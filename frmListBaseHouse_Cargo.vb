Imports System.IO
Imports System.Globalization
Public Class frmListBaseHouse_Cargo

    '------
    '-------

#Region " Biến Cargo"

    Public LoadCargoHouse As Boolean = False
    Dim mCargoHouseStatus, mCargoHouseStatusP, mCargoHouseContainerID, mCargoHouseFilter As String
    Public mCopy, Check_CTNChanged As Boolean
    Public mCargo_ID, mCargoMarks_ID, mCargoRemarks_ID, mCargoDesc_ID, mCargoHouseDesc_ID As String
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

#End Region

    Dim TextName As Object
    Dim rsBILLOFLADING_HOUSEList As New ADODB.Recordset
    Dim mStatus, mStatusP, mStatusR, mFilter, ROUTINGID, FreightChargeID, gBillHID As String
    Dim POL_ID, POD_ID, DEL_ID, POR_ID, DEST_ID, POI_ID, PortFrom_ID, PortTo_ID As String
    Dim mBL_ClauseID As String = DefaultValue
    Public Checking As Integer = 0
    Dim ShipperID, ConsigneeID, NotifyID, Notify2ID, Notify3ID, PLACEOFRECEIPTID, LOADPORTID As String
    Dim TRADECODEID, PORTOFDISCHARGEID, PLACEOFDELIVERYID, PLACEOFDESTINATIONID As String
    Dim PLACEOFBLISSUEID, PORTOFLOADINGID, BillHouseID As String

    Public blnUpdated As Boolean
    Public mBILLOFLADING_HOUSEId, mChargeID, mPrice_ID As String

    Public oTableCustomerInfo As DataTable
    Dim oTableFreightCharge As New DataTable
    Public dsCustomerInfo As New DataSet
    Dim dst As New DataSet
    '    '------------------
    Public oTablePrice As DataTable
    Public dsPrice As New DataSet
    Public oTable As DataTable
    Public ds As New DataSet
    '+ Shipper.SHIPPER_2 + Shipper.SHIPPER_3 + Shipper.SHIPPER_4 + Shipper.SHIPPER_5 + Shipper.SHIPPER_6
    '+ Consignee.CONSIGNEE_2 + Consignee.CONSIGNEE_3 + Consignee.CONSIGNEE_4 + Consignee.CONSIGNEE_5 + Consignee.CONSIGNEE_6
    '+ Notify.NOTIFY_2 + Notify.NOTIFY_3 + Notify.NOTIFY_4 + Notify.NOTIFY_5 + Notify.NOTIFY_6
    Const strBILLOFLADING_HOUSESelect As String = "SELECT BILLOFLADING_HOUSE.BL_ID as BL_ID,ContainerOutBoundNotify.BookingNo,BILLOFLADING_HOUSE.BLH_NO as BLH_NO,BILLOFLADING_HOUSE.NVOCC_MASTER_BL_NO,BILLOFLADING_HOUSE.SHIPPER,BILLOFLADING_HOUSE.CONSIGNEE,BILLOFLADING_HOUSE.Notify, " & _
        "containerOutboundNotify.carrier as PreVessel,containerOutboundNotify.VoyNo as PreVoyNo,BILLOFLADING_HOUSE.BLH_ID as BLH_ID,  " & _
        " Payer,convert(bit,Checking) as Checking," & _
        "  " & _
        " " & _
        "" & _
        "BillOfLading_House.CANVASSERCODE," & _
        "BILLOFLADING_HOUSE.PLACE_OF_RECEIPT_ID AS PLACE_OF_RECEIPT_ID, BILLOFLADING_HOUSE.PLACE_OF_RECEIPT_CODE, PLACE_OF_RECEIPT_NAME, " & _
        "BILLOFLADING_HOUSE.BL_CY_CFS_ITEM,BILLOFLADING_HOUSE.PREPAID_OR_COLLECT,BILLOFLADING_HOUSE.LOAD_DATE,BILLOFLADING_HOUSE.QUARANTINE_CODING,BILLOFLADING_HOUSE.DATE_OF_ISSUE,BILLOFLADING_HOUSE.CURRENCY, " & _
        "BILLOFLADING_HOUSE.EXCHANGE_RATE,SCAC_CODE,BILLOFLADING_HOUSE.REVENUETON, BILLOFLADING_HOUSE.DESCRIPTIONFORSHIPPER, " & _
        "BILLOFLADING_HOUSE.TRADE_CODE_ID AS TRADE_CODE_ID,BILLOFLADING_HOUSE.TRADE_CODE,BILLOFLADING_HOUSE.PREPAIDAT, " & _
         "BILLOFLADING_HOUSE.PORT_OF_LOADING_ID AS PORT_OF_LOADING_ID,BILLOFLADING_HOUSE.PORT_OF_LOADING_CODE AS PORT_OF_LOADING_CODE,BILLOFLADING_HOUSE.PORT_OF_LOADING_NAME AS PORT_OF_LOADING, " & _
        "BILLOFLADING_HOUSE.BL_OTHER_REF,BILLOFLADING_HOUSE.TOTALPREPAID_IN as TOTALPREPAID_IN , " & _
        "ContainerOutBoundNotify.SERVICECONTRACT As ServiceContract,BL_TYPE," & _
        "BILLOFLADING_HOUSE.PAYABLE_AT," & _
        "ContainerOutBoundNotify.SaleName As SaleName," & _
        "BILLOFLADING_HOUSE.PAYER_CODE, " & _
        "BILLOFLADING_HOUSE.NO_OF_COPY_BL, " & _
        "BILLOFLADING_HOUSE.NO_OF_ORIGINAL_BL, " & _
        "BILLOFLADING_HOUSE.CUSTOMS_CLEARED_PLACE, " & _
        "BILLOFLADING_HOUSE.SLOT_SHARE, " & _
        "BILLOFLADING_HOUSE.US_SERVICE_MODE, " & _
"BILLOFLADING_HOUSE.PREIGHTCHARGES, " & _
"BILLOFLADING_HOUSE.TOTALCONTAINER, " & _
        "BILLOFLADING_HOUSE.PORT_OF_DISCHARGE_ID AS PORT_OF_DISCHARGE_ID,BILLOFLADING_HOUSE.PORT_OF_DISCHARGE_CODE,BILLOFLADING_HOUSE.PORT_OF_DISCHARGE_NAME,  " & _
        "BILLOFLADING_HOUSE.PLACE_OF_DELIVERY_ID AS PLACE_OF_DELIVERY_ID,BILLOFLADING_HOUSE.PLACE_OF_DELIVERY_CODE,BILLOFLADING_HOUSE.PLACE_OF_DELIVERY_NAME, " & _
        "BILLOFLADING_HOUSE.PLACE_OF_DESTINATION_ID AS PLACE_OF_DESTINATION_ID,BILLOFLADING_HOUSE.PLACE_OF_DESTINATION_CODE,BILLOFLADING_HOUSE.PLACE_OF_DESTINATION_NAME,  " & _
        "BILLOFLADING_HOUSE.PLACE_OF_BL_ISSUE_ID AS PLACE_OF_BL_ISSUE_ID,BILLOFLADING_HOUSE.PLACE_OF_BL_ISSUE_CODE,BILLOFLADING_HOUSE.PLACE_OF_BL_ISSUE_NAME, " & _
        "BILLOFLADING_HOUSE.TRANSFER_PORT1,BILLOFLADING_HOUSE.TRANSFER_PORT2,BILLOFLADING_HOUSE.TRANSFER_PORT3,BILLOFLADING_HOUSE.TRANSFER_PORT4, " & _
         "BILLOFLADING_HOUSE.WEEKOFYEAR," & _
        "UserList.name as CreativeUser, Note," & _
        "BILLOFLADING_HOUSE.CreativeDate, " & _
  "convert(bit,BILLOFLADING_HOUSE.notShowDes) as NotShowDes, " & _
        "BILLOFLADING_HOUSE.Editable as Editable, " & _
        "BILLOFLADING_HOUSE.Continued as Continued, " & _
        "BILLOFLADING_HOUSE.Approve as Approve, " & _
        "BILLOFLADING_HOUSE.UserId as UserId,BillOfLading_House.BL_clauseID,BL_ClauseCode,BL_ClauseText, " & _
        "BILLOFLADING_HOUSE.Updatetime as Updatetime "

    Const strBILLOFLADING_HOUSEOrder1 As String = _
          " ORDER BY BILLOFLADING_HOUSE.BLH_NO  Desc "
    Const strBILLOFLADING_HOUSEOrder2 As String = _
        " ORDER BY BILLOFLADING_HOUSE.UpdateTime  "
    Const strPriceSelect As String = "SELECT DISTINCT " & _
" FREIGHT_CHARGE_OB.FREIGHT_CHARGE_OB as FREIGHT_CHARGES_ID, FREIGHT_CHARGE_OB.BLH_ID, " & _
"FREIGHT_CHARGE_OB.Currency as Currency, " & _
               " FREIGHT_CHARGE_OB.PrePaid_Collectagency, Items,FREIGHT_CHARGE_OB.remarks,FREIGHT_CHARGE_OB.remarkscredit,quantity," & _
         " CONTAINER_TYPE as CONTAINERTYPE,pricebuytruocthue,taxpricebuy,pricebuy,notebuy,pricebantruocthue,taxpriceban,priceban,noteban,Priceagency,FREIGHT_CHARGE_OB.PrePaid_Collectsale,Pricesale,POP_Code,FREIGHT_CHARGE_OB.tax, " & _
          "FREIGHT_CHARGE_OB.Continued, " & _
          "FREIGHT_CHARGE_OB.Editable, " & _
         "FREIGHT_CHARGE_OB.Approve, " & _
         "FREIGHT_CHARGE_OB.UserId, " & _
         "FREIGHT_CHARGE_OB.Updatetime "
    Const strPriceOrder As String = _
           " ORDER BY PriceBillHouse.UpdateTime desc "

    Const strCustomerInfo As String = "Select Shipper," & _
  "" & _
      " " & _
      "" & _
  "Consignee ," & _
      "" & _
      "" & _
      " " & _
  "Notify " & _
      "" & _
      "" & _
      "  "

