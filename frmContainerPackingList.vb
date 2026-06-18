Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmContainerPackingList
    Dim oTable As New DataTable
    Sub QueryInfo()
        Try
            Dim strQuery As String
            strQuery = "select BookingNo,Company,Vessel,VoyNo,Destination,Container_No,Seal"
            strQuery &= "  From (((((ContainerOutboundnotify LEFT JOIN SailingSchedule On ContainerOutboundnotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN LOADINGPLANFORVESSEL On ContainerOutboundNotify.ContainerOutboundNotifyID=LOADINGPLANFORVESSEL.ContainerOutboundNotifyID )"
            strQuery &= " LEFT JOIN Container On Container.CTN_ID=LOADINGPLANFORVESSEL.CTN_ID )"
            strQuery &= "  LEFT JOIN Customer On Customer.Customer_ID=ContainerOutboundnotify.Customer_ID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_id=Vessel.Vessel_ID)"
            strQuery &= " WHERE BookingNo='" & gBookingNo & "' And ContainerOutboundNotify.Continued=1  And LOADINGPLANFORVESSEL.Continued=1"
            If oTable.Rows.Count > 0 Then
                oTable.Rows.Clear()

            End If
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Adapter.Fill(oTable)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub frmContainerPackingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim rpt As New 
            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            strReportName = "ReportContainerPackingList"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------
            QueryInfo()
            rpt.SetDataSource(oTable)
            Me.CrystalReportViewer1.ReportSource = rpt
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class