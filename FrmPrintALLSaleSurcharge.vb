Public Class FrmPrintALLSaleSurcharge
    Public mID As String
    Sub QueryVessel()
        Try
            Dim strSQL As String
            strSQL = " select Distinct Vessel +' - ' + VoyNo as CapTion ,ContainerOutboundNotify.SailingScheduleID as Data "
            strSQL &= " from ((ContainerOutboundNotify LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strSQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strSQL &= " Where ContainerOutboundNotify.Editable=1 And ContainerOutboundNotify.Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            Me.cboVesselVoyNo.DisplayMember = "Caption"
            Me.cboVesselVoyNo.ValueMember = "Data"
            Me.cboVesselVoyNo.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub FrmPrintALLSaleSurcharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            mID = Me.cboVesselVoyNo.SelectedValue.ToString
            Dim strSQL As String = "Select ContainerOutboundnotifyID From ContainerOutboundnotify Where SailingScheduleID='" & mID & "' And Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            frmReportSaleSurcharge.ALL = True
            For i As Integer = 0 To dt.Rows.Count - 1
                frmReportSaleSurcharge.PrintRpt(dt.Rows(i).Item(0).ToString.Trim)
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class