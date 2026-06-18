Public Class frmThongbaocongnoLog
    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim sqlitem As String
            Dim dsitem As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                ' moi bill ta lay freight
                If Me.chkCusThu.Checked = True Then
                    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Debit' and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' "

                Else
                    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Debit'"

                End If
                dsF = ReadDataSet(sqlF)
                If dsF.Tables(0).Rows.Count > 0 Then


                    For i = 0 To dsF.Tables(0).Rows.Count - 1
                        'kiem tra debit
                        ' lay customerid debit
                        Dim sqlcus As String
                        Dim dsCus As New DataSet
                        sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "'"
                        dsCus = ReadDataSet(sqlcus)
                        ' lay han cong no khach hang 
                        Dim hcn As Integer
                        Try
                            hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                        Catch ex As Exception
                            hcn = 0
                        End Try
                        ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                        If dsF.Tables(0).Rows(i).Item("paycheck").ToString = "False" Then
                            If Me.chkallHCN.Checked = True Then
                                ' If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                Me.dgdListCongno.Rows.Add(1)
                                Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                '---
                                Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                '-----
                                sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                dsitem = ReadDataSet(sqlitem)
                                Try
                                    Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                Catch ex As Exception

                                End Try

                                Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                '--------------------
                                ' Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                rowtang += 1
                                '    End If

                            Else
                                If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                    Me.dgdListCongno.Rows.Add(1)
                                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    '---
                                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                    '-----
                                    sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                    dsitem = ReadDataSet(sqlitem)
                                    Try
                                        Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                    Catch ex As Exception

                                    End Try

                                    Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                    Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                    '--------------------
                                    ' Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                    Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                    Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                    Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                    rowtang += 1
                                End If

                            End If

                        End If






            Next 'het(freight)
                End If
            Next ' het bill
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.dgdListCongno, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sql, strhbl As String
        Try
            ' lay hang xuat

            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                If ds.Tables(0).Rows(j).Item("hBL").ToString = "HCM/SY1112-001TH" Then
                    DisplayMessage(True, "")
                End If
                For i = 1 To 10
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeriddebit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer
                    Try
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    Catch ex As Exception
                        hcn = 0
                    End Try

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckdebit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            strhbl = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString

                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemsdebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricedebit" + i.ToString).ToString


                            Me.dgdListCongno.Item("tigia", rowtang).Value = ds.Tables(0).Rows(j).Item("tigiadebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString



                            Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString



                            rowtang += 1
                        End If

                    End If






                Next
            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description & strhbl)
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1


                For i = 1 To 12
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeriddebit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer = 0
                    If dsCus.Tables(0).Rows.Count > 0 Then
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    End If

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckdebit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString

                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemsdebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricedebit" + i.ToString).ToString


                            Try
                                Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                            Catch ex As Exception

                            End Try







                            rowtang += 1
                        End If

                    End If






                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim sqlitem As String
            Dim dsitem As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics where ref like '%" & Me.txtref.Text & "%'"
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                ' moi bill ta lay freight
                'If Me.chkCusThu.Checked = True Then
                '    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Debit' and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'"

                'Else
                sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Debit'"

                '  End If
                dsF = ReadDataSet(sqlF)
                If dsF.Tables(0).Rows.Count > 0 Then


                    For i = 0 To dsF.Tables(0).Rows.Count - 1
                        'kiem tra debit
                        ' lay customerid debit
                        Dim sqlcus As String
                        Dim dsCus As New DataSet
                        sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "'"
                        dsCus = ReadDataSet(sqlcus)
                        ' lay han cong no khach hang 
                        Dim hcn As Integer
                        Try
                            hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                        Catch ex As Exception
                            hcn = 0
                        End Try
                        ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                        If dsF.Tables(0).Rows(i).Item("paycheck").ToString = "False" Then
                            If Me.chkallHCN.Checked = True Then
                                ' If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                Me.dgdListCongno.Rows.Add(1)
                                Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                '---
                                Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                '-----
                                sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                dsitem = ReadDataSet(sqlitem)
                                Try
                                    Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                Catch ex As Exception

                                End Try
                                Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                '--------------------
                                '   Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                rowtang += 1
                                'End If
                            Else
                                If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                    Me.dgdListCongno.Rows.Add(1)
                                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    '---
                                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                    '-----
                                    sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                    dsitem = ReadDataSet(sqlitem)
                                    Try
                                        Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                    Catch ex As Exception

                                    End Try
                                    Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                    Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                    '--------------------
                                    '   Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                    Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                    Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                    Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                    rowtang += 1
                                End If
                            End If


                        End If






            Next 'het(freight)
                End If
            Next ' het bill
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim sql, strhbl As String
        Try
            ' lay hang xuat

            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where ref like '%" & Me.txtref.Text & "%' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                If ds.Tables(0).Rows(j).Item("hBL").ToString = "HCM/SY1112-001TH" Then
                    DisplayMessage(True, "")
                End If
                For i = 1 To 10
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeriddebit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer
                    Try
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    Catch ex As Exception
                        hcn = 0
                    End Try

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckdebit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            strhbl = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                            Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemsdebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricedebit" + i.ToString).ToString


                            Me.dgdListCongno.Item("tigia", rowtang).Value = ds.Tables(0).Rows(j).Item("tigiadebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                            Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString





                            rowtang += 1
                        End If

                    End If






                Next
            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description & strhbl)
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim sqlitem As String
            Dim dsitem As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics where convert(datetime,sailingdate) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                ' moi bill ta lay freight
                'If Me.chkCusThu.Checked = True Then
                '    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Debit' and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' "

                'Else
                sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Debit'"

                ' End If
                dsF = ReadDataSet(sqlF)
                If dsF.Tables(0).Rows.Count > 0 Then


                    For i = 0 To dsF.Tables(0).Rows.Count - 1
                        'kiem tra debit
                        ' lay customerid debit
                        Dim sqlcus As String
                        Dim dsCus As New DataSet
                        sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "'"
                        dsCus = ReadDataSet(sqlcus)
                        ' lay han cong no khach hang 
                        Dim hcn As Integer
                        Try
                            hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                        Catch ex As Exception
                            hcn = 0
                        End Try
                        ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                        If dsF.Tables(0).Rows(i).Item("paycheck").ToString = "False" Then
                            If Me.chkallHCN.Checked = True Then
                                ' If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                Me.dgdListCongno.Rows.Add(1)
                                Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                '---
                                Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                '-----
                                sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                dsitem = ReadDataSet(sqlitem)
                                Try
                                    Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                Catch ex As Exception

                                End Try
                                Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                '--------------------
                                '   Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                rowtang += 1
                                'End If

                            Else
                                If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                    Me.dgdListCongno.Rows.Add(1)
                                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    '---
                                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                    '-----
                                    sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                    dsitem = ReadDataSet(sqlitem)
                                    Try
                                        Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                    Catch ex As Exception

                                    End Try
                                    Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                    Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                    '--------------------
                                    '   Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                    Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                    Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                    Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                    rowtang += 1
                                End If

                            End If

                        End If






            Next 'het(freight)
                End If
            Next ' het bill
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        '
        Dim sql, strhbl As String
        Try
            ' lay hang xuat

            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where convert(datetime,eta) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                'If ds.Tables(0).Rows(j).Item("hBL").ToString = "HCM/SY1112-001TH" Then
                '    DisplayMessage(True, "")
                'End If
                For i = 1 To 10
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeriddebit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer
                    Try
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    Catch ex As Exception
                        hcn = 0
                    End Try

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckdebit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            strhbl = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                            Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemsdebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuedebit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricedebit" + i.ToString).ToString


                            Me.dgdListCongno.Item("tigia", rowtang).Value = ds.Tables(0).Rows(j).Item("tigiadebit" + i.ToString).ToString
                            Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString



                            Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString



                            rowtang += 1
                        End If

                    End If






                Next
            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description & strhbl)
        End Try
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim sqlitem As String
            Dim dsitem As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                ' moi bill ta lay freight
                If Me.chkcustra.Checked = True Then
                    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Credit' and customerid='" & FindValueID(Me.cbocustra, Me.cbocustra.Text) & "' "

                Else
                    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Credit'  "

                End If
                dsF = ReadDataSet(sqlF)
                If dsF.Tables(0).Rows.Count > 0 Then


                    For i = 0 To dsF.Tables(0).Rows.Count - 1
                        'kiem tra debit
                        ' lay customerid debit
                        Dim sqlcus As String
                        Dim dsCus As New DataSet
                        'If Me.chkcustra.Checked = True Then
                        '    sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "' "

                        'Else
                        sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "'"

                        'End If
                        dsCus = ReadDataSet(sqlcus)
                        ' lay han cong no khach hang 
                        Dim hcn As Integer
                        Try
                            hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                        Catch ex As Exception
                            hcn = 0
                        End Try
                        ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                        If dsF.Tables(0).Rows(i).Item("paycheck").ToString = "False" Then
                            If Me.chkallHCN.Checked = True Then
                                'If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                Me.dgdListCongno.Rows.Add(1)
                                Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                '---
                                Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                '-----
                                sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                dsitem = ReadDataSet(sqlitem)
                                Try
                                    Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                Catch ex As Exception

                                End Try
                                Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                '--------------------
                                ' Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                rowtang += 1
                                'End If
                            Else
                                If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                    Me.dgdListCongno.Rows.Add(1)
                                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    '---
                                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                    '-----
                                    sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                    dsitem = ReadDataSet(sqlitem)
                                    Try
                                        Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                    Catch ex As Exception

                                    End Try
                                    Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                    Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                    '--------------------
                                    ' Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                    Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                    Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                    Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                    rowtang += 1
                                End If
                            End If


                        End If






            Next 'het(freight)
                End If
            Next ' het bill
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Dim sql, strhbl As String
        Try
            ' lay hang xuat

            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                'If ds.Tables(0).Rows(j).Item("hBL").ToString = "HCM/SY1112-001TH" Then
                '    DisplayMessage(True, "")
                'End If
                For i = 1 To 10
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeridcredit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer
                    Try
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    Catch ex As Exception
                        hcn = 0
                    End Try

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckcredit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            strhbl = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString

                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemscredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencycredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricecredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricecredit" + i.ToString).ToString


                            Me.dgdListCongno.Item("tigia", rowtang).Value = ds.Tables(0).Rows(j).Item("tigiacredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString


                            Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString




                            rowtang += 1
                        End If

                    End If






                Next
            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description & strhbl)
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim sqlitem As String
            Dim dsitem As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics where ref like '%" & Me.txtref.Text & "%'"
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                ' moi bill ta lay freight
                'If Me.chkcustra.Checked = True Then
                '    sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Credit' "

                'Else
                sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Credit'"

                ' End If
                dsF = ReadDataSet(sqlF)
                If dsF.Tables(0).Rows.Count > 0 Then


                    For i = 0 To dsF.Tables(0).Rows.Count - 1
                        'kiem tra debit
                        ' lay customerid debit
                        Dim sqlcus As String
                        Dim dsCus As New DataSet
                        sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "'"
                        dsCus = ReadDataSet(sqlcus)
                        ' lay han cong no khach hang 
                        Dim hcn As Integer
                        Try
                            hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                        Catch ex As Exception
                            hcn = 0
                        End Try
                        ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                        If dsF.Tables(0).Rows(i).Item("paycheck").ToString = "False" Then
                            If Me.chkallHCN.Checked = True Then
                                'If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                Me.dgdListCongno.Rows.Add(1)
                                Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                '---
                                Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                '-----
                                sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                dsitem = ReadDataSet(sqlitem)
                                Try
                                    Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try
                                Try
                                    Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                Catch ex As Exception

                                End Try

                                Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                '--------------------
                                '  Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                rowtang += 1
                                'End If
                            Else
                                If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                    Me.dgdListCongno.Rows.Add(1)
                                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    '---
                                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                    '-----
                                    sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                    dsitem = ReadDataSet(sqlitem)
                                    Try
                                        Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try
                                    Try
                                        Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                    Catch ex As Exception

                                    End Try

                                    Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                    Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                    '--------------------
                                    '  Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                    Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                    Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                    Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                    rowtang += 1
                                End If
                            End If


                        End If






            Next 'het(freight)
                End If
            Next ' het bill
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim sql, strhbl As String
        Try
            ' lay hang xuat

            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where ref like '%" & Me.txtrefcredit.Text & "%' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                If ds.Tables(0).Rows(j).Item("hBL").ToString = "HCM/SY1112-001TH" Then
                    DisplayMessage(True, "")
                End If
                For i = 1 To 10
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeridcredit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer
                    Try
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    Catch ex As Exception
                        hcn = 0
                    End Try

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckcredit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            strhbl = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                            Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemscredit" + i.ToString).ToString

                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencycredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricecredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricecredit" + i.ToString).ToString


                            Me.dgdListCongno.Item("tigia", rowtang).Value = ds.Tables(0).Rows(j).Item("tigiacredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString


                            Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString




                            rowtang += 1
                        End If

                    End If






                Next
            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description & strhbl)
        End Try
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim sqlitem As String
            Dim dsitem As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from logistics where convert(datetime,sailingdate) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "' "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                ' moi bill ta lay freight

                sqlF = " select * from logisticsfreight where logisticsid='" & ds.Tables(0).Rows(j).Item("blob_id").ToString & "' and debitcredit='Credit'"
                dsF = ReadDataSet(sqlF)
                If dsF.Tables(0).Rows.Count > 0 Then


                    For i = 0 To dsF.Tables(0).Rows.Count - 1
                        'kiem tra debit
                        ' lay customerid debit
                        Dim sqlcus As String
                        Dim dsCus As New DataSet
                        sqlcus = " select * from customer where customer_id= '" & dsF.Tables(0).Rows(i).Item("customerid").ToString & "'"
                        dsCus = ReadDataSet(sqlcus)
                        ' lay han cong no khach hang 
                        Dim hcn As Integer
                        Try
                            hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                        Catch ex As Exception
                            hcn = 0
                        End Try
                        ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                        If dsF.Tables(0).Rows(i).Item("paycheck").ToString = "False" Then
                            If Me.chkallHCN.Checked = True Then
                                ' If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                Me.dgdListCongno.Rows.Add(1)
                                Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                '---
                                Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                '-----
                                sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                dsitem = ReadDataSet(sqlitem)
                                Try
                                    Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                Catch ex As Exception

                                End Try

                                Try
                                    Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                Catch ex As Exception

                                End Try
                                Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                '--------------------
                                '  Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                rowtang += 1
                                'End If
                            Else
                                If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                                    Me.dgdListCongno.Rows.Add(1)
                                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    '---
                                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                                    '-----
                                    sqlitem = "select * from charge where charge_id='" & dsF.Tables(0).Rows(i).Item("itemid").ToString & "' "
                                    dsitem = ReadDataSet(sqlitem)
                                    Try
                                        Me.dgdListCongno.Item("items", rowtang).Value = dsitem.Tables(0).Rows(0).Item("charge").ToString
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString

                                    Catch ex As Exception

                                    End Try
                                    Me.dgdListCongno.Item("cur", rowtang).Value = "VND" 'dsF.Tables(0).Rows(i).Item("currency").ToString
                                    Me.dgdListCongno.Item("quantity", rowtang).Value = dsF.Tables(0).Rows(i).Item("quantity").ToString
                                    '--------------------
                                    '  Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                                    Me.dgdListCongno.Item("thanhtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricenotaxvnd").ToString, 3)
                                    Me.dgdListCongno.Item("tienthue", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("pricethue").ToString, 3)

                                    Me.dgdListCongno.Item("tongtien", rowtang).Value = FormatNumber(dsF.Tables(0).Rows(i).Item("price").ToString, 3)



                                    Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString






                                    rowtang += 1
                                End If
                            End If


                        End If






            Next 'het(freight)
                End If
            Next ' het bill
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        '
        Dim sql, strhbl As String
        Try
            ' lay hang xuat

            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where convert(datetime,eta) between '" & Me.dtpFromcredit.Value.Date & "' and '" & Me.dtptocredit.Value.Date & "'  and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                'If ds.Tables(0).Rows(j).Item("hBL").ToString = "HCM/SY1112-001TH" Then
                '    DisplayMessage(True, "")
                'End If
                For i = 1 To 10
                    'kiem tra debit
                    ' lay customerid debit
                    Dim sqlcus As String
                    Dim dsCus As New DataSet
                    sqlcus = " select * from customer where customer_id= '" & ds.Tables(0).Rows(j).Item("customeridcredit" + i.ToString).ToString & "'"
                    dsCus = ReadDataSet(sqlcus)
                    ' lay han cong no khach hang 
                    Dim hcn As Integer
                    Try
                        hcn = dsCus.Tables(0).Rows(0).Item("hancongno").ToString
                    Catch ex As Exception
                        hcn = 0
                    End Try

                    ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                    If ds.Tables(0).Rows(j).Item("paycheckcredit" + i.ToString).ToString = "False" And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString <> "0" And ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString <> "") Then
                        If CDate(Getdate()) >= CDate(ds.Tables(0).Rows(j).Item("sailingdate").ToString).AddDays(hcn) Then
                            Me.dgdListCongno.Rows.Add(1)
                            Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                            Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBL").ToString
                            Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hBL").ToString
                            strhbl = ds.Tables(0).Rows(j).Item("hBL").ToString
                            Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                            Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString

                            Me.dgdListCongno.Item("items", rowtang).Value = ds.Tables(0).Rows(j).Item("itemscredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                            Me.dgdListCongno.Item("cur", rowtang).Value = ds.Tables(0).Rows(j).Item("currencycredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("quantity", rowtang).Value = ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("unitprice", rowtang).Value = ds.Tables(0).Rows(j).Item("unitpricecredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("pricenotax", rowtang).Value = ds.Tables(0).Rows(j).Item("pricetruocthuecredit" + i.ToString).ToString

                            Me.dgdListCongno.Item("price", rowtang).Value = ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("tax", rowtang).Value = ds.Tables(0).Rows(j).Item("taxpricecredit" + i.ToString).ToString


                            Me.dgdListCongno.Item("tigia", rowtang).Value = ds.Tables(0).Rows(j).Item("tigiacredit" + i.ToString).ToString
                            Me.dgdListCongno.Item("company", rowtang).Value = dsCus.Tables(0).Rows(0).Item("company").ToString




                            Me.dgdListCongno.Item("hancongno", rowtang).Value = hcn.ToString


                            rowtang += 1
                        End If

                    End If






                Next
            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description & strhbl)
        End Try
    End Sub

    Private Sub frmThongbaocongnoLog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id, value, strSQL As String
        Me.cbocustra.Items.Clear()
        Me.cbocus.Items.Clear()
        id = "customer_id"
        value = "company"
        strSQL = "Select customer_id,company From customer order by company "
        loadDataToObject(Me.cbocus, strSQL, id, value)
        loadDataToObject(Me.cbocustra, strSQL, id, value)
    End Sub
End Class