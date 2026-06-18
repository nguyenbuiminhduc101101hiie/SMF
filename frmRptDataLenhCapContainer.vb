Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmRptDataLenhCapContainer

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
        Dim strQuery As String = "Select Vessel.Vessel +' - '+ Voyno as Vessel,ETD  "
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

    'Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        Me.fraOrder.Visible = False
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '    End Try
    'End Sub
    Sub PrintRPT()
        Try
            'Me.fraOrder.Visible = False
            'Dim rpt As New 
            Dim dt As New DataTable
            '-------------
            Dim rpt As New ReportDocument
            Dim strReportName As String
            Dim strQuery As String
            ' ten Report
            strReportName = "ReportDataLenhCapContainer"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rpt.Load(strReportPath)
            '--------------

            QueryBooking(dt)
            If dt.Rows.Count > 0 Then
                Dim BookingNo, Company, NguoiDaiDien, ContactUs, DiaChi, Tel, Fax, GP20, GP40, HC40, HC45, RF20, RF40, RH40, Special As TextObject

                BookingNo = rpt.ReportDefinition.ReportObjects("BookingNO")
                BookingNo.Text = dt.Rows(0).Item("BookingNo").ToString

                Company = rpt.ReportDefinition.ReportObjects("Company")
                Company.Text = dt.Rows(0).Item("Company").ToString & " - " & dt.Rows(0).Item("Representative").ToString

                NguoiDaiDien = rpt.ReportDefinition.ReportObjects("DaiDien")
                NguoiDaiDien.Text = dt.Rows(0).Item("ReceiptContainer").ToString

                DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
                DiaChi.Text = dt.Rows(0).Item("Address").ToString

                Tel = rpt.ReportDefinition.ReportObjects("Tel")
                Tel.Text = dt.Rows(0).Item("Tel").ToString

                'Fax = rpt.ReportDefinition.ReportObjects("Fax")
                'Fax.Text = dt.Rows(0).Item("Fax").ToString

                GP20 = rpt.ReportDefinition.ReportObjects("GP20")
                GP20.Text = IIf(dt.Rows(0).Item("SoLuong20GP").ToString = "0", "", dt.Rows(0).Item("SoLuong20GP").ToString)

                GP40 = rpt.ReportDefinition.ReportObjects("GP40")
                GP40.Text = IIf(dt.Rows(0).Item("SoLuong40GP").ToString = "0", "", dt.Rows(0).Item("SoLuong40GP").ToString)

                HC40 = rpt.ReportDefinition.ReportObjects("HC40")
                HC40.Text = IIf(dt.Rows(0).Item("SoLuong40HC").ToString = "0", "", dt.Rows(0).Item("SoLuong40HC").ToString)

                HC45 = rpt.ReportDefinition.ReportObjects("HC45")
                HC45.Text = IIf(dt.Rows(0).Item("SoLuong45HC").ToString = "0", "", dt.Rows(0).Item("SoLuong45HC").ToString)

                RF20 = rpt.ReportDefinition.ReportObjects("RF20")
                RF20.Text = IIf(dt.Rows(0).Item("SoLuong20RF").ToString = "0", "", dt.Rows(0).Item("SoLuong20RF").ToString)

                RF40 = rpt.ReportDefinition.ReportObjects("RF40")
                RF40.Text = IIf(dt.Rows(0).Item("SoLuong40RF").ToString = "0", "", dt.Rows(0).Item("SoLuong40RF").ToString)

                Special = rpt.ReportDefinition.ReportObjects("Special")
                Special.Text = dt.Rows(0).Item("SpencialEquipment").ToString


                Dim NhietDoLanh, NoiLayContainer, PhuongAn, ThongGio, YeuCauHaRong, ThoiHanHaBai, ChuyenTai As TextObject


                NhietDoLanh = rpt.ReportDefinition.ReportObjects("NhietDo")
                NhietDoLanh.Text = dt.Rows(0).Item("Cold").ToString

                ThongGio = rpt.ReportDefinition.ReportObjects("ThongGio")
                ThongGio.Text = dt.Rows(0).Item("Ventilation").ToString

                'NoiLayContainer = rpt.ReportDefinition.ReportObjects("NoiLayContainer")
                'NoiLayContainer.Text = dt.Rows(0).Item("EmptyContainerPlace").ToString

                PhuongAn = rpt.ReportDefinition.ReportObjects("PhuongAn")
                PhuongAn.Text = dt.Rows(0).Item("PackingWay").ToString

                YeuCauHaRong = rpt.ReportDefinition.ReportObjects("YeuCauHaRong")
                YeuCauHaRong.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString

                Dim NoiHaBai As TextObject
                NoiHaBai = rpt.ReportDefinition.ReportObjects("NoiHaBai")
                NoiHaBai.Text = dt.Rows(0).Item("CustomsLiquiDate").ToString


                '-----------
                ThoiHanHaBai = rpt.ReportDefinition.ReportObjects("ThoiHanHaBai")
                Dim TempTHHB(), ResultTHHB As String
                ResultTHHB = dt.Rows(0).Item("ClosingTime").ToString
                TempTHHB = Strings.Split(ResultTHHB, Chr(13))
                ResultTHHB = ""
                For j As Integer = 0 To TempTHHB.Length - 1
                    ResultTHHB &= TempTHHB(j)
                    For k As Integer = TempTHHB(j).Length To ThoiHanHaBai.Width \ 10
                        ResultTHHB &= " "
                    Next
                Next
                ThoiHanHaBai.Text = ResultTHHB
                '----------------
                ChuyenTai = rpt.ReportDefinition.ReportObjects("ChuyenTai")
                ChuyenTai.Text = dt.Rows(0).Item("Tranship").ToString

                Dim CangDoHang, DichCuoiCung, Remarks, NgayLam, NguoiGui As TextObject

                CangDoHang = rpt.ReportDefinition.ReportObjects("CangDoHang")
                CangDoHang.Text = dt.Rows(0).Item("PortOfUnLoading").ToString

                DichCuoiCung = rpt.ReportDefinition.ReportObjects("DichCuoiCung")
                DichCuoiCung.Text = dt.Rows(0).Item("Destination").ToString

                Remarks = rpt.ReportDefinition.ReportObjects("Remarks")
                Remarks.Text = dt.Rows(0).Item("Remarks").ToString

                'MWMP = rpt.ReportDefinition.ReportObjects("MaxWMainPort")
                'MWMP.Text = dt.Rows(0).Item("MaxWMainPort").ToString

                'MWL = rpt.ReportDefinition.ReportObjects("MaxWLocal")
                'MWL.Text = dt.Rows(0).Item("MaxWLocal").ToString

                'ContactUs = rpt.ReportDefinition.ReportObjects("txtContactUs")
                'ContactUs.Text = dt.Rows(0).Item("ContactUs").ToString

                NgayLam = rpt.ReportDefinition.ReportObjects("NgayLam")
                NgayLam.Text = CDate(dt.Rows(0).Item("BookingDate").ToString)

                NguoiGui = rpt.ReportDefinition.ReportObjects("NguoiGuiBooking")
                NguoiGui.Text = dt.Rows(0).Item("BookingPerson").ToString

                Dim NgayHetHan As TextObject
                NgayHetHan = rpt.ReportDefinition.ReportObjects("NgayHetHan")
                NgayHetHan.Text = dt.Rows(0).Item("CloseTime")
            End If
            QueryVessel(dt)
            If dt.Rows.Count > 0 Then

                Dim XuatTrenTau, DiNgay As TextObject

                XuatTrenTau = rpt.ReportDefinition.ReportObjects("XuatTrenTau")
                XuatTrenTau.Text = dt.Rows(0).Item("Vessel").ToString

                DiNgay = rpt.ReportDefinition.ReportObjects("DiNgay")
                DiNgay.Text = CDate(dt.Rows(0).Item("ETD").ToString)

              
            End If

            'Me.dtpNgayHetHan.Value.Date

            Me.CrystalReportViewer1.ReportSource = rpt
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

            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub frmDataSupplyContainerOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        'Me.fraOrder.Left = Me.Width / 2 - Me.fraOrder.Width / 2
        'Me.fraOrder.Top = Me.Height / 2 - Me.fraOrder.Height / 2
        'Me.fraOrder.Visible = True
        PrintRPT()
        Exit Sub
Err:
    End Sub

End Class