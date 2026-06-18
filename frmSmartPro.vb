
Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmSmartPro
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
                sql = "select * from taxinvoice  left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid where huy=0 and  convert(datetime,dateinvoice) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' order by convert(datetime,dateinvoice),invoiceno "
            End If

            If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                sql = "select * from taxinvoice left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid where  huy=0 and convert(datetime,dateinvoice) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and invoiceno like '%" & Me.cboChinhanh.Text & "%' order by convert(datetime,dateinvoice),invoiceno "
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
                    sqlsodong = "select * from taxdetail  where taxinvoiceid='" & ds.Tables(0).Rows(i).Item("taxinvoiceid").ToString & "' and continued=1"
                    dssodong = ReadDataSet(sqlsodong)
                    If dssodong.Tables(0).Rows.Count > 0 Then
                        For j = 0 To dssodong.Tables(0).Rows.Count - 1
                            sotienTruocthueVND += dssodong.Tables(0).Rows(j).Item("pricebantruocthue").ToString
                            sotiensauthueVND += dssodong.Tables(0).Rows(j).Item("priceban").ToString
                            tenphi += dssodong.Tables(0).Rows(j).Item("items").ToString + ";"
                        Next
                    End If


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
                    Me.DataGridView1.Item("LCTG", currow).Value = "HD"
                    Me.DataGridView1.Item("SR_HD", currow).Value = ""

                    Me.DataGridView1.Item("SO_HD", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")
                    Me.DataGridView1.Item("NGAY_HD", currow).Value = ngay + "/" + thang + "/" + nam
                    Me.DataGridView1.Item("SOCT", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")
                    Me.DataGridView1.Item("SO_PC", currow).Value = ""
                    Me.DataGridView1.Item("NGAYCT", currow).Value = ngay + "/" + thang + "/" + nam
                    Me.DataGridView1.Item("DIENGIAI", currow).Value = tenphi
                    Me.DataGridView1.Item("TKNO", currow).Value = ds.Tables(0).Rows(i).Item("tkNO").ToString
                    Dim sqlcus As String
                    Dim dscus As New DataSet
                    sqlcus = "select * from customer where customer_id ='" & ds.Tables(0).Rows(i).Item("customer_id").ToString & "'"
                    dscus = ReadDataSet(sqlcus)
                    If dscus.Tables(0).Rows.Count > 0 Then
                        Try
                            Me.DataGridView1.Item("MADTPNCO", currow).Value = dscus.Tables(0).Rows(0).Item("TaxCode").ToString.Substring(dscus.Tables(0).Rows(0).Item("TaxCode").ToString.Length - 6, 6)
                        Catch ex As Exception

                        End Try

                        Me.DataGridView1.Item("MAKH", currow).Value = dscus.Tables(0).Rows(0).Item("shortName").ToString
                        Me.DataGridView1.Item("TENKH", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString
                        Me.DataGridView1.Item("diachi", currow).Value = dscus.Tables(0).Rows(0).Item("Address").ToString
                        Me.DataGridView1.Item("diachi_NGD", currow).Value = dscus.Tables(0).Rows(0).Item("Address").ToString
                        Me.DataGridView1.Item("KHACHHANG", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString
                        Me.DataGridView1.Item("MS_DN", currow).Value = dscus.Tables(0).Rows(0).Item("TaxCode").ToString

                    End If
                    Me.DataGridView1.Item("MAYTCPCO", currow).Value = ""

                    ' tu itemid trong tacdetail ta lay thong tin phi, ma hang,ten,...
                    Try
                        Dim sqlcharge As String
                        Dim dscharge As New DataSet
                        If ds.Tables(0).Rows(i).Item("itemid").ToString <> "" Then
                            sqlcharge = "select * from charge where Charge_ID='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "' "
                            dscharge = ReadDataSet(sqlcharge)
                            If dscharge.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("MADMCO", currow).Value = dscharge.Tables(0).Rows(i).Item("charge_code").ToString
                                Me.DataGridView1.Item("TENDM", currow).Value = dscharge.Tables(0).Rows(i).Item("Charge").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try
                    Me.DataGridView1.Item("LO_XUAT", currow).Value = ""


                    Me.DataGridView1.Item("MA_CT", currow).Value = ""

                    Me.DataGridView1.Item("MADTGT", currow).Value = ""
                    Me.DataGridView1.Item("DONVI_CTU", currow).Value = ""
                    Me.DataGridView1.Item("DONVI", currow).Value = ds.Tables(0).Rows(i).Item("container_type").ToString
                    Me.DataGridView1.Item("LUONG_CTU", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("quantity").ToString, 3)
                    Me.DataGridView1.Item("LUONG", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("quantity").ToString, 3)

                    If Me.chkcu.Checked = True Then
                        Me.DataGridView1.Item("DGVND", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1), 0)

                        Me.DataGridView1.Item("TTVND", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)
                        Me.DataGridView1.Item("PT_CK", currow).Value = "0"
                        Me.DataGridView1.Item("CHIETKHAU", currow).Value = "0"
                        Me.DataGridView1.Item("HDVAT", currow).Value = "R"
                        Me.DataGridView1.Item("TKTHUE", currow).Value = "33311"
                        Me.DataGridView1.Item("TS_GTGT", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                        Me.DataGridView1.Item("THUEVND", currow).Value = FormatNumber(CDbl(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)
                        Me.DataGridView1.Item("TTVND_TT", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)


                    Else
                        Me.DataGridView1.Item("DGVND", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString, 0)

                        Me.DataGridView1.Item("TTVND", currow).Value = FormatNumber((ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)
                        Me.DataGridView1.Item("PT_CK", currow).Value = "0"
                        Me.DataGridView1.Item("CHIETKHAU", currow).Value = "0"
                        Me.DataGridView1.Item("HDVAT", currow).Value = "R"
                        Me.DataGridView1.Item("TKTHUE", currow).Value = "33311"
                        Me.DataGridView1.Item("TS_GTGT", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                        Me.DataGridView1.Item("THUEVND", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100 * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)
                        Me.DataGridView1.Item("TTVND_TT", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)

                    End If
                    Me.DataGridView1.Item("MATHANG", currow).Value = ""
                    Me.DataGridView1.Item("NGAYCTGS", currow).Value = ngay + "/" + thang + "/" + nam
                    Me.DataGridView1.Item("STT_SC", currow).Value = ""
                    Me.DataGridView1.Item("THANG", currow).Value = thang
                    Me.DataGridView1.Item("MAUSER", currow).Value = "QUANLY"
                    'Me.DataGridView1.Item("ngayhachtoan", currow).Value = ngay + "/" + thang + "/" + nam
                    'Me.DataGridView1.Item("ngaychungtu", currow).Value = ngay + "/" + thang + "/" + nam
                    'Me.DataGridView1.Item("sochungtu", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    'Me.DataGridView1.Item("sohoadon", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")


                    'Me.DataGridView1.Item("diengiai", currow).Value = tenphi
                    'Me.DataGridView1.Item("loaitien", currow).Value = "VND"
                    'Me.DataGridView1.Item("tygia", currow).Value = 1

                    'Me.DataGridView1.Item("TKDoanhthuCo", currow).Value = ds.Tables(0).Rows(i).Item("tkco").ToString


                    'Me.DataGridView1.Item("dvt", currow).Value = ds.Tables(0).Rows(i).Item("container_type").ToString

                    'Try
                    '    Me.DataGridView1.Item("soluong", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("quantity").ToString, 3)

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    Me.DataGridView1.Item("dongiasauthue", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString, 0)

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    Me.DataGridView1.Item("dongia", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString / ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100) + 1), 0)

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    Me.DataGridView1.Item("thanhtien", currow).Value = FormatNumber((ds.Tables(0).Rows(i).Item("unitPrice").ToString / ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100) + 1)) * ds.Tables(0).Rows(i).Item("quantity").ToString, 0)

                    'Catch ex As Exception

                    'End Try

                    'Try
                    '    Me.DataGridView1.Item("thanhtienquydoi", currow).Value = FormatNumber((ds.Tables(0).Rows(i).Item("unitPrice").ToString / ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100) + 1)) * ds.Tables(0).Rows(i).Item("quantity").ToString)


                    'Catch ex As Exception

                    'End Try

                    'Me.DataGridView1.Item("thueGTGT", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    'Try
                    '    Me.DataGridView1.Item("tienthueGTGT", currow).Value = FormatNumber(((ds.Tables(0).Rows(i).Item("unitPrice").ToString / ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100) + 1)) * ds.Tables(0).Rows(i).Item("quantity").ToString) * ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100)), 0)

                    'Catch ex As Exception

                    'End Try

                    'Me.DataGridView1.Item("tkthuegtgt", currow).Value = "3331"





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


                    path = StartupPath & "\smartpro.xls"

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
                                ws.Range("a" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LCTG", i).Value 'ref

                                ws.Range("a" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LCTG", i).Value 'ref
                                ws.Range("b" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SR_HD", i).Value 'ref
                                ws.Range("c" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("SO_HD", i).Value 'ref
                                ws.Range("d" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAY_HD", i).Value 'ref
                                ws.Range("e" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("SOCT", i).Value 'ref
                                ws.Range("f" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SO_PC", i).Value 'ref
                                ws.Range("g" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAYCT", i).Value 'ref
                                ws.Range("h" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DIENGIAI", i).Value 'ref
                                ws.Range("i" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("TKNO", i).Value 'ref
                                ws.Range("j" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADTPNNO", i).Value 'ref
                                ws.Range("k" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MAYTCPNO", i).Value 'ref
                                ws.Range("l" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADMNO", i).Value 'ref
                                ws.Range("m" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LO_NHAP", i).Value 'ref
                                ws.Range("n" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("TKCO", i).Value 'ref
                                ws.Range("o" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("MADTPNCO", i).Value 'ref
                                ws.Range("p" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MAYTCPCO", i).Value 'ref
                                ws.Range("q" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADMCO", i).Value 'ref
                                ws.Range("r" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LO_XUAT", i).Value 'ref
                                ws.Range("s" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_CT", i).Value 'ref
                                ws.Range("t" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADTGT", i).Value 'ref
                                ws.Range("u" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENDM", i).Value 'ref
                                ws.Range("v" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DONVI_CTU", i).Value 'ref 
                                ws.Range("w" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DONVI", i).Value 'ref
                                ws.Range("x" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LUONG_CTU", i).Value 'ref
                                ws.Range("y" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SR_HD", i).Value 'ref
                                ws.Range("z" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DGVND", i).Value 'ref
                                ws.Range("aa" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TTVND", i).Value 'ref
                                ws.Range("ab" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("PT_CK", i).Value 'ref
                                ws.Range("ac" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("CHIETKHAU", i).Value 'ref
                                ws.Range("ad" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("HDVAT", i).Value 'ref
                                ws.Range("ae" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TKTHUE", i).Value 'ref
                                ws.Range("af" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("TS_GTGT", i).Value 'ref
                                ws.Range("ag" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("THUEVND", i).Value 'ref
                                ws.Range("ah" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TTVND_TT", i).Value 'ref
                                ws.Range("ai" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MATHANG", i).Value 'ref
                                ws.Range("aj" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("MAKH", i).Value 'ref
                                ws.Range("ak" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENKH", i).Value 'ref
                                ws.Range("al" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("MS_DN", i).Value 'ref
                                ws.Range("am" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DIACHI", i).Value 'ref
                                ws.Range("an" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DIACHI_NGD", i).Value 'ref
                                ws.Range("ao" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("KHACHHANG", i).Value 'ref
                                ws.Range("ap" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("GHICHU", i).Value 'ref
                                ws.Range("aq" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NV_BAN", i).Value 'ref
                                ws.Range("ar" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DGVON", i).Value 'ref
                                ws.Range("as" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("GTVON", i).Value 'ref
                                ws.Range("at" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LAI_GOP", i).Value 'ref
                                ws.Range("au" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TYGIA", i).Value 'ref
                                ws.Range("av" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TTUSD", i).Value 'ref
                                ws.Range("aw" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("THUEUSD", i).Value 'ref
                                ws.Range("ax" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TTUSD_TT", i).Value 'ref
                                ws.Range("ay" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SOCTGS", i).Value 'ref
                                ws.Range("az" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAYCTGS", i).Value 'ref
                                ws.Range("ba" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("STT_SC", i).Value 'ref
                                ws.Range("bb" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DT_NHAN", i).Value 'ref
                                ws.Range("bc" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DT_XUAT", i).Value 'ref
                                ws.Range("bd" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("THANG", i).Value 'ref
                                ws.Range("be" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SO_HOPDONG", i).Value 'ref
                                ws.Range("bf" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MAUSER", i).Value 'ref
                                ws.Range("bg" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MATTTU", i).Value 'ref
                                ws.Range("bh" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAY_DAO_HAN", i).Value 'ref
                                ws.Range("bi" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADVTT", i).Value 'ref
                                ws.Range("bj" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENDVTT", i).Value 'ref
                                ws.Range("bk" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TKNHNO", i).Value 'ref
                                ws.Range("bl" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENTKNHNO", i).Value 'ref
                                ws.Range("bm" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADVNT", i).Value 'ref
                                ws.Range("bn" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENDVNT", i).Value 'ref
                                ws.Range("bo" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TKNHCO", i).Value 'ref
                                ws.Range("bp" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENTKNHCO", i).Value 'ref
                                ws.Range("bq" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENVUNG", i).Value 'ref
                                ws.Range("br" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("KYHIEU", i).Value 'ref
                                ws.Range("bs" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MANGD", i).Value 'ref
                                ws.Range("bt" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DIENGIAI2", i).Value 'ref
                                ws.Range("bu" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DGUSD", i).Value 'ref
                                ws.Range("bv" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TIENHANG", i).Value 'ref
                                ws.Range("bw" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENHH_IN", i).Value 'ref
                                ws.Range("bx" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("HTTT", i).Value 'ref
                                ws.Range("by" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("INVOI", i).Value 'ref
                                ws.Range("bz" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MASANPHAM", i).Value 'ref
                                ws.Range("ca" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DONTRONG", i).Value 'ref
                                ws.Range("cb" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_NV_BAN", i).Value 'ref
                                ws.Range("cc" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SOCT_U", i).Value 'ref
                                ws.Range("cd" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("COL_11", i).Value 'ref 
                                ws.Range("ce" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("COL_12", i).Value 'ref
                                ws.Range("cf" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("COL_13", i).Value 'ref
                                ws.Range("cg" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DANHDAU", i).Value 'ref
                                ws.Range("ch" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TRANGTHAI", i).Value 'ref
                                ws.Range("ci" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("CHIETKHAU_USD", i).Value 'ref
                                ws.Range("cj" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DG_GC", i).Value 'ref
                                ws.Range("ck" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DG_VC", i).Value 'ref
                                ws.Range("cl" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("HANSUDUNG", i).Value 'ref
                                ws.Range("cm" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("ID_CHUNGTU", i).Value 'ref
                                ws.Range("cn" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("KHM_HD", i).Value 'ref
                                ws.Range("co" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("KXLDG", i).Value 'ref
                                ws.Range("cp" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LENHSX", i).Value 'ref
                                ws.Range("cq" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_HD", i).Value 'ref
                                ws.Range("cr" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_HH_GC", i).Value 'ref
                                ws.Range("cs" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_TIEP_THI", i).Value 'ref
                                ws.Range("ct" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_TT", i).Value 'ref
                                ws.Range("cu" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MA_VUNG", i).Value 'ref
                                ws.Range("cv" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MANHOM", i).Value 'ref
                                ws.Range("cw" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MANHOM1", i).Value 'ref
                                ws.Range("cx" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MANHOM2", i).Value 'ref
                                ws.Range("cy" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MODE", i).Value 'ref
                                ws.Range("cz" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MS_TM", i).Value 'ref
                                ws.Range("da" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAY_HOPDONG_SC", i).Value 'ref
                                ws.Range("db" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAY_TT", i).Value 'ref
                                ws.Range("dc" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NGAYLO", i).Value 'ref
                                ws.Range("dd" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NHACUNGCAP", i).Value 'ref
                                ws.Range("de" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NHASANXUAT", i).Value 'ref
                                ws.Range("df" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NHOMKH", i).Value 'ref
                                ws.Range("dg" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("NOIDUNG_SC", i).Value 'ref
                                ws.Range("dh" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SL_GC", i).Value 'ref
                                ws.Range("di" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SO_PT", i).Value 'ref
                                ws.Range("dj" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("SOKHEUOC", i).Value 'ref
                                ws.Range("dk" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("STT_TT", i).Value 'ref
                                ws.Range("dl" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TEN_TIEP_THI", i).Value 'ref
                                ws.Range("dm" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENCT_SC", i).Value 'ref
                                ws.Range("dn" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENYTCPNO", i).Value 'ref
                                ws.Range("do" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("THANG_N", i).Value 'ref
                                ws.Range("dp" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("THUEEUR", i).Value 'ref
                                ws.Range("dq" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TK_CHIETKHAU", i).Value 'ref
                                ws.Range("dr" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TK_XUATKHO", i).Value 'ref
                                ws.Range("ds" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TNK_USD", i).Value 'ref
                                ws.Range("dt" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TNK_VND", i).Value 'ref
                                ws.Range("du" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TS_NK", i).Value 'ref
                                ws.Range("dv" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TT_GC", i).Value 'ref
                                ws.Range("dw" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TT_VC", i).Value 'ref
                                ws.Range("dx" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TTEUR", i).Value 'ref
                                ws.Range("dy" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DONVI_1", i).Value 'ref
                                ws.Range("dz" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("DONVI_2", i).Value 'ref
                                ws.Range("ea" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("HSQD_DVT", i).Value 'ref
                                ws.Range("eb" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LUONG_1", i).Value 'ref
                                ws.Range("ec" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("LUONG_2", i).Value 'ref
                                ws.Range("ed" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MABPSX", i).Value 'ref
                                ws.Range("ee" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("STT_BT", i).Value 'ref
                                ws.Range("ef" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENDTGT", i).Value 'ref
                                ws.Range("eg" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("IMEI", i).Value 'ref
                                ws.Range("eh" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADONHANG", i).Value 'ref 
                                ws.Range("ei" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("BARCODE", i).Value 'ref
                                ws.Range("ej" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MADONHANG_MUA", i).Value 'ref
                                ws.Range("ek" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("MANHOMDT1", i).Value 'ref
                                ws.Range("el" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("TENNHOMDT1", i).Value 'ref


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
                    path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\Smartpro-" + "_" & Now.Second & ".xlsx"

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