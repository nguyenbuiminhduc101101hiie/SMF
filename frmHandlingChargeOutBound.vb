Public Class frmHandlingChargeOutbound

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = " Select Vessel + ' - ' + voyNo as Data,SailingSchedule.SailingScheduleID as ID "
            SQL &= " From (SailingSchedule LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID)"
            SQL &= " Where SailingSchedule.Continued=1 "
            SQL &= " And Convert(DateTime,SailingSchedule.ETD) +1 >'" & Me.dtpFromETA.Value.Date & "' And Convert(DateTime,SailingSchedule.ETD)-1 < '" & Me.dtpToETA.Value.Date & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.ValueMember = "ID"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryData()
        Try
            Dim SQL As String
            SQL = " Select BL_NO,Container_No,Cargo.Container_Type as Type ,SailingSchedule.ETD "
            SQL &= " From (((( BillOfLading Left Join Cargo On BillOfLading.BL_ID=Cargo.BL_ID)"
            SQL &= " Left Join Container On Container.CTN_ID=Cargo.CTN_ID)"
            SQL &= " Left Join ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
            SQL &= " LEFT Join SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
            SQL &= " Where BillOfLading.Continued=1 And Cargo.Continued=1 and SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"

            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Dim f As Double
            dt.Columns.Add("Fee", f.GetType())
            For i As Integer = 0 To dt.Rows.Count - 1
                dt.Rows(i).Item("Fee") = IIf(Me.txtFee.Text = "", 0, CDbl(Me.txtFee.Text))
            Next
            Me.dgdData.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdData)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.txtFee.Text.Trim = "" Then
            MsgBox("Fee Have to have a value")
            Return
        End If
        QueryData()
    End Sub


    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgdData, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmHandlingChargeOutbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub dtpFromETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETA.ValueChanged
        QueryVessel()
    End Sub

    Private Sub dtpToETA_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETA.ValueChanged
        QueryVessel()
    End Sub
End Class