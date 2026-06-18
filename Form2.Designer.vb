<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.fraFreightNote = New System.Windows.Forms.GroupBox
        Me.chkPrepaid = New System.Windows.Forms.RadioButton
        Me.chkCollect = New System.Windows.Forms.RadioButton
        Me.cmdCancelFreightnote = New System.Windows.Forms.Button
        Me.cmdOkFreightNote = New System.Windows.Forms.Button
        Me.txtMessrs = New System.Windows.Forms.TextBox
        Me.txtTaxCode = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.fraFreightNote.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraFreightNote
        '
        Me.fraFreightNote.BackColor = System.Drawing.Color.LightCoral
        Me.fraFreightNote.Controls.Add(Me.chkPrepaid)
        Me.fraFreightNote.Controls.Add(Me.chkCollect)
        Me.fraFreightNote.Controls.Add(Me.cmdCancelFreightnote)
        Me.fraFreightNote.Controls.Add(Me.cmdOkFreightNote)
        Me.fraFreightNote.Controls.Add(Me.txtMessrs)
        Me.fraFreightNote.Controls.Add(Me.txtTaxCode)
        Me.fraFreightNote.Controls.Add(Me.Label30)
        Me.fraFreightNote.Controls.Add(Me.Label26)
        Me.fraFreightNote.ForeColor = System.Drawing.Color.Blue
        Me.fraFreightNote.Location = New System.Drawing.Point(81, 12)
        Me.fraFreightNote.Name = "fraFreightNote"
        Me.fraFreightNote.Size = New System.Drawing.Size(467, 248)
        Me.fraFreightNote.TabIndex = 167
        Me.fraFreightNote.TabStop = False
        Me.fraFreightNote.Text = "Freight Note Info"
        Me.fraFreightNote.Visible = False
        '
        'chkPrepaid
        '
        Me.chkPrepaid.AutoSize = True
        Me.chkPrepaid.Location = New System.Drawing.Point(67, 187)
        Me.chkPrepaid.Name = "chkPrepaid"
        Me.chkPrepaid.Size = New System.Drawing.Size(61, 17)
        Me.chkPrepaid.TabIndex = 7
        Me.chkPrepaid.TabStop = True
        Me.chkPrepaid.Text = "Prepaid"
        Me.chkPrepaid.UseVisualStyleBackColor = True
        '
        'chkCollect
        '
        Me.chkCollect.AutoSize = True
        Me.chkCollect.Location = New System.Drawing.Point(286, 186)
        Me.chkCollect.Name = "chkCollect"
        Me.chkCollect.Size = New System.Drawing.Size(57, 17)
        Me.chkCollect.TabIndex = 6
        Me.chkCollect.TabStop = True
        Me.chkCollect.Text = "Collect"
        Me.chkCollect.UseVisualStyleBackColor = True
        '
        'cmdCancelFreightnote
        '
        Me.cmdCancelFreightnote.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.cmdCancelFreightnote.Location = New System.Drawing.Point(301, 219)
        Me.cmdCancelFreightnote.Name = "cmdCancelFreightnote"
        Me.cmdCancelFreightnote.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelFreightnote.TabIndex = 5
        Me.cmdCancelFreightnote.Text = "&Cancel"
        Me.cmdCancelFreightnote.UseVisualStyleBackColor = False
        '
        'cmdOkFreightNote
        '
        Me.cmdOkFreightNote.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.cmdOkFreightNote.Location = New System.Drawing.Point(124, 219)
        Me.cmdOkFreightNote.Name = "cmdOkFreightNote"
        Me.cmdOkFreightNote.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkFreightNote.TabIndex = 5
        Me.cmdOkFreightNote.Text = "&Ok"
        Me.cmdOkFreightNote.UseVisualStyleBackColor = False
        '
        'txtMessrs
        '
        Me.txtMessrs.Location = New System.Drawing.Point(67, 14)
        Me.txtMessrs.Multiline = True
        Me.txtMessrs.Name = "txtMessrs"
        Me.txtMessrs.Size = New System.Drawing.Size(388, 127)
        Me.txtMessrs.TabIndex = 4
        '
        'txtTaxCode
        '
        Me.txtTaxCode.Location = New System.Drawing.Point(67, 152)
        Me.txtTaxCode.Name = "txtTaxCode"
        Me.txtTaxCode.Size = New System.Drawing.Size(388, 20)
        Me.txtTaxCode.TabIndex = 3
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(5, 156)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(59, 13)
        Me.Label30.TabIndex = 2
        Me.Label30.Text = "Tax Code :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(4, 16)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(58, 13)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "MESSRS :"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1196, 514)
        Me.Controls.Add(Me.fraFreightNote)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.fraFreightNote.ResumeLayout(False)
        Me.fraFreightNote.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fraFreightNote As System.Windows.Forms.GroupBox
    Friend WithEvents chkPrepaid As System.Windows.Forms.RadioButton
    Friend WithEvents chkCollect As System.Windows.Forms.RadioButton
    Friend WithEvents cmdCancelFreightnote As System.Windows.Forms.Button
    Friend WithEvents cmdOkFreightNote As System.Windows.Forms.Button
    Friend WithEvents txtMessrs As System.Windows.Forms.TextBox
    Friend WithEvents txtTaxCode As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
End Class
