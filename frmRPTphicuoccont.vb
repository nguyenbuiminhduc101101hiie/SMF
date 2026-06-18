Imports CrystalDecisions.CrystalReports.Engine

Public Class frmRPTphicuoccont
    Public data As Boolean
    Sub PrintRpt()
        'Try
        '    Dim strReportName As String
        '    Dim rpt As Object
        '    Me.CrystalReportViewer1.ReportSource = Nothing
        '    Dim row As Integer = frmPhicuoccont.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected)
        '    If data = True Then
        '        rpt = New ReportDocument
        '        '-------------
        '        ' ten Report
        '        strReportName = "ReportDataPhieuThuTien"
        '        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        '        If Not IO.File.Exists(strReportPath) Then
        '            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
        '            Exit Sub
        '        End If
        '        rpt.Load(strReportPath)
        '        '-------------
        '    Else
        '        rpt = New ReportDocument
        '        If row < 13 Then
        '            strReportName = "ReportPhicuoccont"
        '        ElseIf row > 13 And row <= 17 Then
        '            strReportName = "ReportPhicuoccont20"
        '        Else
        '            MsgBox("Xin Chọn làm nhiều lần In vì số container quá nhiều.")
        '            Me.Close()
        '            Return
        '        End If

        '        '-------------
        '        ' ten Report

        '        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        '        If Not IO.File.Exists(strReportPath) Then
        '            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
        '            Exit Sub
        '        End If
        '        rpt.Load(strReportPath)
        '        '----------
        '    End If

        '    Dim BLNO, khachHang, DiaChi, MaSoThue, Description, SerialNo As TextObject

        '    'SerialNo = rpt.ReportDefinition.ReportObjects("SerialNo")
        '    'SerialNo.Text = frmPhieuThuTien.txtSeriesNo.Text.ToString
        '    BLNO = rpt.ReportDefinition.ReportObjects("BLNO")
        '    BLNO.Text = gBillNoInBound

        '    khachHang = rpt.ReportDefinition.ReportObjects("khachHang")
        '    khachHang.Text = frmPhicuoccont.txtTenKhachHang.Text.ToString

        '    DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
        '    DiaChi.Text = frmPhicuoccont.txtDiaChi.Text.ToString

        '    'MaSoThue = rpt.ReportDefinition.ReportObjects("MaSoThue")
        '    'MaSoThue.Text = frmPhicuoccont.txtMaSoThue.Text.ToString

        '    Dim Temp As String = ""
        '    For i As Integer = 0 To frmListBaseIB.dgdBillOfLading.RowCount - 1
        '        If gBillNoInBound.Trim = frmListBaseIB.dgdBillOfLading.Item("BL_NO", i).Value.ToString().Trim Then
        '            Temp = frmListBaseIB.dgdBillOfLading.Item("DESCRIPTIONOFGOODS", i).Value.ToString()
        '            Exit For
        '        End If
        '    Next
        '    Description = rpt.ReportDefinition.ReportObjects("Description")
        '    Description.Text = Temp 'frmPhicuoccont.txtHinhThucThanhToan.Text.ToString

        '    If row > 0 Then
        '        Dim NoiDung As TextObject
        '        NoiDung = rpt.ReportDefinition.ReportObjects("NoiDung")
        '        NoiDung.Text = frmPhicuoccont.dgdNoiDungThu.Item("Noidung", frmPhicuoccont.dgdNoiDungThu.SelectedRows(0).Index).Value.ToString
        '    End If
        '    Dim TongCong, TongThu, TongThue As TextObject
        '    Dim tongcongdbl As Double = 0
        '    For j As Integer = 0 To row - 1
        '        Dim stt, Nodung, DonVitinh, SoLuong, ThanhTien, Thu, Thue As TextObject

        '        Dim i As Integer = frmPhicuoccont.dgdNoiDungThu.SelectedRows(j).Index
        '        stt = rpt.ReportDefinition.ReportObjects("Stt" & j + 1)
        '        stt.Text = j + 1
        '        Nodung = rpt.ReportDefinition.ReportObjects("Noidung" & j + 1)
        '        Nodung.Text = frmPhicuoccont.dgdNoiDungThu.Item("Container_No", i).Value.ToString & Chr(32) & " / " & frmPhicuoccont.dgdNoiDungThu.Item("Loaicont", i).Value.ToString & " : " & frmPhicuoccont.dgdNoiDungThu.Item("SoTien", i).Value.ToString

        '        DonVitinh = rpt.ReportDefinition.ReportObjects("DonVitinh" & j + 1)
        '        DonVitinh.Text = frmPhicuoccont.dgdNoiDungThu.Item("DonVitinh", i).Value.ToString

        '        SoLuong = rpt.ReportDefinition.ReportObjects("SoLuong" & j + 1)
        '        SoLuong.Text = frmPhicuoccont.dgdNoiDungThu.Item("SoLuong", i).Value.ToString

        '        ThanhTien = rpt.ReportDefinition.ReportObjects("ThanhTien" & j + 1)
        '        ThanhTien.Text = FormatNumber(CDbl(frmPhicuoccont.dgdNoiDungThu.Item("ThanhTien", i).Value.ToString), 0, TriState.False)

        '        Thu = rpt.ReportDefinition.ReportObjects("Thu" & j + 1)
        '        Thu.Text = FormatNumber(CDbl(frmPhicuoccont.dgdNoiDungThu.Item("soTien", i).Value.ToString), 0, TriState.False)

        '        'Thue = rpt.ReportDefinition.ReportObjects("Thue" & i + 1)
        '        'Thue.Text = FormatNumber(CDbl(ThanhTien.Text) - CDbl(Thu.Text), 0, TriState.False)
        '        tongcongdbl += CDbl(ThanhTien.Text)
        '    Next


        '    TongCong = rpt.ReportDefinition.ReportObjects("TongCong")
        '    TongCong.Text = FormatNumber(CDbl(tongcongdbl), 0, TriState.False)

        '    'TongThu = rpt.ReportDefinition.ReportObjects("Thu")
        '    'TongThu.Text = FormatNumber((CDbl(TongCong.Text) / 1.1), 0, TriState.False)

        '    'TongThue = rpt.ReportDefinition.ReportObjects("Thue")
        '    'TongThue.Text = FormatNumber(CDbl(TongCong.Text) - CDbl(TongThu.Text), 0, TriState.False)

        '    '        Dim dat As Date

        '    Dim Ngay, Thang, Nam, Sotienchu As TextObject
        '    Ngay = rpt.ReportDefinition.ReportObjects("Ngay")
        '    Ngay.Text = Now.Day
        '    Thang = rpt.ReportDefinition.ReportObjects("Thang")
        '    Thang.Text = Now.Month
        '    Nam = rpt.ReportDefinition.ReportObjects("Nam")
        '    Nam.Text = Now.Year
        '    Sotienchu = rpt.ReportDefinition.ReportObjects("Sotienchu")
        '    Sotienchu.Text = VNumberToWord(CDbl(tongcongdbl), frmPhicuoccont.dgdNoiDungThu.Item("donvitinh", 0).Value.ToString)
        '    If data = True Then
        '        rpt.PrintToPrinter(1, True, 1, 100)
        '        Return
        '    End If
        '    Me.CrystalReportViewer1.ReportSource = rpt
        '    'Formatting paper
        '    'Formatting paper
        '    Dim mymargins
        '    mymargins = rpt.PrintOptions.PageMargins
        '    mymargins.topMargin = gTopM
        '    mymargins.bottomMargin = gBottomM
        '    mymargins.leftMargin = gLeftM
        '    mymargins.rightMargin = gRightM
        '    rpt.PrintOptions.ApplyPageMargins(mymargins)
        '    Me.CrystalReportViewer1.ReportSource = rpt
        '    Me.CrystalReportViewer1.Refresh()
        '    Me.CrystalReportViewer1.Show()

        'Catch ex As Exception
        '    DisplayMessage(True, Err.Description)
        'End Try
    End Sub

    Private Sub frmRPTphieuThuTien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CrystalReportViewer1.ReportSource = Nothing
        If frmPhicuoccont.dgdNoiDungThu.Rows.GetRowCount(DataGridViewElementStates.Selected) = 0 Then
            Me.Close()
            Return
        End If
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