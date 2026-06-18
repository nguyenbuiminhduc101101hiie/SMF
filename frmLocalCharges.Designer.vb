<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocalCharges
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocalCharges))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RightClickForDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtSurcharges = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSaveService = New System.Windows.Forms.Button()
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView()
        Me.localchargesid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Items = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.destination = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mainports = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.carrier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.commodity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.service = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gp20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gp40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hc40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rf20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rf40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.other = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.surcharges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.effective_ = New TSA.CalendarColumn()
        Me.t2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transittime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salesman = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 1000000
        Me.ToolTip1.ReshowDelay = 200
        Me.ToolTip1.ShowAlways = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RightClickForDetailsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 26)
        '
        'RightClickForDetailsToolStripMenuItem
        '
        Me.RightClickForDetailsToolStripMenuItem.Name = "RightClickForDetailsToolStripMenuItem"
        Me.RightClickForDetailsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RightClickForDetailsToolStripMenuItem.Text = "Right click for details"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Yellow
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.txtSurcharges)
        Me.GroupBox1.Location = New System.Drawing.Point(438, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 263)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Others Surcharges"
        Me.GroupBox1.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(92, 231)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 2
        Me.Button9.Text = "Close"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(11, 231)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 1
        Me.Button8.Text = "Save"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txtSurcharges
        '
        Me.txtSurcharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSurcharges.Location = New System.Drawing.Point(11, 19)
        Me.txtSurcharges.Multiline = True
        Me.txtSurcharges.Name = "txtSurcharges"
        Me.txtSurcharges.Size = New System.Drawing.Size(306, 206)
        Me.txtSurcharges.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(732, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Search (Column) :"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(1105, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 23)
        Me.Button7.TabIndex = 52
        Me.Button7.Text = "Ok"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(953, 6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(146, 20)
        Me.TextBox2.TabIndex = 51
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Destination", "POL", "MainPorts", "Carrier", "Coloader", "Items"})
        Me.ComboBox1.Location = New System.Drawing.Point(826, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 50
        Me.ComboBox1.Text = "Destination"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 23)
        Me.Button6.TabIndex = 49
        Me.Button6.Text = "Load"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(629, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(52, 23)
        Me.Button5.TabIndex = 48
        Me.Button5.Text = "Ok"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(396, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Search All :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(461, 9)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 20)
        Me.TextBox1.TabIndex = 46
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(104, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 23)
        Me.Button4.TabIndex = 45
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(58, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 23)
        Me.Button3.TabIndex = 44
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(266, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 43
        Me.Button2.Text = "Export..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(214, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 42
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(163, 6)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(46, 23)
        Me.cmdSaveService.TabIndex = 41
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdShippingLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.localchargesid, Me.IO, Me.Items, Me.destination, Me.POl, Me.mainports, Me.carrier, Me.coloader, Me.commodity, Me.service, Me.gp20, Me.gp40, Me.hc40, Me.rf20, Me.rf40, Me.other, Me.surcharges, Me.effective_, Me.t2, Me.t3, Me.t4, Me.t5, Me.t6, Me.t7, Me.cn, Me.transittime, Me.Salesman, Me.userupdate, Me.dateupdate})
        Me.dgdShippingLines.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdShippingLines.Location = New System.Drawing.Point(3, 35)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(1165, 457)
        Me.dgdShippingLines.TabIndex = 40
        '
        'localchargesid
        '
        Me.localchargesid.DataPropertyName = "localchargesid"
        Me.localchargesid.HeaderText = "localchargesid"
        Me.localchargesid.Name = "localchargesid"
        Me.localchargesid.Visible = False
        '
        'IO
        '
        Me.IO.DataPropertyName = "IO"
        Me.IO.HeaderText = "IO"
        Me.IO.Name = "IO"
        Me.IO.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IO.Visible = False
        Me.IO.Width = 43
        '
        'Items
        '
        Me.Items.DataPropertyName = "items"
        Me.Items.HeaderText = "Items"
        Me.Items.Name = "Items"
        Me.Items.Width = 57
        '
        'destination
        '
        Me.destination.DataPropertyName = "destination"
        Me.destination.HeaderText = "Origin Country"
        Me.destination.Name = "destination"
        Me.destination.Width = 90
        '
        'POl
        '
        Me.POl.DataPropertyName = "POl"
        Me.POl.HeaderText = "POL"
        Me.POl.Name = "POl"
        Me.POl.Width = 53
        '
        'mainports
        '
        Me.mainports.DataPropertyName = "mainports"
        Me.mainports.HeaderText = "POD"
        Me.mainports.Name = "mainports"
        Me.mainports.Width = 55
        '
        'carrier
        '
        Me.carrier.DataPropertyName = "carrier"
        Me.carrier.HeaderText = "Carrier"
        Me.carrier.Name = "carrier"
        Me.carrier.Width = 62
        '
        'coloader
        '
        Me.coloader.DataPropertyName = "coloader"
        Me.coloader.HeaderText = "Co-Loader"
        Me.coloader.Name = "coloader"
        Me.coloader.Width = 81
        '
        'commodity
        '
        Me.commodity.DataPropertyName = "commodity"
        Me.commodity.HeaderText = "Commodity"
        Me.commodity.Name = "commodity"
        Me.commodity.Width = 83
        '
        'service
        '
        Me.service.DataPropertyName = "service"
        Me.service.HeaderText = "Service"
        Me.service.Name = "service"
        Me.service.Width = 68
        '
        'gp20
        '
        Me.gp20.DataPropertyName = "gp20"
        Me.gp20.HeaderText = "20 GP"
        Me.gp20.Name = "gp20"
        Me.gp20.Width = 58
        '
        'gp40
        '
        Me.gp40.DataPropertyName = "gp40"
        Me.gp40.HeaderText = "40 GP"
        Me.gp40.Name = "gp40"
        Me.gp40.Width = 58
        '
        'hc40
        '
        Me.hc40.DataPropertyName = "hc40"
        Me.hc40.HeaderText = "40 HC"
        Me.hc40.Name = "hc40"
        Me.hc40.Width = 58
        '
        'rf20
        '
        Me.rf20.DataPropertyName = "rf20"
        Me.rf20.HeaderText = "20 RF"
        Me.rf20.Name = "rf20"
        Me.rf20.Width = 57
        '
        'rf40
        '
        Me.rf40.DataPropertyName = "rf40"
        Me.rf40.HeaderText = "40 RF"
        Me.rf40.Name = "rf40"
        Me.rf40.Width = 57
        '
        'other
        '
        Me.other.DataPropertyName = "other"
        Me.other.HeaderText = "Other Container"
        Me.other.Name = "other"
        Me.other.Width = 97
        '
        'surcharges
        '
        Me.surcharges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.surcharges.DataPropertyName = "surcharges"
        Me.surcharges.HeaderText = "Surcharges (Right click for details)"
        Me.surcharges.Name = "surcharges"
        Me.surcharges.ToolTipText = "Right click for details"
        Me.surcharges.Width = 133
        '
        'effective_
        '
        Me.effective_.DataPropertyName = "effective"
        Me.effective_.HeaderText = "Effective"
        Me.effective_.Name = "effective_"
        Me.effective_.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.effective_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.effective_.Width = 74
        '
        't2
        '
        Me.t2.DataPropertyName = "t2"
        Me.t2.HeaderText = "T2"
        Me.t2.Name = "t2"
        Me.t2.Width = 45
        '
        't3
        '
        Me.t3.DataPropertyName = "t3"
        Me.t3.HeaderText = "T3"
        Me.t3.Name = "t3"
        Me.t3.Width = 45
        '
        't4
        '
        Me.t4.DataPropertyName = "t4"
        Me.t4.HeaderText = "T4"
        Me.t4.Name = "t4"
        Me.t4.Width = 45
        '
        't5
        '
        Me.t5.DataPropertyName = "t5"
        Me.t5.HeaderText = "T5"
        Me.t5.Name = "t5"
        Me.t5.Width = 45
        '
        't6
        '
        Me.t6.DataPropertyName = "t6"
        Me.t6.HeaderText = "T6"
        Me.t6.Name = "t6"
        Me.t6.Width = 45
        '
        't7
        '
        Me.t7.DataPropertyName = "t7"
        Me.t7.HeaderText = "T7"
        Me.t7.Name = "t7"
        Me.t7.Width = 45
        '
        'cn
        '
        Me.cn.DataPropertyName = "cn"
        Me.cn.HeaderText = "CN"
        Me.cn.Name = "cn"
        Me.cn.Width = 47
        '
        'transittime
        '
        Me.transittime.DataPropertyName = "transittime"
        Me.transittime.HeaderText = "Transit Time"
        Me.transittime.Name = "transittime"
        Me.transittime.Width = 83
        '
        'Salesman
        '
        Me.Salesman.DataPropertyName = "Salesman"
        Me.Salesman.HeaderText = "Sales Man"
        Me.Salesman.Name = "Salesman"
        Me.Salesman.Width = 57
        '
        'userupdate
        '
        Me.userupdate.DataPropertyName = "userupdate"
        Me.userupdate.HeaderText = "User Update"
        Me.userupdate.Name = "userupdate"
        Me.userupdate.Width = 85
        '
        'dateupdate
        '
        Me.dateupdate.DataPropertyName = "dateupdate"
        Me.dateupdate.HeaderText = "Date Update"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Width = 86
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(327, 7)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(43, 23)
        Me.Button10.TabIndex = 55
        Me.Button10.Text = "Clips"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'frmLocalCharges
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1180, 504)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmLocalCharges"
        Me.Text = "Local Charges"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RightClickForDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents txtSurcharges As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents localchargesid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Items As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents destination As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mainports As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents carrier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coloader As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commodity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gp20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gp40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hc40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rf20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rf40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents other As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents surcharges As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents effective_ As TSA.CalendarColumn
    Friend WithEvents t2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents transittime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Salesman As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button10 As System.Windows.Forms.Button
End Class
