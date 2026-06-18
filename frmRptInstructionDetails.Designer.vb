<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptInstructionDetails
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
        Me.ReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdViewCBM = New System.Windows.Forms.CheckBox
        Me.chkViewMArks = New System.Windows.Forms.CheckBox
        Me.chkthreenill = New System.Windows.Forms.CheckBox
        Me.cmdrefresh = New System.Windows.Forms.Button
        Me.chkViewPC = New System.Windows.Forms.CheckBox
        Me.chkviewfreight = New System.Windows.Forms.CheckBox
        Me.chkviewnote = New System.Windows.Forms.CheckBox
        Me.chkViewTotal = New System.Windows.Forms.CheckBox
        Me.chkPrintAttachList = New System.Windows.Forms.CheckBox
        Me.cboAttach = New System.Windows.Forms.ComboBox
        Me.cboBillType = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'ReportViewer
        '
        Me.ReportViewer.ActiveViewIndex = -1
        Me.ReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ReportViewer.DisplayGroupTree = False
        Me.ReportViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer.Name = "ReportViewer"
        Me.ReportViewer.SelectionFormula = ""
        Me.ReportViewer.Size = New System.Drawing.Size(1028, 651)
        Me.ReportViewer.TabIndex = 1
        Me.ReportViewer.ViewTimeSelectionFormula = ""
        '
        'cmdViewCBM
        '
        Me.cmdViewCBM.AutoSize = True
        Me.cmdViewCBM.Checked = True
        Me.cmdViewCBM.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cmdViewCBM.Location = New System.Drawing.Point(624, 30)
        Me.cmdViewCBM.Name = "cmdViewCBM"
        Me.cmdViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.cmdViewCBM.TabIndex = 26
        Me.cmdViewCBM.Text = "View CBM"
        Me.cmdViewCBM.UseVisualStyleBackColor = True
        '
        'chkViewMArks
        '
        Me.chkViewMArks.AutoSize = True
        Me.chkViewMArks.Location = New System.Drawing.Point(857, 32)
        Me.chkViewMArks.Name = "chkViewMArks"
        Me.chkViewMArks.Size = New System.Drawing.Size(68, 17)
        Me.chkViewMArks.TabIndex = 25
        Me.chkViewMArks.Text = "V. Marks"
        Me.chkViewMArks.UseVisualStyleBackColor = True
        Me.chkViewMArks.Visible = False
        '
        'chkthreenill
        '
        Me.chkthreenill.AutoSize = True
        Me.chkthreenill.Location = New System.Drawing.Point(779, 30)
        Me.chkthreenill.Name = "chkthreenill"
        Me.chkthreenill.Size = New System.Drawing.Size(66, 17)
        Me.chkthreenill.TabIndex = 24
        Me.chkthreenill.Text = "Three(3)"
        Me.chkthreenill.UseVisualStyleBackColor = True
        Me.chkthreenill.Visible = False
        '
        'cmdrefresh
        '
        Me.cmdrefresh.Location = New System.Drawing.Point(465, 30)
        Me.cmdrefresh.Name = "cmdrefresh"
        Me.cmdrefresh.Size = New System.Drawing.Size(60, 25)
        Me.cmdrefresh.TabIndex = 23
        Me.cmdrefresh.Text = "Refresh"
        Me.cmdrefresh.UseVisualStyleBackColor = True
        '
        'chkViewPC
        '
        Me.chkViewPC.AutoSize = True
        Me.chkViewPC.Checked = True
        Me.chkViewPC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewPC.Location = New System.Drawing.Point(705, 30)
        Me.chkViewPC.Name = "chkViewPC"
        Me.chkViewPC.Size = New System.Drawing.Size(71, 17)
        Me.chkViewPC.TabIndex = 22
        Me.chkViewPC.Text = "View P/C"
        Me.chkViewPC.UseVisualStyleBackColor = True
        '
        'chkviewfreight
        '
        Me.chkviewfreight.AutoSize = True
        Me.chkviewfreight.Checked = True
        Me.chkviewfreight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkviewfreight.Location = New System.Drawing.Point(856, 8)
        Me.chkviewfreight.Name = "chkviewfreight"
        Me.chkviewfreight.Size = New System.Drawing.Size(84, 17)
        Me.chkviewfreight.TabIndex = 21
        Me.chkviewfreight.Text = "View Freight"
        Me.chkviewfreight.UseVisualStyleBackColor = True
        '
        'chkviewnote
        '
        Me.chkviewnote.AutoSize = True
        Me.chkviewnote.Checked = True
        Me.chkviewnote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkviewnote.Location = New System.Drawing.Point(778, 8)
        Me.chkviewnote.Name = "chkviewnote"
        Me.chkviewnote.Size = New System.Drawing.Size(75, 17)
        Me.chkviewnote.TabIndex = 20
        Me.chkviewnote.Text = "View Note"
        Me.chkviewnote.UseVisualStyleBackColor = True
        '
        'chkViewTotal
        '
        Me.chkViewTotal.AutoSize = True
        Me.chkViewTotal.Checked = True
        Me.chkViewTotal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewTotal.Location = New System.Drawing.Point(705, 7)
        Me.chkViewTotal.Name = "chkViewTotal"
        Me.chkViewTotal.Size = New System.Drawing.Size(72, 17)
        Me.chkViewTotal.TabIndex = 19
        Me.chkViewTotal.Text = "View total"
        Me.chkViewTotal.UseVisualStyleBackColor = True
        '
        'chkPrintAttachList
        '
        Me.chkPrintAttachList.AutoSize = True
        Me.chkPrintAttachList.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.chkPrintAttachList.Location = New System.Drawing.Point(359, 7)
        Me.chkPrintAttachList.Name = "chkPrintAttachList"
        Me.chkPrintAttachList.Size = New System.Drawing.Size(100, 17)
        Me.chkPrintAttachList.TabIndex = 18
        Me.chkPrintAttachList.Text = "Print Attach List"
        Me.chkPrintAttachList.UseVisualStyleBackColor = False
        '
        'cboAttach
        '
        Me.cboAttach.Enabled = False
        Me.cboAttach.FormattingEnabled = True
        Me.cboAttach.Items.AddRange(New Object() {"ALL"})
        Me.cboAttach.Location = New System.Drawing.Point(465, 4)
        Me.cboAttach.Name = "cboAttach"
        Me.cboAttach.Size = New System.Drawing.Size(109, 21)
        Me.cboAttach.TabIndex = 16
        Me.cboAttach.Text = "ALL"
        '
        'cboBillType
        '
        Me.cboBillType.Enabled = False
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"BILL OF LADING"})
        Me.cboBillType.Location = New System.Drawing.Point(583, 4)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 17
        Me.cboBillType.Text = "BILL OF LADING"
        '
        'frmRptInstructionDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 651)
        Me.Controls.Add(Me.cmdViewCBM)
        Me.Controls.Add(Me.chkViewMArks)
        Me.Controls.Add(Me.chkthreenill)
        Me.Controls.Add(Me.cmdrefresh)
        Me.Controls.Add(Me.chkViewPC)
        Me.Controls.Add(Me.chkviewfreight)
        Me.Controls.Add(Me.chkviewnote)
        Me.Controls.Add(Me.chkViewTotal)
        Me.Controls.Add(Me.chkPrintAttachList)
        Me.Controls.Add(Me.cboAttach)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.ReportViewer)
        Me.Name = "frmRptInstructionDetails"
        Me.Text = "Instruction (Details)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewMArks As System.Windows.Forms.CheckBox
    Friend WithEvents chkthreenill As System.Windows.Forms.CheckBox
    Friend WithEvents cmdrefresh As System.Windows.Forms.Button
    Friend WithEvents chkViewPC As System.Windows.Forms.CheckBox
    Friend WithEvents chkviewfreight As System.Windows.Forms.CheckBox
    Friend WithEvents chkviewnote As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewTotal As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintAttachList As System.Windows.Forms.CheckBox
    Friend WithEvents cboAttach As System.Windows.Forms.ComboBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
End Class
