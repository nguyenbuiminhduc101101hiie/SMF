<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateInBoundCY
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkFinalICD = New System.Windows.Forms.CheckBox
        Me.chkICDPort = New System.Windows.Forms.CheckBox
        Me.chkImportCY = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboTerminal = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(243, 154)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 292
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(334, 154)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 293
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(102, 12)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(270, 21)
        Me.cboVessel.TabIndex = 288
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(64, 40)
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
        Me.lblVessel.Location = New System.Drawing.Point(15, 14)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(87, 13)
        Me.lblVessel.TabIndex = 290
        Me.lblVessel.Text = "Vessel / VoyNo :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLeavingDate.Location = New System.Drawing.Point(102, 37)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpLeavingDate.TabIndex = 291
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkFinalICD)
        Me.GroupBox1.Controls.Add(Me.chkICDPort)
        Me.GroupBox1.Controls.Add(Me.chkImportCY)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 96)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 52)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        '
        'chkFinalICD
        '
        Me.chkFinalICD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkFinalICD.AutoSize = True
        Me.chkFinalICD.Checked = True
        Me.chkFinalICD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFinalICD.Location = New System.Drawing.Point(298, 19)
        Me.chkFinalICD.Name = "chkFinalICD"
        Me.chkFinalICD.Size = New System.Drawing.Size(69, 17)
        Me.chkFinalICD.TabIndex = 0
        Me.chkFinalICD.Text = "Final ICD"
        Me.chkFinalICD.UseVisualStyleBackColor = True
        '
        'chkICDPort
        '
        Me.chkICDPort.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkICDPort.AutoSize = True
        Me.chkICDPort.Checked = True
        Me.chkICDPort.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkICDPort.Location = New System.Drawing.Point(130, 19)
        Me.chkICDPort.Name = "chkICDPort"
        Me.chkICDPort.Size = New System.Drawing.Size(110, 17)
        Me.chkICDPort.TabIndex = 0
        Me.chkICDPort.Text = "Port Of Ship Ment"
        Me.chkICDPort.UseVisualStyleBackColor = True
        '
        'chkImportCY
        '
        Me.chkImportCY.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.chkImportCY.AutoSize = True
        Me.chkImportCY.Checked = True
        Me.chkImportCY.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkImportCY.Location = New System.Drawing.Point(10, 19)
        Me.chkImportCY.Name = "chkImportCY"
        Me.chkImportCY.Size = New System.Drawing.Size(72, 17)
        Me.chkImportCY.TabIndex = 0
        Me.chkImportCY.Text = "Import CY"
        Me.chkImportCY.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 295
        Me.Label2.Text = "Terminal (CY) :"
        '
        'cboTerminal
        '
        Me.cboTerminal.FormattingEnabled = True
        Me.cboTerminal.Location = New System.Drawing.Point(102, 66)
        Me.cboTerminal.Name = "cboTerminal"
        Me.cboTerminal.Size = New System.Drawing.Size(189, 21)
        Me.cboTerminal.TabIndex = 296
        '
        'frmUpdateInBoundCY
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 193)
        Me.Controls.Add(Me.cboTerminal)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.dtpLeavingDate)
        Me.Name = "frmUpdateInBoundCY"
        Me.Text = "Update InBound CY (Import)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkFinalICD As System.Windows.Forms.CheckBox
    Friend WithEvents chkICDPort As System.Windows.Forms.CheckBox
    Friend WithEvents chkImportCY As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTerminal As System.Windows.Forms.ComboBox
End Class
