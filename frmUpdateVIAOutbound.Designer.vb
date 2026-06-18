<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateVIAOutbound
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVessel = New System.Windows.Forms.Label
        Me.dtpLeavingDate = New System.Windows.Forms.DateTimePicker
        Me.cboPOD = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtVIA1 = New System.Windows.Forms.TextBox
        Me.txtVIA2 = New System.Windows.Forms.TextBox
        Me.txtVIA3 = New System.Windows.Forms.TextBox
        Me.txtVIA4 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(247, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(338, 173)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(97, 12)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(316, 21)
        Me.cboVessel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(59, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 289
        Me.Label1.Text = "ETD :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.BackColor = System.Drawing.Color.Transparent
        Me.lblVessel.ForeColor = System.Drawing.Color.Blue
        Me.lblVessel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVessel.Location = New System.Drawing.Point(10, 14)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(87, 13)
        Me.lblVessel.TabIndex = 290
        Me.lblVessel.Text = "Vessel / VoyNo :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLeavingDate.Location = New System.Drawing.Point(97, 37)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpLeavingDate.TabIndex = 1
        '
        'cboPOD
        '
        Me.cboPOD.FormattingEnabled = True
        Me.cboPOD.Location = New System.Drawing.Point(97, 63)
        Me.cboPOD.Name = "cboPOD"
        Me.cboPOD.Size = New System.Drawing.Size(189, 21)
        Me.cboPOD.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(58, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 295
        Me.Label2.Text = "POD :"
        '
        'txtVIA1
        '
        Me.txtVIA1.Location = New System.Drawing.Point(97, 101)
        Me.txtVIA1.Name = "txtVIA1"
        Me.txtVIA1.Size = New System.Drawing.Size(138, 20)
        Me.txtVIA1.TabIndex = 3
        '
        'txtVIA2
        '
        Me.txtVIA2.Location = New System.Drawing.Point(97, 129)
        Me.txtVIA2.Name = "txtVIA2"
        Me.txtVIA2.Size = New System.Drawing.Size(138, 20)
        Me.txtVIA2.TabIndex = 4
        '
        'txtVIA3
        '
        Me.txtVIA3.Location = New System.Drawing.Point(283, 102)
        Me.txtVIA3.Name = "txtVIA3"
        Me.txtVIA3.Size = New System.Drawing.Size(130, 20)
        Me.txtVIA3.TabIndex = 5
        '
        'txtVIA4
        '
        Me.txtVIA4.Location = New System.Drawing.Point(283, 130)
        Me.txtVIA4.Name = "txtVIA4"
        Me.txtVIA4.Size = New System.Drawing.Size(130, 20)
        Me.txtVIA4.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(55, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 295
        Me.Label3.Text = "VIA 1 :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(55, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 295
        Me.Label4.Text = "VIA 2 :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(241, 106)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 295
        Me.Label5.Text = "VIA 3 :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(241, 132)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 295
        Me.Label6.Text = "VIA 4 :"
        '
        'frmUpdateVIAOutbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 204)
        Me.Controls.Add(Me.txtVIA4)
        Me.Controls.Add(Me.txtVIA3)
        Me.Controls.Add(Me.txtVIA2)
        Me.Controls.Add(Me.txtVIA1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboPOD)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.dtpLeavingDate)
        Me.Name = "frmUpdateVIAOutbound"
        Me.Text = "Update VIA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboPOD As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtVIA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtVIA2 As System.Windows.Forms.TextBox
    Friend WithEvents txtVIA3 As System.Windows.Forms.TextBox
    Friend WithEvents txtVIA4 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
