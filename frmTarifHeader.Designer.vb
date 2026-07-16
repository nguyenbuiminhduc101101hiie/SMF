<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTarifHeader
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.smnuNewHeader = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEditHeader = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuDeleteHeader = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.smnuNewDetails = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuEditDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuDeleteDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.smnuRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.smnuExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlToolbar = New System.Windows.Forms.Panel()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.lblSelectedInfo = New System.Windows.Forms.Label()
        Me.splitMain = New System.Windows.Forms.SplitContainer()
        Me.pnlHeaderList = New System.Windows.Forms.Panel()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.dgdHeader = New System.Windows.Forms.DataGridView()
        Me.pnlDetailList = New System.Windows.Forms.Panel()
        Me.lblDetailTitle = New System.Windows.Forms.Label()
        Me.dgdDetail = New System.Windows.Forms.DataGridView()
        Me.MenuStrip.SuspendLayout()
        Me.pnlToolbar.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitMain.Panel1.SuspendLayout()
        Me.splitMain.Panel2.SuspendLayout()
        Me.splitMain.SuspendLayout()
        Me.pnlHeaderList.SuspendLayout()
        CType(Me.dgdHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetailList.SuspendLayout()
        CType(Me.dgdDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.smnuNewHeader, Me.smnuEditHeader, Me.smnuDeleteHeader, Me.ToolStripSeparator1, Me.smnuNewDetails, Me.smnuEditDetail, Me.smnuDeleteDetail, Me.ToolStripSeparator2, Me.smnuRefresh, Me.smnuExit})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1000, 24)
        Me.MenuStrip.TabIndex = 0
        '
        'smnuNewHeader
        '
        Me.smnuNewHeader.Name = "smnuNewHeader"
        Me.smnuNewHeader.Size = New System.Drawing.Size(85, 20)
        Me.smnuNewHeader.Text = "New Header"
        '
        'smnuEditHeader
        '
        Me.smnuEditHeader.Name = "smnuEditHeader"
        Me.smnuEditHeader.Size = New System.Drawing.Size(81, 20)
        Me.smnuEditHeader.Text = "Edit Header"
        '
        'smnuDeleteHeader
        '
        Me.smnuDeleteHeader.Name = "smnuDeleteHeader"
        Me.smnuDeleteHeader.Size = New System.Drawing.Size(94, 20)
        Me.smnuDeleteHeader.Text = "Delete Header"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 24)
        '
        'smnuNewDetails
        '
        Me.smnuNewDetails.ForeColor = System.Drawing.Color.DarkGreen
        Me.smnuNewDetails.Name = "smnuNewDetails"
        Me.smnuNewDetails.Size = New System.Drawing.Size(82, 20)
        Me.smnuNewDetails.Text = "New Details"
        '
        'smnuEditDetail
        '
        Me.smnuEditDetail.ForeColor = System.Drawing.Color.DarkOrange
        Me.smnuEditDetail.Name = "smnuEditDetail"
        Me.smnuEditDetail.Size = New System.Drawing.Size(73, 20)
        Me.smnuEditDetail.Text = "Edit Detail"
        '
        'smnuDeleteDetail
        '
        Me.smnuDeleteDetail.Name = "smnuDeleteDetail"
        Me.smnuDeleteDetail.Size = New System.Drawing.Size(87, 20)
        Me.smnuDeleteDetail.Text = "Delete Detail"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 24)
        '
        'smnuRefresh
        '
        Me.smnuRefresh.Name = "smnuRefresh"
        Me.smnuRefresh.Size = New System.Drawing.Size(58, 20)
        Me.smnuRefresh.Text = "Refresh"
        '
        'smnuExit
        '
        Me.smnuExit.Name = "smnuExit"
        Me.smnuExit.Size = New System.Drawing.Size(37, 20)
        Me.smnuExit.Text = "Exit"
        '
        'pnlToolbar
        '
        Me.pnlToolbar.Controls.Add(Me.lblTitle)
        Me.pnlToolbar.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlToolbar.Location = New System.Drawing.Point(0, 24)
        Me.pnlToolbar.Name = "pnlToolbar"
        Me.pnlToolbar.Size = New System.Drawing.Size(1000, 40)
        Me.pnlToolbar.TabIndex = 1
        '
        'lblTitle
        '
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Padding = New System.Windows.Forms.Padding(12, 0, 0, 0)
        Me.lblTitle.Size = New System.Drawing.Size(1000, 40)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Tarif Header Management"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlInfo
        '
        Me.pnlInfo.Controls.Add(Me.lblSelectedInfo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 64)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Padding = New System.Windows.Forms.Padding(12, 6, 12, 6)
        Me.pnlInfo.Size = New System.Drawing.Size(1000, 32)
        Me.pnlInfo.TabIndex = 2
        '
        'lblSelectedInfo
        '
        Me.lblSelectedInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblSelectedInfo.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.lblSelectedInfo.ForeColor = System.Drawing.Color.DimGray
        Me.lblSelectedInfo.Location = New System.Drawing.Point(12, 6)
        Me.lblSelectedInfo.Name = "lblSelectedInfo"
        Me.lblSelectedInfo.Size = New System.Drawing.Size(976, 20)
        Me.lblSelectedInfo.TabIndex = 0
        Me.lblSelectedInfo.Text = "No header selected."
        Me.lblSelectedInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'splitMain
        '
        Me.splitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.splitMain.Location = New System.Drawing.Point(0, 96)
        Me.splitMain.Name = "splitMain"
        Me.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'splitMain.Panel1
        '
        Me.splitMain.Panel1.Controls.Add(Me.pnlHeaderList)
        '
        'splitMain.Panel2
        '
        Me.splitMain.Panel2.Controls.Add(Me.pnlDetailList)
        Me.splitMain.Size = New System.Drawing.Size(1000, 504)
        Me.splitMain.SplitterDistance = 240
        Me.splitMain.TabIndex = 3
        '
        'pnlHeaderList
        '
        Me.pnlHeaderList.Controls.Add(Me.dgdHeader)
        Me.pnlHeaderList.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeaderList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHeaderList.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeaderList.Name = "pnlHeaderList"
        Me.pnlHeaderList.Padding = New System.Windows.Forms.Padding(8, 4, 8, 4)
        Me.pnlHeaderList.Size = New System.Drawing.Size(1000, 240)
        Me.pnlHeaderList.TabIndex = 0
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblHeaderTitle.Location = New System.Drawing.Point(8, 4)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(984, 22)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Header List"
        Me.lblHeaderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgdHeader
        '
        Me.dgdHeader.AllowUserToAddRows = False
        Me.dgdHeader.AllowUserToDeleteRows = False
        Me.dgdHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdHeader.Location = New System.Drawing.Point(8, 26)
        Me.dgdHeader.Name = "dgdHeader"
        Me.dgdHeader.ReadOnly = True
        Me.dgdHeader.RowHeadersWidth = 24
        Me.dgdHeader.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdHeader.Size = New System.Drawing.Size(984, 210)
        Me.dgdHeader.TabIndex = 1
        '
        'pnlDetailList
        '
        Me.pnlDetailList.Controls.Add(Me.dgdDetail)
        Me.pnlDetailList.Controls.Add(Me.lblDetailTitle)
        Me.pnlDetailList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetailList.Location = New System.Drawing.Point(0, 0)
        Me.pnlDetailList.Name = "pnlDetailList"
        Me.pnlDetailList.Padding = New System.Windows.Forms.Padding(8, 4, 8, 8)
        Me.pnlDetailList.Size = New System.Drawing.Size(1000, 260)
        Me.pnlDetailList.TabIndex = 0
        '
        'lblDetailTitle
        '
        Me.lblDetailTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblDetailTitle.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblDetailTitle.ForeColor = System.Drawing.Color.SeaGreen
        Me.lblDetailTitle.Location = New System.Drawing.Point(8, 4)
        Me.lblDetailTitle.Name = "lblDetailTitle"
        Me.lblDetailTitle.Size = New System.Drawing.Size(984, 22)
        Me.lblDetailTitle.TabIndex = 0
        Me.lblDetailTitle.Text = "Detail List (select a header above)"
        Me.lblDetailTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgdDetail
        '
        Me.dgdDetail.AllowUserToAddRows = False
        Me.dgdDetail.AllowUserToDeleteRows = False
        Me.dgdDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgdDetail.Location = New System.Drawing.Point(8, 26)
        Me.dgdDetail.Name = "dgdDetail"
        Me.dgdDetail.ReadOnly = True
        Me.dgdDetail.RowHeadersWidth = 24
        Me.dgdDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdDetail.Size = New System.Drawing.Size(984, 226)
        Me.dgdDetail.TabIndex = 1
        '
        'frmTarifHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1000, 600)
        Me.Controls.Add(Me.splitMain)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlToolbar)
        Me.Controls.Add(Me.MenuStrip)
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "frmTarifHeader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Tarif Header"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.pnlToolbar.ResumeLayout(False)
        Me.pnlInfo.ResumeLayout(False)
        Me.splitMain.Panel1.ResumeLayout(False)
        Me.splitMain.Panel2.ResumeLayout(False)
        CType(Me.splitMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitMain.ResumeLayout(False)
        Me.pnlHeaderList.ResumeLayout(False)
        CType(Me.dgdHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetailList.ResumeLayout(False)
        CType(Me.dgdDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents smnuNewHeader As ToolStripMenuItem
    Friend WithEvents smnuEditHeader As ToolStripMenuItem
    Friend WithEvents smnuDeleteHeader As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents smnuNewDetails As ToolStripMenuItem
    Friend WithEvents smnuEditDetail As ToolStripMenuItem
    Friend WithEvents smnuDeleteDetail As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents smnuRefresh As ToolStripMenuItem
    Friend WithEvents smnuExit As ToolStripMenuItem
    Friend WithEvents pnlToolbar As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents pnlInfo As Panel
    Friend WithEvents lblSelectedInfo As Label
    Friend WithEvents splitMain As SplitContainer
    Friend WithEvents pnlHeaderList As Panel
    Friend WithEvents lblHeaderTitle As Label
    Friend WithEvents dgdHeader As DataGridView
    Friend WithEvents pnlDetailList As Panel
    Friend WithEvents lblDetailTitle As Label
    Friend WithEvents dgdDetail As DataGridView
End Class
