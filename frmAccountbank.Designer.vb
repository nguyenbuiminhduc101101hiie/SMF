<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountbank
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fraUpdate = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtAccountNo = New System.Windows.Forms.TextBox()
        Me.lblCode = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.TxtName = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.lblName = New System.Windows.Forms.Label()
        Me.dgdbank = New System.Windows.Forms.DataGridView()
        Me.AccountbankId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangeDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdbank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.txtAccountNo)
        Me.fraUpdate.Controls.Add(Me.lblCode)
        Me.fraUpdate.Controls.Add(Me.txtCode)
        Me.fraUpdate.Controls.Add(Me.TxtName)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.Controls.Add(Me.lblName)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(7, 254)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(689, 115)
        Me.fraUpdate.TabIndex = 45
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(51, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Account :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAccountNo
        '
        Me.txtAccountNo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtAccountNo.ForeColor = System.Drawing.Color.Blue
        Me.txtAccountNo.Location = New System.Drawing.Point(106, 78)
        Me.txtAccountNo.MaxLength = 17
        Me.txtAccountNo.Name = "txtAccountNo"
        Me.txtAccountNo.Size = New System.Drawing.Size(164, 20)
        Me.txtAccountNo.TabIndex = 6
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.ForeColor = System.Drawing.Color.Blue
        Me.lblCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCode.Location = New System.Drawing.Point(38, 28)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(66, 13)
        Me.lblCode.TabIndex = 14
        Me.lblCode.Text = "Bank Code :"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtCode.ForeColor = System.Drawing.Color.Blue
        Me.txtCode.Location = New System.Drawing.Point(106, 25)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(93, 21)
        Me.txtCode.TabIndex = 0
        '
        'TxtName
        '
        Me.TxtName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.TxtName.ForeColor = System.Drawing.Color.Blue
        Me.TxtName.Location = New System.Drawing.Point(106, 52)
        Me.TxtName.MaxLength = 35
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(309, 20)
        Me.TxtName.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(605, 81)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(522, 81)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.ForeColor = System.Drawing.Color.Blue
        Me.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblName.Location = New System.Drawing.Point(35, 56)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(69, 13)
        Me.lblName.TabIndex = 15
        Me.lblName.Text = "Bank Name :"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgdbank
        '
        Me.dgdbank.AllowUserToAddRows = False
        Me.dgdbank.AllowUserToDeleteRows = False
        Me.dgdbank.AllowUserToResizeRows = False
        Me.dgdbank.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdbank.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdbank.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdbank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdbank.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AccountbankId, Me.Bank, Me.BankName, Me.AccountNo})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdbank.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgdbank.Location = New System.Drawing.Point(7, 35)
        Me.dgdbank.Name = "dgdbank"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdbank.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgdbank.Size = New System.Drawing.Size(689, 213)
        Me.dgdbank.TabIndex = 46
        '
        'AccountbankId
        '
        Me.AccountbankId.DataPropertyName = "AccountbankId"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.AccountbankId.DefaultCellStyle = DataGridViewCellStyle2
        Me.AccountbankId.HeaderText = "AccountbankId"
        Me.AccountbankId.Name = "AccountbankId"
        Me.AccountbankId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.AccountbankId.Visible = False
        Me.AccountbankId.Width = 67
        '
        'Bank
        '
        Me.Bank.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Bank.DataPropertyName = "Bank"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.Bank.DefaultCellStyle = DataGridViewCellStyle3
        Me.Bank.HeaderText = "Bank Code"
        Me.Bank.Name = "Bank"
        Me.Bank.Width = 94
        '
        'BankName
        '
        Me.BankName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BankName.DataPropertyName = "bankName"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.BankName.DefaultCellStyle = DataGridViewCellStyle4
        Me.BankName.HeaderText = "Bank name"
        Me.BankName.Name = "BankName"
        Me.BankName.Width = 95
        '
        'AccountNo
        '
        Me.AccountNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.AccountNo.DataPropertyName = "AccountNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.AccountNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.AccountNo.HeaderText = "AccountNo"
        Me.AccountNo.Name = "AccountNo"
        Me.AccountNo.Width = 95
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuEdit, Me.smnuExportExcel})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(701, 24)
        Me.MenuStrip.TabIndex = 49
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "Search"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.NewToolStripMenuItem.Text = "&New"
        '
        'OpenToolStripMenuItem
        '
        Me.OpenToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue
        Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
        Me.OpenToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.OpenToolStripMenuItem.Text = "&Open"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'smnuEdit
        '
        Me.smnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangeDetailToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'ChangeDetailToolStripMenuItem
        '
        Me.ChangeDetailToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue
        Me.ChangeDetailToolStripMenuItem.Name = "ChangeDetailToolStripMenuItem"
        Me.ChangeDetailToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.ChangeDetailToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.ChangeDetailToolStripMenuItem.Text = "&Change detail"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.ForeColor = System.Drawing.Color.DarkBlue
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(189, 22)
        Me.DeleteToolStripMenuItem.Text = "&Delete"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(81, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'frmAccountbank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 381)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdbank)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmAccountbank"
        Me.Text = "Account bank"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdbank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNo As System.Windows.Forms.TextBox
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents TxtName As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents dgdbank As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangeDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccountbankId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