#Region "GetData"

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

    '    Sub QueryPreVessel(ByVal Cbo As Object)

    '        Dim id As String = "Pre_vessel_ID"
    '        Dim value As String = "Pre_Vessel_Code"
    '        On Error GoTo Err_Renamed
    '        Dim strSQL As String
    '        strSQL = "Select Pre_Vessel_ID ,Pre_Vessel_Code From Pre_Vessel where Continued=1 Order By Pre_Vessel_Code desc"
    '        loadDataToObject(Me.cboPre_Vessel, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub


    Sub QueryRouting(Optional ByVal index As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        Dim table As New DataTable
        '----------------
        strQuery = "select * from Routing_House Where BLH_ID='" & Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' And Continued=1"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(table) Then
            table.Clear()
        End If
        Adapter.Fill(ds, "Routing")
        table = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdRouting.DataSource = table
        'If Me.dgdBillOfLading.Enabled = False Then
        '    Me.dgdBillOfLading.Enabled = True
        'End If
        '------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        'If table.Rows.Count > 0 Then
        '    Me.dgdBillOfLading.Columns.Item("BL_No").ToolTipText = "Hiện có:" + CStr(Me.dgdBillOfLading.RowCount()) + " Bills."
        'End If
        'If Me.dgdRouting.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryTradeCode(ByRef Cbo As Object, Optional ByVal id As String = "Market_ID", Optional ByVal value As String = "MarketCode", Optional ByVal rang As String = "")
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select Market_ID,MarketCode From Market where Continued=1 "
        loadDataToObject(Cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryVessel(ByRef Cbo As Object, Optional ByVal id As String = "vessel_ID", Optional ByVal value As String = "Vessel_Code", Optional ByVal rang As String = "")
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select Vessel_Code,Vessel_ID From Vessel where Continued=1 And Vessel_Code like '%" & rang & "%'"
        loadDataToObject(Cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Sub QueryItems()
    '        On Error GoTo ERR_NAMED
    '        Dim id As String = "CHARGE_ID"
    '        Dim value As String = "CHARGE_CODE"
    '        Dim strQuery As String = "Select CHARGE_ID,CHARGE_CODE from CHARGE where CONTINUED=1"
    '        loadDataToObject(Me.cboItems, strQuery, id, value)
    '        Exit Sub
    'ERR_NAMED:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Sub QueryBLOfLading()
        On Error GoTo Err_Renamed
        Dim id As String = "BL_ID"
        Dim value As String = "BL_No"
        Dim strSQL As String
        strSQL = "Select BL_ID,BL_No From BILLOFLADING where Continued=1 order by updatetime desc "
        loadDataToObject(Me.cboBillOfLading_House, strSQL, id, value)
        loadDataToObject(Me.txtMF_FilingType, strSQL, id, value)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryBLOfLadingHOuse()
        On Error GoTo Err_Renamed
        Dim id As String = "BLh_ID"
        Dim value As String = "BLh_No"
        Dim strSQL As String
        strSQL = "Select BLh_ID,BLh_No From BILLOFLADING_house where Continued=1 order by updatetime"
        loadDataToObject(Me.cboBillHouse, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryBLOfLading_h()
        On Error GoTo Err_Renamed
        Dim id As String = "BLh_ID"
        Dim value As String = "BLh_No"
        Dim strSQL As String
        strSQL = "Select BLh_ID,BLh_No From BILLOFLADING_house where Continued=1 order by updatetime"
        loadDataToObject(Me.cboFromBill, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Sub QueryBLOfLading_House()
    '        On Error GoTo Err_Renamed
    '        Dim id As String = "BL_ID"
    '        Dim value As String = "BL_No"
    '        Dim strSQL As String
    '        strSQL = "Select BL_ID,BL_No From BILLOFLADING where Continued=1 "
    '        loadDataToObject(Me.cboBillOfLading_House, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Function MakeQueryBILLOFLADING_HOUSE(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading_House = strBILLOFLADING_HOUSESelect
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " ,(select bl_no from billoflading where bl_id=billoflading_house.bl_id) as bl_no ,Mother,VoyMother,agencyname,(select Count(*) From Cargo_House where Cargo_House.BLH_ID=BillOflading_House.BLH_ID And Cargo_House.continued=1) As QuantityOfContainer "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " ,BILLOFLADING_HOUSE.air_IssuingCarriAgentName,BILLOFLADING_HOUSE.air_AgentIATACode,BILLOFLADING_HOUSE.air_AccountNo,BILLOFLADING_HOUSE.air_To1,BILLOFLADING_HOUSE.air_ByFirstCarrier,BILLOFLADING_HOUSE.air_to2,BILLOFLADING_HOUSE.air_by1,BILLOFLADING_HOUSE.air_to3,BILLOFLADING_HOUSE.air_by2,BILLOFLADING_HOUSE.air_ChgsCode,BILLOFLADING_HOUSE.air_DeclaredValueForCarriage,BILLOFLADING_HOUSE.air_DeclaredValueForCustoms,BILLOFLADING_HOUSE.air_AmountOfInsurance,BILLOFLADING_HOUSE.air_SCI,BILLOFLADING_HOUSE.air_Other,BILLOFLADING_HOUSE.air_flightVoy,BILLOFLADING_HOUSE.air_flightDate,NgayGoiBill,billoflading_house.email,ngaynhanbill,NguoiNhanBill,ngayfileams,nguoifileams,ngaygoichungtu,ngaychinhsuasaudl,noidungchinhsuasaudl,RemarksGoiBill,Amend FROM ((((BILLOFLADING_HOUSE    "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN Market ON BILLOFLADING_HOUSE.Trade_Code_ID=Market.market_ID ) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN ContainerOutBoundNotify On ContainerOutBoundNotify.ContainerOutBoundNotifyID=BillofLading_House.ContainerOutBoundNotifyID) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & "  "

        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN BL_Clause On BL_Clause.BL_ClauseID=BillOfLading_House.BL_ClauseID)"

        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN UserList on BILLOFLADING_HOUSE.CreativeUser=UserList.Usr) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " WHERE  "

        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & ""
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & "BILLOFLADING_HOUSE.Continued = 1 "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " "
        If argCriteria <> "" Then
            MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & argCriteria
        End If

        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & strBILLOFLADING_HOUSEOrder2


        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    'Private Function MakeQueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
    '    '        On Error GoTo Err_Renamed

    '    '        MakeQueryPrice = strPriceSelect

    '    '        MakeQueryPrice = MakeQueryPrice & " FROM ((PriceBillHouse LEFT JOIN BillOfLading_house on PriceBillHouse.BLH_ID=BillOfLading_House.BLH_ID)  "
    '    '        MakeQueryPrice = MakeQueryPrice & "LEFT JOIN Charge on PriceBillHouse.Charge_ID=Charge.Charge_ID) "
    '    '        MakeQueryPrice = MakeQueryPrice & "Where PriceBillHouse.BLH_ID='" & BillHouseID & "'"
    '    '        MakeQueryPrice = MakeQueryPrice & " and PriceBillHouse.Continued = 1 "
    '    '        MakeQueryPrice = MakeQueryPrice & strPriceOrder

    '    '        'Debug.Print MakeQueryCommodity
    '    '        Exit Function
    '    'Err_Renamed:
    '    '        MsgBox(msgErr(Me, Err.Description))
    'End Function
    Sub QueryBooking()
        On Error GoTo ERR_NAMED
        Dim id As String = "ContainerOutBoundNotifyId"
        Dim value As String = "BookingNo"
        Dim strQuery As String = "Select ContainerOutBoundNotifyId,BookingNo from CONTAINEROUTBOUNDNOTIFY where CONTINUED=1"
        loadDataToObject(Me.cboBooking, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryBookingNo()
        On Error GoTo ERR_NAMED
        Dim id As String = "ContainerOutBoundNotifyId"
        Dim value As String = "BookingNo"
        Dim strQuery As String = "Select ContainerOutBoundNotifyId,BookingNo from CONTAINEROUTBOUNDNOTIFY where CONTINUED=1"
        loadDataToObject(Me.cboBookingNo, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Private Sub QueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim ds As New DataSet
    '        '----------------
    '        If IsNothing(argCriteria) Then
    '            strQuery = MakeQueryPrice()
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
    '        '------------vị trí BM
    '        If location >= 0 And location <= Me.dgdPrice.Rows.Count And Me.dgdPrice.Rows.Count > 0 Then
    '            Me.dgdPrice.Rows(location).Selected = True
    '        End If
    '        '--------------------
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        'If oTablePrice.Rows.Count > 0 Then
    '        '    Me.dgdPrice.Columns.Item("BillOfLadingId").ToolTipText = "Hiện có:" + CStr(Me.dgdPrice.RowCount()) + " Prices."
    '        'End If
    '        InsertAutoNumberToGrid(Me.dgdPrice)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    Private Sub QueryBILLOFLADING_HOUSE(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryBILLOFLADING_HOUSE()
        Else
            strQuery = MakeQueryBILLOFLADING_HOUSE(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTable) Then
            oTable.Clear()
        End If
        Adapter.Fill(ds, "BILLOFLADING_HOUSEList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdBillOfLading_House.DataSource = ds.Tables("BILLOFLADING_HOUSEList")
        If Me.dgdBillOfLading_House.Enabled = False Then
            Me.dgdBillOfLading_House.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdBillOfLading_House.Columns.Item("BLH_No").ToolTipText = "Hiện có:" + CStr(Me.dgdBillOfLading_House.RowCount()) + " Bills."
        End If
        If Me.dgdBillOfLading_House.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdBillOfLading_House.Rows.Count And Me.dgdBillOfLading_House.Rows.Count > 0 Then
            Me.dgdBillOfLading_House.Rows(location).Selected = True
            Me.dgdBillOfLading_House.CurrentCell = Me.dgdBillOfLading_House.Rows(location).Cells(4)
        End If

        'dem tong so container
        Dim CountContainer As Integer = 0
        For i As Integer = 0 To Me.dgdBillOfLading_House.Rows.Count - 1
            CountContainer += Me.dgdBillOfLading_House.Item("QuantityOfContainer", i).Value
        Next
        Me.dgdBillOfLading_House.Columns("QuantityOfContainer").HeaderText = "Quantity Of Container " & "(" & CountContainer & " Containers)"
        Me.dgdBillOfLading_House.Columns("QuantityOfContainer").Width = 152

        For i As Integer = 0 To Me.dgdBillOfLading_House.Rows.Count - 1
            If Me.dgdBillOfLading_House.Item("gridchecking", i).Value = True Then
                Me.dgdBillOfLading_House.Rows(i).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        InsertAutoNumberToGrid(Me.dgdBillOfLading_House)
        '--------------------
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Public Sub QueryShipper(ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select * From Shipper where Continued=1 And Shipper_ID='" & ID & "' "
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Dim temp As String = ""
        If (dt.Rows.Count > 0) Then
            ShipperID = dt.Rows(0).Item("Shipper_ID").ToString
            temp &= dt.Rows(0).Item("Shipper_Code").ToString & " - " & dt.Rows(0).Item("Shipper_1").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Shipper_2").ToString & Chr(10) & dt.Rows(0).Item("Shipper_3").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Shipper_4").ToString & Chr(10) & dt.Rows(0).Item("Shipper_5").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Remarks").ToString
        End If
        Me.txtShipper.Text = temp
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub QueryConsignee(ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select * From Consignee where Continued=1 And Consignee_ID='" & ID & "' "
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Dim temp As String = ""
        If (dt.Rows.Count > 0) Then
            ConsigneeID = dt.Rows(0).Item("Consignee_ID").ToString
            temp &= dt.Rows(0).Item("Consignee_Code").ToString & " - " & dt.Rows(0).Item("Consignee_1").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Consignee_2").ToString & Chr(10) & dt.Rows(0).Item("Consignee_3").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Consignee_4").ToString & Chr(10) & dt.Rows(0).Item("Consignee_5").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Remarks").ToString
        End If
        Me.txtConsignee.Text = temp
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub QueryNotify(ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select * From Notify where Continued=1 And Notify_ID='" & ID & "'"
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Dim temp As String = ""
        If (dt.Rows.Count > 0) Then
            NotifyID = dt.Rows(0).Item("Notify_ID").ToString
            temp &= dt.Rows(0).Item("Notify_Code").ToString & " - " & dt.Rows(0).Item("Notify_1").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Notify_2").ToString & Chr(10) & dt.Rows(0).Item("Notify_3").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Notify_4").ToString & Chr(10) & dt.Rows(0).Item("Notify_5").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Remarks").ToString
        End If
        Me.txtNotify.Text = temp
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub QueryNotify2(ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select * From Notify where Continued=1 And Notify_ID='" & ID & "' "
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Dim temp As String = ""
        If (dt.Rows.Count > 0) Then
            Notify2ID = dt.Rows(0).Item("Notify_ID").ToString
            temp &= dt.Rows(0).Item("Notify_Code").ToString & " - " & dt.Rows(0).Item("Notify_1").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Notify_2").ToString & Chr(10) & dt.Rows(0).Item("Notify_3").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Notify_4").ToString & Chr(10) & dt.Rows(0).Item("Notify_5").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Remarks").ToString
        End If

        Me.txtNotify2.Text = temp
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub QueryNotify3(ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select * From Notify where Continued=1 And Notify_ID='" & ID & "' "
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Dim temp As String = ""
        If (dt.Rows.Count > 0) Then
            Notify3ID = dt.Rows(0).Item("Notify_ID").ToString
            temp &= dt.Rows(0).Item("Notify_Code").ToString & " - " & dt.Rows(0).Item("Notify_1").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Notify_2").ToString & Chr(10) & dt.Rows(0).Item("Notify_3").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Notify_4").ToString & Chr(10) & dt.Rows(0).Item("Notify_5").ToString & Chr(10)
            temp &= dt.Rows(0).Item("Remarks").ToString
        End If
        Me.txtNotify3.Text = temp
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Public Sub QueryShipper()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Shipper_Id"
    '        value = "Shipper"
    '        'strSQL = "Select ShipperId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Shipper where Continued=1 Order By Code desc"

    '        strSQL = "Select SHipper_ID,Shipper_Code,Shipper_1 as Shipper From Shipper where Continued=1 And Shipper_1 <>'' Order By Shipper ASC "
    '        If Me.cboShipper.Items.Count = 0 Or mStatus <> "Normal" Then
    '            loadDataToObject(Me.cboShipper, strSQL, id, value)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Public Sub QueryConsignee()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Consignee_Id"
    '        value = "Consignee"
    '        'strSQL = "Select ConsigneeId,'SC-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Consignee where Continued=1 Order By Code Desc"
    '        strSQL = "Select Consignee_code,CONSIGNEE_ID,Consignee_1 as Consignee From Consignee where Continued=1 And Consignee_1 <>'' Order By Consignee ASC"
    '        If Me.cboConsignee.Items.Count = 0 Or mStatus <> "Normal" Then
    '            loadDataToObject(Me.cboConsignee, strSQL, id, value)
    '        End If

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Public Sub QueryNotify(ByRef cbo As ComboBox)
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Notify_Id"
    '        value = "Notify"
    '        'strSQL = "Select NotifyId,'SN-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Notify where Continued=1 Order By Code Desc"
    '        strSQL = "Select Notify_Id,Notify_Code,Notify_1 as Notify  From Notify where Continued=1 And Notify_1 <>'' Order By Notify ASC"
    '        If cbo.Items.Count = 0 Or mStatus <> "Normal" Then
    '            loadDataToObject(cbo, strSQL, id, value)
    '        End If

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
#End Region

    '    Private Sub frmListBaseMaster_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        objUserSetting.SetCParm("frmListBaseMaster.cboFind", Me.cboFind.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtFCommodity", Me.txtBILLOFLADING_HOUSE.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtShipper", Me.txtShipper.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtConsignee", Me.txtConsignee.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtNotify", Me.txtNotify.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtPreCarriageVessel", Me.txtPreCarriageVessel.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtPreCarriageVoyNo", Me.txtPre_VoyNo.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.cboVessel", Me.cboVessel.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtVoyNo", Me.txtVoyNo.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtDescriptionOfContentsForShipper", Me.txtDescriptionOfContentsForShipper.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtTotalNoContainersOrPackages", Me.txtTotalNoContainersOrPackages.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtPlaceOfreceipt", Me.txtPlaceOfreceipt.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtPortOfDischarge", Me.txtPortOfDischarge.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtPortOfLoading", Me.txtPortOfLoading.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtFinalDestination", Me.txtFinalDestination.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtPlaceOfDeliveryCode", Me.txtPlaceOfDeliveryCode.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtRevenueTons", Me.txtRevenueTons.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtRate", Me.txtRate.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtPreightCharges", Me.txtPreightCharges.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtPrepaid", Me.txtPrepaid.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtCollect", Me.txtCollect.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtPrepaidAt", Me.txtPrepaidAt.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtPayableAt", Me.txtPayableAt.Text)

    '        objUserSetting.SetCParm("frmListBaseMaster.txtTotalprepaid", Me.txtTotalprepaid.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtNoOfOrigineBL", Me.txtNoOfOrigineBL.Text)
    '        objUserSetting.SetCParm("frmListBaseMaster.txtPlace", Me.txtPlace.Text)



    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayBILLOFLADING_HOUSE", Me.smnuDisplayBILLOFLADING_HOUSE.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayShipperName", Me.smnuDisplayShipperName.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayConsigneeName", Me.smnuDisplayConsigneeName.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayNotifyName", Me.smnuDisplayNotifyName.Checked)

    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPreCarriage", Me.smnuDisplayPreCarriage.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPlaceOfReceipt", Me.smnuDisplayPlaceOfReceipt.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayOceanVessel", Me.smnuDisplayOceanVessel.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayVoyNo", Me.smnuDisplayVoyNo.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPortOfLoading", Me.smnuDisplayPortOfLoading.Checked)

    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPortOfDischarge", Me.smnuDisplayPortOfDischarge.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPlaceOfDelivery", Me.smnuDisplayPlaceOfDelivery.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayFinalDestination", Me.smnuDisplayFinalDestination.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayDescriptionOfContentsForShipper", Me.smnuDisplayDescriptionOfContentsForShipper.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayTotalNoContainerOrPackages", Me.smnuDisplayTotalNoContainerOrPackages.Checked)

    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPreightCharges", Me.smnuDisplayPreightCharges.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayRevenueTons", Me.smnuDisplayRevenueTons.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayRate", Me.smnuDisplayRate.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPrepaid", Me.smnuDisplayPrepaid.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayCollect", Me.smnuDisplayCollect.Checked)

    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPrepaidAt", Me.smnuDisplayPrepaidAt.Checked)

    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPayableAt", Me.smnuDisplayPayableAt.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPlaceOfIssue", Me.smnuDisplayPlaceOfIssue.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayDateOfIssue", Me.smnuDisplayDateOfIssue.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayTotalPrepaidIn", Me.smnuDisplayTotalPrepaidIn.Checked)

    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayNoOfOrigineBL", Me.smnuDisplayNoOfOrigineBL.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayCreativeUser", Me.smnuDisplayCreativeUser.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayCreativeDate", Me.smnuDisplayCreativeDate.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

#Region "Sự Kiện Form"

    Private Sub frmListBaseHouse_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'objUserSetting.SetCParm("frmListCargoHouse.txtDescriptionOfContentsForShipper", Me.txtDescriptionOfContentsForShipper.Text)
        ''-------------
        'objUserSetting.SetCParm("frmListCargoHouse.txtQuaRanTineCode", Me.txtQuaRanTineCode.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtSealNo", Me.txtNotify.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtMF_FilingType", Me.txtMF_FilingType.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtNVOCC_MasterBL_No", Me.txtNVOCC_MasterBL_No.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtTotalprepaid", Me.txtTotalprepaid.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtSaleName", Me.txtSaleName.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtSCAC", Me.txtSCAC.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtRevenueTons", Me.txtRevenueTons.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtRate", Me.txtRate.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtBLOtherref", Me.txtBLOtherref.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtBLType", Me.txtBLType.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtNoOfOrigineBL", Me.txtNoOfOrigineBL.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtPayerCode", Me.txtPayerCode.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtCustoms", Me.txtCustoms.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.cboBL_CY_CFS_Item", Me.cboBL_CY_CFS_Item.Text)

        '''''''''''''''''''''''''''----------------

        'objUserSetting.SetCParm("frmListCargoHouse.cboRepaid_Collect", Me.cboRepaid_Collect.Text)
        ''-------------
        'objUserSetting.SetCParm("frmListCargoHouse.txtPrepaidAt", Me.txtPrepaidAt.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtPayableAt", Me.txtPayableAt.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtNoOfCopyBL", Me.txtNoOfCopyBL.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.cboSlotshare", Me.cboSlotshare.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtIMOPAGE", Me.txtUSServiceMode.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtTransport1", Me.txtTransport1.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtTransport2", Me.txtTransport2.Text)
        'objUserSetting.SetCParm("frmListCargoHouse.txtTransport3", Me.txtTransport3.Text)

        'objUserSetting.SetCParm("frmListCargoHouse.txtTransport4", Me.txtTransport4.Text)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayCollect", Me.smnuDisplayCollect.Checked)
        ''objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayBillOfLading_House", Me.smnuDisplayBillOfLading_House.Checked)

        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayCreativeDate", Me.smnuDisplayCreativeDate.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayCreativeUser", Me.smnuDisplayCreativeUser.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayDateOfIssue", Me.smnuDisplayDateOfIssue.Checked)

        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayDescriptionOfContentsForShipper", Me.smnuDisplayDescriptionOfContentsForShipper.Checked)

        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayFinalDestination", Me.smnuDisplayFinalDestination.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayNoOfOrigineBL", Me.smnuDisplayNoOfOrigineBL.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayNotifyName", Me.smnuDisplayNotifyName.Checked)
        '' objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayOceanVessel", Me.smnuDisplayOceanVessel.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPayableAt", Me.smnuDisplayPayableAt.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPlaceOfDelivery", Me.smnuDisplayPlaceOfDelivery.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPlaceOfIssue", Me.smnuDisplayPlaceOfIssue.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPlaceOfReceipt", Me.smnuDisplayPlaceOfReceipt.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPortOfDischarge", Me.smnuDisplayPortOfDischarge.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPortOfLoading", Me.smnuDisplayPortOfLoading.Checked)
        '' objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPreCarriage", Me.smnuDisplayPreCarriage.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPreightCharges", Me.smnuDisplayPreightCharges.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPrepaid", Me.smnuDisplayPrepaid.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayPrepaidAt", Me.smnuDisplayPrepaidAt.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayRate", Me.smnuDisplayRate.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayRevenueTons", Me.smnuDisplayRevenueTons.Checked)
        '' objUserSetting.SetBParm("frmListCargoHouse.smnuDisplaySaleName", Me.smnuDisplaySaleName.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayServiceContract", Me.smnuDisplayServiceContract.Checked)

        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTotalNoContainerOrPackages", Me.smnuDisplayTotalNoContainerOrPackages.Checked)
        'objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTotalPrepaidIn", Me.smnuDisplayTotalPrepaidIn.Checked)
        ''objUserSetting.SetBParm("frmListCargoHouse.smnuDisplayTotalPakages", Me.smnuDisplayt.Checked)
        Me.cmdCancel_Click(sender, e)


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub Query()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        'id = "ID"
        'value = "Sohopdong"
        'strSQL = "Select * From chicilonhopdong where Continued=1 and continued=1 order by sohopdong "
        'loadDataToObject(Me.cbotentoanha, strSQL, id, value)
        '--------toa nha
        Me.txtPlofReceiptCode.Items.Clear()
        id = "port_code"
        value = "port_code"
        strSQL = "Select port_code " & _
                 "From port where continued=1 order by port_code "
        loadDataToObject(Me.txtPlofReceiptCode, strSQL, id, value)
        ''------------------------so hop dong cu
        ''Me.cboEquip.Items.Clear()
        ''id = "EquipmentID"
        ''value = "Equipment"
        ''strSQL = "Select * " & _
        ''         "From Equipment where continued=1 order by Equipment"
        ''loadDataToObject(Me.cboEquip, strSQL, id, value)
        ''--------------nguoiphutrach
        'Me.cboCompany.Items.Clear()
        'id = "ID"
        'value = "tencongty"
        'strSQL = "Select ID,tencongty   " & _
        '         "From chicilonkhachhang where continued=1 order by tencongty "
        'loadDataToObject(Me.cboCompany, strSQL, id, value)

        ''------------------------so hop dong cu
        ''--------------nguoiphutrach
        'Me.cbosale.Items.Clear()
        'id = "ID"
        'value = "hoten"
        'strSQL = "Select ID,hoten   " & _
        '         "From chicilonnhanvien where continued=1 order by hoten "
        'loadDataToObject(Me.cbosale, strSQL, id, value)

        Exit Sub
Err_Renamed:
        DisplayMessage(True, msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListBaseHouse_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        Me.tagInformationCustomer.Visible = False
        Me.fraUpdate.Visible = False
        mStatus = "Normal"
        mStatusP = "Normal"
        mStatusR = "Normal"
        blnUpdated = False
        getConsignee()
        Query()
        getShipper()
        getNotify()
        'SetDefaultGrid(Me.dgdRouting, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdDetailBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mBILLOFLADING_HOUSEId = DefaultValue
        Me.GbEditBLH_No.Visible = False
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        LoadComboFind(Me.cboFind, Me.dgdBillOfLading_House)

        GetCurrency(Me.cboCurrency)


        ShipperID = DefaultValue.Replace("{", "").Replace("}", "") 'bo di hai dau  { va }
        ConsigneeID = DefaultValue.Replace("{", "").Replace("}", "")
        NotifyID = DefaultValue.Replace("{", "").Replace("}", "")
        Notify2ID = DefaultValue.Replace("{", "").Replace("}", "")
        Notify3ID = DefaultValue.Replace("{", "").Replace("}", "")
        'QueryShipper()
        'QueryConsignee()
        'QueryNotify(Me.txtNotify)
        'QueryNotify(Me.txtNotify2)
        'QueryNotify(Me.txtNotify3)
        QueryBLOfLading()
        'Dim cbo As Object
        QueryBLOfLading_h()
        QueryItems()
        QueryNote()
        QueryCurrency()
        QueryPortPOP(Me.txtPOP)
        'cbo = Me.txtPlofReceiptCode
        'If Me.txtPlofReceiptCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If
        'cbo = Me.txtPortOfLoadingCode
        'If Me.txtPortOfLoadingCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If
        'cbo = Me.txtPortOfDisChargeCode
        'If Me.txtPortOfDisChargeCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.txtPortOfDeliveryCode
        'If Me.txtPortOfDeliveryCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.txtPortOfDestinationCode
        'If Me.txtPortOfDestinationCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.txtPlaceCode
        'If Me.txtPlaceCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If


        'cbo = Me.txtportfromcode
        'If Me.txtportfromcode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.txtPortToCode
        'If Me.txtPortToCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        Me.grpBillHouse.Visible = False

        'cbo = Me.txtTradeCode
        'QueryTradeCode(cbo)
        QueryAgency()
        QueryBookingNo()
        QueryBooking()
        QueryBLOfLadingHOuse()
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.txtShipper.Text = objUserSetting.GetCParm("frmListBaseMaster.txtShipper")
        'Me.txtConsignee.Text = objUserSetting.GetCParm("frmListBaseMaster.txtConsignee")
        'Me.txtNotify.Text = objUserSetting.GetCParm("frmListBaseMaster.txtNotify")
        'Me.txtPreVessel.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPreVessel")
        'Me.txtPreVesselNo.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPreVesselNo")


        'Me.txtDescriptionOfContentsForShipper.Text = objUserSetting.GetCParm("frmListBaseMaster.txtDescriptionOfContentsForShipper")
        'Me.txtTotalNoContainersOrPackages.Text = objUserSetting.GetCParm("frmListBaseMaster.txtTotalNoContainersOrPackages")

        'Me.txtPlofReceiptName.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPlaceOfreceipt")
        'Me.txtPortOfDisChargeCode.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPortOfDischarge")

        'Me.txtPortOfLoadingCode.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPortOfLoading")

        'Me.txtSaleName.Text = objUserSetting.GetCParm("frmListBaseMaster.txtSaleName")

        'Me.txtRevenueTons.Text = objUserSetting.GetCParm("frmListBaseMaster.txtRevenueTons")

        'Me.txtRate.Text = objUserSetting.GetCParm("frmListBaseMaster.txtRate")
        'Me.txtPrepaidAt.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPrepaidAt")
        'Me.txtPayableAt.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPayableAt")

        'Me.txtTotalprepaid.Text = objUserSetting.GetCParm("frmListBaseMaster.txtTotalprepaid")
        'Me.txtNoOfOrigineBL.Text = objUserSetting.GetCParm("frmListBaseMaster.txtNoOfOrigineBL")
        '--------------
        'Me.smnuDisplayNotifyName.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayNotifyName")

        'Me.smnuDisplayPortOfLoading.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPortOfLoading")

        'Me.smnuDisplayPortOfDischarge.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPortOfDischarge")
        'Me.smnuDisplayPlaceOfDelivery.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPlaceOfDelivery")
        'Me.smnuDisplayFinalDestination.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayFinalDestination")
        'Me.smnuDisplayDescriptionOfContentsForShipper.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayDescriptionOfContentsForShipper")
        'Me.smnuDisplayTotalNoContainerOrPackages.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayTotalNoContainerOrPackages")
        'Me.smnuDisplayPreightCharges.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPreightCharges")
        'Me.smnuDisplayRevenueTons.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayRevenueTons")
        'Me.smnuDisplayRate.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayRate")
        'Me.smnuDisplayPrepaid.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPrepaid")
        'Me.smnuDisplayCollect.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayCollect")
        'Me.smnuDisplayPrepaidAt.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPrepaidAt")
        'Me.smnuDisplayPayableAt.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPayableAt")
        'Me.smnuDisplayPlaceOfIssue.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPlaceOfIssue")
        'Me.smnuDisplayDateOfIssue.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayDateOfIssue")
        'Me.smnuDisplayTotalPrepaidIn.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayTotalPrepaidIn")
        'Me.smnuDisplayNoOfOrigineBL.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayNoOfOrigineBL")
        'Me.smnuDisplayCreativeUser.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayCreativeUser")
        'Me.smnuDisplayCreativeDate.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayCreativeDate")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayApprove")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayUpdateTime")
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        SetMenu(True)
        'UpdateFrame()
        ReFormat()
        VisibleCargo(False)
        Me.CargoHousecmdOK.Enabled = False
        SetDefaultGrid(Me.dgdBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdRouting, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdDetailBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'SetDefaultGrid(Me.dgdBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        '----set mau nen,fra
        Me.BackColor = gMaunen
        Me.TabBase.BackColor = gMauFra
        Me.TabCustomer.BackColor = gMauFra
        Me.TabPage1.BackColor = gMauFra
        Me.TabPlace.BackColor = gMauFra
        Me.TabRouting.BackColor = gMauFra
        Me.TabPage2.BackColor = gMauFra
        Me.CargoHouseTabMarkShipment.BackColor = gMauFra
        Me.CargoHouseTabhazarduos.BackColor = gMauFra
        Me.CargoHouseTabCargoInfo.BackColor = gMauFra
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListBaseMaster_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub

    Private Sub frmListBaseMaster_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        'ReFormat()
    End Sub
#End Region


#Region "Hàm Xử Lý"
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "BL Details, BL A.M.S"
        ElseIf mStatus = "Edit" Then
            Me.Text = "BL Details, BL A.M.S-> Making..."
        End If

    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.tagInformationCustomer.Width = (Me.Width - 50)
        Me.dgdBillOfLading_House.Width = (Me.Width - 25)
        Me.grpFindBill.Top = Me.MenuStrip.Bottom + 5
        Me.dgdBillOfLading_House.Top = Me.grpFindBill.Bottom + 5
        'Me.dgdPrice.Width = Me.dgdBillOfLading_House.Width - 50
        'Me.dgdRouting.Width = Me.dgdBillOfLading_House.Width - 50
        If Me.fraUpdate.Visible = True Then
            Me.dgdBillOfLading_House.Height = Me.Height - Me.dgdBillOfLading_House.Top - Me.MenuStrip.Height - 20 - Me.fraUpdate.Height
        Else
            Me.dgdBillOfLading_House.Height = Me.Height - Me.dgdBillOfLading_House.Top - Me.MenuStrip.Height - 20
        End If

        Me.fraUpdate.Top = Me.dgdBillOfLading_House.Bottom + 10
        Me.fraUpdate.Width = (Me.Width - 25)

        '----- tagCustomer
        'Me.txtShipper.Width = Me.Width / 3
        'Me.txtShipper.Width = Me.txtShipper.Width
        'Me.txtConsignee.Width = Me.txtShipper.Width
        'Me.txtConsignee.Width = Me.txtShipper.Width
        'Me.lbldescriptionShipper.Left = Me.txtShipper.Left + Me.txtShipper.Width + 10

        'Me.txtDescriptionOfContentsForShipper.Width = Me.tagInformationCustomer.Width - Me.lbldescriptionShipper.Right - 50
        'Me.txtDescriptionOfContentsForShipper.Left = Me.lbldescriptionShipper.Left + Me.lbldescriptionShipper.Width + 5

        'Me.txtNote.Left = Me.txtDescriptionOfContentsForShipper.Left
        'Me.txtNote.Width = Me.txtDescriptionOfContentsForShipper.Width

        'Me.txtNotify.Left = Me.txtDescriptionOfContentsForShipper.Left
        'Me.txtNotify.Left = Me.txtDescriptionOfContentsForShipper.Left
        'Me.lblNotify.Left = Me.txtNotify.Left - Me.lblNotify.Width - 5
        'Me.txtNotify.Width = Me.txtDescriptionOfContentsForShipper.Width
        'Me.txtNotify.Width = Me.txtNotify.Width


        'Me.chkSameAsConsignee.Left = Me.txtNotify.Left
        'Me.chkSameAsShipper.Left = Me.chkSameAsConsignee.Left + Me.chkSameAsConsignee.Width + 10
        'Me.txtBillOfLading_house.Left = 3 * Me.tagInformationCustomer.Width / 4 + 30
        'Me.cmdOK.Left = Me.tagInformationCustomer.Right - Me.cmdOK.Width
        'Me.cmdCancel.Left = Me.cmdOK.Left - Me.cmdOK.Width - 10

        'Me.cmdOK.Top = Me.tagInformationCustomer.Bottom + 5
        'Me.cmdCancel.Top = Me.cmdOK.Top
        'Me.cmdChecking.Top = Me.cmdOK.Top
        'Me.cmdFind.Left = Me.txtShipperName.Right + 10

        Me.grpBillHouse.Left = Me.Width / 2 - Me.grpBillHouse.Width / 2
        Me.grpBillHouse.Top = Me.Height / 2 - Me.grpBillHouse.Height / 2 - 100

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Function QueryPayerNote(ByVal BookingID As String) As String
        Try
            Dim SQL As String
            SQL = "Select Note From FreightSale Where ContainerOutBoundNotifyID='" & BookingID & "' and Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt Is Nothing Then
                Return ""
            End If
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return dt.Rows(0).Item("Note")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    'Sub QueryCustomerPayer()
    '    Try
    '        Dim SQL As String
    '        SQL = "Select Company From Customer Where ApprovePayer=1 And Continued=1 "
    '        Dim dt As New DataTable
    '        dt = ReadTable(SQL)
    '        If dt Is Nothing Then
    '            Return
    '        End If
    '        Me.cboApprovePayerCustomer.DisplayMember = "Company"
    '        Me.cboApprovePayerCustomer.ValueMember = "Company"
    '        Me.cboApprovePayerCustomer.DataSource = dt
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        'QueryShipper(Me.dgdBillOfLading_House.Item("SHIPPER_ID", index).Value.ToString)
        'QueryConsignee(Me.dgdBillOfLading_House.Item("CONSIGNEE_ID", index).Value.ToString)
        'QueryNotify(Me.dgdBillOfLading_House.Item("NOTIFY_ID", index).Value.ToString)
        'If Me.dgdBillOfLading_House.Item("NOTIFY2_ID", index).Value.ToString.Trim <> "" Then
        '    QueryNotify2(Me.dgdBillOfLading_House.Item("NOTIFY2_ID", index).Value.ToString)
        'End If
        'If Me.dgdBillOfLading_House.Item("NOTIFY3_ID", index).Value.ToString.Trim <> "" Then
        '    QueryNotify3(Me.dgdBillOfLading_House.Item("NOTIFY3_ID", index).Value.ToString)
        'End If
        Me.txtShipper.Text = Me.dgdBillOfLading_House.Item("shipper", index).Value.ToString
        Me.txtConsignee.Text = Me.dgdBillOfLading_House.Item("consignee", index).Value.ToString
        Me.txtNotify.Text = Me.dgdBillOfLading_House.Item("notify", index).Value.ToString
        'Me.txtNotify2.Text = Me.dgdBillOfLading_House.Item("notify2", index).Value
        'Me.txtNotify3.Text = Me.dgdBillOfLading_House.Item("notify3", index).Value

        Me.chkNotShowDes.Checked = Me.dgdBillOfLading_House.Item("notShowDes", index).Value

        Me.cboBookingNo.Text = Me.dgdBillOfLading_House.Item("BookingNo", index).Value.ToString
        'Me.txtPreVessel.Text = Me.dgdBillOfLading_House.Item("PreVessel", index).Value.ToString

        Me.txtSaleName.Text = Me.dgdBillOfLading_House.Item("SaleName", index).Value.ToString
        Me.txtPreVessel.Text = Me.dgdBillOfLading_House.Item("PreVessel", index).Value.ToString
        Me.txtPreVesselNo.Text = Me.dgdBillOfLading_House.Item("PreVoyNo", index).Value.ToString

        Me.txtDescriptionOfContentsForShipper.Text = Me.dgdBillOfLading_House.Item("DESCRIPTIONFORSHIPPER", index).Value.ToString
        Me.txtPlofReceiptCode.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString
        Me.txtPlofReceiptName.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT", index).Value.ToString

        Me.txtBillOfLading_house.Text = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString

        Me.txtQuaRanTineCode.Text = Me.dgdBillOfLading_House.Item("QUARANTINE_CODING", index).Value.ToString
        Me.txtMF_FilingType.Text = Me.dgdBillOfLading_House.Item("MF_FILING_TYPE", index).Value.ToString


        Me.txtNVOCC_MasterBL_No.Text = Me.dgdBillOfLading_House.Item("NVOCC_MASTER_BL_NO", index).Value.ToString
        Me.cboCurrency.Text = Me.dgdBillOfLading_House.Item("CURRENCY", index).Value.ToString

        Me.txtSCAC.Text = Me.dgdBillOfLading_House.Item("SCAC_CODE", index).Value.ToString
        Me.txtCanVasserCode.Text = Me.dgdBillOfLading_House.Item("CANVASSERCODE", index).Value.ToString

        Me.txtTradeCode.Text = Me.dgdBillOfLading_House.Item("TRADE_CODE", index).Value.ToString
        Me.txtRevenueTons.Text = Me.dgdBillOfLading_House.Item("REVENUETON", index).Value.ToString

        'Me.txtPreightCharges.Text = Me.dgdBillOfLading_House.Item("PreightCharges", index).Value.ToString
        If Me.txtShipper.Text <> "" Then
            Me.txtPreightCharges.Text = Me.dgdBillOfLading_House.Item("PreightCharges", index).Value.ToString
        End If

        Me.txtTotalNoContainersOrPackages.Text = Me.dgdBillOfLading_House.Item("ToTalContainer", index).Value.ToString

        Me.txtTotalprepaid.Text = Me.dgdBillOfLading_House.Item("TOTALPREPAID_IN", index).Value.ToString

        Me.DTPLoad_Date.Text = Me.dgdBillOfLading_House.Item("LOAD_DATE", index).Value.ToString

        Me.DTPDate_Of_Issue.Text = Me.dgdBillOfLading_House.Item("DATE_OF_ISSUE", index).Value.ToString

        Me.txtRate.Text = Me.dgdBillOfLading_House.Item("EXCHANGE_RATE", index).Value.ToString
        Me.txtBLOtherref.Text = Me.dgdBillOfLading_House.Item("BL_OTHER_REF", index).Value.ToString
        Me.txtBLType.Text = Me.dgdBillOfLading_House.Item("BL_TYPE", index).Value.ToString
        Me.txtNoOfOrigineBL.Text = Me.dgdBillOfLading_House.Item("NO_OF_ORIGINAL_BL", index).Value.ToString
        Me.txtNoOfCopyBL.Text = Me.dgdBillOfLading_House.Item("NO_OF_COPY_BL", index).Value.ToString
        Me.txtPayerCode.Text = Me.dgdBillOfLading_House.Item("PAYER_CODE", index).Value.ToString
        Me.txtCustoms.Text = Me.dgdBillOfLading_House.Item("CUSTOMS_CLEARED_PLACE", index).Value.ToString
        Me.txtServiceContract.Text = Me.dgdBillOfLading_House.Item("SERVICECONTRACT", index).Value.ToString
        Me.cboBL_CY_CFS_Item.Text = Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString
        Me.cboRepaid_Collect.Text = Me.dgdBillOfLading_House.Item("PREPAID_OR_COLLECT", index).Value.ToString
        ' agencyname
        Me.TextBox1.Text = Me.dgdBillOfLading_House.Item("agencyname", index).Value.ToString


        Me.txtPrepaidAt.Text = Me.dgdBillOfLading_House.Item("PREPAIDAT", index).Value.ToString
        Me.txtPayableAt.Text = Me.dgdBillOfLading_House.Item("PAYABLE_AT", index).Value.ToString
        Me.cboSlotshare.Text = Me.dgdBillOfLading_House.Item("SLOT_SHARE", index).Value.ToString
        Me.txtUSServiceMode.Text = Me.dgdBillOfLading_House.Item("US_SERVICE_MODE", index).Value.ToString
        Me.cboRepaid_Collect.Text = Me.dgdBillOfLading_House.Item("PREPAID_OR_COLLECT", index).Value.ToString

        Me.txtPlofReceiptCode.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString
        Me.txtPortOfLoadingCode.Text = Me.dgdBillOfLading_House.Item("PORT_OF_LOADING_CODE", index).Value.ToString
        Me.txtPortOfDisChargeCode.Text = Me.dgdBillOfLading_House.Item("PORT_OF_DISCHARGE_CODE", index).Value.ToString
        Me.txtPortOfDeliveryCode.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_DELIVERY_CODE", index).Value.ToString
        Me.txtPortOfDestinationCode.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_DESTINATION_CODE", index).Value.ToString
        Me.txtPlaceCode.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_BL_ISSUE_CODE", index).Value.ToString

        Me.txtPortOfLoadingName.Text = Me.dgdBillOfLading_House.Item("PORT_OF_LOADING_NAME", index).Value.ToString
        Me.txtPortOfDischargeName.Text = Me.dgdBillOfLading_House.Item("PORT_OF_DISCHARGE", index).Value.ToString
        Me.txtPlaceOfDeliveryName.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_DELIVERY", index).Value.ToString
        Me.txtPlaceofdestinationName.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_DESTINATION", index).Value.ToString
        Me.txtPlaceOfBL_IssueName.Text = Me.dgdBillOfLading_House.Item("PLACE_OF_BL_ISSUE", index).Value.ToString
        'Me.txtServiceContract.Text = Me.dgdBillOfLading_House.Item("ServiceContract", index).Value.ToString


        Me.txtTransport1.Text = Me.dgdBillOfLading_House.Item("TRANSFER_PORT1", index).Value.ToString
        Me.txtTransport2.Text = Me.dgdBillOfLading_House.Item("TRANSFER_PORT2", index).Value.ToString
        Me.txtTransport3.Text = Me.dgdBillOfLading_House.Item("TRANSFER_PORT3", index).Value.ToString
        Me.txtTransport4.Text = Me.dgdBillOfLading_House.Item("TRANSFER_PORT4", index).Value.ToString

        Me.txtNote.Text = Me.dgdBillOfLading_House.Item("Note", index).Value.ToString
        Me.chkNotShowDes.Checked = Me.dgdBillOfLading_House.Item("notShowDes", index).Value

        'Me.txtBL_ClauseCode.Text = Me.dgdBillOfLading_House.Item("BL_ClauseCode", index).Value.ToString
        'Me.txtBL_ClauseText.Text = Me.dgdBillOfLading_House.Item("BL_ClauseText", index).Value.ToString
        'Me.txtPayerShipper.Text = Me.txtShipper.Text
        'querycustomerPayer()
        'Me.txtResultSelect.Text = Me.txtPayerShipper.Text


        'Hang2 air----------------------------------------------------------------------
        Me.txtairIssuingCarrier.Text = Me.dgdBillOfLading_House.Item("air_IssuingCarriAgentName", index).Value.ToString
        Me.txtairAgentIATACode.Text = Me.dgdBillOfLading_House.Item("air_AgentIATACode", index).Value.ToString
        Me.txtairAccountNo.Text = Me.dgdBillOfLading_House.Item("air_AccountNo", index).Value.ToString
        Me.txtAirTo1.Text = Me.dgdBillOfLading_House.Item("air_To1", index).Value.ToString
        Me.txtAirByFirstCarrier.Text = Me.dgdBillOfLading_House.Item("air_ByFirstCarrier", index).Value.ToString
        Me.txtAirto2.Text = Me.dgdBillOfLading_House.Item("air_to2", index).Value.ToString
        Me.txtairby1.Text = Me.dgdBillOfLading_House.Item("air_by1", index).Value.ToString
        Me.txtairto3.Text = Me.dgdBillOfLading_House.Item("air_to3", index).Value.ToString
        Me.txtairby2.Text = Me.dgdBillOfLading_House.Item("air_by2", index).Value.ToString
        Me.txtairCHGSCode.Text = Me.dgdBillOfLading_House.Item("air_ChgsCode", index).Value.ToString
        Me.txtairDecCarrier.Text = Me.dgdBillOfLading_House.Item("air_DeclaredValueForCarriage", index).Value.ToString
        Me.txtAirDecCus.Text = Me.dgdBillOfLading_House.Item("air_DeclaredValueForCustoms", index).Value.ToString
        Me.txtairAmountOfInsurance.Text = Me.dgdBillOfLading_House.Item("air_AmountOfInsurance", index).Value.ToString
        Me.txtairSCI.Text = Me.dgdBillOfLading_House.Item("air_SCI", index).Value.ToString

        Me.txtAirOtherPC.Text = Me.dgdBillOfLading_House.Item("air_Other", index).Value.ToString

        Me.txtairflightVoy2.Text = Me.dgdBillOfLading_House.Item("air_flightVoy", index).Value.ToString

        Me.dtpAirFlightDate.Text = Me.dgdBillOfLading_House.Item("air_flightDate", index).Value.ToString
        Me.txtMother.Text = Me.dgdBillOfLading_House.Item("Mother", index).Value.ToString

        Me.txtVoyMother.Text = Me.dgdBillOfLading_House.Item("VoyMOther", index).Value.ToString
        '-----------------------------
        Me.txtNgayGoiBill.Text = Me.dgdBillOfLading_House.Item("ngaygoibill", index).Value.ToString
        Me.txtngaynhanbill.Text = Me.dgdBillOfLading_House.Item("ngaynhanbill", index).Value.ToString

        Me.txtNguoiNhanBill.Text = Me.dgdBillOfLading_House.Item("nguoinhanbill", index).Value.ToString

        Me.txtngayfileAMS.Text = Me.dgdBillOfLading_House.Item("ngayfileams", index).Value.ToString

        Me.txtnguoifileAMS.Text = Me.dgdBillOfLading_House.Item("nguoifileams", index).Value.ToString

        Me.txtngaygoichungtu.Text = Me.dgdBillOfLading_House.Item("ngaygoichungtu", index).Value.ToString
        Me.txtNgaychinhsuasauDL.Text = Me.dgdBillOfLading_House.Item("ngaychinhsuasaudl", index).Value.ToString

        Me.txtNoidungchinhsuasauDL.Text = Me.dgdBillOfLading_House.Item("NoidungchinhsuasauDL", index).Value.ToString

        Me.txtRemarksGoiBill.Text = Me.dgdBillOfLading_House.Item("RemarksGoiBill", index).Value.ToString
        'Me.txtAmend.Text = Me.dgdBillOfLading_House.Item("amend", index).Value.ToString
        Me.txtemail.Text = Me.dgdBillOfLading_House.Item("email", index).Value.ToString

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

#End Region
    Public Sub QueryShipperRefesh()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Shipper_Id"
        value = "Shipper"
        'strSQL = "Select ShipperId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Shipper where Continued=1 Order By Code desc"
        strSQL = "Select SHipper_ID,Shipper_Code,Shipper_1 as Shipper From Shipper where Continued=1 Order By Shipper ASC "
        loadDataToObject(Me.txtShipper, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub QueryConsigneeRefesh()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Consignee_Id"
        value = "Consignee"
        'strSQL = "Select ConsigneeId,'SC-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Consignee where Continued=1 Order By Code Desc"
        strSQL = "Select Consignee_code,CONSIGNEE_ID,Consignee_1 as Consignee From Consignee where Continued=1 Order By Consignee ASC "

        loadDataToObject(Me.txtConsignee, strSQL, id, value)


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub QueryNotifyRefesh()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Notify_Id"
        value = "Notify"
        'strSQL = "Select NotifyId,'SN-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Notify where Continued=1 Order By Code Desc"
        strSQL = "Select Notify_Id,Notify_Code,Notify_1 as Notify  From Notify where Continued=1 Order By Notify ASC "

        loadDataToObject(Me.txtNotify, strSQL, id, value)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveDetailBillOfLading_House()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not Me.dgdBillOfLading_House.Item("Editable", index).Value Or Not UserRight("frmListBillOfLadingHouse", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "'", 15)

        Else
            strQueryDetailBillOfLading_HouseList = "Select * from BillOfLading_House where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub dgdBILLOFLADING_HOUSE_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBillOfLading_House.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex, index As Integer
        ' Xác định vị trí row trong grid
        If Me.oTable.Rows.Count > 0 Then
            index = Me.BindingContext(oTable).Position
        Else
            Exit Sub
        End If
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdBillOfLading_House.Columns(ColIndex).Name = "Approve" And Me.dgdBillOfLading_House.CurrentCellAddress().Y = index Then
            Call ApproveDetailBillOfLading_House()
        End If
        '---------------------------------- hien thi masterbill
        Dim index1 As Integer
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            'DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            'Return
        End If
        If Me.dgdBillOfLading_House.Rows.Count = 0 Then
            Exit Sub
        End If
        index1 = Me.dgdBillOfLading_House.CurrentRow.Index
        If Me.dgdBillOfLading_House.RowCount = 0 Then
            Return
        End If
        Dim i As Integer
        Dim sql, tempS As String
        Dim ds As New DataSet

        sql = "select * from billoflading where bl_id='" & Me.dgdBillOfLading_House.Item("bl_Id", index1).Value.ToString & "' and continued=1 "

        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                tempS += ds.Tables(0).Rows(i).Item("bl_no").ToString
            Next
        End If
        Me.cboBillOfLading_House.Text = tempS
        '------------------------------------------
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
#Region "Xử Lý ComboBox"

    Private Sub cboBillOfLading_House_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillOfLading_House.Leave
        '        On Error GoTo Err_Renamed
        '        Dim strSql, Consignee_code As String
        '        strSql = "Select BillOfLading.BL_No as Name  From BillOfLading_House  inner join BillOfLading  on BillOfLading_House.BL_ID=BillOfLading.BL_ID Where BillOfLading_House.Continued=1"
        '        If Me.cboBillOfLading_House.FindStringExact(Me.cboBillOfLading_House.Text) = -1 Then
        '            Me.cboBillOfLading_House.Text = FindBetter_new("Name", strSql, Me.cboBillOfLading_House.Text)
        '            If Me.cboBillOfLading_House.FindStringExact(Me.cboBillOfLading_House.Text) = -1 Then
        '                DisplayMessage(True, "The B/L is invalid, please check and correct it.")
        '                'Me.cboBillOfLading_House.Focus()
        '            End If
        '        End If

        '        Exit Sub
        'Err_Renamed:
        '        DisplayMessage(True, "")
        'Resume
    End Sub
    Private Sub cboBillOFLading_House_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillOfLading_House.SelectedIndexChanged
       
    End Sub

    '    Private Sub txtShipper_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, shipper_code As String
    '        strSql = "Select shipper_1 as name From Shipper Where Continued=1"
    '        If Me.txtShipper.FindStringExact(Me.txtShipper.Text) = -1 Then
    '            Me.txtShipper.Text = FindBetter_new("Name", strSql, Me.txtShipper.Text)
    '            If Me.txtShipper.FindStringExact(Me.txtShipper.Text) = -1 Then
    '                DisplayMessage(True, "The Shipper is invalid, please check and correct it.")
    '                Me.txtShipper.Focus()
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        DisplayMessage(True, "")
    '        'Resume
    '    End Sub

    '    Private Sub txtConsignee_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Consignee_code As String
    '        strSql = "Select Consignee_1 as Name From Consignee Where Continued=1"
    '        If Me.txtConsignee.FindStringExact(Me.txtConsignee.Text) = -1 Then
    '            Me.txtConsignee.Text = FindBetter_new("Name", strSql, Me.txtConsignee.Text)
    '            If Me.txtConsignee.FindStringExact(Me.txtConsignee.Text) = -1 Then
    '                DisplayMessage(True, "The Consignee is invalid, please check and correct it.")
    '                Me.txtConsignee.Focus()
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        DisplayMessage(True, "")
    '        'Resume
    '    End Sub


    '    Private Sub cboPlofReceiptCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.txtPlofReceiptCode.Text = Trim(UCase(Me.txtPlofReceiptCode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.txtPlofReceiptCode.FindStringExact(Me.txtPlofReceiptCode.Text) = -1 Then
    '            Me.txtPlofReceiptCode.Text = FindBetter_new("code", strSql, Me.txtPlofReceiptCode.Text)
    '            If Me.txtPlofReceiptCode.FindStringExact(Me.txtPlofReceiptCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPlofReceiptCode.Focus()
    '            End If
    '        End If
    '        Me.cboPlofReceiptCode_SelectedIndexChanged(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboPortfrom_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.txtportfromcode.Text = Trim(UCase(Me.txtportfromcode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.txtportfromcode.FindStringExact(Me.txtportfromcode.Text) = -1 Then
    '            Me.txtportfromcode.Text = FindBetter_new("code", strSql, Me.txtportfromcode.Text)
    '            If Me.txtPlofReceiptCode.FindStringExact(Me.txtPlofReceiptCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtportfromcode.Focus()
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboPortOfDisCharge_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim strSql As String
    '        Me.txtPortOfDisChargeCode.Text = Trim(UCase(Me.txtPortOfDisChargeCode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.txtPortOfDisChargeCode.FindStringExact(Me.txtPortOfDisChargeCode.Text) = -1 Then
    '            Me.txtPortOfDisChargeCode.Text = FindBetter_new("Code", strSql, Me.txtPortOfDisChargeCode.Text)
    '            If Me.txtPortOfDisChargeCode.FindStringExact(Me.txtPortOfDisChargeCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPortOfDisChargeCode.Focus()
    '            End If
    '        End If
    '        Me.cboPortOfDisCharge_selectindexchanged(sender, e)
    '    End Sub

    '    Private Sub cboPortOfDisCharge_selectindexchanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortOfDisChargeCode, Me.txtPortOfDisChargeCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPortOfDischarge.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboPortOfDestination_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim strSql As String
    '        Me.txtPortOfDestinationCode.Text = Trim(UCase(Me.txtPortOfDestinationCode.Text))
    '        strSql = "Select Port_code as Code From Port Where Continued=1"
    '        If Me.txtPortOfDestinationCode.FindStringExact(Me.txtPortOfDestinationCode.Text) = -1 Then
    '            Me.txtPortOfDestinationCode.Text = FindBetter_new("Code", strSql, Me.txtPortOfDestinationCode.Text)
    '            If Me.txtPortOfDestinationCode.FindStringExact(Me.txtPortOfDestinationCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPortOfDestinationCode.Focus()
    '            End If
    '        End If
    '        Me.cboPortOfDestination_selectindexchanged(sender, e)
    '    End Sub

    '    Private Sub cboPortOfDestination_selectindexchanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortOfDestinationCode, Me.txtPortOfDestinationCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPlaceofdestination.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    '    Private Sub cboPortOfDelivery_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim strSql As String
    '        Me.txtPortOfDeliveryCode.Text = Trim(UCase(Me.txtPortOfDeliveryCode.Text))
    '        strSql = "Select Port_code as Code From Port Where Continued=1"
    '        If Me.txtPortOfDeliveryCode.FindStringExact(Me.txtPortOfDeliveryCode.Text) = -1 Then
    '            Me.txtPortOfDeliveryCode.Text = FindBetter_new("Code", strSql, Me.txtPortOfDeliveryCode.Text)
    '            If Me.txtPortOfDeliveryCode.FindStringExact(Me.txtPortOfDeliveryCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPortOfDeliveryCode.Focus()
    '            End If
    '        End If
    '        Me.cboPortOfDelivery_selectindexchanged(sender, e)
    '    End Sub

    '    Private Sub cboPortOfDelivery_selectindexchanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortOfDeliveryCode, Me.txtPortOfDeliveryCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPlaceOfDelivery.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboPlaceCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim strSql As String
    '        Me.txtPlaceCode.Text = Trim(UCase(Me.txtPlaceCode.Text))
    '        strSql = "Select Port_Code as Code From Port Where Continued=1"
    '        If Me.txtPlaceCode.FindStringExact(Me.txtPlaceCode.Text) = -1 Then
    '            Me.txtPlaceCode.Text = FindBetter_new("Code", strSql, Me.txtPlaceCode.Text)
    '            If Me.txtPlaceCode.FindStringExact(Me.txtPlaceCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPlaceCode.Focus()
    '            End If
    '        End If
    '        Me.cboPlaceCode_SelectedIndexChanged(sender, e)
    '    End Sub

    '    Private Sub cboPortOfLoading_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim strSql As String
    '        Me.txtPortOfLoadingCode.Text = Trim(UCase(Me.txtPortOfLoadingCode.Text))
    '        strSql = "Select Port_Code as Code From Port Where Continued=1"
    '        If Me.txtPortOfLoadingCode.FindStringExact(Me.txtPortOfLoadingCode.Text) = -1 Then
    '            Me.txtPortOfLoadingCode.Text = FindBetter_new("Code", strSql, Me.txtPortOfLoadingCode.Text)
    '            If Me.txtPortOfLoadingCode.FindStringExact(Me.txtPortOfLoadingCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPortOfLoadingCode.Focus()
    '            End If
    '        End If
    '        Me.cboPortOfLoading_SelectedIndexChanged(sender, e)
    '    End Sub

    'Private Sub cboBLOtherref_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBLOtherref.Leave
    '    Dim strSql As String

    '    strSql = "Select BL_No as name From BILLOFLADING_HOUSE Where Continued=1"
    '    If Me.cboBLOtherref.FindStringExact(Me.cboBLOtherref.Text) = -1 Then
    '        Me.cboBLOtherref.Text = FindBetter_new("BL_No", strSql, Me.cboBLOtherref.Text)

    '        DisplayMessage(True, "The Bill is invalid, please check and correct it.")
    '        Me.cboBLOtherref.Focus()

    '    End If
    'End Sub

    'Private Sub cboBLOtherref_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBLOtherref.SelectedIndexChanged
    '    If Me.cboBLOtherref.Text <> "" Then
    '        If Me.cboBLOtherref.Text.IndexOf("X") = 0 Then
    '            Me.txtBLType.Text = "HOUSE"
    '        Else
    '            Me.txtBLType.Text = "MASTER"
    '        End If
    '    End If
    'End Sub



    Private Sub cboSlotshare_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSlotshare.Leave
        ' strSql = "Select Notify_Code as  From Notify Where Continued=1"
        If Me.cboSlotshare.FindStringExact(Me.cboSlotshare.Text) = -1 Then
            'Me.txtNotify.Text = FindBetter_new("Notify_code", strSql, Me.txtNotify.Text)
            DisplayMessage(True, "The Slot Share is Is Olny C OR H Please Correct It.")
            Me.cboSlotshare.Text = "C"
            Me.cboSlotshare.Focus()
        End If
    End Sub
    'Private Sub txtNotify_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim strSql As String
    '    strSql = "Select Notify_1 as Name From Notify Where Continued=1"
    '    If Me.txtNotify.FindStringExact(Me.txtNotify.Text) = -1 Then
    '        Me.txtNotify.Text = FindBetter_new("Name", strSql, Me.txtNotify.Text)
    '        If Me.txtNotify.FindStringExact(Me.txtNotify.Text) = -1 Then
    '            DisplayMessage(True, "The Notify is invalid, please check and correct it.")
    '            Me.txtNotify.Focus()
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNotify_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNotify.SelectedIndexChanged
    '    Dim Notify1ID As String
    '    Notify1ID = FindValueID(Me.txtNotify, Me.txtNotify.Text)
    '    If Notify1ID <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Notify where Notify_ID='" & Notify1ID & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Notify")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Notify_1").ToString + "  " + table.Rows(0).Item("Notify_2").ToString + "  " + table.Rows(0).Item("Notify_3").ToString + "  " + table.Rows(0).Item("Notify_4").ToString + "  " + table.Rows(0).Item("Notify_5").ToString + "  " + table.Rows(0).Item("Notify_6").ToString
    '            Me.txtNotify.Text = name
    '            NOTIFYID = table.Rows(0).Item("Notify_ID").ToString
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNotify_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim Notify1ID As String
    '    Notify1ID = FindValueID(Me.txtNotify, Me.txtNotify.Text)
    '    If Notify1ID <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Notify where Notify_ID='" & Notify1ID & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Notify")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Notify_1").ToString + "  " + table.Rows(0).Item("Notify_2").ToString + "  " + table.Rows(0).Item("Notify_3").ToString + "  " + table.Rows(0).Item("Notify_4").ToString + "  " + table.Rows(0).Item("Notify_5").ToString + "  " + table.Rows(0).Item("Notify_6").ToString
    '            Me.txtNotify.Text = name
    '            NOTIFYID = table.Rows(0).Item("Notify_ID").ToString
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNotify2_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim strSql As String
    '        strSql = "Select Notify_1 as Name From Notify Where Continued=1"
    '        If Me.txtNotify2.FindStringExact(Me.txtNotify2.Text) = -1 Then
    '            Me.txtNotify2.Text = FindBetter_new("Name", strSql, Me.txtNotify2.Text)
    '            If Me.txtNotify2.FindStringExact(Me.txtNotify2.Text) = -1 Then
    '                DisplayMessage(True, "The Notify is invalid, please check and correct it.")
    '                Me.txtNotify2.Focus()
    '            End If
    '        End If
    '        Me.txtNotify2_SelectedIndexChanged(sender, e)
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub
    'Private Sub txtNotify2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Notify1ID As String
    '    Notify1ID = FindValueID(Me.txtNotify2, Me.txtNotify2.Text)
    '    If Notify1ID <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Notify where Notify_ID='" & Notify1ID & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Notify")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Notify_1").ToString + "  " + table.Rows(0).Item("Notify_2").ToString + "  " + table.Rows(0).Item("Notify_3").ToString + "  " + table.Rows(0).Item("Notify_4").ToString + "  " + table.Rows(0).Item("Notify_5").ToString + "  " + table.Rows(0).Item("Notify_6").ToString
    '            Me.txtNotify2.Text = name
    '            'NOTIFYID = table.Rows(0).Item("Notify_ID").ToString
    '        End If
    '    End If
    'End Sub

    'Private Sub txtNotify3_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Try
    '        Dim strSql As String
    '        strSql = "Select Notify_1 as Name From Notify Where Continued=1"
    '        If Me.txtNotify3.FindStringExact(Me.txtNotify3.Text) = -1 Then
    '            Me.txtNotify3.Text = FindBetter_new("Name", strSql, Me.txtNotify3.Text)
    '            If Me.txtNotify3.FindStringExact(Me.txtNotify3.Text) = -1 Then
    '                DisplayMessage(True, "The Notify is invalid, please check and correct it.")
    '                Me.txtNotify3.Focus()
    '            End If
    '        End If
    '        Me.txtNotify3_SelectedIndexChanged(sender, e)
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    'Private Sub txtNotify3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Notify1ID As String
    '    Notify1ID = FindValueID(Me.txtNotify3, Me.txtNotify3.Text)
    '    If Notify1ID <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Notify where Notify_ID='" & Notify1ID & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Notify")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Notify_1").ToString + "  " + table.Rows(0).Item("Notify_2").ToString + "  " + table.Rows(0).Item("Notify_3").ToString + "  " + table.Rows(0).Item("Notify_4").ToString + "  " + table.Rows(0).Item("Notify_5").ToString + "  " + table.Rows(0).Item("Notify_6").ToString
    '            Me.txtNotify3.Text = name
    '            'NOTIFYID = table.Rows(0).Item("Notify_ID").ToString
    '        End If
    '    End If
    'End Sub

    'Private Sub txtShipper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Shipper1id As String
    '    Shipper1id = FindValueID(Me.txtShipper, Me.txtShipper.Text)
    '    If Shipper1id <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Shipper where Shipper_ID='" & Shipper1id & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Shipper")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Shipper_1").ToString + "  " + table.Rows(0).Item("Shipper_2").ToString + "  " + table.Rows(0).Item("Shipper_3").ToString + "  " + table.Rows(0).Item("Shipper_4").ToString + "  " + table.Rows(0).Item("Shipper_5").ToString + "  " + table.Rows(0).Item("Shipper_6").ToString
    '            Me.txtShipper.Text = name
    '            ShipperID = table.Rows(0).Item("Shipper_ID").ToString
    '        End If
    '    End If
    'End Sub

    'Private Sub txtConsignee_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim Consignee1id As String
    '    Consignee1id = FindValueID(Me.txtConsignee, Me.txtConsignee.Text)
    '    If Consignee1id <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Consignee where Consignee_ID='" & Consignee1id & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Consignee")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Consignee_1").ToString + "  " + table.Rows(0).Item("Consignee_2").ToString + "  " + table.Rows(0).Item("Consignee_3").ToString + "  " + table.Rows(0).Item("Consignee_4").ToString + "  " + table.Rows(0).Item("Consignee_5").ToString + "  " + table.Rows(0).Item("Consignee_6").ToString
    '            Me.txtConsignee.Text = name
    '            ConsigneeID = table.Rows(0).Item("Consignee_ID").ToString
    '        End If
    '    End If
    'End Sub

    'Private Sub cboPre_Vessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPre_Vessel.SelectedIndexChanged

    '    Dim Prevessel1id As String
    '    Prevessel1id = FindValueID(Me.cboPre_Vessel, Me.cboPre_Vessel.Text)
    '    If Prevessel1id <> "" Then
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Pre_vessel where Pre_vessel_ID='" & Prevessel1id & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Prevessel")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            'name = table.Rows(0).Item("Prevessel_1").ToString + "  " + table.Rows(0).Item("Prevessel_2").ToString + "  " + table.Rows(0).Item("Prevessel_3").ToString + "  " + table.Rows(0).Item("Prevessel_4").ToString + "  " + table.Rows(0).Item("Prevessel_5").ToString + "  " + table.Rows(0).Item("Prevessel_6").ToString
    '            Me.txtPre_VoyNo.Text = table.Rows(0).Item("PRE_VESSEL_VOYAGE").ToString
    '            PREVESSELID = table.Rows(0).Item("Pre_vessel_ID").ToString
    '        End If
    '    End If
    'End Sub


    'Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
    '    Dim Vessel1id As String
    '    Vessel1id = FindValueID(Me.cboVessel, Me.cboVessel.Text)
    '    If Vessel1id <> "" Then
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from vessel where vessel_ID='" & Vessel1id & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Vessel")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            'name = table.Rows(0).Item("Vessel_1").ToString + "  " + table.Rows(0).Item("Vessel_2").ToString + "  " + table.Rows(0).Item("Vessel_3").ToString + "  " + table.Rows(0).Item("Vessel_4").ToString + "  " + table.Rows(0).Item("Vessel_5").ToString + "  " + table.Rows(0).Item("Vessel_6").ToString
    '            Me.txtVoyNo.Text = table.Rows(0).Item("VOYAGE").ToString
    '            VESSELID = table.Rows(0).Item("vessel_ID").ToString
    '        End If
    '    End If
    'End Sub

    '    Private Sub cboPlofReceiptCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPlofReceiptCode, Me.txtPlofReceiptCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPlaceOfreceiptName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    '    Private Sub cboPortOfLoading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortOfLoadingCode, Me.txtPortOfLoadingCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPortOfLoading.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    '    Private Sub cboPlaceCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPlaceCode, Me.txtPlaceCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPlaceOfBL_Issue.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    'Private Sub cboTradeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim TradeCode1_ID As String
    '        'TradeCode1_ID = FindValueID(Me.txtTradeCode, Me.txtTradeCode.Text)
    '        If TradeCode1_ID <> "" Then
    '            Dim strQuery As String
    '            '-------------
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Dim dset As New DataSet
    '            Dim table As New DataTable
    '            '----------------
    '            strQuery = "select * from Trade_Code where Trade_Code_ID='" & TradeCode1_ID & "'"

    '            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '            '-----------------

    '            'If Not IsNothing(oTable) Then
    '            '    oTable.Clear()
    '            'End If
    '            table.Clear()
    '            Adapter.Fill(dset, "TradeCode")
    '            table = dset.Tables(0)
    '            If table.Rows.Count > 0 Then
    '                TRADECODEID = table.Rows(0).Item("Trade_Code_ID").ToString
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        'DisplayMessage(True, "")
    '        'Resume
    '    End Sub
#End Region

#Region "Xử Lý Buuton"

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Dim index As Integer = 0
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            index = Me.dgdBillOfLading_House.CurrentRow.Index
       
        End If
        Me.cboBillOfLading_House.Enabled = True
        Me.tagInformationCustomer.Visible = False
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        mCargoHouseStatus = "Normal"
        reText(mStatus)
        Me.dgdBillOfLading_House.Enabled = True
        Dim Bill_ID As String
        LoadCargoHouse = False
        'Bill_ID = FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text)

        'If mFilter = "" Then
        '    QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "'", 15)
        'Else
        '    QueryBILLOFLADING_HOUSE(mFilter)
        'End If

        VisibleCargo(False)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Function CheckData() As Boolean
        Try
            Dim strmsg As String = ""
            Dim Result As Boolean = True
            'If Me.txtBillOfLading_house.Text = "" Then
            '    strmsg &= vbCrLf & "Please check your bill house!"
            '    Result = True
            'End If

            'If Me.txtSEQ.Text = "2" Then
            '    Me.txtRoutingVesselCode.Text = Me.txtPreVessel.Text
            '    Me.txtRoutingVoyAge.Text = Me.txtPreVesselNo.Text
            'Else
            '    Me.txtRoutingVesselCode.Text = ""
            '    Me.txtRoutingVoyAge.Text = ""
            'End If
            'If Me.txtMF_FilingType.Text = "" Then
            '    strmsg &= vbCrLf & "MF Filing type must have an Value"
            '    Result = True
            'End If

            'If Me.txtNVOCC_MasterBL_No.Text = "" Then
            '    strmsg &= vbCrLf & "NVOCC must have an Value"
            '    Result = True
            'End If
            If Me.cboCurrency.Text = "" Then
                strmsg &= vbCrLf & "Currency must have an Value"
                Result = True
            End If
            'If Me.txtSCAC.Text = "" Then
            '    strmsg &= vbCrLf & "SCAC Code must have an Value"
            '    Result = False
            'End If

            'If Me.txtTradeCode.Text = "" Then
            '    strmsg &= vbCrLf & "trade Code must have an Value"
            '    Result = True
            'End If

            'If Me.txtBLOtherref.Text = "" Then
            '    strmsg &= vbCrLf & " B/L Other must have an Value"
            '    Result = False
            'End If
            If Me.txtBLType.Text = "" Then
                strmsg &= vbCrLf & " B/L Type must have an Value"
                Result = True
            End If

            If Me.txtNoOfOrigineBL.Text = "" Then
                strmsg &= vbCrLf & " N.Ori. BL(29) must have an Value"
                Result = True
            End If

            'If Me.txtPayerCode.Text = "" Then
            '    strmsg &= vbCrLf & " payer Code must have an Value"
            '    Result = True
            'End If

            If Me.txtPlofReceiptCode.Text = "" Then
                strmsg &= vbCrLf & " place of receipt must have an Value"
                Result = True
            End If

            If Me.cboBL_CY_CFS_Item.Text = "" Then
                strmsg &= vbCrLf & " BL_CY_CFS_Item must have an Value"
                Result = True
            End If

            If Me.cboRepaid_Collect.Text = "" Then
                strmsg &= vbCrLf & " Repaid_Collect must have an Value"
                Result = True
            End If

            If Me.txtPayableAt.Text = "" Then
                strmsg &= vbCrLf & "Payable At must have an Value"
                Result = True
            End If

            If Me.txtNoOfCopyBL.Text = "" Then
                strmsg &= vbCrLf & " N. C B/L  must have an Value"
                Result = True
            End If

            'If Me.cboSlotshare.Text = "" Then
            '    strmsg &= vbCrLf & " Slot share must have an Value"
            '    Result = True
            'End If



            'If Me.txtUSServiceMode.Text = "" Then
            '    strmsg &= vbCrLf & " US Mode must have an Value"
            '    Result = True
            'End If

            'If Me.txtCanVasserCode.Text = "" Then
            '    strmsg &= vbCrLf & "CanVasserCode must have an Value"
            '    Result = True
            'End If

            If Me.txtPortOfDeliveryCode.Text = "" Then
                strmsg &= vbCrLf & " PORT OF Delivery must have an Value"
                Result = False
            End If

            If Me.txtPortOfDisChargeCode.Text = "" Then
                strmsg &= vbCrLf & " PORT OF Discharge must have an Value"
                Result = False
            End If

            ''''''''''''''''''''''''''''''''''''

            If Me.txtPortOfLoadingCode.Text = "" Then
                strmsg &= vbCrLf & "PORT OF Loading  must have an Value"
                Result = False
            End If

            If Me.txtPortOfDestinationCode.Text = "" Then
                strmsg &= vbCrLf & "PORT OF Destination must have an Value"
                Result = False
            End If

            If Me.txtPlaceCode.Text = "" Then
                strmsg &= vbCrLf & " PORT OF ISSUE must have an Value"
                Result = False
            End If
            'If Me.dgdRouting.RowCount = 0 Then
            '    DisplayMessage(True, "Routing Must have Some record")
            '    ' Return False
            'End If
            If Me.cboBookingNo.Text = "" Then
                strmsg = vbCrLf & "Booking No. Can not be null"
                Result = False
            End If
            If strmsg <> "" Then
                DisplayMessage(True, strmsg)
            End If
            Return Result

            'If Me.cboPortOfDisCharge.Text = "" Then
            '    strmsg &= vbCrLf & " Port Of Discharge must have an Value"
            '    Result = False
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub OkClick()
        Dim strQuery As String

        ' Dim rsCode As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdBillOfLading_House.Rows.Count > 0 Then
            index = Me.dgdBillOfLading_House.CurrentRow.Index
            mBL_ClauseID = Me.dgdBillOfLading_House.Item("BL_ClauseID", index).Value.ToString
        End If
        If Me.txtMF_FilingType.Text = "" Then
            DisplayMessage(True, "Kiểm tra lại số Bill Master (MF_Filing) của hãng tàu.!")
            Me.txtMF_FilingType.Focus()
            Return
        End If
        If CheckData() And (mStatus = "Edit" Or mStatus = "Add" Or mStatus = "Normal") Then
            If mStatus = "Edit" Then
                'CopyValues("BILLOFLADING_HOUSE", "BLH_ID", mBILLOFLADING_HOUSEId)
            End If
            Dim rs As New ADODB.Recordset
            If mBL_ClauseID = "" Then
                mBL_ClauseID = DefaultValue
            End If
            'thêm BL_Clause If Add
            'strQuery = "Select Top 1 * from BL_Clause Where BL_clauseID='" & mBL_ClauseID & "' And Continued=1"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'With rs
            '    If .EOF Or UCase(mStatus) = "ADD" Then
            '        .AddNew()
            '        .Fields("BL_ClauseID").Value = NewId()
            '    End If
            '    mBL_ClauseID = .Fields("BL_ClauseID").Value
            '    mBL_ClauseID = mBL_ClauseID.Replace("{", "").Replace("}", "")
            '    .Fields("BL_ClauseCode").Value = Me.txtBL_ClauseCode.Text
            '    .Fields("BL_ClauseText").Value = Me.txtBL_ClauseText.Text
            '    .Update()
            'End With
            'rs.Close()


            strQuery = "SELECT * "
            strQuery = strQuery & "FROM BILLOFLADING_HOUSE "
            strQuery = strQuery & "WHERE BLH_ID = '" & mBILLOFLADING_HOUSEId & "' AND BLH_ID <> '" & DefaultValue & "' and continued=1"

            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BL_ID").Value = NewId()
                    .Fields("BL_ID").Value = "{" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text.Trim) & "}"
                    .Fields("BLH_NO").Value = Me.txtBillOfLading_house.Text.Trim
                End If
                'strVesselId = .Fields("BLH_ID").Value
                If Me.cboBookingNo.Text <> "" And Me.txtShipper.Text <> "" And Me.txtConsignee.Text <> "" And Me.txtNotify.Text <> "" And Me.txtPlofReceiptCode.Text <> "" And Me.txtPortOfLoadingCode.Text <> "" And Me.txtPortOfDisChargeCode.Text <> "" And Me.txtPortOfDeliveryCode.Text <> "" And Me.txtPortOfDestinationCode.Text <> "" And Me.txtPlaceCode.Text <> "" Then
                    .Fields("ContainerOutBoundNotifyId").Value = "{" & FindValueID(Me.cboBookingNo, Me.cboBookingNo.Text) & "}"
                    '.Fields("SHIPPER_ID").Value = "{" & ShipperID & "}"
                    '.Fields("CONSIGNEE_ID").Value = "{" & ConsigneeID & "}"
                    '.Fields("NOTIFY_ID").Value = "{" & NotifyID & "}"
                    'If Me.txtNotify2.Text.Trim.Length > 0 Then
                    '    .Fields("NOTIFY2_ID").Value = "{" & Notify2ID & "}"
                    'Else
                    '    .Fields("NOTIFY2_ID").Value = DefaultValue
                    'End If

                    'If Me.txtNotify3.Text.Trim.Length > 0 Then
                    '    .Fields("NOTIFY3_ID").Value = "{" & Notify3ID & "}"
                    'Else
                    '    .Fields("NOTIFY3_ID").Value = DefaultValue
                    'End If
                    .Fields("SHIPPER").Value = UCase(Me.txtShipper.Text)

                    .Fields("CONSIGNEE").Value = UCase(Me.txtConsignee.Text)
                    .Fields("NOTIFY").Value = UCase(Me.txtNotify.Text)

                    '.Fields("NOTIFY2").Value = UCase(Me.txtNotify2.Text)
                    '.Fields("NOTIFY3").Value = UCase(Me.txtNotify3.Text)


                    '.Fields("PRE_VESSEL_ID").Value = "{" & PREVESSELID & "}"
                    .Fields("PLACE_OF_RECEIPT_ID").Value = "{" & POR_ID & "}"
                    .Fields("PORT_OF_LOADING_ID").Value = "{" & POL_ID & "}"
                    .Fields("PORT_OF_DISCHARGE_ID").Value = "{" & POD_ID & "}"
                    .Fields("PLACE_OF_DELIVERY_ID").Value = "{" & DEL_ID & "}"
                    .Fields("PLACE_OF_DESTINATION_ID").Value = "{" & DEST_ID & "}"
                    .Fields("PLACE_OF_BL_ISSUE_ID").Value = "{" & POI_ID & "}"
                    '.Fields("BL_ClauseID").Value = "{" & mBL_ClauseID & "}"
                    '.Fields("VESSEL_ID").Value = "{" & VESSELID & "}"
                    '.Fields("TRADE_CODE_ID").Value = "{" & FindValueID(Me.txtTradeCode, Me.txtTradeCode.Text) & "}"
                End If

                .Fields("TRADE_CODE").Value = Me.txtTradeCode.Text
                .Fields("TOTALPREPAID_IN").Value = UCase(Trim(Me.txtTotalprepaid.Text))

                .Fields("BL_CY_CFS_ITEM").Value = UCase(Trim(Me.cboBL_CY_CFS_Item.Text))

                .Fields("ToTalContainer").Value = UCase(Trim(Me.txtTotalNoContainersOrPackages.Text))

                .Fields("PreightCharges").Value = UCase(Trim(Me.txtPreightCharges.Text))

                .Fields("PREPAID_OR_COLLECT").Value = UCase(Trim(Me.cboRepaid_Collect.Text))
                .Fields("LOAD_DATE").Value = Me.DTPLoad_Date.Value.Date

                .Fields("DESCRIPTIONFORSHIPPER").Value = UCase(Trim(Me.txtDescriptionOfContentsForShipper.Text))
                .Fields("REVENUETON").Value = UCase(Trim(Me.txtRevenueTons.Text))

                .Fields("QUARANTINE_CODING").Value = UCase(Trim(Me.txtQuaRanTineCode.Text))
                .Fields("DATE_OF_ISSUE").Value = Me.DTPDate_Of_Issue.Value.Date

                .Fields("CURRENCY").Value = UCase(Trim(Me.cboCurrency.Text))
                .Fields("EXCHANGE_RATE").Value = UCase(Trim(Me.txtRate.Text))
                .Fields("MF_FILING_TYPE").Value = UCase(Trim(Me.txtMF_FilingType.Text))
                .Fields("NVOCC_MASTER_BL_NO").Value = UCase(Trim(Me.txtNVOCC_MasterBL_No.Text))

                .Fields("SCAC_CODE").Value = UCase(Trim(Me.txtSCAC.Text))
                .Fields("CANVASSERCODE").Value = UCase(Trim(Me.txtCanVasserCode.Text))

                .Fields("BL_OTHER_REF").Value = UCase(Trim(Me.txtBLOtherref.Text))
                .Fields("BL_TYPE").Value = UCase(Trim(Me.txtBLType.Text))
                .Fields("PAYABLE_AT").Value = UCase(Trim(Me.txtPayableAt.Text))
                .Fields("PAYER_CODE").Value = UCase(Trim(Me.txtPayerCode.Text))
                .Fields("NO_OF_COPY_BL").Value = UCase(Trim(Me.txtNoOfCopyBL.Text))
                .Fields("NO_OF_ORIGINAL_BL").Value = UCase(Trim(Me.txtNoOfOrigineBL.Text))
                .Fields("CUSTOMS_CLEARED_PLACE").Value = UCase(Trim(Me.txtCustoms.Text))

                .Fields("SLOT_SHARE").Value = UCase(Trim(Me.cboSlotshare.Text))
                .Fields("US_SERVICE_MODE").Value = UCase(Trim(Me.txtUSServiceMode.Text))

                .Fields("PORT_OF_LOADING_NAME").Value = UCase(Trim(Me.txtPortOfLoadingName.Text))
                .Fields("PORT_OF_DISCHARGE_NAME").Value = UCase(Trim(Me.txtPortOfDischargeName.Text))
                .Fields("PLACE_OF_DELIVERY_NAME").Value = UCase(Trim(Me.txtPlaceOfDeliveryName.Text))
                .Fields("PLACE_OF_DESTINATION_NAME").Value = UCase(Trim(Me.txtPlaceofdestinationName.Text))
                .Fields("PLACE_OF_BL_ISSUE_NAME").Value = UCase(Trim(Me.txtPlaceOfBL_IssueName.Text))
                .Fields("PLACE_OF_RECEIPT_NAME").Value = UCase(Trim(Me.txtPlofReceiptName.Text))
                '.Fields("LOAD_PORT_NAME").Value = UCase(Trim(Me.txtLoad_port.Text))

                '.Fields("LOAD_PORT_CODE").Value = UCase(Trim(Me.cboLoad_port.Text))
                .Fields("PORT_OF_LOADING_CODE").Value = UCase(Trim(Me.txtPortOfLoadingCode.Text))
                .Fields("PLACE_OF_BL_ISSUE_CODE").Value = UCase(Trim(Me.txtPlaceCode.Text))
                .Fields("PLACE_OF_DESTINATION_CODE").Value = UCase(Trim(Me.txtPortOfDestinationCode.Text))
                .Fields("PLACE_OF_DELIVERY_CODE").Value = UCase(Trim(Me.txtPortOfDeliveryCode.Text))

                .Fields("PLACE_OF_RECEIPT_CODE").Value = UCase((Me.txtPlofReceiptCode.Text))
                .Fields("PORT_OF_DISCHARGE_CODE").Value = UCase((Me.txtPortOfDisChargeCode.Text))

                '.Fields("SERVICECONTRACT").Value = UCase(Trim(Me.txtServiceContract.Text))
                .Fields("PREPAIDAT").Value = UCase(Trim(Me.txtPrepaidAt.Text))
                .Fields("TRANSFER_PORT1").Value = UCase(Trim(Me.txtTransport1.Text))
                .Fields("TRANSFER_PORT2").Value = UCase(Trim(Me.txtTransport2.Text))
                .Fields("TRANSFER_PORT3").Value = UCase(Trim(Me.txtTransport3.Text))
                .Fields("TRANSFER_PORT4").Value = UCase(Trim(Me.txtTransport4.Text))
                .Fields("Note").Value = Me.txtNote.Text
                If Me.chkNotShowDes.Checked = True Then
                    .Fields("notShowDes").Value = "1"
                Else
                    .Fields("notShowDes").Value = "0"
                End If
                '.Fields("Payer").Value = Me.txtResultSelect.Text
                .Fields("Checking").Value = Checking
                'Me.chkNotShowDes.Checked = Me.dgdBillOfLading_House.Item("notShowDes", index).Value
                '.Fields("PORT_FROM").Value = UCase(Trim(Me.cboPortfrom.Text))
                '.Fields("FROM_DATE").Value = Me.DTPFromDate.Value.Date

                '.Fields("PORT_TO").Value = UCase(Trim(Me.txtPortToCode.Text))
                '.Fields("TO_DATE").Value = Me.DTPToDate.Value.Date
                '.Fields("SEQ").Value = UCase(Trim(Me.txtSEQ.Text))
                '.Fields("MOT").Value = UCase(Trim(Me.txtMOT.Text))
                '----------------------------------------------------------------------------
                .Fields("air_IssuingCarriAgentName").Value = Me.txtairIssuingCarrier.Text '= Me.dgdBillOfLading.Item("air_IssuingCarriAgentName", index).Value.ToString
                .Fields("air_AgentIATACode").Value = Me.txtairAgentIATACode.Text '= Me.dgdBillOfLading.Item("air_AgentIATACode", index).Value.ToString
                .Fields("air_AccountNo").Value = Me.txtairAccountNo.Text '= Me.dgdBillOfLading.Item("air_AccountNo", index).Value.ToString
                .Fields("air_To1").Value = Me.txtAirTo1.Text '= Me.dgdBillOfLading.Item("air_To1", index).Value.ToString
                .Fields("air_ByFirstCarrier").Value = Me.txtAirByFirstCarrier.Text '= Me.dgdBillOfLading.Item("air_ByFirstCarrier", index).Value.ToString
                .Fields("air_to2").Value = Me.txtAirto2.Text '= Me.dgdBillOfLading.Item("air_to2", index).Value.ToString
                .Fields("air_by1").Value = Me.txtairby1.Text '= Me.dgdBillOfLading.Item("air_by1", index).Value.ToString
                .Fields("air_to3").Value = Me.txtairto3.Text '= Me.dgdBillOfLading.Item("air_to3", index).Value.ToString
                .Fields("air_by2").Value = Me.txtairby2.Text '= Me.dgdBillOfLading.Item("air_by2", index).Value.ToString
                .Fields("air_ChgsCode").Value = Me.txtairCHGSCode.Text '= Me.dgdBillOfLading.Item("air_ChgsCode", index).Value.ToString
                .Fields("air_DeclaredValueForCarriage").Value = Me.txtairDecCarrier.Text '= Me.dgdBillOfLading.Item("air_DeclaredValueForCarriage", index).Value.ToString
                .Fields("air_DeclaredValueForCustoms").Value = Me.txtAirDecCus.Text '= Me.dgdBillOfLading.Item("air_DeclaredValueForCustoms", index).Value.ToString
                .Fields("air_AmountOfInsurance").Value = Me.txtairAmountOfInsurance.Text '= Me.dgdBillOfLading.Item("air_AmountOfInsurance", index).Value.ToString
                .Fields("air_SCI").Value = Me.txtairSCI.Text '= Me.dgdBillOfLading.Item("air_SCI", index).Value.ToString

                .Fields("air_Other").Value = Me.txtAirOtherPC.Text '= Me.dgdBillOfLading.Item("air_Other", index).Value.ToString

                .Fields("air_flightVoy").Value = Me.txtairflightVoy2.Text ' = Me.dgdBillOfLading.Item("air_flightVoy", index).Value.ToString

                .Fields("air_flightDate").Value = Me.dtpAirFlightDate.Value.Date  '= Me.dgdBillOfLading.Item("air_flightDate", index).Value.ToString


                '------------------------------------------------------------------------------
                '------------------------------------------------------------------------------
                .Fields("mother").Value = Me.txtMother.Text
                .Fields("voymother").Value = Me.txtVoyMother.Text

                .Fields("agencyname").Value = Me.TextBox1.Text
                '--------------------------


                .Fields("NgayGoiBill").Value = Me.txtNgayGoiBill.Text
                .Fields("email").Value = Me.txtemail.Text
                .Fields("NgaynhanBill").Value = Me.txtngaynhanbill.Text
                .Fields("NguoiNhanBill").Value = Me.txtNguoiNhanBill.Text
                .Fields("Ngayfileams").Value = Me.txtngayfileAMS.Text
                .Fields("Nguoifileams").Value = Me.txtnguoifileAMS.Text
                .Fields("Ngaygoichungtu").Value = Me.txtngaygoichungtu.Text


                .Fields("Ngaychinhsuasaudl").Value = Me.txtNgaychinhsuasauDL.Text
                .Fields("Noidungchinhsuasaudl").Value = Me.txtNoidungchinhsuasauDL.Text

                .Fields("RemarksGoiBill").Value = Me.txtRemarksGoiBill.Text
                '.Fields("amend").Value = Me.txtAmend.Text



                '---------------------------------
                .Update()

            End With
            rs.Close()
            DisplayMessage(True, "Complete!")
            Me.dgdBillOfLading_House.Enabled = True
            Me.fraUpdate.Visible = False
            blnUpdated = True
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
        End If
        If mFilter = "" Then
            If Me.cboBillOfLading_House.Text = "" Then
                QueryBILLOFLADING_HOUSE(mFilter)
            Else
                QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "'", 15)

            End If
        Else
            QueryBILLOFLADING_HOUSE(mFilter)
        End If




        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Checking = 0
        OkClick()
    End Sub
#End Region

#Region "Xử Lý Delete"
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        Dim cmd As New ADODB.Command
        'khong cho xoa nhung House Da Co nhap Phi

        strQuery = "Select count(*) cnt from PRICEBILLHOUSE WHERE BLH_ID = '" & Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString & "'  and continued=1 "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The BILLOFLADING_HOUSE can not be removed. There are transactions that relate to Bill Fee.")
            Exit Sub
        End If


        strQuery = "Select * from BILLOFLADING_HOUSE WHERE BL_ID = '" & Me.dgdBillOfLading_House.Item("BL_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Bill can not be removed.", "Không Thể Xoá Bill Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        If Not IsNothing(Me.dgdBillOfLading_House.Item("Approve", index)) Then
            If Me.dgdBillOfLading_House.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdBillOfLading_House.Item("Editable", index)) Then
            If Not Me.dgdBillOfLading_House.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingHouse", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the BILLOFLADING_HOUSE: " & Me.dgdBillOfLading_House.Item("BLH_No", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from BILLOFLADING_HOUSE where" + " BLH_Id= '" & Me.dgdBillOfLading_House.Item("BLH_Id", index).Value.ToString & "'"
                'rsBILLOFLADING_HOUSEList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsBILLOFLADING_HOUSEList.Fields("continued").Value = 0
                'rsBILLOFLADING_HOUSEList.Update()

                'rsBILLOFLADING_HOUSEList.Requery()
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                ''Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsBILLOFLADING_HOUSEList.Close()
                'blnUpdated = True
                '---------------------------------
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from BILLOFLADING_HOUSE where BLH_Id= '" & Me.dgdBillOfLading_House.Item("blh_ID", index).Value.ToString & "' "
               
                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub smnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        If Me.dgdBillOfLading_House.Rows.Count = 0 Then
            Return
        End If


        Dim selectedRowCount As Integer = _
             Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdBillOfLading_House.SelectedRows(i).Index)
            Next i
        End If
        QueryBILLOFLADING_HOUSE()
        '"And BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "'")
    End Sub
#End Region

    '#Region "Xử Lý Mnu View"

    '    Public Sub UpdateFrame()
    '        On Error GoTo Err_Renamed

    '        Me.dgdBillOfLading_House.Columns.Item("BL_ID").Visible = False

    '        'Me.dgdBillOfLading_House.Columns.Item("ConsigneeName").Visible = Me.smnuDisplayConsigneeName.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("NotifyName").Visible = Me.smnuDisplayNotifyName.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("SCAC_CODE").Visible = Me.smnuDisplayServiceContract.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("CANVASSERCODE").Visible = Me.smnuDisplayCanVasserCode.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("ToTalContainer").Visible = Me.smnuDisplayTotalContainer.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("PLACE_OF_RECEIPT").Visible = Me.smnuDisplayPlaceOfReceipt.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("PreightCharges").Visible = Me.smnuDisplayPreightCharges.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("PREPAIDAT").Visible = Me.smnuDisplayPrepaidAt.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("DESCRIPTIONFORSHIPPER").Visible = Me.smnuDisplayDescriptionOfContentsForShipper.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("SERVICECONTRACT").Visible = Me.smnuDisplayServiceContract.Checked


    '        ' Me.dgdBillOfLading_House.Columns.Item("LOAD_PORT").Visible = Me.smnuDisplayPortOfLoading.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("PORT_OF_DISCHARGE").Visible = Me.smnuDisplayPortOfDischarge.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("PLACE_OF_DELIVERY").Visible = Me.smnuDisplayPlaceOfDelivery.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("PLACE_OF_DESTINATION").Visible = Me.smnuDisplayFinalDestination.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("TOTALPREPAID_IN").Visible = Me.smnuDisplayTotalPrepaidIn.Checked

    '        'Me.dgdBILLOFLADING_HOUSE.Columns.Item("MOBILE").Visible = Me.smnuDisplayRevenueTons.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("EXCHANGE_RATE").Visible = Me.smnuDisplayRate.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("EDITABLE").Visible = False
    '        Me.dgdBillOfLading_House.Columns.Item("CONTINUED").Visible = False

    '        Me.dgdBillOfLading_House.Columns.Item("PREPAID_OR_COLLECT").Visible = Me.smnuDisplayPrepaid.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("PREPAID_OR_COLLECT").Visible = Me.smnuDisplayCollect.Checked

    '        'Me.dgdBILLOFLADING_HOUSE.Columns.Item("FAX").Visible = Me.smnuDisplayPrepaidAt.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("PAYABLE_AT").Visible = Me.smnuDisplayPayableAt.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("PLACE_OF_BL_ISSUE").Visible = Me.smnuDisplayPlaceOfIssue.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("DATE_OF_ISSUE").Visible = Me.smnuDisplayDateOfIssue.Checked

    '        'Me.dgdBILLOFLADING_HOUSE.Columns.Item("FAX").Visible = Me.smnuDisplayTotalPrepaidIn.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("NO_OF_ORIGINAL_BL").Visible = Me.smnuDisplayNoOfOrigineBL.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("CreativeUser").Visible = Me.smnuDisplayCreativeUser.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("CreativeDate").Visible = Me.smnuDisplayCreativeDate.Checked

    '        Me.dgdBillOfLading_House.Columns.Item("APPROVE").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdBillOfLading_House.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub


    '    Private Sub smnuDisplayNotifyName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayNotifyName.Checked = Not Me.smnuDisplayNotifyName.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayServiceContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayServiceContract.Checked = Not Me.smnuDisplayServiceContract.Checked
    '        UpdateFrame()
    '    End Sub

    '    'Private Sub smnuDisplayPreCarriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    Me.smnuDisplayPreCarriage.Checked = Not Me.smnuDisplayPreCarriage.Checked
    '    '    UpdateFrame()
    '    'End Sub

    '    Private Sub smnuDisplayPlaceOfReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPlaceOfReceipt.Checked = Not Me.smnuDisplayPlaceOfReceipt.Checked
    '        UpdateFrame()
    '    End Sub

    '    'Private Sub smnuDisplayOceanVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    Me.smnuDisplayOceanVessel.Checked = Not Me.smnuDisplayOceanVessel.Checked
    '    '    UpdateFrame()
    '    'End Sub

    '    'Private Sub smnuDisplayVoyNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    '    Me.smnuDisplayVoyNo.Checked = Not Me.smnuDisplayVoyNo.Checked
    '    '    UpdateFrame()
    '    'End Sub

    '    Private Sub smnuDisplayPortOfLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPortOfLoading.Checked = Not Me.smnuDisplayPortOfLoading.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPortOfDischarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPortOfDischarge.Checked = Not Me.smnuDisplayPortOfDischarge.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPlaceOfDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPlaceOfDelivery.Checked = Not Me.smnuDisplayPlaceOfDelivery.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayFinalDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayFinalDestination.Checked = Not Me.smnuDisplayFinalDestination.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayDescriptionOfContentsForShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayDescriptionOfContentsForShipper.Checked = Not Me.smnuDisplayDescriptionOfContentsForShipper.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayTotalNoContainerOrPackages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayTotalNoContainerOrPackages.Checked = Not Me.smnuDisplayTotalNoContainerOrPackages.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPreightCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPreightCharges.Checked = Not Me.smnuDisplayPreightCharges.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayRevenueTons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayRevenueTons.Checked = Not Me.smnuDisplayRevenueTons.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayToTalContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayTotalContainer.Checked = Not Me.smnuDisplayTotalContainer.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplaySCACCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplaySCACCode.Checked = Not Me.smnuDisplaySCACCode.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCanVasserCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCanVasserCode.Checked = Not Me.smnuDisplayCanVasserCode.Checked
    '        UpdateFrame()
    '    End Sub


    '    Private Sub smnuDisplayRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayRate.Checked = Not Me.smnuDisplayRate.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPrepaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPrepaid.Checked = Not Me.smnuDisplayPrepaid.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCollect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCollect.Checked = Not Me.smnuDisplayCollect.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPrepaidAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPrepaidAt.Checked = Not Me.smnuDisplayPrepaidAt.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPayableAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPayableAt.Checked = Not Me.smnuDisplayPayableAt.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPlaceOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayPlaceOfIssue.Checked = Not Me.smnuDisplayPlaceOfIssue.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayDateOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayDateOfIssue.Checked = Not Me.smnuDisplayDateOfIssue.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayTotalPrepaidIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayTotalPrepaidIn.Checked = Not Me.smnuDisplayTotalPrepaidIn.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNoOfOrigineBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayNoOfOrigineBL.Checked = Not Me.smnuDisplayNoOfOrigineBL.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCreativeUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCreativeUser.Checked = Not Me.smnuDisplayCreativeUser.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCreativeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayCreativeDate.Checked = Not Me.smnuDisplayCreativeDate.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '        UpdateFrame()
    '    End Sub
    '#End Region

    Private Sub chkSameAsShipper_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtNotify.Text = "SAME AS SHIPPER"
        Me.txtNotify.Text = "SAME AS SHIPPER"
    End Sub

    Private Sub chkSameAsConsignee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.txtNotify.Text = "SAME AS CONSIGNEE"
        Me.txtNotify.Text = "SAME AS CONSIGNEE"
    End Sub

    Private Sub mnuCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    '    Private Sub smnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
    '        On Error GoTo Err_Renamed
    '        If mStatus = "Normal" And UserRight("frmListBaseMaster", "Add") Then

    '            'Me.txtBILLOFLADING_HOUSE.Enabled = False


    '            Me.txtBILLOFLADING_HOUSEId.Text = gBILLOFLADING_HOUSENumber
    '            If gBILLOFLADING_HOUSENumber <> "" And gBILLOFLADING_HOUSENumber <> "No BillNumber." Then

    '                Me.tagInformationCustomer.Visible = True

    '                Me.fraUpdate.Visible = True
    '                Me.dgdBILLOFLADING_HOUSE.Enabled = False

    '                ReFormat()
    '                SetMenu((False))
    '                mBILLOFLADING_HOUSEId = DefaultValue
    '                mStatus = "Add"
    '                reText(mStatus)
    '            Else
    '                mStatus = "Normal"
    '            End If
    '        Else
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtBILLOFLADING_HOUSE.Text)
    '        If Me.txtBILLOFLADING_HOUSE.Text <> "" Then
    '            Select Case cboFind.Text
    '                Case "BILLOFLADING_HOUSEID"
    '                    QueryBILLOFLADING_HOUSE("AND ( BL_No LIKE '" & strFilter & "') " & mFilter)
    '                Case "SHIPPER NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (Shipper_1 LIKE '" & strFilter & "')" & mFilter)

    '                    If Me.smnuDisplayShipperName.Checked = False Then
    '                        Me.smnuDisplayShipperName.Checked = True
    '                    End If
    '                    Me.dgdBILLOFLADING_HOUSE.Columns.Item("SHIPPERNAME").Visible = Me.smnuDisplayShipperName.Checked
    '                    UpdateFrame()
    '                Case "CONSIGNEE NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (CONSIGNEE_1 LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayConsigneeName.Checked = False Then
    '                        Me.smnuDisplayConsigneeName.Checked = True
    '                    End If
    '                    Me.dgdBILLOFLADING_HOUSE.Columns.Item("ConSigneeName").Visible = Me.smnuDisplayConsigneeName.Checked
    '                    UpdateFrame()

    '                Case "NOTIFY NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (NOTIFYNAME LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayNotifyName.Checked = False Then
    '                        Me.smnuDisplayNotifyName.Checked = True
    '                    End If
    '                    Me.dgdBILLOFLADING_HOUSE.Columns.Item("NOTIFYNAME").Visible = Me.smnuDisplayNotifyName.Checked
    '                    UpdateFrame()

    '                Case "PLACE OF RECEIPT NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (PLACE_OF_RECEIPT_NAME LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayPlaceOfReceipt.Checked = False Then
    '                        Me.smnuDisplayPlaceOfReceipt.Checked = True
    '                    End If
    '                    Me.dgdBILLOFLADING_HOUSE.Columns.Item("PLACE_OF_RECEIPT").Visible = Me.smnuDisplayPlaceOfReceipt.Checked
    '                    UpdateFrame()

    '            End Select
    '        Else
    '            QueryBILLOFLADING_HOUSE(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtBillOfLading_House.Text)
    '        If Me.txtBillOfLading_House.Text <> "" Then
    '            Select Case cboFind.Text
    '                Case "BILLOFLADINGID"
    '                    QueryBILLOFLADING_HOUSE("AND ( BL_No LIKE '" & strFilter & "') " & mFilter)
    '                Case "SHIPPER NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (Shipper_1 LIKE '" & strFilter & "')" & mFilter)

    '                    If Me.smnuDisplayShipperName.Checked = False Then
    '                        Me.smnuDisplayShipperName.Checked = True
    '                    End If
    '                    Me.dgdBillOfLading_House.Columns.Item("SHIPPERNAME").Visible = Me.smnuDisplayShipperName.Checked
    '                    UpdateFrame()
    '                Case "CONSIGNEE NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (CONSIGNEE_1 LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayConsigneeName.Checked = False Then
    '                        Me.smnuDisplayConsigneeName.Checked = True
    '                    End If
    '                    Me.dgdBillOfLading_House.Columns.Item("ConSigneeName").Visible = Me.smnuDisplayConsigneeName.Checked
    '                    UpdateFrame()

    '                Case "NOTIFY NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (NOTIFYNAME LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayNotifyName.Checked = False Then
    '                        Me.smnuDisplayNotifyName.Checked = True
    '                    End If
    '                    Me.dgdBillOfLading_House.Columns.Item("NOTIFYNAME").Visible = Me.smnuDisplayNotifyName.Checked
    '                    UpdateFrame()

    '                Case "PLACE OF RECEIPT NAME"
    '                    QueryBILLOFLADING_HOUSE("AND (PLACE_OF_RECEIPT_NAME LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayPlaceOfReceipt.Checked = False Then
    '                        Me.smnuDisplayPlaceOfReceipt.Checked = True
    '                    End If
    '                    Me.dgdBillOfLading_House.Columns.Item("PLACE_OF_RECEIPT").Visible = Me.smnuDisplayPlaceOfReceipt.Checked
    '                    UpdateFrame()
    '                Case "BILLOFLADING_HOUSE"
    '                    QueryBILLOFLADING_HOUSE("AND (BLH_NO LIKE '" & strFilter & "') " & mFilter)
    '                    If Me.smnuDisplayNotifyName.Checked = False Then
    '                        Me.smnuDisplayNotifyName.Checked = True
    '                    End If
    '                    'Me.dgdBillOfLading_House.Columns.Item("BLH_NO").Visible = Me.smnuDisplayb.Checked
    '                    'UpdateFrame()
    '            End Select
    '        Else
    '            QueryBILLOFLADING_HOUSE(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub


    'Private Sub txtNotify_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim Notify1ID As String
    '    Notify1ID = FindValueID(Me.txtNotify, Me.txtNotify.Text)
    '    If Notify1ID <> "" Then
    '        Dim strQuery, name As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim dset As New DataSet
    '        Dim table As New DataTable
    '        '----------------
    '        strQuery = "select * from Notify where Notify_ID='" & Notify1ID & "'"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------

    '        'If Not IsNothing(oTable) Then
    '        '    oTable.Clear()
    '        'End If
    '        Adapter.Fill(dset, "Notify")
    '        table = dset.Tables(0)
    '        If table.Rows.Count > 0 Then
    '            name = table.Rows(0).Item("Notify_1").ToString + "  " + table.Rows(0).Item("Notify_2").ToString + "  " + table.Rows(0).Item("Notify_3").ToString + "  " + table.Rows(0).Item("Notify_4").ToString + "  " + table.Rows(0).Item("Notify_5").ToString + "  " + table.Rows(0).Item("Notify_6").ToString
    '            Me.txtNotify.Text = name
    '            NotifyID = table.Rows(0).Item("Notify_ID").ToString
    '        End If
    '    End If
    'End Sub



    '    Private Sub cmdOKP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        If mStatusP = "Add" Or mStatusP = "Edit" Then

    '            If Me.cboItems.FindStringExact(Me.cboItems.Text) = -1 Then
    '                DisplayMessage(True, "The Item is invalid. ")
    '                Me.cboItems.Focus()
    '                Exit Sub
    '            End If
    '            If Me.cboCurrencyP.FindStringExact(Me.cboCurrencyP.Text) = -1 Then
    '                DisplayMessage(True, "The Currency is invalid. ")
    '                Me.cboCurrency.Focus()
    '                Exit Sub
    '            End If
    '            If Len(Me.txtUnitPrice.Text) = 0 Then
    '                DisplayMessage(True, "The Price is invalid. ")
    '                Me.cboCurrency.Focus()
    '                Exit Sub
    '            End If
    '            If Len(Me.cboPrepaidCollectP.Text) = 0 Then
    '                DisplayMessage(True, "The P/Collect is invalid. ")
    '                Me.cboPrepaidCollectP.Focus()
    '                Exit Sub
    '            End If

    '            Dim strQuery, str, Cargo_ID As String
    '            Dim rs As New ADODB.Recordset
    '            Dim indexBL As Integer = 0
    '            Dim index As Integer = -1
    '            If Me.dgdPrice.RowCount > 0 Then
    '                index = Me.dgdPrice.CurrentRow.Index()
    '            End If
    '            If Me.dgdBillOfLading_House.Rows.Count > 0 Then
    '                indexBL = Me.dgdBillOfLading_House.CurrentRow.Index
    '            End If
    '            If mStatusP = "Add" Then
    '                strQuery = "Select * from PRICEBILLHOUSE where charge_ID='" & FindValueID(Me.cboItems, Me.cboItems.Text) & "'  And Continued=1 "
    '                If index <> -1 Then
    '                    strQuery = strQuery & " and BLH_ID ='" & Me.dgdPrice.Item("BL_IDP", index).Value.ToString & "'" ' SO HOUSE BILL LA BL_ID

    '                Else
    '                    strQuery = strQuery & " and BLH_ID ='" & Me.dgdBillOfLading_House.Item("BLH_ID", indexBL).Value.ToString & "'"
    '                End If


    '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '                If Not rs.EOF Then
    '                    DisplayMessage(True, "This item had added !, please check again.!")
    '                    Exit Sub
    '                End If
    '                rs.Close()
    '            End If


    '            Dim indexBill As Integer = Me.dgdBillOfLading_House.CurrentRow.Index

    '            'If mStatusP = "Add" Then
    '            '    strQuery = "SELECT * "
    '            '    strQuery = strQuery & "FROM PriceBillMaster "
    '            '    strQuery = strQuery & "WHERE BL_Id = '" & BillID & "' AND Items='" & Me.cbo.Text & "'"
    '            'Else
    '            strQuery = "Select * from PriceBillHouse where PriceHouse_id='" & mPrice_ID & "'"
    '            'End If
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


    '            With rs
    '                If mStatusP = "Add" Then
    '                    .AddNew()
    '                    .Fields("PriceHouse_ID").Value = NewId()

    '                    .Fields("BLH_ID").Value = "{" & BillHouseID & "}"

    '                End If
    '                .Fields("Charge_ID").Value = "{" & FindValueID(Me.cboItems, Me.cboItems.Text) & "}"
    '                mPrice_ID = .Fields("PriceHouse_ID").Value
    '                .Fields("Prepaid_Collect").Value = Me.cboPrepaidCollectP.Text

    '                .Fields("POP").Value = Me.txtPOP.Text
    '                .Fields("Quantity").Value = Me.txtQuantityBIll.Text
    '                .Fields("IG_Code").Value = Me.txtIG_Code.Text
    '                .Fields("Currency").Value = Me.cboCurrencyP.Text
    '                .Fields("UnitPrice").Value = Me.txtUnitPrice.Text
    '                .Update()

    '                'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
    '                'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

    '            End With
    '            rs.Close()


    '            '-----------------
    '            Me.cboItems.Enabled = False
    '            Me.cboCurrencyP.Enabled = False
    '            Me.cboPrepaidCollectP.Enabled = False
    '            Me.txtUnitPrice.Enabled = False
    '            Me.cmdOKP.Enabled = False
    '            'mStatusP = "Normal"

    '            Me.dgdPrice.Enabled = True
    '            mStatusP = "Normal"
    '            Me.cmdOKP.Enabled = False
    '            QueryPrice(" And BLH_ID='" & BillHouseID & "'", indexBill)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub


    '    Private Sub ctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAdd.Click
    '        If Not UserRight("frmListBillOfLadingHouse", "Execute") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            Exit Sub
    '        End If
    '        mStatusP = "Add"
    '        Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
    '        BillHouseID = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
    '        mPrice_ID = DefaultValue
    '        Me.cboItems.Enabled = True
    '        Me.cboCurrencyP.Enabled = True
    '        Me.cboPrepaidCollectP.Enabled = True
    '        Me.txtUnitPrice.Enabled = True
    '        Me.cmdOKP.Enabled = True
    '        Me.txtIG_Code.Enabled = True

    '    End Sub

    '    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        mStatusP = "Normal"
    '        Me.cboItems.Enabled = False
    '        Me.cboCurrencyP.Enabled = False
    '        Me.cboPrepaidCollectP.Enabled = False
    '        Me.txtUnitPrice.Enabled = False
    '        Me.txtPOP.Enabled = False
    '        Me.txtQuantityBIll.Enabled = False
    '        Me.cmdOKP.Enabled = False

    '    End Sub

    '    Private Sub ctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEdit.Click
    '        If Not UserRight("frmListBillOfLadingHouse", "Execute") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            Exit Sub
    '        End If
    '        mStatusP = "Edit"
    '        Dim Editable, Approve As Boolean
    '        Dim index As Integer
    '        If Me.dgdPrice.Rows.Count = 0 Then
    '            Return
    '        End If
    '        If Me.oTable.Rows.Count > 0 Then
    '            index = Me.dgdPrice.CurrentRow.Index
    '        Else
    '            Exit Sub
    '        End If

    '        If index >= 0 Then
    '            Approve = Me.dgdPrice.Item("ApproveP", index).Value
    '            Editable = Me.dgdPrice.Item("EditableP", index).Value
    '            If mStatusP = "Edit" And Not Approve And Editable And UserRight("frmListBillOfLadingHouse", "Edit") Then
    '                mPrice_ID = Me.dgdPrice.Item("Price_ID", index).Value.ToString
    '                Me.cboItems.Enabled = True
    '                Me.cboCurrencyP.Enabled = True
    '                Me.cboPrepaidCollectP.Enabled = True
    '                Me.txtUnitPrice.Enabled = True
    '                Me.cmdOKP.Enabled = True
    '                Me.txtIG_Code.Enabled = True
    '                Me.cboItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
    '                Me.cboCurrencyP.Text = Me.dgdPrice.Item("CurrencyP", index).Value.ToString
    '                Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString
    '                Me.txtQuantityBIll.Text = Me.dgdPrice.Item("Quantity", index).Value.ToString
    '                Me.cboPrepaidCollectP.Text = Me.dgdPrice.Item("PrePaid_CollectP", index).Value.ToString
    '                Me.txtUnitPrice.Text = Me.dgdPrice.Item("UnitPrice", index).Value.ToString
    '                Me.txtIG_Code.Text = Me.dgdPrice.Item("IG_Code", index).Value.ToString

    '            Else
    '                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            End If
    '        End If




    '    End Sub

    '    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged

    '        If Me.fraUpdate.Visible = True Then
    '            QueryItems()
    '            mChargeID = DefaultValue

    '            If Me.dgdBillOfLading_House.RowCount > 0 Then
    '                Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
    '                BillHouseID = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
    '                QueryPrice(" And BLH_ID='" & BillHouseID & "'", index, )
    '            End If
    '        End If
    '    End Sub

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
    '        If Not UserRight("frmListBillOfLadingHouse", "Execute") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '        Else
    '            strMesg = "Delete the Detail of Price: " & Me.dgdPrice.Item("Items", index).Value.ToString
    '            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
    '                strQuery = "Select * from PriceBillHouse where PriceHouse_ID='" & Me.dgdPrice.Item("Price_ID", index).Value.ToString & "'"
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
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub ctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel.Click
    '        If Not UserRight("frmListBillOfLadingHouse", "Execute") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            Exit Sub
    '        End If
    '        Dim selectedRowCount As Integer = _
    '    Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
    '        If selectedRowCount >= 0 Then
    '            Dim sb As New System.Text.StringBuilder()
    '            Dim i As Integer
    '            For i = 0 To selectedRowCount - 1
    '                DeleteRowP(Me.dgdPrice.SelectedRows(i).Index)
    '            Next i
    '        End If
    '        Dim index As Integer = 0
    '        If Me.dgdBillOfLading_House.RowCount > 0 Then
    '            index = Me.dgdBillOfLading_House.CurrentRow.Index
    '        End If
    '        QueryPrice(" And BLH_ID='" & Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString.Trim & "'", index, )
    '    End Sub
    '    Public Sub ApprovePrice()
    '        On Error GoTo Err_Renamed
    '        Dim Approve As Boolean
    '        ' Xác định vị trí row trong grid
    '        Dim rs As New ADODB.Recordset
    '        Dim index As Integer = Me.dgdPrice.CurrentRow.Index
    '        Dim strQuery As String

    '        If Not Me.dgdPrice.Item("EditableP", index).Value Or Not UserRight("frmListBillOfLadingHouse", "Execute") Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            QueryPrice(, index)
    '        Else
    '            strQuery = "Select * from PriceBillHouse where" + " PriceHouse_Id= '" & Me.dgdPrice.Item("Price_ID", index).Value.ToString & "'"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            Approve = Not rs.Fields("Approve").Value
    '            rs.Update("Approve", Approve)
    '            rs.Close()
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Private Sub dgdPrice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    '        Dim ColIndex, RowIndex As Integer
    '        ' Xác định vị trí row trong grid
    '        Dim index As Integer = Me.dgdPrice.CurrentRow.Index
    '        On Error GoTo Err_Renamed
    '        ColIndex = e.ColumnIndex()
    '        RowIndex = e.RowIndex
    '        If ColIndex < 0 Then
    '            Return
    '        End If
    '        'MsgBox(Me.dgdPrice.CurrentCellAddress.X)
    '        If Me.dgdPrice.Columns(ColIndex).Name = "ApproveP" And Me.dgdPrice.CurrentCellAddress().Y = RowIndex Then
    '            Call ApprovePrice()
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))

    '    End Sub

    Private Sub smnuExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        Me.Close()
        mStatus = "Normal"
        mStatusP = "Normal"
        mStatusR = "Normal"

    End Sub

    Private Sub smnuBillOfLadingHouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuBillOfLadingHouse.Click
        
    End Sub

    Private Sub smnuManiFest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString


            VB6.ShowForm(frmRptExportCargo_HouseManiFest, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOKR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKR.Click
        On Error GoTo Err_Renamed
        If mStatusR = "Add" Or mStatusR = "Edit" Then


            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.dgdBillOfLading_House.RowCount > 0 Then
                index = Me.dgdBillOfLading_House.CurrentRow.Index()
            Else
                Exit Sub
            End If

            ' Dim indexBill As Integer = Me.dgdBillOfLading.CurrentRow.Index

            'If mStatusP = "Add" Then
            '    strQuery = "SELECT * "
            '    strQuery = strQuery & "FROM PriceBillMaster "
            '    strQuery = strQuery & "WHERE BL_Id = '" & BillID & "' AND Items='" & Me.cbo.Text & "'"
            'Else
            strQuery = "Select * from Routing_House  where Routing_ID='" & ROUTINGID & "' And Continued=1"
            'End If
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


            With rs
                If mStatusR = "Add" Then
                    .AddNew()
                    .Fields("Routing_ID").Value = NewId()
                    .Fields("BLH_ID").Value = "{" & mBILLOFLADING_HOUSEId & "}"
                End If
                'mPrice_ID = .Fields("Price_ID").Value
                .Fields("Port_From").Value = Me.txtportfromcode.Text.Trim()

                'If (Me.chkFromDate.Checked) Then
                .Fields("From_Date").Value = Me.DTPFromDate.Value.Date
                'Else
                ' .Fields("From_Date").Value = vbNull
                'End If
                'If Me.chkTodate.Checked Then
                .Fields("To_Date").Value = Me.DTPToDate.Value.Date
                ' Else
                '.Fields("To_Date").Value = vbNull
                'End If

                .Fields("Port_To").Value = Me.txtPortToCode.Text.Trim

                .Fields("SEQ").Value = Me.txtSEQ.Text.Trim
                .Fields("MOT").Value = Me.txtMOT.Text.Trim
                .Fields("Vessel_Code").Value = Me.txtRoutingVesselCode.Text
                .Fields("VoyAge").Value = Me.txtRoutingVoyAge.Text.Trim
                .Update()

                'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
                'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

            End With
            rs.Close()
            'If mStatusR = "Add" Then
            '    InsertRouting_House()
            'End If
            '
            RefreshRouting(False)
            '-----------------
            'chen ngay den vao 
            Dim rsBillOfLadingList As New ADODB.Recordset
            Dim strMesg, strQueryCommodityList As String
            strMesg = "Chèn Ngày " + Me.DTPToDate.Value.Date.ToString + " vào ngày đến của lô hàng này : " & Me.dgdBillOfLading_House.Item("BLh_No", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from BillOFLading_house where" + " BLh_Id= '" & Me.dgdBillOfLading_House.Item("BLh_Id", index).Value.ToString & "'"
                rsBillOfLadingList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsBillOfLadingList.Fields("arrivaldate").Value = Me.DTPToDate.Value.Date.ToString
                rsBillOfLadingList.Update()


                rsBillOfLadingList.Close()
                'Me.QueryBILLOFLADING_HOUSE(" " & mFilter)
                'mnuRefesh_Click(sender, e)
            End If
            'mStatusP = "Normal"
            Me.dgdRouting.Enabled = True
            mStatusR = "Normal"

            QueryRouting(index)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub ctmnuAddR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAddR.Click
        On Error GoTo Err_Named
        mStatusR = "Add"
        ROUTINGID = DefaultValue
        RefreshRouting(True)
        Me.txtSEQ.Text = CStr(Me.dgdRouting.RowCount + 1)
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleteRowR(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        If Not IsNothing(Me.dgdRouting.Item("ApproveR", index).Value) Then
            If Me.dgdRouting.Item("ApproveR", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdRouting.Item("EditableR", index).Value) Then
            If Not Me.dgdRouting.Item("EditableR", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingHouse", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Detail of Routing : " & Me.dgdRouting.Item("From_Date", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from Routing_House where Routing_ID='" & Me.dgdRouting.Item("Routing_ID", index).Value.ToString & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()
                Me.dgdRouting.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdRouting.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub ctmnuEditR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEditR.Click
        On Error GoTo Err_Named

        Dim index As Integer = 0
        If Me.dgdRouting.Rows.Count > 0 Then
            index = Me.dgdRouting.CurrentRow.Index
        Else
            Exit Sub
        End If
        Dim approve, edittable As Boolean

        approve = Me.dgdRouting.Item("ApproveR", index).Value

        edittable = Me.dgdRouting.Item("EditableR", index).Value
        If mStatusR = "Normal" And Not approve And edittable And UserRight("frmListBillOfLadingHouse", "Edit") Then
            mStatusR = "Edit"
            ROUTINGID = Me.dgdRouting.Item("Routing_ID", index).Value.ToString
            RefreshRouting(True)

            'If Me.dgdRouting.Item("To_Date", index).Value.ToString <> "" Then
            Me.DTPToDate.Text = Me.dgdRouting.Item("To_Date", index).Value.ToString
            ' Me.chkTodate.Checked = True
            'Else
            ' Me.chkTodate.Checked = False
            'End If

            'If Me.dgdRouting.Item("From_Date", index).Value.ToString <> "" Then
            Me.DTPFromDate.Text = Me.dgdRouting.Item("From_Date", index).Value.ToString
            'Me.chkFromDate.Checked = True
            'Else
            'Me.chkFromDate.Checked = False
            'End If
            Me.txtPortToCode.Text = Me.dgdRouting.Item("Port_TO", index).Value.ToString
            Me.txtPortFromCode.Text = Me.dgdRouting.Item("Port_From", index).Value.ToString
            Me.txtSEQ.Text = Me.dgdRouting.Item("SEQ", index).Value.ToString
            Me.txtMOT.Text = Me.dgdRouting.Item("MOT", index).Value.ToString
            Me.txtRoutingVesselCode.Text = Me.dgdRouting.Item("Vessel_Code", index).Value.ToString
            Me.txtRoutingVoyAge.Text = Me.dgdRouting.Item("VoyAge", index).Value.ToString
        Else
            DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
        End If

        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveRouting()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim rs As New ADODB.Recordset
        Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
        Dim strQuery As String
        If Not Me.dgdRouting.Item("EditableR", index).Value Or Not UserRight("frmListBillOfLadingHouse", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryRouting(index)
        Else
            strQuery = "Select * from Routing_House where" + " Routing_ID= '" & Me.dgdRouting.Item("Routing_ID", index).Value.ToString & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuDelR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDelR.Click
        On Error GoTo err_named
        Dim selectedRowCount As Integer = _
    Me.dgdRouting.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowR(Me.dgdRouting.SelectedRows(i).Index)
            Next i
        End If
        Dim index As Integer = 0
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            index = Me.dgdBillOfLading_House.CurrentRow.Index
        End If
        QueryRouting(index)
        Exit Sub
err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdRouting_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdRouting.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdRouting.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdRouting.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        'MsgBox(Me.dgdPrice.CurrentCellAddress.X)
        If Me.dgdRouting.CurrentCellAddress.X = 13 And Me.dgdRouting.CurrentCellAddress().Y = RowIndex Then
            Call ApproveRouting()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCanCelR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCanCelR.Click
        On Error GoTo Err_Named
        RefreshRouting(False)
        mStatusR = "Normal"
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub RefreshRouting(ByVal b As Boolean)
        On Error GoTo Err_Named
        Me.txtPortToCode.Enabled = b
        Me.txtPortFromCode.Enabled = b
        'Me.DTPToDate.Enabled = Me.chkTodate.Checked
        'Me.DTPFromDate.Enabled = Me.chkFromDate.Checked
        Me.txtSEQ.Enabled = b
        Me.txtMOT.Enabled = b
        Me.cmdOKR.Enabled = b
        Me.txtRoutingVesselCode.Enabled = b
        Me.txtRoutingVoyAge.Enabled = b
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cboPortTo_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.txtPortToCode.Text = Trim(UCase(Me.txtPortToCode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.txtPortToCode.FindStringExact(Me.txtPortToCode.Text) = -1 Then
    '            Me.txtPortToCode.Text = FindBetter_new("code", strSql, Me.txtPortToCode.Text)
    '            If Me.txtPlofReceiptCode.FindStringExact(Me.txtPortToCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPortToCode.Focus()
    '            End If
    '        End If

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Private Sub cboPortTo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortToCode, Me.txtPortToCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPortToCode.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub cboBookingNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBookingNo.Leave
        On Error GoTo Err_Renamed
        Dim strSql, shipper_code As String
        strSql = "Select BookingNo  as BookingNo From containeroutboundnotify Where Continued=1"
        If Me.cboBookingNo.FindStringExact(Me.cboBookingNo.Text) = -1 Then
            Me.cboBookingNo.Text = FindBetter_new("BookingNo", strSql, Me.cboBookingNo.Text)
            If Me.cboBookingNo.FindStringExact(Me.cboBookingNo.Text) = -1 Then
                DisplayMessage(True, "The Booking No. is invalid, please check and correct it.")
                Me.cboBookingNo.Focus()
            End If
        End If
        cboBookingNo_Change()
        Exit Sub
Err_Renamed:
        'DisplayMessage(True, "")
        'Resume
    End Sub

    Private Sub cboBookingNo_Change()
        On Error GoTo Err_Renamed
        Dim BookingNo As String
        Dim i As Integer

        BookingNo = FindValueID(Me.cboBookingNo, Me.cboBookingNo.Text)
        'Me.txtSalePayer.Text = QueryPayerNote(BookingNo)
        'If Me.txtSalePayer.Text = "" Then
        '    Me.txtResultSelect.Text = Me.txtPayerShipper.Text
        '    Me.chkPayerShipper.Checked = True
        'Else
        '    Me.txtResultSelect.Text = Me.txtSalePayer.Text
        '    Me.chkSalePayer.Checked = True
        'End If
        If BookingNo <> "" Then
            Dim strSQL, sqlVIA As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset, dsetVIA As New DataSet
            Dim table As New DataTable
            Dim tableVIA As New DataTable
            '----------------
            'strQuery = "select * from CONTAINEROUTBOUNDNOTIFY where CONTAINEROUTBOUNDNOTIFYID='" & BookingNo & "'"
            strSQL = "Select ServiceContract,fileno,Carrier,VoyNo, SaleName,market_id,CONTAINEROUTBOUNDNOTIFY.SailingScheduleID, PortOfUnLoading,tranship,VIA2,VIA3,VIA4,Destination,remarks,ETD  "
            strSQL &= " From CONTAINEROUTBOUNDNOTIFY "
            strSQL = strSQL & " "
            strSQL = strSQL & "  where CONTAINEROUTBOUNDNOTIFY.Continued=1 And ContainerOutBoundNotifyId='" & BookingNo & "'"

            Dim CmdSelect As New SqlClient.SqlCommand(strSQL, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            table.Clear()
            Adapter.Fill(dset, "Port")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                'sua ngay 3/7/07
                Me.dgdBookingRemarks.DataSource = table
                '--------------
                'Me.dgdBookingRemarks.Columns("Charge").Visible = False
                'Me.dgdBookingRemarks.Columns("Editable").Visible = False
                'Me.dgdBookingRemarks.Columns("Continued").Visible = False

                For i = 0 To Me.dgdBookingRemarks.Columns.Count - 1
                    If UCase(Me.dgdBookingRemarks.Columns(i).Name) Like "*ID" Then
                        Me.dgdBookingRemarks.Columns(i).Visible = False
                    End If
                Next
                '--------------
                Me.txtTariff.Text = table.Rows(0).Item("ServiceContract").ToString.Trim
                If table.Rows(0).Item("ServiceContract").ToString.Trim.Length > 10 Then
                    DisplayMessage(True, "Please check S/C Number, It's overflow.!")
                End If
                Me.txtServiceContract.Text = table.Rows(0).Item("ServiceContract").ToString.Trim
                Me.txtFileno.Text = table.Rows(0).Item("fileno").ToString.Trim
                Me.txtPreVessel.Text = table.Rows(0).Item("Carrier").ToString.Trim
                Me.txtPreVesselNo.Text = table.Rows(0).Item("VOYNo").ToString.Trim
                Me.txtSaleName.Text = table.Rows(0).Item("SaleName").ToString.Trim
                '-------transit
                'Me.txtTransport1.Text = PortCode(table.Rows(0).Item("tranship").ToString.Trim)
                Me.txtTransport2.Text = table.Rows(0).Item("VIA2").ToString
                Me.txtTransport3.Text = table.Rows(0).Item("VIA3").ToString
                Me.txtTransport4.Text = table.Rows(0).Item("VIA4").ToString
                'Me.txtPortOfDisChargeCode.Text = PortCode(table.Rows(0).Item("PortOfUnLoading").ToString.Trim).Trim
                'Me.txtBookingPOD.Text = PortCode(table.Rows(0).Item("PortOfUnLoading").ToString.Trim).Trim
                'Me.txtPortOfDestinationCode.Text = PortCode(table.Rows(0).Item("Destination").ToString.Trim).Trim
                'Me.txtPortOfDeliveryCode.Text = PortCode(table.Rows(0).Item("Destination").ToString.Trim).Trim
                Me.DTPDate_Of_Issue.Value = table.Rows(0).Item("etd").ToString.Trim
                Me.DTPLoad_Date.Value = table.Rows(0).Item("etd").ToString.Trim
                Me.DTPFromDate.Value = table.Rows(0).Item("etd").ToString.Trim
                ';----------
                'Me.txtTradeCode.Text = getTradeCode(Me.txtPortOfLoadingCode.Text.Trim, Me.txtPortOfDestinationCode.Text.Trim)

                'Me.txtTradeCode.Text = FindIDValue(Me.txtTradeCode, table.Rows(0).Item("Market_Id").ToString)
                'them vao dgd
                '-- lay các Port VIA tu lich tau di 270607
                'Dim SailingScheduleID As String = table.Rows(0).Item("SailingScheduleID").ToString.Trim
                'sqlVIA = "Select port_code  "
                'sqlVIA &= " From ETASCHEDULE inner join Port on ETASCHEDULE.portid=port.port_id where SailingScehduleID='" & SailingScheduleID & "' AND ETASCHEDULE.CONTINUED=1 order by ETASCHEDULE.updatetime "
                'Dim CmdSelectVIA As New SqlClient.SqlCommand(sqlVIA, Con)
                'Dim AdapterVIA As New SqlClient.SqlDataAdapter(CmdSelectVIA)
                'tableVIA.Clear()
                'AdapterVIA.Fill(dsetVIA, "Port")
                'tableVIA = dsetVIA.Tables(0)
                'If tableVIA.Rows.Count > 0 Then

                '    Select Case tableVIA.Rows.Count
                '        Case 1
                '            Me.txtTransport1.Text = tableVIA.Rows(0).Item("port_code").ToString.Trim
                '        Case 2
                '            Me.txtTransport1.Text = tableVIA.Rows(0).Item("port_code").ToString.Trim
                '            Me.txtTransport2.Text = tableVIA.Rows(1).Item("port_code").ToString.Trim
                '        Case 3
                '            Me.txtTransport1.Text = tableVIA.Rows(0).Item("port_code").ToString.Trim
                '            Me.txtTransport2.Text = tableVIA.Rows(1).Item("port_code").ToString.Trim
                '            Me.txtTransport3.Text = tableVIA.Rows(2).Item("port_code").ToString.Trim
                '        Case 4
                '            Me.txtTransport1.Text = tableVIA.Rows(0).Item("port_code").ToString.Trim
                '            Me.txtTransport2.Text = tableVIA.Rows(1).Item("port_code").ToString.Trim
                '            Me.txtTransport3.Text = tableVIA.Rows(2).Item("port_code").ToString.Trim
                '            Me.txtTransport4.Text = tableVIA.Rows(3).Item("port_code").ToString.Trim
                '    End Select
                'End If
                '---------------------------------
                '  PLACEOFRECEIPTID = table.Rows(0).Item("BookingNo").ToString
            End If
            Me.txtRoutingVesselCode.Text = Me.txtPreVessel.Text
            Me.txtRoutingVoyAge.Text = Me.txtPreVesselNo.Text
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListBillOfLadingHouse", "Add") Then
            Me.grpBillHouse.Visible = True
            Me.grpBillHouse.BringToFront()
            Me.txtBillHouse.Text = Me.cboBillOfLading_House.Text.Trim
            'Me.cboBillOfLading_House.Enabled = False
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryItems()
        On Error GoTo ERR_NAMED
        Dim id As String = "CHARGE_ID"
        Dim value As String = "CHARGE_code"
        Dim strQuery As String = "Select CHARGE_ID,CHARGE_code from CHARGE where CONTINUED=1 Order by Charge"
        loadDataToObject(Me.txtItems, strQuery, id, value)



        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub smnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index, chk As Integer
        index = -1
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng Bill để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.Rows.Count > 0 Then
            index = Me.dgdBillOfLading_House.CurrentRow.Index
        Else
            Exit Sub
        End If
        'Me.txtMF_FilingType.Text = Me.cboBillOfLading_House.Text
        If index >= 0 Then
            QueryRouting(index)
            HideTextCargo()
            Approve = Me.dgdBillOfLading_House.Item("Approve", index).Value
            EditTable = Me.dgdBillOfLading_House.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLadingHouse", "Edit") And Not Me.dgdBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.tagInformationCustomer.Visible = True

                If Me.dgdBillOfLading_House.RowCount > 0 Then
                    index = Me.dgdBillOfLading_House.CurrentRow.Index
                End If
                mBILLOFLADING_HOUSEId = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
                ' Me.txtBillOfLadingId.Text = Me.dgdBillOfLading.Item("BL_No", index).Value.ToString
                mStatus = "Edit"
                Me.fraUpdate.Visible = True
                Me.dgdBillOfLading_House.Height = 306
                Me.dgdBillOfLading_House.Enabled = False

                ReFormat()
                SetMenu((False))
                'Me.txtNotify3.Text = ""
                'Me.txtNotify2.Text = ""
                RefreshData(index)
                mBL_ClauseID = DefaultValue
                Me.tagInformationCustomer.SelectTab(Me.TabCustomer)
                Me.txtMF_FilingType.Text = Me.cboBillOfLading_House.Text
                Me.QueryPrice()
                'mBillOfLadingId = oTable.Rows(index).Item("BillOfLadingId").ToString
                'mStatus = "Edit"
                'reText(mStatus)
                ''RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cboPortfrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtportfromcode, Me.txtportfromcode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtportfromName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryBILLOFLADING_HOUSE("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdBillOfLading_House.Rows.Count > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdBillOfLading_House, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cxtsmnuShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuShipper.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtShipper.Name
            Dim frm As New frmListShipper
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuConsignee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuConsignee.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtConsignee.Name
            Dim frm As New frmListConsignee
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuNotify.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtNotify.Name
            Dim frm As New frmListNotify
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPlofReceiptCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPlofReceiptCode.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPlofReceiptCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortOfloading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortOfloading.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPortOfLoadingCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortOfDischarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortOfDischarge.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPortOfDisChargeCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortOfDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortOfDelivery.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPortOfDeliveryCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortDestination.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPortOfDestinationCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPlaceCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPlaceCode.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPlaceCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortFrom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortFrom.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPortFromCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'Private Sub cxtsmnuPortTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortTo.Click
    '    Try
    '        gSForm = Me.Name
    '        gSCombo = Me.txtPortToCode.Name
    '        Dim frm As New frmListPort
    '        frm.ShowDialog(Me)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub dgdBillOfLading_House_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBillOfLading_House.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdBillOfLading_House)
    End Sub

    'Private Sub dgdPrice_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
    '    InsertAutoNumberToGrid(Me.dgdPrice)
    'End Sub
    Sub QueryBillPrice(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Charge_Code,Charge,Currency,UnitPrice,Quantity,IG_Code ,POP,PrePaid_Collect "
        strQuery &= " from (PRICEBILLHOUSE LEFT JOIN Charge On PRICEBILLHOUSE.Charge_id=Charge.Charge_ID) "
        strQuery &= " Where BLH_ID='" & gBillOfLadingHouseRpt & "' And PRICEBILLHOUSE.Continued=1"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "BillOfLadingList")
        dt = ds.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryFreightCharge()
        On Error GoTo Err_Named
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Charge_Code,Charge,Currency,AMOUNT as UnitPrice,UNIT_OF_QUANTITY,Quantity,POP,Prepaid_collect,CONTAINER_TYPE,RATE_OF_FR_CH,PAYER_CODE,IG_CODE "
        strQuery &= ", Port_Code as PAYABLE_AT_CODE, Port As PAYABLE_AT "
        strQuery &= "  from ((FREIGHT_CHARGE_House LEFT JOIN Charge On FREIGHT_CHARGE_House.Charge_Id=Charge.Charge_ID)"
        strQuery &= " INNER JOIN Port on FREIGHT_CHARGE_House.PAYABLE_AT_ID=Port.Port_ID) "
        strQuery &= " where BLH_ID='" & gBillOfLadingHouseRpt & "' And FREIGHT_CHARGE_House.Continued=1"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableFreightCharge) Then
            oTableFreightCharge.Clear()
        End If
        Adapter.Fill(ds, "Unit")
        oTableFreightCharge = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryUnit(ByRef otableUnit)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select CTN_SIZE_TYPE as type,Count(CTN_SIZE_TYPE) as Num from (container LEFT JOIN Cargo_House on Cargo_House.CTN_ID=Container.CTN_ID) where Cargo_House.BLH_ID='" & gBillOfLadingHouseRpt & "' And Cargo_House.Continued=1 Group by CTN_SIZE_TYPE"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(otableUnit) Then
            otableUnit.Clear()
        End If
        Adapter.Fill(ds, "Unit")
        otableUnit = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Function QueryBL_Clause(ByVal ID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select * from BL_Clause Where BL_ClauseID='" & ID & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub QueryNotify(ByRef dt As DataTable, ByVal NotifyID As String)
        Dim strQuery As String
        strQuery = " Select top 1 Notify.Notify_Code,Notify.Notify_ID,Notify.Notify_1 ,Notify.Notify_2, Notify.Notify_3,Notify.Notify_4,Notify.Notify_5,Notify.Notify_6, Notify.Remarks as RemarksNotify "
        strQuery &= " From (BillOfLading_House LEFT JOIN Notify On BillOfLading_House." & NotifyID & "=Notify.Notify_ID) "
        strQuery &= " Where BillofLading_House.Continued=1 And BLH_ID='" & gBillOfLadingHouseRpt & "' " 'And " & NotifyID & "<>'" & DefaultValue & "'"

        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
        Dim Adapter As New SqlClient.SqlDataAdapter(cmd)

        Try
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()
            Adapter.Dispose()
            Conn = Nothing
            cmd = Nothing
            Adapter = Nothing
        End Try
    End Sub

    'Function ReplaceSym(ByVal str As String) As String
    '    Dim temp As String = str
    '    Dim Sym() As String = {"`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "-", "+", "\", "|", "'", ":", """", "<", ">", "{", "}"}
    '    For i As Integer = 0 To Sym.Length - 1
    '        temp = Strings.Replace(temp, Sym(i), "?" & Sym(i))
    '    Next
    '    temp = Strings.Replace(temp, Chr(13), "^n")
    '    Return temp
    'End Function

    Private Sub mnuManifestFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManifestFile.Click
        On Error GoTo Err_Named
        Dim index As Integer
        If Me.dgdBillOfLading_House.Rows.Count > 0 Then
            index = Me.dgdBillOfLading_House.CurrentRow.Index
        Else
            Exit Sub
        End If
        If Me.dgdBillOfLading_House.Item("BookingNO", index).Value.ToString = "" And Me.dgdBillOfLading_House.Item("SHIPPERNAME", index).Value.ToString = "" Or Me.dgdBillOfLading_House.Item("gridchecking", index).Value = True Then
            MsgBox("Bill chưa có đủ thông tin ")
            Return
        End If
        gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
        gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
        Dim path As String
        SaveFileDialog.InitialDirectory = "C:\"
        SaveFileDialog.Filter = "Notepad files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog.FileName = gBillHouseNoRpt
        If SaveFileDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            path = SaveFileDialog.FileName
        Else
            Return
        End If
        Dim fw As New StreamWriter(path, False)
        Dim temp, Mean As String
        Dim datetime As Date
        Dim EndRecord As String = "'"
        Dim dt As New DataTable
        QueryVesselInfo(dt)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Record 00
        temp = "00:IFCSUM:MANIFEST:9:::" & Strings.Right(Today.Year.ToString, 2) & IIf(Now().Month <= 9, "0" & Now().Month, Now().Month)
        temp &= IIf(Now().Day <= 9, "0" & Now.Day, Now.Day)
        temp &= IIf(Now().Hour <= 9, "0" & Now.Hour, Now.Hour)
        temp &= IIf(Now().Minute <= 9, "0" & Now.Minute, Now.Minute) & EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Record 10
        temp = "10:"
        If dt.Rows.Count > 0 Then
            temp &= IIf(dt.Rows(0).Item("Vessel_Code").ToString.Trim <> "", dt.Rows(0).Item("Vessel_Code").ToString.Trim, "") & ":"
            temp &= IIf(dt.Rows(0).Item("Vessel").ToString.Trim <> "", dt.Rows(0).Item("Vessel").ToString.Trim, "") & ":"
            temp &= IIf(dt.Rows(0).Item("NATIONALITY").ToString.Trim <> "", dt.Rows(0).Item("NATIONALITY").ToString.Trim, "") & ":"
            temp &= dt.Rows(0).Item("VoyNo").ToString.Trim & ":CSC" & EndRecord
        End If
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Record 12
        temp = "12:" & gBillHouseNoRpt & "::::"
        'field 6
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString.Trim, "") & ":"
        'field 7
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_RECEIPT", index).Value.ToString.Trim, "") & ":"
        'field 8
        temp &= IIf(Me.dgdBillOfLading_House.Item("PORT_OF_LOADING_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PORT_OF_LOADING_CODE", index).Value.ToString.Trim, "") & ":"
        'field 9
        temp &= IIf(Me.dgdBillOfLading_House.Item("PORT_OF_LOADING_NAME", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PORT_OF_LOADING_NAME", index).Value.ToString.Trim, "") & ":"
        'field 10
        If UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-CY*" Then
            Mean = "11"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-CFS*" Then
            Mean = "12"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-DOOR*" Then
            Mean = "13"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-TACKLE*" Then
            Mean = "14"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-FIO*" Then
            Mean = "15"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-LIO*" Then
            Mean = "16"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-LO*" Then
            Mean = "17"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-FI*" Then
            Mean = "18"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-FO*" Then
            Mean = "19"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-RAMP*" Then
            Mean = "1R"
        End If
        temp &= Mean & ":"

        'field 11
        If UCase(Me.dgdBillOfLading_House.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "COLLECT" Then
            temp &= "C"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "PREPAID" Then
            temp &= "P"
        Else
            temp &= ""
        End If
        temp &= ":"
        'field 12
        datetime = Me.dgdBillOfLading_House.Item("LOAD_DATE", index).Value
        temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month) & IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
        'field 13
        temp &= ":" & IIf(Me.dgdBillOfLading_House.Item("QUARANTINE_CODING", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("QUARANTINE_CODING", index).Value.ToString.Trim, "") & ":"
        'field 14
        datetime = Me.dgdBillOfLading_House.Item("DATE_OF_ISSUE", index).Value
        temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month) & IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
        temp &= ":"
        'field 15
        temp &= IIf(Me.dgdBillOfLading_House.Item("CURRENCY", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("CURRENCY", index).Value.ToString.Trim, "") & ":"
        'field 16
        temp &= IIf(Me.dgdBillOfLading_House.Item("EXCHANGE_RATE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("EXCHANGE_RATE", index).Value.ToString.Trim, "") & ":"
        'field 17
        temp &= IIf(Me.dgdBillOfLading_House.Item("MF_FILING_TYPE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("MF_FILING_TYPE", index).Value.ToString.Trim, "") & ":"
        'field 18
        temp &= IIf(Me.dgdBillOfLading_House.Item("NVOCC_MASTER_BL_NO", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("NVOCC_MASTER_BL_NO", index).Value.ToString.Trim, "") & ":"
        'field 19
        temp &= IIf(Me.dgdBillOfLading_House.Item("SCAC_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("SCAC_CODE", index).Value.ToString.Trim, "") & ":"
        'field 20
        temp &= IIf(Me.dgdBillOfLading_House.Item("TRADE_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("TRADE_CODE", index).Value.ToString.Trim, "") & ":"
        'field 21
        temp &= IIf(Me.dgdBillOfLading_House.Item("BL_OTHER_REF", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("BL_OTHER_REF", index).Value.ToString.Trim, "") & ":"
        'field 22
        temp &= IIf(Me.dgdBillOfLading_House.Item("BL_TYPE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("BL_TYPE", index).Value.ToString.Trim, "") & ":"
        'field 23
        temp &= IIf(Me.dgdBillOfLading_House.Item("PAYABLE_AT", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PAYABLE_AT", index).Value.ToString.Trim, "") & ":"
        'field 24 
        If UCase(Me.dgdBillOfLading_House.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "COLLECT" Then
            temp &= "C"
        ElseIf UCase(Me.dgdBillOfLading_House.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "PREPAID" Then
            temp &= "S"
        Else
            temp &= "O"
        End If
        temp &= ":"
        'field 25
        temp &= IIf(Me.dgdBillOfLading_House.Item("NO_OF_COPY_BL", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("NO_OF_COPY_BL", index).Value.ToString.Trim, "") & ":"
        'field 26
        temp &= IIf(Me.dgdBillOfLading_House.Item("NO_OF_ORIGINAL_BL", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("NO_OF_ORIGINAL_BL", index).Value.ToString.Trim, "") & ":"
        'field 27
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading_House.Item("CUSTOMS_CLEARED_PLACE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("CUSTOMS_CLEARED_PLACE", index).Value.ToString.Trim, ""), ":", "?:") & ":"
        'field 28
        temp &= IIf(Me.dgdBillOfLading_House.Item("SLOT_SHARE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("SLOT_SHARE", index).Value.ToString.Trim, "") & ":"
        'field 29 
        temp &= IIf(Me.dgdBillOfLading_House.Item("US_SERVICE_MODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("US_SERVICE_MODE", index).Value.ToString.Trim, "")
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''
        'record 13
        'field 1
        temp = "13:"
        'field 2
        temp &= IIf(Me.dgdBillOfLading_House.Item("PORT_OF_DISCHARGE_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PORT_OF_DISCHARGE_CODE", index).Value.ToString.Trim, "") & ":"
        'fieldc3
        temp &= IIf(Me.dgdBillOfLading_House.Item("PORT_OF_DISCHARGE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PORT_OF_DISCHARGE", index).Value.ToString.Trim, "") & ":"
        'field 4
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_DELIVERY_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_DELIVERY_CODE", index).Value.ToString.Trim, "") & ":"
        'field 5
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_DELIVERY", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_DELIVERY", index).Value.ToString.Trim, "") & ":"
        'field 6
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_DESTINATION_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_DESTINATION_CODE", index).Value.ToString.Trim, "") & ":"
        'field 7
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_DESTINATION", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_DESTINATION", index).Value.ToString.Trim, "") & ":"
        'field 8
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_BL_ISSUE_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_BL_ISSUE_CODE", index).Value.ToString.Trim, "") & ":"
        'field 9
        temp &= IIf(Me.dgdBillOfLading_House.Item("PLACE_OF_BL_ISSUE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PLACE_OF_BL_ISSUE", index).Value.ToString.Trim, "") & ":"
        'field 10
        temp &= IIf(Me.dgdBillOfLading_House.Item("TRANSFER_PORT1", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("TRANSFER_PORT1", index).Value.ToString.Trim, "") & ":"
        'field 11
        temp &= IIf(Me.dgdBillOfLading_House.Item("TRANSFER_PORT2", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("TRANSFER_PORT2", index).Value.ToString.Trim, "") & ":"
        'field 12
        temp &= IIf(Me.dgdBillOfLading_House.Item("TRANSFER_PORT3", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("TRANSFER_PORT3", index).Value.ToString.Trim, "") & ":"
        'field 13
        temp &= IIf(Me.dgdBillOfLading_House.Item("TRANSFER_PORT4", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("TRANSFER_PORT4", index).Value.ToString.Trim, "")
        temp &= EndRecord
        fw.WriteLine(temp)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 14

        QueryRoutingInfo(dt)
        Dim row As DataRow
        For Each row In dt.Rows
            temp = "14:"
            'field 1
            temp &= IIf(row.Item("Port_From").ToString.Trim <> "", row.Item("Port_From").ToString.Trim, "") & ":"
            'field 2
            datetime = row.Item("From_Date")
            temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month)
            temp &= IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day) & ":"
            'field 3
            temp &= IIf(row.Item("Port_To").ToString.Trim <> "", row.Item("Port_To").ToString.Trim, "") & ":"
            'field 4
            datetime = row.Item("To_Date")
            temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month)
            temp &= IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
            temp &= ":"
            'field 5
            temp &= IIf(row.Item("Vessel_Code").ToString.Trim <> "", row.Item("Vessel_Code").ToString.Trim, "") & ":"
            'field 6
            temp &= IIf(row.Item("VoyAge").ToString.Trim <> "", row.Item("VoyAge").ToString.Trim, "") & ":"
            'field 7
            temp &= Strings.Replace(IIf(row.Item("SEQ").ToString.Trim <> "", row.Item("SEQ").ToString.Trim, ""), ":", "?:") & ":"
            'field 8
            temp &= IIf(row.Item("MOT").ToString.Trim <> "", row.Item("MOT").ToString.Trim, "")
            temp &= EndRecord
            fw.WriteLine(temp)
        Next
        Dim Container_Type As String
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 15
        'temp = "15: '"

        'Dim CountContainer As Integer = 0
        'QueryUnit(dt)
        'QueryFreightCharge()
        'Dim RowUnit As DataRow

        'For Each row In oTableFreightCharge.Rows
        '    Select Case row.Item("Container_Type").ToString.Trim
        '        Case "20GP"
        '            Container_Type = "22G1"
        '        Case "40GP"
        '            Container_Type = "42G1"
        '        Case "20RF"
        '            Container_Type = "22R1"
        '        Case "40RF"
        '            Container_Type = "42R1"
        '        Case "40HC"
        '            Container_Type = "45G1"
        '        Case "40RH"
        '            Container_Type = "45R1"
        '        Case "45HC"
        '            Container_Type = "L2G0"
        '        Case "20OT"
        '            Container_Type = "22U1"
        '        Case "40OT"
        '            Container_Type = "42U1"
        '        Case "20FR"
        '            Container_Type = "22P3"
        '        Case "40FR"
        '            Container_Type = "42P3"
        '        Case Else
        '            Container_Type = ""

        '    End Select
        '    temp = "15:"
        '    'field 2
        '    temp &= IIf(row.Item("Charge_Code").ToString <> "", row.Item("Charge_Code").ToString.Trim, "") & ":"
        '    'field 3
        '    temp &= IIf(row.Item("Charge").ToString <> "", Strings.Left(row.Item("Charge").ToString.Trim, 18), "") & ":"
        '    'field 4
        '    temp &= IIf(row.Item("PAYABLE_AT_CODE").ToString.Trim <> "", row.Item("PAYABLE_AT_CODE").ToString.Trim, "") & ":"
        '    'field 5
        '    temp &= IIf(row.Item("PAYABLE_AT").ToString.Trim <> "", row.Item("PAYABLE_AT").ToString.Trim, "") & ":"
        '    'For Each RowUnit In dt.Rows
        '    '    If row.Item("Container_Type").ToString.Trim = RowUnit.Item("Type").ToString.Trim Then
        '    '        'field 6
        '    '        temp &= RowUnit.Item("Num").ToString & ":"
        '    '        CountContainer = RowUnit.Item("Num")
        '    '        Exit For
        '    '    End If
        '    'Next
        '    temp &= Strings.Replace(IIf(row.Item("Quantity").ToString.Trim <> "", row.Item("Quantity").ToString.Trim, ""), ":", "?:") & ":"
        '    'field 7
        '    temp &= IIf(row.Item("Currency").ToString.Trim <> "", row.Item("Currency").ToString.Trim, "") & ":"
        '    'field 8
        '    temp &= IIf(row.Item("UnitPrice").ToString.Trim <> "", row.Item("UnitPrice"), "") & ":"
        '    'field 9
        '    temp &= IIf(row.Item("UNIT_OF_QUANTITY").ToString.Trim <> "", row.Item("UNIT_OF_QUANTITY"), "") & ":"
        '    'field 10
        '    temp &= row.Item("UnitPrice") * CountContainer & ":"
        '    'field 11
        '    If UCase(row.Item("PREPAID_COLLECT").ToString).Trim = "POP.O" Then
        '        temp &= "O:"
        '    Else
        '        If UCase(row.Item("PREPAID_COLLECT").ToString.Trim) = "COLLECT" Then
        '            temp &= "C:"
        '        Else
        '            temp &= "P:"
        '        End If
        '    End If
        '    'field 12
        '    temp &= Container_Type & ":"
        '    'field 13
        '    temp &= IIf(row.Item("PAYER_CODE").ToString.Trim <> "", row.Item("PAYER_CODE").ToString.Trim, "") & ":"
        '    'field 14
        '    temp &= IIf(row.Item("IG_CODE").ToString.Trim <> "", row.Item("IG_CODE").ToString.Trim, "") & ":"
        '    temp &= EndRecord
        '    fw.WriteLine(temp)
        'Next
        '''''''''''
        ''Price Bill
        'QueryBillPrice(dt)
        'For Each row In dt.Rows
        '    temp = "15:"
        '    'field 2
        '    temp &= IIf(row.Item("Charge_Code").ToString <> "", row.Item("Charge_Code").ToString.Trim, "") & ":"
        '    'field 3
        '    temp &= IIf(row.Item("Charge").ToString <> "", Strings.Left(row.Item("Charge").ToString.Trim, 18), "") & ":"
        '    'field 4
        '    temp &= IIf(Me.dgdBillOfLading_House.Item("PAYABLE_AT", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PAYABLE_AT", index).Value.ToString.Trim, "") & ":"

        '    'field 5
        '    temp &= " :" 'payable  at name
        '    'field 6
        '    temp &= IIf(row.Item("Quantity").ToString.Trim <> "", row.Item("Quantity").ToString.Trim, "") & ":" 'phí bill không để số lương
        '    'field 7
        '    temp &= IIf(row.Item("Currency").ToString.Trim <> "", row.Item("Currency").ToString.Trim, "") & ":"
        '    'field 8
        '    temp &= IIf(row.Item("UnitPrice").ToString.Trim <> "", row.Item("UnitPrice").ToString.Trim, "") & ":"
        '    'field 9
        '    temp &= "BOX:"
        '    'field 10
        '    temp &= row.Item("UnitPrice") * row.Item("Quantity")
        '    temp &= ":"
        '    'field 11
        '    If UCase(row.Item("PREPAID_COLLECT").ToString).Trim = "POP.O" Then
        '        temp &= "O:"
        '    Else
        '        If UCase(row.Item("PREPAID_COLLECT").ToString.Trim) = "COLLECT" Then
        '            temp &= "C:"
        '        Else
        '            temp &= "P:"
        '        End If
        '    End If
        '    'field 12
        '    temp &= "99BL:"
        '    'field 13
        '    temp &= IIf(Me.dgdBillOfLading_House.Item("PAYER_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("PAYER_CODE", index).Value.ToString.Trim, "") & ":"
        '    'field 14
        '    temp &= Strings.Replace(IIf(row.Item("IG_CODE").ToString.Trim <> "", row.Item("IG_CODE").ToString.Trim, ""), ":", "?:")
        '    temp &= EndRecord
        '    fw.WriteLine(temp)
        'Next
        '''''''''''''''''''''''''''''''''''''''''
        'record 16
        QueryCustomerInfo()
        temp = "16:"
        ' field 2
        If oTableCustomerInfo.Rows.Count > 0 Then
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("Shipper_Code").ToString.Trim <> "", oTableCustomerInfo.Rows(0).Item("Shipper_Code").ToString.Trim, "")  'khong ro Du lieu VIP Shipper 
        End If
        temp &= ":"
        ' field 3-field 8 Shipper Description

        For i As Integer = 1 To 5
            Dim tempshipper, shipperContent As String
            tempshipper = "Shipper_" & i
            shipperContent = ReplaceSym(oTableCustomerInfo.Rows(0).Item(tempshipper).ToString.Trim)
            temp &= IIf(shipperContent <> "", shipperContent, "") & ":"
        Next
        temp = temp.Remove(temp.Length - 1)
        temp &= EndRecord
        fw.WriteLine(temp)



        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 17
        temp = "17:"
        ' field 2
        If oTableCustomerInfo.Rows.Count > 0 Then
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("Consignee_Code").ToString.Trim <> "", oTableCustomerInfo.Rows(0).Item("Consignee_Code").ToString.Trim, "")
        End If
        temp &= ":"
        ' field 3-field 8 consignee description
        For i As Integer = 1 To 5
            Dim tempConsginee, ConsgineeContent As String
            tempConsginee = "Consignee_" & i
            ConsgineeContent = ReplaceSym(oTableCustomerInfo.Rows(0).Item(tempConsginee).ToString.Trim) ', ":", "?:")
            temp &= IIf(ConsgineeContent <> "", ConsgineeContent, "") & ":"
        Next
        temp = temp.Remove(temp.Length - 1)
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 18
        temp = "18:"
        ' field 2
        If oTableCustomerInfo.Rows.Count > 0 Then
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("Notify_Code").ToString.Trim <> "", oTableCustomerInfo.Rows(0).Item("Notify_Code").ToString.Trim, "")
        End If
        temp &= ":"
        ' field 3-field 8 Notify description
        For i As Integer = 1 To 5
            Dim tempNotify, NotifyContent As String
            tempNotify = "Notify_" & i
            NotifyContent = ReplaceSym(oTableCustomerInfo.Rows(0).Item(tempNotify).ToString.Trim) ', ":", "?:")
            temp &= IIf(NotifyContent <> "", NotifyContent, "") & ":"
        Next
        temp = temp.Remove(temp.Length - 1)
        temp &= EndRecord
        fw.WriteLine(temp)

        'record 19 new co (dtnotify.row.count>0)
        Dim dtNotify, dtNotify3 As New DataTable
        QueryNotify(dtNotify, "Notify2_ID")

        If dtNotify.Rows.Count > 0 And dtNotify.Rows(0).Item("Notify_ID").ToString.Trim.Length > 0 Then
            If "{" & dtNotify.Rows(0).Item("Notify_ID").ToString.Trim & "}" <> DefaultValue Then
                temp = "19:"
                If dtNotify.Rows.Count > 0 Then
                    temp &= IIf(dtNotify.Rows(0).Item("Notify_Code").ToString.Trim <> "", dtNotify.Rows(0).Item("Notify_Code").ToString.Trim, "")
                End If
                temp &= ":"
                For K As Integer = 1 To 5
                    Dim Content As String = dtNotify.Rows(0).Item("Notify_" & K).ToString.Trim
                    temp &= ReplaceSym(IIf(Content <> "", Content, "")) & ":"
                Next
                temp = temp.Remove(temp.Length - 1) & "'"
                fw.WriteLine(temp)
            End If

        End If

        QueryNotify(dtNotify3, "Notify3_ID")



        'record 20 new co (dtnotify3.row.count>0)
        If dtNotify3.Rows.Count > 0 And dtNotify3.Rows(0).Item("Notify_ID").ToString.Trim.Length > 0 Then
            If "{" & dtNotify3.Rows(0).Item("Notify_ID").ToString.Trim & "}" <> DefaultValue Then
                temp = "20:"
                If dtNotify3.Rows.Count > 0 Then
                    temp &= IIf(dtNotify3.Rows(0).Item("Notify_Code").ToString.Trim <> "", dtNotify3.Rows(0).Item("Notify_Code").ToString.Trim, "")
                End If
                temp &= ":"
                For K As Integer = 1 To 5
                    Dim Content As String = dtNotify3.Rows(0).Item("Notify_" & K).ToString.Trim
                    temp &= ReplaceSym(IIf(Content <> "", Content, "")) & ":"
                Next
                temp = temp.Remove(temp.Length - 1) & "'"
                fw.WriteLine(temp)
            End If

        End If

        'record 21 BL_Clause
        Dim oTableBL_Clause As New DataTable
        'oTableBL_Clause = QueryBL_Clause(Me.dgdBillOfLading_House.Item("BL_ClauseID", index).Value.ToString)

        'If Not IsNothing(oTableBL_Clause) Then
        '    If oTableBL_Clause.Rows.Count > 0 Then
        '        temp = "21:"
        '        temp &= oTableBL_Clause.Rows(0).Item("BL_ClauseCode").ToString & ":"
        '        temp &= ReplaceSym(oTableBL_Clause.Rows(0).Item("BL_ClauseText").ToString)
        '        temp &= EndRecord
        '        fw.WriteLine(temp)
        '    End If
        'End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 23
        'temp = "23:"
        ''field 2
        'temp &= "CA:"
        ''field 3 
        'temp &= IIf(Me.dgdBillOfLading_House.Item("CANVASSERCODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading_House.Item("CANVASSERCODE", index).Value.ToString.Trim, "") & ":"
        ''field 4
        'temp &= "" '
        'temp &= EndRecord
        'fw.WriteLine(temp)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim TbCargo As New DataTable
        QueryCargoInfo(TbCargo)
        Dim TotalAmount, TotalCBM, TotalGross As Double

        If TbCargo.Rows.Count = 0 Then
            DisplayMessage(True, "There No container in this Bill")
            fw.Close()
            Return
        End If
        'record 41
        For Each row In TbCargo.Rows
            Select Case row.Item("Container_Type").ToString.Trim
                Case "20GP"
                    Container_Type = "22G1"
                Case "40GP"
                    Container_Type = "42G1"
                Case "20RF"
                    Container_Type = "22R1"
                Case "40RF"
                    Container_Type = "42R1"
                Case "40HC"
                    Container_Type = "45G1"
                Case "40RH"
                    Container_Type = "45R1"
                Case "45HC"
                    Container_Type = "L2G0"
                Case "20OT"
                    Container_Type = "22U1"
                Case "40OT"
                    Container_Type = "42U1"
                Case "20FR"
                    Container_Type = "22P3"
                Case "40FR"
                    Container_Type = "42P3"
                Case Else
                    Container_Type = ""

            End Select

            TotalAmount += IIf(row.Item("Amount").ToString <> "", row.Item("Amount"), 0)
            TotalCBM += IIf(row.Item("CBM").ToString.Trim <> "", row.Item("CBM"), 0)
            TotalGross += IIf(row.Item("Gross").ToString.Trim <> "", row.Item("Gross"), 0)

        Next
        temp = "41:"
        'field 2
        row = TbCargo.Rows(0)
        temp &= IIf(row.Item("CARGO_SEQUENCE").ToString.Trim <> "", row.Item("CARGO_SEQUENCE").ToString.Trim, "") & ":"
        'filed 3
        temp &= IIf(row.Item("COMMODITY_GROUP").ToString.Trim <> "", row.Item("COMMODITY_GROUP").ToString.Trim, "") & ":"
        'field 4
        temp &= IIf(row.Item("Commodity").ToString.Trim <> "", row.Item("Commodity").ToString.Trim, "") & ":"
        'field 5
        'temp &= IIf(row.Item("Amount").ToString <> "", row.Item("Amount").ToString.Trim, "") & ":"
        temp &= FormatNumber(TotalAmount, 0, , , TriState.False).ToString & ":"
        'filed 6
        temp &= Strings.Replace(IIf(row.Item("KIND_CODE").ToString.Trim <> "", row.Item("KIND_CODE").ToString.Trim, ""), ":", "?:") & ":"
        'field 7
        temp &= IIf(row.Item("KIND").ToString.Trim <> "", row.Item("KIND").ToString.Trim, "") & ":"
        'field 8
        'temp &= IIf(row.Item("GROSS").ToString.Trim <> "", row.Item("GROSS").ToString.Trim, "") & ":"
        temp &= FormatNumber(TotalGross, 2, , , TriState.False).ToString & ":"
        'field 9
        temp &= "0.00:" 'chu ro du lieu
        'field 10
        'temp &= FormatString(CDbl(IIf(row.Item("CBM").ToString.Trim <> "", row.Item("CBM").ToString.Trim, ""))) & ":"
        temp &= FormatNumber(TotalCBM, 3, , , TriState.False).ToString & ":"
        'field 11
        temp &= Container_Type & ":" 'vi tong ne khong biet dua loai container nao vao
        'field 12
        temp &= Strings.Replace(IIf(row.Item("TARIFF").ToString.Trim <> "", row.Item("TARIFF").ToString.Trim, ""), ":", "?:") & ":"
        'field 13
        temp &= Strings.Replace(IIf(row.Item("HS_CODE").ToString.Trim <> "", row.Item("HS_CODE").ToString.Trim, ""), ":", "?:")
        temp &= EndRecord
        fw.WriteLine(temp)

        ''''''''''''''''''''''''''''''''''''
        'recrord 44
        QueryCargoMarks(dt)

        temp = "44:"
        'field 2
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Marks").ToString.Trim <> "", dt.Rows(0).Item("Marks").ToString.Trim, "")) ', ":", "?:")
            'temp = Strings.Replace(temp, Chr(13), "^n")
        End If
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''
        'record 47
        QueryCargoDescription(dt)

        temp = "47:"
        'field 2
        'If dt.Rows.Count > 0 Then
        '    temp &= ReplaceSym(IIf(dt.Rows(0).Item("Description").ToString.Trim <> "", dt.Rows(0).Item("Description").ToString.Trim, "")) ', ":", "?:")
        '    'temp = Strings.Replace(temp, Chr(13), "^n")
        'End If
        Dim tempremarks As String = ""
        If dtNotify.Rows.Count > 0 Then
            tempremarks = ReplaceSym(IIf(dtNotify.Rows(0).Item("RemarksNotify").ToString.Trim <> "", dtNotify.Rows(0).Item("RemarksNotify").ToString.Trim, ""))
        End If
        If dtNotify3.Rows.Count > 0 Then
            tempremarks += ReplaceSym(IIf(dtNotify3.Rows(0).Item("RemarksNotify").ToString.Trim <> "", dtNotify3.Rows(0).Item("RemarksNotify").ToString.Trim, ""))
        End If
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Description").ToString.Trim <> "", dt.Rows(0).Item("Description").ToString.Trim, "")) + ReplaceSym(oTableCustomerInfo.Rows(0).Item("RemarksShipper").ToString.Trim) + ReplaceSym(oTableCustomerInfo.Rows(0).Item("RemarksConsignee").ToString.Trim) + ReplaceSym(oTableCustomerInfo.Rows(0).Item("RemarksNotify").ToString.Trim) + tempremarks ', ":", "?:")
            'temp = Strings.Replace(temp, Chr(13), "^n")
        End If
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''
        'record 48
        QueryCargoReMarks(dt)
        temp = "48:"
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Cargo_ReMarks").ToString.Trim <> "", dt.Rows(0).Item("Cargo_ReMarks").ToString.Trim, "")) ', ":", "?:")
        End If
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''
        'record 51
        Dim tempi As Integer = 0
        For Each row In TbCargo.Rows
            Select Case row.Item("Container_Type").ToString.Trim
                Case "20GP"
                    Container_Type = "22G1"
                Case "40GP"
                    Container_Type = "42G1"
                Case "20RF"
                    Container_Type = "22R1"
                Case "40RF"
                    Container_Type = "42R1"
                Case "40HC"
                    Container_Type = "45G1"
                Case "40RH"
                    Container_Type = "45R1"
                Case "45HC"
                    Container_Type = "L2G0"
                Case "20OT"
                    Container_Type = "22U1"
                Case "40OT"
                    Container_Type = "42U1"
                Case "20FR"
                    Container_Type = "22P3"
                Case "40FR"
                    Container_Type = "42P3"
                Case Else
                    Container_Type = ""

            End Select
            'field 1
            temp = "51:"
            tempi += 1
            'field 2
            temp &= IIf(row.Item("CARGO_SEQUENCE").ToString.Trim <> "", row.Item("CARGO_SEQUENCE").ToString.Trim, "") & ":"
            'field 3
            temp &= IIf(row.Item("CONTAINER_NO").ToString.Trim <> "", row.Item("CONTAINER_NO").ToString.Trim, "") & ":"
            'field 4
            temp &= IIf(row.Item("SEALNO").ToString.Trim <> "", row.Item("SEALNO").ToString.Trim, "") & ":"
            'field 5
            temp &= Container_Type & ":"
            'field 6
            temp &= IIf(row.Item("CTN_STATUS").ToString.Trim <> "", row.Item("CTN_STATUS").ToString.Trim, "") & ":" 'tinh trang conatiner chua ro du lieu
            'field 7
            temp &= IIf(row.Item("AMount").ToString.Trim <> "", row.Item("Amount").ToString.Trim, "") & ":"
            'field 8
            temp &= IIf(row.Item("GROSS").ToString.Trim <> "", row.Item("GROSS").ToString.Trim, "") & ":"
            'field 9
            temp &= IIf(row.Item("NETWEIGHT").ToString.Trim <> "", row.Item("NETWEIGHT").ToString.Trim, "") & ":"
            'field 10
            temp &= FormatString(CDbl(IIf(row.Item("CBM").ToString.Trim <> "", row.Item("CBM").ToString.Trim, ""))) & ":"
            'field 11
            temp &= IIf(row.Item("TEMPERATURE_ID").ToString.Trim <> "", row.Item("TEMPERATURE_ID").ToString.Trim, "") & ":"
            'field 12
            temp &= IIf(row.Item("TEMPERATURE_SETTING").ToString.Trim <> "", row.Item("TEMPERATURE_SETTING").ToString.Trim, "") & ":"
            'field 13
            temp &= IIf(row.Item("MIN_TEMPERATURE").ToString.Trim <> "", row.Item("MIN_TEMPERATURE").ToString.Trim, "") & ":"
            'field 14
            'nhiet do lay tu cargo 
            temp &= IIf(row.Item("MAX_TEMPERATURE").ToString.Trim <> "", row.Item("MAX_TEMPERATURE").ToString.Trim, "") & ":"
            'field 15
            temp &= Strings.Replace(IIf(row.Item("VENT").ToString.Trim <> "", row.Item("VENT").ToString.Trim, ""), ":", "?:") & ":"
            'field 16
            temp &= IIf(row.Item("SHIPPER_OWNED_UNIT").ToString.Trim <> "", row.Item("SHIPPER_OWNED_UNIT").ToString.Trim, "") & ":"
            'field 17

            If row.Item("CARGO_RECEVING_DATE").ToString <> "" Then
                datetime = row.Item("CARGO_RECEVING_DATE").ToString
                temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month)
                temp &= IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day) & ":"
                '----
            Else
                temp &= ":"
            End If
            temp &= row.Item("seal_no2").ToString.Trim & ":"
            temp &= row.Item("seal_no3").ToString.Trim & ":"
            temp &= row.Item("seal_no4").ToString.Trim & ":"
            temp &= row.Item("seal_no5").ToString.Trim & ":"
            temp &= row.Item("seal_no6").ToString.Trim & ":"
            temp &= row.Item("seal_no7").ToString.Trim & ":"

            temp &= row.Item("seal_no8").ToString.Trim & ":"
            temp &= row.Item("seal_no9").ToString.Trim & "'"


            'filed 18-25

            fw.WriteLine(temp)
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''
        'record 61
        'QueryHouseBill(dt)

        'For Each row In dt.Rows
        '    temp = "61:"
        '    'field 2
        '    temp &= row.Item("BLH_NO").ToString
        '    'field 3- 4
        '    temp &= " : :"

        '    temp &= EndRecord
        '    fw.WriteLine(temp)

        'Next
        '''''''''''''''''''''''''''''''''''''''''''''''
        'record 99
        temp = "99:5'"

        fw.WriteLine(temp)

        fw.Close()
        DisplayMessage(True, "Manifest Export Success With Path:" & path)
        Exit Sub
Err_Named:
        fw.Close()
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryVesselInfo(ByRef dt As DataTable) 'Lay du Lieu Vessel Ra de in File

        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        strQuery = "Select Vessel_Code,Vessel,NATIONALITY,Sailingschedule.VoyNo As VoyNo From (((BILLOFLADING_HOUSE LEFT JOIN ContainerOutboundNotify On BILLOFLADING_HOUSE.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID) "
        strQuery &= " LEFT JOIN Sailingschedule On Sailingschedule.SailingscheduleID=ContainerOutboundNotify.SailingscheduleID) LEFT JOIN "
        strQuery &= " Vessel On Sailingschedule.Vessel_ID=Vessel.Vessel_ID) Where BILLOFLADING_HOUSE.BLH_ID='" & gBillOfLadingHouseRpt & "' And BILLOFLADING_HOUSE.Continued=1"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "info")
        dt = ds.Tables(0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Sub QueryRoutingInfo(ByRef dt As DataTable) 'Lay du Lieu Vessel Ra de in File

        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        strQuery = "Select * from Routing_House where BLH_ID='" & gBillOfLadingHouseRpt & "' And Continued=1 Order BY SEQ ASC"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "info")
        dt = ds.Tables(0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM (((BILLOFLADING_HOUSE LEFT JOIN Shipper On BILLOFLADING_HOUSE.Shipper_ID=Shipper.Shipper_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Consignee On Consignee.Consignee_ID=BILLOFLADING_HOUSE.Consignee_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Notify On Notify.Notify_ID=BILLOFLADING_HOUSE.Notify_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BILLOFLADING_HOUSE.BLH_ID= '" & gBillOfLadingHouseRpt & "' And BILLOFLADING_HOUSE.Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function


    Private Sub QueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCustomerInfo()
        Else
            strQuery = MakeQueryCustomerInfo(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCustomerInfo) Then
            oTableCustomerInfo.Clear()
        End If
        Adapter.Fill(dsCustomerInfo, "BillOfLadingList")
        oTableCustomerInfo = dsCustomerInfo.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Sub QueryCargoInfo(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select COMMODITY,COMMODITY_GROUP,HS_CODE,AMOUNT,TARIFF,KIND,KIND_CODE,CTN_CARGO_MEASUREMENT as CBM,CONTAINER_TYPE,ReeferDegree,"
        strQuery &= " CARGO_SEQUENCE,CONTAINER_NO,SealNo,seal_no2,seal_no3,seal_no4,seal_no5,seal_no6,seal_no7,seal_no8,seal_no9,NUMBER_OF_PACKAGES,GROSS,CTN_STATUS,"
        strQuery &= " Container.NetWeight,TEMPERATURE_SETTING,TEMPERATURE_ID,SHIPPER_OWNED_UNIT,"
        strQuery &= " CARGO_RECEVING_DATE,Cargo_House.VENT,MIN_TEMPERATURE,MAX_TEMPERATURE  "
        ' TemperatureID lay tu Cargo chu khong lay tu Cont
        ' MIN,MAX cung lay tu Cargo
        strQuery &= " from ((CARGO_HOUSE LEFT JOIN Container On CARGO_HOUSE.CTN_ID=Container.CTN_ID)"
        strQuery &= " LEFT JOIN Seal On CARGO_HOUSE.SEAL_ID=SEAL.SEAL_ID) "
        strQuery &= " Where BLH_ID='" & gBillOfLadingHouseRpt & "' And CARGO_HOUSE.Continued=1 Order by CONTAINER_NO ASC"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(dt) Then
            dt.Clear()
        End If
        Adapter.Fill(ds, "BillOfLadingList")
        dt = ds.Tables(0)
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCargoMarks(ByRef oTableCargoMarks As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select MARKS from CargoHouse_Marks Where BLH_ID='" & gBillOfLadingHouseRpt & "'"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoMarks) Then
            oTableCargoMarks.Clear()
        End If
        Adapter.Fill(ds, "CargoMarks")
        oTableCargoMarks = ds.Tables(0)
        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCargoReMarks(ByRef oTableCargoMarks As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select CARGO_REMARKS from CargoHouse_Remarks Where BLH_ID='" & gBillOfLadingHouseRpt & "'"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoMarks) Then
            oTableCargoMarks.Clear()
        End If
        Adapter.Fill(ds, "CargoReMarks")
        oTableCargoMarks = ds.Tables(0)
        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCargoDescription(ByRef oTableCargoDescription As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Description from CargoHouse_Description Where BLH_ID='" & gBillOfLadingHouseRpt & "' "
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoDescription) Then
            oTableCargoDescription.Clear()
        End If
        Adapter.Fill(ds, "CargoDesc")
        oTableCargoDescription = ds.Tables(0)
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSearch.Click
        Try
            If Me.dgdBillOfLading_House.RowCount = 0 Then
                Return
            End If
            Me.grpFind.Visible = True
            Me.grpFind.BringToFront()
            Me.cboFind.Text = FindIDValue(Me.cboFind, Me.dgdBillOfLading_House.Columns(Me.dgdBillOfLading_House.CurrentCell.ColumnIndex).Name)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Try
            If Me.txtFind.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
                FindCombo(Me.txtFind.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdBillOfLading_House)
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
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnuRefesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefesh.Click
        getShipper()
        getConsignee()
        getNotify()
        If Me.dgdBillOfLading_House.Rows.Count = 0 Then
            Return
        End If
        QueryBookingNo()
        QueryBLOfLading()
        If mFilter = "" Then
            QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "'", 15)
        Else
            QueryBILLOFLADING_HOUSE(mFilter)
        End If

    End Sub

    Function QueryMasterInfo(ByVal ID As String) As DataTable
        Try
            Dim SQL As String
            Dim dt As New DataTable
            If ID <> "" Then
                Sql = " Select * from BillOfLading_house Where BLh_ID='" & ID & "' And Continued=1"

                dt = ReadTable(Sql)
            Else

                dt = Nothing

            End If


            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function GetHouseBillData(ByVal dt As DataTable)
        Try
            Dim SQL As String
            Dim rs As New ADODB.Recordset
            SQL = "Select Top 1 * from BillOfLading_House Where Continued=1 "
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                .AddNew()

                If Me.cboFromBill.Text = "" Then

                    .Fields("BL_ID").Value = "{" + FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) + "}"
                Else
                    .Fields("BL_ID").Value = "{" & dt.Rows(0).Item("bl_id").ToString & "}"

                End If

                '.Fields("BL_ID").Value = DefaultValue
                .Fields("BLH_ID").Value = NewId()
                .Fields("BLH_NO").Value = Me.txtBillHouse.Text
                If Me.cboFromBill.Text <> "" Then

               
                    If dt.Rows(0).Item("ContainerOutBoundNotifyId").ToString.Trim <> "" Then
                        .Fields("ContainerOutBoundNotifyId").Value = "{" & dt.Rows(0).Item("ContainerOutBoundNotifyId").ToString & "}"
                    End If

                    'If dt.Rows(0).Item("SHIPPER_ID").ToString.Trim <> "" Then
                    .Fields("SHIPPER").Value = dt.Rows(0).Item("SHIPPER").ToString
                    'End If
                    'f dt.Rows(0).Item("CONSIGNEE_ID").ToString.Trim <> "" Then
                    .Fields("CONSIGNEE").Value = dt.Rows(0).Item("CONSIGNEE").ToString
                    'nd If
                    'f dt.Rows(0).Item("NOTIFY_ID").ToString.Trim <> "" Then
                    .Fields("NOTIFY").Value = dt.Rows(0).Item("NOTIFY").ToString
                    'nd If
                    'If dt.Rows(0).Item("NOTIFY2_ID").ToString.Trim <> "" Then
                    '    .Fields("NOTIFY2_ID").Value = "{" & dt.Rows(0).Item("NOTIFY2_ID").ToString & "}"
                    'End If

                    'If dt.Rows(0).Item("NOTIFY3_ID").ToString.Trim <> "" Then
                    '    .Fields("NOTIFY3_ID").Value = "{" & dt.Rows(0).Item("NOTIFY3_ID").ToString & "}"
                    'End If

                    '.Fields("PRE_VESSEL_ID").Value = "{" & PREVESSELID & "}"
                    If dt.Rows(0).Item("PLACE_OF_RECEIPT_ID").ToString.Trim <> "" Then
                        .Fields("PLACE_OF_RECEIPT_ID").Value = "{" & dt.Rows(0).Item("PLACE_OF_RECEIPT_ID").ToString & "}"
                    End If
                    If dt.Rows(0).Item("PORT_OF_LOADING_ID").ToString.Trim <> "" Then
                        .Fields("PORT_OF_LOADING_ID").Value = "{" & dt.Rows(0).Item("PORT_OF_LOADING_ID").ToString & "}"
                    End If
                    If dt.Rows(0).Item("PORT_OF_DISCHARGE_ID").ToString.Trim <> "" Then
                        .Fields("PORT_OF_DISCHARGE_ID").Value = "{" & dt.Rows(0).Item("PORT_OF_DISCHARGE_ID").ToString & "}"
                    End If
                    If dt.Rows(0).Item("PLACE_OF_DELIVERY_ID").ToString.Trim <> "" Then
                        .Fields("PLACE_OF_DELIVERY_ID").Value = "{" & dt.Rows(0).Item("PLACE_OF_DELIVERY_ID").ToString & "}"
                    End If
                    If dt.Rows(0).Item("PLACE_OF_DESTINATION_ID").ToString.Trim <> "" Then
                        .Fields("PLACE_OF_DESTINATION_ID").Value = "{" & dt.Rows(0).Item("PLACE_OF_DESTINATION_ID").ToString & "}"
                    End If
                    If dt.Rows(0).Item("PLACE_OF_BL_ISSUE_ID").ToString.Trim <> "" Then
                        .Fields("PLACE_OF_BL_ISSUE_ID").Value = "{" & dt.Rows(0).Item("PLACE_OF_BL_ISSUE_ID").ToString & "}"
                    End If

                    If dt.Rows(0).Item("BL_ClauseID").ToString.Trim <> "" Then
                        .Fields("BL_ClauseID").Value = "{" & dt.Rows(0).Item("BL_ClauseID").ToString & "}"
                    End If

                    '.Fields("VESSEL_ID").Value = "{" & VESSELID & "}"
                    '.Fields("TRADE_CODE_ID").Value = "{" & FindValueID(Me.txtTradeCode, Me.txtTradeCode.Text) & "}"


                    .Fields("TRADE_CODE").Value = dt.Rows(0).Item("TRADE_CODE")
                    .Fields("TOTALPREPAID_IN").Value = dt.Rows(0).Item("TOTALPREPAID_IN")

                    .Fields("BL_CY_CFS_ITEM").Value = dt.Rows(0).Item("BL_CY_CFS_ITEM")
                    .Fields("ToTalContainer").Value = dt.Rows(0).Item("ToTalContainer")

                    .Fields("PreightCharges").Value = dt.Rows(0).Item("PreightCharges")

                    .Fields("PREPAID_OR_COLLECT").Value = dt.Rows(0).Item("PREPAID_OR_COLLECT")
                    .Fields("LOAD_DATE").Value = dt.Rows(0).Item("LOAD_DATE")

                    .Fields("DESCRIPTIONFORSHIPPER").Value = dt.Rows(0).Item("DESCRIPTIONFORSHIPPER")
                    .Fields("REVENUETON").Value = dt.Rows(0).Item("REVENUETON")

                    .Fields("QUARANTINE_CODING").Value = dt.Rows(0).Item("QUARANTINE_CODING")
                    .Fields("DATE_OF_ISSUE").Value = dt.Rows(0).Item("DATE_OF_ISSUE")

                    .Fields("CURRENCY").Value = dt.Rows(0).Item("CURRENCY")
                    .Fields("EXCHANGE_RATE").Value = dt.Rows(0).Item("EXCHANGE_RATE")
                    .Fields("MF_FILING_TYPE").Value = dt.Rows(0).Item("MF_FILING_TYPE")
                    .Fields("NVOCC_MASTER_BL_NO").Value = dt.Rows(0).Item("NVOCC_MASTER_BL_NO")

                    .Fields("SCAC_CODE").Value = dt.Rows(0).Item("SCAC_CODE")
                    .Fields("CANVASSERCODE").Value = dt.Rows(0).Item("CANVASSERCODE")

                    .Fields("BL_OTHER_REF").Value = dt.Rows(0).Item("BL_OTHER_REF")
                    .Fields("BL_TYPE").Value = dt.Rows(0).Item("BL_TYPE")
                    .Fields("PAYABLE_AT").Value = dt.Rows(0).Item("PAYABLE_AT")
                    .Fields("PAYER_CODE").Value = dt.Rows(0).Item("PAYER_CODE")
                    .Fields("NO_OF_COPY_BL").Value = dt.Rows(0).Item("NO_OF_COPY_BL")
                    .Fields("NO_OF_ORIGINAL_BL").Value = dt.Rows(0).Item("NO_OF_ORIGINAL_BL")
                    .Fields("CUSTOMS_CLEARED_PLACE").Value = dt.Rows(0).Item("CUSTOMS_CLEARED_PLACE")

                    .Fields("SLOT_SHARE").Value = dt.Rows(0).Item("SLOT_SHARE")
                    .Fields("US_SERVICE_MODE").Value = dt.Rows(0).Item("US_SERVICE_MODE")

                    .Fields("PORT_OF_LOADING_NAME").Value = dt.Rows(0).Item("PORT_OF_LOADING_NAME")
                    .Fields("PORT_OF_DISCHARGE_NAME").Value = dt.Rows(0).Item("PORT_OF_DISCHARGE_NAME")
                    .Fields("PLACE_OF_DELIVERY_NAME").Value = dt.Rows(0).Item("PLACE_OF_DELIVERY_NAME")
                    .Fields("PLACE_OF_DESTINATION_NAME").Value = dt.Rows(0).Item("PLACE_OF_DESTINATION_NAME")
                    .Fields("PLACE_OF_BL_ISSUE_NAME").Value = dt.Rows(0).Item("PLACE_OF_BL_ISSUE_NAME")
                    .Fields("PLACE_OF_RECEIPT_NAME").Value = dt.Rows(0).Item("PLACE_OF_RECEIPT_NAME")
                    '.Fields("LOAD_PORT_NAME").Value = UCase(Trim(Me.txtLoad_port.Text))

                    '.Fields("LOAD_PORT_CODE").Value = UCase(Trim(Me.cboLoad_port.Text))
                    .Fields("PORT_OF_LOADING_CODE").Value = dt.Rows(0).Item("PORT_OF_LOADING_CODE")
                    .Fields("PLACE_OF_BL_ISSUE_CODE").Value = dt.Rows(0).Item("PLACE_OF_BL_ISSUE_CODE")
                    .Fields("PLACE_OF_DESTINATION_CODE").Value = dt.Rows(0).Item("PLACE_OF_DESTINATION_CODE")
                    .Fields("PLACE_OF_DELIVERY_CODE").Value = dt.Rows(0).Item("PLACE_OF_DELIVERY_CODE")

                    .Fields("PLACE_OF_RECEIPT_CODE").Value = dt.Rows(0).Item("PLACE_OF_RECEIPT_CODE")
                    .Fields("PORT_OF_DISCHARGE_CODE").Value = dt.Rows(0).Item("PORT_OF_DISCHARGE_CODE")

                    '.Fields("SERVICECONTRACT").Value = UCase(Trim(Me.txtServiceContract.Text))
                    .Fields("PREPAIDAT").Value = dt.Rows(0).Item("PREPAIDAT")
                    .Fields("TRANSFER_PORT1").Value = dt.Rows(0).Item("TRANSFER_PORT1")
                    .Fields("TRANSFER_PORT2").Value = dt.Rows(0).Item("TRANSFER_PORT2")
                    .Fields("TRANSFER_PORT3").Value = dt.Rows(0).Item("TRANSFER_PORT3")
                    .Fields("TRANSFER_PORT4").Value = dt.Rows(0).Item("TRANSFER_PORT4")
                    .Fields("Note").Value = dt.Rows(0).Item("Note")

                    .Fields("notShowDes").Value = dt.Rows(0).Item("notShowDes")


                End If
                .Update()
            End With

            rs.Close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Sub cmdOKBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKBill.Click
        Try
            Dim tbl As New DataTable
            Dim strSql As String = "Select count(*) cnt From BILLOFLADING_HOUSE where BLH_NO='" & Me.txtBillHouse.Text.Trim & "' and continued=1 "
            tbl = ReadTable(strSql)
            If tbl.Rows(0).Item("cnt") > 0 Then
                MsgBox("Trùng số Bill." + Me.txtBillHouse.Text + ", Xin vui lòng kiểm tra lại.")
                Return
            End If
            Me.txtBillOfLading_house.Text = Me.txtBillHouse.Text.Trim
            tbl.Dispose()
            Me.grpBillHouse.Visible = False
            mBILLOFLADING_HOUSEId = DefaultValue

            Dim dt As New DataTable
            Dim BLh_ID As String = FindValueID(Me.cboFromBill, Me.cboFromBill.Text)
            dt = QueryMasterInfo(BLh_ID)
            GetHouseBillData(dt)

            QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BLh_no='" & Me.txtBillHouse.Text & "' " & mFilter)
            'mStatus = "Add"
            'Me.fraUpdate.Visible = True
            'Me.dgdBillOfLading_House.Height = 306
            'Me.dgdBillOfLading_House.Enabled = False
            'ReFormat()
            'SetMenu((False))
            'Me.cboBillOfLading_House.Enabled = False
            'Me.tagInformationCustomer.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cmdCancelBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelBill.Click
        Try
            Me.grpBillHouse.Visible = False
            Me.cboBillOfLading_House.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub ctmnuSearchNotify2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuSearchNotify2.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtNotify2.Name
            Dim frm As New frmListNotify
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ctmnuSearcheNotify3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuSearcheNotify3.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtNotify3.Name
            Dim frm As New frmListNotify
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ctmCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdBillOfLading_House.RowCount = 0 Then
                Return
            End If
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            Dim BillNo As String = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString.Trim
            VB6.ShowForm(frmListCargoHouse, VB6.FormShowConstants.Modeless, Me)
            frmListCargoHouse.cboBillofLading_House.Text = BillNo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuPrint.Click

    End Sub

    Private Sub mnuManifestHouseFileForVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmManifestVessel_House, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub CheckPort(ByRef Port_Code As TextBox, ByRef PortName As TextBox, ByRef strPortID As String)
        Try
            If Port_Code.Text = "" Then
                MsgBox("Port Code Not allow Null value,Check data Again ")
                Return
            End If
            Dim Temp As String = CheckTSCode(Port_Code, strPortID)
            If Temp = "" Then
                Port_Code.Focus()
                MsgBox("Port Code Invalid, Please Check Again")
                Return
            End If
            PortName.Text = Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub CheckPortcbo(ByRef Port_Code As ComboBox, ByRef PortName As TextBox, ByRef strPortID As String)
        Try
            If Port_Code.Text = "" Then
                MsgBox("Port Code Not allow Null value,Check data Again ")
                Return
            End If
            Dim Temp As String = CheckTSCodecbo(Port_Code, strPortID)
            If Temp = "" Then
                Port_Code.Focus()
                MsgBox("Port Code Invalid, Please Check Again")
                Return
            End If
            PortName.Text = Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtPlofReceiptCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs)


    End Sub


    Private Sub txtPortOfLoadingCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPortOfLoadingCode.Leave

        CheckPort(Me.txtPortOfLoadingCode, Me.txtPortOfLoadingName, POL_ID)

    End Sub
    Private Sub txtPortOfDisChargeCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPortOfDisChargeCode.Leave
        CheckPort(Me.txtPortOfDisChargeCode, Me.txtPortOfDischargeName, POD_ID)
    End Sub

    Private Sub txtPortOfDeliveryCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortOfDeliveryCode.Leave

        CheckPort(Me.txtPortOfDeliveryCode, txtPlaceOfDeliveryName, DEL_ID)

    End Sub

    Private Sub txtPortOfDestinationCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortOfDestinationCode.Leave

        CheckPort(Me.txtPortOfDestinationCode, txtPlaceofdestinationName, DEST_ID)

    End Sub

    Private Sub txtPlaceCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlaceCode.Leave

        CheckPort(Me.txtPlaceCode, txtPlaceOfBL_IssueName, POI_ID)
    End Sub


    Private Sub txtPortFromCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortFromCode.Leave

        CheckPort(Me.txtPortFromCode, txtportfromName, PortFrom_ID)

    End Sub

    Private Sub txtPortToCode_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortToCode.Leave


        CheckPort(Me.txtPortToCode, txtporttoName, PortTo_ID)

    End Sub

    Private Sub txtPlofReceiptCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.txtPlofReceiptCode.Text.Length = 5 Then
            txtPlofReceiptCode_Leave(sender, e)
        End If

    End Sub

    Private Sub txtPortOfLoadingCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortOfLoadingCode.TextChanged
        If Me.txtPortOfLoadingCode.Text.Length = 5 Then
            txtPortOfLoadingCode_Leave(sender, e)
        End If
    End Sub

    Private Sub txtPortOfDisChargeCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortOfDisChargeCode.TextChanged
        If Me.txtPortOfDisChargeCode.Text.Length = 5 Then
            txtPortOfDisChargeCode_Leave(sender, e)
        End If
    End Sub

    Private Sub txtPortOfDeliveryCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortOfDeliveryCode.TextChanged
        If Me.txtPortOfDeliveryCode.Text.Length = 5 Then
            txtPortOfDeliveryCode_Leave(sender, e)
        End If
    End Sub

    Private Sub txtPortOfDestinationCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortOfDestinationCode.TextChanged
        If Me.txtPortOfDestinationCode.Text.Length = 5 Then
            txtPortOfDestinationCode_Leave(sender, e)
        End If
    End Sub

    Private Sub txtPlaceCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlaceCode.TextChanged
        If Me.txtPlaceCode.Text.Length = 5 Then
            txtPlaceCode_Leave(sender, e)
        End If
    End Sub

    Private Sub txtPortFromCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortFromCode.TextChanged
        If Me.txtPortFromCode.Text.Length = 5 Then
            txtPortFromCode_Leave(sender, e)
        End If
    End Sub

    Private Sub txtPortToCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortToCode.TextChanged
        If Me.txtPortToCode.Text.Length = 5 Then
            txtPortToCode_Leave(sender, e)
        End If
    End Sub


    Private Sub cmdChecking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Checking = 1
        OkClick()
    End Sub

    Sub CargoHouseQuerySealNo()
        On Error GoTo Err_Renamed

        Dim id As String = "SEAL_ID"
        Dim value As String = "SEALNO"
        Dim strSQL As String
        strSQL = "Select SEAL_ID,SEALNO From SEAL Where Continued=1 Order By SEALNO Desc"
        loadDataToObject(Me.cboSealNo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub CargoHouseQueryContainerNO()
        On Error GoTo Err_Renamed

        Dim id As String = "CTN_ID"
        Dim value As String = "CONTAINER_NO"
        Dim strSQL As String
        strSQL = "Select CTN_ID,CONTAINER_NO From Container Where Continued=1 Order By CTN_SIZE_TYPE Desc"
        loadDataToObject(Me.txtCTN_NO, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub Load_CargoHouse()
        Try
            mCargoHouseStatus = "Normal"
            mCargoMarks_ID = DefaultValue
            mCargoRemarks_ID = DefaultValue
            mCargoDesc_ID = DefaultValue

            mCargoHouseDesc_ID = DefaultValue
            SetDefaultGrid(Me.dgdDetailBillOfLading_House, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            mCargoHouseStatusP = "Normal"
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'CargoHouseQueryContainerNO()
            CargoHouseQuerySealNo()
            Me.QueryDetailBillOfLading_House(" And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'")
            CargoHouseReefer_Degree()
            LoadCargoHouse = True
            '------------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Me.Cursor = Cursors.Default
        End Try



    End Sub

#Region "CARGO "

    Private Function MakeQueryDetailBillOfLading_House(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        Dim strDetailBillOfLading_HouseSelect As String = "SELECT  Distinct BillOfLading_House.BLH_Id, BillOfLading_House.BLH_NO as BL_No, " & _
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
        Dim strDetailBillOfLading_HouseOrder1 As String = _
                 " ORDER BY BL_NO  Desc "
        Dim strDetailBillOfLading_HouseOrder2 As String = _
            " ORDER BY Cargo_House.UpdateTime Desc "

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
        MsgBox(msgErr(Me, Err.Description))
    End Function

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
            Me.dgdDetailBillOfLading_House.Columns.Item("CargoHouseBilL_No").ToolTipText = "Hiện có:" + CStr(Me.dgdDetailBillOfLading_House.RowCount()) + " Containers."
            'SetMenu(True)
        End If
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading_House)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Sub cboContainerType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        CargoHouseReefer_Degree()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboContainerType_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        CargoHouseReefer_Degree()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub CargoHouseReefer_Degree()
        On Error GoTo Err_Renamed
        'If Me.txtContainerType.Text.Trim = "20RF" Or Me.txtContainerType.Text.Trim = "40RF" Or Me.txtContainerType.Text.Trim = "40RH" Then
        '    Me.lblReeferDegree.Visible = True
        '    Me.txtReeferDegree.Visible = True
        '    Me.lblo.Visible = True
        'Else
        '    Me.lblReeferDegree.Visible = False
        '    Me.txtReeferDegree.Visible = False
        '    Me.lblo.Visible = False
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub CargoHouseQueryBooking(ByRef oTable As DataTable)
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Conn.Open()
        Dim strQuery As String
        strQuery = " Select Cold,Ventilation as Vent "
        strQuery &= " From (ContainerOutboundNotify LEFT JOIN BILLOFLADING_HOUSE On ContainerOutboundNotify.ContainerOutboundNotifyID=BILLOFLADING_HOUSE.ContainerOutboundNotifyID) "
        strQuery &= " Where BLH_ID='" & mBILLOFLADING_HOUSEId & "' And ContainerOutboundNotify.Continued=1"
        Dim Cmd As New SqlClient.SqlCommand(strQuery, Conn)
        Dim Adapter As New SqlClient.SqlDataAdapter(Cmd)
        If oTable.Rows.Count > 0 Then
            oTable.Rows.Clear()
        End If
        Adapter.Fill(oTable)
    End Sub
    Private Sub smnuCargoHouseSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCargoHouseSearch.Click
        Try
            Dim strQuery As String
            gNameForm = frmListCargoHouse.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mCargoHouseFilter = frmFilter.strQuery
                QueryDetailBillOfLading_House("  " & mCargoHouseFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Private Sub smnuCargoHouseInsert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCargoHouseInsert.Click
        On Error GoTo Err_Renamed
        Dim index As Integer = 0
        ' kiem tra co ont san chua, 
        If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
            'If Me.txtDescription.Text.Trim.Length = 0 Then
            Me.txtDescription.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseDescription", 0).Value.ToString
            Me.txtCargoMarks.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCargoMarks", 0).Value.ToString
            Me.txtCargoRemarks.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCARGO_REMARKS", 0).Value.ToString
            'End If

        End If
        '------------------------------------------------
        If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            ''Me.dgdPrice.Rows.Clear()
            'Me.txtContainerKindP.Text = "" 'Me.dgdDetailBillOfLading_House.Item("Kind", index).Value.ToString
            'Me.txtContainerNoP.Text = "" 'Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString
            'Me.txtBillOfLading_HouseP.Text = "" 'Me.dgdDetailBillOfLading_House.Item("Bill_No", index).Value.ToString
            'Me.fraPrice.Enabled = False
        End If

        If mCargoHouseStatus = "Normal" And UserRight("frmListBillOfLadingHouse", "Add") Then

            SetMenu(False)

            Dim dt As New DataTable
            CargoHouseQueryBooking(dt)
            If dt.Rows.Count > 0 Then
                Me.txtReeferDegree.Text = dt.Rows(0).Item("Cold").ToString
                Me.txtVent.Text = dt.Rows(0).Item("Vent").ToString
            End If
            Me.txtCTNStatus.Text = "F"
            Me.txtReeferDegree.Text = ""
            Me.txtShipperOwnedUnit.Text = "N"

            'Me.txtTariff.Text = Me.txtClauseOfService.Text
            mCargo_ID = DefaultValue
            mCargoMarks_ID = DefaultValue
            mCargoRemarks_ID = DefaultValue
            mCargoDesc_ID = DefaultValue


            mCargoHouseDesc_ID = DefaultValue

            mCargoHouseStatus = "Add"
            'Me.TabCargo.Visible = True
            'ReFormat()
            'Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.Rows.Count + 1
            Me.txtCargoSequence.Text = 1 'Me.dgdDetailBillOfLading_House.Rows.Count + 1
            'If Me.txtCargoSequence.Text = "0" Then
            Me.txtDescription.Enabled = True
            'End If

            Me.lblDescription.Enabled = True
            'Me.txtClauseOfService.Enabled = True
            Me.dgdDetailBillOfLading_House.Enabled = False
            reText(mStatus)
            Me.CargoHousecmdOK.Enabled = True


            'If gBillOfLading_HouseNumber = "No BillNumber." Then
            'Me.txtBillOfLadingId.Text = Me.cboBillOfLading_House.Text.Trim
            'End If
            Me.txtCTN_NO.Text = ""
            Me.cboSealNo.Text = ""
            Me.txtAmount.Text = "0"
            Me.txtGross.Text = "0"
            Me.txtMeas.Text = "0"
            Me.txtWeek.Text = ""
            Me.txtReeferDegree.Text = ""
            Me.txtCargoHouseNote.Text = ""
            Me.txtWeek.Text = CargoHouseWeekOfYear()

            'If Not gBillOfLading_HouseNumber = "No BillNumber." Then
            '    QueryBillOfLading_House(, , 0)
            'End If
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DateTimePicker_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker.Leave
        Me.txtWeek.Text = CargoHouseWeekOfYear()
    End Sub
    Private Sub DateTimePicker_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePicker.ValueChanged
        Me.txtWeek.Text = CargoHouseWeekOfYear()
    End Sub
    Public Function CargoHouseWeekOfYear() As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        If Me.DateTimePicker.Text <> "" Then
            CargoHouseWeekOfYear = myCal.GetWeekOfYear(CDate(Me.DateTimePicker.Text), myCWR, myFirstDOW)
        Else
            CargoHouseWeekOfYear = 0
        End If

        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function


    Private Sub smnuCargoHouseExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCargoHouseExportExcel.Click
        Try
            If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdDetailBillOfLading_House, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuCargoHouseEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuCargoHouseEdit.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        Dim Approve, EditTable, UsrRight As Boolean
        chk = Me.dgdDetailBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng container để thao tác.")
            Return
        End If
        If Me.dgdDetailBillOfLading_House.RowCount = 0 Then
            Return
        End If
        If Not IsNothing(oTableDetailBillOfLading_House) Then
            Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            Dim indexBill As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index

            Approve = Me.dgdDetailBillOfLading_House.Item("CargoHouseApprove", index).Value
            EditTable = Me.dgdDetailBillOfLading_House.Item("CargoHouseEditable", index).Value
            If mCargoHouseStatus = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLadingHouse", "Edit") Then
                Me.dgdDetailBillOfLading_House.Enabled = False
                'Me.TabCargo.Visible = True
                ReFormat()

                mCargo_ID = Me.dgdDetailBillOfLading_House.Item("CargoHouseCargoHouse_Id", index).Value.ToString

                mCargoHouseStatus = "Edit"

                CargoHouseRefreshData(index)

                Me.fraCargoGoods.Enabled = True
                Me.txtDescription.Enabled = True
                Me.lblDescription.Enabled = True

                Me.CargoHousecmdOK.Enabled = True
                Me.txtWeek.Text = CargoHouseWeekOfYear()
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

    Private Sub CargoHouseRefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Dim kind As String
        'Me.txtClauseOfService.Text = Me.dgdDetailBillOfLading_House.Item("ClauseOfservice", index).Value.ToString
        Me.txtCTN_NO.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseContainersId", index).Value.ToString
        mCargoHouseContainerID = Me.dgdDetailBillOfLading_House.Item("CargoHouseContainer_ID", index).Value.ToString

        Me.cboSealNo.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSealNo", index).Value.ToString
        '--9 seal no
        Me.txtSeal_no2.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No2", index).Value.ToString
        Me.txtSeal_no3.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No3", index).Value.ToString
        Me.txtSeal_no4.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No4", index).Value.ToString
        Me.txtSeal_no5.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No5", index).Value.ToString
        Me.txtSeal_no6.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No6", index).Value.ToString
        Me.txtSeal_no7.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No7", index).Value.ToString
        Me.txtSeal_no8.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No8", index).Value.ToString
        Me.txtSeal_no9.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSeal_No9", index).Value.ToString
        '------------------------------------



        Me.txtContainerType.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseContainerType", index).Value.ToString
        Me.txtVent.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseVent", index).Value.ToString
        Me.txtAmount.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseAmount", index).Value.ToString
        kind = Me.dgdDetailBillOfLading_House.Item("CargoHouseKind", index).Value.ToString
        Me.txtKind.Text = kind
        Me.txtCodeKind.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseKind_code", index).Value.ToString

        Me.txtGross.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseGross", index).Value.ToString
        Me.cboUnitGross.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseUnitGross", index).Value.ToString
        Me.txtMeas.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseMeas", index).Value.ToString
        Me.cboUnitVolume.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseUnitMeas", index).Value.ToString





        If Me.dgdDetailBillOfLading_House.Item("CargoHouseReceiveDate", index).Value.ToString <> "" Then
            Me.DateTimePicker.Value = CDate(Me.dgdDetailBillOfLading_House.Item("CargoHouseReceiveDate", index).Value.ToString)
            Me.chkReceiveDate.Checked = True
        Else
            Me.chkReceiveDate.Checked = False
        End If




        Me.txtWeek.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseWeek", index).Value.ToString

        If Me.dgdDetailBillOfLading_House.Item("CargoHouseReeferDegree", index).Value.ToString <> "" Then
            Me.txtReeferDegree.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseReeferDegree", index).Value.ToString
            Me.txtReeferDegree.Visible = True
        End If

        Me.txtCargoHouseNote.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseNote", index).Value.ToString
        Me.txtDescription.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseDescription", index).Value.ToString
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.txtCargoMarks.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCargoMarks", index).Value.ToString
        Me.txtCargoRemarks.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCARGO_REMARKS", index).Value.ToString
        Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCARGO_SEQUENCE", index).Value.ToString
        'Me.txtCargoGrossCube.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCARGO_GROSS_CUBE", index).Value.ToString
        Me.txtTempSetting.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseTEMPERATURE_SETTING", index).Value.ToString
        Me.txttempID.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseTEMPERATURE_ID", index).Value.ToString

        Me.txtMinTemp.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseMIN_TEMP", index).Value.ToString
        Me.txtMaxTemp.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseMAX_TEMP", index).Value.ToString

        'Me.txtNetweight.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCARGO_NET_WEIGHT", index).Value.ToString
        Me.txtCommodity.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCOMMODITY", index).Value.ToString
        Me.txtShipperOwnedUnit.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseSHIPPER_OWNED_UNIT", index).Value.ToString
        Me.txtCommodityGroup.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCOMMODITY_GROUP", index).Value.ToString


        Me.txtEMS.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseEMS", index).Value.ToString
        Me.txtTariff.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseTARIFF", index).Value.ToString
        Me.txtHsCode.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseHS_CODE", index).Value.ToString
        Me.txtImoClass.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseIMO_CLASS", index).Value.ToString
        Me.txtIMOPage.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseIMO_PAGE", index).Value.ToString
        Me.txtImoUnNo.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseIMO_UN_NO", index).Value.ToString
        Me.txtFlashPoint.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseFLASH_POINT", index).Value.ToString
        Me.txtMFAG.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseMFAG", index).Value.ToString
        Me.txtTachnicalDescription.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseTECHNICAL_DESCRIPTION", index).Value.ToString
        Me.txtPHDescription.Text = Me.dgdDetailBillOfLading_House.Item("CargoHousePACKAGE_HAZARDOUS_DESCRIPTION", index).Value.ToString
        Me.txtCTNStatus.Text = Me.dgdDetailBillOfLading_House.Item("CargoHouseCTN_STATUS", index).Value.ToString
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description & "RefreshData")
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
            'If Me.txtShipperOwnedUnit.Text = "N" Then
            '    Me.txtCargoRemarks.Text = "COC"
            'ElseIf Me.txtShipperOwnedUnit.Text = "Y" Then
            '    Me.txtCargoRemarks.Text = "SOC"
            'Else
            '    Me.txtCargoRemarks.Text = ""
            'End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub



    Private Sub chkReceiveDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkReceiveDate.CheckedChanged
        If Me.chkReceiveDate.Checked = True Then
            Me.DateTimePicker.Enabled = True
        Else
            Me.DateTimePicker.Enabled = False
        End If
    End Sub

    Private Sub smnuCargoHouseDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuCargoHouseDelete.Click
        Dim selectedRowCount As Integer = _
     Me.dgdDetailBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim indexhouse As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                CargoHouseDeleteRow(Me.dgdDetailBillOfLading_House.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryDetailBillOfLading_House(" And Cargo_House.BLH_ID='" & Me.dgdBillOfLading_House.Item("BLH_ID", indexhouse).Value.ToString & "'")
    End Sub

    Public Sub CargoHouseDeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryDetailBillOfLading_HouseList As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        strQuery = "Select count(*) cnt from FREIGHT_CHARGE_HOUSE WHERE BLH_Id = '" & Me.dgdDetailBillOfLading_House.Item("CargoHouseBLH_Id", index).Value.ToString & "'  and Continued=1 And Container_TYPE='" & Me.txtContainerType.Text.Trim & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The Containers can not be removed. There are transactions that relate to this Price Bill Of Lading.")
            Exit Sub
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading_House.Item("CargoHouseApprove", index)) Then
            If Me.dgdDetailBillOfLading_House.Item("CargoHouseApprove", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdDetailBillOfLading_House.Item("CargoHouseEditable", index)) Then
            If Not Me.dgdDetailBillOfLading_House.Item("CargoHouseEditable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingHouse", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container No: " & Me.dgdDetailBillOfLading_House.Item("CargoHouseContainersId", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryDetailBillOfLading_HouseList = "Select * from Cargo_House where" + " BLH_ID= '" & Me.dgdDetailBillOfLading_House.Item("CargoHouseBLH_ID", index).Value.ToString & "'AND CargoHouse_Id= '" & Me.dgdDetailBillOfLading_House.Item("CargoHouseCargoHouse_ID", index).Value.ToString & "'"
                rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                'Me.dgdDetailBillOfLading_House.Rows(index).DefaultCellStyle.ForeColor = Color.White
                'Me.dgdDetailBillOfLading_House.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub CargoHousecmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CargoHousecmdCancel.Click
        On Error GoTo Err_Renamed
        'Me.TabCargo.Visible = False
        'Me.txtDescription.Enabled = False
        'Me.lblDescription.Enabled = False
        'Me.txtClauseOfService.Enabled = False
        'ReFormat()
        'SetMenu((True))
        mCargoHouseStatus = "Normal"
        'reText(mStatus)
        Me.dgdDetailBillOfLading_House.Enabled = True
        Me.CargoHousecmdOK.Enabled = False
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CargoHousecmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CargoHousecmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        Dim indexBill As Integer
        Dim rsSeal, rsContainer As New ADODB.Recordset
        Dim strQuerySeal, sealId As String
        If Me.dgdDetailBillOfLading_House.RowCount > 0 Then
            index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
            indexBill = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        End If
        If CargoHouseCheckData() And (mCargoHouseStatus = "Add" Or mCargoHouseStatus = "Edit") Then
            If mCargoHouseStatus = "Edit" Then
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
            strQuery = strQuery & "WHERE ( BLH_Id = '" & mBILLOFLADING_HOUSEId & "' AND BLH_Id <> '" & DefaultValue & "') "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BLH_ID").Value = "{" + mBILLOFLADING_HOUSEId + "}"
                    .Fields("CargoHouse_Description_ID").Value = NewId()
                End If

                mCargoDesc_ID = .Fields("CargoHouse_Description_ID").Value
                .Fields("DESCRIPTION").Value = Trim(Me.txtDescription.Text)
                .Update()
            End With
            rs.Close()

            'thêm vào cargo 
            If mCargoHouseStatus = "Edit" Then
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

                    .Fields("BLH_Id").Value = "{" & mBILLOFLADING_HOUSEId & "}"


                End If
                strCargoHouse_ID = .Fields("CargoHouse_Id").Value
                '--------------them container
                '---- them container vao csdl
                strQuerySeal = "SELECT * "
                strQuerySeal = strQuerySeal & "FROM container "
                strQuerySeal = strQuerySeal & "WHERE container_no = '" & Me.txtCTN_NO.Text.Trim & "'  and continued=1"
                rsContainer.Open(strQuerySeal, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rsContainer
                    If Not rsContainer.EOF Then
                        mCargoHouseContainerID = .Fields("ctn_ID").Value()
                    Else
                        .AddNew()
                        mCargoHouseContainerID = NewId()
                        .Fields("ctn_ID").Value = mCargoHouseContainerID
                    End If



                    .Fields("container_no").Value = Me.txtCTN_NO.Text.Trim
                    .Fields("CTN_SIZE_TYPE").Value = Me.txtContainerType.Text.Trim
                    .Fields("netweight").Value = "0"
                    '.Fields("PACKAGES_ID").Value = "{" & FindValueID(Me.cboPackages, Me.cboPackages.Text) & "}"
                    rsContainer.Update()
                    ' Else
                    'If mCargoStatus <> "Edit" Then
                    'DisplayMessage(True, "please check Seal number.")
                    'Return
                    'End If

                    'End If

                End With
                rsContainer.Close()
                '.Fields("SEAL_ID").Value = SealId
                '---------------
                .Fields("CTN_ID").Value = mCargoHouseContainerID

                'strQuerySeal = "SELECT * "
                'strQuerySeal = strQuerySeal & "FROM container "
                'strQuerySeal = strQuerySeal & "WHERE container_no = '" & Me.txtCTN_NO.Text.Trim & "' and CTN_SIZE_TYPE='" & Me.txtContainerType.Text.Trim & "' and continued=1"
                'rsContainer.Open(strQuerySeal, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'With rsContainer
                '    'If rsSeal.EOF Then
                '    .AddNew()
                '    mCargoHouseContainerID = NewId()
                '    .Fields("ctn_ID").Value = mCargoHouseContainerID
                '    .Fields("container_no").Value = Me.txtCTN_NO.Text.Trim
                '    .Fields("CTN_SIZE_TYPE").Value = Me.txtContainerType.Text.Trim
                '    .Fields("netweight").Value = "0"
                '    '.Fields("PACKAGES_ID").Value = "{" & FindValueID(Me.cboPackages, Me.cboPackages.Text) & "}"
                '    rsContainer.Update()
                '    ' Else
                '    'If mCargoStatus <> "Edit" Then
                '    'DisplayMessage(True, "please check Seal number.")
                '    'Return
                '    'End If

                '    'End If

                'End With
                'rsContainer.Close()
                ''.Fields("SEAL_ID").Value = SealId
                ''---------------
                '.Fields("CTN_ID").Value = "{" & mCargoHouseContainerID & "}"

                '---------------------------------------------------------------------------







                '.Fields("CTN_ID").Value = "{" & mCargoHouseContainerID & "}"
                '------------------------------------------------------------

                'sealId = "{" + FindValueID(Me.cboSealNo, Me.cboSealNo.Text.Trim) + "}"
                '---- them seal vao csdl
                strQuerySeal = "SELECT * "
                strQuerySeal = strQuerySeal & "FROM Seal "
                strQuerySeal = strQuerySeal & "WHERE SealNo = '" & Me.cboSealNo.Text.Trim & "' and continued=1"
                rsSeal.Open(strQuerySeal, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rsSeal
                    'If rsSeal.EOF Then
                    .AddNew()
                    sealId = NewId()
                    .Fields("Seal_ID").Value = sealId
                    .Fields("SealNo").Value = Me.cboSealNo.Text.Trim
                    rsSeal.Update()
                    'End If

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
                '.Fields("CARGO_GROSS_CUBE").Value = Trim(Me.txtCargoGrossCube.Text)
                '.Fields("CARGO_NET_WEIGHT").Value = Trim(Me.txtNetweight.Text)
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


                .Fields("Week").Value = Trim(CargoHouseWeekOfYear)
                If Me.txtReeferDegree.Visible = True Then
                    .Fields("ReeferDegree").Value = Trim(Me.txtReeferDegree.Text)
                End If

                .Fields("Note").Value = Trim(Me.txtCargoHouseNote.Text)
                .Update()
            End With
            rs.Close()
            'DisplayMessage(True, "Save is OK!")
            'thêm vào Cargo Marks
            If mCargoHouseStatus = "Edit" Then
                'CopyValues("CARGOHouse_MARKS", "BLH_ID", mBILLOFLADING_HOUSEId)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHouse_MARKS "
            strQuery = strQuery & "WHERE BLH_ID = '" & mBILLOFLADING_HOUSEId & "'  "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouseMarks_ID").Value = NewId()
                    '.Fields("Cargo_ID").Value = strCargoHouse_ID
                    .Fields("BLH_ID").Value = "{" & mBILLOFLADING_HOUSEId & "}"
                End If
                mCargoMarks_ID = .Fields("CargoHouseMarks_ID").Value
                .Fields("MARKS").Value = Trim(Me.txtCargoMarks.Text)
                .Update()
            End With
            rs.Close()

            'Thêm Vào cargo remarks
            If mCargoHouseStatus = "Edit" Then
                'CopyValues("CARGOHouse_REMARKS", "BLH_ID", mBILLOFLADING_HOUSEId)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM CARGOHouse_REMARKS "
            strQuery = strQuery & "WHERE BLH_ID = '" & mBILLOFLADING_HOUSEId & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CargoHouseRemarks_ID").Value = NewId()
                    .Fields("BLH_ID").Value = "{" & mBILLOFLADING_HOUSEId & "}"
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
            'Me.TabCargo.Visible = False
            'Me.cmdOK.Enabled = False
            If mCargoHouseStatus = "Add" Then
                Me.txtCargoSequence.Text = Me.dgdDetailBillOfLading_House.Rows.Count + 1
            End If

            Dim CountContainer As Integer = 0
            For i As Integer = 0 To Me.dgdDetailBillOfLading_House.RowCount - 1
                If Me.dgdDetailBillOfLading_House.Item("CargoHouseContainerType", i).Value.ToString = Me.txtContainerType.Text And Me.dgdDetailBillOfLading_House.Item("CargoHouseBLH_ID", i).Value.ToString.Trim = FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) Then
                    CountContainer += 1
                End If
            Next
            ' update lai price
            Dim strSQL As String
            'strSQL = "Update FREIGHT_CHARGE_Master Set Quantity = " & CountContainer & " Where BL_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "' And Container_Type='" & Me.txtContainerType.Text.Trim & "'"
            'CargoHouseUpdateQuantity(strSQL)


            QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , 0)
            mCargoHouseStatus = "Normal"
            Me.CargoHousecmdOK.Enabled = False
            MsgBox("Complete")
        End If
        'Me.fraUpdate.Visible = False

        ReFormat()
        SetMenu((True))

        reText(mStatus)
        'blnUpdated = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Public Sub CargoHouseUpdateQuantity(ByVal strSQL As String)

        Try
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            'cmd.CommandType = CommandType.Text
            'cmd.CommandText = strSQL
            'cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Function CargoHouseCheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CargoHouseCheckData = True
        strMsg = ""
        Dim strBillOfLading_HouseId As String
        If Me.txtCTN_NO.Text = "" Then
            ' MsgBox("Container nto allow Null value")
            'Return False
        End If
        'If mCargoHouseStatus = "Add" Then
        '    Dim rs As New ADODB.Recordset
        '    Dim strSQL As String
        '    strSQL = "Select * From Cargo_House where CTN_ID='" & mCargoHouseContainerID & "' And BLH_ID='" & FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text) & "' And Continued=1"
        '    rs.Open(strSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        '    If Not rs.EOF Then
        '        strMsg = "This Container Had Already Had In This Bill "
        '        CargoHouseCheckData = False
        '    End If
        '    strBillOfLading_HouseId = DefaultValue
        'End If
        'If Len(Me.txtClauseOfService.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Clause Of Service is invalid."
        '    Me.txtClauseOfService.Focus()
        'End If

        If Len(Me.cboSealNo.Text) = 0 Then
            'CargoHouseCheckData = False
            'strMsg = strMsg & "The Seal No. is invalid. "
            'Me.cboSealNo.Focus()
        End If
        If Len(Me.txtAmount.Text) = 0 Then
            CargoHouseCheckData = False
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
            CargoHouseCheckData = False
            strMsg = strMsg & "The Gross is invalid."
            Me.txtGross.Focus()
        End If
        If Me.cboUnitGross.FindStringExact(Me.cboUnitGross.Text) = -1 Then
            CargoHouseCheckData = False
            strMsg = strMsg & "The Unit Gross is invalid."
            Me.cboUnitGross.Focus()
        End If
        If Len(Me.txtMeas.Text) = 0 Then
            CargoHouseCheckData = False
            strMsg = strMsg & "The Meas is invalid."
            Me.txtMeas.Focus()
        End If

        If Me.cboUnitVolume.FindStringExact(Me.cboUnitVolume.Text) = -1 Then
            CargoHouseCheckData = False
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
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub dgdDetailBillOfLading_House_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDetailBillOfLading_House.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDetailBillOfLading_House)
    End Sub
    Private Sub txtCargoRemarks_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCargoRemarks.Leave
        Try
            'If Me.txtCargoRemarks.Text = "COC" Then
            '    Me.txtShipperOwnedUnit.Text = "N"
            'ElseIf Me.txtCargoRemarks.Text = "SOC" Then
            '    Me.txtShipperOwnedUnit.Text = "Y"
            'Else
            '    DisplayMessage(True, "You Can input only 'COC'  Or 'SOC'")
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    '    Private Sub cboCTN_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '        Dim ContainerID As String

    '        ContainerID = FindValueID(Me.txtCTN_NO, Me.txtCTN_NO.Text)
    '        If ContainerID <> "" Then
    '            Dim strQuery As String
    '            '-------------
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Dim dset As New DataSet
    '            Dim table As New DataTable

    '            '----------------
    '            strQuery = "select * from Container where CTN_ID='" & ContainerID & "'"

    '            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '            '-----------------

    '            'If Not IsNothing(oTable) Then
    '            '    oTable.Clear()
    '            'End If
    '            Adapter.Fill(dset, "Bill")
    '            table = dset.Tables(0)
    '            If table.Rows.Count > 0 Then
    '                CtainerID = table.Rows(0).Item("CTN_ID").ToString
    '                Me.txtContainerType.Text = table.Rows(0).Item("CTN_SIZE_TYPE").ToString
    '                CargoHouseReefer_Degree()
    '            End If

    '        End If
    '        Exit Sub
    'Err_Named:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

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

    '    Private Sub cboCTN_NO_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.txtCTN_NO.Text = Trim(UCase(Me.txtCTN_NO.Text))
    '        strSql = "Select container_no as container_no From container Where Continued=1"
    '        If Me.txtCTN_NO.FindStringExact(Me.txtCTN_NO.Text) = -1 Then
    '            DisplayMessage(True, "The Container is invalid, please check and correct it.")
    '            Me.txtCTN_NO.Text = FindBetter_new("container_no", strSql, Me.txtCTN_NO.Text)
    '            If Me.txtCTN_NO.FindStringExact(Me.txtCTN_NO.Text) = -1 Then
    '                DisplayMessage(True, "The Container is invalid, please check and correct it.")
    '                Me.txtCTN_NO.Focus()
    '            End If
    '        End If
    '        CargoHouseReefer_Degree()
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboCTN_NO_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '        On Error GoTo Err_Named
    '        If mCargoHouseStatus = "Edit" Then
    '            Dim index As Integer
    '            If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
    '                index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '            End If

    '            Dim rs As New ADODB.Recordset
    '            Dim strQuery As String
    '            Dim blnEmpty As Boolean
    '            strQuery = "Select count(*) cnt from Freight_Charge_House WHERE Container_Type = '" & Me.txtContainerType.Text.Trim & "'  and Continued=1"
    '            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            blnEmpty = (rs.Fields("cnt").Value = 0)
    '            rs.Close()
    '            If Not blnEmpty Then
    '                DisplayMessage(True, "The Containers Kind can not be Change. There are Prieght Charge that relate to This Kind Container .")

    '                If Me.dgdDetailBillOfLading_House.Rows.Count > 0 Then
    '                    index = Me.dgdDetailBillOfLading_House.CurrentRow.Index
    '                    Me.txtCTN_NO.Text = Me.dgdDetailBillOfLading_House.Item("ContainersId", index).Value.ToString.Trim
    '                End If

    '                Exit Sub
    '            End If
    '        End If
    '        Exit Sub
    'Err_Named:
    '        DisplayMessage(True, Err.Description & " at Container no Mouse Click _HouseCargo")
    '    End Sub

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

    Public Sub CargoHouseApproveDetailBillOfLading_House()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDetailBillOfLading_House.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        If Not Me.dgdDetailBillOfLading_House.Item("CargoHouseEditable", index).Value Or Not UserRight("frmListBillOfLadingHouse", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from Cargo_House where" + " CARGOHOUSE_ID= '" & Me.dgdDetailBillOfLading_House.Item("CargoHouseCARGOHOUSE_ID", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
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
        If Me.dgdDetailBillOfLading_House.Columns(ColIndex).Name = "CargoHouseApprove" And Me.dgdDetailBillOfLading_House.CurrentCellAddress.Y = RowIndex Then
            Call CargoHouseApproveDetailBillOfLading_House()
            QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub HideTextCargo()
        '-----------
        cboBL_CY_CFS_Item.Text = ""
        cboRepaid_Collect.Text = ""
        '-----------------
        'txtHouseBLNumber.Text = ""
        'txtColoBLNO.Text = ""
        'txtNumOfPackages.Text = ""

        '-----------------------------
        Me.txtCTN_NO.Text = ""
        txtContainerType.Text = ""
        cboSealNo.Text = ""
        txtSeal_no2.Text = ""
        txtSeal_no3.Text = ""
        txtSeal_no4.Text = ""

        txtSeal_no5.Text = ""
        txtSeal_no6.Text = ""
        txtSeal_no7.Text = ""
        txtSeal_no8.Text = ""
        txtSeal_no9.Text = ""
        txtAmount.Text = "0"
        txtCodeKind.Text = ""
        txtKind.Text = ""
        txtGross.Text = "0"
        txtMeas.Text = "0"
        txtReeferDegree.Text = ""
        txtWeek.Text = ""
        txtCTNStatus.Text = ""
        'txtCargoNote.Text = ""
        txtVent.Text = ""
        '-------------
        txtEMS.Text = ""
        txtMFAG.Text = ""
        txtImoUnNo.Text = ""
        txtIMOPage.Text = ""
        txtImoClass.Text = ""
        txtFlashPoint.Text = ""

        txtPHDescription.Text = ""


        txtTachnicalDescription.Text = ""
        '-----------------------------------
        txtCargoSequence.Text = ""
        txtTempSetting.Text = ""
        txtCommodity.Text = ""

        txtCommodityGroup.Text = ""
        'txtCargoGrossCube.Text = "0"
        'txtNetweight.Text = "0"
        txtCargoRemarks.Text = ""

        txtTariff.Text = ""
        txtHsCode.Text = ""
        txtMinTemp.Text = ""
        txtMaxTemp.Text = ""
        txtShipperOwnedUnit.Text = ""
        'txtTotalGrossW.Text = "0"
        'txtTotalVolime.Text = "0"
        'txtTotalPackage.Text = "0"
        txtDescription.Text = ""
        txtCargoMarks.Text = ""
        '-----------------------------cboPrepaidCollectP
        'cboPrepaidCollectP.Text = ""
        ''----------------------------------
        'cboCargoContainerType.Text = ""
        'cbocargoChargeCode.Text = ""
        'txtCargoPayerableatCode.Text = ""
        'txtCargoPayerAbleAt.Text = ""
        'txtCargoChargeRate.Text = "0"
        'txtCargoChargeRateSale.Text = "0"

        'txtCargoQuantity.Text = "0"

        'cboCargoCurrency.Text = ""
        'cboCargoPrePaidCollect.Text = ""
        'txtCargoPayerCode.Text = ""

        'txtcargoIG_Code.Text = ""
        '--------
        cboSealNo.Text = ""

    End Sub
#End Region

    Sub VisibleCargo(ByVal value As Boolean)

        If Me.dgdDetailBillOfLading_House.Visible = Not value Then
            Me.dgdDetailBillOfLading_House.Size = Me.dgdBillOfLading_House.Size
            Me.dgdDetailBillOfLading_House.Height += Me.grpFindBill.Height
            Me.dgdDetailBillOfLading_House.Top = Me.dgdBillOfLading_House.Top
            Me.dgdDetailBillOfLading_House.Left = Me.dgdBillOfLading_House.Left
            Me.dgdDetailBillOfLading_House.Top = Me.MenuStrip.Bottom + 5
            'Me.CargoHousecmdOK.Location = Me.cmdChecking.Location
            'Me.CargoHousecmdCancel.Location = Me.cmdCancel.Location
            'Me.CargoHousecmdCancel.Left -= 10
        End If

        Me.dgdDetailBillOfLading_House.Visible = value
        Me.CargoHouseMenuStrip.Visible = value
        Me.CargoHousecmdCancel.Visible = value
        Me.CargoHousecmdOK.Visible = value

        Me.grpFindBill.Visible = Not value
        Me.cmdOK.Visible = Not value
        Me.cmdCancel.Visible = Not value
        'Me.cmdChecking.Visible = Not value
        Me.dgdBillOfLading_House.Visible = Not value
        Me.MenuStrip.Visible = Not value
    End Sub
    Private Sub tagInformationCustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tagInformationCustomer.SelectedIndexChanged
        If Me.tagInformationCustomer.SelectedTab.Name Like "CargoHouse*" Then
            If Me.dgdBillOfLading_House.RowCount = 0 Then
                Return
            End If

            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            If Me.dgdBillOfLading_House.Item("GridChecking", index).Value = True Then
                Me.tagInformationCustomer.SelectTab(Me.TabCustomer)
                MsgBox("This Bill Has not completed,Please Complete it before add cargo")
                Return
            End If
            If LoadCargoHouse = False Then
                Load_CargoHouse()
            End If
            VisibleCargo(True)
        Else
            VisibleCargo(False)
        End If
    End Sub

    Private Sub smnuCargoHouseExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCargoHouseExit.Click
        Me.cmdCancel_Click(sender, e)
    End Sub


    Private Sub txtCTN_NO_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.txtContainerType.Text = CheckContainer(Me.txtCTN_NO.Text, mCargoHouseContainerID)
        'If Me.txtContainerType.Text = "" Then
        '    MsgBox("Container No is Invalid Or Container Not In Database , please Check again")
        '    Me.txtCTN_NO.Focus()
        '    Return
        'End If
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

    Private Sub GetBLNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetBLNoToolStripMenuItem.Click
        Try

            Me.txtBillHouse.Text &= GetBookingNumberFromDB()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub smnuBillOfLadingHouseData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuBillOfLadingHouseData.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptHouseBill.RptName = "Data"


            VB6.ShowForm(frmRptHouseBill, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txtBLType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBLType.TextChanged
        If UCase(Me.txtBLType.Text) = "O" Then
            Me.txtNoOfOrigineBL.Text = "3"
            Me.txtNoOfCopyBL.Text = "3"
        Else
            Me.txtNoOfOrigineBL.Text = "0"
            Me.txtNoOfCopyBL.Text = "0"
        End If
    End Sub

    Private Sub txtPayerCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPayerCode.TextChanged
        If UCase(Me.txtPayerCode.Text) = "S" Then
            Me.cboRepaid_Collect.Text = "PREPAID"
        Else
            Me.cboRepaid_Collect.Text = "COLLECT"
        End If
    End Sub
    Function GetMasterMerss(ByVal ID As String) As String
        Try
            Dim SQL As String
            SQL = "select Payer From BillOfLading Where BL_ID='" & ID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub DebitNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteToolStripMenuItem.Click
        'frmprintFreightNote_House.Show()
        On Error GoTo Err
        Dim GbILLOFLADING As String
        If dgdBillOfLading_House.RowCount > 0 Then
            'QueryCustomer()
            Me.fraFreightNote.Visible = True
            Me.fraFreightNote.BringToFront()

            Dim index As Integer = dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            GbILLOFLADING = dgdBillOfLading_House.Item("BL_ID", index).Value.ToString
            'gBillNohouseRpt = Me.dgdBillOfLading_House.Item("BL_NO", index).Value.ToString
            Me.txtMessrs.Text = GetMasterMerss(GbILLOFLADING) 'Me.dgdBillOfLading_House.Item("Payer", index).Value.ToString

            'lấy thông shipper
            'Dim SQL As String
            'SQL = "select Payer from BillOfLading Where Shipper_ID='" & Me.dgdBillOfLading.Item("Shipper_ID", index).Value.ToString & "'"
            'Dim dt As New DataTable
            'dt = ReadTable(SQL)
            'If dt.Rows.Count > 0 Then
            '    Me.txtMessrs.Text = dt.Rows(0).Item("Shipper_1").ToString & Chr(13) & Chr(10)
            '    Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_2").ToString & Chr(13) & Chr(10)
            '    Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_3").ToString & Chr(13) & Chr(10)
            '    Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_4").ToString & Chr(13) & Chr(10)
            '    Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_5").ToString & Chr(13) & Chr(10)
            '    Me.txtMessrs.Text &= dt.Rows(0).Item("Remarks").ToString '& Chr(13) & Chr(10)

            '    Me.fraFreightNote.Visible = True
            '    Me.fraFreightNote.BringToFront()

            'End If

        End If
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub cmdOkFreightNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkFreightNote.Click
        On Error GoTo Err
        Me.fraFreightNote.Visible = False
        frmRptFreightNoteOutbound_House.ShowDialog()
        'Me.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelFreightnote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelFreightnote.Click
        On Error GoTo Err
        Me.fraFreightNote.Visible = False
        'Me.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txtSEQ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSEQ.TextChanged
        If Me.txtSEQ.Text = "1" Then
            Me.txtRoutingVesselCode.Text = Me.txtPreVessel.Text
            Me.txtRoutingVoyAge.Text = Me.txtPreVesselNo.Text
        Else
            Me.txtRoutingVesselCode.Text = ""
            Me.txtRoutingVoyAge.Text = ""
        End If
    End Sub

    Private Sub cmdCancleChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancleChange.Click
        Me.GbEditBLH_No.Visible = False
    End Sub

    Private Sub ChangeHouseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeHouseToolStripMenuItem.Click
        Try
            If Me.dgdBillOfLading_House.RowCount = 0 Or IsNothing(Me.dgdBillOfLading_House.CurrentRow) Then
                Return
            End If
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            Me.txtOldHouseBLHNO.Text = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            mBILLOFLADING_HOUSEId = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            Me.GbEditBLH_No.Visible = True
            Me.GbEditBLH_No.BringToFront()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Sub UpdateBLHNO(ByVal ID As String)
        Try
            Dim SQL As String
            SQL = "Update BillOfLading_House "
            SQL &= " Set BLH_NO='" & Me.txtNewBLHNO.Text.Trim & "'"
            SQL &= " Where BLH_ID='" & ID & "'"
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
    Private Sub cmdChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChange.Click
        Try
            UpdateBLHNO(mBILLOFLADING_HOUSEId)
            Me.GbEditBLH_No.Visible = False
            mFilter = " And BLH_ID='" & mBILLOFLADING_HOUSEId & "'"
            QueryBILLOFLADING_HOUSE(" " & mFilter)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Me.txtNewBLHNO.Text &= GetBookingNumberFromDB()
    End Sub

    Private Sub txtNote_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNote.TextChanged

    End Sub

    Private Sub txtShipper_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtShipper.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    cxtsmnuShipper_Click(sender, e)
        'End If
    End Sub

    Private Sub txtShipper_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtShipper.TextChanged

    End Sub

    Private Sub txtConsignee_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtConsignee.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    cxtsmnuConsignee_Click(sender, e)
        'End If
    End Sub

    Private Sub txtConsignee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConsignee.TextChanged

    End Sub

    Private Sub txtNotify_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotify.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    cxtsmnuNotify_Click(sender, e)
        'End If
    End Sub

    Private Sub txtNotify_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotify.TextChanged

    End Sub

    Private Sub txtNotify2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotify2.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    ctmnuSearchNotify2_Click(sender, e)
        'End If
    End Sub

    Private Sub txtNotify2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotify2.TextChanged

    End Sub

    Private Sub txtNotify3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNotify3.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    ctmnuSearcheNotify3_Click(sender, e)
        'End If
    End Sub

    Private Sub txtNotify3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNotify3.TextChanged

    End Sub

    Private Sub fraUpdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.Enter

    End Sub

    Private Sub InstructionDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstructionDetailsToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptHouseBill.RptName = ""


            VB6.ShowForm(frmRptInstructionDetails, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InstructionAMSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InstructionAMSToolStripMenuItem.Click
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptHouseBill.RptName = ""

            VB6.ShowForm(frmRptInstructionAMS, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DraftBillOfLadingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DraftBillOfLadingToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptHouseBill.RptName = ""

            VB6.ShowForm(frmRptHouseBill, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txtCTN_NO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DraftBillAirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DraftBillAirToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRPTAir.RptName = ""

            VB6.ShowForm(frmRPTAir, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillAirDataOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillAirDataOriginalToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRPTAir.RptName = "Data"

            VB6.ShowForm(frmRPTAir, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DraftBillZimexToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptDrafBillZimex.RptName = ""

            VB6.ShowForm(frmRptDrafBillZimex, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BillZimexOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillZimexOriginalToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptDrafBillZimex.RptName = "Data"

            VB6.ShowForm(frmRptDrafBillZimex, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ManifestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManifestToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillNoManifestID = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillNoManifest = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            'frmRptCargoManifest.RptName = "Data"

            VB6.ShowForm(frmRptCargoManifest, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.txtShipper.Text = Me.cboShipper.Text
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.txtConsignee.Text = Me.cboConsignee.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.txtNotify.Text = Me.cboNotify.Text
    End Sub
    Public Sub getShipper()
        On Error GoTo ERR_NAMED
        Dim id As String = "shipper"
        Dim value As String = "shipper"
        Dim strQuery As String = "Select distinct Shipper from billoflading_house where CONTINUED=1 Order by shipper "
        loadDataToObject(Me.cboShipper, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub getConsignee()
        On Error GoTo ERR_NAMED
        Dim id As String = "Consignee"
        Dim value As String = "Consignee"
        Dim strQuery As String = "Select distinct Consignee from billoflading_house where CONTINUED=1 Order by Consignee "
        loadDataToObject(Me.cboConsignee, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub getNotify()
        On Error GoTo ERR_NAMED
        Dim id As String = "Notify"
        Dim value As String = "Notify"
        Dim strQuery As String = "Select distinct Notify from billoflading_house where CONTINUED=1 Order by Notify "
        loadDataToObject(Me.cboNotify, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryAgency()
        On Error GoTo ERR_NAMED
        Dim id As String = "Agency_Id"
        Dim value As String = "AgencyName"
        Dim strQuery As String = "Select Agency_Id,AgencyName from agency where CONTINUED=1 Order by agencyname"
        loadDataToObject(Me.cboagency, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim sql As String
        Dim ds As New DataSet
        sql = "select * from agency where agencyname='" & Me.cboagency.Text & "'"
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBox1.Text = ds.Tables(0).Rows(0).Item("agencyname").ToString + vbCrLf
            Me.TextBox1.Text += ds.Tables(0).Rows(0).Item("Address").ToString + vbCrLf
            If ds.Tables(0).Rows(0).Item("agencyname").ToString <> "" Then
                Me.TextBox1.Text += "Tel: " + ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                Me.TextBox1.Text += "Fax : " + ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
            End If

        Else
            DisplayMessage(True, "Please check again.!")
        End If
    End Sub
    

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.txtCargoRemarks.Text = "CONTAINER TO BE SET AT       .CEL " + Chr(13) + Chr(10) + "SAY TOTAL :              FEET CONTAINER ONLY " + Chr(13) + Chr(10) + "SHIPPER 'S LOAD, COUNT, STOWAGE & SEAL.  "
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Me.txtDescription.Text = "()x   CONTAINER S.T.C."
    End Sub

    Private Sub cboBookingNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBookingNo.SelectedIndexChanged

    End Sub

    Private Sub ChartingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err
        VB6.ShowForm(frmChartingOutboundHouse, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txttempID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txttempID.TextChanged

    End Sub

    Private Sub ReportDetailQuantityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportDetailQuantityToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmCheckLoadingList, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DisplayMasterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayMasterToolStripMenuItem.Click
        Dim index As Integer
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.Rows.Count = 0 Then
            Exit Sub
        End If
        index = Me.dgdBillOfLading_House.CurrentRow.Index
        If Me.dgdBillOfLading_House.RowCount = 0 Then
            Return
        End If
        Dim i As Integer
        Dim sql, tempS As String
        Dim ds As New DataSet

        sql = "select * from billoflading where bl_id='" & Me.dgdBillOfLading_House.Item("bl_Id", index).Value.ToString & "' and continued=1 "

        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            For i = 0 To ds.Tables(0).Rows.Count - 1
                tempS += ds.Tables(0).Rows(i).Item("bl_no").ToString + ", "
            Next
        End If
        Dim frm As New frmThongbao
        frm.txtnoidung.Text = tempS
        frm.ShowDialog()
    End Sub

    Private Sub txtMF_FilingType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMF_FilingType.SelectedIndexChanged

    End Sub

    Private Sub txtPlofReceiptCode_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlofReceiptCode.Leave
        CheckPortcbo(Me.txtPlofReceiptCode, Me.txtPlofReceiptName, POR_ID)
    End Sub

    Private Sub txtPlofReceiptCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlofReceiptCode.SelectedIndexChanged

    End Sub

    Private Sub txtPlofReceiptCode_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlofReceiptCode.TextChanged
        If Me.txtPlofReceiptCode.Text.Length = 5 Then
            txtPlofReceiptCode_Leave1(sender, e)
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Me.txtNgayGoiBill.Text = Me.DateTimePicker1.Value.ToString
    End Sub

    Private Sub dgdBillOfLading_House_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBillOfLading_House.RowHeaderMouseClick
        Try


            'Dim index1 As Integer
            'Dim chk As Integer
            'chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If chk = 0 Then
            '    'DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            '    'Return
            'End If
            'If Me.dgdBillOfLading_House.Rows.Count = 0 Then
            '    Exit Sub
            'End If
            'index1 = Me.dgdBillOfLading_House.CurrentRow.Index
            'If Me.dgdBillOfLading_House.RowCount = 0 Then
            '    Return
            'End If
            'Dim i As Integer
            'Dim sql, tempS As String
            'Dim ds As New DataSet

            'sql = "select * from billoflading where bl_id='" & Me.dgdBillOfLading_House.Item("bl_Id", index1).Value.ToString & "' and continued=1 "

            'ds = ReadDataSet(sql)
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To ds.Tables(0).Rows.Count - 1
            '        tempS += ds.Tables(0).Rows(i).Item("bl_no").ToString
            '    Next
            'End If
            'Me.cboBillOfLading_House.Text = tempS

            Dim ColIndex, RowIndex, index As Integer
            ' Xác định vị trí row trong grid
            If Me.oTable.Rows.Count > 0 Then
                index = Me.BindingContext(oTable).Position
            Else
                Exit Sub
            End If
            ColIndex = e.ColumnIndex()
            RowIndex = e.RowIndex
            If ColIndex < 0 Then
                'Return
            End If
            'If Me.dgdBillOfLading_House.Columns(ColIndex).Name = "Approve" And Me.dgdBillOfLading_House.CurrentCellAddress().Y = index Then
            '    Call ApproveDetailBillOfLading_House()
            'End If
            '---------------------------------- hien thi masterbill
            Dim index1 As Integer
            Dim chk As Integer
            chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                'DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                'Return
            End If
            If Me.dgdBillOfLading_House.Rows.Count = 0 Then
                Exit Sub
            End If
            index1 = Me.dgdBillOfLading_House.CurrentRow.Index
            If Me.dgdBillOfLading_House.RowCount = 0 Then
                Return
            End If
            Dim i As Integer
            Dim sql, tempS As String
            Dim ds As New DataSet

            sql = "select * from billoflading where bl_id='" & Me.dgdBillOfLading_House.Item("bl_Id", index1).Value.ToString & "' and continued=1 "

            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    tempS += ds.Tables(0).Rows(i).Item("bl_no").ToString
                Next
            End If
            Me.cboBillOfLading_House.Text = tempS
            '------------------------------------------
            Exit Sub

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtCTN_NO_Leave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCTN_NO.Leave
        'Me.txtContainerType.Text = CheckContainer(Me.txtCTN_NO.Text, mCargoHouseContainerID)
        'If Me.txtContainerType.Text <> "" Then
        '    MsgBox("Container No is Invalid Or Container Not In Database , please Check again")
        '    Me.txtCTN_NO.Focus()
        '    Return
        'End If
    End Sub

    Private Sub txtCTN_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCTN_NO.SelectedIndexChanged

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim ds As New DataSet
        Dim i As Integer
        Dim sql As String
        Dim bookingNo As String
        bookingNo = Me.cboBookingNo.Text
        Me.txtCTN_NO.Items.Clear()
        Me.cboSealNo.Items.Clear()
        If bookingNo = "" Then
            Return
        End If
        sql = "select * from containeroutboundnotify where bookingNo='" & bookingNo & "' and continued=1 "
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then

            Me.txtCTN_NO.Items.Add(ds.Tables(0).Rows(0).Item("cont1").ToString)
            Me.txtCTN_NO.Items.Add(ds.Tables(0).Rows(0).Item("cont2").ToString)
            Me.txtCTN_NO.Items.Add(ds.Tables(0).Rows(0).Item("cont3").ToString)
            Me.txtCTN_NO.Items.Add(ds.Tables(0).Rows(0).Item("cont4").ToString)


            Me.cboSealNo.Items.Add(ds.Tables(0).Rows(0).Item("seal1").ToString)
            Me.cboSealNo.Items.Add(ds.Tables(0).Rows(0).Item("seal2").ToString)
            Me.cboSealNo.Items.Add(ds.Tables(0).Rows(0).Item("seal3").ToString)
            Me.cboSealNo.Items.Add(ds.Tables(0).Rows(0).Item("seal4").ToString)

        Else
            Return
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.txtContainerType.Text = CheckContainer(Me.txtCTN_NO.Text, mCargoHouseContainerID)
        If Me.txtContainerType.Text <> "" Then
            ' lay so bill house tu ID
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from billoflading_house where blh_id ='" & Me.txtContainerType.Text.Trim & "' and continued=1 "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                MsgBox("Container đã tồn tại trong Bill : " & ds.Tables(0).Rows(0).Item("blh_no").ToString)
          
            End If

            Me.txtCTN_NO.Focus()
            Return
        Else
            DisplayMessage(True, "Container chưa có .!")
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.txtngaynhanbill.Text = Me.DateTimePicker2.Value.ToString
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.txtngayfileAMS.Text = Me.DateTimePicker3.Value.ToString
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Me.txtngaygoichungtu.Text = Me.DateTimePicker4.Value.ToString
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Me.txtNgaychinhsuasauDL.Text = Me.DateTimePicker5.Value.ToString
    End Sub

    Private Sub cboBookingNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBookingNo.TextChanged
        Dim sql As String
        Dim ds As New DataSet
        '--------------------------------------
        'On Error GoTo Err_Renamed
        Dim strSql, shipper_code As String
        strSql = "Select BookingNo  as BookingNo From containeroutboundnotify Where Continued=1"
        If Me.cboBookingNo.FindStringExact(Me.cboBookingNo.Text) = -1 Then
            Me.cboBookingNo.Text = FindBetter_new("BookingNo", strSql, Me.cboBookingNo.Text)
            If Me.cboBookingNo.FindStringExact(Me.cboBookingNo.Text) = -1 Then
                DisplayMessage(True, "The Booking No. is invalid, please check and correct it.")
                Me.cboBookingNo.Focus()
            End If
        End If
        cboBookingNo_Change()
        '
        '----------------------------------------------------
        If Me.cboBookingNo.Text = "" Then
            Return
        End If
        sql = " select * from containeroutboundnotify where bookingno='" & Me.cboBookingNo.Text.Trim & "' and continued=1 "
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.txtSI.Text = ds.Tables(0).Rows(0).Item("giobd").ToString + " " + ds.Tables(0).Rows(0).Item("ampmbd").ToString + " " + CDate(ds.Tables(0).Rows(0).Item("bd").ToString).Date.ToString.Replace("00:00:00", "").Replace("12:00:00 AM", "")
        End If
    End Sub

    Private Sub Label87_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label87.Click

    End Sub

    Private Sub cboBooking_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBooking.Leave

    End Sub

    Private Sub cboBooking_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBooking.SelectedIndexChanged

    End Sub
    Public Sub SearchBooking()
        On Error GoTo Err_Named
        Dim Bill_ID As String
        Dim bk_ID As String

        If Me.cboBooking.Text = "" Then
            Return
        End If
        bk_ID = FindValueID(Me.cboBooking, Me.cboBooking.Text)
        QueryBILLOFLADING_HOUSE(" And BillOfLading_House.containerOutboundNotifyID='" & bk_ID & "'", 14)
        If Bill_ID <> "" Then
            'Dim strQuery As String
            ''-------------
            'Dim Con As New SqlClient.SqlConnection(strconnDG)
            'Dim dset As New DataSet
            'Dim table As New DataTable
            ''----------------
            'strQuery = "select SHIPPER_1,Shipper.Shipper_ID,B illOFLading_House.Shipper_ID,BillOFLading_House.BL_ID as BL_ID" & _
            '" from SHIPPER LEFT JOIN  BillOFLading_House ON BillOFLading_House.Shipper_ID=Shipper.Shipper_ID where BL_ID='" & Bill_ID & "'"

            'Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            'Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            ''-----------------
            'Adapter.Fill(dset, "Bill")
            'table = dset.Tables(0)
            'If table.Rows.Count > 0 Then
            '    'Me.txtShipperName.Text = table.Rows(0).Item("SHIPPER_1")
            'End If
        End If
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        SearchBooking()
    End Sub

    Private Sub DraftNCShippingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DraftNCShippingToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptDrafBillZimex.RptName = ""

            VB6.ShowForm(frmRptDrafBillZimex, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub TabBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabBase.Click

    End Sub

    Private Sub lblfromdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblfromdate.Click

    End Sub

    Private Sub DTPFromDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPFromDate.ValueChanged

    End Sub

    Private Sub lblToDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblToDate.Click

    End Sub

    Private Sub DTPToDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPToDate.ValueChanged

    End Sub

    Private Sub TabPage1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub BillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BillToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptVINPAC.RptName = "Data"


            VB6.ShowForm(frmRptVINPAC, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub UnitedHarbourLogisticsOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnitedHarbourLogisticsOriginalToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptUnitedHarbour.RptName = "Data"


            VB6.ShowForm(frmRptUnitedHarbour, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub HEADWINGLOBALLOGISTICSUSAOriginalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HEADWINGLOBALLOGISTICSUSAOriginalToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptHEADWIN.RptName = "Data"


            VB6.ShowForm(frmRptHEADWIN, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        On Error GoTo Err_Named
        Dim Bill_ID As String
        If Me.cboBillOfLading_House.Text = "" Then
            Return
        End If
        Bill_ID = FindValueID(Me.cboBillOfLading_House, Me.cboBillOfLading_House.Text)
        QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Bill_ID & "'", 14)
        If Bill_ID <> "" Then
            'Dim strQuery As String
            ''-------------
            'Dim Con As New SqlClient.SqlConnection(strconnDG)
            'Dim dset As New DataSet
            'Dim table As New DataTable
            ''----------------
            'strQuery = "select SHIPPER_1,Shipper.Shipper_ID,BillOFLading_House.Shipper_ID,BillOFLading_House.BL_ID as BL_ID" & _
            '" from SHIPPER LEFT JOIN  BillOFLading_House ON BillOFLading_House.Shipper_ID=Shipper.Shipper_ID where BL_ID='" & Bill_ID & "'"

            'Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            'Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            ''-----------------
            'Adapter.Fill(dset, "Bill")
            'table = dset.Tables(0)
            'If table.Rows.Count > 0 Then
            '    'Me.txtShipperName.Text = table.Rows(0).Item("SHIPPER_1")
            'End If
        End If
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub FormLabelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormLabelToolStripMenuItem.Click
        On Error GoTo Err
        Dim index As Integer

        If Me.dgdBillOfLading_House.Rows.Count > 0 Then
            index = Me.dgdBillOfLading_House.CurrentRow.Index
        Else
            Exit Sub
        End If
        gBLH_NO = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString.Trim

        'gMBL = Me.dgdBillOfLading.Item("MBL", index).Value.ToString.Trim
        'gBillInboundID = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString.Trim
        'gInboundBLOriginal = "0"
        ''VB6.ShowForm(frmRptBillInBound, VB6.FormShowConstants.Modal, Me)

        Dim frm As New frmRptformLabelOutbound
        frm.Show()


        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub refreshFreight(ByVal index As Integer)
        Me.cboContainerType.Text = Me.dgdPrice.Item("CONTAINERTYPEP", index).Value.ToString
        Me.txtItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
        Me.txtCurrency.Text = Me.dgdPrice.Item("Currency", index).Value.ToString
        '--------------------
        Me.txtDebitTruocThue.Text = Me.dgdPrice.Item("debitTruocThue", index).Value.ToString.Trim
        Me.txtTaxDebit.Text = Me.dgdPrice.Item("TaxDebit", index).Value.ToString.Trim
        Me.txtNotebuy.Text = Me.dgdPrice.Item("notebuy", index).Value.ToString.Trim
        Me.txtDebit.Text = Me.dgdPrice.Item("priceban", index).Value.ToString
        '---------------------------------------------------------------------
        Me.txtCreditTruocThue.Text = Me.dgdPrice.Item("CreditTruocThue", index).Value.ToString.Trim
        Me.txtTaxCredit.Text = Me.dgdPrice.Item("TaxCredit", index).Value.ToString.Trim
        Me.txtNoteban.Text = Me.dgdPrice.Item("noteban", index).Value.ToString.Trim
        Me.txtCredit.Text = Me.dgdPrice.Item("pricebuy", index).Value.ToString
        '---------------------------------------------------------------------------------





        'Me.txttax.Text = Me.dgdPrice.Item("tax", index).Value.ToString
        Me.txtRemarks.Text = Me.dgdPrice.Item("remarks", index).Value.ToString
        Me.txtRemarksCredit.Text = Me.dgdPrice.Item("remarkscredit", index).Value
        Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString
        Me.txtQuantity.Text = Me.dgdPrice.Item("quantity", index).Value.ToString
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        On Error GoTo Err_named
        mStatusP = "Add"
        FreightChargeID = DefaultValue
        refreshFreight(True)


        Me.txtItems.Text = ""
        Me.txtCurrency.Text = ""

        Me.txtNotebuy.Text = ""
        Me.txtDebit.Text = ""

        Me.txtNoteban.Text = ""
        Me.txtCredit.Text = ""
        Me.txtRemarks.Text = ""

        Me.txtPOP.Text = ""
        'Me.txtUnit.Text = ""

        'Me.cmdOKP.Text = "Add"
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        On Error GoTo Errname
        Dim index As Integer
        Dim chk As Integer
        chk = Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.oTablePrice.Rows.Count > 0 Then
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
        refreshFreight(True)
        FreightChargeID = Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString
        Me.cboContainerType.Text = Me.dgdPrice.Item("CONTAINERTYPEP", index).Value.ToString
        Me.txtItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
        Me.txtCurrency.Text = Me.dgdPrice.Item("DataGridViewTextBoxColumn1", index).Value.ToString
        '--------------------
        Me.txtDebitTruocThue.Text = Me.dgdPrice.Item("debitTruocThue", index).Value.ToString.Trim
        Me.txtTaxDebit.Text = Me.dgdPrice.Item("TaxDebit", index).Value.ToString.Trim
        Me.txtNotebuy.Text = Me.dgdPrice.Item("notebuy", index).Value.ToString.Trim
        Me.txtDebit.Text = Me.dgdPrice.Item("priceban", index).Value.ToString
        '---------------------------------------------------------------------
        Me.txtCreditTruocThue.Text = Me.dgdPrice.Item("CreditTruocThue", index).Value.ToString.Trim
        Me.txtTaxCredit.Text = Me.dgdPrice.Item("TaxCredit", index).Value.ToString.Trim
        Me.txtNoteban.Text = Me.dgdPrice.Item("noteban", index).Value.ToString.Trim
        Me.txtCredit.Text = Me.dgdPrice.Item("pricebuy", index).Value.ToString
        '---------------------------------------------------------------------------------





        'Me.txttax.Text = Me.dgdPrice.Item("tax", index).Value.ToString
        Me.txtRemarks.Text = Me.dgdPrice.Item("remarks", index).Value.ToString
        Me.txtRemarksCredit.Text = Me.dgdPrice.Item("remarkscredit", index).Value
        Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString
        Me.txtQuantity.Text = Me.dgdPrice.Item("quantity", index).Value.ToString


        Exit Sub
Errname:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub ReFreshFreight(ByVal b As Boolean)
        On Error GoTo Err_named
        'Me.cboContainerType.Enabled = b
        Me.txtItems.Enabled = b
        Me.txtCurrency.Enabled = b

        'Me.txtUnit.Enabled = b

        Me.txtNotebuy.Enabled = b
        Me.txtDebit.Enabled = b
        Me.txtNoteban.Enabled = b
        Me.txtCredit.Enabled = b
        'Me.txttax.Enabled = b
        Me.cmdOKP.Enabled = b
        Me.txtNotebuy.Enabled = b
        Me.txtPOP.Enabled = b
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub QueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        'If Me.cboBillofLading.Items.Count = 0 Then
        '    Return
        'End If
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPrice()
        Else
            strQuery = MakeQueryPrice(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------

        Con.Open()
        If Not IsNothing(oTablePrice) Then
            oTablePrice.Clear()
        End If
        Me.dgdPrice.Columns.Item("FREIGHT_CHARGES_ID").Visible = False
        Adapter.Fill(ds, "PriceList")
        oTablePrice = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPrice.DataSource = ds.Tables("PriceList")
        If Me.dgdPrice.Enabled = False Then
            Me.dgdPrice.Enabled = True
        End If

        
       
        InsertAutoNumberToGrid(Me.dgdPrice)
        '--------------------
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Function MakeQueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed
        'BillID = "{" + BillID + "}"
        MakeQueryPrice = strPriceSelect

        MakeQueryPrice = MakeQueryPrice & " FROM FREIGHT_CHARGE_OB  "
        MakeQueryPrice = MakeQueryPrice & "WHERE ((FREIGHT_CHARGE_OB.BLh_Id = '" & mBILLOFLADING_HOUSEId & "') "

        MakeQueryPrice = MakeQueryPrice & "And ("
        MakeQueryPrice = MakeQueryPrice & " FREIGHT_CHARGE_OB.Continued = 1 "
        MakeQueryPrice = MakeQueryPrice & "))"
        If argCriteria <> "" Then
            MakeQueryPrice = MakeQueryPrice & argCriteria
        End If
        'MakeQueryPrice = MakeQueryPrice & strPriceOrder

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Dim chk As Integer
        chk = Me.dgdPrice.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
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
        'If Me.dgdDetailBillOfLading.RowCount > 0 Then
        '    index = Me.dgdDetailBillOfLading.CurrentRow.Index
        'End If
        QueryPrice(" ", index, )
    End Sub
    Sub QueryCurrency()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "CurrencyID"
        value = "Currency"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select CurrencyID,Currency From Currency where Continued=1 "
        'If Me.cboCompany.Items.Count = 0 Then
        loadDataToObject(Me.txtCurrency, strSQL, id, value)
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
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
        
        strMesg = "Delete the Detail of Price: " & Me.dgdPrice.Item("Items", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            strQuery = "Select * from FREIGHT_CHARGE_oB where FREIGHT_CHARGE_oB='" & Me.dgdPrice.Item("FREIGHT_CHARGES_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("continued").Value = 0
            rs.Update()

            'Me.dgdPrice.Rows(index).DefaultCellStyle.ForeColor = Color.White
            'Me.dgdPrice.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            rs.Close()


        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOKP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKP.Click
        On Error GoTo Err_Renamed
        If mStatusP = "Add" Or mStatusP = "Edit" Then
            

            If Len(Me.txtCurrency.Text) = 0 Then
                DisplayMessage(True, "The Currency is invalid. ")
                Me.txtCurrency.Focus()
                Exit Sub
            End If
            If Len(Me.txtDebit.Text) = 0 Then
                DisplayMessage(True, "The Price is invalid. ")
                Me.txtCurrency.Focus()
                Exit Sub
            End If
            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.dgdPrice.RowCount > 0 Then
                index = Me.dgdPrice.CurrentRow.Index()
            End If

            Dim indexBill As Integer
           

            indexBill = Me.dgdBillOfLading_House.CurrentRow.Index

            'If indexBill >= 0 Then
            '    Cargo_ID = Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString
            'Else
            '    'Cargo_ID = DefaultValue
            '    Exit Sub
            'End If
            'strQuery = "Select * from FREIGHT_CHARGE_oB where Items='" & Me.txtItems.Text.Trim & "'"
            'strQuery = strQuery & " and BLh_id='" & mBILLOFLADING_HOUSEId & "' And Continued=1 And Container_Type='" & Me.cboContainerType.Text.Trim & "'"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            'If Not rs.EOF And mStatusP = "Add" Then
            '    DisplayMessage(True, "This Item Had Added ")
            '    'Exit Sub
            'End If
            'rs.Close()
            strQuery = "Select * from FREIGHT_CHARGE_oB where FREIGHT_CHARGE_oB='" & FreightChargeID & "'And Continued=1 "
            ' strQuery = strQuery & " And BL_ID='" & BillID & "'"

            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


            With rs
                If mStatusP = "Add" Then
                    .AddNew()
                    .Fields("FREIGHT_CHARGE_oB").Value = NewId()
                    Dim temp As String

                    'temp = "{" & Trim(Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString) & "}"

                    '.Fields("CTN_ID").Value = "{" & Me.dgdDetailBillOfLading.Item("Container_ID", indexBill).Value.ToString & "}"
                    .Fields("BLh_ID").Value = "{" & mBILLOFLADING_HOUSEId & "}"

                End If

                .Fields("customeridCredit").Value = "{" + FindValueID(Me.txtNotebuy, Me.txtNotebuy.Text) + "}"
                .Fields("customeridDebit").Value = "{" + FindValueID(Me.txtNoteban, Me.txtNoteban.Text) + "}"

                .Fields("Items").Value = Me.txtItems.Text.Trim
                .Fields("Quantity").Value = Me.txtQuantity.Text.Trim

                .Fields("CONTAINER_TYPE").Value = Me.cboContainerType.Text
                .Fields("POP_code").Value = Me.txtPOP.Text
                '------------------------
                .Fields("pricebuytruocthue").Value = Me.txtCreditTruocThue.Text
                .Fields("Taxpricebuy").Value = Me.txtTaxCredit.Text
                .Fields("pricebuy").Value = Me.txtCredit.Text
                '------------------------

                .Fields("priceban").Value = Me.txtDebit.Text
                .Fields("pricebantruocthue").Value = Me.txtDebitTruocThue.Text
                .Fields("Taxpriceban").Value = Me.txtTaxDebit.Text
                '-----------------------

                .Fields("notebuy").Value = Me.txtNotebuy.Text
                .Fields("noteban").Value = Me.txtNoteban.Text
                ' .Fields("tax").Value = Me.txttax.Text

                .Fields("remarks").Value = Me.txtRemarks.Text
                .Fields("remarkscredit").Value = Me.txtRemarksCredit.Text
                .Fields("Currency").Value = Me.txtCurrency.Text

                .Update()
            End With
            rs.Close()
            '-----------------

            'mStatusP = "Normal"
            refreshFreight(False)
            Me.dgdPrice.Enabled = True
            mStatusP = "Normal"
            Me.cmdOKP.Enabled = False
            QueryPrice()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub cmdCancelFreight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelFreight.Click
        mStatusP = "Normal"
        refreshFreight(False)
        Me.cmdOKP.Enabled = False
    End Sub

    Private Sub txtDebitTruocThue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDebitTruocThue.TextChanged
        Try
            Me.txtDebit.Text = FormatNumber(CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDebitTruocThue.Text) + CDbl(Me.txtTaxDebit.Text) * (CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDebitTruocThue.Text)) / 100, 3)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTaxDebit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxDebit.TextChanged
        Try
            Me.txtDebit.Text = FormatNumber(CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDebitTruocThue.Text) + CDbl(Me.txtTaxDebit.Text) * (CDbl(Me.txtQuantity.Text) * CDbl(Me.txtDebitTruocThue.Text)) / 100, 3)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCreditTruocThue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCreditTruocThue.TextChanged
        Try
            Me.txtCredit.Text = FormatNumber(CDbl(Me.txtQuantity.Text) * CDbl(Me.txtCreditTruocThue.Text) + CDbl(Me.txtTaxCredit.Text) * (CDbl(Me.txtQuantity.Text) * CDbl(Me.txtCreditTruocThue.Text)) / 100, 3) 'CStr(CDbl(Me.txtCreditTruocThue.Text) + CDbl(Me.txtTaxCredit.Text))
        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTaxCredit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTaxCredit.TextChanged
        Try
            Me.txtCredit.Text = FormatNumber(CDbl(Me.txtQuantity.Text) * CDbl(Me.txtCreditTruocThue.Text) + CDbl(Me.txtTaxCredit.Text) * (CDbl(Me.txtQuantity.Text) * CDbl(Me.txtCreditTruocThue.Text)) / 100, 3)
        Catch ex As Exception

        End Try
    End Sub
    Sub QueryNote()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Customer_ID"
        value = "Company"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Customer_ID,Company From Customer where Continued=1 Order By Company asc"
        'If Me.cboCompany.Items.Count = 0 Then
        loadDataToObject(Me.txtNoteban, strSQL, id, value)
        loadDataToObject(Me.txtNotebuy, strSQL, id, value)
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub QueryPortPOP(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_Code"
        value = "Port"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Port_Code,Port + ' - ' + country  as Port From Port where Continued=1 Order By Port"
        loadDataToObject(combo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SunToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        Dim chk As Integer
        chk = Me.dgdBillOfLading_House.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If chk = 0 Then
            DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
            Return
        End If
        If Me.dgdBillOfLading_House.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading_House.CurrentRow.Index
            gBillOfLadingHouseRpt = Me.dgdBillOfLading_House.Item("BLH_ID", index).Value.ToString
            gBillHouseNoRpt = Me.dgdBillOfLading_House.Item("BLH_NO", index).Value.ToString
            frmRptHouseBill.RptName = "Data"


            VB6.ShowForm(frmRPTBillSunTrans, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DateTimePicker4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker4.ValueChanged

    End Sub
End Class