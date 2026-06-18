<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintInboundJobprofit_Overseaseaimport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintInboundJobprofit_Overseaseaimport))
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkoversea = New System.Windows.Forms.CheckBox
        Me.cbotk = New System.Windows.Forms.ComboBox
        Me.chkAttachDescription = New System.Windows.Forms.CheckBox
        Me.CHKUSD = New System.Windows.Forms.CheckBox
        Me.chkHBL = New System.Windows.Forms.CheckBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.chkCheckAir = New System.Windows.Forms.CheckBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(139, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 23)
        Me.Button1.TabIndex = 55
        Me.Button1.Text = "Save to SOA"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'chkoversea
        '
        Me.chkoversea.AutoSize = True
        Me.chkoversea.Location = New System.Drawing.Point(361, 5)
        Me.chkoversea.Name = "chkoversea"
        Me.chkoversea.Size = New System.Drawing.Size(81, 17)
        Me.chkoversea.TabIndex = 54
        Me.chkoversea.Text = "CheckBox1"
        Me.chkoversea.UseVisualStyleBackColor = True
        Me.chkoversea.Visible = False
        '
        'cbotk
        '
        Me.cbotk.FormattingEnabled = True
        Me.cbotk.Items.AddRange(New Object() {"Account 1", "Account 2", "Account 3"})
        Me.cbotk.Location = New System.Drawing.Point(252, 3)
        Me.cbotk.Name = "cbotk"
        Me.cbotk.Size = New System.Drawing.Size(103, 21)
        Me.cbotk.TabIndex = 53
        Me.cbotk.Text = "Account 1"
        Me.cbotk.Visible = False
        '
        'chkAttachDescription
        '
        Me.chkAttachDescription.AutoSize = True
        Me.chkAttachDescription.Location = New System.Drawing.Point(356, 4)
        Me.chkAttachDescription.Name = "chkAttachDescription"
        Me.chkAttachDescription.Size = New System.Drawing.Size(113, 17)
        Me.chkAttachDescription.TabIndex = 52
        Me.chkAttachDescription.Text = "Attach Descritpion"
        Me.chkAttachDescription.UseVisualStyleBackColor = True
        Me.chkAttachDescription.Visible = False
        '
        'CHKUSD
        '
        Me.CHKUSD.AutoSize = True
        Me.CHKUSD.Location = New System.Drawing.Point(194, 4)
        Me.CHKUSD.Name = "CHKUSD"
        Me.CHKUSD.Size = New System.Drawing.Size(49, 17)
        Me.CHKUSD.TabIndex = 51
        Me.CHKUSD.Text = "USD"
        Me.CHKUSD.UseVisualStyleBackColor = True
        Me.CHKUSD.Visible = False
        '
        'chkHBL
        '
        Me.chkHBL.AutoSize = True
        Me.chkHBL.Checked = True
        Me.chkHBL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHBL.Location = New System.Drawing.Point(86, 5)
        Me.chkHBL.Name = "chkHBL"
        Me.chkHBL.Size = New System.Drawing.Size(47, 17)
        Me.chkHBL.TabIndex = 50
        Me.chkHBL.Text = "HBL"
        Me.chkHBL.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(5, 5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 49
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(509, 3)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 48
        Me.chkCheckAir.Text = "Air"
        Me.chkCheckAir.UseVisualStyleBackColor = True
        Me.chkCheckAir.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(5, 33)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(845, 389)
        Me.CrystalReportViewer1.TabIndex = 47
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmPrintInboundJobprofit_Overseaseaimport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 434)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkoversea)
        Me.Controls.Add(Me.cbotk)
        Me.Controls.Add(Me.chkAttachDescription)
        Me.Controls.Add(Me.CHKUSD)
        Me.Controls.Add(Me.chkHBL)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkCheckAir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintInboundJobprofit_Overseaseaimport"
        Me.Text = "Job Profit"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkoversea As System.Windows.Forms.CheckBox
    Friend WithEvents cbotk As System.Windows.Forms.ComboBox
    Friend WithEvents chkAttachDescription As System.Windows.Forms.CheckBox
    Friend WithEvents CHKUSD As System.Windows.Forms.CheckBox
    Friend WithEvents chkHBL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
