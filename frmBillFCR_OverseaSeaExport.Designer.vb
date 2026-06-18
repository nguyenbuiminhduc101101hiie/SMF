<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillFCR_OverseaSeaExport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillFCR_OverseaSeaExport))
        Me.chkmbL = New System.Windows.Forms.CheckBox
        Me.chksgN = New System.Windows.Forms.RadioButton
        Me.chkHPH = New System.Windows.Forms.RadioButton
        Me.chkContainer = New System.Windows.Forms.CheckBox
        Me.chkAttachShippingMarks = New System.Windows.Forms.CheckBox
        Me.chkAttachDesc = New System.Windows.Forms.CheckBox
        Me.chkAttachlist = New System.Windows.Forms.CheckBox
        Me.chkViewCBM = New System.Windows.Forms.CheckBox
        Me.chkDest = New System.Windows.Forms.CheckBox
        Me.chkMother = New System.Windows.Forms.CheckBox
        Me.cboBillType = New System.Windows.Forms.ComboBox
        Me.chkDraft = New System.Windows.Forms.CheckBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.chkCheckAir = New System.Windows.Forms.CheckBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'chkmbL
        '
        Me.chkmbL.AutoSize = True
        Me.chkmbL.Location = New System.Drawing.Point(30, 5)
        Me.chkmbL.Name = "chkmbL"
        Me.chkmbL.Size = New System.Drawing.Size(48, 17)
        Me.chkmbL.TabIndex = 78
        Me.chkmbL.Text = "MBL"
        Me.chkmbL.UseVisualStyleBackColor = True
        Me.chkmbL.Visible = False
        '
        'chksgN
        '
        Me.chksgN.AutoSize = True
        Me.chksgN.Location = New System.Drawing.Point(593, 7)
        Me.chksgN.Name = "chksgN"
        Me.chksgN.Size = New System.Drawing.Size(48, 17)
        Me.chksgN.TabIndex = 77
        Me.chksgN.Text = "SGN"
        Me.chksgN.UseVisualStyleBackColor = True
        Me.chksgN.Visible = False
        '
        'chkHPH
        '
        Me.chkHPH.AutoSize = True
        Me.chkHPH.Location = New System.Drawing.Point(539, 7)
        Me.chkHPH.Name = "chkHPH"
        Me.chkHPH.Size = New System.Drawing.Size(48, 17)
        Me.chkHPH.TabIndex = 76
        Me.chkHPH.Text = "HPH"
        Me.chkHPH.UseVisualStyleBackColor = True
        Me.chkHPH.Visible = False
        '
        'chkContainer
        '
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(477, 30)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(110, 17)
        Me.chkContainer.TabIndex = 75
        Me.chkContainer.Text = "Attach Containers"
        Me.chkContainer.UseVisualStyleBackColor = True
        Me.chkContainer.Visible = False
        '
        'chkAttachShippingMarks
        '
        Me.chkAttachShippingMarks.AutoSize = True
        Me.chkAttachShippingMarks.Location = New System.Drawing.Point(382, 30)
        Me.chkAttachShippingMarks.Name = "chkAttachShippingMarks"
        Me.chkAttachShippingMarks.Size = New System.Drawing.Size(89, 17)
        Me.chkAttachShippingMarks.TabIndex = 74
        Me.chkAttachShippingMarks.Text = "Attach Marks"
        Me.chkAttachShippingMarks.UseVisualStyleBackColor = True
        Me.chkAttachShippingMarks.Visible = False
        '
        'chkAttachDesc
        '
        Me.chkAttachDesc.AutoSize = True
        Me.chkAttachDesc.Location = New System.Drawing.Point(288, 30)
        Me.chkAttachDesc.Name = "chkAttachDesc"
        Me.chkAttachDesc.Size = New System.Drawing.Size(88, 17)
        Me.chkAttachDesc.TabIndex = 73
        Me.chkAttachDesc.Text = "Attach Desc."
        Me.chkAttachDesc.UseVisualStyleBackColor = True
        Me.chkAttachDesc.Visible = False
        '
        'chkAttachlist
        '
        Me.chkAttachlist.AutoSize = True
        Me.chkAttachlist.Location = New System.Drawing.Point(63, 30)
        Me.chkAttachlist.Name = "chkAttachlist"
        Me.chkAttachlist.Size = New System.Drawing.Size(72, 17)
        Me.chkAttachlist.TabIndex = 72
        Me.chkAttachlist.Text = "Attach list"
        Me.chkAttachlist.UseVisualStyleBackColor = True
        Me.chkAttachlist.Visible = False
        '
        'chkViewCBM
        '
        Me.chkViewCBM.AutoSize = True
        Me.chkViewCBM.Location = New System.Drawing.Point(208, 30)
        Me.chkViewCBM.Name = "chkViewCBM"
        Me.chkViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.chkViewCBM.TabIndex = 71
        Me.chkViewCBM.Text = "View CBM"
        Me.chkViewCBM.UseVisualStyleBackColor = True
        Me.chkViewCBM.Visible = False
        '
        'chkDest
        '
        Me.chkDest.AutoSize = True
        Me.chkDest.Checked = True
        Me.chkDest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDest.Location = New System.Drawing.Point(208, 8)
        Me.chkDest.Name = "chkDest"
        Me.chkDest.Size = New System.Drawing.Size(81, 17)
        Me.chkDest.TabIndex = 70
        Me.chkDest.Text = "Show Dest."
        Me.chkDest.UseVisualStyleBackColor = True
        Me.chkDest.Visible = False
        '
        'chkMother
        '
        Me.chkMother.AutoSize = True
        Me.chkMother.Location = New System.Drawing.Point(134, 7)
        Me.chkMother.Name = "chkMother"
        Me.chkMother.Size = New System.Drawing.Size(72, 17)
        Me.chkMother.TabIndex = 69
        Me.chkMother.Text = "V. Mother"
        Me.chkMother.UseVisualStyleBackColor = True
        Me.chkMother.Visible = False
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"", "ORIGINAL", "SURRENDERED", "SEAWAY"})
        Me.cboBillType.Location = New System.Drawing.Point(417, 5)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 68
        Me.cboBillType.Visible = False
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Location = New System.Drawing.Point(686, 10)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 67
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        Me.chkDraft.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 14)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 66
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(642, 10)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 65
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 53)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(902, 487)
        Me.CrystalReportViewer1.TabIndex = 64
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmBillFCR_OverseaSeaExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 545)
        Me.Controls.Add(Me.chkmbL)
        Me.Controls.Add(Me.chksgN)
        Me.Controls.Add(Me.chkHPH)
        Me.Controls.Add(Me.chkContainer)
        Me.Controls.Add(Me.chkAttachShippingMarks)
        Me.Controls.Add(Me.chkAttachDesc)
        Me.Controls.Add(Me.chkAttachlist)
        Me.Controls.Add(Me.chkViewCBM)
        Me.Controls.Add(Me.chkDest)
        Me.Controls.Add(Me.chkMother)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.chkDraft)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkCheckAir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBillFCR_OverseaSeaExport"
        Me.Text = "FCR"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkmbL As System.Windows.Forms.CheckBox
    Friend WithEvents chksgN As System.Windows.Forms.RadioButton
    Friend WithEvents chkHPH As System.Windows.Forms.RadioButton
    Friend WithEvents chkContainer As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachShippingMarks As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDesc As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachlist As System.Windows.Forms.CheckBox
    Friend WithEvents chkViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkDest As System.Windows.Forms.CheckBox
    Friend WithEvents chkMother As System.Windows.Forms.CheckBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
