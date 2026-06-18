<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportDebitNguyente_OverseaAirImport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportDebitNguyente_OverseaAirImport))
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
        Me.chksgN.Location = New System.Drawing.Point(67, 41)
        Me.chksgN.Name = "chksgN"
        Me.chksgN.Size = New System.Drawing.Size(48, 17)
        Me.chksgN.TabIndex = 73
        Me.chksgN.Text = "SGN"
        Me.chksgN.UseVisualStyleBackColor = True
        Me.chksgN.Visible = False
        '
        'chkHPH
        '
        Me.chkHPH.AutoSize = True
        Me.chkHPH.Checked = True
        Me.chkHPH.Location = New System.Drawing.Point(13, 41)
        Me.chkHPH.Name = "chkHPH"
        Me.chkHPH.Size = New System.Drawing.Size(48, 17)
        Me.chkHPH.TabIndex = 72
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
        Me.chkHBL.Location = New System.Drawing.Point(869, 12)
        Me.chkHBL.Name = "chkHBL"
        Me.chkHBL.Size = New System.Drawing.Size(47, 17)
        Me.chkHBL.TabIndex = 71
        Me.chkHBL.Text = "HBL"
        Me.chkHBL.UseVisualStyleBackColor = True
        '
        'chkoversea
        '
        Me.chkoversea.AutoSize = True
        Me.chkoversea.Location = New System.Drawing.Point(264, 13)
        Me.chkoversea.Name = "chkoversea"
        Me.chkoversea.Size = New System.Drawing.Size(81, 17)
        Me.chkoversea.TabIndex = 70
        Me.chkoversea.Text = "CheckBox1"
        Me.chkoversea.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(135, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 23)
        Me.Button1.TabIndex = 69
        Me.Button1.Text = "Save to SOA"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cbotk
        '
        Me.cbotk.FormattingEnabled = True
        Me.cbotk.Items.AddRange(New Object() {"Account 1", "Account 2", "Account 3", "HPH_Account 1", "HPH_Account 2", "HPH_Account 3"})
        Me.cbotk.Location = New System.Drawing.Point(369, 12)
        Me.cbotk.Name = "cbotk"
        Me.cbotk.Size = New System.Drawing.Size(103, 21)
        Me.cbotk.TabIndex = 68
        Me.cbotk.Text = "Account 1"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(54, 12)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 67
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(14, 13)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 66
        Me.chkCheckAir.Text = "Air"
        Me.chkCheckAir.UseVisualStyleBackColor = True
        Me.chkCheckAir.Visible = False
        '
        'chkAttachDescription
        '
        Me.chkAttachDescription.AutoSize = True
        Me.chkAttachDescription.Location = New System.Drawing.Point(222, 13)
        Me.chkAttachDescription.Name = "chkAttachDescription"
        Me.chkAttachDescription.Size = New System.Drawing.Size(113, 17)
        Me.chkAttachDescription.TabIndex = 65
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 39)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(838, 520)
        Me.CrystalReportViewer1.TabIndex = 64
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmReportDebitNguyente_OverseaAirImport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 571)
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
        Me.Name = "frmReportDebitNguyente_OverseaAirImport"
        Me.Text = "Report Debit Oversea Air Import"
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
