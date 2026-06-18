<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchPhieuThuTien
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
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpToDate = New System.Windows.Forms.DateTimePicker
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkDateFind = New System.Windows.Forms.RadioButton
        Me.chkVesselFind = New System.Windows.Forms.RadioButton
        Me.dgdResult = New System.Windows.Forms.DataGridView
        Me.PhieuThu_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TongCong = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdOk.Location = New System.Drawing.Point(605, 89)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Từ Ngày :"
        '
        'dtpFromDate
        '
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromDate.Location = New System.Drawing.Point(66, 28)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpFromDate.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(165, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Đến Ngày :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(31, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Vessel VoyNo :"
        '
        'dtpToDate
        '
        Me.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToDate.Location = New System.Drawing.Point(228, 26)
        Me.dtpToDate.Name = "dtpToDate"
        Me.dtpToDate.Size = New System.Drawing.Size(94, 20)
        Me.dtpToDate.TabIndex = 3
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(112, 27)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(167, 21)
        Me.cboVessel.TabIndex = 7
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdCancel.Location = New System.Drawing.Point(515, 89)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpToDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFromDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(38, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(335, 59)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ngày In Phiếu Thu Tiền"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboVessel)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(382, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 59)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tên tàu / Số Chuyến"
        '
        'chkDateFind
        '
        Me.chkDateFind.AutoSize = True
        Me.chkDateFind.ForeColor = System.Drawing.Color.Maroon
        Me.chkDateFind.Location = New System.Drawing.Point(38, 8)
        Me.chkDateFind.Name = "chkDateFind"
        Me.chkDateFind.Size = New System.Drawing.Size(140, 17)
        Me.chkDateFind.TabIndex = 10
        Me.chkDateFind.TabStop = True
        Me.chkDateFind.Text = "Tìm Theo Ngày In Phiếu"
        Me.chkDateFind.UseVisualStyleBackColor = True
        '
        'chkVesselFind
        '
        Me.chkVesselFind.AutoSize = True
        Me.chkVesselFind.ForeColor = System.Drawing.Color.Maroon
        Me.chkVesselFind.Location = New System.Drawing.Point(382, 8)
        Me.chkVesselFind.Name = "chkVesselFind"
        Me.chkVesselFind.Size = New System.Drawing.Size(92, 17)
        Me.chkVesselFind.TabIndex = 11
        Me.chkVesselFind.TabStop = True
        Me.chkVesselFind.Text = "Tìm Theo Tàu"
        Me.chkVesselFind.UseVisualStyleBackColor = True
        '
        'dgdResult
        '
        Me.dgdResult.AllowUserToAddRows = False
        Me.dgdResult.AllowUserToDeleteRows = False
        Me.dgdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PhieuThu_ID, Me.Editable, Me.Continued, Me.TongCong})
        Me.dgdResult.Location = New System.Drawing.Point(5, 128)
        Me.dgdResult.Name = "dgdResult"
        Me.dgdResult.ReadOnly = True
        Me.dgdResult.Size = New System.Drawing.Size(680, 246)
        Me.dgdResult.TabIndex = 12
        '
        'PhieuThu_ID
        '
        Me.PhieuThu_ID.HeaderText = "PhieuThu_ID"
        Me.PhieuThu_ID.Name = "PhieuThu_ID"
        Me.PhieuThu_ID.ReadOnly = True
        Me.PhieuThu_ID.Visible = False
        '
        'Editable
        '
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.ReadOnly = True
        Me.Editable.Visible = False
        '
        'Continued
        '
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Visible = False
        '
        'TongCong
        '
        Me.TongCong.HeaderText = "TongCong"
        Me.TongCong.Name = "TongCong"
        Me.TongCong.ReadOnly = True
        Me.TongCong.Visible = False
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.ForeColor = System.Drawing.Color.DarkRed
        Me.cmdExportExcel.Location = New System.Drawing.Point(423, 89)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 13
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'frmSearchPhieuThuTien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(697, 396)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.dgdResult)
        Me.Controls.Add(Me.chkVesselFind)
        Me.Controls.Add(Me.chkDateFind)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.MaximumSize = New System.Drawing.Size(977, 592)
        Me.Name = "frmSearchPhieuThuTien"
        Me.Text = "Search"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkDateFind As System.Windows.Forms.RadioButton
    Friend WithEvents chkVesselFind As System.Windows.Forms.RadioButton
    Friend WithEvents dgdResult As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents PhieuThu_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TongCong As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
