<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckEDI
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
        Me.txtEDi1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdBrowser1 = New System.Windows.Forms.Button
        Me.txtEDI2 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdBrowser2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.rtEDI2 = New System.Windows.Forms.RichTextBox
        Me.rtEDI1 = New System.Windows.Forms.RichTextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtEDi1
        '
        Me.txtEDi1.Location = New System.Drawing.Point(104, 20)
        Me.txtEDi1.Name = "txtEDi1"
        Me.txtEDi1.Size = New System.Drawing.Size(480, 20)
        Me.txtEDi1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "EDI 1(Text File) :"
        '
        'cmdBrowser1
        '
        Me.cmdBrowser1.Location = New System.Drawing.Point(605, 17)
        Me.cmdBrowser1.Name = "cmdBrowser1"
        Me.cmdBrowser1.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowser1.TabIndex = 2
        Me.cmdBrowser1.Text = "Browser"
        Me.cmdBrowser1.UseVisualStyleBackColor = True
        '
        'txtEDI2
        '
        Me.txtEDI2.Location = New System.Drawing.Point(104, 49)
        Me.txtEDI2.Name = "txtEDI2"
        Me.txtEDI2.Size = New System.Drawing.Size(480, 20)
        Me.txtEDI2.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "EDI 2(Text File) :"
        '
        'cmdBrowser2
        '
        Me.cmdBrowser2.Location = New System.Drawing.Point(605, 47)
        Me.cmdBrowser2.Name = "cmdBrowser2"
        Me.cmdBrowser2.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowser2.TabIndex = 2
        Me.cmdBrowser2.Text = "Browser"
        Me.cmdBrowser2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "EDI 1(Text File)  Content"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 11)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "EDI 2(Text File)  Content"
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(327, 88)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(436, 88)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'rtEDI2
        '
        Me.rtEDI2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtEDI2.Location = New System.Drawing.Point(3, 27)
        Me.rtEDI2.Name = "rtEDI2"
        Me.rtEDI2.Size = New System.Drawing.Size(432, 324)
        Me.rtEDI2.TabIndex = 3
        Me.rtEDI2.Text = ""
        '
        'rtEDI1
        '
        Me.rtEDI1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtEDI1.Location = New System.Drawing.Point(7, 27)
        Me.rtEDI1.Name = "rtEDI1"
        Me.rtEDI1.Size = New System.Drawing.Size(401, 324)
        Me.rtEDI1.TabIndex = 3
        Me.rtEDI1.Text = ""
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "EDI.txt"
        Me.OpenFileDialog1.Filter = "text files(*.txt) |*.txt"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(20, 117)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtEDI1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.rtEDI2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Size = New System.Drawing.Size(867, 358)
        Me.SplitContainer1.SplitterDistance = 415
        Me.SplitContainer1.TabIndex = 4
        '
        'frmCheckEDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 487)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdBrowser2)
        Me.Controls.Add(Me.cmdBrowser1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtEDI2)
        Me.Controls.Add(Me.txtEDi1)
        Me.Name = "frmCheckEDI"
        Me.Text = "Check EDI "
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtEDi1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowser1 As System.Windows.Forms.Button
    Friend WithEvents txtEDI2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdBrowser2 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents rtEDI2 As System.Windows.Forms.RichTextBox
    Friend WithEvents rtEDI1 As System.Windows.Forms.RichTextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
End Class
