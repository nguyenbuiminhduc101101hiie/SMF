Imports System.Globalization
Public Class UsrControlCargoHouse

    Dim mStatus, mStatusP, mFilter As String
    Public blnUpdated, mCopy, Check_CTNChanged As Boolean
    Public mCargo_ID, mPrice_ID, mCargoMarks_ID, mCargoRemarks_ID, mCargoDesc_ID, mCargoHouseDesc_ID As String
    '------------------
    Public oTableBillOfLading_House As DataTable
    Public dsBillOfLading_House As New DataSet
    Public CtainerID, CtainerID_P, FreightChargeHouseID, strCargoHouse_ID, strCargo_Desc_ID As String
    '------------------
    Public oTableDetailBillOfLading_House As DataTable
    Public dsDetailBillOfLading_House As New DataSet
    '------------------
    Public oTableCopyBillOfLading_House As DataTable
    Public dsCopyBillOfLading_House As New DataSet
    '------------------
    Public oTablePrice As DataTable
    Public dsPrice As New DataSet


    Const strPriceSelect As String = "SELECT  FREIGHT_CHARGE_House.BLH_ID as CargoHouse_id," & _
"FREIGHT_CHARGE_House.Charge_ID as Charge_ID,  FREIGHT_CHARGE_House.FREIGHT_CHARGES_House_ID as FREIGHT_CHARGES_House_ID, " & _
"FREIGHT_CHARGE_House.Currency as Currency, Charge.Charge_Code as Charge_Code,FREIGHT_CHARGE_House.POP," & _
           "Amount,FREIGHT_CHARGE_House.PAYABLE_AT_ID as PAYABLE_AT_ID,QUANTITY,UNIT_OF_QUANTITY, " & _
           " RATE_OF_FR_CH,PREPAID_COLLECT,PAYER_CODE,IG_CODE,Container_Type,Unit," & _
            "FREIGHT_CHARGE_House.Continued, " & _
            "FREIGHT_CHARGE_House.Editable, " & _
           "FREIGHT_CHARGE_House.Approve, " & _
           "FREIGHT_CHARGE_House.UserId, " & _
           "FREIGHT_CHARGE_House.Updatetime "
    Const strPriceOrder As String = _
        " ORDER BY FREIGHT_CHARGE_House.UpdateTime Desc "

    Const strDetailBillOfLading_HouseSelect As String = "SELECT  BillOfLading_House.BLH_Id, BillOfLading_House.BLH_NO as BL_No, " & _
       "CONTAINER_NO,SEALNO as Seal_NO,Cargo_House.SEAL_ID as SEAL_ID ,seal_no2,seal_no3,seal_no4,seal_no5,seal_no6,seal_no7,seal_no8,seal_no9,CTN_SIZE_TYPE ," & _
       "Cargo_House.CTN_ID as CTN_ID, Cargo_House.CargoHouse_ID as CargoHouse_ID,CTN_STATUS," & _
       "Cargo_House.Amount as Amount, Cargo_House.ReeferDegree as ReeferDegree,CargoHouse_DESCRIPTION.DESCRIPTION," & _
       "Cargo_House.Kind as Kind,Cargo_House.Kind_Code as Kind_Code, CargoHouse_Marks.Marks as Marks, CargoHouse_remarks.Cargo_REMARKS as CARGO_REMARKS," & _
       "Cargo_House.Gross as Gross, CargoHouse_Description.CargoHouse_Description_ID as Cargo_Description_ID,Cargo_House.TEMPERATURE_SETTING as TEMPERATURE_SETTING," & _
       "Cargo_House.Unit_Gross as Unit_Gross,CargoHouse_marks.CargoHouseMarks_ID as CargoMarks_ID,CargoHouse_Remarks.CargoHouseRemarks_ID as CargoRemarks_ID," & _
       "Cargo_House.CARGO_GROSS_WEIGHT as CARGO_GROSS_WEIGHT,Cargo_House.NUMBER_OF_PACKAGES as NUMBER_OF_PACKAGES, Cargo_House.SHIPPER_OWNED_UNIT as SHIPPER_OWNED_UNIT, " & _
       "Cargo_House.UNIT_MEASUREMENT as UNIT_MEASUREMENT,Cargo_House.TARIFF as TARIFF,Cargo_House.HS_CODE as HS_CODE,Cargo_House.IMO_CLASS as IMO_CLASS,Cargo_House.IMO_UN_NO as IMO_UN_NO, " & _
       "Cargo_House.CARGO_RECEVING_DATE as CARGO_RECEVING_DATE,Cargo_House.EMS as EMS ,Cargo_House.MFAG as MFAG,Cargo_House.TECHNICAL_DESCRIPTION as TECHNICAL_DESCRIPTION, " & _
       "Cargo_House.Week as Week, Cargo_House.CTN_CARGO_MEASUREMENT as CTN_CARGO_MEASUREMENT, Cargo_House.IMO_PAGE as IMO_PAGE,Cargo_House.FLASH_POINT as FLASH_POINT," & _
       "Cargo_House.Note as Note, Cargo_House.PACKAGE_HAZARDOUS_DESCRIPTION as PACKAGE_HAZARDOUS_DESCRIPTION," & _
        "ContainerOutboundNotify.ServiceContract as ServiceContract," & _
        "CARGO_SEQUENCE,CARGO_GROSS_CUBE,Cargo_House.TEMPERATURE_ID,MIN_TEMPERATURE,MAX_TEMPERATURE,CARGO_NET_WEIGHT,COMMODITY,COMMODITY_GROUP," & _
        "Cargo_House.Vent," & _
       "Cargo_House.Continued, " & _
       "Cargo_House.Editable, " & _
       "Cargo_House.Approve, " & _
       "Cargo_House.UserId, " & _
       "Cargo_House.Updatetime "
    Const strDetailBillOfLading_HouseOrder1 As String = _
             " ORDER BY BL_NO  Desc "
    Const strDetailBillOfLading_HouseOrder2 As String = _
        " ORDER BY Cargo_House.UpdateTime Desc "

    Const strBillOfLading_HouseSelect As String = "SELECT BillOfLading_House.BillOfLading_HouseId as BillOfLading_HouseId,BillOfLading_House.ShipperId, Shipper.Name as ShipperName, " & _
    "BillOfLading_House.ConsigneeId, " & _
    "Consignee.Name as ConsigneeName, " & _
    "BillOfLading_House.NotifyId, " & _
    "Notify.Name as NotifyName, " & _
    "PreCarriageVessel, " & _
    "PreCarriageVoyNo, " & _
    "PlaceOfReceipt, " & _
    "BillOfLading_House.OceanVesselId, " & _
    "Vessel.Name as OceanVesselName, " & _
    "ServiceContract, " & _
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
     "BillOfLading_House.Editable as Editable, " & _
       "BillOfLading_House.Continued as Continued, " & _
        "BillOfLading_House.Approve as Approve, " & _
          "BillOfLading_House.UserId as UserId, " & _
        "BillOfLading_House.Updatetime as Updatetime"

    Const strBillOfLading_HouseOrder1 As String = _
          " ORDER BY BillOfLading_House.BillOfLading_HouseId  Desc "
    Const strBillOfLading_HouseOrder2 As String = _
        " ORDER BY BillOfLading_House.UpdateTime Desc "
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
    Public Sub ApproveDetailBillOfLading_House()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not Me.dgdDetailBillOfLading_House.Item("Editable", index).Value Or Not UserRight("frmListBillOfLadingHouse", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from Cargo_House where" + " CARGOHOUSE_ID= '" & oTableDetailBillOfLading_House.Rows(index).Item("CARGOHOUSE_ID").ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    '    Private Sub frmListCargo_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed


    '        objUserSetting.SetCParm("frmListCargoHouse.txtFCommodity", Me.txtSHIPPERNAME.Text)
    '        '-------------
    '        objUserSetting.SetCParm("frmListCargoHouse.txtContainerNo", Me.cboCTN_NO.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtSealNo", Me.cboSealNo.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.cboContainerType", Me.txtContainerType.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtAmount", Me.txtAmount.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtkind", Me.txtKind.Text)
    '        ' objUserSetting.SetCParm("frmListCargoHouse.cboKind", Me.cboKind.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.txtGross", Me.txtGross.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.cboUnitGross", Me.cboUnitGross.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.txtMeas", Me.txtMeas.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.cboUnitVolume", Me.cboUnitVolume.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtWeek", Me.txtWeek.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtReeferDegree", Me.txtReeferDegree.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.txtNote", Me.txtNote.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtDescription", Me.txtDescription.Text)

    '        'objUserSetting.SetCParm("frmListCargoHouse.txtClauseOfService", Me.txtClauseOfService.Text)

    '        ''''''''''''''''''''''''''----------------

    '        objUserSetting.SetCParm("frmListCargoHouse.txtTARIFF", Me.txtTariff.Text)
    '        '-------------
    '        objUserSetting.SetCParm("frmListCargoHouse.txtHSCODE", Me.txtHsCode.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtIMOCLASS", Me.txtImoClass.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.txtIMOUNNO", Me.txtImoUnNo.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtFLASHPOINT", Me.txtFlashPoint.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtIMOPAGE", Me.txtIMOPage.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtEMS", Me.txtEMS.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.txtMFAG", Me.txtMFAG.Text)
    '        objUserSetting.SetCParm("frmListCargoHouse.txtTachnicalDescription", Me.txtTachnicalDescription.Text)

    '        objUserSetting.SetCParm("frmListCargoHouse.txtPHDescription", Me.txtPHDescription.Text)

    '        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayAmount", Me.smnuDisplayAmount.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayBillOfLading_House", Me.smnuDisplayBillOfLading_House.Checked)

    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayClauseOfService", Me.smnuDisplayClauseOfService.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayContainersId", Me.smnuDisplayContainersNo.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayContainerType", Me.smnuDisplayContainerType.Checked)

    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayGross", Me.smnuDisplayGross.Checked)

    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayKind", Me.smnuDisplayKind.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayMeas", Me.smnuDisplayMeas.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayNote", Me.smnuDisplayNote.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayReceiveDate", Me.smnuDisplayReceiveDate.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayReeferDegree", Me.smnuDisplayReeferDegree.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplaySealNo", Me.smnuDisplaySealNo.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayUnitGross", Me.smnuDisplayUnitGross.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayUnitMeas", Me.smnuDisplayUnitMeas.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayWeek", Me.smnuDisplayWeek.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTARIFF", Me.smnuDisplayTARIFF.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayHS_CODE", Me.smnuDisplayHS_CODE.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayIMO_CLASS", Me.smnuDisplayIMO_CLASS.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayIMO_UN_NO", Me.smnuDisplayIMO_UN_NO.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayIMO_PAGE", Me.smnuDisplayIMO_PAGE.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayFLASH_POINT", Me.smnuDisplayFLASH_POINT.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayEMS", Me.smnuDisplayEMS.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayMFAG", Me.smnuDisplayMFAG.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTECHNICAL_DESCRIPTION", Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked)

    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION", Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTotalGross", Me.smnuDisplayTotalgross.Checked)
    '        objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTotalPakages", Me.smnuDisplayTotalPakages.Checked)
    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '    End Sub

    Sub QueryBill_NO()
        On Error GoTo Err_Renamed

        Dim id As String = "BLH_ID"
        Dim value As String = "BLH_No"
        On Error GoTo Err_Renamed
        Dim strSQL As String

        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select BLH_ID ,BLH_No From BillOfLading_House where Continued=1 Order By BLH_NO desc"
        loadDataToObject(Me.cboBillofLading_House, strSQL, id, value)
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    Sub QuerySealNo()
        On Error GoTo Err_Renamed

        Dim id As String = "SEAL_ID"
        Dim value As String = "SEALNO"
        Dim strSQL As String
        strSQL = "Select SEAL_ID,SEALNO From SEAL Where Continued=1 Order By SEALNO Desc"
        loadDataToObject(Me.cboSealNo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    Sub QueryContainerNO()
        On Error GoTo Err_Renamed

        Dim id As String = "CTN_ID"
        Dim value As String = "CONTAINER_NO"
        Dim strSQL As String
        strSQL = "Select CTN_ID,CONTAINER_NO From Container Where Continued=1 Order By CTN_SIZE_TYPE Desc"
        loadDataToObject(Me.cboCTN_NO, strSQL, id, value)
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    '    Sub QueryContainer()
    '        On Error GoTo Err_Renamed

    '        Dim id As String = "BLH_ID"
    '        Dim value As String = "Container_TYPE"
    '        Dim strSQL As String
    '        strSQL = "Select DISTINCT BLH_ID,Container_TYPE From Cargo_house Where Continued=1 "
    '        strSQL &= " And BLH_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "' "
    '        loadDataToObject(Me.cboContainerType, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '    End Sub

    '    Sub QueryItems()
    '        On Error GoTo ERR_NAMED
    '        Dim id As String = "CHARGE_ID"
    '        Dim value As String = "CHARGE_CODE"
    '        Dim strQuery As String = "Select CHARGE_ID,CHARGE_CODE from CHARGE where CONTINUED=1"
    '        loadDataToObject(Me.cboItems, strQuery, id, value)
    '        Exit Sub
    'ERR_NAMED:
    '        msgbox(err.Description)
    '    End Sub

    '    Sub QueryPayable()
    '        On Error GoTo ERR_NAMED
    '        Dim cbo As Object
    '        cbo = Me.cboPayableCode
    '        Queryport(cbo)
    '        Exit Sub
    'ERR_NAMED:
    '        msgbox(err.Description)
    '    End Sub

    Sub QueryBooking(ByRef oTable As DataTable)
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Conn.Open()
        Dim strQuery As String
        strQuery = " Select Cold,Ventilation as Vent "
        strQuery &= " From (ContainerOutboundNotify LEFT JOIN BILLOFLADING_HOUSE On ContainerOutboundNotify.ContainerOutboundNotifyID=BILLOFLADING_HOUSE.ContainerOutboundNotifyID) "
        strQuery &= " Where BLH_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "' And ContainerOutboundNotify.Continued=1"
        Dim Cmd As New SqlClient.SqlCommand(strQuery, Conn)
        Dim Adapter As New SqlClient.SqlDataAdapter(Cmd)
        If oTable.Rows.Count > 0 Then
            oTable.Rows.Clear()
        End If
        Adapter.Fill(oTable)
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
    '        msgbox(err.Description)
    '    End Sub



    Private Sub frmListCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mCargoMarks_ID = DefaultValue
        mCargoRemarks_ID = DefaultValue
        mCargoDesc_ID = DefaultValue

        mCargoHouseDesc_ID = DefaultValue
        SetDefaultGrid(Me.dgdDetailBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdPrice, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

        mStatusP = "Normal"
        blnUpdated = False
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdDetailBillOfLading_House)
        Dim oItems As PDSAListItemString

        ''-------------CboKind
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PACKAGE", "PACKAGE")
        'Me.cboKind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CARTON", "CARTON")
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
        ' ''-----------Container Type
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "20GP", "20GP")
        'Me.txtContainerType.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "40GP", "40GP")
        'Me.txtContainerType.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "40HC", "40HC")
        'Me.txtContainerType.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "45HC", "45HC")
        'Me.txtContainerType.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "20RF", "20RF")
        'Me.txtContainerType.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "40RF", "40RF")
        'Me.txtContainerType.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "40RH", "40RH")
        'Me.txtContainerType.Items.Add(oItems)
        '------------price

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "BAF", "BAF")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CAF", "CAF")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "WRS", "WRS")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "DIB", "DIB")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "DDC", "DDC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "DTHC", "DTHC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "MAF", "MAF")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "ACC", "ACC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "BRC", "BRC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "FTC", "FTC")
        'Me.cboItems.Items.Add(oItems)


        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PSS", "PSS")
        'Me.cboItems.Items.Add(oItems)


        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "COD", "COD")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "ASC", "ASC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CFS", "CFS")
        'Me.cboItems.Items.Add(oItems)


        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "SSP", "SSP")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "ARB", "ARB")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "RSC", "RSC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "ORC", "ORC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PCF", "PCF")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "YAS", "YAS")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PCS", "PCS")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PIC", "PIC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "PAC", "PAC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "SBC", "SBC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "GRI", "GRI")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "WTS", "WTS")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "SCS", "SCS")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "HCH", "HCH")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "OWC", "OWC")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "DCF", "DCF")
        'Me.cboItems.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "ERS", "ERS")
        'Me.cboItems.Items.Add(oItems)
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
        'GetCurrency(Me.cboCurrency)
        QueryBill_NO()

        'QueryDetailBillOfLading_House()
        'QueryContainer()
        QueryContainerNO()
        QuerySealNo()
        ' Me.txtBillOfLading_HouseId.Text = gBillOfLading_HouseNumber

        'them vao cac Combobox o dgdPrice

        'QueryItems()
        'QueryPayable()
        'QueryPackages()

        Reefer_Degree()
        '------------------------



        Me.txtContainerType.Text = objUserSetting.GetCParm("frmListCargoHouse.cboContainerType", "20GP")
        'Me.cboKind.Text = objUserSetting.GetCParm("frmListCargoHouse.cboKind", "PACKAGE")
        Me.cboUnitGross.Text = objUserSetting.GetCParm("frmListCargoHouse.cboUnitGross", "Kgs")
        Me.cboUnitVolume.Text = objUserSetting.GetCParm("frmListCargoHouse.cboUnitVolume", "M3")

        'mFilter = objUserSetting.GetCParm("frmListCargoHouse.mFilter")
        'Me.TxtName.Text = objUserSetting.GetCParm("frmListCargo.txtName")

        'Me.txtAddress.Text = objUserSetting.GetCParm("frmListCargo.txtAddress")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmListCargo.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmListCargo.txtEmail")
        'Me.txtPhone.Text = objUserSetting.GetCParm("frmListCargo.txtPhone")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmListCargo.txtFax")
        'Me.txtContactperson.Text = objUserSetting.GetCParm("frmListCargo.txtContactPerson")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmListCargo.txtRemarks")
        'If Me.txtSHIPPERNAME.Text <> "" Then
        '    QueryBillOfLading_House("AND Name LIKE '" & MakeFilter(Me.txtSHIPPERNAME.Text) & "' " & mFilter)
        'Else
        '    QueryBillOfLading_House(mFilter)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If


        ' Me.cboBillOfLading_House.Text = objUserSetting.GetCParm("frmListCargoHouse.cboFind")
        Me.txtSHIPPERNAME.Text = objUserSetting.GetCParm("frmListCargoHouse.txtFCommodity")

        '-------------
        'Me.cboCTN_NO.Text = objUserSetting.GetCParm("frmListCargoHouse.txtContainerNo")
        Me.cboSealNo.Text = objUserSetting.GetCParm("frmListCargoHouse.txtSealNo")

        Me.txtContainerType.Text = objUserSetting.GetCParm("frmListCargoHouse.cboContainerType")
        Me.txtAmount.Text = objUserSetting.GetCParm("frmListCargoHouse.txtAmount")
        Me.txtKind.Text = objUserSetting.GetCParm("frmListCargoHouse.txtkind")
        ' Me.cboKind.Text = objUserSetting.GetCParm("frmListCargoHouse.cboKind")

        Me.txtGross.Text = objUserSetting.GetCParm("frmListCargoHouse.txtGross")
        Me.cboUnitGross.Text = objUserSetting.GetCParm("frmListCargoHouse.cboUnitGross")


        Me.txtMeas.Text = objUserSetting.GetCParm("frmListCargoHouse.txtMeas")
        Me.cboUnitVolume.Text = objUserSetting.GetCParm("frmListCargoHouse.cboUnitVolume")
        Me.txtWeek.Text = objUserSetting.GetCParm("frmListCargoHouse.txtWeek")
        Me.txtReeferDegree.Text = objUserSetting.GetCParm("frmListCargoHouse.txtReeferDegree")

        Me.txtNote.Text = objUserSetting.GetCParm("frmListCargoHouse.txtNote")
        Me.txtDescription.Text = objUserSetting.GetCParm("frmListCargoHouse.txtDescription")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.txtTariff.Text = objUserSetting.GetCParm("frmListCargoHouse.txtTariff")
        Me.txtHsCode.Text = objUserSetting.GetCParm("frmListCargoHouse.txtHSCODE")

        '-------------
        Me.txtImoClass.Text = objUserSetting.GetCParm("frmListCargoHouse.txtIMOCLASS")
        Me.txtImoUnNo.Text = objUserSetting.GetCParm("frmListCargoHouse.txtIMOUNNO")

        Me.txtIMOPage.Text = objUserSetting.GetCParm("frmListCargoHouse.txtIMOPAGE")
        Me.txtFlashPoint.Text = objUserSetting.GetCParm("frmListCargoHouse.txtFLASHPOINT")
        Me.txtEMS.Text = objUserSetting.GetCParm("frmListCargoHouse.txtEMS")
        Me.txtMFAG.Text = objUserSetting.GetCParm("frmListCargoHouse.txtMFAG")

        Me.txtTachnicalDescription.Text = objUserSetting.GetCParm("frmListCargoHouse.txtTachnicalDescription")
        Me.txtPHDescription.Text = objUserSetting.GetCParm("frmListCargoHouse.txtPHDescription")
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Me.txtClauseOfService.Text = objUserSetting.GetCParm("frmListCargoHouse.txtClauseOfService")

        '----------------

        Me.smnuDisplayAmount.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayAmount")
        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayApprove")
        ' Me.smnuDisplayBillOfLading_House.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayBillOfLading_House")

        Me.smnuDisplayClauseOfService.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayClauseOfService")
        Me.smnuDisplayContainersNo.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayContainersId")
        Me.smnuDisplayContainerType.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayContainerType")

        Me.smnuDisplayGross.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayGross")

        Me.smnuDisplayKind.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayKind")
        Me.smnuDisplayMeas.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayMeas")
        Me.smnuDisplayNote.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayNote")
        Me.smnuDisplayReceiveDate.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayReceiveDate")
        Me.smnuDisplayReeferDegree.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayReeferDegree")
        Me.smnuDisplaySealNo.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplaySealNo")
        Me.smnuDisplayUnitGross.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayUnitGross")
        Me.smnuDisplayUnitMeas.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayUnitMeas")
        Me.smnuDisplayWeek.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayWeek")
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.smnuDisplayTARIFF.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayTARIFF")
        Me.smnuDisplayIMO_CLASS.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayIMO_CLASS")
        Me.smnuDisplayHS_CODE.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayHS_CODE")

        Me.smnuDisplayIMO_UN_NO.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayIMO_UN_NO")

        Me.smnuDisplayIMO_PAGE.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayIMO_PAGE")
        Me.smnuDisplayFLASH_POINT.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayFLASH_POINT")
        Me.smnuDisplayEMS.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayEMS")
        Me.smnuDisplayMFAG.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayMFAG")

        Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayTECHNICAL_DESCRIPTION")
        Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION")
        Me.smnuDisplayMarks.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayMarks")
        Me.smnuDisplayRemarks.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayRemarks")

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListCargoHouse.smnuDisplayUpdateTime")
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdOK.Enabled = False
        'Dim index As Integer
        'If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
        '    index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        '    'Me.dgdDetailBillOfLading_House.SelectedRows
        '    Me.txtContainerKindP.Text = Me.dgdDetailBillOfLading_House.Item("Kind", index).Value.ToString
        '    Me.txtContainerNoP.Text = Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString
        '    Me.txtBillOfLading_HouseP.Text = Me.dgdDetailBillOfLading_House.Item("Bill_No", index).Value.ToString
        'End If
        'Me.txtDescription.Enabled = False
        'Me.lblDescription.Enabled = False
        'Me.cmdOKP.Enabled = False
        ReFormat()
        'Me.Cursor = Cursors.Default
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub

    '    Private Sub QueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 0)
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim ds As New DataSet
    '        '----------------
    '        If IsNothing(argCriteria) Then
    '            strQuery = MakeQueryPrice(, index)
    '        Else
    '            strQuery = MakeQueryPrice(argCriteria, index)
    '        End If
    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        Con.Open()
    '        If Not IsNothing(oTablePrice) Then
    '            oTablePrice.Clear()
    '        End If
    '        Adapter.Fill(dsPrice, "PriceList")
    '        oTablePrice = dsPrice.Tables(0)
    '        'hien thi ra grid 
    '        Me.dgdPrice.DataSource = dsPrice.Tables("PriceList")
    '        If Me.dgdPrice.Enabled = False Then
    '            Me.dgdPrice.Enabled = True
    '        End If
    '        Me.dgdPrice.Columns("freight_charges_house_id").Visible = False
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        InsertAutoNumberToGrid(Me.dgdPrice)

    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '        'Resume
    '    End Sub

    Private Sub QueryBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryBillOfLading_House()
        Else
            strQuery = MakeQueryBillOfLading_House(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableBillOfLading_House) Then
            oTableBillOfLading_House.Clear()
        End If
        Adapter.Fill(dsBillOfLading_House, "BillOfLading_HouseList")
        oTableBillOfLading_House = dsBillOfLading_House.Tables(0)
        'hien thi ra grid 
        Me.dgdDetailBillOfLading_House.DataSource = dsBillOfLading_House.Tables("BillOfLading_HouseList")
        If Me.dgdDetailBillOfLading_House.Enabled = False Then
            Me.dgdDetailBillOfLading_House.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableBillOfLading_House.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading_House.Columns.Item("BillOfLading_HouseId1").ToolTipText = "Hiện có:" + CStr(Me.dgdDetailBillOfLading_House.RowCount()) + " Bills."
        End If
        'If Me.dgdDetailBillOfLading_House.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        'End If
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdDetailBillOfLading_House.Rows.Count And Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading_House.Rows(location).Selected = True
            Me.dgdDetailBillOfLading_House.CurrentCell = Me.dgdDetailBillOfLading_House.Rows(location).Cells(5)
        End If
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading_House)
        '--------------------
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
        'Resume
    End Sub

    Private Sub QueryDetailBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryDetailBillOfLading_House()
        Else
            strQuery = MakeQueryDetailBillOfLading_House(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            oTableDetailBillOfLading_House.Clear()
        End If
        Adapter.Fill(dsDetailBillOfLading_House, "DetailBillOfLading_HouseList")
        oTableDetailBillOfLading_House = dsDetailBillOfLading_House.Tables(0)
        'hien thi ra grid 


        Me.dgdDetailBillOfLading_House.DataSource = dsDetailBillOfLading_House.Tables("DetailBillOfLading_HouseList")
        Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.RowCount
        If Me.dgdDetailBillOfLading_House.Enabled = False Then
            Me.dgdDetailBillOfLading_House.Enabled = True
        End If

        '------------vị trí BM
        If location > 0 And location <= Me.dgdDetailBillOfLading_House.Rows.Count And Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading_House.Rows(location).Selected = True
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableDetailBillOfLading_House.Rows.Count > 0 Then
            Me.dgdDetailBillOfLading_House.Columns.Item("BilL_No").ToolTipText = "Hiện có:" + CStr(Me.dgdDetailBillOfLading_House.RowCount()) + " Containers."
            SetMenu(True)
        End If
        'Me.txtTotalGrossW.Text = totalGross()
        'Me.txtTotalPackage.Text = totalPackage()
        'Me.txtTotalVolime.Text = totalVolume()
        'If Me.dgdDetailBillOfLading_House.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        'End If
        Me.UpdateFrame()
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
        'Resume
    End Sub

    Private Function MakeQueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 0) As String
        On Error GoTo Err_Renamed
        MakeQueryPrice = strPriceSelect

        MakeQueryPrice = MakeQueryPrice & " FROM (FREIGHT_CHARGE_House left join Charge on FREIGHT_CHARGE_House.Charge_Id=Charge.Charge_Id) "
        'MakeQueryPrice = MakeQueryPrice & " LEFT JOIN PAYABLE_AT on PAYABLE_AT.PAYABLE_AT_ID=FREIGHT_CHARGE_House.PAYABLE_AT_ID)  "

        MakeQueryPrice = MakeQueryPrice & "WHERE ((FREIGHT_CHARGE_House.BLH_ID = '" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text.Trim) & "') " 'Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "') "

        MakeQueryPrice = MakeQueryPrice & "And ("
        MakeQueryPrice = MakeQueryPrice & " FREIGHT_CHARGE_House.Continued = 1 "
        MakeQueryPrice = MakeQueryPrice & "))"
        If argCriteria <> "" Then
            MakeQueryPrice = MakeQueryPrice & argCriteria
        End If
        MakeQueryPrice = MakeQueryPrice & strPriceOrder

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function

    Private Function MakeQueryBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading_House = strBillOfLading_HouseSelect
        'MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & " FROM (((BillOfLading_House inner join  BillOfLading_HouseHouse on BillOfLading_House.BillOfLading_HouseId=BillOfLading_HouseHouse.BillOfLading_HouseId) inner join Shipper on BillOfLading_House.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOfLading_House.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading_House.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & " FROM ((((BillOfLading_House left join Shipper on BillOfLading_House.ShipperId=Shipper.ShipperId ) left join Consignee on BillOfLading_House.ConsigneeId=Consignee.ConsigneeId ) left join Notify on BillOfLading_House.NotifyId=Notify.NotifyId) left join UserList on BillOfLading_House.CreativeUser=UserList.Usr) Left join Vessel on BillOfLading_House.OceanVesselId=Vessel.VesselId "
        MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & "WHERE (BillOfLading_House.BillOfLading_HouseId = '" & DefaultValue & "') "

        MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & "OR ("
        MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & " BillOfLading_House.Continued = 1 "
        MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & strBillOfLading_HouseOrder1
        ElseIf index = 14 Then ' 
            MakeQueryBillOfLading_House = MakeQueryBillOfLading_House & strBillOfLading_HouseOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function

    Private Function MakeQueryDetailBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryDetailBillOfLading_House = strDetailBillOfLading_HouseSelect
        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " FROM (((((((Cargo_House left join BillOfLading_House on Cargo_House.BLH_Id = BillOfLading_House.BLH_Id) LEFT JOIN container on Cargo_House.CTN_ID=Container.CTN_ID)"
        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " LEFT JOIN SEAL On SEAL.SEAL_ID=Cargo_House.SEAL_ID) LEFT JOIN CARGOHOUSE_DESCRIPTION ON Cargo_House.BLH_ID=CARGOHOUSE_DESCRIPTION.BLH_ID) "

        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & "LEFT JOIN CargoHouse_Marks on Cargo_House.BLH_ID=CargoHouse_Marks.BLH_ID) LEFT JOIN CargoHouse_Remarks on Cargo_House.BLH_ID=CargoHouse_Remarks.BLH_ID)  "
        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " LEFT JOIN ContainerOutboundNotify ON ContainerOutboundNotify.ContainerOutboundNotifyID= BillOfLading_House.ContainerOutboundNotifyID) "
        'MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " LEFT JOIN CargoHouse_Marks ON CargoHouse_Marks.CargoMarks_ID= Cargo_Marks.CargoMarks_ID) LEFT JOIN CargoHouse_Remarks On CargoHouse_Remarks.CargoRemarks_ID=Cargo_Remarks.CargoRemarks_ID)"
        'MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " LEFT JOIN CargoHouse_Description ON CargoHouse_Description.Cargo_Description_ID=Cargo_Description.Cargo_Description_ID) "
        'MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " LEFT JOIN Cargo_House ON Cargo_House.Cargo_ID = Cargo_House.Cargo_ID) "

        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & " Where (Cargo_House.BLH_ID = '" & DefaultValue & "') "

        'If mCopy = True Then
        '    MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & "WHERE (DetailBillOfLading_House.BillOfLading_HouseId = '" & oTableBillOfLading_House.Rows(indexBill).Item("BillOfLading_HouseId") & "') "
        'Else
        '    MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & "WHERE (DetailBillOfLading_House.BillOfLading_HouseId = '" & gBillOfLading_HouseNumber & "') "
        'End If

        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & "OR ("
        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & "Cargo_House.Continued = 1 "
        MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & strDetailBillOfLading_HouseOrder1
        ElseIf index = 14 Then ' 
            MakeQueryDetailBillOfLading_House = MakeQueryDetailBillOfLading_House & strDetailBillOfLading_HouseOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed
        Me.dgdDetailBillOfLading_House.Columns.Item("Cargo_Id").Visible = False
        'Me.dgdDetailBillOfLading_House.Columns.Item("BL_Id").Visible = Me.smnuDisplayBillOfLading_House.Checked

        Me.dgdDetailBillOfLading_House.Columns.Item("ClauseOfService").Visible = Me.smnuDisplayClauseOfService.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("ContainersId").Visible = Me.smnuDisplayContainersNo.Checked ' luu y dgview

        Me.dgdDetailBillOfLading_House.Columns.Item("SealNo").Visible = Me.smnuDisplaySealNo.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("ContainerType").Visible = Me.smnuDisplayContainerType.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Amount").Visible = Me.smnuDisplayAmount.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Kind").Visible = Me.smnuDisplayKind.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Gross").Visible = Me.smnuDisplayGross.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("UnitGross").Visible = Me.smnuDisplayUnitGross.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Meas").Visible = Me.smnuDisplayMeas.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("UnitMeas").Visible = Me.smnuDisplayUnitMeas.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Receivedate").Visible = Me.smnuDisplayReceiveDate.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Week").Visible = Me.smnuDisplayWeek.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("ReeferDegree").Visible = Me.smnuDisplayReeferDegree.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Note").Visible = Me.smnuDisplayNote.Checked

        Me.dgdDetailBillOfLading_House.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Me.dgdDetailBillOfLading_House.Columns.Item("NUMBER_OF_PACKAGES").Visible = Me.smnuDisplayTotalPakages.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("CARGO_GROSS_WEIGHT").Visible = Me.smnuDisplayTotalgross.Checked
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.dgdDetailBillOfLading_House.Columns.Item("TARIFF").Visible = Me.smnuDisplayTARIFF.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("HS_CODE").Visible = Me.smnuDisplayHS_CODE.Checked

        Me.dgdDetailBillOfLading_House.Columns.Item("IMO_CLASS").Visible = Me.smnuDisplayIMO_CLASS.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("IMO_UN_NO").Visible = Me.smnuDisplayIMO_UN_NO.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("IMO_PAGE").Visible = Me.smnuDisplayIMO_PAGE.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("FLASH_POINT").Visible = Me.smnuDisplayFLASH_POINT.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("EMS").Visible = Me.smnuDisplayEMS.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("MFAG").Visible = Me.smnuDisplayMFAG.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("TECHNICAL_DESCRIPTION").Visible = Me.smnuDisplayTECHNICAL_DESCRIPTION.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("PACKAGE_HAZARDOUS_DESCRIPTION").Visible = Me.smnuDisplayPACKAGE_HAZARDOUS_DESCRIPTION.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("CargoMarks").Visible = Me.smnuDisplayMarks.Checked
        Me.dgdDetailBillOfLading_House.Columns.Item("Cargo_Remarks").Visible = Me.smnuDisplayRemarks.Checked

        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub

    Private Sub ReFormat1()
        On Error GoTo Err
        'If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        If (Me.Height < 705 Or Me.Height >= 705) Then
            Me.Height = 740
        End If
        If (Me.Width < 910 Or Me.Width > 910) Then
            Me.Width = 910
        End If
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
            Me.dgdDetailBillOfLading_House.Height = Me.Height - Me.txtSHIPPERNAME.Height - 40
        Else
            Me.dgdDetailBillOfLading_House.Height = Me.Height - Me.txtDescription.Height - Me.TabCargo.Height - Me.txtSHIPPERNAME.Height - 50
        End If
        Exit Sub
