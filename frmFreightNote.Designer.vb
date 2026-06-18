<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreightNote
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMESSRS = New System.Windows.Forms.TextBox
        Me.txtTax = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtBL_NO = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtRoadTax = New System.Windows.Forms.TextBox
        Me.txtCurrency = New System.Windows.Forms.TextBox
        Me.cboShippingLines = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(75, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tax :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(60, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Messrs :"
        '
        'txtMESSRS
        '
        Me.txtMESSRS.Location = New System.Drawing.Point(108, 75)
        Me.txtMESSRS.Multiline = True
        Me.txtMESSRS.Name = "txtMESSRS"
        Me.txtMESSRS.Size = New System.Drawing.Size(291, 76)
        Me.txtMESSRS.TabIndex = 2
        '
        'txtTax
        '
        Me.txtTax.Location = New System.Drawing.Point(108, 49)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(291, 20)
        Me.txtTax.TabIndex = 1
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdOk.Location = New System.Drawing.Point(243, 189)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 5
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancel.Location = New System.Drawing.Point(324, 189)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtBL_NO
        '
        Me.txtBL_NO.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBL_NO.Location = New System.Drawing.Point(108, 12)
        Me.txtBL_NO.Name = "txtBL_NO"
        Me.txtBL_NO.Size = New System.Drawing.Size(291, 31)
        Me.txtBL_NO.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(32, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Bill Of Lading :"
        '
        'txtRoadTax
        '
        Me.txtRoadTax.Location = New System.Drawing.Point(87, 91)
        Me.txtRoadTax.Name = "txtRoadTax"
        Me.txtRoadTax.Size = New System.Drawing.Size(15, 20)
        Me.txtRoadTax.TabIndex = 3
        Me.txtRoadTax.Visible = False
        '
        'txtCurrency
        '
        Me.txtCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCurrency.Location = New System.Drawing.Point(87, 117)
        Me.txtCurrency.Name = "txtCurrency"
        Me.txtCurrency.Size = New System.Drawing.Size(10, 20)
        Me.txtCurrency.TabIndex = 4
        Me.txtCurrency.Visible = False
        '
        'cboShippingLines
        '
        Me.cboShippingLines.FormattingEnabled = True
        Me.cboShippingLines.Location = New System.Drawing.Point(150, 157)
        Me.cboShippingLines.Name = "cboShippingLines"
        Me.cboShippingLines.Size = New System.Drawing.Size(249, 21)
        Me.cboShippingLines.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(69, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Shipping lines :"
        '
        'frmFreightNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 224)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboShippingLines)
        Me.Controls.Add(Me.txtBL_NO)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtCurrency)
        Me.Controls.Add(Me.txtRoadTax)
        Me.Controls.Add(Me.txtTax)
        Me.Controls.Add(Me.txtMESSRS)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximumSize = New System.Drawing.Size(419, 248)
        Me.MinimumSize = New System.Drawing.Size(419, 248)
        Me.Name = "frmFreightNote"
        Me.Text = "Freight Note"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMESSRS As System.Windows.Forms.TextBox
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtBL_NO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRoadTax As System.Windows.Forms.TextBox
    Friend WithEvents txtCurrency As System.Windows.Forms.TextBox
    Friend WithEvents cboShippingLines As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
