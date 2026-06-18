Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmprintProfitWoojin
    Public rptDocument As New ReportDocument
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmprintProfitWoojin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strReportName As String
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            strReportName = "ReportProfitwoojin"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)




            rptDocument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            For Each tbCurrent In rptDocument.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = strServer
                    .UserID = strUserId
                    .Password = strPassword
                    .DatabaseName = strDatabase
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent
            Dim mymargins = rptDocument.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM

            rptDocument.PrintOptions.ApplyPageMargins(mymargins)
            CrystalReportViewer1.ReportSource = rptDocument
            rptDocument.Refresh()
        Catch ex As Exception

        End Try
    End Sub
End Class