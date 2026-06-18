<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VesselCheck
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.SchedulecheckID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesselCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Checked = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkNoneCheckVessel = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SchedulecheckID, Me.VesselCode, Me.Vessel, Me.VoyNo, Me.ETA, Me.Checked, Me.Approve})
        Me.DataGridView1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(622, 321)
        Me.DataGridView1.TabIndex = 1
        '
        'SchedulecheckID
        '
        Me.SchedulecheckID.DataPropertyName = "SchedulecheckID"
        Me.SchedulecheckID.HeaderText = "SchedulecheckID"
        Me.SchedulecheckID.Name = "SchedulecheckID"
        Me.SchedulecheckID.Visible = False
        '
        'VesselCode
        '
        Me.VesselCode.DataPropertyName = "VesselCode"
        Me.VesselCode.HeaderText = "VesselCode"
        Me.VesselCode.Name = "VesselCode"
        Me.VesselCode.ReadOnly = True
        '
        'Vessel
        '
        Me.Vessel.DataPropertyName = "Vessel"
        Me.Vessel.HeaderText = "Vessel"
        Me.Vessel.Name = "Vessel"
        Me.Vessel.ReadOnly = True
        '
        'VoyNo
        '
        Me.VoyNo.DataPropertyName = "VoyNo"
        Me.VoyNo.HeaderText = "VoyNo"
        Me.VoyNo.Name = "VoyNo"
        Me.VoyNo.ReadOnly = True
        '
        'ETA
        '
        Me.ETA.DataPropertyName = "ETA"
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        '
        'Checked
        '
        Me.Checked.DataPropertyName = "Checked"
        Me.Checked.HeaderText = "Check"
        Me.Checked.Name = "Checked"
        Me.Checked.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Checked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.chkNoneCheckVessel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboYear)
        Me.GroupBox1.Controls.Add(Me.cboMonth)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 339)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(509, 51)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ETA"
        '
        'chkNoneCheckVessel
        '
        Me.chkNoneCheckVessel.AutoSize = True
        Me.chkNoneCheckVessel.Location = New System.Drawing.Point(225, 20)
        Me.chkNoneCheckVessel.Name = "chkNoneCheckVessel"
        Me.chkNoneCheckVessel.Size = New System.Drawing.Size(144, 17)
        Me.chkNoneCheckVessel.TabIndex = 4
        Me.chkNoneCheckVessel.Text = "None Check Vessel Only"
        Me.chkNoneCheckVessel.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Year :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Month :"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(143, 17)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(65, 21)
        Me.cboYear.TabIndex = 3
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(50, 17)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(57, 21)
        Me.cboMonth.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(551, 339)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(83, 24)
        Me.cmdCancel.TabIndex = 7
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(153, 48)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'VesselCheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(646, 402)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "VesselCheck"
        Me.Text = "VesselCheck"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents SchedulecheckID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checked As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkNoneCheckVessel As System.Windows.Forms.CheckBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
