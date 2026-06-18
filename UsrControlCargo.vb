Imports System.Globalization
Public Class UsrControlCargo

    Public mStatus, mStatusP, mFilter As String
    Public blnUpdated, mCopy, Check_CTNChanged As Boolean
    Public mCargo_ID, mPrice_ID, mCargoMarks_ID, mCargoRemarks_ID, mCargoDesc_ID, mCargoHouseDesc_ID, SealId As String
    '------------------
    Public oTableBillOfLading As DataTable
    Public dsBillOfLading As New DataSet
    Public CtainerID, mPackagesID, CtainerID_P, strCargo_ID, strCargo_Desc_ID, FreightChargeID As String
    '------------------
    Public oTableDetailBillOfLading As DataTable
    Public dsDetailBillOfLading As New DataSet
    '------------------
    Public oTableCopyBillOfLading As DataTable
    Public dsCopyBillOfLading As New DataSet

    '------------------
    Public oTablePrice As DataTable
    Public dsPrice As New DataSet

    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer


    Const strPriceSelect As String = "SELECT  FREIGHT_CHARGE_Master.BL_ID as Cargo_id," & _
"FREIGHT_CHARGE_Master.Charge_ID as Charge_ID,  FREIGHT_CHARGE_Master.FREIGHT_CHARGES_ID as FREIGHT_CHARGES_ID, " & _
"FREIGHT_CHARGE_Master.Currency as Currency, Charge.Charge_Code as Charge_Code," & _
           "Amount,UnitPriceSale,FREIGHT_CHARGE_Master.PAYABLE_AT_ID as PAYABLE_AT_ID,QUANTITY,UNIT_OF_QUANTITY, " & _
           " FREIGHT_CHARGE_Master.POP," & _
           " RATE_OF_FR_CH,PREPAID_COLLECT,PAYER_CODE,IG_CODE,CONTAINER_TYPE as CONTAINERTYPE,Unit," & _
            "FREIGHT_CHARGE_Master.Continued, " & _
            "FREIGHT_CHARGE_Master.Editable, " & _
           "FREIGHT_CHARGE_Master.Approve, " & _
           "FREIGHT_CHARGE_Master.UserId, " & _
           "FREIGHT_CHARGE_Master.Updatetime "

    Const strPriceOrder As String = _
        " ORDER BY FREIGHT_CHARGE_Master.UpdateTime Desc "

    '*-*
    Const strDetailBillOfLadingSelect As String = "SELECT  BillOfLading.BL_Id, BillofLading.BL_NO as BL_No, " & _
       "SEALNO as Seal_NO,Cargo.SEAL_ID as SEAL_ID ,seal_no2,seal_no3,seal_no4,seal_no5,seal_no6,seal_no7,seal_no8,seal_no9,CTN_SIZE_TYPE ,CTN_STATUS," & _
       "Cargo.CTN_ID as CTN_ID,container.CONTAINER_NO, Cargo.Cargo_ID as Cargo_ID," & _
       "Cargo.Amount as Amount, Cargo.ReeferDegree as ReeferDegree,CARGO_DESCRIPTION.DESCRIPTION," & _
       "Cargo.Kind as Kind,Cargo.Kind_Code as Kind_Code, Cargo_Marks.Marks as Marks, Cargo_remarks.CARGO_REMARKS as CARGO_REMARKS," & _
       "Cargo.Gross as Gross, Cargo_Description.Cargo_Description_ID as Cargo_Description_ID,Cargo.TEMPERATURE_SETTING as TEMPERATURE_SETTING," & _
       "Cargo.Unit_Gross as Unit_Gross," & _
       "Cargo.CARGO_GROSS_WEIGHT as CARGO_GROSS_WEIGHT,cargo.NUMBER_OF_PACKAGES as NUMBER_OF_PACKAGES, cargo.SHIPPER_OWNED_UNIT as SHIPPER_OWNED_UNIT, " & _
       "Cargo.UNIT_MEASUREMENT as UNIT_MEASUREMENT,cargo.TARIFF as TARIFF,cargo.HS_CODE as HS_CODE,Cargo.IMO_CLASS as IMO_CLASS,Cargo.IMO_UN_NO as IMO_UN_NO, " & _
       "Cargo.CARGO_RECEVING_DATE as CARGO_RECEVING_DATE,cargo.EMS as EMS ,Cargo.MFAG as MFAG,Cargo.TECHNICAL_DESCRIPTION as TECHNICAL_DESCRIPTION, " & _
        "cargo.Week as Week, Cargo.CTN_CARGO_MEASUREMENT as CTN_CARGO_MEASUREMENT, Cargo.IMO_PAGE as IMO_PAGE,cargo.FLASH_POINT as FLASH_POINT," & _
       "cargo.Note as Note, cargo.PACKAGE_HAZARDOUS_DESCRIPTION as PACKAGE_HAZARDOUS_DESCRIPTION," & _
       "ContainerOutboundNotify.ServiceContract as ServiceContract," & _
       "CARGO_SEQUENCE,CARGO_GROSS_CUBE,Cargo.TEMPERATURE_ID,Min_Temperature,Max_Temperature,CARGO_NET_WEIGHT,COMMODITY,COMMODITY_GROUP," & _
       "Cargo.Vent," & _
        "Cargo.Continued, " & _
       "Cargo.Editable, " & _
       "Cargo.Approve, " & _
       "Cargo.UserId, " & _
       "Cargo.Updatetime "
    Const strDetailBillOfLadingOrder1 As String = _
             " ORDER BY BL_NO  Desc "
    Const strDetailBillOfLadingOrder2 As String = _
        " ORDER BY Cargo.UpdateTime Desc "

    Const strBillOfLadingSelect As String = "SELECT BillOfLading.BillOfLadingId as BillOfLadingId,BillOfLading.ShipperId, Shipper.Name as ShipperName, " & _
    "BillOfLading.ConsigneeId, " & _
    "Consignee.Name as ConsigneeName, " & _
    "BillOfLading.NotifyId, " & _
    "Notify.Name as NotifyName, " & _
    "PreCarriageVessel, " & _
    "PreCarriageVoyNo, " & _
    "PlaceOfReceipt, " & _
    "BillOfLading.OceanVesselId, " & _
    "Vessel.Name as OceanVesselName, " & _
    "ContainerOutboundNotfiy.ServiceContract as ServiceContract, " & _
    "VoyNo, " & _
    "PortOfLoading, " & _
    "PortOfDischarge, " & _
        "PlaceOfDelivery, " & _
        "FinalDestination, " & _
        "DescriptionOfContentsForShipper, " & _
        "TotalNoContainerOrPackages, " & _
        "PreightCharges, " & _
        "RevenueTons, " & _
        "Rate, " & _
        "Prepaid, " & _
        "Collect, " & _
        "PrepaidAt, " & _
        "PayableAt, " & _
        "PlaceOfIssue, " & _
      "DateOfIssue, " & _
        "TotalPrepaidIn, " & _
        "NoOfOrigineBL, " & _
        "UserList.name as CreativeUser, " & _
        "CreativeDate, " & _
     "BillOfLading.Editable as Editable, " & _
       "BillOfLading.Continued as Continued, " & _
        "BillOfLading.Approve as Approve, " & _
          "BillOfLading.UserId as UserId, " & _
        "BillOfLading.Updatetime as Updatetime"

    Const strBillOfLadingOrder1 As String = _
          " ORDER BY BillOfLading.BillOfLadingId  Desc "
    Const strBillOfLadingOrder2 As String = _
        " ORDER BY BillOfLading.UpdateTime Desc "

    Const strMarketSelect As String = "SELECT " & _
        "port.Port_Code as POD , " & _
       " (select port_code from port where Port_ID = POL_ID) as POL, " & _
       "charge.Charge_Code , " & _
       "PriceStandard.CTN_TYPE , " & _
       "PriceStandard.Prepaid_Collect, " & _
       "PriceStandard.Price, " & _
       "PriceStandard.Currency, ApplyDate,ExpireDate ," & _
       "PriceStandard.UserId "


    Sub Queryport(ByRef Cbo As Object, Optional ByVal id As String = "Port_ID", Optional ByVal value As String = "Port_Code", Optional ByVal rang As String = "")
        Dim oItem As PDSAListItemString
        Dim intLoop As Integer
        Try
            Cbo.Items.Clear()
            For intLoop = 0 To oTablePort.Rows.Count - 1
                oItem = New PDSAListItemString
                With oTablePort.Rows(intLoop)
                    oItem.Value = Trim(.Item(value).ToString())
                    oItem.ID = .Item(id).ToString()
                End With
                Cbo.Items.Add(oItem)
            Next
            If oTablePort.Rows.Count > 0 Then
                Cbo.SelectedIndex = 0
            End If
        Catch oExcept As Exception
            MessageBox.Show(oExcept.Message)
        End Try
    End Sub

    Sub QueryBookingSurcharge()
        Try
            Dim SQL As String
            SQL = "Select FreightSale.* "
            SQL &= " From ((BillOfLading Inner Join ContainerOutboundNotify On BillofLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= " Inner Join FreightSale On ContainerOutboundNotify.ContainerOutboundNotifyID=FreightSale.ContainerOutboundNotifyID) "
            SQL &= " Where BillOfLading.BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text).ToString & "' And FreightSale.Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdBookingSurcharge.DataSource = dt

            Me.dgdBookingSurcharge.Columns("Charge").Visible = False
            Me.dgdBookingSurcharge.Columns("Editable").Visible = False
            Me.dgdBookingSurcharge.Columns("Continued").Visible = False

            For i As Integer = 0 To Me.dgdBookingSurcharge.Columns.Count - 1
                If UCase(Me.dgdBookingSurcharge.Columns(i).Name) Like "*ID" Then
                    Me.dgdBookingSurcharge.Columns(i).Visible = False
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ApproveDetailBillOfLading()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
        Dim strQueryDetailBillOfLadingList As String
        If Not Me.dgdDetailBillOfLading.Item("Editable", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))

        Else
            strQueryDetailBillOfLadingList = "Select * from Cargo where" + " Cargo_Id= '" & Me.dgdDetailBillOfLading.Item("Cargo_Id", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
    End Sub

    Sub QueryBooking(ByRef oTable As DataTable)
        Try

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strQuery As String
            strQuery = " Select Cold,Ventilation as Vent "
            strQuery &= " From (ContainerOutboundNotify LEFT JOIN BillOfLading On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " Where BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' And ContainerOutboundNotify.Continued=1"
            Dim Cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(Cmd)
            If oTable.Rows.Count > 0 Then
                oTable.Rows.Clear()
            End If
            Adapter.Fill(oTable)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    '    Private Sub frmListCargo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        SetDefaultGrid(Me.dgdBookingSurcharge, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    '        SetDefaultGrid(Me.dgdDetailBillOfLading, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    '        SetDefaultGrid(Me.dgdPrice, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    '        SetDefaultGrid(Me.dgdBookingSurcharge, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtFCommodity", Me.txtSHIPPERNAME.Text)
    '        ''-------------
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtContainerNo", Me.cboCTN_NO.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtSealNo", Me.cboSealNo.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.cboContainerType", Me.txtContainerType.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtAmount", Me.txtAmount.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtkind", Me.txtKind.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.cboKind", Me.cboKind.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtGross", Me.txtGross.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.cboUnitGross", Me.cboUnitGross.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtMeas", Me.txtMeas.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.cboUnitVolume", Me.cboUnitVolume.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtWeek", Me.txtWeek.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtReeferDegree", Me.txtReeferDegree.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtNote", Me.txtNote.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtDescription", Me.txtDescription.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtClauseOfService", Me.txtClauseOfService.Text)

    '        ''''''''''''''''''''''''''----------------

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtTARIFF", Me.txtTariff.Text)
    '        '-------------
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtHSCODE", Me.txtHsCode.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtIMOCLASS", Me.txtImoClass.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtIMOUNNO", Me.txtImoUnNo.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtFLASHPOINT", Me.txtFlashPoint.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtIMOPAGE", Me.txtIMOPage.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtEMS", Me.txtEMS.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtMFAG", Me.txtMFAG.Text)
    '        'objUserSetting.SetCParm("frmListCargoMaster.txtTachnicalDescription", Me.txtTachnicalDescription.Text)

    '        'objUserSetting.SetCParm("frmListCargoMaster.txtPHDescription", Me.txtPHDescription.Text)

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayAmount", Me.smnuDisplayAmount.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        'objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayBillOfLading", Me.smnuDisplayBillOfLading.Checked)

    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayClauseOfService", Me.smnuDisplayClauseOfService.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayContainersId", Me.smnuDisplayContainersNo.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayContainerType", Me.smnuDisplayContainerType.Checked)

    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayGross", Me.smnuDisplayGross.Checked)

    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayKind", Me.smnuDisplayKind.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayMeas", Me.smnuDisplayMeas.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayNote", Me.smnuDisplayNote.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayReceiveDate", Me.smnuDisplayReceiveDate.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayReeferDegree", Me.smnuDisplayReeferDegree.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplaySealNo", Me.smnuDisplaySealNo.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayUnitGross", Me.smnuDisplayUnitGross.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayUnitMeas", Me.smnuDisplayUnitMeas.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayWeek", Me.smnuDisplayWeek.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayTARIFF", Me.smnuDisplayTARIFF.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayHS_CODE", Me.smnuDisplayHS_CODE.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayIMO_CLASS", Me.smnuDisplayIMO_CLASS.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayIMO_UN_NO", Me.smnuDisplayIMO_UN_NO.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayIMO_PAGE", Me.smnuDisplayIMO_PAGE.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayFLASH_POINT", Me.smnuDisplayFLASH_POINT.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayEMS", Me.smnuDisplayEMS.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayMFAG", Me.smnuDisplayMFAG.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayTECHNICAL_DESCRIPTION", Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked)

    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION", Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayTotalGross", Me.smnuDisplayTotalgross.Checked)
    '        objUserSetting.SetBParm("frmListCargoMaster.smnuDisplayTotalPakages", Me.smnuDisplayTotalPakages.Checked)

    '        Me.cmdCancel_Click(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '       msgbox(err.description)
    '    End Sub

    Sub QueryBill_NO()
        On Error GoTo Err_Renamed

        Dim id As String = "BL_ID"
        Dim value As String = "BL_No"
        On Error GoTo Err_Renamed
        Dim strSQL As String

        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select BL_ID ,BL_No From BILLOFLADING where Continued=1 Order By BL_NO desc"
        loadDataToObject(Me.cboBillofLading, strSQL, id, value)
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub
    '    Sub QueryPackages()
    '        On Error GoTo Err_Renamed

    '        Dim id As String = "PACKAGES_ID"
    '        Dim value As String = "PACKAGES_Code"
    '        On Error GoTo Err_Renamed
    '        Dim strSQL As String

    '        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
    '        strSQL = "Select PACKAGES_ID ,PACKAGES_Code From Packages where Continued=1 Order By PACKAGES_ID desc"
    '        loadDataToObject(Me.cboPackages, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '       msgbox(err.description)
    '    End Sub

    Sub QuerySealNo()
        On Error GoTo Err_Renamed

        Dim id As String = "SEAL_ID"
        Dim value As String = "SEALNO"
        Dim strSQL As String
        strSQL = "Select SEAL_ID,SEALNO From SEAL Where Continued=1 Order By SEALNO Desc"
        loadDataToObject(Me.cboSealNo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub
    '    Sub QueryCharge()
    '        On Error GoTo Err_Renamed

    '        Dim id As String = "Charge_Id"
    '        Dim value As String = "Charge_code"
    '        Dim strSQL As String
    '        strSQL = "Select * From Charge Where Continued=1 Order By Charge_code Desc"
    '        loadDataToObject(Me.cboItems, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '       msgbox(err.description)
    '    End Sub
    Sub QueryContainerNO()
        On Error GoTo Err_Renamed

        Dim id As String = "CTN_ID"
        Dim value As String = "CONTAINER_NO"
        Dim strSQL As String
        strSQL = "Select CTN_ID,CONTAINER_NO From Container Where Continued=1 Order By CTN_SIZE_TYPE Desc"
        loadDataToObject(Me.cboCTN_NO, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
    End Sub
    Sub QueryContainer()
        On Error GoTo Err_Renamed
        Dim id As String = "BL_ID"
        Dim value As String = "Container_TYPE"
        Dim strSQL As String
        strSQL = "Select DISTINCT BL_ID,Container_TYPE From Cargo Where Continued=1 "
        strSQL &= " And BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' Order By Container_TYPE Desc"
        loadDataToObject(Me.cboContainerType, strSQL, id, value)
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub


    Private Sub frmListCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mCargoMarks_ID = DefaultValue
        mCargoRemarks_ID = DefaultValue
        mCargoDesc_ID = DefaultValue

        FreightChargeID = DefaultValue

        mCargoHouseDesc_ID = DefaultValue

        mStatusP = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdDetailBillOfLading, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdBookingSurcharge, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdPrice, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdDetailBillOfLading)
        'Dim oItems As PDSAListItemString

        ' ''-------------CboKind
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PACKAGE", "PACKAGE")
        'Me.cboKind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CARTONS", "CARTONS")
        'Me.cboKind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "DRUM", "DRUM")
        'Me.cboKind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "UNIT", "UNIT")
        'Me.cboKind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "BAG", "BAG")
        'Me.cboKind.Items.Add(oItems)
        ' ''-------------
        ' ''-----Gross weight

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "KGS", "KGS")
        'Me.cboUnitGross.Items.Add(oItems)
        ''--------------Meas
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CBM", "CBM")
        'Me.cboUnitVolume.Items.Add(oItems)


        ''--------------
        '---------------------
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "USD", "USD")
        'Me.cboCurrency.Items.Add(oItems)
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "EUR", "EUR")
        'Me.cboCurrency.Items.Add(oItems)
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "VND", "VND")
        'Me.cboCurrency.Items.Add(oItems)
        ''-----------------

        'If Me.dgdPrice.RowCount = 0 Then
        '    Me.dgdPrice.ContextMenuStrip = Me.ctmnuPrice
        'End If

        'đỗ dữ liệu vào combobox BiilofLading
        GetCurrency(Me.cboCurrency)
        QueryBill_NO()

        'QueryDetailBillOfLading()
        QueryContainer()

        QueryContainerNO()
        QuerySealNo()
        'QueryPackages()

        ' Me.txtBillOfLadingId.Text = gBillOfLadingNumber

        Reefer_Degree()


        QueryItems()
        QueryPayable()
        '------------------------
        'Me.txtContainerType.Text = objUserSetting.GetCParm("frmListCargoMaster.cboContainerType", "20GP")
        'Me.cboKind.Text = objUserSetting.GetCParm("frmListCargoMaster.cboKind", "PACKAGE")
        'Me.cboUnitGross.Text = objUserSetting.GetCParm("frmListCargoMaster.cboUnitGross", "Kgs")
        'Me.cboUnitVolume.Text = objUserSetting.GetCParm("frmListCargoMaster.cboUnitVolume", "M3")

        'mFilter = objUserSetting.GetCParm("frmListCargoMaster.mFilter")
        'Me.TxtName.Text = objUserSetting.GetCParm("frmListCargo.txtName")

        'Me.txtAddress.Text = objUserSetting.GetCParm("frmListCargo.txtAddress")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmListCargo.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmListCargo.txtEmail")
        'Me.txtPhone.Text = objUserSetting.GetCParm("frmListCargo.txtPhone")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmListCargo.txtFax")
        'Me.txtContactperson.Text = objUserSetting.GetCParm("frmListCargo.txtContactPerson")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmListCargo.txtRemarks")
        'If Me.txtSHIPPERNAME.Text <> "" Then
        '    QueryBillOfLading("AND Name LIKE '" & MakeFilter(Me.txtSHIPPERNAME.Text) & "' " & mFilter)
        'Else
        '    QueryBillOfLading(mFilter)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If
        ' Me.cboBillofLading.Text = objUserSetting.GetCParm("frmListCargoMaster.cboFind")
        'Me.txtSHIPPERNAME.Text = objUserSetting.GetCParm("frmListCargoMaster.txtFCommodity")

        ''-------------
        'Me.cboCTN_NO.Text = objUserSetting.GetCParm("frmListCargoMaster.txtContainerNo")
        'Me.cboSealNo.Text = objUserSetting.GetCParm("frmListCargoMaster.txtSealNo")

        'Me.txtContainerType.Text = objUserSetting.GetCParm("frmListCargoMaster.cboContainerType")
        'Me.txtAmount.Text = objUserSetting.GetCParm("frmListCargoMaster.txtAmount")
        'Me.txtKind.Text = objUserSetting.GetCParm("frmListCargoMaster.txtkind")
        'Me.cboKind.Text = objUserSetting.GetCParm("frmListCargoMaster.cboKind")

        'Me.txtGross.Text = objUserSetting.GetCParm("frmListCargoMaster.txtGross")
        'Me.cboUnitGross.Text = objUserSetting.GetCParm("frmListCargoMaster.cboUnitGross")


        'Me.txtMeas.Text = objUserSetting.GetCParm("frmListCargoMaster.txtMeas")
        'Me.cboUnitVolume.Text = objUserSetting.GetCParm("frmListCargoMaster.cboUnitVolume")
        'Me.txtWeek.Text = objUserSetting.GetCParm("frmListCargoMaster.txtWeek")
        'Me.txtReeferDegree.Text = objUserSetting.GetCParm("frmListCargoMaster.txtReeferDegree")

        'Me.txtNote.Text = objUserSetting.GetCParm("frmListCargoMaster.txtNote")
        'Me.txtDescription.Text = objUserSetting.GetCParm("frmListCargoMaster.txtDescription")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.txtTariff.Text = objUserSetting.GetCParm("frmListCargoMaster.txtTariff")
        ' Me.txtHsCode.Text = objUserSetting.GetCParm("frmListCargoMaster.txtHSCODE")

        '-------------
        'Me.txtImoClass.Text = objUserSetting.GetCParm("frmListCargoMaster.txtIMOCLASS")
        'Me.txtImoUnNo.Text = objUserSetting.GetCParm("frmListCargoMaster.txtIMOUNNO")

        'Me.txtIMOPage.Text = objUserSetting.GetCParm("frmListCargoMaster.txtIMOPAGE")
        'Me.txtFlashPoint.Text = objUserSetting.GetCParm("frmListCargoMaster.txtFLASHPOINT")
        'Me.txtEMS.Text = objUserSetting.GetCParm("frmListCargoMaster.txtEMS")
        'Me.txtMFAG.Text = objUserSetting.GetCParm("frmListCargoMaster.txtMFAG")

        'Me.txtTachnicalDescription.Text = objUserSetting.GetCParm("frmListCargoMaster.txtTachnicalDescription")
        'Me.txtPHDescription.Text = objUserSetting.GetCParm("frmListCargoMaster.txtPHDescription")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.txtClauseOfService.Text = objUserSetting.GetCParm("frmListCargoMaster.txtClauseOfService")

        '----------------

        Me.smnuDisplayAmount.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayAmount")
        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayApprove")
        ' Me.smnuDisplayBillOfLading.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayBillOfLading")

        Me.smnuDisplayClauseOfService.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayClauseOfService")
        Me.smnuDisplayContainersNo.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayContainersNO")
        Me.smnuDisplayContainerType.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayContainerType")

        Me.smnuDisplayGross.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayGross")

        Me.smnuDisplayKind.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayKind")
        Me.smnuDisplayMeas.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayMeas")
        Me.smnuDisplayNote.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayNote")
        Me.smnuDisplayReceiveDate.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayReceiveDate")
        Me.smnuDisplayReeferDegree.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayReeferDegree")
        Me.smnuDisplaySealNo.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplaySealNo")
        Me.smnuDisplayUnitGross.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayUnitGross")
        Me.smnuDisplayUnitMeas.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayUnitMeas")
        Me.smnuDisplayWeek.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayWeek")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.smnuDisplayTARIFF.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayTARIFF")
        Me.smnuDisplayIMO_CLASS.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayIMO_CLASS")
        Me.smnuDisplayHS_CODE.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayHS_CODE")

        Me.smnuDisplayIMO_UN_NO.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayIMO_UN_NO")

        Me.smnuDisplayIMO_PAGE.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayIMO_PAGE")
        Me.smnuDisplayFLASH_POINT.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayFLASH_POINT")
        Me.smnuDisplayEMS.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayEMS")
        Me.smnuDisplayMFAG.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayMFAG")

        Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayTECHNICAL_DESCRIPTION")
        Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION")
        Me.smnuDisplayMarks.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayMarks")
        Me.smnuDisplayRemarks.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayRemarks")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListCargoMaster.smnuDisplayUpdateTime")
        UpdateFrame()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        'Me.cmdOK.Enabled = False
        'Dim index As Integer
        'If Me.dgdDetailBillOfLading.RowCount > 0 Then
        '    index = Me.dgdDetailBillOfLading.CurrentRow.Index
        '    'Me.dgdDetailBillOfLading.SelectedRows
        '    Me.txtContainerKindP.Text = Me.dgdDetailBillOfLading.Item("Kind", index).Value.ToString
        '    Me.txtContainerNoP.Text = Me.dgdDetailBillOfLading.Item("ContainersId", index).Value.ToString
        '    Me.txtBillOfLadingP.Text = Me.dgdDetailBillOfLading.Item("Bill_No", index).Value.ToString
        'End If
        'Me.txtDescription.Enabled = False
        'Me.lblDescription.Enabled = False
        Me.lblReeferDegree.Visible = False
        Me.txtReeferDegree.Visible = False
        Me.lblo.Visible = False

        Me.cmdOKP.Enabled = False
        Me.cmdOKPrice.Enabled = False
        ReFormat()
        'Me.cmdOKP.Enabled = False
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub QueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------

        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPrice(, index)
        Else
            strQuery = MakeQueryPrice(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTablePrice) Then
            oTablePrice.Clear()
        End If
        Me.dgdPrice.Columns.Item("FREIGHT_CHARGES_ID").Visible = False
        Adapter.Fill(dsPrice, "PriceList")
        oTablePrice = dsPrice.Tables(0)
        'hien thi ra grid 
        Me.dgdPrice.DataSource = dsPrice.Tables("PriceList")
        If Me.dgdPrice.Enabled = False Then
            Me.dgdPrice.Enabled = True
        End If
        Me.Cursor = System.Windows.Forms.Cursors.Default
        InsertAutoNumberToGrid(Me.dgdPrice)
        Exit Sub
