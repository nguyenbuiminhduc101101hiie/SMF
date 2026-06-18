Public Class frmGetBookingNoContainerManagerment


    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL = strSQL & " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 Order By Vessel_Code desc"
        'loadDataToObject(Me.cboVessel, strSQL, id, value)
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboVessel.DisplayMember = value
        Me.cboVessel.ValueMember = id
        Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim strSQL As String
            strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            strSQL &= " From SailingSchedule,vessel "
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD='" & Me.dtpLeavingDate.Value.Date & "'"
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            Else
                MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        On Error GoTo Err_named
        Dim Ves_ID As String
        If Me.cboVessel.Text = "" Then
            Return
        End If
        Ves_ID = Me.cboVessel.SelectedValue.ToString
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        If Ves_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select ETD "
            strQuery &= "from SailingSchedule "
            strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString
            End If
            '  query stranship
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmGetBookingNoContainerManagerment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub
    Function GetLoadingPlan()
        Try
            Dim SQl As String
            SQl = "select Container_No,BookingNo "
            SQl &= "From ((LoadingPlanForVessel LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=LoadingPlanForVessel.ContainerOutboundNotifyID)"
            SQl &= " LEFT JOIN Container On LoadingPlanForVessel.CTN_ID=Container.CTN_ID)"
            SQl &= " Where ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And LoadingPlanForVessel.Continued=1 "
            Return ReadTable(SQl)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub UpdateSQL(ByVal SQL As String)
        Dim Conn As SqlClient.SqlConnection
        Dim cmd As SqlClient.SqlCommand

        Try
            Conn = New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            cmd = New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Conn.Close()
            Conn.Dispose()
            cmd.Dispose()
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim oTableLoadingPlan As DataTable
            oTableLoadingPlan = GetLoadingPlan()
            For i As Integer = 0 To oTableLoadingPlan.Rows.Count - 1
                Dim SQL As String
                SQL = "Update ContainermanagerMent Set BookingNo='" & oTableLoadingPlan.Rows(i).Item("BookingNo").ToString & "'"
                SQL &= " Where Continued=1 And (DateOfOnboard='' Or DateOfOnboard Is NULL) And Container_NO='" & oTableLoadingPlan.Rows(i).Item("Container_No") & "'"
                UpdateSQL(SQL)
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class