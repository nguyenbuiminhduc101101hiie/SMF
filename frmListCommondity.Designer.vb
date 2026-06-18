<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListCommondity
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListCommondity))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboFind = New System.Windows.Forms.ComboBox()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.txtSale = New System.Windows.Forms.TextBox()
        Me.txtRemark = New System.Windows.Forms.TextBox()
        Me.txtCommondity = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.fraUpdate = New System.Windows.Forms.GroupBox()
        Me.lblSealDate = New System.Windows.Forms.Label()
        Me.lblSealNo = New System.Windows.Forms.Label()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgdCommondity = New System.Windows.Forms.DataGridView()
        Me.Commondity_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Commondity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdCommondity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(762, 24)
        Me.MenuStrip.TabIndex = 35
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
        Me.smnuExportExcel.Size = New System.Drawing.Size(81, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 27)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 24)
        Me.cboFind.TabIndex = 10
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(595, 27)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 38
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtSale
        '
        Me.txtSale.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSale.Location = New System.Drawing.Point(171, 27)
        Me.txtSale.Name = "txtSale"
        Me.txtSale.Size = New System.Drawing.Size(396, 22)
        Me.txtSale.TabIndex = 11
        '
        'txtRemark
        '
        Me.txtRemark.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRemark.ForeColor = System.Drawing.Color.Blue
        Me.txtRemark.Location = New System.Drawing.Point(91, 46)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(308, 22)
        Me.txtRemark.TabIndex = 2
        '
        'txtCommondity
        '
        Me.txtCommondity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommondity.ForeColor = System.Drawing.Color.Blue
        Me.txtCommondity.Location = New System.Drawing.Point(91, 19)
        Me.txtCommondity.Name = "txtCommondity"
        Me.txtCommondity.Size = New System.Drawing.Size(308, 22)
        Me.txtCommondity.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(322, 73)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'fraUpdate
        '
        Me.fraUpdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraUpdate.Controls.Add(Me.lblSealDate)
        Me.fraUpdate.Controls.Add(Me.lblSealNo)
        Me.fraUpdate.Controls.Add(Me.txtRemark)
        Me.fraUpdate.Controls.Add(Me.txtCommondity)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 235)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(437, 113)
        Me.fraUpdate.TabIndex = 40
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'lblSealDate
        '
        Me.lblSealDate.AutoSize = True
        Me.lblSealDate.ForeColor = System.Drawing.Color.Blue
        Me.lblSealDate.Location = New System.Drawing.Point(36, 50)
        Me.lblSealDate.Name = "lblSealDate"
        Me.lblSealDate.Size = New System.Drawing.Size(55, 13)
        Me.lblSealDate.TabIndex = 19
        Me.lblSealDate.Text = "Remarks :"
        '
        'lblSealNo
        '
        Me.lblSealNo.AutoSize = True
        Me.lblSealNo.ForeColor = System.Drawing.Color.Blue
        Me.lblSealNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblSealNo.Location = New System.Drawing.Point(21, 23)
        Me.lblSealNo.Name = "lblSealNo"
        Me.lblSealNo.Size = New System.Drawing.Size(64, 13)
        Me.lblSealNo.TabIndex = 14
        Me.lblSealNo.Text = "Commodity :"
        Me.lblSealNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(239, 73)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 3
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgdCommondity
        '
        Me.dgdCommondity.AllowUserToAddRows = False
        Me.dgdCommondity.AllowUserToDeleteRows = False
        Me.dgdCommondity.AllowUserToResizeRows = False
        Me.dgdCommondity.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdCommondity.BackgroundColor = System.Drawing.Color.PowderBlue
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdCommondity.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdCommondity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCommondity.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Commondity_ID, Me.Commondity, Me.Remarks, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdCommondity.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgdCommondity.Location = New System.Drawing.Point(12, 55)
        Me.dgdCommondity.Name = "dgdCommondity"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdCommondity.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgdCommondity.Size = New System.Drawing.Size(738, 174)
        Me.dgdCommondity.TabIndex = 0
        '
        'Commondity_ID
        '
        Me.Commondity_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Commondity_ID.DataPropertyName = "Commondity_ID"
        Me.Commondity_ID.HeaderText = "Commondity_ID"
        Me.Commondity_ID.Name = "Commondity_ID"
        Me.Commondity_ID.Visible = False
        '
        'Commondity
        '
        Me.Commondity.DataPropertyName = "Commondity"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        Me.Commondity.DefaultCellStyle = DataGridViewCellStyle10
        Me.Commondity.HeaderText = "Commodity"
        Me.Commondity.Name = "Commondity"
        Me.Commondity.ToolTipText = "Commodity"
        Me.Commondity.Width = 99
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle11
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ToolTipText = "Remarks"
        Me.Remarks.Width = 81
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
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle13
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.ToolTipText = "Ngừuơi Cập Nhật"
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle14
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ToolTipText = "Ngày Cập Nhật"
        '
        'frmListCommondity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(762, 377)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtSale)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdCommondity)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListCommondity"
        Me.Text = "List of Commodity"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdCommondity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtSale As System.Windows.Forms.TextBox
    Friend WithEvents txtRemark As System.Windows.Forms.TextBox
    Friend WithEvents txtCommondity As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents lblSealDate As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblSealNo As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgdCommondity As System.Windows.Forms.DataGridView
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Commondity_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Commondity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
