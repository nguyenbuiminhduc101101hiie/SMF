<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListContainerArrival
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListContainerArrival))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.txthbl = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtBill = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.lblcontExport = New System.Windows.Forms.Label()
        Me.inboundContainersID_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inboundid_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.containerno_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.containertype_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MBL_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.hbl_ = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RefExport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayIFD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayDCO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayEMM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayDSO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayOFO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayOEO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ngayBFF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.billexport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VesselExport = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bairong = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Button8)
        Me.GroupBox1.Controls.Add(Me.txthbl)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Button7)
        Me.GroupBox1.Controls.Add(Me.Button5)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.txtBill)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(806, 67)
        Me.GroupBox1.TabIndex = 511
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(144, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 23)
        Me.Button1.TabIndex = 510
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(555, 28)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(55, 23)
        Me.Button8.TabIndex = 509
        Me.Button8.Text = "Exit"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'txthbl
        '
        Me.txthbl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txthbl.Location = New System.Drawing.Point(213, 31)
        Me.txthbl.Name = "txthbl"
        Me.txthbl.Size = New System.Drawing.Size(135, 20)
        Me.txthbl.TabIndex = 499
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(28, 13)
        Me.Label5.TabIndex = 498
        Me.Label5.Text = "HBL"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(415, 28)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(73, 23)
        Me.Button7.TabIndex = 496
        Me.Button7.Text = "Search (All)"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(494, 28)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(55, 23)
        Me.Button5.TabIndex = 495
        Me.Button5.Text = "Export"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(354, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 481
        Me.Button2.Text = "Search"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtBill
        '
        Me.txtBill.Location = New System.Drawing.Point(9, 31)
        Me.txtBill.Name = "txtBill"
        Me.txtBill.Size = New System.Drawing.Size(129, 20)
        Me.txtBill.TabIndex = 485
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 488
        Me.Label4.Text = "MBL"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.inboundContainersID_, Me.inboundid_, Me.containerno_, Me.containertype_, Me.MBL_, Me.hbl_, Me.RefExport, Me.ngayIFD, Me.ngayDCO, Me.ngayEMM, Me.ngayDSO, Me.ngayOFO, Me.ngayOEO, Me.ngayBFF, Me.billexport, Me.VesselExport, Me.bairong})
        Me.DataGridView2.Location = New System.Drawing.Point(12, 99)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(973, 388)
        Me.DataGridView2.TabIndex = 510
        '
        'lblcontExport
        '
        Me.lblcontExport.AutoSize = True
        Me.lblcontExport.Location = New System.Drawing.Point(7, 83)
        Me.lblcontExport.Name = "lblcontExport"
        Me.lblcontExport.Size = New System.Drawing.Size(43, 13)
        Me.lblcontExport.TabIndex = 509
        Me.lblcontExport.Text = "............"
        '
        'inboundContainersID_
        '
        Me.inboundContainersID_.DataPropertyName = "inboundContainersID"
        Me.inboundContainersID_.HeaderText = "inboundContainersID"
        Me.inboundContainersID_.Name = "inboundContainersID_"
        Me.inboundContainersID_.Visible = False
        Me.inboundContainersID_.Width = 131
        '
        'inboundid_
        '
        Me.inboundid_.DataPropertyName = "inboundid"
        Me.inboundid_.HeaderText = "inboundid"
        Me.inboundid_.Name = "inboundid_"
        Me.inboundid_.Visible = False
        Me.inboundid_.Width = 78
        '
        'containerno_
        '
        Me.containerno_.DataPropertyName = "containerno"
        Me.containerno_.HeaderText = "Container No."
        Me.containerno_.Name = "containerno_"
        Me.containerno_.Width = 97
        '
        'containertype_
        '
        Me.containertype_.DataPropertyName = "containertype"
        Me.containertype_.HeaderText = "Type"
        Me.containertype_.Name = "containertype_"
        Me.containertype_.Width = 56
        '
        'MBL_
        '
        Me.MBL_.DataPropertyName = "mbl"
        Me.MBL_.HeaderText = "MBL"
        Me.MBL_.Name = "MBL_"
        Me.MBL_.Width = 54
        '
        'hbl_
        '
        Me.hbl_.DataPropertyName = "hbl"
        Me.hbl_.HeaderText = "HBL"
        Me.hbl_.Name = "hbl_"
        Me.hbl_.Width = 53
        '
        'RefExport
        '
        Me.RefExport.DataPropertyName = "RefExport"
        Me.RefExport.HeaderText = "Ref. Export"
        Me.RefExport.Name = "RefExport"
        Me.RefExport.Width = 85
        '
        'ngayIFD
        '
        Me.ngayIFD.DataPropertyName = "ngayIFD"
        Me.ngayIFD.HeaderText = "IFD (ngày)"
        Me.ngayIFD.Name = "ngayIFD"
        Me.ngayIFD.Width = 81
        '
        'ngayDCO
        '
        Me.ngayDCO.DataPropertyName = "ngayDCO"
        Me.ngayDCO.HeaderText = "DCO (ngày)"
        Me.ngayDCO.Name = "ngayDCO"
        Me.ngayDCO.Width = 87
        '
        'ngayEMM
        '
        Me.ngayEMM.DataPropertyName = "ngayEMM"
        Me.ngayEMM.HeaderText = "EMM (ngày)"
        Me.ngayEMM.Name = "ngayEMM"
        Me.ngayEMM.Width = 89
        '
        'ngayDSO
        '
        Me.ngayDSO.DataPropertyName = "ngayDSO"
        Me.ngayDSO.HeaderText = "DSO (ngày)"
        Me.ngayDSO.Name = "ngayDSO"
        Me.ngayDSO.Width = 87
        '
        'ngayOFO
        '
        Me.ngayOFO.DataPropertyName = "ngayOFO"
        Me.ngayOFO.HeaderText = "OFO (ngày)"
        Me.ngayOFO.Name = "ngayOFO"
        Me.ngayOFO.Width = 86
        '
        'ngayOEO
        '
        Me.ngayOEO.DataPropertyName = "ngayOEO"
        Me.ngayOEO.HeaderText = "OEO (ngày)"
        Me.ngayOEO.Name = "ngayOEO"
        Me.ngayOEO.Width = 87
        '
        'ngayBFF
        '
        Me.ngayBFF.DataPropertyName = "ngayBFF"
        Me.ngayBFF.HeaderText = "BFF (ngày)"
        Me.ngayBFF.Name = "ngayBFF"
        Me.ngayBFF.Width = 83
        '
        'billexport
        '
        Me.billexport.DataPropertyName = "billexport"
        Me.billexport.HeaderText = "Bill Export"
        Me.billexport.Name = "billexport"
        Me.billexport.Width = 78
        '
        'VesselExport
        '
        Me.VesselExport.DataPropertyName = "VesselExport"
        Me.VesselExport.HeaderText = "Vessel Export"
        Me.VesselExport.Name = "VesselExport"
        Me.VesselExport.Width = 96
        '
        'bairong
        '
        Me.bairong.DataPropertyName = "bairong"
        Me.bairong.HeaderText = "Bãi rỗng"
        Me.bairong.Name = "bairong"
        Me.bairong.Width = 71
        '
        'frmListContainerArrival
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(997, 499)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.lblcontExport)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListContainerArrival"
        Me.Text = "List Container (Arrival)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents txthbl As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtBill As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents lblcontExport As System.Windows.Forms.Label
    Friend WithEvents inboundContainersID_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents inboundid_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents containerno_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents containertype_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBL_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hbl_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefExport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayIFD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayDCO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayEMM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayDSO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayOFO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayOEO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ngayBFF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents billexport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselExport As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bairong As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
