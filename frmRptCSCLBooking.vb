Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRptCSCLBooking
    Dim mSailingScheduleID As String = DefaultValue
    Dim dt As New DataTable
    Sub QueryContainerLine()
        Try
            Dim strQuery As String
            strQuery = "select SailingSchedule.ETD,SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong20RF,SoLuong40RF,SoLuong45HC,SoLuong40RH,Market.Market as destination,SELL_Way,"
            strQuery &= "Teus = SoLuong20GP + SoLuong40GP * 2 + SoLuong40HC * 2 + SoLuong20RF + SoLuong40RF * 2 + SoLuong45HC * 2 + SoLuong40RH * 2"
            strQuery &= ",weight=SoLuong20GP*15+SoLuong40GP*17+SoLuong40HC*18+SoLuong20RF*21+SoLuong40RH*23"
            strQuery &= " from ((containerOutboundNotify LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " INNER JOIN Market On Market.Market_ID=ContainerOutboundNotify.Market_ID)"
            strQuery &= " Where ContainerOutboundNotify.SailingScheduleID='" & mSailingScheduleID & "' And ContainerOutboundNotify.continued=1"
            Dim conn As New SqlClient.SqlConnection(strconnDG)
            conn.Open()
            Dim cmdselect As New SqlClient.SqlCommand(strQuery, conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdselect)
            If Not IsNothing(dt) Then
                dt.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception

        End Try
    End Sub

    Sub QueryVessel()
        Try
            Dim id As String = "SailingScheduleID"
            Dim value As String = "Data"
            Dim strQuery As String
            strQuery = "Select SailingScheduleID,Vessel.Vessel + ' - ' + SailingSchedule.VoyNo as Data "
            strQuery &= " From SailingSchedule LEFT JOIN Vessel On Sailingschedule.Vessel_ID = Vessel.Vessel_ID "
            strQuery &= " Where SailingSchedule.continued=1"
            loadDataToObject(Me.cboVessel, strQuery, id, value)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Me.fraInfo.Visible = False
            Me.CrystalReportViewer1.Visible = True
            QueryContainerLine()
            'Dim rpt As New 
            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            strReportName = "ReportContainerBooking"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------
            rpt.SetDataSource(dt)
            Dim POl, POD, Vessel, Voy, Line, TML, TS, VEL, ETA, ETD As TextObject
            If dt.Rows.Count > 0 Then
                ETD = rpt.ReportDefinition.ReportObjects("ETD")
                ETD.Text = dt.Rows(0).Item("ETD").ToString
            End If

            POl = rpt.ReportDefinition.ReportObjects("POL")
            POl.Text = Me.txtPOL.Text

            POD = rpt.ReportDefinition.ReportObjects("POD")
            POD.Text = Me.txtPOD.Text

            Dim tempVes() As String
            tempVes = Strings.Split(Me.cboVessel.Text, " - ")

            Vessel = rpt.ReportDefinition.ReportObjects("Vessel")
            Vessel.Text = tempVes(0)

            Voy = rpt.ReportDefinition.ReportObjects("Voy")
            Voy.Text = tempVes(1)

            Line = rpt.ReportDefinition.ReportObjects("LINE")
            Line.Text = Me.txtLine.Text

            TML = rpt.ReportDefinition.ReportObjects("TML")
            TML.Text = Me.cboTML.Text

            TS = rpt.ReportDefinition.ReportObjects("TS")
            TS.Text = Me.txtTS.Text

            VEL = rpt.ReportDefinition.ReportObjects("VELOPRATOR")
            VEL.Text = Me.txtVelOper.Text

            ETA = rpt.ReportDefinition.ReportObjects("ETA")
            ETA.Text = Me.dtpETA.Value.Date
            Dim dat As TextObject
            dat = rpt.ReportDefinition.ReportObjects("Date")
            dat.Text = Now.Date

            Me.CrystalReportViewer1.ReportSource = rpt
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()

    End Sub

    Private Sub frmRptCSCLBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CrystalReportViewer1.Visible = False
        Me.fraInfo.Visible = True
        Reformat()
        QueryVessel()

    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try
            mSailingScheduleID = FindValueID(Me.cboVessel, Me.cboVessel.Text)
        Catch ex As Exception

        End Try
    End Sub
    Sub Reformat()
        Me.fraInfo.Top = Me.Height / 2 - Me.fraInfo.Height / 2
        Me.fraInfo.Left = Me.Width / 2 - Me.fraInfo.Width / 2
    End Sub

    Private Sub frmRptCSCLBooking_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Reformat()
    End Sub
End Class