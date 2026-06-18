<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraphInBound
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
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVessel = New System.Windows.Forms.Label
        Me.dtpLeavingDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cboYear = New System.Windows.Forms.ComboBox
        Me.cmdOkMonth = New System.Windows.Forms.Button
        Me.cboMonth = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.BL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.cmdGraph = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.cboVessel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblVessel)
        Me.GroupBox1.Controls.Add(Me.dtpLeavingDate)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(387, 122)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Choose Vessel/ETD"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(290, 92)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 293
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(95, 28)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(270, 21)
        Me.cboVessel.TabIndex = 288
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(57, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 289
        Me.Label1.Text = "ETD :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.BackColor = System.Drawing.Color.Transparent
        Me.lblVessel.ForeColor = System.Drawing.Color.Blue
        Me.lblVessel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVessel.Location = New System.Drawing.Point(8, 30)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(87, 13)
        Me.lblVessel.TabIndex = 290
        Me.lblVessel.Text = "Vessel / VoyNo :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLeavingDate.Location = New System.Drawing.Point(95, 53)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpLeavingDate.TabIndex = 291
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cboYear)
        Me.GroupBox2.Controls.Add(Me.cmdOkMonth)
        Me.GroupBox2.Controls.Add(Me.cboMonth)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(401, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(295, 122)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Choose Month"
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(67, 65)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(77, 21)
        Me.cboYear.TabIndex = 291
        '
        'cmdOkMonth
        '
        Me.cmdOkMonth.Location = New System.Drawing.Point(193, 93)
        Me.cmdOkMonth.Name = "cmdOkMonth"
        Me.cmdOkMonth.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkMonth.TabIndex = 293
        Me.cmdOkMonth.Text = "&Ok"
        Me.cmdOkMonth.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"})
        Me.cboMonth.Location = New System.Drawing.Point(67, 29)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(77, 21)
        Me.cboMonth.TabIndex = 291
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(18, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "Month :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(18, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 289
        Me.Label3.Text = "Year  :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BL_ID})
        Me.dgdData.Location = New System.Drawing.Point(8, 175)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(688, 289)
        Me.dgdData.TabIndex = 2
        '
        'BL_ID
        '
        Me.BL_ID.HeaderText = "BL_ID"
        Me.BL_ID.Name = "BL_ID"
        Me.BL_ID.ReadOnly = True
        Me.BL_ID.Visible = False
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(512, 146)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 3
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdcancel
        '
        Me.cmdcancel.Location = New System.Drawing.Point(431, 146)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdcancel.TabIndex = 3
        Me.cmdcancel.Text = "Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'cmdGraph
        '
        Me.cmdGraph.Location = New System.Drawing.Point(594, 146)
        Me.cmdGraph.Name = "cmdGraph"
        Me.cmdGraph.Size = New System.Drawing.Size(75, 23)
        Me.cmdGraph.TabIndex = 4
        Me.cmdGraph.Text = "Graph"
        Me.cmdGraph.UseVisualStyleBackColor = True
        '
        'frmGraphInBound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 476)
        Me.Controls.Add(Me.cmdGraph)
        Me.Controls.Add(Me.cmdcancel)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmGraphInBound"
        Me.Text = "frmGraphOutBound"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboYear As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOkMonth As System.Windows.Forms.Button
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents BL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdGraph As System.Windows.Forms.Button
End Class
