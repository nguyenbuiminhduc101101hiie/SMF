Imports Excel
Public Class frmExcelTiengViet

    Dim ds As New DataSet
    Dim Path As String
    Dim Vessel, VoyNo As String
    Dim ETD As Date
    Dim SailID As String
    Dim dem As Integer = 0
    Dim dsTHC_DHC As New DataSet

    Sub QueryVessel1()
        Try
            Dim SQL As String
            SQL = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETD)  as data "
            SQL &= "from BillOfLadingIB where Continued=1 And ETD >='" & Me.dtpFromETD.Value.Date & "' And ETD<='" & Me.dtpToETD.Value.Date & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim ds As New DataSet
            If Not IsNothing(ds) Then
                ds.Clear()
            End If
            Adapter.Fill(ds)
            Me.cboVessel.Items.Clear()
            Me.cboVessel.Text = ""
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            Next
        Catch ex As Exception

        End Try
    End Sub
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
            'ds.Tables.Add()
            'If ds.Tables(0).Rows.Count > 0 Then
            '    ds.Tables(0).Rows.Clear()
            'End If
            Adapter.Fill(ds)
            Me.cboVessel.Text = ""
            Me.cboVessel.DataSource = ds.Tables(0)
            Me.cboVessel.DisplayMember = "data"
            Me.cboVessel.ValueMember = "ID"
            'Me.cboVessel.Items.Clear()
            'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            'Me.cboVessel.Items.Add(ds.Tables(0).Rows(i).Item("data").ToString)
            ' Next
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryInfo(ByVal Vessel As String, ByVal Voyno As String, ByVal ETD As Date)
        Try
            Dim strSQL As String
            strSQL = "Select Shipper.Shipper_1+' '+Shipper.Shipper_2+' '+Shipper.Shipper_3+' '+Shipper.Shipper_4+' '+Shipper.Shipper_5 as CongTy,BillOfLading.BL_TYPE, BillOfLading.BL_ID,BillOfLading.BL_No,Commission,BillOfLading.Tax,BillOfLading.PREPAID_OR_COLLECT,ContainerOutboundNotify.SaleName, TeLex  "
            strSQL &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strSQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL &= " LEFT JOIN Shipper On Shipper.Shipper_ID=BillOfLading.Shipper_ID)  "
            strSQL &= "Where BillOfLading.Continued=1 And SailingSchedule.SailingScheduleID='" & SailID & "'"
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
    Sub QueryInfohouse(ByVal Vessel As String, ByVal Voyno As String, ByVal ETD As Date)
        Try
            Dim strSQL As String
            strSQL = "Select Shipper.Shipper_1+' '+Shipper.Shipper_2+' '+Shipper.Shipper_3+' '+Shipper.Shipper_4+' '+Shipper.Shipper_5 as CongTy,BillOfLading.BL_TYPE, BillOfLading.BL_ID,BillOfLading_house.blh_no as BL_No,Commission,BillOfLading.Tax,BillOfLading.PREPAID_OR_COLLECT,ContainerOutboundNotify.SaleName, TeLex  "
            strSQL &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strSQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL &= " LEFT JOIN Shipper On Shipper.Shipper_ID=BillOfLading.Shipper_ID) inner join BillOfLading_house on BillOfLading.bl_id=BillOfLading_house.bl_id "
            strSQL &= "Where BillOfLading.Continued=1 And SailingSchedule.SailingScheduleID='" & SailID & "'"
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
            strSQL = "Select PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*exchange)as Fee "
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            'And Charge_Code <>'OCB' And Charge_Code<>'ODB' And Charge_Code<>'LHC' 
            strSQL &= " where BL_ID='" & BillId.Trim & "' And FREIGHT_CHARGE_Master.Continued=1  AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT"
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
    Sub QueryPriceHistory(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*tigia)as Fee "
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            'And Charge_Code <>'OCB' And Charge_Code<>'ODB' And Charge_Code<>'LHC' 
            strSQL &= " where BL_ID='" & BillId.Trim & "' And FREIGHT_CHARGE_Master.Continued=1  AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) GROUP BY PREPAID_COLLECT"
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
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*exchange) as OceanFreight "
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT "
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
            strSQL = "Select BL_ID,PREPAID_COLLECT,Sum(UnitPriceSale*Quantity*tigia) as OceanFreight "
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='ODB') And FREIGHT_CHARGE_Master.Continued=1 AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) Group by BL_ID,PREPAID_COLLECT "
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

    Function QueryBillFEE(ByVal BLID As String) As DataTable
     
        Try
            Dim SQL As String
            SQL = " Select Fee=Sum(UnitPrice * Quantity),Prepaid_Collect "
            SQL &= " From PriceBillMaster "
            SQL &= " Where PriceBillMaster.BL_ID='" & BLID & "' And Continued=1 Group By Prepaid_Collect"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If ds.Tables("oTableBillFee").Rows.Count > 0 Then
                ds.Tables("oTableBillFee").Rows.Clear()
            End If
            Adapter.Fill(ds.Tables("oTableBillFee"))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function
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
            InsertAutoNumberToGrid(Me.dgdVesselCollection)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub frmFreightInboundList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetDefaultGrid(Me.dgdVesselCollection, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            ds.Tables.Clear()

            ds.Tables.Add("oTableFreight")
            ds.Tables.Add("oTableFee")
            ds.Tables.Add("oTableContainer")
            ds.Tables.Add("oTableBill")
            ds.Tables.Add("oTableBillFee")
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

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(UnitPriceSale * Quantity*exchange) "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (Charge_Code like '%DHC%' Or Charge_Code Like '%THC%' Or charge_Code LIKE '%LHC%') and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
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
            strQuery = " select Fee=Sum(UnitPriceSale * Quantity*tigia) "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID)inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (Charge_Code like '%DHC%' Or Charge_Code Like '%THC%' Or charge_Code LIKE '%LHC%') and Prepaid_Collect='Prepaid' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) "
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

    Sub SetExcelValue()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\ReportAccount.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            Dim bl_no As String
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 7 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                'If Me.RadioMaster.Checked = True Then
                QueryInfo(Vessel, VoyNo, ETD)
                'Else
                '    QueryInfohouse(Vessel, VoyNo, ETD)
                'End If

                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 0 To 6
                    '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                    '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                    '    End If
                    'Next
                    'insert container
                    ws.Range("F" & DongHienTai).Value2 = IIf(QueryPOPCheck(BillID) = 1, "Other POP", " ")
                    ws.Range("A" & DongHienTai).Value2 = Vessel & " - V. " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("Congty").ToString.Trim
                    ws.Range("D" & DongHienTai).Value2 = bl_no
                    If ds.Tables("oTableBill").Rows(i).Item("telex").ToString.Trim = "" Then
                        ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("BL_TYPE").ToString.Trim
                    Else
                        ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("telex").ToString.Trim
                    End If

                    'Insert Cac Loai Phi
                    'If Me.RadioMaster.Checked = True Then

                    QueryBillFEE(BillID)
                    For P As Integer = 0 To ds.Tables("oTableBillFee").Rows.Count - 1
                        If ds.Tables("oTableBillFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableBillFee").Rows(P).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableBillFee").Rows(P).Item("FEE")

                            Else
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableBillFee").Rows(P).Item("FEE")
                            End If
                        End If
                    Next
                    QueryPrice(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableFee").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                                ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")

                            Else
                                ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                            End If

                        End If
                    Next
                    ws.Range("G" & DongHienTai).Value2 = ws.Range("G" & DongHienTai).Value2 + ws.Range("I" & DongHienTai).Value2
                    'End If
                    ''insert OnceaFreight
                    'QueryFreight(BillID)
                    'For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                    '    If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                    '        ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                    '        ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                    '        'Dim Congthuc As String
                    '        ''Congthuc = "=N" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                    '        'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                    '        ''thêm công thức vào NET
                    '        'ws.Range("U" & DongHienTai).Value2 = "=N" & DongHienTai & "+ O" & DongHienTai & "- R" & DongHienTai
                    '        'Else
                    '        '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                    '        '    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                    '        'Dim Congthuc As String
                    '        'Congthuc = "=M" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                    '        'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 

                    '        '' thêm công thức vào NET
                    '        'ws.Range("U" & DongHienTai).Value2 = "=-R" & DongHienTai
                    '    End If
                    'Next

                    'insert Commission
                    'Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
                    'ws.Range("N" & DongHienTai).Value2 = Temp & "%"
                    'ws.Range("O" & DongHienTai).Formula = "=if(Count(G" & DongHienTai & ")>=1, G" & DongHienTai & " * N" & DongHienTai & ",K" & DongHienTai & "* N" & DongHienTai & ")"
                    'If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
                    '    ws.Range("N" & DongHienTai).Value2 = ""
                    '    ws.Range("O" & DongHienTai).Value2 = 15
                    'End If
                    'Inert THC/DHC LHC
                    'QueryDHC_THC(BillID)
                    'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                    '    ws.Range("P" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item(0)
                    'End If

                    'insert freight To Owner()
                    'ws.Range("Q" & DongHienTai).Formula = "=(G" & DongHienTai & "+I" & DongHienTai & ")-O" & DongHienTai & "+P" & DongHienTai

                    ''Insert SaleName
                    'ws.Range("R" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

                    ''insert Extra Charge
                    'ws.Range("T" & DongHienTai).Value2 = "=k" & DongHienTai & "+L" & DongHienTai & "+M" & DongHienTai & "-G" & DongHienTai & "-I" & DongHienTai & "-J" & DongHienTai

                    ''Insert Different
                    'ws.Range("U" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai & "-S" & DongHienTai & "-T" & DongHienTai
                    ''ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

                    ''insert renvenue
                    'ws.Range("V" & DongHienTai).Value2 = "=O" & DongHienTai & "+U" & DongHienTai

                    DongHienTai += 1
                    Dim SQL As String
                    SQL = "Select BLH_NO,BL_TYPE from BillOfLading_House where BL_ID='" & BillID & "' And Continued=1 "
                    Dim Housedt As New DataSet
                    Housedt = ReadDataSet(SQL)
                    For j As Integer = 0 To Housedt.Tables(0).Rows.Count - 1
                        ws.Range("D" & DongHienTai).Value2 = Housedt.Tables(0).Rows(j).Item("BLH_NO").ToString 'vị trí billno
                        ws.Range("O" & DongHienTai).Value2 = Housedt.Tables(0).Rows(j).Item("BL_TYPE").ToString
                        DongHienTai += 1
                    Next
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                'Dim C As Integer
                'For C = 0 To 19
                '    If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "R" Then
                '        Dim Sum As String
                '        Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                '        ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                '        ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                '    End If
                'Next
                'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
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

            Path = "c:\ReportAccount" & strUserId & Vessel & "-" & VoyNo & Strings.Replace(CDate(ETD), "/", "-") & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox(" Không xuất được file excel" & vbCrLf & "Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueHistory()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\ReportAccount.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            Dim bl_no As String
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 7 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETD = Me.dgdVesselCollection.Item("ETDGID", CountVessel).Value
                SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
                'If Me.RadioMaster.Checked = True Then
                QueryInfo(Vessel, VoyNo, ETD)
                'Else
                '    QueryInfohouse(Vessel, VoyNo, ETD)
                'End If

                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    'For k As Integer = 0 To 6
                    '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                    '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
                    '    End If
                    'Next
                    'insert container

                    ws.Range("A" & DongHienTai).Value2 = Vessel & " - V. " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("Congty").ToString.Trim
                    ws.Range("D" & DongHienTai).Value2 = bl_no
                    If ds.Tables("oTableBill").Rows(i).Item("telex").ToString.Trim = "" Then
                        ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("BL_TYPE").ToString.Trim
                    Else
                        ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("telex").ToString.Trim
                    End If

                    'Insert Cac Loai Phi
                    'If Me.RadioMaster.Checked = True Then

                    QueryBillFEE(BillID)
                    For P As Integer = 0 To ds.Tables("oTableBillFee").Rows.Count - 1
                        If ds.Tables("oTableBillFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableBillFee").Rows(P).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableBillFee").Rows(P).Item("FEE")

                            Else
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableBillFee").Rows(P).Item("FEE")
                            End If
                        End If
                    Next
                    QueryPriceHistory(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                            If UCase(ds.Tables("oTableFee").Rows(P).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
                                ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")

                            Else
                                ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                            End If

                        End If
                    Next
                    ws.Range("G" & DongHienTai).Value2 = ws.Range("G" & DongHienTai).Value2 + ws.Range("I" & DongHienTai).Value2
                    

                    DongHienTai += 1
                    Dim SQL As String
                    SQL = "Select BLH_NO,BL_TYPE from BillOfLading_House where BL_ID='" & BillID & "' And Continued=1 "
                    Dim Housedt As New DataSet
                    Housedt = ReadDataSet(SQL)
                    For j As Integer = 0 To Housedt.Tables(0).Rows.Count - 1
                        ws.Range("D" & DongHienTai).Value2 = Housedt.Tables(0).Rows(j).Item("BLH_NO").ToString 'vị trí billno
                        ws.Range("O" & DongHienTai).Value2 = Housedt.Tables(0).Rows(j).Item("BL_TYPE").ToString
                        DongHienTai += 1
                    Next
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                'Dim C As Integer
                'For C = 0 To 19
                '    If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "R" Then
                '        Dim Sum As String
                '        Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
                '        ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
                '        ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
                '    End If
                'Next
                'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
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

            Path = "c:\ReportAccount" & strUserId & Vessel & "-" & VoyNo & Strings.Replace(CDate(ETD), "/", "-") & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox(" Không xuất được file excel" & vbCrLf & "Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    'Sub SetExcelValueAmendMent()
    '    Dim app As Application
    '    Try
    '        Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

    '        app = New Application()
    '        app.Visible = True

    '        Dim workbooks As Workbooks
    '        workbooks = app.Workbooks
    '        Dim workbook As _Workbook

    '        Path = StartupPath & "\OutboundCommissionAmendMent.xls"

    '        workbook = workbooks.Open(Path)



    '        Dim sheets As Sheets
    '        Dim bl_no As String
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
    '            SailID = Me.dgdVesselCollection.Item("SailingScheduleID", CountVessel).Value.ToString
    '            QueryInfo(Vessel, VoyNo, ETD)
    '            Dim BillID As String = ""
    '            Dim n As Integer = ds.Tables("oTableBill").Rows.Count
    '            SoDong = DongHienTai
    '            For i As Integer = 0 To n - 1

    '                BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
    '                bl_no = ds.Tables("oTableBill").Rows(i).Item("BL_No").ToString.Trim
    '                'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
    '                'Insert Bill Info
    '                'For k As Integer = 0 To 6
    '                '    If ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
    '                '        ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k + 1).ToString
    '                '    End If
    '                'Next
    '                'insert container

    '                ws.Range("A" & DongHienTai).Value2 = bl_no 'Vessel & " - " & VoyNo
    '                ws.Range("B" & DongHienTai).Value2 = ETD
    '                QueryContainer(BillID)
    '                Dim CurType As String = " "
    '                For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
    '                    Dim Type As String = ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim
    '                    'If Type = "20GP" Then
    '                    '    ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'ElseIf Type = "40GP" Then
    '                    '    ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'ElseIf Type = "20RF" Then
    '                    '    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'ElseIf Type = "40RF" Then
    '                    '    ws.Range("F" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'ElseIf Type = "40HC" Then
    '                    '    ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'ElseIf Type = "40RH" Then
    '                    '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'Else
    '                    '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    'End If
    '                    If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
    '                        CurType &= "," & Strings.Right(Type, 2)
    '                    End If
    '                    CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
    '                    ws.Range("E" & DongHienTai).Value2 = CurType
    '                    If Strings.Left(Type, 2) = "20" Then
    '                        ws.Range("C" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    Else
    '                        ws.Range("D" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
    '                    End If
    '                Next
    '                'thêm công thức vào teu
    '                'Insert Cac Loai Phi
    '                QueryPrice(BillID)
    '                For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
    '                    If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
    '                        If UCase(ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim) = "PREPAID" Then
    '                            ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
    '                            ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
    '                            'ws.Range("J" & DongHienTai).Value2 = "P"
    '                        Else
    '                            ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
    '                            ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
    '                            'ws.Range("J" & DongHienTai).Value2 = "C"
    '                        End If

    '                    End If
    '                Next


    '                'insert OnceaFreight
    '                QueryFreight(BillID)
    '                For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
    '                    If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString.Trim) = "PREPAID" Then
    '                        ws.Range("G" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
    '                        ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
    '                        'Dim Congthuc As String
    '                        ''Congthuc = "=N" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
    '                        'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
    '                        ''thêm công thức vào NET
    '                        'ws.Range("U" & DongHienTai).Value2 = "=N" & DongHienTai & "+ O" & DongHienTai & "- R" & DongHienTai
    '                        'Else
    '                        '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
    '                        '    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
    '                        'Dim Congthuc As String
    '                        'Congthuc = "=M" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
    '                        'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 

    '                        '' thêm công thức vào NET
    '                        'ws.Range("U" & DongHienTai).Value2 = "=-R" & DongHienTai
    '                    End If
    '                Next

    '                'insert Commission
    '                Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
    '                ws.Range("N" & DongHienTai).Value2 = Temp & "%"
    '                ws.Range("O" & DongHienTai).Formula = "=if(Count(G" & DongHienTai & ")>=1, G" & DongHienTai & " * N" & DongHienTai & ",K" & DongHienTai & "* N" & DongHienTai & ")"
    '                If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
    '                    ws.Range("N" & DongHienTai).Value2 = ""
    '                    ws.Range("O" & DongHienTai).Value2 = 15
    '                End If
    '                'Inert THC/DHC
    '                'QueryDHC_THC(BillID)
    '                'If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
    '                '    ws.Range("U" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item(0)
    '                'End If

    '                'insert freight To Owner()
    '                ws.Range("P" & DongHienTai).Formula = "=(G" & DongHienTai & "+I" & DongHienTai & ")-O" & DongHienTai '& "+P" & DongHienTai

    '                'Insert SaleName
    '                ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

    '                'Insert Different
    '                ws.Range("T" & DongHienTai).Value2 = "=k" & DongHienTai & "-G" & DongHienTai & "-R" & DongHienTai & "-S" & DongHienTai
    '                'ds.Tables("oTableBill").Rows(i).Item("SaleName").ToString.Trim

    '                'insert renvenue
    '                ws.Range("U" & DongHienTai).Value2 = "=O" & DongHienTai & "+T" & DongHienTai

    '                DongHienTai += 1
    '                'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
    '                'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
    '            Next
    '            ws.Range("A" & DongHienTai, "B" & DongHienTai).Cells.MergeCells = 1
    '            ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
    '            ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '            ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '            'ws.Range("B" & DongHienTai).Value2 = ETD
    '            Dim C As Integer
    '            For C = 0 To 18
    '                If Alpha(C + 2) <> "N" And Alpha(C + 2) <> "Q" Then
    '                    Dim Sum As String
    '                    Sum = "=sum(" & Alpha(C + 2) & SoDong & ":" & Alpha(C + 2) & DongHienTai - 1 & ")"
    '                    ws.Range(Alpha(C + 2) & DongHienTai).Cells.Font.Bold = 1
    '                    ws.Range(Alpha(C + 2) & DongHienTai).Formula = Sum
    '                End If
    '            Next
    '            'ws.Range("A" & DongHienTai, "Q" & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
    '            DongHienTai += 1
    '        Next
    '        'ws.Range("A8", "Q" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)

    '        'SUM TOÀN BỘ FILE
    '        'Dim ToTal As Integer
    '        'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
    '        'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
    '        'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '        'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '        'For ToTal = 0 To 10
    '        '    'If Alpha(ToTal + 7) <> "Q" Then
    '        '    Dim Sum As String
    '        '    Sum = "=sum(" & Alpha(ToTal + 7) & 8 & ":" & Alpha(ToTal + 7) & DongHienTai - 1 & ")"
    '        '    ws.Range(Alpha(ToTal + 7) & DongHienTai).Formula = Sum
    '        '    'End If
    '        'Next

    '        Path = "c:\OutboundCommissionAmendMent" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

    '        workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

    '    Catch ex As Exception
    '        MsgBox(" Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
    '        MsgBox(Err.Description)
    '        Return
    '    Finally
    '        app.Quit()
    '    End Try

    'End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try

            If Me.dgdVesselCollection.RowCount <= 0 Then
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

    Private Sub dgdVesselCollection_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdVesselCollection.CellContentClick

    End Sub

    Private Sub dgdVesselCollection_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdVesselCollection.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdVesselCollection)
    End Sub

End Class