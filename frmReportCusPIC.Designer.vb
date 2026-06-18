<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCusPIC
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
        Me.rptcuspic = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptcuspic
        '
        Me.rptcuspic.ActiveViewIndex = -1
        Me.rptcuspic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptcuspic.DisplayGroupTree = False
        Me.rptcuspic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptcuspic.Location = New System.Drawing.Point(0, 0)
        Me.rptcuspic.Name = "rptcuspic"
        Me.rptcuspic.SelectionFormula = ""
        Me.rptcuspic.Size = New System.Drawing.Size(873, 264)
        Me.rptcuspic.TabIndex = 0
        Me.rptcuspic.ViewTimeSelectionFormula = ""
        '
        'frmReportCusPIC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 264)
        Me.Controls.Add(Me.rptcuspic)
        Me.Name = "frmReportCusPIC"
        Me.Text = "Report Cus. PIC"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptcuspic As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
