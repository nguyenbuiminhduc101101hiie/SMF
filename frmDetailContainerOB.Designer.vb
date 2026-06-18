<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDetailContainerOB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDetailContainerOB))
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.cboMBL = New System.Windows.Forms.ComboBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.Ref = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MBL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HBL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Consignee = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GoodsType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Containers = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Seal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tongkien = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tongkg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tongkhoi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.cboHBL = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdOK = New System.Windows.Forms.Button
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.cbocontainers = New System.Windows.Forms.ComboBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.cboref = New System.Windows.Forms.ComboBox
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(11, 97)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Excel..."
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.cboMBL)
        Me.GroupBox3.Location = New System.Drawing.Point(557, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(178, 79)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "House Bill No.  /  MAWB :"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(92, 45)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "OK"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cboMBL
        '
        Me.cboMBL.FormattingEnabled = True
        Me.cboMBL.Location = New System.Drawing.Point(6, 18)
        Me.cboMBL.Name = "cboMBL"
        Me.cboMBL.Size = New System.Drawing.Size(161, 21)
        Me.cboMBL.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(92, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgdData
        '
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Ref, Me.MBL, Me.HBL, Me.Consignee, Me.ETD, Me.GoodsType, Me.Containers, Me.Type, Me.Seal, Me.tongkien, Me.tongkg, Me.tongkhoi})
        Me.dgdData.Location = New System.Drawing.Point(12, 126)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.Size = New System.Drawing.Size(996, 329)
        Me.dgdData.TabIndex = 9
        '
        'Ref
        '
        Me.Ref.HeaderText = "Ref"
        Me.Ref.Name = "Ref"
        '
        'MBL
        '
        Me.MBL.HeaderText = "MBL"
        Me.MBL.Name = "MBL"
        '
        'HBL
        '
        Me.HBL.HeaderText = "HBL"
        Me.HBL.Name = "HBL"
        '
        'Consignee
        '
        Me.Consignee.HeaderText = "Consignee"
        Me.Consignee.Name = "Consignee"
        '
        'ETD
        '
        Me.ETD.HeaderText = "ETD"
        Me.ETD.Name = "ETD"
        '
        'GoodsType
        '
        Me.GoodsType.HeaderText = "Goods type"
        Me.GoodsType.Name = "GoodsType"
        '
        'Containers
        '
        Me.Containers.HeaderText = "Containers"
        Me.Containers.Name = "Containers"
        '
        'Type
        '
        Me.Type.HeaderText = "Type"
        Me.Type.Name = "Type"
        '
        'Seal
        '
        Me.Seal.HeaderText = "Seal"
        Me.Seal.Name = "Seal"
        '
        'tongkien
        '
        Me.tongkien.HeaderText = "Package"
        Me.tongkien.Name = "tongkien"
        '
        'tongkg
        '
        Me.tongkg.HeaderText = "Volume"
        Me.tongkg.Name = "tongkg"
        '
        'tongkhoi
        '
        Me.tongkhoi.HeaderText = "Meas"
        Me.tongkhoi.Name = "tongkhoi"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button2)
        Me.GroupBox2.Controls.Add(Me.cboHBL)
        Me.GroupBox2.Location = New System.Drawing.Point(370, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(181, 79)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "HAWB"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(97, 45)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "OK"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cboHBL
        '
        Me.cboHBL.FormattingEnabled = True
        Me.cboHBL.Location = New System.Drawing.Point(6, 18)
        Me.cboHBL.Name = "cboHBL"
        Me.cboHBL.Size = New System.Drawing.Size(166, 21)
        Me.cboHBL.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmdOK)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(352, 79)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ETD"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "To ETD :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From ETD :"
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(265, 50)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 2
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(243, 19)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(97, 20)
        Me.DateTimePicker2.TabIndex = 1
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(77, 19)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(97, 20)
        Me.DateTimePicker1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.cbocontainers)
        Me.GroupBox4.Location = New System.Drawing.Point(741, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(173, 79)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Containers"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(92, 45)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "OK"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'cbocontainers
        '
        Me.cbocontainers.FormattingEnabled = True
        Me.cbocontainers.Location = New System.Drawing.Point(6, 18)
        Me.cbocontainers.Name = "cbocontainers"
        Me.cbocontainers.Size = New System.Drawing.Size(161, 21)
        Me.cbocontainers.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Button6)
        Me.GroupBox5.Controls.Add(Me.cboref)
        Me.GroupBox5.Location = New System.Drawing.Point(920, 12)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(178, 79)
        Me.GroupBox5.TabIndex = 11
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Ref :"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(92, 45)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "OK"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'cboref
        '
        Me.cboref.FormattingEnabled = True
        Me.cboref.Location = New System.Drawing.Point(6, 18)
        Me.cboref.Name = "cboref"
        Me.cboref.Size = New System.Drawing.Size(161, 21)
        Me.cboref.TabIndex = 0
        '
        'frmDetailContainerOB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1020, 467)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDetailContainerOB"
        Me.Text = "Details Container"
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cboMBL As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cboHBL As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Ref As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HBL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Consignee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GoodsType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Containers As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Seal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tongkien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tongkg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tongkhoi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cbocontainers As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents cboref As System.Windows.Forms.ComboBox
End Class
