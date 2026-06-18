<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchQuotationCode
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchQuotationCode))
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.from = New TSA.CalendarColumn
        Me.den = New TSA.CalendarColumn
        Me.service = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.LCL5min = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LCL5max = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LCLMax = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FCL20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FCL40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FCLHC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FCLSpecial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Air1000min = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Air1000max = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Location = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtpto = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.chkonly = New System.Windows.Forms.CheckBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbosale = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.from, Me.den, Me.service, Me.LCL5min, Me.LCL5max, Me.LCLMax, Me.FCL20, Me.FCL40, Me.FCLHC, Me.FCLSpecial, Me.Air1000min, Me.Air1000max, Me.Location})
        Me.dgdShippingLines.Location = New System.Drawing.Point(12, 67)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(1236, 447)
        Me.dgdShippingLines.TabIndex = 10
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'from
        '
        Me.from.DataPropertyName = "tu"
        Me.from.HeaderText = "From"
        Me.from.Name = "from"
        Me.from.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'den
        '
        Me.den.DataPropertyName = "den"
        Me.den.HeaderText = "To"
        Me.den.Name = "den"
        Me.den.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'service
        '
        Me.service.DataPropertyName = "service"
        Me.service.HeaderText = "Service"
        Me.service.Items.AddRange(New Object() {"Customs", "Trucking", "C/O", "Fumigation", "Packing", "Insurance", "Other"})
        Me.service.Name = "service"
        Me.service.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.service.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'LCL5min
        '
        Me.LCL5min.DataPropertyName = "LCL5min"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LCL5min.DefaultCellStyle = DataGridViewCellStyle1
        Me.LCL5min.HeaderText = "LCL <5CBM"
        Me.LCL5min.Name = "LCL5min"
        '
        'LCL5max
        '
        Me.LCL5max.DataPropertyName = "LCL5max"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LCL5max.DefaultCellStyle = DataGridViewCellStyle2
        Me.LCL5max.HeaderText = "LCL >5CBM"
        Me.LCL5max.Name = "LCL5max"
        '
        'LCLMax
        '
        Me.LCLMax.DataPropertyName = "LCLMax"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.LCLMax.DefaultCellStyle = DataGridViewCellStyle3
        Me.LCLMax.HeaderText = "LCL Max"
        Me.LCLMax.Name = "LCLMax"
        '
        'FCL20
        '
        Me.FCL20.DataPropertyName = "FCL20"
        Me.FCL20.HeaderText = "FCL 20'"
        Me.FCL20.Name = "FCL20"
        '
        'FCL40
        '
        Me.FCL40.DataPropertyName = "FCL40"
        Me.FCL40.HeaderText = "FCL 40'"
        Me.FCL40.Name = "FCL40"
        '
        'FCLHC
        '
        Me.FCLHC.DataPropertyName = "FCLHC"
        Me.FCLHC.HeaderText = "FCL 40HC"
        Me.FCLHC.Name = "FCLHC"
        '
        'FCLSpecial
        '
        Me.FCLSpecial.DataPropertyName = "FCLSpecial"
        Me.FCLSpecial.HeaderText = "FCL Special"
        Me.FCLSpecial.Name = "FCLSpecial"
        '
        'Air1000min
        '
        Me.Air1000min.DataPropertyName = "Air1000min"
        Me.Air1000min.HeaderText = "Air <1000Kg"
        Me.Air1000min.Name = "Air1000min"
        '
        'Air1000max
        '
        Me.Air1000max.DataPropertyName = "Air1000max"
        Me.Air1000max.HeaderText = "Air >1000Kg"
        Me.Air1000max.Name = "Air1000max"
        '
        'Location
        '
        Me.Location.DataPropertyName = "Location"
        Me.Location.HeaderText = "Location"
        Me.Location.Items.AddRange(New Object() {"HCM", "DN", "BD", "VT", "LA"})
        Me.Location.Name = "Location"
        Me.Location.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Location.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(183, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "to :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "From :"
        '
        'dtpto
        '
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpto.Location = New System.Drawing.Point(210, 12)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(114, 20)
        Me.dtpto.TabIndex = 60
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(60, 12)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpFrom.TabIndex = 59
        '
        'chkonly
        '
        Me.chkonly.AutoSize = True
        Me.chkonly.Location = New System.Drawing.Point(551, 9)
        Me.chkonly.Name = "chkonly"
        Me.chkonly.Size = New System.Drawing.Size(47, 17)
        Me.chkonly.TabIndex = 80
        Me.chkonly.Text = "Only"
        Me.chkonly.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(343, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 79
        Me.Label6.Text = "Service :"
        '
        'cbosale
        '
        Me.cbosale.FormattingEnabled = True
        Me.cbosale.Items.AddRange(New Object() {"Customs", "Trucking", "C/O", "Fumigation", "Packing", "Insurance", "Other"})
        Me.cbosale.Location = New System.Drawing.Point(398, 9)
        Me.cbosale.Name = "cbosale"
        Me.cbosale.Size = New System.Drawing.Size(147, 21)
        Me.cbosale.TabIndex = 78
        Me.cbosale.Text = "Customs"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(615, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 81
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(696, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 82
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(777, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "Export"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmSearchQuotationCode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 526)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chkonly)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cbosale)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpto)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSearchQuotationCode"
        Me.Text = "Search Tariff Cost"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents from As TSA.CalendarColumn
    Friend WithEvents den As TSA.CalendarColumn
    Friend WithEvents service As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents LCL5min As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LCL5max As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LCLMax As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCL20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCL40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCLHC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FCLSpecial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Air1000min As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Air1000max As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkonly As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cbosale As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
