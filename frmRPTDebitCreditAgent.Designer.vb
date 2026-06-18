<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRPTDebitCreditAgent
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
        Me.cboAgent = New System.Windows.Forms.ComboBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.chkCheckHBLFee = New System.Windows.Forms.CheckBox
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(771, 545)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cboAgent
        '
        Me.cboAgent.FormattingEnabled = True
        Me.cboAgent.Location = New System.Drawing.Point(376, 4)
        Me.cboAgent.Name = "cboAgent"
        Me.cboAgent.Size = New System.Drawing.Size(188, 21)
        Me.cboAgent.TabIndex = 1
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(586, 3)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(54, 23)
        Me.cmdRefresh.TabIndex = 3
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckHBLFee
        '
        Me.chkCheckHBLFee.AutoSize = True
        Me.chkCheckHBLFee.BackColor = System.Drawing.Color.Transparent
        Me.chkCheckHBLFee.Location = New System.Drawing.Point(348, 6)
        Me.chkCheckHBLFee.Name = "chkCheckHBLFee"
        Me.chkCheckHBLFee.Size = New System.Drawing.Size(15, 14)
        Me.chkCheckHBLFee.TabIndex = 4
        Me.chkCheckHBLFee.UseVisualStyleBackColor = False
        Me.chkCheckHBLFee.Visible = False
        '
        'frmRPTDebitCreditAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 545)
        Me.Controls.Add(Me.chkCheckHBLFee)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.cboAgent)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmRPTDebitCreditAgent"
        Me.Text = "Debit / Credit Agent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cboAgent As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckHBLFee As System.Windows.Forms.CheckBox
End Class
