<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBooking
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBooking))
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.chkAttachShippingMarks = New System.Windows.Forms.CheckBox
        Me.chkAttachDesc = New System.Windows.Forms.CheckBox
        Me.chkDraft = New System.Windows.Forms.CheckBox
        Me.chkLogo = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtby = New System.Windows.Forms.TextBox
        Me.chkViewCBM = New System.Windows.Forms.CheckBox
        Me.chkDest = New System.Windows.Forms.CheckBox
        Me.chkMother = New System.Windows.Forms.CheckBox
        Me.cboBillType = New System.Windows.Forms.ComboBox
        Me.cmdRefresh = New System.Windows.Forms.Button
        Me.SuspendLayout()
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1225, 344)
        Me.CrystalReportViewer1.TabIndex = 8
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'chkAttachShippingMarks
        '
        Me.chkAttachShippingMarks.AutoSize = True
        Me.chkAttachShippingMarks.Location = New System.Drawing.Point(904, 32)
        Me.chkAttachShippingMarks.Name = "chkAttachShippingMarks"
        Me.chkAttachShippingMarks.Size = New System.Drawing.Size(89, 17)
        Me.chkAttachShippingMarks.TabIndex = 41
        Me.chkAttachShippingMarks.Text = "Attach Marks"
        Me.chkAttachShippingMarks.UseVisualStyleBackColor = True
        Me.chkAttachShippingMarks.Visible = False
        '
        'chkAttachDesc
        '
        Me.chkAttachDesc.AutoSize = True
        Me.chkAttachDesc.Location = New System.Drawing.Point(810, 32)
        Me.chkAttachDesc.Name = "chkAttachDesc"
        Me.chkAttachDesc.Size = New System.Drawing.Size(88, 17)
        Me.chkAttachDesc.TabIndex = 40
        Me.chkAttachDesc.Text = "Attach Desc."
        Me.chkAttachDesc.UseVisualStyleBackColor = True
        Me.chkAttachDesc.Visible = False
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Location = New System.Drawing.Point(607, 10)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 32
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        Me.chkDraft.Visible = False
        '
        'chkLogo
        '
        Me.chkLogo.AutoSize = True
        Me.chkLogo.Location = New System.Drawing.Point(563, 10)
        Me.chkLogo.Name = "chkLogo"
        Me.chkLogo.Size = New System.Drawing.Size(50, 17)
        Me.chkLogo.TabIndex = 39
        Me.chkLogo.Text = "Logo"
        Me.chkLogo.UseVisualStyleBackColor = True
        Me.chkLogo.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(372, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "by :"
        Me.Label1.Visible = False
        '
        'txtby
        '
        Me.txtby.Location = New System.Drawing.Point(402, 30)
        Me.txtby.Name = "txtby"
        Me.txtby.Size = New System.Drawing.Size(300, 20)
        Me.txtby.TabIndex = 37
        Me.txtby.Visible = False
        '
        'chkViewCBM
        '
        Me.chkViewCBM.AutoSize = True
        Me.chkViewCBM.Location = New System.Drawing.Point(729, 33)
        Me.chkViewCBM.Name = "chkViewCBM"
        Me.chkViewCBM.Size = New System.Drawing.Size(75, 17)
        Me.chkViewCBM.TabIndex = 36
        Me.chkViewCBM.Text = "View CBM"
        Me.chkViewCBM.UseVisualStyleBackColor = True
        Me.chkViewCBM.Visible = False
        '
        'chkDest
        '
        Me.chkDest.AutoSize = True
        Me.chkDest.Checked = True
        Me.chkDest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDest.Location = New System.Drawing.Point(729, 11)
        Me.chkDest.Name = "chkDest"
        Me.chkDest.Size = New System.Drawing.Size(81, 17)
        Me.chkDest.TabIndex = 35
        Me.chkDest.Text = "Show Dest."
        Me.chkDest.UseVisualStyleBackColor = True
        Me.chkDest.Visible = False
        '
        'chkMother
        '
        Me.chkMother.AutoSize = True
        Me.chkMother.Location = New System.Drawing.Point(655, 10)
        Me.chkMother.Name = "chkMother"
        Me.chkMother.Size = New System.Drawing.Size(72, 17)
        Me.chkMother.TabIndex = 34
        Me.chkMother.Text = "V. Mother"
        Me.chkMother.UseVisualStyleBackColor = True
        Me.chkMother.Visible = False
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"", "ORIGINAL", "SURRENDERED", "SEAWAY"})
        Me.cboBillType.Location = New System.Drawing.Point(938, 8)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 33
        Me.cboBillType.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(857, 7)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 31
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        Me.cmdRefresh.Visible = False
        '
        'frmBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1225, 344)
        Me.Controls.Add(Me.chkAttachShippingMarks)
        Me.Controls.Add(Me.chkAttachDesc)
        Me.Controls.Add(Me.chkDraft)
        Me.Controls.Add(Me.chkLogo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtby)
        Me.Controls.Add(Me.chkViewCBM)
        Me.Controls.Add(Me.chkDest)
        Me.Controls.Add(Me.chkMother)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBooking"
        Me.Text = "Booking"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkAttachShippingMarks As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDesc As System.Windows.Forms.CheckBox
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents chkLogo As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtby As System.Windows.Forms.TextBox
    Friend WithEvents chkViewCBM As System.Windows.Forms.CheckBox
    Friend WithEvents chkDest As System.Windows.Forms.CheckBox
    Friend WithEvents chkMother As System.Windows.Forms.CheckBox
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
End Class
