<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpress_Quotation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpress_Quotation))
        Me.cboCode1 = New System.Windows.Forms.ComboBox
        Me.cmdOK1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgdview1 = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgdCus = New System.Windows.Forms.DataGridView
        Me.CheckPrint = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.customerid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.customercode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboDK = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtvalue = New System.Windows.Forms.TextBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.dgdQuotation = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cusid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.checkIn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.companyQ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.proposal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Salecode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CodeSelling = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.cmdSelectAll = New System.Windows.Forms.Button
        Me.cmdUnAll = New System.Windows.Forms.Button
        Me.cbosale = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdDelete = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.WEIGHT1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.A1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.B1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.C1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.D1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.E1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.F1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.G1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.H1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.I1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.J1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.K1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.L1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.M1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.N1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.O1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.P1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Q1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.R1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.S1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.T1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.U1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.V1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdCus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdQuotation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboCode1
        '
        Me.cboCode1.FormattingEnabled = True
        Me.cboCode1.Location = New System.Drawing.Point(132, 12)
        Me.cboCode1.Name = "cboCode1"
        Me.cboCode1.Size = New System.Drawing.Size(280, 21)
        Me.cboCode1.TabIndex = 364
        '
        'cmdOK1
        '
        Me.cmdOK1.Location = New System.Drawing.Point(423, 10)
        Me.cmdOK1.Name = "cmdOK1"
        Me.cmdOK1.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK1.TabIndex = 363
        Me.cmdOK1.Text = "View"
        Me.cmdOK1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(30, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 362
        Me.Label1.Text = "Code (Selling):"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgdview1
        '
        Me.dgdview1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgdview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdview1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.WEIGHT1, Me.A1, Me.B1, Me.C1, Me.D1, Me.E1, Me.F1, Me.G1, Me.H1, Me.I1, Me.J1, Me.K1, Me.L1, Me.M1, Me.N1, Me.O1, Me.P1, Me.Q1, Me.R1, Me.S1, Me.T1, Me.U1, Me.V1, Me.Note})
        Me.dgdview1.Location = New System.Drawing.Point(18, 53)
        Me.dgdview1.Name = "dgdview1"
        Me.dgdview1.Size = New System.Drawing.Size(523, 451)
        Me.dgdview1.TabIndex = 361
        '
        'Button1
        '
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(774, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 21)
        Me.Button1.TabIndex = 365
        Me.Button1.Text = "&Select"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgdCus
        '
        Me.dgdCus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgdCus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CheckPrint, Me.customerid, Me.company, Me.customercode})
        Me.dgdCus.Location = New System.Drawing.Point(557, 91)
        Me.dgdCus.Name = "dgdCus"
        Me.dgdCus.Size = New System.Drawing.Size(298, 413)
        Me.dgdCus.TabIndex = 366
        '
        'CheckPrint
        '
        Me.CheckPrint.HeaderText = "Check"
        Me.CheckPrint.Name = "CheckPrint"
        Me.CheckPrint.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CheckPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CheckPrint.Width = 50
        '
        'customerid
        '
        Me.customerid.HeaderText = "customerid"
        Me.customerid.Name = "customerid"
        Me.customerid.Visible = False
        '
        'company
        '
        Me.company.DataPropertyName = "company"
        Me.company.HeaderText = "Company"
        Me.company.Name = "company"
        '
        'customercode
        '
        Me.customercode.HeaderText = "Cus. Code"
        Me.customercode.Name = "customercode"
        '
        'cboDK
        '
        Me.cboDK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDK.FormattingEnabled = True
        Me.cboDK.Items.AddRange(New Object() {"Company", "Salename", "Customer_code", "Maincode", "VIPcode"})
        Me.cboDK.Location = New System.Drawing.Point(611, 13)
        Me.cboDK.Name = "cboDK"
        Me.cboDK.Size = New System.Drawing.Size(157, 21)
        Me.cboDK.TabIndex = 367
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(559, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 369
        Me.Label2.Text = "Items :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtvalue
        '
        Me.txtvalue.Location = New System.Drawing.Point(611, 38)
        Me.txtvalue.Name = "txtvalue"
        Me.txtvalue.Size = New System.Drawing.Size(157, 20)
        Me.txtvalue.TabIndex = 370
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(774, 35)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(49, 23)
        Me.cmdSearch.TabIndex = 371
        Me.cmdSearch.Text = "Find"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'dgdQuotation
        '
        Me.dgdQuotation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdQuotation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdQuotation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.cusid, Me.checkIn, Me.companyQ, Me.proposal, Me.Salecode, Me.CodeSelling})
        Me.dgdQuotation.Location = New System.Drawing.Point(861, 91)
        Me.dgdQuotation.Name = "dgdQuotation"
        Me.dgdQuotation.Size = New System.Drawing.Size(298, 413)
        Me.dgdQuotation.TabIndex = 372
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'cusid
        '
        Me.cusid.DataPropertyName = "customerid"
        Me.cusid.HeaderText = "customerid"
        Me.cusid.Name = "cusid"
        Me.cusid.Visible = False
        '
        'checkIn
        '
        Me.checkIn.HeaderText = "Check"
        Me.checkIn.Name = "checkIn"
        Me.checkIn.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.checkIn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'companyQ
        '
        Me.companyQ.DataPropertyName = "company"
        Me.companyQ.HeaderText = "Company"
        Me.companyQ.Name = "companyQ"
        '
        'proposal
        '
        Me.proposal.DataPropertyName = "proposal"
        Me.proposal.HeaderText = "Proposal"
        Me.proposal.Name = "proposal"
        '
        'Salecode
        '
        Me.Salecode.DataPropertyName = "Salecode"
        Me.Salecode.HeaderText = "Sale Code"
        Me.Salecode.Name = "Salecode"
        '
        'CodeSelling
        '
        Me.CodeSelling.DataPropertyName = "CodeSelling"
        Me.CodeSelling.HeaderText = "Code selling"
        Me.CodeSelling.Name = "CodeSelling"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(559, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 16)
        Me.Label3.TabIndex = 373
        Me.Label3.Text = "Value :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCode.ForeColor = System.Drawing.Color.Navy
        Me.lblCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCode.Location = New System.Drawing.Point(858, 43)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(17, 16)
        Me.lblCode.TabIndex = 374
        Me.lblCode.Text = "..."
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.Location = New System.Drawing.Point(557, 62)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(40, 23)
        Me.cmdSelectAll.TabIndex = 375
        Me.cmdSelectAll.Text = "All..."
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdUnAll
        '
        Me.cmdUnAll.Location = New System.Drawing.Point(603, 62)
        Me.cmdUnAll.Name = "cmdUnAll"
        Me.cmdUnAll.Size = New System.Drawing.Size(40, 23)
        Me.cmdUnAll.TabIndex = 376
        Me.cmdUnAll.Text = "U. All"
        Me.cmdUnAll.UseVisualStyleBackColor = True
        '
        'cbosale
        '
        Me.cbosale.FormattingEnabled = True
        Me.cbosale.Location = New System.Drawing.Point(907, 14)
        Me.cbosale.Name = "cbosale"
        Me.cbosale.Size = New System.Drawing.Size(121, 21)
        Me.cbosale.TabIndex = 377
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(855, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 378
        Me.Label4.Text = "Sale :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdDelete
        '
        Me.cmdDelete.Location = New System.Drawing.Point(861, 62)
        Me.cmdDelete.Name = "cmdDelete"
        Me.cmdDelete.Size = New System.Drawing.Size(46, 23)
        Me.cmdDelete.TabIndex = 379
        Me.cmdDelete.Text = "Delete"
        Me.cmdDelete.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(913, 62)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 380
        Me.Button2.Text = "Export .xls"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(994, 62)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 381
        Me.Button3.Text = "Print"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'WEIGHT1
        '
        Me.WEIGHT1.HeaderText = "WEIGHT"
        Me.WEIGHT1.Name = "WEIGHT1"
        Me.WEIGHT1.Width = 70
        '
        'A1
        '
        Me.A1.DataPropertyName = "A"
        Me.A1.HeaderText = "A"
        Me.A1.Name = "A1"
        Me.A1.Width = 50
        '
        'B1
        '
        Me.B1.DataPropertyName = "B"
        Me.B1.HeaderText = "B"
        Me.B1.Name = "B1"
        Me.B1.Width = 50
        '
        'C1
        '
        Me.C1.DataPropertyName = "C"
        Me.C1.HeaderText = "C"
        Me.C1.Name = "C1"
        Me.C1.Width = 50
        '
        'D1
        '
        Me.D1.DataPropertyName = "D"
        Me.D1.HeaderText = "D"
        Me.D1.Name = "D1"
        Me.D1.Width = 50
        '
        'E1
        '
        Me.E1.DataPropertyName = "E"
        Me.E1.HeaderText = "E"
        Me.E1.Name = "E1"
        Me.E1.Width = 50
        '
        'F1
        '
        Me.F1.DataPropertyName = "F"
        Me.F1.HeaderText = "F"
        Me.F1.Name = "F1"
        Me.F1.Width = 50
        '
        'G1
        '
        Me.G1.DataPropertyName = "G"
        Me.G1.HeaderText = "G"
        Me.G1.Name = "G1"
        Me.G1.Width = 50
        '
        'H1
        '
        Me.H1.DataPropertyName = "H"
        Me.H1.HeaderText = "H"
        Me.H1.Name = "H1"
        Me.H1.Width = 50
        '
        'I1
        '
        Me.I1.DataPropertyName = "I"
        Me.I1.HeaderText = "I"
        Me.I1.Name = "I1"
        '
        'J1
        '
        Me.J1.DataPropertyName = "J"
        Me.J1.HeaderText = "J"
        Me.J1.Name = "J1"
        '
        'K1
        '
        Me.K1.DataPropertyName = "k"
        Me.K1.HeaderText = "k"
        Me.K1.Name = "K1"
        '
        'L1
        '
        Me.L1.DataPropertyName = "l"
        Me.L1.HeaderText = "L"
        Me.L1.Name = "L1"
        '
        'M1
        '
        Me.M1.DataPropertyName = "m"
        Me.M1.HeaderText = "M"
        Me.M1.Name = "M1"
        '
        'N1
        '
        Me.N1.DataPropertyName = "n"
        Me.N1.HeaderText = "N"
        Me.N1.Name = "N1"
        '
        'O1
        '
        Me.O1.DataPropertyName = "o"
        Me.O1.HeaderText = "O"
        Me.O1.Name = "O1"
        '
        'P1
        '
        Me.P1.DataPropertyName = "P"
        Me.P1.HeaderText = "P"
        Me.P1.Name = "P1"
        '
        'Q1
        '
        Me.Q1.DataPropertyName = "Q"
        Me.Q1.HeaderText = "Q"
        Me.Q1.Name = "Q1"
        '
        'R1
        '
        Me.R1.DataPropertyName = "R"
        Me.R1.HeaderText = "R"
        Me.R1.Name = "R1"
        '
        'S1
        '
        Me.S1.DataPropertyName = "S"
        Me.S1.HeaderText = "S"
        Me.S1.Name = "S1"
        '
        'T1
        '
        Me.T1.DataPropertyName = "T"
        Me.T1.HeaderText = "T"
        Me.T1.Name = "T1"
        '
        'U1
        '
        Me.U1.DataPropertyName = "U"
        Me.U1.HeaderText = "U"
        Me.U1.Name = "U1"
        '
        'V1
        '
        Me.V1.DataPropertyName = "V"
        Me.V1.HeaderText = "V"
        Me.V1.Name = "V1"
        '
        'Note
        '
        Me.Note.DataPropertyName = "note"
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        '
        'frmExpress_Quotation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1167, 516)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmdDelete)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbosale)
        Me.Controls.Add(Me.cmdUnAll)
        Me.Controls.Add(Me.cmdSelectAll)
        Me.Controls.Add(Me.lblCode)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgdQuotation)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.txtvalue)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboDK)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgdCus)
        Me.Controls.Add(Me.cboCode1)
        Me.Controls.Add(Me.cmdOK1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgdview1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExpress_Quotation"
        Me.Text = "Express Quotation"
        CType(Me.dgdview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdCus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdQuotation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboCode1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgdview1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgdCus As System.Windows.Forms.DataGridView
    Friend WithEvents cboDK As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtvalue As System.Windows.Forms.TextBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents dgdQuotation As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents cmdUnAll As System.Windows.Forms.Button
    Friend WithEvents CheckPrint As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents customerid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents customercode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cbosale As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdDelete As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cusid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents checkIn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents companyQ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents proposal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Salecode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CodeSelling As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WEIGHT1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents A1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents B1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents C1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents D1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents E1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents G1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents H1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents I1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents J1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents K1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents L1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents M1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents N1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents O1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents P1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Q1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents R1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents S1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents T1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents U1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents V1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Note As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
