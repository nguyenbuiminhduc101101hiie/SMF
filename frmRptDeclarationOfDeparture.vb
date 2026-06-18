Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptDeclarationOfDeparture

    Private Sub frmRptDeclarationOfDeparture_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.grpComfirmInfo.Visible = True
    End Sub
    Public VesselID As String
    Function QueryVesselInfo(ByVal ID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Vessel.*,BoardingAgent.* "
            SQL &= "from (Vessel INNER JOIN BoardingAgent On BoardingAgent.ShipCode=Vessel.Vessel_Code)"
            SQL &= "Where BoardingAgent.Continued=1 And BoardingAgentID='" & ID & "'"
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
            Dim dt As New DataTable
            'VesselID = "44CE47F6-C819-4385-8511-6441551455D5"
            dt = QueryVesselInfo(VesselID)
            If dt.Rows.Count <= 0 Then
                MsgBox("No data")
                Me.Close()
                Return
            End If
            Me.CrystalReportViewer1.ReportSource = Nothing
            strReportName = "ReportDeclarationOfDeparture.rpt"

            ' ten Report--------------

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)

            Dim Check As TextObject
            Check = rptDocument.ReportDefinition.ReportObjects("CheckDEN")
            Check.Text = "X"

            'Dim DaiLy As TextObject
            'DaiLy = rptDocument.ReportDefinition.ReportObjects("DaiLy")
            'DaiLy.Text = dt.Rows(0).Item("AgentName").ToString

            'Dim Ngay As TextObject
            'Ngay = rptDocument.ReportDefinition.ReportObjects("LanCuoiDenCangVN")
            'Ngay.Text = dt.Rows(0).Item("LastDateOfArrivalAD").ToString 'Me.dtpDate.Value.Day & "  Tháng  " & Me.dtpDate.Value.Month & "  Năm  " & Me.dtpDate.Value.Year

            Dim Vessel As TextObject
            Vessel = rptDocument.ReportDefinition.ReportObjects("tentau")
            Vessel.Text = dt.Rows(0).Item("Vessel").ToString & dt.Rows(0).Item("TypeOfShip").ToString

            Dim Cangden As TextObject
            Cangden = rptDocument.ReportDefinition.ReportObjects("Cangden")
            Cangden.Text = dt.Rows(0).Item("Dis_LoadPortAD").ToString


            Dim Thoigianden As TextObject
            Thoigianden = rptDocument.ReportDefinition.ReportObjects("Thoigianden")
            Thoigianden.Text = dt.Rows(0).Item("DATEOFARRIVALAD").ToString

            Dim GIOden As TextObject
            GIOden = rptDocument.ReportDefinition.ReportObjects("GIOden")
            GIOden.Text = dt.Rows(0).Item("TIMEOFARRIVALAD").ToString


            Dim HoHieu As TextObject
            HoHieu = rptDocument.ReportDefinition.ReportObjects("HoHieu")
            HoHieu.Text = dt.Rows(0).Item("Call_Sign").ToString
            Dim SoIMO As TextObject
            SoIMO = rptDocument.ReportDefinition.ReportObjects("SoIMO")
            SoIMO.Text = dt.Rows(0).Item("IMONO").ToString()


            Dim TenThuyenTruong As TextObject
            TenThuyenTruong = rptDocument.ReportDefinition.ReportObjects("ThuyenTruongden")
            TenThuyenTruong.Text = dt.Rows(0).Item("CaptionNameAD").ToString
            'Dim DuKienDenCang As TextObject
            'DuKienDenCang = rptDocument.ReportDefinition.ReportObjects("ThoiGianDuKienDenCang")
            'DuKienDenCang.Text = Me.dtpKeTuNgay.Value.Date 'Me.dtpKeTuNgay.Value.Day & "  Tháng  " & Me.dtpKeTuNgay.Value.Month & "  Năm  " & Me.dtpKeTuNgay.Value.Year
            '----------truoc-giua-den
            Dim CangTruoc As TextObject
            CangTruoc = rptDocument.ReportDefinition.ReportObjects("CangTruoc")
            CangTruoc.Text = dt.Rows(0).Item("PreviousPortAD").ToString()

            Dim CangGiua As TextObject
            CangGiua = rptDocument.ReportDefinition.ReportObjects("CangGiua")
            CangGiua.Text = dt.Rows(0).Item("Dis_LoadPortAD").ToString()

            Dim Cangke As TextObject
            Cangke = rptDocument.ReportDefinition.ReportObjects("Cangke")
            Cangke.Text = dt.Rows(0).Item("NextPortAD").ToString()
            '----------------
            Dim CangROICUOICUNG As TextObject
            CangROICUOICUNG = rptDocument.ReportDefinition.ReportObjects("CangROICUOICUNG")
            CangROICUOICUNG.Text = dt.Rows(0).Item("PreviousPortAD").ToString()

            Dim ChuTau As TextObject
            ChuTau = rptDocument.ReportDefinition.ReportObjects("ChuTau")
            ChuTau.Text = dt.Rows(0).Item("ShipOwner").ToString & " & " & dt.Rows(0).Item("Address").ToString

            Dim DaiLy As TextObject
            DaiLy = rptDocument.ReportDefinition.ReportObjects("TenDiachiDaily")
            DaiLy.Text = dt.Rows(0).Item("AgentName").ToString

            'Dim Address As TextObject
            'Address = rptDocument.ReportDefinition.ReportObjects("DiaChi")
            'Address.Text = dt.Rows(0).Item("Address").ToString

            'Dim LoaiTau As TextObject
            'LoaiTau = rptDocument.ReportDefinition.ReportObjects("LoaiTau")
            'LoaiTau.Text = dt.Rows(0).Item("TypeOfShip").ToString

            'Dim CongSuatmay As TextObject
            'CongSuatmay = rptDocument.ReportDefinition.ReportObjects("CongSuatmay")
            'CongSuatmay.Text = dt.Rows(0).Item("PowerOfEngine").ToString


            'Dim ChieuCaotinhKhong As TextObject
            'ChieuCaotinhKhong = rptDocument.ReportDefinition.ReportObjects("ChieuCaotinhKhong")
            'ChieuCaotinhKhong.Text = dt.Rows(0).Item("AirDraft").ToString


            Dim ChieuDaiToiDa As TextObject
            ChieuDaiToiDa = rptDocument.ReportDefinition.ReportObjects("ChieuDai")
            ChieuDaiToiDa.Text = dt.Rows(0).Item("LengthOver").ToString


            Dim ChieuRong As TextObject
            ChieuRong = rptDocument.ReportDefinition.ReportObjects("ChieuRong")
            ChieuRong.Text = dt.Rows(0).Item("Breath").ToString

            'Dim TocDo As TextObject
            'TocDo = rptDocument.ReportDefinition.ReportObjects("TocDo")
            'TocDo.Text = dt.Rows(0).Item("Speed").ToString

            Dim MonNuocKhiDen As TextObject
            MonNuocKhiDen = rptDocument.ReportDefinition.ReportObjects("MonNuocMuiTau")
            MonNuocKhiDen.Text = dt.Rows(0).Item("foreDraftAD").ToString & "/" & dt.Rows(0).Item("AfterDraftAD").ToString

            'Dim Lai As TextObject
            'Lai = rptDocument.ReportDefinition.ReportObjects("Lai")
            'Lai.Text = dt.Rows(0).Item("AfterDraftAD").ToString

            Dim DungTichToanPhan As TextObject
            DungTichToanPhan = rptDocument.ReportDefinition.ReportObjects("TongDungTich")
            DungTichToanPhan.Text = dt.Rows(0).Item("GrossTonnage").ToString


            Dim DungTichCoIch As TextObject
            DungTichCoIch = rptDocument.ReportDefinition.ReportObjects("DungTichCoIch")
            DungTichCoIch.Text = dt.Rows(0).Item("NetTonnage").ToString

            Dim TrongTaiTinh As TextObject
            TrongTaiTinh = rptDocument.ReportDefinition.ReportObjects("TongTrongTai")
            TrongTaiTinh.Text = dt.Rows(0).Item("DeadWeight").ToString

            'Dim LoaiHang As TextObject
            'LoaiHang = rptDocument.ReportDefinition.ReportObjects("LoaiHang")
            'LoaiHang.Text = dt.Rows(0).Item("KindOfCargoAD").ToString

           
            Dim SoThuyenVien As TextObject
            SoThuyenVien = rptDocument.ReportDefinition.ReportObjects("SoThuyenVien")
            SoThuyenVien.Text = dt.Rows(0).Item("NumOfCrewAD").ToString

            Dim SoHanhKhach As TextObject
            SoHanhKhach = rptDocument.ReportDefinition.ReportObjects("SoHanhKhach")
            SoHanhKhach.Text = dt.Rows(0).Item("NumOfPassengersAD").ToString

            'Dim LuongDanNuocThucTe As TextObject
            'LuongDanNuocThucTe = rptDocument.ReportDefinition.ReportObjects("LuongDanNuocThucTe")
            'LuongDanNuocThucTe.Text = dt.Rows(0).Item("ActualDisplacementAD").ToString

            'Dim ThoiGianDuKienDenCang As TextObject
            'ThoiGianDuKienDenCang = rptDocument.ReportDefinition.ReportObjects("ThoiGianDuKienDenCang")
            'ThoiGianDuKienDenCang.Text = dt.Rows(0).Item("TimeOfArrivalAD").ToString

            Dim ViTriTauTrongCang As TextObject
            ViTriTauTrongCang = rptDocument.ReportDefinition.ReportObjects("ViTriTauTrongCang")
            ViTriTauTrongCang.Text = dt.Rows(0).Item("PositionOfShipInPortAD").ToString

            Dim MucDichDenCang As TextObject
            MucDichDenCang = rptDocument.ReportDefinition.ReportObjects("MucDichDenCang")
            MucDichDenCang.Text = dt.Rows(0).Item("PurposeToPortAD").ToString

            Dim ETA As TextObject
            ETA = rptDocument.ReportDefinition.ReportObjects("ETA")
            ETA.Text = dt.Rows(0).Item("TimeOfArrivalAD").ToString

            Dim Berthed As TextObject
            Berthed = rptDocument.ReportDefinition.ReportObjects("Berthed")
            Berthed.Text = dt.Rows(0).Item("TimeOfBerthAD").ToString & " - " & dt.Rows(0).Item("DateOfBerthAD").ToString

            Dim Dis_ImCargo As TextObject
            Dis_ImCargo = rptDocument.ReportDefinition.ReportObjects("Dis_ImCargo")
            Dis_ImCargo.Text = dt.Rows(0).Item("DateOfBerthAD").ToString
            'Dim port As TextObject
            'port = rptDocument.ReportDefinition.ReportObjects("port")
            'port.Text = cboTerminal.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            'Dim NoiDangKy As TextObject
            'NoiDangKy = rptDocument.ReportDefinition.ReportObjects("NoiDangKy")
            'NoiDangKy.Text = Me.cboNoiDangKy.Text
            'Phần chung
            Dim TaiLieuDinhKem As TextObject
            TaiLieuDinhKem = rptDocument.ReportDefinition.ReportObjects("TaiLieuDinhKem")
            TaiLieuDinhKem.Text = Me.txtTaiLieuDinhKem.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            Dim BngKhaiHangHoa As TextObject
            BngKhaiHangHoa = rptDocument.ReportDefinition.ReportObjects("BngKhaiHangHoa")
            BngKhaiHangHoa.Text = Me.txtBangKhaiHangHoa.Text

            Dim BangKhaiDuTruCuaTau As TextObject
            BangKhaiDuTruCuaTau = rptDocument.ReportDefinition.ReportObjects("BangKhaiDuTruCuaTau")
            BangKhaiDuTruCuaTau.Text = Me.txtBangKhaiDuTruCuaTau.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            Dim BangKhaiHanhLyThuyenVien As TextObject
            BangKhaiHanhLyThuyenVien = rptDocument.ReportDefinition.ReportObjects("txtBangKhaiHanhLyThuyenVien")
            BangKhaiHanhLyThuyenVien.Text = Me.txtBangKhaiHanhLyThuyenVien.Text

            Dim ROB As TextObject
            ROB = rptDocument.ReportDefinition.ReportObjects("ROB")
            ROB.Text = "FO: " & dt.Rows(0).Item("FOAD").ToString & "                    "
            ROB.Text &= "DO: " & dt.Rows(0).Item("DOAD").ToString & "                    "
            ROB.Text &= "FW: " & dt.Rows(0).Item("FWAD").ToString & "                    "

            Me.CrystalReportViewer1.ReportSource = rptDocument
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

            '----------------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)

        End Try
    End Sub
    Function QueryVesselInfoDeparture(ByVal ID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Vessel.*,BoardingAgent.* "
            SQL &= "from (Vessel INNER JOIN BoardingAgent On BoardingAgent.ShipCode=Vessel.Vessel_Code)"
            SQL &= "Where BoardingAgent.Continued=1 And BoardingAgentID='" & ID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub Print_RptDeparture()
        Try
            Dim rptDocument As ReportDocument

            If IsNothing(rptDocument) Then
                rptDocument = New ReportDocument
            End If
            Dim strReportName As String
            'Dim strQuery As String
            'Dim CargoMarks As TextObject
            Dim dt As New DataTable
            dt = QueryVesselInfoDeparture(VesselID)
            If dt.Rows.Count <= 0 Then
                MsgBox("No data")
                Me.Close()
                Return
            End If
            Me.CrystalReportViewer1.ReportSource = Nothing
            strReportName = "ReportDeclarationOfDeparture.rpt"

            ' ten Report--------------

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)

            Dim Check As TextObject
            Check = rptDocument.ReportDefinition.ReportObjects("CheckROI")
            Check.Text = "X"

            Dim DaiLy As TextObject
            DaiLy = rptDocument.ReportDefinition.ReportObjects("TenDiaChiDaiLy")
            DaiLy.Text = dt.Rows(0).Item("AgentName").ToString

            'Dim Ngay As TextObject
            'Ngay = rptDocument.ReportDefinition.ReportObjects("LanCuoiDenCangVN")
            'Ngay.Text = dt.Rows(0).Item("LastDateOfArrivalDD").ToString 'Me.dtpDate.Value.Day & "  Tháng  " & Me.dtpDate.Value.Month & "  Năm  " & Me.dtpDate.Value.Year

            Dim Vessel As TextObject
            Vessel = rptDocument.ReportDefinition.ReportObjects("Vessel")
            Vessel.Text = dt.Rows(0).Item("Vessel").ToString & dt.Rows(0).Item("TypeOfShip").ToString

            'Dim QuocTich As TextObject
            'QuocTich = rptDocument.ReportDefinition.ReportObjects("QuocTich")
            'QuocTich.Text = dt.Rows(0).Item("NATIONALITY").ToString

            Dim HoHieu As TextObject
            HoHieu = rptDocument.ReportDefinition.ReportObjects("HoHieu")
            HoHieu.Text = dt.Rows(0).Item("Call_Sign").ToString

            Dim SoIMO As TextObject
            SoIMO = rptDocument.ReportDefinition.ReportObjects("SoIMO")
            SoIMO.Text = dt.Rows(0).Item("IMONO").ToString()

            Dim TenThuyenTruong As TextObject
            TenThuyenTruong = rptDocument.ReportDefinition.ReportObjects("TenThuyenTruong")
            TenThuyenTruong.Text = dt.Rows(0).Item("CaptionNameDD").ToString
            'Dim DuKienDenCang As TextObject
            'DuKienDenCang = rptDocument.ReportDefinition.ReportObjects("ThoiGianDuKienDenCang")
            'DuKienDenCang.Text = Me.dtpKeTuNgay.Value.Date 'Me.dtpKeTuNgay.Value.Day & "  Tháng  " & Me.dtpKeTuNgay.Value.Month & "  Năm  " & Me.dtpKeTuNgay.Value.Year

            Dim CangTruoc As TextObject
            CangTruoc = rptDocument.ReportDefinition.ReportObjects("CangTruoc")
            CangTruoc.Text = dt.Rows(0).Item("PreviousPortDD").ToString()

            Dim CangGiua As TextObject
            CangGiua = rptDocument.ReportDefinition.ReportObjects("CangGiua")
            CangGiua.Text = dt.Rows(0).Item("Dis_LoadPortDD").ToString()

            Dim Cangke As TextObject
            Cangke = rptDocument.ReportDefinition.ReportObjects("CangCuoi")
            Cangke.Text = dt.Rows(0).Item("NextPortDD").ToString()

            Dim ChuTau As TextObject
            ChuTau = rptDocument.ReportDefinition.ReportObjects("TenDiaChiChuTau")
            ChuTau.Text = dt.Rows(0).Item("ShipOwner").ToString & "&" & dt.Rows(0).Item("Address").ToString

            'Dim Address As TextObject
            'Address = rptDocument.ReportDefinition.ReportObjects("DiaChi")
            'Address.Text = dt.Rows(0).Item("Address").ToString

            'Dim LoaiTau As TextObject
            'LoaiTau = rptDocument.ReportDefinition.ReportObjects("LoaiTau")
            'LoaiTau.Text = dt.Rows(0).Item("TypeOfShip").ToString

            'Dim CongSuatmay As TextObject
            'CongSuatmay = rptDocument.ReportDefinition.ReportObjects("CongSuatmay")
            'CongSuatmay.Text = dt.Rows(0).Item("PowerOfEngine").ToString


            'Dim ChieuCaotinhKhong As TextObject
            'ChieuCaotinhKhong = rptDocument.ReportDefinition.ReportObjects("ChieuCaotinhKhong")
            'ChieuCaotinhKhong.Text = dt.Rows(0).Item("AirDraft").ToString


            Dim ChieuDaiToiDa As TextObject
            ChieuDaiToiDa = rptDocument.ReportDefinition.ReportObjects("ChieuDai")
            ChieuDaiToiDa.Text = dt.Rows(0).Item("LengthOver").ToString


            Dim ChieuRong As TextObject
            ChieuRong = rptDocument.ReportDefinition.ReportObjects("ChieuRong")
            ChieuRong.Text = dt.Rows(0).Item("Breath").ToString

            'Dim TocDo As TextObject
            'TocDo = rptDocument.ReportDefinition.ReportObjects("TocDo")
            'TocDo.Text = dt.Rows(0).Item("Speed").ToString

            Dim MonNuocKhiDen As TextObject
            MonNuocKhiDen = rptDocument.ReportDefinition.ReportObjects("MonNuocMuiTau")
            MonNuocKhiDen.Text = dt.Rows(0).Item("foreDraftDD").ToString & "/" & dt.Rows(0).Item("AfterDraftDD").ToString

            'Dim Lai As TextObject
            'Lai = rptDocument.ReportDefinition.ReportObjects("Lai")
            'Lai.Text = dt.Rows(0).Item("AfterDraftDD").ToString

            Dim DungTichToanPhan As TextObject
            DungTichToanPhan = rptDocument.ReportDefinition.ReportObjects("TongDungTich")
            DungTichToanPhan.Text = dt.Rows(0).Item("GrossTonnage").ToString


            Dim DungTichCoIch As TextObject
            DungTichCoIch = rptDocument.ReportDefinition.ReportObjects("DungTichCoIch")
            DungTichCoIch.Text = dt.Rows(0).Item("NetTonnage").ToString

            Dim TrongTaiTinh As TextObject
            TrongTaiTinh = rptDocument.ReportDefinition.ReportObjects("TongTrongTai")
            TrongTaiTinh.Text = dt.Rows(0).Item("DeadWeight").ToString

            'Dim LoaiHang As TextObject
            'LoaiHang = rptDocument.ReportDefinition.ReportObjects("LoaiHang")
            'LoaiHang.Text = dt.Rows(0).Item("KindOfCargoDD").ToString

            'Dim SoLuong As TextObject
            'SoLuong = rptDocument.ReportDefinition.ReportObjects("SoLuong")
            'SoLuong.Text = Me.txtSoLuong.Text

            Dim SoThuyenVien As TextObject
            SoThuyenVien = rptDocument.ReportDefinition.ReportObjects("SoThuyenVien")
            SoThuyenVien.Text = dt.Rows(0).Item("NumOfCrewDD").ToString

            Dim SoHanhKhach As TextObject
            SoHanhKhach = rptDocument.ReportDefinition.ReportObjects("SoHanhKhach")
            SoHanhKhach.Text = dt.Rows(0).Item("NumOfPassengersDD").ToString

            'Dim LuongDanNuocThucTe As TextObject
            'LuongDanNuocThucTe = rptDocument.ReportDefinition.ReportObjects("LuongDanNuocThucTe")
            'LuongDanNuocThucTe.Text = dt.Rows(0).Item("ActualDisplacementDD").ToString

            'Dim ThoiGianDuKienDenCang As TextObject
            'ThoiGianDuKienDenCang = rptDocument.ReportDefinition.ReportObjects("ThoiGianDuKienDenCang")
            'ThoiGianDuKienDenCang.Text = dt.Rows(0).Item("TimeOfArrivalDD").ToString

            Dim ViTriTauTrongCang As TextObject
            ViTriTauTrongCang = rptDocument.ReportDefinition.ReportObjects("ViTriTauTrongCang")
            ViTriTauTrongCang.Text = dt.Rows(0).Item("PositionOfShipInPortDD").ToString

            Dim MucDichDenCang As TextObject
            MucDichDenCang = rptDocument.ReportDefinition.ReportObjects("MucDichDenCang")
            MucDichDenCang.Text = dt.Rows(0).Item("PurposeToPortDD").ToString

            'Dim ETA As TextObject
            'ETA = rptDocument.ReportDefinition.ReportObjects("ETA")
            'ETA.Text = dt.Rows(0).Item("TimeOfArrivalDD").ToString

            Dim Berthed As TextObject
            Berthed = rptDocument.ReportDefinition.ReportObjects("Berthed")
            Berthed.Text = dt.Rows(0).Item("TimeOfBerthDD").ToString & " - " & dt.Rows(0).Item("DateOfBerthDD").ToString

            Dim Dis_ImCargo As TextObject
            Dis_ImCargo = rptDocument.ReportDefinition.ReportObjects("Dis_ImCargo")
            Dis_ImCargo.Text = dt.Rows(0).Item("DateOfBerthDD").ToString
            'Dim port As TextObject
            'port = rptDocument.ReportDefinition.ReportObjects("port")
            'port.Text = cboTerminal.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            'Dim NoiDangKy As TextObject
            'NoiDangKy = rptDocument.ReportDefinition.ReportObjects("NoiDangKy")
            'NoiDangKy.Text = Me.cboNoiDangKy.Text

            Dim TaiLieuDinhKem As TextObject
            TaiLieuDinhKem = rptDocument.ReportDefinition.ReportObjects("TaiLieuDinhKem")
            TaiLieuDinhKem.Text = Me.txtTaiLieuDinhKem.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            Dim BngKhaiHangHoa As TextObject
            BngKhaiHangHoa = rptDocument.ReportDefinition.ReportObjects("BngKhaiHangHoa")
            BngKhaiHangHoa.Text = Me.txtBangKhaiHangHoa.Text

            Dim BangKhaiDuTruCuaTau As TextObject
            BangKhaiDuTruCuaTau = rptDocument.ReportDefinition.ReportObjects("BangKhaiDuTruCuaTau")
            BangKhaiDuTruCuaTau.Text = Me.txtBangKhaiDuTruCuaTau.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            Dim BangKhaiHanhLyThuyenVien As TextObject
            BangKhaiHanhLyThuyenVien = rptDocument.ReportDefinition.ReportObjects("txtBangKhaiHanhLyThuyenVien")
            BangKhaiHanhLyThuyenVien.Text = Me.txtBangKhaiHanhLyThuyenVien.Text

            Dim ROB As TextObject
            ROB = rptDocument.ReportDefinition.ReportObjects("ROB")
            ROB.Text = "FO: " & dt.Rows(0).Item("FODD").ToString & "                    "
            ROB.Text &= "DO: " & dt.Rows(0).Item("DODD").ToString & "                    "
            ROB.Text &= "FW: " & dt.Rows(0).Item("FWDD").ToString & "                    "

            Me.CrystalReportViewer1.ReportSource = rptDocument
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

            '----------------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)

        End Try
    End Sub
    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        If Me.chkArrival.Checked = True Then
            print_Rpt()
        Else
            Print_RptDeparture()
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.grpComfirmInfo.Visible = False
    End Sub

    Private Sub cmdUpdateInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInfo.Click
        Me.grpComfirmInfo.Visible = True
    End Sub

    Private Sub grpComfirmInfo_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpComfirmInfo.Enter

    End Sub
End Class