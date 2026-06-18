<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmParaColor
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabGrid = New System.Windows.Forms.TabPage
        Me.cmdGridCancel = New System.Windows.Forms.Button
        Me.cmdGridOk = New System.Windows.Forms.Button
        Me.rdoFalse = New System.Windows.Forms.RadioButton
        Me.rdoTrue = New System.Windows.Forms.RadioButton
        Me.cboFont = New System.Windows.Forms.ComboBox
        Me.cboAlignCell = New System.Windows.Forms.ComboBox
        Me.cbosfrColor = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbosbkColor = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cbocfrColor = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbocbkColor = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cbobkColor = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.TabControl1.SuspendLayout()
        Me.tabGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabGrid)
        Me.TabControl1.Location = New System.Drawing.Point(2, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(371, 327)
        Me.TabControl1.TabIndex = 0
        '
        'tabGrid
        '
        Me.tabGrid.Controls.Add(Me.cmdGridCancel)
        Me.tabGrid.Controls.Add(Me.cmdGridOk)
        Me.tabGrid.Controls.Add(Me.rdoFalse)
        Me.tabGrid.Controls.Add(Me.rdoTrue)
        Me.tabGrid.Controls.Add(Me.cboFont)
        Me.tabGrid.Controls.Add(Me.cboAlignCell)
        Me.tabGrid.Controls.Add(Me.cbosfrColor)
        Me.tabGrid.Controls.Add(Me.Label8)
        Me.tabGrid.Controls.Add(Me.Label7)
        Me.tabGrid.Controls.Add(Me.Label6)
        Me.tabGrid.Controls.Add(Me.cbosbkColor)
        Me.tabGrid.Controls.Add(Me.Label5)
        Me.tabGrid.Controls.Add(Me.Label4)
        Me.tabGrid.Controls.Add(Me.cbocfrColor)
        Me.tabGrid.Controls.Add(Me.Label3)
        Me.tabGrid.Controls.Add(Me.cbocbkColor)
        Me.tabGrid.Controls.Add(Me.Label2)
        Me.tabGrid.Controls.Add(Me.cbobkColor)
        Me.tabGrid.Controls.Add(Me.Label1)
        Me.tabGrid.Location = New System.Drawing.Point(4, 22)
        Me.tabGrid.Name = "tabGrid"
        Me.tabGrid.Padding = New System.Windows.Forms.Padding(3)
        Me.tabGrid.Size = New System.Drawing.Size(363, 301)
        Me.tabGrid.TabIndex = 0
        Me.tabGrid.Text = "Grid"
        Me.tabGrid.UseVisualStyleBackColor = True
        '
        'cmdGridCancel
        '
        Me.cmdGridCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdGridCancel.ForeColor = System.Drawing.Color.Navy
        Me.cmdGridCancel.Location = New System.Drawing.Point(261, 257)
        Me.cmdGridCancel.Name = "cmdGridCancel"
        Me.cmdGridCancel.Size = New System.Drawing.Size(65, 21)
        Me.cmdGridCancel.TabIndex = 11
        Me.cmdGridCancel.Text = "Cancel"
        Me.cmdGridCancel.UseVisualStyleBackColor = True
        '
        'cmdGridOk
        '
        Me.cmdGridOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdGridOk.ForeColor = System.Drawing.Color.Navy
        Me.cmdGridOk.Location = New System.Drawing.Point(165, 257)
        Me.cmdGridOk.Name = "cmdGridOk"
        Me.cmdGridOk.Size = New System.Drawing.Size(65, 21)
        Me.cmdGridOk.TabIndex = 10
        Me.cmdGridOk.Text = "OK"
        Me.cmdGridOk.UseVisualStyleBackColor = True
        '
        'rdoFalse
        '
        Me.rdoFalse.AutoSize = True
        Me.rdoFalse.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoFalse.Location = New System.Drawing.Point(230, 183)
        Me.rdoFalse.Name = "rdoFalse"
        Me.rdoFalse.Size = New System.Drawing.Size(50, 17)
        Me.rdoFalse.TabIndex = 9
        Me.rdoFalse.Text = "False"
        Me.rdoFalse.UseVisualStyleBackColor = True
        '
        'rdoTrue
        '
        Me.rdoTrue.AutoSize = True
        Me.rdoTrue.Checked = True
        Me.rdoTrue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rdoTrue.Location = New System.Drawing.Point(165, 183)
        Me.rdoTrue.Name = "rdoTrue"
        Me.rdoTrue.Size = New System.Drawing.Size(47, 17)
        Me.rdoTrue.TabIndex = 8
        Me.rdoTrue.TabStop = True
        Me.rdoTrue.Text = "True"
        Me.rdoTrue.UseVisualStyleBackColor = True
        '
        'cboFont
        '
        Me.cboFont.DropDownHeight = 1
        Me.cboFont.FormattingEnabled = True
        Me.cboFont.IntegralHeight = False
        Me.cboFont.Location = New System.Drawing.Point(165, 206)
        Me.cboFont.Name = "cboFont"
        Me.cboFont.Size = New System.Drawing.Size(161, 21)
        Me.cboFont.TabIndex = 7
        '
        'cboAlignCell
        '
        Me.cboAlignCell.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlignCell.FormattingEnabled = True
        Me.cboAlignCell.IntegralHeight = False
        Me.cboAlignCell.Items.AddRange(New Object() {"NotSet", "TopLeft", "TopCenter", "TopRight", "MiddleLeft", "MiddleCenter", "MiddleRight", "BottomLeft", "BottomCenter", "BottomRight"})
        Me.cboAlignCell.Location = New System.Drawing.Point(165, 152)
        Me.cboAlignCell.Name = "cboAlignCell"
        Me.cboAlignCell.Size = New System.Drawing.Size(161, 21)
        Me.cboAlignCell.TabIndex = 7
        '
        'cbosfrColor
        '
        Me.cbosfrColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbosfrColor.DropDownHeight = 1
        Me.cbosfrColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosfrColor.FormattingEnabled = True
        Me.cbosfrColor.IntegralHeight = False
        Me.cbosfrColor.Location = New System.Drawing.Point(165, 125)
        Me.cbosfrColor.Name = "cbosfrColor"
        Me.cbosfrColor.Size = New System.Drawing.Size(161, 21)
        Me.cbosfrColor.TabIndex = 6
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(99, 209)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Font Cell :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(85, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(75, 15)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Resize Cell :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(68, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Alignment Cell :"
        '
        'cbosbkColor
        '
        Me.cbosbkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbosbkColor.DropDownHeight = 1
        Me.cbosbkColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbosbkColor.FormattingEnabled = True
        Me.cbosbkColor.IntegralHeight = False
        Me.cbosbkColor.Location = New System.Drawing.Point(165, 98)
        Me.cbosbkColor.Name = "cbosbkColor"
        Me.cbosbkColor.Size = New System.Drawing.Size(161, 21)
        Me.cbosbkColor.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(6, 127)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Selection Letter Color Cell :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(9, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Selection Back Color Cell :"
        '
        'cbocfrColor
        '
        Me.cbocfrColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocfrColor.DropDownHeight = 1
        Me.cbocfrColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocfrColor.FormattingEnabled = True
        Me.cbocfrColor.IntegralHeight = False
        Me.cbocfrColor.Location = New System.Drawing.Point(165, 71)
        Me.cbocfrColor.Name = "cbocfrColor"
        Me.cbocfrColor.Size = New System.Drawing.Size(161, 21)
        Me.cbocfrColor.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(60, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Letter Color Cell :"
        '
        'cbocbkColor
        '
        Me.cbocbkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbocbkColor.DropDownHeight = 1
        Me.cbocbkColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocbkColor.FormattingEnabled = True
        Me.cbocbkColor.IntegralHeight = False
        Me.cbocbkColor.Location = New System.Drawing.Point(165, 44)
        Me.cbocbkColor.Name = "cbocbkColor"
        Me.cbocbkColor.Size = New System.Drawing.Size(161, 21)
        Me.cbocbkColor.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(67, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "BackColor Cell :"
        '
        'cbobkColor
        '
        Me.cbobkColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cbobkColor.DropDownHeight = 1
        Me.cbobkColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbobkColor.FormattingEnabled = True
        Me.cbobkColor.IntegralHeight = False
        Me.cbobkColor.Location = New System.Drawing.Point(165, 17)
        Me.cbobkColor.Name = "cbobkColor"
        Me.cbobkColor.Size = New System.Drawing.Size(161, 21)
        Me.cbobkColor.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(49, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Background Color :"
        '
        'frmParaColor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(375, 333)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmParaColor"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Option"
        Me.TabControl1.ResumeLayout(False)
        Me.tabGrid.ResumeLayout(False)
        Me.tabGrid.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabGrid As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents cbobkColor As System.Windows.Forms.ComboBox
    Friend WithEvents cbosbkColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbocfrColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbocbkColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbosfrColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboAlignCell As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdGridCancel As System.Windows.Forms.Button
    Friend WithEvents cmdGridOk As System.Windows.Forms.Button
    Friend WithEvents rdoFalse As System.Windows.Forms.RadioButton
    Friend WithEvents rdoTrue As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboFont As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
End Class
