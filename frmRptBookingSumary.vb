Imports System.Globalization
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Public Class frmRptBookingSumary
    '    Dim dt As New DataTable
    '    Dim week As TextObject
    '    Dim rpt As New ReportBookingSummary

    '    Public Function WeekOfYear(ByVal dat As String) As Integer
    '        On Error GoTo Err_Renamed
    '        Dim myCI As New CultureInfo("en-US")
    '        Dim myCal As Calendar = myCI.Calendar
    '        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
    '        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
    '        If dat <> "" Then
    '            WeekOfYear = myCal.GetWeekOfYear(CDate(dat), myCWR, myFirstDOW)
    '        Else
    '            WeekOfYear = 0
    '        End If
    '        Exit Function
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Function

    '    Sub QueryBookingSumary(ByVal Week As String)
    '        Try
    '            Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '            Dim StrQuery As String
    '            StrQuery = "select SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong20RF,SoLuong40RF,SoLuong45HC,SoLuong40RH,Market ,"
    '            StrQuery &= " Total = SoLuong20GP + SoLuong40GP*2 + SoLuong40HC*2 + SoLuong20RF + SoLuong40RF*2 + SoLuong45HC*2 + SoLuong40RH*2 "
    '            StrQuery &= " from (containerOutboundNotify  INNER JOIN Market On Market.Market_ID=ContainerOutboundNotify.Market_ID)"
    '            StrQuery &= "Where ContainerOutboundNotify.Continued=1 And WeekOfyear='" & Week & "'"
    '            Dim cmdselect As New SqlClient.SqlCommand(StrQuery, Conn)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmdselect)
    '            If Not IsNothing(dt) Then
    '                dt.Clear()

    '            End If
    '            Adapter.Fill(dt)
    '        Catch ex As Exception

    '        End Try
    '    End Sub
    '    Sub QueryWeek()
    '        Try
    '            Dim dt1 As New DataTable
    '            Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '            Dim StrQuery As String
    '            StrQuery = "Select Distinct WeekOfYear from containerOutboundNotify Where Continued=1 order by weekofyear ASC"
    '            Dim cmdselect As New SqlClient.SqlCommand(StrQuery, Conn)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmdselect)
    '            If Not IsNothing(dt1) Then
    '                dt1.Clear()
    '            End If
    '            Me.cboWeek.Items.Clear()
    '            Adapter.Fill(dt1)
    '            For i As Integer = 0 To dt1.Rows.Count - 1
    '                Me.cboWeek.Items.Add(dt1.Rows(i).Item(0).ToString)
    '            Next
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Private Sub frmRptBookingSumary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    '        QueryWeek()
    '        Me.cboWeek.SelectedIndex = 0
    '        QueryBookingSumary(Me.cboWeek.Text)
    '        'If dt.Rows.Count > 0 Then
    '        '    rpt.SetDataSource(dt)
    '        '    Me.CrystalReportViewer1.ReportSource = rpt
    '        '    Me.CrystalReportViewer1.Refresh()

    '        '    Me.CrystalReportViewer1.Show()
    '        'End If

    '    End Sub
    '    Private Sub cboWeek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWeek.SelectedIndexChanged
    '        QueryBookingSumary(Me.cboWeek.Text)

    '        If dt.Rows.Count > 0 Then

    '            week = rpt.ReportDefinition.ReportObjects("Week")
    '            week.Text = Me.cboWeek.Text
    '        End If

    '        rpt.SetDataSource(dt)
    '        Me.CrystalReportViewer1.ReportSource = rpt
    '        Me.CrystalReportViewer1.Refresh()
    '        Me.CrystalReportViewer1.Show()

    '    End Sub
End Class