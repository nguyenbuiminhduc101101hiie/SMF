Imports System
'Imports System.Reflection ' For Missing.Value and BindingFlags
'Imports System.Runtime.InteropServices ' For COMException
Imports Excel


Module ExportXls
    Public bEvent As Boolean
  
    'key 1 : top
    'key 2 : bottom
    'key 3 : left
    'key 4 : right
    'key 5 : around

    Public Sub FormatFont(ByVal ws As Excel._Worksheet, ByVal Cell1 As String, Optional ByVal Cell2 As String = "", Optional ByVal nFont As String = "Times New Roman", Optional ByVal nBold As Integer = 0, Optional ByVal nItalic As Integer = 0, Optional ByVal nSize As Integer = 8)
        Try
            If Cell2 = "" Then
                ws.Range(Cell1).Cells.Font.Name = nFont
                ws.Range(Cell1).Cells.Font.Bold = nBold
                ws.Range(Cell1).Cells.Font.Italic = nItalic
                ws.Range(Cell1).Cells.Font.Size = nSize
            Else
                ws.Range(Cell1, Cell2).Cells.Font.Name = nFont
                ws.Range(Cell1, Cell2).Cells.Font.Bold = nBold
                ws.Range(Cell1, Cell2).Cells.Font.Italic = nItalic
                ws.Range(Cell1, Cell2).Cells.Font.Size = nSize
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Function ExportExpress_Quotation(ByVal dgdView As DataGridView, ByVal stForm As Form, ByVal customer As String, ByVal codeselling As String, ByVal salename As String, ByVal proposal As String) As Boolean
        Dim app As Application
        Try
            Dim d As Date = CDate(Getdate())
            Dim path As String = ""
            Dim catCus() As String
            catCus = customer.Split(" ")

            'path = OpenDlg(catCus(0) & " " & codeselling & " .xls")
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + catCus(0) & " " & codeselling & " .xls"

            '"c:\" & stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"

            If path = "" Then
                Return False
            End If

            stForm.Cursor = Cursors.WaitCursor

            app = New Application()
            'app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If

            Dim i, j As Integer
            Dim nRow As Integer = 10
            Dim nCol As Integer = 0
            Dim cell As String = "A"
            Dim arrCol As String()

            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count

            ReDim arrCol(col - 1)
            ' lay thong tin khach hang
            Dim sqlkh As String
            Dim dskh As New DataSet
            sqlkh = "select * from customer where company='" & customer & "' and continued=1"
            dskh = ReadDataSet(sqlkh)
            If dskh.Tables(0).Rows.Count > 0 Then
                ws.Range(cell & 1).Value = "To"
                ws.Range(cell & 2).Value = "Company :"
                ws.Range(cell & 3).Value = "Email :"
                ws.Range(cell & 4).Value = "Address :"
                ws.Range(cell & 5).Value = "Phone :"
                ws.Range(cell & 6).Value = "Service Code :"
                ws.Range(cell & 6).Value = "Account No. :"
                ws.Range(cell & 6).Value = "QUOTATION"
                '--
                ws.Range("B" & 1).Value = UCase(dskh.Tables(0).Rows(0).Item("attn").ToString)
                ws.Range("B" & 2).Value = UCase(dskh.Tables(0).Rows(0).Item("company").ToString)
                ws.Range("B" & 3).Value = UCase(dskh.Tables(0).Rows(0).Item("email").ToString)
                ws.Range("B" & 4).Value = UCase(dskh.Tables(0).Rows(0).Item("address").ToString)
                ws.Range("B" & 5).Value = UCase(dskh.Tables(0).Rows(0).Item("tel").ToString)
                ws.Range("B" & 6).Value = "Courier"
                ws.Range("B" & 6).Value = UCase(dskh.Tables(0).Rows(0).Item("customer_code").ToString)

                '-----
                ws.Range("C" & 1).Value = "Proposal No. :"
                ws.Range("C" & 2).Value = "From :"
                ws.Range("C" & 3).Value = "Sale :"
                ws.Range("C" & 4).Value = "Sender :"
                ws.Range("C" & 5).Value = "Cell Phone :"
                ws.Range("C" & 6).Value = "Email :"
                ws.Range("C" & 6).Value = "Eff. Date :"
                '--
                ws.Range("d" & 1).Value = proposal
                ws.Range("d" & 2).Value = "NPV"
                ws.Range("d" & 3).Value = UCase(salename)
                ws.Range("d" & 4).Value = ""
                ws.Range("d" & 5).Value = ""
                ws.Range("d" & 6).Value = "Courier"
                ws.Range("d" & 6).Value = codeselling

            End If
            '-----------------------------------

            Dim st As String = cell
            nCol = 0

            '====================================

            pal = New System.Windows.Forms.GroupBox
            With pal
                pal.Width = 316
                pal.Height = 111
                pal.Left = stForm.Width / 2 - pal.Width / 2
                pal.Top = stForm.Height / 2 - pal.Height / 2
                .Text = "Please wait ..... "
                .Name = "pal"
            End With
            stForm.Controls.Add(pal)
            stForm.Controls.Item("pal").BringToFront()

            Dim prb As New ProgressBar
            With prb
                .Minimum = 0
                .Maximum = row
                .Width = 280
                .Height = 20
                .Left = pal.Width / 2 - .Width / 2
                .Top = 34
                .Name = "prbExcel"
            End With
            stForm.Controls.Add(prb)
            pal.Controls.Add(prb)

            cmd = New System.Windows.Forms.Button
            With cmd
                .Width = 75
                .Height = 23
                .Left = pal.Width / 2 - .Width / 2
                .Top = 80
                .Text = "Stop"
                .Name = "cmdStop"
            End With
            AddHandler cmd.Click, AddressOf cmd_Click
            stForm.Controls.Add(cmd)
            pal.Controls.Add(cmd)

            lbl = New System.Windows.Forms.Label
            With lbl
                .Text = "00%"
                .Left = pal.Width / 2
                .Top = prb.Top + prb.Height + 10
                .ForeColor = Color.Blue
            End With
            stForm.Controls.Add(lbl)
            pal.Controls.Add(lbl)

            max = row
            prb.Maximum = row + 1

            '====================================

            For j = 0 To col - 1
                If dgdView.Columns(j).Visible = True Then
                    st = SetCell(st)
                    arrCol(nCol) = st
                    ws.Range(arrCol(nCol) & nRow).Value = dgdView.Columns(j).HeaderText
                    nCol += 1
                End If
            Next

            drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)
            ' drawBorder(ws, 6, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            nRow += 1

            'For i = 0 To row - 1
            i = 0
            bEvent = False

            Dim cnt As Double = 100 / row
            Dim ncnt As Double = cnt

            While i <> row And bEvent = False
                prb.Value = i + 1
                lbl.Text = CInt(ncnt) & "%"
                nCol = 0
                System.Windows.Forms.Application.DoEvents()
                For j = 0 To col - 1
                    If dgdView.Columns(j).Visible = True Then
                        ws.Range(arrCol(nCol) & nRow).Value = dgdView.Item(j, i).Value
                        'Dim bool As Boolean
                        'bool = IIf(dgdView.Rows(i).DefaultCellStyle.ForeColor = Color.Red, True, False)
                        'If bool = True Then
                        '    ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = 255 'System.Drawing.Color.Red.ToArgb
                        'End If
                        'Dim _color As System.Drawing.Color = dgdView.Rows(i).DefaultCellStyle.ForeColor
                        'ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = "Red" ' CDbl(_color.GetHue)
                        'dgdView.Item(j, i).Style.ForeColor.ToArgb
                        nCol += 1
                    End If
                Next
                ws.Range("A" & nRow).Value = i + 1
                ws.Range("A" & nRow).BorderAround(, XlBorderWeight.xlMedium)
                ws.Range("A" & nRow).Cells.HorizontalAlignment = 3

                nRow += 1
                i = i + 1
                ncnt += cnt

            End While
            'Next

            For i = 0 To nCol - 1
                ws.Range(arrCol(i) & 3, arrCol(i) & nRow - 1).Cells.Columns.AutoFit()
            Next

            'For i = 4 To nRow - 1
            '    ws.Range(arrCol(0) & i, arrCol(nCol) & i).Cells.Rows.AutoFit()
            'Next

            'drawBorder(ws, 5, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)

            'drawBorder(ws, 6, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)
            If row > 1 Then
                'drawBorder(ws, 1, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
                'drawBorder(ws, 2, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)

            End If
            If col > 1 Then
                'drawBorder(ws, 3, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
                'drawBorder(ws, 4, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If

            path = ProccessString(path)
            workbook.Application.DisplayAlerts = False
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            workbook.Application.DisplayAlerts = True
            stForm.Cursor = Cursors.Default

            MsgBox("Complete path " & path)
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)

            app.Visible = True

            app.Quit()

            Return True
        Catch ex As Exception
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)
            MsgBox(ex.Message)
            stForm.Cursor = Cursors.Default
            Return False
        Finally

        End Try
    End Function
    Public Sub AlignHorVer(ByVal ws As Excel._Worksheet, ByVal Cell1 As String, Optional ByVal Cell2 As String = "", Optional ByVal nHorizontal As Integer = 3, Optional ByVal nVertical As Integer = 2)
        If Cell2 = "" Then
            ws.Range(Cell1).Cells.HorizontalAlignment = nHorizontal
            ws.Range(Cell1).Cells.VerticalAlignment = nVertical
        Else
            ws.Range(Cell1, Cell2).Cells.HorizontalAlignment = nHorizontal
            ws.Range(Cell1, Cell2).Cells.VerticalAlignment = nVertical
        End If
    End Sub
    Sub QueryContainer(ByRef ds As DataSet, Optional ByVal BL As String = "")
        Try
            Dim strSQL As String
            strSQL = "select Container_No,Seal,Container_Type "
            strSQL &= " From (CargoIB INNER JOIN Container On CargoIB.CTN_ID=Container.CTN_ID)"
            strSQL &= " Where BLIB_ID='" & BL & "' And CargoIB.Continued=1"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            ds.Tables.Clear()
            ds.Tables.Add()
            Adapter.Fill(ds.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryCountContainer(ByRef ds As DataSet, Optional ByVal BL As String = "")
        Try
            Dim strSQL As String
            strSQL = "select Container_Type,Count(Container_Type) as Num "
            strSQL &= " From CargoIB "
            strSQL &= " Where BLIB_ID='" & BL & "' And Continued=1 Group By Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            ds.Tables.Clear()
            ds.Tables.Add()
            Adapter.Fill(ds.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryFreight(ByRef ds As DataSet, Optional ByVal BL As String = "")
        Try
            Dim strSQL As String
            strSQL = "select Prepaid_collect,Freight=sum(UnitPrice*Quantity)  "
            strSQL &= " From FREIGHT_CHARGE_IB "
            strSQL &= " Where FREIGHT_CHARGE_IB.Continued=1 And Items ='OCB' And BLIB_ID='" & BL & "' Group By Prepaid_collect"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            ds.Tables.Clear()
            ds.Tables.Add()
            Adapter.Fill(ds.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryShipper(ByRef ds As DataSet)
        Try
            'Dim strSQL As String
            'strSQL = "select * "
            'strSQL &= " From Shipper "
            'strSQL &= " Where Continued=1 Order By Shipper_1 "
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            'ds.Tables.Clear()
            'ds.Tables.Add()
            'Adapter.Fill(ds.Tables(0))
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryConsignee(ByRef ds As DataSet)
        Try
            Dim strSQL As String
            strSQL = "select * "
            strSQL &= " From Consignee "
            strSQL &= " Where Continued=1 Order By Consignee_1 "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            ds.Tables.Clear()
            ds.Tables.Add()
            Adapter.Fill(ds.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Sub QueryPrice(ByRef ds As DataSet, Optional ByVal BL As String = "")
        Try
            Dim strSQL As String
            strSQL = "select Prepaid_Collect,sum(UnitPrice*Quantity) as Price "
            strSQL &= " From FREIGHT_CHARGE_IB "
            strSQL &= " Where BLIB_ID='" & BL & "' And Continued=1 And Items<>'OCB' Group By Prepaid_Collect"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            ds.Tables.Clear()
            ds.Tables.Add()
            Adapter.Fill(ds.Tables(0))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Function tim(ByVal key As String, ByVal FindField As String, ByVal ValueFiled As String, ByVal ds As DataSet)
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            If ds.Tables(0).Rows(i).Item(FindField).ToString Like "*" & key & "*" Then
                Return ds.Tables(0).Rows(i).Item(ValueFiled).ToString()
            End If
        Next
        Return ""
    End Function

    Public Function ExportExecelBillInbound(ByVal dgdView As DataGridView, ByVal stForm As Form) As Boolean
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "V", "U", "W", "X", "Y", "Z"}
            stForm.Cursor = Cursors.WaitCursor

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook
            Dim path As String = StartupPath & "\BILLInboudData.xls"
            workbook = workbooks.Open(path)
            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If

            Dim i, j As Integer
            Dim BgRow As Integer = 5
            Dim CurRow As Integer
            CurRow = BgRow
            Dim nCol As Integer = 0
            ' Dim arrCol As String()
            Dim ds As New DataSet
            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count
            Dim Pre_Col As String = ""
            Dim dsShipper As New DataSet
            Dim dsConsignee As New DataSet
            QueryConsignee(dsConsignee)
            QueryShipper(dsShipper)
            For j = 0 To row - 1
                Dim BLID As String
                BLID = dgdView.Item("BL_ID", j).Value.ToString
                'kiem tra bill prepaid hay collect
                Dim strPre_Col As String = "Select Distinct PREPAID_COLLECT From Freight_Charge_IB where BLIB_ID='" & BLID & "' And Continued=1"
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Dim cmd As New SqlClient.SqlCommand(strPre_Col, Conn)
                Dim da As New SqlClient.SqlDataAdapter(cmd)
                Dim dsFreight As New DataSet


                dsFreight.Tables.Clear()
                dsFreight.Tables.Add()

                da.Fill(dsFreight.Tables(0))
                If dsFreight.Tables(0).Rows.Count > 0 Then
                    If dsFreight.Tables(0).Rows.Count = 2 Then
                        Pre_Col = "COLLECT"
                    ElseIf dsFreight.Tables(0).Rows(0).Item(0).ToString.Trim = "PREPAID" Then
                        Pre_Col = "PREPAID"
                    Else
                        Pre_Col = "COLLECT"
                    End If
                Else
                    Pre_Col = "PREPAID"
                End If

                ws.Range("B" & CurRow).Value2 = dgdView.Item("BL_NO", j).Value.ToString
                ws.Range("E" & CurRow).Value2 = dgdView.Item("ICDPort", j).Value.ToString
                ws.Range("O" & CurRow).Value2 = dgdView.Item("PLACE_OF_RECEIPT", j).Value.ToString
                ws.Range("P" & CurRow).Value2 = dgdView.Item("POL", j).Value.ToString
                ws.Range("Q" & CurRow).Value2 = Mid(dgdView.Item("BL_NO", j).Value.ToString.Trim, 2, 3)
                ws.Range("R" & CurRow).Value2 = dgdView.Item("VESSEL", j).Value.ToString
                ws.Range("S" & CurRow).Value2 = dgdView.Item("VoyAge", j).Value.ToString
                ws.Range("T" & CurRow).Value2 = dgdView.Item("ETA", j).Value.ToString
                ws.Range("V" & CurRow).Value2 = dgdView.Item("PORT_OF_DISCHARGE", j).Value.ToString.Trim
                ws.Range("W" & CurRow).Value2 = dgdView.Item("ICDPORT", j).Value.ToString
                ws.Range("X" & CurRow).Value2 = dgdView.Item("ICDPORT", j).Value.ToString
                ws.Range("Y" & CurRow).Value2 = Pre_Col

                ws.Range("C" & CurRow).Value2 = tim(dgdView.Item("SHIPPERNAME", j).Value.ToString, "Shipper_1", "Shipper_Code", dsShipper)
                ws.Range("D" & CurRow).Value2 = dgdView.Item("SHIPPERNAME", j).Value.ToString
                ws.Range("G" & CurRow).Value2 = tim(dgdView.Item("ConsigneeNAME", j).Value, "Consignee_1", "Consignee_Code", dsConsignee)
                ws.Range("H" & CurRow).Value2 = dgdView.Item("ConsigneeNAME", j).Value


                ws.Range("AE" & CurRow).Value2 = Mid(dgdView.Item("BL_CY_CFS_ITEM", j).Value.ToString.Trim, 2, 3)
                QueryContainer(ds, BLID)
                Dim n As Integer = IIf(ds.Tables(0).Rows.Count - 1 > 19, 19, ds.Tables(0).Rows.Count - 1)

                For k As Integer = 0 To n
                    Dim temp As String
                    temp = ds.Tables(0).Rows(k).Item("Container_No").ToString
                    temp &= " / " & ds.Tables(0).Rows(k).Item("Container_Type").ToString
                    temp &= " / " & ds.Tables(0).Rows(k).Item("Seal").ToString
                    ws.Range("A" & Alpha(k + 4) & CurRow).Value2 = temp
                Next
                Dim tempDESC() As String
                tempDESC = Strings.Split(dgdView.Item("DESCRIPTIONOFGOODS", j).Value.ToString.Trim, Chr(13))
                Dim AlphaPos As Integer = 9 'vi tri cua F trong mang Alpha()

                For IntDesc As Integer = 0 To tempDESC.Length - 1
                    If tempDESC(IntDesc) <> "" Then
                        ws.Range("B" & Alpha(AlphaPos) & CurRow).Value2 = tempDESC(IntDesc)
                        AlphaPos += 1
                        If AlphaPos > 25 Then
                            Exit For
                        End If
                    End If
                Next
                QueryCountContainer(ds, BLID)
                For CountContainer As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(0).Item("Container_Type").ToString Like "20*" Then
                        If ds.Tables(0).Rows(0).Item("Container_Type").ToString Like "*R*" Then
                            ws.Range("DA" & CurRow).Value2 = Right(ds.Tables(0).Rows(0).Item("Container_Type").ToString, 2)
                        Else
                            ws.Range("DA" & CurRow).Value2 = "DC"
                        End If
                        ws.Range("CY" & CurRow).Value2 = ds.Tables(0).Rows(0).Item("Num").ToString
                    Else
                        If ds.Tables(0).Rows(0).Item("Container_Type").ToString Like "*R*" Then
                            ws.Range("DA" & CurRow).Value2 = Right(ds.Tables(0).Rows(0).Item("Container_Type").ToString, 2)
                        Else
                            ws.Range("DA" & CurRow).Value2 = "DC"
                        End If
                        ws.Range("CZ" & CurRow).Value2 = ds.Tables(0).Rows(0).Item("Num").ToString
                    End If
                Next
                QueryFreight(ds, BLID)
                For F As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If UCase(ds.Tables(0).Rows(F).Item("Prepaid_Collect").ToString) = "PREPAID" Then
                        ws.Range("DE" & CurRow).Value2 = ds.Tables(0).Rows(F).Item("Freight")
                    Else
                        ws.Range("DG" & CurRow).Value2 = ds.Tables(0).Rows(F).Item("Freight")
                    End If
                Next


                QueryPrice(ds, BLID)
                For P As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    If UCase(ds.Tables(0).Rows(P).Item("Prepaid_Collect").ToString) = "PREPAID" Then
                        ws.Range("DF" & CurRow).Value2 = ds.Tables(0).Rows(P).Item("Price")
                    Else
                        ws.Range("DH" & CurRow).Value2 = ds.Tables(0).Rows(P).Item("Price")
                    End If
                Next

                ws.Range("DN" & CurRow).Value2 = dgdView.Item("LOAD_DATE", j).Value.ToString
                'ws.Range("R" & CurRow).Value2 = dgdView.Item("VESSEL", j).Value.ToString
                'ws.Range("S" & CurRow).Value2 = dgdView.Item("VoyAge", j).Value.ToString
                'ws.Range("T" & CurRow).Value2 = dgdView.Item("ETA", j).Value.ToString
                'ws.Range("V" & CurRow).Value2 = dgdView.Item("POD", j).Value.ToString.Trim
                'ws.Range("W" & CurRow).Value2 = dgdView.Item("ICDPORT", j).Value.ToString
                'ws.Range("X" & CurRow).Value2 = dgdView.Item("ICDPORT", j).Value.ToString


                CurRow += 1
            Next

            'drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)
            'drawBorder(ws, 7, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            'nRow += 1




            MsgBox("Complete")
            app.Visible = True
            path = "c:\" & strUserId & " " & Now.Date & " H" & Now.Hour & "M" & Now.Minute & "S" & Now.Second
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            'app.Quit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally
            stForm.Cursor = Cursors.Default
            'app.Quit()
        End Try
    End Function
    Sub drawBorder(ByVal ws As Excel._Worksheet, ByVal key As Integer, ByVal Cell1 As String, Optional ByVal Cell2 As String = "", Optional ByVal style As Integer = 1)
        Try
            Select Case key
                Case 1 'Top
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.Borders(XlBordersIndex.xlEdgeTop).LineStyle = style
                    Else
                        ws.Range(Cell1, Cell2).Cells.Borders(XlBordersIndex.xlEdgeTop).LineStyle = style
                    End If
                Case 2 'Bottom
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.Borders(XlBordersIndex.xlEdgeBottom).LineStyle = style
                    Else
                        ws.Range(Cell1, Cell2).Cells.Borders(XlBordersIndex.xlEdgeBottom).LineStyle = style
                    End If
                Case 3 'Left
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.Borders(XlBordersIndex.xlEdgeLeft).LineStyle = style
                    Else
                        ws.Range(Cell1, Cell2).Cells.Borders(XlBordersIndex.xlEdgeLeft).LineStyle = style
                    End If
                Case 4 'Right
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.Borders(XlBordersIndex.xlEdgeRight).LineStyle = style
                    Else
                        ws.Range(Cell1, Cell2).Cells.Borders(XlBordersIndex.xlEdgeRight).LineStyle = style
                    End If
                Case 5 'Around
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.BorderAround(, XlBorderWeight.xlThin)
                    Else
                        ws.Range(Cell1, Cell2).Cells.BorderAround(, XlBorderWeight.xlThin)
                    End If
                Case 6 'Horizontal
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = style
                    Else
                        If Cell1 = Cell2 Then Return
                        ws.Range(Cell1, Cell2).Cells.Borders(XlBordersIndex.xlInsideHorizontal).LineStyle = style
                    End If
                Case 7 'Vertical
                    If Cell2 = "" Then
                        ws.Range(Cell1).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = style
                    Else
                        If Cell1 = Cell2 Then Return
                        ws.Range(Cell1, Cell2).Cells.Borders(XlBordersIndex.xlInsideVertical).LineStyle = style
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function SetCell(ByVal cell As String) As String
        Try
            Dim rCell As String = ""
            Dim tmp As String = cell
            Dim tmp2 As String = Strings.Right(tmp, 1)
            Dim tmp1 As String = tmp.Remove(tmp.Length - 1, 1)
            Dim ntmp As Integer = AscW(tmp2)
            ntmp += 1
            If ntmp > 90 Then
                tmp2 = "A"
                If tmp1 = "" Then
                    tmp1 = "A"
                Else
                    If AscW(tmp1) = 90 Then Return ""
                    tmp1 = Chr(AscW(tmp1) + 1)
                End If
            Else
                tmp2 = Chr(ntmp)
            End If
            rCell = tmp1 & tmp2
            Return rCell
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return Nothing
    End Function

    Dim time As System.Windows.Forms.Timer
    Dim cmd As System.Windows.Forms.Button
    Public prb As ProgressBar
    Dim pal As System.Windows.Forms.GroupBox
    Dim lbl As System.Windows.Forms.Label

    Dim max As Integer
    Dim n As Integer

    Sub cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If bEvent = False Then
            bEvent = True
        End If
    End Sub

    Public Function ExportExecel_lemon(ByVal dgdView As DataGridView, ByVal stForm As Form) As Boolean
        Dim app As Application
        Try
            Dim path As String = ""
            path = OpenDlg(stForm.Name)
            If path = "" Then
                Return False
            End If
            stForm.Cursor = Cursors.WaitCursor

            app = New Application()
            'app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If


            Dim i, j As Integer
            Dim nRow As Integer = 12
            Dim nCol As Integer = 0
            Dim cell As String = "A"
            Dim arrCol As String()

            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count

            '====================================
            'time = New System.Windows.Forms.Timer
            'time.Enabled = False
            'AddHandler time.Tick, AddressOf time_Tick
            ''stForm.Container.Add(time)

            pal = New System.Windows.Forms.GroupBox
            With pal
                pal.Width = 316
                pal.Height = 111
                pal.Left = stForm.Width / 2 - pal.Width / 2
                pal.Top = stForm.Height / 2 - pal.Height / 2
                .Text = "Please wait export"
                .Name = "pal"
            End With
            stForm.Controls.Add(pal)
            stForm.Controls.Item("pal").BringToFront()

            Dim prb As New ProgressBar
            With prb
                .Minimum = 0
                .Maximum = row
                .Width = 280
                .Height = 20
                .Left = pal.Width / 2 - .Width / 2
                .Top = 34
                .Name = "prbExcel"
            End With
            stForm.Controls.Add(prb)
            pal.Controls.Add(prb)

            cmd = New System.Windows.Forms.Button
            With cmd
                .Width = 75
                .Height = 23
                .Left = pal.Width / 2 - .Width / 2
                .Top = 80
                .Text = "Stop"
                .Name = "cmdStop"
            End With
            AddHandler cmd.Click, AddressOf cmd_Click
            stForm.Controls.Add(cmd)
            pal.Controls.Add(cmd)

            lbl = New System.Windows.Forms.Label
            With lbl
                .Text = "00%"
                .Left = pal.Width / 2
                .Top = prb.Top + prb.Height + 10
                .ForeColor = Color.Blue
            End With
            stForm.Controls.Add(lbl)
            pal.Controls.Add(lbl)

            max = row
            prb.Maximum = row + 1

            '====================================

            ReDim arrCol(col - 1)

            ws.Range(cell & 1).Value = stForm.Text
            Dim st As String = cell
            nCol = 0

            For j = 0 To col - 1
                If dgdView.Columns(j).Visible = True Then

                    arrCol(nCol) = st
                    ws.Range(arrCol(nCol) & nRow).Value = dgdView.Columns(j).HeaderText
                    nCol += 1

                
                st = SetCell(st)

                End If
            Next

            drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)
            drawBorder(ws, 7, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            nRow += 1

            'For i = 0 To row - 1
            i = 0
            bEvent = False
            'time.Enabled = True
            Dim cnt As Double = 100 / row
            Dim ncnt As Double = cnt
            While i <> row And bEvent = False
                prb.Value = i + 1
                lbl.Text = CInt(ncnt) & "%"
                nCol = 0
                System.Windows.Forms.Application.DoEvents()
                For j = 0 To col - 1
                    If dgdView.Columns(j).Visible = True Then
                        ws.Range(arrCol(nCol) & nRow).Value = dgdView.Item(j, i).Value
                        nCol += 1
                    End If
                Next
                'ws.Range("A" & nRow).Value = i + 1
                'ws.Range("A" & nRow).BorderAround(, XlBorderWeight.xlThin)
                'ws.Range("A" & nRow).Cells.HorizontalAlignment = 3
                nRow += 1
                ncnt += cnt
                i = i + 1
            End While
            'Next

            For i = 0 To nCol - 1
                ws.Range(arrCol(i) & 3, arrCol(i) & nRow - 1).Cells.Columns.AutoFit()
            Next

            'For i = 4 To nRow - 1
            '    ws.Range(arrCol(0) & i, arrCol(nCol) & i).Cells.Rows.AutoFit()
            'Next

            drawBorder(ws, 13, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)
            If row > 1 Then
                drawBorder(ws, 13, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If
            If col > 1 Then
                drawBorder(ws, 14, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If

            Dim d As Date = CDate(Getdate())
            ' Dim path = stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
            path = ProccessString(path)
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            stForm.Cursor = Cursors.Default

            MsgBox("Complete, path : " & path)
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)

            app.Quit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally

        End Try
    End Function
    Public Function ExportExecel(ByVal dgdView As DataGridView, ByVal stForm As UserControl) As Boolean
        Dim app As Application
        Try
            Dim path As String = ""
            path = OpenDlg(stForm.Name)
            If path = "" Then
                Return False
            End If
            stForm.Cursor = Cursors.WaitCursor

            app = New Application()
            'app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If


            Dim i, j As Integer
            Dim nRow As Integer = 3
            Dim nCol As Integer = 0
            Dim cell As String = "A"
            Dim arrCol As String()

            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count

            '====================================
            'time = New System.Windows.Forms.Timer
            'time.Enabled = False
            'AddHandler time.Tick, AddressOf time_Tick
            ''stForm.Container.Add(time)

            pal = New System.Windows.Forms.GroupBox
            With pal
                pal.Width = 316
                pal.Height = 111
                pal.Left = stForm.Width / 2 - pal.Width / 2
                pal.Top = stForm.Height / 2 - pal.Height / 2
                .Text = "Please wait export"
                .Name = "pal"
            End With
            stForm.Controls.Add(pal)
            stForm.Controls.Item("pal").BringToFront()

            Dim prb As New ProgressBar
            With prb
                .Minimum = 0
                .Maximum = row
                .Width = 280
                .Height = 20
                .Left = pal.Width / 2 - .Width / 2
                .Top = 34
                .Name = "prbExcel"
            End With
            stForm.Controls.Add(prb)
            pal.Controls.Add(prb)

            cmd = New System.Windows.Forms.Button
            With cmd
                .Width = 75
                .Height = 23
                .Left = pal.Width / 2 - .Width / 2
                .Top = 80
                .Text = "Stop"
                .Name = "cmdStop"
            End With
            AddHandler cmd.Click, AddressOf cmd_Click
            stForm.Controls.Add(cmd)
            pal.Controls.Add(cmd)

            lbl = New System.Windows.Forms.Label
            With lbl
                .Text = "00%"
                .Left = pal.Width / 2
                .Top = prb.Top + prb.Height + 10
                .ForeColor = Color.Blue
            End With
            stForm.Controls.Add(lbl)
            pal.Controls.Add(lbl)

            max = row
            prb.Maximum = row + 1

            '====================================

            ReDim arrCol(col - 1)

            ws.Range(cell & 1).Value = stForm.Text
            Dim st As String = cell
            nCol = 0

            For j = 0 To col - 1
                If dgdView.Columns(j).Visible = True Then
                    st = SetCell(st)
                    arrCol(nCol) = st
                    ws.Range(arrCol(nCol) & nRow).Value = dgdView.Columns(j).HeaderText
                    nCol += 1
                End If
            Next

            drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)
            drawBorder(ws, 7, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            nRow += 1

            'For i = 0 To row - 1
            i = 0
            bEvent = False
            'time.Enabled = True
            Dim cnt As Double = 100 / row
            Dim ncnt As Double = cnt
            While i <> row And bEvent = False
                prb.Value = i + 1
                lbl.Text = CInt(ncnt) & "%"
                nCol = 0
                System.Windows.Forms.Application.DoEvents()
                For j = 0 To col - 1
                    If dgdView.Columns(j).Visible = True Then
                        ws.Range(arrCol(nCol) & nRow).Value = dgdView.Item(j, i).Value
                        nCol += 1
                    End If
                Next
                ws.Range("A" & nRow).Value = i + 1
                ws.Range("A" & nRow).BorderAround(, XlBorderWeight.xlThin)
                ws.Range("A" & nRow).Cells.HorizontalAlignment = 3
                nRow += 1
                ncnt += cnt
                i = i + 1
            End While
            'Next

            For i = 0 To nCol - 1
                ws.Range(arrCol(i) & 3, arrCol(i) & nRow - 1).Cells.Columns.AutoFit()
            Next

            'For i = 4 To nRow - 1
            '    ws.Range(arrCol(0) & i, arrCol(nCol) & i).Cells.Rows.AutoFit()
            'Next

            drawBorder(ws, 5, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)
            If row > 1 Then
                drawBorder(ws, 6, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If
            If col > 1 Then
                drawBorder(ws, 7, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If

            Dim d As Date = CDate(Getdate())
            ' Dim path = stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
            path = ProccessString(path)
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            stForm.Cursor = Cursors.Default

            MsgBox("Complete, path : " & path)
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)

            app.Quit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally

        End Try
    End Function
    
    Public Function ExportExecel(ByVal dgdView As DataGridView, ByVal stForm As Form) As Boolean

        Try

            Dim d As Date = CDate(Getdate())

            Dim path As String = ""
            path = OpenDlg(stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls")

            '"c:\" & stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"

            If path = "" Then
                Return False
            End If

            stForm.Cursor = Cursors.WaitCursor
            Dim app As Application
            app = New Application()
            'app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If

            Dim i, j As Integer
            Dim nRow As Integer = 6
            Dim nCol As Integer = 0
            Dim cell As String = "B"
            Dim arrCol As String()

            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count

            ReDim arrCol(col - 1)


            Dim st As String = cell
            nCol = 0

            '====================================

            pal = New System.Windows.Forms.GroupBox
            With pal
                pal.Width = 316
                pal.Height = 111
                pal.Left = stForm.Width / 2 - pal.Width / 2
                pal.Top = stForm.Height / 2 - pal.Height / 2
                .Text = "Please wait ..... "
                .Name = "pal"
            End With
            stForm.Controls.Add(pal)
            stForm.Controls.Item("pal").BringToFront()

            Dim prb As New ProgressBar
            With prb
                .Minimum = 0
                .Maximum = row
                .Width = 280
                .Height = 20
                .Left = pal.Width / 2 - .Width / 2
                .Top = 34
                .Name = "prbExcel"
            End With
            stForm.Controls.Add(prb)
            pal.Controls.Add(prb)

            cmd = New System.Windows.Forms.Button
            With cmd
                .Width = 75
                .Height = 23
                .Left = pal.Width / 2 - .Width / 2
                .Top = 80
                .Text = "Stop"
                .Name = "cmdStop"
            End With
            AddHandler cmd.Click, AddressOf cmd_Click
            stForm.Controls.Add(cmd)
            pal.Controls.Add(cmd)

            lbl = New System.Windows.Forms.Label
            With lbl
                .Text = "00%"
                .Left = pal.Width / 2
                .Top = prb.Top + prb.Height + 10
                .ForeColor = Color.Blue
            End With
            stForm.Controls.Add(lbl)
            pal.Controls.Add(lbl)

            max = row
            prb.Maximum = row + 1

            '====================================

            For j = 0 To col - 1
                If dgdView.Columns(j).Visible = True Then
                    st = SetCell(st)
                    arrCol(nCol) = st
                    ws.Range(arrCol(nCol) & nRow).Value = dgdView.Columns(j).HeaderText.ToUpper
                    ' ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = Color.Blue
                    ' ws.Range(arrCol(nCol) & nRow).Cells.Font.Background = Color.LightPink
                    nCol += 1
                End If
            Next

            drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow, 2)
            ' drawBorder(ws, 6, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            nRow += 1

            'For i = 0 To row - 1
            i = 0
            bEvent = False

            Dim cnt As Double = 100 / row
            Dim ncnt As Double = cnt

            While i <> row And bEvent = False
                prb.Value = i + 1
                lbl.Text = CInt(ncnt) & "%"
                nCol = 0
                System.Windows.Forms.Application.DoEvents()
                For j = 0 To col - 1
                    If dgdView.Columns(j).Visible = True Then
                        ws.Range(arrCol(nCol) & nRow).Value = dgdView.Item(j, i).Value
                        Dim bool As Boolean
                        bool = IIf(dgdView.Rows(i).DefaultCellStyle.ForeColor = Color.Blue, True, False)
                        If bool = True Then
                            ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = System.Drawing.Color.Blue.ToArgb
                        End If
                        Dim _color As System.Drawing.Color = dgdView.Rows(i).DefaultCellStyle.ForeColor
                        ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = CDbl(_color.GetHue)
                        dgdView.Item(j, i).Style.ForeColor.ToArgb()
                        nCol += 1
                    End If
                Next
                'ws.Range("A" & nRow).Value = i + 1
                'ws.Range("A" & nRow).BorderAround(, XlBorderWeight.xlMedium)
                'ws.Range("A" & nRow).Cells.HorizontalAlignment = 3

                nRow += 1
                i = i + 1
                ncnt += cnt

            End While
            'Next
            ' lay ten cty trong option
            Dim congty As String

            congty = getOptionValue("companyname", "all", "all", "name", "C")
            ws.Range("c3").Value = congty
            ' ws.Range("c4").Value = stForm.Text
            ws.Range("c3").Cells.Font.Color = System.Drawing.Color.Red.ToArgb
            ' ws.Range("c4").Cells.Font.Color = System.Drawing.Color.Brown.ToArgb
            ws.Range("c3").Cells.Font.Size = 18
            ' ws.Range("c4").Cells.Font.Size = 20
            '  ws.Range(cell & nCol / 2).Value = stForm.Text
            For i = 0 To nCol - 1
                ws.Range(arrCol(i) & 6, arrCol(i) & nRow - 1).Cells.Columns.AutoFit()
                ' ws.Range(arrCol(i)6 6, arrCol(i) & nRow - 1).Cells.Font.Bold = True
                ws.Range(arrCol(i) & 6, arrCol(i) & nRow - 1).Cells.Font.Color = System.Drawing.Color.Blue.ToArgb
                ws.Range(arrCol(i) & 7, arrCol(i) & nRow - 1).Cells.Font.Color = System.Drawing.Color.Yellow.ToArgb
            Next
            For i = 0 To nCol - 1
                '  ws.Range(arrCol(i) & 6, arrCol(0) & nRow).Cells.Font.Bold = True
                '  ws.Range(arrCol(i) & 7, arrCol(0) & nRow).Cells.Font. = True
                'ws.Range(arrCol(i) & 6, arrCol(0) & nRow).Cells.Font.Color = System.Drawing.Color.Red.ToArgb
            Next
            ws.Range(arrCol(nCol / 2) + "4").Value = stForm.Text
            ws.Range(arrCol(nCol / 2) + "4").Cells.Font.Color = System.Drawing.Color.Brown.ToArgb

            ws.Range(arrCol(nCol / 2) + "4").Cells.Font.Size = 20


            For i = 6 To 6
                ws.Range(arrCol(0) & i, arrCol(nCol - 1) & i).Font.Bold = True
                ws.Range(arrCol(0) & i, arrCol(nCol - 1) & i).Font.Color = Color.Purple.ToArgb
            Next
            For i = 7 To nRow - 1
                ws.Range(arrCol(0) & i, arrCol(nCol - 1) & i).Font.Color = Color.Blue.ToArgb
            Next

            'For i = 6 To nRow - 1
            '    ' ws.Range(arrCol(0) & i, arrCol(nCol - 1) & i).Font.Color = Color.Blue.ToArgb
            '    drawBorder(ws, 5, arrCol(0) & 6, arrCol(nCol - 1) & nRow - 1, 1)
            'Next
            drawBorder(ws, 5, arrCol(0) & 6, arrCol(nCol - 1) & 6, 1)
            drawBorder(ws, 5, arrCol(0) & 6, arrCol(nCol - 1) & nRow - 1, 3)

            drawBorder(ws, 6, arrCol(0) & 6, arrCol(nCol - 1) & nRow - 1, 3)

            '------------------------------
            Dim rRng As Range
            For i = 0 To nCol - 1
                rRng = ws.Range(arrCol(i) & 6 & ":" & arrCol(i) & nRow - 1)

                'Clear existing
                ' rRng.Borders.LineStyle = Nothing

                'Apply new borders
                rRng.BorderAround(1, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, Color.Brown.ToArgb)
            Next
            rRng = ws.Range(arrCol(0) & 6 & ":" & arrCol(nCol - 1) & 6)

            'Clear existing
            'rRng.Borders.LineStyle = Nothing

            'Apply new borders
            rRng.BorderAround(1, XlBorderWeight.xlMedium, XlColorIndex.xlColorIndexAutomatic, Color.Brown.ToArgb)
            'rRng.Borders(xlInsideHorizontal).LineStyle = xlContinuous
            'rRng.Borders(xlInsideVertical).LineStyle = xlContinuous
            '-------------------------------------------------
            If row > 1 Then
                'drawBorder(ws, 1, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
                'drawBorder(ws, 2, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)

            End If
            If col > 1 Then
                'drawBorder(ws, 3, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
                'drawBorder(ws, 4, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If

            path = ProccessString(path)
            workbook.Application.DisplayAlerts = False
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            workbook.Application.DisplayAlerts = True
            stForm.Cursor = Cursors.Default

            MsgBox("Complete path " & path)
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)

            app.Visible = True

            app.Quit()

            Return True
        Catch ex As Exception
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)
            MsgBox(ex.Message)
            stForm.Cursor = Cursors.Default
            Return False
        Finally

        End Try
    End Function
    Public Function ExportSOA(ByVal dgdView As DataGridView, ByVal stForm As Form) As Boolean
        Dim app As Application
        Try
            Dim d As Date = CDate(Getdate())
            Dim path As String = ""
            path = OpenDlg(stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls")

            '"c:\" & stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"

            If path = "" Then
                Return False
            End If

            stForm.Cursor = Cursors.WaitCursor

            app = New Application()
            'app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If

            Dim i, j As Integer
            Dim nRow As Integer = 10
            Dim nCol As Integer = 0
            Dim cell As String = "A"
            Dim arrCol As String()

            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count

            ReDim arrCol(col - 1)

            ws.Range(cell & 1).Value = stForm.Text
            Dim st As String = cell
            nCol = 0

            '====================================

            pal = New System.Windows.Forms.GroupBox
            With pal
                pal.Width = 316
                pal.Height = 111
                pal.Left = stForm.Width / 2 - pal.Width / 2
                pal.Top = stForm.Height / 2 - pal.Height / 2
                .Text = "Please wait ..... "
                .Name = "pal"
            End With
            stForm.Controls.Add(pal)
            stForm.Controls.Item("pal").BringToFront()

            Dim prb As New ProgressBar
            With prb
                .Minimum = 0
                .Maximum = row
                .Width = 280
                .Height = 20
                .Left = pal.Width / 2 - .Width / 2
                .Top = 34
                .Name = "prbExcel"
            End With
            stForm.Controls.Add(prb)
            pal.Controls.Add(prb)

            cmd = New System.Windows.Forms.Button
            With cmd
                .Width = 75
                .Height = 23
                .Left = pal.Width / 2 - .Width / 2
                .Top = 80
                .Text = "Stop"
                .Name = "cmdStop"
            End With
            AddHandler cmd.Click, AddressOf cmd_Click
            stForm.Controls.Add(cmd)
            pal.Controls.Add(cmd)

            lbl = New System.Windows.Forms.Label
            With lbl
                .Text = "00%"
                .Left = pal.Width / 2
                .Top = prb.Top + prb.Height + 10
                .ForeColor = Color.Blue
            End With
            stForm.Controls.Add(lbl)
            pal.Controls.Add(lbl)

            max = row
            prb.Maximum = row + 1

            '====================================

            For j = 0 To col - 1
                If dgdView.Columns(j).Visible = True Then
                    st = SetCell(st)
                    arrCol(nCol) = st
                    ws.Range(arrCol(nCol) & nRow).Value = dgdView.Columns(j).HeaderText
                    nCol += 1
                End If
            Next

            drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)
            ' drawBorder(ws, 6, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            nRow += 1

            'For i = 0 To row - 1
            i = 0
            bEvent = False

            Dim cnt As Double = 100 / row
            Dim ncnt As Double = cnt

            While i <> row And bEvent = False
                prb.Value = i + 1
                lbl.Text = CInt(ncnt) & "%"
                nCol = 0
                System.Windows.Forms.Application.DoEvents()
                For j = 0 To col - 1
                    If dgdView.Columns(j).Visible = True Then
                        ws.Range(arrCol(nCol) & nRow).Value = dgdView.Item(j, i).Value
                        'Dim bool As Boolean
                        'bool = IIf(dgdView.Rows(i).DefaultCellStyle.ForeColor = Color.Red, True, False)
                        'If bool = True Then
                        '    ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = 255 'System.Drawing.Color.Red.ToArgb
                        'End If
                        'Dim _color As System.Drawing.Color = dgdView.Rows(i).DefaultCellStyle.ForeColor
                        'ws.Range(arrCol(nCol) & nRow).Cells.Font.Color = "Red" ' CDbl(_color.GetHue)
                        'dgdView.Item(j, i).Style.ForeColor.ToArgb
                        nCol += 1
                    End If
                Next
                ws.Range("A" & nRow).Value = i + 1
                ws.Range("A" & nRow).BorderAround(, XlBorderWeight.xlMedium)
                ws.Range("A" & nRow).Cells.HorizontalAlignment = 3

                nRow += 1
                i = i + 1
                ncnt += cnt

            End While
            'Next

            For i = 0 To nCol - 1
                ws.Range(arrCol(i) & 3, arrCol(i) & nRow - 1).Cells.Columns.AutoFit()
            Next

            'For i = 4 To nRow - 1
            '    ws.Range(arrCol(0) & i, arrCol(nCol) & i).Cells.Rows.AutoFit()
            'Next

            drawBorder(ws, 5, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)

            drawBorder(ws, 6, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)
            If row > 1 Then
                'drawBorder(ws, 1, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
                'drawBorder(ws, 2, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)

            End If
            If col > 1 Then
                'drawBorder(ws, 3, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
                'drawBorder(ws, 4, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If

            path = ProccessString(path)
            workbook.Application.DisplayAlerts = False
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            workbook.Application.DisplayAlerts = True
            stForm.Cursor = Cursors.Default

            MsgBox("Complete path " & path)
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)

            app.Visible = True

            app.Quit()

            Return True
        Catch ex As Exception
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)
            MsgBox(ex.Message)
            stForm.Cursor = Cursors.Default
            Return False
        Finally

        End Try
    End Function
    Public Function ExportExecelschedule(ByVal dgdView As DataGridView, ByVal stForm As Form, ByVal service As String, ByVal portCode As String, ByVal contact As String) As Boolean
        Dim app As Application
        Try
            Dim path As String = ""
            path = OpenDlg(stForm.Text)
            If path = "" Then
                Return False
            End If
            stForm.Cursor = Cursors.WaitCursor

            app = New Application()
            'app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            workbook = workbooks.Add(XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return False
            End If


            Dim i, j As Integer
            Dim nRow As Integer = 7
            Dim nCol As Integer = 0
            Dim cell As String = "A"
            Dim arrCol As String()

            Dim col As Integer = dgdView.ColumnCount  'dst.Tables(0).Columns.Count
            Dim row As Integer = dgdView.RowCount  'dst.Tables(0).Rows.Count
            ws.Range("A6").Value = service
            '====================================
            'time = New System.Windows.Forms.Timer
            'time.Enabled = False
            'AddHandler time.Tick, AddressOf time_Tick
            ''stForm.Container.Add(time)

            pal = New System.Windows.Forms.GroupBox
            With pal
                pal.Width = 316
                pal.Height = 111
                pal.Left = stForm.Width / 2 - pal.Width / 2
                pal.Top = stForm.Height / 2 - pal.Height / 2
                .Text = "Please wait export"
                .Name = "pal"
            End With
            stForm.Controls.Add(pal)
            stForm.Controls.Item("pal").BringToFront()

            Dim prb As New ProgressBar
            With prb
                .Minimum = 0
                .Maximum = row
                .Width = 280
                .Height = 20
                .Left = pal.Width / 2 - .Width / 2
                .Top = 34
                .Name = "prbExcel"
            End With
            stForm.Controls.Add(prb)
            pal.Controls.Add(prb)

            cmd = New System.Windows.Forms.Button
            With cmd
                .Width = 75
                .Height = 23
                .Left = pal.Width / 2 - .Width / 2
                .Top = 80
                .Text = "Stop"
                .Name = "cmdStop"
            End With
            AddHandler cmd.Click, AddressOf cmd_Click
            stForm.Controls.Add(cmd)
            pal.Controls.Add(cmd)

            lbl = New System.Windows.Forms.Label
            With lbl
                .Text = "00%"
                .Left = pal.Width / 2
                .Top = prb.Top + prb.Height + 10
                .ForeColor = Color.Blue
            End With
            stForm.Controls.Add(lbl)
            pal.Controls.Add(lbl)

            max = row
            prb.Maximum = row + 1

            '====================================

            ReDim arrCol(col - 1)

            ws.Range(cell & 1).Value = stForm.Text
            Dim st As String = cell
            nCol = 0

            For j = 0 To col - 1
                If dgdView.Columns(j).Visible = True Then
                    st = SetCell(st)
                    arrCol(nCol) = st
                    ws.Range(arrCol(nCol) & nRow).Value = dgdView.Columns(j).HeaderText
                    nCol += 1
                End If
            Next

            drawBorder(ws, 5, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)
            drawBorder(ws, 7, arrCol(0) & nRow, arrCol(nCol - 1) & nRow)

            nRow += 1

            'For i = 0 To row - 1
            i = 0
            bEvent = False
            'time.Enabled = True
            Dim cnt As Double = 100 / row
            Dim ncnt As Double = cnt
            While i <> row And bEvent = False
                prb.Value = i + 1
                lbl.Text = CInt(ncnt) & "%"
                nCol = 0
                System.Windows.Forms.Application.DoEvents()
                For j = 0 To col - 1
                    If dgdView.Columns(j).Visible = True Then
                        If Not IsNothing(dgdView.Item(j, i).Value) Then
                            'If j = 12 Then
                            '    DisplayMessage(True, "")
                            'End If
                            ws.Range(arrCol(nCol) & nRow).Value = dgdView.Item(j, i).Value.ToString
                        End If
                        nCol += 1
                    End If
                Next
                ws.Range("A" & nRow).Value = i + 1
                ws.Range("A" & nRow).BorderAround(, XlBorderWeight.xlThin)
                ws.Range("A" & nRow).Cells.HorizontalAlignment = 3
                nRow += 1
                ncnt += cnt
                i = i + 1
            End While
            'Next
            ws.Range("A" & i + 9).Value = "The above shedule is subject to changes with or without prior notice."

            ws.Range("A" & i + 10).Value = "PORT CODE : "
            ws.Range("B" & i + 10).Value = portCode
            ws.Range("A" & i + 12).Value = contact

            For i = 0 To nCol - 1
                ws.Range(arrCol(i) & 3, arrCol(i) & nRow - 1).Cells.Columns.AutoFit()
            Next

            'For i = 4 To nRow - 1
            '    ws.Range(arrCol(0) & i, arrCol(nCol) & i).Cells.Rows.AutoFit()
            'Next

            drawBorder(ws, 8, arrCol(0) & 3, arrCol(nCol - 1) & nRow - 1)
            If row > 1 Then
                drawBorder(ws, 9, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If
            If col > 1 Then
                drawBorder(ws, 10, arrCol(0) & 4, arrCol(nCol - 1) & nRow - 1, 3)
            End If

            Dim d As Date = CDate(Getdate())
            ' Dim path = stForm.Text & " - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
            path = ProccessString(path)
            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            stForm.Cursor = Cursors.Default


            MsgBox("Complete, path : " & path)
            stForm.Controls.Remove(cmd)
            stForm.Controls.Remove(prb)
            stForm.Controls.Remove(pal)

            app.Quit()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        Finally

        End Try
    End Function
End Module
