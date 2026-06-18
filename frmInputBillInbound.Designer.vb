<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBillInbound
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputBillInbound))
        Me.palBillHouse = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dgdBillNumber = New System.Windows.Forms.DataGridView()
        Me.BLIB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gFLC_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gSC_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nvocc = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.FCL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.LCL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Consol = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.hbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.txtNumberBillHouse = New System.Windows.Forms.TextBox()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.ctxGetBLNo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GetBLNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkfcl = New System.Windows.Forms.RadioButton()
        Me.chklcl = New System.Windows.Forms.RadioButton()
        Me.chkconsol = New System.Windows.Forms.RadioButton()
        Me.chkair = New System.Windows.Forms.RadioButton()
        Me.cbobranch = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboQuotation = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbotat = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboSale = New System.Windows.Forms.ComboBox()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.chksoccoc = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CBOTO = New System.Windows.Forms.ComboBox()
        Me.CBOFROM = New System.Windows.Forms.ComboBox()
        Me.CBOCODE = New System.Windows.Forms.ComboBox()
        Me.txtfindpod = New System.Windows.Forms.TextBox()
        Me.txtfindpol = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtlot = New System.Windows.Forms.TextBox()
        Me.txtetd = New System.Windows.Forms.MaskedTextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpETD = New System.Windows.Forms.DateTimePicker()
        Me.txteta = New System.Windows.Forms.MaskedTextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dtpETA = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboSC = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboFLC = New System.Windows.Forms.ComboBox()
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxGetBLNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'palBillHouse
        '
        Me.palBillHouse.AutoScroll = True
        Me.palBillHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.palBillHouse.Location = New System.Drawing.Point(90, 323)
        Me.palBillHouse.Name = "palBillHouse"
        Me.palBillHouse.Size = New System.Drawing.Size(304, 76)
        Me.palBillHouse.TabIndex = 18
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(786, 51)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "&Doc."
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(116, 429)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Bills"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal.Location = New System.Drawing.Point(60, 429)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblTotal.TabIndex = 328
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(17, 429)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 327
        Me.Label2.Text = "Total :"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(319, 405)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(238, 405)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 19
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label4.Location = New System.Drawing.Point(8, 328)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "House Bill :"
        '
        'dgdBillNumber
        '
        Me.dgdBillNumber.AllowUserToAddRows = False
        Me.dgdBillNumber.AllowUserToDeleteRows = False
        Me.dgdBillNumber.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        Me.dgdBillNumber.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdBillNumber.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdBillNumber.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBillNumber.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdBillNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBillNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLIB_ID, Me.lot, Me.RefNo, Me.mbl, Me.gFLC_, Me.gSC_, Me.nvocc, Me.FCL, Me.LCL, Me.Consol, Me.hbl, Me.UserUpdate, Me.DateUpdate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdBillNumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgdBillNumber.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgdBillNumber.Location = New System.Drawing.Point(410, 12)
        Me.dgdBillNumber.Name = "dgdBillNumber"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgdBillNumber.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdBillNumber.Size = New System.Drawing.Size(616, 460)
        Me.dgdBillNumber.TabIndex = 337
        '
        'BLIB_ID
        '
        Me.BLIB_ID.DataPropertyName = "BLIB_ID"
        Me.BLIB_ID.HeaderText = "BLIB_ID"
        Me.BLIB_ID.Name = "BLIB_ID"
        Me.BLIB_ID.Visible = False
        '
        'lot
        '
        Me.lot.DataPropertyName = "lot"
        Me.lot.HeaderText = "Lot."
        Me.lot.Name = "lot"
        Me.lot.Width = 72
        '
        'RefNo
        '
        Me.RefNo.DataPropertyName = "ref"
        Me.RefNo.HeaderText = "Ref No."
        Me.RefNo.Name = "RefNo"
        Me.RefNo.Width = 71
        '
        'mbl
        '
        Me.mbl.DataPropertyName = "mbl"
        Me.mbl.HeaderText = "MBL"
        Me.mbl.Name = "mbl"
        Me.mbl.Width = 72
        '
        'gFLC_
        '
        Me.gFLC_.DataPropertyName = "gflc"
        Me.gFLC_.HeaderText = "F/L/C"
        Me.gFLC_.Name = "gFLC_"
        Me.gFLC_.Width = 72
        '
        'gSC_
        '
        Me.gSC_.DataPropertyName = "gsc"
        Me.gSC_.HeaderText = "SOC/COC"
        Me.gSC_.Name = "gSC_"
        Me.gSC_.Width = 71
        '
        'nvocc
        '
        Me.nvocc.DataPropertyName = "nvocc"
        Me.nvocc.HeaderText = "SOC/COC"
        Me.nvocc.Name = "nvocc"
        Me.nvocc.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nvocc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.nvocc.Visible = False
        '
        'FCL
        '
        Me.FCL.DataPropertyName = "FCL"
        Me.FCL.HeaderText = "FCL"
        Me.FCL.Name = "FCL"
        Me.FCL.Visible = False
        '
        'LCL
        '
        Me.LCL.DataPropertyName = "LCL"
        Me.LCL.HeaderText = "LCL"
        Me.LCL.Name = "LCL"
        Me.LCL.Visible = False
        '
        'Consol
        '
        Me.Consol.DataPropertyName = "Consol"
        Me.Consol.HeaderText = "Consol"
        Me.Consol.Name = "Consol"
        Me.Consol.Visible = False
        '
        'hbl
        '
        Me.hbl.DataPropertyName = "hbl"
        Me.hbl.HeaderText = "HBL"
        Me.hbl.Name = "hbl"
        Me.hbl.Width = 72
        '
        'UserUpdate
        '
        Me.UserUpdate.DataPropertyName = "UserUpdate"
        Me.UserUpdate.HeaderText = "User Update"
        Me.UserUpdate.Name = "UserUpdate"
        Me.UserUpdate.Width = 71
        '
        'DateUpdate
        '
        Me.DateUpdate.DataPropertyName = "DateUpdate"
        Me.DateUpdate.HeaderText = "Date Update"
        Me.DateUpdate.Name = "DateUpdate"
        Me.DateUpdate.Width = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(8, 264)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 322
        Me.Label1.Text = "MBL (Carrier) :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label5.Location = New System.Drawing.Point(8, 298)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 321
        Me.Label5.Text = "Quantity of HBL :"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNumber.Location = New System.Drawing.Point(88, 257)
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(306, 24)
        Me.txtBillNumber.TabIndex = 12
        '
        'txtNumberBillHouse
        '
        Me.txtNumberBillHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberBillHouse.Location = New System.Drawing.Point(129, 291)
        Me.txtNumberBillHouse.Name = "txtNumberBillHouse"
        Me.txtNumberBillHouse.Size = New System.Drawing.Size(198, 24)
        Me.txtNumberBillHouse.TabIndex = 13
        Me.txtNumberBillHouse.Text = "1"
        '
        'cmdReset
        '
        Me.cmdReset.ForeColor = System.Drawing.Color.Maroon
        Me.cmdReset.Location = New System.Drawing.Point(333, 292)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(61, 23)
        Me.cmdReset.TabIndex = 14
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'ctxGetBLNo
        '
        Me.ctxGetBLNo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetBLNoToolStripMenuItem})
        Me.ctxGetBLNo.Name = "ctxGetBLNo"
        Me.ctxGetBLNo.Size = New System.Drawing.Size(133, 26)
        '
        'GetBLNoToolStripMenuItem
        '
        Me.GetBLNoToolStripMenuItem.Name = "GetBLNoToolStripMenuItem"
        Me.GetBLNoToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.GetBLNoToolStripMenuItem.Text = "Get B/L No"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(155, 93)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(239, 20)
        Me.txtRef.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label6.Location = New System.Drawing.Point(8, 101)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 339
        Me.Label6.Text = "Ref No. :"
        '
        'chkfcl
        '
        Me.chkfcl.AutoSize = True
        Me.chkfcl.Checked = True
        Me.chkfcl.Location = New System.Drawing.Point(800, 84)
        Me.chkfcl.Name = "chkfcl"
        Me.chkfcl.Size = New System.Drawing.Size(44, 17)
        Me.chkfcl.TabIndex = 4
        Me.chkfcl.TabStop = True
        Me.chkfcl.Text = "FCL"
        Me.chkfcl.UseVisualStyleBackColor = True
        Me.chkfcl.Visible = False
        '
        'chklcl
        '
        Me.chklcl.AutoSize = True
        Me.chklcl.Location = New System.Drawing.Point(800, 84)
        Me.chklcl.Name = "chklcl"
        Me.chklcl.Size = New System.Drawing.Size(44, 17)
        Me.chklcl.TabIndex = 5
        Me.chklcl.Text = "LCL"
        Me.chklcl.UseVisualStyleBackColor = True
        Me.chklcl.Visible = False
        '
        'chkconsol
        '
        Me.chkconsol.AutoSize = True
        Me.chkconsol.Location = New System.Drawing.Point(794, 84)
        Me.chkconsol.Name = "chkconsol"
        Me.chkconsol.Size = New System.Drawing.Size(57, 17)
        Me.chkconsol.TabIndex = 6
        Me.chkconsol.Text = "Consol"
        Me.chkconsol.UseVisualStyleBackColor = True
        Me.chkconsol.Visible = False
        '
        'chkair
        '
        Me.chkair.AutoSize = True
        Me.chkair.Location = New System.Drawing.Point(804, 84)
        Me.chkair.Name = "chkair"
        Me.chkair.Size = New System.Drawing.Size(37, 17)
        Me.chkair.TabIndex = 7
        Me.chkair.Text = "Air"
        Me.chkair.UseVisualStyleBackColor = True
        Me.chkair.Visible = False
        '
        'cbobranch
        '
        Me.cbobranch.FormattingEnabled = True
        Me.cbobranch.Items.AddRange(New Object() {"SGN", "HPH", "HAN", "DAD"})
        Me.cbobranch.Location = New System.Drawing.Point(794, 82)
        Me.cbobranch.Name = "cbobranch"
        Me.cbobranch.Size = New System.Drawing.Size(66, 21)
        Me.cbobranch.TabIndex = 0
        Me.cbobranch.Text = "SGN"
        Me.cbobranch.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(799, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Branch :"
        Me.Label7.Visible = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(88, 91)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Get Ref."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboQuotation
        '
        Me.cboQuotation.FormattingEnabled = True
        Me.cboQuotation.Location = New System.Drawing.Point(88, 231)
        Me.cboQuotation.Name = "cboQuotation"
        Me.cboQuotation.Size = New System.Drawing.Size(118, 21)
        Me.cboQuotation.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(8, 235)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 348
        Me.Label8.Text = "Quotation No. :"
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(814, 81)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(25, 23)
        Me.Button2.TabIndex = 349
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbotat
        '
        Me.cbotat.FormattingEnabled = True
        Me.cbotat.Items.AddRange(New Object() {"S", "N"})
        Me.cbotat.Location = New System.Drawing.Point(794, 82)
        Me.cbotat.Name = "cbotat"
        Me.cbotat.Size = New System.Drawing.Size(66, 21)
        Me.cbotat.TabIndex = 1
        Me.cbotat.Text = "S"
        Me.cbotat.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(231, 235)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 418
        Me.Label16.Text = "Sale :"
        '
        'cboSale
        '
        Me.cboSale.DropDownWidth = 400
        Me.cboSale.FormattingEnabled = True
        Me.cboSale.Location = New System.Drawing.Point(268, 231)
        Me.cboSale.Name = "cboSale"
        Me.cboSale.Size = New System.Drawing.Size(126, 21)
        Me.cboSale.TabIndex = 10
        '
        'cboAgent
        '
        Me.cboAgent.DropDownWidth = 400
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(88, 202)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(306, 24)
        Me.cboAgent.TabIndex = 16
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label73.Location = New System.Drawing.Point(8, 209)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(41, 13)
        Me.Label73.TabIndex = 420
        Me.Label73.Text = "Agent :"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chksoccoc
        '
        Me.chksoccoc.AutoSize = True
        Me.chksoccoc.Location = New System.Drawing.Point(806, 84)
        Me.chksoccoc.Name = "chksoccoc"
        Me.chksoccoc.Size = New System.Drawing.Size(75, 17)
        Me.chksoccoc.TabIndex = 3
        Me.chksoccoc.Text = "SOC/COC"
        Me.chksoccoc.UseVisualStyleBackColor = True
        Me.chksoccoc.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "BLIB_ID"
        Me.DataGridViewTextBoxColumn1.HeaderText = "BLIB_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ref"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Ref No."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mbl"
        Me.DataGridViewTextBoxColumn3.HeaderText = "MBL"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "hbl"
        Me.DataGridViewTextBoxColumn4.HeaderText = "HBL"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "UserUpdate"
        Me.DataGridViewTextBoxColumn5.HeaderText = "User Update"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DateUpdate"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Date Update"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "DateUpdate"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Date Update"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'CBOTO
        '
        Me.CBOTO.FormattingEnabled = True
        Me.CBOTO.Items.AddRange(New Object() {"CE", "LE", "FE", "AE", "EE", "CI", "LI", "FI", "AI", "EI", "CC", "T"})
        Me.CBOTO.Location = New System.Drawing.Point(269, 66)
        Me.CBOTO.Name = "CBOTO"
        Me.CBOTO.Size = New System.Drawing.Size(125, 21)
        Me.CBOTO.TabIndex = 2417
        '
        'CBOFROM
        '
        Me.CBOFROM.FormattingEnabled = True
        Me.CBOFROM.Items.AddRange(New Object() {"CE", "LE", "FE", "AE", "EE", "CI", "LI", "FI", "AI", "EI", "CC", "T"})
        Me.CBOFROM.Location = New System.Drawing.Point(145, 66)
        Me.CBOFROM.Name = "CBOFROM"
        Me.CBOFROM.Size = New System.Drawing.Size(118, 21)
        Me.CBOFROM.TabIndex = 2416
        '
        'CBOCODE
        '
        Me.CBOCODE.FormattingEnabled = True
        Me.CBOCODE.Location = New System.Drawing.Point(88, 66)
        Me.CBOCODE.Name = "CBOCODE"
        Me.CBOCODE.Size = New System.Drawing.Size(53, 21)
        Me.CBOCODE.TabIndex = 2415
        '
        'txtfindpod
        '
        Me.txtfindpod.Location = New System.Drawing.Point(269, 40)
        Me.txtfindpod.Name = "txtfindpod"
        Me.txtfindpod.Size = New System.Drawing.Size(125, 20)
        Me.txtfindpod.TabIndex = 2425
        '
        'txtfindpol
        '
        Me.txtfindpol.Location = New System.Drawing.Point(145, 40)
        Me.txtfindpol.Name = "txtfindpol"
        Me.txtfindpol.Size = New System.Drawing.Size(118, 20)
        Me.txtfindpol.TabIndex = 2424
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label9.Location = New System.Drawing.Point(8, 124)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 2427
        Me.Label9.Text = "LOT No. :"
        '
        'txtlot
        '
        Me.txtlot.Location = New System.Drawing.Point(89, 120)
        Me.txtlot.Name = "txtlot"
        Me.txtlot.Size = New System.Drawing.Size(306, 20)
        Me.txtlot.TabIndex = 2426
        '
        'txtetd
        '
        Me.txtetd.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtetd.Location = New System.Drawing.Point(220, 147)
        Me.txtetd.Name = "txtetd"
        Me.txtetd.Size = New System.Drawing.Size(174, 20)
        Me.txtetd.TabIndex = 2429
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(200, 144)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(14, 23)
        Me.Button6.TabIndex = 2430
        Me.Button6.Text = ">"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label10.Location = New System.Drawing.Point(8, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 2428
        Me.Label10.Text = "ETD :"
        '
        'dtpETD
        '
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(89, 147)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(105, 20)
        Me.dtpETD.TabIndex = 2431
        '
        'txteta
        '
        Me.txteta.BackColor = System.Drawing.Color.LemonChiffon
        Me.txteta.Location = New System.Drawing.Point(220, 176)
        Me.txteta.Name = "txteta"
        Me.txteta.Size = New System.Drawing.Size(174, 20)
        Me.txteta.TabIndex = 2433
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(200, 174)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(14, 23)
        Me.Button7.TabIndex = 2434
        Me.Button7.Text = ">"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label11.Location = New System.Drawing.Point(8, 179)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 2432
        Me.Label11.Text = "ETA :"
        '
        'dtpETA
        '
        Me.dtpETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETA.Location = New System.Drawing.Point(88, 174)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(106, 20)
        Me.dtpETA.TabIndex = 2435
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(110, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(32, 13)
        Me.Label12.TabIndex = 2439
        Me.Label12.Text = "S/C :"
        '
        'cboSC
        '
        Me.cboSC.FormattingEnabled = True
        Me.cboSC.Items.AddRange(New Object() {"S", "C"})
        Me.cboSC.Location = New System.Drawing.Point(145, 4)
        Me.cboSC.Name = "cboSC"
        Me.cboSC.Size = New System.Drawing.Size(40, 21)
        Me.cboSC.TabIndex = 2438
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 7)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(42, 13)
        Me.Label13.TabIndex = 2437
        Me.Label13.Text = "F/L/C :"
        '
        'cboFLC
        '
        Me.cboFLC.FormattingEnabled = True
        Me.cboFLC.Items.AddRange(New Object() {"F", "L", "C"})
        Me.cboFLC.Location = New System.Drawing.Point(61, 3)
        Me.cboFLC.Name = "cboFLC"
        Me.cboFLC.Size = New System.Drawing.Size(40, 21)
        Me.cboFLC.TabIndex = 2436
        '
        'frmInputBillInbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 484)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cboSC)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboFLC)
        Me.Controls.Add(Me.txteta)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dtpETA)
        Me.Controls.Add(Me.txtetd)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtpETD)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtlot)
        Me.Controls.Add(Me.txtfindpod)
        Me.Controls.Add(Me.txtfindpol)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CBOTO)
        Me.Controls.Add(Me.CBOFROM)
        Me.Controls.Add(Me.CBOCODE)
        Me.Controls.Add(Me.chksoccoc)
        Me.Controls.Add(Me.cboAgent)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.cbotat)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cboSale)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboQuotation)
        Me.Controls.Add(Me.chkair)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbobranch)
        Me.Controls.Add(Me.chkconsol)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.chklcl)
        Me.Controls.Add(Me.chkfcl)
        Me.Controls.Add(Me.dgdBillNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.palBillHouse)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumberBillHouse)
        Me.Controls.Add(Me.txtBillNumber)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInputBillInbound"
        Me.Text = "Input Bill Inbound"
        CType(Me.dgdBillNumber,System.ComponentModel.ISupportInitialize).EndInit
        Me.ctxGetBLNo.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents palBillHouse As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dgdBillNumber As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtNumberBillHouse As System.Windows.Forms.TextBox
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents ctxGetBLNo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GetBLNoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkfcl As System.Windows.Forms.RadioButton
    Friend WithEvents chklcl As System.Windows.Forms.RadioButton
    Friend WithEvents chkconsol As System.Windows.Forms.RadioButton
    Friend WithEvents chkair As System.Windows.Forms.RadioButton
    Friend WithEvents cbobranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cboQuotation As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbotat As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboSale As System.Windows.Forms.ComboBox
    Friend WithEvents cboAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chksoccoc As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CBOTO As System.Windows.Forms.ComboBox
    Friend WithEvents CBOFROM As System.Windows.Forms.ComboBox
    Friend WithEvents CBOCODE As System.Windows.Forms.ComboBox
    Friend WithEvents txtfindpod As System.Windows.Forms.TextBox
    Friend WithEvents txtfindpol As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtlot As System.Windows.Forms.TextBox
    Friend WithEvents txtetd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents txteta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents BLIB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gFLC_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gSC_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nvocc As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents FCL As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents LCL As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Consol As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents hbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboSC As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboFLC As System.Windows.Forms.ComboBox
End Class
