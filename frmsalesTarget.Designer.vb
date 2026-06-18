<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmsalesTarget
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmsalesTarget))
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdSaveService = New System.Windows.Forms.Button
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.salecode = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.tu = New TSA.CalendarColumn
        Me.den = New TSA.CalendarColumn
        Me.target = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bonus = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Export..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(95, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(14, 10)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(75, 23)
        Me.cmdSaveService.TabIndex = 14
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.salecode, Me.tu, Me.den, Me.target, Me.bonus})
        Me.dgdShippingLines.Location = New System.Drawing.Point(12, 39)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(565, 462)
        Me.dgdShippingLines.TabIndex = 13
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'salecode
        '
        Me.salecode.DataPropertyName = "Salecode"
        Me.salecode.HeaderText = "Sale Code"
        Me.salecode.Items.AddRange(New Object() {"sgn-sale", "sgn-sale1", "sgn-sale2", "sgn-sale3", "sgn-sale4", "sgn-sale5", "sgn-sale6", "sgn-sale7", "sgn-sale8", "sgn-sale9", "sgn-sale10", "sgn-will-ceo", "sgn-cus", "sgn-cus1", "sgn-cus2", "sgn-log", "sgn-log1", "sgn-log2"})
        Me.salecode.Name = "salecode"
        Me.salecode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.salecode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'tu
        '
        Me.tu.DataPropertyName = "tu"
        Me.tu.HeaderText = "From"
        Me.tu.Name = "tu"
        Me.tu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'den
        '
        Me.den.DataPropertyName = "den"
        Me.den.HeaderText = "To"
        Me.den.Name = "den"
        Me.den.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'target
        '
        Me.target.DataPropertyName = "target"
        Me.target.HeaderText = "Target"
        Me.target.Name = "target"
        Me.target.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'bonus
        '
        Me.bonus.DataPropertyName = "bonus"
        Me.bonus.HeaderText = "Bonus"
        Me.bonus.Name = "bonus"
        '
        'frmsalesTarget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 513)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmsalesTarget"
        Me.Text = "Sales Target"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents salecode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents tu As TSA.CalendarColumn
    Friend WithEvents den As TSA.CalendarColumn
    Friend WithEvents target As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bonus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
