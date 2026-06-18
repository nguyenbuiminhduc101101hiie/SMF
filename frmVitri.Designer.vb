<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVitri
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVitri))
        Me.cbonhakho = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbovung = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboday = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ten = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dai = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cao = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vitri = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tinhtrang = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ghichu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmdAdd = New System.Windows.Forms.Button()
        Me.cmdedit = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbonhakho
        '
        Me.cbonhakho.FormattingEnabled = True
        Me.cbonhakho.Location = New System.Drawing.Point(40, 29)
        Me.cbonhakho.Name = "cbonhakho"
        Me.cbonhakho.Size = New System.Drawing.Size(186, 21)
        Me.cbonhakho.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Ware house (Nhà kho):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Area (Vùng):"
        '
        'cbovung
        '
        Me.cbovung.FormattingEnabled = True
        Me.cbovung.Location = New System.Drawing.Point(40, 72)
        Me.cbovung.Name = "cbovung"
        Me.cbovung.Size = New System.Drawing.Size(186, 21)
        Me.cbovung.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(37, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Rows (dãy):"
        '
        'cboday
        '
        Me.cboday.FormattingEnabled = True
        Me.cboday.Location = New System.Drawing.Point(40, 116)
        Me.cboday.Name = "cboday"
        Me.cboday.Size = New System.Drawing.Size(186, 21)
        Me.cboday.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.day, Me.ten, Me.dai, Me.rong, Me.cao, Me.vitri, Me.tinhtrang, Me.ghichu})
        Me.DataGridView1.Location = New System.Drawing.Point(232, 29)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(753, 191)
        Me.DataGridView1.TabIndex = 6
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'day
        '
        Me.day.DataPropertyName = "day"
        Me.day.HeaderText = "Row (dãy)"
        Me.day.Name = "day"
        Me.day.Width = 80
        '
        'ten
        '
        Me.ten.DataPropertyName = "ten"
        Me.ten.HeaderText = "(Tên Vị trí)"
        Me.ten.Name = "ten"
        Me.ten.Width = 82
        '
        'dai
        '
        Me.dai.DataPropertyName = "dai"
        Me.dai.HeaderText = "(Dài)"
        Me.dai.Name = "dai"
        Me.dai.Width = 54
        '
        'rong
        '
        Me.rong.DataPropertyName = "rong"
        Me.rong.HeaderText = "(Rộng)"
        Me.rong.Name = "rong"
        Me.rong.Width = 64
        '
        'cao
        '
        Me.cao.DataPropertyName = "cao"
        Me.cao.HeaderText = "(Cao)"
        Me.cao.Name = "cao"
        Me.cao.Width = 57
        '
        'vitri
        '
        Me.vitri.DataPropertyName = "vitri"
        Me.vitri.HeaderText = "(Mô tả vị trí)"
        Me.vitri.Name = "vitri"
        Me.vitri.Width = 89
        '
        'tinhtrang
        '
        Me.tinhtrang.DataPropertyName = "tinhtrang"
        Me.tinhtrang.HeaderText = "(Tình trạng)"
        Me.tinhtrang.Name = "tinhtrang"
        Me.tinhtrang.Width = 86
        '
        'ghichu
        '
        Me.ghichu.DataPropertyName = "ghichu"
        Me.ghichu.HeaderText = "(Ghi chú)"
        Me.ghichu.Name = "ghichu"
        Me.ghichu.Width = 75
        '
        'cmdAdd
        '
        Me.cmdAdd.Location = New System.Drawing.Point(40, 143)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 7
        Me.cmdAdd.Text = "Add (thêm)"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cmdedit
        '
        Me.cmdedit.Location = New System.Drawing.Point(121, 143)
        Me.cmdedit.Name = "cmdedit"
        Me.cmdedit.Size = New System.Drawing.Size(75, 23)
        Me.cmdedit.TabIndex = 8
        Me.cmdedit.Text = "Edit (chỉnh)"
        Me.cmdedit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Location = New System.Drawing.Point(232, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(753, 187)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(121, 172)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 172)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(121, 201)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmVitri
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 425)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdedit)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboday)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbovung)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbonhakho)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVitri"
        Me.Text = "Location"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbonhakho As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbovung As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboday As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cmdedit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ten As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cao As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vitri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tinhtrang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ghichu As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
