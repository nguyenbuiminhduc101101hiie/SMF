<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPayMent
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtBL_NO = New System.Windows.Forms.TextBox
        Me.txtVND = New System.Windows.Forms.TextBox
        Me.txtPay = New System.Windows.Forms.TextBox
        Me.txtRate = New System.Windows.Forms.TextBox
        Me.txtContainer = New System.Windows.Forms.TextBox
        Me.txtCustomer = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lvBL_NO = New System.Windows.Forms.ListBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtBLNOSearch = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.cboCurrency = New System.Windows.Forms.ComboBox
        Me.txtRemaind = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dtpPayDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtUpdateTime = New System.Windows.Forms.TextBox
        Me.txtUserid = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtReceiptNo = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtGetBillName = New System.Windows.Forms.TextBox
        Me.dtpGetBillDate = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtPayerName = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.txtBookingPrepaidCurrency = New System.Windows.Forms.TextBox
        Me.txtBookingPrePaidFee = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtBookingCollectFee = New System.Windows.Forms.TextBox
        Me.txtBookingCollectCurrency = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExport = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDateOfIssue = New System.Windows.Forms.ToolStripMenuItem
        Me.grpIssue = New System.Windows.Forms.GroupBox
        Me.cmdCancelIssue = New System.Windows.Forms.Button
        Me.cmdOKIssue = New System.Windows.Forms.Button
        Me.dtpIssueTo = New System.Windows.Forms.DateTimePicker
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtpIssueFrom = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtVNDLine = New System.Windows.Forms.TextBox
        Me.txtPayLine = New System.Windows.Forms.TextBox
        Me.txtRemaindLine = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtBookingPrepaidCurrencyBuy = New System.Windows.Forms.TextBox
        Me.txtBookingPrePaidFeeBuy = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.TextBox6 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.grpIssue.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(34, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VND :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(295, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Rate :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(369, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Containers"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(25, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Customer :"
        Me.ToolTip1.SetToolTip(Me.Label7, "Shipper / Consignee")
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(34, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "B/L No :"
        '
        'txtBL_NO
        '
        Me.txtBL_NO.Location = New System.Drawing.Point(84, 45)
        Me.txtBL_NO.Name = "txtBL_NO"
        Me.txtBL_NO.Size = New System.Drawing.Size(228, 20)
        Me.txtBL_NO.TabIndex = 3
        '
        'txtVND
        '
        Me.txtVND.ForeColor = System.Drawing.Color.DarkRed
        Me.txtVND.Location = New System.Drawing.Point(72, 76)
        Me.txtVND.Name = "txtVND"
        Me.txtVND.Size = New System.Drawing.Size(102, 20)
        Me.txtVND.TabIndex = 13
        Me.txtVND.Text = "0"
        Me.txtVND.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPay
        '
        Me.txtPay.ForeColor = System.Drawing.Color.DarkRed
        Me.txtPay.Location = New System.Drawing.Point(72, 55)
        Me.txtPay.Name = "txtPay"
        Me.txtPay.Size = New System.Drawing.Size(102, 20)
        Me.txtPay.TabIndex = 12
        Me.txtPay.Text = "0"
        Me.txtPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(333, 19)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(96, 20)
        Me.txtRate.TabIndex = 11
        Me.txtRate.Text = "0"
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtContainer
        '
        Me.txtContainer.Enabled = False
        Me.txtContainer.Location = New System.Drawing.Point(319, 45)
        Me.txtContainer.Name = "txtContainer"
        Me.txtContainer.Size = New System.Drawing.Size(47, 20)
        Me.txtContainer.TabIndex = 4
        Me.txtContainer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(84, 71)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(505, 20)
        Me.txtCustomer.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(12, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Pay (Cus.):"
        '
        'lvBL_NO
        '
        Me.lvBL_NO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvBL_NO.ForeColor = System.Drawing.Color.Black
        Me.lvBL_NO.FormattingEnabled = True
        Me.lvBL_NO.Location = New System.Drawing.Point(0, 26)
        Me.lvBL_NO.Name = "lvBL_NO"
        Me.lvBL_NO.Size = New System.Drawing.Size(311, 485)
        Me.lvBL_NO.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(350, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "B/L No :"
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdOk.Location = New System.Drawing.Point(847, 447)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 16
        Me.cmdOk.Text = "&Ok "
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdFind.Location = New System.Drawing.Point(634, 30)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(75, 20)
        Me.cmdFind.TabIndex = 2
        Me.cmdFind.Text = "&Search"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtBLNOSearch
        '
        Me.txtBLNOSearch.Location = New System.Drawing.Point(400, 30)
        Me.txtBLNOSearch.Name = "txtBLNOSearch"
        Me.txtBLNOSearch.Size = New System.Drawing.Size(228, 20)
        Me.txtBLNOSearch.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancel.Location = New System.Drawing.Point(847, 475)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(20, 99)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(49, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Remain :"
        Me.ToolTip1.SetToolTip(Me.Label13, "Số tiền còn lại ")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(131, 23)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Currency :"
        '
        'cboCurrency
        '
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(187, 19)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(100, 21)
        Me.cboCurrency.TabIndex = 10
        '
        'txtRemaind
        '
        Me.txtRemaind.ForeColor = System.Drawing.Color.DarkRed
        Me.txtRemaind.Location = New System.Drawing.Point(72, 96)
        Me.txtRemaind.Name = "txtRemaind"
        Me.txtRemaind.Size = New System.Drawing.Size(102, 20)
        Me.txtRemaind.TabIndex = 14
        Me.txtRemaind.Text = "0"
        Me.txtRemaind.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.Maroon
        Me.Label14.Location = New System.Drawing.Point(551, 413)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 13)
        Me.Label14.TabIndex = 25
        Me.Label14.Text = "Pay (date) :"
        '
        'dtpPayDate
        '
        Me.dtpPayDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPayDate.Location = New System.Drawing.Point(614, 409)
        Me.dtpPayDate.Name = "dtpPayDate"
        Me.dtpPayDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpPayDate.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(11, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "User Update :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(11, 43)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 13)
        Me.Label11.TabIndex = 27
        Me.Label11.Text = "Update Time :"
        '
        'txtUpdateTime
        '
        Me.txtUpdateTime.Enabled = False
        Me.txtUpdateTime.Location = New System.Drawing.Point(86, 39)
        Me.txtUpdateTime.Name = "txtUpdateTime"
        Me.txtUpdateTime.Size = New System.Drawing.Size(108, 20)
        Me.txtUpdateTime.TabIndex = 28
        '
        'txtUserid
        '
        Me.txtUserid.Enabled = False
        Me.txtUserid.Location = New System.Drawing.Point(86, 13)
        Me.txtUserid.Name = "txtUserid"
        Me.txtUserid.Size = New System.Drawing.Size(108, 20)
        Me.txtUserid.TabIndex = 29
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtUpdateTime)
        Me.GroupBox1.Controls.Add(Me.txtUserid)
        Me.GroupBox1.Location = New System.Drawing.Point(319, 408)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(200, 67)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.Maroon
        Me.Label17.Location = New System.Drawing.Point(15, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(67, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "Receipt No :"
        '
        'txtReceiptNo
        '
        Me.txtReceiptNo.Location = New System.Drawing.Point(84, 19)
        Me.txtReceiptNo.Name = "txtReceiptNo"
        Me.txtReceiptNo.Size = New System.Drawing.Size(228, 20)
        Me.txtReceiptNo.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.txtVNDLine)
        Me.GroupBox2.Controls.Add(Me.txtPayLine)
        Me.GroupBox2.Controls.Add(Me.txtRemaindLine)
        Me.GroupBox2.Controls.Add(Me.txtRate)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtVND)
        Me.GroupBox2.Controls.Add(Me.txtPay)
        Me.GroupBox2.Controls.Add(Me.cboCurrency)
        Me.GroupBox2.Controls.Add(Me.txtRemaind)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Location = New System.Drawing.Point(317, 252)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(607, 134)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payment"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.ForeColor = System.Drawing.Color.Maroon
        Me.Label24.Location = New System.Drawing.Point(524, 479)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(88, 13)
        Me.Label24.TabIndex = 33
        Me.Label24.Text = "Get O.Bill Name :"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.ForeColor = System.Drawing.Color.Maroon
        Me.Label25.Location = New System.Drawing.Point(525, 460)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(87, 13)
        Me.Label25.TabIndex = 32
        Me.Label25.Text = "Get O.Bill (date) :"
        '
        'txtGetBillName
        '
        Me.txtGetBillName.Location = New System.Drawing.Point(614, 476)
        Me.txtGetBillName.Name = "txtGetBillName"
        Me.txtGetBillName.Size = New System.Drawing.Size(204, 20)
        Me.txtGetBillName.TabIndex = 31
        '
        'dtpGetBillDate
        '
        Me.dtpGetBillDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpGetBillDate.Location = New System.Drawing.Point(614, 456)
        Me.dtpGetBillDate.Name = "dtpGetBillDate"
        Me.dtpGetBillDate.Size = New System.Drawing.Size(101, 20)
        Me.dtpGetBillDate.TabIndex = 30
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.ForeColor = System.Drawing.Color.Maroon
        Me.Label23.Location = New System.Drawing.Point(541, 432)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 13)
        Me.Label23.TabIndex = 26
        Me.Label23.Text = "Payer Name :"
        '
        'txtPayerName
        '
        Me.txtPayerName.Location = New System.Drawing.Point(614, 429)
        Me.txtPayerName.Name = "txtPayerName"
        Me.txtPayerName.Size = New System.Drawing.Size(204, 20)
        Me.txtPayerName.TabIndex = 29
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtBL_NO)
        Me.GroupBox3.Controls.Add(Me.txtReceiptNo)
        Me.GroupBox3.Controls.Add(Me.txtContainer)
        Me.GroupBox3.Controls.Add(Me.txtCustomer)
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Location = New System.Drawing.Point(317, 65)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(605, 100)
        Me.GroupBox3.TabIndex = 32
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Bill (Infomation)"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtBookingPrepaidCurrency)
        Me.GroupBox5.Controls.Add(Me.txtBookingPrePaidFee)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.txtBookingCollectFee)
        Me.GroupBox5.Controls.Add(Me.txtBookingCollectCurrency)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox5.Location = New System.Drawing.Point(640, 172)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(284, 74)
        Me.GroupBox5.TabIndex = 41
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Container Fee (Sale)"
        '
        'txtBookingPrepaidCurrency
        '
        Me.txtBookingPrepaidCurrency.Location = New System.Drawing.Point(178, 19)
        Me.txtBookingPrepaidCurrency.Name = "txtBookingPrepaidCurrency"
        Me.txtBookingPrepaidCurrency.Size = New System.Drawing.Size(80, 20)
        Me.txtBookingPrepaidCurrency.TabIndex = 31
        '
        'txtBookingPrePaidFee
        '
        Me.txtBookingPrePaidFee.Location = New System.Drawing.Point(86, 19)
        Me.txtBookingPrePaidFee.Name = "txtBookingPrePaidFee"
        Me.txtBookingPrePaidFee.Size = New System.Drawing.Size(84, 20)
        Me.txtBookingPrePaidFee.TabIndex = 6
        Me.txtBookingPrePaidFee.Text = "0"
        Me.txtBookingPrePaidFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.Maroon
        Me.Label18.Location = New System.Drawing.Point(18, 49)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "Collect Fee :"
        '
        'txtBookingCollectFee
        '
        Me.txtBookingCollectFee.Location = New System.Drawing.Point(86, 45)
        Me.txtBookingCollectFee.Name = "txtBookingCollectFee"
        Me.txtBookingCollectFee.Size = New System.Drawing.Size(83, 20)
        Me.txtBookingCollectFee.TabIndex = 8
        Me.txtBookingCollectFee.Text = "0"
        Me.txtBookingCollectFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBookingCollectCurrency
        '
        Me.txtBookingCollectCurrency.Location = New System.Drawing.Point(178, 45)
        Me.txtBookingCollectCurrency.Name = "txtBookingCollectCurrency"
        Me.txtBookingCollectCurrency.Size = New System.Drawing.Size(80, 20)
        Me.txtBookingCollectCurrency.TabIndex = 31
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.ForeColor = System.Drawing.Color.Maroon
        Me.Label19.Location = New System.Drawing.Point(14, 22)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(70, 13)
        Me.Label19.TabIndex = 4
        Me.Label19.Text = "Prepaid Fee :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuExport, Me.smnuDateOfIssue})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(935, 24)
        Me.MenuStrip1.TabIndex = 43
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Navy
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuExport
        '
        Me.smnuExport.ForeColor = System.Drawing.Color.Navy
        Me.smnuExport.Name = "smnuExport"
        Me.smnuExport.Size = New System.Drawing.Size(51, 20)
        Me.smnuExport.Text = "Export"
        '
        'smnuDateOfIssue
        '
        Me.smnuDateOfIssue.ForeColor = System.Drawing.Color.Navy
        Me.smnuDateOfIssue.Name = "smnuDateOfIssue"
        Me.smnuDateOfIssue.Size = New System.Drawing.Size(86, 20)
        Me.smnuDateOfIssue.Text = "Date Of Issue"
        '
        'grpIssue
        '
        Me.grpIssue.BackColor = System.Drawing.Color.SeaShell
        Me.grpIssue.Controls.Add(Me.cmdCancelIssue)
        Me.grpIssue.Controls.Add(Me.cmdOKIssue)
        Me.grpIssue.Controls.Add(Me.dtpIssueTo)
        Me.grpIssue.Controls.Add(Me.Label16)
        Me.grpIssue.Controls.Add(Me.dtpIssueFrom)
        Me.grpIssue.Controls.Add(Me.Label15)
        Me.grpIssue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.grpIssue.Location = New System.Drawing.Point(382, 52)
        Me.grpIssue.Name = "grpIssue"
        Me.grpIssue.Size = New System.Drawing.Size(313, 100)
        Me.grpIssue.TabIndex = 44
        Me.grpIssue.TabStop = False
        Me.grpIssue.Text = "Search Date Of Issue"
        Me.grpIssue.Visible = False
        '
        'cmdCancelIssue
        '
        Me.cmdCancelIssue.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.cmdCancelIssue.ForeColor = System.Drawing.Color.Navy
        Me.cmdCancelIssue.Location = New System.Drawing.Point(172, 63)
        Me.cmdCancelIssue.Name = "cmdCancelIssue"
        Me.cmdCancelIssue.Size = New System.Drawing.Size(61, 23)
        Me.cmdCancelIssue.TabIndex = 37
        Me.cmdCancelIssue.Text = "Cancel"
        Me.cmdCancelIssue.UseVisualStyleBackColor = False
        '
        'cmdOKIssue
        '
        Me.cmdOKIssue.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.cmdOKIssue.ForeColor = System.Drawing.Color.Navy
        Me.cmdOKIssue.Location = New System.Drawing.Point(79, 63)
        Me.cmdOKIssue.Name = "cmdOKIssue"
        Me.cmdOKIssue.Size = New System.Drawing.Size(61, 23)
        Me.cmdOKIssue.TabIndex = 37
        Me.cmdOKIssue.Text = "OK"
        Me.cmdOKIssue.UseVisualStyleBackColor = False
        '
        'dtpIssueTo
        '
        Me.dtpIssueTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIssueTo.Location = New System.Drawing.Point(196, 24)
        Me.dtpIssueTo.Name = "dtpIssueTo"
        Me.dtpIssueTo.Size = New System.Drawing.Size(99, 20)
        Me.dtpIssueTo.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.Maroon
        Me.Label16.Location = New System.Drawing.Point(169, 27)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(26, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "To :"
        '
        'dtpIssueFrom
        '
        Me.dtpIssueFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpIssueFrom.Location = New System.Drawing.Point(53, 25)
        Me.dtpIssueFrom.Name = "dtpIssueFrom"
        Me.dtpIssueFrom.Size = New System.Drawing.Size(99, 20)
        Me.dtpIssueFrom.TabIndex = 35
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(15, 28)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 36
        Me.Label15.Text = "From :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.ForeColor = System.Drawing.Color.Navy
        Me.Label26.Location = New System.Drawing.Point(444, 79)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(36, 13)
        Me.Label26.TabIndex = 31
        Me.Label26.Text = "VND :"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.ForeColor = System.Drawing.Color.Navy
        Me.Label27.Location = New System.Drawing.Point(418, 58)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(62, 13)
        Me.Label27.TabIndex = 30
        Me.Label27.Text = "Pay (Lines):"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.ForeColor = System.Drawing.Color.Navy
        Me.Label28.Location = New System.Drawing.Point(430, 99)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(49, 13)
        Me.Label28.TabIndex = 29
        Me.Label28.Text = "Remain :"
        Me.ToolTip1.SetToolTip(Me.Label28, "Số tiền còn lại ")
        '
        'txtVNDLine
        '
        Me.txtVNDLine.AcceptsReturn = True
        Me.txtVNDLine.ForeColor = System.Drawing.Color.Navy
        Me.txtVNDLine.Location = New System.Drawing.Point(482, 76)
        Me.txtVNDLine.Name = "txtVNDLine"
        Me.txtVNDLine.Size = New System.Drawing.Size(102, 20)
        Me.txtVNDLine.TabIndex = 33
        Me.txtVNDLine.Text = "0"
        Me.txtVNDLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPayLine
        '
        Me.txtPayLine.ForeColor = System.Drawing.Color.Navy
        Me.txtPayLine.Location = New System.Drawing.Point(482, 55)
        Me.txtPayLine.Name = "txtPayLine"
        Me.txtPayLine.Size = New System.Drawing.Size(102, 20)
        Me.txtPayLine.TabIndex = 32
        Me.txtPayLine.Text = "0"
        Me.txtPayLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtRemaindLine
        '
        Me.txtRemaindLine.ForeColor = System.Drawing.Color.Navy
        Me.txtRemaindLine.Location = New System.Drawing.Point(482, 96)
        Me.txtRemaindLine.Name = "txtRemaindLine"
        Me.txtRemaindLine.Size = New System.Drawing.Size(102, 20)
        Me.txtRemaindLine.TabIndex = 34
        Me.txtRemaindLine.Text = "0"
        Me.txtRemaindLine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtBookingPrepaidCurrencyBuy)
        Me.GroupBox4.Controls.Add(Me.txtBookingPrePaidFeeBuy)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Controls.Add(Me.TextBox6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox4.Location = New System.Drawing.Point(317, 172)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(284, 74)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Container Fee (Buy)"
        '
        'txtBookingPrepaidCurrencyBuy
        '
        Me.txtBookingPrepaidCurrencyBuy.Location = New System.Drawing.Point(178, 19)
        Me.txtBookingPrepaidCurrencyBuy.Name = "txtBookingPrepaidCurrencyBuy"
        Me.txtBookingPrepaidCurrencyBuy.Size = New System.Drawing.Size(80, 20)
        Me.txtBookingPrepaidCurrencyBuy.TabIndex = 31
        '
        'txtBookingPrePaidFeeBuy
        '
        Me.txtBookingPrePaidFeeBuy.Location = New System.Drawing.Point(86, 19)
        Me.txtBookingPrePaidFeeBuy.Name = "txtBookingPrePaidFeeBuy"
        Me.txtBookingPrePaidFeeBuy.Size = New System.Drawing.Size(84, 20)
        Me.txtBookingPrePaidFeeBuy.TabIndex = 6
        Me.txtBookingPrePaidFeeBuy.Text = "0"
        Me.txtBookingPrePaidFeeBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(18, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Collect Fee :"
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(86, 45)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(83, 20)
        Me.TextBox5.TabIndex = 8
        Me.TextBox5.Text = "0"
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(178, 45)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(80, 20)
        Me.TextBox6.TabIndex = 31
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Prepaid Fee :"
        '
        'frmPayMent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 516)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.grpIssue)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.txtGetBillName)
        Me.Controls.Add(Me.dtpGetBillDate)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtBLNOSearch)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dtpPayDate)
        Me.Controls.Add(Me.txtPayerName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lvBL_NO)
        Me.Controls.Add(Me.Label14)
        Me.MaximizeBox = False
        Me.Name = "frmPayMent"
        Me.Text = "Payment"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpIssue.ResumeLayout(False)
        Me.grpIssue.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtBL_NO As System.Windows.Forms.TextBox
    Friend WithEvents txtVND As System.Windows.Forms.TextBox
    Friend WithEvents txtPay As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txtContainer As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lvBL_NO As System.Windows.Forms.ListBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtBLNOSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRemaind As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtUpdateTime As System.Windows.Forms.TextBox
    Friend WithEvents txtUserid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtReceiptNo As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBookingPrepaidCurrency As System.Windows.Forms.TextBox
    Friend WithEvents txtBookingPrePaidFee As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtBookingCollectFee As System.Windows.Forms.TextBox
    Friend WithEvents txtBookingCollectCurrency As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpIssue As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelIssue As System.Windows.Forms.Button
    Friend WithEvents cmdOKIssue As System.Windows.Forms.Button
    Friend WithEvents dtpIssueTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtpIssueFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtPayerName As System.Windows.Forms.TextBox
    Friend WithEvents smnuDateOfIssue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtGetBillName As System.Windows.Forms.TextBox
    Friend WithEvents dtpGetBillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents txtVNDLine As System.Windows.Forms.TextBox
    Friend WithEvents txtPayLine As System.Windows.Forms.TextBox
    Friend WithEvents txtRemaindLine As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtBookingPrepaidCurrencyBuy As System.Windows.Forms.TextBox
    Friend WithEvents txtBookingPrePaidFeeBuy As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
