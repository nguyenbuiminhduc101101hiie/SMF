Public Class frmlistchargesPaid

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim ds As New DataSet
            Dim sql As String
            If Me.chkp.Checked = True Then
                If Me.chkoutbound.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,outboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, outboundfreight.tigia "
                            sql &= "  ,outboundfreight.approve,outboundfreight.userupdate,outboundfreight.dateupdate,daily  From outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=1 order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,outboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, outboundfreight.tigia "
                            sql &= "  ,outboundfreight.approve,outboundfreight.userupdate,outboundfreight.dateupdate,daily  From outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%' and paycheck=1 order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
                If Me.chkinbound.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,hbl as hbl,taxcode + '-' + company as company,charge_code as item,inboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, inboundfreight.tigia "
                            sql &= "  ,inboundfreight.approve,inboundfreight.userupdate,inboundfreight.dateupdate,daily  From inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=1 order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,hbl as hbl,taxcode + '-' + company as company,charge_code as item,inboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, inboundfreight.tigia "
                            sql &= "  ,inboundfreight.approve,inboundfreight.userupdate,inboundfreight.dateupdate,daily  From inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%' and paycheck=1 order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
                If Me.chklogistics.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,logisticsfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, logisticsfreight.tigia "
                            sql &= "  ,logisticsfreight.approve,logisticsfreight.userupdate,logisticsfreight.dateupdate,daily  From logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join customer on logisticsfreight.customerid=customer.customer_id  left join charge on logisticsfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=1 order by ref,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,logisticsfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, logisticsfreight.tigia "
                            sql &= "  ,logisticsfreight.approve,logisticsfreight.userupdate,logisticsfreight.dateupdate, daily  From logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join customer on logisticsfreight.customerid=customer.customer_id  left join charge on logisticsfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=1 order by ref,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
            Else
                If Me.chkoutbound.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,outboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, outboundfreight.tigia "
                            sql &= "  ,outboundfreight.approve,outboundfreight.userupdate,outboundfreight.dateupdate,daily  From outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=0  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,outboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, outboundfreight.tigia "
                            sql &= "  ,outboundfreight.approve,outboundfreight.userupdate,outboundfreight.dateupdate,daily  From outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'   and paycheck=0  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
                If Me.chkinbound.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,hbl as hbl,taxcode + '-' + company as company,charge_code as item,inboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, inboundfreight.tigia "
                            sql &= "  ,inboundfreight.approve,inboundfreight.userupdate,inboundfreight.dateupdate,daily  From inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=0   order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,hbl as hbl,taxcode + '-' + company as company,charge_code as item,inboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, inboundfreight.tigia "
                            sql &= "  ,inboundfreight.approve,inboundfreight.userupdate,inboundfreight.dateupdate,daily  From inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'   and paycheck=0  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
                If Me.chklogistics.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,logisticsfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, logisticsfreight.tigia "
                            sql &= "  ,logisticsfreight.approve,logisticsfreight.userupdate,logisticsfreight.dateupdate,daily  From logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join customer on logisticsfreight.customerid=customer.customer_id  left join charge on logisticsfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=0 order by ref,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,logisticsfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, logisticsfreight.tigia "
                            sql &= "  ,logisticsfreight.approve,logisticsfreight.userupdate,logisticsfreight.dateupdate,daily  From logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join customer on logisticsfreight.customerid=customer.customer_id  left join charge on logisticsfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'  and paycheck=0 order by ref,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
            End If





            If Me.chkall.Checked = True Then
                If Me.chkoutbound.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,outboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, outboundfreight.tigia "
                            sql &= "  ,outboundfreight.approve,outboundfreight.userupdate,outboundfreight.dateupdate,daily  From outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,outboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, outboundfreight.tigia "
                            sql &= "  ,outboundfreight.approve,outboundfreight.userupdate,outboundfreight.dateupdate,daily  From outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on outboundfreight.customerid=customer.customer_id  left join charge on outboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'   order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If
                If Me.chkinbound.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,hbl as hbl,taxcode + '-' + company as company,charge_code as item,inboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, inboundfreight.tigia "
                            sql &= "  ,inboundfreight.approve,inboundfreight.userupdate,inboundfreight.dateupdate,daily  From inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'   order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,hbl as hbl,taxcode + '-' + company as company,charge_code as item,inboundfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, inboundfreight.tigia "
                            sql &= "  ,inboundfreight.approve,inboundfreight.userupdate,inboundfreight.dateupdate,daily  From inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on inboundfreight.customerid=customer.customer_id  left join charge on inboundfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If

                If Me.chklogistics.Checked = True Then
                    Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,logisticsfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, logisticsfreight.tigia "
                            sql &= "  ,logisticsfreight.approve,logisticsfreight.userupdate,logisticsfreight.dateupdate,daily  From logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join customer on logisticsfreight.customerid=customer.customer_id  left join charge on logisticsfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Debit' and ref like '%" & Me.cboChinhanh.Text & "%'  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            Me.dgddebitGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgddebitGrid)
                        Catch ex As Exception

                        End Try
                        Try
                            sql = "Select ref,mblmawb as hbl,taxcode + '-' + company as company,charge_code as item,logisticsfreight.currency,containertype,unitprice, pricetruocthue,pricenotaxvnd, taxprice, pricethue, price, note, quantity, paycheck, os, ngay, ngayhoadon, logisticsfreight.tigia "
                            sql &= "  ,logisticsfreight.approve,logisticsfreight.userupdate,logisticsfreight.dateupdate,daily  From logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join customer on logisticsfreight.customerid=customer.customer_id  left join charge on logisticsfreight.itemid=charge.charge_id "
                            sql &= "Where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and debitcredit='Credit' and ref like '%" & Me.cboChinhanh.Text & "%'  order by hbl,convert(datetime,datereport) desc "
                            ds = ReadDataSet(sql)
                            ds = ReadDataSet(sql)
                            Me.dgdCreditGrid.DataSource = ds.Tables(0)


                            '--------------------
                            Me.Cursor = System.Windows.Forms.Cursors.Default

                            InsertAutoNumberToGrid(Me.dgdCreditGrid)
                        Catch ex As Exception

                        End Try


                    Catch ex As Exception
                        MsgBox(msgErr(Me, ex.Message))
                    End Try
                End If



            End If

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
               
                'SetMenu(False)
                ExportExecel(Me.dgddebitGrid, Me)
                ExportExecel(Me.dgdCreditGrid, Me)
                ' ExportExecel(Me.DataGridView2, Me)
                'SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class