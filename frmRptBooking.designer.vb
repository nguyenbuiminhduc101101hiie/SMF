<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptBooking
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
        Me.gpbPH = New System.Windows.Forms.GroupBox
        Me.cmdPUHAIOk = New System.Windows.Forms.Button
        Me.chkSOCPH = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.txtVoyNo = New System.Windows.Forms.TextBox
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdOkSHPH = New System.Windows.Forms.Button
        Me.chkSOCSHPH = New System.Windows.Forms.CheckBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cmdOkSE = New System.Windows.Forms.Button
        Me.cboDestSE = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmdOkUSWC = New System.Windows.Forms.Button
        Me.cboDestUSWC = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.lblResult = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmdOkMV = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmdexport = New System.Windows.Forms.Button
        Me.gpbPH.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpbPH
        '
        Me.gpbPH.Controls.Add(Me.cmdPUHAIOk)
        Me.gpbPH.Controls.Add(Me.chkSOCPH)
        Me.gpbPH.ForeColor = System.Drawing.Color.Maroon
        Me.gpbPH.Location = New System.Drawing.Point(55, 55)
        Me.gpbPH.Name = "gpbPH"
        Me.gpbPH.Size = New System.Drawing.Size(214, 53)
        Me.gpbPH.TabIndex = 0
        Me.gpbPH.TabStop = False
        Me.gpbPH.Text = "Daily Report"
        '
        'cmdPUHAIOk
        '
        Me.cmdPUHAIOk.Location = New System.Drawing.Point(93, 15)
        Me.cmdPUHAIOk.Name = "cmdPUHAIOk"
        Me.cmdPUHAIOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdPUHAIOk.TabIndex = 5
        Me.cmdPUHAIOk.Text = "Ok"
        Me.cmdPUHAIOk.UseVisualStyleBackColor = True
        '
        'chkSOCPH
        '
        Me.chkSOCPH.AutoSize = True
        Me.chkSOCPH.Location = New System.Drawing.Point(16, 19)
        Me.chkSOCPH.Name = "chkSOCPH"
        Me.chkSOCPH.Size = New System.Drawing.Size(48, 17)
        Me.chkSOCPH.TabIndex = 4
        Me.chkSOCPH.Text = "SOC"
        Me.chkSOCPH.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vessel :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Voy No :"
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(55, 28)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(214, 21)
        Me.cboVessel.TabIndex = 2
        '
        'txtVoyNo
        '
        Me.txtVoyNo.Location = New System.Drawing.Point(347, 29)
        Me.txtVoyNo.Name = "txtVoyNo"
        Me.txtVoyNo.Size = New System.Drawing.Size(100, 20)
        Me.txtVoyNo.TabIndex = 1
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HotTrack
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Location = New System.Drawing.Point(54, 311)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(573, 132)
        Me.dgdData.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdOkSHPH)
        Me.GroupBox2.Controls.Add(Me.chkSOCSHPH)
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Location = New System.Drawing.Point(300, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(220, 53)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Daily Report 2"
        '
        'cmdOkSHPH
        '
        Me.cmdOkSHPH.Location = New System.Drawing.Point(112, 20)
        Me.cmdOkSHPH.Name = "cmdOkSHPH"
        Me.cmdOkSHPH.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkSHPH.TabIndex = 5
        Me.cmdOkSHPH.Text = "Ok"
        Me.cmdOkSHPH.UseVisualStyleBackColor = True
        '
        'chkSOCSHPH
        '
        Me.chkSOCSHPH.AutoSize = True
        Me.chkSOCSHPH.Location = New System.Drawing.Point(24, 23)
        Me.chkSOCSHPH.Name = "chkSOCSHPH"
        Me.chkSOCSHPH.Size = New System.Drawing.Size(48, 17)
        Me.chkSOCSHPH.TabIndex = 4
        Me.chkSOCSHPH.Text = "SOC"
        Me.chkSOCSHPH.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmdOkSE)
        Me.GroupBox4.Controls.Add(Me.cboDestSE)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.ForeColor = System.Drawing.Color.ForestGreen
        Me.GroupBox4.Location = New System.Drawing.Point(54, 115)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(276, 67)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "DAILY BOOKING REPORT OF SOUTHEASTASIA "
        '
        'cmdOkSE
        '
        Me.cmdOkSE.Location = New System.Drawing.Point(185, 29)
        Me.cmdOkSE.Name = "cmdOkSE"
        Me.cmdOkSE.Size = New System.Drawing.Size(76, 23)
        Me.cmdOkSE.TabIndex = 5
        Me.cmdOkSE.Text = "Ok"
        Me.cmdOkSE.UseVisualStyleBackColor = True
        '
        'cboDestSE
        '
        Me.cboDestSE.FormattingEnabled = True
        Me.cboDestSE.Location = New System.Drawing.Point(59, 31)
        Me.cboDestSE.MaxLength = 5
        Me.cboDestSE.Name = "cboDestSE"
        Me.cboDestSE.Size = New System.Drawing.Size(110, 21)
        Me.cboDestSE.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(14, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(42, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "DEST :"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TextBox1)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.cmdOkUSWC)
        Me.GroupBox5.Controls.Add(Me.cboDestUSWC)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox5.Location = New System.Drawing.Point(54, 189)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(573, 76)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "USWC"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(235, 19)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(247, 49)
        Me.TextBox1.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(179, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Customer :"
        '
        'cmdOkUSWC
        '
        Me.cmdOkUSWC.Location = New System.Drawing.Point(493, 19)
        Me.cmdOkUSWC.Name = "cmdOkUSWC"
        Me.cmdOkUSWC.Size = New System.Drawing.Size(75, 23)
        Me.cmdOkUSWC.TabIndex = 5
        Me.cmdOkUSWC.Text = "Ok"
        Me.cmdOkUSWC.UseVisualStyleBackColor = True
        '
        'cboDestUSWC
        '
        Me.cboDestUSWC.FormattingEnabled = True
        Me.cboDestUSWC.Location = New System.Drawing.Point(59, 19)
        Me.cboDestUSWC.MaxLength = 5
        Me.cboDestUSWC.Name = "cboDestUSWC"
        Me.cboDestUSWC.Size = New System.Drawing.Size(110, 21)
        Me.cboDestUSWC.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 23)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "DEST :"
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Location = New System.Drawing.Point(5, 295)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(43, 13)
        Me.lblResult.TabIndex = 0
        Me.lblResult.Text = "Result :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(670, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'cmdOkMV
        '
        Me.cmdOkMV.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOkMV.Location = New System.Drawing.Point(65, 28)
        Me.cmdOkMV.Name = "cmdOkMV"
        Me.cmdOkMV.Size = New System.Drawing.Size(164, 24)
        Me.cmdOkMV.TabIndex = 5
        Me.cmdOkMV.Text = "Daily Booking of  MV"
        Me.cmdOkMV.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmdOkMV)
        Me.GroupBox3.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox3.Location = New System.Drawing.Point(347, 115)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(280, 67)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "DAILY BOOKING OF MV"
        '
        'cmdexport
        '
        Me.cmdexport.Location = New System.Drawing.Point(539, 278)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(88, 23)
        Me.cmdexport.TabIndex = 6
        Me.cmdexport.Text = "Export (.XLS)"
        Me.cmdexport.UseVisualStyleBackColor = True
        '
        'frmRptBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(670, 461)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.txtVoyNo)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gpbPH)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.Maroon
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(814, 653)
        Me.Name = "frmRptBooking"
        Me.Text = "Booking Report"
        Me.gpbPH.ResumeLayout(False)
        Me.gpbPH.PerformLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpbPH As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdPUHAIOk As System.Windows.Forms.Button
    Friend WithEvents txtVoyNo As System.Windows.Forms.TextBox
    Friend WithEvents chkSOCPH As System.Windows.Forms.CheckBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOkSHPH As System.Windows.Forms.Button
    Friend WithEvents chkSOCSHPH As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOkSE As System.Windows.Forms.Button
    Friend WithEvents cboDestSE As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdOkUSWC As System.Windows.Forms.Button
    Friend WithEvents cboDestUSWC As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblResult As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdOkMV As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdexport As System.Windows.Forms.Button
End Class
