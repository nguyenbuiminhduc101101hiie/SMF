Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmReportForeignVessel
    Public mForeignID As String

    Private Sub frmReportForeignVessel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim rpt As New ReportForeignVessel

            'rpt.PrintOptions.PaperSize = PaperSize.PaperA4

            'Dim strSql As String = "Select * From TerminalDeparture where TerminalDeparture_ID='" & mForeignID & "'"
            'Dim tbl As New DataTable
            'tbl = ReadTable(strSql)
            'If tbl.Rows.Count = 0 Then
            '    Me.Close()
            '    Return
            'End If

            'strSql = "Select * From Vessel Where Vessel_ID='" & tbl.Rows(0).Item("Vessel_ID").ToString & "' and continued=1"
            'Dim tbl1 As DataTable
            'tbl1 = ReadTable(strSql)
            'If tbl1.Rows.Count = 0 Then
            '    Me.Close()
            '    Return
            'End If


            'Dim Gui As TextObject
            'Dim _To As TextObject
            'Dim Cang As TextObject
            'Dim Tentau As TextObject
            'Dim QuocTich As TextObject
            'Dim HoHieu As TextObject
            'Dim DangKy As TextObject
            'Dim ChuTau As TextObject
            'Dim DiaChi As TextObject
            'Dim Tel As TextObject
            'Dim Fax As TextObject
            'Dim LoaiTau As TextObject
            'Dim CongSuat As TextObject
            'Dim ChieuCao As TextObject
            'Dim ChieuDai As TextObject
            'Dim ChieuRong As TextObject
            'Dim VanToc As TextObject
            'Dim Mui As TextObject
            'Dim Lai As TextObject
            'Dim DungTich As TextObject
            'Dim TrongTai As TextObject
            'Dim LoaiHang As TextObject
            'Dim SoLuong As TextObject
            'Dim ThuyenVien As TextObject
            'Dim hanhKhach As TextObject
            'Dim TauDenCang As TextObject
            'Dim LuongNuoc As TextObject
            'Dim ThoiGian As TextObject
            'Dim MucDich As TextObject
            'Dim ThoiGianCuoi As TextObject
            'Dim TenDaiLy As TextObject
            'Dim Ma As TextObject

            'Gui = rpt.ReportDefinition.ReportObjects("Gui")
            'Gui.Text = tbl.Rows(0).Item("Gui")
            '_To = rpt.ReportDefinition.ReportObjects("To")
            '_To.Text = tbl.Rows(0).Item("_To")
            'Cang = rpt.ReportDefinition.ReportObjects("cang")
            'Cang.Text = tbl.Rows(0).Item("Port")

            ''---------
            'Tentau = rpt.ReportDefinition.ReportObjects("TenTau")
            'Tentau.Text = tbl1.Rows(0).Item("Vessel")

            'QuocTich = rpt.ReportDefinition.ReportObjects("QuocTich")
            'QuocTich.Text = tbl1.Rows(0).Item("NATIONALITY")

            'HoHieu = rpt.ReportDefinition.ReportObjects("HoHieu")
            'HoHieu.Text = tbl1.Rows(0).Item("Call_Sign")

            'DangKy = rpt.ReportDefinition.ReportObjects("NoiDangKy")
            'DangKy.Text = tbl1.Rows(0).Item("PortOfRegister")

            'ChuTau = rpt.ReportDefinition.ReportObjects("ChuTau")
            'ChuTau.Text = tbl1.Rows(0).Item("ShipOwner")

            'DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
            'DiaChi.Text = tbl1.Rows(0).Item("Address")

            'Tel = rpt.ReportDefinition.ReportObjects("Tel")
            'Tel.Text = tbl1.Rows(0).Item("Tel")

            'Fax = rpt.ReportDefinition.ReportObjects("Fax")
            'Fax.Text = tbl1.Rows(0).Item("Fax")

            'LoaiTau = rpt.ReportDefinition.ReportObjects("LoaiTau")
            'LoaiTau.Text = tbl1.Rows(0).Item("TypeOfShip")

            'CongSuat = rpt.ReportDefinition.ReportObjects("CongSuat")
            'CongSuat.Text = tbl1.Rows(0).Item("PowerOfEngine")

            'ChieuCao = rpt.ReportDefinition.ReportObjects("ChieuCao")
            'ChieuCao.Text = tbl1.Rows(0).Item("AirDraft")

            'ChieuDai = rpt.ReportDefinition.ReportObjects("ChieuDai")
            'ChieuDai.Text = tbl1.Rows(0).Item("LengthOver")

            'ChieuRong = rpt.ReportDefinition.ReportObjects("ChieuRong")
            'ChieuRong.Text = tbl1.Rows(0).Item("Breath")

            'VanToc = rpt.ReportDefinition.ReportObjects("VanToc")
            'VanToc.Text = tbl1.Rows(0).Item("Speed")

            'DungTich = rpt.ReportDefinition.ReportObjects("DungTich")
            'DungTich.Text = tbl1.Rows(0).Item("GrossTonnage")

            'TrongTai = rpt.ReportDefinition.ReportObjects("TrongTai")
            'TrongTai.Text = tbl1.Rows(0).Item("DeadWeight")

            ''---------
            'Mui = rpt.ReportDefinition.ReportObjects("Mui")
            'Mui.Text = tbl.Rows(0).Item("Fore")

            'Lai = rpt.ReportDefinition.ReportObjects("Lai")
            'Lai.Text = tbl.Rows(0).Item("After")

            'LoaiHang = rpt.ReportDefinition.ReportObjects("Loaihang")
            'LoaiHang.Text = tbl.Rows(0).Item("KindOfCargo")

            'SoLuong = rpt.ReportDefinition.ReportObjects("SoLuong")


            'Dim Temp(), Result As String

            'Result = tbl.Rows(0).Item("Quantity").ToString
            'Temp = Strings.Split(Result, Chr(13))
            'Result = ""


            'For j As Integer = 0 To Temp.Length - 1

            '    Result &= Temp(j)
            '    If Temp(j).Trim.Length > 0 Then
            '        For k As Integer = Temp(j).Length To SoLuong.Width \ 10
            '            Result &= " "
            '        Next
            '    End If


            'Next
            'SoLuong.Text = Result

            'ThuyenVien = rpt.ReportDefinition.ReportObjects("ThuyenVien")
            'ThuyenVien.Text = tbl.Rows(0).Item("NumCrew")

            'hanhKhach = rpt.ReportDefinition.ReportObjects("hanhKhach")
            'hanhKhach.Text = tbl.Rows(0).Item("NumPassenger")

            'TauDenCang = rpt.ReportDefinition.ReportObjects("TauDenCang")
            'TauDenCang.Text = tbl.Rows(0).Item("LastPortCall")

            'LuongNuoc = rpt.ReportDefinition.ReportObjects("LuongNuoc")
            'LuongNuoc.Text = tbl.Rows(0).Item("ActualDisplace")

            'ThoiGian = rpt.ReportDefinition.ReportObjects("ThoiGian")
            'ThoiGian.Text = tbl.Rows(0).Item("EstimatedTime")

            'MucDich = rpt.ReportDefinition.ReportObjects("MucDich")
            'MucDich.Text = tbl.Rows(0).Item("PurposePort")

            'ThoiGianCuoi = rpt.ReportDefinition.ReportObjects("ThoiGianCuoi")
            'ThoiGianCuoi.Text = tbl.Rows(0).Item("LastTimeArrival")

            'TenDaiLy = rpt.ReportDefinition.ReportObjects("TenDaiLy")
            'TenDaiLy.Text = tbl.Rows(0).Item("AgencyName")

            'Ma = rpt.ReportDefinition.ReportObjects("Code")
            'Ma.Text = tbl.Rows(0).Item("Code")

            'Me.rptForeignVessel.ReportSource = rpt
            'Me.rptForeignVessel.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class