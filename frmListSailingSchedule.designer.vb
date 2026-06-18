<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListSailingSchedule
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListSailingSchedule))
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtSailingSchedule = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdSailingSchedule = New System.Windows.Forms.DataGridView
        Me.SailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesseL_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETAVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesselETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OperatorSailing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Service = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Capacity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Slot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terminal1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terminal2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terminal3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fraUpdate = New System.Windows.Forms.TabControl
        Me.tbcSailingSchedule = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboService = New System.Windows.Forms.ComboBox
        Me.cboTerminal3 = New System.Windows.Forms.ComboBox
        Me.cboTerminal2 = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cboTerminal1 = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblLeavingDate = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.dtpETA = New System.Windows.Forms.DateTimePicker
        Me.dtpETD = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtETAVoyNo = New System.Windows.Forms.TextBox
        Me.txtVesselVoyno = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtOperator = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtCapacity = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSlot = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.lblPortOfUnLoading = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ETASailingSchedule = New System.Windows.Forms.TabPage
        Me.cmdOkP = New System.Windows.Forms.Button
        Me.cmdCancelP = New System.Windows.Forms.Button
        Me.dtpETDPort = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.DtpETAETA = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.cxtPort = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxtsmnuPort = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdETA = New System.Windows.Forms.DataGridView
        Me.ETAScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETASailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETAPortID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETDPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETAEditable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ETAApprove = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ETAContinued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ETAUserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETAUpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctmnuPrice = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.ctmnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.ctmnuDel = New System.Windows.Forms.ToolStripMenuItem
        Me.cxtPortTranship = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxtsmnuPortTranship = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdSailingSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fraUpdate.SuspendLayout()
        Me.tbcSailingSchedule.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ETASailingSchedule.SuspendLayout()
        Me.cxtPort.SuspendLayout()
        CType(Me.dgdETA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmnuPrice.SuspendLayout()
        Me.cxtPortTranship.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(595, 25)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 9
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtSailingSchedule
        '
        Me.txtSailingSchedule.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtSailingSchedule.Location = New System.Drawing.Point(171, 25)
        Me.txtSailingSchedule.Name = "txtSailingSchedule"
        Me.txtSailingSchedule.Size = New System.Drawing.Size(396, 20)
        Me.txtSailingSchedule.TabIndex = 8
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 25)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(143, 22)
        Me.cboFind.TabIndex = 7
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.RefreshToolStripMenuItem, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(681, 24)
        Me.MenuStrip.TabIndex = 6
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.smnuAdd.Size = New System.Drawing.Size(40, 20)
        Me.smnuAdd.Text = "&New"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'dgdSailingSchedule
        '
        Me.dgdSailingSchedule.AllowUserToAddRows = False
        Me.dgdSailingSchedule.AllowUserToDeleteRows = False
        Me.dgdSailingSchedule.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdSailingSchedule.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdSailingSchedule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdSailingSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdSailingSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SailingScheduleID, Me.Vessel_ID, Me.VesseL_Code, Me.Vessel, Me.VoyNo, Me.ETD, Me.ETAVoyNo, Me.VesselETA, Me.POL, Me.OperatorSailing, Me.Service, Me.Capacity, Me.Slot, Me.Terminal1, Me.Terminal2, Me.Terminal3, Me.Editable, Me.Continued, Me.Approve, Me.UserUpdate, Me.UpdateTime})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdSailingSchedule.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgdSailingSchedule.Location = New System.Drawing.Point(10, 51)
        Me.dgdSailingSchedule.Name = "dgdSailingSchedule"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdSailingSchedule.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgdSailingSchedule.Size = New System.Drawing.Size(646, 181)
        Me.dgdSailingSchedule.TabIndex = 20
        '
        'SailingScheduleID
        '
        Me.SailingScheduleID.DataPropertyName = "SailingScheduleID"
        Me.SailingScheduleID.HeaderText = "SailingScheduleID"
        Me.SailingScheduleID.Name = "SailingScheduleID"
        Me.SailingScheduleID.Visible = False
        '
        'Vessel_ID
        '
        Me.Vessel_ID.DataPropertyName = "Vessel_ID"
        Me.Vessel_ID.HeaderText = "Vessel_ID"
        Me.Vessel_ID.Name = "Vessel_ID"
        Me.Vessel_ID.Visible = False
        '
        'VesseL_Code
        '
        Me.VesseL_Code.DataPropertyName = "VesseL_Code"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        Me.VesseL_Code.DefaultCellStyle = DataGridViewCellStyle2
        Me.VesseL_Code.HeaderText = "Vessel Code"
        Me.VesseL_Code.Name = "VesseL_Code"
        '
        'Vessel
        '
        Me.Vessel.DataPropertyName = "Vessel"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.Vessel.DefaultCellStyle = DataGridViewCellStyle3
        Me.Vessel.HeaderText = "Vessel"
        Me.Vessel.Name = "Vessel"
        '
        'VoyNo
        '
        Me.VoyNo.DataPropertyName = "VoyNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.VoyNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.VoyNo.HeaderText = "VoyNo (ETD)"
        Me.VoyNo.Name = "VoyNo"
        '
        'ETD
        '
        Me.ETD.DataPropertyName = "ETD"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Format = "d"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.ETD.DefaultCellStyle = DataGridViewCellStyle5
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        '
        'ETAVoyNo
        '
        Me.ETAVoyNo.DataPropertyName = "ETAVoyNo"
        Me.ETAVoyNo.HeaderText = "VoyNo (ETA)"
        Me.ETAVoyNo.Name = "ETAVoyNo"
        '
        'VesselETA
        '
        Me.VesselETA.DataPropertyName = "ETA"
        Me.VesselETA.HeaderText = "ETA"
        Me.VesselETA.Name = "VesselETA"
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        '
        'OperatorSailing
        '
        Me.OperatorSailing.DataPropertyName = "Operator"
        Me.OperatorSailing.HeaderText = "Operator"
        Me.OperatorSailing.Name = "OperatorSailing"
        '
        'Service
        '
        Me.Service.DataPropertyName = "Service"
        Me.Service.HeaderText = "Service"
        Me.Service.Name = "Service"
        '
        'Capacity
        '
        Me.Capacity.DataPropertyName = "Capacity"
        Me.Capacity.HeaderText = "Capacity"
        Me.Capacity.Name = "Capacity"
        '
        'Slot
        '
        Me.Slot.DataPropertyName = "Slot"
        Me.Slot.HeaderText = "Slot"
        Me.Slot.Name = "Slot"
        '
        'Terminal1
        '
        Me.Terminal1.DataPropertyName = "Terminal1"
        Me.Terminal1.HeaderText = "Terminal 1"
        Me.Terminal1.Name = "Terminal1"
        '
        'Terminal2
        '
        Me.Terminal2.DataPropertyName = "Terminal2"
        Me.Terminal2.HeaderText = "Terminal 2"
        Me.Terminal2.Name = "Terminal2"
        '
        'Terminal3
        '
        Me.Terminal3.DataPropertyName = "Terminal3"
        Me.Terminal3.HeaderText = "Terminal 3"
        Me.Terminal3.Name = "Terminal3"
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Editable.Visible = False
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        '
        'UserUpdate
        '
        Me.UserUpdate.DataPropertyName = "Userupdate"
        Me.UserUpdate.HeaderText = "User Update"
        Me.UserUpdate.Name = "UserUpdate"
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.tbcSailingSchedule)
        Me.fraUpdate.Controls.Add(Me.ETASailingSchedule)
        Me.fraUpdate.Location = New System.Drawing.Point(10, 240)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.SelectedIndex = 0
        Me.fraUpdate.ShowToolTips = True
        Me.fraUpdate.Size = New System.Drawing.Size(650, 218)
        Me.fraUpdate.TabIndex = 21
        '
        'tbcSailingSchedule
        '
        Me.tbcSailingSchedule.Controls.Add(Me.GroupBox1)
        Me.tbcSailingSchedule.ForeColor = System.Drawing.Color.Maroon
        Me.tbcSailingSchedule.Location = New System.Drawing.Point(4, 22)
        Me.tbcSailingSchedule.Name = "tbcSailingSchedule"
        Me.tbcSailingSchedule.Padding = New System.Windows.Forms.Padding(3)
        Me.tbcSailingSchedule.Size = New System.Drawing.Size(642, 192)
        Me.tbcSailingSchedule.TabIndex = 2
        Me.tbcSailingSchedule.Text = "Feeder Vessel"
        Me.tbcSailingSchedule.ToolTipText = "Lịch Tàu Đi"
        Me.tbcSailingSchedule.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboService)
        Me.GroupBox1.Controls.Add(Me.cboTerminal3)
        Me.GroupBox1.Controls.Add(Me.cboTerminal2)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.cboPOL)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.cboTerminal1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.lblLeavingDate)
        Me.GroupBox1.Controls.Add(Me.cboVessel)
        Me.GroupBox1.Controls.Add(Me.dtpETA)
        Me.GroupBox1.Controls.Add(Me.dtpETD)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtETAVoyNo)
        Me.GroupBox1.Controls.Add(Me.txtVesselVoyno)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtOperator)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtCapacity)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtSlot)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblPortOfUnLoading)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(630, 178)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'cboService
        '
        Me.cboService.FormattingEnabled = True
        Me.cboService.Location = New System.Drawing.Point(202, 122)
        Me.cboService.Name = "cboService"
        Me.cboService.Size = New System.Drawing.Size(75, 21)
        Me.cboService.TabIndex = 42
        '
        'cboTerminal3
        '
        Me.cboTerminal3.FormattingEnabled = True
        Me.cboTerminal3.Location = New System.Drawing.Point(351, 87)
        Me.cboTerminal3.Name = "cboTerminal3"
        Me.cboTerminal3.Size = New System.Drawing.Size(137, 21)
        Me.cboTerminal3.TabIndex = 19
        '
        'cboTerminal2
        '
        Me.cboTerminal2.FormattingEnabled = True
        Me.cboTerminal2.Location = New System.Drawing.Point(351, 51)
        Me.cboTerminal2.Name = "cboTerminal2"
        Me.cboTerminal2.Size = New System.Drawing.Size(137, 21)
        Me.cboTerminal2.TabIndex = 19
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancel.Location = New System.Drawing.Point(332, 146)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(90, 95)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(190, 21)
        Me.cboPOL.TabIndex = 19
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdOk.Location = New System.Drawing.Point(413, 146)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 20
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboTerminal1
        '
        Me.cboTerminal1.FormattingEnabled = True
        Me.cboTerminal1.Location = New System.Drawing.Point(351, 16)
        Me.cboTerminal1.Name = "cboTerminal1"
        Me.cboTerminal1.Size = New System.Drawing.Size(137, 21)
        Me.cboTerminal1.TabIndex = 19
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.ForeColor = System.Drawing.Color.Blue
        Me.Label14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label14.Location = New System.Drawing.Point(153, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 13
        Me.Label14.Text = "ETA :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLeavingDate
        '
        Me.lblLeavingDate.AutoSize = True
        Me.lblLeavingDate.BackColor = System.Drawing.Color.Transparent
        Me.lblLeavingDate.ForeColor = System.Drawing.Color.Blue
        Me.lblLeavingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblLeavingDate.Location = New System.Drawing.Point(152, 73)
        Me.lblLeavingDate.Name = "lblLeavingDate"
        Me.lblLeavingDate.Size = New System.Drawing.Size(35, 13)
        Me.lblLeavingDate.TabIndex = 13
        Me.lblLeavingDate.Text = "ETD :"
        Me.lblLeavingDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(89, 16)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(190, 21)
        Me.cboVessel.TabIndex = 19
        '
        'dtpETA
        '
        Me.dtpETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETA.Location = New System.Drawing.Point(189, 43)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(91, 20)
        Me.dtpETA.TabIndex = 21
        '
        'dtpETD
        '
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(189, 69)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(91, 20)
        Me.dtpETD.TabIndex = 21
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(401, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Slot :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtETAVoyNo
        '
        Me.txtETAVoyNo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtETAVoyNo.ForeColor = System.Drawing.Color.Blue
        Me.txtETAVoyNo.Location = New System.Drawing.Point(88, 43)
        Me.txtETAVoyNo.Name = "txtETAVoyNo"
        Me.txtETAVoyNo.Size = New System.Drawing.Size(62, 20)
        Me.txtETAVoyNo.TabIndex = 20
        '
        'txtVesselVoyno
        '
        Me.txtVesselVoyno.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtVesselVoyno.ForeColor = System.Drawing.Color.Blue
        Me.txtVesselVoyno.Location = New System.Drawing.Point(89, 69)
        Me.txtVesselVoyno.Name = "txtVesselVoyno"
        Me.txtVesselVoyno.Size = New System.Drawing.Size(62, 20)
        Me.txtVesselVoyno.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(295, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Capacity :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOperator
        '
        Me.txtOperator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperator.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtOperator.ForeColor = System.Drawing.Color.Blue
        Me.txtOperator.Location = New System.Drawing.Point(89, 120)
        Me.txtOperator.Name = "txtOperator"
        Me.txtOperator.Size = New System.Drawing.Size(62, 20)
        Me.txtOperator.TabIndex = 20
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(288, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(62, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Terminal 3 :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(152, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Service :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCapacity
        '
        Me.txtCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacity.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtCapacity.ForeColor = System.Drawing.Color.Blue
        Me.txtCapacity.Location = New System.Drawing.Point(351, 120)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(48, 20)
        Me.txtCapacity.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(288, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Terminal 2 :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSlot
        '
        Me.txtSlot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSlot.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtSlot.ForeColor = System.Drawing.Color.Blue
        Me.txtSlot.Location = New System.Drawing.Point(435, 120)
        Me.txtSlot.Name = "txtSlot"
        Me.txtSlot.Size = New System.Drawing.Size(51, 20)
        Me.txtSlot.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(53, 98)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "POL :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPortOfUnLoading
        '
        Me.lblPortOfUnLoading.AutoSize = True
        Me.lblPortOfUnLoading.BackColor = System.Drawing.Color.Transparent
        Me.lblPortOfUnLoading.ForeColor = System.Drawing.Color.Blue
        Me.lblPortOfUnLoading.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblPortOfUnLoading.Location = New System.Drawing.Point(44, 20)
        Me.lblPortOfUnLoading.Name = "lblPortOfUnLoading"
        Me.lblPortOfUnLoading.Size = New System.Drawing.Size(44, 13)
        Me.lblPortOfUnLoading.TabIndex = 9
        Me.lblPortOfUnLoading.Text = "Vessel :"
        Me.lblPortOfUnLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(11, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(75, 13)
        Me.Label13.TabIndex = 15
        Me.Label13.Text = "VoyNo (ETA) :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(33, 124)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Operator :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(10, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "VoyNo (ETD) :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(288, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Terminal 1 :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ETASailingSchedule
        '
        Me.ETASailingSchedule.Controls.Add(Me.cmdOkP)
        Me.ETASailingSchedule.Controls.Add(Me.cmdCancelP)
        Me.ETASailingSchedule.Controls.Add(Me.dtpETDPort)
        Me.ETASailingSchedule.Controls.Add(Me.Label12)
        Me.ETASailingSchedule.Controls.Add(Me.DtpETAETA)
        Me.ETASailingSchedule.Controls.Add(Me.Label2)
        Me.ETASailingSchedule.Controls.Add(Me.Label1)
        Me.ETASailingSchedule.Controls.Add(Me.cboPort)
        Me.ETASailingSchedule.Controls.Add(Me.dgdETA)
        Me.ETASailingSchedule.Location = New System.Drawing.Point(4, 22)
        Me.ETASailingSchedule.Name = "ETASailingSchedule"
        Me.ETASailingSchedule.Size = New System.Drawing.Size(642, 192)
        Me.ETASailingSchedule.TabIndex = 3
        Me.ETASailingSchedule.Text = "Port (Transite)"
        Me.ETASailingSchedule.UseVisualStyleBackColor = True
        '
        'cmdOkP
        '
        Me.cmdOkP.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOkP.Location = New System.Drawing.Point(409, 131)
        Me.cmdOkP.Name = "cmdOkP"
        Me.cmdOkP.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkP.TabIndex = 6
        Me.cmdOkP.Text = "&Ok"
        Me.cmdOkP.UseVisualStyleBackColor = True
        '
        'cmdCancelP
        '
        Me.cmdCancelP.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancelP.Location = New System.Drawing.Point(328, 131)
        Me.cmdCancelP.Name = "cmdCancelP"
        Me.cmdCancelP.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelP.TabIndex = 5
        Me.cmdCancelP.Text = "&Cancel"
        Me.cmdCancelP.UseVisualStyleBackColor = True
        '
        'dtpETDPort
        '
        Me.dtpETDPort.Enabled = False
        Me.dtpETDPort.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETDPort.Location = New System.Drawing.Point(186, 155)
        Me.dtpETDPort.Name = "dtpETDPort"
        Me.dtpETDPort.Size = New System.Drawing.Size(100, 20)
        Me.dtpETDPort.TabIndex = 4
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Maroon
        Me.Label12.Location = New System.Drawing.Point(149, 158)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "ETD :"
        '
        'DtpETAETA
        '
        Me.DtpETAETA.Enabled = False
        Me.DtpETAETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpETAETA.Location = New System.Drawing.Point(49, 155)
        Me.DtpETAETA.Name = "DtpETAETA"
        Me.DtpETAETA.Size = New System.Drawing.Size(100, 20)
        Me.DtpETAETA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(12, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ETA :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(14, 131)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Port :"
        '
        'cboPort
        '
        Me.cboPort.ContextMenuStrip = Me.cxtPort
        Me.cboPort.Enabled = False
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(49, 128)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(237, 21)
        Me.cboPort.TabIndex = 1
        '
        'cxtPort
        '
        Me.cxtPort.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxtsmnuPort})
        Me.cxtPort.Name = "ctmnuPrice"
        Me.cxtPort.Size = New System.Drawing.Size(108, 26)
        '
        'cxtsmnuPort
        '
        Me.cxtsmnuPort.Name = "cxtsmnuPort"
        Me.cxtsmnuPort.Size = New System.Drawing.Size(107, 22)
        Me.cxtsmnuPort.Text = "Search"
        '
        'dgdETA
        '
        Me.dgdETA.AllowUserToAddRows = False
        Me.dgdETA.AllowUserToDeleteRows = False
        Me.dgdETA.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdETA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgdETA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdETA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ETAScheduleID, Me.ETASailingScheduleID, Me.ETAPortID, Me.Port_Code, Me.Port, Me.ETA, Me.ETDPort, Me.ETAEditable, Me.ETAApprove, Me.ETAContinued, Me.ETAUserUpdate, Me.ETAUpdateTime})
        Me.dgdETA.ContextMenuStrip = Me.ctmnuPrice
        Me.dgdETA.Location = New System.Drawing.Point(13, 10)
        Me.dgdETA.Name = "dgdETA"
        Me.dgdETA.Size = New System.Drawing.Size(612, 112)
        Me.dgdETA.TabIndex = 0
        '
        'ETAScheduleID
        '
        Me.ETAScheduleID.DataPropertyName = "ETAScheduleID"
        Me.ETAScheduleID.HeaderText = "ETAScheDuleID"
        Me.ETAScheduleID.Name = "ETAScheduleID"
        Me.ETAScheduleID.Visible = False
        '
        'ETASailingScheduleID
        '
        Me.ETASailingScheduleID.DataPropertyName = "SailingScheduleID"
        Me.ETASailingScheduleID.HeaderText = "ETASailingScheduleID"
        Me.ETASailingScheduleID.Name = "ETASailingScheduleID"
        Me.ETASailingScheduleID.Visible = False
        '
        'ETAPortID
        '
        Me.ETAPortID.DataPropertyName = "PortID"
        Me.ETAPortID.HeaderText = "Port ID"
        Me.ETAPortID.Name = "ETAPortID"
        Me.ETAPortID.Visible = False
        '
        'Port_Code
        '
        Me.Port_Code.DataPropertyName = "Port_Code"
        Me.Port_Code.HeaderText = "Port Code"
        Me.Port_Code.Name = "Port_Code"
        '
        'Port
        '
        Me.Port.DataPropertyName = "Port"
        Me.Port.HeaderText = "Port Name"
        Me.Port.Name = "Port"
        '
        'ETA
        '
        Me.ETA.DataPropertyName = "ETA"
        DataGridViewCellStyle9.Format = "d"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.ETA.DefaultCellStyle = DataGridViewCellStyle9
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        '
        'ETDPort
        '
        Me.ETDPort.DataPropertyName = "ETD"
        Me.ETDPort.HeaderText = "ETD"
        Me.ETDPort.Name = "ETDPort"
        '
        'ETAEditable
        '
        Me.ETAEditable.DataPropertyName = "Editable"
        Me.ETAEditable.HeaderText = "ETAEditable"
        Me.ETAEditable.Name = "ETAEditable"
        Me.ETAEditable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ETAEditable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ETAEditable.Visible = False
        '
        'ETAApprove
        '
        Me.ETAApprove.DataPropertyName = "Approve"
        Me.ETAApprove.HeaderText = "Approve"
        Me.ETAApprove.Name = "ETAApprove"
        '
        'ETAContinued
        '
        Me.ETAContinued.DataPropertyName = "Continued"
        Me.ETAContinued.HeaderText = "Continued"
        Me.ETAContinued.Name = "ETAContinued"
        Me.ETAContinued.Visible = False
        '
        'ETAUserUpdate
        '
        Me.ETAUserUpdate.DataPropertyName = "UserUpdate"
        Me.ETAUserUpdate.HeaderText = "UserUpdate"
        Me.ETAUserUpdate.Name = "ETAUserUpdate"
        '
        'ETAUpdateTime
        '
        Me.ETAUpdateTime.DataPropertyName = "UpdateTime"
        Me.ETAUpdateTime.HeaderText = "UpdateTime"
        Me.ETAUpdateTime.Name = "ETAUpdateTime"
        '
        'ctmnuPrice
        '
        Me.ctmnuPrice.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmnuAdd, Me.ctmnuEdit, Me.ctmnuDel})
        Me.ctmnuPrice.Name = "ctmnuPrice"
        Me.ctmnuPrice.Size = New System.Drawing.Size(106, 70)
        '
        'ctmnuAdd
        '
        Me.ctmnuAdd.Image = CType(resources.GetObject("ctmnuAdd.Image"), System.Drawing.Image)
        Me.ctmnuAdd.Name = "ctmnuAdd"
        Me.ctmnuAdd.Size = New System.Drawing.Size(105, 22)
        Me.ctmnuAdd.Text = "Add"
        '
        'ctmnuEdit
        '
        Me.ctmnuEdit.Image = CType(resources.GetObject("ctmnuEdit.Image"), System.Drawing.Image)
        Me.ctmnuEdit.Name = "ctmnuEdit"
        Me.ctmnuEdit.Size = New System.Drawing.Size(105, 22)
        Me.ctmnuEdit.Text = "Edit"
        '
        'ctmnuDel
        '
        Me.ctmnuDel.Image = CType(resources.GetObject("ctmnuDel.Image"), System.Drawing.Image)
        Me.ctmnuDel.Name = "ctmnuDel"
        Me.ctmnuDel.Size = New System.Drawing.Size(105, 22)
        Me.ctmnuDel.Text = "Delete"
        '
        'cxtPortTranship
        '
        Me.cxtPortTranship.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cxtsmnuPortTranship})
        Me.cxtPortTranship.Name = "ctmnuPrice"
        Me.cxtPortTranship.Size = New System.Drawing.Size(108, 26)
        '
        'cxtsmnuPortTranship
        '
        Me.cxtsmnuPortTranship.Name = "cxtsmnuPortTranship"
        Me.cxtsmnuPortTranship.Size = New System.Drawing.Size(107, 22)
        Me.cxtsmnuPortTranship.Text = "Search"
        '
        'frmListSailingSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(681, 466)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtSailingSchedule)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdSailingSchedule)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmListSailingSchedule"
        Me.Text = "Sailing Schedule Feeder"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.dgdSailingSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fraUpdate.ResumeLayout(False)
        Me.tbcSailingSchedule.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ETASailingSchedule.ResumeLayout(False)
        Me.ETASailingSchedule.PerformLayout()
        Me.cxtPort.ResumeLayout(False)
        CType(Me.dgdETA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctmnuPrice.ResumeLayout(False)
        Me.cxtPortTranship.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtSailingSchedule As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgdSailingSchedule As System.Windows.Forms.DataGridView
    Friend WithEvents fraUpdate As System.Windows.Forms.TabControl
    Friend WithEvents tbcSailingSchedule As System.Windows.Forms.TabPage
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblPortOfUnLoading As System.Windows.Forms.Label
    Friend WithEvents txtVesselVoyno As System.Windows.Forms.TextBox
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblLeavingDate As System.Windows.Forms.Label
    Friend WithEvents ETASailingSchedule As System.Windows.Forms.TabPage
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents DtpETAETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents dgdETA As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCancelP As System.Windows.Forms.Button
    Friend WithEvents ctmnuPrice As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmnuDel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOkP As System.Windows.Forms.Button
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxtPortTranship As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxtsmnuPortTranship As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cxtPort As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cxtsmnuPort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboTerminal3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTerminal2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboTerminal1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSlot As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents txtOperator As System.Windows.Forms.TextBox
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtpETDPort As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ETAScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETASailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETAPortID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETAEditable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ETAApprove As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ETAContinued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ETAUserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETAUpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtETAVoyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesseL_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETAVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorSailing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Slot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminal1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminal2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminal3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboService As System.Windows.Forms.ComboBox
End Class