Err_Renamed:
        msgbox(err.description)
        'Resume
    End Sub

    Private Sub QueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryBillOfLading()
        Else
            strQuery = MakeQueryBillOfLading(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableBillOfLading) Then
            oTableBillOfLading.Clear()
        End If
        Adapter.Fill(dsBillOfLading, "BillOfLadingList")
        oTableBillOfLading = dsBillOfLading.Tables(0)
        'hien thi ra grid 
        Me.dgdDetailBillOfLading.DataSource = dsBillOfLading.Tables("BillOfLadingList")
        If Me.dgdDetailBillOfLading.Enabled = False Then
            Me.dgdDetailBillOfLading.Enabled = True
        End If
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdDetailBillOfLading.Rows.Count And Me.dgdDetailBillOfLading.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading.Rows(location).Selected = True
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableBillOfLading.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading.Columns.Item("BillOfLadingId1").ToolTipText = "Hiện có:" + CStr(Me.dgdDetailBillOfLading.RowCount()) + " Bills."
        End If
        'If Me.dgdDetailBillOfLading.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        'End If
        Exit Sub
Err_Renamed:
        'MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Sub QueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryDetailBillOfLading()
        Else
            strQuery = MakeQueryDetailBillOfLading(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableDetailBillOfLading) Then
            oTableDetailBillOfLading.Clear()
        End If
        Adapter.Fill(dsDetailBillOfLading, "DetailBillOfLadingList")
        oTableDetailBillOfLading = dsDetailBillOfLading.Tables(0)
        'hien thi ra grid 


        Me.dgdDetailBillOfLading.DataSource = dsDetailBillOfLading.Tables("DetailBillOfLadingList")

        If Me.dgdDetailBillOfLading.Enabled = False Then
            Me.dgdDetailBillOfLading.Enabled = True
        End If


        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableDetailBillOfLading.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading.Columns.Item("Cargo_Id").ToolTipText = "Hiện có:" + CStr(Me.dgdDetailBillOfLading.RowCount()) + " Containers."
            SetMenu(True)
        End If
        Me.txtTotalGrossW.Text = totalGross()
        Me.txtTotalPackage.Text = totalPackage()
        Me.txtTotalVolime.Text = totalVolume()
        'If Me.dgdDetailBillOfLading.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        'End If
        '------------vị trí BM 
        Me.UpdateFrame()
        If location > 0 And location <= Me.dgdDetailBillOfLading.Rows.Count And Me.dgdDetailBillOfLading.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading.Rows(location).Selected = True
            Me.dgdDetailBillOfLading.CurrentCell = Me.dgdDetailBillOfLading.Rows(location).Cells(3)
        End If
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading)
        Exit Sub
