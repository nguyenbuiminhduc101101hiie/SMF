<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTheodoinhienlieu
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim PointSeriesLabel1 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()
        Dim PointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim LineSeriesView1 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim PointSeriesLabel2 As DevExpress.XtraCharts.PointSeriesLabel = New DevExpress.XtraCharts.PointSeriesLabel()
        Dim PointOptions2 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim LineSeriesView2 As DevExpress.XtraCharts.LineSeriesView = New DevExpress.XtraCharts.LineSeriesView()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTheodoinhienlieu))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.JobDetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtnlsuachua = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtnltoncuoiky = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtnltieuthu = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.txtnldanhan = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.txtsodudauky = New System.Windows.Forms.TextBox()
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.SalesreportchartshowTableAdapter = New TSA.FDIDataSet2TableAdapters.salesreportchartshowTableAdapter()
        Me.SalesreportchartshowBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FDIDataSet2 = New TSA.FDIDataSet2()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.soxe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.laixe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLDauky = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLTieuthu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLDanhan = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLsuachua = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NLCuoiky = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ghichu = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkVND = New System.Windows.Forms.CheckBox()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.txtsumSelect = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(PointSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesreportchartshowBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FDIDataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(708, 72)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(74, 13)
        Me.Label14.TabIndex = 843
        Me.Label14.Text = "NL sửa chữa :"
        Me.Label14.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(708, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(70, 13)
        Me.Label15.TabIndex = 844
        Me.Label15.Text = "NL đã nhận :"
        Me.Label15.Visible = False
        '
        'txtnlsuachua
        '
        Me.txtnlsuachua.Location = New System.Drawing.Point(791, 69)
        Me.txtnlsuachua.Name = "txtnlsuachua"
        Me.txtnlsuachua.Size = New System.Drawing.Size(100, 20)
        Me.txtnlsuachua.TabIndex = 841
        Me.txtnlsuachua.Visible = False
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(791, 69)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(100, 20)
        Me.TextBox5.TabIndex = 842
        Me.TextBox5.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(708, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 840
        Me.Label13.Text = "NL tồn cuối kỳ :"
        Me.Label13.Visible = False
        '
        'txtnltoncuoiky
        '
        Me.txtnltoncuoiky.Location = New System.Drawing.Point(791, 90)
        Me.txtnltoncuoiky.Name = "txtnltoncuoiky"
        Me.txtnltoncuoiky.Size = New System.Drawing.Size(100, 20)
        Me.txtnltoncuoiky.TabIndex = 839
        Me.txtnltoncuoiky.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(708, 51)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 13)
        Me.Label12.TabIndex = 838
        Me.Label12.Text = "NL tiêu thụ :"
        Me.Label12.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(708, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 837
        Me.Label9.Text = "NL đã nhận :"
        Me.Label9.Visible = False
        '
        'txtnltieuthu
        '
        Me.txtnltieuthu.Location = New System.Drawing.Point(791, 48)
        Me.txtnltieuthu.Name = "txtnltieuthu"
        Me.txtnltieuthu.Size = New System.Drawing.Size(100, 20)
        Me.txtnltieuthu.TabIndex = 835
        Me.txtnltieuthu.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(791, 48)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 836
        Me.TextBox1.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(708, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 834
        Me.Label11.Text = "NL đã nhận :"
        Me.Label11.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(708, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 833
        Me.Label8.Text = "NL đã nhận :"
        Me.Label8.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(791, 27)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 832
        Me.TextBox3.Visible = False
        '
        'txtnldanhan
        '
        Me.txtnldanhan.Location = New System.Drawing.Point(791, 27)
        Me.txtnldanhan.Name = "txtnldanhan"
        Me.txtnldanhan.Size = New System.Drawing.Size(100, 20)
        Me.txtnldanhan.TabIndex = 831
        Me.txtnldanhan.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(708, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 13)
        Me.Label10.TabIndex = 830
        Me.Label10.Text = "NL tồn đầu kỳ :"
        Me.Label10.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(708, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 829
        Me.Label6.Text = "NL tồn đầu kỳ :"
        Me.Label6.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(791, 6)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 828
        Me.TextBox2.Visible = False
        '
        'txtsodudauky
        '
        Me.txtsodudauky.Location = New System.Drawing.Point(791, 6)
        Me.txtsodudauky.Name = "txtsodudauky"
        Me.txtsodudauky.Size = New System.Drawing.Size(100, 20)
        Me.txtsodudauky.TabIndex = 827
        Me.txtsodudauky.Visible = False
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(598, 13)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 824
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(548, 13)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 823
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(511, 13)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 822
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(406, 13)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 821
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(356, 13)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 820
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(319, 13)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 819
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(479, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 818
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(219, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 817
        Me.Label2.Text = "From (Date report):"
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Location = New System.Drawing.Point(10, 109)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(922, 336)
        Me.TabControl2.TabIndex = 816
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.ChartControl1)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(914, 310)
        Me.TabPage2.TabIndex = 0
        Me.TabPage2.Text = "General Summary"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ChartControl1
        '
        Me.ChartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartControl1.CrosshairOptions.ArgumentLineColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ChartControl1.CrosshairOptions.ValueLineColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ChartControl1.DataAdapter = Me.SalesreportchartshowTableAdapter
        Me.ChartControl1.DataSource = Me.SalesreportchartshowBindingSource
        XyDiagram1.AxisX.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        XyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisX.Range.SideMarginsEnabled = True
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        XyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisY.Range.SideMarginsEnabled = True
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Location = New System.Drawing.Point(563, 6)
        Me.ChartControl1.Name = "ChartControl1"
        Series1.ArgumentDataMember = "sanpham"
        Series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        PointSeriesLabel1.LineVisible = True
        PointOptions1.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        PointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        PointSeriesLabel1.PointOptions = PointOptions1
        Series1.Label = PointSeriesLabel1
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.Name = "Nhiên liệu"
        Series1.ValueDataMembersSerializable = "soluong"
        Series1.View = LineSeriesView1
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.ChartControl1.SeriesTemplate.ArgumentDataMember = "sanpham"
        Me.ChartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        PointSeriesLabel2.LineVisible = True
        PointOptions2.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        PointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        PointSeriesLabel2.PointOptions = PointOptions2
        Me.ChartControl1.SeriesTemplate.Label = PointSeriesLabel2
        Me.ChartControl1.SeriesTemplate.ValueDataMembersSerializable = "soluong"
        Me.ChartControl1.SeriesTemplate.View = LineSeriesView2
        Me.ChartControl1.Size = New System.Drawing.Size(341, 298)
        Me.ChartControl1.TabIndex = 262
        '
        'SalesreportchartshowTableAdapter
        '
        Me.SalesreportchartshowTableAdapter.ClearBeforeFill = True
        '
        'SalesreportchartshowBindingSource
        '
        Me.SalesreportchartshowBindingSource.DataMember = "salesreportchartshow"
        Me.SalesreportchartshowBindingSource.DataSource = Me.FDIDataSet2
        '
        'FDIDataSet2
        '
        Me.FDIDataSet2.DataSetName = "FDIDataSet2"
        Me.FDIDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.soxe, Me.laixe, Me.NLDauky, Me.NLTieuthu, Me.NLDanhan, Me.NLsuachua, Me.NLCuoiky, Me.ghichu})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(551, 298)
        Me.DataGridView1.TabIndex = 261
        '
        'Column1
        '
        Me.Column1.HeaderText = "No."
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 49
        '
        'soxe
        '
        Me.soxe.HeaderText = "Số xe"
        Me.soxe.Name = "soxe"
        Me.soxe.Width = 45
        '
        'laixe
        '
        Me.laixe.HeaderText = "Lái xe"
        Me.laixe.Name = "laixe"
        Me.laixe.Width = 46
        '
        'NLDauky
        '
        Me.NLDauky.HeaderText = "Nhiên liệu đầu kỳ"
        Me.NLDauky.Name = "NLDauky"
        Me.NLDauky.Width = 96
        '
        'NLTieuthu
        '
        Me.NLTieuthu.HeaderText = "Nhiên liệu tiêu thụ"
        Me.NLTieuthu.Name = "NLTieuthu"
        Me.NLTieuthu.Width = 94
        '
        'NLDanhan
        '
        Me.NLDanhan.HeaderText = "Nhiên liệu đã nhận"
        Me.NLDanhan.Name = "NLDanhan"
        Me.NLDanhan.Width = 90
        '
        'NLsuachua
        '
        Me.NLsuachua.HeaderText = "Nhiên liệu sửa chữa"
        Me.NLsuachua.Name = "NLsuachua"
        Me.NLsuachua.Width = 94
        '
        'NLCuoiky
        '
        Me.NLCuoiky.HeaderText = "Nhiên liệu cuối kỳ"
        Me.NLCuoiky.Name = "NLCuoiky"
        Me.NLCuoiky.Width = 96
        '
        'ghichu
        '
        Me.ghichu.HeaderText = "Ghi chú"
        Me.ghichu.Name = "ghichu"
        Me.ghichu.Width = 64
        '
        'chkVND
        '
        Me.chkVND.AutoSize = True
        Me.chkVND.Checked = True
        Me.chkVND.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVND.Location = New System.Drawing.Point(321, 41)
        Me.chkVND.Name = "chkVND"
        Me.chkVND.Size = New System.Drawing.Size(49, 17)
        Me.chkVND.TabIndex = 814
        Me.chkVND.Text = "VND"
        Me.chkVND.UseVisualStyleBackColor = True
        Me.chkVND.Visible = False
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(336, 69)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 813
        Me.Label169.Text = "Sum..."
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(375, 64)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(153, 20)
        Me.txtsumSelect.TabIndex = 812
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(95, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(118, 21)
        Me.ComboBox1.TabIndex = 810
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(537, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 809
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(456, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 808
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(375, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 807
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 806
        Me.Label1.Text = "Location :"
        '
        'frmTheodoinhienlieu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(944, 449)
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
        Me.Controls.Add(Me.Label169)
        Me.Controls.Add(Me.txtsumSelect)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTheodoinhienlieu"
        Me.Text = "Theo dõi nhiên liệu (Credit-Pay-True)"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(PointSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(LineSeriesView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesreportchartshowBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FDIDataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents JobDetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtnlsuachua As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtnltoncuoiky As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtnltieuthu As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents txtnldanhan As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents txtsodudauky As System.Windows.Forms.TextBox
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkVND As System.Windows.Forms.CheckBox
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents txtsumSelect As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents soxe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents laixe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLDauky As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLTieuthu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLDanhan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLsuachua As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NLCuoiky As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ghichu As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents SalesreportchartshowTableAdapter As TSA.FDIDataSet2TableAdapters.salesreportchartshowTableAdapter
    Friend WithEvents FDIDataSet2 As TSA.FDIDataSet2
    Friend WithEvents SalesreportchartshowBindingSource As System.Windows.Forms.BindingSource
End Class
