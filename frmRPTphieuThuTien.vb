Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRPTphieuThuTien
    Public data As Boolean
    Sub PrintRpt()
        Try
            If frmPhieuThuTien.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) = 0 Then

                Me.Close()
                Return
            End If
            Dim strReportName As String
            Dim rpt As Object
            Me.CrystalReportViewer1.ReportSource = Nothing
            If data = True Then
                'rpt = New ReportDocument
                '-------------
                ' ten Report
                strReportName = "ReportDataPhieuThuTien"
                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rpt.Load(strReportPath)
                '-------------
            Else
                rpt = New ReportDocument
                '-------------
                ' ten Report
                strReportName = "ReportPhieuThuTien"
                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rpt.Load(strReportPath)
                '----------
            End If

            Dim BLNO, khachHang, DiaChi, MaSoThue, HinhThucThanhToan, SerialNo As TextObject

            SerialNo = rpt.ReportDefinition.ReportObjects("SerialNo")
            SerialNo.Text = frmPhieuThuTien.txtSeriesNo.Text.ToString
            BLNO = rpt.ReportDefinition.ReportObjects("BLNO")
            BLNO.Text = gBillNoInBound

            khachHang = rpt.ReportDefinition.ReportObjects("khachHang")
            khachHang.Text = frmPhieuThuTien.txtTenKhachHang.Text.ToString

            DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
            DiaChi.Text = frmPhieuThuTien.txtDiaChi.Text.ToString

            MaSoThue = rpt.ReportDefinition.ReportObjects("MaSoThue")
            MaSoThue.Text = frmPhieuThuTien.txtMaSoThue.Text.ToString

            HinhThucThanhToan = rpt.ReportDefinition.ReportObjects("HinhThucThanhToan")
            HinhThucThanhToan.Text = frmPhieuThuTien.txtHinhThucThanhToan.Text.ToString

            If frmPhieuThuTien.dgdNoiDungThu.RowCount > 0 Then
                Dim NoiDung As TextObject
                NoiDung = rpt.ReportDefinition.ReportObjects("NoiDung")
                NoiDung.Text = frmPhieuThuTien.dgdNoiDungThu.Item("Noidung", frmPhieuThuTien.dgdNoiDungThu.SelectedRows(0).Index).Value.ToString
            End If
            Dim Total As Double = 0
            Dim Dif As Boolean = False
            'If frmPhieuThuTien.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) = 0 Then
            '    MsgBox("You have to select Some row on the grid  ")
            'End If
            For RowReport As Integer = 0 To frmPhieuThuTien.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1
                Dim i As Integer = frmPhieuThuTien.dgdNoiDungThu.SelectedRows(RowReport).Index 'Row In Grid
                Dim stt, Nodung, DonVitinh, SoLuong, ThanhTien, Thu, Thue As TextObject

                'If Dif = False And frmPhieuThuTien.dgdNoiDungThu.Item("SeriesNo", i).Value.ToString.Trim <> SerialNo.Text.Trim Then
                '    Dif = True
                '    MsgBox("Các dòng chọn Phải có cùng số serial, hãy kiểm tra lại Dữ liệu có thể không chính xác")
                '    Me.Close()
                'End If
                stt = rpt.ReportDefinition.ReportObjects("Stt" & RowReport + 1)
                stt.Text = (RowReport + 1).ToString 'frmPhieuThuTien.dgdNoiDungThu.Rows(i).HeaderCell.Value.ToString

                Nodung = rpt.ReportDefinition.ReportObjects("Noidung" & RowReport + 1)
                Nodung.Text = "Container " & frmPhieuThuTien.dgdNoiDungThu.Item("LoaiContainer", i).Value.ToString & "f : " & frmPhieuThuTien.dgdNoiDungThu.Item("DonGia", i).Value.ToString

                DonVitinh = rpt.ReportDefinition.ReportObjects("DonVitinh" & RowReport + 1)
                DonVitinh.Text = frmPhieuThuTien.dgdNoiDungThu.Item("DonVitinh", i).Value.ToString

                SoLuong = rpt.ReportDefinition.ReportObjects("SoLuong" & RowReport + 1)
                SoLuong.Text = frmPhieuThuTien.dgdNoiDungThu.Item("SoLuong", i).Value.ToString

                ThanhTien = rpt.ReportDefinition.ReportObjects("ThanhTien" & RowReport + 1)
                ThanhTien.Text = FormatNumber(CDbl(frmPhieuThuTien.dgdNoiDungThu.Item("ThanhTien", i).Value.ToString), 0)
                Total += FormatNumber(CDbl(ThanhTien.Text), 0) ' tính tổng số tiền của 1 số seri

                Thu = rpt.ReportDefinition.ReportObjects("Thu" & RowReport + 1)
                Thu.Text = FormatNumber(CDbl(ThanhTien.Text) / 1.1, 0)

                Thue = rpt.ReportDefinition.ReportObjects("Thue" & RowReport + 1)
                Thue.Text = FormatNumber(CDbl(ThanhTien.Text) - CDbl(Thu.Text), 0)

            Next
            Dim TongCong, TongThu, TongThue As TextObject

            TongCong = rpt.ReportDefinition.ReportObjects("TongCong")
            TongCong.Text = FormatNumber((CDbl(Total)), 0)

            TongThu = rpt.ReportDefinition.ReportObjects("Thu")
            TongThu.Text = FormatNumber((CDbl(TongCong.Text) / 1.1), 0)

            TongThue = rpt.ReportDefinition.ReportObjects("Thue")
            TongThue.Text = FormatNumber(CDbl(TongCong.Text) - CDbl(TongThu.Text), 0)

            '        Dim dat As Date

            Dim Ngay, Thang, Nam, Sotienchu As TextObject
            Ngay = rpt.ReportDefinition.ReportObjects("Ngay")
            Ngay.Text = Now.Day
            Thang = rpt.ReportDefinition.ReportObjects("Thang")
            Thang.Text = Now.Month
            Nam = rpt.ReportDefinition.ReportObjects("Nam")
            Nam.Text = Now.Year
            Sotienchu = rpt.ReportDefinition.ReportObjects("Sotienchu")
            Sotienchu.Text = VNumberToWord(CDbl(Total), frmPhieuThuTien.dgdNoiDungThu.Item("donvitinh", 0).Value.ToString) 'VNumberToWord(CDbl(frmPhieuThuTien.txtTongCong.Text))
            If data = True Then
                rpt.PrintToPrinter(1, True, 1, 100)
                Return
            End If
            Me.CrystalReportViewer1.ReportSource = rpt
            'Formatting paper
            'Formatting paper
            Dim mymargins
            mymargins = rpt.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM
            rpt.PrintOptions.ApplyPageMargins(mymargins)
            Me.CrystalReportViewer1.ReportSource = rpt
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()
            'rpt.close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmRPTphieuThuTien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CrystalReportViewer1.ReportSource = Nothing
        PrintRpt()
    End Sub

    Private Sub cmdPrintData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrintData.Click
        Try
            data = True
            PrintRpt()
            data = False
            PrintRpt()
        Catch ex As Exception

        End Try
    End Sub
End Class