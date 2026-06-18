<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCargoManifest
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
        Me.cmdrefresh = New System.Windows.Forms.Button
        Me.cmdViewCBM = New System.Windows.Forms.CheckBox
        Me.chkViewMArks = New System.Windows.Forms.CheckBox
        Me.chkViewPC = New System.Windows.Forms.CheckBox
        Me.chkviewfreight = New System.Windows.Forms.CheckBox
        Me.chkviewnote = New System.Windows.Forms.CheckBox
        Me.chkViewTotal = New System.Windows.Forms.CheckBox
        Me.chkPrintAttachList = New System.Windows.Forms.CheckBox
        Me.cboAttach = New System.Windows.Forms.ComboBox
        Me.cboBillType = New System.Windows.Forms.ComboBox
        Me.chkViewRemarks = New System.Windows.Forms.CheckBox
        Me.chkViewWeight = New System.Windows.Forms.CheckBox
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
        Me.ReportViewer.ShowGroupTreeButton = False
        Me.ReportViewer.ShowRefreshButton = False
        Me.ReportViewer.ShowTextSearchButton = False
        Me.ReportViewer.Size = New System.Drawing.Size(913, 492)
        Me.ReportViewer.TabIndex = 2
        Me.ReportViewer.ViewTimeSelectionFormula = ""
        '
        'cmdrefresh
        '
        Me.cmdrefresh.Location = New System.Drawing.Point(381, 29)
        Me.cmdrefresh.Name = "cmdrefresh"
        Me.cmdrefresh.Size = New System.Drawing.Size(60, 25)
        Me.cmdrefresh.TabIndex = 9
        Me.cmdrefresh.Text = "Refresh"
        Me.cmdrefresh.UseVisualStyleBackColor = True
        '
        'cmdViewCBM
        '
        Me.cmdViewCBM.AutoSize = True
        Me.cmdViewCBM.Location = New System.Drawing.Point(781, 29)
        Me.cmdViewCBM.Name = "cmdViewCBM"
        Me.cmdViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.cmdViewCBM.TabIndex = 24
        Me.cmdViewCBM.Text = "View CBM"
        Me.cmdViewCBM.UseVisualStyleBackColor = True
        Me.cmdViewCBM.Visible = False
        '
        'chkViewMArks
        '
        Me.chkViewMArks.AutoSize = True
        Me.chkViewMArks.Location = New System.Drawing.Point(781, 29)
        Me.chkViewMArks.Name = "chkViewMArks"
        Me.chkViewMArks.Size = New System.Drawing.Size(68, 17)
        Me.chkViewMArks.TabIndex = 23
        Me.chkViewMArks.Text = "V. Marks"
        Me.chkViewMArks.UseVisualStyleBackColor = True
        Me.chkViewMArks.Visible = False
        '
        'chkViewPC
        '
        Me.chkViewPC.AutoSize = True
        Me.chkViewPC.Checked = True
        Me.chkViewPC.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewPC.Location = New System.Drawing.Point(778, 29)
        Me.chkViewPC.Name = "chkViewPC"
        Me.chkViewPC.Size = New System.Drawing.Size(71, 17)
        Me.chkViewPC.TabIndex = 22
        Me.chkViewPC.Text = "View P/C"
        Me.chkViewPC.UseVisualStyleBackColor = True
        Me.chkViewPC.Visible = False
        '
        'chkviewfreight
        '
        Me.chkviewfreight.AutoSize = True
        Me.chkviewfreight.Checked = True
        Me.chkviewfreight.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkviewfreight.Location = New System.Drawing.Point(772, 7)
        Me.chkviewfreight.Name = "chkviewfreight"
        Me.chkviewfreight.Size = New System.Drawing.Size(84, 17)
        Me.chkviewfreight.TabIndex = 21
        Me.chkviewfreight.Text = "View Freight"
        Me.chkviewfreight.UseVisualStyleBackColor = True
        Me.chkviewfreight.Visible = False
        '
        'chkviewnote
        '
        Me.chkviewnote.AutoSize = True
        Me.chkviewnote.Checked = True
        Me.chkviewnote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkviewnote.Location = New System.Drawing.Point(694, 7)
        Me.chkviewnote.Name = "chkviewnote"
        Me.chkviewnote.Size = New System.Drawing.Size(75, 17)
        Me.chkviewnote.TabIndex = 20
        Me.chkviewnote.Text = "View Note"
        Me.chkviewnote.UseVisualStyleBackColor = True
        Me.chkviewnote.Visible = False
        '
        'chkViewTotal
        '
        Me.chkViewTotal.AutoSize = True
        Me.chkViewTotal.Checked = True
        Me.chkViewTotal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewTotal.Location = New System.Drawing.Point(621, 6)
        Me.chkViewTotal.Name = "chkViewTotal"
        Me.chkViewTotal.Size = New System.Drawing.Size(72, 17)
        Me.chkViewTotal.TabIndex = 19
        Me.chkViewTotal.Text = "View total"
        Me.chkViewTotal.UseVisualStyleBackColor = True
        Me.chkViewTotal.Visible = False
        '
        'chkPrintAttachList
        '
        Me.chkPrintAttachList.AutoSize = True
        Me.chkPrintAttachList.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.chkPrintAttachList.Location = New System.Drawing.Point(275, 6)
        Me.chkPrintAttachList.Name = "chkPrintAttachList"
        Me.chkPrintAttachList.Size = New System.Drawing.Size(100, 17)
        Me.chkPrintAttachList.TabIndex = 18
        Me.chkPrintAttachList.Text = "Print Attach List"
        Me.chkPrintAttachList.UseVisualStyleBackColor = False
        Me.chkPrintAttachList.Visible = False
        '
        'cboAttach
        '
        Me.cboAttach.Enabled = False
        Me.cboAttach.FormattingEnabled = True
        Me.cboAttach.Items.AddRange(New Object() {"ALL"})
        Me.cboAttach.Location = New System.Drawing.Point(381, 3)
        Me.cboAttach.Name = "cboAttach"
        Me.cboAttach.Size = New System.Drawing.Size(109, 21)
        Me.cboAttach.TabIndex = 16
        Me.cboAttach.Text = "All"
        Me.cboAttach.Visible = False
        '
        'cboBillType
        '
        Me.cboBillType.Enabled = False
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"BILL OF LADING"})
        Me.cboBillType.Location = New System.Drawing.Point(499, 3)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 17
        Me.cboBillType.Text = "BILL OF LADING"
        Me.cboBillType.Visible = False
        '
        'chkViewRemarks
        '
        Me.chkViewRemarks.AutoSize = True
        Me.chkViewRemarks.Location = New System.Drawing.Point(499, 34)
        Me.chkViewRemarks.Name = "chkViewRemarks"
        Me.chkViewRemarks.Size = New System.Drawing.Size(78, 17)
        Me.chkViewRemarks.TabIndex = 25
        Me.chkViewRemarks.Text = "V. S.Marks"
        Me.chkViewRemarks.UseVisualStyleBackColor = True
        '
        'chkViewWeight
        '
        Me.chkViewWeight.AutoSize = True
        Me.chkViewWeight.Location = New System.Drawing.Point(587, 34)
        Me.chkViewWeight.Name = "chkViewWeight"
        Me.chkViewWeight.Size = New System.Drawing.Size(73, 17)
        Me.chkViewWeight.TabIndex = 26
        Me.chkViewWeight.Text = "V. Weight"
        Me.chkViewWeight.UseVisualStyleBackColor = True
        '
        'frmRptCargoManifest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 492)
        Me.Controls.Add(Me.chkViewWeight)
        Me.Controls.Add(Me.chkViewRemarks)
        Me.Controls.Add(Me.cmdViewCBM)
        Me.Controls.Add(Me.chkViewMArks)
        Me.Controls.Add(Me.chkViewPC)
        Me.Controls.Add(Me.chkviewfreight)
        Me.Controls.Add(Me.chkviewnote)
        Me.Controls.Add(Me.chkViewTotal)
        Me.Controls.Add(Me.chkPrintAttachList)
        Me.Controls.Add(Me.cboAttach)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.cmdrefresh)
        Me.Controls.Add(Me.ReportViewer)
        Me.Name = "frmRptCargoManifest"
        Me.Text = "Rpt Cargo Manifest"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdrefresh As System.Windows.Forms.Button
    Friend WithEvents cmdViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewMArks As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewPC As System.Windows.Forms.CheckBox
    Friend WithEvents chkviewfreight As System.Windows.Forms.CheckBox
    Friend WithEvents chkviewnote As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewTotal As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintAttachList As System.Windows.Forms.CheckBox
    Friend WithEvents cboAttach As System.Windows.Forms.ComboBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkViewRemarks As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewWeight As System.Windows.Forms.CheckBox
End Class
