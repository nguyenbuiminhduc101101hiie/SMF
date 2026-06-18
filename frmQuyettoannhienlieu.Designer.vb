<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuyettoannhienlieu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQuyettoannhienlieu))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.JobDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkVND = New System.Windows.Forms.CheckBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.txtsumSelect = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbocustomer = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtsodudauky = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtnldanhan = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datereport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loaihinh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLIENT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.socont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soseal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LUONG = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PTA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PCA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PBX = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chikhac = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PCD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PXD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ghichu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtnltieuthu = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtnltoncuoiky = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtnlsuachua = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(597, 11)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 791
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(547, 11)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 790
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(510, 11)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 789
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(405, 11)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 788
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(355, 11)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 787
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(318, 11)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 786
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(478, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 785
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 784
        Me.Label2.Text = "From (Date report):"
        '
        'chkVND
        '
        Me.chkVND.AutoSize = True
        Me.chkVND.Checked = True
        Me.chkVND.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVND.Location = New System.Drawing.Point(320, 39)
        Me.chkVND.Name = "chkVND"
        Me.chkVND.Size = New System.Drawing.Size(49, 17)
        Me.chkVND.TabIndex = 778
        Me.chkVND.Text = "VND"
        Me.chkVND.UseVisualStyleBackColor = True
        Me.chkVND.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(218, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 779
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(335, 67)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 777
        Me.Label169.Text = "Sum..."
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(374, 62)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(153, 20)
        Me.txtsumSelect.TabIndex = 776
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(94, 10)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(118, 21)
        Me.ComboBox1.TabIndex = 774
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(218, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 775
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(536, 36)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 773
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(455, 36)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 772
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(374, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 771
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 770
        Me.Label1.Text = "Location :"
        '
        'cbocustomer
        '
        Me.cbocustomer.FormattingEnabled = True
        Me.cbocustomer.Location = New System.Drawing.Point(94, 38)
        Me.cbocustomer.Name = "cbocustomer"
        Me.cbocustomer.Size = New System.Drawing.Size(118, 21)
        Me.cbocustomer.TabIndex = 792
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 793
        Me.Label5.Text = "Tên nhân viên :"
        '
        'txtsodudauky
        '
        Me.txtsodudauky.Location = New System.Drawing.Point(790, 4)
        Me.txtsodudauky.Name = "txtsodudauky"
        Me.txtsodudauky.Size = New System.Drawing.Size(100, 20)
        Me.txtsodudauky.TabIndex = 794
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(707, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 795
        Me.Label6.Text = "NL tồn đầu kỳ :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(707, 28)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 797
        Me.Label8.Text = "NL đã nhận :"
        '
        'txtnldanhan
        '
        Me.txtnldanhan.Location = New System.Drawing.Point(790, 25)
        Me.txtnldanhan.Name = "txtnldanhan"
        Me.txtnldanhan.Size = New System.Drawing.Size(100, 20)
        Me.txtnldanhan.TabIndex = 796
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(707, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 799
        Me.Label9.Text = "NL đã nhận :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(790, 46)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 798
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Location = New System.Drawing.Point(9, 107)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(881, 291)
        Me.TabControl2.TabIndex = 783
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(873, 265)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "General Summary"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.datereport, Me.loaihinh, Me.CLIENT, Me.Column5, Me.Column6, Me.socont, Me.soseal, Me.Column7, Me.Column8, Me.POL, Me.POD, Me.LUONG, Me.PTA, Me.PCA, Me.PBX, Me.chikhac, Me.PCD, Me.PXD, Me.ghichu})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(861, 253)
        Me.DataGridView1.TabIndex = 261
        '
        'Column1
        '
        Me.Column1.HeaderText = "No."
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 49
        '
        'datereport
        '
        Me.datereport.HeaderText = "Ngày V.C"
        Me.datereport.Name = "datereport"
        '
        'loaihinh
        '
        Me.loaihinh.HeaderText = "Số xe"
        Me.loaihinh.Name = "loaihinh"
        '
        'CLIENT
        '
        Me.CLIENT.HeaderText = "Chủ hàng"
        Me.CLIENT.Name = "CLIENT"
        '
        'Column5
        '
        Me.Column5.HeaderText = "M/BL No."
        Me.Column5.Name = "Column5"
        Me.Column5.Width = 79
        '
        'Column6
        '
        Me.Column6.HeaderText = "HBL"
        Me.Column6.Name = "Column6"
        Me.Column6.Visible = False
        Me.Column6.Width = 53
        '
        'socont
        '
        Me.socont.HeaderText = "Số Container"
        Me.socont.Name = "socont"
        '
        'soseal
        '
        Me.soseal.HeaderText = "Số Seal"
        Me.soseal.Name = "soseal"
        '
        'Column7
        '
        Me.Column7.HeaderText = "20' "
        Me.Column7.Name = "Column7"
        Me.Column7.Width = 46
        '
        'Column8
        '
        Me.Column8.HeaderText = "40'"
        Me.Column8.Name = "Column8"
        Me.Column8.Width = 46
        '
        'POL
        '
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.Width = 53
        '
        'POD
        '
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        Me.POD.Width = 55
        '
        'LUONG
        '
        Me.LUONG.HeaderText = "Lương"
        Me.LUONG.Name = "LUONG"
        '
        'PTA
        '
        Me.PTA.HeaderText = "Tiền ăn"
        Me.PTA.Name = "PTA"
        '
        'PCA
        '
        Me.PCA.HeaderText = "Công an"
        Me.PCA.Name = "PCA"
        '
        'PBX
        '
        Me.PBX.HeaderText = "Bốc xếp"
        Me.PBX.Name = "PBX"
        '
        'chikhac
        '
        Me.chikhac.HeaderText = "Khác"
        Me.chikhac.Name = "chikhac"
        '
        'PCD
        '
        Me.PCD.HeaderText = "Phí cầu đường"
        Me.PCD.Name = "PCD"
        '
        'PXD
        '
        Me.PXD.HeaderText = "Phí xăng dầu"
        Me.PXD.Name = "PXD"
        '
        'ghichu
        '
        Me.ghichu.HeaderText = "Ghi chú"
        Me.ghichu.Name = "ghichu"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(790, 4)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 794
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(707, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 795
        Me.Label10.Text = "NL tồn đầu kỳ :"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(790, 25)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 796
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(707, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 797
        Me.Label11.Text = "NL đã nhận :"
        '
        'txtnltieuthu
        '
        Me.txtnltieuthu.Location = New System.Drawing.Point(790, 46)
        Me.txtnltieuthu.Name = "txtnltieuthu"
        Me.txtnltieuthu.Size = New System.Drawing.Size(100, 20)
        Me.txtnltieuthu.TabIndex = 798
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(707, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 799
        Me.Label12.Text = "NL tiêu thụ :"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(707, 91)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 801
        Me.Label13.Text = "NL tồn cuối kỳ :"
        '
        'txtnltoncuoiky
        '
        Me.txtnltoncuoiky.Location = New System.Drawing.Point(790, 88)
        Me.txtnltoncuoiky.Name = "txtnltoncuoiky"
        Me.txtnltoncuoiky.Size = New System.Drawing.Size(100, 20)
        Me.txtnltoncuoiky.TabIndex = 800
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(707, 70)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 13)
        Me.Label14.TabIndex = 804
        Me.Label14.Text = "NL sửa chữa :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(707, 70)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 805
        Me.Label15.Text = "NL đã nhận :"
        '
        'txtnlsuachua
        '
        Me.txtnlsuachua.Location = New System.Drawing.Point(790, 67)
        Me.txtnlsuachua.Name = "txtnlsuachua"
        Me.txtnlsuachua.Size = New System.Drawing.Size(100, 20)
        Me.txtnlsuachua.TabIndex = 802
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(790, 67)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 803
        '
        'frmQuyettoannhienlieu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 410)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtnlsuachua)
        Me.Controls.Add(Me.TextBox5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.txtnltoncuoiky)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtnltieuthu)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.txtnldanhan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.txtsodudauky)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cbocustomer)
        Me.Controls.Add(Me.Y2)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.Y1)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.D1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl2)
        Me.Controls.Add(Me.chkVND)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label169)
        Me.Controls.Add(Me.txtsumSelect)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmQuyettoannhienlieu"
        Me.Text = "Quyết toán nhiên liệu (Credit-Pay-True)"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents JobDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkVND As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents txtsumSelect As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbocustomer As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtsodudauky As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtnldanhan As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtnltieuthu As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtnltoncuoiky As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datereport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents loaihinh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLIENT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents socont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents soseal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LUONG As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PTA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PBX As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chikhac As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PXD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ghichu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtnlsuachua As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
End Class
