<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportAmendMentfee
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cboCharge = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(379, 277)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 42
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(472, 277)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 41
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dtpToETD
        '
        Me.dtpToETD.Location = New System.Drawing.Point(92, 251)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(264, 20)
        Me.dtpToETD.TabIndex = 40
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Location = New System.Drawing.Point(92, 226)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(264, 20)
        Me.dtpFromETD.TabIndex = 39
        '
        'cmdAdd
        '
        Me.cmdAdd.ForeColor = System.Drawing.Color.Maroon
        Me.cmdAdd.Location = New System.Drawing.Point(362, 199)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 38
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(92, 201)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(264, 21)
        Me.cboVessel.TabIndex = 37
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(6, 204)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Vessel -VoyNo. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(28, 229)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "From(ETA) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(64, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "To :"
        '
        'dgdVesselCollection
        '
        Me.dgdVesselCollection.AllowUserToAddRows = False
        Me.dgdVesselCollection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdVesselCollection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdVesselCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVesselCollection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SailingScheduleID, Me.Vesselgid, Me.VoyNoGid, Me.ETDGid})
        Me.dgdVesselCollection.Location = New System.Drawing.Point(-1, 1)
        Me.dgdVesselCollection.Name = "dgdVesselCollection"
        Me.dgdVesselCollection.Size = New System.Drawing.Size(551, 188)
        Me.dgdVesselCollection.TabIndex = 33
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
        Me.GroupBox1.Controls.Add(Me.cboCharge)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(362, 226)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 45)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        '
        'cboCharge
        '
        Me.cboCharge.FormattingEnabled = True
        Me.cboCharge.Items.AddRange(New Object() {"MAF", "ASC"})
        Me.cboCharge.Location = New System.Drawing.Point(65, 19)
        Me.cboCharge.Name = "cboCharge"
        Me.cboCharge.Size = New System.Drawing.Size(99, 21)
        Me.cboCharge.TabIndex = 44
        Me.cboCharge.Text = "MAF"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(7, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "S.charge :"
        '
        'frmReportAmendMentfee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(557, 311)
        Me.Controls.Add(Me.GroupBox1)
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
        Me.Name = "frmReportAmendMentfee"
        Me.Text = "Report Manifest AmendMent Fee"
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents SailingScheduleID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vesselgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNoGid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDGid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboCharge As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
