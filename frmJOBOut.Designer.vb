<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJOBOut
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmJOBOut))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.item = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Deusd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreUSD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OSUSD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OSVND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.chkSale = New System.Windows.Forms.CheckBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdOKH = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboHBL = New System.Windows.Forms.ComboBox
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboMBL = New System.Windows.Forms.ComboBox
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.item, Me.Deusd, Me.DeVND, Me.CreUSD, Me.CreVND, Me.OSUSD, Me.OSVND})
        Me.DataGridView1.Location = New System.Drawing.Point(492, 23)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(0, 35)
        Me.DataGridView1.TabIndex = 23
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
        'chkSale
        '
        Me.chkSale.AutoSize = True
        Me.chkSale.Location = New System.Drawing.Point(552, 36)
        Me.chkSale.Name = "chkSale"
        Me.chkSale.Size = New System.Drawing.Size(47, 17)
        Me.chkSale.TabIndex = 22
        Me.chkSale.Text = "Sale"
        Me.chkSale.UseVisualStyleBackColor = True
        Me.chkSale.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(232, 50)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(128, 23)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "OCEAN INBOUND"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 50)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 23)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Ok"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(366, 79)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdOKH
        '
        Me.cmdOKH.Location = New System.Drawing.Point(366, 50)
        Me.cmdOKH.Name = "cmdOKH"
        Me.cmdOKH.Size = New System.Drawing.Size(75, 23)
        Me.cmdOKH.TabIndex = 18
        Me.cmdOKH.Text = "JOB"
        Me.cmdOKH.UseVisualStyleBackColor = True
        Me.cmdOKH.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(229, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "HBL :"
        Me.Label2.Visible = False
        '
        'cboHBL
        '
        Me.cboHBL.FormattingEnabled = True
        Me.cboHBL.Location = New System.Drawing.Point(232, 23)
        Me.cboHBL.Name = "cboHBL"
        Me.cboHBL.Size = New System.Drawing.Size(210, 21)
        Me.cboHBL.TabIndex = 16
        Me.cboHBL.Visible = False
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(151, 50)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 15
        Me.cmdOK.Text = "JOB"
        Me.cmdOK.UseVisualStyleBackColor = True
        Me.cmdOK.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label1.Location = New System.Drawing.Point(13, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Ref :"
        '
        'cboMBL
        '
        Me.cboMBL.FormattingEnabled = True
        Me.cboMBL.Location = New System.Drawing.Point(16, 23)
        Me.cboMBL.Name = "cboMBL"
        Me.cboMBL.Size = New System.Drawing.Size(210, 21)
        Me.cboMBL.TabIndex = 13
        '
        'frmJOBOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(249, 94)
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
        Me.Name = "frmJOBOut"
        Me.Text = "JOB Outbound"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Deusd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSUSD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OSVND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkSale As System.Windows.Forms.CheckBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdOKH As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboHBL As System.Windows.Forms.ComboBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboMBL As System.Windows.Forms.ComboBox
End Class
