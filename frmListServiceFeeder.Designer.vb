<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListServiceFeeder
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
        Me.dgdServiceFeeder = New System.Windows.Forms.DataGridView
        Me.ServiceFeederID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServiceFeederCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServiCeFeederName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.txtServiceFeedername = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtServiceFeederCode = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabService = New System.Windows.Forms.TabPage
        Me.tabViaPort = New System.Windows.Forms.TabPage
        Me.dgdViaPortData = New System.Windows.Forms.DataGridView
        Me.cmdOkP = New System.Windows.Forms.Button
        Me.cmdCancelP = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboPort = New System.Windows.Forms.ComboBox
        Me.txtNumberOfDay = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ServiceViaPortID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ServiceID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ViaPortID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PortCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PortName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfDayVia = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContinuedViaPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EditableViaPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveViaPort = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserIDViaPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTimeViaPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdServiceFeeder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabService.SuspendLayout()
        Me.tabViaPort.SuspendLayout()
        CType(Me.dgdViaPortData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdServiceFeeder
        '
        Me.dgdServiceFeeder.AllowUserToAddRows = False
        Me.dgdServiceFeeder.AllowUserToDeleteRows = False
        Me.dgdServiceFeeder.AllowUserToOrderColumns = True
        Me.dgdServiceFeeder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdServiceFeeder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdServiceFeeder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceFeederID, Me.ServiceFeederCode, Me.ServiCeFeederName, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdServiceFeeder.Location = New System.Drawing.Point(6, 31)
        Me.dgdServiceFeeder.Name = "dgdServiceFeeder"
        Me.dgdServiceFeeder.ReadOnly = True
        Me.dgdServiceFeeder.Size = New System.Drawing.Size(629, 120)
        Me.dgdServiceFeeder.TabIndex = 0
        '
        'ServiceFeederID
        '
        Me.ServiceFeederID.DataPropertyName = "ServiceFeederID"
        Me.ServiceFeederID.HeaderText = "ServiceFeederID"
        Me.ServiceFeederID.Name = "ServiceFeederID"
        Me.ServiceFeederID.ReadOnly = True
        Me.ServiceFeederID.Visible = False
        '
        'ServiceFeederCode
        '
        Me.ServiceFeederCode.DataPropertyName = "ServiceFeederCode"
        Me.ServiceFeederCode.HeaderText = "ServiceFeederCode"
        Me.ServiceFeederCode.Name = "ServiceFeederCode"
        Me.ServiceFeederCode.ReadOnly = True
        '
        'ServiCeFeederName
        '
        Me.ServiCeFeederName.DataPropertyName = "ServiCeFeederName"
        Me.ServiCeFeederName.HeaderText = "ServiCe Feeder Name"
        Me.ServiCeFeederName.Name = "ServiCeFeederName"
        Me.ServiCeFeederName.ReadOnly = True
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Visible = False
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.ReadOnly = True
        Me.Editable.Visible = False
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(638, 24)
        Me.MenuStrip.TabIndex = 1
        Me.MenuStrip.Text = "MenuStrip1"
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
        Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
        Me.smnuAdd.Text = "Insert"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "Delete"
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
        Me.smnuExit.Text = "Exit"
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.TabControl1)
        Me.fraUpdate.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.fraUpdate.Location = New System.Drawing.Point(0, 147)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(638, 235)
        Me.fraUpdate.TabIndex = 2
        Me.fraUpdate.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(446, 161)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(530, 161)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'txtServiceFeedername
        '
        Me.txtServiceFeedername.Location = New System.Drawing.Point(124, 37)
        Me.txtServiceFeedername.Name = "txtServiceFeedername"
        Me.txtServiceFeedername.Size = New System.Drawing.Size(242, 20)
        Me.txtServiceFeedername.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(6, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Service Feeder Name :"
        '
        'txtServiceFeederCode
        '
        Me.txtServiceFeederCode.Location = New System.Drawing.Point(124, 11)
        Me.txtServiceFeederCode.Name = "txtServiceFeederCode"
        Me.txtServiceFeederCode.Size = New System.Drawing.Size(100, 20)
        Me.txtServiceFeederCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(9, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service Feeder Code :"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabService)
        Me.TabControl1.Controls.Add(Me.tabViaPort)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(632, 216)
        Me.TabControl1.TabIndex = 3
        '
        'tabService
        '
        Me.tabService.Controls.Add(Me.cmdCancel)
        Me.tabService.Controls.Add(Me.txtServiceFeederCode)
        Me.tabService.Controls.Add(Me.cmdOk)
        Me.tabService.Controls.Add(Me.Label1)
        Me.tabService.Controls.Add(Me.txtServiceFeedername)
        Me.tabService.Controls.Add(Me.Label2)
        Me.tabService.Location = New System.Drawing.Point(4, 22)
        Me.tabService.Name = "tabService"
        Me.tabService.Padding = New System.Windows.Forms.Padding(3)
        Me.tabService.Size = New System.Drawing.Size(624, 190)
        Me.tabService.TabIndex = 0
        Me.tabService.Text = "Service"
        Me.tabService.UseVisualStyleBackColor = True
        '
        'tabViaPort
        '
        Me.tabViaPort.Controls.Add(Me.txtNumberOfDay)
        Me.tabViaPort.Controls.Add(Me.Label4)
        Me.tabViaPort.Controls.Add(Me.cmdOkP)
        Me.tabViaPort.Controls.Add(Me.cmdCancelP)
        Me.tabViaPort.Controls.Add(Me.Label3)
        Me.tabViaPort.Controls.Add(Me.cboPort)
        Me.tabViaPort.Controls.Add(Me.dgdViaPortData)
        Me.tabViaPort.Location = New System.Drawing.Point(4, 22)
        Me.tabViaPort.Name = "tabViaPort"
        Me.tabViaPort.Padding = New System.Windows.Forms.Padding(3)
        Me.tabViaPort.Size = New System.Drawing.Size(624, 190)
        Me.tabViaPort.TabIndex = 1
        Me.tabViaPort.Text = "ViaPort Info"
        Me.tabViaPort.UseVisualStyleBackColor = True
        '
        'dgdViaPortData
        '
        Me.dgdViaPortData.AllowUserToAddRows = False
        Me.dgdViaPortData.AllowUserToDeleteRows = False
        Me.dgdViaPortData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdViaPortData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ServiceViaPortID, Me.ServiceID, Me.ViaPortID, Me.PortCode, Me.PortName, Me.NumberOfDayVia, Me.ContinuedViaPort, Me.EditableViaPort, Me.ApproveViaPort, Me.UserIDViaPort, Me.UpdateTimeViaPort})
        Me.dgdViaPortData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdViaPortData.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgdViaPortData.Location = New System.Drawing.Point(3, 3)
        Me.dgdViaPortData.Name = "dgdViaPortData"
        Me.dgdViaPortData.ReadOnly = True
        Me.dgdViaPortData.Size = New System.Drawing.Size(618, 111)
        Me.dgdViaPortData.TabIndex = 0
        '
        'cmdOkP
        '
        Me.cmdOkP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOkP.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOkP.Location = New System.Drawing.Point(543, 161)
        Me.cmdOkP.Name = "cmdOkP"
        Me.cmdOkP.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkP.TabIndex = 10
        Me.cmdOkP.Text = "&Ok"
        Me.cmdOkP.UseVisualStyleBackColor = True
        '
        'cmdCancelP
        '
        Me.cmdCancelP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancelP.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancelP.Location = New System.Drawing.Point(462, 161)
        Me.cmdCancelP.Name = "cmdCancelP"
        Me.cmdCancelP.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelP.TabIndex = 9
        Me.cmdCancelP.Text = "&Cancel"
        Me.cmdCancelP.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(60, 123)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Port :"
        '
        'cboPort
        '
        Me.cboPort.Enabled = False
        Me.cboPort.FormattingEnabled = True
        Me.cboPort.Location = New System.Drawing.Point(95, 120)
        Me.cboPort.Name = "cboPort"
        Me.cboPort.Size = New System.Drawing.Size(237, 21)
        Me.cboPort.TabIndex = 7
        '
        'txtNumberOfDay
        '
        Me.txtNumberOfDay.Location = New System.Drawing.Point(95, 147)
        Me.txtNumberOfDay.Name = "txtNumberOfDay"
        Me.txtNumberOfDay.Size = New System.Drawing.Size(100, 20)
        Me.txtNumberOfDay.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(9, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Number Of day :"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(106, 70)
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.AddToolStripMenuItem.Text = "Add"
        '
        'EditToolStripMenuItem
        '
        Me.EditToolStripMenuItem.Name = "EditToolStripMenuItem"
        Me.EditToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EditToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'ServiceViaPortID
        '
        Me.ServiceViaPortID.DataPropertyName = "ServiceViaPortID"
        Me.ServiceViaPortID.HeaderText = "ServiceViaPortID"
        Me.ServiceViaPortID.Name = "ServiceViaPortID"
        Me.ServiceViaPortID.ReadOnly = True
        Me.ServiceViaPortID.Visible = False
        '
        'ServiceID
        '
        Me.ServiceID.DataPropertyName = "ServiceID"
        Me.ServiceID.HeaderText = "ServiceID"
        Me.ServiceID.Name = "ServiceID"
        Me.ServiceID.ReadOnly = True
        Me.ServiceID.Visible = False
        '
        'ViaPortID
        '
        Me.ViaPortID.DataPropertyName = "ViaPortID"
        Me.ViaPortID.HeaderText = "ViaPortID"
        Me.ViaPortID.Name = "ViaPortID"
        Me.ViaPortID.ReadOnly = True
        Me.ViaPortID.Visible = False
        '
        'PortCode
        '
        Me.PortCode.DataPropertyName = "Port_Code"
        Me.PortCode.HeaderText = "Port Code"
        Me.PortCode.Name = "PortCode"
        Me.PortCode.ReadOnly = True
        '
        'PortName
        '
        Me.PortName.DataPropertyName = "Port"
        Me.PortName.HeaderText = "Port Name"
        Me.PortName.Name = "PortName"
        Me.PortName.ReadOnly = True
        '
        'NumberOfDayVia
        '
        Me.NumberOfDayVia.DataPropertyName = "NumberOfDayVia"
        Me.NumberOfDayVia.HeaderText = "Number Of Day"
        Me.NumberOfDayVia.Name = "NumberOfDayVia"
        Me.NumberOfDayVia.ReadOnly = True
        '
        'ContinuedViaPort
        '
        Me.ContinuedViaPort.DataPropertyName = "Continued"
        Me.ContinuedViaPort.HeaderText = "Continued"
        Me.ContinuedViaPort.Name = "ContinuedViaPort"
        Me.ContinuedViaPort.ReadOnly = True
        Me.ContinuedViaPort.Visible = False
        '
        'EditableViaPort
        '
        Me.EditableViaPort.DataPropertyName = "Editable"
        Me.EditableViaPort.HeaderText = "Editable"
        Me.EditableViaPort.Name = "EditableViaPort"
        Me.EditableViaPort.ReadOnly = True
        Me.EditableViaPort.Visible = False
        '
        'ApproveViaPort
        '
        Me.ApproveViaPort.DataPropertyName = "Approve"
        Me.ApproveViaPort.HeaderText = "Approve"
        Me.ApproveViaPort.Name = "ApproveViaPort"
        Me.ApproveViaPort.ReadOnly = True
        Me.ApproveViaPort.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApproveViaPort.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'UserIDViaPort
        '
        Me.UserIDViaPort.DataPropertyName = "UserID"
        Me.UserIDViaPort.HeaderText = "UserID"
        Me.UserIDViaPort.Name = "UserIDViaPort"
        Me.UserIDViaPort.ReadOnly = True
        '
        'UpdateTimeViaPort
        '
        Me.UpdateTimeViaPort.DataPropertyName = "UpdateTime"
        Me.UpdateTimeViaPort.HeaderText = "UpdateTime"
        Me.UpdateTimeViaPort.Name = "UpdateTimeViaPort"
        Me.UpdateTimeViaPort.ReadOnly = True
        '
        'frmListServiceFeeder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 382)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdServiceFeeder)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmListServiceFeeder"
        Me.Text = "Service Feeder"
        CType(Me.dgdServiceFeeder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabService.ResumeLayout(False)
        Me.tabService.PerformLayout()
        Me.tabViaPort.ResumeLayout(False)
        Me.tabViaPort.PerformLayout()
        CType(Me.dgdViaPortData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdServiceFeeder As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtServiceFeedername As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtServiceFeederCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServiceFeederID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceFeederCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiCeFeederName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabService As System.Windows.Forms.TabPage
    Friend WithEvents tabViaPort As System.Windows.Forms.TabPage
    Friend WithEvents dgdViaPortData As System.Windows.Forms.DataGridView
    Friend WithEvents txtNumberOfDay As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdOkP As System.Windows.Forms.Button
    Friend WithEvents cmdCancelP As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboPort As System.Windows.Forms.ComboBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AddToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ServiceViaPortID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ServiceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ViaPortID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PortCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PortName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfDayVia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContinuedViaPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditableViaPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveViaPort As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserIDViaPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTimeViaPort As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
