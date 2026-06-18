Public Class frmUpdateInBoundCY

    Sub QueryVessel(Optional ByVal arg As String = "")
        Try
            Dim sql As String
            sql = " Select Distinct VoyNo_inbound as VoyNo,Vessel_Inbound +'-' + VoyNo_Inbound  as Value"
            sql &= " From ContainerManagerment "
            sql &= " Where Continued=1 " & arg
            sql &= " Order By Value"
            Dim dt As New DataTable
            dt = ReadTable(sql)
            Me.cboVessel.DisplayMember = "Value"
            Me.cboVessel.ValueMember = "VoyNo"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try
            Dim SQL As String
            SQL = "Select Arrival_Date as ETA "
            SQL &= " From ContainerManagerMent "
            SQL &= " Where Continued=1 And VoyNo_Inbound='" & Me.cboVessel.SelectedValue.ToString.Trim & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                MsgBox("ETA is invalid check Again")
                Return
            End If
            Me.dtpLeavingDate.Text = dt.Rows(0).Item("ETA").ToString

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim SQL As String
            Sql = "select VoyNo_Inbound "
            Sql &= " From ContainerManagerment "
            Sql &= " Where Continued=1 And Convert(DateTime,Arrival_Date)='" & Me.dtpLeavingDate.Value.Date & "'"
            Dim dt As New DataTable
            dt = ReadTable(Sql)
            If dt.Rows.Count = 0 Then
                Return
            End If
            Me.cboVessel.SelectedValue = dt.Rows(0).Item("VoyNo_Inbound").ToString.Trim
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmUpdateInBoundCY_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        QueryICD(Me.cboTerminal)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim Conn As SqlClient.SqlConnection
        Dim cmd As SqlClient.SqlCommand
        Try
            Dim TempVessel() As String
            TempVessel = Me.cboVessel.Text.Split("-")
            If TempVessel.Length < 2 Then
                MsgBox("Vessel Invalid")
                Return
            End If
            Dim SQL As String
            SQL = " Update ContainerManagerment "
            If Me.chkImportCY.Checked = True Then
                SQL &= " Set ImportCY='" & Me.cboTerminal.Text.Trim & "'"
            End If
            If Me.chkICDPort.Checked = True Then
                SQL &= ", ICDPort='" & Me.cboTerminal.Text.Trim & "'"
            End If
            If Me.chkFinalICD.Checked = True Then
                SQL &= ", FinalICD='" & Me.cboTerminal.Text.Trim & "'"
            End If
            SQL &= " Where Continued=1 And Vessel_Inbound='" & TempVessel(0).Trim & "' And VoyNo_Inbound='" & TempVessel(1).Trim & "' And Convert(DateTime,Arrival_Date)='" & Me.dtpLeavingDate.Value.Date & "'"
            Conn = New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            cmd = New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            Dim i As Integer = cmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox(i & " Record(S) Updated")
            Else
                MsgBox(" 0 Record Updated")
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            cmd.Dispose()
            cmd = Nothing
            Conn.Close()
            Conn.Dispose()

        End Try
    End Sub

   
  
End Class