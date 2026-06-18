Imports System.IO

Public Class frmMasterBL_Cargo


    Dim TextName As Object
    Dim update As Boolean
    Dim PartyID As String
    Dim rsBillOfLadingList As New ADODB.Recordset
    Dim mStatus, mStatusP, mFilter, mPrice_ID, mStatusR, mHouseCOLOstatus, mHouseCOLOID As String
    Dim POL_ID, POD_ID, DEL_ID, POR_ID, DEST_ID, POI_ID, PortFrom_ID, PortTo_ID As String
    Dim mBL_ClauseID As String = DefaultValue
    Public Checking As Integer = 0
    Dim ShipperID, ConsigneeID, NotifyID, Notify2ID, Notify3ID, PREVESSELID, PLACEOFRECEIPTID, LOADPORTID As String
    Dim TRADECODEID, PORTOFDISCHARGEID, PLACEOFDELIVERYID, PLACEOFDESTINATIONID As String
    Dim VESSELID, PLACEOFBLISSUEID, PORTOFLOADINGID, BillID, ROUTINGID As String

    Public blnUpdated As Boolean
    Public mBillOfLadingId, mChargeID As String

    '    '------------------
    Public oTableCustomerInfo As DataTable
    Public dsCustomerInfo As New DataSet
    Dim dst As New DataSet
    Public oTablePrice, oTableFreightCharge As DataTable
    Public dsPrice As New DataSet
    Public oTable As DataTable
    Public ds As New DataSet
    '+ Shipper.SHIPPER_2 + Shipper.SHIPPER_3 + Shipper.SHIPPER_4 + Shipper.SHIPPER_5 + Shipper.SHIPPER_6
    '+ Consignee.CONSIGNEE_2 + Consignee.CONSIGNEE_3 + Consignee.CONSIGNEE_4 + Consignee.CONSIGNEE_5 + Consignee.CONSIGNEE_6
    '+ Notify.NOTIFY_2 + Notify.NOTIFY_3 + Notify.NOTIFY_4 + Notify.NOTIFY_5 + Notify.NOTIFY_6
    Const strBillOfLadingSelect As String = " SELECT BillOfLading.BL_ID as BL_ID,BillOfLading.Telex, " & _
        "BillOfLading.BL_NO as BL_NO,BillofLading.CANVASSERCODE,Payer,Checking, " & _
        "BillOfLading.ContainerOutBoundNotifyID as ContainerOutBoundNotifyID," & _
        "BillOfLading.SHIPPER_ID AS SHIPPER_ID,BillOfLading.BL_ClauseID,BL_ClauseCode,BL_ClauseText," & _
        "Shipper.SHIPPER_1  as ShipperName, " & _
        "BillOfLading.CONSIGNEE_ID AS CONSIGNEE_ID , " & _
        "Consignee.CONSIGNEE_1  as ConsigneeName, " & _
        "BillOfLading.Notify_Id AS Notify_Id, " & _
        "Notify.NOTIFY_1  as NotifyName, BillOfLading.NOTIFY2_ID ,Notify2.NOTIFY_1  as Notify2Name,BillOfLading.NOTIFY3_ID,Notify3.NOTIFY_1  as Notify3Name ,Party.PartyCode,Party.PartyType," & _
        "Party.Party_ID as PartyID,PartyAddress1,PartyAddress2,PartyAddress3,PartyAddress4,PartyAddress5," & _
        "Vessel.Vessel as pre_Vessel," & _
        "SailingSchedule.VoyNo as Pre_VoyNo,PreightCharges,ToTalContainer," & _
        "ContainerOutboundNotify.CustomsLiquiDate as CustomClean," & _
        "BillOfLading.PLACE_OF_RECEIPT_ID AS PLACE_OF_RECEIPT_ID,  " & _
        "BillOfLading.PLACE_OF_RECEIPT_CODE,  " & _
        "PLACE_OF_RECEIPT_NAME, " & _
        "BL_CY_CFS_ITEM,PREPAID_OR_COLLECT,LOAD_DATE,QUARANTINE_CODING,DATE_OF_ISSUE,CURRENCY, " & _
        "EXCHANGE_RATE,MF_FILING_TYPE ,NVOCC_MASTER_BL_NO,SCAC_CODE,REVENUETON,DESCRIPTIONFORSHIPPER, " & _
        "BillOfLading.TRADE_CODE_ID AS TRADE_CODE_ID, " & _
        "BillOfLading.TRADE_CODE, " & _
        "BillOfLading.SERVICECONTRACT,PREPAIDAT, " & _
        "BillOfLading.PORT_OF_LOADING_ID AS PORT_OF_LOADING_ID, " & _
        "BillOfLading.PORT_OF_LOADING_CODE AS PORT_OF_LOADING_CODE," & _
        "BillOfLading.PORT_OF_LOADING_NAME AS PORT_OF_LOADING, " & _
        "BL_OTHER_REF,Billoflading.TOTALPREPAID_IN as TOTALPREPAID_IN, " & _
        "BL_TYPE, " & _
        "PAYABLE_AT," & _
        "ContainerOutBoundNotify.BookingNo as BookingNo," & _
        "PAYER_CODE,ContainerOutBoundNotify.SALENAME as SaleName, " & _
        "NO_OF_COPY_BL, " & _
        "NO_OF_ORIGINAL_BL, " & _
        "CUSTOMS_CLEARED_PLACE, " & _
        "SLOT_SHARE, " & _
        "US_SERVICE_MODE, " & _
        "BillOfLading.PORT_OF_DISCHARGE_ID AS PORT_OF_DISCHARGE_ID, " & _
        "PORT_OF_DISCHARGE_CODE,PORT_OF_DISCHARGE_NAME,  " & _
        "BillOfLading.PLACE_OF_DELIVERY_ID AS PLACE_OF_DELIVERY_ID, " & _
        "PLACE_OF_DELIVERY_CODE,PLACE_OF_DELIVERY_NAME, " & _
        "BillOfLading.PLACE_OF_DESTINATION_ID AS PLACE_OF_DESTINATION_ID, " & _
        "PLACE_OF_DESTINATION_CODE,PLACE_OF_DESTINATION_NAME,  " & _
        "BillOfLading.PLACE_OF_BL_ISSUE_ID AS PLACE_OF_BL_ISSUE_ID, " & _
        "PLACE_OF_BL_ISSUE_CODE,PLACE_OF_BL_ISSUE_NAME, " & _
        "TRANSFER_PORT1,TRANSFER_PORT2,TRANSFER_PORT3,TRANSFER_PORT4, " & _
        "BillOfLading.WEEKOFYEAR," & _
        "UserList.Name as CreativeUser, Note," & _
        "CreativeDate, notShowDes,VIP,Commission,BillOfLading.TAX," & _
        "BillOfLading.Editable as Editable, " & _
        "BillOfLading.Continued as Continued, " & _
        "BillOfLading.Approve as Approve, " & _
        "BillOfLading.UserId as UserId, " & _
        "BillOfLading.Updatetime as Updatetime "

    Const strBillOfLadingOrder1 As String = _
          " ORDER BY BillOfLading.BL_NO  Desc "
    Const strBillOfLadingOrder2 As String = _
        " ORDER BY BillOfLading.UpdateTime Desc "

    Const strPriceSelect As String = "SELECT DISTINCT BillofLading.BL_ID as BL_IDP,BillofLading.BL_NO as BL_NOP," & _
    "Charge.Charge_Code,Charge.Charge_ID,Price_ID, Prepaid_collect," & _
    "PriceBillMaster.Currency as Currency, POP,Quantity,IG_Code," & _
    "UnitPrice, " & _
                "PriceBillMaster.Continued, " & _
            "PriceBillMaster.Editable, " & _
           "PriceBillMaster.Approve, " & _
           "PriceBillMaster.UserId, " & _
           "PriceBillMaster.Updatetime "
    Const strPriceOrder As String = _
           " ORDER BY PriceBillMaster.UpdateTime Desc "


    Const strFreightCharge As String = "Select DISTINCT Charge.Charge_Code as Item," & _
   "FREIGHT_CHARGE_Master.CURRENCY as CURRENCY, " & _
   "FREIGHT_CHARGE_Master.Container_Type as ContainerType,Unit," & _
   "FREIGHT_CHARGE_Master.PREPAID_COLLECT,PAYER_CODE,POP," & _
   " FREIGHT_CHARGE_Master.AMOUNT as UnitPrice  "

    Const strCustomerInfo As String = "Select Shipper.Shipper_1, Shipper_Code," & _
    "Shipper.Shipper_2 , Shipper.Shipper_3,Shipper.Shipper_4," & _
        "Shipper.Shipper_5 , " & _
        "Shipper.Shipper_6 ,Shipper.Remarks as RemarksShipper ," & _
        "Party.Party_ID as PartyID,PartyCode,PartyType,PartyAddress1,PartyAddress2,PartyAddress3,PartyAddress4,PartyAddress5, " & _
    "Consignee.Consignee_1,Consignee_Code, " & _
        "Consignee.Consignee_2 , Consignee.Consignee_3,Consignee.Consignee_4," & _
        "Consignee.Consignee_5 , " & _
        "Consignee.Consignee_6 , Consignee.Remarks as RemarksConsignee ," & _
    "Notify.Notify_1 , Notify_Code," & _
        "Notify.Notify_2, Notify.Notify_3,Notify.Notify_4," & _
        "Notify.Notify_5, " & _
        "Notify.Notify_6 , Notify.Remarks as RemarksNotify "

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
        strQuery = "select * from Routing_Master Where BL_ID='" & Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString & "' And Continued=1"

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

    Sub QueryTradeCode(ByRef Cbo As Object, Optional ByVal id As String = "Market_Id", Optional ByVal value As String = "marketCode", Optional ByVal rang As String = "")
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select Market_Id,MarketCode From Market where Continued=1 "
        loadDataToObject(Cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryVessel(ByRef Cbo As Object, Optional ByVal id As String = "vessel_ID", Optional ByVal value As String = "Vessel_Code", Optional ByVal rang As String = "")
        On Error GoTo Err_Renamed
        Dim strSQL As String
        strSQL = "Select Vessel_Code,Vessel.Vessel_ID From Vessel LEFT JOIN CONTAINEROUTBOUNDNOTIFY "
        strSQL = strSQL & " On CONTAINEROUTBOUNDNOTIFY.Vessel_ID=Vessel.Vessel_ID where CONTAINEROUTBOUNDNOTIFY.Continued=1 "
        loadDataToObject(Cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Sub QueryBLOfLading()
    '        On Error GoTo Err_Renamed
    '        Dim id As String = "BL_ID"
    '        Dim value As String = "BL_No"
    '        Dim strSQL As String
    '        strSQL = "Select BL_ID,BL_No From BillOfLading where Continued=1 "
    '        loadDataToObject(Me.cboBLOtherref, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = strBillOfLadingSelect
        MakeQueryBillOfLading = MakeQueryBillOfLading & ",(select Count(*) From Cargo where Cargo.BL_ID=BillOflading.BL_ID And Cargo.continued=1) As QuantityOfContainer "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM ((((((((((((BillOfLading left join Shipper on BillOfLading.Shipper_Id=Shipper.Shipper_Id ) left join Consignee on BillOflading.Consignee_Id=Consignee.Consignee_Id ) left join Notify on BillOfLading.Notify_Id=Notify.Notify_Id) left join ContainerOutBoundNotify ON BILLOFLADING.ContainerOutBoundNotifyID=ContainerOutBoundNotify.ContainerOutBoundNotifyID ) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN Party On Party.BL_ID=BillOfLading.BL_ID )"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN Notify as Notify2 On BillOflading.Notify2_ID=Notify2.Notify_ID) LEFT JOIN Notify as Notify3 On Notify3.Notify_ID=BillOflading.Notify3_ID)"
        MakeQueryBillOfLading = MakeQueryBillOfLading & "  left JOIN Market ON BILLOFLADING.TRADE_CODE_ID=Market.Market_ID ) left JOIN SailingSchedule on ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID ) left join Vessel on SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " left JOIN UserList on BillOfLading.CreativeUser=UserList.Usr) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN BL_Clause On BL_Clause.BL_ClauseID=BillOfLading.BL_ClauseID) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE "


        MakeQueryBillOfLading = MakeQueryBillOfLading & "BillOfLading.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " "
        If argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If

        'MakeQueryBillOfLading = MakeQueryBillOfLading & strBillOfLadingOrder2


        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub QueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
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
        If Not IsNothing(oTable) Then
            oTable.Clear()
        End If
        Adapter.Fill(ds, "BillOfLadingList")

        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdBillOfLading.DataSource = ds.Tables("BillOfLadingList")
        If Me.dgdBillOfLading.Enabled = False Then
            Me.dgdBillOfLading.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdBillOfLading.Columns.Item("BL_No").ToolTipText = "Hiện có:" + CStr(Me.dgdBillOfLading.RowCount()) + " Bills."
        End If
        If Me.dgdBillOfLading.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdBillOfLading.Rows.Count And Me.dgdBillOfLading.Rows.Count > 0 Then
            Me.dgdBillOfLading.Rows(location).Selected = True
            Me.dgdBillOfLading.CurrentCell = Me.dgdBillOfLading.Rows(location).Cells("BL_NO")
        End If
        '--------------------
        'dem tong so container
        Dim CountContainer As Integer = 0
        For i As Integer = 0 To Me.dgdBillOfLading.Rows.Count - 1
            CountContainer += Me.dgdBillOfLading.Item("QuantityOfContainer", i).Value
        Next
        Me.dgdBillOfLading.Columns("QuantityOfContainer").HeaderText = "Quantity Of Container " & "(" & CountContainer & " Containers)"
        Me.dgdBillOfLading.Columns("QuantityOfContainer").Width = 152
        InsertAutoNumberToGrid(Me.dgdBillOfLading)
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
            temp &= dt.Rows(0).Item("Shipper_Code").ToString & " - " & dt.Rows(0).Item("Shipper_1").ToString & chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Shipper_2").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Shipper_3").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Shipper_4").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Shipper_5").ToString & Chr(13) & Chr(10)
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
            temp &= dt.Rows(0).Item("Consignee_Code").ToString & " - " & dt.Rows(0).Item("Consignee_1").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Consignee_2").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Consignee_3").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Consignee_4").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Consignee_5").ToString & Chr(13) & Chr(10)
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
            temp &= dt.Rows(0).Item("Notify_Code").ToString & " - " & dt.Rows(0).Item("Notify_1").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Notify_2").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Notify_3").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Notify_4").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Notify_5").ToString & Chr(13) & Chr(10)
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
            temp &= dt.Rows(0).Item("Notify_Code").ToString & " - " & dt.Rows(0).Item("Notify_1").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Notify_2").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Notify_3").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Notify_4").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Notify_5").ToString & Chr(13) & Chr(10)
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
            temp &= dt.Rows(0).Item("Notify_Code").ToString & " - " & dt.Rows(0).Item("Notify_1").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Notify_2").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Notify_3").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Notify_4").ToString & Chr(13) & Chr(10) & dt.Rows(0).Item("Notify_5").ToString & Chr(13) & Chr(10)
            temp &= dt.Rows(0).Item("Remarks").ToString
        End If
        Me.txtNotify3.Text = temp
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    '    Public Sub QueryShipperRefesh()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Shipper_Id"
    '        value = "Shipper"
    '        'strSQL = "Select ShipperId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Shipper where Continued=1 Order By Code desc"
    '        strSQL = "Select SHipper_ID,Shipper_Code,Shipper_1 as Shipper From Shipper where Continued=1  Order By Shipper ASC"
    '        loadDataToObject(Me.txtShipper, strSQL, id, value)
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
    '        strSQL = "Select Consignee_code,CONSIGNEE_ID,Consignee_1 as Consignee From Consignee where Continued=1 Order By Consignee ASC"
    '        If Me.txtConsignee.Items.Count = 0 Or mStatus <> "Normal" Then
    '            loadDataToObject(Me.txtConsignee, strSQL, id, value)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Public Sub QueryConsigneeRefesh()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Consignee_Id"
    '        value = "Consignee"
    '        'strSQL = "Select ConsigneeId,'SC-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Consignee where Continued=1 Order By Code Desc"
    '        strSQL = "Select Consignee_code,CONSIGNEE_ID,Consignee_1 as Consignee From Consignee where Continued=1 Order By Consignee ASC"
    '        loadDataToObject(Me.txtConsignee, strSQL, id, value)
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
    '        strSQL = "Select Notify_Id,Notify_Code,Notify_1 as Notify  From Notify where Continued=1  Order By Notify ASC"
    '        If cbo.Items.Count = 0 Or mStatus <> "Normal" Then
    '            loadDataToObject(cbo, strSQL, id, value)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Public Sub QueryNotifyRefesh()
    '        On Error GoTo Err_Renamed
    '        Dim id, value, strSQL As String
    '        id = "Notify_Id"
    '        value = "Notify"
    '        'strSQL = "Select NotifyId,'SN-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Notify where Continued=1 Order By Code Desc"
    '        strSQL = "Select Notify_Id,Notify_Code,Notify_1 as Notify  From Notify where Continued=1  Order By Notify ASC"
    '        loadDataToObject(Me.txtNotify, strSQL, id, value)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
#End Region

