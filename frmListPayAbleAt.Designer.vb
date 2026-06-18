<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListPayAbleAt
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.lblPayableAtName = New System.Windows.Forms.Label
        Me.txtPAYABLE_AT = New System.Windows.Forms.TextBox
        Me.lblPayableAtCode = New System.Windows.Forms.Label
        Me.txtPAYABLE_ATCode = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dgdPayableAt = New System.Windows.Forms.DataGridView
        Me.PAYABLE_AT_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAYABLE_AT_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PAYABLE_AT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtPayableAt = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayPayableAt = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.smnuDisplayApprove = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUserId = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUpdateTime = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdPayableAt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.lblPayableAtName)
        Me.fraUpdate.Controls.Add(Me.txtPAYABLE_AT)
        Me.fraUpdate.Controls.Add(Me.lblPayableAtCode)
        Me.fraUpdate.Controls.Add(Me.txtPAYABLE_ATCode)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 236)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(689, 170)
        Me.fraUpdate.TabIndex = 22
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'lblPayableAtName
        '
        Me.lblPayableAtName.AutoSize = True
        Me.lblPayableAtName.ForeColor = System.Drawing.Color.Blue
        Me.lblPayableAtName.Location = New System.Drawing.Point(81, 63)
        Me.lblPayableAtName.Name = "lblPayableAtName"
        Me.lblPayableAtName.Size = New System.Drawing.Size(41, 13)
        Me.lblPayableAtName.TabIndex = 19
        Me.lblPayableAtName.Text = "Name :"
        Me.ToolTip1.SetToolTip(Me.lblPayableAtName, "Tên Địa Điểm")
        '
        'txtPAYABLE_AT
        '
        Me.txtPAYABLE_AT.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtPAYABLE_AT.ForeColor = System.Drawing.Color.Blue
        Me.txtPAYABLE_AT.Location = New System.Drawing.Point(124, 62)
        Me.txtPAYABLE_AT.MaxLength = 50
        Me.txtPAYABLE_AT.Multiline = True
        Me.txtPAYABLE_AT.Name = "txtPAYABLE_AT"
        Me.txtPAYABLE_AT.Size = New System.Drawing.Size(269, 60)
        Me.txtPAYABLE_AT.TabIndex = 4
        '
        'lblPayableAtCode
        '
        Me.lblPayableAtCode.AutoSize = True
        Me.lblPayableAtCode.ForeColor = System.Drawing.Color.Blue
        Me.lblPayableAtCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPayableAtCode.Location = New System.Drawing.Point(81, 27)
        Me.lblPayableAtCode.Name = "lblPayableAtCode"
        Me.lblPayableAtCode.Size = New System.Drawing.Size(41, 13)
        Me.lblPayableAtCode.TabIndex = 14
        Me.lblPayableAtCode.Text = " Code :"
        Me.lblPayableAtCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblPayableAtCode, "Mã Địa Điểm")
        '
        'txtPAYABLE_ATCode
        '
        Me.txtPAYABLE_ATCode.Enabled = False
        Me.txtPAYABLE_ATCode.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtPAYABLE_ATCode.ForeColor = System.Drawing.Color.Blue
        Me.txtPAYABLE_ATCode.Location = New System.Drawing.Point(124, 25)
        Me.txtPAYABLE_ATCode.Name = "txtPAYABLE_ATCode"
        Me.txtPAYABLE_ATCode.Size = New System.Drawing.Size(93, 21)
        Me.txtPAYABLE_ATCode.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(583, 133)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(500, 133)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgdPayableAt
        '
        Me.dgdPayableAt.AllowUserToAddRows = False
        Me.dgdPayableAt.AllowUserToDeleteRows = False
        Me.dgdPayableAt.AllowUserToResizeRows = False
        Me.dgdPayableAt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdPayableAt.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPayableAt.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdPayableAt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPayableAt.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PAYABLE_AT_ID, Me.PAYABLE_AT_CODE, Me.PAYABLE_AT, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdPayableAt.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgdPayableAt.Location = New System.Drawing.Point(12, 56)
        Me.dgdPayableAt.Name = "dgdPayableAt"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPayableAt.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgdPayableAt.Size = New System.Drawing.Size(780, 174)
        Me.dgdPayableAt.TabIndex = 21
        '
        'PAYABLE_AT_ID
        '
        Me.PAYABLE_AT_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PAYABLE_AT_ID.DataPropertyName = "PAYABLE_AT_ID"
        Me.PAYABLE_AT_ID.HeaderText = "PayAbleAtId"
        Me.PAYABLE_AT_ID.Name = "PAYABLE_AT_ID"
        Me.PAYABLE_AT_ID.Visible = False
        '
        'PAYABLE_AT_CODE
        '
        Me.PAYABLE_AT_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PAYABLE_AT_CODE.DataPropertyName = "PAYABLE_AT_CODE"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        Me.PAYABLE_AT_CODE.DefaultCellStyle = DataGridViewCellStyle10
        Me.PAYABLE_AT_CODE.HeaderText = "Place  Code"
        Me.PAYABLE_AT_CODE.Name = "PAYABLE_AT_CODE"
        Me.PAYABLE_AT_CODE.ToolTipText = "Mã Địa Điểm"
        Me.PAYABLE_AT_CODE.Width = 101
        '
        'PAYABLE_AT
        '
        Me.PAYABLE_AT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PAYABLE_AT.DataPropertyName = "PAYABLE_AT"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        Me.PAYABLE_AT.DefaultCellStyle = DataGridViewCellStyle11
        Me.PAYABLE_AT.HeaderText = "Name"
        Me.PAYABLE_AT.Name = "PAYABLE_AT"
        Me.PAYABLE_AT.ToolTipText = "Tên Địa Điểm"
        Me.PAYABLE_AT.Width = 64
        '
        'Continued
        '
        Me.Continued.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle12.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle12
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.ToolTipText = "Duyệt"
        Me.Approve.Visible = False
        '
        'UserId
        '
        Me.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle13
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.ToolTipText = "Ngừuơi Cập Nhật"
        Me.UserId.Visible = False
        '
        'UpdateTime
        '
        Me.UpdateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle14
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ToolTipText = "Ngày Cập Nhật"
        Me.UpdateTime.Visible = False
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(595, 28)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 20
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtPayableAt
        '
        Me.txtPayableAt.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtPayableAt.Location = New System.Drawing.Point(171, 28)
        Me.txtPayableAt.Name = "txtPayableAt"
        Me.txtPayableAt.Size = New System.Drawing.Size(396, 20)
        Me.txtPayableAt.TabIndex = 19
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 28)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 22)
        Me.cboFind.TabIndex = 18
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuDisplay, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(976, 24)
        Me.MenuStrip.TabIndex = 17
        Me.MenuStrip.Text = "MenuStrip"
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
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'smnuDisplay
        '
        Me.smnuDisplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuDisplayPayableAt, Me.ToolStripSeparator1, Me.smnuDisplayApprove, Me.smnuDisplayUserId, Me.smnuDisplayUpdateTime})
        Me.smnuDisplay.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDisplay.Name = "smnuDisplay"
        Me.smnuDisplay.Size = New System.Drawing.Size(41, 20)
        Me.smnuDisplay.Text = "&View"
        '
        'smnuDisplayPayableAt
        '
        Me.smnuDisplayPayableAt.Name = "smnuDisplayPayableAt"
        Me.smnuDisplayPayableAt.Size = New System.Drawing.Size(135, 22)
        Me.smnuDisplayPayableAt.Text = "Payable At"
        Me.smnuDisplayPayableAt.ToolTipText = "Chi Trả Tại"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(132, 6)
        '
        'smnuDisplayApprove
        '
        Me.smnuDisplayApprove.Name = "smnuDisplayApprove"
        Me.smnuDisplayApprove.Size = New System.Drawing.Size(135, 22)
        Me.smnuDisplayApprove.Text = "&Approve"
        '
        'smnuDisplayUserId
        '
        Me.smnuDisplayUserId.Name = "smnuDisplayUserId"
        Me.smnuDisplayUserId.Size = New System.Drawing.Size(135, 22)
        Me.smnuDisplayUserId.Text = "Us&er Update"
        '
        'smnuDisplayUpdateTime
        '
        Me.smnuDisplayUpdateTime.Name = "smnuDisplayUpdateTime"
        Me.smnuDisplayUpdateTime.Size = New System.Drawing.Size(135, 22)
        Me.smnuDisplayUpdateTime.Text = "Date &Update"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'frmListPayAbleAt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(976, 416)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdPayableAt)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtPayableAt)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmListPayAbleAt"
        Me.Text = "List Pay Able At"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdPayableAt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents lblPayableAtName As System.Windows.Forms.Label
    Friend WithEvents txtPAYABLE_AT As System.Windows.Forms.TextBox
    Friend WithEvents lblPayableAtCode As System.Windows.Forms.Label
    Friend WithEvents txtPAYABLE_ATCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgdPayableAt As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtPayableAt As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayPayableAt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smnuDisplayApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUserId As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUpdateTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PAYABLE_AT_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAYABLE_AT_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PAYABLE_AT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
