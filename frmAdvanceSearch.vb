Imports System.IO
Public Class frmAdvanceSearch

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try

            Dim StrQuery As String
            StrQuery = Me.txtCommand.Text
            If Me.txtCommand.Text = "" Then
                Return
            End If
            'If StrQuery.ToUpper.IndexOf("DELETE") > -1 Or StrQuery.ToUpper.IndexOf("CREATE") > -1 Then
            '    MsgBox("Permission deny !", MsgBoxStyle.Critical)
            '    Exit Sub
            'End If
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(StrQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim dt As New DataTable
            dt.Reset()
            Adapter.Fill(dt)
            Me.dgdData.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdData)
            'tssCol.Text = Me.dgdData.ColumnCount & " cols"
            tssRow.Text = Me.dgdData.RowCount & " rows"
            tssComplete.Text = "Complete"

            'For i As Integer = 0 To dt.Columns.Count - 1
            '    If dt.Columns(i).ColumnName.ToUpper Like "*ID" Or dt.Columns(i).ColumnName.ToUpper Like "*EDITABLE*" Or dt.Columns(i).ColumnName.ToUpper Like "*APPROVED*" Or dt.Columns(i).ColumnName.ToUpper Like "*CONTINUED*" Then
            '        Me.dgdData.Columns(i).Visible = False
            '    End If
            'Next
        Catch ex As Exception
            DisplayMessage(False, "this Query is invalid, please try again!" & vbCrLf & ex.Message)
            'tssCol.Text = "0 cols"
            tssRow.Text = "0 rows"
            tssComplete.Text = "Error"
        End Try
    End Sub
    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        'Me.Top = frmMain.MenuStrip1.Height + frmMain.ToolStrip1.Height + 18
        'Me.Left = 0
        'Me.Height = frmMain.Height - 10 - Me.Top
        'Me.Width = frmMain.Width - 8
        'Me.txtCommand.Width = Me.Width - 50
        'Me.dgdData.Width = Me.txtCommand.Width
        'Me.dgdData.Height = Me.Height - Me.txtCommand.Height - 150
        Me.tssComplete.Width = Me.StatusStrip.Width - Me.tssCol.Width - tssRow.Width
        'Me.cmdFind.Left = Me.txtBillOfLading.Right + 10
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Sub frmAdvanceSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ReFormat()
    End Sub

    Private Sub frmAdvanceSearch_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        ReFormat()
    End Sub

    Private Sub frmAdvanceSearch_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ReFormat()
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.txtCommand.Text = "Select"
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub


    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

    Private Sub cmdExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExcel.Click
        Try
            If Me.dgdData.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdData, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Me.txtCommand.Text = "Select"
    End Sub

    Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
        Try
            Me.OpenFileDialog1.InitialDirectory = "C:\"
            Me.OpenFileDialog1.Filter = "Text files (*.txt)|*.txt"

            If Me.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sr As StreamReader = New StreamReader(Me.OpenFileDialog1.FileName)
                Me.txtCommand.Text = sr.ReadToEnd
                sr.Close()
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Try
            Me.SaveFileDialog1.InitialDirectory = "C:\"
            Me.SaveFileDialog1.Filter = "Text files (*.txt)|*.txt"

            If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Dim sw As StreamWriter = New StreamWriter(Me.SaveFileDialog1.FileName)
                sw.Write(Me.txtCommand.Text.Trim)
                sw.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RunToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RunToolStripMenuItem.Click
        Me.cmdOk.PerformClick()
    End Sub

    Private Sub txtCommand_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCommand.KeyUp
        LineText()
    End Sub

    Private Sub txtCommand_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCommand.MouseUp
        LineText()
    End Sub
    Sub LineText()
        Try
            If Me.txtCommand.TextLength = 0 Then
                Return
            End If
            Dim index As Integer = Me.txtCommand.SelectionStart
            Dim tmp1 As Integer = 0
            Dim tmp2 As Integer = 0
            If index < Me.txtCommand.Lines(0).Length + 2 Then
                tssCol.Text = "Ln " & 1 & ", Col " & index
            End If
            For i As Integer = 1 To Me.txtCommand.Lines.Length - 1
                tmp1 += Me.txtCommand.Lines(i - 1).Length + 2
                tmp2 = tmp1 + Me.txtCommand.Lines(i).Length + 2
                If tmp1 <= index And index <= tmp2 Then
                    tssCol.Text = "Ln " & i + 1 & ", Col " & index - tmp1
                    Exit For
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class