#Region "Sự Kiện Form"

    Private Sub frmListBaseMaster_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'objUserSetting.SetCParm("frmListBaseMaster.txtDescriptionOfContentsForShipper", Me.txtDescriptionOfContentsForShipper.Text)
        '-------------
        'objUserSetting.SetCParm("frmListBaseMaster.txtQuaRanTineCode", Me.txtQuaRanTineCode.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtSealNo", Me.cboNotify.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtMF_FilingType", Me.txtMF_FilingType.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtNVOCC_MasterBL_No", Me.txtNVOCC_MasterBL_No.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtTotalprepaid", Me.txtTotalprepaid.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtSaleName", Me.txtSaleName.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtSCAC", Me.txtSCAC.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtRevenueTons", Me.txtRevenueTons.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtRate", Me.txtRate.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtBLOtherref", Me.txtBLOtherref.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtBLType", Me.txtBLType.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtNoOfOrigineBL", Me.txtNoOfOrigineBL.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtPayerCode", Me.txtPayerCode.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtCustoms", Me.txtCustoms.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtBL_CY_CFS_Item", Me.txtBL_CY_CFS_Item.Text)

        ''''''''''''''''''''''''''----------------

        'objUserSetting.SetCParm("frmListBaseMaster.cboRepaid_Collect", Me.cboRepaid_Collect.Text)
        ''-------------
        'objUserSetting.SetCParm("frmListBaseMaster.txtPrepaidAt", Me.txtPrepaidAt.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtPayableAt", Me.txtPayableAt.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtNoOfCopyBL", Me.txtNoOfCopyBL.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.cboSlotshare", Me.cboSlotshare.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtIMOPAGE", Me.txtUSServiceMode.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtTransport1", Me.txtTransport1.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtTransport2", Me.txtTransport2.Text)
        'objUserSetting.SetCParm("frmListBaseMaster.txtTransport3", Me.txtTransport3.Text)

        'objUserSetting.SetCParm("frmListBaseMaster.txtTransport4", Me.txtTransport4.Text)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayCollect", Me.smnuDisplayCollect.Checked)
        'objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayBillOfLading_House", Me.smnuDisplayBillOfLading_House.Checked)

        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayCreativeDate", Me.smnuDisplayCreativeDate.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayCreativeUser", Me.smnuDisplayCreativeUser.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayDateOfIssue", Me.smnuDisplayDateOfIssue.Checked)

        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayDescriptionOfContentsForShipper", Me.smnuDisplayDescriptionOfContentsForShipper.Checked)

        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayFinalDestination", Me.smnuDisplayFinalDestination.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayNoOfOrigineBL", Me.smnuDisplayNoOfOrigineBL.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayNotifyName", Me.smnuDisplayNotifyName.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayOceanVessel", Me.smnuDisplayOceanVessel.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPayableAt", Me.smnuDisplayPayableAt.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPlaceOfDelivery", Me.smnuDisplayPlaceOfDelivery.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPlaceOfIssue", Me.smnuDisplayPlaceOfIssue.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPlaceOfReceipt", Me.smnuDisplayPlaceOfReceipt.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPortOfDischarge", Me.smnuDisplayPortOfDischarge.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPortOfLoading", Me.smnuDisplayPortOfLoading.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPreCarriage", Me.smnuDisplayPreCarriage.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPreightCharges", Me.smnuDisplayPreightCharges.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPrepaid", Me.smnuDisplayPrepaid.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayPrepaidAt", Me.smnuDisplayPrepaidAt.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayRate", Me.smnuDisplayRate.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayRevenueTons", Me.smnuDisplayRevenueTons.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplaySaleName", Me.smnuDisplaySaleName.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayServiceContract", Me.smnuDisplayServiceContract.Checked)

        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayTotalNoContainerOrPackages", Me.smnuDisplayTotalNoContainerOrPackages.Checked)
        objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayTotalPrepaidIn", Me.smnuDisplayTotalPrepaidIn.Checked)
        'objUserSetting.SetBParm("frmListBaseMaster.smnuDisplayTotalPakages", Me.smnuDisplayt.Checked)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListBaseMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        Me.tagInformationCustomer.Visible = False
        Me.fraUpdate.Visible = False
        Me.dgdBillOfLading.Enabled = True
        SetDefaultGrid(Me.dgdBillOfLading, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdHouseCOLO, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdPrice, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdRouting, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.grpParty.Enabled = False
        BillID = DefaultValue
        PartyID = DefaultValue
        mStatus = "Normal"
        mStatusP = "Normal"
        mStatusR = "Normal"
        mHouseCOLOstatus = "Normal"
        blnUpdated = False
        mBillOfLadingId = DefaultValue
        mHouseCOLOID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        LoadComboFind(Me.cboFind, Me.dgdBillOfLading)
        ' tạm che
        'QueryBillOfLading()
        GetCurrency(Me.cboCurrency)
        GetCurrency(Me.cboCurrencyP)

        ShipperID = DefaultValue.Replace("{", "").Replace("}", "") 'bo di hai dau  { va }
        ConsigneeID = DefaultValue.Replace("{", "").Replace("}", "")
        NotifyID = DefaultValue.Replace("{", "").Replace("}", "")
        Notify2ID = DefaultValue.Replace("{", "").Replace("}", "")
        Notify3ID = DefaultValue.Replace("{", "").Replace("}", "")
        'QueryShipper()
        'QueryConsignee()
        'QueryNotify(cboNotify)
        'QueryNotify(cboNotify2)
        'QueryNotify(cboNotify3)

        'Dim cbo As Object
        ''cbo = Me.cboNotify

        'cbo = Me.cboPlofReceiptCode
        'If Me.cboPlofReceiptCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If
        'cbo = Me.cboPortOfLoading
        'If Me.cboPortOfLoading.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If
        'cbo = Me.cboPortOfDisCharge
        'If Me.cboPortOfDisCharge.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.cboPortOfDelivery
        'If Me.cboPortOfDelivery.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.cboPortOfDestination
        'If Me.cboPortOfDestination.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.cboPlaceCode
        'If Me.cboPlaceCode.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.cboPortfrom
        'If Me.cboPortfrom.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.cboPortTo
        'If Me.cboPortTo.Items.Count = 0 Then
        '    Queryport(cbo)
        'End If

        'cbo = Me.txtTradeCode
        'QueryTradeCode(cbo)
        QueryBookingNo()

        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.txtBillOfLading.Text = objUserSetting.GetCParm("frmListBaseMaster.txtBILLOFLADING")

        '        '--------------
        'Me.cboShipper.Text = objUserSetting.GetCParm("frmListBaseMaster.cboShipper")
        'Me.cboConsignee.Text = objUserSetting.GetCParm("frmListBaseMaster.cboConsignee")
        'Me.cboNotify.Text = objUserSetting.GetCParm("frmListBaseMaster.cboNotify")
        'Me.txtPreVessel.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPreVessel")
        'Me.txtPreVesselNo.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPreVesselNo")

        'Me.txtDescriptionOfContentsForShipper.Text = objUserSetting.GetCParm("frmListBaseMaster.txtDescriptionOfContentsForShipper")
        'Me.txtTotalNoContainersOrPackages.Text = objUserSetting.GetCParm("frmListBaseMaster.txtTotalNoContainersOrPackages")

        'Me.txtPlaceOfreceipt.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPlaceOfreceipt")
        'Me.txtPortOfDischarge.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPortOfDischarge")

        'Me.txtPortOfLoading.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPortOfLoading")
        'Me.txtPlaceofdestination.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPlaceofdestination")
        'Me.txtSaleName.Text = objUserSetting.GetCParm("frmListBaseMaster.txtSaleName")
        'Me.txtPlaceOfDelivery.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPlaceOfDelivery")
        'Me.txtRevenueTons.Text = objUserSetting.GetCParm("frmListBaseMaster.txtRevenueTons")

        'Me.txtRate.Text = objUserSetting.GetCParm("frmListBaseMaster.txtRate")


        'Me.txtPrepaidAt.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPrepaidAt")
        'Me.txtPayableAt.Text = objUserSetting.GetCParm("frmListBaseMaster.txtPayableAt")

        'Me.txtTotalprepaid.Text = objUserSetting.GetCParm("frmListBaseMaster.txtTotalprepaid")
        ' Me.txtNoOfOrigineBL.Text = objUserSetting.GetCParm("frmListBaseMaster.txtNoOfOrigineBL")

        Me.smnuDisplayNotifyName.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayNotifyName")

        Me.smnuDisplayPreCarriage.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPreCarriage")
        Me.smnuDisplayPlaceOfReceipt.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPlaceOfReceipt")
        Me.smnuDisplayOceanVessel.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayOceanVessel")
        Me.smnuDisplayVoyNo.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayVoyNo")
        Me.smnuDisplayPortOfLoading.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPortOfLoading")

        Me.smnuDisplayPortOfDischarge.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPortOfDischarge")
        Me.smnuDisplayPlaceOfDelivery.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPlaceOfDelivery")
        Me.smnuDisplayFinalDestination.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayFinalDestination")
        Me.smnuDisplayDescriptionOfContentsForShipper.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayDescriptionOfContentsForShipper")
        Me.smnuDisplayTotalNoContainerOrPackages.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayTotalNoContainerOrPackages")

        Me.smnuDisplayPreightCharges.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPreightCharges")
        Me.smnuDisplayRevenueTons.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayRevenueTons")
        Me.smnuDisplayRate.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayRate")
        Me.smnuDisplayPrepaid.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPrepaid")
        Me.smnuDisplayCollect.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayCollect")

        Me.smnuDisplayPrepaidAt.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPrepaidAt")

        Me.smnuDisplayPayableAt.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPayableAt")
        Me.smnuDisplayPlaceOfIssue.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayPlaceOfIssue")
        Me.smnuDisplayDateOfIssue.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayDateOfIssue")
        Me.smnuDisplayTotalPrepaidIn.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayTotalPrepaidIn")

        Me.smnuDisplayNoOfOrigineBL.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayNoOfOrigineBL")
        Me.smnuDisplayCreativeUser.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayCreativeUser")
        Me.smnuDisplayCreativeDate.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayCreativeDate")
        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayApprove")
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplayUpdateTime")
        Me.smnuDisplaySaleName.Checked = objUserSetting.GetBParm("frmListBaseMaster.smnuDisplaySaleName")

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        SetMenu(True)
        UpdateFrame()
        ReFormat()
        Me.Cursor = System.Windows.Forms.Cursors.Default
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
            Me.Text = "Bill Of Lading (Base)"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Bill Of Lading (Base)-> Making..."
        End If

    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.smnuDelete.Enabled = argVisible
        Me.smnuEdit.Enabled = argVisible
        Me.smnuDisplay.Enabled = argVisible
        Me.smnuExit.Enabled = argVisible
        Me.smnuPrint.Enabled = argVisible
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Function QueryPayerNote(ByVal BookingID As String) As String
        Try
            Dim SQL As String
            SQL = "Select Note From FreightSale Where ContainerBoundNotifyID='" & BookingID & "' and Continued=1"
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
    Sub QueryCustomerPayer()
        Try
            Dim SQL As String
            SQL = "Select Company From Customer Where ApprovePayer=1 And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt Is Nothing Then
                Return
            End If
            Me.cboApprovePayerCustomer.DisplayMember = "Company"
            Me.cboApprovePayerCustomer.ValueMember = "Company"
            Me.cboApprovePayerCustomer.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Function MakeQueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14) As String
        On Error GoTo Err_Renamed

        MakeQueryPrice = strPriceSelect

        MakeQueryPrice = MakeQueryPrice & " FROM ((PriceBillMaster LEFT JOIN BillOfLading on PriceBillMaster.BL_ID=BillOfLading.BL_ID)  "
        MakeQueryPrice = MakeQueryPrice & "LEFT JOIN Charge on PriceBillMaster.Charge_ID=Charge.Charge_ID) "
        MakeQueryPrice = MakeQueryPrice & "Where PriceBillMaster.BL_ID='" & Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString & "'"
        MakeQueryPrice = MakeQueryPrice & " and PriceBillMaster.Continued = 1 "
        MakeQueryPrice = MakeQueryPrice & strPriceOrder

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Sub QueryBookingNo()
        On Error GoTo ERR_NAMED
        Dim id As String = "ContainerOutBoundNotifyId"
        Dim value As String = "BookingNo"
        Dim strQuery As String = "Select ContainerOutBoundNotifyId,BookingNo from CONTAINEROUTBOUNDNOTIFY where CONTINUED=1  order by Bookingno "
        loadDataToObject(Me.cboBookingNo, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Sub QueryItems()
        On Error GoTo ERR_NAMED
        Dim id As String = "CHARGE_ID"
        Dim value As String = "CHARGE_CODE"
        Dim strQuery As String = "Select CHARGE_ID,CHARGE_CODE from CHARGE where CONTINUED=1 Order by Charge_code"
        loadDataToObject(Me.cboItems, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub QueryPrice(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
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
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTablePrice) Then
            oTablePrice.Clear()
        End If
        Adapter.Fill(dsPrice, "PriceList")
        oTablePrice = dsPrice.Tables(0)
        'hien thi ra grid 
        Me.dgdPrice.DataSource = dsPrice.Tables("PriceList")
        If Me.dgdPrice.Enabled = False Then
            Me.dgdPrice.Enabled = True
        End If
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdPrice.Rows.Count And Me.dgdPrice.Rows.Count > 0 Then
            Me.dgdPrice.Rows(location).Selected = True
        End If
        Me.dgdPrice.Columns.Item("BL_IDP").Visible = False
        Me.dgdPrice.Columns.Item("PRICE_ID").Visible = False
        '--------------------
        'Me.Cursor = System.Windows.Forms.Cursors.Default
        'If oTablePrice.Rows.Count > 0 Then
        '    Me.dgdPrice.Columns.Item("BillOfLadingId").ToolTipText = "Hiện có:" + CStr(Me.dgdPrice.RowCount()) + " Prices."
        'End If
        InsertAutoNumberToGrid(Me.dgdPrice)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < 705 Or Me.Height >= 705) Then
        '    Me.Height = 732
        'End If
        'If (Me.Width < 910 Or Me.Width > 910) Then
        '    Me.Width = 910
        'End If

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.tagInformationCustomer.Width = (Me.Width - 50)
        Me.dgdBillOfLading.Width = (Me.Width - 25)
        'Me.dgdRouting.Width = Me.dgdBillOfLading.Width - 50

        'If Me.Width > 610 Then
        Me.dgdBillOfLading.Height = Me.Height - IIf(Me.fraUpdate.Visible, Me.fraUpdate.Height + 105, 125) '> 7000
        'Else
        '    Me.dgdBillOfLading.Height = Me.Height - 110 - IIf(Me.fraBillOfLadingSheet.Visible, Me.fraBillOfLadingSheet.Height + 5, 40) ' < 7000
        'End If
        'Me.fraBillOfLadingSheet.Width = (Me.Width - 30)
        Me.fraUpdate.Top = Me.dgdBillOfLading.Bottom + 10
        'Me.fraUpdate.Height = Me.Bottom - Me.fraUpdate.Top - 100
        Me.fraUpdate.Width = (Me.Width - 25)
        'Me.tagInformationCustomer.Top = Me.dgdBillOfLading.Height + Me.dgdBillOfLading.Top '+ 100

        '----- tagCustomer
        'Me.cboShipper.Width = Me.Width / 3
        'Me.txtShipper.Width = Me.cboShipper.Width
        'Me.cboConsignee.Width = Me.cboShipper.Width
        'Me.txtConsignee.Width = Me.cboShipper.Width
        'Me.lbldescriptionShipper.Left = Me.cboShipper.Left + Me.cboShipper.Width + 10

        'Me.txtDescriptionOfContentsForShipper.Width = Me.tagInformationCustomer.Width - Me.lbldescriptionShipper.Right - 50
        'Me.txtDescriptionOfContentsForShipper.Left = Me.lbldescriptionShipper.Left + Me.lbldescriptionShipper.Width + 5

        'Me.txtNote.Left = Me.txtDescriptionOfContentsForShipper.Left
        'Me.txtNote.Width = Me.txtDescriptionOfContentsForShipper.Width

        'Me.cboNotify.Left = Me.txtDescriptionOfContentsForShipper.Left
        'Me.txtNotify.Left = Me.txtDescriptionOfContentsForShipper.Left
        'Me.lblNotify.Left = Me.txtNotify.Left - Me.lblNotify.Width - 5
        'Me.cboNotify.Width = Me.txtDescriptionOfContentsForShipper.Width
        'Me.txtNotify.Width = Me.cboNotify.Width


        'Me.chkSameAsConsignee.Left = Me.txtNotify.Left
        'Me.chkSameAsShipper.Left = Me.chkSameAsConsignee.Left + Me.chkSameAsConsignee.Width + 10
        'Me.txtBillOfLadingId.Left = 3 * Me.tagInformationCustomer.Width / 4 + 30
        'Me.cmdOK.Left = Me.tagInformationCustomer.Right - Me.cmdOK.Width
        'Me.cmdCancel.Left = Me.cmdOK.Left - Me.cmdOK.Width - 10

        Me.cmdOK.Top = Me.tagInformationCustomer.Bottom + 5
        Me.cmdCancel.Top = Me.cmdOK.Top
        Me.cmdChecking.Top = Me.cmdOK.Top
        Me.cmdFind.Left = Me.txtBillOfLading.Right + 10
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Public Sub ApproveDetailBillOfLadingMaster()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        ' Xác định vị trí row trong grid
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
        End If

        Dim strQueryDetailBillOfLading_HouseList As String
        If Not Me.dgdBillOfLading.Item("Editable", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryBillOfLading(mFilter, , index)
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from BillOfLading where" + " BL_Id= '" & Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub SetVip()
        On Error GoTo Err_Renamed
        Dim VIP As Boolean
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        ' Xác định vị trí row trong grid
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
        End If

        Dim strQueryDetailBillOfLading_HouseList As String
        If Not Me.dgdBillOfLading.Item("Editable", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryBillOfLading(mFilter, , index)
        Else
            strQueryDetailBillOfLading_HouseList = "Select * from BillOfLading where" + " BL_Id= '" & Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            VIP = Not rs.Fields("VIP").Value
            rs.Update("VIP", VIP)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub SetWidth()
        '-------cot 1

        'Me.lblOceanV.Left = Me.tagInformationCustomer.Width / 4 + 30
        'Me.cboVessel.Left = Me.lblOceanV.Left + Me.lblOceanV.Width + 5


        'Me.cboVessel.Width = (Me.cboVessel.Right - Me.cboVessel.Left) + rong

        'Me.lblVoyNo.Left = Me.lblOceanV.Left + (Me.lblOceanV.Width - Me.lblVoyNo.Width)
        'Me.txtVoyNo.Left = Me.lblVoyNo.Left + Me.lblVoyNo.Width + 5
        'Me.txtVoyNo.Width = Me.txtVoyNo.Right - Me.txtVoyNo.Left + rong

        'Me.lblCurrency.Left = Me.lblOceanV.Left + (Me.lblOceanV.Width - Me.lblCurrency.Width)
        Me.cboCurrency.Left = Me.lblCurrency.Left + Me.lblCurrency.Width + 5
        Me.cboCurrency.Width = Me.cboCurrency.Right - Me.cboCurrency.Left + rong
        Me.txtSaleName.Left = Me.cboCurrency.Left
        Me.txtSaleName.Width = Me.cboCurrency.Width
        Me.lblSaleName.Left = Me.txtSaleName.Left - Me.lblSaleName.Width


        ' Me.lblSCAC.Left = Me.lblOceanV.Left + (Me.lblOceanV.Width - Me.lblSCAC.Width)
        Me.txtSCAC.Left = Me.lblSCAC.Left + Me.lblSCAC.Width + 5
        Me.txtSCAC.Width = Me.txtSCAC.Right - Me.txtSCAC.Left + rong

        ' Me.lblTradeCode.Left = Me.lblOceanV.Left + (Me.lblOceanV.Width - Me.lblTradeCode.Width)
        Me.txtTradeCode.Left = Me.lblTradeCode.Left + Me.lblTradeCode.Width + 5
        Me.txtTradeCode.Width = Me.txtTradeCode.Right - Me.txtTradeCode.Left + rong

        ' Me.lblRevenueTons.Left = Me.lblOceanV.Left + (Me.lblOceanV.Width - Me.lblRevenueTons.Width)
        'Me.txtRevenueTons.Left = Me.lblRevenueTons.Left + Me.lblRevenueTons.Width + 5
        'Me.txtRevenueTons.Width = Me.txtRevenueTons.Right - Me.txtRevenueTons.Left + rong
        ' cot 2
        Me.Label23.Left = 2 * Me.tagInformationCustomer.Width / 4
        Me.txtPlofReceiptCode.Left = Me.Label23.Left + Me.Label23.Width + 5
        Me.txtPlofReceiptCode.Width = Me.txtPlofReceiptCode.Right - Me.txtPlofReceiptCode.Left + rong

        'Me.lblPlaceOfReceipt.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblPlaceOfReceipt.Width)
        Me.txtPlofReceiptName.Left = Me.txtPlofReceiptCode.Left
        Me.txtPlofReceiptName.Width = Me.txtPlofReceiptName.Right - Me.txtPlofReceiptName.Left + rong

        'Me.lblLoadPortCode.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblLoadPortCode.Width)
        'Me.cboLoad_port.Left = Me.lblLoadPortCode.Left + Me.lblLoadPortCode.Width + 5
        'Me.cboLoad_port.Width = Me.cboLoad_port.Right - Me.cboLoad_port.Left + rong

        ''Me.lblLoadPort.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblLoadPort.Width)
        'Me.txtLoad_port.Left = Me.cboLoad_port.Left
        'Me.txtLoad_port.Width = Me.txtLoad_port.Right - Me.txtLoad_port.Left + rong

        Me.lblRate.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblRate.Width)
        Me.txtRate.Left = Me.lblRate.Left + Me.lblRate.Width + 5
        Me.txtRate.Width = Me.txtRate.Right - Me.txtRate.Left + rong


        Me.cboBookingNo.Left = Me.txtRate.Left
        Me.cboBookingNo.Width = Me.txtRate.Width
        Me.lblbooking.Left = Me.cboBookingNo.Left - Me.lblbooking.Width

        Me.lblBLOtherRef.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblBLOtherRef.Width)
        Me.txtBLOtherref.Left = Me.lblBLOtherRef.Left + Me.lblBLOtherRef.Width + 5
        Me.txtBLOtherref.Width = Me.txtBLOtherref.Right - Me.txtBLOtherref.Left + rong

        Me.lblBLType.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblBLType.Width)
        Me.txtBLType.Left = Me.lblBLType.Left + Me.lblBLType.Width + 5
        Me.txtBLType.Width = Me.txtBLType.Right - Me.txtBLType.Left + rong

        Me.Label17.Left = Me.Label23.Left + (Me.Label23.Width - Me.Label17.Width)
        Me.txtNoOfOrigineBL.Left = Me.Label17.Left + Me.Label17.Width + 5
        Me.txtNoOfOrigineBL.Width = Me.txtNoOfOrigineBL.Right - Me.txtNoOfOrigineBL.Left + rong

        Me.lblPayerCode.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblPayerCode.Width)
        Me.txtPayerCode.Left = Me.lblPayerCode.Left + Me.lblPayerCode.Width + 5
        Me.txtPayerCode.Width = Me.txtPayerCode.Right - Me.txtPayerCode.Left + rong

        Me.lblCustoms.Left = Me.Label23.Left + (Me.Label23.Width - Me.lblCustoms.Width)
        Me.txtCustoms.Left = Me.lblCustoms.Left + Me.lblCustoms.Width + 5
        Me.txtCustoms.Width = Me.txtCustoms.Right - Me.txtCustoms.Left + rong

        '---cot 3
        Me.lblServiceContract.Left = 3 * Me.tagInformationCustomer.Width / 4
        Me.txtServiceContract.Left = Me.lblServiceContract.Left + Me.lblServiceContract.Width + 5
        Me.txtServiceContract.Width = Me.txtServiceContract.Right - Me.txtServiceContract.Left + rong

        Me.lblBL_CY_CFS_Item.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblBL_CY_CFS_Item.Width)
        Me.cboBL_CY_CFS_Item.Left = Me.lblBL_CY_CFS_Item.Left + Me.lblBL_CY_CFS_Item.Width + 5
        Me.cboBL_CY_CFS_Item.Width = Me.cboBL_CY_CFS_Item.Right - Me.cboBL_CY_CFS_Item.Left + rong

        Me.lblRepaid_Collect.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblRepaid_Collect.Width)
        Me.cboRepaid_Collect.Left = Me.lblRepaid_Collect.Left + Me.lblRepaid_Collect.Width + 5
        Me.cboRepaid_Collect.Width = Me.cboRepaid_Collect.Right - Me.cboRepaid_Collect.Left + rong

        Me.lblPrepaidAt.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblPrepaidAt.Width)
        Me.txtPrepaidAt.Left = Me.lblPrepaidAt.Left + Me.lblPrepaidAt.Width + 5
        Me.txtPrepaidAt.Width = Me.txtPrepaidAt.Right - Me.txtPrepaidAt.Left + rong

        Me.lblPayableAt.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblPayableAt.Width)
        Me.txtPayableAt.Left = Me.lblPayableAt.Left + Me.lblPayableAt.Width + 5
        Me.txtPayableAt.Width = Me.txtPayableAt.Right - Me.txtPayableAt.Left + rong

        Me.lblNoOfCopyBL.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblNoOfCopyBL.Width)
        Me.txtNoOfCopyBL.Left = Me.lblNoOfCopyBL.Left + Me.lblNoOfCopyBL.Width + 5
        Me.txtNoOfCopyBL.Width = Me.txtNoOfCopyBL.Right - Me.txtNoOfCopyBL.Left + rong

        Me.lblSlotshare.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblSlotshare.Width)
        Me.cboSlotshare.Left = Me.lblSlotshare.Left + Me.lblSlotshare.Width + 5
        Me.cboSlotshare.Width = Me.cboSlotshare.Right - Me.cboSlotshare.Left + rong

        Me.lblUSServiceMode.Left = Me.lblServiceContract.Left + (Me.lblServiceContract.Width - Me.lblUSServiceMode.Width)
        Me.txtUSServiceMode.Left = Me.lblUSServiceMode.Left + Me.lblUSServiceMode.Width + 5
        Me.txtUSServiceMode.Width = Me.txtUSServiceMode.Right - Me.txtUSServiceMode.Left + rong
        '------place
        Me.txtPortOfLoadingName.Width = Me.tagInformationCustomer.Width - Me.txtPortOfLoadingName.Left - 50
        Me.txtPortOfDischargeName.Width = Me.tagInformationCustomer.Width - Me.txtPortOfDischargeName.Left - 50
        Me.txtPlaceOfDeliveryName.Width = Me.tagInformationCustomer.Width - Me.txtPlaceOfDeliveryName.Left - 50
        Me.txtPlaceofdestinationName.Width = Me.tagInformationCustomer.Width - Me.txtPlaceofdestinationName.Left - 50
        Me.txtPlaceOfBL_IssueName.Width = Me.txtPlaceofdestinationName.Width
        '----
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString

        QueryShipper(Me.dgdBillOfLading.Item("SHIPPER_ID", index).Value.ToString)

        Me.chknotShowDes.Checked = Me.dgdBillOfLading.Item("notShowDes", index).Value
        Me.chkVip.Checked = Me.dgdBillOfLading.Item("VIP", index).Value

        QueryConsignee(Me.dgdBillOfLading.Item("CONSIGNEE_ID", index).Value.ToString)
        QueryNotify(Me.dgdBillOfLading.Item("NOTIFY_ID", index).Value.ToString)
        QueryNotify2(Me.dgdBillOfLading.Item("NOTIFY2_ID", index).Value.ToString)
        QueryNotify3(Me.dgdBillOfLading.Item("NOTIFY3_ID", index).Value.ToString)


        Me.txtDescriptionOfContentsForShipper.Text = Me.dgdBillOfLading.Item("DESCRIPTIONFORSHIPPER", index).Value.ToString

        Me.txtPreVessel.Text = Me.dgdBillOfLading.Item("PRE_VESSEL", index).Value.ToString

        Me.txtPreVesselNo.Text = Me.dgdBillOfLading.Item("PRE_VoyNo", index).Value.ToString
        Me.cboBookingNo.Text = FindIDValue(Me.cboBookingNo, Me.dgdBillOfLading.Item("ContainerOutBoundNotifyId", index).Value.ToString)
        'Me.cboVessel.Text = Me.dgdBillOfLading.Item("VESSEL_CODE", index).Value.ToString

        If Not Me.txtShipper.Text.Trim Like "S0000001*" Then
            Me.txtPreightCharges.Text = Me.dgdBillOfLading.Item("PreightCharges", index).Value.ToString
        Else
            Me.txtPreightCharges.Text = "OCEAN FREIGHT OF : " & Chr(13) & " AMS: " & Chr(10) & "_ PLS DOUBLE CHECK UPON RECEIPT OF B/L " & Chr(10) & " AND CONFIRM US BEFORE THE DEADLINE " & Chr(10) & " THE DEAD LINE BELONGD TO YOUR A/C  " & Chr(10) & "  THANKS("")"
        End If
        'Me.txtPreightCharges.Text = Me.dgdBillOfLading.Item("PreightCharges", index).Value.ToString

        Me.txtTotalprepaid.Text = Me.dgdBillOfLading.Item("TOTALPREPAID_IN", index).Value.ToString

        Me.txtTotalNoContainersOrPackages.Text = Me.dgdBillOfLading.Item("ToTalContainer", index).Value.ToString

        Me.txtPlofReceiptCode.Text = Me.dgdBillOfLading.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString
        'Me.TXTTELEX.Text = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString
        ' Me.cboLoad_port.Text = Me.dgdBillOfLading.Item("LOAD_PORT_CODE", index).Value.ToString

        Me.txtQuaRanTineCode.Text = Me.dgdBillOfLading.Item("QUARANTINE_CODING", index).Value.ToString
        Me.txtMF_FilingType.Text = Me.dgdBillOfLading.Item("MF_FILING_TYPE", index).Value.ToString
        Me.TXTTELEX.Text = Me.dgdBillOfLading.Item("TELEX", index).Value.ToString

        Me.txtNVOCC_MasterBL_No.Text = Me.dgdBillOfLading.Item("NVOCC_MASTER_BL_NO", index).Value.ToString
        Me.cboCurrency.Text = Me.dgdBillOfLading.Item("CURRENCY", index).Value.ToString

        Me.txtSCAC.Text = Me.dgdBillOfLading.Item("SCAC_CODE", index).Value.ToString
        Me.txtCanVasserCode.Text = Me.dgdBillOfLading.Item("CANVASSERCODE", index).Value.ToString

        Me.txtTradeCode.Text = Me.dgdBillOfLading.Item("TRADE_CODE", index).Value.ToString
        Me.txtRevenueTons.Text = Me.dgdBillOfLading.Item("REVENUETON", index).Value.ToString

        Me.DTPLoad_Date.Text = Me.dgdBillOfLading.Item("LOAD_DATE", index).Value.ToString

        Me.txtRate.Text = Me.dgdBillOfLading.Item("EXCHANGE_RATE", index).Value.ToString
        Me.txtBLOtherref.Text = Me.dgdBillOfLading.Item("BL_OTHER_REF", index).Value.ToString
        Me.txtBLType.Text = Me.dgdBillOfLading.Item("BL_TYPE", index).Value.ToString
        Me.txtNoOfOrigineBL.Text = Me.dgdBillOfLading.Item("NO_OF_ORIGINAL_BL", index).Value.ToString
        Me.txtNoOfCopyBL.Text = Me.dgdBillOfLading.Item("NO_OF_COPY_BL", index).Value.ToString
        Me.txtPayerCode.Text = Me.dgdBillOfLading.Item("PAYER_CODE", index).Value.ToString
        Me.txtCustoms.Text = Me.dgdBillOfLading.Item("CUSTOMS_CLEARED_PLACE", index).Value.ToString


        'Me.txtServiceContract.Text = Me.dgdBillOfLading.Item("SERVICECONTRACT", index).Value.ToString


        Me.cboBL_CY_CFS_Item.Text = Me.dgdBillOfLading.Item("BL_CY_CFS_ITEM", index).Value.ToString
        Me.cboRepaid_Collect.Text = Me.dgdBillOfLading.Item("PREPAID_OR_COLLECT", index).Value.ToString

        Me.DTPDate_Of_Issue.Text = Me.dgdBillOfLading.Item("DATE_OF_ISSUE", index).Value.ToString

        Me.txtPrepaidAt.Text = Me.dgdBillOfLading.Item("PREPAIDAT", index).Value.ToString
        Me.txtPayableAt.Text = Me.dgdBillOfLading.Item("PAYABLE_AT", index).Value.ToString
        Me.cboSlotshare.Text = Me.dgdBillOfLading.Item("SLOT_SHARE", index).Value.ToString
        Me.txtUSServiceMode.Text = Me.dgdBillOfLading.Item("US_SERVICE_MODE", index).Value.ToString
        Me.cboRepaid_Collect.Text = Me.dgdBillOfLading.Item("PREPAID_OR_COLLECT", index).Value.ToString


        Me.txtPortOfLoadingCode.Text = Me.dgdBillOfLading.Item("PORT_OF_LOADING_CODE", index).Value.ToString
        Me.txtPortOfDisChargeCode.Text = Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE_CODE", index).Value.ToString
        Me.txtPortOfDeliveryCode.Text = Me.dgdBillOfLading.Item("PLACE_OF_DELIVERY_CODE", index).Value.ToString
        Me.txtPortOfDestinationCode.Text = Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION_CODE", index).Value.ToString
        Me.txtPlaceCode.Text = Me.dgdBillOfLading.Item("PLACE_OF_BL_ISSUE_CODE", index).Value.ToString

        Me.txtPortOfLoadingName.Text = Me.dgdBillOfLading.Item("PORT_OF_LOADING_NAME", index).Value.ToString
        Me.txtPortOfDischargeName.Text = Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE", index).Value.ToString
        Me.txtPlaceOfDeliveryName.Text = Me.dgdBillOfLading.Item("PLACE_OF_DELIVERY", index).Value.ToString
        Me.txtPlaceofdestinationName.Text = Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION", index).Value.ToString
        Me.txtPlaceOfBL_IssueName.Text = Me.dgdBillOfLading.Item("PLACE_OF_BL_ISSUE", index).Value.ToString
        Me.txtSaleName.Text = Me.dgdBillOfLading.Item("SaleName", index).Value.ToString

        Me.txtTransport1.Text = Me.dgdBillOfLading.Item("TRANSFER_PORT1", index).Value.ToString
        Me.txtTransport2.Text = Me.dgdBillOfLading.Item("TRANSFER_PORT2", index).Value.ToString
        Me.txtTransport3.Text = Me.dgdBillOfLading.Item("TRANSFER_PORT3", index).Value.ToString
        Me.txtTransport4.Text = Me.dgdBillOfLading.Item("TRANSFER_PORT4", index).Value.ToString
        Me.txtServiceContract.Text = Me.dgdBillOfLading.Item("ServiceContract", index).Value.ToString
        Me.txtNote.Text = Me.dgdBillOfLading.Item("Note", index).Value.ToString

        Me.txtCommission.Text = Me.dgdBillOfLading.Item("Commission", index).Value.ToString
        Me.txtTAX.Text = Me.dgdBillOfLading.Item("TAX", index).Value.ToString
        If Me.dgdBillOfLading.Item("Party_ID", index).Value.ToString <> "" Then
            PartyID = Me.dgdBillOfLading.Item("Party_ID", index).Value.ToString
            Me.txtPartyCode.Text = Me.dgdBillOfLading.Item("PartyCode", index).Value.ToString
            Me.txtPartyType.Text = Me.dgdBillOfLading.Item("PartyType", index).Value.ToString
            Me.txtAddress1.Text = Me.dgdBillOfLading.Item("PartyAddress1", index).Value.ToString
            Me.txtAddress2.Text = Me.dgdBillOfLading.Item("PartyAddress2", index).Value.ToString
            Me.txtAddress3.Text = Me.dgdBillOfLading.Item("PartyAddress3", index).Value.ToString
            Me.txtAddress4.Text = Me.dgdBillOfLading.Item("PartyAddress4", index).Value.ToString
            Me.txtAddress5.Text = Me.dgdBillOfLading.Item("PartyAddress5", index).Value.ToString

        Else
            PartyID = DefaultValue
        End If
        'Me.cboPortfrom.Text = Me.dgdBillOfLading.Item("PORT_FROM", index).Value.ToString
        'Me.DTPFromDate.Text = Me.dgdBillOfLading.Item("FROM_DATE", index).Value.ToString
        'Me.cboPortTo.Text = Me.dgdBillOfLading.Item("PORT_TO", index).Value.ToString
        'Me.DTPToDate.Text = Me.dgdBillOfLading.Item("TO_DATE", index).Value.ToString
        'Me.txtSEQ.Text = Me.dgdBillOfLading.Item("SEQ", index).Value.ToString
        'Me.txtMOT.Text = Me.dgdBillOfLading.Item("MOT", index).Value.ToString
        Me.txtBL_ClauseCode.Text = Me.dgdBillOfLading.Item("BL_ClauseCode", index).Value.ToString
        Me.txtBL_ClauseText.Text = Me.dgdBillOfLading.Item("BL_ClauseText", index).Value.ToString

        Me.txtPayerShipper.Text = Me.txtShipper.Text

        QueryCustomerPayer()

        Me.txtResultSelect.Text = Me.txtPayerShipper.Text

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

