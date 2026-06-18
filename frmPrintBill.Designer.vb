<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintBill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintBill))
        Me.cboBillType = New System.Windows.Forms.ComboBox()
        Me.chkDraft = New System.Windows.Forms.CheckBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.chkdescriptionall = New System.Windows.Forms.CheckBox()
        Me.chkSign = New System.Windows.Forms.CheckBox()
        Me.chkatt = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboBillType
        '
        Me.cboBillType.FormattingEnabled = True
        Me.cboBillType.Items.AddRange(New Object() {"", "ORIGINAL", "SURRENDERED", "SEAWAY", "COPY"})
        Me.cboBillType.Location = New System.Drawing.Point(151, 8)
        Me.cboBillType.Name = "cboBillType"
        Me.cboBillType.Size = New System.Drawing.Size(116, 21)
        Me.cboBillType.TabIndex = 26
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.Location = New System.Drawing.Point(12, 12)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 25
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = True
        Me.chkDraft.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(70, 7)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 24
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
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 36)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(875, 404)
        Me.CrystalReportViewer1.TabIndex = 23
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'chkdescriptionall
        '
        Me.chkdescriptionall.AutoSize = True
        Me.chkdescriptionall.Checked = True
        Me.chkdescriptionall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkdescriptionall.Location = New System.Drawing.Point(273, 10)
        Me.chkdescriptionall.Name = "chkdescriptionall"
        Me.chkdescriptionall.Size = New System.Drawing.Size(93, 17)
        Me.chkdescriptionall.TabIndex = 27
        Me.chkdescriptionall.Text = "Description All"
        Me.chkdescriptionall.UseVisualStyleBackColor = True
        '
        'chkSign
        '
        Me.chkSign.AutoSize = True
        Me.chkSign.Location = New System.Drawing.Point(372, 10)
        Me.chkSign.Name = "chkSign"
        Me.chkSign.Size = New System.Drawing.Size(47, 17)
        Me.chkSign.TabIndex = 28
        Me.chkSign.Text = "Sign"
        Me.chkSign.UseVisualStyleBackColor = True
        '
        'chkatt
        '
        Me.chkatt.AutoSize = True
        Me.chkatt.Location = New System.Drawing.Point(425, 10)
        Me.chkatt.Name = "chkatt"
        Me.chkatt.Size = New System.Drawing.Size(84, 17)
        Me.chkatt.TabIndex = 29
        Me.chkatt.Text = "Att. (page 1)"
        Me.chkatt.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(522, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 23)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Print (Att. page 2)"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmPrintBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 452)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkatt)
        Me.Controls.Add(Me.chkSign)
        Me.Controls.Add(Me.chkdescriptionall)
        Me.Controls.Add(Me.cboBillType)
        Me.Controls.Add(Me.chkDraft)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintBill"
        Me.Text = "Print Bill"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboBillType As System.Windows.Forms.ComboBox
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkdescriptionall As System.Windows.Forms.CheckBox
    Friend WithEvents chkSign As System.Windows.Forms.CheckBox
    Friend WithEvents chkatt As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
