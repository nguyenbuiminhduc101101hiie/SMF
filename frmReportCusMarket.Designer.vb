<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCusMarket
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
        Me.rptCusMarket = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptCusMarket
        '
        Me.rptCusMarket.ActiveViewIndex = -1
        Me.rptCusMarket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptCusMarket.DisplayGroupTree = False
        Me.rptCusMarket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCusMarket.Location = New System.Drawing.Point(0, 0)
        Me.rptCusMarket.Name = "rptCusMarket"
        Me.rptCusMarket.SelectionFormula = ""
        Me.rptCusMarket.Size = New System.Drawing.Size(467, 264)
        Me.rptCusMarket.TabIndex = 0
        Me.rptCusMarket.ViewTimeSelectionFormula = ""
        '
        'frmReportCusMarket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(467, 264)
        Me.Controls.Add(Me.rptCusMarket)
        Me.Name = "frmReportCusMarket"
        Me.Text = "Report Cus. Market"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptCusMarket As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
