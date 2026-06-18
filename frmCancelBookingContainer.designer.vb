<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancelBookingContainer
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
        Me.dgdLoadingPlanData = New System.Windows.Forms.DataGridView
        Me.ContainerOutboundNotifyID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LOADINGPLANFORVESSELID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cancel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grpBookingContainerInfo = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtSoLuong40RH = New System.Windows.Forms.TextBox
        Me.txtSoLuong45HC = New System.Windows.Forms.TextBox
        Me.txtSoLuong40RF = New System.Windows.Forms.TextBox
        Me.txtSoLuong20RF = New System.Windows.Forms.TextBox
        Me.txtSoLuong40HC = New System.Windows.Forms.TextBox
        Me.txtSoLuong40GP = New System.Windows.Forms.TextBox
        Me.txtSoLuong20GP = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtSoLuong40FR = New System.Windows.Forms.TextBox
        Me.txtSoLuong20FR = New System.Windows.Forms.TextBox
        Me.txtSoLuong40OT = New System.Windows.Forms.TextBox
        Me.txtSoLuong20OT = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        CType(Me.dgdLoadingPlanData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBookingContainerInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgdLoadingPlanData
        '
        Me.dgdLoadingPlanData.AllowUserToAddRows = False
        Me.dgdLoadingPlanData.AllowUserToDeleteRows = False
        Me.dgdLoadingPlanData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdLoadingPlanData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdLoadingPlanData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ContainerOutboundNotifyID, Me.LOADINGPLANFORVESSELID, Me.BookingNo, Me.ContainerNo, Me.Container_Type, Me.Cancel})
        Me.dgdLoadingPlanData.Location = New System.Drawing.Point(0, 0)
        Me.dgdLoadingPlanData.Name = "dgdLoadingPlanData"
        Me.dgdLoadingPlanData.ReadOnly = True
        Me.dgdLoadingPlanData.Size = New System.Drawing.Size(633, 337)
        Me.dgdLoadingPlanData.TabIndex = 0
        '
        'ContainerOutboundNotifyID
        '
        Me.ContainerOutboundNotifyID.DataPropertyName = "ContainerOutboundNotifyID"
        Me.ContainerOutboundNotifyID.HeaderText = "ContainerOutboundNotifyID"
        Me.ContainerOutboundNotifyID.Name = "ContainerOutboundNotifyID"
        Me.ContainerOutboundNotifyID.ReadOnly = True
        Me.ContainerOutboundNotifyID.Visible = False
        '
        'LOADINGPLANFORVESSELID
        '
        Me.LOADINGPLANFORVESSELID.DataPropertyName = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.HeaderText = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.Name = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.ReadOnly = True
        Me.LOADINGPLANFORVESSELID.Visible = False
        '
        'BookingNo
        '
        Me.BookingNo.DataPropertyName = "BookingNo"
        Me.BookingNo.HeaderText = "Booking No."
        Me.BookingNo.Name = "BookingNo"
        Me.BookingNo.ReadOnly = True
        '
        'ContainerNo
        '
        Me.ContainerNo.DataPropertyName = "ContainerNo"
        Me.ContainerNo.HeaderText = "Container No."
        Me.ContainerNo.Name = "ContainerNo"
        Me.ContainerNo.ReadOnly = True
        '
        'Container_Type
        '
        Me.Container_Type.DataPropertyName = "Container_Type"
        Me.Container_Type.HeaderText = "Container Type"
        Me.Container_Type.Name = "Container_Type"
        Me.Container_Type.ReadOnly = True
        '
        'Cancel
        '
        Me.Cancel.DataPropertyName = "Cancel"
        Me.Cancel.HeaderText = "Cancel"
        Me.Cancel.Name = "Cancel"
        Me.Cancel.ReadOnly = True
        Me.Cancel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Cancel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'cmdOk
        '
        Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdOk.Location = New System.Drawing.Point(558, 411)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 1
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(558, 447)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'grpBookingContainerInfo
        '
        Me.grpBookingContainerInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label13)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label9)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label10)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label11)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label12)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong40FR)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong20FR)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong40OT)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong20OT)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label8)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label7)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label6)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label5)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label4)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label3)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label2)
        Me.grpBookingContainerInfo.Controls.Add(Me.Label1)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong40RH)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong45HC)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong40RF)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong20RF)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong40HC)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong40GP)
        Me.grpBookingContainerInfo.Controls.Add(Me.txtSoLuong20GP)
        Me.grpBookingContainerInfo.Location = New System.Drawing.Point(0, 343)
        Me.grpBookingContainerInfo.Name = "grpBookingContainerInfo"
        Me.grpBookingContainerInfo.Size = New System.Drawing.Size(548, 135)
        Me.grpBookingContainerInfo.TabIndex = 2
        Me.grpBookingContainerInfo.TabStop = False
        Me.grpBookingContainerInfo.Text = "Booking Container Info"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ForeColor = System.Drawing.Color.Blue
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(493, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "40RH"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ForeColor = System.Drawing.Color.Blue
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(420, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 13)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "40RF"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Blue
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(345, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "20RF"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(277, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 13)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "45HC"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(199, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "40HC"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(132, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "40GP"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(60, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "20GP"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Quantity :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSoLuong40RH
        '
        Me.txtSoLuong40RH.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong40RH.Location = New System.Drawing.Point(488, 37)
        Me.txtSoLuong40RH.Name = "txtSoLuong40RH"
        Me.txtSoLuong40RH.Size = New System.Drawing.Size(51, 20)
        Me.txtSoLuong40RH.TabIndex = 121
        Me.txtSoLuong40RH.Text = "0"
        Me.txtSoLuong40RH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong45HC
        '
        Me.txtSoLuong45HC.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong45HC.Location = New System.Drawing.Point(272, 38)
        Me.txtSoLuong45HC.Name = "txtSoLuong45HC"
        Me.txtSoLuong45HC.Size = New System.Drawing.Size(49, 20)
        Me.txtSoLuong45HC.TabIndex = 118
        Me.txtSoLuong45HC.Text = "0"
        Me.txtSoLuong45HC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong40RF
        '
        Me.txtSoLuong40RF.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong40RF.Location = New System.Drawing.Point(413, 38)
        Me.txtSoLuong40RF.Name = "txtSoLuong40RF"
        Me.txtSoLuong40RF.Size = New System.Drawing.Size(53, 20)
        Me.txtSoLuong40RF.TabIndex = 120
        Me.txtSoLuong40RF.Text = "0"
        Me.txtSoLuong40RF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong20RF
        '
        Me.txtSoLuong20RF.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong20RF.Location = New System.Drawing.Point(341, 38)
        Me.txtSoLuong20RF.Name = "txtSoLuong20RF"
        Me.txtSoLuong20RF.Size = New System.Drawing.Size(51, 20)
        Me.txtSoLuong20RF.TabIndex = 119
        Me.txtSoLuong20RF.Text = "0"
        Me.txtSoLuong20RF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong40HC
        '
        Me.txtSoLuong40HC.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong40HC.Location = New System.Drawing.Point(196, 38)
        Me.txtSoLuong40HC.Name = "txtSoLuong40HC"
        Me.txtSoLuong40HC.Size = New System.Drawing.Size(47, 20)
        Me.txtSoLuong40HC.TabIndex = 117
        Me.txtSoLuong40HC.Text = "0"
        Me.txtSoLuong40HC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong40GP
        '
        Me.txtSoLuong40GP.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong40GP.Location = New System.Drawing.Point(122, 38)
        Me.txtSoLuong40GP.Name = "txtSoLuong40GP"
        Me.txtSoLuong40GP.Size = New System.Drawing.Size(50, 20)
        Me.txtSoLuong40GP.TabIndex = 116
        Me.txtSoLuong40GP.Text = "0"
        Me.txtSoLuong40GP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong20GP
        '
        Me.txtSoLuong20GP.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong20GP.Location = New System.Drawing.Point(55, 37)
        Me.txtSoLuong20GP.Name = "txtSoLuong20GP"
        Me.txtSoLuong20GP.Size = New System.Drawing.Size(49, 20)
        Me.txtSoLuong20GP.TabIndex = 115
        Me.txtSoLuong20GP.Text = "0"
        Me.txtSoLuong20GP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.ForeColor = System.Drawing.Color.Blue
        Me.Label9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label9.Location = New System.Drawing.Point(277, 71)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "4OFR"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.ForeColor = System.Drawing.Color.Blue
        Me.Label10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label10.Location = New System.Drawing.Point(199, 69)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "20FR"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.ForeColor = System.Drawing.Color.Blue
        Me.Label11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label11.Location = New System.Drawing.Point(132, 69)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(34, 13)
        Me.Label11.TabIndex = 129
        Me.Label11.Text = "40OT"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.ForeColor = System.Drawing.Color.Blue
        Me.Label12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label12.Location = New System.Drawing.Point(60, 69)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 130
        Me.Label12.Text = "20OT"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSoLuong40FR
        '
        Me.txtSoLuong40FR.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong40FR.Location = New System.Drawing.Point(272, 87)
        Me.txtSoLuong40FR.Name = "txtSoLuong40FR"
        Me.txtSoLuong40FR.Size = New System.Drawing.Size(49, 20)
        Me.txtSoLuong40FR.TabIndex = 126
        Me.txtSoLuong40FR.Text = "0"
        Me.txtSoLuong40FR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong20FR
        '
        Me.txtSoLuong20FR.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong20FR.Location = New System.Drawing.Point(196, 87)
        Me.txtSoLuong20FR.Name = "txtSoLuong20FR"
        Me.txtSoLuong20FR.Size = New System.Drawing.Size(47, 20)
        Me.txtSoLuong20FR.TabIndex = 125
        Me.txtSoLuong20FR.Text = "0"
        Me.txtSoLuong20FR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong40OT
        '
        Me.txtSoLuong40OT.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong40OT.Location = New System.Drawing.Point(122, 87)
        Me.txtSoLuong40OT.Name = "txtSoLuong40OT"
        Me.txtSoLuong40OT.Size = New System.Drawing.Size(50, 20)
        Me.txtSoLuong40OT.TabIndex = 124
        Me.txtSoLuong40OT.Text = "0"
        Me.txtSoLuong40OT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSoLuong20OT
        '
        Me.txtSoLuong20OT.ForeColor = System.Drawing.Color.Blue
        Me.txtSoLuong20OT.Location = New System.Drawing.Point(55, 86)
        Me.txtSoLuong20OT.Name = "txtSoLuong20OT"
        Me.txtSoLuong20OT.Size = New System.Drawing.Size(49, 20)
        Me.txtSoLuong20OT.TabIndex = 123
        Me.txtSoLuong20OT.Text = "0"
        Me.txtSoLuong20OT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.ForeColor = System.Drawing.Color.Blue
        Me.Label13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label13.Location = New System.Drawing.Point(0, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 13)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "Quantity :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCancelBookingContainer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 490)
        Me.Controls.Add(Me.grpBookingContainerInfo)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.dgdLoadingPlanData)
        Me.Name = "frmCancelBookingContainer"
        Me.Text = "Booking Cancel (Container)"
        CType(Me.dgdLoadingPlanData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBookingContainerInfo.ResumeLayout(False)
        Me.grpBookingContainerInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgdLoadingPlanData As System.Windows.Forms.DataGridView
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grpBookingContainerInfo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSoLuong40RH As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong45HC As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong40RF As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong20RF As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong40HC As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong40GP As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong20GP As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ContainerOutboundNotifyID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LOADINGPLANFORVESSELID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cancel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSoLuong40FR As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong20FR As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong40OT As System.Windows.Forms.TextBox
    Friend WithEvents txtSoLuong20OT As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
