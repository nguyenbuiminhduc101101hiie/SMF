Public Class frmContainerManagerMent

    Dim mStatus, mStatusP, mFilter, mFinalICD As String
    Public blnUpdated, mCopy, Check_CTNChanged As Boolean
    Dim UserRightFrm As String
    Public oTableContainerMNG As New DataTable
    Public dsBillOfLading As New DataSet
    Public mCargoIB_ID, mRepairStatus As String
    Public mContainermanagermentID As String
    '------------------
    'Public oTablePort As DataTable
    '------------------
    Public oTableDetailBillOfLading As DataTable
    Public dsDetailBillOfLading As New DataSet
    '------------------
    Public oTableCopyBillOfLading As DataTable
    Public dsCopyBillOfLading As New DataSet
    '---
    Public oTableContainerRepair As DataTable
    Public dsContainerRepair As New DataSet

    '

    'Const strContainerMNGSelect As String = " SELECT BillOfLadingIB.BLIB_ID as BLIB_ID," & _
    '    "BillOfLadingIB.BLIB_NO as BLIB_NO,BillOfLadingIB.DisChargeDate ," & _
    '    "BillOfLadingIB.POL_CODE,VesselInBound.Vessel As VesselInbound,BillOfLadingIB.PRE_VOYAGE as VoyAgeInbound," & _
    '    "Container.Container_No,Container.CTN_SIZE_TYPE,Container.CTN_ID, " & _
    '    "CargoIB.RECEIVEKIND,BillOfLadingIB.ETA," & _
    '    "BillOfLading.BL_ID,BillOfLading.BL_NO,VesselOutBound.Vessel as VesselOutbound,SailingScheDule.VoyNo as VoyAgeOutbound," & _
    '    "BillOfLading.PORT_OF_DISCHARGE_NAME," & _
    '    "CONTAINERMANAGERMENT.CONTAINERMANAGEMENTID,CONTAINERMANAGERMENT.ImportCY,FactOfDelDate,FactOfReDelDate,CorrectionOfReDELDate,PicApprove,EmptyCY,ConditionOfContainerAT_MT_CY," & _
    '    "DateOfEmptyContainerToShipper,VanningDate,DateOfFullLoadContainerToCY,ExportCY,DateOfOnBoard,SoundContainer," & _
    '    "ToBeInSpected,DamageContainer,FullImport,FullToConsignee,FullExport,EmptyToShipper,EmptyContainerReposit,StorageInvoce," & _
    '    "CargoIB.CargoIB_ID," & _
    '    "CargoIB.Editable as Editable, " & _
    '    "CargoIB.Continued as Continued, " & _
    '    "CargoIB.Approve as Approve, " & _
    '    "CargoIB.UserID as UserUpdate , " & _
    '    "CargoIB.Updatetime as Updatetime "

    'Const strContainerMNGOrder1 As String = _cargiib
    '      " ORDER BY BillOfLading.BL_NO  Desc "
    'Const strContainerMNGOrder2 As String = _
    '    " ORDER BY BillOfLading.UpdateTime Desc "
    'Const strContainerMNGSelect As String = " Select containermanagerment.*,emptyport from ContainerManagerment left join  printemptycontainer on ContainerManagerment.container_no=printemptycontainer.container_no where containermanagerment.continued=1 " 'left join cargoib on ContainerManagerment.cargoib_id=cargoib.cargoib_id  where ContainerManagerment.continued=1 "

    Const strContainerPriceRepair As String = "Select ContainerRepair_ID,ContainerRepair.ContainerManagementID,Price,Ex,Detail,DateRepair,Address,StatusRepair,ContainerRepair.Approve,ContainerRepair.Editable,ContainerRepair.Continued,ContainerRepair.UserUpdate,ContainerRepair.Updatetime "
    Const strContainerMNGSelectC As String = " order by cargoib.stt"
    '    SELECT BillOfLadingIB.BLIB_ID as BLIB_ID,BillOfLadingIB.BLIB_NO as BLIB_NO,BillOfLadingIB.DisChargeDate ,
    'BillOfLadingIB.POL_CODE,VesselInBound.Vessel As VesselInbound,BillOfLadingIB.PRE_VOYAGE as VoyAgeInbound,
    'Container.Container_No,Container.CTN_SIZE_TYPE,Container.CTN_ID, CargoIB.RECEIVEKIND,BillOfLadingIB.ETA,
    'CONTAINERMANAGERMENT.CONTAINERMANAGEMENTID,CONTAINERMANAGERMENT.ImportCY,
    'FactOfDelDate,FactOfReDelDate,CorrectionOfReDELDate,PicApprove,EmptyCY,ConditionOfContainerAT_MT_CY,
    'DateOfEmptyContainerToShipper,VanningDate,DateOfFullLoadContainerToCY,ExportCY,DateOfOnBoard,SoundContainer,
    'ToBeInSpected,DamageContainer,FullImport,FullToConsignee,FullExport,EmptyToShipper,EmptyContainerReposit,StorageInvoce,
    'CargoIB.CargoIB_ID,CargoIB.Editable as Editable, CargoIB.Continued as Continued, CargoIB.Approve as Approve, 
    'CargoIB.UserID as UserUpdate , CargoIB.Updatetime as Updatetime 

    'FROM ((((  CargoIB LEFT JOIN CONTAINERMANAGERMENT On CargoIB.CargoIB_ID=CONTAINERMANAGERMENT.CargoIB_ID ) 
    'LEFT JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID) 
    'LEFT JOIN Container On Container.CTN_ID=CargoIB.CTN_ID )
    'LEFT JOIN Vessel As VesselInbound On BillOfLadingIB.PRE_VESSEL_ID=VesselInbound.VESSEL_ID)

    'Where (CargoIB.Continued = 1 ) ORDER BY BillOfLading.UpdateTime Desc 

    '    Private Function MakeQueryContainerMNG(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
    '        On Error GoTo Err_Renamed

    '        MakeQueryContainerMNG = strContainerMNGSelect
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " FROM (((((((((  CargoIB LEFT JOIN CONTAINERMANAGERMENT On CargoIB.CargoIB_ID=CONTAINERMANAGERMENT.CargoIB_ID ) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN Container On Container.CTN_ID=CargoIB.CTN_ID ) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN Vessel As VesselInbound On BillOfLadingIB.PRE_VESSEL_ID=VesselInbound.VESSEL_ID) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN Cargo On Cargo.CTN_ID=CargoIB.CTN_ID ) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN BillOfLading On BillOfLading.BL_ID=Cargo.BL_ID )"
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN ContainerOutBoundNotify On ContainerOutBoundNotify.ContainerOutBoundNotifyID=BillOfLading.ContainerOutBoundNotifyID) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheDuleID=ContainerOutBoundNotify.SailingScheduleID ) "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " LEFT JOIN Vessel as VesselOutbound On VesselOutbound.Vessel_ID=SailingScheDule.Vessel_ID )"
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " Where "

    '        MakeQueryContainerMNG = MakeQueryContainerMNG & " ("
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & "CargoIB.Continued = 1 "
    '        MakeQueryContainerMNG = MakeQueryContainerMNG & ") And CargoIB.UpdateTime > Cargo.UpdateTime "
    '        If Not IsNothing(argCriteria) And argCriteria <> "" Then
    '            MakeQueryContainerMNG = MakeQueryContainerMNG & argCriteria
    '        End If
    '        If index = 1 Then ' 
    '            MakeQueryContainerMNG = MakeQueryContainerMNG & strContainerMNGOrder1
    '        ElseIf index = 14 Then ' 
    '            MakeQueryContainerMNG = MakeQueryContainerMNG & strContainerMNGOrder2
    '        End If
    '        'Debug.Print MakeQueryCommodity
    '        Exit Function
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Function
    Private Sub QueryContainerPriceRepair(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 0, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------

        strQuery = MakeQueryContainerRepair()

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableContainerRepair) Then
            oTableContainerRepair.Clear()
        End If

        Adapter.Fill(ds, "ContainerRepair")
        oTableContainerRepair = ds.Tables(0)
        Me.dgdContainerRepair.DataSource = ds.Tables("ContainerRepair")
        Me.dgdContainerRepair.Columns.Item(0).Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableContainerRepair.Rows.Count > 0 Then
            Me.dgdContainerRepair.Columns.Item("Price").ToolTipText = "Hiện có:" + CStr(Me.dgdContainerRepair.RowCount()) + " Price(s)."
            SetMenu(True)
        End If
        '------------vị trí BM
        If Me.oTableContainerMNG.Rows.Count > 0 Then
            location = Me.dgdContainerMNG.CurrentRow.Index
        End If
        If location >= 0 And location <= Me.dgdContainerRepair.Rows.Count And Me.dgdContainerRepair.Rows.Count > 0 Then
            Me.dgdContainerRepair.Rows(location).Selected = True
            Me.dgdContainerRepair.CurrentCell = Me.dgdContainerRepair.Rows(location).Cells(3)
        End If
        '--------------------
        ' Me.UpdateFrame()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Public Function MakeQueryContainerRepair() As String
        On Error GoTo Err_Renamed
        MakeQueryContainerRepair = strContainerPriceRepair
        MakeQueryContainerRepair = MakeQueryContainerRepair & "from ContainerManagerment inner join ContainerRepair on ContainerManagerment.ContainerManagementID = ContainerRepair.ContainerManagementID "
        MakeQueryContainerRepair = MakeQueryContainerRepair & " where ContainerRepair.ContainerManagementID= '" & mContainermanagermentID & "' and ContainerRepair.Continued=1 "
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function


    Private Sub QueryContainerMNG(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim strContainerMNGSelect As String
        strContainerMNGSelect = " Select containermanagerment.ContainerManagementID,BookingNo,CargoIB_ID,Cargo_ID,BL_NO_Inbound, "
        strContainerMNGSelect &= " containermanagerment.Container_No,CTN_SIZE_TYPE,FullOrEmpty,TS_AHR,POL_CODE,Vessel_Inbound,VoyNo_Inbound,Arrival_Date,Arrival_ICD,DisCharge_Date, "
        strContainerMNGSelect &= " ImportCY,convert(datetime,containermanagerment.FactOfDelDate) as FactOfDelDate,convert(datetime,containermanagerment.CorrectionOfDELDate) as CorrectionOfDELDate, "
        strContainerMNGSelect &= " convert(datetime,containermanagerment.FactOfReDelDate) as FactOfReDelDate,convert(datetime,containermanagerment.CorrectionOfReDELDate) as CorrectionOfReDELDate,PicApprove,EmptyCY, "
        strContainerMNGSelect &= " ConditionOfContainerAT_MT_CY,ConditionOfContainerAT_MT_CYDetail,convert(datetime,containermanagerment.DateOfEmptyContainerToShipper) as DateOfEmptyContainerToShipper, "
        strContainerMNGSelect &= " VanningDate,convert(datetime,containermanagerment.DateOfFullLoadContainerToCY) as DateOfFullLoadContainerToCY,ExportCY,convert(datetime,containermanagerment.DateOfOnBoard) as DateOfOnBoard,ConditionOfContainerAT_MT_Out, "
        strContainerMNGSelect &= " Code,SoundContainer,ToBeInSpected,DamageContainer,FullImport,FullToConsignee,FullExport,EmptyToShipper, "
        strContainerMNGSelect &= " EmptyContainerReposit,EmptyExportQuay,ICDPort,FinalICD,RECEIVEKIND,RECEIVEKINDDetail,Vessel_Outbound,"
        strContainerMNGSelect &= " VoyNo_Outbound,ETD,BL_NO_Outbound,Port_Of_Discharge,StorageInvoce,OceanVessel,OceanVoyno,OceanETD,RrepairDate,"
        strContainerMNGSelect &= " CompleteRepairDate,MTDelayCY,MTDelayDate,MTMovingCY,MTMovingDate,containermanagerment.Editable,"
        strContainerMNGSelect &= " containermanagerment.Continued,containermanagerment.Approve,containermanagerment.Userupdate,containermanagerment.UpdateTime,(select emptyport from printemptycontainer where ContainerManagerment.container_no=printemptycontainer.container_no and continued=1 and bl_no_inbound=blib_no )as emptyport,PicApproveDem,RefDem,PicApproveDet,RefDet "
        strContainerMNGSelect &= " from (ContainerManagerment LEFT JOIN DemDetReduce On DemDetReduce.BLIB_NO=BL_NO_INbound And DemdetReduce.Container_No=ContainerManagerment.Container_No)"
        strContainerMNGSelect &= " where containermanagerment.continued=1 " 'left join cargoib on ContainerManagerment.cargoib_id=cargoib.cargoib_id  where ContainerManagerment.continued=1 "
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = strContainerMNGSelect & strContainerMNGSelectC
        Else
            strQuery = strContainerMNGSelect & argCriteria '& strContainerMNGSelectC
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableContainerMNG) Then
            oTableContainerMNG.Clear()
        End If
        Adapter.Fill(ds, "ContainerMNG")
        oTableContainerMNG = ds.Tables(0)
        Me.dgdContainerMNG.DataSource = ds.Tables("ContainerMNG")
        If Me.dgdContainerMNG.Enabled = False Then
            Me.dgdContainerMNG.Enabled = True
        End If


        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableContainerMNG.Rows.Count > 0 Then
            Me.dgdContainerMNG.Columns.Item("BLIB_NO").ToolTipText = "Hiện có:" + CStr(Me.dgdContainerMNG.RowCount()) + " Containers."
            SetMenu(True)
        End If
        '------------vị trí BM
        'If Me.oTableContainerMNG.Rows.Count > 0 Then
        '    location = Me.dgdContainerMNG.CurrentRow.Index
        'End If
        If location >= 0 And location <= Me.dgdContainerMNG.Rows.Count And Me.dgdContainerMNG.Rows.Count > 0 Then
            Me.dgdContainerMNG.Rows(location).Selected = True
            Me.dgdContainerMNG.CurrentCell = Me.dgdContainerMNG.Rows(location).Cells(7)
        End If
        '--------------------
        ' Me.UpdateFrame()
        '------stt tren luoi
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        For i As Integer = 0 To Me.dgdContainerMNG.Columns.Count - 1
            If UCase(Me.dgdContainerMNG.Columns(i).Name) Like "*ID" Or UCase(Me.dgdContainerMNG.Columns(i).Name) Like "*1" Then
                Me.dgdContainerMNG.Columns(i).Visible = False
            End If
        Next

        For i As Integer = 7 To Me.dgdContainerMNG.Columns.Count - 1
            For j As Integer = 0 To Me.dgdContainerMNG.Rows.Count - 1
                If Me.dgdContainerMNG.Item(i, j).Value.ToString.Trim Like "*1900*" Then
                    Me.dgdContainerMNG.Item(i, j).Value = DBNull.Value
                End If
            Next
        Next
        Me.dgdContainerMNG.Columns("FactOfDelDate").DefaultCellStyle.ForeColor = Color.Red
        Me.dgdContainerMNG.Columns("FactOfReDelDate").DefaultCellStyle.ForeColor = Color.Red
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        'Me.smnuInsert.Enabled = argVisible
        Me.smnuEdit.Enabled = argVisible
        Me.smnuDelete.Enabled = argVisible
        Me.smnuDisplay.Enabled = argVisible
        Me.smnuExit.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmContainerManagerMent_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'objUserSetting.SetCParm("frmContainerManagerMent.txtImportCY", Me.txtImportCY.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.dtpFactOFDelDate", Me.dtpFactOFDelDate.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.dtpFactOfReDELDate", Me.dtpFactOfReDELDate.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.dtpCorrectReDELDate", Me.dtpCorrectReDELDate.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.txtPicApprove", Me.txtPicApprove.Text)

        ''objUserSetting.SetCParm("frmContainerManagerMent.txtConditionOfContainerAt_MT_CY", Me.txtConditionOfContainerAt_MT_CY.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.dtpOfMTContainerToShipper", Me.dtpOfMTContainerToShipper.Text)

        'objUserSetting.SetCParm("frmContainerManagerMent.dtpVanningDate", Me.dtpVanningDate.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.dtpFulLoadToCYDate", Me.dtpFulLoadToCYDate.Text)

        'objUserSetting.SetCParm("frmContainerManagerMent.txtExport_CY", Me.txtExport_CY.Text)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkSoundContainer", Me.chkSoundContainer.Checked)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkToBeInspected", Me.chkToBeInspected.Checked)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkDamage", Me.chkDamage.Checked)

        'objUserSetting.SetCParm("frmContainerManagerMent.chkFullImports", Me.chkFullImports.Checked)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkFullToConsignee", Me.chkFullToConsignee.Checked)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkFullExportAtQuay", Me.chkFullExportAtQuay.Checked)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkMT_TobeRepositioned", Me.chkEmptyForRepostioned.Checked)
        'objUserSetting.SetCParm("frmContainerManagerMent.chkEmptyToShipper", Me.chkEmptyToShipper.Checked)


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayVesselInbound", Me.smnuDisplayVesselInbound.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        ''objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayBillOfLading", Me.smnuDisplayBillOfLading.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayDisChargeDate", Me.smnuDisplayDisChargeDate.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayVesselOutbound", Me.smnuDisplayVesselOutbound.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayImportsCY", Me.smnuDisplayImportsCY.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayDelDate", Me.smnuDisplayDelDate.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayReDelDate", Me.smnuDisplayReDelDate.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayPicApprove", Me.smnuDisplayPicApprove.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayEmptyCY", Me.smnuDisplayEmptyCY.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayDateOfMT_ToShipper", Me.smnuDisplayDateOfMT_ToShipper.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayVanningDate", Me.smnuDisplayVanningDate.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayFullLoadContainer_CY", Me.smnuDisplayFullLoadContainer_CY.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayDateOfONboard", Me.smnuDisplayDateOfONboard.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayContainerDetail", Me.smnuDisplayContainerDetail.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmContainerManagerMent.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryICDCombo(ByVal dt As DataTable, ByRef cbo As ComboBox)
        Try
            Dim Display, Value As String
            Display = "Terminal"
            Value = "Code"

            Me.cboEmptyCY.DisplayMember = Display
            Me.cboEmptyCY.ValueMember = Value
            Me.cboEmptyCY.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmContainerManagerMent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        UserRightFrm = "frmContainerManagerMent"
        mStatus = "Normal"
        mCargoIB_ID = DefaultValue
        QueryCode()
        Me.grpFind.Visible = False
        LoadComboFind(Me.cboFind, Me.dgdContainerMNG)
        'Dim dt As New DataTable
        QueryCode()
        QueryICD(Me.cboEmptyCY)
        QueryICD(Me.cboExport_CY)
        QueryICD(Me.cboImportCY)
        QueryICD(Me.cboMTDelayCy)
        QueryICD(Me.cboMTMovingCY)
        QueryICD(Me.cbofilterPlace)
        mFinalICD = ""
        GetContainerType(Me.cboContainerType)
        GetContainerType(Me.cbofilterType)

        '07-12-2007 cho màu chữ trùng màu nền chỉ hiện  lên khi select Text
        Me.txtCODD.ForeColor = Me.txtCODD.BackColor
        Me.txtCRD.ForeColor = Me.txtCRD.BackColor

       
        'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
        'Me.txtImportCY.Text = objUserSetting.GetCParm("frmContainerManagerMent.txtImportCY")
        ''-------------
        'Me.dtpFactOFDelDate.Text = objUserSetting.GetCParm("frmContainerManagerMent.dtpFactOFDelDate")
        'Me.dtpFactOfReDELDate.Text = objUserSetting.GetCParm("frmContainerManagerMent.dtpFactOfReDELDate")

        'Me.dtpCorrectReDELDate.Text = objUserSetting.GetCParm("frmContainerManagerMent.dtpCorrectReDELDate")
        'Me.txtPicApprove.Text = objUserSetting.GetCParm("frmContainerManagerMent.txtPicApprove")
        ''Me.txtConditionOfContainerAt_MT_CY.Text = objUserSetting.GetCParm("frmContainerManagerMent.txtConditionOfContainerAt_MT_CY")
        'Me.dtpOfMTContainerToShipper.Text = objUserSetting.GetCParm("frmContainerManagerMent.dtpOfMTContainerToShipper")
        'Me.dtpVanningDate.Text = objUserSetting.GetCParm("frmContainerManagerMent.dtpVanningDate")
        'Me.dtpFulLoadToCYDate.Text = objUserSetting.GetCParm("frmContainerManagerMent.dtpFulLoadToCYDate")
        'Me.txtExport_CY.Text = objUserSetting.GetCParm("frmContainerManagerMent.txtExport_CY")

        'Me.chkSoundContainer.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkSoundContainer")
        'Me.chkToBeInspected.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkToBeInspected")
        'Me.chkDamage.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkDamage")
        'Me.chkFullImports.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkFullImports")
        'Me.chkFullToConsignee.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkFullToConsignee")
        'Me.chkFullExportAtQuay.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkFullExportAtQuay")
        'Me.chkEmptyForRepostioned.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkMT_TobeRepositioned")
        'Me.chkEmptyToShipper.Checked = objUserSetting.GetCParm("frmContainerManagerMent.chkEmptyToShipper")

        'Me.smnuDisplayVesselInbound.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayVesselInbound")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayApprove")
        '' Me.smnuDisplayBillOfLading.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayBillOfLading")
        'Me.smnuDisplayContainer.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayContainer")
        'Me.smnuDisplayVesselOutbound.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayVesselOutbound")

        'Me.smnuDisplayDisChargeDate.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayDisChargeDate")

        'Me.smnuDisplayImportsCY.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayImportsCY")
        'Me.smnuDisplayDelDate.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayDelDate")
        'Me.smnuDisplayReDelDate.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayReDelDate")
        'Me.smnuDisplayPicApprove.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayPicApprove")
        'Me.smnuDisplayEmptyCY.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayEmptyCY")
        'Me.smnuDisplayDateOfMT_ToShipper.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayDateOfMT_ToShipper")
        'Me.smnuDisplayVanningDate.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayVanningDate")
        'Me.smnuDisplayFullLoadContainer_CY.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayFullLoadContainer_CY")
        'Me.smnuDisplayDateOfONboard.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayDateOfONboard")
        'Me.smnuDisplayContainerDetail.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayContainerDetail")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmContainerManagerMent.smnuDisplayUpdateTime")
        Me.FraUpdate.Visible = False
        UpDateFrame()
        SetDefaultGrid(Me.dgdContainerMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdContainerRepair, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

        '07-12-2007 cho 4 cột màu chữ bằng màu nền
        Dim ForeColor As Color
        ForeColor = Me.dgdContainerMNG.BackgroundColor
        Me.dgdContainerMNG.Columns("PicApproveDem").DefaultCellStyle.ForeColor = ForeColor
        Me.dgdContainerMNG.Columns("PicApproveDet").DefaultCellStyle.ForeColor = ForeColor
        Me.dgdContainerMNG.Columns("REFDem").DefaultCellStyle.ForeColor = ForeColor
        Me.dgdContainerMNG.Columns("RefDet").DefaultCellStyle.ForeColor = ForeColor
        Me.dgdContainerMNG.Columns("CorrectionOfDELDate").DefaultCellStyle.ForeColor = ForeColor
        Me.dgdContainerMNG.Columns("CorrectionOfReDELDate").DefaultCellStyle.ForeColor = ForeColor

        ReFormat()


        Exit Sub
Err:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.dgdContainerMNG.Width = (Me.Width - 25)


        Me.dgdContainerMNG.Height = Me.Height - IIf(Me.FraUpdate.Visible, Me.FraUpdate.Height + 115, 135) '> 7000

        Me.FraUpdate.Top = Me.dgdContainerMNG.Bottom + 10

        Me.FraUpdate.Width = (Me.Width - 25)


        'Me.cmdCancel.Top = Me.cmdOK.Top
        'Me.cmdFind.Left = Me.txtBillOfLading.Right + 10
        Me.grpFind.Left = Me.Width / 2 - Me.grpFind.Width / 2
        Me.grpFind.Top = Me.Height / 2 - Me.grpFind.Height / 2
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Dim strQuery As String
        Dim Isedit As Boolean = False

        ' Dim rsCode As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdContainerMNG.Rows.Count > 0 Then
            index = Me.dgdContainerMNG.CurrentRow.Index
        End If

        'kiểm tra số bill có rỗng không
        If mStatus = "Edit" Or mStatus = "Add" Then
            If mStatus = "Edit" Then
                CopyValues("ContainerManagerMent", "ContainerManageMentID", mContainermanagermentID)
            End If
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM ContainerManagerMent "
            strQuery = strQuery & "WHERE  ContainerManageMentID= '" & mContainermanagermentID & "' AND  Continued=1"
            'If Me.txtDOO.Text <> "" Then
            '    If Me.chkFullExportAtQuay.Checked = False And Me.chkEmptyExpotAtQuay.Checked = False Then
            '        MsgBox("You have to check Empty Export At Quay Or Full Export At Quay!") ', Because date of onboard is not null")
            '        Return
            '    End If
            'End If
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("ContainerManageMentID").Value = NewId()
                    .Fields("CargoIB_ID").Value = "{" & mCargoIB_ID & "}"
                End If
                .Fields("CTN_SIZE_TYPE").Value = Me.cboContainerType.Text
                .Fields("ImportCY").Value = Me.cboImportCY.Text.Trim
                .Fields("FactOfDelDate").Value = Me.txtFODD.Text.Trim
                .Fields("CorrectionOfDELDate").Value = Me.txtCODD.Text.Trim

                .Fields("FactOfReDelDate").Value = Me.txtFORD.Text.Trim
                .Fields("CorrectionOfReDELDate").Value = Me.txtCRD.Text.Trim
                .Fields("PicApprove").Value = Me.txtPicApprove.Text.Trim
                .Fields("EmptyCY").Value = UCase(Trim(Me.cboEmptyCY.Text))
                '.Fields("ConditionOfContainerAT_MT_CY").Value = UCase(Trim(Me.txtConditionOfContainerAt_MT_CY.Text))
                .Fields("DateOfEmptyContainerToShipper").Value = Me.txtDOECTS.Text.Trim
                .Fields("VanningDate").Value = Me.txtVD.Text.Trim
                .Fields("DateOfFullLoadContainerToCY").Value = Me.txtFLTCD.Text.Trim
                .Fields("ExportCY").Value = Me.cboExport_CY.Text.Trim
                .Fields("DateOfOnBoard").Value = Me.txtDOO.Text.Trim
                '.Fields("StorageInvoce").Value = Me.txtStorageInvoce.Text

                .Fields("Arrival_Date").Value = Me.txtArrivalDate.Text.Trim
                .Fields("DisCharge_Date").Value = Me.txtDischargeDate.Text.Trim

                .Fields("SoundContainer").Value = IIf(Me.chkSoundContainer.Checked, 1, 0)
                .Fields("ToBeInSpected").Value = IIf(Me.chkToBeInspected.Checked, 1, 0)
                .Fields("DamageContainer").Value = IIf(Me.chkDamage.Checked, 1, 0)
                .Fields("FullImport").Value = IIf(Me.chkFullImports.Checked, 1, 0)
                .Fields("FullToConsignee").Value = IIf(Me.chkFullToConsignee.Checked, 1, 0)
                .Fields("FullExport").Value = IIf(Me.chkFullExportAtQuay.Checked, 1, 0)
                .Fields("EmptyToShipper").Value = IIf(Me.chkEmptyToShipper.Checked, 1, 0)
                .Fields("EmptyContainerReposit").Value = IIf(Me.chkEmptyForRepostioned.Checked, 1, 0)
                .Fields("EmptyExportQuay").Value = IIf(Me.chkEmptyAtQuay.Checked, 1, 0)

                If Me.cboExport_CY.Text.Trim <> "" Then
                    .Fields("FinalICD").Value = Me.cboExport_CY.Text
                Else
                    If Me.cboEmptyCY.Text.Trim <> "" Then
                        .Fields("FinalICD").Value = Me.cboEmptyCY.Text
                    Else
                        .Fields("FinalICD").Value = Me.cboImportCY.Text
                    End If
                End If

                'If mFinalICD.Trim <> "" Then 'mfinalicd dc gán giá trị khi có sự kiện MTMovingCY,MTDelayCY SelectedIndexChage
                '    .Fields("FinalICD").Value = mFinalICD.Trim
                'End If
                ' ''thêm 26-09-2007

                .Fields("BL_NO_Inbound").Value = Me.txtBLIB_NO.Text

                .Fields("TS_AHR").Value = Me.txtPol.Text 'POL
                .Fields("POL_CODE").Value = Me.txtPolCode.Text
                .Fields("Vessel_Inbound").Value = Me.txtVesselIB.Text
                .Fields("VoyNo_Inbound").Value = Me.txtVoyNoIB.Text
                .Fields("ICDPort").Value = Me.txtPortOfShipment.Text
                .Fields("ConditionOfContainerAT_MT_CY").Value = Me.cboMTContainerAtCY.Text
                .Fields("ConditionOfContainerAT_MT_CYDetail").Value = Me.txtMTContainerDetail.Text

                .Fields("RECEIVEKIND").Value = Me.cboContainerCondition.Text
                .Fields("RECEIVEKINDDetail").Value = Me.txtContainerConditionDetail.Text
                ''Outbound
                .Fields("ConditionOfContainerAT_MT_Out").Value = Me.txtExportContDetail.Text
                .Fields("Code").Value = Me.cboCode.Text
                .Fields("BL_NO_Outbound").Value = Me.txtBLNOOB.Text
                .Fields("Vessel_Outbound").Value = Me.txtVesselOutbound.Text
                .Fields("VoyNo_Outbound").Value = Me.txtVyNoOutbound.Text
                .Fields("Port_Of_Discharge").Value = Me.txtPortOfDischarge.Text
                .Fields("StorageInvoce").Value = Me.txtStoreInvoce.Text


                .Fields("OceanVessel").Value = Me.txtOceanVessel.Text
                .Fields("OceanVoyno").Value = Me.txtOceanVoyNo.Text
                .Fields("OceanETD").Value = Me.txtETD.Text
                .Fields("MTDelayCY").Value = Me.cboMTDelayCy.Text
                .Fields("MTDelayDate").Value = Me.txtMTDelayDate.Text

                .Fields("MTMovingCY").Value = Me.cboMTMovingCY.Text
                .Fields("MTMovingDate").Value = Me.txtMTMovingDate.Text
                .Update()
            End With
            rs.Close()


            Me.dgdContainerMNG.Enabled = True
        End If
        Me.FraUpdate.Visible = False
        blnUpdated = True
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        'Me.cmdSearch_Click(sender, e)
        'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')", , index)

        QueryContainerMNG("  " & mFilter, , index)

        Exit Sub
Err_Renamed:

        'Resume
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        Me.txtContainerNo.Text = Me.dgdContainerMNG.Item("Container_no", index).Value.ToString
        Me.cboContainerType.Text = Me.dgdContainerMNG.Item("ContainerType", index).Value.ToString
        Me.cboImportCY.Text = Me.dgdContainerMNG.Item("ImportCY", index).Value.ToString
        Me.lblFullOrEmpty.Text = IIf(UCase(Me.dgdContainerMNG.Item("FullOrEmpty", index).Value.ToString.Trim) = "F", "Full", "Empty")
        '----
        Me.txtDOO.Text = Me.dgdContainerMNG.Item("DateOfOnBoard", index).Value.ToString
        If Me.txtDOO.Text <> "" Then
            Me.chkDOO.Checked = False
        Else
            Me.chkDOO.Checked = True
        End If

        Me.txtFODD.Text = Me.dgdContainerMNG.Item("FactOfDelDate", index).Value.ToString
        If Me.txtFODD.Text <> "" Then
            Me.chkFODD.Checked = False
        Else
            Me.chkFODD.Checked = True
        End If

        Me.txtCODD.Text = Me.dgdContainerMNG.Item("CorrectionOfDELDate", index).Value.ToString
       
        Me.txtFORD.Text = Me.dgdContainerMNG.Item("FactOfReDelDate", index).Value.ToString
        If Me.txtFORD.Text <> "" Then
            Me.chkFORD.Checked = False
        Else
            Me.chkFORD.Checked = True
        End If

        Me.txtCRD.Text = Me.dgdContainerMNG.Item("CorrectionOfReDELDate", index).Value.ToString
     

        Me.txtDOECTS.Text = Me.dgdContainerMNG.Item("DateOfEmptyContainerToShipper", index).Value.ToString
        If Me.txtDOECTS.Text <> "" Then
            Me.chkDOECTS.Checked = False
        Else
            Me.chkDOECTS.Checked = True
        End If

        Me.txtVD.Text = Me.dgdContainerMNG.Item("VanningDate", index).Value.ToString
        If Me.txtVD.Text <> "" Then
            Me.chkVD.Checked = False
        Else
            Me.chkVD.Checked = True
        End If

        Me.txtFLTCD.Text = Me.dgdContainerMNG.Item("DateOfFullLoadContainerToCY", index).Value.ToString
        If Me.txtFLTCD.Text <> "" Then
            Me.chkFLTCD.Checked = False
        Else
            Me.chkFLTCD.Checked = True
        End If

       
        '-------

        Me.txtArrivalDate.Text = Me.dgdContainerMNG.Item("ETA", index).Value.ToString
        Me.txtDischargeDate.Text = Me.dgdContainerMNG.Item("DisChargeDate", index).Value.ToString
        Me.txtPicApprove.Text = Me.dgdContainerMNG.Item("PicApprove", index).Value.ToString
        Me.cboEmptyCY.Text = Me.dgdContainerMNG.Item("EmptyCY", index).Value.ToString
        'Me.txtConditionOfContainerAt_MT_CY.Text = Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CY", index).Value.ToString


        Me.cboExport_CY.Text = Me.dgdContainerMNG.Item("ExportCY", index).Value.ToString


        If Not IsNothing(Me.dgdContainerMNG.Item("SoundContainer", index)) Then
            Me.chkSoundContainer.Checked = Me.dgdContainerMNG.Item("SoundContainer", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("ToBeInSpected", index)) Then
            Me.chkToBeInspected.Checked = Me.dgdContainerMNG.Item("ToBeInSpected", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("DamageContainer", index)) Then
            Me.chkDamage.Checked = Me.dgdContainerMNG.Item("DamageContainer", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("FullImport", index)) Then
            Me.chkFullImports.Checked = Me.dgdContainerMNG.Item("FullImport", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("FullToConsignee", index)) Then
            Me.chkFullToConsignee.Checked = Me.dgdContainerMNG.Item("FullToConsignee", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("FullExport", index)) Then
            Me.chkFullExportAtQuay.Checked = Me.dgdContainerMNG.Item("FullExport", index).Value
        End If

        If Not IsNothing(Me.dgdContainerMNG.Item("EmptyToShipper", index)) Then
            Me.chkEmptyToShipper.Checked = Me.dgdContainerMNG.Item("EmptyToShipper", index).Value
        End If

        If Not IsNothing(Me.dgdContainerMNG.Item("EmptyContainerReposit", index)) Then
            Me.chkEmptyForRepostioned.Checked = Me.dgdContainerMNG.Item("EmptyContainerReposit", index).Value
        End If

        If Not IsNothing(Me.dgdContainerMNG.Item("EmptyExportQuay", index)) Then
            Me.chkEmptyAtQuay.Checked = Me.dgdContainerMNG.Item("EmptyExportQuay", index).Value
        End If

        ''thêm 26-09-2007
        'Inbound
        Me.txtBLIB_NO.Text = Me.dgdContainerMNG.Item("BLIB_NO", index).Value
        If Not IsDBNull(Me.dgdContainerMNG.Item("POL_NAME", index).Value) Then
            Me.txtPol.Text = Me.dgdContainerMNG.Item("POL_NAME", index).Value
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("POL_CODE", index).Value) Then
            Me.txtPolCode.Text = Me.dgdContainerMNG.Item("POL_CODE", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("VESSELInBound", index).Value) Then
            Me.txtVesselIB.Text = Me.dgdContainerMNG.Item("VESSELInBound", index).Value
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("VOYAGEInbound", index).Value) Then
            Me.txtVoyNoIB.Text = Me.dgdContainerMNG.Item("VOYAGEInbound", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("ICDPort", index).Value) Then
            Me.txtPortOfShipment.Text = Me.dgdContainerMNG.Item("ICDPort", index).Value
        End If



        'Outbound
        If Not IsDBNull(Me.dgdContainerMNG.Item("BL_NO", index).Value) Then
            Me.txtBLNOOB.Text = Me.dgdContainerMNG.Item("BL_NO", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("VesselOutbound", index).Value) Then
            Me.txtVesselOutbound.Text = Me.dgdContainerMNG.Item("VesselOutbound", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("VoyAgeOutbound", index).Value) Then
            Me.txtVyNoOutbound.Text = Me.dgdContainerMNG.Item("VoyAgeOutbound", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("PORT_OF_DISCHARGE_NAME", index).Value) Then
            Me.txtPortOfDischarge.Text = Me.dgdContainerMNG.Item("PORT_OF_DISCHARGE_NAME", index).Value
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("StorageInvoce", index).Value) Then
            Me.txtStoreInvoce.Text = Me.dgdContainerMNG.Item("StorageInvoce", index).Value()
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("OceanVessel", index).Value) Then
            Me.txtOceanVessel.Text = Me.dgdContainerMNG.Item("OceanVessel", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("OceanVoyno", index).Value) Then
            Me.txtOceanVoyNo.Text = Me.dgdContainerMNG.Item("OceanVoyno", index).Value
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("OceanETD", index).Value) Then
            Me.txtETD.Text = Me.dgdContainerMNG.Item("OceanETD", index).Value
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CY", index).Value) Then
            Me.cboMTContainerAtCY.Text = Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CY", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CYDetail", index).Value) Then
            Me.txtMTContainerDetail.Text = Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CYDetail", index).Value
        End If

        If Not IsDBNull(Me.dgdContainerMNG.Item("RECEIVEKIND", index).Value) Then
            Me.cboContainerCondition.Text = Me.dgdContainerMNG.Item("RECEIVEKIND", index).Value
        End If
        If Not IsDBNull(Me.dgdContainerMNG.Item("RECEIVEKINDDetail", index).Value) Then
            Me.txtContainerConditionDetail.Text = Me.dgdContainerMNG.Item("RECEIVEKINDDetail", index).Value
        End If

        'If Me.dgdContainerMNG.Item("MTDelayDate", index).Value.ToString.Trim <> "" Then
        '    Me.dtpDateOfMTDelayCY.Text = Me.dgdContainerMNG.Item("MTDelayDate", index).Value.ToString
        'End If

        Me.txtMTDelayDateTextDisplay.Text = Me.dgdContainerMNG.Item("MTDelayDate", index).Value.ToString.Trim
        Me.txtMTDelayCYDisplay.Text = Me.dgdContainerMNG.Item("MTDelayCY", index).Value.ToString
        Me.txtExportContDetail.Text = Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_Out", index).Value.ToString
        Me.cboCode.Text = Me.dgdContainerMNG.Item("Code", index).Value.ToString
        'If Me.dgdContainerMNG.Item("MTMovingDate", index).Value.ToString.Trim <> "" Then
        '    Me.dtpMtMovingDate.Text = Me.dgdContainerMNG.Item("MTMovingDate", index).Value.ToString
        'End If
        Me.txtMTContainerDetail.Text = Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CYDetail", index).Value.ToString.Trim
        Me.txtMTMovingTextDisplay.Text = Me.dgdContainerMNG.Item("MTMovingDate", index).Value.ToString.Trim
        Me.txtMTMovingCYdisplay.Text = Me.dgdContainerMNG.Item("MTMovingCY", index).Value.ToString

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub RefreshDataRepair(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.txtContainerNo.Text = Me.dgdContainerMNG.Item("Container_no", index).Value.ToString
        Me.cboImportCY.Text = Me.dgdContainerMNG.Item("ImportCY", index).Value.ToString
        '----
        Me.txtDOO.Text = Me.dgdContainerMNG.Item("DateOfOnBoard", index).Value.ToString
        If Me.txtDOO.Text <> "" Then
            Me.chkDOO.Checked = True
        Else
            Me.chkDOO.Checked = False
        End If

        Me.txtFODD.Text = Me.dgdContainerMNG.Item("FactOfDelDate", index).Value.ToString
        If Me.txtFODD.Text <> "" Then
            Me.chkFODD.Checked = True
        Else
            Me.chkFODD.Checked = False
        End If

        Me.txtFORD.Text = Me.dgdContainerMNG.Item("FactOfReDelDate", index).Value.ToString
        If Me.txtFORD.Text <> "" Then
            Me.chkFORD.Checked = True
        Else
            Me.chkFORD.Checked = False
        End If

        Me.txtCRD.Text = Me.dgdContainerMNG.Item("CorrectionOfReDELDate", index).Value.ToString
      
        Me.txtDOECTS.Text = Me.dgdContainerMNG.Item("DateOfEmptyContainerToShipper", index).Value.ToString
        If Me.txtDOECTS.Text <> "" Then
            Me.chkDOECTS.Checked = True
        Else
            Me.chkDOECTS.Checked = False
        End If

        Me.txtVD.Text = Me.dgdContainerMNG.Item("VanningDate", index).Value.ToString
        If Me.txtVD.Text <> "" Then
            Me.chkVD.Checked = True
        Else
            Me.chkVD.Checked = False
        End If

        Me.txtFLTCD.Text = Me.dgdContainerMNG.Item("DateOfFullLoadContainerToCY", index).Value.ToString
        If Me.txtFLTCD.Text <> "" Then
            Me.chkFLTCD.Checked = True
        Else
            Me.chkFLTCD.Checked = False
        End If
        '-------


        Me.txtPicApprove.Text = Me.dgdContainerMNG.Item("PicApprove", index).Value.ToString
        Me.cboEmptyCY.Text = Me.dgdContainerMNG.Item("EmptyCY", index).Value.ToString
        'Me.txtConditionOfContainerAt_MT_CY.Text = Me.dgdContainerMNG.Item("ConditionOfContainerAT_MT_CY", index).Value.ToString


        Me.cboExport_CY.Text = Me.dgdContainerMNG.Item("ExportCY", index).Value.ToString


        If Not IsNothing(Me.dgdContainerMNG.Item("SoundContainer", index)) Then
            Me.chkSoundContainer.Checked = Me.dgdContainerMNG.Item("SoundContainer", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("ToBeInSpected", index)) Then
            Me.chkToBeInspected.Checked = Me.dgdContainerMNG.Item("ToBeInSpected", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("DamageContainer", index)) Then
            Me.chkDamage.Checked = Me.dgdContainerMNG.Item("DamageContainer", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("FullImport", index)) Then
            Me.chkFullImports.Checked = Me.dgdContainerMNG.Item("FullImport", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("FullToConsignee", index)) Then
            Me.chkFullToConsignee.Checked = Me.dgdContainerMNG.Item("FullToConsignee", index).Value
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("FullExport", index)) Then
            Me.chkFullExportAtQuay.Checked = Me.dgdContainerMNG.Item("FullExport", index).Value
        End If

        If Not IsNothing(Me.dgdContainerMNG.Item("EmptyToShipper", index)) Then
            Me.chkEmptyToShipper.Checked = Me.dgdContainerMNG.Item("EmptyToShipper", index).Value
        End If

        If Not IsNothing(Me.dgdContainerMNG.Item("EmptyContainerReposit", index)) Then
            Me.chkEmptyForRepostioned.Checked = Me.dgdContainerMNG.Item("EmptyContainerReposit", index).Value
        End If
        'Me.txtStorageInvoce.Text = Me.dgdContainerMNG.Item("StorageInvoce", index).Value.ToString
        Exit Sub
