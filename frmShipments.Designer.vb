<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShipments
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShipments))
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpShowDocument1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpShowDocument = New System.Windows.Forms.DateTimePicker()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DetailsInDocToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Department_Shipment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lot = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.debitIssued = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.invoiceIssued = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.paid = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ref = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.quotation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gFLC_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gSC_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hbl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POL_shipment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POD_shipment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Sales = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.volume = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Datereport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(54, 37)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(43, 23)
        Me.Button13.TabIndex = 13
        Me.Button13.Text = "Excel..."
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(138, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "To :"
        '
        'dtpShowDocument1
        '
        Me.dtpShowDocument1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShowDocument1.Location = New System.Drawing.Point(168, 8)
        Me.dtpShowDocument1.Name = "dtpShowDocument1"
        Me.dtpShowDocument1.Size = New System.Drawing.Size(84, 20)
        Me.dtpShowDocument1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "From :"
        '
        'dtpShowDocument
        '
        Me.dtpShowDocument.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpShowDocument.Location = New System.Drawing.Point(49, 8)
        Me.dtpShowDocument.Name = "dtpShowDocument"
        Me.dtpShowDocument.Size = New System.Drawing.Size(84, 20)
        Me.dtpShowDocument.TabIndex = 7
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(5, 37)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(43, 23)
        Me.Button8.TabIndex = 5
        Me.Button8.Text = "Load"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Department_Shipment, Me.Status, Me.lot, Me.debitIssued, Me.invoiceIssued, Me.paid, Me.ref, Me.quotation, Me.mbl, Me.gFLC_, Me.gSC_, Me.hbl, Me.POL_shipment, Me.POD_shipment, Me.ETA, Me.ETD, Me.Sales, Me.volume, Me.OPS, Me.Datereport, Me.remarks, Me.Userupdate, Me.dateupdate})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(12, 66)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(922, 346)
        Me.DataGridView1.TabIndex = 1
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetailsInDocToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(150, 26)
        '
        'DetailsInDocToolStripMenuItem
        '
        Me.DetailsInDocToolStripMenuItem.Name = "DetailsInDocToolStripMenuItem"
        Me.DetailsInDocToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.DetailsInDocToolStripMenuItem.Text = "Details in Doc."
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(474, 9)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(37, 17)
        Me.chkall.TabIndex = 682
        Me.chkall.Text = "All"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"", "Agency-Import", "Agency-Export", "Logistics-Customs", "ACS-Air-Import", "ACS-Air-Export"})
        Me.ComboBox2.Location = New System.Drawing.Point(312, 7)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(153, 21)
        Me.ComboBox2.TabIndex = 681
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(273, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 683
        Me.Label3.Text = "Dept."
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "Department"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 87
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.HeaderText = "Status"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Width = 62
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ref."
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 52
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Master Bill"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "House Bill"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Width = 79
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = "POL"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 53
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.HeaderText = "POD"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Width = 55
        '
        'DataGridViewTextBoxColumn8
        '
        DataGridViewCellStyle4.Format = "d"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTextBoxColumn8.HeaderText = "ETA"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 53
        '
        'DataGridViewTextBoxColumn9
        '
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewTextBoxColumn9.HeaderText = "ETD"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Width = 54
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = "Sales"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 58
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "Volume"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 67
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.HeaderText = "OPS"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Width = 54
        '
        'DataGridViewTextBoxColumn13
        '
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewTextBoxColumn13.HeaderText = "Date (Report)"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 96
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.HeaderText = "Remarks"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Width = 74
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.HeaderText = "User Update"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 92
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.HeaderText = "Date Update"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 93
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(103, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 23)
        Me.Button1.TabIndex = 686
        Me.Button1.Text = "Details in Doc."
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Department_Shipment
        '
        Me.Department_Shipment.HeaderText = "Department"
        Me.Department_Shipment.Name = "Department_Shipment"
        Me.Department_Shipment.Width = 87
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        Me.Status.Width = 62
        '
        'lot
        '
        Me.lot.HeaderText = "Lot. No."
        Me.lot.Name = "lot"
        Me.lot.Width = 70
        '
        'debitIssued
        '
        Me.debitIssued.HeaderText = "Debit Issued"
        Me.debitIssued.Name = "debitIssued"
        Me.debitIssued.Width = 72
        '
        'invoiceIssued
        '
        Me.invoiceIssued.HeaderText = "Invoice Issued"
        Me.invoiceIssued.Name = "invoiceIssued"
        Me.invoiceIssued.Width = 82
        '
        'paid
        '
        Me.paid.HeaderText = "Paid"
        Me.paid.Name = "paid"
        Me.paid.Width = 34
        '
        'ref
        '
        Me.ref.HeaderText = "Ref."
        Me.ref.Name = "ref"
        Me.ref.Width = 52
        '
        'quotation
        '
        Me.quotation.HeaderText = "Quotation"
        Me.quotation.Name = "quotation"
        Me.quotation.Width = 78
        '
        'mbl
        '
        Me.mbl.HeaderText = "Master Bill"
        Me.mbl.Name = "mbl"
        Me.mbl.Width = 80
        '
        'gFLC_
        '
        Me.gFLC_.HeaderText = "F/L/C"
        Me.gFLC_.Name = "gFLC_"
        Me.gFLC_.Width = 61
        '
        'gSC_
        '
        Me.gSC_.HeaderText = "SOC/COC"
        Me.gSC_.Name = "gSC_"
        Me.gSC_.Width = 81
        '
        'hbl
        '
        Me.hbl.HeaderText = "House Bill"
        Me.hbl.Name = "hbl"
        Me.hbl.Width = 79
        '
        'POL_shipment
        '
        Me.POL_shipment.HeaderText = "POL"
        Me.POL_shipment.Name = "POL_shipment"
        Me.POL_shipment.Width = 53
        '
        'POD_shipment
        '
        Me.POD_shipment.HeaderText = "POD"
        Me.POD_shipment.Name = "POD_shipment"
        Me.POD_shipment.Width = 55
        '
        'ETA
        '
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ETA.DefaultCellStyle = DataGridViewCellStyle1
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        Me.ETA.Width = 53
        '
        'ETD
        '
        DataGridViewCellStyle2.Format = "d"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.ETD.DefaultCellStyle = DataGridViewCellStyle2
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        Me.ETD.Width = 54
        '
        'Sales
        '
        Me.Sales.HeaderText = "Sales"
        Me.Sales.Name = "Sales"
        Me.Sales.Width = 58
        '
        'volume
        '
        Me.volume.HeaderText = "Volume"
        Me.volume.Name = "volume"
        Me.volume.Width = 67
        '
        'OPS
        '
        Me.OPS.HeaderText = "OPS"
        Me.OPS.Name = "OPS"
        Me.OPS.Width = 54
        '
        'Datereport
        '
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Datereport.DefaultCellStyle = DataGridViewCellStyle3
        Me.Datereport.HeaderText = "Date (Report)"
        Me.Datereport.Name = "Datereport"
        Me.Datereport.Width = 96
        '
        'remarks
        '
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.Width = 74
        '
        'Userupdate
        '
        Me.Userupdate.HeaderText = "User Update"
        Me.Userupdate.Name = "Userupdate"
        Me.Userupdate.Width = 92
        '
        'dateupdate
        '
        Me.dateupdate.HeaderText = "Date Update"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Width = 93
        '
        'frmShipments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(946, 438)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkall)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.dtpShowDocument1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.dtpShowDocument)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmShipments"
        Me.Text = "Shipments"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpShowDocument1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpShowDocument As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DetailsInDocToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Department_Shipment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents debitIssued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents invoiceIssued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents paid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents quotation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gFLC_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gSC_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hbl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL_shipment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD_shipment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Sales As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents volume As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Datereport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
