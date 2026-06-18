<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChartRate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChartRate))
        Me.cmdPrint = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.AxMSChart1 = New AxMSChart20Lib.AxMSChart
        Me.pd = New System.Drawing.Printing.PrintDocument
        CType(Me.AxMSChart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdPrint
        '
        Me.cmdPrint.Location = New System.Drawing.Point(469, 477)
        Me.cmdPrint.Name = "cmdPrint"
        Me.cmdPrint.Size = New System.Drawing.Size(75, 23)
        Me.cmdPrint.TabIndex = 5
        Me.cmdPrint.Text = "Print"
        Me.cmdPrint.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Location = New System.Drawing.Point(388, 477)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 23)
        Me.cmdexit.TabIndex = 4
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'AxMSChart1
        '
        Me.AxMSChart1.DataSource = Nothing
        Me.AxMSChart1.Location = New System.Drawing.Point(12, 12)
        Me.AxMSChart1.Name = "AxMSChart1"
        Me.AxMSChart1.OcxState = CType(resources.GetObject("AxMSChart1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxMSChart1.Size = New System.Drawing.Size(888, 459)
        Me.AxMSChart1.TabIndex = 3
        '
        'pd
        '
        '
        'frmChartRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(912, 512)
        Me.Controls.Add(Me.cmdPrint)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.AxMSChart1)
        Me.Name = "frmChartRate"
        Me.Text = "Charting Rate Details"
        CType(Me.AxMSChart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdPrint As System.Windows.Forms.Button
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents AxMSChart1 As AxMSChart20Lib.AxMSChart
    Friend WithEvents pd As System.Drawing.Printing.PrintDocument
End Class
