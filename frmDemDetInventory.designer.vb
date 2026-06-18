<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDemDetInventory
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdContainerMNG = New System.Windows.Forms.DataGridView
        Me.BLIB_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemInfact = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemCorrect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemReduce = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DetInfact = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DetCorrect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DetReduce = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdContainerMNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(503, 386)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 189
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportExcel.Location = New System.Drawing.Point(595, 386)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 188
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(685, 386)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 187
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.ExportExcelToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(772, 24)
        Me.MenuStrip.TabIndex = 185
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'ExportExcelToolStripMenuItem
        '
        Me.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem"
        Me.ExportExcelToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.ExportExcelToolStripMenuItem.Text = "Export Excel"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'dgdContainerMNG
        '
        Me.dgdContainerMNG.AllowUserToAddRows = False
        Me.dgdContainerMNG.AllowUserToDeleteRows = False
        Me.dgdContainerMNG.AllowUserToOrderColumns = True
        Me.dgdContainerMNG.AllowUserToResizeRows = False
        Me.dgdContainerMNG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdContainerMNG.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainerMNG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdContainerMNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainerMNG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLIB_NO, Me.Container_No, Me.ContainerType, Me.DemInfact, Me.DemCorrect, Me.DemReduce, Me.DetInfact, Me.DetCorrect, Me.DetReduce})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdContainerMNG.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgdContainerMNG.Location = New System.Drawing.Point(12, 27)
        Me.dgdContainerMNG.Name = "dgdContainerMNG"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainerMNG.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgdContainerMNG.ShowCellErrors = False
        Me.dgdContainerMNG.ShowEditingIcon = False
        Me.dgdContainerMNG.ShowRowErrors = False
        Me.dgdContainerMNG.Size = New System.Drawing.Size(748, 353)
        Me.dgdContainerMNG.TabIndex = 186
        '
        'BLIB_NO
        '
        Me.BLIB_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BLIB_NO.DataPropertyName = "BL_NO_Inbound"
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Blue
        Me.BLIB_NO.DefaultCellStyle = DataGridViewCellStyle2
        Me.BLIB_NO.HeaderText = "Bill No (Inbound)"
        Me.BLIB_NO.Name = "BLIB_NO"
        Me.BLIB_NO.ToolTipText = "Bill No"
        Me.BLIB_NO.Width = 116
        '
        'Container_No
        '
        Me.Container_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Container_No.DataPropertyName = "Container_No"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        Me.Container_No.DefaultCellStyle = DataGridViewCellStyle3
        Me.Container_No.HeaderText = "Containers No."
        Me.Container_No.Name = "Container_No"
        Me.Container_No.ToolTipText = "Container No"
        Me.Container_No.Width = 106
        '
        'ContainerType
        '
        Me.ContainerType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ContainerType.DataPropertyName = "CTN_SIZE_TYPE"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Blue
        Me.ContainerType.DefaultCellStyle = DataGridViewCellStyle4
        Me.ContainerType.HeaderText = "Containers Type"
        Me.ContainerType.Name = "ContainerType"
        Me.ContainerType.ToolTipText = "Container Type"
        Me.ContainerType.Width = 114
        '
        'DemInfact
        '
        Me.DemInfact.DataPropertyName = "DemInfact"
        Me.DemInfact.HeaderText = "Dem Infact"
        Me.DemInfact.Name = "DemInfact"
        '
        'DemCorrect
        '
        Me.DemCorrect.DataPropertyName = "DemCorrect"
        Me.DemCorrect.HeaderText = "Dem Correct"
        Me.DemCorrect.Name = "DemCorrect"
        '
        'DemReduce
        '
        Me.DemReduce.DataPropertyName = "DemReduce"
        Me.DemReduce.HeaderText = "Dem Reduce"
        Me.DemReduce.Name = "DemReduce"
        '
        'DetInfact
        '
        Me.DetInfact.DataPropertyName = "DetInfact"
        Me.DetInfact.HeaderText = "Det Infact"
        Me.DetInfact.Name = "DetInfact"
        '
        'DetCorrect
        '
        Me.DetCorrect.DataPropertyName = "DetCorrect"
        Me.DetCorrect.HeaderText = "Det Correct"
        Me.DetCorrect.Name = "DetCorrect"
        '
        'DetReduce
        '
        Me.DetReduce.DataPropertyName = "DetReduce"
        Me.DetReduce.HeaderText = "Det Reduce"
        Me.DetReduce.Name = "DetReduce"
        '
        'frmDemDetInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(772, 412)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.dgdContainerMNG)
        Me.Name = "frmDemDetInventory"
        Me.Text = "DEM DET (Total)"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.dgdContainerMNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdContainerMNG As System.Windows.Forms.DataGridView
    Friend WithEvents BLIB_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemInfact As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemCorrect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemReduce As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetInfact As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetCorrect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetReduce As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
