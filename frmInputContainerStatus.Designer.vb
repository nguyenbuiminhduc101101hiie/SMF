<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputContainerStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputContainerStatus))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button7 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdSaveService = New System.Windows.Forms.Button
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView
        Me.ContainerStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.location = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.socont = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.bai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.status = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.Status_Date = New TSA.CalendarColumn
        Me.opr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.depot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.loading = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(337, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Search (Column) :"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(651, 41)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 23)
        Me.Button7.TabIndex = 67
        Me.Button7.Text = "Ok"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(511, 44)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(134, 20)
        Me.TextBox2.TabIndex = 66
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"socont", "location", "bai"})
        Me.ComboBox1.Location = New System.Drawing.Point(431, 43)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(70, 21)
        Me.ComboBox1.TabIndex = 65
        Me.ComboBox1.Text = "socont"
        '
        'Button6
        '
        Me.Button6.ForeColor = System.Drawing.Color.Blue
        Me.Button6.Location = New System.Drawing.Point(21, 15)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 23)
        Me.Button6.TabIndex = 64
        Me.Button6.Text = "Load"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(651, 16)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(52, 23)
        Me.Button5.TabIndex = 63
        Me.Button5.Text = "Ok"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(366, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 62
        Me.Label1.Text = "Search All :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(431, 18)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(214, 20)
        Me.TextBox1.TabIndex = 61
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(113, 15)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 23)
        Me.Button4.TabIndex = 60
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Blue
        Me.Button3.Location = New System.Drawing.Point(67, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 23)
        Me.Button3.TabIndex = 59
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(275, 15)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 58
        Me.Button2.Text = "Export..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(223, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.ForeColor = System.Drawing.Color.Red
        Me.cmdSaveService.Location = New System.Drawing.Point(172, 15)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(46, 23)
        Me.cmdSaveService.TabIndex = 56
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgdShippingLines.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContainerStatusID, Me.location, Me.socont, Me.bai, Me.status, Me.Status_Date, Me.opr, Me.FL, Me.depot, Me.loading})
        Me.dgdShippingLines.Location = New System.Drawing.Point(12, 74)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(1150, 328)
        Me.dgdShippingLines.TabIndex = 55
        '
        'ContainerStatusID
        '
        Me.ContainerStatusID.DataPropertyName = "ContainerStatusID"
        Me.ContainerStatusID.HeaderText = "ContainerStatusID"
        Me.ContainerStatusID.Name = "ContainerStatusID"
        Me.ContainerStatusID.Visible = False
        Me.ContainerStatusID.Width = 118
        '
        'location
        '
        Me.location.DataPropertyName = "location"
        Me.location.HeaderText = "Location"
        Me.location.Items.AddRange(New Object() {"VNSGN", "VNHPH", "VNHAN", "VNDAD"})
        Me.location.Name = "location"
        Me.location.Width = 54
        '
        'socont
        '
        Me.socont.DataPropertyName = "socont"
        Me.socont.HeaderText = "Socont"
        Me.socont.Name = "socont"
        Me.socont.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.socont.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.socont.Width = 66
        '
        'bai
        '
        Me.bai.DataPropertyName = "bai"
        Me.bai.HeaderText = "Bai"
        Me.bai.Name = "bai"
        Me.bai.Width = 47
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        Me.status.HeaderText = "Status"
        Me.status.Items.AddRange(New Object() {"FulIm", "TrImp", "TrExp", "FulEx", "MT"})
        Me.status.Name = "status"
        Me.status.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.status.Width = 62
        '
        'Status_Date
        '
        Me.Status_Date.DataPropertyName = "Status_Date"
        Me.Status_Date.HeaderText = "Status_Date"
        Me.Status_Date.Name = "Status_Date"
        Me.Status_Date.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Status_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Status_Date.Width = 91
        '
        'opr
        '
        Me.opr.DataPropertyName = "opr"
        Me.opr.HeaderText = "Opr"
        Me.opr.Name = "opr"
        Me.opr.Width = 49
        '
        'FL
        '
        Me.FL.DataPropertyName = "fl"
        Me.FL.HeaderText = "FE"
        Me.FL.Name = "FL"
        Me.FL.Width = 45
        '
        'depot
        '
        Me.depot.DataPropertyName = "depot"
        Me.depot.HeaderText = "Depot date (Import)"
        Me.depot.Name = "depot"
        Me.depot.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.depot.Width = 113
        '
        'loading
        '
        Me.loading.DataPropertyName = "loading"
        Me.loading.HeaderText = "Loading date (Export)"
        Me.loading.Name = "loading"
        Me.loading.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.loading.Width = 122
        '
        'frmInputContainerStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1174, 426)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInputContainerStatus"
        Me.Text = "Input Container Status"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents ContainerStatusID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents location As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents socont As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents bai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents Status_Date As TSA.CalendarColumn
    Friend WithEvents opr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents depot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents loading As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
