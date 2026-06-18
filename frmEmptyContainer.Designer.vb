<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEmptyContainer
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
        Me.dtpNgayLayHang = New System.Windows.Forms.DateTimePicker
        Me.dtpNgayCapCang = New System.Windows.Forms.DateTimePicker
        Me.dtpNgayHaRong = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtBL_NO = New System.Windows.Forms.TextBox
        Me.gpbChuhang = New System.Windows.Forms.GroupBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.cboEmptyPort = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboContainerType = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.dgdContainerNo = New System.Windows.Forms.DataGridView
        Me.PrintEmptyContainerID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmptyPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateofReDel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Printed = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdUncheckAll = New System.Windows.Forms.Button
        Me.chkAttachlist = New System.Windows.Forms.CheckBox
        Me.gpbChuhang.SuspendLayout()
        CType(Me.dgdContainerNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpNgayLayHang
        '
        Me.dtpNgayLayHang.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayLayHang.Location = New System.Drawing.Point(90, 94)
        Me.dtpNgayLayHang.Name = "dtpNgayLayHang"
        Me.dtpNgayLayHang.Size = New System.Drawing.Size(147, 20)
        Me.dtpNgayLayHang.TabIndex = 3
        '
        'dtpNgayCapCang
        '
        Me.dtpNgayCapCang.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayCapCang.Location = New System.Drawing.Point(90, 69)
        Me.dtpNgayCapCang.Name = "dtpNgayCapCang"
        Me.dtpNgayCapCang.Size = New System.Drawing.Size(147, 20)
        Me.dtpNgayCapCang.TabIndex = 4
        '
        'dtpNgayHaRong
        '
        Me.dtpNgayHaRong.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgayHaRong.Location = New System.Drawing.Point(90, 118)
        Me.dtpNgayHaRong.Name = "dtpNgayHaRong"
        Me.dtpNgayHaRong.Size = New System.Drawing.Size(147, 20)
        Me.dtpNgayHaRong.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Bãi Rỗng :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(2, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Ngày Cập Cảng :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(2, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Ngày Lấy Hàng :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(4, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Ngày Hạ Rỗng :"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(110, 213)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 24)
        Me.cmdOk.TabIndex = 12
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(23, 212)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 25)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtBL_NO
        '
        Me.txtBL_NO.Enabled = False
        Me.txtBL_NO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBL_NO.Location = New System.Drawing.Point(90, 8)
        Me.txtBL_NO.Name = "txtBL_NO"
        Me.txtBL_NO.Size = New System.Drawing.Size(205, 31)
        Me.txtBL_NO.TabIndex = 14
        '
        'gpbChuhang
        '
        Me.gpbChuhang.Controls.Add(Me.RadioButton3)
        Me.gpbChuhang.Controls.Add(Me.RadioButton2)
        Me.gpbChuhang.Controls.Add(Me.RadioButton1)
        Me.gpbChuhang.Location = New System.Drawing.Point(5, 153)
        Me.gpbChuhang.Name = "gpbChuhang"
        Me.gpbChuhang.Size = New System.Drawing.Size(232, 51)
        Me.gpbChuhang.TabIndex = 15
        Me.gpbChuhang.TabStop = False
        Me.gpbChuhang.Text = "Chủ Hàng"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(166, 19)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(52, 17)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "Notify"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Checked = True
        Me.RadioButton2.Location = New System.Drawing.Point(78, 19)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(75, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Consignee"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(11, 19)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(61, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.Text = "Shipper"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'cboEmptyPort
        '
        Me.cboEmptyPort.ForeColor = System.Drawing.Color.Blue
        Me.cboEmptyPort.FormattingEnabled = True
        Me.cboEmptyPort.Items.AddRange(New Object() {"CÁT LÁI", "NEW PORT", "ICD SÓNG THẦN", "ICD PHƯỚC LONG", "ICD TRANSIMEX", "ICD BIÊN HÒA ", "PHÚC LONG DEPOT", "KHÁNH HỘI PORT", "Z1", "VINATRAN", "SADACO", "LINH XUÂN"})
        Me.cboEmptyPort.Location = New System.Drawing.Point(90, 45)
        Me.cboEmptyPort.Name = "cboEmptyPort"
        Me.cboEmptyPort.Size = New System.Drawing.Size(147, 21)
        Me.cboEmptyPort.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Số Bill Of lading :"
        '
        'cboContainerType
        '
        Me.cboContainerType.Enabled = False
        Me.cboContainerType.FormattingEnabled = True
        Me.cboContainerType.Location = New System.Drawing.Point(60, 273)
        Me.cboContainerType.Name = "cboContainerType"
        Me.cboContainerType.Size = New System.Drawing.Size(61, 21)
        Me.cboContainerType.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 276)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Type :"
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAll.Location = New System.Drawing.Point(127, 276)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(37, 17)
        Me.chkAll.TabIndex = 17
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'dgdContainerNo
        '
        Me.dgdContainerNo.AllowUserToAddRows = False
        Me.dgdContainerNo.AllowUserToDeleteRows = False
        Me.dgdContainerNo.AllowUserToOrderColumns = True
        Me.dgdContainerNo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainerNo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PrintEmptyContainerID, Me.ContainerNo, Me.Container_Type, Me.EmptyPort, Me.ContainerStatus, Me.DateofReDel, Me.Printed, Me.UpdateTime, Me.UserID})
        Me.dgdContainerNo.Location = New System.Drawing.Point(243, 45)
        Me.dgdContainerNo.Name = "dgdContainerNo"
        Me.dgdContainerNo.RowHeadersWidth = 30
        Me.dgdContainerNo.Size = New System.Drawing.Size(458, 159)
        Me.dgdContainerNo.TabIndex = 19
        '
        'PrintEmptyContainerID
        '
        Me.PrintEmptyContainerID.DataPropertyName = "PrintEmptyContainerID"
        Me.PrintEmptyContainerID.HeaderText = "PrintEmptyContainerID"
        Me.PrintEmptyContainerID.Name = "PrintEmptyContainerID"
        Me.PrintEmptyContainerID.Visible = False
        '
        'ContainerNo
        '
        Me.ContainerNo.DataPropertyName = "Container_No"
        Me.ContainerNo.HeaderText = "Container No"
        Me.ContainerNo.Name = "ContainerNo"
        Me.ContainerNo.ReadOnly = True
        '
        'Container_Type
        '
        Me.Container_Type.DataPropertyName = "Container_Type"
        Me.Container_Type.HeaderText = "Container Type"
        Me.Container_Type.Name = "Container_Type"
        Me.Container_Type.ReadOnly = True
        Me.Container_Type.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Container_Type.Width = 60
        '
        'EmptyPort
        '
        Me.EmptyPort.DataPropertyName = "EmptyPort"
        Me.EmptyPort.HeaderText = "Empty Port"
        Me.EmptyPort.Name = "EmptyPort"
        '
        'ContainerStatus
        '
        Me.ContainerStatus.DataPropertyName = "ContainerStatus"
        Me.ContainerStatus.HeaderText = "Status"
        Me.ContainerStatus.Name = "ContainerStatus"
        Me.ContainerStatus.ReadOnly = True
        '
        'DateofReDel
        '
        Me.DateofReDel.DataPropertyName = "DateOfReDel"
        Me.DateofReDel.HeaderText = "Date Of DeliVery"
        Me.DateofReDel.Name = "DateofReDel"
        Me.DateofReDel.ReadOnly = True
        '
        'Printed
        '
        Me.Printed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Printed.DataPropertyName = "Printed"
        Me.Printed.HeaderText = "Printed"
        Me.Printed.Name = "Printed"
        Me.Printed.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Printed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Printed.Width = 65
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "Update Time"
        Me.UpdateTime.Name = "UpdateTime"
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        '
        'cmdUncheckAll
        '
        Me.cmdUncheckAll.Location = New System.Drawing.Point(558, 213)
        Me.cmdUncheckAll.Name = "cmdUncheckAll"
        Me.cmdUncheckAll.Size = New System.Drawing.Size(143, 34)
        Me.cmdUncheckAll.TabIndex = 20
        Me.cmdUncheckAll.Text = "Uncheck All (Printed)"
        Me.cmdUncheckAll.UseVisualStyleBackColor = True
        '
        'chkAttachlist
        '
        Me.chkAttachlist.AutoSize = True
        Me.chkAttachlist.Location = New System.Drawing.Point(306, 17)
        Me.chkAttachlist.Name = "chkAttachlist"
        Me.chkAttachlist.Size = New System.Drawing.Size(72, 17)
        Me.chkAttachlist.TabIndex = 21
        Me.chkAttachlist.Text = "Attach list"
        Me.chkAttachlist.UseVisualStyleBackColor = True
        '
        'frmEmptyContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 259)
        Me.Controls.Add(Me.chkAttachlist)
        Me.Controls.Add(Me.cmdUncheckAll)
        Me.Controls.Add(Me.dgdContainerNo)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboContainerType)
        Me.Controls.Add(Me.cboEmptyPort)
        Me.Controls.Add(Me.gpbChuhang)
        Me.Controls.Add(Me.txtBL_NO)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpNgayHaRong)
        Me.Controls.Add(Me.dtpNgayCapCang)
        Me.Controls.Add(Me.dtpNgayLayHang)
        Me.ForeColor = System.Drawing.Color.Blue
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmEmptyContainer"
        Me.Text = "Confirm"
        Me.gpbChuhang.ResumeLayout(False)
        Me.gpbChuhang.PerformLayout()
        CType(Me.dgdContainerNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpNgayLayHang As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNgayCapCang As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpNgayHaRong As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtBL_NO As System.Windows.Forms.TextBox
    Friend WithEvents gpbChuhang As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents cboEmptyPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboContainerType As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents dgdContainerNo As System.Windows.Forms.DataGridView
    Friend WithEvents cmdUncheckAll As System.Windows.Forms.Button
    Friend WithEvents PrintEmptyContainerID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmptyPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateofReDel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Printed As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkAttachlist As System.Windows.Forms.CheckBox
End Class
