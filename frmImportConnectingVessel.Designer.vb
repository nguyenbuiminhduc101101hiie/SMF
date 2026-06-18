<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportConnectingVessel
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
        Me.grpInFo = New System.Windows.Forms.GroupBox
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.txtVoyNo = New System.Windows.Forms.TextBox
        Me.txtVessel = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtSheetname = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpETD = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdBrowser = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.prbExport = New System.Windows.Forms.ProgressBar
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.grpInFo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInFo
        '
        Me.grpInFo.Controls.Add(Me.GroupBox1)
        Me.grpInFo.Controls.Add(Me.txtFileName)
        Me.grpInFo.Controls.Add(Me.txtVoyNo)
        Me.grpInFo.Controls.Add(Me.txtVessel)
        Me.grpInFo.Controls.Add(Me.Label4)
        Me.grpInFo.Controls.Add(Me.txtSheetname)
        Me.grpInFo.Controls.Add(Me.Label3)
        Me.grpInFo.Controls.Add(Me.dtpETD)
        Me.grpInFo.Controls.Add(Me.Label5)
        Me.grpInFo.Controls.Add(Me.Label1)
        Me.grpInFo.Controls.Add(Me.Label2)
        Me.grpInFo.Controls.Add(Me.cmdCancel)
        Me.grpInFo.Controls.Add(Me.cmdBrowser)
        Me.grpInFo.Controls.Add(Me.cmdOk)
        Me.grpInFo.Location = New System.Drawing.Point(8, 11)
        Me.grpInFo.Name = "grpInFo"
        Me.grpInFo.Size = New System.Drawing.Size(542, 162)
        Me.grpInFo.TabIndex = 289
        Me.grpInFo.TabStop = False
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(77, 26)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(324, 20)
        Me.txtFileName.TabIndex = 3
        '
        'txtVoyNo
        '
        Me.txtVoyNo.Location = New System.Drawing.Point(325, 78)
        Me.txtVoyNo.Name = "txtVoyNo"
        Me.txtVoyNo.Size = New System.Drawing.Size(78, 20)
        Me.txtVoyNo.TabIndex = 3
        '
        'txtVessel
        '
        Me.txtVessel.Location = New System.Drawing.Point(77, 78)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(210, 20)
        Me.txtVessel.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(296, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No :"
        '
        'txtSheetname
        '
        Me.txtSheetname.Location = New System.Drawing.Point(77, 52)
        Me.txtSheetname.Name = "txtSheetname"
        Me.txtSheetname.Size = New System.Drawing.Size(210, 20)
        Me.txtSheetname.TabIndex = 3
        Me.txtSheetname.Text = "sheet1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(15, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Vessel :"
        '
        'dtpETD
        '
        Me.dtpETD.Location = New System.Drawing.Point(77, 104)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(210, 20)
        Me.dtpETD.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(40, 104)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "ETD :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(15, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "File Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(3, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sheet Name :"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(376, 128)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBrowser
        '
        Me.cmdBrowser.ForeColor = System.Drawing.Color.Maroon
        Me.cmdBrowser.Location = New System.Drawing.Point(431, 24)
        Me.cmdBrowser.Name = "cmdBrowser"
        Me.cmdBrowser.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowser.TabIndex = 0
        Me.cmdBrowser.Text = "&Browser"
        Me.cmdBrowser.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(457, 127)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.prbExport)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(110, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 89)
        Me.GroupBox1.TabIndex = 290
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Please wait"
        Me.GroupBox1.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(292, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 15)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "X"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(142, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "00%"
        '
        'prbExport
        '
        Me.prbExport.Location = New System.Drawing.Point(18, 34)
        Me.prbExport.Name = "prbExport"
        Me.prbExport.Size = New System.Drawing.Size(280, 13)
        Me.prbExport.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Excel Files (*.xls)|*.xls"
        '
        'frmImportConnectingVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 179)
        Me.Controls.Add(Me.grpInFo)
        Me.Name = "frmImportConnectingVessel"
        Me.Text = "Import Connecting Vessel"
        Me.grpInFo.ResumeLayout(False)
        Me.grpInFo.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpInFo As System.Windows.Forms.GroupBox
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents txtSheetname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVoyNo As System.Windows.Forms.TextBox
    Friend WithEvents txtVessel As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowser As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents prbExport As System.Windows.Forms.ProgressBar
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
