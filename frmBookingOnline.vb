
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmBookingOnline
    '    Public mFilter As String = ""
    '    Dim rpt As New ReportBookingOnline
    '    Sub QueryBookingOnline(ByRef dt As DataTable, Optional ByVal strFilter As String = "")
    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '        Dim strSQL As String = "select * from BookingOnline Where Continued=1 " & strFilter
    '        Dim Cmd As New SqlClient.SqlCommand(strSQL, Conn)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(Cmd)
    '        'Dim t As Date
    '        't.TimeOfDay = Me.mclSelect.SelectionStart.TimeOfDay
    '        't = Me.mclSelect.SelectionStart.Date
    '        Try
    '            Conn.Open()
    '            If dt.Rows.Count > 0 Then
    '                dt.Rows.Clear()
    '            End If
    '            Adapter.Fill(dt)
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        Finally
    '            Conn.Close()
    '            Conn.Dispose()
    '            Conn = Nothing
    '            Cmd.Dispose()
    '            Cmd = Nothing
    '            Adapter.Dispose()
    '            Adapter = Nothing
    '        End Try
    '    End Sub
    '    Private Sub frmBookingOnline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        SetDefaultGrid(Me.dgdBookingOnline, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    '    End Sub


    '    Private Sub mclSelect_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles mclSelect.DateChanged
    '        Try
    '            Dim dt As New DataTable
    '            Dim DayStart As String = Me.mclSelect.SelectionStart & " 00:00"
    '            Dim DayEnd As String = Me.mclSelect.SelectionStart & " 23:59"
    '            QueryBookingOnline(dt, " And UpdateTime>='" & DayStart & "' And UpdateTime<='" & DayEnd & "'")
    '            Me.dgdBookingOnline.DataSource = dt
    '            dt.Dispose()
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '    End Sub
    '    Sub QueryTenNV(ByRef dt As DataTable, ByVal SQL As String)
    '        Try
    '            Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '            Conn.Open()
    '            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
    '            Adapter.Fill(dt)
    '            Conn.Close()
    '            Conn.Dispose()
    '            Conn = Nothing
    '            cmd.Dispose()
    '            cmd = Nothing
    '            Adapter.Dispose()
    '            Adapter = Nothing
    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '    End Sub
    '    Sub PrintBooking(ByVal dgdBookingOnline As DataGridView, ByVal index As Integer)

    '        Dim text1, TenTau, SoChuyen, POL, Company, NguoiDaiDien, DiaChi, Tel, Fax, Email, GP20, GP40, HC40, HC45, RF20, RF40, RH40, Special As TextObject

    '        text1 = rpt.ReportDefinition.ReportObjects("text1")
    '        text1.Text = "BOOKING ONLINE (" + dgdBookingOnline.Item("bookingonlineno", index).Value.ToString + ")"

    '        Company = rpt.ReportDefinition.ReportObjects("Company")
    '        Company.Text = dgdBookingOnline.Item("Company", index).Value.ToString

    '        NguoiDaiDien = rpt.ReportDefinition.ReportObjects("DaiDien")
    '        NguoiDaiDien.Text = dgdBookingOnline.Item("ATTN", index).Value.ToString

    '        DiaChi = rpt.ReportDefinition.ReportObjects("DiaChi")
    '        DiaChi.Text = dgdBookingOnline.Item("Address", index).Value.ToString


    '        Tel = rpt.ReportDefinition.ReportObjects("Tel")
    '        Tel.Text = dgdBookingOnline.Item("Tel", index).Value.ToString


    '        Fax = rpt.ReportDefinition.ReportObjects("Fax")
    '        Fax.Text = dgdBookingOnline.Item("Fax", index).Value.ToString

    '        Email = rpt.ReportDefinition.ReportObjects("Email")
    '        Email.Text = dgdBookingOnline.Item("Email", index).Value.ToString


    '        GP20 = rpt.ReportDefinition.ReportObjects("GP20")
    '        GP20.Text = dgdBookingOnline.Item("SoLuong20GP", index).Value.ToString

    '        GP40 = rpt.ReportDefinition.ReportObjects("GP40")
    '        GP40.Text = dgdBookingOnline.Item("SoLuong40GP", index).Value.ToString

    '        HC40 = rpt.ReportDefinition.ReportObjects("HC40")
    '        HC40.Text = dgdBookingOnline.Item("SoLuong40HC", index).Value.ToString

    '        HC45 = rpt.ReportDefinition.ReportObjects("HC45")
    '        HC45.Text = dgdBookingOnline.Item("SoLuong45HC", index).Value.ToString

    '        RF20 = rpt.ReportDefinition.ReportObjects("RF20")
    '        RF20.Text = dgdBookingOnline.Item("SoLuong20RF", index).Value.ToString

    '        RF40 = rpt.ReportDefinition.ReportObjects("RF40")
    '        RF40.Text = dgdBookingOnline.Item("SoLuong40RF", index).Value.ToString

    '        Special = rpt.ReportDefinition.ReportObjects("Special")
    '        Special.Text = dgdBookingOnline.Item("SpencalEquipMent", index).Value.ToString


    '        Dim Dingay, NhietDoLanh, NoiLayContainer, PhuongAn, ThongGio, YeuCauHaRong, ThoiHanHaBai, ChuyenTai As TextObject

    '        NhietDoLanh = rpt.ReportDefinition.ReportObjects("NhietDo")
    '        NhietDoLanh.Text = dgdBookingOnline.Item("Temperature", index).Value.ToString

    '        ThongGio = rpt.ReportDefinition.ReportObjects("ThongGio")
    '        ThongGio.Text = dgdBookingOnline.Item("Vent", index).Value.ToString

    '        Dingay = rpt.ReportDefinition.ReportObjects("Dingay")
    '        Dingay.Text = dgdBookingOnline.Item("OnboardDate", index).Value.ToString
    '        'dt.Rows(0).Item("Cold").ToString

    '        TenTau = rpt.ReportDefinition.ReportObjects("TenTau")
    '        TenTau.Text = dgdBookingOnline.Item("Vessel", index).Value.ToString
    '        'dt.Rows(0).Item("Ventilation").ToString

    '        SoChuyen = rpt.ReportDefinition.ReportObjects("SoChuyen")
    '        SoChuyen.Text = dgdBookingOnline.Item("VoyAge", index).Value.ToString

    '        POL = rpt.ReportDefinition.ReportObjects("POL")
    '        POL.Text = dgdBookingOnline.Item("POL", index).Value.ToString


    '        Dim CangDoHang, DichCuoiCung, NguoiLam, Remarks, NgayLam, NguoiGui, MotaHanghoa As TextObject

    '        CangDoHang = rpt.ReportDefinition.ReportObjects("CangDoHang")
    '        CangDoHang.Text = dgdBookingOnline.Item("POD", index).Value.ToString

    '        Remarks = rpt.ReportDefinition.ReportObjects("Remarks")
    '        Remarks.Text = dgdBookingOnline.Item("Remarks", index).Value.ToString


    '        MotaHanghoa = rpt.ReportDefinition.ReportObjects("MotaHanghoa")
    '        MotaHanghoa.Text = dgdBookingOnline.Item("Goods", index).Value.ToString

    '        Dim dt As New DataTable
    '        QueryTenNV(dt, "Select Name from UserList Where usr='" & strUserId.Trim & "' And DisContinued=0")
    '        NguoiLam = rpt.ReportDefinition.ReportObjects("NguoiLamBooking")
    '        If dt.Rows.Count > 0 Then
    '            NguoiLam.Text = dt.Rows(0).Item("Name").ToString
    '        Else
    '            NguoiLam.Text = strUserId
    '        End If
    '        dt.Dispose()


    '        rpt.Refresh()
    '        'rpt.PrintToPrinter(1, True, 1, 2)
    '        Me.CrystalReportViewer1.ReportSource = rpt
    '        Me.CrystalReportViewer1.Refresh()
    '        Me.CrystalReportViewer1.DisplayToolbar = True
    '        Me.CrystalReportViewer1.Show()

    '        rpt = Nothing

    '        Exit Sub
    'Err:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cxtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtPrint.Click
    '        Try
    '            Dim countSelected As Integer = Me.dgdBookingOnline.GetCellCount(DataGridViewElementStates.Selected)
    '            If countSelected = 0 Then
    '                Return
    '            End If

    '            Dim index As Integer
    '            If Me.dgdBookingOnline.Rows.Count = 0 Then
    '                Return
    '            Else
    '                index = Me.dgdBookingOnline.CurrentRow.Index
    '            End If
    '            Dim BookingOnlineID As String
    '            BookingOnlineID = Me.dgdBookingOnline.Item("BookingOnlineID", index).Value.ToString.Trim
    '            Dim strQuery As String
    '            strQuery = "Update BookingOnline set UserUpdate='" & strUserId & "' Where BookingOnlineId='" & BookingOnlineID & "'" ' And userUpdate is null"
    '            Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '            Conn.Open()
    '            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
    '            cmd.CommandType = CommandType.Text
    '            cmd.CommandText = strQuery
    '            Dim i As Integer
    '            i = cmd.ExecuteNonQuery()
    '            rpt = New ReportBookingOnline

    '            PrintBooking(Me.dgdBookingOnline, index)

    '            Me.tabData.SelectTab("tabPrint")

    '            'Me.CrystalReportViewer1.BringToFront()

    '            'End If
    '            'frmRptBookingOnline.printIndex = index
    '            'frmRptBookingOnline.ShowDialog()
    '            cmd.Dispose()
    '            Conn.Close()
    '            Conn.Dispose()

    '        Catch ex As Exception
    '            DisplayMessage(True, Err.Description)
    '        End Try
    '    End Sub


    '    Private Sub cmdexit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdexit.Click
    '        Me.Close()
    '    End Sub
End Class