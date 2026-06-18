<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOption
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOption))
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboFra = New System.Windows.Forms.ComboBox
        Me.cboBackG = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtOptionValue = New System.Windows.Forms.TextBox
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgdOption = New System.Windows.Forms.DataGridView
        Me.OptionID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.frmName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Department = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OptionCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OptionName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OptionValue = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog
        Me.FontDialog1 = New System.Windows.Forms.FontDialog
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdOption, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.cboFra)
        Me.fraUpdate.Controls.Add(Me.cboBackG)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.txtOptionValue)
        Me.fraUpdate.Controls.Add(Me.txtCode)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.txtName)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Location = New System.Drawing.Point(12, 281)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(710, 230)
        Me.fraUpdate.TabIndex = 5
        Me.fraUpdate.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(371, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "FraU. :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(203, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "BackG :"
        '
        'cboFra
        '
        Me.cboFra.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboFra.DropDownHeight = 1
        Me.cboFra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFra.FormattingEnabled = True
        Me.cboFra.IntegralHeight = False
        Me.cboFra.Location = New System.Drawing.Point(412, 18)
        Me.cboFra.Name = "cboFra"
        Me.cboFra.Size = New System.Drawing.Size(96, 21)
        Me.cboFra.TabIndex = 4
        '
        'cboBackG
        '
        Me.cboBackG.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cboBackG.DropDownHeight = 1
        Me.cboBackG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBackG.FormattingEnabled = True
        Me.cboBackG.IntegralHeight = False
        Me.cboBackG.Location = New System.Drawing.Point(251, 18)
        Me.cboBackG.Name = "cboBackG"
        Me.cboBackG.Size = New System.Drawing.Size(99, 21)
        Me.cboBackG.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(539, 16)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(620, 16)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Option Value :"
        '
        'txtOptionValue
        '
        Me.txtOptionValue.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtOptionValue.Location = New System.Drawing.Point(92, 71)
        Me.txtOptionValue.Multiline = True
        Me.txtOptionValue.Name = "txtOptionValue"
        Me.txtOptionValue.Size = New System.Drawing.Size(612, 153)
        Me.txtOptionValue.TabIndex = 1
        '
        'txtCode
        '
        Me.txtCode.Location = New System.Drawing.Point(92, 19)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(84, 20)
        Me.txtCode.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Option Code :"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(92, 45)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(612, 20)
        Me.txtName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Option name :"
        '
        'dgdOption
        '
        Me.dgdOption.AllowUserToAddRows = False
        Me.dgdOption.AllowUserToDeleteRows = False
        Me.dgdOption.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdOption.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.OptionID, Me.frmName, Me.Department, Me.OptionCode, Me.OptionName, Me.OptionValue, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdOption.Location = New System.Drawing.Point(12, 37)
        Me.dgdOption.Name = "dgdOption"
        Me.dgdOption.Size = New System.Drawing.Size(718, 238)
        Me.dgdOption.TabIndex = 3
        '
        'OptionID
        '
        Me.OptionID.DataPropertyName = "OptionID"
        Me.OptionID.HeaderText = "OptionID"
        Me.OptionID.Name = "OptionID"
        Me.OptionID.Visible = False
        '
        'frmName
        '
        Me.frmName.DataPropertyName = "frmname"
        Me.frmName.HeaderText = "Frm Name"
        Me.frmName.Name = "frmName"
        '
        'Department
        '
        Me.Department.DataPropertyName = "department"
        Me.Department.HeaderText = "Department"
        Me.Department.Name = "Department"
        '
        'OptionCode
        '
        Me.OptionCode.DataPropertyName = "Code"
        Me.OptionCode.HeaderText = "Option Code"
        Me.OptionCode.Name = "OptionCode"
        '
        'OptionName
        '
        Me.OptionName.DataPropertyName = "OptionName"
        Me.OptionName.HeaderText = "Option Nane"
        Me.OptionName.Name = "OptionName"
        '
        'OptionValue
        '
        Me.OptionValue.DataPropertyName = "OptionValue"
        Me.OptionValue.HeaderText = "Option Value"
        Me.OptionValue.Name = "OptionValue"
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
        Me.MenuStrip.Size = New System.Drawing.Size(732, 24)
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
        Me.smnuAdd.Visible = False
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
        Me.smnuDelete.Visible = False
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
        'frmOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 523)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdOption)
        Me.Controls.Add(Me.MenuStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOption"
        Me.Text = "Parameter Option"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdOption, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgdOption As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtOptionValue As System.Windows.Forms.TextBox
    Friend WithEvents OptionID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents frmName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Department As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OptionCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OptionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OptionValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboFra As System.Windows.Forms.ComboBox
    Friend WithEvents cboBackG As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
End Class