Err:
        msgbox(err.Description)
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
        Me.dgdDetailBillOfLading_House.Width = (Me.Width - 30)
        Me.TabCargo.Width = Me.Width - 30
        'Me.dgdPrice.Width = Me.TabCargo.Width - 30
        'Me.fraCargoGoods.Width = Me.TabCargo.Width - 20
        'MsgBox(Me.Width)
        If Me.Width > 800 Then
            Me.Height = frmMain.Height - 10 - Me.Top
            dgdDetailBillOfLading_House.Height = Me.Height - 60 - IIf(TabCargo.Visible, 100 + TabCargo.Height + 110, +40) '> 7000
        Else
            Me.Height = frmMain.Height - 10 - Me.Top
            dgdDetailBillOfLading_House.Height = Me.Height - 90 - IIf(TabCargo.Visible, TabCargo.Height + 85, +10) ' < 7000
        End If
        Me.TabCargo.Top = Me.dgdDetailBillOfLading_House.Bottom + 10
        Me.cmdOK.Left = TabCargo.Width - 200
        Me.cmdCancel.Left = Me.cmdOK.Left + Me.cmdOK.Width + 20
        'Me.grpFind.Left = Me.Width / 2 - Me.grpFind.Width / 2
        'Me.grpFind.Top = Me.Height / 2 - Me.grpFind.Height / 2

        cmdCancel.Top = TabCargo.Bottom + 5
        cmdOK.Top = cmdCancel.Top
        'cmdFind.Left = Me.txtContainer.Left + Me.txtContainer.Width + 10
        'txtContainer.Width = Me.Width - 297

        Exit Sub
