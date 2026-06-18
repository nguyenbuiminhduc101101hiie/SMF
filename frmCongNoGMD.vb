Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Public Class frmCongNoGMD

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.dgddebitGrid, Me)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub SOA(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal customerid As String, ByVal date_ As String, ByVal order As String)
        Try
            Try
                Dim currow As Integer
                ' kiem tra neu co du lieu yhi moi add
                Dim sql As String
                Dim ds As New DataSet
                Dim i As Integer
                Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
                Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
                ' KIEM TRA HANG SOC,COC,TAT CA
                'If Me.CHKSOC.Checked = True Then
                '    If Me.chkpay.Checked = True Then
                '        If Me.chkallCus.Checked = True Then
                '            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "' AND nvocc=1 order by " & order & " "

                '        Else
                '            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "' AND nvocc=1 order by " & order & " "

                '        End If

                '    Else
                '        If Me.chkallCus.Checked = True Then
                '            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'   and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "' AND nvocc=1 order by " & order & " "

                '        Else
                '            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'  and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "' AND nvocc=1 order by " & order & " "

                '        End If

                '    End If

                'End If

                'If Me.CHKCOC.Checked = True Then
                '    If Me.chkpay.Checked = True Then
                '        If Me.chkallCus.Checked = True Then
                '            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "' AND nvocc=0 order by " & order & " "

                '        Else
                '            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "' AND nvocc=0 order by " & order & " "

                '        End If

                '    Else
                '        If Me.chkallCus.Checked = True Then
                '            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'   and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "' AND nvocc=0 order by " & order & " "

                '        Else
                '            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'  and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "' AND nvocc=0 order by " & order & " "

                '        End If

                '    End If

                'End If
                'If Me.chlallsoccoc.Checked = True Then
                If Me.cboFLC.Text = "" And cboSC.Text = "" Then
                    If Me.chkpay.Checked = True Then
                        If Me.chkallCus.Checked = True Then
                            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "'  and os=0   order by " & order & " "

                        Else
                            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "'    and os=0  order by " & order & " "

                        End If

                    Else
                        If Me.chkallCus.Checked = True Then
                            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'   and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "'    and os=0   order by " & TableDeptID & " "

                        Else
                            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'  and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "'   and os=0   order by " & order & " "

                        End If

                    End If
                Else
                    If Me.chkpay.Checked = True Then
                        If Me.chkallCus.Checked = True Then
                            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "' and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'   and os=0   order by " & order & " "

                        Else
                            sql = "select * , " & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit' and paycheck=1 and nhom= '" & tieudedong & "' and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'   and os=0  order by " & order & " "

                        End If

                    Else
                        If Me.chkallCus.Checked = True Then
                            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'   and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "'  and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'   and os=0   order by " & TableDeptID & " "

                        Else
                            sql = "select * ," & tableFreight & ".currency as cur_, " & tableFreight & ".tigia as tigia_ from  " & TableDept & " left join  " & tableFreight & " on  " & TableDept & "." & TableDeptID & " = " & tableFreight & "." & tableFreightID & " left join charge on charge.charge_id= " & tableFreight & ".itemid  left join customer on " & tableFreight & ".customerid =customer.customer_id where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'  and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='Debit'  and paycheck=0 and nhom= '" & tieudedong & "' and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'   and os=0  order by " & order & " "

                        End If

                    End If
                End If


                ' End If
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgddebitGrid.Rows.Add(1)
                        currow = dgddebitGrid.RowCount - 2
                        Me.dgddebitGrid.Item("stt_debit", currow).Value = (i + 1).ToString
                        Me.dgddebitGrid.Item("id_debit", currow).Value = ds.Tables(0).Rows(i).Item("customer_id").ToString
                        Me.dgddebitGrid.Item("ref", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                        '-----------------------------------------------
                        Try
                            Me.dgddebitGrid.Item("flc", currow).Value = ds.Tables(0).Rows(i).Item("gflc").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("sc", currow).Value = ds.Tables(0).Rows(i).Item("gsc").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("mbl", currow).Value = ds.Tables(0).Rows(i).Item("mblcarrier").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("mbl", currow).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("tkhq", currow).Value = ds.Tables(0).Rows(i).Item("tkhq").ToString
                        Catch ex As Exception

                        End Try
                        '-----------------------------------------------------------
                        Try
                            Me.dgddebitGrid.Item("company_debit", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("item_debit", currow).Value = ds.Tables(0).Rows(i).Item("charge_code").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            Me.dgddebitGrid.Item("currency_debit", currow).Value = ds.Tables(0).Rows(i).Item("cur_").ToString
                        Catch ex As Exception

                        End Try
                        ' them
                        Try
                            Me.dgddebitGrid.Item("sales", currow).Value = ds.Tables(0).Rows(i).Item("salename").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("vessel", currow).Value = ds.Tables(0).Rows(i).Item("vessel").ToString '+ ds.Tables(0).Rows(i).Item("fv1").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            Me.dgddebitGrid.Item("vessel", currow).Value += ds.Tables(0).Rows(i).Item("fv1").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("polpod", currow).Value = ds.Tables(0).Rows(i).Item("polcode").ToString + "/" + ds.Tables(0).Rows(i).Item("podcode").ToString ' + ds.Tables(0).Rows(i).Item("AirportDeparture").ToString + "/" + ds.Tables(0).Rows(i).Item("AirPortDes").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("polpod", currow).Value += ds.Tables(0).Rows(i).Item("AirportDeparture").ToString + "/" + ds.Tables(0).Rows(i).Item("AirPortDes").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            Me.dgddebitGrid.Item("etdeta", currow).Value = ds.Tables(0).Rows(i).Item("sailingdate").ToString + "/" + ds.Tables(0).Rows(i).Item("eta").ToString '+ ds.Tables(0).Rows(i).Item("fd1").ToString + "/" + ds.Tables(0).Rows(i).Item("fd2").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("etdeta", currow).Value += ds.Tables(0).Rows(i).Item("fd1").ToString + "/" + ds.Tables(0).Rows(i).Item("fd2").ToString
                        Catch ex As Exception

                        End Try

                        If ds.Tables(0).Rows(i).Item("cur_").ToString.Trim = "USD" Then

                            Me.dgddebitGrid.Item("price", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price_").ToString, 2)
                        Else
                            Me.dgddebitGrid.Item("price", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price_").ToString) / CDbl(ds.Tables(0).Rows(i).Item("tigia_").ToString), 2)
                        End If
                        'them vat
                        If ds.Tables(0).Rows(i).Item("cur_").ToString.Trim = "USD" Then

                            Me.dgddebitGrid.Item("vat", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("price_").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString)) / 100, 2)
                        Else
                            Me.dgddebitGrid.Item("vat", currow).Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("price_").ToString) * CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString)) / 100, 2) / CDbl(ds.Tables(0).Rows(i).Item("tigia_").ToString)
                        End If
                        ''''

                        Me.dgddebitGrid.Item("price_", currow).Value = CDbl(Me.dgddebitGrid.Item("vat", currow).Value) + CDbl(Me.dgddebitGrid.Item("price", currow).Value)


                        '---- them vnd
                        If ds.Tables(0).Rows(i).Item("cur_").ToString.Trim = "VND" Then

                            Me.dgddebitGrid.Item("tongvnd", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                        Else
                            Me.dgddebitGrid.Item("tongvnd", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia_").ToString), 2)
                        End If
                        '---------------------------
                        Try
                            Me.dgddebitGrid.Item("containertype_debit", currow).Value = ds.Tables(0).Rows(i).Item("containertype").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("quantity_debit", currow).Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("unitprice_debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("unitprice").ToString, 2)
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("tigia_debit", currow).Value = ds.Tables(0).Rows(i).Item("tigia_").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("taxprice_debit", currow).Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("price_debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("note_debit", currow).Value = ds.Tables(0).Rows(i).Item("note").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("paycheck_debit", currow).Value = ds.Tables(0).Rows(i).Item("paycheck").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("Agent_debit", currow).Value = ds.Tables(0).Rows(i).Item("daily").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("Os_debit", currow).Value = ds.Tables(0).Rows(i).Item("os").ToString
                        Catch ex As Exception

                        End Try


                        Try
                            Me.dgddebitGrid.Item("ngay_debit", currow).Value = ds.Tables(0).Rows(i).Item("ngay").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("ngay_debit", currow).Value = ds.Tables(0).Rows(i).Item("ngay").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("ngayhoadon_debit", currow).Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            Me.dgddebitGrid.Item("approvedebit", currow).Value = ds.Tables(0).Rows(i).Item("approve").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("Userupdatedebit", currow).Value = ds.Tables(0).Rows(i).Item("Userupdate").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("dateupdatedebit", currow).Value = ds.Tables(0).Rows(i).Item("dateupdate").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            Me.dgddebitGrid.Item("remarks_", currow).Value = ds.Tables(0).Rows(i).Item("note").ToString
                        Catch ex As Exception

                        End Try

                    Next
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Function getTongXDLogisticsfreight(ByVal cusid As String, ByVal tu As Date, ByVal den As Date, ByVal debitcredit As String, ByVal pay As Boolean, ByVal tableM As String, ByVal tableMID As String, ByVal tableFreight As String, ByVal tableFreightID As String)
        Try
            Dim tong As Double = 0
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text

            ' lay tong tien cua freightlogistics
            Dim sql As String
            Dim ds As New DataSet
            'If codeXangDau = True Then
            '    sql = "select * from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid left join charge on charge.charge_id= logisticsfreight.itemid where customerid='" & FindValueID(Me.cbocustomer, Me.cbocustomer.Text) & "' and debitcredit='" & debitcredit & "'  and convert(datetime,datereport) between '" & tu & "' and '" & den & "' and ref like '%" & Me.ComboBox1.Text & "%' and paycheck='" & pay & "' and charge_code='PXD' "
            'Else
            sql = "select * from " & tableM & " left join " & tableFreight & " on " & tableM & "." & tableMID & "=" & tableFreight & "." & tableFreightID & " where " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and debitcredit='" & debitcredit & "'  and convert(datetime,datereport) between '" & tu & "' and '" & den & "' and paycheck='" & pay & "'  "

            'End If
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If ds.Tables(0).Rows(i).Item("currency").ToString.Trim = "VND" Then
                        tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
                    Else
                        tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
                    End If

                Next
            End If






            Return tong
        Catch ex As Exception

        End Try
    End Function
    Public Sub printReport()
        Try
            Try
                ' xoa csdl

                Dim cmd As New ADODB.Command
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from ReportCongNoKhachHang  "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                '---------------

                ' them vao csdl
                Dim i As Integer
                Dim strQuery As String
                Dim rs As New ADODB.Recordset

                For i = 0 To Me.dgddebitGrid.RowCount - 2

                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM ReportCongNoKhachHang "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        ''-------------------------
                        Try
                            .Fields("ref").Value = Me.dgddebitGrid.Item("ref", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("sales").Value = "" 'Me.dgddebitGrid.Item("mbl", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("vessel").Value = Me.dgddebitGrid.Item("vessel", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("polpod").Value = Me.dgddebitGrid.Item("polpod", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("etdeta").Value = Me.dgddebitGrid.Item("etdeta", i).Value.ToString
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("price").Value = Me.dgddebitGrid.Item("price", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("vat").Value = Me.dgddebitGrid.Item("vat", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("debit").Value = Me.dgddebitGrid.Item("price_", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("mbl").Value = Me.dgddebitGrid.Item("mbl", i).Value.ToString
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("hbl").Value = Me.dgddebitGrid.Item("hbl", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("company").Value = Me.dgddebitGrid.Item("company_debit", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("item").Value = Me.dgddebitGrid.Item("Item_debit", i).Value.ToString + "(" + Me.dgddebitGrid.Item("remarks_", i).Value.ToString + ")"
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("tongvnd").Value = Me.dgddebitGrid.Item("tongvnd", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("remarks").Value = Me.dgddebitGrid.Item("remarks_", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("tigia").Value = Me.dgddebitGrid.Item("tigia_debit", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("fromto").Value = Me.D1.Text + "-" + Me.T1.Text + "-" + Y1.Text + "/" + Me.N2.Text + "-" + Me.T2.Text + "-" + Y2.Text
                        Catch ex As Exception

                        End Try

                        .Update()
                        .Close()
                    End With

                Next

                '-------------------
                Dim rptDoCument As ReportDocument
                Dim mymargins
                Dim strReportName As String

                rptDoCument = New ReportDocument

                strReportName = "ReportCongNoKhachHang"




                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDoCument.Load(strReportPath)
                'Formatting paper

                ' End If
                Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
                Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
                For Each tbCurrent In rptDoCument.Database.Tables
                    tliCurrent = tbCurrent.LogOnInfo
                    With tliCurrent.ConnectionInfo
                        .ServerName = strServer
                        .UserID = strUserId
                        .Password = strPassword
                        .DatabaseName = strDatabase
                    End With
                    tbCurrent.ApplyLogOnInfo(tliCurrent)
                Next tbCurrent

                rptDoCument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)
                '--------------connect ko can login
                Dim connection As IConnectionInfo
                For Each connection In rptDoCument.DataSourceConnections

                    'Select Case connection.ServerName

                    '    Case strServer
                    connection.SetConnection(strServer, strDatabase, strUserId, strPassword)
                    '        ' connection.SetLogon(strUserId, strPassword)

                    'End Select

                Next
                '------------
                'Set Database Logon to subreport

                Dim subreport As ReportDocument

                For Each subreport In rptDoCument.Subreports

                    For Each connection In subreport.DataSourceConnections

                        'Select Case connection.ServerName

                        '    Case strServer

                        connection.SetConnection(strServer, strDatabase, strUserId, strPassword)

                        'End Select

                    Next

                Next
                '----------------------------------------------------------------------------
                CrystalReportViewer1.ReportSource = rptDoCument
                '------------------------------------------

                rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape

                rptDoCument.Refresh()

                Me.CrystalReportViewer1.Refresh()
                Me.CrystalReportViewer1.Show()

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Me.dgddebitGrid.Rows.Clear()
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            'Agency(-Import)
            'Agency(-Export)
            'Domestic(-Rail)
            'Domestic(-Truck)
            'Logistics(-Customs)
            'Oversea(-Sea - Import)
            'Oversea(-Sea - Export)
            'ACS(-Air - Import)
            'ACS(-Air - Export)
            'ACS(-Sea - Export)
            ' show hcn
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from customer where customer_id='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.txthcn.Text = ds.Tables(0).Rows(0).Item("Remarks_Customer").ToString
            End If
            Dim sodudauky As Double = 0
            Dim phatsinh As Double = 0
            'If Me.chkall.Checked = True Then
            '    ' tinh so du
            '    'cua 3 freight
            '    '1. outboundfreight
            '    sodudauky = getTongXDLogisticsfreight(FindValueID(Me.cbocus, Me.cbocus.Text), "01-jan-2000", NGAY1, "Debit", Me.chkpay.Checked, "outbound", "blob_id", "outboundfreight", "logisticsid")
            '    Me.txtsodudauky.Text = FormatNumber(sodudauky, 0)
            '    phatsinh = getTongXDLogisticsfreight(FindValueID(Me.cbocus, Me.cbocus.Text), NGAY1, NGAY2, "Debit", Me.chkpay.Checked, "outbound", "blob_id", "outboundfreight", "logisticsid")
            '    Me.txtphatsinh.Text = FormatNumber(phatsinh, 0)

            '    Me.txtducuoiky.Text = FormatNumber(sodudauky + phatsinh, 0)
            '    '----------------------------
            'End If
            If Me.chkall.Checked = True Then
                ' If Me.ComboBox2.Text = "Agency-Import" Then
                SOA("Agency-Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "HBL")
                'End If
                'If Me.ComboBox2.Text = "Agency-Export" Then
                SOA("Agency-Export", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "mblmawb")
                'End If
                'SOA("Moving Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")
                ''End If
                ''If Me.ComboBox2.Text = "Agency-Export" Then
                'SOA("Moving Export", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
                'End If
                'If Me.ComboBox2.Text = "Oversea-Sea-Import" Then
                'SOA("ACS-Air-Import", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")
                ''End If

                ''If Me.ComboBox2.Text = "Oversea-Sea-Export" Then
                'SOA("ACS-Air-Export", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
                'End If
                'If Me.ComboBox2.Text = "ACS-Air-Import" Then

                SOA("ACS-Air-Import", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "hbl")

                'End If

                'If Me.ComboBox2.Text = "ACS-Air-Export" Then
                SOA("ACS-Air-Export", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "mblmawb")
                'End If
                'If Me.ComboBox2.Text = "Domestic-Truck" Then
                'SOA("Domestic-Truck", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")

                'End If

                'If Me.ComboBox2.Text = "Logistics-Customs" Then
                SOA("Logistics-Customs", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "ref")

                'End If
            Else
                If Me.ComboBox2.Text = "Agency-Import" Then
                    SOA("Agency-Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "hbl")
                End If
                If Me.ComboBox2.Text = "Agency-Export" Then
                    SOA("Agency-Export", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "mblmawb")
                End If

                'If Me.ComboBox2.Text = "Moving Import" Then
                '    SOA("Moving Import", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")
                'End If
                'If Me.ComboBox2.Text = "Moving Export" Then
                '    SOA("Moving Export", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
                'End If


                'If Me.ComboBox2.Text = "Oversea-Sea-Import" Then
                '    SOA("Oversea-Sea-Import", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA")
                'End If

                'If Me.ComboBox2.Text = "Oversea-Sea-Export" Then
                '    SOA("Oversea-Sea-Export", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")
                'End If
                If Me.ComboBox2.Text = "ACS-Air-Import" Then

                    SOA("ACS-Air-Import", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "ETA", "hbl")

                End If

                If Me.ComboBox2.Text = "ACS-Air-Export" Then
                    SOA("ACS-Air-Export", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "mblmawb")
                End If
                'If Me.ComboBox2.Text = "Domestic-Truck" Then
                '    SOA("Domestic-Truck", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE")

                'End If

                If Me.ComboBox2.Text = "Logistics-Customs" Then
                    SOA("Logistics-Customs", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", FindValueID(Me.cbocus, Me.cbocus.Text), "SAILINGDATE", "ref")

                End If
            End If

            ' tog
            Dim tdebit As Double = 0
            Dim tcredit As Double = 0


            Dim amount1 As Double = 0
            Dim amount2 As Double = 0

            Dim profit As Double = 0

            Dim it As Integer
            Dim tongusd As Double = 0
            Dim tongVND As Double = 0

            For it = 0 To Me.dgddebitGrid.RowCount - 2
                If Me.dgddebitGrid.Item("currency_debit", it).Value.ToString.Trim = "VND" Then
                    Try
                        tongVND += CDbl(Me.dgddebitGrid.Item("price_debit", it).Value.ToString)
                    Catch ex As Exception

                    End Try
                Else 'If Me.dgddebitGrid.Item("currency_debit", it).Value.ToString.Trim = "VND" Then

                    Try
                        tongusd += CDbl(Me.dgddebitGrid.Item("price_debit", it).Value.ToString)
                    Catch ex As Exception

                    End Try

                End If



            Next
            Me.txttotalVND.Text = FormatNumber(tongVND, 0)
            Me.txttotalUSD.Text = FormatNumber(tongusd, 2)

            '' ghi vao
            'Dim currow As Integer
            'Me.dgddebitGrid.Rows.Add(1)
            'currow = dgddebitGrid.RowCount - 2
            'Me.dgddebitGrid.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
            'Me.dgddebitGrid.Rows(currow).DefaultCellStyle.ForeColor = Color.White
            'Me.dgddebitGrid.Item("DESCRIPTION", currow).Value = "Total"
            'Me.dgddebitGrid.Item("debit", currow).Value = FormatNumber(tdebit, 3) 'ds.Tables(0).Rows(i).Item("mblmawb").ToString
            'Me.dgddebitGrid.Item("credit", currow).Value = FormatNumber(tcredit, 3)

            'Me.dgddebitGrid.Item("AMOUNTCOLLECTBYGMDUSD", currow).Value = FormatNumber(amount1, 3)

            'Me.dgddebitGrid.Item("AMOUNTPAIDBYGMDUSD", currow).Value = FormatNumber(amount2, 3)
            'Try

            '    Me.dgddebitGrid.Item("gmdprofit", currow).Value = FormatNumber(profit, 3)
            'Catch ex As Exception

            'End Try


            ''-

            ' kiem neu luoi >1 thi co du lieu
            Try

                Dim cmd As New ADODB.Command
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from salesReportChart  "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try

            Try
                'duyet luoi
                Dim strQuery As String
                Dim rs As New ADODB.Recordset
                Dim i As Integer
                For i = 0 To Me.dgddebitGrid.Rows.Count - 2
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM salesReportChart "

                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()
                        .Fields("id").Value = NewId()




                        Try
                            .Fields("stt").Value = i + 1
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("sanpham").Value = Me.dgddebitGrid.Item("company_debit", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("soluong").Value = Me.dgddebitGrid.Item("tongvnd", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        .Update()
                        rs.Close()
                    End With

                Next

            Catch ex As Exception

            End Try
            ' lay  salesreportchart nhom lai voi sanpham
            Try

                Dim cmd1 As New ADODB.Command
                cmd1.let_ActiveConnection(strconn)
                cmd1.CommandText = "delete from salesReportChartshow  "

                cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Catch ex As Exception

            End Try
            Try
                Dim strQuery As String
                Dim rs As New ADODB.Recordset
                Dim i As Integer
                Dim sqln As String
                Dim dsn As New DataSet
                sqln = "select sanpham,sum(soluong) as tong from salesreportchart group by sanpham "
                dsn = ReadDataSet(sqln)
                If dsn.Tables(0).Rows.Count > 0 Then
                    For i = 0 To dsn.Tables(0).Rows.Count - 1
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM salesReportChartshow "

                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs

                            .AddNew()
                            .Fields("id").Value = NewId()




                            Try
                                .Fields("stt").Value = i + 1
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("sanpham").Value = dsn.Tables(0).Rows(i).Item("sanpham").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("soluong").Value = dsn.Tables(0).Rows(i).Item("tong").ToString
                            Catch ex As Exception

                            End Try
                            .Update()
                            rs.Close()
                        End With
                    Next
                End If
            Catch ex As Exception

            End Try
            ' lay salesreportchartshow

            Dim dss As New DataSet
            dss = ReadDataSet("set dateformat dmy select * from salesreportchartshow")
            ChartControl1.DataSource = dss.Tables(0)

            printReport()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,company + '-' + taxcode as company From customer where continued=1 and company like '%" & Me.TextBox2.Text & "%' or taxcode like '%" & Me.TextBox2.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocus, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub querycombo()
        Try
            Dim id_, id As String
            Dim value_, value As String
            Dim strQuery_, strQuery, strSQL As String


            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company + '-' + taxcode as company from customer where CONTINUED=1 Order by company "
            Me.cbocus.Items.Clear()
            loadDataToObject(Me.cbocus, strQuery, id, value)

            id = "tablename"
            value = "viewername"
            Me.ComboBox2.Items.Clear()


            strSQL = "Select tablename,viewername From listdept order by viewername "
            loadDataToObject(Me.ComboBox2, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmSOAGeneral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'FDIDataSet3.salesreportchartshow' table. You can move, or remove it, as needed.
        '  Me.SalesreportchartshowTableAdapter.Fill(Me.FDIDataSet3.salesreportchartshow)
        Try
            Me.dgddebitGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.dgddebitGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            querycombo()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgddebitGrid_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        Try
            Dim tong As Double = 0
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgddebitGrid.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect.Text = FormatNumber(tong.ToString, 3)
            Catch ex As Exception

            End Try

            'Dim selectedRowCount As Integer = _
            '     Me.dgddebitGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If selectedRowCount = 0 Then
            '    DisplayMessage(True, "Xin ch?n 1 dòng d? li?u ?? thao tác.")
            '    Return
            'End If
            'If selectedRowCount > 0 Then
            '    Dim sb As New System.Text.StringBuilder()
            '    Dim i As Integer
            '    For i = 0 To selectedRowCount - 1

            '        tong += CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit_lc", Me.dgdCreditGrid.SelectedRows(i).Index).ToString)
            '    Next i
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' xoatable
            '---------------------------
            'Dim Con As New SqlClient.SqlConnection(strconnDG)
            'Dim sqldebit, strQuery As String
            'Dim CmdSelect As New SqlClient.SqlCommand(sqldebit, Con)
            'Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            'Dim cmd As New ADODB.Command
            'cmd.let_ActiveConnection(strconn)
            'cmd.CommandText = "delete from frmPrintSOAGeneral  "

            'cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            ' '' them
            'Dim rs As New ADODB.Recordset
            'Dim i As Integer
            'Dim tongdebit As Double = 0
            'Dim tongcredit As Double = 0


            'If Me.dgddebitGrid.RowCount > 0 Then

            '    For i = 0 To Me.dgddebitGrid.RowCount - 3

            '        Try
            '            tongdebit += CDbl(Me.dgddebitGrid.Item("debit", i).Value)
            '            tongcredit += CDbl(Me.dgddebitGrid.Item("credit", i).Value)
            '        Catch ex As Exception

            '        End Try
            '        strQuery = "SELECT * "
            '        strQuery = strQuery & "FROM frmPrintSOAGeneral "
            '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            '        With rs

            '            .AddNew()


            '            '-------------------------
            '            .Fields("no").Value = Me.dgddebitGrid.Item("no", i).Value

            '            .Fields("invoiceno").Value = Me.dgddebitGrid.Item("invoiceno", i).Value

            '            .Fields("mblmawb").Value = Me.dgddebitGrid.Item("mblmawb", i).Value

            '            .Fields("hblhawb").Value = Me.dgddebitGrid.Item("hblhawb", i).Value
            '            .Fields("dest").Value = Me.dgddebitGrid.Item("dest", i).Value
            '            .Fields("description").Value = Me.dgddebitGrid.Item("description", i).Value
            '            Try
            '                .Fields("debit").Value = Me.dgddebitGrid.Item("debit", i).Value
            '            Catch ex As Exception
            '                .Fields("debit").Value = 0
            '            End Try
            '            Try
            '                .Fields("credit").Value = Me.dgddebitGrid.Item("credit", i).Value
            '            Catch ex As Exception
            '                .Fields("credit").Value = 0
            '            End Try
            '            Try
            '                .Fields("AMOUNTCOLLECTBYGMDUSD").Value = Me.dgddebitGrid.Item("AMOUNTCOLLECTBYGMDUSD", i).Value
            '            Catch ex As Exception
            '                .Fields("AMOUNTCOLLECTBYGMDUSD").Value = 0
            '            End Try
            '            Try
            '                .Fields("AMOUNTPAIDBYGMDUSD").Value = Me.dgddebitGrid.Item("AMOUNTPAIDBYGMDUSD", i).Value
            '            Catch ex As Exception
            '                .Fields("AMOUNTPAIDBYGMDUSD").Value = 0
            '            End Try

            '            .Fields("GMDINVOICENO").Value = Me.dgddebitGrid.Item("GMDINVOICENO", i).Value
            '            Try
            '                .Fields("GMDPROFIT").Value = Me.dgddebitGrid.Item("GMDPROFIT", i).Value
            '            Catch ex As Exception
            '                .Fields("GMDPROFIT").Value = 0
            '            End Try




            '            .Update()
            '        End With
            '        rs.Close()
            '    Next
            'End If
            ''  ds.Tables.Add(dtdebit)
            'frmPrintSOAGeneral.Show()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgddebitGrid_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            Dim tong As Double = 0
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgddebitGrid.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect.Text = FormatNumber(tong.ToString, 3)
            Catch ex As Exception

            End Try

            'Dim selectedRowCount As Integer = _
            '     Me.dgddebitGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If selectedRowCount = 0 Then
            '    DisplayMessage(True, "Xin ch?n 1 dòng d? li?u ?? thao tác.")
            '    Return
            'End If
            'If selectedRowCount > 0 Then
            '    Dim sb As New System.Text.StringBuilder()
            '    Dim i As Integer
            '    For i = 0 To selectedRowCount - 1

            '        tong += CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit_lc", Me.dgdCreditGrid.SelectedRows(i).Index).ToString)
            '    Next i
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgddebitGrid_CellContentClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgddebitGrid.CellContentClick
        Try
            Dim tong As Double = 0
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgddebitGrid.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect.Text = FormatNumber(tong.ToString, 3)
            Catch ex As Exception

            End Try

            'Dim selectedRowCount As Integer = _
            '     Me.dgddebitGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If selectedRowCount = 0 Then
            '    DisplayMessage(True, "Xin ch?n 1 dòng d? li?u ?? thao tác.")
            '    Return
            'End If
            'If selectedRowCount > 0 Then
            '    Dim sb As New System.Text.StringBuilder()
            '    Dim i As Integer
            '    For i = 0 To selectedRowCount - 1

            '        tong += CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit_lc", Me.dgdCreditGrid.SelectedRows(i).Index).ToString)
            '    Next i
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgddebitGrid_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgddebitGrid.MouseUp
        Try
            Dim tong As Double = 0
            If Me.dgddebitGrid.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.dgddebitGrid.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect.Text = FormatNumber(tong.ToString, 3)
            Catch ex As Exception

            End Try

            'Dim selectedRowCount As Integer = _
            '     Me.dgddebitGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If selectedRowCount = 0 Then
            '    DisplayMessage(True, "Xin ch?n 1 dòng d? li?u ?? thao tác.")
            '    Return
            'End If
            'If selectedRowCount > 0 Then
            '    Dim sb As New System.Text.StringBuilder()
            '    Dim i As Integer
            '    For i = 0 To selectedRowCount - 1

            '        tong += CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit_lc", Me.dgdCreditGrid.SelectedRows(i).Index).ToString)
            '    Next i
            'End If
        Catch ex As Exception

        End Try
    End Sub
End Class