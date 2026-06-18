Public Class frmVideo

    Private Sub frmVideo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strReportName As String = "gioithieuSMF.AVI"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        'openPlayer(strReportPath)
    End Sub
End Class