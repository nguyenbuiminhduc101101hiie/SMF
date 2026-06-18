<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTripAccountOutbound
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
        Me.cboNam = New System.Windows.Forms.ComboBox
        Me.cboThang = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtDay = New System.Windows.Forms.ComboBox
        Me.RadioEPre = New System.Windows.Forms.RadioButton
        Me.RadioEPay = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Navy
        Me.cmdCancel.Location = New System.Drawing.Point(287, 128)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Navy
        Me.cmdOk.Location = New System.Drawing.Point(368, 128)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 20
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboNam
        '
        Me.cboNam.FormattingEnabled = True
        Me.cboNam.Location = New System.Drawing.Point(373, 13)
        Me.cboNam.Name = "cboNam"
        Me.cboNam.Size = New System.Drawing.Size(70, 21)
        Me.cboNam.TabIndex = 18
        '
        'cboThang
        '
        Me.cboThang.FormattingEnabled = True
        Me.cboThang.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboThang.Location = New System.Drawing.Point(259, 13)
        Me.cboThang.Name = "cboThang"
        Me.cboThang.Size = New System.Drawing.Size(70, 21)
        Me.cboThang.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(0, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(136, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Vessel / VoyNo / ETD :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboVessel
        '
        Me.cboVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(139, 40)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(304, 21)
        Me.cboVessel.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(212, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Month :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(335, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Year :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(106, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Day :"
        '
        'txtDay
        '
        Me.txtDay.FormattingEnabled = True
        Me.txtDay.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.txtDay.Location = New System.Drawing.Point(139, 13)
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(70, 21)
        Me.txtDay.TabIndex = 17
        '
        'RadioEPre
        '
        Me.RadioEPre.AutoSize = True
        Me.RadioEPre.Checked = True
        Me.RadioEPre.Location = New System.Drawing.Point(17, 21)
        Me.RadioEPre.Name = "RadioEPre"
        Me.RadioEPre.Size = New System.Drawing.Size(79, 17)
        Me.RadioEPre.TabIndex = 21
        Me.RadioEPre.TabStop = True
        Me.RadioEPre.Text = "Ex. Present"
        Me.RadioEPre.UseVisualStyleBackColor = True
        '
        'RadioEPay
        '
        Me.RadioEPay.AutoSize = True
        Me.RadioEPay.Location = New System.Drawing.Point(110, 21)
        Me.RadioEPay.Name = "RadioEPay"
        Me.RadioEPay.Size = New System.Drawing.Size(84, 17)
        Me.RadioEPay.TabIndex = 22
        Me.RadioEPay.TabStop = True
        Me.RadioEPay.Text = "Ex. Payment"
        Me.RadioEPay.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioEPay)
        Me.GroupBox1.Controls.Add(Me.RadioEPre)
        Me.GroupBox1.Location = New System.Drawing.Point(236, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 48)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exchange"
        '
        'frmTripAccountOutbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 163)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cboNam)
        Me.Controls.Add(Me.txtDay)
        Me.Controls.Add(Me.cboThang)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTripAccountOutbound"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Trip Acount Outbound"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboNam As System.Windows.Forms.ComboBox
    Friend WithEvents cboThang As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.ComboBox
    Friend WithEvents RadioEPre As System.Windows.Forms.RadioButton
    Friend WithEvents RadioEPay As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
