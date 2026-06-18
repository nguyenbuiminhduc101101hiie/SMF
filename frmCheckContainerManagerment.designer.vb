<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckContainerManagerment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckContainerManagerment))
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.cmdOk = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkEmptyExpotAtQuay = New System.Windows.Forms.RadioButton
        Me.chkEmptyToShipper = New System.Windows.Forms.RadioButton
        Me.chkFullExportAtQuay = New System.Windows.Forms.RadioButton
        Me.chkFullToConsignee = New System.Windows.Forms.RadioButton
        Me.chkDamage = New System.Windows.Forms.RadioButton
        Me.chkEmptyForRepostioned = New System.Windows.Forms.RadioButton
        Me.chkFullImports = New System.Windows.Forms.RadioButton
        Me.chkToBeInspected = New System.Windows.Forms.RadioButton
        Me.chkSoundContainer = New System.Windows.Forms.RadioButton
        Me.chkPhucLong = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdExcel = New System.Windows.Forms.Button
        Me.grbProcess = New System.Windows.Forms.GroupBox
        Me.pgbCheck = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdCheck = New System.Windows.Forms.Button
        Me.txtSheetName = New System.Windows.Forms.TextBox
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grbProcess.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Excel Files (*.xls)|*.xls"
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdOk.Location = New System.Drawing.Point(226, 198)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        Me.cmdOk.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 227)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(509, 237)
        Me.DataGridView1.TabIndex = 6
        Me.DataGridView1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkEmptyExpotAtQuay)
        Me.GroupBox1.Controls.Add(Me.chkEmptyToShipper)
        Me.GroupBox1.Controls.Add(Me.chkFullExportAtQuay)
        Me.GroupBox1.Controls.Add(Me.chkFullToConsignee)
        Me.GroupBox1.Controls.Add(Me.chkDamage)
        Me.GroupBox1.Controls.Add(Me.chkEmptyForRepostioned)
        Me.GroupBox1.Controls.Add(Me.chkFullImports)
        Me.GroupBox1.Controls.Add(Me.chkToBeInspected)
        Me.GroupBox1.Controls.Add(Me.chkSoundContainer)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(6, 91)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(506, 98)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Visible = False
        '
        'chkEmptyExpotAtQuay
        '
        Me.chkEmptyExpotAtQuay.AutoSize = True
        Me.chkEmptyExpotAtQuay.ForeColor = System.Drawing.Color.Blue
        Me.chkEmptyExpotAtQuay.Location = New System.Drawing.Point(314, 18)
        Me.chkEmptyExpotAtQuay.Name = "chkEmptyExpotAtQuay"
        Me.chkEmptyExpotAtQuay.Size = New System.Drawing.Size(128, 17)
        Me.chkEmptyExpotAtQuay.TabIndex = 32
        Me.chkEmptyExpotAtQuay.TabStop = True
        Me.chkEmptyExpotAtQuay.Text = "Empty Export At Quay"
        Me.chkEmptyExpotAtQuay.UseVisualStyleBackColor = True
        '
        'chkEmptyToShipper
        '
        Me.chkEmptyToShipper.AutoSize = True
        Me.chkEmptyToShipper.Location = New System.Drawing.Point(195, 59)
        Me.chkEmptyToShipper.Name = "chkEmptyToShipper"
        Me.chkEmptyToShipper.Size = New System.Drawing.Size(112, 17)
        Me.chkEmptyToShipper.TabIndex = 29
        Me.chkEmptyToShipper.Text = "Empty To Shipper "
        Me.chkEmptyToShipper.UseVisualStyleBackColor = True
        '
        'chkFullExportAtQuay
        '
        Me.chkFullExportAtQuay.AutoSize = True
        Me.chkFullExportAtQuay.Location = New System.Drawing.Point(318, 61)
        Me.chkFullExportAtQuay.Name = "chkFullExportAtQuay"
        Me.chkFullExportAtQuay.Size = New System.Drawing.Size(118, 17)
        Me.chkFullExportAtQuay.TabIndex = 30
        Me.chkFullExportAtQuay.Text = "Full Export At Quay "
        Me.chkFullExportAtQuay.UseVisualStyleBackColor = True
        '
        'chkFullToConsignee
        '
        Me.chkFullToConsignee.AutoSize = True
        Me.chkFullToConsignee.Location = New System.Drawing.Point(195, 38)
        Me.chkFullToConsignee.Name = "chkFullToConsignee"
        Me.chkFullToConsignee.Size = New System.Drawing.Size(113, 17)
        Me.chkFullToConsignee.TabIndex = 31
        Me.chkFullToConsignee.Text = "Full To Consignee "
        Me.chkFullToConsignee.UseVisualStyleBackColor = True
        '
        'chkDamage
        '
        Me.chkDamage.AutoSize = True
        Me.chkDamage.Location = New System.Drawing.Point(195, 18)
        Me.chkDamage.Name = "chkDamage"
        Me.chkDamage.Size = New System.Drawing.Size(68, 17)
        Me.chkDamage.TabIndex = 28
        Me.chkDamage.Text = "Damage "
        Me.chkDamage.UseVisualStyleBackColor = True
        '
        'chkEmptyForRepostioned
        '
        Me.chkEmptyForRepostioned.AutoSize = True
        Me.chkEmptyForRepostioned.Location = New System.Drawing.Point(6, 59)
        Me.chkEmptyForRepostioned.Name = "chkEmptyForRepostioned"
        Me.chkEmptyForRepostioned.Size = New System.Drawing.Size(163, 17)
        Me.chkEmptyForRepostioned.TabIndex = 25
        Me.chkEmptyForRepostioned.Text = "Container Tobe Repositioned"
        Me.chkEmptyForRepostioned.UseVisualStyleBackColor = True
        '
        'chkFullImports
        '
        Me.chkFullImports.AutoSize = True
        Me.chkFullImports.Location = New System.Drawing.Point(314, 38)
        Me.chkFullImports.Name = "chkFullImports"
        Me.chkFullImports.Size = New System.Drawing.Size(122, 17)
        Me.chkFullImports.TabIndex = 24
        Me.chkFullImports.Text = "Full Imports At Quay "
        Me.chkFullImports.UseVisualStyleBackColor = True
        '
        'chkToBeInspected
        '
        Me.chkToBeInspected.AutoSize = True
        Me.chkToBeInspected.Location = New System.Drawing.Point(8, 38)
        Me.chkToBeInspected.Name = "chkToBeInspected"
        Me.chkToBeInspected.Size = New System.Drawing.Size(161, 17)
        Me.chkToBeInspected.TabIndex = 27
        Me.chkToBeInspected.Text = "To Be Inspected (Container) "
        Me.chkToBeInspected.UseVisualStyleBackColor = True
        '
        'chkSoundContainer
        '
        Me.chkSoundContainer.AutoSize = True
        Me.chkSoundContainer.Location = New System.Drawing.Point(8, 19)
        Me.chkSoundContainer.Name = "chkSoundContainer"
        Me.chkSoundContainer.Size = New System.Drawing.Size(107, 17)
        Me.chkSoundContainer.TabIndex = 26
        Me.chkSoundContainer.Text = "Sound Container "
        Me.chkSoundContainer.UseVisualStyleBackColor = True
        '
        'chkPhucLong
        '
        Me.chkPhucLong.AutoSize = True
        Me.chkPhucLong.Location = New System.Drawing.Point(6, 77)
        Me.chkPhucLong.Name = "chkPhucLong"
        Me.chkPhucLong.Size = New System.Drawing.Size(115, 17)
        Me.chkPhucLong.TabIndex = 8
        Me.chkPhucLong.Text = "From PHUC LONG"
        Me.chkPhucLong.UseVisualStyleBackColor = True
        Me.chkPhucLong.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label3.Location = New System.Drawing.Point(410, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "File (.xls)"
        Me.ToolTip1.SetToolTip(Me.Label3, resources.GetString("Label3.ToolTip"))
        Me.Label3.Visible = False
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 500000000
        Me.ToolTip1.AutoPopDelay = 500000000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 50
        '
        'cmdExcel
        '
        Me.cmdExcel.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdExcel.Location = New System.Drawing.Point(356, 195)
        Me.cmdExcel.Name = "cmdExcel"
        Me.cmdExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExcel.TabIndex = 4
        Me.cmdExcel.Text = "&Export Excel"
        Me.cmdExcel.UseVisualStyleBackColor = True
        Me.cmdExcel.Visible = False
        '
        'grbProcess
        '
        Me.grbProcess.Controls.Add(Me.pgbCheck)
        Me.grbProcess.Location = New System.Drawing.Point(19, 5)
        Me.grbProcess.Name = "grbProcess"
        Me.grbProcess.Size = New System.Drawing.Size(442, 49)
        Me.grbProcess.TabIndex = 9
        Me.grbProcess.TabStop = False
        Me.grbProcess.Text = "please wait ..."
        '
        'pgbCheck
        '
        Me.pgbCheck.Location = New System.Drawing.Point(27, 17)
        Me.pgbCheck.Name = "pgbCheck"
        Me.pgbCheck.Size = New System.Drawing.Size(402, 23)
        Me.pgbCheck.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmdCancel)
        Me.GroupBox2.Controls.Add(Me.cmdBrowse)
        Me.GroupBox2.Controls.Add(Me.cmdCheck)
        Me.GroupBox2.Controls.Add(Me.txtSheetName)
        Me.GroupBox2.Controls.Add(Me.txtFilename)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 73)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdCancel.Location = New System.Drawing.Point(292, 43)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdBrowse
        '
        Me.cmdBrowse.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdBrowse.Location = New System.Drawing.Point(392, 14)
        Me.cmdBrowse.Name = "cmdBrowse"
        Me.cmdBrowse.Size = New System.Drawing.Size(75, 23)
        Me.cmdBrowse.TabIndex = 10
        Me.cmdBrowse.Text = "&Browse"
        Me.cmdBrowse.UseVisualStyleBackColor = True
        '
        'cmdCheck
        '
        Me.cmdCheck.ForeColor = System.Drawing.Color.DarkBlue
        Me.cmdCheck.Location = New System.Drawing.Point(392, 43)
        Me.cmdCheck.Name = "cmdCheck"
        Me.cmdCheck.Size = New System.Drawing.Size(75, 23)
        Me.cmdCheck.TabIndex = 11
        Me.cmdCheck.Text = "&Check"
        Me.cmdCheck.UseVisualStyleBackColor = True
        '
        'txtSheetName
        '
        Me.txtSheetName.Location = New System.Drawing.Point(75, 40)
        Me.txtSheetName.Name = "txtSheetName"
        Me.txtSheetName.Size = New System.Drawing.Size(113, 20)
        Me.txtSheetName.TabIndex = 9
        Me.txtSheetName.Text = "sheet1"
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(75, 14)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(306, 20)
        Me.txtFilename.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label2.Location = New System.Drawing.Point(3, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Sheet Name :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(13, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "File Name :"
        '
        'frmCheckContainerManagerment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(473, 74)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.chkPhucLong)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.cmdExcel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.grbProcess)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmCheckContainerManagerment"
        Me.Text = "Check Container Status"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbProcess.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkPhucLong As System.Windows.Forms.CheckBox
    Friend WithEvents chkEmptyExpotAtQuay As System.Windows.Forms.RadioButton
    Friend WithEvents chkEmptyToShipper As System.Windows.Forms.RadioButton
    Friend WithEvents chkFullExportAtQuay As System.Windows.Forms.RadioButton
    Friend WithEvents chkFullToConsignee As System.Windows.Forms.RadioButton
    Friend WithEvents chkDamage As System.Windows.Forms.RadioButton
    Friend WithEvents chkEmptyForRepostioned As System.Windows.Forms.RadioButton
    Friend WithEvents chkFullImports As System.Windows.Forms.RadioButton
    Friend WithEvents chkToBeInspected As System.Windows.Forms.RadioButton
    Friend WithEvents chkSoundContainer As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdExcel As System.Windows.Forms.Button
    Friend WithEvents grbProcess As System.Windows.Forms.GroupBox
    Friend WithEvents pgbCheck As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdCheck As System.Windows.Forms.Button
    Friend WithEvents txtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
