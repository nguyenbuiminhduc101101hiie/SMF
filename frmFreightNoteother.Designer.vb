<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreightNoteother
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
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.FreightNoteoTherID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Charge_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fee = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Currency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeeType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdExit = New System.Windows.Forms.Button
        Me.txtToTal = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.txtType = New System.Windows.Forms.TextBox
        Me.txtCurrency = New System.Windows.Forms.TextBox
        Me.txtFee = New System.Windows.Forms.TextBox
        Me.txtChargeCode = New System.Windows.Forms.TextBox
        Me.txtBLNO = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FreightNoteoTherID, Me.BL_NO, Me.Charge_Code, Me.Fee, Me.Quantity, Me.Currency, Me.FeeType, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdData.Location = New System.Drawing.Point(4, 3)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(721, 208)
        Me.dgdData.TabIndex = 0
        '
        'FreightNoteoTherID
        '
        Me.FreightNoteoTherID.DataPropertyName = "FreightNoteoTherID"
        Me.FreightNoteoTherID.HeaderText = "FreightNoteoTherID"
        Me.FreightNoteoTherID.Name = "FreightNoteoTherID"
        Me.FreightNoteoTherID.ReadOnly = True
        Me.FreightNoteoTherID.Visible = False
        '
        'BL_NO
        '
        Me.BL_NO.DataPropertyName = "BL_NO"
        Me.BL_NO.HeaderText = "B/L No."
        Me.BL_NO.Name = "BL_NO"
        Me.BL_NO.ReadOnly = True
        '
        'Charge_Code
        '
        Me.Charge_Code.DataPropertyName = "Charge_Code"
        Me.Charge_Code.HeaderText = "Charge Code"
        Me.Charge_Code.Name = "Charge_Code"
        Me.Charge_Code.ReadOnly = True
        '
        'Fee
        '
        Me.Fee.DataPropertyName = "Fee"
        Me.Fee.HeaderText = "Fee"
        Me.Fee.Name = "Fee"
        Me.Fee.ReadOnly = True
        '
        'Quantity
        '
        Me.Quantity.DataPropertyName = "Quantity"
        Me.Quantity.HeaderText = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.ReadOnly = True
        '
        'Currency
        '
        Me.Currency.DataPropertyName = "Currency"
        Me.Currency.HeaderText = "Currency"
        Me.Currency.Name = "Currency"
        Me.Currency.ReadOnly = True
        '
        'FeeType
        '
        Me.FeeType.DataPropertyName = "Type"
        Me.FeeType.HeaderText = "FeeType"
        Me.FeeType.Name = "FeeType"
        Me.FeeType.ReadOnly = True
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Continued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Continued.Visible = False
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.ReadOnly = True
        Me.Editable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Editable.Visible = False
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.ReadOnly = True
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.Visible = False
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdExit)
        Me.GroupBox1.Controls.Add(Me.txtToTal)
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.txtType)
        Me.GroupBox1.Controls.Add(Me.txtCurrency)
        Me.GroupBox1.Controls.Add(Me.txtFee)
        Me.GroupBox1.Controls.Add(Me.txtChargeCode)
        Me.GroupBox1.Controls.Add(Me.txtBLNO)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 217)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(715, 142)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmdExit
        '
        Me.cmdExit.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdExit.Location = New System.Drawing.Point(444, 115)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 3
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'txtToTal
        '
        Me.txtToTal.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtToTal.Location = New System.Drawing.Point(245, 115)
        Me.txtToTal.Name = "txtToTal"
        Me.txtToTal.ReadOnly = True
        Me.txtToTal.Size = New System.Drawing.Size(112, 20)
        Me.txtToTal.TabIndex = 2
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(276, 50)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(81, 20)
        Me.txtQuantity.TabIndex = 2
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(107, 113)
        Me.txtType.Name = "txtType"
        Me.txtType.Size = New System.Drawing.Size(83, 20)
        Me.txtType.TabIndex = 2
        Me.txtType.Text = "B/L"
        '
        'txtCurrency
        '
        Me.txtCurrency.Location = New System.Drawing.Point(276, 76)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(81, 20)
        Me.txtCurrency.TabIndex = 2
        '
        'txtFee
        '
        Me.txtFee.Location = New System.Drawing.Point(107, 74)
        Me.txtFee.Name = "txtFee"
        Me.txtFee.Size = New System.Drawing.Size(83, 20)
        Me.txtFee.TabIndex = 2
        '
        'txtChargeCode
        '
        Me.txtChargeCode.Location = New System.Drawing.Point(107, 47)
        Me.txtChargeCode.Name = "txtChargeCode"
        Me.txtChargeCode.Size = New System.Drawing.Size(83, 20)
        Me.txtChargeCode.TabIndex = 2
        '
        'txtBLNO
        '
        Me.txtBLNO.Location = New System.Drawing.Point(107, 21)
        Me.txtBLNO.Name = "txtBLNO"
        Me.txtBLNO.Size = New System.Drawing.Size(250, 20)
        Me.txtBLNO.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(206, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Total :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label8.Location = New System.Drawing.Point(68, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Type :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(222, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Quantity :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label5.Location = New System.Drawing.Point(219, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Currency :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(74, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fee :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(30, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Charge Code :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(54, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "B/L No. :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 1
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdCancel.Location = New System.Drawing.Point(525, 115)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(85, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Show Report"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.Enabled = False
        Me.cmdOk.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdOk.Location = New System.Drawing.Point(616, 115)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(93, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Add"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmFreightNoteother
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(731, 367)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgdData)
        Me.Name = "frmFreightNoteother"
        Me.Text = "Freight Note (other charge)"
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtToTal As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents txtFee As System.Windows.Forms.TextBox
    Friend WithEvents txtChargeCode As System.Windows.Forms.TextBox
    Friend WithEvents txtBLNO As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtType As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FreightNoteoTherID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Charge_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeeType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
