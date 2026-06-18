<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptForeignVesselApplicaitonForArrivalb
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdUpdateInfo = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnShow = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboTerminal = New System.Windows.Forms.ComboBox
        Me.grpComfirmInfo = New System.Windows.Forms.GroupBox
        Me.grpComfirmInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(943, 493)
        Me.CrystalReportViewer1.TabIndex = 6
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cmdUpdateInfo
        '
        Me.cmdUpdateInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateInfo.Location = New System.Drawing.Point(841, 6)
        Me.cmdUpdateInfo.Name = "cmdUpdateInfo"
        Me.cmdUpdateInfo.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdateInfo.TabIndex = 7
        Me.cmdUpdateInfo.Text = "Update Info"
        Me.cmdUpdateInfo.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(37, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Xin Phép Vào cảng :"
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(114, 71)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "&Ok"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(192, 71)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboTerminal
        '
        Me.cboTerminal.FormattingEnabled = True
        Me.cboTerminal.Location = New System.Drawing.Point(146, 33)
        Me.cboTerminal.Name = "cboTerminal"
        Me.cboTerminal.Size = New System.Drawing.Size(121, 21)
        Me.cboTerminal.TabIndex = 6
        '
        'grpComfirmInfo
        '
        Me.grpComfirmInfo.Controls.Add(Me.cboTerminal)
        Me.grpComfirmInfo.Controls.Add(Me.cmdCancel)
        Me.grpComfirmInfo.Controls.Add(Me.btnShow)
        Me.grpComfirmInfo.Controls.Add(Me.Label6)
        Me.grpComfirmInfo.Location = New System.Drawing.Point(210, 102)
        Me.grpComfirmInfo.Name = "grpComfirmInfo"
        Me.grpComfirmInfo.Size = New System.Drawing.Size(304, 102)
        Me.grpComfirmInfo.TabIndex = 8
        Me.grpComfirmInfo.TabStop = False
        Me.grpComfirmInfo.Text = "Confirm Information"
        Me.grpComfirmInfo.Visible = False
        '
        'frmRptForeignVesselApplicaitonForArrivalb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 493)
        Me.Controls.Add(Me.cmdUpdateInfo)
        Me.Controls.Add(Me.grpComfirmInfo)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmRptForeignVesselApplicaitonForArrivalb"
        Me.Text = "Report Foreign Vessel Applicaiton For Arrival"
        Me.grpComfirmInfo.ResumeLayout(False)
        Me.grpComfirmInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdUpdateInfo As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboTerminal As System.Windows.Forms.ComboBox
    Friend WithEvents grpComfirmInfo As System.Windows.Forms.GroupBox
End Class
