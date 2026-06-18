<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccounting_Report
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
        Me.components = New System.ComponentModel.Container
        Me.dgdVessel = New System.Windows.Forms.DataGridView
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHIPPING_LINE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DEST = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Payer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuBangKhaiThueCuoc = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuBangKhaiThueThuaNhapQT = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cdmCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtThueThuc = New System.Windows.Forms.TextBox
        Me.txtThueGiam = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.dgdVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdVessel
        '
        Me.dgdVessel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdVessel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVessel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.Vessel, Me.VoyNo, Me.SHIPPING_LINE, Me.POL, Me.DEST, Me.Payer, Me.BL_NO, Me.ETD})
        Me.dgdVessel.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdVessel.Location = New System.Drawing.Point(12, 123)
        Me.dgdVessel.Name = "dgdVessel"
        Me.dgdVessel.Size = New System.Drawing.Size(576, 195)
        Me.dgdVessel.TabIndex = 0
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Vessel
        '
        Me.Vessel.DataPropertyName = "Vessel"
        Me.Vessel.HeaderText = "Vessel"
        Me.Vessel.Name = "Vessel"
        '
        'VoyNo
        '
        Me.VoyNo.DataPropertyName = "VoyNo"
        Me.VoyNo.HeaderText = "Voyno"
        Me.VoyNo.Name = "VoyNo"
        '
        'SHIPPING_LINE
        '
        Me.SHIPPING_LINE.DataPropertyName = "SHIPPING_LINE"
        Me.SHIPPING_LINE.HeaderText = "SHIPPING_LINE"
        Me.SHIPPING_LINE.Name = "SHIPPING_LINE"
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.Visible = False
        '
        'DEST
        '
        Me.DEST.DataPropertyName = "DEST"
        Me.DEST.HeaderText = "DEST"
        Me.DEST.Name = "DEST"
        Me.DEST.Visible = False
        '
        'Payer
        '
        Me.Payer.DataPropertyName = "Payer"
        Me.Payer.HeaderText = "Payer"
        Me.Payer.Name = "Payer"
        Me.Payer.Visible = False
        '
        'BL_NO
        '
        Me.BL_NO.DataPropertyName = "BL_NO"
        Me.BL_NO.HeaderText = "BL_NO"
        Me.BL_NO.Name = "BL_NO"
        Me.BL_NO.Visible = False
        '
        'ETD
        '
        Me.ETD.DataPropertyName = "ETD"
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        Me.ETD.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBangKhaiThueCuoc, Me.mnuBangKhaiThueThuaNhapQT})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(256, 48)
        '
        'mnuBangKhaiThueCuoc
        '
        Me.mnuBangKhaiThueCuoc.Name = "mnuBangKhaiThueCuoc"
        Me.mnuBangKhaiThueCuoc.Size = New System.Drawing.Size(255, 22)
        Me.mnuBangKhaiThueCuoc.Text = "Bảng Khai Thuế Cước"
        '
        'mnuBangKhaiThueThuaNhapQT
        '
        Me.mnuBangKhaiThueThuaNhapQT.Name = "mnuBangKhaiThueThuaNhapQT"
        Me.mnuBangKhaiThueThuaNhapQT.Size = New System.Drawing.Size(255, 22)
        Me.mnuBangKhaiThueThuaNhapQT.Text = "Bảng Khai thu nhập Vận tải Quốc tế"
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.Location = New System.Drawing.Point(326, 77)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cdmCancel
        '
        Me.cdmCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cdmCancel.Location = New System.Drawing.Point(407, 76)
        Me.cdmCancel.Name = "cdmCancel"
        Me.cdmCancel.Size = New System.Drawing.Size(75, 23)
        Me.cdmCancel.TabIndex = 3
        Me.cdmCancel.Text = "Cancel"
        Me.cdmCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "From :"
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(89, 19)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(91, 20)
        Me.dtpFrom.TabIndex = 5
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(326, 19)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(91, 20)
        Me.dtpTo.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(298, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To :"
        '
        'txtThueThuc
        '
        Me.txtThueThuc.Location = New System.Drawing.Point(89, 46)
        Me.txtThueThuc.Name = "txtThueThuc"
        Me.txtThueThuc.Size = New System.Drawing.Size(54, 20)
        Me.txtThueThuc.TabIndex = 6
        Me.txtThueThuc.Text = "3"
        Me.txtThueThuc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtThueGiam
        '
        Me.txtThueGiam.Location = New System.Drawing.Point(326, 49)
        Me.txtThueGiam.Name = "txtThueGiam"
        Me.txtThueGiam.Size = New System.Drawing.Size(58, 20)
        Me.txtThueGiam.TabIndex = 6
        Me.txtThueGiam.Text = "1"
        Me.txtThueGiam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Thuế Phải nộp :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(234, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Thuế Miễn Giảm :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cdmCancel)
        Me.GroupBox1.Controls.Add(Me.txtThueGiam)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.txtThueThuc)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(575, 105)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(386, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(15, 13)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(145, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(15, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "%"
        '
        'frmAccounting_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 330)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgdVessel)
        Me.Name = "frmAccounting_Report"
        Me.Text = "Accounting Report"
        CType(Me.dgdVessel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgdVessel As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cdmCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtThueThuc As System.Windows.Forms.TextBox
    Friend WithEvents txtThueGiam As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHIPPING_LINE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuBangKhaiThueCuoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuBangKhaiThueThuaNhapQT As System.Windows.Forms.ToolStripMenuItem
End Class
