<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetbalance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetbalance))
        Me.cmdSaveService = New System.Windows.Forms.Button
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.accountbankid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bank = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bankname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.money = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ngay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(12, 209)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(75, 23)
        Me.cmdSaveService.TabIndex = 4
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.accountbankid, Me.bank, Me.bankname, Me.money, Me.ngay, Me.continued, Me.userupdate, Me.dateupdate})
        Me.dgdShippingLines.Location = New System.Drawing.Point(12, 12)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(573, 191)
        Me.dgdShippingLines.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(93, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'accountbankid
        '
        Me.accountbankid.DataPropertyName = "accountbankid"
        Me.accountbankid.HeaderText = "accountbankid"
        Me.accountbankid.Name = "accountbankid"
        Me.accountbankid.Visible = False
        '
        'bank
        '
        Me.bank.DataPropertyName = "bank"
        Me.bank.HeaderText = "Bank"
        Me.bank.Name = "bank"
        '
        'bankname
        '
        Me.bankname.DataPropertyName = "bankname"
        Me.bankname.HeaderText = "Bank Name"
        Me.bankname.Name = "bankname"
        '
        'money
        '
        Me.money.DataPropertyName = "money"
        Me.money.HeaderText = "Credit"
        Me.money.Name = "money"
        '
        'ngay
        '
        Me.ngay.DataPropertyName = "ngay"
        Me.ngay.HeaderText = "Date"
        Me.ngay.Name = "ngay"
        '
        'continued
        '
        Me.continued.DataPropertyName = "continued"
        Me.continued.HeaderText = "continued"
        Me.continued.Name = "continued"
        Me.continued.Visible = False
        '
        'userupdate
        '
        Me.userupdate.DataPropertyName = "userupdate"
        Me.userupdate.HeaderText = "userupdate"
        Me.userupdate.Name = "userupdate"
        Me.userupdate.Visible = False
        '
        'dateupdate
        '
        Me.dateupdate.DataPropertyName = "dateupdate"
        Me.dateupdate.HeaderText = "dateupdate"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Visible = False
        '
        'frmSetbalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(597, 247)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSetbalance"
        Me.Text = "Set Parameter"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents accountbankid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bankname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents money As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
