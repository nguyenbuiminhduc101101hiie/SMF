<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgentReport
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAgentReport))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboChinhanh = New System.Windows.Forms.ComboBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Country = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalShipment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalAmountDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotalamountCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkpay = New System.Windows.Forms.CheckBox()
        Me.chkall = New System.Windows.Forms.CheckBox()
        Me.chkDaily = New System.Windows.Forms.RadioButton()
        Me.chkcustomer = New System.Windows.Forms.RadioButton()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Branch :"
        '
        'cboChinhanh
        '
        Me.cboChinhanh.FormattingEnabled = True
        Me.cboChinhanh.Items.AddRange(New Object() {"", "SGN", "HPH", "HAN", "DAD"})
        Me.cboChinhanh.Location = New System.Drawing.Point(24, 29)
        Me.cboChinhanh.Name = "cboChinhanh"
        Me.cboChinhanh.Size = New System.Drawing.Size(78, 21)
        Me.cboChinhanh.TabIndex = 79
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(363, 28)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 78
        Me.Button3.Text = "Export excel"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(447, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 77
        Me.Button2.Text = "Exit"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightCoral
        Me.Button1.Location = New System.Drawing.Point(363, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 76
        Me.Button1.Text = "1.Search"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(201, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "to :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(132, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "From (date report):"
        '
        'dtpto
        '
        Me.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpto.Location = New System.Drawing.Point(229, 28)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(114, 20)
        Me.dtpto.TabIndex = 73
        '
        'dtpFrom
        '
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(229, 3)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(114, 20)
        Me.dtpFrom.TabIndex = 72
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(12, 66)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(821, 284)
        Me.TabControl1.TabIndex = 82
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(813, 258)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General Summary"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.Company, Me.Country, Me.TotalShipment, Me.TotalAmountDebit, Me.TotalamountCredit})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(801, 246)
        Me.DataGridView1.TabIndex = 46
        '
        'No
        '
        Me.No.HeaderText = "No."
        Me.No.Name = "No"
        Me.No.Width = 30
        '
        'Company
        '
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.Width = 300
        '
        'Country
        '
        Me.Country.HeaderText = "Country"
        Me.Country.Name = "Country"
        '
        'TotalShipment
        '
        Me.TotalShipment.HeaderText = "Total Shipment"
        Me.TotalShipment.Name = "TotalShipment"
        Me.TotalShipment.Visible = False
        '
        'TotalAmountDebit
        '
        Me.TotalAmountDebit.HeaderText = "Total Amount (Debit)"
        Me.TotalAmountDebit.Name = "TotalAmountDebit"
        '
        'TotalamountCredit
        '
        Me.TotalamountCredit.HeaderText = "Total Amount Credit"
        Me.TotalamountCredit.Name = "TotalamountCredit"
        '
        'chkpay
        '
        Me.chkpay.AutoSize = True
        Me.chkpay.Location = New System.Drawing.Point(229, 54)
        Me.chkpay.Name = "chkpay"
        Me.chkpay.Size = New System.Drawing.Size(94, 17)
        Me.chkpay.TabIndex = 83
        Me.chkpay.Text = "Đã thanh toán"
        Me.chkpay.UseVisualStyleBackColor = True
        '
        'chkall
        '
        Me.chkall.AutoSize = True
        Me.chkall.Location = New System.Drawing.Point(329, 54)
        Me.chkall.Name = "chkall"
        Me.chkall.Size = New System.Drawing.Size(66, 17)
        Me.chkall.TabIndex = 84
        Me.chkall.Text = "Toàn bộ"
        Me.chkall.UseVisualStyleBackColor = True
        '
        'chkDaily
        '
        Me.chkDaily.AutoSize = True
        Me.chkDaily.Location = New System.Drawing.Point(447, 31)
        Me.chkDaily.Name = "chkDaily"
        Me.chkDaily.Size = New System.Drawing.Size(61, 17)
        Me.chkDaily.TabIndex = 85
        Me.chkDaily.Text = "Agency"
        Me.chkDaily.UseVisualStyleBackColor = True
        '
        'chkcustomer
        '
        Me.chkcustomer.AutoSize = True
        Me.chkcustomer.Checked = True
        Me.chkcustomer.Location = New System.Drawing.Point(514, 30)
        Me.chkcustomer.Name = "chkcustomer"
        Me.chkcustomer.Size = New System.Drawing.Size(108, 17)
        Me.chkcustomer.TabIndex = 86
        Me.chkcustomer.TabStop = True
        Me.chkcustomer.Text = "Customer/Vendor"
        Me.chkcustomer.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(528, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 87
        Me.Button4.Text = "Clips"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'frmAgentReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 356)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.chkcustomer)
        Me.Controls.Add(Me.chkDaily)
        Me.Controls.Add(Me.chkall)
        Me.Controls.Add(Me.chkpay)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboChinhanh)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpto)
        Me.Controls.Add(Me.dtpFrom)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAgentReport"
        Me.Text = "Agent Report"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboChinhanh As System.Windows.Forms.ComboBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents chkpay As System.Windows.Forms.CheckBox
    Friend WithEvents chkall As System.Windows.Forms.CheckBox
    Friend WithEvents No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Country As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalShipment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalAmountDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalamountCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkDaily As System.Windows.Forms.RadioButton
    Friend WithEvents chkcustomer As System.Windows.Forms.RadioButton
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
