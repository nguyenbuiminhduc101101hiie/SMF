<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSOCReport
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSOCReport))
        Me.Label169 = New System.Windows.Forms.Label
        Me.txtsumSelect = New System.Windows.Forms.TextBox
        Me.chkall = New System.Windows.Forms.CheckBox
        Me.ComboBox2 = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SHIPMENT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemTICOETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemTICOpickup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemTICOamount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.demAgentETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.demagentPickup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.demAgentAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.demprofit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.detTICOReturn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.detTICOAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DetAgentReturn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.detAgentAmount = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.detprofit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.stoFeeProfit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.powerFeeCollect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.powerFeePayment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.profit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkVND = New System.Windows.Forms.CheckBox
        Me.txthbl = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.chkselect = New System.Windows.Forms.CheckBox
        Me.Y2 = New System.Windows.Forms.ComboBox
        Me.T2 = New System.Windows.Forms.ComboBox
        Me.N2 = New System.Windows.Forms.ComboBox
        Me.Y1 = New System.Windows.Forms.ComboBox
        Me.T1 = New System.Windows.Forms.ComboBox
        Me.D1 = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(512, 71)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(37, 13)
        Me.Label169.TabIndex = 644
        Me.Label169.Text = "Sum..."
        '
        'txtsumSelect
        '
        Me.txtsumSelect.BackColor = System.Drawing.Color.Khaki
        Me.txtsumSelect.Location = New System.Drawing.Point(551, 66)
        Me.txtsumSelect.Name = "txtsumSelect"
        Me.txtsumSelect.Size = New System.Drawing.Size(153, 20)
        Me.txtsumSelect.TabIndex = 643
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(240, 39)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(36, 17)
        Me.chkall.TabIndex = 642
        Me.chkall.Text = "all"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.ComboBox2.Location = New System.Drawing.Point(78, 37)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 641
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(31, 41)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 640
        Me.Label5.Text = "Dept :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 61)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 638
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(16, 104)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(945, 1)
        Me.GroupBox1.TabIndex = 637
        Me.GroupBox1.TabStop = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.ComboBox1.Location = New System.Drawing.Point(78, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox1.TabIndex = 636
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(713, 38)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 635
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(632, 38)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 634
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(551, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 633
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 628
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.SHIPMENT, Me.ContainerNo, Me.DemTICOETA, Me.DemTICOpickup, Me.DemTICOamount, Me.demAgentETA, Me.demagentPickup, Me.demAgentAmount, Me.demprofit, Me.detTICOReturn, Me.detTICOAmount, Me.DetAgentReturn, Me.detAgentAmount, Me.detprofit, Me.stoFeeProfit, Me.powerFeeCollect, Me.powerFeePayment, Me.profit, Me.total})
        Me.DataGridView1.Location = New System.Drawing.Point(16, 120)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.PaleTurquoise
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridView1.Size = New System.Drawing.Size(945, 341)
        Me.DataGridView1.TabIndex = 627
        '
        'No
        '
        Me.No.HeaderText = "NO."
        Me.No.Name = "No"
        Me.No.Width = 51
        '
        'SHIPMENT
        '
        Me.SHIPMENT.HeaderText = "Shipment"
        Me.SHIPMENT.Name = "SHIPMENT"
        Me.SHIPMENT.Width = 76
        '
        'ContainerNo
        '
        Me.ContainerNo.HeaderText = "Container No."
        Me.ContainerNo.Name = "ContainerNo"
        Me.ContainerNo.Width = 89
        '
        'DemTICOETA
        '
        Me.DemTICOETA.HeaderText = "Dem.TICO.ETA"
        Me.DemTICOETA.Name = "DemTICOETA"
        Me.DemTICOETA.Width = 106
        '
        'DemTICOpickup
        '
        Me.DemTICOpickup.HeaderText = "Dem.TICO.Pick up"
        Me.DemTICOpickup.Name = "DemTICOpickup"
        Me.DemTICOpickup.Width = 111
        '
        'DemTICOamount
        '
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.DemTICOamount.DefaultCellStyle = DataGridViewCellStyle1
        Me.DemTICOamount.HeaderText = "Dem.TICO.Amount"
        Me.DemTICOamount.Name = "DemTICOamount"
        Me.DemTICOamount.Width = 121
        '
        'demAgentETA
        '
        Me.demAgentETA.HeaderText = "Dem.Agent.ETA"
        Me.demAgentETA.Name = "demAgentETA"
        Me.demAgentETA.Width = 109
        '
        'demagentPickup
        '
        Me.demagentPickup.HeaderText = "Dem.Agent.Pickup"
        Me.demagentPickup.Name = "demagentPickup"
        Me.demagentPickup.Width = 121
        '
        'demAgentAmount
        '
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.demAgentAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.demAgentAmount.HeaderText = "Dem.Agent.Amount"
        Me.demAgentAmount.Name = "demAgentAmount"
        Me.demAgentAmount.Width = 124
        '
        'demprofit
        '
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.demprofit.DefaultCellStyle = DataGridViewCellStyle3
        Me.demprofit.HeaderText = "Dem.Profit"
        Me.demprofit.Name = "demprofit"
        Me.demprofit.Width = 81
        '
        'detTICOReturn
        '
        Me.detTICOReturn.HeaderText = "Det.TICO.Return"
        Me.detTICOReturn.Name = "detTICOReturn"
        Me.detTICOReturn.Width = 112
        '
        'detTICOAmount
        '
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.detTICOAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.detTICOAmount.HeaderText = "Det.TICO.Amount"
        Me.detTICOAmount.Name = "detTICOAmount"
        Me.detTICOAmount.Width = 116
        '
        'DetAgentReturn
        '
        Me.DetAgentReturn.HeaderText = "Det.Agent.Return"
        Me.DetAgentReturn.Name = "DetAgentReturn"
        Me.DetAgentReturn.Width = 115
        '
        'detAgentAmount
        '
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.detAgentAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.detAgentAmount.HeaderText = "Det.Agent.Amount"
        Me.detAgentAmount.Name = "detAgentAmount"
        Me.detAgentAmount.Width = 119
        '
        'detprofit
        '
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.detprofit.DefaultCellStyle = DataGridViewCellStyle6
        Me.detprofit.HeaderText = "Det.Profit"
        Me.detprofit.Name = "detprofit"
        Me.detprofit.Width = 76
        '
        'stoFeeProfit
        '
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.stoFeeProfit.DefaultCellStyle = DataGridViewCellStyle7
        Me.stoFeeProfit.HeaderText = "STO.Fee.Profit"
        Me.stoFeeProfit.Name = "stoFeeProfit"
        Me.stoFeeProfit.Width = 102
        '
        'powerFeeCollect
        '
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.powerFeeCollect.DefaultCellStyle = DataGridViewCellStyle8
        Me.powerFeeCollect.HeaderText = "Power.Fee.Collect"
        Me.powerFeeCollect.Name = "powerFeeCollect"
        Me.powerFeeCollect.Width = 118
        '
        'powerFeePayment
        '
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.powerFeePayment.DefaultCellStyle = DataGridViewCellStyle9
        Me.powerFeePayment.HeaderText = "Power.Fee.Payment"
        Me.powerFeePayment.Name = "powerFeePayment"
        Me.powerFeePayment.Width = 127
        '
        'profit
        '
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.profit.DefaultCellStyle = DataGridViewCellStyle10
        Me.profit.HeaderText = "Profit"
        Me.profit.Name = "profit"
        Me.profit.Width = 56
        '
        'total
        '
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.total.DefaultCellStyle = DataGridViewCellStyle11
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.Width = 56
        '
        'chkVND
        '
        Me.chkVND.AutoSize = True
        Me.chkVND.Location = New System.Drawing.Point(497, 41)
        Me.chkVND.Name = "chkVND"
        Me.chkVND.Size = New System.Drawing.Size(49, 17)
        Me.chkVND.TabIndex = 646
        Me.chkVND.Text = "VND"
        Me.chkVND.UseVisualStyleBackColor = True
        '
        'txthbl
        '
        Me.txthbl.Location = New System.Drawing.Point(78, 61)
        Me.txthbl.Name = "txthbl"
        Me.txthbl.Size = New System.Drawing.Size(153, 20)
        Me.txthbl.TabIndex = 647
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(33, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 648
        Me.Label6.Text = "HBL :"
        '
        'chkselect
        '
        Me.chkselect.AutoSize = True
        Me.chkselect.Location = New System.Drawing.Point(240, 63)
        Me.chkselect.Name = "chkselect"
        Me.chkselect.Size = New System.Drawing.Size(56, 17)
        Me.chkselect.TabIndex = 649
        Me.chkselect.Text = "Select"
        Me.chkselect.UseVisualStyleBackColor = True
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(739, 11)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 704
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(689, 11)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 703
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(652, 11)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 702
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(547, 11)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 701
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(497, 11)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 700
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(460, 11)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 699
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(620, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 698
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(360, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 697
        Me.Label2.Text = "From (Date report):"
        '
        'frmSOCReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 473)
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
        Me.Name = "frmSOCReport"
        Me.Text = "SOC Report"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents chkVND As System.Windows.Forms.CheckBox
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SHIPMENT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemTICOETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemTICOpickup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemTICOamount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents demAgentETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents demagentPickup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents demAgentAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents demprofit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detTICOReturn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detTICOAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetAgentReturn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detAgentAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents detprofit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stoFeeProfit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents powerFeeCollect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents powerFeePayment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents profit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txthbl As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkselect As System.Windows.Forms.CheckBox
    Friend WithEvents Y2 As System.Windows.Forms.ComboBox
    Friend WithEvents T2 As System.Windows.Forms.ComboBox
    Friend WithEvents N2 As System.Windows.Forms.ComboBox
    Friend WithEvents Y1 As System.Windows.Forms.ComboBox
    Friend WithEvents T1 As System.Windows.Forms.ComboBox
    Friend WithEvents D1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
