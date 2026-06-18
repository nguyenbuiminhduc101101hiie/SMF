<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CheckStatusHistoryBeforeReport
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdfind = New System.Windows.Forms.Button
        Me.txtContainerno = New System.Windows.Forms.TextBox
        Me.dgdContainer = New System.Windows.Forms.DataGridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdcontainer1 = New System.Windows.Forms.DataGridView
        Me.ExportExcel2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgdContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgdcontainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(12, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Container No. :"
        '
        'cmdfind
        '
        Me.cmdfind.Location = New System.Drawing.Point(285, 23)
        Me.cmdfind.Name = "cmdfind"
        Me.cmdfind.Size = New System.Drawing.Size(75, 23)
        Me.cmdfind.TabIndex = 7
        Me.cmdfind.Text = "Find"
        Me.cmdfind.UseVisualStyleBackColor = True
        '
        'txtContainerno
        '
        Me.txtContainerno.Location = New System.Drawing.Point(92, 26)
        Me.txtContainerno.Name = "txtContainerno"
        Me.txtContainerno.Size = New System.Drawing.Size(182, 20)
        Me.txtContainerno.TabIndex = 6
        '
        'dgdContainer
        '
        Me.dgdContainer.AllowUserToAddRows = False
        Me.dgdContainer.AllowUserToDeleteRows = False
        Me.dgdContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainer.Location = New System.Drawing.Point(2, 52)
        Me.dgdContainer.Name = "dgdContainer"
        Me.dgdContainer.ReadOnly = True
        Me.dgdContainer.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContainer.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdContainer.Size = New System.Drawing.Size(851, 314)
        Me.dgdContainer.TabIndex = 5
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSearch, Me.mnuExportExcel, Me.ExportExcel2ToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(865, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuSearch
        '
        Me.mnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.mnuSearch.Name = "mnuSearch"
        Me.mnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.mnuSearch.Text = "Search"
        '
        'mnuExportExcel
        '
        Me.mnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.mnuExportExcel.Name = "mnuExportExcel"
        Me.mnuExportExcel.Size = New System.Drawing.Size(90, 20)
        Me.mnuExportExcel.Text = "Export Excel 1"
        '
        'dgdcontainer1
        '
        Me.dgdcontainer1.AllowUserToAddRows = False
        Me.dgdcontainer1.AllowUserToDeleteRows = False
        Me.dgdcontainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdcontainer1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgdcontainer1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdcontainer1.Location = New System.Drawing.Point(2, 372)
        Me.dgdcontainer1.Name = "dgdcontainer1"
        Me.dgdcontainer1.ReadOnly = True
        Me.dgdcontainer1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGriDViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdcontainer1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdcontainer1.Size = New System.Drawing.Size(851, 175)
        Me.dgdcontainer1.TabIndex = 10
        '
        'ExportExcel2ToolStripMenuItem
        '
        Me.ExportExcel2ToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.ExportExcel2ToolStripMenuItem.Name = "ExportExcel2ToolStripMenuItem"
        Me.ExportExcel2ToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.ExportExcel2ToolStripMenuItem.Text = "Export Excel 2"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'CheckStatusHistoryBeforeReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 573)
        Me.Controls.Add(Me.dgDcontainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdfind)
        Me.Controls.Add(Me.txtContainerno)
        Me.Controls.Add(Me.dgdContainer)
        Me.Name = "CheckStatusHistoryBeforeReport"
        Me.Text = "Check Status History Before Report"
        CType(Me.dgdContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgdcontainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdfind As System.Windows.Forms.Button
    Friend WithEvents txtContainerno As System.Windows.Forms.TextBox
    Friend WithEvents dgdContainer As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdcontainer1 As System.Windows.Forms.DataGridView
    Friend WithEvents ExportExcel2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
