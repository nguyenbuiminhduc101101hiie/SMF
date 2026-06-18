Public Class frmSearchPhiCuocCont
    Dim oTable As New DataTable
    Dim strQuery As String


    Sub QueryVessel()
        Try
            strQuery = "Select Distinct Vessel +' - '+ VoyAge as Data From BillOfLadingIb Where Continued=1 Order By Data"
            Dim dt As New DataTable
            dt = ReadTable(strQuery)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.ValueMember = "Data"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryTheoTau()
        Try
            Dim Temp() As String
            Temp = Strings.Split(Me.cboVessel.Text.Trim, " - ")
            If Temp.Length < 2 Then
                Return
            End If
            Dim Vessel, VoyNo As String
            Vessel = Temp(0)
            VoyNo = Temp(1)
            strQuery = "select Distinct PhiCuocCont.BLIB_NO as ""Số Bill"",TenKhachHang As ""Tên Khách Hàng"",DiaChi As ""Địa chỉ"",dalaycuoc as ""Đã Lấy Cựơc"","
            strQuery &= "HinhThucThanhToan as ""Hình Thức Thanh Toán"",NoiDung as ""Nội Dung"",TenNguoiTra as ""Tên Người Trả"",CMNDNguoiTra as ""CMND Người Trả"","
            strQuery &= "TenNguoiLay as ""Tên Ngừơi Lấy"",CMNDNguoiLay as ""CMND Ngừơi Lấy"",Container_no, "
            strQuery &= "LoaiCont as ""Loại Container"",SoLuong as ""Số Lượng"",DonViTinh as ""Đơn Vị Tính "",SoTien as ""Số Tiền"",ThanhTien as ""Thành Tiền"",Userid as [Người cập nhật], updatetime as [Thời gian cập nhật]"
            strQuery &= " From (PhiCuocCont INNER JOIN BillOfLadingIB On BillOfLadingIB.BLIB_NO=PhiCuocCont.BLIB_NO)"
            strQuery &= " Where PhiCuocCont.Continued=1 And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo & "'"
            oTable = ReadTable(strQuery)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryTheoNgay()
        Try

            strQuery = "select Distinct PhiCuocCont.BLIB_NO as ""Số Bill"",TenKhachHang As ""Tên Khách Hàng"",DiaChi As ""Địa chỉ"",dalaycuoc as ""Đã Lấy Cựơc"","
            strQuery &= "HinhThucThanhToan as ""Hình Thức Thanh Toán"",NoiDung as ""Nội Dung"",TenNguoiTra as ""Tên Người Trả"",CMNDNguoiTra as ""CMND Người Trả"","
            strQuery &= "TenNguoiLay as ""Tên Ngừơi Lấy"",CMNDNguoiLay as ""CMND Ngừơi Lấy"", Container_No, "
            strQuery &= "LoaiCont as ""Loại Container"",SoLuong as ""Số Lượng"",DonViTinh as ""Đơn Vị Tính "",SoTien as ""Số Tiền"",ThanhTien as ""Thành Tiền"",Userid as [Người cập nhật], updatetime as [Thời gian cập nhật]"
            strQuery &= " from PhiCuocCont "
            If Me.dtpFromDate.Value.Date <> Me.dtpToDate.Value.Date Then
                strQuery &= " Where convert(datetime,updateTime) >'" & Date.FromOADate(Me.dtpFromDate.Value.Date.ToOADate) & "' And convert(datetime,UpdateTime) <'" & Me.dtpToDate.Value.Date.AddDays(1) & "' And Continued=1"
            Else
                strQuery &= " Where day(updateTime)= '" & Me.dtpFromDate.Value.Date.Day & "' and month(updateTime)= '" & Me.dtpFromDate.Value.Date.Month & "' and year(updateTime)= '" & Me.dtpFromDate.Value.Date.Year & "' And Continued=1"
            End If

            oTable = ReadTable(strQuery)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            If Me.chkDateFind.Checked = True Then
                QueryTheoNgay()
            Else
                QueryTheoTau()
            End If
            Me.dgdResult.DataSource = oTable
            InsertAutoNumberToGrid(Me.dgdResult)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdResult.Rows.Count > 0 Then
                'SetMenu(False)
                Me.Cursor = Cursors.WaitCursor
                ExportExecel(Me.dgdResult, Me)

                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmSearchPhieuThuTien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        SetDefaultGrid(Me.dgdResult, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub
End Class