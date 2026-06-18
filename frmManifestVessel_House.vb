Imports System.IO
Public Class frmManifestVessel_House

    Dim oTable, oTableFreightCharge, oTableCustomerInfo As New DataTable

    Const strBILLOFLADING_HOUSESelect As String = "SELECT BILLOFLADING_HOUSE.BL_ID as BL_ID,BILLOFLADING_HOUSE.SHIPPER_ID AS SHIPPER_ID, Shipper.SHIPPER_1  as ShipperName, " & _
       "BILLOFLADING_HOUSE.BLH_ID as BLH_ID, BILLOFLADING_HOUSE.BLH_NO as BLH_NO, " & _
       "BILLOFLADING_HOUSE.CONSIGNEE_ID AS CONSIGNEE_ID , BILLOFLADING_HOUSE.BL_ClauseID," & _
       "Consignee.CONSIGNEE_1  as ConsigneeName, Vessel.Vessel as PreVessel, SailingSchedule.VoyNo as PreVoyNo, " & _
       "BILLOFLADING_HOUSE.Notify_Id AS Notify_Id, " & _
       "Notify.NOTIFY_1  as NotifyName, BILLOFLADING_HOUSE.NOTIFY2_ID,Notify2.NOTIFY_1  as Notify2Name, BILLOFLADING_HOUSE.NOTIFY3_ID,Notify3.NOTIFY_1  as Notify3Name," & _
       "BillOfLading_House.CANVASSERCODE," & _
       "BILLOFLADING_HOUSE.PLACE_OF_RECEIPT_ID AS PLACE_OF_RECEIPT_ID, BILLOFLADING_HOUSE.PLACE_OF_RECEIPT_CODE, PLACE_OF_RECEIPT_NAME, " & _
       "BILLOFLADING_HOUSE.BL_CY_CFS_ITEM,BILLOFLADING_HOUSE.PREPAID_OR_COLLECT,BILLOFLADING_HOUSE.LOAD_DATE,BILLOFLADING_HOUSE.QUARANTINE_CODING,BILLOFLADING_HOUSE.DATE_OF_ISSUE,BILLOFLADING_HOUSE.CURRENCY, " & _
       "BILLOFLADING_HOUSE.EXCHANGE_RATE,BILLOFLADING_HOUSE.MF_FILING_TYPE ,BILLOFLADING_HOUSE.NVOCC_MASTER_BL_NO,SCAC_CODE,BILLOFLADING_HOUSE.REVENUETON, BILLOFLADING_HOUSE.DESCRIPTIONFORSHIPPER, " & _
       "BILLOFLADING_HOUSE.TRADE_CODE_ID AS TRADE_CODE_ID,BILLOFLADING_HOUSE.TRADE_CODE,BILLOFLADING_HOUSE.PREPAIDAT, " & _
        "BILLOFLADING_HOUSE.PORT_OF_LOADING_ID AS PORT_OF_LOADING_ID,BILLOFLADING_HOUSE.PORT_OF_LOADING_CODE AS PORT_OF_LOADING_CODE,BILLOFLADING_HOUSE.PORT_OF_LOADING_NAME AS PORT_OF_LOADING, " & _
       "BILLOFLADING_HOUSE.BL_OTHER_REF,BILLOFLADING_HOUSE.TOTALPREPAID_IN as TOTALPREPAID_IN , " & _
       "ContainerOutBoundNotify.SERVICECONTRACT As ServiceContract,BL_TYPE," & _
       "BILLOFLADING_HOUSE.PAYABLE_AT," & _
       "ContainerOutBoundNotify.BookingNo,ContainerOutBoundNotify.SaleName As SaleName," & _
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
 "BILLOFLADING_HOUSE.notShowDes, " & _
       "BILLOFLADING_HOUSE.Editable as Editable, " & _
       "BILLOFLADING_HOUSE.Continued as Continued, " & _
       "BILLOFLADING_HOUSE.Approve as Approve, " & _
       "BILLOFLADING_HOUSE.UserId as UserId, " & _
       "BILLOFLADING_HOUSE.Updatetime as Updatetime "

    Const strBILLOFLADING_HOUSEOrder1 As String = _
          " ORDER BY BILLOFLADING_HOUSE.BLH_NO  Desc "
    Const strBILLOFLADING_HOUSEOrder2 As String = _
        " ORDER BY BILLOFLADING_HOUSE.UpdateTime Desc "
    Const strPriceSelect As String = "SELECT DISTINCT BillofLading_House.BLH_ID as BL_IDP,BillofLading_House.BLH_NO as BL_NOP," & _
       "Charge.Charge_Code,PriceBillHouse.Charge_ID,PriceHouse_ID, Prepaid_collect,POP,Quantity," & _
       "PriceBillHouse.Currency as Currency,IG_Code, " & _
       "UnitPrice, " & _
                   "PriceBillHouse.Continued, " & _
               "PriceBillHouse.Editable, " & _
              "PriceBillHouse.Approve, " & _
              "PriceBillHouse.UserId, " & _
              "PriceBillHouse.Updatetime "
    Const strPriceOrder As String = _
           " ORDER BY PriceBillHouse.UpdateTime Desc "

    Const strCustomerInfo As String = "Select Shipper.Shipper_1, Shipper_Code," & _
  "Shipper.Shipper_2 , Shipper.Shipper_3,Shipper.Shipper_4," & _
      "Shipper.Shipper_5 , " & _
      "Shipper.Shipper_6 , Shipper.Remarks as RemarksShipper ," & _
  "Consignee.Consignee_1,Consignee_Code, " & _
      "Consignee.Consignee_2 , Consignee.Consignee_3,Consignee.Consignee_4," & _
      "Consignee.Consignee_5 , " & _
      "Consignee.Consignee_6 , Consignee.Remarks as RemarksConsignee , " & _
  "Notify.Notify_1 , Notify_Code," & _
      "Notify.Notify_2, Notify.Notify_3,Notify.Notify_4," & _
      "Notify.Notify_5, " & _
      "Notify.Notify_6 ,Notify.Remarks as RemarksNotify  "

    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL &= " From SailingSchedule,vessel "
        strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD='" & Me.dtpLeavingDate.Value.Date & "'"
        strSQL &= "Order By Vessel_Code desc"
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboVessel.DisplayMember = value
        Me.cboVessel.ValueMember = id
        Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim strSQL As String
            strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            strSQL &= " From SailingSchedule,vessel "
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD='" & Me.dtpLeavingDate.Value.Date & "'"
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                QueryVessel()
            Else
                MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        On Error GoTo Err_named
        Dim Ves_ID As String
        If Me.cboVessel.Text = "" Then
            Return
        End If
        Ves_ID = Me.cboVessel.SelectedValue.ToString
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        If Ves_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select ETD "
            strQuery &= "from SailingSchedule "
            strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString
            End If
            '  query stranship
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmManifestVessel_House_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
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
        strQuery &= " Vessel On Sailingschedule.Vessel_ID=Vessel.Vessel_ID) Where ContainerOutboundNotify.SailingscheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And BILLOFLADING_HOUSE.Continued=1"
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

    Private Function MakeQueryBILLOFLADING_HOUSE(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBILLOFLADING_HOUSE = strBILLOFLADING_HOUSESelect
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " ,(select Count(*) From Cargo_House where Cargo_House.BLH_ID=BillOflading_House.BLH_ID And Cargo_House.continued=1) As QuantityOfContainer "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " FROM ((((((((((BILLOFLADING_HOUSE left join Shipper on BILLOFLADING_HOUSE.Shipper_Id=Shipper.Shipper_Id ) left join Consignee on BILLOFLADING_HOUSE.Consignee_Id=Consignee.Consignee_Id ) left join Notify on BILLOFLADING_HOUSE.Notify_Id=Notify.Notify_Id) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN Notify as Notify2 On BillOflading_House.Notify2_ID=Notify2.Notify_ID) LEFT JOIN Notify as Notify3 On Notify3.Notify_ID=BillOflading_House.Notify3_ID)"
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN Market ON BILLOFLADING_HOUSE.Trade_Code_ID=Market.market_ID ) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN ContainerOutBoundNotify On ContainerOutBoundNotify.ContainerOutBoundNotifyID=BillofLading_House.ContainerOutBoundNotifyID) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID) "


        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " LEFT JOIN UserList on BILLOFLADING_HOUSE.CreativeUser=UserList.Usr) "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & " WHERE (BILLOFLADING_HOUSE.BL_Id = '" & DefaultValue & "') "

        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & "OR ("
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & "BILLOFLADING_HOUSE.Continued = 1 "
        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & ") and checking= 0 and BILLOFLADING_HOUSE.BLH_NO not like 'CU%' "
        If argCriteria <> "" Then
            MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & argCriteria
        End If

        MakeQueryBILLOFLADING_HOUSE = MakeQueryBILLOFLADING_HOUSE & strBILLOFLADING_HOUSEOrder2


        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

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
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Function QueryCountBill(ByVal SailingID As String) As DataTable
        Try
            Dim SQl As String
            SQl = "select BLH_ID as ID ,BLH_No  "
            SQl &= " From(BillOfLading_House LEFT JOIN ContaineroutboundNotify On BillOfLading_House.ContaineroutboundNotifyID=ContaineroutboundNotify.ContaineroutboundNotifyID)"
            SQl &= " Where BILLOFLADING_HOUSE.BLH_NO not like 'CU%' and BillOfLading_House.Continued=1 And ContaineroutboundNotify.SailingScheduleID='" & SailingID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQl)
            Return dt

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub QueryRoutingInfo(ByRef dt As DataTable, ByVal ID As String) 'Lay du Lieu Vessel Ra de in File

        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        strQuery = "Select * from Routing_House where BLH_ID='" & ID & "' And Continued=1 Order BY SEQ ASC"

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

    Sub QueryUnit(ByRef otableUnit As DataTable, ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "select CTN_SIZE_TYPE as type,Count(CTN_SIZE_TYPE) as Num from (container LEFT JOIN Cargo_House on Cargo_House.CTN_ID=Container.CTN_ID) where Cargo_House.BLH_ID='" & ID & "' And Cargo_House.Continued=1 Group by CTN_SIZE_TYPE"
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

    Sub QueryNotify(ByRef dt As DataTable, ByVal NotifyID As String, ByVal ID As String)
        Dim strQuery As String
        strQuery = " Select top 1 Notify.Notify_Code,Notify.Notify_ID,Notify.Notify_1 ,Notify.Notify_2, Notify.Notify_3,Notify.Notify_4,Notify.Notify_5,Notify.Notify_6, Notify.Remarks as RemarksNotify "
        strQuery &= " From (BillOfLading_House LEFT JOIN Notify On BillOfLading_House." & NotifyID & "=Notify.Notify_ID) "
        strQuery &= " Where BillofLading_House.Continued=1 And BLH_ID='" & ID & "' " 'And " & NotifyID & "<>'" & DefaultValue & "'"

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

    Sub QueryFreightCharge(ByVal ID As String)
        On Error GoTo Err_Named
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Charge_Code,Charge,Currency,AMOUNT as UnitPrice,UNIT_OF_QUANTITY,Quantity,POP,Prepaid_collect,CONTAINER_TYPE,RATE_OF_FR_CH,PAYER_CODE,IG_CODE "
        strQuery &= ", Port_Code as PAYABLE_AT_CODE, Port As PAYABLE_AT "
        strQuery &= "  from ((FREIGHT_CHARGE_House LEFT JOIN Charge On FREIGHT_CHARGE_House.Charge_Id=Charge.Charge_ID)"
        strQuery &= " INNER JOIN Port on FREIGHT_CHARGE_House.PAYABLE_AT_ID=Port.Port_ID) "
        strQuery &= " where BLH_ID='" & ID & "' And FREIGHT_CHARGE_House.Continued=1"
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

    Sub QueryBillPrice(ByRef dt As DataTable, ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Charge_Code,Charge,Currency,UnitPrice,Quantity,IG_Code ,POP,PrePaid_Collect "
        strQuery &= " from (PRICEBILLHOUSE LEFT JOIN Charge On PRICEBILLHOUSE.Charge_id=Charge.Charge_ID) "
        strQuery &= " Where BLH_ID='" & ID & "' And PRICEBILLHOUSE.Continued=1"
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

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM (((BILLOFLADING_HOUSE LEFT JOIN Shipper On BILLOFLADING_HOUSE.Shipper_ID=Shipper.Shipper_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Consignee On Consignee.Consignee_ID=BILLOFLADING_HOUSE.Consignee_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Notify On Notify.Notify_ID=BILLOFLADING_HOUSE.Notify_ID) "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " BILLOFLADING_HOUSE.Continued=1 " & argCriteria
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
        Adapter.Fill(oTableCustomerInfo)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Sub QueryCargoInfo(ByRef dt As DataTable, ByVal ID As String)
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
        strQuery &= " Where BLH_ID='" & ID & "' And CARGO_HOUSE.Continued=1 Order by CONTAINER_NO ASC"
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

    Sub QueryCargoMarks(ByRef oTableCargoMarks As DataTable, ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select MARKS from CargoHouse_Marks Where BLH_ID='" & ID & "'"
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

    Sub QueryCargoReMarks(ByRef oTableCargoMarks As DataTable, ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select CARGO_REMARKS from CargoHouse_Remarks Where BLH_ID='" & ID & "'"
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

    Sub QueryCargoDescription(ByRef oTableCargoDescription As DataTable, ByVal ID As String)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        strQuery = "Select Description from CargoHouse_Description Where BLH_ID='" & ID & "' "
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


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
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
        Dim oTableCountHouseBill As New DataTable
        oTableCountHouseBill = QueryCountBill(Me.cboVessel.SelectedValue.ToString)
        Dim BLHNO As String = ""
        Dim BLHID As String = ""

        For CountBill As Integer = 0 To oTableCountHouseBill.Rows.Count - 1
            BLHID = oTableCountHouseBill.Rows(CountBill).Item("ID").ToString
            BLHNO = oTableCountHouseBill.Rows(CountBill).Item("BLH_NO").ToString
            QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BLH_ID='" & BLHID & "'")
            'Record 12
            temp = "12:" & oTable.Rows(0).Item("blh_no").ToString.Trim & "::::"
            'field 6
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_RECEIPT_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_RECEIPT_CODE").ToString.Trim, "") & ":"
            'field 7
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_RECEIPT_NAME").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_RECEIPT_NAME").ToString.Trim, "") & ":"
            'field 8
            temp &= IIf(oTable.Rows(0).Item("PORT_OF_LOADING_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PORT_OF_LOADING_CODE").ToString.Trim, "") & ":"
            'field 9
            temp &= IIf(oTable.Rows(0).Item("PORT_OF_LOADING").ToString.Trim <> "", oTable.Rows(0).Item("PORT_OF_LOADING").ToString.Trim, "") & ":"
            'field 10
            If UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-CY*" Then
                Mean = "11"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-CFS*" Then
                Mean = "12"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-DOOR*" Then
                Mean = "13"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-TACKLE*" Then
                Mean = "14"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-FIO*" Then
                Mean = "15"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-LIO*" Then
                Mean = "16"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-LO*" Then
                Mean = "17"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-FI*" Then
                Mean = "18"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-FO*" Then
                Mean = "19"
            ElseIf UCase(oTable.Rows(0).Item("BL_CY_CFS_ITEM").ToString.Trim) Like "*CY-RAMP*" Then
                Mean = "1R"
            End If
            temp &= Mean & ":"
            'field 11
            If UCase(oTable.Rows(0).Item("PREPAID_OR_COLLECT").ToString).Trim = "COLLECT" Then
                temp &= "C"
            ElseIf UCase(oTable.Rows(0).Item("PREPAID_OR_COLLECT").ToString).Trim = "PREPAID" Then
                temp &= "P"
            Else
                temp &= ""
            End If
            temp &= ":"
            'field 12
            datetime = oTable.Rows(0).Item("LOAD_DATE")
            temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month) & IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
            'field 13
            temp &= ":" & IIf(oTable.Rows(0).Item("QUARANTINE_CODING").ToString.Trim <> "", oTable.Rows(0).Item("QUARANTINE_CODING").ToString.Trim, "") & ":"
            'field 14
            datetime = oTable.Rows(0).Item("DATE_OF_ISSUE")
            temp &= datetime.Year & IIf(datetime.Month <= 9, "0" & datetime.Month.ToString, datetime.Month) & IIf(datetime.Day <= 9, "0" & datetime.Day.ToString, datetime.Day)
            temp &= ":"
            'field 15
            temp &= IIf(oTable.Rows(0).Item("CURRENCY").ToString.Trim <> "", oTable.Rows(0).Item("CURRENCY").ToString.Trim, "") & ":"
            'field 16
            temp &= IIf(oTable.Rows(0).Item("EXCHANGE_RATE").ToString.Trim <> "", oTable.Rows(0).Item("EXCHANGE_RATE").ToString.Trim, "") & ":"
            'field 17
            temp &= IIf(oTable.Rows(0).Item("MF_FILING_TYPE").ToString.Trim <> "", oTable.Rows(0).Item("MF_FILING_TYPE").ToString.Trim, "") & ":"
            'field 18
            temp &= IIf(oTable.Rows(0).Item("NVOCC_MASTER_BL_NO").ToString.Trim <> "", oTable.Rows(0).Item("NVOCC_MASTER_BL_NO").ToString.Trim, "") & ":"
            'field 19
            temp &= IIf(oTable.Rows(0).Item("SCAC_CODE").ToString.Trim <> "", oTable.Rows(0).Item("SCAC_CODE").ToString.Trim, "") & ":"
            'field 20
            temp &= IIf(oTable.Rows(0).Item("TRADE_CODE").ToString.Trim <> "", oTable.Rows(0).Item("TRADE_CODE").ToString.Trim, "") & ":"
            'field 21
            temp &= IIf(oTable.Rows(0).Item("BL_OTHER_REF").ToString.Trim <> "", oTable.Rows(0).Item("BL_OTHER_REF").ToString.Trim, "") & ":"
            'field 22
            temp &= IIf(oTable.Rows(0).Item("BL_TYPE").ToString.Trim <> "", oTable.Rows(0).Item("BL_TYPE").ToString.Trim, "") & ":"
            'field 23
            temp &= IIf(oTable.Rows(0).Item("PAYABLE_AT").ToString.Trim <> "", oTable.Rows(0).Item("PAYABLE_AT").ToString.Trim, "") & ":"
            'field 24 
            If UCase(oTable.Rows(0).Item("PREPAID_OR_COLLECT").ToString).Trim = "COLLECT" Then
                temp &= "C"
            ElseIf UCase(oTable.Rows(0).Item("PREPAID_OR_COLLECT").ToString).Trim = "PREPAID" Then
                temp &= "S"
            Else
                temp &= "O"
            End If
            temp &= ":"
            'field 25
            temp &= IIf(oTable.Rows(0).Item("NO_OF_COPY_BL").ToString.Trim <> "", oTable.Rows(0).Item("NO_OF_COPY_BL").ToString.Trim, "") & ":"
            'field 26
            temp &= IIf(oTable.Rows(0).Item("NO_OF_ORIGINAL_BL").ToString.Trim <> "", oTable.Rows(0).Item("NO_OF_ORIGINAL_BL").ToString.Trim, "") & ":"
            'field 27
            temp &= Strings.Replace(IIf(oTable.Rows(0).Item("CUSTOMS_CLEARED_PLACE").ToString.Trim <> "", oTable.Rows(0).Item("CUSTOMS_CLEARED_PLACE").ToString.Trim, ""), ":", "?:") & ":"
            'field 28
            temp &= IIf(oTable.Rows(0).Item("SLOT_SHARE").ToString.Trim <> "", oTable.Rows(0).Item("SLOT_SHARE").ToString.Trim, "") & ":"
            'field 29 
            temp &= IIf(oTable.Rows(0).Item("US_SERVICE_MODE").ToString.Trim <> "", oTable.Rows(0).Item("US_SERVICE_MODE").ToString.Trim, "")
            temp &= EndRecord
            fw.WriteLine(temp)
            '''''''''''''''''''''''''''''''''''''''''''''''
            'record 13
            'field 1
            temp = "13:"
            'field 2
            temp &= IIf(oTable.Rows(0).Item("PORT_OF_DISCHARGE_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PORT_OF_DISCHARGE_CODE").ToString.Trim, "") & ":"
            'fieldc3
            temp &= IIf(oTable.Rows(0).Item("PORT_OF_DISCHARGE_NAME").ToString.Trim <> "", oTable.Rows(0).Item("PORT_OF_DISCHARGE_NAME").ToString.Trim, "") & ":"
            'field 4
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_DELIVERY_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_DELIVERY_CODE").ToString.Trim, "") & ":"
            'field 5
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_DELIVERY_NAME").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_DELIVERY_NAME").ToString.Trim, "") & ":"
            'field 6
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_DESTINATION_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_DESTINATION_CODE").ToString.Trim, "") & ":"
            'field 7
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_DESTINATION_NAME").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_DESTINATION_NAME").ToString.Trim, "") & ":"
            'field 8
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_BL_ISSUE_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_BL_ISSUE_CODE").ToString.Trim, "") & ":"
            'field 9
            temp &= IIf(oTable.Rows(0).Item("PLACE_OF_BL_ISSUE_NAME").ToString.Trim <> "", oTable.Rows(0).Item("PLACE_OF_BL_ISSUE_NAME").ToString.Trim, "") & ":"
            'field 10
            temp &= IIf(oTable.Rows(0).Item("TRANSFER_PORT1").ToString.Trim <> "", oTable.Rows(0).Item("TRANSFER_PORT1").ToString.Trim, "") & ":"
            'field 11
            temp &= IIf(oTable.Rows(0).Item("TRANSFER_PORT2").ToString.Trim <> "", oTable.Rows(0).Item("TRANSFER_PORT2").ToString.Trim, "") & ":"
            'field 12
            temp &= IIf(oTable.Rows(0).Item("TRANSFER_PORT3").ToString.Trim <> "", oTable.Rows(0).Item("TRANSFER_PORT3").ToString.Trim, "") & ":"
            'field 13
            temp &= IIf(oTable.Rows(0).Item("TRANSFER_PORT4").ToString.Trim <> "", oTable.Rows(0).Item("TRANSFER_PORT4").ToString.Trim, "")
            temp &= EndRecord
            fw.WriteLine(temp)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            'record 14

            QueryRoutingInfo(dt, BLHID)
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
            'fw.WriteLine(temp)
            'Dim CountContainer As Integer = 0
            'QueryUnit(dt, BLHID)
            'QueryFreightCharge(BLHID)
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
            'QueryBillPrice(dt, BLHID)
            'For Each row In dt.Rows
            '    temp = "15:"
            '    'field 2
            '    temp &= IIf(row.Item("Charge_Code").ToString <> "", row.Item("Charge_Code").ToString.Trim, "") & ":"
            '    'field 3
            '    temp &= IIf(row.Item("Charge").ToString <> "", Strings.Left(row.Item("Charge").ToString.Trim, 18), "") & ":"
            '    'field 4
            '    temp &= IIf(oTable.Rows(0).Item("PAYABLE_AT").ToString.Trim <> "", oTable.Rows(0).Item("PAYABLE_AT").ToString.Trim, "") & ":"

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
            '    temp &= IIf(oTable.Rows(0).Item("PAYER_CODE").ToString.Trim <> "", oTable.Rows(0).Item("PAYER_CODE").ToString.Trim, "") & ":"
            '    'field 14
            '    temp &= Strings.Replace(IIf(row.Item("IG_CODE").ToString.Trim <> "", row.Item("IG_CODE").ToString.Trim, ""), ":", "?:")
            '    temp &= EndRecord
            '    fw.WriteLine(temp)
            'Next
            '''''''''''''''''''''''''''''''''''''''''
            'record 16
            QueryCustomerInfo(" And BillOfLading_house.BLH_ID='" & BLHID & "'")
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
            QueryNotify(dtNotify, "Notify2_ID", BLHID)

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

            QueryNotify(dtNotify3, "Notify3_ID", BLHID)



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
            ' record 21
            Dim oTableBL_Clause As New DataTable
            'oTableBL_Clause = QueryBL_Clause(oTable.Rows(0).Item("BL_ClauseID").ToString)

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
            ''record 23
            'temp = "23:"
            ''field 2
            'temp &= "CA:"
            ''field 3 
            'temp &= IIf(oTable.Rows(0).Item("CANVASSERCODE").ToString.Trim <> "", oTable.Rows(0).Item("CANVASSERCODE").ToString.Trim, "") & ":"
            ''field 4
            'temp &= "" '
            'temp &= EndRecord
            'fw.WriteLine(temp)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim TbCargo As New DataTable
            QueryCargoInfo(TbCargo, BLHID)
            Dim TotalAmount, TotalCBM, TotalGross As Double

            If TbCargo.Rows.Count = 0 Then
                DisplayMessage(True, "There No container in this Bill")
                fw.Close()
                Return
            End If
            'record 41
            TotalAmount = 0
            TotalCBM = 0
            TotalGross = 0
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
            QueryCargoMarks(dt, BLHID)

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
            QueryCargoDescription(dt, BLHID)

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
            QueryCargoReMarks(dt, BLHID)
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
                fw.WriteLine(temp)
            Next
        Next 'kết thúc một bill
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
        temp = "99:" & 5 + oTableCountHouseBill.Rows.Count & "'"

        fw.WriteLine(temp)

        fw.Close()
        DisplayMessage(True, "Manifest Export Success With Path:" & path)
        Exit Sub
Err_Named:
        fw.Close()
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class