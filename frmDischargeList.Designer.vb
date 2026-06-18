<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDischargeList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDischargeList))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbovoy = New System.Windows.Forms.ComboBox()
        Me.cboVessel = New System.Windows.Forms.ComboBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.contNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.sealno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NETWEIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GROSSWEIGHT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PACKAGEDESCRIPTIONOFGOODS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BLNO = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.OPRCODE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DESTINATION = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chlallsoccoc = New System.Windows.Forms.RadioButton()
        Me.CHKCOC = New System.Windows.Forms.RadioButton()
        Me.CHKSOC = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cbovoy)
        Me.GroupBox1.Controls.Add(Me.cboVessel)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 116)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vessel/Voyage"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(265, 86)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Voyage :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Vessel :"
        '
        'cbovoy
        '
        Me.cbovoy.AccessibleDescription = "frmDischargeList"
        Me.cbovoy.FormattingEnabled = True
        Me.cbovoy.Location = New System.Drawing.Point(62, 59)
        Me.cbovoy.Name = "cbovoy"
        Me.cbovoy.Size = New System.Drawing.Size(278, 21)
        Me.cbovoy.TabIndex = 1
        '
        'cboVessel
        '
        Me.cboVessel.AccessibleDescription = "frmDischargeList"
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(62, 32)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(278, 21)
        Me.cboVessel.TabIndex = 0
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.contNo, Me.sealno, Me.NETWEIGHT, Me.GROSSWEIGHT, Me.PACKAGEDESCRIPTIONOFGOODS, Me.BLNO, Me.OPRCODE, Me.DESTINATION, Me.ETA, Me.POD})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 134)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1035, 351)
        Me.DataGridView1.TabIndex = 1
        '
        'contNo
        '
        Me.contNo.HeaderText = "CONT. NO."
        Me.contNo.Name = "contNo"
        Me.contNo.Width = 80
        '
        'sealno
        '
        Me.sealno.HeaderText = "SEAL NO."
        Me.sealno.Name = "sealno"
        Me.sealno.Width = 75
        '
        'NETWEIGHT
        '
        Me.NETWEIGHT.HeaderText = "NET WEIGHT (OF EACH CONT.)"
        Me.NETWEIGHT.Name = "NETWEIGHT"
        Me.NETWEIGHT.Width = 114
        '
        'GROSSWEIGHT
        '
        Me.GROSSWEIGHT.HeaderText = "GROSS WEIGHT (OF EACH CONT)"
        Me.GROSSWEIGHT.Name = "GROSSWEIGHT"
        Me.GROSSWEIGHT.Width = 110
        '
        'PACKAGEDESCRIPTIONOFGOODS
        '
        Me.PACKAGEDESCRIPTIONOFGOODS.HeaderText = "PACKAGE DESCRIPTION OF GOODS (COMMODITY OF EACH CONT.)"
        Me.PACKAGEDESCRIPTIONOFGOODS.Name = "PACKAGEDESCRIPTIONOFGOODS"
        Me.PACKAGEDESCRIPTIONOFGOODS.Width = 177
        '
        'BLNO
        '
        Me.BLNO.HeaderText = "B/L NO."
        Me.BLNO.Name = "BLNO"
        Me.BLNO.Width = 67
        '
        'OPRCODE
        '
        Me.OPRCODE.HeaderText = "OPR. CODE"
        Me.OPRCODE.Name = "OPRCODE"
        Me.OPRCODE.Width = 84
        '
        'DESTINATION
        '
        Me.DESTINATION.HeaderText = "DESTINATION"
        Me.DESTINATION.Name = "DESTINATION"
        Me.DESTINATION.Width = 105
        '
        'ETA
        '
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        Me.ETA.Width = 53
        '
        'POD
        '
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        Me.POD.Width = 55
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(375, 98)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Export "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(456, 98)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Exit"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.chlallsoccoc)
        Me.GroupBox2.Controls.Add(Me.CHKCOC)
        Me.GroupBox2.Controls.Add(Me.CHKSOC)
        Me.GroupBox2.Location = New System.Drawing.Point(378, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(153, 43)
        Me.GroupBox2.TabIndex = 732
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
        'frmDischargeList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1059, 497)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDischargeList"
        Me.Text = "Discharge List"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbovoy As System.Windows.Forms.ComboBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents contNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sealno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NETWEIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GROSSWEIGHT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PACKAGEDESCRIPTIONOFGOODS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BLNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPRCODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DESTINATION As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chlallsoccoc As System.Windows.Forms.RadioButton
    Friend WithEvents CHKCOC As System.Windows.Forms.RadioButton
    Friend WithEvents CHKSOC As System.Windows.Forms.RadioButton
End Class
