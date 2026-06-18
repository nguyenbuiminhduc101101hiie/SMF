<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCurrency
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCurrency))
        Me.fraUpdate = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtcode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpNgay = New System.Windows.Forms.DateTimePicker()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.txtRate = New System.Windows.Forms.TextBox()
        Me.txtCurrency = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgdCurrency = New System.Windows.Forms.DataGridView()
        Me.CurrencyID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Currency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClpsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdCurrency, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.txtcode)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.dtpNgay)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.Controls.Add(Me.txtRate)
        Me.fraUpdate.Controls.Add(Me.txtCurrency)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Location = New System.Drawing.Point(9, 303)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(701, 79)
        Me.fraUpdate.TabIndex = 5
        Me.fraUpdate.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Date :"
        '
        'txtcode
        '
        Me.txtcode.Location = New System.Drawing.Point(257, 43)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(99, 20)
        Me.txtcode.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(196, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Code :"
        '
        'dtpNgay
        '
        Me.dtpNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpNgay.Location = New System.Drawing.Point(257, 15)
        Me.dtpNgay.Name = "dtpNgay"
        Me.dtpNgay.Size = New System.Drawing.Size(99, 20)
        Me.dtpNgay.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(370, 42)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(451, 42)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(95, 44)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(84, 20)
        Me.txtRate.TabIndex = 1
        Me.txtRate.Text = "0"
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCurrency
        '
        Me.txtCurrency.Location = New System.Drawing.Point(95, 18)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(84, 20)
        Me.txtCurrency.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(56, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Rate :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Currency :"
        '
        'dgdCurrency
        '
        Me.dgdCurrency.AllowUserToAddRows = False
        Me.dgdCurrency.AllowUserToDeleteRows = False
        Me.dgdCurrency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdCurrency.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCurrency.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CurrencyID, Me.Currency, Me.Rate, Me.ngay, Me.code, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdCurrency.Location = New System.Drawing.Point(10, 36)
        Me.dgdCurrency.Name = "dgdCurrency"
        Me.dgdCurrency.Size = New System.Drawing.Size(718, 261)
        Me.dgdCurrency.TabIndex = 3
        '
        'CurrencyID
        '
        Me.CurrencyID.DataPropertyName = "CurrencyID"
        Me.CurrencyID.HeaderText = "CurrencyID"
        Me.CurrencyID.Name = "CurrencyID"
        Me.CurrencyID.Visible = False
        '
        'Currency
        '
        Me.Currency.DataPropertyName = "Currency"
        Me.Currency.HeaderText = "Currency"
        Me.Currency.Name = "Currency"
        Me.Currency.Width = 74
        '
        'Rate
        '
        Me.Rate.DataPropertyName = "Rate"
        Me.Rate.HeaderText = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.Width = 55
        '
        'ngay
        '
        Me.ngay.DataPropertyName = "ngay"
        Me.ngay.HeaderText = "Date"
        Me.ngay.Name = "ngay"
        Me.ngay.Width = 55
        '
        'code
        '
        Me.code.DataPropertyName = "code"
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.Width = 57
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Continued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Continued.Visible = False
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Editable.Visible = False
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.Width = 72
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "userID"
        Me.UserID.Name = "UserID"
        Me.UserID.Width = 63
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.Width = 90
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.ExportExcelToolStripMenuItem, Me.smnuExit, Me.ClpsToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(735, 24)
        Me.MenuStrip.TabIndex = 4
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'smnuSearch
        '
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(43, 20)
        Me.smnuAdd.Text = "New"
        '
        'smnuEdit
        '
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.smnuEdit.Text = "Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(52, 20)
        Me.smnuDelete.Text = "Delete"
        Me.smnuDelete.Visible = False
        '
        'ExportExcelToolStripMenuItem
        '
        Me.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem"
        Me.ExportExcelToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.ExportExcelToolStripMenuItem.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "Exit"
        '
        'ClpsToolStripMenuItem
        '
        Me.ClpsToolStripMenuItem.Name = "ClpsToolStripMenuItem"
        Me.ClpsToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.ClpsToolStripMenuItem.Text = "Clips"
        '
        'frmCurrency
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(735, 387)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdCurrency)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCurrency"
        Me.Text = "Currency"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdCurrency, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dgdCurrency As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CurrencyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ClpsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
