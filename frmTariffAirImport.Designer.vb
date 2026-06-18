<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTariffAirImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTariffAirImport))
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
        Me.tariffAirImportID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.country = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.origin = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dischargePort = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coloader = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lcl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.min = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kg1544 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kg45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kg100 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kg300 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kg500 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kg1000 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kgfsc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.kgssc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.surcharges = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.effective = New TSA.CalendarColumn()
        Me.t2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.t7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transittime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salesman = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RightClickForDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CalendarColumn1 = New TSA.CalendarColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtSurcharges = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button10 = New System.Windows.Forms.Button()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 23)
        Me.Button6.TabIndex = 52
        Me.Button6.Text = "Load"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(695, 11)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(52, 23)
        Me.Button5.TabIndex = 51
        Me.Button5.Text = "Ok"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(474, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Search :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(527, 14)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 20)
        Me.TextBox1.TabIndex = 49
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(104, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 23)
        Me.Button4.TabIndex = 48
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(58, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 23)
        Me.Button3.TabIndex = 47
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(266, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 46
        Me.Button2.Text = "Export..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(214, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 45
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(163, 12)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(46, 23)
        Me.cmdSaveService.TabIndex = 44
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
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tariffAirImportID, Me.country, Me.origin, Me.dischargePort, Me.coloader, Me.lcl, Me.min, Me.kg1544, Me.kg45, Me.kg100, Me.kg300, Me.kg500, Me.kg1000, Me.kgfsc, Me.kgssc, Me.surcharges, Me.effective, Me.t2, Me.t3, Me.t4, Me.t5, Me.t6, Me.t7, Me.cn, Me.transittime, Me.Remarks, Me.Salesman, Me.userupdate, Me.dateupdate})
        Me.dgdShippingLines.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdShippingLines.Location = New System.Drawing.Point(3, 41)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(1256, 476)
        Me.dgdShippingLines.TabIndex = 43
        '
        'tariffAirImportID
        '
        Me.tariffAirImportID.DataPropertyName = "tariffAirImportID"
        Me.tariffAirImportID.HeaderText = "tariffaIRImport"
        Me.tariffAirImportID.Name = "tariffAirImportID"
        Me.tariffAirImportID.Visible = False
        Me.tariffAirImportID.Width = 98
        '
        'country
        '
        Me.country.DataPropertyName = "country"
        Me.country.HeaderText = "Origin Country"
        Me.country.Name = "country"
        Me.country.Width = 98
        '
        'origin
        '
        Me.origin.DataPropertyName = "origin"
        Me.origin.HeaderText = "POL"
        Me.origin.Name = "origin"
        Me.origin.Width = 53
        '
        'dischargePort
        '
        Me.dischargePort.DataPropertyName = "dischargePort"
        Me.dischargePort.HeaderText = "POD"
        Me.dischargePort.Name = "dischargePort"
        Me.dischargePort.Width = 55
        '
        'coloader
        '
        Me.coloader.DataPropertyName = "coloader"
        Me.coloader.HeaderText = "Co-Loader"
        Me.coloader.Name = "coloader"
        Me.coloader.Width = 81
        '
        'lcl
        '
        Me.lcl.DataPropertyName = "lcl"
        Me.lcl.HeaderText = "LCL"
        Me.lcl.Name = "lcl"
        Me.lcl.Width = 51
        '
        'min
        '
        Me.min.DataPropertyName = "Min"
        Me.min.HeaderText = "Min 1-14"
        Me.min.Name = "min"
        Me.min.Width = 73
        '
        'kg1544
        '
        Me.kg1544.DataPropertyName = "kg1544"
        Me.kg1544.HeaderText = "Normal 15-44"
        Me.kg1544.Name = "kg1544"
        Me.kg1544.Width = 95
        '
        'kg45
        '
        Me.kg45.DataPropertyName = "kg45"
        Me.kg45.HeaderText = "+45"
        Me.kg45.Name = "kg45"
        Me.kg45.Width = 50
        '
        'kg100
        '
        Me.kg100.DataPropertyName = "kg100"
        Me.kg100.HeaderText = "+100"
        Me.kg100.Name = "kg100"
        Me.kg100.Width = 56
        '
        'kg300
        '
        Me.kg300.DataPropertyName = "kg300"
        Me.kg300.HeaderText = "+300"
        Me.kg300.Name = "kg300"
        Me.kg300.Width = 56
        '
        'kg500
        '
        Me.kg500.DataPropertyName = "kg500"
        Me.kg500.HeaderText = "+500"
        Me.kg500.Name = "kg500"
        Me.kg500.Width = 56
        '
        'kg1000
        '
        Me.kg1000.DataPropertyName = "kg1000"
        Me.kg1000.HeaderText = "+1000"
        Me.kg1000.Name = "kg1000"
        Me.kg1000.Width = 62
        '
        'kgfsc
        '
        Me.kgfsc.DataPropertyName = "kgfsc"
        Me.kgfsc.HeaderText = "FSC"
        Me.kgfsc.Name = "kgfsc"
        Me.kgfsc.Width = 52
        '
        'kgssc
        '
        Me.kgssc.DataPropertyName = "kgssc"
        Me.kgssc.HeaderText = "SSC"
        Me.kgssc.Name = "kgssc"
        Me.kgssc.Width = 53
        '
        'surcharges
        '
        Me.surcharges.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.surcharges.DataPropertyName = "surcharges"
        Me.surcharges.HeaderText = "Surcharges"
        Me.surcharges.Name = "surcharges"
        Me.surcharges.Width = 86
        '
        'effective
        '
        Me.effective.DataPropertyName = "effective"
        Me.effective.HeaderText = "Effective"
        Me.effective.Name = "effective"
        Me.effective.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.effective.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.effective.Width = 74
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
        Me.transittime.Width = 90
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 74
        '
        'Salesman
        '
        Me.Salesman.DataPropertyName = "Salesman"
        Me.Salesman.HeaderText = "Sales Man"
        Me.Salesman.Name = "Salesman"
        Me.Salesman.Width = 63
        '
        'userupdate
        '
        Me.userupdate.DataPropertyName = "userupdate"
        Me.userupdate.HeaderText = "User Update"
        Me.userupdate.Name = "userupdate"
        Me.userupdate.Width = 92
        '
        'dateupdate
        '
        Me.dateupdate.DataPropertyName = "dateupdate"
        Me.dateupdate.HeaderText = "Date Update"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Width = 93
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
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "tariffaIRImport"
        Me.DataGridViewTextBoxColumn1.HeaderText = "tariffaIRImport"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "country"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Country"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "origin"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Origin"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "dischargePort"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Discharge Port"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "coloader"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Co-Loader"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "lcl"
        Me.DataGridViewTextBoxColumn6.HeaderText = "LCL"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Min"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Min"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "surcharges"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Surcharges"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'CalendarColumn1
        '
        Me.CalendarColumn1.DataPropertyName = "effective"
        Me.CalendarColumn1.HeaderText = "Effective"
        Me.CalendarColumn1.Name = "CalendarColumn1"
        Me.CalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "t2"
        Me.DataGridViewTextBoxColumn9.HeaderText = "T2"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "t3"
        Me.DataGridViewTextBoxColumn10.HeaderText = "T3"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "t4"
        Me.DataGridViewTextBoxColumn11.HeaderText = "T4"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "t5"
        Me.DataGridViewTextBoxColumn12.HeaderText = "T5"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "t6"
        Me.DataGridViewTextBoxColumn13.HeaderText = "T6"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "t7"
        Me.DataGridViewTextBoxColumn14.HeaderText = "T7"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "cn"
        Me.DataGridViewTextBoxColumn15.HeaderText = "CN"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "transittime"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Transit Time"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "userupdate"
        Me.DataGridViewTextBoxColumn17.HeaderText = "User Update"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "dateupdate"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Date Update"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(768, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "Search (Column) :"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(1141, 8)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 23)
        Me.Button7.TabIndex = 55
        Me.Button7.Text = "Ok"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(989, 11)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(146, 20)
        Me.TextBox2.TabIndex = 54
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Country", "Orgin", "DischargePort", "Coloader"})
        Me.ComboBox1.Location = New System.Drawing.Point(862, 10)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 53
        Me.ComboBox1.Text = "Country"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Yellow
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.txtSurcharges)
        Me.GroupBox1.Location = New System.Drawing.Point(474, 133)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 263)
        Me.GroupBox1.TabIndex = 57
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
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 1000000
        Me.ToolTip1.ReshowDelay = 200
        Me.ToolTip1.ShowAlways = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(327, 12)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(43, 23)
        Me.Button10.TabIndex = 58
        Me.Button10.Text = "Clips"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'frmTariffAirImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1270, 529)
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
        Me.Name = "frmTariffAirImport"
        Me.Text = "Tariff Air Import"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CalendarColumn1 As TSA.CalendarColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents txtSurcharges As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RightClickForDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tariffAirImportID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents country As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents origin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dischargePort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coloader As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lcl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents min As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kg1544 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kg45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kg100 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kg300 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kg500 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kg1000 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kgfsc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents kgssc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents surcharges As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents effective As TSA.CalendarColumn
    Friend WithEvents t2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents t7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents transittime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Salesman As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button10 As System.Windows.Forms.Button
End Class
