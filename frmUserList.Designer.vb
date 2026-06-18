<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserList
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdUsr = New System.Windows.Forms.DataGridView
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblCharge = New System.Windows.Forms.Label
        Me.lblChargeCode = New System.Windows.Forms.Label
        Me.txtUserName = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.txtfax = New System.Windows.Forms.TextBox
        Me.txtExt = New System.Windows.Forms.TextBox
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.txtTel = New System.Windows.Forms.TextBox
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.txtNickname = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboDepartment = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtFind = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.cbomn1 = New System.Windows.Forms.ComboBox
        Me.cbomn2 = New System.Windows.Forms.ComboBox
        Me.cbomn3 = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.UsrID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserRightDepartmentID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Department = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NickName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ext = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mobile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdUsr, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraUpdate.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(52, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'dgdUsr
        '
        Me.dgdUsr.AllowUserToAddRows = False
        Me.dgdUsr.AllowUserToDeleteRows = False
        Me.dgdUsr.AllowUserToResizeRows = False
        Me.dgdUsr.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdUsr.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdUsr.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdUsr.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdUsr.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UsrID, Me.UserRightDepartmentID, Me.Username, Me.FullName, Me.Department, Me.mn1, Me.mn2, Me.mn3, Me.NickName, Me.Tel, Me.Ext, Me.Mobile, Me.Fax, Me.Email, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdUsr.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgdUsr.Location = New System.Drawing.Point(12, 58)
        Me.dgdUsr.Name = "dgdUsr"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdUsr.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgdUsr.Size = New System.Drawing.Size(746, 174)
        Me.dgdUsr.TabIndex = 0
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'lblCharge
        '
        Me.lblCharge.AutoSize = True
        Me.lblCharge.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCharge.Location = New System.Drawing.Point(40, 61)
        Me.lblCharge.Name = "lblCharge"
        Me.lblCharge.Size = New System.Drawing.Size(60, 13)
        Me.lblCharge.TabIndex = 19
        Me.lblCharge.Text = "Full Name :"
        Me.ToolTip1.SetToolTip(Me.lblCharge, "Họ tên")
        '
        'lblChargeCode
        '
        Me.lblChargeCode.AutoSize = True
        Me.lblChargeCode.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblChargeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblChargeCode.Location = New System.Drawing.Point(34, 29)
        Me.lblChargeCode.Name = "lblChargeCode"
        Me.lblChargeCode.Size = New System.Drawing.Size(66, 13)
        Me.lblChargeCode.TabIndex = 14
        Me.lblChargeCode.Text = "User Name :"
        Me.lblChargeCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblChargeCode, "Tên đăng nhập")
        '
        'txtUserName
        '
        Me.txtUserName.Enabled = False
        Me.txtUserName.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtUserName.ForeColor = System.Drawing.Color.Blue
        Me.txtUserName.Location = New System.Drawing.Point(102, 26)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(192, 21)
        Me.txtUserName.TabIndex = 2
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(631, 184)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
        Me.smnuAdd.Text = "&Insert"
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(529, 184)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 11
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFullName.ForeColor = System.Drawing.Color.Blue
        Me.txtFullName.Location = New System.Drawing.Point(102, 58)
        Me.txtFullName.MaxLength = 50
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(336, 21)
        Me.txtFullName.TabIndex = 3
        '
        'fraUpdate
        '
        Me.fraUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraUpdate.Controls.Add(Me.Label10)
        Me.fraUpdate.Controls.Add(Me.Label9)
        Me.fraUpdate.Controls.Add(Me.Label8)
        Me.fraUpdate.Controls.Add(Me.cbomn3)
        Me.fraUpdate.Controls.Add(Me.cbomn2)
        Me.fraUpdate.Controls.Add(Me.cbomn1)
        Me.fraUpdate.Controls.Add(Me.txtfax)
        Me.fraUpdate.Controls.Add(Me.txtExt)
        Me.fraUpdate.Controls.Add(Me.txtMobile)
        Me.fraUpdate.Controls.Add(Me.txtTel)
        Me.fraUpdate.Controls.Add(Me.txtEmail)
        Me.fraUpdate.Controls.Add(Me.txtNickname)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.cboDepartment)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.Label7)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.lblCharge)
        Me.fraUpdate.Controls.Add(Me.txtFullName)
        Me.fraUpdate.Controls.Add(Me.lblChargeCode)
        Me.fraUpdate.Controls.Add(Me.txtUserName)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 238)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(746, 236)
        Me.fraUpdate.TabIndex = 34
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'txtfax
        '
        Me.txtfax.Location = New System.Drawing.Point(294, 163)
        Me.txtfax.Name = "txtfax"
        Me.txtfax.Size = New System.Drawing.Size(144, 20)
        Me.txtfax.TabIndex = 9
        '
        'txtExt
        '
        Me.txtExt.Location = New System.Drawing.Point(294, 137)
        Me.txtExt.Name = "txtExt"
        Me.txtExt.Size = New System.Drawing.Size(144, 20)
        Me.txtExt.TabIndex = 7
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(102, 163)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(143, 20)
        Me.txtMobile.TabIndex = 8
        '
        'txtTel
        '
        Me.txtTel.Location = New System.Drawing.Point(102, 137)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(143, 20)
        Me.txtTel.TabIndex = 6
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(102, 189)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(336, 21)
        Me.txtEmail.TabIndex = 10
        '
        'txtNickname
        '
        Me.txtNickname.Location = New System.Drawing.Point(102, 111)
        Me.txtNickname.Name = "txtNickname"
        Me.txtNickname.Size = New System.Drawing.Size(336, 20)
        Me.txtNickname.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(264, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(30, 13)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Fax :"
        '
        'cboDepartment
        '
        Me.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDepartment.FormattingEnabled = True
        Me.cboDepartment.Location = New System.Drawing.Point(102, 84)
        Me.cboDepartment.Name = "cboDepartment"
        Me.cboDepartment.Size = New System.Drawing.Size(336, 21)
        Me.cboDepartment.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(56, 166)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Mobile :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(266, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Ext :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(62, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Email :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(72, 140)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Tel :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(34, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Nick Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(32, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Department :"
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(595, 30)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 32
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtFind
        '
        Me.txtFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtFind.Location = New System.Drawing.Point(171, 30)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(396, 20)
        Me.txtFind.TabIndex = 31
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 30)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 22)
        Me.cboFind.TabIndex = 30
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(770, 24)
        Me.MenuStrip.TabIndex = 29
        Me.MenuStrip.Text = "MenuStrip"
        '
        'cbomn1
        '
        Me.cbomn1.FormattingEnabled = True
        Me.cbomn1.Location = New System.Drawing.Point(358, 26)
        Me.cbomn1.Name = "cbomn1"
        Me.cbomn1.Size = New System.Drawing.Size(121, 21)
        Me.cbomn1.TabIndex = 20
        '
        'cbomn2
        '
        Me.cbomn2.FormattingEnabled = True
        Me.cbomn2.Location = New System.Drawing.Point(485, 26)
        Me.cbomn2.Name = "cbomn2"
        Me.cbomn2.Size = New System.Drawing.Size(121, 21)
        Me.cbomn2.TabIndex = 21
        '
        'cbomn3
        '
        Me.cbomn3.FormattingEnabled = True
        Me.cbomn3.Location = New System.Drawing.Point(612, 26)
        Me.cbomn3.Name = "cbomn3"
        Me.cbomn3.Size = New System.Drawing.Size(121, 21)
        Me.cbomn3.TabIndex = 22
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(355, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Manager 1 :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label8, "Tên đăng nhập")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(482, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Manager 2 :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label9, "Tên đăng nhập")
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(609, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Manager 3 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Label10, "Tên đăng nhập")
        '
        'UsrID
        '
        Me.UsrID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UsrID.DataPropertyName = "UsrID"
        Me.UsrID.HeaderText = "UsrID"
        Me.UsrID.Name = "UsrID"
        Me.UsrID.Visible = False
        Me.UsrID.Width = 64
        '
        'UserRightDepartmentID
        '
        Me.UserRightDepartmentID.DataPropertyName = "UserRightDepartmentID"
        Me.UserRightDepartmentID.HeaderText = "UserRightDepartmentID"
        Me.UserRightDepartmentID.Name = "UserRightDepartmentID"
        Me.UserRightDepartmentID.Visible = False
        '
        'Username
        '
        Me.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Username.DataPropertyName = "Usr"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Yellow
        Me.Username.DefaultCellStyle = DataGridViewCellStyle2
        Me.Username.HeaderText = "User Name"
        Me.Username.Name = "Username"
        Me.Username.ToolTipText = "Tên đăng nhập"
        Me.Username.Width = 94
        '
        'FullName
        '
        Me.FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.FullName.DataPropertyName = "Name"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Aqua
        Me.FullName.DefaultCellStyle = DataGridViewCellStyle3
        Me.FullName.HeaderText = "Full Name"
        Me.FullName.Name = "FullName"
        Me.FullName.ToolTipText = "Họ tên"
        Me.FullName.Width = 88
        '
        'Department
        '
        Me.Department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Department.DataPropertyName = "Department"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Aquamarine
        Me.Department.DefaultCellStyle = DataGridViewCellStyle4
        Me.Department.HeaderText = "Department"
        Me.Department.Name = "Department"
        Me.Department.ReadOnly = True
        Me.Department.Width = 97
        '
        'mn1
        '
        Me.mn1.DataPropertyName = "manager1"
        Me.mn1.HeaderText = "Manager 1"
        Me.mn1.Name = "mn1"
        '
        'mn2
        '
        Me.mn2.DataPropertyName = "manager2"
        Me.mn2.HeaderText = "Manager 2"
        Me.mn2.Name = "mn2"
        '
        'mn3
        '
        Me.mn3.DataPropertyName = "manager3"
        Me.mn3.HeaderText = "Manager 3"
        Me.mn3.Name = "mn3"
        '
        'NickName
        '
        Me.NickName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.NickName.DataPropertyName = "Nickname"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.NickName.DefaultCellStyle = DataGridViewCellStyle5
        Me.NickName.HeaderText = "Nick Name"
        Me.NickName.Name = "NickName"
        Me.NickName.ReadOnly = True
        Me.NickName.Width = 94
        '
        'Tel
        '
        Me.Tel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Tel.DataPropertyName = "Tel"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.Tel.DefaultCellStyle = DataGridViewCellStyle6
        Me.Tel.HeaderText = "Tel"
        Me.Tel.Name = "Tel"
        Me.Tel.ReadOnly = True
        Me.Tel.Width = 50
        '
        'Ext
        '
        Me.Ext.DataPropertyName = "Ext"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        Me.Ext.DefaultCellStyle = DataGridViewCellStyle7
        Me.Ext.HeaderText = "Ext"
        Me.Ext.Name = "Ext"
        Me.Ext.ReadOnly = True
        '
        'Mobile
        '
        Me.Mobile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Mobile.DataPropertyName = "Mobile"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        Me.Mobile.DefaultCellStyle = DataGridViewCellStyle8
        Me.Mobile.HeaderText = "Mobile"
        Me.Mobile.Name = "Mobile"
        Me.Mobile.ReadOnly = True
        Me.Mobile.Width = 69
        '
        'Fax
        '
        Me.Fax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Fax.DataPropertyName = "Fax"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        Me.Fax.DefaultCellStyle = DataGridViewCellStyle9
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        Me.Fax.ReadOnly = True
        Me.Fax.Width = 52
        '
        'Email
        '
        Me.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Email.DataPropertyName = "Email"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        Me.Email.DefaultCellStyle = DataGridViewCellStyle10
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        Me.Email.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Email.Width = 62
        '
        'Continued
        '
        Me.Continued.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Continued.DataPropertyName = "DisContinued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Width = 89
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
        'Approve
        '
        Me.Approve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Approve.DataPropertyName = "Approve"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle11.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle11
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.ToolTipText = "Duyệt"
        Me.Approve.Width = 60
        '
        'UserId
        '
        Me.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle12
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UserId.ToolTipText = "Ngừuơi Cập Nhật"
        Me.UserId.Width = 76
        '
        'UpdateTime
        '
        Me.UpdateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle13
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.MinimumWidth = 100
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UpdateTime.ToolTipText = "Ngày Cập Nhật"
        '
        'frmUserList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(770, 486)
        Me.Controls.Add(Me.dgdUsr)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmUserList"
        Me.Text = "User List"
        CType(Me.dgdUsr, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdUsr As System.Windows.Forms.DataGridView
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblCharge As System.Windows.Forms.Label
    Friend WithEvents lblChargeCode As System.Windows.Forms.Label
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cboDepartment As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtFind As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents txtfax As System.Windows.Forms.TextBox
    Friend WithEvents txtExt As System.Windows.Forms.TextBox
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents txtTel As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtNickname As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbomn3 As System.Windows.Forms.ComboBox
    Friend WithEvents cbomn2 As System.Windows.Forms.ComboBox
    Friend WithEvents cbomn1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UsrID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserRightDepartmentID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Username As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Department As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NickName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ext As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
