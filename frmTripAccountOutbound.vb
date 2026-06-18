Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmTripAccountOutbound

    Dim path As String
    Dim tempvessel() As String
    Private connstring As String
    Dim dsdata As New DataSet
    Dim dsdataOceanFreight As New DataSet
    Dim dsFee As New DataSet
    Dim dsBillPrice As New DataSet

    'Dim collectColor As Integer = 7
    'Dim PrepaidColor As Integer = 5
    'Sub QueryCROSSTab()
    '    Dim sql As String
    '    sql = "TRANSFORM Freight_charge_ib.unitprice  "
    '    sql = sql + " SELECT  BillOfLadingIb.BLIB_ID as F0,POR AS F1,POL AS F2,POD AS F3,DEST AS F4,BLIB_NO AS F5 "
    '    sql = sql + " FROM  BillOfLadingIb inner join Freight_charge_ib on BillOfLadingIb.BLIB_ID=Freight_charge_ib.BLIB_Id "
    '    sql = sql + " Where  Vessel='" & tempvessel(0) & "' and VoyAge='" & tempvessel(1) & "' And BillOfLadingIb.Continued=1 And month(ETA)=" & Me.cboThang.Text & " And year(ETA)=" & Me.cboNam.Text & " "
    '    sql = sql + " PIVOT  Freight_charge_ib.items; "
    '    Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '    Conn.Open()
    '    Dim cmdSelect As New SqlClient.SqlCommand(sql, Conn)
    '    Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '    Dim ds As New DataSet
    '    Adapter.Fill(ds)
    '    Me.DataGridView1.DataSource = ds.Tables(0)

    'End Sub

    Function ReplaceAlpha(ByVal str As String) As String
        Try

            str = str.Replace(".", ",")
            For i As Integer = 0 To str.Length - 1
                If Not IsNumeric(str(i)) And str(i) <> "," Then
                    str = str.Remove(i, 1)
                End If
            Next

            Return str
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub SetExcelValue()
        Dim app As Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\TripAccountOutbound.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If

            Dim n As Integer = dsdata.Tables(0).Rows.Count
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double

            Dim BillNo As String = ""
            Dim Arrpos(100) As FeePos 'tối đa là 100 fee
            Dim CountFee As Integer = 0
            Dim CurRow As Integer = 11
            '-them tieu de asc va tang coutfee 1
            Arrpos(CountFee).Items = "ASC"
            Arrpos(CountFee).Pos = Alpha(Asc("I") + CountFee - 65) 'phí bắt đầu chạy từ cột H
            ws.Range(Arrpos(CountFee).Pos & 7).Value2 = Arrpos(CountFee).Items
            ws.Range(Arrpos(CountFee).Pos & 8).Value2 = "USD"
            ws.Range(Arrpos(CountFee).Pos & 9).Value2 = "FL" & CountFee + 1
            'ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 = "ASC"
            CountFee += 1
            '---
            For i As Integer = 0 To n - 1 'duyệt hết tất cả cácbill
                'If i = 8 Then
                '    MsgBox(" ")
                'End If

                BillNo = dsdata.Tables(0).Rows(i).Item("F5").ToString.Trim
                If BillNo Like "*777" Then
                    DisplayMessage(True, "")
                End If
                ''thêm các phụ phí của Container
                Dim Collect As Integer = QueryPrice(dsdata.Tables(0).Rows(i).Item("F0").ToString)

                'ws.Range("G" & 11 + i).Value2 = Me.txtCommission.Text

                'che ngày 13-12-2007 vì chó ra tất cả cá phí không giới hạn 
                'If dsFee.Tables(0).Rows.Count > 0 Then
                '    For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsfee.table(0)
                '        If dsFee.Tables(0).Rows(k).Item("BL_ID").ToString = dsdata.Tables(0).Rows(i).Item("F0").ToString Then
                '            For j As Integer = 8 To 26
                '                If dsFee.Tables(0).Rows(k).Item("F" & j).ToString.Trim.Length > 0 Then
                '                    ws.Range(Alpha(j) & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("F" & j).ToString
                '                End If
                '            Next
                '        End If
                '    Next
                'End If

                '''''''''''''''''''' đoạn sửa ngày 13-12-2007
                
                For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsfee.table(0)
                    'chen cot asc vao truoc tang countfee lan 1

                    '---------------
                    Dim Insert As Boolean = True
                    'CountFee = 0
                    For TempPos As Integer = 0 To CountFee - 1
                        If dsFee.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper() = Arrpos(TempPos).Items Then
                            If ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 Is Nothing Then
                                ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                            Else
                                ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 += dsFee.Tables(0).Rows(k).Item("FEE").ToString
                            End If
                            'ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                            Insert = False
                            Exit For
                        End If
                    Next
                    If Insert Then
                        Arrpos(CountFee).Items = dsFee.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper()
                        Arrpos(CountFee).Pos = Alpha(Asc("I") + CountFee - 65) 'phí bắt đầu chạy từ cột H
                        ws.Range(Arrpos(CountFee).Pos & 7).Value2 = Arrpos(CountFee).Items
                        ws.Range(Arrpos(CountFee).Pos & 8).Value2 = "USD"
                        ws.Range(Arrpos(CountFee).Pos & 9).Value2 = "FL" & CountFee + 1
                        If ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 Is Nothing Then
                            ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                        Else
                            ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 += dsFee.Tables(0).Rows(k).Item("FEE").ToString
                        End If

                        CountFee += 1
                    End If
                Next

                '''''''''''''''''''''''''''''''''''kết thúc đoạn sửa ngày 13-12-2007




                ''thêm các phụ phí của bill
                QueryBillPrice(dsdata.Tables(0).Rows(i).Item("F0").ToString)

                'che ngay 13-12-2007 hiện tất cả các phụ phí chứ không gioi hạn
                'If dsBillPrice.Tables(0).Rows.Count > 0 Then
                'For k As Integer = 0 To dsBillPrice.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsbillprice.table(0)
                '    If dsBillPrice.Tables(0).Rows(k).Item("BL_ID").ToString = dsdata.Tables(0).Rows(i).Item("F0").ToString Then
                '        For j As Integer = 8 To 26
                '            If dsBillPrice.Tables(0).Rows(k).Item("F" & j).ToString.Trim.Length > 0 Then
                '                ws.Range(Alpha(j) & CurRow).Value2 = dsBillPrice.Tables(0).Rows(k).Item("F" & j).ToString
                '            End If
                '        Next
                '    End If
                'Next
                'End If

                For k As Integer = 0 To dsBillPrice.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsbillprice.table(0)
                    Dim Insert As Boolean = True
                    'CountFee = 0
                    For TempPos As Integer = 0 To CountFee - 1
                        If dsBillPrice.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper() = Arrpos(TempPos).Items Then
                            If ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 Is Nothing Then
                                ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 = dsBillPrice.Tables(0).Rows(k).Item("FEE").ToString
                            Else
                                ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 += dsBillPrice.Tables(0).Rows(k).Item("FEE").ToString
                            End If

                            Insert = False
                            Exit For
                        End If
                    Next
                    If Insert Then
                        Arrpos(CountFee).Items = dsBillPrice.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper()
                        Arrpos(CountFee).Pos = Alpha(Asc("I") + CountFee - 65) 'phí bắt đầu chạy từ cột H
                        ws.Range(Arrpos(CountFee).Pos & 7).Value2 = Arrpos(CountFee).Items
                        ws.Range(Arrpos(CountFee).Pos & 8).Value2 = "USD"
                        ws.Range(Arrpos(CountFee).Pos & 9).Value2 = "FL" & CountFee + 1
                        If ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 Is Nothing Then
                            ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 = dsBillPrice.Tables(0).Rows(k).Item("FEE").ToString
                        Else
                            ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 += dsBillPrice.Tables(0).Rows(k).Item("FEE").ToString
                        End If
                        CountFee += 1
                    End If
                Next

                For k As Integer = 0 To 4
                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        'arrS(dem, k) = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                        ws.Range(Alpha(k) & CurRow).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                    End If
                Next
                'If dsdata.Tables(0).Rows(i).Item("F5").ToString = "8SGNHAM4AN824" Then
                '    DisplayMessage(True, "")

                'End If

                Dim Temp As String = dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim 'Strings.Replace(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim, "%", "").Trim
                For P As Integer = 0 To dsdataOceanFreight.Tables(0).Rows.Count - 1
                    If dsdata.Tables(0).Rows(i).Item("F0").ToString = dsdataOceanFreight.Tables(0).Rows(P).Item("F0").ToString Then
                        If UCase(dsdataOceanFreight.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString) = "PREPAID" And dsdataOceanFreight.Tables(0).Rows(P).Item("POP").ToString Like "VN*" Then
                            ws.Range("F" & CurRow).Value += dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                            If dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight").ToString <> "" And Temp <> "" And UCase(Temp) <> "A" Then
                                ws.Range("H" & CurRow).Value2 = (CDbl(dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")) * CDbl(Temp.Trim) / 100).ToString
                            Else
                                If UCase(Temp) = "A" Then
                                    ws.Range("H" & CurRow).Value2 = 15 * CDbl(dsdataOceanFreight.Tables(0).Rows(P).Item("quantity"))
                                End If
                            End If

                        Else
                            ' khong show ra bao cao
                            ws.Range("G" & CurRow).Value += dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                            If dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight").ToString <> "" And Temp <> "" And UCase(Temp) <> "A" Then
                                ws.Range("H" & CurRow).Value2 = (CDbl(dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")) * CDbl(Temp) / 100).ToString
                            Else
                                If UCase(Temp) = "A" Then
                                    ws.Range("H" & CurRow).Value2 = 15 * CDbl(dsdataOceanFreight.Tables(0).Rows(P).Item("quantity").ToString)
                                End If
                            End If
                        End If
                    End If
                Next


                CurRow += 1
            Next

            ws.Range("B4").Value2 = Me.cboThang.Text & " / " & Me.cboNam.Text
            'Me.DataGridView1.DataSource = dsdata.Tables(0)
            ws.Range("B6").Value2 = tempvessel(0)
            ws.Range("E6").Value2 = tempvessel(1)

            ws.Range("G6").Value2 = CDate(tempvessel(2)).Date

            path = "c:\TripAccountOutbound" & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

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
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}

            app = New Application()
            app.Visible = True

            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook

            path = StartupPath & "\TripAccountOutbound.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If

            Dim n As Integer = dsdata.Tables(0).Rows.Count
            'Dim range As Object 'Range 

            'Dim arr(n, 20) As Double
            'Dim arrS(n, 7) As String
            'Dim OceanFreightarr(n) As Double

            Dim BillNo As String = ""
            Dim Arrpos(100) As FeePos 'tối đa là 100 fee
            Dim CountFee As Integer = 0
            Dim CurRow As Integer = 11
            For i As Integer = 0 To n - 1 'duyệt hết tất cả cácbill
                'If i = 8 Then
                '    MsgBox(" ")
                'End If

                BillNo = dsdata.Tables(0).Rows(i).Item("F5").ToString.Trim
                ''thêm các phụ phí của Container
                Dim Collect As Integer = QueryPriceHistory(dsdata.Tables(0).Rows(i).Item("F0").ToString)

                'ws.Range("G" & 11 + i).Value2 = Me.txtCommission.Text

                'che ngày 13-12-2007 vì chó ra tất cả cá phí không giới hạn 
                'If dsFee.Tables(0).Rows.Count > 0 Then
                '    For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsfee.table(0)
                '        If dsFee.Tables(0).Rows(k).Item("BL_ID").ToString = dsdata.Tables(0).Rows(i).Item("F0").ToString Then
                '            For j As Integer = 8 To 26
                '                If dsFee.Tables(0).Rows(k).Item("F" & j).ToString.Trim.Length > 0 Then
                '                    ws.Range(Alpha(j) & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("F" & j).ToString
                '                End If
                '            Next
                '        End If
                '    Next
                'End If

                '''''''''''''''''''' đoạn sửa ngày 13-12-2007

                For k As Integer = 0 To dsFee.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsfee.table(0)

                    Dim Insert As Boolean = True
                    'CountFee = 0
                    For TempPos As Integer = 0 To CountFee - 1
                        If dsFee.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper() = Arrpos(TempPos).Items Then
                            ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                            Insert = False
                            Exit For
                        End If
                    Next
                    If Insert Then
                        Arrpos(CountFee).Items = dsFee.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper()
                        Arrpos(CountFee).Pos = Alpha(Asc("I") + CountFee - 65) 'phí bắt đầu chạy từ cột H
                        ws.Range(Arrpos(CountFee).Pos & 7).Value2 = Arrpos(CountFee).Items
                        ws.Range(Arrpos(CountFee).Pos & 8).Value2 = "USD"
                        ws.Range(Arrpos(CountFee).Pos & 9).Value2 = "FL" & CountFee + 1
                        ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 = dsFee.Tables(0).Rows(k).Item("FEE").ToString
                        CountFee += 1
                    End If
                Next

                '''''''''''''''''''''''''''''''''''kết thúc đoạn sửa ngày 13-12-2007




                ''thêm các phụ phí của bill
                QueryBillPrice(dsdata.Tables(0).Rows(i).Item("F0").ToString)

                'che ngay 13-12-2007 hiện tất cả các phụ phí chứ không gioi hạn
                'If dsBillPrice.Tables(0).Rows.Count > 0 Then
                'For k As Integer = 0 To dsBillPrice.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsbillprice.table(0)
                '    If dsBillPrice.Tables(0).Rows(k).Item("BL_ID").ToString = dsdata.Tables(0).Rows(i).Item("F0").ToString Then
                '        For j As Integer = 8 To 26
                '            If dsBillPrice.Tables(0).Rows(k).Item("F" & j).ToString.Trim.Length > 0 Then
                '                ws.Range(Alpha(j) & CurRow).Value2 = dsBillPrice.Tables(0).Rows(k).Item("F" & j).ToString
                '            End If
                '        Next
                '    End If
                'Next
                'End If

                For k As Integer = 0 To dsBillPrice.Tables(0).Rows.Count - 1 'chạy hết các dòng của dsbillprice.table(0)
                    Dim Insert As Boolean = True
                    'CountFee = 0
                    For TempPos As Integer = 0 To CountFee - 1
                        If dsBillPrice.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper() = Arrpos(TempPos).Items Then
                            ws.Range(Arrpos(TempPos).Pos & CurRow).Value2 = dsBillPrice.Tables(0).Rows(k).Item("FEE").ToString
                            Insert = False
                            Exit For
                        End If
                    Next
                    If Insert Then
                        Arrpos(CountFee).Items = dsBillPrice.Tables(0).Rows(k).Item("Charge_Code").ToString.Trim.ToUpper()
                        Arrpos(CountFee).Pos = Alpha(Asc("I") + CountFee - 65) 'phí bắt đầu chạy từ cột H
                        ws.Range(Arrpos(CountFee).Pos & 7).Value2 = Arrpos(CountFee).Items
                        ws.Range(Arrpos(CountFee).Pos & 8).Value2 = "USD"
                        ws.Range(Arrpos(CountFee).Pos & 9).Value2 = "FL" & CountFee + 1
                        ws.Range(Arrpos(CountFee).Pos & CurRow).Value2 = dsBillPrice.Tables(0).Rows(k).Item("FEE").ToString
                        CountFee += 1
                    End If
                Next

                For k As Integer = 0 To 4
                    If dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString.Length > 0 Then
                        'arrS(dem, k) = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                        ws.Range(Alpha(k) & CurRow).Value2 = dsdata.Tables(0).Rows(i).Item("F" & k + 1).ToString
                    End If
                Next
                'If dsdata.Tables(0).Rows(i).Item("F5").ToString = "8SGNHAM4AN824" Then
                '    DisplayMessage(True, "")

                'End If
                Dim Temp As String = ReplaceAlpha(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim) 'Strings.Replace(dsdata.Tables(0).Rows(i).Item("Commission").ToString.Trim, "%", "").Trim
                For P As Integer = 0 To dsdataOceanFreight.Tables(0).Rows.Count - 1
                    If dsdata.Tables(0).Rows(i).Item("F0").ToString = dsdataOceanFreight.Tables(0).Rows(P).Item("F0").ToString Then
                        If UCase(dsdataOceanFreight.Tables(0).Rows(P).Item("PREPAID_COLLECT").ToString) = "PREPAID" Then
                            ws.Range("F" & CurRow).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                            If dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight").ToString <> "" And Temp <> "" And UCase(Temp) <> "A" Then
                                ws.Range("H" & CurRow).Value2 = (CDbl(dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")) * CDbl(Temp.Trim) / 100).ToString
                            Else
                                If UCase(Temp) = "A" Then
                                    ws.Range("H" & CurRow).Value2 = 15 * dsdataOceanFreight.Tables(0).Rows(P).Item("quantity")
                                End If
                            End If

                        Else
                            ' khong show ra bao cao
                            'ws.Range("G" & CurRow).Value2 = dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")
                            If dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight").ToString <> "" And Temp <> "" And UCase(Temp) <> "A" Then
                                ws.Range("H" & CurRow).Value2 = (CDbl(dsdataOceanFreight.Tables(0).Rows(P).Item("OceanFreight")) * CDbl(Temp) / 100).ToString
                            Else
                                If UCase(Temp) = "A" Then
                                    ws.Range("H" & CurRow).Value2 = 15 * dsdataOceanFreight.Tables(0).Rows(P).Item("quantity")
                                End If
                            End If
                        End If
                    End If
                Next


                CurRow += 1
            Next

            ws.Range("B4").Value2 = Me.cboThang.Text & " / " & Me.cboNam.Text
            'Me.DataGridView1.DataSource = dsdata.Tables(0)
            ws.Range("B6").Value2 = tempvessel(0)
            ws.Range("E6").Value2 = tempvessel(1)

            ws.Range("G6").Value2 = CDate(tempvessel(2)).Date

            path = "c:\TripAccountOutbound" & tempvessel(0) & "-" & tempvessel(1) & CDate(tempvessel(2)).Date & Now.Second & ".xls"

            workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    '    Sub InsertExcel()
    '        connstring = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    '"Data Source=" & path & ";Extended Properties=""Excel 8.0;HDR=NO;"""
    '        Dim pram As OleDbParameter
    '        Dim dr As DataRow
    '        Dim olecon As OleDbConnection
    '        Dim olecomm As OleDbCommand
    '        Dim olecomm1 As OleDbCommand
    '        Dim oleadpt As OleDbDataAdapter
    '        Dim ds As DataSet
    '        Try
    '            olecon = New OleDbConnection
    '            olecon.ConnectionString = connstring
    '            olecomm = New OleDbCommand
    '            olecomm.CommandText = "Select F1, F2, F3, F4,F5,F6,F7, F8, F9, F10,F11,F12, F13, F14, F15, F16,F17,F18,F19, F20, F21, F22,F23,F24,F25,F26 from [Sheet1$]"
    '            olecomm.Connection = olecon
    '            olecomm1 = New OleDbCommand
    '            olecomm1.CommandText = "Insert into [Sheet1$] " & _
    '            "(F1, F2, F3, F4,F5,F6,F7, F8, F9, F10,F11,F12, F13, F14, F15, F16,F17,F18,F19, F20, F21, F22,F23,F24,F25,F26)" & _
    '            " values (@F1, @F2, @F3, @F4,@F5,@F6,@F7, @F8, @F9, @F10,@F11,@F12, @F13, @F14, @F15, @F16,@F17,@F18,@F19, @F20, @F21, @F22,@F23,@F24,@F25,@F26)"
    '            olecomm1.Connection = olecon
    '            pram = olecomm1.Parameters.Add("@F1", OleDbType.VarChar)
    '            pram.SourceColumn = "F1"
    '            pram = olecomm1.Parameters.Add("@F2", OleDbType.VarChar)
    '            pram.SourceColumn = "F2"
    '            pram = olecomm1.Parameters.Add("@F3", OleDbType.VarChar)
    '            pram.SourceColumn = "F3"
    '            pram = olecomm1.Parameters.Add("@F4", OleDbType.VarChar)
    '            pram.SourceColumn = "F4"
    '            pram = olecomm1.Parameters.Add("@F5", OleDbType.VarChar)
    '            pram.SourceColumn = "F5"
    '            pram = olecomm1.Parameters.Add("@F6", OleDbType.VarChar)
    '            pram.SourceColumn = "F6"

    '            For i As Integer = 7 To 26
    '                pram = olecomm1.Parameters.Add("@F" & i, OleDbType.UnsignedInt)
    '                pram.SourceColumn = "F" & i
    '            Next
    '            oleadpt = New OleDbDataAdapter(olecomm)
    '            ds = New DataSet
    '            olecon.Open()
    '            oleadpt.Fill(ds, "Sheet1")
    '            If IsNothing(ds) = False Then
    '                For k As Integer = 0 To dsdata.Tables(0).Rows.Count - 1
    '                    dr = ds.Tables(0).NewRow
    '                    For j As Integer = 1 To 26
    '                        If j <> 7 Then
    '                            dr.Item("F" & j) = dsdata.Tables(0).Rows(k).Item("F" & j)
    '                        End If
    '                    Next
    '                    ds.Tables(0).Rows.Add(dr)
    '                Next
    '                'Me.DataGridView1.DataSource = ds.Tables(0)
    '                oleadpt = New OleDbDataAdapter
    '                oleadpt.InsertCommand = olecomm1
    '                Dim i As Integer = oleadpt.Update(ds, "Sheet1")
    '                MessageBox.Show(i & " row affected")
    '            End If
    '        Catch ex As Exception
    '            MessageBox.Show(ex.Message)
    '        Finally
    '            olecon.Close()
    '            olecon = Nothing
    '            olecomm = Nothing
    '            oleadpt = Nothing
    '            ds = Nothing
    '            dr = Nothing
    '            pram = Nothing
    '        End Try
    '    End Sub
    ' ham lay phu phi
    ' neu prepaid tra nuoc thu 3 thi ko in ra
    Function QueryPrice(ByVal billID As String) As Integer
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            'strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,quantity,"
            'strQuery &= "BL_ID,Charge_Code,sum(Amount *Quantity*exchange) as Fee"

            strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,quantity,"
            strQuery &= "BL_ID,Charge_Code,sum(Amount *Quantity*exchange) as Fee"


            'strQuery &= "F8=case Charge_Code when 'BAF' then Amount *Quantity  end ," 'BAF
            'strQuery &= "F9=case Charge_Code when 'WRS' then Amount *Quantity end," 'WRS
            'strQuery &= "F10=case Charge_Code when 'CAF' then Amount*Quantity  end," 'CAF
            'strQuery &= "F11=case Charge_Code when 'DIB' then Amount*Quantity  end," 'DIB
            'strQuery &= "F12=case Charge_Code when 'DDC' then Amount*Quantity  end," 'DDC
            'strQuery &= "F13=case Charge_Code when 'LHC' then Amount*Quantity  end," 'LHC
            'strQuery &= "F14=case Charge_Code when 'MAF' then Amount*Quantity end," 'MAF
            'strQuery &= "F15=case Charge_Code when 'ACC' then Amount*Quantity  end," 'ACC
            'strQuery &= "F16=case Charge_Code when 'BKC' then Amount*Quantity end," 'BKC
            'strQuery &= "F17=case Charge_Code when 'ERS' then Amount*Quantity end," 'ERS
            'strQuery &= "F18=case Charge_Code when 'PTC' then Amount*Quantity end," 'PTC
            'strQuery &= "F19=case Charge_Code when 'PSS' then Amount*Quantity  end," 'PSS
            'strQuery &= "F20=case Charge_Code when 'COD' then Amount*Quantity end," 'COD
            'strQuery &= "F21=case Charge_Code when 'ASC' then Amount*Quantity  end," 'ACSAND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY )
            'strQuery &= "F22=case Charge_Code when 'PCF' then Amount*Quantity end," 'PCF
            'strQuery &= "F23=case Charge_Code when 'OIB' then Amount*Quantity  end," 'OIB
            'strQuery &= "F24=case Charge_Code when 'ARB' then Amount*Quantity end," 'ARB
            'strQuery &= "F25=case Charge_Code when 'RSC' then Amount*Quantity  end," 'RSC
            'strQuery &= "F26=case Charge_Code when 'ORC' then Amount*Quantity  end" 'ORC
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency ) inner join port on Freight_Charge_Master.payable_at_id=port.port_id"
            strQuery &= " Where BL_ID='" & billID & "' And port_code like 'VN%' And FREIGHT_CHARGE_Master.Continued=1 And PREPAID_COLLECT = 'PREPAID' And Charge_Code<>'OCB' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY)  "
            strQuery &= " Group By PREPAID_COLLECT,BL_ID,Charge_Code, exchange,quantity "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
            If dsFee.Tables(0).Rows.Count > 0 Then
                Return IIf(dsFee.Tables(0).Rows(0).Item("flag") = 1, 1, 0)
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function
    Function QueryPriceHistory(ByVal billID As String) As Integer
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,quantity, "
            strQuery &= "BL_ID,Charge_Code,sum(Amount *Quantity*tigia) as Fee"
            'strQuery &= "F8=case Charge_Code when 'BAF' then Amount *Quantity  end ," 'BAF
            'strQuery &= "F9=case Charge_Code when 'WRS' then Amount *Quantity end," 'WRS
            'strQuery &= "F10=case Charge_Code when 'CAF' then Amount*Quantity  end," 'CAF
            'strQuery &= "F11=case Charge_Code when 'DIB' then Amount*Quantity  end," 'DIB
            'strQuery &= "F12=case Charge_Code when 'DDC' then Amount*Quantity  end," 'DDC
            'strQuery &= "F13=case Charge_Code when 'LHC' then Amount*Quantity  end," 'LHC
            'strQuery &= "F14=case Charge_Code when 'MAF' then Amount*Quantity end," 'MAF
            'strQuery &= "F15=case Charge_Code when 'ACC' then Amount*Quantity  end," 'ACC
            'strQuery &= "F16=case Charge_Code when 'BKC' then Amount*Quantity end," 'BKC
            'strQuery &= "F17=case Charge_Code when 'ERS' then Amount*Quantity end," 'ERS
            'strQuery &= "F18=case Charge_Code when 'PTC' then Amount*Quantity end," 'PTC
            'strQuery &= "F19=case Charge_Code when 'PSS' then Amount*Quantity  end," 'PSS
            'strQuery &= "F20=case Charge_Code when 'COD' then Amount*Quantity end," 'COD
            'strQuery &= "F21=case Charge_Code when 'ASC' then Amount*Quantity  end," 'ACSAND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY )
            'strQuery &= "F22=case Charge_Code when 'PCF' then Amount*Quantity end," 'PCF
            'strQuery &= "F23=case Charge_Code when 'OIB' then Amount*Quantity  end," 'OIB
            'strQuery &= "F24=case Charge_Code when 'ARB' then Amount*Quantity end," 'ARB
            'strQuery &= "F25=case Charge_Code when 'RSC' then Amount*Quantity  end," 'RSC
            'strQuery &= "F26=case Charge_Code when 'ORC' then Amount*Quantity  end" 'ORC
            strQuery &= " From ((FREIGHT_CHARGE_Master LEFT JOIN Charge On Charge.Charge_ID=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id "
            strQuery &= " Where BL_ID='" & billID & "' And port_code like 'VN%' And FREIGHT_CHARGE_Master.Continued=1 And PREPAID_COLLECT = 'PREPAID' And Charge_Code<>'OCB' "
            strQuery &= " Group By PREPAID_COLLECT,BL_ID,Charge_Code, exchange,quantity "
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsFee.Tables(0).Rows.Count > 0 Then
                dsFee.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsFee.Tables(0))
            If dsFee.Tables(0).Rows.Count > 0 Then
                Return IIf(dsFee.Tables(0).Rows(0).Item("flag") = 1, 1, 0)
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function
    Function QueryBillPrice(ByVal billID As String) As Integer
        Try
            Dim strQuery As String
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            strQuery = " select flag=case PREPAID_COLLECT when 'COLLECT' Then 1 Else 0 end,"
            strQuery &= "BL_ID,Charge_Code,sum(UnitPrice *Quantity) as Fee "
            'strQuery &= "F8=case Charge_Code when 'BAF' then UnitPrice *Quantity  end ," 'BAF
            'strQuery &= "F9=case Charge_Code when 'WRS' then UnitPrice *Quantity end," 'WRS
            'strQuery &= "F10=case Charge_Code when 'CAF' then UnitPrice*Quantity  end," 'CAF
            'strQuery &= "F11=case Charge_Code when 'DIB' then UnitPrice*Quantity  end," 'DIB
            'strQuery &= "F12=case Charge_Code when 'DDC' then UnitPrice*Quantity  end," 'DDC
            'strQuery &= "F13=case Charge_Code when 'LHC' then UnitPrice*Quantity  end," 'LHC
            'strQuery &= "F14=case Charge_Code when 'MAF' then UnitPrice*Quantity end," 'MAF
            'strQuery &= "F15=case Charge_Code when 'ACC' then UnitPrice*Quantity  end," 'ACC
            'strQuery &= "F16=case Charge_Code when 'BKC' then UnitPrice*Quantity end," 'BKC
            'strQuery &= "F17=case Charge_Code when 'ERS' then UnitPrice*Quantity end," 'ERS
            'strQuery &= "F18=case Charge_Code when 'PTC' then UnitPrice*Quantity end," 'PTC
            'strQuery &= "F19=case Charge_Code when 'PSS' then UnitPrice*Quantity  end," 'PSS
            'strQuery &= "F20=case Charge_Code when 'COD' then UnitPrice*Quantity end," 'COD
            'strQuery &= "F21=case Charge_Code when 'ASC' then UnitPrice*Quantity  end," 'ACS
            'strQuery &= "F22=case Charge_Code when 'PCF' then UnitPrice*Quantity end," 'PCF
            'strQuery &= "F23=case Charge_Code when 'OIB' then UnitPrice*Quantity  end," 'OIB
            'strQuery &= "F24=case Charge_Code when 'ARB' then UnitPrice*Quantity end," 'ARB
            'strQuery &= "F25=case Charge_Code when 'RSC' then UnitPrice*Quantity  end," 'RSC
            'strQuery &= "F26=case Charge_Code when 'ORC' then UnitPrice*Quantity  end" 'ORC
            strQuery &= " From (PRICEBILLMASTER LEFT JOIN Charge On Charge.Charge_ID=PRICEBILLMASTER.Charge_ID) inner join port on PRICEBILLMASTER.POP=port.port_code "
            strQuery &= " Where BL_ID='" & billID & "' And port_code like 'VN%' and PRICEBILLMASTER.Continued=1 and PREPAID_COLLECT='PREPAID' And Charge_Code<>'OCB'"
            strQuery &= " Group By PREPAID_COLLECT,BL_ID,Charge_Code"
            Dim cmdSelectFee As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterFee As New SqlClient.SqlDataAdapter(cmdSelectFee)
            If dsBillPrice.Tables(0).Rows.Count > 0 Then
                dsBillPrice.Tables(0).Rows.Clear()
            End If
            AdapterFee.Fill(dsBillPrice.Tables(0))
            If dsBillPrice.Tables(0).Rows.Count > 0 Then
                Return IIf(dsBillPrice.Tables(0).Rows(0).Item("flag") = 1, 1, 0)
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Function

    Sub QueryBill()
        Try
            Dim strQuery As String

            strQuery = "Select distinct BillOfLading.BL_ID as F0,PLACE_OF_RECEIPT_CODE AS F1,PORT_OF_LOADING_CODE AS F2,PORT_OF_DISCHARGE_CODE AS F3,PLACE_OF_DESTINATION_CODE AS F4,BL_NO AS F5,Commission,BillOfLading.TAX "
            strQuery &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strQuery &= " Where SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And BillOfLading.Continued=1 order by BL_NO "
            'strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyNo='" & tempvessel(1) & "' And BillOfLading.Continued=1 And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text & " Order by BL_NO "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If dsdata.Tables(0).Rows.Count > 0 Then
                dsdata.Tables(0).Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables(0))
            ' lay ocean freight
            strQuery = "Select FREIGHT_CHARGE_Master.BL_ID as F0,OceanFreight=Sum(Amount*Quantity*exchange),Prepaid_Collect, quantity,port.port_code  as POP "
            strQuery &= " from (((((BillOfLading LEFT JOIN FREIGHT_CHARGE_Master on FREIGHT_CHARGE_Master.BL_ID=BillOfLading.BL_ID) "
            strQuery &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN CHARGE On Charge.Charge_Id=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency) inner join port on Freight_Charge_Master.payable_at_id=port.port_id  "
            strQuery &= " where CHARGE.Charge_Code like'%OCB%' and FREIGHT_CHARGE_Master.Continued=1 And SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) " 'And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text
            strQuery &= " "
            strQuery &= " Group By FREIGHT_CHARGE_Master.BL_ID,Prepaid_Collect,quantity,port.port_code "
            Dim cmdSelectOceanFreight As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterOceanFreight As New SqlClient.SqlDataAdapter(cmdSelectOceanFreight)
            If dsdataOceanFreight.Tables(0).Rows.Count > 0 Then
                dsdataOceanFreight.Tables(0).Rows.Clear()
            End If
            AdapterOceanFreight.Fill(dsdataOceanFreight.Tables(0))

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryBillHistory()
        Try
            Dim strQuery As String

            strQuery = "Select distinct BillOfLading.BL_ID as F0,PLACE_OF_RECEIPT_CODE AS F1,PORT_OF_LOADING_CODE AS F2,PORT_OF_DISCHARGE_CODE AS F3,PLACE_OF_DESTINATION_CODE AS F4,BL_NO AS F5,Commission,BillOfLading.TAX "
            strQuery &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strQuery &= " Where SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And BillOfLading.Continued=1 order by bl_no "
            'strQuery &= " Where Vessel='" & tempvessel(0) & "' and VoyNo='" & tempvessel(1) & "' And BillOfLading.Continued=1 And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text & " Order by BL_NO "
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If dsdata.Tables(0).Rows.Count > 0 Then
                dsdata.Tables(0).Rows.Clear()
            End If
            Adapter.Fill(dsdata.Tables(0))
            ' lay ocean freight
            strQuery = "Select FREIGHT_CHARGE_Master.BL_ID as F0,OceanFreight=Sum(Amount*Quantity*tigia),Prepaid_Collect,quantity  "
            strQuery &= " from ((((BillOfLading LEFT JOIN FREIGHT_CHARGE_Master on FREIGHT_CHARGE_Master.BL_ID=BillOfLading.BL_ID) "
            strQuery &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN CHARGE On Charge.Charge_Id=FREIGHT_CHARGE_Master.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strQuery &= " where CHARGE.Charge_Code like'%OCB%' and FREIGHT_CHARGE_Master.Continued=1 And SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' AND CURRENCY.UPDATETIME=(SELECT MAX(CURRENCY.UPDATETIME)FROM CURRENCY WHERE CURRENCY =Freight_Charge_Master.CURRENCY ) " 'And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text
            strQuery &= " Group By FREIGHT_CHARGE_Master.BL_ID,Prepaid_Collect,quantity"
            Dim cmdSelectOceanFreight As New SqlClient.SqlCommand(strQuery, Conn)
            Dim AdapterOceanFreight As New SqlClient.SqlDataAdapter(cmdSelectOceanFreight)
            If dsdataOceanFreight.Tables(0).Rows.Count > 0 Then
                dsdataOceanFreight.Tables(0).Rows.Clear()
            End If
            AdapterOceanFreight.Fill(dsdataOceanFreight.Tables(0))

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select distinct SailingSchedule.SailingScheduleID as Id, Vessel +' - '+ VoyNo + ' - ' + convert(nvarchar,ETD)  as data "
            SQL &= " from (((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
            SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            SQL &= " where BillOfLading.Continued=1 And day(ETD)=" & Me.txtDay.Text & " And month(ETD)=" & Me.cboThang.Text & " And year(ETD)=" & Me.cboNam.Text
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

    'Sub QueryETA()
    '    Try
    '        Dim SQL As String = "Select ETA from BillOfLading where BLIB_ID='" & gBillInboundID & "' And Continued=1 And Vessel=" & Me.cboVessel.Text.Trim & "Voyage=" & Me.cboSoChuyen.Text.Trim
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        Dim cmdSelect As New SqlClient.SqlCommand(SQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        Dim ds As New DataSet
    '        Adapter.Fill(ds)

    '    Catch ex As Exception

    '    End Try
    'End Sub
    Private Sub frmTripAccountOutbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.cboNam.Text = Now.Year
            Me.cboThang.Text = Now.Month
            dsFee.Tables.Clear()
            dsdata.Tables.Clear()
            dsBillPrice.Tables.Clear()

            dsdataOceanFreight.Clear()

            dsFee.Tables.Add()

            dsdata.Tables.Add()

            dsdataOceanFreight.Tables.Add()

            dsBillPrice.Tables.Add()
            For i As Integer = 2000 To 2050
                Me.cboNam.Items.Add(i)
            Next

            'QueryBill()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cboThang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboThang.SelectedIndexChanged, txtDay.SelectedIndexChanged
        Me.cboVessel.Text = ""
        QueryVessel()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click

        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            tempvessel = Strings.Split(Me.cboVessel.Text, " - ")
            If Me.RadioEPre.Checked = True Then
                QueryBill()
                SetExcelValue()
            Else
                QueryBillHistory()
                SetExcelValueHistory()
            End If

        Catch ex As Exception

        End Try

        'InsertExcel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub


    Private Sub cboNam_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboNam.SelectedIndexChanged

        QueryVessel()
    End Sub

End Class