<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTripAccountSummaryOutbound
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
        Me.components = New System.ComponentModel.Container
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cboNam = New System.Windows.Forms.ComboBox
        Me.cboThang = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboday = New System.Windows.Forms.ComboBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioEPay = New System.Windows.Forms.RadioButton
        Me.RadioEPre = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Navy
        Me.cmdCancel.Location = New System.Drawing.Point(279, 120)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 29
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Navy
        Me.cmdOk.Location = New System.Drawing.Point(360, 120)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 30
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboNam
        '
        Me.cboNam.FormattingEnabled = True
        Me.cboNam.Location = New System.Drawing.Point(366, 12)
        Me.cboNam.Name = "cboNam"
        Me.cboNam.Size = New System.Drawing.Size(69, 21)
        Me.cboNam.TabIndex = 28
        '
        'cboThang
        '
        Me.cboThang.FormattingEnabled = True
        Me.cboThang.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.cboThang.Location = New System.Drawing.Point(265, 12)
        Me.cboThang.Name = "cboThang"
        Me.cboThang.Size = New System.Drawing.Size(57, 21)
        Me.cboThang.TabIndex = 27
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(4, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 14)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Vessel / VoyNo / ETD :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cboVessel
        '
        Me.cboVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(131, 39)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(304, 21)
        Me.cboVessel.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(219, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Month :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(328, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Year :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(97, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Day :"
        '
        'cboday
        '
        Me.cboday.FormattingEnabled = True
        Me.cboday.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.cboday.Location = New System.Drawing.Point(133, 12)
        Me.cboday.Name = "cboday"
        Me.cboday.Size = New System.Drawing.Size(65, 21)
        Me.cboday.TabIndex = 27
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioEPay)
        Me.GroupBox1.Controls.Add(Me.RadioEPre)
        Me.GroupBox1.Location = New System.Drawing.Point(228, 66)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 48)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exchange"
        '
        'RadioEPay
        '
        Me.RadioEPay.AutoSize = True
        Me.RadioEPay.Location = New System.Drawing.Point(110, 21)
        Me.RadioEPay.Name = "RadioEPay"
        Me.RadioEPay.Size = New System.Drawing.Size(84, 17)
        Me.RadioEPay.TabIndex = 22
        Me.RadioEPay.Text = "Ex. Payment"
        Me.RadioEPay.UseVisualStyleBackColor = True
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
        'frmTripAccountSummaryOutbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(442, 153)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cboNam)
        Me.Controls.Add(Me.cboday)
        Me.Controls.Add(Me.cboThang)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmTripAccountSummaryOutbound"
        Me.Text = "Trip Account Summary Outbound"
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
    Friend WithEvents cboday As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioEPay As System.Windows.Forms.RadioButton
    Friend WithEvents RadioEPre As System.Windows.Forms.RadioButton
End Class