Err:
        msgbox(err.Description)
        'Resume
    End Sub

    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        ' Me.Close()
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub

    Private Sub cboContainerType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Reefer_Degree()
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub

    Private Sub cboContainerType_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Reefer_Degree()
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
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
        msgbox(err.Description)
    End Sub

    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Detail Cargo House"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Detail Cargo  House-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Detail Cargo House-> Add."
        End If

    End Sub

    '    Function InsertHouseBill() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        Dim rs, rsHBL As New ADODB.Recordset
    '        Dim index As Integer = 0
    '        Dim indexBill As Integer
    '        'If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
    '        '    index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '        '    indexBill = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '        'End If

    '        'Lấy Số House Bill trong CSDL ra để thêm vào

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM BillOfLading_House_HOUSE "
    '        strQuery = strQuery & "WHERE BL_ID = '" & BillID & "'"
    '        rsHBL.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        If rsHBL.EOF Then
    '            DisplayMessage(True, "This Master Has not Got House Bill")
    '            Return False
    '        End If
    '        rsHBL.MoveFirst()
    '        While Not rsHBL.EOF
    '            'thêm vào Cargo House Description
    '            strQuery = "SELECT * "
    '            strQuery = strQuery & "FROM CARGOHOUSE_DESCRIPTION "
    '            strQuery = strQuery & "WHERE BLH_ID= '" & rsHBL.Fields("BLH_ID").Value.ToString & "' AND BL_ID = '" & BillID & "' "
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            With rs
    '                If rs.EOF Then
    '                    .AddNew()
    '                    .Fields("CargoHouse_Description_ID").Value = NewId()
    '                    .Fields("BL_ID").Value = "{" & BillID & "}"
    '                    .Fields("Cargo_Description_ID").Value = mCargoDesc_ID
    '                    Dim temp As String
    '                    temp = rsHBL.Fields("BLH_ID").Value.ToString
    '                    .Fields("BLH_ID").Value = temp
    '                End If
    '                strCargo_Desc_ID = .Fields("Cargo_Description_ID").Value
    '                .Fields("DESCRIPTION").Value = Trim(Me.txtDescription.Text)
    '                .Update()
    '            End With
    '            rs.Close()

    '            'thêm vào cargo House 

    '            strQuery = "SELECT * "
    '            strQuery = strQuery & "FROM Cargo_House "
    '            strQuery = strQuery & "WHERE BLH_Id = '" & rsHBL.Fields("BLH_ID").Value.ToString & "' AND Cargo_Id = '" & mCargo_ID & "' "
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            With rs
    '                If rs.EOF Then

    '                    .AddNew()

    '                    .Fields("CargoHouse_ID").Value = NewId()

    '                    .Fields("Cargo_ID").Value = strCargo_ID

    '                    .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString

    '                    .Fields("BL_Id").Value = "{" & BillID & "}"

    '                    .Fields("CTN_ID").Value = "{" & CtainerID & "}"

    '                    .Fields("SEAL_ID").Value = "{" & FindValueID(Me.cboSealNo, Me.cboSealNo.Text) & "}"

    '                    .Fields("Cargo_Desc_ID").Value = strCargo_Desc_ID

    '                End If

    '                'strCargo_ID = .Fields("Cargo_Id").Value

    '                .Fields("CARGO_GROSS_WEIGHT").Value = Me.txtTotalGrossW.Text

    '                .Fields("NUMBER_OF_PACKAGES").Value = Me.txtTotalPackage.Text

    '                .Fields("Amount").Value = Me.txtAmount.Text

    '                .Fields("TARIFF").Value = Trim(Me.txtTariff.Text)
    '                .Fields("HS_CODE").Value = Trim(Me.txtHsCode.Text)
    '                .Fields("IMO_CLASS").Value = Trim(Me.txtImoClass.Text)
    '                .Fields("IMO_UN_NO").Value = Trim(Me.txtImoUnNo.Text)
    '                .Fields("IMO_PAGE").Value = Trim(Me.txtIMOPage.Text)
    '                .Fields("FLash_Point").Value = Trim(Me.txtFlashPoint.Text)
    '                .Fields("EMS").Value = Trim(Me.txtEMS.Text)

    '                .Fields("Cargo_Desc_ID").Value = strCargo_Desc_ID

    '                .Fields("CARGO_SEQUENCE").Value = Trim(Me.txtCargoSequence.Text)
    '                .Fields("COMMODITY_GROUP").Value = Trim(Me.txtCommodityGroup.Text)
    '                .Fields("COMMODITY").Value = Trim(Me.txtCommodity.Text)
    '                .Fields("CARGO_GROSS_CUBE").Value = Trim(Me.txtCargoGrossCube.Text)
    '                '.Fields("CARGO_NET_WEIGHT").Value = Trim(Me.txtt.Text)
    '                .Fields("CARGO_GROSS_WEIGHT").Value = Trim(Me.txtTotalGrossW.Text)

    '                .Fields("MFAG").Value = Trim(Me.txtTariff.Text)
    '                .Fields("TECHNICAL_DESCRIPTION").Value = Trim(Me.txtTachnicalDescription.Text)
    '                .Fields("TOTALVOLUME").Value = Trim(Me.txtTotalVolime.Text)
    '                .Fields("PACKAGE_HAZARDOUS_DESCRIPTION").Value = Trim(Me.txtPHDescription.Text)

    '                .Fields("SHIPPER_OWNED_UNIT").Value = Trim(Me.txtShipperOwnedUnit.Text)
    '                .Fields("TEMPERATURE_SETTING").Value = Trim(Me.txtTempSetting.Text)

    '                If Me.chkStandard.Checked Then
    '                    .Fields("Kind").Value = Trim(Me.cboKind.Text)
    '                Else
    '                    If Me.chkOther.Checked Then
    '                        .Fields("Kind").Value = Trim(Me.txtKind.Text)
    '                    End If
    '                End If

    '                .Fields("Gross").Value = Trim(Me.txtGross.Text)
    '                .Fields("Unit_Gross").Value = Trim(Me.cboUnitGross.Text)

    '                .Fields("CTN_CARGO_MEASUREMENT").Value = Trim(Me.txtMeas.Text)
    '                .Fields("UNIT_MEASUREMENT").Value = Trim(Me.cboUnitVolume.Text)
    '                .Fields("CARGO_RECEVING_DATE").Value = CDate(Trim(Me.DateTimePicker.Text))
    '                .Fields("Week").Value = Trim(WeekOfYear)
    '                If Me.txtReeferDegree.Visible = True Then
    '                    .Fields("ReeferDegree").Value = Trim(Me.txtReeferDegree.Text)
    '                End If

    '                .Fields("Note").Value = Trim(Me.txtNote.Text)
    '                .Update()
    '            End With
    '            rs.Close()
    '            'thêm vào Cargo Marks

    '            strQuery = "SELECT * "
    '            strQuery = strQuery & "FROM CARGOHOUSE_MARKS "
    '            strQuery = strQuery & "WHERE BLH_Id = '" & rsHBL.Fields("BLH_ID").Value.ToString & "' AND Cargo_Id <> '" & mCargo_ID & "' "
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            With rs
    '                If rs.EOF Then
    '                    .AddNew()
    '                    .Fields("CargoHouseMarks_ID").Value = NewId()
    '                    .Fields("CargoMarks_ID").Value = mCargoMarks_ID
    '                    .Fields("Cargo_ID").Value = strCargo_ID
    '                    .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString
    '                End If
    '                .Fields("MARKS").Value = Trim(Me.txtCargoMarks.Text)
    '                .Update()
    '            End With
    '            rs.Close()

    '            'Thêm Vào cargo remarks

    '            strQuery = "SELECT * "
    '            strQuery = strQuery & "FROM CARGOHOUSE_REMARKS "
    '            strQuery = strQuery & "WHERE BLH_Id = '" & rsHBL.Fields("BLH_ID").Value.ToString & "' AND Cargo_Id <> '" & mCargo_ID & "' "
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            With rs
    '                If rs.EOF Then
    '                    .AddNew()
    '                    .Fields("CargoHouseRemarks_ID").Value = NewId()

    '                    .Fields("CargoRemarks_ID").Value = mCargoRemarks_ID

    '                    .Fields("Cargo_ID").Value = strCargo_ID
    '                    .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString
    '                End If
    '                .Fields("CARGO_REMARKS").Value = Trim(Me.txtCargoRemarks.Text)
    '                .Update()
    '            End With
    '            rs.Close()
    '            rsHBL.MoveNext()
    '        End While

    '        Return True
    'Err_Renamed:
    '        msgbox(err.Description)
    '    End Function
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        Dim indexBill As Integer
        Dim rsSeal As New ADODB.Recordset
        Dim strQuerySeal, sealId As String
        If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            indexBill = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        End If
        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            If mStatus = "Edit" Then
                'CopyValues("CARGOHouse_DESCRIPTION", "BLH_Id", FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text))
            End If
            'thêm Vào Container
            'strQuery = "SELECT * "
            'strQuery = strQuery & "FROM Container "
            'strQuery = strQuery & "WHERE BillOfLading_HouseId = '" & Trim(Me.txtBillOfLading_HouseId.Text) & "'"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'With rs
            '    If rs.EOF Then
            '        .AddNew()
            '        .Fields("BillOfLading_HouseId").Value = Trim(Me.txtBillOfLading_HouseId.Text)
            '    End If
            '    .Fields("Description").Value = Trim(Me.txtDescription.Text)
            '    .Update()
            'End With
            'rs.Close()

            'thêm vào Cargo Description
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHouse_DESCRIPTION "
            strQuery = strQuery & "WHERE ( BLH_Id = '" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "' AND BLH_Id <> '" & DefaultValue & "') "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BLH_ID").Value = "{" + FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) + "}"
                    .Fields("CargoHouse_Description_ID").Value = NewId()
                End If

                mCargoDesc_ID = .Fields("CargoHouse_Description_ID").Value
                .Fields("DESCRIPTION").Value = Trim(Me.txtDescription.Text)
                .Update()
            End With
            rs.Close()

            'thêm vào cargo 
            If mStatus = "Edit" Then
                'CopyValues("Cargo_House", "CargoHouse_ID", mCargo_ID)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Cargo_House "
            strQuery = strQuery & "WHERE CargoHouse_ID = '" & mCargo_ID & "' AND Continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouse_ID").Value = NewId()

                    '.Fields("BL_Id").Value = "{" & BillHouseID & "}"

                    .Fields("BLH_Id").Value = "{" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "}"


                End If
                strCargoHouse_ID = .Fields("CargoHouse_Id").Value
                .Fields("CTN_ID").Value = "{" & CtainerID & "}"
                sealId = "{" + FindValueID(Me.cboSealNo, Me.cboSealNo.Text.Trim) + "}"
                '---- them seal vao csdl
                strQuerySeal = "SELECT * "
                strQuerySeal = strQuerySeal & "FROM Seal "
                strQuerySeal = strQuerySeal & "WHERE SealNo = '" & Me.cboSealNo.Text.Trim & "' and continued=1"
                rsSeal.Open(strQuerySeal, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rsSeal
                    If rsSeal.EOF Then
                        .AddNew()
                        sealId = NewId()
                        .Fields("Seal_ID").Value = sealId
                        .Fields("SealNo").Value = Me.cboSealNo.Text.Trim
                        rsSeal.Update()
                    End If

                End With
                rsSeal.Close()
                .Fields("SEAL_ID").Value = sealId
                '---------------
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

                '.Fields("CARGO_GROSS_WEIGHT").Value = Me.txtTotalGrossW.Text
                '.Fields("NUMBER_OF_PACKAGES").Value = Me.txtTotalPackage.Text

                '.Fields("ServiceContract").Value = Trim(Me.txtClauseOfService.Text)
                '.Fields("CTN_NO").Value = Trim(Me.cboContainerNo.Text)
                '.Fields("CONTAINER_TYPE").Value = Trim(Me.cboContainerType.Text)

                .Fields("Amount").Value = Me.txtAmount.Text

                .Fields("CTN_STATUS").Value = UCase(Trim(Me.txtCTNStatus.Text))

                .Fields("TARIFF").Value = Trim(Me.txtTariff.Text)
                .Fields("HS_CODE").Value = Trim(Me.txtHsCode.Text)
                .Fields("IMO_CLASS").Value = Trim(Me.txtImoClass.Text)
                .Fields("IMO_UN_NO").Value = Trim(Me.txtImoUnNo.Text)
                .Fields("IMO_PAGE").Value = Trim(Me.txtIMOPage.Text)
                .Fields("FLash_Point").Value = Trim(Me.txtFlashPoint.Text)
                .Fields("EMS").Value = Trim(Me.txtEMS.Text)
                .Fields("Vent").Value = Trim(Me.txtVent.Text)

                .Fields("CARGO_SEQUENCE").Value = Trim(Me.txtCargoSequence.Text)
                .Fields("COMMODITY_GROUP").Value = Trim(Me.txtCommodityGroup.Text)
                .Fields("COMMODITY").Value = Trim(Me.txtCommodity.Text)
                .Fields("CARGO_GROSS_CUBE").Value = Trim(Me.txtCargoGrossCube.Text)
                .Fields("CARGO_NET_WEIGHT").Value = Trim(Me.txtNetweight.Text)
                '.Fields("CARGO_GROSS_WEIGHT").Value = Trim(Me.txtTotalGrossW.Text)

                .Fields("MFAG").Value = Trim(Me.txtMFAG.Text)
                .Fields("TECHNICAL_DESCRIPTION").Value = Trim(Me.txtTachnicalDescription.Text)

                ' .Fields("TOTALVOLUME").Value = Trim(Me.txtTotalVolime.Text)

                .Fields("PACKAGE_HAZARDOUS_DESCRIPTION").Value = Trim(Me.txtPHDescription.Text)

                .Fields("SHIPPER_OWNED_UNIT").Value = Trim(Me.txtShipperOwnedUnit.Text)
                .Fields("TEMPERATURE_SETTING").Value = Trim(Me.txtTempSetting.Text)
                .Fields("CONTAINER_TYPE").Value = Trim(Me.txtContainerType.Text)

                .Fields("TEMPERATURE_ID").Value = Trim(Me.txttempID.Text)


                .Fields("MIN_TEMPERATURE").Value = Trim(Me.txtMinTemp.Text)
                .Fields("MAX_TEMPERATURE").Value = Trim(Me.txtMaxTemp.Text)

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
                'CopyValues("CARGOHouse_MARKS", "BLH_ID", FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text.Trim))
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHouse_MARKS "
            strQuery = strQuery & "WHERE BLH_ID = '" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text.Trim) & "'  "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouseMarks_ID").Value = NewId()
                    '.Fields("Cargo_ID").Value = strCargoHouse_ID
                End If
                mCargoMarks_ID = .Fields("CargoHouseMarks_ID").Value
                .Fields("MARKS").Value = Trim(Me.txtCargoMarks.Text)
                .Update()
            End With
            rs.Close()

            'Thêm Vào cargo remarks
            If mStatus = "Edit" Then
                'CopyValues("CARGOHouse_REMARKS", "BLH_ID", FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text.Trim))
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHouse_REMARKS "
            strQuery = strQuery & "WHERE BLH_ID = '" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text.Trim) & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouseRemarks_ID").Value = NewId()
                    '.Fields("Cargo_ID").Value = strCargoHouse_ID
                End If
                mCargoRemarks_ID = .Fields("CargoHouseRemarks_ID").Value.ToString
                .Fields("CARGO_REMARKS").Value = Trim(Me.txtCargoRemarks.Text)
                .Update()
            End With
            rs.Close()
            'InsertHouseBill()
            '-----------------
            Me.dgdDetailBillOfLading_House.Enabled = True

            Me.fraCargoGoods.Enabled = True
            'Me.cmdPrice.Enabled = False
            Me.lblDescription.Enabled = True
            Me.txtDescription.Enabled = True
            Me.TabCargo.Visible = False
            'Me.cmdOK.Enabled = False
            If mStatus = "Add" Then
                Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.Rows.Count + 1
            End If

            Dim CountContainer As Integer = 0
            For i As Integer = 0 To Me.dgdDetailBillOfLading_House.RowCount - 1
                If Me.dgdDetailBillOfLading_House.Item("ContainerType", i).Value.ToString = Me.txtContainerType.Text And Me.dgdDetailBillOfLading_House.Item("BLH_ID", i).Value.ToString.Trim = FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) Then
                    CountContainer += 1
                End If
            Next
            ' update lai price
            Dim strSQL As String
            strSQL = "Update FREIGHT_CHARGE_Master Set Quantity = " & CountContainer & " Where BL_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "' And Container_Type='" & Me.txtContainerType.Text.Trim & "'"
            UpdateQuantity(strSQL)


            QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text.Trim) & "'", , 0)
            mStatus = "Normal"
        End If
        'Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))

        reText(mStatus)
        blnUpdated = True
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
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
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strBillOfLading_HouseId As String
        If mStatus = "Add" Then
            Dim rs As New ADODB.Recordset
            Dim strSQL As String
            strSQL = "Select * From Cargo_House where CTN_ID='" & CtainerID & "' And BLH_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "' And Continued=1"
            rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                strMsg = "This Container Had Already Had In This Bill "
                CheckData = False
            End If
            strBillOfLading_HouseId = DefaultValue
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
        'If Me.chkStandard.Checked Then
        '    If Me.cboKind.FindStringExact(Me.cboKind.Text) = -1 Then
        '        CheckData = False
        '        strMsg = strMsg & "The the Kind is invalid."
        '    End If
        'ElseIf Me.chkOther.Checked Then
        '    If Len(Me.txtKind.Text) = 0 Then
        '        CheckData = False
        '        strMsg = strMsg & "The the Kind is invalid."
        '    End If
        'End If
        'If Me.chkStandard.Checked = False And Me.chkOther.Checked = False Then
        '    CheckData = False
        '    strMsg = strMsg & "The the Kind is invalid. "
        'End If
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
        'If Len(Me.txtDescription.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Description is invalid. Please check again."
        '    Me.txtDescription.Focus()
        'End If



        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function

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

    '    If Not IsNothing(oTableBillOfLading_House) Then
    '        mCopy = True
    '        Me.QueryDetailBillOfLading_House()

    '    Else
    '        DisplayMessage(True, "There is no data in the Grid B/L.")
    '    End If


    'End Sub

    Private Sub smnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Me.dgdDetailBillOfLading_House.RowCount = 0 Then
            Return
        End If
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            Dim indexBill As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            'QueryPrice(, index)
            Approve = Me.dgdDetailBillOfLading_House.Item("Approve", index).Value
            EditTable = Me.dgdDetailBillOfLading_House.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLadingHouse", "Edit") And Not Me.dgdDetailBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdDetailBillOfLading_House.Enabled = False
                Me.TabCargo.Visible = True
                ReFormat()
                'Me.QueryContainer()

                mCargo_ID = Me.dgdDetailBillOfLading_House.Item("CargoHouse_Id", index).Value.ToString

                mStatus = "Edit"
                reText(mStatus)
                SetMenu(False)
                RefreshData(index)

                Me.fraCargoGoods.Enabled = True
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
    '    Private Sub RefreshDataPrice(ByVal index As Integer)
    '        On Error GoTo Err_Renamed
    '        Dim oItems As PDSAListItemString
    '        Dim kind As String
    '        Me.cboItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
    '        Me.cboCurrency.Text = Me.dgdPrice.Item("Currency", index).Value.ToString
    '        Me.txtUnitPrice.Text = Me.dgdPrice.Item("UnitPrice", index).Value.ToString
    '        Exit Sub
    'Err_Renamed:
    '        DisplayMessage(True, Err.Description & "RefreshData")
    '    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        ' Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading_House.Item("ClauseOfservice", index).Value.ToString
        Me.cboCTN_NO.Text = Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString
        Me.cboSealNo.Text = Me.dgdDetailBillOfLading_House.Item("SealNo", index).Value.ToString
        '--9 seal no
        Me.txtSeal_no2.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No2", index).Value.ToString
        Me.txtSeal_no3.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No3", index).Value.ToString
        Me.txtSeal_no4.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No4", index).Value.ToString
        Me.txtSeal_no5.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No5", index).Value.ToString
        Me.txtSeal_no6.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No6", index).Value.ToString
        Me.txtSeal_no7.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No7", index).Value.ToString
        Me.txtSeal_no8.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No8", index).Value.ToString
        Me.txtSeal_no9.Text = Me.dgdDetailBillOfLading_House.Item("Seal_No9", index).Value.ToString
        '------------------------------------

        Me.txtContainerType.Text = Me.dgdDetailBillOfLading_House.Item("ContainerType", index).Value.ToString
        Me.txtVent.Text = Me.dgdDetailBillOfLading_House.Item("Vent", index).Value.ToString
        Me.txtAmount.Text = Me.dgdDetailBillOfLading_House.Item("Amount", index).Value.ToString
        kind = Me.dgdDetailBillOfLading_House.Item("Kind", index).Value.ToString
        Me.txtKind.Text = kind
        Me.txtCodeKind.Text = Me.dgdDetailBillOfLading_House.Item("Kind_code", index).Value.ToString

        Me.txtGross.Text = Me.dgdDetailBillOfLading_House.Item("Gross", index).Value.ToString
        Me.cboUnitGross.Text = Me.dgdDetailBillOfLading_House.Item("UnitGross", index).Value.ToString
        Me.txtMeas.Text = Me.dgdDetailBillOfLading_House.Item("Meas", index).Value.ToString
        Me.cboUnitVolume.Text = Me.dgdDetailBillOfLading_House.Item("UnitMeas", index).Value.ToString





        If Me.dgdDetailBillOfLading_House.Item("ReceiveDate", index).Value.ToString <> "" Then
            Me.DateTimePicker.Text = Me.dgdDetailBillOfLading_House.Item("ReceiveDate", index).Value.ToString
            Me.chkReceiveDate.Checked = True
        Else
            Me.chkReceiveDate.Checked = False
        End If




        Me.txtWeek.Text = Me.dgdDetailBillOfLading_House.Item("Week", index).Value.ToString

        If Me.dgdDetailBillOfLading_House.Item("ReeferDegree", index).Value.ToString <> "" Then
            Me.txtReeferDegree.Text = Me.dgdDetailBillOfLading_House.Item("ReeferDegree", index).Value.ToString
            Me.txtReeferDegree.Visible = True
        End If

        Me.txtNote.Text = Me.dgdDetailBillOfLading_House.Item("Note", index).Value.ToString
        Me.txtDescription.Text = Me.dgdDetailBillOfLading_House.Item("Description", index).Value.ToString
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.txtCargoMarks.Text = Me.dgdDetailBillOfLading_House.Item("CargoMarks", index).Value.ToString
        Me.txtCargoRemarks.Text = Me.dgdDetailBillOfLading_House.Item("CARGO_REMARKS", index).Value.ToString
        Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.Item("CARGO_SEQUENCE", index).Value.ToString
        Me.txtCargoGrossCube.Text = Me.dgdDetailBillOfLading_House.Item("CARGO_GROSS_CUBE", index).Value.ToString
        Me.txtTempSetting.Text = Me.dgdDetailBillOfLading_House.Item("TEMPERATURE_SETTING", index).Value.ToString
        Me.txttempID.Text = Me.dgdDetailBillOfLading_House.Item("TEMPERATURE_ID", index).Value.ToString

        Me.txtMinTemp.Text = Me.dgdDetailBillOfLading_House.Item("MIN_TEMP", index).Value.ToString
        Me.txtMaxTemp.Text = Me.dgdDetailBillOfLading_House.Item("MAX_TEMP", index).Value.ToString

        Me.txtNetweight.Text = Me.dgdDetailBillOfLading_House.Item("CARGO_NET_WEIGHT", index).Value.ToString
        Me.txtCommodity.Text = Me.dgdDetailBillOfLading_House.Item("COMMODITY", index).Value.ToString
        Me.txtShipperOwnedUnit.Text = Me.dgdDetailBillOfLading_House.Item("SHIPPER_OWNED_UNIT", index).Value.ToString
        Me.txtCommodityGroup.Text = Me.dgdDetailBillOfLading_House.Item("COMMODITY_GROUP", index).Value.ToString


        Me.txtEMS.Text = Me.dgdDetailBillOfLading_House.Item("EMS", index).Value.ToString
        Me.txtTariff.Text = Me.dgdDetailBillOfLading_House.Item("TARIFF", index).Value.ToString
        Me.txtHsCode.Text = Me.dgdDetailBillOfLading_House.Item("HS_CODE", index).Value.ToString
        Me.txtImoClass.Text = Me.dgdDetailBillOfLading_House.Item("IMO_CLASS", index).Value.ToString
        Me.txtIMOPage.Text = Me.dgdDetailBillOfLading_House.Item("IMO_PAGE", index).Value.ToString
        Me.txtImoUnNo.Text = Me.dgdDetailBillOfLading_House.Item("IMO_UN_NO", index).Value.ToString
        Me.txtFlashPoint.Text = Me.dgdDetailBillOfLading_House.Item("FLASH_POINT", index).Value.ToString
        Me.txtMFAG.Text = Me.dgdDetailBillOfLading_House.Item("MFAG", index).Value.ToString
        Me.txtTachnicalDescription.Text = Me.dgdDetailBillOfLading_House.Item("TECHNICAL_DESCRIPTION", index).Value.ToString
        Me.txtPHDescription.Text = Me.dgdDetailBillOfLading_House.Item("PACKAGE_HAZARDOUS_DESCRIPTION", index).Value.ToString
        Me.txtCTNStatus.Text = Me.dgdDetailBillOfLading_House.Item("CTN_STATUS", index).Value.ToString
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & "RefreshData")
    End Sub
    Private Sub RefreshDataBill(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        'Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading_House.Item("ClauseOfService", index).Value.ToString
        Me.cboCTN_NO.Text = Me.dgdDetailBillOfLading_House.Item("ContainersNo", index).Value.ToString
        Me.cboSealNo.Text = Me.dgdDetailBillOfLading_House.Item("SealNo", index).Value.ToString
        Me.txtContainerType.Text = Me.dgdDetailBillOfLading_House.Item("ContainerType", index).Value.ToString
        Me.txtAmount.Text = Me.dgdDetailBillOfLading_House.Item("Amount", index).Value.ToString
        kind = Me.dgdDetailBillOfLading_House.Item("Kind", index).Value.ToString
        'If kind = "Package" Or kind = "Carton" Or kind = "Drum" Or kind = "Unit" Or kind = "Bag" Then
        '    Me.chkStandard.Checked = True
        '    Me.cboKind.Text = kind
        'Else
        '    Me.chkOther.Checked = True
        Me.txtKind.Text = kind
        Me.txtCodeKind.Text = Me.dgdDetailBillOfLading_House.Item("Kind_Code", index).Value.ToString
        'End If
        Me.txtGross.Text = Me.dgdDetailBillOfLading_House.Item("Gross", index).Value.ToString
        Me.cboUnitGross.Text = Me.dgdDetailBillOfLading_House.Item("UnitGross", index).Value.ToString
        Me.txtMeas.Text = Me.dgdDetailBillOfLading_House.Item("Meas", index).Value.ToString
        Me.cboUnitVolume.Text = Me.dgdDetailBillOfLading_House.Item("UnitMeas", index).Value.ToString
        Me.DateTimePicker.Text = Me.dgdDetailBillOfLading_House.Item("ReceiveDate", index).Value.ToString
        Me.txtWeek.Text = Me.dgdDetailBillOfLading_House.Item("Week", index).Value.ToString
        Me.txtReeferDegree.Text = Me.dgdDetailBillOfLading_House.Item("ReeferDegree", index).Value.ToString
        Me.txtNote.Text = Me.dgdDetailBillOfLading_House.Item("Note", index).Value.ToString
        Me.txtDescription.Text = Me.dgdDetailBillOfLading_House.Item("Description", index).Value.ToString

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
        Me.smnuInsert.Enabled = argVisible
        Me.smnuEdit.Enabled = argVisible
        Me.smnuDelete.Enabled = argVisible
        Me.smnuDisplay.Enabled = argVisible
        Me.smnuExit.Enabled = argVisible
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    Private Sub smnuInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuInsert.Click
        On Error GoTo Err_Renamed
        Dim index As Integer = 0
        If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            ''Me.dgdPrice.Rows.Clear()
            'Me.txtContainerKindP.Text = "" 'Me.dgdDetailBillOfLading_House.Item("Kind", index).Value.ToString
            'Me.txtContainerNoP.Text = "" 'Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString
            'Me.txtBillOfLading_HouseP.Text = "" 'Me.dgdDetailBillOfLading_House.Item("Bill_No", index).Value.ToString
            'Me.fraPrice.Enabled = False
        End If

        If mStatus = "Normal" And UserRight("frmListBillOfLadingHouse", "Add") Then
            'QueryPrice()
            SetMenu(False)

            Dim dt As New DataTable
            QueryBooking(dt)
            If dt.Rows.Count > 0 Then
                Me.txtReeferDegree.Text = dt.Rows(0).Item("Cold").ToString
                Me.txtVent.Text = dt.Rows(0).Item("Vent").ToString
            End If
            Me.txtCTNStatus.Text = "F"
            Me.txtReeferDegree.Text = ""
            Me.txtShipperOwnedUnit.Text = "N"
            Me.txtCargoRemarks.Text = "COC"
            ' Me.txtTariff.Text = Me.txtClauseOfService.Text
            mCargo_ID = DefaultValue
            mCargoMarks_ID = DefaultValue
            mCargoRemarks_ID = DefaultValue
            mCargoDesc_ID = DefaultValue


            mCargoHouseDesc_ID = DefaultValue

            mStatus = "Add"
            Me.TabCargo.Visible = True
            ReFormat()
            'Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.Rows.Count + 1
            Me.txtCargoSequence.Text = 1 'Me.dgdDetailBillOfLading_House.Rows.Count + 1
            'If Me.txtCargoSequence.Text = "0" Then
            Me.txtDescription.Enabled = True
            'End If

            Me.lblDescription.Enabled = True
            'Me.txtClauseOfService.Enabled = True
            Me.dgdDetailBillOfLading_House.Enabled = False
            reText(mStatus)
            Me.cmdOK.Enabled = True
            'Me.QueryContainer()

            'If gBillOfLading_HouseNumber = "No BillNumber." Then
            'Me.txtBillOfLadingId.Text = Me.cboBillofLading_House.Text.Trim
            'End If
            Me.cboCTN_NO.Text = ""
            Me.cboSealNo.Text = ""
            Me.txtAmount.Text = "0"
            Me.txtGross.Text = "0"
            Me.txtMeas.Text = "0"
            Me.txtWeek.Text = ""
            Me.txtReeferDegree.Text = ""
            Me.txtNote.Text = ""
            Me.txtWeek.Text = WeekOfYear()

            'If Not gBillOfLading_HouseNumber = "No BillNumber." Then
            '    QueryBillOfLading_House(, , 0)
            'End If
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.TabCargo.Visible = False
        Me.txtDescription.Enabled = False
        Me.lblDescription.Enabled = False
        'Me.txtClauseOfService.Enabled = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdDetailBillOfLading_House.Enabled = True
        Me.cmdOK.Enabled = False
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    Public Function totalGross() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            For i = 0 To oTableDetailBillOfLading_House.Rows.Count - 1
                total = total + oTableDetailBillOfLading_House.Rows(i).Item("Gross")
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function
    Public Function totalVolume() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            For i = 0 To oTableDetailBillOfLading_House.Rows.Count - 1
                total = total + oTableDetailBillOfLading_House.Rows(i).Item("CTN_CARGO_MEASUREMENT")
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function

    Public Function totalPackage() As Double
        On Error GoTo Err_Renamed
        Dim i As Integer
        Dim total As Double
        total = 0
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            For i = 0 To oTableDetailBillOfLading_House.Rows.Count - 1
                total = total + oTableDetailBillOfLading_House.Rows(i).Item("Amount")
            Next
        End If
        Return total
        Exit Function
Err_Renamed:
        msgbox(err.Description)
    End Function

    Private Sub smnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
     Me.dgdDetailBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdDetailBillOfLading_House.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryDetailBillOfLading_House(" And Cargo_House.BLH_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "'")
    End Sub

    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryDetailBillOfLading_HouseList As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        strQuery = "Select count(*) cnt from FREIGHT_CHARGE_HOUSE WHERE BLH_Id = '" & Me.dgdDetailBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'  and Continued=1 And Container_TYPE='" & Me.txtContainerType.Text.Trim & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The Containers can not be removed. There are transactions that relate to this Price Bill Of Lading.")
            Exit Sub
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading_House.Item("Approve", index)) Then
            If Me.dgdDetailBillOfLading_House.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading_House.Item("Editable", index)) Then
            If Not Me.dgdDetailBillOfLading_House.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingHouse", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container No: " & Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillOfLading_HouseList = "Select * from Cargo_House where" + " BLH_ID= '" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "'AND CargoHouse_Id= '" & Me.dgdDetailBillOfLading_House.Item("CargoHouse_ID", index).Value.ToString & "'"
                rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                Me.dgdDetailBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdDetailBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub
    '    Public Sub DeleteRowP(ByVal index As Integer)
    '        On Error GoTo Err_Renamed
    '        Dim rs As New ADODB.Recordset
    '        Dim strQuery As String
    '        Dim blnEmpty As Boolean
    '        ' Xác định vị trí row trong grid
    '        'Dim index As Integer = Me.BindingContext(oTable).Position

    '        If Not IsNothing(Me.dgdPrice.Item("ApproveP", index).Value) Then
    '            If Me.dgdPrice.Item("ApproveP", index).Value Then
    '                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '                Exit Sub
    '            End If
    '        End If
    '        If Not IsNothing(Me.dgdPrice.Item("EditableP", index).Value) Then
    '            If Not Me.dgdPrice.Item("EditableP", index).Value Then
    '                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '                Exit Sub
    '            End If
    '        End If
    '        Dim strMesg As String
    '        Dim bm As Short
    '        If Not UserRight("frmListBillOfLadingHouse", "Delete") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '        Else
    '            strMesg = "Delete the Detail of Price: " & Me.dgdPrice.Item("Items", index).Value.ToString
    '            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
    '                strQuery = "Select * from FREIGHT_CHARGE_HOUSE where FREIGHT_CHARGES_HOUSE_ID='" & Me.dgdPrice.Item("FREIGHT_CHARGES_HOUSE_ID", index).Value.ToString & "'"
    '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '                rs.Fields("continued").Value = 0
    '                rs.Update()

    '                Me.dgdPrice.Rows(index).DefaultCellStyle.ForeColor = Color.White
    '                Me.dgdPrice.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
    '                rs.Close()
    '                blnUpdated = True
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '    End Sub

    Private Sub cboBillofLading_House_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillofLading_House.Leave
        On Error GoTo Err_Renamed
        Dim strSql As String
        Me.cboBillofLading_House.Text = Trim(UCase(Me.cboBillofLading_House.Text))
        strSql = "Select BLH_No as BLh_No From BillOfLading_House Where Continued=1"
        If Me.cboBillofLading_House.FindStringExact(Me.cboBillofLading_House.Text) = -1 Then
            Me.cboBillofLading_House.Text = FindBetter_new("blH_no", strSql, Me.cboBillofLading_House.Text)
            If Me.cboBillofLading_House.FindStringExact(Me.cboBillofLading_House.Text) = -1 Then
                DisplayMessage(True, "The B/L is invalid, please check and correct it.")
                Me.cboBillofLading_House.Focus()
            End If
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub


    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillofLading_House.TextChanged
        'If Me.cboBillOfLading_House.FindStringExact(Me.cboBillOfLading_House.Text) = -1 Then
        '    Me.cboBillOfLading_House.SelectedIndex = 0
        'End If
    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtSHIPPERNAME.Text)
    '        If Me.txtSHIPPERNAME.Text <> "" Then
    '            Select Case cboBillOfLading_House.Text
    '                Case "BillOfLading_HouseId"
    '                    QueryBillOfLading_House("AND ( BillOfLading_House.BillOfLading_HouseId LIKE '" & strFilter & "') " & mFilter)
    '                Case "ShipperName"
    '                    QueryBillOfLading_House("AND (Shipper.Name LIKE '" & strFilter & "') " & mFilter)
    '                Case "ConsigneeName"
    '                    QueryBillOfLading_House("AND (Consignee.Name LIKE '" & strFilter & "') " & mFilter)
    '                Case "NotifyName"
    '                    QueryBillOfLading_House("AND (Notify.Name LIKE '" & strFilter & "') " & mFilter)
    '            End Select
    '        Else
    '            QueryBillOfLading_House(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '    End Sub

    Private Sub dgdDetailBillOfLading_House_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDetailBillOfLading_House.CellClick
        Dim index As Integer
        If Me.dgdDetailBillOfLading_House.RowCount = 0 Then
            Return
        End If
        index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        'Me.txtBillOfLadingId.Text = Me.dgdDetailBillOfLading_House.Item("BILL_NO", index).Value.ToString
        'Me.txtContainerNoP.Text = Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString
        'Me.txtContainerKindP.Text = Me.dgdDetailBillOfLading_House.Item("ContainerType", index).Value.ToString
        CtainerID_P = Me.dgdDetailBillOfLading_House.Item("Container_ID", index).Value.ToString

        'Me.txtBillOfLadingId.Text = Me.dgdDetailBillOfLading_House.Item("Bill_No", index).Value.ToString
        'Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading_House.Item("ClauseOfservice", index).Value.ToString

        'QueryPrice(, index)
    End Sub

    Private Sub dgdDetailBillOfLading_House_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDetailBillOfLading_House.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdDetailBillOfLading_House.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdDetailBillOfLading_House.Columns(ColIndex).Name = "Approve" And Me.dgdDetailBillOfLading_House.CurrentCellAddress.Y = RowIndex Then
            Call ApproveDetailBillOfLading_House()
            QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
        End If
        Exit Sub
