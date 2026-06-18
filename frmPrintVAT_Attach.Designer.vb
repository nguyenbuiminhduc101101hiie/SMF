<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintVAT_Attach
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintVAT_Attach))
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkShowMST = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(680, 2)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 13
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        Me.cmdRefresh.Visible = False
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
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(917, 493)
        Me.CrystalReportViewer1.TabIndex = 12
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'chkShowMST
        '
        Me.chkShowMST.AutoSize = True
        Me.chkShowMST.BackColor = System.Drawing.Color.Transparent
        Me.chkShowMST.Checked = True
        Me.chkShowMST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMST.Location = New System.Drawing.Point(585, 6)
        Me.chkShowMST.Name = "chkShowMST"
        Me.chkShowMST.Size = New System.Drawing.Size(79, 17)
        Me.chkShowMST.TabIndex = 16
        Me.chkShowMST.Text = "Show MST"
        Me.chkShowMST.UseVisualStyleBackColor = False
        '
        'frmPrintVAT_Attach
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(917, 493)
        Me.Controls.Add(Me.chkShowMST)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintVAT_Attach"
        Me.Text = "Print VAT (Attached)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkShowMST As System.Windows.Forms.CheckBox
End Class
