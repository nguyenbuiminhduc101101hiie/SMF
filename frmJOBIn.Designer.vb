<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJOBIn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJOBIn))
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMBL = New System.Windows.Forms.ComboBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboHBL = New System.Windows.Forms.ComboBox
        Me.cmdOKH = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(9, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ref :"
        '
        'cboMBL
        '
        Me.cboMBL.FormattingEnabled = True
        Me.cboMBL.Location = New System.Drawing.Point(12, 22)
        Me.cboMBL.Name = "cboMBL"
        Me.cboMBL.Size = New System.Drawing.Size(210, 21)
        Me.cboMBL.TabIndex = 2
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(147, 49)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 4
        Me.cmdOK.Text = "JOB"
        Me.cmdOK.UseVisualStyleBackColor = True
        Me.cmdOK.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(225, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "HBL :"
        Me.Label2.Visible = False
        '
        'cboHBL
        '
        Me.cboHBL.FormattingEnabled = True
        Me.cboHBL.Location = New System.Drawing.Point(228, 22)
        Me.cboHBL.Name = "cboHBL"
        Me.cboHBL.Size = New System.Drawing.Size(210, 21)
        Me.cboHBL.TabIndex = 5
        Me.cboHBL.Visible = False
        '
        'cmdOKH
        '
        Me.cmdOKH.Location = New System.Drawing.Point(362, 49)
        Me.cmdOKH.Name = "cmdOKH"
        Me.cmdOKH.Size = New System.Drawing.Size(75, 23)
        Me.cmdOKH.TabIndex = 7
        Me.cmdOKH.Text = "JOB"
        Me.cmdOKH.UseVisualStyleBackColor = True
        Me.cmdOKH.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(362, 78)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 49)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "OCEAN INBOUND"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(228, 49)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "OCEAN INBOUND"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(548, 35)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(47, 17)
        Me.chkSale.TabIndex = 11
        Me.chkSale.Text = "Sale"
        Me.chkSale.UseVisualStyleBackColor = True
        Me.chkSale.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.Deusd, Me.DeVND, Me.CreUSD, Me.CreVND, Me.OSUSD, Me.OSVND})
        Me.DataGridView1.Location = New System.Drawing.Point(488, 22)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(0, 0)
        Me.DataGridView1.TabIndex = 12
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
        Me.OSUSD.HeaderText = "OSDE"
        Me.OSUSD.Name = "OSUSD"
        '
        'OSVND
        '
        Me.OSVND.HeaderText = "OSCRE"
        Me.OSVND.Name = "OSVND"
        '
        'frmJOBIn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(239, 99)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.chkSale)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdOKH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboHBL)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboMBL)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmJOBIn"
        Me.Text = "JOB - Inbound"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMBL As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboHBL As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOKH As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
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
