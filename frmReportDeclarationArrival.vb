Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmReportDeclarationArrival
    Public mTerminalID As String
    Private Sub frmReportDeclarationArrival_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Dim rpt As New 
            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            strReportName = "ReportDeclarationArrival"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------
            rpt.PrintOptions.PaperSize = PaperSize.PaperA4

            Dim strSql As String = "Select * From TerminalDeparture where TerminalDeparture_ID='" & mTerminalID & "'"
            Dim tbl As New DataTable
            tbl = ReadTable(strSql)
            If tbl.Rows.Count = 0 Then
                Me.Close()
                Return
            End If

            strSql = "Select * From Vessel Where Vessel_ID='" & tbl.Rows(0).Item("Vessel_ID").ToString & "' and continued=1"
            Dim tbl1 As DataTable
            tbl1 = ReadTable(strSql)
            If tbl1.Rows.Count = 0 Then
                Me.Close()
                Return
            End If


            Dim Tentau As TextObject
            Dim CangDen As TextObject
            Dim ThoiGianDen As TextObject
            Dim CangRoi As TextObject
            Dim ThuyenTruong As TextObject
            Dim QuocTich As TextObject
            Dim HoHieu As TextObject
            Dim ChuTau As TextObject

            Dim ChieuDai As TextObject
            Dim ChieuRong As TextObject
            Dim MonNuoc As TextObject

            Dim DungTich As TextObject
            Dim DungTichIch As TextObject
            Dim TrongTai As TextObject
            Dim DacDiem As TextObject
            Dim SoLuong1 As TextObject
            Dim SoLuong2 As TextObject
            Dim ThuyenVien As TextObject
            Dim hanhKhach As TextObject
            Dim ViTri As TextObject

            Dim MucDich As TextObject
            Dim Yeucau As TextObject
            Dim TenDaiLy As TextObject
            Dim Ma As TextObject
            Dim ghiChu As TextObject

            '---------
            Tentau = rpt.ReportDefinition.ReportObjects("TenTau")
            Tentau.Text = tbl1.Rows(0).Item("Vessel")

            QuocTich = rpt.ReportDefinition.ReportObjects("QuocTich")
            QuocTich.Text = tbl1.Rows(0).Item("NATIONALITY")

            HoHieu = rpt.ReportDefinition.ReportObjects("HoHieu")
            HoHieu.Text = tbl1.Rows(0).Item("Call_Sign")

            ChuTau = rpt.ReportDefinition.ReportObjects("ChuTau")
            ChuTau.Text = tbl1.Rows(0).Item("ShipOwner")

            ChieuDai = rpt.ReportDefinition.ReportObjects("ChieuDai")
            ChieuDai.Text = tbl1.Rows(0).Item("LengthOver")

            ChieuRong = rpt.ReportDefinition.ReportObjects("ChieuRong")
            ChieuRong.Text = tbl1.Rows(0).Item("Breath")

            DungTichIch = rpt.ReportDefinition.ReportObjects("DungTichIch")
            DungTichIch.Text = tbl1.Rows(0).Item("NetTonnage")

            DungTich = rpt.ReportDefinition.ReportObjects("DungTich")
            DungTich.Text = tbl1.Rows(0).Item("GrossTonnage")

            TrongTai = rpt.ReportDefinition.ReportObjects("TrongTai")
            TrongTai.Text = tbl1.Rows(0).Item("DeadWeight")

            '---------
            MonNuoc = rpt.ReportDefinition.ReportObjects("MonNuoc")
            MonNuoc.Text = tbl.Rows(0).Item("Fore") & " / " & tbl.Rows(0).Item("After")

            CangDen = rpt.ReportDefinition.ReportObjects("CangDen")
            CangDen.Text = tbl.Rows(0).Item("PortOfArrival")

            ThoiGianDen = rpt.ReportDefinition.ReportObjects("ThoiGianDen")
            ThoiGianDen.Text = tbl.Rows(0).Item("DateArrival")

            CangRoi = rpt.ReportDefinition.ReportObjects("CangRoi")
            CangRoi.Text = tbl.Rows(0).Item("PortArrivedFrom")

            ThuyenTruong = rpt.ReportDefinition.ReportObjects("ThuyenTruong")
            ThuyenTruong.Text = tbl.Rows(0).Item("MasterName")

            DacDiem = rpt.ReportDefinition.ReportObjects("DacDiem")
            DacDiem.Text = tbl.Rows(0).Item("BreifParticular")

            SoLuong1 = rpt.ReportDefinition.ReportObjects("SoLuong2")
            SoLuong1.Text = tbl.Rows(0).Item("QuantityDanger")

            SoLuong2 = rpt.ReportDefinition.ReportObjects("SoLuong1")
            Dim Temp(), Result As String

            Result = tbl.Rows(0).Item("QuantityCargo").ToString
            Temp = Strings.Split(Result, Chr(13))
            Result = ""


            For j As Integer = 0 To Temp.Length - 1

                SoLuong2.Text &= Temp(j) & " - "
            Next

            ThuyenVien = rpt.ReportDefinition.ReportObjects("ThuyenVien")
            ThuyenVien.Text = tbl.Rows(0).Item("NumCrew")

            hanhKhach = rpt.ReportDefinition.ReportObjects("hanhKhach")
            hanhKhach.Text = tbl.Rows(0).Item("NumPassenger")


            MucDich = rpt.ReportDefinition.ReportObjects("MucDich")
            Result = tbl.Rows(0).Item("PurposePort")
            Temp = Strings.Split(Result, Chr(13))
            Result = ""
            For j As Integer = 0 To Temp.Length - 1
                Result &= Temp(j)
                If Temp(j).Trim.Length > 0 Then
                    For k As Integer = Temp(j).Length To MucDich.Width \ 10
                        Result &= " "
                    Next
                End If
            Next
            MucDich.Text = Result

            TenDaiLy = rpt.ReportDefinition.ReportObjects("DaiLy")
            TenDaiLy.Text = tbl.Rows(0).Item("AgencyName")

            Yeucau = rpt.ReportDefinition.ReportObjects("YeuCau")
            Result = tbl.Rows(0).Item("OtherConcer")
            Temp = Strings.Split(Result, Chr(13))
            Result = ""
            For j As Integer = 0 To Temp.Length - 1
                Result &= Temp(j)
                If Temp(j).Trim.Length > 0 Then
                    For k As Integer = Temp(j).Length To Yeucau.Width \ 10
                        Result &= " "
                    Next
                End If
            Next
            Yeucau.Text = Result

            ghiChu = rpt.ReportDefinition.ReportObjects("GhiChu")
            Result = tbl.Rows(0).Item("Remarks")
            Temp = Strings.Split(Result, Chr(13))
            Result = ""
            For j As Integer = 0 To Temp.Length - 1

                Result &= Temp(j)
                If Temp(j).Trim.Length > 0 Then
                    For k As Integer = Temp(j).Length To ghiChu.Width \ 10
                        Result &= " "
                    Next
                End If


            Next
            ghiChu.Text = Result

            ViTri = rpt.ReportDefinition.ReportObjects("Vitri")
            ViTri.Text = tbl.Rows(0).Item("PosPort")

            Ma = rpt.ReportDefinition.ReportObjects("Code")
            Ma.Text = tbl.Rows(0).Item("Code")

            Me.rptDeclaration.ReportSource = rpt
            Me.rptDeclaration.Show()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class