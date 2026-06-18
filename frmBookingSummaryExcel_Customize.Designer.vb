<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingSummaryExcel_Customize
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboWeekOfYear1 = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFrom1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtTo1 = New System.Windows.Forms.TextBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboYear1 = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtTo2 = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFrom2 = New System.Windows.Forms.TextBox
        Me.cboWeekOfYear2 = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboYear2 = New System.Windows.Forms.ComboBox
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Week Of Year :"
        '
        'cboWeekOfYear1
        '
        Me.cboWeekOfYear1.FormattingEnabled = True
        Me.cboWeekOfYear1.Location = New System.Drawing.Point(97, 22)
        Me.cboWeekOfYear1.Name = "cboWeekOfYear1"
        Me.cboWeekOfYear1.Size = New System.Drawing.Size(99, 21)
        Me.cboWeekOfYear1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "From :"
        '
        'txtFrom1
        '
        Me.txtFrom1.Location = New System.Drawing.Point(96, 52)
        Me.txtFrom1.Name = "txtFrom1"
        Me.txtFrom1.Size = New System.Drawing.Size(100, 20)
        Me.txtFrom1.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(219, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To :"
        '
        'txtTo1
        '
        Me.txtTo1.Location = New System.Drawing.Point(246, 54)
        Me.txtTo1.Name = "txtTo1"
        Me.txtTo1.Size = New System.Drawing.Size(100, 20)
        Me.txtTo1.TabIndex = 4
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(334, 211)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 22)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(253, 211)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 22)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(208, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Year :"
        '
        'cboYear1
        '
        Me.cboYear1.FormattingEnabled = True
        Me.cboYear1.Location = New System.Drawing.Point(246, 19)
        Me.cboYear1.Name = "cboYear1"
        Me.cboYear1.Size = New System.Drawing.Size(100, 21)
        Me.cboYear1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTo1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtFrom1)
        Me.GroupBox1.Controls.Add(Me.cboWeekOfYear1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cboYear1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 91)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Week 1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTo2)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtFrom2)
        Me.GroupBox2.Controls.Add(Me.cboWeekOfYear2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.cboYear2)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(402, 91)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Week 2"
        '
        'txtTo2
        '
        Me.txtTo2.Location = New System.Drawing.Point(246, 54)
        Me.txtTo2.Name = "txtTo2"
        Me.txtTo2.Size = New System.Drawing.Size(100, 20)
        Me.txtTo2.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(219, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "To :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Week Of Year :"
        '
        'txtFrom2
        '
        Me.txtFrom2.Location = New System.Drawing.Point(96, 52)
        Me.txtFrom2.Name = "txtFrom2"
        Me.txtFrom2.Size = New System.Drawing.Size(100, 20)
        Me.txtFrom2.TabIndex = 4
        '
        'cboWeekOfYear2
        '
        Me.cboWeekOfYear2.FormattingEnabled = True
        Me.cboWeekOfYear2.Location = New System.Drawing.Point(97, 22)
        Me.cboWeekOfYear2.Name = "cboWeekOfYear2"
        Me.cboWeekOfYear2.Size = New System.Drawing.Size(99, 21)
        Me.cboWeekOfYear2.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(58, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "From :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(208, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Year :"
        '
        'cboYear2
        '
        Me.cboYear2.FormattingEnabled = True
        Me.cboYear2.Location = New System.Drawing.Point(246, 19)
        Me.cboYear2.Name = "cboYear2"
        Me.cboYear2.Size = New System.Drawing.Size(100, 21)
        Me.cboYear2.TabIndex = 2
        '
        'frmBookingSummaryExcel_Customize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 239)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdOk)
        Me.Name = "frmBookingSummaryExcel_Customize"
        Me.Text = "Booking Summary (China)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboWeekOfYear1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtFrom1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtTo1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboYear1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFrom2 As System.Windows.Forms.TextBox
    Friend WithEvents cboWeekOfYear2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboYear2 As System.Windows.Forms.ComboBox
End Class
