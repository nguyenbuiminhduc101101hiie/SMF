<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInputDataFullContainerIB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInputDataFullContainerIB))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtFilename = New System.Windows.Forms.TextBox
        Me.cmdBroswser = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSheetName = New System.Windows.Forms.TextBox
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtVoyNo = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtpETA = New System.Windows.Forms.DateTimePicker
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.txtShipperName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtConsignee = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNotify = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.CBOicdpORT = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(38, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "File Name :"
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(102, 11)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(374, 20)
        Me.txtFilename.TabIndex = 10
        '
        'cmdBroswser
        '
        Me.cmdBroswser.ForeColor = System.Drawing.Color.Maroon
        Me.cmdBroswser.Location = New System.Drawing.Point(485, 11)
        Me.cmdBroswser.Name = "cmdBroswser"
        Me.cmdBroswser.Size = New System.Drawing.Size(75, 23)
        Me.cmdBroswser.TabIndex = 0
        Me.cmdBroswser.Text = "Browse"
        Me.cmdBroswser.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(26, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Sheet Name :"
        '
        'txtSheetName
        '
        Me.txtSheetName.Location = New System.Drawing.Point(102, 42)
        Me.txtSheetName.Name = "txtSheetName"
        Me.txtSheetName.Size = New System.Drawing.Size(125, 20)
        Me.txtSheetName.TabIndex = 10
        Me.txtSheetName.Text = "Sheet1"
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(99, 68)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(205, 21)
        Me.cboVessel.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Navy
        Me.Label3.Location = New System.Drawing.Point(54, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Vessel :"
        '
        'txtVoyNo
        '
        Me.txtVoyNo.Location = New System.Drawing.Point(360, 68)
        Me.txtVoyNo.Name = "txtVoyNo"
        Me.txtVoyNo.Size = New System.Drawing.Size(116, 20)
        Me.txtVoyNo.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(310, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Voy No :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(64, 98)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "ETA :"
        '
        'dtpETA
        '
        Me.dtpETA.Location = New System.Drawing.Point(99, 98)
        Me.dtpETA.Name = "dtpETA"
        Me.dtpETA.Size = New System.Drawing.Size(205, 20)
        Me.dtpETA.TabIndex = 11
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(479, 211)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 0
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(398, 211)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 0
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'txtShipperName
        '
        Me.txtShipperName.Location = New System.Drawing.Point(99, 134)
        Me.txtShipperName.MaxLength = 35
        Me.txtShipperName.Name = "txtShipperName"
        Me.txtShipperName.Size = New System.Drawing.Size(377, 20)
        Me.txtShipperName.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(18, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Shipper Name :"
        '
        'txtConsignee
        '
        Me.txtConsignee.Location = New System.Drawing.Point(99, 159)
        Me.txtConsignee.MaxLength = 35
        Me.txtConsignee.Name = "txtConsignee"
        Me.txtConsignee.Size = New System.Drawing.Size(377, 20)
        Me.txtConsignee.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(4, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Consignee Name :"
        '
        'txtNotify
        '
        Me.txtNotify.Location = New System.Drawing.Point(99, 185)
        Me.txtNotify.MaxLength = 35
        Me.txtNotify.Name = "txtNotify"
        Me.txtNotify.Size = New System.Drawing.Size(377, 20)
        Me.txtNotify.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(27, 186)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Notify Name :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(482, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Review (.XLS)"
        Me.ToolTip1.SetToolTip(Me.Label9, resources.GetString("Label9.ToolTip"))
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 5000000
        Me.ToolTip1.AutoPopDelay = 5000000
        Me.ToolTip1.InitialDelay = 50
        Me.ToolTip1.ReshowDelay = 50
        '
        'CBOicdpORT
        '
        Me.CBOicdpORT.FormattingEnabled = True
        Me.CBOicdpORT.Items.AddRange(New Object() {"CAT LAI", "NEW PORT", "ICD SONH THAN", "ICD PHUOC LONG", "ICD TRANSIMEX", "ICD BIEN HOA ", "PHUC LONG DEPOT", "KHANH HOI PORT", "Z1", "VINATRAN", "SADACO", "LINH XUAN"})
        Me.CBOicdpORT.Location = New System.Drawing.Point(360, 97)
        Me.CBOicdpORT.Name = "CBOicdpORT"
        Me.CBOicdpORT.Size = New System.Drawing.Size(116, 21)
        Me.CBOicdpORT.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(306, 100)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "ICD Port :"
        '
        'frmInputDataFullContainerIB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 238)
        Me.Controls.Add(Me.CBOicdpORT)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.dtpETA)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.txtNotify)
        Me.Controls.Add(Me.txtConsignee)
        Me.Controls.Add(Me.txtShipperName)
        Me.Controls.Add(Me.txtSheetName)
        Me.Controls.Add(Me.txtVoyNo)
        Me.Controls.Add(Me.cmdBroswser)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "frmInputDataFullContainerIB"
        Me.Text = "Input Data From Excel List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFilename As System.Windows.Forms.TextBox
    Friend WithEvents cmdBroswser As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSheetName As System.Windows.Forms.TextBox
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtVoyNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpETA As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtShipperName As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtConsignee As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNotify As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents CBOicdpORT As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
