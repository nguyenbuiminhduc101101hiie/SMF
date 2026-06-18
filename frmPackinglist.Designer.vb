<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPackinglist
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPackinglist))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label314 = New System.Windows.Forms.Label()
        Me.cboHBL = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtshipper = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtbookingno = New System.Windows.Forms.TextBox()
        Me.txtvessel = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtvoy = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtngayhabai = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txttransit = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtPOD = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtghichu = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.contNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sealno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.descriptionContainer = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GROSSWEIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NhietdoThonggio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chlallsoccoc = New System.Windows.Forms.RadioButton()
        Me.CHKCOC = New System.Windows.Forms.RadioButton()
        Me.CHKSOC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(169, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 353
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(88, 39)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 352
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label314
        '
        Me.Label314.AutoSize = True
        Me.Label314.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label314.Location = New System.Drawing.Point(16, 16)
        Me.Label314.Name = "Label314"
        Me.Label314.Size = New System.Drawing.Size(31, 13)
        Me.Label314.TabIndex = 349
        Me.Label314.Text = "HBL:"
        '
        'cboHBL
        '
        Me.cboHBL.AccessibleName = "32"
        Me.cboHBL.FormattingEnabled = True
        Me.cboHBL.Location = New System.Drawing.Point(53, 12)
        Me.cboHBL.Name = "cboHBL"
        Me.cboHBL.Size = New System.Drawing.Size(191, 21)
        Me.cboHBL.TabIndex = 348
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtghichu)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPOD)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txttransit)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtngayhabai)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtvoy)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtvessel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtbookingno)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtshipper)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(19, 68)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1044, 182)
        Me.GroupBox1.TabIndex = 354
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Information"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.contNo, Me.sealno, Me.descriptionContainer, Me.GROSSWEIGHT, Me.NhietdoThonggio})
        Me.DataGridView1.Location = New System.Drawing.Point(19, 256)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1044, 351)
        Me.DataGridView1.TabIndex = 355
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Chủ hàng/Shipper :"
        '
        'txtshipper
        '
        Me.txtshipper.Location = New System.Drawing.Point(141, 20)
        Me.txtshipper.Multiline = True
        Me.txtshipper.Name = "txtshipper"
        Me.txtshipper.Size = New System.Drawing.Size(470, 54)
        Me.txtshipper.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(631, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Booking No. :"
        '
        'txtbookingno
        '
        Me.txtbookingno.Location = New System.Drawing.Point(709, 24)
        Me.txtbookingno.Name = "txtbookingno"
        Me.txtbookingno.Size = New System.Drawing.Size(138, 20)
        Me.txtbookingno.TabIndex = 3
        '
        'txtvessel
        '
        Me.txtvessel.Location = New System.Drawing.Point(141, 80)
        Me.txtvessel.Name = "txtvessel"
        Me.txtvessel.Size = New System.Drawing.Size(198, 20)
        Me.txtvessel.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tên tàu / Vessel :"
        '
        'txtvoy
        '
        Me.txtvoy.Location = New System.Drawing.Point(472, 80)
        Me.txtvoy.Name = "txtvoy"
        Me.txtvoy.Size = New System.Drawing.Size(139, 20)
        Me.txtvoy.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(353, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Số chuyến / Voyage :"
        '
        'txtngayhabai
        '
        Me.txtngayhabai.Location = New System.Drawing.Point(709, 80)
        Me.txtngayhabai.Name = "txtngayhabai"
        Me.txtngayhabai.Size = New System.Drawing.Size(138, 20)
        Me.txtngayhabai.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(628, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "(Ngày hạ bãi) :"
        '
        'txttransit
        '
        Me.txttransit.Location = New System.Drawing.Point(141, 106)
        Me.txttransit.Name = "txttransit"
        Me.txttransit.Size = New System.Drawing.Size(198, 20)
        Me.txttransit.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Cảng chuyển tải/Transit :"
        '
        'txtPOD
        '
        Me.txtPOD.Location = New System.Drawing.Point(472, 106)
        Me.txtPOD.Name = "txtPOD"
        Me.txtPOD.Size = New System.Drawing.Size(139, 20)
        Me.txtPOD.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(353, 109)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Cảng đến/Destination :"
        '
        'txtghichu
        '
        Me.txtghichu.Location = New System.Drawing.Point(709, 106)
        Me.txtghichu.Name = "txtghichu"
        Me.txtghichu.Size = New System.Drawing.Size(138, 20)
        Me.txtghichu.TabIndex = 15
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(628, 110)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ghi chú :"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(11, 153)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 356
        Me.Button3.Text = "Export"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'contNo
        '
        Me.contNo.HeaderText = "Số Container/ Container No."
        Me.contNo.Name = "contNo"
        Me.contNo.Width = 136
        '
        'sealno
        '
        Me.sealno.HeaderText = "Số Seal/Seal No."
        Me.sealno.Name = "sealno"
        Me.sealno.Width = 105
        '
        'descriptionContainer
        '
        Me.descriptionContainer.HeaderText = "Tên hàng/Description of goods"
        Me.descriptionContainer.Name = "descriptionContainer"
        Me.descriptionContainer.Width = 138
        '
        'GROSSWEIGHT
        '
        Me.GROSSWEIGHT.HeaderText = "Trọng lượng hàng/Gross cargo weight"
        Me.GROSSWEIGHT.Name = "GROSSWEIGHT"
        Me.GROSSWEIGHT.Width = 165
        '
        'NhietdoThonggio
        '
        Me.NhietdoThonggio.HeaderText = "Nhiệt độ, thông gió/Temperature,Vent."
        Me.NhietdoThonggio.Name = "NhietdoThonggio"
        Me.NhietdoThonggio.Width = 196
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.chlallsoccoc)
        Me.GroupBox2.Controls.Add(Me.CHKCOC)
        Me.GroupBox2.Controls.Add(Me.CHKSOC)
        Me.GroupBox2.Location = New System.Drawing.Point(263, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 43)
        Me.GroupBox2.TabIndex = 733
        Me.GroupBox2.TabStop = False
        '
        'chlallsoccoc
        '
        Me.chlallsoccoc.AutoSize = True
        Me.chlallsoccoc.Checked = True
        Me.chlallsoccoc.Location = New System.Drawing.Point(97, 18)
        Me.chlallsoccoc.Name = "chlallsoccoc"
        Me.chlallsoccoc.Size = New System.Drawing.Size(44, 17)
        Me.chlallsoccoc.TabIndex = 2
        Me.chlallsoccoc.TabStop = True
        Me.chlallsoccoc.Text = "ALL"
        Me.chlallsoccoc.UseVisualStyleBackColor = True
        '
        'CHKCOC
        '
        Me.CHKCOC.AutoSize = True
        Me.CHKCOC.Location = New System.Drawing.Point(51, 18)
        Me.CHKCOC.Name = "CHKCOC"
        Me.CHKCOC.Size = New System.Drawing.Size(50, 17)
        Me.CHKCOC.TabIndex = 1
        Me.CHKCOC.Text = "COC "
        Me.CHKCOC.UseVisualStyleBackColor = True
        '
        'CHKSOC
        '
        Me.CHKSOC.AutoSize = True
        Me.CHKSOC.Location = New System.Drawing.Point(6, 18)
        Me.CHKSOC.Name = "CHKSOC"
        Me.CHKSOC.Size = New System.Drawing.Size(50, 17)
        Me.CHKSOC.TabIndex = 0
        Me.CHKSOC.Text = "SOC "
        Me.CHKSOC.UseVisualStyleBackColor = True
        '
        'frmPackinglist
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1075, 611)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label314)
        Me.Controls.Add(Me.cboHBL)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPackinglist"
        Me.Text = "Packing list"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label314 As System.Windows.Forms.Label
    Friend WithEvents cboHBL As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtvoy As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtvessel As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtbookingno As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtshipper As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtngayhabai As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txttransit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtghichu As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPOD As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents contNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sealno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descriptionContainer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GROSSWEIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NhietdoThonggio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chlallsoccoc As System.Windows.Forms.RadioButton
    Friend WithEvents CHKCOC As System.Windows.Forms.RadioButton
    Friend WithEvents CHKSOC As System.Windows.Forms.RadioButton
End Class
