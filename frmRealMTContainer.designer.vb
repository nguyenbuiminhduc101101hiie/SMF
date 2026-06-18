<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRealMTContainer
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgdBookingContainerVessel = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblSoundContainerLastupdate = New System.Windows.Forms.Label
        Me.lblContainerLastSupply = New System.Windows.Forms.Label
        Me.cmdrefresh = New System.Windows.Forms.Button
        CType(Me.dgdBookingContainerAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdCountMNG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdBookingContainerVessel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.dgdBookingContainerAll.Location = New System.Drawing.Point(12, 210)
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
        Me.dgdBookingContainerAll.Size = New System.Drawing.Size(815, 164)
        Me.dgdBookingContainerAll.TabIndex = 113
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
        Me.DataGridViewTextBoxColumn3.HeaderText = "Quantity 20GP"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "Cont40GPBook"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Quantity 40GP"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Cont40HCBook"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Quantity 40HC"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "Cont45HCBook"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Quantity 45HC"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Cont20RFBook"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Quantity 20RF"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Cont40RFBook"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Quantity 40RF"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Cont40RHBook"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Quantity 40RH"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
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
        Me.dgdCountMNG.Location = New System.Drawing.Point(5, 23)
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
        Me.dgdCountMNG.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgdCountMNG.Size = New System.Drawing.Size(822, 165)
        Me.dgdCountMNG.TabIndex = 112
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
        '
        'Quantity40GP
        '
        Me.Quantity40GP.DataPropertyName = "Quantity40GP"
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Quantity40GP.DefaultCellStyle = DataGridViewCellStyle7
        Me.Quantity40GP.HeaderText = "Quantity 40GP"
        Me.Quantity40GP.Name = "Quantity40GP"
        Me.Quantity40GP.ReadOnly = True
        '
        'Quantity40HC
        '
        Me.Quantity40HC.DataPropertyName = "Quantity40HC"
        Me.Quantity40HC.HeaderText = "Quantity 40HC"
        Me.Quantity40HC.Name = "Quantity40HC"
        Me.Quantity40HC.ReadOnly = True
        '
        'Quantity45HC
        '
        Me.Quantity45HC.DataPropertyName = "Quantity45HC"
        Me.Quantity45HC.HeaderText = "Quantity 45HC"
        Me.Quantity45HC.Name = "Quantity45HC"
        Me.Quantity45HC.ReadOnly = True
        '
        'Quantity20RF
        '
        Me.Quantity20RF.DataPropertyName = "Quantity20RF"
        Me.Quantity20RF.HeaderText = "Quantity 20RF"
        Me.Quantity20RF.Name = "Quantity20RF"
        Me.Quantity20RF.ReadOnly = True
        '
        'Quantity40RF
        '
        Me.Quantity40RF.DataPropertyName = "Quantity40RF"
        Me.Quantity40RF.HeaderText = "Quantity 40RF"
        Me.Quantity40RF.Name = "Quantity40RF"
        Me.Quantity40RF.ReadOnly = True
        '
        'Quantity40RH
        '
        Me.Quantity40RH.DataPropertyName = "Quantity40RH"
        Me.Quantity40RH.HeaderText = "Quantity 40RH"
        Me.Quantity40RH.Name = "Quantity40RH"
        Me.Quantity40RH.ReadOnly = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(8, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Container Book"
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(8, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 16)
        Me.Label2.TabIndex = 114
        Me.Label2.Text = "Real Container AT CY"
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(480, 377)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 124
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(170, 379)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(256, 21)
        Me.cboVessel.TabIndex = 123
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(34, 381)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 16)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Vessel / V.No/ ETD  :"
        '
        'dgdBookingContainerVessel
        '
        Me.dgdBookingContainerVessel.AllowUserToAddRows = False
        Me.dgdBookingContainerVessel.AllowUserToDeleteRows = False
        Me.dgdBookingContainerVessel.AllowUserToOrderColumns = True
        Me.dgdBookingContainerVessel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdBookingContainerVessel.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingContainerVessel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgdBookingContainerVessel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBookingContainerVessel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16})
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdBookingContainerVessel.DefaultCellStyle = DataGridViewCellStyle11
        Me.dgdBookingContainerVessel.Location = New System.Drawing.Point(12, 406)
        Me.dgdBookingContainerVessel.Name = "dgdBookingContainerVessel"
        Me.dgdBookingContainerVessel.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingContainerVessel.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgdBookingContainerVessel.RowHeadersWidth = 10
        Me.dgdBookingContainerVessel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.dgdBookingContainerVessel.Size = New System.Drawing.Size(815, 159)
        Me.dgdBookingContainerVessel.TabIndex = 121
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "EmptyContainerPlace"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CY (Book)"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Cont20GPBook"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Quantity 20GP"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Cont40GPBook"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Quantity 40GP"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "Cont40HCBook"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Quantity 40HC"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Cont45HCBook"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Quantity 45HC"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Cont20RFBook"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Quantity 20RF"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Cont40RFBook"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Quantity 40RF"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Cont40RHBook"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Quantity 40RH"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.ReadOnly = True
        '
        'lblSoundContainerLastupdate
        '
        Me.lblSoundContainerLastupdate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSoundContainerLastupdate.AutoSize = True
        Me.lblSoundContainerLastupdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSoundContainerLastupdate.ForeColor = System.Drawing.Color.Maroon
        Me.lblSoundContainerLastupdate.Location = New System.Drawing.Point(167, 4)
        Me.lblSoundContainerLastupdate.Name = "lblSoundContainerLastupdate"
        Me.lblSoundContainerLastupdate.Size = New System.Drawing.Size(189, 16)
        Me.lblSoundContainerLastupdate.TabIndex = 114
        Me.lblSoundContainerLastupdate.Text = "Sound Container Last Update :"
        '
        'lblContainerLastSupply
        '
        Me.lblContainerLastSupply.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblContainerLastSupply.AutoSize = True
        Me.lblContainerLastSupply.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContainerLastSupply.ForeColor = System.Drawing.Color.Maroon
        Me.lblContainerLastSupply.Location = New System.Drawing.Point(155, 191)
        Me.lblContainerLastSupply.Name = "lblContainerLastSupply"
        Me.lblContainerLastSupply.Size = New System.Drawing.Size(186, 16)
        Me.lblContainerLastSupply.TabIndex = 114
        Me.lblContainerLastSupply.Text = "Sound Container Last Supply :"
        '
        'cmdrefresh
        '
        Me.cmdrefresh.Location = New System.Drawing.Point(734, -1)
        Me.cmdrefresh.Name = "cmdrefresh"
        Me.cmdrefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdrefresh.TabIndex = 125
        Me.cmdrefresh.Text = "Refresh"
        Me.cmdrefresh.UseVisualStyleBackColor = True
        '
        'frmRealMTContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 573)
        Me.Controls.Add(Me.cmdrefresh)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgdBookingContainerVessel)
        Me.Controls.Add(Me.lblContainerLastSupply)
        Me.Controls.Add(Me.lblSoundContainerLastupdate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgdBookingContainerAll)
        Me.Controls.Add(Me.dgdCountMNG)
        Me.MaximumSize = New System.Drawing.Size(837, 631)
        Me.Name = "frmRealMTContainer"
        Me.Text = "Real MT Container"
        Me.TopMost = True
        CType(Me.dgdBookingContainerAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdCountMNG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdBookingContainerVessel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdBookingContainerAll As System.Windows.Forms.DataGridView
    Friend WithEvents dgdCountMNG As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgdBookingContainerVessel As System.Windows.Forms.DataGridView
    Friend WithEvents finalICD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Quantity40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblSoundContainerLastupdate As System.Windows.Forms.Label
    Friend WithEvents lblContainerLastSupply As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdrefresh As System.Windows.Forms.Button
End Class
