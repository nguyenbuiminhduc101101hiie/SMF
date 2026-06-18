<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListBooKingData
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblcontainer_no = New System.Windows.Forms.Label
        Me.lblBL_NO = New System.Windows.Forms.Label
        Me.lblF_E = New System.Windows.Forms.Label
        Me.lblSIZE = New System.Windows.Forms.Label
        Me.lblWeight = New System.Windows.Forms.Label
        Me.lblOPR = New System.Windows.Forms.Label
        Me.lblDG_REF = New System.Windows.Forms.Label
        Me.lblETA1 = New System.Windows.Forms.Label
        Me.lblPOL = New System.Windows.Forms.Label
        Me.lblOPL = New System.Windows.Forms.Label
        Me.lblPOD = New System.Windows.Forms.Label
        Me.lblOPD = New System.Windows.Forms.Label
        Me.lblCarrier = New System.Windows.Forms.Label
        Me.txtF_E = New System.Windows.Forms.TextBox
        Me.txtSize = New System.Windows.Forms.TextBox
        Me.txtBL_NO = New System.Windows.Forms.TextBox
        Me.txtWeight = New System.Windows.Forms.TextBox
        Me.txtOPR = New System.Windows.Forms.TextBox
        Me.txtCarrier = New System.Windows.Forms.TextBox
        Me.txtDG_REF = New System.Windows.Forms.TextBox
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.lbBillNo = New System.Windows.Forms.ListBox
        Me.dgdBookingData = New System.Windows.Forms.DataGridView
        Me.txtContainer_No = New System.Windows.Forms.TextBox
        Me.txtETA1 = New System.Windows.Forms.TextBox
        Me.txtPOD = New System.Windows.Forms.TextBox
        Me.txtPOL = New System.Windows.Forms.TextBox
        Me.txtOPD = New System.Windows.Forms.TextBox
        Me.txtOPL = New System.Windows.Forms.TextBox
        Me.lblETA2 = New System.Windows.Forms.Label
        Me.txtETA2 = New System.Windows.Forms.TextBox
        Me.lblVessel2 = New System.Windows.Forms.Label
        Me.txtvessel2 = New System.Windows.Forms.TextBox
        Me.lblETD = New System.Windows.Forms.Label
        Me.txtETD = New System.Windows.Forms.TextBox
        Me.lblService = New System.Windows.Forms.Label
        Me.txtService = New System.Windows.Forms.TextBox
        Me.cmdFind = New System.Windows.Forms.Button
        Me.mnuExit = New System.Windows.Forms.MenuStrip
        Me.mnuImport = New System.Windows.Forms.ToolStripMenuItem
        Me.smnuExportExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.prbExport = New System.Windows.Forms.ProgressBar
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BooKingDataID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.F_E = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_SIZE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Weight = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OPR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OPL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DEST = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POD = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DG_REF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Carrier = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETD1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VesselName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyAge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ETA2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Service = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.continued = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Editable = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Approve = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.UserID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgdBookingData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuExit.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblcontainer_no
        '
        Me.lblcontainer_no.AutoSize = True
        Me.lblcontainer_no.Location = New System.Drawing.Point(35, 257)
        Me.lblcontainer_no.Name = "lblcontainer_no"
        Me.lblcontainer_no.Size = New System.Drawing.Size(75, 13)
        Me.lblcontainer_no.TabIndex = 2
        Me.lblcontainer_no.Text = "Container No :"
        '
        'lblBL_NO
        '
        Me.lblBL_NO.AutoSize = True
        Me.lblBL_NO.Location = New System.Drawing.Point(7, 201)
        Me.lblBL_NO.Name = "lblBL_NO"
        Me.lblBL_NO.Size = New System.Drawing.Size(43, 13)
        Me.lblBL_NO.TabIndex = 3
        Me.lblBL_NO.Text = "BL No :"
        '
        'lblF_E
        '
        Me.lblF_E.AutoSize = True
        Me.lblF_E.Location = New System.Drawing.Point(290, 229)
        Me.lblF_E.Name = "lblF_E"
        Me.lblF_E.Size = New System.Drawing.Size(31, 13)
        Me.lblF_E.TabIndex = 4
        Me.lblF_E.Text = "F/E :"
        '
        'lblSIZE
        '
        Me.lblSIZE.AutoSize = True
        Me.lblSIZE.Location = New System.Drawing.Point(283, 203)
        Me.lblSIZE.Name = "lblSIZE"
        Me.lblSIZE.Size = New System.Drawing.Size(37, 13)
        Me.lblSIZE.TabIndex = 5
        Me.lblSIZE.Text = "SIZE :"
        '
        'lblWeight
        '
        Me.lblWeight.AutoSize = True
        Me.lblWeight.Location = New System.Drawing.Point(420, 230)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(47, 13)
        Me.lblWeight.TabIndex = 6
        Me.lblWeight.Text = "Weight :"
        '
        'lblOPR
        '
        Me.lblOPR.AutoSize = True
        Me.lblOPR.Location = New System.Drawing.Point(324, 335)
        Me.lblOPR.Name = "lblOPR"
        Me.lblOPR.Size = New System.Drawing.Size(36, 13)
        Me.lblOPR.TabIndex = 7
        Me.lblOPR.Text = "OPR :"
        '
        'lblDG_REF
        '
        Me.lblDG_REF.AutoSize = True
        Me.lblDG_REF.Location = New System.Drawing.Point(411, 205)
        Me.lblDG_REF.Name = "lblDG_REF"
        Me.lblDG_REF.Size = New System.Drawing.Size(56, 13)
        Me.lblDG_REF.TabIndex = 8
        Me.lblDG_REF.Text = "DG_REF :"
        '
        'lblETA1
        '
        Me.lblETA1.AutoSize = True
        Me.lblETA1.Location = New System.Drawing.Point(72, 306)
        Me.lblETA1.Name = "lblETA1"
        Me.lblETA1.Size = New System.Drawing.Size(40, 13)
        Me.lblETA1.TabIndex = 9
        Me.lblETA1.Text = "ETA1 :"
        '
        'lblPOL
        '
        Me.lblPOL.AutoSize = True
        Me.lblPOL.Location = New System.Drawing.Point(77, 383)
        Me.lblPOL.Name = "lblPOL"
        Me.lblPOL.Size = New System.Drawing.Size(34, 13)
        Me.lblPOL.TabIndex = 10
        Me.lblPOL.Text = "POL :"
        '
        'lblOPL
        '
        Me.lblOPL.AutoSize = True
        Me.lblOPL.Location = New System.Drawing.Point(326, 383)
        Me.lblOPL.Name = "lblOPL"
        Me.lblOPL.Size = New System.Drawing.Size(34, 13)
        Me.lblOPL.TabIndex = 11
        Me.lblOPL.Text = "OPL :"
        '
        'lblPOD
        '
        Me.lblPOD.AutoSize = True
        Me.lblPOD.Location = New System.Drawing.Point(325, 309)
        Me.lblPOD.Name = "lblPOD"
        Me.lblPOD.Size = New System.Drawing.Size(36, 13)
        Me.lblPOD.TabIndex = 12
        Me.lblPOD.Text = "POD :"
        '
        'lblOPD
        '
        Me.lblOPD.AutoSize = True
        Me.lblOPD.Location = New System.Drawing.Point(320, 358)
        Me.lblOPD.Name = "lblOPD"
        Me.lblOPD.Size = New System.Drawing.Size(42, 13)
        Me.lblOPD.TabIndex = 13
        Me.lblOPD.Text = "DEST :"
        '
        'lblCarrier
        '
        Me.lblCarrier.AutoSize = True
        Me.lblCarrier.Location = New System.Drawing.Point(69, 281)
        Me.lblCarrier.Name = "lblCarrier"
        Me.lblCarrier.Size = New System.Drawing.Size(43, 13)
        Me.lblCarrier.TabIndex = 14
        Me.lblCarrier.Text = "Carrier :"
        '
        'txtF_E
        '
        Me.txtF_E.BackColor = System.Drawing.Color.White
        Me.txtF_E.Location = New System.Drawing.Point(323, 226)
        Me.txtF_E.Name = "txtF_E"
        Me.txtF_E.ReadOnly = True
        Me.txtF_E.Size = New System.Drawing.Size(74, 20)
        Me.txtF_E.TabIndex = 15
        '
        'txtSize
        '
        Me.txtSize.BackColor = System.Drawing.Color.White
        Me.txtSize.Location = New System.Drawing.Point(323, 200)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.ReadOnly = True
        Me.txtSize.Size = New System.Drawing.Size(74, 20)
        Me.txtSize.TabIndex = 17
        '
        'txtBL_NO
        '
        Me.txtBL_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBL_NO.Location = New System.Drawing.Point(52, 199)
        Me.txtBL_NO.Name = "txtBL_NO"
        Me.txtBL_NO.Size = New System.Drawing.Size(135, 20)
        Me.txtBL_NO.TabIndex = 18
        '
        'txtWeight
        '
        Me.txtWeight.BackColor = System.Drawing.Color.White
        Me.txtWeight.Location = New System.Drawing.Point(470, 228)
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.ReadOnly = True
        Me.txtWeight.Size = New System.Drawing.Size(79, 20)
        Me.txtWeight.TabIndex = 19
        '
        'txtOPR
        '
        Me.txtOPR.BackColor = System.Drawing.Color.White
        Me.txtOPR.Location = New System.Drawing.Point(363, 332)
        Me.txtOPR.Name = "txtOPR"
        Me.txtOPR.ReadOnly = True
        Me.txtOPR.Size = New System.Drawing.Size(186, 20)
        Me.txtOPR.TabIndex = 20
        '
        'txtCarrier
        '
        Me.txtCarrier.BackColor = System.Drawing.Color.White
        Me.txtCarrier.Location = New System.Drawing.Point(112, 280)
        Me.txtCarrier.Name = "txtCarrier"
        Me.txtCarrier.ReadOnly = True
        Me.txtCarrier.Size = New System.Drawing.Size(167, 20)
        Me.txtCarrier.TabIndex = 26
        '
        'txtDG_REF
        '
        Me.txtDG_REF.BackColor = System.Drawing.Color.White
        Me.txtDG_REF.Location = New System.Drawing.Point(470, 203)
        Me.txtDG_REF.Name = "txtDG_REF"
        Me.txtDG_REF.ReadOnly = True
        Me.txtDG_REF.Size = New System.Drawing.Size(79, 20)
        Me.txtDG_REF.TabIndex = 27
        '
        'cboVessel
        '
        Me.cboVessel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(7, 45)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(181, 21)
        Me.cboVessel.TabIndex = 32
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 13)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Vessel Name :"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Excel Files (*.xls)|*.xls|Text Files(*.txt)|*.txt"
        '
        'lbBillNo
        '
        Me.lbBillNo.FormattingEnabled = True
        Me.lbBillNo.Location = New System.Drawing.Point(10, 72)
        Me.lbBillNo.Name = "lbBillNo"
        Me.lbBillNo.Size = New System.Drawing.Size(177, 121)
        Me.lbBillNo.TabIndex = 37
        '
        'dgdBookingData
        '
        Me.dgdBookingData.AllowUserToAddRows = False
        Me.dgdBookingData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdBookingData.BackgroundColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgdBookingData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBookingData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BooKingDataID, Me.BL_NO, Me.ContainerNo, Me.F_E, Me.CTN_SIZE, Me.Weight, Me.OPR, Me.POL, Me.OPL, Me.DEST, Me.POD, Me.DG_REF, Me.Carrier, Me.ETA, Me.ETD1, Me.VesselName, Me.VoyAge, Me.ETA2, Me.Vessel2, Me.Service, Me.continued, Me.Editable, Me.Approve, Me.UserID, Me.UpdateTime})
        Me.dgdBookingData.GridColor = System.Drawing.SystemColors.ButtonShadow
        Me.dgdBookingData.Location = New System.Drawing.Point(193, 45)
        Me.dgdBookingData.Name = "dgdBookingData"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle23.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdBookingData.RowHeadersDefaultCellStyle = DataGridViewCellStyle23
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle24.ForeColor = System.Drawing.Color.White
        Me.dgdBookingData.RowsDefaultCellStyle = DataGridViewCellStyle24
        Me.dgdBookingData.Size = New System.Drawing.Size(382, 148)
        Me.dgdBookingData.TabIndex = 38
        '
        'txtContainer_No
        '
        Me.txtContainer_No.BackColor = System.Drawing.Color.White
        Me.txtContainer_No.Location = New System.Drawing.Point(112, 254)
        Me.txtContainer_No.Name = "txtContainer_No"
        Me.txtContainer_No.ReadOnly = True
        Me.txtContainer_No.Size = New System.Drawing.Size(167, 20)
        Me.txtContainer_No.TabIndex = 18
        '
        'txtETA1
        '
        Me.txtETA1.BackColor = System.Drawing.Color.White
        Me.txtETA1.Location = New System.Drawing.Point(112, 306)
        Me.txtETA1.Name = "txtETA1"
        Me.txtETA1.ReadOnly = True
        Me.txtETA1.Size = New System.Drawing.Size(167, 20)
        Me.txtETA1.TabIndex = 20
        '
        'txtPOD
        '
        Me.txtPOD.BackColor = System.Drawing.Color.White
        Me.txtPOD.Location = New System.Drawing.Point(363, 306)
        Me.txtPOD.Name = "txtPOD"
        Me.txtPOD.ReadOnly = True
        Me.txtPOD.Size = New System.Drawing.Size(186, 20)
        Me.txtPOD.TabIndex = 15
        '
        'txtPOL
        '
        Me.txtPOL.BackColor = System.Drawing.Color.White
        Me.txtPOL.Location = New System.Drawing.Point(112, 380)
        Me.txtPOL.Name = "txtPOL"
        Me.txtPOL.ReadOnly = True
        Me.txtPOL.Size = New System.Drawing.Size(167, 20)
        Me.txtPOL.TabIndex = 19
        '
        'txtOPD
        '
        Me.txtOPD.BackColor = System.Drawing.Color.White
        Me.txtOPD.Location = New System.Drawing.Point(363, 355)
        Me.txtOPD.Name = "txtOPD"
        Me.txtOPD.ReadOnly = True
        Me.txtOPD.Size = New System.Drawing.Size(186, 20)
        Me.txtOPD.TabIndex = 20
        '
        'txtOPL
        '
        Me.txtOPL.BackColor = System.Drawing.Color.White
        Me.txtOPL.Location = New System.Drawing.Point(363, 380)
        Me.txtOPL.Name = "txtOPL"
        Me.txtOPL.ReadOnly = True
        Me.txtOPL.Size = New System.Drawing.Size(186, 20)
        Me.txtOPL.TabIndex = 27
        '
        'lblETA2
        '
        Me.lblETA2.AutoSize = True
        Me.lblETA2.Location = New System.Drawing.Point(72, 358)
        Me.lblETA2.Name = "lblETA2"
        Me.lblETA2.Size = New System.Drawing.Size(40, 13)
        Me.lblETA2.TabIndex = 9
        Me.lblETA2.Text = "ETA2 :"
        '
        'txtETA2
        '
        Me.txtETA2.BackColor = System.Drawing.Color.White
        Me.txtETA2.Location = New System.Drawing.Point(112, 355)
        Me.txtETA2.Name = "txtETA2"
        Me.txtETA2.ReadOnly = True
        Me.txtETA2.Size = New System.Drawing.Size(167, 20)
        Me.txtETA2.TabIndex = 20
        '
        'lblVessel2
        '
        Me.lblVessel2.AutoSize = True
        Me.lblVessel2.Location = New System.Drawing.Point(27, 335)
        Me.lblVessel2.Name = "lblVessel2"
        Me.lblVessel2.Size = New System.Drawing.Size(84, 13)
        Me.lblVessel2.TabIndex = 6
        Me.lblVessel2.Text = "Second Vessel :"
        '
        'txtvessel2
        '
        Me.txtvessel2.BackColor = System.Drawing.Color.White
        Me.txtvessel2.Location = New System.Drawing.Point(112, 332)
        Me.txtvessel2.Name = "txtvessel2"
        Me.txtvessel2.ReadOnly = True
        Me.txtvessel2.Size = New System.Drawing.Size(167, 20)
        Me.txtvessel2.TabIndex = 19
        '
        'lblETD
        '
        Me.lblETD.AutoSize = True
        Me.lblETD.Location = New System.Drawing.Point(325, 283)
        Me.lblETD.Name = "lblETD"
        Me.lblETD.Size = New System.Drawing.Size(35, 13)
        Me.lblETD.TabIndex = 12
        Me.lblETD.Text = "ETD :"
        '
        'txtETD
        '
        Me.txtETD.BackColor = System.Drawing.Color.White
        Me.txtETD.Location = New System.Drawing.Point(363, 280)
        Me.txtETD.Name = "txtETD"
        Me.txtETD.ReadOnly = True
        Me.txtETD.Size = New System.Drawing.Size(186, 20)
        Me.txtETD.TabIndex = 15
        '
        'lblService
        '
        Me.lblService.AutoSize = True
        Me.lblService.Location = New System.Drawing.Point(312, 257)
        Me.lblService.Name = "lblService"
        Me.lblService.Size = New System.Drawing.Size(49, 13)
        Me.lblService.TabIndex = 12
        Me.lblService.Text = "Service :"
        '
        'txtService
        '
        Me.txtService.BackColor = System.Drawing.Color.White
        Me.txtService.Location = New System.Drawing.Point(363, 254)
        Me.txtService.Name = "txtService"
        Me.txtService.ReadOnly = True
        Me.txtService.Size = New System.Drawing.Size(186, 20)
        Me.txtService.TabIndex = 15
        '
        'cmdFind
        '
        Me.cmdFind.Location = New System.Drawing.Point(193, 198)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(75, 23)
        Me.cmdFind.TabIndex = 39
        Me.cmdFind.Text = "&Find"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'mnuExit
        '
        Me.mnuExit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuImport, Me.smnuExportExcel, Me.RefreshToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.mnuExit.Location = New System.Drawing.Point(0, 0)
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(595, 24)
        Me.mnuExit.TabIndex = 40
        Me.mnuExit.Text = "MenuStrip1"
        '
        'mnuImport
        '
        Me.mnuImport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.mnuImport.Name = "mnuImport"
        Me.mnuImport.Size = New System.Drawing.Size(51, 20)
        Me.mnuImport.Text = "&Import"
        '
        'smnuExportExcel
        '
        Me.smnuExportExcel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.smnuExportExcel.Name = "smnuExportExcel"
        Me.smnuExportExcel.Size = New System.Drawing.Size(79, 20)
        Me.smnuExportExcel.Text = "Export Excel"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.prbExport)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(148, 113)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 89)
        Me.GroupBox1.TabIndex = 287
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Please wait"
        Me.GroupBox1.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(292, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "X"
        Me.ToolTip1.SetToolTip(Me.Label1, "Close")
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(142, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "00%"
        '
        'prbExport
        '
        Me.prbExport.Location = New System.Drawing.Point(18, 34)
        Me.prbExport.Name = "prbExport"
        Me.prbExport.Size = New System.Drawing.Size(280, 20)
        Me.prbExport.TabIndex = 0
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'BooKingDataID
        '
        Me.BooKingDataID.DataPropertyName = "BookingDataID"
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle22.ForeColor = System.Drawing.Color.White
        Me.BooKingDataID.DefaultCellStyle = DataGridViewCellStyle22
        Me.BooKingDataID.HeaderText = "BooKingData ID"
        Me.BooKingDataID.Name = "BooKingDataID"
        Me.BooKingDataID.Visible = False
        '
        'BL_NO
        '
        Me.BL_NO.DataPropertyName = "BL_NO"
        Me.BL_NO.HeaderText = "BL_NO"
        Me.BL_NO.Name = "BL_NO"
        '
        'ContainerNo
        '
        Me.ContainerNo.DataPropertyName = "Container_No"
        Me.ContainerNo.HeaderText = "Container No."
        Me.ContainerNo.Name = "ContainerNo"
        '
        'F_E
        '
        Me.F_E.DataPropertyName = "F_E"
        Me.F_E.HeaderText = "F_E"
        Me.F_E.Name = "F_E"
        '
        'CTN_SIZE
        '
        Me.CTN_SIZE.DataPropertyName = "CTN_ZISE"
        Me.CTN_SIZE.HeaderText = "Container Size"
        Me.CTN_SIZE.Name = "CTN_SIZE"
        '
        'Weight
        '
        Me.Weight.DataPropertyName = "Weight"
        Me.Weight.HeaderText = "Weight"
        Me.Weight.Name = "Weight"
        '
        'OPR
        '
        Me.OPR.DataPropertyName = "OPR"
        Me.OPR.HeaderText = "OPR"
        Me.OPR.Name = "OPR"
        '
        'POL
        '
        Me.POL.DataPropertyName = "POL"
        Me.POL.HeaderText = "POL"
        Me.POL.Name = "POL"
        '
        'OPL
        '
        Me.OPL.DataPropertyName = "OPL"
        Me.OPL.HeaderText = "OPL"
        Me.OPL.Name = "OPL"
        '
        'DEST
        '
        Me.DEST.DataPropertyName = "DEST"
        Me.DEST.HeaderText = "DEST"
        Me.DEST.Name = "DEST"
        '
        'POD
        '
        Me.POD.DataPropertyName = "POD"
        Me.POD.HeaderText = "POD"
        Me.POD.Name = "POD"
        '
        'DG_REF
        '
        Me.DG_REF.DataPropertyName = "DG_REF"
        Me.DG_REF.HeaderText = "DG_REF"
        Me.DG_REF.Name = "DG_REF"
        '
        'Carrier
        '
        Me.Carrier.DataPropertyName = "Carrier"
        Me.Carrier.HeaderText = "Carrier"
        Me.Carrier.Name = "Carrier"
        '
        'ETA
        '
        Me.ETA.DataPropertyName = "ETA1"
        Me.ETA.HeaderText = "ETA"
        Me.ETA.Name = "ETA"
        '
        'ETD1
        '
        Me.ETD1.DataPropertyName = "ETD"
        Me.ETD1.HeaderText = "ETD 2"
        Me.ETD1.Name = "ETD1"
        '
        'VesselName
        '
        Me.VesselName.DataPropertyName = "Vessel"
        Me.VesselName.HeaderText = "Vessel 2"
        Me.VesselName.Name = "VesselName"
        '
        'VoyAge
        '
        Me.VoyAge.DataPropertyName = "Voyage"
        Me.VoyAge.HeaderText = "VoyAge 2"
        Me.VoyAge.Name = "VoyAge"
        '
        'ETA2
        '
        Me.ETA2.DataPropertyName = "ETA2"
        Me.ETA2.HeaderText = "ETA"
        Me.ETA2.Name = "ETA2"
        Me.ETA2.Visible = False
        '
        'Vessel2
        '
        Me.Vessel2.DataPropertyName = "Vessel2"
        Me.Vessel2.HeaderText = "Vessel"
        Me.Vessel2.Name = "Vessel2"
        Me.Vessel2.Visible = False
        '
        'Service
        '
        Me.Service.DataPropertyName = "Service"
        Me.Service.HeaderText = "Service"
        Me.Service.Name = "Service"
        Me.Service.Visible = False
        '
        'continued
        '
        Me.continued.DataPropertyName = "continued"
        Me.continued.HeaderText = "continued"
        Me.continued.Name = "continued"
        Me.continued.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.continued.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.continued.Visible = False
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
        Me.Approve.Visible = False
        '
        'UserID
        '
        Me.UserID.DataPropertyName = "UserID"
        Me.UserID.HeaderText = "UserID"
        Me.UserID.Name = "UserID"
        '
        'UpdateTime
        '
        Me.UpdateTime.DataPropertyName = "UpdateTime"
        Me.UpdateTime.HeaderText = "UpdateTime"
        Me.UpdateTime.Name = "UpdateTime"
        '
        'frmListBooKingData
        '
        Me.AcceptButton = Me.cmdFind
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(595, 416)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdFind)
        Me.Controls.Add(Me.dgdBookingData)
        Me.Controls.Add(Me.lbBillNo)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.txtOPL)
        Me.Controls.Add(Me.txtDG_REF)
        Me.Controls.Add(Me.txtCarrier)
        Me.Controls.Add(Me.txtETA2)
        Me.Controls.Add(Me.txtETA1)
        Me.Controls.Add(Me.txtOPD)
        Me.Controls.Add(Me.txtOPR)
        Me.Controls.Add(Me.txtPOL)
        Me.Controls.Add(Me.txtvessel2)
        Me.Controls.Add(Me.txtWeight)
        Me.Controls.Add(Me.txtContainer_No)
        Me.Controls.Add(Me.txtBL_NO)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.txtService)
        Me.Controls.Add(Me.txtETD)
        Me.Controls.Add(Me.txtPOD)
        Me.Controls.Add(Me.txtF_E)
        Me.Controls.Add(Me.lblService)
        Me.Controls.Add(Me.lblCarrier)
        Me.Controls.Add(Me.lblETD)
        Me.Controls.Add(Me.lblOPD)
        Me.Controls.Add(Me.lblPOD)
        Me.Controls.Add(Me.lblOPL)
        Me.Controls.Add(Me.lblETA2)
        Me.Controls.Add(Me.lblPOL)
        Me.Controls.Add(Me.lblETA1)
        Me.Controls.Add(Me.lblDG_REF)
        Me.Controls.Add(Me.lblVessel2)
        Me.Controls.Add(Me.lblOPR)
        Me.Controls.Add(Me.lblWeight)
        Me.Controls.Add(Me.lblSIZE)
        Me.Controls.Add(Me.lblF_E)
        Me.Controls.Add(Me.lblBL_NO)
        Me.Controls.Add(Me.lblcontainer_no)
        Me.Controls.Add(Me.mnuExit)
        Me.ForeColor = System.Drawing.Color.Blue
        Me.MainMenuStrip = Me.mnuExit
        Me.MaximizeBox = False
        Me.Name = "frmListBooKingData"
        Me.Text = "Connecting Vessel"
        CType(Me.dgdBookingData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuExit.ResumeLayout(False)
        Me.mnuExit.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblcontainer_no As System.Windows.Forms.Label
    Friend WithEvents lblBL_NO As System.Windows.Forms.Label
    Friend WithEvents lblF_E As System.Windows.Forms.Label
    Friend WithEvents lblSIZE As System.Windows.Forms.Label
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents lblOPR As System.Windows.Forms.Label
    Friend WithEvents lblDG_REF As System.Windows.Forms.Label
    Friend WithEvents lblETA1 As System.Windows.Forms.Label
    Friend WithEvents lblPOL As System.Windows.Forms.Label
    Friend WithEvents lblOPL As System.Windows.Forms.Label
    Friend WithEvents lblPOD As System.Windows.Forms.Label
    Friend WithEvents lblOPD As System.Windows.Forms.Label
    Friend WithEvents lblCarrier As System.Windows.Forms.Label
    Friend WithEvents txtF_E As System.Windows.Forms.TextBox
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents txtBL_NO As System.Windows.Forms.TextBox
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents txtOPR As System.Windows.Forms.TextBox
    Friend WithEvents txtCarrier As System.Windows.Forms.TextBox
    Friend WithEvents txtDG_REF As System.Windows.Forms.TextBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lbBillNo As System.Windows.Forms.ListBox
    Friend WithEvents dgdBookingData As System.Windows.Forms.DataGridView
    Friend WithEvents txtContainer_No As System.Windows.Forms.TextBox
    Friend WithEvents txtETA1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPOD As System.Windows.Forms.TextBox
    Friend WithEvents txtPOL As System.Windows.Forms.TextBox
    Friend WithEvents txtOPD As System.Windows.Forms.TextBox
    Friend WithEvents txtOPL As System.Windows.Forms.TextBox
    Friend WithEvents lblETA2 As System.Windows.Forms.Label
    Friend WithEvents txtETA2 As System.Windows.Forms.TextBox
    Friend WithEvents lblVessel2 As System.Windows.Forms.Label
    Friend WithEvents txtvessel2 As System.Windows.Forms.TextBox
    Friend WithEvents lblETD As System.Windows.Forms.Label
    Friend WithEvents txtETD As System.Windows.Forms.TextBox
    Friend WithEvents lblService As System.Windows.Forms.Label
    Friend WithEvents txtService As System.Windows.Forms.TextBox
    Friend WithEvents cmdFind As System.Windows.Forms.Button
    Friend WithEvents mnuExit As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents smnuExportExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents prbExport As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BooKingDataID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents F_E As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_SIZE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Weight As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OPL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEST As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POD As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DG_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Carrier As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETD1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VesselName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ETA2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Service As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents continued As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Editable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Approve As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents UserID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
