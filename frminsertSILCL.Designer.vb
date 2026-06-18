<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frminsertSILCL
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frminsertSILCL))
        Me.cbotat = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.cbobranch = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRef = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.palBillHouse = New System.Windows.Forms.Panel
        Me.cmdReset = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtNumberBillHouse = New System.Windows.Forms.TextBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cboSalename = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cbotat
        '
        Me.cbotat.FormattingEnabled = True
        Me.cbotat.Items.AddRange(New Object() {"ES", "EN", "IS", "IN"})
        Me.cbotat.Location = New System.Drawing.Point(100, 51)
        Me.cbotat.Name = "cbotat"
        Me.cbotat.Size = New System.Drawing.Size(57, 21)
        Me.cbotat.TabIndex = 435
        Me.cbotat.Text = "ES"
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.Color.Maroon
        Me.Button1.Location = New System.Drawing.Point(163, 51)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(61, 23)
        Me.Button1.TabIndex = 431
        Me.Button1.Text = "get..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label8.Location = New System.Drawing.Point(239, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 430
        Me.Label8.Visible = False
        '
        'cbobranch
        '
        Me.cbobranch.FormattingEnabled = True
        Me.cbobranch.Items.AddRange(New Object() {"HCM", "HPH", "HAN"})
        Me.cbobranch.Location = New System.Drawing.Point(37, 51)
        Me.cbobranch.Name = "cbobranch"
        Me.cbobranch.Size = New System.Drawing.Size(57, 21)
        Me.cbobranch.TabIndex = 429
        Me.cbobranch.Text = "HCM"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(16, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 426
        Me.Label6.Text = "Ref No. :"
        '
        'txtRef
        '
        Me.txtRef.Location = New System.Drawing.Point(91, 81)
        Me.txtRef.Name = "txtRef"
        Me.txtRef.Size = New System.Drawing.Size(133, 20)
        Me.txtRef.TabIndex = 416
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(228, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 425
        Me.Label4.Text = "Ref. (House bill) :"
        '
        'palBillHouse
        '
        Me.palBillHouse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.palBillHouse.AutoScroll = True
        Me.palBillHouse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.palBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.palBillHouse.Location = New System.Drawing.Point(230, 31)
        Me.palBillHouse.Name = "palBillHouse"
        Me.palBillHouse.Size = New System.Drawing.Size(433, 129)
        Me.palBillHouse.TabIndex = 424
        '
        'cmdReset
        '
        Me.cmdReset.ForeColor = System.Drawing.Color.Maroon
        Me.cmdReset.Location = New System.Drawing.Point(163, 137)
        Me.cmdReset.Name = "cmdReset"
        Me.cmdReset.Size = New System.Drawing.Size(61, 23)
        Me.cmdReset.TabIndex = 419
        Me.cmdReset.Text = "Reset"
        Me.cmdReset.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(588, 175)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 421
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtNumberBillHouse
        '
        Me.txtNumberBillHouse.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumberBillHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumberBillHouse.Location = New System.Drawing.Point(132, 107)
        Me.txtNumberBillHouse.Name = "txtNumberBillHouse"
        Me.txtNumberBillHouse.Size = New System.Drawing.Size(92, 24)
        Me.txtNumberBillHouse.TabIndex = 418
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(507, 175)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 420
        Me.cmdOK.Text = "&Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(53, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 422
        Me.Label5.Text = "Number Ref. :"
        '
        'cboSalename
        '
        Me.cboSalename.BackColor = System.Drawing.Color.White
        Me.cboSalename.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboSalename.FormattingEnabled = True
        Me.cboSalename.Location = New System.Drawing.Point(37, 18)
        Me.cboSalename.Name = "cboSalename"
        Me.cboSalename.Size = New System.Drawing.Size(114, 23)
        Me.cboSalename.TabIndex = 436
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(34, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 15)
        Me.Label7.TabIndex = 437
        Me.Label7.Text = "Sale name :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frminsertSILCL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(672, 210)
        Me.Controls.Add(Me.cboSalename)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbotat)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbobranch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRef)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.palBillHouse)
        Me.Controls.Add(Me.cmdReset)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.txtNumberBillHouse)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frminsertSILCL"
        Me.Text = "Insert SI (Consol)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbotat As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbobranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRef As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents palBillHouse As System.Windows.Forms.Panel
    Friend WithEvents cmdReset As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtNumberBillHouse As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboSalename As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
