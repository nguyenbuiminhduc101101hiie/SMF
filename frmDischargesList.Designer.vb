<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDischargesList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDischargesList))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboVoy = New System.Windows.Forms.ComboBox()
        Me.Label314 = New System.Windows.Forms.Label()
        Me.cbotenTau = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(303, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 347
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(222, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 346
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(14, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 345
        Me.Label1.Text = "Voyage :"
        '
        'cboVoy
        '
        Me.cboVoy.FormattingEnabled = True
        Me.cboVoy.Location = New System.Drawing.Point(69, 37)
        Me.cboVoy.Name = "cboVoy"
        Me.cboVoy.Size = New System.Drawing.Size(309, 21)
        Me.cboVoy.TabIndex = 344
        '
        'Label314
        '
        Me.Label314.AutoSize = True
        Me.Label314.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label314.Location = New System.Drawing.Point(14, 14)
        Me.Label314.Name = "Label314"
        Me.Label314.Size = New System.Drawing.Size(44, 13)
        Me.Label314.TabIndex = 343
        Me.Label314.Text = "Vessel :"
        '
        'cbotenTau
        '
        Me.cbotenTau.FormattingEnabled = True
        Me.cbotenTau.Location = New System.Drawing.Point(69, 10)
        Me.cbotenTau.Name = "cbotenTau"
        Me.cbotenTau.Size = New System.Drawing.Size(309, 21)
        Me.cbotenTau.TabIndex = 342
        '
        'frmDischargesList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(396, 96)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboVoy)
        Me.Controls.Add(Me.Label314)
        Me.Controls.Add(Me.cbotenTau)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDischargesList"
        Me.Text = "Discharges List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVoy As System.Windows.Forms.ComboBox
    Friend WithEvents Label314 As System.Windows.Forms.Label
    Friend WithEvents cbotenTau As System.Windows.Forms.ComboBox
End Class
