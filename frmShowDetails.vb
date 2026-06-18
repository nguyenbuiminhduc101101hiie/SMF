Public Class frmShowDetails

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' ExportExecel(Me.DataGridView1, Me)
            If Me.SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
                Me.GridControl1.ExportToXlsx(Me.SaveFileDialog1.FileName)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmShowDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Dim sql As String
            ' GridControl1.OptionsView.ColumnAutoWidth = False
            Dim ds As New DataSet
            If gSQLShowDetails <> "" Then
                ds = ReadDataSet(gSQLShowDetails)
            End If

            If ds.Tables(0).Rows.Count > 0 Then
                Me.GridControl1.DataSource = ds.Tables(0)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Me.GridControl1.ShowPrintPreview()
        Catch ex As Exception

        End Try
    End Sub
End Class