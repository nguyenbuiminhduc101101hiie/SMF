<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDayOfEachStatus
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
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdContainerMNG = New System.Windows.Forms.DataGridView
        Me.BLIB_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullStorage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DET = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EmptyStorage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DETFull = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WaitForOnboard = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdContainerMNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.ExportExcelToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(671, 24)
        Me.MenuStrip.TabIndex = 175
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "Search"
        '
        'ExportExcelToolStripMenuItem
        '
        Me.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem"
        Me.ExportExcelToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainerMNG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdContainerMNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainerMNG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLIB_NO, Me.Container_No, Me.ContainerType, Me.FullStorage, Me.DET, Me.EmptyStorage, Me.DETFull, Me.WaitForOnboard})
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
        Me.dgdContainerMNG.Size = New System.Drawing.Size(647, 380)
        Me.dgdContainerMNG.TabIndex = 176
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
        'FullStorage
        '
        Me.FullStorage.DataPropertyName = "FullStorage"
        Me.FullStorage.HeaderText = "Full Storage"
        Me.FullStorage.Name = "FullStorage"
        '
        'DET
        '
        Me.DET.DataPropertyName = "DET"
        Me.DET.HeaderText = "DET"
        Me.DET.Name = "DET"
        '
        'EmptyStorage
        '
        Me.EmptyStorage.DataPropertyName = "EmptyStorage"
        Me.EmptyStorage.HeaderText = "Empty Storage"
        Me.EmptyStorage.Name = "EmptyStorage"
        '
        'DETFull
        '
        Me.DETFull.DataPropertyName = "DETFull"
        Me.DETFull.HeaderText = "Det Full"
        Me.DETFull.Name = "DETFull"
        '
        'WaitForOnboard
        '
        Me.WaitForOnboard.DataPropertyName = "WaitForOnboard"
        Me.WaitForOnboard.HeaderText = "Wait For Onboard"
        Me.WaitForOnboard.Name = "WaitForOnboard"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(574, 420)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 177
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportExcel.Location = New System.Drawing.Point(484, 420)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 179
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'frmDayOfEachStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(671, 455)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.dgdContainerMNG)
        Me.Name = "frmDayOfEachStatus"
        Me.Text = "Day(s) Of Each Status"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.dgdContainerMNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdContainerMNG As System.Windows.Forms.DataGridView
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents BLIB_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullStorage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DET As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmptyStorage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DETFull As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WaitForOnboard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
End Class
