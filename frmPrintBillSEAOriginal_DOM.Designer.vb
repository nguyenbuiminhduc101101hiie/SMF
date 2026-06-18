<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintBillSEAOriginal_DOM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintBillSEAOriginal_DOM))
        Me.chkshowbillOther = New System.Windows.Forms.CheckBox()
        Me.chkContainerNo = New System.Windows.Forms.CheckBox()
        Me.chkthru = New System.Windows.Forms.CheckBox()
        Me.chkALPine = New System.Windows.Forms.CheckBox()
        Me.chkNon = New System.Windows.Forms.CheckBox()
        Me.chkContainer = New System.Windows.Forms.CheckBox()
        Me.chkAttachShippingMarks = New System.Windows.Forms.CheckBox()
        Me.chkAttachDesc = New System.Windows.Forms.CheckBox()
        Me.chkAttachlist = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtby = New System.Windows.Forms.TextBox()
        Me.chkViewCBM = New System.Windows.Forms.CheckBox()
        Me.chkDest = New System.Windows.Forms.CheckBox()
        Me.chkMother = New System.Windows.Forms.CheckBox()
        Me.cboBillType = New System.Windows.Forms.ComboBox()
        Me.chkDraft = New System.Windows.Forms.CheckBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chkCheckAir = New System.Windows.Forms.CheckBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'chkshowbillOther
        '
        Me.chkshowbillOther.AutoSize = True
        Me.chkshowbillOther.Location = New System.Drawing.Point(853, 23)
        Me.chkshowbillOther.Name = "chkshowbillOther"
        Me.chkshowbillOther.Size = New System.Drawing.Size(169, 17)
        Me.chkshowbillOther.TabIndex = 59
        Me.chkshowbillOther.Text = "Show Bill (Ship./Consig.) other"
        Me.chkshowbillOther.UseVisualStyleBackColor = True
        '
        'chkContainerNo
        '
        Me.chkContainerNo.AutoSize = True
        Me.chkContainerNo.Checked = True
        Me.chkContainerNo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkContainerNo.Location = New System.Drawing.Point(756, 23)
        Me.chkContainerNo.Name = "chkContainerNo"
        Me.chkContainerNo.Size = New System.Drawing.Size(91, 17)
        Me.chkContainerNo.TabIndex = 58
        Me.chkContainerNo.Text = "Container No."
        Me.chkContainerNo.UseVisualStyleBackColor = True
        '
        'chkthru
        '
        Me.chkthru.AutoSize = True
        Me.chkthru.Location = New System.Drawing.Point(699, 22)
        Me.chkthru.Name = "chkthru"
        Me.chkthru.Size = New System.Drawing.Size(51, 17)
        Me.chkthru.TabIndex = 57
        Me.chkthru.Text = "Thru."
        Me.chkthru.UseVisualStyleBackColor = True
        '
        'chkALPine
        '
        Me.chkALPine.AutoSize = True
        Me.chkALPine.Location = New System.Drawing.Point(756, 22)
        Me.chkALPine.Name = "chkALPine"
        Me.chkALPine.Size = New System.Drawing.Size(60, 17)
        Me.chkALPine.TabIndex = 56
        Me.chkALPine.Text = "ALPine"
        Me.chkALPine.UseVisualStyleBackColor = True
        '
        'chkNon
        '
        Me.chkNon.AutoSize = True
        Me.chkNon.Location = New System.Drawing.Point(41, 19)
        Me.chkNon.Name = "chkNon"
        Me.chkNon.Size = New System.Drawing.Size(111, 17)
        Me.chkNon.TabIndex = 55
        Me.chkNon.Text = "V. Non-negotiable"
        Me.chkNon.UseVisualStyleBackColor = True
        '
        'chkContainer
        '
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(634, 45)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(110, 17)
        Me.chkContainer.TabIndex = 54
        Me.chkContainer.Text = "Attach Containers"
        Me.chkContainer.UseVisualStyleBackColor = True
        '
        'chkAttachShippingMarks
        '
        Me.chkAttachShippingMarks.AutoSize = True
        Me.chkAttachShippingMarks.Location = New System.Drawing.Point(539, 45)
        Me.chkAttachShippingMarks.Name = "chkAttachShippingMarks"
        Me.chkAttachShippingMarks.Size = New System.Drawing.Size(89, 17)
        Me.chkAttachShippingMarks.TabIndex = 53
        Me.chkAttachShippingMarks.Text = "Attach Marks"
        Me.chkAttachShippingMarks.UseVisualStyleBackColor = True
        '
        'chkAttachDesc
        '
        Me.chkAttachDesc.AutoSize = True
        Me.chkAttachDesc.Location = New System.Drawing.Point(445, 45)
        Me.chkAttachDesc.Name = "chkAttachDesc"
        Me.chkAttachDesc.Size = New System.Drawing.Size(88, 17)
        Me.chkAttachDesc.TabIndex = 52
        Me.chkAttachDesc.Text = "Attach Desc."
        Me.chkAttachDesc.UseVisualStyleBackColor = True
        '
        'chkAttachlist
        '
        Me.chkAttachlist.AutoSize = True
        Me.chkAttachlist.Location = New System.Drawing.Point(756, 44)
        Me.chkAttachlist.Name = "chkAttachlist"
        Me.chkAttachlist.Size = New System.Drawing.Size(72, 17)
        Me.chkAttachlist.TabIndex = 51
        Me.chkAttachlist.Text = "Attach list"
        Me.chkAttachlist.UseVisualStyleBackColor = True
        Me.chkAttachlist.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "by :"
        '
        'txtby
        '
        Me.txtby.Location = New System.Drawing.Point(41, 42)
        Me.txtby.Name = "txtby"
        Me.txtby.Size = New System.Drawing.Size(300, 20)
        Me.txtby.TabIndex = 49
        '
        'chkViewCBM
        '
        Me.chkViewCBM.AutoSize = True
        Me.chkViewCBM.Location = New System.Drawing.Point(368, 45)
        Me.chkViewCBM.Name = "chkViewCBM"
        Me.chkViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.chkViewCBM.TabIndex = 48
        Me.chkViewCBM.Text = "View CBM"
        Me.chkViewCBM.UseVisualStyleBackColor = True
        '
        'chkDest
        '
        Me.chkDest.AutoSize = True
        Me.chkDest.Checked = True
        Me.chkDest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDest.Location = New System.Drawing.Point(368, 23)
        Me.chkDest.Name = "chkDest"
        Me.chkDest.Size = New System.Drawing.Size(81, 17)
        Me.chkDest.TabIndex = 47
        Me.chkDest.Text = "Show Dest."
        Me.chkDest.UseVisualStyleBackColor = True
        '
        'chkMother
        '
        Me.chkMother.AutoSize = True
        Me.chkMother.Location = New System.Drawing.Point(294, 22)
        Me.chkMother.Name = "chkMother"
        Me.chkMother.Size = New System.Drawing.Size(72, 17)
        Me.chkMother.TabIndex = 46
        Me.chkMother.Text = "V. Mother"
        Me.chkMother.UseVisualStyleBackColor = True
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"", "ORIGINAL", "SURRENDERED", "SEAWAY", "COPY"})
        Me.cboBillType.Location = New System.Drawing.Point(577, 20)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 45
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Checked = True
        Me.chkDraft.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDraft.Location = New System.Drawing.Point(246, 22)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 44
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(496, 19)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 43
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(202, 22)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 42
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 68)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1119, 544)
        Me.CrystalReportViewer1.TabIndex = 41
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmPrintBillSEAOriginal_DOM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 624)
        Me.Controls.Add(Me.chkshowbillOther)
        Me.Controls.Add(Me.chkContainerNo)
        Me.Controls.Add(Me.chkthru)
        Me.Controls.Add(Me.chkALPine)
        Me.Controls.Add(Me.chkNon)
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
        Me.Name = "frmPrintBillSEAOriginal_DOM"
        Me.Text = "Bill  (DOM)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkshowbillOther As System.Windows.Forms.CheckBox
    Friend WithEvents chkContainerNo As System.Windows.Forms.CheckBox
    Friend WithEvents chkthru As System.Windows.Forms.CheckBox
    Friend WithEvents chkALPine As System.Windows.Forms.CheckBox
    Friend WithEvents chkNon As System.Windows.Forms.CheckBox
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
