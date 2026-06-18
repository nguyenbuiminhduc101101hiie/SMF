<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpress_port
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpress_port))
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.cboZone = New System.Windows.Forms.ComboBox
        Me.dgdview = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Zone = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.show = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.inbound = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.chkshow = New System.Windows.Forms.CheckBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.chkinbound = New System.Windows.Forms.CheckBox
        CType(Me.dgdview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdexit
        '
        Me.cmdexit.Location = New System.Drawing.Point(113, 89)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 23)
        Me.cmdexit.TabIndex = 17
        Me.cmdexit.Text = "Cancel"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(194, 89)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 16
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Port :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Zone - PWD :"
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(70, 39)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(197, 21)
        Me.cboPort.TabIndex = 11
        '
        'cboZone
        '
        Me.cboZone.FormattingEnabled = True
        Me.cboZone.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"})
        Me.cboZone.Location = New System.Drawing.Point(104, 12)
        Me.cboZone.Name = "cboZone"
        Me.cboZone.Size = New System.Drawing.Size(163, 21)
        Me.cboZone.TabIndex = 10
        Me.cboZone.Text = "A"
        '
        'dgdview
        '
        Me.dgdview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Zone, Me.Port, Me.show, Me.inbound})
        Me.dgdview.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdview.Location = New System.Drawing.Point(295, 12)
        Me.dgdview.Name = "dgdview"
        Me.dgdview.Size = New System.Drawing.Size(415, 372)
        Me.dgdview.TabIndex = 9
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'Zone
        '
        Me.Zone.DataPropertyName = "Zone"
        Me.Zone.HeaderText = "Zone"
        Me.Zone.Name = "Zone"
        '
        'Port
        '
        Me.Port.DataPropertyName = "Port"
        Me.Port.HeaderText = "Port"
        Me.Port.Name = "Port"
        '
        'show
        '
        Me.show.DataPropertyName = "show"
        Me.show.HeaderText = "Show"
        Me.show.Name = "show"
        Me.show.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.show.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'inbound
        '
        Me.inbound.DataPropertyName = "inbound"
        Me.inbound.HeaderText = "Inbound"
        Me.inbound.Name = "inbound"
        Me.inbound.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.inbound.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.AddToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 70)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(107, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(30, 89)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 18
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(30, 118)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "Find"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'chkshow
        '
        Me.chkshow.AutoSize = True
        Me.chkshow.Location = New System.Drawing.Point(70, 66)
        Me.chkshow.Name = "chkshow"
        Me.chkshow.Size = New System.Drawing.Size(53, 17)
        Me.chkshow.TabIndex = 20
        Me.chkshow.Text = "Show"
        Me.chkshow.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(113, 118)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 21
        Me.Button4.Text = "Edit"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(194, 118)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "Delete"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'chkinbound
        '
        Me.chkinbound.AutoSize = True
        Me.chkinbound.Location = New System.Drawing.Point(129, 66)
        Me.chkinbound.Name = "chkinbound"
        Me.chkinbound.Size = New System.Drawing.Size(65, 17)
        Me.chkinbound.TabIndex = 23
        Me.chkinbound.Text = "Inbound"
        Me.chkinbound.UseVisualStyleBackColor = True
        '
        'frmExpress_port
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 396)
        Me.Controls.Add(Me.chkinbound)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.chkshow)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboPort)
        Me.Controls.Add(Me.cboZone)
        Me.Controls.Add(Me.dgdview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExpress_port"
        Me.Text = "Express Port"
        CType(Me.dgdview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents cboZone As System.Windows.Forms.ComboBox
    Friend WithEvents dgdview As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chkshow As System.Windows.Forms.CheckBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkinbound As System.Windows.Forms.CheckBox
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Zone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents show As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents inbound As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
