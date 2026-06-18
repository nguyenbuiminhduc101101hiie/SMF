<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportBookingSummary_Mother
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
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.cboWeek = New System.Windows.Forms.ComboBox
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.dgdResult = New System.Windows.Forms.DataGridView
        Me.chkVesselFind = New System.Windows.Forms.RadioButton
        Me.chkDateFind = New System.Windows.Forms.RadioButton
        Me.Market = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgdResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(542, 98)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(11, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Year :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(115, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Week :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(10, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Vessel VoyNo :"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(48, 26)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(54, 21)
        Me.cboYear.TabIndex = 5
        '
        'cboWeek
        '
        Me.cboWeek.FormattingEnabled = True
        Me.cboWeek.Location = New System.Drawing.Point(160, 26)
        Me.cboWeek.Name = "cboWeek"
        Me.cboWeek.Size = New System.Drawing.Size(44, 21)
        Me.cboWeek.TabIndex = 6
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(95, 24)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(258, 21)
        Me.cboVessel.TabIndex = 7
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboYear)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cboWeek)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(225, 63)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Week/Year"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboVessel)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(251, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(366, 63)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Vessel /VoyNo"
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(461, 98)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdExportExcel.Location = New System.Drawing.Point(380, 98)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 0
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'dgdResult
        '
        Me.dgdResult.AllowUserToAddRows = False
        Me.dgdResult.AllowUserToDeleteRows = False
        Me.dgdResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Market, Me.GP20, Me.GP40, Me.HC40, Me.HC45, Me.RF20, Me.RF40, Me.RH40, Me.OT20, Me.OT40, Me.FR20, Me.FR40})
        Me.dgdResult.Location = New System.Drawing.Point(12, 140)
        Me.dgdResult.Name = "dgdResult"
        Me.dgdResult.ReadOnly = True
        Me.dgdResult.Size = New System.Drawing.Size(605, 230)
        Me.dgdResult.TabIndex = 9
        '
        'chkVesselFind
        '
        Me.chkVesselFind.AutoSize = True
        Me.chkVesselFind.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkVesselFind.Location = New System.Drawing.Point(251, 6)
        Me.chkVesselFind.Name = "chkVesselFind"
        Me.chkVesselFind.Size = New System.Drawing.Size(122, 17)
        Me.chkVesselFind.TabIndex = 13
        Me.chkVesselFind.Text = "Find Vessel / VoyNo"
        Me.chkVesselFind.UseVisualStyleBackColor = True
        '
        'chkDateFind
        '
        Me.chkDateFind.AutoSize = True
        Me.chkDateFind.Checked = True
        Me.chkDateFind.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkDateFind.Location = New System.Drawing.Point(12, 6)
        Me.chkDateFind.Name = "chkDateFind"
        Me.chkDateFind.Size = New System.Drawing.Size(122, 17)
        Me.chkDateFind.TabIndex = 12
        Me.chkDateFind.TabStop = True
        Me.chkDateFind.Text = "Find Week And year"
        Me.chkDateFind.UseVisualStyleBackColor = True
        '
        'Market
        '
        Me.Market.DataPropertyName = "Market"
        Me.Market.HeaderText = "Market"
        Me.Market.Name = "Market"
        Me.Market.ReadOnly = True
        '
        'GP20
        '
        Me.GP20.DataPropertyName = "SoLuong20GP"
        Me.GP20.HeaderText = "20GP"
        Me.GP20.Name = "GP20"
        Me.GP20.ReadOnly = True
        '
        'GP40
        '
        Me.GP40.DataPropertyName = "SoLuong40GP"
        Me.GP40.HeaderText = "40GP"
        Me.GP40.Name = "GP40"
        Me.GP40.ReadOnly = True
        '
        'HC40
        '
        Me.HC40.DataPropertyName = "SoLuong40HC"
        Me.HC40.HeaderText = "40HC"
        Me.HC40.Name = "HC40"
        Me.HC40.ReadOnly = True
        '
        'HC45
        '
        Me.HC45.DataPropertyName = "SoLuong45HC"
        Me.HC45.HeaderText = "45HC"
        Me.HC45.Name = "HC45"
        Me.HC45.ReadOnly = True
        '
        'RF20
        '
        Me.RF20.DataPropertyName = "SoLuong20RF"
        Me.RF20.HeaderText = "20RF"
        Me.RF20.Name = "RF20"
        Me.RF20.ReadOnly = True
        '
        'RF40
        '
        Me.RF40.DataPropertyName = "SoLuong40RF"
        Me.RF40.HeaderText = "40RF"
        Me.RF40.Name = "RF40"
        Me.RF40.ReadOnly = True
        '
        'RH40
        '
        Me.RH40.DataPropertyName = "SoLuong40RH"
        Me.RH40.HeaderText = "40RH"
        Me.RH40.Name = "RH40"
        Me.RH40.ReadOnly = True
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
        'frmReportBookingSummary_Mother
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 382)
        Me.Controls.Add(Me.chkVesselFind)
        Me.Controls.Add(Me.chkDateFind)
        Me.Controls.Add(Me.dgdResult)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Name = "frmReportBookingSummary_Mother"
        Me.Text = "Report Booking Summary (Mother)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgdResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboWeek As System.Windows.Forms.ComboBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents dgdResult As System.Windows.Forms.DataGridView
    Friend WithEvents chkVesselFind As System.Windows.Forms.RadioButton
    Friend WithEvents chkDateFind As System.Windows.Forms.RadioButton
    Friend WithEvents Market As System.Windows.Forms.DataGridViewTextBoxColumn
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
End Class
