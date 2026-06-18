<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRPTContainer
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cboContainer_No = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgdGeneral = New System.Windows.Forms.DataGridView
        Me.bookingno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETDOB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.dgdGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboContainer_No
        '
        Me.cboContainer_No.FormattingEnabled = True
        Me.cboContainer_No.Location = New System.Drawing.Point(85, 31)
        Me.cboContainer_No.Name = "cboContainer_No"
        Me.cboContainer_No.Size = New System.Drawing.Size(121, 21)
        Me.cboContainer_No.TabIndex = 186
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 185
        Me.Label1.Text = "Container No :"
        '
        'dgdGeneral
        '
        Me.dgdGeneral.AllowUserToAddRows = False
        Me.dgdGeneral.AllowUserToDeleteRows = False
        Me.dgdGeneral.AllowUserToResizeRows = False
        Me.dgdGeneral.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdGeneral.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgdGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdGeneral.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bookingno, Me.BL_NO, Me.ETDOB, Me.Container_No, Me.ContainerType})
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgdGeneral.DefaultCellStyle = DataGridViewCellStyle15
        Me.dgdGeneral.Location = New System.Drawing.Point(12, 58)
        Me.dgdGeneral.Name = "dgdGeneral"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdGeneral.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgdGeneral.ShowCellErrors = False
        Me.dgdGeneral.ShowEditingIcon = False
        Me.dgdGeneral.ShowRowErrors = False
        Me.dgdGeneral.Size = New System.Drawing.Size(797, 326)
        Me.dgdGeneral.TabIndex = 183
        '
        'bookingno
        '
        Me.bookingno.DataPropertyName = "bookingno"
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.bookingno.DefaultCellStyle = DataGridViewCellStyle10
        Me.bookingno.HeaderText = "Booking/LOT"
        Me.bookingno.Name = "bookingno"
        '
        'BL_NO
        '
        Me.BL_NO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.BL_NO.DataPropertyName = "BL_NO_Outbound"
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Green
        Me.BL_NO.DefaultCellStyle = DataGridViewCellStyle11
        Me.BL_NO.HeaderText = "Bill No (Outbound)"
        Me.BL_NO.Name = "BL_NO"
        Me.BL_NO.Width = 124
        '
        'ETDOB
        '
        Me.ETDOB.DataPropertyName = "ETDOB"
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Green
        Me.ETDOB.DefaultCellStyle = DataGridViewCellStyle12
        Me.ETDOB.HeaderText = "ETD Outbound"
        Me.ETDOB.Name = "ETDOB"
        Me.ETDOB.ToolTipText = "ETD Of Outbound Vessel"
        '
        'Container_No
        '
        Me.Container_No.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Container_No.DataPropertyName = "Container_No"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.Blue
        Me.Container_No.DefaultCellStyle = DataGridViewCellStyle13
        Me.Container_No.HeaderText = "Containers No."
        Me.Container_No.Name = "Container_No"
        Me.Container_No.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Container_No.ToolTipText = "Container No"
        Me.Container_No.Width = 87
        '
        'ContainerType
        '
        Me.ContainerType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ContainerType.DataPropertyName = "CTN_SIZE_TYPE"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.Blue
        Me.ContainerType.DefaultCellStyle = DataGridViewCellStyle14
        Me.ContainerType.HeaderText = "Containers Type"
        Me.ContainerType.Name = "ContainerType"
        Me.ContainerType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ContainerType.ToolTipText = "Container Type"
        Me.ContainerType.Width = 95
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPrint, Me.smnuExportExcel, Me.mnuExit})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(824, 24)
        Me.MenuStrip1.TabIndex = 184
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuPrint
        '
        Me.mnuPrint.ForeColor = System.Drawing.Color.Maroon
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Size = New System.Drawing.Size(41, 20)
        Me.mnuPrint.Text = "&Print"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'mnuExit
        '
        Me.mnuExit.ForeColor = System.Drawing.Color.DarkRed
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(37, 20)
        Me.mnuExit.Text = "&Exit"
        '
        'frmRPTContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 402)
        Me.Controls.Add(Me.cboContainer_No)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgdGeneral)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmRPTContainer"
        Me.Text = "Query Container"
        CType(Me.dgdGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboContainer_No As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgdGeneral As System.Windows.Forms.DataGridView
    Friend WithEvents bookingno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETDOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
End Class
