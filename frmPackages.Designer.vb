<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListPackages
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListPackages))
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.lblPackagesDescription = New System.Windows.Forms.Label
        Me.txtPackagesDescription = New System.Windows.Forms.TextBox
        Me.lblPackagesCode = New System.Windows.Forms.Label
        Me.txtPackagesCode = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dgdPackages = New System.Windows.Forms.DataGridView
        Me.PACKAGES_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PACKAGES_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PACKAGES_DESCRIPTION = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtPackages = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayPackagesDescription = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.smnuDisplayApprove = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUserId = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUpdateTime = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdPackages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.lblPackagesDescription)
        Me.fraUpdate.Controls.Add(Me.txtPackagesDescription)
        Me.fraUpdate.Controls.Add(Me.lblPackagesCode)
        Me.fraUpdate.Controls.Add(Me.txtPackagesCode)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 236)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(689, 161)
        Me.fraUpdate.TabIndex = 16
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'lblPackagesDescription
        '
        Me.lblPackagesDescription.AutoSize = True
        Me.lblPackagesDescription.ForeColor = System.Drawing.Color.Blue
        Me.lblPackagesDescription.Location = New System.Drawing.Point(6, 64)
        Me.lblPackagesDescription.Name = "lblPackagesDescription"
        Me.lblPackagesDescription.Size = New System.Drawing.Size(117, 13)
        Me.lblPackagesDescription.TabIndex = 19
        Me.lblPackagesDescription.Text = "Packages Description :"
        Me.ToolTip1.SetToolTip(Me.lblPackagesDescription, "Diễn Giải")
        '
        'txtPackagesDescription
        '
        Me.txtPackagesDescription.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtPackagesDescription.ForeColor = System.Drawing.Color.Blue
        Me.txtPackagesDescription.Location = New System.Drawing.Point(124, 62)
        Me.txtPackagesDescription.MaxLength = 50
        Me.txtPackagesDescription.Multiline = True
        Me.txtPackagesDescription.Name = "txtPackagesDescription"
        Me.txtPackagesDescription.Size = New System.Drawing.Size(269, 65)
        Me.txtPackagesDescription.TabIndex = 4
        '
        'lblPackagesCode
        '
        Me.lblPackagesCode.AutoSize = True
        Me.lblPackagesCode.ForeColor = System.Drawing.Color.Blue
        Me.lblPackagesCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPackagesCode.Location = New System.Drawing.Point(33, 28)
        Me.lblPackagesCode.Name = "lblPackagesCode"
        Me.lblPackagesCode.Size = New System.Drawing.Size(89, 13)
        Me.lblPackagesCode.TabIndex = 14
        Me.lblPackagesCode.Text = "Packages Code :"
        Me.lblPackagesCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblPackagesCode, "Mã Packages")
        '
        'txtPackagesCode
        '
        Me.txtPackagesCode.Enabled = False
        Me.txtPackagesCode.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtPackagesCode.ForeColor = System.Drawing.Color.Blue
        Me.txtPackagesCode.Location = New System.Drawing.Point(124, 25)
        Me.txtPackagesCode.Name = "txtPackagesCode"
        Me.txtPackagesCode.Size = New System.Drawing.Size(93, 21)
        Me.txtPackagesCode.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(554, 122)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(471, 122)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgdPackages
        '
        Me.dgdPackages.AllowUserToAddRows = False
        Me.dgdPackages.AllowUserToDeleteRows = False
        Me.dgdPackages.AllowUserToResizeRows = False
        Me.dgdPackages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdPackages.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPackages.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPackages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PACKAGES_ID, Me.PACKAGES_CODE, Me.PACKAGES_DESCRIPTION, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdPackages.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgdPackages.Location = New System.Drawing.Point(12, 56)
        Me.dgdPackages.Name = "dgdPackages"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPackages.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgdPackages.Size = New System.Drawing.Size(780, 174)
        Me.dgdPackages.TabIndex = 15
        '
        'PACKAGES_ID
        '
        Me.PACKAGES_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PACKAGES_ID.DataPropertyName = "PACKAGES_ID"
        Me.PACKAGES_ID.HeaderText = "PackagesId"
        Me.PACKAGES_ID.Name = "PACKAGES_ID"
        Me.PACKAGES_ID.Visible = False
        '
        'PACKAGES_CODE
        '
        Me.PACKAGES_CODE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PACKAGES_CODE.DataPropertyName = "PACKAGES_CODE"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.PACKAGES_CODE.DefaultCellStyle = DataGridViewCellStyle2
        Me.PACKAGES_CODE.HeaderText = "Packages Code"
        Me.PACKAGES_CODE.Name = "PACKAGES_CODE"
        Me.PACKAGES_CODE.ToolTipText = "Mã Packages"
        Me.PACKAGES_CODE.Width = 111
        '
        'PACKAGES_DESCRIPTION
        '
        Me.PACKAGES_DESCRIPTION.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PACKAGES_DESCRIPTION.DataPropertyName = "PACKAGES_DESCRIPTION"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.PACKAGES_DESCRIPTION.DefaultCellStyle = DataGridViewCellStyle3
        Me.PACKAGES_DESCRIPTION.HeaderText = "Packages Description"
        Me.PACKAGES_DESCRIPTION.Name = "PACKAGES_DESCRIPTION"
        Me.PACKAGES_DESCRIPTION.ToolTipText = "Diễn Giải"
        Me.PACKAGES_DESCRIPTION.Width = 142
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle4
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
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle5
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.ToolTipText = "Ngừuơi Cập Nhật"
        Me.UserId.Visible = False
        '
        'UpdateTime
        '
        Me.UpdateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle6
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
        Me.cmdFind.TabIndex = 14
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtPackages
        '
        Me.txtPackages.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtPackages.Location = New System.Drawing.Point(171, 28)
        Me.txtPackages.Name = "txtPackages"
        Me.txtPackages.Size = New System.Drawing.Size(396, 20)
        Me.txtPackages.TabIndex = 13
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 28)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 22)
        Me.cboFind.TabIndex = 12
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuDisplay, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(973, 24)
        Me.MenuStrip.TabIndex = 11
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(45, 20)
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
        Me.smnuDisplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuDisplayPackagesDescription, Me.ToolStripSeparator1, Me.smnuDisplayApprove, Me.smnuDisplayUserId, Me.smnuDisplayUpdateTime})
        Me.smnuDisplay.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDisplay.Name = "smnuDisplay"
        Me.smnuDisplay.Size = New System.Drawing.Size(42, 20)
        Me.smnuDisplay.Text = "&View"
        '
        'smnuDisplayPackagesDescription
        '
        Me.smnuDisplayPackagesDescription.Name = "smnuDisplayPackagesDescription"
        Me.smnuDisplayPackagesDescription.Size = New System.Drawing.Size(181, 22)
        Me.smnuDisplayPackagesDescription.Text = "Packages Description"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(178, 6)
        '
        'smnuDisplayApprove
        '
        Me.smnuDisplayApprove.Name = "smnuDisplayApprove"
        Me.smnuDisplayApprove.Size = New System.Drawing.Size(181, 22)
        Me.smnuDisplayApprove.Text = "&Approve"
        '
        'smnuDisplayUserId
        '
        Me.smnuDisplayUserId.Name = "smnuDisplayUserId"
        Me.smnuDisplayUserId.Size = New System.Drawing.Size(181, 22)
        Me.smnuDisplayUserId.Text = "Us&er Update"
        '
        'smnuDisplayUpdateTime
        '
        Me.smnuDisplayUpdateTime.Name = "smnuDisplayUpdateTime"
        Me.smnuDisplayUpdateTime.Size = New System.Drawing.Size(181, 22)
        Me.smnuDisplayUpdateTime.Text = "Date &Update"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(36, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'frmListPackages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 409)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdPackages)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtPackages)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListPackages"
        Me.Text = "List Of Packages"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdPackages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents lblPackagesDescription As System.Windows.Forms.Label
    Friend WithEvents txtPackagesDescription As System.Windows.Forms.TextBox
    Friend WithEvents lblPackagesCode As System.Windows.Forms.Label
    Friend WithEvents txtPackagesCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgdPackages As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtPackages As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayPackagesDescription As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smnuDisplayApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUserId As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUpdateTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PACKAGES_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PACKAGES_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PACKAGES_DESCRIPTION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
