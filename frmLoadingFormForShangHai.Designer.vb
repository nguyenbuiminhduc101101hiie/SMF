<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadingFormForShangHai
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
        Me.dtpLeavingDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpLeavingDate.Location = New System.Drawing.Point(94, 51)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(103, 20)
        Me.dtpLeavingDate.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(56, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ETD :"
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(94, 12)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(243, 21)
        Me.cboVessel.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Vessel - VoyNo :"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(209, 85)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(290, 85)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 6
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmLoadingFormForShangHai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 117)
        Me.Controls.Add(Me.dtpLeavingDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Name = "frmLoadingFormForShangHai"
        Me.Text = "Loading Form For ShangHai"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
End Class
