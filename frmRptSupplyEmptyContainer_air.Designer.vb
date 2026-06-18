<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptSupplyEmptyContainer_air
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRptSupplyEmptyContainer_air))
        Me.chkrequest = New System.Windows.Forms.CheckBox()
        Me.cmdrefesh = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'chkrequest
        '
        Me.chkrequest.AutoSize = True
        Me.chkrequest.Checked = True
        Me.chkrequest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkrequest.Location = New System.Drawing.Point(478, 6)
        Me.chkrequest.Name = "chkrequest"
        Me.chkrequest.Size = New System.Drawing.Size(108, 17)
        Me.chkrequest.TabIndex = 7
        Me.chkrequest.Text = "Booking Request"
        Me.chkrequest.UseVisualStyleBackColor = True
        Me.chkrequest.Visible = False
        '
        'cmdrefesh
        '
        Me.cmdrefesh.Location = New System.Drawing.Point(390, 2)
        Me.cmdrefesh.Name = "cmdrefesh"
        Me.cmdrefesh.Size = New System.Drawing.Size(75, 23)
        Me.cmdrefesh.TabIndex = 6
        Me.cmdrefesh.Text = "Refesh"
        Me.cmdrefesh.UseVisualStyleBackColor = True
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(938, 497)
        Me.CrystalReportViewer1.TabIndex = 5
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmRptSupplyEmptyContainer_air
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 497)
        Me.Controls.Add(Me.chkrequest)
        Me.Controls.Add(Me.cmdrefesh)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmRptSupplyEmptyContainer_air"
        Me.Text = "Print Booking Confirm Air"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkrequest As System.Windows.Forms.CheckBox
    Friend WithEvents cmdrefesh As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
