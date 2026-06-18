<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTerminal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTerminal))
        Me.dgdterminal = New System.Windows.Forms.DataGridView()
        Me.TerminalID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.terminalCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TerminalName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capacity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FreeStorage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ValidOrder = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Continued = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.fraUpdate = New System.Windows.Forms.GroupBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOk = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtValidOrder = New System.Windows.Forms.TextBox()
        Me.txtFreeStorage = New System.Windows.Forms.TextBox()
        Me.txtCapacity = New System.Windows.Forms.TextBox()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgdterminal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdterminal
        '
        Me.dgdterminal.AllowUserToAddRows = False
        Me.dgdterminal.AllowUserToDeleteRows = False
        Me.dgdterminal.BackgroundColor = System.Drawing.Color.PaleTurquoise
        Me.dgdterminal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdterminal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TerminalID, Me.terminalCode, Me.TerminalName, Me.Capacity, Me.FreeStorage, Me.ValidOrder, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdterminal.Location = New System.Drawing.Point(3, 37)
        Me.dgdterminal.Name = "dgdterminal"
        Me.dgdterminal.Size = New System.Drawing.Size(718, 150)
        Me.dgdterminal.TabIndex = 0
        '
        'TerminalID
        '
        Me.TerminalID.DataPropertyName = "TerminalID"
        Me.TerminalID.HeaderText = "TerminalID"
        Me.TerminalID.Name = "TerminalID"
        Me.TerminalID.Visible = False
        '
        'terminalCode
        '
        Me.terminalCode.DataPropertyName = "Code"
        Me.terminalCode.HeaderText = " Terminal Code"
        Me.terminalCode.Name = "terminalCode"
        '
        'TerminalName
        '
        Me.TerminalName.DataPropertyName = "TerminalName"
        Me.TerminalName.HeaderText = "Terminal Nane"
        Me.TerminalName.Name = "TerminalName"
        '
        'Capacity
        '
        Me.Capacity.DataPropertyName = "Capacity"
        Me.Capacity.HeaderText = "Capacity"
        Me.Capacity.Name = "Capacity"
        '
        'FreeStorage
        '
        Me.FreeStorage.DataPropertyName = "FreeStorage"
        Me.FreeStorage.HeaderText = "Free storage"
        Me.FreeStorage.Name = "FreeStorage"
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
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.ExportExcelToolStripMenuItem, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(725, 24)
        Me.MenuStrip.TabIndex = 1
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
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.txtValidOrder)
        Me.fraUpdate.Controls.Add(Me.txtFreeStorage)
        Me.fraUpdate.Controls.Add(Me.txtCapacity)
        Me.fraUpdate.Controls.Add(Me.txtCode)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.txtName)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Location = New System.Drawing.Point(12, 230)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(701, 193)
        Me.fraUpdate.TabIndex = 0
        Me.fraUpdate.TabStop = False
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(252, 107)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(333, 107)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label5.Location = New System.Drawing.Point(36, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Valid Order :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(214, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Free Storage :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(47, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Capacity :"
        '
        'txtValidOrder
        '
        Me.txtValidOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValidOrder.Location = New System.Drawing.Point(103, 105)
        Me.txtValidOrder.Name = "txtValidOrder"
        Me.txtValidOrder.Size = New System.Drawing.Size(88, 22)
        Me.txtValidOrder.TabIndex = 5
        Me.txtValidOrder.Text = "0"
        Me.txtValidOrder.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFreeStorage
        '
        Me.txtFreeStorage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreeStorage.Location = New System.Drawing.Point(291, 79)
        Me.txtFreeStorage.Name = "txtFreeStorage"
        Me.txtFreeStorage.Size = New System.Drawing.Size(117, 22)
        Me.txtFreeStorage.TabIndex = 4
        Me.txtFreeStorage.Text = "0"
        Me.txtFreeStorage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCapacity
        '
        Me.txtCapacity.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacity.Location = New System.Drawing.Point(103, 79)
        Me.txtCapacity.Name = "txtCapacity"
        Me.txtCapacity.Size = New System.Drawing.Size(88, 22)
        Me.txtCapacity.TabIndex = 3
        Me.txtCapacity.Text = "0"
        Me.txtCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(103, 23)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(305, 22)
        Me.txtCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(20, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Terminal Code :"
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtName.Location = New System.Drawing.Point(103, 52)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(305, 22)
        Me.txtName.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label1.Location = New System.Drawing.Point(19, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Terminal name :"
        '
        'frmTerminal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 468)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdterminal)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmTerminal"
        Me.Text = "Terminal"
        CType(Me.dgdterminal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdterminal As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFreeStorage As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacity As System.Windows.Forms.TextBox
    Friend WithEvents TerminalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents terminalCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TerminalName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capacity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreeStorage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValidOrder As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtValidOrder As System.Windows.Forms.TextBox
End Class
