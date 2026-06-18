<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCusCommodity
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
        Me.rptCusCommodity = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptCusCommodity
        '
        Me.rptCusCommodity.ActiveViewIndex = -1
        Me.rptCusCommodity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptCusCommodity.DisplayGroupTree = False
        Me.rptCusCommodity.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCusCommodity.Location = New System.Drawing.Point(0, 0)
        Me.rptCusCommodity.Name = "rptCusCommodity"
        Me.rptCusCommodity.SelectionFormula = ""
        Me.rptCusCommodity.Size = New System.Drawing.Size(560, 264)
        Me.rptCusCommodity.TabIndex = 0
        Me.rptCusCommodity.ViewTimeSelectionFormula = ""
        '
        'frmReportCusCommodity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 264)
        Me.Controls.Add(Me.rptCusCommodity)
        Me.Name = "frmReportCusCommodity"
        Me.Text = "Report Cus. Commodity"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptCusCommodity As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