#End Region

#Region "Comment"

    '    Private Sub UpdateFrame()
    '        On Error GoTo Err_Renamed

    '        Me.dgdBillOfLading.Columns.Item("BillOfLadingId1").Visible = Me.smnuDisplayBillOfLading.Checked
    '        Me.dgdBillOfLading.Columns.Item("ShipperId").Visible = Me.smnuDisplayShipperName.Checked
    '        Me.dgdBillOfLading.Columns.Item("ConsigneeId").Visible = Me.smnuDisplayConsigneeName.Checked
    '        Me.dgdBillOfLading.Columns.Item("NotifyId").Visible = Me.smnuDisplayNotifyName.Checked

    '        Me.dgdBillOfLading.Columns.Item("PreCarriageVessel").Visible = Me.smnuDisplayPreCarriage.Checked
    '        Me.dgdBillOfLading.Columns.Item("PreCarriageVoyNo").Visible = Me.smnuDisplayPreCarriage.Checked
    '        Me.dgdBillOfLading.Columns.Item("PlaceOfReceipt").Visible = Me.smnuDisplayPlaceOfReceipt.Checked
    '        Me.dgdBillOfLading.Columns.Item("OceanVessel").Visible = Me.smnuDisplayOceanVessel.Checked
    '        Me.dgdBillOfLading.Columns.Item("VoyNo").Visible = Me.smnuDisplayVoyNo.Checked
    '        Me.dgdBillOfLading.Columns.Item("ServiceContract").Visible = Me.smnuDisplayServiceContract.Checked
    '        Me.dgdBillOfLading.Columns.Item("PortOfLoading").Visible = Me.smnuDisplayPortOfLoading.Checked

    '        Me.dgdBillOfLading.Columns.Item("PortOfDischarge").Visible = Me.smnuDisplayPortOfDischarge.Checked
    '        Me.dgdBillOfLading.Columns.Item("PlaceOfDelivery").Visible = Me.smnuDisplayPlaceOfDelivery.Checked
    '        Me.dgdBillOfLading.Columns.Item("FinalDestination").Visible = Me.smnuDisplayFinalDestination.Checked
    '        Me.dgdBillOfLading.Columns.Item("DescriptionOfContentsForShipper").Visible = Me.smnuDisplayDescriptionOfContentsForShipper.Checked
    '        Me.dgdBillOfLading.Columns.Item("TotalNoContainerOrPackages").Visible = Me.smnuDisplayTotalNoContainerOrPackages.Checked

    '        Me.dgdBillOfLading.Columns.Item("PreightCharges").Visible = Me.smnuDisplayPreightCharges.Checked
    '        Me.dgdBillOfLading.Columns.Item("RevenueTons").Visible = Me.smnuDisplayRevenueTons.Checked
    '        Me.dgdBillOfLading.Columns.Item("Rate").Visible = Me.smnuDisplayRate.Checked
    '        Me.dgdBillOfLading.Columns.Item("Prepaid").Visible = Me.smnuDisplayPrepaid.Checked
    '        Me.dgdBillOfLading.Columns.Item("Collect").Visible = Me.smnuDisplayCollect.Checked

    '        Me.dgdBillOfLading.Columns.Item("PrepaidAt").Visible = Me.smnuDisplayPrepaidAt.Checked

    '        Me.dgdBillOfLading.Columns.Item("PayableAt").Visible = Me.smnuDisplayPayableAt.Checked
    '        Me.dgdBillOfLading.Columns.Item("PlaceAndDateOfIssue").Visible = Me.smnuDisplayPlaceOfIssue.Checked
    '        Me.dgdBillOfLading.Columns.Item("DateOfIssue").Visible = Me.smnuDisplayDateOfIssue.Checked
    '        Me.dgdBillOfLading.Columns.Item("TotalPrepaidIn").Visible = Me.smnuDisplayTotalPrepaidIn.Checked

    '        Me.dgdBillOfLading.Columns.Item("NoOfOrigineBL").Visible = Me.smnuDisplayNoOfOrigineBL.Checked
    '        Me.dgdBillOfLading.Columns.Item("CreativeUser").Visible = Me.smnuDisplayCreativeUser.Checked
    '        Me.dgdBillOfLading.Columns.Item("CreativeDate").Visible = Me.smnuDisplayCreativeDate.Checked
    '        Me.dgdBillOfLading.Columns.Item("Approve1").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdBillOfLading.Columns.Item("UserId1").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdBillOfLading.Columns.Item("UpdateTime1").Visible = Me.smnuDisplayUpdateTime.Checked
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    '    Private Sub smnuDisplayBillOfLading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBillOfLading.Click
    '        Me.smnuDisplayBillOfLading.Checked = Not Me.smnuDisplayBillOfLading.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayBillOfLadingHouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayShipperName.Click
    '        Me.smnuDisplayShipperName.Checked = Not Me.smnuDisplayShipperName.Checked
    '        UpdateFrame()
    '    End Sub


    '    Private Sub smnuDisplayConsigneeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayConsigneeName.Click
    '        Me.smnuDisplayConsigneeName.Checked = Not Me.smnuDisplayConsigneeName.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNotifyName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNotifyName.Click
    '        Me.smnuDisplayNotifyName.Checked = Not Me.smnuDisplayNotifyName.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPreCarriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPreCarriage.Click
    '        Me.smnuDisplayPreCarriage.Checked = Not Me.smnuDisplayPreCarriage.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPlaceOfReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPlaceOfReceipt.Click
    '        Me.smnuDisplayPlaceOfReceipt.Checked = Not Me.smnuDisplayPlaceOfReceipt.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayOceanVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayOceanVessel.Click
    '        Me.smnuDisplayOceanVessel.Checked = Not Me.smnuDisplayOceanVessel.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayVoyNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayVoyNo.Click
    '        Me.smnuDisplayVoyNo.Checked = Not Me.smnuDisplayVoyNo.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPortOfLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPortOfLoading.Click
    '        Me.smnuDisplayPortOfLoading.Checked = Not Me.smnuDisplayPortOfLoading.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPortOfDischarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPortOfDischarge.Click
    '        Me.smnuDisplayPortOfDischarge.Checked = Not Me.smnuDisplayPortOfDischarge.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPlaceOfDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPlaceOfDelivery.Click
    '        Me.smnuDisplayPlaceOfDelivery.Checked = Not Me.smnuDisplayPlaceOfDelivery.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayFinalDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFinalDestination.Click
    '        Me.smnuDisplayFinalDestination.Checked = Not Me.smnuDisplayFinalDestination.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayDescriptionOfContentsForShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDescriptionOfContentsForShipper.Click
    '        Me.smnuDisplayDescriptionOfContentsForShipper.Checked = Not Me.smnuDisplayDescriptionOfContentsForShipper.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayTotalNoContainerOrPackages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTotalNoContainerOrPackages.Click
    '        Me.smnuDisplayTotalNoContainerOrPackages.Checked = Not Me.smnuDisplayTotalNoContainerOrPackages.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPreightCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPreightCharges.Click
    '        Me.smnuDisplayPreightCharges.Checked = Not Me.smnuDisplayPreightCharges.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayRevenueTons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRevenueTons.Click
    '        Me.smnuDisplayRevenueTons.Checked = Not Me.smnuDisplayRevenueTons.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRate.Click
    '        Me.smnuDisplayRate.Checked = Not Me.smnuDisplayRate.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPrepaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPrepaid.Click
    '        Me.smnuDisplayPrepaid.Checked = Not Me.smnuDisplayPrepaid.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCollect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCollect.Click
    '        Me.smnuDisplayCollect.Checked = Not Me.smnuDisplayCollect.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPrepaidAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPrepaidAt.Click
    '        Me.smnuDisplayPrepaidAt.Checked = Not Me.smnuDisplayPrepaidAt.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPayableAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPayableAt.Click
    '        Me.smnuDisplayPayableAt.Checked = Not Me.smnuDisplayPayableAt.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayPlaceOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPlaceOfIssue.Click
    '        Me.smnuDisplayPlaceOfIssue.Checked = Not Me.smnuDisplayPlaceOfIssue.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayDateOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDateOfIssue.Click
    '        Me.smnuDisplayDateOfIssue.Checked = Not Me.smnuDisplayDateOfIssue.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayTotalPrepaidIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTotalPrepaidIn.Click
    '        Me.smnuDisplayTotalPrepaidIn.Checked = Not Me.smnuDisplayTotalPrepaidIn.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayNoOfOrigineBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNoOfOrigineBL.Click
    '        Me.smnuDisplayNoOfOrigineBL.Checked = Not Me.smnuDisplayNoOfOrigineBL.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCreativeUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCreativeUser.Click
    '        Me.smnuDisplayCreativeUser.Checked = Not Me.smnuDisplayCreativeUser.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayCreativeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCreativeDate.Click
    '        Me.smnuDisplayCreativeDate.Checked = Not Me.smnuDisplayCreativeDate.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
    '        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
    '        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '        UpdateFrame()
    '    End Sub

    '    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
    '        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '        UpdateFrame()
    '    End Sub

#End Region