Err_Renamed:
        msgbox(err.Description)
    End Sub


    'Private Sub chkOther_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.chkStandard.Checked = Not Me.chkOther.Checked()
    '    If Me.chkStandard.Checked Then
    '        Me.lblKind.Visible = True
    '        Me.cboKind.Visible = True
    '        Me.lblKind.Visible = False
    '        Me.txtKind.Visible = False
    '    End If
    '    If Me.chkOther.Checked Then
    '        Me.lblKind.Visible = True
    '        Me.txtKind.Visible = True

    '        Me.cboKind.Visible = False
    '    End If
    'End Sub

    'Private Sub chkStandard_CheckedChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.chkOther.Checked = Not Me.chkStandard.Checked
    '    If Me.chkStandard.Checked Then
    '        Me.lblKind.Visible = True
    '        Me.cboKind.Visible = True
    '        Me.txtKind.Visible = False
    '    End If
    '    If Me.chkOther.Checked Then
    '        Me.lblKind.Visible = True
    '        Me.txtKind.Visible = True
    '        Me.cboKind.Visible = False
    '    End If

    'End Sub

    Private Sub txtAmount_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.Leave
        If txtAmount.Text = "" Then
            txtAmount.Text = 0
        End If
        If Not Char.IsNumber(Me.txtAmount.Text) Then
            DisplayMessage(True, "The Description is invalid. Please check again.")
            Me.txtAmount.Focus()
        Else
            If CInt(Me.txtAmount.Text) < 0 Then
                DisplayMessage(True, "The Description is invalid. Please check again.")
                Me.txtAmount.Focus()
            End If
        End If
        If Me.txtAmount.Text.Trim = "0" Or Me.txtAmount.Text = "" Then
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
            Me.txtGross.Text = FormatString(CDbl(Me.txtGross.Text))
        End If
    End Sub

    Private Sub txtGross_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGross.TextChanged
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
        End If
    End Sub

    Private Sub txtMeas_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeas.Leave
        If txtMeas.Text = "" Then
            txtMeas.Text = 0
        End If
        If Not Char.IsNumber(Me.txtMeas.Text) Then
            DisplayMessage(True, "The Meas is invalid. Please check again.")
            Me.txtMeas.Focus()
            'Else
            '    If CDbl(Me.txtGross.Text) < 0 Then
            '        DisplayMessage(True, "The Gross is invalid. Please check again.")
            '        Me.txtGross.Focus()
            '    End If
        Else
            Me.txtMeas.Text = FormatString(CDbl(Me.txtMeas.Text))
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
    '            If mStatusP = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLading_HouseMaster", "Edit") Then
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
    '        msgbox(err.Description)
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
    '    Function InsertPrice_House(ByVal indexbill As Integer) As Boolean
    '        Dim rsHBL, rs As New ADODB.Recordset
    '        Dim strQuery As String = "SELECT * "
    '        strQuery = strQuery & "FROM BillOfLading_House_HOUSE "
    '        strQuery = strQuery & "WHERE BLH_ID = '" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "'"
    '        rsHBL.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        If rsHBL.EOF Then
    '            Return False
    '        End If
    '        rsHBL.MoveFirst()
    '        While Not rsHBL.EOF
    '            strQuery = "Select * from PRICEBILLHOUSE where BLH_ID='" & rsHBL.Fields("BLH_ID").Value.ToString & "' And BLH_ID <>'" & DefaultValue & "'"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            With rs
    '                If rs.EOF Then
    '                    .AddNew()
    '                    .Fields("PriceHouse_ID").Value = NewId()
    '                    .Fields("Price_ID").Value = mPrice_ID
    '                    Dim temp As String
    '                    'If mStatusP = "Edit" Then
    '                    '    temp = "{" + Trim(Me.dgdPrice.Item("DetailBillOfLading_HouseIdP", index).Value.ToString) + "}"
    '                    'Else
    '                    temp = "{" & Trim(Me.dgdDetailBillOfLading_House.Item("Cargo_ID", indexbill).Value.ToString) & "}"
    '                    'End If
    '                    .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "}"
    '                    .Fields("CTN_ID").Value = "{" & CtainerID & "}"
    '                    .Fields("Cargo_ID").Value = temp
    '                    .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString
    '                    .Fields("Items").Value = Me.cboItems.Text
    '                End If
    '                .Fields("Currency").Value = Me.cboCurrency.Text
    '                .Fields("UnitPrice").Value = Me.txtUnitPrice.Text
    '                .Update()
    '            End With
    '            rs.Close()
    '            rsHBL.MoveNext()
    '        End While
    '    End Function

    '    Private Sub cmdOKP_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        If mStatusP = "Add" Or mStatusP = "Edit" Then

    '            If Me.cboItems.FindStringExact(Me.cboItems.Text) = -1 Then
    '                DisplayMessage(True, "The Item is invalid. ")
    '                Me.cboItems.Focus()
    '                Exit Sub
    '            End If
    '            If Me.cboCurrency.FindStringExact(Me.cboCurrency.Text) = -1 Then
    '                DisplayMessage(True, "The Currency is invalid. ")
    '                Me.cboCurrency.Focus()
    '                Exit Sub
    '            End If
    '            If Len(Me.txtUnitPrice.Text) = 0 Then
    '                DisplayMessage(True, "The Price is invalid. ")
    '                Me.cboCurrency.Focus()
    '                Exit Sub
    '            End If
    '            Dim strQuery, str, Cargo_ID As String
    '            Dim rs As New ADODB.Recordset
    '            Dim index As Integer = -1
    '            If Me.dgdPrice.RowCount > 0 Then
    '                index = Me.dgdPrice.CurrentRow.Index()
    '            End If

    '            Dim indexBill As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index()

    '            'If indexBill >= 0 Then
    '            '    Cargo_ID = Me.dgdDetailBillOfLading_House.Item("Cargo_ID", indexBill).Value.ToString
    '            'Else
    '            '    'Cargo_ID = DefaultValue
    '            '    Exit Sub
    '            'End If
    '            strQuery = "Select * from FREIGHT_CHARGE_House where charge_ID='" & FindValueID(Me.cboItems, Me.cboItems.Text) & "' And Continued=1"
    '            strQuery = strQuery & " And BLH_id='" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "' And Container_type='" & Me.cboContainerType.Text.Trim & "'and upper(Prepaid_Collect)='" & UCase(Me.cboPrepaidOrCollect.Text.Trim) & "'"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '            If Not rs.EOF And mStatusP = "Add" Then
    '                DisplayMessage(True, "This Item Had Added ")
    '                Exit Sub
    '            End If
    '            rs.Close()
    '            strQuery = "Select * from FREIGHT_CHARGE_House where FREIGHT_CHARGES_House_ID='" & FreightChargeHouseID & "' And Continued=1"
    '            'strQuery = strQuery & " And BLH_ID='" & BillHouseID & "'"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


    '            With rs
    '                If mStatusP = "Add" Then
    '                    .AddNew()
    '                    .Fields("FREIGHT_CHARGES_House_ID").Value = NewId()
    '                    'Dim temp As String

    '                    'temp = "{" & Trim(Me.dgdDetailBillOfLading_House.Item("Cargo_ID", indexBill).Value.ToString) & "}"

    '                    '.Fields("CTN_ID").Value = "{" & Me.dgdDetailBillOfLading.Item("Container_ID", indexBill).Value.ToString & "}"
    '                    .Fields("BLH_ID").Value = "{" & FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) & "}"

    '                End If

    '                .Fields("PAYABLE_AT_ID").Value = "{" & FindValueID(Me.cboPayableCode, Me.cboPayableCode.Text) & "}"
    '                .Fields("CHARGE_ID").Value = "{" & FindValueID(Me.cboItems, Me.cboItems.Text) & "}"
    '                mPrice_ID = .Fields("FREIGHT_CHARGES_House_ID").Value

    '                .Fields("IG_CODE").Value = Me.txtIGCode.Text

    '                '.Fields("AMOUNT").Value = Me.txtAmount.Text
    '                .Fields("CONTAINER_TYPE").Value = Me.cboContainerType.Text
    '                '.Fields("UNIT").Value = Me.txtUnit.Text

    '                .Fields("PREPAID_COLLECT").Value = Me.cboPrepaidOrCollect.Text
    '                .Fields("POP").Value = Me.txtPOP.Text
    '                .Fields("PAYER_CODE").Value = Me.txtPayerCode.Text
    '                '.Fields("QUANTITY").Value = Me.txtQuantity.Text
    '                '.Fields("RATE_OF_FR_CH").Value = Me.txtRateFreightCharge.Text
    '                .Fields("UNIT_OF_QUANTITY").Value = Me.txtQuantityUnit.Text
    '                .Fields("Currency").Value = Me.cboCurrency.Text
    '                .Fields("AMOUNT").Value = Me.txtUnitPrice.Text
    '                .Update()

    '                'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
    '                'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

    '            End With
    '            rs.Close()
    '            'If mStatus = "Add" Then
    '            '    InsertPrice_House(indexBill)
    '            'End If

    '            '-----------------
    '            ReFreshFreight(False)
    '            'mStatusP = "Normal"
    '            Me.dgdPrice.Enabled = True
    '            mStatusP = "Normal"
    '            Me.cmdOKP.Enabled = False
    '            QueryPrice(, )
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '        'Resume
    '    End Sub


    '    Public Sub ApprovePrice()
    '        On Error GoTo Err_Renamed
    '        Dim Approve As Boolean
    '        ' Xác định vị trí row trong grid
    '        Dim rs As New ADODB.Recordset
    '        Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '        Dim strQuery As String
    '        If Not Me.dgdPrice.Item("Editable", index).Value Or Not UserRight("frmListBillOfLadingHouse", "Approve") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            QueryPrice(, index)
    '        Else
    '            strQuery = "select * from FREIGHT_CHARGE_House where FREIGHT_CHARGES_House_ID='" & Me.dgdPrice.Item("FREIGHT_CHARGES_House_ID", index).Value.ToString & "'"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            Approve = Not rs.Fields("Approve").Value
    '            rs.Update("Approve", Approve)
    '            rs.Close()
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        msgbox(err.Description)
    '    End Sub

    'Private Sub dgdPrice_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPrice.CellClick
    '    If Me.dgdPrice.RowCount = 0 Then
    '        Me.ctmnuDel.Enabled = False
    '        Me.ctmnuEdit.Enabled = False
    '    Else
    '        Me.ctmnuDel.Enabled = True
    '        Me.ctmnuEdit.Enabled = True
    '    End If
    'End Sub

    '    Private Sub dgdPrice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '        Dim ColIndex, RowIndex As Integer
    '        ' Xác định vị trí row trong grid
    '        Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '        On Error GoTo Err_Renamed
    '        ColIndex = e.ColumnIndex()
    '        RowIndex = e.RowIndex
    '        If ColIndex < 0 Then
    '            Return
    '        End If
    '        'MsgBox(Me.dgdPrice.CurrentCellAddress.X)
    '        If Me.dgdPrice.CurrentCellAddress.X = 17 And Me.dgdPrice.CurrentCellAddress().Y = RowIndex Then
    '            Call ApprovePrice()
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(Err.Description)
    '    End Sub

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
            WeekOfYear = myCal.GetWeekOfYear(CDate(Me.DateTimePicker.Text), myCWR, myFirstDOW)
        Else
            WeekOfYear = 0
        End If

        Exit Function
