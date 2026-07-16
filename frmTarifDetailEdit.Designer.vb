<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTarifDetailEdit
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlBody = New System.Windows.Forms.Panel()
        Me.txtTigia = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtUnitPriceIncVAT = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalAmount = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboCurrency = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboItem = New System.Windows.Forms.ComboBox()
        Me.lblItem = New System.Windows.Forms.Label()
        Me.pnlFooter = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlBody.SuspendLayout()
        Me.pnlFooter.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.SeaGreen
        Me.pnlHeader.Controls.Add(Me.lblTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(560, 48)
        Me.pnlHeader.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lblTitle.Size = New System.Drawing.Size(560, 48)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Edit Tarif Detail"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlBody
        '
        Me.pnlBody.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlBody.Controls.Add(Me.txtTigia)
        Me.pnlBody.Controls.Add(Me.Label8)
        Me.pnlBody.Controls.Add(Me.txtUnitPriceIncVAT)
        Me.pnlBody.Controls.Add(Me.Label7)
        Me.pnlBody.Controls.Add(Me.txtVAT)
        Me.pnlBody.Controls.Add(Me.Label6)
        Me.pnlBody.Controls.Add(Me.txtTotalAmount)
        Me.pnlBody.Controls.Add(Me.Label5)
        Me.pnlBody.Controls.Add(Me.txtUnitPrice)
        Me.pnlBody.Controls.Add(Me.Label4)
        Me.pnlBody.Controls.Add(Me.txtQty)
        Me.pnlBody.Controls.Add(Me.Label3)
        Me.pnlBody.Controls.Add(Me.txtUnit)
        Me.pnlBody.Controls.Add(Me.Label2)
        Me.pnlBody.Controls.Add(Me.cboCurrency)
        Me.pnlBody.Controls.Add(Me.Label1)
        Me.pnlBody.Controls.Add(Me.cboItem)
        Me.pnlBody.Controls.Add(Me.lblItem)
        Me.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlBody.Location = New System.Drawing.Point(0, 48)
        Me.pnlBody.Name = "pnlBody"
        Me.pnlBody.Padding = New System.Windows.Forms.Padding(16, 12, 16, 8)
        Me.pnlBody.Size = New System.Drawing.Size(560, 220)
        Me.pnlBody.TabIndex = 1
        '
        'txtTigia
        '
        Me.txtTigia.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtTigia.Location = New System.Drawing.Point(420, 168)
        Me.txtTigia.Name = "txtTigia"
        Me.txtTigia.Size = New System.Drawing.Size(120, 25)
        Me.txtTigia.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(380, 171)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 17)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Tigia"
        '
        'txtUnitPriceIncVAT
        '
        Me.txtUnitPriceIncVAT.BackColor = System.Drawing.Color.Gainsboro
        Me.txtUnitPriceIncVAT.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnitPriceIncVAT.Location = New System.Drawing.Point(150, 168)
        Me.txtUnitPriceIncVAT.Name = "txtUnitPriceIncVAT"
        Me.txtUnitPriceIncVAT.ReadOnly = True
        Me.txtUnitPriceIncVAT.Size = New System.Drawing.Size(120, 25)
        Me.txtUnitPriceIncVAT.TabIndex = 15
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(19, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 17)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Unit Price Inc VAT"
        '
        'txtVAT
        '
        Me.txtVAT.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtVAT.Location = New System.Drawing.Point(490, 132)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(50, 25)
        Me.txtVAT.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(450, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "VAT%"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalAmount.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtTotalAmount.Location = New System.Drawing.Point(320, 132)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(120, 25)
        Me.txtTotalAmount.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(226, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Total Amount"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnitPrice.Location = New System.Drawing.Point(100, 132)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(120, 25)
        Me.txtUnitPrice.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(19, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Unit Price"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtQty.Location = New System.Drawing.Point(420, 96)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(120, 25)
        Me.txtQty.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(388, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Qty"
        '
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnit.Location = New System.Drawing.Point(260, 96)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(120, 25)
        Me.txtUnit.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(224, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Unit"
        '
        'cboCurrency
        '
        Me.cboCurrency.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(100, 96)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(120, 25)
        Me.cboCurrency.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(19, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Currency"
        '
        'cboItem
        '
        Me.cboItem.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.cboItem.DropDownWidth = 500
        Me.cboItem.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboItem.FormattingEnabled = True
        Me.cboItem.Location = New System.Drawing.Point(100, 24)
        Me.cboItem.Name = "cboItem"
        Me.cboItem.Size = New System.Drawing.Size(440, 25)
        Me.cboItem.TabIndex = 1
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblItem.Location = New System.Drawing.Point(19, 27)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(34, 17)
        Me.lblItem.TabIndex = 0
        Me.lblItem.Text = "Item"
        '
        'pnlFooter
        '
        Me.pnlFooter.BackColor = System.Drawing.Color.White
        Me.pnlFooter.Controls.Add(Me.cmdCancel)
        Me.pnlFooter.Controls.Add(Me.cmdSave)
        Me.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlFooter.Location = New System.Drawing.Point(0, 268)
        Me.pnlFooter.Name = "pnlFooter"
        Me.pnlFooter.Size = New System.Drawing.Size(560, 52)
        Me.pnlFooter.TabIndex = 2
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmdCancel.Location = New System.Drawing.Point(460, 10)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(88, 32)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.BackColor = System.Drawing.Color.SeaGreen
        Me.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSave.ForeColor = System.Drawing.Color.White
        Me.cmdSave.Location = New System.Drawing.Point(356, 10)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(96, 32)
        Me.cmdSave.TabIndex = 0
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = False
        '
        'frmTarifDetailEdit
        '
        Me.AcceptButton = Me.cmdSave
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(560, 320)
        Me.Controls.Add(Me.pnlBody)
        Me.Controls.Add(Me.pnlFooter)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTarifDetailEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Edit Tarif Detail"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlBody.ResumeLayout(False)
        Me.pnlBody.PerformLayout()
        Me.pnlFooter.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlBody As Panel
    Friend WithEvents cboItem As ComboBox
    Friend WithEvents lblItem As Label
    Friend WithEvents cboCurrency As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtQty As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUnitPrice As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtTotalAmount As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtVAT As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtUnitPriceIncVAT As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTigia As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents cmdSave As Button
    Friend WithEvents cmdCancel As Button
End Class
