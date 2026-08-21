<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportFreightQuotation
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabImport = New System.Windows.Forms.TabPage()
        Me.tabView = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkReplaceOld = New System.Windows.Forms.CheckBox()
        Me.txtValidMonth = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtQuotationName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdUnselectAll = New System.Windows.Forms.Button()
        Me.cmdSelectAll = New System.Windows.Forms.Button()
        Me.lstSheets = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFileName = New System.Windows.Forms.TextBox()
        Me.cmdBrowser = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.prbImport = New System.Windows.Forms.ProgressBar()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.pnlFilter = New System.Windows.Forms.Panel()
        Me.chkActiveOnly = New System.Windows.Forms.CheckBox()
        Me.cmdSearch = New System.Windows.Forms.Button()
        Me.txtKeyword = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtPod = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPol = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAgent = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBatch = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTable = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dgdData = New System.Windows.Forms.DataGridView()
        Me.lblRowCount = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tabImport.SuspendLayout()
        Me.tabView.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnlFilter.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls"
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabImport)
        Me.tabMain.Controls.Add(Me.tabView)
        Me.tabMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabMain.Location = New System.Drawing.Point(0, 0)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(1084, 661)
        Me.tabMain.TabIndex = 0
        '
        'tabImport
        '
        Me.tabImport.Controls.Add(Me.cmdCancel)
        Me.tabImport.Controls.Add(Me.cmdOK)
        Me.tabImport.Controls.Add(Me.txtLog)
        Me.tabImport.Controls.Add(Me.lblNote)
        Me.tabImport.Controls.Add(Me.lblStatus)
        Me.tabImport.Controls.Add(Me.prbImport)
        Me.tabImport.Controls.Add(Me.GroupBox1)
        Me.tabImport.Location = New System.Drawing.Point(4, 24)
        Me.tabImport.Name = "tabImport"
        Me.tabImport.Padding = New System.Windows.Forms.Padding(3)
        Me.tabImport.Size = New System.Drawing.Size(1076, 633)
        Me.tabImport.TabIndex = 0
        Me.tabImport.Text = "1. Import Excel"
        Me.tabImport.UseVisualStyleBackColor = True
        '
        'tabView
        '
        Me.tabView.Controls.Add(Me.dgdData)
        Me.tabView.Controls.Add(Me.lblRowCount)
        Me.tabView.Controls.Add(Me.pnlFilter)
        Me.tabView.Location = New System.Drawing.Point(4, 24)
        Me.tabView.Name = "tabView"
        Me.tabView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabView.Size = New System.Drawing.Size(1076, 633)
        Me.tabView.TabIndex = 1
        Me.tabView.Text = "2. Tra cuu / View"
        Me.tabView.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkReplaceOld)
        Me.GroupBox1.Controls.Add(Me.txtValidMonth)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtQuotationName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmdUnselectAll)
        Me.GroupBox1.Controls.Add(Me.cmdSelectAll)
        Me.GroupBox1.Controls.Add(Me.lstSheets)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtFileName)
        Me.GroupBox1.Controls.Add(Me.cmdBrowser)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Navy
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(560, 236)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import Freight Quotation Sea-Air"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(12, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "File Excel :"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(108, 22)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(340, 21)
        Me.txtFileName.TabIndex = 1
        '
        'cmdBrowser
        '
        Me.cmdBrowser.ForeColor = System.Drawing.Color.Maroon
        Me.cmdBrowser.Location = New System.Drawing.Point(454, 20)
        Me.cmdBrowser.Name = "cmdBrowser"
        Me.cmdBrowser.Size = New System.Drawing.Size(90, 23)
        Me.cmdBrowser.TabIndex = 2
        Me.cmdBrowser.Text = "Browser..."
        Me.cmdBrowser.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Ten bao gia :"
        '
        'txtQuotationName
        '
        Me.txtQuotationName.Location = New System.Drawing.Point(108, 50)
        Me.txtQuotationName.Name = "txtQuotationName"
        Me.txtQuotationName.Size = New System.Drawing.Size(340, 21)
        Me.txtQuotationName.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(12, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Hieu luc :"
        '
        'txtValidMonth
        '
        Me.txtValidMonth.Location = New System.Drawing.Point(108, 78)
        Me.txtValidMonth.Name = "txtValidMonth"
        Me.txtValidMonth.Size = New System.Drawing.Size(140, 21)
        Me.txtValidMonth.TabIndex = 6
        Me.txtValidMonth.Text = "T5-2026"
        '
        'chkReplaceOld
        '
        Me.chkReplaceOld.AutoSize = True
        Me.chkReplaceOld.ForeColor = System.Drawing.Color.Maroon
        Me.chkReplaceOld.Location = New System.Drawing.Point(260, 80)
        Me.chkReplaceOld.Name = "chkReplaceOld"
        Me.chkReplaceOld.Size = New System.Drawing.Size(284, 19)
        Me.chkReplaceOld.TabIndex = 7
        Me.chkReplaceOld.Text = "Vo hieu hoa batch cu cung ten file (Continued = 0)"
        Me.chkReplaceOld.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(12, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Sheets import :"
        '
        'lstSheets
        '
        Me.lstSheets.CheckOnClick = True
        Me.lstSheets.FormattingEnabled = True
        Me.lstSheets.Location = New System.Drawing.Point(108, 108)
        Me.lstSheets.Name = "lstSheets"
        Me.lstSheets.Size = New System.Drawing.Size(340, 94)
        Me.lstSheets.TabIndex = 9
        '
        'cmdSelectAll
        '
        Me.cmdSelectAll.ForeColor = System.Drawing.Color.Maroon
        Me.cmdSelectAll.Location = New System.Drawing.Point(454, 108)
        Me.cmdSelectAll.Name = "cmdSelectAll"
        Me.cmdSelectAll.Size = New System.Drawing.Size(90, 23)
        Me.cmdSelectAll.TabIndex = 10
        Me.cmdSelectAll.Text = "Chon tat ca"
        Me.cmdSelectAll.UseVisualStyleBackColor = True
        '
        'cmdUnselectAll
        '
        Me.cmdUnselectAll.ForeColor = System.Drawing.Color.Maroon
        Me.cmdUnselectAll.Location = New System.Drawing.Point(454, 137)
        Me.cmdUnselectAll.Name = "cmdUnselectAll"
        Me.cmdUnselectAll.Size = New System.Drawing.Size(90, 23)
        Me.cmdUnselectAll.TabIndex = 11
        Me.cmdUnselectAll.Text = "Bo chon"
        Me.cmdUnselectAll.UseVisualStyleBackColor = True
        '
        'prbImport
        '
        Me.prbImport.Location = New System.Drawing.Point(12, 258)
        Me.prbImport.Name = "prbImport"
        Me.prbImport.Size = New System.Drawing.Size(560, 18)
        Me.prbImport.TabIndex = 1
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Maroon
        Me.lblStatus.Location = New System.Drawing.Point(12, 280)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 15)
        Me.lblStatus.TabIndex = 2
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.ForeColor = System.Drawing.Color.DimGray
        Me.lblNote.Location = New System.Drawing.Point(12, 298)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(400, 13)
        Me.lblNote.TabIndex = 3
        Me.lblNote.Text = "Chay SQL Create_FreightQuotation_Tables.sql truoc khi import."
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(12, 318)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ReadOnly = True
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(560, 90)
        Me.txtLog.TabIndex = 4
        '
        'cmdOK
        '
        Me.cmdOK.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOK.Location = New System.Drawing.Point(416, 418)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 5
        Me.cmdOK.Text = "Import"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(497, 418)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 6
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'pnlFilter
        '
        Me.pnlFilter.Controls.Add(Me.chkActiveOnly)
        Me.pnlFilter.Controls.Add(Me.cmdSearch)
        Me.pnlFilter.Controls.Add(Me.txtKeyword)
        Me.pnlFilter.Controls.Add(Me.Label9)
        Me.pnlFilter.Controls.Add(Me.txtPod)
        Me.pnlFilter.Controls.Add(Me.Label8)
        Me.pnlFilter.Controls.Add(Me.txtPol)
        Me.pnlFilter.Controls.Add(Me.Label7)
        Me.pnlFilter.Controls.Add(Me.txtAgent)
        Me.pnlFilter.Controls.Add(Me.Label6)
        Me.pnlFilter.Controls.Add(Me.cboBatch)
        Me.pnlFilter.Controls.Add(Me.Label5)
        Me.pnlFilter.Controls.Add(Me.cboTable)
        Me.pnlFilter.Controls.Add(Me.Label10)
        Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlFilter.Location = New System.Drawing.Point(3, 3)
        Me.pnlFilter.Name = "pnlFilter"
        Me.pnlFilter.Size = New System.Drawing.Size(1070, 78)
        Me.pnlFilter.TabIndex = 0
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(8, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 15)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Bang :"
        '
        'cboTable
        '
        Me.cboTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTable.FormattingEnabled = True
        Me.cboTable.Items.AddRange(New Object() {"Batch", "FCL-FOB", "FCL-EXW", "LCL-FOB", "LCL-EXW", "AIR-FOB", "AIR-EXW"})
        Me.cboTable.Location = New System.Drawing.Point(53, 8)
        Me.cboTable.Name = "cboTable"
        Me.cboTable.Size = New System.Drawing.Size(130, 23)
        Me.cboTable.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(195, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Batch :"
        '
        'cboBatch
        '
        Me.cboBatch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBatch.FormattingEnabled = True
        Me.cboBatch.Location = New System.Drawing.Point(243, 8)
        Me.cboBatch.Name = "cboBatch"
        Me.cboBatch.Size = New System.Drawing.Size(280, 23)
        Me.cboBatch.TabIndex = 3
        '
        'chkActiveOnly
        '
        Me.chkActiveOnly.AutoSize = True
        Me.chkActiveOnly.Checked = True
        Me.chkActiveOnly.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActiveOnly.ForeColor = System.Drawing.Color.Maroon
        Me.chkActiveOnly.Location = New System.Drawing.Point(535, 10)
        Me.chkActiveOnly.Name = "chkActiveOnly"
        Me.chkActiveOnly.Size = New System.Drawing.Size(170, 19)
        Me.chkActiveOnly.TabIndex = 4
        Me.chkActiveOnly.Text = "Chi batch dang hieu luc"
        Me.chkActiveOnly.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(8, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Agent :"
        '
        'txtAgent
        '
        Me.txtAgent.Location = New System.Drawing.Point(53, 43)
        Me.txtAgent.Name = "txtAgent"
        Me.txtAgent.Size = New System.Drawing.Size(90, 21)
        Me.txtAgent.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(155, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "POL :"
        '
        'txtPol
        '
        Me.txtPol.Location = New System.Drawing.Point(193, 43)
        Me.txtPol.Name = "txtPol"
        Me.txtPol.Size = New System.Drawing.Size(90, 21)
        Me.txtPol.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(295, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "POD :"
        '
        'txtPod
        '
        Me.txtPod.Location = New System.Drawing.Point(336, 43)
        Me.txtPod.Name = "txtPod"
        Me.txtPod.Size = New System.Drawing.Size(90, 21)
        Me.txtPod.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(438, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(59, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Keyword :"
        '
        'txtKeyword
        '
        Me.txtKeyword.Location = New System.Drawing.Point(503, 43)
        Me.txtKeyword.Name = "txtKeyword"
        Me.txtKeyword.Size = New System.Drawing.Size(160, 21)
        Me.txtKeyword.TabIndex = 12
        '
        'cmdSearch
        '
        Me.cmdSearch.ForeColor = System.Drawing.Color.Maroon
        Me.cmdSearch.Location = New System.Drawing.Point(675, 41)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(90, 24)
        Me.cmdSearch.TabIndex = 13
        Me.cmdSearch.Text = "Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Location = New System.Drawing.Point(6, 87)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.RowHeadersWidth = 25
        Me.dgdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdData.Size = New System.Drawing.Size(1061, 515)
        Me.dgdData.TabIndex = 1
        '
        'lblRowCount
        '
        Me.lblRowCount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRowCount.AutoSize = True
        Me.lblRowCount.ForeColor = System.Drawing.Color.Maroon
        Me.lblRowCount.Location = New System.Drawing.Point(6, 607)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(0, 15)
        Me.lblRowCount.TabIndex = 2
        '
        'frmImportFreightQuotation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1084, 661)
        Me.Controls.Add(Me.tabMain)
        Me.MinimizeBox = False
        Me.Name = "frmImportFreightQuotation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Freight Quotation Sea-Air"
        Me.tabMain.ResumeLayout(False)
        Me.tabImport.ResumeLayout(False)
        Me.tabImport.PerformLayout()
        Me.tabView.ResumeLayout(False)
        Me.tabView.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnlFilter.ResumeLayout(False)
        Me.pnlFilter.PerformLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabImport As System.Windows.Forms.TabPage
    Friend WithEvents tabView As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkReplaceOld As System.Windows.Forms.CheckBox
    Friend WithEvents txtValidMonth As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQuotationName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdUnselectAll As System.Windows.Forms.Button
    Friend WithEvents cmdSelectAll As System.Windows.Forms.Button
    Friend WithEvents lstSheets As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtFileName As System.Windows.Forms.TextBox
    Friend WithEvents cmdBrowser As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents prbImport As System.Windows.Forms.ProgressBar
    Friend WithEvents txtLog As System.Windows.Forms.TextBox
    Friend WithEvents cmdOK As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents chkActiveOnly As System.Windows.Forms.CheckBox
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
    Friend WithEvents txtKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtPod As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPol As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtAgent As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboBatch As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboTable As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents lblRowCount As System.Windows.Forms.Label
End Class
