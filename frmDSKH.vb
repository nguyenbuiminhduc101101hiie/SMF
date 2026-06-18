
Imports Excel
Imports system.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.SharedPublic
Class frmDSKH

    Private Sub frmDSKH_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim id, value, strSQL As String
            Me.cboref.Items.Clear()
            id = "ref"
            value = "ref"
            strSQL = "Select distinct ref From inbound where Continued=1 order by ref "
            loadDataToObject(Me.cboref, strSQL, id, value)
            ' -
            If gRef_CVRH <> "" Then
                Me.cboref.Text = gRef_CVRH
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim app As Application
            'ExportExecelDeCre(Me.dgdStatement, Me, "Debit Credit Statement", "From : " + Me.dtpFrom.Value.Date + "     To: " + Me.dtpto.Value.Date)
            '------------xuat ra excel theo mau
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            Dim path As String
            app = New Application()
            app.Visible = True
            Dim dsdata As New DataSet
            Dim workbooks As Workbooks
            workbooks = app.Workbooks
            Dim workbook As _Workbook
            path = StartupPath & "\dskh.xls"
            workbook = workbooks.Open(path)



            Dim sheets As Sheets
            sheets = workbook.Worksheets
            Dim ws As _Worksheet
            ws = sheets.Item("dskh")
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            Dim DongCongThuc As Integer = 9
            Dim DongHienTai As Integer = 9
            Dim n As Integer '= Me.dgdStatement.RowCount - 1

            Dim tang As Integer = 25 ' chua 6 cot ghi POD
            Dim j As Integer
        
            Dim sqlEff As String
            Dim dung As Boolean = False

            Dim i As Integer = 0
            Dim customerid As String
            Dim donghangnhap As Integer = 0
            Dim TONGE1, TONGE2, tong1, tong2, tong3, tong4, tong5 As Double
            ' lap het dong trong luoi
            '  ws.Range("a7").Value2 = "DAILY BOOKING REPORT " + Me.dtpFrom.Value.Date.Month.ToString + "-" + Me.dtpFrom.Value.Date.Year.ToString

            'For j = 1 To 31
            '    ws.Range(ws.Cells(10, j), ws.Cells(10, j)).Interior.Color = RGB(20, 255, 35)
            'Next
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound where ref='" & Me.cboref.Text.Trim & "' ORDER by hbl "
            ds = ReadDataSet(sql)
            ws.Range("c2").Value2 = ds.Tables(0).Rows(0).Item("vessel").ToString
            ws.Range("c3").Value2 = ds.Tables(0).Rows(0).Item("voyage").ToString
            ws.Range("c4").Value2 = ds.Tables(0).Rows(0).Item("eta").ToString

            ws.Range("c5").Value2 = ds.Tables(0).Rows(0).Item("mbl").ToString
         
          

            For i = 0 To ds.Tables(0).Rows.Count - 1


                ws.Range("b" + DongHienTai.ToString).Value2 = ds.Tables(0).Rows(i).Item("hbl").ToString
                ws.Range("c" + DongHienTai.ToString).Value2 = ds.Tables(0).Rows(i).Item("consignee").ToString
                ws.Range("d" + DongHienTai.ToString).Value2 = ds.Tables(0).Rows(i).Item("description").ToString

                ws.Range("e" + DongHienTai.ToString).Value2 = ds.Tables(0).Rows(i).Item("shippingmarks").ToString
                Dim kien As Double = 0
                Dim kg As Double = 0
                Dim khoi As Double = 0
                '-----
                Dim k As Integer
                Dim sqlKKK As String
                Dim dsKKK As New DataSet
                Dim cont As String
                sqlKKK = "select * from containerrepair where inboundid='" & gInboundID & "' "

                dsKKK = ReadDataSet(sqlKKK)
                If dsKKK.Tables(0).Rows.Count > 0 Then
                    For k = 0 To dsKKK.Tables(0).Rows.Count - 1



                        If dsKKK.Tables(0).Rows(k).Item("sokien").ToString <> "" Then
                            kien += CDbl(dsKKK.Tables(0).Rows(k).Item("sokien").ToString)
                        End If
                        If dsKKK.Tables(0).Rows(k).Item("sokg").ToString <> "" Then
                            kg += CDbl(dsKKK.Tables(0).Rows(k).Item("sokg").ToString)
                        End If
                        If dsKKK.Tables(0).Rows(k).Item("sokhoi").ToString <> "" Then
                            khoi += CDbl(dsKKK.Tables(0).Rows(k).Item("sokhoi").ToString)
                        End If

                        If dsKKK.Tables(0).Rows(0).Item("containerno").ToString <> "" Then
                            cont += dsKKK.Tables(0).Rows(k).Item("containerno").ToString + "/" + dsKKK.Tables(0).Rows(k).Item("seal").ToString '+ "/" + dsKKK.Tables(0).Rows(k).Item("type").ToString + "; "

                        End If

                    Next
                End If


                'For j = 1 To 46
                '    cont += ds.Tables(0).Rows(0).Item("containerno" & j.ToString).ToString + "/" + ds.Tables(0).Rows(0).Item("seal" & j.ToString).ToString + "; "
                'Next
                cont = cont.Replace("/;", "").Trim
                '---------------

                ws.Range("c6").Value2 = cont
                ws.Range("f" + DongHienTai.ToString).Value2 = kien.ToString
                ws.Range("g" + DongHienTai.ToString).Value2 = kg.ToString
                ws.Range("h" + DongHienTai.ToString).Value2 = khoi.ToString

                DongHienTai += 1
            Next


            'ws.Range("A10:ae" & (DongHienTai + 1).ToString).Columns.Borders.Value = 1
            ws.Range("b9:i" & DongHienTai.ToString).Columns.WrapText = 0





            'path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\dskh " & Now.Second & ".xls"

            'workbook.SaveAs(path, , , , , , XlSaveAsAccessMode.xlShared, , , , )
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\dskh-" + Me.cboref.Text.ToString + strUserName.ToString + "_" & Now.Second & ".xlsx"
            'If app.Version = "11.0" Then
            '    format1 = Excel.XlFileFormat.xlWorkbookNormal ';  '  //This format would throw an exception if the machine has office 2007
            'ElseIf (app.Version = "12.0") Then
            '    format1 = Excel.XlFileFormat.xlExcel7 ';   
            'End If
            ' workbook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,,, ,,,,,)

            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            gRef_CVRH = ""
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class