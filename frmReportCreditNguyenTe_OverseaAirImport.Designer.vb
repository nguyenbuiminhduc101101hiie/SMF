<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportCreditNguyenTe_OverseaAirImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportCreditNguyenTe_OverseaAirImport))
        Me.chksgN = New System.Windows.Forms.RadioButton
        Me.chkHPH = New System.Windows.Forms.RadioButton
        Me.chkHBL = New System.Windows.Forms.CheckBox
        Me.chkoversea = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cbotk = New System.Windows.Forms.ComboBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.chkCheckAir = New System.Windows.Forms.CheckBox
        Me.chkAttachDescription = New System.Windows.Forms.CheckBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'chksgN
        '
        Me.chksgN.AutoSize = True
        Me.chksgN.Location = New System.Drawing.Point(401, 35)
        Me.chksgN.Name = "chksgN"
        Me.chksgN.Size = New System.Drawing.Size(48, 17)
        Me.chksgN.TabIndex = 83
        Me.chksgN.Text = "SGN"
        Me.chksgN.UseVisualStyleBackColor = True
        Me.chksgN.Visible = False
        '
        'chkHPH
        '
        Me.chkHPH.AutoSize = True
        Me.chkHPH.Checked = True
        Me.chkHPH.Location = New System.Drawing.Point(347, 35)
        Me.chkHPH.Name = "chkHPH"
        Me.chkHPH.Size = New System.Drawing.Size(48, 17)
        Me.chkHPH.TabIndex = 82
        Me.chkHPH.TabStop = True
        Me.chkHPH.Text = "HPH"
        Me.chkHPH.UseVisualStyleBackColor = True
        Me.chkHPH.Visible = False
        '
        'chkHBL
        '
        Me.chkHBL.AutoSize = True
        Me.chkHBL.Checked = True
        Me.chkHBL.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHBL.Location = New System.Drawing.Point(134, 14)
        Me.chkHBL.Name = "chkHBL"
        Me.chkHBL.Size = New System.Drawing.Size(47, 17)
        Me.chkHBL.TabIndex = 81
        Me.chkHBL.Text = "HBL"
        Me.chkHBL.UseVisualStyleBackColor = True
        '
        'chkoversea
        '
        Me.chkoversea.AutoSize = True
        Me.chkoversea.Location = New System.Drawing.Point(263, 12)
        Me.chkoversea.Name = "chkoversea"
        Me.chkoversea.Size = New System.Drawing.Size(81, 17)
        Me.chkoversea.TabIndex = 80
        Me.chkoversea.Text = "CheckBox1"
        Me.chkoversea.UseVisualStyleBackColor = True
        Me.chkoversea.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(134, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 23)
        Me.Button1.TabIndex = 79
        Me.Button1.Text = "Save to SOA"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cbotk
        '
        Me.cbotk.FormattingEnabled = True
        Me.cbotk.Items.AddRange(New Object() {"Account 1", "Account 2", "Account 3", "HPH_Account 1", "HPH_Account 2", "HPH_Account 3"})
        Me.cbotk.Location = New System.Drawing.Point(134, 12)
        Me.cbotk.Name = "cbotk"
        Me.cbotk.Size = New System.Drawing.Size(103, 21)
        Me.cbotk.TabIndex = 78
        Me.cbotk.Text = "Account 1"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(53, 11)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 77
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(13, 12)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 76
        Me.chkCheckAir.Text = "Air"
        Me.chkCheckAir.UseVisualStyleBackColor = True
        Me.chkCheckAir.Visible = False
        '
        'chkAttachDescription
        '
        Me.chkAttachDescription.AutoSize = True
        Me.chkAttachDescription.Location = New System.Drawing.Point(221, 12)
        Me.chkAttachDescription.Name = "chkAttachDescription"
        Me.chkAttachDescription.Size = New System.Drawing.Size(113, 17)
        Me.chkAttachDescription.TabIndex = 75
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(9, 35)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(859, 513)
        Me.CrystalReportViewer1.TabIndex = 74
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmReportCreditNguyenTe_OverseaAirImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 560)
        Me.Controls.Add(Me.chksgN)
        Me.Controls.Add(Me.chkHPH)
        Me.Controls.Add(Me.chkHBL)
        Me.Controls.Add(Me.chkoversea)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cbotk)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkCheckAir)
        Me.Controls.Add(Me.chkAttachDescription)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportCreditNguyenTe_OverseaAirImport"
        Me.Text = "Crebit Oversea Air Import"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chksgN As System.Windows.Forms.RadioButton
    Friend WithEvents chkHPH As System.Windows.Forms.RadioButton
    Friend WithEvents chkHBL As System.Windows.Forms.CheckBox
    Friend WithEvents chkoversea As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cbotk As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDescription As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
