Imports Excel
Public Class frmFreightSettleOutBound1

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
            strSQL = "Select BillOfLading.BL_ID,Vessel + ' - ' + VoyNo As F1,ETD as F2,BL_NO as F3,Shipper_1 as F4,SaleName as F5,PORT_OF_LOADING_CODE as F6,PORT_OF_DISCHARGE_CODE as F7,Commission,BillOfLading.TAX "
            strSQL &= " from ((((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strSQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_id=Vessel.Vessel_ID) "
            strSQL &= " LEFT JOIN Shipper On BillOfLading.Shipper_ID=Shipper.Shipper_ID) "
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
            strSQL = "Select PREPAID_COLLECT,Fee=Sum(Amount*Quantity)  "
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)"
            strSQL &= " where BL_ID='" & BillId.Trim & "' And Charge_Code <>'OCB' And Charge_Code <>'DCB' And Charge_Code <>'THC' And Charge_Code <>'DHC'  And FREIGHT_CHARGE_Master.Continued=1  GROUP BY PREPAID_COLLECT"
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

    Sub QueryDHC_THC(ByVal billID As String)
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select Fee=Sum(Amount * Quantity) "
            strQuery &= " From (Freight_Charge_Master LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID)"
            strQuery &= " Where BL_ID='" & billID & "' and Freight_Charge_Master.Continued=1 And (Charge_Code like '%DHC%' Or Charge_Code Like '%THC%') and Prepaid_Collect='Prepaid'"
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

    Sub QueryFreight(ByVal BillId As String)
        Try
            Dim strSQL As String
            strSQL = "Select BL_ID,PREPAID_COLLECT,OceanFreight=Sum(Amount* Quantity)"
            strSQL &= " from (FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID)"
            strSQL &= " where BL_ID='" & BillId.Trim & "' And (Charge_Code ='OCB' Or Charge_Code='DCB') And FREIGHT_CHARGE_Master.Continued=1 Group by BL_ID,PREPAID_COLLECT "
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
            InsertAutoNumberToGrid(Me.dgdVesselCollection)
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
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            Path = StartupPath & "\FreightOutBoundList1.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 10 ' dòng hiên hành Dang Xét
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
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BL_ID").ToString.Trim
                    ws.Range("A" & DongHienTai).Value = i + 1
                    'QueryPrice(ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim)
                    'Insert Bill Info
                    For k As Integer = 1 To 7
                        If ds.Tables("oTableBill").Rows(i).Item("F" & k).ToString.Length > 0 Then
                            ws.Range(Alpha(k) & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("F" & k).ToString
                        End If
                    Next
                    Dim Pos As Integer = 8
                    'insert container
                    QueryContainer(BillID)
                    Dim CurType As String = " "
                    For CountContainer As Integer = 0 To ds.Tables("oTableContainer").Rows.Count - 1
                        Dim Type As String = UCase(ds.Tables("oTableContainer").Rows(CountContainer).Item("Container_type").ToString.Trim)
                        'If Type = "20GP" Then
                        '    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40GP" Then
                        '    ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "20RF" Then
                        '    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RF" Then
                        '    ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40HC" Then
                        '    ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'ElseIf Type = "40RH" Then
                        '    ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'Else
                        '    ws.Range("N" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        'End If
                        If Not (CurType Like "*" & Strings.Right(Type, 2) & "*") Then
                            CurType &= "," & Strings.Right(Type, 2)
                        End If
                        CurType = IIf(CurType(1) = ",", CurType.Remove(1, 1), CurType)
                        ws.Range("L" & DongHienTai).Value2 = CurType
                        If Type = "40HC" Then
                            ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                        Else
                            If Strings.Left(Type, 2) = "20" Then
                                ws.Range("I" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            Else
                                ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableContainer").Rows(CountContainer).Item("SoLuong")
                            End If
                        End If

                    Next
                    'thêm công thức vào teu
                    'Insert Cac Loai Phi
                    QueryPrice(BillID)
                    For P As Integer = 0 To ds.Tables("oTableFee").Rows.Count - 1
                        If UCase(ds.Tables("oTableFee").Rows(P).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                            If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                            End If
                        Else
                            If ds.Tables("oTableFee").Rows(P).Item("FEE").ToString.Trim.Length > 0 Then
                                ws.Range("R" & DongHienTai).Value2 = ds.Tables("oTableFee").Rows(P).Item("FEE")
                            End If
                        End If

                    Next
                    'Commission
                    Dim Temp As String = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim(), "%", "")
                    'ws.Range("V" & DongHienTai).Value2 = Temp & "%"
                    'ws.Range("W" & DongHienTai).Formula = "=(O" & DongHienTai & "+ P" & DongHienTai & ")* V" & DongHienTai
                    'If UCase(ds.Tables("oTableBill").Rows(i).Item("Commission").ToString.Trim) = "A" Then
                    '    ws.Range("V" & DongHienTai).Value2 = ""
                    '    ws.Range("W" & DongHienTai).Value2 = 15
                    'End If
                    ''TAX
                    'Temp = Strings.Replace(ds.Tables("oTableBill").Rows(i).Item("TAX").ToString.Trim(), "%", "")
                    'ws.Range("Y" & DongHienTai).Value2 = Temp & "%"
                    'ws.Range("Z" & DongHienTai).Formula = "=(O" & DongHienTai & "+ P" & DongHienTai & ")* Y" & DongHienTai
                    'Net
                    'ws.Range("AA" & DongHienTai).Value2 = "=if(Count(O" & DongHienTai & ")>=1,O" & DongHienTai & " +Q" & DongHienTai & "+R" & DongHienTai & "-W" & DongHienTai & "-Z" & DongHienTai & ",-W" & DongHienTai & "-Z" & DongHienTai & ") + T" & DongHienTai & "-U" & DongHienTai
                    QueryDHC_THC(BillID)
                    If dsTHC_DHC.Tables(0).Rows.Count > 0 Then
                        'For j As Integer = 0 To dsTHC_DHC.Tables(0).Rows.Count - 1
                        'If UCase(dsTHC_DHC.Tables(0).Rows(j).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                        'ws.Range("O" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                        '' Else
                        'ws.Range("P" & CurRow).Value2 = dsTHC_DHC.Tables(0).Rows(j).Item("Fee").ToString
                        If dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString <> "" Then
                            ws.Range("T" & DongHienTai).Value2 = dsTHC_DHC.Tables(0).Rows(0).Item("Fee").ToString

                            ws.Range("U" & DongHienTai).Formula = "=if((7.5 * T" & DongHienTai & ") / 100>0,(7.5 * T" & DongHienTai & ") / 100,"""")"
                        End If
                        ' End If
                        ' Next
                    End If

                    'insert OnceaFreight
                    QueryFreight(BillID)
                    For F As Integer = 0 To ds.Tables("oTableFreight").Rows.Count - 1
                        If UCase(ds.Tables("oTableFreight").Rows(F).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
                            ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")

                            'Dim Congthuc As String
                            ''Congthuc = "=N" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 
                            ''thêm công thức vào NET
                            'ws.Range("U" & DongHienTai).Value2 = "=N" & DongHienTai & "+ O" & DongHienTai & "- R" & DongHienTai
                        Else
                            ws.Range("O" & DongHienTai).Value2 = ds.Tables("oTableFreight").Rows(F).Item("OceanFreight")
                            'Dim Congthuc As String
                            'Congthuc = "=M" & DongHienTai & "*" & Me.txtHandingFee.Text & "/100"
                            'ws.Range("R" & DongHienTai).Formula = Congthuc  ' thêm Công thức tính commision 

                            '' thêm công thức vào NET
                            'ws.Range("U" & DongHienTai).Value2 = "=-R" & DongHienTai
                        End If
                    Next


                    ' ws.Range("Q" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee
                    ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                    ws.Range("B" & DongHienTai).Value2 = ETD
                    DongHienTai += 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "Q" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                Next
                ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
                ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                'ws.Range("B" & DongHienTai).Value2 = ETD
                Dim C As Integer
                For C = 0 To 10
                    ' If Alpha(C + 7) <> "Q" Then
                    Dim Sum As String
                    Sum = "=sum(" & Alpha(C + 7) & SoDong & ":" & Alpha(C + 7) & DongHienTai - 1 & ")"
                    ws.Range(Alpha(C + 7) & DongHienTai).Cells.Font.Bold = 1
                    ws.Range(Alpha(C + 7) & DongHienTai).Formula = Sum
                    'End If
                Next
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

            Path = "c:\FreightSettleForm2" & strUserId & Vessel & "-" & VoyNo & CDate(ETD) & Now.Second & ".xls"

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

            SetExcelValue()

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



    Private Sub dgdVesselCollection_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdVesselCollection.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdVesselCollection)
    End Sub
End Class