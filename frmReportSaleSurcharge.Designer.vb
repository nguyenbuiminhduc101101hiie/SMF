<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportSaleSurcharge
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
        Me.rptSaleSurcharge = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cboOne = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'rptSaleSurcharge
        '
        Me.rptSaleSurcharge.ActiveViewIndex = -1
        Me.rptSaleSurcharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptSaleSurcharge.DisplayGroupTree = False
        Me.rptSaleSurcharge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptSaleSurcharge.Location = New System.Drawing.Point(0, 0)
        Me.rptSaleSurcharge.Name = "rptSaleSurcharge"
        Me.rptSaleSurcharge.SelectionFormula = ""
        Me.rptSaleSurcharge.Size = New System.Drawing.Size(769, 397)
        Me.rptSaleSurcharge.TabIndex = 0
        Me.rptSaleSurcharge.ViewTimeSelectionFormula = ""
        '
        'cboOne
        '
        Me.cboOne.FormattingEnabled = True
        Me.cboOne.Location = New System.Drawing.Point(576, 2)
        Me.cboOne.Name = "cboOne"
        Me.cboOne.Size = New System.Drawing.Size(193, 21)
        Me.cboOne.TabIndex = 1
        '
        'frmReportSaleSurcharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 397)
        Me.Controls.Add(Me.cboOne)
        Me.Controls.Add(Me.rptSaleSurcharge)
        Me.Name = "frmReportSaleSurcharge"
        Me.Text = "Report Sale Surcharge"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptSaleSurcharge As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cboOne As System.Windows.Forms.ComboBox
End Class
