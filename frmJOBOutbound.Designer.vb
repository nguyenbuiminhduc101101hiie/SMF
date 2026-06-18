<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJOBOutbound
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJOBOutbound))
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdOKH = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboHBL = New System.Windows.Forms.ComboBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMBL = New System.Windows.Forms.ComboBox
        Me.chkSale = New System.Windows.Forms.CheckBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Deusd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreUSD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OSUSD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OSVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(357, 113)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 17
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdOKH
        '
        Me.cmdOKH.Location = New System.Drawing.Point(357, 84)
        Me.cmdOKH.Name = "cmdOKH"
        Me.cmdOKH.Size = New System.Drawing.Size(75, 23)
        Me.cmdOKH.TabIndex = 16
        Me.cmdOKH.Text = "JOB"
        Me.cmdOKH.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(220, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "MBL/MAWB  :"
        '
        'cboHBL
        '
        Me.cboHBL.FormattingEnabled = True
        Me.cboHBL.Location = New System.Drawing.Point(223, 57)
        Me.cboHBL.Name = "cboHBL"
        Me.cboHBL.Size = New System.Drawing.Size(210, 21)
        Me.cboHBL.TabIndex = 14
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(142, 84)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 13
        Me.cmdOK.Text = "JOB"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(4, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "MBL Carrier :"
        '
        'cboMBL
        '
        Me.cboMBL.FormattingEnabled = True
        Me.cboMBL.Location = New System.Drawing.Point(7, 57)
        Me.cboMBL.Name = "cboMBL"
        Me.cboMBL.Size = New System.Drawing.Size(210, 21)
        Me.cboMBL.TabIndex = 11
        '
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(7, 12)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(47, 17)
        Me.chkSale.TabIndex = 18
        Me.chkSale.Text = "Sale"
        Me.chkSale.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.Deusd, Me.DeVND, Me.CreUSD, Me.CreVND, Me.OSUSD, Me.OSVND})
        Me.DataGridView1.Location = New System.Drawing.Point(7, 142)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(757, 311)
        Me.DataGridView1.TabIndex = 19
        '
        'item
        '
        Me.item.HeaderText = "item"
        Me.item.Name = "item"
        '
        'Deusd
        '
        Me.Deusd.HeaderText = "DeUSD"
        Me.Deusd.Name = "Deusd"
        '
        'DeVND
        '
        Me.DeVND.HeaderText = "DeVND"
        Me.DeVND.Name = "DeVND"
        '
        'CreUSD
        '
        Me.CreUSD.HeaderText = "CreUSD"
        Me.CreUSD.Name = "CreUSD"
        '
        'CreVND
        '
        Me.CreVND.HeaderText = "CreVND"
        Me.CreVND.Name = "CreVND"
        '
        'OSUSD
        '
        Me.OSUSD.HeaderText = "OSDe"
        Me.OSUSD.Name = "OSUSD"
        '
        'OSVND
        '
        Me.OSVND.HeaderText = "OSCre"
        Me.OSVND.Name = "OSVND"
        '
        'frmJOBOutbound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 488)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.chkSale)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdOKH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboHBL)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMBL)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJOBOutbound"
        Me.Text = "JOB - Outbound"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdOKH As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboHBL As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMBL As System.Windows.Forms.ComboBox
    Friend WithEvents chkSale As System.Windows.Forms.CheckBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deusd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSVND As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
