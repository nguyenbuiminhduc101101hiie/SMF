<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPhieuThuTien
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdThem = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtTongTien = New System.Windows.Forms.TextBox
        Me.txtSoLuong = New System.Windows.Forms.TextBox
        Me.txtHinhThucThanhToan = New System.Windows.Forms.TextBox
        Me.txtMaSoThue = New System.Windows.Forms.TextBox
        Me.txtDiaChi = New System.Windows.Forms.TextBox
        Me.txtTenKhachHang = New System.Windows.Forms.TextBox
        Me.txtBLNo = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboLoaiContainer = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtTongCong = New System.Windows.Forms.TextBox
        Me.dgdNoiDungThu = New System.Windows.Forms.DataGridView
        Me.PhieuThu_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SeriesNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BLIB_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TenKhachHang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiaChi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MaSoThue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HinhThucThanhToan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoiDung = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LoaiContainer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DonViTinh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DonGia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ThanhTien = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EditTable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmDel = New System.Windows.Forms.ToolStripMenuItem
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSoTien = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdAll = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdOkReport = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSeriesNo = New System.Windows.Forms.TextBox
        Me.txtNoiDungthu = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.cbodonvitinh = New System.Windows.Forms.ComboBox
        CType(Me.dgdNoiDungThu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(363, 115)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdThem
        '
        Me.cmdThem.Location = New System.Drawing.Point(573, 17)
        Me.cmdThem.Name = "cmdThem"
        Me.cmdThem.Size = New System.Drawing.Size(43, 23)
        Me.cmdThem.TabIndex = 6
        Me.cmdThem.Text = "Thêm"
        Me.cmdThem.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(17, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Số B/L No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(6, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Tên khách hàng :  "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(52, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Địa chỉ :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(31, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Mã số thuế :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(268, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Số lượng Cont :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(54, 80)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Thành tiền :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Đơn vị tính :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(277, 125)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(113, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Hình thức thanh toán :"
        '
        'txtTongTien
        '
        Me.txtTongTien.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTongTien.Location = New System.Drawing.Point(120, 76)
        Me.txtTongTien.Name = "txtTongTien"
        Me.txtTongTien.Size = New System.Drawing.Size(108, 20)
        Me.txtTongTien.TabIndex = 4
        Me.txtTongTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong
        '
        Me.txtSoLuong.Location = New System.Drawing.Point(349, 24)
        Me.txtSoLuong.Name = "txtSoLuong"
        Me.txtSoLuong.Size = New System.Drawing.Size(45, 20)
        Me.txtSoLuong.TabIndex = 1
        Me.txtSoLuong.Text = "0"
        Me.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHinhThucThanhToan
        '
        Me.txtHinhThucThanhToan.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtHinhThucThanhToan.Location = New System.Drawing.Point(392, 123)
        Me.txtHinhThucThanhToan.Name = "txtHinhThucThanhToan"
        Me.txtHinhThucThanhToan.Size = New System.Drawing.Size(89, 20)
        Me.txtHinhThucThanhToan.TabIndex = 4
        '
        'txtMaSoThue
        '
        Me.txtMaSoThue.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtMaSoThue.Location = New System.Drawing.Point(100, 121)
        Me.txtMaSoThue.Name = "txtMaSoThue"
        Me.txtMaSoThue.Size = New System.Drawing.Size(167, 20)
        Me.txtMaSoThue.TabIndex = 3
        '
        'txtDiaChi
        '
        Me.txtDiaChi.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtDiaChi.Location = New System.Drawing.Point(100, 96)
        Me.txtDiaChi.Name = "txtDiaChi"
        Me.txtDiaChi.Size = New System.Drawing.Size(557, 20)
        Me.txtDiaChi.TabIndex = 2
        '
        'txtTenKhachHang
        '
        Me.txtTenKhachHang.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTenKhachHang.Location = New System.Drawing.Point(100, 67)
        Me.txtTenKhachHang.Name = "txtTenKhachHang"
        Me.txtTenKhachHang.Size = New System.Drawing.Size(557, 20)
        Me.txtTenKhachHang.TabIndex = 1
        '
        'txtBLNo
        '
        Me.txtBLNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBLNo.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtBLNo.Location = New System.Drawing.Point(100, 27)
        Me.txtBLNo.Multiline = True
        Me.txtBLNo.Name = "txtBLNo"
        Me.txtBLNo.Size = New System.Drawing.Size(272, 34)
        Me.txtBLNo.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(37, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Loại kiểm định :"
        '
        'cboLoaiContainer
        '
        Me.cboLoaiContainer.FormattingEnabled = True
        Me.cboLoaiContainer.Location = New System.Drawing.Point(121, 23)
        Me.cboLoaiContainer.Name = "cboLoaiContainer"
        Me.cboLoaiContainer.Size = New System.Drawing.Size(54, 21)
        Me.cboLoaiContainer.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(268, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "TỔNG CỘNG :"
        '
        'txtTongCong
        '
        Me.txtTongCong.Enabled = False
        Me.txtTongCong.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtTongCong.Location = New System.Drawing.Point(349, 76)
        Me.txtTongCong.Name = "txtTongCong"
        Me.txtTongCong.Size = New System.Drawing.Size(100, 20)
        Me.txtTongCong.TabIndex = 5
        Me.txtTongCong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgdNoiDungThu
        '
        Me.dgdNoiDungThu.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdNoiDungThu.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdNoiDungThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdNoiDungThu.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PhieuThu_ID, Me.SeriesNo, Me.BLIB_NO, Me.TenKhachHang, Me.DiaChi, Me.MaSoThue, Me.HinhThucThanhToan, Me.NoiDung, Me.LoaiContainer, Me.SoLuong, Me.DonViTinh, Me.DonGia, Me.ThanhTien, Me.Total, Me.EditTable, Me.Continued, Me.UserID, Me.UpdateTime})
        Me.dgdNoiDungThu.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdNoiDungThu.Location = New System.Drawing.Point(12, 147)
        Me.dgdNoiDungThu.Name = "dgdNoiDungThu"
        Me.dgdNoiDungThu.ReadOnly = True
        Me.dgdNoiDungThu.Size = New System.Drawing.Size(645, 185)
        Me.dgdNoiDungThu.TabIndex = 6
        '
        'PhieuThu_ID
        '
        Me.PhieuThu_ID.DataPropertyName = "PhieuThu_ID"
        Me.PhieuThu_ID.HeaderText = "PhieuThu_ID"
        Me.PhieuThu_ID.Name = "PhieuThu_ID"
        Me.PhieuThu_ID.ReadOnly = True
        Me.PhieuThu_ID.Visible = False
        '
        'SeriesNo
        '
        Me.SeriesNo.DataPropertyName = "SeriesNo"
        Me.SeriesNo.HeaderText = "Số Series"
        Me.SeriesNo.Name = "SeriesNo"
        Me.SeriesNo.ReadOnly = True
        '
        'BLIB_NO
        '
        Me.BLIB_NO.DataPropertyName = "BLIB_NO"
        Me.BLIB_NO.HeaderText = "Số Bill"
        Me.BLIB_NO.Name = "BLIB_NO"
        Me.BLIB_NO.ReadOnly = True
        '
        'TenKhachHang
        '
        Me.TenKhachHang.DataPropertyName = "TenKhachHang"
        Me.TenKhachHang.HeaderText = "Tên Khách Hàng"
        Me.TenKhachHang.Name = "TenKhachHang"
        Me.TenKhachHang.ReadOnly = True
        '
        'DiaChi
        '
        Me.DiaChi.DataPropertyName = "DiaChi"
        Me.DiaChi.HeaderText = "Địa Chỉ"
        Me.DiaChi.Name = "DiaChi"
        Me.DiaChi.ReadOnly = True
        '
        'MaSoThue
        '
        Me.MaSoThue.DataPropertyName = "MaSoThue"
        Me.MaSoThue.HeaderText = "Mã Số Thuế"
        Me.MaSoThue.Name = "MaSoThue"
        Me.MaSoThue.ReadOnly = True
        '
        'HinhThucThanhToan
        '
        Me.HinhThucThanhToan.DataPropertyName = "HinhThucThanhToan"
        Me.HinhThucThanhToan.HeaderText = "Hình Thức Thanh Toán"
        Me.HinhThucThanhToan.Name = "HinhThucThanhToan"
        Me.HinhThucThanhToan.ReadOnly = True
        '
        'NoiDung
        '
        Me.NoiDung.DataPropertyName = "NoiDungThu"
        Me.NoiDung.HeaderText = "Nội Dung Thu"
        Me.NoiDung.Name = "NoiDung"
        Me.NoiDung.ReadOnly = True
        '
        'LoaiContainer
        '
        Me.LoaiContainer.DataPropertyName = "LoaiContainer"
        Me.LoaiContainer.HeaderText = "Loại Container kiểm định"
        Me.LoaiContainer.Name = "LoaiContainer"
        Me.LoaiContainer.ReadOnly = True
        Me.LoaiContainer.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.LoaiContainer.Width = 150
        '
        'SoLuong
        '
        Me.SoLuong.DataPropertyName = "SoLuong"
        Me.SoLuong.HeaderText = "Số lượng"
        Me.SoLuong.Name = "SoLuong"
        Me.SoLuong.ReadOnly = True
        '
        'DonViTinh
        '
        Me.DonViTinh.DataPropertyName = "DonViTinh"
        Me.DonViTinh.HeaderText = "Đơn vị tính"
        Me.DonViTinh.Name = "DonViTinh"
        Me.DonViTinh.ReadOnly = True
        '
        'DonGia
        '
        Me.DonGia.DataPropertyName = "DonGia"
        Me.DonGia.HeaderText = "Số tiền"
        Me.DonGia.Name = "DonGia"
        Me.DonGia.ReadOnly = True
        '
        'ThanhTien
        '
        Me.ThanhTien.DataPropertyName = "ThanhTien"
        Me.ThanhTien.HeaderText = "Thành tiền"
        Me.ThanhTien.Name = "ThanhTien"
        Me.ThanhTien.ReadOnly = True
        '
        'Total
        '
        Me.Total.DataPropertyName = "TongCong"
        Me.Total.HeaderText = "Tổng Cộng"
        Me.Total.Name = "Total"
        Me.Total.ReadOnly = True
        Me.Total.Visible = False
        '
        'EditTable
        '
        Me.EditTable.DataPropertyName = "Editable"
        Me.EditTable.HeaderText = "Editable"
        Me.EditTable.Name = "EditTable"
        Me.EditTable.ReadOnly = True
        Me.EditTable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.EditTable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.EditTable.Visible = False
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Visible = False
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "User Update"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "Update Time"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmDel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 26)
        '
        'ctmDel
        '
        Me.ctmDel.Name = "ctmDel"
        Me.ctmDel.Size = New System.Drawing.Size(116, 22)
        Me.ctmDel.Text = "Delete"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(301, 54)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Số tiền :"
        '
        'txtSoTien
        '
        Me.txtSoTien.Location = New System.Drawing.Point(349, 51)
        Me.txtSoTien.Name = "txtSoTien"
        Me.txtSoTien.Size = New System.Drawing.Size(68, 20)
        Me.txtSoTien.TabIndex = 3
        Me.txtSoTien.Text = "25000"
        Me.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbodonvitinh)
        Me.GroupBox1.Controls.Add(Me.cmdAll)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.cmdOkReport)
        Me.GroupBox1.Controls.Add(Me.cmdThem)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cboLoaiContainer)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtSoTien)
        Me.GroupBox1.Controls.Add(Me.txtTongTien)
        Me.GroupBox1.Controls.Add(Me.txtSoLuong)
        Me.GroupBox1.Controls.Add(Me.txtTongCong)
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Location = New System.Drawing.Point(9, 368)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(645, 144)
        Me.GroupBox1.TabIndex = 26
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thêm chi tiết"
        '
        'cmdAll
        '
        Me.cmdAll.Location = New System.Drawing.Point(524, 17)
        Me.cmdAll.Name = "cmdAll"
        Me.cmdAll.Size = New System.Drawing.Size(43, 23)
        Me.cmdAll.TabIndex = 11
        Me.cmdAll.Text = "All"
        Me.cmdAll.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Enabled = False
        Me.cmdSave.Location = New System.Drawing.Point(541, 115)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 7
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdOkReport
        '
        Me.cmdOkReport.Enabled = False
        Me.cmdOkReport.Location = New System.Drawing.Point(450, 115)
        Me.cmdOkReport.Name = "cmdOkReport"
        Me.cmdOkReport.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkReport.TabIndex = 8
        Me.cmdOkReport.Text = "Report"
        Me.cmdOkReport.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label12.Location = New System.Drawing.Point(491, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Series No :"
        '
        'txtSeriesNo
        '
        Me.txtSeriesNo.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.txtSeriesNo.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtSeriesNo.Location = New System.Drawing.Point(551, 121)
        Me.txtSeriesNo.Name = "txtSeriesNo"
        Me.txtSeriesNo.ReadOnly = True
        Me.txtSeriesNo.Size = New System.Drawing.Size(106, 20)
        Me.txtSeriesNo.TabIndex = 5
        '
        'txtNoiDungthu
        '
        Me.txtNoiDungthu.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtNoiDungthu.Location = New System.Drawing.Point(129, 338)
        Me.txtNoiDungthu.Name = "txtNoiDungthu"
        Me.txtNoiDungthu.Size = New System.Drawing.Size(525, 20)
        Me.txtNoiDungthu.TabIndex = 7
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label13.Location = New System.Drawing.Point(47, 341)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "Nội Dung Thu :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(666, 24)
        Me.MenuStrip1.TabIndex = 27
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuNew
        '
        Me.mnuNew.ForeColor = System.Drawing.Color.Maroon
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.Size = New System.Drawing.Size(40, 20)
        Me.mnuNew.Text = "New"
        '
        'cbodonvitinh
        '
        Me.cbodonvitinh.FormattingEnabled = True
        Me.cbodonvitinh.Items.AddRange(New Object() {"VND", "USD"})
        Me.cbodonvitinh.Location = New System.Drawing.Point(121, 51)
        Me.cbodonvitinh.Name = "cbodonvitinh"
        Me.cbodonvitinh.Size = New System.Drawing.Size(54, 21)
        Me.cbodonvitinh.TabIndex = 12
        Me.cbodonvitinh.Text = "VND"
        '
        'frmPhieuThuTien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(666, 524)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgdNoiDungThu)
        Me.Controls.Add(Me.txtBLNo)
        Me.Controls.Add(Me.txtTenKhachHang)
        Me.Controls.Add(Me.txtDiaChi)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtMaSoThue)
        Me.Controls.Add(Me.txtSeriesNo)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtHinhThucThanhToan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNoiDungthu)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MaximumSize = New System.Drawing.Size(674, 558)
        Me.MinimumSize = New System.Drawing.Size(674, 558)
        Me.Name = "frmPhieuThuTien"
        Me.Text = "In Phiếu thu tiền"
        CType(Me.dgdNoiDungThu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdThem As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTongTien As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong As System.Windows.Forms.TextBox
    Friend WithEvents txtHinhThucThanhToan As System.Windows.Forms.TextBox
    Friend WithEvents txtMaSoThue As System.Windows.Forms.TextBox
    Friend WithEvents txtDiaChi As System.Windows.Forms.TextBox
    Friend WithEvents txtTenKhachHang As System.Windows.Forms.TextBox
    Friend WithEvents txtBLNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboLoaiContainer As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTongCong As System.Windows.Forms.TextBox
    Friend WithEvents dgdNoiDungThu As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSoTien As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSeriesNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdOkReport As System.Windows.Forms.Button
    Friend WithEvents txtNoiDungthu As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents PhieuThu_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SeriesNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BLIB_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TenKhachHang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiaChi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaSoThue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HinhThucThanhToan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoiDung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LoaiContainer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DonViTinh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DonGia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThanhTien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditTable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdAll As System.Windows.Forms.Button
    Friend WithEvents cbodonvitinh As System.Windows.Forms.ComboBox
End Class
