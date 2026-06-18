<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChartingInbound
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChartingInbound))
        Me.grpFilter = New System.Windows.Forms.GroupBox
        Me.cmdViewTransitGraph = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtpToBookingDate = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkYear = New System.Windows.Forms.RadioButton
        Me.chkDay = New System.Windows.Forms.RadioButton
        Me.chkmonth = New System.Windows.Forms.RadioButton
        Me.picChart = New System.Windows.Forms.PictureBox
        Me.cmdPrintPreview = New System.Windows.Forms.Button
        Me.cmdExportImage = New System.Windows.Forms.Button
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.grpFilter.SuspendLayout()
        CType(Me.picChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilter
        '
        Me.grpFilter.Controls.Add(Me.cmdViewTransitGraph)
        Me.grpFilter.Controls.Add(Me.cmdCancel)
        Me.grpFilter.Controls.Add(Me.cmdOk)
        Me.grpFilter.Controls.Add(Me.Label2)
        Me.grpFilter.Controls.Add(Me.dtpToBookingDate)
        Me.grpFilter.Controls.Add(Me.dtpFrom)
        Me.grpFilter.Controls.Add(Me.Label1)
        Me.grpFilter.Controls.Add(Me.chkYear)
        Me.grpFilter.Controls.Add(Me.chkDay)
        Me.grpFilter.Controls.Add(Me.chkmonth)
        Me.grpFilter.Location = New System.Drawing.Point(11, 12)
        Me.grpFilter.Name = "grpFilter"
        Me.grpFilter.Size = New System.Drawing.Size(749, 88)
        Me.grpFilter.TabIndex = 1
        Me.grpFilter.TabStop = False
        Me.grpFilter.Text = "filter"
        '
        'cmdViewTransitGraph
        '
        Me.cmdViewTransitGraph.Location = New System.Drawing.Point(626, 58)
        Me.cmdViewTransitGraph.Name = "cmdViewTransitGraph"
        Me.cmdViewTransitGraph.Size = New System.Drawing.Size(117, 23)
        Me.cmdViewTransitGraph.TabIndex = 4
        Me.cmdViewTransitGraph.Text = "View Transit Graph"
        Me.cmdViewTransitGraph.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(440, 59)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(86, 23)
        Me.cmdCancel.TabIndex = 3
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(534, 59)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(86, 23)
        Me.cmdOk.TabIndex = 3
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "To  (Booking Date) :"
        '
        'dtpToBookingDate
        '
        Me.dtpToBookingDate.Location = New System.Drawing.Point(119, 45)
        Me.dtpToBookingDate.Name = "dtpToBookingDate"
        Me.dtpToBookingDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpToBookingDate.TabIndex = 2
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(119, 14)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From (Booking Date) :"
        '
        'chkYear
        '
        Me.chkYear.AutoSize = True
        Me.chkYear.Location = New System.Drawing.Point(343, 62)
        Me.chkYear.Name = "chkYear"
        Me.chkYear.Size = New System.Drawing.Size(86, 17)
        Me.chkYear.TabIndex = 0
        Me.chkYear.Text = "Filter by Year"
        Me.chkYear.UseVisualStyleBackColor = True
        '
        'chkDay
        '
        Me.chkDay.AutoSize = True
        Me.chkDay.Location = New System.Drawing.Point(343, 14)
        Me.chkDay.Name = "chkDay"
        Me.chkDay.Size = New System.Drawing.Size(83, 17)
        Me.chkDay.TabIndex = 0
        Me.chkDay.Text = "Filter by Day"
        Me.chkDay.UseVisualStyleBackColor = True
        '
        'chkmonth
        '
        Me.chkmonth.AutoSize = True
        Me.chkmonth.Checked = True
        Me.chkmonth.Location = New System.Drawing.Point(343, 39)
        Me.chkmonth.Name = "chkmonth"
        Me.chkmonth.Size = New System.Drawing.Size(94, 17)
        Me.chkmonth.TabIndex = 0
        Me.chkmonth.TabStop = True
        Me.chkmonth.Text = "Filter by Month"
        Me.chkmonth.UseVisualStyleBackColor = True
        '
        'picChart
        '
        Me.picChart.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picChart.Location = New System.Drawing.Point(12, 150)
        Me.picChart.Name = "picChart"
        Me.picChart.Size = New System.Drawing.Size(770, 409)
        Me.picChart.TabIndex = 2
        Me.picChart.TabStop = False
        '
        'cmdPrintPreview
        '
        Me.cmdPrintPreview.Location = New System.Drawing.Point(581, 125)
        Me.cmdPrintPreview.Name = "cmdPrintPreview"
        Me.cmdPrintPreview.Size = New System.Drawing.Size(93, 23)
        Me.cmdPrintPreview.TabIndex = 3
        Me.cmdPrintPreview.Text = "PreView Image"
        Me.cmdPrintPreview.UseVisualStyleBackColor = True
        '
        'cmdExportImage
        '
        Me.cmdExportImage.Location = New System.Drawing.Point(478, 125)
        Me.cmdExportImage.Name = "cmdExportImage"
        Me.cmdExportImage.Size = New System.Drawing.Size(97, 23)
        Me.cmdExportImage.TabIndex = 3
        Me.cmdExportImage.Text = "Export Image"
        Me.cmdExportImage.UseVisualStyleBackColor = True
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
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "image"
        Me.SaveFileDialog1.Filter = "tiff (*.tiff)| *.tiff"
        '
        'frmChartingInbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 571)
        Me.Controls.Add(Me.cmdExportImage)
        Me.Controls.Add(Me.cmdPrintPreview)
        Me.Controls.Add(Me.picChart)
        Me.Controls.Add(Me.grpFilter)
        Me.Name = "frmChartingInbound"
        Me.Text = "Charting"
        Me.grpFilter.ResumeLayout(False)
        Me.grpFilter.PerformLayout()
        CType(Me.picChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpFilter As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkYear As System.Windows.Forms.RadioButton
    Friend WithEvents chkDay As System.Windows.Forms.RadioButton
    Friend WithEvents chkmonth As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpToBookingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents picChart As System.Windows.Forms.PictureBox
    Friend WithEvents cmdViewTransitGraph As System.Windows.Forms.Button
    Friend WithEvents cmdPrintPreview As System.Windows.Forms.Button
    Friend WithEvents cmdExportImage As System.Windows.Forms.Button
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
End Class
