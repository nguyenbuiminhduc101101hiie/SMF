Public Class frmAgentReport

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' inbound 
            Dim i, j As Integer

            '---
            Dim cmd As New ADODB.Command
            Dim rs As New ADODB.Recordset
            Dim sqlCus As String
            Dim dsCus As New DataSet
            If Me.chkall.Checked = True Then

                ' xoa smf_tamagentreport
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from smf_tamagentreport "
                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                '---------------------------

                Dim sqlin As String
                Dim dsin As New DataSet

                ' lay tat cac cac HBL theo dk ngay
                sqlin = "select *,inboundfreight.tigia as tg,inboundfreight.currency as cur from inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid where convert(datetime,datereport) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and ref like '%" & Me.cboChinhanh.Text & "%' and inboundfreight.customerid is not null  and os=0 " ' loai bo chi ho 3/8
                dsin = ReadDataSet(sqlin)
                If dsin.Tables(0).Rows.Count > 0 Then
                    ' lay tung phi de kiem tra
                    '
                    For i = 0 To dsin.Tables(0).Rows.Count - 1
                        ' lay moi dong phi ra kiem tra cusID voi list cus
                        ' If Me.chkAgent.Checked = True Then
                        If Me.chkDaily.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode like '%agent%'"
                        End If
                        If Me.chkcustomer.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode not like '%agent%'"
                        End If

                        'Else
                        'sqlCus = "select * from customer where continued=1"
                        'End If
                        dsCus = ReadDataSet(sqlCus)
                        If dsCus.Tables(0).Rows.Count > 0 Then
                            ' lay tung cusid kiem tra
                            For j = 0 To dsCus.Tables(0).Rows.Count - 1
                                ' j chaoy chobien CusID, I chay cho bien Freght
                                If dsCus.Tables(0).Rows(j).Item("Customer_id").ToString = dsin.Tables(0).Rows(i).Item("Customerid").ToString Then
                                    ' neu = thi lay so lieuchen vao smf_tamagentreport
                                    ' neu debit thi them vao debit hay nguoc lai
                                    If dsin.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try

                                            'Try
                                            '    If dsin.Tables(0).Rows(i).Item("hbl").ToString = dsin.Tables(0).Rows(i - 1).Item("hbl").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try

                                            .Fields("house").Value = dsin.Tables(0).Rows(i).Item("hbl").ToString
                                            If UCase(dsin.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("debit").Value = FormatNumber(dsin.Tables(0).Rows(i).Item("price").ToString / dsin.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("debit").Value = dsin.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If

                                            .Update()
                                        End With
                                        rs.Close()
                                    Else
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try

                                            'Try
                                            '    If dsin.Tables(0).Rows(i).Item("hbl").ToString = dsin.Tables(0).Rows(i - 1).Item("hbl").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            .Fields("house").Value = dsin.Tables(0).Rows(i).Item("hbl").ToString
                                            If UCase(dsin.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then
                                                .Fields("credit").Value = FormatNumber(dsin.Tables(0).Rows(i).Item("price").ToString / dsin.Tables(0).Rows(i).Item("tg").ToString, 2)

                                            Else
                                                .Fields("credit").Value = FormatNumber(dsin.Tables(0).Rows(i).Item("price").ToString / dsin.Tables(0).Rows(i).Item("tg").ToString, 2)

                                            End If
                                            '  .Fields("credit").Value = dsin.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()

                                    End If
                                Else

                                End If
                            Next
                        End If
                    Next
                End If
                '----------------
                Dim sqlout As String
                Dim dsout As New DataSet

                ' lay tat cac cac HBL theo dk ngay
                sqlout = "select *,outboundfreight.tigia as tg,outboundfreight.currency as cur  from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid where convert(datetime,datereport) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and ref like '%" & Me.cboChinhanh.Text & "%' and outboundfreight.customerid is not null  and os=0  "
                dsout = ReadDataSet(sqlout)
                If dsout.Tables(0).Rows.Count > 0 Then
                    ' lay tung phi de kiem tra
                    '
                    For i = 0 To dsout.Tables(0).Rows.Count - 1
                        ' lay moi dong phi ra kiem tra cusID voi list cus
                        ' If Me.chkAgent.Checked = True Then
                        If Me.chkDaily.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode like '%agent%'"
                        End If
                        If Me.chkcustomer.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode not like '%agent%'"
                        End If
                        'Else
                        '    sqlCus = "select * from customer where continued=1"
                        'End If
                        dsCus = ReadDataSet(sqlCus)
                        If dsCus.Tables(0).Rows.Count > 0 Then
                            ' lay tung cusid kiem tra
                            For j = 0 To dsCus.Tables(0).Rows.Count - 1
                                ' j chaoy chobien CusID, I chay cho bien Freght
                                If dsCus.Tables(0).Rows(j).Item("Customer_id").ToString = dsout.Tables(0).Rows(i).Item("Customerid").ToString Then
                                    ' neu = thi lay so lieuchen vao smf_tamagentreport
                                    ' neu debit thi them vao debit hay nguoc lai
                                    If dsout.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            '         .Fields("shipment").Value = dsout.Tables(0).Rows(i).Item("mblmawb").ToString + ","

                                            'Try
                                            '    If dsout.Tables(0).Rows(i).Item("mblmawb").ToString = dsout.Tables(0).Rows(i - 1).Item("mblmawb").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            If UCase(dsout.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("debit").Value = FormatNumber(dsout.Tables(0).Rows(i).Item("price").ToString / dsout.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("debit").Value = dsout.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If
                                            '       .Fields("debit").Value = dsout.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()
                                    Else
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            'Try
                                            '    If dsout.Tables(0).Rows(i).Item("mblmawb").ToString = dsout.Tables(0).Rows(i - 1).Item("mblmawb").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            '.Fields("shipment").Value = dsout.Tables(0).Rows(i).Item("mblmawb").ToString + ","

                                            'End Try
                                            If UCase(dsout.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("credit").Value = FormatNumber(dsout.Tables(0).Rows(i).Item("price").ToString / dsout.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("credit").Value = dsout.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If


                                            ' .Fields("credit").Value = dsout.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()

                                    End If
                                Else

                                End If
                            Next
                        End If
                    Next
                End If
                '''logistics
                '----------------
                Dim sqllog As String
                Dim dslog As New DataSet

                ' lay tat cac cac HBL theo dk ngay
                sqllog = "select *,logisticsfreight.tigia as tg,logisticsfreight.currency as cur from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid where convert(datetime,datereport) between '" & ddMMMyyyy(Me.dtpFrom.Value.Date) & "' and '" & ddMMMyyyy(Me.dtpto.Value.Date) & "' and ref like '%" & Me.cboChinhanh.Text & "%' and logisticsfreight.customerid is not null  and  os=0  "
                dslog = ReadDataSet(sqllog)
                If dslog.Tables(0).Rows.Count > 0 Then
                    ' lay tung phi de kiem tra
                    '
                    For i = 0 To dslog.Tables(0).Rows.Count - 1
                        ' lay moi dong phi ra kiem tra cusID voi list cus
                        'If Me.chkAgent.Checked = True Then
                        If Me.chkDaily.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode like '%agent%'"
                        End If
                        If Me.chkcustomer.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode not like '%agent%'"
                        End If
                        'Else
                        '    sqlCus = "select * from customer where continued=1"
                        'End If
                        dsCus = ReadDataSet(sqlCus)
                        If dsCus.Tables(0).Rows.Count > 0 Then
                            ' lay tung cusid kiem tra
                            For j = 0 To dsCus.Tables(0).Rows.Count - 1
                                ' j chaoy chobien CusID, I chay cho bien Freght
                                If dsCus.Tables(0).Rows(j).Item("Customer_id").ToString = dslog.Tables(0).Rows(i).Item("Customerid").ToString Then
                                    ' neu = thi lay so lieuchen vao smf_tamagentreport
                                    ' neu debit thi them vao debit hay nguoc lai
                                    If dslog.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            ' .Fields("shipment").Value = dslog.Tables(0).Rows(i).Item("ref").ToString + ","
                                            'Try
                                            '    If dsin.Tables(0).Rows(i).Item("ref").ToString = dsin.Tables(0).Rows(i - 1).Item("ref").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            If UCase(dslog.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then
                                                .Fields("debit").Value = FormatNumber(dslog.Tables(0).Rows(i).Item("price").ToString / dslog.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("debit").Value = dslog.Tables(0).Rows(i).Item("price").ToString
                                            End If



                                            .Update()
                                        End With
                                        rs.Close()
                                    Else
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            ' .Fields("shipment").Value = dslog.Tables(0).Rows(i).Item("ref").ToString + ","
                                            'Try
                                            '    If dslog.Tables(0).Rows(i).Item("ref").ToString = dslog.Tables(0).Rows(i - 1).Item("ref").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception

                                            'End Try

                                            If UCase(dslog.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then
                                                .Fields("credit").Value = FormatNumber(dslog.Tables(0).Rows(i).Item("price").ToString / dslog.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("credit").Value = dslog.Tables(0).Rows(i).Item("price").ToString
                                            End If


                                            ' .Fields("credit").Value = dslog.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()

                                    End If
                                Else

                                End If
                            Next
                        End If
                    Next
                End If
                ''' 
            Else
                'Dim i, j As Integer

                ''---
                'Dim cmd As New ADODB.Command
                'Dim rs As New ADODB.Recordset
                'Dim sqlCus As String
                'Dim dsCus As New DataSet
                ' xoa smf_tamagentreport
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from smf_tamagentreport "
                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                '---------------------------

                Dim sqlin As String
                Dim dsin As New DataSet

                ' lay tat cac cac HBL theo dk ngay
                sqlin = "select *,inboundfreight.tigia as tg,inboundfreight.currency as cur from inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '" & Me.cboChinhanh.Text & "%' and inboundfreight.customerid is not null and paycheck= '" & Me.chkpay.Checked & "'  and os=0  "
                dsin = ReadDataSet(sqlin)
                If dsin.Tables(0).Rows.Count > 0 Then
                    ' lay tung phi de kiem tra
                    '
                    For i = 0 To dsin.Tables(0).Rows.Count - 1
                        ' lay moi dong phi ra kiem tra cusID voi list cus
                        ' If Me.chkAgent.Checked = True Then
                        If Me.chkDaily.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode like '%agent%'"
                        End If
                        If Me.chkcustomer.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode not like '%agent%'"
                        End If
                        'Else
                        'sqlCus = "select * from customer where continued=1"
                        'End If
                        dsCus = ReadDataSet(sqlCus)
                        If dsCus.Tables(0).Rows.Count > 0 Then
                            ' lay tung cusid kiem tra
                            For j = 0 To dsCus.Tables(0).Rows.Count - 1
                                ' j chaoy chobien CusID, I chay cho bien Freght
                                If dsCus.Tables(0).Rows(j).Item("Customer_id").ToString = dsin.Tables(0).Rows(i).Item("Customerid").ToString Then
                                    ' neu = thi lay so lieuchen vao smf_tamagentreport
                                    ' neu debit thi them vao debit hay nguoc lai
                                    If dsin.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try

                                            'Try
                                            '    If dsin.Tables(0).Rows(i).Item("hbl").ToString = dsin.Tables(0).Rows(i - 1).Item("hbl").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try

                                            .Fields("house").Value = dsin.Tables(0).Rows(i).Item("hbl").ToString

                                            If UCase(dsin.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("debit").Value = dsin.Tables(0).Rows(i).Item("price").ToString / dsin.Tables(0).Rows(i).Item("tg").ToString
                                            Else
                                                .Fields("debit").Value = dsin.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If


                                            ' .Fields("debit").Value = dsin.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()
                                    Else
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try

                                            'Try
                                            '    If dsin.Tables(0).Rows(i).Item("hbl").ToString = dsin.Tables(0).Rows(i - 1).Item("hbl").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            .Fields("house").Value = dsin.Tables(0).Rows(i).Item("hbl").ToString


                                            If UCase(dsin.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("credit").Value = FormatNumber(dsin.Tables(0).Rows(i).Item("price").ToString / dsin.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("credit").Value = dsin.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If


                                            '.Fields("credit").Value = dsin.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()

                                    End If
                                Else

                                End If
                            Next
                        End If
                    Next
                End If
                '----------------
                Dim sqlout As String
                Dim dsout As New DataSet

                ' lay tat cac cac HBL theo dk ngay
                sqlout = "select *,outboundfreight.tigia as tg,outboundfreight.currency as cur from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '" & Me.cboChinhanh.Text & "%' and outboundfreight.customerid is not null  and paycheck= '" & Me.chkpay.Checked & "'  and os=0 "
                dsout = ReadDataSet(sqlout)
                If dsout.Tables(0).Rows.Count > 0 Then
                    ' lay tung phi de kiem tra
                    '
                    For i = 0 To dsout.Tables(0).Rows.Count - 1
                        ' lay moi dong phi ra kiem tra cusID voi list cus
                        ' If Me.chkAgent.Checked = True Then
                        If Me.chkDaily.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode like '%agent%'"
                        End If
                        If Me.chkcustomer.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode not like '%agent%'"
                        End If
                        'Else
                        '    sqlCus = "select * from customer where continued=1"
                        'End If
                        dsCus = ReadDataSet(sqlCus)
                        If dsCus.Tables(0).Rows.Count > 0 Then
                            ' lay tung cusid kiem tra
                            For j = 0 To dsCus.Tables(0).Rows.Count - 1
                                ' j chaoy chobien CusID, I chay cho bien Freght
                                If dsCus.Tables(0).Rows(j).Item("Customer_id").ToString = dsout.Tables(0).Rows(i).Item("Customerid").ToString Then
                                    ' neu = thi lay so lieuchen vao smf_tamagentreport
                                    ' neu debit thi them vao debit hay nguoc lai
                                    If dsout.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            '         .Fields("shipment").Value = dsout.Tables(0).Rows(i).Item("mblmawb").ToString + ","

                                            'Try
                                            '    If dsout.Tables(0).Rows(i).Item("mblmawb").ToString = dsout.Tables(0).Rows(i - 1).Item("mblmawb").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try

                                            If UCase(dsout.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("debit").Value = FormatNumber(dsout.Tables(0).Rows(i).Item("price").ToString / dsout.Tables(0).Rows(i).Item("tg").ToString)
                                            Else
                                                .Fields("debit").Value = dsout.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If


                                            '  .Fields("debit").Value = dsout.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()
                                    Else
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            'Try
                                            '    If dsout.Tables(0).Rows(i).Item("mblmawb").ToString = dsout.Tables(0).Rows(i - 1).Item("mblmawb").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            '.Fields("shipment").Value = dsout.Tables(0).Rows(i).Item("mblmawb").ToString + ","

                                            If UCase(dsout.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("credit").Value = dsout.Tables(0).Rows(i).Item("price").ToString / dsout.Tables(0).Rows(i).Item("tg").ToString
                                            Else
                                                .Fields("credit").Value = dsout.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If



                                            '   .Fields("credit").Value = dsout.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()

                                    End If
                                Else

                                End If
                            Next
                        End If
                    Next
                End If
                '''logistics
                '----------------
                Dim sqllog As String
                Dim dslog As New DataSet

                ' lay tat cac cac HBL theo dk ngay
                sqllog = "select *,logisticsfreight.tigia as tg,logisticsfreight.currency as cur   from logistics left join logisticsfreight on logistics.blob_id=logisticsfreight.logisticsid where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '" & Me.cboChinhanh.Text & "%' and logisticsfreight.customerid is not null and paycheck= '" & Me.chkpay.Checked & "'  and os=0 "
                dslog = ReadDataSet(sqllog)
                If dslog.Tables(0).Rows.Count > 0 Then
                    ' lay tung phi de kiem tra
                    '
                    For i = 0 To dslog.Tables(0).Rows.Count - 1
                        ' lay moi dong phi ra kiem tra cusID voi list cus
                        'If Me.chkAgent.Checked = True Then
                        If Me.chkDaily.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode like '%agent%'"
                        End If
                        If Me.chkcustomer.Checked = True Then
                            sqlCus = "select * from customer where continued=1 and maincode not like '%agent%'"
                        End If
                        'Else
                        '    sqlCus = "select * from customer where continued=1"
                        'End If
                        dsCus = ReadDataSet(sqlCus)
                        If dsCus.Tables(0).Rows.Count > 0 Then
                            ' lay tung cusid kiem tra
                            For j = 0 To dsCus.Tables(0).Rows.Count - 1
                                ' j chaoy chobien CusID, I chay cho bien Freght
                                If dsCus.Tables(0).Rows(j).Item("Customer_id").ToString = dslog.Tables(0).Rows(i).Item("Customerid").ToString Then
                                    ' neu = thi lay so lieuchen vao smf_tamagentreport
                                    ' neu debit thi them vao debit hay nguoc lai
                                    If dslog.Tables(0).Rows(i).Item("debitcredit").ToString = "Debit" Then
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            ' .Fields("shipment").Value = dslog.Tables(0).Rows(i).Item("ref").ToString + ","
                                            'Try
                                            '    If dsin.Tables(0).Rows(i).Item("ref").ToString = dsin.Tables(0).Rows(i - 1).Item("ref").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception
                                            '    .Fields("shipment").Value = 1
                                            'End Try
                                            If UCase(dslog.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("debit").Value = FormatNumber(dslog.Tables(0).Rows(i).Item("price").ToString / dslog.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("debit").Value = dslog.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If


                                            '.Fields("debit").Value = dslog.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()
                                    Else
                                        rs.Open("select top 1 * from smf_tamagentreport", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)


                                        With rs

                                            .AddNew()
                                            .Fields("id").Value = NewId()
                                            Try
                                                .Fields("customerid").Value = "{" + dsCus.Tables(0).Rows(j).Item("Customer_id").ToString + "}"
                                            Catch ex As Exception
                                                .Fields("customerid").Value = DefaultValue '"{" + ds.Tables(0).Rows(i).Item("customerid").ToString + "}"
                                            End Try
                                            ' .Fields("shipment").Value = dslog.Tables(0).Rows(i).Item("ref").ToString + ","
                                            'Try
                                            '    If dslog.Tables(0).Rows(i).Item("ref").ToString = dslog.Tables(0).Rows(i - 1).Item("ref").ToString Then
                                            '        .Fields("shipment").Value = 0
                                            '    Else
                                            '        .Fields("shipment").Value = 1
                                            '    End If
                                            'Catch ex As Exception

                                            'End Try
                                            If UCase(dslog.Tables(0).Rows(i).Item("cur").ToString.Trim) = "VND" Then

                                                .Fields("credit").Value = FormatNumber(dslog.Tables(0).Rows(i).Item("price").ToString / dslog.Tables(0).Rows(i).Item("tg").ToString, 2)
                                            Else
                                                .Fields("credit").Value = dslog.Tables(0).Rows(i).Item("price").ToString '/ dsin.Tables(0).Rows(i).Item("tg").ToString

                                            End If



                                            ' .Fields("credit").Value = dslog.Tables(0).Rows(i).Item("price").ToString
                                            .Update()
                                        End With
                                        rs.Close()

                                    End If
                                Else

                                End If
                            Next
                        End If
                    Next
                End If
                ''' 
            End If



            ' show 
            Me.DataGridView1.Rows.Clear()
            Dim demIn As Integer = 0
            Dim demOut As Integer = 0
            ' luu y logitics khong co dai ly.
            Dim currow As Integer
            Dim sqlshow As String
            Dim dsshow As New DataSet
            sqlshow = "select customerid,sum(shipment) as lohang,sum(debit) as thu,sum(credit) as chi from smf_tamagentreport group by customerid "
            dsshow = ReadDataSet(sqlshow)
            If dsshow.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsshow.Tables(0).Rows.Count - 1
                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2

                    Me.DataGridView1.Item("no", currow).Value = i + 1 'dsoShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                    Dim ten As String
                    Dim dsten As New DataSet
                    ten = "select * from customer where customer_id='" & dsshow.Tables(0).Rows(i).Item("customerid").ToString & "' "
                    dsten = ReadDataSet(ten)
                    If dsten.Tables(0).Rows.Count > 0 Then
                        Me.DataGridView1.Item("company", currow).Value = dsten.Tables(0).Rows(0).Item("company").ToString
                        Me.DataGridView1.Item("country", currow).Value = dsten.Tables(0).Rows(0).Item("country").ToString
                    End If
                    ' dem so shipment
                    Dim sqlShipment As String
                    Dim dsShipmentIn As New DataSet
                    sqlShipment = "select * from inbound where agentid='" & dsshow.Tables(0).Rows(i).Item("customerid").ToString & "' "
                    dsShipmentIn = ReadDataSet(sqlShipment)
                    demIn = dsShipmentIn.Tables(0).Rows.Count

                    Dim dsShipmentOut As New DataSet
                    sqlShipment = "select * from outbound where agentid='" & dsshow.Tables(0).Rows(i).Item("customerid").ToString & "' "
                    dsShipmentOut = ReadDataSet(sqlShipment)
                    demOut = dsShipmentOut.Tables(0).Rows.Count


                    ' Me.DataGridView1.Item("company", currow).Value = dsshow.Tables(0).Rows(i).Item("customerid").ToString
                    Me.DataGridView1.Item("TotalShipment", currow).Value = demIn + demOut
                    Me.DataGridView1.Item("totalamountdebit", currow).Value = dsshow.Tables(0).Rows(i).Item("thu").ToString
                    Me.DataGridView1.Item("totalamountcredit", currow).Value = dsshow.Tables(0).Rows(i).Item("chi").ToString

                Next

            End If
            ' tong 
            Dim k As Integer
            currow += 1
            For k = 0 To Me.DataGridView1.Rows.Count - 2
                Try
                    Me.DataGridView1.Item("TotalShipment", currow).Value += CDbl(dsshow.Tables(0).Rows(k).Item("lohang").ToString)
                Catch ex As Exception

                End Try
                Try
                    Me.DataGridView1.Item("totalamountdebit", currow).Value += CDbl(dsshow.Tables(0).Rows(k).Item("thu").ToString)
                Catch ex As Exception

                End Try
                Try
                    Me.DataGridView1.Item("totalamountcredit", currow).Value += CDbl(dsshow.Tables(0).Rows(k).Item("chi").ToString)
                Catch ex As Exception

                End Try

            Next
            Try
                Me.DataGridView1.Item("TotalShipment", currow).Value = FormatNumber(Me.DataGridView1.Item("TotalShipment", currow).Value, 2)
                Me.DataGridView1.Item("totalamountdebit", currow).Value = FormatNumber(Me.DataGridView1.Item("totalamountdebit", currow).Value, 2)
                Me.DataGridView1.Item("totalamountcredit", currow).Value = FormatNumber(Me.DataGridView1.Item("totalamountcredit", currow).Value, 2)
            Catch ex As Exception

            End Try
            InsertAutoNumberToGrid(Me.DataGridView1)
            '-----------------------------------------------------------------------------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmAgentReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            'Me.cboChinhanh.Items.Clear()
            'Me.cboChinhanh.Text = ""
            'If gBranch = "" Then

            '    Me.cboChinhanh.Items.Add("ALL")
            '    Me.cboChinhanh.Items.Add("HCM")
            '    Me.cboChinhanh.Items.Add("HPH")

            'ElseIf gBranch = "SGN" Then

            '    Me.cboChinhanh.Items.Add("HCM")

            'ElseIf gBranch = "HPH" Then

            '    Me.cboChinhanh.Items.Add("HPH")

            'End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Try
                If Me.DataGridView1.RowCount = 0 Then
                    Return
                End If
                'SetMenu(False)
                ExportExecel(Me.DataGridView1, Me)
                'SetMenu(True)
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_ContextMenuChanged(sender As Object, e As EventArgs) Handles Button1.ContextMenuChanged

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim url As String = "https://youtu.be/rQyfJpY8tv4"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub
End Class