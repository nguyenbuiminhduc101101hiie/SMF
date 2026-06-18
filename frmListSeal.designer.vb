<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListSeal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListSeal))
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.dtpSealDate = New System.Windows.Forms.DateTimePicker
        Me.lblSealDate = New System.Windows.Forms.Label
        Me.lblSealNo = New System.Windows.Forms.Label
        Me.txtSealNo = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dgdSeal = New System.Windows.Forms.DataGridView
        Me.SEAL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SealNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateOfSeal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtSeal = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdSeal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.dtpSealDate)
        Me.fraUpdate.Controls.Add(Me.lblSealDate)
        Me.fraUpdate.Controls.Add(Me.lblSealNo)
        Me.fraUpdate.Controls.Add(Me.txtSealNo)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 236)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(517, 83)
        Me.fraUpdate.TabIndex = 28
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'dtpSealDate
        '
        Me.dtpSealDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpSealDate.Location = New System.Drawing.Point(299, 19)
        Me.dtpSealDate.Name = "dtpSealDate"
        Me.dtpSealDate.Size = New System.Drawing.Size(200, 24)
        Me.dtpSealDate.TabIndex = 20
        '
        'lblSealDate
        '
        Me.lblSealDate.AutoSize = True
        Me.lblSealDate.ForeColor = System.Drawing.Color.Blue
        Me.lblSealDate.Location = New System.Drawing.Point(237, 21)
        Me.lblSealDate.Name = "lblSealDate"
        Me.lblSealDate.Size = New System.Drawing.Size(60, 13)
        Me.lblSealDate.TabIndex = 19
        Me.lblSealDate.Text = "Seal Date :"
        Me.ToolTip1.SetToolTip(Me.lblSealDate, "Ngày Seal")
        '
        'lblSealNo
        '
        Me.lblSealNo.AutoSize = True
        Me.lblSealNo.ForeColor = System.Drawing.Color.Blue
        Me.lblSealNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSealNo.Location = New System.Drawing.Point(68, 21)
        Me.lblSealNo.Name = "lblSealNo"
        Me.lblSealNo.Size = New System.Drawing.Size(51, 13)
        Me.lblSealNo.TabIndex = 14
        Me.lblSealNo.Text = "Seal No :"
        Me.lblSealNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblSealNo, "Số Seal")
        '
        'txtSealNo
        '
        Me.txtSealNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSealNo.ForeColor = System.Drawing.Color.Blue
        Me.txtSealNo.Location = New System.Drawing.Point(121, 18)
        Me.txtSealNo.Name = "txtSealNo"
        Me.txtSealNo.Size = New System.Drawing.Size(93, 24)
        Me.txtSealNo.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(339, 52)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(422, 52)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgdSeal
        '
        Me.dgdSeal.AllowUserToAddRows = False
        Me.dgdSeal.AllowUserToDeleteRows = False
        Me.dgdSeal.AllowUserToResizeRows = False
        Me.dgdSeal.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdSeal.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdSeal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdSeal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdSeal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SEAL_ID, Me.SealNo, Me.DateOfSeal, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdSeal.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgdSeal.Location = New System.Drawing.Point(12, 56)
        Me.dgdSeal.Name = "dgdSeal"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdSeal.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgdSeal.Size = New System.Drawing.Size(656, 174)
        Me.dgdSeal.TabIndex = 27
        '
        'SEAL_ID
        '
        Me.SEAL_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SEAL_ID.DataPropertyName = "Seal_Id"
        Me.SEAL_ID.HeaderText = "SealId"
        Me.SEAL_ID.Name = "SEAL_ID"
        Me.SEAL_ID.Visible = False
        '
        'SealNo
        '
        Me.SealNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.SealNo.DataPropertyName = "SealNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.SealNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.SealNo.HeaderText = "Seal No"
        Me.SealNo.Name = "SealNo"
        Me.SealNo.ToolTipText = "Số Seal"
        Me.SealNo.Width = 77
        '
        'DateOfSeal
        '
        Me.DateOfSeal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DateOfSeal.DataPropertyName = "DateOfSeal"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.DateOfSeal.DefaultCellStyle = DataGridViewCellStyle3
        Me.DateOfSeal.HeaderText = "Seal Date"
        Me.DateOfSeal.Name = "DateOfSeal"
        Me.DateOfSeal.ToolTipText = "Ngày Seal"
        Me.DateOfSeal.Width = 88
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
        Me.cmdFind.TabIndex = 26
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtSeal
        '
        Me.txtSeal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSeal.Location = New System.Drawing.Point(171, 28)
        Me.txtSeal.Name = "txtSeal"
        Me.txtSeal.Size = New System.Drawing.Size(396, 22)
        Me.txtSeal.TabIndex = 25
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 28)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 24)
        Me.cboFind.TabIndex = 24
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(680, 24)
        Me.MenuStrip.TabIndex = 23
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
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
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'frmListSeal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(680, 336)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdSeal)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtSeal)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListSeal"
        Me.Text = "List Of Seal"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdSeal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents lblSealDate As System.Windows.Forms.Label
    Friend WithEvents lblSealNo As System.Windows.Forms.Label
    Friend WithEvents txtSealNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgdSeal As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtSeal As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpSealDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SEAL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SealNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfSeal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
End Class
