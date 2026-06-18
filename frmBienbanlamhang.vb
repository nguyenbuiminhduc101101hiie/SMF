Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
'Imports Excel
Public Class frmBienbanlamhang

    Public flag As Integer
    Private Sub frmManifestConsol_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String


            rptDoCument = New ReportDocument




            strReportName = "ReportBienbanlamhang"




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
            '--------------connect ko can login
            Dim connection As IConnectionInfo
            For Each connection In rptDoCument.DataSourceConnections

                'Select Case connection.ServerName

                '    Case strServer
                connection.SetConnection(strServer, strDatabase, strUserId, strPassword)
                '        ' connection.SetLogon(strUserId, strPassword)

                'End Select

            Next
            '------------
            'Set Database Logon to subreport

            Dim subreport As ReportDocument

            For Each subreport In rptDoCument.Subreports

                For Each connection In subreport.DataSourceConnections

                    'Select Case connection.ServerName

                    '    Case strServer

                    connection.SetConnection(strServer, strDatabase, strUserId, strPassword)

                    'End Select

                Next

            Next
            '----------------------------------------------------------------------------
            CrystalReportViewer1.ReportSource = rptDoCument
            '------------------------------------------


            '-------------------------------------------------------------
            '-----------chuan bi so lieu ghi vao SOA



            '-------------------------


            'Me.CrystalReportViewer1.ReportSource = rptDoCument
            'Formatting paper

            If flag = 1 Then
                mymargins = rptDoCument.PrintOptions.PageMargins
                mymargins.topMargin = gTopM
                mymargins.bottomMargin = gBottomM
                mymargins.leftMargin = gLeftM
                mymargins.rightMargin = gRightM
                'rptDoCument.PrintOptions.ApplyPageMargins(mymargins)
            End If
            'rptDoCument.PrintOptions.PaperSize = PaperSize.PaperA4
            'If frmMain.mnuReportOrientationPortrait.Checked Then
            '    rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            'Else
            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            'End If
            rptDoCument.Refresh()

            'If frmInBoundRemarks.CountBill > 1 Then
            '    rptDoCument.PrintToPrinter(1, True, 1, 2)
            '    Me.Close()
            'End If
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()
            'Dim strMesg As String = "Print this Arrival Note! ?"
            'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            '    rptDoCument.Refresh()
            '    rptDoCument.PrintToPrinter(1, True, 1, 1)
            'End If
        Catch ex As Exception

        End Try
    End Sub
End Class