Public Class frmNoDebitCredit

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Dim nodebitcredit As Boolean = False
            Dim tongdebit, tongcredit As Double

            Me.dgdListCongno.Rows.Clear()
            sql = "select * from outbound where continued=1 " 'where ref like '%" & Me.txtref.Text & "%' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                tongdebit = 0
                tongcredit = 0
                For i = 1 To 20
                    'kiem tra debit
                    ' lay customerid debit

                    'If (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "0") And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "0") Then
                    '    nodebitcredit = True

                    'Else
                    '    nodebitcredit = False
                    '    Exit For
                    'End If
                    Try
                        tongdebit += ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try

                Next


                ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                If tongdebit = 0 And tongcredit = 0 Then
                    Me.dgdListCongno.Rows.Add(1)
                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                    '---
                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                    '-----

                    Me.dgdListCongno.Item("sale", rowtang).Value = ds.Tables(0).Rows(j).Item("salecode").ToString





                    rowtang += 1
                Else

                End If









            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try

            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Dim nodebitcredit As Boolean = False
            Dim tongdebit, tongcredit As Double

            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where continued=1 " 'where ref like '%" & Me.txtref.Text & "%' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                tongdebit = 0
                tongcredit = 0
                For i = 1 To 20
                    'kiem tra debit
                    ' lay customerid debit

                    'If (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "0") And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "0") Then
                    '    nodebitcredit = True

                    'Else
                    '    nodebitcredit = False
                    '    Exit For
                    'End If
                    Try
                        tongdebit += ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try

                Next


                ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                If tongdebit = 0 And tongcredit = 0 Then
                    Me.dgdListCongno.Rows.Add(1)
                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("mbl").ToString
                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hbl").ToString
                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                    '---
                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                    '-----

                    Me.dgdListCongno.Item("sale", rowtang).Value = ds.Tables(0).Rows(j).Item("salecode").ToString





                    rowtang += 1
                Else

                End If









            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Dim nodebitcredit As Boolean = False
            Dim tongdebit, tongcredit As Double

            Me.dgdListCongno.Rows.Clear()
            sql = "select * from outbound where ref like '%" & Me.txtref.Text & "%' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                tongdebit = 0
                tongcredit = 0
                For i = 1 To 20
                    'kiem tra debit
                    ' lay customerid debit

                    'If (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "0") And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "0") Then
                    '    nodebitcredit = True

                    'Else
                    '    nodebitcredit = False
                    '    Exit For
                    'End If
                    Try
                        tongdebit += ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try

                Next


                ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                If tongdebit = 0 And tongcredit = 0 Then
                    Me.dgdListCongno.Rows.Add(1)
                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                    '---
                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                    '-----

                    Me.dgdListCongno.Item("sale", rowtang).Value = ds.Tables(0).Rows(j).Item("salecode").ToString





                    rowtang += 1
                Else

                End If









            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Dim nodebitcredit As Boolean = False
            Dim tongdebit, tongcredit As Double

            Me.dgdListCongno.Rows.Clear()
            sql = "select * from outbound where convert(datetime,sailingdate) between '" & Me.dtpFrom.Value.Date() & "' and '" & Me.dtpto.Value.Date() & "' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                tongdebit = 0
                tongcredit = 0
                For i = 1 To 20
                    'kiem tra debit
                    ' lay customerid debit

                    'If (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "0") And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "0") Then
                    '    nodebitcredit = True

                    'Else
                    '    nodebitcredit = False
                    '    Exit For
                    'End If
                    Try
                        tongdebit += ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try

                Next


                ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                If tongdebit = 0 And tongcredit = 0 Then
                    Me.dgdListCongno.Rows.Add(1)
                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLCarrier").ToString
                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("MBLMAWB").ToString
                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                    '---
                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                    '-----

                    Me.dgdListCongno.Item("sale", rowtang).Value = ds.Tables(0).Rows(j).Item("salecode").ToString





                    rowtang += 1
                Else

                End If









            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try

            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Dim nodebitcredit As Boolean = False
            Dim tongdebit, tongcredit As Double

            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where ref like '%" & Me.txtref.Text & "%' and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                tongdebit = 0
                tongcredit = 0
                For i = 1 To 20
                    'kiem tra debit
                    ' lay customerid debit

                    'If (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "0") And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "0") Then
                    '    nodebitcredit = True

                    'Else
                    '    nodebitcredit = False
                    '    Exit For
                    'End If
                    Try
                        tongdebit += ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try

                Next


                ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                If tongdebit = 0 And tongcredit = 0 Then
                    Me.dgdListCongno.Rows.Add(1)
                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("mbl").ToString
                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hbl").ToString
                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                    '---
                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                    '-----

                    Me.dgdListCongno.Item("sale", rowtang).Value = ds.Tables(0).Rows(j).Item("salecode").ToString





                    rowtang += 1
                Else

                End If









            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            ' lay hang xuat
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer
            Dim rowtang As Integer = 0
            Dim nodebitcredit As Boolean = False
            Dim tongdebit, tongcredit As Double

            Me.dgdListCongno.Rows.Clear()
            sql = "select * from inbound where convert(datetime,eta)  between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "'  and continued=1 "
            ds = ReadDataSet(sql)
            For j = 0 To ds.Tables(0).Rows.Count - 1

                tongdebit = 0
                tongcredit = 0
                For i = 1 To 20
                    'kiem tra debit
                    ' lay customerid debit

                    'If (ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitydebit" + i.ToString).ToString = "0") And (ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "" Or ds.Tables(0).Rows(j).Item("quantitycredit" + i.ToString).ToString = "0") Then
                    '    nodebitcredit = True

                    'Else
                    '    nodebitcredit = False
                    '    Exit For
                    'End If
                    Try
                        tongdebit += ds.Tables(0).Rows(j).Item("pricedebit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try
                    Try
                        tongcredit += ds.Tables(0).Rows(j).Item("pricecredit" + i.ToString).ToString
                    Catch ex As Exception

                    End Try

                Next


                ' lay phi khach hang nay kiem tra co pay hay chua, neu chua pay thi so sanh ngay sailingdate de thong bao
                If tongdebit = 0 And tongcredit = 0 Then
                    Me.dgdListCongno.Rows.Add(1)
                    Me.dgdListCongno.Item("refno", rowtang).Value = ds.Tables(0).Rows(j).Item("ref").ToString
                    Me.dgdListCongno.Item("mbl", rowtang).Value = ds.Tables(0).Rows(j).Item("mbl").ToString
                    Me.dgdListCongno.Item("hbl", rowtang).Value = ds.Tables(0).Rows(j).Item("hbl").ToString
                    Me.dgdListCongno.Item("etd", rowtang).Value = ds.Tables(0).Rows(j).Item("sailingdate").ToString
                    Me.dgdListCongno.Item("eta", rowtang).Value = ds.Tables(0).Rows(j).Item("eta").ToString
                    '---
                    Me.dgdListCongno.Item("routing", rowtang).Value = ds.Tables(0).Rows(j).Item("pol").ToString + "-" + ds.Tables(0).Rows(j).Item("pod").ToString
                    '-----

                    Me.dgdListCongno.Item("sale", rowtang).Value = ds.Tables(0).Rows(j).Item("salecode").ToString





                    rowtang += 1
                Else

                End If









            Next
            InsertAutoNumberToGrid(Me.dgdListCongno)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.dgdListCongno, Me)
        Catch ex As Exception

        End Try
    End Sub
End Class