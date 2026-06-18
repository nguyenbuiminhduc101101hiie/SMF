<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckContainerMTMoving
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdBrowse = New System.Windows.Forms.Button
        Me.cmdCheck = New System.Windows.Forms.Button
        Me.txtSheetName = New System.Windows.Forms.TextBox
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.grbProcess = New System.Windows.Forms.GroupBox
        Me.pgbCheck = New System.Windows.Forms.ProgressBar
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateExe = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusCheck = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Condition = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox2.SuspendLayout()
        Me.grbProcess.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 73)
        Me.GroupBox2.TabIndex = 11
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
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'grbProcess
        '
        Me.grbProcess.Controls.Add(Me.pgbCheck)
        Me.grbProcess.Location = New System.Drawing.Point(21, 22)
        Me.grbProcess.Name = "grbProcess"
        Me.grbProcess.Size = New System.Drawing.Size(442, 49)
        Me.grbProcess.TabIndex = 12
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
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContainerNo, Me.Status, Me.DateExe, Me.StatusCheck, Me.Condition})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 88)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(471, 283)
        Me.DataGridView1.TabIndex = 13
        '
        'ContainerNo
        '
        Me.ContainerNo.HeaderText = "ContainerNo"
        Me.ContainerNo.Name = "ContainerNo"
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.Name = "Status"
        '
        'DateExe
        '
        Me.DateExe.HeaderText = "Date Exe."
        Me.DateExe.Name = "DateExe"
        '
        'StatusCheck
        '
        Me.StatusCheck.HeaderText = "Check status"
        Me.StatusCheck.Name = "StatusCheck"
        '
        'Condition
        '
        Me.Condition.HeaderText = "Condition"
        Me.Condition.Name = "Condition"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(388, 377)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Excel"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmCheckContainerstandardform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 409)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grbProcess)
        Me.Name = "frmCheckContainerstandardform"
        Me.Text = "Check Container"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.grbProcess.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdBrowse As System.Windows.Forms.Button
    Friend WithEvents cmdCheck As System.Windows.Forms.Button
    Friend WithEvents txtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents grbProcess As System.Windows.Forms.GroupBox
    Friend WithEvents pgbCheck As System.Windows.Forms.ProgressBar
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateExe As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusCheck As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Condition As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
