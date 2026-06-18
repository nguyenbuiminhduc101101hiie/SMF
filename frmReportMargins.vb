Public Class frmReportMargins

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.txttop.Text = ""
        Me.txtLeft.Text = ""
        Me.txtRight.Text = ""
        Me.txtBottom.Text = ""
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo err
        gTopM = CInt(Me.txttop.Text)
        gLeftM = CInt(Me.txtLeft.Text)
        gRightM = CInt(Me.txtRight.Text)
        gBottomM = CInt(Me.txtBottom.Text)
        Me.txttop.Text = gTopM
        Me.txtBottom.Text = gBottomM
        Me.txtRight.Text = gRightM
        Me.txtLeft.Text = gLeftM
        Me.Close()
        Exit Sub
err:
        DisplayMessage(True, "Please, check again!")
    End Sub

    Private Sub frmReportMargins_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.txttop.Text = gTopM
        Me.txtBottom.Text = gBottomM
        Me.txtRight.Text = gRightM
        Me.txtLeft.Text = gLeftM
    End Sub
End Class