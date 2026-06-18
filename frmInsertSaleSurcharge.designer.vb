<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsertSaleSurcharge
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
        Me.components = New System.ComponentModel.Container
        Me.dgdUpdateSurtCharge = New System.Windows.Forms.DataGridView
        Me.PortSelect = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.POD_Code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Port_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.CheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UnCheckToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.chkNoneExpireDate = New System.Windows.Forms.CheckBox
        Me.dtpExpireDate = New System.Windows.Forms.DateTimePicker
        Me.dtpApplyDate = New System.Windows.Forms.DateTimePicker
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMoney = New System.Windows.Forms.TextBox
        Me.cboCurrency = New System.Windows.Forms.ComboBox
        Me.cboItems = New System.Windows.Forms.ComboBox
        Me.cboContainerType = New System.Windows.Forms.ComboBox
        Me.cboPrepaidCollect = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOK = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbomarket = New System.Windows.Forms.ComboBox
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.txtSearch = New System.Windows.Forms.TextBox
        Me.cmdNewSearch = New System.Windows.Forms.Button
        Me.cboShippingLine = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.cboSalename = New System.Windows.Forms.ComboBox
        CType(Me.dgdUpdateSurtCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdUpdateSurtCharge
        '
        Me.dgdUpdateSurtCharge.AllowUserToAddRows = False
        Me.dgdUpdateSurtCharge.AllowUserToDeleteRows = False
        Me.dgdUpdateSurtCharge.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgdUpdateSurtCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdUpdateSurtCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PortSelect, Me.POD_Code, Me.POD, Me.Port_ID})
        Me.dgdUpdateSurtCharge.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdUpdateSurtCharge.Location = New System.Drawing.Point(338, 39)
        Me.dgdUpdateSurtCharge.Name = "dgdUpdateSurtCharge"
        Me.dgdUpdateSurtCharge.Size = New System.Drawing.Size(365, 333)
        Me.dgdUpdateSurtCharge.TabIndex = 0
        '
        'PortSelect
        '
        Me.PortSelect.DataPropertyName = "PortSelect"
        Me.PortSelect.HeaderText = "Select"
        Me.PortSelect.Name = "PortSelect"
        Me.PortSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PortSelect.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'POD_Code
        '
        Me.POD_Code.DataPropertyName = "POD_Code"
        Me.POD_Code.HeaderText = "POD_Code"
        Me.POD_Code.Name = "POD_Code"
        '
        'POD
        '
        Me.POD.DataPropertyName = "POD"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        '
        'Port_ID
        '
        Me.Port_ID.DataPropertyName = "Port_ID"
        Me.Port_ID.HeaderText = "Port_ID"
        Me.Port_ID.Name = "Port_ID"
        Me.Port_ID.Visible = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CheckToolStripMenuItem, Me.UnCheckToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(123, 48)
        '
        'CheckToolStripMenuItem
        '
        Me.CheckToolStripMenuItem.Name = "CheckToolStripMenuItem"
        Me.CheckToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.CheckToolStripMenuItem.Text = "Check "
        '
        'UnCheckToolStripMenuItem
        '
        Me.UnCheckToolStripMenuItem.Name = "UnCheckToolStripMenuItem"
        Me.UnCheckToolStripMenuItem.Size = New System.Drawing.Size(122, 22)
        Me.UnCheckToolStripMenuItem.Text = "UnCheck"
        '
        'fraUpdate
        '
        Me.fraUpdate.Controls.Add(Me.cboSalename)
        Me.fraUpdate.Controls.Add(Me.cboShippingLine)
        Me.fraUpdate.Controls.Add(Me.chkNoneExpireDate)
        Me.fraUpdate.Controls.Add(Me.dtpExpireDate)
        Me.fraUpdate.Controls.Add(Me.dtpApplyDate)
        Me.fraUpdate.Controls.Add(Me.cboPOL)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.txtMoney)
        Me.fraUpdate.Controls.Add(Me.cboCurrency)
        Me.fraUpdate.Controls.Add(Me.cboItems)
        Me.fraUpdate.Controls.Add(Me.cboContainerType)
        Me.fraUpdate.Controls.Add(Me.cboPrepaidCollect)
        Me.fraUpdate.Controls.Add(Me.Label5)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.Label4)
        Me.fraUpdate.Controls.Add(Me.Label8)
        Me.fraUpdate.Controls.Add(Me.Label11)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Controls.Add(Me.Label10)
        Me.fraUpdate.Controls.Add(Me.Label3)
        Me.fraUpdate.Controls.Add(Me.Label7)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOK)
        Me.fraUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fraUpdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.fraUpdate.Location = New System.Drawing.Point(12, 39)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(320, 331)
        Me.fraUpdate.TabIndex = 2
        Me.fraUpdate.TabStop = False
        Me.fraUpdate.Text = "Update"
        '
        'chkNoneExpireDate
        '
        Me.chkNoneExpireDate.AutoSize = True
        Me.chkNoneExpireDate.Location = New System.Drawing.Point(260, 174)
        Me.chkNoneExpireDate.Name = "chkNoneExpireDate"
        Me.chkNoneExpireDate.Size = New System.Drawing.Size(56, 19)
        Me.chkNoneExpireDate.TabIndex = 11
        Me.chkNoneExpireDate.Text = "None"
        Me.chkNoneExpireDate.UseVisualStyleBackColor = True
        '
        'dtpExpireDate
        '
        Me.dtpExpireDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpExpireDate.Location = New System.Drawing.Point(156, 172)
        Me.dtpExpireDate.Name = "dtpExpireDate"
        Me.dtpExpireDate.Size = New System.Drawing.Size(98, 21)
        Me.dtpExpireDate.TabIndex = 10
        '
        'dtpApplyDate
        '
        Me.dtpApplyDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpApplyDate.Location = New System.Drawing.Point(156, 126)
        Me.dtpApplyDate.Name = "dtpApplyDate"
        Me.dtpApplyDate.Size = New System.Drawing.Size(98, 21)
        Me.dtpApplyDate.TabIndex = 8
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(12, 34)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(136, 23)
        Me.cboPOL.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Items :"
        '
        'txtMoney
        '
        Me.txtMoney.Location = New System.Drawing.Point(156, 79)
        Me.txtMoney.Name = "txtMoney"
        Me.txtMoney.Size = New System.Drawing.Size(98, 21)
        Me.txtMoney.TabIndex = 6
        '
        'cboCurrency
        '
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.FormattingEnabled = True
        Me.cboCurrency.Location = New System.Drawing.Point(156, 34)
        Me.cboCurrency.Name = "cboCurrency"
        Me.cboCurrency.Size = New System.Drawing.Size(98, 23)
        Me.cboCurrency.TabIndex = 4
        '
        'cboItems
        '
        Me.cboItems.FormattingEnabled = True
        Me.cboItems.Location = New System.Drawing.Point(13, 124)
        Me.cboItems.Name = "cboItems"
        Me.cboItems.Size = New System.Drawing.Size(136, 23)
        Me.cboItems.TabIndex = 7
        '
        'cboContainerType
        '
        Me.cboContainerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContainerType.FormattingEnabled = True
        Me.cboContainerType.Items.AddRange(New Object() {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH", "20OT", "40OT", "20FR", "40FR"})
        Me.cboContainerType.Location = New System.Drawing.Point(13, 170)
        Me.cboContainerType.Name = "cboContainerType"
        Me.cboContainerType.Size = New System.Drawing.Size(135, 23)
        Me.cboContainerType.TabIndex = 9
        Me.cboContainerType.TabStop = False
        '
        'cboPrepaidCollect
        '
        Me.cboPrepaidCollect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrepaidCollect.FormattingEnabled = True
        Me.cboPrepaidCollect.Items.AddRange(New Object() {"", "Prepaid", "Collect"})
        Me.cboPrepaidCollect.Location = New System.Drawing.Point(13, 77)
        Me.cboPrepaidCollect.Name = "cboPrepaidCollect"
        Me.cboPrepaidCollect.Size = New System.Drawing.Size(136, 23)
        Me.cboPrepaidCollect.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(153, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 15)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Price :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(153, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Currency :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 15)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "PrePaid Or Collect :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(153, 154)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Expire Date :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(153, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Apply Date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 152)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 15)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Container Type :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 15)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "POL :"
        '
        'cmdCancel
        '
        Me.cmdCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdCancel.Location = New System.Drawing.Point(220, 304)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(77, 21)
        Me.cmdCancel.TabIndex = 13
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cmdOK.Location = New System.Drawing.Point(136, 304)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(77, 21)
        Me.cmdOK.TabIndex = 12
        Me.cmdOK.Text = "&OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(28, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(46, 13)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Market :"
        '
        'cbomarket
        '
        Me.cbomarket.FormattingEnabled = True
        Me.cbomarket.Location = New System.Drawing.Point(76, 12)
        Me.cbomarket.Name = "cbomarket"
        Me.cbomarket.Size = New System.Drawing.Size(152, 21)
        Me.cbomarket.TabIndex = 1
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(634, 10)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(69, 25)
        Me.cmdSearch.TabIndex = 16
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(420, 12)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(210, 20)
        Me.txtSearch.TabIndex = 15
        '
        'cmdNewSearch
        '
        Me.cmdNewSearch.Location = New System.Drawing.Point(338, 10)
        Me.cmdNewSearch.Name = "cmdNewSearch"
        Me.cmdNewSearch.Size = New System.Drawing.Size(76, 25)
        Me.cmdNewSearch.TabIndex = 14
        Me.cmdNewSearch.Text = "New Search "
        Me.cmdNewSearch.UseVisualStyleBackColor = True
        '
        'cboShippingLine
        '
        Me.cboShippingLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboShippingLine.FormattingEnabled = True
        Me.cboShippingLine.Location = New System.Drawing.Point(12, 220)
        Me.cboShippingLine.Name = "cboShippingLine"
        Me.cboShippingLine.Size = New System.Drawing.Size(242, 23)
        Me.cboShippingLine.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 202)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Shipping Lines :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 248)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 15)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Sale Name :"
        '
        'cboSalename
        '
        Me.cboSalename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSalename.FormattingEnabled = True
        Me.cboSalename.Location = New System.Drawing.Point(12, 266)
        Me.cboSalename.Name = "cboSalename"
        Me.cboSalename.Size = New System.Drawing.Size(242, 23)
        Me.cboSalename.TabIndex = 15
        '
        'frmInsertSaleSurcharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 382)
        Me.Controls.Add(Me.fraUpdate)
        Me.Controls.Add(Me.cmdNewSearch)
        Me.Controls.Add(Me.cmdSearch)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cbomarket)
        Me.Controls.Add(Me.dgdUpdateSurtCharge)
        Me.Controls.Add(Me.txtSearch)
        Me.Name = "frmInsertSaleSurcharge"
        Me.Text = "Update Surcharge"
        CType(Me.dgdUpdateSurtCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdUpdateSurtCharge As System.Windows.Forms.DataGridView
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents txtMoney As System.Windows.Forms.TextBox
    Friend WithEvents cboCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents cboContainerType As System.Windows.Forms.ComboBox
    Friend WithEvents cboItems As System.Windows.Forms.ComboBox
    Friend WithEvents cboPrepaidCollect As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents PortSelect As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpExpireDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpApplyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents CheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UnCheckToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cbomarket As System.Windows.Forms.ComboBox
    Friend WithEvents POD_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkNoneExpireDate As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents cmdNewSearch As System.Windows.Forms.Button
    Friend WithEvents cboShippingLine As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboSalename As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
