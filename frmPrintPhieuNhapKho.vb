Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Public Class frmPrintPhieuNhapKho

    Private Sub frmPrintPhieuNhapKho_Load(sender As Object, e As EventArgs) Handles Me.Load
        printReport()
    End Sub

    Public Sub printReport()

        Try

            '-------------------
            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim strReportName As String

            rptDoCument = New ReportDocument

            strReportName = "Reportphieunhapkho"




            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'Formatting paper

            ' End If
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            For Each tbCurrent In rptDoCument.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = strServer
                    .UserID = strUserId
                    .Password = strPassword
                    .DatabaseName = strDatabase
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            rptDoCument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)

            CrystalReportViewer1.ReportSource = rptDoCument
            '------------------------------------------

            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

            rptDoCument.Refresh()

            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        printReport()
    End Sub
End Class