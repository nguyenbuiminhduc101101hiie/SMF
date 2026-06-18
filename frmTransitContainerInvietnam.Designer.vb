<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransitContainerInvietnam
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpFromETA = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpToETA = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cdmCancel = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cmdAll = New System.Windows.Forms.Button
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(286, 103)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From ETA :"
        '
        'dtpFromETA
        '
        Me.dtpFromETA.Location = New System.Drawing.Point(67, 16)
        Me.dtpFromETA.Name = "dtpFromETA"
        Me.dtpFromETA.Size = New System.Drawing.Size(200, 20)
        Me.dtpFromETA.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To ETA :"
        '
        'dtpToETA
        '
        Me.dtpToETA.Location = New System.Drawing.Point(331, 19)
        Me.dtpToETA.Name = "dtpToETA"
        Me.dtpToETA.Size = New System.Drawing.Size(200, 20)
        Me.dtpToETA.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFromETA)
        Me.GroupBox1.Controls.Add(Me.dtpToETA)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(590, 85)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cdmCancel
        '
        Me.cdmCancel.Location = New System.Drawing.Point(191, 103)
        Me.cdmCancel.Name = "cdmCancel"
        Me.cdmCancel.Size = New System.Drawing.Size(75, 23)
        Me.cdmCancel.TabIndex = 0
        Me.cdmCancel.Text = "Cancel"
        Me.cdmCancel.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(99, 103)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 0
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdAll
        '
        Me.cmdAll.Location = New System.Drawing.Point(12, 103)
        Me.cmdAll.Name = "cmdAll"
        Me.cmdAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdAll.TabIndex = 0
        Me.cmdAll.Text = "All"
        Me.cmdAll.UseVisualStyleBackColor = True
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Location = New System.Drawing.Point(12, 132)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(597, 268)
        Me.dgdData.TabIndex = 5
        '
        'frmTransitContainerInvietnam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(614, 401)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdAll)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cdmCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Name = "frmTransitContainerInvietnam"
        Me.Text = "Transit Container In (VietNam)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFromETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpToETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cdmCancel As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdAll As System.Windows.Forms.Button
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
End Class