Err_Renamed:
        'MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        
    End Sub

    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryDetailBillofLadingList As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        'strQuery = "Select count(*) cnt from FREIGHT_CHARGE_IB WHERE BLIB_Id = '" & Me.dgdcontainermng.Item("BL_ID", index).Value.ToString & "' And Continued=1 And Container_type='" & Me.dgdcontainermng.Item("ContainerType", index).Value.ToString.Trim & "'"
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)
        'rs.Close()
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Containers can not be removed. There are transactions that relate to this Container(FreightCharge).")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdContainerMNG.Item("Approve", index)) Then
            If Me.dgdContainerMNG.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdContainerMNG.Item("Editable", index)) Then
            If Not Me.dgdContainerMNG.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight(UserRightFrm, "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container No: " & Me.dgdContainerMNG.Item("Container_NO", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillofLadingList = "Select * from CONTAINERMANAGERMENT where CONTAINERMANAGEMENTID='" & Me.dgdContainerMNG.Item("CONTAINERMANAGEMENTID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQueryDetailBillofLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                Me.dgdContainerMNG.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdContainerMNG.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
 Me.dgdContainerMNG.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdContainerMNG.SelectedRows(i).Index)
            Next i
        End If
        QueryContainerMNG(" " & mFilter) '" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
    End Sub

    Public Sub ApproveContainer()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdContainerMNG.CurrentRow.Index
        Dim strQueryDetailBillOfLadingList As String
        If Not Me.dgdContainerMNG.Item("Editable", index).Value Or Not UserRight(UserRightFrm, "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
        Else
            strQueryDetailBillOfLadingList = "Select * from CONTAINERMANAGERMENT where CONTAINERMANAGEMENTID= '" & Me.dgdContainerMNG.Item("CONTAINERMANAGEMENTID", index).Value.ToString & "' And Continued=1"
            rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdDetailBillOfLading_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainerMNG.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdContainerMNG.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdContainerMNG.CurrentRow.Index

        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        'If RowIndex < 0 Then
        '    Exit Sub
        'End If
        'If Me.dgdContainerMNG.Item(ColIndex, RowIndex) Is Nothing Then
        '    Exit Sub
        'End If
        If ColIndex < 0 Or RowIndex < 0 Then
            Return
        End If
        If Me.dgdContainerMNG.Columns(ColIndex).Name = "Approve" And Me.dgdContainerMNG.CurrentCellAddress().Y = index Then
            Call ApproveContainer()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Equipment Control "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Equipment Control-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Equipment Control-> Add."
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.FraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdContainerMNG.Enabled = True
        Me.cmdOK.Enabled = False
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub UpDateFrame()
        On Error GoTo Err_Renamed
        'Me.dgdContainerMNG.Columns.Item("ContainerManagementID").Visible = False
        'Me.dgdContainerMNG.Columns.Item("VESSELInBound").Visible = Me.smnuDisplayVesselInbound.Checked
        'Me.dgdContainerMNG.Columns.Item("VoyAgeInBound").Visible = Me.smnuDisplayVesselInbound.Checked
        'Me.dgdContainerMNG.Columns.Item("ETA").Visible = Me.smnuDisplayVesselInbound.Checked
        'Me.dgdContainerMNG.Columns.Item("ContainerType").Visible = Me.smnuDisplayContainer.Checked
        'Me.dgdContainerMNG.Columns.Item("Container_No").Visible = Me.smnuDisplayContainer.Checked
        'Me.dgdContainerMNG.Columns.Item("RECEIVEKIND").Visible = Me.smnuDisplayContainer.Checked
        'Me.dgdContainerMNG.Columns.Item("DisChargeDate").Visible = Me.smnuDisplayDisChargeDate.Checked
        'Me.dgdContainerMNG.Columns.Item("VesselOutBound").Visible = Me.smnuDisplayVesselOutbound.Checked
        'Me.dgdContainerMNG.Columns.Item("VoyAgeOutBound").Visible = Me.smnuDisplayVesselOutbound.Checked
        'Me.dgdContainerMNG.Columns.Item("ImportCY").Visible = Me.smnuDisplayImportsCY.Checked
        'Me.dgdContainerMNG.Columns.Item("FactOfDelDate").Visible = Me.smnuDisplayDelDate.Checked
        'Me.dgdContainerMNG.Columns.Item("FactOfReDelDate").Visible = Me.smnuDisplayReDelDate.Checked
        'Me.dgdContainerMNG.Columns.Item("CorrectionOfReDELDate").Visible = Me.smnuDisplayReDelDate.Checked
        'Me.dgdContainerMNG.Columns.Item("PicApprove").Visible = Me.smnuDisplayPicApprove.Checked
        'Me.dgdContainerMNG.Columns.Item("EmptyCY").Visible = Me.smnuDisplayEmptyCY.Checked
        'Me.dgdContainerMNG.Columns.Item("DateOfEmptyContainerToShipper").Visible = Me.smnuDisplayDateOfMT_ToShipper.Checked
        'Me.dgdContainerMNG.Columns.Item("VanningDate").Visible = Me.smnuDisplayVanningDate.Checked
        'Me.dgdContainerMNG.Columns.Item("DateOfFullLoadContainerToCY").Visible = Me.smnuDisplayFullLoadContainer_CY.Checked
        'Me.dgdContainerMNG.Columns.Item("ConditionOfContainerAT_MT_CY").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("ExportCY").Visible = Me.smnuDisplayFullLoadContainer_CY.Checked
        'Me.dgdContainerMNG.Columns.Item("DateOfOnBoard").Visible = Me.smnuDisplayDateOfONboard.Checked
        'Me.dgdContainerMNG.Columns.Item("SoundContainer").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("ToBeInSpected").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("DamageContainer").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("FullImport").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("FullToConsignee").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("FullExport").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("EmptyToShipper").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("EmptyContainerReposit").Visible = Me.smnuDisplayContainerDetail.Checked
        'Me.dgdContainerMNG.Columns.Item("StorageInvoce").Visible = Me.smnuDisplayStorageInvoce.Checked

        'Me.dgdContainerMNG.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        'Me.dgdContainerMNG.Columns.Item("Userupdate").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdContainerMNG.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuDisplayStorageInvoce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayStorageInvoce.Click
        smnuDisplayStorageInvoce.Checked = Not smnuDisplayStorageInvoce.Checked
        UpDateFrame()
    End Sub


#Region "Menu Strip View"

    Private Sub smnuDisplayApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpDateFrame()
    End Sub
    Private Sub smnuDisplayContainer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayContainer.Click
        Me.smnuDisplayContainer.Checked = Not Me.smnuDisplayContainer.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayVesselInbound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayVesselInbound.Click
        Me.smnuDisplayVesselInbound.Checked = Not Me.smnuDisplayVesselInbound.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayDisChargeDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayDisChargeDate.Click
        Me.smnuDisplayDisChargeDate.Checked = Not Me.smnuDisplayDisChargeDate.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayVesselOutbound_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayVesselOutbound.Click
        Me.smnuDisplayVesselOutbound.Checked = Not Me.smnuDisplayVesselOutbound.Checked
        UpDateFrame()
    End Sub


    Private Sub smnuDisplayImportsCY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayImportsCY.Click
        Me.smnuDisplayImportsCY.Checked = Not Me.smnuDisplayImportsCY.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayDelDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayDelDate.Click
        Me.smnuDisplayDelDate.Checked = Not Me.smnuDisplayDelDate.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayReDelDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayReDelDate.Click
        Me.smnuDisplayReDelDate.Checked = Not Me.smnuDisplayReDelDate.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayPicApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayPicApprove.Click
        Me.smnuDisplayPicApprove.Checked = Not Me.smnuDisplayPicApprove.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayEmptyCY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayEmptyCY.Click
        Me.smnuDisplayEmptyCY.Checked = Not Me.smnuDisplayEmptyCY.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayDateOfMT_ToShipper_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayDateOfMT_ToShipper.Click
        Me.smnuDisplayDateOfMT_ToShipper.Checked = Not Me.smnuDisplayDateOfMT_ToShipper.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayVanningDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayVanningDate.Click
        Me.smnuDisplayVanningDate.Checked = Not Me.smnuDisplayVanningDate.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayFullLoadContainer_CY_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayFullLoadContainer_CY.Click
        Me.smnuDisplayFullLoadContainer_CY.Checked = Not Me.smnuDisplayFullLoadContainer_CY.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayUserId_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayDateOfONboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDateOfONboard.Click
        Me.smnuDisplayDateOfONboard.Checked = Not Me.smnuDisplayDateOfONboard.Checked
        UpDateFrame()
    End Sub

    Private Sub smnuDisplayContainerDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayContainerDetail.Click
        Me.smnuDisplayContainerDetail.Checked = Not Me.smnuDisplayContainerDetail.Checked
        UpDateFrame()
    End Sub

#End Region


    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        Me.Close()
    End Sub

    '    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err
    '        Dim index As Integer = 0
    '        If Me.oTableContainerMNG.Rows.Count > 0 Then
    '            If Me.dgdContainerMNG.CurrentRow.Index >= 0 Then
    '                index = Me.dgdContainerMNG.CurrentRow.Index
    '            End If
    '        End If
    '        If Me.cboItems.Text <> "" Then
    '            Select Case Me.cboItems.Text.Trim
    '                Case "Fact Of Delivery Date"
    '                    mFilter = " And (convert(datetime,FactOfDelDate) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,FactOfDelDate) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "Fact Of Redelivery Date"
    '                    mFilter = " And (convert(datetime,FactOfReDelDate) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,FactOfReDelDate) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "Correction Redelivery Date"
    '                    mFilter = " And (convert(datetime,CorrectionOfReDELDate) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,CorrectionOfReDELDate) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "Date Of Empty Container To shipper"
    '                    mFilter = " And (convert(datetime,DateOfEmptyContainerToShipper) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,DateOfEmptyContainerToShipper) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "Vanning Date"
    '                    mFilter = " And (convert(datetime,VanningDate) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,VanningDate) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "Full Load to CY Date"
    '                    mFilter = " And (convert(datetime,DateOfFullLoadContainerToCY) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,DateOfFullLoadContainerToCY) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "Date Of Onboard"
    '                    mFilter = " And (convert(datetime,DateOfOnBoard) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,DateOfOnBoard) <='" & Me.dtpTodate.Value.Date & "')"
    '                Case "ETA"
    '                    mFilter = " And (convert(datetime,Arrival_Date) >= '" & Me.dtpFromDate.Value.Date & "' And convert(datetime,Arrival_Date) <='" & Me.dtpTodate.Value.Date & "')"
    '            End Select
    '            QueryContainerMNG(mFilter, , index)
    '        Else
    '            DisplayMessage(True, "Xin chọn 1 mục để tìm kiếm.")
    '            Me.cboItems.Focus()
    '        End If
    '        Exit Sub
    'Err:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    'Private Sub cboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.cboStatus.Text <> "" Then
    '        If UCase(Me.cboStatus.Text.Trim) = "VIET NAM" Then
    '            QueryContainerMNG(" And BL_NO_Outbound is NULL And DateOfOnboard is NULL ")
    '        Else
    '            QueryContainerMNG(" And BL_NO_Outbound Is Not NULL or dateOfOnboard is Not NULL ")
    '        End If
    '    Else
    '        DisplayMessage(True, "Xin chọn 1 mục để lọc thông tin.")
    '        Me.cboItems.Focus()
    '    End If
    'End Sub

    Private Sub smnuContainerInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuContainerInventory.Click
        On Error GoTo Err
        Me.fraReportInfo.Visible = True
        frmRptContainerInventory.PrintType = "Report"
        Exit Sub
Err:

    End Sub

    Private Sub cmdOkReportinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkReportinfo.Click
        On Error GoTo Err
        Me.fraReportInfo.Visible = False

        frmRptContainerInventory.ShowDialog()
        Exit Sub
Err:

    End Sub

    Private Sub cmdCancelReportInfo_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelReportInfo.Click
        Me.fraReportInfo.Visible = False
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        QueryContainerMNG()
    End Sub

    Private Sub frmContainerManagerMent_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ' ReFormat()
    End Sub

    Private Sub frmContainerManagerMent_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' ReFormat()
    End Sub

    Private Sub chkFODD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFODD.CheckedChanged
        If Me.chkFODD.Checked = True Then
            Me.txtFODD.Text = ""
        Else
            Me.txtFODD.Text = Me.dtpFactOFDelDate.Text
        End If
    End Sub

    Private Sub chkFORD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFORD.CheckedChanged
        If Me.chkFORD.Checked = True Then
            Me.txtFORD.Text = ""
        Else
            Me.txtFORD.Text = Me.dtpFactOfReDELDate.Text
        End If
    End Sub




    Private Sub chkDOECTS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDOECTS.CheckedChanged
        If Me.chkDOECTS.Checked = True Then
            Me.txtDOECTS.Text = ""
        Else
            Me.txtDOECTS.Text = Me.dtpOfMTContainerToShipper.Text
        End If
    End Sub

    Private Sub chkVD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVD.CheckedChanged
        If Me.chkVD.Checked = True Then
            Me.txtVD.Text = ""
        Else
            Me.txtVD.Text = Me.dtpVanningDate.Text
        End If
    End Sub

    Private Sub chkFLTCD_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFLTCD.CheckedChanged
        If Me.chkFLTCD.Checked = True Then
            Me.txtFLTCD.Text = ""
        Else
            Me.txtFLTCD.Text = Me.dtpFulLoadToCYDate.Text
        End If
    End Sub

    Private Sub chkDOO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDOO.CheckedChanged
        If Me.chkDOO.Checked = True Then
            Me.txtDOO.Text = ""
        Else
            Me.txtDOO.Text = Me.dtpDateOfOnboard.Text
        End If
    End Sub

    Sub SetCorrectDELDate()
        Try
            If Me.dgdContainerMNG.Rows.Count = 0 Or Me.dgdContainerMNG.CurrentRow Is Nothing Then
                Return
            End If
            Dim index As Integer = Me.dgdContainerMNG.CurrentRow.Index
            Me.txtCODD.Text = Date.FromOADate(Me.dtpFactOFDelDate.Value.Date.ToOADate - GetDemReduce(Me.dgdContainerMNG.Item("BLIB_NO", index).Value.ToString.Trim, Me.txtContainerNo.Text.Trim)).Date()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub SetCorrectReDELDate()
        Try
            If Me.dgdContainerMNG.Rows.Count = 0 Or Me.dgdContainerMNG.CurrentRow Is Nothing Then
                Return
            End If
            Dim index As Integer = Me.dgdContainerMNG.CurrentRow.Index
            Me.txtCRD.Text = Date.FromOADate(Me.dtpFactOfReDELDate.Value.Date.ToOADate - GetDetReduce(Me.dgdContainerMNG.Item("BLIB_NO", index).Value.ToString.Trim, Me.txtContainerNo.Text.Trim)).Date()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub dtpFactOFDelDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFactOFDelDate.ValueChanged
        SetCorrectDELDate()
        If Me.chkFODD.Checked = False Then
            Me.txtFODD.Text = Me.dtpFactOFDelDate.Value
        End If
    End Sub

    Private Sub dtpFactOfReDELDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFactOfReDELDate.ValueChanged
        SetCorrectReDELDate()
        If Me.chkFORD.Checked = False Then
            Me.txtFORD.Text = Me.dtpFactOfReDELDate.Value
        End If
    End Sub


    Private Sub dtpOfMTContainerToShipper_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpOfMTContainerToShipper.ValueChanged
        If Me.chkDOECTS.Checked = False Then
            Me.txtDOECTS.Text = Me.dtpOfMTContainerToShipper.Value
        End If
    End Sub

    Private Sub dtpVanningDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpVanningDate.ValueChanged
        If Me.chkVD.Checked = False Then
            Me.txtVD.Text = Me.dtpVanningDate.Value
        End If
    End Sub

    Private Sub dtpFulLoadToCYDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFulLoadToCYDate.ValueChanged
        If Me.chkFLTCD.Checked = False Then
            Me.txtFLTCD.Text = Me.dtpFulLoadToCYDate.Value
        End If
    End Sub

    Private Sub dtpDateOfOnboard_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfOnboard.ValueChanged
        If Me.chkDOO.Checked = False Then
            Me.txtDOO.Text = Me.dtpDateOfOnboard.Value
        End If
    End Sub

    Sub SetRepairItem(ByVal value As Boolean)
        Try
            Me.txtDetail.Enabled = value
            Me.txtprice.Enabled = value
            Me.txtFCurrency.Enabled = value
            Me.txtAddess.Enabled = value
            Me.dtprepairDate.Enabled = value
            Me.chkStatusRepair.Enabled = value
            Me.cmdRepair.Enabled = value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CTMAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTMAdd.Click
        Try
            mRepairStatus = "Add"
            SetRepairItem(True)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ctmEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmEdit.Click
        Try
            Dim index As Integer
            If Me.dgdContainerRepair.RowCount > 0 Then
                index = Me.dgdContainerRepair.CurrentRow.Index
            Else
                Exit Sub
            End If
            Me.SetRepairItem(True)

            mRepairStatus = "Edit"

            Me.txtDetail.Text = Me.dgdContainerRepair.Item("Detail", index).Value.ToString.Trim
            Me.txtprice.Text = Me.dgdContainerRepair.Item("Price", index).Value.ToString.Trim
            Me.txtFCurrency.Text = Me.dgdContainerRepair.Item("EX", index).Value.ToString.Trim
            Me.dtprepairDate.Value = Me.dgdContainerRepair.Item("dateRepair", index).Value.ToString.Trim
            Me.dtpNgayhoantat.Value = Me.dgdContainerRepair.Item("dateRepair", index).Value.ToString.Trim
            Me.txtAddess.Text = Me.dgdContainerRepair.Item("Address", index).Value.ToString.Trim
            Me.chkStatusRepair.Checked = Me.dgdContainerRepair.Item("StatusRepair", index).Value


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CTMDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CTMDelete.Click
        Try
            Dim index As Integer
            If Me.dgdContainerRepair.RowCount > 0 Then
                index = Me.dgdContainerRepair.CurrentRow.Index
            Else
                Exit Sub
            End If
            Dim strQuery As String
            strQuery = "select * from ContainerRepair where ContainerRepair_ID='" & Me.dgdContainerRepair.Item("ContainerRepair_ID", index).Value.ToString & "' And Continued=1"
            Dim rs As New ADODB.Recordset
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 0
            rs.Update()
            rs.Close()
            Me.QueryContainerPriceRepair()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRepair.Click
        Try
            If mRepairStatus = "Add" Or mRepairStatus = "Edit" Then
                If Me.txtDetail.Text.Trim.Length = 0 And Me.txtprice.Text.Trim.Length = 0 And Me.txtFCurrency.Text.Trim.Length = 0 Then
                    DisplayMessage(True, "Xin nhập vào đầy đủ dữ liệu.!")
                    Exit Sub
                End If
                Dim strQuery, strContainerRepair_Id, pName As String
                Dim rs As New ADODB.Recordset
                Dim ContainerRepairID As String
                Dim index As Integer
                If Me.oTableContainerRepair.Rows.Count > 0 And mRepairStatus = "Edit" Then
                    index = Me.dgdContainerRepair.CurrentRow.Index
                    ContainerRepairID = Me.dgdContainerRepair.Item("ContainerRepair_Id", index).Value.ToString.Trim()
                Else
                    ContainerRepairID = DefaultValue
                End If
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM ContainerRepair "
                strQuery = strQuery & "WHERE ContainerRepair_Id = '" & ContainerRepairID & "' AND ContainerRepair_Id <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If mRepairStatus = "Add" Then
                        .AddNew()
                        .Fields("ContainerRepair_ID").Value = NewId()
                        .Fields("ContainermanagementID").Value = "{" + mContainermanagermentID + "}"
                    End If
                    '.Fields("ContainerRepair_ID").Value = ContainerRepairID

                    .Fields("price").Value = Me.txtprice.Text.Trim
                    .Fields("Ex").Value = Me.txtFCurrency.Text.Trim
                    .Fields("Detail").Value = Me.txtDetail.Text.Trim
                    .Fields("DateRepair").Value = Me.dtprepairDate.Value
                    .Fields("DateComplete").Value = Me.dtpNgayhoantat.Value
                    .Fields("Address").Value = Me.txtAddess.Text.Trim
                    .Fields("StatusRepair").Value = Me.chkStatusRepair.Checked
                    .Update()
                End With
                rs.Close()


                strQuery = "SELECT * "
                strQuery = strQuery & "FROM ContainerManagerment "
                strQuery = strQuery & "WHERE ContainermanagermentID = '" & mContainermanagermentID & "' AND Continued=1 "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("RrepairDate").Value = Me.dtprepairDate.Value.Date
                rs.Fields("CompleteRepairDate").Value = Me.dtpNgayhoantat.Value.Date
                rs.Close()

                Me.QueryContainerPriceRepair()
                Me.SetRepairItem(False)
                mRepairStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancelRepair_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelRepair.Click
        Me.SetRepairItem(False)
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerMNG("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdContainerMNG.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdContainerMNG, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub mnuContainerSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContainerSummary.Click
        Try
            VB6.ShowForm(frmContainerSummary, VB6.FormShowConstants.Modal, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdContainerMNG_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContainerMNG.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
    End Sub

    Private Sub mnuCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheck.Click


    End Sub

    Private Sub mnuConvertPOLToTS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConvertPOLToTS.Click
        Try
            If Me.dgdContainerMNG.Rows.Count <= 0 Then
                Return
            End If
            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            Dim rsCount As Integer = 0
            For i As Integer = 0 To Me.dgdContainerMNG.RowCount - 1

                If Me.dgdContainerMNG.Item("POL_CODE", i).Value.ToString.Trim <> "" Then
                    Continue For
                End If

                Dim temp As String
                temp = Mid(Me.dgdContainerMNG.Item("BLIB_NO", i).Value.ToString, 2, 3)
                strQuery = "select * from ContainerManagerment Where BL_NO_Inbound='" & Me.dgdContainerMNG.Item("BLIB_NO", i).Value.ToString.Trim & "' And Container_No='" & Me.dgdContainerMNG.Item("Container_No", i).Value.ToString.Trim & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    rs.Fields("POL_CODE").Value = temp
                    rs.Update()
                End If
                rs.Close()

                'For j As Integer = 0 To oTablePort.Rows.Count - 1
                '    'If i = 10 Then
                '    '    MsgBox("")
                '    'End If
                '    'If oTablePort.Rows(j).Item("Port").ToString.Trim = "" Or Me.dgdContainerMNG.Item("POL_CODE", i).Value.ToString = "" Then
                '    '    Continue For
                '    'End If
                '    'rsCount = 0
                '    'Dim PC, P, g As String
                '    'P = oTablePort.Rows(j).Item("Port").ToString.Trim
                '    'PC = oTablePort.Rows(j).Item("Port_Code").ToString.Trim
                '    'g = Me.dgdContainerMNG.Item("POL_CODE", i).Value.ToString()
                '    If (oTablePort.Rows(j).Item("Port").ToString.Trim Like "*" & Me.dgdContainerMNG.Item("POL_CODE", i).Value.ToString & "*" Or Me.dgdContainerMNG.Item("POL_CODE", i).Value.ToString Like "*" & oTablePort.Rows(j).Item("Port").ToString.Trim & "*") And oTablePort.Rows(j).Item("Port").ToString.Trim <> "" And Me.dgdContainerMNG.Item("POL_CODE", i).Value.ToString <> "" Then
                '       Exit For
                '    End If
                'Next

            Next
            QueryContainerMNG(mFilter, , )
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cxtsmnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSearch.Click
        Try
            If Me.dgdContainerMNG.RowCount = 0 Then
                Return
            End If
            Me.grpFind.Visible = True
            Me.grpFind.BringToFront()
            Me.cboFind.Text = FindIDValue(Me.cboFind, Me.dgdContainerMNG.Columns(Me.dgdContainerMNG.CurrentCell.ColumnIndex).Name)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdFindg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindg.Click
        Try
            If Me.txtFind.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
                FindCombo(Me.txtFind.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdContainerMNG)
            End If
            Me.grpFind.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.grpFind.Visible = False
        End Try
    End Sub

    Private Sub txtFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFindg.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnuContainerInventoryEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuContainerInventoryEXCEL.Click
        On Error GoTo Err
        Me.fraReportInfo.Visible = True
        frmRptContainerInventory.PrintType = "Excel"
        Exit Sub
Err:
    End Sub

    Private Sub ReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportToolStripMenuItem.Click

    End Sub

    Private Sub smnuStatusInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuStatusInventory.Click

        VB6.ShowForm(frmContainerstatusInventory, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub mnuNumberOfDayVietNam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNumberOfDayVietNam.Click

        VB6.ShowForm(frmContainerDailyInventory, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub CheckVNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckVNToolStripMenuItem.Click
        VB6.ShowForm(frmCheckContainerstandardform, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub CheckOnboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckOnboardToolStripMenuItem.Click
        VB6.ShowForm(frmCheckContainerOnboard, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub CheckImportEmptyContToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckImportEmptyContToolStripMenuItem.Click
        VB6.ShowForm(frmInputDataListEquipMentControl, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub CheckImportFullContToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckImportFullContToolStripMenuItem.Click
        VB6.ShowForm(frmCheckFromDisChargeList, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub CheckDatabaseOldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDatabaseOldToolStripMenuItem.Click
        VB6.ShowForm(frmCheckContainerManagerment, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub CheckContainerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckContainerToolStripMenuItem.Click
        VB6.ShowForm(VesselCheck, VB6.FormShowConstants.Modeless, Me)
    End Sub
#Region "Cập nhật Ngày 2-10-2007"
    Private Sub txtDOO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDOO.TextChanged
        If Me.txtDOO.Text.Trim <> "" Then 'date of Onboard
            Me.chkOnboard.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFLTCD.Text.Trim <> "" Then 'date of full load to CY
            Me.chkFullExportAtQuay.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtDOECTS.Text.Trim <> "" Then
            Me.chkEmptyToShipper.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFORD.Text.Trim <> "" Then
            Me.chkSoundContainer.Checked = True
            Me.chkEmptyAtQuay.Checked = True
        ElseIf Me.txtFODD.Text.Trim <> "" Then
            Me.chkFullToConsignee.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFODD.Text.Trim = "" Then
            Me.chkFullImports.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        End If
    End Sub

    Private Sub txtFODD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFODD.TextChanged, txtCODD.TextChanged
        If Me.txtDOO.Text.Trim <> "" Then 'date of Onboard
            Me.chkOnboard.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFLTCD.Text.Trim <> "" Then 'date of full load to CY
            Me.chkFullExportAtQuay.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtDOECTS.Text.Trim <> "" Then
            Me.chkEmptyToShipper.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFORD.Text.Trim <> "" Then
            Me.chkSoundContainer.Checked = True
            Me.chkEmptyAtQuay.Checked = True
        ElseIf Me.txtFODD.Text.Trim <> "" Then
            Me.chkFullToConsignee.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFODD.Text.Trim = "" Then
            Me.chkFullImports.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        End If
    End Sub

    Private Sub txtDOECTS_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDOECTS.TextChanged
        If Me.txtDOO.Text.Trim <> "" Then 'date of Onboard
            Me.chkOnboard.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFLTCD.Text.Trim <> "" Then 'date of full load to CY
            Me.chkFullExportAtQuay.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtDOECTS.Text.Trim <> "" Then
            Me.chkEmptyToShipper.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFORD.Text.Trim <> "" Then
            Me.chkSoundContainer.Checked = True
            Me.chkEmptyAtQuay.Checked = True
        ElseIf Me.txtFODD.Text.Trim <> "" Then
            Me.chkFullToConsignee.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFODD.Text.Trim = "" Then
            Me.chkFullImports.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        End If
    End Sub

    Private Sub txtFLTCD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFLTCD.TextChanged
        If Me.txtDOO.Text.Trim <> "" Then 'date of Onboard
            Me.chkOnboard.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFLTCD.Text.Trim <> "" Then 'date of full load to CY
            Me.chkFullExportAtQuay.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtDOECTS.Text.Trim <> "" Then
            Me.chkEmptyToShipper.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFORD.Text.Trim <> "" Then
            Me.chkSoundContainer.Checked = True
            Me.chkEmptyAtQuay.Checked = True
        ElseIf Me.txtFODD.Text.Trim <> "" Then
            Me.chkFullToConsignee.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFODD.Text.Trim = "" Then
            Me.chkFullImports.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        End If

    End Sub

    Private Sub txtFORD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFORD.TextChanged
        If Me.txtDOO.Text.Trim <> "" Then 'date of Onboard
            Me.chkOnboard.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFLTCD.Text.Trim <> "" Then 'date of full load to CY
            Me.chkFullExportAtQuay.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtDOECTS.Text.Trim <> "" Then
            Me.chkEmptyToShipper.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFORD.Text.Trim <> "" Then
            Me.chkSoundContainer.Checked = True
            Me.chkEmptyAtQuay.Checked = True
        ElseIf Me.txtFODD.Text.Trim <> "" Then
            Me.chkFullToConsignee.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        ElseIf Me.txtFODD.Text.Trim = "" Then
            Me.chkFullImports.Checked = True
            Me.chkEmptyAtQuay.Checked = False
        End If
    End Sub

    Private Sub cboMTContainerAtCY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMTContainerAtCY.SelectedIndexChanged, cboContainerCondition.SelectedIndexChanged
        If Me.chkEmptyAtQuay.Checked = True Then
            If UCase(Me.cboMTContainerAtCY.Text) = "S" Then
                Me.chkSoundContainer.Checked = True
            ElseIf UCase(Me.cboMTContainerAtCY.Text) = "D" Then
                Me.chkDamage.Checked = True
            ElseIf UCase(Me.cboMTContainerAtCY.Text) = "I" Then
                Me.chkToBeInspected.Checked = True
            End If
        End If

    End Sub

    Private Sub chkDamage_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDamage.CheckedChanged
        Me.cboMTContainerAtCY.Text = "D"
        Me.chkEmptyAtQuay.Checked = chkDamage.Checked
    End Sub

    Private Sub chkToBeInspected_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkToBeInspected.CheckedChanged
        Me.cboMTContainerAtCY.Text = "I"
        Me.chkEmptyAtQuay.Checked = chkToBeInspected.Checked
    End Sub

    Private Sub chkSoundContainer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSoundContainer.CheckedChanged
        Me.cboMTContainerAtCY.Text = "S"
        Me.chkEmptyAtQuay.Checked = chkSoundContainer.Checked
    End Sub
#End Region

    Private Sub HideOnboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideOnboardToolStripMenuItem.Click
        Try
            Dim rsHide As New ADODB.Recordset
            Dim strQuery As String = "Update CONTAINERMANAGERMENT set continued=1 where dateofonboard <> '' or dateofonboard is not NULL "
            If Not UserRight(UserRightFrm, "Approve") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                'QueryContainerMNG(" And (Arrival_Date>='" & Me.dtpFromDate.Value.Date & "' And Arrival_Date<='" & Me.dtpTodate.Value.Date & "')")
            Else
                rsHide.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                DisplayMessage(True, "It's OK, please check again!")
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub GetBookingNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetBookingNoToolStripMenuItem.Click
        frmGetBookingNoContainerManagerment.Show()
    End Sub

    Private Sub ChangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.dgdContainerMNG.Rows.Count > 0 Then
            index = Me.dgdContainerMNG.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            'QueryRouting(index)
            Approve = Me.dgdContainerMNG.Item("Approve", index).Value
            EditTable = Me.dgdContainerMNG.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight(UserRightFrm, "Edit") Then
                If Me.dgdContainerMNG.RowCount > 0 Then
                    index = Me.dgdContainerMNG.CurrentRow.Index
                End If
                mCargoIB_ID = Me.dgdContainerMNG.Item("CargoIB_ID", index).Value.ToString.Trim
                mContainermanagermentID = Me.dgdContainerMNG.Item("ContainerManagementID", index).Value.ToString.Trim
                Me.cmdOK.Enabled = True
                mStatus = "Edit"
                Me.FraUpdate.Visible = True
                Me.dgdContainerMNG.Height = 306
                Me.dgdContainerMNG.Enabled = False

                ReFormat()
                SetMenu((False))
                QueryContainerPriceRepair()
                RefreshData(index)
                'reText(mStatus)

            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelFilter.Click
        Me.grpFilter.Visible = False
    End Sub

    Private Sub cmdOkFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkFilter.Click
        If Me.cbofilterPlace.Text = "" And Me.cbofilterType.Text = "" Then
            If Me.chkStatus.Checked = True Then
                QueryContainerMNG(" and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' And " & Me.cboContainerStatus.Text.Trim & " =1")
            Else
                QueryContainerMNG(" and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' ")
                'and soundcontainer=0 and tobeinspected=0 and damagecontainer=0 and fullimport=0 and fulltoconsignee=0 and fullexport=0 and emptytoshipper=0 and emptycontainerreposit=0 and emptyexportquay=0 ")
            End If
        ElseIf Me.cbofilterPlace.Text <> "" And Me.cbofilterType.Text = "" Then
            If Me.chkStatus.Checked = True Then
                QueryContainerMNG(" and FinalICD='" & Me.cbofilterPlace.Text.Trim & "' and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") < ='" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' And " & Me.cboContainerStatus.Text.Trim & " =1")
            Else
                QueryContainerMNG(" and FinalICD='" & Me.cbofilterPlace.Text.Trim & "' and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' ")
                'and soundcontainer=0 and tobeinspected=0 and damagecontainer=0 and fullimport=0 and fulltoconsignee=0 and fullexport=0 and emptytoshipper=0 and emptycontainerreposit=0 and emptyexportquay=0 ")
            End If
        ElseIf Me.cbofilterPlace.Text = "" And Me.cbofilterType.Text <> "" Then
            If Me.chkStatus.Checked = True Then
                QueryContainerMNG(" and CTN_SIZE_TYPE='" & Me.cbofilterType.Text.Trim & "' and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' And " & Me.cboContainerStatus.Text.Trim & " =1")
            Else
                QueryContainerMNG(" and CTN_SIZE_TYPE='" & Me.cbofilterType.Text.Trim & "' and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' ")
                'and soundcontainer=0 and tobeinspected=0 and damagecontainer=0 and fullimport=0 and fulltoconsignee=0 and fullexport=0 and emptytoshipper=0 and emptycontainerreposit=0 and emptyexportquay=0 ")
            End If
        ElseIf Me.cbofilterPlace.Text <> "" And Me.cbofilterType.Text <> "" Then
            If Me.chkStatus.Checked = True Then
                QueryContainerMNG(" and FinalICD='" & Me.cbofilterPlace.Text.Trim & "' and CTN_SIZE_TYPE='" & Me.cbofilterType.Text.Trim & "' and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' And " & Me.cboContainerStatus.Text.Trim & " =1")
            Else
                QueryContainerMNG(" and FinalICD='" & Me.cbofilterPlace.Text.Trim & "' and CTN_SIZE_TYPE='" & Me.cbofilterType.Text.Trim & "' and convert(datetime," & Me.cboItems.Text & ") >= '" & Date.FromOADate(Me.dtpFromFilterDate.Value.Date.ToOADate) & "' And Convert(datetime," & Me.cboItems.Text & ") <= '" & Date.FromOADate(Me.dtpToFilterdate.Value.Date.ToOADate + 1) & "' ")
                'and soundcontainer=0 and tobeinspected=0 and damagecontainer=0 and fullimport=0 and fulltoconsignee=0 and fullexport=0 and emptytoshipper=0 and emptycontainerreposit=0 and emptyexportquay=0 ")
            End If
        End If


        Me.grpFilter.Visible = False

    End Sub

    Private Sub FilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilterToolStripMenuItem.Click
        Me.grpFilter.Visible = True
        Me.grpFilter.BringToFront()
    End Sub

    Function GetDemReduce(ByVal BLIB_NO As String, ByVal ContainerNO As String) As Double
        Try
            Dim SQL As String
            SQL = "select DemDays From DemDetReduce Where BLIB_NO='" & BLIB_NO.Trim & "' And Container_No='" & ContainerNO & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            Return dt.Rows(0).Item("DemDays")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function GetDetReduce(ByVal BLIB_NO As String, ByVal ContainerNO As String) As Double
        Try
            Dim SQL As String
            SQL = "select DemDays + DetDays as DetDays From DemDetReduce Where BLIB_NO='" & BLIB_NO.Trim & "' And Container_No='" & ContainerNO & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            Return dt.Rows(0).Item("DetDays")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        If mFilter = "" Then
            Return
        End If
        QueryContainerMNG(" " & mFilter)
    End Sub

    Private Sub StorageContainerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StorageContainerToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmStorageSoundCOntainerFee, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DayOfStatusContainerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DayOfStatusContainerToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmDayOfEachStatus, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DemDetSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DemDetSummaryToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmDemDetInventory, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub chkMTDelayDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMTDelayDate.CheckedChanged
        If Me.chkMTDelayDate.Checked = True Then
            Me.txtMTDelayDate.Text = Me.dtpDateOfMTDelayCY.Value.Date
        Else
            Me.txtMTDelayDate.Text = ""
        End If
    End Sub
    Private Sub chkMTMoving_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMTMoving.CheckedChanged
        If Me.chkMTMoving.Checked = False Then
            Me.txtMTMovingDate.Text = Me.dtpMtMovingDate.Value.Date
        Else
            Me.txtMTMovingDate.Text = ""
        End If
    End Sub
    Private Sub dtpDateOfMTDelayCY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDateOfMTDelayCY.ValueChanged, dtpMtMovingDate.ValueChanged
        If Me.chkMTDelayDate.Checked = False Then
            Me.txtMTDelayDate.Text = Me.dtpDateOfMTDelayCY.Value.Date
        Else
            Me.txtMTDelayDate.Text = ""
        End If
    End Sub

   
    'Private Sub cboMTDelayCy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMTDelayCy.SelectedIndexChanged
    '    mFinalICD = cboMTDelayCy.Text
    'End Sub

    'Private Sub cboMTMovingCY_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMTMovingCY.SelectedIndexChanged
    '    mFinalICD = cboMTMovingCY.Text
    'End Sub

    Private Sub MTContainerMovingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTContainerMovingToolStripMenuItem.Click
        If Me.dgdContainerMNG.Rows.Count = 0 Then
            Return
        End If
        If IsNothing(Me.dgdContainerMNG.CurrentRow) Then
            Return
        End If
        Dim index As Integer = Me.dgdContainerMNG.CurrentRow.Index
        mContainermanagermentID = Me.dgdContainerMNG.Item("ContainerManagementID", index).Value.ToString
        Me.txtCurrentCYMoving.Text = Me.dgdContainerMNG.Item("FinalICD", index).Value.ToString


        fraMTMoving.Visible = True
        fraMTMoving.BringToFront()
    End Sub

    Private Sub MTContainerDelayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MTContainerDelayToolStripMenuItem.Click
        If Me.dgdContainerMNG.Rows.Count = 0 Then
            Return
        End If
        If IsNothing(Me.dgdContainerMNG.CurrentRow) Then
            Return
        End If

        Dim index As Integer = Me.dgdContainerMNG.CurrentRow.Index
        mContainermanagermentID = Me.dgdContainerMNG.Item("ContainerManagementID", index).Value.ToString
        Me.txtCurrentCYMTDelay.Text = Me.dgdContainerMNG.Item("FinalICD", index).Value.ToString


        fraMTDelay.Visible = True
        fraMTDelay.BringToFront()

    End Sub

    Private Sub cmdCancelMTMovingDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelMTMovingDisplay.Click
        fraMTMoving.Visible = False
    End Sub

    Private Sub cmdCancelMTdelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelMTdelay.Click
        fraMTDelay.Visible = False
    End Sub
    Sub UpdateSQL(ByVal SQL As String)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOkMTDelay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkMTDelay.Click
        Try
            Dim SQL As String
            SQL = " Update ContainerManagerMent "
            SQL &= " Set MTDelayCY='" & Me.cboMTDelayCy.Text & "',MTDelayDate=' " & Me.txtMTDelayDate.Text & "',FinalICD='" & Me.cboMTDelayCy.Text & "'"
            SQL &= " Where ContainerManagementID='" & mContainermanagermentID & "'"
            UpdateSQL(SQL)
            Me.fraMTDelay.Visible = False
            mFilter = " and ContainerManagementID='" & mContainermanagermentID & "'"
            QueryContainerMNG(" " & mFilter)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdOkMTMoving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkMTMoving.Click
        Try
            Dim SQL As String
            'If Me.ch Then
            SQL = " Update ContainerManagerMent "
            SQL &= " Set MTMovingCY='" & Me.cboMTMovingCY.Text & "',MTMovingDate=' " & Me.txtMTMovingDate.Text & "', FinalICD='" & Me.cboMTMovingCY.Text & "'"
            SQL &= " Where ContainerManagementID='" & mContainermanagermentID & "'"
            UpdateSQL(SQL)
            Me.fraMTMoving.Visible = False
            mFilter = " and ContainerManagementID='" & mContainermanagermentID & "'"
            QueryContainerMNG(" " & mFilter)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub mnucheckmtmoving_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnucheckmtmoving.Click
        On Error GoTo Err
        VB6.ShowForm(frmCheckContainerMTMoving, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CheckStatusContainerBeforeReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckStatusContainerBeforeReportToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(CheckStatusHistoryBeforeReport, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InsertInfomationOutboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsertInfomationOutboundToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmUpdateLoadingListInfo, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        On Error GoTo Err
        VB6.ShowForm(frmUpdateInBoundCY, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Label61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Sub QueryCode()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "CodeSTATUSID"
        value = "code"
        strSQL = "Select CodeSTATUSID, CODE From codestatus "
        loadDataToObject(Me.cboCode, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class