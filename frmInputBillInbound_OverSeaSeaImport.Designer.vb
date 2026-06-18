<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputBillInbound_OverSeaSeaImport
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputBillInbound_OverSeaSeaImport))
        Me.cboAgent = New System.Windows.Forms.ComboBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cboSale = New System.Windows.Forms.ComboBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.cbotat = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboRef = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.chkair = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbobranch = New System.Windows.Forms.ComboBox
        Me.txtRef = New System.Windows.Forms.TextBox
        Me.chkconsol = New System.Windows.Forms.RadioButton
        Me.chklcl = New System.Windows.Forms.RadioButton
        Me.chkfcl = New System.Windows.Forms.RadioButton
        Me.dgdBillNumber = New System.Windows.Forms.DataGridView
        Me.BLIB_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.mbl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hbl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label4 = New System.Windows.Forms.Label
        Me.palBillHouse = New System.Windows.Forms.Panel
        Me.cmdReset = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblTotal = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumberBillHouse = New System.Windows.Forms.TextBox
        Me.txtBillNumber = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.dgdBillNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboAgent
        '
        Me.cboAgent.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(328, 353)
        Me.cboAgent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(577, 28)
        Me.cboAgent.TabIndex = 449
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.ForeColor = System.Drawing.Color.Maroon
        Me.Label73.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label73.Location = New System.Drawing.Point(325, 332)
        Me.Label73.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(53, 17)
        Me.Label73.TabIndex = 450
        Me.Label73.Text = "Agent :"
        Me.Label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(195, 132)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 17)
        Me.Label16.TabIndex = 448
        Me.Label16.Text = "Sale :"
        Me.Label16.Visible = False
        '
        'cboSale
        '
        Me.cboSale.DropDownWidth = 400
        Me.cboSale.FormattingEnabled = True
        Me.cboSale.Location = New System.Drawing.Point(287, 127)
        Me.cboSale.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboSale.Name = "cboSale"
        Me.cboSale.Size = New System.Drawing.Size(176, 24)
        Me.cboSale.TabIndex = 447
        Me.cboSale.Visible = False
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(472, 156)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(21, 28)
        Me.Button2.TabIndex = 445
        Me.Button2.Text = ">"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'cbotat
        '
        Me.cbotat.FormattingEnabled = True
        Me.cbotat.Items.AddRange(New Object() {"S", "N"})
        Me.cbotat.Location = New System.Drawing.Point(103, 310)
        Me.cbotat.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbotat.Name = "cbotat"
        Me.cbotat.Size = New System.Drawing.Size(75, 24)
        Me.cbotat.TabIndex = 446
        Me.cbotat.Text = "S"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(188, 161)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 17)
        Me.Label8.TabIndex = 444
        Me.Label8.Text = "(S/P No. ) :"
        Me.Label8.Visible = False
        '
        'cboRef
        '
        Me.cboRef.FormattingEnabled = True
        Me.cboRef.Location = New System.Drawing.Point(287, 158)
        Me.cboRef.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboRef.Name = "cboRef"
        Me.cboRef.Size = New System.Drawing.Size(176, 24)
        Me.cboRef.TabIndex = 443
        Me.cboRef.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label7.Location = New System.Drawing.Point(829, 294)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 17)
        Me.Label7.TabIndex = 441
        Me.Label7.Text = "Branch :"
        Me.Label7.Visible = False
        '
        'chkair
        '
        Me.chkair.AutoSize = True
        Me.chkair.Location = New System.Drawing.Point(772, 310)
        Me.chkair.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkair.Name = "chkair"
        Me.chkair.Size = New System.Drawing.Size(46, 21)
        Me.chkair.TabIndex = 439
        Me.chkair.Text = "Air"
        Me.chkair.UseVisualStyleBackColor = True
        Me.chkair.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(21, 367)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 17)
        Me.Label6.TabIndex = 435
        Me.Label6.Text = "Ref No. :"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(184, 309)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 28)
        Me.Button1.TabIndex = 442
        Me.Button1.Text = "Get Ref."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cbobranch
        '
        Me.cbobranch.FormattingEnabled = True
        Me.cbobranch.Items.AddRange(New Object() {"SGN", "HPH", "HAN", "DAD"})
        Me.cbobranch.Location = New System.Drawing.Point(21, 310)
        Me.cbobranch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbobranch.Name = "cbobranch"
        Me.cbobranch.Size = New System.Drawing.Size(75, 24)
        Me.cbobranch.TabIndex = 440
        Me.cbobranch.Text = "SGN"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(121, 359)
        Me.txtRef.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(176, 22)
        Me.txtRef.TabIndex = 421
        '
        'chkconsol
        '
        Me.chkconsol.AutoSize = True
        Me.chkconsol.Location = New System.Drawing.Point(691, 310)
        Me.chkconsol.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkconsol.Name = "chkconsol"
        Me.chkconsol.Size = New System.Drawing.Size(72, 21)
        Me.chkconsol.TabIndex = 438
        Me.chkconsol.Text = "Consol"
        Me.chkconsol.UseVisualStyleBackColor = True
        Me.chkconsol.Visible = False
        '
        'chklcl
        '
        Me.chklcl.AutoSize = True
        Me.chklcl.Location = New System.Drawing.Point(624, 310)
        Me.chklcl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chklcl.Name = "chklcl"
        Me.chklcl.Size = New System.Drawing.Size(54, 21)
        Me.chklcl.TabIndex = 437
        Me.chklcl.Text = "LCL"
        Me.chklcl.UseVisualStyleBackColor = True
        Me.chklcl.Visible = False
        '
        'chkfcl
        '
        Me.chkfcl.AutoSize = True
        Me.chkfcl.Checked = True
        Me.chkfcl.Location = New System.Drawing.Point(557, 310)
        Me.chkfcl.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkfcl.Name = "chkfcl"
        Me.chkfcl.Size = New System.Drawing.Size(54, 21)
        Me.chkfcl.TabIndex = 436
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
        Me.dgdBillNumber.Location = New System.Drawing.Point(16, 15)
        Me.dgdBillNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgdBillNumber.Name = "dgdBillNumber"
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgdBillNumber.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdBillNumber.Size = New System.Drawing.Size(891, 276)
        Me.dgdBillNumber.TabIndex = 434
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
        Me.mbl.HeaderText = "MBL"
        Me.mbl.Name = "mbl"
        '
        'hbl
        '
        Me.hbl.DataPropertyName = "hbl"
        Me.hbl.HeaderText = "HBL"
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
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(324, 386)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 17)
        Me.Label4.TabIndex = 433
        Me.Label4.Text = "House Bill :"
        '
        'palBillHouse
        '
        Me.palBillHouse.AutoScroll = True
        Me.palBillHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.palBillHouse.Location = New System.Drawing.Point(327, 407)
        Me.palBillHouse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.palBillHouse.Name = "palBillHouse"
        Me.palBillHouse.Size = New System.Drawing.Size(577, 123)
        Me.palBillHouse.TabIndex = 432
        '
        'cmdReset
        '
        Me.cmdReset.ForeColor = System.Drawing.Color.Maroon
        Me.cmdReset.Location = New System.Drawing.Point(217, 460)
        Me.cmdReset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(81, 28)
        Me.cmdReset.TabIndex = 424
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(164, 506)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 17)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "Bills"
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTotal.Location = New System.Drawing.Point(89, 506)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(0, 17)
        Me.lblTotal.TabIndex = 430
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(32, 506)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 17)
        Me.Label2.TabIndex = 429
        Me.Label2.Text = "Total :"
        '
        'txtNumberBillHouse
        '
        Me.txtNumberBillHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberBillHouse.Location = New System.Drawing.Point(176, 423)
        Me.txtNumberBillHouse.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNumberBillHouse.Name = "txtNumberBillHouse"
        Me.txtNumberBillHouse.Size = New System.Drawing.Size(121, 29)
        Me.txtNumberBillHouse.TabIndex = 423
        '
        'txtBillNumber
        '
        Me.txtBillNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBillNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNumber.Location = New System.Drawing.Point(121, 389)
        Me.txtBillNumber.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBillNumber.Name = "txtBillNumber"
        Me.txtBillNumber.Size = New System.Drawing.Size(176, 29)
        Me.txtBillNumber.TabIndex = 422
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(691, 538)
        Me.cmdCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(100, 28)
        Me.cmdCancel.TabIndex = 426
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(583, 538)
        Me.cmdOK.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(100, 28)
        Me.cmdOK.TabIndex = 425
        Me.cmdOK.Text = "Save"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(37, 430)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(116, 17)
        Me.Label5.TabIndex = 427
        Me.Label5.Text = "Quantity of HBL :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(21, 393)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 428
        Me.Label1.Text = "MBL (Carrier) :"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Maroon
        Me.Button3.Location = New System.Drawing.Point(799, 538)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 28)
        Me.Button3.TabIndex = 451
        Me.Button3.Text = "&Doc."
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmInputBillInbound_OverSeaSeaImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 598)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cboAgent)
        Me.Controls.Add(Me.Label73)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cboSale)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cbotat)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboRef)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkair)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbobranch)
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
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmInputBillInbound_OverSeaSeaImport"
        Me.Text = "Input Bill Inbound"
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
    Friend WithEvents cboRef As System.Windows.Forms.ComboBox
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
    Friend WithEvents BLIB_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
