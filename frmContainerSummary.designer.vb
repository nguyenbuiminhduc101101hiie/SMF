<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContainerSummary
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
        Me.dtpToETA = New System.Windows.Forms.DateTimePicker
        Me.dtpFromETA = New System.Windows.Forms.DateTimePicker
        Me.cmdAdd = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgdVesselCollection = New System.Windows.Forms.DataGridView
        Me.Vesselgid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNoGid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETAGid = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdCancel.Location = New System.Drawing.Point(248, 284)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 22
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdOk.Location = New System.Drawing.Point(329, 284)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 21
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dtpToETA
        '
        Me.dtpToETA.Location = New System.Drawing.Point(97, 258)
        Me.dtpToETA.Name = "dtpToETA"
        Me.dtpToETA.Size = New System.Drawing.Size(307, 20)
        Me.dtpToETA.TabIndex = 20
        '
        'dtpFromETA
        '
        Me.dtpFromETA.Location = New System.Drawing.Point(97, 233)
        Me.dtpFromETA.Name = "dtpFromETA"
        Me.dtpFromETA.Size = New System.Drawing.Size(307, 20)
        Me.dtpFromETA.TabIndex = 19
        '
        'cmdAdd
        '
        Me.cmdAdd.ForeColor = System.Drawing.Color.MidnightBlue
        Me.cmdAdd.Location = New System.Drawing.Point(419, 206)
        Me.cmdAdd.Name = "cmdAdd"
        Me.cmdAdd.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd.TabIndex = 18
        Me.cmdAdd.Text = "&Add"
        Me.cmdAdd.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(97, 208)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(307, 21)
        Me.cboVessel.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(11, 211)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Vessel -Voy No :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label3.Location = New System.Drawing.Point(33, 236)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "From(ETA) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label2.Location = New System.Drawing.Point(69, 261)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "To :"
        '
        'dgdVesselCollection
        '
        Me.dgdVesselCollection.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdVesselCollection.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdVesselCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdVesselCollection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Vesselgid, Me.VoyNoGid, Me.ETAGid})
        Me.dgdVesselCollection.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgdVesselCollection.Location = New System.Drawing.Point(0, 0)
        Me.dgdVesselCollection.Name = "dgdVesselCollection"
        Me.dgdVesselCollection.Size = New System.Drawing.Size(504, 200)
        Me.dgdVesselCollection.TabIndex = 13
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
        'ETAGid
        '
        Me.ETAGid.DataPropertyName = "ETA"
        Me.ETAGid.HeaderText = "ETA"
        Me.ETAGid.Name = "ETAGid"
        '
        'frmContainerSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 319)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dtpToETA)
        Me.Controls.Add(Me.dtpFromETA)
        Me.Controls.Add(Me.cmdAdd)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgdVesselCollection)
        Me.MaximizeBox = False
        Me.Name = "frmContainerSummary"
        Me.Text = "Container Summary"
        CType(Me.dgdVesselCollection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpToETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdAdd As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgdVesselCollection As System.Windows.Forms.DataGridView
    Friend WithEvents Vesselgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNoGid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETAGid As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
