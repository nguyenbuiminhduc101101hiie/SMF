<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckPrice
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.dgdData = New System.Windows.Forms.DataGridView
        Me.BL_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreateUser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BookingNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_Type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChargeCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Currency = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrepaidCollect = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgdSurCharge = New System.Windows.Forms.DataGridView
        Me.BookingNoSurcharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_typeSurcharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ChargeCodeSurcharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrencySurCharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PriceSurcharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PrepaidCollectSurcharge = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdSurCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(312, 41)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 292
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOk
        '
        Me.cmdOk.Location = New System.Drawing.Point(396, 41)
        Me.cmdOk.Name = "cmdOk"
        Me.cmdOk.Size = New System.Drawing.Size(75, 23)
        Me.cmdOk.TabIndex = 293
        Me.cmdOk.Text = "&Ok"
        Me.cmdOk.UseVisualStyleBackColor = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(99, 13)
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
        Me.Label1.Location = New System.Drawing.Point(61, 41)
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
        Me.lblVessel.Location = New System.Drawing.Point(12, 15)
        Me.lblVessel.Name = "lblVessel"
        Me.lblVessel.Size = New System.Drawing.Size(87, 13)
        Me.lblVessel.TabIndex = 290
        Me.lblVessel.Text = "Vessel / VoyNo :"
        Me.lblVessel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLeavingDate
        '
        Me.dtpLeavingDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpLeavingDate.Location = New System.Drawing.Point(99, 38)
        Me.dtpLeavingDate.Name = "dtpLeavingDate"
        Me.dtpLeavingDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpLeavingDate.TabIndex = 291
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboVessel)
        Me.GroupBox1.Controls.Add(Me.cmdExportExcel)
        Me.GroupBox1.Controls.Add(Me.cmdCancel)
        Me.GroupBox1.Controls.Add(Me.dtpLeavingDate)
        Me.GroupBox1.Controls.Add(Me.cmdOk)
        Me.GroupBox1.Controls.Add(Me.lblVessel)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(566, 76)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.Location = New System.Drawing.Point(477, 41)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(75, 23)
        Me.cmdExportExcel.TabIndex = 292
        Me.cmdExportExcel.Text = "Export Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'dgdData
        '
        Me.dgdData.AllowUserToAddRows = False
        Me.dgdData.AllowUserToDeleteRows = False
        Me.dgdData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BL_NO, Me.CreateUser, Me.BookingNo, Me.Container_Type, Me.ChargeCode, Me.Currency, Me.Price, Me.PrepaidCollect})
        Me.dgdData.Location = New System.Drawing.Point(2, 89)
        Me.dgdData.Name = "dgdData"
        Me.dgdData.ReadOnly = True
        Me.dgdData.Size = New System.Drawing.Size(566, 371)
        Me.dgdData.TabIndex = 295
        '
        'BL_NO
        '
        Me.BL_NO.HeaderText = "B/L No."
        Me.BL_NO.Name = "BL_NO"
        Me.BL_NO.ReadOnly = True
        Me.BL_NO.Width = 80
        '
        'CreateUser
        '
        Me.CreateUser.HeaderText = "Create user"
        Me.CreateUser.Name = "CreateUser"
        Me.CreateUser.ReadOnly = True
        '
        'BookingNo
        '
        Me.BookingNo.HeaderText = "BookingNo."
        Me.BookingNo.Name = "BookingNo"
        Me.BookingNo.ReadOnly = True
        Me.BookingNo.Width = 80
        '
        'Container_Type
        '
        Me.Container_Type.HeaderText = "Type"
        Me.Container_Type.Name = "Container_Type"
        Me.Container_Type.ReadOnly = True
        Me.Container_Type.Width = 50
        '
        'ChargeCode
        '
        Me.ChargeCode.HeaderText = "Items"
        Me.ChargeCode.Name = "ChargeCode"
        Me.ChargeCode.ReadOnly = True
        Me.ChargeCode.Width = 40
        '
        'Currency
        '
        Me.Currency.HeaderText = "Cur"
        Me.Currency.Name = "Currency"
        Me.Currency.ReadOnly = True
        Me.Currency.Width = 40
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 50
        '
        'PrepaidCollect
        '
        Me.PrepaidCollect.HeaderText = "Prepaid Collect"
        Me.PrepaidCollect.Name = "PrepaidCollect"
        Me.PrepaidCollect.ReadOnly = True
        Me.PrepaidCollect.Width = 80
        '
        'dgdSurCharge
        '
        Me.dgdSurCharge.AllowUserToAddRows = False
        Me.dgdSurCharge.AllowUserToDeleteRows = False
        Me.dgdSurCharge.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdSurCharge.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdSurCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BookingNoSurcharge, Me.Container_typeSurcharge, Me.ChargeCodeSurcharge, Me.CurrencySurCharge, Me.PriceSurcharge, Me.PrepaidCollectSurcharge})
        Me.dgdSurCharge.Location = New System.Drawing.Point(574, 89)
        Me.dgdSurCharge.Name = "dgdSurCharge"
        Me.dgdSurCharge.ReadOnly = True
        Me.dgdSurCharge.Size = New System.Drawing.Size(373, 371)
        Me.dgdSurCharge.TabIndex = 295
        '
        'BookingNoSurcharge
        '
        Me.BookingNoSurcharge.HeaderText = "BookingNo."
        Me.BookingNoSurcharge.Name = "BookingNoSurcharge"
        Me.BookingNoSurcharge.ReadOnly = True
        Me.BookingNoSurcharge.Width = 80
        '
        'Container_typeSurcharge
        '
        Me.Container_typeSurcharge.HeaderText = "Type"
        Me.Container_typeSurcharge.Name = "Container_typeSurcharge"
        Me.Container_typeSurcharge.ReadOnly = True
        Me.Container_typeSurcharge.Width = 40
        '
        'ChargeCodeSurcharge
        '
        Me.ChargeCodeSurcharge.HeaderText = "Items"
        Me.ChargeCodeSurcharge.Name = "ChargeCodeSurcharge"
        Me.ChargeCodeSurcharge.ReadOnly = True
        Me.ChargeCodeSurcharge.Width = 40
        '
        'CurrencySurCharge
        '
        Me.CurrencySurCharge.HeaderText = "Cur"
        Me.CurrencySurCharge.Name = "CurrencySurCharge"
        Me.CurrencySurCharge.ReadOnly = True
        Me.CurrencySurCharge.Width = 40
        '
        'PriceSurcharge
        '
        Me.PriceSurcharge.HeaderText = "Price"
        Me.PriceSurcharge.Name = "PriceSurcharge"
        Me.PriceSurcharge.ReadOnly = True
        Me.PriceSurcharge.Width = 80
        '
        'PrepaidCollectSurcharge
        '
        Me.PrepaidCollectSurcharge.HeaderText = "Prepaid Collect"
        Me.PrepaidCollectSurcharge.Name = "PrepaidCollectSurcharge"
        Me.PrepaidCollectSurcharge.ReadOnly = True
        Me.PrepaidCollectSurcharge.Width = 50
        '
        'frmCheckPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(958, 470)
        Me.Controls.Add(Me.dgdSurCharge)
        Me.Controls.Add(Me.dgdData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmCheckPrice"
        Me.Text = "Check Price"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgdData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdSurCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents cmdOk As System.Windows.Forms.Button
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVessel As System.Windows.Forms.Label
    Friend WithEvents dtpLeavingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents dgdData As System.Windows.Forms.DataGridView
    Friend WithEvents dgdSurCharge As System.Windows.Forms.DataGridView
    Friend WithEvents BL_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreateUser As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChargeCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrepaidCollect As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BookingNoSurcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_typeSurcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ChargeCodeSurcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencySurCharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceSurcharge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrepaidCollectSurcharge As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
