<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransitContainerOut
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
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dtpFromETD = New System.Windows.Forms.DateTimePicker
        Me.dtpToETD = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdAll = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cdmCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.dgdData.Size = New System.Drawing.Size(587, 305)
        Me.dgdData.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpFromETD)
        Me.GroupBox1.Controls.Add(Me.dtpToETD)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(587, 85)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'dtpFromETD
        '
        Me.dtpFromETD.Location = New System.Drawing.Point(67, 16)
        Me.dtpFromETD.Name = "dtpFromETD"
        Me.dtpFromETD.Size = New System.Drawing.Size(200, 20)
        Me.dtpFromETD.TabIndex = 3
        '
        'dtpToETD
        '
        Me.dtpToETD.Location = New System.Drawing.Point(331, 19)
        Me.dtpToETD.Name = "dtpToETD"
        Me.dtpToETD.Size = New System.Drawing.Size(200, 20)
        Me.dtpToETD.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From ETD :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(280, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To ETD :"
        '
        'cmdAll
        '
        Me.cmdAll.Location = New System.Drawing.Point(12, 103)
        Me.cmdAll.Name = "cmdAll"
        Me.cmdAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdAll.TabIndex = 9
        Me.cmdAll.Text = "All"
        Me.cmdAll.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(99, 103)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 6
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cdmCancel
        '
        Me.cdmCancel.Location = New System.Drawing.Point(191, 103)
        Me.cdmCancel.Name = "cdmCancel"
        Me.cdmCancel.Size = New System.Drawing.Size(75, 23)
        Me.cdmCancel.TabIndex = 7
        Me.cdmCancel.Text = "Cancel"
        Me.cdmCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(286, 103)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'frmTransitContainerOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(611, 449)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdAll)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cdmCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Name = "frmTransitContainerOut"
        Me.Text = "Transit Container Out"
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFromETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpToETD As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdAll As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cdmCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
End Class
