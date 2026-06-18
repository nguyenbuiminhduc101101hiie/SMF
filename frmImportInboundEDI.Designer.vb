<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportInboundEDI
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
        Me.cmdBrowser = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboICDPort = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpETA = New System.Windows.Forms.DateTimePicker
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.lblVessel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtVoyNo = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'cmdBrowser
        '
        Me.cmdBrowser.Location = New System.Drawing.Point(464, 10)
        Me.cmdBrowser.Name = "cmdBrowser"
        Me.cmdBrowser.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowser.TabIndex = 0
        Me.cmdBrowser.Text = "&Browser"
        Me.cmdBrowser.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File Name :"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(70, 12)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(388, 20)
        Me.txtFileName.TabIndex = 2
        Me.txtFileName.Text = "C:\Documents and Settings\Long.CA\Desktop\03-11-2007.txt"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(383, 118)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(302, 117)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "ICD Port :"
        '
        'cboICDPort
        '
        Me.cboICDPort.FormattingEnabled = True
        Me.cboICDPort.Location = New System.Drawing.Point(70, 75)
        Me.cboICDPort.Name = "cboICDPort"
        Me.cboICDPort.Size = New System.Drawing.Size(210, 21)
        Me.cboICDPort.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(298, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "ETA :"
        '
        'dtpETA
        '
        Me.dtpETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETA.Location = New System.Drawing.Point(334, 71)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(124, 20)
        Me.dtpETA.TabIndex = 8
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(70, 38)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(210, 21)
        Me.cboVessel.TabIndex = 291
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.BackColor = System.Drawing.Color.Transparent
        Me.lblVessel.ForeColor = System.Drawing.Color.Black
        Me.lblVessel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVessel.Location = New System.Drawing.Point(25, 40)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(44, 13)
        Me.lblVessel.TabIndex = 292
        Me.lblVessel.Text = "Vessel :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(283, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Voy No. :"
        '
        'txtVoyNo
        '
        Me.txtVoyNo.Location = New System.Drawing.Point(334, 40)
        Me.txtVoyNo.Name = "txtVoyNo"
        Me.txtVoyNo.Size = New System.Drawing.Size(124, 20)
        Me.txtVoyNo.TabIndex = 2
        '
        'frmImportInboundEDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(569, 183)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.dtpETA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboICDPort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.txtVoyNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdBrowser)
        Me.Name = "frmImportInboundEDI"
        Me.Text = "Import EDI Manifest (Inbound)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdBrowser As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboICDPort As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtVoyNo As System.Windows.Forms.TextBox
End Class
