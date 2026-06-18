<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingOnline
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxtPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.tabData = New System.Windows.Forms.TabControl
        Me.tabBookingData = New System.Windows.Forms.TabPage
        Me.cmdexit = New System.Windows.Forms.Button
        Me.mclSelect = New System.Windows.Forms.MonthCalendar
        Me.dgdBookingOnline = New System.Windows.Forms.DataGridView
        Me.tabPrint = New System.Windows.Forms.TabPage
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.BookingOnlineID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingOnlineNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ATTN = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Goods = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnboardDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyAge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Temperature = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpencalEquipMent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1.SuspendLayout()
        Me.tabData.SuspendLayout()
        Me.tabBookingData.SuspendLayout()
        CType(Me.dgdBookingOnline, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPrint.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxtPrint})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(108, 26)
        '
        'cxtPrint
        '
        Me.cxtPrint.Name = "cxtPrint"
        Me.cxtPrint.Size = New System.Drawing.Size(107, 22)
        Me.cxtPrint.Text = "Print"
        '
        'tabData
        '
        Me.tabData.Controls.Add(Me.tabBookingData)
        Me.tabData.Controls.Add(Me.tabPrint)
        Me.tabData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabData.Location = New System.Drawing.Point(0, 0)
        Me.tabData.Name = "tabData"
        Me.tabData.SelectedIndex = 0
        Me.tabData.Size = New System.Drawing.Size(702, 385)
        Me.tabData.TabIndex = 1
        '
        'tabBookingData
        '
        Me.tabBookingData.Controls.Add(Me.cmdexit)
        Me.tabBookingData.Controls.Add(Me.mclSelect)
        Me.tabBookingData.Controls.Add(Me.dgdBookingOnline)
        Me.tabBookingData.Location = New System.Drawing.Point(4, 22)
        Me.tabBookingData.Name = "tabBookingData"
        Me.tabBookingData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabBookingData.Size = New System.Drawing.Size(694, 359)
        Me.tabBookingData.TabIndex = 0
        Me.tabBookingData.Text = "Booking Online Data"
        Me.tabBookingData.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmdexit.Location = New System.Drawing.Point(65, 312)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 23)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'mclSelect
        '
        Me.mclSelect.CalendarDimensions = New System.Drawing.Size(1, 2)
        Me.mclSelect.Dock = System.Windows.Forms.DockStyle.Left
        Me.mclSelect.Location = New System.Drawing.Point(3, 3)
        Me.mclSelect.Name = "mclSelect"
        Me.mclSelect.TabIndex = 3
        '
        'dgdBookingOnline
        '
        Me.dgdBookingOnline.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingOnline.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdBookingOnline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBookingOnline.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookingOnlineID, Me.Company, Me.BookingOnlineNo, Me.ATTN, Me.Address, Me.Tel, Me.Fax, Me.Email, Me.Goods, Me.POL, Me.POD, Me.OnboardDate, Me.Vessel, Me.VoyAge, Me.SoLuong20GP, Me.SoLuong40GP, Me.SoLuong20RF, Me.SoLuong40RF, Me.SoLuong40HC, Me.SoLuong45HC, Me.SoLuong40RH, Me.Vent, Me.Temperature, Me.SpencalEquipMent, Me.Remarks, Me.Continued, Me.UpdateTime})
        Me.dgdBookingOnline.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdBookingOnline.Dock = System.Windows.Forms.DockStyle.Right
        Me.dgdBookingOnline.Location = New System.Drawing.Point(214, 3)
        Me.dgdBookingOnline.MaximumSize = New System.Drawing.Size(790, 0)
        Me.dgdBookingOnline.Name = "dgdBookingOnline"
        Me.dgdBookingOnline.ReadOnly = True
        Me.dgdBookingOnline.Size = New System.Drawing.Size(477, 353)
        Me.dgdBookingOnline.TabIndex = 2
        '
        'tabPrint
        '
        Me.tabPrint.Controls.Add(Me.CrystalReportViewer1)
        Me.tabPrint.Location = New System.Drawing.Point(4, 22)
        Me.tabPrint.Name = "tabPrint"
        Me.tabPrint.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPrint.Size = New System.Drawing.Size(694, 359)
        Me.tabPrint.TabIndex = 1
        Me.tabPrint.Text = "Print"
        Me.tabPrint.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.DisplayToolbar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 3)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(688, 353)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'BookingOnlineID
        '
        Me.BookingOnlineID.DataPropertyName = "BookingOnlineID"
        Me.BookingOnlineID.HeaderText = "BookingOnlineID"
        Me.BookingOnlineID.Name = "BookingOnlineID"
        Me.BookingOnlineID.ReadOnly = True
        Me.BookingOnlineID.Visible = False
        '
        'Company
        '
        Me.Company.DataPropertyName = "Company"
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        '
        'BookingOnlineNo
        '
        Me.BookingOnlineNo.DataPropertyName = "Bookingonlineno"
        Me.BookingOnlineNo.HeaderText = "Booking online no."
        Me.BookingOnlineNo.Name = "BookingOnlineNo"
        Me.BookingOnlineNo.ReadOnly = True
        '
        'ATTN
        '
        Me.ATTN.DataPropertyName = "ATTN"
        Me.ATTN.HeaderText = "Full Name"
        Me.ATTN.Name = "ATTN"
        Me.ATTN.ReadOnly = True
        '
        'Address
        '
        Me.Address.DataPropertyName = "Address"
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        '
        'Tel
        '
        Me.Tel.DataPropertyName = "Tel"
        Me.Tel.HeaderText = "Tel"
        Me.Tel.Name = "Tel"
        Me.Tel.ReadOnly = True
        '
        'Fax
        '
        Me.Fax.DataPropertyName = "Fax"
        Me.Fax.HeaderText = "Fax"
        Me.Fax.Name = "Fax"
        Me.Fax.ReadOnly = True
        '
        'Email
        '
        Me.Email.DataPropertyName = "Email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'Goods
        '
        Me.Goods.DataPropertyName = "Commondity"
        Me.Goods.HeaderText = "Goods"
        Me.Goods.Name = "Goods"
        Me.Goods.ReadOnly = True
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.ReadOnly = True
        '
        'POD
        '
        Me.POD.DataPropertyName = "POD"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        Me.POD.ReadOnly = True
        '
        'OnboardDate
        '
        Me.OnboardDate.DataPropertyName = "OnboardDate"
        Me.OnboardDate.HeaderText = "Onboard Date"
        Me.OnboardDate.Name = "OnboardDate"
        Me.OnboardDate.ReadOnly = True
        '
        'Vessel
        '
        Me.Vessel.DataPropertyName = "Vessel"
        Me.Vessel.HeaderText = "Feeder Vessel"
        Me.Vessel.Name = "Vessel"
        Me.Vessel.ReadOnly = True
        '
        'VoyAge
        '
        Me.VoyAge.DataPropertyName = "VoyAge"
        Me.VoyAge.HeaderText = "Feeder Voyage"
        Me.VoyAge.Name = "VoyAge"
        Me.VoyAge.ReadOnly = True
        '
        'SoLuong20GP
        '
        Me.SoLuong20GP.DataPropertyName = "SoLuong20GP"
        Me.SoLuong20GP.HeaderText = "20GP"
        Me.SoLuong20GP.Name = "SoLuong20GP"
        Me.SoLuong20GP.ReadOnly = True
        '
        'SoLuong40GP
        '
        Me.SoLuong40GP.DataPropertyName = "SoLuong40GP"
        Me.SoLuong40GP.HeaderText = "40GP"
        Me.SoLuong40GP.Name = "SoLuong40GP"
        Me.SoLuong40GP.ReadOnly = True
        '
        'SoLuong20RF
        '
        Me.SoLuong20RF.DataPropertyName = "SoLuong20RF"
        Me.SoLuong20RF.HeaderText = "20RF"
        Me.SoLuong20RF.Name = "SoLuong20RF"
        Me.SoLuong20RF.ReadOnly = True
        '
        'SoLuong40RF
        '
        Me.SoLuong40RF.DataPropertyName = "SoLuong40RF"
        Me.SoLuong40RF.HeaderText = "40RF"
        Me.SoLuong40RF.Name = "SoLuong40RF"
        Me.SoLuong40RF.ReadOnly = True
        '
        'SoLuong40HC
        '
        Me.SoLuong40HC.DataPropertyName = "SoLuong40HC"
        Me.SoLuong40HC.HeaderText = "40HC"
        Me.SoLuong40HC.Name = "SoLuong40HC"
        Me.SoLuong40HC.ReadOnly = True
        '
        'SoLuong45HC
        '
        Me.SoLuong45HC.DataPropertyName = "SoLuong45HC"
        Me.SoLuong45HC.HeaderText = "45HC"
        Me.SoLuong45HC.Name = "SoLuong45HC"
        Me.SoLuong45HC.ReadOnly = True
        '
        'SoLuong40RH
        '
        Me.SoLuong40RH.DataPropertyName = "SoLuong40RH"
        Me.SoLuong40RH.HeaderText = "40RH"
        Me.SoLuong40RH.Name = "SoLuong40RH"
        Me.SoLuong40RH.ReadOnly = True
        '
        'Vent
        '
        Me.Vent.DataPropertyName = "Vent"
        Me.Vent.HeaderText = "Vent"
        Me.Vent.Name = "Vent"
        Me.Vent.ReadOnly = True
        '
        'Temperature
        '
        Me.Temperature.DataPropertyName = "Temperature"
        Me.Temperature.HeaderText = "Temperature"
        Me.Temperature.Name = "Temperature"
        Me.Temperature.ReadOnly = True
        '
        'SpencalEquipMent
        '
        Me.SpencalEquipMent.DataPropertyName = "SpencalEquipMent"
        Me.SpencalEquipMent.HeaderText = "SpencalEquipMent"
        Me.SpencalEquipMent.Name = "SpencalEquipMent"
        Me.SpencalEquipMent.ReadOnly = True
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Continued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Continued.Visible = False
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "Update Time"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'frmBookingOnline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 385)
        Me.Controls.Add(Me.tabData)
        Me.MinimumSize = New System.Drawing.Size(710, 412)
        Me.Name = "frmBookingOnline"
        Me.Text = "Booking Online"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.tabData.ResumeLayout(False)
        Me.tabBookingData.ResumeLayout(False)
        CType(Me.dgdBookingOnline, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPrint.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxtPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tabData As System.Windows.Forms.TabControl
    Friend WithEvents tabBookingData As System.Windows.Forms.TabPage
    Friend WithEvents mclSelect As System.Windows.Forms.MonthCalendar
    Public WithEvents dgdBookingOnline As System.Windows.Forms.DataGridView
    Friend WithEvents tabPrint As System.Windows.Forms.TabPage
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents BookingOnlineID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingOnlineNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ATTN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Goods As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnboardDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Temperature As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpencalEquipMent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
