<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBillInbound_OverSeaAirImport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputBillInbound_OverSeaAirImport))
        Me.cboAgent = New System.Windows.Forms.ComboBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboSale = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cbotat = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboQuotation = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkair = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cbobranch = New System.Windows.Forms.ComboBox()
        Me.txtRef = New System.Windows.Forms.TextBox()
        Me.chkconsol = New System.Windows.Forms.RadioButton()
        Me.chklcl = New System.Windows.Forms.RadioButton()
        Me.chkfcl = New System.Windows.Forms.RadioButton()
        Me.dgdBillNumber = New System.Windows.Forms.DataGridView()
        Me.BLIB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.palBillHouse = New System.Windows.Forms.Panel()
        Me.cmdReset = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNumberBillHouse = New System.Windows.Forms.TextBox()
        Me.txtBillNumber = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtfindpod = New System.Windows.Forms.TextBox()
        Me.txtfindpol = New System.Windows.Forms.TextBox()
        Me.cbopolcode = New System.Windows.Forms.ComboBox()
        Me.cbopodcode = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtlot = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtetd = New System.Windows.Forms.MaskedTextBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpETD = New System.Windows.Forms.DateTimePicker()
        Me.txteta = New System.Windows.Forms.MaskedTextBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpETA = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboAgent
        '
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(103, 315)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(358, 24)
        Me.cboAgent.TabIndex = 21
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.ForeColor = System.Drawing.Color.Blue
        Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label73.Location = New System.Drawing.Point(14, 329)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(41, 13)
        Me.Label73.TabIndex = 480
        Me.Label73.Text = "Agent :"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(254, 234)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(34, 13)
        Me.Label16.TabIndex = 478
        Me.Label16.Text = "Sale :"
        '
        'cboSale
        '
        Me.cboSale.DropDownWidth = 400
        Me.cboSale.FormattingEnabled = True
        Me.cboSale.Location = New System.Drawing.Point(297, 231)
        Me.cboSale.Name = "cboSale"
        Me.cboSale.Size = New System.Drawing.Size(164, 21)
        Me.cboSale.TabIndex = 17
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(35, 416)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(16, 23)
        Me.Button2.TabIndex = 475
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbotat
        '
        Me.cbotat.FormattingEnabled = True
        Me.cbotat.Items.AddRange(New Object() {"S", "N"})
        Me.cbotat.Location = New System.Drawing.Point(166, 78)
        Me.cbotat.Name = "cbotat"
        Me.cbotat.Size = New System.Drawing.Size(57, 21)
        Me.cbotat.TabIndex = 6
        Me.cbotat.Text = "S"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(14, 234)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 13)
        Me.Label8.TabIndex = 474
        Me.Label8.Text = "Quotation No. :"
        '
        'cboQuotation
        '
        Me.cboQuotation.FormattingEnabled = True
        Me.cboQuotation.Location = New System.Drawing.Point(103, 231)
        Me.cboQuotation.Name = "cboQuotation"
        Me.cboQuotation.Size = New System.Drawing.Size(146, 21)
        Me.cboQuotation.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(20, 421)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 471
        Me.Label7.Text = "Branch :"
        Me.Label7.Visible = False
        '
        'chkair
        '
        Me.chkair.AutoSize = True
        Me.chkair.Location = New System.Drawing.Point(25, 419)
        Me.chkair.Name = "chkair"
        Me.chkair.Size = New System.Drawing.Size(37, 17)
        Me.chkair.TabIndex = 469
        Me.chkair.Text = "Air"
        Me.chkair.UseVisualStyleBackColor = True
        Me.chkair.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(14, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 465
        Me.Label6.Text = "Ref No. :"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(227, 77)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Get Ref."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbobranch
        '
        Me.cbobranch.FormattingEnabled = True
        Me.cbobranch.Items.AddRange(New Object() {"SGN", "HPH", "HAN", "DAD"})
        Me.cbobranch.Location = New System.Drawing.Point(105, 78)
        Me.cbobranch.Name = "cbobranch"
        Me.cbobranch.Size = New System.Drawing.Size(57, 21)
        Me.cbobranch.TabIndex = 5
        Me.cbobranch.Text = "SGN"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(103, 120)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(358, 20)
        Me.txtRef.TabIndex = 8
        '
        'chkconsol
        '
        Me.chkconsol.AutoSize = True
        Me.chkconsol.ForeColor = System.Drawing.Color.Blue
        Me.chkconsol.Location = New System.Drawing.Point(15, 419)
        Me.chkconsol.Name = "chkconsol"
        Me.chkconsol.Size = New System.Drawing.Size(57, 17)
        Me.chkconsol.TabIndex = 468
        Me.chkconsol.Text = "Consol"
        Me.chkconsol.UseVisualStyleBackColor = True
        Me.chkconsol.Visible = False
        '
        'chklcl
        '
        Me.chklcl.AutoSize = True
        Me.chklcl.Location = New System.Drawing.Point(21, 419)
        Me.chklcl.Name = "chklcl"
        Me.chklcl.Size = New System.Drawing.Size(44, 17)
        Me.chklcl.TabIndex = 467
        Me.chklcl.Text = "LCL"
        Me.chklcl.UseVisualStyleBackColor = True
        Me.chklcl.Visible = False
        '
        'chkfcl
        '
        Me.chkfcl.AutoSize = True
        Me.chkfcl.Checked = True
        Me.chkfcl.Location = New System.Drawing.Point(21, 419)
        Me.chkfcl.Name = "chkfcl"
        Me.chkfcl.Size = New System.Drawing.Size(44, 17)
        Me.chkfcl.TabIndex = 466
        Me.chkfcl.TabStop = True
        Me.chkfcl.Text = "FCL"
        Me.chkfcl.UseVisualStyleBackColor = True
        Me.chkfcl.Visible = False
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
        Me.dgdBillNumber.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLIB_ID, Me.RefNo, Me.mbl, Me.hbl, Me.UserUpdate, Me.DateUpdate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Navy
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdBillNumber.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgdBillNumber.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.dgdBillNumber.Location = New System.Drawing.Point(467, 12)
        Me.dgdBillNumber.Name = "dgdBillNumber"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgdBillNumber.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdBillNumber.Size = New System.Drawing.Size(576, 456)
        Me.dgdBillNumber.TabIndex = 464
        '
        'BLIB_ID
        '
        Me.BLIB_ID.DataPropertyName = "BLIB_ID"
        Me.BLIB_ID.HeaderText = "BLIB_ID"
        Me.BLIB_ID.Name = "BLIB_ID"
        Me.BLIB_ID.Visible = False
        '
        'RefNo
        '
        Me.RefNo.DataPropertyName = "ref"
        Me.RefNo.HeaderText = "Ref No."
        Me.RefNo.Name = "RefNo"
        '
        'mbl
        '
        Me.mbl.DataPropertyName = "mbl"
        Me.mbl.HeaderText = "Mawb"
        Me.mbl.Name = "mbl"
        '
        'hbl
        '
        Me.hbl.DataPropertyName = "hbl"
        Me.hbl.HeaderText = "Hawb"
        Me.hbl.Name = "hbl"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(14, 343)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 463
        Me.Label4.Text = "Hawb :"
        '
        'palBillHouse
        '
        Me.palBillHouse.AutoScroll = True
        Me.palBillHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.palBillHouse.Location = New System.Drawing.Point(103, 343)
        Me.palBillHouse.Name = "palBillHouse"
        Me.palBillHouse.Size = New System.Drawing.Size(358, 64)
        Me.palBillHouse.TabIndex = 22
        '
        'cmdReset
        '
        Me.cmdReset.ForeColor = System.Drawing.Color.Maroon
        Me.cmdReset.Location = New System.Drawing.Point(402, 287)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(58, 23)
        Me.cmdReset.TabIndex = 20
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(115, 447)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 13)
        Me.Label3.TabIndex = 461
        Me.Label3.Text = "Bills"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal.Location = New System.Drawing.Point(59, 447)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 13)
        Me.lblTotal.TabIndex = 460
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(16, 447)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 459
        Me.Label2.Text = "Total :"
        '
        'txtNumberBillHouse
        '
        Me.txtNumberBillHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberBillHouse.Location = New System.Drawing.Point(103, 285)
        Me.txtNumberBillHouse.Name = "txtNumberBillHouse"
        Me.txtNumberBillHouse.Size = New System.Drawing.Size(293, 24)
        Me.txtNumberBillHouse.TabIndex = 19
        Me.txtNumberBillHouse.Text = "1"
        '
        'txtBillNumber
        '
        Me.txtBillNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNumber.Location = New System.Drawing.Point(103, 257)
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(358, 24)
        Me.txtBillNumber.TabIndex = 18
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(216, 416)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 24
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(135, 416)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 23
        Me.cmdOK.Text = "Save"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(14, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 13)
        Me.Label5.TabIndex = 457
        Me.Label5.Text = "Quantity of Hawb :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(14, 260)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 458
        Me.Label1.Text = "Mawb :"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(297, 416)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "&Doc."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(14, 26)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Find Code :"
        '
        'txtfindpod
        '
        Me.txtfindpod.Location = New System.Drawing.Point(274, 23)
        Me.txtfindpod.Name = "txtfindpod"
        Me.txtfindpod.Size = New System.Drawing.Size(187, 20)
        Me.txtfindpod.TabIndex = 2
        '
        'txtfindpol
        '
        Me.txtfindpol.Location = New System.Drawing.Point(103, 23)
        Me.txtfindpol.Name = "txtfindpol"
        Me.txtfindpol.Size = New System.Drawing.Size(165, 20)
        Me.txtfindpol.TabIndex = 1
        '
        'cbopolcode
        '
        Me.cbopolcode.DropDownWidth = 150
        Me.cbopolcode.FormattingEnabled = True
        Me.cbopolcode.Location = New System.Drawing.Point(104, 50)
        Me.cbopolcode.Name = "cbopolcode"
        Me.cbopolcode.Size = New System.Drawing.Size(164, 21)
        Me.cbopolcode.TabIndex = 3
        '
        'cbopodcode
        '
        Me.cbopodcode.DropDownWidth = 150
        Me.cbopodcode.FormattingEnabled = True
        Me.cbopodcode.Location = New System.Drawing.Point(274, 50)
        Me.cbopodcode.Name = "cbopodcode"
        Me.cbopodcode.Size = New System.Drawing.Size(187, 21)
        Me.cbopodcode.TabIndex = 4
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label10.Location = New System.Drawing.Point(104, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 13)
        Me.Label10.TabIndex = 2428
        Me.Label10.Text = "POL/ORG :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label11.Location = New System.Drawing.Point(271, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 13)
        Me.Label11.TabIndex = 2429
        Me.Label11.Text = "POD/DIS :"
        '
        'txtlot
        '
        Me.txtlot.Location = New System.Drawing.Point(103, 144)
        Me.txtlot.Name = "txtlot"
        Me.txtlot.Size = New System.Drawing.Size(358, 20)
        Me.txtlot.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(14, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 13)
        Me.Label9.TabIndex = 465
        Me.Label9.Text = "LOT No. :"
        '
        'txtetd
        '
        Me.txtetd.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtetd.Location = New System.Drawing.Point(227, 169)
        Me.txtetd.Name = "txtetd"
        Me.txtetd.Size = New System.Drawing.Size(234, 20)
        Me.txtetd.TabIndex = 12
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(207, 168)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(14, 23)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = ">"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label12.Location = New System.Drawing.Point(14, 171)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 13)
        Me.Label12.TabIndex = 2438
        Me.Label12.Text = "Date Departure :"
        '
        'dtpETD
        '
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(103, 169)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(97, 20)
        Me.dtpETD.TabIndex = 10
        '
        'txteta
        '
        Me.txteta.BackColor = System.Drawing.Color.LemonChiffon
        Me.txteta.Location = New System.Drawing.Point(227, 193)
        Me.txteta.Name = "txteta"
        Me.txteta.Size = New System.Drawing.Size(234, 20)
        Me.txteta.TabIndex = 15
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(206, 193)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(14, 23)
        Me.Button7.TabIndex = 14
        Me.Button7.Text = ">"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label13.Location = New System.Drawing.Point(14, 198)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 13)
        Me.Label13.TabIndex = 2442
        Me.Label13.Text = "Date Arrival :"
        '
        'dtpETA
        '
        Me.dtpETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETA.Location = New System.Drawing.Point(104, 193)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(96, 20)
        Me.dtpETA.TabIndex = 13
        '
        'frmInputBillInbound_OverSeaAirImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 480)
        Me.Controls.Add(Me.txteta)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.dtpETA)
        Me.Controls.Add(Me.txtetd)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.dtpETD)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtfindpod)
        Me.Controls.Add(Me.txtfindpol)
        Me.Controls.Add(Me.cbopolcode)
        Me.Controls.Add(Me.cbopodcode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cboAgent)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cboSale)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbotat)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboQuotation)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkair)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbobranch)
        Me.Controls.Add(Me.txtlot)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.chkconsol)
        Me.Controls.Add(Me.chklcl)
        Me.Controls.Add(Me.chkfcl)
        Me.Controls.Add(Me.dgdBillNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.palBillHouse)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtNumberBillHouse)
        Me.Controls.Add(Me.txtBillNumber)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmInputBillInbound_OverSeaAirImport"
        Me.Text = "Input Air Ref."
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboAgent As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboSale As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cbotat As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboQuotation As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkair As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbobranch As System.Windows.Forms.ComboBox
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents chkconsol As System.Windows.Forms.RadioButton
    Friend WithEvents chklcl As System.Windows.Forms.RadioButton
    Friend WithEvents chkfcl As System.Windows.Forms.RadioButton
    Friend WithEvents dgdBillNumber As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents palBillHouse As System.Windows.Forms.Panel
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumberBillHouse As System.Windows.Forms.TextBox
    Friend WithEvents txtBillNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BLIB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtfindpod As System.Windows.Forms.TextBox
    Friend WithEvents txtfindpol As System.Windows.Forms.TextBox
    Friend WithEvents cbopolcode As System.Windows.Forms.ComboBox
    Friend WithEvents cbopodcode As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtlot As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtetd As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents txteta As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
End Class
