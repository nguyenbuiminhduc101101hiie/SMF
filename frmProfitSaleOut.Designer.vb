<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProfitSaleOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfitSaleOut))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.VewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSale = New System.Windows.Forms.TextBox
        Me.chkSale = New System.Windows.Forms.CheckBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOKBill = New System.Windows.Forms.Button
        Me.txtBillNo = New System.Windows.Forms.TextBox
        Me.cmdexcel = New System.Windows.Forms.Button
        Me.dgData = New System.Windows.Forms.DataGridView
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.shipper = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Consignee = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DebitNoteNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ORG = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DES = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KGS = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CBM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dc20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RF20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dc40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HQ40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.hc40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RH40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Expense = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Income = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Profit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Profitagent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BKKCOMM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.agent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Handledby = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MBL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HBL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dtpToETD = New System.Windows.Forms.DateTimePicker
        Me.dtpFromETD = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VewToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 26)
        '
        'VewToolStripMenuItem
        '
        Me.VewToolStripMenuItem.Name = "VewToolStripMenuItem"
        Me.VewToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.VewToolStripMenuItem.Text = "View Details"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(290, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Sale Code :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSale)
        Me.GroupBox2.Controls.Add(Me.chkSale)
        Me.GroupBox2.Location = New System.Drawing.Point(354, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(147, 34)
        Me.GroupBox2.TabIndex = 131
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
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdOKBill)
        Me.GroupBox1.Controls.Add(Me.txtBillNo)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(278, 75)
        Me.GroupBox1.TabIndex = 130
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "MBL/MAWB :"
        '
        'cmdOKBill
        '
        Me.cmdOKBill.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOKBill.Location = New System.Drawing.Point(197, 41)
        Me.cmdOKBill.Name = "cmdOKBill"
        Me.cmdOKBill.Size = New System.Drawing.Size(75, 23)
        Me.cmdOKBill.TabIndex = 111
        Me.cmdOKBill.Text = "&Ok"
        Me.cmdOKBill.UseVisualStyleBackColor = True
        '
        'txtBillNo
        '
        Me.txtBillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBillNo.Location = New System.Drawing.Point(6, 41)
        Me.txtBillNo.Name = "txtBillNo"
        Me.txtBillNo.Size = New System.Drawing.Size(185, 24)
        Me.txtBillNo.TabIndex = 0
        '
        'cmdexcel
        '
        Me.cmdexcel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdexcel.Location = New System.Drawing.Point(688, 61)
        Me.cmdexcel.Name = "cmdexcel"
        Me.cmdexcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdexcel.TabIndex = 129
        Me.cmdexcel.Text = "&Export xls."
        Me.cmdexcel.UseVisualStyleBackColor = True
        '
        'dgData
        '
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.shipper, Me.Consignee, Me.DebitNoteNo, Me.Ref, Me.ORG, Me.DES, Me.KGS, Me.CBM, Me.dc20, Me.RF20, Me.dc40, Me.HQ40, Me.hc40, Me.RH40, Me.Expense, Me.Income, Me.Profit, Me.Profitagent, Me.NP, Me.BKKCOMM, Me.agent, Me.ETD, Me.ETA, Me.Handledby, Me.MBL, Me.HBL})
        Me.dgData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgData.Location = New System.Drawing.Point(6, 93)
        Me.dgData.Name = "dgData"
        Me.dgData.Size = New System.Drawing.Size(1135, 438)
        Me.dgData.TabIndex = 128
        '
        'No
        '
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        '
        'shipper
        '
        Me.shipper.HeaderText = "Shipper"
        Me.shipper.Name = "shipper"
        '
        'Consignee
        '
        Me.Consignee.HeaderText = "Consignee"
        Me.Consignee.Name = "Consignee"
        '
        'DebitNoteNo
        '
        Me.DebitNoteNo.HeaderText = "Debit Note No."
        Me.DebitNoteNo.Name = "DebitNoteNo"
        '
        'Ref
        '
        Me.Ref.HeaderText = "Lot No./Ref"
        Me.Ref.Name = "Ref"
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
        'KGS
        '
        Me.KGS.HeaderText = "KGS"
        Me.KGS.Name = "KGS"
        '
        'CBM
        '
        Me.CBM.HeaderText = "CBM"
        Me.CBM.Name = "CBM"
        '
        'dc20
        '
        Me.dc20.HeaderText = "20DC"
        Me.dc20.Name = "dc20"
        '
        'RF20
        '
        Me.RF20.HeaderText = "20RF"
        Me.RF20.Name = "RF20"
        '
        'dc40
        '
        Me.dc40.HeaderText = "40DC"
        Me.dc40.Name = "dc40"
        '
        'HQ40
        '
        Me.HQ40.HeaderText = "40HQ"
        Me.HQ40.Name = "HQ40"
        '
        'hc40
        '
        Me.hc40.HeaderText = "40HC"
        Me.hc40.Name = "hc40"
        '
        'RH40
        '
        Me.RH40.HeaderText = "40RH"
        Me.RH40.Name = "RH40"
        '
        'Expense
        '
        Me.Expense.HeaderText = "Expense"
        Me.Expense.Name = "Expense"
        '
        'Income
        '
        Me.Income.HeaderText = "Income"
        Me.Income.Name = "Income"
        '
        'Profit
        '
        Me.Profit.HeaderText = "Profit"
        Me.Profit.Name = "Profit"
        '
        'Profitagent
        '
        Me.Profitagent.HeaderText = "Profit Agent"
        Me.Profitagent.Name = "Profitagent"
        '
        'NP
        '
        Me.NP.HeaderText = "N/P"
        Me.NP.Name = "NP"
        '
        'BKKCOMM
        '
        Me.BKKCOMM.HeaderText = "BKK COMM"
        Me.BKKCOMM.Name = "BKKCOMM"
        '
        'agent
        '
        Me.agent.HeaderText = "Agent"
        Me.agent.Name = "agent"
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
        'Handledby
        '
        Me.Handledby.HeaderText = "Handle By"
        Me.Handledby.Name = "Handledby"
        '
        'MBL
        '
        Me.MBL.HeaderText = "MBL"
        Me.MBL.Name = "MBL"
        '
        'HBL
        '
        Me.HBL.HeaderText = "HBL"
        Me.HBL.Name = "HBL"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(607, 61)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 127
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(526, 61)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 126
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dtpToETD
        '
        Me.dtpToETD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpToETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToETD.Location = New System.Drawing.Point(576, 24)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(187, 24)
        Me.dtpToETD.TabIndex = 125
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFromETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromETD.Location = New System.Drawing.Point(354, 24)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(188, 24)
        Me.dtpFromETD.TabIndex = 124
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(290, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "From(ETD) :"
        '
        'frmProfitSaleOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 543)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdexcel)
        Me.Controls.Add(Me.dgData)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dtpToETD)
        Me.Controls.Add(Me.dtpFromETD)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmProfitSaleOut"
        Me.Text = "Profit Sale (Outbound)"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents VewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents shipper As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consignee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DebitNoteNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ORG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DES As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KGS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CBM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dc20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RF20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dc40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HQ40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hc40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RH40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expense As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Income As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Profitagent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BKKCOMM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents agent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Handledby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpToETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
