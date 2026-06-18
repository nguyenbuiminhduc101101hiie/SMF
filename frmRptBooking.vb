Public Class frmRptBooking
    Dim strQuery As String
    Dim oTable As New DataTable
    Public Function GetData(ByVal strSQL As String) As DataTable
        Dim dt As New DataTable
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmd As New SqlClient.SqlCommand()
        Dim Adapter As New SqlClient.SqlDataAdapter()
        Try
            cmd = New SqlClient.SqlCommand(strSQL, Conn)
            Adapter = New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return Nothing
        Finally
            Conn.Close()
            Conn = Nothing
            cmd.Dispose()
            cmd = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Function
    Private Sub cmdOkSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkSE.Click
        strQuery = "Select Container_type,Count(Container_type) As ""Quantity"",ETD"

        strQuery &= " from ((((ContainerOutboundNotify  INNER JOIN SailingSChedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
        strQuery &= " INNER JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID)"

        strQuery &= " INNER JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " INNER JOIN Cargo On Cargo.BL_ID=BillOfLading.BL_ID)"

        strQuery &= " where Vessel  like '%" & Me.cboVessel.Text.Trim & "%'  And VoyNo like '%" & Me.txtVoyNo.Text.Trim & "%' And ContainerOutboundNotify.Continued=1"
        strQuery &= " And Cargo.Continued=1 And PLACE_OF_DESTINATION_CODE Like '%" & Me.cboDestSE.Text.Trim & "%' and ContainerOutboundNotify.Editable=1"
        strQuery &= " Group BY Container_type,ETD"
        strQuery &= " Order by Container_type"
        Me.lblResult.Text = "Result Of ""DAILY BOOKING REPORT OF SOUTHEASTASIA"""
        Me.dgdData.DataSource = GetData(strQuery)
    End Sub
    Private Sub cmdOkMV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkMV.Click
        strQuery = "Select PORT_OF_DISCHARGE_CODE As POD ,PLACE_OF_DESTINATION_CODE as ""FINAL DEST"",Container_type,"
        strQuery &= " Count(Container_type) As ""Quantity"", Sum(Gross) As ""G.Weight"" "
        strQuery &= " from ((((ContainerOutboundNotify  INNER JOIN SailingSChedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
        strQuery &= " INNER JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID)"
        strQuery &= " INNER JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " INNER JOIN Cargo On Cargo.BL_ID=BillOfLading.BL_ID)"
        strQuery &= " where Vessel  like '%" & Me.cboVessel.Text.Trim & "%'  And VoyNo like '%" & Me.txtVoyNo.Text.Trim & "%' And ContainerOutboundNotify.Continued=1"
        strQuery &= " And Cargo.Continued=1 and ContainerOutboundNotify.Editable=1"
        strQuery &= " Group BY PORT_OF_DISCHARGE_CODE,PLACE_OF_DESTINATION_CODE,Container_type"
        strQuery &= " Order by Container_type"
        Me.lblResult.Text = "Result Of ""Daily Booking Of MV"""
        Me.dgdData.DataSource = GetData(strQuery)
    End Sub
    Private Sub cmdOkSHPH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkSHPH.Click
        strQuery = "Select Container_type,Count(Container_type) As ""Quantity"", Sum(Gross) As ""G.Weight"""

        strQuery &= " from ((((ContainerOutboundNotify  INNER JOIN SailingSChedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
        strQuery &= " INNER JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID)"

        strQuery &= " INNER JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " INNER JOIN Cargo On Cargo.BL_ID=BillOfLading.BL_ID)"

        strQuery &= " where SOC=" & IIf(Me.chkSOCSHPH.Checked, 1, 0) & " and Vessel  like '%" & Me.cboVessel.Text.Trim & "%'  And VoyNo like '%" & Me.txtVoyNo.Text.Trim & "%' And ContainerOutboundNotify.Continued=1"
        strQuery &= " And Cargo.Continued=1 and ContainerOutboundNotify.Editable=1"
        strQuery &= " Group BY Container_type"
        strQuery &= " Order by Container_type"
        Me.lblResult.Text = "Result Of ""SHANG HAI PUHAI Shipping"""
        Me.dgdData.DataSource = GetData(strQuery)
    End Sub
    Private Sub cmdPUHAIOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPUHAIOk.Click
        strQuery = "Select Container_type,Count(Container_type) As ""Quantity"", Sum(Gross) As ""G.Weight"""

        strQuery &= " from ((((ContainerOutboundNotify  INNER JOIN SailingSChedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
        strQuery &= " INNER JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID)"

        strQuery &= " INNER JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " INNER JOIN Cargo On Cargo.BL_ID=BillOfLading.BL_ID)"

        strQuery &= " where SOC=" & IIf(Me.chkSOCPH.Checked, 1, 0) & " and Vessel  like '%" & Me.cboVessel.Text.Trim & "%'  And VoyNo like '%" & Me.txtVoyNo.Text.Trim & "%' And ContainerOutboundNotify.Continued=1"
        strQuery &= " And Cargo.Continued=1 and ContainerOutboundNotify.Editable=1"
        strQuery &= " Group BY Container_type"
        strQuery &= " Order by Container_type"
        Me.lblResult.Text = "Result Of ""PUHAI Daily report"""
        Me.dgdData.DataSource = GetData(strQuery)

    End Sub

    Private Sub cmdOkUSWC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkUSWC.Click
        strQuery = "Select Container_type,Count(Container_type) As ""Quntity"",ETD,ContainerOutboundNotify.ServiceContract,Company"

        strQuery &= " from (((((ContainerOutboundNotify  INNER JOIN SailingSChedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
        strQuery &= " INNER JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID)"

        strQuery &= " INNER JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
        strQuery &= " INNER JOIN Cargo On Cargo.BL_ID=BillOfLading.BL_ID)"
        strQuery &= " INNER JOIN CUSTOMER On ContainerOutboundNotify.Customer_ID=CUSTOMER.Customer_ID)"

        strQuery &= " where Vessel  like '%" & Me.cboVessel.Text.Trim & "%'  And VoyNo like '%" & Me.txtVoyNo.Text.Trim & "%' And ContainerOutboundNotify.Continued=1"
        strQuery &= " And Cargo.Continued=1 And PLACE_OF_DESTINATION_CODE Like '%" & Me.cboDestUSWC.Text.Trim & "%' And Company Like '%" & Me.TextBox1.Text.Trim & "%' and ContainerOutboundNotify.Editable=1"
        strQuery &= " Group BY Container_type,ETD,ContainerOutboundNotify.ServiceContract,Company"
        strQuery &= " Order by Container_type"
        Me.lblResult.Text = "Result Of ""USWC"""
        Me.dgdData.DataSource = GetData(strQuery)
    End Sub

    Sub QueryVessel()
        Try
            Dim SQL As String = "Select Vessel from Vessel Order By Vessel  "


            Me.cboVessel.DisplayMember = "Vessel"
            Me.cboVessel.ValueMember = "Vessel"
            Me.cboVessel.DataSource = GetData(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmRptBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.cboDestSE.DisplayMember = "Port_Code"
        'Me.cboDestSE.ValueMember = "port"
        'Me.cboDestSE.DataSource = oTablePort

        'Me.cboDestSE.DisplayMember = "Port_Code"
        'Me.cboDestSE.ValueMember = "port"
        'Me.cboDestSE.DataSource = oTablePort
        SetDefaultGrid(Me.dgdData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.cboDestUSWC.DisplayMember = "Port_Code"
        Me.cboDestUSWC.ValueMember = "Port"
        Me.cboDestUSWC.DataSource = oTablePort

        Me.cboDestSE.DisplayMember = "Port_Code"
        Me.cboDestSE.ValueMember = "port"
        Me.cboDestSE.DataSource = oTablePort

        QueryVessel()
    End Sub


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub cmdexport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexport.Click
        Try
            If Me.dgdData.RowCount > 0 Then
                'SetMenu(False)
                ExportExecel(Me.dgdData, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class
