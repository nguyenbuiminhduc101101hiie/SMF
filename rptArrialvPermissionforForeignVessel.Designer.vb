<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptArrialvPermissionforForeignVessel
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.cmdUpdateInfo = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnShow = New System.Windows.Forms.Button
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.dtpKeTuNgay = New System.Windows.Forms.DateTimePicker
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grpComfirmInfo = New System.Windows.Forms.GroupBox
        Me.grpComfirmInfo.SuspendLayout()
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(918, 360)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cmdUpdateInfo
        '
        Me.cmdUpdateInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateInfo.Location = New System.Drawing.Point(821, 12)
        Me.cmdUpdateInfo.Name = "cmdUpdateInfo"
        Me.cmdUpdateInfo.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdateInfo.TabIndex = 5
        Me.cmdUpdateInfo.Text = "Update Info"
        Me.cmdUpdateInfo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ngày :"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(171, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Kể Từ Ngày :"
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(165, 71)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "&Ok"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'dtpDate
        '
        Me.dtpDate.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(67, 30)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(98, 20)
        Me.dtpDate.TabIndex = 3
        '
        'dtpKeTuNgay
        '
        Me.dtpKeTuNgay.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpKeTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpKeTuNgay.Location = New System.Drawing.Point(243, 29)
        Me.dtpKeTuNgay.Name = "dtpKeTuNgay"
        Me.dtpKeTuNgay.Size = New System.Drawing.Size(98, 20)
        Me.dtpKeTuNgay.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(243, 71)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'grpComfirmInfo
        '
        Me.grpComfirmInfo.Controls.Add(Me.cmdCancel)
        Me.grpComfirmInfo.Controls.Add(Me.dtpKeTuNgay)
        Me.grpComfirmInfo.Controls.Add(Me.dtpDate)
        Me.grpComfirmInfo.Controls.Add(Me.btnShow)
        Me.grpComfirmInfo.Controls.Add(Me.Label4)
        Me.grpComfirmInfo.Controls.Add(Me.Label2)
        Me.grpComfirmInfo.Location = New System.Drawing.Point(274, 74)
        Me.grpComfirmInfo.Name = "grpComfirmInfo"
        Me.grpComfirmInfo.Size = New System.Drawing.Size(347, 103)
        Me.grpComfirmInfo.TabIndex = 5
        Me.grpComfirmInfo.TabStop = False
        Me.grpComfirmInfo.Text = "Confirm Information"
        Me.grpComfirmInfo.Visible = False
        '
        'rptArrialvPermissionforForeignVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 360)
        Me.Controls.Add(Me.cmdUpdateInfo)
        Me.Controls.Add(Me.grpComfirmInfo)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.MinimumSize = New System.Drawing.Size(926, 387)
        Me.Name = "rptArrialvPermissionforForeignVessel"
        Me.Text = "Report Arrival Permission for Foreign Vessel"
        Me.grpComfirmInfo.ResumeLayout(False)
        Me.grpComfirmInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdUpdateInfo As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpKeTuNgay As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grpComfirmInfo As System.Windows.Forms.GroupBox
End Class