Err_Renamed:
        MsgBox(Err.Description)
        'Resume
    End Function

    Private Sub cboBillOfLading_House_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillofLading_House.SelectedIndexChanged
        Dim BillHouse_ID As String

        BillHouse_ID = FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text)
        'MsgBox(Me.dgdDetailBillOfLading_House.Item("Cargo_id", 0).Value.ToString)
        mFilter = " And BillOfLading_House.BLH_ID='" & BillHouse_ID & "'"
        QueryDetailBillOfLading_House(mFilter, 14)
        If BillHouse_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "select ContainerOutboundNotify.SERVICECONTRACT as SERVICECONTRACT,SHIPPER_1,Shipper.Shipper_ID,BillOFLading_House.Shipper_ID,BillOflading_House.BLH_ID as BLH_ID" & _
            " from ((SHIPPER LEFT JOIN  BillOfLading_House ON BillofLading_House.Shipper_ID=Shipper.Shipper_ID) " & _
            " LEFT JOIN ContainerOutboundNotify On ContainerOutBoundNotify.ContainerOutboundNotifyID=BillOfLading_House.ContainerOutboundNotifyID) where BLH_ID='" & BillHouse_ID & "'"
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
                'Me.txtClauseOfService.Text = table.Rows(0).Item("SERVICECONTRACT").ToString
                'Me.txtBillOfLadingId.Text = Me.cboBillofLading_House.Text
                ' BillHouseID = BillHouse_ID
            End If

            'Me.txtBillOfLading_HouseId.Text = BillhouseID

        End If
    End Sub

    Private Sub cboCTN_NO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCTN_NO.Leave
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

    Private Sub cboCTN_NO_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboCTN_NO.MouseClick
        On Error GoTo Err_Named
        If mStatus = "Edit" Then
            Dim index As Integer
            If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
                index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            End If

            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            Dim blnEmpty As Boolean
            strQuery = "Select count(*) cnt from Freight_Charge_House WHERE Container_Type = '" & Me.txtContainerType.Text.Trim & "'  and Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            blnEmpty = (rs.Fields("cnt").Value = 0)
            rs.Close()
            If Not blnEmpty Then
                DisplayMessage(True, "The Containers Kind can not be Change. There are Prieght Charge that relate to This Kind Container .")

                If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
                    index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
                    Me.cboCTN_NO.Text = Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString.Trim
                End If

                Exit Sub
            End If
        End If
        Exit Sub
