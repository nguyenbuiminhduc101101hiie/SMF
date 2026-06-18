<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintAllManifest
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
        Me.chkStep = New System.Windows.Forms.RadioButton
        Me.chkAll = New System.Windows.Forms.RadioButton
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpFromETA = New System.Windows.Forms.DateTimePicker
        Me.dtpToETA = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'chkStep
        '
        Me.chkStep.AutoSize = True
        Me.chkStep.Location = New System.Drawing.Point(289, 104)
        Me.chkStep.Name = "chkStep"
        Me.chkStep.Size = New System.Drawing.Size(86, 17)
        Me.chkStep.TabIndex = 2
        Me.chkStep.Text = "Step by Step"
        Me.chkStep.UseVisualStyleBackColor = True
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Checked = True
        Me.chkAll.Location = New System.Drawing.Point(150, 104)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(36, 17)
        Me.chkAll.TabIndex = 3
        Me.chkAll.TabStop = True
        Me.chkAll.Text = "All"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(271, 127)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(161, 127)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(80, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "From (ETA) :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(93, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "To(ETA) :"
        '
        'dtpFromETA
        '
        Me.dtpFromETA.Location = New System.Drawing.Point(148, 25)
        Me.dtpFromETA.Name = "dtpFromETA"
        Me.dtpFromETA.Size = New System.Drawing.Size(227, 20)
        Me.dtpFromETA.TabIndex = 15
        '
        'dtpToETA
        '
        Me.dtpToETA.Location = New System.Drawing.Point(148, 51)
        Me.dtpToETA.Name = "dtpToETA"
        Me.dtpToETA.Size = New System.Drawing.Size(227, 20)
        Me.dtpToETA.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Vessel /Voyno /ETA:"
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(148, 77)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(227, 21)
        Me.cboVessel.TabIndex = 12
        '
        'frmPrintAllManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(456, 162)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFromETA)
        Me.Controls.Add(Me.dtpToETA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkAll)
        Me.Controls.Add(Me.chkStep)
        Me.MaximizeBox = False
        Me.Name = "frmPrintAllManifest"
        Me.Text = "Printf Manifest Confirm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkStep As System.Windows.Forms.RadioButton
    Friend WithEvents chkAll As System.Windows.Forms.RadioButton
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpFromETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
End Class
