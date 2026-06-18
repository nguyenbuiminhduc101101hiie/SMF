<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpecialFreightTariffMarket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSpecialFreightTariffMarket))
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.FreightTariffID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MarketCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApplyDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateExp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TariffREF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateREF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveBy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveREF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Customer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Commodity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.FraupdateMin = New System.Windows.Forms.GroupBox
        Me.Label293 = New System.Windows.Forms.Label
        Me.cboPOD = New System.Windows.Forms.ComboBox
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.txtCustomerCode = New System.Windows.Forms.TextBox
        Me.Label227 = New System.Windows.Forms.Label
        Me.Label224 = New System.Windows.Forms.Label
        Me.Label226 = New System.Windows.Forms.Label
        Me.Label225 = New System.Windows.Forms.Label
        Me.Label195 = New System.Windows.Forms.Label
        Me.Label223 = New System.Windows.Forms.Label
        Me.dtpApproveDate = New System.Windows.Forms.DateTimePicker
        Me.dtpDateREF = New System.Windows.Forms.DateTimePicker
        Me.Label196 = New System.Windows.Forms.Label
        Me.dtpDateExp = New System.Windows.Forms.DateTimePicker
        Me.Label113 = New System.Windows.Forms.Label
        Me.Label177 = New System.Windows.Forms.Label
        Me.Label178 = New System.Windows.Forms.Label
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.txtCommodity = New System.Windows.Forms.TextBox
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.txtApproveREF = New System.Windows.Forms.TextBox
        Me.txtApproveBy = New System.Windows.Forms.TextBox
        Me.txtTariffREF = New System.Windows.Forms.TextBox
        Me.Label179 = New System.Windows.Forms.Label
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
        Me.tabFreight = New System.Windows.Forms.TabPage
        Me.grpTariff = New System.Windows.Forms.GroupBox
        Me.cmdCancelFreight = New System.Windows.Forms.Button
        Me.cmdOkFreight = New System.Windows.Forms.Button
        Me.dgdFreight = New System.Windows.Forms.DataGridView
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
        Me.txtunit = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.SpecialFreightID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveF = New System.Windows.Forms.DataGridViewCheckBoxColumn
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.FraupdateMin.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabFreightInfo.SuspendLayout()
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
        Me.dgdData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FreightTariffID, Me.MarketCode, Me.ApplyDate, Me.DateExp, Me.TariffREF, Me.DateREF, Me.POL, Me.POD, Me.ApproveDate, Me.ApproveBy, Me.ApproveREF, Me.Customer, Me.Commodity, Me.UserID, Me.UpdateTime, Me.Approve})
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
        'ApproveDate
        '
        Me.ApproveDate.DataPropertyName = "ApproveDate"
        Me.ApproveDate.HeaderText = "Approve Date"
        Me.ApproveDate.Name = "ApproveDate"
        Me.ApproveDate.ReadOnly = True
        '
        'ApproveBy
        '
        Me.ApproveBy.DataPropertyName = "ApproveBy"
        Me.ApproveBy.HeaderText = "Approve By"
        Me.ApproveBy.Name = "ApproveBy"
        Me.ApproveBy.ReadOnly = True
        '
        'ApproveREF
        '
        Me.ApproveREF.DataPropertyName = "ApproveREF"
        Me.ApproveREF.HeaderText = "Approve REF"
        Me.ApproveREF.Name = "ApproveREF"
        Me.ApproveREF.ReadOnly = True
        '
        'Customer
        '
        Me.Customer.DataPropertyName = "Customer"
        Me.Customer.HeaderText = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.ReadOnly = True
        '
        'Commodity
        '
        Me.Commodity.DataPropertyName = "Commodity"
        Me.Commodity.HeaderText = "Commodity"
        Me.Commodity.Name = "Commodity"
        Me.Commodity.ReadOnly = True
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
        'FraupdateMin
        '
        Me.FraupdateMin.Controls.Add(Me.Label293)
        Me.FraupdateMin.Controls.Add(Me.cboPOD)
        Me.FraupdateMin.Controls.Add(Me.cboPOL)
        Me.FraupdateMin.Controls.Add(Me.txtCustomerCode)
        Me.FraupdateMin.Controls.Add(Me.Label227)
        Me.FraupdateMin.Controls.Add(Me.Label224)
        Me.FraupdateMin.Controls.Add(Me.Label226)
        Me.FraupdateMin.Controls.Add(Me.Label225)
        Me.FraupdateMin.Controls.Add(Me.Label195)
        Me.FraupdateMin.Controls.Add(Me.Label223)
        Me.FraupdateMin.Controls.Add(Me.dtpApproveDate)
        Me.FraupdateMin.Controls.Add(Me.dtpDateREF)
        Me.FraupdateMin.Controls.Add(Me.Label196)
        Me.FraupdateMin.Controls.Add(Me.dtpDateExp)
        Me.FraupdateMin.Controls.Add(Me.Label113)
        Me.FraupdateMin.Controls.Add(Me.Label177)
        Me.FraupdateMin.Controls.Add(Me.Label178)
        Me.FraupdateMin.Controls.Add(Me.dtpDate)
        Me.FraupdateMin.Controls.Add(Me.txtCommodity)
        Me.FraupdateMin.Controls.Add(Me.txtCustomer)
        Me.FraupdateMin.Controls.Add(Me.txtApproveREF)
        Me.FraupdateMin.Controls.Add(Me.txtApproveBy)
        Me.FraupdateMin.Controls.Add(Me.txtTariffREF)
        Me.FraupdateMin.Controls.Add(Me.Label179)
        Me.FraupdateMin.Location = New System.Drawing.Point(6, 3)
        Me.FraupdateMin.Name = "FraupdateMin"
        Me.FraupdateMin.Size = New System.Drawing.Size(956, 181)
        Me.FraupdateMin.TabIndex = 7
        Me.FraupdateMin.TabStop = False
        '
        'Label293
        '
        Me.Label293.AutoSize = True
        Me.Label293.ForeColor = System.Drawing.Color.Maroon
        Me.Label293.Location = New System.Drawing.Point(329, 24)
        Me.Label293.Name = "Label293"
        Me.Label293.Size = New System.Drawing.Size(85, 13)
        Me.Label293.TabIndex = 15
        Me.Label293.Text = "Customer Code :"
        '
        'cboPOD
        '
        Me.cboPOD.FormattingEnabled = True
        Me.cboPOD.Location = New System.Drawing.Point(95, 120)
        Me.cboPOD.Name = "cboPOD"
        Me.cboPOD.Size = New System.Drawing.Size(199, 21)
        Me.cboPOD.TabIndex = 17
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(95, 94)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(199, 21)
        Me.cboPOL.TabIndex = 17
        '
        'txtCustomerCode
        '
        Me.txtCustomerCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomerCode.Location = New System.Drawing.Point(418, 21)
        Me.txtCustomerCode.Name = "txtCustomerCode"
        Me.txtCustomerCode.Size = New System.Drawing.Size(94, 20)
        Me.txtCustomerCode.TabIndex = 14
        '
        'Label227
        '
        Me.Label227.AutoSize = True
        Me.Label227.ForeColor = System.Drawing.Color.Maroon
        Me.Label227.Location = New System.Drawing.Point(350, 78)
        Me.Label227.Name = "Label227"
        Me.Label227.Size = New System.Drawing.Size(64, 13)
        Me.Label227.TabIndex = 9
        Me.Label227.Text = "Commodity :"
        '
        'Label224
        '
        Me.Label224.AutoSize = True
        Me.Label224.ForeColor = System.Drawing.Color.Maroon
        Me.Label224.Location = New System.Drawing.Point(357, 50)
        Me.Label224.Name = "Label224"
        Me.Label224.Size = New System.Drawing.Size(57, 13)
        Me.Label224.TabIndex = 9
        Me.Label224.Text = "Customer :"
        '
        'Label226
        '
        Me.Label226.AutoSize = True
        Me.Label226.ForeColor = System.Drawing.Color.Maroon
        Me.Label226.Location = New System.Drawing.Point(337, 130)
        Me.Label226.Name = "Label226"
        Me.Label226.Size = New System.Drawing.Size(77, 13)
        Me.Label226.TabIndex = 9
        Me.Label226.Text = "Approve REF :"
        '
        'Label225
        '
        Me.Label225.AutoSize = True
        Me.Label225.ForeColor = System.Drawing.Color.Maroon
        Me.Label225.Location = New System.Drawing.Point(346, 104)
        Me.Label225.Name = "Label225"
        Me.Label225.Size = New System.Drawing.Size(68, 13)
        Me.Label225.TabIndex = 9
        Me.Label225.Text = "Approve By :"
        '
        'Label195
        '
        Me.Label195.AutoSize = True
        Me.Label195.ForeColor = System.Drawing.Color.Maroon
        Me.Label195.Location = New System.Drawing.Point(1, 21)
        Me.Label195.Name = "Label195"
        Me.Label195.Size = New System.Drawing.Size(91, 13)
        Me.Label195.TabIndex = 9
        Me.Label195.Text = "Special Rate No.:"
        '
        'Label223
        '
        Me.Label223.AutoSize = True
        Me.Label223.ForeColor = System.Drawing.Color.Maroon
        Me.Label223.Location = New System.Drawing.Point(335, 157)
        Me.Label223.Name = "Label223"
        Me.Label223.Size = New System.Drawing.Size(79, 13)
        Me.Label223.TabIndex = 7
        Me.Label223.Text = "Approve Date :"
        '
        'dtpApproveDate
        '
        Me.dtpApproveDate.Location = New System.Drawing.Point(418, 154)
        Me.dtpApproveDate.Name = "dtpApproveDate"
        Me.dtpApproveDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpApproveDate.TabIndex = 7
        '
        'dtpDateREF
        '
        Me.dtpDateREF.Location = New System.Drawing.Point(95, 149)
        Me.dtpDateREF.Name = "dtpDateREF"
        Me.dtpDateREF.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateREF.TabIndex = 6
        '
        'Label196
        '
        Me.Label196.AutoSize = True
        Me.Label196.ForeColor = System.Drawing.Color.Maroon
        Me.Label196.Location = New System.Drawing.Point(32, 152)
        Me.Label196.Name = "Label196"
        Me.Label196.Size = New System.Drawing.Size(60, 13)
        Me.Label196.TabIndex = 7
        Me.Label196.Text = "Date REF :"
        '
        'dtpDateExp
        '
        Me.dtpDateExp.Location = New System.Drawing.Point(95, 69)
        Me.dtpDateExp.Name = "dtpDateExp"
        Me.dtpDateExp.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateExp.TabIndex = 2
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.ForeColor = System.Drawing.Color.Maroon
        Me.Label113.Location = New System.Drawing.Point(35, 72)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(57, 13)
        Me.Label113.TabIndex = 7
        Me.Label113.Text = "Date Exp :"
        '
        'Label177
        '
        Me.Label177.AutoSize = True
        Me.Label177.ForeColor = System.Drawing.Color.Maroon
        Me.Label177.Location = New System.Drawing.Point(28, 124)
        Me.Label177.Name = "Label177"
        Me.Label177.Size = New System.Drawing.Size(64, 13)
        Me.Label177.TabIndex = 4
        Me.Label177.Text = "POD Code :"
        '
        'Label178
        '
        Me.Label178.AutoSize = True
        Me.Label178.ForeColor = System.Drawing.Color.Maroon
        Me.Label178.Location = New System.Drawing.Point(30, 98)
        Me.Label178.Name = "Label178"
        Me.Label178.Size = New System.Drawing.Size(62, 13)
        Me.Label178.TabIndex = 4
        Me.Label178.Text = "POL Code :"
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(95, 43)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpDate.TabIndex = 1
        '
        'txtCommodity
        '
        Me.txtCommodity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCommodity.Location = New System.Drawing.Point(418, 76)
        Me.txtCommodity.Name = "txtCommodity"
        Me.txtCommodity.Size = New System.Drawing.Size(315, 20)
        Me.txtCommodity.TabIndex = 11
        '
        'txtCustomer
        '
        Me.txtCustomer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCustomer.Location = New System.Drawing.Point(418, 46)
        Me.txtCustomer.Multiline = True
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(315, 28)
        Me.txtCustomer.TabIndex = 10
        '
        'txtApproveREF
        '
        Me.txtApproveREF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApproveREF.Location = New System.Drawing.Point(418, 128)
        Me.txtApproveREF.Name = "txtApproveREF"
        Me.txtApproveREF.Size = New System.Drawing.Size(200, 20)
        Me.txtApproveREF.TabIndex = 9
        '
        'txtApproveBy
        '
        Me.txtApproveBy.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApproveBy.Location = New System.Drawing.Point(418, 102)
        Me.txtApproveBy.Name = "txtApproveBy"
        Me.txtApproveBy.Size = New System.Drawing.Size(200, 20)
        Me.txtApproveBy.TabIndex = 8
        '
        'txtTariffREF
        '
        Me.txtTariffREF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTariffREF.Location = New System.Drawing.Point(95, 19)
        Me.txtTariffREF.Name = "txtTariffREF"
        Me.txtTariffREF.Size = New System.Drawing.Size(94, 20)
        Me.txtTariffREF.TabIndex = 5
        '
        'Label179
        '
        Me.Label179.AutoSize = True
        Me.Label179.ForeColor = System.Drawing.Color.Maroon
        Me.Label179.Location = New System.Drawing.Point(56, 46)
        Me.Label179.Name = "Label179"
        Me.Label179.Size = New System.Drawing.Size(36, 13)
        Me.Label179.TabIndex = 1
        Me.Label179.Text = "Date :"
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.InsertToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.mnuExportExcel, Me.ExitToolStripMenuItem})
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
        Me.tabFreightInfo.Controls.Add(Me.FraupdateMin)
        Me.tabFreightInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabFreightInfo.Name = "tabFreightInfo"
        Me.tabFreightInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabFreightInfo.Size = New System.Drawing.Size(889, 190)
        Me.tabFreightInfo.TabIndex = 0
        Me.tabFreightInfo.Text = "Freight Info"
        Me.tabFreightInfo.UseVisualStyleBackColor = True
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
        'cmdCancelFreight
        '
        Me.cmdCancelFreight.Location = New System.Drawing.Point(495, 144)
        Me.cmdCancelFreight.Name = "cmdCancelFreight"
        Me.cmdCancelFreight.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelFreight.TabIndex = 20
        Me.cmdCancelFreight.Text = "Cancel"
        Me.cmdCancelFreight.UseVisualStyleBackColor = True
        '
        'cmdOkFreight
        '
        Me.cmdOkFreight.Enabled = False
        Me.cmdOkFreight.Location = New System.Drawing.Point(576, 144)
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
        Me.dgdFreight.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SpecialFreightID, Me.ContainerType, Me.Rate, Me.unit, Me.ApproveF})
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
        'ctmnuFreight
        '
        Me.ctmnuFreight.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CargoctmnuAdd, Me.CargoctmnuEdit, Me.CargoctmnuDel})
        Me.ctmnuFreight.Name = "ctmnuPrice"
        Me.ctmnuFreight.Size = New System.Drawing.Size(153, 92)
        '
        'CargoctmnuAdd
        '
        Me.CargoctmnuAdd.Image = CType(resources.GetObject("CargoctmnuAdd.Image"), System.Drawing.Image)
        Me.CargoctmnuAdd.Name = "CargoctmnuAdd"
        Me.CargoctmnuAdd.Size = New System.Drawing.Size(152, 22)
        Me.CargoctmnuAdd.Text = "Add"
        '
        'CargoctmnuEdit
        '
        Me.CargoctmnuEdit.Image = CType(resources.GetObject("CargoctmnuEdit.Image"), System.Drawing.Image)
        Me.CargoctmnuEdit.Name = "CargoctmnuEdit"
        Me.CargoctmnuEdit.Size = New System.Drawing.Size(152, 22)
        Me.CargoctmnuEdit.Text = "Edit"
        '
        'CargoctmnuDel
        '
        Me.CargoctmnuDel.Image = CType(resources.GetObject("CargoctmnuDel.Image"), System.Drawing.Image)
        Me.CargoctmnuDel.Name = "CargoctmnuDel"
        Me.CargoctmnuDel.Size = New System.Drawing.Size(152, 22)
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
        Me.fraupdate.Location = New System.Drawing.Point(0, 346)
        Me.fraupdate.Name = "fraupdate"
        Me.fraupdate.Size = New System.Drawing.Size(956, 269)
        Me.fraupdate.TabIndex = 18
        Me.fraupdate.TabStop = False
        Me.fraupdate.Text = "Update"
        '
        'txtunit
        '
        Me.txtunit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtunit.Location = New System.Drawing.Point(392, 144)
        Me.txtunit.Name = "txtunit"
        Me.txtunit.Size = New System.Drawing.Size(34, 20)
        Me.txtunit.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(354, 147)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Rate :"
        '
        'SpecialFreightID
        '
        Me.SpecialFreightID.DataPropertyName = "SpecialFreightID"
        Me.SpecialFreightID.HeaderText = "SpecialFreightID"
        Me.SpecialFreightID.Name = "SpecialFreightID"
        Me.SpecialFreightID.ReadOnly = True
        Me.SpecialFreightID.Visible = False
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
        'unit
        '
        Me.unit.DataPropertyName = "unit"
        Me.unit.HeaderText = "Unit"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
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
        'frmSpecialFreightTariffMarket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(956, 615)
        Me.Controls.Add(Me.fraupdate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMarketCode)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.dgdData)
        Me.Name = "frmSpecialFreightTariffMarket"
        Me.Text = "Special Freight"
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.FraupdateMin.ResumeLayout(False)
        Me.FraupdateMin.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabFreightInfo.ResumeLayout(False)
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
    Friend WithEvents FraupdateMin As System.Windows.Forms.GroupBox
    Friend WithEvents Label293 As System.Windows.Forms.Label
    Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
    Friend WithEvents Label227 As System.Windows.Forms.Label
    Friend WithEvents Label224 As System.Windows.Forms.Label
    Friend WithEvents Label226 As System.Windows.Forms.Label
    Friend WithEvents Label225 As System.Windows.Forms.Label
    Friend WithEvents Label195 As System.Windows.Forms.Label
    Friend WithEvents Label223 As System.Windows.Forms.Label
    Friend WithEvents dtpApproveDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDateREF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label196 As System.Windows.Forms.Label
    Friend WithEvents dtpDateExp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label113 As System.Windows.Forms.Label
    Friend WithEvents Label177 As System.Windows.Forms.Label
    Friend WithEvents Label178 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCommodity As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents txtApproveREF As System.Windows.Forms.TextBox
    Friend WithEvents txtApproveBy As System.Windows.Forms.TextBox
    Friend WithEvents txtTariffREF As System.Windows.Forms.TextBox
    Friend WithEvents Label179 As System.Windows.Forms.Label
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
    Friend WithEvents cboPOD As System.Windows.Forms.ComboBox
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents fraupdate As System.Windows.Forms.GroupBox
    Friend WithEvents ctmnuFreight As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CargoctmnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargoctmnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargoctmnuDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents cboType As System.Windows.Forms.ComboBox
    Friend WithEvents FreightTariffID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarketCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApplyDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateExp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TariffREF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateREF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveREF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Customer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Commodity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtunit As System.Windows.Forms.TextBox
    Friend WithEvents SpecialFreightID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveF As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
