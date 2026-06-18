Public Class frmDischargesList
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            DisplayMessage(True, "Đăng ký mẫu với bộ phận kỹ thuật.!")


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmLoadinglist_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim id, value, strsql As String
        Me.cbotenTau.Items.Clear()
        id = "vessel"
        value = "vessel"
        strsql = "Select distinct vessel From outbound where Continued=1 Order By vessel "
        loadDataToObject(Me.cbotenTau, strsql, id, value)


        Me.cboVoy.Items.Clear()
        id = "voyage"
        value = "voyage"
        strsql = "Select distinct voyage From outbound where Continued=1 Order By voyage "
        loadDataToObject(Me.cboVoy, strsql, id, value)

    End Sub
End Class