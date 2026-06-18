<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPriceStandard
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtMarket = New System.Windows.Forms.TextBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayMarket = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.smnuDisplayApprove = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUserId = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUpdateTime = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.txtMoney = New System.Windows.Forms.TextBox
        Me.cboCurrency = New System.Windows.Forms.ComboBox
        Me.cboContainerType = New System.Windows.Forms.ComboBox
        Me.cboItems = New System.Windows.Forms.ComboBox
        Me.cboPrepaidCollect = New System.Windows.Forms.ComboBox
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.dgdPriceStandard = New System.Windows.Forms.DataGridView
        Me.PriceStandard_Id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShippingLine = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MarketCodeTS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MarketCodeSale = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Charge_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Charge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrepaidCollect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Money = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Currency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SaleName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdPriceStandard, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 33)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 22)
        Me.cboFind.TabIndex = 46
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(595, 35)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 43
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtMarket
        '
        Me.txtMarket.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtMarket.Location = New System.Drawing.Point(171, 35)
        Me.txtMarket.Name = "txtMarket"
        Me.txtMarket.Size = New System.Drawing.Size(396, 20)
        Me.txtMarket.TabIndex = 42
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuDisplay, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(682, 24)
        Me.MenuStrip.TabIndex = 41
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
        Me.smnuAdd.Text = "&Insert"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.smnuEdit.Text = "&Edit"
        Me.smnuEdit.Visible = False
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(52, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'smnuDisplay
        '
        Me.smnuDisplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuDisplayMarket, Me.ToolStripSeparator1, Me.smnuDisplayApprove, Me.smnuDisplayUserId, Me.smnuDisplayUpdateTime})
        Me.smnuDisplay.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDisplay.Name = "smnuDisplay"
        Me.smnuDisplay.Size = New System.Drawing.Size(44, 20)
        Me.smnuDisplay.Text = "&View"
        '
        'smnuDisplayMarket
        '
        Me.smnuDisplayMarket.Name = "smnuDisplayMarket"
        Me.smnuDisplayMarket.Size = New System.Drawing.Size(139, 22)
        Me.smnuDisplayMarket.Text = "Items"
        Me.smnuDisplayMarket.ToolTipText = "Chi Trả Tại"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(136, 6)
        '
        'smnuDisplayApprove
        '
        Me.smnuDisplayApprove.Name = "smnuDisplayApprove"
        Me.smnuDisplayApprove.Size = New System.Drawing.Size(139, 22)
        Me.smnuDisplayApprove.Text = "&Approve"
        '
        'smnuDisplayUserId
        '
        Me.smnuDisplayUserId.Name = "smnuDisplayUserId"
        Me.smnuDisplayUserId.Size = New System.Drawing.Size(139, 22)
        Me.smnuDisplayUserId.Text = "Us&er Update"
        '
        'smnuDisplayUpdateTime
        '
        Me.smnuDisplayUpdateTime.Name = "smnuDisplayUpdateTime"
        Me.smnuDisplayUpdateTime.Size = New System.Drawing.Size(139, 22)
        Me.smnuDisplayUpdateTime.Text = "Date &Update"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(81, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.cboPOL)
        Me.fraUpdate.Controls.Add(Me.txtMoney)
        Me.fraUpdate.Controls.Add(Me.cboCurrency)
        Me.fraUpdate.Controls.Add(Me.cboContainerType)
        Me.fraUpdate.Controls.Add(Me.cboItems)
        Me.fraUpdate.Controls.Add(Me.cboPrepaidCollect)
        Me.fraUpdate.Controls.Add(Me.cboPort)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.Label7)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUpdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.fraUpdate.Location = New System.Drawing.Point(12, 243)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(635, 143)
        Me.fraUpdate.TabIndex = 45
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(26, 36)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(136, 23)
        Me.cboPOL.TabIndex = 17
        '
        'txtMoney
        '
        Me.txtMoney.Location = New System.Drawing.Point(335, 87)
        Me.txtMoney.Name = "txtMoney"
        Me.txtMoney.Size = New System.Drawing.Size(121, 21)
        Me.txtMoney.TabIndex = 16
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Items.AddRange(New Object() {"USD", "EUR", "VND"})
        Me.cboCurrency.Location = New System.Drawing.Point(478, 85)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(121, 23)
        Me.cboCurrency.TabIndex = 15
        '
        'cboContainerType
        '
        Me.cboContainerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContainerType.FormattingEnabled = True
        Me.cboContainerType.Items.AddRange(New Object() {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH"})
        Me.cboContainerType.Location = New System.Drawing.Point(478, 36)
        Me.cboContainerType.Name = "cboContainerType"
        Me.cboContainerType.Size = New System.Drawing.Size(121, 23)
        Me.cboContainerType.TabIndex = 15
        '
        'cboItems
        '
        Me.cboItems.FormattingEnabled = True
        Me.cboItems.Location = New System.Drawing.Point(335, 36)
        Me.cboItems.Name = "cboItems"
        Me.cboItems.Size = New System.Drawing.Size(121, 23)
        Me.cboItems.TabIndex = 15
        '
        'cboPrepaidCollect
        '
        Me.cboPrepaidCollect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrepaidCollect.FormattingEnabled = True
        Me.cboPrepaidCollect.Items.AddRange(New Object() {"Prepaid", "Collect"})
        Me.cboPrepaidCollect.Location = New System.Drawing.Point(193, 85)
        Me.cboPrepaidCollect.Name = "cboPrepaidCollect"
        Me.cboPrepaidCollect.Size = New System.Drawing.Size(121, 23)
        Me.cboPrepaidCollect.TabIndex = 15
        '
        'cboPort
        '
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(193, 37)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(121, 23)
        Me.cboPort.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(332, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Money :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(475, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Currency :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(190, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "PrePaid Or Collect :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(475, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Container Type :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Items :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "POL :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(190, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "POD :"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(439, 114)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(522, 114)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'dgdPriceStandard
        '
        Me.dgdPriceStandard.AllowUserToAddRows = False
        Me.dgdPriceStandard.AllowUserToDeleteRows = False
        Me.dgdPriceStandard.AllowUserToResizeRows = False
        Me.dgdPriceStandard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdPriceStandard.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPriceStandard.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdPriceStandard.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPriceStandard.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PriceStandard_Id, Me.ShippingLine, Me.POL, Me.POL_ID, Me.Port_ID, Me.Port, Me.MarketCodeTS, Me.MarketCodeSale, Me.CTN_TYPE, Me.Charge_ID, Me.Charge, Me.PrepaidCollect, Me.Money, Me.Currency, Me.SaleName, Me.Continued, Me.Editable, Me.Approve, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdPriceStandard.DefaultCellStyle = DataGridViewCellStyle12
        Me.dgdPriceStandard.Location = New System.Drawing.Point(12, 63)
        Me.dgdPriceStandard.Name = "dgdPriceStandard"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdPriceStandard.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgdPriceStandard.Size = New System.Drawing.Size(658, 330)
        Me.dgdPriceStandard.TabIndex = 44
        '
        'PriceStandard_Id
        '
        Me.PriceStandard_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.PriceStandard_Id.DataPropertyName = "PriceStandard_Id"
        Me.PriceStandard_Id.HeaderText = "PriceStandard_Id"
        Me.PriceStandard_Id.Name = "PriceStandard_Id"
        Me.PriceStandard_Id.Visible = False
        Me.PriceStandard_Id.Width = 130
        '
        'ShippingLine
        '
        Me.ShippingLine.DataPropertyName = "shippingline"
        Me.ShippingLine.HeaderText = "Shiping Lines"
        Me.ShippingLine.Name = "ShippingLine"
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL_Code"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        '
        'POL_ID
        '
        Me.POL_ID.DataPropertyName = "POL_ID"
        Me.POL_ID.HeaderText = "POL_ID"
        Me.POL_ID.Name = "POL_ID"
        Me.POL_ID.Visible = False
        '
        'Port_ID
        '
        Me.Port_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Port_ID.DataPropertyName = "Port_ID"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.Port_ID.DefaultCellStyle = DataGridViewCellStyle2
        Me.Port_ID.HeaderText = "Port_ID"
        Me.Port_ID.Name = "Port_ID"
        Me.Port_ID.Visible = False
        Me.Port_ID.Width = 75
        '
        'Port
        '
        Me.Port.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Port.DataPropertyName = "Port_Code"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.Port.DefaultCellStyle = DataGridViewCellStyle3
        Me.Port.HeaderText = "POD"
        Me.Port.Name = "Port"
        Me.Port.ToolTipText = "Tên cảng"
        Me.Port.Width = 58
        '
        'MarketCodeTS
        '
        Me.MarketCodeTS.DataPropertyName = "MarketCodeTS"
        Me.MarketCodeTS.HeaderText = "Market Code TS"
        Me.MarketCodeTS.Name = "MarketCodeTS"
        '
        'MarketCodeSale
        '
        Me.MarketCodeSale.DataPropertyName = "MarketCodeSale"
        Me.MarketCodeSale.HeaderText = "Market Code Sale"
        Me.MarketCodeSale.Name = "MarketCodeSale"
        '
        'CTN_TYPE
        '
        Me.CTN_TYPE.DataPropertyName = "CTN_TYPE"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.CTN_TYPE.DefaultCellStyle = DataGridViewCellStyle4
        Me.CTN_TYPE.HeaderText = "Container Type"
        Me.CTN_TYPE.Name = "CTN_TYPE"
        Me.CTN_TYPE.ReadOnly = True
        '
        'Charge_ID
        '
        Me.Charge_ID.DataPropertyName = "Charge_ID"
        Me.Charge_ID.HeaderText = "Charge_ID"
        Me.Charge_ID.Name = "Charge_ID"
        Me.Charge_ID.Visible = False
        '
        'Charge
        '
        Me.Charge.DataPropertyName = "Charge_Code"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.Charge.DefaultCellStyle = DataGridViewCellStyle5
        Me.Charge.HeaderText = "Items"
        Me.Charge.Name = "Charge"
        '
        'PrepaidCollect
        '
        Me.PrepaidCollect.DataPropertyName = "Prepaid_Collect"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        Me.PrepaidCollect.DefaultCellStyle = DataGridViewCellStyle6
        Me.PrepaidCollect.HeaderText = "Prepaid Or Collect"
        Me.PrepaidCollect.Name = "PrepaidCollect"
        Me.PrepaidCollect.ReadOnly = True
        '
        'Money
        '
        Me.Money.DataPropertyName = "Price"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Format = "N2"
        Me.Money.DefaultCellStyle = DataGridViewCellStyle7
        Me.Money.HeaderText = "Money"
        Me.Money.Name = "Money"
        Me.Money.ReadOnly = True
        '
        'Currency
        '
        Me.Currency.DataPropertyName = "Currency"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        Me.Currency.DefaultCellStyle = DataGridViewCellStyle8
        Me.Currency.HeaderText = "Currency"
        Me.Currency.Name = "Currency"
        Me.Currency.ReadOnly = True
        '
        'SaleName
        '
        Me.SaleName.DataPropertyName = "SaleName"
        Me.SaleName.HeaderText = "Sale name"
        Me.SaleName.Name = "SaleName"
        '
        'Continued
        '
        Me.Continued.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
        Me.Continued.Width = 89
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Editable.Visible = False
        Me.Editable.Width = 59
        '
        'Approve
        '
        Me.Approve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Approve.DataPropertyName = "Approve"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle9
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.ToolTipText = "Duyệt"
        Me.Approve.Visible = False
        Me.Approve.Width = 79
        '
        'UserId
        '
        Me.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle10
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.ToolTipText = "Ngừuơi Cập Nhật"
        Me.UserId.Visible = False
        Me.UserId.Width = 95
        '
        'UpdateTime
        '
        Me.UpdateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle11
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ToolTipText = "Ngày Cập Nhật"
        Me.UpdateTime.Visible = False
        Me.UpdateTime.Width = 5
        '
        'frmPriceStandard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 397)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtMarket)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.dgdPriceStandard)
        Me.Controls.Add(Me.fraUpdate)
        Me.Name = "frmPriceStandard"
        Me.Text = "Surcharge"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdPriceStandard, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtMarket As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayMarket As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents smnuDisplayApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUserId As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUpdateTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents txtMoney As System.Windows.Forms.TextBox
    Friend WithEvents cboCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents cboContainerType As System.Windows.Forms.ComboBox
    Friend WithEvents cboItems As System.Windows.Forms.ComboBox
    Friend WithEvents cboPrepaidCollect As System.Windows.Forms.ComboBox
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents dgdPriceStandard As System.Windows.Forms.DataGridView
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PriceStandard_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShippingLine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarketCodeTS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarketCodeSale As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Charge_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Charge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrepaidCollect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Money As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SaleName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
