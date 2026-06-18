<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDuyetDNTT
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDuyetDNTT))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.JobDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmrCountdown = New System.Windows.Forms.Timer(Me.components)
        Me.lbltime = New System.Windows.Forms.Label()
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.txtsumSelect = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkselect = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txthbl = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.ktt = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ApproveHBL = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.dntt = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ktt_ = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.boss_ = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.job = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.vendor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cur = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 300000
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JobDetailsToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(130, 26)
        '
        'JobDetailsToolStripMenuItem
        '
        Me.JobDetailsToolStripMenuItem.Name = "JobDetailsToolStripMenuItem"
        Me.JobDetailsToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.JobDetailsToolStripMenuItem.Text = "Job details"
        '
        'tmrCountdown
        '
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Location = New System.Drawing.Point(21, 12)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(0, 13)
        Me.lbltime.TabIndex = 808
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(788, 18)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 806
        Me.Y2.Text = "2020"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(738, 18)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 805
        Me.T2.Text = "JAN"
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(517, 75)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 794
        Me.Label169.Text = "Sum..."
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(556, 70)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(153, 20)
        Me.txtsumSelect.TabIndex = 793
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.ComboBox2.Location = New System.Drawing.Point(134, 43)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 791
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(89, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 790
        Me.Label5.Text = "Dept :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(287, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 789
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(134, 18)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox1.TabIndex = 788
        Me.ComboBox1.Text = "SGN"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(718, 44)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 787
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(637, 44)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 786
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(556, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 785
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 784
        Me.Label1.Text = "Location :"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ktt, Me.ID, Me.ApproveHBL, Me.job, Me.dntt, Me.ktt_, Me.boss_, Me.mbl, Me.hbl, Me.vendor, Me.item, Me.Cur, Me.amount, Me.Remarks})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(21, 117)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Size = New System.Drawing.Size(1037, 381)
        Me.DataGridView1.TabIndex = 783
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(701, 18)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 804
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(596, 18)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 803
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(546, 18)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 802
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(509, 18)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 801
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(669, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 800
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(409, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 799
        Me.Label2.Text = "From (Date report):"
        '
        'chkselect
        '
        Me.chkselect.AutoSize = True
        Me.chkselect.Location = New System.Drawing.Point(296, 70)
        Me.chkselect.Name = "chkselect"
        Me.chkselect.Size = New System.Drawing.Size(56, 17)
        Me.chkselect.TabIndex = 798
        Me.chkselect.Text = "Select"
        Me.chkselect.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(89, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 797
        Me.Label6.Text = "HBL :"
        '
        'txthbl
        '
        Me.txthbl.Location = New System.Drawing.Point(134, 68)
        Me.txthbl.Name = "txthbl"
        Me.txthbl.Size = New System.Drawing.Size(153, 20)
        Me.txthbl.TabIndex = 796
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(287, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 795
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Checked = True
        Me.chkall.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkall.Location = New System.Drawing.Point(296, 45)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(36, 17)
        Me.chkall.TabIndex = 792
        Me.chkall.Text = "all"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'ktt
        '
        Me.ktt.HeaderText = "Acc (Approve)"
        Me.ktt.Name = "ktt"
        Me.ktt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ktt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ktt.Visible = False
        '
        'ApproveHBL
        '
        Me.ApproveHBL.HeaderText = "Approve (HBL)"
        Me.ApproveHBL.Name = "ApproveHBL"
        Me.ApproveHBL.Visible = False
        Me.ApproveHBL.Width = 83
        '
        'dntt
        '
        Me.dntt.HeaderText = "DNTT"
        Me.dntt.Name = "dntt"
        Me.dntt.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dntt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dntt.Width = 62
        '
        'ktt_
        '
        Me.ktt_.HeaderText = "Acc. Approve"
        Me.ktt_.Name = "ktt_"
        Me.ktt_.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ktt_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ktt_.Width = 89
        '
        'boss_
        '
        Me.boss_.HeaderText = "Boss Approve"
        Me.boss_.Name = "boss_"
        Me.boss_.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.boss_.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.boss_.Width = 90
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 43
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Job./Ref."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 77
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "MBL"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 54
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "HBL"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 53
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Vendor (Nhà cung cấp)"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 112
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Items (Tên phí)"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 78
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Cur. (Tiền tệ)"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 75
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn8.HeaderText = "Amount"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 68
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "Remarks (Ghi chú từ Doc.)"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 110
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        Me.ID.Width = 43
        '
        'job
        '
        Me.job.HeaderText = "Job./Ref."
        Me.job.Name = "job"
        Me.job.Width = 77
        '
        'mbl
        '
        Me.mbl.HeaderText = "MBL"
        Me.mbl.Name = "mbl"
        Me.mbl.Width = 54
        '
        'hbl
        '
        Me.hbl.HeaderText = "HBL"
        Me.hbl.Name = "hbl"
        Me.hbl.Width = 53
        '
        'vendor
        '
        Me.vendor.HeaderText = "Vendor (Nhà cung cấp)"
        Me.vendor.Name = "vendor"
        Me.vendor.Width = 112
        '
        'item
        '
        Me.item.HeaderText = "Items (Tên phí)"
        Me.item.Name = "item"
        Me.item.Width = 78
        '
        'Cur
        '
        Me.Cur.HeaderText = "Cur. (Tiền tệ)"
        Me.Cur.Name = "Cur"
        Me.Cur.Width = 75
        '
        'amount
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.amount.DefaultCellStyle = DataGridViewCellStyle1
        Me.amount.HeaderText = "Amount"
        Me.amount.Name = "amount"
        Me.amount.Width = 68
        '
        'Remarks
        '
        Me.Remarks.HeaderText = "Remarks (Ghi chú từ Doc.)"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 110
        '
        'frmDuyetDNTT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1079, 510)
        Me.Controls.Add(Me.lbltime)
        Me.Controls.Add(Me.Y2)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.Label169)
        Me.Controls.Add(Me.txtsumSelect)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.Y1)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.D1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkselect)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txthbl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkall)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDuyetDNTT"
        Me.Text = "Đề nghị thanh toán được duyệt"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents JobDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmrCountdown As System.Windows.Forms.Timer
    Friend WithEvents lbltime As System.Windows.Forms.Label
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents txtsumSelect As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkselect As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txthbl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents ktt As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveHBL As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents job As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dntt As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ktt_ As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents boss_ As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents mbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents vendor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
