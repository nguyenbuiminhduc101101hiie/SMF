<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptHEADWIN
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptHEADWIN))
        Me.ReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkDraft = New System.Windows.Forms.CheckBox
        Me.chkfeeder = New System.Windows.Forms.CheckBox
        Me.chkMother = New System.Windows.Forms.CheckBox
        Me.ChkSur = New System.Windows.Forms.CheckBox
        Me.cmdViewCBM = New System.Windows.Forms.CheckBox
        Me.chkViewMArks = New System.Windows.Forms.CheckBox
        Me.cmdrefresh = New System.Windows.Forms.Button
        Me.chkViewPC = New System.Windows.Forms.CheckBox
        Me.chkviewfreight = New System.Windows.Forms.CheckBox
        Me.chkviewnote = New System.Windows.Forms.CheckBox
        Me.chkViewTotal = New System.Windows.Forms.CheckBox
        Me.chkPrintAttachList = New System.Windows.Forms.CheckBox
        Me.cboAttach = New System.Windows.Forms.ComboBox
        Me.cboBillType = New System.Windows.Forms.ComboBox
        Me.chkDateIssue = New System.Windows.Forms.CheckBox
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
        Me.ReportViewer.Size = New System.Drawing.Size(947, 555)
        Me.ReportViewer.TabIndex = 2
        Me.ReportViewer.ViewTimeSelectionFormula = ""
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Checked = True
        Me.chkDraft.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDraft.Location = New System.Drawing.Point(390, 28)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 48
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        '
        'chkfeeder
        '
        Me.chkfeeder.AutoSize = True
        Me.chkfeeder.Checked = True
        Me.chkfeeder.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkfeeder.Location = New System.Drawing.Point(447, 29)
        Me.chkfeeder.Name = "chkfeeder"
        Me.chkfeeder.Size = New System.Drawing.Size(72, 17)
        Me.chkfeeder.TabIndex = 47
        Me.chkfeeder.Text = "V. Feeder"
        Me.chkfeeder.UseVisualStyleBackColor = True
        '
        'chkMother
        '
        Me.chkMother.AutoSize = True
        Me.chkMother.Location = New System.Drawing.Point(852, 31)
        Me.chkMother.Name = "chkMother"
        Me.chkMother.Size = New System.Drawing.Size(72, 17)
        Me.chkMother.TabIndex = 46
        Me.chkMother.Text = "V. Mother"
        Me.chkMother.UseVisualStyleBackColor = True
        '
        'ChkSur
        '
        Me.ChkSur.AutoSize = True
        Me.ChkSur.Location = New System.Drawing.Point(525, 29)
        Me.ChkSur.Name = "ChkSur"
        Me.ChkSur.Size = New System.Drawing.Size(84, 17)
        Me.ChkSur.TabIndex = 45
        Me.ChkSur.Text = "View O,S,W"
        Me.ChkSur.UseVisualStyleBackColor = True
        '
        'cmdViewCBM
        '
        Me.cmdViewCBM.AutoSize = True
        Me.cmdViewCBM.Location = New System.Drawing.Point(620, 29)
        Me.cmdViewCBM.Name = "cmdViewCBM"
        Me.cmdViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.cmdViewCBM.TabIndex = 44
        Me.cmdViewCBM.Text = "View CBM"
        Me.cmdViewCBM.UseVisualStyleBackColor = True
        '
        'chkViewMArks
        '
        Me.chkViewMArks.AutoSize = True
        Me.chkViewMArks.Location = New System.Drawing.Point(774, 31)
        Me.chkViewMArks.Name = "chkViewMArks"
        Me.chkViewMArks.Size = New System.Drawing.Size(68, 17)
        Me.chkViewMArks.TabIndex = 43
        Me.chkViewMArks.Text = "V. Marks"
        Me.chkViewMArks.UseVisualStyleBackColor = True
        '
        'cmdrefresh
        '
        Me.cmdrefresh.Location = New System.Drawing.Point(492, 2)
        Me.cmdrefresh.Name = "cmdrefresh"
        Me.cmdrefresh.Size = New System.Drawing.Size(60, 25)
        Me.cmdrefresh.TabIndex = 42
        Me.cmdrefresh.Text = "Refresh"
        Me.cmdrefresh.UseVisualStyleBackColor = True
        '
        'chkViewPC
        '
        Me.chkViewPC.AutoSize = True
        Me.chkViewPC.Checked = True
        Me.chkViewPC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewPC.Location = New System.Drawing.Point(701, 29)
        Me.chkViewPC.Name = "chkViewPC"
        Me.chkViewPC.Size = New System.Drawing.Size(71, 17)
        Me.chkViewPC.TabIndex = 41
        Me.chkViewPC.Text = "View P/C"
        Me.chkViewPC.UseVisualStyleBackColor = True
        '
        'chkviewfreight
        '
        Me.chkviewfreight.AutoSize = True
        Me.chkviewfreight.Checked = True
        Me.chkviewfreight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkviewfreight.Location = New System.Drawing.Point(852, 7)
        Me.chkviewfreight.Name = "chkviewfreight"
        Me.chkviewfreight.Size = New System.Drawing.Size(84, 17)
        Me.chkviewfreight.TabIndex = 40
        Me.chkviewfreight.Text = "View Freight"
        Me.chkviewfreight.UseVisualStyleBackColor = True
        '
        'chkviewnote
        '
        Me.chkviewnote.AutoSize = True
        Me.chkviewnote.Checked = True
        Me.chkviewnote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkviewnote.Location = New System.Drawing.Point(774, 7)
        Me.chkviewnote.Name = "chkviewnote"
        Me.chkviewnote.Size = New System.Drawing.Size(75, 17)
        Me.chkviewnote.TabIndex = 39
        Me.chkviewnote.Text = "View Note"
        Me.chkviewnote.UseVisualStyleBackColor = True
        '
        'chkViewTotal
        '
        Me.chkViewTotal.AutoSize = True
        Me.chkViewTotal.Location = New System.Drawing.Point(701, 6)
        Me.chkViewTotal.Name = "chkViewTotal"
        Me.chkViewTotal.Size = New System.Drawing.Size(72, 17)
        Me.chkViewTotal.TabIndex = 38
        Me.chkViewTotal.Text = "View total"
        Me.chkViewTotal.UseVisualStyleBackColor = True
        '
        'chkPrintAttachList
        '
        Me.chkPrintAttachList.AutoSize = True
        Me.chkPrintAttachList.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.chkPrintAttachList.Location = New System.Drawing.Point(355, 6)
        Me.chkPrintAttachList.Name = "chkPrintAttachList"
        Me.chkPrintAttachList.Size = New System.Drawing.Size(100, 17)
        Me.chkPrintAttachList.TabIndex = 37
        Me.chkPrintAttachList.Text = "Print Attach List"
        Me.chkPrintAttachList.UseVisualStyleBackColor = False
        Me.chkPrintAttachList.Visible = False
        '
        'cboAttach
        '
        Me.cboAttach.FormattingEnabled = True
        Me.cboAttach.Items.AddRange(New Object() {"ALL", "SHIPPING MARKS"})
        Me.cboAttach.Location = New System.Drawing.Point(461, 3)
        Me.cboAttach.Name = "cboAttach"
        Me.cboAttach.Size = New System.Drawing.Size(11, 21)
        Me.cboAttach.TabIndex = 35
        Me.cboAttach.Text = "ALL"
        Me.cboAttach.Visible = False
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"ORIGINAL", "SURRENDED", "SEAWAY"})
        Me.cboBillType.Location = New System.Drawing.Point(579, 3)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 36
        Me.cboBillType.Text = "ORIGINAL"
        '
        'chkDateIssue
        '
        Me.chkDateIssue.AutoSize = True
        Me.chkDateIssue.Checked = True
        Me.chkDateIssue.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDateIssue.Location = New System.Drawing.Point(309, 28)
        Me.chkDateIssue.Name = "chkDateIssue"
        Me.chkDateIssue.Size = New System.Drawing.Size(75, 17)
        Me.chkDateIssue.TabIndex = 49
        Me.chkDateIssue.Text = "Issue date"
        Me.chkDateIssue.UseVisualStyleBackColor = True
        '
        'frmRptHEADWIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 555)
        Me.Controls.Add(Me.chkDateIssue)
        Me.Controls.Add(Me.chkDraft)
        Me.Controls.Add(Me.chkfeeder)
        Me.Controls.Add(Me.chkMother)
        Me.Controls.Add(Me.ChkSur)
        Me.Controls.Add(Me.cmdViewCBM)
        Me.Controls.Add(Me.chkViewMArks)
        Me.Controls.Add(Me.cmdrefresh)
        Me.Controls.Add(Me.chkViewPC)
        Me.Controls.Add(Me.chkviewfreight)
        Me.Controls.Add(Me.chkviewnote)
        Me.Controls.Add(Me.chkViewTotal)
        Me.Controls.Add(Me.chkPrintAttachList)
        Me.Controls.Add(Me.cboAttach)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.ReportViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptHEADWIN"
        Me.Text = "HEADWIN GLOBAL LOG"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents chkfeeder As System.Windows.Forms.CheckBox
    Friend WithEvents chkMother As System.Windows.Forms.CheckBox
    Friend WithEvents ChkSur As System.Windows.Forms.CheckBox
    Friend WithEvents cmdViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewMArks As System.Windows.Forms.CheckBox
    Friend WithEvents cmdrefresh As System.Windows.Forms.Button
    Friend WithEvents chkViewPC As System.Windows.Forms.CheckBox
    Friend WithEvents chkviewfreight As System.Windows.Forms.CheckBox
    Friend WithEvents chkviewnote As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewTotal As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintAttachList As System.Windows.Forms.CheckBox
    Friend WithEvents cboAttach As System.Windows.Forms.ComboBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkDateIssue As System.Windows.Forms.CheckBox
End Class
