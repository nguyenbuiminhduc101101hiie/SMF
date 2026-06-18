<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComparePortInbound
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComparePortInbound))
        Me.Label6 = New System.Windows.Forms.Label
        Me.dgdInboundData = New System.Windows.Forms.DataGridView
        Me.dgdPortData = New System.Windows.Forms.DataGridView
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdBrowser = New System.Windows.Forms.Button
        Me.txtFileName = New System.Windows.Forms.TextBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpFromETA = New System.Windows.Forms.DateTimePicker
        Me.dtpToETA = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtSheetName = New System.Windows.Forms.TextBox
        Me.cmdExportExcelPort = New System.Windows.Forms.Button
        Me.cmdExportExcelInbound = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        CType(Me.dgdInboundData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdPortData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label6.Location = New System.Drawing.Point(322, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "File Name :"
        '
        'dgdInboundData
        '
        Me.dgdInboundData.AllowUserToAddRows = False
        Me.dgdInboundData.AllowUserToDeleteRows = False
        Me.dgdInboundData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdInboundData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgdInboundData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdInboundData.Location = New System.Drawing.Point(6, 51)
        Me.dgdInboundData.Name = "dgdInboundData"
        Me.dgdInboundData.ReadOnly = True
        Me.dgdInboundData.Size = New System.Drawing.Size(269, 189)
        Me.dgdInboundData.TabIndex = 7
        '
        'dgdPortData
        '
        Me.dgdPortData.AllowUserToAddRows = False
        Me.dgdPortData.AllowUserToDeleteRows = False
        Me.dgdPortData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdPortData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgdPortData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPortData.Location = New System.Drawing.Point(10, 51)
        Me.dgdPortData.Name = "dgdPortData"
        Me.dgdPortData.ReadOnly = True
        Me.dgdPortData.Size = New System.Drawing.Size(255, 186)
        Me.dgdPortData.TabIndex = 8
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(489, 67)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 9
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(408, 67)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 10
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBrowser
        '
        Me.cmdBrowser.Location = New System.Drawing.Point(489, 10)
        Me.cmdBrowser.Name = "cmdBrowser"
        Me.cmdBrowser.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowser.TabIndex = 11
        Me.cmdBrowser.Text = "&Browser"
        Me.cmdBrowser.UseVisualStyleBackColor = True
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(384, 11)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(100, 20)
        Me.txtFileName.TabIndex = 12
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "(*.xls)|*.xls"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(50, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "From (ETA) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(63, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "To(ETA) :"
        '
        'dtpFromETA
        '
        Me.dtpFromETA.Location = New System.Drawing.Point(118, 11)
        Me.dtpFromETA.Name = "dtpFromETA"
        Me.dtpFromETA.Size = New System.Drawing.Size(186, 20)
        Me.dtpFromETA.TabIndex = 16
        '
        'dtpToETA
        '
        Me.dtpToETA.Location = New System.Drawing.Point(118, 37)
        Me.dtpToETA.Name = "dtpToETA"
        Me.dtpToETA.Size = New System.Drawing.Size(186, 20)
        Me.dtpToETA.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(8, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Vessel /Voyno /ETA:"
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(118, 63)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(186, 21)
        Me.cboVessel.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label7.Location = New System.Drawing.Point(309, 41)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Sheet Name :"
        '
        'txtSheetName
        '
        Me.txtSheetName.Location = New System.Drawing.Point(384, 38)
        Me.txtSheetName.Name = "txtSheetName"
        Me.txtSheetName.Size = New System.Drawing.Size(100, 20)
        Me.txtSheetName.TabIndex = 20
        Me.txtSheetName.Text = "Sheet1"
        '
        'cmdExportExcelPort
        '
        Me.cmdExportExcelPort.Location = New System.Drawing.Point(190, 22)
        Me.cmdExportExcelPort.Name = "cmdExportExcelPort"
        Me.cmdExportExcelPort.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcelPort.TabIndex = 21
        Me.cmdExportExcelPort.Text = "Export Excel"
        Me.cmdExportExcelPort.UseVisualStyleBackColor = True
        '
        'cmdExportExcelInbound
        '
        Me.cmdExportExcelInbound.Location = New System.Drawing.Point(200, 22)
        Me.cmdExportExcelInbound.Name = "cmdExportExcelInbound"
        Me.cmdExportExcelInbound.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcelInbound.TabIndex = 22
        Me.cmdExportExcelInbound.Text = "Export Excel"
        Me.cmdExportExcelInbound.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgdInboundData)
        Me.GroupBox1.Controls.Add(Me.cmdExportExcelInbound)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(281, 274)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Inbound data"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.cmdExportExcelPort)
        Me.GroupBox2.Controls.Add(Me.dgdPortData)
        Me.GroupBox2.Location = New System.Drawing.Point(299, 93)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(274, 274)
        Me.GroupBox2.TabIndex = 24
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Terminal data"
        '
        'frmComparePortInbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 385)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtSheetName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFromETA)
        Me.Controls.Add(Me.dtpToETA)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.txtFileName)
        Me.Controls.Add(Me.cmdBrowser)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Label6)
        Me.ForeColor = System.Drawing.Color.DarkBlue
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmComparePortInbound"
        Me.Text = "Compare Port - Inbound"
        CType(Me.dgdInboundData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdPortData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgdInboundData As System.Windows.Forms.DataGridView
    Friend WithEvents dgdPortData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBrowser As System.Windows.Forms.Button
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFromETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents cmdExportExcelPort As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcelInbound As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
