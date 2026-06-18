Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptDataSupplyContainerNotify

    Sub QueryBooking(ByRef oTable As DataTable)
        On Error GoTo Err
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        Dim strQuery As String = "Select * from (ContainerOutboundNotify inner join CUSTOMER On CUSTOMER.CUSTOMER_ID=ContainerOutboundNotify.Customer_ID)  Where ContainerOutboundNotifyID='" & gBookingID & "' And ContainerOutboundNotify.Continued=1"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTable) Then
            oTable.Clear()
        End If
        Adapter.Fill(ds, "Booking")
        oTable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err:

    End Sub

    Function ReplaceDate(ByVal s As String) As String
        Dim Temp As String
        Try
            If IsNothing(s) Then
                Return s
            End If
            Temp = ""
            Temp = Strings.Replace(s, "12:00:00 AM", "")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Return Temp
    End Function

    Function PortName(ByVal S As String) As String
        Dim Temp As String
        Try
            If IsNothing(S) Then
                Return S
            End If
            Temp = ""
            Temp = Strings.Left(S, S.Trim.Length - 6)
            Temp = Strings.Replace(Temp, "-", "")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        Return Temp
    End Function

    Sub QueryVessel(ByRef oTable As DataTable)
        On Error GoTo Err
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        Dim strQuery As String = "Select  Vessel.Vessel +'  V.'+ Voyno as Vessel,ETD  "
        strQuery &= " from ((ContainerOutboundNotify inner join SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID) "
        strQuery &= " Inner Join Vessel on Vessel.Vessel_ID=SailingSchedule.Vessel_ID ) "
        strQuery &= " Where ContainerOutboundNotify.ContainerOutboundNotifyID='" & gBookingID & "' And ContainerOutboundNotify.Continued=1"
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTable) Then
            oTable.Clear()
        End If
        Adapter.Fill(ds, "Booking")
        oTable = ds.Tables(0)

        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err:
    End Sub

    Private Sub frmRptDataSupplyConatinerNotify_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        Me.Hide()

        Dim dt As New DataTable
        '--------------- 
        Dim rpt As New ReportDocument
        Dim strReportName As String
        Dim strQuery As String
        ' ten Report
        strReportName = "ReportDataTBcapContainer"
        Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        If Not IO.File.Exists(strReportPath) Then
            DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            Exit Sub
        End If
        rpt.Load(strReportPath)
        '------------

        QueryBooking(dt)
        If dt.Rows.Count > 0 Then
            Dim BookingNo, Company, NguoiDaiDien, MWMP, MWL, ContactUs, DiaChi, Tel, Fax, GP20, GP40, HC40, HC45, RF20, RF40, RH40, Special, soluongcontloai As TextObject

            BookingNo = rpt.ReportDefinition.ReportObjects("BookingNO")
            BookingNo.Text = dt.Rows(0).Item("BookingNo").ToString

            Company = rpt.ReportDefinition.ReportObjects("Company")
            Company.Text = dt.Rows(0).Item("Company").ToString & " - " & dt.Rows(0).Item("Representative").ToString

            NguoiDaiDien = rpt.ReportDefinition.ReportObjects("DaiDien")
            NguoiDaiDien.Text = dt.Rows(0).Item("TRUCKCOMPANY").ToString

            DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
            DiaChi.Text = dt.Rows(0).Item("Address").ToString

            Tel = rpt.ReportDefinition.ReportObjects("Tel")
            Tel.Text = dt.Rows(0).Item("Tel").ToString

            Fax = rpt.ReportDefinition.ReportObjects("Fax")
            Fax.Text = dt.Rows(0).Item("Fax").ToString

            Dim sl As String = ""

            sl = IIf(dt.Rows(0).Item("SoLuong20GP").ToString = "0", "", dt.Rows(0).Item("SoLuong20GP").ToString + " x 20GP; ")


            sl += IIf(dt.Rows(0).Item("SoLuong40GP").ToString = "0", "", dt.Rows(0).Item("SoLuong40GP").ToString + " x 40GP; ")


            sl += IIf(dt.Rows(0).Item("SoLuong40HC").ToString = "0", "", dt.Rows(0).Item("SoLuong40HC").ToString + " x 40HC; ")


            sl += IIf(dt.Rows(0).Item("SoLuong45HC").ToString = "0", "", dt.Rows(0).Item("SoLuong45HC").ToString + " x 45HC; ")


            sl += IIf(dt.Rows(0).Item("SoLuong20RF").ToString = "0", "", dt.Rows(0).Item("SoLuong20RF").ToString + " x 20RF; ")


            sl += IIf(dt.Rows(0).Item("SoLuong40RF").ToString = "0", "", dt.Rows(0).Item("SoLuong40RF").ToString + " x 40RF; ")


            sl += IIf(dt.Rows(0).Item("SoLuong40RH").ToString = "0", "", dt.Rows(0).Item("SoLuong40RH").ToString + " x 40RH; ")

            sl += IIf(dt.Rows(0).Item("SoLuong20OT").ToString = "0", "", dt.Rows(0).Item("SoLuong20OT").ToString + " x 20OT; ")


            sl += IIf(dt.Rows(0).Item("SoLuong40OT").ToString = "0", "", dt.Rows(0).Item("SoLuong40OT").ToString + " x 40OT; ")



            sl += IIf(dt.Rows(0).Item("SoLuong20FR").ToString = "0", "", dt.Rows(0).Item("SoLuong20FR").ToString + " x 20FR; ")


            sl += IIf(dt.Rows(0).Item("SoLuong40FR").ToString = "0", "", dt.Rows(0).Item("SoLuong40FR").ToString + " x 40FR; ")



            soluongcontloai = rpt.ReportDefinition.ReportObjects("SoLuongContLoai")
            soluongcontloai.Text = "Số lượng/Loại cont : " + sl.Remove(sl.Length - 2, 1)


            Dim TitleSend, DateSend, NhietDoLanh, NoiLayContainer, PhuongAn, ThongGio, YeuCauHaRong, ThoiHanHaBai, ChuyenTai As TextObject


            NhietDoLanh = rpt.ReportDefinition.ReportObjects("NhietDo")
            NhietDoLanh.Text = dt.Rows(0).Item("Cold").ToString

            ThongGio = rpt.ReportDefinition.ReportObjects("ThongGio")
            ThongGio.Text = dt.Rows(0).Item("Ventilation").ToString

            NoiLayContainer = rpt.ReportDefinition.ReportObjects("NoiLayContainer")
            Dim MTPort As String
            MTPort = dt.Rows(0).Item("EmptyContainerPlace").ToString.Trim

            Dim PortKhongDau() As String = {"CAT LAI", "VINATRANS", "NEW PORT", "PHUC LONG", "PHUOC LONG"}
            Dim PortCoDau() As String = {"CÁT LÁI", "VINATRANS", "NEW PORT", "PHÚC LONG", "PHƯỚC LONG"}
            For i As Integer = 0 To PortKhongDau.Length - 1
                If UCase(MTPort) = UCase(PortKhongDau(i)) Then
                    MTPort = PortCoDau(i)
                End If
            Next
            NoiLayContainer.Text = MTPort & " - NGÀY CẤP: " & ReplaceDate(dt.Rows(0).Item("ngaycapcont").ToString)

            PhuongAn = rpt.ReportDefinition.ReportObjects("PhuongAn")
            PhuongAn.Text = dt.Rows(0).Item("PackingWay").ToString

            Dim SCNO As TextObject
            SCNO = rpt.ReportDefinition.ReportObjects("SCNO")
            If dt.Rows(0).Item("ServiceContract").ToString <> "" Then
                SCNO.Text = "S/C: " & dt.Rows(0).Item("ServiceContract").ToString
            End If

            Dim Commondity As TextObject
            Commondity = rpt.ReportDefinition.ReportObjects("Commondity")
            If dt.Rows(0).Item("Commondity").ToString <> "" Then
                SCNO.Text += "     Commodity :" & dt.Rows(0).Item("Commondity").ToString
            End If

            YeuCauHaRong = rpt.ReportDefinition.ReportObjects("YeuCauHaRong")
            YeuCauHaRong.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

            Dim NoiHaBai As TextObject
            NoiHaBai = rpt.ReportDefinition.ReportObjects("NoiHaBai")
            NoiHaBai.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

            '-----------
            ThoiHanHaBai = rpt.ReportDefinition.ReportObjects("ThoiHanHaBai")
            Dim TempTHHB(), ResultTHHB, TEMP, TEMP1 As String
            If dt.Rows(0).Item("DateClosing1").ToString = "" Then
                TEMP = ""
            Else
                TEMP = ReplaceDate(dt.Rows(0).Item("DateClosing1").ToString)
            End If
            If dt.Rows(0).Item("DateClosing2").ToString = "" Then
                TEMP1 = ""
            Else
                TEMP1 = ReplaceDate(dt.Rows(0).Item("DateClosing2").ToString)
            End If

            ResultTHHB = "TRƯỚC " & dt.Rows(0).Item("Gio1").ToString.Trim & "H " & dt.Rows(0).Item("AMPM1").ToString.Trim & " CỦA NGÀY " & TEMP & " ĐỐI VỚI CONT 20F" & Chr(13)
            ResultTHHB &= "TRƯỚC " & dt.Rows(0).Item("Gio2").ToString.Trim & "H " & dt.Rows(0).Item("AMPM2").ToString.Trim & " CỦA NGÀY " & TEMP1 & " ĐỐI VỚI CONT 40F"
            TempTHHB = Strings.Split(ResultTHHB, Chr(13))
            ResultTHHB = ""
            For j As Integer = 0 To TempTHHB.Length - 1
                ResultTHHB &= TempTHHB(j)
                For k As Integer = TempTHHB(j).Length To ThoiHanHaBai.Width \ 10
                    ResultTHHB &= " "
                Next
            Next
            ThoiHanHaBai.Text = ResultTHHB
            '---------------
            Dim TXTTHOIHANCUOIBD As TextObject
            TXTTHOIHANCUOIBD = rpt.ReportDefinition.ReportObjects("txtBillDetail")
            TXTTHOIHANCUOIBD.Text = dt.Rows(0).Item("GioBD").ToString & " " & dt.Rows(0).Item("AMPMBD").ToString & "  Ngày: " & ReplaceDate(dt.Rows(0).Item("BD").ToString)
            '----------------
            ChuyenTai = rpt.ReportDefinition.ReportObjects("ChuyenTai")
            ChuyenTai.Text = PortName(dt.Rows(0).Item("Tranship").ToString)

            Dim CangDoHang, DichCuoiCung, Remarks, NgayLam, NguoiGui As TextObject

            CangDoHang = rpt.ReportDefinition.ReportObjects("CangDoHang")
            CangDoHang.Text = PortName(dt.Rows(0).Item("PortOfUnLoading").ToString)

            DichCuoiCung = rpt.ReportDefinition.ReportObjects("DichCuoiCung")
            DichCuoiCung.Text = PortName(dt.Rows(0).Item("Destination").ToString)
            '-------------
            Dim TempPrei(), ResultrEMARKS As String
            Remarks = rpt.ReportDefinition.ReportObjects("Remarks")
            'Remarks.Text = dt.Rows(0).Item("Remarks").ToString

            ResultrEMARKS = dt.Rows(0).Item("Remarks").ToString
            'ResultPrei = Me.oTableBillOfLading.Rows(0).Item("PreightCharges").ToString
            TempPrei = Strings.Split(ResultrEMARKS, Chr(13))
            ResultrEMARKS = ""

            For j As Integer = 0 To TempPrei.Length - 1

                ResultrEMARKS &= TempPrei(j)
                For k As Integer = TempPrei(j).Length To Remarks.Width \ 10
                    ResultrEMARKS &= " "
                Next

            Next
            Remarks.Text = ResultrEMARKS
            '-----------------

            MWMP = rpt.ReportDefinition.ReportObjects("MaxWMainPort")
            MWMP.Text = dt.Rows(0).Item("MaxWMainPort").ToString

            MWL = rpt.ReportDefinition.ReportObjects("MaxWLocal")
            MWL.Text = dt.Rows(0).Item("MaxWLocal").ToString

            ContactUs = rpt.ReportDefinition.ReportObjects("txtContactUs")
            ContactUs.Text = dt.Rows(0).Item("ContactUs").ToString

            Dim BookingNo1, SaleCode As TextObject
            BookingNo1 = rpt.ReportDefinition.ReportObjects("BookingNo1")
            BookingNo1.Text = dt.Rows(0).Item("BookingNo").ToString

            SaleCode = rpt.ReportDefinition.ReportObjects("SaleCode")
            SaleCode.Text = dt.Rows(0).Item("SaleCode").ToString

            NgayLam = rpt.ReportDefinition.ReportObjects("NgayLam")
            NgayLam.Text = CDate(dt.Rows(0).Item("BookingDate").ToString)

            NguoiGui = rpt.ReportDefinition.ReportObjects("NguoiGuiBooking")
            NguoiGui.Text = dt.Rows(0).Item("BookingPerson").ToString


            rpt.ReportDefinition.ReportObjects("VAN").ObjectFormat.EnableSuppress = True
            'Section3.ReportObjects("VAN").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("HUNG").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("HIEN").ObjectFormat.EnableSuppress = True
            rpt.ReportDefinition.ReportObjects("HUONG").ObjectFormat.EnableSuppress = True

            If UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "ĐẶNG HOÀNG VÂN" Then
                rpt.ReportDefinition.ReportObjects("VAN").ObjectFormat.EnableSuppress = False
            ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN ĐẮC HÙNG" Then
                rpt.ReportDefinition.ReportObjects("HUNG").ObjectFormat.EnableSuppress = False
            ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "PHAN THỊ THU HIỀN" Then
                rpt.ReportDefinition.ReportObjects("HIEN").ObjectFormat.EnableSuppress = False
            ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN THỊ THANH HƯƠNG" Then
                rpt.ReportDefinition.ReportObjects("HUONG").ObjectFormat.EnableSuppress = False
            ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "LƯƠNG THÚY PHƯƠNG" Then
                rpt.ReportDefinition.ReportObjects("PHUONG").ObjectFormat.EnableSuppress = False
            End If


            TitleSend = rpt.ReportDefinition.ReportObjects("TitleSend")
            DateSend = rpt.ReportDefinition.ReportObjects("DateSend")
            If dt.Rows(0).Item("ThirdSendDate").ToString <> "" Then
                TitleSend.Text = "Third Send :"
                DateSend.Text = CDate(dt.Rows(0).Item("ThirdSendDate").ToString)
            ElseIf dt.Rows(0).Item("SecondSendDate").ToString <> "" Then
                TitleSend.Text = "Second Send :"
                DateSend.Text = CDate(dt.Rows(0).Item("SecondSendDate").ToString)
            ElseIf dt.Rows(0).Item("FirstSendDate").ToString <> "" Then
                TitleSend.Text = "First Send :"
                DateSend.Text = CDate(dt.Rows(0).Item("FirstSendDate").ToString)
            Else
                TitleSend.Text = ""
                DateSend.Text = ""
            End If
            Dim text As String = "YÊU CẦU QÚY CÔNG TY ĐỔI LỆNH CẤP CONTAINER TẠI : "
            Dim SupplyPlace As TextObject
            SupplyPlace = rpt.ReportDefinition.ReportObjects("SupplyPlace")
            If UCase(dt.Rows(0).Item("SupplyOrderPlace").ToString()) = "TERMINAL" Then
                SupplyPlace.Text = text & "CÁT LÁI"
            Else
                SupplyPlace.Text = text & " VP 37 TÔN ĐỨC THẮNG, P. 1009"
            End If
        End If
        QueryVessel(dt)
        If dt.Rows.Count > 0 Then

            Dim XuatTrenTau, DiNgay As TextObject

            XuatTrenTau = rpt.ReportDefinition.ReportObjects("XuatTrenTau")
            XuatTrenTau.Text = dt.Rows(0).Item("Vessel").ToString

            DiNgay = rpt.ReportDefinition.ReportObjects("DiNgay")
            DiNgay.Text = CDate(dt.Rows(0).Item("ETD").ToString)

        End If
        'Me.CrystalReportViewer1.ReportSource = rpt
        'Formatting paper
        Dim mymargins = rpt.PrintOptions.PageMargins
        mymargins.topMargin = gTopM
        mymargins.bottomMargin = gBottomM
        mymargins.leftMargin = gLeftM
        mymargins.rightMargin = gRightM
        rpt.PrintOptions.ApplyPageMargins(mymargins)
        If frmMain.mnuReportOrientationPortrait.Checked Then
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rpt.Refresh()
        rpt.PrintToPrinter(1, True, 1, 1)

        'Me.CrystalReportViewer1.Refresh()
        'Me.CrystalReportViewer1.Show()
        Me.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class