<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInventoryDetailsReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInventoryDetailsReport))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.seg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Location = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.container = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Size = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.opr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FulIm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Trimp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Depot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Trexp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fulex = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Loading = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gradeRemarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(20, 68)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(87, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 627
        Me.PictureBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(371, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 626
        Me.Label4.Text = "INVENTORY REPORT"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(20, 52)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(863, 1)
        Me.GroupBox1.TabIndex = 625
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(358, 9)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 624
        Me.Button3.Text = "Exit"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(277, 9)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 623
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(196, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 622
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 621
        Me.Label2.Text = "Date :"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(75, 12)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(104, 20)
        Me.DateTimePicker1.TabIndex = 620
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seg, Me.Location, Me.container, Me.Size, Me.opr, Me.FE, Me.FulIm, Me.Trimp, Me.Depot, Me.Trexp, Me.Fulex, Me.Loading, Me.gradeRemarks})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 116)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(873, 276)
        Me.DataGridView1.TabIndex = 619
        '
        'seg
        '
        Me.seg.HeaderText = "Seg"
        Me.seg.Name = "seg"
        '
        'Location
        '
        Me.Location.HeaderText = "Location"
        Me.Location.Name = "Location"
        '
        'container
        '
        Me.container.HeaderText = "Container"
        Me.container.Name = "container"
        '
        'Size
        '
        Me.Size.HeaderText = "Size"
        Me.Size.Name = "Size"
        '
        'opr
        '
        Me.opr.HeaderText = "Opr"
        Me.opr.Name = "opr"
        '
        'FE
        '
        Me.FE.HeaderText = "FE"
        Me.FE.Name = "FE"
        '
        'FulIm
        '
        Me.FulIm.HeaderText = "FulIm"
        Me.FulIm.Name = "FulIm"
        '
        'Trimp
        '
        Me.Trimp.HeaderText = "Trimp"
        Me.Trimp.Name = "Trimp"
        '
        'Depot
        '
        Me.Depot.HeaderText = "Deport"
        Me.Depot.Name = "Depot"
        '
        'Trexp
        '
        Me.Trexp.HeaderText = "Trexp"
        Me.Trexp.Name = "Trexp"
        '
        'Fulex
        '
        Me.Fulex.HeaderText = "Fulex"
        Me.Fulex.Name = "Fulex"
        '
        'Loading
        '
        Me.Loading.HeaderText = "Loading"
        Me.Loading.Name = "Loading"
        '
        'gradeRemarks
        '
        Me.gradeRemarks.HeaderText = "Grade Remarks"
        Me.gradeRemarks.Name = "gradeRemarks"
        '
        'frmInventoryDetailsReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(897, 404)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInventoryDetailsReport"
        Me.Text = "Inventory Details"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents seg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents container As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Size As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents opr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FulIm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Trimp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Depot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Trexp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fulex As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Loading As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gradeRemarks As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