#Region "Xử Lý Mnu"
    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryHouseCOLO()
        Try

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strSQL As String = "Select * from HouseColoBillInfo Where Continued=1 And BL_ID='" & mBillOfLadingId & "'"
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdHouseCOLO.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Public Sub editbill()
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.dgdBillOfLading.Rows.Count > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
        Else
            Exit Sub
        End If




        If index >= 0 Then
            QueryRouting(index)
            Approve = Me.dgdBillOfLading.Item("Approve", index).Value
            EditTable = Me.dgdBillOfLading.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListBillOfLadingMaster", "Edit") Then
                Me.tagInformationCustomer.Visible = True

                If Me.dgdBillOfLading.RowCount > 0 Then
                    index = Me.dgdBillOfLading.CurrentRow.Index
                End If
                mBillOfLadingId = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
                QueryHouseCOLO()

                ' Me.txtBillOfLadingId.Text = Me.dgdBillOfLading.Item("BL_No", index).Value.ToString
                mStatus = "Edit"
                Me.fraUpdate.Visible = True
                Me.dgdBillOfLading.Height = 306
                Me.dgdBillOfLading.Enabled = True
                ReFormat()
                SetMenu((False))
                Me.txtNotify3.Text = ""
                Me.txtNotify2.Text = ""
                RefreshData(index)
                If Me.dgdBillOfLading.Item("SHIPPERNAME", index).Value.ToString.Trim = "" And Me.txtPlofReceiptCode.Text = "" And Me.txtPortOfLoadingCode.Text = "" And Me.txtPortOfDeliveryCode.Text = "" And Me.txtPortOfDestinationCode.Text = "" And Me.txtPortOfDisChargeCode.Text = "" And Me.txtPlaceCode.Text = "" Then
                    Dim POL, POD As String
                    GetPortFromBill(Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString.Trim, POL, POD)
                    Me.txtPlofReceiptCode.Text = POL
                    Me.txtPortOfLoadingCode.Text = POL
                    'Me.cboPortOfDelivery.Text = POD
                    'Me.cboPortOfDestination.Text = POD
                    'Me.cboPortOfDisCharge.Text = POD
                    Me.txtPlaceCode.Text = POL
                End If
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
    Private Sub smnuEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuEdit.Click

    End Sub

#End Region

#Region "Xử Lý ComboBox"

    '    Private Sub txtShipper_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, shipper_code As String
    '        strSql = "Select Shipper_1  as name From Shipper Where Continued=1"
    '        If Me.txtShipper.FindStringExact(Me.txtShipper.Text) = -1 Then
    '            Me.txtShipper.Text = FindBetter_new("Name", strSql, Me.txtShipper.Text)
    '            If Me.txtShipper.FindStringExact(Me.txtShipper.Text) = -1 Then
    '                DisplayMessage(True, "The Shipper is invalid, please check and correct it.")
    '                Me.txtShipper.Focus()
    '            End If

    '        End If
    '        Me.txtShipper_SelectedIndexChanged(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '        'DisplayMessage(True, "")
    '        'Resume
    '    End Sub

    '    Private Sub txtConsignee_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Consignee_code As String
    '        strSql = "Select Consignee_1 as name From Consignee Where Continued=1"
    '        If Me.txtConsignee.FindStringExact(Me.txtConsignee.Text) = -1 Then
    '            Me.txtConsignee.Text = FindBetter_new("Name", strSql, Me.txtConsignee.Text)
    '            If Me.txtConsignee.FindStringExact(Me.txtConsignee.Text) = -1 Then
    '                DisplayMessage(True, "The Consignee is invalid, please check and correct it.")
    '                Me.txtConsignee.Focus()
    '            End If
    '        End If
    '        Me.txtConsignee_SelectedIndexChanged(sender, e)
    '        Exit Sub
    'Err_Renamed:
    '        'DisplayMessage(True, "")
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
    '        Me.txtPortfromCode.Text = Trim(UCase(Me.txtPortfromCode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.txtPortfromCode.FindStringExact(Me.txtPortfromCode.Text) = -1 Then
    '            Me.txtPortfromCode.Text = FindBetter_new("code", strSql, Me.txtPortfromCode.Text)
    '            If Me.txtPlofReceiptCode.FindStringExact(Me.txtPlofReceiptCode.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.txtPortfromCode.Focus()
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
    '                Me.txtPortOfDischargeName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
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
    '                Me.txtPlaceofdestinationName.Text = oTablePort.Rows(i).Item("Port").ToString
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
    '                Me.txtPlaceOfDeliveryName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
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
    '    Me.txtNotify_SelectedIndexChanged(sender, e)
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
    '        Else
    '            Me.txtNotify2.Text = ""
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
    '        Else
    '            Me.txtNotify3.Text = ""
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

    'Private Sub cboPre_Vessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    '            ' Me.txtPre_VoyNo.Text = table.Rows(0).Item("PRE_VESSEL_VOYAGE").ToString
    '            PREVESSELID = table.Rows(0).Item("Pre_vessel_ID").ToString
    '        End If
    '    End If
    'End Sub


    'Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
    '                Me.txtPlofReceiptName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    Private Sub cboBookingNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBookingNo.Leave
        On Error GoTo Err_Renamed
        Dim strSql, shipper_code As String
        strSql = "Select BookingNo  as BookingNo From containeroutboundnotify Where Continued=1"
        If Me.cboBookingNo.FindStringExact(Me.cboBookingNo.Text) = -1 Then
            DisplayMessage(True, "Booking No. is invalid!, plaease check again.")
            'Me.cboBookingNo.Text = FindBetter_new("BookingNo", strSql, Me.cboBookingNo.Text)
            'If Me.cboBookingNo.FindStringExact(Me.cboBookingNo.Text) = -1 Then
            '    DisplayMessage(True, "The Booking No. is invalid, please check and correct it.")
            '    Me.cboBookingNo.Focus()
            'End If
        End If
        Me.cboBookingNo_SelectedIndexChanged(sender, e)
        Exit Sub
