<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCustomer
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
        Me.rptCustomer = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'rptCustomer
        '
        Me.rptCustomer.ActiveViewIndex = -1
        Me.rptCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rptCustomer.DisplayGroupTree = False
        Me.rptCustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rptCustomer.Location = New System.Drawing.Point(0, 0)
        Me.rptCustomer.Name = "rptCustomer"
        Me.rptCustomer.SelectionFormula = ""
        Me.rptCustomer.Size = New System.Drawing.Size(292, 273)
        Me.rptCustomer.TabIndex = 0
        Me.rptCustomer.ViewTimeSelectionFormula = ""
        '
        'frmReportCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.rptCustomer)
        Me.Name = "frmReportCustomer"
        Me.Text = "Report Customer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rptCustomer As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
