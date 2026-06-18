Public Class frmSelectCustomer

    Private Sub cmdcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcode.Click
        Try

            Dim id, value, strSQL As String
            Me.cboCustomerShipper.Items.Clear()
            Me.cboCustomerShipper.Text = ""
            id = "Customer_id"
            value = "Company"
            strSQL = "Select Customer_id,  company From customer  where company like '%" & Me.txtcode.Text.Trim & "%' and continued=1 Order By company"
            loadDataToObject_(Me.cboCustomerShipper, strSQL, id, value)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdchonShipper_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdchonShipper.Click
        Try
            Clipboard.SetText(Me.TextBox1.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cboCustomerShipper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCustomerShipper.SelectedIndexChanged
        Try
            Try
                Dim sql As String
                Dim ds As New DataSet
                sql = "select * from customer where company='" & Me.cboCustomerShipper.Text & "'"
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    'If Me.cboSCN.Text = "Shipper" Then

                    Me.TextBox1.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    Me.TextBox1.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    '    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                    '        Me.txtShipper.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                    '        Me.txtShipper.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    '    End If
                    'ElseIf Me.cboSCN.Text = "Consignee" Then
                    '    Me.txtConsignee.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    '    Me.txtConsignee.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    '    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                    '        Me.txtConsignee.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                    '        Me.txtConsignee.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    '    End If
                    'ElseIf Me.cboSCN.Text = "Notify" Then
                    '    Me.txtNotify.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    '    Me.txtNotify.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    '    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                    '        Me.txtNotify.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                    '        Me.txtNotify.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    '    End If

                    'ElseIf Me.cboSCN.Text Like "*Agent*" Then
                    '    Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("company").ToString + vbCrLf
                    '    Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("Addresstiengviet").ToString + vbCrLf
                    '    If ds.Tables(0).Rows(0).Item("company").ToString <> "" Then
                    '        Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("tel").ToString + "  " '+ vbCrLf
                    '        Me.txtAgencyName.Text += ds.Tables(0).Rows(0).Item("fax").ToString + vbCrLf
                    '    End If

                    'End If
                Else
                    DisplayMessage(True, "Please check again.!")
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class