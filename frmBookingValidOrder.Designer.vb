<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookingValidOrder
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
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtValidOrder = New System.Windows.Forms.TextBox
        Me.txtBookingNo = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dgdBookingValidOrder = New System.Windows.Forms.DataGridView
        Me.BookingValidOrderID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValidOrder = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ExportExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuApproveOrder = New System.Windows.Forms.ToolStripMenuItem
        Me.frApproveOrder = New System.Windows.Forms.GroupBox
        Me.cmdCancelApproveOrder = New System.Windows.Forms.Button
        Me.cmdOKApproveOrder = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtValidOrderAP = New System.Windows.Forms.TextBox
        Me.txtBookingNoAP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdBookingValidOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.frApproveOrder.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.txtValidOrder)
        Me.fraUpdate.Controls.Add(Me.txtBookingNo)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Location = New System.Drawing.Point(18, 240)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(315, 129)
        Me.fraUpdate.TabIndex = 5
        Me.fraUpdate.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(116, 75)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(197, 75)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Valid Order :"
        '
        'txtValidOrder
        '
        Me.txtValidOrder.Location = New System.Drawing.Point(93, 50)
        Me.txtValidOrder.Name = "txtValidOrder"
        Me.txtValidOrder.Size = New System.Drawing.Size(88, 20)
        Me.txtValidOrder.TabIndex = 1
        Me.txtValidOrder.Text = "0"
        Me.txtValidOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBookingNo
        '
        Me.txtBookingNo.Location = New System.Drawing.Point(93, 24)
        Me.txtBookingNo.Name = "txtBookingNo"
        Me.txtBookingNo.Size = New System.Drawing.Size(179, 20)
        Me.txtBookingNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Booking No. :"
        '
        'dgdBookingValidOrder
        '
        Me.dgdBookingValidOrder.AllowUserToAddRows = False
        Me.dgdBookingValidOrder.AllowUserToDeleteRows = False
        Me.dgdBookingValidOrder.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdBookingValidOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBookingValidOrder.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookingValidOrderID, Me.BookingNo, Me.ValidOrder, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdBookingValidOrder.Location = New System.Drawing.Point(9, 27)
        Me.dgdBookingValidOrder.Name = "dgdBookingValidOrder"
        Me.dgdBookingValidOrder.Size = New System.Drawing.Size(712, 205)
        Me.dgdBookingValidOrder.TabIndex = 3
        '
        'BookingValidOrderID
        '
        Me.BookingValidOrderID.DataPropertyName = "BookingValidOrderID"
        Me.BookingValidOrderID.HeaderText = "BookingValidOrderID"
        Me.BookingValidOrderID.Name = "BookingValidOrderID"
        Me.BookingValidOrderID.Visible = False
        '
        'BookingNo
        '
        Me.BookingNo.DataPropertyName = "BookingNo"
        Me.BookingNo.HeaderText = "Booking No."
        Me.BookingNo.Name = "BookingNo"
        '
        'ValidOrder
        '
        Me.ValidOrder.DataPropertyName = "ValidOrder"
        Me.ValidOrder.HeaderText = "Valid Order"
        Me.ValidOrder.Name = "ValidOrder"
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Continued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Continued.Visible = False
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Editable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Editable.Visible = False
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Approve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "userID"
        Me.UserID.Name = "UserID"
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.ExportExcelToolStripMenuItem, Me.mnuApproveOrder, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(733, 24)
        Me.MenuStrip.TabIndex = 4
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'smnuSearch
        '
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(54, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(43, 20)
        Me.smnuAdd.Text = "New"
        '
        'smnuEdit
        '
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(39, 20)
        Me.smnuEdit.Text = "Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(52, 20)
        Me.smnuDelete.Text = "Delete"
        '
        'ExportExcelToolStripMenuItem
        '
        Me.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem"
        Me.ExportExcelToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.ExportExcelToolStripMenuItem.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "Exit"
        '
        'mnuApproveOrder
        '
        Me.mnuApproveOrder.Name = "mnuApproveOrder"
        Me.mnuApproveOrder.Size = New System.Drawing.Size(97, 20)
        Me.mnuApproveOrder.Text = "Approve Order"
        '
        'frApproveOrder
        '
        Me.frApproveOrder.Controls.Add(Me.cmdCancelApproveOrder)
        Me.frApproveOrder.Controls.Add(Me.cmdOKApproveOrder)
        Me.frApproveOrder.Controls.Add(Me.Label1)
        Me.frApproveOrder.Controls.Add(Me.txtValidOrderAP)
        Me.frApproveOrder.Controls.Add(Me.txtBookingNoAP)
        Me.frApproveOrder.Controls.Add(Me.Label3)
        Me.frApproveOrder.Location = New System.Drawing.Point(281, 79)
        Me.frApproveOrder.Name = "frApproveOrder"
        Me.frApproveOrder.Size = New System.Drawing.Size(298, 109)
        Me.frApproveOrder.TabIndex = 6
        Me.frApproveOrder.TabStop = False
        Me.frApproveOrder.Text = "Approve order"
        Me.frApproveOrder.Visible = False
        '
        'cmdCancelApproveOrder
        '
        Me.cmdCancelApproveOrder.Location = New System.Drawing.Point(123, 70)
        Me.cmdCancelApproveOrder.Name = "cmdCancelApproveOrder"
        Me.cmdCancelApproveOrder.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancelApproveOrder.TabIndex = 7
        Me.cmdCancelApproveOrder.Text = "&Cancel"
        Me.cmdCancelApproveOrder.UseVisualStyleBackColor = True
        '
        'cmdOKApproveOrder
        '
        Me.cmdOKApproveOrder.Location = New System.Drawing.Point(204, 70)
        Me.cmdOKApproveOrder.Name = "cmdOKApproveOrder"
        Me.cmdOKApproveOrder.Size = New System.Drawing.Size(75, 23)
        Me.cmdOKApproveOrder.TabIndex = 8
        Me.cmdOKApproveOrder.Text = "&Ok"
        Me.cmdOKApproveOrder.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Valid Order :"
        '
        'txtValidOrderAP
        '
        Me.txtValidOrderAP.Location = New System.Drawing.Point(100, 45)
        Me.txtValidOrderAP.Name = "txtValidOrderAP"
        Me.txtValidOrderAP.Size = New System.Drawing.Size(88, 20)
        Me.txtValidOrderAP.TabIndex = 6
        Me.txtValidOrderAP.Text = "0"
        Me.txtValidOrderAP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBookingNoAP
        '
        Me.txtBookingNoAP.Location = New System.Drawing.Point(100, 19)
        Me.txtBookingNoAP.Name = "txtBookingNoAP"
        Me.txtBookingNoAP.Size = New System.Drawing.Size(179, 20)
        Me.txtBookingNoAP.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(27, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Booking No. :"
        '
        'frmBookingValidOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 380)
        Me.Controls.Add(Me.frApproveOrder)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdBookingValidOrder)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmBookingValidOrder"
        Me.Text = "Booking Valid Order"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdBookingValidOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.frApproveOrder.ResumeLayout(False)
        Me.frApproveOrder.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtValidOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgdBookingValidOrder As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBookingNo As System.Windows.Forms.TextBox
    Friend WithEvents BookingValidOrderID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValidOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mnuApproveOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents frApproveOrder As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelApproveOrder As System.Windows.Forms.Button
    Friend WithEvents cmdOKApproveOrder As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtValidOrderAP As System.Windows.Forms.TextBox
    Friend WithEvents txtBookingNoAP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
