Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmManifest_out

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            opt1()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub opt1() ' XUAT SOC
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


            path = StartupPath & "\EMANIFEST.xlsx"

            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item(3)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 11
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
            Dim j As Integer

            Dim tangP As Integer = 9
            Dim tang As Integer = 10
            Dim ds As New DataSet
            Dim sql, HBL As String
            Dim i As Integer = 0

            Dim stt As Integer = 1
            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0
            '-----------
            Dim sqlContainer As String
            Dim dsContainer As New DataSet

            '  sql = "select * from inbound where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "





            sql = "select * from " & gPrintOutbound & " where blob_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "








            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' hien thi thong tin co ban
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    HBL = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    ' ws.Range("B6").Value2 = ds.Tables(0).Rows(i).Item("tongSoKienLoaiKien").ToString '
                    'Try
                    '    Dim tlk() As String
                    '    tlk = ds.Tables(0).Rows(i).Item("loaikien").ToString.Split("-")
                    '    ws.Range("B7").Value2 = tlk(0)
                    'Catch ex As Exception
                    '    'ws.Range("b22").Value2 = ds.Tables(0).Rows(i).Item("loaikien").ToString
                    'End Try














                    Dim tongkien As Double = 0
                    sqlContainer = " select * from containertype where outboundid='" & gEManifest & "'"
                    dsContainer = ReadDataSet(sqlContainer)
                    If dsContainer.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dsContainer.Tables(0).Rows.Count - 1
                            ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("mblmawb").ToString '
                            ws.Range("B" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("shipper").ToString '
                            ws.Range("c" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString '
                            ws.Range("d" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("notify").ToString '
                            ws.Range("f" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString '
                            ws.Range("g" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString '
                            ws.Range("h" + CStr(tang)).Value2 = "" 'ds.Tables(0).Rows(i).Item("hscode").ToString '
                            ws.Range("i" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString + " (" + dsContainer.Tables(0).Rows(j).Item("sokien").ToString + " " + dsContainer.Tables(0).Rows(j).Item("type").ToString + ")" '
                            ws.Range("j" + CStr(tang)).Value2 = "0" 'ds.Tables(0).Rows(i).Item("description").ToString + " (" + dsContainer.Tables(0).Rows(j).Item("sokien").ToString + ")" '
                            ws.Range("k" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString '
                            ws.Range("l" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString '
                            ws.Range("o" + CStr(tang)).Value2 = "KGM" 'dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString '
                            ws.Range("p" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("podcode").ToString '
                            ws.Range("q" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("podcode").ToString '
                            ws.Range("r" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("polcode").ToString '
                            ws.Range("s" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("polcode").ToString '

                            ws.Range("u" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("podcode").ToString '
                            ws.Range("v" + CStr(tang)).Value2 = IIf(dsContainer.Tables(0).Rows(j).Item("containertype").ToString Like "*40*", "Container 40", dsContainer.Tables(0).Rows(j).Item("containertype").ToString) '
                            ws.Range("w" + CStr(tang)).Value2 = "CM3"
                            Try
                                tongkien += CDbl(dsContainer.Tables(0).Rows(j).Item("sokien").ToString)
                            Catch ex As Exception

                            End Try
                            Try
                                ws.Range("B7").Value2 = dsContainer.Tables(0).Rows(j).Item("type").ToString.Split("-")(0)
                            Catch ex As Exception
                                ws.Range("B7").Value2 = dsContainer.Tables(0).Rows(j).Item("type").ToString
                            End Try

                            '---------------
                            'ws.Range("a" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("hscode").ToString '
                            'ws.Range("b" + CStr(tang)).Value2 = ds.Tables(0).Rows(i).Item("description").ToString.Replace(Chr(13), " ").Replace(Chr(10), " ") '


                            'ws.Range("c" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokg").ToString
                            'ws.Range("d" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("sokhoi").ToString
                            'ws.Range("e" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("containerno").ToString
                            'ws.Range("f" + CStr(tang)).Value2 = dsContainer.Tables(0).Rows(j).Item("seal").ToString
                            tang += 1
                        Next

                    End If
                    ws.Range("B6").Value2 = tongkien.ToString



                    ' stt += 1
                Next
            End If
            ' sum

            ' Dim path As String = ""
            'path = OpenDlg(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + hbl + "_" & Now.Second & ".xlsx")
            'If path = "" Then
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" + HBL.Replace("/", "_") + "_SOC" & Now.Second & ".xlsx"
            'End If
            '------------------------------
            Dim format1 As String
            '  path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\" + hbl + "_" & Now.Second & ".xlsx"
            'If app.Version = "11.0" Then
            '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
            'ElseIf (app.Version = "12.0") Then
            '    format1 = Excel.XlFileFormat.xlExcel7 ';   
            'End If
            ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
            DisplayMessage(True, "File name : " & path & " saved.")

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class