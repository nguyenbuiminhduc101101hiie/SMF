<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThongbao_
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmThongbao_))
        Me.Button5 = New System.Windows.Forms.Button()
        Me.dgdthongbao = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Department = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Message = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LogisticsTruckingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HideẨnToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.dgdthongbao, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 20)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(43, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Load"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'dgdthongbao
        '
        Me.dgdthongbao.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdthongbao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdthongbao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdthongbao.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgdthongbao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdthongbao.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Department, Me.Message})
        Me.dgdthongbao.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdthongbao.Location = New System.Drawing.Point(12, 49)
        Me.dgdthongbao.Name = "dgdthongbao"
        Me.dgdthongbao.RowTemplate.Height = 24
        Me.dgdthongbao.Size = New System.Drawing.Size(877, 398)
        Me.dgdthongbao.TabIndex = 1
        '
        'id
        '
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        Me.id.Width = 40
        '
        'Department
        '
        Me.Department.HeaderText = "Department"
        Me.Department.Name = "Department"
        Me.Department.Width = 87
        '
        'Message
        '
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Message.DefaultCellStyle = DataGridViewCellStyle1
        Me.Message.FillWeight = 300.0!
        Me.Message.HeaderText = "Message"
        Me.Message.Name = "Message"
        Me.Message.Width = 75
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogisticsTruckingToolStripMenuItem, Me.ExportToolStripMenuItem, Me.ImportToolStripMenuItem, Me.HideẨnToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(319, 92)
        '
        'LogisticsTruckingToolStripMenuItem
        '
        Me.LogisticsTruckingToolStripMenuItem.Name = "LogisticsTruckingToolStripMenuItem"
        Me.LogisticsTruckingToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.LogisticsTruckingToolStripMenuItem.Text = "Logistics && Trucking (Khai hải quan && Vận tải)"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ExportToolStripMenuItem.Text = "Export (hàng xuất)"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.ImportToolStripMenuItem.Text = "Import (hàng nhập)"
        '
        'HideẨnToolStripMenuItem
        '
        Me.HideẨnToolStripMenuItem.Name = "HideẨnToolStripMenuItem"
        Me.HideẨnToolStripMenuItem.Size = New System.Drawing.Size(318, 22)
        Me.HideẨnToolStripMenuItem.Text = "Hide (Ẩn)"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"All", "Import", "Export", "Logistics", "KPIs", "Booking", "Quotation"})
        Me.ComboBox1.Location = New System.Drawing.Point(75, 22)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(194, 21)
        Me.ComboBox1.TabIndex = 6
        Me.ComboBox1.Text = "All"
        '
        'frmThongbao_
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(901, 459)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.dgdthongbao)
        Me.Controls.Add(Me.Button5)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmThongbao_"
        Me.Text = "Thông báo"
        CType(Me.dgdthongbao, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents dgdthongbao As System.Windows.Forms.DataGridView
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents LogisticsTruckingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HideẨnToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Department As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Message As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
End Class
