<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBaocaosanluongtheotuyen
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
        Dim XyDiagram1 As DevExpress.XtraCharts.XYDiagram = New DevExpress.XtraCharts.XYDiagram()
        Dim Series1 As DevExpress.XtraCharts.Series = New DevExpress.XtraCharts.Series()
        Dim SideBySideBarSeriesLabel1 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim PointOptions1 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim SideBySideBarSeriesLabel2 As DevExpress.XtraCharts.SideBySideBarSeriesLabel = New DevExpress.XtraCharts.SideBySideBarSeriesLabel()
        Dim PointOptions2 As DevExpress.XtraCharts.PointOptions = New DevExpress.XtraCharts.PointOptions()
        Dim ChartTitle1 As DevExpress.XtraCharts.ChartTitle = New DevExpress.XtraCharts.ChartTitle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBaocaosanluongtheotuyen))
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cbonhom = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkVND = New System.Windows.Forms.CheckBox()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.txtsumSelect = New System.Windows.Forms.TextBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.chkallTuyen = New System.Windows.Forms.CheckBox()
        Me.cbotuyen = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ChartControl1 = New DevExpress.XtraCharts.ChartControl()
        Me.SalesreportchartshowTableAdapter = New TSA.FDIDataSetTableAdapters.salesreportchartshowTableAdapter()
        Me.FDIDataSet = New TSA.FDIDataSet()
        Me.SalesreportchartshowBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.chkteu = New System.Windows.Forms.RadioButton()
        Me.chkcbm = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chlallsoccoc = New System.Windows.Forms.RadioButton()
        Me.CHKCOC = New System.Windows.Forms.RadioButton()
        Me.CHKSOC = New System.Windows.Forms.RadioButton()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtfindcus = New System.Windows.Forms.TextBox()
        Me.cboCusNhap = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboPOL = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboFLC = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.job = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loaihinh = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tuyen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.agent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cont20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cont40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Kgs = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CBM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FDIDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesreportchartshowBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(759, 11)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 788
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(709, 11)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 787
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(672, 11)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 786
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(567, 11)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 785
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(517, 11)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 784
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(480, 11)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 783
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(640, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 782
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(380, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 781
        Me.Label2.Text = "From (Date report):"
        '
        'cbonhom
        '
        Me.cbonhom.FormattingEnabled = True
        Me.cbonhom.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbonhom.Location = New System.Drawing.Point(757, 36)
        Me.cbonhom.Name = "cbonhom"
        Me.cbonhom.Size = New System.Drawing.Size(104, 21)
        Me.cbonhom.TabIndex = 780
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(683, 39)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 779
        Me.Label7.Text = "Sales group :"
        '
        'chkVND
        '
        Me.chkVND.AutoSize = True
        Me.chkVND.Location = New System.Drawing.Point(386, 43)
        Me.chkVND.Name = "chkVND"
        Me.chkVND.Size = New System.Drawing.Size(49, 17)
        Me.chkVND.TabIndex = 778
        Me.chkVND.Text = "VND"
        Me.chkVND.UseVisualStyleBackColor = True
        Me.chkVND.Visible = False
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(718, 65)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 777
        Me.Label169.Text = "Sum..."
        Me.Label169.Visible = False
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(757, 60)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(104, 20)
        Me.txtsumSelect.TabIndex = 776
        Me.txtsumSelect.Visible = False
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(232, 30)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(36, 17)
        Me.chkall.TabIndex = 775
        Me.chkall.Text = "all"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import"})
        Me.ComboBox2.Location = New System.Drawing.Point(70, 28)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 774
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 773
        Me.Label5.Text = "Dept :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(223, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 772
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(3, 129)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(946, 1)
        Me.GroupBox1.TabIndex = 771
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(70, 3)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox1.TabIndex = 770
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(602, 40)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 769
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(521, 40)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 768
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(440, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 767
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 766
        Me.Label1.Text = "Location :"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.job, Me.loaihinh, Me.POL, Me.tuyen, Me.client, Me.agent, Me.mbl, Me.hbl, Me.cont20, Me.cont40, Me.Kgs, Me.CBM, Me.tong, Me.sales, Me.remarks})
        Me.DataGridView1.Location = New System.Drawing.Point(11, 144)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Size = New System.Drawing.Size(514, 331)
        Me.DataGridView1.TabIndex = 765
        '
        'chkallTuyen
        '
        Me.chkallTuyen.AutoSize = True
        Me.chkallTuyen.Location = New System.Drawing.Point(331, 53)
        Me.chkallTuyen.Name = "chkallTuyen"
        Me.chkallTuyen.Size = New System.Drawing.Size(36, 17)
        Me.chkallTuyen.TabIndex = 791
        Me.chkallTuyen.Text = "all"
        Me.chkallTuyen.UseVisualStyleBackColor = True
        '
        'cbotuyen
        '
        Me.cbotuyen.FormattingEnabled = True
        Me.cbotuyen.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cbotuyen.Location = New System.Drawing.Point(229, 54)
        Me.cbotuyen.Name = "cbotuyen"
        Me.cbotuyen.Size = New System.Drawing.Size(96, 21)
        Me.cbotuyen.TabIndex = 790
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(184, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 789
        Me.Label6.Text = "(POD) :"
        '
        'ChartControl1
        '
        Me.ChartControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChartControl1.CrosshairOptions.ArgumentLineColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ChartControl1.CrosshairOptions.ValueLineColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.ChartControl1.DataAdapter = Me.SalesreportchartshowTableAdapter
        Me.ChartControl1.DataSource = Me.FDIDataSet.salesreportchartshow
        XyDiagram1.AxisX.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        XyDiagram1.AxisX.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisX.Range.SideMarginsEnabled = True
        XyDiagram1.AxisX.VisibleInPanesSerializable = "-1"
        XyDiagram1.AxisY.NumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        XyDiagram1.AxisY.Range.ScrollingRange.SideMarginsEnabled = True
        XyDiagram1.AxisY.Range.SideMarginsEnabled = True
        XyDiagram1.AxisY.VisibleInPanesSerializable = "-1"
        Me.ChartControl1.Diagram = XyDiagram1
        Me.ChartControl1.Location = New System.Drawing.Point(531, 144)
        Me.ChartControl1.Name = "ChartControl1"
        Series1.ArgumentDataMember = "sanpham"
        Series1.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        SideBySideBarSeriesLabel1.LineVisible = True
        PointOptions1.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        PointOptions1.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        SideBySideBarSeriesLabel1.PointOptions = PointOptions1
        Series1.Label = SideBySideBarSeriesLabel1
        Series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.[True]
        Series1.Name = "Total"
        Series1.ValueDataMembersSerializable = "soluong"
        Me.ChartControl1.SeriesSerializable = New DevExpress.XtraCharts.Series() {Series1}
        Me.ChartControl1.SeriesTemplate.ArgumentDataMember = "sanpham"
        Me.ChartControl1.SeriesTemplate.ArgumentScaleType = DevExpress.XtraCharts.ScaleType.Qualitative
        SideBySideBarSeriesLabel2.LineVisible = True
        PointOptions2.ArgumentNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        PointOptions2.ValueNumericOptions.Format = DevExpress.XtraCharts.NumericFormat.General
        SideBySideBarSeriesLabel2.PointOptions = PointOptions2
        Me.ChartControl1.SeriesTemplate.Label = SideBySideBarSeriesLabel2
        Me.ChartControl1.SeriesTemplate.ValueDataMembersSerializable = "soluong"
        Me.ChartControl1.Size = New System.Drawing.Size(408, 331)
        Me.ChartControl1.TabIndex = 792
        ChartTitle1.Text = "Đồ thị sản lượng"
        Me.ChartControl1.Titles.AddRange(New DevExpress.XtraCharts.ChartTitle() {ChartTitle1})
        '
        'SalesreportchartshowTableAdapter
        '
        Me.SalesreportchartshowTableAdapter.ClearBeforeFill = True
        '
        'FDIDataSet
        '
        Me.FDIDataSet.DataSetName = "FDIDataSet"
        Me.FDIDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SalesreportchartshowBindingSource
        '
        Me.SalesreportchartshowBindingSource.DataMember = "salesreportchartshow"
        Me.SalesreportchartshowBindingSource.DataSource = Me.FDIDataSet
        '
        'chkteu
        '
        Me.chkteu.AutoSize = True
        Me.chkteu.Checked = True
        Me.chkteu.Location = New System.Drawing.Point(437, 68)
        Me.chkteu.Name = "chkteu"
        Me.chkteu.Size = New System.Drawing.Size(44, 17)
        Me.chkteu.TabIndex = 793
        Me.chkteu.TabStop = True
        Me.chkteu.Text = "Teu"
        Me.chkteu.UseVisualStyleBackColor = True
        '
        'chkcbm
        '
        Me.chkcbm.AutoSize = True
        Me.chkcbm.Location = New System.Drawing.Point(480, 69)
        Me.chkcbm.Name = "chkcbm"
        Me.chkcbm.Size = New System.Drawing.Size(48, 17)
        Me.chkcbm.TabIndex = 794
        Me.chkcbm.Text = "CBM"
        Me.chkcbm.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.chlallsoccoc)
        Me.GroupBox2.Controls.Add(Me.CHKCOC)
        Me.GroupBox2.Controls.Add(Me.CHKSOC)
        Me.GroupBox2.Location = New System.Drawing.Point(545, 69)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 43)
        Me.GroupBox2.TabIndex = 860
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
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(292, 103)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(45, 23)
        Me.Button8.TabIndex = 864
        Me.Button8.Text = "...>"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(262, 78)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(45, 23)
        Me.Button4.TabIndex = 863
        Me.Button4.Text = ">"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtfindcus
        '
        Me.txtfindcus.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtfindcus.ForeColor = System.Drawing.Color.Blue
        Me.txtfindcus.Location = New System.Drawing.Point(70, 78)
        Me.txtfindcus.Name = "txtfindcus"
        Me.txtfindcus.Size = New System.Drawing.Size(186, 22)
        Me.txtfindcus.TabIndex = 862
        '
        'cboCusNhap
        '
        Me.cboCusNhap.DropDownWidth = 500
        Me.cboCusNhap.FormattingEnabled = True
        Me.cboCusNhap.Location = New System.Drawing.Point(70, 103)
        Me.cboCusNhap.Name = "cboCusNhap"
        Me.cboCusNhap.Size = New System.Drawing.Size(216, 21)
        Me.cboCusNhap.TabIndex = 861
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 13)
        Me.Label8.TabIndex = 865
        Me.Label8.Text = "Customer :"
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.cboPOL.Location = New System.Drawing.Point(70, 52)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(96, 21)
        Me.cboPOL.TabIndex = 867
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 866
        Me.Label9.Text = "(POL) :"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 49
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Job./Ref."
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 77
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Type (Loại hình)"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 99
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "POL"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 53
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "POD"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 55
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "Client"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 58
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "Agent"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 60
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.HeaderText = "MBL"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 54
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.HeaderText = "HBL"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 53
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 56
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Sales/Care"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 85
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 74
        '
        'cboFLC
        '
        Me.cboFLC.FormattingEnabled = True
        Me.cboFLC.Items.AddRange(New Object() {"F", "L", "C"})
        Me.cboFLC.Location = New System.Drawing.Point(232, 3)
        Me.cboFLC.Name = "cboFLC"
        Me.cboFLC.Size = New System.Drawing.Size(36, 21)
        Me.cboFLC.TabIndex = 868
        Me.cboFLC.Text = "F"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(270, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 13)
        Me.Label10.TabIndex = 869
        Me.Label10.Text = "(COC,Im,Ex)"
        Me.Label10.Visible = False
        '
        'No
        '
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        Me.No.Width = 49
        '
        'job
        '
        Me.job.HeaderText = "Job./Ref."
        Me.job.Name = "job"
        Me.job.Width = 77
        '
        'loaihinh
        '
        Me.loaihinh.HeaderText = "Type (Loại hình)"
        Me.loaihinh.Name = "loaihinh"
        Me.loaihinh.Width = 99
        '
        'POL
        '
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.Width = 53
        '
        'tuyen
        '
        Me.tuyen.HeaderText = "POD"
        Me.tuyen.Name = "tuyen"
        Me.tuyen.Width = 55
        '
        'client
        '
        Me.client.HeaderText = "Client"
        Me.client.Name = "client"
        Me.client.Width = 58
        '
        'agent
        '
        Me.agent.HeaderText = "Agent"
        Me.agent.Name = "agent"
        Me.agent.Width = 60
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
        'cont20
        '
        Me.cont20.HeaderText = "20"
        Me.cont20.Name = "cont20"
        Me.cont20.Width = 44
        '
        'cont40
        '
        Me.cont40.HeaderText = "40"
        Me.cont40.Name = "cont40"
        Me.cont40.Width = 44
        '
        'Kgs
        '
        Me.Kgs.HeaderText = "Kgs"
        Me.Kgs.Name = "Kgs"
        Me.Kgs.Width = 50
        '
        'CBM
        '
        Me.CBM.HeaderText = "CBM"
        Me.CBM.Name = "CBM"
        Me.CBM.Width = 55
        '
        'tong
        '
        Me.tong.HeaderText = "Total (Teu/CBM)"
        Me.tong.Name = "tong"
        Me.tong.Width = 103
        '
        'sales
        '
        Me.sales.HeaderText = "Sales/Care"
        Me.sales.Name = "sales"
        Me.sales.Width = 85
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 74
        '
        'frmBaocaosanluongtheotuyen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 487)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboFLC)
        Me.Controls.Add(Me.cboPOL)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtfindcus)
        Me.Controls.Add(Me.cboCusNhap)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkcbm)
        Me.Controls.Add(Me.chkteu)
        Me.Controls.Add(Me.ChartControl1)
        Me.Controls.Add(Me.chkallTuyen)
        Me.Controls.Add(Me.cbotuyen)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Y2)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.Y1)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.D1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbonhom)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkVND)
        Me.Controls.Add(Me.Label169)
        Me.Controls.Add(Me.txtsumSelect)
        Me.Controls.Add(Me.chkall)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmBaocaosanluongtheotuyen"
        Me.Text = "Báo cáo sản lượng theo tuyến"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(XyDiagram1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Series1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(SideBySideBarSeriesLabel2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ChartControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FDIDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesreportchartshowBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbonhom As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkVND As System.Windows.Forms.CheckBox
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents txtsumSelect As System.Windows.Forms.TextBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkallTuyen As System.Windows.Forms.CheckBox
    Friend WithEvents cbotuyen As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ChartControl1 As DevExpress.XtraCharts.ChartControl
    Friend WithEvents SalesreportchartshowTableAdapter As TSA.FDIDataSetTableAdapters.salesreportchartshowTableAdapter
    Friend WithEvents FDIDataSet As TSA.FDIDataSet
    Friend WithEvents SalesreportchartshowBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents chkteu As System.Windows.Forms.RadioButton
    Friend WithEvents chkcbm As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chlallsoccoc As System.Windows.Forms.RadioButton
    Friend WithEvents CHKCOC As System.Windows.Forms.RadioButton
    Friend WithEvents CHKSOC As System.Windows.Forms.RadioButton
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtfindcus As System.Windows.Forms.TextBox
    Friend WithEvents cboCusNhap As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboFLC As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents job As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents loaihinh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tuyen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents client As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents agent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cont20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cont40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Kgs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CBM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tong As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
