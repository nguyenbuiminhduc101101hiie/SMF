<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCSCLBooking
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.fraInfo = New System.Windows.Forms.GroupBox
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.dtpETA = New System.Windows.Forms.DateTimePicker
        Me.txtLine = New System.Windows.Forms.TextBox
        Me.txtPOD = New System.Windows.Forms.TextBox
        Me.txtPOL = New System.Windows.Forms.TextBox
        Me.txtTS = New System.Windows.Forms.TextBox
        Me.txtVelOper = New System.Windows.Forms.TextBox
        Me.cboTML = New System.Windows.Forms.ComboBox
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.fraInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(751, 319)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        Me.CrystalReportViewer1.Visible = False
        '
        'fraInfo
        '
        Me.fraInfo.BackColor = System.Drawing.Color.PowderBlue
        Me.fraInfo.Controls.Add(Me.cmdCancel)
        Me.fraInfo.Controls.Add(Me.cmdOk)
        Me.fraInfo.Controls.Add(Me.dtpETA)
        Me.fraInfo.Controls.Add(Me.txtLine)
        Me.fraInfo.Controls.Add(Me.txtPOD)
        Me.fraInfo.Controls.Add(Me.txtPOL)
        Me.fraInfo.Controls.Add(Me.txtTS)
        Me.fraInfo.Controls.Add(Me.txtVelOper)
        Me.fraInfo.Controls.Add(Me.cboTML)
        Me.fraInfo.Controls.Add(Me.cboVessel)
        Me.fraInfo.Controls.Add(Me.Label5)
        Me.fraInfo.Controls.Add(Me.Label4)
        Me.fraInfo.Controls.Add(Me.Label3)
        Me.fraInfo.Controls.Add(Me.Label7)
        Me.fraInfo.Controls.Add(Me.Label8)
        Me.fraInfo.Controls.Add(Me.Label6)
        Me.fraInfo.Controls.Add(Me.Label2)
        Me.fraInfo.Controls.Add(Me.Label1)
        Me.fraInfo.ForeColor = System.Drawing.Color.DarkGreen
        Me.fraInfo.Location = New System.Drawing.Point(0, 30)
        Me.fraInfo.Name = "fraInfo"
        Me.fraInfo.Size = New System.Drawing.Size(619, 184)
        Me.fraInfo.TabIndex = 0
        Me.fraInfo.TabStop = False
        Me.fraInfo.Text = "Container Booking Info"
        '
        'cmdCancel
        '
        Me.cmdCancel.BackColor = System.Drawing.Color.LightPink
        Me.cmdCancel.Location = New System.Drawing.Point(449, 150)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 9
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = False
        '
        'cmdOk
        '
        Me.cmdOk.BackColor = System.Drawing.Color.LightPink
        Me.cmdOk.Location = New System.Drawing.Point(530, 150)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 8
        Me.cmdOk.Text = "&OK"
        Me.cmdOk.UseVisualStyleBackColor = False
        '
        'dtpETA
        '
        Me.dtpETA.Location = New System.Drawing.Point(417, 110)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(188, 20)
        Me.dtpETA.TabIndex = 7
        '
        'txtLine
        '
        Me.txtLine.Location = New System.Drawing.Point(83, 84)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(190, 20)
        Me.txtLine.TabIndex = 2
        '
        'txtPOD
        '
        Me.txtPOD.Location = New System.Drawing.Point(417, 58)
        Me.txtPOD.Name = "txtPOD"
        Me.txtPOD.Size = New System.Drawing.Size(188, 20)
        Me.txtPOD.TabIndex = 5
        '
        'txtPOL
        '
        Me.txtPOL.Location = New System.Drawing.Point(417, 32)
        Me.txtPOL.Name = "txtPOL"
        Me.txtPOL.Size = New System.Drawing.Size(188, 20)
        Me.txtPOL.TabIndex = 4
        '
        'txtTS
        '
        Me.txtTS.Location = New System.Drawing.Point(83, 111)
        Me.txtTS.Name = "txtTS"
        Me.txtTS.Size = New System.Drawing.Size(190, 20)
        Me.txtTS.TabIndex = 3
        '
        'txtVelOper
        '
        Me.txtVelOper.Location = New System.Drawing.Point(417, 84)
        Me.txtVelOper.Name = "txtVelOper"
        Me.txtVelOper.Size = New System.Drawing.Size(188, 20)
        Me.txtVelOper.TabIndex = 6
        '
        'cboTML
        '
        Me.cboTML.FormattingEnabled = True
        Me.cboTML.Items.AddRange(New Object() {"CAT LAT PORT", "NEW PORT", "ICD SONG THAN", "ICD PHUOC LONG", "PHUONG LONG DEPOT", "KHANH HOI PORT", "ICD TRANSIMEX", "ICD BIEN HOA", "..."})
        Me.cboTML.Location = New System.Drawing.Point(83, 57)
        Me.cboTML.Name = "cboTML"
        Me.cboTML.Size = New System.Drawing.Size(190, 21)
        Me.cboTML.TabIndex = 1
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(83, 29)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(190, 21)
        Me.cboVessel.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 114)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "T/S :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(46, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "TML :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "LINE :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(65, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Vessel-Voy :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(381, 112)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "ETA :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(338, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "VEL Operator :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(379, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "POD :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(381, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POL :"
        '
        'frmRptCSCLBooking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 319)
        Me.Controls.Add(Me.fraInfo)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmRptCSCLBooking"
        Me.Text = "CSCL Report Booking"
        Me.fraInfo.ResumeLayout(False)
        Me.fraInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents fraInfo As System.Windows.Forms.GroupBox
    Friend WithEvents txtLine As System.Windows.Forms.TextBox
    Friend WithEvents txtPOD As System.Windows.Forms.TextBox
    Friend WithEvents txtPOL As System.Windows.Forms.TextBox
    Friend WithEvents txtTS As System.Windows.Forms.TextBox
    Friend WithEvents txtVelOper As System.Windows.Forms.TextBox
    Friend WithEvents cboTML As System.Windows.Forms.ComboBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
