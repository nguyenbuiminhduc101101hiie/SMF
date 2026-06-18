<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintALLSaleSurcharge
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.chkAll = New System.Windows.Forms.RadioButton
        Me.cboVesselVoyNo = New System.Windows.Forms.ComboBox
        Me.chkOne = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vessel - VoyNo :"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(164, 83)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(272, 83)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.Location = New System.Drawing.Point(122, 49)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(60, 17)
        Me.chkAll.TabIndex = 5
        Me.chkAll.TabStop = True
        Me.chkAll.Text = "Print All"
        Me.chkAll.UseVisualStyleBackColor = True
        Me.chkAll.Visible = False
        '
        'cboVesselVoyNo
        '
        Me.cboVesselVoyNo.FormattingEnabled = True
        Me.cboVesselVoyNo.Location = New System.Drawing.Point(112, 22)
        Me.cboVesselVoyNo.Name = "cboVesselVoyNo"
        Me.cboVesselVoyNo.Size = New System.Drawing.Size(285, 21)
        Me.cboVesselVoyNo.TabIndex = 7
        '
        'chkOne
        '
        Me.chkOne.AutoSize = True
        Me.chkOne.Location = New System.Drawing.Point(254, 49)
        Me.chkOne.Name = "chkOne"
        Me.chkOne.Size = New System.Drawing.Size(93, 17)
        Me.chkOne.TabIndex = 4
        Me.chkOne.Text = "Print One Only"
        Me.chkOne.UseVisualStyleBackColor = True
        Me.chkOne.Visible = False
        '
        'FrmPrintALLSaleSurcharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(439, 113)
        Me.Controls.Add(Me.cboVesselVoyNo)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.chkOne)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Label2)
        Me.Name = "FrmPrintALLSaleSurcharge"
        Me.Text = "Prin Sale Surcharge"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents chkAll As System.Windows.Forms.RadioButton
    Friend WithEvents cboVesselVoyNo As System.Windows.Forms.ComboBox
    Friend WithEvents chkOne As System.Windows.Forms.RadioButton
End Class
