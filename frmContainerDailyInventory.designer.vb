<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmContainerDailyInventory
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
        Me.dgdContainer = New System.Windows.Forms.DataGridView
        Me.BLIB_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NumberOfDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BeginDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverdueFull = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OverdueEmpty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.dtpChooseDate = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtOverdueFull = New System.Windows.Forms.TextBox
        Me.txtOverdueEmpty = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dgdContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdContainer
        '
        Me.dgdContainer.AllowUserToAddRows = False
        Me.dgdContainer.AllowUserToDeleteRows = False
        Me.dgdContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BLIB_NO, Me.Container_NO, Me.Container_Type, Me.ContainerStatus, Me.NumberOfDays, Me.BeginDate, Me.OverdueFull, Me.OverdueEmpty})
        Me.dgdContainer.Location = New System.Drawing.Point(12, 90)
        Me.dgdContainer.Name = "dgdContainer"
        Me.dgdContainer.ReadOnly = True
        Me.dgdContainer.RowHeadersWidth = 10
        Me.dgdContainer.Size = New System.Drawing.Size(542, 302)
        Me.dgdContainer.TabIndex = 0
        '
        'BLIB_NO
        '
        Me.BLIB_NO.DataPropertyName = "BLIB_NO"
        Me.BLIB_NO.HeaderText = "B/L No"
        Me.BLIB_NO.Name = "BLIB_NO"
        Me.BLIB_NO.ReadOnly = True
        '
        'Container_NO
        '
        Me.Container_NO.DataPropertyName = "Container_NO"
        Me.Container_NO.HeaderText = "Container No"
        Me.Container_NO.Name = "Container_NO"
        Me.Container_NO.ReadOnly = True
        '
        'Container_Type
        '
        Me.Container_Type.DataPropertyName = "Container_Type"
        Me.Container_Type.HeaderText = "Container Type "
        Me.Container_Type.Name = "Container_Type"
        Me.Container_Type.ReadOnly = True
        Me.Container_Type.Width = 50
        '
        'ContainerStatus
        '
        Me.ContainerStatus.DataPropertyName = "ContainerStatus"
        Me.ContainerStatus.HeaderText = "Container Status"
        Me.ContainerStatus.Name = "ContainerStatus"
        Me.ContainerStatus.ReadOnly = True
        Me.ContainerStatus.Width = 50
        '
        'NumberOfDays
        '
        Me.NumberOfDays.DataPropertyName = "NumberOfDays"
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.NumberOfDays.DefaultCellStyle = DataGridViewCellStyle1
        Me.NumberOfDays.HeaderText = "Number Of Day "
        Me.NumberOfDays.Name = "NumberOfDays"
        Me.NumberOfDays.ReadOnly = True
        Me.NumberOfDays.Width = 50
        '
        'BeginDate
        '
        Me.BeginDate.DataPropertyName = "maxdate"
        Me.BeginDate.HeaderText = "Date (Start)"
        Me.BeginDate.Name = "BeginDate"
        Me.BeginDate.ReadOnly = True
        '
        'OverdueFull
        '
        Me.OverdueFull.DataPropertyName = "OverdueFull"
        Me.OverdueFull.HeaderText = "Overdue Full"
        Me.OverdueFull.Name = "OverdueFull"
        Me.OverdueFull.ReadOnly = True
        Me.OverdueFull.Width = 50
        '
        'OverdueEmpty
        '
        Me.OverdueEmpty.DataPropertyName = "OverdueEmpty"
        Me.OverdueEmpty.HeaderText = "Overdue Empty"
        Me.OverdueEmpty.Name = "OverdueEmpty"
        Me.OverdueEmpty.ReadOnly = True
        Me.OverdueEmpty.Width = 50
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(566, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.ForeColor = System.Drawing.Color.Maroon
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.SearchToolStripMenuItem.Text = "Search"
        '
        'dtpChooseDate
        '
        Me.dtpChooseDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpChooseDate.Location = New System.Drawing.Point(98, 36)
        Me.dtpChooseDate.Name = "dtpChooseDate"
        Me.dtpChooseDate.Size = New System.Drawing.Size(92, 20)
        Me.dtpChooseDate.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(13, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Inventory Date :"
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(397, 63)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 4
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(479, 63)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Overdue Full >= :"
        '
        'txtOverdueFull
        '
        Me.txtOverdueFull.Location = New System.Drawing.Point(301, 37)
        Me.txtOverdueFull.Name = "txtOverdueFull"
        Me.txtOverdueFull.Size = New System.Drawing.Size(47, 20)
        Me.txtOverdueFull.TabIndex = 6
        Me.txtOverdueFull.Text = "30"
        '
        'txtOverdueEmpty
        '
        Me.txtOverdueEmpty.Location = New System.Drawing.Point(457, 37)
        Me.txtOverdueEmpty.Name = "txtOverdueEmpty"
        Me.txtOverdueEmpty.Size = New System.Drawing.Size(47, 20)
        Me.txtOverdueEmpty.TabIndex = 6
        Me.txtOverdueEmpty.Tag = ""
        Me.txtOverdueEmpty.Text = "30"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(354, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Overdue Empty >= :"
        '
        'frmContainerDailyInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 404)
        Me.Controls.Add(Me.txtOverdueEmpty)
        Me.Controls.Add(Me.txtOverdueFull)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpChooseDate)
        Me.Controls.Add(Me.dgdContainer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmContainerDailyInventory"
        Me.Text = "Number of day (Vietnam)"
        CType(Me.dgdContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdContainer As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents dtpChooseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BLIB_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NumberOfDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BeginDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverdueFull As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverdueEmpty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOverdueFull As System.Windows.Forms.TextBox
    Friend WithEvents txtOverdueEmpty As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
