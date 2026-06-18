<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChartProfitIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChartProfitIn))
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.chkUSD = New System.Windows.Forms.RadioButton
        Me.cmdOK = New System.Windows.Forms.Button
        Me.pd = New System.Drawing.Printing.PrintDocument
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.cmdprint = New System.Windows.Forms.Button
        Me.cmdExit = New System.Windows.Forms.Button
        Me.AxMSChart1 = New AxMSChartLib.AxMSChart
        CType(Me.AxMSChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(308, 28)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(48, 17)
        Me.RadioButton1.TabIndex = 28
        Me.RadioButton1.Text = "VND"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'chkUSD
        '
        Me.chkUSD.AutoSize = True
        Me.chkUSD.Checked = True
        Me.chkUSD.Location = New System.Drawing.Point(308, 7)
        Me.chkUSD.Name = "chkUSD"
        Me.chkUSD.Size = New System.Drawing.Size(48, 17)
        Me.chkUSD.TabIndex = 27
        Me.chkUSD.TabStop = True
        Me.chkUSD.Text = "USD"
        Me.chkUSD.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(396, 14)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 26
        Me.cmdOK.Text = "Ok"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'pd
        '
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(182, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "To :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "From :"
        '
        'dtpTo
        '
        Me.dtpTo.CustomFormat = "MMM-yyyy"
        Me.dtpTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTo.Location = New System.Drawing.Point(214, 14)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(88, 24)
        Me.dtpTo.TabIndex = 23
        '
        'dtpFrom
        '
        Me.dtpFrom.CustomFormat = "MMM-yyyy"
        Me.dtpFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFrom.Location = New System.Drawing.Point(59, 14)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(107, 24)
        Me.dtpFrom.TabIndex = 22
        '
        'cmdprint
        '
        Me.cmdprint.Location = New System.Drawing.Point(477, 14)
        Me.cmdprint.Name = "cmdprint"
        Me.cmdprint.Size = New System.Drawing.Size(75, 23)
        Me.cmdprint.TabIndex = 21
        Me.cmdprint.Text = "Print"
        Me.cmdprint.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Location = New System.Drawing.Point(558, 14)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(75, 23)
        Me.cmdExit.TabIndex = 20
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'AxMSChart1
        '
        Me.AxMSChart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AxMSChart1.DataSource = Nothing
        Me.AxMSChart1.Location = New System.Drawing.Point(20, 40)
        Me.AxMSChart1.Name = "AxMSChart1"
        Me.AxMSChart1.OcxState = CType(resources.GetObject("AxMSChart1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSChart1.Size = New System.Drawing.Size(790, 442)
        Me.AxMSChart1.TabIndex = 19
        '
        'frmChartProfitIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 502)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.chkUSD)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.cmdprint)
        Me.Controls.Add(Me.cmdExit)
        Me.Controls.Add(Me.AxMSChart1)
        Me.Name = "frmChartProfitIn"
        Me.Text = "Chart Profit In"
        CType(Me.AxMSChart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents chkUSD As System.Windows.Forms.RadioButton
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents pd As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdprint As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents AxMSChart1 As AxMSChartLib.AxMSChart
End Class
