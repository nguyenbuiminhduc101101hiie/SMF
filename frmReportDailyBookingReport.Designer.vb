<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportDailyBookingReport
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtWeek = New System.Windows.Forms.TextBox
        Me.txtDate = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdCheckAll = New System.Windows.Forms.Button
        Me.cmdUncheckAll = New System.Windows.Forms.Button
        Me.dgdVessel = New System.Windows.Forms.DataGridView
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.dgdResult = New System.Windows.Forms.DataGridView
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ReportOperator = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR20_ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR40_ = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Slot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CHON = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OPR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Service = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SpaceTEU = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GP20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GP40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HC40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HC45 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RF20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RF40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RH40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OT20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OT40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Capacity = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesselSlot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TOTAL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtWeek)
        Me.GroupBox1.Controls.Add(Me.txtDate)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmdCheckAll)
        Me.GroupBox1.Controls.Add(Me.cmdUncheckAll)
        Me.GroupBox1.Controls.Add(Me.dgdVessel)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(655, 209)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Feeder"
        '
        'txtWeek
        '
        Me.txtWeek.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtWeek.Location = New System.Drawing.Point(534, 20)
        Me.txtWeek.Name = "txtWeek"
        Me.txtWeek.ReadOnly = True
        Me.txtWeek.Size = New System.Drawing.Size(47, 20)
        Me.txtWeek.TabIndex = 12
        '
        'txtDate
        '
        Me.txtDate.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtDate.Location = New System.Drawing.Point(386, 20)
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(94, 20)
        Me.txtDate.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(490, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Week :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(347, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Date :"
        '
        'cmdCheckAll
        '
        Me.cmdCheckAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdCheckAll.Location = New System.Drawing.Point(10, 51)
        Me.cmdCheckAll.Name = "cmdCheckAll"
        Me.cmdCheckAll.Size = New System.Drawing.Size(102, 23)
        Me.cmdCheckAll.TabIndex = 10
        Me.cmdCheckAll.Text = "Check ALL"
        Me.cmdCheckAll.UseVisualStyleBackColor = True
        '
        'cmdUncheckAll
        '
        Me.cmdUncheckAll.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdUncheckAll.Location = New System.Drawing.Point(118, 51)
        Me.cmdUncheckAll.Name = "cmdUncheckAll"
        Me.cmdUncheckAll.Size = New System.Drawing.Size(97, 23)
        Me.cmdUncheckAll.TabIndex = 9
        Me.cmdUncheckAll.Text = "UnCheck ALL"
        Me.cmdUncheckAll.UseVisualStyleBackColor = True
        '
        'dgdVessel
        '
        Me.dgdVessel.AllowUserToAddRows = False
        Me.dgdVessel.AllowUserToDeleteRows = False
        Me.dgdVessel.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgdVessel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVessel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CHON, Me.ID, Me.Vessel, Me.Vessel_Code, Me.ETD, Me.OPR, Me.Service, Me.SpaceTEU, Me.GP20, Me.GP40, Me.HC40, Me.HC45, Me.RF20, Me.RF40, Me.RH40, Me.OT20, Me.OT40, Me.FR20, Me.FR40, Me.Capacity, Me.VesselSlot, Me.Column1, Me.Column2, Me.TOTAL})
        Me.dgdVessel.Location = New System.Drawing.Point(8, 80)
        Me.dgdVessel.Name = "dgdVessel"
        Me.dgdVessel.Size = New System.Drawing.Size(449, 116)
        Me.dgdVessel.TabIndex = 8
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdOk.Location = New System.Drawing.Point(549, 173)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdCancel.Location = New System.Drawing.Point(468, 173)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(188, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ETD (To) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(18, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "ETD (From) :"
        '
        'dtpTo
        '
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(247, 19)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(93, 20)
        Me.dtpTo.TabIndex = 4
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(87, 19)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(93, 20)
        Me.dtpFrom.TabIndex = 5
        '
        'dgdResult
        '
        Me.dgdResult.AllowUserToAddRows = False
        Me.dgdResult.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.dgdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn3, Me.POL, Me.DataGridViewTextBoxColumn5, Me.ReportOperator, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.FR20_, Me.FR40_, Me.DataGridViewTextBoxColumn6, Me.Slot, Me.DataGridViewTextBoxColumn16})
        Me.dgdResult.Location = New System.Drawing.Point(10, 256)
        Me.dgdResult.Name = "dgdResult"
        Me.dgdResult.ReadOnly = True
        Me.dgdResult.Size = New System.Drawing.Size(655, 166)
        Me.dgdResult.TabIndex = 9
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdExportExcel.Location = New System.Drawing.Point(584, 227)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 10
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Vessel_Code"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Vessel Code"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Data"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Vessel  /  VoyNo"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 150
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "ETD"
        Me.DataGridViewTextBoxColumn3.HeaderText = "ETD"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Service"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Service"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'ReportOperator
        '
        Me.ReportOperator.DataPropertyName = "Operator"
        Me.ReportOperator.HeaderText = "Operator"
        Me.ReportOperator.Name = "ReportOperator"
        Me.ReportOperator.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Soluong20GP"
        Me.DataGridViewTextBoxColumn7.HeaderText = "20GP"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Soluong40GP"
        Me.DataGridViewTextBoxColumn8.HeaderText = "40GP"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Soluong40HC"
        Me.DataGridViewTextBoxColumn9.HeaderText = "40HC"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Soluong45HC"
        Me.DataGridViewTextBoxColumn10.HeaderText = "45HC"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Soluong20RF"
        Me.DataGridViewTextBoxColumn11.HeaderText = "20RF"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Soluong40RF"
        Me.DataGridViewTextBoxColumn12.HeaderText = "40RF"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Soluong40RH"
        Me.DataGridViewTextBoxColumn13.HeaderText = "40RH"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Soluong20OT"
        Me.DataGridViewTextBoxColumn14.HeaderText = "20OT"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Soluong40OT"
        Me.DataGridViewTextBoxColumn15.HeaderText = "40OT"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'FR20_
        '
        Me.FR20_.DataPropertyName = "Soluong20FR"
        Me.FR20_.HeaderText = "20FR"
        Me.FR20_.Name = "FR20_"
        Me.FR20_.ReadOnly = True
        '
        'FR40_
        '
        Me.FR40_.DataPropertyName = "Soluong40FR"
        Me.FR40_.HeaderText = "40FR"
        Me.FR40_.Name = "FR40_"
        Me.FR40_.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Capacity"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Capacity"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'Slot
        '
        Me.Slot.DataPropertyName = "Slot"
        Me.Slot.HeaderText = "Slot"
        Me.Slot.Name = "Slot"
        Me.Slot.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "TotalTEU"
        Me.DataGridViewTextBoxColumn16.HeaderText = "TOTAL TEU"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'CHON
        '
        Me.CHON.HeaderText = "Select"
        Me.CHON.Name = "CHON"
        '
        'ID
        '
        Me.ID.DataPropertyName = "ID"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.Visible = False
        '
        'Vessel
        '
        Me.Vessel.DataPropertyName = "Data"
        Me.Vessel.HeaderText = "Vessel - VoyNo"
        Me.Vessel.Name = "Vessel"
        Me.Vessel.ReadOnly = True
        Me.Vessel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Vessel_Code
        '
        Me.Vessel_Code.DataPropertyName = "Vessel_Code"
        Me.Vessel_Code.HeaderText = "Vessel_Code"
        Me.Vessel_Code.Name = "Vessel_Code"
        Me.Vessel_Code.ReadOnly = True
        Me.Vessel_Code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Vessel_Code.Visible = False
        '
        'ETD
        '
        Me.ETD.DataPropertyName = "ETD"
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        Me.ETD.Visible = False
        '
        'OPR
        '
        Me.OPR.DataPropertyName = "OPR"
        Me.OPR.HeaderText = "OPR"
        Me.OPR.Name = "OPR"
        Me.OPR.Visible = False
        '
        'Service
        '
        Me.Service.DataPropertyName = "Service"
        Me.Service.HeaderText = "SerVice"
        Me.Service.Name = "Service"
        Me.Service.Visible = False
        '
        'SpaceTEU
        '
        Me.SpaceTEU.HeaderText = "Space Teu"
        Me.SpaceTEU.Name = "SpaceTEU"
        Me.SpaceTEU.Visible = False
        '
        'GP20
        '
        Me.GP20.DataPropertyName = "Soluong20GP"
        Me.GP20.HeaderText = "20GP"
        Me.GP20.Name = "GP20"
        Me.GP20.Visible = False
        '
        'GP40
        '
        Me.GP40.DataPropertyName = "Soluong40GP"
        Me.GP40.HeaderText = "40GP"
        Me.GP40.Name = "GP40"
        Me.GP40.Visible = False
        '
        'HC40
        '
        Me.HC40.DataPropertyName = "Soluong40HC"
        Me.HC40.HeaderText = "40HC"
        Me.HC40.Name = "HC40"
        Me.HC40.Visible = False
        '
        'HC45
        '
        Me.HC45.DataPropertyName = "Soluong45HC"
        Me.HC45.HeaderText = "45HC"
        Me.HC45.Name = "HC45"
        Me.HC45.Visible = False
        '
        'RF20
        '
        Me.RF20.DataPropertyName = "Soluong20RF"
        Me.RF20.HeaderText = "20RF"
        Me.RF20.Name = "RF20"
        Me.RF20.Visible = False
        '
        'RF40
        '
        Me.RF40.DataPropertyName = "Soluong40RF"
        Me.RF40.HeaderText = "40RF"
        Me.RF40.Name = "RF40"
        Me.RF40.Visible = False
        '
        'RH40
        '
        Me.RH40.DataPropertyName = "Soluong40RH"
        Me.RH40.HeaderText = "40RH"
        Me.RH40.Name = "RH40"
        Me.RH40.Visible = False
        '
        'OT20
        '
        Me.OT20.DataPropertyName = "Soluong20OT"
        Me.OT20.HeaderText = "20OT"
        Me.OT20.Name = "OT20"
        Me.OT20.Visible = False
        '
        'OT40
        '
        Me.OT40.DataPropertyName = "Soluong40OT"
        Me.OT40.HeaderText = "40OT"
        Me.OT40.Name = "OT40"
        Me.OT40.Visible = False
        '
        'FR20
        '
        Me.FR20.DataPropertyName = "Soluong20FR"
        Me.FR20.HeaderText = "20FR"
        Me.FR20.Name = "FR20"
        Me.FR20.Visible = False
        '
        'FR40
        '
        Me.FR40.DataPropertyName = "Soluong40FR"
        Me.FR40.HeaderText = "40FR"
        Me.FR40.Name = "FR40"
        Me.FR40.Visible = False
        '
        'Capacity
        '
        Me.Capacity.DataPropertyName = "Capacity"
        Me.Capacity.HeaderText = "Capacity"
        Me.Capacity.Name = "Capacity"
        Me.Capacity.Visible = False
        '
        'VesselSlot
        '
        Me.VesselSlot.DataPropertyName = "Slot"
        Me.VesselSlot.HeaderText = "Slot"
        Me.VesselSlot.Name = "VesselSlot"
        Me.VesselSlot.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "POL"
        Me.Column1.HeaderText = "POL"
        Me.Column1.Name = "Column1"
        Me.Column1.Visible = False
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Operator"
        Me.Column2.HeaderText = "Operator"
        Me.Column2.Name = "Column2"
        Me.Column2.Visible = False
        '
        'TOTAL
        '
        Me.TOTAL.HeaderText = "TOTAL TEU"
        Me.TOTAL.Name = "TOTAL"
        Me.TOTAL.Visible = False
        '
        'frmReportDailyBookingReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(682, 433)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.dgdResult)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximumSize = New System.Drawing.Size(877, 644)
        Me.MinimumSize = New System.Drawing.Size(100, 111)
        Me.Name = "frmReportDailyBookingReport"
        Me.Text = "Daily Booking Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdVessel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents dgdVessel As System.Windows.Forms.DataGridView
    Friend WithEvents dgdResult As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdCheckAll As System.Windows.Forms.Button
    Friend WithEvents cmdUncheckAll As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWeek As System.Windows.Forms.TextBox
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents CHON As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SpaceTEU As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GP20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GP40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HC40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HC45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RF20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RF40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RH40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OT20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OT40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselSlot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TOTAL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReportOperator As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR20_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR40_ As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Slot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
