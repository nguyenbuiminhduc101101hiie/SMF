<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTradeCode
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
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.lblTradeCode = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dgdTradeCode = New System.Windows.Forms.DataGridView
        Me.Trade_Code_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Trade_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtTradeCode = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayCode = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayRemarks = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayApprove = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUserId = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUpdateTime = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdTradeCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.lblRemarks)
        Me.fraUpdate.Controls.Add(Me.txtRemarks)
        Me.fraUpdate.Controls.Add(Me.lblTradeCode)
        Me.fraUpdate.Controls.Add(Me.txtCode)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(9, 317)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(757, 124)
        Me.fraUpdate.TabIndex = 17
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.ForeColor = System.Drawing.Color.Blue
        Me.lblRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRemarks.Location = New System.Drawing.Point(371, 32)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 13)
        Me.lblRemarks.TabIndex = 18
        Me.lblRemarks.Text = "Remarks :"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblRemarks, "Diễn Giải")
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtRemarks.ForeColor = System.Drawing.Color.Blue
        Me.txtRemarks.Location = New System.Drawing.Point(428, 29)
        Me.txtRemarks.MaxLength = 50
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(242, 61)
        Me.txtRemarks.TabIndex = 4
        '
        'lblTradeCode
        '
        Me.lblTradeCode.AutoSize = True
        Me.lblTradeCode.ForeColor = System.Drawing.Color.Blue
        Me.lblTradeCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTradeCode.Location = New System.Drawing.Point(29, 33)
        Me.lblTradeCode.Name = "lblTradeCode"
        Me.lblTradeCode.Size = New System.Drawing.Size(69, 13)
        Me.lblTradeCode.TabIndex = 14
        Me.lblTradeCode.Text = "Trade Code :"
        Me.lblTradeCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblTradeCode, "Mã Giao Dịch")
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtCode.ForeColor = System.Drawing.Color.Blue
        Me.txtCode.Location = New System.Drawing.Point(100, 29)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(242, 21)
        Me.txtCode.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(538, 96)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.cmdCancel, "Cancel")
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(455, 96)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.ToolTip1.SetToolTip(Me.cmdOK, "ok")
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgdTradeCode
        '
        Me.dgdTradeCode.AllowUserToAddRows = False
        Me.dgdTradeCode.AllowUserToDeleteRows = False
        Me.dgdTradeCode.AllowUserToResizeRows = False
        Me.dgdTradeCode.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdTradeCode.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.dgdTradeCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdTradeCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Trade_Code_Id, Me.Trade_Code, Me.Remarks, Me.Editable, Me.Continued, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdTradeCode.DefaultCellStyle = DataGridViewCellStyle44
        Me.dgdTradeCode.Location = New System.Drawing.Point(8, 60)
        Me.dgdTradeCode.Name = "dgdTradeCode"
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdTradeCode.RowHeadersDefaultCellStyle = DataGridViewCellStyle45
        Me.dgdTradeCode.Size = New System.Drawing.Size(758, 258)
        Me.dgdTradeCode.TabIndex = 16
        '
        'Trade_Code_Id
        '
        Me.Trade_Code_Id.DataPropertyName = "Trade_Code_Id"
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Trade_Code_Id.DefaultCellStyle = DataGridViewCellStyle38
        Me.Trade_Code_Id.HeaderText = "Trade Code Id"
        Me.Trade_Code_Id.Name = "Trade_Code_Id"
        Me.Trade_Code_Id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Trade_Code_Id.Visible = False
        Me.Trade_Code_Id.Width = 67
        '
        'Trade_Code
        '
        Me.Trade_Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Trade_Code.DataPropertyName = "Trade_Code"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle39.ForeColor = System.Drawing.Color.White
        Me.Trade_Code.DefaultCellStyle = DataGridViewCellStyle39
        Me.Trade_Code.HeaderText = "Trade Code "
        Me.Trade_Code.Name = "Trade_Code"
        Me.Trade_Code.ToolTipText = "Mã Giao Dịch"
        Me.Trade_Code.Width = 94
        '
        'Remarks
        '
        Me.Remarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Remarks.DataPropertyName = "REMARKS"
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle40.ForeColor = System.Drawing.Color.White
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle40
        Me.Remarks.HeaderText = "ReMarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ToolTipText = "Diễn Giải"
        Me.Remarks.Width = 82
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
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
        Me.Continued.Width = 89
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle41.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle41.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle41.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle41
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.ToolTipText = "Duyệt"
        Me.Approve.Width = 79
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle42.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle42.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle42
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.ToolTipText = "Ngừơi Cập Nhật"
        Me.UserId.Width = 76
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle43.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle43.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle43
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ToolTipText = "Ngày Cập Nhật"
        Me.UpdateTime.Width = 96
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(620, 33)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 15
        Me.cmdFind.Text = "&Find"
        Me.ToolTip1.SetToolTip(Me.cmdFind, "Tìm")
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtTradeCode
        '
        Me.txtTradeCode.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtTradeCode.Location = New System.Drawing.Point(133, 32)
        Me.txtTradeCode.Name = "txtTradeCode"
        Me.txtTradeCode.Size = New System.Drawing.Size(464, 20)
        Me.txtTradeCode.TabIndex = 14
        Me.ToolTip1.SetToolTip(Me.txtTradeCode, "Chuỗi Cần Tìm")
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(8, 32)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(119, 22)
        Me.cboFind.TabIndex = 13
        Me.ToolTip1.SetToolTip(Me.cboFind, "Tiêu Chí Tìm")
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuDisplay, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip.TabIndex = 12
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuAdd
        '
        Me.smnuAdd.AutoToolTip = True
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
        Me.smnuAdd.Text = "&Insert"
        Me.smnuAdd.ToolTipText = "Thêm"
        '
        'smnuEdit
        '
        Me.smnuEdit.AutoToolTip = True
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "&Edit"
        Me.smnuEdit.ToolTipText = "Sửa"
        '
        'smnuDelete
        '
        Me.smnuDelete.AutoToolTip = True
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "&Delete"
        Me.smnuDelete.ToolTipText = "Xoá"
        '
        'smnuDisplay
        '
        Me.smnuDisplay.AutoToolTip = True
        Me.smnuDisplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuDisplayCode, Me.smnuDisplayRemarks, Me.smnuDisplayApprove, Me.smnuDisplayUserId, Me.smnuDisplayUpdateTime})
        Me.smnuDisplay.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDisplay.Name = "smnuDisplay"
        Me.smnuDisplay.Size = New System.Drawing.Size(41, 20)
        Me.smnuDisplay.Text = "&View"
        Me.smnuDisplay.ToolTipText = "Xem Theo Chỉ Mục"
        '
        'smnuDisplayCode
        '
        Me.smnuDisplayCode.Name = "smnuDisplayCode"
        Me.smnuDisplayCode.Size = New System.Drawing.Size(152, 22)
        Me.smnuDisplayCode.Text = "Trade  C&ode "
        Me.smnuDisplayCode.ToolTipText = "Mã Giao Dịch"
        '
        'smnuDisplayRemarks
        '
        Me.smnuDisplayRemarks.Name = "smnuDisplayRemarks"
        Me.smnuDisplayRemarks.Size = New System.Drawing.Size(152, 22)
        Me.smnuDisplayRemarks.Text = "&Remarks"
        Me.smnuDisplayRemarks.ToolTipText = "Diễn Giải"
        '
        'smnuDisplayApprove
        '
        Me.smnuDisplayApprove.Name = "smnuDisplayApprove"
        Me.smnuDisplayApprove.Size = New System.Drawing.Size(152, 22)
        Me.smnuDisplayApprove.Text = "&Approve"
        Me.smnuDisplayApprove.ToolTipText = "Duyệt"
        '
        'smnuDisplayUserId
        '
        Me.smnuDisplayUserId.Name = "smnuDisplayUserId"
        Me.smnuDisplayUserId.Size = New System.Drawing.Size(152, 22)
        Me.smnuDisplayUserId.Text = "Us&er Update"
        Me.smnuDisplayUserId.ToolTipText = "Ngừơi Cập Nhật"
        '
        'smnuDisplayUpdateTime
        '
        Me.smnuDisplayUpdateTime.Name = "smnuDisplayUpdateTime"
        Me.smnuDisplayUpdateTime.Size = New System.Drawing.Size(152, 22)
        Me.smnuDisplayUpdateTime.Text = "Date &Update"
        Me.smnuDisplayUpdateTime.ToolTipText = "Ngày Cập Nhật"
        '
        'smnuExit
        '
        Me.smnuExit.AutoToolTip = True
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        Me.smnuExit.ToolTipText = "Thoát"
        '
        'frmTradeCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 459)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdTradeCode)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtTradeCode)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTradeCode"
        Me.Text = "List Of Trade Code"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdTradeCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents lblTradeCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgdTradeCode As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtTradeCode As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayRemarks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUserId As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUpdateTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Trade_Code_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Trade_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
