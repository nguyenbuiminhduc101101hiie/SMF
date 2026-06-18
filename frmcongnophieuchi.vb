Public Class frmcongnophieuchi
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlc As String
            Dim dsc As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -65281
            Dim dongtang As Integer


            '-----------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------

            sql = "select blob_id,mblmawb,sum(price) as tongdebit from outboundfreight left join outbound on outbound.blob_id=outboundfreight.outboundid where convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and debitcredit='Credit' group by blob_id,mblmawb "



            ds = ReadDataSet(sql)
            Dim debit, debitphaithu As Double
            ' show account
            Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)
                    debitphaithu = 0
                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("no", currow).Value = i.ToString

                    Me.dgData.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString

                    Me.dgData.Item("debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("tongdebit").ToString, 2)
                    debit = CDbl(ds.Tables(0).Rows(i).Item("tongdebit").ToString)
                    ' show ref
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from outbound where mblmawb ='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "'"
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        Me.dgData.Item("ref", currow).Value = dsref.Tables(0).Rows(0).Item("ref").ToString
                    End If
                    '--------------------
                    mau -= 100
                    ' vong lap con
                    sqlc = "select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "' and continued=1  "


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
                            Try
                                Me.dgData.Item("invoiceno", dongtang).Value = dsc.Tables(0).Rows(j).Item("sophieuchi").ToString
                            Catch ex As Exception

                            End Try



                            '----------------------------------------------------------------------------
                            Try
                                Me.dgData.Item("dateinvoice", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngay").ToString 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            Try
                                Me.dgData.Item("sotien", dongtang).Value = FormatNumber(dsc.Tables(0).Rows(j).Item("sotien").ToString, 2) 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                                debitphaithu += CDbl(dsc.Tables(0).Rows(j).Item("sotien").ToString)
                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("hbl", dongtang).Value = "Sub Total"
                    Me.dgData.Item("debit", dongtang).Value = FormatNumber(debit, 2)
                    Me.dgData.Item("sotien", dongtang).Value = FormatNumber(debitphaithu, 2)
                    Me.dgData.Item("sotienphaithu", dongtang).Value = FormatNumber(debit - debitphaithu, 2)
                    'Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    'Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    'Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    'Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    'Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    'Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    'Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    'Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next

            End If ' het hang FF

            '----hang nhap
            '-----------------------------------------------------------------------------------------------------------------------

            sql = "select blib_id,hbl,sum(price) as tongdebit from inboundfreight left join inbound on inbound.blib_id=inboundfreight.inboundid where convert(datetime,ETA) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and debitcredit='Credit' group by blib_id,hbl "



            ds = ReadDataSet(sql)
            Dim debitInbound, debitphaithuInbound As Double
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)
                    debitphaithuInbound = 0
                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("no", currow).Value = i.ToString

                    Me.dgData.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString

                    Me.dgData.Item("debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("tongdebit").ToString, 2)
                    ' show ref
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from inbound where hbl ='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "'"
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        Me.dgData.Item("ref", currow).Value = dsref.Tables(0).Rows(0).Item("ref").ToString
                    End If
                    '--------------------

                    debitInbound = CDbl(ds.Tables(0).Rows(i).Item("tongdebit").ToString)

                    mau -= 100
                    ' vong lap con
                    sqlc = "select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "' and continued=1  "


                    dsc = ReadDataSet(sqlc)
                    dongtang = currow + 1

                    '----------------------------------
                    If dsc.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            Me.dgData.Rows.Add(1)
                            Me.dgData.Item("no", dongtang).Value = j + 1
                            Try
                                Me.dgData.Item("invoiceno", dongtang).Value = dsc.Tables(0).Rows(j).Item("sophieuchi").ToString
                            Catch ex As Exception

                            End Try



                            '----------------------------------------------------------------------------
                            Try
                                Me.dgData.Item("dateinvoice", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngay").ToString 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            Try
                                Me.dgData.Item("sotien", dongtang).Value = FormatNumber(dsc.Tables(0).Rows(j).Item("sotien").ToString, 2) 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                                debitphaithuInbound += CDbl(dsc.Tables(0).Rows(j).Item("sotien").ToString)
                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("hbl", dongtang).Value = "Sub Total"
                    Me.dgData.Item("debit", dongtang).Value = FormatNumber(debitInbound, 2)
                    Me.dgData.Item("sotien", dongtang).Value = FormatNumber(debitphaithuInbound, 2)
                    Me.dgData.Item("sotienphaithu", dongtang).Value = FormatNumber(debitInbound - debitphaithuInbound, 2)
                    'Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    'Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    'Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    'Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    'Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    'Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    'Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    'Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next

            End If ' het hang FF
            '------------------------------------------------
            ' Logistics
            sql = "select blob_id,ref,sum(price) as tongdebit from Logisticsfreight left join Logistics on Logistics.blob_id=Logisticsfreight.Logisticsid where convert(datetime,sailingdate) between '" & Me.dtpFromETD.Value.Date & "' and '" & Me.dtpToETD.Value.Date & "' and debitcredit='Credit' group by blob_id,ref "



            ds = ReadDataSet(sql)
            Dim debitLogistics, debitphaithuLogistics As Double
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)
                    debitphaithuLogistics = 0
                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("no", currow).Value = i.ToString

                    Me.dgData.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    ' show ref
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from logistics where ref ='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'"
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        Me.dgData.Item("ref", currow).Value = dsref.Tables(0).Rows(0).Item("ref").ToString
                    End If
                    '--------------------
                    Me.dgData.Item("debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("tongdebit").ToString, 2)
                    debitLogistics = CDbl(ds.Tables(0).Rows(i).Item("tongdebit").ToString)

                    mau -= 100
                    ' vong lap con
                    sqlc = "select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'  and continued=1  "


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
                            Try
                                Me.dgData.Item("invoiceno", dongtang).Value = dsc.Tables(0).Rows(j).Item("sophieuchi").ToString
                            Catch ex As Exception

                            End Try



                            '----------------------------------------------------------------------------
                            Try
                                Me.dgData.Item("dateinvoice", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngay").ToString 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            Try
                                Me.dgData.Item("sotien", dongtang).Value = FormatNumber(dsc.Tables(0).Rows(j).Item("sotien").ToString, 2) 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                                debitphaithuLogistics += CDbl(dsc.Tables(0).Rows(j).Item("sotien").ToString)
                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("hbl", dongtang).Value = "Sub Total"
                    Me.dgData.Item("debit", dongtang).Value = FormatNumber(debitLogistics, 2)
                    Me.dgData.Item("sotien", dongtang).Value = FormatNumber(debitphaithuLogistics, 2)
                    Me.dgData.Item("sotienphaithu", dongtang).Value = FormatNumber(debitLogistics - debitphaithuLogistics, 2)
                    'Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    'Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    'Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    'Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    'Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    'Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    'Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    'Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


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
        'Me.cboagencyname.Items.Clear()
        ''id = "agency_id"
        ''value = "agencyname"
        ''strSQL = "Select agency_id,  agencyname From agency  where continued=1 Order By agencyname"
        ''loadDataToObject_(Me.cboagencyname, strSQL, id, value)

        'id = "Customer_id"
        'value = "Company"
        'strSQL = "Select Customer_id,  company From customer  where continued=1 Order By company"
        'loadDataToObject_(Me.cboagencyname, strSQL, id, value)

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlc As String
            Dim dsc As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -65281
            Dim dongtang As Integer


            '-----------------------------------------------------------------------------------------------------------------------
            '-----------------------------------------------------------------------------------------------------------------------

            sql = "select blob_id,mblmawb,sum(price) as tongdebit from outboundfreight left join outbound on outbound.blob_id=outboundfreight.outboundid where (mblmawb like '%" & Me.txthbl.Text & "%' or ref like '%" & Me.txthbl.Text & "%') and debitcredit='Credit' group by blob_id,mblmawb "



            ds = ReadDataSet(sql)
            Dim debit, debitphaithu As Double
            ' show account
            Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)
                    debitphaithu = 0
                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("no", currow).Value = i.ToString

                    Me.dgData.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString

                    Me.dgData.Item("debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("tongdebit").ToString, 2)
                    debit = CDbl(ds.Tables(0).Rows(i).Item("tongdebit").ToString)
                    ' show ref
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from outbound where mblmawb ='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "'"
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        Me.dgData.Item("ref", currow).Value = dsref.Tables(0).Rows(0).Item("ref").ToString
                    End If
                    '--------------------
                    mau -= 100
                    ' vong lap con
                    sqlc = "select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("mblmawb").ToString & "'  and continued=1  "


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
                            Try
                                Me.dgData.Item("invoiceno", dongtang).Value = dsc.Tables(0).Rows(j).Item("sophieuchi").ToString
                            Catch ex As Exception

                            End Try



                            '----------------------------------------------------------------------------
                            Try
                                Me.dgData.Item("dateinvoice", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngay").ToString 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            Try
                                Me.dgData.Item("sotien", dongtang).Value = FormatNumber(dsc.Tables(0).Rows(j).Item("sotien").ToString, 2) 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                                debitphaithu += CDbl(dsc.Tables(0).Rows(j).Item("sotien").ToString)
                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("hbl", dongtang).Value = "Sub Total"
                    Me.dgData.Item("debit", dongtang).Value = FormatNumber(debit, 2)
                    Me.dgData.Item("sotien", dongtang).Value = FormatNumber(debitphaithu, 2)
                    Me.dgData.Item("sotienphaithu", dongtang).Value = FormatNumber(debit - debitphaithu, 2)
                    'Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    'Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    'Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    'Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    'Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    'Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    'Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    'Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next

            End If ' het hang FF

            '----hang nhap
            '-----------------------------------------------------------------------------------------------------------------------

            sql = "select blib_id,hbl,sum(price) as tongdebit from inboundfreight left join inbound on inbound.blib_id=inboundfreight.inboundid where  (hbl like '%" & Me.txthbl.Text & "%' or ref like '%" & Me.txthbl.Text & "%') and debitcredit='Credit' group by blib_id,hbl "



            ds = ReadDataSet(sql)
            Dim debitInbound, debitphaithuInbound As Double
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)
                    debitphaithuInbound = 0
                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("no", currow).Value = i.ToString

                    Me.dgData.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString

                    Me.dgData.Item("debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("tongdebit").ToString, 2)
                    ' show ref
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from inbound where hbl ='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "'"
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        Me.dgData.Item("ref", currow).Value = dsref.Tables(0).Rows(0).Item("ref").ToString
                    End If
                    '--------------------

                    debitInbound = CDbl(ds.Tables(0).Rows(i).Item("tongdebit").ToString)

                    mau -= 100
                    ' vong lap con
                    sqlc = "select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("hbl").ToString & "' and continued=1  "


                    dsc = ReadDataSet(sqlc)
                    dongtang = currow + 1

                    '----------------------------------
                    If dsc.Tables(0).Rows.Count > 0 Then
                        For j As Integer = 0 To dsc.Tables(0).Rows.Count - 1
                            Me.dgData.Rows.Add(1)
                            Me.dgData.Item("no", dongtang).Value = j + 1
                            Try
                                Me.dgData.Item("invoiceno", dongtang).Value = dsc.Tables(0).Rows(j).Item("sophieuchi").ToString
                            Catch ex As Exception

                            End Try



                            '----------------------------------------------------------------------------
                            Try
                                Me.dgData.Item("dateinvoice", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngay").ToString 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            Try
                                Me.dgData.Item("sotien", dongtang).Value = FormatNumber(dsc.Tables(0).Rows(j).Item("sotien").ToString, 2) 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                                debitphaithuInbound += CDbl(dsc.Tables(0).Rows(j).Item("sotien").ToString)
                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("hbl", dongtang).Value = "Sub Total"
                    Me.dgData.Item("debit", dongtang).Value = FormatNumber(debitInbound, 2)
                    Me.dgData.Item("sotien", dongtang).Value = FormatNumber(debitphaithuInbound, 2)
                    Me.dgData.Item("sotienphaithu", dongtang).Value = FormatNumber(debitInbound - debitphaithuInbound, 2)
                    'Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    'Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    'Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    'Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    'Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    'Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    'Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    'Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next

            End If ' het hang FF
            '------------------------------------------------
            ' Logistics
            sql = "select blob_id,ref,sum(price) as tongdebit from Logisticsfreight left join Logistics on Logistics.blob_id=Logisticsfreight.Logisticsid where  (mblmawb like '%" & Me.txthbl.Text & "%' or ref like '%" & Me.txthbl.Text & "%') and debitcredit='Credit' group by blob_id,ref "



            ds = ReadDataSet(sql)
            Dim debitLogistics, debitphaithuLogistics As Double
            ' show account
            'Me.dgData.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgData.Rows.Add(1)
                    debitphaithuLogistics = 0
                    currow = Me.dgData.RowCount - 2
                    ' hien thi noi dung bill Ib
                    Me.dgData.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.dgData.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                    Me.dgData.Item("no", currow).Value = i.ToString

                    Me.dgData.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    ' show ref
                    Dim sqlref As String
                    Dim dsref As New DataSet
                    sqlref = "select * from logistics where ref ='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'"
                    dsref = ReadDataSet(sqlref)
                    If dsref.Tables(0).Rows.Count > 0 Then
                        Me.dgData.Item("ref", currow).Value = dsref.Tables(0).Rows(0).Item("ref").ToString
                    End If
                    '--------------------
                    Me.dgData.Item("debit", currow).Value = FormatNumber(ds.Tables(0).Rows(i).Item("tongdebit").ToString, 2)
                    debitLogistics = CDbl(ds.Tables(0).Rows(i).Item("tongdebit").ToString)

                    mau -= 100
                    ' vong lap con
                    sqlc = "select * from phieuchi where billno='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'  and continued=1  "


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
                            Try
                                Me.dgData.Item("invoiceno", dongtang).Value = dsc.Tables(0).Rows(j).Item("sophieuchi").ToString
                            Catch ex As Exception

                            End Try



                            '----------------------------------------------------------------------------
                            Try
                                Me.dgData.Item("dateinvoice", dongtang).Value = dsc.Tables(0).Rows(j).Item("ngay").ToString 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)

                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            Try
                                Me.dgData.Item("sotien", dongtang).Value = FormatNumber(dsc.Tables(0).Rows(j).Item("sotien").ToString, 2) 'FormatNumber(FormatNumber(CDbl(debit - credit), 2), 2)
                                debitphaithuLogistics += CDbl(dsc.Tables(0).Rows(j).Item("sotien").ToString)
                            Catch ex As Exception

                            End Try
                            '-----------------tong

                            '----------------------------------------------------------------------------
                            dongtang += 1
                        Next
                    End If
                    ' them tong
                    'dongtang += 1
                    Me.dgData.Rows.Add(1)
                    Me.dgData.Item("hbl", dongtang).Value = "Sub Total"
                    Me.dgData.Item("debit", dongtang).Value = FormatNumber(debitLogistics, 2)
                    Me.dgData.Item("sotien", dongtang).Value = FormatNumber(debitphaithuLogistics, 2)
                    Me.dgData.Item("sotienphaithu", dongtang).Value = FormatNumber(debitLogistics - debitphaithuLogistics, 2)
                    'Me.dgData.Item("RFsc", dongtang).Value = FormatNumber(tong2, 2)
                    'Me.dgData.Item("Rtotal", dongtang).Value = FormatNumber(tong3, 2)
                    'Me.dgData.Item("pF", dongtang).Value = FormatNumber(tong4, 2)
                    'Me.dgData.Item("pFsc", dongtang).Value = FormatNumber(tong5, 2)
                    'Me.dgData.Item("ptotal", dongtang).Value = FormatNumber(tong6, 2)

                    'Me.dgData.Item("GrossIncome", dongtang).Value = FormatNumber(tong7, 2)
                    'Me.dgData.Item("COMMISSION", dongtang).Value = FormatNumber(tong8, 2)
                    'Me.dgData.Item("MarginProfit", dongtang).Value = FormatNumber(tong9, 2)


                    Me.dgData.Rows(dongtang).DefaultCellStyle.ForeColor = Color.Red
                    '---------------------------------
                    '--------------------
                Next

            End If ' het hang FF
            InsertAutoNumberToGrid(Me.dgData)
        Catch ex As Exception

        End Try
    End Sub
End Class