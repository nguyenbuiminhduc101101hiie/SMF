<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCusSaleDetail
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
        Me.rptCusSaleDetail = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptCusSaleDetail
        '
        Me.rptCusSaleDetail.ActiveViewIndex = -1
        Me.rptCusSaleDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptCusSaleDetail.DisplayGroupTree = False
        Me.rptCusSaleDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCusSaleDetail.Location = New System.Drawing.Point(0, 0)
        Me.rptCusSaleDetail.Name = "rptCusSaleDetail"
        Me.rptCusSaleDetail.SelectionFormula = ""
        Me.rptCusSaleDetail.ShowGroupTreeButton = False
        Me.rptCusSaleDetail.Size = New System.Drawing.Size(744, 264)
        Me.rptCusSaleDetail.TabIndex = 0
        Me.rptCusSaleDetail.ViewTimeSelectionFormula = ""
        '
        'frmReportCusSaleDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 264)
        Me.Controls.Add(Me.rptCusSaleDetail)
        Me.Name = "frmReportCusSaleDetail"
        Me.Text = "Report Cus. Sale Detail"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptCusSaleDetail As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
