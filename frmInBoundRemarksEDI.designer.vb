<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInBoundRemarksEDI
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtBLIB_NO = New System.Windows.Forms.TextBox
        Me.dtpArrival = New System.Windows.Forms.DateTimePicker
        Me.dtpDemurage = New System.Windows.Forms.DateTimePicker
        Me.chkPrint = New System.Windows.Forms.CheckBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtPre_Col = New System.Windows.Forms.TextBox
        Me.cmdRptFormData = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpPrintdate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.cboportshipment = New System.Windows.Forms.ComboBox
        Me.txtPOD = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtDel = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtDest = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(13, 138)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Vessel Arrial date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(13, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(88, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Demurrate Date :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.Location = New System.Drawing.Point(243, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Prepaid Or Collect"
        '
        'txtBLIB_NO
        '
        Me.txtBLIB_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBLIB_NO.Enabled = False
        Me.txtBLIB_NO.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBLIB_NO.Location = New System.Drawing.Point(4, 1)
        Me.txtBLIB_NO.Name = "txtBLIB_NO"
        Me.txtBLIB_NO.Size = New System.Drawing.Size(332, 38)
        Me.txtBLIB_NO.TabIndex = 13
        '
        'dtpArrival
        '
        Me.dtpArrival.Location = New System.Drawing.Point(16, 154)
        Me.dtpArrival.Name = "dtpArrival"
        Me.dtpArrival.Size = New System.Drawing.Size(202, 20)
        Me.dtpArrival.TabIndex = 14
        '
        'dtpDemurage
        '
        Me.dtpDemurage.Location = New System.Drawing.Point(16, 202)
        Me.dtpDemurage.Name = "dtpDemurage"
        Me.dtpDemurage.Size = New System.Drawing.Size(202, 20)
        Me.dtpDemurage.TabIndex = 14
        '
        'chkPrint
        '
        Me.chkPrint.AutoSize = True
        Me.chkPrint.Checked = True
        Me.chkPrint.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrint.ForeColor = System.Drawing.Color.Blue
        Me.chkPrint.Location = New System.Drawing.Point(224, 205)
        Me.chkPrint.Name = "chkPrint"
        Me.chkPrint.Size = New System.Drawing.Size(53, 17)
        Me.chkPrint.TabIndex = 15
        Me.chkPrint.Text = "(Print)"
        Me.chkPrint.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(181, 275)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 16
        Me.cmdOk.Text = "&Review"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(262, 275)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 17
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtPre_Col
        '
        Me.txtPre_Col.Location = New System.Drawing.Point(239, 175)
        Me.txtPre_Col.Name = "txtPre_Col"
        Me.txtPre_Col.Size = New System.Drawing.Size(100, 20)
        Me.txtPre_Col.TabIndex = 18
        '
        'cmdRptFormData
        '
        Me.cmdRptFormData.ForeColor = System.Drawing.Color.Maroon
        Me.cmdRptFormData.Location = New System.Drawing.Point(16, 275)
        Me.cmdRptFormData.Name = "cmdRptFormData"
        Me.cmdRptFormData.Size = New System.Drawing.Size(109, 23)
        Me.cmdRptFormData.TabIndex = 19
        Me.cmdRptFormData.Text = "&Review data only"
        Me.cmdRptFormData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(13, 231)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Print Date :"
        '
        'dtpPrintdate
        '
        Me.dtpPrintdate.Location = New System.Drawing.Point(16, 247)
        Me.dtpPrintdate.Name = "dtpPrintdate"
        Me.dtpPrintdate.Size = New System.Drawing.Size(202, 20)
        Me.dtpPrintdate.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(262, 231)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Send"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"The First Notice", "The Second Notice", "The Third Notice"})
        Me.ComboBox1.Location = New System.Drawing.Point(237, 247)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(100, 21)
        Me.ComboBox1.TabIndex = 20
        Me.ComboBox1.Text = "The First Notice"
        '
        'cboportshipment
        '
        Me.cboportshipment.FormattingEnabled = True
        Me.cboportshipment.Items.AddRange(New Object() {"CAT LAI", "NEW PORT", "SONG THAN", "PHUOC LONG", "PHUC LONG", "KHANH HOI", "TRANSIMEX", "BIEN HOA"})
        Me.cboportshipment.Location = New System.Drawing.Point(237, 116)
        Me.cboportshipment.Name = "cboportshipment"
        Me.cboportshipment.Size = New System.Drawing.Size(100, 21)
        Me.cboportshipment.TabIndex = 20
        Me.cboportshipment.Text = "CAT LAI"
        '
        'txtPOD
        '
        Me.txtPOD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPOD.Location = New System.Drawing.Point(38, 45)
        Me.txtPOD.Name = "txtPOD"
        Me.txtPOD.Size = New System.Drawing.Size(298, 13)
        Me.txtPOD.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(1, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "POD :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.Location = New System.Drawing.Point(1, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "DEL :"
        '
        'txtDel
        '
        Me.txtDel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDel.Location = New System.Drawing.Point(38, 71)
        Me.txtDel.Name = "txtDel"
        Me.txtDel.Size = New System.Drawing.Size(298, 13)
        Me.txtDel.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.Location = New System.Drawing.Point(1, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Dest :"
        '
        'txtDest
        '
        Me.txtDest.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDest.Location = New System.Drawing.Point(38, 97)
        Me.txtDest.Name = "txtDest"
        Me.txtDest.Size = New System.Drawing.Size(298, 13)
        Me.txtDest.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.Location = New System.Drawing.Point(183, 120)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "ICD Port :"
        '
        'frmInBoundRemarksEDI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 310)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDest)
        Me.Controls.Add(Me.txtDel)
        Me.Controls.Add(Me.txtPOD)
        Me.Controls.Add(Me.cboportshipment)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.cmdRptFormData)
        Me.Controls.Add(Me.txtPre_Col)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.chkPrint)
        Me.Controls.Add(Me.dtpPrintdate)
        Me.Controls.Add(Me.dtpDemurage)
        Me.Controls.Add(Me.dtpArrival)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBLIB_NO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmInBoundRemarksEDI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InBound Remarks"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBLIB_NO As System.Windows.Forms.TextBox
    Friend WithEvents dtpArrival As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpDemurage As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkPrint As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents txtPre_Col As System.Windows.Forms.TextBox
    Friend WithEvents cmdRptFormData As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpPrintdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents cboportshipment As System.Windows.Forms.ComboBox
    Friend WithEvents txtPOD As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDel As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDest As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
