<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEditPortInfo
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
        Me.dgdUpdateSurtCharge = New System.Windows.Forms.DataGridView
        Me.PortSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.POD_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbomarket = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.cmdNewSearch = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.txtOverW40 = New System.Windows.Forms.TextBox
        Me.txtOverW20 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgdUpdateSurtCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdUpdateSurtCharge
        '
        Me.dgdUpdateSurtCharge.AllowUserToAddRows = False
        Me.dgdUpdateSurtCharge.AllowUserToDeleteRows = False
        Me.dgdUpdateSurtCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgdUpdateSurtCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdUpdateSurtCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PortSelect, Me.POD_Code, Me.POD, Me.Port_ID})
        Me.dgdUpdateSurtCharge.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdUpdateSurtCharge.Location = New System.Drawing.Point(332, 37)
        Me.dgdUpdateSurtCharge.Name = "dgdUpdateSurtCharge"
        Me.dgdUpdateSurtCharge.Size = New System.Drawing.Size(365, 245)
        Me.dgdUpdateSurtCharge.TabIndex = 0
        '
        'PortSelect
        '
        Me.PortSelect.DataPropertyName = "PortSelect"
        Me.PortSelect.HeaderText = "Select"
        Me.PortSelect.Name = "PortSelect"
        Me.PortSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PortSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'POD_Code
        '
        Me.POD_Code.DataPropertyName = "POD_Code"
        Me.POD_Code.HeaderText = "POD Code"
        Me.POD_Code.Name = "POD_Code"
        '
        'POD
        '
        Me.POD.DataPropertyName = "POD"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        '
        'Port_ID
        '
        Me.Port_ID.DataPropertyName = "Port_ID"
        Me.Port_ID.HeaderText = "Port_ID"
        Me.Port_ID.Name = "Port_ID"
        Me.Port_ID.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckToolStripMenuItem, Me.UnCheckToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(128, 48)
        '
        'CheckToolStripMenuItem
        '
        Me.CheckToolStripMenuItem.Name = "CheckToolStripMenuItem"
        Me.CheckToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.CheckToolStripMenuItem.Text = "Check "
        '
        'UnCheckToolStripMenuItem
        '
        Me.UnCheckToolStripMenuItem.Name = "UnCheckToolStripMenuItem"
        Me.UnCheckToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.UnCheckToolStripMenuItem.Text = "UnCheck"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(15, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Market :"
        '
        'cbomarket
        '
        Me.cbomarket.FormattingEnabled = True
        Me.cbomarket.Location = New System.Drawing.Point(63, 11)
        Me.cbomarket.Name = "cbomarket"
        Me.cbomarket.Size = New System.Drawing.Size(152, 21)
        Me.cbomarket.TabIndex = 15
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(412, 9)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(69, 25)
        Me.cmdSearch.TabIndex = 47
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(487, 11)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(173, 20)
        Me.txtSearch.TabIndex = 16
        '
        'cmdNewSearch
        '
        Me.cmdNewSearch.Location = New System.Drawing.Point(332, 9)
        Me.cmdNewSearch.Name = "cmdNewSearch"
        Me.cmdNewSearch.Size = New System.Drawing.Size(76, 25)
        Me.cmdNewSearch.TabIndex = 47
        Me.cmdNewSearch.Text = "New Search "
        Me.cmdNewSearch.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.txtOverW40)
        Me.GroupBox1.Controls.Add(Me.txtOverW20)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 109)
        Me.GroupBox1.TabIndex = 48
        Me.GroupBox1.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(132, 73)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(85, 25)
        Me.cmdCancel.TabIndex = 49
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(223, 73)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(85, 25)
        Me.cmdOk.TabIndex = 49
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtOverW40
        '
        Me.txtOverW40.Location = New System.Drawing.Point(83, 41)
        Me.txtOverW40.Name = "txtOverW40"
        Me.txtOverW40.Size = New System.Drawing.Size(86, 20)
        Me.txtOverW40.TabIndex = 16
        Me.txtOverW40.Text = "0"
        Me.txtOverW40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOverW20
        '
        Me.txtOverW20.Location = New System.Drawing.Point(83, 15)
        Me.txtOverW20.Name = "txtOverW20"
        Me.txtOverW20.Size = New System.Drawing.Size(86, 20)
        Me.txtOverW20.TabIndex = 16
        Me.txtOverW20.Text = "0"
        Me.txtOverW20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(18, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Over W40 :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(18, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Over W20 :"
        '
        'frmEditPortInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 335)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbomarket)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.cmdNewSearch)
        Me.Controls.Add(Me.dgdUpdateSurtCharge)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "frmEditPortInfo"
        Me.Text = "Update Surcharge"
        CType(Me.dgdUpdateSurtCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdUpdateSurtCharge As System.Windows.Forms.DataGridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbomarket As System.Windows.Forms.ComboBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdNewSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtOverW40 As System.Windows.Forms.TextBox
    Friend WithEvents txtOverW20 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents PortSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents POD_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port_ID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
