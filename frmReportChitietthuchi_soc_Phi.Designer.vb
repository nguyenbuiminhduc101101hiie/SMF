<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportChitietthuchi_soc_Phi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportChitietthuchi_soc_Phi))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.JobDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.chkallsales = New System.Windows.Forms.CheckBox()
        Me.cbosalescode = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkmbl = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.chkselect = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txthbl = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkVND = New System.Windows.Forms.CheckBox()
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
        Me.cbocharge = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cbocus = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.chkallCus = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chlallsoccoc = New System.Windows.Forms.RadioButton()
        Me.CHKCOC = New System.Windows.Forms.RadioButton()
        Me.CHKSOC = New System.Windows.Forms.RadioButton()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
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
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"COMPLETE", "PENDING", "ERROR"})
        Me.ComboBox3.Location = New System.Drawing.Point(253, 13)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 852
        Me.ComboBox3.Text = "COMPLETE"
        '
        'chkallsales
        '
        Me.chkallsales.AutoSize = True
        Me.chkallsales.Checked = True
        Me.chkallsales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkallsales.Location = New System.Drawing.Point(732, 41)
        Me.chkallsales.Name = "chkallsales"
        Me.chkallsales.Size = New System.Drawing.Size(36, 17)
        Me.chkallsales.TabIndex = 851
        Me.chkallsales.Text = "all"
        Me.chkallsales.UseVisualStyleBackColor = True
        '
        'cbosalescode
        '
        Me.cbosalescode.DropDownWidth = 300
        Me.cbosalescode.FormattingEnabled = True
        Me.cbosalescode.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbosalescode.Location = New System.Drawing.Point(489, 38)
        Me.cbosalescode.Name = "cbosalescode"
        Me.cbosalescode.Size = New System.Drawing.Size(237, 21)
        Me.cbosalescode.TabIndex = 850
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(415, 41)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 13)
        Me.Label11.TabIndex = 849
        Me.Label11.Text = "Sales code :"
        '
        'chkmbl
        '
        Me.chkmbl.AutoSize = True
        Me.chkmbl.Location = New System.Drawing.Point(259, 91)
        Me.chkmbl.Name = "chkmbl"
        Me.chkmbl.Size = New System.Drawing.Size(56, 17)
        Me.chkmbl.TabIndex = 848
        Me.chkmbl.Text = "Select"
        Me.chkmbl.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(52, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 847
        Me.Label8.Text = "MBL :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(97, 89)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(153, 20)
        Me.TextBox1.TabIndex = 846
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(250, 89)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 845
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(250, 86)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 844
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(768, 14)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 843
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(718, 14)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 842
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(681, 14)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 841
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(576, 14)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 840
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(526, 14)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 839
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(489, 14)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 838
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(649, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 837
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(389, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 836
        Me.Label2.Text = "From (Date report):"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(5, 168)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1002, 342)
        Me.TabControl1.TabIndex = 835
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(994, 316)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General Summary"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(982, 304)
        Me.DataGridView1.TabIndex = 46
        '
        'chkselect
        '
        Me.chkselect.AutoSize = True
        Me.chkselect.Location = New System.Drawing.Point(259, 67)
        Me.chkselect.Name = "chkselect"
        Me.chkselect.Size = New System.Drawing.Size(56, 17)
        Me.chkselect.TabIndex = 834
        Me.chkselect.Text = "Select"
        Me.chkselect.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(52, 68)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 833
        Me.Label6.Text = "HBL :"
        '
        'txthbl
        '
        Me.txthbl.Location = New System.Drawing.Point(97, 65)
        Me.txthbl.Name = "txthbl"
        Me.txthbl.Size = New System.Drawing.Size(153, 20)
        Me.txthbl.TabIndex = 832
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(250, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 831
        '
        'chkVND
        '
        Me.chkVND.AutoSize = True
        Me.chkVND.Location = New System.Drawing.Point(435, 122)
        Me.chkVND.Name = "chkVND"
        Me.chkVND.Size = New System.Drawing.Size(49, 17)
        Me.chkVND.TabIndex = 830
        Me.chkVND.Text = "VND"
        Me.chkVND.UseVisualStyleBackColor = True
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(833, 19)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 829
        Me.Label169.Text = "Sum..."
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(872, 14)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(95, 20)
        Me.txtsumSelect.TabIndex = 828
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.ComboBox2.Location = New System.Drawing.Point(97, 40)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 827
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(52, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 826
        Me.Label5.Text = "Dept :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(250, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 825
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(97, 13)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox1.TabIndex = 824
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(651, 119)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 823
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(570, 119)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 822
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(489, 119)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 821
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 820
        Me.Label1.Text = "Location :"
        '
        'cbocharge
        '
        Me.cbocharge.DropDownWidth = 300
        Me.cbocharge.FormattingEnabled = True
        Me.cbocharge.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbocharge.Location = New System.Drawing.Point(525, 63)
        Me.cbocharge.Name = "cbocharge"
        Me.cbocharge.Size = New System.Drawing.Size(201, 21)
        Me.cbocharge.TabIndex = 854
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(416, 66)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 853
        Me.Label12.Text = "Item :"
        '
        'cbocus
        '
        Me.cbocus.DropDownWidth = 400
        Me.cbocus.FormattingEnabled = True
        Me.cbocus.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbocus.Location = New System.Drawing.Point(526, 89)
        Me.cbocus.Name = "cbocus"
        Me.cbocus.Size = New System.Drawing.Size(201, 21)
        Me.cbocus.TabIndex = 856
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(417, 92)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 855
        Me.Label13.Text = "Cus./Vendor/Agent :"
        '
        'chkallCus
        '
        Me.chkallCus.AutoSize = True
        Me.chkallCus.Checked = True
        Me.chkallCus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkallCus.Location = New System.Drawing.Point(732, 91)
        Me.chkallCus.Name = "chkallCus"
        Me.chkallCus.Size = New System.Drawing.Size(36, 17)
        Me.chkallCus.TabIndex = 857
        Me.chkallCus.Text = "all"
        Me.chkallCus.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.chlallsoccoc)
        Me.GroupBox2.Controls.Add(Me.CHKCOC)
        Me.GroupBox2.Controls.Add(Me.CHKSOC)
        Me.GroupBox2.Location = New System.Drawing.Point(741, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 43)
        Me.GroupBox2.TabIndex = 858
        Me.GroupBox2.TabStop = False
        '
        'chlallsoccoc
        '
        Me.chlallsoccoc.AutoSize = True
        Me.chlallsoccoc.Checked = True
        Me.chlallsoccoc.Location = New System.Drawing.Point(97, 18)
        Me.chlallsoccoc.Name = "chlallsoccoc"
        Me.chlallsoccoc.Size = New System.Drawing.Size(44, 17)
        Me.chlallsoccoc.TabIndex = 2
        Me.chlallsoccoc.TabStop = True
        Me.chlallsoccoc.Text = "ALL"
        Me.chlallsoccoc.UseVisualStyleBackColor = True
        '
        'CHKCOC
        '
        Me.CHKCOC.AutoSize = True
        Me.CHKCOC.Location = New System.Drawing.Point(51, 18)
        Me.CHKCOC.Name = "CHKCOC"
        Me.CHKCOC.Size = New System.Drawing.Size(50, 17)
        Me.CHKCOC.TabIndex = 1
        Me.CHKCOC.Text = "COC "
        Me.CHKCOC.UseVisualStyleBackColor = True
        '
        'CHKSOC
        '
        Me.CHKSOC.AutoSize = True
        Me.CHKSOC.Location = New System.Drawing.Point(6, 18)
        Me.CHKSOC.Name = "CHKSOC"
        Me.CHKSOC.Size = New System.Drawing.Size(50, 17)
        Me.CHKSOC.TabIndex = 0
        Me.CHKSOC.Text = "SOC "
        Me.CHKSOC.UseVisualStyleBackColor = True
        '
        'frmReportChitietthuchi_soc_Phi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1019, 522)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkallCus)
        Me.Controls.Add(Me.cbocus)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.cbocharge)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.chkallsales)
        Me.Controls.Add(Me.cbosalescode)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.chkmbl)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Y2)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.Y1)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.D1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.chkselect)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txthbl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkVND)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportChitietthuchi_soc_Phi"
        Me.Text = "Report (chi tiết thu/chi từng phí)"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents JobDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents chkallsales As System.Windows.Forms.CheckBox
    Friend WithEvents cbosalescode As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkmbl As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkselect As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txthbl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkVND As System.Windows.Forms.CheckBox
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
    Friend WithEvents cbocharge As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cbocus As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents chkallCus As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chlallsoccoc As System.Windows.Forms.RadioButton
    Friend WithEvents CHKCOC As System.Windows.Forms.RadioButton
    Friend WithEvents CHKSOC As System.Windows.Forms.RadioButton
End Class
