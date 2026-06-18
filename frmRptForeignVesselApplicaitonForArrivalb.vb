Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptForeignVesselApplicaitonForArrivalb

    Public VesselID As String
    Function QueryVesselInfo(ByVal ID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Vessel.*,KindOfCargoAD,NumOfCrewAD,NumOfPassengersAD,ActualDisplacementAD,TimeOfArrivalAD,LengthOver,Breath,PurposeToPortAD,AgentName,AfterDraftAD,foreDraftAD,PreviousPortAD,LastDateOfArrivalAD,NextPortAD,DateOfArrivalPilotStationAD,TimeOfArrivalPilotStationAD,DateOfArrivalPilotOnboardAD,TimeOfArrivalPilotOnboardAD,FCNTRAD,FTEUAD,FTONSAD "
            SQL &= "from (Vessel LEFT JOIN BoardingAgent On BoardingAgent.ShipCode=Vessel.Vessel_Code )"
            SQL &= "Where BoardingAgent.Continued=1  And BoardingAgentID='" & ID & "'"
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

            'VesselID = "44CE47F6-C819-4385-8511-6441551455D5"
            Dim dt As New DataTable
            dt = QueryVesselInfo(VesselID)
            If dt.Rows.Count <= 0 Then
                MsgBox("No data")
                Me.Close()
                Return
            End If
            Me.CrystalReportViewer1.ReportSource = Nothing
            strReportName = "ReportForeignVesselApplicationForArrival.rpt"

            ' ten Report--------------

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)
            Dim DaiLy As TextObject
            DaiLy = rptDocument.ReportDefinition.ReportObjects("TenDaiLyChuTau")
            DaiLy.Text = dt.Rows(0).Item("AgentName").ToString

            Dim Ngay As TextObject
            Ngay = rptDocument.ReportDefinition.ReportObjects("LanCuoiDenCangVN")
            Ngay.Text = dt.Rows(0).Item("LastDateOfArrivalAD").ToString 'Me.dtpDate.Value.Day & "  Tháng  " & Me.dtpDate.Value.Month & "  Năm  " & Me.dtpDate.Value.Year

            Dim Vessel As TextObject
            Vessel = rptDocument.ReportDefinition.ReportObjects("Tentau")
            Vessel.Text = dt.Rows(0).Item("Vessel").ToString

            Dim QuocTich As TextObject
            QuocTich = rptDocument.ReportDefinition.ReportObjects("QuocTich")
            QuocTich.Text = dt.Rows(0).Item("NATIONALITY").ToString

            Dim HoHieu As TextObject
            HoHieu = rptDocument.ReportDefinition.ReportObjects("HoHieu")
            HoHieu.Text = dt.Rows(0).Item("Call_Sign").ToString

            Dim De As TextObject
            De = rptDocument.ReportDefinition.ReportObjects("MucDichDenCang")
            De.Text = dt.Rows(0).Item("PurposeToPortAD").ToString

            'Dim DuKienDenCang As TextObject
            'DuKienDenCang = rptDocument.ReportDefinition.ReportObjects("ThoiGianDuKienDenCang")
            'DuKienDenCang.Text = Me.dtpKeTuNgay.Value.Date 'Me.dtpKeTuNgay.Value.Day & "  Tháng  " & Me.dtpKeTuNgay.Value.Month & "  Năm  " & Me.dtpKeTuNgay.Value.Year

            Dim FromPort As TextObject
            FromPort = rptDocument.ReportDefinition.ReportObjects("TauDenTuCang")
            FromPort.Text = dt.Rows(0).Item("PreviousPortAD").ToString 'Me.txtTauDenTuCang.Text 'dt.Rows(0).Item("Vessel").ToString

            Dim ChuTau As TextObject
            ChuTau = rptDocument.ReportDefinition.ReportObjects("ChuTau")
            ChuTau.Text = dt.Rows(0).Item("ShipOwner").ToString

            Dim Address As TextObject
            Address = rptDocument.ReportDefinition.ReportObjects("DiaChi")
            Address.Text = dt.Rows(0).Item("Address").ToString

            Dim LoaiTau As TextObject
            LoaiTau = rptDocument.ReportDefinition.ReportObjects("LoaiTau")
            LoaiTau.Text = dt.Rows(0).Item("TypeOfShip").ToString

            Dim CongSuatmay As TextObject
            CongSuatmay = rptDocument.ReportDefinition.ReportObjects("CongSuatmay")
            CongSuatmay.Text = dt.Rows(0).Item("PowerOfEngine").ToString


            Dim ChieuCaotinhKhong As TextObject
            ChieuCaotinhKhong = rptDocument.ReportDefinition.ReportObjects("ChieuCaotinhKhong")
            ChieuCaotinhKhong.Text = dt.Rows(0).Item("AirDraft").ToString


            Dim ChieuDaiToiDa As TextObject
            ChieuDaiToiDa = rptDocument.ReportDefinition.ReportObjects("ChieuDaiToiDa")
            ChieuDaiToiDa.Text = dt.Rows(0).Item("LengthOver").ToString


            Dim ChieuRong As TextObject
            ChieuRong = rptDocument.ReportDefinition.ReportObjects("ChieuRong")
            ChieuRong.Text = dt.Rows(0).Item("Breath").ToString

            Dim TocDo As TextObject
            TocDo = rptDocument.ReportDefinition.ReportObjects("VanToc")
            TocDo.Text = dt.Rows(0).Item("Speed").ToString

            'Dim MonNuocKhiDen As TextObject
            'MonNuocKhiDen = rptDocument.ReportDefinition.ReportObjects("MonNuocKhiDen")
            'MonNuocKhiDen.Text = dt.Rows(0).Item("DRAFT").ToString

            'Dim Lai As TextObject
            'Lai = rptDocument.ReportDefinition.ReportObjects("Lai")
            'Lai.Text = dt.Rows(0).Item("DRAFT").ToString

            Dim DungTichToanPhan As TextObject
            DungTichToanPhan = rptDocument.ReportDefinition.ReportObjects("DungTichToanPhan")
            DungTichToanPhan.Text = dt.Rows(0).Item("GrossTonnage").ToString

            Dim TrongTaiTinh As TextObject
            TrongTaiTinh = rptDocument.ReportDefinition.ReportObjects("TrongTaiTinh")
            TrongTaiTinh.Text = dt.Rows(0).Item("DeadWeight").ToString

            Dim LoaiHang As TextObject
            LoaiHang = rptDocument.ReportDefinition.ReportObjects("LoaiHang")
            LoaiHang.Text = dt.Rows(0).Item("KindOfCargoAD").ToString

            Dim MonNuocKhiDen As TextObject
            MonNuocKhiDen = rptDocument.ReportDefinition.ReportObjects("MonNuocKhiDen")
            MonNuocKhiDen.Text = dt.Rows(0).Item("foreDraftAD").ToString & "/" & dt.Rows(0).Item("AfterDraftAD").ToString

            'Dim LAI As TextObject
            'LAI = rptDocument.ReportDefinition.ReportObjects("LAI")
            'LAI.Text = dt.Rows(0).Item("AfterDraftAD").ToString

            Dim SoThuyenVien As TextObject
            SoThuyenVien = rptDocument.ReportDefinition.ReportObjects("SoThuyenVien")
            SoThuyenVien.Text = dt.Rows(0).Item("NumOfCrewAD").ToString

            Dim SoHanhKhach As TextObject
            SoHanhKhach = rptDocument.ReportDefinition.ReportObjects("SoHanhKhach")
            SoHanhKhach.Text = dt.Rows(0).Item("NumOfPassengersAD").ToString

            Dim LuongDanNuocThucTe As TextObject
            LuongDanNuocThucTe = rptDocument.ReportDefinition.ReportObjects("LuongDanNuocThucTe")
            LuongDanNuocThucTe.Text = dt.Rows(0).Item("ActualDisplacementAD").ToString

            Dim ThoiGianDuKienDenCang As TextObject
            ThoiGianDuKienDenCang = rptDocument.ReportDefinition.ReportObjects("ThoiGianDuKienDenCang")
            ThoiGianDuKienDenCang.Text = "Ngày " & dt.Rows(0).Item("DateOfArrivalPilotStationAD").ToString

            Dim DuKienRoi As TextObject
            DuKienRoi = rptDocument.ReportDefinition.ReportObjects("DuKienRoi")
            DuKienRoi.Text = "Ngày " & dt.Rows(0).Item("DateOfArrivalPilotOnboardAD").ToString

            Dim MucDichDenCang As TextObject
            MucDichDenCang = rptDocument.ReportDefinition.ReportObjects("MucDichDenCang")
            MucDichDenCang.Text = dt.Rows(0).Item("PurposeToPortAD").ToString

            Dim CangKeTiep As TextObject
            CangKeTiep = rptDocument.ReportDefinition.ReportObjects("CangKeTiep")
            CangKeTiep.Text = dt.Rows(0).Item("NextPortAD").ToString
            'FCNTRAD,FTEUAD,FTONSAD
            Dim HangQuaCang As TextObject
            HangQuaCang = rptDocument.ReportDefinition.ReportObjects("HangQuaCang")
            HangQuaCang.Text = dt.Rows(0).Item("FCNTRAD").ToString & "cntrs/" & dt.Rows(0).Item("FTEUAD").ToString & "teus/" & dt.Rows(0).Item("FTONSAD").ToString & "mt"

            Dim port As TextObject
            port = rptDocument.ReportDefinition.ReportObjects("port")
            port.Text = Me.cboTerminal.Text 'dt.Rows(0).Item("PurposeToPortAD").ToString
            Dim NoiDangKy As TextObject
            NoiDangKy = rptDocument.ReportDefinition.ReportObjects("NoiDangKy")
            NoiDangKy.Text = dt.Rows(0).Item("PortOfRegister").ToString

            Dim NgayLam As TextObject
            NgayLam = rptDocument.ReportDefinition.ReportObjects("Ngay")
            NgayLam.Text = Now.Day

            Dim Thang As TextObject
            Thang = rptDocument.ReportDefinition.ReportObjects("Thang")
            Thang.Text = Now.Month

            Dim Nam As TextObject
            Nam = rptDocument.ReportDefinition.ReportObjects("Nam")
            Nam.Text = Now.Year

            Me.CrystalReportViewer1.ReportSource = rptDocument
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

            '----------------------------
        Catch ex As Exception
            DisplayMessage(True, Err.Description)

        End Try
    End Sub
    Private Sub frmRptForeignVesselApplicaitonForArrivalb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryICD(Me.cboTerminal)
        Me.grpComfirmInfo.Visible = True
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        print_Rpt()
        Me.grpComfirmInfo.Visible = False
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.grpComfirmInfo.Visible = False
    End Sub

    Private Sub cmdUpdateInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdateInfo.Click
        Me.grpComfirmInfo.Visible = True
    End Sub
End Class