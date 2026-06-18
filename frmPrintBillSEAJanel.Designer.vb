<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintBillSEAJanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintBillSEAJanel))
        Me.chkContainer = New System.Windows.Forms.CheckBox
        Me.chkAttachShippingMarks = New System.Windows.Forms.CheckBox
        Me.chkAttachDesc = New System.Windows.Forms.CheckBox
        Me.chkAttachlist = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtby = New System.Windows.Forms.TextBox
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
        'chkContainer
        '
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(631, 35)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(110, 17)
        Me.chkContainer.TabIndex = 63
        Me.chkContainer.Text = "Attach Containers"
        Me.chkContainer.UseVisualStyleBackColor = True
        '
        'chkAttachShippingMarks
        '
        Me.chkAttachShippingMarks.AutoSize = True
        Me.chkAttachShippingMarks.Location = New System.Drawing.Point(536, 35)
        Me.chkAttachShippingMarks.Name = "chkAttachShippingMarks"
        Me.chkAttachShippingMarks.Size = New System.Drawing.Size(89, 17)
        Me.chkAttachShippingMarks.TabIndex = 62
        Me.chkAttachShippingMarks.Text = "Attach Marks"
        Me.chkAttachShippingMarks.UseVisualStyleBackColor = True
        '
        'chkAttachDesc
        '
        Me.chkAttachDesc.AutoSize = True
        Me.chkAttachDesc.Location = New System.Drawing.Point(442, 35)
        Me.chkAttachDesc.Name = "chkAttachDesc"
        Me.chkAttachDesc.Size = New System.Drawing.Size(88, 17)
        Me.chkAttachDesc.TabIndex = 61
        Me.chkAttachDesc.Text = "Attach Desc."
        Me.chkAttachDesc.UseVisualStyleBackColor = True
        '
        'chkAttachlist
        '
        Me.chkAttachlist.AutoSize = True
        Me.chkAttachlist.Location = New System.Drawing.Point(721, 17)
        Me.chkAttachlist.Name = "chkAttachlist"
        Me.chkAttachlist.Size = New System.Drawing.Size(72, 17)
        Me.chkAttachlist.TabIndex = 60
        Me.chkAttachlist.Text = "Attach list"
        Me.chkAttachlist.UseVisualStyleBackColor = True
        Me.chkAttachlist.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 59
        Me.Label1.Text = "by :"
        '
        'txtby
        '
        Me.txtby.Location = New System.Drawing.Point(38, 32)
        Me.txtby.Name = "txtby"
        Me.txtby.Size = New System.Drawing.Size(321, 20)
        Me.txtby.TabIndex = 58
        '
        'chkViewCBM
        '
        Me.chkViewCBM.AutoSize = True
        Me.chkViewCBM.Location = New System.Drawing.Point(365, 35)
        Me.chkViewCBM.Name = "chkViewCBM"
        Me.chkViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.chkViewCBM.TabIndex = 57
        Me.chkViewCBM.Text = "View CBM"
        Me.chkViewCBM.UseVisualStyleBackColor = True
        '
        'chkDest
        '
        Me.chkDest.AutoSize = True
        Me.chkDest.Checked = True
        Me.chkDest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDest.Location = New System.Drawing.Point(365, 13)
        Me.chkDest.Name = "chkDest"
        Me.chkDest.Size = New System.Drawing.Size(81, 17)
        Me.chkDest.TabIndex = 56
        Me.chkDest.Text = "Show Dest."
        Me.chkDest.UseVisualStyleBackColor = True
        '
        'chkMother
        '
        Me.chkMother.AutoSize = True
        Me.chkMother.Location = New System.Drawing.Point(291, 12)
        Me.chkMother.Name = "chkMother"
        Me.chkMother.Size = New System.Drawing.Size(72, 17)
        Me.chkMother.TabIndex = 55
        Me.chkMother.Text = "V. Mother"
        Me.chkMother.UseVisualStyleBackColor = True
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"", "ORIGINAL", "SURRENDERED", "SEAWAY", "COPY"})
        Me.cboBillType.Location = New System.Drawing.Point(574, 10)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 54
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Location = New System.Drawing.Point(243, 12)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 53
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(493, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 52
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(199, 12)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 51
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(8, 58)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(833, 540)
        Me.CrystalReportViewer1.TabIndex = 50
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmPrintBillSEAJanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 610)
        Me.Controls.Add(Me.chkContainer)
        Me.Controls.Add(Me.chkAttachShippingMarks)
        Me.Controls.Add(Me.chkAttachDesc)
        Me.Controls.Add(Me.chkAttachlist)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtby)
        Me.Controls.Add(Me.chkViewCBM)
        Me.Controls.Add(Me.chkDest)
        Me.Controls.Add(Me.chkMother)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.chkDraft)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkCheckAir)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintBillSEAJanel"
        Me.Text = "Print Bill SEA Janel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkContainer As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachShippingMarks As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDesc As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachlist As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtby As System.Windows.Forms.TextBox
    Friend WithEvents chkViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkDest As System.Windows.Forms.CheckBox
    Friend WithEvents chkMother As System.Windows.Forms.CheckBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
