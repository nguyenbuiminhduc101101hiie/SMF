<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckContainerSale_Maket
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
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.cmdOk = New System.Windows.Forms.Button
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblVessel = New System.Windows.Forms.Label
        Me.dtpLeavingDate = New System.Windows.Forms.DateTimePicker
        Me.dgdBooking = New System.Windows.Forms.DataGridView
        Me.Note = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Vessel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.VoyNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong20GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40GP = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong45HC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong20RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40RF = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SoLuong40RH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdExportExcel = New System.Windows.Forms.Button
        CType(Me.dgdBooking, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdCancel.Location = New System.Drawing.Point(369, 36)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 292
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.ForeColor = System.Drawing.Color.Maroon
        Me.cmdOk.Location = New System.Drawing.Point(447, 36)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 293
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(90, 12)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(270, 21)
        Me.cboVessel.TabIndex = 288
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(52, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 289
        Me.Label1.Text = "ETD :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVessel
        '
        Me.lblVessel.AutoSize = True
        Me.lblVessel.BackColor = System.Drawing.Color.Transparent
        Me.lblVessel.ForeColor = System.Drawing.Color.Blue
        Me.lblVessel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVessel.Location = New System.Drawing.Point(3, 14)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(87, 13)
        Me.lblVessel.TabIndex = 290
        Me.lblVessel.Text = "Vessel / VoyNo :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLeavingDate.Location = New System.Drawing.Point(90, 37)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpLeavingDate.TabIndex = 291
        '
        'dgdBooking
        '
        Me.dgdBooking.AllowUserToAddRows = False
        Me.dgdBooking.AllowUserToDeleteRows = False
        Me.dgdBooking.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBooking.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Note, Me.Vessel, Me.VoyNo, Me.SoLuong20GP, Me.SoLuong40GP, Me.SoLuong40HC, Me.SoLuong45HC, Me.SoLuong20RF, Me.SoLuong40RF, Me.SoLuong40RH})
        Me.dgdBooking.Location = New System.Drawing.Point(12, 69)
        Me.dgdBooking.Name = "dgdBooking"
        Me.dgdBooking.ReadOnly = True
        Me.dgdBooking.RowHeadersWidth = 10
        Me.dgdBooking.Size = New System.Drawing.Size(700, 207)
        Me.dgdBooking.TabIndex = 294
        '
        'Note
        '
        Me.Note.HeaderText = "Note"
        Me.Note.Name = "Note"
        Me.Note.ReadOnly = True
        Me.Note.Width = 150
        '
        'Vessel
        '
        Me.Vessel.HeaderText = "Vessel"
        Me.Vessel.Name = "Vessel"
        Me.Vessel.ReadOnly = True
        '
        'VoyNo
        '
        Me.VoyNo.HeaderText = "VoyNo"
        Me.VoyNo.Name = "VoyNo"
        Me.VoyNo.ReadOnly = True
        Me.VoyNo.Width = 50
        '
        'SoLuong20GP
        '
        Me.SoLuong20GP.DataPropertyName = "20GP"
        Me.SoLuong20GP.HeaderText = "20GP"
        Me.SoLuong20GP.Name = "SoLuong20GP"
        Me.SoLuong20GP.ReadOnly = True
        Me.SoLuong20GP.Width = 40
        '
        'SoLuong40GP
        '
        Me.SoLuong40GP.DataPropertyName = "40GP"
        Me.SoLuong40GP.HeaderText = "40GP"
        Me.SoLuong40GP.Name = "SoLuong40GP"
        Me.SoLuong40GP.ReadOnly = True
        Me.SoLuong40GP.Width = 40
        '
        'SoLuong40HC
        '
        Me.SoLuong40HC.DataPropertyName = "40HC"
        Me.SoLuong40HC.HeaderText = "40HC"
        Me.SoLuong40HC.Name = "SoLuong40HC"
        Me.SoLuong40HC.ReadOnly = True
        Me.SoLuong40HC.Width = 40
        '
        'SoLuong45HC
        '
        Me.SoLuong45HC.DataPropertyName = "45HC"
        Me.SoLuong45HC.HeaderText = "45HC"
        Me.SoLuong45HC.Name = "SoLuong45HC"
        Me.SoLuong45HC.ReadOnly = True
        Me.SoLuong45HC.Width = 40
        '
        'SoLuong20RF
        '
        Me.SoLuong20RF.DataPropertyName = "20RF"
        Me.SoLuong20RF.HeaderText = "20RF"
        Me.SoLuong20RF.Name = "SoLuong20RF"
        Me.SoLuong20RF.ReadOnly = True
        Me.SoLuong20RF.Width = 40
        '
        'SoLuong40RF
        '
        Me.SoLuong40RF.DataPropertyName = "40RF"
        Me.SoLuong40RF.HeaderText = "40RF"
        Me.SoLuong40RF.Name = "SoLuong40RF"
        Me.SoLuong40RF.ReadOnly = True
        Me.SoLuong40RF.Width = 40
        '
        'SoLuong40RH
        '
        Me.SoLuong40RH.DataPropertyName = "40RH"
        Me.SoLuong40RH.HeaderText = "40RH"
        Me.SoLuong40RH.Name = "SoLuong40RH"
        Me.SoLuong40RH.ReadOnly = True
        Me.SoLuong40RH.Width = 40
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.ForeColor = System.Drawing.Color.Maroon
        Me.cmdExportExcel.Location = New System.Drawing.Point(528, 36)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 295
        Me.cmdExportExcel.Text = "Export Excel "
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'frmCheckContainerSale_Maket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 286)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.dgdBooking)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOk)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblVessel)
        Me.Controls.Add(Me.dtpLeavingDate)
        Me.Name = "frmCheckContainerSale_Maket"
        Me.Text = "Containers (Booking - Supply)"
        CType(Me.dgdBooking, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgdBooking As System.Windows.Forms.DataGridView
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents Note As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vessel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents VoyNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong20GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40GP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong45HC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong20RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40RF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SoLuong40RH As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