Err_Renamed:
        msgbox(err.description)
        'Resume
    End Sub

    Sub QueryItems()
        On Error GoTo ERR_NAMED
        Dim id As String = "CHARGE_ID"
        Dim value As String = "CHARGE_CODE"
        Dim strQuery As String = "Select CHARGE_ID,CHARGE_CODE from CHARGE where CONTINUED=1 order by Charge_code "
        loadDataToObject(Me.cboItems, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        msgbox(err.description)
    End Sub

    Sub QueryPayable()
        On Error GoTo ERR_NAMED
        Dim cbo As Object
        cbo = Me.cboPayableCode
        Queryport(cbo)
        Exit Sub
ERR_NAMED:
        msgbox(err.description)
    End Sub

    Private Function MakeQueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 0) As String
        On Error GoTo Err_Renamed
        MakeQueryPrice = strPriceSelect
        MakeQueryPrice = MakeQueryPrice & " FROM (FREIGHT_CHARGE_Master left join Charge on FREIGHT_CHARGE_Master.Charge_Id=Charge.Charge_Id) "
        ' MakeQueryPrice = MakeQueryPrice & " LEFT JOIN PAYABLE_AT on PAYABLE_AT.PAYABLE_AT_ID=FREIGHT_CHARGE_Master.PAYABLE_AT_ID)  "
        MakeQueryPrice = MakeQueryPrice & "WHERE ((FREIGHT_CHARGE_Master.BL_Id = '" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "') " 'Me.dgdDetailBillOfLading.Item("BL_ID", index).Value.ToString.Trim & "') "
        MakeQueryPrice = MakeQueryPrice & "And ("
        MakeQueryPrice = MakeQueryPrice & " FREIGHT_CHARGE_Master.Continued = 1 "
        MakeQueryPrice = MakeQueryPrice & "))"
        If argCriteria <> "" Then
            MakeQueryPrice = MakeQueryPrice & argCriteria
        End If
        MakeQueryPrice = MakeQueryPrice & strPriceOrder

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function
    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = strBillOfLadingSelect
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM ((((BillOfLading left join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) left join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) left join Notify on BillOfLading.NotifyId=Notify.NotifyId) left join UserList on BillOfLading.CreativeUser=UserList.Usr) Left join Vessel on BillOfLading.OceanVesselId=Vessel.VesselId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "WHERE (BillOfLading.BillOfLadingId = '" & DefaultValue & "') "

        MakeQueryBillOfLading = MakeQueryBillOfLading & "OR ("
        MakeQueryBillOfLading = MakeQueryBillOfLading & " BillOfLading.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryBillOfLading = MakeQueryBillOfLading & strBillOfLadingOrder1
        ElseIf index = 14 Then ' 
            MakeQueryBillOfLading = MakeQueryBillOfLading & strBillOfLadingOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function
    Private Function MakeQueryDetailBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryDetailBillOfLading = strDetailBillOfLadingSelect
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " FROM (((((((Cargo left join BillOfLading on Cargo.BL_Id = BillOfLading.BL_Id) left JOIN container on cargo.CTN_ID=Container.CTN_ID)"
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN SEAL On SEAL.SEAL_ID=Cargo.SEAL_ID) LEFT JOIN CARGO_DESCRIPTION ON CARGO.Cargo_Desc_ID=CARGO_DESCRIPTION.CARGO_DESCRIPTION_ID) "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "LEFT JOIN Cargo_Marks on Cargo.BL_ID=Cargo_Marks.BL_ID) LEFT JOIN Cargo_Remarks on Cargo.BL_ID=Cargo_Remarks.BL_ID)  "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN ContainerOutboundNotify ON ContainerOutboundNotify.ContainerOutboundNotifyID= BillOfLading.ContainerOutboundNotifyID) "
        'MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN CargoHouse_Description ON CargoHouse_Description.Cargo_Description_ID=Cargo_Description.Cargo_Description_ID) "
        'MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " LEFT JOIN Cargo_House ON Cargo_House.Cargo_ID = Cargo.Cargo_ID) "

        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & " Where (Cargo.BL_ID = '" & DefaultValue & "') "




        'If mCopy = True Then
        '    MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "WHERE (DetailBillOfLading.BillOfLadingId = '" & oTableBillOfLading.Rows(indexBill).Item("BillOfLadingId") & "') "
        'Else
        '    MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "WHERE (DetailBillOfLading.BillOfLadingId = '" & gBillOfLadingNumber & "') "
        'End If


        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "OR ("
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & "Cargo.Continued = 1 "
        MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & strDetailBillOfLadingOrder1
        ElseIf index = 14 Then ' 
            MakeQueryDetailBillOfLading = MakeQueryDetailBillOfLading & strDetailBillOfLadingOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function
    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed
        Me.dgdDetailBillOfLading.Columns.Item("Cargo_Id").Visible = False

        Me.dgdDetailBillOfLading.Columns.Item("ClauseOfService").Visible = Me.smnuDisplayClauseOfService.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Containers_No").Visible = Me.smnuDisplayContainersNo.Checked

        Me.dgdDetailBillOfLading.Columns.Item("SealNo").Visible = Me.smnuDisplaySealNo.Checked
        Me.dgdDetailBillOfLading.Columns.Item("ContainerType").Visible = Me.smnuDisplayContainerType.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Amount").Visible = Me.smnuDisplayAmount.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Kind").Visible = Me.smnuDisplayKind.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Gross").Visible = Me.smnuDisplayGross.Checked
        Me.dgdDetailBillOfLading.Columns.Item("UnitGross").Visible = Me.smnuDisplayUnitGross.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Meas").Visible = Me.smnuDisplayMeas.Checked
        Me.dgdDetailBillOfLading.Columns.Item("UnitMeas").Visible = Me.smnuDisplayUnitMeas.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Receivedate").Visible = Me.smnuDisplayReceiveDate.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Week").Visible = Me.smnuDisplayWeek.Checked
        Me.dgdDetailBillOfLading.Columns.Item("ReeferDegree").Visible = Me.smnuDisplayReeferDegree.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Note").Visible = Me.smnuDisplayNote.Checked

        Me.dgdDetailBillOfLading.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        Me.dgdDetailBillOfLading.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdDetailBillOfLading.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Me.dgdDetailBillOfLading.Columns.Item("NUMBER_OF_PACKAGES").Visible = Me.smnuDisplayTotalPakages.Checked
        Me.dgdDetailBillOfLading.Columns.Item("CARGO_GROSS_WEIGHT").Visible = Me.smnuDisplayTotalgross.Checked
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.dgdDetailBillOfLading.Columns.Item("TARIFF").Visible = Me.smnuDisplayTARIFF.Checked
        Me.dgdDetailBillOfLading.Columns.Item("HS_CODE").Visible = Me.smnuDisplayHS_CODE.Checked

        Me.dgdDetailBillOfLading.Columns.Item("IMO_CLASS").Visible = Me.smnuDisplayIMO_CLASS.Checked
        Me.dgdDetailBillOfLading.Columns.Item("IMO_UN_NO").Visible = Me.smnuDisplayIMO_UN_NO.Checked
        Me.dgdDetailBillOfLading.Columns.Item("IMO_PAGE").Visible = Me.smnuDisplayIMO_PAGE.Checked
        Me.dgdDetailBillOfLading.Columns.Item("FLASH_POINT").Visible = Me.smnuDisplayFLASH_POINT.Checked
        Me.dgdDetailBillOfLading.Columns.Item("EMS").Visible = Me.smnuDisplayEMS.Checked
        Me.dgdDetailBillOfLading.Columns.Item("MFAG").Visible = Me.smnuDisplayMFAG.Checked
        Me.dgdDetailBillOfLading.Columns.Item("TECHNICAL_DESCRIPTION").Visible = Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked
        Me.dgdDetailBillOfLading.Columns.Item("PACKAGE_HAZARDOUS_DESCRIPTION").Visible = Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked
        Me.dgdDetailBillOfLading.Columns.Item("CargoMarks").Visible = Me.smnuDisplayMarks.Checked
        Me.dgdDetailBillOfLading.Columns.Item("Cargo_Remarks").Visible = Me.smnuDisplayRemarks.Checked

        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub
    Private Sub ReFormat1()
        On Error GoTo Err
        'If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < 705 Or Me.Height >= 705) Then
        '    Me.Height = 740
        'End If
        'If (Me.Width < 910 Or Me.Width > 910) Then
        '    Me.Width = 910
        'End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 108 - (frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18)
        Me.Width = frmMain.Width - 8
        'If Me.Width > 610 Then
        '    dgdDetailBillOfLading.Height = Me.Height - 60 - IIf(TabCargo.Visible, TabCargo.Height + 35, 40) '> 7000
        'Else
        '    dgdDetailBillOfLading.Height = Me.Height - 110 - IIf(TabCargo.Visible, TabCargo.Height + 5, 40) ' < 7000
        'End If
        'If Me.TabCargo.Visible = False Then
        '    
        '    dgdDetailBillOfLading.Width = Me.Width - 20
        '    dgdDetailBillOfLading.Height = Me.Height - 300

        'End If

        'dgdNotify.Width = (Me.Width - 20)
        'If Me.Width > 610 Then
        '    dgdNotify.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        'Else
        '    dgdNotify.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        'End If
        'fraUpdate.Width = (Me.Width - 30)
        'fraUpdate.Top = dgdNotify.Height + dgdNotify.Top '+ 100
        'Me.txtNotify.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtAddress.Width = Me.fraUpdate.Width - Me.txtAddress.Left - 10
        'Me.txtContactperson.Width = Me.fraUpdate.Width - Me.txtContactperson.Left - 10


        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10
        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdFind.Left = Me.txtNotify.Left + Me.txtNotify.Width + 10
        'txtNotify.Width = Me.Width - 297

        If (Me.TabCargo.Visible = False) Then
            Me.dgdDetailBillOfLading.Height = Me.Height - Me.txtSHIPPERNAME.Height - 40
        Else
            Me.dgdDetailBillOfLading.Height = Me.Height - Me.txtDescription.Height - Me.TabCargo.Height - Me.txtSHIPPERNAME.Height - 50
        End If
        Exit Sub
Err:
        msgbox(err.description)
        'Resume
    End Sub
    Private Sub ReFormat()
        On Error GoTo Err
        'If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(tabcargo.Visible, 540, 540)) Then
        '    Me.Height = IIf(tabcargo.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If 
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0

        Me.Width = frmMain.Width - 8
        'Me.fraBillNo.Left = Me.Width - fraBillNo.Width - 20
        'Me.fraTotal.Left = Me.Width - fraTotal.Width - 20
        dgdDetailBillOfLading.Width = (Me.Width - 30)
        Me.TabCargo.Width = Me.Width - 30
        Me.dgdPrice.Width = Me.TabCargo.Width - 30

        Me.Height = frmMain.Height - 10 - Me.Top
        Me.TabCargo.Top = Me.Height - Me.TabCargo.Height - Me.cmdCancel.Height - 30
        Me.cmdOK.Left = TabCargo.Width - 200
        Me.cmdCancel.Left = Me.cmdOK.Left + Me.cmdOK.Width + 20
        Me.grpFind.Left = Me.Width / 2 - Me.grpFind.Width / 2
        Me.grpFind.Top = Me.Height / 2 - Me.grpFind.Height / 2

        cmdCancel.Top = TabCargo.Bottom + 2
        cmdOK.Top = cmdCancel.Top

        'Me.fraCargoGoods.Width = Me.TabCargo.Width - 20
        'MsgBox(Me.Width)
        'If Me.Width > 800 Then
        '    Me.Height = frmMain.Height - 10 - Me.Top
        '    dgdDetailBillOfLading.Height = Me.Height - 60 - IIf(TabCargo.Visible, 100 + TabCargo.Height + 110, +40) '> 7000
        'Else
        '    Me.Height = frmMain.Height - 10 - Me.Top
        '    dgdDetailBillOfLading.Height = Me.Height - 90 - IIf(TabCargo.Visible, TabCargo.Height + 85, +10) ' < 7000
        'End If
        If Me.TabCargo.Visible = True Then
            Me.dgdDetailBillOfLading.Height = Me.TabCargo.Top - Me.dgdDetailBillOfLading.Top - 10
        Else
            Me.dgdDetailBillOfLading.Height = Me.Height - Me.dgdDetailBillOfLading.Top - Me.MenuStrip.Height - Me.cboBillofLading.Height - 10
        End If

        'cmdFind.Left = Me.txtContainer.Left + Me.txtContainer.Width + 10
        'txtContainer.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(Err.Description)
        'Resume
    End Sub
    '    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
    '        On Error GoTo Err_Renamed
    '        Me.Close()
    '        Exit Sub
    'Err_Renamed:
    '       msgbox(err.description)
    '    End Sub

    Private Sub cboCTN_NO_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCTN_NO.MouseClick

        If mStatus = "Edit" Then
            Dim index As Integer
            If Me.dgdDetailBillOfLading.Rows.Count > 0 Then
                index = Me.dgdDetailBillOfLading.CurrentRow.Index
            End If
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim blnEmpty As Boolean
            strQuery = "Select count(*) cnt from Freight_Charge_Master WHERE Container_Type = '" & Me.txtContainerType.Text.Trim & "'  and Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            blnEmpty = (rs.Fields("cnt").Value = 0)
            rs.Close()
            If Not blnEmpty Then
                DisplayMessage(True, "The Containers Kind can not be Change. There are Prieght Charge that relate to This Kind Container .")

                If Me.dgdDetailBillOfLading.Rows.Count > 0 Then
                    index = Me.dgdDetailBillOfLading.CurrentRow.Index
                    Me.cboCTN_NO.Text = Me.dgdDetailBillOfLading.Item("Containers_No", index).Value.ToString.Trim
                End If

                Exit Sub
            End If
        End If
        Exit Sub
Err_Named:
        msgbox(err.description)
    End Sub
    Private Sub cboContainerType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCTN_NO.TextChanged
        On Error GoTo Err_Renamed
        Reefer_Degree()
        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
    End Sub
    Private Sub cboctn_no_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCTN_NO.Leave
        On Error GoTo Err_Renamed
        Dim strSql, Port_code As String
        Me.cboCTN_NO.Text = Trim(UCase(Me.cboCTN_NO.Text))
        strSql = "Select container_no as container_no From container Where Continued=1"
        If Me.cboCTN_NO.FindStringExact(Me.cboCTN_NO.Text) = -1 Then
            DisplayMessage(True, "The Container is invalid, please check and correct it.")
            Me.cboCTN_NO.Text = FindBetter_new("container_no", strSql, Me.cboCTN_NO.Text)
            If Me.cboCTN_NO.FindStringExact(Me.cboCTN_NO.Text) = -1 Then
                DisplayMessage(True, "The Container is invalid, please check and correct it.")
                Me.cboCTN_NO.Focus()
            End If
        End If
        Reefer_Degree()
        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
    End Sub
    Public Sub Reefer_Degree()
        On Error GoTo Err_Renamed
        If Me.txtContainerType.Text.Trim = "20RF" Or Me.txtContainerType.Text.Trim = "40RF" Or Me.txtContainerType.Text.Trim = "40RH" Then
            Me.lblReeferDegree.Visible = True
            Me.txtReeferDegree.Visible = True
            Me.lblo.Visible = True
        Else
            Me.lblReeferDegree.Visible = False
            Me.txtReeferDegree.Visible = False
            Me.lblo.Visible = False
        End If
        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Detail Cargo Master "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Detail Cargo Master-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Detail Cargo Master-> Add."
        End If

    End Sub
    Function InsertHouseBill() As Boolean
        On Error GoTo Err_Renamed
        Dim strQuery, strCargoHouse_Desc_ID As String
        Dim rs, rsHBL As New ADODB.Recordset
        Dim index As Integer = 0
        Dim indexBill As Integer
        'If Me.dgdDetailBillOfLading.RowCount > 0 Then
        '    index = Me.dgdDetailBillOfLading.CurrentRow.Index
        '    indexBill = Me.dgdDetailBillOfLading.CurrentRow.Index
        'End If

        'Lấy Số House Bill trong CSDL ra để thêm vào

        strQuery = "SELECT * "
        strQuery = strQuery & "FROM BILLOFLADING_HOUSE "
        strQuery = strQuery & "WHERE BL_ID = '" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "'"
        rsHBL.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rsHBL.EOF Then
            Return False
        End If
        rsHBL.MoveFirst()
        While Not rsHBL.EOF
            'thêm vào Cargo House Description
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHOUSE_DESCRIPTION "
            strQuery = strQuery & "WHERE BLH_ID= '" & rsHBL.Fields("BLH_ID").Value.ToString & "'  "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouse_Description_ID").Value = NewId()

                    '.Fields("BL_ID").Value = "{" & BillID & "}"
                    '.Fields("Cargo_Description_ID").Value = mCargoDesc_ID
                    Dim temp As String
                    temp = rsHBL.Fields("BLH_ID").Value.ToString
                    .Fields("BLH_ID").Value = temp
                End If
                strCargoHouse_Desc_ID = .Fields("CargoHouse_Description_ID").Value
                .Fields("DESCRIPTION").Value = Trim(Me.txtDescription.Text)
                .Update()
            End With
            rs.Close()

            'thêm vào cargo House 

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Cargo_House "
            strQuery = strQuery & "WHERE BLH_Id = '" & rsHBL.Fields("BLH_ID").Value.ToString & "'  "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs

                .AddNew()

                .Fields("CargoHouse_ID").Value = NewId()

                ' .Fields("Cargo_ID").Value = strCargo_ID

                .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString

                '.Fields("BL_Id").Value = "{" & BillID & "}"

                .Fields("CTN_ID").Value = "{" & CtainerID & "}"

                .Fields("SEAL_ID").Value = SealId
                ' .Fields("PACKAGES_ID").Value = "{" & FindValueID(Me.cboPackages, Me.cboPackages.Text) & "}"
                '--insert seal no 
                .Fields("Seal_no2").Value = Me.txtSeal_no2.Text
                .Fields("seal_no3").Value = Me.txtSeal_no3.Text
                .Fields("Seal_no4").Value = Me.txtSeal_no4.Text
                .Fields("seal_no5").Value = Me.txtSeal_no5.Text
                .Fields("seal_no6").Value = Me.txtSeal_no6.Text

                .Fields("seal_no7").Value = Me.txtSeal_no7.Text
                .Fields("seal_no8").Value = Me.txtSeal_no8.Text
                .Fields("seal_no9").Value = Me.txtSeal_no9.Text




                .Fields("Cargo_Desc_ID").Value = strCargoHouse_Desc_ID

                'strCargo_ID = .Fields("Cargo_Id").Value

                .Fields("CARGO_GROSS_WEIGHT").Value = Me.txtTotalGrossW.Text


                .Fields("NUMBER_OF_PACKAGES").Value = Me.txtTotalPackage.Text

                .Fields("TEMPERATURE_ID").Value = Me.txttempID.Text

                .Fields("Amount").Value = Me.txtAmount.Text

                .Fields("TARIFF").Value = Trim(Me.txtTariff.Text)
                .Fields("HS_CODE").Value = Trim(Me.txtHsCode.Text)
                .Fields("IMO_CLASS").Value = Trim(Me.txtImoClass.Text)
                .Fields("IMO_UN_NO").Value = Trim(Me.txtImoUnNo.Text)
                .Fields("IMO_PAGE").Value = Trim(Me.txtIMOPage.Text)
                .Fields("FLash_Point").Value = Trim(Me.txtFlashPoint.Text)
                .Fields("EMS").Value = Trim(Me.txtEMS.Text)

                .Fields("CTN_STATUS").Value = UCase(Me.txtCTNStatus.Text.Trim)
                .Fields("KIND_CODE").Value = UCase(Me.txtCodeKind.Text.Trim)

                .Fields("CARGO_SEQUENCE").Value = Trim(Me.txtCargoSequence.Text)
                .Fields("COMMODITY_GROUP").Value = Trim(Me.txtCommodityGroup.Text)
                .Fields("COMMODITY").Value = Trim(Me.txtCommodity.Text)
                .Fields("CARGO_GROSS_CUBE").Value = Trim(Me.txtCargoGrossCube.Text)
                '.Fields("CARGO_NET_WEIGHT").Value = Trim(Me.txtt.Text)
                .Fields("CARGO_GROSS_WEIGHT").Value = Trim(Me.txtTotalGrossW.Text)

                .Fields("MFAG").Value = Trim(Me.txtMFAG.Text)
                .Fields("TECHNICAL_DESCRIPTION").Value = Trim(Me.txtTachnicalDescription.Text)
                '.Fields("TOTALVOLUME").Value = Trim(Me.txtTotalVolime.Text)
                .Fields("PACKAGE_HAZARDOUS_DESCRIPTION").Value = Trim(Me.txtPHDescription.Text)

                .Fields("SHIPPER_OWNED_UNIT").Value = Trim(Me.txtShipperOwnedUnit.Text)
                .Fields("TEMPERATURE_SETTING").Value = Trim(Me.txtTempSetting.Text)
                .Fields("MIN_TEMPERATURE").Value = Trim(Me.txtMinTemp.Text)
                .Fields("MAX_TEMPERATURE").Value = Trim(Me.txtMaxTemp.Text)
                .Fields("Kind").Value = Trim(Me.txtKind.Text)
                .Fields("Gross").Value = Trim(Me.txtGross.Text)
                .Fields("Unit_Gross").Value = Trim(Me.cboUnitGross.Text)
                .Fields("CONTAINER_TYPE").Value = Trim(Me.txtContainerType.Text)

                .Fields("CTN_CARGO_MEASUREMENT").Value = Trim(Me.txtMeas.Text)
                .Fields("UNIT_MEASUREMENT").Value = Trim(Me.cboUnitVolume.Text)

                '  ----ngay 21-10-07
                If Me.chkReceiveDate.Checked = True Then
                    .Fields("CARGO_RECEVING_DATE").Value = Me.DateTimePicker.Text
                Else
                    .Fields("CARGO_RECEVING_DATE").Value = ""
                End If




                .Fields("Week").Value = Trim(WeekOfYear)
                If Me.txtReeferDegree.Visible = True Then
                    .Fields("ReeferDegree").Value = Trim(Me.txtReeferDegree.Text)
                End If

                .Fields("Note").Value = Trim(Me.txtNote.Text)
                .Update()
            End With
            rs.Close()
            'thêm vào Cargo Marks

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHOUSE_MARKS "
            strQuery = strQuery & "WHERE BLH_Id = '" & rsHBL.Fields("BLH_ID").Value.ToString & "'  "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouseMarks_ID").Value = NewId()
                    '.Fields("CargoMarks_ID").Value = mCargoMarks_ID
                    '.Fields("Cargo_ID").Value = strCargo_ID
                    .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString
                End If
                .Fields("MARKS").Value = Trim(Me.txtCargoMarks.Text)
                .Update()
            End With
            rs.Close()

            'Thêm Vào cargo remarks

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHOUSE_REMARKS "
            strQuery = strQuery & "WHERE BLH_Id = '" & rsHBL.Fields("BLH_ID").Value.ToString & "'  "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouseRemarks_ID").Value = NewId()

                    '.Fields("CargoRemarks_ID").Value = mCargoRemarks_ID

                    '.Fields("Cargo_ID").Value = strCargo_ID
                    .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString
                End If
                .Fields("CARGO_REMARKS").Value = Trim(Me.txtCargoRemarks.Text)
                .Update()
            End With
            rs.Close()
            rsHBL.MoveNext()
        End While

        Return True
