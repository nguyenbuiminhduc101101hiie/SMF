Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class rptArrialvPermissionforForeignVessel
    Public BoardingID As String = ""
    Dim mdate As Date
    Dim mKeTuNgay As Date
    Dim mDaiLy As String = ""
    Function QueryBoardingAgent(ByVal ID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Vessel.*,PurposeToPortAD,AgentName,LastDateOfArrivalAD "
            SQL &= " from (Vessel LEFT JOIN BOardingAgent On BoardingAgent.ShipCode=Vessel.Vessel_Code )"
            SQL &= "Where BOardingAgent.Continued=1 And BoardingAgentID='" & ID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub print_Rpt()
        Try
            Dim rptDocument As ReportDocument

            If IsNothing(rptDocument) Then
                rptDocument = New ReportDocument
            End If
            Dim strReportName As String
            'Dim strQuery As String
            'Dim CargoMarks As TextObject
            'BoardingID = "DB231053-DFBA-4AC3-A574-3F566D852704"
            Dim dt As New DataTable
            dt = QueryBoardingAgent(BoardingID)
            If dt.Rows.Count <= 0 Then
                MsgBox("No data")
                Me.Close()
                Return
            End If
            Me.CrystalReportViewer1.ReportSource = Nothing

            strReportName = "ReportArivalPermissionForForeignVessel.rpt"

            ' ten Report--------------

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)
            Dim DaiLy As TextObject
            DaiLy = rptDocument.ReportDefinition.ReportObjects("DaiLy")
            DaiLy.Text = dt.Rows(0).Item("AgentName").ToString 'Me.txtDaiLy.Text

            Dim Ngay As TextObject
            Ngay = rptDocument.ReportDefinition.ReportObjects("XinPhepNgay")
            Ngay.Text = Me.dtpDate.Value.Day & "  Tháng  " & Me.dtpDate.Value.Month & "  Năm  " & Me.dtpDate.Value.Year

            Dim Vessel As TextObject
            Vessel = rptDocument.ReportDefinition.ReportObjects("Vessel")
            Vessel.Text = dt.Rows(0).Item("Vessel").ToString

            Dim QuocTich As TextObject
            QuocTich = rptDocument.ReportDefinition.ReportObjects("QuocTich")
            QuocTich.Text = dt.Rows(0).Item("NATIONALITY").ToString

            Dim HoHieu As TextObject
            HoHieu = rptDocument.ReportDefinition.ReportObjects("HoHieu")
            HoHieu.Text = dt.Rows(0).Item("Call_Sign").ToString

            Dim De As TextObject
            De = rptDocument.ReportDefinition.ReportObjects("De")
            De.Text = dt.Rows(0).Item("PurposeToPortAD").ToString 'Me.txtFor.Text

            Dim KetuNgay As TextObject
            KetuNgay = rptDocument.ReportDefinition.ReportObjects("KeTuNgay")
            KetuNgay.Text = Me.dtpKeTuNgay.Value.Day & "  Tháng  " & Me.dtpKeTuNgay.Value.Month & "  Năm  " & Me.dtpKeTuNgay.Value.Year

            Dim Vessel1 As TextObject
            Vessel1 = rptDocument.ReportDefinition.ReportObjects("Vessel2")
            Vessel1.Text = dt.Rows(0).Item("Vessel").ToString

            Dim Vessel2 As TextObject
            Vessel2 = rptDocument.ReportDefinition.ReportObjects("Vessel3")
            Vessel2.Text = dt.Rows(0).Item("Vessel").ToString

            Me.CrystalReportViewer1.ReportSource = rptDocument
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

            '----------------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)

        End Try
    End Sub
    Private Sub rptArrialvPermissionforForeignVessel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grpComfirmInfo.Visible = True
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        print_Rpt()
        Me.grpComfirmInfo.Visible = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.grpComfirmInfo.Visible = False
    End Sub

   
    Private Sub cmdUpdateInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInfo.Click
        Me.grpComfirmInfo.Visible = True
    End Sub
End Class