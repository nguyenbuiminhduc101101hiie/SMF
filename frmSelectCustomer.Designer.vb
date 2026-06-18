<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSelectCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelectCustomer))
        Me.GroupBox15 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.txtcode = New System.Windows.Forms.TextBox
        Me.cmdcode = New System.Windows.Forms.Button
        Me.Label33 = New System.Windows.Forms.Label
        Me.cboCustomerShipper = New System.Windows.Forms.ComboBox
        Me.cmdchonShipper = New System.Windows.Forms.Button
        Me.GroupBox15.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox15
        '
        Me.GroupBox15.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox15.Controls.Add(Me.TextBox1)
        Me.GroupBox15.Controls.Add(Me.txtcode)
        Me.GroupBox15.Controls.Add(Me.cmdcode)
        Me.GroupBox15.Controls.Add(Me.Label33)
        Me.GroupBox15.Controls.Add(Me.cboCustomerShipper)
        Me.GroupBox15.Controls.Add(Me.cmdchonShipper)
        Me.GroupBox15.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.Size = New System.Drawing.Size(118, 182)
        Me.GroupBox15.TabIndex = 608
        Me.GroupBox15.TabStop = False
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(7, 109)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(105, 67)
        Me.TextBox1.TabIndex = 333
        '
        'txtcode
        '
        Me.txtcode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtcode.BackColor = System.Drawing.Color.SeaShell
        Me.txtcode.Location = New System.Drawing.Point(7, 21)
        Me.txtcode.Name = "txtcode"
        Me.txtcode.Size = New System.Drawing.Size(105, 20)
        Me.txtcode.TabIndex = 1
        '
        'cmdcode
        '
        Me.cmdcode.Location = New System.Drawing.Point(7, 47)
        Me.cmdcode.Name = "cmdcode"
        Me.cmdcode.Size = New System.Drawing.Size(19, 24)
        Me.cmdcode.TabIndex = 2
        Me.cmdcode.Text = ">"
        Me.cmdcode.UseVisualStyleBackColor = True
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label33.Location = New System.Drawing.Point(4, 7)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(44, 13)
        Me.Label33.TabIndex = 332
        Me.Label33.Text = "string ..."
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCustomerShipper
        '
        Me.cboCustomerShipper.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCustomerShipper.BackColor = System.Drawing.Color.SeaShell
        Me.cboCustomerShipper.DropDownWidth = 400
        Me.cboCustomerShipper.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCustomerShipper.FormattingEnabled = True
        Me.cboCustomerShipper.Location = New System.Drawing.Point(7, 77)
        Me.cboCustomerShipper.Name = "cboCustomerShipper"
        Me.cboCustomerShipper.Size = New System.Drawing.Size(105, 26)
        Me.cboCustomerShipper.TabIndex = 3
        '
        'cmdchonShipper
        '
        Me.cmdchonShipper.Location = New System.Drawing.Point(32, 48)
        Me.cmdchonShipper.Name = "cmdchonShipper"
        Me.cmdchonShipper.Size = New System.Drawing.Size(44, 23)
        Me.cmdchonShipper.TabIndex = 4
        Me.cmdchonShipper.Text = "Copy..."
        Me.cmdchonShipper.UseVisualStyleBackColor = True
        '
        'frmSelectCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(124, 185)
        Me.Controls.Add(Me.GroupBox15)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSelectCustomer"
        Me.Text = "Select Customer"
        Me.TopMost = True
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents txtcode As System.Windows.Forms.TextBox
    Friend WithEvents cmdcode As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents cboCustomerShipper As System.Windows.Forms.ComboBox
    Friend WithEvents cmdchonShipper As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
End Class
