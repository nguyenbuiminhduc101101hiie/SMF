<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShipperConfirm
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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboShipperREF_C = New System.Windows.Forms.ComboBox
        Me.cboShipperREF_H = New System.Windows.Forms.ComboBox
        Me.txtBL_NO = New System.Windows.Forms.TextBox
        Me.dgdShipperREF_H = New System.Windows.Forms.DataGridView
        Me.HBLH_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ctmnuShipper_H = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmnuDel_H = New System.Windows.Forms.ToolStripMenuItem
        Me.dgdShipperREF_C = New System.Windows.Forms.DataGridView
        Me.CBLH_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdAdd_C = New System.Windows.Forms.Button
        Me.cmdAdd_H = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.ctmnuChipper_C = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctmnuDel_C = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgdShipperREF_H, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmnuShipper_H.SuspendLayout()
        CType(Me.dgdShipperREF_C, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctmnuChipper_C.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(35, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Master Bill No :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Shipper's REF (H) : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Shipper's REF (C) :"
        '
        'cboShipperREF_C
        '
        Me.cboShipperREF_C.FormattingEnabled = True
        Me.cboShipperREF_C.Location = New System.Drawing.Point(98, 160)
        Me.cboShipperREF_C.Name = "cboShipperREF_C"
        Me.cboShipperREF_C.Size = New System.Drawing.Size(154, 21)
        Me.cboShipperREF_C.TabIndex = 3
        '
        'cboShipperREF_H
        '
        Me.cboShipperREF_H.FormattingEnabled = True
        Me.cboShipperREF_H.Location = New System.Drawing.Point(114, 28)
        Me.cboShipperREF_H.Name = "cboShipperREF_H"
        Me.cboShipperREF_H.Size = New System.Drawing.Size(154, 21)
        Me.cboShipperREF_H.TabIndex = 4
        '
        'txtBL_NO
        '
        Me.txtBL_NO.Location = New System.Drawing.Point(114, 2)
        Me.txtBL_NO.Name = "txtBL_NO"
        Me.txtBL_NO.Size = New System.Drawing.Size(154, 20)
        Me.txtBL_NO.TabIndex = 5
        '
        'dgdShipperREF_H
        '
        Me.dgdShipperREF_H.AllowUserToAddRows = False
        Me.dgdShipperREF_H.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShipperREF_H.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HBLH_NO})
        Me.dgdShipperREF_H.ContextMenuStrip = Me.ctmnuShipper_H
        Me.dgdShipperREF_H.Location = New System.Drawing.Point(12, 72)
        Me.dgdShipperREF_H.Name = "dgdShipperREF_H"
        Me.dgdShipperREF_H.Size = New System.Drawing.Size(510, 79)
        Me.dgdShipperREF_H.TabIndex = 6
        '
        'HBLH_NO
        '
        Me.HBLH_NO.HeaderText = "House Bill No"
        Me.HBLH_NO.Name = "HBLH_NO"
        Me.HBLH_NO.Width = 300
        '
        'ctmnuShipper_H
        '
        Me.ctmnuShipper_H.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmnuDel_H})
        Me.ctmnuShipper_H.Name = "ContextMenuStrip1"
        Me.ctmnuShipper_H.Size = New System.Drawing.Size(108, 26)
        '
        'ctmnuDel_H
        '
        Me.ctmnuDel_H.Name = "ctmnuDel_H"
        Me.ctmnuDel_H.Size = New System.Drawing.Size(107, 22)
        Me.ctmnuDel_H.Text = "Delate"
        '
        'dgdShipperREF_C
        '
        Me.dgdShipperREF_C.AllowUserToAddRows = False
        Me.dgdShipperREF_C.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShipperREF_C.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CBLH_NO})
        Me.dgdShipperREF_C.Location = New System.Drawing.Point(9, 184)
        Me.dgdShipperREF_C.Name = "dgdShipperREF_C"
        Me.dgdShipperREF_C.Size = New System.Drawing.Size(513, 79)
        Me.dgdShipperREF_C.TabIndex = 7
        '
        'CBLH_NO
        '
        Me.CBLH_NO.HeaderText = "COLO BILL"
        Me.CBLH_NO.Name = "CBLH_NO"
        Me.CBLH_NO.Width = 300
        '
        'cmdAdd_C
        '
        Me.cmdAdd_C.Location = New System.Drawing.Point(447, 158)
        Me.cmdAdd_C.Name = "cmdAdd_C"
        Me.cmdAdd_C.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd_C.TabIndex = 8
        Me.cmdAdd_C.Text = "Add"
        Me.cmdAdd_C.UseVisualStyleBackColor = True
        '
        'cmdAdd_H
        '
        Me.cmdAdd_H.Location = New System.Drawing.Point(447, 43)
        Me.cmdAdd_H.Name = "cmdAdd_H"
        Me.cmdAdd_H.Size = New System.Drawing.Size(75, 23)
        Me.cmdAdd_H.TabIndex = 9
        Me.cmdAdd_H.Text = "Add"
        Me.cmdAdd_H.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(447, 269)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 10
        Me.cmdOk.Text = "Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'ctmnuChipper_C
        '
        Me.ctmnuChipper_C.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctmnuDel_C})
        Me.ctmnuChipper_C.Name = "ctmnuChipper_C"
        Me.ctmnuChipper_C.Size = New System.Drawing.Size(108, 26)
        '
        'ctmnuDel_C
        '
        Me.ctmnuDel_C.Name = "ctmnuDel_C"
        Me.ctmnuDel_C.Size = New System.Drawing.Size(107, 22)
        Me.ctmnuDel_C.Text = "Delete"
        '
        'frmShipperConfirm
        '
        Me.AcceptButton = Me.cmdOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 301)
        Me.Controls.Add(Me.cmdAdd_H)
        Me.Controls.Add(Me.cmdAdd_C)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dgdShipperREF_C)
        Me.Controls.Add(Me.dgdShipperREF_H)
        Me.Controls.Add(Me.cboShipperREF_C)
        Me.Controls.Add(Me.txtBL_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboShipperREF_H)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmShipperConfirm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Shipper Confirm"
        CType(Me.dgdShipperREF_H, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctmnuShipper_H.ResumeLayout(False)
        CType(Me.dgdShipperREF_C, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctmnuChipper_C.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboShipperREF_C As System.Windows.Forms.ComboBox
    Friend WithEvents cboShipperREF_H As System.Windows.Forms.ComboBox
    Friend WithEvents txtBL_NO As System.Windows.Forms.TextBox
    Friend WithEvents dgdShipperREF_H As System.Windows.Forms.DataGridView
    Friend WithEvents dgdShipperREF_C As System.Windows.Forms.DataGridView
    Friend WithEvents cmdAdd_C As System.Windows.Forms.Button
    Friend WithEvents cmdAdd_H As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents ctmnuShipper_H As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmnuDel_H As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctmnuChipper_C As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctmnuDel_C As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HBLH_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CBLH_NO As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
