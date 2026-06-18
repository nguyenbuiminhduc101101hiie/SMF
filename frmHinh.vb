Public Class frmHinh

    Private Sub frmHinh_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            Me.PictureBox1.ImageLocation = gHinh
            Me.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            Me.PictureBox1.Show()
            Me.PictureBox1.Load()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim newMargins As System.Drawing.Printing.Margins
            newMargins = New System.Drawing.Printing.Margins(0.2, 0.2, 0.2, 0.2)
            PrintDocument1.DefaultPageSettings.Margins = newMargins
            e.Graphics.DrawImage(Me.PictureBox1.Image, 0, 0)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            PrintDialog1 = New PrintDialog

            PrintDialog1.Document = PrintDocument1 'pbxLogo.Image

            Dim r As DialogResult = PrintDialog1.ShowDialog

            If r = DialogResult.OK Then

                PrintDocument1.Print()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class