Err_Renamed:
        msgbox(err.description)
    End Function
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        Dim indexBill As Integer
        Dim rsSeal As New ADODB.Recordset
        Dim strQuerySeal As String

        If Me.dgdDetailBillOfLading.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading.CurrentRow.Index
            indexBill = Me.dgdDetailBillOfLading.CurrentRow.Index
        End If
        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            'thêm vào Cargo Description
            If mStatus = "Edit" Then
                'CopyValues("CARGO_DESCRIPTION", "BL_ID", FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text))
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGO_DESCRIPTION "
            strQuery = strQuery & "WHERE (BL_ID = '" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' AND BL_Id <> '" & DefaultValue & "') "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    '.Fields("CargoHouse_Description_ID").Value = NewId()
                    .Fields("Cargo_Description_ID").Value = NewId()
                    .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "}"
                End If
                mCargoDesc_ID = .Fields("Cargo_Description_ID").Value
                .Fields("DESCRIPTION").Value = Trim(Me.txtDescription.Text)
                .Update()
            End With
            rs.Close()

            'thêm vào cargo 
            If mStatus = "Edit" Then
                'CopyValues("Cargo", "Cargo_Id", mCargo_ID)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Cargo "
            strQuery = strQuery & "WHERE Cargo_Id = '" & mCargo_ID & "' AND Cargo_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Cargo_ID").Value = NewId()

                    .Fields("BL_Id").Value = "{" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "}"

                    '.Fields("PACKAGES_ID").Value = "{" & FindValueID(Me.cboPackages, Me.cboPackages.Text) & "}"
                End If
                strCargo_ID = .Fields("Cargo_Id").Value
                .Fields("CARGO_SEQUENCE").Value = Trim(Me.txtCargoSequence.Text)
                .Fields("CTN_ID").Value = "{" & FindValueID(Me.cboCTN_NO, Me.cboCTN_NO.Text) & "}"
                SealId = "{" + FindValueID(Me.cboSealNo, Me.cboSealNo.Text.Trim) + "}"
                '---- them seal vao csdl

                strQuerySeal = "SELECT * "
                strQuerySeal = strQuerySeal & "FROM Seal "
                strQuerySeal = strQuerySeal & "WHERE SealNo = '" & Me.cboSealNo.Text.Trim & "' and continued=1"
                rsSeal.Open(strQuerySeal, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rsSeal
                    If rsSeal.EOF Then
                        .AddNew()
                        SealId = NewId()
                        .Fields("Seal_ID").Value = SealId
                        .Fields("SealNo").Value = Me.cboSealNo.Text.Trim
                        '.Fields("PACKAGES_ID").Value = "{" & FindValueID(Me.cboPackages, Me.cboPackages.Text) & "}"
                        rsSeal.Update()
                    Else
                        If mStatus <> "Edit" Then
                            DisplayMessage(True, "please check Seal number.")
                            Return
                        End If

                    End If

                End With
                rsSeal.Close()
                .Fields("SEAL_ID").Value = SealId
                '---------------
                '9 seal no.
                '--9 seal no
                .Fields("Seal_no2").Value = Me.txtSeal_no2.Text
                .Fields("seal_no3").Value = Me.txtSeal_no3.Text
                .Fields("Seal_no4").Value = Me.txtSeal_no4.Text
                .Fields("seal_no5").Value = Me.txtSeal_no5.Text
                .Fields("seal_no6").Value = Me.txtSeal_no6.Text

                .Fields("seal_no7").Value = Me.txtSeal_no7.Text
                .Fields("seal_no8").Value = Me.txtSeal_no8.Text
                .Fields("seal_no9").Value = Me.txtSeal_no9.Text

                '--------------


                .Fields("Cargo_Desc_ID").Value = mCargoDesc_ID
                .Fields("CARGO_GROSS_WEIGHT").Value = Me.txtTotalGrossW.Text
                .Fields("NUMBER_OF_PACKAGES").Value = Me.txtTotalPackage.Text

                .Fields("TEMPERATURE_ID").Value = Me.txttempID.Text

                .Fields("Amount").Value = Me.txtAmount.Text

                .Fields("TARIFF").Value = Trim(Me.txtTariff.Text)
                .Fields("HS_CODE").Value = Trim(Me.txtHsCode.Text)
                .Fields("IMO_CLASS").Value = Trim(Me.txtImoClass.Text)
                .Fields("IMO_UN_NO").Value = Trim(Me.txtImoUnNo.Text)
                .Fields("IMO_PAGE").Value = Trim(Me.txtIMOPage.Text)
                .Fields("FLash_Point").Value = Trim(Me.txtFlashPoint.Text)
                .Fields("EMS").Value = Trim(Me.txtEMS.Text)

                .Fields("Vent").Value = Trim(Me.txtVent.Text)
                .Fields("CTN_STATUS").Value = UCase(Trim(Me.txtCTNStatus.Text))

                .Fields("COMMODITY_GROUP").Value = Trim(Me.txtCommodityGroup.Text)
                .Fields("COMMODITY").Value = Trim(Me.txtCommodity.Text)
                .Fields("CARGO_GROSS_CUBE").Value = Trim(Me.txtCargoGrossCube.Text)
                .Fields("CARGO_NET_WEIGHT").Value = Trim(Me.txtNetweight.Text)
                .Fields("CARGO_GROSS_WEIGHT").Value = Trim(Me.txtTotalGrossW.Text)

                .Fields("MFAG").Value = Trim(Me.txtMFAG.Text)
                .Fields("TECHNICAL_DESCRIPTION").Value = Trim(Me.txtTachnicalDescription.Text)
                ' .Fields("TOTALVOLUME").Value = Trim(Me.txtTotalVolime.Text)
                .Fields("PACKAGE_HAZARDOUS_DESCRIPTION").Value = Trim(Me.txtPHDescription.Text)

                .Fields("SHIPPER_OWNED_UNIT").Value = Trim(Me.txtShipperOwnedUnit.Text)
                .Fields("TEMPERATURE_SETTING").Value = Trim(Me.txtTempSetting.Text)
                .Fields("MIN_TEMPERATURE").Value = Trim(Me.txtMinTemp.Text)
                .Fields("MAX_TEMPERATURE").Value = Trim(Me.txtMaxTemp.Text)

                .Fields("CONTAINER_TYPE").Value = Trim(Me.txtContainerType.Text)

                .Fields("Kind").Value = Trim(Me.txtKind.Text)
                .Fields("Kind_Code").Value = Trim(Me.txtCodeKind.Text)

                .Fields("Gross").Value = Trim(Me.txtGross.Text)
                .Fields("Unit_Gross").Value = Trim(Me.cboUnitGross.Text)

                .Fields("CTN_CARGO_MEASUREMENT").Value = Trim(Me.txtMeas.Text)
                .Fields("UNIT_MEASUREMENT").Value = Trim(Me.cboUnitVolume.Text)
                '  ----ngay 21-10-07
                If Me.chkReceiveDate.Checked = True Then
                    .Fields("CARGO_RECEVING_DATE").Value = Me.DateTimePicker.Text
                Else
                    .Fields("CARGO_RECEVING_DATE").Value = ""
                End If

                .Fields("Week").Value = Trim(WeekOfYear)
                If Me.txtReeferDegree.Visible = True Then
                    .Fields("ReeferDegree").Value = Trim(Me.txtReeferDegree.Text)
                End If

                .Fields("Note").Value = Trim(Me.txtNote.Text)
                .Update()
            End With
            rs.Close()
            'thêm vào Cargo Marks
            If mStatus = "Edit" Then
                'CopyValues("CARGO_MARKS", "BL_Id", FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim))
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGO_MARKS "
            strQuery = strQuery & "WHERE BL_Id = '" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "' AND BL_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoMarks_ID").Value = NewId()
                    .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "}"
                    '.Fields("Cargo_ID").Value = strCargo_ID
                End If
                mCargoMarks_ID = .Fields("CargoMarks_ID").Value
                .Fields("MARKS").Value = Trim(Me.txtCargoMarks.Text)
                .Update()
            End With
            rs.Close()

            'Thêm Vào cargo remarks
            If mStatus = "Edit" Then
                'CopyValues("CARGO_REMARKS", "BL_Id", FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim))
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGO_REMARKS "
            strQuery = strQuery & "WHERE BL_Id = '" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "' AND BL_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoRemarks_ID").Value = NewId()
                    .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "}"
                    '.Fields("Cargo_ID").Value = strCargo_ID
                End If
                mCargoRemarks_ID = .Fields("CargoRemarks_ID").Value.ToString
                .Fields("CARGO_REMARKS").Value = Trim(Me.txtCargoRemarks.Text)
                .Update()
            End With
            rs.Close()
            If mStatus = "Add" Then
                InsertHouseBill()
                Me.txtCargoSequence.Text = 1
                DisplayMessage(True, "Container has Added.")
            End If
            InsertContainerMNG()
            '-----------------
            Me.dgdDetailBillOfLading.Enabled = True

            Me.fraCargoGoods.Enabled = True
            'Me.cmdPrice.Enabled = False
            Me.lblDescription.Enabled = True
            Me.txtDescription.Enabled = True
            If mStatus = "Edit" Then
                Me.TabCargo.Visible = False
                mStatus = "Normal"
            End If

            'Me.cmdOK.Enabled = False
            Dim CountContainer As Integer = 0
            For i As Integer = 0 To Me.dgdDetailBillOfLading.RowCount - 1
                If Me.dgdDetailBillOfLading.Item("ContainerType", i).Value.ToString = Me.txtContainerType.Text And Me.dgdDetailBillOfLading.Item("BL_ID", i).Value.ToString.Trim = FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) Then
                    CountContainer += 1
                End If
            Next
            QueryDetailBillOfLading("And CARGO.BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "'", , index)
            ' update lai price
            Dim strSQL As String
            strSQL = "Update FREIGHT_CHARGE_Master Set Quantity = " & CountContainer & " Where BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' And Container_Type='" & Me.txtContainerType.Text.Trim & "'"
            UpdateQuantity(strSQL)
        End If
        'Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))

        reText(mStatus)
        blnUpdated = True
        Exit Sub
Err_Renamed:
        msgbox(err.description)
        'Resume
    End Sub
    Public Sub UpdateQuantity(ByVal strSQL As String)

        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strSQL
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryBillOflading(ByRef dt As DataTable)
        On Error GoTo Err
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------

        strQuery = "Select Vessel.Vessel,SailingSchedule.Voyno,BL_NO,PORT_OF_DISCHARGE_NAME "
        strQuery &= " From (((BillOflading LEFT JOIN ContainerOutboundNotify On BillOflading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID) "
        strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
        strQuery &= " Where BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' And BillOfLading.Continued=1"
        'strQuery = MakeQueryDetailBillOfLading(argCriteria, index)
        'End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------

        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(dt)
        Exit Sub
Err:
        msgbox(err.description)
    End Sub
    Sub InsertContainerMNG() 'master Cargo
        On Error GoTo Err
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim dt As New DataTable
        'lay du lieu trong bang Billoflading IB de vao dt
        QueryBillOfLading(dt)
        strQuery = "SELECT * "
        strQuery = strQuery & " FROM ContainerManagerment  Where Container_no='" & Me.cboCTN_NO.Text.Trim & "' And Continued=1 Order by UpdateTime DESC "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            DisplayMessage(True, "Container: " + Me.cboCTN_NO.Text.Trim + " không tồn tại trong các ICD, xin vui lòng kiểm tra lại!!!")
            If rs.State = ADODB.ObjectStateEnum.adStateOpen Then
                rs.Close()
                Exit Sub
            End If
        End If
        rs.MoveFirst()
        With rs
            .Fields("Cargo_ID").Value = strCargo_ID
            .Fields("BL_NO_Outbound").Value = dt.Rows(0).Item("BL_NO").ToString
            .Fields("Port_Of_Discharge").Value = dt.Rows(0).Item("PORT_OF_DISCHARGE_NAME").ToString
            .Fields("Vessel_Outbound").Value = dt.Rows(0).Item("Vessel").ToString
            .Fields("VoyNo_Outbound").Value = dt.Rows(0).Item("Voyno")
            '.Fields("Arrival_Date").Value = dt.Rows(0).Item("ETA").ToString
            '.Fields("DisCharge_Date").Value = dt.Rows(0).Item("DisChargeDate")
            .Update()
        End With
        rs.Close()
        Exit Sub
Err:
        msgbox(err.description)
    End Sub
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strBillOfLadingId As String
        If mStatus = "Add" Then
            Dim rs As New ADODB.Recordset
            Dim strSQL As String
            strSQL = "Select * From Cargo where CTN_ID='" & CtainerID & "' And BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' And Continued=1"
            rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                strMsg = "This Container had already had in this Bill! "
                CheckData = False
            End If
            strBillOfLadingId = DefaultValue
        End If
        'If Len(Me.txtClauseOfService.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Clause Of Service is invalid."
        '    Me.txtClauseOfService.Focus()
        'End If
        If Len(Me.cboCTN_NO.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Container No. is invalid."
            Me.cboCTN_NO.Focus()
        End If
        If Len(Me.cboSealNo.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Seal No. is invalid. "
            Me.cboSealNo.Focus()
        End If
        If Len(Me.txtAmount.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Amount is invalid. "
            Me.txtAmount.Focus()
        End If
        If Len(Me.txtGross.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Gross is invalid."
            Me.txtGross.Focus()
        End If
        If Me.cboUnitGross.FindStringExact(Me.cboUnitGross.Text) = -1 Then
            CheckData = False
            strMsg = strMsg & "The Unit Gross is invalid."
            Me.cboUnitGross.Focus()
        End If
        If Len(Me.txtMeas.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Meas is invalid."
            Me.txtMeas.Focus()
        End If

        If Me.cboUnitVolume.FindStringExact(Me.cboUnitVolume.Text) = -1 Then
            CheckData = False
            strMsg = strMsg & "The Unit Volume is invalid. Please check again."
            Me.cboUnitVolume.Focus()
        End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function
#Region "Xu ly Mnu View"
    Private Sub smnuDisplayAmount_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayAmount.Click
        Me.smnuDisplayAmount.Checked = Not Me.smnuDisplayAmount.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayClauseOfService_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayClauseOfService.Click
        Me.smnuDisplayClauseOfService.Checked = Not Me.smnuDisplayClauseOfService.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayContainersNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayContainersNo.Click
        Me.smnuDisplayContainersNo.Checked = Not Me.smnuDisplayContainersNo.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayContainerType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayContainerType.Click
        Me.smnuDisplayContainerType.Checked = Not Me.smnuDisplayContainerType.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayGross_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayGross.Click
        Me.smnuDisplayGross.Checked = Not Me.smnuDisplayGross.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayKind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayKind.Click
        Me.smnuDisplayKind.Checked = Not Me.smnuDisplayKind.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayMeas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayMeas.Click
        Me.smnuDisplayMeas.Checked = Not Me.smnuDisplayMeas.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayNote.Click
        Me.smnuDisplayNote.Checked = Not Me.smnuDisplayNote.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayReceiveDate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayReceiveDate.Click
        Me.smnuDisplayReceiveDate.Checked = Not Me.smnuDisplayReceiveDate.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayReeferDegree_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayReeferDegree.Click
        Me.smnuDisplayReeferDegree.Checked = Not Me.smnuDisplayReeferDegree.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplaySealNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplaySealNo.Click
        Me.smnuDisplaySealNo.Checked = Not Me.smnuDisplaySealNo.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUnitGross_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUnitGross.Click
        Me.smnuDisplayUnitGross.Checked = Not Me.smnuDisplayUnitGross.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUnitMeas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUnitMeas.Click
        Me.smnuDisplayUnitMeas.Checked = Not Me.smnuDisplayUnitMeas.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUserId_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub

    'Private Sub smnuCopyBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCopyBill.Click

    '    If Not IsNothing(oTableBillOfLading) Then
    '        mCopy = True
    '        Me.QueryDetailBillOfLading()

    '    Else
    '        DisplayMessage(True, "There is no data in the Grid B/L.")
    '    End If


    'End Sub
#End Region

    Private Sub smnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Me.dgdDetailBillOfLading.RowCount = 0 Then
            Return
        End If
        If Not IsNothing(oTableDetailBillOfLading) Then
            Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
            Dim indexBill As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index

            Approve = Me.dgdDetailBillOfLading.Item("Approve", index).Value
            EditTable = Me.dgdDetailBillOfLading.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLadingMaster", "Edit") And Not Me.dgdDetailBillOfLading.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdDetailBillOfLading.Enabled = False

                QueryBookingSurcharge()
                Me.TabCargo.Visible = True
                ReFormat()
                QueryContainer()
                mCargo_ID = Me.dgdDetailBillOfLading.Item("Cargo_Id", index).Value.ToString

                mCargoDesc_ID = Me.dgdDetailBillOfLading.Item("Cargo_Description_ID", index).Value.ToString
                Me.QuerySealNo()
                mStatus = "Edit"
                reText(mStatus)
                SetMenu(False)
                RefreshData(index)

                Me.fraCargoGoods.Enabled = True
                QueryPrice(, index)
                ' lay seal tu csdl

                Me.txtDescription.Enabled = True
                Me.lblDescription.Enabled = True

                Me.cmdOK.Enabled = True
                Me.txtWeek.Text = WeekOfYear()
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Else
            DisplayMessage(True, "No item in the Grid.")
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, "No item in the Grid.")
    End Sub
    Private Sub RefreshDataPrice(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        Me.cboItems.Text = Me.dgdPrice.Item("Items", index).ToString
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & "RefreshData")
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading.Item("ClauseOfservice", index).Value.ToString
        Me.cboCTN_NO.Text = Trim(Me.dgdDetailBillOfLading.Item("Containers_No", index).Value.ToString)
        Me.cboSealNo.Text = Me.dgdDetailBillOfLading.Item("SealNo", index).Value.ToString
        '--9 seal no
        Me.txtSeal_no2.Text = Me.dgdDetailBillOfLading.Item("Seal_No2", index).Value.ToString
        Me.txtSeal_no3.Text = Me.dgdDetailBillOfLading.Item("Seal_No3", index).Value.ToString
        Me.txtSeal_no4.Text = Me.dgdDetailBillOfLading.Item("Seal_No4", index).Value.ToString
        Me.txtSeal_no5.Text = Me.dgdDetailBillOfLading.Item("Seal_No5", index).Value.ToString
        Me.txtSeal_no6.Text = Me.dgdDetailBillOfLading.Item("Seal_No6", index).Value.ToString
        Me.txtSeal_no7.Text = Me.dgdDetailBillOfLading.Item("Seal_No7", index).Value.ToString
        Me.txtSeal_no8.Text = Me.dgdDetailBillOfLading.Item("Seal_No8", index).Value.ToString
        Me.txtSeal_no9.Text = Me.dgdDetailBillOfLading.Item("Seal_No9", index).Value.ToString
        '------------------------------------

        Me.txtContainerType.Text = Me.dgdDetailBillOfLading.Item("ContainerType", index).Value.ToString
        Me.txtVent.Text = Me.dgdDetailBillOfLading.Item("Vent", index).Value.ToString
        Me.txtAmount.Text = Me.dgdDetailBillOfLading.Item("Amount", index).Value.ToString
        kind = Me.dgdDetailBillOfLading.Item("Kind", index).Value.ToString
        Me.txtKind.Text = kind
        Me.txtCodeKind.Text = Me.dgdDetailBillOfLading.Item("Kind_Code", index).Value.ToString
        Me.txtGross.Text = Me.dgdDetailBillOfLading.Item("Gross", index).Value.ToString
        Me.cboUnitGross.Text = Me.dgdDetailBillOfLading.Item("UnitGross", index).Value.ToString
        Me.txtMeas.Text = Me.dgdDetailBillOfLading.Item("Meas", index).Value.ToString
        Me.cboUnitVolume.Text = Me.dgdDetailBillOfLading.Item("UnitMeas", index).Value.ToString
        If Me.dgdDetailBillOfLading.Item("ReceiveDate", index).Value.ToString <> "" Then
            Me.DateTimePicker.Text = Me.dgdDetailBillOfLading.Item("ReceiveDate", index).Value.ToString
            Me.chkReceiveDate.Checked = True
        Else
            Me.chkReceiveDate.Checked = False
        End If

        Me.txtWeek.Text = Me.dgdDetailBillOfLading.Item("Week", index).Value.ToString

        If Me.dgdDetailBillOfLading.Item("ReeferDegree", index).Value.ToString <> "" Then
            Me.txtReeferDegree.Text = Me.dgdDetailBillOfLading.Item("ReeferDegree", index).Value.ToString
            Me.txtReeferDegree.Visible = True
        End If

        Me.txtNote.Text = Me.dgdDetailBillOfLading.Item("Note", index).Value.ToString
        Me.txtDescription.Text = Me.dgdDetailBillOfLading.Item("Description", index).Value.ToString
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.txtCargoMarks.Text = Me.dgdDetailBillOfLading.Item("CargoMarks", index).Value.ToString
        Me.txtCargoRemarks.Text = Me.dgdDetailBillOfLading.Item("CARGO_REMARKS", index).Value.ToString
        Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading.Item("CARGO_SEQUENCE", index).Value.ToString
        Me.txtCargoGrossCube.Text = Me.dgdDetailBillOfLading.Item("CARGO_GROSS_CUBE", index).Value.ToString
        Me.txtTempSetting.Text = Me.dgdDetailBillOfLading.Item("TEMPERATURE_SETTING", index).Value.ToString
        Me.txttempID.Text = Me.dgdDetailBillOfLading.Item("TEMPERATURE_ID", index).Value.ToString
        Me.txtMinTemp.Text = Me.dgdDetailBillOfLading.Item("MIN_TEMP", index).Value.ToString
        Me.txtMaxTemp.Text = Me.dgdDetailBillOfLading.Item("MAX_TEMP", index).Value.ToString

        Me.txtNetweight.Text = Me.dgdDetailBillOfLading.Item("CARGO_NET_WEIGHT", index).Value.ToString
        Me.txtCommodity.Text = Me.dgdDetailBillOfLading.Item("COMMODITY", index).Value.ToString
        Me.txtShipperOwnedUnit.Text = Me.dgdDetailBillOfLading.Item("SHIPPER_OWNED_UNIT", index).Value.ToString
        Me.txtCommodityGroup.Text = Me.dgdDetailBillOfLading.Item("COMMODITY_GROUP", index).Value.ToString


        Me.txtEMS.Text = Me.dgdDetailBillOfLading.Item("EMS", index).Value.ToString
        Me.txtTariff.Text = Me.dgdDetailBillOfLading.Item("TARIFF", index).Value.ToString
        Me.txtHsCode.Text = Me.dgdDetailBillOfLading.Item("HS_CODE", index).Value.ToString
        Me.txtImoClass.Text = Me.dgdDetailBillOfLading.Item("IMO_CLASS", index).Value.ToString
        Me.txtIMOPage.Text = Me.dgdDetailBillOfLading.Item("IMO_PAGE", index).Value.ToString
        Me.txtImoUnNo.Text = Me.dgdDetailBillOfLading.Item("IMO_UN_NO", index).Value.ToString
        Me.txtFlashPoint.Text = Me.dgdDetailBillOfLading.Item("FLASH_POINT", index).Value.ToString
        Me.txtMFAG.Text = Me.dgdDetailBillOfLading.Item("MFAG", index).Value.ToString
        Me.txtTachnicalDescription.Text = Me.dgdDetailBillOfLading.Item("TECHNICAL_DESCRIPTION", index).Value.ToString
        Me.txtPHDescription.Text = Me.dgdDetailBillOfLading.Item("PACKAGE_HAZARDOUS_DESCRIPTION", index).Value.ToString
        Me.txtCTNStatus.Text = Me.dgdDetailBillOfLading.Item("CTN_STATUS", index).Value.ToString
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & "RefreshData")
    End Sub
    Private Sub RefreshDataBill(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading.Item("ClauseOfService", index).Value.ToString
        Me.cboCTN_NO.Text = Me.dgdDetailBillOfLading.Item("ContainersNo", index).Value.ToString
        Me.cboSealNo.Text = Me.dgdDetailBillOfLading.Item("SealNo", index).Value.ToString
        Me.txtContainerType.Text = Me.dgdDetailBillOfLading.Item("ContainerType", index).Value.ToString
        Me.txtAmount.Text = Me.dgdDetailBillOfLading.Item("Amount", index).Value.ToString
        kind = Me.dgdDetailBillOfLading.Item("Kind", index).Value.ToString

        Me.txtKind.Text = kind
        Me.txtGross.Text = Me.dgdDetailBillOfLading.Item("Gross", index).Value.ToString
        Me.cboUnitGross.Text = Me.dgdDetailBillOfLading.Item("UnitGross", index).Value.ToString
        Me.txtMeas.Text = Me.dgdDetailBillOfLading.Item("Meas", index).Value.ToString
        Me.cboUnitVolume.Text = Me.dgdDetailBillOfLading.Item("UnitMeas", index).Value.ToString
        Me.DateTimePicker.Text = Me.dgdDetailBillOfLading.Item("ReceiveDate", index).Value.ToString
        Me.txtWeek.Text = Me.dgdDetailBillOfLading.Item("Week", index).Value.ToString
        Me.txtReeferDegree.Text = Me.dgdDetailBillOfLading.Item("ReeferDegree", index).Value.ToString
        Me.txtNote.Text = Me.dgdDetailBillOfLading.Item("Note", index).Value.ToString
        Me.txtDescription.Text = Me.dgdDetailBillOfLading.Item("Description", index).Value.ToString

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & "RefreshData")
    End Sub

    Private Sub smnuDisplayWeek_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayWeek.Click
        Me.smnuDisplayWeek.Checked = Not Me.smnuDisplayWeek.Checked
        UpdateFrame()
    End Sub

    Private Sub frmListCargoMaster_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub frmListCargoMaster_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub

    Private Sub frmListCargo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'ReFormat()
    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub
    Private Sub smnuInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuInsert.Click
        On Error GoTo Err_Renamed
        Dim index As Integer = 0
        If Me.dgdDetailBillOfLading.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading.CurrentRow.Index
            'Me.dgdPrice.Rows.Clear()
            'Me.txtContainerKindP.Text = "" 'Me.dgdDetailBillOfLading.Item("Kind", index).Value.ToString
            'Me.txtContainerNoP.Text = "" 'Me.dgdDetailBillOfLading.Item("ContainersId", index).Value.ToString
            'Me.txtBillOfLadingP.Text = "" 'Me.dgdDetailBillOfLading.Item("Bill_No", index).Value.ToString
            'Me.fraPrice.Enabled = False
        End If

        If mStatus = "Normal" And UserRight("frmListBillOfLadingMaster", "Add") Then


            Dim dt As New DataTable
            QueryBooking(dt)
            If dt.Rows.Count > 0 Then
                Me.txtReeferDegree.Text = dt.Rows(0).Item("Cold").ToString
                Me.txtVent.Text = dt.Rows(0).Item("Vent").ToString
            End If

            QueryPrice()
            QueryContainer()
            SetMenu(False)

            Me.txtCTNStatus.Text = "F"
            Me.txtReeferDegree.Text = ""
            Me.txtShipperOwnedUnit.Text = "N"
            Me.txtCargoRemarks.Text = "COC"
            Me.txtTariff.Text = Me.txtClauseOfService.Text

            mCargo_ID = DefaultValue
            mCargoMarks_ID = DefaultValue
            mCargoRemarks_ID = DefaultValue
            mCargoDesc_ID = DefaultValue
            mCargoHouseDesc_ID = DefaultValue
            mStatus = "Add"
            Me.TabCargo.Visible = True
            ReFormat()
            'If Me.txtCargoSequence.Text = "0" Then
            Me.txtDescription.Enabled = True
            'End If

            Me.lblDescription.Enabled = True
            'Me.txtClauseOfService.Enabled = True
            Me.dgdDetailBillOfLading.Enabled = False
            reText(mStatus)
            Me.cmdOK.Enabled = True
            ' lay Seal tu csdl
            Me.QuerySealNo()

            'If gBillOfLadingNumber = "No BillNumber." Then
            Me.txtBillOfLadingId.Text = Me.cboBillofLading.Text.Trim
            'End If
            Me.cboCTN_NO.Text = ""
            Me.cboSealNo.Text = ""
            Me.txtAmount.Text = "0"
            Me.txtGross.Text = "0"
            Me.txtMeas.Text = "0"
            Me.txtWeek.Text = ""
            Me.txtReeferDegree.Text = ""
            Me.txtNote.Text = ""

            'If Not gBillOfLadingNumber = "No BillNumber." Then
            '    QueryBillOfLading(, , 0)
            'End If

            'Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading.RowCount + 1
            Me.txtCargoSequence.Text = 1 'Me.dgdDetailBillOfLading.RowCount + 1
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Me.txtWeek.Text = WeekOfYear()

        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.TabCargo.Visible = False
        Me.txtDescription.Enabled = False
        Me.lblDescription.Enabled = False
        Me.txtClauseOfService.Enabled = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdDetailBillOfLading.Enabled = True
        Me.cmdOK.Enabled = False
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub
    Public Function totalGross() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading) Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                total = total + oTableDetailBillOfLading.Rows(i).Item("Gross")
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function
    Public Function totalVolume() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading) Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                total = total + oTableDetailBillOfLading.Rows(i).Item("CTN_CARGO_MEASUREMENT")
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function

    Public Function totalPackage() As Double
        On Error GoTo Err_Renamed
        Dim i, total As Integer
        total = 0
        If Not IsNothing(oTableDetailBillOfLading) Then
            For i = 0 To oTableDetailBillOfLading.Rows.Count - 1
                total = total + oTableDetailBillOfLading.Rows(i).Item("Amount")
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        msgbox(err.description)
    End Function

    Private Sub smnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
     Me.dgdDetailBillOfLading.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdDetailBillOfLading.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryDetailBillOfLading(" And Cargo.BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "'")
    End Sub

    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryDetailBillofLadingList As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        strQuery = "Select count(*) cnt from FREIGHT_CHARGE_Master WHERE BL_Id = '" & Me.dgdDetailBillOfLading.Item("BL_ID", index).Value.ToString & "' And Continued=1 And Container_type='" & Me.dgdDetailBillOfLading.Item("ContainerType", index).Value.ToString.Trim & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The Containers can not be removed. There are transactions that relate to this Price Bill Of Lading.")
            Exit Sub
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading.Item("Approve", index)) Then
            If Me.dgdDetailBillOfLading.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading.Item("Editable", index)) Then
            If Not Me.dgdDetailBillOfLading.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingMaster", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container No: " & Me.dgdDetailBillOfLading.Item("Containers_NO", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillofLadingList = "Select * from Cargo where" + " Cargo_Id= '" & Me.dgdDetailBillOfLading.Item("Cargo_Id", index).Value.ToString & "'"
                rs.Open(strQueryDetailBillofLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                Me.dgdDetailBillOfLading.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdDetailBillOfLading.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub
    Public Sub DeleteRowP(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        If Not IsNothing(Me.dgdPrice.Item("ApproveP", index).Value) Then
            If Me.dgdPrice.Item("ApproveP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPrice.Item("EditableP", index).Value) Then
            If Not Me.dgdPrice.Item("EditableP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingMaster", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Detail of Price: " & Me.dgdPrice.Item("Items", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from FREIGHT_CHARGE_Master where FREIGHT_CHARGES_ID='" & Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                Me.dgdPrice.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdPrice.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub cboBillofLading_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillofLading.Leave
        On Error GoTo Err_Renamed
        Dim strSql As String
        Me.cboBillofLading.Text = Trim(UCase(Me.cboBillofLading.Text))
        strSql = "Select BL_No as BL_No From BillOfLading Where Continued=1"
        If Me.cboBillofLading.FindStringExact(Me.cboBillofLading.Text) = -1 Then
            Me.cboBillofLading.Text = FindBetter_new("bl_no", strSql, Me.cboBillofLading.Text)
            If Me.cboBillofLading.FindStringExact(Me.cboBillofLading.Text) = -1 Then
                DisplayMessage(True, "The B/L is invalid, please check and correct it.")
                Me.cboBillofLading.Focus()
            End If
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub


    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillofLading.TextChanged
        'If Me.cboBillofLading.FindStringExact(Me.cboBillofLading.Text) = -1 Then
        '    Me.cboBillofLading.SelectedIndex = 0
        'End If
    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtSHIPPERNAME.Text)
    '        If Me.txtSHIPPERNAME.Text <> "" Then
    '            Select Case cboBillofLading.Text
    '                Case "BillOfLadingId"
    '                    QueryBillOfLading("AND ( BillOfLading.BillOfLadingId LIKE '" & strFilter & "') " & mFilter)
    '                Case "ShipperName"
    '                    QueryBillOfLading("AND (Shipper.Name LIKE '" & strFilter & "') " & mFilter)
    '                Case "ConsigneeName"
    '                    QueryBillOfLading("AND (Consignee.Name LIKE '" & strFilter & "') " & mFilter)
    '                Case "NotifyName"
    '                    QueryBillOfLading("AND (Notify.Name LIKE '" & strFilter & "') " & mFilter)
    '            End Select
    '        Else
    '            QueryBillOfLading(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '       msgbox(err.description)
    '    End Sub

    Private Sub dgdDetailBillOfLading_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDetailBillOfLading.CellClick
        Dim index As Integer
        If Me.oTableDetailBillOfLading.Rows.Count > 0 Then
            index = Me.dgdDetailBillOfLading.CurrentRow.Index
        Else
            Exit Sub
        End If


        'Me.txtBillOfLadingP.Text = Me.dgdDetailBillOfLading.Item("BILL_NO", index).Value.ToString
        'Me.txtContainerNoP.Text = Me.dgdDetailBillOfLading.Item("ContainersId", index).Value.ToString
        'Me.txtContainerKindP.Text = Me.dgdDetailBillOfLading.Item("ContainerType", index).Value.ToString
        CtainerID_P = Me.dgdDetailBillOfLading.Item("Container_ID", index).Value.ToString

        Me.txtBillOfLadingId.Text = Me.dgdDetailBillOfLading.Item("Bill_No", index).Value.ToString
        Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading.Item("ClauseOfservice", index).Value.ToString

        'QueryPrice(, index)
    End Sub

    Private Sub dgdDetailBillOfLading_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDetailBillOfLading.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdDetailBillOfLading.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index 'Me.BindingContext(oTableDetailBillOfLading).Position
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdDetailBillOfLading.Columns(ColIndex).Name = "Approve" And Me.dgdDetailBillOfLading.CurrentCellAddress.Y = index Then
            Call ApproveDetailBillOfLading()
            QueryDetailBillOfLading(" And Cargo.BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "'", , index)
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub



    Private Sub smnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '-------------
        objUserSetting.SetCParm("frmListCargoMaster.txtContainerNo", Me.cboCTN_NO.Text)
        objUserSetting.SetCParm("frmListCargoMaster.txtSealNo", Me.cboSealNo.Text)

        objUserSetting.SetCParm("frmListCargoMaster.cboContainerType", Me.txtContainerType.Text)
        objUserSetting.SetCParm("frmListCargoMaster.txtAmount", Me.txtAmount.Text)
        objUserSetting.SetCParm("frmListCargoMaster.txtkind", Me.txtKind.Text)

        objUserSetting.SetCParm("frmListCargoMaster.txtGross", Me.txtGross.Text)
        objUserSetting.SetCParm("frmListCargoMaster.cboUnitGross", Me.cboUnitGross.Text)


        objUserSetting.SetCParm("frmListCargoMaster.txtMeas", Me.txtMeas.Text)
        objUserSetting.SetCParm("frmListCargoMaster.cboUnitVolume", Me.cboUnitVolume.Text)
        objUserSetting.SetCParm("frmListCargoMaster.txtWeek", Me.txtWeek.Text)
        objUserSetting.SetCParm("frmListCargoMaster.txtReeferDegree", Me.txtReeferDegree.Text)

        objUserSetting.SetCParm("frmListCargoMaster.txtNote", Me.txtNote.Text)
        objUserSetting.SetCParm("frmListCargoMaster.txtDescription", Me.txtDescription.Text)

        objUserSetting.SetCParm("frmListCargoMaster.txtClauseOfService", Me.txtClauseOfService.Text)

        '----------------

    End Sub

    Private Sub smnuPaste_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '-------------
        Me.cboCTN_NO.Text = objUserSetting.GetCParm("frmListCargoMaster.txtContainerNo")
        Me.cboSealNo.Text = objUserSetting.GetCParm("frmListCargoMaster.txtSealNo")

        Me.txtContainerType.Text = objUserSetting.GetCParm("frmListCargoMaster.cboContainerType")
        Me.txtAmount.Text = objUserSetting.GetCParm("frmListCargoMaster.txtAmount")
        Me.txtKind.Text = objUserSetting.GetCParm("frmListCargoMaster.txtkind")


        Me.txtGross.Text = objUserSetting.GetCParm("frmListCargoMaster.txtGross")
        Me.cboUnitGross.Text = objUserSetting.GetCParm("frmListCargoMaster.cboUnitGross")


        Me.txtMeas.Text = objUserSetting.GetCParm("frmListCargoMaster.txtMeas")
        Me.cboUnitVolume.Text = objUserSetting.GetCParm("frmListCargoMaster.cboUnitVolume")
        Me.txtWeek.Text = objUserSetting.GetCParm("frmListCargoMaster.txtWeek")
        Me.txtReeferDegree.Text = objUserSetting.GetCParm("frmListCargoMaster.txtReeferDegree")

        Me.txtNote.Text = objUserSetting.GetCParm("frmListCargoMaster.txtNote")
        Me.txtDescription.Text = objUserSetting.GetCParm("frmListCargoMaster.txtDescription")

        Me.txtClauseOfService.Text = objUserSetting.GetCParm("frmListCargoMaster.txtClauseOfService")

        '----------------
    End Sub


    Private Sub txtAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        If txtAmount.Text = "" Then
            txtAmount.Text = 0
        End If
        If Not Char.IsNumber(Me.txtAmount.Text) Then
            DisplayMessage(True, "The Description is invalid. Please check again.")
            Me.txtAmount.Focus()
        Else
            If CDbl(Me.txtAmount.Text) < 0 Then
                DisplayMessage(True, "The Description is invalid. Please check again.")
                Me.txtAmount.Focus()
            End If
        End If
        If Me.txtAmount.Text.Trim = "0" Then
            Me.txtCTNStatus.Text = "E"
        ElseIf CDbl(Me.txtAmount.Text) > 0 Then
            Me.txtCTNStatus.Text = "F"
        Else
            Me.txtCTNStatus.Text = ""
        End If
        'Me.txtAmount.Text = FormatString(CDbl(Me.txtAmount.Text))
    End Sub

    Private Sub txtGross_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGross.Leave
        If txtGross.Text = "" Then
            txtGross.Text = 0
        End If
        If Not Char.IsNumber(Me.txtGross.Text) Then
            DisplayMessage(True, "The Gross is invalid. Please check again.")
            Me.txtGross.Focus()
            'Else
            '    If CDbl(Me.txtGross.Text) < 0 Then
            '        DisplayMessage(True, "The Gross is invalid. Please check again.")
            '        Me.txtGross.Focus()
            '    End If
        Else
            'Me.txtGross.Text = FormatString(CDbl(Me.txtGross.Text))
        End If
    End Sub


    'Private Sub cmdCancelP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.fraPrice.Visible = False
    '    mStatusP = "Normal"
    '    Me.cmdEdit.Enabled = True
    'End Sub

    '    Private Sub cmdEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdEdit.Click
    '        On Error GoTo Err_Renamed
    '        Dim Approve, EditTable, UsrRight As Boolean
    '        Dim index As Integer = Me.BindingContext(oTablePrice).Position
    '        If index >= 0 Then
    '            Approve = oTablePrice.Rows(index).Item("Approve")
    '            EditTable = oTablePrice.Rows(index).Item("Editable")
    '            mStatusP = "Normal"
    '            If mStatusP = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLadingMaster", "Edit") Then
    '                Me.dgdPrice.Enabled = False
    '                Me.cmdEdit.Enabled = False
    '                mStatusP = "Edit"
    '                RefreshDataPrice(index)
    '            Else
    '                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '       msgbox(err.description)
    '    End Sub

    'Private Sub cmdDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDelete.Click
    '    Dim selectedRowCount As Integer = _
    '         Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
    '    If selectedRowCount > 0 Then
    '        Dim sb As New System.Text.StringBuilder()
    '        Dim i As Integer
    '        For i = 0 To selectedRowCount - 1
    '            DeleteRowP(Me.dgdPrice.SelectedRows(i).Index)
    '        Next i
    '    End If
    '    Me.QueryPrice()
    'End Sub
    Function InsertPrice_House(ByVal indexbill As Integer) As Boolean
        Dim rsHBL, rs As New ADODB.Recordset
        Dim strQuery As String = "SELECT * "
        strQuery = strQuery & "FROM BILLOFLADING_HOUSE "
        strQuery = strQuery & "WHERE BL_ID = '" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "'"
        rsHBL.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rsHBL.EOF Then
            Return False
        End If
        rsHBL.MoveFirst()
        While Not rsHBL.EOF
            strQuery = "Select * from FREIGHT_CHARGE_House where CARGOHOUSE_ID in "
            strQuery = strQuery & "(select CARGOHOUSE_ID from Cargo_House where BLH_ID='" & rsHBL.Fields("BLH_ID").Value.ToString & "')"
            'strQuery = strQuery & (" And  <>'" & DefaultValue & "'")
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs


                .AddNew()
                .Fields("FREIGHT_CHARGES_House_ID").Value = NewId()
                Dim temp As String

                temp = "{" & Trim(Me.dgdDetailBillOfLading.Item("Cargo_ID", indexbill).Value.ToString) & "}"
                .Fields("PAYABLE_AT_ID").Value = "{" & FindValueID(Me.cboPayableCode, Me.cboPayableCode.Text) & "}"
                '.Fields("CTN_ID").Value = "{" & Me.dgdDetailBillOfLading.Item("Container_ID", indexbill).Value.ToString & "}"
                .Fields("CargoHouse_ID").Value = temp
                .Fields("CHARGE_ID").Value = "{" & FindValueID(Me.cboItems, Me.cboItems.Text) & "}"

                'mPrice_ID = .Fields("FREIGHT_CHARGES_ID").Value

                .Fields("IG_CODE").Value = Me.txtIGCode.Text

                '.Fields("AMOUNT").Value = Me.txtAmount.Text
                .Fields("PREPAID_COLLECT").Value = Me.cboPrepaidOrCollect.Text
                .Fields("PAYER_CODE").Value = Me.txtPayerCode.Text
                '.Fields("QUANTITY").Value = Me.txtQuantity.Text
                '.Fields("RATE_OF_FR_CH").Value = Me.txtRateFreightCharge.Text
                .Fields("UNIT_OF_QUANTITY").Value = Me.txtQuantityUnit.Text
                .Fields("Currency").Value = Me.cboCurrency.Text
                .Fields("AMOUNT").Value = Me.txtUnitPrice.Text
                .Update()

            End With
            rs.Close()
            rsHBL.MoveNext()
        End While
    End Function
    Private Sub cmdOKP_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOKP.Click
        On Error GoTo Err_Renamed
        If mStatusP = "Add" Or mStatusP = "Edit" Then

            If Me.cboItems.FindStringExact(Me.cboItems.Text) = -1 Then
                DisplayMessage(True, "The Item is invalid. ")
                Me.cboItems.Focus()
                Exit Sub
            End If
            If Me.cboCurrency.FindStringExact(Me.cboCurrency.Text) = -1 Then
                DisplayMessage(True, "The Currency is invalid. ")
                Me.cboCurrency.Focus()
                Exit Sub
            End If
            If Len(Me.txtUnitPrice.Text) = 0 Then
                DisplayMessage(True, "The Price is invalid. ")
                Me.cboCurrency.Focus()
                Exit Sub
            End If
            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.dgdPrice.RowCount > 0 Then
                index = Me.dgdPrice.CurrentRow.Index()
            End If

            Dim indexBill As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index

            'If indexBill >= 0 Then
            '    Cargo_ID = Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString
            'Else
            '    'Cargo_ID = DefaultValue
            '    Exit Sub
            'End If
            strQuery = "Select * from FREIGHT_CHARGE_Master where charge_ID='" & FindValueID(Me.cboItems, Me.cboItems.Text) & "'"
            strQuery = strQuery & " and BL_id='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "' And Continued=1 And Container_Type='" & Me.cboContainerType.Text.Trim & "' and upper(Prepaid_Collect)='" & UCase(Me.cboPrepaidOrCollect.Text.Trim) & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            If Not rs.EOF And mStatusP = "Add" Then
                DisplayMessage(True, "This Item Had Added ")
                Exit Sub
            End If
            rs.Close()
            strQuery = "Select * from FREIGHT_CHARGE_Master where FREIGHT_CHARGES_ID='" & FreightChargeID & "'And Continued=1 "
            ' strQuery = strQuery & " And BL_ID='" & BillID & "'"

            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


            With rs
                If mStatusP = "Add" Then
                    .AddNew()
                    .Fields("FREIGHT_CHARGES_ID").Value = NewId()
                    Dim temp As String

                    'temp = "{" & Trim(Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString) & "}"

                    '.Fields("CTN_ID").Value = "{" & Me.dgdDetailBillOfLading.Item("Container_ID", indexBill).Value.ToString & "}"
                    .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "}"

                End If

                .Fields("PAYABLE_AT_ID").Value = "{" & FindValueID(Me.cboPayableCode, Me.cboPayableCode.Text) & "}"
                .Fields("CHARGE_ID").Value = "{" & FindValueID(Me.cboItems, Me.cboItems.Text) & "}"
                mPrice_ID = .Fields("FREIGHT_CHARGES_ID").Value

                .Fields("IG_CODE").Value = Me.txtIGCode.Text

                '.Fields("AMOUNT").Value = Me.txtAmount.Text
                .Fields("CONTAINER_TYPE").Value = Me.cboContainerType.Text

                .Fields("PREPAID_COLLECT").Value = Me.cboPrepaidOrCollect.Text
                .Fields("POP").Value = Me.txtPOP.Text.Trim

                .Fields("PAYER_CODE").Value = Me.txtPayerCode.Text
                .Fields("QUANTITY").Value = Me.txtQuantity.Text
                .Fields("UnitPriceSale").Value = Me.txtChargeRateSale.Text
                .Fields("UNIT_OF_QUANTITY").Value = Me.txtQuantityUnit.Text
                .Fields("Currency").Value = Me.cboCurrency.Text
                .Fields("AMOUNT").Value = Me.txtUnitPrice.Text
                .Fields("Quantity").Value = Me.txtQuantity.Text

                .Update()

                'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
                'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

            End With
            rs.Close()
            'If mStatus = "Add" Then
            '    InsertPrice_House(indexBill)
            'End If

            '-----------------

            mStatusP = "Normal"
            ReFreshFreight(False)
            Me.dgdPrice.Enabled = True

            Me.cmdOKP.Enabled = False
            QueryPrice(, indexBill)
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
        'Resume
    End Sub

    Public Sub ApprovePrice()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim rs As New ADODB.Recordset
        Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
        Dim strQuery As String
        If Not Me.dgdPrice.Item("EditableP", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPrice(, index)
        Else
            ' strQuery = "Select * from FREIGHT_CHARGE_Master where" + " BillOfLadingId= '" & oTablePrice.Rows(index).Item("BillOfLadingId").ToString & "' AND Cargo_ID='" & oTablePrice.Rows(index).Item("Cargo_ID").ToString & "' AND Items='" & oTablePrice.Rows(index).Item("Items").ToString & "'"
            strQuery = "select * from FREIGHT_CHARGE_Master where FREIGHT_CHARGES_ID='" & Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    'Private Sub dgdPrice_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPrice.CellClick
    '    If Me.dgdPrice.RowCount = 0 Then
    '        Me.ctmnuDel.Enabled = False
    '        Me.ctmnuEdit.Enabled = False
    '    Else
    '        Me.ctmnuDel.Enabled = True
    '        Me.ctmnuEdit.Enabled = True
    '    End If
    'End Sub

    Private Sub dgdPrice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPrice.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        'MsgBox(Me.dgdPrice.CurrentCellAddress.X)
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPrice.Columns(ColIndex).Name = "ApproveP" And Me.dgdPrice.CurrentCellAddress().Y = RowIndex Then
            Call ApprovePrice()
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub DateTimePicker_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker.Leave
        Me.txtWeek.Text = WeekOfYear()
    End Sub
    Private Sub DateTimePicker_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker.ValueChanged
        Me.txtWeek.Text = WeekOfYear()
    End Sub
    Public Function WeekOfYear() As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        If Me.DateTimePicker.Text <> "" Then
            WeekOfYear = myCal.GetWeekOfYear(CDate(DateTimePicker.Text), myCWR, myFirstDOW)
        Else
            WeekOfYear = 0
        End If
        Exit Function
Err_Renamed:
        msgbox(err.description)
        'Resume
    End Function

    Private Sub cboBillofLading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillofLading.SelectedIndexChanged
        Dim Bill_ID As String

        Bill_ID = FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text)
        'MsgBox(Me.dgdDetailBillOfLading.Item("Cargo_id", 0).Value.ToString)
        mFilter = " And Cargo.BL_ID='" & Bill_ID & "'"
        QueryDetailBillOfLading(mFilter, 14)
        If Bill_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "select ContainerOutboundNotify.SERVICECONTRACT as SERVICECONTRACT,SHIPPER_1,Shipper.Shipper_ID,BillOFLading.Shipper_ID,BillOflading.BL_ID as BL_ID" & _
            " from ((SHIPPER LEFT JOIN  BillOfLading ON BillofLading.Shipper_ID=Shipper.Shipper_ID) " & _
            " LEFT JOIN ContainerOutboundNotify On ContainerOutBoundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) where BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "'"

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Bill")

            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.txtSHIPPERNAME.Text = table.Rows(0).Item("SHIPPER_1").ToString
                Me.txtClauseOfService.Text = table.Rows(0).Item("SERVICECONTRACT").ToString
                Me.txtTariff.Text = Me.txtClauseOfService.Text
                Me.txtBillOfLadingId.Text = Me.cboBillofLading.Text
                'BillID = Bill_ID
            End If

            strQuery = "Select PLACE_OF_DESTINATION_CODE from BILLOFLADING " & _
                       " Where BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text.Trim) & "'"
            Dim tbl As New DataTable
            tbl = ReadTable(strQuery)
            If tbl.Rows.Count > 0 Then
                If IsDBNull(tbl.Rows(0).Item("PLACE_OF_DESTINATION_CODE")) = False Then
                    QueryPriceStandard(tbl.Rows(0).Item("PLACE_OF_DESTINATION_CODE").ToString)
                End If
            End If

            'Me.txtBillOfLadingId.Text = BillID

        End If
    End Sub
    Private Sub TabCargo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCargo.SelectedIndexChanged
        On Error GoTo Err_named
        If UCase(TabCargo.SelectedTab.Name) = "TABCONTAINERPRICE" Then
            If Not UserRight("frmListBillOfLadingMaster", "Execute") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                TabCargo.SelectedIndex = 0
                Exit Sub
            Else
                Dim index As Integer
                DisplayMessage(True, "Lưu ý: bạn phải nhập xong Container, sau đó bạn mới nhập giá cho từng loại Container!")
                If (Me.dgdDetailBillOfLading.RowCount > 0) Then
                    index = Me.dgdDetailBillOfLading.CurrentRow.Index
                    QueryContainer()
                    'QueryPrice(" And Container_Type='" & Me.cboContainerType.Text.Trim & "'", index, )
                    QueryPrice(, index)
                End If
            End If
        End If
        Exit Sub
Err_named:
        msgbox(err.description)
    End Sub


    Private Sub TabControl1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCargo.VisibleChanged
        Me.fraBillNo.Visible = Me.TabCargo.Visible
        Me.fraTotal.Visible = Me.TabCargo.Visible
        Me.txtDescription.Visible = Me.TabCargo.Visible
        Me.lblDescription.Visible = Me.TabCargo.Visible
        ' Me.cmdCancel.Visible = Me.TabCargo.Visible
        ' Me.cmdOK.Visible = Me.TabCargo.Visible
        Me.cboBillofLading.Enabled = Not Me.TabCargo.Visible

        Me.cmdCancel.Visible = TabCargo.Visible
        Me.cmdOK.Visible = TabCargo.Visible


        Exit Sub
        ' Me.fraPrice.Visible = Me.TabCargo.Visible
    End Sub

    Private Sub cboCTN_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCTN_NO.SelectedIndexChanged
        On Error GoTo Err_Named
        Dim ContainerID As String
        ContainerID = FindValueID(Me.cboCTN_NO, Me.cboCTN_NO.Text)
        If ContainerID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable

            '----------------
            strQuery = "select * from Container where CTN_ID='" & ContainerID & "'"

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Bill")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                CtainerID = table.Rows(0).Item("CTN_ID").ToString
                Me.txtContainerType.Text = table.Rows(0).Item("CTN_SIZE_TYPE").ToString
                Reefer_Degree()
            End If

            ''''''''''''''''''''''''''''''''''''''''

        End If
        Exit Sub
Err_Named:
        msgbox(err.description)
    End Sub



    Private Sub ctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAdd.Click
        On Error GoTo Err_named
        If mCargo_ID = DefaultValue Then
            MsgBox("Please, close this windows, and open it again!")
            Me.TabCargo.SelectedIndex = 0
            Return
        End If
        mStatusP = "Add"
        FreightChargeID = DefaultValue

        ReFreshFreight(True)

        'Me.cmdOKP.Text = "Add"
        Exit Sub
Err_named:
        msgbox(err.description)
    End Sub

    Private Sub ctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEdit.Click
        On Error GoTo errname
        Dim index As Integer

        If Me.dgdPrice.Rows.Count > 0 Then
            index = Me.dgdPrice.CurrentRow.Index
        Else
            Exit Sub
        End If
        If Not IsNothing(Me.dgdPrice.Item("ApproveP", index).Value) And UserRight("frmListBillOfLadingMaster", "Edit") Then
            If Me.dgdPrice.Item("ApproveP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        mStatusP = "Edit"
        Me.cboContainerType.Enabled = True
        ReFreshFreight(True)
        Me.cboContainerType.Text = Me.dgdPrice.Item("ContainertypeP", index).Value.ToString
        FreightChargeID = Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString
        Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString.Trim
        Me.cboItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
        Me.cboPayableCode.Text = FindIDValue(Me.cboPayableCode, Me.dgdPrice.Item("PAYABLE_AT_ID", index).Value.ToString)
        Me.cboCurrency.Text = Me.dgdPrice.Item("Currency", index).Value.ToString
        Me.cboPrepaidOrCollect.Text = Me.dgdPrice.Item("PREPAID_COLLECT", index).Value.ToString
        'Me.txtQuantity.Text = Me.dgdPrice.Item("QUANTITY", index).Value.ToString
        Me.txtQuantityUnit.Text = Me.dgdPrice.Item("UNIT_OF_QUANTITY", index).Value.ToString
        'Me.txtRateFreightCharge.Text = Me.dgdPrice("RATE_OF_FR_CH", index).Value.ToString
        Me.txtPayerCode.Text = Me.dgdPrice("PAYER_CODE", index).Value.ToString
        Me.txtUnitPrice.Text = Me.dgdPrice.Item("AMOUNTP", index).Value.ToString
        Me.txtChargeRateSale.Text = Me.dgdPrice.Item("UnitPriceSale", index).Value.ToString
        Me.txtIGCode.Text = Me.dgdPrice.Item("IG_CODE", index).Value.ToString


        Exit Sub
errname:
        msgbox(err.description)
    End Sub

    Private Sub ctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel.Click
        Dim selectedRowCount As Integer = _
  Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowP(Me.dgdPrice.SelectedRows(i).Index)
            Next i
        End If
        Dim index As Integer = 0
        If Me.dgdDetailBillOfLading.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading.CurrentRow.Index
        End If
        QueryPrice(, index)
    End Sub




    Private Sub smnuDisplayMarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMarks.Click
        Me.smnuDisplayMarks.Checked = Not Me.smnuDisplayMarks.Checked
        UpdateFrame()

    End Sub

    Private Sub smnuDisplayRemarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRemarks.Click

    End Sub

    Private Sub smnuDisplayHS_CODE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayHS_CODE.Click
        Me.smnuDisplayHS_CODE.Checked = Not Me.smnuDisplayHS_CODE.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayIMO_CLASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayIMO_CLASS.Click
        Me.smnuDisplayIMO_CLASS.Checked = Not Me.smnuDisplayIMO_CLASS.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayIMO_UN_NO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayIMO_UN_NO.Click
        Me.smnuDisplayIMO_UN_NO.Checked = Not Me.smnuDisplayIMO_UN_NO.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayIMO_PAGE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayIMO_PAGE.Click
        Me.smnuDisplayIMO_PAGE.Checked = Not Me.smnuDisplayIMO_PAGE.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayFLASH_POINT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFLASH_POINT.Click
        Me.smnuDisplayFLASH_POINT.Checked = Not Me.smnuDisplayFLASH_POINT.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayEMS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayEMS.Click
        Me.smnuDisplayMarks.Checked = Not Me.smnuDisplayMarks.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayMFAG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMFAG.Click
        Me.smnuDisplayEMS.Checked = Not Me.smnuDisplayEMS.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTEChNICAL_DESCRIPTION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTECHNICAL_DESCRIPTION.Click
        Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked = Not Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Click
        Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked = Not Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTARIFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTARIFF.Click
        Me.smnuDisplayTARIFF.Checked = Not Me.smnuDisplayTARIFF.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTotalgross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTotalgross.Click
        Me.smnuDisplayTotalgross.Checked = Not Me.smnuDisplayTotalgross.Checked
        UpdateFrame()

    End Sub

    Private Sub TotalPakages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTotalPakages.Click
        Me.smnuDisplayTotalPakages.Checked = Not Me.smnuDisplayTotalPakages.Checked
        UpdateFrame()

    End Sub

    Sub ReFreshFreight(ByVal b As Boolean)
        On Error GoTo Err_named
        Me.cboContainerType.Enabled = b
        Me.cboPriceStandard.Enabled = b
        Me.cboItems.Enabled = b
        Me.cboPayableCode.Enabled = b
        Me.cboCurrency.Enabled = b
        Me.cboPrepaidOrCollect.Enabled = b
        'Me.txtQuantity.Enabled = b
        Me.txtQuantityUnit.Enabled = b
        ' Me.txtRateFreightCharge.Enabled = b
        Me.txtPayerCode.Enabled = b
        Me.txtUnitPrice.Enabled = b
        Me.txtIGCode.Enabled = b
        Me.cmdOKP.Enabled = b
        Me.txtPOP.Enabled = b
        Me.txtQuantity.Enabled = b
        Me.cmdOKPrice.Enabled = False
        If mStatusP = "Add" Then
            Me.cmdOKPrice.Enabled = True
        End If
        Exit Sub
Err_named:
        msgbox(err.description)
    End Sub
    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelP.Click
        On Error GoTo Err_named
        mStatusP = "Normal"
        ReFreshFreight(False)
        Exit Sub
Err_named:
        msgbox(err.description)
    End Sub

    Private Sub cboContainerType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboContainerType.SelectedIndexChanged
        On Error GoTo Err_Named
        Dim Bill As String
        Bill = FindValueID(Me.cboContainerType, Me.cboContainerType.Text).Trim
        If Bill <> "" Then
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            Dim strSQL As String = "select Count(Container_TYPE) As Num,Container_Type from Cargo "
            strSQL &= " Where BL_ID='" & Bill & "' And Continued=1 "
            strSQL &= " And Container_Type='" & Me.cboContainerType.Text.Trim & "' Group By Container_TYPE "
            Dim CmdSelect As New SqlClient.SqlCommand(strSQL, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Unit")
            table = dset.Tables(0)
            'If table.Rows.Count > 0 Then
            '    Me.txtUnit.Text = table.Rows(0).Item("Num").ToString
            'End If

            Dim index As Integer = 0
            If Me.dgdDetailBillOfLading.Rows.Count > 0 Then
                index = 0 'Me.dgdDetailBillOfLading.CurrentRow.Index

            End If
            QueryPrice(, index)
        End If

        If Me.TabCargo.Visible = True Then 'UCase(Me.TabCargo.SelectedTab.Name) = "TABCONTAINERPRICE" Then

            Dim CountContainer As Integer = 0
            For i As Integer = 0 To Me.dgdDetailBillOfLading.RowCount - 1
                If Me.dgdDetailBillOfLading.Item("ContainerType", i).Value.ToString = Me.cboContainerType.Text And Me.dgdDetailBillOfLading.Item("BL_ID", i).Value.ToString.Trim = FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) Then
                    CountContainer += 1
                End If
            Next
            Me.txtQuantity.Text = CountContainer
        End If

        Exit Sub
Err_Named:
        DisplayMessage(True, Err.Description & "Container Type")
    End Sub


    Private Sub txtTotalGrossW_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalGrossW.TextChanged
        If IsNumeric(Me.txtTotalGrossW.Text) Then
            Me.txtTotalGrossW.Text = FormatString(CDbl(Me.txtTotalGrossW.Text))
        End If
    End Sub

    Private Sub txtMeas_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeas.Leave
        If txtMeas.Text = "" Then
            txtMeas.Text = 0
        End If
        If Not Char.IsNumber(Me.txtMeas.Text) Then
            DisplayMessage(True, "The Meas is invalid. Please check again.")
            Me.txtMeas.Focus()
        Else
            Me.txtMeas.Text = FormatString(CDbl(Me.txtMeas.Text))
        End If
    End Sub

    Private Sub txtTotalVolime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalVolime.TextChanged
        If IsNumeric(Me.txtTotalVolime.Text) Then
            Me.txtTotalVolime.Text = FormatString(CDbl(Me.txtTotalVolime.Text))
        End If
    End Sub

    Private Sub MenuStrip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip.ItemClicked

    End Sub

    Private Sub txtReeferDegree_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReeferDegree.Leave
        Me.txtTempSetting.Text = Me.txtReeferDegree.Text
    End Sub

    Private Sub cboPayableCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPayableCode.Leave
        On Error GoTo Err_Renamed
        Dim strSql, Port_code As String
        Me.cboPayableCode.Text = Trim(UCase(Me.cboPayableCode.Text))
        strSql = "Select Port_code as code From Port Where Continued=1"
        If Me.cboPayableCode.FindStringExact(Me.cboPayableCode.Text) = -1 Then
            Me.cboPayableCode.Text = FindBetter_new("code", strSql, Me.cboPayableCode.Text)
            If Me.cboPayableCode.FindStringExact(Me.cboPayableCode.Text) = -1 Then
                DisplayMessage(True, "The Port is invalid, please check and correct it.")
                Me.cboPayableCode.Focus()
            End If
        End If
        Me.cboPayableCode_SelectedIndexChanged(sender, e)
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub cboPayableCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPayableCode.SelectedIndexChanged
        On Error GoTo Err_Renamed
        Dim Port_ID As String
        Dim i As Integer
        Port_ID = FindValueID(Me.cboPayableCode, Me.cboPayableCode.Text)
        For i = 0 To oTablePort.Rows.Count - 1
            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
                Me.txtPOP.Text = oTablePort.Rows(i).Item("Port").ToString
                Exit For
            End If
        Next

        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub cboSealNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSealNo.Leave
        On Error GoTo Err_Renamed
        Dim strSql, Port_code As String
        'Me.cboSealNo.Text = Trim(UCase(Me.cboSealNo.Text))
        'strSql = "Select sealNo as SealNo From Seal Where Continued=1"
        'If Me.cboSealNo.FindStringExact(Me.cboSealNo.Text) = -1 Then
        '    Me.cboSealNo.Text = FindBetter_new("SealNo", strSql, Me.cboSealNo.Text)
        '    If Me.cboSealNo.FindStringExact(Me.cboSealNo.Text) = -1 Then
        '        DisplayMessage(True, "The SealNo. is invalid, please check and correct it.")
        '        Me.cboSealNo.Focus()
        '    End If
        'End If
        'Reefer_Degree()
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub cboSealNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSealNo.SelectedIndexChanged

    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = frmListCargoMaster.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryDetailBillOfLading("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdDetailBillOfLading.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdDetailBillOfLading, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryPriceStandard(ByVal _mPort As String)
        On Error GoTo Err_Renamed
        Dim id As String
        Dim value As String
        Dim strSQL As String

        strSQL = "Select Port.Port_Code ,PriceStandard.CTN_TYPE " & _
                 "From (PriceStandard INNER JOIN Port ON PriceStandard.Port_ID=port.Port_ID) " & _
                 "INNER JOIN Charge ON PriceStandard.Charge_ID=Charge.Charge_ID " & _
                 "Where port.Port_Code='" & _mPort & "' " & _
                 "Group By Port.Port_Code,PriceStandard.CTN_TYPE "
        Dim tbl As DataTable
        tbl = ReadTable(strSQL)
        If tbl.Rows.Count > 0 Then
            Me.cboPriceStandard.Items.Clear()
            For i As Integer = 0 To tbl.Rows.Count - 1
                Me.cboPriceStandard.Items.Add(tbl.Rows(i).Item("Port_Code").ToString & " - " & tbl.Rows(i).Item("CTN_TYPE").ToString)
            Next
            Me.cboPriceStandard.SelectedIndex = 0
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.description)
    End Sub

    Private Sub cmdOKPrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKPrice.Click
        Try
            If Me.cboPriceStandard.SelectedIndex = -1 Then
                MsgBox("The Price Standard is invalid")
                Return
            End If
            Dim st() As String = Me.cboPriceStandard.Text.Split("-")

            If Me.cboContainerType.Text <> st(1).Trim Then
                MsgBox("The Container Type is invalid")
                Return
            End If
            Dim strSql As String = "Select Charge.Charge_ID,Charge.Charge_Code,PriceStandard.Price,PriceStandard.CTN_TYPE,PriceStandard.Prepaid_Collect,PriceStandard.Currency " & _
                                   " From (PriceStandard INNER JOIN Charge ON Charge.Charge_ID=PriceStandard.Charge_ID) " & _
                                   " INNER JOIN Port ON Port.Port_ID=PriceStandard.Port_ID " & _
                                   " Where port.Port_Code='" & st(0).Trim & "' and PriceStandard.CTN_TYPE='" & st(1).Trim & "'"
            Dim tbl As New DataTable
            tbl = ReadTable(strSql)
            If tbl.Rows.Count > 0 Then
                For i As Integer = 0 To tbl.Rows.Count - 1
                    Dim strQuery As String
                    Dim rs As New ADODB.Recordset
                    strQuery = "Select * from FREIGHT_CHARGE_Master where charge_ID='" & tbl.Rows(i).Item("Charge_ID").ToString & "'"
                    strQuery = strQuery & " and BL_id='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' And Continued=1 And Container_Type='" & tbl.Rows(i).Item("CTN_TYPE") & "'"
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                    If Not rs.EOF And mStatusP = "Add" Then
                        'DisplayMessage(True, "This Item Had Added ")
                        rs.Close()
                    Else
                        rs.Close()
                        strQuery = "Select * from FREIGHT_CHARGE_Master where FREIGHT_CHARGES_ID='" & FreightChargeID & "'And Continued=1 "
                        ' strQuery = strQuery & " And BL_ID='" & BillID & "'"

                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                        With rs
                            If mStatusP = "Add" Then
                                .AddNew()
                                .Fields("FREIGHT_CHARGES_ID").Value = NewId()
                                .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "}"

                            End If

                            .Fields("CHARGE_ID").Value = "{" & tbl.Rows(i).Item("Charge_ID").ToString & "}"
                            'mPrice_ID = .Fields("FREIGHT_CHARGES_ID").Value

                            '.Fields("IG_CODE").Value = Me.txtIGCode.Text

                            '.Fields("AMOUNT").Value = Me.txtAmount.Text
                            .Fields("CONTAINER_TYPE").Value = tbl.Rows(i).Item("CTN_TYPE").ToString
                            '.Fields("UNIT").Value = Me.txtUnit.Text

                            .Fields("PREPAID_COLLECT").Value = tbl.Rows(i).Item("Prepaid_Collect").ToString
                            '.Fields("POP").Value = Me.txtPOP.Text.Trim

                            '.Fields("PAYER_CODE").Value = Me.txtPayerCode.Text
                            '.Fields("QUANTITY").Value = Me.txtQuantity.Text
                            '.Fields("RATE_OF_FR_CH").Value = Me.txtRateFreightCharge.Text
                            .Fields("QUANTITY").Value = 1
                            .Fields("Currency").Value = tbl.Rows(i).Item("Currency")
                            .Fields("AMOUNT").Value = tbl.Rows(i).Item("Price")
                            .Update()

                            'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
                            'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

                        End With
                        rs.Close()
                    End If
                Next
            End If
            mStatusP = "Normal"
            ReFreshFreight(False)
            Me.dgdPrice.Enabled = True

            Me.cmdOKP.Enabled = False
            QueryPrice()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdDetailBillOfLading_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDetailBillOfLading.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading)
    End Sub

    Private Sub dgdPrice_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPrice.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdPrice)
    End Sub



    Private Sub cxtsmnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSearch.Click
        Try
            If Me.dgdDetailBillOfLading.RowCount = 0 Then
                Return
            End If
            Me.grpFind.BringToFront()
            Me.grpFind.Visible = True
            Me.cboFind.Text = FindIDValue(Me.cboFind, Me.dgdDetailBillOfLading.Columns(Me.dgdDetailBillOfLading.CurrentCell.ColumnIndex).Name)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Try
            If Me.txtFind.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
                FindCombo(Me.txtFind.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdDetailBillOfLading)
            End If
            Me.grpFind.SendToBack()
            Me.grpFind.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.grpFind.Visible = False
        End Try
    End Sub

    Private Sub txtFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtMeas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeas.TextChanged

    End Sub

    Private Sub dgdDetailBillOfLading_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDetailBillOfLading.RowHeaderMouseClick
        Try
            Dim index As Integer
            If Me.dgdDetailBillOfLading.Rows.Count > 0 Then
                index = Me.dgdDetailBillOfLading.CurrentRow.Index
            Else
                Exit Sub
            End If
            Me.cboBillofLading.Text = Me.dgdDetailBillOfLading.Item("Bill_No", index).Value.ToString.Trim
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub txtCargoRemarks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCargoRemarks.Leave
        Try
            If Me.txtCargoRemarks.Text = "COC" Then
                Me.txtShipperOwnedUnit.Text = "N"
            ElseIf Me.txtCargoRemarks.Text = "SOC" Then
                Me.txtShipperOwnedUnit.Text = "Y"
            Else
                DisplayMessage(True, "You Can input only 'COC'  Or 'SOC'")
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtShipperOwnedUnit_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtShipperOwnedUnit.Leave
        Try
            If Me.txtShipperOwnedUnit.Text <> "N" And Me.txtShipperOwnedUnit.Text <> "Y" Then
                DisplayMessage(True, "You Can input Only 'N' For SOC Or 'N' For COC ")
                Me.txtShipperOwnedUnit.Text = "Y"
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub txtShipperOwnedUnit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipperOwnedUnit.TextChanged
        Try
            If Me.txtShipperOwnedUnit.Text = "N" Then
                Me.txtCargoRemarks.Text = "COC"
            ElseIf Me.txtShipperOwnedUnit.Text = "Y" Then
                Me.txtCargoRemarks.Text = "SOC"
            Else
                Me.txtCargoRemarks.Text = ""
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged

    End Sub

    Private Sub txtGross_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGross.TextChanged

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub cboItems_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboItems.Leave
        Try
            If Me.cboItems.FindStringExact(Me.cboItems.Text) = -1 Then
                MsgBox("items is Invalid, Check Again please")
                Me.cboItems.Focus()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Function outPortCode(ByVal PortID As String) As String
        Dim portcode, POL, POD, dateT, strSQL, strSQLBill As String
        Dim rs, rsBill As New ADODB.Recordset
        portcode = ""

        '--- lay du luei tu bill
        strSQLBill = "Select * From Port where Port_ID='" & PortID & "' and continued =1"
        rsBill.Open(strSQLBill, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rsBill.EOF Then
            portcode = rsBill.Fields("Port_Code").Value.ToString
        End If
        rsBill.Close()
        Return portcode

    End Function

    Function GetETD(ByVal BL_ID As String) As String
        Try
            Dim SQL As String
            SQL = " Select ETD "
            SQL &= " From ((SailingSchedule LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID )"
            SQL &= " LEFT JOIN BillOfLading On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
            SQL &= " Where BillOfLading.BL_ID='" & BL_ID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return dt.Rows(0).Item("ETD").ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Function MakeQueryPriceStandard(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryPriceStandard = strMarketSelect
        MakeQueryPriceStandard = MakeQueryPriceStandard & "From (PriceStandard INNER JOIN Port ON PriceStandard.Port_ID=port.Port_ID) " & _
                                            "INNER JOIN Charge ON PriceStandard.Charge_ID=Charge.Charge_ID "
        MakeQueryPriceStandard = MakeQueryPriceStandard & " WHERE ((PriceStandard_ID <> '" & DefaultValue & "') "

        MakeQueryPriceStandard = MakeQueryPriceStandard & "and ("
        MakeQueryPriceStandard = MakeQueryPriceStandard & "PriceStandard.Continued = 1 "
        MakeQueryPriceStandard = MakeQueryPriceStandard & ")) "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryPriceStandard = MakeQueryPriceStandard & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryPriceStandard = MakeQueryPriceStandard & strMarketOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryPriceStandard = MakeQueryPriceStandard & strMarketOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
    End Function

    Public Function QueryPriceStandardDisplay(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPriceStandard()
        Else
            strQuery = MakeQueryPriceStandard(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "ListPriceStandard")
        Dim dt As New DataTable
        dt = ds.Tables(0)
        'hien thi ra grid 
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Return dt
        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
        'Resume
    End Function
    Private Sub cboItems_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItems.SelectedIndexChanged
        Dim POLID, PODID, dateT, strSQL, strSQLBill, chargeid As String
        Dim rs, rsBill As New ADODB.Recordset

        If Me.cboContainerType.Text <> "" And Me.cboItems.Text <> "" Then
            '--- lay du luei tu bill phi OCB
            If Me.cboItems.Text = "OCB" Then
                strSQLBill = "Select * From BillOfLading where Bl_nO='" & Me.cboBillofLading.Text.Trim & "' and continued =1"
                rsBill.Open(strSQLBill, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rsBill.EOF Then
                    POLID = rsBill.Fields("PORT_OF_LOADING_ID").Value
                    PODID = rsBill.Fields("PORT_OF_DISCHARGE_ID").Value
                End If
                rsBill.Close()
                Dim ETD As Date
                If GetETD(FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text)) = "" Then
                    MsgBox("Please Check Schedule ")
                    Return
                End If
                ETD = CDate(GetETD(FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text)))
                '
                '---
                Dim Type As String
                Dim Container_Type() As String = {"GP20", "GP40", "HC45", "HC40", "RF20", "RF40", "RH40"}
                Dim FactType() As String = {"20GP", "40GP", "45HC", "40HC", "20RF", "40RF", "40RH"}

                If Me.cboContainerType.Text = "" Then
                    Return
                End If

                For i As Integer = 0 To Container_Type.Length - 1
                    If Me.cboContainerType.Text = FactType(i) Then
                        Type = "," & Container_Type(i) & " "
                        Exit For
                    End If
                Next
                strSQL = "Select [Date],DateExp,POL,POD " & Type
                strSQL &= " From FreightTariff  "
                strSQL &= " where [DATE]-1<'" & ETD & "' And DateExp+1 >'" & ETD & "' and POL = '" & outPortCode(POLID).Trim & "' and POD='" & outPortCode(PODID).Trim & "' and continued=1  "
                Dim dt As New DataTable
                dt = ReadTable(strSQL)
                If dt.Rows.Count = 0 Then
                    Return
                End If
                Me.dgdDisplayTariff.DataSource = dt
                Me.GrpDisplayTariff.Visible = True
                Me.GrpDisplayTariff.BringToFront()
                'rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If Not rs.EOF Then

                '    If Me.cboContainerType.Text = "20GP" Then
                '        Me.txtUnitPrice.Text = rs.Fields("GP20").Value
                '    ElseIf Me.cboContainerType.Text = "40GP" Then
                '        Me.txtUnitPrice.Text = rs.Fields("GP40").Value
                '    ElseIf Me.cboContainerType.Text = "40HC" Then
                '        Me.txtUnitPrice.Text = rs.Fields("HC40").Value
                '    ElseIf Me.cboContainerType.Text = "45HC" Then
                '        Me.txtUnitPrice.Text = rs.Fields("HC45").Value
                '    ElseIf Me.cboContainerType.Text = "20RF" Then
                '        Me.txtUnitPrice.Text = rs.Fields("RF20").Value
                '    ElseIf Me.cboContainerType.Text = "40RF" Then
                '        Me.txtUnitPrice.Text = rs.Fields("RF40").Value
                '    ElseIf Me.cboContainerType.Text = "40RH" Then
                '        Me.txtUnitPrice.Text = rs.Fields("RH40").Value
                '    Else
                '        DisplayMessage(True, "Please check tariff.!")
                '        Me.txtUnitPrice.Text = ""
                '    End If

                '    rs.Close()
                'End If
            Else
                ' gia cua surcharge

                strSQLBill = "Select * From BillOfLading where Bl_nO='" & Me.cboBillofLading.Text.Trim & "' and continued =1"
                rsBill.Open(strSQLBill, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rsBill.EOF Then
                    POLID = rsBill.Fields("PORT_OF_LOADING_ID").Value
                    PODID = rsBill.Fields("PORT_OF_DISCHARGE_ID").Value
                End If
                rsBill.Close()
                chargeid = "" 'khởi gán giá trị
                '---charge code
                strSQLBill = "Select * From charge where charge_code='" & Me.cboItems.Text.Trim & "' and continued =1"
                rsBill.Open(strSQLBill, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rsBill.EOF Then
                    chargeid = rsBill.Fields("charge_id").Value
                End If
                rsBill.Close()
                '--------------
                If chargeid = "" Then
                    Return
                End If
                Dim dt As New DataTable
                dt = QueryPriceStandardDisplay(" and PriceStandard.Charge_ID='" & chargeid & "' And PriceStandard.CTN_TYPE='" & Me.cboContainerType.Text & "'")
                If dt.Rows.Count = 0 Then
                    Return
                End If
                Me.dgdDisplayTariff.DataSource = dt
                Me.GrpDisplayTariff.Visible = True
                Me.GrpDisplayTariff.BringToFront()
                'rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If Not rs.EOF Then
                '    Me.txtUnitPrice.Text = rs.Fields("Price").Value
                'Else
                '    DisplayMessage(True, "Please check surcharge.!")
                '    Me.txtUnitPrice.Text = ""
                'End If
                'rs.Close()
            End If
        End If
    End Sub

    Private Sub cmdApproveSalesurCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApproveSalesurCharge.Click
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim SQL As String
            SQL = " Update FreightSale Set Approve=1"
            SQL &= " Where ContainerOutboundNotifyID In (Select ContainerOutboundNotifyID From BillOfLading Where BL_ID='" & FindValueID(Me.cboBillofLading, Me.cboBillofLading.Text) & "' )"
            Dim cmd As New SqlClient.SqlCommand("", Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
            DisplayMessage(True, "Freight (Approve)")
            Me.QueryBookingSurcharge()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub TabCargoInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabCargoInfo.Click

    End Sub

    Private Sub txtUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrice.TextChanged
        Me.txtChargeRateSale.Text = Me.txtUnitPrice.Text
    End Sub

    Private Sub txtCodeKind_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodeKind.Leave
        Try
            Dim rs As New ADODB.Recordset
            Dim strSQL As String
            If Me.txtCodeKind.Text <> "" Then
                strSQL = "Select * From KIND where KINDCODE='" & Me.txtCodeKind.Text.Trim & "'"
                rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    Me.txtKind.Text = rs.Fields("KIND").Value.ToString
                End If
                rs.Close()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtCodeKind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodeKind.TextChanged

    End Sub

    Private Sub dgdBookingSurcharge_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBookingSurcharge.CellContentClick

    End Sub

    Private Sub dgdBookingSurcharge_ColumnAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dgdBookingSurcharge.ColumnAdded

    End Sub

    Private Sub dgdBookingSurcharge_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdBookingSurcharge.DataSourceChanged

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.GrpDisplayTariff.Visible = False
    End Sub



    Private Sub GrpDisplayTariff_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrpDisplayTariff.MouseDown
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub GrpDisplayTariff_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrpDisplayTariff.MouseMove
        If Mdown Then
            Me.GrpDisplayTariff.Left = (e.X - X) + Me.GrpDisplayTariff.Left
            Me.GrpDisplayTariff.Top = (e.Y - Y) + Me.GrpDisplayTariff.Top
        End If
    End Sub

    Private Sub GrpDisplayTariff_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GrpDisplayTariff.MouseUp
        If Mdown Then
            Mdown = False
            Me.GrpDisplayTariff.Left = (e.X - X) + Me.GrpDisplayTariff.Left
            Me.GrpDisplayTariff.Top = (e.Y - Y) + Me.GrpDisplayTariff.Top
        End If
    End Sub

    Private Sub chkReceiveDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReceiveDate.CheckedChanged
        If Me.chkReceiveDate.Checked = True Then
            Me.DateTimePicker.Enabled = True
        Else
            Me.DateTimePicker.Enabled = False
        End If
    End Sub

End Class
