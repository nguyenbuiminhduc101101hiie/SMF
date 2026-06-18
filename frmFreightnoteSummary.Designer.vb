<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFreightnoteSummary
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
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVessel = New System.Windows.Forms.Label
        Me.dtpLeavingDate = New System.Windows.Forms.DateTimePicker
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtpToETD = New System.Windows.Forms.DateTimePicker
        Me.cmdOkPayer = New System.Windows.Forms.Button
        Me.cmdAllPayer = New System.Windows.Forms.Button
        Me.dtpFromETD = New System.Windows.Forms.DateTimePicker
        Me.cboPayer = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgddata = New System.Windows.Forms.DataGridView
        Me.BookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Payer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OceanFreight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctxFind = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.FindToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.grpSearch = New System.Windows.Forms.GroupBox
        Me.cdmCancelFind = New System.Windows.Forms.Button
        Me.cmdFindNext = New System.Windows.Forms.Button
        Me.txtSearchText = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgddata, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxFind.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(215, 70)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 293
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(101, 19)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(189, 21)
        Me.cboVessel.TabIndex = 288
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(63, 47)
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
        Me.lblVessel.Location = New System.Drawing.Point(14, 21)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(87, 13)
        Me.lblVessel.TabIndex = 290
        Me.lblVessel.Text = "Vessel / VoyNo :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLeavingDate.Location = New System.Drawing.Point(101, 44)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpLeavingDate.TabIndex = 291
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(446, 143)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 292
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.Controls.Add(Me.dtpToETD)
        Me.GroupBox2.Controls.Add(Me.cmdOkPayer)
        Me.GroupBox2.Controls.Add(Me.cmdAllPayer)
        Me.GroupBox2.Controls.Add(Me.dtpFromETD)
        Me.GroupBox2.Controls.Add(Me.cboPayer)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(318, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(284, 131)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Payer Info"
        '
        'dtpToETD
        '
        Me.dtpToETD.Location = New System.Drawing.Point(74, 74)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(200, 20)
        Me.dtpToETD.TabIndex = 291
        '
        'cmdOkPayer
        '
        Me.cmdOkPayer.Location = New System.Drawing.Point(199, 102)
        Me.cmdOkPayer.Name = "cmdOkPayer"
        Me.cmdOkPayer.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkPayer.TabIndex = 293
        Me.cmdOkPayer.Text = "&Ok"
        Me.cmdOkPayer.UseVisualStyleBackColor = True
        '
        'cmdAllPayer
        '
        Me.cmdAllPayer.Location = New System.Drawing.Point(116, 103)
        Me.cmdAllPayer.Name = "cmdAllPayer"
        Me.cmdAllPayer.Size = New System.Drawing.Size(75, 23)
        Me.cmdAllPayer.TabIndex = 292
        Me.cmdAllPayer.Text = "All Payer"
        Me.cmdAllPayer.UseVisualStyleBackColor = True
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Location = New System.Drawing.Point(74, 48)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(200, 20)
        Me.dtpFromETD.TabIndex = 291
        '
        'cboPayer
        '
        Me.cboPayer.FormattingEnabled = True
        Me.cboPayer.Location = New System.Drawing.Point(74, 21)
        Me.cboPayer.Name = "cboPayer"
        Me.cboPayer.Size = New System.Drawing.Size(200, 21)
        Me.cboPayer.TabIndex = 288
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(12, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 289
        Me.Label4.Text = "ETD  (To) :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(32, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 290
        Me.Label2.Text = "Payer :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(5, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 289
        Me.Label3.Text = "ETD (From) :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dgddata
        '
        Me.dgddata.AllowUserToAddRows = False
        Me.dgddata.AllowUserToDeleteRows = False
        Me.dgddata.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgddata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgddata.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookingNo, Me.BL_NO, Me.Payer, Me.OceanFreight})
        Me.dgddata.ContextMenuStrip = Me.ctxFind
        Me.dgddata.Location = New System.Drawing.Point(12, 172)
        Me.dgddata.Name = "dgddata"
        Me.dgddata.ReadOnly = True
        Me.dgddata.Size = New System.Drawing.Size(590, 312)
        Me.dgddata.TabIndex = 293
        '
        'BookingNo
        '
        Me.BookingNo.DataPropertyName = "BookingNo"
        Me.BookingNo.HeaderText = "Booking No"
        Me.BookingNo.Name = "BookingNo"
        Me.BookingNo.ReadOnly = True
        '
        'BL_NO
        '
        Me.BL_NO.DataPropertyName = "BL_NO"
        Me.BL_NO.HeaderText = "B/L No"
        Me.BL_NO.Name = "BL_NO"
        Me.BL_NO.ReadOnly = True
        '
        'Payer
        '
        Me.Payer.DataPropertyName = "Payer"
        Me.Payer.HeaderText = "Payer"
        Me.Payer.Name = "Payer"
        Me.Payer.ReadOnly = True
        '
        'OceanFreight
        '
        Me.OceanFreight.DataPropertyName = "OceanFreight"
        Me.OceanFreight.HeaderText = "Ocean Freight"
        Me.OceanFreight.Name = "OceanFreight"
        Me.OceanFreight.ReadOnly = True
        '
        'ctxFind
        '
        Me.ctxFind.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindToolStripMenuItem})
        Me.ctxFind.Name = "ctxFind"
        Me.ctxFind.Size = New System.Drawing.Size(98, 26)
        '
        'FindToolStripMenuItem
        '
        Me.FindToolStripMenuItem.Name = "FindToolStripMenuItem"
        Me.FindToolStripMenuItem.Size = New System.Drawing.Size(97, 22)
        Me.FindToolStripMenuItem.Text = "Find"
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdExportExcel.Location = New System.Drawing.Point(527, 143)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 292
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.cdmCancelFind)
        Me.grpSearch.Controls.Add(Me.cmdFindNext)
        Me.grpSearch.Controls.Add(Me.txtSearchText)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Location = New System.Drawing.Point(27, 235)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(328, 92)
        Me.grpSearch.TabIndex = 295
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "Search"
        Me.grpSearch.Visible = False
        '
        'cdmCancelFind
        '
        Me.cdmCancelFind.Location = New System.Drawing.Point(160, 56)
        Me.cdmCancelFind.Name = "cdmCancelFind"
        Me.cdmCancelFind.Size = New System.Drawing.Size(75, 23)
        Me.cdmCancelFind.TabIndex = 2
        Me.cdmCancelFind.Text = "Cancel"
        Me.cdmCancelFind.UseVisualStyleBackColor = True
        '
        'cmdFindNext
        '
        Me.cmdFindNext.Location = New System.Drawing.Point(241, 55)
        Me.cmdFindNext.Name = "cmdFindNext"
        Me.cmdFindNext.Size = New System.Drawing.Size(75, 23)
        Me.cmdFindNext.TabIndex = 2
        Me.cmdFindNext.Text = "Next"
        Me.cmdFindNext.UseVisualStyleBackColor = True
        '
        'txtSearchText
        '
        Me.txtSearchText.Location = New System.Drawing.Point(45, 23)
        Me.txtSearchText.Name = "txtSearchText"
        Me.txtSearchText.Size = New System.Drawing.Size(271, 20)
        Me.txtSearchText.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Find :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboVessel)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.dtpLeavingDate)
        Me.GroupBox1.Controls.Add(Me.lblVessel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(303, 104)
        Me.GroupBox1.TabIndex = 296
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vessel Infor"
        '
        'frmFreightnoteSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 515)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.dgddata)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "frmFreightnoteSummary"
        Me.Text = "Freight Note Summary"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgddata, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxFind.ResumeLayout(False)
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cboPayer As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpToETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOkPayer As System.Windows.Forms.Button
    Friend WithEvents dgddata As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdAllPayer As System.Windows.Forms.Button
    Friend WithEvents BookingNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Payer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OceanFreight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ctxFind As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents FindToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents txtSearchText As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cdmCancelFind As System.Windows.Forms.Button
    Friend WithEvents cmdFindNext As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
