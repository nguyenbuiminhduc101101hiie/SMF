<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptMasterBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptMasterBill))
        Me.ReportViewer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cboBillType = New System.Windows.Forms.ComboBox
        Me.chkPrintAttachList = New System.Windows.Forms.CheckBox
        Me.cboAttach = New System.Windows.Forms.ComboBox
        Me.chkViewTotal = New System.Windows.Forms.CheckBox
        Me.chkViewNote = New System.Windows.Forms.CheckBox
        Me.chkViewFreight = New System.Windows.Forms.CheckBox
        Me.chkMoveVessel = New System.Windows.Forms.CheckBox
        Me.cmdrefresh = New System.Windows.Forms.Button
        Me.chkDefaultMargin = New System.Windows.Forms.CheckBox
        Me.chkHSCode = New System.Windows.Forms.CheckBox
        Me.chkSCACCode = New System.Windows.Forms.CheckBox
        Me.chkHBL = New System.Windows.Forms.CheckBox
        Me.cmdViewCBM = New System.Windows.Forms.CheckBox
        Me.cmdViewMotherVessel = New System.Windows.Forms.CheckBox
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
        Me.ReportViewer.Size = New System.Drawing.Size(1028, 423)
        Me.ReportViewer.TabIndex = 0
        Me.ReportViewer.ViewTimeSelectionFormula = ""
        '
        'cboBillType
        '
        Me.cboBillType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"BILL OF LADING"})
        Me.cboBillType.Location = New System.Drawing.Point(598, 4)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(113, 21)
        Me.cboBillType.TabIndex = 1
        '
        'chkPrintAttachList
        '
        Me.chkPrintAttachList.AutoSize = True
        Me.chkPrintAttachList.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.chkPrintAttachList.Location = New System.Drawing.Point(355, 6)
        Me.chkPrintAttachList.Name = "chkPrintAttachList"
        Me.chkPrintAttachList.Size = New System.Drawing.Size(100, 17)
        Me.chkPrintAttachList.TabIndex = 2
        Me.chkPrintAttachList.Text = "Print Attach List"
        Me.chkPrintAttachList.UseVisualStyleBackColor = False
        '
        'cboAttach
        '
        Me.cboAttach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAttach.FormattingEnabled = True
        Me.cboAttach.Items.AddRange(New Object() {"ALL", "DESCRIPTION", "NOTIFY"})
        Me.cboAttach.Location = New System.Drawing.Point(458, 4)
        Me.cboAttach.Name = "cboAttach"
        Me.cboAttach.Size = New System.Drawing.Size(130, 21)
        Me.cboAttach.TabIndex = 3
        '
        'chkViewTotal
        '
        Me.chkViewTotal.AutoSize = True
        Me.chkViewTotal.Location = New System.Drawing.Point(755, 6)
        Me.chkViewTotal.Name = "chkViewTotal"
        Me.chkViewTotal.Size = New System.Drawing.Size(76, 17)
        Me.chkViewTotal.TabIndex = 4
        Me.chkViewTotal.Text = "View Total"
        Me.chkViewTotal.UseVisualStyleBackColor = True
        '
        'chkViewNote
        '
        Me.chkViewNote.AutoSize = True
        Me.chkViewNote.Checked = True
        Me.chkViewNote.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkViewNote.Location = New System.Drawing.Point(832, 6)
        Me.chkViewNote.Name = "chkViewNote"
        Me.chkViewNote.Size = New System.Drawing.Size(75, 17)
        Me.chkViewNote.TabIndex = 5
        Me.chkViewNote.Text = "View Note"
        Me.chkViewNote.UseVisualStyleBackColor = True
        '
        'chkViewFreight
        '
        Me.chkViewFreight.AutoSize = True
        Me.chkViewFreight.Location = New System.Drawing.Point(909, 6)
        Me.chkViewFreight.Name = "chkViewFreight"
        Me.chkViewFreight.Size = New System.Drawing.Size(84, 17)
        Me.chkViewFreight.TabIndex = 6
        Me.chkViewFreight.Text = "View Freight"
        Me.chkViewFreight.UseVisualStyleBackColor = True
        '
        'chkMoveVessel
        '
        Me.chkMoveVessel.AutoSize = True
        Me.chkMoveVessel.Location = New System.Drawing.Point(832, 29)
        Me.chkMoveVessel.Name = "chkMoveVessel"
        Me.chkMoveVessel.Size = New System.Drawing.Size(76, 17)
        Me.chkMoveVessel.TabIndex = 7
        Me.chkMoveVessel.Text = "Move P.V."
        Me.chkMoveVessel.UseVisualStyleBackColor = True
        '
        'cmdrefresh
        '
        Me.cmdrefresh.Image = CType(resources.GetObject("cmdrefresh.Image"), System.Drawing.Image)
        Me.cmdrefresh.Location = New System.Drawing.Point(719, 2)
        Me.cmdrefresh.Name = "cmdrefresh"
        Me.cmdrefresh.Size = New System.Drawing.Size(31, 25)
        Me.cmdrefresh.TabIndex = 8
        Me.cmdrefresh.UseVisualStyleBackColor = True
        '
        'chkDefaultMargin
        '
        Me.chkDefaultMargin.AutoSize = True
        Me.chkDefaultMargin.Location = New System.Drawing.Point(909, 29)
        Me.chkDefaultMargin.Name = "chkDefaultMargin"
        Me.chkDefaultMargin.Size = New System.Drawing.Size(78, 17)
        Me.chkDefaultMargin.TabIndex = 9
        Me.chkDefaultMargin.Text = "De. Margin"
        Me.chkDefaultMargin.UseVisualStyleBackColor = True
        '
        'chkHSCode
        '
        Me.chkHSCode.AutoSize = True
        Me.chkHSCode.Location = New System.Drawing.Point(591, 29)
        Me.chkHSCode.Name = "chkHSCode"
        Me.chkHSCode.Size = New System.Drawing.Size(79, 17)
        Me.chkHSCode.TabIndex = 10
        Me.chkHSCode.Text = "V. HSCode"
        Me.chkHSCode.UseVisualStyleBackColor = True
        '
        'chkSCACCode
        '
        Me.chkSCACCode.AutoSize = True
        Me.chkSCACCode.Location = New System.Drawing.Point(668, 29)
        Me.chkSCACCode.Name = "chkSCACCode"
        Me.chkSCACCode.Size = New System.Drawing.Size(95, 17)
        Me.chkSCACCode.TabIndex = 11
        Me.chkSCACCode.Text = "V. SCAC Code"
        Me.chkSCACCode.UseVisualStyleBackColor = True
        '
        'chkHBL
        '
        Me.chkHBL.AutoSize = True
        Me.chkHBL.Location = New System.Drawing.Point(765, 29)
        Me.chkHBL.Name = "chkHBL"
        Me.chkHBL.Size = New System.Drawing.Size(60, 17)
        Me.chkHBL.TabIndex = 12
        Me.chkHBL.Text = "V. HBL"
        Me.chkHBL.UseVisualStyleBackColor = True
        '
        'cmdViewCBM
        '
        Me.cmdViewCBM.AutoSize = True
        Me.cmdViewCBM.Location = New System.Drawing.Point(506, 29)
        Me.cmdViewCBM.Name = "cmdViewCBM"
        Me.cmdViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.cmdViewCBM.TabIndex = 14
        Me.cmdViewCBM.Text = "View CBM"
        Me.cmdViewCBM.UseVisualStyleBackColor = True
        '
        'cmdViewMotherVessel
        '
        Me.cmdViewMotherVessel.AutoSize = True
        Me.cmdViewMotherVessel.Location = New System.Drawing.Point(403, 29)
        Me.cmdViewMotherVessel.Name = "cmdViewMotherVessel"
        Me.cmdViewMotherVessel.Size = New System.Drawing.Size(95, 17)
        Me.cmdViewMotherVessel.TabIndex = 15
        Me.cmdViewMotherVessel.Text = "View M.Vessel"
        Me.cmdViewMotherVessel.UseVisualStyleBackColor = True
        '
        'frmRptMasterBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 423)
        Me.Controls.Add(Me.cmdViewMotherVessel)
        Me.Controls.Add(Me.cmdViewCBM)
        Me.Controls.Add(Me.chkHBL)
        Me.Controls.Add(Me.chkSCACCode)
        Me.Controls.Add(Me.chkHSCode)
        Me.Controls.Add(Me.chkDefaultMargin)
        Me.Controls.Add(Me.cmdrefresh)
        Me.Controls.Add(Me.chkMoveVessel)
        Me.Controls.Add(Me.chkViewFreight)
        Me.Controls.Add(Me.chkViewNote)
        Me.Controls.Add(Me.chkViewTotal)
        Me.Controls.Add(Me.cboAttach)
        Me.Controls.Add(Me.chkPrintAttachList)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.ReportViewer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptMasterBill"
        Me.Text = "Report Master Bill"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkPrintAttachList As System.Windows.Forms.CheckBox
    Friend WithEvents cboAttach As System.Windows.Forms.ComboBox
    Friend WithEvents chkViewTotal As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewNote As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewFreight As System.Windows.Forms.CheckBox
    Friend WithEvents chkMoveVessel As System.Windows.Forms.CheckBox
    Friend WithEvents cmdrefresh As System.Windows.Forms.Button
    Friend WithEvents chkDefaultMargin As System.Windows.Forms.CheckBox
    Friend WithEvents chkHSCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkSCACCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkHBL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents cmdViewMotherVessel As System.Windows.Forms.CheckBox
End Class
