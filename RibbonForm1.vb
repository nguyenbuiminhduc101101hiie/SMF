Public Class RibbonForm1 

   
   
    Private Sub RibbonForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BarButtonItem2_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem2.ItemClick
        Try
            Dim form As New frmThongbao
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BarButtonItem3_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem3.ItemClick
        Try
            Dim form As New frmBangketamung_nhanvien
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class