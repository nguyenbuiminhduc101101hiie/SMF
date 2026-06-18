<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmbookingEWDailyReport
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
        Me.cmdok = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboMotherVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboMarket = New System.Windows.Forms.ComboBox
        Me.dtpETD = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.chkeast = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'cmdok
        '
        Me.cmdok.Location = New System.Drawing.Point(375, 66)
        Me.cmdok.Name = "cmdok"
        Me.cmdok.Size = New System.Drawing.Size(75, 23)
        Me.cmdok.TabIndex = 0
        Me.cmdok.Text = "&Ok"
        Me.cmdok.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(285, 66)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboMotherVessel
        '
        Me.cboMotherVessel.FormattingEnabled = True
        Me.cboMotherVessel.Location = New System.Drawing.Point(160, 12)
        Me.cboMotherVessel.Name = "cboMotherVessel"
        Me.cboMotherVessel.Size = New System.Drawing.Size(290, 21)
        Me.cboMotherVessel.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(121, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Mother Vessel / Voyno :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(281, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Market :"
        '
        'cboMarket
        '
        Me.cboMarket.FormattingEnabled = True
        Me.cboMarket.Location = New System.Drawing.Point(329, 39)
        Me.cboMarket.Name = "cboMarket"
        Me.cboMarket.Size = New System.Drawing.Size(121, 21)
        Me.cboMarket.TabIndex = 1
        '
        'dtpETD
        '
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(160, 38)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(121, 20)
        Me.dtpETD.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(121, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "ETD :"
        '
        'chkeast
        '
        Me.chkeast.AutoSize = True
        Me.chkeast.Location = New System.Drawing.Point(39, 81)
        Me.chkeast.Name = "chkeast"
        Me.chkeast.Size = New System.Drawing.Size(81, 17)
        Me.chkeast.TabIndex = 5
        Me.chkeast.Text = "CheckBox1"
        Me.chkeast.UseVisualStyleBackColor = True
        '
        'frmbookingEWDailyReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 120)
        Me.Controls.Add(Me.chkeast)
        Me.Controls.Add(Me.dtpETD)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMarket)
        Me.Controls.Add(Me.cboMotherVessel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdok)
        Me.MinimumSize = New System.Drawing.Size(480, 154)
        Me.Name = "frmbookingEWDailyReport"
        Me.Text = "frmboookingEWDailyReport"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdok As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboMotherVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboMarket As System.Windows.Forms.ComboBox
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkeast As System.Windows.Forms.CheckBox
End Class
