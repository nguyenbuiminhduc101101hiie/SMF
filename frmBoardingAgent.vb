'Imports Excel
Public Class frmBoardingAgent

    Dim mStatus, mBoardingAgentID, mStatusP, ETAid As String
    Dim UserRightFrm As String = "frmBoardingAgent"
    Dim mFilter As String
    Dim oTable As New DataSet
    Dim oTableBoarding As New DataTable


    Sub QueryVessel(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Code"
        value = "Data"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select vessel_Code as Code,Vessel as Data From Vessel where Continued=1 Order By Vessel "
        'loadDataToObject(cbo, strSQL, id, value)
        Dim dt As New DataTable
        GetData(dt, strSQL)
        cbo.DisplayMember = "Data"
        cbo.ValueMember = "Code"
        cbo.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub GetData(ByRef dt As DataTable, ByVal strSQL As String)
        Dim Conn As New SqlClient.SqlConnection(strConnDg)
        Dim cmd As New SqlClient.SqlCommand()
        Dim Adapter As New SqlClient.SqlDataAdapter()
        Try
            cmd = New SqlClient.SqlCommand(strSQL, Conn)
            Adapter = New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            MsgBox(True, Err.Description)
        Finally
            Conn.Close()
            Conn = Nothing
            cmd.Dispose()
            cmd = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Sub


    Sub QueryPort(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_ID"
        value = "Data"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Id,Port + ' - ' + Port_Code as Data From Port where Continued=1 Order By Port_Code desc"
        loadDataToObject(cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryBoardingAgent(Optional ByVal arg As String = "")
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String = "select * from BoardingAgent where Continued=1 " & arg
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            'Dim dt As New DataTable
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            If oTableBoarding.Rows.Count > 0 Then
                oTableBoarding.Rows.Clear()
            End If
            Adapter.Fill(oTableBoarding)
            Me.dgdBoardingAgent.DataSource = oTableBoarding
            InsertAutoNumberToGrid(Me.dgdBoardingAgent)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub frmListBoardingAgent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        mStatus = "Normal"
        mBoardingAgentID = DefaultValue
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdBoardingAgent)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Vessel", "Vessel")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "VoyNo", "VoyNo")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "OceanVessel", "OceanVessel")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "OceanVessel VoyNo", "OceanVessel VoyNo")
        'Me.cboFind.Items.Add(oItems)



        'QueryBoardingAgent()


        Dim cbo As ComboBox
        cbo = Me.cboVessel
        QueryVessel(cbo)
        'QuerySailing()
        '
        'cbo = Me.cboOceanVessel
        'QueryVessel(cbo)
        'cbo = Me.cboPort
        'QueryPort(cbo)
        'cbo = Me.cboTranshipPort
        'QueryPort(cbo)


        Me.fraUpdate.Visible = False
        SetDefaultGrid(Me.dgdBoardingAgent, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        ReFormat()
        Exit Sub
Err:

    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Boarding Agent "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Boarding Agent -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Boarding Agent -> Add."
        End If

    End Sub

    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmBoardingAgent", "Add") Then
            SetNullDateText()
            Me.fraUpdate.Visible = True
            Me.dgdBoardingAgent.Enabled = False
            mBoardingAgentID = DefaultValue
            ReFormat()
            SetMenu((False))
            mStatus = "Add"
            reText(mStatus)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        'Me.dgdBoardingAgent.Item("BoardingagentID", index).Visible = False

        Me.txtshipCode.Text = Me.dgdBoardingAgent.Item("shipCode", index).Value.ToString.Trim
        Me.cboVessel.Text = Me.dgdBoardingAgent.Item("Vessel", index).Value.ToString.Trim
        Me.txtVoyageArrival.Text = Me.dgdBoardingAgent.Item("VoyageNoOnArrival", index).Value.ToString.Trim
        Me.txtVoyageDeparture.Text = Me.dgdBoardingAgent.Item("VoyageNoOnDeparture", index).Value.ToString.Trim
        Me.txtServiceTerm.Text = Me.dgdBoardingAgent.Item("ServiceTerm", index).Value.ToString.Trim
        Me.txtOperatorName.Text = Me.dgdBoardingAgent.Item("OperatorName", index).Value.ToString.Trim
        Me.txtAgentName.Text = Me.dgdBoardingAgent.Item("AgentName", index).Value.ToString.Trim
        Me.txtOwnerName.Text = Me.dgdBoardingAgent.Item("OwnerName", index).Value.ToString.Trim
        Me.txtDateOfArrivalAD.Text = Me.dgdBoardingAgent.Item("DateOfArrivalAD", index).Value.ToString.Trim
        Me.txtTimeOfArrivalAD.Text = Me.dgdBoardingAgent.Item("TimeOfArrivalAD", index).Value.ToString.Trim
        Me.txtCaptionNameAD.Text = Me.dgdBoardingAgent.Item("CaptionNameAD", index).Value.ToString.Trim
        Me.txtNumOfCrewAD.Text = Me.dgdBoardingAgent.Item("NumOfCrewAD", index).Value.ToString.Trim
        Me.txtNumOfPassengersAD.Text = Me.dgdBoardingAgent.Item("NumOfPassengersAD", index).Value.ToString.Trim
        Me.txtPositionOfShipInPortAD.Text = Me.dgdBoardingAgent.Item("PositionOfShipInPortAD", index).Value.ToString.Trim
        Me.txtPurposetoportAD.Text = Me.dgdBoardingAgent.Item("PurposeToPortAD", index).Value.ToString.Trim
        Me.txtKindofCargoAD.Text = Me.dgdBoardingAgent.Item("KindOfCargoAD", index).Value.ToString.Trim
        Me.txtFOAD.Text = Me.dgdBoardingAgent.Item("FOAD", index).Value.ToString.Trim
        Me.txtDOAD.Text = Me.dgdBoardingAgent.Item("DOAD", index).Value.ToString.Trim
        Me.txtFWAD.Text = Me.dgdBoardingAgent.Item("FWAD", index).Value.ToString.Trim
        Me.txtdateofarrivalPilotStationAD.Text = Me.dgdBoardingAgent.Item("DateOfArrivalPilotStationAD", index).Value.ToString.Trim
        Me.txtTimeOfArrivalPilotStationAD.Text = Me.dgdBoardingAgent.Item("TimeOfArrivalPilotStationAD", index).Value.ToString.Trim
        Me.txtDateOfArrivalPilotOnboardAD.Text = Me.dgdBoardingAgent.Item("DateOfArrivalPilotOnboardAD", index).Value.ToString.Trim
        Me.txtTimeOfArrivalPilotOnboardAD.Text = Me.dgdBoardingAgent.Item("TimeOfArrivalPilotOnboardAD", index).Value.ToString.Trim
        Me.txtDateOfBerthAD.Text = Me.dgdBoardingAgent.Item("DateOfBerthAD", index).Value.ToString.Trim
        Me.txtTimeOfBerthAD.Text = Me.dgdBoardingAgent.Item("TimeOfBerthAD", index).Value.ToString.Trim
        Me.txtForeDraftAD.Text = Me.dgdBoardingAgent.Item("foreDraftAD", index).Value.ToString.Trim
        Me.txtAfterDraftAD.Text = Me.dgdBoardingAgent.Item("AfterDraftAD", index).Value.ToString.Trim
        Me.txtActualDisplacementAD.Text = Me.dgdBoardingAgent.Item("ActualDisplacementAD", index).Value.ToString.Trim
        Me.txtLastDateOfArrivalAD.Text = Me.dgdBoardingAgent.Item("LastDateOfArrivalAD", index).Value.ToString.Trim
        Me.cboPreviousPortAD.text = Me.dgdBoardingAgent.Item("PreviousPortAD", index).Value.ToString.Trim
        Me.cboDis_LoadPortAD.Text = Me.dgdBoardingAgent.Item("Dis_LoadPortAD", index).Value.ToString.Trim
        Me.cboNextPortAD.Text = Me.dgdBoardingAgent.Item("NextPortAD", index).Value.ToString.Trim
        Me.txtDateCommencingOperationAD.Text = Me.dgdBoardingAgent.Item("DateCommencingOperationAD", index).Value.ToString.Trim
        Me.txtTimeCommencingOperationAD.Text = Me.dgdBoardingAgent.Item("TimeCommencingOperationAD", index).Value.ToString.Trim
        Me.txtE20GPAD.Text = Me.dgdBoardingAgent.Item("E20GPAD", index).Value.ToString.Trim
        Me.txtE40GPAD.Text = Me.dgdBoardingAgent.Item("E40GPAD", index).Value.ToString.Trim
        Me.txtE20HCAD.Text = Me.dgdBoardingAgent.Item("E20HCAD", index).Value.ToString.Trim
        Me.txtE40HCAD.Text = Me.dgdBoardingAgent.Item("E40HCAD", index).Value.ToString.Trim
        Me.txtE45HCAD.Text = Me.dgdBoardingAgent.Item("E45HCAD", index).Value.ToString.Trim
        Me.txtE20RFAD.Text = Me.dgdBoardingAgent.Item("E20RFAD", index).Value.ToString.Trim
        Me.txtE40RFAD.Text = Me.dgdBoardingAgent.Item("E40RFAD", index).Value.ToString.Trim
        Me.txtE20RHAD.Text = Me.dgdBoardingAgent.Item("E20RHAD", index).Value.ToString.Trim
        Me.txtE40RHAD.Text = Me.dgdBoardingAgent.Item("E40RHAD", index).Value.ToString.Trim
        Me.txtE45RHAD.Text = Me.dgdBoardingAgent.Item("E45RHAD", index).Value.ToString.Trim
        Me.txtE20FRAD.Text = Me.dgdBoardingAgent.Item("E20FRAD", index).Value.ToString.Trim
        Me.txtE40FRAD.Text = Me.dgdBoardingAgent.Item("E40FRAD", index).Value.ToString.Trim
        Me.txtE20HGAD.Text = Me.dgdBoardingAgent.Item("E20HGAD", index).Value.ToString.Trim
        Me.txtE40HGAD.Text = Me.dgdBoardingAgent.Item("E40HGAD", index).Value.ToString.Trim
        Me.txtE40GHAD.Text = Me.dgdBoardingAgent.Item("E40GHAD", index).Value.ToString.Trim
        Me.txtE20OTAD.Text = Me.dgdBoardingAgent.Item("E20OTAD", index).Value.ToString.Trim
        Me.txtE40OTAD.Text = Me.dgdBoardingAgent.Item("E40OTAD", index).Value.ToString.Trim
        Me.txtE20TKAD.Text = Me.dgdBoardingAgent.Item("E20TKAD", index).Value.ToString.Trim
        Me.txtE40TKAD.Text = Me.dgdBoardingAgent.Item("E40TKAD", index).Value.ToString.Trim
        Me.TXTECNTRAD.Text = Me.dgdBoardingAgent.Item("ECNTRAD", index).Value.ToString.Trim
        Me.TXTETEUAD.Text = Me.dgdBoardingAgent.Item("ETEUAD", index).Value.ToString.Trim
        Me.TXTETONSAD.Text = Me.dgdBoardingAgent.Item("ETONSAD", index).Value.ToString.Trim
        Me.txtF20GPAD.Text = Me.dgdBoardingAgent.Item("F20GPAD", index).Value.ToString.Trim
        Me.txtF40GPAD.Text = Me.dgdBoardingAgent.Item("F40GPAD", index).Value.ToString.Trim
        Me.txtF20HCAD.Text = Me.dgdBoardingAgent.Item("F20HCAD", index).Value.ToString.Trim
        Me.txtF40HCAD.Text = Me.dgdBoardingAgent.Item("F40HCAD", index).Value.ToString.Trim
        Me.txtF45HCAD.Text = Me.dgdBoardingAgent.Item("F45HCAD", index).Value.ToString.Trim
        Me.txtF20RFAD.Text = Me.dgdBoardingAgent.Item("F20RFAD", index).Value.ToString.Trim
        Me.txtF40RFAD.Text = Me.dgdBoardingAgent.Item("F40RFAD", index).Value.ToString.Trim
        Me.txtF20RHAD.Text = Me.dgdBoardingAgent.Item("F20RHAD", index).Value.ToString.Trim
        Me.txtF40RHAD.Text = Me.dgdBoardingAgent.Item("F40RHAD", index).Value.ToString.Trim
        Me.txtF45RHAD.Text = Me.dgdBoardingAgent.Item("F45RHAD", index).Value.ToString.Trim
        Me.txtF20FRAD.Text = Me.dgdBoardingAgent.Item("F20FRAD", index).Value.ToString.Trim
        Me.txtF40FRAD.Text = Me.dgdBoardingAgent.Item("F40FRAD", index).Value.ToString.Trim
        Me.txtF20HGAD.Text = Me.dgdBoardingAgent.Item("F20HGAD", index).Value.ToString.Trim
        Me.txtF40HGAD.Text = Me.dgdBoardingAgent.Item("F40HGAD", index).Value.ToString.Trim
        Me.txtF40GHAD.Text = Me.dgdBoardingAgent.Item("F40GHAD", index).Value.ToString.Trim
        Me.txtF20OTAD.Text = Me.dgdBoardingAgent.Item("F20OTAD", index).Value.ToString.Trim
        Me.txtF40OTAD.Text = Me.dgdBoardingAgent.Item("F40OTAD", index).Value.ToString.Trim
        Me.txtF20TKAD.Text = Me.dgdBoardingAgent.Item("F20TKAD", index).Value.ToString.Trim
        Me.txtF40TKAD.Text = Me.dgdBoardingAgent.Item("F40TKAD", index).Value.ToString.Trim
        Me.txtFCNTRAD.Text = Me.dgdBoardingAgent.Item("FCNTRAD", index).Value.ToString.Trim
        Me.txtFTEUAD.Text = Me.dgdBoardingAgent.Item("FTEUAD", index).Value.ToString.Trim
        Me.txtFTONAD.Text = Me.dgdBoardingAgent.Item("FTONSAD", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCNTRAD.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCNTRAD", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoTONSAD.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoTONSAD", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCLASSAD.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCLASSAD", index).Value.ToString.Trim
        Me.txtOtherConcerningRequirementOfShipAD.Text = Me.dgdBoardingAgent.Item("OtherConcerningRequirementOfShipAD", index).Value.ToString.Trim
        Me.txtRemaksAD.Text = Me.dgdBoardingAgent.Item("RemaksAD", index).Value.ToString.Trim
        Me.txtCaptionNameDD.Text = Me.dgdBoardingAgent.Item("CaptionNameDD", index).Value.ToString.Trim
        Me.txtNumOfCrewDD.Text = Me.dgdBoardingAgent.Item("NumOfCrewDD", index).Value.ToString.Trim
        Me.txtNumOfPassengersDD.Text = Me.dgdBoardingAgent.Item("NumOfPassengersDD", index).Value.ToString.Trim
        Me.txtPositionOfShipInPortDD.Text = Me.dgdBoardingAgent.Item("PositionOfShipInPortDD", index).Value.ToString.Trim
        Me.txtPurposeToPortDD.Text = Me.dgdBoardingAgent.Item("PurposeToPortDD", index).Value.ToString.Trim
        Me.txtKindOfCargoDD.Text = Me.dgdBoardingAgent.Item("KindOfCargoDD", index).Value.ToString.Trim
        Me.txtFODD.Text = Me.dgdBoardingAgent.Item("FODD", index).Value.ToString.Trim
        Me.txtDODD.Text = Me.dgdBoardingAgent.Item("DODD", index).Value.ToString.Trim
        Me.txtFWDD.Text = Me.dgdBoardingAgent.Item("FWDD", index).Value.ToString.Trim
        Me.txtDateOfArrivalPilotStationDD.Text = Me.dgdBoardingAgent.Item("DateOfArrivalPilotStationDD", index).Value.ToString.Trim
        Me.txtTimeOfArrivalPilotStationDD.Text = Me.dgdBoardingAgent.Item("TimeOfArrivalPilotStationDD", index).Value.ToString.Trim
        Me.txtDateOfArrivalPilotOnboardDD.Text = Me.dgdBoardingAgent.Item("DateOfArrivalPilotOnboardDD", index).Value.ToString.Trim
        Me.txtTimeOfArrivalPilotOnboardDD.Text = Me.dgdBoardingAgent.Item("TimeOfArrivalPilotOnboardDD", index).Value.ToString.Trim
        Me.txtDateOfBerthDD.Text = Me.dgdBoardingAgent.Item("DateOfBerthDD", index).Value.ToString.Trim
        Me.txtTimeOfBerthDD.Text = Me.dgdBoardingAgent.Item("TimeOfBerthDD", index).Value.ToString.Trim
        Me.txtforeDraftDD.Text = Me.dgdBoardingAgent.Item("foreDraftDD", index).Value.ToString.Trim
        Me.txtAfterDraftDD.Text = Me.dgdBoardingAgent.Item("AfterDraftDD", index).Value.ToString.Trim
        Me.txtActualDisplacementDD.Text = Me.dgdBoardingAgent.Item("ActualDisplacementDD", index).Value.ToString.Trim
        Me.txtLastDateOfArrivalDD.Text = Me.dgdBoardingAgent.Item("LastDateOfArrivalDD", index).Value.ToString.Trim
        Me.cboPreviousPortDD.Text = Me.dgdBoardingAgent.Item("PreviousPortDD", index).Value.ToString.Trim
        Me.cboDis_LoadPortDD.Text = Me.dgdBoardingAgent.Item("Dis_LoadPortDD", index).Value.ToString.Trim
        Me.cboNextPortDD.Text = Me.dgdBoardingAgent.Item("NextPortDD", index).Value.ToString.Trim
        Me.txtDateCommencingOperationDD.Text = Me.dgdBoardingAgent.Item("DateCommencingOperationDD", index).Value.ToString.Trim
        Me.txtTimeCommencingOperationDD.Text = Me.dgdBoardingAgent.Item("TimeCommencingOperationDD", index).Value.ToString.Trim
        Me.txtE20GPDD.Text = Me.dgdBoardingAgent.Item("E20GPDD", index).Value.ToString.Trim
        Me.txtE40GPDD.Text = Me.dgdBoardingAgent.Item("E40GPDD", index).Value.ToString.Trim
        Me.txtE20HCDD.Text = Me.dgdBoardingAgent.Item("E20HCDD", index).Value.ToString.Trim
        Me.txtE40HCDD.Text = Me.dgdBoardingAgent.Item("E40HCDD", index).Value.ToString.Trim
        Me.txtE45HCDD.Text = Me.dgdBoardingAgent.Item("E45HCDD", index).Value.ToString.Trim
        Me.txtE20RFDD.Text = Me.dgdBoardingAgent.Item("E20RFDD", index).Value.ToString.Trim
        Me.txtE40RFDD.Text = Me.dgdBoardingAgent.Item("E40RFDD", index).Value.ToString.Trim
        Me.txtE20RHDD.Text = Me.dgdBoardingAgent.Item("E20RHDD", index).Value.ToString.Trim
        Me.txtE40RHDD.Text = Me.dgdBoardingAgent.Item("E40RHDD", index).Value.ToString.Trim
        Me.txtE45RHDD.Text = Me.dgdBoardingAgent.Item("E45RHDD", index).Value.ToString.Trim
        Me.txtE20FRDD.Text = Me.dgdBoardingAgent.Item("E20FRDD", index).Value.ToString.Trim
        Me.txtE40FRDD.Text = Me.dgdBoardingAgent.Item("E40FRDD", index).Value.ToString.Trim
        Me.txtE20HGDD.Text = Me.dgdBoardingAgent.Item("E20HGDD", index).Value.ToString.Trim
        Me.txtE40HGDD.Text = Me.dgdBoardingAgent.Item("E40HGDD", index).Value.ToString.Trim
        Me.txtE40GHDD.Text = Me.dgdBoardingAgent.Item("E40GHDD", index).Value.ToString.Trim
        Me.txtE20OTDD.Text = Me.dgdBoardingAgent.Item("E20OTDD", index).Value.ToString.Trim
        Me.txtE40OTDD.Text = Me.dgdBoardingAgent.Item("E40OTDD", index).Value.ToString.Trim
        Me.txtE20TKDD.Text = Me.dgdBoardingAgent.Item("E20TKDD", index).Value.ToString.Trim
        Me.txtE40TKDD.Text = Me.dgdBoardingAgent.Item("E40TKDD", index).Value.ToString.Trim
        Me.txtECNTRDD.Text = Me.dgdBoardingAgent.Item("ECNTRDD", index).Value.ToString.Trim
        Me.txtETEUDD.Text = Me.dgdBoardingAgent.Item("ETEUDD", index).Value.ToString.Trim
        Me.txtETONDD.Text = Me.dgdBoardingAgent.Item("ETONSDD", index).Value.ToString.Trim
        Me.txtF20GPDD.Text = Me.dgdBoardingAgent.Item("F20GPDD", index).Value.ToString.Trim
        Me.txtF40GPDD.Text = Me.dgdBoardingAgent.Item("F40GPDD", index).Value.ToString.Trim
        Me.txtF20HCDD.Text = Me.dgdBoardingAgent.Item("F20HCDD", index).Value.ToString.Trim
        Me.txtF40HCDD.Text = Me.dgdBoardingAgent.Item("F40HCDD", index).Value.ToString.Trim
        Me.txtF45HCDD.Text = Me.dgdBoardingAgent.Item("F45HCDD", index).Value.ToString.Trim
        Me.txtF20RFDD.Text = Me.dgdBoardingAgent.Item("F20RFDD", index).Value.ToString.Trim
        Me.txtF40RFDD.Text = Me.dgdBoardingAgent.Item("F40RFDD", index).Value.ToString.Trim
        Me.txtF20RHDD.Text = Me.dgdBoardingAgent.Item("F20RHDD", index).Value.ToString.Trim
        Me.txtF40RHDD.Text = Me.dgdBoardingAgent.Item("F40RHDD", index).Value.ToString.Trim
        Me.txtF45RHDD.Text = Me.dgdBoardingAgent.Item("F45RHDD", index).Value.ToString.Trim
        Me.txtF20FRDD.Text = Me.dgdBoardingAgent.Item("F20FRDD", index).Value.ToString.Trim
        Me.txtF40FRDD.Text = Me.dgdBoardingAgent.Item("F40FRDD", index).Value.ToString.Trim
        Me.txtF20HGDD.Text = Me.dgdBoardingAgent.Item("F20HGDD", index).Value.ToString.Trim
        Me.txtF40HGDD.Text = Me.dgdBoardingAgent.Item("F40HGDD", index).Value.ToString.Trim
        Me.txtF40GHDD.Text = Me.dgdBoardingAgent.Item("F40GHDD", index).Value.ToString.Trim
        Me.txtF20OTDD.Text = Me.dgdBoardingAgent.Item("F20OTDD", index).Value.ToString.Trim
        Me.txtF40OTDD.Text = Me.dgdBoardingAgent.Item("F40OTDD", index).Value.ToString.Trim
        Me.txtF20TKDD.Text = Me.dgdBoardingAgent.Item("F20TKDD", index).Value.ToString.Trim
        Me.txtF40TKDD.Text = Me.dgdBoardingAgent.Item("F40TKDD", index).Value.ToString.Trim
        Me.txtFCNTRDD.Text = Me.dgdBoardingAgent.Item("FCNTRDD", index).Value.ToString.Trim
        Me.txtFTEUDD.Text = Me.dgdBoardingAgent.Item("FTEUDD", index).Value.ToString.Trim
        Me.txtFTONDD.Text = Me.dgdBoardingAgent.Item("FTONSDD", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCNTRDD.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCNTRDD", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoTONSDD.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoTONSDD", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCLASSDD.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCLASSDD", index).Value.ToString.Trim
        Me.txtOtherConcerningRequirementOfShipDD.Text = Me.dgdBoardingAgent.Item("OtherConcerningRequirementOfShipDD", index).Value.ToString.Trim
        Me.txtRemarksDD.Text = Me.dgdBoardingAgent.Item("RemarksDD", index).Value.ToString.Trim
        Me.txtE20GPAD1.Text = Me.dgdBoardingAgent.Item("E20GPAD1", index).Value.ToString.Trim
        Me.txtE40GPAD1.Text = Me.dgdBoardingAgent.Item("E40GPAD1", index).Value.ToString.Trim
        Me.txtE20HCAD1.Text = Me.dgdBoardingAgent.Item("E20HCAD1", index).Value.ToString.Trim
        Me.txtE40HCAD1.Text = Me.dgdBoardingAgent.Item("E40HCAD1", index).Value.ToString.Trim
        Me.txtE45HCAD1.Text = Me.dgdBoardingAgent.Item("E45HCAD1", index).Value.ToString.Trim
        Me.txtE20RFAD1.Text = Me.dgdBoardingAgent.Item("E20RFAD1", index).Value.ToString.Trim
        Me.txtE40RFAD1.Text = Me.dgdBoardingAgent.Item("E40RFAD1", index).Value.ToString.Trim
        Me.txtE20RHAD1.Text = Me.dgdBoardingAgent.Item("E20RHAD1", index).Value.ToString.Trim
        Me.txtE40RHAD1.Text = Me.dgdBoardingAgent.Item("E40RHAD1", index).Value.ToString.Trim
        Me.txtE45RHAD1.Text = Me.dgdBoardingAgent.Item("E45RHAD1", index).Value.ToString.Trim
        Me.txtE20FRAD1.Text = Me.dgdBoardingAgent.Item("E20FRAD1", index).Value.ToString.Trim
        Me.txtE40FRAD1.Text = Me.dgdBoardingAgent.Item("E40FRAD1", index).Value.ToString.Trim
        Me.txtE20HGAD1.Text = Me.dgdBoardingAgent.Item("E20HGAD1", index).Value.ToString.Trim
        Me.txtE40HGAD1.Text = Me.dgdBoardingAgent.Item("E40HGAD1", index).Value.ToString.Trim
        Me.txtE40GHAD1.Text = Me.dgdBoardingAgent.Item("E40GHAD1", index).Value.ToString.Trim
        Me.txtE20OTAD1.Text = Me.dgdBoardingAgent.Item("E20OTAD1", index).Value.ToString.Trim
        Me.txtE40OTAD1.Text = Me.dgdBoardingAgent.Item("E40OTAD1", index).Value.ToString.Trim
        Me.txtE20TKAD1.Text = Me.dgdBoardingAgent.Item("E20TKAD1", index).Value.ToString.Trim
        Me.txtE40TKAD1.Text = Me.dgdBoardingAgent.Item("E40TKAD1", index).Value.ToString.Trim
        Me.txtECNTRAD1.Text = Me.dgdBoardingAgent.Item("ECNTRAD1", index).Value.ToString.Trim
        Me.txtETEUAD1.Text = Me.dgdBoardingAgent.Item("ETEUAD1", index).Value.ToString.Trim
        Me.txtETONAD1.Text = Me.dgdBoardingAgent.Item("ETONSAD1", index).Value.ToString.Trim
        Me.txtF20GPAD1.Text = Me.dgdBoardingAgent.Item("F20GPAD1", index).Value.ToString.Trim
        Me.txtF40GPAD1.Text = Me.dgdBoardingAgent.Item("F40GPAD1", index).Value.ToString.Trim
        Me.txtF20HCAD1.Text = Me.dgdBoardingAgent.Item("F20HCAD1", index).Value.ToString.Trim
        Me.txtF40HCAD1.Text = Me.dgdBoardingAgent.Item("F40HCAD1", index).Value.ToString.Trim
        Me.txtF45HCAD1.Text = Me.dgdBoardingAgent.Item("F45HCAD1", index).Value.ToString.Trim
        Me.txtF20RFAD1.Text = Me.dgdBoardingAgent.Item("F20RFAD1", index).Value.ToString.Trim
        Me.txtF40RFAD1.Text = Me.dgdBoardingAgent.Item("F40RFAD1", index).Value.ToString.Trim
        Me.txtF20RHAD1.Text = Me.dgdBoardingAgent.Item("F20RHAD1", index).Value.ToString.Trim
        Me.txtF40RHAD1.Text = Me.dgdBoardingAgent.Item("F40RHAD1", index).Value.ToString.Trim
        Me.txtF45RHAD1.Text = Me.dgdBoardingAgent.Item("F45RHAD1", index).Value.ToString.Trim
        Me.txtF20FRAD1.Text = Me.dgdBoardingAgent.Item("F20FRAD1", index).Value.ToString.Trim
        Me.txtF40FRAD1.Text = Me.dgdBoardingAgent.Item("F40FRAD1", index).Value.ToString.Trim
        Me.txtF20HGAD1.Text = Me.dgdBoardingAgent.Item("F20HGAD1", index).Value.ToString.Trim
        Me.txtF40HGAD1.Text = Me.dgdBoardingAgent.Item("F40HGAD1", index).Value.ToString.Trim
        Me.txtF40GHAD1.Text = Me.dgdBoardingAgent.Item("F40GHAD1", index).Value.ToString.Trim
        Me.txtF20OTAD1.Text = Me.dgdBoardingAgent.Item("F20OTAD1", index).Value.ToString.Trim
        Me.txtF40OTAD1.Text = Me.dgdBoardingAgent.Item("F40OTAD1", index).Value.ToString.Trim
        Me.txtF20TKAD1.Text = Me.dgdBoardingAgent.Item("F20TKAD1", index).Value.ToString.Trim
        Me.txtF40TKAD1.Text = Me.dgdBoardingAgent.Item("F40TKAD1", index).Value.ToString.Trim
        Me.txtFCNTRAD1.Text = Me.dgdBoardingAgent.Item("FCNTRAD1", index).Value.ToString.Trim
        Me.txtFTEUAD1.Text = Me.dgdBoardingAgent.Item("FTEUAD1", index).Value.ToString.Trim
        Me.txtFTONAD1.Text = Me.dgdBoardingAgent.Item("FTONSAD1", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCNTRAD1.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCNTRAD1", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoTONSDD1.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoTONSAD1", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCLASSAD1.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCLASSAD1", index).Value.ToString.Trim
        Me.txtOtherConcerningRequirementOfShipAD1.Text = Me.dgdBoardingAgent.Item("OtherConcerningRequirementOfShipAD1", index).Value.ToString.Trim
        Me.txtRemaksAD1.Text = Me.dgdBoardingAgent.Item("RemaksAD1", index).Value.ToString.Trim
        'Me.txtCaptionNameDD1.text = Me.dgdBoardingAgent.Item("CaptionNameDD1", index).Value.ToString.Trim
        'Me.txtNumOfCrewDD1.text = Me.dgdBoardingAgent.Item("NumOfCrewDD1", index).Value.ToString.Trim
        'Me.txtNumOfPassengersDD1.text = Me.dgdBoardingAgent.Item("NumOfPassengersDD1", index).Value.ToString.Trim
        'Me.txtPositionOfShipInPortDD1.text = Me.dgdBoardingAgent.Item("PositionOfShipInPortDD1", index).Value.ToString.Trim
        'Me.txtPurposeToPortDD1.text = Me.dgdBoardingAgent.Item("PurposeToPortDD1", index).Value.ToString.Trim
        'Me.txtKindOfCargoDD1.text = Me.dgdBoardingAgent.Item("KindOfCargoDD1", index).Value.ToString.Trim
        'Me.txtFODD1.text = Me.dgdBoardingAgent.Item("FODD1", index).Value.ToString.Trim
        'Me.txtDODD1.text = Me.dgdBoardingAgent.Item("DODD1", index).Value.ToString.Trim
        'Me.txtFWDD1.text = Me.dgdBoardingAgent.Item("FWDD1", index).Value.ToString.Trim
        'Me.txtDateOfArrivalPilotStationDD1.text = Me.dgdBoardingAgent.Item("DateOfArrivalPilotStationDD1", index).Value.ToString.Trim
        'Me.txtTimeOfArrivalPilotStationDD1.text = Me.dgdBoardingAgent.Item("TimeOfArrivalPilotStationDD1", index).Value.ToString.Trim
        'Me.txtDateOfArrivalPilotOnboardDD1.text = Me.dgdBoardingAgent.Item("DateOfArrivalPilotOnboardDD1", index).Value.ToString.Trim
        'Me.txtTimeOfArrivalPilotOnboardDD1.text = Me.dgdBoardingAgent.Item("TimeOfArrivalPilotOnboardDD1", index).Value.ToString.Trim
        'Me.txtDateOfBerthDD1.text = Me.dgdBoardingAgent.Item("DateOfBerthDD1", index).Value.ToString.Trim
        'Me.txtTimeOfBerthDD1.text = Me.dgdBoardingAgent.Item("TimeOfBerthDD1", index).Value.ToString.Trim
        'Me.txtforeDraftDD1.text = Me.dgdBoardingAgent.Item("foreDraftDD1", index).Value.ToString.Trim
        'Me.txtAfterDraftDD1.text = Me.dgdBoardingAgent.Item("AfterDraftDD1", index).Value.ToString.Trim
        'Me.txtActualDisplacementDD1.text = Me.dgdBoardingAgent.Item("ActualDisplacementDD1", index).Value.ToString.Trim
        'Me.txtLastDateOfArrivalDD1.text = Me.dgdBoardingAgent.Item("LastDateOfArrivalDD1", index).Value.ToString.Trim
        'Me.cboPreviousPortDD1.text = Me.dgdBoardingAgent.Item("PreviousPortDD1", index).Value.ToString.Trim
        'Me.cboDis_LoadPortDD1.text = Me.dgdBoardingAgent.Item("Dis_LoadPortDD1", index).Value.ToString.Trim
        'Me.cboNextPortDD1.text = Me.dgdBoardingAgent.Item("NextPortDD1", index).Value.ToString.Trim
        'Me.txtDateCommencingOperationDD1.text = Me.dgdBoardingAgent.Item("DateCommencingOperationDD1", index).Value.ToString.Trim
        'Me.txtTimeCommencingOperationDD1.text = Me.dgdBoardingAgent.Item("TimeCommencingOperationDD1", index).Value.ToString.Trim
        Me.txtE20GPDD1.Text = Me.dgdBoardingAgent.Item("E20GPDD1", index).Value.ToString.Trim
        Me.txtE40GPDD1.Text = Me.dgdBoardingAgent.Item("E40GPDD1", index).Value.ToString.Trim
        Me.txtE20HCDD1.Text = Me.dgdBoardingAgent.Item("E20HCDD1", index).Value.ToString.Trim
        Me.txtE40HCDD1.Text = Me.dgdBoardingAgent.Item("E40HCDD1", index).Value.ToString.Trim
        Me.txtE45HCDD1.Text = Me.dgdBoardingAgent.Item("E45HCDD1", index).Value.ToString.Trim
        Me.txtE20RFDD1.Text = Me.dgdBoardingAgent.Item("E20RFDD1", index).Value.ToString.Trim
        Me.txtE40RFDD1.Text = Me.dgdBoardingAgent.Item("E40RFDD1", index).Value.ToString.Trim
        Me.txtE20RHDD1.Text = Me.dgdBoardingAgent.Item("E20RHDD1", index).Value.ToString.Trim
        Me.txtE40RHDD1.Text = Me.dgdBoardingAgent.Item("E40RHDD1", index).Value.ToString.Trim
        Me.txtE45RHDD1.Text = Me.dgdBoardingAgent.Item("E45RHDD1", index).Value.ToString.Trim
        Me.txtE20FRDD1.Text = Me.dgdBoardingAgent.Item("E20FRDD1", index).Value.ToString.Trim
        Me.txtE40FRDD1.Text = Me.dgdBoardingAgent.Item("E40FRDD1", index).Value.ToString.Trim
        Me.txtE20HGDD1.Text = Me.dgdBoardingAgent.Item("E20HGDD1", index).Value.ToString.Trim
        Me.txtE40HGDD1.Text = Me.dgdBoardingAgent.Item("E40HGDD1", index).Value.ToString.Trim
        Me.txtE40GHDD1.Text = Me.dgdBoardingAgent.Item("E40GHDD1", index).Value.ToString.Trim
        Me.txtE20OTDD1.Text = Me.dgdBoardingAgent.Item("E20OTDD1", index).Value.ToString.Trim
        Me.txtE40OTDD1.Text = Me.dgdBoardingAgent.Item("E40OTDD1", index).Value.ToString.Trim
        Me.txtE20TKDD1.Text = Me.dgdBoardingAgent.Item("E20TKDD1", index).Value.ToString.Trim
        Me.txtE40TKDD1.Text = Me.dgdBoardingAgent.Item("E40TKDD1", index).Value.ToString.Trim
        Me.txtECNTRDD1.Text = Me.dgdBoardingAgent.Item("ECNTRDD1", index).Value.ToString.Trim
        Me.txtETEUDD1.Text = Me.dgdBoardingAgent.Item("ETEUDD1", index).Value.ToString.Trim
        Me.txtETONDD1.Text = Me.dgdBoardingAgent.Item("ETONSDD1", index).Value.ToString.Trim
        Me.txtF20GPDD1.Text = Me.dgdBoardingAgent.Item("F20GPDD1", index).Value.ToString.Trim
        Me.txtF40GPDD1.Text = Me.dgdBoardingAgent.Item("F40GPDD1", index).Value.ToString.Trim
        Me.txtF20HCDD1.Text = Me.dgdBoardingAgent.Item("F20HCDD1", index).Value.ToString.Trim
        Me.txtF40HCDD1.Text = Me.dgdBoardingAgent.Item("F40HCDD1", index).Value.ToString.Trim
        Me.txtF45HCDD1.Text = Me.dgdBoardingAgent.Item("F45HCDD1", index).Value.ToString.Trim
        Me.txtF20RFDD1.Text = Me.dgdBoardingAgent.Item("F20RFDD1", index).Value.ToString.Trim
        Me.txtF40RFDD1.Text = Me.dgdBoardingAgent.Item("F40RFDD1", index).Value.ToString.Trim
        Me.txtF20RHDD1.Text = Me.dgdBoardingAgent.Item("F20RHDD1", index).Value.ToString.Trim
        Me.txtF40RHDD1.Text = Me.dgdBoardingAgent.Item("F40RHDD1", index).Value.ToString.Trim
        Me.txtF45RHDD1.Text = Me.dgdBoardingAgent.Item("F45RHDD1", index).Value.ToString.Trim
        Me.txtF20FRDD1.Text = Me.dgdBoardingAgent.Item("F20FRDD1", index).Value.ToString.Trim
        Me.txtF40FRDD1.Text = Me.dgdBoardingAgent.Item("F40FRDD1", index).Value.ToString.Trim
        Me.txtF20HGDD1.Text = Me.dgdBoardingAgent.Item("F20HGDD1", index).Value.ToString.Trim
        Me.txtF40HGDD1.Text = Me.dgdBoardingAgent.Item("F40HGDD1", index).Value.ToString.Trim
        Me.txtF40GHDD1.Text = Me.dgdBoardingAgent.Item("F40GHDD1", index).Value.ToString.Trim
        Me.txtF20OTDD1.Text = Me.dgdBoardingAgent.Item("F20OTDD1", index).Value.ToString.Trim
        Me.txtF40OTDD1.Text = Me.dgdBoardingAgent.Item("F40OTDD1", index).Value.ToString.Trim
        Me.txtF20TKDD1.Text = Me.dgdBoardingAgent.Item("F20TKDD1", index).Value.ToString.Trim
        Me.txtF40TKDD1.Text = Me.dgdBoardingAgent.Item("F40TKDD1", index).Value.ToString.Trim
        Me.txtFCNTRDD1.Text = Me.dgdBoardingAgent.Item("FCNTRDD1", index).Value.ToString.Trim
        Me.txtFTEUDD1.Text = Me.dgdBoardingAgent.Item("FTEUDD1", index).Value.ToString.Trim
        Me.txtFTONDD1.Text = Me.dgdBoardingAgent.Item("FTONSDD1", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCNTRDD1.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCNTRDD1", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoTONSDD1.text = Me.dgdBoardingAgent.Item("DangerousInboundCargoTONSDD1", index).Value.ToString.Trim
        Me.txtDangerousInboundCargoCLASSDD1.Text = Me.dgdBoardingAgent.Item("DangerousInboundCargoCLASSDD1", index).Value.ToString.Trim
        Me.txtOtherConcerningRequirementOfShipDD1.Text = Me.dgdBoardingAgent.Item("OtherConcerningRequirementOfShipDD1", index).Value.ToString.Trim
        Me.txtApplicationForArrivalDate.Text = Me.dgdBoardingAgent.Item("ApplicationForArrivalDate", index).Value.ToString.Trim
        Me.txtTheApprovalPort.Text = Me.dgdBoardingAgent.Item("TheApprovalPort", index).Value.ToString.Trim
        'Me.dgdBoardingAgent.Item("Editable", index).Visible = False
        'Me.dgdBoardingAgent.Item("Continued", index).Visible = False
        'Me.txtApprove.text = Me.dgdBoardingAgent.Item("Approve", index).Value.ToString.Trim
        'Me.txtUserID.text = Me.dgdBoardingAgent.Item("UserID", index).Value.ToString.Trim
        'Me.txtUpdattime.text = Me.dgdBoardingAgent.Item("Updattime", index).Value.ToString.Trim
        If Me.dgdBoardingAgent.Item("ApproveArrival", index).Value.ToString.Trim <> "" Then
            Me.chkApproveETA.Checked = Me.dgdBoardingAgent.Item("ApproveArrival", index).Value
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub




    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(fraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(fraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.dgdBoardingAgent.Left = 10
        dgdBoardingAgent.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdBoardingAgent.Height = Me.Height - Me.cmdOk.Height - 65 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdBoardingAgent.Height = Me.Height - Me.cmdOk.Height - 105 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 20)
        fraUpdate.Top = Me.dgdBoardingAgent.Height + dgdBoardingAgent.Top

        cmdOk.Top = fraUpdate.Bottom + 5
        cmdCancel.Top = cmdOk.Top
        cmdFind.Left = Me.FindBoardingAgent.Left + Me.FindBoardingAgent.Width + 10
        'txtBoardingAgent.Width = Me.Width - 297
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg, BookingNumber As String
        Dim strQuery As String
        Dim ctr As Control
        Dim rs As New ADODB.Recordset
        CheckData = True
        strMsg = ""
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM Boardingagent "
        strQuery = strQuery & "WHERE shipCode = '" & Me.txtshipCode.Text.Trim & "' And Continued=1 And VoyageNoOnArrival = '" & Me.txtVoyageArrival.Text.Trim & "' and VoyageNoOnDeparture = '" & Me.txtVoyageDeparture.Text.Trim & "' And  BoardingAgentID <> '" & mBoardingAgentID & "' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            CheckData = False
            rs.Close()
            DisplayMessage(True, "This Boarding agent had already in database, please check again!")
            Return CheckData
        End If


        'For Each ctr In Me.Controls
        '    If UCase(ctr.Name) Like "TXT*" Then
        '        If ctr.Text = "" Then
        '            CheckData = False
        '            strMsg += "The " & Replace(UCase(ctr.Name), "TXT", "") & "is invalid. Please check again."
        '        End If
        '    End If
        'Next

        check(Me)
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Public Sub check(ByVal Container As Object)
        Dim cControl As Control
        If Container.haschildren Then
            For Each cControl In Container.controls

                If LCase(cControl.Name) Like "*txt*" Then
                    MsgBox(LCase(cControl.Name).Replace("txt", "") & " not allow null value. Please check again.")
                    Return
                End If
                If cControl.HasChildren Then 'nếu con có controls trong controls
                    check(cControl)
                End If
            Next cControl
        End If
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strContainerOutboundNotifyId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdBoardingAgent.RowCount > 0 And mStatus = "Edit" Then
            index = Me.dgdBoardingAgent.CurrentRow.Index
        End If
        If checkdata() = False Then
            DisplayMessage(True, "Please, check your data.!")
            Return
        End If
        'If Me.cboOceanVessel.Text = "" Then
        '    DisplayMessage(True, "You have to Input the Ocean Vessel Name ")
        '    Me.cboOceanVessel.Focus()
        '    Return
        'End If
        'If Me.cboVessel.Text = "" Then
        '    DisplayMessage(True, "You have to Input the Vessel Name ")
        '    Me.cboVessel.Focus()
        '    Return
        'End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            If mStatus = "Edit" Then
                CopyValues("BoardingAgent", "BoardingAgentID", mBoardingAgentID)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM BoardingAgent "
            strQuery = strQuery & "WHERE  BoardingAgentID= '" & mBoardingAgentID & "' AND BoardingAgentID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BoardingAgentID").Value = NewId()
                End If

                .Fields("shipCode").Value = Me.txtshipCode.Text.Trim
                .Fields("Vessel").Value = Me.cboVessel.Text.Trim
                .Fields("VoyageNoOnArrival").Value = Me.txtVoyageArrival.Text.Trim
                .Fields("VoyageNoOnDeparture").Value = Me.txtVoyageDeparture.Text.Trim
                .Fields("ServiceTerm").Value = Me.txtServiceTerm.Text.Trim
                .Fields("OperatorName").Value = Me.txtOperatorName.Text.Trim
                .Fields("AgentName").Value = Me.txtAgentName.Text.Trim
                .Fields("OwnerName").Value = Me.txtOwnerName.Text.Trim
                .Fields("DateOfArrivalAD").Value = Me.txtDateOfArrivalAD.Text.Trim
                .Fields("TimeOfArrivalAD").Value = Me.txtTimeOfArrivalAD.Text.Trim
                .Fields("CaptionNameAD").Value = Me.txtCaptionNameAD.Text.Trim
                .Fields("NumOfCrewAD").Value = Me.txtNumOfCrewAD.Text.Trim
                .Fields("NumOfPassengersAD").Value = Me.txtNumOfPassengersAD.Text.Trim
                .Fields("PositionOfShipInPortAD").Value = Me.txtPositionOfShipInPortAD.Text.Trim
                .Fields("PurposeToPortAD").Value = Me.txtPurposetoportAD.Text.Trim
                .Fields("KindOfCargoAD").Value = Me.txtKindofCargoAD.Text.Trim
                .Fields("FOAD").Value = Me.txtFOAD.Text.Trim
                .Fields("DOAD").Value = Me.txtDOAD.Text.Trim
                .Fields("FWAD").Value = Me.txtFWAD.Text.Trim
                .Fields("DateOfArrivalPilotStationAD").Value = Me.txtdateofarrivalPilotStationAD.Text.Trim
                .Fields("TimeOfArrivalPilotStationAD").Value = Me.txtTimeOfArrivalPilotStationAD.Text.Trim
                .Fields("DateOfArrivalPilotOnboardAD").Value = Me.txtDateOfArrivalPilotOnboardAD.Text.Trim
                .Fields("TimeOfArrivalPilotOnboardAD").Value = Me.txtTimeOfArrivalPilotOnboardAD.Text.Trim
                .Fields("DateOfBerthAD").Value = Me.txtDateOfBerthAD.Text.Trim
                .Fields("TimeOfBerthAD").Value = Me.txtTimeOfBerthAD.Text.Trim
                .Fields("foreDraftAD").Value = Me.txtForeDraftAD.Text.Trim
                .Fields("AfterDraftAD").Value = Me.txtAfterDraftAD.Text.Trim
                .Fields("ActualDisplacementAD").Value = Me.txtActualDisplacementAD.Text.Trim
                .Fields("LastDateOfArrivalAD").Value = Me.txtLastDateOfArrivalAD.Text.Trim
                .Fields("PreviousPortAD").Value = Me.cboPreviousPortAD.Text.Trim
                .Fields("Dis_LoadPortAD").Value = Me.cboDis_LoadPortAD.Text.Trim
                .Fields("NextPortAD").Value = Me.cboNextPortAD.Text.Trim
                .Fields("DateCommencingOperationAD").Value = Me.txtDateCommencingOperationAD.Text.Trim
                .Fields("TimeCommencingOperationAD").Value = Me.txtTimeCommencingOperationAD.Text.Trim
                .Fields("E20GPAD").Value = Me.txtE20GPAD.Text.Trim
                .Fields("E40GPAD").Value = Me.txtE40GPAD.Text.Trim
                .Fields("E20HCAD").Value = Me.txtE20HCAD.Text.Trim
                .Fields("E40HCAD").Value = Me.txtE40HCAD.Text.Trim
                .Fields("E45HCAD").Value = Me.txtE45HCAD.Text.Trim
                .Fields("E20RFAD").Value = Me.txtE20RFAD.Text.Trim
                .Fields("E40RFAD").Value = Me.txtE40RFAD.Text.Trim
                .Fields("E20RHAD").Value = Me.txtE20RHAD.Text.Trim
                .Fields("E40RHAD").Value = Me.txtE40RHAD.Text.Trim
                .Fields("E45RHAD").Value = Me.txtE45RHAD.Text.Trim
                .Fields("E20FRAD").Value = Me.txtE20FRAD.Text.Trim
                .Fields("E40FRAD").Value = Me.txtE40FRAD.Text.Trim
                .Fields("E20HGAD").Value = Me.txtE20HGAD.Text.Trim
                .Fields("E40HGAD").Value = Me.txtE40HGAD.Text.Trim
                .Fields("E40GHAD").Value = Me.txtE40GHAD.Text.Trim
                .Fields("E20OTAD").Value = Me.txtE20OTAD.Text.Trim
                .Fields("E40OTAD").Value = Me.txtE40OTAD.Text.Trim
                .Fields("E20TKAD").Value = Me.txtE20TKAD.Text.Trim
                .Fields("E40TKAD").Value = Me.txtE40TKAD.Text.Trim
                .Fields("ECNTRAD").Value = Me.TXTECNTRAD.Text.Trim
                .Fields("ETEUAD").Value = Me.TXTETEUAD.Text.Trim
                .Fields("ETONSAD").Value = Me.TXTETONSAD.Text.Trim
                .Fields("F20GPAD").Value = Me.txtF20GPAD.Text.Trim
                .Fields("F40GPAD").Value = Me.txtF40GPAD.Text.Trim
                .Fields("F20HCAD").Value = Me.txtF20HCAD.Text.Trim
                .Fields("F40HCAD").Value = Me.txtF40HCAD.Text.Trim
                .Fields("F45HCAD").Value = Me.txtF45HCAD.Text.Trim
                .Fields("F20RFAD").Value = Me.txtF20RFAD.Text.Trim
                .Fields("F40RFAD").Value = Me.txtF40RFAD.Text.Trim
                .Fields("F20RHAD").Value = Me.txtF20RHAD.Text.Trim
                .Fields("F40RHAD").Value = Me.txtF40RHAD.Text.Trim
                .Fields("F45RHAD").Value = Me.txtF45RHAD.Text.Trim
                .Fields("F20FRAD").Value = Me.txtF20FRAD.Text.Trim
                .Fields("F40FRAD").Value = Me.txtF40FRAD.Text.Trim
                .Fields("F20HGAD").Value = Me.txtF20HGAD.Text.Trim
                .Fields("F40HGAD").Value = Me.txtF40HGAD.Text.Trim
                .Fields("F40GHAD").Value = Me.txtF40GHAD.Text.Trim
                .Fields("F20OTAD").Value = Me.txtF20OTAD.Text.Trim
                .Fields("F40OTAD").Value = Me.txtF40OTAD.Text.Trim
                .Fields("F20TKAD").Value = Me.txtF20TKAD.Text.Trim
                .Fields("F40TKAD").Value = Me.txtF40TKAD.Text.Trim
                .Fields("FCNTRAD").Value = Me.txtFCNTRAD.Text.Trim
                .Fields("FTEUAD").Value = Me.txtFTEUAD.Text.Trim
                .Fields("FTONSAD").Value = Me.txtFTONAD.Text.Trim
                .Fields("DangerousInboundCargoCNTRAD").Value = Me.txtDangerousInboundCargoCNTRAD.Text.Trim
                .Fields("DangerousInboundCargoTONSAD").Value = Me.txtDangerousInboundCargoTONSAD.Text.Trim
                .Fields("DangerousInboundCargoCLASSAD").Value = Me.txtDangerousInboundCargoCLASSAD.Text.Trim
                .Fields("OtherConcerningRequirementOfShipAD").Value = Me.txtOtherConcerningRequirementOfShipAD.Text.Trim
                .Fields("RemaksAD").Value = Me.txtRemaksAD.Text.Trim
                .Fields("CaptionNameDD").Value = Me.txtCaptionNameDD.Text.Trim
                .Fields("NumOfCrewDD").Value = Me.txtNumOfCrewDD.Text.Trim
                .Fields("NumOfPassengersDD").Value = Me.txtNumOfPassengersDD.Text.Trim
                .Fields("PositionOfShipInPortDD").Value = Me.txtPositionOfShipInPortDD.Text.Trim
                .Fields("PurposeToPortDD").Value = Me.txtPurposeToPortDD.Text.Trim
                .Fields("KindOfCargoDD").Value = Me.txtKindOfCargoDD.Text.Trim
                .Fields("FODD").Value = Me.txtFODD.Text.Trim
                .Fields("DODD").Value = Me.txtDODD.Text.Trim
                .Fields("FWDD").Value = Me.txtFWDD.Text.Trim
                .Fields("DateOfArrivalPilotStationDD").Value = Me.txtDateOfArrivalPilotStationDD.Text.Trim
                .Fields("TimeOfArrivalPilotStationDD").Value = Me.txtTimeOfArrivalPilotStationDD.Text.Trim
                .Fields("DateOfArrivalPilotOnboardDD").Value = Me.txtDateOfArrivalPilotOnboardDD.Text.Trim
                .Fields("TimeOfArrivalPilotOnboardDD").Value = Me.txtTimeOfArrivalPilotOnboardDD.Text.Trim
                .Fields("DateOfBerthDD").Value = Me.txtDateOfBerthDD.Text.Trim
                .Fields("TimeOfBerthDD").Value = Me.txtTimeOfBerthDD.Text.Trim
                .Fields("foreDraftDD").Value = Me.txtforeDraftDD.Text.Trim
                .Fields("AfterDraftDD").Value = Me.txtAfterDraftDD.Text.Trim
                .Fields("ActualDisplacementDD").Value = Me.txtActualDisplacementDD.Text.Trim
                .Fields("LastDateOfArrivalDD").Value = Me.txtLastDateOfArrivalDD.Text.Trim
                .Fields("PreviousPortDD").Value = Me.cboPreviousPortDD.Text.Trim
                .Fields("Dis_LoadPortDD").Value = Me.cboDis_LoadPortDD.Text.Trim
                .Fields("NextPortDD").Value = Me.cboNextPortDD.Text.Trim
                .Fields("DateCommencingOperationDD").Value = Me.txtDateCommencingOperationDD.Text.Trim
                .Fields("TimeCommencingOperationDD").Value = Me.txtTimeCommencingOperationDD.Text.Trim
                .Fields("E20GPDD").Value = Me.txtE20GPDD.Text.Trim
                .Fields("E40GPDD").Value = Me.txtE40GPDD.Text.Trim
                .Fields("E20HCDD").Value = Me.txtE20HCDD.Text.Trim
                .Fields("E40HCDD").Value = Me.txtE40HCDD.Text.Trim
                .Fields("E45HCDD").Value = Me.txtE45HCDD.Text.Trim
                .Fields("E20RFDD").Value = Me.txtE20RFDD.Text.Trim
                .Fields("E40RFDD").Value = Me.txtE40RFDD.Text.Trim
                .Fields("E20RHDD").Value = Me.txtE20RHDD.Text.Trim
                .Fields("E40RHDD").Value = Me.txtE40RHDD.Text.Trim
                .Fields("E45RHDD").Value = Me.txtE45RHDD.Text.Trim
                .Fields("E20FRDD").Value = Me.txtE20FRDD.Text.Trim
                .Fields("E40FRDD").Value = Me.txtE40FRDD.Text.Trim
                .Fields("E20HGDD").Value = Me.txtE20HGDD.Text.Trim
                .Fields("E40HGDD").Value = Me.txtE40HGDD.Text.Trim
                .Fields("E40GHDD").Value = Me.txtE40GHDD.Text.Trim
                .Fields("E20OTDD").Value = Me.txtE20OTDD.Text.Trim
                .Fields("E40OTDD").Value = Me.txtE40OTDD.Text.Trim
                .Fields("E20TKDD").Value = Me.txtE20TKDD.Text.Trim
                .Fields("E40TKDD").Value = Me.txtE40TKDD.Text.Trim
                .Fields("ECNTRDD").Value = Me.txtECNTRDD.Text.Trim
                .Fields("ETEUDD").Value = Me.txtETEUDD.Text.Trim
                .Fields("ETONSDD").Value = Me.txtETONDD.Text.Trim
                .Fields("F20GPDD").Value = Me.txtF20GPDD.Text.Trim
                .Fields("F40GPDD").Value = Me.txtF40GPDD.Text.Trim
                .Fields("F20HCDD").Value = Me.txtF20HCDD.Text.Trim
                .Fields("F40HCDD").Value = Me.txtF40HCDD.Text.Trim
                .Fields("F45HCDD").Value = Me.txtF45HCDD.Text.Trim
                .Fields("F20RFDD").Value = Me.txtF20RFDD.Text.Trim
                .Fields("F40RFDD").Value = Me.txtF40RFDD.Text.Trim
                .Fields("F20RHDD").Value = Me.txtF20RHDD.Text.Trim
                .Fields("F40RHDD").Value = Me.txtF40RHDD.Text.Trim
                .Fields("F45RHDD").Value = Me.txtF45RHDD.Text.Trim
                .Fields("F20FRDD").Value = Me.txtF20FRDD.Text.Trim
                .Fields("F40FRDD").Value = Me.txtF40FRDD.Text.Trim
                .Fields("F20HGDD").Value = Me.txtF20HGDD.Text.Trim
                .Fields("F40HGDD").Value = Me.txtF40HGDD.Text.Trim
                .Fields("F40GHDD").Value = Me.txtF40GHDD.Text.Trim
                .Fields("F20OTDD").Value = Me.txtF20OTDD.Text.Trim
                .Fields("F40OTDD").Value = Me.txtF40OTDD.Text.Trim
                .Fields("F20TKDD").Value = Me.txtF20TKDD.Text.Trim
                .Fields("F40TKDD").Value = Me.txtF40TKDD.Text.Trim
                .Fields("FCNTRDD").Value = Me.txtFCNTRDD.Text.Trim
                .Fields("FTEUDD").Value = Me.txtFTEUDD.Text.Trim
                .Fields("FTONSDD").Value = Me.txtFTONDD.Text.Trim
                .Fields("DangerousInboundCargoCNTRDD").Value = Me.txtDangerousInboundCargoCNTRDD.Text.Trim
                .Fields("DangerousInboundCargoTONSDD").Value = Me.txtDangerousInboundCargoTONSDD.Text.Trim
                .Fields("DangerousInboundCargoCLASSDD").Value = Me.txtDangerousInboundCargoCLASSDD.Text.Trim
                .Fields("OtherConcerningRequirementOfShipDD").Value = Me.txtOtherConcerningRequirementOfShipDD.Text.Trim
                .Fields("RemarksDD").Value = Me.txtRemarksDD.Text.Trim
                .Fields("E20GPAD1").Value = Me.txtE20GPAD1.Text.Trim
                .Fields("E40GPAD1").Value = Me.txtE40GPAD1.Text.Trim
                .Fields("E20HCAD1").Value = Me.txtE20HCAD1.Text.Trim
                .Fields("E40HCAD1").Value = Me.txtE40HCAD1.Text.Trim
                .Fields("E45HCAD1").Value = Me.txtE45HCAD1.Text.Trim
                .Fields("E20RFAD1").Value = Me.txtE20RFAD1.Text.Trim
                .Fields("E40RFAD1").Value = Me.txtE40RFAD1.Text.Trim
                .Fields("E20RHAD1").Value = Me.txtE20RHAD1.Text.Trim
                .Fields("E40RHAD1").Value = Me.txtE40RHAD1.Text.Trim
                .Fields("E45RHAD1").Value = Me.txtE45RHAD1.Text.Trim
                .Fields("E20FRAD1").Value = Me.txtE20FRAD1.Text.Trim
                .Fields("E40FRAD1").Value = Me.txtE40FRAD1.Text.Trim
                .Fields("E20HGAD1").Value = Me.txtE20HGAD1.Text.Trim
                .Fields("E40HGAD1").Value = Me.txtE40HGAD1.Text.Trim
                .Fields("E40GHAD1").Value = Me.txtE40GHAD1.Text.Trim
                .Fields("E20OTAD1").Value = Me.txtE20OTAD1.Text.Trim
                .Fields("E40OTAD1").Value = Me.txtE40OTAD1.Text.Trim
                .Fields("E20TKAD1").Value = Me.txtE20TKAD1.Text.Trim
                .Fields("E40TKAD1").Value = Me.txtE40TKAD1.Text.Trim
                .Fields("ECNTRAD1").Value = Me.txtECNTRAD1.Text.Trim
                .Fields("ETEUAD1").Value = Me.txtETEUAD1.Text.Trim
                .Fields("ETONSAD1").Value = Me.txtETONAD1.Text.Trim
                .Fields("F20GPAD1").Value = Me.txtF20GPAD1.Text.Trim
                .Fields("F40GPAD1").Value = Me.txtF40GPAD1.Text.Trim
                .Fields("F20HCAD1").Value = Me.txtF20HCAD1.Text.Trim
                .Fields("F40HCAD1").Value = Me.txtF40HCAD1.Text.Trim
                .Fields("F45HCAD1").Value = Me.txtF45HCAD1.Text.Trim
                .Fields("F20RFAD1").Value = Me.txtF20RFAD1.Text.Trim
                .Fields("F40RFAD1").Value = Me.txtF40RFAD1.Text.Trim
                .Fields("F20RHAD1").Value = Me.txtF20RHAD1.Text.Trim
                .Fields("F40RHAD1").Value = Me.txtF40RHAD1.Text.Trim
                .Fields("F45RHAD1").Value = Me.txtF45RHAD1.Text.Trim
                .Fields("F20FRAD1").Value = Me.txtF20FRAD1.Text.Trim
                .Fields("F40FRAD1").Value = Me.txtF40FRAD1.Text.Trim
                .Fields("F20HGAD1").Value = Me.txtF20HGAD1.Text.Trim
                .Fields("F40HGAD1").Value = Me.txtF40HGAD1.Text.Trim
                .Fields("F40GHAD1").Value = Me.txtF40GHAD1.Text.Trim
                .Fields("F20OTAD1").Value = Me.txtF20OTAD1.Text.Trim
                .Fields("F40OTAD1").Value = Me.txtF40OTAD1.Text.Trim
                .Fields("F20TKAD1").Value = Me.txtF20TKAD1.Text.Trim
                .Fields("F40TKAD1").Value = Me.txtF40TKAD1.Text.Trim
                .Fields("FCNTRAD1").Value = Me.txtFCNTRAD1.Text.Trim
                .Fields("FTEUAD1").Value = Me.txtFTEUAD1.Text.Trim
                .Fields("FTONSAD1").Value = Me.txtFTONAD1.Text.Trim
                .Fields("DangerousInboundCargoCNTRAD1").Value = Me.txtDangerousInboundCargoCNTRAD1.Text.Trim
                .Fields("DangerousInboundCargoTONSAD1").Value = Me.txtDangerousInboundCargoTONSDD1.Text.Trim
                .Fields("DangerousInboundCargoCLASSAD1").Value = Me.txtDangerousInboundCargoCLASSAD1.Text.Trim
                .Fields("OtherConcerningRequirementOfShipAD1").Value = Me.txtOtherConcerningRequirementOfShipAD1.Text.Trim
                .Fields("RemaksAD1").Value = Me.txtRemaksAD1.Text.Trim
                '.Fields("CaptionNameDD1").Value = Me.txtCaptionNameDD1.text.Trim
                '.Fields("NumOfCrewDD1").Value = Me.txtNumOfCrewDD1.text.Trim
                '.Fields("NumOfPassengersDD1").Value = Me.txtNumOfPassengersDD1.text.Trim
                '.Fields("PositionOfShipInPortDD1").Value = Me.txtPositionOfShipInPortDD1.text.Trim
                '.Fields("PurposeToPortDD1").Value = Me.txtPurposeToPortDD1.text.Trim
                '.Fields("KindOfCargoDD1").Value = Me.txtKindOfCargoDD1.text.Trim
                '.Fields("FODD1").Value = Me.txtFODD1.text.Trim
                '.Fields("DODD1").Value = Me.txtDODD1.text.Trim
                '.Fields("FWDD1").Value = Me.txtFWDD1.text.Trim
                '.Fields("DateOfArrivalPilotStationDD1").Value = Me.txtDateOfArrivalPilotStationDD1.text.Trim
                '.Fields("TimeOfArrivalPilotStationDD1").Value = Me.txtTimeOfArrivalPilotStationDD1.text.Trim
                '.Fields("DateOfArrivalPilotOnboardDD1").Value = Me.txtDateOfArrivalPilotOnboardDD1.text.Trim
                '.Fields("TimeOfArrivalPilotOnboardDD1").Value = Me.txtTimeOfArrivalPilotOnboardDD1.text.Trim
                '.Fields("DateOfBerthDD1").Value = Me.txtDateOfBerthDD1.text.Trim
                '.Fields("TimeOfBerthDD1").Value = Me.txtTimeOfBerthDD1.text.Trim
                '.Fields("foreDraftDD1").Value = Me.txtforeDraftDD1.text.Trim
                '.Fields("AfterDraftDD1").Value = Me.txtAfterDraftDD1.text.Trim
                '.Fields("ActualDisplacementDD1").Value = Me.txtActualDisplacementDD1.text.Trim
                '.Fields("LastDateOfArrivalDD1").Value = Me.txtLastDateOfArrivalDD1.text.Trim
                '.Fields("PreviousPortDD1").Value = Me.txtPreviousPortDD1.text.Trim
                '.Fields("Dis_LoadPortDD1").Value = Me.txtDis_LoadPortDD1.text.Trim
                '.Fields("NextPortDD1").Value = Me.txtNextPortDD1.text.Trim
                '.Fields("DateCommencingOperationDD1").Value = Me.txtDateCommencingOperationDD1.text.Trim
                '.Fields("TimeCommencingOperationDD1").Value = Me.txtTimeCommencingOperationDD1.text.Trim
                .Fields("E20GPDD1").Value = Me.txtE20GPDD1.Text.Trim
                .Fields("E40GPDD1").Value = Me.txtE40GPDD1.Text.Trim
                .Fields("E20HCDD1").Value = Me.txtE20HCDD1.Text.Trim
                .Fields("E40HCDD1").Value = Me.txtE40HCDD1.Text.Trim
                .Fields("E45HCDD1").Value = Me.txtE45HCDD1.Text.Trim
                .Fields("E20RFDD1").Value = Me.txtE20RFDD1.Text.Trim
                .Fields("E40RFDD1").Value = Me.txtE40RFDD1.Text.Trim
                .Fields("E20RHDD1").Value = Me.txtE20RHDD1.Text.Trim
                .Fields("E40RHDD1").Value = Me.txtE40RHDD1.Text.Trim
                .Fields("E45RHDD1").Value = Me.txtE45RHDD1.Text.Trim
                .Fields("E20FRDD1").Value = Me.txtE20FRDD1.Text.Trim
                .Fields("E40FRDD1").Value = Me.txtE40FRDD1.Text.Trim
                .Fields("E20HGDD1").Value = Me.txtE20HGDD1.Text.Trim
                .Fields("E40HGDD1").Value = Me.txtE40HGDD1.Text.Trim
                .Fields("E40GHDD1").Value = Me.txtE40GHDD1.Text.Trim
                .Fields("E20OTDD1").Value = Me.txtE20OTDD1.Text.Trim
                .Fields("E40OTDD1").Value = Me.txtE40OTDD1.Text.Trim
                .Fields("E20TKDD1").Value = Me.txtE20TKDD1.Text.Trim
                .Fields("E40TKDD1").Value = Me.txtE40TKDD1.Text.Trim
                .Fields("ECNTRDD1").Value = Me.txtECNTRDD1.Text.Trim
                .Fields("ETEUDD1").Value = Me.txtETEUDD1.Text.Trim
                .Fields("ETONSDD1").Value = Me.txtETONDD1.Text.Trim
                .Fields("F20GPDD1").Value = Me.txtF20GPDD1.Text.Trim
                .Fields("F40GPDD1").Value = Me.txtF40GPDD1.Text.Trim
                .Fields("F20HCDD1").Value = Me.txtF20HCDD1.Text.Trim
                .Fields("F40HCDD1").Value = Me.txtF40HCDD1.Text.Trim
                .Fields("F45HCDD1").Value = Me.txtF45HCDD1.Text.Trim
                .Fields("F20RFDD1").Value = Me.txtF20RFDD1.Text.Trim
                .Fields("F40RFDD1").Value = Me.txtF40RFDD1.Text.Trim
                .Fields("F20RHDD1").Value = Me.txtF20RHDD1.Text.Trim
                .Fields("F40RHDD1").Value = Me.txtF40RHDD1.Text.Trim
                .Fields("F45RHDD1").Value = Me.txtF45RHDD1.Text.Trim
                .Fields("F20FRDD1").Value = Me.txtF20FRDD1.Text.Trim
                .Fields("F40FRDD1").Value = Me.txtF40FRDD1.Text.Trim
                .Fields("F20HGDD1").Value = Me.txtF20HGDD1.Text.Trim
                .Fields("F40HGDD1").Value = Me.txtF40HGDD1.Text.Trim
                .Fields("F40GHDD1").Value = Me.txtF40GHDD1.Text.Trim
                .Fields("F20OTDD1").Value = Me.txtF20OTDD1.Text.Trim
                .Fields("F40OTDD1").Value = Me.txtF40OTDD1.Text.Trim
                .Fields("F20TKDD1").Value = Me.txtF20TKDD1.Text.Trim
                .Fields("F40TKDD1").Value = Me.txtF40TKDD1.Text.Trim
                .Fields("FCNTRDD1").Value = Me.txtFCNTRDD1.Text.Trim
                .Fields("FTEUDD1").Value = Me.txtFTEUDD1.Text.Trim
                .Fields("FTONSDD1").Value = Me.txtFTONDD1.Text.Trim
                .Fields("DangerousInboundCargoCNTRDD1").Value = Me.txtDangerousInboundCargoCNTRDD1.Text.Trim
                .Fields("DangerousInboundCargoTONSDD1").Value = Me.txtDangerousInboundCargoTONSDD1.Text.Trim
                .Fields("DangerousInboundCargoCLASSDD1").Value = Me.txtDangerousInboundCargoCLASSDD1.Text.Trim
                .Fields("OtherConcerningRequirementOfShipDD1").Value = Me.txtOtherConcerningRequirementOfShipDD1.Text.Trim
                .Fields("ApplicationForArrivalDate").Value = Me.txtApplicationForArrivalDate.Text.Trim
                .Fields("TheApprovalPort").Value = Me.txtTheApprovalPort.Text.Trim
                .Fields("Editable").Value = 1
                .Fields("Continued").Value = 1
                '.Fields("Approve").Value = Me.txtApprove.text.Trim
                '.Fields("UserID").Value = Me.txtUserID.text.Trim
                '.Fields("Updattime").Value = Me.txtUpdattime.text.Trim

                .Fields("ApproveETA").Value = IIf(Me.chkApproveETA.Checked, 1, 0)

                .Update()

            End With
            rs.Close()
            Me.dgdBoardingAgent.Enabled = True

            QueryBoardingAgent()

            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            reText(mStatus)
            'blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
        MsgBox(msgErr(Me, "Xin kiểm tra lại các dữ liệu!"))
    End Sub


    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean

        ' Xác định vị trí row trong grid

        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        'strQuery = "Select * from ContainerOutboundNotify WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "' And UserId='DBO'"
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEOF = rs.EOF
        'rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, "Sorry, The ContainerOutboundNotify can not be removed.")
        '    Exit Sub
        'End If
        'che tam vi chua co quan he voi Dulieu khac
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The ContainerOutboundNotify can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdBoardingAgent.Item("Approve", index)) Then
            If Me.dgdBoardingAgent.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdBoardingAgent.Item("Editable", index)) Then
            If Not Me.dgdBoardingAgent.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmBoardingAgent", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Boarding Agent: " & Me.dgdBoardingAgent.Item("Vessel", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from BoardingAgent where" + " BoardingAgentID= '" & Me.dgdBoardingAgent.Item("BoardingAgentID", index).Value.ToString & "'"
                rs.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                Me.dgdBoardingAgent.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdBoardingAgent.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                'blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdBoardingAgent.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim location As Integer
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdBoardingAgent.SelectedRows(i).Index)
                location = Me.dgdBoardingAgent.SelectedRows(i).Index
            Next i
        End If
        Me.QueryBoardingAgent(mFilter)
    End Sub
    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub ApproveBoardingAgent()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If Me.dgdBoardingAgent.Rows.Count > 0 Then
            index = Me.dgdBoardingAgent.CurrentRow.Index
        End If
        Dim rsContainerOutboundNotifyList As New ADODB.Recordset
        Dim strQueryContainerOutboundNotifyList As String
        If Not Me.dgdBoardingAgent.Item("Editable", index).Value Or Not UserRight("frmBoardingAgent", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            'QueryBoardingAgent(mFilter)
        Else
            strQueryContainerOutboundNotifyList = "Select * from BoardingAgent where" + " BoardingAgentId= '" & dgdBoardingAgent.Item("BoardingAgentId", index).Value.ToString & "'"
            rsContainerOutboundNotifyList.Open(strQueryContainerOutboundNotifyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsContainerOutboundNotifyList.Fields("Approve").Value
            rsContainerOutboundNotifyList.Update("Approve", Approve)
            rsContainerOutboundNotifyList.Close()
        End If
        QueryBoardingAgent(mFilter)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdBoardingAgent_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBoardingAgent.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdBoardingAgent.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdBoardingAgent.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        'MsgBox(Me.dgdETA.CurrentCellAddress.X)
        If Me.dgdBoardingAgent.Columns(ColIndex).Name = "Approve" And Me.dgdBoardingAgent.CurrentCellAddress().Y = RowIndex Then
            Call ApproveBoardingAgent()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub





    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdBoardingAgent.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.FindBoardingAgent.Text)
        If Me.FindBoardingAgent.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.FindBoardingAgent.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdBoardingAgent)

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryBoardingAgent("  " & mFilter)
                'QuerySailing("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdBoardingAgent.Rows.Count > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdBoardingAgent, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Me.txtshipCode.Text = Me.cboVessel.SelectedValue.ToString.Trim
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        SetNullDateText()
        'If Me.dgdBoardingAgent.SelectedRows.Count = 0 Then
        '    Return
        'End If
        If Me.dgdBoardingAgent.Rows.Count > 0 Then
            index = Me.dgdBoardingAgent.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            Approve = Me.dgdBoardingAgent.Item("Approve", index).Value
            EditTable = Me.dgdBoardingAgent.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmBoardingAgent", "Edit") Then
                Me.dgdBoardingAgent.Height = 306
                Me.dgdBoardingAgent.Enabled = False
                'Me.txtBookingNo.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mBoardingAgentID = Me.dgdBoardingAgent.Item("BoardingAgentId", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Function QueryBoardingInfo() As DataTable
        Try
            If Me.dgdBoardingAgent.RowCount = 0 Then
                Return Nothing
            End If
            Dim Index As Integer = Me.dgdBoardingAgent.CurrentRow.Index
            Dim SQL As String = "Select * from BoardingAgent Where BoardingagentID='" & Me.dgdBoardingAgent.Item("BoardingagentID", Index).Value.ToString & "' And Continued=1"
            Dim TempDt As New DataTable
            TempDt = ReadTable(SQL)
            Return TempDt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return Nothing
        End Try
    End Function
    Private Sub ExportExcelFromToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelFromToolStripMenuItem.Click
        Dim dt As DataTable = QueryBoardingInfo()
        If IsNothing(dt) Or dt.Rows.Count = 0 Then
            Return
        End If
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim Path As String
            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = StartupPath & "\TDR & LOADING SUMMARY.xls"

            workbook = workbooks.Open(Path)

            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            '''''''''''''''''''''''''''''''''
            'ARRIVAL INFO
            ws.Range("D4").Value2 = dt.Rows(0).Item("Vessel").ToString
            ws.Range("J4").Value2 = dt.Rows(0).Item("VoyageNoOnArrival").ToString
            ws.Range("D7").Value2 = dt.Rows(0).Item("TimeOfArrivalPilotStationAD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotStationAD").ToString
            ws.Range("D8").Value2 = dt.Rows(0).Item("TimeOfArrivalPilotOnboardAD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotOnboardAD").ToString
            ws.Range("D9").Value2 = dt.Rows(0).Item("TimeOfBerthAD").ToString & " " & dt.Rows(0).Item("DateOfBerthAD").ToString
            ws.Range("D10").Value2 = dt.Rows(0).Item("TimeCommencingOperationAD").ToString & " " & dt.Rows(0).Item("DateCommencingOperationAD").ToString
            ws.Range("D11").Value2 = dt.Rows(0).Item("FOAD").ToString
            ws.Range("D12").Value2 = dt.Rows(0).Item("DOAD").ToString
            ws.Range("D13").Value2 = "" 'CHƯA CÓ DỮ LIỆU
            ws.Range("D14").Value2 = dt.Rows(0).Item("foreDraftAD").ToString
            ws.Range("D15").Value2 = dt.Rows(0).Item("AfterDraftAD").ToString
            ws.Range("D16").Value2 = dt.Rows(0).Item("FCNTRAD").ToString
            ws.Range("D17").Value2 = dt.Rows(0).Item("ECNTRAD").ToString
            ws.Range("D18").Value2 = dt.Rows(0).Item("FTONSAD").ToString
            ws.Range("D19").Value2 = "" 'CHƯA CÓ DỮ LIỆU
            ws.Range("D20").Value2 = IIf(dt.Rows(0).Item("RemaksAD").ToString.Trim = "", "NIL", dt.Rows(0).Item("RemaksAD").ToString.Trim)
            ws.Range("D21").Value2 = "" 'KHÔNG RÕ DỮ LIỆU
            ws.Range("D22").Value2 = "" 'KHÔNG RÕ DỮ LIỆU
            ws.Range("D23").Value2 = "" 'KHÔNG RÕ DỮ LIỆU  dt.Rows(0).Item("ECNTRAD").ToString
            ws.Range("D24").Value2 = "" 'KHÔNG RÕ DỮ LIỆU  dt.Rows(0).Item("FTONSAD").ToString
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'DEPARTUE INFO
            ws.Range("D8").Value2 = dt.Rows(0).Item("TimeOfArrivalPilotOnboardDD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotOnboardDD").ToString
            ws.Range("D9").Value2 = dt.Rows(0).Item("TimeOfBerthDD").ToString & " " & dt.Rows(0).Item("DateOfBerthDD").ToString
            ws.Range("D10").Value2 = dt.Rows(0).Item("TimeCommencingOperationDD").ToString & " " & dt.Rows(0).Item("DateCommencingOperationDD").ToString
            ws.Range("D11").Value2 = dt.Rows(0).Item("FODD").ToString
            ws.Range("D12").Value2 = dt.Rows(0).Item("DODD").ToString
            ws.Range("D13").Value2 = "" 'CHƯA CÓ DỮ LIỆU
            ws.Range("D14").Value2 = dt.Rows(0).Item("foreDraftDD").ToString
            ws.Range("D15").Value2 = dt.Rows(0).Item("AfterDraftDD").ToString
            ws.Range("D16").Value2 = dt.Rows(0).Item("FCNTRDD").ToString
            ws.Range("D17").Value2 = dt.Rows(0).Item("ECNTRDD").ToString
            ws.Range("D18").Value2 = dt.Rows(0).Item("FTONSDD").ToString
            ws.Range("D19").Value2 = "" 'CHƯA CÓ DỮ LIỆU
            ws.Range("D20").Value2 = IIf(dt.Rows(0).Item("RemarksDD").ToString.Trim = "", "NIL", dt.Rows(0).Item("RemarksDD").ToString.Trim)
            ws.Range("D21").Value2 = dt.Rows(0).Item("NextPortDD").ToString
            ws.Range("D22").Value2 = "" 'KHÔNG RÕ DỮ LIỆU
            ws.Range("D23").Value2 = "" 'KHÔNG RÕ DỮ LIỆU  dt.Rows(0).Item("ECNTRDD").ToString
            ws.Range("D24").Value2 = "" 'KHÔNG RÕ DỮ LIỆU  dt.Rows(0).Item("FTONSDD").ToString

            ''''''''''''''''''''''''
            'LOADING SUMMARY AS OPERATOR

            ws.Range("D28").Value2 = CDbl(dt.Rows(0).Item("F20GPAD").ToString) + CDbl(dt.Rows(0).Item("F20GPAD1").ToString)
            ws.Range("E28").Value2 = CDbl(dt.Rows(0).Item("F40GPAD").ToString) + CDbl(dt.Rows(0).Item("F40GPAD1").ToString)
            ws.Range("F28").Value2 = CDbl(dt.Rows(0).Item("F40HCAD").ToString) + CDbl(dt.Rows(0).Item("F40HCAD1").ToString)
            ws.Range("G28").Value2 = CDbl(dt.Rows(0).Item("F20RFAD").ToString) + CDbl(dt.Rows(0).Item("F20RFAD1").ToString)
            ws.Range("H28").Value2 = CDbl(dt.Rows(0).Item("F40RHAD").ToString) + CDbl(dt.Rows(0).Item("F40RHAD1").ToString)
            ws.Range("I28").Value2 = CDbl(dt.Rows(0).Item("F45HCAD").ToString) + CDbl(dt.Rows(0).Item("F45RHAD").ToString) + CDbl(dt.Rows(0).Item("F45HCAD1").ToString) + CDbl(dt.Rows(0).Item("F45RHAD1").ToString)

            '''''''''''''''''''''''''''''''''
            'MESSAGE OF CSC CONTAIENR
            ws.Range("B36").Value2 = dt.Rows(0).Item("Dis_LoadPortAD").ToString
            ws.Range("C36").Value2 = CDbl(dt.Rows(0).Item("F20GPAD").ToString) + CDbl(dt.Rows(0).Item("F20HCAD").ToString) + CDbl(dt.Rows(0).Item("F20RFAD").ToString) + CDbl(dt.Rows(0).Item("F20RHAD").ToString) + CDbl(dt.Rows(0).Item("F20FRAD").ToString) + CDbl(dt.Rows(0).Item("F20HGAD").ToString) + CDbl(dt.Rows(0).Item("F20OTAD").ToString) + CDbl(dt.Rows(0).Item("F20TKAD").ToString)
            ws.Range("D36").Value2 = CDbl(dt.Rows(0).Item("F40GPAD").ToString) + CDbl(dt.Rows(0).Item("F40HCAD").ToString) + CDbl(dt.Rows(0).Item("F40RFAD").ToString) + CDbl(dt.Rows(0).Item("F40RHAD").ToString) + CDbl(dt.Rows(0).Item("F40FRAD").ToString) + CDbl(dt.Rows(0).Item("F40HGAD").ToString) + CDbl(dt.Rows(0).Item("F40GHAD").ToString) + CDbl(dt.Rows(0).Item("F40OTAD").ToString) + CDbl(dt.Rows(0).Item("F40TKAD").ToString)

            ws.Range("F36").Value2 = dt.Rows(0).Item("PreviousPortAD").ToString
            ws.Range("G36").Value2 = dt.Rows(0).Item("Dis_LoadPortAD").ToString
            ws.Range("C36").Value2 = dt.Rows(0).Item("F20GPAD1").ToString
            ws.Range("D36").Value2 = dt.Rows(0).Item("F40GPAD1").ToString
            ''''''''''''''''''''''''''''''''''''''''
            ''CHUYỂN QUA SHEET 2
            ws = sheets.Item(2)
            ''''''''''''''''''''''''''''''''''
            'DISCHARGE DETAIL
            ws.Range("A8").Value2 = dt.Rows(0).Item("Dis_LoadPortAD").ToString
            ws.Range("C8").Value2 = CDbl(dt.Rows(0).Item("F20GPAD").ToString)
            ws.Range("D8").Value2 = CDbl(dt.Rows(0).Item("F40GPAD").ToString)
            ws.Range("E8").Value2 = CDbl(dt.Rows(0).Item("F40HCAD").ToString)
            ws.Range("F8").Value2 = CDbl(dt.Rows(0).Item("F20RFAD").ToString)
            ws.Range("G8").Value2 = CDbl(dt.Rows(0).Item("F40RHAD").ToString)
            ws.Range("H8").Value2 = CDbl(dt.Rows(0).Item("F45HCAD").ToString) + CDbl(dt.Rows(0).Item("F45RHAD").ToString)
            ws.Range("J8").Value2 = CDbl(dt.Rows(0).Item("F20GPAD").ToString) + CDbl(dt.Rows(0).Item("F20RFAD").ToString)
            ws.Range("K8").Value2 = CDbl(dt.Rows(0).Item("F40GPAD").ToString) + CDbl(dt.Rows(0).Item("F40RHAD").ToString) + CDbl(dt.Rows(0).Item("F40HCAD").ToString)
            ws.Range("L8").Value2 = CDbl(dt.Rows(0).Item("F45HCAD").ToString) + CDbl(dt.Rows(0).Item("F45RHAD").ToString)
            ''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''LOADING DETAIL

            ws.Range("A16").Value2 = dt.Rows(0).Item("Dis_LoadPortDD").ToString
            ws.Range("C16").Value2 = CDbl(dt.Rows(0).Item("F20GPDD").ToString)
            ws.Range("D16").Value2 = CDbl(dt.Rows(0).Item("F40GPDD").ToString)
            ws.Range("E16").Value2 = CDbl(dt.Rows(0).Item("F40HCDD").ToString)
            ws.Range("F16").Value2 = CDbl(dt.Rows(0).Item("F20RFDD").ToString)
            ws.Range("G16").Value2 = CDbl(dt.Rows(0).Item("F40RHDD").ToString)
            ws.Range("H16").Value2 = CDbl(dt.Rows(0).Item("F45HCDD").ToString) + CDbl(dt.Rows(0).Item("F45RHDD").ToString)
            ws.Range("J16").Value2 = CDbl(dt.Rows(0).Item("F20GPDD").ToString) + CDbl(dt.Rows(0).Item("F20RFDD").ToString)
            ws.Range("K16").Value2 = CDbl(dt.Rows(0).Item("F40GPDD").ToString) + CDbl(dt.Rows(0).Item("F40RHDD").ToString) + CDbl(dt.Rows(0).Item("F40HCDD").ToString)
            ws.Range("L16").Value2 = CDbl(dt.Rows(0).Item("F45HCDD").ToString) + CDbl(dt.Rows(0).Item("F45RHDD").ToString)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'DANGER CARGO SUMMARY

            'CHƯA RÕ SỮ LIỆU

            '''''''''''''''''''''''''
            'SPENCIAL CARGO 

            ' CHƯA RÕ DỮ LIỆU


            'RETOWS CONTAINER
            ';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


            'CHUYỂN QUA SHEET 3
            ws = sheets.Item(3)
            ws.Range("A4").Value2 = dt.Rows(0).Item("Vessel").ToString & " - " & dt.Rows(0).Item("VoyageNoOnArrival").ToString
            ws.Range("B4").Value2 = dt.Rows(0).Item("Dis_LoadPortAD").ToString
            ws.Range("C4").Value2 = "DATE " ' CHƯA RÕ DỮ LIỆU dt.Rows(0).Item("TimeOfArrivalPilotStationAD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotStationAD").ToString
            ws.Range("D4").Value2 = "" 'dt.Rows(0).Item("TimeOfArrivalPilotOnboardAD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotOnboardAD").ToString
            ws.Range("E4").Value2 = "POD" 'dt.Rows(0).Item("TimeOfBerthAD").ToString & " " & dt.Rows(0).Item("DateOfBerthAD").ToString
            ws.Range("F4").Value2 = "DEST" 'dt.Rows(0).Item("TimeCommencingOperationAD").ToString & " " & dt.Rows(0).Item("DateCommencingOperationAD").ToString
            ws.Range("G4").Value2 = dt.Rows(0).Item("FTEUAD").ToString
            ws.Range("H4").Value2 = dt.Rows(0).Item("FTONSAD").ToString
            ws.Range("I4").Value2 = CDbl(dt.Rows(0).Item("F20GPAD").ToString)
            ws.Range("J4").Value2 = CDbl(dt.Rows(0).Item("F40GPAD").ToString)
            ws.Range("K4").Value2 = CDbl(dt.Rows(0).Item("F40HGAD").ToString)
            ws.Range("L4").Value2 = CDbl(dt.Rows(0).Item("F20RFAD").ToString)
            ws.Range("M4").Value2 = CDbl(dt.Rows(0).Item("F40RHAD").ToString)
            ws.Range("N4").Value2 = CDbl(dt.Rows(0).Item("E20GPAD").ToString) + CDbl(dt.Rows(0).Item("E20HCAD").ToString) + CDbl(dt.Rows(0).Item("E20RFAD").ToString) + CDbl(dt.Rows(0).Item("E20RHAD").ToString) + CDbl(dt.Rows(0).Item("E20FRAD").ToString) + CDbl(dt.Rows(0).Item("E20HGAD").ToString) + CDbl(dt.Rows(0).Item("E20OTAD").ToString) + CDbl(dt.Rows(0).Item("E20TKAD").ToString)
            ws.Range("O4").Value2 = CDbl(dt.Rows(0).Item("E40GPAD").ToString) + CDbl(dt.Rows(0).Item("E40HCAD").ToString) + CDbl(dt.Rows(0).Item("E40RFAD").ToString) + CDbl(dt.Rows(0).Item("E40RHAD").ToString) + CDbl(dt.Rows(0).Item("E40FRAD").ToString) + CDbl(dt.Rows(0).Item("E40HGAD").ToString) + CDbl(dt.Rows(0).Item("E40GHAD").ToString) + CDbl(dt.Rows(0).Item("E40OTAD").ToString) + CDbl(dt.Rows(0).Item("E40TKAD").ToString)
          
            'ws.Range("A5").Value2 = dt.Rows(0).Item("Vessel").ToString & " - " & dt.Rows(0).Item("VoyageNoOnArrival").ToString
            ws.Range("B5").Value2 = dt.Rows(0).Item("Dis_LoadPortDD").ToString
            ws.Range("C5").Value2 = "DATE " ' CHƯA RÕ DỮ LIỆU dt.Rows(0).Item("TimeOfArrivalPilotStationDD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotStationDD").ToString
            ws.Range("D5").Value2 = "" 'dt.Rows(0).Item("TimeOfArrivalPilotOnboardDD").ToString & " " & dt.Rows(0).Item("DateOfArrivalPilotOnboardDD").ToString
            ws.Range("E5").Value2 = "POD" 'dt.Rows(0).Item("TimeOfBerthDD").ToString & " " & dt.Rows(0).Item("DateOfBerthDD").ToString
            ws.Range("F5").Value2 = "DEST" 'dt.Rows(0).Item("TimeCommencingOperationDD").ToString & " " & dt.Rows(0).Item("DateCommencingOperationDD").ToString
            ws.Range("G5").Value2 = dt.Rows(0).Item("FTEUDD").ToString
            ws.Range("H5").Value2 = dt.Rows(0).Item("FTONSDD").ToString
            ws.Range("I5").Value2 = CDbl(dt.Rows(0).Item("F20GPDD").ToString)
            ws.Range("J5").Value2 = CDbl(dt.Rows(0).Item("F40GPDD").ToString)
            ws.Range("K5").Value2 = CDbl(dt.Rows(0).Item("F40HGDD").ToString)
            ws.Range("L5").Value2 = CDbl(dt.Rows(0).Item("F20RFDD").ToString)
            ws.Range("M5").Value2 = CDbl(dt.Rows(0).Item("F40RHDD").ToString)
            ws.Range("N5").Value2 = CDbl(dt.Rows(0).Item("E20GPDD").ToString) + CDbl(dt.Rows(0).Item("E20HCDD").ToString) + CDbl(dt.Rows(0).Item("E20RFDD").ToString) + CDbl(dt.Rows(0).Item("E20RHDD").ToString) + CDbl(dt.Rows(0).Item("E20FRDD").ToString) + CDbl(dt.Rows(0).Item("E20HGDD").ToString) + CDbl(dt.Rows(0).Item("E20OTDD").ToString) + CDbl(dt.Rows(0).Item("E20TKDD").ToString)
            ws.Range("O5").Value2 = CDbl(dt.Rows(0).Item("E40GPDD").ToString) + CDbl(dt.Rows(0).Item("E40HCDD").ToString) + CDbl(dt.Rows(0).Item("E40RFDD").ToString) + CDbl(dt.Rows(0).Item("E40RHDD").ToString) + CDbl(dt.Rows(0).Item("E40FRDD").ToString) + CDbl(dt.Rows(0).Item("E40HGDD").ToString) + CDbl(dt.Rows(0).Item("E40GHDD").ToString) + CDbl(dt.Rows(0).Item("E40OTDD").ToString) + CDbl(dt.Rows(0).Item("E40TKDD").ToString)

            workbook.SaveAs("c:\" & dt.Rows(0).Item("Vessel").ToString & " " & Strings.Replace(Now().ToString, ":", " ") & ".xls")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub dtpDateCommencingOperationDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateCommencingOperationDD.ValueChanged
        Me.txtDateCommencingOperationDD.Text = Me.dtpDateCommencingOperationDD.Text
    End Sub

    Private Sub dtpDateOfArrivalAD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfArrivalAD.ValueChanged
        Me.txtDateOfArrivalAD.Text = Me.dtpDateOfArrivalAD.Text
    End Sub

    Private Sub dtpdateofarrivalPilotStationAD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpdateofarrivalPilotStationAD.ValueChanged
        Me.txtdateofarrivalPilotStationAD.Text = Me.dtpdateofarrivalPilotStationAD.Text
    End Sub

    Private Sub dtpDateOfBerthAD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfBerthAD.ValueChanged
        Me.txtDateOfBerthAD.Text = Me.dtpDateOfBerthAD.Text
    End Sub

    Private Sub dtpDateOfArrivalPilotOnboardAD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfArrivalPilotOnboardAD.ValueChanged
        Me.txtDateOfArrivalPilotOnboardAD.Text = Me.dtpDateOfArrivalPilotOnboardAD.Text
    End Sub

    Private Sub dtpDateCommencingOperationAD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateCommencingOperationAD.ValueChanged
        Me.txtDateCommencingOperationAD.Text = Me.dtpDateCommencingOperationAD.Text
    End Sub

    Private Sub dtpDateOfArrivalPilotStationDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfArrivalPilotStationDD.ValueChanged
        Me.txtDateOfArrivalPilotStationDD.Text = Me.dtpDateOfArrivalPilotStationDD.Text
    End Sub

    Private Sub dtpDateOfArrivalPilotOnboardDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfArrivalPilotOnboardDD.ValueChanged
        Me.txtDateOfArrivalPilotOnboardDD.Text = Me.dtpDateOfArrivalPilotOnboardDD.Text
    End Sub

    Private Sub dtpDateOfBerthDD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfBerthDD.ValueChanged
        Me.txtDateOfBerthDD.Text = Me.dtpDateOfBerthDD.Text
    End Sub

    Sub SetNullDateText()
        Try

            Me.txtDateCommencingOperationDD.Text = ""
            Me.txtDateOfArrivalAD.Text = ""
            Me.txtdateofarrivalPilotStationAD.Text = ""
            Me.txtDateOfBerthAD.Text = ""
            Me.txtDateOfArrivalPilotOnboardAD.Text = ""
            Me.txtDateCommencingOperationAD.Text = ""
            Me.txtDateOfArrivalPilotStationDD.Text = ""
            Me.txtDateOfArrivalPilotOnboardDD.Text = ""
            Me.txtDateOfBerthDD.Text = Me.dtpDateOfBerthDD.Text

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub DeclarationOfDepartureToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeclarationOfDepartureToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If Me.dgdBoardingAgent.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdBoardingAgent.CurrentRow.Index
        frmRptDeclarationOfDeparture.VesselID = Me.dgdBoardingAgent.Item("BoardingAgentID", index).Value.ToString
        VB6.ShowForm(frmRptDeclarationOfDeparture, VB6.FormShowConstants.Modeless, Me)


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ForeignVesselApplicaitonForArrivalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForeignVesselApplicaitonForArrivalToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If Me.dgdBoardingAgent.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdBoardingAgent.CurrentRow.Index
        frmRptForeignVesselApplicaitonForArrivalb.VesselID = Me.dgdBoardingAgent.Item("BoardingAgentID", index).Value.ToString
        VB6.ShowForm(frmRptForeignVesselApplicaitonForArrivalb, VB6.FormShowConstants.Modeless, Me)


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PermissionForForeignVesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PermissionForForeignVesselToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If Me.dgdBoardingAgent.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdBoardingAgent.CurrentRow.Index
        rptArrialvPermissionforForeignVessel.BoardingID = Me.dgdBoardingAgent.Item("BoardingAgentID", index).Value.ToString

        VB6.ShowForm(rptArrialvPermissionforForeignVessel, VB6.FormShowConstants.Modeless, Me)


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class