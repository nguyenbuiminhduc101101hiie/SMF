<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpress_Zone
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpress_Zone))
        Me.dgdview = New System.Windows.Forms.DataGridView
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PWD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboCode = New System.Windows.Forms.ComboBox
        Me.cboPWD = New System.Windows.Forms.ComboBox
        Me.txtTT = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdexit = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        CType(Me.dgdview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgdview
        '
        Me.dgdview.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdview.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.id, Me.Code, Me.PWD, Me.TTime})
        Me.dgdview.Location = New System.Drawing.Point(285, 12)
        Me.dgdview.Name = "dgdview"
        Me.dgdview.Size = New System.Drawing.Size(240, 285)
        Me.dgdview.TabIndex = 0
        '
        'id
        '
        Me.id.DataPropertyName = "id"
        Me.id.HeaderText = "id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'Code
        '
        Me.Code.DataPropertyName = "code"
        Me.Code.HeaderText = "Code"
        Me.Code.Name = "Code"
        '
        'PWD
        '
        Me.PWD.DataPropertyName = "pwd"
        Me.PWD.HeaderText = "PWD"
        Me.PWD.Name = "PWD"
        '
        'TTime
        '
        Me.TTime.DataPropertyName = "ttime"
        Me.TTime.HeaderText = "T.Time"
        Me.TTime.Name = "TTime"
        '
        'cboCode
        '
        Me.cboCode.FormattingEnabled = True
        Me.cboCode.Items.AddRange(New Object() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V"})
        Me.cboCode.Location = New System.Drawing.Point(59, 12)
        Me.cboCode.Name = "cboCode"
        Me.cboCode.Size = New System.Drawing.Size(198, 21)
        Me.cboCode.TabIndex = 1
        Me.cboCode.Text = "A"
        '
        'cboPWD
        '
        Me.cboPWD.FormattingEnabled = True
        Me.cboPWD.Location = New System.Drawing.Point(59, 51)
        Me.cboPWD.Name = "cboPWD"
        Me.cboPWD.Size = New System.Drawing.Size(198, 21)
        Me.cboPWD.TabIndex = 2
        '
        'txtTT
        '
        Me.txtTT.Location = New System.Drawing.Point(59, 93)
        Me.txtTT.Name = "txtTT"
        Me.txtTT.Size = New System.Drawing.Size(198, 20)
        Me.txtTT.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Zone :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "PWD :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "T/Time :"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(182, 119)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdexit
        '
        Me.cmdexit.Location = New System.Drawing.Point(101, 119)
        Me.cmdexit.Name = "cmdexit"
        Me.cmdexit.Size = New System.Drawing.Size(75, 23)
        Me.cmdexit.TabIndex = 8
        Me.cmdexit.Text = "Exit"
        Me.cmdexit.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(20, 119)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(20, 148)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "Find"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmExpress_Zone
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 309)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.cmdexit)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtTT)
        Me.Controls.Add(Me.cboPWD)
        Me.Controls.Add(Me.cboCode)
        Me.Controls.Add(Me.dgdview)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmExpress_Zone"
        Me.Text = "Express Zone"
        CType(Me.dgdview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdview As System.Windows.Forms.DataGridView
    Friend WithEvents cboCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboPWD As System.Windows.Forms.ComboBox
    Friend WithEvents txtTT As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PWD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdexit As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
