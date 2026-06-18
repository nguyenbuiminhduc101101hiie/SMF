<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingVessel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgdBookingContainerAll = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgdCountMNG = New System.Windows.Forms.DataGridView
        Me.finalICD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Quantity40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboVessel = New System.Windows.Forms.ComboBox
        CType(Me.dgdBookingContainerAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdCountMNG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 20)
        Me.Label2.TabIndex = 117
        Me.Label2.Text = "Real Container AT CY"
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(12, 249)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(156, 20)
        Me.Label1.TabIndex = 118
        Me.Label1.Text = "Vessel / V.No/ ETD  :"
        '
        'dgdBookingContainerAll
        '
        Me.dgdBookingContainerAll.AllowUserToAddRows = False
        Me.dgdBookingContainerAll.AllowUserToDeleteRows = False
        Me.dgdBookingContainerAll.AllowUserToOrderColumns = True
        Me.dgdBookingContainerAll.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdBookingContainerAll.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingContainerAll.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdBookingContainerAll.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBookingContainerAll.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdBookingContainerAll.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgdBookingContainerAll.Location = New System.Drawing.Point(12, 275)
        Me.dgdBookingContainerAll.Name = "dgdBookingContainerAll"
        Me.dgdBookingContainerAll.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingContainerAll.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgdBookingContainerAll.RowHeadersWidth = 10
        Me.dgdBookingContainerAll.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgdBookingContainerAll.Size = New System.Drawing.Size(712, 217)
        Me.dgdBookingContainerAll.TabIndex = 116
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "EmptyContainerPlace"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CY (Book)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Cont20GPBook"
        Me.DataGridViewTextBoxColumn3.HeaderText = "20GP (Book-All)"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 70
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Cont40GPBook"
        Me.DataGridViewTextBoxColumn4.HeaderText = "40GP  (Book-All)"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 70
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Cont40HCBook"
        Me.DataGridViewTextBoxColumn5.HeaderText = "40HC (Book-All)"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 70
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Cont45HCBook"
        Me.DataGridViewTextBoxColumn6.HeaderText = "45HC (Book-All)"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 70
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Cont20RFBook"
        Me.DataGridViewTextBoxColumn7.HeaderText = "20RF (Book-All)"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 70
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Cont40RFBook"
        Me.DataGridViewTextBoxColumn8.HeaderText = "40RF (Book-All)"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 70
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Cont40RHBook"
        Me.DataGridViewTextBoxColumn9.HeaderText = "40RH (Book-All)"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 70
        '
        'dgdCountMNG
        '
        Me.dgdCountMNG.AllowUserToAddRows = False
        Me.dgdCountMNG.AllowUserToDeleteRows = False
        Me.dgdCountMNG.AllowUserToOrderColumns = True
        Me.dgdCountMNG.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdCountMNG.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdCountMNG.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgdCountMNG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdCountMNG.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.finalICD, Me.Quantity20GP, Me.Quantity40GP, Me.Quantity40HC, Me.Quantity45HC, Me.Quantity20RF, Me.Quantity40RF, Me.Quantity40RH})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdCountMNG.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgdCountMNG.Location = New System.Drawing.Point(16, 41)
        Me.dgdCountMNG.Name = "dgdCountMNG"
        Me.dgdCountMNG.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdCountMNG.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdCountMNG.RowHeadersWidth = 10
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgdCountMNG.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgdCountMNG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgdCountMNG.Size = New System.Drawing.Size(712, 167)
        Me.dgdCountMNG.TabIndex = 115
        '
        'finalICD
        '
        Me.finalICD.DataPropertyName = "finalICD"
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.finalICD.DefaultCellStyle = DataGridViewCellStyle5
        Me.finalICD.HeaderText = "Empty CY"
        Me.finalICD.Name = "finalICD"
        Me.finalICD.ReadOnly = True
        '
        'Quantity20GP
        '
        Me.Quantity20GP.DataPropertyName = "Quantity20GP"
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity20GP.DefaultCellStyle = DataGridViewCellStyle6
        Me.Quantity20GP.HeaderText = "Quantity 20GP"
        Me.Quantity20GP.Name = "Quantity20GP"
        Me.Quantity20GP.ReadOnly = True
        Me.Quantity20GP.Width = 50
        '
        'Quantity40GP
        '
        Me.Quantity40GP.DataPropertyName = "Quantity40GP"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity40GP.DefaultCellStyle = DataGridViewCellStyle7
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
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(170, 248)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(256, 21)
        Me.cboVessel.TabIndex = 119
        '
        'frmBookingVessel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 501)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgdBookingContainerAll)
        Me.Controls.Add(Me.dgdCountMNG)
        Me.Name = "frmBookingVessel"
        Me.Text = "Container Booking (Vessel)"
        CType(Me.dgdBookingContainerAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdCountMNG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgdBookingContainerAll As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgdCountMNG As System.Windows.Forms.DataGridView
    Friend WithEvents finalICD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
End Class
