Public Class frmMonthlyReportForSale
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim currow As Integer
            Dim mau As Integer = -65281
            Dim i As Integer
            Me.DataGridView1.Rows.Clear()
            Dim sqlvolumn As String
            Dim dsvolumn As New DataSet
            Dim v As Integer
            Dim t As Integer
            Dim sqlCont As String = ""
            Dim dsCont As New DataSet
            mau -= 100
            Dim stt As Integer = 1
            ' If UCase(Me.cboChinhanh.Text) = "ALL" Then
            If Me.chkonly.Checked = True Then

         
                sql = "select customer_id,customer_code ,company from outboundfreight  left join customer on outboundfreight .customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where outbound.salecode like '%" & Me.cbosale.Text & "%'   and convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and outbound.branch='" & Me.cboChinhanh.Text & "'  and debitcredit='Debit' group by customer_id,customer_code ,company "




                ds = ReadDataSet(sql)

                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                    Next
                End If
                ' lay ra tung khach hang

                '========================================
                ' lay tung hous cua tung Cus tinh air
             
                'Me.DataGridView1.Rows.Add(1)
                'currow = Me.DataGridView1.RowCount - 2
                ' hien thi noi dung bill Ib
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                ' dien ten khach hang vao luoi


                ' ta lay tung house

                sqlvolumn = "select distinct blob_id from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid where outbound.salecode like '%" & Me.cbosale.Text & "%'   and convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and outbound.branch='" & Me.cboChinhanh.Text & "' "
                dsvolumn = ReadDataSet(sqlvolumn)
                If dsvolumn.Tables(0).Rows.Count > 0 Then
                    ' tgung house

                    For v = 0 To dsvolumn.Tables(0).Rows.Count - 1
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""
                        Dim cont20 As Integer = 0
                        Dim cont40 As Integer = 0
                        Dim contHC As Integer = 0

                        ' voi cung 1 house ta lay thong tin gia tien

                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        Me.DataGridView1.Item("Column1", currow).Value = (v + 1).ToString

                        '------------------------------
                        ' ung moi khach hang ta lay pol/pod
                        Dim sqlpolpod As String
                        Dim dspolpod As New DataSet
                        Dim p As Integer
                        sqlpolpod = "select * from outbound  where blob_id='" & dsvolumn.Tables(0).Rows(v).Item("blob_id").ToString & "'  "
                        dspolpod = ReadDataSet(sqlpolpod)
                        If dspolpod.Tables(0).Rows.Count > 0 Then
                            ' ta ghi vao polpod
                            For p = 0 To dspolpod.Tables(0).Rows.Count - 1
                                Me.DataGridView1.Item("Column3", currow).Value = dspolpod.Tables(0).Rows(p).Item("ref").ToString + " (" + dspolpod.Tables(0).Rows(p).Item("polcode").ToString + "/" + dspolpod.Tables(0).Rows(p).Item("podcode").ToString + "); " + Chr(10)
                            Next

                        End If
                        ' lay so cont
                        '------------------------------------------------
                        Dim air, fcl As String
                        sqlCont = "select containertype.*,air,fcl,lcl,consol from containertype left join outbound on containertype.outboundid=outbound.blob_id where containertype.outboundid='" & dsvolumn.Tables(0).Rows(v).Item("blob_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            Try
                                air = dsCont.Tables(0).Rows(0).Item("air").ToString
                                fcl = dsCont.Tables(0).Rows(0).Item("fcl").ToString
                            Catch ex As Exception

                            End Try

                            For t = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(t).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(t).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(t).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(t).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(t).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(t).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(t).Item("type").ToString
                                'dme(soluong)
                                If dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*20*" Then
                                    cont20 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*40*" Then
                                    cont40 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*HC*" Then
                                    contHC += 1
                                End If
                                ' 
                            Next
                        End If
                        ' ta ghi vao luoi cont 1.....
                        If kg > 0 Then
                            If air = "True" Then
                                Me.DataGridView1.Item("Column4", currow).Value = FormatNumber(kg.ToString, 2)
                            End If

                        End If
                        If khoi > 0 Then
                            If fcl = "False" Then
                                Me.DataGridView1.Item("Column5", currow).Value = FormatNumber(khoi.ToString, 3)
                            End If

                        End If
                        If cont20 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column6", currow).Value = FormatNumber(cont20.ToString, 0)
                            End If

                        End If
                        If cont40 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column7", currow).Value = FormatNumber(cont40.ToString, 0)
                            End If
                        End If
                        If contHC > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column8", currow).Value = FormatNumber(contHC.ToString, 0)
                            End If
                        End If
                        air = ""
                        fcl = ""
                        ' lay gia outboundfreght
                        Dim sqlFreight As String
                        Dim dsFreight As New DataSet
                        Dim tongthuUSD As Double = 0
                        Dim tongchiuSD As Double = 0
                        Dim f As Integer = 0
                        Dim cus As String = ""
                        sqlFreight = "select outboundfreight.*,company,new from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on customer.customer_id=outboundfreight.customerid where blob_id='" & dsvolumn.Tables(0).Rows(v).Item("blob_id").ToString & "'  order by customerid "

                        dsFreight = ReadDataSet(sqlFreight)
                        If dsFreight.Tables(0).Rows.Count > 0 Then
                            For f = 0 To dsFreight.Tables(0).Rows.Count - 1
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Debit" Then
                                    tongthuUSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                    Try
                                        If dsFreight.Tables(0).Rows(f).Item("company").ToString <> dsFreight.Tables(0).Rows(f + 1).Item("company").ToString Then
                                            ' cus += "(" + dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString + ");"
                                            ' Else
                                            cus += dsFreight.Tables(0).Rows(f).Item("company").ToString + "(" + IIf(dsFreight.Tables(0).Rows(f).Item("new").ToString = "True", "New", "Old") + ");" + Chr(10) + Chr(13)

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Credit" Then
                                    tongchiuSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                End If
                            Next
                        End If
                        '-------------------------
                        ' ghi profit

                        Me.DataGridView1.Item("Column2", currow).Value = cus
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber((tongthuUSD - tongchiuSD), 2)

                    Next


                End If
                '' hang  nhap
                '=============================================
                sql = "select customer_id,customer_code ,company from inboundfreight  left join customer on inboundfreight .customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where inbound.salecode like '%" & Me.cbosale.Text & "%'   and convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and inbound.branch='" & Me.cboChinhanh.Text & "'  and debitcredit='Debit' group by customer_id,customer_code ,company "




                ds = ReadDataSet(sql)
                Try
                    Me.DataGridView1.Rows(currow + 1).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                    Me.DataGridView1.Rows(currow + 1).DefaultCellStyle.ForeColor = Color.Black
                Catch ex As Exception

                End Try

                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                    Next
                End If
                ' lay ra tung khach hang

                '========================================
                ' lay tung hous cua tung Cus tinh air
                'Dim sqlvolumn As String
                'Dim dsvolumn As New DataSet
                'Dim v As Integer
                'Dim t As Integer
                'Dim sqlCont As String = ""
                'Dim dsCont As New DataSet
                mau -= 100
                'Me.DataGridView1.Rows.Add(1)
                'currow = Me.DataGridView1.RowCount - 2
                ' hien thi noi dung bill Ib
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                ' dien ten khach hang vao luoi


                ' ta lay tung house

                sqlvolumn = "select distinct blib_id from inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid where inbound.salecode like '%" & Me.cbosale.Text & "%'   and convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and inbound.branch='" & Me.cboChinhanh.Text & "' "
                dsvolumn = ReadDataSet(sqlvolumn)
                If dsvolumn.Tables(0).Rows.Count > 0 Then
                    ' tgung house

                    For v = 0 To dsvolumn.Tables(0).Rows.Count - 1
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""
                        Dim cont20 As Integer = 0
                        Dim cont40 As Integer = 0
                        Dim contHC As Integer = 0

                        ' voi cung 1 house ta lay thong tin gia tien

                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        Me.DataGridView1.Item("Column1", currow).Value = (v + 1).ToString

                        '------------------------------
                        ' ung moi khach hang ta lay pol/pod
                        Dim sqlpolpod As String
                        Dim dspolpod As New DataSet
                        Dim p As Integer
                        sqlpolpod = "select * from inbound  where blib_id='" & dsvolumn.Tables(0).Rows(v).Item("blib_id").ToString & "'  "
                        dspolpod = ReadDataSet(sqlpolpod)
                        If dspolpod.Tables(0).Rows.Count > 0 Then
                            ' ta ghi vao polpod
                            For p = 0 To dspolpod.Tables(0).Rows.Count - 1
                                Me.DataGridView1.Item("Column3", currow).Value = dspolpod.Tables(0).Rows(p).Item("ref").ToString + " (" + dspolpod.Tables(0).Rows(p).Item("polcode").ToString + "/" + dspolpod.Tables(0).Rows(p).Item("podcode").ToString + "); " + Chr(10)
                            Next

                        End If
                        ' lay so cont
                        '------------------------------------------------
                        Dim air, fcl As String
                        sqlCont = "select containerrepair.*,air,fcl,lcl,consol from containerrepair left join inbound on containerrepair.inboundid=inbound.blib_id where containerrepair.inboundid='" & dsvolumn.Tables(0).Rows(v).Item("blib_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            Try
                                air = dsCont.Tables(0).Rows(0).Item("air").ToString
                                fcl = dsCont.Tables(0).Rows(0).Item("fcl").ToString
                            Catch ex As Exception

                            End Try

                            For t = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(t).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(t).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(t).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(t).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(t).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(t).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(t).Item("type").ToString
                                'dme(soluong)
                                If dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*20*" Then
                                    cont20 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*40*" Then
                                    cont40 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*HC*" Then
                                    contHC += 1
                                End If
                                ' 
                            Next
                        End If
                        ' ta ghi vao luoi cont 1.....
                        If kg > 0 Then
                            If air = "True" Then
                                Me.DataGridView1.Item("Column4", currow).Value = FormatNumber(kg.ToString, 2)
                            End If

                        End If
                        If khoi > 0 Then
                            If fcl = "False" Then
                                Me.DataGridView1.Item("Column5", currow).Value = FormatNumber(khoi.ToString, 3)
                            End If

                        End If
                        If cont20 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column6", currow).Value = FormatNumber(cont20.ToString, 0)
                            End If

                        End If
                        If cont40 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column7", currow).Value = FormatNumber(cont40.ToString, 0)
                            End If
                        End If
                        If contHC > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column8", currow).Value = FormatNumber(contHC.ToString, 0)
                            End If
                        End If
                        air = ""
                        fcl = ""
                        ' lay gia outboundfreght
                        Dim sqlFreight As String
                        Dim dsFreight As New DataSet
                        Dim tongthuUSD As Double = 0
                        Dim tongchiuSD As Double = 0
                        Dim f As Integer = 0
                        Dim cus As String = ""
                        sqlFreight = "select inboundfreight.*,company,new from inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on customer.customer_id=inboundfreight.customerid where blib_id='" & dsvolumn.Tables(0).Rows(v).Item("blib_id").ToString & "'  order by customerid "

                        dsFreight = ReadDataSet(sqlFreight)
                        If dsFreight.Tables(0).Rows.Count > 0 Then
                            For f = 0 To dsFreight.Tables(0).Rows.Count - 1
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Debit" Then
                                    tongthuUSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                    Try
                                        If dsFreight.Tables(0).Rows(f).Item("company").ToString <> dsFreight.Tables(0).Rows(f + 1).Item("company").ToString Then
                                            ' cus += "(" + dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString + ");"
                                            ' Else
                                            cus += dsFreight.Tables(0).Rows(f).Item("company").ToString + "(" + IIf(dsFreight.Tables(0).Rows(f).Item("new").ToString = "True", "New", "Old") + ");" + Chr(10) + Chr(13)

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Credit" Then
                                    tongchiuSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                End If
                            Next
                        End If
                        '-------------------------
                        ' ghi profit

                        Me.DataGridView1.Item("Column2", currow).Value = cus
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber((tongthuUSD - tongchiuSD), 2)

                    Next


                End If
                '  -------------------------------------
            Else
                ' xuat ra nhieu sale
                'Me.DataGridView1.Rows.Add(3)

                sql = "select customer_id,customer_code ,company from outboundfreight  left join customer on outboundfreight .customerid=customer.customer_id left join outbound on outbound.blob_id=outboundfreight.outboundid where  convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and outbound.branch='" & Me.cboChinhanh.Text & "'  and debitcredit='Debit' group by customer_id,customer_code ,company "

                ds = ReadDataSet(sql)
                'Me.DataGridView1.Rows(currow + 1).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                'Me.DataGridView1.Rows(currow + 1).DefaultCellStyle.ForeColor = Color.Black
                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                    Next
                End If
                ' lay ra tung khach hang

                '========================================
                ' lay tung hous cua tung Cus tinh air
                'Dim sqlvolumn As String
                'Dim dsvolumn As New DataSet
                'Dim v As Integer
                'Dim t As Integer
                'Dim sqlCont As String = ""
                'Dim dsCont As New DataSet
                mau -= 100
                'Me.DataGridView1.Rows.Add(1)
                'currow = Me.DataGridView1.RowCount - 2
                ' hien thi noi dung bill Ib
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                ' dien ten khach hang vao luoi


                ' ta lay tung house

                sqlvolumn = "select distinct blob_id,salecode from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid where  convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and outbound.branch='" & Me.cboChinhanh.Text & "' order by salecode "
                dsvolumn = ReadDataSet(sqlvolumn)
                If dsvolumn.Tables(0).Rows.Count > 0 Then
                    ' tgung house

                    For v = 0 To dsvolumn.Tables(0).Rows.Count - 1
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""
                        Dim cont20 As Integer = 0
                        Dim cont40 As Integer = 0
                        Dim contHC As Integer = 0

                        ' voi cung 1 house ta lay thong tin gia tien

                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        Me.DataGridView1.Item("Column1", currow).Value = stt.ToString

                        '------------------------------
                        ' ung moi khach hang ta lay pol/pod
                        Dim sqlpolpod As String
                        Dim dspolpod As New DataSet
                        Dim p As Integer
                        sqlpolpod = "select * from outbound  where blob_id='" & dsvolumn.Tables(0).Rows(v).Item("blob_id").ToString & "'  "
                        dspolpod = ReadDataSet(sqlpolpod)
                        If dspolpod.Tables(0).Rows.Count > 0 Then
                            ' ta ghi vao polpod
                            For p = 0 To dspolpod.Tables(0).Rows.Count - 1
                                Me.DataGridView1.Item("Column3", currow).Value = dspolpod.Tables(0).Rows(p).Item("ref").ToString + " (" + dspolpod.Tables(0).Rows(p).Item("polcode").ToString + "/" + dspolpod.Tables(0).Rows(p).Item("podcode").ToString + "); " + Chr(10)
                            Next

                        End If
                        ' lay so cont
                        '------------------------------------------------
                        Dim air, fcl As String
                        sqlCont = "select containertype.*,air,fcl,lcl,consol from containertype left join outbound on containertype.outboundid=outbound.blob_id where containertype.outboundid='" & dsvolumn.Tables(0).Rows(v).Item("blob_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            Try
                                air = dsCont.Tables(0).Rows(0).Item("air").ToString
                                fcl = dsCont.Tables(0).Rows(0).Item("fcl").ToString
                            Catch ex As Exception

                            End Try

                            For t = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(t).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(t).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(t).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(t).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(t).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(t).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(t).Item("type").ToString
                                'dme(soluong)
                                If dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*20*" Then
                                    cont20 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*40*" Then
                                    cont40 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*HC*" Then
                                    contHC += 1
                                End If
                                ' 
                            Next
                        End If
                        ' ta ghi vao luoi cont 1.....
                        If kg > 0 Then
                            If air = "True" Then
                                Me.DataGridView1.Item("Column4", currow).Value = FormatNumber(kg.ToString, 2)
                            End If

                        End If
                        If khoi > 0 Then
                            If fcl = "False" Then
                                Me.DataGridView1.Item("Column5", currow).Value = FormatNumber(khoi.ToString, 3)
                            End If

                        End If
                        If cont20 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column6", currow).Value = FormatNumber(cont20.ToString, 0)
                            End If

                        End If
                        If cont40 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column7", currow).Value = FormatNumber(cont40.ToString, 0)
                            End If
                        End If
                        If contHC > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column8", currow).Value = FormatNumber(contHC.ToString, 0)
                            End If
                        End If
                        air = ""
                        fcl = ""
                        ' lay gia outboundfreght
                        Dim sqlFreight As String
                        Dim dsFreight As New DataSet
                        Dim tongthuUSD As Double = 0
                        Dim tongchiuSD As Double = 0
                        Dim f As Integer = 0
                        Dim cus As String = ""
                        sqlFreight = "select outboundfreight.*,company,new from outbound left join outboundfreight on outbound.blob_id=outboundfreight.outboundid left join customer on customer.customer_id=outboundfreight.customerid where blob_id='" & dsvolumn.Tables(0).Rows(v).Item("blob_id").ToString & "'  order by customerid "

                        dsFreight = ReadDataSet(sqlFreight)
                        If dsFreight.Tables(0).Rows.Count > 0 Then
                            For f = 0 To dsFreight.Tables(0).Rows.Count - 1
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Debit" Then
                                    tongthuUSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                    Try
                                        If dsFreight.Tables(0).Rows(f).Item("company").ToString <> dsFreight.Tables(0).Rows(f + 1).Item("company").ToString Then
                                            ' cus += "(" + dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString + ");"

                                            cus += dsFreight.Tables(0).Rows(f).Item("company").ToString + "(" + IIf(dsFreight.Tables(0).Rows(f).Item("new").ToString = "True", "New", "Old") + ");" + Chr(10) + Chr(13)

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Credit" Then
                                    tongchiuSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                End If
                            Next
                        End If
                        '-------------------------
                        ' ghi profit

                        Me.DataGridView1.Item("Column2", currow).Value = cus
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber((tongthuUSD - tongchiuSD), 2)
                        Me.DataGridView1.Item("Column10", currow).Value = dsvolumn.Tables(0).Rows(v).Item("salecode").ToString
                        Try
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        Catch ex As Exception

                        End Try

                        stt += 1
                        Try
                            If dsvolumn.Tables(0).Rows(v).Item("salecode").ToString <> dsvolumn.Tables(0).Rows(v + 1).Item("salecode").ToString Then
                                Me.DataGridView1.Rows.Add(3)
                                mau -= 100
                                'Me.DataGridView1.Rows.Add(1)
                                'currow = Me.DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                stt = 1

                            End If
                        Catch ex As Exception

                        End Try


                    Next


                End If



                '' hang nhap=========================================================
                ' Dim stt As Integer = 1
                Me.DataGridView1.Rows.Add(3)
                sql = "select customer_id,customer_code ,company from inboundfreight  left join customer on inboundfreight .customerid=customer.customer_id left join inbound on inbound.blib_id=inboundfreight.inboundid where  convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and inbound.branch='" & Me.cboChinhanh.Text & "'  and debitcredit='Debit' group by customer_id,customer_code ,company "

                ds = ReadDataSet(sql)

                If ds.Tables(0).Rows.Count > 0 Then
                    ' ung moi dong tga lay so lieu
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                    Next
                End If
                ' lay ra tung khach hang

                '========================================
                ' lay tung hous cua tung Cus tinh air
                'Dim sqlvolumn As String
                'Dim dsvolumn As New DataSet
                'Dim v As Integer
                'Dim t As Integer
                'Dim sqlCont As String = ""
                'Dim dsCont As New DataSet
                mau -= 100
                'Me.DataGridView1.Rows.Add(1)
                'currow = Me.DataGridView1.RowCount - 2
                ' hien thi noi dung bill Ib
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black

                ' dien ten khach hang vao luoi


                ' ta lay tung house

                sqlvolumn = "select distinct blib_id,salecode from inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid where  convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and inbound.branch='" & Me.cboChinhanh.Text & "' order by salecode "
                dsvolumn = ReadDataSet(sqlvolumn)
                If dsvolumn.Tables(0).Rows.Count > 0 Then
                    ' tgung house

                    For v = 0 To dsvolumn.Tables(0).Rows.Count - 1
                        Dim kg As Double = 0
                        Dim kien As Double = 0
                        Dim khoi As Double = 0
                        Dim cont As String = ""
                        Dim type As String = ""
                        Dim cont20 As Integer = 0
                        Dim cont40 As Integer = 0
                        Dim contHC As Integer = 0

                        ' voi cung 1 house ta lay thong tin gia tien

                        Me.DataGridView1.Rows.Add(1)
                        currow = Me.DataGridView1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        'Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        Me.DataGridView1.Item("Column1", currow).Value = stt.ToString

                        '------------------------------
                        ' ung moi khach hang ta lay pol/pod
                        Dim sqlpolpod As String
                        Dim dspolpod As New DataSet
                        Dim p As Integer
                        sqlpolpod = "select * from inbound  where blib_id='" & dsvolumn.Tables(0).Rows(v).Item("blib_id").ToString & "'  "
                        dspolpod = ReadDataSet(sqlpolpod)
                        If dspolpod.Tables(0).Rows.Count > 0 Then
                            ' ta ghi vao polpod
                            For p = 0 To dspolpod.Tables(0).Rows.Count - 1
                                Me.DataGridView1.Item("Column3", currow).Value = dspolpod.Tables(0).Rows(p).Item("ref").ToString + " (" + dspolpod.Tables(0).Rows(p).Item("polcode").ToString + "/" + dspolpod.Tables(0).Rows(p).Item("podcode").ToString + "); " + Chr(10)
                            Next

                        End If
                        ' lay so cont
                        '------------------------------------------------
                        Dim air, fcl As String
                        sqlCont = "select containerrepair.*,air,fcl,lcl,consol from containerrepair left join inbound on containerrepair.inboundid=inbound.blib_id where containerrepair.inboundid='" & dsvolumn.Tables(0).Rows(v).Item("blib_id").ToString & "'"
                        dsCont = ReadDataSet(sqlCont)
                        If dsCont.Tables(0).Rows.Count > 0 Then
                            Try
                                air = dsCont.Tables(0).Rows(0).Item("air").ToString
                                fcl = dsCont.Tables(0).Rows(0).Item("fcl").ToString
                            Catch ex As Exception

                            End Try

                            For t = 0 To dsCont.Tables(0).Rows.Count - 1
                                Try
                                    kg += CDbl(dsCont.Tables(0).Rows(t).Item("sokg").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    kien += CDbl(dsCont.Tables(0).Rows(t).Item("sokien").ToString)
                                Catch ex As Exception

                                End Try
                                Try
                                    khoi += CDbl(dsCont.Tables(0).Rows(t).Item("sokhoi").ToString)
                                Catch ex As Exception

                                End Try

                                Try
                                    cont += dsCont.Tables(0).Rows(t).Item("containerno").ToString & "/" & dsCont.Tables(0).Rows(t).Item("seal").ToString & "/" & dsCont.Tables(0).Rows(t).Item("containertype").ToString & "; "
                                Catch ex As Exception

                                End Try
                                type = dsCont.Tables(0).Rows(t).Item("type").ToString
                                'dme(soluong)
                                If dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*20*" Then
                                    cont20 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*40*" Then
                                    cont40 += 1
                                ElseIf dsCont.Tables(0).Rows(t).Item("containertype").ToString Like "*HC*" Then
                                    contHC += 1
                                End If
                                ' 
                            Next
                        End If
                        ' ta ghi vao luoi cont 1.....
                        If kg > 0 Then
                            If air = "True" Then
                                Me.DataGridView1.Item("Column4", currow).Value = FormatNumber(kg.ToString, 2)
                            End If

                        End If
                        If khoi > 0 Then
                            If fcl = "False" Then
                                Me.DataGridView1.Item("Column5", currow).Value = FormatNumber(khoi.ToString, 3)
                            End If

                        End If
                        If cont20 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column6", currow).Value = FormatNumber(cont20.ToString, 0)
                            End If

                        End If
                        If cont40 > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column7", currow).Value = FormatNumber(cont40.ToString, 0)
                            End If
                        End If
                        If contHC > 0 Then
                            If fcl = "True" Then
                                Me.DataGridView1.Item("Column8", currow).Value = FormatNumber(contHC.ToString, 0)
                            End If
                        End If
                        air = ""
                        fcl = ""
                        ' lay gia inboundfreght
                        Dim sqlFreight As String
                        Dim dsFreight As New DataSet
                        Dim tongthuUSD As Double = 0
                        Dim tongchiuSD As Double = 0
                        Dim f As Integer = 0
                        Dim cus As String = ""
                        sqlFreight = "select inboundfreight.*,company,new from inbound left join inboundfreight on inbound.blib_id=inboundfreight.inboundid left join customer on customer.customer_id=inboundfreight.customerid where blib_id='" & dsvolumn.Tables(0).Rows(v).Item("blib_id").ToString & "'  order by customerid "

                        dsFreight = ReadDataSet(sqlFreight)
                        If dsFreight.Tables(0).Rows.Count > 0 Then
                            For f = 0 To dsFreight.Tables(0).Rows.Count - 1
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Debit" Then
                                    tongthuUSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                    Try
                                        If dsFreight.Tables(0).Rows(f).Item("company").ToString <> dsFreight.Tables(0).Rows(f + 1).Item("company").ToString Then
                                            ' cus += "(" + dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString + ");"

                                            cus += dsFreight.Tables(0).Rows(f).Item("company").ToString + "(" + IIf(dsFreight.Tables(0).Rows(f).Item("new").ToString = "True", "New", "Old") + ");" + Chr(10) + Chr(13)

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If
                                If dsFreight.Tables(0).Rows(f).Item("debitcredit").ToString = "Credit" Then
                                    tongchiuSD += dsFreight.Tables(0).Rows(f).Item("pricetruocthue").ToString
                                End If
                            Next
                        End If
                        '-------------------------
                        ' ghi profit

                        Me.DataGridView1.Item("Column2", currow).Value = cus
                        Me.DataGridView1.Item("Column9", currow).Value = FormatNumber((tongthuUSD - tongchiuSD), 2)
                        Me.DataGridView1.Item("Column10", currow).Value = dsvolumn.Tables(0).Rows(v).Item("salecode").ToString
                        Try
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                        Catch ex As Exception

                        End Try

                        stt += 1
                        Try
                            If dsvolumn.Tables(0).Rows(v).Item("salecode").ToString <> dsvolumn.Tables(0).Rows(v + 1).Item("salecode").ToString Then
                                Me.DataGridView1.Rows.Add(3)
                                mau -= 100
                                'Me.DataGridView1.Rows.Add(1)
                                'currow = Me.DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                stt = 1

                            End If
                        Catch ex As Exception

                        End Try


                    Next


                End If


            End If



            '--------------------
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

    Private Sub frmMonthlyReportForSale_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim id, value, strSQL As String
            ' lay cont vao cbopack
            cbosale.Items.Clear()
            id = "salecode"
            value = "salecode"
            strSQL = "Select salecode  From sale order by salecode "
            loadDataToObject(Me.cbosale, strSQL, id, value)
            '-------------------------------------------
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
End Class