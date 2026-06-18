<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBillInbound_OverSeaSeaExport
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputBillInbound_OverSeaSeaExport))
        Me.cbopolcode = New System.Windows.Forms.ComboBox
        Me.cbopodcode = New System.Windows.Forms.ComboBox
        Me.chkfcl = New System.Windows.Forms.RadioButton
        Me.cboBKNo = New System.Windows.Forms.ComboBox
        Me.dgdBillNumber = New System.Windows.Forms.DataGridView
        Me.BLOB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Order = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mblcarrier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MBLMAWB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HBLHAWB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BKNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRef = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.palBillHouse = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdReset = New System.Windows.Forms.Button
        Me.lblTotal = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtNumberBillHouse = New System.Windows.Forms.TextBox
        Me.txtBillNumber = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.cboAgent = New System.Windows.Forms.ComboBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboSale = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbotat = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.ctxGetBLNo = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GetBLNoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboRef = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkair = New System.Windows.Forms.RadioButton
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbobranch = New System.Windows.Forms.ComboBox
        Me.chkconsol = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.chklcl = New System.Windows.Forms.RadioButton
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxGetBLNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'cbopolcode
        '
        Me.cbopolcode.DropDownWidth = 150
        Me.cbopolcode.FormattingEnabled = True
        Me.cbopolcode.Location = New System.Drawing.Point(487, 267)
        Me.cbopolcode.Name = "cbopolcode"
        Me.cbopolcode.Size = New System.Drawing.Size(60, 21)
        Me.cbopolcode.TabIndex = 462
        '
        'cbopodcode
        '
        Me.cbopodcode.DropDownWidth = 150
        Me.cbopodcode.FormattingEnabled = True
        Me.cbopodcode.Location = New System.Drawing.Point(615, 267)
        Me.cbopodcode.Name = "cbopodcode"
        Me.cbopodcode.Size = New System.Drawing.Size(63, 21)
        Me.cbopodcode.TabIndex = 461
        '
        'chkfcl
        '
        Me.chkfcl.AutoSize = True
        Me.chkfcl.Location = New System.Drawing.Point(287, 235)
        Me.chkfcl.Name = "chkfcl"
        Me.chkfcl.Size = New System.Drawing.Size(14, 13)
        Me.chkfcl.TabIndex = 444
        Me.chkfcl.TabStop = True
        Me.chkfcl.UseVisualStyleBackColor = True
        Me.chkfcl.Visible = False
        '
        'cboBKNo
        '
        Me.cboBKNo.FormattingEnabled = True
        Me.cboBKNo.Location = New System.Drawing.Point(91, 281)
        Me.cboBKNo.Name = "cboBKNo"
        Me.cboBKNo.Size = New System.Drawing.Size(133, 21)
        Me.cboBKNo.TabIndex = 442
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
        Me.dgdBillNumber.Location = New System.Drawing.Point(12, 12)
        Me.dgdBillNumber.Name = "dgdBillNumber"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgdBillNumber.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdBillNumber.Size = New System.Drawing.Size(670, 217)
        Me.dgdBillNumber.TabIndex = 440
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
        Me.mblcarrier.HeaderText = "MBL Carrier"
        Me.mblcarrier.Name = "mblcarrier"
        '
        'MBLMAWB
        '
        Me.MBLMAWB.DataPropertyName = "MBLMAWB"
        Me.MBLMAWB.HeaderText = "HBL/MAWB"
        Me.MBLMAWB.Name = "MBLMAWB"
        '
        'HBLHAWB
        '
        Me.HBLHAWB.DataPropertyName = "hblhawb"
        Me.HBLHAWB.HeaderText = "HAWB"
        Me.HBLHAWB.Name = "HBLHAWB"
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
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(16, 315)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 441
        Me.Label6.Text = "Ref No. :"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(91, 310)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(133, 20)
        Me.txtRef.TabIndex = 427
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(243, 297)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 439
        Me.Label4.Text = "House Bill :"
        '
        'palBillHouse
        '
        Me.palBillHouse.AutoScroll = True
        Me.palBillHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.palBillHouse.Location = New System.Drawing.Point(245, 314)
        Me.palBillHouse.Name = "palBillHouse"
        Me.palBillHouse.Size = New System.Drawing.Size(433, 100)
        Me.palBillHouse.TabIndex = 438
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(123, 430)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 437
        Me.Label3.Text = "Bills"
        '
        'cmdReset
        '
        Me.cmdReset.ForeColor = System.Drawing.Color.Maroon
        Me.cmdReset.Location = New System.Drawing.Point(163, 391)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(61, 23)
        Me.cmdReset.TabIndex = 430
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal.Location = New System.Drawing.Point(67, 430)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblTotal.TabIndex = 436
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(24, 430)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 435
        Me.Label2.Text = "Total :"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(522, 420)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 432
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtNumberBillHouse
        '
        Me.txtNumberBillHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberBillHouse.Location = New System.Drawing.Point(132, 359)
        Me.txtNumberBillHouse.Name = "txtNumberBillHouse"
        Me.txtNumberBillHouse.Size = New System.Drawing.Size(92, 24)
        Me.txtNumberBillHouse.TabIndex = 429
        '
        'txtBillNumber
        '
        Me.txtBillNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNumber.Location = New System.Drawing.Point(91, 333)
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(133, 24)
        Me.txtBillNumber.TabIndex = 428
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(441, 420)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 431
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(16, 336)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 434
        Me.Label1.Text = "MBL (Carrier) :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(28, 362)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 433
        Me.Label5.Text = "Number House Bill :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(422, 271)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 459
        Me.Label10.Text = "POL/ORG :"
        '
        'cboAgent
        '
        Me.cboAgent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAgent.DropDownWidth = 300
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(246, 267)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(170, 24)
        Me.cboAgent.TabIndex = 457
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.ForeColor = System.Drawing.Color.Maroon
        Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label73.Location = New System.Drawing.Point(244, 250)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(41, 13)
        Me.Label73.TabIndex = 458
        Me.Label73.Text = "Agent :"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(199, 101)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 456
        Me.Label16.Text = "Sale :"
        Me.Label16.Visible = False
        '
        'cboSale
        '
        Me.cboSale.DropDownWidth = 400
        Me.cboSale.FormattingEnabled = True
        Me.cboSale.Location = New System.Drawing.Point(267, 97)
        Me.cboSale.Name = "cboSale"
        Me.cboSale.Size = New System.Drawing.Size(134, 21)
        Me.cboSale.TabIndex = 455
        Me.cboSale.Visible = False
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(407, 123)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(16, 23)
        Me.Button2.TabIndex = 453
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbotat
        '
        Me.cbotat.FormattingEnabled = True
        Me.cbotat.Items.AddRange(New Object() {"S", "N"})
        Me.cbotat.Location = New System.Drawing.Point(80, 244)
        Me.cbotat.Name = "cbotat"
        Me.cbotat.Size = New System.Drawing.Size(57, 21)
        Me.cbotat.TabIndex = 454
        Me.cbotat.Text = "S"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label9.Location = New System.Drawing.Point(194, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 452
        Me.Label9.Text = "(S/P No. ) :"
        Me.Label9.Visible = False
        '
        'ctxGetBLNo
        '
        Me.ctxGetBLNo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GetBLNoToolStripMenuItem})
        Me.ctxGetBLNo.Name = "ctxGetBLNo"
        Me.ctxGetBLNo.Size = New System.Drawing.Size(153, 48)
        '
        'GetBLNoToolStripMenuItem
        '
        Me.GetBLNoToolStripMenuItem.Name = "GetBLNoToolStripMenuItem"
        Me.GetBLNoToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.GetBLNoToolStripMenuItem.Text = "Get B/L No"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label11.Location = New System.Drawing.Point(553, 271)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 460
        Me.Label11.Text = "POD/DIS :"
        '
        'cboRef
        '
        Me.cboRef.FormattingEnabled = True
        Me.cboRef.Location = New System.Drawing.Point(268, 124)
        Me.cboRef.Name = "cboRef"
        Me.cboRef.Size = New System.Drawing.Size(133, 21)
        Me.cboRef.TabIndex = 451
        Me.cboRef.Visible = False
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(143, 244)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 450
        Me.Button1.Text = "Get Ref."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkair
        '
        Me.chkair.AutoSize = True
        Me.chkair.Location = New System.Drawing.Point(448, 235)
        Me.chkair.Name = "chkair"
        Me.chkair.Size = New System.Drawing.Size(14, 13)
        Me.chkair.TabIndex = 447
        Me.chkair.TabStop = True
        Me.chkair.UseVisualStyleBackColor = True
        Me.chkair.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(234, 279)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 449
        Me.Label8.Visible = False
        '
        'cbobranch
        '
        Me.cbobranch.FormattingEnabled = True
        Me.cbobranch.Items.AddRange(New Object() {"SGN", "HPH", "HAN", "DAD"})
        Me.cbobranch.Location = New System.Drawing.Point(17, 244)
        Me.cbobranch.Name = "cbobranch"
        Me.cbobranch.Size = New System.Drawing.Size(57, 21)
        Me.cbobranch.TabIndex = 448
        Me.cbobranch.Text = "SGN"
        '
        'chkconsol
        '
        Me.chkconsol.AutoSize = True
        Me.chkconsol.Location = New System.Drawing.Point(387, 235)
        Me.chkconsol.Name = "chkconsol"
        Me.chkconsol.Size = New System.Drawing.Size(14, 13)
        Me.chkconsol.TabIndex = 446
        Me.chkconsol.TabStop = True
        Me.chkconsol.UseVisualStyleBackColor = True
        Me.chkconsol.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(16, 289)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 443
        Me.Label7.Text = "BKNo. :"
        '
        'chklcl
        '
        Me.chklcl.AutoSize = True
        Me.chklcl.Location = New System.Drawing.Point(337, 235)
        Me.chklcl.Name = "chklcl"
        Me.chklcl.Size = New System.Drawing.Size(14, 13)
        Me.chklcl.TabIndex = 445
        Me.chklcl.TabStop = True
        Me.chklcl.UseVisualStyleBackColor = True
        Me.chklcl.Visible = False
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "BLOB_iD"
        Me.DataGridViewTextBoxColumn1.HeaderText = "BLOB_ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "order"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Order"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "mblcarrier"
        Me.DataGridViewTextBoxColumn3.HeaderText = "MBL Carrier"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "MBLMAWB"
        Me.DataGridViewTextBoxColumn4.HeaderText = "HBL/MAWB"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "hblhawb"
        Me.DataGridViewTextBoxColumn5.HeaderText = "HAWB"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "bkno"
        Me.DataGridViewTextBoxColumn6.HeaderText = "BKNo"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "UserUpdate"
        Me.DataGridViewTextBoxColumn7.HeaderText = "User Update"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "DateUpdate"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Date Update"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(603, 420)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 463
        Me.Button3.Text = "&Doc."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmInputBillInbound_OverSeaSeaExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 513)
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
        Me.Controls.Add(Me.cboSale)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cbotat)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboRef)
        Me.Controls.Add(Me.chkair)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbobranch)
        Me.Controls.Add(Me.chkconsol)
        Me.Controls.Add(Me.chklcl)
        Me.Controls.Add(Me.Label7)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInputBillInbound_OverSeaSeaExport"
        Me.Text = "Input Bill Outbound"
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxGetBLNo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbopolcode As System.Windows.Forms.ComboBox
    Friend WithEvents cbopodcode As System.Windows.Forms.ComboBox
    Friend WithEvents chkfcl As System.Windows.Forms.RadioButton
    Friend WithEvents cboBKNo As System.Windows.Forms.ComboBox
    Friend WithEvents dgdBillNumber As System.Windows.Forms.DataGridView
    Friend WithEvents BLOB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Order As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mblcarrier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBLMAWB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HBLHAWB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BKNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents ctxGetBLNo As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GetBLNoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboRef As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkair As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbobranch As System.Windows.Forms.ComboBox
    Friend WithEvents chkconsol As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chklcl As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
