<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillInstruction
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillInstruction))
        Me.chkViewCBM = New System.Windows.Forms.CheckBox()
        Me.chkDest = New System.Windows.Forms.CheckBox()
        Me.chkMother = New System.Windows.Forms.CheckBox()
        Me.cboBillType = New System.Windows.Forms.ComboBox()
        Me.chkDraft = New System.Windows.Forms.CheckBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chkCheckAir = New System.Windows.Forms.CheckBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.chkAttachlist = New System.Windows.Forms.CheckBox()
        Me.chkContainer = New System.Windows.Forms.CheckBox()
        Me.chkAttachShippingMarks = New System.Windows.Forms.CheckBox()
        Me.chkAttachDesc = New System.Windows.Forms.CheckBox()
        Me.chkHPH = New System.Windows.Forms.RadioButton()
        Me.chksgN = New System.Windows.Forms.RadioButton()
        Me.chkmbl = New System.Windows.Forms.RadioButton()
        Me.chkThru = New System.Windows.Forms.RadioButton()
        Me.txtConsineethru = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkAgent = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkViewCBM
        '
        Me.chkViewCBM.AutoSize = True
        Me.chkViewCBM.Location = New System.Drawing.Point(222, 35)
        Me.chkViewCBM.Name = "chkViewCBM"
        Me.chkViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.chkViewCBM.TabIndex = 41
        Me.chkViewCBM.Text = "View CBM"
        Me.chkViewCBM.UseVisualStyleBackColor = True
        '
        'chkDest
        '
        Me.chkDest.AutoSize = True
        Me.chkDest.Checked = True
        Me.chkDest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDest.Location = New System.Drawing.Point(222, 13)
        Me.chkDest.Name = "chkDest"
        Me.chkDest.Size = New System.Drawing.Size(81, 17)
        Me.chkDest.TabIndex = 40
        Me.chkDest.Text = "Show Dest."
        Me.chkDest.UseVisualStyleBackColor = True
        Me.chkDest.Visible = False
        '
        'chkMother
        '
        Me.chkMother.AutoSize = True
        Me.chkMother.Location = New System.Drawing.Point(763, 103)
        Me.chkMother.Name = "chkMother"
        Me.chkMother.Size = New System.Drawing.Size(72, 17)
        Me.chkMother.TabIndex = 39
        Me.chkMother.Text = "V. Mother"
        Me.chkMother.UseVisualStyleBackColor = True
        Me.chkMother.Visible = False
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"", "ORIGINAL", "SURRENDERED", "SEAWAY"})
        Me.cboBillType.Location = New System.Drawing.Point(431, 10)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 38
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Location = New System.Drawing.Point(661, 106)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 37
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        Me.chkDraft.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(350, 9)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 36
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(617, 106)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 35
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 85)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1062, 303)
        Me.CrystalReportViewer1.TabIndex = 34
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'chkAttachlist
        '
        Me.chkAttachlist.AutoSize = True
        Me.chkAttachlist.Location = New System.Drawing.Point(661, 144)
        Me.chkAttachlist.Name = "chkAttachlist"
        Me.chkAttachlist.Size = New System.Drawing.Size(72, 17)
        Me.chkAttachlist.TabIndex = 42
        Me.chkAttachlist.Text = "Attach list"
        Me.chkAttachlist.UseVisualStyleBackColor = True
        Me.chkAttachlist.Visible = False
        '
        'chkContainer
        '
        Me.chkContainer.AutoSize = True
        Me.chkContainer.Location = New System.Drawing.Point(491, 35)
        Me.chkContainer.Name = "chkContainer"
        Me.chkContainer.Size = New System.Drawing.Size(110, 17)
        Me.chkContainer.TabIndex = 45
        Me.chkContainer.Text = "Attach Containers"
        Me.chkContainer.UseVisualStyleBackColor = True
        '
        'chkAttachShippingMarks
        '
        Me.chkAttachShippingMarks.AutoSize = True
        Me.chkAttachShippingMarks.Location = New System.Drawing.Point(396, 35)
        Me.chkAttachShippingMarks.Name = "chkAttachShippingMarks"
        Me.chkAttachShippingMarks.Size = New System.Drawing.Size(89, 17)
        Me.chkAttachShippingMarks.TabIndex = 44
        Me.chkAttachShippingMarks.Text = "Attach Marks"
        Me.chkAttachShippingMarks.UseVisualStyleBackColor = True
        '
        'chkAttachDesc
        '
        Me.chkAttachDesc.AutoSize = True
        Me.chkAttachDesc.Location = New System.Drawing.Point(302, 35)
        Me.chkAttachDesc.Name = "chkAttachDesc"
        Me.chkAttachDesc.Size = New System.Drawing.Size(88, 17)
        Me.chkAttachDesc.TabIndex = 43
        Me.chkAttachDesc.Text = "Attach Desc."
        Me.chkAttachDesc.UseVisualStyleBackColor = True
        '
        'chkHPH
        '
        Me.chkHPH.AutoSize = True
        Me.chkHPH.Location = New System.Drawing.Point(514, 103)
        Me.chkHPH.Name = "chkHPH"
        Me.chkHPH.Size = New System.Drawing.Size(48, 17)
        Me.chkHPH.TabIndex = 46
        Me.chkHPH.Text = "HPH"
        Me.chkHPH.UseVisualStyleBackColor = True
        Me.chkHPH.Visible = False
        '
        'chksgN
        '
        Me.chksgN.AutoSize = True
        Me.chksgN.Location = New System.Drawing.Point(568, 103)
        Me.chksgN.Name = "chksgN"
        Me.chksgN.Size = New System.Drawing.Size(48, 17)
        Me.chksgN.TabIndex = 47
        Me.chksgN.Text = "SGN"
        Me.chksgN.UseVisualStyleBackColor = True
        Me.chksgN.Visible = False
        '
        'chkmbl
        '
        Me.chkmbl.AutoSize = True
        Me.chkmbl.Location = New System.Drawing.Point(30, 19)
        Me.chkmbl.Name = "chkmbl"
        Me.chkmbl.Size = New System.Drawing.Size(52, 17)
        Me.chkmbl.TabIndex = 48
        Me.chkmbl.Text = "MB/L"
        Me.chkmbl.UseVisualStyleBackColor = True
        '
        'chkThru
        '
        Me.chkThru.AutoSize = True
        Me.chkThru.Location = New System.Drawing.Point(88, 19)
        Me.chkThru.Name = "chkThru"
        Me.chkThru.Size = New System.Drawing.Size(47, 17)
        Me.chkThru.TabIndex = 49
        Me.chkThru.Text = "Thru"
        Me.chkThru.UseVisualStyleBackColor = True
        '
        'txtConsineethru
        '
        Me.txtConsineethru.Location = New System.Drawing.Point(639, 6)
        Me.txtConsineethru.Multiline = True
        Me.txtConsineethru.Name = "txtConsineethru"
        Me.txtConsineethru.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtConsineethru.Size = New System.Drawing.Size(351, 62)
        Me.txtConsineethru.TabIndex = 50
        Me.txtConsineethru.Text = "TO ORDER OF THE HOLDER OF THE SURRENDERED " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "B/L No: " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ISSUED BY VESTAL SHIPPING &" & _
    " LOGISTICS CO.,LTD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(570, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "Consignee :"
        '
        'chkAgent
        '
        Me.chkAgent.AutoSize = True
        Me.chkAgent.Checked = True
        Me.chkAgent.Location = New System.Drawing.Point(141, 19)
        Me.chkAgent.Name = "chkAgent"
        Me.chkAgent.Size = New System.Drawing.Size(53, 17)
        Me.chkAgent.TabIndex = 52
        Me.chkAgent.TabStop = True
        Me.chkAgent.Text = "Agent"
        Me.chkAgent.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAgent)
        Me.GroupBox1.Controls.Add(Me.chkmbl)
        Me.GroupBox1.Controls.Add(Me.chkThru)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(197, 55)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        '
        'frmBillInstruction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1086, 400)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConsineethru)
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
        Me.Name = "frmBillInstruction"
        Me.Text = "Bill Instruction"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkDest As System.Windows.Forms.CheckBox
    Friend WithEvents chkMother As System.Windows.Forms.CheckBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkAttachlist As System.Windows.Forms.CheckBox
    Friend WithEvents chkContainer As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachShippingMarks As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDesc As System.Windows.Forms.CheckBox
    Friend WithEvents chkHPH As System.Windows.Forms.RadioButton
    Friend WithEvents chksgN As System.Windows.Forms.RadioButton
    Friend WithEvents chkmbl As System.Windows.Forms.RadioButton
    Friend WithEvents chkThru As System.Windows.Forms.RadioButton
    Friend WithEvents txtConsineethru As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAgent As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