Err_Named:
        DisplayMessage(True, Err.Description & " at Container no Mouse Click _HouseCargo")
    End Sub



    Private Sub cboCTN_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCTN_NO.SelectedIndexChanged

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

        End If
        Exit Sub
Err_Named:
        MsgBox(Err.Description)
    End Sub

    'Private Sub chkStandard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkStandard.CheckedChanged
    '    Me.cboKind.Visible = Me.chkStandard.Checked
    '    Me.txtKind.Visible = Not Me.chkStandard.Checked

    'End Sub

    '    Sub ReFreshFreight(ByVal b As Boolean)
    '        On Error GoTo Err_named
    '        'Me.cboContainerType.Enabled = b
    '        'Me.cboItems.Enabled = b
    '        'Me.cboPayableCode.Enabled = b
    '        'Me.cboCurrency.Enabled = b
    '        Me.cboPrepaidOrCollect.Enabled = b
    '        ' Me.txtQuantity.Enabled = b
    '        Me.txtQuantityUnit.Enabled = b
    '        'Me.txtRateFreightCharge.Enabled = b
    '        Me.txtPayerCode.Enabled = b
    '        Me.txtUnitPrice.Enabled = b
    '        Me.txtIGCode.Enabled = b
    '        Me.txtQuantity.Enabled = b
    '        Me.cmdOKP.Enabled = b
    '        Me.txtPOP.Enabled = b
    '        Exit Sub
    'Err_named:
    '        MsgBox(Err.Description)
    '    End Sub

    '    Private Sub ctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAdd.Click
    '        On Error GoTo Err_Named
    '        If mCargo_ID = DefaultValue Then
    '            MsgBox("Please, Sorry")
    '            Me.TabCargo.SelectedIndex = 0
    '            Return
    '        End If
    '        mStatusP = "Add"
    '        FreightChargeHouseID = DefaultValue
    '        ReFreshFreight(True)
    '        Exit Sub
    'Err_Named:
    '        DisplayMessage(True, Err.Description & "ctmnu ADD")
    '        'Me.cmdOKP.Text = "Add"
    '    End Sub

    '    Private Sub ctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEdit.Click
    '        On Error GoTo Err_named
    '        Dim index As Integer

    '        If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
    '            index = Me.dgdPrice.CurrentRow.Index
    '        Else
    '            Exit Sub
    '        End If
    '        If Not IsNothing(Me.dgdPrice.Item("ApproveP", index).Value) And UserRight("frmListBillOfLadingHouse", "Edit") Then
    '            If Me.dgdPrice.Item("ApproveP", index).Value Then
    '                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '                Exit Sub
    '            End If
    '        End If
    '        mStatusP = "Edit"

    '        ReFreshFreight(True)
    '        FreightChargeHouseID = Me.dgdPrice.Item("FREIGHT_CHARGES_HOUSE_ID", index).Value.ToString
    '        Me.cboContainerType.Text = Me.dgdPrice.Item("ContainertypeP", index).Value.ToString
    '        Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString.Trim
    '        Me.cboItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
    '        Me.cboPayableCode.Text = FindIDValue(Me.cboPayableCode, Me.dgdPrice.Item("PAYABLE_AT_ID", index).Value.ToString)
    '        Me.cboCurrency.Text = Me.dgdPrice.Item("CurrencyP", index).Value.ToString
    '        Me.cboPrepaidOrCollect.Text = Me.dgdPrice.Item("PREPAID_COLLECT", index).Value.ToString
    '        'Me.txtQuantity.Text = Me.dgdPrice.Item("QUANTITY", index).Value.ToString
    '        Me.txtQuantityUnit.Text = Me.dgdPrice.Item("UNIT_OF_QUANTITY", index).Value.ToString
    '        'Me.txtRateFreightCharge.Text = Me.dgdPrice("RATE_OF_FR_CH", index).Value.ToString
    '        Me.txtPayerCode.Text = Me.dgdPrice("PAYER_CODE", index).Value.ToString
    '        Me.txtUnitPrice.Text = Me.dgdPrice.Item("AMOUNTP", index).Value.ToString
    '        Me.txtIGCode.Text = Me.dgdPrice.Item("IG_CODE", index).Value.ToString
    '        Exit Sub
    'Err_named:
    '        MsgBox(Err.Description)
    '    End Sub


    '    Private Sub ctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel.Click
    '        On Error GoTo Err_Named
    '        Dim selectedRowCount As Integer = _
    '  Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
    '        If selectedRowCount >= 0 Then
    '            Dim sb As New System.Text.StringBuilder()
    '            Dim i As Integer
    '            For i = 0 To selectedRowCount - 1
    '                DeleteRowP(Me.dgdPrice.SelectedRows(i).Index)
    '            Next i
    '        End If
    '        Dim index As Integer = 0
    '        If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
    '            index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '        End If
    '        QueryPrice(, index)
    '        Exit Sub
    'Err_Named:
    '        DisplayMessage(False, Err.Description)
    '    End Sub





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

    Private Sub dgdDetailBillOfLading_House_CellContentClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDetailBillOfLading_House.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index

        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdDetailBillOfLading_House.CurrentCellAddress().X = 49 And Me.dgdDetailBillOfLading_House.CurrentCellAddress().Y = index Then
            Call ApproveDetailBillOfLading_House()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(Err.Description)
    End Sub

    Private Sub TabCargo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCargo.SelectedIndexChanged
        On Error GoTo Err_named
        If TabCargo.SelectedIndex = 3 Then
            If Not UserRight("frmListBillOfLadingMaster", "Execute") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                TabCargo.SelectedIndex = 0
                Exit Sub
            Else
                Dim index As Integer
                DisplayMessage(True, "Lưu ý: bạn phải nhập xong Container, sau đó bạn mới nhập giá cho từng loại Container!")
                If (Me.dgdDetailBillOfLading_House.RowCount > 0) Then
                    index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
                    'QueryContainer()
                    'Me.dgdPrice.Columns("").Visible = False
                    'QueryPrice(, index)
                End If
            End If

        End If
        Exit Sub
