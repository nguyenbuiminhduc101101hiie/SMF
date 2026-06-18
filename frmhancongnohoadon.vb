Public Class frmhancongnohoadon

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            Dim i, k, currow As Integer
            Dim ts As Date = CDate(Getdate())
            sql = "select * from taxinvoice left join customer on taxinvoice.customer_id=customer.customer_id where huy=0 and dathanhtoan=0 "
            ds = ReadDataSet(sql)
            Me.DataGridView1.Rows.Clear()
            If ds.Tables(0).Rows.Count > 0 Then
                'For k = CInt(Me.ComboBox1.Text) * (-1) To CInt(Me.cbongay.Text)

                'ts = CDate(Getdate()).AddDays(k)
                For i = 0 To ds.Tables(0).Rows.Count - 1 'CDate(dt2.Rows(i).Item("arrivaldate").ToString.Trim)


                    'If ts.Date >= CDate(ds.Tables(0).Rows(i).Item("dateinvoice").ToString.Trim).Date Then
                    'ghi vao> luoi
                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2
                    Me.DataGridView1.Item("stt", currow).Value = (i + 1).ToString
                    Me.DataGridView1.Item("soquyen", currow).Value = ds.Tables(0).Rows(i).Item("serialno").ToString
                    Me.DataGridView1.Item("sohoadon", currow).Value = ds.Tables(0).Rows(i).Item("invoiceno").ToString
                    Me.DataGridView1.Item("khachhang", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString
                    Me.DataGridView1.Item("soref", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Try
                        Me.DataGridView1.Item("dathanhtoan", currow).Value = ds.Tables(0).Rows(i).Item("thucthu").ToString
                        Me.DataGridView1.Item("ngaythanhtoan", currow).Value = ds.Tables(0).Rows(i).Item("ngaythucthu").ToString

                    Catch ex As Exception

                    End Try





                    Try
                        Me.DataGridView1.Item("inbound", currow).Value = ds.Tables(0).Rows(i).Item("inbound").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("outbound", currow).Value = ds.Tables(0).Rows(i).Item("outbound").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("logistics", currow).Value = ds.Tables(0).Rows(i).Item("logistics").ToString

                    Catch ex As Exception

                    End Try

                    Me.DataGridView1.Item("ngayphathanh", currow).Value = ds.Tables(0).Rows(i).Item("dateinvoice").ToString.Replace("12:00:00 AM", "")
                    Me.DataGridView1.Item("ngaycongno", currow).Value = ds.Tables(0).Rows(i).Item("buss_place").ToString
                    Dim hieu As Integer = (CDate(Getdate()).Date - CDate(ds.Tables(0).Rows(i).Item("dateinvoice").ToString)).TotalDays
                    Try
                        Me.DataGridView1.Item("songayconlai", currow).Value = CInt(ds.Tables(0).Rows(i).Item("buss_place").ToString) - hieu
                    Catch ex As Exception
                        Me.DataGridView1.Item("songayconlai", currow).Value = 0 - hieu
                    End Try
                    ' lay tong tien
                    Dim sqltien As String
                    Dim dstien As New DataSet
                    ' sqltien = " select sum(pricebantruocthue+(pricebantruocthue*taxpriceban/100)) as priceban from taxdetail where taxinvoiceid='" & ds.Tables(0).Rows(i).Item("taxinvoiceid").ToString & "' "
                    ' dstien = ReadDataSet(sqltien)
                    ' If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.Item("thanhtien", currow).Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("tk511").ToString) + CDbl(ds.Tables(0).Rows(i).Item("tk311").ToString), 0)
                    'Me.DataGridView1.Item("thanhtien", currow).Value = dstien.Tables(0).Rows.Item("priceban").ToString

                    '  End If
                    ' End If

                Next


                'Next
                'For i = 0 To ds.Tables(0).Rows.Count - 1
                '    ' ung voi moi hoa don ta lay ngay hien tai - ngay phat hanh 
                '    If ts.Date = CDate(ds.Tables(0).Rows(i).Item("dateinvoice").ToString.Trim).Date.AddDays(CInt(Me.cbongay.Text)) Then

                '    End If
                'Next

            End If
            InsertAutoNumberToGrid(Me.DataGridView1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmhancongnohoadon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class