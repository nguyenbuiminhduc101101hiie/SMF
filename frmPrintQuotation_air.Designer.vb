<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintQuotation_air
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintQuotation_air))
        Me.chkWM = New System.Windows.Forms.RadioButton()
        Me.chkDH = New System.Windows.Forms.RadioButton()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'chkWM
        '
        Me.chkWM.AutoSize = True
        Me.chkWM.Location = New System.Drawing.Point(152, 15)
        Me.chkWM.Name = "chkWM"
        Me.chkWM.Size = New System.Drawing.Size(45, 17)
        Me.chkWM.TabIndex = 74
        Me.chkWM.Text = "WM"
        Me.chkWM.UseVisualStyleBackColor = True
        Me.chkWM.Visible = False
        '
        'chkDH
        '
        Me.chkDH.AutoSize = True
        Me.chkDH.Checked = True
        Me.chkDH.Location = New System.Drawing.Point(105, 15)
        Me.chkDH.Name = "chkDH"
        Me.chkDH.Size = New System.Drawing.Size(41, 17)
        Me.chkDH.TabIndex = 73
        Me.chkDH.TabStop = True
        Me.chkDH.Text = "DH"
        Me.chkDH.UseVisualStyleBackColor = True
        Me.chkDH.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 12)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 72
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 41)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1090, 522)
        Me.CrystalReportViewer1.TabIndex = 71
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmPrintQuotation_air
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 575)
        Me.Controls.Add(Me.chkWM)
        Me.Controls.Add(Me.chkDH)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintQuotation_air"
        Me.Text = "Quotation (AIR)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkWM As System.Windows.Forms.RadioButton
    Friend WithEvents chkDH As System.Windows.Forms.RadioButton
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
