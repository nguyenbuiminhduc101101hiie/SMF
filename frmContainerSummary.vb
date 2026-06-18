Imports Excel
Public Class frmContainerSummary
    Dim ds As New DataSet
    Dim Path As String
    Dim Vessel, VoyNo As String
    Dim ETA As Date
    Dim dem As Integer = 0

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct Vessel +' - '+ Voyage + ' - ' + convert(nvarchar,ETA)  as data "
            SQL &= "from BillOfLadingIB where Continued=1 And ETA >='" & Me.dtpFromETA.Value.Date & "' And ETA<='" & Me.dtpToETA.Value.Date & "'"
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

    Sub QueryInfo(ByVal Vessel As String, ByVal Voyno As String, ByVal ETA As Date)
        Try
            Dim strSQL As String
            strSQL = "Select BillOfLadingIB.BLIB_ID,BLIB_NO,Container_No,Container_type,GROSSWEIGHT,"
            strSQL &= " POR,POL ,POD,DEL,Vessel , Voyage ,ETA "
            strSQL &= " from ((BillOfLadingIB LEFT JOIN CargoIB On CargoIb.BLIB_ID=BillOfLadingIb.BLIB_ID )"
            strSQL &= " LEFT JOIN Container On CargoIB.CTN_ID=Container.CTN_ID )"
            strSQL &= " Where Vessel='" & Vessel.Trim & "' And Voyage='" & Voyno.Trim & "' And ETA='" & ETA & "' And BillOfLadingIB.Continued=1"
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

    'Sub QueryContainer(ByVal BillId As String)
    '    Try
    '        Dim strSQL As String
    '        strSQL = "Select Container_type,Count(container_Type) as SoLuong from CargoIB"
    '        strSQL &= " where cargoib.BLIB_ID='" & BillId.Trim & "' Group by Container_type"
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()

    '        Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        If ds.Tables("oTableContainer").Rows.Count > 0 Then
    '            ds.Tables("oTableContainer").Rows.Clear()
    '        End If
    '        Adapter.Fill(ds.Tables("oTableContainer"))
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '    End Try
    'End Sub

    'Sub QueryPrice(ByVal BillId As String)
    '    Try
    '        Dim strSQL As String
    '        strSQL = "Select PREPAID_COLLECT,Sum(UnitPrice)as Fee from FREIGHT_CHARGE_IB "
    '        strSQL &= " where BLIB_ID='" & BillId.Trim & "' And Items <>'OCB' GROUP BY PREPAID_COLLECT"
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        If ds.Tables("oTableFee").Rows.Count > 0 Then
    '            ds.Tables("oTableFee").Rows.Clear()
    '        End If
    '        Adapter.Fill(ds.Tables("oTableFee"))
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '    End Try
    'End Sub

    'Sub QueryFreight(ByVal BillId As String)
    '    Try
    '        Dim strSQL As String
    '        strSQL = "Select BLIB_ID,PREPAID_COLLECT,Sum(UnitPrice) as OceanFreight from FREIGHT_CHARGE_IB "
    '        strSQL &= " where BLIB_ID='" & BillId.Trim & "' And Items ='OCB'  Group by BLIB_ID,PREPAID_COLLECT"
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        If ds.Tables("oTableFreight").Rows.Count > 0 Then
    '            ds.Tables("oTableFreight").Rows.Clear()
    '        End If
    '        Adapter.Fill(ds.Tables("oTableFreight"))
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '    End Try
    'End Sub

    Private Sub cmdAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAdd.Click
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            Dim tempds As New DataSet
            tempds.Tables.Add("Vessel")
            tempds.Tables(0).Columns.Add("Vessel")
            tempds.Tables(0).Columns.Add("Voyno")
            tempds.Tables(0).Columns.Add("ETA")
            Me.dgdVesselCollection.Rows.Add(1)
            Dim Countdgd As Integer = Me.dgdVesselCollection.RowCount - 1
            Dim row As DataRow
            row = tempds.Tables(0).NewRow
            Dim tempvessel() As String
            tempvessel = Strings.Split(Me.cboVessel.Text, " - ")
            row("Vessel") = IIf(tempvessel.Length > 0, tempvessel(0), "")
            row("VoyNo") = IIf(tempvessel.Length > 1, tempvessel(1), "")
            row("ETA") = IIf(tempvessel.Length > 2, CDate(tempvessel(2)), "")
            Me.dgdVesselCollection.Item("Vesselgid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(0), "")
            Me.dgdVesselCollection.Item("VoyNogid", Countdgd).Value = IIf(tempvessel.Length > 0, tempvessel(1), "")
            Me.dgdVesselCollection.Item("ETAgid", Countdgd).Value = IIf(tempvessel.Length > 0, CDate(tempvessel(2)), "")
            InsertAutoNumberToGrid(Me.dgdVesselCollection)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub frmContainerSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetDefaultGrid(Me.dgdVesselCollection, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
            ds.Tables.Clear()
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
    '            ETA = Me.dgdVesselCollection.Item("ETAGID", CountVessel).Value
    '            QueryInfo(Vessel, VoyNo, ETA)
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
    '                ws.Range("B" & DongHienTai).Value2 = ETA
    '                ws.Range("W" & DongHienTai).Formula = "=R" & DongHienTai & " + V" & DongHienTai
    '                DongHienTai += 1
    '                ws.Range("A8", "W" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
    '                ws.Range("A8", "W" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
    '            Next
    '            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
    '            'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
    '            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
    '            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
    '            'ws.Range("B" & DongHienTai).Value2 = ETA
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

    '        Path = "c:\InboundCommission" & Vessel & "-" & VoyNo & CDate(ETA) & Now.Second & ".xls"

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

            Path = StartupPath & "\ContainerSummary.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim DongHienTai As Integer = 5 ' dòng hiên hành Dang Xét
            Dim SoDong As Integer = 0 'dong bắt đầu của một tàu mới
            For CountVessel As Integer = 0 To Me.dgdVesselCollection.RowCount - 1 ' chạy hết tất cả các tàu đã chọn

                Vessel = Me.dgdVesselCollection.Item("VesselGID", CountVessel).Value
                VoyNo = Me.dgdVesselCollection.Item("VoyNoGID", CountVessel).Value
                ETA = Me.dgdVesselCollection.Item("ETAGID", CountVessel).Value
                QueryInfo(Vessel, VoyNo, ETA)
                Dim BillID As String = ""
                Dim n As Integer = ds.Tables("oTableBill").Rows.Count
                SoDong = DongHienTai
                For i As Integer = 0 To n - 1

                    BillID = ds.Tables("oTableBill").Rows(i).Item("BLIB_ID").ToString.Trim

                    ws.Range("E" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("BLIB_NO").ToString
                    ws.Range("H" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("Container_No").ToString
                    ws.Range("J" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("Container_type").ToString
                    ws.Range("K" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("GrossWeight").ToString
                    'ws.Range("L" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("OPR").ToString
                    ws.Range("M" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("POR").ToString
                    ws.Range("N" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("POL").ToString
                    ws.Range("P" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("POD").ToString
                    ws.Range("Q" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("DEL").ToString
                    ws.Range("U" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("Vessel").ToString
                    ws.Range("V" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("VoyAge").ToString
                    ws.Range("W" & DongHienTai).Value2 = ds.Tables("oTableBill").Rows(i).Item("ETA").ToString
                    
                    'ws.Range("Q" & DongHienTai).Value2 = Me.txtHandingFee.Text ' thêm commission % handingfee
                    'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                    'ws.Range("B" & DongHienTai).Value2 = ETA
                    'DongHienTai += 1
                    'ws.Range("A8", "U" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                    'ws.Range("A8", "U" & DongHienTai).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = 1
                    DongHienTai += 1
                Next
                'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
                'ws.Range("A" & DongHienTai).Value2 = Vessel & " - " & VoyNo
                'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
                'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
                ''ws.Range("B" & DongHienTai).Value2 = ETA
                'ws.Range("A" & DongHienTai, Alpha(C + 4) & DongHienTai).Cells.BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 1)
                DongHienTai += 1
            Next
            'ws.Range("A8", "U" & DongHienTai - 1).BorderAround(1, XlBorderWeight.xlThick, XlColorIndex.xlColorIndexAutomatic, 5)
            'Dim ToTal As Integer
            'ws.Range("A" & DongHienTai, "C" & DongHienTai).Cells.MergeCells = 1
            'ws.Range("A" & DongHienTai).Value2 = "GRAND TOTAL ="
            'ws.Range("A" & DongHienTai).Cells.Font.Bold = 1
            'ws.Range("A" & DongHienTai).Cells.HorizontalAlignment = 3 'align center
            'For ToTal = 0 To 16
            '    If Alpha(ToTal + 5) <> "Q" Then
            '        Dim Sum As String
            '        Sum = "=sum(" & Alpha(ToTal + 5) & 8 & ":" & Alpha(ToTal + 5) & DongHienTai - 1 & ")"
            '        ws.Range(Alpha(ToTal + 5) & DongHienTai).Formula = Sum
            '    End If
            'Next

            Path = "c:\ContainerSummary" & strUserId & Vessel & "-" & VoyNo & CDate(ETA) & Now.Second & ".xls"

            workbook.SaveAs(Path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & "Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
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
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpFromETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETA.ValueChanged
        Try
            QueryVessel()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dtpToETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETA.ValueChanged
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