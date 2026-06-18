<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintDO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintDO))
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.chkCheckAir = New System.Windows.Forms.CheckBox()
        Me.chkAttachDescription = New System.Windows.Forms.CheckBox()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.txtnhanvien = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CHKASPERBILL = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbochinhanh = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(58, 6)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 10
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'chkCheckAir
        '
        Me.chkCheckAir.AutoSize = True
        Me.chkCheckAir.Location = New System.Drawing.Point(17, 10)
        Me.chkCheckAir.Name = "chkCheckAir"
        Me.chkCheckAir.Size = New System.Drawing.Size(38, 17)
        Me.chkCheckAir.TabIndex = 9
        Me.chkCheckAir.Text = "Air"
        Me.chkCheckAir.UseVisualStyleBackColor = True
        Me.chkCheckAir.Visible = False
        '
        'chkAttachDescription
        '
        Me.chkAttachDescription.AutoSize = True
        Me.chkAttachDescription.Location = New System.Drawing.Point(214, 104)
        Me.chkAttachDescription.Name = "chkAttachDescription"
        Me.chkAttachDescription.Size = New System.Drawing.Size(113, 17)
        Me.chkAttachDescription.TabIndex = 8
        Me.chkAttachDescription.Text = "Attach Descritpion"
        Me.chkAttachDescription.UseVisualStyleBackColor = True
        Me.chkAttachDescription.Visible = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 33)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(982, 475)
        Me.CrystalReportViewer1.TabIndex = 7
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(451, 6)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(86, 20)
        Me.DateTimePicker1.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(394, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Ngày In :"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"MY DINH", "GIA LAM", "NOI BAI", "KHAC"})
        Me.ComboBox1.Location = New System.Drawing.Point(130, 100)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(88, 21)
        Me.ComboBox1.TabIndex = 13
        Me.ComboBox1.Text = "MY DINH"
        Me.ComboBox1.Visible = False
        '
        'txtnhanvien
        '
        Me.txtnhanvien.Location = New System.Drawing.Point(214, 8)
        Me.txtnhanvien.Name = "txtnhanvien"
        Me.txtnhanvien.Size = New System.Drawing.Size(157, 20)
        Me.txtnhanvien.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(146, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Nhân viên :"
        '
        'CHKASPERBILL
        '
        Me.CHKASPERBILL.AutoSize = True
        Me.CHKASPERBILL.Location = New System.Drawing.Point(546, 8)
        Me.CHKASPERBILL.Name = "CHKASPERBILL"
        Me.CHKASPERBILL.Size = New System.Drawing.Size(73, 17)
        Me.CHKASPERBILL.TabIndex = 16
        Me.CHKASPERBILL.Text = "As Per Bill"
        Me.CHKASPERBILL.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(628, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "C.Nhánh :"
        '
        'cbochinhanh
        '
        Me.cbochinhanh.FormattingEnabled = True
        Me.cbochinhanh.Items.AddRange(New Object() {"HAN", "HPH", "SGN", "DAD"})
        Me.cbochinhanh.Location = New System.Drawing.Point(688, 4)
        Me.cbochinhanh.Name = "cbochinhanh"
        Me.cbochinhanh.Size = New System.Drawing.Size(61, 21)
        Me.cbochinhanh.TabIndex = 19
        Me.cbochinhanh.Text = "SGN"
        '
        'frmPrintDO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 508)
        Me.Controls.Add(Me.cbochinhanh)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CHKASPERBILL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtnhanvien)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.chkCheckAir)
        Me.Controls.Add(Me.chkAttachDescription)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintDO"
        Me.Text = "Print D/O"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents chkCheckAir As System.Windows.Forms.CheckBox
    Friend WithEvents chkAttachDescription As System.Windows.Forms.CheckBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents txtnhanvien As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CHKASPERBILL As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbochinhanh As System.Windows.Forms.ComboBox
End Class
