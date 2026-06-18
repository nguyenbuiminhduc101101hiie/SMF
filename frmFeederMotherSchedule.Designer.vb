<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeederMotherSchedule
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgdFeeder = New System.Windows.Forms.DataGridView
        Me.SailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeederVessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeederVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeederService = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeederETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeederETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdMother = New System.Windows.Forms.DataGridView
        Me.MotherSailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotherVessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotherVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotherService = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotherETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgdFeederMotherData = New System.Windows.Forms.DataGridView
        Me.CatchFeederVessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FeederID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MotherID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatchFeederVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatchFeederETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatchFeederETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatchMotherVessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CatchMotherVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cmdSave = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cboFeederService = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMotherService = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdnew = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmdLoad = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.cmdExportExcelSchedule = New System.Windows.Forms.Button
        Me.txtPICInfo = New System.Windows.Forms.TextBox
        Me.txtPortCode = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.lblPortCode = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblDate = New System.Windows.Forms.Label
        Me.lblName = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgdReview = New System.Windows.Forms.DataGridView
        Me.VesselName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VOYNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETDHCM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CONNECTINGVESSEL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ConnectingVoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETDMother = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdFeeder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.dgdMother, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdFeederMotherData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgdReview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgdFeeder
        '
        Me.dgdFeeder.AllowUserToAddRows = False
        Me.dgdFeeder.AllowUserToDeleteRows = False
        Me.dgdFeeder.AllowUserToOrderColumns = True
        Me.dgdFeeder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdFeeder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdFeeder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SailingScheduleID, Me.FeederVessel, Me.FeederVoyNo, Me.FeederService, Me.FeederETA, Me.FeederETD})
        Me.dgdFeeder.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdFeeder.Location = New System.Drawing.Point(3, 80)
        Me.dgdFeeder.Name = "dgdFeeder"
        Me.dgdFeeder.ReadOnly = True
        Me.dgdFeeder.Size = New System.Drawing.Size(431, 227)
        Me.dgdFeeder.TabIndex = 0
        '
        'SailingScheduleID
        '
        Me.SailingScheduleID.DataPropertyName = "SailingScheduleID"
        Me.SailingScheduleID.HeaderText = "SailingScheduleID"
        Me.SailingScheduleID.Name = "SailingScheduleID"
        Me.SailingScheduleID.ReadOnly = True
        Me.SailingScheduleID.Visible = False
        '
        'FeederVessel
        '
        Me.FeederVessel.DataPropertyName = "FeederVessel"
        Me.FeederVessel.HeaderText = "Feeder Vessel"
        Me.FeederVessel.Name = "FeederVessel"
        Me.FeederVessel.ReadOnly = True
        '
        'FeederVoyNo
        '
        Me.FeederVoyNo.DataPropertyName = "FeederVoyNo"
        Me.FeederVoyNo.HeaderText = "Feeder VoyNo"
        Me.FeederVoyNo.Name = "FeederVoyNo"
        Me.FeederVoyNo.ReadOnly = True
        '
        'FeederService
        '
        Me.FeederService.DataPropertyName = "FeederService"
        Me.FeederService.HeaderText = "Feeder Service"
        Me.FeederService.Name = "FeederService"
        Me.FeederService.ReadOnly = True
        '
        'FeederETA
        '
        Me.FeederETA.DataPropertyName = "FeederETA"
        Me.FeederETA.HeaderText = "Feeder ETA"
        Me.FeederETA.Name = "FeederETA"
        Me.FeederETA.ReadOnly = True
        '
        'FeederETD
        '
        Me.FeederETD.DataPropertyName = "FeederETD"
        Me.FeederETD.HeaderText = "Feeder ETD"
        Me.FeederETD.Name = "FeederETD"
        Me.FeederETD.ReadOnly = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmAdd})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(105, 26)
        '
        'ctmAdd
        '
        Me.ctmAdd.Name = "ctmAdd"
        Me.ctmAdd.Size = New System.Drawing.Size(104, 22)
        Me.ctmAdd.Text = "Add"
        '
        'dgdMother
        '
        Me.dgdMother.AllowUserToAddRows = False
        Me.dgdMother.AllowUserToDeleteRows = False
        Me.dgdMother.AllowUserToOrderColumns = True
        Me.dgdMother.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdMother.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdMother.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.MotherSailingScheduleID, Me.MotherVessel, Me.MotherVoyNo, Me.MotherService, Me.MotherETD})
        Me.dgdMother.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdMother.Location = New System.Drawing.Point(434, 80)
        Me.dgdMother.Name = "dgdMother"
        Me.dgdMother.ReadOnly = True
        Me.dgdMother.Size = New System.Drawing.Size(388, 227)
        Me.dgdMother.TabIndex = 0
        '
        'MotherSailingScheduleID
        '
        Me.MotherSailingScheduleID.DataPropertyName = "MotherSailingScheduleID"
        Me.MotherSailingScheduleID.HeaderText = "MotherSailingScheduleID"
        Me.MotherSailingScheduleID.Name = "MotherSailingScheduleID"
        Me.MotherSailingScheduleID.ReadOnly = True
        Me.MotherSailingScheduleID.Visible = False
        '
        'MotherVessel
        '
        Me.MotherVessel.DataPropertyName = "MotherVessel"
        Me.MotherVessel.HeaderText = "Mother Vessel"
        Me.MotherVessel.Name = "MotherVessel"
        Me.MotherVessel.ReadOnly = True
        '
        'MotherVoyNo
        '
        Me.MotherVoyNo.DataPropertyName = "MotherVoyNo"
        Me.MotherVoyNo.HeaderText = "Mother VoyNo"
        Me.MotherVoyNo.Name = "MotherVoyNo"
        Me.MotherVoyNo.ReadOnly = True
        '
        'MotherService
        '
        Me.MotherService.DataPropertyName = "MotherService"
        Me.MotherService.HeaderText = "Mother Service"
        Me.MotherService.Name = "MotherService"
        Me.MotherService.ReadOnly = True
        '
        'MotherETD
        '
        Me.MotherETD.DataPropertyName = "MotherETD"
        Me.MotherETD.HeaderText = "Mother ETD"
        Me.MotherETD.Name = "MotherETD"
        Me.MotherETD.ReadOnly = True
        '
        'dgdFeederMotherData
        '
        Me.dgdFeederMotherData.AllowUserToAddRows = False
        Me.dgdFeederMotherData.AllowUserToDeleteRows = False
        Me.dgdFeederMotherData.AllowUserToOrderColumns = True
        Me.dgdFeederMotherData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdFeederMotherData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdFeederMotherData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CatchFeederVessel, Me.FeederID, Me.MotherID, Me.CatchFeederVoyNo, Me.CatchFeederETA, Me.CatchFeederETD, Me.CatchMotherVessel, Me.CatchMotherVoyNo})
        Me.dgdFeederMotherData.ContextMenuStrip = Me.ContextMenuStrip2
        Me.dgdFeederMotherData.Location = New System.Drawing.Point(3, 338)
        Me.dgdFeederMotherData.Name = "dgdFeederMotherData"
        Me.dgdFeederMotherData.ReadOnly = True
        Me.dgdFeederMotherData.Size = New System.Drawing.Size(814, 187)
        Me.dgdFeederMotherData.TabIndex = 1
        '
        'CatchFeederVessel
        '
        Me.CatchFeederVessel.HeaderText = "Feeder Name"
        Me.CatchFeederVessel.Name = "CatchFeederVessel"
        Me.CatchFeederVessel.ReadOnly = True
        '
        'FeederID
        '
        Me.FeederID.HeaderText = "FeederID"
        Me.FeederID.Name = "FeederID"
        Me.FeederID.ReadOnly = True
        Me.FeederID.Visible = False
        '
        'MotherID
        '
        Me.MotherID.HeaderText = "MotherID"
        Me.MotherID.Name = "MotherID"
        Me.MotherID.ReadOnly = True
        Me.MotherID.Visible = False
        '
        'CatchFeederVoyNo
        '
        Me.CatchFeederVoyNo.HeaderText = "Feeder VoyNo"
        Me.CatchFeederVoyNo.Name = "CatchFeederVoyNo"
        Me.CatchFeederVoyNo.ReadOnly = True
        '
        'CatchFeederETA
        '
        Me.CatchFeederETA.DataPropertyName = "FeederETA"
        Me.CatchFeederETA.HeaderText = "Feeder ETA"
        Me.CatchFeederETA.Name = "CatchFeederETA"
        Me.CatchFeederETA.ReadOnly = True
        '
        'CatchFeederETD
        '
        Me.CatchFeederETD.DataPropertyName = "FeederETD"
        Me.CatchFeederETD.HeaderText = "Feeder ETD"
        Me.CatchFeederETD.Name = "CatchFeederETD"
        Me.CatchFeederETD.ReadOnly = True
        '
        'CatchMotherVessel
        '
        Me.CatchMotherVessel.HeaderText = "Mother Vessel"
        Me.CatchMotherVessel.Name = "CatchMotherVessel"
        Me.CatchMotherVessel.ReadOnly = True
        '
        'CatchMotherVoyNo
        '
        Me.CatchMotherVoyNo.HeaderText = "Mother VoyNo"
        Me.CatchMotherVoyNo.Name = "CatchMotherVoyNo"
        Me.CatchMotherVoyNo.ReadOnly = True
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(117, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportExcel.Location = New System.Drawing.Point(743, 309)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 4
        Me.cmdExportExcel.Text = "&Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdSave
        '
        Me.cmdSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSave.Location = New System.Drawing.Point(578, 309)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(75, 23)
        Me.cmdSave.TabIndex = 5
        Me.cmdSave.Text = "&Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(500, 309)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(72, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cboFeederService
        '
        Me.cboFeederService.FormattingEnabled = True
        Me.cboFeederService.Location = New System.Drawing.Point(97, 17)
        Me.cboFeederService.Name = "cboFeederService"
        Me.cboFeederService.Size = New System.Drawing.Size(89, 21)
        Me.cboFeederService.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Feeder Service :"
        '
        'cboMotherService
        '
        Me.cboMotherService.FormattingEnabled = True
        Me.cboMotherService.Location = New System.Drawing.Point(672, 17)
        Me.cboMotherService.Name = "cboMotherService"
        Me.cboMotherService.Size = New System.Drawing.Size(90, 21)
        Me.cboMotherService.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(586, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Mother Service :"
        '
        'cmdnew
        '
        Me.cmdnew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdnew.Location = New System.Drawing.Point(422, 309)
        Me.cmdnew.Name = "cmdnew"
        Me.cmdnew.Size = New System.Drawing.Size(72, 23)
        Me.cmdnew.TabIndex = 6
        Me.cmdnew.Text = "&New"
        Me.cmdnew.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.cmdLoad)
        Me.GroupBox1.Controls.Add(Me.cmdExportExcel)
        Me.GroupBox1.Controls.Add(Me.cmdnew)
        Me.GroupBox1.Controls.Add(Me.cmdSave)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.dgdFeederMotherData)
        Me.GroupBox1.Controls.Add(Me.dgdMother)
        Me.GroupBox1.Controls.Add(Me.dgdFeeder)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(842, 566)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Schedule"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboMotherService)
        Me.GroupBox2.Controls.Add(Me.cboFeederService)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(813, 46)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter"
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(411, 18)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePicker2.TabIndex = 10
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(257, 18)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(90, 20)
        Me.DateTimePicker1.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(192, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "From(ETD) :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(353, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "To (ETD) :"
        '
        'cmdLoad
        '
        Me.cmdLoad.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLoad.Location = New System.Drawing.Point(659, 309)
        Me.cmdLoad.Name = "cmdLoad"
        Me.cmdLoad.Size = New System.Drawing.Size(75, 23)
        Me.cmdLoad.TabIndex = 11
        Me.cmdLoad.Text = "Load"
        Me.cmdLoad.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(856, 598)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(848, 572)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Schedule Info"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.AutoScroll = True
        Me.TabPage2.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.TabPage2.Controls.Add(Me.cmdExportExcelSchedule)
        Me.TabPage2.Controls.Add(Me.txtPICInfo)
        Me.TabPage2.Controls.Add(Me.txtPortCode)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.lblPortCode)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.lblDate)
        Me.TabPage2.Controls.Add(Me.lblName)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.dgdReview)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(848, 572)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Review schedule"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmdExportExcelSchedule
        '
        Me.cmdExportExcelSchedule.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportExcelSchedule.BackColor = System.Drawing.Color.MistyRose
        Me.cmdExportExcelSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue
        Me.cmdExportExcelSchedule.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportExcelSchedule.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdExportExcelSchedule.Location = New System.Drawing.Point(431, 6)
        Me.cmdExportExcelSchedule.Name = "cmdExportExcelSchedule"
        Me.cmdExportExcelSchedule.Size = New System.Drawing.Size(114, 25)
        Me.cmdExportExcelSchedule.TabIndex = 9
        Me.cmdExportExcelSchedule.Text = "Export Excel"
        Me.cmdExportExcelSchedule.UseVisualStyleBackColor = False
        '
        'txtPICInfo
        '
        Me.txtPICInfo.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPICInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPICInfo.Location = New System.Drawing.Point(15, 492)
        Me.txtPICInfo.Multiline = True
        Me.txtPICInfo.Name = "txtPICInfo"
        Me.txtPICInfo.ReadOnly = True
        Me.txtPICInfo.Size = New System.Drawing.Size(774, 86)
        Me.txtPICInfo.TabIndex = 8
        '
        'txtPortCode
        '
        Me.txtPortCode.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtPortCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPortCode.Location = New System.Drawing.Point(110, 409)
        Me.txtPortCode.Multiline = True
        Me.txtPortCode.Name = "txtPortCode"
        Me.txtPortCode.ReadOnly = True
        Me.txtPortCode.Size = New System.Drawing.Size(719, 61)
        Me.txtPortCode.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 473)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(354, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "For further information, please contact our marketing team :"
        '
        'lblPortCode
        '
        Me.lblPortCode.AutoSize = True
        Me.lblPortCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPortCode.Location = New System.Drawing.Point(12, 409)
        Me.lblPortCode.Name = "lblPortCode"
        Me.lblPortCode.Size = New System.Drawing.Size(92, 16)
        Me.lblPortCode.TabIndex = 5
        Me.lblPortCode.Text = "PORT CODE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(7, 389)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(439, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "The above shedule is subject to changes with or without prior notice."
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, CType((System.Drawing.FontStyle.Italic Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(624, 48)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(64, 25)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Date :"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Arial", 15.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Blue
        Me.lblName.Location = New System.Drawing.Point(6, 49)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(461, 24)
        Me.lblName.TabIndex = 2
        Me.lblName.Text = "HO CHI MINH TO USNYC -  MBL SERVICE - AAS"
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label6.Font = New System.Drawing.Font("Arial", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Coral
        Me.Label6.Location = New System.Drawing.Point(3, 3)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(826, 46)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "WEEKLY SAILING SCHEDULE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgdReview
        '
        Me.dgdReview.AllowUserToAddRows = False
        Me.dgdReview.AllowUserToDeleteRows = False
        Me.dgdReview.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dgdReview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgdReview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal
        Me.dgdReview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdReview.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdReview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdReview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.VesselName, Me.VOYNO, Me.ETDHCM, Me.CONNECTINGVESSEL, Me.ConnectingVoyNo, Me.ETDMother})
        Me.dgdReview.Location = New System.Drawing.Point(6, 78)
        Me.dgdReview.Name = "dgdReview"
        Me.dgdReview.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdReview.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdReview.Size = New System.Drawing.Size(823, 308)
        Me.dgdReview.TabIndex = 0
        '
        'VesselName
        '
        Me.VesselName.HeaderText = "VESSEL NAME"
        Me.VesselName.Name = "VesselName"
        Me.VesselName.ReadOnly = True
        Me.VesselName.Width = 150
        '
        'VOYNO
        '
        Me.VOYNO.HeaderText = "VOY NO."
        Me.VOYNO.Name = "VOYNO"
        Me.VOYNO.ReadOnly = True
        '
        'ETDHCM
        '
        Me.ETDHCM.HeaderText = " ETD (HCM)"
        Me.ETDHCM.Name = "ETDHCM"
        Me.ETDHCM.ReadOnly = True
        '
        'CONNECTINGVESSEL
        '
        Me.CONNECTINGVESSEL.HeaderText = "CONNECTING VESSEL"
        Me.CONNECTINGVESSEL.Name = "CONNECTINGVESSEL"
        Me.CONNECTINGVESSEL.ReadOnly = True
        Me.CONNECTINGVESSEL.Width = 200
        '
        'ConnectingVoyNo
        '
        Me.ConnectingVoyNo.HeaderText = "Voy No."
        Me.ConnectingVoyNo.Name = "ConnectingVoyNo"
        Me.ConnectingVoyNo.ReadOnly = True
        '
        'ETDMother
        '
        Me.ETDMother.HeaderText = "ETD ()"
        Me.ETDMother.Name = "ETDMother"
        Me.ETDMother.ReadOnly = True
        '
        'frmFeederMotherSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 612)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmFeederMotherSchedule"
        Me.Text = "Feeder & mother Schedule"
        CType(Me.dgdFeeder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.dgdMother, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdFeederMotherData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgdReview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgdFeeder As System.Windows.Forms.DataGridView
    Friend WithEvents dgdMother As System.Windows.Forms.DataGridView
    Friend WithEvents dgdFeederMotherData As System.Windows.Forms.DataGridView
    Friend WithEvents MotherSailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotherVessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotherVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotherService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotherETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeederVessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeederVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeederService As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeederETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeederETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboFeederService As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMotherService As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdnew As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgdReview As System.Windows.Forms.DataGridView
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblPortCode As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPICInfo As System.Windows.Forms.TextBox
    Friend WithEvents txtPortCode As System.Windows.Forms.TextBox
    Friend WithEvents VesselName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VOYNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDHCM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CONNECTINGVESSEL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ConnectingVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDMother As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExportExcelSchedule As System.Windows.Forms.Button
    Friend WithEvents CatchFeederVessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FeederID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MotherID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatchFeederVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatchFeederETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatchFeederETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatchMotherVessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CatchMotherVoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
