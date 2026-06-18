<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreightTariffMarket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFreightTariffMarket))
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.FreightTariffID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MarketCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApplyDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateExp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TariffREF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateREF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InsertToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabFreightInfo = New System.Windows.Forms.TabPage
        Me.FraupdateMarket = New System.Windows.Forms.GroupBox
        Me.cboPOD = New System.Windows.Forms.ComboBox
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.Label177 = New System.Windows.Forms.Label
        Me.Label178 = New System.Windows.Forms.Label
        Me.Label221 = New System.Windows.Forms.Label
        Me.dtpDateREF = New System.Windows.Forms.DateTimePicker
        Me.Label222 = New System.Windows.Forms.Label
        Me.txtTariffREF = New System.Windows.Forms.TextBox
        Me.dtpDateExp = New System.Windows.Forms.DateTimePicker
        Me.Label194 = New System.Windows.Forms.Label
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.txtMarketCode = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.tabFreight = New System.Windows.Forms.TabPage
        Me.grpTariff = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtunit = New System.Windows.Forms.TextBox
        Me.cmdCancelFreight = New System.Windows.Forms.Button
        Me.cmdOkFreight = New System.Windows.Forms.Button
        Me.dgdFreight = New System.Windows.Forms.DataGridView
        Me.FreightID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveF = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ctmnuFreight = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CargoctmnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.CargoctmnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.CargoctmnuDel = New System.Windows.Forms.ToolStripMenuItem
        Me.Label171 = New System.Windows.Forms.Label
        Me.txtRate = New System.Windows.Forms.TextBox
        Me.Label170 = New System.Windows.Forms.Label
        Me.cboType = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMarketCode = New System.Windows.Forms.ComboBox
        Me.fraupdate = New System.Windows.Forms.GroupBox
        Me.InputFromXLSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabFreightInfo.SuspendLayout()
        Me.FraupdateMarket.SuspendLayout()
        Me.tabFreight.SuspendLayout()
        Me.grpTariff.SuspendLayout()
        CType(Me.dgdFreight, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmnuFreight.SuspendLayout()
        Me.fraupdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FreightTariffID, Me.MarketCode, Me.ApplyDate, Me.DateExp, Me.TariffREF, Me.DateREF, Me.POL, Me.POD, Me.UserID, Me.UpdateTime, Me.Approve})
        Me.dgdData.Location = New System.Drawing.Point(12, 49)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(934, 259)
        Me.dgdData.TabIndex = 8
        '
        'FreightTariffID
        '
        Me.FreightTariffID.DataPropertyName = "FreightTariffID"
        Me.FreightTariffID.HeaderText = "FreightTariffID"
        Me.FreightTariffID.Name = "FreightTariffID"
        Me.FreightTariffID.ReadOnly = True
        Me.FreightTariffID.Visible = False
        '
        'MarketCode
        '
        Me.MarketCode.DataPropertyName = "MarketCode"
        Me.MarketCode.HeaderText = "Market Code"
        Me.MarketCode.Name = "MarketCode"
        Me.MarketCode.ReadOnly = True
        '
        'ApplyDate
        '
        Me.ApplyDate.DataPropertyName = "Date"
        Me.ApplyDate.HeaderText = "Date"
        Me.ApplyDate.Name = "ApplyDate"
        Me.ApplyDate.ReadOnly = True
        '
        'DateExp
        '
        Me.DateExp.DataPropertyName = "DateExp"
        Me.DateExp.HeaderText = "Date EXP"
        Me.DateExp.Name = "DateExp"
        Me.DateExp.ReadOnly = True
        '
        'TariffREF
        '
        Me.TariffREF.DataPropertyName = "TariffREF"
        Me.TariffREF.HeaderText = "Tariff Ref"
        Me.TariffREF.Name = "TariffREF"
        Me.TariffREF.ReadOnly = True
        '
        'DateREF
        '
        Me.DateREF.DataPropertyName = "DateREF"
        Me.DateREF.HeaderText = "Date REF"
        Me.DateREF.Name = "DateREF"
        Me.DateREF.ReadOnly = True
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.ReadOnly = True
        '
        'POD
        '
        Me.POD.DataPropertyName = "POD"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        Me.POD.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "Update Time"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.ReadOnly = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(694, 240)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(775, 240)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 12
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.InsertToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.mnuExportExcel, Me.InputFromXLSToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(956, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'InsertToolStripMenuItem
        '
        Me.InsertToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.InsertToolStripMenuItem.Name = "InsertToolStripMenuItem"
        Me.InsertToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.InsertToolStripMenuItem.Text = "Insert"
        Me.InsertToolStripMenuItem.Visible = False
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'mnuExportExcel
        '
        Me.mnuExportExcel.ForeColor = System.Drawing.Color.DarkRed
        Me.mnuExportExcel.Name = "mnuExportExcel"
        Me.mnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.mnuExportExcel.Text = "Export Excel"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabFreightInfo)
        Me.TabControl1.Controls.Add(Me.tabFreight)
        Me.TabControl1.Location = New System.Drawing.Point(12, 19)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(897, 216)
        Me.TabControl1.TabIndex = 16
        '
        'tabFreightInfo
        '
        Me.tabFreightInfo.Controls.Add(Me.FraupdateMarket)
        Me.tabFreightInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabFreightInfo.Name = "tabFreightInfo"
        Me.tabFreightInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFreightInfo.Size = New System.Drawing.Size(889, 190)
        Me.tabFreightInfo.TabIndex = 0
        Me.tabFreightInfo.Text = "Freight Info"
        Me.tabFreightInfo.UseVisualStyleBackColor = True
        '
        'FraupdateMarket
        '
        Me.FraupdateMarket.Controls.Add(Me.cboPOD)
        Me.FraupdateMarket.Controls.Add(Me.cboPOL)
        Me.FraupdateMarket.Controls.Add(Me.Label177)
        Me.FraupdateMarket.Controls.Add(Me.Label178)
        Me.FraupdateMarket.Controls.Add(Me.Label221)
        Me.FraupdateMarket.Controls.Add(Me.dtpDateREF)
        Me.FraupdateMarket.Controls.Add(Me.Label222)
        Me.FraupdateMarket.Controls.Add(Me.txtTariffREF)
        Me.FraupdateMarket.Controls.Add(Me.dtpDateExp)
        Me.FraupdateMarket.Controls.Add(Me.Label194)
        Me.FraupdateMarket.Controls.Add(Me.dtpDate)
        Me.FraupdateMarket.Controls.Add(Me.txtMarketCode)
        Me.FraupdateMarket.Controls.Add(Me.Label34)
        Me.FraupdateMarket.Controls.Add(Me.Label35)
        Me.FraupdateMarket.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.FraupdateMarket.Location = New System.Drawing.Point(3, 0)
        Me.FraupdateMarket.Name = "FraupdateMarket"
        Me.FraupdateMarket.Size = New System.Drawing.Size(883, 187)
        Me.FraupdateMarket.TabIndex = 4
        Me.FraupdateMarket.TabStop = False
        '
        'cboPOD
        '
        Me.cboPOD.FormattingEnabled = True
        Me.cboPOD.Location = New System.Drawing.Point(418, 97)
        Me.cboPOD.Name = "cboPOD"
        Me.cboPOD.Size = New System.Drawing.Size(199, 21)
        Me.cboPOD.TabIndex = 41
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(97, 102)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(199, 21)
        Me.cboPOL.TabIndex = 42
        '
        'Label177
        '
        Me.Label177.AutoSize = True
        Me.Label177.ForeColor = System.Drawing.Color.Maroon
        Me.Label177.Location = New System.Drawing.Point(351, 101)
        Me.Label177.Name = "Label177"
        Me.Label177.Size = New System.Drawing.Size(64, 13)
        Me.Label177.TabIndex = 39
        Me.Label177.Text = "POD Code :"
        '
        'Label178
        '
        Me.Label178.AutoSize = True
        Me.Label178.ForeColor = System.Drawing.Color.Maroon
        Me.Label178.Location = New System.Drawing.Point(32, 106)
        Me.Label178.Name = "Label178"
        Me.Label178.Size = New System.Drawing.Size(62, 13)
        Me.Label178.TabIndex = 40
        Me.Label178.Text = "POL Code :"
        '
        'Label221
        '
        Me.Label221.AutoSize = True
        Me.Label221.Location = New System.Drawing.Point(355, 48)
        Me.Label221.Name = "Label221"
        Me.Label221.Size = New System.Drawing.Size(61, 13)
        Me.Label221.TabIndex = 38
        Me.Label221.Text = "Tariff REF :"
        '
        'dtpDateREF
        '
        Me.dtpDateREF.Location = New System.Drawing.Point(417, 71)
        Me.dtpDateREF.Name = "dtpDateREF"
        Me.dtpDateREF.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateREF.TabIndex = 37
        '
        'Label222
        '
        Me.Label222.AutoSize = True
        Me.Label222.Location = New System.Drawing.Point(357, 74)
        Me.Label222.Name = "Label222"
        Me.Label222.Size = New System.Drawing.Size(60, 13)
        Me.Label222.TabIndex = 36
        Me.Label222.Text = "Date REF :"
        '
        'txtTariffREF
        '
        Me.txtTariffREF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTariffREF.Location = New System.Drawing.Point(417, 48)
        Me.txtTariffREF.MaxLength = 50
        Me.txtTariffREF.Name = "txtTariffREF"
        Me.txtTariffREF.Size = New System.Drawing.Size(200, 20)
        Me.txtTariffREF.TabIndex = 35
        '
        'dtpDateExp
        '
        Me.dtpDateExp.Location = New System.Drawing.Point(96, 78)
        Me.dtpDateExp.Name = "dtpDateExp"
        Me.dtpDateExp.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateExp.TabIndex = 34
        '
        'Label194
        '
        Me.Label194.AutoSize = True
        Me.Label194.Location = New System.Drawing.Point(36, 81)
        Me.Label194.Name = "Label194"
        Me.Label194.Size = New System.Drawing.Size(57, 13)
        Me.Label194.TabIndex = 33
        Me.Label194.Text = "Date Exp :"
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(96, 52)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpDate.TabIndex = 1
        '
        'txtMarketCode
        '
        Me.txtMarketCode.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtMarketCode.Location = New System.Drawing.Point(96, 22)
        Me.txtMarketCode.Name = "txtMarketCode"
        Me.txtMarketCode.ReadOnly = True
        Me.txtMarketCode.Size = New System.Drawing.Size(54, 20)
        Me.txtMarketCode.TabIndex = 0
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(57, 55)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Date :"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(19, 26)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(74, 13)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "Market Code :"
        '
        'tabFreight
        '
        Me.tabFreight.Controls.Add(Me.grpTariff)
        Me.tabFreight.Location = New System.Drawing.Point(4, 22)
        Me.tabFreight.Name = "tabFreight"
        Me.tabFreight.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFreight.Size = New System.Drawing.Size(889, 190)
        Me.tabFreight.TabIndex = 1
        Me.tabFreight.Text = "Freight"
        Me.tabFreight.UseVisualStyleBackColor = True
        '
        'grpTariff
        '
        Me.grpTariff.Controls.Add(Me.Label2)
        Me.grpTariff.Controls.Add(Me.txtunit)
        Me.grpTariff.Controls.Add(Me.cmdCancelFreight)
        Me.grpTariff.Controls.Add(Me.cmdOkFreight)
        Me.grpTariff.Controls.Add(Me.dgdFreight)
        Me.grpTariff.Controls.Add(Me.Label171)
        Me.grpTariff.Controls.Add(Me.txtRate)
        Me.grpTariff.Controls.Add(Me.Label170)
        Me.grpTariff.Controls.Add(Me.cboType)
        Me.grpTariff.Location = New System.Drawing.Point(6, 9)
        Me.grpTariff.Name = "grpTariff"
        Me.grpTariff.Size = New System.Drawing.Size(880, 175)
        Me.grpTariff.TabIndex = 7
        Me.grpTariff.TabStop = False
        Me.grpTariff.Text = "Special Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(346, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Unit :"
        '
        'txtunit
        '
        Me.txtunit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunit.Location = New System.Drawing.Point(381, 143)
        Me.txtunit.Name = "txtunit"
        Me.txtunit.Size = New System.Drawing.Size(36, 20)
        Me.txtunit.TabIndex = 21
        '
        'cmdCancelFreight
        '
        Me.cmdCancelFreight.Location = New System.Drawing.Point(471, 142)
        Me.cmdCancelFreight.Name = "cmdCancelFreight"
        Me.cmdCancelFreight.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelFreight.TabIndex = 20
        Me.cmdCancelFreight.Text = "Cancel"
        Me.cmdCancelFreight.UseVisualStyleBackColor = True
        '
        'cmdOkFreight
        '
        Me.cmdOkFreight.Enabled = False
        Me.cmdOkFreight.Location = New System.Drawing.Point(552, 142)
        Me.cmdOkFreight.Name = "cmdOkFreight"
        Me.cmdOkFreight.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkFreight.TabIndex = 20
        Me.cmdOkFreight.Text = "OK"
        Me.cmdOkFreight.UseVisualStyleBackColor = True
        '
        'dgdFreight
        '
        Me.dgdFreight.AllowUserToAddRows = False
        Me.dgdFreight.AllowUserToDeleteRows = False
        Me.dgdFreight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdFreight.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FreightID, Me.ContainerType, Me.Rate, Me.Unit, Me.ApproveF})
        Me.dgdFreight.ContextMenuStrip = Me.ctmnuFreight
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdFreight.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgdFreight.Location = New System.Drawing.Point(10, 15)
        Me.dgdFreight.Name = "dgdFreight"
        Me.dgdFreight.ReadOnly = True
        Me.dgdFreight.Size = New System.Drawing.Size(561, 120)
        Me.dgdFreight.TabIndex = 19
        '
        'FreightID
        '
        Me.FreightID.DataPropertyName = "FreightID"
        Me.FreightID.HeaderText = "FreightID"
        Me.FreightID.Name = "FreightID"
        Me.FreightID.ReadOnly = True
        Me.FreightID.Visible = False
        '
        'ContainerType
        '
        Me.ContainerType.DataPropertyName = "containerType"
        Me.ContainerType.HeaderText = "Cont. Type"
        Me.ContainerType.Name = "ContainerType"
        Me.ContainerType.ReadOnly = True
        '
        'Rate
        '
        Me.Rate.DataPropertyName = "Rate"
        Me.Rate.HeaderText = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.ReadOnly = True
        '
        'Unit
        '
        Me.Unit.DataPropertyName = "Unit"
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        Me.Unit.ReadOnly = True
        '
        'ApproveF
        '
        Me.ApproveF.DataPropertyName = "Approve"
        Me.ApproveF.HeaderText = "Approve"
        Me.ApproveF.Name = "ApproveF"
        Me.ApproveF.ReadOnly = True
        Me.ApproveF.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApproveF.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ctmnuFreight
        '
        Me.ctmnuFreight.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargoctmnuAdd, Me.CargoctmnuEdit, Me.CargoctmnuDel})
        Me.ctmnuFreight.Name = "ctmnuPrice"
        Me.ctmnuFreight.Size = New System.Drawing.Size(117, 70)
        '
        'CargoctmnuAdd
        '
        Me.CargoctmnuAdd.Image = CType(resources.GetObject("CargoctmnuAdd.Image"), System.Drawing.Image)
        Me.CargoctmnuAdd.Name = "CargoctmnuAdd"
        Me.CargoctmnuAdd.Size = New System.Drawing.Size(116, 22)
        Me.CargoctmnuAdd.Text = "Add"
        '
        'CargoctmnuEdit
        '
        Me.CargoctmnuEdit.Image = CType(resources.GetObject("CargoctmnuEdit.Image"), System.Drawing.Image)
        Me.CargoctmnuEdit.Name = "CargoctmnuEdit"
        Me.CargoctmnuEdit.Size = New System.Drawing.Size(116, 22)
        Me.CargoctmnuEdit.Text = "Edit"
        '
        'CargoctmnuDel
        '
        Me.CargoctmnuDel.Image = CType(resources.GetObject("CargoctmnuDel.Image"), System.Drawing.Image)
        Me.CargoctmnuDel.Name = "CargoctmnuDel"
        Me.CargoctmnuDel.Size = New System.Drawing.Size(116, 22)
        Me.CargoctmnuDel.Text = "Delete"
        '
        'Label171
        '
        Me.Label171.AutoSize = True
        Me.Label171.ForeColor = System.Drawing.Color.Maroon
        Me.Label171.Location = New System.Drawing.Point(208, 147)
        Me.Label171.Name = "Label171"
        Me.Label171.Size = New System.Drawing.Size(36, 13)
        Me.Label171.TabIndex = 18
        Me.Label171.Text = "Rate :"
        '
        'txtRate
        '
        Me.txtRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRate.Location = New System.Drawing.Point(246, 143)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(87, 20)
        Me.txtRate.TabIndex = 17
        '
        'Label170
        '
        Me.Label170.AutoSize = True
        Me.Label170.ForeColor = System.Drawing.Color.Maroon
        Me.Label170.Location = New System.Drawing.Point(18, 147)
        Me.Label170.Name = "Label170"
        Me.Label170.Size = New System.Drawing.Size(85, 13)
        Me.Label170.TabIndex = 16
        Me.Label170.Text = "Container Type :"
        '
        'cboType
        '
        Me.cboType.FormattingEnabled = True
        Me.cboType.Location = New System.Drawing.Point(105, 143)
        Me.cboType.Name = "cboType"
        Me.cboType.Size = New System.Drawing.Size(87, 21)
        Me.cboType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(2, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Market Code :"
        '
        'cboMarketCode
        '
        Me.cboMarketCode.FormattingEnabled = True
        Me.cboMarketCode.Location = New System.Drawing.Point(78, 26)
        Me.cboMarketCode.Name = "cboMarketCode"
        Me.cboMarketCode.Size = New System.Drawing.Size(121, 21)
        Me.cboMarketCode.TabIndex = 17
        '
        'fraupdate
        '
        Me.fraupdate.Controls.Add(Me.TabControl1)
        Me.fraupdate.Controls.Add(Me.cmdOk)
        Me.fraupdate.Controls.Add(Me.cmdCancel)
        Me.fraupdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.fraupdate.Location = New System.Drawing.Point(0, 314)
        Me.fraupdate.Name = "fraupdate"
        Me.fraupdate.Size = New System.Drawing.Size(956, 301)
        Me.fraupdate.TabIndex = 18
        Me.fraupdate.TabStop = False
        Me.fraupdate.Text = "Update"
        '
        'InputFromXLSToolStripMenuItem
        '
        Me.InputFromXLSToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.InputFromXLSToolStripMenuItem.Name = "InputFromXLSToolStripMenuItem"
        Me.InputFromXLSToolStripMenuItem.Size = New System.Drawing.Size(100, 20)
        Me.InputFromXLSToolStripMenuItem.Text = "Import from .XLS"
        '
        'frmFreightTariffMarket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 615)
        Me.Controls.Add(Me.fraupdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMarketCode)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgdData)
        Me.Name = "frmFreightTariffMarket"
        Me.Text = "Freight Tariff"
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabFreightInfo.ResumeLayout(False)
        Me.FraupdateMarket.ResumeLayout(False)
        Me.FraupdateMarket.PerformLayout()
        Me.tabFreight.ResumeLayout(False)
        Me.grpTariff.ResumeLayout(False)
        Me.grpTariff.PerformLayout()
        CType(Me.dgdFreight, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctmnuFreight.ResumeLayout(False)
        Me.fraupdate.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InsertToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabFreightInfo As System.Windows.Forms.TabPage
    Friend WithEvents tabFreight As System.Windows.Forms.TabPage
    Friend WithEvents grpTariff As System.Windows.Forms.GroupBox
    Friend WithEvents dgdFreight As System.Windows.Forms.DataGridView
    Friend WithEvents Label171 As System.Windows.Forms.Label
    Friend WithEvents Label170 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelFreight As System.Windows.Forms.Button
    Friend WithEvents cmdOkFreight As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMarketCode As System.Windows.Forms.ComboBox
    Friend WithEvents fraupdate As System.Windows.Forms.GroupBox
    Friend WithEvents ctmnuFreight As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CargoctmnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargoctmnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargoctmnuDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents FraupdateMarket As System.Windows.Forms.GroupBox
    Friend WithEvents Label221 As System.Windows.Forms.Label
    Friend WithEvents dtpDateREF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label222 As System.Windows.Forms.Label
    Friend WithEvents txtTariffREF As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateExp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label194 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtMarketCode As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents cboPOD As System.Windows.Forms.ComboBox
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents Label178 As System.Windows.Forms.Label
    Friend WithEvents FreightTariffID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarketCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApplyDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateExp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TariffREF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateREF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtunit As System.Windows.Forms.TextBox
    Friend WithEvents FreightID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveF As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents InputFromXLSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
