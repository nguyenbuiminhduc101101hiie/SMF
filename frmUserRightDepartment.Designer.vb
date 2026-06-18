<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserRightDepartment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserRightDepartment))
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmdSaveService = New System.Windows.Forms.Button
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView
        Me.userrightdepartmentid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.usr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.department = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.URAccess = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.onlyAccount = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ValidityStart = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.validityend = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.editable = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.discontinued = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.userid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Updatetime = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(95, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(14, 12)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(75, 23)
        Me.cmdSaveService.TabIndex = 7
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.userrightdepartmentid, Me.usr, Me.department, Me.URAccess, Me.onlyAccount, Me.ValidityStart, Me.validityend, Me.remarks, Me.editable, Me.discontinued, Me.userid, Me.Updatetime})
        Me.dgdShippingLines.Location = New System.Drawing.Point(12, 47)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(605, 191)
        Me.dgdShippingLines.TabIndex = 6
        '
        'userrightdepartmentid
        '
        Me.userrightdepartmentid.DataPropertyName = "userrightdepartmentid"
        Me.userrightdepartmentid.HeaderText = "userrightdepartmentid"
        Me.userrightdepartmentid.Name = "userrightdepartmentid"
        Me.userrightdepartmentid.Visible = False
        '
        'usr
        '
        Me.usr.DataPropertyName = "usr"
        Me.usr.HeaderText = "Usr"
        Me.usr.Name = "usr"
        '
        'department
        '
        Me.department.DataPropertyName = "department"
        Me.department.HeaderText = "Department"
        Me.department.Name = "department"
        '
        'URAccess
        '
        Me.URAccess.DataPropertyName = "URAccess"
        Me.URAccess.HeaderText = "URAccess"
        Me.URAccess.Name = "URAccess"
        Me.URAccess.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.URAccess.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'onlyAccount
        '
        Me.onlyAccount.DataPropertyName = "onlyAccount"
        Me.onlyAccount.HeaderText = "Only Account"
        Me.onlyAccount.Name = "onlyAccount"
        Me.onlyAccount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.onlyAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ValidityStart
        '
        Me.ValidityStart.DataPropertyName = "ValidityStart"
        Me.ValidityStart.HeaderText = "Validity Start"
        Me.ValidityStart.Name = "ValidityStart"
        '
        'validityend
        '
        Me.validityend.DataPropertyName = "validityend"
        Me.validityend.HeaderText = "Validity End"
        Me.validityend.Name = "validityend"
        '
        'remarks
        '
        Me.remarks.DataPropertyName = "remarks"
        Me.remarks.HeaderText = "Remarks"
        Me.remarks.Name = "remarks"
        '
        'editable
        '
        Me.editable.DataPropertyName = "editable"
        Me.editable.HeaderText = "Editable"
        Me.editable.Name = "editable"
        '
        'discontinued
        '
        Me.discontinued.DataPropertyName = "discontinued"
        Me.discontinued.HeaderText = "Discontinued"
        Me.discontinued.Name = "discontinued"
        '
        'userid
        '
        Me.userid.DataPropertyName = "userid"
        Me.userid.HeaderText = "UserID"
        Me.userid.Name = "userid"
        '
        'Updatetime
        '
        Me.Updatetime.DataPropertyName = "Updatetime"
        Me.Updatetime.HeaderText = "Update time"
        Me.Updatetime.Name = "Updatetime"
        '
        'frmUserRightDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 250)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmUserRightDepartment"
        Me.Text = "User Right Department"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents userrightdepartmentid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents usr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents department As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents URAccess As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents onlyAccount As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ValidityStart As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents validityend As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents editable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents discontinued As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents userid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Updatetime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
