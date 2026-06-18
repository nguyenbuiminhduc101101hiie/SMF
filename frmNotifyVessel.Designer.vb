<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotifyVessel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayName = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayCode = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayETA = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayETD = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayETB = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayBTH = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayNote = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayCommodity = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayremarks = New System.Windows.Forms.ToolStripMenuItem
        Me.smnudisplayApprove = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUserId = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDisplayUpdateTime = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.cboVesselCode = New System.Windows.Forms.ComboBox
        Me.dtpETA = New System.Windows.Forms.DateTimePicker
        Me.dtpETB = New System.Windows.Forms.DateTimePicker
        Me.dtpBTH = New System.Windows.Forms.DateTimePicker
        Me.dtpETD = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblCode = New System.Windows.Forms.Label
        Me.txtVoyNo = New System.Windows.Forms.TextBox
        Me.txtVesselName = New System.Windows.Forms.TextBox
        Me.lblRemarks = New System.Windows.Forms.Label
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.dgdVessel = New System.Windows.Forms.DataGridView
        Me.notifyVesselId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesselName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BTH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Commodity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdFind = New System.Windows.Forms.Button
        Me.txtVessel = New System.Windows.Forms.TextBox
        Me.cboFind = New System.Windows.Forms.ComboBox
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuDisplay, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(709, 24)
        Me.MenuStrip.TabIndex = 0
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(40, 20)
        Me.smnuAdd.Text = "&New"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'smnuDisplay
        '
        Me.smnuDisplay.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuDisplayName, Me.smnuDisplayCode, Me.smnuDisplayETA, Me.smnuDisplayETD, Me.smnuDisplayETB, Me.smnuDisplayBTH, Me.smnuDisplayNote, Me.smnuDisplayCommodity, Me.smnuDisplayremarks, Me.smnudisplayApprove, Me.smnuDisplayUserId, Me.smnuDisplayUpdateTime})
        Me.smnuDisplay.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDisplay.Name = "smnuDisplay"
        Me.smnuDisplay.Size = New System.Drawing.Size(41, 20)
        Me.smnuDisplay.Text = "&View"
        '
        'smnuDisplayName
        '
        Me.smnuDisplayName.Name = "smnuDisplayName"
        Me.smnuDisplayName.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayName.Text = "Vessel &Name"
        '
        'smnuDisplayCode
        '
        Me.smnuDisplayCode.Name = "smnuDisplayCode"
        Me.smnuDisplayCode.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayCode.Text = "Vessel C&ode"
        '
        'smnuDisplayETA
        '
        Me.smnuDisplayETA.Name = "smnuDisplayETA"
        Me.smnuDisplayETA.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayETA.Text = "ETA"
        '
        'smnuDisplayETD
        '
        Me.smnuDisplayETD.Name = "smnuDisplayETD"
        Me.smnuDisplayETD.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayETD.Text = "ETD"
        '
        'smnuDisplayETB
        '
        Me.smnuDisplayETB.Name = "smnuDisplayETB"
        Me.smnuDisplayETB.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayETB.Text = "ETB"
        Me.smnuDisplayETB.Visible = False
        '
        'smnuDisplayBTH
        '
        Me.smnuDisplayBTH.Name = "smnuDisplayBTH"
        Me.smnuDisplayBTH.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayBTH.Text = "BTH"
        Me.smnuDisplayBTH.Visible = False
        '
        'smnuDisplayNote
        '
        Me.smnuDisplayNote.Name = "smnuDisplayNote"
        Me.smnuDisplayNote.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayNote.Text = "Note"
        '
        'smnuDisplayCommodity
        '
        Me.smnuDisplayCommodity.Name = "smnuDisplayCommodity"
        Me.smnuDisplayCommodity.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayCommodity.Text = "Commodity"
        '
        'smnuDisplayremarks
        '
        Me.smnuDisplayremarks.Name = "smnuDisplayremarks"
        Me.smnuDisplayremarks.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayremarks.Text = "Remarks"
        '
        'smnudisplayApprove
        '
        Me.smnudisplayApprove.Name = "smnudisplayApprove"
        Me.smnudisplayApprove.Size = New System.Drawing.Size(146, 22)
        Me.smnudisplayApprove.Text = "Approve"
        '
        'smnuDisplayUserId
        '
        Me.smnuDisplayUserId.Name = "smnuDisplayUserId"
        Me.smnuDisplayUserId.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayUserId.Text = "Us&er Update"
        '
        'smnuDisplayUpdateTime
        '
        Me.smnuDisplayUpdateTime.Name = "smnuDisplayUpdateTime"
        Me.smnuDisplayUpdateTime.Size = New System.Drawing.Size(146, 22)
        Me.smnuDisplayUpdateTime.Text = "Date &Update"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.cboVesselCode)
        Me.fraUpdate.Controls.Add(Me.dtpETA)
        Me.fraUpdate.Controls.Add(Me.dtpETB)
        Me.fraUpdate.Controls.Add(Me.dtpBTH)
        Me.fraUpdate.Controls.Add(Me.dtpETD)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.lblCode)
        Me.fraUpdate.Controls.Add(Me.txtVoyNo)
        Me.fraUpdate.Controls.Add(Me.txtVesselName)
        Me.fraUpdate.Controls.Add(Me.lblRemarks)
        Me.fraUpdate.Controls.Add(Me.txtRemarks)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.Controls.Add(Me.txtNote)
        Me.fraUpdate.Controls.Add(Me.lblName)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 265)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(442, 200)
        Me.fraUpdate.TabIndex = 5
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        Me.fraUpdate.Visible = False
        '
        'cboVesselCode
        '
        Me.cboVesselCode.FormattingEnabled = True
        Me.cboVesselCode.Location = New System.Drawing.Point(106, 28)
        Me.cboVesselCode.Name = "cboVesselCode"
        Me.cboVesselCode.Size = New System.Drawing.Size(138, 21)
        Me.cboVesselCode.TabIndex = 20
        '
        'dtpETA
        '
        Me.dtpETA.CalendarForeColor = System.Drawing.SystemColors.WindowText
        Me.dtpETA.CalendarMonthBackground = System.Drawing.Color.White
        Me.dtpETA.CalendarTitleForeColor = System.Drawing.SystemColors.Desktop
        Me.dtpETA.CalendarTrailingForeColor = System.Drawing.SystemColors.Control
        Me.dtpETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETA.Location = New System.Drawing.Point(293, 28)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(117, 20)
        Me.dtpETA.TabIndex = 3
        '
        'dtpETB
        '
        Me.dtpETB.CalendarForeColor = System.Drawing.Color.Black
        Me.dtpETB.CalendarTitleForeColor = System.Drawing.Color.Blue
        Me.dtpETB.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETB.Location = New System.Drawing.Point(729, 19)
        Me.dtpETB.Name = "dtpETB"
        Me.dtpETB.Size = New System.Drawing.Size(87, 20)
        Me.dtpETB.TabIndex = 4
        Me.dtpETB.Visible = False
        '
        'dtpBTH
        '
        Me.dtpBTH.CalendarTitleForeColor = System.Drawing.Color.Blue
        Me.dtpBTH.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBTH.Location = New System.Drawing.Point(729, 50)
        Me.dtpBTH.Name = "dtpBTH"
        Me.dtpBTH.Size = New System.Drawing.Size(87, 20)
        Me.dtpBTH.TabIndex = 9
        Me.dtpBTH.Visible = False
        '
        'dtpETD
        '
        Me.dtpETD.CalendarTitleForeColor = System.Drawing.Color.Blue
        Me.dtpETD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpETD.Location = New System.Drawing.Point(293, 54)
        Me.dtpETD.Name = "dtpETD"
        Me.dtpETD.Size = New System.Drawing.Size(117, 20)
        Me.dtpETD.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(256, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Note :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(694, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "BTH:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label5.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(257, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "ETD :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(695, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "ETB:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(257, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "ETA :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(59, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "VoyNo :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCode
        '
        Me.lblCode.AutoSize = True
        Me.lblCode.ForeColor = System.Drawing.Color.Blue
        Me.lblCode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCode.Location = New System.Drawing.Point(32, 32)
        Me.lblCode.Name = "lblCode"
        Me.lblCode.Size = New System.Drawing.Size(72, 13)
        Me.lblCode.TabIndex = 0
        Me.lblCode.Text = "Vessel Code :"
        Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtVoyNo
        '
        Me.txtVoyNo.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtVoyNo.ForeColor = System.Drawing.Color.Blue
        Me.txtVoyNo.Location = New System.Drawing.Point(106, 80)
        Me.txtVoyNo.Name = "txtVoyNo"
        Me.txtVoyNo.Size = New System.Drawing.Size(138, 21)
        Me.txtVoyNo.TabIndex = 1
        '
        'txtVesselName
        '
        Me.txtVesselName.Enabled = False
        Me.txtVesselName.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txtVesselName.ForeColor = System.Drawing.Color.Blue
        Me.txtVesselName.Location = New System.Drawing.Point(106, 54)
        Me.txtVesselName.Name = "txtVesselName"
        Me.txtVesselName.Size = New System.Drawing.Size(138, 21)
        Me.txtVesselName.TabIndex = 1
        '
        'lblRemarks
        '
        Me.lblRemarks.AutoSize = True
        Me.lblRemarks.ForeColor = System.Drawing.Color.Blue
        Me.lblRemarks.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblRemarks.Location = New System.Drawing.Point(49, 112)
        Me.lblRemarks.Name = "lblRemarks"
        Me.lblRemarks.Size = New System.Drawing.Size(55, 13)
        Me.lblRemarks.TabIndex = 14
        Me.lblRemarks.Text = "Remarks :"
        Me.lblRemarks.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRemarks
        '
        Me.txtRemarks.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtRemarks.ForeColor = System.Drawing.Color.Blue
        Me.txtRemarks.Location = New System.Drawing.Point(106, 109)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(304, 50)
        Me.txtRemarks.TabIndex = 6
        '
        'cmdCancel
        '
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(250, 165)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 19
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(333, 165)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 18
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtNote.ForeColor = System.Drawing.Color.Blue
        Me.txtNote.Location = New System.Drawing.Point(293, 79)
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(117, 20)
        Me.txtNote.TabIndex = 7
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.ForeColor = System.Drawing.Color.Blue
        Me.lblName.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblName.Location = New System.Drawing.Point(29, 58)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(75, 13)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "Vessel Name :"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgdVessel
        '
        Me.dgdVessel.AllowUserToAddRows = False
        Me.dgdVessel.AllowUserToDeleteRows = False
        Me.dgdVessel.AllowUserToResizeRows = False
        Me.dgdVessel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdVessel.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdVessel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdVessel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVessel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.notifyVesselId, Me.Vessel_ID, Me.Code, Me.VesselName, Me.VoyNo, Me.ETA, Me.ETB, Me.ETD, Me.BTH, Me.Note, Me.Commodity, Me.Remarks, Me.Approve, Me.Continued, Me.Editable, Me.UserId, Me.UpdateTime})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdVessel.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgdVessel.Location = New System.Drawing.Point(12, 58)
        Me.dgdVessel.Name = "dgdVessel"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdVessel.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgdVessel.Size = New System.Drawing.Size(685, 201)
        Me.dgdVessel.TabIndex = 3
        '
        'notifyVesselId
        '
        Me.notifyVesselId.DataPropertyName = "notifyVesselId"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.notifyVesselId.DefaultCellStyle = DataGridViewCellStyle2
        Me.notifyVesselId.HeaderText = "NotifyVesselId"
        Me.notifyVesselId.Name = "notifyVesselId"
        Me.notifyVesselId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.notifyVesselId.Visible = False
        Me.notifyVesselId.Width = 67
        '
        'Vessel_ID
        '
        Me.Vessel_ID.DataPropertyName = "Vessel_ID"
        Me.Vessel_ID.HeaderText = "Vessel_ID"
        Me.Vessel_ID.Name = "Vessel_ID"
        Me.Vessel_ID.Visible = False
        '
        'Code
        '
        Me.Code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Code.DataPropertyName = "Vessel_Code"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        Me.Code.DefaultCellStyle = DataGridViewCellStyle3
        Me.Code.HeaderText = "Vessel Code"
        Me.Code.Name = "Code"
        Me.Code.Width = 94
        '
        'VesselName
        '
        Me.VesselName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.VesselName.DataPropertyName = "Vessel"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        Me.VesselName.DefaultCellStyle = DataGridViewCellStyle4
        Me.VesselName.HeaderText = "VesselName"
        Me.VesselName.Name = "VesselName"
        Me.VesselName.Width = 101
        '
        'VoyNo
        '
        Me.VoyNo.DataPropertyName = "VoyNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        Me.VoyNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.VoyNo.HeaderText = "VoyNo"
        Me.VoyNo.Name = "VoyNo"
        '
        'ETA
        '
        Me.ETA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ETA.DataPropertyName = "ETA"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ETA.DefaultCellStyle = DataGridViewCellStyle6
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        Me.ETA.Width = 56
        '
        'ETB
        '
        Me.ETB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ETB.DataPropertyName = "ETB"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Format = "d"
        Me.ETB.DefaultCellStyle = DataGridViewCellStyle7
        Me.ETB.HeaderText = "ETB"
        Me.ETB.Name = "ETB"
        Me.ETB.Visible = False
        '
        'ETD
        '
        Me.ETD.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ETD.DataPropertyName = "ETD"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Format = "d"
        Me.ETD.DefaultCellStyle = DataGridViewCellStyle8
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        Me.ETD.Width = 57
        '
        'BTH
        '
        Me.BTH.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BTH.DataPropertyName = "BTH"
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle9.Format = "d"
        Me.BTH.DefaultCellStyle = DataGridViewCellStyle9
        Me.BTH.HeaderText = "BTH"
        Me.BTH.Name = "BTH"
        Me.BTH.Visible = False
        '
        'Note
        '
        Me.Note.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Note.DataPropertyName = "Note"
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        Me.Note.DefaultCellStyle = DataGridViewCellStyle10
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.Width = 59
        '
        'Commodity
        '
        Me.Commodity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Commodity.DataPropertyName = "Commodity"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.White
        Me.Commodity.DefaultCellStyle = DataGridViewCellStyle11
        Me.Commodity.HeaderText = "Commodity"
        Me.Commodity.Name = "Commodity"
        Me.Commodity.Width = 92
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.White
        Me.Remarks.DefaultCellStyle = DataGridViewCellStyle12
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Width = 81
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Visible = False
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.Visible = False
        '
        'UserId
        '
        Me.UserId.DataPropertyName = "UserId"
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        Me.UserId.DefaultCellStyle = DataGridViewCellStyle13
        Me.UserId.HeaderText = "User Update"
        Me.UserId.Name = "UserId"
        Me.UserId.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.UserId.Width = 76
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        Me.UpdateTime.DefaultCellStyle = DataGridViewCellStyle14
        Me.UpdateTime.HeaderText = "Date Update"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.Width = 96
        '
        'cmdFind
        '
        Me.cmdFind.ForeColor = System.Drawing.Color.Blue
        Me.cmdFind.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdFind.Location = New System.Drawing.Point(624, 28)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(77, 21)
        Me.cmdFind.TabIndex = 2
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'txtVessel
        '
        Me.txtVessel.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtVessel.Location = New System.Drawing.Point(137, 27)
        Me.txtVessel.Name = "txtVessel"
        Me.txtVessel.Size = New System.Drawing.Size(464, 20)
        Me.txtVessel.TabIndex = 1
        '
        'cboFind
        '
        Me.cboFind.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cboFind.FormattingEnabled = True
        Me.cboFind.Location = New System.Drawing.Point(12, 27)
        Me.cboFind.Name = "cboFind"
        Me.cboFind.Size = New System.Drawing.Size(119, 22)
        Me.cboFind.TabIndex = 0
        '
        'frmNotifyVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 471)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdVessel)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.txtVessel)
        Me.Controls.Add(Me.cboFind)
        Me.Controls.Add(Me.MenuStrip)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmNotifyVessel"
        Me.Text = "Feeder Vessel (In)"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdVessel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayName As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayCode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayETA As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayETD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayETB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayBTH As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayNote As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayCommodity As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUserId As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDisplayUpdateTime As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents txtVesselName As System.Windows.Forms.TextBox
    Friend WithEvents lblRemarks As System.Windows.Forms.Label
    Friend WithEvents txtRemarks As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents dgdVessel As System.Windows.Forms.DataGridView
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents txtVessel As System.Windows.Forms.TextBox
    Friend WithEvents cboFind As System.Windows.Forms.ComboBox
    Friend WithEvents smnuDisplayremarks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpETB As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpBTH As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents smnudisplayApprove As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtVoyNo As System.Windows.Forms.TextBox
    Friend WithEvents cboVesselCode As System.Windows.Forms.ComboBox
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents notifyVesselId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Note As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Commodity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
