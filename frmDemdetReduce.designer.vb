<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDemdetReduce
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
        Me.dgdDemBillData = New System.Windows.Forms.DataGridView
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchBillOfLadingInboundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdAll = New System.Windows.Forms.Button
        Me.lblToTalContainer = New System.Windows.Forms.Label
        Me.cboBLNO = New System.Windows.Forms.ComboBox
        Me.cboContainerNo = New System.Windows.Forms.ComboBox
        Me.cboContainer_type = New System.Windows.Forms.ComboBox
        Me.chkDetDays = New System.Windows.Forms.CheckBox
        Me.chkDemdays = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.txtDetDays = New System.Windows.Forms.TextBox
        Me.txtDemDays = New System.Windows.Forms.TextBox
        Me.txtPicApproveDem = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtPicApproveDet = New System.Windows.Forms.TextBox
        Me.txtRefDem = New System.Windows.Forms.TextBox
        Me.txtRefDet = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.DemDetReduceID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BLIB_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_No = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DeMurrageDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DemDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DetDays = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PicApproveDem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PicApproveDet = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefDem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RefDet = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdDemBillData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdDemBillData
        '
        Me.dgdDemBillData.AllowUserToAddRows = False
        Me.dgdDemBillData.AllowUserToDeleteRows = False
        Me.dgdDemBillData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdDemBillData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdDemBillData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DemDetReduceID, Me.BLIB_NO, Me.Container_No, Me.Container_Type, Me.DeMurrageDate, Me.DemDays, Me.DetDays, Me.PicApproveDem, Me.PicApproveDet, Me.RefDem, Me.RefDet})
        Me.dgdDemBillData.ContextMenuStrip = Me.ContextMenuStrip1
        Me.dgdDemBillData.Location = New System.Drawing.Point(4, 24)
        Me.dgdDemBillData.Name = "dgdDemBillData"
        Me.dgdDemBillData.ReadOnly = True
        Me.dgdDemBillData.Size = New System.Drawing.Size(674, 168)
        Me.dgdDemBillData.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeleteToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(106, 26)
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(105, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchToolStripMenuItem, Me.SearchBillOfLadingInboundToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(686, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(129, 20)
        Me.SearchToolStripMenuItem.Text = "Search DemDetReduce"
        '
        'SearchBillOfLadingInboundToolStripMenuItem
        '
        Me.SearchBillOfLadingInboundToolStripMenuItem.Name = "SearchBillOfLadingInboundToolStripMenuItem"
        Me.SearchBillOfLadingInboundToolStripMenuItem.Size = New System.Drawing.Size(167, 20)
        Me.SearchBillOfLadingInboundToolStripMenuItem.Text = "Search Bill Of Lading( Inbound)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cmdAll)
        Me.GroupBox1.Controls.Add(Me.lblToTalContainer)
        Me.GroupBox1.Controls.Add(Me.cboBLNO)
        Me.GroupBox1.Controls.Add(Me.cboContainerNo)
        Me.GroupBox1.Controls.Add(Me.cboContainer_type)
        Me.GroupBox1.Controls.Add(Me.chkDetDays)
        Me.GroupBox1.Controls.Add(Me.chkDemdays)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.txtPicApproveDet)
        Me.GroupBox1.Controls.Add(Me.txtRefDet)
        Me.GroupBox1.Controls.Add(Me.txtRefDem)
        Me.GroupBox1.Controls.Add(Me.txtPicApproveDem)
        Me.GroupBox1.Controls.Add(Me.txtDetDays)
        Me.GroupBox1.Controls.Add(Me.txtDemDays)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 198)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(671, 175)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cmdAll
        '
        Me.cmdAll.Location = New System.Drawing.Point(567, 138)
        Me.cmdAll.Name = "cmdAll"
        Me.cmdAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdAll.TabIndex = 13
        Me.cmdAll.Text = "All (of 1 bill)"
        Me.cmdAll.UseVisualStyleBackColor = True
        '
        'lblToTalContainer
        '
        Me.lblToTalContainer.AutoSize = True
        Me.lblToTalContainer.Location = New System.Drawing.Point(326, 26)
        Me.lblToTalContainer.Name = "lblToTalContainer"
        Me.lblToTalContainer.Size = New System.Drawing.Size(0, 13)
        Me.lblToTalContainer.TabIndex = 7
        '
        'cboBLNO
        '
        Me.cboBLNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboBLNO.FormattingEnabled = True
        Me.cboBLNO.Location = New System.Drawing.Point(82, 19)
        Me.cboBLNO.Name = "cboBLNO"
        Me.cboBLNO.Size = New System.Drawing.Size(234, 28)
        Me.cboBLNO.TabIndex = 0
        '
        'cboContainerNo
        '
        Me.cboContainerNo.FormattingEnabled = True
        Me.cboContainerNo.Location = New System.Drawing.Point(82, 58)
        Me.cboContainerNo.Name = "cboContainerNo"
        Me.cboContainerNo.Size = New System.Drawing.Size(140, 21)
        Me.cboContainerNo.TabIndex = 1
        '
        'cboContainer_type
        '
        Me.cboContainer_type.Enabled = False
        Me.cboContainer_type.FormattingEnabled = True
        Me.cboContainer_type.Location = New System.Drawing.Point(256, 58)
        Me.cboContainer_type.Name = "cboContainer_type"
        Me.cboContainer_type.Size = New System.Drawing.Size(60, 21)
        Me.cboContainer_type.TabIndex = 2
        '
        'chkDetDays
        '
        Me.chkDetDays.AutoSize = True
        Me.chkDetDays.Location = New System.Drawing.Point(618, 65)
        Me.chkDetDays.Name = "chkDetDays"
        Me.chkDetDays.Size = New System.Drawing.Size(15, 14)
        Me.chkDetDays.TabIndex = 7
        Me.chkDetDays.UseVisualStyleBackColor = True
        '
        'chkDemdays
        '
        Me.chkDemdays.AutoSize = True
        Me.chkDemdays.Location = New System.Drawing.Point(617, 20)
        Me.chkDemdays.Name = "chkDemdays"
        Me.chkDemdays.Size = New System.Drawing.Size(15, 14)
        Me.chkDemdays.TabIndex = 5
        Me.chkDemdays.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Type :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Cont No. :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "B/L No :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(466, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Reduce Det :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(460, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Reduce Dem :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(576, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "day(s)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(575, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "day(s)"
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(482, 138)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 14
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(399, 138)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 15
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'txtDetDays
        '
        Me.txtDetDays.Enabled = False
        Me.txtDetDays.Location = New System.Drawing.Point(540, 61)
        Me.txtDetDays.Name = "txtDetDays"
        Me.txtDetDays.Size = New System.Drawing.Size(34, 20)
        Me.txtDetDays.TabIndex = 0
        '
        'txtDemDays
        '
        Me.txtDemDays.Enabled = False
        Me.txtDemDays.Location = New System.Drawing.Point(539, 16)
        Me.txtDemDays.Name = "txtDemDays"
        Me.txtDemDays.Size = New System.Drawing.Size(34, 20)
        Me.txtDemDays.TabIndex = 6
        '
        'txtPicApproveDem
        '
        Me.txtPicApproveDem.Location = New System.Drawing.Point(82, 85)
        Me.txtPicApproveDem.Name = "txtPicApproveDem"
        Me.txtPicApproveDem.Size = New System.Drawing.Size(234, 20)
        Me.txtPicApproveDem.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "ApproveDem :"
        '
        'txtPicApproveDet
        '
        Me.txtPicApproveDet.Location = New System.Drawing.Point(82, 111)
        Me.txtPicApproveDet.Name = "txtPicApproveDet"
        Me.txtPicApproveDet.Size = New System.Drawing.Size(234, 20)
        Me.txtPicApproveDet.TabIndex = 10
        '
        'txtRefDem
        '
        Me.txtRefDem.Location = New System.Drawing.Point(467, 85)
        Me.txtRefDem.Name = "txtRefDem"
        Me.txtRefDem.Size = New System.Drawing.Size(164, 20)
        Me.txtRefDem.TabIndex = 11
        '
        'txtRefDet
        '
        Me.txtRefDet.Location = New System.Drawing.Point(467, 111)
        Me.txtRefDet.Name = "txtRefDet"
        Me.txtRefDet.Size = New System.Drawing.Size(164, 20)
        Me.txtRefDet.TabIndex = 12
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(7, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "ApproveDet :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(410, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Ref Dem :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(415, 115)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Ref Det :"
        '
        'DemDetReduceID
        '
        Me.DemDetReduceID.DataPropertyName = "DemDetReduceID"
        Me.DemDetReduceID.HeaderText = "DemDetReduceID"
        Me.DemDetReduceID.Name = "DemDetReduceID"
        Me.DemDetReduceID.ReadOnly = True
        Me.DemDetReduceID.Visible = False
        '
        'BLIB_NO
        '
        Me.BLIB_NO.DataPropertyName = "BLIB_NO"
        Me.BLIB_NO.HeaderText = "B/L No"
        Me.BLIB_NO.Name = "BLIB_NO"
        Me.BLIB_NO.ReadOnly = True
        '
        'Container_No
        '
        Me.Container_No.DataPropertyName = "Container_No"
        Me.Container_No.HeaderText = "Container No."
        Me.Container_No.Name = "Container_No"
        Me.Container_No.ReadOnly = True
        '
        'Container_Type
        '
        Me.Container_Type.DataPropertyName = "Container_Type"
        Me.Container_Type.HeaderText = "Container Type"
        Me.Container_Type.Name = "Container_Type"
        Me.Container_Type.ReadOnly = True
        '
        'DeMurrageDate
        '
        Me.DeMurrageDate.DataPropertyName = "DeMurrageDate"
        Me.DeMurrageDate.HeaderText = "Demurrage Date"
        Me.DeMurrageDate.Name = "DeMurrageDate"
        Me.DeMurrageDate.ReadOnly = True
        Me.DeMurrageDate.Visible = False
        '
        'DemDays
        '
        Me.DemDays.DataPropertyName = "DemDays"
        Me.DemDays.HeaderText = "Dem Day (Reduce)"
        Me.DemDays.Name = "DemDays"
        Me.DemDays.ReadOnly = True
        '
        'DetDays
        '
        Me.DetDays.DataPropertyName = "DetDays"
        Me.DetDays.HeaderText = "Det day (Reduce)"
        Me.DetDays.Name = "DetDays"
        Me.DetDays.ReadOnly = True
        '
        'PicApproveDem
        '
        Me.PicApproveDem.DataPropertyName = "PicApproveDem"
        Me.PicApproveDem.HeaderText = "Pic Approve dem"
        Me.PicApproveDem.Name = "PicApproveDem"
        Me.PicApproveDem.ReadOnly = True
        '
        'PicApproveDet
        '
        Me.PicApproveDet.DataPropertyName = "PicApproveDet"
        Me.PicApproveDet.HeaderText = "Pic Approve Det"
        Me.PicApproveDet.Name = "PicApproveDet"
        Me.PicApproveDet.ReadOnly = True
        '
        'RefDem
        '
        Me.RefDem.DataPropertyName = "RefDem"
        Me.RefDem.HeaderText = "Ref Dem"
        Me.RefDem.Name = "RefDem"
        Me.RefDem.ReadOnly = True
        '
        'RefDet
        '
        Me.RefDet.DataPropertyName = "RefDet"
        Me.RefDet.HeaderText = "Ref Det"
        Me.RefDet.Name = "RefDet"
        Me.RefDet.ReadOnly = True
        '
        'frmDemdetReduce
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(686, 385)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgdDemBillData)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmDemdetReduce"
        Me.Text = "Dem & Det Reduce"
        CType(Me.dgdDemBillData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdDemBillData As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDemDays As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDetDays As System.Windows.Forms.TextBox
    Friend WithEvents chkDetDays As System.Windows.Forms.CheckBox
    Friend WithEvents chkDemdays As System.Windows.Forms.CheckBox
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cboContainer_type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboContainerNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents SearchBillOfLadingInboundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cboBLNO As System.Windows.Forms.ComboBox
    Friend WithEvents lblToTalContainer As System.Windows.Forms.Label
    Friend WithEvents cmdAll As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtPicApproveDet As System.Windows.Forms.TextBox
    Friend WithEvents txtRefDem As System.Windows.Forms.TextBox
    Friend WithEvents txtPicApproveDem As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtRefDet As System.Windows.Forms.TextBox
    Friend WithEvents DemDetReduceID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BLIB_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DeMurrageDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DemDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DetDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PicApproveDem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PicApproveDet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefDem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RefDet As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
