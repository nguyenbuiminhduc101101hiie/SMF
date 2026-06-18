Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmPrintVAT_Attach
    Public rptDocument As New ReportDocument
    Private Sub frmPrintVAT_Attach_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim sql, strReportName As String
            chkShowMST.Visible = False
            Dim ds As New DataSet
            Dim dsKh As New DataSet
            Dim sqlKH As String
            Dim tientinhthue, thue, vattinh As Double
            Dim masothue() As Char
            Dim chungtu, donviban, diachi, tenKH, sohoadon, tigia, hinhthucthanhtoan, ngayHD, n1, n2, n3, n4, n5, n6, n7, n8, n9, n10, n11, n12, n13, n14, congtienhanghoadichvu, congtien, VAT, tienthue, tongcongtienthanhtoan, bangchu, khKy, NguoilapKy, ThutruongKy As TextObject

            Dim VAT1, VAT2, VAT3, VAT4, VAT5, VAT6 As Object
            Dim congtienhanghoa, thang, nam As Object
            Dim i As Integer
            'If Me.chkClucidat.Checked = True Then
            '    sql = " select taxinvoice.*, charge as clucidat,taxdetail.* from taxinvoice left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid LEFT OUTER JOIN "
            '    sql += " CHARGE ON TaxDetail.Clucidat = CHARGE.CHARGE_CODe where taxinvoice.taxinvoiceid= '" & gTaxInvoiceID & "' and taxdetail.continued=1 order by taxdetail.STT "

            'Else
            '    sql = " select taxinvoice.*, taxdetail.* from taxinvoice left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid LEFT OUTER JOIN "
            '    sql += " CHARGE ON TaxDetail.Clucidat = CHARGE.CHARGE_CODe where taxinvoice.taxinvoiceid= '" & gTaxInvoiceID & "' and taxdetail.continued=1 order by taxdetail.STT "


            'End If
            '      sql = " select taxinvoice.*, taxdetail.* from taxinvoice left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid where taxinvoice.taxinvoiceid= '" & gTaxInvoiceID & "' and taxdetail.continued=1 order by STT "
            sql = "select * from outboundfreight left join charge on outboundfreight.itemid=charge.charge_id where customerid='" & gTaxInvoice_cusID & "' and ngayhoadon='" & gSohoadon & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count <= 0 Then
                sql = "select * from inboundfreight left join charge on inboundfreight.itemid=charge.charge_id where customerid='" & gTaxInvoice_cusID & "' and ngayhoadon='" & gSohoadon & "'"
                ds = ReadDataSet(sql)
            End If
            If ds.Tables(0).Rows.Count <= 0 Then
                sql = "select * from logisticsfreight left join charge on logisticsfreight.itemid=charge.charge_id where customerid='" & gTaxInvoice_cusID & "' and ngayhoadon='" & gSohoadon & "'"
                ds = ReadDataSet(sql)

            End If
            strReportName = "ReportVAT-Attach"

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)
            ' lay du lieu dua vao
            ' lay thong tin khach hang
            sqlKH = "select * from taxinvoice left join customer on taxinvoice.customer_id=customer.customer_id where taxinvoice.taxinvoiceid= '" & gTaxInvoiceID & "'"
            dsKh = ReadDataSet(sqlKH)
            If dsKh.Tables(0).Rows.Count > 0 Then
                tenKH = rptDocument.ReportDefinition.ReportObjects("txttenkhachhang")
                tenKH.Text = dsKh.Tables(0).Rows(0).Item("englishname").ToString '+ dsKh.Tables(0).Rows(0).Item("address").ToString
                diachi = rptDocument.ReportDefinition.ReportObjects("txtdiachikhachhang")
                diachi.Text = dsKh.Tables(0).Rows(0).Item("address").ToString
                Try
                    Dim stkcus As Object
                    stkcus = rptDocument.ReportDefinition.ReportObjects("txtsotaikhoan")
                    stkcus.Text = dsKh.Tables(0).Rows(0).Item("sotaikhoan").ToString
                Catch ex As Exception

                End Try
                'lay masothue tach ra rieng tung char
                masothue = dsKh.Tables(0).Rows(0).Item("taxcode").ToString.ToCharArray
                For i = 0 To masothue.Length - 1
                    n1 = rptDocument.ReportDefinition.ReportObjects("n" & i + 1)
                    n1.Text = masothue(i).ToString
                Next



            End If


            If Me.chkShowMST.Checked = True Then
                For i = 0 To masothue.Length - 1
                    rptDocument.ReportDefinition.ReportObjects("n" & i + 1).ObjectFormat.EnableSuppress = False


                Next
            Else
                For i = 0 To masothue.Length - 1
                    rptDocument.ReportDefinition.ReportObjects("n" & i + 1).ObjectFormat.EnableSuppress = True


                Next
            End If


            Dim lien As Object
            'lien = rptDocument.ReportDefinition.ReportObjects("txtlien")
            'lien.Text = cboLien.Text

            hinhthucthanhtoan = rptDocument.ReportDefinition.ReportObjects("txthinhthucthanhtoan")
            hinhthucthanhtoan.Text = dsKh.Tables(0).Rows(0).Item("methodpayment").ToString

            ngayHD = rptDocument.ReportDefinition.ReportObjects("txtngay")
            ngayHD.Text = CDate(dsKh.Tables(0).Rows(0).Item("dateinvoice").ToString.Replace("12:00:00 AM", "")).Day

            chungtu = rptDocument.ReportDefinition.ReportObjects("txtbillno")
            chungtu.Text = dsKh.Tables(0).Rows(0).Item("chungtu").ToString
            thang = rptDocument.ReportDefinition.ReportObjects("txtthang")
            thang.Text = CDate(dsKh.Tables(0).Rows(0).Item("dateinvoice").ToString.Replace("12:00:00 AM", "")).Month



            nam = rptDocument.ReportDefinition.ReportObjects("txtnam")
            nam.Text = CDate(dsKh.Tables(0).Rows(0).Item("dateinvoice").ToString.Replace("12:00:00 AM", "")).Year.ToString.Replace("20", "")



            ' lay tham so ten va dia chi Cong ty
            'donviban = rptDocument.ReportDefinition.ReportObjects("txtdonviban")
            'donviban.Text = getOptionValue("companyname", "ALL", "All", "Name", "C")
            'diachi = rptDocument.ReportDefinition.ReportObjects("txtdiachi")
            'diachi.Text = getOptionValue("companyaddress", "ALL", "All", "address", "C")
            'txtsohoadon

            sohoadon = rptDocument.ReportDefinition.ReportObjects("txtsohoadon")
            sohoadon.Text = dsKh.Tables(0).Rows(0).Item("invoiceno").ToString
            ' thue VAT
            VAT = rptDocument.ReportDefinition.ReportObjects("txtvat")
            VAT.Text = dsKh.Tables(0).Rows(0).Item("VATShow").ToString

            'If Me.chktigia.Checked = True Then
            '    rptDocument.ReportDefinition.ReportObjects("txttigia").ObjectFormat.EnableSuppress = False
            'Else
            '    rptDocument.ReportDefinition.ReportObjects("txttigia").ObjectFormat.EnableSuppress = True
            'End If
            Dim k As Integer
            Dim tigia1 As String = "1"
            For k = 0 To dsKh.Tables(0).Rows.Count - 1
                If dsKh.Tables(0).Rows(k).Item("exchange").ToString <> "1" Then
                    tigia1 = dsKh.Tables(0).Rows(0).Item("exchange").ToString
                End If
            Next
            tigia = rptDocument.ReportDefinition.ReportObjects("txttigia")
            tigia.Text = "TG : " + FormatNumber(tigia1, 2).Replace(",", ".")


            ' tinh thue
            Dim j As Integer
            'tinh tong
            Dim sqlTong As String
            Dim dsTong As New DataSet
            Dim TT As Double = 0
            Dim tax As Double = 0
            Dim ST As Double = 0
            Dim li As Integer

            'sqlTong = " select unitprice  * quantity * exchangeRate as Truocthue,Taxpriceban  as tax,unitprice * exchangeRate * quantity as Sauthue,currency,exchangeRate from taxinvoice left join taxdetail on taxinvoice.taxinvoiceid=taxdetail.taxinvoiceid  "
            'sqlTong += "  where taxinvoice.taxinvoiceid= '" & gTaxInvoiceID & "' and taxdetail.continued=1  "
            'dsTong = ReadDataSet(sqlTong)
            'If dsTong.Tables(0).Rows.Count > 0 Then
            '    For li = 0 To dsTong.Tables(0).Rows.Count - 1
            '        TT += FormatNumber(CDbl(dsTong.Tables(0).Rows(li).Item("truocthue").ToString), 0)
            '        tax = FormatNumber(CDbl(dsTong.Tables(0).Rows(0).Item("tax").ToString), 0)
            '        ST += FormatNumber(CDbl(dsTong.Tables(0).Rows(li).Item("sauthue").ToString), 0)
            '    Next

            'End If
            'For j = 0 To ds.Tables(0).Rows.Count - 1
            '    tientinhthue += CDbl(Math.Round(ds.Tables(0).Rows(j).Item("thanhtien")))
            'Next
            'TT = Math.Round(TT)

            'Dim tongcong As Double
            'tongcong = Math.Round(CDbl(thue + tientinhthue))



            ' ten khachhang
            khKy = rptDocument.ReportDefinition.ReportObjects("txttenkh")
            khKy.Text = dsKh.Tables(0).Rows(0).Item("customersign").ToString

            ThutruongKy = rptDocument.ReportDefinition.ReportObjects("txtthutruong")
            ThutruongKy.Text = dsKh.Tables(0).Rows(0).Item("directorsign").ToString


            ' hient thi details
            Dim l As Integer
            Dim thue1 As Double = 0
            Dim t1, t2, t3, t4, t5, t6, t7, t8, t9, t10 As Double
            Dim th1, th2, th3, th4, th5, th6, th7, th8, th9, th10 As Double
            Dim DGUSD1, DGUSD2, DGUSD3, DGUSD4, DGUSD5, DGUSD6, DGUSD7, DGUSD8, DGUSD9, DGUSD10 As Double
            Dim thuept1, thuept2, thuept3, thuept4, thuept5, thuept6, thuept7, thuept8, thuept9, thuept10 As Object
            Dim thuept1_, thuept2_, thuept3_, thuept4_, thuept5_, thuept6_, thuept7_, thuept8_, thuept9_, thuept10_ As Double
            Dim TC1, TC2, TC3, TC4, TC5, TC6, tc7, tc8, tc9, tc10 As Object
            Dim stt1, stt2, stt3, stt4, stt5, stt6, stt7, stt8, stt9, stt10, ten6, ten1, ten2, ten3, ten4, ten5, ten7, ten8, ten9, ten10, dvt1, dvt2, dvt3, dvt4, dvt5, dvt6, dvt7, dvt8, dvt9, dvt10, sl1, sl2, sl3, sl4, sl5, sl6, sl7, sl8, sl9, sl10, dg1, dg2, dg3, dg4, dg5, dg6, dg7, dg8, dg9, dg10, tt1, tt2, tt3, tt4, tt5, tt6, tt7, tt8, tt9, tt10 As Object

            Dim tongDG As Double = 0
            Dim tongVAT As Double = 0
            Dim tongTien As Double = 0
            Dim thue_ As Double = 0
            ' hient thi details


            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1



                    stt1 = rptDocument.ReportDefinition.ReportObjects("txtstt" + (i + 1).ToString)
                    stt1.Text = (i + 1).ToString

                    ten1 = rptDocument.ReportDefinition.ReportObjects("txtten" + (i + 1).ToString)
                    ten1.Text = ds.Tables(0).Rows(i).Item("charge").ToString

                    dvt1 = rptDocument.ReportDefinition.ReportObjects("txtdvt" + (i + 1).ToString)
                    dvt1.Text = UCase(ds.Tables(0).Rows(i).Item("Containertype").ToString)

                    sl1 = rptDocument.ReportDefinition.ReportObjects("txtsl" + (i + 1).ToString)
                    sl1.Text = ds.Tables(0).Rows(i).Item("quantity").ToString

                    dg1 = rptDocument.ReportDefinition.ReportObjects("txtdg" + (i + 1).ToString)
                    ' If UCase(ds.Tables(0).Rows(0).Item("currency").ToString) <> "VND" Then
                    dg1.Text = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 0).Replace(",", ".")
                    'Else
                    '    dg1.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("unitprice").ToString), 0)
                    'End If


                    'If UCase(ds.Tables(0).Rows(0).Item("currency").ToString) <> "VND" Then
                    t1 = (CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString) * CDbl(sl1.text))
                    'Else
                    '    t1 = (CDbl(ds.Tables(0).Rows(0).Item("unitprice").ToString) * CDbl(1) * CDbl(sl1.text))

                    'End If






                    tt1 = rptDocument.ReportDefinition.ReportObjects("txttt" + (i + 1).ToString)
                    tt1.Text = FormatNumber(t1.ToString, 0).Replace(",", ".")
                    tongTien += CDbl(FormatNumber(t1.ToString, 0)) '.Replace(",", "."))
                    '------------------------------
                    'show so bill
                    'ten2 = rptDocument.ReportDefinition.ReportObjects("txtten2")
                    'ten2.text = ds.Tables(0).Rows(0).Item("chungtu").ToString
                    '-----------------------------------------
                Next
            End If

            congtien = rptDocument.ReportDefinition.ReportObjects("txtcongtien")
            congtien.Text = FormatNumber(System.Math.Round(tongTien), 0).Replace(",", ".")

            vattinh = CDbl(dsKh.Tables(0).Rows(0).Item("VAT").ToString)
            thue = System.Math.Round(CDbl((tongTien * vattinh) / 100))

            tienthue = rptDocument.ReportDefinition.ReportObjects("txtthuevat")
            tienthue.Text = FormatNumber(thue, 0, TriState.True).ToString.Replace(",", ".")

            congtienhanghoadichvu = rptDocument.ReportDefinition.ReportObjects("txtTongcongtienthanhtoan")
            congtienhanghoadichvu.Text = FormatNumber(CStr(Math.Round(CDbl(thue + tongTien))).ToString, 0, TriState.True).Replace(",", ".")

            bangchu = rptDocument.ReportDefinition.ReportObjects("txtTienchu")
            bangchu.Text = VNumberToWord(Math.Round(CDbl(thue + tongTien)), "VND")
            ''------
            ' lay so lieu tu Option
            Dim strQuery, value As String
            Dim rs As New ADODB.Recordset
            value = ""
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [option] "
            strQuery = strQuery & "WHERE frmName = 'frmVAT' and OptionCode='STK' And Continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If Not rs.EOF Then
                    value = .Fields("optionvalue").Value
                End If

            End With
            rs.Close()
            ''---------------------------------
            Dim stk As Object
            stk = rptDocument.ReportDefinition.ReportObjects("txtstk")
            stk.Text = value
            '------------------------------------------------------------------------------
            'Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.ReportSource = rptDocument
            ''Formatting paper
            'Dim mymargins = rptDocument.PrintOptions.PageMargins
            'mymargins.topMargin = gTopM
            'mymargins.bottomMargin = gBottomM
            'mymargins.leftMargin = gLeftM
            'mymargins.rightMargin = gRightM
            'rptDocument.PrintOptions.ApplyPageMargins(mymargins)
            'rptDocument.PrintOptions.PaperSize = PaperSize.PaperA4

            'rptDocument.Refresh()
            Me.CrystalReportViewer1.Show()
            'Else

            '    rptDocument.PrintToPrinter(1, False, 0, 0) ' Print command

            'End If












        Catch ex As Exception
            DisplayMessage(True, ex.Message)
        End Try

    End Sub
End Class