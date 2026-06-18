<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintVAT_Nhom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintVAT_Nhom))
        Me.cboLien = New System.Windows.Forms.ComboBox()
        Me.chkShowMST = New System.Windows.Forms.CheckBox()
        Me.chkDraft = New System.Windows.Forms.CheckBox()
        Me.chkClucidat = New System.Windows.Forms.CheckBox()
        Me.chkKhung = New System.Windows.Forms.CheckBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chktigia = New System.Windows.Forms.CheckBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'cboLien
        '
        Me.cboLien.FormattingEnabled = True
        Me.cboLien.Items.AddRange(New Object() {"Liên 1 : Lưu (Copy 1: Save)", "Liên 2: Giao cho người mua(Copy 2: Buyer kept)", "Liên 3: Hoạch toán nội bộ(Copy 3: Internal)"})
        Me.cboLien.Location = New System.Drawing.Point(429, 25)
        Me.cboLien.Name = "cboLien"
        Me.cboLien.Size = New System.Drawing.Size(326, 21)
        Me.cboLien.TabIndex = 16
        Me.cboLien.Text = "Liên 1 : Lưu (Copy 1: Save)"
        '
        'chkShowMST
        '
        Me.chkShowMST.AutoSize = True
        Me.chkShowMST.BackColor = System.Drawing.Color.Transparent
        Me.chkShowMST.Checked = True
        Me.chkShowMST.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkShowMST.Location = New System.Drawing.Point(515, 6)
        Me.chkShowMST.Name = "chkShowMST"
        Me.chkShowMST.Size = New System.Drawing.Size(79, 17)
        Me.chkShowMST.TabIndex = 15
        Me.chkShowMST.Text = "Show MST"
        Me.chkShowMST.UseVisualStyleBackColor = False
        '
        'chkDraft
        '
        Me.chkDraft.AutoSize = True
        Me.chkDraft.BackColor = System.Drawing.Color.Transparent
        Me.chkDraft.Location = New System.Drawing.Point(600, 6)
        Me.chkDraft.Name = "chkDraft"
        Me.chkDraft.Size = New System.Drawing.Size(49, 17)
        Me.chkDraft.TabIndex = 14
        Me.chkDraft.Text = "Draft"
        Me.chkDraft.UseVisualStyleBackColor = False
        '
        'chkClucidat
        '
        Me.chkClucidat.AutoSize = True
        Me.chkClucidat.BackColor = System.Drawing.Color.Transparent
        Me.chkClucidat.Location = New System.Drawing.Point(359, 27)
        Me.chkClucidat.Name = "chkClucidat"
        Me.chkClucidat.Size = New System.Drawing.Size(64, 17)
        Me.chkClucidat.TabIndex = 13
        Me.chkClucidat.Text = "Clucidat"
        Me.chkClucidat.UseVisualStyleBackColor = False
        Me.chkClucidat.Visible = False
        '
        'chkKhung
        '
        Me.chkKhung.AutoSize = True
        Me.chkKhung.BackColor = System.Drawing.Color.Transparent
        Me.chkKhung.Location = New System.Drawing.Point(456, 6)
        Me.chkKhung.Name = "chkKhung"
        Me.chkKhung.Size = New System.Drawing.Size(59, 17)
        Me.chkKhung.TabIndex = 12
        Me.chkKhung.Text = "Bill No."
        Me.chkKhung.UseVisualStyleBackColor = False
        Me.chkKhung.Visible = False
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(680, 2)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 11
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chktigia
        '
        Me.chktigia.AutoSize = True
        Me.chktigia.Location = New System.Drawing.Point(359, 6)
        Me.chktigia.Name = "chktigia"
        Me.chktigia.Size = New System.Drawing.Size(91, 17)
        Me.chktigia.TabIndex = 10
        Me.chktigia.Text = "Hiển thị Tỉ giá"
        Me.chktigia.UseVisualStyleBackColor = True
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
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1096, 618)
        Me.CrystalReportViewer1.TabIndex = 9
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'frmPrintVAT_Nhom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1096, 618)
        Me.Controls.Add(Me.cboLien)
        Me.Controls.Add(Me.chkShowMST)
        Me.Controls.Add(Me.chkDraft)
        Me.Controls.Add(Me.chkClucidat)
        Me.Controls.Add(Me.chkKhung)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chktigia)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintVAT_Nhom"
        Me.Text = "Invoice (Group)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboLien As System.Windows.Forms.ComboBox
    Friend WithEvents chkShowMST As System.Windows.Forms.CheckBox
    Friend WithEvents chkDraft As System.Windows.Forms.CheckBox
    Friend WithEvents chkClucidat As System.Windows.Forms.CheckBox
    Friend WithEvents chkKhung As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chktigia As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
