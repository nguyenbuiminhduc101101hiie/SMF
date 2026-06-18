<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputLoadingPlanForVessel
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputLoadingPlanForVessel))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuLoadingList = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportLoadingPlan = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadingFormForPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LoadingFormForShangHaiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.InputDataLoadingFormForPortToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuLoadingCheck = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtContainerOutboundNotify = New System.Windows.Forms.TextBox
        Me.cboVesselVoyNoETD = New System.Windows.Forms.ComboBox
        Me.lblBookingNo = New System.Windows.Forms.Label
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.txtReturnDate = New System.Windows.Forms.TextBox
        Me.chkNull2 = New System.Windows.Forms.CheckBox
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtVent = New System.Windows.Forms.TextBox
        Me.txtCold = New System.Windows.Forms.TextBox
        Me.chkDelay = New System.Windows.Forms.CheckBox
        Me.chkCustomClear = New System.Windows.Forms.CheckBox
        Me.dtpDelayDate = New System.Windows.Forms.DateTimePicker
        Me.chkCancel = New System.Windows.Forms.CheckBox
        Me.cboContainerType = New System.Windows.Forms.ComboBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.txtQuantity = New System.Windows.Forms.TextBox
        Me.dtpDateOfSupplyMTContainer = New System.Windows.Forms.DateTimePicker
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.chkNull = New System.Windows.Forms.CheckBox
        Me.txtSeal = New System.Windows.Forms.TextBox
        Me.txtDateOfSupplyMtContainer = New System.Windows.Forms.TextBox
        Me.cboContainerNo = New System.Windows.Forms.ComboBox
        Me.cboPlaceOfSupplyMTContainer = New System.Windows.Forms.ComboBox
        Me.cboReturnPlace = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgdAddContainer = New System.Windows.Forms.DataGridView
        Me.LOADINGPLANFORVESSELID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BooKingContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_NoAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_SIZE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cold = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SealAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateOfSupplyEmptyContainer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RETURNPLACE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReturnDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLACESUPPLYEMPTYCONTAINER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomClear = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DelayAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DelayDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CancelAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ApproveAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EditableAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContinuedAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIdAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatetimeAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.ctmEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.ctmDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgdDelayInfo = New System.Windows.Forms.DataGridView
        Me.BookingNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Delay = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DateOfDelay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CanCel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.panBooking = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.txtBookingNoSearch = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmdCancelSearch = New System.Windows.Forms.Button
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.dgdContianerOutboundNotify = New System.Windows.Forms.DataGridView
        Me.ctxSearchBookingNoGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmFindBookingNo = New System.Windows.Forms.ToolStripMenuItem
        Me.PreViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ContainerOutBoundNotifyId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalContainer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalBookingContainer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SupplyOrder = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Customer_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OT20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OT40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingVent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingCold = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Tranship = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PortOfUnLoading = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Dest = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PackingWay = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FullReturnContainerPlace = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdAddContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgdDelayInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panBooking.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        CType(Me.dgdContianerOutboundNotify, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxSearchBookingNoGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuEdit, Me.smnuLoadingList, Me.mnuExportLoadingPlan, Me.LoadingFormForPortToolStripMenuItem, Me.LoadingFormForShangHaiToolStripMenuItem, Me.InputDataLoadingFormForPortToolStripMenuItem, Me.mnuPrint, Me.smnuLoadingCheck, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1143, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(90, 20)
        Me.smnuEdit.Text = "&Edit (Quantity)"
        '
        'smnuLoadingList
        '
        Me.smnuLoadingList.ForeColor = System.Drawing.Color.Maroon
        Me.smnuLoadingList.Name = "smnuLoadingList"
        Me.smnuLoadingList.Size = New System.Drawing.Size(117, 20)
        Me.smnuLoadingList.Text = "&Loading list (Feeder)"
        Me.smnuLoadingList.Visible = False
        '
        'mnuExportLoadingPlan
        '
        Me.mnuExportLoadingPlan.ForeColor = System.Drawing.Color.Maroon
        Me.mnuExportLoadingPlan.Name = "mnuExportLoadingPlan"
        Me.mnuExportLoadingPlan.Size = New System.Drawing.Size(172, 20)
        Me.mnuExportLoadingPlan.Text = "Loading List (Outbound-Feeder)"
        Me.mnuExportLoadingPlan.Visible = False
        '
        'LoadingFormForPortToolStripMenuItem
        '
        Me.LoadingFormForPortToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.LoadingFormForPortToolStripMenuItem.Name = "LoadingFormForPortToolStripMenuItem"
        Me.LoadingFormForPortToolStripMenuItem.Size = New System.Drawing.Size(125, 20)
        Me.LoadingFormForPortToolStripMenuItem.Text = "Loading Form For Port"
        '
        'LoadingFormForShangHaiToolStripMenuItem
        '
        Me.LoadingFormForShangHaiToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.LoadingFormForShangHaiToolStripMenuItem.Name = "LoadingFormForShangHaiToolStripMenuItem"
        Me.LoadingFormForShangHaiToolStripMenuItem.Size = New System.Drawing.Size(150, 20)
        Me.LoadingFormForShangHaiToolStripMenuItem.Text = "Loading Form For ShangHai"
        '
        'InputDataLoadingFormForPortToolStripMenuItem
        '
        Me.InputDataLoadingFormForPortToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.InputDataLoadingFormForPortToolStripMenuItem.Name = "InputDataLoadingFormForPortToolStripMenuItem"
        Me.InputDataLoadingFormForPortToolStripMenuItem.Size = New System.Drawing.Size(188, 20)
        Me.InputDataLoadingFormForPortToolStripMenuItem.Text = "Input Data (Loading Form For Port)"
        '
        'mnuPrint
        '
        Me.mnuPrint.ForeColor = System.Drawing.Color.Maroon
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(41, 20)
        Me.mnuPrint.Text = "Print"
        '
        'smnuLoadingCheck
        '
        Me.smnuLoadingCheck.ForeColor = System.Drawing.Color.Maroon
        Me.smnuLoadingCheck.Name = "smnuLoadingCheck"
        Me.smnuLoadingCheck.Size = New System.Drawing.Size(88, 20)
        Me.smnuLoadingCheck.Text = "Loading Check"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(874, 27)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 6
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtContainerOutboundNotify
        '
        Me.txtContainerOutboundNotify.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtContainerOutboundNotify.Location = New System.Drawing.Point(370, 28)
        Me.txtContainerOutboundNotify.Name = "txtContainerOutboundNotify"
        Me.txtContainerOutboundNotify.Size = New System.Drawing.Size(484, 20)
        Me.txtContainerOutboundNotify.TabIndex = 5
        '
        'cboVesselVoyNoETD
        '
        Me.cboVesselVoyNoETD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVesselVoyNoETD.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboVesselVoyNoETD.FormattingEnabled = True
        Me.cboVesselVoyNoETD.Location = New System.Drawing.Point(125, 27)
        Me.cboVesselVoyNoETD.Name = "cboVesselVoyNoETD"
        Me.cboVesselVoyNoETD.Size = New System.Drawing.Size(239, 22)
        Me.cboVesselVoyNoETD.TabIndex = 4
        '
        'lblBookingNo
        '
        Me.lblBookingNo.AutoSize = True
        Me.lblBookingNo.ForeColor = System.Drawing.Color.Blue
        Me.lblBookingNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblBookingNo.Location = New System.Drawing.Point(9, 31)
        Me.lblBookingNo.Name = "lblBookingNo"
        Me.lblBookingNo.Size = New System.Drawing.Size(111, 13)
        Me.lblBookingNo.TabIndex = 8
        Me.lblBookingNo.Text = "Vessel/VoyNo/ETD. :"
        Me.lblBookingNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.txtReturnDate)
        Me.fraUpdate.Controls.Add(Me.chkNull2)
        Me.fraUpdate.Controls.Add(Me.dtpReturnDate)
        Me.fraUpdate.Controls.Add(Me.Label9)
        Me.fraUpdate.Controls.Add(Me.GroupBox1)
        Me.fraUpdate.Controls.Add(Me.cboContainerType)
        Me.fraUpdate.Controls.Add(Me.txtWeight)
        Me.fraUpdate.Controls.Add(Me.txtQuantity)
        Me.fraUpdate.Controls.Add(Me.dtpDateOfSupplyMTContainer)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.Controls.Add(Me.chkNull)
        Me.fraUpdate.Controls.Add(Me.txtSeal)
        Me.fraUpdate.Controls.Add(Me.txtDateOfSupplyMtContainer)
        Me.fraUpdate.Controls.Add(Me.cboContainerNo)
        Me.fraUpdate.Controls.Add(Me.cboPlaceOfSupplyMTContainer)
        Me.fraUpdate.Controls.Add(Me.cboReturnPlace)
        Me.fraUpdate.Controls.Add(Me.Label8)
        Me.fraUpdate.Controls.Add(Me.Label7)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.dgdAddContainer)
        Me.fraUpdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.fraUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.fraUpdate.Location = New System.Drawing.Point(0, 290)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(1143, 288)
        Me.fraUpdate.TabIndex = 1
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Add Container No."
        Me.fraUpdate.Visible = False
        '
        'txtReturnDate
        '
        Me.txtReturnDate.Location = New System.Drawing.Point(472, 192)
        Me.txtReturnDate.Name = "txtReturnDate"
        Me.txtReturnDate.Size = New System.Drawing.Size(73, 20)
        Me.txtReturnDate.TabIndex = 20
        '
        'chkNull2
        '
        Me.chkNull2.AutoSize = True
        Me.chkNull2.Location = New System.Drawing.Point(551, 196)
        Me.chkNull2.Name = "chkNull2"
        Me.chkNull2.Size = New System.Drawing.Size(58, 17)
        Me.chkNull2.TabIndex = 19
        Me.chkNull2.Text = "(None)"
        Me.chkNull2.UseVisualStyleBackColor = True
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpReturnDate.Location = New System.Drawing.Point(609, 194)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.Size = New System.Drawing.Size(90, 20)
        Me.dtpReturnDate.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(402, 194)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Return Date :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtVent)
        Me.GroupBox1.Controls.Add(Me.txtCold)
        Me.GroupBox1.Controls.Add(Me.chkDelay)
        Me.GroupBox1.Controls.Add(Me.chkCustomClear)
        Me.GroupBox1.Controls.Add(Me.dtpDelayDate)
        Me.GroupBox1.Controls.Add(Me.chkCancel)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 246)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(525, 36)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(72, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(35, 13)
        Me.Label12.TabIndex = 20
        Me.Label12.Text = "Vent :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(2, 14)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Cold :"
        '
        'txtVent
        '
        Me.txtVent.Location = New System.Drawing.Point(108, 11)
        Me.txtVent.Name = "txtVent"
        Me.txtVent.Size = New System.Drawing.Size(32, 20)
        Me.txtVent.TabIndex = 18
        '
        'txtCold
        '
        Me.txtCold.Location = New System.Drawing.Point(37, 11)
        Me.txtCold.Name = "txtCold"
        Me.txtCold.Size = New System.Drawing.Size(30, 20)
        Me.txtCold.TabIndex = 17
        '
        'chkDelay
        '
        Me.chkDelay.AutoSize = True
        Me.chkDelay.ForeColor = System.Drawing.Color.MidnightBlue
        Me.chkDelay.Location = New System.Drawing.Point(174, 11)
        Me.chkDelay.Name = "chkDelay"
        Me.chkDelay.Size = New System.Drawing.Size(53, 17)
        Me.chkDelay.TabIndex = 10
        Me.chkDelay.Text = "Delay"
        Me.chkDelay.UseVisualStyleBackColor = True
        '
        'chkCustomClear
        '
        Me.chkCustomClear.AutoSize = True
        Me.chkCustomClear.Location = New System.Drawing.Point(428, 13)
        Me.chkCustomClear.Name = "chkCustomClear"
        Me.chkCustomClear.Size = New System.Drawing.Size(91, 17)
        Me.chkCustomClear.TabIndex = 16
        Me.chkCustomClear.Text = "Custom Clear "
        Me.chkCustomClear.UseVisualStyleBackColor = True
        '
        'dtpDelayDate
        '
        Me.dtpDelayDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDelayDate.Location = New System.Drawing.Point(229, 10)
        Me.dtpDelayDate.Name = "dtpDelayDate"
        Me.dtpDelayDate.Size = New System.Drawing.Size(91, 20)
        Me.dtpDelayDate.TabIndex = 14
        '
        'chkCancel
        '
        Me.chkCancel.AutoSize = True
        Me.chkCancel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.chkCancel.Location = New System.Drawing.Point(363, 13)
        Me.chkCancel.Name = "chkCancel"
        Me.chkCancel.Size = New System.Drawing.Size(59, 17)
        Me.chkCancel.TabIndex = 11
        Me.chkCancel.Text = "Cancel"
        Me.chkCancel.UseVisualStyleBackColor = True
        '
        'cboContainerType
        '
        Me.cboContainerType.FormattingEnabled = True
        Me.cboContainerType.Items.AddRange(New Object() {"20GP", "40GP", "20RF", "40RF", "40HC", "45HC", "40RH", "20OT", "40OT", "20FR", "40FR"})
        Me.cboContainerType.Location = New System.Drawing.Point(313, 166)
        Me.cboContainerType.Name = "cboContainerType"
        Me.cboContainerType.Size = New System.Drawing.Size(60, 21)
        Me.cboContainerType.TabIndex = 3
        '
        'txtWeight
        '
        Me.txtWeight.Enabled = False
        Me.txtWeight.Location = New System.Drawing.Point(84, 193)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(59, 20)
        Me.txtWeight.TabIndex = 12
        Me.txtWeight.Tag = ""
        Me.txtWeight.Text = "0"
        '
        'txtQuantity
        '
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Location = New System.Drawing.Point(198, 194)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(29, 20)
        Me.txtQuantity.TabIndex = 12
        Me.txtQuantity.Text = "0"
        '
        'dtpDateOfSupplyMTContainer
        '
        Me.dtpDateOfSupplyMTContainer.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateOfSupplyMTContainer.Location = New System.Drawing.Point(85, 225)
        Me.dtpDateOfSupplyMTContainer.Name = "dtpDateOfSupplyMTContainer"
        Me.dtpDateOfSupplyMTContainer.Size = New System.Drawing.Size(120, 20)
        Me.dtpDateOfSupplyMTContainer.TabIndex = 6
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdCancel.Location = New System.Drawing.Point(712, 166)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdOk.Location = New System.Drawing.Point(712, 193)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 13
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'chkNull
        '
        Me.chkNull.AutoSize = True
        Me.chkNull.Checked = True
        Me.chkNull.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNull.ForeColor = System.Drawing.Color.MidnightBlue
        Me.chkNull.Location = New System.Drawing.Point(218, 228)
        Me.chkNull.Name = "chkNull"
        Me.chkNull.Size = New System.Drawing.Size(58, 17)
        Me.chkNull.TabIndex = 4
        Me.chkNull.Text = "(None)"
        Me.chkNull.UseVisualStyleBackColor = True
        '
        'txtSeal
        '
        Me.txtSeal.Location = New System.Drawing.Point(313, 194)
        Me.txtSeal.Name = "txtSeal"
        Me.txtSeal.Size = New System.Drawing.Size(60, 20)
        Me.txtSeal.TabIndex = 5
        '
        'txtDateOfSupplyMtContainer
        '
        Me.txtDateOfSupplyMtContainer.Location = New System.Drawing.Point(279, 226)
        Me.txtDateOfSupplyMtContainer.Name = "txtDateOfSupplyMtContainer"
        Me.txtDateOfSupplyMtContainer.Size = New System.Drawing.Size(88, 20)
        Me.txtDateOfSupplyMtContainer.TabIndex = 7
        '
        'cboContainerNo
        '
        Me.cboContainerNo.FormattingEnabled = True
        Me.cboContainerNo.Location = New System.Drawing.Point(84, 168)
        Me.cboContainerNo.Name = "cboContainerNo"
        Me.cboContainerNo.Size = New System.Drawing.Size(144, 21)
        Me.cboContainerNo.TabIndex = 4
        '
        'cboPlaceOfSupplyMTContainer
        '
        Me.cboPlaceOfSupplyMTContainer.FormattingEnabled = True
        Me.cboPlaceOfSupplyMTContainer.Location = New System.Drawing.Point(472, 220)
        Me.cboPlaceOfSupplyMTContainer.Name = "cboPlaceOfSupplyMTContainer"
        Me.cboPlaceOfSupplyMTContainer.Size = New System.Drawing.Size(137, 21)
        Me.cboPlaceOfSupplyMTContainer.TabIndex = 9
        '
        'cboReturnPlace
        '
        Me.cboReturnPlace.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboReturnPlace.FormattingEnabled = True
        Me.cboReturnPlace.Location = New System.Drawing.Point(472, 166)
        Me.cboReturnPlace.Name = "cboReturnPlace"
        Me.cboReturnPlace.Size = New System.Drawing.Size(137, 21)
        Me.cboReturnPlace.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label8.Location = New System.Drawing.Point(34, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Weight :"
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label7.Location = New System.Drawing.Point(374, 215)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(99, 26)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Place Of MT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Container Supply :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label1.Location = New System.Drawing.Point(145, 197)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Quantity :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label6.Location = New System.Drawing.Point(397, 170)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Return Place :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label5.Location = New System.Drawing.Point(277, 197)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Seal :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(6, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Container No :"
        '
        'Label2
        '
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(18, 216)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 48)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Date Of " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Supply MT " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Container :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(226, 170)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Container Type :"
        '
        'dgdAddContainer
        '
        Me.dgdAddContainer.AllowUserToAddRows = False
        Me.dgdAddContainer.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdAddContainer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgdAddContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdAddContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LOADINGPLANFORVESSELID, Me.CTN_ID, Me.BooKingContainerNo, Me.Container_NoAdd, Me.CTN_SIZE_TYPE, Me.Weight, Me.Cold, Me.Vent, Me.SealAdd, Me.DateOfSupplyEmptyContainer, Me.RETURNPLACE, Me.ReturnDate, Me.PLACESUPPLYEMPTYCONTAINER, Me.CustomClear, Me.DelayAdd, Me.DelayDate, Me.CancelAdd, Me.ApproveAdd, Me.EditableAdd, Me.ContinuedAdd, Me.UserIdAdd, Me.UpdatetimeAdd})
        Me.dgdAddContainer.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdAddContainer.Location = New System.Drawing.Point(9, 19)
        Me.dgdAddContainer.Name = "dgdAddContainer"
        Me.dgdAddContainer.ReadOnly = True
        Me.dgdAddContainer.Size = New System.Drawing.Size(1117, 143)
        Me.dgdAddContainer.TabIndex = 0
        '
        'LOADINGPLANFORVESSELID
        '
        Me.LOADINGPLANFORVESSELID.DataPropertyName = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.HeaderText = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.Name = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.ReadOnly = True
        Me.LOADINGPLANFORVESSELID.Visible = False
        '
        'CTN_ID
        '
        Me.CTN_ID.DataPropertyName = "CTN_ID"
        Me.CTN_ID.HeaderText = "CTN_ID"
        Me.CTN_ID.Name = "CTN_ID"
        Me.CTN_ID.ReadOnly = True
        Me.CTN_ID.Visible = False
        '
        'BooKingContainerNo
        '
        Me.BooKingContainerNo.DataPropertyName = "BooKingNo"
        Me.BooKingContainerNo.HeaderText = "BooKing No"
        Me.BooKingContainerNo.Name = "BooKingContainerNo"
        Me.BooKingContainerNo.ReadOnly = True
        '
        'Container_NoAdd
        '
        Me.Container_NoAdd.DataPropertyName = "Container_No"
        Me.Container_NoAdd.HeaderText = "Container No"
        Me.Container_NoAdd.Name = "Container_NoAdd"
        Me.Container_NoAdd.ReadOnly = True
        '
        'CTN_SIZE_TYPE
        '
        Me.CTN_SIZE_TYPE.DataPropertyName = "CTN_SIZE_TYPE"
        Me.CTN_SIZE_TYPE.HeaderText = "Container Type"
        Me.CTN_SIZE_TYPE.Name = "CTN_SIZE_TYPE"
        Me.CTN_SIZE_TYPE.ReadOnly = True
        Me.CTN_SIZE_TYPE.Width = 50
        '
        'Weight
        '
        Me.Weight.DataPropertyName = "Weight"
        Me.Weight.HeaderText = "Weight"
        Me.Weight.Name = "Weight"
        Me.Weight.ReadOnly = True
        '
        'Cold
        '
        Me.Cold.DataPropertyName = "Cold"
        Me.Cold.HeaderText = "Cold"
        Me.Cold.Name = "Cold"
        Me.Cold.ReadOnly = True
        Me.Cold.Width = 50
        '
        'Vent
        '
        Me.Vent.DataPropertyName = "Ventilation"
        Me.Vent.HeaderText = "Ventilation"
        Me.Vent.Name = "Vent"
        Me.Vent.ReadOnly = True
        '
        'SealAdd
        '
        Me.SealAdd.DataPropertyName = "Seal"
        Me.SealAdd.HeaderText = "Seal"
        Me.SealAdd.Name = "SealAdd"
        Me.SealAdd.ReadOnly = True
        Me.SealAdd.Width = 50
        '
        'DateOfSupplyEmptyContainer
        '
        Me.DateOfSupplyEmptyContainer.DataPropertyName = "DateOfSupplyEmptyContainer"
        Me.DateOfSupplyEmptyContainer.HeaderText = "Date Of Supply Empty Container"
        Me.DateOfSupplyEmptyContainer.Name = "DateOfSupplyEmptyContainer"
        Me.DateOfSupplyEmptyContainer.ReadOnly = True
        '
        'RETURNPLACE
        '
        Me.RETURNPLACE.DataPropertyName = "RETURNPLACE"
        Me.RETURNPLACE.HeaderText = "RETURNPLACE"
        Me.RETURNPLACE.Name = "RETURNPLACE"
        Me.RETURNPLACE.ReadOnly = True
        '
        'ReturnDate
        '
        Me.ReturnDate.DataPropertyName = "ReturnDate"
        Me.ReturnDate.HeaderText = "Return Date"
        Me.ReturnDate.Name = "ReturnDate"
        Me.ReturnDate.ReadOnly = True
        '
        'PLACESUPPLYEMPTYCONTAINER
        '
        Me.PLACESUPPLYEMPTYCONTAINER.DataPropertyName = "PLACESUPPLYEMPTYCONTAINER"
        Me.PLACESUPPLYEMPTYCONTAINER.HeaderText = "Place Of Supply Empty Container"
        Me.PLACESUPPLYEMPTYCONTAINER.Name = "PLACESUPPLYEMPTYCONTAINER"
        Me.PLACESUPPLYEMPTYCONTAINER.ReadOnly = True
        '
        'CustomClear
        '
        Me.CustomClear.DataPropertyName = "CustomClear"
        Me.CustomClear.HeaderText = "CustomClear"
        Me.CustomClear.Name = "CustomClear"
        Me.CustomClear.ReadOnly = True
        '
        'DelayAdd
        '
        Me.DelayAdd.DataPropertyName = "Delay"
        Me.DelayAdd.HeaderText = "Delay"
        Me.DelayAdd.Name = "DelayAdd"
        Me.DelayAdd.ReadOnly = True
        Me.DelayAdd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DelayAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DelayAdd.Width = 50
        '
        'DelayDate
        '
        Me.DelayDate.DataPropertyName = "DelayDate"
        Me.DelayDate.HeaderText = "DelayDate"
        Me.DelayDate.Name = "DelayDate"
        Me.DelayDate.ReadOnly = True
        '
        'CancelAdd
        '
        Me.CancelAdd.DataPropertyName = "Cancel"
        Me.CancelAdd.HeaderText = "Cancel"
        Me.CancelAdd.Name = "CancelAdd"
        Me.CancelAdd.ReadOnly = True
        Me.CancelAdd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CancelAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CancelAdd.Width = 50
        '
        'ApproveAdd
        '
        Me.ApproveAdd.DataPropertyName = "Approve"
        Me.ApproveAdd.HeaderText = "Approve"
        Me.ApproveAdd.Name = "ApproveAdd"
        Me.ApproveAdd.ReadOnly = True
        Me.ApproveAdd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApproveAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ApproveAdd.Visible = False
        '
        'EditableAdd
        '
        Me.EditableAdd.DataPropertyName = "Editable"
        Me.EditableAdd.HeaderText = "Editable"
        Me.EditableAdd.Name = "EditableAdd"
        Me.EditableAdd.ReadOnly = True
        Me.EditableAdd.Visible = False
        '
        'ContinuedAdd
        '
        Me.ContinuedAdd.DataPropertyName = "Continued"
        Me.ContinuedAdd.HeaderText = "Continued"
        Me.ContinuedAdd.Name = "ContinuedAdd"
        Me.ContinuedAdd.ReadOnly = True
        Me.ContinuedAdd.Visible = False
        '
        'UserIdAdd
        '
        Me.UserIdAdd.DataPropertyName = "UserId"
        Me.UserIdAdd.HeaderText = "UserID"
        Me.UserIdAdd.Name = "UserIdAdd"
        Me.UserIdAdd.ReadOnly = True
        '
        'UpdatetimeAdd
        '
        Me.UpdatetimeAdd.DataPropertyName = "Updatetime"
        Me.UpdatetimeAdd.HeaderText = "Updatetime"
        Me.UpdatetimeAdd.Name = "UpdatetimeAdd"
        Me.UpdatetimeAdd.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmAdd, Me.ctmEdit, Me.ctmDelete})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(117, 70)
        '
        'ctmAdd
        '
        Me.ctmAdd.Image = CType(resources.GetObject("ctmAdd.Image"), System.Drawing.Image)
        Me.ctmAdd.Name = "ctmAdd"
        Me.ctmAdd.Size = New System.Drawing.Size(116, 22)
        Me.ctmAdd.Text = "Add"
        '
        'ctmEdit
        '
        Me.ctmEdit.Image = CType(resources.GetObject("ctmEdit.Image"), System.Drawing.Image)
        Me.ctmEdit.Name = "ctmEdit"
        Me.ctmEdit.Size = New System.Drawing.Size(116, 22)
        Me.ctmEdit.Text = "Edit"
        '
        'ctmDelete
        '
        Me.ctmDelete.Image = CType(resources.GetObject("ctmDelete.Image"), System.Drawing.Image)
        Me.ctmDelete.Name = "ctmDelete"
        Me.ctmDelete.Size = New System.Drawing.Size(116, 22)
        Me.ctmDelete.Text = "Delete"
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 500000000
        Me.ToolTip1.AutoPopDelay = 500000000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 50
        '
        'dgdDelayInfo
        '
        Me.dgdDelayInfo.AllowUserToAddRows = False
        Me.dgdDelayInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdDelayInfo.BackgroundColor = System.Drawing.Color.SeaGreen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdDelayInfo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdDelayInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdDelayInfo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookingNumber, Me.Container_No, Me.Container_Type, Me.Seal, Me.Delay, Me.DateOfDelay, Me.CanCel})
        Me.dgdDelayInfo.Location = New System.Drawing.Point(0, 0)
        Me.dgdDelayInfo.Name = "dgdDelayInfo"
        Me.dgdDelayInfo.ReadOnly = True
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Navy
        Me.dgdDelayInfo.RowsDefaultCellStyle = DataGridViewCellStyle13
        Me.dgdDelayInfo.Size = New System.Drawing.Size(409, 283)
        Me.dgdDelayInfo.TabIndex = 12
        Me.ToolTip1.SetToolTip(Me.dgdDelayInfo, "Detail Of Container Delay Or Cancel")
        '
        'BookingNumber
        '
        Me.BookingNumber.DataPropertyName = "BookingNo"
        Me.BookingNumber.HeaderText = "Booking No"
        Me.BookingNumber.Name = "BookingNumber"
        Me.BookingNumber.ReadOnly = True
        Me.BookingNumber.Width = 50
        '
        'Container_No
        '
        Me.Container_No.DataPropertyName = "Container_No"
        Me.Container_No.HeaderText = "Container No"
        Me.Container_No.Name = "Container_No"
        Me.Container_No.ReadOnly = True
        '
        'Container_Type
        '
        Me.Container_Type.DataPropertyName = "CTN_SIZE_TYPE"
        Me.Container_Type.HeaderText = "Container type"
        Me.Container_Type.Name = "Container_Type"
        Me.Container_Type.ReadOnly = True
        Me.Container_Type.Width = 50
        '
        'Seal
        '
        Me.Seal.DataPropertyName = "Seal"
        Me.Seal.FillWeight = 50.0!
        Me.Seal.HeaderText = "Seal"
        Me.Seal.Name = "Seal"
        Me.Seal.ReadOnly = True
        Me.Seal.Width = 50
        '
        'Delay
        '
        Me.Delay.DataPropertyName = "Delay"
        Me.Delay.HeaderText = "Delay"
        Me.Delay.Name = "Delay"
        Me.Delay.ReadOnly = True
        Me.Delay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Delay.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Delay.Width = 50
        '
        'DateOfDelay
        '
        Me.DateOfDelay.DataPropertyName = "DelayDate"
        Me.DateOfDelay.HeaderText = "Delay Date"
        Me.DateOfDelay.Name = "DateOfDelay"
        Me.DateOfDelay.ReadOnly = True
        '
        'CanCel
        '
        Me.CanCel.DataPropertyName = "Cancel"
        Me.CanCel.HeaderText = "Cancel"
        Me.CanCel.Name = "CanCel"
        Me.CanCel.ReadOnly = True
        Me.CanCel.Width = 50
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Filter = "(*.xls)|*.xls"
        '
        'panBooking
        '
        Me.panBooking.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panBooking.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panBooking.Controls.Add(Me.SplitContainer1)
        Me.panBooking.Location = New System.Drawing.Point(12, 55)
        Me.panBooking.Name = "panBooking"
        Me.panBooking.Size = New System.Drawing.Size(976, 287)
        Me.panBooking.TabIndex = 9
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.grpSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dgdContianerOutboundNotify)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgdDelayInfo)
        Me.SplitContainer1.Size = New System.Drawing.Size(972, 283)
        Me.SplitContainer1.SplitterDistance = 559
        Me.SplitContainer1.TabIndex = 0
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.txtBookingNoSearch)
        Me.grpSearch.Controls.Add(Me.Label10)
        Me.grpSearch.Controls.Add(Me.cmdCancelSearch)
        Me.grpSearch.Controls.Add(Me.cmdSearch)
        Me.grpSearch.ForeColor = System.Drawing.Color.Maroon
        Me.grpSearch.Location = New System.Drawing.Point(43, 91)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(340, 91)
        Me.grpSearch.TabIndex = 12
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Find Booking No"
        Me.grpSearch.Visible = False
        '
        'txtBookingNoSearch
        '
        Me.txtBookingNoSearch.Location = New System.Drawing.Point(79, 33)
        Me.txtBookingNoSearch.Name = "txtBookingNoSearch"
        Me.txtBookingNoSearch.Size = New System.Drawing.Size(247, 20)
        Me.txtBookingNoSearch.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label10.Location = New System.Drawing.Point(6, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Booking No :"
        '
        'cmdCancelSearch
        '
        Me.cmdCancelSearch.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdCancelSearch.Location = New System.Drawing.Point(170, 59)
        Me.cmdCancelSearch.Name = "cmdCancelSearch"
        Me.cmdCancelSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelSearch.TabIndex = 0
        Me.cmdCancelSearch.Text = "&Cancel"
        Me.cmdCancelSearch.UseVisualStyleBackColor = True
        '
        'cmdSearch
        '
        Me.cmdSearch.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdSearch.Location = New System.Drawing.Point(251, 59)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 0
        Me.cmdSearch.Text = "&Find"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'dgdContianerOutboundNotify
        '
        Me.dgdContianerOutboundNotify.AllowUserToAddRows = False
        Me.dgdContianerOutboundNotify.AllowUserToDeleteRows = False
        Me.dgdContianerOutboundNotify.AllowUserToResizeRows = False
        Me.dgdContianerOutboundNotify.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContianerOutboundNotify.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgdContianerOutboundNotify.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContianerOutboundNotify.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContainerOutBoundNotifyId, Me.SailingScheduleID, Me.BookingNo, Me.TotalContainer, Me.TotalBookingContainer, Me.SupplyOrder, Me.Customer_ID, Me.Company, Me.SoLuong20GP, Me.SoLuong40GP, Me.SoLuong40HC, Me.SoLuong45HC, Me.SoLuong20RF, Me.SoLuong40RF, Me.SoLuong40RH, Me.OT20, Me.OT40, Me.FR20, Me.FR40, Me.BookingVent, Me.BookingCold, Me.Tranship, Me.PortOfUnLoading, Me.Dest, Me.PackingWay, Me.FullReturnContainerPlace, Me.Approve, Me.Continued, Me.Editable, Me.UserId, Me.UpdateTime})
        Me.dgdContianerOutboundNotify.ContextMenuStrip = Me.ctxSearchBookingNoGrid
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdContianerOutboundNotify.DefaultCellStyle = DataGridViewCellStyle20
        Me.dgdContianerOutboundNotify.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdContianerOutboundNotify.Location = New System.Drawing.Point(0, 0)
        Me.dgdContianerOutboundNotify.Name = "dgdContianerOutboundNotify"
        Me.dgdContianerOutboundNotify.ReadOnly = True
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdContianerOutboundNotify.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgdContianerOutboundNotify.Size = New System.Drawing.Size(559, 283)
        Me.dgdContianerOutboundNotify.TabIndex = 11
        '
        'ctxSearchBookingNoGrid
        '
        Me.ctxSearchBookingNoGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmFindBookingNo, Me.PreViewToolStripMenuItem})
        Me.ctxSearchBookingNoGrid.Name = "ctxSearchBookingNoGrid"
        Me.ctxSearchBookingNoGrid.Size = New System.Drawing.Size(162, 48)
        '
        'ctmFindBookingNo
        '
        Me.ctmFindBookingNo.Name = "ctmFindBookingNo"
        Me.ctmFindBookingNo.Size = New System.Drawing.Size(161, 22)
        Me.ctmFindBookingNo.Text = "Find Booking No"
        '
        'PreViewToolStripMenuItem
        '
        Me.PreViewToolStripMenuItem.Name = "PreViewToolStripMenuItem"
        Me.PreViewToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.PreViewToolStripMenuItem.Text = "PreView"
        '
        'ContainerOutBoundNotifyId
        '
        Me.ContainerOutBoundNotifyId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ContainerOutBoundNotifyId.DataPropertyName = "ContainerOutBoundNotifyId"
        Me.ContainerOutBoundNotifyId.HeaderText = "ContainerOutBoundNotifyId"
        Me.ContainerOutBoundNotifyId.Name = "ContainerOutBoundNotifyId"
        Me.ContainerOutBoundNotifyId.ReadOnly = True
        Me.ContainerOutBoundNotifyId.Visible = False
        Me.ContainerOutBoundNotifyId.Width = 186
        '
        'SailingScheduleID
        '
        Me.SailingScheduleID.DataPropertyName = "SailingScheduleID"
        Me.SailingScheduleID.HeaderText = "SailingSchedule Id"
        Me.SailingScheduleID.Name = "SailingScheduleID"
        Me.SailingScheduleID.ReadOnly = True
        Me.SailingScheduleID.Visible = False
        '
        'BookingNo
        '
        Me.BookingNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BookingNo.DataPropertyName = "BookingNo"
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle15.ForeColor = System.Drawing.Color.White
        Me.BookingNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.BookingNo.HeaderText = "BookingNo"
        Me.BookingNo.Name = "BookingNo"
        Me.BookingNo.ReadOnly = True
        Me.BookingNo.ToolTipText = "Số Booking"
        Me.BookingNo.Width = 94
        '
        'TotalContainer
        '
        Me.TotalContainer.DataPropertyName = "TotalContainer"
        Me.TotalContainer.HeaderText = "Total Container"
        Me.TotalContainer.Name = "TotalContainer"
        Me.TotalContainer.ReadOnly = True
        '
        'TotalBookingContainer
        '
        Me.TotalBookingContainer.DataPropertyName = "TotalBookingContainer"
        Me.TotalBookingContainer.HeaderText = "Total Booking Container"
        Me.TotalBookingContainer.Name = "TotalBookingContainer"
        Me.TotalBookingContainer.ReadOnly = True
        '
        'SupplyOrder
        '
        Me.SupplyOrder.DataPropertyName = "SupplyOrder"
        Me.SupplyOrder.HeaderText = "SupplyOrder"
        Me.SupplyOrder.Name = "SupplyOrder"
        Me.SupplyOrder.ReadOnly = True
        Me.SupplyOrder.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SupplyOrder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Customer_ID
        '
        Me.Customer_ID.DataPropertyName = "Customer_ID"
        Me.Customer_ID.HeaderText = "Customer ID"
        Me.Customer_ID.Name = "Customer_ID"
        Me.Customer_ID.ReadOnly = True
        Me.Customer_ID.Visible = False
        '
        'Company
        '
        Me.Company.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Company.DataPropertyName = "Company"
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.White
        Me.Company.DefaultCellStyle = DataGridViewCellStyle16
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        Me.Company.ToolTipText = "Công ty"
        Me.Company.Width = 83
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
        'SoLuong40RH
        '
        Me.SoLuong40RH.DataPropertyName = "SoLuong40RH"
        Me.SoLuong40RH.HeaderText = "40RH"
        Me.SoLuong40RH.Name = "SoLuong40RH"
        Me.SoLuong40RH.ReadOnly = True
        '
        'OT20
        '
        Me.OT20.DataPropertyName = "SoLuong20OT"
        Me.OT20.HeaderText = "20OT"
        Me.OT20.Name = "OT20"
        Me.OT20.ReadOnly = True
        '
        'OT40
        '
        Me.OT40.DataPropertyName = "SoLuong40OT"
        Me.OT40.HeaderText = "40OT"
        Me.OT40.Name = "OT40"
        Me.OT40.ReadOnly = True
        '
        'FR20
        '
        Me.FR20.DataPropertyName = "SoLuong20FR"
        Me.FR20.HeaderText = "20FR"
        Me.FR20.Name = "FR20"
        Me.FR20.ReadOnly = True
        '
        'FR40
        '
        Me.FR40.DataPropertyName = "SoLuong40FR"
        Me.FR40.HeaderText = "40FR"
        Me.FR40.Name = "FR40"
        Me.FR40.ReadOnly = True
        '
        'BookingVent
        '
        Me.BookingVent.DataPropertyName = "Vent"
        Me.BookingVent.HeaderText = "Booking Vent"
        Me.BookingVent.Name = "BookingVent"
        Me.BookingVent.ReadOnly = True
        '
        'BookingCold
        '
        Me.BookingCold.DataPropertyName = "Cold"
        Me.BookingCold.HeaderText = "Booking Cold"
        Me.BookingCold.Name = "BookingCold"
        Me.BookingCold.ReadOnly = True
        '
        'Tranship
        '
        Me.Tranship.DataPropertyName = "Tranship"
        Me.Tranship.HeaderText = "Transit Port"
        Me.Tranship.Name = "Tranship"
        Me.Tranship.ReadOnly = True
        '
        'PortOfUnLoading
        '
        Me.PortOfUnLoading.DataPropertyName = "PortOfUnLoading"
        Me.PortOfUnLoading.HeaderText = "Port Of DisCharge"
        Me.PortOfUnLoading.Name = "PortOfUnLoading"
        Me.PortOfUnLoading.ReadOnly = True
        '
        'Dest
        '
        Me.Dest.DataPropertyName = "Dest"
        Me.Dest.HeaderText = "Dest"
        Me.Dest.Name = "Dest"
        Me.Dest.ReadOnly = True
        '
        'PackingWay
        '
        Me.PackingWay.DataPropertyName = "PackingWay"
        Me.PackingWay.HeaderText = "Stuffing Place"
        Me.PackingWay.Name = "PackingWay"
        Me.PackingWay.ReadOnly = True
        '
        'FullReturnContainerPlace
        '
        Me.FullReturnContainerPlace.DataPropertyName = "FullReturnContainerPlace"
        Me.FullReturnContainerPlace.HeaderText = "Full Container Return Place"
        Me.FullReturnContainerPlace.Name = "FullReturnContainerPlace"
        Me.FullReturnContainerPlace.ReadOnly = True
        '
        'Approve
        '
        Me.Approve.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Approve.DataPropertyName = "Approve"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle17.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle17.NullValue = False
        Me.Approve.DefaultCellStyle = DataGridViewCellStyle17
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.ReadOnly = True
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Approve.ToolTipText = "Duyệt"
        Me.Approve.Width = 79
        '
        'Continued
        '
        Me.Continued.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Visible = False
        Me.Continued.Width = 89
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.ReadOnly = True
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Editable.Visible = False
        Me.Editable.Width = 59
        '
        'UserId
        '
        Me.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle18.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle18
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.ReadOnly = True
        Me.UserId.ToolTipText = "Ngừuơi Cập Nhật"
        Me.UserId.Width = 95
        '
        'UpdateTime
        '
        Me.UpdateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle19.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle19
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        Me.UpdateTime.ToolTipText = "Ngày Cập Nhật"
        Me.UpdateTime.Width = 5
        '
        'frmInputLoadingPlanForVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 578)
        Me.Controls.Add(Me.panBooking)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.lblBookingNo)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtContainerOutboundNotify)
        Me.Controls.Add(Me.cboVesselVoyNoETD)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmInputLoadingPlanForVessel"
        Me.Text = "Loading Plan For Vessel"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdAddContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgdDelayInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panBooking.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        CType(Me.dgdContianerOutboundNotify, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxSearchBookingNoGrid.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuLoadingList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtContainerOutboundNotify As System.Windows.Forms.TextBox
    Friend WithEvents cboVesselVoyNoETD As System.Windows.Forms.ComboBox
    Friend WithEvents lblBookingNo As System.Windows.Forms.Label
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents dgdAddContainer As System.Windows.Forms.DataGridView
    Friend WithEvents chkDelay As System.Windows.Forms.CheckBox
    Friend WithEvents chkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents cboContainerNo As System.Windows.Forms.ComboBox
    Friend WithEvents cboReturnPlace As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtSeal As System.Windows.Forms.TextBox
    Friend WithEvents dtpDateOfSupplyMTContainer As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkNull As System.Windows.Forms.CheckBox
    Friend WithEvents txtDateOfSupplyMtContainer As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboPlaceOfSupplyMTContainer As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboContainerType As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents mnuExportLoadingPlan As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpDelayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents panBooking As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgdDelayInfo As System.Windows.Forms.DataGridView
    Friend WithEvents BookingNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Delay As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DateOfDelay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CanCel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dgdContianerOutboundNotify As System.Windows.Forms.DataGridView
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LoadingFormForPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoadingFormForShangHaiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkCustomClear As System.Windows.Forms.CheckBox
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtBookingNoSearch As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelSearch As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents ctxSearchBookingNoGrid As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmFindBookingNo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVent As System.Windows.Forms.TextBox
    Friend WithEvents txtCold As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LOADINGPLANFORVESSELID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BooKingContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_NoAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_SIZE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SealAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfSupplyEmptyContainer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RETURNPLACE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReturnDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLACESUPPLYEMPTYCONTAINER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomClear As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DelayAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DelayDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CancelAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ApproveAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EditableAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContinuedAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIdAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatetimeAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtReturnDate As System.Windows.Forms.TextBox
    Friend WithEvents chkNull2 As System.Windows.Forms.CheckBox
    Friend WithEvents InputDataLoadingFormForPortToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuLoadingCheck As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContainerOutBoundNotifyId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalContainer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalBookingContainer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplyOrder As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Customer_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OT20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OT40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingVent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingCold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tranship As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PortOfUnLoading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Dest As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PackingWay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FullReturnContainerPlace As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
