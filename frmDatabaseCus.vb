Public Class frmDatabaseCus

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If UCase(Me.ComboBox1.Text) = "ENGLISH NAME" Then
                sql = "select company,address,tel,salename from customer where company like '%" & Me.TextBox1.Text & "%'  "
            End If

            If UCase(Me.ComboBox1.Text) = "ADDRESS" Then
                sql = "select company,address,tel,salename from customer where address like '%" & Me.TextBox1.Text & "%'  "
            End If

            If UCase(Me.ComboBox1.Text) = "TELEPHONE" Then
                sql = "select company,address,tel,salename from customer where tel like '%" & Me.TextBox1.Text & "%'  "
            End If
            If UCase(Me.ComboBox1.Text) = "SALENAME" Then
                sql = "select company,address,tel,salename from customer where SALENAME like '%" & Me.TextBox1.Text & "%'  "
            End If
            ds = ReadDataSet(sql)
            Me.DataGridView1.DataSource = ds.Tables(0)
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Try
                Dim url As String = "https://youtu.be/BIpx-KUJ-9U"

                Process.Start(url)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
End Class