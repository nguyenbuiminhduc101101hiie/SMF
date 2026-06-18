<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCargoReceipt
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCargoReceipt))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgdAgency = New System.Windows.Forms.DataGridView()
        Me.cargoReceiptID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.customerid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.refno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vaohoi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nhapxuatchodonvi = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.doongba = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.phuongtiengiaohang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bookingso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.diadiemnhanhang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.USERUPDATE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fraUpdate = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtghichukhac = New System.Windows.Forms.TextBox()
        Me.txtslkhac = New System.Windows.Forms.TextBox()
        Me.txtkhac = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtghichukhongkymahieu = New System.Windows.Forms.TextBox()
        Me.txtslkhongkymahieu = New System.Windows.Forms.TextBox()
        Me.txtkhongkymahieu = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtghichuamuot = New System.Windows.Forms.TextBox()
        Me.txtslamuot = New System.Windows.Forms.TextBox()
        Me.txtamuot = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtghichubep = New System.Windows.Forms.TextBox()
        Me.txtslbep = New System.Windows.Forms.TextBox()
        Me.txtbep = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtghichuthung = New System.Windows.Forms.TextBox()
        Me.txtslthung = New System.Windows.Forms.TextBox()
        Me.txtthung = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtghichurach = New System.Windows.Forms.TextBox()
        Me.txtslrach = New System.Windows.Forms.TextBox()
        Me.txtrach = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtdiadiemnhanhang = New System.Windows.Forms.TextBox()
        Me.txtbookingso = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtvaohoi = New System.Windows.Forms.TextBox()
        Me.txtphuongtiengiao = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtdoongba = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.cbocustomer = New System.Windows.Forms.ComboBox()
        Me.txtngay = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtrefno = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSealNo = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtkichthuoc = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtsoluong = New System.Windows.Forms.TextBox()
        Me.txtstt = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtkymahieu = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dgdPIC = New System.Windows.Forms.DataGridView()
        Me.cargoreceiptdetailID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cargoReceiptID_detail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stt = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kymahieu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soluong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kichthuoc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ctmnuPIC = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddPIC = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPIC = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeletePIC = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdPICOk = New System.Windows.Forms.Button()
        Me.cmdPICCancel = New System.Windows.Forms.Button()
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdAgency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraUpdate.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgdPIC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmnuPIC.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1161, 24)
        Me.MenuStrip.TabIndex = 57
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
        Me.smnuAdd.Text = "&Insert"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(52, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(44, 20)
        Me.smnuExportExcel.Text = "Print"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'dgdAgency
        '
        Me.dgdAgency.AllowUserToAddRows = False
        Me.dgdAgency.AllowUserToDeleteRows = False
        Me.dgdAgency.AllowUserToResizeRows = False
        Me.dgdAgency.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdAgency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdAgency.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdAgency.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdAgency.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdAgency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdAgency.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cargoReceiptID, Me.customerid, Me.refno, Me.vaohoi, Me.ngay, Me.nhapxuatchodonvi, Me.doongba, Me.phuongtiengiaohang, Me.bookingso, Me.diadiemnhanhang, Me.Editable, Me.Continued, Me.Approve, Me.USERUPDATE, Me.dateupdate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdAgency.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgdAgency.Location = New System.Drawing.Point(12, 27)
        Me.dgdAgency.Name = "dgdAgency"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdAgency.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgdAgency.Size = New System.Drawing.Size(1131, 186)
        Me.dgdAgency.TabIndex = 58
        '
        'cargoReceiptID
        '
        Me.cargoReceiptID.DataPropertyName = "cargoReceiptID"
        Me.cargoReceiptID.HeaderText = "cargoReceiptID"
        Me.cargoReceiptID.Name = "cargoReceiptID"
        Me.cargoReceiptID.Visible = False
        Me.cargoReceiptID.Width = 121
        '
        'customerid
        '
        Me.customerid.DataPropertyName = "customerid"
        Me.customerid.HeaderText = "customerid"
        Me.customerid.Name = "customerid"
        Me.customerid.Visible = False
        Me.customerid.Width = 93
        '
        'refno
        '
        Me.refno.DataPropertyName = "refno"
        Me.refno.HeaderText = "Ref. No."
        Me.refno.Name = "refno"
        Me.refno.Width = 56
        '
        'vaohoi
        '
        Me.vaohoi.DataPropertyName = "vaohoi"
        Me.vaohoi.HeaderText = "Vào hồi"
        Me.vaohoi.Name = "vaohoi"
        Me.vaohoi.Width = 54
        '
        'ngay
        '
        Me.ngay.DataPropertyName = "ngay"
        Me.ngay.HeaderText = "Ngày"
        Me.ngay.Name = "ngay"
        Me.ngay.Width = 61
        '
        'nhapxuatchodonvi
        '
        Me.nhapxuatchodonvi.DataPropertyName = "nhapxuatchodonvi"
        Me.nhapxuatchodonvi.HeaderText = "Nhập/Xuất cho"
        Me.nhapxuatchodonvi.Name = "nhapxuatchodonvi"
        Me.nhapxuatchodonvi.Width = 109
        '
        'doongba
        '
        Me.doongba.DataPropertyName = "doongba"
        Me.doongba.HeaderText = "Do ông bà"
        Me.doongba.Name = "doongba"
        Me.doongba.Width = 71
        '
        'phuongtiengiaohang
        '
        Me.phuongtiengiaohang.DataPropertyName = "phuongtiengiaohang"
        Me.phuongtiengiaohang.HeaderText = "Phương tiện giao hàng"
        Me.phuongtiengiaohang.Name = "phuongtiengiaohang"
        Me.phuongtiengiaohang.Width = 121
        '
        'bookingso
        '
        Me.bookingso.DataPropertyName = "bookingso"
        Me.bookingso.HeaderText = "Booking số"
        Me.bookingso.Name = "bookingso"
        Me.bookingso.Width = 87
        '
        'diadiemnhanhang
        '
        Me.diadiemnhanhang.DataPropertyName = "diadiemnhanhang"
        Me.diadiemnhanhang.HeaderText = "Địa điểm nhận hàng"
        Me.diadiemnhanhang.Name = "diadiemnhanhang"
        Me.diadiemnhanhang.Width = 108
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Editable.Visible = False
        Me.Editable.Width = 59
        '
        'Continued
        '
        Me.Continued.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
        '
        'Approve
        '
        Me.Approve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Approve.DataPropertyName = "Approve"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle2
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.ToolTipText = "Duyệt"
        Me.Approve.Width = 79
        '
        'USERUPDATE
        '
        Me.USERUPDATE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.USERUPDATE.DataPropertyName = "UserUPDATE"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.USERUPDATE.DefaultCellStyle = DataGridViewCellStyle3
        Me.USERUPDATE.HeaderText = "User Update"
        Me.USERUPDATE.Name = "USERUPDATE"
        Me.USERUPDATE.ToolTipText = "Ngừơi Cập Nhật"
        Me.USERUPDATE.Width = 95
        '
        'dateupdate
        '
        Me.dateupdate.DataPropertyName = "dateupdate"
        Me.dateupdate.HeaderText = "Date Update"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Width = 96
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.TabPage1)
        Me.fraUpdate.Controls.Add(Me.TabPage2)
        Me.fraUpdate.Location = New System.Drawing.Point(12, 219)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.SelectedIndex = 0
        Me.fraUpdate.Size = New System.Drawing.Size(1131, 373)
        Me.fraUpdate.TabIndex = 59
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.cmdCancel)
        Me.TabPage1.Controls.Add(Me.cmdOK)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1123, 347)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.txtdiadiemnhanhang)
        Me.GroupBox1.Controls.Add(Me.txtbookingso)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtvaohoi)
        Me.GroupBox1.Controls.Add(Me.txtphuongtiengiao)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtdoongba)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtsearch)
        Me.GroupBox1.Controls.Add(Me.cbocustomer)
        Me.GroupBox1.Controls.Add(Me.txtngay)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtrefno)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.lblSealNo)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1111, 302)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.txtghichukhac)
        Me.GroupBox2.Controls.Add(Me.txtslkhac)
        Me.GroupBox2.Controls.Add(Me.txtkhac)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.txtghichukhongkymahieu)
        Me.GroupBox2.Controls.Add(Me.txtslkhongkymahieu)
        Me.GroupBox2.Controls.Add(Me.txtkhongkymahieu)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.txtghichuamuot)
        Me.GroupBox2.Controls.Add(Me.txtslamuot)
        Me.GroupBox2.Controls.Add(Me.txtamuot)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtghichubep)
        Me.GroupBox2.Controls.Add(Me.txtslbep)
        Me.GroupBox2.Controls.Add(Me.txtbep)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.txtghichuthung)
        Me.GroupBox2.Controls.Add(Me.txtslthung)
        Me.GroupBox2.Controls.Add(Me.txtthung)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.txtghichurach)
        Me.GroupBox2.Controls.Add(Me.txtslrach)
        Me.GroupBox2.Controls.Add(Me.txtrach)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(492, 15)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(613, 281)
        Me.GroupBox2.TabIndex = 444
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tình trạng"
        '
        'txtghichukhac
        '
        Me.txtghichukhac.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtghichukhac.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtghichukhac.ForeColor = System.Drawing.Color.Blue
        Me.txtghichukhac.Location = New System.Drawing.Point(402, 216)
        Me.txtghichukhac.Name = "txtghichukhac"
        Me.txtghichukhac.Size = New System.Drawing.Size(204, 22)
        Me.txtghichukhac.TabIndex = 462
        '
        'txtslkhac
        '
        Me.txtslkhac.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtslkhac.ForeColor = System.Drawing.Color.Blue
        Me.txtslkhac.Location = New System.Drawing.Point(241, 216)
        Me.txtslkhac.Name = "txtslkhac"
        Me.txtslkhac.Size = New System.Drawing.Size(155, 22)
        Me.txtslkhac.TabIndex = 461
        '
        'txtkhac
        '
        Me.txtkhac.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkhac.ForeColor = System.Drawing.Color.Blue
        Me.txtkhac.Location = New System.Drawing.Point(178, 216)
        Me.txtkhac.Name = "txtkhac"
        Me.txtkhac.Size = New System.Drawing.Size(24, 22)
        Me.txtkhac.TabIndex = 460
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Blue
        Me.Label25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label25.Location = New System.Drawing.Point(15, 225)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 459
        Me.Label25.Text = "Khác (Others)"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtghichukhongkymahieu
        '
        Me.txtghichukhongkymahieu.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtghichukhongkymahieu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtghichukhongkymahieu.ForeColor = System.Drawing.Color.Blue
        Me.txtghichukhongkymahieu.Location = New System.Drawing.Point(403, 185)
        Me.txtghichukhongkymahieu.Name = "txtghichukhongkymahieu"
        Me.txtghichukhongkymahieu.Size = New System.Drawing.Size(204, 22)
        Me.txtghichukhongkymahieu.TabIndex = 458
        '
        'txtslkhongkymahieu
        '
        Me.txtslkhongkymahieu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtslkhongkymahieu.ForeColor = System.Drawing.Color.Blue
        Me.txtslkhongkymahieu.Location = New System.Drawing.Point(242, 185)
        Me.txtslkhongkymahieu.Name = "txtslkhongkymahieu"
        Me.txtslkhongkymahieu.Size = New System.Drawing.Size(155, 22)
        Me.txtslkhongkymahieu.TabIndex = 457
        '
        'txtkhongkymahieu
        '
        Me.txtkhongkymahieu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkhongkymahieu.ForeColor = System.Drawing.Color.Blue
        Me.txtkhongkymahieu.Location = New System.Drawing.Point(179, 185)
        Me.txtkhongkymahieu.Name = "txtkhongkymahieu"
        Me.txtkhongkymahieu.Size = New System.Drawing.Size(24, 22)
        Me.txtkhongkymahieu.TabIndex = 456
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.ForeColor = System.Drawing.Color.Blue
        Me.Label24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label24.Location = New System.Drawing.Point(16, 194)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(123, 13)
        Me.Label24.TabIndex = 455
        Me.Label24.Text = "Không ký mã hiệu (N/M)"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtghichuamuot
        '
        Me.txtghichuamuot.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtghichuamuot.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtghichuamuot.ForeColor = System.Drawing.Color.Blue
        Me.txtghichuamuot.Location = New System.Drawing.Point(403, 152)
        Me.txtghichuamuot.Name = "txtghichuamuot"
        Me.txtghichuamuot.Size = New System.Drawing.Size(204, 22)
        Me.txtghichuamuot.TabIndex = 454
        '
        'txtslamuot
        '
        Me.txtslamuot.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtslamuot.ForeColor = System.Drawing.Color.Blue
        Me.txtslamuot.Location = New System.Drawing.Point(242, 152)
        Me.txtslamuot.Name = "txtslamuot"
        Me.txtslamuot.Size = New System.Drawing.Size(155, 22)
        Me.txtslamuot.TabIndex = 453
        '
        'txtamuot
        '
        Me.txtamuot.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtamuot.ForeColor = System.Drawing.Color.Blue
        Me.txtamuot.Location = New System.Drawing.Point(179, 152)
        Me.txtamuot.Name = "txtamuot"
        Me.txtamuot.Size = New System.Drawing.Size(24, 22)
        Me.txtamuot.TabIndex = 452
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.ForeColor = System.Drawing.Color.Blue
        Me.Label23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label23.Location = New System.Drawing.Point(16, 161)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(69, 13)
        Me.Label23.TabIndex = 451
        Me.Label23.Text = "Ẩm ướt (Wet)"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtghichubep
        '
        Me.txtghichubep.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtghichubep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtghichubep.ForeColor = System.Drawing.Color.Blue
        Me.txtghichubep.Location = New System.Drawing.Point(402, 120)
        Me.txtghichubep.Name = "txtghichubep"
        Me.txtghichubep.Size = New System.Drawing.Size(204, 22)
        Me.txtghichubep.TabIndex = 450
        '
        'txtslbep
        '
        Me.txtslbep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtslbep.ForeColor = System.Drawing.Color.Blue
        Me.txtslbep.Location = New System.Drawing.Point(241, 120)
        Me.txtslbep.Name = "txtslbep"
        Me.txtslbep.Size = New System.Drawing.Size(155, 22)
        Me.txtslbep.TabIndex = 449
        '
        'txtbep
        '
        Me.txtbep.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbep.ForeColor = System.Drawing.Color.Blue
        Me.txtbep.Location = New System.Drawing.Point(178, 120)
        Me.txtbep.Name = "txtbep"
        Me.txtbep.Size = New System.Drawing.Size(24, 22)
        Me.txtbep.TabIndex = 448
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Blue
        Me.Label22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label22.Location = New System.Drawing.Point(15, 129)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 13)
        Me.Label22.TabIndex = 447
        Me.Label22.Text = "Bẹp (Distored)"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtghichuthung
        '
        Me.txtghichuthung.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtghichuthung.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtghichuthung.ForeColor = System.Drawing.Color.Blue
        Me.txtghichuthung.Location = New System.Drawing.Point(402, 87)
        Me.txtghichuthung.Name = "txtghichuthung"
        Me.txtghichuthung.Size = New System.Drawing.Size(204, 22)
        Me.txtghichuthung.TabIndex = 446
        '
        'txtslthung
        '
        Me.txtslthung.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtslthung.ForeColor = System.Drawing.Color.Blue
        Me.txtslthung.Location = New System.Drawing.Point(241, 87)
        Me.txtslthung.Name = "txtslthung"
        Me.txtslthung.Size = New System.Drawing.Size(155, 22)
        Me.txtslthung.TabIndex = 445
        '
        'txtthung
        '
        Me.txtthung.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtthung.ForeColor = System.Drawing.Color.Blue
        Me.txtthung.Location = New System.Drawing.Point(178, 87)
        Me.txtthung.Name = "txtthung"
        Me.txtthung.Size = New System.Drawing.Size(24, 22)
        Me.txtthung.TabIndex = 444
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Blue
        Me.Label21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label21.Location = New System.Drawing.Point(15, 96)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(69, 13)
        Me.Label21.TabIndex = 443
        Me.Label21.Text = "Thủng (Hole)"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtghichurach
        '
        Me.txtghichurach.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtghichurach.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtghichurach.ForeColor = System.Drawing.Color.Blue
        Me.txtghichurach.Location = New System.Drawing.Point(403, 56)
        Me.txtghichurach.Name = "txtghichurach"
        Me.txtghichurach.Size = New System.Drawing.Size(204, 22)
        Me.txtghichurach.TabIndex = 442
        '
        'txtslrach
        '
        Me.txtslrach.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtslrach.ForeColor = System.Drawing.Color.Blue
        Me.txtslrach.Location = New System.Drawing.Point(242, 56)
        Me.txtslrach.Name = "txtslrach"
        Me.txtslrach.Size = New System.Drawing.Size(155, 22)
        Me.txtslrach.TabIndex = 441
        '
        'txtrach
        '
        Me.txtrach.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrach.ForeColor = System.Drawing.Color.Blue
        Me.txtrach.Location = New System.Drawing.Point(179, 56)
        Me.txtrach.Name = "txtrach"
        Me.txtrach.Size = New System.Drawing.Size(24, 22)
        Me.txtrach.TabIndex = 440
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.ForeColor = System.Drawing.Color.Blue
        Me.Label20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label20.Location = New System.Drawing.Point(16, 65)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 5
        Me.Label20.Text = "Rách (Cut)"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label19.Location = New System.Drawing.Point(400, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(44, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Ghi chú"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(239, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Số lượng"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(16, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Tình trạng"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdiadiemnhanhang
        '
        Me.txtdiadiemnhanhang.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdiadiemnhanhang.ForeColor = System.Drawing.Color.Blue
        Me.txtdiadiemnhanhang.Location = New System.Drawing.Point(117, 226)
        Me.txtdiadiemnhanhang.Multiline = True
        Me.txtdiadiemnhanhang.Name = "txtdiadiemnhanhang"
        Me.txtdiadiemnhanhang.Size = New System.Drawing.Size(369, 59)
        Me.txtdiadiemnhanhang.TabIndex = 443
        '
        'txtbookingso
        '
        Me.txtbookingso.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbookingso.ForeColor = System.Drawing.Color.Blue
        Me.txtbookingso.Location = New System.Drawing.Point(117, 195)
        Me.txtbookingso.Name = "txtbookingso"
        Me.txtbookingso.Size = New System.Drawing.Size(369, 22)
        Me.txtbookingso.TabIndex = 442
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(6, 200)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 441
        Me.Label5.Text = "Giao theo Booking :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label16.Location = New System.Drawing.Point(282, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 13)
        Me.Label16.TabIndex = 440
        Me.Label16.Text = "Vào hồi:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtvaohoi
        '
        Me.txtvaohoi.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtvaohoi.ForeColor = System.Drawing.Color.Blue
        Me.txtvaohoi.Location = New System.Drawing.Point(332, 15)
        Me.txtvaohoi.Name = "txtvaohoi"
        Me.txtvaohoi.Size = New System.Drawing.Size(90, 22)
        Me.txtvaohoi.TabIndex = 439
        '
        'txtphuongtiengiao
        '
        Me.txtphuongtiengiao.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtphuongtiengiao.ForeColor = System.Drawing.Color.Blue
        Me.txtphuongtiengiao.Location = New System.Drawing.Point(117, 167)
        Me.txtphuongtiengiao.Name = "txtphuongtiengiao"
        Me.txtphuongtiengiao.Size = New System.Drawing.Size(369, 22)
        Me.txtphuongtiengiao.TabIndex = 438
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(6, 172)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(90, 13)
        Me.Label14.TabIndex = 437
        Me.Label14.Text = "Phương tiện giao:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(6, 231)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 435
        Me.Label8.Text = "Địa điểm nhận hàng:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(6, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 428
        Me.Label4.Text = "Do ông bà:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtdoongba
        '
        Me.txtdoongba.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtdoongba.ForeColor = System.Drawing.Color.Blue
        Me.txtdoongba.Location = New System.Drawing.Point(117, 139)
        Me.txtdoongba.Name = "txtdoongba"
        Me.txtdoongba.Size = New System.Drawing.Size(369, 22)
        Me.txtdoongba.TabIndex = 427
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(219, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(45, 23)
        Me.Button2.TabIndex = 426
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(117, 47)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(95, 20)
        Me.DateTimePicker1.TabIndex = 425
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(441, 80)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 23)
        Me.Button1.TabIndex = 424
        Me.Button1.Text = ">"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtsearch
        '
        Me.txtsearch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsearch.ForeColor = System.Drawing.Color.Blue
        Me.txtsearch.Location = New System.Drawing.Point(117, 80)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(318, 22)
        Me.txtsearch.TabIndex = 423
        '
        'cbocustomer
        '
        Me.cbocustomer.FormattingEnabled = True
        Me.cbocustomer.Location = New System.Drawing.Point(117, 112)
        Me.cbocustomer.Name = "cbocustomer"
        Me.cbocustomer.Size = New System.Drawing.Size(369, 21)
        Me.cbocustomer.TabIndex = 5
        '
        'txtngay
        '
        Me.txtngay.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtngay.ForeColor = System.Drawing.Color.Blue
        Me.txtngay.Location = New System.Drawing.Point(270, 47)
        Me.txtngay.Name = "txtngay"
        Me.txtngay.Size = New System.Drawing.Size(216, 22)
        Me.txtngay.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(6, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Date (Ngày) :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtrefno
        '
        Me.txtrefno.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtrefno.ForeColor = System.Drawing.Color.Blue
        Me.txtrefno.Location = New System.Drawing.Point(117, 15)
        Me.txtrefno.Name = "txtrefno"
        Me.txtrefno.Size = New System.Drawing.Size(45, 22)
        Me.txtrefno.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(6, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Company (C.ty gửi)  :"
        '
        'lblSealNo
        '
        Me.lblSealNo.AutoSize = True
        Me.lblSealNo.ForeColor = System.Drawing.Color.Blue
        Me.lblSealNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSealNo.Location = New System.Drawing.Point(6, 22)
        Me.lblSealNo.Name = "lblSealNo"
        Me.lblSealNo.Size = New System.Drawing.Size(72, 13)
        Me.lblSealNo.TabIndex = 1
        Me.lblSealNo.Text = "Ref. No. (Số):"
        Me.lblSealNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(10, 307)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(57, 27)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOK
        '
        Me.cmdOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(69, 307)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(58, 27)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtkichthuoc)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.txtsoluong)
        Me.TabPage2.Controls.Add(Me.txtstt)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtkymahieu)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.dgdPIC)
        Me.TabPage2.Controls.Add(Me.cmdPICOk)
        Me.TabPage2.Controls.Add(Me.cmdPICCancel)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1123, 347)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Details"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtkichthuoc
        '
        Me.txtkichthuoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtkichthuoc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkichthuoc.Location = New System.Drawing.Point(589, 243)
        Me.txtkichthuoc.Name = "txtkichthuoc"
        Me.txtkichthuoc.Size = New System.Drawing.Size(286, 21)
        Me.txtkichthuoc.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.Location = New System.Drawing.Point(522, 247)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "Kích thước:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.Location = New System.Drawing.Point(388, 248)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "SL. :"
        '
        'txtsoluong
        '
        Me.txtsoluong.BackColor = System.Drawing.Color.PeachPuff
        Me.txtsoluong.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtsoluong.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtsoluong.Location = New System.Drawing.Point(421, 243)
        Me.txtsoluong.Name = "txtsoluong"
        Me.txtsoluong.Size = New System.Drawing.Size(83, 21)
        Me.txtsoluong.TabIndex = 11
        '
        'txtstt
        '
        Me.txtstt.FormattingEnabled = True
        Me.txtstt.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20"})
        Me.txtstt.Location = New System.Drawing.Point(79, 243)
        Me.txtstt.Name = "txtstt"
        Me.txtstt.Size = New System.Drawing.Size(54, 21)
        Me.txtstt.TabIndex = 1
        Me.txtstt.Text = "1"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(6, 247)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(69, 13)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "No. (Số TT) :"
        '
        'txtkymahieu
        '
        Me.txtkymahieu.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtkymahieu.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtkymahieu.Location = New System.Drawing.Point(227, 243)
        Me.txtkymahieu.Name = "txtkymahieu"
        Me.txtkymahieu.Size = New System.Drawing.Size(155, 21)
        Me.txtkymahieu.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(156, 248)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(65, 13)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Ký mã hiệu :"
        '
        'dgdPIC
        '
        Me.dgdPIC.AllowUserToAddRows = False
        Me.dgdPIC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdPIC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdPIC.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdPIC.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPIC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgdPIC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPIC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cargoreceiptdetailID, Me.cargoReceiptID_detail, Me.stt, Me.kymahieu, Me.soluong, Me.kichthuoc})
        Me.dgdPIC.ContextMenuStrip = Me.ctmnuPIC
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdPIC.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgdPIC.Location = New System.Drawing.Point(6, 6)
        Me.dgdPIC.Name = "dgdPIC"
        Me.dgdPIC.Size = New System.Drawing.Size(1111, 229)
        Me.dgdPIC.TabIndex = 50
        '
        'cargoreceiptdetailID
        '
        Me.cargoreceiptdetailID.DataPropertyName = "cargoreceiptdetailID"
        Me.cargoreceiptdetailID.HeaderText = "cargoreceiptdetailID"
        Me.cargoreceiptdetailID.Name = "cargoreceiptdetailID"
        Me.cargoreceiptdetailID.Visible = False
        Me.cargoreceiptdetailID.Width = 127
        '
        'cargoReceiptID_detail
        '
        Me.cargoReceiptID_detail.DataPropertyName = "cargoReceiptID"
        Me.cargoReceiptID_detail.HeaderText = "cargoReceiptID"
        Me.cargoReceiptID_detail.Name = "cargoReceiptID_detail"
        Me.cargoReceiptID_detail.Visible = False
        Me.cargoReceiptID_detail.Width = 107
        '
        'stt
        '
        Me.stt.DataPropertyName = "stt"
        Me.stt.HeaderText = "STT"
        Me.stt.Name = "stt"
        Me.stt.Width = 53
        '
        'kymahieu
        '
        Me.kymahieu.DataPropertyName = "kymahieu"
        Me.kymahieu.HeaderText = "Ký mã hiệu"
        Me.kymahieu.Name = "kymahieu"
        Me.kymahieu.Width = 84
        '
        'soluong
        '
        Me.soluong.DataPropertyName = "soluong"
        Me.soluong.HeaderText = "Số lượng"
        Me.soluong.Name = "soluong"
        Me.soluong.Width = 74
        '
        'kichthuoc
        '
        Me.kichthuoc.DataPropertyName = "kichthuoc"
        Me.kichthuoc.HeaderText = "Kích thước"
        Me.kichthuoc.Name = "kichthuoc"
        Me.kichthuoc.Width = 85
        '
        'ctmnuPIC
        '
        Me.ctmnuPIC.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddPIC, Me.EditPIC, Me.DeletePIC})
        Me.ctmnuPIC.Name = "ctmnuPIC"
        Me.ctmnuPIC.Size = New System.Drawing.Size(108, 70)
        '
        'AddPIC
        '
        Me.AddPIC.Name = "AddPIC"
        Me.AddPIC.Size = New System.Drawing.Size(107, 22)
        Me.AddPIC.Text = "Add"
        '
        'EditPIC
        '
        Me.EditPIC.Name = "EditPIC"
        Me.EditPIC.Size = New System.Drawing.Size(107, 22)
        Me.EditPIC.Text = "Edit"
        '
        'DeletePIC
        '
        Me.DeletePIC.Name = "DeletePIC"
        Me.DeletePIC.Size = New System.Drawing.Size(107, 22)
        Me.DeletePIC.Text = "Delete"
        '
        'cmdPICOk
        '
        Me.cmdPICOk.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdPICOk.Location = New System.Drawing.Point(92, 308)
        Me.cmdPICOk.Name = "cmdPICOk"
        Me.cmdPICOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdPICOk.TabIndex = 20
        Me.cmdPICOk.Text = "Ok"
        Me.cmdPICOk.UseVisualStyleBackColor = True
        '
        'cmdPICCancel
        '
        Me.cmdPICCancel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.cmdPICCancel.Location = New System.Drawing.Point(11, 308)
        Me.cmdPICCancel.Name = "cmdPICCancel"
        Me.cmdPICCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdPICCancel.TabIndex = 19
        Me.cmdPICCancel.Text = "Cancel"
        Me.cmdPICCancel.UseVisualStyleBackColor = True
        '
        'frmCargoReceipt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 605)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.dgdAgency)
        Me.Controls.Add(Me.fraUpdate)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.Name = "frmCargoReceipt"
        Me.Text = "Cargo Receipt"
        Me.MenuStrip.ResumeLayout(false)
        Me.MenuStrip.PerformLayout
        CType(Me.dgdAgency,System.ComponentModel.ISupportInitialize).EndInit
        Me.fraUpdate.ResumeLayout(false)
        Me.TabPage1.ResumeLayout(false)
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        Me.TabPage2.ResumeLayout(false)
        Me.TabPage2.PerformLayout
        CType(Me.dgdPIC,System.ComponentModel.ISupportInitialize).EndInit
        Me.ctmnuPIC.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdAgency As System.Windows.Forms.DataGridView
    Friend WithEvents fraUpdate As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtphuongtiengiao As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtdoongba As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents cbocustomer As System.Windows.Forms.ComboBox
    Friend WithEvents txtngay As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtrefno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSealNo As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtkichthuoc As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtsoluong As System.Windows.Forms.TextBox
    Friend WithEvents txtstt As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtkymahieu As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgdPIC As System.Windows.Forms.DataGridView
    Friend WithEvents ctmnuPIC As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddPIC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPIC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeletePIC As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdPICOk As System.Windows.Forms.Button
    Friend WithEvents cmdPICCancel As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtvaohoi As System.Windows.Forms.TextBox
    Friend WithEvents txtbookingso As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdiadiemnhanhang As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtghichurach As System.Windows.Forms.TextBox
    Friend WithEvents txtslrach As System.Windows.Forms.TextBox
    Friend WithEvents txtrach As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtghichuthung As System.Windows.Forms.TextBox
    Friend WithEvents txtslthung As System.Windows.Forms.TextBox
    Friend WithEvents txtthung As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtghichubep As System.Windows.Forms.TextBox
    Friend WithEvents txtslbep As System.Windows.Forms.TextBox
    Friend WithEvents txtbep As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtghichuamuot As System.Windows.Forms.TextBox
    Friend WithEvents txtslamuot As System.Windows.Forms.TextBox
    Friend WithEvents txtamuot As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtghichukhongkymahieu As System.Windows.Forms.TextBox
    Friend WithEvents txtslkhongkymahieu As System.Windows.Forms.TextBox
    Friend WithEvents txtkhongkymahieu As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtghichukhac As System.Windows.Forms.TextBox
    Friend WithEvents txtslkhac As System.Windows.Forms.TextBox
    Friend WithEvents txtkhac As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents cargoreceiptdetailID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cargoReceiptID_detail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kymahieu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents soluong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kichthuoc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cargoReceiptID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customerid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents refno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vaohoi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nhapxuatchodonvi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents doongba As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents phuongtiengiaohang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bookingso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents diadiemnhanhang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents USERUPDATE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
