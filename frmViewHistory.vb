Public Class frmViewHistory

    Private Sub frmViewHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If gViewHistory <> "" Then
                Dim sql As String
                Dim ds As New DataSet
                sql = "select userid,updatetime,chuoi from history where chuoi like '%" & gViewHistory & "%' "
                ds = ReadDataSet(sql)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.DataSource = ds.Tables(0)
                End If
            End If
            InsertAutoNumberToGrid(Me.DataGridView1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If Me.DataGridView1.RowCount = 0 Then
                Return
            End If
            'SetMenu(False)
            ExportExecel(Me.DataGridView1, Me)
            'SetMenu(True)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class