Err_Renamed:
        'DisplayMessage(True, "")
        'Resume
    End Sub

    Private Sub cboBookingNo_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBookingNo.Resize

    End Sub

    Private Sub cboBookingNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBookingNo.SelectedIndexChanged
        On Error GoTo Err_Renamed
        Dim BookingNo As String
        Dim i As Integer
        BookingNo = FindValueID(Me.cboBookingNo, Me.cboBookingNo.Text)
        Me.txtSalePayer.Text = QueryPayerNote(BookingNo)
        If BookingNo <> "" Then
            Dim strSQL, sqlVIA As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset, dsetVIA As New DataSet
            Dim table As New DataTable
            Dim tableVIA As New DataTable
            '----------------
            'strQuery = "select * from CONTAINEROUTBOUNDNOTIFY where CONTAINEROUTBOUNDNOTIFYID='" & BookingNo & "'"
            strSQL = "Select ServiceContract,Vessel.Vessel_Code As Code,SailingSchedule.VoyNo As No, SaleName,market_id,CONTAINEROUTBOUNDNOTIFY.SailingScheduleID, PortOfUnLoading,tranship,VIA,Destination,remarks  "
            strSQL &= " From ((SailingSchedule LEFT JOIN CONTAINEROUTBOUNDNOTIFY "
            strSQL = strSQL & " On CONTAINEROUTBOUNDNOTIFY.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL = strSQL & " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) where CONTAINEROUTBOUNDNOTIFY.Continued=1 And ContainerOutBoundNotifyId='" & BookingNo & "'"

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
                Me.txtServiceContract.Text = table.Rows(0).Item("ServiceContract").ToString.Trim
                Me.txtPreVessel.Text = table.Rows(0).Item("Code").ToString.Trim
                Me.txtPreVesselNo.Text = table.Rows(0).Item("No").ToString.Trim
                Me.txtSaleName.Text = table.Rows(0).Item("SaleName").ToString.Trim
                '-------transit
                Me.txtTransport1.Text = PortCode(table.Rows(0).Item("tranship").ToString.Trim)
                Me.txtTransport2.Text = table.Rows(0).Item("VIA").ToString
                Me.txtPortOfDisChargeCode.Text = PortCode(table.Rows(0).Item("PortOfUnLoading").ToString.Trim).Trim
                Me.txtPortOfDestinationCode.Text = PortCode(table.Rows(0).Item("Destination").ToString.Trim).Trim
                Me.txtPortOfDeliveryCode.Text = PortCode(table.Rows(0).Item("Destination").ToString.Trim).Trim
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
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    '

    '    Private Sub cboPortOfLoading_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortOfLoadingCode, Me.txtPortOfLoadingCode.Text)
    '        For i = 0 To oTablePort.Rows.Count - 1
    '            If Trim(oTablePort.Rows(i).Item("Port_Id").ToString) = Trim(Port_ID) Then
    '                Me.txtPortOfLoadingName.Text = oTablePort.Rows(i).Item("Port").ToString
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
    '                Me.txtPlaceOfBL_IssueName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    '    Private Sub cboTradeCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim TradeCode1_ID As String
    '        TradeCode1_ID = FindValueID(Me.txtTradeCode, Me.txtTradeCode.Text)
    '        If TradeCode1_ID <> "" Then
    '            Dim strQuery As String
    '            '-------------
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Dim dset As New DataSet
    '            Dim table As New DataTable
    '            '----------------
    '            strQuery = "select * from Market where Market_ID='" & TradeCode1_ID & "'"

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
    '                TRADECODEID = table.Rows(0).Item("Market_ID").ToString
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
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
        End If
        Me.tagInformationCustomer.Visible = False
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        'Me.dgdBillOfLading.Enabled = True
        QueryBillOfLading(mFilter, , index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub InsertHouseBill()
        Dim rs, rsm As New ADODB.Recordset
        Dim strQuery As String
        strQuery = "Select * from BILLOFLADING_House where BL_ID='" & mBillOfLadingId & "' AND BL_ID <> '" & DefaultValue & "'"
        rsm.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rsm.EOF Then
            rsm.Close()
            Exit Sub
        End If
        rsm.MoveFirst()
        While Not rsm.EOF
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM BILLOFLADING_House "
            strQuery = strQuery & "WHERE BLH_ID = '" & rsm.Fields("BLH_ID").Value.ToString & "' AND BLH_ID <> '" & DefaultValue & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            With rs
                'If rs.EOF Then
                '    .AddNew()
                '    .Fields("BL_ID").Value = NewId()
                'End If
                'strVesselId = .Fields("BL_ID").Value
                If Me.cboBookingNo.Text <> "" And Me.txtShipper.Text <> "" And Me.txtConsignee.Text <> "" And Me.txtNotify.Text <> "" And Me.txtPlofReceiptCode.Text <> "" And Me.txtPortOfLoadingCode.Text <> "" And Me.txtPortOfDisChargeCode.Text <> "" And Me.txtPortOfDeliveryCode.Text <> "" And Me.txtPortOfDestinationCode.Text <> "" And Me.txtPlaceCode.Text <> "" Then
                    .Fields("SHIPPER_ID").Value = "{" & ShipperID & "}"
                    .Fields("CONSIGNEE_ID").Value = "{" & ConsigneeID & "}"
                    .Fields("NOTIFY_ID").Value = "{" & NotifyID & "}"
                    If Me.txtNotify2.Text.Trim.Length > 0 Then
                        .Fields("NOTIFY2_ID").Value = "{" & Notify2ID & "}"
                    Else
                        .Fields("NOTIFY2_ID").Value = DefaultValue
                    End If
                    If Me.txtNotify3.Text.Trim.Length > 0 Then
                        .Fields("NOTIFY3_ID").Value = "{" & Notify3ID & "}"
                    Else
                        .Fields("NOTIFY3_ID").Value = DefaultValue
                    End If


                    .Fields("ContainerOutBoundNotifyId").Value = "{" & FindValueID(Me.cboBookingNo, Me.cboBookingNo.Text) & "}"
                    .Fields("PLACE_OF_RECEIPT_ID").Value = "{" & POR_ID & "}"
                    .Fields("PORT_OF_LOADING_ID").Value = "{" & POL_ID & "}"
                    .Fields("PORT_OF_DISCHARGE_ID").Value = "{" & POD_ID & "}"
                    .Fields("PLACE_OF_DELIVERY_ID").Value = "{" & DEL_ID & "}"
                    .Fields("PLACE_OF_DESTINATION_ID").Value = "{" & DEST_ID & "}"
                    .Fields("PLACE_OF_BL_ISSUE_ID").Value = "{" & POI_ID & "}"
                    .Fields("BL_ClauseID").Value = "{" & mBL_ClauseID & "}"
                    '.Fields("TRADE_CODE_ID").Value = "{" & FindValueID(Me.txtTradeCode, Me.txtTradeCode.Text) & "}"
                End If


                .Fields("TRADE_CODE").Value = Me.txtTradeCode.Text

                .Fields("TOTALPREPAID_IN").Value = UCase(Trim(Me.txtTotalprepaid.Text))

                .Fields("BL_CY_CFS_ITEM").Value = UCase(Trim(Me.cboBL_CY_CFS_Item.Text))

                .Fields("PREPAID_OR_COLLECT").Value = UCase(Trim(Me.cboRepaid_Collect.Text))
                .Fields("LOAD_DATE").Value = Me.DTPLoad_Date.Value.Date

                .Fields("DESCRIPTIONFORSHIPPER").Value = UCase(Trim(Me.txtDescriptionOfContentsForShipper.Text))
                .Fields("REVENUETON").Value = UCase(Trim(Me.txtRevenueTons.Text))

                .Fields("QUARANTINE_CODING").Value = UCase(Trim(Me.txtQuaRanTineCode.Text))
                .Fields("DATE_OF_ISSUE").Value = Me.DTPDate_Of_Issue.Value.Date

                .Fields("Note").Value = Me.txtNote.Text

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
                .Fields("PreightCharges").Value = UCase(Trim(Me.txtPreightCharges.Text))

                .Fields("ToTalContainer").Value = UCase(Trim(Me.txtTotalNoContainersOrPackages.Text))
                .Fields("PORT_OF_LOADING_CODE").Value = UCase(Trim(Me.txtPortOfLoadingCode.Text))
                .Fields("PLACE_OF_BL_ISSUE_CODE").Value = UCase(Trim(Me.txtPlaceCode.Text))
                .Fields("PLACE_OF_DESTINATION_CODE").Value = UCase(Trim(Me.txtPortOfDestinationCode.Text))
                .Fields("PLACE_OF_DELIVERY_CODE").Value = UCase(Trim(Me.txtPortOfDeliveryCode.Text))

                .Fields("PLACE_OF_RECEIPT_CODE").Value = UCase((Me.txtPlofReceiptCode.Text))
                .Fields("PORT_OF_DISCHARGE_CODE").Value = UCase((Me.txtPortOfDisChargeCode.Text))
                '  .Fields("Vessel_Code").Value = UCase(Trim(Me.cboVessel.Text))
                '.Fields("SERVICECONTRACT").Value = UCase(Trim(Me.txtServiceContract.Text))
                .Fields("PREPAIDAT").Value = UCase(Trim(Me.txtPrepaidAt.Text))
                .Fields("TRANSFER_PORT1").Value = UCase(Trim(Me.txtTransport1.Text))
                .Fields("TRANSFER_PORT2").Value = UCase(Trim(Me.txtTransport2.Text))
                .Fields("TRANSFER_PORT3").Value = UCase(Trim(Me.txtTransport3.Text))
                .Fields("TRANSFER_PORT4").Value = UCase(Trim(Me.txtTransport4.Text))
                '.Fields("PORT_FROM").Value = UCase(Trim(Me.cboPortfrom.Text))
                '.Fields("FROM_DATE").Value = Me.DTPFromDate.Value.Date

                '.Fields("PORT_TO").Value = UCase(Trim(Me.cboPortTo.Text))
                '.Fields("TO_DATE").Value = Me.DTPToDate.Value.Date
                '.Fields("SEQ").Value = UCase(Trim(Me.txtSEQ.Text))
                '.Fields("MOT").Value = UCase(Trim(Me.txtMOT.Text))
                If Me.chknotShowDes.Checked = True Then
                    .Fields("notShowDes").Value = "1"
                Else
                    .Fields("notShowDes").Value = "0"
                End If

                .Fields("Payer").Value = Me.txtResultSelect.Text
                .Update()

            End With
            rs.Close()
            rsm.MoveNext()
        End While
        rsm.Close()


    End Sub
    Public Function CheckData() As Boolean
        Try
            Dim strmsg As String = ""
            Dim Result As Boolean = True
            If Me.txtCommission.Text = "" Then
                strmsg &= "Commission must have an Value"
                Result = True
            End If
            If Me.txtTAX.Text = "" Then
                strmsg &= "Tax must have an Value"
                Result = True
            End If

            If Me.txtServiceContract.Text = "" Then
                strmsg &= "Services Contract must have an Value"
                Result = True
            End If
            If Me.txtMF_FilingType.Text = "" Then
                strmsg &= vbCrLf & "MF Filing type must have an Value"
                Result = True
            End If
            If Me.cboCurrency.Text = "" Then
                strmsg &= vbCrLf & "Currency must have an Value"
                Result = False
            End If
            'If Me.txtSCAC.Text = "" Then
            '    strmsg &= vbCrLf & "SCAC Code must have an Value"
            '    Result = False
            'End If

            If Me.txtTradeCode.Text = "" Then
                strmsg &= vbCrLf & "trade Code must have an Value"
                Result = False
            End If

            'If Me.txtBLOtherref.Text = "" Then
            '    strmsg &= vbCrLf & " B/L Other must have an Value"
            '    Result = False
            'End If
            If Me.txtBLType.Text = "" Then
                strmsg &= vbCrLf & " B/L Type must have an Value"
                Result = False
            End If

            If Me.txtNoOfOrigineBL.Text = "" Then
                strmsg &= vbCrLf & " N.Ori. BL(29) must have an Value"
                Result = False
            End If

            If Me.txtPayerCode.Text = "" Then
                strmsg &= vbCrLf & " payer Code must have an Value"
                Result = False
            End If

            If Me.txtPlofReceiptCode.Text = "" Then
                strmsg &= vbCrLf & " place of receipt must have an Value"
                Result = False
            End If

            If Me.cboBL_CY_CFS_Item.Text = "" Then
                strmsg &= vbCrLf & " BL_CY_CFS_Item must have an Value"
                Result = False
            End If
            ''''''''''''''''''''''''''''''''''''

            If Me.cboRepaid_Collect.Text = "" Then
                strmsg &= vbCrLf & " Repaid_Collect must have an Value"
                Result = False
            End If

            If Me.txtPayableAt.Text = "" Then
                strmsg &= vbCrLf & "Payable At must have an Value"
                Result = False
            End If

            If Me.txtNoOfCopyBL.Text = "" Then
                strmsg &= vbCrLf & " N. C B/L  must have an Value"
                Result = False
            End If

            'If Me.cboSlotshare.Text = "" Then
            '    strmsg &= vbCrLf & " Slot share must have an Value"
            '    Result = False
            'End If

            ''''''''''''''''''''''''''''''''''''

            If Me.txtUSServiceMode.Text = "" Then
                strmsg &= vbCrLf & " US Mode must have an Value"
                Result = True
            End If

            If Me.txtCanVasserCode.Text = "" Then
                strmsg &= vbCrLf & "CanVasserCode must have an Value"
                Result = False
            End If

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
            If Me.dgdRouting.RowCount = 0 Then
                DisplayMessage(True, "Routing Must have Some record")
                Return False
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
        Dim strQuery, strVesselId As String
        Dim Isedit As Boolean = False



        ' Dim rsCode As New ADODB.Recordset
        mBL_ClauseID = DefaultValue
        Dim index As Integer = 0
        If Me.dgdBillOfLading.Rows.Count > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
            mBL_ClauseID = Me.dgdBillOfLading.Item("BL_ClauseID", index).Value.ToString
        End If

        'kiểm tra số bill có rỗng không

        'If Me.txtBillOfLadingId.Text = "" Then
        '    'Me.txtBillOfLadingId.Focus()
        '    If Me.txtBillOfLadingId.Text = "" Then
        '        mStatus = "Normal"
        '    End If
        'End If
        If CheckData() And (mStatus = "Edit" Or mStatus = "Add") Then
            'If mStatus = "Edit" Then
            '    CopyValues("BILLOFLADING", "BL_ID", mBillOfLadingId)
            'End If
            If mBL_ClauseID = "" Then
                mBL_ClauseID = DefaultValue
            End If
            Dim rs As New ADODB.Recordset
            'thêm BL_Clause If Add
            strQuery = "Select Top 1 * from BL_Clause Where BL_clauseID='" & mBL_ClauseID & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If .EOF Or UCase(mStatus) = "ADD" Then
                    .AddNew()
                    .Fields("BL_ClauseID").Value = NewId()
                End If
                mBL_ClauseID = .Fields("BL_ClauseID").Value
                mBL_ClauseID = mBL_ClauseID.Replace("{", "").Replace("}", "")
                .Fields("BL_ClauseCode").Value = Me.txtBL_ClauseCode.Text
                .Fields("BL_ClauseText").Value = Me.txtBL_ClauseText.Text
                .Update()
            End With
            rs.Close()

            strQuery = "select Top 1 * From party where continued=1 and BL_ID='" & mBillOfLadingId & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Me.chkVip.Checked = True Then 'nếu là vip thì mới đưa party vào
                If rs.EOF Then
                    rs.AddNew()
                    rs.Fields("Party_ID").Value = NewId()
                    rs.Fields("BL_ID").Value = "{" & mBillOfLadingId & "}"
                End If
                PartyID = rs.Fields("Party_ID").Value.ToString

                rs.Fields("PartyCode").Value = Me.txtPartyCode.Text
                rs.Fields("PartyType").Value = Me.txtPartyType.Text
                rs.Fields("PartyAddress1").Value = Me.txtAddress1.Text
                rs.Fields("PartyAddress2").Value = Me.txtAddress2.Text
                rs.Fields("PartyAddress3").Value = Me.txtAddress3.Text
                rs.Fields("PartyAddress4").Value = Me.txtAddress4.Text
                rs.Fields("PartyAddress5").Value = Me.txtAddress5.Text
                rs.Update()
            Else
                If Not rs.EOF Then
                    rs.Fields("BL_ID").Value = DefaultValue
                    rs.Update()
                End If
            End If
            rs.Close()

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM BILLOFLADING "
            strQuery = strQuery & "WHERE BL_ID = '" & mBillOfLadingId & "' AND BL_ID <> '" & DefaultValue & "'"

            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'If rs.Fields("SHIPPER_ID").Value.ToString <> DefaultValue Then
            '    Isedit = True
            'End If
            ' bat cu khi bill thay doi thi house cung thay doi theo
            With rs
                'If rs.EOF Then
                '    .AddNew()
                '    .Fields("BL_ID").Value = NewId()
                'End If
                strVesselId = .Fields("BL_ID").Value
                '.Fields("SHIPPER_ID").Value = "{" & FindValueID(Me.txtShipper, Me.txtShipper.Text) & "}"
                '.Fields("CONSIGNEE_ID").Value = "{" & ConsigneeID & "}"
                '.Fields("NOTIFY_ID").Value = "{" & NOTIFYID & "}"
                ''.Fields("PRE_VESSEL_ID").Value = "{" & PREVESSELID & "}"
                '.Fields("PLACE_OF_RECEIPT_ID").Value = "{" & PLACEOFRECEIPTID & "}"
                ''.Fields("LOAD_PORT_ID").Value = "{" & LOADPORTID & "}"

                '.Fields("PORT_OF_LOADING_ID").Value = "{" & PORTOFLOADINGID & "}"

                '.Fields("PORT_OF_DISCHARGE_ID").Value = "{" & PORTOFDISCHARGEID & "}"
                '.Fields("PLACE_OF_DELIVERY_ID").Value = "{" & PLACEOFDELIVERYID & "}"

                '.Fields("PLACE_OF_DESTINATION_ID").Value = "{" & PLACEOFDESTINATIONID & "}"
                '.Fields("PLACE_OF_BL_ISSUE_ID").Value = "{" & PLACEOFBLISSUEID & "}"
                ''.Fields("VESSEL_ID").Value = "{" & VESSELID & "}"

                If Me.cboBookingNo.Text <> "" And Me.txtShipper.Text <> "" And Me.txtConsignee.Text <> "" And Me.txtNotify.Text <> "" And Me.txtPlofReceiptCode.Text <> "" And Me.txtPortOfLoadingCode.Text <> "" And Me.txtPortOfDisChargeCode.Text <> "" And Me.txtPortOfDeliveryCode.Text <> "" And Me.txtPortOfDestinationCode.Text <> "" And Me.txtPlaceCode.Text <> "" Then
                    .Fields("ContainerOutBoundNotifyId").Value = "{" & FindValueID(Me.cboBookingNo, Me.cboBookingNo.Text) & "}"
                    '.Fields("TRADE_CODE_ID").Value = "{" & TRADECODEID & "}"
                    .Fields("SHIPPER_ID").Value = "{" & ShipperID & "}"
                    .Fields("CONSIGNEE_ID").Value = "{" & ConsigneeID & "}"
                    .Fields("NOTIFY_ID").Value = "{" & NotifyID & "}"
                    If Me.txtNotify2.Text.Trim.Length > 0 Then
                        .Fields("NOTIFY2_ID").Value = "{" & Notify2ID & "}"
                    Else
                        .Fields("NOTIFY2_ID").Value = DefaultValue
                    End If
                    If Me.txtNotify3.Text.Trim.Length > 0 Then
                        .Fields("NOTIFY3_ID").Value = "{" & Notify3ID & "}"
                    Else
                        .Fields("NOTIFY3_ID").Value = DefaultValue
                    End If
                    '.Fields("PartyID").Value = PartyID
                    .Fields("PLACE_OF_RECEIPT_ID").Value = "{" & POR_ID & "}"
                    .Fields("PORT_OF_LOADING_ID").Value = "{" & POL_ID & "}"
                    .Fields("PORT_OF_DISCHARGE_ID").Value = "{" & POD_ID & "}"
                    .Fields("PLACE_OF_DELIVERY_ID").Value = "{" & DEL_ID & "}"
                    .Fields("PLACE_OF_DESTINATION_ID").Value = "{" & DEST_ID & "}"
                    .Fields("PLACE_OF_BL_ISSUE_ID").Value = "{" & POI_ID & "}"
                    .Fields("BL_ClauseID").Value = "{" & mBL_ClauseID & "}"
                    '.Fields("TRADE_CODE_ID").Value = "{" & FindValueID(Me.txtTradeCode, Me.txtTradeCode.Text) & "}"
                End If

                If Me.chknotShowDes.Checked = True Then
                    .Fields("notShowDes").Value = 1
                Else
                    .Fields("notShowDes").Value = 0
                End If

                If Me.chkVip.Checked = True Then
                    .Fields("VIP").Value = 1
                Else
                    .Fields("VIP").Value = 0
                End If


                .Fields("TELEX").Value = Me.TXTTELEX.Text
                .Fields("TRADE_CODE").Value = Me.txtTradeCode.Text
                .Fields("TOTALPREPAID_IN").Value = UCase(Trim(Me.txtTotalprepaid.Text))

                .Fields("BL_CY_CFS_ITEM").Value = UCase(Trim(Me.cboBL_CY_CFS_Item.Text))

                .Fields("PREPAID_OR_COLLECT").Value = UCase(Trim(Me.cboRepaid_Collect.Text))
                .Fields("LOAD_DATE").Value = Me.DTPLoad_Date.Value.Date

                .Fields("DESCRIPTIONFORSHIPPER").Value = UCase(Trim(Me.txtDescriptionOfContentsForShipper.Text))
                .Fields("REVENUETON").Value = UCase(Trim(Me.txtRevenueTons.Text))
                '.Fields("SALENAME").Value = UCase(Trim(Me.txtSaleName.Text))
                .Fields("QUARANTINE_CODING").Value = UCase(Trim(Me.txtQuaRanTineCode.Text))
                .Fields("DATE_OF_ISSUE").Value = Me.DTPDate_Of_Issue.Value.Date

                .Fields("Note").Value = Me.txtNote.Text

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

                .Fields("PreightCharges").Value = UCase(Trim(Me.txtPreightCharges.Text))

                .Fields("ToTalContainer").Value = UCase(Trim(Me.txtTotalNoContainersOrPackages.Text))


                '.Fields("SERVICECONTRACT").Value = UCase(Trim(Me.txtServiceContract.Text))
                .Fields("PREPAIDAT").Value = UCase(Trim(Me.txtPrepaidAt.Text))
                .Fields("TRANSFER_PORT1").Value = UCase(Trim(Me.txtTransport1.Text))
                .Fields("TRANSFER_PORT2").Value = UCase(Trim(Me.txtTransport2.Text))
                .Fields("TRANSFER_PORT3").Value = UCase(Trim(Me.txtTransport3.Text))
                .Fields("TRANSFER_PORT4").Value = UCase(Trim(Me.txtTransport4.Text))
                .Fields("ServiceContract").Value = UCase(Trim(Me.txtServiceContract.Text))

                .Fields("Commission").Value = UCase(Trim(Me.txtCommission.Text))
                .Fields("TAX").Value = UCase(Trim(Me.txtTAX.Text))
                .Fields("Payer").Value = Me.txtResultSelect.Text
                .Fields("Checking").Value = Checking
                '.Fields("PORT_FROM").Value = UCase(Trim(Me.cboPortfrom.Text))
                '.Fields("FROM_DATE").Value = Me.DTPFromDate.Value.Date

                '.Fields("PORT_TO").Value = UCase(Trim(Me.cboPortTo.Text))
                '.Fields("TO_DATE").Value = Me.DTPToDate.Value.Date
                '.Fields("SEQ").Value = UCase(Trim(Me.txtSEQ.Text))
                '.Fields("MOT").Value = UCase(Trim(Me.txtMOT.Text))
                .Update()

            End With
            rs.Close()
            If update = True Then
                InsertHouseBill()
            End If
            Me.dgdBillOfLading.Enabled = True

            'MakeQueryBillOfLading("And BIllOfLading.BL_ID='" & BillID & "'", 15)
            Me.fraUpdate.Visible = False
            blnUpdated = True
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            QueryBillOfLading(mFilter, , index)

        End If


        Exit Sub
Err_Renamed:

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
        'neu da co phi bill thi khong cho xoa Bill
        strQuery = "Select count(*) cnt from PRICEBILLMASTER WHERE BL_ID = '" & Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString & "'  "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEmpty = (rs.Fields("cnt").Value = 0)
        rs.Close()
        If Not blnEmpty Then
            DisplayMessage(True, "The BillOFLading can not be removed. There are transactions that relate to this customer.")
            Exit Sub
        End If



        strQuery = "Select * from BILLOFLADING WHERE BL_ID = '" & Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Bill can not be removed.", "Không Thể Xoá Bill Này"))
            Exit Sub
        End If


        If Not IsNothing(Me.dgdBillOfLading.Item("Approve", index)) Then
            If Me.dgdBillOfLading.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdBillOfLading.Item("Editable", index)) Then
            If Not Me.dgdBillOfLading.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListBillOfLadingMaster", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the BillOFLading: " & Me.dgdBillOfLading.Item("BL_No", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from BillOFLading where" + " BL_Id= '" & Me.dgdBillOfLading.Item("BL_Id", index).Value.ToString & "'"
                rsBillOfLadingList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsBillOfLadingList.Fields("continued").Value = 0
                rsBillOfLadingList.Update()

                rsBillOfLadingList.Requery()
                Me.dgdBillOfLading.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdBillOfLading.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsBillOfLadingList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub smnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
             Me.dgdBillOfLading.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdBillOfLading.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryBillOfLading(" " & mFilter)

    End Sub
#End Region

#Region "Xử Lý Mnu View"

    Public Sub UpdateFrame()
        On Error GoTo Err_Renamed

        Me.dgdBillOfLading.Columns.Item("BL_ID").Visible = False

        Me.dgdBillOfLading.Columns.Item("SaleName").Visible = Me.smnuDisplaySaleName.Checked

        Me.dgdBillOfLading.Columns.Item("NotifyName").Visible = Me.smnuDisplayNotifyName.Checked
        Me.dgdBillOfLading.Columns.Item("SCAC_CODE").Visible = Me.smnuDisplayServiceContract.Checked

        Me.dgdBillOfLading.Columns.Item("ToTalContainer").Visible = Me.smnuDisplayToTalContainer.Checked
        Me.dgdBillOfLading.Columns.Item("PreightCharges").Visible = Me.smnuDisplayPreightCharges.Checked
        Me.dgdBillOfLading.Columns.Item("Pre_Vessel").Visible = Me.smnuDisplayPreCarriage.Checked

        Me.dgdBillOfLading.Columns.Item("PLACE_OF_RECEIPT").Visible = Me.smnuDisplayPlaceOfReceipt.Checked

        'Me.dgdBillOfLading.Columns.Item("Vessel").Visible = Me.smnuDisplayOceanVessel.Checked

        Me.dgdBillOfLading.Columns.Item("PREPAIDAT").Visible = Me.smnuDisplayPrepaidAt.Checked

        Me.dgdBillOfLading.Columns.Item("DESCRIPTIONFORSHIPPER").Visible = Me.smnuDisplayDescriptionOfContentsForShipper.Checked

        Me.dgdBillOfLading.Columns.Item("SERVICECONTRACT").Visible = Me.smnuDisplayServiceContract.Checked


        'Me.dgdBillOfLading.Columns.Item("PORT_OF_LOADING").Visible = Me.smnuDisplayPortOfLoading.Checked
        Me.dgdBillOfLading.Columns.Item("CanVasserCode").Visible = Me.smnuDisplayCanVasserCode.Checked

        Me.dgdBillOfLading.Columns.Item("SCAC_Code").Visible = Me.smnuDisplaySCACCode.Checked

        Me.dgdBillOfLading.Columns.Item("PORT_OF_DISCHARGE").Visible = Me.smnuDisplayPortOfDischarge.Checked

        Me.dgdBillOfLading.Columns.Item("PLACE_OF_DELIVERY").Visible = Me.smnuDisplayPlaceOfDelivery.Checked

        Me.dgdBillOfLading.Columns.Item("PLACE_OF_DESTINATION").Visible = Me.smnuDisplayFinalDestination.Checked

        Me.dgdBillOfLading.Columns.Item("TOTALPREPAID_IN").Visible = Me.smnuDisplayTotalPrepaidIn.Checked

        Me.dgdBillOfLading.Columns.Item("REVENUETON").Visible = Me.smnuDisplayRevenueTons.Checked

        Me.dgdBillOfLading.Columns.Item("EXCHANGE_RATE").Visible = Me.smnuDisplayRate.Checked

        Me.dgdBillOfLading.Columns.Item("EDITABLE").Visible = False

        Me.dgdBillOfLading.Columns.Item("CONTINUED").Visible = False

        Me.dgdBillOfLading.Columns.Item("PREPAID_OR_COLLECT").Visible = Me.smnuDisplayPrepaid.Checked Or Me.smnuDisplayCollect.Checked

        'Me.dgdBillOfLading.Columns.Item("PREPAID_OR_COLLECT").Visible = Me.smnuDisplayCollect.Checked

        Me.dgdBillOfLading.Columns.Item("PAYABLE_AT").Visible = Me.smnuDisplayPrepaidAt.Checked

        Me.dgdBillOfLading.Columns.Item("PAYABLE_AT").Visible = Me.smnuDisplayPayableAt.Checked
        Me.dgdBillOfLading.Columns.Item("PLACE_OF_BL_ISSUE").Visible = Me.smnuDisplayPlaceOfIssue.Checked
        Me.dgdBillOfLading.Columns.Item("DATE_OF_ISSUE").Visible = Me.smnuDisplayDateOfIssue.Checked

        Me.dgdBillOfLading.Columns.Item("TOTALPREPAID_IN").Visible = Me.smnuDisplayTotalPrepaidIn.Checked

        Me.dgdBillOfLading.Columns.Item("NO_OF_ORIGINAL_BL").Visible = Me.smnuDisplayNoOfOrigineBL.Checked
        Me.dgdBillOfLading.Columns.Item("CreativeUser").Visible = Me.smnuDisplayCreativeUser.Checked
        Me.dgdBillOfLading.Columns.Item("CreativeDate").Visible = Me.smnuDisplayCreativeDate.Checked

        Me.dgdBillOfLading.Columns.Item("APPROVE").Visible = Me.smnuDisplayApprove.Checked
        Me.dgdBillOfLading.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdBillOfLading.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    'Private Sub smnuDisplayConsigneeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayConsigneeName.Checked = Not Me.smnuDisplayConsigneeName.Checked
    '    UpdateFrame()

    'End Sub

    Private Sub smnuDisplayNotifyName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNotifyName.Click
        Me.smnuDisplayNotifyName.Checked = Not Me.smnuDisplayNotifyName.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayServiceContract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayServiceContract.Click
        Me.smnuDisplayServiceContract.Checked = Not Me.smnuDisplayServiceContract.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPreCarriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPreCarriage.Click
        Me.smnuDisplayPreCarriage.Checked = Not Me.smnuDisplayPreCarriage.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPlaceOfReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPlaceOfReceipt.Click
        Me.smnuDisplayPlaceOfReceipt.Checked = Not Me.smnuDisplayPlaceOfReceipt.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayOceanVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayOceanVessel.Click
        Me.smnuDisplayOceanVessel.Checked = Not Me.smnuDisplayOceanVessel.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayVoyNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayVoyNo.Click
        Me.smnuDisplayVoyNo.Checked = Not Me.smnuDisplayVoyNo.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplaySaleName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySaleName.Click
        Me.smnuDisplaySaleName.Checked = Not Me.smnuDisplaySaleName.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPortOfLoading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPortOfLoading.Click
        Me.smnuDisplayPortOfLoading.Checked = Not Me.smnuDisplayPortOfLoading.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPortOfDischarge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPortOfDischarge.Click
        Me.smnuDisplayPortOfDischarge.Checked = Not Me.smnuDisplayPortOfDischarge.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPlaceOfDelivery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPlaceOfDelivery.Click
        Me.smnuDisplayPlaceOfDelivery.Checked = Not Me.smnuDisplayPlaceOfDelivery.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayFinalDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFinalDestination.Click
        Me.smnuDisplayFinalDestination.Checked = Not Me.smnuDisplayFinalDestination.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayDescriptionOfContentsForShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDescriptionOfContentsForShipper.Click
        Me.smnuDisplayDescriptionOfContentsForShipper.Checked = Not Me.smnuDisplayDescriptionOfContentsForShipper.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTotalNoContainerOrPackages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTotalNoContainerOrPackages.Click
        Me.smnuDisplayTotalNoContainerOrPackages.Checked = Not Me.smnuDisplayTotalNoContainerOrPackages.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPreightCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPreightCharges.Click
        Me.smnuDisplayPreightCharges.Checked = Not Me.smnuDisplayPreightCharges.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayRevenueTons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayToTalContainer.Click
        Me.smnuDisplayToTalContainer.Checked = Not Me.smnuDisplayToTalContainer.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayToTalConTainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRevenueTons.Click
        Me.smnuDisplayRevenueTons.Checked = Not Me.smnuDisplayRevenueTons.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplaySCACCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySCACCode.Click
        Me.smnuDisplaySCACCode.Checked = Not Me.smnuDisplaySCACCode.Checked
        UpdateFrame()
    End Sub


    Private Sub smnuDisplayCanVasserCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCanVasserCode.Click
        Me.smnuDisplayCanVasserCode.Checked = Not Me.smnuDisplayCanVasserCode.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayRate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayRate.Click
        Me.smnuDisplayRevenueTons.Checked = Not Me.smnuDisplayRevenueTons.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPrepaid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPrepaid.Click
        Me.smnuDisplayPrepaid.Checked = Not Me.smnuDisplayPrepaid.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCollect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCollect.Click
        Me.smnuDisplayCollect.Checked = Not Me.smnuDisplayCollect.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPrepaidAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPrepaidAt.Click
        Me.smnuDisplayPrepaidAt.Checked = Not Me.smnuDisplayPrepaidAt.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPayableAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPayableAt.Click
        Me.smnuDisplayPayableAt.Checked = Not Me.smnuDisplayPayableAt.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayPlaceOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPlaceOfIssue.Click
        Me.smnuDisplayPlaceOfIssue.Checked = Not Me.smnuDisplayPlaceOfIssue.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayDateOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDateOfIssue.Click
        Me.smnuDisplayDateOfIssue.Checked = Not Me.smnuDisplayDateOfIssue.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayTotalPrepaidIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTotalPrepaidIn.Click
        Me.smnuDisplayTotalPrepaidIn.Checked = Not Me.smnuDisplayTotalPrepaidIn.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNoOfOrigineBL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNoOfOrigineBL.Click
        Me.smnuDisplayNoOfOrigineBL.Checked = Not Me.smnuDisplayNoOfOrigineBL.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCreativeUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCreativeUser.Click
        Me.smnuDisplayCreativeUser.Checked = Not Me.smnuDisplayCreativeUser.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCreativeDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCreativeDate.Click
        Me.smnuDisplayCreativeDate.Checked = Not Me.smnuDisplayCreativeDate.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub
#End Region



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

    '            'Me.txtBillOfLading.Enabled = False


    '            Me.txtBillOfLadingId.Text = gBillOfLadingNumber
    '            If gBillOfLadingNumber <> "" And gBillOfLadingNumber <> "No BillNumber." Then

    '                Me.tagInformationCustomer.Visible = True

    '                Me.fraUpdate.Visible = True
    '                Me.dgdBillOfLading.Enabled = False

    '                ReFormat()
    '                SetMenu((False))
    '                mBillOfLadingId = DefaultValue
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

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtBillOfLading.Text)
        If Me.txtBillOfLading.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtBillOfLading.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdBillOfLading)
            '    Select Case cboFind.Text
            '        Case "BILLOFLADINGID"
            '            QueryBillOfLading("AND ( BL_No LIKE '" & strFilter & "') " & mFilter)
            '        Case "SHIPPER NAME"
            '            QueryBillOfLading("AND (Shipper_1 LIKE '" & strFilter & "')" & mFilter)


            '        Case "CONSIGNEE NAME"
            '            QueryBillOfLading("AND (CONSIGNEE_1 LIKE '" & strFilter & "') " & mFilter)

            '        Case "NOTIFY NAME"
            '            QueryBillOfLading("AND (NOTIFYNAME LIKE '" & strFilter & "') " & mFilter)
            '            If Me.smnuDisplayNotifyName.Checked = False Then
            '                Me.smnuDisplayNotifyName.Checked = True
            '            End If
            '            Me.dgdBillOfLading.Columns.Item("NOTIFYNAME").Visible = Me.smnuDisplayNotifyName.Checked
            '            UpdateFrame()

            '        Case "PLACE OF RECEIPT NAME"
            '            QueryBillOfLading("AND (PLACE_OF_RECEIPT_NAME LIKE '" & strFilter & "') " & mFilter)
            '            If Me.smnuDisplayPlaceOfReceipt.Checked = False Then
            '                Me.smnuDisplayPlaceOfReceipt.Checked = True
            '            End If
            '            Me.dgdBillOfLading.Columns.Item("PLACE_OF_RECEIPT").Visible = Me.smnuDisplayPlaceOfReceipt.Checked
            '            UpdateFrame()

            '    End Select
            'Else
            '    QueryBillOfLading(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

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

    Private Sub dgdBillOfLading_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBillOfLading.CellClick
        If Me.dgdBillOfLading.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
        BillID = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
    End Sub

    Private Sub dgdBillOfLading_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBillOfLading.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdBillOfLading.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.BindingContext(oTable).Position
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdBillOfLading.Columns(ColIndex).Name = "Approve" And Me.dgdBillOfLading.CurrentCellAddress().Y = index Then
            Call ApproveDetailBillOfLadingMaster()
        ElseIf Me.dgdBillOfLading.Columns(ColIndex).Name = "VIP" And Me.dgdBillOfLading.CurrentCellAddress().Y = index Then
            SetVip()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Function InsertRouting_House() As Boolean
        Dim rsHBL, rs As New ADODB.Recordset
        Dim strQuery As String = "SELECT * "
        strQuery = strQuery & "FROM BILLOFLADING_HOUSE "
        strQuery = strQuery & "WHERE BL_ID = '" & BillID & "'"
        rsHBL.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rsHBL.EOF Then
            Return False
        End If
        rsHBL.MoveFirst()
        While Not rsHBL.EOF
            strQuery = "Select * from Routing_House where BLH_ID='" & rsHBL.Fields("BLH_ID").Value.ToString & "' And BLH_ID <>'" & DefaultValue & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs

                .AddNew()
                .Fields("Routing_ID").Value = NewId()
                .Fields("BLH_ID").Value = rsHBL.Fields("BLH_ID").Value.ToString

                .Fields("Port_From").Value = Me.txtPortfromCode.Text.Trim()
                .Fields("From_Date").Value = Me.DTPFromDate.Value.Date
                .Fields("Port_To").Value = Me.txtPortToCode.Text.Trim
                .Fields("To_Date").Value = Me.DTPToDate.Value.Date


                .Fields("SEQ").Value = Me.txtSEQ.Text.Trim
                .Fields("MOT").Value = Me.txtMOT.Text.Trim
                .Fields("Vessel_Code").Value = Me.txtRoutingVesselCode.Text
                .Fields("VoyAge").Value = Me.txtRoutingVoyAge.Text.Trim
                .Update()

            End With
            rs.Close()
            rsHBL.MoveNext()
        End While
    End Function

    Private Sub cmdOKP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKP.Click
        On Error GoTo Err_Renamed
        If mStatusP = "Add" Or mStatusP = "Edit" Then

            If Me.cboItems.FindStringExact(Me.cboItems.Text) = -1 Then
                DisplayMessage(True, "The Item is invalid. ")
                Me.cboItems.Focus()
                Exit Sub
            End If
            If Me.cboPrepaidCollectP.FindStringExact(Me.cboPrepaidCollectP.Text) = -1 Then
                DisplayMessage(True, "The P/Collect is invalid. ")
                Me.cboPrepaidCollectP.Focus()
                Exit Sub
            End If
            If Me.cboCurrencyP.FindStringExact(Me.cboCurrencyP.Text) = -1 Then
                DisplayMessage(True, "The Currency is invalid. ")
                Me.cboCurrency.Focus()
                Exit Sub
            End If
            If Len(Me.txtUnitPrice.Text) = 0 Then
                DisplayMessage(True, "The Price is invalid. ")
                Me.txtUnitPrice.Focus()
                Exit Sub
            End If

            If Len(Me.txtQuantityBIll.Text) = 0 Then
                DisplayMessage(True, "The Quantity is invalid. ")
                Me.txtQuantityBIll.Focus()
                Exit Sub
            End If

            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset

            Dim indexBL As Integer = 0
            If Me.dgdBillOfLading.RowCount > 0 Then
                indexBL = Me.dgdBillOfLading.CurrentRow.Index()
            End If
            Dim index As Integer = -1
            If Me.dgdPrice.RowCount > 0 Then
                index = Me.dgdPrice.CurrentRow.Index()
            End If
            If mStatus = "Edit" Then
                CopyValues("PRICEBILLMASTER", "charge_ID", FindValueID(Me.cboItems, Me.cboItems.Text))
            End If
            If mStatusP = "Add" Then
                strQuery = "Select * from PRICEBILLMASTER where charge_ID='" & FindValueID(Me.cboItems, Me.cboItems.Text) & "' And Continued=1 "
                If index <> -1 Then
                    strQuery = strQuery & " and BL_ID ='" & Me.dgdPrice.Item("BL_IDP", index).Value.ToString & "'"
                Else
                    strQuery = strQuery & " and BL_ID ='" & Me.dgdBillOfLading.Item("BL_ID", indexBL).Value.ToString & "'"
                End If


                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                If Not rs.EOF Then
                    DisplayMessage(True, "This Item Had Added")
                    Exit Sub
                End If
                rs.Close()
            End If

            Dim indexBill As Integer = Me.dgdBillOfLading.CurrentRow.Index

            'If mStatusP = "Add" Then
            '    strQuery = "SELECT * "
            '    strQuery = strQuery & "FROM PriceBillMaster "
            '    strQuery = strQuery & "WHERE BL_Id = '" & BillID & "' AND Items='" & Me.cbo.Text & "'"
            'Else
            strQuery = "Select * from PriceBillMaster where Price_id='" & mPrice_ID & "'"
            'End If
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


            With rs
                If mStatusP = "Add" Then
                    .AddNew()
                    .Fields("Price_ID").Value = NewId()

                    .Fields("BL_ID").Value = "{" & BillID & "}"
                End If
                .Fields("Charge_ID").Value = "{" & FindValueID(Me.cboItems, Me.cboItems.Text) & "}"
                mPrice_ID = .Fields("Price_ID").Value
                .Fields("Quantity").Value = Me.txtQuantityBIll.Text
                .Fields("IG_Code").Value = Me.txtIG_Code.Text
                .Fields("POP").Value = Me.txtPOP.Text
                .Fields("Prepaid_Collect").Value = Me.cboPrepaidCollectP.Text
                .Fields("Currency").Value = Me.cboCurrencyP.Text
                .Fields("UnitPrice").Value = Me.txtUnitPrice.Text
                .Update()

                'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
                'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

            End With
            rs.Close()
            If mStatusP = "Add" Then
                'InsertPrice_House(indexBill)' hàm đang bị lỗi
            End If
            RefreshPrice(False)
            '-----------------

            'mStatusP = "Normal"
            Me.dgdPrice.Enabled = True
            mStatusP = "Normal"
            Me.cmdOKP.Enabled = False
            QueryPrice(, indexBill)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Public Sub ApprovePrice()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim rs As New ADODB.Recordset
        Dim index As Integer = Me.dgdPrice.CurrentRow.Index
        Dim strQuery As String
        If Not Me.dgdPrice.Item("EditableP", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Execute") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPrice(, index)
        Else
            strQuery = "Select * from PriceBillMaster where" + " Price_Id= '" & Me.dgdPrice.Item("Price_ID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAdd.Click
        If Not UserRight("frmListBillOfLadingMaster", "Execute") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            Exit Sub
        End If
        mStatusP = "Add"
        Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
        BillID = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
        mPrice_ID = DefaultValue
        RefreshPrice(True)
        'Me.cmdOKP.Text = "Add"
    End Sub

    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelP.Click
        mStatusP = "Normal"
        RefreshPrice(False)

    End Sub
    Sub RefreshPrice(ByVal b As Boolean)
        On Error GoTo Err_Named
        Me.txtPOP.Enabled = b
        Me.txtQuantityBIll.Enabled = b
        Me.cboItems.Enabled = b
        Me.cboCurrencyP.Enabled = b
        Me.cboPrepaidCollectP.Enabled = b
        Me.txtUnitPrice.Enabled = b
        Me.cmdOKP.Enabled = b
        Me.txtIG_Code.Enabled = b

        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEdit.Click
        If Me.dgdPrice.RowCount <= 0 Then
            Return
        End If
        If Not UserRight("frmListBillOfLadingMaster", "Execute") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            Exit Sub
        End If
        mStatusP = "Edit"
        Dim Editable, Approve As Boolean
        Dim index As Integer
        If Me.oTable.Rows.Count >= 0 Then
            index = Me.dgdPrice.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            Approve = Me.dgdPrice.Item("ApproveP", index).Value
            Editable = Me.dgdPrice.Item("EditableP", index).Value
            If mStatusP = "Edit" And Not Approve And Editable And UserRight("frmListBillOfLadingMaster", "Edit") Then
                mPrice_ID = Me.dgdPrice.Item("Price_ID", index).Value.ToString
                RefreshPrice(True)

                Me.cboItems.Text = Me.dgdPrice.Item("Items", index).Value.ToString
                Me.txtPOP.Text = Me.dgdPrice.Item("POP", index).Value.ToString
                Me.txtQuantityBIll.Text = Me.dgdPrice.Item("Quantity", index).Value.ToString
                Me.txtIG_Code.Text = Me.dgdPrice.Item("IG_Code", index).Value.ToString.Trim

                Me.cboCurrencyP.Text = Me.dgdPrice.Item("CurrencyP", index).Value.ToString

                Me.cboPrepaidCollectP.Text = Me.dgdPrice.Item("PrePaid_Collect", index).Value.ToString


                Me.txtUnitPrice.Text = Me.dgdPrice.Item("UnitPrice", index).Value.ToString
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        End If



    End Sub

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        On Error GoTo Err_Named
        If Me.fraUpdate.Visible = True Then
            QueryItems()
            Me.dgdBillOfLading.Enabled = False
            mChargeID = DefaultValue

            If Me.dgdBillOfLading.RowCount > 0 Then
                Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
                BillID = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
                QueryPrice(" And BL_ID='" & BillID & "'", index, )
            End If
        Else
            mStatus = "Normal"
            Me.dgdBillOfLading.Enabled = True
        End If
        Exit Sub
Err_Named:
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

        If Not UserRight("frmListBillOfLadingMaster", "Execute") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Detail of Price: " & Me.dgdPrice.Item("Items", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from PriceBillMaster where Price_ID='" & Me.dgdPrice.Item("Price_ID", index).Value.ToString & "'"
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
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel.Click
        On Error GoTo err_named
        If Not UserRight("frmListBillOfLadingMaster", "Execute") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            Exit Sub
        End If
        If Me.dgdPrice.RowCount <= 0 Then
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
        If Me.dgdBillOfLading.RowCount > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
        End If
        QueryPrice(, index, )
        Exit Sub
err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub dgdPrice_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPrice.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdRouting.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdPrice.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        'MsgBox(Me.dgdPrice.CurrentCellAddress.X)
        If Me.dgdPrice.Columns(ColIndex).Name = "ApproveP" And Me.dgdPrice.CurrentCellAddress().Y = RowIndex Then
            Call ApprovePrice()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub




    Private Sub mnuBillOfLading_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBillOfLading.Click
        On Error GoTo Err_Renamed
        If Me.dgdBillOfLading.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
            gBillOfLadingRpt = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
            gBillNoRpt = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString
            frmRptMasterBill.rptName = ""
            VB6.ShowForm(frmRptMasterBill, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuManifest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManifest.Click
        On Error GoTo Err_Renamed
        If Me.dgdBillOfLading.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
            gBillOfLadingRpt = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
            gBillNoRpt = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString

            VB6.ShowForm(frmShipperConfirm, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOKR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKR.Click
        On Error GoTo Err_Renamed
        If mStatusR = "Add" Or mStatusR = "Edit" Then

            If Me.txtSEQ.Text = "" Then
                DisplayMessage(True, "SEQ is invalid!, please input again! ")
                Me.txtSEQ.Focus()
            End If
            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = -1
            If Me.dgdBillOfLading.RowCount > 0 Then
                index = Me.dgdBillOfLading.CurrentRow.Index()
            Else
                Exit Sub
            End If

            ' Dim indexBill As Integer = Me.dgdBillOfLading.CurrentRow.Index

            'If mStatusP = "Add" Then
            '    strQuery = "SELECT * "
            '    strQuery = strQuery & "FROM PriceBillMaster "
            '    strQuery = strQuery & "WHERE BL_Id = '" & BillID & "' AND Items='" & Me.cbo.Text & "'"
            'Else
            strQuery = "Select * from Routing_master  where Routing_ID='" & ROUTINGID & "' And Continued=1"
            'End If
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


            With rs
                If mStatusR = "Add" Then
                    .AddNew()
                    .Fields("Routing_ID").Value = NewId()
                    .Fields("BL_ID").Value = "{" & BillID & "}"
                End If
                'mPrice_ID = .Fields("Price_ID").Value
                .Fields("Port_From").Value = Me.txtPortfromCode.Text.Trim()
                ' xu ly ngay
                'If (Me.chkFromDate.Checked) Then
                .Fields("From_Date").Value = Me.DTPFromDate.Value.Date
                'Else
                '.Fields("From_Date").Value = vbNull
                'End If
                ' xu ly ngay
                'If Me.chkTodate.Checked Then
                .Fields("To_Date").Value = Me.DTPToDate.Value.Date
                'Else
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
            If mStatusR = "Add" Then
                InsertRouting_House() ' hàm đang bị lỗi
            End If

            RefreshRouting(False)
            '-----------------

            'mStatusP = "Normal"
            Me.dgdPrice.Enabled = True
            mStatusR = "Normal"

            QueryRouting(index)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub RefreshRouting(ByVal b As Boolean)
        On Error GoTo Err_Named
        Me.txtPortToCode.Enabled = b
        Me.txtPortfromCode.Enabled = b

        Me.txtSEQ.Enabled = b
        Me.txtMOT.Enabled = b
        Me.cmdOKR.Enabled = b
        Me.txtRoutingVesselCode.Enabled = b
        Me.txtRoutingVoyAge.Enabled = b
        Exit Sub
Err_Named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub ctmnuAddR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAddR.Click
        On Error GoTo Err_Named
        mStatusR = "Add"
        ROUTINGID = DefaultValue
        RefreshRouting(True)
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
        If Not UserRight("frmListBillOfLadingMaster", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Detail of Routing : " & Me.dgdRouting.Item("From_Date", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from Routing_Master where Routing_ID='" & Me.dgdRouting.Item("Routing_ID", index).Value.ToString & "'"
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
        If mStatusR = "Normal" And Not approve And edittable And UserRight("frmListBillOfLadingMaster", "Edit") Then
            mStatusR = "Edit"
            ROUTINGID = Me.dgdRouting.Item("Routing_ID", index).Value.ToString
            RefreshRouting(True)
            'If Me.dgdRouting.Item("To_Date", index).Value.ToString <> "" Then
            Me.DTPToDate.Text = Me.dgdRouting.Item("To_Date", index).Value.ToString
            'Me.chkTodate.Checked = True
            'Else
            'Me.chkTodate.Checked = False
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
        Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
        Dim strQuery As String
        If Not Me.dgdRouting.Item("EditableR", index).Value Or Not UserRight("frmListBillOfLadingMaster", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryRouting(index)
        Else
            strQuery = "Select * from Routing_Master where" + " Routing_ID= '" & Me.dgdRouting.Item("Routing_ID", index).Value.ToString & "'"
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
        If Me.dgdBillOfLading.RowCount > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
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

    Private Sub cmdCancelR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelR.Click
        On Error GoTo Err_Named
        mStatusR = "Normal"
        RefreshRouting(False)
        Exit Sub
Err_Named:
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

    Sub QueryVesselInfo(ByRef dt As DataTable) 'Lay du Lieu Vessel Ra de in File

        On Error GoTo Err_Renamed
        Dim strQuery As String

        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        strQuery = "Select Vessel_Code,Vessel,NATIONALITY,Sailingschedule.VoyNo As VoyNo From (((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOflading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID) "
        strQuery &= " LEFT JOIN Sailingschedule On Sailingschedule.SailingscheduleID=ContainerOutboundNotify.SailingscheduleID) LEFT JOIN "
        strQuery &= " Vessel On Sailingschedule.Vessel_ID=Vessel.Vessel_ID) Where BillofLading.BL_ID='" & gBillOfLadingRpt & "' And BillOfLading.Continued=1"
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
        strQuery = "Select * from Routing_Master where BL_ID='" & gBillOfLadingRpt & "' And Continued=1 Order BY SEQ ASC"

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

    Sub QueryUnit(ByRef otableUnit)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select CTN_SIZE_TYPE as type,Count(CTN_SIZE_TYPE) as Num from (container LEFT JOIN Cargo on Cargo.CTN_ID=Container.CTN_ID) where Cargo.BL_ID='" & gBillOfLadingRpt & "' And Cargo.Continued=1 Group by CTN_SIZE_TYPE"
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
    Sub QueryFreightCharge()
        On Error GoTo Err_Named
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Charge_Code,Charge,Currency,AMOUNT as UnitPrice,UNIT_OF_QUANTITY,Quantity,POP,Prepaid_collect,CONTAINER_TYPE,RATE_OF_FR_CH,PAYER_CODE,IG_CODE "
        strQuery &= ", Port_Code as PAYABLE_AT_CODE, Port As PAYABLE_AT  "
        strQuery &= "  from ((Freight_Charge_Master LEFT JOIN Charge On Freight_Charge_Master.Charge_Id=Charge.Charge_ID)"
        strQuery &= " INNER JOIN Port on Freight_Charge_Master.PAYABLE_AT_ID=Port.Port_ID) "
        strQuery &= " where BL_ID='" & gBillOfLadingRpt & "' And Freight_Charge_Master.Continued=1"
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

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM ((((BillOfLading LEFT JOIN Shipper On BillOfLading.Shipper_ID=Shipper.Shipper_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Consignee On Consignee.Consignee_ID=BillOfLading.Consignee_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Notify On Notify.Notify_ID=BillOfLading.Notify_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Party On Party.BL_ID=BillOfLading.BL_ID )"
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLading.BL_ID= '" & gBillOfLadingRpt & "' And BillOfLading.Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Sub QueryBillPrice(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Charge_Code,Charge,Currency,UnitPrice,Quantity,IG_CODE,POP,PrePaid_Collect "
        strQuery &= " from (PriceBillMaster LEFT JOIN Charge On PriceBillMaster.Charge_id=Charge.Charge_ID) "
        strQuery &= " Where BL_ID='" & gBillOfLadingRpt & "' And PriceBillMaster.Continued=1"
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

    Private Sub QueryHouseBill(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        strQuery = "Select BLH_NO from BillOfLading_House Where BL_ID='" & gBillOfLadingRpt & "' and Continued=1"
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
        'Resume
    End Sub

    Sub QueryCargoInfo(ByRef dt As DataTable)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select COMMODITY,COMMODITY_GROUP,HS_CODE,AMOUNT,TARIFF,KIND,Kind_Code,CTN_CARGO_MEASUREMENT as CBM,CONTAINER_TYPE,ReeferDegree,"
        strQuery &= " CARGO_SEQUENCE,CONTAINER_NO,SealNo,seal_no2,seal_no3,seal_no4,seal_no5,seal_no6,seal_no7,seal_no8,seal_no9,NUMBER_OF_PACKAGES,GROSS,CTN_STATUS,"
        strQuery &= " Container.NetWeight,TEMPERATURE_SETTING,TEMPERATURE_ID,SHIPPER_OWNED_UNIT,"
        strQuery &= " CARGO_RECEVING_DATE,Cargo.VENT,MIN_TEMPERATURE,MAX_TEMPERATURE  "
        ' TEMPERATURE_ID lay tu Cargo chu khong lay tu Cont
        ' Min,MAX temperature phai dua vao Cargo chu khong lay tu Cont
        strQuery &= " from ((Cargo LEFT JOIN Container On Cargo.CTN_ID=Container.CTN_ID)"
        strQuery &= " LEFT JOIN Seal On Cargo.SEAL_ID=SEAL.SEAL_ID) "
        strQuery &= " Where BL_ID='" & gBillOfLadingRpt & "' And cargo.Continued=1 Order by CARGO_SEQUENCE ASC"
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
        strQuery = "Select MARKS from CARGO_MARKS Where BL_ID='" & gBillOfLadingRpt & "'"
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
        strQuery = "Select CARGO_REMARKS from CARGO_REMARKS Where BL_ID='" & gBillOfLadingRpt & "'"
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
        strQuery = "Select Description from CARGO_DESCRIPTION Where BL_ID='" & gBillOfLadingRpt & "' "
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

    Sub QueryNotify(ByRef dt As DataTable, ByVal NotifyID As String)
        Dim strQuery As String
        strQuery = " Select top 1 Notify.Notify_Code,Notify.Notify_ID,Notify.Notify_1 ,Notify.Notify_2, Notify.Notify_3,Notify.Notify_4,Notify.Notify_5,Notify.Notify_6,Notify.Remarks  as RemarksNotify "
        strQuery &= " From (BillOfLading LEFT JOIN Notify On BillOfLading." & NotifyID & "=Notify.Notify_ID) "
        strQuery &= " Where BillofLading.Continued=1 And BL_ID='" & gBillOfLadingRpt & "' " 'And " & NotifyID & "<>'" & DefaultValue & "'"

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
    Sub QueryHouseCoLO(ByRef dt As DataTable)
        Try
            Dim strQuery As String
            strQuery = "Select * from HouseColoBillInfo Where Continued=1 And BL_ID='" & gBillOfLadingRpt & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub mnuManifestFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManifestFile.Click
        On Error GoTo Err_Named
        Dim index As Integer
        If Me.dgdBillOfLading.Rows.Count > 0 Then
            index = Me.dgdBillOfLading.CurrentRow.Index
        Else
            Exit Sub
        End If
        If Me.dgdBillOfLading.Item("BookingNO", index).Value.ToString = "" And Me.dgdBillOfLading.Item("SHIPPERNAME", index).Value.ToString = "" Then
            MsgBox("Bill chưa có đủ thông tin ")
            Return
        End If
        gBillNoRpt = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString
        gBillOfLadingRpt = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
        Dim path As String
        SaveFileDialog.InitialDirectory = "C:\"
        SaveFileDialog.Filter = "Notepad files (*.txt)|*.txt|All files (*.*)|*.*"
        SaveFileDialog.FileName = gBillNoRpt
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
        temp = "00:IFCSUM:MANIFEST:9: : :" & Strings.Right(Today.Year.ToString, 2) & IIf(Now().Month <= 9, "0" & Now().Month, Now().Month)
        temp &= IIf(Now().Day <= 9, "0" & Now.Day, Now.Day)
        temp &= IIf(Now().Hour <= 9, "0" & Now.Hour, Now.Hour)
        temp &= IIf(Now().Minute <= 9, "0" & Now.Minute, Now.Minute) & EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Record 10
        temp = "10:"
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Vessel_Code").ToString.Trim <> "", dt.Rows(0).Item("Vessel_Code").ToString.Trim, " ")) & ":"
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Vessel").ToString.Trim <> "", dt.Rows(0).Item("Vessel").ToString.Trim, " ")) & ":"
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("NATIONALITY").ToString.Trim <> "", dt.Rows(0).Item("NATIONALITY").ToString.Trim, " ")) & ":"
            temp &= ReplaceSym(dt.Rows(0).Item("VoyNo").ToString.Trim) & ":CSC" & EndRecord
            fw.WriteLine(temp)

        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'Record 12
        temp = "12:" & gBillNoRpt & ": : : :"
        'field 6
        temp &= ReplaceSym(IIf(Me.dgdBillOfLading.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_RECEIPT_CODE", index).Value.ToString.Trim, " ")) & ":"
        'field 7
        temp &= ReplaceSym(IIf(Me.dgdBillOfLading.Item("PLACE_OF_RECEIPT", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_RECEIPT", index).Value.ToString.Trim, " ")) & ":"
        'field 8
        temp &= ReplaceSym(IIf(Me.dgdBillOfLading.Item("PORT_OF_LOADING_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PORT_OF_LOADING_CODE", index).Value.ToString.Trim, " ")) & ":"
        'field 9
        temp &= ReplaceSym(IIf(Me.dgdBillOfLading.Item("PORT_OF_LOADING_NAME", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PORT_OF_LOADING_NAME", index).Value.ToString.Trim, " ")) & ":"
        'field 10
        If UCase(Me.dgdBillOfLading.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-CY*" Then
            Mean = "11"
        ElseIf UCase(Me.dgdBillOfLading.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-FO*" Then
            Mean = "19"
        ElseIf UCase(Me.dgdBillOfLading.Item("BL_CY_CFS_ITEM", index).Value.ToString.Trim) Like "*CY-RAMP*" Then
            Mean = "1R"
        Else
            Mean = "13"
        End If
        temp &= Mean & ":"
        'field 11
        If UCase(Me.dgdBillOfLading.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "COLLECT" Then
            temp &= "C"
        Else
            temp &= "P"
        End If
        temp &= ":"
        'field 12
        datetime = Me.dgdBillOfLading.Item("LOAD_DATE", index).Value
        temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month) & IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
        'field 13
        temp &= ":" & IIf(Me.dgdBillOfLading.Item("QUARANTINE_CODING", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("QUARANTINE_CODING", index).Value.ToString.Trim, " ") & ":"
        'field 14
        datetime = Me.dgdBillOfLading.Item("DATE_OF_ISSUE", index).Value
        temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month) & IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
        temp &= ":"
        'field 15
        temp &= IIf(Me.dgdBillOfLading.Item("CURRENCY", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("CURRENCY", index).Value.ToString.Trim, " ") & ":"
        'field 16
        temp &= ReplaceSym(IIf(Me.dgdBillOfLading.Item("EXCHANGE_RATE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("EXCHANGE_RATE", index).Value.ToString.Trim, " ")) & ":"
        'field 17
        temp &= IIf(Me.dgdBillOfLading.Item("MF_FILING_TYPE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("MF_FILING_TYPE", index).Value.ToString.Trim, " ") & ":"
        'field 18
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("NVOCC_MASTER_BL_NO", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("NVOCC_MASTER_BL_NO", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 19
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("SCAC_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("SCAC_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 20
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("TRADE_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("TRADE_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 21
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("BL_OTHER_REF", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("BL_OTHER_REF", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 22
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("BL_TYPE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("BL_TYPE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 23
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PAYABLE_AT", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PAYABLE_AT", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 24 
        If UCase(Me.dgdBillOfLading.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "COLLECT" Then
            temp &= "C"
        ElseIf UCase(Me.dgdBillOfLading.Item("PREPAID_OR_COLLECT", index).Value.ToString).Trim = "PREPAID" Then
            temp &= "S"
        Else
            temp &= "O"
        End If
        temp &= ":"
        'field 25
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("NO_OF_COPY_BL", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("NO_OF_COPY_BL", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 26
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("NO_OF_ORIGINAL_BL", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("NO_OF_ORIGINAL_BL", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 27
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("CUSTOMS_CLEARED_PLACE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("CUSTOMS_CLEARED_PLACE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 28
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("SLOT_SHARE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("SLOT_SHARE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 29 
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("US_SERVICE_MODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("US_SERVICE_MODE", index).Value.ToString.Trim, " "), ":", "?:")
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''
        'record 13
        'field 1
        temp = "13:"
        'field 2
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'fieldc3
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 4
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PLACE_OF_DELIVERY_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_DELIVERY_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 5
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PLACE_OF_DELIVERY", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_DELIVERY", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 6
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 7
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 8
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PLACE_OF_BL_ISSUE_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_BL_ISSUE_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 9
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PLACE_OF_BL_ISSUE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PLACE_OF_BL_ISSUE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 10
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("TRANSFER_PORT1", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("TRANSFER_PORT1", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 11
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("TRANSFER_PORT2", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("TRANSFER_PORT2", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 12
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("TRANSFER_PORT3", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("TRANSFER_PORT3", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 13
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("TRANSFER_PORT4", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("TRANSFER_PORT4", index).Value.ToString.Trim, " "), ":", "?:")
        temp &= EndRecord
        fw.WriteLine(temp)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 14

        QueryRoutingInfo(dt)
        Dim row As DataRow
        For Each row In dt.Rows
            temp = "14:"
            'field 1
            temp &= Strings.Replace(IIf(row.Item("Port_From").ToString.Trim <> "", row.Item("Port_From").ToString.Trim, " "), ":", "?:") & ":"
            'field 2
            datetime = row.Item("From_Date")
            temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month)
            temp &= IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day) & ":"
            'field 3
            temp &= IIf(row.Item("Port_To").ToString.Trim <> "", row.Item("Port_To").ToString.Trim, " ") & ":"
            'field 4
            datetime = row.Item("To_Date")
            temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month)
            temp &= IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
            temp &= ":"
            'field 5
            temp &= Strings.Replace(IIf(row.Item("Vessel_Code").ToString.Trim <> "", row.Item("Vessel_Code").ToString.Trim, " "), ":", "?:") & ":"
            'field 6
            temp &= Strings.Replace(IIf(row.Item("VoyAge").ToString.Trim <> "", row.Item("VoyAge").ToString.Trim, " "), ":", "?:") & ":"
            'field 7
            temp &= Strings.Replace(IIf(row.Item("SEQ").ToString.Trim <> "", row.Item("SEQ").ToString.Trim, " "), ":", "?:") & ":"
            'field 8
            temp &= Strings.Replace(IIf(row.Item("MOT").ToString.Trim <> "", row.Item("MOT").ToString.Trim, " "), ":", "?:")
            temp &= EndRecord
            fw.WriteLine(temp)
        Next
        'temp &= EndRecord
        'fw.WriteLine(temp)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 15
        Dim CountContainer As Integer = 0
        QueryUnit(dt)
        QueryFreightCharge()
        Dim RowUnit As DataRow
        Dim Container_Type As String
        For Each row In oTableFreightCharge.Rows
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
                    Container_Type = " "
            End Select
            temp = "15:"
            'field 2
            temp &= Strings.Replace(IIf(row.Item("Charge_Code").ToString <> "", row.Item("Charge_Code").ToString.Trim, " "), ":", "?:") & ":"
            'field 3
            temp &= Strings.Replace(IIf(row.Item("Charge").ToString <> "", Strings.Left(row.Item("Charge").ToString.Trim, 18), " "), ":", "?:") & ":"
            'field 4
            temp &= Strings.Replace(IIf(row.Item("PAYABLE_AT_CODE").ToString.Trim <> "", row.Item("PAYABLE_AT_CODE").ToString.Trim, " "), ":", "?:") & ":"
            'field 5
            temp &= Strings.Replace(IIf(row.Item("PAYABLE_AT").ToString.Trim <> "", row.Item("PAYABLE_AT").ToString.Trim, " "), ":", "?:") & ":"
            For Each RowUnit In dt.Rows
                If row.Item("Container_Type").ToString.Trim = RowUnit.Item("Type").ToString.Trim Then
                    'field 6
                    temp &= RowUnit.Item("Num").ToString & ":"
                    CountContainer = RowUnit.Item("Num")
                    Exit For
                End If
            Next
            'field 7
            temp &= Strings.Replace(IIf(row.Item("Currency").ToString.Trim <> "", row.Item("Currency").ToString.Trim, " "), ":", "?:") & ":"
            'field 8
            temp &= Strings.Replace(IIf(row.Item("UnitPrice").ToString.Trim <> "", row.Item("UnitPrice"), " "), ":", "?:") & ":"
            'field 9
            temp &= Strings.Replace(IIf(row.Item("UNIT_OF_QUANTITY").ToString.Trim <> "", row.Item("UNIT_OF_QUANTITY"), " "), ":", "?:") & ":"
            'field 10
            temp &= row.Item("UnitPrice") * CountContainer & ":"
            'field 11
            If UCase(row.Item("PREPAID_COLLECT").ToString).Trim = "POP.O" Then
                temp &= "O:"
            Else
                If UCase(row.Item("PREPAID_COLLECT").ToString.Trim) = "COLLECT" Then
                    temp &= "C:"
                Else
                    temp &= "P:"
                End If
            End If
            'field 12
            temp &= Container_Type & ":"
            'field 13
            temp &= Strings.Replace(IIf(row.Item("PAYER_CODE").ToString.Trim <> "", row.Item("PAYER_CODE").ToString.Trim, " "), ":", "?:") & ":"
            'field 14
            temp &= Strings.Replace(IIf(row.Item("IG_CODE").ToString.Trim <> "", row.Item("IG_CODE").ToString.Trim, " "), ":", "?:")
            temp &= EndRecord
            fw.WriteLine(temp)
        Next
        '''''''''' 
        ' kieu Container Theo chuan 1995
        'Price Bill (phi BIll)
        QueryBillPrice(dt)
        For Each row In dt.Rows

            temp = "15:"
            'field 2
            temp &= Strings.Replace(IIf(row.Item("Charge_Code").ToString <> "", row.Item("Charge_Code").ToString.Trim, " "), ":", "?:") & ":"
            'field 3
            temp &= Strings.Replace(IIf(row.Item("Charge").ToString <> "", Strings.Left(row.Item("Charge").ToString.Trim, 18), " "), ":", "?:") & ":"
            'field 4
            temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PAYABLE_AT", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PAYABLE_AT", index).Value.ToString.Trim, " "), ":", "?:") & ":"

            'field 5
            temp &= " :" 'payable  at name
            'field 6
            temp &= Strings.Replace(IIf(row.Item("Quantity").ToString.Trim <> "", row.Item("Quantity").ToString.Trim, " "), ":", "?:") & ":" 'phí bill không để số lương
            'field 7
            temp &= Strings.Replace(IIf(row.Item("Currency").ToString.Trim <> "", row.Item("Currency").ToString.Trim, " "), ":", "?:") & ":"
            'field 8
            temp &= Strings.Replace(IIf(row.Item("UnitPrice").ToString.Trim <> "", row.Item("UnitPrice").ToString.Trim, " "), ":", "?:") & ":"
            'field 9
            temp &= "BOX:"
            'field 10
            temp &= row.Item("UnitPrice") * row.Item("Quantity")
            temp &= ":"
            'field 11
            If UCase(row.Item("PREPAID_COLLECT").ToString).Trim = "POP.O" Then
                temp &= "O:"
            Else
                If UCase(row.Item("PREPAID_COLLECT").ToString.Trim) = "COLLECT" Then
                    temp &= "C:"
                Else
                    temp &= "P:"
                End If
            End If
            'field 12
            temp &= "99BL:"
            'field 13
            temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("PAYER_CODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("PAYER_CODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
            'field 14
            temp &= Strings.Replace(IIf(row.Item("IG_CODE").ToString.Trim <> "", row.Item("IG_CODE").ToString.Trim, " "), ":", "?:")
            temp &= EndRecord
            fw.WriteLine(temp)
        Next
        '''''''''''''''''''''''''''''''''''''''''
        'record 16
        QueryCustomerInfo()
        temp = "16:"
        ' field 2
        If oTableCustomerInfo.Rows.Count > 0 Then
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("Shipper_Code").ToString.Trim <> "", oTableCustomerInfo.Rows(0).Item("Shipper_Code").ToString.Trim, " ")  'khong ro Du lieu VIP Shipper 
        End If
        temp &= ":"
        ' field 3-field 8 Shipper Description

        For i As Integer = 1 To 5
            Dim tempshipper, shipperContent As String
            tempshipper = "Shipper_" & i
            shipperContent = ReplaceSym(oTableCustomerInfo.Rows(0).Item(tempshipper).ToString.Trim)
            temp &= IIf(shipperContent <> "", shipperContent, " ") & ":"
        Next
        temp = temp.Remove(temp.Length - 1)
        temp &= EndRecord
        fw.WriteLine(temp)



        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 17
        temp = "17:"
        ' field 2
        If oTableCustomerInfo.Rows.Count > 0 Then
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("Consignee_Code").ToString.Trim <> "", oTableCustomerInfo.Rows(0).Item("Consignee_Code").ToString.Trim, " ")
        End If
        temp &= ":"
        ' field 3-field 8 consignee description
        For i As Integer = 1 To 5
            Dim tempConsginee, ConsgineeContent As String
            tempConsginee = "Consignee_" & i
            ConsgineeContent = ReplaceSym(oTableCustomerInfo.Rows(0).Item(tempConsginee).ToString.Trim)
            temp &= IIf(ConsgineeContent <> "", ConsgineeContent, " ") & ":"
        Next
        temp = temp.Remove(temp.Length - 1)
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 18
        temp = "18:"
        ' field 2
        If oTableCustomerInfo.Rows.Count > 0 Then
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("Notify_Code").ToString.Trim <> "", oTableCustomerInfo.Rows(0).Item("Notify_Code").ToString.Trim, " ")
        End If
        temp &= ":"
        ' field 3-field 8 Notify description
        For i As Integer = 1 To 5
            Dim tempNotify, NotifyContent As String
            tempNotify = "Notify_" & i
            NotifyContent = ReplaceSym(oTableCustomerInfo.Rows(0).Item(tempNotify).ToString.Trim)
            temp &= IIf(NotifyContent <> "", NotifyContent, " ") & ":"
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
                    temp &= IIf(dtNotify.Rows(0).Item("Notify_Code").ToString.Trim <> "", dtNotify.Rows(0).Item("Notify_Code").ToString.Trim, " ")
                End If
                temp &= ":"
                For K As Integer = 1 To 5
                    Dim Content As String = dtNotify.Rows(0).Item("Notify_" & K).ToString.Trim
                    temp &= ReplaceSym(IIf(Content <> "", Content, " ")) & ":"
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
                    temp &= IIf(dtNotify3.Rows(0).Item("Notify_Code").ToString.Trim <> "", dtNotify3.Rows(0).Item("Notify_Code").ToString.Trim, " ")
                End If
                temp &= ":"
                For K As Integer = 1 To 5
                    Dim Content As String = dtNotify3.Rows(0).Item("Notify_" & K).ToString.Trim
                    temp &= ReplaceSym(IIf(Content <> "", Content, " ")) & ":"
                Next
                temp = temp.Remove(temp.Length - 1) & "'"
                fw.WriteLine(temp)
            End If
        End If

        'record 21 BL_Clause
        Dim oTableBL_Clause As New DataTable
        oTableBL_Clause = QueryBL_Clause(Me.dgdBillOfLading.Item("BL_ClauseID", index).Value.ToString)

        If Not IsNothing(oTableBL_Clause) Then
            If oTableBL_Clause.Rows.Count > 0 Then
                temp = "21:"
                temp &= oTableBL_Clause.Rows(0).Item("BL_ClauseCode").ToString & ":"
                temp &= ReplaceSym(oTableBL_Clause.Rows(0).Item("BL_ClauseText").ToString)
                temp &= EndRecord
                fw.WriteLine(temp)
            End If
        End If


        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'record 23
        If oTableCustomerInfo.Rows(0).Item("PartyType").ToString <> "" Then
            'If "{" & oTableCustomerInfo.Rows(0).Item("PartyID").ToString & "}" <> DefaultValue Then
            temp = "23:"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyType").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyType").ToString, " ") & ":"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyCode").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyCode").ToString, " ") & ":"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyAddress1").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyAddress1").ToString, " ") & ":"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyAddress2").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyAddress2").ToString, " ") & ":"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyAddress3").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyAddress3").ToString, " ") & ":"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyAddress4").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyAddress4").ToString, " ") & ":"
            temp &= IIf(oTableCustomerInfo.Rows(0).Item("PartyAddress5").ToString <> "", oTableCustomerInfo.Rows(0).Item("PartyAddress5").ToString, " ")
            temp &= "'"
            fw.WriteLine(temp)
            'End If
        End If

        temp = "23:"
        'field 2
        temp &= "CA:"
        'field 3 
        temp &= Strings.Replace(IIf(Me.dgdBillOfLading.Item("CANVASSERCODE", index).Value.ToString.Trim <> "", Me.dgdBillOfLading.Item("CANVASSERCODE", index).Value.ToString.Trim, " "), ":", "?:") & ":"
        'field 4
        temp &= "" '
        temp &= EndRecord
        fw.WriteLine(temp)
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
                    Container_Type = " "

            End Select
            TotalAmount += IIf(row.Item("Amount").ToString <> "", row.Item("Amount"), 0)
            TotalCBM += IIf(row.Item("CBM").ToString.Trim <> "", row.Item("CBM"), 0)
            TotalGross += IIf(row.Item("Gross").ToString.Trim <> "", row.Item("Gross"), 0)

        Next
        temp = "41:"
        'field 2
        'temp &= Strings.Replace(IIf(row.Item("CARGO_SEQUENCE").ToString.Trim <> "", row.Item("CARGO_SEQUENCE").ToString.Trim, " "), ":", "?:") & ":"
        temp &= "1:"
        'If TbCargo.Rows.Count > 0 Then
        row = TbCargo.Rows(0)

        'filed 3
        temp &= Strings.Replace(IIf(row.Item("COMMODITY_GROUP").ToString.Trim <> "", row.Item("COMMODITY_GROUP").ToString.Trim, " "), ":", "?:") & ":"
        'field 4
        temp &= Strings.Replace(IIf(row.Item("Commodity").ToString.Trim <> "", row.Item("Commodity").ToString.Trim, " "), ":", "?:") & ":"
        'field 5
        'temp &= IIf(row.Item("Amount").ToString <> "", row.Item("Amount").ToString.Trim, " ") & ":"
        temp &= FormatNumber(TotalAmount, 0, , , TriState.False).ToString & ":"
        'filed 6
        temp &= Strings.Replace(IIf(row.Item("KIND_CODE").ToString.Trim <> "", row.Item("KIND_CODE").ToString.Trim, " "), ":", "?:") & ":"
        'field 7
        temp &= Strings.Replace(IIf(row.Item("KIND").ToString.Trim <> "", row.Item("KIND").ToString.Trim, " "), ":", "?:") & ":"
        'field 8
        'temp &= Strings.Replace(IIf(row.Item("GROSS").ToString.Trim <> "", row.Item("GROSS").ToString.Trim, " "), ":", "?:") & ":"
        temp &= FormatNumber(TotalGross, 2, , , TriState.False).ToString & ":"
        'field 9
        temp &= "0.00:" 'chu ro du lieu
        'field 10
        'temp &= FormatString(CDbl(IIf(row.Item("CBM").ToString.Trim <> "", row.Item("CBM").ToString.Trim, " "))) & ":"
        temp &= FormatNumber(TotalCBM, 3, , , TriState.False).ToString & ":"
        'field 11
        temp &= Container_Type & ":" 'vi tong nen khong biet dua loai container nao vao
        'field 12
        temp &= Strings.Replace(IIf(row.Item("TARIFF").ToString.Trim <> "", row.Item("TARIFF").ToString.Trim, " "), ":", "?:") & ":"
        'field 13
        temp &= Strings.Replace(IIf(row.Item("HS_CODE").ToString.Trim <> "", row.Item("HS_CODE").ToString.Trim, " "), ":", "?:")
        temp &= EndRecord
        fw.WriteLine(temp)

        ''''''''''''''''''''''''''''''''''''
        'recrord 44
        QueryCargoMarks(dt)

        temp = "44:"
        'field 2
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Marks").ToString.Trim <> "", dt.Rows(0).Item("Marks").ToString.Trim, " ")) ', ":", "?:")
            'temp = Strings.Replace(temp, Chr(13), "^n")
        End If
        temp &= EndRecord

        fw.WriteLine(temp)
        '''''''''''''''''''''''''''
        'record 47
        QueryCargoDescription(dt)

        temp = "47:"
        'field 2
        Dim tempremarks As String = ""
        If dtNotify.Rows.Count > 0 Then
            tempremarks = ReplaceSym(IIf(dtNotify.Rows(0).Item("RemarksNotify").ToString.Trim <> "", dtNotify.Rows(0).Item("Notify_Code").ToString.Trim, " "))
        End If
        If dtNotify3.Rows.Count > 0 Then
            tempremarks += ReplaceSym(IIf(dtNotify3.Rows(0).Item("RemarksNotify").ToString.Trim <> "", dtNotify3.Rows(0).Item("Notify_Code").ToString.Trim, " "))
        End If
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym(IIf(dt.Rows(0).Item("Description").ToString.Trim <> "", dt.Rows(0).Item("Description").ToString.Trim, " ")) + ReplaceSym(oTableCustomerInfo.Rows(0).Item("RemarksShipper").ToString.Trim) + ReplaceSym(oTableCustomerInfo.Rows(0).Item("RemarksConsignee").ToString.Trim) + ReplaceSym(oTableCustomerInfo.Rows(0).Item("RemarksNotify").ToString.Trim) + tempremarks ', ":", "?:")
            'temp = Strings.Replace(temp, Chr(13), "^n")
        End If
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''
        'record 48
        QueryCargoReMarks(dt)
        temp = "48:"
        If dt.Rows.Count > 0 Then
            temp &= ReplaceSym((IIf(dt.Rows(0).Item("Cargo_ReMarks").ToString.Trim <> "", dt.Rows(0).Item("Cargo_ReMarks").ToString.Trim, " "))) ', ":", "?:")
        End If
        temp &= EndRecord
        fw.WriteLine(temp)
        '''''''''''''''''''''''''''''''''''''''''''''''
        'record 51
        Dim tempi As Integer = 0
        For Each row In TbCargo.Rows
            'field 1
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
                    Container_Type = " "
            End Select
            temp = "51:"
            tempi += 1
            'field 2
            temp &= IIf(row.Item("CARGO_SEQUENCE").ToString.Trim <> "", row.Item("CARGO_SEQUENCE").ToString.Trim, " ") & ":"
            'field 3
            temp &= IIf(row.Item("CONTAINER_NO").ToString.Trim <> "", row.Item("CONTAINER_NO").ToString.Trim, " ") & ":"
            'field 4
            temp &= IIf(row.Item("SEALNO").ToString.Trim <> "", row.Item("SEALNO").ToString.Trim, " ") & ":"
            'field 5
            temp &= Container_Type & ":"
            'field 6
            temp &= IIf(row.Item("CTN_STATUS").ToString.Trim <> "", row.Item("CTN_STATUS").ToString.Trim, " ") & ":" 'tinh trang conatiner chua ro du lieu
            'field 7
            temp &= IIf(row.Item("AMount").ToString.Trim <> "", row.Item("Amount").ToString.Trim, " ") & ":"
            'field 8
            temp &= IIf(row.Item("GROSS").ToString.Trim <> "", row.Item("GROSS").ToString.Trim, " ") & ":"
            'field 9
            temp &= IIf(row.Item("NETWEIGHT").ToString.Trim <> "", row.Item("NETWEIGHT").ToString.Trim, " ") & ":"
            'field 10
            temp &= FormatString(CDbl(IIf(row.Item("CBM").ToString.Trim <> "", row.Item("CBM").ToString.Trim, " "))) & ":"
            'field 11
            temp &= Strings.Replace(IIf(row.Item("TEMPERATURE_ID").ToString.Trim <> "", row.Item("TEMPERATURE_ID").ToString.Trim, " "), ":", "?:") & ":"
            'field 12
            temp &= Strings.Replace(IIf(row.Item("TEMPERATURE_SETTING").ToString.Trim <> "", row.Item("TEMPERATURE_SETTING").ToString.Trim, " "), ":", "?:") & ":"
            'field 13
            temp &= Strings.Replace(IIf(row.Item("MIN_TEMPERATURE").ToString.Trim <> "", row.Item("MIN_TEMPERATURE").ToString.Trim, " "), ":", "?:") & ":"
            'field 14
            'nhiet do lay tu cargo 
            temp &= Strings.Replace(IIf(row.Item("MAX_TEMPERATURE").ToString.Trim <> "", row.Item("MAX_TEMPERATURE").ToString.Trim, " "), ":", "?:") & ":"
            'field 15
            temp &= Strings.Replace(IIf(row.Item("VENT").ToString.Trim <> "", row.Item("VENT").ToString.Trim, " "), ":", "?:") & ":"
            'field 16
            temp &= IIf(row.Item("SHIPPER_OWNED_UNIT").ToString.Trim <> "", row.Item("SHIPPER_OWNED_UNIT").ToString.Trim, " ") & ":"
            'field 17

            If row.Item("CARGO_RECEVING_DATE").ToString <> "" Then
                datetime = row.Item("CARGO_RECEVING_DATE").ToString
                temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month)
                temp &= IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day) & ":"
                '----
            Else
                temp &= " : "
            End If
            temp &= row.Item("seal_no2").ToString.Trim & ":"
            temp &= row.Item("seal_no3").ToString.Trim & ":"
            temp &= row.Item("seal_no4").ToString.Trim & ":"
            temp &= row.Item("seal_no5").ToString.Trim & ":"
            temp &= row.Item("seal_no6").ToString.Trim & ":"
            temp &= row.Item("seal_no7").ToString.Trim & ":"

            temp &= row.Item("seal_no8").ToString.Trim & ":"
            temp &= row.Item("seal_no9").ToString.Trim & "'"

            '----
            fw.WriteLine(temp)
        Next

        '''''''''''''''''''''''''''''''''''''''''''''''''
        'record 61
        QueryHouseCOLO(dt)
        '''''''''''''''if AMS By CSCL thi khong Can house
        For Each row In dt.Rows
            temp = "61:"
            'field 2
            temp &= row.Item("BLH_NO").ToString & ":"
            'field 3
            temp &= row.Item("NoOfPakages").ToString & ":"
            temp &= row.Item("ColoBill").ToString

            temp &= EndRecord
            fw.WriteLine(temp)

        Next
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


    Private Sub cboRepaid_Collect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRepaid_Collect.SelectedIndexChanged, cboBL_CY_CFS_Item.SelectedIndexChanged
        Me.cboPrepaidCollectP.Text = Me.cboRepaid_Collect.Text
    End Sub

    '    Private Sub cboPortTo_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.txtPortToCode.Text = Trim(UCase(Me.txtPortToCode.Text))
    '        strSql = "Select Port_code as code From Port Where Continued=1"
    '        If Me.txtPortToCode.FindStringExact(Me.txtPortToCode.Text) = -1 Then
    '            Me.txtPortToCode.Text = FindBetter_new("code", strSql, Me.txtPortToCode.Text)
    '            If Me.txtPlofReceiptCode.FindStringExact(Me.cboPortTo.Text) = -1 Then
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
    '                Me.txtporttoName.Text = oTablePort.Rows(i).Item("Port").ToString
    '                Exit For
    '            End If
    '        Next

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboPortfrom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '        On Error GoTo Err_Renamed
    '        Dim Port_ID As String
    '        Dim i As Integer
    '        Port_ID = FindValueID(Me.txtPortfromCode, Me.txtPortfromCode.Text)
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
    Sub QueryCustomer()
        Try
            Dim SQL As String
            SQL = "Select Customer_ID as Value ,Company  as Display From Customer Where Continued=1 Order By Company"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboCustomer.DisplayMember = "Display"
            Me.cboCustomer.ValueMember = "Value"

            Me.cboCustomer.DataSource = dt

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub mnuFreightNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFreightNote.Click
        On Error GoTo Err
        If Me.dgdBillOfLading.RowCount > 0 Then
            QueryCustomer()

            Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
            gBillOfLadingRpt = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
            gBillNoRpt = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString

            'lấy thông shipper
            Dim SQL As String
            SQL = "select * from Shipper Where Shipper_ID='" & Me.dgdBillOfLading.Item("Shipper_ID", index).Value.ToString & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                Me.txtMessrs.Text = dt.Rows(0).Item("Shipper_1").ToString & Chr(13) & Chr(10)
                Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_2").ToString & Chr(13) & Chr(10)
                Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_3").ToString & Chr(13) & Chr(10)
                Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_4").ToString & Chr(13) & Chr(10)
                Me.txtMessrs.Text &= dt.Rows(0).Item("Shipper_5").ToString & Chr(13) & Chr(10)
                Me.txtMessrs.Text &= dt.Rows(0).Item("Remarks").ToString '& Chr(13) & Chr(10)

                Me.fraFreightNote.Visible = True
                Me.fraFreightNote.BringToFront()

            End If

        End If
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOkFreightNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkFreightNote.Click
        On Error GoTo Err
        Me.fraFreightNote.Visible = False
        frmRptFreightNoteOutbound.ShowDialog()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelFreightnote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelFreightnote.Click
        On Error GoTo Err
        Me.fraFreightNote.Visible = False
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryBillOfLading("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdBillOfLading.Rows.Count > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdBillOfLading, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub mnuTripAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTripAccount.Click
        On Error GoTo Err
        Dim index As Integer
        'If Me.dgdBillOfLading.Rows.Count > 0 Then
        '    index = Me.dgdBillOfLading.CurrentRow.Index
        'Else
        '    Exit Sub
        'End If
        VB6.ShowForm(frmTripAccountOutbound, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuFreightSettle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFreightSettle.Click
        On Error GoTo Err
        VB6.ShowForm(frmFreightSettleOutbound, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuSummaryReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSummaryReport.Click
        On Error GoTo Err
        VB6.ShowForm(frmSummaryReportOutbound, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuManifestAmendmentFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManifestAmendmentFee.Click
        On Error GoTo Err
        VB6.ShowForm(frmReportAmendMentfee, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuTripAccountSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTripAccountSummary.Click
        On Error GoTo Err
        VB6.ShowForm(frmTripAccountSummaryOutbound, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
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
            gSCombo = Me.txtPortfromCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuPortTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortTo.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.txtPortToCode.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub cxtsmnuConsignee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtCargo.Click
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

    Private Sub mnuOutboundCommissionReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOutboundCommissionReport.Click
        On Error GoTo Err
        VB6.ShowForm(frmOutboundCommission, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdBillOfLading_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBillOfLading.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdBillOfLading)
    End Sub

    Private Sub dgdPrice_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPrice.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdPrice)
    End Sub

    Private Sub mnuBillOfLadingdata_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBillOfLadingdata.Click
        On Error GoTo Err_Renamed
        If Me.dgdBillOfLading.RowCount > 0 Then
            Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
            gBillOfLadingRpt = Me.dgdBillOfLading.Item("BL_ID", index).Value.ToString
            gBillNoRpt = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString
            frmRptMasterBill.rptName = "Data"


            VB6.ShowForm(frmRptMasterBill, VB6.FormShowConstants.Modal, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txtBillOfLading_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBillOfLading.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub mnuRefesh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRefesh.Click
        'Me.QueryShipperRefesh()
        'Me.QueryConsigneeRefesh()
        'Me.QueryNotifyRefesh()
        Me.QueryBillOfLading(" " & mFilter)
    End Sub

    Sub setCOLOItem(ByVal b As Boolean)
        Try
            Me.txtHouseBLNumber.Enabled = b
            Me.txtColoBLNO.Enabled = b
            Me.txtNumOfPackages.Enabled = b
            Me.cmdOkHouseCOLO.Enabled = b
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ctmnuAddHouseCOLO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAddHouseCOLO.Click
        setCOLOItem(True)
        mHouseCOLOstatus = "Add"
        mHouseCOLOID = DefaultValue

    End Sub
    Sub RefreshHouseCOLO(ByVal index As Integer)
        Try
            Me.txtHouseBLNumber.Text = Me.dgdHouseCOLO.Item("BLH_NO", index).Value.ToString
            Me.txtNumOfPackages.Text = Me.dgdHouseCOLO.Item("NoOfPakages", index).Value.ToString
            Me.txtColoBLNO.Text = Me.dgdHouseCOLO.Item("COLOBILL", index).Value.ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub ctmnuEditHouseCOLO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEditHouseCOLO.Click
        If Me.dgdHouseCOLO.Rows.Count = 0 Or IsNothing(Me.dgdHouseCOLO.CurrentRow) Then
            Return
        End If
        Dim index As Integer = Me.dgdHouseCOLO.CurrentRow.Index
        mHouseCOLOID = Me.dgdHouseCOLO.Item("HouseColoBillInfoID", index).Value.ToString
        mHouseCOLOstatus = "Edit"
        RefreshHouseCOLO(index)
        setCOLOItem(True)
    End Sub

    Private Sub cmdCancelHouseColo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelHouseColo.Click
        setCOLOItem(False)
        mHouseCOLOstatus = "Normal"
    End Sub

    Private Sub cmdOkHouseCOLO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkHouseCOLO.Click
        If mHouseCOLOstatus = "Normal" Then
            Return
        End If
        If mHouseCOLOstatus = "Add" Then
            For i As Integer = 0 To Me.dgdHouseCOLO.Rows.Count - 1
                If Me.txtHouseBLNumber.Text.Trim = Me.dgdHouseCOLO.Item("BLH_NO", i).Value.ToString.Trim Then
                    MsgBox("This House Bill Already In database ")
                    Return
                End If
            Next
        End If

        If mStatus = "Edit" Then
            CopyValues("HouseColoBillInfo", "HouseColoBillInfoID", mHouseCOLOID)
        End If
        Dim rs As New ADODB.Recordset
        Dim strQuery As String = "Select * from HouseColoBillInfo Where HouseColoBillInfoID='" & mHouseCOLOID & "' And Continued=1"


        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        With rs
            If .EOF Then
                .AddNew()
                .Fields("HouseColoBillInfoID").Value = NewId()
                .Fields("BL_ID").Value = "{" & mBillOfLadingId & "}"
            End If
            .Fields("BLH_NO").Value = Me.txtHouseBLNumber.Text.Trim
            .Fields("NoOfPakages").Value = Me.txtNumOfPackages.Text
            .Fields("ColoBill").Value = Me.txtColoBLNO.Text.Trim
            .Update()
        End With
        rs.Close()
        QueryHouseCOLO()
        setCOLOItem(True)

    End Sub

    Public Sub DeleteRowHouseCOlO(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim blnEmpty As Boolean
        Dim strMesg As String
        Dim bm As Short

        strMesg = "Delete the Detail of House No : " & Me.dgdHouseCOLO.Item("BLH_NO", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            strQuery = "Select * from HouseColoBillInfo where HouseColoBillInfoID='" & Me.dgdHouseCOLO.Item("HouseColoBillInfoID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("continued").Value = 0
            rs.Update()
            Me.dgdHouseCOLO.Rows(index).DefaultCellStyle.ForeColor = Color.White
            Me.dgdHouseCOLO.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            rs.Close()
            blnUpdated = True
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuDelHouseCOLO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDelHouseCOLO.Click
        On Error GoTo err_named
        Dim selectedRowCount As Integer = _
    Me.dgdHouseCOLO.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowHouseCOlO(Me.dgdHouseCOLO.SelectedRows(i).Index)
            Next i
        End If
        Dim index As Integer = 0
        QueryHouseCOLO()
        Exit Sub
err_named:
        MsgBox(msgErr(Me, Err.Description))
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

    Private Sub mnuExportVIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportVIP.Click
        Try
            frmExportVip.ShowDialog()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ctmCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmCargo.Click
        Try
            If Me.dgdBillOfLading.RowCount = 0 Then
                Return
            End If
            Me.Cursor = Cursors.WaitCursor
            Dim index As Integer = Me.dgdBillOfLading.CurrentRow.Index
            Dim BillNo As String = Me.dgdBillOfLading.Item("BL_NO", index).Value.ToString.Trim
            If Me.tabCargoMaster.Controls.Item("ListCargoMaster") Is Nothing Then
                Dim Cargo As New UsrControlCargo
                Cargo.Name = "ListCargoMaster"
                Cargo.Dock = DockStyle.Fill
                Me.tabCargoMaster.Controls.Add(Cargo)
                Me.TabControl1.SelectTab(Me.tabCargoMaster)
                Cargo.cboBillofLading.Text = BillNo
            Else
                Dim Cargo As New UsrControlCargo
                Cargo = Me.tabCargoMaster.Controls.Item("ListCargoMaster")
                Cargo.cboBillofLading.Text = BillNo
                Me.TabControl1.SelectTab(Me.tabCargoMaster)

            End If

            'frmListCargoMaster.cboBillofLading.Text = BillNo
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub mnuFreightSettleOutBound1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFreightSettleOutBound1.Click
        On Error GoTo Err
        VB6.ShowForm(frmFreightSettleOutBound1, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub fraUpdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.Enter

    End Sub

    Private Sub tabBillFEE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabBillFEE.Click

    End Sub


    Private Sub chkVip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkVip.CheckedChanged
        Me.grpParty.Enabled = Me.chkVip.Checked()
        'If Not IsNothing(Me.dgdBillOfLading.Item("Partyid", Me.dgdBillOfLading.CurrentRow.Index)) Then
        '    PartyID = Me.dgdBillOfLading.Item("Partyid", Me.dgdBillOfLading.CurrentRow.Index).Value.ToString
        'End If
    End Sub

    Private Sub txtSEQ_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSEQ.Leave
        If Me.txtSEQ.Text = "2" Then
            Me.txtRoutingVesselCode.Text = Me.txtPreVessel.Text
            Me.txtRoutingVoyAge.Text = Me.txtPreVesselNo.Text
        Else
            Me.txtRoutingVesselCode.Text = ""
            Me.txtRoutingVoyAge.Text = ""
        End If
    End Sub

    Private Sub txtSEQ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSEQ.TextChanged

    End Sub

    Private Sub CBOcUSTOMER_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CBOcUSTOMER.SelectedIndexChanged
        Try
            Dim SQL As String
            SQL = "Select PIC as Value From PIC Where Customer_ID='" & Me.CBOcUSTOMER.SelectedValue.ToString & "' And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.txtMessrs.Text = Me.CBOcUSTOMER.Text
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.txtMessrs.Text &= Chr(13) & Chr(10) & dt.Rows(i).Item(0).ToString
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub CheckLoadingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckLoadingListToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmCheckLoadingList, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ManifestSummaryListEXCELToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManifestSummaryListEXCELToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmManifestSummary, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuManifestfileForVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuManifestfileForVessel.Click
        On Error GoTo Err
        VB6.ShowForm(frmManifestVessel, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuNotUpdateHouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNotUpdateHouse.Click
        update = False
        editbill()
    End Sub

    Private Sub mnuUpdateHouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUpdateHouse.Click
        update = True
        editbill()
    End Sub

    Sub CheckPort(ByRef Port_Code As TextBox, ByRef PortName As TextBox, ByRef strPortID As String)
        Try
            If Port_Code.Text = "" Then
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

    Private Sub txtPlofReceiptCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlofReceiptCode.Leave

        CheckPort(Me.txtPlofReceiptCode, Me.txtPlofReceiptName, POR_ID)
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

    Private Sub txtPlofReceiptCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlofReceiptCode.TextChanged

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


    Private Sub chkSalePayer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSalePayer.CheckedChanged
        If Me.chkSalePayer.Checked = True Then
            Me.txtResultSelect.Text = Me.txtSalePayer.Text
        End If

    End Sub

    Private Sub chkPayerShipper_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPayerShipper.CheckedChanged
        If Me.chkPayerShipper.Checked = True Then
            Me.txtResultSelect.Text = Me.txtPayerShipper.Text
        End If
    End Sub

    Private Sub chkApproveCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkApproveCustomer.CheckedChanged
        If Me.chkApproveCustomer.Checked = True Then
            Me.txtResultSelect.Text = Me.cboApprovePayerCustomer.Text
        End If
    End Sub

    Private Sub cmdChecking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdChecking.Click
        Checking = 1
        OkClick()
    End Sub

End Class