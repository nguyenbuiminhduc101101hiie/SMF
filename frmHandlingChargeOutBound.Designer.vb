<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHandlingChargeOutbound
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
        Me.txtFee = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpToETA = New System.Windows.Forms.DateTimePicker
        Me.dtpFromETA = New System.Windows.Forms.DateTimePicker
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.cmdcancel = New System.Windows.Forms.Button
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFee)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpToETA)
        Me.GroupBox1.Controls.Add(Me.dtpFromETA)
        Me.GroupBox1.Controls.Add(Me.cboVessel)
        Me.GroupBox1.Controls.Add(Me.cmdcancel)
        Me.GroupBox1.Controls.Add(Me.cmdExportExcel)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(713, 120)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtFee
        '
        Me.txtFee.Location = New System.Drawing.Point(102, 77)
        Me.txtFee.Name = "txtFee"
        Me.txtFee.Size = New System.Drawing.Size(113, 20)
        Me.txtFee.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Vessel/Voy No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(227, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To (ETA) :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Fee :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From (ETA) :"
        '
        'dtpToETA
        '
        Me.dtpToETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpToETA.Location = New System.Drawing.Point(285, 18)
        Me.dtpToETA.Name = "dtpToETA"
        Me.dtpToETA.Size = New System.Drawing.Size(95, 20)
        Me.dtpToETA.TabIndex = 2
        '
        'dtpFromETA
        '
        Me.dtpFromETA.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFromETA.Location = New System.Drawing.Point(102, 19)
        Me.dtpFromETA.Name = "dtpFromETA"
        Me.dtpFromETA.Size = New System.Drawing.Size(95, 20)
        Me.dtpFromETA.TabIndex = 2
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(102, 50)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(278, 21)
        Me.cboVessel.TabIndex = 3
        '
        'cmdcancel
        '
        Me.cmdcancel.Location = New System.Drawing.Point(461, 80)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdcancel.TabIndex = 4
        Me.cmdcancel.Text = "Cancel"
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(632, 80)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 4
        Me.cmdExportExcel.Text = "Export Excel "
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(547, 80)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 4
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Location = New System.Drawing.Point(12, 138)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(713, 357)
        Me.dgdData.TabIndex = 1
        '
        'frmHandlingChargeInbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(737, 507)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmHandlingChargeInbound"
        Me.Text = "Handling Charge (Inbound)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpToETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFromETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents txtFee As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
End Class
