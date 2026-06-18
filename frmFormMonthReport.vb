Public Class frmFormMonthReport
    Public Sub all()
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                Dim currow As Integer
                Dim mau As Integer = -65281
                Dim i As Integer
                Dim sqlo, sqli, sqll As String
                Dim dso As New DataSet
                Dim dsi As New DataSet
                Dim dsl As New DataSet
                Me.DataGridView1.Rows.Clear()
                If UCase(Me.cboChinhanh.Text) = "ALL" Then
                    'If Me.chkoutbound.Checked = True Then
                    sqlo = "select DISTINCT REF from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select DISTINCT REF from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    'End If
                    'If Me.chkLogistics.Checked = True Then
                    sqll = "select DISTINCT REF from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    'End If
                End If
                If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                    'If Me.chkoutbound.Checked = True Then
                    sqlo = "select DISTINCT REF from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select DISTINCT REF from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    '     If Me.chkLogistics.Checked = True Then
                    sqll = "select DISTINCT REF from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
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
                            Dim SQLshowref As String = " select * from outbound where ref= '" & dso.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsoShowRef As New DataSet
                            dsoShowRef = ReadDataSet(SQLshowref)
                            If dsoShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'dso.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("ref").ToString 'dso.Tables(0).Rows(i).Item("bl_type").ToString
                                '-----------------------------
                                Dim tach() As String
                                Try
                                    tach = dsoShowRef.Tables(0).Rows(0).Item("shipper").ToString.Split(Chr(13))
                                    Me.DataGridView1.Item("Column3", currow).Value = tach(0)

                                Catch ex As Exception

                                End Try

                                Me.DataGridView1.Item("Column4", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsoShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("hblhawb").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If



                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsoCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0

                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '------------------------------
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dsohouse As New DataSet
                            SQLHOUSE = "select * from outbound where ref='" & dso.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dsohouse = ReadDataSet(SQLHOUSE)
                            If dsohouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dsohouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containertype where outboundid='" & dsohouse.Tables(0).Rows(ih).Item("blob_id").ToString & "'"
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
                                            'dme(soluong)
                                            If dsoCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsoCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    ' tinh cuoc========================================================
                                    Dim sqlPhi As String = ""
                                    Dim dsophi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from outboundfreight left join charge on outboundfreight.itemid =charge.charge_id  where outboundid='" & dsohouse.Tables(0).Rows(ih).Item("blob_id").ToString & "' "
                                    dsophi = ReadDataSet(sqlPhi)
                                    If dsophi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsophi.Tables(0).Rows.Count - 1
                                            If dsophi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsophi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsophi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsophi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsophi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsophi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsophi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsophi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next

                                    End If
                                Next

                                '=========================================================================
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type


                            '--- phi da thu

                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

                            '---
                            '----------------------------------


                        Next
                    End If
                End If
                '' hang nhap
                If Me.chkall.Checked = True Then ' hang xuat
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dsi.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                            Dim SQLshowref As String = " select * from inbound where ref= '" & dsi.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsiShowRef As New DataSet
                            dsiShowRef = ReadDataSet(SQLshowref)
                            If dsiShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'dsi.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("ref").ToString 'dsi.Tables(0).Rows(i).Item("bl_type").ToString
                                '-----------------------------
                                Dim tach() As String
                                Try
                                    tach = dsiShowRef.Tables(0).Rows(0).Item("shipper").ToString.Split(Chr(13))
                                    Me.DataGridView1.Item("Column3", currow).Value = tach(0)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("Column4", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsiShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("mbl").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("hbl").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("mbl").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("hbl").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If



                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsiCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0
                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '========================================
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dsihouse As New DataSet
                            SQLHOUSE = "select * from inbound where ref='" & dsi.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dsihouse = ReadDataSet(SQLHOUSE)
                            If dsihouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dsihouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containerrepair where inboundid='" & dsihouse.Tables(0).Rows(ih).Item("blib_id").ToString & "'"
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
                                            'dme(soluong)
                                            If dsiCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsiCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    '--- phi da thu
                                    Dim sqlPhi As String = ""
                                    Dim dsiphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & dsihouse.Tables(0).Rows(ih).Item("blib_id").ToString & "' "
                                    dsiphi = ReadDataSet(sqlPhi)
                                    If dsiphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsiphi.Tables(0).Rows.Count - 1
                                            If dsiphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsiphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsiphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsiphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsiphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsiphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsiphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsiphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next
                                    End If
                                Next
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type



                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

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
                            Dim SQLshowref As String = " select * from logistics where ref= '" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dslShowRef As New DataSet
                            dslShowRef = ReadDataSet(SQLshowref)
                            If dslShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'dsl.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dslShowRef.Tables(0).Rows(0).Item("ref").ToString 'dsl.Tables(0).Rows(i).Item("bl_type").ToString
                                '-----------------------------
                                Dim tach() As String
                                Try
                                    tach = dslShowRef.Tables(0).Rows(0).Item("shipper").ToString.Split(Chr(13))
                                    Me.DataGridView1.Item("Column3", currow).Value = tach(0)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("Column4", currow).Value = dslShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dslShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dslShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dslShowRef.Tables(0).Rows(0).Item("hblhawb").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dslShowRef.Tables(0).Rows(0).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dslShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dslShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dslShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dslShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dslShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If


                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dslCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0
                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '------------------------------
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dslhouse As New DataSet
                            SQLHOUSE = "select * from logistics where ref='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dslhouse = ReadDataSet(SQLHOUSE)
                            If dslhouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dslhouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containerlogistics where outboundid='" & dslhouse.Tables(0).Rows(ih).Item("blob_id").ToString & "'"
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
                                            'dem(soluong)
                                            If dslCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dslCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    '--- phi da thu
                                    Dim sqlPhi As String = ""
                                    Dim dslphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from logisticsfreight left join charge on logisticsfreight.itemid =charge.charge_id  where logisticsid='" & dslhouse.Tables(0).Rows(ih).Item("blob_id").ToString & "' "
                                    dslphi = ReadDataSet(sqlPhi)
                                    If dslphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dslphi.Tables(0).Rows.Count - 1
                                            If dslphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dslphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dslphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dslphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dslphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dslphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dslphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dslphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next
                                    End If
                                Next
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type



                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                ' lay total
                'Dim tongcont20, tongcont40 As Integer
                'Dim tongthu, tongchi As Double
                'Dim it As Integer = 0
                'For it = 0 To Me.DataGridView1.RowCount - 1
                '    tongcont20 += CInt(Me.DataGridView1.Item("Column7", it).Value)
                '    tongcont40 += CInt(Me.DataGridView1.Item("Column8", it).Value)
                '    tongthu += CDbl(Me.DataGridView1.Item("Column9", it).Value)
                '    tongchi += CDbl(Me.DataGridView1.Item("Column10", it).Value)
                'Next
                'Try
                '    Me.DataGridView1.Item("Column7", currow + 1).Value = tongcont20.ToString
                '    Me.DataGridView1.Item("Column8", currow + 1).Value = tongcont40.ToString
                'Catch ex As Exception

                'End Try

                'Me.DataGridView1.Item("Column9", currow + 1).Value = FormatNumber(tongthu.ToString, 2)
                'Me.DataGridView1.Item("Column10", currow + 1).Value = FormatNumber(tongchi.ToString, 2)


                '--------------------
                InsertAutoNumberToGrid(Me.DataGridView1)

            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
        Catch ex As Exception

        End Try
    End Sub
    Public Sub iol()
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                Dim currow As Integer
                Dim mau As Integer = -65281
                Dim i As Integer
                Me.DataGridView1.Rows.Clear()
                If UCase(Me.cboChinhanh.Text) = "ALL" Then
                    If Me.chkoutbound.Checked = True Then
                        sql = "select DISTINCT REF from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    End If
                    If Me.chkinbound.Checked = True Then
                        sql = "select DISTINCT REF from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    End If
                    If Me.chkLogistics.Checked = True Then
                        sql = "select DISTINCT REF from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
                    End If
                End If
                If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                    If Me.chkoutbound.Checked = True Then
                        sql = "select DISTINCT REF from outbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' and ref like '%" & Me.cboChinhanh.Text & "%'"
                    End If
                    If Me.chkinbound.Checked = True Then
                        sql = "select DISTINCT REF from inbound where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                    End If
                    If Me.chkLogistics.Checked = True Then
                        sql = "select DISTINCT REF from logistics where convert(datetime,datereport) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and ref like '%" & Me.cboChinhanh.Text & "%'"
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
                            Dim SQLshowref As String = " select * from outbound where ref= '" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsShowRef As New DataSet
                            dsShowRef = ReadDataSet(SQLshowref)
                            If dsShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'ds.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsShowRef.Tables(0).Rows(0).Item("ref").ToString 'ds.Tables(0).Rows(i).Item("bl_type").ToString
                                '-----------------------------
                                Dim tach() As String
                                Try
                                    tach = dsShowRef.Tables(0).Rows(0).Item("shipper").ToString.Split(Chr(13))
                                    Me.DataGridView1.Item("Column3", currow).Value = tach(0)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("Column4", currow).Value = dsShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsShowRef.Tables(0).Rows(0).Item("hblhawb").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If



                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0

                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '------------------------------
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dshouse As New DataSet
                            SQLHOUSE = "select * from outbound where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dshouse = ReadDataSet(SQLHOUSE)
                            If dshouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dshouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containertype where outboundid='" & dshouse.Tables(0).Rows(ih).Item("blob_id").ToString & "'"
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
                                            'dme(soluong)
                                            If dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    ' tinh cuoc========================================================
                                    Dim sqlPhi As String = ""
                                    Dim dsphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from outboundfreight left join charge on outboundfreight.itemid =charge.charge_id  where outboundid='" & dshouse.Tables(0).Rows(ih).Item("blob_id").ToString & "' "
                                    dsphi = ReadDataSet(sqlPhi)
                                    If dsphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsphi.Tables(0).Rows.Count - 1
                                            If dsphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next

                                    End If
                                Next

                                '=========================================================================
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type


                            '--- phi da thu

                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

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
                            Dim SQLshowref As String = " select * from inbound where ref= '" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsShowRef As New DataSet
                            dsShowRef = ReadDataSet(SQLshowref)
                            If dsShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'ds.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsShowRef.Tables(0).Rows(0).Item("ref").ToString 'ds.Tables(0).Rows(i).Item("bl_type").ToString
                                '-----------------------------
                                Dim tach() As String
                                Try
                                    tach = dsShowRef.Tables(0).Rows(0).Item("shipper").ToString.Split(Chr(13))
                                    Me.DataGridView1.Item("Column3", currow).Value = tach(0)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("Column4", currow).Value = dsShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mbl").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsShowRef.Tables(0).Rows(0).Item("hbl").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mbl").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsShowRef.Tables(0).Rows(0).Item("hbl").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If



                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0
                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '========================================
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dshouse As New DataSet
                            SQLHOUSE = "select * from inbound where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dshouse = ReadDataSet(SQLHOUSE)
                            If dshouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dshouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containerrepair where inboundid='" & dshouse.Tables(0).Rows(ih).Item("blib_id").ToString & "'"
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
                                            'dme(soluong)
                                            If dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    '--- phi da thu
                                    Dim sqlPhi As String = ""
                                    Dim dsphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & dshouse.Tables(0).Rows(ih).Item("blib_id").ToString & "' "
                                    dsphi = ReadDataSet(sqlPhi)
                                    If dsphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsphi.Tables(0).Rows.Count - 1
                                            If dsphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next
                                    End If
                                Next
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type



                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

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
                            Dim SQLshowref As String = " select * from logistics where ref= '" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsShowRef As New DataSet
                            dsShowRef = ReadDataSet(SQLshowref)
                            If dsShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'ds.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsShowRef.Tables(0).Rows(0).Item("ref").ToString 'ds.Tables(0).Rows(i).Item("bl_type").ToString
                                '-----------------------------
                                Dim tach() As String
                                Try
                                    tach = dsShowRef.Tables(0).Rows(0).Item("shipper").ToString.Split(Chr(13))
                                    Me.DataGridView1.Item("Column3", currow).Value = tach(0)

                                Catch ex As Exception

                                End Try
                                Me.DataGridView1.Item("Column4", currow).Value = dsShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsShowRef.Tables(0).Rows(0).Item("hblhawb").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If


                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0
                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '------------------------------
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dshouse As New DataSet
                            SQLHOUSE = "select * from logistics where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dshouse = ReadDataSet(SQLHOUSE)
                            If dshouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dshouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containerlogistics where outboundid='" & dshouse.Tables(0).Rows(ih).Item("blob_id").ToString & "'"
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
                                            'dem(soluong)
                                            If dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    '--- phi da thu
                                    Dim sqlPhi As String = ""
                                    Dim dsphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from logisticsfreight left join charge on logisticsfreight.itemid =charge.charge_id  where logisticsid='" & dshouse.Tables(0).Rows(ih).Item("blob_id").ToString & "' "
                                    dsphi = ReadDataSet(sqlPhi)
                                    If dsphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsphi.Tables(0).Rows.Count - 1
                                            If dsphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next
                                    End If
                                Next
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type



                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                ' lay total
                Dim tongcont20, tongcont40 As Integer
                Dim tongthu, tongchi As Double
                Dim it As Integer = 0
                For it = 0 To Me.DataGridView1.RowCount - 1
                    tongcont20 += CInt(Me.DataGridView1.Item("Column7", it).Value)
                    tongcont40 += CInt(Me.DataGridView1.Item("Column8", it).Value)
                    tongthu += CDbl(Me.DataGridView1.Item("Column9", it).Value)
                    tongchi += CDbl(Me.DataGridView1.Item("Column10", it).Value)
                Next
                Try
                    Me.DataGridView1.Item("Column7", currow + 1).Value = tongcont20.ToString
                    Me.DataGridView1.Item("Column8", currow + 1).Value = tongcont40.ToString
                Catch ex As Exception

                End Try
                Try
                    Me.DataGridView1.Item("Column9", currow + 1).Value = FormatNumber(tongthu.ToString, 2)
                    Me.DataGridView1.Item("Column10", currow + 1).Value = FormatNumber(tongchi.ToString, 2)
                Catch ex As Exception

                End Try



                '--------------------
                InsertAutoNumberToGrid(Me.DataGridView1)

            Catch ex As Exception
                DisplayMessage(True, Err.Description)
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

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                Dim currow As Integer
                Dim mau As Integer = -65281
                Dim i As Integer
                Dim sqlo, sqli, sqll As String
                Dim dso As New DataSet
                Dim dsi As New DataSet
                Dim dsl As New DataSet
                Me.DataGridView1.Rows.Clear()
                If UCase(Me.cboChinhanh.Text) = "ALL" Then
                    'If Me.chkoutbound.Checked = True Then
                    sqlo = "select DISTINCT REF from outbound where ref like '%" & Me.txtref.Text & "%' "
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select DISTINCT REF from inbound where ref like '%" & Me.txtref.Text & "%' "
                    'End If
                    'If Me.chkLogistics.Checked = True Then
                    sqll = "select DISTINCT REF from logistics where ref like '%" & Me.txtref.Text & "%' "
                    'End If
                End If
                If UCase(Me.cboChinhanh.Text) <> "ALL" Then
                    'If Me.chkoutbound.Checked = True Then
                    sqlo = "select DISTINCT REF from outbound where ref like '%" & Me.txtref.Text & "%' and  ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    'If Me.chkinbound.Checked = True Then
                    sqli = "select DISTINCT REF from inbound where ref like '%" & Me.txtref.Text & "%'  and ref like '%" & Me.cboChinhanh.Text & "%'"
                    'End If
                    '     If Me.chkLogistics.Checked = True Then
                    sqll = "select DISTINCT REF from logistics where ref like '%" & Me.txtref.Text & "%' and ref like '%" & Me.cboChinhanh.Text & "%'"
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
                            Dim SQLshowref As String = " select * from outbound where ref= '" & dso.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsoShowRef As New DataSet
                            dsoShowRef = ReadDataSet(SQLshowref)
                            If dsoShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'dso.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("ref").ToString 'dso.Tables(0).Rows(i).Item("bl_type").ToString
                                Me.DataGridView1.Item("Column3", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("shipper").ToString
                                Me.DataGridView1.Item("Column4", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsoShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("hblhawb").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsoShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If



                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsoCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0

                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '------------------------------
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dsohouse As New DataSet
                            SQLHOUSE = "select * from outbound where ref='" & dso.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dsohouse = ReadDataSet(SQLHOUSE)
                            If dsohouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dsohouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containertype where outboundid='" & dsohouse.Tables(0).Rows(ih).Item("blob_id").ToString & "'"
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
                                            'dme(soluong)
                                            If dsoCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsoCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    ' tinh cuoc========================================================
                                    Dim sqlPhi As String = ""
                                    Dim dsophi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from outboundfreight left join charge on outboundfreight.itemid =charge.charge_id  where outboundid='" & dsohouse.Tables(0).Rows(ih).Item("blob_id").ToString & "' "
                                    dsophi = ReadDataSet(sqlPhi)
                                    If dsophi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsophi.Tables(0).Rows.Count - 1
                                            If dsophi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsophi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsophi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsophi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsophi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsophi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsophi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsophi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next

                                    End If
                                Next

                                '=========================================================================
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type


                            '--- phi da thu

                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

                            '---
                            '----------------------------------


                        Next
                    End If
                End If
                '' hang nhap
                If Me.chkall.Checked = True Then ' hang xuat
                    If dsi.Tables(0).Rows.Count > 0 Then
                        ' ung moi dong tga lay so lieu
                        For i = 0 To dsi.Tables(0).Rows.Count - 1
                            mau -= 100
                            Me.DataGridView1.Rows.Add(1)
                            currow = Me.DataGridView1.RowCount - 2
                            ' hien thi noi dung bill Ib
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                            Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Black
                            Dim SQLshowref As String = " select * from inbound where ref= '" & dsi.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dsiShowRef As New DataSet
                            dsiShowRef = ReadDataSet(SQLshowref)
                            If dsiShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'dsi.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("ref").ToString 'dsi.Tables(0).Rows(i).Item("bl_type").ToString
                                Me.DataGridView1.Item("Column3", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("shipper").ToString
                                Me.DataGridView1.Item("Column4", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dsiShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("mbl").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("hbl").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("mbl").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("hbl").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dsiShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If



                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dsiCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0
                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '========================================
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dsihouse As New DataSet
                            SQLHOUSE = "select * from inbound where ref='" & dsi.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dsihouse = ReadDataSet(SQLHOUSE)
                            If dsihouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dsihouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containerrepair where inboundid='" & dsihouse.Tables(0).Rows(ih).Item("blib_id").ToString & "'"
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
                                            'dme(soluong)
                                            If dsiCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dsiCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    '--- phi da thu
                                    Dim sqlPhi As String = ""
                                    Dim dsiphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from inboundfreight left join charge on inboundfreight.itemid =charge.charge_id  where inboundid='" & dsihouse.Tables(0).Rows(ih).Item("blib_id").ToString & "' "
                                    dsiphi = ReadDataSet(sqlPhi)
                                    If dsiphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dsiphi.Tables(0).Rows.Count - 1
                                            If dsiphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dsiphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dsiphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dsiphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dsiphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dsiphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dsiphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dsiphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next
                                    End If
                                Next
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type



                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

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
                            Dim SQLshowref As String = " select * from logistics where ref= '" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            Dim dslShowRef As New DataSet
                            dslShowRef = ReadDataSet(SQLshowref)
                            If dslShowRef.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("Column1", currow).Value = currow + 1 'dsl.Tables(0).Rows(i).Item("ref").ToString
                                Me.DataGridView1.Item("Column2", currow).Value = dslShowRef.Tables(0).Rows(0).Item("ref").ToString 'dsl.Tables(0).Rows(i).Item("bl_type").ToString
                                Me.DataGridView1.Item("Column3", currow).Value = dslShowRef.Tables(0).Rows(0).Item("shipper").ToString
                                Me.DataGridView1.Item("Column4", currow).Value = dslShowRef.Tables(0).Rows(0).Item("agencyname").ToString
                                If dslShowRef.Tables(0).Rows(0).Item("air").ToString = "True" Then
                                    Me.DataGridView1.Item("Column5", currow).Value = dslShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dslShowRef.Tables(0).Rows(0).Item("hblhawb").ToString
                                Else
                                    Me.DataGridView1.Item("Column5", currow).Value = dslShowRef.Tables(0).Rows(0).Item("mblcarrier").ToString
                                    Me.DataGridView1.Item("Column6", currow).Value = dslShowRef.Tables(0).Rows(0).Item("mblmawb").ToString
                                End If
                                '-------------------------------------------
                                Me.DataGridView1.Item("Column12", currow).Value = dslShowRef.Tables(0).Rows(0).Item("itemSITC").ToString
                                Me.DataGridView1.Item("Column13", currow).Value = dslShowRef.Tables(0).Rows(0).Item("salecode").ToString
                                Me.DataGridView1.Item("Column14", currow).Value = dslShowRef.Tables(0).Rows(0).Item("ops").ToString
                                Me.DataGridView1.Item("Column15", currow).Value = dslShowRef.Tables(0).Rows(0).Item("userupdate").ToString
                            End If


                            Dim j As Integer
                            Dim sqlCont As String = ""
                            Dim dslCont As New DataSet
                            '---
                            Dim kg As Double = 0
                            Dim kien As Double = 0
                            Dim khoi As Double = 0
                            Dim cont As String = ""
                            Dim type As String = ""
                            Dim cont20 As Integer = 0
                            Dim cont40 As Integer = 0
                            Dim tongthuUSD As Double = 0
                            Dim tongchiUSD As Double = 0
                            Dim tongthuVND As Double = 0
                            Dim tongchiVND As Double = 0
                            '------------------------------
                            Dim ih As Integer
                            Dim SQLHOUSE As String
                            Dim dslhouse As New DataSet
                            SQLHOUSE = "select * from logistics where ref='" & dsl.Tables(0).Rows(i).Item("ref").ToString & "' "
                            dslhouse = ReadDataSet(SQLHOUSE)
                            If dslhouse.Tables(0).Rows.Count > 0 Then
                                For ih = 0 To dslhouse.Tables(0).Rows.Count - 1
                                    sqlCont = "select * from containerlogistics where outboundid='" & dslhouse.Tables(0).Rows(ih).Item("blob_id").ToString & "'"
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
                                            'dem(soluong)
                                            If dslCont.Tables(0).Rows(j).Item("containertype").ToString Like "*20*" Then
                                                cont20 += 1
                                            ElseIf dslCont.Tables(0).Rows(j).Item("containertype").ToString Like "*40*" Then
                                                cont40 += 1
                                            End If
                                            ' 
                                        Next
                                    End If
                                    '--- phi da thu
                                    Dim sqlPhi As String = ""
                                    Dim dslphi As New DataSet
                                    Dim k As Integer
                                    Dim tenphi As String = ""

                                    sqlPhi = "select * from logisticsfreight left join charge on logisticsfreight.itemid =charge.charge_id  where logisticsid='" & dslhouse.Tables(0).Rows(ih).Item("blob_id").ToString & "' "
                                    dslphi = ReadDataSet(sqlPhi)
                                    If dslphi.Tables(0).Rows.Count > 0 Then
                                        For k = 0 To dslphi.Tables(0).Rows.Count - 1
                                            If dslphi.Tables(0).Rows(k).Item("currency").ToString.Trim = "USD" Then
                                                If dslphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                                    tongthuUSD += CDbl(dslphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongthuVND += CDbl(dslphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                                If dslphi.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                                    tongchiUSD += CDbl(dslphi.Tables(0).Rows(k).Item("pricetruocthue").ToString)
                                                    tongchiVND += CDbl(dslphi.Tables(0).Rows(k).Item("pricenotaxvnd").ToString)
                                                End If
                                            End If

                                            tenphi += dslphi.Tables(0).Rows(k).Item("dvt").ToString & "; "
                                        Next
                                    End If
                                Next
                            End If

                            ' them vao excel
                            Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString 'FormatNumber(kien.ToString, 0) & " " & type & "/" & FormatNumber(kg.ToString, 3) & " Kgs" & "/" & FormatNumber(khoi.ToString, 3) & " CBM"

                            Me.DataGridView1.Item("Column8", currow).Value = cont40.ToString 'FormatNumber(kien.ToString, 0) & " " & type



                            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tongthuUSD.ToString, 2)
                            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tongchiUSD.ToString, 2)
                            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber((tongthuUSD - tongchiUSD).ToString, 2)
                            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tongthuVND.ToString, 0)
                            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tongchiVND.ToString, 0)
                            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber((tongthuVND - tongchiVND).ToString, 0)

                            '---
                            '----------------------------------

                        Next
                    End If
                End If
                ' lay total
                'Dim tongcont20, tongcont40 As Integer
                'Dim tongthu, tongchi As Double
                'Dim it As Integer = 0
                'For it = 0 To Me.DataGridView1.RowCount - 1
                '    tongcont20 += CInt(Me.DataGridView1.Item("Column7", it).Value)
                '    tongcont40 += CInt(Me.DataGridView1.Item("Column8", it).Value)
                '    tongthu += CDbl(Me.DataGridView1.Item("Column9", it).Value)
                '    tongchi += CDbl(Me.DataGridView1.Item("Column10", it).Value)
                'Next
                'Try
                '    Me.DataGridView1.Item("Column7", currow + 1).Value = tongcont20.ToString
                '    Me.DataGridView1.Item("Column8", currow + 1).Value = tongcont40.ToString
                'Catch ex As Exception

                'End Try

                'Me.DataGridView1.Item("Column9", currow + 1).Value = FormatNumber(tongthu.ToString, 2)
                'Me.DataGridView1.Item("Column10", currow + 1).Value = FormatNumber(tongchi.ToString, 2)


                '--------------------
                InsertAutoNumberToGrid(Me.DataGridView1)

            Catch ex As Exception
                DisplayMessage(True, Err.Description)
            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmFormMonthReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Shell("C:\WINDOWS\system32\calc.exe", AppWinStyle.NormalFocus)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
        Try
            Dim tong As Double = 0
            If Me.DataGridView1.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.DataGridView1.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsum.Text = FormatNumber(tong.ToString)
            Catch ex As Exception

            End Try

         
        Catch ex As Exception

        End Try
    End Sub
End Class