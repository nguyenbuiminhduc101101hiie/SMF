<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTarifDetailInput
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
        Me.pnlTop = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblHeaderInfo = New System.Windows.Forms.Label()
        Me.pnlInput = New System.Windows.Forms.Panel()
        Me.cmdAddRow = New System.Windows.Forms.Button()
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
        Me.lblInputTitle = New System.Windows.Forms.Label()
        Me.dgdPending = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdRemoveRow = New System.Windows.Forms.Button()
        Me.cmdSaveAll = New System.Windows.Forms.Button()
        Me.lblGridTitle = New System.Windows.Forms.Label()
        Me.pnlTop.SuspendLayout()
        Me.pnlInput.SuspendLayout()
        CType(Me.dgdPending, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlTop
        '
        Me.pnlTop.BackColor = System.Drawing.Color.SteelBlue
        Me.pnlTop.Controls.Add(Me.lblHeaderInfo)
        Me.pnlTop.Controls.Add(Me.lblTitle)
        Me.pnlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTop.Location = New System.Drawing.Point(0, 0)
        Me.pnlTop.Name = "pnlTop"
        Me.pnlTop.Size = New System.Drawing.Size(900, 64)
        Me.pnlTop.TabIndex = 0
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.White
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New System.Windows.Forms.Padding(16, 8, 0, 0)
        Me.lblTitle.Size = New System.Drawing.Size(900, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "New Tarif Details"
        '
        'lblHeaderInfo
        '
        Me.lblHeaderInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeaderInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblHeaderInfo.ForeColor = System.Drawing.Color.White
        Me.lblHeaderInfo.Location = New System.Drawing.Point(0, 32)
        Me.lblHeaderInfo.Name = "lblHeaderInfo"
        Me.lblHeaderInfo.Padding = New System.Windows.Forms.Padding(16, 0, 0, 0)
        Me.lblHeaderInfo.Size = New System.Drawing.Size(900, 32)
        Me.lblHeaderInfo.TabIndex = 1
        Me.lblHeaderInfo.Text = "Header info"
        Me.lblHeaderInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlInput
        '
        Me.pnlInput.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlInput.Controls.Add(Me.cmdAddRow)
        Me.pnlInput.Controls.Add(Me.txtTigia)
        Me.pnlInput.Controls.Add(Me.Label8)
        Me.pnlInput.Controls.Add(Me.txtUnitPriceIncVAT)
        Me.pnlInput.Controls.Add(Me.Label7)
        Me.pnlInput.Controls.Add(Me.txtVAT)
        Me.pnlInput.Controls.Add(Me.Label6)
        Me.pnlInput.Controls.Add(Me.txtTotalAmount)
        Me.pnlInput.Controls.Add(Me.Label5)
        Me.pnlInput.Controls.Add(Me.txtUnitPrice)
        Me.pnlInput.Controls.Add(Me.Label4)
        Me.pnlInput.Controls.Add(Me.txtQty)
        Me.pnlInput.Controls.Add(Me.Label3)
        Me.pnlInput.Controls.Add(Me.txtUnit)
        Me.pnlInput.Controls.Add(Me.Label2)
        Me.pnlInput.Controls.Add(Me.cboCurrency)
        Me.pnlInput.Controls.Add(Me.Label1)
        Me.pnlInput.Controls.Add(Me.cboItem)
        Me.pnlInput.Controls.Add(Me.lblItem)
        Me.pnlInput.Controls.Add(Me.lblInputTitle)
        Me.pnlInput.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInput.Location = New System.Drawing.Point(0, 64)
        Me.pnlInput.Name = "pnlInput"
        Me.pnlInput.Padding = New System.Windows.Forms.Padding(12, 8, 12, 8)
        Me.pnlInput.Size = New System.Drawing.Size(900, 148)
        Me.pnlInput.TabIndex = 1
        '
        'cmdAddRow
        '
        Me.cmdAddRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAddRow.BackColor = System.Drawing.Color.SeaGreen
        Me.cmdAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAddRow.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdAddRow.ForeColor = System.Drawing.Color.White
        Me.cmdAddRow.Location = New System.Drawing.Point(760, 108)
        Me.cmdAddRow.Name = "cmdAddRow"
        Me.cmdAddRow.Size = New System.Drawing.Size(120, 32)
        Me.cmdAddRow.TabIndex = 19
        Me.cmdAddRow.Text = "+ Add to List"
        Me.cmdAddRow.UseVisualStyleBackColor = False
        '
        'txtTigia
        '
        Me.txtTigia.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtTigia.Location = New System.Drawing.Point(780, 72)
        Me.txtTigia.Name = "txtTigia"
        Me.txtTigia.Size = New System.Drawing.Size(100, 25)
        Me.txtTigia.TabIndex = 18
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(740, 75)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 17)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Tigia"
        '
        'txtUnitPriceIncVAT
        '
        Me.txtUnitPriceIncVAT.BackColor = System.Drawing.Color.Gainsboro
        Me.txtUnitPriceIncVAT.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnitPriceIncVAT.Location = New System.Drawing.Point(620, 72)
        Me.txtUnitPriceIncVAT.Name = "txtUnitPriceIncVAT"
        Me.txtUnitPriceIncVAT.ReadOnly = True
        Me.txtUnitPriceIncVAT.Size = New System.Drawing.Size(100, 25)
        Me.txtUnitPriceIncVAT.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(500, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 17)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Unit Price Inc VAT"
        '
        'txtVAT
        '
        Me.txtVAT.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtVAT.Location = New System.Drawing.Point(440, 72)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.Size = New System.Drawing.Size(50, 25)
        Me.txtVAT.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(400, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 17)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "VAT%"
        '
        'txtTotalAmount
        '
        Me.txtTotalAmount.BackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalAmount.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtTotalAmount.Location = New System.Drawing.Point(290, 72)
        Me.txtTotalAmount.Name = "txtTotalAmount"
        Me.txtTotalAmount.ReadOnly = True
        Me.txtTotalAmount.Size = New System.Drawing.Size(100, 25)
        Me.txtTotalAmount.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(196, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 17)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Total Amount"
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnitPrice.Location = New System.Drawing.Point(90, 72)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.Size = New System.Drawing.Size(100, 25)
        Me.txtUnitPrice.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(16, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 17)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Unit Price"
        '
        'txtQty
        '
        Me.txtQty.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtQty.Location = New System.Drawing.Point(780, 36)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(100, 25)
        Me.txtQty.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(748, 39)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Qty"
        '
        'txtUnit
        '
        Me.txtUnit.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUnit.Location = New System.Drawing.Point(620, 36)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.Size = New System.Drawing.Size(100, 25)
        Me.txtUnit.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(584, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Unit"
        '
        'cboCurrency
        '
        Me.cboCurrency.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(440, 36)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(120, 25)
        Me.cboCurrency.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(370, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Currency"
        '
        'cboItem
        '
        Me.cboItem.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.cboItem.DropDownWidth = 500
        Me.cboItem.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cboItem.FormattingEnabled = True
        Me.cboItem.Location = New System.Drawing.Point(90, 36)
        Me.cboItem.Name = "cboItem"
        Me.cboItem.Size = New System.Drawing.Size(260, 25)
        Me.cboItem.TabIndex = 2
        '
        'lblItem
        '
        Me.lblItem.AutoSize = True
        Me.lblItem.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblItem.Location = New System.Drawing.Point(16, 39)
        Me.lblItem.Name = "lblItem"
        Me.lblItem.Size = New System.Drawing.Size(34, 17)
        Me.lblItem.TabIndex = 1
        Me.lblItem.Text = "Item"
        '
        'lblInputTitle
        '
        Me.lblInputTitle.AutoSize = True
        Me.lblInputTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblInputTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblInputTitle.Location = New System.Drawing.Point(16, 12)
        Me.lblInputTitle.Name = "lblInputTitle"
        Me.lblInputTitle.Size = New System.Drawing.Size(127, 17)
        Me.lblInputTitle.TabIndex = 0
        Me.lblInputTitle.Text = "Enter Detail Row"
        '
        'dgdPending
        '
        Me.dgdPending.AllowUserToAddRows = False
        Me.dgdPending.AllowUserToDeleteRows = False
        Me.dgdPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPending.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdPending.Location = New System.Drawing.Point(0, 236)
        Me.dgdPending.Name = "dgdPending"
        Me.dgdPending.ReadOnly = True
        Me.dgdPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdPending.Size = New System.Drawing.Size(900, 244)
        Me.dgdPending.TabIndex = 2
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.Controls.Add(Me.cmdClose)
        Me.pnlBottom.Controls.Add(Me.cmdRemoveRow)
        Me.pnlBottom.Controls.Add(Me.cmdSaveAll)
        Me.pnlBottom.Controls.Add(Me.lblGridTitle)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 480)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(900, 52)
        Me.pnlBottom.TabIndex = 3
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmdClose.Location = New System.Drawing.Point(800, 10)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(88, 32)
        Me.cmdClose.TabIndex = 3
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdRemoveRow
        '
        Me.cmdRemoveRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRemoveRow.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmdRemoveRow.Location = New System.Drawing.Point(696, 10)
        Me.cmdRemoveRow.Name = "cmdRemoveRow"
        Me.cmdRemoveRow.Size = New System.Drawing.Size(96, 32)
        Me.cmdRemoveRow.TabIndex = 2
        Me.cmdRemoveRow.Text = "Remove Row"
        Me.cmdRemoveRow.UseVisualStyleBackColor = True
        '
        'cmdSaveAll
        '
        Me.cmdSaveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSaveAll.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSaveAll.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmdSaveAll.ForeColor = System.Drawing.Color.White
        Me.cmdSaveAll.Location = New System.Drawing.Point(580, 10)
        Me.cmdSaveAll.Name = "cmdSaveAll"
        Me.cmdSaveAll.Size = New System.Drawing.Size(108, 32)
        Me.cmdSaveAll.TabIndex = 1
        Me.cmdSaveAll.Text = "Save All"
        Me.cmdSaveAll.UseVisualStyleBackColor = False
        '
        'lblGridTitle
        '
        Me.lblGridTitle.AutoSize = True
        Me.lblGridTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblGridTitle.ForeColor = System.Drawing.Color.DimGray
        Me.lblGridTitle.Location = New System.Drawing.Point(16, 18)
        Me.lblGridTitle.Name = "lblGridTitle"
        Me.lblGridTitle.Size = New System.Drawing.Size(248, 17)
        Me.lblGridTitle.TabIndex = 0
        Me.lblGridTitle.Text = "Pending Details (add multiple rows)"
        '
        'frmTarifDetailInput
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 532)
        Me.Controls.Add(Me.dgdPending)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlInput)
        Me.Controls.Add(Me.pnlTop)
        Me.MinimizeBox = False
        Me.Name = "frmTarifDetailInput"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New Tarif Details"
        Me.pnlTop.ResumeLayout(False)
        Me.pnlInput.ResumeLayout(False)
        Me.pnlInput.PerformLayout()
        CType(Me.dgdPending, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblHeaderInfo As Label
    Friend WithEvents pnlInput As Panel
    Friend WithEvents lblInputTitle As Label
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
    Friend WithEvents cmdAddRow As Button
    Friend WithEvents dgdPending As DataGridView
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblGridTitle As Label
    Friend WithEvents cmdSaveAll As Button
    Friend WithEvents cmdRemoveRow As Button
    Friend WithEvents cmdClose As Button
End Class
