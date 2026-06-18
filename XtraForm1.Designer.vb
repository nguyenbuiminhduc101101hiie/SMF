<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBangtheodoiBillTokhai
    Inherits DevExpress.XtraEditors.XtraForm

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBangtheodoiBillTokhai))
        Me.BangtheodoiBillTokhaiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HKLogDataSet = New TSA.HKLogDataSet()
        Me.chkallCus = New System.Windows.Forms.CheckBox()
        Me.cbocus = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
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
        Me.chkselect = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txthbl = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BangtheodoiBillTokhaiTableAdapter = New TSA.HKLogDataSetTableAdapters.BangtheodoiBillTokhaiTableAdapter()
        Me.BangtheodoiBillTokhaiBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.HKLogDataSet1 = New TSA.HKLogDataSet1()
        Me.BangtheodoiBillTokhaiTableAdapter1 = New TSA.HKLogDataSet1TableAdapters.BangtheodoiBillTokhaiTableAdapter()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.chkall = New System.Windows.Forms.CheckBox()
        CType(Me.BangtheodoiBillTokhaiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HKLogDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BangtheodoiBillTokhaiBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HKLogDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BangtheodoiBillTokhaiBindingSource
        '
        Me.BangtheodoiBillTokhaiBindingSource.DataMember = "BangtheodoiBillTokhai"
        Me.BangtheodoiBillTokhaiBindingSource.DataSource = Me.HKLogDataSet
        '
        'HKLogDataSet
        '
        Me.HKLogDataSet.DataSetName = "HKLogDataSet"
        Me.HKLogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'chkallCus
        '
        Me.chkallCus.AutoSize = True
        Me.chkallCus.Checked = True
        Me.chkallCus.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkallCus.Location = New System.Drawing.Point(681, 68)
        Me.chkallCus.Name = "chkallCus"
        Me.chkallCus.Size = New System.Drawing.Size(36, 17)
        Me.chkallCus.TabIndex = 895
        Me.chkallCus.Text = "all"
        Me.chkallCus.UseVisualStyleBackColor = True
        '
        'cbocus
        '
        Me.cbocus.DropDownWidth = 400
        Me.cbocus.FormattingEnabled = True
        Me.cbocus.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbocus.Location = New System.Drawing.Point(475, 66)
        Me.cbocus.Name = "cbocus"
        Me.cbocus.Size = New System.Drawing.Size(201, 21)
        Me.cbocus.TabIndex = 894
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(366, 69)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 13)
        Me.Label13.TabIndex = 893
        Me.Label13.Text = "Cus./Vendor/Agent :"
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"COMPLETE", "PENDING", "ERROR"})
        Me.ComboBox3.Location = New System.Drawing.Point(239, 11)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 892
        Me.ComboBox3.Text = "COMPLETE"
        '
        'chkallsales
        '
        Me.chkallsales.AutoSize = True
        Me.chkallsales.Checked = True
        Me.chkallsales.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkallsales.Location = New System.Drawing.Point(718, 39)
        Me.chkallsales.Name = "chkallsales"
        Me.chkallsales.Size = New System.Drawing.Size(36, 17)
        Me.chkallsales.TabIndex = 891
        Me.chkallsales.Text = "all"
        Me.chkallsales.UseVisualStyleBackColor = True
        '
        'cbosalescode
        '
        Me.cbosalescode.DropDownWidth = 300
        Me.cbosalescode.FormattingEnabled = True
        Me.cbosalescode.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbosalescode.Location = New System.Drawing.Point(475, 36)
        Me.cbosalescode.Name = "cbosalescode"
        Me.cbosalescode.Size = New System.Drawing.Size(237, 21)
        Me.cbosalescode.TabIndex = 890
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(401, 39)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 13)
        Me.Label11.TabIndex = 889
        Me.Label11.Text = "Sales code :"
        '
        'chkmbl
        '
        Me.chkmbl.AutoSize = True
        Me.chkmbl.Location = New System.Drawing.Point(245, 87)
        Me.chkmbl.Name = "chkmbl"
        Me.chkmbl.Size = New System.Drawing.Size(55, 17)
        Me.chkmbl.TabIndex = 888
        Me.chkmbl.Text = "Select"
        Me.chkmbl.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(33, 13)
        Me.Label8.TabIndex = 887
        Me.Label8.Text = "MBL :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(83, 85)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(153, 21)
        Me.TextBox1.TabIndex = 886
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(236, 85)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 885
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(236, 82)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 884
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(754, 12)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 883
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(704, 12)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 882
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(667, 12)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 881
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(562, 12)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 880
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(512, 12)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 879
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(475, 12)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 878
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(635, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 13)
        Me.Label3.TabIndex = 877
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(375, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 13)
        Me.Label2.TabIndex = 876
        Me.Label2.Text = "From (Date report):"
        '
        'chkselect
        '
        Me.chkselect.AutoSize = True
        Me.chkselect.Location = New System.Drawing.Point(245, 63)
        Me.chkselect.Name = "chkselect"
        Me.chkselect.Size = New System.Drawing.Size(55, 17)
        Me.chkselect.TabIndex = 875
        Me.chkselect.Text = "Select"
        Me.chkselect.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 13)
        Me.Label6.TabIndex = 874
        Me.Label6.Text = "HBL :"
        '
        'txthbl
        '
        Me.txthbl.Location = New System.Drawing.Point(83, 61)
        Me.txthbl.Name = "txthbl"
        Me.txthbl.Size = New System.Drawing.Size(153, 21)
        Me.txthbl.TabIndex = 873
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(236, 61)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 872
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.ComboBox2.Location = New System.Drawing.Point(83, 36)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 868
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(38, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 867
        Me.Label5.Text = "Dept :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(236, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 866
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(83, 11)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox1.TabIndex = 865
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(718, 94)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 864
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(556, 94)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 863
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(475, 94)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 862
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 861
        Me.Label1.Text = "Location :"
        '
        'BangtheodoiBillTokhaiTableAdapter
        '
        Me.BangtheodoiBillTokhaiTableAdapter.ClearBeforeFill = True
        '
        'BangtheodoiBillTokhaiBindingSource1
        '
        Me.BangtheodoiBillTokhaiBindingSource1.DataMember = "BangtheodoiBillTokhai"
        Me.BangtheodoiBillTokhaiBindingSource1.DataSource = Me.HKLogDataSet1
        '
        'HKLogDataSet1
        '
        Me.HKLogDataSet1.DataSetName = "HKLogDataSet1"
        Me.HKLogDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BangtheodoiBillTokhaiTableAdapter1
        '
        Me.BangtheodoiBillTokhaiTableAdapter1.ClearBeforeFill = True
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "archivos excel |*.xlsx"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.Location = New System.Drawing.Point(12, 136)
        Me.GridControl1.LookAndFeel.SkinName = "Office 2013"
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(978, 375)
        Me.GridControl1.TabIndex = 896
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(637, 94)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 897
        Me.Button4.Text = "Print"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(245, 40)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(54, 17)
        Me.chkall.TabIndex = 898
        Me.chkall.Text = "tất cả"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'frmBangtheodoiBillTokhai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1002, 523)
        Me.Controls.Add(Me.chkall)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.chkallCus)
        Me.Controls.Add(Me.cbocus)
        Me.Controls.Add(Me.Label13)
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
        Me.Controls.Add(Me.chkselect)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txthbl)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBangtheodoiBillTokhai"
        Me.Text = "Bảng theo dõi Bill - Tờ khai"
        CType(Me.BangtheodoiBillTokhaiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HKLogDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BangtheodoiBillTokhaiBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HKLogDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkallCus As System.Windows.Forms.CheckBox
    Friend WithEvents cbocus As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
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
    Friend WithEvents chkselect As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txthbl As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HKLogDataSet As TSA.HKLogDataSet
    Friend WithEvents BangtheodoiBillTokhaiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BangtheodoiBillTokhaiTableAdapter As TSA.HKLogDataSetTableAdapters.BangtheodoiBillTokhaiTableAdapter
    Friend WithEvents HKLogDataSet1 As TSA.HKLogDataSet1
    Friend WithEvents BangtheodoiBillTokhaiBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents BangtheodoiBillTokhaiTableAdapter1 As TSA.HKLogDataSet1TableAdapters.BangtheodoiBillTokhaiTableAdapter
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
End Class
