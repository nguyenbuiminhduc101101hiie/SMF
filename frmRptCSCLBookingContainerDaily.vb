Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Public Class frmRptCSCLBookingContainerDaily
    '    Dim oTableContainer As New DataTable
    '    Dim rpt As New ReportCSCLContainerDailyReport
    '    Sub QueryContainer()
    '        On Error GoTo Err
    '        Dim StrSQL As String
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Conn.Open()
    '        StrSQL = "Select Vessel.Vessel,SailingSchedule.VoyNo,SailingSchedule.ETD,BillOfLading.PORT_OF_LOADING_CODE as POL,SlotExchange,"
    '        StrSQL &= " SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong45HC,SoLuong20RF,SoLuong40RF,SoLuong40RH,"
    '        StrSQL &= " TEU=SoLuong20GP+SoLuong40GP*2+SoLuong40HC*2+ SoLuong45HC*2+SoLuong20RF+SoLuong40RF*2+SoLuong40RH*2, BillOfLading.PORT_OF_DISCHARGE_CODE as POD, "
    '        StrSQL &= " total20weight=SoLuong20GP*15+SoLuong20RF*21,total40weight=SoLuong40GP*17+SoLuong40HC*18+SoLuong40RH*23,ToTalWeight=SoLuong20GP*15+SoLuong20RF*21+SoLuong40GP*17+SoLuong40HC*18+SoLuong40RH*23  "
    '        StrSQL &= " From (((ContainerOutboundNotify LEFT JOIN BillOfLading On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID) "
    '        StrSQL &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingscheduleID) "
    '        StrSQL &= " LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID) "
    '        StrSQL &= " Where ContainerOutboundNotify.SailingScheduleID='" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "' And ContainerOutboundNotify.Continued=1 "
    '        Dim cmdSelect As New SqlClient.SqlCommand(StrSQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '        If Not IsNothing(oTableContainer) Then
    '            oTableContainer.Clear()
    '        End If
    '        Adapter.Fill(oTableContainer)
    '        Exit Sub

    'Err:
    '    End Sub
    '    Sub QueryVesselVoyNo()
    '        On Error GoTo Err
    '        Dim id As String = "SailingScheduleID"
    '        Dim Value As String = "Data"
    '        Dim strSQL As String = "Select SailingScheduleID,Vessel.Vessel + ' - ' + VoyNo as Data from SailingSchedule,Vessel Where SailingSchedule.Vessel_ID=Vessel.Vessel_ID And SailingSchedule.Continued=1"
    '        loadDataToObject(Me.cboVessel, strSQL, id, Value)
    '        Exit Sub
    'Err:
    '    End Sub

    '    Private Sub frmRptCSCLBookingContainerDaily_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '        On Error GoTo Err
    '        QueryVesselVoyNo()
    '        QueryContainer()

    '        rpt.SetDataSource(oTableContainer)
    '        Dim dat As TextObject
    '        dat = rpt.ReportDefinition.ReportObjects("Date")
    '        dat.Text = Now.Date

    '        Me.CrystalReportViewer1.ReportSource = rpt
    '        Me.CrystalReportViewer1.Refresh()
    '        Me.CrystalReportViewer1.Show()
    '        Exit Sub
    'Err:
    '        MsgBox(Err.Description)
    '    End Sub

    '    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
    '        Try

    '            QueryContainer()
    '            rpt.SetDataSource(oTableContainer)
    '            Me.CrystalReportViewer1.ReportSource = rpt
    '            Me.CrystalReportViewer1.Refresh()
    '            Me.CrystalReportViewer1.Show()
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try

    '    End Sub
End Class