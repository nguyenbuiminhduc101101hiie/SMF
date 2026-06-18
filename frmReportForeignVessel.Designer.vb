<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportForeignVessel
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
        Me.rptForeignVessel = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptForeignVessel
        '
        Me.rptForeignVessel.ActiveViewIndex = -1
        Me.rptForeignVessel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptForeignVessel.DisplayGroupTree = False
        Me.rptForeignVessel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptForeignVessel.Location = New System.Drawing.Point(0, 0)
        Me.rptForeignVessel.Name = "rptForeignVessel"
        Me.rptForeignVessel.SelectionFormula = ""
        Me.rptForeignVessel.Size = New System.Drawing.Size(492, 311)
        Me.rptForeignVessel.TabIndex = 0
        Me.rptForeignVessel.ViewTimeSelectionFormula = ""
        '
        'frmReportForeignVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 311)
        Me.Controls.Add(Me.rptForeignVessel)
        Me.Name = "frmReportForeignVessel"
        Me.Text = "Foreign Vessel Application's For Arrival"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptForeignVessel As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
