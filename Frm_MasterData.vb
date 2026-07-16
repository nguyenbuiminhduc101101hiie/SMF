Imports System.Globalization
Imports System.IO
Imports System.Runtime.InteropServices
Imports Excel

Public Class Frm_MasterData
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim app As Application = Nothing
        Dim workbook As _Workbook = Nothing
        Dim ws As _Worksheet = Nothing
        Dim workPath As String = Nothing
        Dim outputPath As String = Nothing

        Try
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text

            outputPath = OpenDlg("MASTERDATA_TBS_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".xls")
            If String.IsNullOrEmpty(outputPath) Then
                Return
            End If

            Button1.Enabled = False
            lblProgress.Text = "Đang tải dữ liệu..."
            System.Windows.Forms.Application.DoEvents()

            Dim sql_airimp As String = " select * from inbound_OverseaAirImport where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_airimp As DataSet = ReadDataSet(sql_airimp)

            Dim sql_airexp As String = " select * from Outbound_OverseaAirExport where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_airexp As DataSet = ReadDataSet(sql_airexp)

            Dim sql_seaimp As String = " select * from inbound where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_seaimp As DataSet = ReadDataSet(sql_seaimp)

            Dim sql_seaexp As String = " select * from outbound where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "'"
            Dim ds_seaexp As DataSet = ReadDataSet(sql_seaexp)

            Dim totalRows As Integer = GetRowCount(ds_airimp) + GetRowCount(ds_airexp) + GetRowCount(ds_seaimp) + GetRowCount(ds_seaexp)
            BeginExportProgress(totalRows + 2)

            Dim templatePath As String = Path.Combine(StartupPath, "MASTERDATA_TBS.xls")
            workPath = Path.Combine(Path.GetTempPath(), "MASTERDATA_TBS_" & Guid.NewGuid().ToString("N") & ".xls")
            File.Copy(templatePath, workPath, True)

            app = New Application()
            app.Visible = False
            app.DisplayAlerts = False
            app.ScreenUpdating = False

            Dim workbooks As Workbooks = app.Workbooks
            workbook = workbooks.Open(workPath)

            Dim selectedKeys = LoadUserColumnKeys()
            Dim useTemplateLayout = UsesTemplateLayout(selectedKeys)
            Dim exportInUsd As Boolean = rdoUSD.Checked
            Dim currentRow As Integer = DataStartRow

            AdvanceExportProgress("Đang mở file Excel...")

            Dim sheets As Sheets = workbook.Worksheets
            ws = sheets.Item(1)

            If ws Is Nothing Then
                Return
            End If

            ApplyTemplateColumnLayout(ws, selectedKeys)

            ExportDataSet(ws, currentRow, ds_airimp, MasterDataShipmentKind.AirImport, selectedKeys, useTemplateLayout, exportInUsd, "Đang xuất Air Import...", AddressOf AdvanceExportProgress)
            ExportDataSet(ws, currentRow, ds_airexp, MasterDataShipmentKind.AirExport, selectedKeys, useTemplateLayout, exportInUsd, "Đang xuất Air Export...", AddressOf AdvanceExportProgress)
            ExportDataSet(ws, currentRow, ds_seaimp, MasterDataShipmentKind.SeaImport, selectedKeys, useTemplateLayout, exportInUsd, "Đang xuất Sea Import...", AddressOf AdvanceExportProgress)
            ExportDataSet(ws, currentRow, ds_seaexp, MasterDataShipmentKind.SeaExport, selectedKeys, useTemplateLayout, exportInUsd, "Đang xuất Sea Export...", AddressOf AdvanceExportProgress)

            AdvanceExportProgress("Đang lưu file Excel...")
            workbook.SaveAs(outputPath)

            MessageBox.Show("Xuất Excel thành công!" & vbCrLf & outputPath, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Xuất Excel thất bại: " & ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            EndExportProgress()
            ReleaseExcel(ws, workbook, app)
            If workPath IsNot Nothing AndAlso File.Exists(workPath) Then
                Try
                    File.Delete(workPath)
                Catch
                End Try
            End If
        End Try
    End Sub

    Private Sub btnConfigColumns_Click(sender As Object, e As EventArgs) Handles btnConfigColumns.Click
        Using frm As New Frm_MasterData_Config()
            frm.ShowDialog(Me)
        End Using
    End Sub

    Private progressCurrent As Integer = 0
    Private progressTotal As Integer = 0

    Private Sub BeginExportProgress(total As Integer)
        progressCurrent = 0
        progressTotal = Math.Max(total, 1)
        prbExport.Minimum = 0
        prbExport.Maximum = progressTotal
        prbExport.Value = 0
        prbExport.Visible = True
    End Sub

    Private Sub AdvanceExportProgress(status As String)
        progressCurrent += 1
        If progressCurrent > progressTotal Then
            progressCurrent = progressTotal
        End If
        prbExport.Value = progressCurrent
        Dim percent As Integer = CInt(progressCurrent * 100 / progressTotal)
        lblProgress.Text = status & " (" & progressCurrent & "/" & progressTotal & " - " & percent & "%)"
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub EndExportProgress()
        prbExport.Visible = False
        prbExport.Value = 0
        lblProgress.Text = ""
        Button1.Enabled = True
    End Sub

    Private Sub ReleaseExcel(ByRef ws As _Worksheet, ByRef workbook As _Workbook, ByRef app As Application)
        Try
            If ws IsNot Nothing Then
                Marshal.ReleaseComObject(ws)
                ws = Nothing
            End If
        Catch
        End Try

        Try
            If workbook IsNot Nothing Then
                workbook.Close(False)
                Marshal.ReleaseComObject(workbook)
                workbook = Nothing
            End If
        Catch
        End Try

        Try
            If app IsNot Nothing Then
                app.Quit()
                Marshal.ReleaseComObject(app)
                app = Nothing
            End If
        Catch
        End Try

        GC.Collect()
        GC.WaitForPendingFinalizers()
        GC.Collect()
    End Sub

    Private Function GetRowCount(ds As DataSet) As Integer
        If ds Is Nothing OrElse ds.Tables.Count = 0 Then
            Return 0
        End If

        Return ds.Tables(0).Rows.Count
    End Function
End Class
