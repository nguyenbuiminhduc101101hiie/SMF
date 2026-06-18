<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStorageSoundCOntainerFee
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.EmptyStorage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdContainerMNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportExcel.Location = New System.Drawing.Point(556, 309)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 183
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(646, 309)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 182
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.ExportExcelToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(721, 24)
        Me.MenuStrip.TabIndex = 180
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
        Me.dgdContainerMNG.AllowUserToResizeRows = False
        Me.dgdContainerMNG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdContainerMNG.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainerMNG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgdContainerMNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainerMNG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLIB_NO, Me.Container_No, Me.ContainerType, Me.EmptyStorage})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdContainerMNG.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgdContainerMNG.Location = New System.Drawing.Point(9, 42)
        Me.dgdContainerMNG.Name = "dgdContainerMNG"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainerMNG.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgdContainerMNG.ShowCellErrors = False
        Me.dgdContainerMNG.ShowEditingIcon = False
        Me.dgdContainerMNG.ShowRowErrors = False
        Me.dgdContainerMNG.Size = New System.Drawing.Size(700, 261)
        Me.dgdContainerMNG.TabIndex = 181
        '
        'BLIB_NO
        '
        Me.BLIB_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BLIB_NO.DataPropertyName = "BL_NO_Inbound"
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Blue
        Me.BLIB_NO.DefaultCellStyle = DataGridViewCellStyle8
        Me.BLIB_NO.HeaderText = "Bill No (Inbound)"
        Me.BLIB_NO.Name = "BLIB_NO"
        Me.BLIB_NO.ToolTipText = "Bill No"
        Me.BLIB_NO.Width = 116
        '
        'Container_No
        '
        Me.Container_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Container_No.DataPropertyName = "Container_No"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Blue
        Me.Container_No.DefaultCellStyle = DataGridViewCellStyle9
        Me.Container_No.HeaderText = "Containers No."
        Me.Container_No.Name = "Container_No"
        Me.Container_No.ToolTipText = "Container No"
        Me.Container_No.Width = 106
        '
        'ContainerType
        '
        Me.ContainerType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ContainerType.DataPropertyName = "CTN_SIZE_TYPE"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.Blue
        Me.ContainerType.DefaultCellStyle = DataGridViewCellStyle10
        Me.ContainerType.HeaderText = "Containers Type"
        Me.ContainerType.Name = "ContainerType"
        Me.ContainerType.ToolTipText = "Container Type"
        Me.ContainerType.Width = 114
        '
        'EmptyStorage
        '
        Me.EmptyStorage.DataPropertyName = "EmptyStorage"
        Me.EmptyStorage.HeaderText = "Empty Storage"
        Me.EmptyStorage.Name = "EmptyStorage"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefresh.Location = New System.Drawing.Point(464, 309)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 184
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'frmStorageSoundCOntainerFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(721, 335)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.dgdContainerMNG)
        Me.Name = "frmStorageSoundCOntainerFee"
        Me.Text = "Sound Container  Storage Fee"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.dgdContainerMNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdContainerMNG As System.Windows.Forms.DataGridView
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents BLIB_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmptyStorage As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
