<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNhatkysuachua
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNhatkysuachua))
        Me.fraUpdate = New System.Windows.Forms.TabControl()
        Me.tbcCongTy = New System.Windows.Forms.TabPage()
        Me.cbosoxe = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtchietkhau = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtthanhtien = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtthue = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtdongia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtsoluong = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtlitdau = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txttenphi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.txtthoigian = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtso = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txttinhtrang = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cboBookingOffice = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.lblcompany = New System.Windows.Forms.Label()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuPrint = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgdContianerOutboundNotify = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.nhatkysuachuaID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thietbiID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUSTOMERID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chinhanh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.so = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thoigian = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.litdau = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tinhtrang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tenphi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soluong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dongia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.thanhtien = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chietkhau = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fraUpdate.SuspendLayout()
        Me.tbcCongTy.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdContianerOutboundNotify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraUpdate.Controls.Add(Me.tbcCongTy)
        Me.fraUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUpdate.Location = New System.Drawing.Point(14, 274)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.SelectedIndex = 0
        Me.fraUpdate.ShowToolTips = True
        Me.fraUpdate.Size = New System.Drawing.Size(1056, 337)
        Me.fraUpdate.TabIndex = 2431
        '
        'tbcCongTy
        '
        Me.tbcCongTy.BackColor = System.Drawing.Color.PaleGreen
        Me.tbcCongTy.Controls.Add(Me.cbosoxe)
        Me.tbcCongTy.Controls.Add(Me.Label13)
        Me.tbcCongTy.Controls.Add(Me.txtchietkhau)
        Me.tbcCongTy.Controls.Add(Me.Label12)
        Me.tbcCongTy.Controls.Add(Me.txtthanhtien)
        Me.tbcCongTy.Controls.Add(Me.Label11)
        Me.tbcCongTy.Controls.Add(Me.txtthue)
        Me.tbcCongTy.Controls.Add(Me.Label9)
        Me.tbcCongTy.Controls.Add(Me.txtdongia)
        Me.tbcCongTy.Controls.Add(Me.Label8)
        Me.tbcCongTy.Controls.Add(Me.txtsoluong)
        Me.tbcCongTy.Controls.Add(Me.Label7)
        Me.tbcCongTy.Controls.Add(Me.txtlitdau)
        Me.tbcCongTy.Controls.Add(Me.Label6)
        Me.tbcCongTy.Controls.Add(Me.txttenphi)
        Me.tbcCongTy.Controls.Add(Me.Label3)
        Me.tbcCongTy.Controls.Add(Me.Label1)
        Me.tbcCongTy.Controls.Add(Me.dtpNgay)
        Me.tbcCongTy.Controls.Add(Me.txtthoigian)
        Me.tbcCongTy.Controls.Add(Me.Button2)
        Me.tbcCongTy.Controls.Add(Me.TextBox1)
        Me.tbcCongTy.Controls.Add(Me.txtso)
        Me.tbcCongTy.Controls.Add(Me.Label5)
        Me.tbcCongTy.Controls.Add(Me.txttinhtrang)
        Me.tbcCongTy.Controls.Add(Me.Label4)
        Me.tbcCongTy.Controls.Add(Me.cboBookingOffice)
        Me.tbcCongTy.Controls.Add(Me.Label2)
        Me.tbcCongTy.Controls.Add(Me.cmdOK)
        Me.tbcCongTy.Controls.Add(Me.Label10)
        Me.tbcCongTy.Controls.Add(Me.cmdCancel)
        Me.tbcCongTy.Controls.Add(Me.cboCompany)
        Me.tbcCongTy.Controls.Add(Me.lblcompany)
        Me.tbcCongTy.ForeColor = System.Drawing.Color.Blue
        Me.tbcCongTy.Location = New System.Drawing.Point(4, 22)
        Me.tbcCongTy.Name = "tbcCongTy"
        Me.tbcCongTy.Padding = New System.Windows.Forms.Padding(3)
        Me.tbcCongTy.Size = New System.Drawing.Size(1048, 311)
        Me.tbcCongTy.TabIndex = 0
        Me.tbcCongTy.Tag = " "
        Me.tbcCongTy.Text = "Information"
        Me.tbcCongTy.ToolTipText = "Thông Tin Công Ty"
        Me.tbcCongTy.UseVisualStyleBackColor = True
        '
        'cbosoxe
        '
        Me.cbosoxe.DropDownWidth = 400
        Me.cbosoxe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbosoxe.FormattingEnabled = True
        Me.cbosoxe.Items.AddRange(New Object() {"HAN", "HPH", "SGN", "DAD"})
        Me.cbosoxe.Location = New System.Drawing.Point(130, 83)
        Me.cbosoxe.Name = "cbosoxe"
        Me.cbosoxe.Size = New System.Drawing.Size(240, 23)
        Me.cbosoxe.TabIndex = 89
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.SystemColors.Window
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(9, 88)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 88
        Me.Label13.Text = "(Số xe):"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtchietkhau
        '
        Me.txtchietkhau.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtchietkhau.Location = New System.Drawing.Point(463, 122)
        Me.txtchietkhau.Multiline = True
        Me.txtchietkhau.Name = "txtchietkhau"
        Me.txtchietkhau.Size = New System.Drawing.Size(93, 20)
        Me.txtchietkhau.TabIndex = 87
        Me.txtchietkhau.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(391, 125)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 86
        Me.Label12.Text = "(Chiết khấu):"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtthanhtien
        '
        Me.txtthanhtien.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtthanhtien.Location = New System.Drawing.Point(463, 147)
        Me.txtthanhtien.Multiline = True
        Me.txtthanhtien.Name = "txtthanhtien"
        Me.txtthanhtien.Size = New System.Drawing.Size(93, 20)
        Me.txtthanhtien.TabIndex = 85
        Me.txtthanhtien.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(391, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "(Thành tiền):"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtthue
        '
        Me.txtthue.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtthue.Location = New System.Drawing.Point(463, 97)
        Me.txtthue.Multiline = True
        Me.txtthue.Name = "txtthue"
        Me.txtthue.Size = New System.Drawing.Size(93, 20)
        Me.txtthue.TabIndex = 83
        Me.txtthue.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(391, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "(Thuế):"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdongia
        '
        Me.txtdongia.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtdongia.Location = New System.Drawing.Point(463, 71)
        Me.txtdongia.Multiline = True
        Me.txtdongia.Name = "txtdongia"
        Me.txtdongia.Size = New System.Drawing.Size(93, 20)
        Me.txtdongia.TabIndex = 81
        Me.txtdongia.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(391, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "(Đơn giá):"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtsoluong
        '
        Me.txtsoluong.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.txtsoluong.Location = New System.Drawing.Point(463, 44)
        Me.txtsoluong.Multiline = True
        Me.txtsoluong.Name = "txtsoluong"
        Me.txtsoluong.Size = New System.Drawing.Size(93, 20)
        Me.txtsoluong.TabIndex = 79
        Me.txtsoluong.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(391, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 13)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "(Số lượng) :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtlitdau
        '
        Me.txtlitdau.Location = New System.Drawing.Point(130, 170)
        Me.txtlitdau.Multiline = True
        Me.txtlitdau.Name = "txtlitdau"
        Me.txtlitdau.Size = New System.Drawing.Size(240, 20)
        Me.txtlitdau.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(10, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "(Lít dầu):"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txttenphi
        '
        Me.txttenphi.Location = New System.Drawing.Point(130, 250)
        Me.txttenphi.Multiline = True
        Me.txttenphi.Name = "txttenphi"
        Me.txttenphi.Size = New System.Drawing.Size(240, 20)
        Me.txttenphi.TabIndex = 75
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(10, 254)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "(Tên phí):"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(10, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "(Ngày) :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(130, 57)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(240, 20)
        Me.dtpNgay.TabIndex = 72
        '
        'txtthoigian
        '
        Me.txtthoigian.Location = New System.Drawing.Point(130, 144)
        Me.txtthoigian.Multiline = True
        Me.txtthoigian.Name = "txtthoigian"
        Me.txtthoigian.Size = New System.Drawing.Size(240, 20)
        Me.txtthoigian.TabIndex = 37
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(195, 114)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(16, 23)
        Me.Button2.TabIndex = 8
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(130, 116)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(62, 20)
        Me.TextBox1.TabIndex = 7
        '
        'txtso
        '
        Me.txtso.Location = New System.Drawing.Point(131, 35)
        Me.txtso.Name = "txtso"
        Me.txtso.Size = New System.Drawing.Size(239, 20)
        Me.txtso.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(10, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "(Tình trạng):"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txttinhtrang
        '
        Me.txttinhtrang.Location = New System.Drawing.Point(130, 200)
        Me.txttinhtrang.Multiline = True
        Me.txttinhtrang.Name = "txttinhtrang"
        Me.txttinhtrang.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txttinhtrang.Size = New System.Drawing.Size(240, 44)
        Me.txttinhtrang.TabIndex = 23
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(10, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "(Số) :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboBookingOffice
        '
        Me.cboBookingOffice.DropDownWidth = 400
        Me.cboBookingOffice.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBookingOffice.FormattingEnabled = True
        Me.cboBookingOffice.Items.AddRange(New Object() {"HAN", "HPH", "SGN", "DAD"})
        Me.cboBookingOffice.Location = New System.Drawing.Point(131, 9)
        Me.cboBookingOffice.Name = "cboBookingOffice"
        Me.cboBookingOffice.Size = New System.Drawing.Size(69, 23)
        Me.cboBookingOffice.TabIndex = 1
        Me.cboBookingOffice.Text = "HAN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(10, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(106, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Branch (chi nhánh)  :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(133, 276)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(53, 24)
        Me.cmdOK.TabIndex = 44
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(10, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(60, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "(Thời gian):"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(195, 276)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(55, 24)
        Me.cmdCancel.TabIndex = 45
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cboCompany
        '
        Me.cboCompany.DropDownWidth = 400
        Me.cboCompany.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.Location = New System.Drawing.Point(215, 115)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(155, 23)
        Me.cboCompany.TabIndex = 9
        '
        'lblcompany
        '
        Me.lblcompany.AutoSize = True
        Me.lblcompany.BackColor = System.Drawing.SystemColors.Window
        Me.lblcompany.ForeColor = System.Drawing.Color.Maroon
        Me.lblcompany.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblcompany.Location = New System.Drawing.Point(10, 120)
        Me.lblcompany.Name = "lblcompany"
        Me.lblcompany.Size = New System.Drawing.Size(97, 13)
        Me.lblcompany.TabIndex = 6
        Me.lblcompany.Text = "(Đơn vị sửa chữa ):"
        Me.lblcompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.InsertToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.smnuPrint, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1082, 24)
        Me.MenuStrip.TabIndex = 2432
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "&Search"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InsertToolStripMenuItem.Text = "Insert"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(39, 20)
        Me.EditToolStripMenuItem.Text = "&Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'smnuPrint
        '
        Me.smnuPrint.ForeColor = System.Drawing.Color.Maroon
        Me.smnuPrint.Name = "smnuPrint"
        Me.smnuPrint.Size = New System.Drawing.Size(44, 20)
        Me.smnuPrint.Text = "&Print"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'dgdContianerOutboundNotify
        '
        Me.dgdContianerOutboundNotify.AllowUserToAddRows = False
        Me.dgdContianerOutboundNotify.AllowUserToDeleteRows = False
        Me.dgdContianerOutboundNotify.AllowUserToOrderColumns = True
        Me.dgdContianerOutboundNotify.AllowUserToResizeColumns = False
        Me.dgdContianerOutboundNotify.AllowUserToResizeRows = False
        Me.dgdContianerOutboundNotify.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdContianerOutboundNotify.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdContianerOutboundNotify.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdContianerOutboundNotify.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContianerOutboundNotify.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdContianerOutboundNotify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContianerOutboundNotify.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.nhatkysuachuaID, Me.thietbiID, Me.CUSTOMERID, Me.chinhanh, Me.so, Me.ngay, Me.thoigian, Me.litdau, Me.tinhtrang, Me.tenphi, Me.soluong, Me.dongia, Me.thue, Me.thanhtien, Me.chietkhau, Me.approve, Me.Editable, Me.Continued, Me.Dateupdate, Me.userupdate})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdContianerOutboundNotify.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgdContianerOutboundNotify.Location = New System.Drawing.Point(14, 29)
        Me.dgdContianerOutboundNotify.Name = "dgdContianerOutboundNotify"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContianerOutboundNotify.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgdContianerOutboundNotify.Size = New System.Drawing.Size(1056, 239)
        Me.dgdContianerOutboundNotify.TabIndex = 2433
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'nhatkysuachuaID
        '
        Me.nhatkysuachuaID.DataPropertyName = "nhatkysuachuaID"
        Me.nhatkysuachuaID.HeaderText = "nhatkysuachuaID"
        Me.nhatkysuachuaID.Name = "nhatkysuachuaID"
        Me.nhatkysuachuaID.Visible = False
        Me.nhatkysuachuaID.Width = 131
        '
        'thietbiID
        '
        Me.thietbiID.DataPropertyName = "thietbiID"
        Me.thietbiID.HeaderText = "thietbiID"
        Me.thietbiID.Name = "thietbiID"
        Me.thietbiID.Visible = False
        Me.thietbiID.Width = 80
        '
        'CUSTOMERID
        '
        Me.CUSTOMERID.DataPropertyName = "CUSTOMERID"
        Me.CUSTOMERID.HeaderText = "customerid"
        Me.CUSTOMERID.Name = "CUSTOMERID"
        Me.CUSTOMERID.Visible = False
        Me.CUSTOMERID.Width = 93
        '
        'chinhanh
        '
        Me.chinhanh.DataPropertyName = "chinhanh"
        Me.chinhanh.HeaderText = "Chi nhánh"
        Me.chinhanh.Name = "chinhanh"
        Me.chinhanh.Width = 89
        '
        'so
        '
        Me.so.DataPropertyName = "so"
        Me.so.HeaderText = "Số phiếu"
        Me.so.Name = "so"
        Me.so.Width = 82
        '
        'ngay
        '
        Me.ngay.DataPropertyName = "ngay"
        Me.ngay.HeaderText = "Ngày"
        Me.ngay.Name = "ngay"
        Me.ngay.Width = 61
        '
        'thoigian
        '
        Me.thoigian.DataPropertyName = "thoigian"
        Me.thoigian.HeaderText = "Thời gian"
        Me.thoigian.Name = "thoigian"
        Me.thoigian.Width = 85
        '
        'litdau
        '
        Me.litdau.DataPropertyName = "litdau"
        Me.litdau.HeaderText = "Lít dầu"
        Me.litdau.Name = "litdau"
        Me.litdau.Width = 73
        '
        'tinhtrang
        '
        Me.tinhtrang.DataPropertyName = "tinhtrang"
        Me.tinhtrang.HeaderText = "Tình trạng"
        Me.tinhtrang.Name = "tinhtrang"
        Me.tinhtrang.Width = 90
        '
        'tenphi
        '
        Me.tenphi.DataPropertyName = "tenphi"
        Me.tenphi.HeaderText = "Tên phí"
        Me.tenphi.Name = "tenphi"
        Me.tenphi.Width = 77
        '
        'soluong
        '
        Me.soluong.DataPropertyName = "soluong"
        Me.soluong.HeaderText = "Số lượng"
        Me.soluong.Name = "soluong"
        Me.soluong.Width = 82
        '
        'dongia
        '
        Me.dongia.DataPropertyName = "dongia"
        Me.dongia.HeaderText = "Đơn giá"
        Me.dongia.Name = "dongia"
        Me.dongia.Width = 76
        '
        'thue
        '
        Me.thue.DataPropertyName = "thue"
        Me.thue.HeaderText = "Thuế"
        Me.thue.Name = "thue"
        Me.thue.Width = 61
        '
        'thanhtien
        '
        Me.thanhtien.DataPropertyName = "thanhtien"
        Me.thanhtien.HeaderText = "Thành tiền"
        Me.thanhtien.Name = "thanhtien"
        Me.thanhtien.Width = 93
        '
        'chietkhau
        '
        Me.chietkhau.DataPropertyName = "chietkhau"
        Me.chietkhau.HeaderText = "Chiết khấu"
        Me.chietkhau.Name = "chietkhau"
        Me.chietkhau.Width = 93
        '
        'approve
        '
        Me.approve.DataPropertyName = "approve"
        Me.approve.HeaderText = "Approve"
        Me.approve.Name = "approve"
        Me.approve.Width = 79
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.Visible = False
        Me.Editable.Width = 78
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
        Me.Continued.Width = 89
        '
        'Dateupdate
        '
        Me.Dateupdate.DataPropertyName = "Dateupdate"
        Me.Dateupdate.HeaderText = "Date Update"
        Me.Dateupdate.Name = "Dateupdate"
        Me.Dateupdate.Width = 96
        '
        'userupdate
        '
        Me.userupdate.DataPropertyName = "userupdate"
        Me.userupdate.HeaderText = "User Update"
        Me.userupdate.Name = "userupdate"
        Me.userupdate.Width = 95
        '
        'frmNhatkysuachua
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 620)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.dgdContianerOutboundNotify)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmNhatkysuachua"
        Me.Text = "Nhật ký sửa chữa"
        Me.fraUpdate.ResumeLayout(False)
        Me.tbcCongTy.ResumeLayout(False)
        Me.tbcCongTy.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.dgdContianerOutboundNotify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.TabControl
    Friend WithEvents tbcCongTy As System.Windows.Forms.TabPage
    Friend WithEvents txtthoigian As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtso As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txttinhtrang As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboBookingOffice As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents lblcompany As System.Windows.Forms.Label
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdContianerOutboundNotify As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txttenphi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtthue As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtdongia As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtsoluong As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtlitdau As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtthanhtien As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtchietkhau As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbosoxe As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents nhatkysuachuaID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents thietbiID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMERID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chinhanh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents so As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents thoigian As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents litdau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tinhtrang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tenphi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents soluong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dongia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents thue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents thanhtien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chietkhau As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents approve As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
