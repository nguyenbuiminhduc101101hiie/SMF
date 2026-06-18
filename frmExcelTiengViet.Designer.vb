<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExcelTiengViet
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
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dtpToETD = New System.Windows.Forms.DateTimePicker
        Me.dtpFromETD = New System.Windows.Forms.DateTimePicker
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgdVesselCollection = New System.Windows.Forms.DataGridView
        Me.SailingScheduleID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vesselgid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNoGid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETDGid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioEPay = New System.Windows.Forms.RadioButton
        Me.RadioEPre = New System.Windows.Forms.RadioButton
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboVessel
        '
        Me.cboVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(102, 213)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(264, 21)
        Me.cboVessel.TabIndex = 43
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdCancel.Location = New System.Drawing.Point(358, 292)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 42
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdOk.Location = New System.Drawing.Point(439, 292)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 41
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dtpToETD
        '
        Me.dtpToETD.Location = New System.Drawing.Point(102, 263)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(199, 20)
        Me.dtpToETD.TabIndex = 40
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Location = New System.Drawing.Point(102, 238)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(199, 20)
        Me.dtpFromETD.TabIndex = 39
        '
        'cmdAdd
        '
        Me.cmdAdd.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdAdd.Location = New System.Drawing.Point(372, 213)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 38
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(16, 216)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Vessel -Voy No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(38, 241)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "From(ETA) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(74, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "To :"
        '
        'dgdVesselCollection
        '
        Me.dgdVesselCollection.AllowUserToAddRows = False
        Me.dgdVesselCollection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdVesselCollection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdVesselCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVesselCollection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SailingScheduleID, Me.Vesselgid, Me.VoyNoGid, Me.ETDGid})
        Me.dgdVesselCollection.Location = New System.Drawing.Point(8, 7)
        Me.dgdVesselCollection.Name = "dgdVesselCollection"
        Me.dgdVesselCollection.Size = New System.Drawing.Size(501, 200)
        Me.dgdVesselCollection.TabIndex = 34
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioEPay)
        Me.GroupBox1.Controls.Add(Me.RadioEPre)
        Me.GroupBox1.Location = New System.Drawing.Point(302, 238)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 48)
        Me.GroupBox1.TabIndex = 44
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Exchange"
        '
        'RadioEPay
        '
        Me.RadioEPay.AutoSize = True
        Me.RadioEPay.Location = New System.Drawing.Point(110, 21)
        Me.RadioEPay.Name = "RadioEPay"
        Me.RadioEPay.Size = New System.Drawing.Size(84, 17)
        Me.RadioEPay.TabIndex = 22
        Me.RadioEPay.Text = "Ex. Payment"
        Me.RadioEPay.UseVisualStyleBackColor = True
        '
        'RadioEPre
        '
        Me.RadioEPre.AutoSize = True
        Me.RadioEPre.Checked = True
        Me.RadioEPre.Location = New System.Drawing.Point(17, 21)
        Me.RadioEPre.Name = "RadioEPre"
        Me.RadioEPre.Size = New System.Drawing.Size(79, 17)
        Me.RadioEPre.TabIndex = 21
        Me.RadioEPre.TabStop = True
        Me.RadioEPre.Text = "Ex. Present"
        Me.RadioEPre.UseVisualStyleBackColor = True
        '
        'frmExcelTiengViet
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 319)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dtpToETD)
        Me.Controls.Add(Me.dtpFromETD)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgdVesselCollection)
        Me.Name = "frmExcelTiengViet"
        Me.Text = "frmExcelTiengViet"
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpToETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgdVesselCollection As System.Windows.Forms.DataGridView
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vesselgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNoGid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDGid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioEPay As System.Windows.Forms.RadioButton
    Friend WithEvents RadioEPre As System.Windows.Forms.RadioButton
End Class
