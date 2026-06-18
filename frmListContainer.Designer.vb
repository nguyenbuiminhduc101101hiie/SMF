<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListContainer
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListContainer))
        Me.dgdContainer = New System.Windows.Forms.DataGridView
        Me.ContainerId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_SIZE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NETWEIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtContainer = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdOK = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.lblCTN_SIZE_TYPE = New System.Windows.Forms.Label
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.cboCTN_Size_type = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblContainerno = New System.Windows.Forms.Label
        Me.txtNetWeight = New System.Windows.Forms.TextBox
        Me.txtContainerNo = New System.Windows.Forms.TextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.dgdContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdContainer
        '
        Me.dgdContainer.AllowUserToAddRows = False
        Me.dgdContainer.AllowUserToDeleteRows = False
        Me.dgdContainer.AllowUserToResizeRows = False
        Me.dgdContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdContainer.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContainerId, Me.CTN_SIZE_TYPE, Me.Container_No, Me.NETWEIGHT, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdContainer.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgdContainer.Location = New System.Drawing.Point(12, 54)
        Me.dgdContainer.Name = "dgdContainer"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainer.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        Me.dgdContainer.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdContainer.Size = New System.Drawing.Size(648, 174)
        Me.dgdContainer.TabIndex = 9
        '
        'ContainerId
        '
        Me.ContainerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ContainerId.DataPropertyName = "CTN_ID"
        Me.ContainerId.HeaderText = "ContainerId"
        Me.ContainerId.Name = "ContainerId"
        Me.ContainerId.Visible = False
        '
        'CTN_SIZE_TYPE
        '
        Me.CTN_SIZE_TYPE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.CTN_SIZE_TYPE.DataPropertyName = "CTN_SIZE_TYPE"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.CTN_SIZE_TYPE.DefaultCellStyle = DataGridViewCellStyle2
        Me.CTN_SIZE_TYPE.HeaderText = "Container Size/Type"
        Me.CTN_SIZE_TYPE.Name = "CTN_SIZE_TYPE"
        Me.CTN_SIZE_TYPE.ToolTipText = "Kích Cở/Loại Container"
        Me.CTN_SIZE_TYPE.Width = 135
        '
        'Container_No
        '
        Me.Container_No.DataPropertyName = "Container_No"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.Container_No.DefaultCellStyle = DataGridViewCellStyle3
        Me.Container_No.HeaderText = "Container No"
        Me.Container_No.Name = "Container_No"
        Me.Container_No.ToolTipText = "Container No"
        '
        'NETWEIGHT
        '
        Me.NETWEIGHT.DataPropertyName = "NETWEIGHT"
        Me.NETWEIGHT.HeaderText = "NETWEIGHT"
        Me.NETWEIGHT.Name = "NETWEIGHT"
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
        Me.cmdFind.Location = New System.Drawing.Point(583, 26)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 8
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtContainer
        '
        Me.txtContainer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContainer.Location = New System.Drawing.Point(159, 26)
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.Size = New System.Drawing.Size(396, 22)
        Me.txtContainer.TabIndex = 7
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 26)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 24)
        Me.cboFind.TabIndex = 6
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(674, 24)
        Me.MenuStrip.TabIndex = 5
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
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(284, 85)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.ToolTip1.SetToolTip(Me.cmdOK, "Ok")
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(367, 85)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.ToolTip1.SetToolTip(Me.cmdCancel, "Cancel")
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'lblCTN_SIZE_TYPE
        '
        Me.lblCTN_SIZE_TYPE.AutoSize = True
        Me.lblCTN_SIZE_TYPE.ForeColor = System.Drawing.Color.Blue
        Me.lblCTN_SIZE_TYPE.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCTN_SIZE_TYPE.Location = New System.Drawing.Point(18, 28)
        Me.lblCTN_SIZE_TYPE.Name = "lblCTN_SIZE_TYPE"
        Me.lblCTN_SIZE_TYPE.Size = New System.Drawing.Size(104, 13)
        Me.lblCTN_SIZE_TYPE.TabIndex = 14
        Me.lblCTN_SIZE_TYPE.Text = "Container size/type :"
        Me.lblCTN_SIZE_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblCTN_SIZE_TYPE, "Kích Cỡ / loại Container")
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.cboCTN_Size_type)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.lblContainerno)
        Me.fraUpdate.Controls.Add(Me.lblCTN_SIZE_TYPE)
        Me.fraUpdate.Controls.Add(Me.txtNetWeight)
        Me.fraUpdate.Controls.Add(Me.txtContainerNo)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 233)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(466, 121)
        Me.fraUpdate.TabIndex = 10
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'cboCTN_Size_type
        '
        Me.cboCTN_Size_type.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCTN_Size_type.ForeColor = System.Drawing.Color.Blue
        Me.cboCTN_Size_type.FormattingEnabled = True
        Me.cboCTN_Size_type.Items.AddRange(New Object() {"20GP", "40GP", "20RF", "40RF", "40HC", "45HC", "40RH", "20OT", "40OT", "20FR", "40FR", "CBM"})
        Me.cboCTN_Size_type.Location = New System.Drawing.Point(124, 25)
        Me.cboCTN_Size_type.Name = "cboCTN_Size_type"
        Me.cboCTN_Size_type.Size = New System.Drawing.Size(126, 26)
        Me.cboCTN_Size_type.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(260, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Net Weight :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblContainerno
        '
        Me.lblContainerno.AutoSize = True
        Me.lblContainerno.ForeColor = System.Drawing.Color.Blue
        Me.lblContainerno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblContainerno.Location = New System.Drawing.Point(253, 28)
        Me.lblContainerno.Name = "lblContainerno"
        Me.lblContainerno.Size = New System.Drawing.Size(75, 13)
        Me.lblContainerno.TabIndex = 14
        Me.lblContainerno.Text = "Container No :"
        Me.lblContainerno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.lblContainerno, "Container No")
        '
        'txtNetWeight
        '
        Me.txtNetWeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNetWeight.ForeColor = System.Drawing.Color.Blue
        Me.txtNetWeight.Location = New System.Drawing.Point(330, 54)
        Me.txtNetWeight.Name = "txtNetWeight"
        Me.txtNetWeight.Size = New System.Drawing.Size(114, 24)
        Me.txtNetWeight.TabIndex = 0
        '
        'txtContainerNo
        '
        Me.txtContainerNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContainerNo.ForeColor = System.Drawing.Color.Blue
        Me.txtContainerNo.Location = New System.Drawing.Point(330, 25)
        Me.txtContainerNo.Name = "txtContainerNo"
        Me.txtContainerNo.Size = New System.Drawing.Size(114, 24)
        Me.txtContainerNo.TabIndex = 0
        '
        'frmListContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(674, 367)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdContainer)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtContainer)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListContainer"
        Me.Text = "List Container"
        CType(Me.dgdContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdContainer As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtContainer As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents lblCTN_SIZE_TYPE As System.Windows.Forms.Label
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents lblContainerno As System.Windows.Forms.Label
    Friend WithEvents txtContainerNo As System.Windows.Forms.TextBox
    Friend WithEvents cboCTN_Size_type As System.Windows.Forms.ComboBox
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNetWeight As System.Windows.Forms.TextBox
    Friend WithEvents ContainerId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_SIZE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NETWEIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
