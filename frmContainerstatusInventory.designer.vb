<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContainerstatusInventory
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
        Me.dgdCountMNG = New System.Windows.Forms.DataGridView
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdexport = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.FinalICD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity20OT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40OT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity20FR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40FR = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdCountMNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgdCountMNG
        '
        Me.dgdCountMNG.AllowUserToAddRows = False
        Me.dgdCountMNG.AllowUserToDeleteRows = False
        Me.dgdCountMNG.AllowUserToOrderColumns = True
        Me.dgdCountMNG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdCountMNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCountMNG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.FinalICD, Me.Quantity20GP, Me.Quantity40GP, Me.Quantity40HC, Me.Quantity45HC, Me.Quantity20RF, Me.Quantity40RF, Me.Quantity40RH, Me.Quantity20OT, Me.Quantity40OT, Me.Quantity20FR, Me.Quantity40FR})
        Me.dgdCountMNG.Location = New System.Drawing.Point(0, 51)
        Me.dgdCountMNG.Name = "dgdCountMNG"
        Me.dgdCountMNG.ReadOnly = True
        Me.dgdCountMNG.RowHeadersWidth = 10
        Me.dgdCountMNG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgdCountMNG.Size = New System.Drawing.Size(531, 282)
        Me.dgdCountMNG.TabIndex = 109
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Items.AddRange(New Object() {"All", "Sound Container", "To be Inspected", "Damage Container", "Full Import", "Full To Consignee", "Full Export", "Empty To Shipper", "Empty Container Reposit"})
        Me.cboStatus.Location = New System.Drawing.Point(114, 12)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(194, 21)
        Me.cboStatus.TabIndex = 110
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(3, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Status Of Container  :"
        '
        'cmdexport
        '
        Me.cmdexport.Location = New System.Drawing.Point(330, 11)
        Me.cmdexport.Name = "cmdexport"
        Me.cmdexport.Size = New System.Drawing.Size(94, 23)
        Me.cmdexport.TabIndex = 112
        Me.cmdexport.Text = "Export to Excel"
        Me.cmdexport.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(430, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(51, 23)
        Me.Button1.TabIndex = 112
        Me.Button1.Text = "&Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FinalICD
        '
        Me.FinalICD.DataPropertyName = "FinalICD"
        Me.FinalICD.HeaderText = "CY"
        Me.FinalICD.Name = "FinalICD"
        Me.FinalICD.ReadOnly = True
        '
        'Quantity20GP
        '
        Me.Quantity20GP.DataPropertyName = "Quantity20GP"
        Me.Quantity20GP.HeaderText = "Quantity 20GP"
        Me.Quantity20GP.Name = "Quantity20GP"
        Me.Quantity20GP.ReadOnly = True
        Me.Quantity20GP.Width = 50
        '
        'Quantity40GP
        '
        Me.Quantity40GP.DataPropertyName = "Quantity40GP"
        Me.Quantity40GP.HeaderText = "Quantity 40GP"
        Me.Quantity40GP.Name = "Quantity40GP"
        Me.Quantity40GP.ReadOnly = True
        Me.Quantity40GP.Width = 50
        '
        'Quantity40HC
        '
        Me.Quantity40HC.DataPropertyName = "Quantity40HC"
        Me.Quantity40HC.HeaderText = "Quantity 40HC"
        Me.Quantity40HC.Name = "Quantity40HC"
        Me.Quantity40HC.ReadOnly = True
        Me.Quantity40HC.Width = 50
        '
        'Quantity45HC
        '
        Me.Quantity45HC.DataPropertyName = "Quantity45HC"
        Me.Quantity45HC.HeaderText = "Quantity 45HC"
        Me.Quantity45HC.Name = "Quantity45HC"
        Me.Quantity45HC.ReadOnly = True
        Me.Quantity45HC.Width = 50
        '
        'Quantity20RF
        '
        Me.Quantity20RF.DataPropertyName = "Quantity20RF"
        Me.Quantity20RF.HeaderText = "Quantity 20RF"
        Me.Quantity20RF.Name = "Quantity20RF"
        Me.Quantity20RF.ReadOnly = True
        Me.Quantity20RF.Width = 50
        '
        'Quantity40RF
        '
        Me.Quantity40RF.DataPropertyName = "Quantity40RF"
        Me.Quantity40RF.HeaderText = "Quantity 40RF"
        Me.Quantity40RF.Name = "Quantity40RF"
        Me.Quantity40RF.ReadOnly = True
        Me.Quantity40RF.Width = 50
        '
        'Quantity40RH
        '
        Me.Quantity40RH.DataPropertyName = "Quantity40RH"
        Me.Quantity40RH.HeaderText = "Quantity 40RH"
        Me.Quantity40RH.Name = "Quantity40RH"
        Me.Quantity40RH.ReadOnly = True
        Me.Quantity40RH.Width = 50
        '
        'Quantity20OT
        '
        Me.Quantity20OT.DataPropertyName = "Quantity20OT"
        Me.Quantity20OT.HeaderText = "Quantity 20OT"
        Me.Quantity20OT.Name = "Quantity20OT"
        Me.Quantity20OT.ReadOnly = True
        '
        'Quantity40OT
        '
        Me.Quantity40OT.DataPropertyName = "Quantity40OT"
        Me.Quantity40OT.HeaderText = "Quantity 40OT"
        Me.Quantity40OT.Name = "Quantity40OT"
        Me.Quantity40OT.ReadOnly = True
        '
        'Quantity20FR
        '
        Me.Quantity20FR.DataPropertyName = "Quantity20FR"
        Me.Quantity20FR.HeaderText = "Quantity 20FR"
        Me.Quantity20FR.Name = "Quantity20FR"
        Me.Quantity20FR.ReadOnly = True
        '
        'Quantity40FR
        '
        Me.Quantity40FR.DataPropertyName = "Quantity40FR"
        Me.Quantity40FR.HeaderText = "Quantity 40FR"
        Me.Quantity40FR.Name = "Quantity40FR"
        Me.Quantity40FR.ReadOnly = True
        '
        'frmContainerstatusInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 333)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdexport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStatus)
        Me.Controls.Add(Me.dgdCountMNG)
        Me.Name = "frmContainerstatusInventory"
        Me.Text = "Status of Container"
        CType(Me.dgdCountMNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdCountMNG As System.Windows.Forms.DataGridView
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdexport As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents FinalICD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20OT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40OT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20FR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40FR As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
