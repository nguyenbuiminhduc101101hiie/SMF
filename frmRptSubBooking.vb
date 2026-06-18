Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptSubBooking
    Public data As Boolean = False
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

    Sub QueryVessel(ByRef oTable As DataTable)
        On Error GoTo Err
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        Dim strQuery As String = "Select  Vessel.Vessel +' - '+ Voyno as Vessel,ETD,ContainerOutboundNotify.CloseTime "
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
    Sub PrintRpt()
        'Try
        '    Dim rpt As New ReportDocument
        '    Dim RptData As New ReportLenhCapContainer
        '    Dim dt As New DataTable
        '    Dim strReportName As String
        '    Me.CrystalReportViewer1.ReportSource = Nothing

        '    If data = False Then
        '        strReportName = "ReportLenhCapContainer"
        '    Else
        '        strReportName = "ReportDataLenhCapContainer"

        '    End If
        '    ' ten Report
        '    Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
        '    If Not IO.File.Exists(strReportPath) Then
        '        DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
        '        Exit Sub
        '    End If
        '    rpt.Load(strReportPath)
        '    '----------

        '    QueryBooking(dt)
        '    If dt.Rows.Count > 0 Then
        '        Dim BookingNo, Company, NguoiDaiDien, ContactUs, DiaChi, Tel, Fax, GP20, GP40, HC40, HC45, RF20, RF40, RH40, Special, soluongcontloai As TextObject

        '        BookingNo = rpt.ReportDefinition.ReportObjects("BookingNO")
        '        BookingNo.Text = gBookingNo

        '        Company = rpt.ReportDefinition.ReportObjects("Company")
        '        Company.Text = frmBookingOrder.txtCompanyOrder.Text.Trim  'dt.Rows(0).Item("Company").ToString

        '        NguoiDaiDien = rpt.ReportDefinition.ReportObjects("DaiDien")
        '        NguoiDaiDien.Text = frmBookingOrder.txtNguoiDaiDienNhanConatiner.Text.Trim    'dt.Rows(0).Item("Representative").ToString

        '        DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi") ' nới lấy container rỗng
        '        DiaChi.Text = frmBookingOrder.cboSupplyDepotOrder.Text.Trim    'dt.Rows(0).Item("EmptyContainerPlace").ToString

        '        Dim CMND As TextObject
        '        CMND = rpt.ReportDefinition.ReportObjects("CMThu")
        '        CMND.Text = "CMT : " & frmBookingOrder.txtCMNDSplit.Text


        '        Tel = rpt.ReportDefinition.ReportObjects("Tel")
        '        Tel.Text = frmBookingOrder.txttellenh.Text 'dt.Rows(0).Item("Tel").ToString


        '        Dim NhietDoLanh, NoiLayContainer, PhuongAn, ThongGio, YeuCauHaRong, ThoiHanHaBai, ChuyenTai As TextObject
        '        'If data = False Then 'bên lệnh cấp data không cần
        '        '    Fax = rpt.ReportDefinition.ReportObjects("Fax")
        '        '    Fax.Text = dt.Rows(0).Item("Fax").ToString

        '        '    NoiLayContainer = rpt.ReportDefinition.ReportObjects("NoiLayContainer")
        '        '    NoiLayContainer.Text = dt.Rows(0).Item("EmptyContainerPlace").ToString

        '        'End If
        '        Dim sl As String = ""

        '        sl = IIf(frmBookingOrder.txtQuanTity20gp.Text.ToString = "0" Or frmBookingOrder.txtQuanTity20gp.Text.ToString = "", "", frmBookingOrder.txtQuanTity20gp.Text.ToString + " x 20GP; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity40GP.Text.ToString = "0" Or frmBookingOrder.txtQuanTity40GP.Text.ToString = "", "", frmBookingOrder.txtQuanTity40GP.Text.ToString + " x 40GP; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity40HC.Text.ToString = "0" Or frmBookingOrder.txtQuanTity40HC.Text.ToString = "", "", frmBookingOrder.txtQuanTity40HC.Text.ToString + " x 40HC; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity45HC.Text.ToString = "0" Or frmBookingOrder.txtQuanTity45HC.Text.ToString = "", "", frmBookingOrder.txtQuanTity45HC.Text.ToString + " x 45HC; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity20RF.Text.ToString = "0" Or frmBookingOrder.txtQuanTity20RF.Text.ToString = "", "", frmBookingOrder.txtQuanTity20RF.Text.ToString + " x 20RF; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity20RF.Text.ToString = "0" Or frmBookingOrder.txtQuanTity20RF.Text.ToString = "", "", frmBookingOrder.txtQuanTity40RF.Text.ToString + " x 40RF; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity40RH.Text.ToString = "0" Or frmBookingOrder.txtQuanTity40RH.Text.ToString = "", "", frmBookingOrder.txtQuanTity40RH.Text.ToString + " x 40RH; ")

        '        sl += IIf(frmBookingOrder.txtQuanTity20OT.Text.ToString = "0" Or frmBookingOrder.txtQuanTity20OT.Text.ToString = "", "", frmBookingOrder.txtQuanTity20OT.Text.ToString + " x 20OT; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity40OT.Text.ToString = "0" Or frmBookingOrder.txtQuanTity40OT.Text.ToString = "", "", frmBookingOrder.txtQuanTity40OT.Text.ToString + " x 40OT; ")



        '        sl += IIf(frmBookingOrder.txtQuanTity20FR.Text.ToString = "0" Or frmBookingOrder.txtQuanTity20FR.Text.ToString = "", "", frmBookingOrder.txtQuanTity20FR.Text.ToString + " x 20FR; ")


        '        sl += IIf(frmBookingOrder.txtQuanTity40FR.Text.ToString = "0" Or frmBookingOrder.txtQuanTity40FR.Text.ToString = "", "", frmBookingOrder.txtQuanTity40FR.Text.ToString + " x 40FR; ")



        '        soluongcontloai = rpt.ReportDefinition.ReportObjects("SoLuongContLoai")
        '        soluongcontloai.Text = "Số lượng/Loại cont : " + sl.Remove(sl.Length - 2, 1)





        '        NhietDoLanh = rpt.ReportDefinition.ReportObjects("NhietDo")
        '        NhietDoLanh.Text = dt.Rows(0).Item("Cold").ToString

        '        ThongGio = rpt.ReportDefinition.ReportObjects("ThongGio")
        '        ThongGio.Text = dt.Rows(0).Item("Ventilation").ToString


        '        PhuongAn = rpt.ReportDefinition.ReportObjects("PhuongAn")
        '        PhuongAn.Text = dt.Rows(0).Item("PackingWay").ToString

        '        YeuCauHaRong = rpt.ReportDefinition.ReportObjects("YeuCauHaRong")
        '        YeuCauHaRong.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

        '        Dim NoiHaBai As TextObject
        '        NoiHaBai = rpt.ReportDefinition.ReportObjects("NoiHaBai")
        '        NoiHaBai.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString


        '        '-----------
        '        ThoiHanHaBai = rpt.ReportDefinition.ReportObjects("ThoiHanHaBai")
        '        Dim TempTHHB(), ResultTHHB, TEMP, TEMP1 As String
        '        If dt.Rows(0).Item("DateClosing1").ToString = "" Then
        '            TEMP = ""
        '        Else
        '            TEMP = CDate(dt.Rows(0).Item("DateClosing1").ToString)
        '        End If
        '        If dt.Rows(0).Item("DateClosing2").ToString = "" Then
        '            TEMP1 = ""
        '        Else
        '            TEMP1 = CDate(dt.Rows(0).Item("DateClosing2").ToString)
        '        End If
        '        ResultTHHB = "TRƯỚC " & dt.Rows(0).Item("Gio1").ToString.Trim & "H " & dt.Rows(0).Item("AMPM1").ToString.Trim & " CỦA NGÀY " & TEMP & " ĐỐI VỚI CONT 20F" & Chr(13)
        '        ResultTHHB &= "TRƯỚC " & dt.Rows(0).Item("Gio2").ToString.Trim & "H " & dt.Rows(0).Item("AMPM2").ToString.Trim & " CỦA NGÀY " & TEMP1 & " ĐỐI VỚI CONT 40F"
        '        TempTHHB = Strings.Split(ResultTHHB, Chr(13))
        '        ResultTHHB = ""
        '        For j As Integer = 0 To TempTHHB.Length - 1
        '            ResultTHHB &= TempTHHB(j)
        '            For k As Integer = TempTHHB(j).Length To ThoiHanHaBai.Width \ 10
        '                ResultTHHB &= " "
        '            Next
        '        Next
        '        ThoiHanHaBai.Text = ResultTHHB
        '        '----------------
        '        ChuyenTai = rpt.ReportDefinition.ReportObjects("ChuyenTai")
        '        ChuyenTai.Text = dt.Rows(0).Item("Tranship").ToString

        '        Dim CangDoHang, DichCuoiCung, Remarks, NgayLam, NguoiGui As TextObject

        '        CangDoHang = rpt.ReportDefinition.ReportObjects("CangDoHang")
        '        CangDoHang.Text = dt.Rows(0).Item("PortOfUnLoading").ToString

        '        DichCuoiCung = rpt.ReportDefinition.ReportObjects("DichCuoiCung")
        '        DichCuoiCung.Text = dt.Rows(0).Item("Destination").ToString

        '        Remarks = rpt.ReportDefinition.ReportObjects("Remarks")
        '        Remarks.Text = frmBookingOrder.txtRemarksSplit.Text

        '        'MWMP = rpt.ReportDefinition.ReportObjects("MaxWMainPort")
        '        'MWMP.Text = dt.Rows(0).Item("MaxWMainPort").ToString

        '        'MWL = rpt.ReportDefinition.ReportObjects("MaxWLocal")
        '        'MWL.Text = dt.Rows(0).Item("MaxWLocal").ToString

        '        'ContactUs = rpt.ReportDefinition.ReportObjects("txtContactUs")
        '        'ContactUs.Text = dt.Rows(0).Item("ContactUs").ToString

        '        NgayLam = rpt.ReportDefinition.ReportObjects("NgayLam")
        '        NgayLam.Text = CDate(Getdate())

        '        NguoiGui = rpt.ReportDefinition.ReportObjects("NguoiGuiBooking")
        '        NguoiGui.Text = dt.Rows(0).Item("BookingPerson").ToString

        '        'rpt.Section3.ReportObjects("VAN").ObjectFormat.EnableSuppress = True
        '        'rpt.Section3.ReportObjects("HUNG").ObjectFormat.EnableSuppress = True
        '        'rpt.Section3.ReportObjects("HIEN").ObjectFormat.EnableSuppress = True
        '        'rpt.Section3.ReportObjects("HUONG").ObjectFormat.EnableSuppress = True

        '        'If UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "ĐẶNG HOÀNG VÂN" Then
        '        '    rpt.Section3.ReportObjects("VAN").ObjectFormat.EnableSuppress = False
        '        'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN ĐẮC HÙNG" Then
        '        '    rpt.Section3.ReportObjects("HUNG").ObjectFormat.EnableSuppress = False
        '        'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "PHAN THỊ THU HIỀN" Then
        '        '    rpt.Section3.ReportObjects("HIEN").ObjectFormat.EnableSuppress = False
        '        'ElseIf UCase(dt.Rows(0).Item("BookingPerson").ToString.Trim) = "NGUYỄN THỊ THANH HƯƠNG" Then
        '        '    rpt.Section3.ReportObjects("HUONG").ObjectFormat.EnableSuppress = False
        '        'End If


        '    End If
        '    QueryVessel(dt)
        '    If dt.Rows.Count > 0 Then

        '        Dim XuatTrenTau, DiNgay As TextObject

        '        XuatTrenTau = rpt.ReportDefinition.ReportObjects("XuatTrenTau")
        '        XuatTrenTau.Text = dt.Rows(0).Item("Vessel").ToString

        '        DiNgay = rpt.ReportDefinition.ReportObjects("DiNgay")
        '        DiNgay.Text = CDate(dt.Rows(0).Item("ETD").ToString)

        '    End If
        '    Dim NgayHetHan As TextObject
        '    NgayHetHan = rpt.ReportDefinition.ReportObjects("NgayHetHan")
        '    NgayHetHan.Text = frmBookingOrder.dtpExpireate.Value.Date 'dt.Rows(0).Item("CloseTime")
        '    'RptData = rpt
        '    'Formatting paper
        '    Dim mymargins = rpt.PrintOptions.PageMargins
        '    mymargins.topMargin = gTopM
        '    mymargins.bottomMargin = gBottomM
        '    mymargins.leftMargin = gLeftM
        '    mymargins.rightMargin = gRightM
        '    rpt.PrintOptions.ApplyPageMargins(mymargins)
        '    If data Then
        '        rpt.PrintToPrinter(1, True, 1, 100)
        '        Return
        '    End If
        '    Me.CrystalReportViewer1.ReportSource = rpt

        '    If frmMain.mnuReportOrientationPortrait.Checked Then
        '        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        '    Else
        '        rpt.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        '    End If
        '    rpt.Refresh()

        '    Me.CrystalReportViewer1.Refresh()
        '    Me.CrystalReportViewer1.Show()

        'Catch ex As Exception
        '    MsgBox(Err.Description)
        'End Try
    End Sub
    Private Sub frmSupplyContainerOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PrintRpt()
    End Sub

    Private Sub cmdOkData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkData.Click
        Try
            'If Me.txtCMNDSplit.Text = "" Or Me.txttellenh.Text = "" Then
            '    DisplayMessage(True, "Please check again, the ID Card or Telephone is invalid!")
            '    Return
            'End If
            'If checkDate() = False Then
            '    DisplayMessage(True, "Please check again Expire Date is Invalid!")
            '    Return
            'End If
            'If Me.chkSave.Checked = False Then ' nếu Nút "Don't Save" không Check
            '    If SaveSplitData() = False Then
            '        DisplayMessage(True, "If you want Print anyway Please check (Don't Save)")
            '        Return
            '    End If
            'End If
            'gBookingNo = Me.txtSubBookingNo.Text
            'If gBookingNo = "" Then
            '    If (MsgBox("Chưa Có Sub Booking No. .Bạn có muốn nhập Sub Booking No. không ?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes) Then
            '        Return
            '    End If
            'End If
            data = True
            PrintRpt()
            data = False
            PrintRpt()
            'frmRptSubBooking.ShowDialog()
            'Me.fraReportSplitBooking.Visible = False
            'Me.txtQuanTity20gp.Text = ""
            'Me.txtQuanTity20RF.Text = ""
            'Me.txtQuanTity40GP.Text = ""
            'Me.txtQuanTity40HC.Text = ""
            'Me.txtQuanTity40RF.Text = ""
            'Me.txtQuanTity40RH.Text = ""
            'Me.txtQuanTity45HC.Text = ""
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class