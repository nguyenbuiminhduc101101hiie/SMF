<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckDNTT
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckDNTT))
        Me.cbodebitcredit = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.chkallCus = New System.Windows.Forms.CheckBox()
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txthcn = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txttotalVND = New System.Windows.Forms.TextBox()
        Me.txttotalUSD = New System.Windows.Forms.TextBox()
        Me.chkDaCheckDNTT = New System.Windows.Forms.CheckBox()
        Me.dgddebitGrid = New System.Windows.Forms.DataGridView()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.txtsumSelect = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.cbocus = New System.Windows.Forms.ComboBox()
        Me.debitid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.paycheck_debit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.stt_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MBL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HBL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.company_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.currency_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.containertype_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quantity_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unitprice_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.price_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.priceVND = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.taxprice_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tigia_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.note_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Agent_debit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Os_debit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ngay_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayhoadon_debit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.approvedebit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Userupdatedebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdatedebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgddebitGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbodebitcredit
        '
        Me.cbodebitcredit.FormattingEnabled = True
        Me.cbodebitcredit.Items.AddRange(New Object() {"Credit"})
        Me.cbodebitcredit.Location = New System.Drawing.Point(64, 51)
        Me.cbodebitcredit.Name = "cbodebitcredit"
        Me.cbodebitcredit.Size = New System.Drawing.Size(67, 21)
        Me.cbodebitcredit.TabIndex = 750
        Me.cbodebitcredit.Text = "Credit"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 749
        Me.Label7.Text = "Db/Cr :"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(18, 127)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 748
        Me.Button4.Text = "Finish"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'chkallCus
        '
        Me.chkallCus.AutoSize = True
        Me.chkallCus.Location = New System.Drawing.Point(350, 24)
        Me.chkallCus.Name = "chkallCus"
        Me.chkallCus.Size = New System.Drawing.Size(36, 17)
        Me.chkallCus.TabIndex = 747
        Me.chkallCus.Text = "all"
        Me.chkallCus.UseVisualStyleBackColor = True
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(813, 18)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 746
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(763, 18)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 745
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(726, 18)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 744
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(621, 18)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 743
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(571, 18)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 742
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(534, 18)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 741
        Me.D1.Text = "01"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(391, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 740
        Me.Label6.Text = "(hạn mức) :"
        '
        'txthcn
        '
        Me.txthcn.BackColor = System.Drawing.Color.Khaki
        Me.txthcn.Location = New System.Drawing.Point(454, 53)
        Me.txthcn.Name = "txthcn"
        Me.txthcn.Size = New System.Drawing.Size(75, 20)
        Me.txthcn.TabIndex = 739
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(537, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 13)
        Me.Label4.TabIndex = 738
        Me.Label4.Text = "Total Amount (VND) :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(256, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 737
        Me.Label1.Text = "Total Amount (USD) :"
        '
        'txttotalVND
        '
        Me.txttotalVND.Location = New System.Drawing.Point(649, 127)
        Me.txttotalVND.Name = "txttotalVND"
        Me.txttotalVND.Size = New System.Drawing.Size(137, 20)
        Me.txttotalVND.TabIndex = 736
        '
        'txttotalUSD
        '
        Me.txttotalUSD.Location = New System.Drawing.Point(370, 127)
        Me.txttotalUSD.Name = "txttotalUSD"
        Me.txttotalUSD.Size = New System.Drawing.Size(137, 20)
        Me.txttotalUSD.TabIndex = 735
        '
        'chkDaCheckDNTT
        '
        Me.chkDaCheckDNTT.AutoSize = True
        Me.chkDaCheckDNTT.Location = New System.Drawing.Point(19, 86)
        Me.chkDaCheckDNTT.Name = "chkDaCheckDNTT"
        Me.chkDaCheckDNTT.Size = New System.Drawing.Size(106, 17)
        Me.chkDaCheckDNTT.TabIndex = 734
        Me.chkDaCheckDNTT.Text = "Đã check ĐNTT"
        Me.chkDaCheckDNTT.UseVisualStyleBackColor = True
        '
        'dgddebitGrid
        '
        Me.dgddebitGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgddebitGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgddebitGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgddebitGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgddebitGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.debitid, Me.paycheck_debit, Me.stt_debit, Me.ref, Me.MBL, Me.HBL, Me.company_debit, Me.Item_debit, Me.currency_debit, Me.containertype_debit, Me.quantity_debit, Me.unitprice_debit, Me.price_debit, Me.priceVND, Me.taxprice_debit, Me.tigia_debit, Me.note_debit, Me.Agent_debit, Me.Os_debit, Me.ngay_debit, Me.ngayhoadon_debit, Me.approvedebit, Me.Userupdatedebit, Me.dateupdatedebit})
        Me.dgddebitGrid.Location = New System.Drawing.Point(18, 153)
        Me.dgddebitGrid.Name = "dgddebitGrid"
        Me.dgddebitGrid.RowTemplate.Height = 24
        Me.dgddebitGrid.Size = New System.Drawing.Size(980, 322)
        Me.dgddebitGrid.TabIndex = 733
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(350, 50)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(36, 17)
        Me.chkall.TabIndex = 732
        Me.chkall.Text = "all"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(532, 57)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 731
        Me.Label169.Text = "Sum..."
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(571, 54)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(72, 20)
        Me.txtsumSelect.TabIndex = 730
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Domestic-Rail", "Domestic-Truck", "Logistics-Customs", "Oversea-Sea-Import", "Oversea-Sea-Export", "ACS-Air-Import", "ACS-Air-Export", "ACS-Sea-Export"})
        Me.ComboBox2.Location = New System.Drawing.Point(194, 46)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 729
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(149, 50)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 728
        Me.Label5.Text = "Dept :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(19, 79)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1191, 1)
        Me.GroupBox1.TabIndex = 727
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(878, 49)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 726
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(797, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 725
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(716, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 724
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(694, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 723
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(434, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 722
        Me.Label2.Text = "From (Date report):"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(10, 21)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(70, 26)
        Me.Label75.TabIndex = 721
        Me.Label75.Text = "Search Cus./" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Tax code"
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(166, 20)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(22, 23)
        Me.Button23.TabIndex = 720
        Me.Button23.Text = ">"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Info
        Me.TextBox2.Location = New System.Drawing.Point(87, 21)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(75, 20)
        Me.TextBox2.TabIndex = 719
        '
        'cbocus
        '
        Me.cbocus.BackColor = System.Drawing.SystemColors.Info
        Me.cbocus.DropDownWidth = 500
        Me.cbocus.FormattingEnabled = True
        Me.cbocus.Location = New System.Drawing.Point(194, 21)
        Me.cbocus.Name = "cbocus"
        Me.cbocus.Size = New System.Drawing.Size(153, 21)
        Me.cbocus.TabIndex = 718
        '
        'debitid
        '
        Me.debitid.HeaderText = "debitID"
        Me.debitid.Name = "debitid"
        Me.debitid.Visible = False
        Me.debitid.Width = 66
        '
        'paycheck_debit
        '
        Me.paycheck_debit.DataPropertyName = "paycheck"
        Me.paycheck_debit.HeaderText = "Check ĐNTT"
        Me.paycheck_debit.Name = "paycheck_debit"
        Me.paycheck_debit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.paycheck_debit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.paycheck_debit.Width = 96
        '
        'stt_debit
        '
        Me.stt_debit.DataPropertyName = "stt"
        Me.stt_debit.HeaderText = "No."
        Me.stt_debit.Name = "stt_debit"
        Me.stt_debit.Width = 49
        '
        'ref
        '
        Me.ref.HeaderText = "Ref. No."
        Me.ref.Name = "ref"
        Me.ref.Width = 72
        '
        'MBL
        '
        Me.MBL.HeaderText = "MBL/MBLMAWB"
        Me.MBL.Name = "MBL"
        Me.MBL.Width = 115
        '
        'HBL
        '
        Me.HBL.HeaderText = "HBL/HBLHAWB"
        Me.HBL.Name = "HBL"
        Me.HBL.Width = 112
        '
        'company_debit
        '
        Me.company_debit.DataPropertyName = "company"
        Me.company_debit.HeaderText = "Company"
        Me.company_debit.Name = "company_debit"
        Me.company_debit.Width = 76
        '
        'Item_debit
        '
        Me.Item_debit.DataPropertyName = "Item"
        Me.Item_debit.HeaderText = "Item"
        Me.Item_debit.Name = "Item_debit"
        Me.Item_debit.Width = 52
        '
        'currency_debit
        '
        Me.currency_debit.DataPropertyName = "currency"
        Me.currency_debit.HeaderText = "Currency"
        Me.currency_debit.Name = "currency_debit"
        Me.currency_debit.Width = 74
        '
        'containertype_debit
        '
        Me.containertype_debit.DataPropertyName = "containertype"
        Me.containertype_debit.HeaderText = "Container Type"
        Me.containertype_debit.Name = "containertype_debit"
        Me.containertype_debit.Width = 96
        '
        'quantity_debit
        '
        Me.quantity_debit.DataPropertyName = "quantity"
        Me.quantity_debit.HeaderText = "Quantity"
        Me.quantity_debit.Name = "quantity_debit"
        Me.quantity_debit.Width = 71
        '
        'unitprice_debit
        '
        Me.unitprice_debit.DataPropertyName = "unitprice"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N4"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.unitprice_debit.DefaultCellStyle = DataGridViewCellStyle1
        Me.unitprice_debit.HeaderText = "Unit price (Inc. VAT)"
        Me.unitprice_debit.Name = "unitprice_debit"
        Me.unitprice_debit.Width = 96
        '
        'price_debit
        '
        Me.price_debit.DataPropertyName = "price"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N3"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.price_debit.DefaultCellStyle = DataGridViewCellStyle2
        Me.price_debit.HeaderText = "Total amount (Inc. VAT)"
        Me.price_debit.Name = "price_debit"
        Me.price_debit.Width = 111
        '
        'priceVND
        '
        Me.priceVND.DataPropertyName = "priceVND"
        Me.priceVND.HeaderText = "Total Amount (VND)"
        Me.priceVND.Name = "priceVND"
        Me.priceVND.Width = 116
        '
        'taxprice_debit
        '
        Me.taxprice_debit.DataPropertyName = "taxprice"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.taxprice_debit.DefaultCellStyle = DataGridViewCellStyle3
        Me.taxprice_debit.HeaderText = "Tax"
        Me.taxprice_debit.Name = "taxprice_debit"
        Me.taxprice_debit.Width = 50
        '
        'tigia_debit
        '
        Me.tigia_debit.DataPropertyName = "tigia"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.tigia_debit.DefaultCellStyle = DataGridViewCellStyle4
        Me.tigia_debit.HeaderText = "Ex."
        Me.tigia_debit.Name = "tigia_debit"
        Me.tigia_debit.Width = 47
        '
        'note_debit
        '
        Me.note_debit.DataPropertyName = "note"
        Me.note_debit.HeaderText = "Note"
        Me.note_debit.Name = "note_debit"
        Me.note_debit.Width = 55
        '
        'Agent_debit
        '
        Me.Agent_debit.DataPropertyName = "daily"
        Me.Agent_debit.HeaderText = "Agent"
        Me.Agent_debit.Name = "Agent_debit"
        Me.Agent_debit.Width = 41
        '
        'Os_debit
        '
        Me.Os_debit.DataPropertyName = "os"
        Me.Os_debit.HeaderText = "On Behaft"
        Me.Os_debit.Name = "Os_debit"
        Me.Os_debit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Os_debit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Os_debit.Width = 74
        '
        'ngay_debit
        '
        Me.ngay_debit.DataPropertyName = "ngay"
        Me.ngay_debit.HeaderText = "Date"
        Me.ngay_debit.Name = "ngay_debit"
        Me.ngay_debit.Width = 55
        '
        'ngayhoadon_debit
        '
        Me.ngayhoadon_debit.DataPropertyName = "ngayhoadon"
        Me.ngayhoadon_debit.HeaderText = "Invoice"
        Me.ngayhoadon_debit.Name = "ngayhoadon_debit"
        Me.ngayhoadon_debit.Width = 67
        '
        'approvedebit
        '
        Me.approvedebit.DataPropertyName = "approve"
        Me.approvedebit.HeaderText = "Approve"
        Me.approvedebit.Name = "approvedebit"
        Me.approvedebit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.approvedebit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.approvedebit.Width = 72
        '
        'Userupdatedebit
        '
        Me.Userupdatedebit.DataPropertyName = "userupdate"
        Me.Userupdatedebit.HeaderText = "User update"
        Me.Userupdatedebit.Name = "Userupdatedebit"
        Me.Userupdatedebit.Width = 83
        '
        'dateupdatedebit
        '
        Me.dateupdatedebit.DataPropertyName = "dateupdate"
        Me.dateupdatedebit.HeaderText = "Date update"
        Me.dateupdatedebit.Name = "dateupdatedebit"
        Me.dateupdatedebit.Width = 84
        '
        'frmCheckDNTT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 507)
        Me.Controls.Add(Me.cbodebitcredit)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.chkallCus)
        Me.Controls.Add(Me.Y2)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.Y1)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.D1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txthcn)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txttotalVND)
        Me.Controls.Add(Me.txttotalUSD)
        Me.Controls.Add(Me.chkDaCheckDNTT)
        Me.Controls.Add(Me.dgddebitGrid)
        Me.Controls.Add(Me.chkall)
        Me.Controls.Add(Me.Label169)
        Me.Controls.Add(Me.txtsumSelect)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label75)
        Me.Controls.Add(Me.Button23)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.cbocus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCheckDNTT"
        Me.Text = "Check DNTT"
        CType(Me.dgddebitGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbodebitcredit As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents chkallCus As System.Windows.Forms.CheckBox
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txthcn As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txttotalVND As System.Windows.Forms.TextBox
    Friend WithEvents txttotalUSD As System.Windows.Forms.TextBox
    Friend WithEvents chkDaCheckDNTT As System.Windows.Forms.CheckBox
    Friend WithEvents dgddebitGrid As System.Windows.Forms.DataGridView
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents txtsumSelect As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents cbocus As System.Windows.Forms.ComboBox
    Friend WithEvents debitid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents paycheck_debit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents stt_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents company_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents currency_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents containertype_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quantity_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents unitprice_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents priceVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents taxprice_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tigia_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents note_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Agent_debit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Os_debit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ngay_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayhoadon_debit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents approvedebit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Userupdatedebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdatedebit As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
