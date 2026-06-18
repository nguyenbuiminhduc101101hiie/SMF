Public Class frmShipments

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Try
            Try
                Dim J As Integer
                Dim i As Integer
                Dim currow As Integer
                Me.DataGridView1.Rows.Clear()



                Dim sqlo As String
                Dim dso As New DataSet
                If Me.chkall.Checked = True Then
                    Try



                        sqlo = "select * from outbound where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "
                        Me.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                        dso = ReadDataSet(sqlo)
                        If dso.Tables(0).Rows.Count > 0 Then
                            For i = 0 To dso.Tables(0).Rows.Count - 1


                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.DataGridView1.Item("Department_Shipment", currow).Value = "Agency-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                                Try
                                    Me.DataGridView1.Item("quotation", currow).Value = dso.Tables(0).Rows(i).Item("quotationNo").ToString
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                                Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString

                                Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString

                                Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                                Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                                Me.DataGridView1.Item("gflc_", currow).Value = dso.Tables(0).Rows(i).Item("gflc").ToString
                                Me.DataGridView1.Item("gsc_", currow).Value = dso.Tables(0).Rows(i).Item("gsc").ToString
                                Try
                                    Me.DataGridView1.Item("lot", currow).Value = dso.Tables(0).Rows(i).Item("lot").ToString
                                Catch ex As Exception

                                End Try


                                Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pol").ToString
                                Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pod").ToString
                                Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                                Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                                Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                                Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                                Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)
                                Me.DataGridView1.Item("remarks", currow).Value = dso.Tables(0).Rows(i).Item("remarks").ToString
                                '-----------
                                Me.DataGridView1.Item("userupdate", currow).Value = dso.Tables(0).Rows(i).Item("userupdate").ToString
                                Me.DataGridView1.Item("dateupdate", currow).Value = dso.Tables(0).Rows(i).Item("dateupdate").ToString
                                Try
                                    Me.DataGridView1.Item("volume", currow).Value = dso.Tables(0).Rows(i).Item("saycontainer").ToString

                                Catch ex As Exception

                                End Try
                                '------------



                            Next
                        End If

                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    '--------------------try---------------
                    Try


                        'sqlo = "select * from outbound_OverseaSeaExport where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "
                        'Me.GroupBox2.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                        'dso = ReadDataSet(sqlo)
                        'If dso.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dso.Tables(0).Rows.Count - 1


                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "Oversea-Sea-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                        '        Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                        '        Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pod").ToString
                        '        Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                        '        Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                        '        Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                        '        Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)
                        '    Next
                        'End If

                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    '-----------------------------------
                    '-----------------------------------
                    Try


                        sqlo = "select * from outbound_OverseaAirExport where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "'"
                        Me.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                        dso = ReadDataSet(sqlo)
                        If dso.Tables(0).Rows.Count > 0 Then
                            For i = 0 To dso.Tables(0).Rows.Count - 1


                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.DataGridView1.Item("Department_Shipment", currow).Value = "ACS-Air-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                                Try
                                    Me.DataGridView1.Item("quotation", currow).Value = dso.Tables(0).Rows(i).Item("quotationNo").ToString
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                                Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString

                                Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString
                                Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                                Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                                Me.DataGridView1.Item("gflc_", currow).Value = dso.Tables(0).Rows(i).Item("gflc").ToString
                                Me.DataGridView1.Item("gsc_", currow).Value = dso.Tables(0).Rows(i).Item("gsc").ToString
                                Try
                                    Me.DataGridView1.Item("lot", currow).Value = dso.Tables(0).Rows(i).Item("lot").ToString
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("AirportDeparture").ToString
                                Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("AirportDes").ToString
                                Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                                Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                                Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                                Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                                Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)

                                Me.DataGridView1.Item("remarks", currow).Value = dso.Tables(0).Rows(i).Item("remarks").ToString

                                '-----------
                                Me.DataGridView1.Item("userupdate", currow).Value = dso.Tables(0).Rows(i).Item("userupdate").ToString
                                Me.DataGridView1.Item("dateupdate", currow).Value = dso.Tables(0).Rows(i).Item("dateupdate").ToString
                                Try
                                    Me.DataGridView1.Item("volume", currow).Value = dso.Tables(0).Rows(i).Item("saycontainer").ToString

                                Catch ex As Exception

                                End Try
                                '------------
                            Next
                        End If

                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    '-----------------------------------
                    Try


                        'sqlo = "select * from Outbound_ACSSeaExport where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "
                        'Me.GroupBox2.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                        'dso = ReadDataSet(sqlo)
                        'If dso.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dso.Tables(0).Rows.Count - 1


                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "ACS-Sea-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                        '        Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                        '        Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pod").ToString
                        '        Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                        '        Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                        '        Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                        '        Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)
                        '    Next
                        'End If

                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    '-----------------------------------
                    Dim sqli As String
                    Dim dsi As New DataSet
                    Try




                        sqli = "select * from inbound where  convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "

                        dsi = ReadDataSet(sqli)
                        If dsi.Tables(0).Rows.Count > 0 Then
                            For i = 0 To dsi.Tables(0).Rows.Count - 1



                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.DataGridView1.Item("Department_Shipment", currow).Value = "Agency-Import" 'dsi.Tables(0).Rows(i).Item("Department_Shipment").ToString

                                Try
                                    Me.DataGridView1.Item("quotation", currow).Value = dsi.Tables(0).Rows(i).Item("quotationNo").ToString
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("status", currow).Value = dsi.Tables(0).Rows(i).Item("status").ToString
                                Me.DataGridView1.Item("debitissued", currow).Value = dsi.Tables(0).Rows(i).Item("debitissued").ToString

                                Me.DataGridView1.Item("invoiceissued", currow).Value = dsi.Tables(0).Rows(i).Item("invoiceissued").ToString

                                Me.DataGridView1.Item("mbl", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString
                                Me.DataGridView1.Item("hbl", currow).Value = dsi.Tables(0).Rows(i).Item("hbl").ToString

                                Me.DataGridView1.Item("gflc_", currow).Value = dsi.Tables(0).Rows(i).Item("gflc").ToString
                                Me.DataGridView1.Item("gsc_", currow).Value = dsi.Tables(0).Rows(i).Item("gsc").ToString
                                Try
                                    Me.DataGridView1.Item("lot", currow).Value = dsi.Tables(0).Rows(i).Item("lot").ToString
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("ref", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("POL_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pol").ToString
                                Me.DataGridView1.Item("POD_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pod").ToString
                                Me.DataGridView1.Item("eta", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("eta").ToString)
                                Me.DataGridView1.Item("etd", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString)
                                Me.DataGridView1.Item("sales", currow).Value = dsi.Tables(0).Rows(i).Item("salecode").ToString
                                Me.DataGridView1.Item("OPS", currow).Value = dsi.Tables(0).Rows(i).Item("ops").ToString
                                Me.DataGridView1.Item("datereport", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("datereport").ToString)
                                Me.DataGridView1.Item("remarks", currow).Value = dsi.Tables(0).Rows(i).Item("remarks").ToString

                                '-----------
                                Me.DataGridView1.Item("userupdate", currow).Value = dsi.Tables(0).Rows(i).Item("userupdate").ToString
                                Me.DataGridView1.Item("dateupdate", currow).Value = dsi.Tables(0).Rows(i).Item("dateupdate").ToString
                                Try
                                    Me.DataGridView1.Item("volume", currow).Value = dsi.Tables(0).Rows(i).Item("saycontainer").ToString

                                Catch ex As Exception

                                End Try
                                '------------
                            Next
                        End If
                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                    '---------------------------------------
                    Try


                        sqli = "select * from inbound_OverseaAirimport where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "

                        dsi = ReadDataSet(sqli)
                        If dsi.Tables(0).Rows.Count > 0 Then
                            For i = 0 To dsi.Tables(0).Rows.Count - 1



                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.DataGridView1.Item("Department_Shipment", currow).Value = "Oversea-Sea-Import" 'dsi.Tables(0).Rows(i).Item("Department_Shipment").ToString
                                Try
                                    Me.DataGridView1.Item("quotation", currow).Value = dsi.Tables(0).Rows(i).Item("quotationNo").ToString
                                Catch ex As Exception

                                End Try

                                Me.DataGridView1.Item("status", currow).Value = dsi.Tables(0).Rows(i).Item("status").ToString
                                Me.DataGridView1.Item("debitissued", currow).Value = dsi.Tables(0).Rows(i).Item("debitissued").ToString

                                Me.DataGridView1.Item("invoiceissued", currow).Value = dsi.Tables(0).Rows(i).Item("invoiceissued").ToString
                                Me.DataGridView1.Item("mbl", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString
                                Me.DataGridView1.Item("hbl", currow).Value = dsi.Tables(0).Rows(i).Item("hbl").ToString

                                Me.DataGridView1.Item("gflc_", currow).Value = dsi.Tables(0).Rows(i).Item("gflc").ToString
                                Me.DataGridView1.Item("gsc_", currow).Value = dsi.Tables(0).Rows(i).Item("gsc").ToString
                                Try
                                    Me.DataGridView1.Item("lot", currow).Value = dsi.Tables(0).Rows(i).Item("lot").ToString
                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("ref", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("POL_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pol").ToString
                                Me.DataGridView1.Item("POD_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pod").ToString
                                Me.DataGridView1.Item("eta", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("eta").ToString)
                                Me.DataGridView1.Item("etd", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString)
                                Me.DataGridView1.Item("sales", currow).Value = dsi.Tables(0).Rows(i).Item("salecode").ToString
                                Me.DataGridView1.Item("OPS", currow).Value = dsi.Tables(0).Rows(i).Item("ops").ToString
                                Me.DataGridView1.Item("datereport", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("datereport").ToString)
                                Me.DataGridView1.Item("remarks", currow).Value = dsi.Tables(0).Rows(i).Item("remarks").ToString

                                '-----------
                                Me.DataGridView1.Item("userupdate", currow).Value = dsi.Tables(0).Rows(i).Item("userupdate").ToString
                                Me.DataGridView1.Item("dateupdate", currow).Value = dsi.Tables(0).Rows(i).Item("dateupdate").ToString
                                Try
                                    Me.DataGridView1.Item("volume", currow).Value = dsi.Tables(0).Rows(i).Item("saycontainer").ToString

                                Catch ex As Exception

                                End Try
                                '------------
                            Next
                        End If
                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                    '---------------------------------------

                    '---------------------------------------
                    Try

                        'sqli = "select * from inbound_OverseaAirImport where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "

                        'dsi = ReadDataSet(sqli)
                        'If dsi.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dsi.Tables(0).Rows.Count - 1



                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "ACS-Air-Import" 'dsi.Tables(0).Rows(i).Item("Department_Shipment").ToString


                        '        Me.DataGridView1.Item("status", currow).Value = dsi.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dsi.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dsi.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dsi.Tables(0).Rows(i).Item("hbl").ToString
                        '        Me.DataGridView1.Item("ref", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pod").ToString
                        '        Me.DataGridView1.Item("eta", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("eta").ToString)
                        '        Me.DataGridView1.Item("etd", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString)
                        '        Me.DataGridView1.Item("sales", currow).Value = dsi.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dsi.Tables(0).Rows(i).Item("ops").ToString
                        '        Me.DataGridView1.Item("datereport", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("datereport").ToString)
                        '    Next
                        'End If




                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                    '---------------------------------------


                    Dim sqll As String
                    Dim dsl As New DataSet
                    Try




                        sqll = "select * from logistics where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "

                        dsl = ReadDataSet(sqll)
                        If dsl.Tables(0).Rows.Count > 0 Then
                            For i = 0 To dsl.Tables(0).Rows.Count - 1


                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                ' hien thi noi dung bill Ib
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                Me.DataGridView1.Item("Department_Shipment", currow).Value = "Logistics-Customs" 'dsl.Tables(0).Rows(i).Item("Department_Shipment").ToString
                                Try
                                    Me.DataGridView1.Item("quotation", currow).Value = dsl.Tables(0).Rows(i).Item("quotationNo").ToString
                                Catch ex As Exception

                                End Try

                                Me.DataGridView1.Item("status", currow).Value = dsl.Tables(0).Rows(i).Item("status").ToString
                                Me.DataGridView1.Item("debitissued", currow).Value = dsl.Tables(0).Rows(i).Item("debitissued").ToString

                                Me.DataGridView1.Item("invoiceissued", currow).Value = dsl.Tables(0).Rows(i).Item("invoiceissued").ToString

                                Me.DataGridView1.Item("mbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblcarrier").ToString
                                Me.DataGridView1.Item("hbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblmawb").ToString

                                Try
                                    Me.DataGridView1.Item("lot", currow).Value = dsl.Tables(0).Rows(i).Item("lot").ToString
                                Catch ex As Exception

                                End Try

                                Me.DataGridView1.Item("ref", currow).Value = dsl.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("POL_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pol").ToString
                                Me.DataGridView1.Item("POD_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pod").ToString
                                Try
                                    Me.DataGridView1.Item("eta", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("eta").ToString)

                                Catch ex As Exception

                                End Try
                                Try
                                    Me.DataGridView1.Item("etd", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("sailingdate").ToString)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("sales", currow).Value = dsl.Tables(0).Rows(i).Item("salecode").ToString
                                Me.DataGridView1.Item("OPS", currow).Value = dsl.Tables(0).Rows(i).Item("ops").ToString
                                Try
                                    Me.DataGridView1.Item("datereport", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("datereport").ToString)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("remarks", currow).Value = dsl.Tables(0).Rows(i).Item("remarks").ToString
                                '-----------
                                Me.DataGridView1.Item("userupdate", currow).Value = dsl.Tables(0).Rows(i).Item("userupdate").ToString
                                Me.DataGridView1.Item("dateupdate", currow).Value = dsl.Tables(0).Rows(i).Item("dateupdate").ToString
                                Try
                                    Me.DataGridView1.Item("volume", currow).Value = dsl.Tables(0).Rows(i).Item("saycontainer").ToString

                                Catch ex As Exception

                                End Try
                                '------------
                            Next
                        End If

                        '---------------------------------------
                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    Try




                        'sqll = "select * from logistics_truck where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "

                        'dsl = ReadDataSet(sqll)
                        'If dsl.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dsl.Tables(0).Rows.Count - 1


                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "Domestic-Truck" 'dsl.Tables(0).Rows(i).Item("Department_Shipment").ToString


                        '        Me.DataGridView1.Item("status", currow).Value = dsl.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dsl.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dsl.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblcarrier").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblmawb").ToString
                        '        Me.DataGridView1.Item("ref", currow).Value = dsl.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pod").ToString
                        '        Try
                        '            Me.DataGridView1.Item("eta", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("eta").ToString)

                        '        Catch ex As Exception

                        '        End Try
                        '        Try
                        '            Me.DataGridView1.Item("etd", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("sailingdate").ToString)

                        '        Catch ex As Exception

                        '        End Try
                        '        Me.DataGridView1.Item("sales", currow).Value = dsl.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dsl.Tables(0).Rows(i).Item("ops").ToString
                        '        Try
                        '            Me.DataGridView1.Item("datereport", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("datereport").ToString)

                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                Else
                    If Me.ComboBox2.Text = "Agency-Export" Then
                        Try



                            sqlo = "select * from outbound where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "
                            Me.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                            dso = ReadDataSet(sqlo)
                            If dso.Tables(0).Rows.Count > 0 Then
                                For i = 0 To dso.Tables(0).Rows.Count - 1


                                    Me.DataGridView1.Rows.Add(1)
                                    currow = DataGridView1.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView1.Item("Department_Shipment", currow).Value = "Agency-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                                    Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                                    Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString
                                    Try
                                        Me.DataGridView1.Item("quotation", currow).Value = dso.Tables(0).Rows(i).Item("quotationNo").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString

                                    Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                                    Me.DataGridView1.Item("gflc_", currow).Value = dso.Tables(0).Rows(i).Item("gflc").ToString
                                    Me.DataGridView1.Item("gsc_", currow).Value = dso.Tables(0).Rows(i).Item("gsc").ToString

                                    Try
                                        Me.DataGridView1.Item("lot", currow).Value = dso.Tables(0).Rows(i).Item("lot").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                                    Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pod").ToString
                                    Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                                    Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                                    Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                                    Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                                    Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)
                                    Me.DataGridView1.Item("remarks", currow).Value = dso.Tables(0).Rows(i).Item("remarks").ToString
                                    '-----------
                                    Me.DataGridView1.Item("userupdate", currow).Value = dso.Tables(0).Rows(i).Item("userupdate").ToString
                                    Me.DataGridView1.Item("dateupdate", currow).Value = dso.Tables(0).Rows(i).Item("dateupdate").ToString
                                    Try
                                        Me.DataGridView1.Item("volume", currow).Value = dso.Tables(0).Rows(i).Item("saycontainer").ToString

                                    Catch ex As Exception

                                    End Try
                                    '------------
                                Next
                            End If

                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                    End If



                    '--------------------try---------------
                    Try


                        'sqlo = "select * from outbound_OverseaSeaExport where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "
                        'Me.GroupBox2.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                        'dso = ReadDataSet(sqlo)
                        'If dso.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dso.Tables(0).Rows.Count - 1


                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "Oversea-Sea-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                        '        Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                        '        Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pod").ToString
                        '        Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                        '        Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                        '        Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                        '        Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)
                        '    Next
                        'End If

                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    '-----------------------------------
                    '-----------------------------------
                    If Me.ComboBox2.Text = "ACS-Air-Export" Then
                        Try


                            sqlo = "select * from outbound_OverseaAirExport where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "'"
                            Me.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                            dso = ReadDataSet(sqlo)
                            If dso.Tables(0).Rows.Count > 0 Then
                                For i = 0 To dso.Tables(0).Rows.Count - 1


                                    Me.DataGridView1.Rows.Add(1)
                                    currow = DataGridView1.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView1.Item("Department_Shipment", currow).Value = "ACS-Air-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                                    Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                                    Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString
                                    Try
                                        Me.DataGridView1.Item("quotation", currow).Value = dso.Tables(0).Rows(i).Item("quotationNo").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString
                                    Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                                    Me.DataGridView1.Item("gflc_", currow).Value = dso.Tables(0).Rows(i).Item("gflc").ToString
                                    Me.DataGridView1.Item("gsc_", currow).Value = dso.Tables(0).Rows(i).Item("gsc").ToString
                                    Try
                                        Me.DataGridView1.Item("lot", currow).Value = dso.Tables(0).Rows(i).Item("lot").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                                    Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("AirportDeparture").ToString
                                    Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("AirportDes").ToString
                                    Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                                    Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                                    Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                                    Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                                    Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)

                                    Me.DataGridView1.Item("remarks", currow).Value = dso.Tables(0).Rows(i).Item("remarks").ToString
                                    '-----------
                                    Me.DataGridView1.Item("userupdate", currow).Value = dso.Tables(0).Rows(i).Item("userupdate").ToString
                                    Me.DataGridView1.Item("dateupdate", currow).Value = dso.Tables(0).Rows(i).Item("dateupdate").ToString
                                    Try
                                        Me.DataGridView1.Item("volume", currow).Value = dso.Tables(0).Rows(i).Item("saycontainer").ToString

                                    Catch ex As Exception

                                    End Try
                                    '------------
                                Next
                            End If

                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                    End If



                    '-----------------------------------
                    Try


                        'sqlo = "select * from Outbound_ACSSeaExport where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "
                        'Me.GroupBox2.Text = "Shipments in " + CDate(Me.dtpShowDocument.Value.Date).Date.ToString("MMM") + " (from Date report)"
                        'dso = ReadDataSet(sqlo)
                        'If dso.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dso.Tables(0).Rows.Count - 1


                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "ACS-Sea-Export" 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                        '        Me.DataGridView1.Item("status", currow).Value = dso.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dso.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dso.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dso.Tables(0).Rows(i).Item("mblcarrier").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dso.Tables(0).Rows(i).Item("mblmawb").ToString

                        '        Me.DataGridView1.Item("ref", currow).Value = dso.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dso.Tables(0).Rows(i).Item("pod").ToString
                        '        Me.DataGridView1.Item("eta", currow).Value = CDate(dso.Tables(0).Rows(i).Item("eta").ToString)
                        '        Me.DataGridView1.Item("etd", currow).Value = CDate(dso.Tables(0).Rows(i).Item("sailingdate").ToString)
                        '        Me.DataGridView1.Item("sales", currow).Value = dso.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dso.Tables(0).Rows(i).Item("ops").ToString
                        '        Me.DataGridView1.Item("datereport", currow).Value = CDate(dso.Tables(0).Rows(i).Item("datereport").ToString)
                        '    Next
                        'End If

                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try


                    '-----------------------------------
                    Dim sqli As String
                    Dim dsi As New DataSet

                    If Me.ComboBox2.Text = "Agency-Import" Then
                        Try




                            sqli = "select * from inbound where  convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "

                            dsi = ReadDataSet(sqli)
                            If dsi.Tables(0).Rows.Count > 0 Then
                                For i = 0 To dsi.Tables(0).Rows.Count - 1



                                    Me.DataGridView1.Rows.Add(1)
                                    currow = DataGridView1.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView1.Item("Department_Shipment", currow).Value = "Agency-Import" 'dsi.Tables(0).Rows(i).Item("Department_Shipment").ToString


                                    Me.DataGridView1.Item("status", currow).Value = dsi.Tables(0).Rows(i).Item("status").ToString
                                    Me.DataGridView1.Item("debitissued", currow).Value = dsi.Tables(0).Rows(i).Item("debitissued").ToString
                                    Try
                                        Me.DataGridView1.Item("quotation", currow).Value = dsi.Tables(0).Rows(i).Item("quotationNo").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("invoiceissued", currow).Value = dsi.Tables(0).Rows(i).Item("invoiceissued").ToString

                                    Me.DataGridView1.Item("mbl", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString
                                    Me.DataGridView1.Item("hbl", currow).Value = dsi.Tables(0).Rows(i).Item("hbl").ToString


                                    Me.DataGridView1.Item("gflc_", currow).Value = dsi.Tables(0).Rows(i).Item("gflc").ToString
                                    Me.DataGridView1.Item("gsc_", currow).Value = dsi.Tables(0).Rows(i).Item("gsc").ToString
                                    Try
                                        Me.DataGridView1.Item("lot", currow).Value = dsi.Tables(0).Rows(i).Item("lot").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("ref", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                                    Me.DataGridView1.Item("POL_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView1.Item("POD_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pod").ToString
                                    Me.DataGridView1.Item("eta", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("eta").ToString)
                                    Me.DataGridView1.Item("etd", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString)
                                    Me.DataGridView1.Item("sales", currow).Value = dsi.Tables(0).Rows(i).Item("salecode").ToString
                                    Me.DataGridView1.Item("OPS", currow).Value = dsi.Tables(0).Rows(i).Item("ops").ToString
                                    Me.DataGridView1.Item("datereport", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("datereport").ToString)
                                    Me.DataGridView1.Item("remarks", currow).Value = dsi.Tables(0).Rows(i).Item("remarks").ToString

                                    '-----------
                                    Me.DataGridView1.Item("userupdate", currow).Value = dsi.Tables(0).Rows(i).Item("userupdate").ToString
                                    Me.DataGridView1.Item("dateupdate", currow).Value = dsi.Tables(0).Rows(i).Item("dateupdate").ToString
                                    Try
                                        Me.DataGridView1.Item("volume", currow).Value = dsi.Tables(0).Rows(i).Item("saycontainer").ToString

                                    Catch ex As Exception

                                    End Try
                                    '------------
                                Next
                            End If
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                    End If

                    '---------------------------------------
                    If Me.ComboBox2.Text = "ACS-Air-Import" Then
                        Try


                            sqli = "select * from inbound_OverseaAirimport where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "

                            dsi = ReadDataSet(sqli)
                            If dsi.Tables(0).Rows.Count > 0 Then
                                For i = 0 To dsi.Tables(0).Rows.Count - 1



                                    Me.DataGridView1.Rows.Add(1)
                                    currow = DataGridView1.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView1.Item("Department_Shipment", currow).Value = "Oversea-Sea-Import" 'dsi.Tables(0).Rows(i).Item("Department_Shipment").ToString

                                    Try
                                        Me.DataGridView1.Item("quotation", currow).Value = dsi.Tables(0).Rows(i).Item("quotationNo").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("status", currow).Value = dsi.Tables(0).Rows(i).Item("status").ToString
                                    Me.DataGridView1.Item("debitissued", currow).Value = dsi.Tables(0).Rows(i).Item("debitissued").ToString

                                    Me.DataGridView1.Item("invoiceissued", currow).Value = dsi.Tables(0).Rows(i).Item("invoiceissued").ToString
                                    Me.DataGridView1.Item("mbl", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString
                                    Me.DataGridView1.Item("hbl", currow).Value = dsi.Tables(0).Rows(i).Item("hbl").ToString


                                    Me.DataGridView1.Item("gflc_", currow).Value = dsi.Tables(0).Rows(i).Item("gflc").ToString
                                    Me.DataGridView1.Item("gsc_", currow).Value = dsi.Tables(0).Rows(i).Item("gsc").ToString
                                    Try
                                        Me.DataGridView1.Item("lot", currow).Value = dsi.Tables(0).Rows(i).Item("lot").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("ref", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                                    Me.DataGridView1.Item("POL_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView1.Item("POD_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pod").ToString
                                    Me.DataGridView1.Item("eta", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("eta").ToString)
                                    Me.DataGridView1.Item("etd", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString)
                                    Me.DataGridView1.Item("sales", currow).Value = dsi.Tables(0).Rows(i).Item("salecode").ToString
                                    Me.DataGridView1.Item("OPS", currow).Value = dsi.Tables(0).Rows(i).Item("ops").ToString
                                    Me.DataGridView1.Item("datereport", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("datereport").ToString)
                                    Me.DataGridView1.Item("remarks", currow).Value = dsi.Tables(0).Rows(i).Item("remarks").ToString
                                    '-----------
                                    Me.DataGridView1.Item("userupdate", currow).Value = dsi.Tables(0).Rows(i).Item("userupdate").ToString
                                    Me.DataGridView1.Item("dateupdate", currow).Value = dsi.Tables(0).Rows(i).Item("dateupdate").ToString
                                    Try
                                        Me.DataGridView1.Item("volume", currow).Value = dsi.Tables(0).Rows(i).Item("saycontainer").ToString

                                    Catch ex As Exception

                                    End Try
                                    '------------
                                Next
                            End If
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                    End If

                    '---------------------------------------

                    '---------------------------------------
                    Try

                        'sqli = "select * from inbound_OverseaAirImport where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "

                        'dsi = ReadDataSet(sqli)
                        'If dsi.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dsi.Tables(0).Rows.Count - 1



                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "ACS-Air-Import" 'dsi.Tables(0).Rows(i).Item("Department_Shipment").ToString


                        '        Me.DataGridView1.Item("status", currow).Value = dsi.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dsi.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dsi.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dsi.Tables(0).Rows(i).Item("mbl").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dsi.Tables(0).Rows(i).Item("hbl").ToString
                        '        Me.DataGridView1.Item("ref", currow).Value = dsi.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dsi.Tables(0).Rows(i).Item("pod").ToString
                        '        Me.DataGridView1.Item("eta", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("eta").ToString)
                        '        Me.DataGridView1.Item("etd", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("sailingdate").ToString)
                        '        Me.DataGridView1.Item("sales", currow).Value = dsi.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dsi.Tables(0).Rows(i).Item("ops").ToString
                        '        Me.DataGridView1.Item("datereport", currow).Value = CDate(dsi.Tables(0).Rows(i).Item("datereport").ToString)
                        '    Next
                        'End If




                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                    '---------------------------------------


                    Dim sqll As String
                    Dim dsl As New DataSet
                    If Me.ComboBox2.Text = "Logistics-Customs" Then
                        Try




                            sqll = "select * from logistics where convert(datetime,datereport) between '" & ddMMMyyyy(CDate(Me.dtpShowDocument.Value.Date)) & "' and  '" & ddMMMyyyy(CDate(Me.dtpShowDocument1.Value.Date)) & "' "

                            dsl = ReadDataSet(sqll)
                            If dsl.Tables(0).Rows.Count > 0 Then
                                For i = 0 To dsl.Tables(0).Rows.Count - 1


                                    Me.DataGridView1.Rows.Add(1)
                                    currow = DataGridView1.RowCount - 2
                                    ' hien thi noi dung bill Ib
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                                    Me.DataGridView1.Item("Department_Shipment", currow).Value = "Logistics-Customs" 'dsl.Tables(0).Rows(i).Item("Department_Shipment").ToString

                                    Try
                                        Me.DataGridView1.Item("quotation", currow).Value = dsl.Tables(0).Rows(i).Item("quotationNo").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("status", currow).Value = dsl.Tables(0).Rows(i).Item("status").ToString
                                    Me.DataGridView1.Item("debitissued", currow).Value = dsl.Tables(0).Rows(i).Item("debitissued").ToString

                                    Me.DataGridView1.Item("invoiceissued", currow).Value = dsl.Tables(0).Rows(i).Item("invoiceissued").ToString

                                    Me.DataGridView1.Item("mbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("hbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblmawb").ToString

                                    Try
                                        Me.DataGridView1.Item("lot", currow).Value = dsl.Tables(0).Rows(i).Item("lot").ToString
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("ref", currow).Value = dsl.Tables(0).Rows(i).Item("ref").ToString
                                    Me.DataGridView1.Item("POL_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pol").ToString
                                    Me.DataGridView1.Item("POD_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pod").ToString
                                    Try
                                        Me.DataGridView1.Item("eta", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("eta").ToString)

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.DataGridView1.Item("etd", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("sailingdate").ToString)

                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("sales", currow).Value = dsl.Tables(0).Rows(i).Item("salecode").ToString
                                    Me.DataGridView1.Item("OPS", currow).Value = dsl.Tables(0).Rows(i).Item("ops").ToString
                                    Try
                                        Me.DataGridView1.Item("datereport", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("datereport").ToString)

                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("remarks", currow).Value = dsl.Tables(0).Rows(i).Item("remarks").ToString
                                    '-----------
                                    Me.DataGridView1.Item("userupdate", currow).Value = dsl.Tables(0).Rows(i).Item("userupdate").ToString
                                    Me.DataGridView1.Item("dateupdate", currow).Value = dsl.Tables(0).Rows(i).Item("dateupdate").ToString
                                    Try
                                        Me.DataGridView1.Item("volume", currow).Value = dsl.Tables(0).Rows(i).Item("saycontainer").ToString

                                    Catch ex As Exception

                                    End Try
                                    '------------
                                Next
                            End If

                            '---------------------------------------
                        Catch ex As Exception
                            DisplayMessage(True, Err.Description)
                        End Try
                    End If




                    Try




                        'sqll = "select * from logistics_truck where convert(datetime,datereport) between '" & CDate(Me.dtpShowDocument.Value.Date) & "' and  '" & CDate(Me.dtpShowDocument1.Value.Date) & "' "

                        'dsl = ReadDataSet(sqll)
                        'If dsl.Tables(0).Rows.Count > 0 Then
                        '    For i = 0 To dsl.Tables(0).Rows.Count - 1


                        '        Me.DataGridView1.Rows.Add(1)
                        '        currow = DataGridView1.RowCount - 2
                        '        ' hien thi noi dung bill Ib
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.Blue
                        '        Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.White
                        '        Me.DataGridView1.Item("Department_Shipment", currow).Value = "Domestic-Truck" 'dsl.Tables(0).Rows(i).Item("Department_Shipment").ToString


                        '        Me.DataGridView1.Item("status", currow).Value = dsl.Tables(0).Rows(i).Item("status").ToString
                        '        Me.DataGridView1.Item("debitissued", currow).Value = dsl.Tables(0).Rows(i).Item("debitissued").ToString

                        '        Me.DataGridView1.Item("invoiceissued", currow).Value = dsl.Tables(0).Rows(i).Item("invoiceissued").ToString

                        '        Me.DataGridView1.Item("mbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblcarrier").ToString
                        '        Me.DataGridView1.Item("hbl", currow).Value = dsl.Tables(0).Rows(i).Item("mblmawb").ToString
                        '        Me.DataGridView1.Item("ref", currow).Value = dsl.Tables(0).Rows(i).Item("ref").ToString
                        '        Me.DataGridView1.Item("POL_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pol").ToString
                        '        Me.DataGridView1.Item("POD_Shipment", currow).Value = dsl.Tables(0).Rows(i).Item("pod").ToString
                        '        Try
                        '            Me.DataGridView1.Item("eta", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("eta").ToString)

                        '        Catch ex As Exception

                        '        End Try
                        '        Try
                        '            Me.DataGridView1.Item("etd", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("sailingdate").ToString)

                        '        Catch ex As Exception

                        '        End Try
                        '        Me.DataGridView1.Item("sales", currow).Value = dsl.Tables(0).Rows(i).Item("salecode").ToString
                        '        Me.DataGridView1.Item("OPS", currow).Value = dsl.Tables(0).Rows(i).Item("ops").ToString
                        '        Try
                        '            Me.DataGridView1.Item("datereport", currow).Value = CDate(dsl.Tables(0).Rows(i).Item("datereport").ToString)

                        '        Catch ex As Exception

                        '        End Try

                        '    Next
                        'End If
                    Catch ex As Exception
                        DisplayMessage(True, Err.Description)
                    End Try
                End If

                InsertAutoNumberToGrid(Me.DataGridView1)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Try
            If Me.DataGridView1.Rows.Count > 0 Then
                ExportExecel(Me.DataGridView1, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DetailsInDocToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetailsInDocToolStripMenuItem.Click
        Try
            Dim index As Integer = Me.DataGridView1.CurrentRow.Index

            If index >= 0 Then
            

                gchuyensobill = Me.DataGridView1.Item("hbl", index).Value.ToString



                gchuyenBophan = Me.DataGridView1.Item("Department_Shipment", index).Value.ToString

                If gchuyenBophan = "Agency-Export" Then
                    If LoginSucceeded = True Then
                        Dim form As New frmOutbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                        form.txtMBLMAWB.Text = gchuyensobill

                    End If
                End If


                If gchuyenBophan = "Agency-Import" Then
                    If LoginSucceeded = True Then
                        Dim form As New frmInbound 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                        form.txtHBL.Text = gchuyensobill

                    End If
                End If

                If gchuyenBophan = "ACS-Air-Import" Then
                    If LoginSucceeded = True Then
                        Dim form As New frmInbound_OverseaAirImport 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                        form.txtHBL.Text = gchuyensobill

                    End If
                End If

                If gchuyenBophan = "ACS-Air-Export" Then
                    If LoginSucceeded = True Then
                        Dim form As New frmOutbound_OverseaAirExport 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                        form.txtMBLMAWB.Text = gchuyensobill

                    End If
                End If

                If gchuyenBophan = "Logistics-Customs" Then
                    If LoginSucceeded = True Then
                        Dim form As New frmLogistics 'frmQuotationTico
                        form.MdiParent = frmMain
                        form.Show()
                        form.txtMBLMAWB.Text = gchuyensobill

                    End If
                End If


            End If
            '' lay id de kiem tra

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStrip1.Opening

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DetailsInDocToolStripMenuItem_Click(sender, e)
    End Sub
End Class