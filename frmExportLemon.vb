Imports Excel
Imports System.Data.OleDb
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class frmExportLemon

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


                    '----------lemon
                    Me.DataGridView1.Item("loainghiepvu", currow).Value = "BHTN02"
                    Me.DataGridView1.Item("loaiphieu", currow).Value = ""
                    Try
                        Me.DataGridView1.Item("sophieu", currow).Value = ds.Tables(0).Rows(i).Item("phieuthu").ToString ' them phieuthu
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("ngayphieu", currow).Value = ds.Tables(0).Rows(i).Item("ngayphieuthu").ToString ' them phieuthu
                    Catch ex As Exception

                    End Try
                    ' lay tat ca ten phi
                    Dim id As Integer
                    Dim ten As String
                    For id = 0 To ds.Tables(0).Rows.Count - 1

                        Try
                            Dim sqlcharge As String
                            Dim dscharge As New DataSet
                            If ds.Tables(0).Rows(i).Item("itemid").ToString <> "" Then
                                sqlcharge = "select * from charge where Charge_ID='" & ds.Tables(0).Rows(id).Item("itemid").ToString & "' "
                                dscharge = ReadDataSet(sqlcharge)
                                If dscharge.Tables(0).Rows.Count > 0 Then
                                    ' Me.DataGridView1.Item("mahang", currow).Value = dscharge.Tables(0).Rows(0).Item("charge_code").ToString
                                    ten += dscharge.Tables(0).Rows(0).Item("Charge").ToString + ","
                                    'Try
                                    '    Me.DataGridView1.Item("mahang", currow).Value = dscharge.Tables(0).Rows(i).Item("charge_code").ToString
                                    'Catch ex As Exception

                                    'End Try

                                    'Try
                                    '    Me.DataGridView1.Item("tenhang", currow).Value = dscharge.Tables(0).Rows(i).Item("charge").ToString
                                    'Catch ex As Exception

                                    'End Try


                                    Try
                                        Me.DataGridView1.Item("diengiai", currow).Value = dscharge.Tables(0).Rows(i).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try

                                    'Try
                                    '    Me.DataGridView1.Item("vatdesc", currow).Value = dscharge.Tables(0).Rows(i).Item("charge").ToString
                                    'Catch ex As Exception

                                    'End Try


                                End If
                            End If

                        Catch ex As Exception

                        End Try

                    Next
                    '----------------------------
                    Try
                        Dim sqlcharge As String
                        Dim dscharge As New DataSet
                        If ds.Tables(0).Rows(i).Item("itemid").ToString <> "" Then
                            sqlcharge = "select * from charge where Charge_ID='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "' "
                            dscharge = ReadDataSet(sqlcharge)
                            If dscharge.Tables(0).Rows.Count > 0 Then
                                ' Me.DataGridView1.Item("mahang", currow).Value = dscharge.Tables(0).Rows(0).Item("charge_code").ToString
                                ' ten += dscharge.Tables(0).Rows(0).Item("Charge").ToString + ","
                                Try
                                    Me.DataGridView1.Item("mahang", currow).Value = dscharge.Tables(0).Rows(0).Item("charge_code").ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    Me.DataGridView1.Item("tenhang", currow).Value = dscharge.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("tenhangthueGTGT", currow).Value = dscharge.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try

                                'Try
                                '    Me.DataGridView1.Item("diengiai", currow).Value = dscharge.Tables(0).Rows(i).Item("charge").ToString
                                'Catch ex As Exception

                                'End Try

                                Try
                                    Me.DataGridView1.Item("vatdesc", currow).Value = dscharge.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try


                            End If
                        End If

                    Catch ex As Exception

                    End Try
                   
                    Try
                        Me.DataGridView1.Item("soseri", currow).Value = ds.Tables(0).Rows(i).Item("serialno").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("sohoadon", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ngayhoadon", currow).Value = ngay + "/" + thang + "/" + nam
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ngaydaohan", currow).Value = ngay + "/" + thang + "/" + nam
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("diengiai", currow).Value = ten
                    Catch ex As Exception

                    End Try

                   
                    ten = ""

                    Try
                        Dim sqlcus As String
                        Dim dscus As New DataSet
                        sqlcus = "select * from customer where customer_id ='" & ds.Tables(0).Rows(i).Item("customer_id").ToString & "'"
                        dscus = ReadDataSet(sqlcus)
                        If dscus.Tables(0).Rows.Count > 0 Then
                            ' Me.DataGridView1.Item("makhachhang", currow).Value = dscus.Tables(0).Rows(0).Item("shortName").ToString
                            Me.DataGridView1.Item("tenkhachhang", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString

                            Me.DataGridView1.Item("tendoituong", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString

                            ' Me.DataGridView1.Item("tendoituongthueGTGT", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString

                            Me.DataGridView1.Item("diachiDTthueGTGT", currow).Value = dscus.Tables(0).Rows(0).Item("Address").ToString
                            '  Me.DataGridView1.Item("masothue", currow).Value = dscus.Tables(0).Rows(0).Item("TaxCode").ToString
                            '  Me.DataGridView1.Item("noinhanhang", currow).Value = dscus.Tables(0).Rows(0).Item("Address").ToString
                            ' Me.DataGridView1.Item("madtthue", currow).Value = dscus.Tables(0).Rows(0).Item("shortName").ToString
                            ' Me.DataGridView1.Item("madtdt", currow).Value = dscus.Tables(0).Rows(0).Item("shortName").ToString

                            Try
                                Me.DataGridView1.Item("LoaidoituongGTGT", currow).Value = ""
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("doituongGTGT", currow).Value = dscus.Tables(0).Rows(0).Item("shortName").ToString
                            Catch ex As Exception

                            End Try

                            Try
                                Me.DataGridView1.Item("tendoituongthueGTGT", currow).Value = dscus.Tables(0).Rows(0).Item("EnglishName").ToString
                            Catch ex As Exception

                            End Try

                            Try
                                Me.DataGridView1.Item("masothue", currow).Value = dscus.Tables(0).Rows(0).Item("TaxCode").ToString
                            Catch ex As Exception

                            End Try

                        End If
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("loaidoituong", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("doituong", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("LoaidoituongKHUyThac", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("doituongKHUyThac", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("tenkhachhanguythac", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("daidienhoadon", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try



                    Try
                        Me.DataGridView1.Item("taikhoannganhang", currow).Value = "" ' ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("loaitien", currow).Value = "VND"
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("tygia", currow).Value = "1"
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("nguoilapphieu", currow).Value = "HN02002"
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Nhanvienkinhdoanh", currow).Value = "HN02002"
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("bangGia", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("dieukhoanthuongmai", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("PTthanhtoan", currow).Value = ds.Tables(0).Rows(i).Item("PTTT").ToString
                    Catch ex As Exception

                    End Try

                  
                    Try
                        Me.DataGridView1.Item("PTGiaohang", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("Loaihinhnhapkhau", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    

                    Try
                        Me.DataGridView1.Item("diachikhachhang", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("noiGiaohang", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("diachigiaohang", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ref1", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("ref2", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ref3", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ref4", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("ref5", currow).Value = ""
                    Catch ex As Exception

                    End Try



                   
                    Try
                        Me.DataGridView1.Item("dvt", currow).Value = ds.Tables(0).Rows(i).Item("container_type").ToString
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("soluong", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("soluongQD", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("dongiatruocthue", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitprice").ToString, 0) 'FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("dongia", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitprice").ToString, 0) 'FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    Catch ex As Exception

                    End Try
                    Dim sotien As Double = 0
                    Dim thueGTGT As Double = 0
                    sotien = ds.Tables(0).Rows(i).Item("unitprice").ToString * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString) 'CDbl((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString)

                    thueGTGT = CDbl(ds.Tables(0).Rows(i).Item("pricebantruocthue").ToString) - CDbl(sotien) ' ((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString)) / 100
                    Dim thanhtien As Double = 0
                    Dim lthueGTGT As Double = 0
                    Dim tongTTNT As Double = 0
                    Dim itt As Integer
                    For itt = 0 To ds.Tables(0).Rows.Count - 1
                        'Try
                        thanhtien += CDbl(ds.Tables(0).Rows(itt).Item("pricebantruocthue").ToString) 'FormatNumber(CDbl(FormatNumber((CDbl(ds.Tables(0).Rows(itt).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(itt).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)) * CDbl(ds.Tables(0).Rows(itt).Item("quantity").ToString), 0)



                        lthueGTGT += CDbl(ds.Tables(0).Rows(itt).Item("pricebantruocthue").ToString) - CDbl(ds.Tables(0).Rows(itt).Item("unitprice").ToString) '((CDbl(ds.Tables(0).Rows(itt).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(itt).Item("taxpriceban").ToString) / 100) + 1)).ToString * CDbl(ds.Tables(0).Rows(itt).Item("quantity").ToString) * CDbl(ds.Tables(0).Rows(itt).Item("taxpriceban").ToString)) / 100
                        tongTTNT += thanhtien + lthueGTGT
                        'Catch ex As Exception

                        'End Try
                    Next

                    Try
                        Me.DataGridView1.Item("sotiennguyente", currow).Value = FormatNumber(sotien, 0)
                    Catch ex As Exception
                    End Try

                    Try
                        Me.DataGridView1.Item("sotienquydoi", currow).Value = FormatNumber(sotien, 0)
                    Catch ex As Exception
                    End Try
                    Try
                        Me.DataGridView1.Item("tkno", currow).Value = "1311"
                    Catch ex As Exception
                    End Try

                    Try
                        Me.DataGridView1.Item("tkco", currow).Value = "33311"
                    Catch ex As Exception
                    End Try
                    Try
                        Me.DataGridView1.Item("diengiaichitiet", currow).Value = ten
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("soluongchietkhau", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("soluongchietkhauQD", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("tilechietkhau", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("giamgianguyente", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("giamgiaquydoi", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("tienthueTTDB", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("thueTTDBNT", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("thueTTDBQD", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("TKNoTTDB", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("TKCoTTDB", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("DiengiaithueTTDB", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("nhomThue", currow).Value = "VAT" + ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("ThueGTGTNT", currow).Value = FormatNumber(thueGTGT, 0)
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("ThueGTGTQD", currow).Value = FormatNumber(thueGTGT, 0)
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("TKNoGTGT", currow).Value = ds.Tables(0).Rows(i).Item("tkno").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("TKCoGTGT", currow).Value = ds.Tables(0).Rows(i).Item("tkco").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("DienGiaiThueGTGT", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("DongiaphiDB", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ThuePhiDBNT", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("ThuePhiDBQD", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("TKNoPhiDB", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("TKCoPhiDB", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("DiengiaiPhiDB", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Sothu1", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Sothu2", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Sothu3", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Sothu4", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Sothu5", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Chuoithu1", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Chuoithu2", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Chuoithu3", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Chuoithu4", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Chuoithu5", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Ngaythu1", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Ngaythu2", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("Ngaythu3", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Ngaythu4", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Ngaythu5", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("CotthongKethu1", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("CotthongKethu2", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("CotthongKethu3", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("CotthongKethu4", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("CotthongKethu5", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Khoanmuc1", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc2", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc3", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc4", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("Khoanmuc5", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc6", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc7", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc8", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc9", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Khoanmuc10", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Quycach1", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach2", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Quycach3", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach4", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach5", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach6", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach7", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach8", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach9", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Quycach10", currow).Value = ""
                    Catch ex As Exception

                    End Try



                    Try
                        Me.DataGridView1.Item("LoaidoituongQLCN", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("DoituongQLCN", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("Khodukienxuat", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Tachdoanhthuvathue", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Tachdoanhthuchitiettheomathang", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("CotDc1", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("CotDc2", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("CotDc3", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("CotDc4", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("CotDc5", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Hopdong", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("NgayHopdong", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("TKHQ", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("NgayDangKyToKhai", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("SoHDTM", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Sodonggoi", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Booking", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("COntainerSeal", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("Hangtau", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("vandon", currow).Value = ds.Tables(0).Rows(i).Item("billnumber").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("cangdi", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("cangden", currow).Value = ""
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("ngaydi", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("ngayden", currow).Value = ""
                    Catch ex As Exception

                    End Try


                    Try
                        Me.DataGridView1.Item("motahanghoa", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("motadonggoi", currow).Value = ""
                    Catch ex As Exception

                    End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("nguoitao", currow).Value = "FA02PTT"
                    '' ''Catch ex As Exception

                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("ngaytao", currow).Value = ngay + "/" + thang + "/" + nam
                    '' ''Catch ex As Exception

                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("nguoicapnhatcuoicung", currow).Value = "FA02PTT"
                    '' ''Catch ex As Exception

                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("ngaycapnhatcuoicung", currow).Value = ngay + "/" + thang + "/" + nam
                    '' ''Catch ex As Exception

                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thanhtienNTdieuchinh", currow).Value = FormatNumber(thanhtien, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thanhtienQTdieuchinh", currow).Value = FormatNumber(thanhtien, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thanhtienNTsauCK", currow).Value = FormatNumber(thanhtien, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thanhtienNTsauCK", currow).Value = FormatNumber(thanhtien, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try
                    ' '' ''--- tinh thue GTGT
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thueGTGT", currow).Value = FormatNumber(lthueGTGT, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thueGTGTQD", currow).Value = FormatNumber(lthueGTGT, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tongthanhtoanNT", currow).Value = FormatNumber(tongTTNT, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tongthanhtoanQD", currow).Value = FormatNumber(tongTTNT, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try
                    ' '' '' them chi tiet hang hoa
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("stt", currow).Value = (currow + 1).ToString
                    '' ''Catch ex As Exception
                    '' ''End Try





                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tienhangchitiet", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    '' ''Catch ex As Exception

                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tienhangqdchitiet", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    '' ''Catch ex As Exception

                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thanhtienntsauckchitiet", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    '' ''Catch ex As Exception

                    '' ''End Try


                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thanhtienqdsauckchitiet", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    '' ''Catch ex As Exception

                    '' ''End Try




                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tongthanhtoanntchitiet", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    '' ''Catch ex As Exception

                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tongthanhtoanqdchitiet", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100) + 1)).ToString, 0)
                    '' ''Catch ex As Exception

                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tknodt", currow).Value = ds.Tables(0).Rows(i).Item("tkno").ToString
                    '' ''Catch ex As Exception

                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tkcodt", currow).Value = ds.Tables(0).Rows(i).Item("tkco").ToString
                    '' ''Catch ex As Exception

                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("loaidtdt", currow).Value = "KH"
                    '' ''Catch ex As Exception

                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thueGTGTchitiet", currow).Value = FormatNumber(lthueGTGT, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("thueGTGTqdchitiet", currow).Value = FormatNumber(lthueGTGT, 2)
                    '' ''Catch ex As Exception
                    '' ''End Try


                    '' ''Try
                    '' ''    Me.DataGridView1.Item("nhomthue", currow).Value = "VAT" + ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tile", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("tile", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    '' ''Catch ex As Exception
                    '' ''End Try



                    '' ''Try
                    '' ''    Me.DataGridView1.Item("loaidtthue", currow).Value = "KH"
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("nhang", currow).Value = "0201"
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("masterbill", currow).Value = ds.Tables(0).Rows(i).Item("billnumber").ToString
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("chuyenbt", currow).Value = "1"
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("xuatkho", currow).Value = "0"
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("giaitru", currow).Value = "0"
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("giaitru", currow).Value = "0"
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("khoaphieu", currow).Value = "0"
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("luutam", currow).Value = "0"
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("huy", currow).Value = IIf(ds.Tables(0).Rows(i).Item("huy").ToString = "False", "0", "1")
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("dainhdtc", currow).Value = "1"
                    '' ''Catch ex As Exception
                    '' ''End Try

                    '' ''Try
                    '' ''    Me.DataGridView1.Item("dainhd", currow).Value = "1"
                    '' ''Catch ex As Exception
                    '' ''End Try
                    '' ''Try
                    '' ''    Me.DataGridView1.Item("solaninhd", currow).Value = "1"
                    '' ''Catch ex As Exception
                    '' ''End Try


                    '----------------------------------------
                    'Try
                    '    ' tu itemid trong tacdetail ta lay thong tin phi, ma hang,ten,...
                    '    Try
                    '        Dim sqlcharge As String
                    '        Dim dscharge As New DataSet
                    '        If ds.Tables(0).Rows(i).Item("itemid").ToString <> "" Then
                    '            sqlcharge = "select * from charge where Charge_ID='" & ds.Tables(0).Rows(i).Item("itemid").ToString & "' "
                    '            dscharge = ReadDataSet(sqlcharge)
                    '            If dscharge.Tables(0).Rows.Count > 0 Then
                    '                Me.DataGridView1.Item("mahang", currow).Value = dscharge.Tables(0).Rows(0).Item("charge_code").ToString
                    '                Me.DataGridView1.Item("tenhang", currow).Value = dscharge.Tables(0).Rows(0).Item("Charge").ToString
                    '            End If
                    '        End If

                    '    Catch ex As Exception

                    '    End Try
                    'Catch ex As Exception

                    'End Try
                    'Try

                    'Catch ex As Exception

                    'End Try


                    'Me.DataGridView1.Item("dalaphoadon", currow).Value = 1
                    'Me.DataGridView1.Item("ngayhachtoan", currow).Value = ngay + "/" + thang + "/" + nam
                    'Me.DataGridView1.Item("ngaychungtu", currow).Value = ngay + "/" + thang + "/" + nam
                    'Me.DataGridView1.Item("sochungtu", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    'Me.DataGridView1.Item("sohoadon", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")
                    'Me.DataGridView1.Item("ngayhoadon", currow).Value = ngay + "/" + thang + "/" + nam

                    'Me.DataGridView1.Item("sophieuxuat", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    'Me.DataGridView1.Item("mausohd", currow).Value = "01GTKT3/002" 'ds.Tables(0).Rows(i).Item("serialno").ToString '.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")

                    'Me.DataGridView1.Item("kyhieuhd", currow).Value = ds.Tables(0).Rows(i).Item("serialno").ToString '.Replace("HPH", "").Replace("SGN", "").Replace("HAN", "").Replace("DAD", "")


                    'Me.DataGridView1.Item("diengiai", currow).Value = tenphi
                    'Me.DataGridView1.Item("loaitien", currow).Value = "VND"
                    'Me.DataGridView1.Item("tygia", currow).Value = 1

                    'Me.DataGridView1.Item("TKDoanhthuCo", currow).Value = "5113" 'ds.Tables(0).Rows(i).Item("tkco").ToString
                    'Me.DataGridView1.Item("TKTienChiphiNo", currow).Value = "131" 'ds.Tables(0).Rows(i).Item("tkno").ToString

                    'Me.DataGridView1.Item("dvt", currow).Value = ds.Tables(0).Rows(i).Item("container_type").ToString

                    'Try
                    '    Me.DataGridView1.Item("soluong", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("quantity").ToString, 3)

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    Me.DataGridView1.Item("dongiasauthue", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString * ((ds.Tables(0).Rows(i).Item("taxpriceban").ToString / 100) + 1), 0)

                    'Catch ex As Exception

                    'End Try
                    'Try
                    '    Me.DataGridView1.Item("dongia", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitPrice").ToString, 0)

                    'Catch ex As Exception

                    'End Try
                 




                    'Try
                    '    Me.DataGridView1.Item("thanhtienquydoi", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString), 0)


                    'Catch ex As Exception

                    'End Try

                    'Me.DataGridView1.Item("thueGTGT", currow).Value = ds.Tables(0).Rows(i).Item("taxpriceban").ToString
                    'Try
                    '    Me.DataGridView1.Item("tienthueGTGT", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitPrice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("quantity").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxpriceban").ToString) / 100, 0)

                    'Catch ex As Exception

                    'End Try

                    'Me.DataGridView1.Item("tkthuegtgt", currow).Value = "33311"





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
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel_lemon(Me.DataGridView1, Me)
            'SetMenu(True)
            'Try
            '    Try
            '        Dim app As Application
            '        Try

            '            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}
            '            Dim path As String
            '            app = New Application()
            '            app.Visible = False
            '            Dim dsdata As New DataSet
            '            Dim workbooks As Workbooks
            '            workbooks = app.Workbooks
            '            Dim workbook As _Workbook


            '            path = StartupPath & "\lemon.xls"

            '            workbook = workbooks.Open(path)



            '            Dim sheets As Sheets
            '            sheets = workbook.Worksheets
            '            Dim ws, ws1 As _Worksheet
            '            ws = sheets.Item(1) ' 1 la debit

            '            If ws Is Nothing Then
            '                app.Quit()
            '                Return
            '            End If


            '            Dim DongCongThuc As Integer = 9
            '            Dim DongHienTai As Integer = 2
            '            Dim donghientaiF As Integer = DongHienTai
            '            Dim BillId As String
            '            Dim n As Integer
            '            Dim dem As Integer = 0
            '            Dim BillNo As String = ""
            '            Dim market As String = ""
            '            ' lay ten khach hang
            '            Dim sqlC As String
            '            Dim cus, add, tel, fax, taxcode As String
            '            Dim dsC As New DataSet
            '            Dim j As Integer = 0

            '            Dim tangP As Integer = 9
            '            Dim tang As Integer = 29
            '            Dim ds As New DataSet
            '            Dim sql As String
            '            Dim i As Integer = 0

            '            Dim stt As Integer = 1
            '            Dim TKien, TKg, TKhoi, TKiena, TKga, TKhoia As Double
            '            Dim kien As Double = 0
            '            Dim kg As Double = 0
            '            Dim khoi As Double = 0
            '            Dim hbl As String
            '            '-----------
            '            Dim tongtienDebit As Double = 0
            '            Dim tongtienCredit As Double = 0



            '            Dim dongcong As Integer = 0
            '            If Me.DataGridView1.RowCount > 0 Then
            '                ' hien thi thong tin co ban
            '                For i = 0 To Me.DataGridView1.RowCount - 1
            '                    Try
            '                        ws.Range("a" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("loainghiepvu", i).Value 'ref

            '                        ws.Range("d" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("diengiai", i).Value 'ref

            '                        ws.Range("e" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("soseri", i).Value 'ref

            '                        ws.Range("f" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("sohoadon", i).Value 'ref

            '                        ws.Range("g" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("ngayhoadon", i).Value 'ref


            '                        ws.Range("i" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tenkhachhang", i).Value 'ref

            '                        ws.Range("j" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("makhachhang", i).Value 'ref


            '                        ws.Range("k" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("ptthanhtoan", i).Value 'ref


            '                        ws.Range("l" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("loaitien", i).Value 'ref
            '                        ws.Range("m" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tygia", i).Value 'ref
            '                        ws.Range("o" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nguoilapphieu", i).Value 'ref

            '                        ws.Range("u" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nvkd", i).Value 'ref


            '                        ws.Range("v" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tendoituongthueGTGT", i).Value 'ref

            '                        ws.Range("w" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("diachiDTthueGTGT", i).Value 'ref

            '                        ws.Range("x" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tenhangthueGTGT", i).Value 'ref

            '                        ws.Range("y" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("masothue", i).Value 'ref



            '                        ws.Range("z" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nguoitao", i).Value 'ref


            '                        ws.Range("aa" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("ngaytao", i).Value 'ref




            '                        ws.Range("ab" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nguoicapnhatcuoicung", i).Value 'ref



            '                        ws.Range("ac" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("ngaycapnhatcuoicung", i).Value 'ref


            '                        ws.Range("ad" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienhang", i).Value 'ref
            '                        ws.Range("ae" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienhangqd", i).Value 'ref

            '                        ws.Range("ak" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienntdieuchinh", i).Value 'ref
            '                        ws.Range("al" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienqddieuchinh", i).Value 'ref

            '                        ws.Range("ao" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienntsauck", i).Value 'ref
            '                        ws.Range("ap" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienqdsauck", i).Value 'ref
            '                        ws.Range("as" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thuegtgt", i).Value 'ref
            '                        ws.Range("at" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thuegtgtqd", i).Value 'ref
            '                        ws.Range("aw" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tongthanhtoannt", i).Value 'ref
            '                        ws.Range("ax" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tongthanhtoanqd", i).Value 'ref


            '                        ws.Range("ay" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("noinhanhang", i).Value 'ref


            '                        ws.Range("bw" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("stt", i).Value 'ref

            '                        ws.Range("bx" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("mahang", i).Value 'ref

            '                        ws.Range("by" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tenhang", i).Value 'ref


            '                        ws.Range("bz" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("dvt", i).Value 'ref

            '                        ws.Range("ca" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("soluong", i).Value 'ref

            '                        ws.Range("cb" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("soluongQD", i).Value 'ref
            '                        ws.Range("cc" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dongia", i).Value 'ref

            '                        ws.Range("cd" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dongiatruocthue", i).Value 'ref

            '                        ws.Range("ce" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienhangchitiet", i).Value 'ref
            '                        ws.Range("cf" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienhangqdchitiet", i).Value 'ref

            '                        ws.Range("ci" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienNTsauCKChitiet", i).Value 'ref


            '                        ws.Range("cj" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thanhtienQDsauCKChitiet", i).Value 'ref




            '                        ws.Range("cm" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tongthanhtoanntchitiet", i).Value 'ref
            '                        ws.Range("cn" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tongthanhtoanqdchitiet", i).Value 'ref



            '                        ws.Range("co" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tknodt", i).Value 'ref
            '                        ws.Range("cp" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkcodt", i).Value 'ref

            '                        ws.Range("cq" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("loaidtdt", i).Value 'ref

            '                        ws.Range("cr" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("madtdt", i).Value 'ref
            '                        ws.Range("cu" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nhomthue", i).Value 'ref

            '                        ws.Range("cw" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tknothue", i).Value 'ref

            '                        ws.Range("cx" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkcothue", i).Value 'ref

            '                        ws.Range("cy" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("loaidtthue", i).Value 'ref
            '                        ws.Range("cz" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("madtthue", i).Value 'ref

            '                        ws.Range("df" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("diengiaichitiet", i).Value 'ref

            '                        ws.Range("dl" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("vatdesc", i).Value 'ref
            '                        ws.Range("do" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("nhang", i).Value 'ref
            '                        ws.Range("dr" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("masterbill", i).Value 'ref

            '                        ws.Range("ds" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("housebill", i).Value 'ref
            '                        ws.Range("dx" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("xuatkho", i).Value 'ref

            '                        ws.Range("dw" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("chuyenbt", i).Value 'ref



            '                        ws.Range("dy" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("giaitru", i).Value 'ref

            '                        ws.Range("dz" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("khoaphieu", i).Value 'ref
            '                        ws.Range("ea" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("luutam", i).Value 'ref
            '                        ws.Range("eb" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("huy", i).Value 'ref

            '                        ws.Range("ec" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dainHDTC", i).Value 'ref

            '                        ws.Range("ed" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dainhd", i).Value 'ref

            '                        ws.Range("ee" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("solaninhd", i).Value 'ref


            '                        'ws.Range("am" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tkchietkhau", i).Value 'ref

            '                        'ws.Range("an" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("giatinhthueXK", i).Value 'ref
            '                        'ws.Range("ao" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thueXK", i).Value 'ref

            '                        'ws.Range("ap" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienthuexk", i).Value 'ref
            '                        'ws.Range("aq" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tkthuexk", i).Value 'ref


            '                        'ws.Range("ar" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("thuegtgt", i).Value 'ref


            '                        'ws.Range("as" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienthuegtgt", i).Value 'ref
            '                        'ws.Range("at" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienthuegtgtquydoi", i).Value 'ref

            '                        'ws.Range("au" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tkthuegtgt", i).Value 'ref
            '                        'ws.Range("av" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("hhkhongthtrentokhaithuegtgt", i).Value 'ref


            '                        'ws.Range("aw" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("kho", i).Value 'ref
            '                        'ws.Range("ax" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkgiavon", i).Value 'ref
            '                        'ws.Range("ay" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tkkho", i).Value 'ref
            '                        'ws.Range("az" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("dongiavon", i).Value 'ref
            '                        'ws.Range("ba" + DongHienTai.ToString).Value2 = Me.DataGridView1.Item("tienvon", i).Value 'ref


            '                        dongcong += 1
            '                    Catch ex As Exception

            '                    End Try




            '                    DongHienTai += 1
            '                Next
            '            End If
            '            'Try
            '            '    ws.Range("c5").Value2 = (dongcong - 2).ToString
            '            'Catch ex As Exception

            '            'End Try

            '            ' sum
            '            'ws.Range("u" + (DongHienTai - 1).ToString).Value2 = "from:" + Me.dtpFrom.Value.Date + " to:" + Me.dtpto.Value.Date
            '            'ws.Range("v" + (DongHienTai - 1).ToString).Value2 = "Total"
            '            'ws.Range("w" + (DongHienTai - 1).ToString).Value2 = FormatNumber(tongtienDebit, 2)
            '            'ws.Range("x" + (DongHienTai - 1).ToString).Value2 = ""
            '            ' ws.Range("x2:x" & (DongHienTai - 1).ToString).Columns.WrapText = 1
            '            ' ke khung
            '            'ws.Range("A1:o" & (DongHienTai - 1).ToString).Columns.Borders.Value = 1


            '            'ws.Range("m4:m" & (DongHienTai - 1).ToString).Columns.WrapText = 1
            '            ' ke khung

            '            '----------------------------------------------
            '            '------------------------------
            '            Dim format1 As String
            '            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\Lemon-" + "_" & Now.Second & ".xlsx"

            '            workbook.SaveAs(path, 51, , , , , XlSaveAsAccessMode.xlExclusive, , , , )
            '            DisplayMessage(True, "File name : " & path & " saved.")
            '            '----------
            '            'Dim xlApp As New Excel.Application
            '            'Dim xlWorkBook As Excel.Workbook
            '            'Dim xlWorkSheet As Excel.Worksheet
            '            ''~~> Save As file
            '            'xlWorkBook.SaveAs(Filename:="C:\SampleNew.xlsx", FileFormat:=51,, , , )

            '            ''~~> Close the file
            '            'xlWorkBook.Close()
            '            '--------------------------------------------------------

            '        Catch ex As Exception
            '            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            '            MsgBox(Err.Description)
            '            Return
            '        Finally
            '            app.Quit()
            '        End Try
            '    Catch ex As Exception

            '    End Try
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Try
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            'ExportExecel_lemon(Me.DataGridView1, Me)
            'SetMenu(True)
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


                        path = StartupPath & "\lemon-cus.xls"

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



                        Dim dongcong As Integer = 0
                        If Me.DataGridView1.RowCount > 0 Then
                            ' hien thi thong tin co ban
                            For i = 0 To Me.DataGridView1.RowCount - 1
                                Try
                                   

                                    ws.Range("e" + DongHienTai.ToString).Value2 = "'KH"

                               


                                    ws.Range("g" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("tendoituongthueGTGT", i).Value 'ref

                                    ws.Range("f" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("doituonggtgt", i).Value 'ref




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
                        path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\Lemon-Cus-" + "_" & Now.Second & ".xlsx"

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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            Try
                If Me.DataGridView1.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                'ExportExecel_lemon(Me.DataGridView1, Me)
                'SetMenu(True)
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


                            path = StartupPath & "\lemon-Bill.xls"

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



                            Dim dongcong As Integer = 0
                            If Me.DataGridView1.RowCount > 0 Then
                                ' hien thi thong tin co ban
                                For i = 0 To Me.DataGridView1.RowCount - 1
                                    Try


                                        ws.Range("a" + DongHienTai.ToString).Value2 = "'MasterBill"




                                        ws.Range("b" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("vandon", i).Value 'ref

                                        ws.Range("d" + DongHienTai.ToString).Value2 = "'" + Me.DataGridView1.Item("vandon", i).Value 'ref




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
                            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\SMF\Lemon-bill-" + "_" & Now.Second & ".xlsx"

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
        Catch ex As Exception

        End Try
    End Sub
End Class