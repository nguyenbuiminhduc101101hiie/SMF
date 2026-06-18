<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfitOutbound
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfitOutbound))
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSale = New System.Windows.Forms.TextBox
        Me.chkSale = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.txtLot = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtHBL = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOKBill = New System.Windows.Forms.Button
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.cmdexcel = New System.Windows.Forms.Button
        Me.dgData = New System.Windows.Forms.DataGridView
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ORG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shipper = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.socont = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tongkien = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tongkg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tongkhoi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Consignee = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NameSendPreAlert = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.agent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Term = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.jobno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillCarrier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MBL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HBL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Carrier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesselVoyage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Income = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Expense = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Profit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NetProfit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditNoteNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerCredit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemsCredit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.payCreditVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PayOnDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitNoteNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AmountVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerDebit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ItemsDebit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.payDebitVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CarrierInvoiceNo1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReMarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrgSur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Close_ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dtpToETD = New System.Windows.Forms.DateTimePicker
        Me.dtpFromETD = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.chkFreight = New System.Windows.Forms.CheckBox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(18, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 123
        Me.Label4.Text = "Sale Code :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSale)
        Me.GroupBox2.Controls.Add(Me.chkSale)
        Me.GroupBox2.Location = New System.Drawing.Point(88, 56)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 34)
        Me.GroupBox2.TabIndex = 122
        Me.GroupBox2.TabStop = False
        '
        'txtSale
        '
        Me.txtSale.Location = New System.Drawing.Point(27, 8)
        Me.txtSale.Name = "txtSale"
        Me.txtSale.Size = New System.Drawing.Size(111, 20)
        Me.txtSale.TabIndex = 1
        '
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(6, 11)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(15, 14)
        Me.chkSale.TabIndex = 0
        Me.chkSale.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txtLot)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.txtHBL)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdOKBill)
        Me.GroupBox1.Controls.Add(Me.txtBillNo)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 159)
        Me.GroupBox1.TabIndex = 121
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(5, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 116
        Me.Label6.Text = "Ref No. :"
        '
        'Button2
        '
        Me.Button2.ForeColor = System.Drawing.Color.Maroon
        Me.Button2.Location = New System.Drawing.Point(197, 75)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 117
        Me.Button2.Text = "&Ok"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtLot
        '
        Me.txtLot.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLot.Location = New System.Drawing.Point(5, 123)
        Me.txtLot.Name = "txtLot"
        Me.txtLot.Size = New System.Drawing.Size(185, 24)
        Me.txtLot.TabIndex = 115
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(6, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "HAWB :"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(196, 123)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 114
        Me.Button1.Text = "&Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtHBL
        '
        Me.txtHBL.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHBL.Location = New System.Drawing.Point(6, 75)
        Me.txtHBL.Name = "txtHBL"
        Me.txtHBL.Size = New System.Drawing.Size(185, 24)
        Me.txtHBL.TabIndex = 112
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(6, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "HBL/MAWB :"
        '
        'cmdOKBill
        '
        Me.cmdOKBill.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOKBill.Location = New System.Drawing.Point(197, 30)
        Me.cmdOKBill.Name = "cmdOKBill"
        Me.cmdOKBill.Size = New System.Drawing.Size(75, 23)
        Me.cmdOKBill.TabIndex = 111
        Me.cmdOKBill.Text = "&Ok"
        Me.cmdOKBill.UseVisualStyleBackColor = True
        '
        'txtBillNo
        '
        Me.txtBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNo.Location = New System.Drawing.Point(6, 30)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(185, 24)
        Me.txtBillNo.TabIndex = 0
        '
        'cmdexcel
        '
        Me.cmdexcel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdexcel.Location = New System.Drawing.Point(422, 53)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdexcel.TabIndex = 120
        Me.cmdexcel.Text = "&Export xls."
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'dgData
        '
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.ETD, Me.ETA, Me.ORG, Me.DES, Me.shipper, Me.socont, Me.tongkien, Me.tongkg, Me.tongkhoi, Me.Consignee, Me.NameSendPreAlert, Me.agent, Me.Term, Me.Ref, Me.jobno, Me.BillCarrier, Me.MBL, Me.HBL, Me.Carrier, Me.VesselVoyage, Me.Income, Me.Expense, Me.Profit, Me.NetProfit, Me.CreditNoteNo, Me.CustomerCredit, Me.ItemsCredit, Me.payCreditVND, Me.PayOnDate, Me.DebitNoteNo, Me.AmountVND, Me.CustomerDebit, Me.ItemsDebit, Me.payDebitVND, Me.CarrierInvoiceNo1, Me.ReMarks, Me.OrgSur, Me.Close_})
        Me.dgData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgData.Location = New System.Drawing.Point(7, 173)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(1001, 306)
        Me.dgData.TabIndex = 119
        '
        'No
        '
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        '
        'ETD
        '
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        '
        'ETA
        '
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        '
        'ORG
        '
        Me.ORG.HeaderText = "ORG"
        Me.ORG.Name = "ORG"
        '
        'DES
        '
        Me.DES.HeaderText = "DES"
        Me.DES.Name = "DES"
        '
        'shipper
        '
        Me.shipper.HeaderText = "Shipper"
        Me.shipper.Name = "shipper"
        '
        'socont
        '
        Me.socont.HeaderText = "Container"
        Me.socont.Name = "socont"
        '
        'tongkien
        '
        Me.tongkien.HeaderText = "Package"
        Me.tongkien.Name = "tongkien"
        '
        'tongkg
        '
        Me.tongkg.HeaderText = "Volumn"
        Me.tongkg.Name = "tongkg"
        '
        'tongkhoi
        '
        Me.tongkhoi.HeaderText = "Meas"
        Me.tongkhoi.Name = "tongkhoi"
        '
        'Consignee
        '
        Me.Consignee.HeaderText = "Consignee"
        Me.Consignee.Name = "Consignee"
        '
        'NameSendPreAlert
        '
        Me.NameSendPreAlert.HeaderText = "Name send pre-alert"
        Me.NameSendPreAlert.Name = "NameSendPreAlert"
        '
        'agent
        '
        Me.agent.HeaderText = "Agent"
        Me.agent.Name = "agent"
        '
        'Term
        '
        Me.Term.HeaderText = "Term"
        Me.Term.Name = "Term"
        '
        'Ref
        '
        Me.Ref.HeaderText = "Lot No./Ref"
        Me.Ref.Name = "Ref"
        '
        'jobno
        '
        Me.jobno.HeaderText = "Job No."
        Me.jobno.Name = "jobno"
        '
        'BillCarrier
        '
        Me.BillCarrier.HeaderText = "Bill (Carrier)"
        Me.BillCarrier.Name = "BillCarrier"
        '
        'MBL
        '
        Me.MBL.HeaderText = "HBL"
        Me.MBL.Name = "MBL"
        '
        'HBL
        '
        Me.HBL.HeaderText = "HAWB"
        Me.HBL.Name = "HBL"
        '
        'Carrier
        '
        Me.Carrier.HeaderText = "Carrier"
        Me.Carrier.Name = "Carrier"
        '
        'VesselVoyage
        '
        Me.VesselVoyage.HeaderText = "Vessel Name/ Voyage"
        Me.VesselVoyage.Name = "VesselVoyage"
        '
        'Income
        '
        Me.Income.HeaderText = "Income"
        Me.Income.Name = "Income"
        '
        'Expense
        '
        Me.Expense.HeaderText = "Expense"
        Me.Expense.Name = "Expense"
        '
        'Profit
        '
        Me.Profit.HeaderText = "Profit"
        Me.Profit.Name = "Profit"
        '
        'NetProfit
        '
        Me.NetProfit.HeaderText = "Net Profit"
        Me.NetProfit.Name = "NetProfit"
        Me.NetProfit.Visible = False
        '
        'CreditNoteNo
        '
        Me.CreditNoteNo.HeaderText = "Credit Note No."
        Me.CreditNoteNo.Name = "CreditNoteNo"
        '
        'CustomerCredit
        '
        Me.CustomerCredit.HeaderText = "Customer (Credit)"
        Me.CustomerCredit.Name = "CustomerCredit"
        '
        'ItemsCredit
        '
        Me.ItemsCredit.HeaderText = "Items (Credit)"
        Me.ItemsCredit.Name = "ItemsCredit"
        '
        'payCreditVND
        '
        Me.payCreditVND.HeaderText = "pay Credit VND"
        Me.payCreditVND.Name = "payCreditVND"
        '
        'PayOnDate
        '
        Me.PayOnDate.HeaderText = "Pay On (Date)"
        Me.PayOnDate.Name = "PayOnDate"
        '
        'DebitNoteNo
        '
        Me.DebitNoteNo.HeaderText = "Debit Note No."
        Me.DebitNoteNo.Name = "DebitNoteNo"
        '
        'AmountVND
        '
        Me.AmountVND.HeaderText = "Amount (VND)"
        Me.AmountVND.Name = "AmountVND"
        '
        'CustomerDebit
        '
        Me.CustomerDebit.HeaderText = "Customer (Debit)"
        Me.CustomerDebit.Name = "CustomerDebit"
        '
        'ItemsDebit
        '
        Me.ItemsDebit.HeaderText = "Items (Debit)"
        Me.ItemsDebit.Name = "ItemsDebit"
        '
        'payDebitVND
        '
        Me.payDebitVND.HeaderText = "pay Debit VND"
        Me.payDebitVND.Name = "payDebitVND"
        '
        'CarrierInvoiceNo1
        '
        Me.CarrierInvoiceNo1.HeaderText = "Carrier Invoice No."
        Me.CarrierInvoiceNo1.Name = "CarrierInvoiceNo1"
        '
        'ReMarks
        '
        Me.ReMarks.HeaderText = "Note (freight)"
        Me.ReMarks.Name = "ReMarks"
        '
        'OrgSur
        '
        Me.OrgSur.HeaderText = "Org/Sur"
        Me.OrgSur.Name = "OrgSur"
        '
        'Close_
        '
        Me.Close_.HeaderText = "Close"
        Me.Close_.Name = "Close_"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 26)
        '
        'VewToolStripMenuItem
        '
        Me.VewToolStripMenuItem.Name = "VewToolStripMenuItem"
        Me.VewToolStripMenuItem.Size = New System.Drawing.Size(137, 22)
        Me.VewToolStripMenuItem.Text = "View Details"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(341, 53)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 118
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(260, 53)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 117
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dtpToETD
        '
        Me.dtpToETD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToETD.Location = New System.Drawing.Point(310, 27)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(187, 24)
        Me.dtpToETD.TabIndex = 116
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromETD.Location = New System.Drawing.Point(88, 27)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(188, 24)
        Me.dtpFromETD.TabIndex = 115
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(18, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "From(ETD) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(282, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "To :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdOk)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.dtpFromETD)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.dtpToETD)
        Me.GroupBox3.Controls.Add(Me.cmdCancel)
        Me.GroupBox3.Controls.Add(Me.GroupBox2)
        Me.GroupBox3.Controls.Add(Me.cmdexcel)
        Me.GroupBox3.Location = New System.Drawing.Point(305, 13)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(514, 104)
        Me.GroupBox3.TabIndex = 127
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "from...to..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(312, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Show Freight :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkFreight)
        Me.GroupBox4.Location = New System.Drawing.Point(393, 123)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(32, 34)
        Me.GroupBox4.TabIndex = 128
        Me.GroupBox4.TabStop = False
        '
        'chkFreight
        '
        Me.chkFreight.AutoSize = True
        Me.chkFreight.Location = New System.Drawing.Point(6, 11)
        Me.chkFreight.Name = "chkFreight"
        Me.chkFreight.Size = New System.Drawing.Size(15, 14)
        Me.chkFreight.TabIndex = 0
        Me.chkFreight.UseVisualStyleBackColor = True
        '
        'frmProfitOutbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 491)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgData)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProfitOutbound"
        Me.Text = "General "
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSale As System.Windows.Forms.TextBox
    Friend WithEvents chkSale As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdOKBill As System.Windows.Forms.Button
    Friend WithEvents txtBillNo As System.Windows.Forms.TextBox
    Friend WithEvents cmdexcel As System.Windows.Forms.Button
    Friend WithEvents dgData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpToETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtLot As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtHBL As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shipper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents socont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tongkien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tongkg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tongkhoi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consignee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NameSendPreAlert As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents agent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Term As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents jobno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillCarrier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carrier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselVoyage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Income As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expense As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NetProfit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditNoteNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemsCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents payCreditVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PayOnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitNoteNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AmountVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemsDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents payDebitVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CarrierInvoiceNo1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReMarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrgSur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Close_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFreight As System.Windows.Forms.CheckBox
End Class
