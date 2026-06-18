<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExportcashLoan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmExportcashLoan))
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkHCM = New System.Windows.Forms.RadioButton
        Me.chkhp = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(300, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(219, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Print"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkHCM
        '
        Me.chkHCM.AutoSize = True
        Me.chkHCM.Location = New System.Drawing.Point(111, 33)
        Me.chkHCM.Name = "chkHCM"
        Me.chkHCM.Size = New System.Drawing.Size(83, 17)
        Me.chkHCM.TabIndex = 9
        Me.chkHCM.TabStop = True
        Me.chkHCM.Text = "Ho Chi Minh"
        Me.chkHCM.UseVisualStyleBackColor = True
        '
        'chkhp
        '
        Me.chkhp.AutoSize = True
        Me.chkhp.Location = New System.Drawing.Point(15, 33)
        Me.chkhp.Name = "chkhp"
        Me.chkhp.Size = New System.Drawing.Size(75, 17)
        Me.chkhp.TabIndex = 8
        Me.chkhp.TabStop = True
        Me.chkhp.Text = "Hai Phong"
        Me.chkhp.UseVisualStyleBackColor = True
        '
        'FrmExportcashLoan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(387, 79)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkHCM)
        Me.Controls.Add(Me.chkhp)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmExportcashLoan"
        Me.Text = "Export Cash Loan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkHCM As System.Windows.Forms.RadioButton
    Friend WithEvents chkhp As System.Windows.Forms.RadioButton
End Class
