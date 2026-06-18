Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmPrintBienbanvanchuyen

    Private Sub cmdRefresh_Click(sender As Object, e As EventArgs) Handles cmdRefresh.Click
        Try
            print()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPrintBienbanvanchuyen_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            print()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub print()
        Try
            Dim rptDoCument As ReportDocument
            rptDoCument = New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            ' ten Report
            strReportName = "ReportBienbanvanchuyen"
            'If Me.chkCheckAir.Checked = True Then
            '    strReportName = "ReportLenhGiaohangnoAT_air"
            'End If

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)


            Dim T1() As String
            Dim T As String
            Dim showText As Object
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from logistics where BLOB_ID='" & gLogisticsID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then


                '------------lay container/seal/loai
                Dim sqlcont As String
                Dim dscont As New DataSet
                Dim socont As String = ""
                Dim loaicont As String = ""
                Dim i As Integer
                sqlcont = "select * from containerlogistics where outboundid='" & gLogisticsID & "' "

                dscont = ReadDataSet(sqlcont)
                If dscont.Tables(0).Rows.Count > 0 Then
                    socont += dscont.Tables(0).Rows(i).Item("containerno").ToString + "/" + dscont.Tables(0).Rows(i).Item("containertype").ToString + ", "
                    loaicont += dscont.Tables(0).Rows(i).Item("containertype").ToString
                End If

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtsocontainer")
                T1 = Strings.Split(socont, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T


                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtsoluong")
                T1 = Strings.Split("01 x " + loaicont, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtdiadiem")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("diadiemnhanhang").ToString + "/" + ds.Tables(0).Rows(0).Item("diadiemgiaohang").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtlienhe")
                T1 = Strings.Split(ds.Tables(0).Rows(0).Item("nguoilienlac").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T

            End If




            CrystalReportViewer1.ReportSource = rptDoCument
            '------------- 
            rptDoCument.Refresh()
            '----------------

            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

            '--------------------------
        Catch ex As Exception

        End Try
    End Sub

End Class