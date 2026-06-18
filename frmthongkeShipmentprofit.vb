Public Class frmthongkeShipmentprofit

    Dim tongthu As Double = 0
    Dim tongchi As Double = 0
    Dim danhap As Integer = 0
    Dim tongshipment As Integer = 0
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            tongthu = 0
            tongchi = 0
            danhap = 0
            tongshipment = 0

            inbound()

            outbound()
            logistics()

            InsertAutoNumberToGrid(Me.dgdPort)

            InsertAutoNumberToGrid(Me.dgdPort1)
            InsertAutoNumberToGrid(Me.dgdPort11)

            Try
                Me.lblTotal.Text = "Total Profit : " + FormatNumber(tongthu - tongchi, 2) + " / " + danhap.ToString + " Shipment (Real Volume : " + (tongshipment).ToString + " Shipment profit)"
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub logistics()

        Try
            Dim strQuery, makequeryport As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim ds As New DataSet
            '----------------
            Try
                If UCase(gDepartment) = "SALE" Then
                    makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                    ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                    makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join logistics on quotation_sale.docid=logistics.blob_id left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                    makequeryport = makequeryport & " WHERE  "

                    makequeryport = makequeryport & ""
                    makequeryport = makequeryport & " quotation_sale.salename='" & strUserId & "' and quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                    makequeryport = makequeryport & " "

                ElseIf UCase(gDepartment) = "CUSTOMER" Then
                    makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                    ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                    makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join logistics on quotation_sale.docid=logistics.blob_id left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                    makequeryport = makequeryport & " WHERE  "

                    makequeryport = makequeryport & ""
                    makequeryport = makequeryport & " quotation_sale.salename='" & strUserId & "' and quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                    makequeryport = makequeryport & " "

                ElseIf UCase(gDepartment) = "SALEMANAGER" Then
                    ' lay list salecode
                    Dim sqluser As String
                    Dim dsuser As New DataSet
                    Dim iuser As Integer
                    sqluser = "select * from userlist where manager1='" & strUserId & "' "
                    makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                    ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                    makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join logistics on quotation_sale.docid=logistics.blob_id left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                    makequeryport = makequeryport & " WHERE  "

                    makequeryport = makequeryport & ""
                    makequeryport = makequeryport & "  (quotation_sale.branch like '%" & gBranch & "%') "
                    makequeryport = makequeryport & " "


                    dsuser = ReadDataSet(sqluser)
                    If dsuser.Tables(0).Rows.Count > 0 Then
                        If dsuser.Tables(0).Rows.Count > 1 Then
                            For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                If iuser = 0 Then
                                    makequeryport += " and (quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                Else
                                    makequeryport += " or quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                End If



                            Next
                        Else
                            For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                makequeryport += " and (quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                            Next
                        End If

                    End If
                    makequeryport += " or quotation_sale.salename='" & strUserId & "')"


                Else
                    makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                    ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                    makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join logistics on quotation_sale.docid=logistics.blob_id left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                    makequeryport = makequeryport & " WHERE  "

                    makequeryport = makequeryport & ""
                    makequeryport = makequeryport & " quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                    makequeryport = makequeryport & " "

                End If
                makequeryport = makequeryport & "  and (Month(containeroutboundnotify_sale.etd)='" & CDate(ngay.Value.Date).Month & "')  and (year(containeroutboundnotify_sale.etd)='" & CDate(ngay.Value.Date).Year & "') and iol='Logistics'  and containeroutboundnotify_sale.continued=1 order by convert(datetime,quotation_sale.dateupdate) desc" 'and (quotationno like '%PR%' or  quotationno like '%S_L%'  )

            Catch ex As Exception

            End Try
            Dim dem, i, currow As Integer
            Me.dgdPort11.Rows.Clear()
            ds = ReadDataSet(makequeryport)
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Me.dgdPort11.Rows.Add(1)
                    currow = Me.dgdPort11.RowCount - 2
                    ' hien thi noi dung bill Ib
                    'Me.dgdPort11.Rows(currow).DefaultCellStyle.BackColor = Color.White
                    'Me.dgdPort11.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                    Me.dgdPort11.Item("quotationID11", currow).Value = ds.Tables(0).Rows(i).Item("quotationID").ToString
                    Me.dgdPort11.Item("customer_id11", currow).Value = ds.Tables(0).Rows(i).Item("customer_id").ToString
                    Me.dgdPort11.Item("quotationNo11", currow).Value = ds.Tables(0).Rows(i).Item("quotationNo").ToString
                    Me.dgdPort11.Item("bookingno11", currow).Value = ds.Tables(0).Rows(i).Item("bookingno").ToString

                    Me.dgdPort11.Item("Customer11", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString

                    '  Me.dgdPort11.Item("notexsitc", currow).Value = ds.Tables(0).Rows(i).Item("Subject").ToString


                    Me.dgdPort11.Item("ref11", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString


                    Me.dgdPort11.Item("docid11", currow).Value = ds.Tables(0).Rows(i).Item("docid").ToString
                    Me.dgdPort11.Item("terms11", currow).Value = ds.Tables(0).Rows(i).Item("terms").ToString
                    Me.dgdPort11.Item("validdate11", currow).Value = ds.Tables(0).Rows(i).Item("validdate").ToString


                    Me.dgdPort11.Item("type11", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                    Me.dgdPort11.Item("shippingline11", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString

                    '  Me.dgdPort11.Item("mastercoloader", currow).Value = ds.Tables(0).Rows(i).Item("mastercoloader").ToString

                    Me.dgdPort11.Item("frequency11", currow).Value = ds.Tables(0).Rows(i).Item("frequency").ToString

                    Me.dgdPort11.Item("pol11", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                    Me.dgdPort11.Item("pod11", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                    Me.dgdPort11.Item("TransitTime11", currow).Value = ds.Tables(0).Rows(i).Item("TransitTime").ToString

                    Me.dgdPort11.Item("SaleName11", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
                    Me.dgdPort11.Item("remarks11", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                    Me.dgdPort11.Item("Editable11", currow).Value = ds.Tables(0).Rows(i).Item("Editable").ToString

                    Me.dgdPort11.Item("Continued11", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString

                    Me.dgdPort11.Item("Approve11", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString

                    Me.dgdPort11.Item("userupdate11", currow).Value = ds.Tables(0).Rows(i).Item("userupdate").ToString

                    Me.dgdPort11.Item("dateupdate11", currow).Value = ds.Tables(0).Rows(i).Item("dateupdate").ToString

                    ' lay thong tin debit/credit
                    Dim sqlq As String
                    Dim dsq As New DataSet
                    Dim j As Integer
                    Dim thu As Double = 0
                    Dim chi As Double = 0
                    Try

                        If ds.Tables(0).Rows(i).Item("QuotationId").ToString <> "" Then


                            sqlq = "select * from logisticsfreight_sale where QuotationId = '" & ds.Tables(0).Rows(i).Item("QuotationId").ToString & "' "
                            dsq = ReadDataSet(sqlq)
                            If dsq.Tables(0).Rows.Count > 0 Then
                                For j = 0 To dsq.Tables(0).Rows.Count - 1
                                    If UCase(dsq.Tables(0).Rows(j).Item("debitcredit").ToString) = "DEBIT" Then
                                        Try
                                            thu += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)

                                            tongthu += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                        Catch ex As Exception

                                        End Try
                                    Else

                                        Try
                                            chi += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                            tongchi += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                        Catch ex As Exception

                                        End Try
                                    End If
                                Next

                            End If
                        End If

                    Catch ex As Exception

                    End Try
                    Me.dgdPort11.Item("DEBIT11", currow).Value = FormatNumber(thu, 0)
                    Me.dgdPort11.Item("CREDIT11", currow).Value = FormatNumber(chi, 0)
                    Me.dgdPort11.Item("profit11", currow).Value = FormatNumber(thu - chi, 0)

                    currow += 1


                    dem += 1
                Next
            End If

            '  Dim danhap As Integer = 0
            For i = 0 To dgdPort11.RowCount - 1
                Try
                    If CDbl(Me.dgdPort11.Item("DEBIT11", i).Value.ToString) > 0 And CDbl(Me.dgdPort11.Item("credit", i).Value.ToString) > 0 Then
                        danhap += 1
                    End If
                Catch ex As Exception

                End Try
            Next
            Try
                tongshipment += Me.dgdPort11.RowCount - 1
            Catch ex As Exception

            End Try
            'Try
            '    Me.lblTotal.Text = "Total Profit : " + FormatNumber(tongthu - tongchi, 2) + " / " + danhap.ToString + " Shipment (Real Volume : " + (Me.dgdPort11.RowCount - 1).ToString + " Shipment profit)"
            'Catch ex As Exception

            'End Try
        Catch ex As Exception

        End Try

    End Sub
    Public Sub outbound()
        Try
            Try


                Dim strQuery, MakeQueryPort As String
                '-------------
                Dim Con As New SqlClient.SqlConnection(strconnDG)
                Dim ds As New DataSet
                '----------------
                Try
                    If UCase(gDepartment) = "SALE" Then
                        MakeQueryPort = "select quotation_sale.*,taxcode + '-' + company as company,ref " ' lay them 2 bien tu outbound 
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        MakeQueryPort = MakeQueryPort & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join outbound on outbound.blob_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        MakeQueryPort = MakeQueryPort & " WHERE  "

                        MakeQueryPort = MakeQueryPort & ""
                        MakeQueryPort = MakeQueryPort & " quotation_sale.salename='" & strUserId & "' and quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                        MakeQueryPort = MakeQueryPort & " "

                    ElseIf UCase(gDepartment) = "CUSTOMER" Then
                        MakeQueryPort = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        MakeQueryPort = MakeQueryPort & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join outbound on outbound.blob_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        MakeQueryPort = MakeQueryPort & "WHERE  "

                        MakeQueryPort = MakeQueryPort & ""
                        MakeQueryPort = MakeQueryPort & " quotation_sale.salename='" & strUserId & "' and quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                        MakeQueryPort = MakeQueryPort & " "

                    ElseIf UCase(gDepartment) = "SALEMANAGER" Then
                        ' lay list salecode
                        Dim sqluser As String
                        Dim dsuser As New DataSet
                        Dim iuser As Integer
                        sqluser = "select * from userlist where manager1='" & strUserId & "' "
                        MakeQueryPort = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        MakeQueryPort = MakeQueryPort & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join outbound on outbound.blob_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        MakeQueryPort = MakeQueryPort & "WHERE  "

                        MakeQueryPort = MakeQueryPort & ""
                        MakeQueryPort = MakeQueryPort & "  (quotation_sale.branch like '%" & gBranch & "%') "
                        MakeQueryPort = MakeQueryPort & " "


                        dsuser = ReadDataSet(sqluser)
                        If dsuser.Tables(0).Rows.Count > 0 Then
                            If dsuser.Tables(0).Rows.Count > 1 Then
                                For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                    If iuser = 0 Then
                                        MakeQueryPort += " and (quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                    Else
                                        MakeQueryPort += " or quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                    End If



                                Next
                            Else
                                For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                    MakeQueryPort += " and (quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                Next
                            End If

                        End If
                        MakeQueryPort += " or quotation_sale.salename='" & strUserId & "')"

                        MakeQueryPort = MakeQueryPort & " "

                    Else
                        MakeQueryPort = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        MakeQueryPort = MakeQueryPort & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join outbound on outbound.blob_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        MakeQueryPort = MakeQueryPort & "WHERE  "

                        MakeQueryPort = MakeQueryPort & ""
                        MakeQueryPort = MakeQueryPort & " quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                        MakeQueryPort = MakeQueryPort & " "

                    End If

                    'If mStatus = "Edit" Then
                    '    MakeQueryPort = MakeQueryPort & " and serviceid='" & mQuotationid & "'"
                    'End If
                    'If mStatus = "Add" Then
                    ' strQuery += "  and (Month(etd)='" & CDate(ngay).Month & "')  and (year(etd)='" & CDate(ngay).Year & "') and iol='Outbound' order by convert(integer,fileno) desc "
                    '  MakeQueryPort += "  and (Month(etd)='" & CDate(ngay).Month & "')  and (year(etd)='" & CDate(ngay).Year & "') and iol='Outbound' order by convert(integer,fileno) desc "

                    MakeQueryPort = MakeQueryPort & " and  (Month(containeroutboundnotify_sale.etd)='" & CDate(ngay.Value.Date).Month & "')  and (year(containeroutboundnotify_sale.etd)='" & CDate(ngay.Value.Date).Year & "') and iol='Outbound' and containeroutboundnotify_sale.continued=1 order by convert(datetime,quotation_sale.dateupdate) desc" '(quotationno like '%S_E%' or quotationno like '%ES%' or  quotationno like '%EN%') and

                Catch ex As Exception

                End Try
                '' '' '' ''Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
                '' '' '' ''Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
                ' '' '' '' ''-----------------
                '' '' '' ''Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                '' '' '' ''Con.Open()
                '' '' '' ''Adapter.Fill(ds, "PortList")
                '' '' '' ''oTable = ds.Tables(0)
                ' '' '' '' ''hien thi ra grid 
                '' '' '' ''Me.dgdPort1.DataSource = ds.Tables("PortList")
                '' '' '' ''If Me.dgdPort1.Enabled = False Then
                '' '' '' ''    Me.dgdPort1.Enabled = True
                '' '' '' ''End If
                Dim dem, i, currow As Integer
                'Dim tongthu As Double = 0
                'Dim tongchi As Double = 0
                Me.dgdPort1.Rows.Clear()
                ds = ReadDataSet(MakeQueryPort)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdPort1.Rows.Add(1)
                        currow = Me.dgdPort1.RowCount - 2
                        ' hien thi noi dung bill Ib
                        'Me.dgdPort1.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        'Me.dgdPort1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdPort1.Item("quotationID1", currow).Value = ds.Tables(0).Rows(i).Item("quotationID").ToString
                        Me.dgdPort1.Item("customer_id1", currow).Value = ds.Tables(0).Rows(i).Item("customer_id").ToString
                        Me.dgdPort1.Item("quotationNo1", currow).Value = ds.Tables(0).Rows(i).Item("quotationNo").ToString
                        Me.dgdPort1.Item("bookingno1", currow).Value = ds.Tables(0).Rows(i).Item("bookingno").ToString

                        Me.dgdPort1.Item("Customer1", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString

                        Me.dgdPort1.Item("notexsitc1", currow).Value = ds.Tables(0).Rows(i).Item("Subject").ToString


                        Me.dgdPort1.Item("ref1", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString


                        Me.dgdPort1.Item("docid1", currow).Value = ds.Tables(0).Rows(i).Item("docid").ToString
                        Me.dgdPort1.Item("terms1", currow).Value = ds.Tables(0).Rows(i).Item("terms").ToString
                        Me.dgdPort1.Item("validdate1", currow).Value = ds.Tables(0).Rows(i).Item("validdate").ToString


                        Me.dgdPort1.Item("type1", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                        Me.dgdPort1.Item("shippingline1", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString

                        ' Me.dgdPort1.Item("mastercoloader1", currow).Value = ds.Tables(0).Rows(i).Item("mastercoloader").ToString

                        Me.dgdPort1.Item("frequency1", currow).Value = ds.Tables(0).Rows(i).Item("frequency").ToString

                        Me.dgdPort1.Item("pol1", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                        Me.dgdPort1.Item("pod1", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                        Me.dgdPort1.Item("TransitTime1", currow).Value = ds.Tables(0).Rows(i).Item("TransitTime").ToString

                        Me.dgdPort1.Item("SaleName1", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
                        Me.dgdPort1.Item("remarks1", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                        Me.dgdPort1.Item("Editable1", currow).Value = ds.Tables(0).Rows(i).Item("Editable").ToString

                        Me.dgdPort1.Item("Continued1", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString

                        Me.dgdPort1.Item("Approve1", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString

                        Me.dgdPort1.Item("userupdate1", currow).Value = ds.Tables(0).Rows(i).Item("userupdate").ToString

                        Me.dgdPort1.Item("dateupdate1", currow).Value = ds.Tables(0).Rows(i).Item("dateupdate").ToString

                        ' lay thong tin debit/credit
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Dim j As Integer
                        Dim thu As Double = 0
                        Dim chi As Double = 0
                        Try

                            If ds.Tables(0).Rows(i).Item("QuotationId").ToString <> "" Then


                                sqlq = "select * from outboundfreight_sale where QuotationId = '" & ds.Tables(0).Rows(i).Item("QuotationId").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    For j = 0 To dsq.Tables(0).Rows.Count - 1
                                        If UCase(dsq.Tables(0).Rows(j).Item("debitcredit").ToString) = "DEBIT" Then
                                            Try
                                                thu += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                                tongthu += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                            Catch ex As Exception

                                            End Try
                                        Else

                                            Try
                                                chi += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                                tongchi += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)

                                            Catch ex As Exception

                                            End Try
                                        End If
                                    Next

                                End If
                            End If

                        Catch ex As Exception

                        End Try
                        Me.dgdPort1.Item("DEBIT1", currow).Value = FormatNumber(thu, 0)
                        Me.dgdPort1.Item("CREDIT1", currow).Value = FormatNumber(chi, 0)
                        Me.dgdPort1.Item("profit1", currow).Value = FormatNumber(thu - chi, 0)
                        currow += 1


                        dem += 1
                    Next
                End If
                '--------------------
                Me.Cursor = System.Windows.Forms.Cursors.Default
                'If oTable.Rows.Count > 0 Then
                '    Me.dgdPort1.Columns.Item("servicename").ToolTipText = "Hiện có:" + CStr(Me.dgdPort1.RowCount()) + " Service."
                'End If
                If Me.dgdPort1.RowCount() = 0 Then
                    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
                End If
                '------------vị trí BM
                'If location > 0 And location <= Me.dgdPort1.Rows.Count And Me.dgdPort1.Rows.Count > 0 Then
                '    Me.dgdPort1.Rows(location).Selected = True
                '    Me.dgdPort1.CurrentCell = Me.dgdPort1.Rows(location).Cells(3)
                'End If
                InsertAutoNumberToGrid(Me.dgdPort1)
                ' Dim danhap As Integer = 0
                For i = 0 To dgdPort1.RowCount - 1
                    Try
                        If CDbl(Me.dgdPort1.Item("DEBIT1", i).Value.ToString) > 0 And CDbl(Me.dgdPort1.Item("credit1", i).Value.ToString) > 0 Then
                            danhap += 1
                        End If
                    Catch ex As Exception

                    End Try
                Next
                Try
                    tongshipment += Me.dgdPort1.RowCount - 1
                Catch ex As Exception

                End Try
                'Try
                '    Me.lblTotal.Text = "Total Profit : " + FormatNumber(tongthu - tongchi, 2) + " / " + danhap.ToString + " Shipment (Real Volume : " + (Me.dgdPort1.RowCount - 1).ToString + " Shipment profit)"
                'Catch ex As Exception

                'End Try
            Catch ex As Exception
                MsgBox(msgErr(Me, Err.Description))
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub inbound()
        Try
            Try
                Dim strQuery, makequeryport As String
                '-------------
                Dim Con As New SqlClient.SqlConnection(strconnDG)
                Dim ds As New DataSet
                '----------------
                Try
                    If UCase(gDepartment) = "SALE" Then
                        makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join inbound on inbound.blib_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        makequeryport = makequeryport & " WHERE  "

                        makequeryport = makequeryport & ""
                        makequeryport = makequeryport & " quotation_sale.salename='" & strUserId & "' and quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                        makequeryport = makequeryport & " "

                    ElseIf UCase(gDepartment) = "CUSTOMER" Then
                        makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join inbound on inbound.blib_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        makequeryport = makequeryport & " WHERE  "

                        makequeryport = makequeryport & ""
                        makequeryport = makequeryport & " quotation_sale.salename='" & strUserId & "' and quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                        makequeryport = makequeryport & " "

                    ElseIf UCase(gDepartment) = "SALEMANAGER" Then
                        ' lay list salecode
                        Dim sqluser As String
                        Dim dsuser As New DataSet
                        Dim iuser As Integer
                        sqluser = "select * from userlist where manager1='" & strUserId & "' "
                        makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join inbound on inbound.blib_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        makequeryport = makequeryport & " WHERE  "

                        makequeryport = makequeryport & ""
                        makequeryport = makequeryport & "  (quotation_sale.branch like '%" & gBranch & "%') "
                        makequeryport = makequeryport & " "


                        dsuser = ReadDataSet(sqluser)
                        If dsuser.Tables(0).Rows.Count > 0 Then
                            If dsuser.Tables(0).Rows.Count > 1 Then
                                For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                    If iuser = 0 Then
                                        makequeryport += " and (quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                    Else
                                        makequeryport += " or quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                    End If



                                Next
                            Else
                                For iuser = 0 To dsuser.Tables(0).Rows.Count - 1
                                    makequeryport += " and (quotation_sale.salename = '" & dsuser.Tables(0).Rows(iuser).Item("usr").ToString & "'"
                                Next
                            End If

                        End If
                        makequeryport += " or  quotation_sale.salename='" & strUserId & "')"

                        makequeryport = makequeryport & " "

                    Else
                        makequeryport = "select quotation_sale.*,taxcode + '-' + company as company,ref "
                        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
                        makequeryport = makequeryport & " FROM quotation_sale left join customer on quotation_sale.customer_id=customer.customer_id left join inbound on inbound.blib_id=quotation_sale.docid left join containeroutboundnotify_sale on quotation_sale.quotationid= containeroutboundnotify_sale.quotationid "
                        makequeryport = makequeryport & " WHERE  "

                        makequeryport = makequeryport & ""
                        makequeryport = makequeryport & " quotation_sale.Continued = 1 and (quotation_sale.branch like '%" & gBranch & "%') "
                        makequeryport = makequeryport & " "

                    End If

                    makequeryport = makequeryport & " and  (Month(containeroutboundnotify_sale.eta)='" & CDate(ngay.Value.Date).Month & "')  and (year(containeroutboundnotify_sale.eta)='" & CDate(ngay.Value.Date).Year & "') and iol='Inbound' and containeroutboundnotify_sale.continued=1 order by convert(datetime,quotation_sale.dateupdate) desc" '(quotationno like '%IS%' or quotationno like '%IN%' or quotationno like '%S_I%' ) and

                Catch ex As Exception

                End Try
                'Dim tongthu As Double = 0
                'Dim tongchi As Double = 0
                Dim dem, i, currow As Integer
                Me.dgdPort.Rows.Clear()
                ds = ReadDataSet(makequeryport)
                If ds.Tables(0).Rows.Count > 0 Then
                    For i = 0 To ds.Tables(0).Rows.Count - 1
                        Me.dgdPort.Rows.Add(1)
                        currow = Me.dgdPort.RowCount - 2
                        ' hien thi noi dung bill Ib
                        'Me.dgdPort.Rows(currow).DefaultCellStyle.BackColor = Color.White
                        'Me.dgdPort.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                        Me.dgdPort.Item("quotationID", currow).Value = ds.Tables(0).Rows(i).Item("quotationID").ToString
                        Me.dgdPort.Item("customer_id", currow).Value = ds.Tables(0).Rows(i).Item("customer_id").ToString
                        Me.dgdPort.Item("quotationNo", currow).Value = ds.Tables(0).Rows(i).Item("quotationNo").ToString
                        Me.dgdPort.Item("bookingno", currow).Value = ds.Tables(0).Rows(i).Item("bookingno").ToString

                        Me.dgdPort.Item("Customer", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString

                        Me.dgdPort.Item("notexsitc", currow).Value = ds.Tables(0).Rows(i).Item("Subject").ToString


                        Me.dgdPort.Item("ref", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString


                        Me.dgdPort.Item("docid", currow).Value = ds.Tables(0).Rows(i).Item("docid").ToString
                        Me.dgdPort.Item("terms", currow).Value = ds.Tables(0).Rows(i).Item("terms").ToString
                        Me.dgdPort.Item("validdate", currow).Value = ds.Tables(0).Rows(i).Item("validdate").ToString


                        Me.dgdPort.Item("type", currow).Value = ds.Tables(0).Rows(i).Item("type").ToString
                        Me.dgdPort.Item("shippingline", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString

                        ' Me.dgdPort.Item("mastercoloader", currow).Value = ds.Tables(0).Rows(i).Item("mastercoloader").ToString

                        Me.dgdPort.Item("frequency", currow).Value = ds.Tables(0).Rows(i).Item("frequency").ToString

                        Me.dgdPort.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                        Me.dgdPort.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString

                        Me.dgdPort.Item("TransitTime", currow).Value = ds.Tables(0).Rows(i).Item("TransitTime").ToString

                        Me.dgdPort.Item("SaleName", currow).Value = ds.Tables(0).Rows(i).Item("SaleName").ToString
                        Me.dgdPort.Item("remarks", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                        Me.dgdPort.Item("Editable", currow).Value = ds.Tables(0).Rows(i).Item("Editable").ToString

                        Me.dgdPort.Item("Continued", currow).Value = ds.Tables(0).Rows(i).Item("Continued").ToString

                        Me.dgdPort.Item("Approve", currow).Value = ds.Tables(0).Rows(i).Item("Approve").ToString

                        Me.dgdPort.Item("userupdate", currow).Value = ds.Tables(0).Rows(i).Item("userupdate").ToString

                        Me.dgdPort.Item("dateupdate", currow).Value = ds.Tables(0).Rows(i).Item("dateupdate").ToString

                        ' lay thong tin debit/credit
                        Dim sqlq As String
                        Dim dsq As New DataSet
                        Dim j As Integer
                        Dim thu As Double = 0
                        Dim chi As Double = 0
                        Try

                            If ds.Tables(0).Rows(i).Item("QuotationId").ToString <> "" Then


                                sqlq = "select * from inboundfreight_sale where QuotationId = '" & ds.Tables(0).Rows(i).Item("QuotationId").ToString & "' "
                                dsq = ReadDataSet(sqlq)
                                If dsq.Tables(0).Rows.Count > 0 Then
                                    For j = 0 To dsq.Tables(0).Rows.Count - 1
                                        If UCase(dsq.Tables(0).Rows(j).Item("debitcredit").ToString) = "DEBIT" Then
                                            Try
                                                thu += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                                tongthu += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                            Catch ex As Exception

                                            End Try
                                        Else

                                            Try
                                                chi += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                                tongchi += CDbl(dsq.Tables(0).Rows(j).Item("PRICE").ToString)
                                            Catch ex As Exception

                                            End Try
                                        End If
                                    Next

                                End If
                            End If

                        Catch ex As Exception

                        End Try
                        Me.dgdPort.Item("DEBIT", currow).Value = FormatNumber(thu, 0)
                        Me.dgdPort.Item("CREDIT", currow).Value = FormatNumber(chi, 0)
                        Me.dgdPort.Item("profit", currow).Value = FormatNumber(thu - chi, 0)

                        currow += 1


                        dem += 1
                    Next
                End If
                '  Dim danhap As Integer = 0
                For i = 0 To dgdPort.RowCount - 1
                    Try
                        If CDbl(Me.dgdPort.Item("DEBIT", i).Value.ToString) > 0 And CDbl(Me.dgdPort.Item("credit", i).Value.ToString) > 0 Then
                            danhap += 1
                        End If
                    Catch ex As Exception

                    End Try
                Next
                Try
                    tongshipment += Me.dgdPort.RowCount - 1
                Catch ex As Exception

                End Try

                'Try
                '    Me.lblTotal.Text = "Total Profit : " + FormatNumber(tongthu - tongchi, 2) + " / " + danhap.ToString + " Shipment (Real Volume : " + (Me.dgdPort.RowCount - 1).ToString + " Shipment profit)"
                'Catch ex As Exception

                'End Try
            Catch ex As Exception

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
                If Me.dgdPort.Rows.Count > 0 Then

                    ExportExecel(Me.dgdPort, Me)

                End If
            Catch ex As Exception
                MsgBox(msgErr(Me, ex.Message))
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If Me.dgdPort1.Rows.Count > 0 Then

                ExportExecel(Me.dgdPort1, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If Me.dgdPort11.Rows.Count > 0 Then

                ExportExecel(Me.dgdPort11, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub DataGridView1_Click(sender As Object, e As EventArgs)
        Try
            InsertAutoNumberToGrid(Me.dgdPort)

            InsertAutoNumberToGrid(Me.dgdPort1)
            InsertAutoNumberToGrid(Me.dgdPort11)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub



    Private Sub DataGridView3_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgdPort1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdPort1.CellClick
        InsertAutoNumberToGrid(Me.dgdPort)

        InsertAutoNumberToGrid(Me.dgdPort1)
        InsertAutoNumberToGrid(Me.dgdPort11)
    End Sub


    Private Sub dgdPort1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdPort1.CellContentClick

    End Sub

    Private Sub dgdPort11_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdPort11.CellClick
        InsertAutoNumberToGrid(Me.dgdPort)

        InsertAutoNumberToGrid(Me.dgdPort1)
        InsertAutoNumberToGrid(Me.dgdPort11)
    End Sub

    Private Sub dgdPort11_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgdPort11.CellContentClick

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Try
                Dim url As String = "https://youtu.be/g_Envn7XiN0"

                Process.Start(url)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class