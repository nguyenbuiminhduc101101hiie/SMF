<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputOutbound_OverseaAirExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputOutbound_OverseaAirExport))
        Me.ctxGetBLNo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GetBLNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cbopolcode = New System.Windows.Forms.ComboBox()
        Me.cbopodcode = New System.Windows.Forms.ComboBox()
        Me.chkfcl = New System.Windows.Forms.RadioButton()
        Me.cboBKNo = New System.Windows.Forms.ComboBox()
        Me.dgdBillNumber = New System.Windows.Forms.DataGridView()
        Me.BLOB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Order = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mblcarrier = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MBLMAWB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HBLHAWB = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BKNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.palBillHouse = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.txtNumberBillHouse = New System.Windows.Forms.TextBox()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboSale = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbotat = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboRef = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkair = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbobranch = New System.Windows.Forms.ComboBox()
        Me.chkconsol = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chklcl = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cboQuotation = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtlot = New System.Windows.Forms.TextBox()
        Me.txtetd = New System.Windows.Forms.MaskedTextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dtpETD = New System.Windows.Forms.DateTimePicker()
        Me.txteta = New System.Windows.Forms.MaskedTextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.dtpETA = New System.Windows.Forms.DateTimePicker()
        Me.ctxGetBLNo.SuspendLayout()
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(226, 410)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(69, 23)
        Me.Button3.TabIndex = 501
        Me.Button3.Text = "&Doc."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cbopolcode
        '
        Me.cbopolcode.DropDownWidth = 150
        Me.cbopolcode.FormattingEnabled = True
        Me.cbopolcode.Location = New System.Drawing.Point(17, 24)
        Me.cbopolcode.Name = "cbopolcode"
        Me.cbopolcode.Size = New System.Drawing.Size(95, 21)
        Me.cbopolcode.TabIndex = 500
        '
        'cbopodcode
        '
        Me.cbopodcode.DropDownWidth = 150
        Me.cbopodcode.FormattingEnabled = True
        Me.cbopodcode.Location = New System.Drawing.Point(117, 24)
        Me.cbopodcode.Name = "cbopodcode"
        Me.cbopodcode.Size = New System.Drawing.Size(87, 21)
        Me.cbopodcode.TabIndex = 499
        '
        'chkfcl
        '
        Me.chkfcl.AutoSize = True
        Me.chkfcl.Location = New System.Drawing.Point(651, 91)
        Me.chkfcl.Name = "chkfcl"
        Me.chkfcl.Size = New System.Drawing.Size(14, 13)
        Me.chkfcl.TabIndex = 482
        Me.chkfcl.TabStop = True
        Me.chkfcl.UseVisualStyleBackColor = True
        Me.chkfcl.Visible = False
        '
        'cboBKNo
        '
        Me.cboBKNo.FormattingEnabled = True
        Me.cboBKNo.Location = New System.Drawing.Point(95, 88)
        Me.cboBKNo.Name = "cboBKNo"
        Me.cboBKNo.Size = New System.Drawing.Size(133, 21)
        Me.cboBKNo.TabIndex = 480
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gold
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBillNumber.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdBillNumber.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBillNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLOB_ID, Me.Order, Me.mblcarrier, Me.MBLMAWB, Me.HBLHAWB, Me.BKNo, Me.UserUpdate, Me.DateUpdate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdBillNumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgdBillNumber.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgdBillNumber.Location = New System.Drawing.Point(301, 18)
        Me.dgdBillNumber.Name = "dgdBillNumber"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgdBillNumber.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdBillNumber.Size = New System.Drawing.Size(713, 488)
        Me.dgdBillNumber.TabIndex = 478
        '
        'BLOB_ID
        '
        Me.BLOB_ID.DataPropertyName = "BLOB_iD"
        Me.BLOB_ID.HeaderText = "BLOB_ID"
        Me.BLOB_ID.Name = "BLOB_ID"
        Me.BLOB_ID.Visible = False
        '
        'Order
        '
        Me.Order.DataPropertyName = "order"
        Me.Order.HeaderText = "Order"
        Me.Order.Name = "Order"
        '
        'mblcarrier
        '
        Me.mblcarrier.DataPropertyName = "mblcarrier"
        Me.mblcarrier.HeaderText = "Mawb"
        Me.mblcarrier.Name = "mblcarrier"
        '
        'MBLMAWB
        '
        Me.MBLMAWB.DataPropertyName = "MBLMAWB"
        Me.MBLMAWB.HeaderText = "Hawb"
        Me.MBLMAWB.Name = "MBLMAWB"
        '
        'HBLHAWB
        '
        Me.HBLHAWB.DataPropertyName = "hblhawb"
        Me.HBLHAWB.HeaderText = "HAWB"
        Me.HBLHAWB.Name = "HBLHAWB"
        Me.HBLHAWB.Visible = False
        '
        'BKNo
        '
        Me.BKNo.DataPropertyName = "bkno"
        Me.BKNo.HeaderText = "BKNo"
        Me.BKNo.Name = "BKNo"
        '
        'UserUpdate
        '
        Me.UserUpdate.DataPropertyName = "UserUpdate"
        Me.UserUpdate.HeaderText = "User Update"
        Me.UserUpdate.Name = "UserUpdate"
        '
        'DateUpdate
        '
        Me.DateUpdate.DataPropertyName = "DateUpdate"
        Me.DateUpdate.HeaderText = "Date Update"
        Me.DateUpdate.Name = "DateUpdate"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(1, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 479
        Me.Label6.Text = "Ref No. :"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(95, 117)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(200, 20)
        Me.txtRef.TabIndex = 465
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(1, 364)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 477
        Me.Label4.Text = "Hawb :"
        '
        'palBillHouse
        '
        Me.palBillHouse.AutoScroll = True
        Me.palBillHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.palBillHouse.Location = New System.Drawing.Point(94, 364)
        Me.palBillHouse.Name = "palBillHouse"
        Me.palBillHouse.Size = New System.Drawing.Size(201, 40)
        Me.palBillHouse.TabIndex = 476
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(140, 493)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 475
        Me.Label3.Text = "Bills"
        '
        'cmdReset
        '
        Me.cmdReset.ForeColor = System.Drawing.Color.Maroon
        Me.cmdReset.Location = New System.Drawing.Point(234, 308)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(61, 23)
        Me.cmdReset.TabIndex = 468
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal.Location = New System.Drawing.Point(84, 493)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblTotal.TabIndex = 474
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(41, 493)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 473
        Me.Label2.Text = "Total :"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(162, 410)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(58, 23)
        Me.cmdCancel.TabIndex = 470
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtNumberBillHouse
        '
        Me.txtNumberBillHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberBillHouse.Location = New System.Drawing.Point(95, 307)
        Me.txtNumberBillHouse.Name = "txtNumberBillHouse"
        Me.txtNumberBillHouse.Size = New System.Drawing.Size(125, 24)
        Me.txtNumberBillHouse.TabIndex = 467
        Me.txtNumberBillHouse.Text = "1"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNumber.Location = New System.Drawing.Point(95, 278)
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(200, 24)
        Me.txtBillNumber.TabIndex = 466
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(94, 410)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(62, 23)
        Me.cmdOK.TabIndex = 469
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(1, 281)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 472
        Me.Label1.Text = "Mawb :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(1, 307)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 13)
        Me.Label5.TabIndex = 471
        Me.Label5.Text = "Number Hawb :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(14, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 497
        Me.Label10.Text = "POL/ORG :"
        '
        'cboAgent
        '
        Me.cboAgent.DropDownWidth = 400
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(94, 334)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(201, 24)
        Me.cboAgent.TabIndex = 495
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.ForeColor = System.Drawing.Color.Maroon
        Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label73.Location = New System.Drawing.Point(1, 343)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(41, 13)
        Me.Label73.TabIndex = 496
        Me.Label73.Text = "Agent :"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(466, 125)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 494
        Me.Label16.Text = "Sale :"
        Me.Label16.Visible = False
        '
        'cboSale
        '
        Me.cboSale.DropDownWidth = 400
        Me.cboSale.FormattingEnabled = True
        Me.cboSale.Location = New System.Drawing.Point(94, 224)
        Me.cboSale.Name = "cboSale"
        Me.cboSale.Size = New System.Drawing.Size(201, 21)
        Me.cboSale.TabIndex = 493
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(674, 147)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(16, 23)
        Me.Button2.TabIndex = 491
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbotat
        '
        Me.cbotat.FormattingEnabled = True
        Me.cbotat.Items.AddRange(New Object() {"S", "N"})
        Me.cbotat.Location = New System.Drawing.Point(80, 51)
        Me.cbotat.Name = "cbotat"
        Me.cbotat.Size = New System.Drawing.Size(57, 21)
        Me.cbotat.TabIndex = 492
        Me.cbotat.Text = "S"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Location = New System.Drawing.Point(461, 151)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 490
        Me.Label9.Text = "(S/P No. ) :"
        Me.Label9.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label11.Location = New System.Drawing.Point(114, 11)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 498
        Me.Label11.Text = "POD/DIS :"
        '
        'cboRef
        '
        Me.cboRef.FormattingEnabled = True
        Me.cboRef.Location = New System.Drawing.Point(535, 148)
        Me.cboRef.Name = "cboRef"
        Me.cboRef.Size = New System.Drawing.Size(133, 21)
        Me.cboRef.TabIndex = 489
        Me.cboRef.Visible = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(143, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 488
        Me.Button1.Text = "Get Ref."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkair
        '
        Me.chkair.AutoSize = True
        Me.chkair.Location = New System.Drawing.Point(812, 91)
        Me.chkair.Name = "chkair"
        Me.chkair.Size = New System.Drawing.Size(14, 13)
        Me.chkair.TabIndex = 485
        Me.chkair.TabStop = True
        Me.chkair.UseVisualStyleBackColor = True
        Me.chkair.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(234, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 487
        Me.Label8.Visible = False
        '
        'cbobranch
        '
        Me.cbobranch.FormattingEnabled = True
        Me.cbobranch.Items.AddRange(New Object() {"SGN", "HPH", "HAN", "DAD"})
        Me.cbobranch.Location = New System.Drawing.Point(17, 51)
        Me.cbobranch.Name = "cbobranch"
        Me.cbobranch.Size = New System.Drawing.Size(57, 21)
        Me.cbobranch.TabIndex = 486
        Me.cbobranch.Text = "SGN"
        '
        'chkconsol
        '
        Me.chkconsol.AutoSize = True
        Me.chkconsol.Location = New System.Drawing.Point(751, 91)
        Me.chkconsol.Name = "chkconsol"
        Me.chkconsol.Size = New System.Drawing.Size(14, 13)
        Me.chkconsol.TabIndex = 484
        Me.chkconsol.TabStop = True
        Me.chkconsol.UseVisualStyleBackColor = True
        Me.chkconsol.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(1, 96)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 481
        Me.Label7.Text = "BKNo. :"
        '
        'chklcl
        '
        Me.chklcl.AutoSize = True
        Me.chklcl.Location = New System.Drawing.Point(701, 91)
        Me.chklcl.Name = "chklcl"
        Me.chklcl.Size = New System.Drawing.Size(14, 13)
        Me.chklcl.TabIndex = 483
        Me.chklcl.TabStop = True
        Me.chklcl.UseVisualStyleBackColor = True
        Me.chklcl.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label12.Location = New System.Drawing.Point(1, 230)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 505
        Me.Label12.Text = "Sale :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label13.Location = New System.Drawing.Point(1, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(79, 13)
        Me.Label13.TabIndex = 503
        Me.Label13.Text = "Quotation No. :"
        '
        'cboQuotation
        '
        Me.cboQuotation.FormattingEnabled = True
        Me.cboQuotation.Location = New System.Drawing.Point(95, 251)
        Me.cboQuotation.Name = "cboQuotation"
        Me.cboQuotation.Size = New System.Drawing.Size(200, 21)
        Me.cboQuotation.TabIndex = 502
        '
        'Button4
        '
        Me.Button4.ForeColor = System.Drawing.Color.Maroon
        Me.Button4.Location = New System.Drawing.Point(234, 86)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(61, 23)
        Me.Button4.TabIndex = 506
        Me.Button4.Text = "Get Ref."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label14.Location = New System.Drawing.Point(1, 148)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 508
        Me.Label14.Text = "LOT :"
        '
        'txtlot
        '
        Me.txtlot.Location = New System.Drawing.Point(95, 143)
        Me.txtlot.Name = "txtlot"
        Me.txtlot.Size = New System.Drawing.Size(200, 20)
        Me.txtlot.TabIndex = 507
        '
        'txtetd
        '
        Me.txtetd.BackColor = System.Drawing.SystemColors.Info
        Me.txtetd.Location = New System.Drawing.Point(205, 169)
        Me.txtetd.Name = "txtetd"
        Me.txtetd.Size = New System.Drawing.Size(90, 20)
        Me.txtetd.TabIndex = 509
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(187, 168)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(14, 23)
        Me.Button6.TabIndex = 510
        Me.Button6.Text = ">"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label15.Location = New System.Drawing.Point(1, 174)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(35, 13)
        Me.Label15.TabIndex = 512
        Me.Label15.Text = "ETD :"
        '
        'dtpETD
        '
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(95, 169)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(86, 20)
        Me.dtpETD.TabIndex = 511
        '
        'txteta
        '
        Me.txteta.BackColor = System.Drawing.SystemColors.Info
        Me.txteta.Location = New System.Drawing.Point(205, 195)
        Me.txteta.Name = "txteta"
        Me.txteta.Size = New System.Drawing.Size(90, 20)
        Me.txteta.TabIndex = 513
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(187, 194)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(14, 23)
        Me.Button7.TabIndex = 514
        Me.Button7.Text = ">"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label17.Location = New System.Drawing.Point(1, 199)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 516
        Me.Label17.Text = "ETA :"
        '
        'dtpETA
        '
        Me.dtpETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETA.Location = New System.Drawing.Point(95, 195)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(86, 20)
        Me.dtpETA.TabIndex = 515
        '
        'frmInputOutbound_OverseaAirExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 519)
        Me.Controls.Add(Me.txteta)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.dtpETA)
        Me.Controls.Add(Me.txtetd)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.dtpETD)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtlot)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cboQuotation)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cbopolcode)
        Me.Controls.Add(Me.cbopodcode)
        Me.Controls.Add(Me.chkfcl)
        Me.Controls.Add(Me.dgdBillNumber)
        Me.Controls.Add(Me.cboBKNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.palBillHouse)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.txtNumberBillHouse)
        Me.Controls.Add(Me.txtBillNumber)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboAgent)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.cbotat)
        Me.Controls.Add(Me.cboSale)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.chkair)
        Me.Controls.Add(Me.cboRef)
        Me.Controls.Add(Me.cbobranch)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.chkconsol)
        Me.Controls.Add(Me.chklcl)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInputOutbound_OverseaAirExport"
        Me.Text = "Input Ref. Oversea Air Export"
        Me.ctxGetBLNo.ResumeLayout(False)
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ctxGetBLNo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GetBLNoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cbopolcode As System.Windows.Forms.ComboBox
    Friend WithEvents cbopodcode As System.Windows.Forms.ComboBox
    Friend WithEvents chkfcl As System.Windows.Forms.RadioButton
    Friend WithEvents cboBKNo As System.Windows.Forms.ComboBox
    Friend WithEvents dgdBillNumber As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents palBillHouse As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtNumberBillHouse As System.Windows.Forms.TextBox
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboSale As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbotat As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboRef As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkair As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbobranch As System.Windows.Forms.ComboBox
    Friend WithEvents chkconsol As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chklcl As System.Windows.Forms.RadioButton
    Friend WithEvents BLOB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mblcarrier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBLMAWB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HBLHAWB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BKNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cboQuotation As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtlot As System.Windows.Forms.TextBox
    Friend WithEvents txtetd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents txteta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
End Class
