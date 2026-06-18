<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListLocalPic
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
    '<System.Diagnostics.DebuggerStepThrough()> _
    'Private Sub InitializeComponent()
    '    Me.MenuStrip = New System.Windows.Forms.MenuStrip
    '    Me.smnuSearch = New System.Windows.Forms.ToolStripMenuItem
    '    Me.smnuAdd = New System.Windows.Forms.ToolStripMenuItem
    '    Me.smnuEdit = New System.Windows.Forms.ToolStripMenuItem
    '    Me.smnuDelete = New System.Windows.Forms.ToolStripMenuItem
    '    Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
    '    Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
    '    Me.dgdPicLocal = New System.Windows.Forms.DataGridView
    '    Me.FraUpdate = New System.Windows.Forms.GroupBox
    '    Me.Label1 = New System.Windows.Forms.Label
    '    Me.TextBox1 = New System.Windows.Forms.TextBox
    '    Me.Button1 = New System.Windows.Forms.Button
    '    Me.CheckBox1 = New System.Windows.Forms.CheckBox
    '    Me.MenuStrip.SuspendLayout()
    '    CType(Me.dgdPicLocal, System.ComponentModel.ISupportInitialize).BeginInit()
    '    Me.FraUpdate.SuspendLayout()
    '    Me.SuspendLayout()
    '    '
    '    'MenuStrip
    '    '
    '    Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
    '    Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
    '    Me.MenuStrip.Name = "MenuStrip"
    '    Me.MenuStrip.Size = New System.Drawing.Size(849, 24)
    '    Me.MenuStrip.TabIndex = 8
    '    Me.MenuStrip.Text = "MenuStrip"
    '    '
    '    'smnuSearch
    '    '
    '    Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
    '    Me.smnuSearch.Name = "smnuSearch"
    '    Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
    '    Me.smnuSearch.Text = "Search"
    '    '
    '    'smnuAdd
    '    '
    '    Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
    '    Me.smnuAdd.Name = "smnuAdd"
    '    Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
    '    Me.smnuAdd.Text = "&Insert"
    '    '
    '    'smnuEdit
    '    '
    '    Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
    '    Me.smnuEdit.Name = "smnuEdit"
    '    Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
    '    Me.smnuEdit.Text = "&Edit"
    '    '
    '    'smnuDelete
    '    '
    '    Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
    '    Me.smnuDelete.Name = "smnuDelete"
    '    Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
    '    Me.smnuDelete.Text = "&Delete"
    '    '
    '    'smnuExportExcel
    '    '
    '    Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
    '    Me.smnuExportExcel.Name = "smnuExportExcel"
    '    Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
    '    Me.smnuExportExcel.Text = "Export Excel"
    '    '
    '    'smnuExit
    '    '
    '    Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
    '    Me.smnuExit.Name = "smnuExit"
    '    Me.smnuExit.Size = New System.Drawing.Size(37, 20)
    '    Me.smnuExit.Text = "E&xit"
    '    '
    '    'dgdPicLocal
    '    '
    '    Me.dgdPicLocal.AllowUserToAddRows = False
    '    Me.dgdPicLocal.AllowUserToDeleteRows = False
    '    Me.dgdPicLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    '    Me.dgdPicLocal.Location = New System.Drawing.Point(0, 27)
    '    Me.dgdPicLocal.Name = "dgdPicLocal"
    '    Me.dgdPicLocal.ReadOnly = True
    '    Me.dgdPicLocal.Size = New System.Drawing.Size(785, 317)
    '    Me.dgdPicLocal.TabIndex = 9
    '    '
    '    'FraUpdate
    '    '
    '    Me.FraUpdate.Controls.Add(Me.CheckBox1)
    '    Me.FraUpdate.Controls.Add(Me.Button1)
    '    Me.FraUpdate.Controls.Add(Me.TextBox1)
    '    Me.FraUpdate.Controls.Add(Me.Label1)
    '    Me.FraUpdate.Location = New System.Drawing.Point(0, 343)
    '    Me.FraUpdate.Name = "FraUpdate"
    '    Me.FraUpdate.Size = New System.Drawing.Size(692, 126)
    '    Me.FraUpdate.TabIndex = 10
    '    Me.FraUpdate.TabStop = False
    '    '
    '    'Label1
    '    '
    '    Me.Label1.AutoSize = True
    '    Me.Label1.Location = New System.Drawing.Point(3, 16)
    '    Me.Label1.Name = "Label1"
    '    Me.Label1.Size = New System.Drawing.Size(39, 13)
    '    Me.Label1.TabIndex = 0
    '    Me.Label1.Text = "Label1"
    '    '
    '    'TextBox1
    '    '
    '    Me.TextBox1.Location = New System.Drawing.Point(506, 47)
    '    Me.TextBox1.Name = "TextBox1"
    '    Me.TextBox1.Size = New System.Drawing.Size(100, 20)
    '    Me.TextBox1.TabIndex = 1
    '    '
    '    'Button1
    '    '
    '    Me.Button1.Location = New System.Drawing.Point(355, 78)
    '    Me.Button1.Name = "Button1"
    '    Me.Button1.Size = New System.Drawing.Size(75, 23)
    '    Me.Button1.TabIndex = 2
    '    Me.Button1.Text = "Button1"
    '    Me.Button1.UseVisualStyleBackColor = True
    '    '
    '    'CheckBox1
    '    '
    '    Me.CheckBox1.AutoSize = True
    '    Me.CheckBox1.Location = New System.Drawing.Point(349, 27)
    '    Me.CheckBox1.Name = "CheckBox1"
    '    Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
    '    Me.CheckBox1.TabIndex = 3
    '    Me.CheckBox1.Text = "CheckBox1"
    '    Me.CheckBox1.UseVisualStyleBackColor = True
    '    '
    '    'frmListLocalPic
    '    '
    '    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    '    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    '    Me.ClientSize = New System.Drawing.Size(849, 472)
    '    Me.Controls.Add(Me.FraUpdate)
    '    Me.Controls.Add(Me.dgdPicLocal)
    '    Me.Controls.Add(Me.MenuStrip)
    '    Me.Name = "frmListLocalPic"
    '    Me.Text = "Local PIC"
    '    Me.MenuStrip.ResumeLayout(False)
    '    Me.MenuStrip.PerformLayout()
    '    CType(Me.dgdPicLocal, System.ComponentModel.ISupportInitialize).EndInit()
    '    Me.FraUpdate.ResumeLayout(False)
    '    Me.FraUpdate.PerformLayout()
    '    Me.ResumeLayout(False)
    '    Me.PerformLayout()

    'End Sub
    'Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    'Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents dgdPicLocal As System.Windows.Forms.DataGridView
    'Friend WithEvents FraUpdate As System.Windows.Forms.GroupBox
    'Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    'Friend WithEvents Button1 As System.Windows.Forms.Button
    'Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    'Friend WithEvents Label1 As System.Windows.Forms.Label


    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents txtLocalNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMobile As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDepartMent As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPicName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkSchedule As System.Windows.Forms.CheckBox
    Friend WithEvents chkWebSite As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dgdPicLocal As System.Windows.Forms.DataGridView
    Friend WithEvents PicLocalID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PicName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DePartMent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Mobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LocalNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Schedule As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents WebSite As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem





    Private Sub InitializeComponent()
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.txtLocalNumber = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmail = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMobile = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtDepartMent = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtPicName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkSchedule = New System.Windows.Forms.CheckBox
        Me.chkWebSite = New System.Windows.Forms.CheckBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dgdPicLocal = New System.Windows.Forms.DataGridView
        Me.PicLocalID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PicName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DePartMent = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Mobile = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Email = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LocalNumber = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Schedule = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.WebSite = New System.Windows.Forms.DataGridViewCheckBoxColumn
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
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.fraUpdate.SuspendLayout()
        CType(Me.dgdPicLocal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.txtLocalNumber)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.txtEmail)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.txtMobile)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.txtDepartMent)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.txtPicName)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.chkSchedule)
        Me.fraUpdate.Controls.Add(Me.chkWebSite)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.ForeColor = System.Drawing.Color.Maroon
        Me.fraUpdate.Location = New System.Drawing.Point(12, 372)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(795, 134)
        Me.fraUpdate.TabIndex = 13
        Me.fraUpdate.TabStop = False
        '
        'txtLocalNumber
        '
        Me.txtLocalNumber.Location = New System.Drawing.Point(380, 45)
        Me.txtLocalNumber.Name = "txtLocalNumber"
        Me.txtLocalNumber.Size = New System.Drawing.Size(210, 20)
        Me.txtLocalNumber.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(299, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Loacl Number :"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(380, 19)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(210, 20)
        Me.txtEmail.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(340, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Email :"
        '
        'txtMobile
        '
        Me.txtMobile.Location = New System.Drawing.Point(82, 69)
        Me.txtMobile.Name = "txtMobile"
        Me.txtMobile.Size = New System.Drawing.Size(210, 20)
        Me.txtMobile.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(36, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Mobile :"
        '
        'txtDepartMent
        '
        Me.txtDepartMent.Location = New System.Drawing.Point(82, 43)
        Me.txtDepartMent.Name = "txtDepartMent"
        Me.txtDepartMent.Size = New System.Drawing.Size(210, 20)
        Me.txtDepartMent.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(11, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "DepartMent :"
        '
        'txtPicName
        '
        Me.txtPicName.Location = New System.Drawing.Point(81, 17)
        Me.txtPicName.Name = "txtPicName"
        Me.txtPicName.Size = New System.Drawing.Size(210, 20)
        Me.txtPicName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(25, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "PicName :"
        '
        'chkSchedule
        '
        Me.chkSchedule.AutoSize = True
        Me.chkSchedule.Location = New System.Drawing.Point(519, 71)
        Me.chkSchedule.Name = "chkSchedule"
        Me.chkSchedule.Size = New System.Drawing.Size(71, 17)
        Me.chkSchedule.TabIndex = 6
        Me.chkSchedule.Text = "Schedule"
        Me.chkSchedule.UseVisualStyleBackColor = True
        '
        'chkWebSite
        '
        Me.chkWebSite.AutoSize = True
        Me.chkWebSite.Location = New System.Drawing.Point(380, 71)
        Me.chkWebSite.Name = "chkWebSite"
        Me.chkWebSite.Size = New System.Drawing.Size(70, 17)
        Me.chkWebSite.TabIndex = 5
        Me.chkWebSite.Text = "WebSite "
        Me.chkWebSite.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(434, 94)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 22)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(515, 94)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 22)
        Me.cmdOk.TabIndex = 7
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'dgdPicLocal
        '
        Me.dgdPicLocal.AllowUserToAddRows = False
        Me.dgdPicLocal.AllowUserToDeleteRows = False
        Me.dgdPicLocal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPicLocal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PicLocalID, Me.PicName, Me.DePartMent, Me.Mobile, Me.Email, Me.LocalNumber, Me.Schedule, Me.WebSite, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdPicLocal.Location = New System.Drawing.Point(12, 27)
        Me.dgdPicLocal.Name = "dgdPicLocal"
        Me.dgdPicLocal.ReadOnly = True
        Me.dgdPicLocal.Size = New System.Drawing.Size(785, 339)
        Me.dgdPicLocal.TabIndex = 12
        '
        'PicLocalID
        '
        Me.PicLocalID.DataPropertyName = "PicLocalID"
        Me.PicLocalID.HeaderText = "PicLocalID"
        Me.PicLocalID.Name = "PicLocalID"
        Me.PicLocalID.ReadOnly = True
        Me.PicLocalID.Visible = False
        '
        'PicName
        '
        Me.PicName.DataPropertyName = "PicName"
        Me.PicName.HeaderText = "PicName"
        Me.PicName.Name = "PicName"
        Me.PicName.ReadOnly = True
        '
        'DePartMent
        '
        Me.DePartMent.DataPropertyName = "DePartMent"
        Me.DePartMent.HeaderText = "DePartMent"
        Me.DePartMent.Name = "DePartMent"
        Me.DePartMent.ReadOnly = True
        '
        'Mobile
        '
        Me.Mobile.DataPropertyName = "Mobile"
        Me.Mobile.HeaderText = "Mobile"
        Me.Mobile.Name = "Mobile"
        Me.Mobile.ReadOnly = True
        '
        'Email
        '
        Me.Email.DataPropertyName = "Email"
        Me.Email.HeaderText = "Email"
        Me.Email.Name = "Email"
        Me.Email.ReadOnly = True
        '
        'LocalNumber
        '
        Me.LocalNumber.DataPropertyName = "LocalNumber"
        Me.LocalNumber.HeaderText = "LocalNumber"
        Me.LocalNumber.Name = "LocalNumber"
        Me.LocalNumber.ReadOnly = True
        '
        'Schedule
        '
        Me.Schedule.DataPropertyName = "Schedule"
        Me.Schedule.HeaderText = "Schedule"
        Me.Schedule.Name = "Schedule"
        Me.Schedule.ReadOnly = True
        '
        'WebSite
        '
        Me.WebSite.DataPropertyName = "WebSite"
        Me.WebSite.HeaderText = "WebSite"
        Me.WebSite.Name = "WebSite"
        Me.WebSite.ReadOnly = True
        '
        'Continued
        '
        Me.Continued.DataPropertyName = "Continued"
        Me.Continued.HeaderText = "Continued"
        Me.Continued.Name = "Continued"
        Me.Continued.ReadOnly = True
        Me.Continued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Continued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Continued.Visible = False
        '
        'Editable
        '
        Me.Editable.DataPropertyName = "Editable"
        Me.Editable.HeaderText = "Editable"
        Me.Editable.Name = "Editable"
        Me.Editable.ReadOnly = True
        Me.Editable.Visible = False
        '
        'Approve
        '
        Me.Approve.DataPropertyName = "Approve"
        Me.Approve.HeaderText = "Approve"
        Me.Approve.Name = "Approve"
        Me.Approve.ReadOnly = True
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        Me.UserID.ReadOnly = True
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        Me.UpdateTime.ReadOnly = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuSearch, Me.smnuAdd, Me.smnuEdit, Me.smnuDelete, Me.smnuExportExcel, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(809, 24)
        Me.MenuStrip.TabIndex = 11
        Me.MenuStrip.Text = "MenuStrip"
        '
        'smnuSearch
        '
        Me.smnuSearch.ForeColor = System.Drawing.Color.Maroon
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.ForeColor = System.Drawing.Color.Maroon
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(48, 20)
        Me.smnuAdd.Text = "&Insert"
        '
        'smnuEdit
        '
        Me.smnuEdit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "&Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.ForeColor = System.Drawing.Color.Maroon
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "&Delete"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'smnuExit
        '
        Me.smnuExit.ForeColor = System.Drawing.Color.Maroon
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "E&xit"
        '
        'frmListLocalPic
        '
        Me.ClientSize = New System.Drawing.Size(809, 516)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.dgdPicLocal)
        Me.Controls.Add(Me.MenuStrip)
        Me.Name = "frmListLocalPic"
        Me.Text = "PIC (Local)"
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        CType(Me.dgdPicLocal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
