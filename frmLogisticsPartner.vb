Public Class frmLogisticsPartner

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim sql As String
            Dim ds As New DataSet
            If UCase(Me.ComboBox1.Text) = "ENGLISH NAME" Then
                sql = "select company,englishname,taxcode,address,tel,industry,remarks_sale from customer where company like '%" & Me.TextBox1.Text & "%'  and maincode like '%Logistics Partner%' "
            End If

            If UCase(Me.ComboBox1.Text) = "ADDRESS" Then
                sql = "select company,englishname,taxcode,address,tel,industry,remarks_sale from customer where address like '%" & Me.TextBox1.Text & "%'  and maincode like '%Logistics Partner%' "
            End If

            If UCase(Me.ComboBox1.Text) = "TELEPHONE" Then
                sql = "select company,englishname,taxcode,address,tel,industry,remarks_sale from customer where tel like '%" & Me.TextBox1.Text & "%'  and maincode like '%Logistics Partner%' "
            End If
            If UCase(Me.ComboBox1.Text) = "ALL" Then
                sql = "select company,englishname,taxcode,address,tel,industry,remarks_sale from customer where  maincode like '%Logistics Partner%' "
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
End Class