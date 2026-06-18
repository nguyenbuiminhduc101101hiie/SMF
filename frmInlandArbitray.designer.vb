<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInlandArbitray
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
        Me.dgdInlandArbitray = New System.Windows.Forms.DataGridView
        Me.InlandArbitrayID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Market_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MarketCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Market = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RelayPort = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
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
        Me.fraUpdate = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPrice40RH = New System.Windows.Forms.TextBox
        Me.txtPrice40RF = New System.Windows.Forms.TextBox
        Me.txtPrice20RF = New System.Windows.Forms.TextBox
        Me.txtPrice45HC = New System.Windows.Forms.TextBox
        Me.txtPrice40HC = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtPrice40GP = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtPrice20GP = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboPOD = New System.Windows.Forms.ComboBox
        Me.cboPOL = New System.Windows.Forms.ComboBox
        Me.cboMarket = New System.Windows.Forms.ComboBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtRelayPort = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.dgdInlandArbitray, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.fraUpdate.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdInlandArbitray
        '
        Me.dgdInlandArbitray.AllowUserToAddRows = False
        Me.dgdInlandArbitray.AllowUserToDeleteRows = False
        Me.dgdInlandArbitray.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdInlandArbitray.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.InlandArbitrayID, Me.Market_ID, Me.POL_ID, Me.POD_ID, Me.MarketCode, Me.Market, Me.POL, Me.POD, Me.RelayPort, Me.Price20GP, Me.Price40GP, Me.Price40HC, Me.Price45HC, Me.Price20RF, Me.Price40RF, Me.Price40RH, Me.Continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdInlandArbitray.Location = New System.Drawing.Point(0, 27)
        Me.dgdInlandArbitray.Name = "dgdInlandArbitray"
        Me.dgdInlandArbitray.Size = New System.Drawing.Size(718, 187)
        Me.dgdInlandArbitray.TabIndex = 3
        '
        'InlandArbitrayID
        '
        Me.InlandArbitrayID.DataPropertyName = "InlandArbitrayID"
        Me.InlandArbitrayID.HeaderText = "InlandArbitrayID"
        Me.InlandArbitrayID.Name = "InlandArbitrayID"
        Me.InlandArbitrayID.Visible = False
        '
        'Market_ID
        '
        Me.Market_ID.DataPropertyName = "Market_ID"
        Me.Market_ID.HeaderText = "Market_ID"
        Me.Market_ID.Name = "Market_ID"
        Me.Market_ID.Visible = False
        '
        'POL_ID
        '
        Me.POL_ID.DataPropertyName = "POL_ID"
        Me.POL_ID.HeaderText = "POL_ID"
        Me.POL_ID.Name = "POL_ID"
        Me.POL_ID.Visible = False
        '
        'POD_ID
        '
        Me.POD_ID.DataPropertyName = "POD_ID"
        Me.POD_ID.HeaderText = "POD_ID"
        Me.POD_ID.Name = "POD_ID"
        Me.POD_ID.Visible = False
        '
        'MarketCode
        '
        Me.MarketCode.DataPropertyName = "MarketCode"
        Me.MarketCode.HeaderText = "Market Code"
        Me.MarketCode.Name = "MarketCode"
        '
        'Market
        '
        Me.Market.DataPropertyName = "Market"
        Me.Market.HeaderText = "Market"
        Me.Market.Name = "Market"
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        '
        'POD
        '
        Me.POD.DataPropertyName = "POD"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        '
        'RelayPort
        '
        Me.RelayPort.DataPropertyName = "RelayPort"
        Me.RelayPort.HeaderText = "Relay Port"
        Me.RelayPort.Name = "RelayPort"
        '
        'Price20GP
        '
        Me.Price20GP.DataPropertyName = "Price20GP"
        Me.Price20GP.HeaderText = "20GP"
        Me.Price20GP.Name = "Price20GP"
        '
        'Price40GP
        '
        Me.Price40GP.DataPropertyName = "Price40GP"
        Me.Price40GP.HeaderText = "40GP"
        Me.Price40GP.Name = "Price40GP"
        '
        'Price40HC
        '
        Me.Price40HC.DataPropertyName = "Price40HC"
        Me.Price40HC.HeaderText = "40HC"
        Me.Price40HC.Name = "Price40HC"
        '
        'Price45HC
        '
        Me.Price45HC.DataPropertyName = "Price45HC"
        Me.Price45HC.HeaderText = "45HC"
        Me.Price45HC.Name = "Price45HC"
        '
        'Price20RF
        '
        Me.Price20RF.DataPropertyName = "Price20RF"
        Me.Price20RF.HeaderText = "20RF"
        Me.Price20RF.Name = "Price20RF"
        '
        'Price40RF
        '
        Me.Price40RF.DataPropertyName = "Price40RF"
        Me.Price40RF.HeaderText = "40RF"
        Me.Price40RF.Name = "Price40RF"
        '
        'Price40RH
        '
        Me.Price40RH.DataPropertyName = "Price40RH"
        Me.Price40RH.HeaderText = "40RH"
        Me.Price40RH.Name = "Price40RH"
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
        Me.MenuStrip.Size = New System.Drawing.Size(751, 24)
        Me.MenuStrip.TabIndex = 4
        Me.MenuStrip.Text = "MenuStrip1"
        '
        'smnuSearch
        '
        Me.smnuSearch.Name = "smnuSearch"
        Me.smnuSearch.Size = New System.Drawing.Size(52, 20)
        Me.smnuSearch.Text = "Search"
        '
        'smnuAdd
        '
        Me.smnuAdd.Name = "smnuAdd"
        Me.smnuAdd.Size = New System.Drawing.Size(40, 20)
        Me.smnuAdd.Text = "New"
        '
        'smnuEdit
        '
        Me.smnuEdit.Name = "smnuEdit"
        Me.smnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.smnuEdit.Text = "Edit"
        '
        'smnuDelete
        '
        Me.smnuDelete.Name = "smnuDelete"
        Me.smnuDelete.Size = New System.Drawing.Size(50, 20)
        Me.smnuDelete.Text = "Delete"
        '
        'ExportExcelToolStripMenuItem
        '
        Me.ExportExcelToolStripMenuItem.Name = "ExportExcelToolStripMenuItem"
        Me.ExportExcelToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
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
        Me.fraUpdate.Controls.Add(Me.GroupBox1)
        Me.fraUpdate.Controls.Add(Me.cboPOD)
        Me.fraUpdate.Controls.Add(Me.cboPOL)
        Me.fraUpdate.Controls.Add(Me.cboMarket)
        Me.fraUpdate.Controls.Add(Me.cmdCancel)
        Me.fraUpdate.Controls.Add(Me.cmdOk)
        Me.fraUpdate.Controls.Add(Me.Label7)
        Me.fraUpdate.Controls.Add(Me.Label6)
        Me.fraUpdate.Controls.Add(Me.Label2)
        Me.fraUpdate.Controls.Add(Me.txtRelayPort)
        Me.fraUpdate.Controls.Add(Me.Label1)
        Me.fraUpdate.Location = New System.Drawing.Point(9, 220)
        Me.fraUpdate.Name = "fraUpdate"
        Me.fraUpdate.Size = New System.Drawing.Size(701, 266)
        Me.fraUpdate.TabIndex = 5
        Me.fraUpdate.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPrice40RH)
        Me.GroupBox1.Controls.Add(Me.txtPrice40RF)
        Me.GroupBox1.Controls.Add(Me.txtPrice20RF)
        Me.GroupBox1.Controls.Add(Me.txtPrice45HC)
        Me.GroupBox1.Controls.Add(Me.txtPrice40HC)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtPrice40GP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPrice20GP)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(627, 84)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Container Price"
        '
        'txtPrice40RH
        '
        Me.txtPrice40RH.Location = New System.Drawing.Point(539, 24)
        Me.txtPrice40RH.Name = "txtPrice40RH"
        Me.txtPrice40RH.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice40RH.TabIndex = 1
        Me.txtPrice40RH.Text = "0"
        Me.txtPrice40RH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice40RF
        '
        Me.txtPrice40RF.Location = New System.Drawing.Point(242, 52)
        Me.txtPrice40RF.Name = "txtPrice40RF"
        Me.txtPrice40RF.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice40RF.TabIndex = 1
        Me.txtPrice40RF.Text = "0"
        Me.txtPrice40RF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice20RF
        '
        Me.txtPrice20RF.Location = New System.Drawing.Point(242, 22)
        Me.txtPrice20RF.Name = "txtPrice20RF"
        Me.txtPrice20RF.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice20RF.TabIndex = 1
        Me.txtPrice20RF.Text = "0"
        Me.txtPrice20RF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice45HC
        '
        Me.txtPrice45HC.Location = New System.Drawing.Point(387, 51)
        Me.txtPrice45HC.Name = "txtPrice45HC"
        Me.txtPrice45HC.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice45HC.TabIndex = 1
        Me.txtPrice45HC.Text = "0"
        Me.txtPrice45HC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPrice40HC
        '
        Me.txtPrice40HC.Location = New System.Drawing.Point(387, 23)
        Me.txtPrice40HC.Name = "txtPrice40HC"
        Me.txtPrice40HC.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice40HC.TabIndex = 1
        Me.txtPrice40HC.Text = "0"
        Me.txtPrice40HC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Maroon
        Me.Label11.Location = New System.Drawing.Point(469, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(68, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Price 40RH :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Maroon
        Me.Label10.Location = New System.Drawing.Point(174, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Price 40RF :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Maroon
        Me.Label9.Location = New System.Drawing.Point(173, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Price 20RF :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Maroon
        Me.Label8.Location = New System.Drawing.Point(318, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Price 45HC :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(318, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Price 40HC :"
        '
        'txtPrice40GP
        '
        Me.txtPrice40GP.Location = New System.Drawing.Point(80, 49)
        Me.txtPrice40GP.Name = "txtPrice40GP"
        Me.txtPrice40GP.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice40GP.TabIndex = 1
        Me.txtPrice40GP.Text = "0"
        Me.txtPrice40GP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(11, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Price 40GP :"
        '
        'txtPrice20GP
        '
        Me.txtPrice20GP.Location = New System.Drawing.Point(80, 22)
        Me.txtPrice20GP.Name = "txtPrice20GP"
        Me.txtPrice20GP.Size = New System.Drawing.Size(66, 20)
        Me.txtPrice20GP.TabIndex = 1
        Me.txtPrice20GP.Text = "0"
        Me.txtPrice20GP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(11, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 13)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Price 20GP :"
        '
        'cboPOD
        '
        Me.cboPOD.FormattingEnabled = True
        Me.cboPOD.Location = New System.Drawing.Point(133, 107)
        Me.cboPOD.Name = "cboPOD"
        Me.cboPOD.Size = New System.Drawing.Size(191, 21)
        Me.cboPOD.TabIndex = 3
        '
        'cboPOL
        '
        Me.cboPOL.FormattingEnabled = True
        Me.cboPOL.Location = New System.Drawing.Point(133, 66)
        Me.cboPOL.Name = "cboPOL"
        Me.cboPOL.Size = New System.Drawing.Size(191, 21)
        Me.cboPOL.TabIndex = 3
        '
        'cboMarket
        '
        Me.cboMarket.FormattingEnabled = True
        Me.cboMarket.Location = New System.Drawing.Point(133, 27)
        Me.cboMarket.Name = "cboMarket"
        Me.cboMarket.Size = New System.Drawing.Size(191, 21)
        Me.cboMarket.TabIndex = 3
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(539, 237)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 2
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(620, 237)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 2
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Maroon
        Me.Label7.Location = New System.Drawing.Point(96, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "POD :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Maroon
        Me.Label6.Location = New System.Drawing.Point(96, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "POL :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Maroon
        Me.Label2.Location = New System.Drawing.Point(10, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Market Code  / Market :"
        '
        'txtRelayPort
        '
        Me.txtRelayPort.Location = New System.Drawing.Point(412, 27)
        Me.txtRelayPort.Multiline = True
        Me.txtRelayPort.Name = "txtRelayPort"
        Me.txtRelayPort.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtRelayPort.Size = New System.Drawing.Size(191, 101)
        Me.txtRelayPort.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(348, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Relay Port :"
        '
        'frmInlandArbitray
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 498)
        Me.Controls.Add(Me.dgdInlandArbitray)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.fraUpdate)
        Me.Name = "frmInlandArbitray"
        Me.Text = "Inland Arbitray"
        CType(Me.dgdInlandArbitray, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.fraUpdate.ResumeLayout(False)
        Me.fraUpdate.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdInlandArbitray As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents smnuSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fraUpdate As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPOD As System.Windows.Forms.ComboBox
    Friend WithEvents cboPOL As System.Windows.Forms.ComboBox
    Friend WithEvents cboMarket As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRelayPort As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPrice40RH As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice40RF As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice20RF As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice45HC As System.Windows.Forms.TextBox
    Friend WithEvents txtPrice40HC As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtPrice40GP As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPrice20GP As System.Windows.Forms.TextBox
    Friend WithEvents InlandArbitrayID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Market_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MarketCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Market As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RelayPort As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price40RH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
