Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmMISA
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -55281
            Dim i As Integer
            Dim j As Integer

            Dim tongprofit, tongallcbm As Double
            Me.DataGridView1.Rows.Clear()
            tongprofit = 0



            ' so hoa don the hien luon chi nhanhvd: HPH000001 cua HAI PHONG; SGN000001 cua SG
            If UCase(Me.cboChinhanh.Text) = "ALL" Then
                sql = "select * from taxinvoice  left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid where huy=0 and  convert(datetime,dateinvoice) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and taxdetail.continued=1  order by convert(datetime,dateinvoice),invoiceno "
            End If

            If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                sql = "select * from taxinvoice left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid where  huy=0 and convert(datetime,dateinvoice) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and invoiceno like '%" & Me.cboChinhanh.Text & "%'  and taxdetail.continued=1  order by convert(datetime,dateinvoice),invoiceno "
            End If

            Dim tongthuusd As Double = 0
            Dim tongchiusd As Double = 0
            Dim tongcbm As Double = 0
            '--------
            Dim sqlCont As String = ""
            Dim dsCont As New DataSet

            Dim kg As Double = 0
            Dim kien As Double = 0
            Dim khoi As Double = 0
            Dim cont As String = ""
            Dim type As String = ""
            Dim cont20 As Integer = 0
            Dim cont40 As Integer = 0
            Dim sotienTruocthueVND As Double = 0
            Dim sotiensauthueVND As Double = 0
            Dim tenphi As String

            '------------------
            ds = ReadDataSet(sql)
            Dim STT As Integer = 1
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung moi dong tga lay so lieu
                'Me.DataGridView1.Rows.Add(1)
                'currow = Me.DataGridView1.RowCount - 2
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' moi hoa don ta lay toan bo thong tin taxdetils 
                    ' tu so bill ta lay thong tin bill da xuat hoa don ' billnumber
                    ' ta lay so dong tren taxdetails
                    sotienTruocthueVND = 0
                    sotiensauthueVND = 0
                    tenphi = ""
                    Dim sqlsodong As String
                    Dim dssodong As New DataSet
                    'sqlsodong = "select * from taxdetail  where taxinvoiceid='" & ds.Tables(0).Rows(i).Item("taxinvoiceid").ToString & "' and continued=1"
                    'dssodong = ReadDataSet(sqlsodong)
                    'If dssodong.Tables(0).Rows.Count > 0 Then
                    '    For j = 0 To dssodong.Tables(0).Rows.Count - 1
                    '        sotienTruocthueVND += dssodong.Tables(0).Rows(j).Item("pricebantruocthue").ToString
                    '        sotiensauthueVND += dssodong.Tables(0).Rows(j).Item("priceban").ToString
                    '        tenphi += dssodong.Tables(0).Rows(j).Item("items").ToString + ";"
                    '    Next
                    'End If


                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2
                    Dim sttStr As String

                    If STT < 10 Then
                        sttStr = "00000" + STT.ToString
                    Else
                        If STT < 99 Then
                            sttStr = "0000" + STT.ToString
                        Else
                            If STT > 99 Then
                                sttStr = "000" + STT.ToString
                            End If
                        End If
                    End If
                    Dim ngay, thang, nam As String
                    ngay = CDate(ds.Tables(0).Rows(i).Item("dateinvoice").ToString).Day.ToString
                    If CInt(ngay) < 10 Then
                        ngay = "0" + ngay
                    End If
                    thang = CDate(ds.Tables(0).Rows(i).Item("dateinvoice").ToString).Month.ToString
                    If CInt(thang) < 10 Then
                        thang = "0" + thang
                    End If
                    nam = CDate(ds.Tables(0).Rows(i).Item("dateinvoice").ToString).Year.ToString


                    '----------Misa
                    Me.DataGridView1.Item("dalaphoadon", currow).Value = 1
                    Me.DataGridView1.Item("ngayhachtoan", currow).Value = ngay + "/" + thang + "/" + nam
                    Me.DataGridView1.Item("ngaychungtu", currow).Value = ngay + "/" + thang + "/" + nam
                    Me.DataGridView1.Item("sochungtu", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    Me.DataGridView1.Item("sohoadon", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")
                    Me.DataGridView1.Item("ngayhoadon", currow).Value = ngay + "/" + thang + "/" + nam

                    Me.DataGridView1.Item("sophieuxuat", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    Me.DataGridView1.Item("mausohd", currow).Value = "01GTKT3/002" 'ds.Tables(0).Rows(i).Item("serialno").ToString '.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    Me.DataGridView1.Item("kyhieuhd", currow).Value = ds.Tables(0).Rows(i).Item("serialno").ToString '.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    Dim sqlcus As String
                    Dim dscus As New DataSet
                    sqlcus = "select * from customer where customer_id ='" & ds.Tables(0).Rows(i).Item("customer_id").ToString & "'"
                    dscus = ReadDataSet(sqlcus)
                    If dscus.Tables(0).Rows.Count > 0 Then
                        Me.DataGridView1.Item("makhachhang", currow).Value = dscus.Tables(0).Rows(0).Item("shortName").ToString
                        Me.DataGridView1.Item("tenkhachhang", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString
                        Me.DataGridView1.Item("diachi", currow).Value = dscus.Tables(0).Rows(0).Item("Address").ToString
                        Me.DataGridView1.Item("masothue", currow).Value = dscus.Tables(0).Rows(0).Item("TaxCode").ToString

                    End If
                    Me.DataGridView1.Item("diengiai", currow).Value = tenphi
                    Me.DataGridView1.Item("loaitien", currow).Value = "VND"
                    Me.DataGridView1.Item("tygia", currow).Value = 1
                    ' tu itemid trong tacdetail ta lay thong tin phi, ma hang,ten,...
                    Try
                        Dim sqlcharge As String
                        Dim dscharge As New DataSet
                        If ds.Tables(0).Rows(i).Item("itemid").ToString <> "" Then
                            sqlcharge = "select * from charge where Charge_ID='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "' "
                            dscharge = ReadDataSet(sqlcharge)
                            If dscharge.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("mahang", currow).Value = dscharge.Tables(0).Rows(0).Item("charge_code").ToString
                                Me.DataGridView1.Item("tenhang", currow).Value = dscharge.Tables(0).Rows(0).Item("Charge").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                    Me.DataGridView1.Item("TKDoanhthuCo", currow).Value = "5113" 'ds.Tables(0).Rows(i).Item("tkco").ToString
                    Me.DataGridView1.Item("TKTienChiphiNo", currow).Value = "131" 'ds.Tables(0).Rows(i).Item("tkno").ToString

                    Me.DataGridView1.Item("dvt", currow).Value = ds.Tables(0).Rows(i).Item("container_type").ToString

                    Try
                        Me.DataGridView1.Item("soluong", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("quantity").ToString, 3)

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("dongiasauthue", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString * ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100) + 1), 0)

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("dongia", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString, 0)

                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("thanhtien", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)

                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("thanhtienquydoi", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)


                    Catch ex As Exception

                    End Try

                    Me.DataGridView1.Item("thueGTGT", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    Try
                        Me.DataGridView1.Item("tienthueGTGT", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100, 0)

                    Catch ex As Exception

                    End Try

                    Me.DataGridView1.Item("tkthuegtgt", currow).Value = "33311"





                    STT += 1
                Next
            End If


            Me.DataGridView1.Rows.Add(1)
            currow = Me.DataGridView1.RowCount - 2
            'Me.DataGridView1.Item("Column1", currow).Value = "Total"
            'Me.DataGridView1.Item("Column2", currow).Value = FormatNumber(tongthulclport - tongchilclport, 2)
            'Me.DataGridView1.Item("Column3", currow).Value = FormatNumber(tongkhoilclport.ToString, 3)

            '----------------
            InsertAutoNumberToGrid(Me.DataGridView1)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
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


                    path = StartupPath & "\misa_new.xls"

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
                    Dim DongHienTai As Integer = 2
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



                    Dim dongcong As Integer = 0
                    If Me.DataGridView1.RowCount > 0 Then
                        ' hien thi thong tin co ban
                        For i = 0 To Me.DataGridView1.RowCount - 1
                            Try
                                ws.Range("a" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("hienthitrenso", i).Value 'ref

                                ws.Range("b" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("hinhthucbanhang", i).Value 'ref

                                ws.Range("c" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("phuongthucthanhtoan", i).Value 'ref

                                ws.Range("d" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("kiemphieuxuatkho", i).Value 'ref

                                ws.Range("e" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("lapkemhoadon", i).Value 'ref
                                ws.Range("f" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dalaphoadon", i).Value 'ref

                                ws.Range("g" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("ngayhachtoan", i).Value 'ref


                                ws.Range("h" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("ngaychungtu", i).Value 'ref


                                ws.Range("i" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("sochungtu", i).Value 'ref
                                ws.Range("j" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("sophieuxuat", i).Value 'ref
                                ws.Range("k" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("lydoxuat", i).Value 'ref

                                ws.Range("l" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("mausohd", i).Value 'ref
                                ws.Range("m" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("kyhieuhd", i).Value 'ref

                                ws.Range("n" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("sohoadon", i).Value 'ref

                                ws.Range("o" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("ngayhoadon", i).Value 'ref

                                ws.Range("p" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("makhachhang", i).Value 'ref



                                ws.Range("q" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tenkhachhang", i).Value 'ref

                                ws.Range("r" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("diachi", i).Value 'ref

                                ws.Range("s" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("masothue", i).Value 'ref
                                ws.Range("t" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("diengiai", i).Value 'ref


                                ws.Range("u" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nopvaotk", i).Value 'ref
                                ws.Range("v" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nvbanhang", i).Value 'ref

                                ws.Range("w" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("loaitien", i).Value 'ref
                                ws.Range("x" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tygia", i).Value 'ref

                                ws.Range("y" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("mahang", i).Value 'ref
                                ws.Range("z" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tenhang", i).Value 'ref
                                ws.Range("aa" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("hangkhuyenmai", i).Value 'ref

                                ws.Range("ab" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tktienchiphino", i).Value 'ref
                                ws.Range("ac" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkdoanhthuco", i).Value 'ref
                                ws.Range("ad" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("dvt", i).Value 'ref

                                ws.Range("ae" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("soluong", i).Value 'ref


                                ws.Range("af" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dongiasauthue", i).Value 'ref
                                ws.Range("ag" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dongia", i).Value 'ref

                                ws.Range("ah" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtien", i).Value 'ref

                                ws.Range("ai" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienquydoi", i).Value 'ref


                                ws.Range("aj" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tyleck", i).Value 'ref
                                ws.Range("ak" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienchietkhau", i).Value 'ref



                                ws.Range("al" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienchietkhauquydoi", i).Value 'ref

                                ws.Range("am" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tkchietkhau", i).Value 'ref

                                ws.Range("an" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("giatinhthueXK", i).Value 'ref
                                ws.Range("ao" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thueXK", i).Value 'ref

                                ws.Range("ap" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienthuexk", i).Value 'ref
                                ws.Range("aq" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tkthuexk", i).Value 'ref


                                ws.Range("ar" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thuegtgt", i).Value 'ref


                                ws.Range("as" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienthuegtgt", i).Value 'ref
                                ws.Range("at" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienthuegtgtquydoi", i).Value 'ref

                                ws.Range("au" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tkthuegtgt", i).Value 'ref
                                ws.Range("av" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("hhkhongthtrentokhaithuegtgt", i).Value 'ref


                                ws.Range("aw" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("kho", i).Value 'ref
                                ws.Range("ax" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkgiavon", i).Value 'ref
                                ws.Range("ay" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkkho", i).Value 'ref
                                ws.Range("az" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dongiavon", i).Value 'ref
                                ws.Range("ba" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienvon", i).Value 'ref


                                dongcong += 1
                            Catch ex As Exception

                            End Try




                            DongHienTai += 1
                        Next
                    End If
                    'Try
                    '    ws.Range("c5").Value2 = (dongcong - 2).ToString
                    'Catch ex As Exception

                    'End Try

                    ' sum
                    'ws.Range("u" + (DongHienTai - 1).ToString).Value2 = "from:" + Me.dtpFrom.Value.Date + " to:" + Me.dtpto.Value.Date
                    'ws.Range("v" + (DongHienTai - 1).ToString).Value2 = "Total"
                    'ws.Range("w" + (DongHienTai - 1).ToString).Value2 = FormatNumber(tongtienDebit, 2)
                    'ws.Range("x" + (DongHienTai - 1).ToString).Value2 = ""
                    ' ws.Range("x2:x" & (DongHienTai - 1).ToString).Columns.WrapText = 1
                    ' ke khung
                    'ws.Range("A1:o" & (DongHienTai - 1).ToString).Columns.Borders.Value = 1


                    'ws.Range("m4:m" & (DongHienTai - 1).ToString).Columns.WrapText = 1
                    ' ke khung

                    '----------------------------------------------
                    '------------------------------
                    Dim format1 As String
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\Misa-" + "_" & Now.Second & ".xlsx"

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
    End Sub

    Private Sub frmBravo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.cboChinhanh.Items.Clear()
            Me.cboChinhanh.Text = ""
            If gBranch = "" Then

                Me.cboChinhanh.Items.Add("ALL")
                Me.cboChinhanh.Items.Add("SGN")
                Me.cboChinhanh.Items.Add("HPH")

            ElseIf gBranch = "SGN" Then

                Me.cboChinhanh.Items.Add("SGN")

            ElseIf gBranch = "HPH" Then

                Me.cboChinhanh.Items.Add("HPH")

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class