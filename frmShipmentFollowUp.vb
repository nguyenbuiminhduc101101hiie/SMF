Public Class frmShipmentFollowUp

    Private Sub chkoutbound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkoutbound.CheckedChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkinbound_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkinbound.CheckedChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkLogistics_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkLogistics.CheckedChanged
        Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub iol()
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -65281
            Dim i As Integer
            Me.DataGridView1.Rows.Clear()
            If UCase(Me.cboChinhanh.Text) = "ALL" Then
                If Me.chkoutbound.Checked = True Then
                    sql = "select * from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                End If
                If Me.chkinbound.Checked = True Then
                    sql = "select * from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                End If
                If Me.chkLogistics.Checked = True Then
                    sql = "select * from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                End If
            End If
            If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                If Me.chkoutbound.Checked = True Then
                    sql = "select * from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '%" & Me.cboChinhanh.Text & "%'"
                End If
                If Me.chkinbound.Checked = True Then
                    sql = "select * from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                End If
                If Me.chkLogistics.Checked = True Then
                    sql = "select * from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                End If
            End If


            ds = ReadDataSet(sql)
            If Me.chkoutbound.Checked = True Then ' hang xuat
                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        mau -= 100
                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                        Me.DataGridView1.Item("Column1", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                        Me.DataGridView1.Item("Column2", currow).Value = ds.Tables(0).Rows(i).Item("bl_type").ToString
                        Try
                            Me.DataGridView1.Item("Column3", currow).Value = ds.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))(0)
                        Catch ex As Exception

                        End Try
                        ' lay thong tin shipper
                        Dim sqlShipper As String
                        Dim dsShipper As New DataSet
                        If ds.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                            'sqlShipper = "select * from customer where company like N'%" & ds.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                            'dsShipper = ReadDataSet(sqlShipper)
                            'If dsShipper.Tables(0).Rows.Count > 0 Then
                            '    Me.DataGridView1.Item("Column4", currow).Value = dsShipper.Tables(0).Rows(0).Item("company").ToString
                            '    Me.DataGridView1.Item("Column5", currow).Value = dsShipper.Tables(0).Rows(0).Item("address").ToString
                            '    Me.DataGridView1.Item("Column6", currow).Value = dsShipper.Tables(0).Rows(0).Item("tel").ToString
                            '    Me.DataGridView1.Item("Column7", currow).Value = dsShipper.Tables(0).Rows(0).Item("fax").ToString



                            'Else
                            Dim s() As String
                            s = ds.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                            Try
                                Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column6", currow).Value = s(3)
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column7", currow).Value = s(4)
                            Catch ex As Exception

                            End Try

                            ' End If
                        End If
                        Me.DataGridView1.Item("Column8", currow).Value = ds.Tables(0).Rows(i).Item("mblcarrier").ToString & "/" & ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        'ta co so mblmawb, ta lay thong so container
                        Dim j As Integer
                        Dim sqlCont As String = ""
                        Dim dsCont As New DataSet
                        '---
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""

                        sqlCont = "select * from containertype where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            For j = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(j).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(j).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(j).Item("type").ToString
                            Next
                        End If
                        ' them vao excel
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                        Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                        Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                        Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                        Me.DataGridView1.Item("Column13", currow).Value = cont
                        '---------------------------------------------------

                        'truong hop hang xuat
                        Me.DataGridView1.Item("Column15", currow).Value = ds.Tables(0).Rows(i).Item("importCy").ToString
                        Me.DataGridView1.Item("Column16", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString
                        Me.DataGridView1.Item("Column17", currow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString

                        Me.DataGridView1.Item("Column19", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString
                        Me.DataGridView1.Item("Column20", currow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                        Me.DataGridView1.Item("Column21", currow).Value = ds.Tables(0).Rows(i).Item("description").ToString
                        ' ngay tau di den
                        Try
                            Me.DataGridView1.Item("Column22", currow).Value = CDate(ds.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(ds.Tables(0).Rows(i).Item("eta").ToString).Date

                        Catch ex As Exception

                        End Try
                        '--- phi da thu
                        Dim sqlPhi As String = ""
                        Dim dsphi As New DataSet
                        Dim k As Integer
                        Dim tenphi As String = ""

                        sqlPhi = "select * from outboundfreight left join charge on outboundfreight.itemid =charge.charge_id  where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "' and debitcredit='Debit' "
                        dsphi = ReadDataSet(sqlPhi)
                        If dsphi.Tables(0).Rows.Count > 0 Then
                            For k = 0 To dsphi.Tables(0).Rows.Count - 1
                                tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                            Next
                        End If
                        Me.DataGridView1.Item("Column23", currow).Value = tenphi
                        '-------------------------------------------
                        '--- nguoi thanh toan
                        Dim sqlcusdebit As String = ""
                        Dim dscusdebit As New DataSet
                        Dim l As Integer
                        Dim tencusdebit As String = ""
                        Dim hoadon As String = ""
                        Dim tongsotienvnd As Double = 0

                        Dim tencuscredit As String = ""

                        Dim tongsotienvndcredit As Double = 0
                        Dim sotienthucthuVND As Double = 0
                        Dim ngaythucthu As String = ""
                        '-------
                        Dim sotienthucchiVND As Double = 0
                        Dim ngaythucchi As String = ""
                        Dim sophieuchi As String = ""
                        ' Dim ngayhoadon As String = ""
                        sqlcusdebit = "select * from outboundfreight left join customer on outboundfreight.customerid =customer.customer_id  where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                        dscusdebit = ReadDataSet(sqlcusdebit)
                        If dscusdebit.Tables(0).Rows.Count > 0 Then
                            For k = 0 To dscusdebit.Tables(0).Rows.Count - 1
                                If dscusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                    tencusdebit += dscusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                    hoadon += dscusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                    Try
                                        tongsotienvnd += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                    Catch ex As Exception

                                    End Try
                                    If dscusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                        Try
                                            sotienthucthuVND += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try

                                        ngaythucthu += dscusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                    End If

                                End If
                                If dscusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                    tencuscredit += dscusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                    Try
                                        tongsotienvndcredit += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                    Catch ex As Exception

                                    End Try
                                    If dscusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                        Try
                                            sotienthucchiVND += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try

                                        ngaythucchi += dscusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                    End If
                                End If

                            Next
                        End If

                        '-------------------------------------------
                        Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                        Me.DataGridView1.Item("Column25", currow).Value = hoadon
                        Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                        Me.DataGridView1.Item("Column27", currow).Value = "VND"
                        '----
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlThucthu As String = ""
                        Dim dsthucthu As New DataSet
                        Dim n As Integer

                        'sqlThucthu = " select * from phieuthu where billno='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                        'dsthucthu = ReadDataSet(sqlThucthu)
                        'If dsthucthu.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dsthucthu.Tables(0).Rows.Count - 1
                        '        Try
                        '            sotienthucthuVND += CDbl(dsthucthu.Tables(0).Rows(n).Item("sotien").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '        Try

                        '            ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '    Next
                        'End If
                        '---
                        Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                        Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                        '-----------
                        ' ngay hoa don
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlhoadon As String = ""
                        Dim dshoadon As New DataSet
                        Dim m As Integer

                        'Dim ngayhoadon As String = ""
                        'sqlhoadon = " select * from taxinvoice where billnumber='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                        'dshoadon = ReadDataSet(sqlhoadon)
                        'If dshoadon.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dshoadon.Tables(0).Rows.Count - 1
                        '        Try
                        '            ngayhoadon += CDbl(dshoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                        ''---
                        'Me.DataGridView1.Item("Column30", currow).Value = ngayhoadon.Replace("12:00:00 AM", "")
                        ' lay trong phan theo doi lo hang
                        Dim sqltheodoi As String = ""
                        Dim dstheodoi As New DataSet
                        Dim o As Integer

                        sqltheodoi = "select * from theodoilohang where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                        dstheodoi = ReadDataSet(sqltheodoi)
                        If dstheodoi.Tables(0).Rows.Count > 0 Then
                            For o = 0 To dstheodoi.Tables(0).Rows.Count - 1
                                'ung voi gia tri ta tim lan luot trong theo doi
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                    Me.DataGridView1.Item("Column31", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                    Me.DataGridView1.Item("Column32", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                    Me.DataGridView1.Item("Column33", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                    Me.DataGridView1.Item("Column34", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                    Me.DataGridView1.Item("Column35", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                    Me.DataGridView1.Item("Column36", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                    Me.DataGridView1.Item("Column44", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                            Next
                        End If
                        '-----------
                        ' tinh loi nhuan
                        ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                        Dim sqltongthuchi As String
                        Dim dstongthuchi As New DataSet
                        Dim tongthu As Double = 0
                        Dim tongchi As Double = 0
                        Dim tenphichi As String = ""

                        Dim r As Integer

                        sqltongthuchi = "select * from outboundfreight left join charge on outboundfreight.itemid=charge.charge_id where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                        dstongthuchi = ReadDataSet(sqltongthuchi)
                        If dstongthuchi.Tables(0).Rows.Count > 0 Then
                            For r = 0 To dstongthuchi.Tables(0).Rows.Count - 1
                                If dstongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                    Try
                                        tongthu += dstongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dstongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                    Catch ex As Exception

                                    End Try
                                End If

                                If dstongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                    Try
                                        tongchi += dstongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dstongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                    Catch ex As Exception

                                    End Try
                                    ' ten khach hang
                                    tenphichi += dstongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                End If


                            Next
                        End If
                        '-------------------------
                        Try
                            Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                        Catch ex As Exception

                        End Try

                        ' phhai tra cho
                        Dim sqlcuscredit As String
                        Dim dscuscredit As New DataSet
                        Dim ten As String = ""
                        Dim g As Integer

                        sqlcuscredit = "select * from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                        dscuscredit = ReadDataSet(sqlcuscredit)
                        If dscuscredit.Tables(0).Rows.Count > 0 Then
                            For r = 0 To dscuscredit.Tables(0).Rows.Count - 1


                                If dscuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                    ten += dscuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                    ' ten khach hang

                                End If
                            Next
                        End If
                        '-------------------------
                        Try
                            Me.DataGridView1.Item("Column39", currow).Value = ten
                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                        Catch ex As Exception

                        End Try
                        ' lay pjieu chi tu house bill
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlThucchi As String = ""
                        Dim dsthucchi As New DataSet
                        Dim nc As Integer

                        'sqlThucchi = " select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                        'dsthucchi = ReadDataSet(sqlThucchi)
                        'If dsthucchi.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dsthucchi.Tables(0).Rows.Count - 1
                        '        Try
                        '            sotienthucchiVND += CDbl(dsthucchi.Tables(0).Rows(n).Item("sotien").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '        Try

                        '            ngaythucchi += dsthucchi.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '        Try
                        '            sophieuchi += dsthucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                        Try
                            Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                            Me.DataGridView1.Item("Column43", currow).Value = "VND"
                            Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                            Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                            Try
                                Me.DataGridView1.Item("Column61", currow).Value = ds.Tables(0).Rows(i).Item("userupdate").ToString
                            Catch ex As Exception

                            End Try

                        Catch ex As Exception

                        End Try

                        '---
                        '----------------------------------

                    Next
                End If
            End If
            '' hang nhap
            If Me.chkinbound.Checked = True Then ' hang xuat
                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        mau -= 100
                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                        Me.DataGridView1.Item("Column1", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                        Me.DataGridView1.Item("Column2", currow).Value = ds.Tables(0).Rows(i).Item("bl_type").ToString
                        Try
                            Me.DataGridView1.Item("Column3", currow).Value = ds.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))(0)
                        Catch ex As Exception

                        End Try
                        ' lay thong tin shipper
                        Dim sqlShipper As String
                        Dim dsShipper As New DataSet
                        If ds.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                            'sqlShipper = "select * from customer where company like N'%" & ds.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                            'dsShipper = ReadDataSet(sqlShipper)
                            'If dsShipper.Tables(0).Rows.Count > 0 Then
                            '    Me.DataGridView1.Item("Column4", currow).Value = dsShipper.Tables(0).Rows(0).Item("company").ToString
                            '    Me.DataGridView1.Item("Column5", currow).Value = dsShipper.Tables(0).Rows(0).Item("address").ToString
                            '    Me.DataGridView1.Item("Column6", currow).Value = dsShipper.Tables(0).Rows(0).Item("tel").ToString
                            '    Me.DataGridView1.Item("Column7", currow).Value = dsShipper.Tables(0).Rows(0).Item("fax").ToString



                            'Else
                            Dim s() As String
                            s = ds.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                            Try
                                Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column6", currow).Value = s(3)
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column7", currow).Value = s(4)
                            Catch ex As Exception

                            End Try
                            '
                            ' End If
                        End If
                        Try
                            Me.DataGridView1.Item("Column8", currow).Value = ds.Tables(0).Rows(i).Item("mbl").ToString & "/" & ds.Tables(0).Rows(i).Item("hbl").ToString

                        Catch ex As Exception

                        End Try
                        'ta co so mblmawb, ta lay thong so container
                        Dim j As Integer
                        Dim sqlCont As String = ""
                        Dim dsCont As New DataSet
                        '---
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""

                        sqlCont = "select * from containerREPAIR where INboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            For j = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(j).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(j).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(j).Item("type").ToString
                            Next
                        End If
                        ' them vao excel
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                        Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                        Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                        Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                        Me.DataGridView1.Item("Column13", currow).Value = cont
                        '---------------------------------------------------

                        'truong hop hang xuat
                        ' nhap kho 14, xuat kho 15

                        'Me.DataGridView1.Item("Column15", currow).Value = ds.Tables(0).Rows(i).Item("importCy").ToString
                        Me.DataGridView1.Item("Column16", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString
                        Me.DataGridView1.Item("Column17", currow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString

                        Me.DataGridView1.Item("Column19", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString
                        Me.DataGridView1.Item("Column20", currow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                        Me.DataGridView1.Item("Column21", currow).Value = ds.Tables(0).Rows(i).Item("description").ToString
                        ' ngay tau di den
                        Try
                            Me.DataGridView1.Item("Column22", currow).Value = CDate(ds.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(ds.Tables(0).Rows(i).Item("eta").ToString).Date

                        Catch ex As Exception

                        End Try
                        '--- phi da thu
                        Dim sqlPhi As String = ""
                        Dim dsphi As New DataSet
                        Dim k As Integer
                        Dim tenphi As String = ""

                        sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "' and debitcredit='Debit' "
                        dsphi = ReadDataSet(sqlPhi)
                        If dsphi.Tables(0).Rows.Count > 0 Then
                            For k = 0 To dsphi.Tables(0).Rows.Count - 1
                                tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                            Next
                        End If
                        Me.DataGridView1.Item("Column23", currow).Value = tenphi
                        '-------------------------------------------
                        '--- nguoi thanh toan
                        Dim sqlcusdebit As String = ""
                        Dim dscusdebit As New DataSet
                        Dim l As Integer
                        Dim tencusdebit As String = ""
                        Dim hoadon As String = ""
                        Dim tongsotienvnd As Double = 0

                        Dim tencuscredit As String = ""

                        Dim tongsotienvndcredit As Double = 0
                        Dim sotienthucthuVND As Double = 0
                        Dim ngaythucthu As String = ""
                        Dim sotienthucchiVND As Double = 0
                        Dim ngaythucchi As String = ""
                        Dim sophieuchi As String = ""
                        Dim ngayhoadon As String = ""
                        sqlcusdebit = "select * from inboundfreight left join customer on inboundfreight.customerid =customer.customer_id  where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                        dscusdebit = ReadDataSet(sqlcusdebit)
                        If dscusdebit.Tables(0).Rows.Count > 0 Then
                            For k = 0 To dscusdebit.Tables(0).Rows.Count - 1
                                If dscusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                    tencusdebit += dscusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                    hoadon += dscusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                    Try
                                        tongsotienvnd += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                    Catch ex As Exception

                                    End Try
                                    If dscusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                        Try
                                            sotienthucthuVND += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try

                                        ngaythucthu += dscusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                    End If
                                End If

                                If dscusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                    tencuscredit += dscusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                    Try
                                        tongsotienvndcredit += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                    Catch ex As Exception

                                    End Try
                                    If dscusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                        Try
                                            sotienthucchiVND += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try

                                        ngaythucchi += dscusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                    End If
                                End If

                            Next
                        End If

                        '-------------------------------------------
                        Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                        Me.DataGridView1.Item("Column25", currow).Value = hoadon
                        Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                        Me.DataGridView1.Item("Column27", currow).Value = "VND"
                        '----
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlThucthu As String = ""
                        Dim dsthucthu As New DataSet
                        Dim n As Integer

                        'sqlThucthu = " select * from phieuthu where billno='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "' "
                        'dsthucthu = ReadDataSet(sqlThucthu)
                        'If dsthucthu.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dsthucthu.Tables(0).Rows.Count - 1
                        '        Try
                        '            sotienthucthuVND += CDbl(dsthucthu.Tables(0).Rows(n).Item("sotien").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '        Try

                        '            ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '    Next
                        'End If
                        '---
                        Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                        Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                        '-----------
                        ' ngay hoa don
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlhoadon As String = ""
                        Dim dshoadon As New DataSet
                        Dim m As Integer

                        'sqlhoadon = " select * from taxinvoice where billnumber='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "' "
                        'dshoadon = ReadDataSet(sqlhoadon)
                        'If dshoadon.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dshoadon.Tables(0).Rows.Count - 1
                        '        Try
                        '            ngayhoadon += CDbl(dshoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                        '---
                        Me.DataGridView1.Item("Column30", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                        ' lay trong phan theo doi lo hang
                        Dim sqltheodoi As String = ""
                        Dim dstheodoi As New DataSet
                        Dim o As Integer

                        sqltheodoi = "select * from theodoilohanginbound where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                        dstheodoi = ReadDataSet(sqltheodoi)
                        If dstheodoi.Tables(0).Rows.Count > 0 Then
                            For o = 0 To dstheodoi.Tables(0).Rows.Count - 1
                                'ung voi gia tri ta tim lan luot trong theo doi
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                    Me.DataGridView1.Item("Column31", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                    Me.DataGridView1.Item("Column32", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                    Me.DataGridView1.Item("Column33", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                    Me.DataGridView1.Item("Column34", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                    Me.DataGridView1.Item("Column35", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                    Me.DataGridView1.Item("Column36", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                    Me.DataGridView1.Item("Column44", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NHAP KHO" Then
                                    Me.DataGridView1.Item("Column14", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "XUAT KHO" Then
                                    Me.DataGridView1.Item("Column15", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                            Next
                        End If
                        '-----------
                        ' tinh loi nhuan
                        ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                        Dim sqltongthuchi As String
                        Dim dstongthuchi As New DataSet
                        Dim tongthu As Double = 0
                        Dim tongchi As Double = 0
                        Dim tenphichi As String = ""

                        Dim r As Integer

                        sqltongthuchi = "select * from inboundfreight left join charge on inboundfreight.itemid=charge.charge_id where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                        dstongthuchi = ReadDataSet(sqltongthuchi)
                        If dstongthuchi.Tables(0).Rows.Count > 0 Then
                            For r = 0 To dstongthuchi.Tables(0).Rows.Count - 1
                                If dstongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                    Try
                                        tongthu += dstongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dstongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                    Catch ex As Exception

                                    End Try
                                End If

                                If dstongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                    Try
                                        tongchi += dstongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dstongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                    Catch ex As Exception

                                    End Try
                                    ' ten khach hang
                                    tenphichi += dstongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                End If


                            Next
                        End If
                        '-------------------------
                        Try
                            Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                        Catch ex As Exception

                        End Try

                        ' phhai tra cho
                        Dim sqlcuscredit As String
                        Dim dscuscredit As New DataSet
                        Dim ten As String = ""
                        Dim g As Integer

                        sqlcuscredit = "select * from inboundfreight left join customer on inboundfreight.customerid=customer.customer_id where inboundid='" & ds.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                        dscuscredit = ReadDataSet(sqlcuscredit)
                        If dscuscredit.Tables(0).Rows.Count > 0 Then
                            For r = 0 To dscuscredit.Tables(0).Rows.Count - 1


                                If dscuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                    ten += dscuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                    ' ten khach hang

                                End If
                            Next
                        End If
                        '-------------------------
                        Try
                            Me.DataGridView1.Item("Column39", currow).Value = ten
                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                        Catch ex As Exception

                        End Try
                        ' lay pjieu chi tu house bill
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlThucchi As String = ""
                        Dim dsthucchi As New DataSet
                        Dim nc As Integer

                        'sqlThucchi = " select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "' "
                        'dsthucchi = ReadDataSet(sqlThucchi)
                        'If dsthucchi.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dsthucchi.Tables(0).Rows.Count - 1
                        '        Try
                        '            sotienthucchiVND += CDbl(dsthucchi.Tables(0).Rows(n).Item("sotien").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '        Try

                        '            ngaythucchi += dsthucchi.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '        Try
                        '            sophieuchi += dsthucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                        Try
                            Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                        Catch ex As Exception

                        End Try
                        Try
                            'Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(sotienthucchiVND, 0)
                            'Me.DataGridView1.Item("Column43", currow).Value = "VND"
                            'Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi


                            Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                            Me.DataGridView1.Item("Column43", currow).Value = "VND"
                            Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                            Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                            Try
                                Me.DataGridView1.Item("Column61", currow).Value = ds.Tables(0).Rows(i).Item("userupdate").ToString
                            Catch ex As Exception

                            End Try
                        Catch ex As Exception

                        End Try

                        '---
                        '----------------------------------

                    Next
                End If
            End If
            '--------------------------------------------------------------------------------------------------------------------
            ' logistics
            If Me.chkLogistics.Checked = True Then ' logistics
                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        mau -= 100
                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                        Me.DataGridView1.Item("Column1", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                        Me.DataGridView1.Item("Column2", currow).Value = ds.Tables(0).Rows(i).Item("bl_type").ToString
                        Try
                            Me.DataGridView1.Item("Column3", currow).Value = ds.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))(0)
                        Catch ex As Exception

                        End Try
                        ' lay thong tin shipper
                        Dim sqlShipper As String
                        Dim dsShipper As New DataSet
                        If ds.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                            'sqlShipper = "select * from customer where company like N'%" & ds.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                            'dsShipper = ReadDataSet(sqlShipper)
                            'If dsShipper.Tables(0).Rows.Count > 0 Then
                            '    Me.DataGridView1.Item("Column4", currow).Value = dsShipper.Tables(0).Rows(0).Item("company").ToString
                            '    Me.DataGridView1.Item("Column5", currow).Value = dsShipper.Tables(0).Rows(0).Item("address").ToString
                            '    Me.DataGridView1.Item("Column6", currow).Value = dsShipper.Tables(0).Rows(0).Item("tel").ToString
                            '    Me.DataGridView1.Item("Column7", currow).Value = dsShipper.Tables(0).Rows(0).Item("fax").ToString



                            'Else
                            Dim s() As String
                            s = ds.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                            Try
                                Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column6", currow).Value = s(3)
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column7", currow).Value = s(4)
                            Catch ex As Exception

                            End Try

                            ' End If
                        End If
                        Me.DataGridView1.Item("Column8", currow).Value = ds.Tables(0).Rows(i).Item("mblcarrier").ToString & "/" & ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        'ta co so mblmawb, ta lay thong so container
                        Dim j As Integer
                        Dim sqlCont As String = ""
                        Dim dsCont As New DataSet
                        '---
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""

                        sqlCont = "select * from containerlogistics where outboundid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            For j = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(j).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(j).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(j).Item("type").ToString
                            Next
                        End If
                        ' them vao excel
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                        Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                        Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                        Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                        Me.DataGridView1.Item("Column13", currow).Value = cont
                        '---------------------------------------------------

                        'truong hop hang xuat
                        Me.DataGridView1.Item("Column15", currow).Value = ds.Tables(0).Rows(i).Item("importCy").ToString
                        Me.DataGridView1.Item("Column16", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString
                        Me.DataGridView1.Item("Column17", currow).Value = ds.Tables(0).Rows(i).Item("agencyname").ToString

                        Me.DataGridView1.Item("Column19", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString
                        Me.DataGridView1.Item("Column20", currow).Value = ds.Tables(0).Rows(i).Item("voyage").ToString
                        Me.DataGridView1.Item("Column21", currow).Value = ds.Tables(0).Rows(i).Item("description").ToString
                        ' ngay tau di den
                        Try
                            Me.DataGridView1.Item("Column22", currow).Value = CDate(ds.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(ds.Tables(0).Rows(i).Item("eta").ToString).Date

                        Catch ex As Exception

                        End Try
                        '--- phi da thu
                        Dim sqlPhi As String = ""
                        Dim dsphi As New DataSet
                        Dim k As Integer
                        Dim tenphi As String = ""

                        sqlPhi = "select * from logisticsfreight left join charge on logisticsfreight.itemid =charge.charge_id  where logisticsid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "' and debitcredit='Debit' "
                        dsphi = ReadDataSet(sqlPhi)
                        If dsphi.Tables(0).Rows.Count > 0 Then
                            For k = 0 To dsphi.Tables(0).Rows.Count - 1
                                tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                            Next
                        End If
                        Me.DataGridView1.Item("Column23", currow).Value = tenphi
                        '-------------------------------------------
                        '--- nguoi thanh toan
                        Dim sqlcusdebit As String = ""
                        Dim dscusdebit As New DataSet
                        Dim l As Integer
                        Dim tencusdebit As String = ""
                        Dim hoadon As String = ""
                        Dim tongsotienvnd As Double = 0

                        Dim tencuscredit As String = ""

                        Dim tongsotienvndcredit As Double = 0
                        Dim sotienthucthuVND As Double = 0
                        Dim ngaythucthu As String = ""

                        Dim sotienthucchiVND As Double = 0
                        Dim ngaythucchi As String = ""
                        Dim sophieuchi As String = ""
                        sqlcusdebit = "select * from logisticsfreight left join customer on logisticsfreight.customerid =customer.customer_id  where logisticsid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                        dscusdebit = ReadDataSet(sqlcusdebit)
                        If dscusdebit.Tables(0).Rows.Count > 0 Then
                            For k = 0 To dscusdebit.Tables(0).Rows.Count - 1
                                If dscusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                    tencusdebit += dscusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                    hoadon += dscusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                    Try
                                        tongsotienvnd += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                    Catch ex As Exception

                                    End Try
                                    If dscusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                        Try
                                            sotienthucthuVND += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try

                                        ngaythucthu += dscusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                    End If

                                End If
                                If dscusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                    tencuscredit += dscusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                    Try
                                        tongsotienvndcredit += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                    Catch ex As Exception

                                    End Try
                                    If dscusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                        Try
                                            sotienthucchiVND += CDbl(dscusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try

                                        ngaythucchi += dscusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                    End If
                                End If

                            Next
                        End If

                        '-------------------------------------------
                        Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                        Me.DataGridView1.Item("Column25", currow).Value = hoadon
                        Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                        Me.DataGridView1.Item("Column27", currow).Value = "VND"
                        '----
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlThucthu As String = ""
                        Dim dsthucthu As New DataSet
                        Dim n As Integer

                        'sqlThucthu = " select * from phieuthu where billno='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                        'dsthucthu = ReadDataSet(sqlThucthu)
                        'If dsthucthu.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dsthucthu.Tables(0).Rows.Count - 1
                        '        Try
                        '            sotienthucthuVND += CDbl(dsthucthu.Tables(0).Rows(n).Item("sotien").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '        Try

                        '            ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '    Next
                        'End If
                        '---
                        Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                        Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                        '-----------
                        ' ngay hoa don
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlhoadon As String = ""
                        Dim dshoadon As New DataSet
                        Dim m As Integer

                        'Dim ngayhoadon As String = ""
                        'sqlhoadon = " select * from taxinvoice where billnumber='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                        'dshoadon = ReadDataSet(sqlhoadon)
                        'If dshoadon.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dshoadon.Tables(0).Rows.Count - 1
                        '        Try
                        '            ngayhoadon += CDbl(dshoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                        ''---
                        'Me.DataGridView1.Item("Column30", currow).Value = ngayhoadon.Replace("12:00:00 AM", "")
                        ' lay trong phan theo doi lo hang
                        Dim sqltheodoi As String = ""
                        Dim dstheodoi As New DataSet
                        Dim o As Integer

                        sqltheodoi = "select * from theodoilohanglogistics where logisticsid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                        dstheodoi = ReadDataSet(sqltheodoi)
                        If dstheodoi.Tables(0).Rows.Count > 0 Then
                            For o = 0 To dstheodoi.Tables(0).Rows.Count - 1
                                'ung voi gia tri ta tim lan luot trong theo doi
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                    Me.DataGridView1.Item("Column31", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                    Me.DataGridView1.Item("Column32", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                    Me.DataGridView1.Item("Column33", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                    Me.DataGridView1.Item("Column34", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                    Me.DataGridView1.Item("Column35", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                    Me.DataGridView1.Item("Column36", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If
                                If UCase(dstheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                    Me.DataGridView1.Item("Column44", currow).Value = dstheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                End If

                            Next
                        End If
                        '-----------
                        ' tinh loi nhuan
                        ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                        Dim sqltongthuchi As String
                        Dim dstongthuchi As New DataSet
                        Dim tongthu As Double = 0
                        Dim tongchi As Double = 0
                        Dim tenphichi As String = ""

                        Dim r As Integer

                        sqltongthuchi = "select * from logisticsfreight left join charge on logisticsfreight.itemid=charge.charge_id where logisticsid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                        dstongthuchi = ReadDataSet(sqltongthuchi)
                        If dstongthuchi.Tables(0).Rows.Count > 0 Then
                            For r = 0 To dstongthuchi.Tables(0).Rows.Count - 1
                                If dstongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                    Try
                                        tongthu += dstongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dstongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                    Catch ex As Exception

                                    End Try
                                End If

                                If dstongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                    Try
                                        tongchi += dstongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dstongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                    Catch ex As Exception

                                    End Try
                                    ' ten khach hang
                                    tenphichi += dstongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                End If


                            Next
                        End If
                        '-------------------------
                        Try
                            Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                        Catch ex As Exception

                        End Try

                        ' phhai tra cho
                        Dim sqlcuscredit As String
                        Dim dscuscredit As New DataSet
                        Dim ten As String = ""
                        Dim g As Integer

                        sqlcuscredit = "select * from logisticsfreight left join customer on logisticsfreight.customerid=customer.customer_id where logisticsid='" & ds.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                        dscuscredit = ReadDataSet(sqlcuscredit)
                        If dscuscredit.Tables(0).Rows.Count > 0 Then
                            For r = 0 To dscuscredit.Tables(0).Rows.Count - 1


                                If dscuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                    ten += dscuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                    ' ten khach hang

                                End If
                            Next
                        End If
                        '-------------------------
                        Try
                            Me.DataGridView1.Item("Column39", currow).Value = ten
                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                        Catch ex As Exception

                        End Try
                        ' lay pjieu chi tu house bill
                        ' ngay thuc thu, ket noi voi phieu thu = so house bill
                        Dim sqlThucchi As String = ""
                        Dim dsthucchi As New DataSet
                        Dim nc As Integer

                        'sqlThucchi = " select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                        'dsthucchi = ReadDataSet(sqlThucchi)
                        'If dsthucchi.Tables(0).Rows.Count > 0 Then
                        '    For n = 0 To dsthucchi.Tables(0).Rows.Count - 1
                        '        Try
                        '            sotienthucchiVND += CDbl(dsthucchi.Tables(0).Rows(n).Item("sotien").ToString)
                        '            ' ngaythucthu += dsthucthu.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try
                        '        Try

                        '            ngaythucchi += dsthucchi.Tables(0).Rows(n).Item("ngay").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '        Try
                        '            sophieuchi += dsthucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                        Try
                            Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                        Catch ex As Exception

                        End Try
                        Try
                            Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                            Me.DataGridView1.Item("Column43", currow).Value = "VND"
                            Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                            Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                            Try
                                Me.DataGridView1.Item("Column61", currow).Value = ds.Tables(0).Rows(i).Item("userupdate").ToString
                            Catch ex As Exception

                            End Try

                        Catch ex As Exception

                        End Try

                        '---
                        '----------------------------------

                    Next
                End If
            End If
            InsertAutoNumberToGrid(Me.DataGridView1)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub all()
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                Dim currow As Integer
                Dim mau As Integer = -65281
                Dim i As Integer
                Dim sqli, sqlo, sqll As String
                Dim dsi As New DataSet
                Dim dso As New DataSet
                Dim dsl As New DataSet

                Me.DataGridView1.Rows.Clear()
                If UCase(Me.cboChinhanh.Text) = "ALL" Then
                    'If Me.chkoutbound.Checked = True Then
                    sqlo = "select * from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select * from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    'End If
                    'If Me.chkLogistics.Checked = True Then
                    sqll = "select * from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    'End If
                End If
                If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                    ' If Me.chkoutbound.Checked = True Then
                    sqlo = "select * from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select * from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    'If Me.chkLogistics.Checked = True Then
                    sqll = "select * from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                End If


                dso = ReadDataSet(sqlo)
                dsi = ReadDataSet(sqli)
                dsl = ReadDataSet(sqll)

                If Me.chkall.Checked = True Then ' hang xuat
                    If dso.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dso.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                            Me.DataGridView1.Item("Column1", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                            Me.DataGridView1.Item("Column2", currow).Value = dso.Tables(0).Rows(i).Item("bl_type").ToString
                            Try
                                Me.DataGridView1.Item("Column3", currow).Value = dso.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))(0)
                            Catch ex As Exception

                            End Try

                            ' lay thong tin shipper
                            Dim sqlShipper As String
                            Dim dsoShipper As New DataSet
                            If dso.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                                'sqlShipper = "select * from customer where company like N'%" & dso.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                                'dsoShipper = ReadDataSet(sqlShipper)
                                'If dsoShipper.Tables(0).Rows.Count > 0 Then
                                '    Me.DataGridView1.Item("Column4", currow).Value = dsoShipper.Tables(0).Rows(0).Item("company").ToString
                                '    Me.DataGridView1.Item("Column5", currow).Value = dsoShipper.Tables(0).Rows(0).Item("address").ToString
                                '    Me.DataGridView1.Item("Column6", currow).Value = dsoShipper.Tables(0).Rows(0).Item("tel").ToString
                                '    Me.DataGridView1.Item("Column7", currow).Value = dsoShipper.Tables(0).Rows(0).Item("fax").ToString



                                'Else
                                Dim s() As String
                                s = dso.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                                Try
                                    Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column6", currow).Value = s(3)
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column7", currow).Value = s(4)
                                Catch ex As Exception

                                End Try

                                'End If
                            End If
                            Me.DataGridView1.Item("Column8", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString & "/" & dso.Tables(0).Rows(i).Item("mblmawb").ToString
                            'ta co so mblmawb, ta lay thong so container
                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsoCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""

                            sqlCont = "select * from containertype where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsoCont = ReadDataSet(sqlCont)
                            If dsoCont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dsoCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dsoCont.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dsoCont.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dsoCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        cont += dsoCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsoCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsoCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                    Catch ex As Exception

                                    End Try
                                    type = dsoCont.Tables(0).Rows(j).Item("type").ToString
                                Next
                            End If
                            ' them vao excel
                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                            Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                            Me.DataGridView1.Item("Column13", currow).Value = cont
                            '---------------------------------------------------

                            'truong hop hang xuat
                            Me.DataGridView1.Item("Column15", currow).Value = dso.Tables(0).Rows(i).Item("importCy").ToString
                            Me.DataGridView1.Item("Column16", currow).Value = dso.Tables(0).Rows(i).Item("shippingline").ToString
                            Me.DataGridView1.Item("Column17", currow).Value = dso.Tables(0).Rows(i).Item("agencyname").ToString

                            Me.DataGridView1.Item("Column19", currow).Value = dso.Tables(0).Rows(i).Item("vessel").ToString
                            Me.DataGridView1.Item("Column20", currow).Value = dso.Tables(0).Rows(i).Item("voyage").ToString
                            Me.DataGridView1.Item("Column21", currow).Value = dso.Tables(0).Rows(i).Item("description").ToString
                            ' ngay tau di den
                            Try
                                Me.DataGridView1.Item("Column22", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(dso.Tables(0).Rows(i).Item("eta").ToString).Date

                            Catch ex As Exception

                            End Try
                            '--- phi da thu
                            Dim sqlPhi As String = ""
                            Dim dsophi As New DataSet
                            Dim k As Integer
                            Dim tenphi As String = ""

                            sqlPhi = "select * from outboundfreight left join charge on outboundfreight.itemid =charge.charge_id  where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "' and debitcredit='Debit' "
                            dsophi = ReadDataSet(sqlPhi)
                            If dsophi.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsophi.Tables(0).Rows.Count - 1
                                    tenphi += dsophi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                Next
                            End If
                            Me.DataGridView1.Item("Column23", currow).Value = tenphi
                            '-------------------------------------------
                            '--- nguoi thanh toan
                            Dim sqlcusdebit As String = ""
                            Dim dsocusdebit As New DataSet
                            Dim l As Integer
                            Dim tencusdebit As String = ""
                            Dim hoadon As String = ""
                            Dim tongsotienvnd As Double = 0

                            Dim tencuscredit As String = ""

                            Dim tongsotienvndcredit As Double = 0
                            Dim sotienthucthuVND As Double = 0
                            Dim ngaythucthu As String = ""
                            '-------
                            Dim sotienthucchiVND As Double = 0
                            Dim ngaythucchi As String = ""
                            Dim sophieuchi As String = ""
                            ' Dim ngayhoadon As String = ""
                            sqlcusdebit = "select * from outboundfreight left join customer on outboundfreight.customerid =customer.customer_id  where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsocusdebit = ReadDataSet(sqlcusdebit)
                            If dsocusdebit.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsocusdebit.Tables(0).Rows.Count - 1
                                    If dsocusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                        tencusdebit += dsocusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                        hoadon += dsocusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                        Try
                                            tongsotienvnd += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsocusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucthuVND += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucthu += dsocusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If

                                    End If
                                    If dsocusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                        tencuscredit += dsocusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                        Try
                                            tongsotienvndcredit += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsocusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucchiVND += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucchi += dsocusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                Next
                            End If

                            '-------------------------------------------
                            Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                            Me.DataGridView1.Item("Column25", currow).Value = hoadon
                            Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                            Me.DataGridView1.Item("Column27", currow).Value = "VND"
                            '----
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucthu As String = ""
                            Dim dsothucthu As New DataSet
                            Dim n As Integer

                            'sqlThucthu = " select * from phieuthu where billno='" & dso.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                            'dsothucthu = ReadDataSet(sqlThucthu)
                            'If dsothucthu.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsothucthu.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucthuVND += CDbl(dsothucthu.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                            '-----------
                            ' ngay hoa don
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlhoadon As String = ""
                            Dim dsohoadon As New DataSet
                            Dim m As Integer

                            'Dim ngayhoadon As String = ""
                            'sqlhoadon = " select * from taxinvoice where billnumber='" & dso.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                            'dsohoadon = ReadDataSet(sqlhoadon)
                            'If dsohoadon.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsohoadon.Tables(0).Rows.Count - 1
                            '        Try
                            '            ngayhoadon += CDbl(dsohoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                            '            ' ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            ''---
                            'Me.DataGridView1.Item("Column30", currow).Value = ngayhoadon.Replace("12:00:00 AM", "")
                            ' lay trong phan theo doi lo hang
                            Dim sqltheodoi As String = ""
                            Dim dsotheodoi As New DataSet
                            Dim o As Integer

                            sqltheodoi = "select * from theodoilohang where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsotheodoi = ReadDataSet(sqltheodoi)
                            If dsotheodoi.Tables(0).Rows.Count > 0 Then
                                For o = 0 To dsotheodoi.Tables(0).Rows.Count - 1
                                    'ung voi gia tri ta tim lan luot trong theo doi
                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                        Me.DataGridView1.Item("Column31", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                        Me.DataGridView1.Item("Column32", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                        Me.DataGridView1.Item("Column33", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                        Me.DataGridView1.Item("Column34", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                        Me.DataGridView1.Item("Column35", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                        Me.DataGridView1.Item("Column36", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                        Me.DataGridView1.Item("Column44", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                Next
                            End If
                            '-----------
                            ' tinh loi nhuan
                            ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                            Dim sqltongthuchi As String
                            Dim dsotongthuchi As New DataSet
                            Dim tongthu As Double = 0
                            Dim tongchi As Double = 0
                            Dim tenphichi As String = ""

                            Dim r As Integer

                            sqltongthuchi = "select * from outboundfreight left join charge on outboundfreight.itemid=charge.charge_id where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dsotongthuchi = ReadDataSet(sqltongthuchi)
                            If dsotongthuchi.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsotongthuchi.Tables(0).Rows.Count - 1
                                    If dsotongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                        Try
                                            tongthu += dsotongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsotongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If dsotongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        Try
                                            tongchi += dsotongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsotongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                        ' ten khach hang
                                        tenphichi += dsotongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                    End If


                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                            Catch ex As Exception

                            End Try

                            ' phhai tra cho
                            Dim sqlcuscredit As String
                            Dim dsocuscredit As New DataSet
                            Dim ten As String = ""
                            Dim g As Integer

                            sqlcuscredit = "select * from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dsocuscredit = ReadDataSet(sqlcuscredit)
                            If dsocuscredit.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsocuscredit.Tables(0).Rows.Count - 1


                                    If dsocuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        ten += dsocuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                        ' ten khach hang

                                    End If
                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column39", currow).Value = ten
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                            Catch ex As Exception

                            End Try
                            ' lay pjieu chi tu house bill
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucchi As String = ""
                            Dim dsothucchi As New DataSet
                            Dim nc As Integer

                            'sqlThucchi = " select * from phieuchi where billno='" & dso.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                            'dsothucchi = ReadDataSet(sqlThucchi)
                            'If dsothucchi.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsothucchi.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucchiVND += CDbl(dsothucchi.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucchi += dsothucchi.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '        Try
                            '            sophieuchi += dsothucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            Try
                                Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                                Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                                Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                Try
                                    Me.DataGridView1.Item("Column61", currow).Value = dso.Tables(0).Rows(i).Item("userupdate").ToString
                                Catch ex As Exception

                                End Try

                            Catch ex As Exception

                            End Try

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                '' hang nhap
                If Me.chkall.Checked = True Then ' hang nhap
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dsi.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                            Me.DataGridView1.Item("Column1", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                            Me.DataGridView1.Item("Column2", currow).Value = dsi.Tables(0).Rows(i).Item("bl_type").ToString
                            Try
                                Me.DataGridView1.Item("Column3", currow).Value = dsi.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))(0)
                            Catch ex As Exception

                            End Try
                            ' lay thong tin shipper
                            Dim sqlShipper As String
                            Dim dsiShipper As New DataSet
                            If dsi.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                                'sqlShipper = "select * from customer where company like N'%" & dsi.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                                'dsiShipper = ReadDataSet(sqlShipper)
                                'If dsiShipper.Tables(0).Rows.Count > 0 Then
                                '    Me.DataGridView1.Item("Column4", currow).Value = dsiShipper.Tables(0).Rows(0).Item("company").ToString
                                '    Me.DataGridView1.Item("Column5", currow).Value = dsiShipper.Tables(0).Rows(0).Item("address").ToString
                                '    Me.DataGridView1.Item("Column6", currow).Value = dsiShipper.Tables(0).Rows(0).Item("tel").ToString
                                '    Me.DataGridView1.Item("Column7", currow).Value = dsiShipper.Tables(0).Rows(0).Item("fax").ToString



                                'Else
                                Dim s() As String
                                s = dsi.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                                Try
                                    Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column6", currow).Value = s(3)
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column7", currow).Value = s(4)
                                Catch ex As Exception

                                End Try

                                ' End If
                            End If
                            Try
                                Me.DataGridView1.Item("Column8", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString & "/" & dsi.Tables(0).Rows(i).Item("hbl").ToString

                            Catch ex As Exception

                            End Try
                            'ta co so mblmawb, ta lay thong so container
                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsiCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""

                            sqlCont = "select * from containerREPAIR where INboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                            dsiCont = ReadDataSet(sqlCont)
                            If dsiCont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dsiCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dsiCont.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dsiCont.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dsiCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        cont += dsiCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsiCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsiCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                    Catch ex As Exception

                                    End Try
                                    type = dsiCont.Tables(0).Rows(j).Item("type").ToString
                                Next
                            End If
                            ' them vao excel
                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                            Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                            Me.DataGridView1.Item("Column13", currow).Value = cont
                            '---------------------------------------------------

                            'truong hop hang xuat
                            ' nhap kho 14, xuat kho 15

                            'Me.DataGridView1.Item("Column15", currow).Value = dsi.Tables(0).Rows(i).Item("importCy").ToString
                            Me.DataGridView1.Item("Column16", currow).Value = dsi.Tables(0).Rows(i).Item("shippingline").ToString
                            Me.DataGridView1.Item("Column17", currow).Value = dsi.Tables(0).Rows(i).Item("agencyname").ToString

                            Me.DataGridView1.Item("Column19", currow).Value = dsi.Tables(0).Rows(i).Item("vessel").ToString
                            Me.DataGridView1.Item("Column20", currow).Value = dsi.Tables(0).Rows(i).Item("voyage").ToString
                            Me.DataGridView1.Item("Column21", currow).Value = dsi.Tables(0).Rows(i).Item("description").ToString
                            ' ngay tau di den
                            Try
                                Me.DataGridView1.Item("Column22", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(dsi.Tables(0).Rows(i).Item("eta").ToString).Date

                            Catch ex As Exception

                            End Try
                            '--- phi da thu
                            Dim sqlPhi As String = ""
                            Dim dsiphi As New DataSet
                            Dim k As Integer
                            Dim tenphi As String = ""

                            sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "' and debitcredit='Debit' "
                            dsiphi = ReadDataSet(sqlPhi)
                            If dsiphi.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsiphi.Tables(0).Rows.Count - 1
                                    tenphi += dsiphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                Next
                            End If
                            Me.DataGridView1.Item("Column23", currow).Value = tenphi
                            '-------------------------------------------
                            '--- nguoi thanh toan
                            Dim sqlcusdebit As String = ""
                            Dim dsicusdebit As New DataSet
                            Dim l As Integer
                            Dim tencusdebit As String = ""
                            Dim hoadon As String = ""
                            Dim tongsotienvnd As Double = 0

                            Dim tencuscredit As String = ""

                            Dim tongsotienvndcredit As Double = 0
                            Dim sotienthucthuVND As Double = 0
                            Dim ngaythucthu As String = ""
                            Dim sotienthucchiVND As Double = 0
                            Dim ngaythucchi As String = ""
                            Dim sophieuchi As String = ""
                            Dim ngayhoadon As String = ""
                            sqlcusdebit = "select * from inboundfreight left join customer on inboundfreight.customerid =customer.customer_id  where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                            dsicusdebit = ReadDataSet(sqlcusdebit)
                            If dsicusdebit.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsicusdebit.Tables(0).Rows.Count - 1
                                    If dsicusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                        tencusdebit += dsicusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                        hoadon += dsicusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                        Try
                                            tongsotienvnd += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsicusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucthuVND += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucthu += dsicusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                    If dsicusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                        tencuscredit += dsicusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                        Try
                                            tongsotienvndcredit += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsicusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucchiVND += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucchi += dsicusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                Next
                            End If

                            '-------------------------------------------
                            Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                            Me.DataGridView1.Item("Column25", currow).Value = hoadon
                            Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                            Me.DataGridView1.Item("Column27", currow).Value = "VND"
                            '----
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucthu As String = ""
                            Dim dsithucthu As New DataSet
                            Dim n As Integer

                            'sqlThucthu = " select * from phieuthu where billno='" & dsi.Tables(0).Rows(i).Item("hbl").ToString & "' "
                            'dsithucthu = ReadDataSet(sqlThucthu)
                            'If dsithucthu.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsithucthu.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucthuVND += CDbl(dsithucthu.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                            '-----------
                            ' ngay hoa don
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlhoadon As String = ""
                            Dim dsihoadon As New DataSet
                            Dim m As Integer

                            'sqlhoadon = " select * from taxinvoice where billnumber='" & dsi.Tables(0).Rows(i).Item("hbl").ToString & "' "
                            'dsihoadon = ReadDataSet(sqlhoadon)
                            'If dsihoadon.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsihoadon.Tables(0).Rows.Count - 1
                            '        Try
                            '            ngayhoadon += CDbl(dsihoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                            '            ' ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column30", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            ' lay trong phan theo doi lo hang
                            Dim sqltheodoi As String = ""
                            Dim dsitheodoi As New DataSet
                            Dim o As Integer

                            sqltheodoi = "select * from theodoilohanginbound where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                            dsitheodoi = ReadDataSet(sqltheodoi)
                            If dsitheodoi.Tables(0).Rows.Count > 0 Then
                                For o = 0 To dsitheodoi.Tables(0).Rows.Count - 1
                                    'ung voi gia tri ta tim lan luot trong theo doi
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                        Me.DataGridView1.Item("Column31", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                        Me.DataGridView1.Item("Column32", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                        Me.DataGridView1.Item("Column33", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                        Me.DataGridView1.Item("Column34", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                        Me.DataGridView1.Item("Column35", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                        Me.DataGridView1.Item("Column36", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                        Me.DataGridView1.Item("Column44", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NHAP KHO" Then
                                        Me.DataGridView1.Item("Column14", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "XUAT KHO" Then
                                        Me.DataGridView1.Item("Column15", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                Next
                            End If
                            '-----------
                            ' tinh loi nhuan
                            ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                            Dim sqltongthuchi As String
                            Dim dsitongthuchi As New DataSet
                            Dim tongthu As Double = 0
                            Dim tongchi As Double = 0
                            Dim tenphichi As String = ""

                            Dim r As Integer

                            sqltongthuchi = "select * from inboundfreight left join charge on inboundfreight.itemid=charge.charge_id where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                            dsitongthuchi = ReadDataSet(sqltongthuchi)
                            If dsitongthuchi.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsitongthuchi.Tables(0).Rows.Count - 1
                                    If dsitongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                        Try
                                            tongthu += dsitongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsitongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If dsitongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        Try
                                            tongchi += dsitongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsitongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                        ' ten khach hang
                                        tenphichi += dsitongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                    End If


                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                            Catch ex As Exception

                            End Try

                            ' phhai tra cho
                            Dim sqlcuscredit As String
                            Dim dsicuscredit As New DataSet
                            Dim ten As String = ""
                            Dim g As Integer

                            sqlcuscredit = "select * from inboundfreight left join customer on inboundfreight.customerid=customer.customer_id where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                            dsicuscredit = ReadDataSet(sqlcuscredit)
                            If dsicuscredit.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsicuscredit.Tables(0).Rows.Count - 1


                                    If dsicuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        ten += dsicuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                        ' ten khach hang

                                    End If
                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column39", currow).Value = ten
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                            Catch ex As Exception

                            End Try
                            ' lay pjieu chi tu house bill
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucchi As String = ""
                            Dim dsithucchi As New DataSet
                            Dim nc As Integer

                            'sqlThucchi = " select * from phieuchi where billno='" & dsi.Tables(0).Rows(i).Item("hbl").ToString & "' "
                            'dsithucchi = ReadDataSet(sqlThucchi)
                            'If dsithucchi.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsithucchi.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucchiVND += CDbl(dsithucchi.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucchi += dsithucchi.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '        Try
                            '            sophieuchi += dsithucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            Try
                                Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                            Catch ex As Exception

                            End Try
                            Try
                                'Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                'Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                'Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi


                                Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                                Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                                Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                Try
                                    Me.DataGridView1.Item("Column61", currow).Value = dsi.Tables(0).Rows(i).Item("userupdate").ToString
                                Catch ex As Exception

                                End Try
                            Catch ex As Exception

                            End Try

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                '--------------------------------------------------------------------------------------------------------------------
                ' logistics
                If Me.chkall.Checked = True Then ' logistics
                    If dsl.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dsl.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                            Me.DataGridView1.Item("Column1", currow).Value = dsl.Tables(0).Rows(i).Item("ref").ToString
                            Me.DataGridView1.Item("Column2", currow).Value = dsl.Tables(0).Rows(i).Item("bl_type").ToString
                            Try
                                Me.DataGridView1.Item("Column3", currow).Value = dsl.Tables(0).Rows(i).Item("consignee").ToString.Split(Chr(13))(0)
                            Catch ex As Exception

                            End Try
                            ' lay thong tin shipper
                            Dim sqlShipper As String
                            Dim dslShipper As New DataSet
                            If dsl.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                                'sqlShipper = "select * from customer where company like N'%" & dsl.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                                'dslShipper = ReadDataSet(sqlShipper)
                                'If dslShipper.Tables(0).Rows.Count > 0 Then
                                '    Me.DataGridView1.Item("Column4", currow).Value = dslShipper.Tables(0).Rows(0).Item("company").ToString
                                '    Me.DataGridView1.Item("Column5", currow).Value = dslShipper.Tables(0).Rows(0).Item("address").ToString
                                '    Me.DataGridView1.Item("Column6", currow).Value = dslShipper.Tables(0).Rows(0).Item("tel").ToString
                                '    Me.DataGridView1.Item("Column7", currow).Value = dslShipper.Tables(0).Rows(0).Item("fax").ToString



                                'Else
                                Dim s() As String
                                s = dsl.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                                Try
                                    Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column6", currow).Value = s(3)
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("Column7", currow).Value = s(4)
                                Catch ex As Exception

                                End Try

                                '   End If
                            End If
                            Me.DataGridView1.Item("Column8", currow).Value = dsl.Tables(0).Rows(i).Item("mblcarrier").ToString & "/" & dsl.Tables(0).Rows(i).Item("mblmawb").ToString
                            'ta co so mblmawb, ta lay thong so container
                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dslCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""

                            sqlCont = "select * from containerlogistics where outboundid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dslCont = ReadDataSet(sqlCont)
                            If dslCont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dslCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dslCont.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dslCont.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dslCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        cont += dslCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dslCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dslCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                    Catch ex As Exception

                                    End Try
                                    type = dslCont.Tables(0).Rows(j).Item("type").ToString
                                Next
                            End If
                            ' them vao excel
                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                            Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                            Me.DataGridView1.Item("Column13", currow).Value = cont
                            '---------------------------------------------------

                            'truong hop hang xuat
                            Me.DataGridView1.Item("Column15", currow).Value = dsl.Tables(0).Rows(i).Item("importCy").ToString
                            Me.DataGridView1.Item("Column16", currow).Value = dsl.Tables(0).Rows(i).Item("shippingline").ToString
                            Me.DataGridView1.Item("Column17", currow).Value = dsl.Tables(0).Rows(i).Item("agencyname").ToString

                            Me.DataGridView1.Item("Column19", currow).Value = dsl.Tables(0).Rows(i).Item("vessel").ToString
                            Me.DataGridView1.Item("Column20", currow).Value = dsl.Tables(0).Rows(i).Item("voyage").ToString
                            Me.DataGridView1.Item("Column21", currow).Value = dsl.Tables(0).Rows(i).Item("description").ToString
                            ' ngay tau di den
                            Try
                                Me.DataGridView1.Item("Column22", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(dsl.Tables(0).Rows(i).Item("eta").ToString).Date

                            Catch ex As Exception

                            End Try
                            '--- phi da thu
                            Dim sqlPhi As String = ""
                            Dim dslphi As New DataSet
                            Dim k As Integer
                            Dim tenphi As String = ""

                            sqlPhi = "select * from logisticsfreight left join charge on logisticsfreight.itemid =charge.charge_id  where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "' and debitcredit='Debit' "
                            dslphi = ReadDataSet(sqlPhi)
                            If dslphi.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dslphi.Tables(0).Rows.Count - 1
                                    tenphi += dslphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                Next
                            End If
                            Me.DataGridView1.Item("Column23", currow).Value = tenphi
                            '-------------------------------------------
                            '--- nguoi thanh toan
                            Dim sqlcusdebit As String = ""
                            Dim dslcusdebit As New DataSet
                            Dim l As Integer
                            Dim tencusdebit As String = ""
                            Dim hoadon As String = ""
                            Dim tongsotienvnd As Double = 0

                            Dim tencuscredit As String = ""

                            Dim tongsotienvndcredit As Double = 0
                            Dim sotienthucthuVND As Double = 0
                            Dim ngaythucthu As String = ""

                            Dim sotienthucchiVND As Double = 0
                            Dim ngaythucchi As String = ""
                            Dim sophieuchi As String = ""
                            sqlcusdebit = "select * from logisticsfreight left join customer on logisticsfreight.customerid =customer.customer_id  where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dslcusdebit = ReadDataSet(sqlcusdebit)
                            If dslcusdebit.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dslcusdebit.Tables(0).Rows.Count - 1
                                    If dslcusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                        tencusdebit += dslcusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                        hoadon += dslcusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                        Try
                                            tongsotienvnd += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dslcusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucthuVND += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucthu += dslcusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If

                                    End If
                                    If dslcusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                        tencuscredit += dslcusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                        Try
                                            tongsotienvndcredit += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dslcusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucchiVND += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucchi += dslcusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                Next
                            End If

                            '-------------------------------------------
                            Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                            Me.DataGridView1.Item("Column25", currow).Value = hoadon
                            Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                            Me.DataGridView1.Item("Column27", currow).Value = "VND"
                            '----
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucthu As String = ""
                            Dim dslthucthu As New DataSet
                            Dim n As Integer

                            'sqlThucthu = " select * from phieuthu where billno='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            'dslthucthu = ReadDataSet(sqlThucthu)
                            'If dslthucthu.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dslthucthu.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucthuVND += CDbl(dslthucthu.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                            '-----------
                            ' ngay hoa don
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlhoadon As String = ""
                            Dim dslhoadon As New DataSet
                            Dim m As Integer

                            'Dim ngayhoadon As String = ""
                            'sqlhoadon = " select * from taxinvoice where billnumber='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            'dslhoadon = ReadDataSet(sqlhoadon)
                            'If dslhoadon.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dslhoadon.Tables(0).Rows.Count - 1
                            '        Try
                            '            ngayhoadon += CDbl(dslhoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                            '            ' ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            ''---
                            'Me.DataGridView1.Item("Column30", currow).Value = ngayhoadon.Replace("12:00:00 AM", "")
                            ' lay trong phan theo doi lo hang
                            Dim sqltheodoi As String = ""
                            Dim dsltheodoi As New DataSet
                            Dim o As Integer

                            sqltheodoi = "select * from theodoilohanglogistics where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsltheodoi = ReadDataSet(sqltheodoi)
                            If dsltheodoi.Tables(0).Rows.Count > 0 Then
                                For o = 0 To dsltheodoi.Tables(0).Rows.Count - 1
                                    'ung voi gia tri ta tim lan luot trong theo doi
                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                        Me.DataGridView1.Item("Column31", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                        Me.DataGridView1.Item("Column32", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                        Me.DataGridView1.Item("Column33", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                        Me.DataGridView1.Item("Column34", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                        Me.DataGridView1.Item("Column35", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                        Me.DataGridView1.Item("Column36", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                        Me.DataGridView1.Item("Column44", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                Next
                            End If
                            '-----------
                            ' tinh loi nhuan
                            ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                            Dim sqltongthuchi As String
                            Dim dsltongthuchi As New DataSet
                            Dim tongthu As Double = 0
                            Dim tongchi As Double = 0
                            Dim tenphichi As String = ""

                            Dim r As Integer

                            sqltongthuchi = "select * from logisticsfreight left join charge on logisticsfreight.itemid=charge.charge_id where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dsltongthuchi = ReadDataSet(sqltongthuchi)
                            If dsltongthuchi.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsltongthuchi.Tables(0).Rows.Count - 1
                                    If dsltongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                        Try
                                            tongthu += dsltongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsltongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If dsltongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        Try
                                            tongchi += dsltongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsltongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                        ' ten khach hang
                                        tenphichi += dsltongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                    End If


                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                            Catch ex As Exception

                            End Try

                            ' phhai tra cho
                            Dim sqlcuscredit As String
                            Dim dslcuscredit As New DataSet
                            Dim ten As String = ""
                            Dim g As Integer

                            sqlcuscredit = "select * from logisticsfreight left join customer on logisticsfreight.customerid=customer.customer_id where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dslcuscredit = ReadDataSet(sqlcuscredit)
                            If dslcuscredit.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dslcuscredit.Tables(0).Rows.Count - 1


                                    If dslcuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        ten += dslcuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                        ' ten khach hang

                                    End If
                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column39", currow).Value = ten
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                            Catch ex As Exception

                            End Try
                            ' lay pjieu chi tu house bill
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucchi As String = ""
                            Dim dslthucchi As New DataSet
                            Dim nc As Integer

                            'sqlThucchi = " select * from phieuchi where billno='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            'dslthucchi = ReadDataSet(sqlThucchi)
                            'If dslthucchi.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dslthucchi.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucchiVND += CDbl(dslthucchi.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucchi += dslthucchi.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '        Try
                            '            sophieuchi += dslthucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            Try
                                Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                                Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                                Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                Try
                                    Me.DataGridView1.Item("Column61", currow).Value = dsl.Tables(0).Rows(i).Item("userupdate").ToString
                                Catch ex As Exception

                                End Try

                            Catch ex As Exception

                            End Try

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                InsertAutoNumberToGrid(Me.DataGridView1)

            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
        Catch ex As Exception

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
                If Me.DataGridView1.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                ExportExecel(Me.DataGridView1, Me)
                ' SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.chkall.Checked = True Then
                all()
            Else
                iol()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                Dim currow As Integer
                Dim mau As Integer = -65281
                Dim i As Integer
                Dim sqli, sqlo, sqll As String
                Dim dsi As New DataSet
                Dim dso As New DataSet
                Dim dsl As New DataSet

                Me.DataGridView1.Rows.Clear()
                If UCase(Me.cboChinhanh.Text) = "ALL" Then
                    'If Me.chkoutbound.Checked = True Then
                    sqlo = "select * from outbound where ref like '%" & Me.txtref.Text & "%'  "
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select * from inbound where ref like '%" & Me.txtref.Text & "%' "
                    'End If
                    'If Me.chkLogistics.Checked = True Then
                    sqll = "select * from logistics where ref like '%" & Me.txtref.Text & "%' "
                    'End If
                End If
                If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                    ' If Me.chkoutbound.Checked = True Then
                    sqlo = "select * from outbound where ref like '%" & Me.txtref.Text & "%' and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select * from inbound where ref like '%" & Me.txtref.Text & "%'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    'If Me.chkLogistics.Checked = True Then
                    sqll = "select * from logistics where ref like '%" & Me.txtref.Text & "%' and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                End If


                dso = ReadDataSet(sqlo)
                dsi = ReadDataSet(sqli)
                dsl = ReadDataSet(sqll)

                If Me.chkall.Checked = True Then ' hang xuat
                    If dso.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dso.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                            Me.DataGridView1.Item("Column1", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                            Me.DataGridView1.Item("Column2", currow).Value = dso.Tables(0).Rows(i).Item("bl_type").ToString
                            Me.DataGridView1.Item("Column3", currow).Value = dso.Tables(0).Rows(i).Item("consignee").ToString
                            ' lay thong tin shipper
                            Dim sqlShipper As String
                            Dim dsoShipper As New DataSet
                            If dso.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                                sqlShipper = "select * from customer where company like '%" & dso.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                                dsoShipper = ReadDataSet(sqlShipper)
                                If dsoShipper.Tables(0).Rows.Count > 0 Then
                                    Me.DataGridView1.Item("Column4", currow).Value = dsoShipper.Tables(0).Rows(0).Item("company").ToString
                                    Me.DataGridView1.Item("Column5", currow).Value = dsoShipper.Tables(0).Rows(0).Item("address").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsoShipper.Tables(0).Rows(0).Item("tel").ToString
                                    Me.DataGridView1.Item("Column7", currow).Value = dsoShipper.Tables(0).Rows(0).Item("fax").ToString



                                Else
                                    Dim s() As String
                                    s = dso.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                                    Try
                                        Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column6", currow).Value = s(3)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column7", currow).Value = s(4)
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                            Me.DataGridView1.Item("Column8", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString & "/" & dso.Tables(0).Rows(i).Item("mblmawb").ToString
                            'ta co so mblmawb, ta lay thong so container
                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsoCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""

                            sqlCont = "select * from containertype where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsoCont = ReadDataSet(sqlCont)
                            If dsoCont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dsoCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dsoCont.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dsoCont.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dsoCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        cont += dsoCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsoCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsoCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                    Catch ex As Exception

                                    End Try
                                    type = dsoCont.Tables(0).Rows(j).Item("type").ToString
                                Next
                            End If
                            ' them vao excel
                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                            Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                            Me.DataGridView1.Item("Column13", currow).Value = cont
                            '---------------------------------------------------

                            'truong hop hang xuat
                            Me.DataGridView1.Item("Column15", currow).Value = dso.Tables(0).Rows(i).Item("importCy").ToString
                            Me.DataGridView1.Item("Column16", currow).Value = dso.Tables(0).Rows(i).Item("shippingline").ToString
                            Me.DataGridView1.Item("Column17", currow).Value = dso.Tables(0).Rows(i).Item("agencyname").ToString

                            Me.DataGridView1.Item("Column19", currow).Value = dso.Tables(0).Rows(i).Item("vessel").ToString
                            Me.DataGridView1.Item("Column20", currow).Value = dso.Tables(0).Rows(i).Item("voyage").ToString
                            Me.DataGridView1.Item("Column21", currow).Value = dso.Tables(0).Rows(i).Item("description").ToString
                            ' ngay tau di den
                            Try
                                Me.DataGridView1.Item("Column22", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(dso.Tables(0).Rows(i).Item("eta").ToString).Date

                            Catch ex As Exception

                            End Try
                            '--- phi da thu
                            Dim sqlPhi As String = ""
                            Dim dsophi As New DataSet
                            Dim k As Integer
                            Dim tenphi As String = ""

                            sqlPhi = "select * from outboundfreight left join charge on outboundfreight.itemid =charge.charge_id  where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "' and debitcredit='Debit' "
                            dsophi = ReadDataSet(sqlPhi)
                            If dsophi.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsophi.Tables(0).Rows.Count - 1
                                    tenphi += dsophi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                Next
                            End If
                            Me.DataGridView1.Item("Column23", currow).Value = tenphi
                            '-------------------------------------------
                            '--- nguoi thanh toan
                            Dim sqlcusdebit As String = ""
                            Dim dsocusdebit As New DataSet
                            Dim l As Integer
                            Dim tencusdebit As String = ""
                            Dim hoadon As String = ""
                            Dim tongsotienvnd As Double = 0

                            Dim tencuscredit As String = ""

                            Dim tongsotienvndcredit As Double = 0
                            Dim sotienthucthuVND As Double = 0
                            Dim ngaythucthu As String = ""
                            '-------
                            Dim sotienthucchiVND As Double = 0
                            Dim ngaythucchi As String = ""
                            Dim sophieuchi As String = ""
                            ' Dim ngayhoadon As String = ""
                            sqlcusdebit = "select * from outboundfreight left join customer on outboundfreight.customerid =customer.customer_id  where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsocusdebit = ReadDataSet(sqlcusdebit)
                            If dsocusdebit.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsocusdebit.Tables(0).Rows.Count - 1
                                    If dsocusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                        tencusdebit += dsocusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                        hoadon += dsocusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                        Try
                                            tongsotienvnd += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsocusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucthuVND += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucthu += dsocusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If

                                    End If
                                    If dsocusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                        tencuscredit += dsocusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                        Try
                                            tongsotienvndcredit += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsocusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucchiVND += CDbl(dsocusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucchi += dsocusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                Next
                            End If

                            '-------------------------------------------
                            Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                            Me.DataGridView1.Item("Column25", currow).Value = hoadon
                            Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                            Me.DataGridView1.Item("Column27", currow).Value = "VND"
                            '----
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucthu As String = ""
                            Dim dsothucthu As New DataSet
                            Dim n As Integer

                            'sqlThucthu = " select * from phieuthu where billno='" & dso.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                            'dsothucthu = ReadDataSet(sqlThucthu)
                            'If dsothucthu.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsothucthu.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucthuVND += CDbl(dsothucthu.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                            '-----------
                            ' ngay hoa don
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlhoadon As String = ""
                            Dim dsohoadon As New DataSet
                            Dim m As Integer

                            'Dim ngayhoadon As String = ""
                            'sqlhoadon = " select * from taxinvoice where billnumber='" & dso.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                            'dsohoadon = ReadDataSet(sqlhoadon)
                            'If dsohoadon.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsohoadon.Tables(0).Rows.Count - 1
                            '        Try
                            '            ngayhoadon += CDbl(dsohoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                            '            ' ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            ''---
                            'Me.DataGridView1.Item("Column30", currow).Value = ngayhoadon.Replace("12:00:00 AM", "")
                            ' lay trong phan theo doi lo hang
                            Dim sqltheodoi As String = ""
                            Dim dsotheodoi As New DataSet
                            Dim o As Integer

                            sqltheodoi = "select * from theodoilohang where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsotheodoi = ReadDataSet(sqltheodoi)
                            If dsotheodoi.Tables(0).Rows.Count > 0 Then
                                For o = 0 To dsotheodoi.Tables(0).Rows.Count - 1
                                    'ung voi gia tri ta tim lan luot trong theo doi
                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                        Me.DataGridView1.Item("Column31", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                        Me.DataGridView1.Item("Column32", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                        Me.DataGridView1.Item("Column33", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                        Me.DataGridView1.Item("Column34", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                        Me.DataGridView1.Item("Column35", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                        Me.DataGridView1.Item("Column36", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsotheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                        Me.DataGridView1.Item("Column44", currow).Value = dsotheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                Next
                            End If
                            '-----------
                            ' tinh loi nhuan
                            ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                            Dim sqltongthuchi As String
                            Dim dsotongthuchi As New DataSet
                            Dim tongthu As Double = 0
                            Dim tongchi As Double = 0
                            Dim tenphichi As String = ""

                            Dim r As Integer

                            sqltongthuchi = "select * from outboundfreight left join charge on outboundfreight.itemid=charge.charge_id where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dsotongthuchi = ReadDataSet(sqltongthuchi)
                            If dsotongthuchi.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsotongthuchi.Tables(0).Rows.Count - 1
                                    If dsotongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                        Try
                                            tongthu += dsotongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsotongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If dsotongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        Try
                                            tongchi += dsotongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsotongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                        ' ten khach hang
                                        tenphichi += dsotongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                    End If


                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                            Catch ex As Exception

                            End Try

                            ' phhai tra cho
                            Dim sqlcuscredit As String
                            Dim dsocuscredit As New DataSet
                            Dim ten As String = ""
                            Dim g As Integer

                            sqlcuscredit = "select * from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id where outboundid='" & dso.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dsocuscredit = ReadDataSet(sqlcuscredit)
                            If dsocuscredit.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsocuscredit.Tables(0).Rows.Count - 1


                                    If dsocuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        ten += dsocuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                        ' ten khach hang

                                    End If
                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column39", currow).Value = ten
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                            Catch ex As Exception

                            End Try
                            ' lay pjieu chi tu house bill
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucchi As String = ""
                            Dim dsothucchi As New DataSet
                            Dim nc As Integer

                            'sqlThucchi = " select * from phieuchi where billno='" & dso.Tables(0).Rows(i).Item("mblmawb").ToString & "' "
                            'dsothucchi = ReadDataSet(sqlThucchi)
                            'If dsothucchi.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsothucchi.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucchiVND += CDbl(dsothucchi.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsothucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucchi += dsothucchi.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '        Try
                            '            sophieuchi += dsothucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            Try
                                Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                                Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                                Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                Try
                                    Me.DataGridView1.Item("Column61", currow).Value = dso.Tables(0).Rows(i).Item("userupdate").ToString
                                Catch ex As Exception

                                End Try

                            Catch ex As Exception

                            End Try

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                '' hang nhap
                If Me.chkall.Checked = True Then ' hang nhap
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dsi.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                            Me.DataGridView1.Item("Column1", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                            Me.DataGridView1.Item("Column2", currow).Value = dsi.Tables(0).Rows(i).Item("bl_type").ToString
                            Me.DataGridView1.Item("Column3", currow).Value = dsi.Tables(0).Rows(i).Item("consignee").ToString
                            ' lay thong tin shipper
                            Dim sqlShipper As String
                            Dim dsiShipper As New DataSet
                            If dsi.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                                sqlShipper = "select * from customer where company like '%" & dsi.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                                dsiShipper = ReadDataSet(sqlShipper)
                                If dsiShipper.Tables(0).Rows.Count > 0 Then
                                    Me.DataGridView1.Item("Column4", currow).Value = dsiShipper.Tables(0).Rows(0).Item("company").ToString
                                    Me.DataGridView1.Item("Column5", currow).Value = dsiShipper.Tables(0).Rows(0).Item("address").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsiShipper.Tables(0).Rows(0).Item("tel").ToString
                                    Me.DataGridView1.Item("Column7", currow).Value = dsiShipper.Tables(0).Rows(0).Item("fax").ToString



                                Else
                                    Dim s() As String
                                    s = dsi.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                                    Try
                                        Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column6", currow).Value = s(3)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column7", currow).Value = s(4)
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                            Try
                                Me.DataGridView1.Item("Column8", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString & "/" & dsi.Tables(0).Rows(i).Item("hbl").ToString

                            Catch ex As Exception

                            End Try
                            'ta co so mblmawb, ta lay thong so container
                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsiCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""

                            sqlCont = "select * from containerREPAIR where INboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                            dsiCont = ReadDataSet(sqlCont)
                            If dsiCont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dsiCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dsiCont.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dsiCont.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dsiCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        cont += dsiCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dsiCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dsiCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                    Catch ex As Exception

                                    End Try
                                    type = dsiCont.Tables(0).Rows(j).Item("type").ToString
                                Next
                            End If
                            ' them vao excel
                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                            Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                            Me.DataGridView1.Item("Column13", currow).Value = cont
                            '---------------------------------------------------

                            'truong hop hang xuat
                            ' nhap kho 14, xuat kho 15

                            'Me.DataGridView1.Item("Column15", currow).Value = dsi.Tables(0).Rows(i).Item("importCy").ToString
                            Me.DataGridView1.Item("Column16", currow).Value = dsi.Tables(0).Rows(i).Item("shippingline").ToString
                            Me.DataGridView1.Item("Column17", currow).Value = dsi.Tables(0).Rows(i).Item("agencyname").ToString

                            Me.DataGridView1.Item("Column19", currow).Value = dsi.Tables(0).Rows(i).Item("vessel").ToString
                            Me.DataGridView1.Item("Column20", currow).Value = dsi.Tables(0).Rows(i).Item("voyage").ToString
                            Me.DataGridView1.Item("Column21", currow).Value = dsi.Tables(0).Rows(i).Item("description").ToString
                            ' ngay tau di den
                            Try
                                Me.DataGridView1.Item("Column22", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(dsi.Tables(0).Rows(i).Item("eta").ToString).Date

                            Catch ex As Exception

                            End Try
                            '--- phi da thu
                            Dim sqlPhi As String = ""
                            Dim dsiphi As New DataSet
                            Dim k As Integer
                            Dim tenphi As String = ""

                            sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "' and debitcredit='Debit' "
                            dsiphi = ReadDataSet(sqlPhi)
                            If dsiphi.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsiphi.Tables(0).Rows.Count - 1
                                    tenphi += dsiphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                Next
                            End If
                            Me.DataGridView1.Item("Column23", currow).Value = tenphi
                            '-------------------------------------------
                            '--- nguoi thanh toan
                            Dim sqlcusdebit As String = ""
                            Dim dsicusdebit As New DataSet
                            Dim l As Integer
                            Dim tencusdebit As String = ""
                            Dim hoadon As String = ""
                            Dim tongsotienvnd As Double = 0

                            Dim tencuscredit As String = ""

                            Dim tongsotienvndcredit As Double = 0
                            Dim sotienthucthuVND As Double = 0
                            Dim ngaythucthu As String = ""
                            Dim sotienthucchiVND As Double = 0
                            Dim ngaythucchi As String = ""
                            Dim sophieuchi As String = ""
                            Dim ngayhoadon As String = ""
                            sqlcusdebit = "select * from inboundfreight left join customer on inboundfreight.customerid =customer.customer_id  where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                            dsicusdebit = ReadDataSet(sqlcusdebit)
                            If dsicusdebit.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dsicusdebit.Tables(0).Rows.Count - 1
                                    If dsicusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                        tencusdebit += dsicusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                        hoadon += dsicusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                        Try
                                            tongsotienvnd += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsicusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucthuVND += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucthu += dsicusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                    If dsicusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                        tencuscredit += dsicusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                        Try
                                            tongsotienvndcredit += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dsicusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucchiVND += CDbl(dsicusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucchi += dsicusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                Next
                            End If

                            '-------------------------------------------
                            Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                            Me.DataGridView1.Item("Column25", currow).Value = hoadon
                            Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                            Me.DataGridView1.Item("Column27", currow).Value = "VND"
                            '----
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucthu As String = ""
                            Dim dsithucthu As New DataSet
                            Dim n As Integer

                            'sqlThucthu = " select * from phieuthu where billno='" & dsi.Tables(0).Rows(i).Item("hbl").ToString & "' "
                            'dsithucthu = ReadDataSet(sqlThucthu)
                            'If dsithucthu.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsithucthu.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucthuVND += CDbl(dsithucthu.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                            '-----------
                            ' ngay hoa don
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlhoadon As String = ""
                            Dim dsihoadon As New DataSet
                            Dim m As Integer

                            'sqlhoadon = " select * from taxinvoice where billnumber='" & dsi.Tables(0).Rows(i).Item("hbl").ToString & "' "
                            'dsihoadon = ReadDataSet(sqlhoadon)
                            'If dsihoadon.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsihoadon.Tables(0).Rows.Count - 1
                            '        Try
                            '            ngayhoadon += CDbl(dsihoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                            '            ' ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column30", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            ' lay trong phan theo doi lo hang
                            Dim sqltheodoi As String = ""
                            Dim dsitheodoi As New DataSet
                            Dim o As Integer

                            sqltheodoi = "select * from theodoilohanginbound where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'"
                            dsitheodoi = ReadDataSet(sqltheodoi)
                            If dsitheodoi.Tables(0).Rows.Count > 0 Then
                                For o = 0 To dsitheodoi.Tables(0).Rows.Count - 1
                                    'ung voi gia tri ta tim lan luot trong theo doi
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                        Me.DataGridView1.Item("Column31", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                        Me.DataGridView1.Item("Column32", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                        Me.DataGridView1.Item("Column33", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                        Me.DataGridView1.Item("Column34", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                        Me.DataGridView1.Item("Column35", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                        Me.DataGridView1.Item("Column36", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                        Me.DataGridView1.Item("Column44", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "NHAP KHO" Then
                                        Me.DataGridView1.Item("Column14", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsitheodoi.Tables(0).Rows(o).Item("items").ToString) = "XUAT KHO" Then
                                        Me.DataGridView1.Item("Column15", currow).Value = dsitheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                Next
                            End If
                            '-----------
                            ' tinh loi nhuan
                            ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                            Dim sqltongthuchi As String
                            Dim dsitongthuchi As New DataSet
                            Dim tongthu As Double = 0
                            Dim tongchi As Double = 0
                            Dim tenphichi As String = ""

                            Dim r As Integer

                            sqltongthuchi = "select * from inboundfreight left join charge on inboundfreight.itemid=charge.charge_id where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                            dsitongthuchi = ReadDataSet(sqltongthuchi)
                            If dsitongthuchi.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsitongthuchi.Tables(0).Rows.Count - 1
                                    If dsitongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                        Try
                                            tongthu += dsitongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsitongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If dsitongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        Try
                                            tongchi += dsitongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsitongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                        ' ten khach hang
                                        tenphichi += dsitongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                    End If


                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                            Catch ex As Exception

                            End Try

                            ' phhai tra cho
                            Dim sqlcuscredit As String
                            Dim dsicuscredit As New DataSet
                            Dim ten As String = ""
                            Dim g As Integer

                            sqlcuscredit = "select * from inboundfreight left join customer on inboundfreight.customerid=customer.customer_id where inboundid='" & dsi.Tables(0).Rows(i).Item("blib_id").ToString & "'  "
                            dsicuscredit = ReadDataSet(sqlcuscredit)
                            If dsicuscredit.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsicuscredit.Tables(0).Rows.Count - 1


                                    If dsicuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        ten += dsicuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                        ' ten khach hang

                                    End If
                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column39", currow).Value = ten
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                            Catch ex As Exception

                            End Try
                            ' lay pjieu chi tu house bill
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucchi As String = ""
                            Dim dsithucchi As New DataSet
                            Dim nc As Integer

                            'sqlThucchi = " select * from phieuchi where billno='" & dsi.Tables(0).Rows(i).Item("hbl").ToString & "' "
                            'dsithucchi = ReadDataSet(sqlThucchi)
                            'If dsithucchi.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dsithucchi.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucchiVND += CDbl(dsithucchi.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dsithucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucchi += dsithucchi.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '        Try
                            '            sophieuchi += dsithucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            Try
                                Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                            Catch ex As Exception

                            End Try
                            Try
                                'Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                'Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                'Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi


                                Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                                Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                                Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                Try
                                    Me.DataGridView1.Item("Column61", currow).Value = dsi.Tables(0).Rows(i).Item("userupdate").ToString
                                Catch ex As Exception

                                End Try
                            Catch ex As Exception

                            End Try

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                '--------------------------------------------------------------------------------------------------------------------
                ' logistics
                If Me.chkall.Checked = True Then ' logistics
                    If dsl.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dsl.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                            Me.DataGridView1.Item("Column1", currow).Value = dsl.Tables(0).Rows(i).Item("ref").ToString
                            Me.DataGridView1.Item("Column2", currow).Value = dsl.Tables(0).Rows(i).Item("bl_type").ToString
                            Me.DataGridView1.Item("Column3", currow).Value = dsl.Tables(0).Rows(i).Item("consignee").ToString
                            ' lay thong tin shipper
                            Dim sqlShipper As String
                            Dim dslShipper As New DataSet
                            If dsl.Tables(0).Rows(i).Item("shipper").ToString <> "" Then
                                sqlShipper = "select * from customer where company like '%" & dsl.Tables(0).Rows(i).Item("shipper").ToString & "%'"
                                dslShipper = ReadDataSet(sqlShipper)
                                If dslShipper.Tables(0).Rows.Count > 0 Then
                                    Me.DataGridView1.Item("Column4", currow).Value = dslShipper.Tables(0).Rows(0).Item("company").ToString
                                    Me.DataGridView1.Item("Column5", currow).Value = dslShipper.Tables(0).Rows(0).Item("address").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dslShipper.Tables(0).Rows(0).Item("tel").ToString
                                    Me.DataGridView1.Item("Column7", currow).Value = dslShipper.Tables(0).Rows(0).Item("fax").ToString



                                Else
                                    Dim s() As String
                                    s = dsl.Tables(0).Rows(i).Item("shipper").ToString.Split(Chr(13))
                                    Try
                                        Me.DataGridView1.Item("Column4", currow).Value = s(0).ToString

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column5", currow).Value = s(1) & " " & s(2)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column6", currow).Value = s(3)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("Column7", currow).Value = s(4)
                                    Catch ex As Exception

                                    End Try

                                End If
                            End If
                            Me.DataGridView1.Item("Column8", currow).Value = dsl.Tables(0).Rows(i).Item("mblcarrier").ToString & "/" & dsl.Tables(0).Rows(i).Item("mblmawb").ToString
                            'ta co so mblmawb, ta lay thong so container
                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dslCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""

                            sqlCont = "select * from containerlogistics where outboundid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dslCont = ReadDataSet(sqlCont)
                            If dslCont.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dslCont.Tables(0).Rows.Count - 1
                                    Try
                                        kg += CDbl(dslCont.Tables(0).Rows(j).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        kien += CDbl(dslCont.Tables(0).Rows(j).Item("sokien").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        khoi += CDbl(dslCont.Tables(0).Rows(j).Item("sokhoi").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        cont += dslCont.Tables(0).Rows(j).Item("containerno").ToString & "/" & dslCont.Tables(0).Rows(j).Item("seal").ToString & "/" & dslCont.Tables(0).Rows(j).Item("containertype").ToString & "; "
                                    Catch ex As Exception

                                    End Try
                                    type = dslCont.Tables(0).Rows(j).Item("type").ToString
                                Next
                            End If
                            ' them vao excel
                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(kien.ToString, 0) & " " & type


                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(kg.ToString, 3) & " Kgs"
                            Me.DataGridView1.Item("Column12", currow).Value = FormatNumber(khoi.ToString, 3) & " CBM"
                            Me.DataGridView1.Item("Column13", currow).Value = cont
                            '---------------------------------------------------

                            'truong hop hang xuat
                            Me.DataGridView1.Item("Column15", currow).Value = dsl.Tables(0).Rows(i).Item("importCy").ToString
                            Me.DataGridView1.Item("Column16", currow).Value = dsl.Tables(0).Rows(i).Item("shippingline").ToString
                            Me.DataGridView1.Item("Column17", currow).Value = dsl.Tables(0).Rows(i).Item("agencyname").ToString

                            Me.DataGridView1.Item("Column19", currow).Value = dsl.Tables(0).Rows(i).Item("vessel").ToString
                            Me.DataGridView1.Item("Column20", currow).Value = dsl.Tables(0).Rows(i).Item("voyage").ToString
                            Me.DataGridView1.Item("Column21", currow).Value = dsl.Tables(0).Rows(i).Item("description").ToString
                            ' ngay tau di den
                            Try
                                Me.DataGridView1.Item("Column22", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("sailingdate").ToString).Date & "/" & CDate(dsl.Tables(0).Rows(i).Item("eta").ToString).Date

                            Catch ex As Exception

                            End Try
                            '--- phi da thu
                            Dim sqlPhi As String = ""
                            Dim dslphi As New DataSet
                            Dim k As Integer
                            Dim tenphi As String = ""

                            sqlPhi = "select * from logisticsfreight left join charge on logisticsfreight.itemid =charge.charge_id  where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "' and debitcredit='Debit' "
                            dslphi = ReadDataSet(sqlPhi)
                            If dslphi.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dslphi.Tables(0).Rows.Count - 1
                                    tenphi += dslphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                Next
                            End If
                            Me.DataGridView1.Item("Column23", currow).Value = tenphi
                            '-------------------------------------------
                            '--- nguoi thanh toan
                            Dim sqlcusdebit As String = ""
                            Dim dslcusdebit As New DataSet
                            Dim l As Integer
                            Dim tencusdebit As String = ""
                            Dim hoadon As String = ""
                            Dim tongsotienvnd As Double = 0

                            Dim tencuscredit As String = ""

                            Dim tongsotienvndcredit As Double = 0
                            Dim sotienthucthuVND As Double = 0
                            Dim ngaythucthu As String = ""

                            Dim sotienthucchiVND As Double = 0
                            Dim ngaythucchi As String = ""
                            Dim sophieuchi As String = ""
                            sqlcusdebit = "select * from logisticsfreight left join customer on logisticsfreight.customerid =customer.customer_id  where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dslcusdebit = ReadDataSet(sqlcusdebit)
                            If dslcusdebit.Tables(0).Rows.Count > 0 Then
                                For k = 0 To dslcusdebit.Tables(0).Rows.Count - 1
                                    If dslcusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then
                                        tencusdebit += dslcusdebit.Tables(0).Rows(k).Item("company").ToString & "; "
                                        hoadon += dslcusdebit.Tables(0).Rows(k).Item("ngayhoadon").ToString & "; "
                                        Try
                                            tongsotienvnd += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dslcusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucthuVND += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucthu += dslcusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If

                                    End If
                                    If dslcusdebit.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then
                                        tencuscredit += dslcusdebit.Tables(0).Rows(k).Item("company").ToString & "; "

                                        Try
                                            tongsotienvndcredit += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                        Catch ex As Exception

                                        End Try
                                        If dslcusdebit.Tables(0).Rows(k).Item("paycheck").ToString = "True" Then
                                            Try
                                                sotienthucchiVND += CDbl(dslcusdebit.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                            Catch ex As Exception

                                            End Try

                                            ngaythucchi += dslcusdebit.Tables(0).Rows(k).Item("ngay").ToString + "; "

                                        End If
                                    End If

                                Next
                            End If

                            '-------------------------------------------
                            Me.DataGridView1.Item("Column24", currow).Value = tencusdebit
                            Me.DataGridView1.Item("Column25", currow).Value = hoadon
                            Me.DataGridView1.Item("Column26", currow).Value = FormatNumber(tongsotienvnd, 0)
                            Me.DataGridView1.Item("Column27", currow).Value = "VND"
                            '----
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucthu As String = ""
                            Dim dslthucthu As New DataSet
                            Dim n As Integer

                            'sqlThucthu = " select * from phieuthu where billno='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            'dslthucthu = ReadDataSet(sqlThucthu)
                            'If dslthucthu.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dslthucthu.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucthuVND += CDbl(dslthucthu.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '    Next
                            'End If
                            '---
                            Me.DataGridView1.Item("Column28", currow).Value = ngaythucthu.Replace("12:00:00 AM", "")
                            Me.DataGridView1.Item("Column29", currow).Value = FormatNumber(sotienthucthuVND, 0)
                            '-----------
                            ' ngay hoa don
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlhoadon As String = ""
                            Dim dslhoadon As New DataSet
                            Dim m As Integer

                            'Dim ngayhoadon As String = ""
                            'sqlhoadon = " select * from taxinvoice where billnumber='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            'dslhoadon = ReadDataSet(sqlhoadon)
                            'If dslhoadon.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dslhoadon.Tables(0).Rows.Count - 1
                            '        Try
                            '            ngayhoadon += CDbl(dslhoadon.Tables(0).Rows(n).Item("dateinvoice").ToString)
                            '            ' ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            ''---
                            'Me.DataGridView1.Item("Column30", currow).Value = ngayhoadon.Replace("12:00:00 AM", "")
                            ' lay trong phan theo doi lo hang
                            Dim sqltheodoi As String = ""
                            Dim dsltheodoi As New DataSet
                            Dim o As Integer

                            sqltheodoi = "select * from theodoilohanglogistics where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'"
                            dsltheodoi = ReadDataSet(sqltheodoi)
                            If dsltheodoi.Tables(0).Rows.Count > 0 Then
                                For o = 0 To dsltheodoi.Tables(0).Rows.Count - 1
                                    'ung voi gia tri ta tim lan luot trong theo doi
                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY KH NHAN HOA DON" Then
                                        Me.DataGridView1.Item("Column31", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY PHAT LENH" Then
                                        Me.DataGridView1.Item("Column32", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGUOI LIEN LAC" Then
                                        Me.DataGridView1.Item("Column33", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "EMAIL LIEN LAC" Then
                                        Me.DataGridView1.Item("Column34", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY MO FILE" Then
                                        Me.DataGridView1.Item("Column35", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DONG FILE" Then
                                        Me.DataGridView1.Item("Column36", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If
                                    If UCase(dsltheodoi.Tables(0).Rows(o).Item("items").ToString) = "NGAY DUA CHUNG TU CHO KHACH HANG" Then
                                        Me.DataGridView1.Item("Column44", currow).Value = dsltheodoi.Tables(0).Rows(o).Item("remarks").ToString
                                    End If

                                Next
                            End If
                            '-----------
                            ' tinh loi nhuan
                            ' lay tong thu= usd (nguyen te) - tong chi (nguyen te)-> truoc thue 
                            Dim sqltongthuchi As String
                            Dim dsltongthuchi As New DataSet
                            Dim tongthu As Double = 0
                            Dim tongchi As Double = 0
                            Dim tenphichi As String = ""

                            Dim r As Integer

                            sqltongthuchi = "select * from logisticsfreight left join charge on logisticsfreight.itemid=charge.charge_id where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dsltongthuchi = ReadDataSet(sqltongthuchi)
                            If dsltongthuchi.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dsltongthuchi.Tables(0).Rows.Count - 1
                                    If dsltongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Debit" Then
                                        Try
                                            tongthu += dsltongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsltongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                    End If

                                    If dsltongthuchi.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        Try
                                            tongchi += dsltongthuchi.Tables(0).Rows(r).Item("pricenotaxvnd").ToString() / dsltongthuchi.Tables(0).Rows(r).Item("tigia").ToString()

                                        Catch ex As Exception

                                        End Try
                                        ' ten khach hang
                                        tenphichi += dsltongthuchi.Tables(0).Rows(r).Item("dvt").ToString & "; "
                                    End If


                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column38", currow).Value = FormatNumber(tongthu - tongchi, 0)
                            Catch ex As Exception

                            End Try

                            ' phhai tra cho
                            Dim sqlcuscredit As String
                            Dim dslcuscredit As New DataSet
                            Dim ten As String = ""
                            Dim g As Integer

                            sqlcuscredit = "select * from logisticsfreight left join customer on logisticsfreight.customerid=customer.customer_id where logisticsid='" & dsl.Tables(0).Rows(i).Item("blob_id").ToString & "'  "
                            dslcuscredit = ReadDataSet(sqlcuscredit)
                            If dslcuscredit.Tables(0).Rows.Count > 0 Then
                                For r = 0 To dslcuscredit.Tables(0).Rows.Count - 1


                                    If dslcuscredit.Tables(0).Rows(r).Item("debitcredit").ToString() = "Credit" Then
                                        ten += dslcuscredit.Tables(0).Rows(r).Item("company").ToString() & "; "
                                        ' ten khach hang

                                    End If
                                Next
                            End If
                            '-------------------------
                            Try
                                Me.DataGridView1.Item("Column39", currow).Value = ten
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column40", currow).Value = tenphichi
                            Catch ex As Exception

                            End Try
                            ' lay pjieu chi tu house bill
                            ' ngay thuc thu, ket noi voi phieu thu = so house bill
                            Dim sqlThucchi As String = ""
                            Dim dslthucchi As New DataSet
                            Dim nc As Integer

                            'sqlThucchi = " select * from phieuchi where billno='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            'dslthucchi = ReadDataSet(sqlThucchi)
                            'If dslthucchi.Tables(0).Rows.Count > 0 Then
                            '    For n = 0 To dslthucchi.Tables(0).Rows.Count - 1
                            '        Try
                            '            sotienthucchiVND += CDbl(dslthucchi.Tables(0).Rows(n).Item("sotien").ToString)
                            '            ' ngaythucthu += dslthucthu.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try
                            '        Try

                            '            ngaythucchi += dslthucchi.Tables(0).Rows(n).Item("ngay").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '        Try
                            '            sophieuchi += dslthucchi.Tables(0).Rows(n).Item("soPhieuchi").ToString
                            '        Catch ex As Exception

                            '        End Try

                            '    Next
                            'End If
                            Try
                                Me.DataGridView1.Item("Column41", currow).Value = sophieuchi
                            Catch ex As Exception

                            End Try
                            Try
                                Me.DataGridView1.Item("Column42", currow).Value = FormatNumber(tongsotienvndcredit, 0) 'sotienthucchiVND
                                Me.DataGridView1.Item("Column43", currow).Value = "VND"
                                Me.DataGridView1.Item("Column45", currow).Value = ngaythucchi
                                Me.DataGridView1.Item("Column46", currow).Value = FormatNumber(sotienthucchiVND, 0)
                                Try
                                    Me.DataGridView1.Item("Column61", currow).Value = dsl.Tables(0).Rows(i).Item("userupdate").ToString
                                Catch ex As Exception

                                End Try

                            Catch ex As Exception

                            End Try

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                InsertAutoNumberToGrid(Me.DataGridView1)

            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmShipmentFollowUp_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.cboChinhanh.Items.Clear()
            Me.cboChinhanh.Text = ""
            If gBranch = "" Then

                Me.cboChinhanh.Items.Add("ALL")
                Me.cboChinhanh.Items.Add("HCM")
                Me.cboChinhanh.Items.Add("HPH")

            ElseIf gBranch = "SGN" Then

                Me.cboChinhanh.Items.Add("HCM")

            ElseIf gBranch = "HPH" Then

                Me.cboChinhanh.Items.Add("HPH")

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class