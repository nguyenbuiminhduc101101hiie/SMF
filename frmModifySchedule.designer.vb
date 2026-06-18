<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModifySchedule
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModifySchedule))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSaveService = New System.Windows.Forms.Button()
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView()
        Me.terminaldepartureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VESSELNAME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VOYAGE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CLOSINGTIME = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MODEOFTRANSPORT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NOTE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.userupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dateupdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button8 = New System.Windows.Forms.Button()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(673, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "Search (Column) :"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(994, 10)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(52, 23)
        Me.Button7.TabIndex = 39
        Me.Button7.Text = "Ok"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(842, 13)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(146, 20)
        Me.TextBox2.TabIndex = 38
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownWidth = 300
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"POL", "POD", "ETD", "ETA", "VESSELNAME", "VOYAGE"})
        Me.ComboBox1.Location = New System.Drawing.Point(768, 12)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(60, 21)
        Me.ComboBox1.TabIndex = 37
        Me.ComboBox1.Text = "POL"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(19, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 23)
        Me.Button6.TabIndex = 36
        Me.Button6.Text = "Load"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(613, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(52, 23)
        Me.Button5.TabIndex = 35
        Me.Button5.Text = "Ok"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(426, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Search All :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(491, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(118, 20)
        Me.TextBox1.TabIndex = 33
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(111, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(53, 23)
        Me.Button4.TabIndex = 32
        Me.Button4.Text = "Cancel"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(65, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 23)
        Me.Button3.TabIndex = 31
        Me.Button3.Text = "New"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(273, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 23)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Export..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(221, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(43, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(170, 12)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(46, 23)
        Me.cmdSaveService.TabIndex = 28
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
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.terminaldepartureID, Me.VESSELNAME, Me.VOYAGE, Me.CLOSINGTIME, Me.POL, Me.POD, Me.ETD, Me.ETA, Me.MODEOFTRANSPORT, Me.NOTE, Me.userupdate, Me.dateupdate})
        Me.dgdShippingLines.Location = New System.Drawing.Point(19, 41)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(1027, 453)
        Me.dgdShippingLines.TabIndex = 533
        '
        'terminaldepartureID
        '
        Me.terminaldepartureID.DataPropertyName = "terminaldeparture_ID"
        Me.terminaldepartureID.HeaderText = "terminaldepartureID"
        Me.terminaldepartureID.Name = "terminaldepartureID"
        Me.terminaldepartureID.Visible = False
        Me.terminaldepartureID.Width = 124
        '
        'VESSELNAME
        '
        Me.VESSELNAME.DataPropertyName = "GUI"
        Me.VESSELNAME.HeaderText = "VESSEL NAME"
        Me.VESSELNAME.Name = "VESSELNAME"
        Me.VESSELNAME.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.VESSELNAME.Width = 98
        '
        'VOYAGE
        '
        Me.VOYAGE.DataPropertyName = "PORT"
        Me.VOYAGE.HeaderText = "VOYAGE"
        Me.VOYAGE.Name = "VOYAGE"
        Me.VOYAGE.Width = 76
        '
        'CLOSINGTIME
        '
        Me.CLOSINGTIME.DataPropertyName = "AFTER"
        Me.CLOSINGTIME.HeaderText = "CLOSING TIME"
        Me.CLOSINGTIME.Name = "CLOSINGTIME"
        Me.CLOSINGTIME.Width = 99
        '
        'POL
        '
        Me.POL.DataPropertyName = "QUANTITY"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        Me.POL.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.POL.Width = 53
        '
        'POD
        '
        Me.POD.DataPropertyName = "_TO"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        Me.POD.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.POD.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.POD.Width = 36
        '
        'ETD
        '
        Me.ETD.DataPropertyName = "numcrew"
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        Me.ETD.Width = 54
        '
        'ETA
        '
        Me.ETA.DataPropertyName = "numpassenger"
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        Me.ETA.Width = 53
        '
        'MODEOFTRANSPORT
        '
        Me.MODEOFTRANSPORT.DataPropertyName = "QUANTITYCARGO"
        Me.MODEOFTRANSPORT.HeaderText = "MODE OF TRANSPORT"
        Me.MODEOFTRANSPORT.Name = "MODEOFTRANSPORT"
        Me.MODEOFTRANSPORT.Width = 138
        '
        'NOTE
        '
        Me.NOTE.DataPropertyName = "REMARKS"
        Me.NOTE.HeaderText = "NOTE"
        Me.NOTE.Name = "NOTE"
        Me.NOTE.Width = 62
        '
        'userupdate
        '
        Me.userupdate.DataPropertyName = "userupdate"
        Me.userupdate.HeaderText = "USER UPDATE"
        Me.userupdate.Name = "userupdate"
        '
        'dateupdate
        '
        Me.dateupdate.DataPropertyName = "dateupdate"
        Me.dateupdate.HeaderText = "DATE UPDATE"
        Me.dateupdate.Name = "dateupdate"
        Me.dateupdate.Width = 99
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(334, 12)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(43, 23)
        Me.Button8.TabIndex = 534
        Me.Button8.Text = "Clips"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'frmModifySchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 506)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.dgdShippingLines)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModifySchedule"
        Me.Text = "Modify Schedule"
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
    Friend WithEvents terminaldepartureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VESSELNAME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VOYAGE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CLOSINGTIME As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MODEOFTRANSPORT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NOTE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dateupdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
