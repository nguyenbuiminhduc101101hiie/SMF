Public Class frmMonitorUser

    Sub LoadUserLogin()
        Try
            Dim tbl As New DataTable
            Dim str As String = "Select Name,LoginTime,HostIP From UserOnline us inner join userlist on us.usr=userlist.usr " & _
                                "Where day(getdate())=day(LoginTime) and month(getdate())=month(LoginTime) and day(getdate())=day(LoginTime) and LogoutTime is Null " & _
                                "and logintime=(Select max(logintime) From UserOnline us1 where us1.usr=us.usr )"
            tbl = ReadTable(str)
            Me.lvwUserLogin.Items.Clear()
            If tbl.Rows.Count > 0 Then
                For i As Integer = 0 To tbl.Rows.Count - 1
                    Me.lvwUserLogin.Items.Add(tbl.Rows(i).Item("name").ToString & Chr(13) & tbl.Rows(i).Item("LoginTime").ToString & Chr(13) & tbl.Rows(i).Item("HostIP").ToString, 0)
                Next
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
        
    End Sub
    Private Sub frmMonitorUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadUserLogin()
        Dim Ngay As Date = CDate(Getdate())
        Me.Text = "Users Online - " & Ngay.ToString
    End Sub
End Class