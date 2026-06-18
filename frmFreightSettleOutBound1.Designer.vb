<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreightSettleOutBound1
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dtpToETD = New System.Windows.Forms.DateTimePicker
        Me.dtpFromETD = New System.Windows.Forms.DateTimePicker
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgdVesselCollection = New System.Windows.Forms.DataGridView
        Me.SailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vesselgid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNoGid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETDGid = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdCancel.Location = New System.Drawing.Point(298, 290)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 32
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdOk.Location = New System.Drawing.Point(379, 290)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 31
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dtpToETD
        '
        Me.dtpToETD.Location = New System.Drawing.Point(100, 257)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(264, 20)
        Me.dtpToETD.TabIndex = 30
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Location = New System.Drawing.Point(100, 232)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(264, 20)
        Me.dtpFromETD.TabIndex = 29
        '
        'cmdAdd
        '
        Me.cmdAdd.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdAdd.Location = New System.Drawing.Point(370, 205)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 28
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(100, 207)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(264, 21)
        Me.cboVessel.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(14, 210)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Vessel -Voy No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(36, 235)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "From(ETA) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(72, 260)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "To :"
        '
        'dgdVesselCollection
        '
        Me.dgdVesselCollection.AllowUserToAddRows = False
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.MidnightBlue
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdVesselCollection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdVesselCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVesselCollection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SailingScheduleID, Me.Vesselgid, Me.VoyNoGid, Me.ETDGid})
        Me.dgdVesselCollection.Location = New System.Drawing.Point(12, 1)
        Me.dgdVesselCollection.Name = "dgdVesselCollection"
        Me.dgdVesselCollection.Size = New System.Drawing.Size(468, 200)
        Me.dgdVesselCollection.TabIndex = 23
        '
        'SailingScheduleID
        '
        Me.SailingScheduleID.DataPropertyName = "SailingScheduleID"
        Me.SailingScheduleID.HeaderText = "SailingScheduleID"
        Me.SailingScheduleID.Name = "SailingScheduleID"
        Me.SailingScheduleID.Visible = False
        '
        'Vesselgid
        '
        Me.Vesselgid.DataPropertyName = "Vessel"
        Me.Vesselgid.HeaderText = "Vessel"
        Me.Vesselgid.Name = "Vesselgid"
        '
        'VoyNoGid
        '
        Me.VoyNoGid.DataPropertyName = "VoyNo"
        Me.VoyNoGid.HeaderText = "VoyNo"
        Me.VoyNoGid.Name = "VoyNoGid"
        '
        'ETDGid
        '
        Me.ETDGid.DataPropertyName = "ETD"
        Me.ETDGid.HeaderText = "ETD"
        Me.ETDGid.Name = "ETDGid"
        '
        'frmFreightSettleOutBound1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 324)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dtpToETD)
        Me.Controls.Add(Me.dtpFromETD)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgdVesselCollection)
        Me.MaximumSize = New System.Drawing.Size(500, 351)
        Me.MinimumSize = New System.Drawing.Size(500, 351)
        Me.Name = "frmFreightSettleOutBound1"
        Me.Text = "Freight Settle Outbound 1"
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpToETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgdVesselCollection As System.Windows.Forms.DataGridView
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vesselgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNoGid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDGid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
