<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListSailingScheduleMother
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListSailingScheduleMother))
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
        Me.OceanVesselID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OceanVessel_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OceanVessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OceanVesselVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OperatorMother = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terminal1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terminal2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Terminal3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Slot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Capacity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Service = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OceanETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserUpdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.fraUpdate = New System.Windows.Forms.TabControl
        Me.tbcSailingSchedule = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboOceanVessel = New System.Windows.Forms.ComboBox
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblClosingTime = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtOceanVoyNo = New System.Windows.Forms.TextBox
        Me.txtSlot = New System.Windows.Forms.TextBox
        Me.txtCapacity = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtOperator = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpVesselETD = New System.Windows.Forms.DateTimePicker
        Me.ETASailingSchedule = New System.Windows.Forms.TabPage
        Me.dtpETDPort = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmdOkP = New System.Windows.Forms.Button
        Me.cmdCancelP = New System.Windows.Forms.Button
        Me.DtpETAETA = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.cxtPort = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cxtsmnuPort = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdETA = New System.Windows.Forms.DataGridView
        Me.MotherTranShipID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotherSailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cboService = New System.Windows.Forms.ComboBox
        Me.MenuStrip.SuspendLayout()
        CType(Me.dgdSailingSchedule, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
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
        Me.MenuStrip.Size = New System.Drawing.Size(804, 24)
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdSailingSchedule.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdSailingSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdSailingSchedule.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SailingScheduleID, Me.OceanVesselID, Me.OceanVessel_Code, Me.OceanVessel, Me.OceanVesselVoyNo, Me.POL, Me.OperatorMother, Me.Terminal1, Me.Terminal2, Me.Terminal3, Me.Slot, Me.Capacity, Me.Service, Me.OceanETD, Me.Editable, Me.Continued, Me.Approve, Me.UserUpdate, Me.UpdateTime})
        Me.dgdSailingSchedule.ContextMenuStrip = Me.ContextMenuStrip1
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdSailingSchedule.DefaultCellStyle = DataGridViewCellStyle14
        Me.dgdSailingSchedule.Location = New System.Drawing.Point(16, 53)
        Me.dgdSailingSchedule.Name = "dgdSailingSchedule"
        Me.dgdSailingSchedule.Size = New System.Drawing.Size(750, 181)
        Me.dgdSailingSchedule.TabIndex = 20
        '
        'SailingScheduleID
        '
        Me.SailingScheduleID.DataPropertyName = "MotherSailingScheduleID"
        Me.SailingScheduleID.HeaderText = "SailingScheduleID"
        Me.SailingScheduleID.Name = "SailingScheduleID"
        Me.SailingScheduleID.Visible = False
        '
        'OceanVesselID
        '
        Me.OceanVesselID.DataPropertyName = "OceanVesselID"
        Me.OceanVesselID.HeaderText = "OceanVesselID"
        Me.OceanVesselID.Name = "OceanVesselID"
        Me.OceanVesselID.Visible = False
        '
        'OceanVessel_Code
        '
        Me.OceanVessel_Code.DataPropertyName = "OceanVessel_Code"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        Me.OceanVessel_Code.DefaultCellStyle = DataGridViewCellStyle10
        Me.OceanVessel_Code.HeaderText = "Ocean Vessel Code"
        Me.OceanVessel_Code.Name = "OceanVessel_Code"
        '
        'OceanVessel
        '
        Me.OceanVessel.DataPropertyName = "OceanVessel"
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        Me.OceanVessel.DefaultCellStyle = DataGridViewCellStyle11
        Me.OceanVessel.HeaderText = "OceanVessel"
        Me.OceanVessel.Name = "OceanVessel"
        '
        'OceanVesselVoyNo
        '
        Me.OceanVesselVoyNo.DataPropertyName = "OceanVesselVoyNo"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        Me.OceanVesselVoyNo.DefaultCellStyle = DataGridViewCellStyle12
        Me.OceanVesselVoyNo.HeaderText = "Ocean Vessel Voy No"
        Me.OceanVesselVoyNo.Name = "OceanVesselVoyNo"
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        '
        'OperatorMother
        '
        Me.OperatorMother.DataPropertyName = "Operator"
        Me.OperatorMother.HeaderText = "Operator"
        Me.OperatorMother.Name = "OperatorMother"
        '
        'Terminal1
        '
        Me.Terminal1.DataPropertyName = "Terminal1"
        Me.Terminal1.HeaderText = "Terminal 1"
        Me.Terminal1.Name = "Terminal1"
        Me.Terminal1.Visible = False
        '
        'Terminal2
        '
        Me.Terminal2.DataPropertyName = "Terminal2"
        Me.Terminal2.HeaderText = "Terminal 2"
        Me.Terminal2.Name = "Terminal2"
        Me.Terminal2.Visible = False
        '
        'Terminal3
        '
        Me.Terminal3.DataPropertyName = "Terminal3"
        Me.Terminal3.HeaderText = "Terminal 3"
        Me.Terminal3.Name = "Terminal3"
        Me.Terminal3.Visible = False
        '
        'Slot
        '
        Me.Slot.DataPropertyName = "Slot"
        Me.Slot.HeaderText = "Slot"
        Me.Slot.Name = "Slot"
        '
        'Capacity
        '
        Me.Capacity.DataPropertyName = "Capacity"
        Me.Capacity.HeaderText = "Capacity"
        Me.Capacity.Name = "Capacity"
        '
        'Service
        '
        Me.Service.DataPropertyName = "Service"
        Me.Service.HeaderText = "Service"
        Me.Service.Name = "Service"
        '
        'OceanETD
        '
        Me.OceanETD.DataPropertyName = "OceanETD"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        Me.OceanETD.DefaultCellStyle = DataGridViewCellStyle13
        Me.OceanETD.HeaderText = "ETD (OceanVessel)"
        Me.OceanETD.Name = "OceanETD"
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
        Me.UserUpdate.DataPropertyName = "UserID"
        Me.UserUpdate.HeaderText = "User Update"
        Me.UserUpdate.Name = "UserUpdate"
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(93, 26)
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.tbcSailingSchedule)
        Me.fraUpdate.Controls.Add(Me.ETASailingSchedule)
        Me.fraUpdate.Location = New System.Drawing.Point(10, 240)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.SelectedIndex = 0
        Me.fraUpdate.ShowToolTips = True
        Me.fraUpdate.Size = New System.Drawing.Size(750, 214)
        Me.fraUpdate.TabIndex = 21
        '
        'tbcSailingSchedule
        '
        Me.tbcSailingSchedule.Controls.Add(Me.GroupBox1)
        Me.tbcSailingSchedule.ForeColor = System.Drawing.Color.Maroon
        Me.tbcSailingSchedule.Location = New System.Drawing.Point(4, 22)
        Me.tbcSailingSchedule.Name = "tbcSailingSchedule"
        Me.tbcSailingSchedule.Padding = New System.Windows.Forms.Padding(3)
        Me.tbcSailingSchedule.Size = New System.Drawing.Size(742, 188)
        Me.tbcSailingSchedule.TabIndex = 2
        Me.tbcSailingSchedule.Text = "Mother Vessel "
        Me.tbcSailingSchedule.ToolTipText = "Lịch Tàu Đi"
        Me.tbcSailingSchedule.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboService)
        Me.GroupBox1.Controls.Add(Me.cboOceanVessel)
        Me.GroupBox1.Controls.Add(Me.cboPOL)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblClosingTime)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtOceanVoyNo)
        Me.GroupBox1.Controls.Add(Me.txtSlot)
        Me.GroupBox1.Controls.Add(Me.txtCapacity)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtOperator)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpVesselETD)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(461, 176)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'cboOceanVessel
        '
        Me.cboOceanVessel.FormattingEnabled = True
        Me.cboOceanVessel.ItemHeight = 13
        Me.cboOceanVessel.Location = New System.Drawing.Point(114, 14)
        Me.cboOceanVessel.Name = "cboOceanVessel"
        Me.cboOceanVessel.Size = New System.Drawing.Size(236, 21)
        Me.cboOceanVessel.TabIndex = 5
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(114, 67)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(236, 21)
        Me.cboPOL.TabIndex = 36
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancel.Location = New System.Drawing.Point(299, 147)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(240, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Slot :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdOk.Location = New System.Drawing.Point(380, 147)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 20
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(59, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 31
        Me.Label5.Text = "Capacity :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblClosingTime
        '
        Me.lblClosingTime.AutoSize = True
        Me.lblClosingTime.BackColor = System.Drawing.Color.Transparent
        Me.lblClosingTime.ForeColor = System.Drawing.Color.Blue
        Me.lblClosingTime.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblClosingTime.Location = New System.Drawing.Point(182, 44)
        Me.lblClosingTime.Name = "lblClosingTime"
        Me.lblClosingTime.Size = New System.Drawing.Size(35, 13)
        Me.lblClosingTime.TabIndex = 11
        Me.lblClosingTime.Text = "ETD :"
        Me.lblClosingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(76, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "POL :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(32, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Ocean Vessel :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(56, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 13)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Operator :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOceanVoyNo
        '
        Me.txtOceanVoyNo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtOceanVoyNo.ForeColor = System.Drawing.Color.Blue
        Me.txtOceanVoyNo.Location = New System.Drawing.Point(114, 41)
        Me.txtOceanVoyNo.Name = "txtOceanVoyNo"
        Me.txtOceanVoyNo.Size = New System.Drawing.Size(64, 20)
        Me.txtOceanVoyNo.TabIndex = 24
        '
        'txtSlot
        '
        Me.txtSlot.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSlot.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtSlot.ForeColor = System.Drawing.Color.Blue
        Me.txtSlot.Location = New System.Drawing.Point(273, 120)
        Me.txtSlot.Name = "txtSlot"
        Me.txtSlot.Size = New System.Drawing.Size(77, 20)
        Me.txtSlot.TabIndex = 40
        '
        'txtCapacity
        '
        Me.txtCapacity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCapacity.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtCapacity.ForeColor = System.Drawing.Color.Blue
        Me.txtCapacity.Location = New System.Drawing.Point(115, 119)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(61, 20)
        Me.txtCapacity.TabIndex = 39
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(18, 44)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "O.Vessel Voy No :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOperator
        '
        Me.txtOperator.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperator.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtOperator.ForeColor = System.Drawing.Color.Blue
        Me.txtOperator.Location = New System.Drawing.Point(114, 94)
        Me.txtOperator.Name = "txtOperator"
        Me.txtOperator.Size = New System.Drawing.Size(62, 20)
        Me.txtOperator.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(222, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Service :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpVesselETD
        '
        Me.dtpVesselETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpVesselETD.Location = New System.Drawing.Point(217, 41)
        Me.dtpVesselETD.Name = "dtpVesselETD"
        Me.dtpVesselETD.Size = New System.Drawing.Size(133, 20)
        Me.dtpVesselETD.TabIndex = 25
        Me.ToolTip1.SetToolTip(Me.dtpVesselETD, "Ngày tàu đi")
        '
        'ETASailingSchedule
        '
        Me.ETASailingSchedule.Controls.Add(Me.dtpETDPort)
        Me.ETASailingSchedule.Controls.Add(Me.Label13)
        Me.ETASailingSchedule.Controls.Add(Me.cmdOkP)
        Me.ETASailingSchedule.Controls.Add(Me.cmdCancelP)
        Me.ETASailingSchedule.Controls.Add(Me.DtpETAETA)
        Me.ETASailingSchedule.Controls.Add(Me.Label2)
        Me.ETASailingSchedule.Controls.Add(Me.Label1)
        Me.ETASailingSchedule.Controls.Add(Me.cboPort)
        Me.ETASailingSchedule.Controls.Add(Me.dgdETA)
        Me.ETASailingSchedule.Location = New System.Drawing.Point(4, 22)
        Me.ETASailingSchedule.Name = "ETASailingSchedule"
        Me.ETASailingSchedule.Size = New System.Drawing.Size(742, 188)
        Me.ETASailingSchedule.TabIndex = 3
        Me.ETASailingSchedule.Text = "Port (Arrival)"
        Me.ETASailingSchedule.UseVisualStyleBackColor = True
        '
        'dtpETDPort
        '
        Me.dtpETDPort.Enabled = False
        Me.dtpETDPort.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETDPort.Location = New System.Drawing.Point(190, 155)
        Me.dtpETDPort.Name = "dtpETDPort"
        Me.dtpETDPort.Size = New System.Drawing.Size(100, 20)
        Me.dtpETDPort.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(153, 158)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "ETD :"
        '
        'cmdOkP
        '
        Me.cmdOkP.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOkP.Location = New System.Drawing.Point(478, 126)
        Me.cmdOkP.Name = "cmdOkP"
        Me.cmdOkP.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkP.TabIndex = 6
        Me.cmdOkP.Text = "&Ok"
        Me.cmdOkP.UseVisualStyleBackColor = True
        '
        'cmdCancelP
        '
        Me.cmdCancelP.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancelP.Location = New System.Drawing.Point(397, 126)
        Me.cmdCancelP.Name = "cmdCancelP"
        Me.cmdCancelP.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelP.TabIndex = 5
        Me.cmdCancelP.Text = "&Cancel"
        Me.cmdCancelP.UseVisualStyleBackColor = True
        '
        'DtpETAETA
        '
        Me.DtpETAETA.Enabled = False
        Me.DtpETAETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpETAETA.Location = New System.Drawing.Point(57, 155)
        Me.DtpETAETA.Name = "DtpETAETA"
        Me.DtpETAETA.Size = New System.Drawing.Size(91, 20)
        Me.DtpETAETA.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(20, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ETA :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(22, 131)
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
        Me.cboPort.Location = New System.Drawing.Point(57, 128)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(233, 21)
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdETA.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdETA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdETA.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MotherTranShipID, Me.MotherSailingScheduleID, Me.ETAPortID, Me.Port_Code, Me.Port, Me.ETA, Me.ETDPort, Me.ETAEditable, Me.ETAApprove, Me.ETAContinued, Me.ETAUserUpdate, Me.ETAUpdateTime})
        Me.dgdETA.ContextMenuStrip = Me.ctmnuPrice
        Me.dgdETA.Location = New System.Drawing.Point(5, 6)
        Me.dgdETA.Name = "dgdETA"
        Me.dgdETA.Size = New System.Drawing.Size(731, 112)
        Me.dgdETA.TabIndex = 0
        '
        'MotherTranShipID
        '
        Me.MotherTranShipID.DataPropertyName = "MotherTranShipID"
        Me.MotherTranShipID.HeaderText = "ETAScheDuleID"
        Me.MotherTranShipID.Name = "MotherTranShipID"
        Me.MotherTranShipID.Visible = False
        '
        'MotherSailingScheduleID
        '
        Me.MotherSailingScheduleID.DataPropertyName = "MotherSailingScheduleID"
        Me.MotherSailingScheduleID.HeaderText = "ETASailingScheduleID"
        Me.MotherSailingScheduleID.Name = "MotherSailingScheduleID"
        Me.MotherSailingScheduleID.Visible = False
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
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ETA.DefaultCellStyle = DataGridViewCellStyle6
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        '
        'ETDPort
        '
        Me.ETDPort.DataPropertyName = "ETD"
        Me.ETDPort.HeaderText = "ETD "
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
        'cboService
        '
        Me.cboService.FormattingEnabled = True
        Me.cboService.Location = New System.Drawing.Point(272, 93)
        Me.cboService.Name = "cboService"
        Me.cboService.Size = New System.Drawing.Size(78, 21)
        Me.cboService.TabIndex = 41
        '
        'frmListSailingScheduleMother
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(804, 466)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdSailingSchedule)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtSailingSchedule)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmListSailingScheduleMother"
        Me.Text = "Sailing Schedule Mother"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        CType(Me.dgdSailingSchedule, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
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
    Friend WithEvents cboOceanVessel As System.Windows.Forms.ComboBox
    Friend WithEvents dtpVesselETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtOceanVoyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblClosingTime As System.Windows.Forms.Label
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
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSlot As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents txtOperator As System.Windows.Forms.TextBox
    Friend WithEvents dtpETDPort As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MotherTranShipID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotherSailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OceanVesselID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OceanVessel_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OceanVessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OceanVesselVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OperatorMother As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminal1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminal2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Terminal3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Slot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OceanETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserUpdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboService As System.Windows.Forms.ComboBox
End Class
