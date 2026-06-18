Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmexportKhoCFS

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Try
                Try
                    Dim app As Application
                    Try

                        Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
                        Dim path As String
                        app = New Application()
                        app.Visible = False
                        Dim dsdata As New DataSet
                        Dim workbooks As Workbooks
                        workbooks = app.Workbooks
                        Dim workbook As _Workbook


                        path = StartupPath & "\khocfs.xls"

                        workbook = workbooks.Open(path)



                        Dim sheets As Sheets
                        sheets = workbook.Worksheets
                        Dim ws, ws1 As _Worksheet
                        ws = sheets.Item(1) ' 1 la debit

                        If ws Is Nothing Then
                            app.Quit()
                            Return
                        End If


                        Dim DongCongThuc As Integer = 9
                        Dim DongHienTai As Integer = 6
                        Dim donghientaiF As Integer = DongHienTai
                        Dim BillId As String
                        Dim n As Integer
                        Dim dem As Integer = 0
                        Dim BillNo As String = ""
                        Dim market As String = ""
                        ' lay ten khach hang
                        Dim sqlC As String
                        Dim cus, add, tel, fax, taxcode As String
                        Dim dsC As New DataSet
                        Dim j As Integer = 0

                        Dim tangP As Integer = 9
                        Dim tang As Integer = 29
                        Dim ds As New DataSet
                        Dim sql As String
                        Dim i As Integer = 0

                        Dim stt As Integer = 1
                        Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
                        Dim kien As Double = 0
                        Dim kg As Double = 0
                        Dim khoi As Double = 0
                        Dim hbl As String
                        '-----------
                        Dim tongtienDebit As Double = 0
                        Dim tongtienCredit As Double = 0

                        Dim tongkien, tongkg, tongkhoi As Double

                        Dim dongcong As Integer = 0
                        sql = "select * from KhoCFSconsol"
                        ds = ReadDataSet(sql)
                        If ds.Tables(0).Rows.Count > 0 Then

                            ws.Range("d3").Value2 = ds.Tables(0).Rows(0).Item("tentau").ToString

                            ws.Range("e3").Value2 = ds.Tables(0).Rows(0).Item("chuyen").ToString

                            ws.Range("f3").Value2 = ds.Tables(0).Rows(0).Item("ngaycap").ToString
                            ws.Range("g3").Value2 = ds.Tables(0).Rows(0).Item("socont").ToString

                            ws.Range("h3").Value2 = ds.Tables(0).Rows(0).Item("seal").ToString
                            ws.Range("i3").Value2 = ds.Tables(0).Rows(0).Item("kichco").ToString

                            ws.Range("j3").Value2 = ds.Tables(0).Rows(0).Item("mbl").ToString

                            ws.Range("k3").Value2 = ds.Tables(0).Rows(0).Item("ngaydi").ToString


                            ' hien thi thong tin co ban
                            For i = 0 To ds.Tables(0).Rows.Count - 1
                                Try
                                    ws.Range("a" + DongHienTai.ToString).Value2 = (i + 1).ToString '"'" + ds.Tables(0).Rows(i).Item("ngaydi").ToString

                                    ws.Range("b" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("hbl").ToString

                                    ws.Range("c" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("ngayhbl").ToString
                                    ws.Range("d" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("chuhang").ToString
                                    ws.Range("e" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("diachi").ToString

                                    ws.Range("f" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("shipmarks").ToString
                                    ws.Range("g" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("hanghoa").ToString

                                    ws.Range("h" + DongHienTai.ToString).Value2 = "'" + ds.Tables(0).Rows(i).Item("dvt").ToString
                                    Try
                                        ws.Range("i" + DongHienTai.ToString).Value2 = CDbl(ds.Tables(0).Rows(i).Item("soluong").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        ws.Range("j" + DongHienTai.ToString).Value2 = CDbl(ds.Tables(0).Rows(i).Item("trongluong").ToString)

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        ws.Range("k" + DongHienTai.ToString).Value2 = CDbl(ds.Tables(0).Rows(i).Item("sokhoi").ToString)

                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongkien += CDbl(ds.Tables(0).Rows(i).Item("soluong").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongkg += CDbl(ds.Tables(0).Rows(i).Item("trongluong").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongkhoi += CDbl(ds.Tables(0).Rows(i).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try
                                    dongcong += 1
                                Catch ex As Exception

                                End Try




                                DongHienTai += 1
                            Next
                        End If
                        ws.Range("h" + (DongHienTai).ToString).Value2 = "Total"
                        ws.Range("i" + (DongHienTai).ToString).Value2 = FormatNumber(tongkien, 0)

                        ws.Range("j" + (DongHienTai).ToString).Value2 = FormatNumber(tongkg, 4)

                        ws.Range("k" + (DongHienTai).ToString).Value2 = FormatNumber(tongkhoi, 4)
                        '----------------------------------------------
                        '------------------------------
                        Dim format1 As String
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\KhoCFS-" + "_" & Now.Second & ".xlsx"

                        workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
                        DisplayMessage(True, "File name : " & path & " saved.")
                        '----------
                        'Dim xlApp As New Excel.Application
                        'Dim xlWorkBook As Excel.Workbook
                        'Dim xlWorkSheet As Excel.Worksheet
                        ''~~> Save As file
                        'xlWorkBook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,, , , )

                        ''~~> Close the file
                        'xlWorkBook.Close()
                        '--------------------------------------------------------

                    Catch ex As Exception
                        MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
                        MsgBox(Err.Description)
                        Return
                    Finally
                        app.Quit()
                    End Try
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class