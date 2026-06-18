<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChart))
        Me.AxMSChart1 = New AxMSChart20Lib.AxMSChart
        Me.cmdexit = New System.Windows.Forms.Button
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.pd = New System.Drawing.Printing.PrintDocument
        CType(Me.AxMSChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxMSChart1
        '
        Me.AxMSChart1.DataSource = Nothing
        Me.AxMSChart1.Location = New System.Drawing.Point(29, 29)
        Me.AxMSChart1.Name = "AxMSChart1"
        Me.AxMSChart1.OcxState = CType(resources.GetObject("AxMSChart1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSChart1.Size = New System.Drawing.Size(835, 418)
        Me.AxMSChart1.TabIndex = 0
        '
        'cmdexit
        '
        Me.cmdexit.Location = New System.Drawing.Point(403, 454)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 23)
        Me.cmdexit.TabIndex = 1
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(484, 454)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrint.TabIndex = 2
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
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
        'frmChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 489)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.AxMSChart1)
        Me.Name = "frmChart"
        Me.Text = "Charting (Carrier - Service)"
        CType(Me.AxMSChart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxMSChart1 As AxMSChart20Lib.AxMSChart
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents pd As System.Drawing.Printing.PrintDocument
End Class
