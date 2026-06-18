<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCreditOut_Logistics_PDD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportCreditOut_Logistics_PDD))
        Me.chkasperbill = New System.Windows.Forms.CheckBox()
        Me.chkoversea = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CHKTKHQ = New System.Windows.Forms.CheckBox()
        Me.chkTigia = New System.Windows.Forms.CheckBox()
        Me.chkHBL = New System.Windows.Forms.CheckBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chkCheckAir = New System.Windows.Forms.CheckBox()
        Me.chkAttachDescription = New System.Windows.Forms.CheckBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'chkasperbill
        '
        Me.chkasperbill.AutoSize = True
        Me.chkasperbill.Location = New System.Drawing.Point(193, 31)
        Me.chkasperbill.Name = "chkasperbill"
        Me.chkasperbill.Size = New System.Drawing.Size(73, 17)
        Me.chkasperbill.TabIndex = 77
        Me.chkasperbill.Text = "As Per Bill"
        Me.chkasperbill.UseVisualStyleBackColor = True
        Me.chkasperbill.Visible = False
        '
        'chkoversea
        '
        Me.chkoversea.AutoSize = True
        Me.chkoversea.Checked = True
        Me.chkoversea.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkoversea.Location = New System.Drawing.Point(647, 28)
        Me.chkoversea.Name = "chkoversea"
        Me.chkoversea.Size = New System.Drawing.Size(66, 17)
        Me.chkoversea.TabIndex = 76
        Me.chkoversea.Text = "Oversea"
        Me.chkoversea.UseVisualStyleBackColor = True
        Me.chkoversea.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(550, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 23)
        Me.Button1.TabIndex = 75
        Me.Button1.Text = "Save to SOA"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'CHKTKHQ
        '
        Me.CHKTKHQ.AutoSize = True
        Me.CHKTKHQ.Location = New System.Drawing.Point(550, 26)
        Me.CHKTKHQ.Name = "CHKTKHQ"
        Me.CHKTKHQ.Size = New System.Drawing.Size(56, 17)
        Me.CHKTKHQ.TabIndex = 74
        Me.CHKTKHQ.Text = "TKHQ"
        Me.CHKTKHQ.UseVisualStyleBackColor = True
        Me.CHKTKHQ.Visible = False
        '
        'chkTigia
        '
        Me.chkTigia.AutoSize = True
        Me.chkTigia.Checked = True
        Me.chkTigia.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTigia.Location = New System.Drawing.Point(547, 26)
        Me.chkTigia.Name = "chkTigia"
        Me.chkTigia.Size = New System.Drawing.Size(60, 17)
        Me.chkTigia.TabIndex = 73
        Me.chkTigia.Text = "x Tỉ giá"
        Me.chkTigia.UseVisualStyleBackColor = True
        Me.chkTigia.Visible = False
        '
        'chkHBL
        '
        Me.chkHBL.AutoSize = True
        Me.chkHBL.Location = New System.Drawing.Point(140, 31)
        Me.chkHBL.Name = "chkHBL"
        Me.chkHBL.Size = New System.Drawing.Size(47, 17)
        Me.chkHBL.TabIndex = 72
        Me.chkHBL.Text = "HBL"
        Me.chkHBL.UseVisualStyleBackColor = True
        Me.chkHBL.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(59, 30)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 71
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(15, 31)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 70
        Me.chkCheckAir.Text = "Air"
        Me.chkCheckAir.UseVisualStyleBackColor = True
        Me.chkCheckAir.Visible = False
        '
        'chkAttachDescription
        '
        Me.chkAttachDescription.AutoSize = True
        Me.chkAttachDescription.Location = New System.Drawing.Point(580, 26)
        Me.chkAttachDescription.Name = "chkAttachDescription"
        Me.chkAttachDescription.Size = New System.Drawing.Size(113, 17)
        Me.chkAttachDescription.TabIndex = 69
        Me.chkAttachDescription.Text = "Attach Descritpion"
        Me.chkAttachDescription.UseVisualStyleBackColor = True
        Me.chkAttachDescription.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 70)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(946, 393)
        Me.CrystalReportViewer1.TabIndex = 68
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmReportCreditOut_Logistics_PDD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 475)
        Me.Controls.Add(Me.chkasperbill)
        Me.Controls.Add(Me.chkoversea)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CHKTKHQ)
        Me.Controls.Add(Me.chkTigia)
        Me.Controls.Add(Me.chkHBL)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkCheckAir)
        Me.Controls.Add(Me.chkAttachDescription)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportCreditOut_Logistics_PDD"
        Me.Text = "Prview Phiếu điều động"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkasperbill As System.Windows.Forms.CheckBox
    Friend WithEvents chkoversea As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CHKTKHQ As System.Windows.Forms.CheckBox
    Friend WithEvents chkTigia As System.Windows.Forms.CheckBox
    Friend WithEvents chkHBL As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDescription As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
