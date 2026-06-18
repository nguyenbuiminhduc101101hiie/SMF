Imports Excel

Public Class frmSummaryReportOutbound

    Dim ds As New DataSet
    Dim Path As String
    Dim Vessel, VoyNo As String
    Dim ETD As Date
    Dim dem As Integer = 0
    Dim SailID As String
    Dim dsTHC_DHC As New DataSet
    Dim dsCosting, dsCostingSale, dsCostingAMS As New DataSet
    'Sub QueryVessel1()
    '    Try
    '        Dim SQL As String
    '        SQL = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETD)  as data "
    '        SQL &= "from BillOfLadingIB where Continued=1 And ETD >='" & Me.dtpFromETD.Value.Date & "' And ETD<='" & Me.dtpToETD.Value.Date & "'"
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        Dim ds As New DataSet
    '        If Not IsNothing(ds) Then
    '            ds.Clear()
    '        End If
    '        Adapter.Fill(ds)
    '        Me.cboVessel.Items.Clear()
    '        Me.cboVessel.Text = ""
    '        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
    '            Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
    '        Next
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct SailingSchedule.SailingScheduleID as Id, Vessel +' - '+ VoyNo + ' - ' + convert(nvarchar,ETD)  as data "
            SQL &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            SQL &= " where BillOfLading.Continued=1 And ETD >='" & Me.dtpFromETD.Value.Date & "' And ETD<='" & Me.dtpToETD.Value.Date & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet

            Adapter.Fill(ds)
            Me.cboVessel.Text = ""
            Me.cboVessel.DataSource = ds.Tables(0)
            Me.cboVessel.DisplayMember = "data"
            Me.cboVessel.ValueMember = "ID"
            
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(AMOUNT * Quantity*exchange) "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (Charge_Code like '%DHC%' Or Charge_Code Like '%THC%') and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryDHC_THCHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(AMOUNT * Quantity*tigia) "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (Charge_Code like '%DHC%' Or Charge_Code Like '%THC%') and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsTHC_DHC) Then
                dsTHC_DHC.Clear()
            End If
            AdapterFee.Fill(dsTHC_DHC)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryCosting(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(AMOUNT * Quantity*exchange),port_code "
            strQuery &= " From ((Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code <>'DHC'  And Charge_Code <>'THC' And Charge_Code <>'LHC' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
            strQuery &= " group by port_code "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsCosting) Then
                dsCosting.Clear()
            End If
            AdapterFee.Fill(dsCosting)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryCostingHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(AMOUNT * Quantity*tigia),port_code  "
            strQuery &= " From ((Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code <>'DHC'  And Charge_Code <>'THC' And Charge_Code <>'LHC' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
            strQuery &= " group by port_code "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsCosting) Then
                dsCosting.Clear()
            End If
            AdapterFee.Fill(dsCosting)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryCostingSale(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPriceSale * Quantity*exchange),port_code  "
            strQuery &= " From ((Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code <>'DHC' And Charge_Code <>'THC' And Charge_Code <>'LHC' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
            strQuery &= " group by port_code "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsCostingSale) Then
                dsCostingSale.Clear()
            End If
            AdapterFee.Fill(dsCostingSale)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryCostingSaleHistory(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPriceSale * Quantity*tigia),port_code "
            strQuery &= " From ((Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And Charge_Code <>'DHC' And Charge_Code <>'THC' And Charge_Code <>'LHC' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsCostingSale) Then
                dsCostingSale.Clear()
            End If
            AdapterFee.Fill(dsCostingSale)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryGetAMS(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPrice * Quantity*exchange) "
            strQuery &= " From (pricebillmaster LEFT JOIN Charge On Charge.Charge_ID=pricebillmaster.Charge_ID) inner join currency on currency.currency=pricebillmaster.currency "
            strQuery &= " Where BL_ID='" & billID & "' and pricebillmaster.Continued=1 "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If Not IsNothing(dsCostingAMS) Then
                dsCostingAMS.Clear()
            End If
            AdapterFee.Fill(dsCostingAMS)
            'Return dsFee.Tables(0).Rows(0).Item("flag")
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryInfo(ByVal Vessel As String, ByVal Voyno As String, ByVal ETD As Date)
        Try
            Dim strSQL As String
            strSQL = "Select distinct BillOfLading.BL_ID,BillOfLading.ServiceContract as F1,Vessel as F2,VoyNo As F3,ETD as F4,BillOfLading.PORT_OF_LOADING_CODE as F5,BillOfLading.PORT_OF_DISCHARGE_CODE as F7,BL_NO as F8,BLH_NO as F9,BillOfLading.PLACE_OF_DELIVERY_CODE as F10 ,Commission,BillOfLading.TAX "
            strSQL &= " from (((((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strSQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_id=Vessel.Vessel_ID) "
            strSQL &= " LEFT JOIN Shipper On BillOfLading.Shipper_ID=Shipper.Shipper_ID) "
            strSQL &= " LEFT JOIN BILLOFLADING_HOUSE On BillOfLading.BL_ID=BILLOFLADING_HOUSE.BL_ID) "
            strSQL &= "Where BillOfLading.Continued=1 And SailingSchedule.SailingScheduleID='" & SailID & "' And BillOfLading.ServiceContract Like'%" & Me.txtServiceContract.Text.Trim & "%' and blh_no like 'CU%'"

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBill").Rows.Count > 0 Then
                ds.Tables("oTableBill").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBill"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryContainer(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Container_type,Count(container_Type) as SoLuong from Cargo"
            strSQL &= " where cargo.BL_ID='" & BillId.Trim & "' And Cargo.Continued=1 Group by Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()

            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableContainer").Rows.Count > 0 Then
                ds.Tables("oTableContainer").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableContainer"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryPrice(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select Charge_Code as Items,PREPAID_COLLECT,UnitPrice as Fee "
            strSQL &= " from (PRICEBIllMaster LEFT JOIN Charge On Charge.Charge_ID=PRICEBIllMaster.Charge_ID)"
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='TRUCKING' Or Charge_Code ='HANDLING') And PRICEBIllMaster.Continued=1"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFee").Rows.Count > 0 Then
                ds.Tables("oTableFee").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFee"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryFreight(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(Amount*quantity*exchange) as OceanFreight,port_code  "
            strSQL &= " from ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)inner join port on Freight_Charge_Master.payable_at_id=port.port_id) inner join currency on currency.currency=Freight_Charge_Master.currency "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code ='ODB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreight").Rows.Count > 0 Then
                ds.Tables("oTableFreight").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreight"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryFreightHistory(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(Amount*quantity*tigia) as OceanFreight,port_code "
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code ='ODB') AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT,port_code "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableFreight").Rows.Count > 0 Then
                ds.Tables("oTableFreight").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableFreight"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            Dim tempds As New DataSet
            tempds.Tables.Add("Vessel")
            tempds.Tables(0).Columns.Add("Vessel")
            tempds.Tables(0).Columns.Add("Voyno")
            tempds.Tables(0).Columns.Add("ETD")
            Me.dgdVesselCollection.Rows.Add(1)
            Dim Countdgd As Integer = Me.dgdVesselCollection.RowCount - 1
            Dim row As DataRow
            row = tempds.Tables(0).NewRow
            Dim tempvessel() As String
            tempvessel = Strings.Split(Me.cboVessel.Text, " - ")
            row("Vessel") = IIf(tempvessel.Length > 0, tempvessel(0), "")
            row("VoyNo") = IIf(tempvessel.Length > 1, tempvessel(1), "")
            row("ETD") = IIf(tempvessel.Length > 2, CDate(tempvessel(2)), "")
            Me.dgdVesselCollection.Item("Vesselgid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(0), "")
            Me.dgdVesselCollection.Item("VoyNogid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(1), "")
            Me.dgdVesselCollection.Item("ETDgid", Countdgd).Value = IIf(tempvessel.Length > 0, CDate(tempvessel(2)), "")
            Me.dgdVesselCollection.Item("SailingScheduleID", Countdgd).Value = Me.cboVessel.SelectedValue.ToString
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub frmFreightInboundList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            ds.Tables.Clear()
            SetDefaultGrid(Me.dgdVesselCollection, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            ds.Tables.Add("oTableFreight")
            ds.Tables.Add("oTableFee")
            ds.Tables.Add("oTableContainer")
            ds.Tables.Add("oTableBill")
            QueryVessel()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    'Sub SetExcelValueCommission()
    '    Dim app As Application
    '    Try
    '        Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    '        app = New Application()
    '        app.Visible = True

    '        Dim workbooks As Workbooks
    '        workbooks = app.Workbooks
    '        Dim workbook As _Workbook

    '        Path = StartupPath & "\InbounCommission.xls"

    '        workbook = workbooks.Open(Path)



    '        Dim sheets As Sheets
    '        sheets = workbook.Worksheets
    '        Dim ws As _Worksheet
    '        ws = sheets.Item(1)
    '        If ws Is Nothing Then
    '            app.Quit()
    '            Return
    '        End If
    '        Dim DongHienTai As Integer = 9 ' dòng hiên hành Dang Xét
    '        Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
    '        For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

    '            Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
    '            VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
    '            ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
    '            QueryInfo(Vessel, VoyNo, ETD)
    '            Dim BillID As String = ""
    '            Dim n As Integer = ds.Tables("oTableBill").Rows.Count
    '            SoDong = DongHienTai
    '            For i As Integer = 0 To n - 1

    '                BillID = ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim
    '                'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
    '                'Insert Bill Info
    '                'For k As Integer = 2 To 4
    '                If ds.Tables("oTableBill").Rows(i).Item("F3").ToString.Length > 0 Then
    '                    ws.Range("A" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F3").ToString
    '                End If
    '                'Next
    '                'insert container
    '                QueryContainer(BillID)
    '                For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
    '                    Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
    '                    If Type = "20GP" Then
    '                        ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40GP" Then
    '                        ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "20RF" Then
    '                        ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40RF" Then
    '                        ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40HC" Then
    '                        ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    ElseIf Type = "40RH" Then
    '                        ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    Else
    '                        ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    End If
    '                Next
    '                'Insert Cac Loai Phi
    '                QueryPrice(BillID)
    '                If ds.Tables("oTableFee").Rows.Count > 0 Then
    '                    If UCase(ds.Tables("oTableFee").Rows(0).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
    '                        If ds.Tables("oTableFee").Rows(0).Item("FEE").ToString.Trim.Length > 0 Then
    '                            ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                            ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                        End If
    '                    Else 'phí là prepaid
    '                        If ds.Tables("oTableFee").Rows(0).Item("FEE").ToString.Trim.Length > 0 Then
    '                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                            ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
    '                        End If
    '                    End If
    '                End If
    '                'insert OnceaFreight
    '                QueryFreight(BillID)
    '                If ds.Tables("oTableFreight").Rows.Count > 0 Then
    '                    If ds.Tables("oTableFreight").Rows(0).Item("PREPAID_COLLECT").ToString = "COLLECT" Then
    '                        ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")
    '                        ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")
    '                        Dim Congthuc As String
    '                        Congthuc = "=L" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
    '                        ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
    '                        'thêm công thức vào Freight To Owner
    '                        ws.Range("S" & DongHienTai).Value2 = "=L" & DongHienTai & "+ M" & DongHienTai & "- R" & DongHienTai
    '                    Else
    '                        ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")
    '                        ws.Range("N" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(0).Item("OceanFreight")

    '                        Dim Congthuc As String
    '                        Congthuc = "=J" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
    '                        ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
    '                        'thêm công thức vào Freight To Owner
    '                        ws.Range("S" & DongHienTai).Value2 = "=J" & DongHienTai & "+ K" & DongHienTai & "- R" & DongHienTai
    '                    End If
    '                End If
    '                'ws.Range("Q" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee
    '                'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
    '                ws.Range("B" & DongHienTai).Value2 = ETD
    '                ws.Range("W" & DongHienTai).Formula = "=R" & DongHienTai & " + V" & DongHienTai
    '                DongHienTai += 1
    '                ws.Range("A8", "W" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
    '                ws.Range("A8", "W" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
    '            Next
    '            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
    '            'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
    '            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '            'ws.Range("B" & DongHienTai).Value2 = ETD
    '            'Dim C As Integer
    '            'For C = 0 To 16
    '            '    'If Alpha(C + 2) <> "Q" Then
    '            '    Dim Sum As String
    '            '    Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
    '            '    ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
    '            '    ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
    '            '    'End If
    '            'Next
    '            'ws.Range("A" & DongHienTai, Alpha(C + 4) & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
    '            DongHienTai += 1
    '        Next
    '        ' ws.Range("A8", "U" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)
    '        Dim ToTal As Integer
    '        ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
    '        ws.Range("A" & DongHienTai).Value2 = "TOTAL "
    '        ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '        ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '        For ToTal = 0 To 16
    '            ' If Alpha(ToTal + 5) <> "Q" Then
    '            Dim Sum As String
    '            Sum = "=sum(" & Alpha(ToTal + 2) & 9 & ":" & Alpha(ToTal + 2) & DongHienTai - 1 & ")"
    '            ws.Range(Alpha(ToTal + 2) & DongHienTai).Formula = Sum
    '            ws.Range(Alpha(ToTal + 2) & DongHienTai).Cells.Font.Bold = 1
    '            'End If
    '        Next

    '        Path = "c:\InboundCommission" & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

    '        workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

    '    Catch ex As Exception
    '        MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
    '        MsgBox(Err.Description)
    '        Return
    '    Finally
    '        app.Quit()
    '    End Try

    'End Sub

    Sub SetExcelValue()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\SummaryReport.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 8 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                QueryInfo(Vessel, VoyNo, ETD)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                If ds.Tables("oTableBill").Rows().Count > 0 Then
                    BillID = ds.Tables("oTableBill").Rows(0).Item("BL_ID").ToString.Trim
                End If
                Dim CountHouse As Integer = 0
                For i As Integer = 0 To n - 1


                    If BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim Then
                        CountHouse += 1
                    Else
                        BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                        CountHouse = 1
                    End If
                    'Insert Bill Info
                    Dim Pos As Integer = 10
                    For k As Integer = 1 To Pos
                        If k = 6 Then
                            Continue For
                        End If
                        If ds.Tables("oTableBill").Rows(i).Item("F" & k).ToString.Length > 0 Then
                            ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k).ToString
                        End If
                    Next
                    Pos += 4 'ẩn đi 4 cột trong file EXCEL L,M,N,O
                    If ds.Tables("oTableBill").Rows.Count > 0 Then
                        ws.Range("B" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F1").ToString
                    End If
                    'insert container
                    If CountHouse = 1 Then
                        QueryContainer(BillID)
                        Dim CurType As String = " "
                        For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                            Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                            'If Type = "20GP" Then
                            '    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40GP" Then
                            '    ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "20RF" Then
                            '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40RF" Then
                            '    ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40HC" Then
                            '    ws.Range("N" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40RH" Then
                            '    ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'Else
                            '    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'End If

                            If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                                CurType &= "," & Strings.Right(Type, 2)
                            End If
                            CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)

                            If Strings.Right(Type, 2) = "GP" Then

                                If Strings.Left(Type, 2) = "20" Then
                                    ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                ElseIf Strings.Left(Type, 2) = "40" Then
                                    ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                End If

                            ElseIf Type = "40HC" Then
                                ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            ElseIf Strings.Left(Type, 2) = "45" Then
                                ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            Else
                                If Strings.Left(Type, 2) = "20" Then
                                    ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                Else
                                    ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                End If
                            End If
                        Next

                        Dim TeuFormula As String = ""
                        TeuFormula = "=" & Alpha(Pos + 1) & DongHienTai & "+ (" & Alpha(Pos + 2) & DongHienTai & "*2) +(" & Alpha(Pos + 3) & DongHienTai & "*2)+(" & Alpha(Pos + 4) & DongHienTai & "*2)+(" & Alpha(Pos + 5) & DongHienTai & "*1)+(" & Alpha(Pos + 6) & DongHienTai & "*2)" 'alph(pos+2)=ô 20ft +3=40ft
                        ws.Range(Alpha(Pos + 7) & DongHienTai).Formula = TeuFormula
                        ws.Range(Alpha(Pos + 8) & DongHienTai).Value2 = CurType


                        QueryCosting(BillID)
                        QueryCostingSale(BillID)
                        QueryGetAMS(BillID)
                        If dsCosting.Tables(0).Rows.Count > 0 Then
                            ws.Range(Alpha(Pos + 10) & DongHienTai).Value2 = dsCosting.Tables(0).Rows(0).Item(0).ToString
                        End If

                        ' sellingrate
                        QueryFreight(BillID)
                        If UCase(ds.Tables("oTableFreight").Rows(0).Item("Prepaid_Collect").ToString) = "PREPAID" And ds.Tables("oTableFreight").Rows(0).Item("port_code").ToString Like "VN*" Then
                            ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 10) & DongHienTai).Value2 + ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 * 75 + ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 * 100 + ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 * 150 + ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 * 150 + ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 * 75 + ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 * 150
                        Else
                            ' lay gia sale -(AMS+THC) 
                            ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 = CDbl(dsCostingSale.Tables(0).Rows(0).Item(0).ToString)
                        End If
                        'Insert Cac Loai Phi
                        QueryPrice(BillID)
                        If ds.Tables("oTableFee").Rows.Count > 0 Then
                            If ds.Tables("oTableFee").Rows(0).Item("FEE").ToString.Trim.Length > 0 Then
                                If ds.Tables("oTableFee").Rows(0).Item("Items").ToString = "HANDLING" Then
                                    ws.Range("AB" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
                                Else
                                    ws.Range("AC" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
                                End If

                            End If
                        End If
                    End If
                    'QueryFreight(BillID)
                    If ds.Tables("oTableFreight").Rows.Count > 0 Then
                        If UCase(ds.Tables("oTableFreight").Rows(0).Item("Prepaid_Collect").ToString) = "PREPAID" And ds.Tables("oTableFreight").Rows(0).Item("port_code").ToString Like "VN*" Then

                            ws.Range("AD" & DongHienTai).Value2 = "P"
                        Else
                            ws.Range("AD" & DongHienTai).Value2 = "C"
                        End If
                    End If
                    ' 'profit
                    If ws.Range("AD" & DongHienTai).Value2 = "P" Then
                        ws.Range(Alpha(Pos + 11) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 - ws.Range(Alpha(Pos + 10) & DongHienTai).Value2
                    Else
                        ' lay gia sale -(AMS+THC) 
                        ws.Range(Alpha(Pos + 12) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 - ws.Range(Alpha(Pos + 10) & DongHienTai).Value2
                    End If

                    'hanlding chagre
                    ws.Range(Alpha(Pos + 13) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 * 18 + ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 * 25 + ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 * 25 + ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 * 25 + ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 * 18 + ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 * 25
                    DongHienTai += 1
                Next
                'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                'Dim C As Integer
                'For C = 0 To 10
                '    ' If Alpha(C + 7) <> "Q" Then
                '    Dim Sum As String
                '    Sum = "=sum(" & Alpha(C + 7) & SoDong & ":" & Alpha(C + 7) & DongHienTai - 1 & ")"
                '    ws.Range(Alpha(C + 7) & DongHienTai).Cells.Font.Bold = 1
                '    ws.Range(Alpha(C + 7) & DongHienTai).Formula = Sum
                '    'End If
                'Next
                'ws.Range("A" & DongHienTai, "Y" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
            Next
            'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

            'SUM TOÀN BỘ FILE
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 10
            '    'If Alpha(ToTal + 7) <> "Q" Then
            '    Dim Sum As String
            '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
            '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
            '    'End If
            'Next

            Path = "c:\SummaryReport" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueHistory()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\SummaryReport.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 8 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                QueryInfo(Vessel, VoyNo, ETD)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                If ds.Tables("oTableBill").Rows().Count > 0 Then
                    BillID = ds.Tables("oTableBill").Rows(0).Item("BL_ID").ToString.Trim
                End If
                Dim CountHouse As Integer = 0
                For i As Integer = 0 To n - 1


                    If BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim Then
                        CountHouse += 1
                    Else
                        BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                        CountHouse = 1
                    End If
                    'Insert Bill Info
                    Dim Pos As Integer = 10
                    For k As Integer = 1 To Pos
                        If k = 6 Then
                            Continue For
                        End If
                        If ds.Tables("oTableBill").Rows(i).Item("F" & k).ToString.Length > 0 Then
                            ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k).ToString
                        End If
                    Next
                    Pos += 4 'ẩn đi 4 cột trong file EXCEL L,M,N,O
                    If ds.Tables("oTableBill").Rows.Count > 0 Then
                        ws.Range("B" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F1").ToString
                    End If
                    'insert container
                    If CountHouse = 1 Then
                        QueryContainer(BillID)
                        Dim CurType As String = " "
                        For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                            Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
                            'If Type = "20GP" Then
                            '    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40GP" Then
                            '    ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "20RF" Then
                            '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40RF" Then
                            '    ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40HC" Then
                            '    ws.Range("N" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'ElseIf Type = "40RH" Then
                            '    ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'Else
                            '    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            'End If

                            If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                                CurType &= "," & Strings.Right(Type, 2)
                            End If
                            CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)

                            If Strings.Right(Type, 2) = "GP" Then

                                If Strings.Left(Type, 2) = "20" Then
                                    ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                ElseIf Strings.Left(Type, 2) = "40" Then
                                    ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                End If

                            ElseIf Type = "40HC" Then
                                ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            ElseIf Strings.Left(Type, 2) = "45" Then
                                ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            Else
                                If Strings.Left(Type, 2) = "20" Then
                                    ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                Else
                                    ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                                End If
                            End If
                        Next

                        Dim TeuFormula As String = ""
                        TeuFormula = "=" & Alpha(Pos + 1) & DongHienTai & "+ (" & Alpha(Pos + 2) & DongHienTai & "*2) +(" & Alpha(Pos + 3) & DongHienTai & "*2)+(" & Alpha(Pos + 4) & DongHienTai & "*2)+(" & Alpha(Pos + 5) & DongHienTai & "*1)+(" & Alpha(Pos + 6) & DongHienTai & "*2)" 'alph(pos+2)=ô 20ft +3=40ft
                        ws.Range(Alpha(Pos + 7) & DongHienTai).Formula = TeuFormula
                        ws.Range(Alpha(Pos + 8) & DongHienTai).Value2 = CurType


                        QueryCostingHistory(BillID)
                        QueryCostingSaleHistory(BillID)
                        QueryGetAMS(BillID)
                        If dsCosting.Tables(0).Rows.Count > 0 Then
                            ws.Range(Alpha(Pos + 10) & DongHienTai).Value2 = dsCosting.Tables(0).Rows(0).Item(0).ToString
                        End If

                        ' sellingrate
                        QueryFreightHistory(BillID)
                        If UCase(ds.Tables("oTableFreight").Rows(0).Item("Prepaid_Collect").ToString) = "PREPAID" Then
                            ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 10) & DongHienTai).Value2 + ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 * 75 + ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 * 100 + ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 * 150 + ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 * 150 + ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 * 75 + ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 * 150
                        Else
                            ' lay gia sale -(AMS+THC) 
                            ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 = CDbl(dsCostingSale.Tables(0).Rows(0).Item(0).ToString)
                        End If
                        'Insert Cac Loai Phi
                        QueryPrice(BillID)
                        If ds.Tables("oTableFee").Rows.Count > 0 Then
                            If ds.Tables("oTableFee").Rows(0).Item("FEE").ToString.Trim.Length > 0 Then
                                If ds.Tables("oTableFee").Rows(0).Item("Items").ToString = "HANDLING" Then
                                    ws.Range("AB" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
                                Else
                                    ws.Range("AC" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(0).Item("FEE")
                                End If

                            End If
                        End If
                    End If
                    'QueryFreight(BillID)
                    If ds.Tables("oTableFreight").Rows.Count > 0 Then
                        If UCase(ds.Tables("oTableFreight").Rows(0).Item("Prepaid_Collect").ToString) = "COLLECT" Then
                            ws.Range("AD" & DongHienTai).Value2 = "C"
                        Else
                            ws.Range("AD" & DongHienTai).Value2 = "P"
                        End If
                    End If
                    ' 'profit
                    If ws.Range("AD" & DongHienTai).Value2 = "P" Then
                        ws.Range(Alpha(Pos + 11) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 - ws.Range(Alpha(Pos + 10) & DongHienTai).Value2
                    Else
                        ' lay gia sale -(AMS+THC) 
                        ws.Range(Alpha(Pos + 12) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 9) & DongHienTai).Value2 - ws.Range(Alpha(Pos + 10) & DongHienTai).Value2
                    End If

                    'hanlding chagre
                    ws.Range(Alpha(Pos + 13) & DongHienTai).Value2 = ws.Range(Alpha(Pos + 1) & DongHienTai).Value2 * 18 + ws.Range(Alpha(Pos + 2) & DongHienTai).Value2 * 25 + ws.Range(Alpha(Pos + 3) & DongHienTai).Value2 * 25 + ws.Range(Alpha(Pos + 4) & DongHienTai).Value2 * 25 + ws.Range(Alpha(Pos + 5) & DongHienTai).Value2 * 18 + ws.Range(Alpha(Pos + 6) & DongHienTai).Value2 * 25
                    DongHienTai += 1
                Next
                ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                'Dim C As Integer
                'For C = 0 To 10
                '    ' If Alpha(C + 7) <> "Q" Then
                '    Dim Sum As String
                '    Sum = "=sum(" & Alpha(C + 7) & SoDong & ":" & Alpha(C + 7) & DongHienTai - 1 & ")"
                '    ws.Range(Alpha(C + 7) & DongHienTai).Cells.Font.Bold = 1
                '    ws.Range(Alpha(C + 7) & DongHienTai).Formula = Sum
                '    'End If
                'Next
                'ws.Range("A" & DongHienTai, "Y" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
            Next
            'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

            'SUM TOÀN BỘ FILE
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 10
            '    'If Alpha(ToTal + 7) <> "Q" Then
            '    Dim Sum As String
            '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
            '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
            '    'End If
            'Next

            Path = "c:\SummaryReport" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try

            If Me.dgdVesselCollection.RowCount <= 0 Then
                Return
            End If
            If Me.txtServiceContract.Text = "" Then
                MsgBox("you have to input a Service contract No. ")
                Return
            End If
            If Me.RadioEPre.Checked = True Then
                SetExcelValue()
            Else
                SetExcelValueHistory()
            End If


            'If Me.txtHandingFee.Text = "" Then
            '    MsgBox("You must insert Handing fee (%)")
            '    Exit Sub
            'End If
            'If Me.chkFreightList.Checked = True Then
            '    
            'Else
            '    SetExcelValueCommission()
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpFromETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETD.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpToETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETD.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

End Class