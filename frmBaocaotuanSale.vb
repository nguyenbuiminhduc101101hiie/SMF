Public Class frmBaocaotuanSale

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlc As String
            Dim dsc As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -65281
            Dim dongtang As Integer
            If Me.chkSale.Checked = True Then
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where CourierDocument.khachhangid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' and CourierDocument.salename like '%" & Me.txtSale.Text & "%' and convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where CourierDocument.salename like '%" & Me.txtSale.Text & "%' and convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            Else
                'CourierDocument.khachhangid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' and
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where CourierDocument.khachhangid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' and convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            End If

            ds = ReadDataSet(sql)
            ' show account
            Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)

                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("accno", currow).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString

                    Me.dgData.Item("ACCOUNTNAME", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString



                    mau -= 100
                    ' vong lap con
                    If Me.chkSale.Checked = True Then
                        sqlc = "select * from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where CourierDocument.salename like '%" & Me.txtSale.Text & "%' and convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "' "

                    Else
                        sqlc = "select * from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "' "

                    End If
                    dsc = ReadDataSet(sqlc)
                    dongtang = currow + 1
                    Dim tong1 As Double = 0
                    Dim tong2 As Double = 0
                    Dim tong3 As Double = 0
                    Dim tong4 As Double = 0
                    Dim tong5 As Double = 0
                    Dim tong6 As Double = 0
                    Dim tong7 As Double = 0
                    Dim tong8 As Double = 0
                    Dim tong9 As Double = 0


                    If dsc.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            Me.dgData.Rows.Add(1)
                            Me.dgData.Item("no", dongtang).Value = j + 1
                            Me.dgData.Item("ngayps", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngayps").ToString.Replace("12:00:00 AM", "")
                            Me.dgData.Item("accno", dongtang).Value = dsc.Tables(0).Rows(j).Item("customer_code").ToString
                            Me.dgData.Item("hawb", dongtang).Value = dsc.Tables(0).Rows(j).Item("hawb").ToString
                            Me.dgData.Item("org", dongtang).Value = dsc.Tables(0).Rows(j).Item("noidi").ToString
                            Me.dgData.Item("des", dongtang).Value = dsc.Tables(0).Rows(j).Item("noiden").ToString
                            Me.dgData.Item("cw", dongtang).Value = dsc.Tables(0).Rows(j).Item("trongluongcan").ToString
                            Me.dgData.Item("devision", dongtang).Value = dsc.Tables(0).Rows(j).Item("loaihang").ToString

                            Me.dgData.Item("ter", dongtang).Value = dsc.Tables(0).Rows(j).Item("salename").ToString

                            Me.dgData.Item("RF", dongtang).Value = dsc.Tables(0).Rows(j).Item("cuocdebit").ToString
                            '-----------------tong
                            Try
                                tong1 += dsc.Tables(0).Rows(j).Item("cuocdebit").ToString
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            Me.dgData.Item("RFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphidebit").ToString
                            '--tong-----
                            Try
                                tong2 += dsc.Tables(0).Rows(j).Item("phuphidebit").ToString
                            Catch ex As Exception

                            End Try
                            '---------------------
                            Try
                                Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocdebit").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphidebit").ToString), 2)

                            Catch ex As Exception

                            End Try
                            '-------tong
                            Try
                                tong3 += FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocdebit").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphidebit").ToString), 2)

                            Catch ex As Exception

                            End Try
                            '-------------------------------

                            Me.dgData.Item("PF", dongtang).Value = dsc.Tables(0).Rows(j).Item("cuocCREDIT").ToString
                            '-tong------------------------------------------------------------
                            Try
                                tong4 += dsc.Tables(0).Rows(j).Item("cuocCREDIT").ToString
                            Catch ex As Exception

                            End Try
                            '-------------------------------------------------------------------


                            Me.dgData.Item("PFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString
                            '-tong------------------------------------------------------------
                            Try
                                tong5 += dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString
                            Catch ex As Exception

                            End Try
                            '-------------------------------------------------------------------
                            Try
                                Me.dgData.Item("Ptotal", dongtang).Value = FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocCREDIT").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString), 2)

                            Catch ex As Exception

                            End Try
                            '-tong------------------------------------------------------------
                            Try
                                tong6 += FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocCREDIT").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString), 2)

                            Catch ex As Exception

                            End Try
                            '-------------------------------------------------------------------
                            Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocdebit").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphidebit").ToString), 2) - FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocCREDIT").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString), 2), 2)
                            '-tong------------------------------------------------------------
                            Try
                                tong7 += FormatNumber(FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocdebit").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphidebit").ToString), 2) - FormatNumber(CDbl(dsc.Tables(0).Rows(j).Item("cuocCREDIT").ToString) + CDbl(dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-------------------------------------------------------------------
                            Me.dgData.Item("COMMISSION", dongtang).Value = dsc.Tables(0).Rows(j).Item("COM").ToString
                            '-tong------------------------------------------------------------
                            Try
                                tong8 += dsc.Tables(0).Rows(j).Item("COM").ToString
                            Catch ex As Exception

                            End Try
                            '-------------------------------------------------------------------



                            Me.dgData.Item("MarginProfit", dongtang).Value = dsc.Tables(0).Rows(j).Item("Profit").ToString
                            '-tong------------------------------------------------------------
                            Try
                                tong9 += dsc.Tables(0).Rows(j).Item("Profit").ToString
                            Catch ex As Exception

                            End Try
                            '-------------------------------------------------------------------


                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("ter", dongtang).Value = "Sub Total"
                    Me.dgData.Item("RF", dongtang).Value = FormatNumber(tong1, 2)
                    Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next
            End If ' het hang cuorier
            ' den hang FF Outbound
            '-----------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------
            If Me.chkSale.Checked = True Then
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from outboundfreight  left join customer on outboundfreight .customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where outbound.salecode like '%" & Me.txtSale.Text & "%' and outboundfreight.customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'  and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from outboundfreight  left join customer on outboundfreight .customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where outbound.salecode like '%" & Me.txtSale.Text & "%' and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            Else
                'CourierDocument.khachhangid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' and
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from outboundfreight  left join customer on outboundfreight .customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where outboundfreight.customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'  and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from outboundfreight  left join customer on outboundfreight .customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where  convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            End If

            ds = ReadDataSet(sql)
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)

                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("accno", currow).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString

                    Me.dgData.Item("ACCOUNTNAME", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString



                    mau -= 100
                    ' vong lap con
                    If Me.chkSale.Checked = True Then
                        sqlc = "select mblmawb,debitcredit,sum(pricenotaxvnd) as sum from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where outbound.salecode like '%" & Me.txtSale.Text & "%' and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'  group by mblmawb,debitcredit order by mblmawb "

                    Else
                        '   sqlc = "select * from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "' "
                        ' sqlc = "select  mblmawb,debitcredit,sum(pricetruocthue) as sum from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'   group by mblmawb,debitcredit order by mblmawb "
                        sqlc = "select mblmawb,debitcredit,sum(pricenotaxvnd) as sum from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where  convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'  group by mblmawb,debitcredit order by mblmawb "

                    End If
                    dsc = ReadDataSet(sqlc)
                    dongtang = currow + 1
                    '-------------khai bao tong
                    Dim tong1 As Double = 0
                    Dim tong2 As Double = 0
                    Dim tong3 As Double = 0
                    Dim tong4 As Double = 0
                    Dim tong5 As Double = 0
                    Dim tong6 As Double = 0
                    Dim tong7 As Double = 0
                    Dim tong8 As Double = 0
                    Dim tong9 As Double = 0
                    '----------------------------------
                    If dsc.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            Me.dgData.Rows.Add(1)
                            Me.dgData.Item("no", dongtang).Value = j + 1
                            ' ung voi tung mblmawb thi ta laythong tin de show
                            Dim sqlmblmawb As String
                            Dim dsmblmawb As New DataSet
                            sqlmblmawb = " select * from outbound where mblmawb='" & dsc.Tables(0).Rows(j).Item("mblmawb").ToString & "'"
                            dsmblmawb = ReadDataSet(sqlmblmawb)
                            If dsmblmawb.Tables(0).Rows.Count > 0 Then
                                '-----------------------------------------------------
                                Me.dgData.Item("ngayps", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("SAILINGDATE").ToString.Replace("12:00:00 AM", "")
                                Me.dgData.Item("accno", dongtang).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString
                                Me.dgData.Item("hawb", dongtang).Value = dsc.Tables(0).Rows(j).Item("mblmawb").ToString
                                Me.dgData.Item("org", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("pol").ToString
                                Me.dgData.Item("des", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("pod").ToString
                                Me.dgData.Item("agent", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("agencyname").ToString
                                ' lay tong so kg
                                Dim sqlkg As String
                                Dim dskg As New DataSet
                                sqlkg = "select * from containertype where outboundid='" & dsmblmawb.Tables(0).Rows(0).Item("blob_id").ToString & "' "

                                dskg = ReadDataSet(sqlkg)
                                Dim sokg As Double = 0
                                For kg As Integer = 0 To dskg.Tables(0).Rows.Count - 1
                                    Try
                                        sokg += CDbl(dskg.Tables(0).Rows(kg).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try

                                Next

                                '------------------------------
                                Me.dgData.Item("cw", dongtang).Value = FormatNumber(sokg.ToString, 2) 'dsc.Tables(0).Rows(j).Item("trongluongcan").ToString
                                Me.dgData.Item("devision", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("description").ToString

                                Me.dgData.Item("ter", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("salecode").ToString
                            End If

                            'tinh cuoc
                            '---------------------------------------------------
                            Dim debit As Double = 0
                            Dim credit As Double = 0
                            'For h As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            If dsc.Tables(0).Rows(j).Item("debitcredit").ToString = "Debit" Then
                                debit += dsc.Tables(0).Rows(j).Item("sum").ToString
                            Else
                                credit += dsc.Tables(0).Rows(j).Item("sum").ToString
                            End If


                            'Next
                            Me.dgData.Item("RF", dongtang).Value = FormatNumber(debit.ToString, 2)
                            '-----------------tong
                            Try
                                tong1 += debit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            '    Me.dgData.Item("RFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphidebit").ToString
                            Try
                                Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(debit, 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong
                            Try
                                tong3 += debit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------

                            Me.dgData.Item("PF", dongtang).Value = FormatNumber(credit.ToString, 2)

                            '-----------------tong
                            Try
                                tong4 += credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            'Me.dgData.Item("PFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString
                            Try
                                Me.dgData.Item("Ptotal", dongtang).Value = FormatNumber(credit, 2)

                            Catch ex As Exception

                            End Try

                            '-----------------tong
                            Try
                                tong6 += credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                            '-----------------tong
                            Try
                                tong7 += debit - credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------

                            'Me.dgData.Item("COMMISSION", dongtang).Value = dsc.Tables(0).Rows(j).Item("COM").ToString

                            Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                            '-----------------tong
                            Try
                                tong9 += debit - credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("ter", dongtang).Value = "Sub Total"
                    Me.dgData.Item("RF", dongtang).Value = FormatNumber(tong1, 2)
                    Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next
            End If ' het hang FF

            ' den hang FF inbound
            '-----------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------
            If Me.chkSale.Checked = True Then
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from Inboundfreight  left join customer on Inboundfreight .customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where inbound.salecode like '%" & Me.txtSale.Text & "%' and inboundfreight.customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'  and convert(datetime,eta) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from Inboundfreight  left join customer on Inboundfreight .customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where inbound.salecode like '%" & Me.txtSale.Text & "%' AND convert(datetime,eta) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            Else
                'CourierDocument.khachhangid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' and
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from inboundfreight  left join customer on inboundfreight .customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where inboundfreight.customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'  and convert(datetime,eta) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from inboundfreight  left join customer on inboundfreight .customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where convert(datetime,eta) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            End If

            ds = ReadDataSet(sql)
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)

                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("accno", currow).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString

                    Me.dgData.Item("ACCOUNTNAME", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString



                    mau -= 100
                    ' vong lap con
                    If Me.chkSale.Checked = True Then
                        sqlc = "select hbl,debitcredit,sum(pricenotaxvnd) as sum from inboundfreight left join customer on inboundfreight.customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where inbound.salecode like '%" & Me.txtSale.Text & "%' and convert(datetime,eta) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'  group by hbl,debitcredit order by hbl "

                    Else
                        '   sqlc = "select * from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "' "
                        ' sqlc = "select  mblmawb,debitcredit,sum(pricetruocthue) as sum from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'   group by mblmawb,debitcredit order by mblmawb "
                        sqlc = "select hbl,debitcredit,sum(pricenotaxvnd) as sum from inboundfreight left join customer on inboundfreight.customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where  convert(datetime,eta) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'  group by hbl,debitcredit order by hbl "

                    End If
                    dsc = ReadDataSet(sqlc)
                    dongtang = currow + 1
                    '-------------khai bao tong
                    Dim tong1 As Double = 0
                    Dim tong2 As Double = 0
                    Dim tong3 As Double = 0
                    Dim tong4 As Double = 0
                    Dim tong5 As Double = 0
                    Dim tong6 As Double = 0
                    Dim tong7 As Double = 0
                    Dim tong8 As Double = 0
                    Dim tong9 As Double = 0
                    '----------------------------------
                    If dsc.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            Me.dgData.Rows.Add(1)
                            Me.dgData.Item("no", dongtang).Value = j + 1
                            ' ung voi tung mblmawb thi ta laythong tin de show
                            Dim sqlmblmawb As String
                            Dim dsmblmawb As New DataSet
                            sqlmblmawb = " select * from inbound where hbl='" & dsc.Tables(0).Rows(j).Item("hbl").ToString & "'"
                            dsmblmawb = ReadDataSet(sqlmblmawb)
                            If dsmblmawb.Tables(0).Rows.Count > 0 Then
                                '-----------------------------------------------------
                                Me.dgData.Item("ngayps", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("eta").ToString.Replace("12:00:00 AM", "")
                                Me.dgData.Item("accno", dongtang).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString
                                Me.dgData.Item("hawb", dongtang).Value = dsc.Tables(0).Rows(j).Item("hbl").ToString
                                Me.dgData.Item("org", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("pol").ToString
                                Me.dgData.Item("des", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("pod").ToString
                                Me.dgData.Item("agent", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("agencyname").ToString
                                ' lay tong so kg
                                '------------------------------
                                ' lay tong so kg
                                Dim sqlkg As String
                                Dim dskg As New DataSet
                                sqlkg = "select * from containerrepair where inboundid='" & dsmblmawb.Tables(0).Rows(0).Item("blib_id").ToString & "' "

                                dskg = ReadDataSet(sqlkg)
                                Dim sokg As Double = 0
                                For kg As Integer = 0 To dskg.Tables(0).Rows.Count - 1
                                    Try
                                        sokg += CDbl(dskg.Tables(0).Rows(kg).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try

                                Next

                                '------------------------------
                                Me.dgData.Item("cw", dongtang).Value = FormatNumber(sokg.ToString, 2) 'dsc.Tables(0).Rows(j).Item("trongluongcan").ToString
                                Me.dgData.Item("devision", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("description").ToString

                                Me.dgData.Item("ter", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("salecode").ToString
                            End If

                            'tinh cuoc
                            '---------------------------------------------------
                            Dim debit As Double = 0
                            Dim credit As Double = 0
                            'For h As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            If dsc.Tables(0).Rows(j).Item("debitcredit").ToString = "Debit" Then
                                debit += dsc.Tables(0).Rows(j).Item("sum").ToString
                            Else
                                credit += dsc.Tables(0).Rows(j).Item("sum").ToString
                            End If


                            'Next
                            Me.dgData.Item("RF", dongtang).Value = FormatNumber(debit.ToString, 2)
                            '-----------------tong
                            Try
                                tong1 += debit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            '    Me.dgData.Item("RFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphidebit").ToString
                            Try
                                Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(debit, 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong
                            Try
                                tong3 += debit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------

                            Me.dgData.Item("PF", dongtang).Value = FormatNumber(credit.ToString, 2)
                            '-----------------tong
                            Try
                                tong4 += credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------
                            'Me.dgData.Item("PFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString
                            Try
                                Me.dgData.Item("Ptotal", dongtang).Value = FormatNumber(credit, 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong
                            Try
                                tong6 += credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------

                            Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                            '-----------------tong
                            Try
                                tong7 += debit - credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------

                            'Me.dgData.Item("COMMISSION", dongtang).Value = dsc.Tables(0).Rows(j).Item("COM").ToString

                            Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                            '-----------------tong
                            Try
                                tong9 += debit - credit
                            Catch ex As Exception

                            End Try
                            '----------------------------------------------------------------------------

                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("ter", dongtang).Value = "Sub Total"
                    Me.dgData.Item("RF", dongtang).Value = FormatNumber(tong1, 2)
                    Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next
            End If ' het hang FF

            ' den hang FF Log
            '-----------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------
            If Me.chkSale.Checked = True Then
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from logisticsfreight  left join customer on logisticsfreight .customerid=customer.customer_id left join logistics on logistics.blob_id=logisticsfreight.logisticsid where logistics.salecode like '%" & Me.txtSale.Text & "%' and logisticsfreight.customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'  and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from logisticsfreight  left join customer on logisticsfreight .customerid=customer.customer_id left join logistics on logistics.blob_id=logisticsfreight.logisticsid where logistics.salecode like '%" & Me.txtSale.Text & "%' AND convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            Else
                'CourierDocument.khachhangid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "' and
                If Me.CHKCUS.Checked = True Then
                    sql = "select customer_id,customer_code ,company from logisticsfreight  left join customer on logisticsfreight .customerid=customer.customer_id left join logistics on logistics.blob_id=logisticsfreight.logisticsid where logisticsfreight.customerid='" & FindValueID(Me.cboagencyname, Me.cboagencyname.Text) & "'  and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                Else
                    sql = "select customer_id,customer_code ,company from logisticsfreight  left join customer on logisticsfreight .customerid=customer.customer_id left join logistics on logistics.blob_id=logisticsfreight.logisticsid where  convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' group by customer_id,customer_code ,company "

                End If

            End If

            ds = ReadDataSet(sql)
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)

                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("accno", currow).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString

                    Me.dgData.Item("ACCOUNTNAME", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString



                    mau -= 100
                    ' vong lap con
                    If Me.chkSale.Checked = True Then
                        sqlc = "select ref,debitcredit,sum(pricenotaxvnd) as sum from logisticsfreight left join customer on logisticsfreight.customerid=customer.customer_id left join logistics on logistics.blob_id=logisticsfreight.logisticsid where logistics.salecode like '%" & Me.txtSale.Text & "%' and convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'  group by ref,debitcredit order by ref "

                    Else
                        '   sqlc = "select * from CourierDocument left join customer on CourierDocument.khachhangid=customer.customer_id where convert(datetime,ngayps) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "' "
                        ' sqlc = "select  mblmawb,debitcredit,sum(pricetruocthue) as sum from outboundfreight left join customer on outboundfreight.customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'   group by mblmawb,debitcredit order by mblmawb "
                        sqlc = "select ref,debitcredit,sum(pricenotaxvnd) as sum from logisticsfreight left join customer on logisticsfreight.customerid=customer.customer_id left join logistics on logistics.blob_id=logisticsfreight.logisticsid where  convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and customer_code='" & ds.Tables(0).Rows(i).Item("customer_code").ToString & "'  group by ref,debitcredit order by ref "

                    End If
                    dsc = ReadDataSet(sqlc)
                    dongtang = currow + 1
                    '-------------khai bao tong
                    Dim tong1 As Double = 0
                    Dim tong2 As Double = 0
                    Dim tong3 As Double = 0
                    Dim tong4 As Double = 0
                    Dim tong5 As Double = 0
                    Dim tong6 As Double = 0
                    Dim tong7 As Double = 0
                    Dim tong8 As Double = 0
                    Dim tong9 As Double = 0
                    '----------------------------------
                    If dsc.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            Me.dgData.Rows.Add(1)
                            Me.dgData.Item("no", dongtang).Value = j + 1
                            ' ung voi tung mblmawb thi ta laythong tin de show
                            Dim sqlmblmawb As String
                            Dim dsmblmawb As New DataSet
                            sqlmblmawb = " select * from logistics where ref='" & dsc.Tables(0).Rows(j).Item("ref").ToString & "'"
                            dsmblmawb = ReadDataSet(sqlmblmawb)
                            If dsmblmawb.Tables(0).Rows.Count > 0 Then
                                '-----------------------------------------------------
                                Me.dgData.Item("ngayps", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("SAILINGDATE").ToString.Replace("12:00:00 AM", "")
                                Me.dgData.Item("accno", dongtang).Value = ds.Tables(0).Rows(i).Item("customer_code").ToString
                                Me.dgData.Item("hawb", dongtang).Value = dsc.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgData.Item("org", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("pol").ToString
                                Me.dgData.Item("des", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("pod").ToString
                                Me.dgData.Item("agent", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("agencyname").ToString
                                ' lay tong so kg
                                Dim sqlkg As String
                                Dim dskg As New DataSet
                                sqlkg = "select * from containerlogistics where outboundid='" & dsmblmawb.Tables(0).Rows(0).Item("blob_id").ToString & "' "

                                dskg = ReadDataSet(sqlkg)
                                Dim sokg As Double = 0
                                For kg As Integer = 0 To dskg.Tables(0).Rows.Count - 1
                                    Try
                                        sokg += CDbl(dskg.Tables(0).Rows(kg).Item("sokg").ToString)
                                    Catch ex As Exception

                                    End Try

                                Next

                                '------------------------------
                                Me.dgData.Item("cw", dongtang).Value = FormatNumber(sokg.ToString, 2) 'dsc.Tables(0).Rows(j).Item("trongluongcan").ToString
                                Me.dgData.Item("devision", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("description").ToString

                                Me.dgData.Item("ter", dongtang).Value = dsmblmawb.Tables(0).Rows(0).Item("salecode").ToString
                            End If

                            'tinh cuoc
                            '---------------------------------------------------
                            Dim debit As Double = 0
                            Dim credit As Double = 0
                            'For h As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            If dsc.Tables(0).Rows(j).Item("debitcredit").ToString = "Debit" Then
                                debit += dsc.Tables(0).Rows(j).Item("sum").ToString
                            Else
                                credit += dsc.Tables(0).Rows(j).Item("sum").ToString
                            End If


                            'Next
                            Me.dgData.Item("RF", dongtang).Value = FormatNumber(debit.ToString, 2)
                            Try
                                tong1 += debit
                            Catch ex As Exception

                            End Try
                            '    Me.dgData.Item("RFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphidebit").ToString
                            Try
                                Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(debit, 2)

                            Catch ex As Exception

                            End Try
                            Try
                                tong3 += debit
                            Catch ex As Exception

                            End Try

                            Me.dgData.Item("PF", dongtang).Value = FormatNumber(credit.ToString, 2)
                            Try
                                tong4 += credit
                            Catch ex As Exception

                            End Try
                            'Me.dgData.Item("PFsc", dongtang).Value = dsc.Tables(0).Rows(j).Item("phuphiCREDIT").ToString
                            Try
                                Me.dgData.Item("Ptotal", dongtang).Value = FormatNumber(credit, 2)

                            Catch ex As Exception

                            End Try
                            Try
                                tong6 += credit
                            Catch ex As Exception

                            End Try

                            Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                            Try
                                tong7 += debit - credit
                            Catch ex As Exception

                            End Try
                            'Me.dgData.Item("COMMISSION", dongtang).Value = dsc.Tables(0).Rows(j).Item("COM").ToString

                            Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                            Try
                                tong9 += debit - credit
                            Catch ex As Exception

                            End Try
                            dongtang += 1
                        Next
                    End If
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("ter", dongtang).Value = "Sub Total"
                    Me.dgData.Item("RF", dongtang).Value = FormatNumber(tong1, 2)
                    Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next
            End If ' het hang FF
            InsertAutoNumberToGrid(Me.dgData)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexcel.Click
        Try
            If Me.dgData.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.dgData, Me)
            'SetMenu(True)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub QueryAgency()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        Me.cboagencyname.Items.Clear()
        'id = "agency_id"
        'value = "agencyname"
        'strSQL = "Select agency_id,  agencyname From agency  where continued=1 Order By agencyname"
        'loadDataToObject_(Me.cboagencyname, strSQL, id, value)

        id = "Customer_id"
        value = "Company"
        strSQL = "Select Customer_id,  company From customer  where continued=1 Order By company"
        loadDataToObject_(Me.cboagencyname, strSQL, id, value)

        'id = "Shippinglineid"
        'value = "Shippingline"
        'strSQL = "Select Shippinglineid,  Shippingline From Shippingline  where continued=1 Order By Shippingline "
        'loadDataToObject_(Me.cboagencyname, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub frmBaocaotuanSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Me.CHKCUS.Checked = True
            'Me.CHKCUS.Enabled = False
            QueryAgency()
        Catch ex As Exception

        End Try
    End Sub
End Class