Err_named:
        MsgBox(Err.Description)
    End Sub

    Private Sub TabControl1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCargo.VisibleChanged
        'Me.fraBillNo.Visible = Me.TabCargo.Visible
        'Me.fraTotal.Visible = Me.TabCargo.Visible
        Me.txtDescription.Visible = Me.TabCargo.Visible
        Me.lblDescription.Visible = Me.TabCargo.Visible
        ' Me.cmdCancel.Visible = Me.TabCargo.Visible
        ' Me.cmdOK.Visible = Me.TabCargo.Visible
        Me.cmdOK.Visible = Me.TabCargo.Visible
        Me.cmdCancel.Visible = Me.TabCargo.Visible
        Me.cboBillofLading_House.Enabled = Not Me.TabCargo.Visible


        Exit Sub
        ' Me.fraPrice.Visible = Me.TabCargo.Visible
    End Sub

    '    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Named
    '        ReFreshFreight(False)
    '        Exit Sub
    'Err_Named:
    '        MsgBox(Err.Description)
    '    End Sub


    '    Private Sub cboContainerType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Named
    '        Dim Bill As String
    '        Bill = FindValueID(Me.cboContainerType, Me.cboContainerType.Text).Trim
    '        If Bill <> "" Then
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Dim dset As New DataSet
    '            Dim table As New DataTable
    '            Dim strSQL As String = "select Count(Container_TYPE) As Num from Cargo_House "
    '            strSQL &= " Where BLH_ID='" & Bill & "' And Continued=1 "
    '            strSQL &= " And Container_Type='" & Me.cboContainerType.Text.Trim & "' Group By Container_TYPE "
    '            Dim CmdSelect As New SqlClient.SqlCommand(strSQL, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '            '-----------------

    '            'If Not IsNothing(oTable) Then
    '            '    oTable.Clear()
    '            'End If
    '            Adapter.Fill(dset, "Unit")
    '            table = dset.Tables(0)
    '            'If table.Rows.Count > 0 Then
    '            '    Me.txtUnit.Text = table.Rows(0).Item("Num").ToString
    '            'End If

    '            Dim index As Integer
    '            If Me.dgdPrice.Rows.Count > 0 Then
    '                If IsNothing(Me.dgdPrice.CurrentRow) Then
    '                    Exit Sub
    '                End If
    '                index = Me.dgdPrice.CurrentRow.Index
    '                QueryPrice(, index)
    '            End If

    '            If Me.TabCargo.Visible = True Then 'UCase(Me.TabCargo.SelectedTab.Name) = "TABCONTAINERPRICE" Then
    '                Dim CountContainer As Integer = 0
    '                For i As Integer = 0 To Me.dgdDetailBillOfLading_House.RowCount - 1
    '                    If Me.dgdDetailBillOfLading_House.Item("ContainerType", i).Value.ToString = Me.cboContainerType.Text And Me.dgdDetailBillOfLading_House.Item("BLH_ID", i).Value.ToString.Trim = FindValueID(Me.cboBillofLading_House, Me.cboBillofLading_House.Text) Then
    '                        CountContainer += 1
    '                    End If
    '                Next
    '                Me.txtQuantity.Text = CountContainer
    '            End If
    '        End If
    '        Exit Sub
    'Err_Named:
    '        DisplayMessage(True, Err.Description & "Container Type")
    '    End Sub


    Private Sub txtReeferDegree_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReeferDegree.Leave
        Me.txtTempSetting.Text = Me.txtReeferDegree.Text
    End Sub

    '    Private Sub cboPayableCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.cboPayableCode.Text = Trim(UCase(Me.cboPayableCode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.cboPayableCode.FindStringExact(Me.cboPayableCode.Text) = -1 Then
    '            Me.cboPayableCode.Text = FindBetter_new("code", strSql, Me.cboPayableCode.Text)
    '            If Me.cboPayableCode.FindStringExact(Me.cboPayableCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.cboPayableCode.Focus()
    '            End If
    '        End If
    '        Me.cboPayableCode_SelectedIndexChanged(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(Err.Description)
    '    End Sub

    '    Private Sub cboPayableCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.cboPayableCode, Me.cboPayableCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPOP.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(Err.Description)
    '    End Sub

    Private Sub cboSealNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSealNo.Leave
        On Error GoTo Err_Renamed
        'Dim strSql, Port_code As String
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
        MsgBox(Err.Description)
    End Sub

    Private Sub cboSealNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSealNo.SelectedIndexChanged

    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = frmListCargoHouse.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryDetailBillOfLading_House("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdDetailBillOfLading_House, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdDetailBillOfLading_House_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDetailBillOfLading_House.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading_House)
    End Sub

    'Private Sub dgdPrice_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    InsertAutoNumberToGrid(Me.dgdPrice)
    'End Sub

    Private Sub txtAmount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged

    End Sub

    'Private Sub cxtsmnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSearch.Click
    '    Try
    '        If Me.dgdDetailBillOfLading_House.RowCount = 0 Then
    '            Return
    '        End If
    '        Me.grpFind.Visible = True
    '        Me.cboFind.Text = FindIDValue(Me.cboFind, Me.dgdDetailBillOfLading_House.Columns(Me.dgdDetailBillOfLading_House.CurrentCell.ColumnIndex).Name)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.txtFind.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtFind.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdDetailBillOfLading_House)
    '        End If
    '        Me.grpFind.Visible = False
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Me.grpFind.Visible = False
    '    End Try
    'End Sub

    'Private Sub txtFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Try
    '        If e.KeyCode = Keys.Enter Then
    '            Me.cmdFind.PerformClick()
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub dgdDetailBillOfLading_House_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDetailBillOfLading_House.RowHeaderMouseClick
        Try
            Dim index As Integer
            If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
                index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            Else
                Exit Sub
            End If
            Me.cboBillofLading_House.Text = Me.dgdDetailBillOfLading_House.Item("Bill_No", index).Value.ToString.Trim
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


    Private Sub txtMeas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMeas.TextChanged

    End Sub
    Private Sub chkReceiveDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReceiveDate.CheckedChanged
        If Me.chkReceiveDate.Checked = True Then
            Me.DateTimePicker.Enabled = True
        Else
            Me.DateTimePicker.Enabled = False
        End If
    End Sub
End Class
