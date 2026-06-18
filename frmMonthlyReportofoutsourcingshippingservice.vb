Public Class frmMonthlyReportofoutsourcingshippingservice

    Private Sub frmMonthlyReportofoutsourcingshippingservice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim id, value, strsQl As String

            Me.cboSalename.Items.Clear()
            id = "sale_id"
            value = "salename"
            strSQL = "Select sale_id,salename From sale order by salename "
            loadDataToObject(Me.cboSalename, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim i As Integer
            Dim sql As String
            Dim ds As New DataSet
            If Me.chkXSITC.Checked = True Then
                sql = "select * from quotation left join customer on quotation.customer_id=customer.customer_id where (quotation.salename='" & Me.cboSalename.Text & "') and (convert(datetime,dateupdate) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "')  and shippingline<>'SITC' order by quotationno "

            Else
                sql = "select * from quotation left join customer on quotation.customer_id=customer.customer_id where (quotation.salename='" & Me.cboSalename.Text & "') and (convert(datetime,dateupdate) between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpto.Value.Date & "')  and shippingline ='SITC' order by quotationno "

            End If
            ds = ReadDataSet(sql)
            Dim currow As Integer
            If ds.Tables(0).Rows.Count > 0 Then
                Me.DataGridView1.Rows.Clear()
                For i = 0 To ds.Tables(0).Rows.Count - 1

                    Me.DataGridView1.Rows.Add(1)
                    currow = Me.DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib


                    Me.DataGridView1.Item("customer", currow).Value = ds.Tables(0).Rows(i).Item("company").ToString

                    Me.DataGridView1.Item("ref", currow).Value = ds.Tables(0).Rows(i).Item("quotationno").ToString

                    Try
                        ' co so ref ta lay toan bo volumn
                        Me.DataGridView1.Item("volume", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                    Catch ex As Exception

                    End Try
                    Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                    Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString


                    Me.DataGridView1.Item("carrier", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString
                    Me.DataGridView1.Item("reason", currow).Value = ds.Tables(0).Rows(i).Item("subject").ToString




                Next


            End If
            Me.Text = "Monthly Report of outsourcing shipping service-" + Me.cboSalename.Text
            InsertAutoNumberToGrid(Me.DataGridView1)
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
            If Me.DataGridView1.RowCount > 0 Then

                ExportExecel(Me.DataGridView1, Me)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class