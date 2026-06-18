<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDay
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDay))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RightClickForDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button7 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txtSurcharges = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSaveService = New System.Windows.Forms.Button()
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ten = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vung = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.dai = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.nhanvien = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.vitri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tinhtrang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ghichu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RightClickForDetailsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(185, 26)
        '
        'RightClickForDetailsToolStripMenuItem
        '
        Me.RightClickForDetailsToolStripMenuItem.Name = "RightClickForDetailsToolStripMenuItem"
        Me.RightClickForDetailsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.RightClickForDetailsToolStripMenuItem.Text = "Right click for details"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 1000
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 1000000
        Me.ToolTip1.ReshowDelay = 200
        Me.ToolTip1.ShowAlways = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(980, 13)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 23)
        Me.Button7.TabIndex = 69
        Me.Button7.Text = "Ok"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Yellow
        Me.GroupBox1.Controls.Add(Me.Button9)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.txtSurcharges)
        Me.GroupBox1.Location = New System.Drawing.Point(459, 121)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(323, 263)
        Me.GroupBox1.TabIndex = 68
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Others Surcharges"
        Me.GroupBox1.Visible = False
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(92, 231)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 2
        Me.Button9.Text = "Close"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(11, 231)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 1
        Me.Button8.Text = "Save"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txtSurcharges
        '
        Me.txtSurcharges.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSurcharges.Location = New System.Drawing.Point(11, 19)
        Me.txtSurcharges.Multiline = True
        Me.txtSurcharges.Name = "txtSurcharges"
        Me.txtSurcharges.Size = New System.Drawing.Size(306, 206)
        Me.txtSurcharges.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(659, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Search (Column) :"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(880, 14)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(94, 20)
        Me.TextBox2.TabIndex = 66
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Destination", "POL", "MainPorts", "Carrier", "Coloader"})
        Me.ComboBox1.Location = New System.Drawing.Point(753, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 65
        Me.ComboBox1.Text = "Destination"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(20, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 23)
        Me.Button6.TabIndex = 64
        Me.Button6.Text = "Load"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(591, 14)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(52, 23)
        Me.Button5.TabIndex = 63
        Me.Button5.Text = "Ok"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Search All :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(423, 17)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(160, 20)
        Me.TextBox1.TabIndex = 61
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(112, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 23)
        Me.Button4.TabIndex = 60
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(66, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 23)
        Me.Button3.TabIndex = 59
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(274, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 58
        Me.Button2.Text = "Export..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(222, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(171, 14)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(46, 23)
        Me.cmdSaveService.TabIndex = 56
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdShippingLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.ten, Me.vung, Me.dai, Me.rong, Me.cao, Me.nhanvien, Me.vitri, Me.tinhtrang, Me.ghichu, Me.userupdate, Me.dateupdate})
        Me.dgdShippingLines.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdShippingLines.Location = New System.Drawing.Point(20, 43)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(990, 366)
        Me.dgdShippingLines.TabIndex = 55
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        Me.ID.Width = 43
        '
        'ten
        '
        Me.ten.DataPropertyName = "ten"
        Me.ten.HeaderText = "Name (Tên)"
        Me.ten.Name = "ten"
        Me.ten.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ten.Width = 88
        '
        'vung
        '
        Me.vung.DataPropertyName = "vung"
        Me.vung.HeaderText = "(Phân khu)"
        Me.vung.Name = "vung"
        Me.vung.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.vung.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.vung.Width = 84
        '
        'dai
        '
        Me.dai.DataPropertyName = "dai"
        Me.dai.HeaderText = "L (dài)"
        Me.dai.Name = "dai"
        Me.dai.Width = 61
        '
        'rong
        '
        Me.rong.DataPropertyName = "rong"
        Me.rong.HeaderText = "W (rộng)"
        Me.rong.Name = "rong"
        Me.rong.Width = 73
        '
        'cao
        '
        Me.cao.DataPropertyName = "cao"
        Me.cao.HeaderText = "H (cao)"
        Me.cao.Name = "cao"
        Me.cao.Width = 67
        '
        'nhanvien
        '
        Me.nhanvien.DataPropertyName = "nhanvien"
        Me.nhanvien.HeaderText = "(Nhân viên phụ trách)"
        Me.nhanvien.Name = "nhanvien"
        Me.nhanvien.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.nhanvien.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.nhanvien.Width = 99
        '
        'vitri
        '
        Me.vitri.DataPropertyName = "vitri"
        Me.vitri.HeaderText = "(Mô tả vị trí)"
        Me.vitri.Name = "vitri"
        Me.vitri.Width = 70
        '
        'tinhtrang
        '
        Me.tinhtrang.DataPropertyName = "tinhtrang"
        Me.tinhtrang.HeaderText = "Status (Tình trạng)"
        Me.tinhtrang.Name = "tinhtrang"
        Me.tinhtrang.Width = 109
        '
        'ghichu
        '
        Me.ghichu.DataPropertyName = "ghichu"
        Me.ghichu.HeaderText = "Remarks (Ghi chú)"
        Me.ghichu.Name = "ghichu"
        Me.ghichu.Width = 91
        '
        'userupdate
        '
        Me.userupdate.DataPropertyName = "userupdate"
        Me.userupdate.HeaderText = "User Update"
        Me.userupdate.Name = "userupdate"
        Me.userupdate.Width = 85
        '
        'dateupdate
        '
        Me.dateupdate.DataPropertyName = "dateupdate"
        Me.dateupdate.HeaderText = "Date Update"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Width = 86
        '
        'frmDay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 427)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDay"
        Me.Text = "Row (phân Dãy)"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RightClickForDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents txtSurcharges As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ten As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vung As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nhanvien As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents vitri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tinhtrang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ghichu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
