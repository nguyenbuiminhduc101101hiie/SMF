<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingSupplyOrder
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
        Me.dgdOrder = New System.Windows.Forms.DataGridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.mnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.txtbookingno = New System.Windows.Forms.TextBox
        Me.cmdfind = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DaiDien = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CMND = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.supplydepot = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Soluong40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OT20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OT40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FR40 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.userid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Updatetime = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdOrder
        '
        Me.dgdOrder.AllowUserToAddRows = False
        Me.dgdOrder.AllowUserToDeleteRows = False
        Me.dgdOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdOrder.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookingNo, Me.OrderNo, Me.DaiDien, Me.CMND, Me.OrderDate, Me.Remarks, Me.supplydepot, Me.Soluong20GP, Me.Soluong40GP, Me.Soluong20RF, Me.Soluong40RF, Me.Soluong40HC, Me.Soluong45HC, Me.Soluong40RH, Me.OT20, Me.OT40, Me.FR20, Me.FR40, Me.userid, Me.Updatetime})
        Me.dgdOrder.Location = New System.Drawing.Point(12, 58)
        Me.dgdOrder.Name = "dgdOrder"
        Me.dgdOrder.ReadOnly = True
        Me.dgdOrder.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdOrder.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgdOrder.Size = New System.Drawing.Size(777, 309)
        Me.dgdOrder.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSearch, Me.mnuExportExcel})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(801, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuSearch
        '
        Me.mnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.mnuSearch.Name = "mnuSearch"
        Me.mnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.mnuSearch.Text = "Search"
        '
        'mnuExportExcel
        '
        Me.mnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.mnuExportExcel.Name = "mnuExportExcel"
        Me.mnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.mnuExportExcel.Text = "Export Excel"
        '
        'txtbookingno
        '
        Me.txtbookingno.Location = New System.Drawing.Point(96, 32)
        Me.txtbookingno.Name = "txtbookingno"
        Me.txtbookingno.Size = New System.Drawing.Size(182, 20)
        Me.txtbookingno.TabIndex = 2
        '
        'cmdfind
        '
        Me.cmdfind.Location = New System.Drawing.Point(284, 29)
        Me.cmdfind.Name = "cmdfind"
        Me.cmdfind.Size = New System.Drawing.Size(75, 23)
        Me.cmdfind.TabIndex = 3
        Me.cmdfind.Text = "Find"
        Me.cmdfind.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(22, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Booking No. :"
        '
        'BookingNo
        '
        Me.BookingNo.DataPropertyName = "BookingNo"
        Me.BookingNo.HeaderText = "Booking No"
        Me.BookingNo.Name = "BookingNo"
        Me.BookingNo.ReadOnly = True
        '
        'OrderNo
        '
        Me.OrderNo.DataPropertyName = "OrderNo"
        Me.OrderNo.HeaderText = "Order No"
        Me.OrderNo.Name = "OrderNo"
        Me.OrderNo.ReadOnly = True
        '
        'DaiDien
        '
        Me.DaiDien.DataPropertyName = "DaiDien"
        Me.DaiDien.HeaderText = "Receipt Container Person"
        Me.DaiDien.Name = "DaiDien"
        Me.DaiDien.ReadOnly = True
        Me.DaiDien.Width = 200
        '
        'CMND
        '
        Me.CMND.DataPropertyName = "CMND"
        Me.CMND.HeaderText = "Card ID"
        Me.CMND.Name = "CMND"
        Me.CMND.ReadOnly = True
        '
        'OrderDate
        '
        Me.OrderDate.DataPropertyName = "OrderDate"
        Me.OrderDate.HeaderText = "Order Date"
        Me.OrderDate.Name = "OrderDate"
        Me.OrderDate.ReadOnly = True
        '
        'Remarks
        '
        Me.Remarks.DataPropertyName = "Remarks"
        Me.Remarks.HeaderText = "Remarks"
        Me.Remarks.Name = "Remarks"
        Me.Remarks.ReadOnly = True
        '
        'supplydepot
        '
        Me.supplydepot.DataPropertyName = "supplydepot"
        Me.supplydepot.HeaderText = "Supply depot"
        Me.supplydepot.Name = "supplydepot"
        Me.supplydepot.ReadOnly = True
        '
        'Soluong20GP
        '
        Me.Soluong20GP.DataPropertyName = "Soluong20GP"
        Me.Soluong20GP.HeaderText = "20GP"
        Me.Soluong20GP.Name = "Soluong20GP"
        Me.Soluong20GP.ReadOnly = True
        '
        'Soluong40GP
        '
        Me.Soluong40GP.DataPropertyName = "Soluong40GP"
        Me.Soluong40GP.HeaderText = "40GP"
        Me.Soluong40GP.Name = "Soluong40GP"
        Me.Soluong40GP.ReadOnly = True
        '
        'Soluong20RF
        '
        Me.Soluong20RF.DataPropertyName = "Soluong20RF"
        Me.Soluong20RF.HeaderText = "20RF"
        Me.Soluong20RF.Name = "Soluong20RF"
        Me.Soluong20RF.ReadOnly = True
        '
        'Soluong40RF
        '
        Me.Soluong40RF.DataPropertyName = "Soluong40RF"
        Me.Soluong40RF.HeaderText = "40RF"
        Me.Soluong40RF.Name = "Soluong40RF"
        Me.Soluong40RF.ReadOnly = True
        '
        'Soluong40HC
        '
        Me.Soluong40HC.DataPropertyName = "Soluong40HC"
        Me.Soluong40HC.HeaderText = "40HC"
        Me.Soluong40HC.Name = "Soluong40HC"
        Me.Soluong40HC.ReadOnly = True
        '
        'Soluong45HC
        '
        Me.Soluong45HC.DataPropertyName = "Soluong45HC"
        Me.Soluong45HC.HeaderText = "45HC"
        Me.Soluong45HC.Name = "Soluong45HC"
        Me.Soluong45HC.ReadOnly = True
        '
        'Soluong40RH
        '
        Me.Soluong40RH.DataPropertyName = "Soluong40RH"
        Me.Soluong40RH.HeaderText = "40RH"
        Me.Soluong40RH.Name = "Soluong40RH"
        Me.Soluong40RH.ReadOnly = True
        '
        'OT20
        '
        Me.OT20.DataPropertyName = "Soluong20OT"
        Me.OT20.HeaderText = "20OT"
        Me.OT20.Name = "OT20"
        Me.OT20.ReadOnly = True
        '
        'OT40
        '
        Me.OT40.DataPropertyName = "Soluong40OT"
        Me.OT40.HeaderText = "40OT"
        Me.OT40.Name = "OT40"
        Me.OT40.ReadOnly = True
        '
        'FR20
        '
        Me.FR20.DataPropertyName = "Soluong20FR"
        Me.FR20.HeaderText = "20FR"
        Me.FR20.Name = "FR20"
        Me.FR20.ReadOnly = True
        '
        'FR40
        '
        Me.FR40.DataPropertyName = "Soluong40FR"
        Me.FR40.HeaderText = "40FR"
        Me.FR40.Name = "FR40"
        Me.FR40.ReadOnly = True
        '
        'userid
        '
        Me.userid.DataPropertyName = "UserID"
        Me.userid.HeaderText = "User Update"
        Me.userid.Name = "userid"
        Me.userid.ReadOnly = True
        '
        'Updatetime
        '
        Me.Updatetime.DataPropertyName = "Updatetime"
        Me.Updatetime.HeaderText = "Update time"
        Me.Updatetime.Name = "Updatetime"
        Me.Updatetime.ReadOnly = True
        '
        'frmBookingSupplyOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 379)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdfind)
        Me.Controls.Add(Me.txtbookingno)
        Me.Controls.Add(Me.dgdOrder)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmBookingSupplyOrder"
        Me.Text = "Booking Supply Order"
        CType(Me.dgdOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdOrder As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtbookingno As System.Windows.Forms.TextBox
    Friend WithEvents cmdfind As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BookingNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DaiDien As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMND As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents supplydepot As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Soluong40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OT20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OT40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FR40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Updatetime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
