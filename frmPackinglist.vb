Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmPackinglist
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            '  DisplayMessage(True, "Đăng ký mẫu với bộ phận kỹ thuật.!")
            Dim sql As String
            Dim ds As New DataSet
            Dim i, currow As Integer
            Me.DataGridView1.Rows.Clear()
            If Me.CHKSOC.Checked = True Then
                sql = "select * from outbound left join containertype on outbound.BLoB_ID=containertype.outboundid where mblmawb='" & Me.cboHBL.Text.Trim & "' and nvocc=1 "
            End If
            If Me.CHKCOC.Checked = True Then
                sql = "select * from outbound left join containertype on outbound.BLoB_ID=containertype.outboundid where mblmawb='" & Me.cboHBL.Text.Trim & "' and nvocc=0 "
            End If
            If Me.chlallsoccoc.Checked = True Then
                sql = "select * from outbound left join containertype on outbound.BLoB_ID=containertype.outboundid where mblmawb='" & Me.cboHBL.Text.Trim & "' "
            End If
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then


                Me.txtshipper.Text = ds.Tables(0).Rows(i).Item("shipper").ToString
                Me.txtbookingno.Text = ds.Tables(0).Rows(i).Item("bkno").ToString
                Me.txtvessel.Text = ds.Tables(0).Rows(i).Item("vessel").ToString
                Me.txtvoy.Text = ds.Tables(0).Rows(i).Item("voyage").ToString
                Me.txtngayhabai.Text = ds.Tables(0).Rows(i).Item("ngayhabai").ToString
                Me.txttransit.Text = ds.Tables(0).Rows(i).Item("transit").ToString
                Me.txtPOD.Text = ds.Tables(0).Rows(i).Item("pod").ToString
                Me.txtghichu.Text = ds.Tables(0).Rows(i).Item("remarks").ToString

                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    ' Me.DataGridView1.Item("no", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                    Me.DataGridView1.Item("contno", currow).Value = ds.Tables(0).Rows(i).Item("containerno").ToString

                    Me.DataGridView1.Item("sealno", currow).Value = ds.Tables(0).Rows(i).Item("seal").ToString

                    Try
                        Me.DataGridView1.Item("descriptionContainer", currow).Value = ds.Tables(0).Rows(i).Item("descriptionContainer").ToString

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("GROSSWEIGHT", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("sokg").ToString, 2)

                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("NhietdoThonggio", currow).Value = ds.Tables(0).Rows(i).Item("nhietdo").ToString + "/" + ds.Tables(0).Rows(i).Item("thonggio").ToString

                    Catch ex As Exception

                    End Try




                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmLoadinglist_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id, value, strsql As String
        Me.cboHBL.Items.Clear()
        id = "blob_id"
        value = "mblmawb"
        strsql = "Select  blob_id,mblmawb From outbound where Continued=1 Order By mblmawb "
        loadDataToObject(Me.cboHBL, strsql, id, value)




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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


                    path = StartupPath & "\Packinglist.xlsx"

                    workbook = workbooks.Open(path)



                    Dim sheets As Sheets
                    sheets = workbook.Worksheets
                    Dim ws As _Worksheet
                    ws = sheets.Item(1)
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
                    Dim tang As Integer = 23
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





                    '  sql = "select * from " & gPrintInbound & " where blib_id='" & gEManifest & "' " 'convert(datetime,SailingDate) >= '" & Me.dtpFromETD.Value.Date & "' and convert(datetime,SailingDate) <= '" & Me.dtpToETD.Value.Date & "' and continued=1 order by stuff(ref,1,3,'') "







                    ws.Range("c13").Value2 = Me.txtshipper.Text


                    ws.Range("h13").Value2 = Me.txtbookingno.Text
                    ws.Range("c15").Value2 = Me.txtvessel.Text
                    ws.Range("f15").Value2 = Me.txtvoy.Text
                    ws.Range("i15").Value2 = Me.txtngayhabai

                    ws.Range("c17").Value2 = Me.txttransit.Text
                    ws.Range("f17").Value2 = Me.txtPOD.Text
                    ws.Range("i17").Value2 = Me.txtghichu.Text


                    If Me.DataGridView1.Rows.Count > 0 Then
                        ' hien thi thong tin co ban
                        For i = 0 To Me.DataGridView1.Rows.Count - 1

                            ws.Range("b" + tang.ToString).Value2 = Me.DataGridView1.Item("contno", i).Value

                            ' ws.Range("c" + tang.ToString).Value2 = Me.DataGridView1.Item("type", i).Value

                            ws.Range("c" + tang.ToString).Value2 = Me.DataGridView1.Item("sealno", i).Value



                            '   ws.Range("e" + tang.ToString).Value2 = Me.DataGridView1.Item("netweight", i).Value


                            ws.Range("g" + tang.ToString).Value2 = Me.DataGridView1.Item("descriptionContainer", i).Value
                            ws.Range("f" + tang.ToString).Value2 = Me.DataGridView1.Item("grossweight", i).Value

                            ws.Range("f" + tang.ToString).Value2 = Me.DataGridView1.Item("NhietdoThonggio", i).Value

                         
                            ' ws.Range("i" + tang.ToString).Value2 = Me.DataGridView1.Item("blno", i).Value

                            ' ws.Range("h" + tang.ToString).Value2 = Me.DataGridView1.Item("DESTINATION", i).Value
                            tang += 1
                            ' stt += 1
                        Next
                    End If
                    ' sum
                    ws.Range("b" + (tang + 3).ToString).Value2 = "Lưu ý :"
                    ws.Range("c" + (tang + 3).ToString).Value2 = "CODE CẢNG :"
                    tang += 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "- Đề nghị Quý khách hàng chỉ sử dụng mẫu Container Packing Lít này cho tất cả các container xuất qua CARGO LINES."
                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "- Người gửi hàng vui lòng cung cấp đầy đủ thông tin vào Container Packing Lít và nộp lại cho Điều Độ Cảng."

                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "Nếu không thực hiện, container sẽ không được phép hạ bãi và xếp lên tàu."


                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "'- Người gửi hàng sẽ chịu trách nhiêm về các chi phí phát sinh do việc cung cấp thông tin sai hoặc thiếu trên "

                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "Container Packing List. "


                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "'- Đề nghị Quý khách hàng đóng hàng vào đúng số container đã cấp theo lệnh cấp rỗng. Sử dụng đúng seal Hãng Tàu"



                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = " đã cấp và khai báo đầy đủ số (Số và Chữ)."



                    tang = 1
                    ws.Range("b" + (tang + 3).ToString).Value2 = "'- Yêu cầu dán nhãn hàng nguy hiểm đầy đủ 04 mặt trên Container (đóng hàng IMO)."


                    tang = 1
                    ws.Range("i" + (tang + 3).ToString).Value2 = "Đại diện khách hàng ký tên"

                    tang = 1
                    ws.Range("i" + (tang + 3).ToString).Value2 = "For and on behalf of shipper"


                    tang = 1
                    ws.Range("i" + (tang + 3).ToString).Value2 = "(Số điện thoại liên lạc)"
                    tang = 1
                    ws.Range("i" + (tang + 3).ToString).Value2 = "Họ và Tên"


                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\" & Me.cboHBL.Text & "_" & Now.Second & ".xlsx"
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
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class