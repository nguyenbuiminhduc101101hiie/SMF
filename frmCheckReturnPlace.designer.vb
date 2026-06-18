<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckReturnPlace
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgdAddContainer = New System.Windows.Forms.DataGridView
        Me.LOADINGPLANFORVESSELID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BooKingContainerNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Container_NoAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CTN_SIZE_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Cold = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Ventilation = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SealAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DateOfSupplyEmptyContainer = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RETURNPLACE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomsLiquiDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PLACESUPPLYEMPTYCONTAINER = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DelayAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.DelayDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CancelAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ApproveAdd = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.EditableAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContinuedAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIdAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdatetimeAdd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboVessel = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblBookingQuantity = New System.Windows.Forms.Label
        Me.cmdExportExcel = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.dgdAddContainer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgdAddContainer
        '
        Me.dgdAddContainer.AllowUserToAddRows = False
        Me.dgdAddContainer.AllowUserToDeleteRows = False
        Me.dgdAddContainer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgdAddContainer.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgdAddContainer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdAddContainer.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.LOADINGPLANFORVESSELID, Me.CTN_ID, Me.BooKingContainerNo, Me.Container_NoAdd, Me.CTN_SIZE_TYPE, Me.Cold, Me.Ventilation, Me.SealAdd, Me.DateOfSupplyEmptyContainer, Me.RETURNPLACE, Me.CustomsLiquiDate, Me.PLACESUPPLYEMPTYCONTAINER, Me.DelayAdd, Me.DelayDate, Me.CancelAdd, Me.ApproveAdd, Me.EditableAdd, Me.ContinuedAdd, Me.UserIdAdd, Me.UpdatetimeAdd})
        Me.dgdAddContainer.Location = New System.Drawing.Point(4, 58)
        Me.dgdAddContainer.Name = "dgdAddContainer"
        Me.dgdAddContainer.ReadOnly = True
        Me.dgdAddContainer.Size = New System.Drawing.Size(590, 330)
        Me.dgdAddContainer.TabIndex = 1
        '
        'LOADINGPLANFORVESSELID
        '
        Me.LOADINGPLANFORVESSELID.DataPropertyName = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.HeaderText = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.Name = "LOADINGPLANFORVESSELID"
        Me.LOADINGPLANFORVESSELID.ReadOnly = True
        Me.LOADINGPLANFORVESSELID.Visible = False
        '
        'CTN_ID
        '
        Me.CTN_ID.DataPropertyName = "CTN_ID"
        Me.CTN_ID.HeaderText = "CTN_ID"
        Me.CTN_ID.Name = "CTN_ID"
        Me.CTN_ID.ReadOnly = True
        Me.CTN_ID.Visible = False
        '
        'BooKingContainerNo
        '
        Me.BooKingContainerNo.DataPropertyName = "BooKingNo"
        Me.BooKingContainerNo.HeaderText = "BooKing No"
        Me.BooKingContainerNo.Name = "BooKingContainerNo"
        Me.BooKingContainerNo.ReadOnly = True
        '
        'Container_NoAdd
        '
        Me.Container_NoAdd.DataPropertyName = "Container_No"
        Me.Container_NoAdd.HeaderText = "Container No"
        Me.Container_NoAdd.Name = "Container_NoAdd"
        Me.Container_NoAdd.ReadOnly = True
        '
        'CTN_SIZE_TYPE
        '
        Me.CTN_SIZE_TYPE.DataPropertyName = "CTN_SIZE_TYPE"
        Me.CTN_SIZE_TYPE.HeaderText = "Container Type"
        Me.CTN_SIZE_TYPE.Name = "CTN_SIZE_TYPE"
        Me.CTN_SIZE_TYPE.ReadOnly = True
        Me.CTN_SIZE_TYPE.Width = 50
        '
        'Cold
        '
        Me.Cold.DataPropertyName = "Cold"
        Me.Cold.HeaderText = "Cold"
        Me.Cold.Name = "Cold"
        Me.Cold.ReadOnly = True
        Me.Cold.Width = 50
        '
        'Ventilation
        '
        Me.Ventilation.DataPropertyName = "Ventilation"
        Me.Ventilation.HeaderText = "Ventilation"
        Me.Ventilation.Name = "Ventilation"
        Me.Ventilation.ReadOnly = True
        '
        'SealAdd
        '
        Me.SealAdd.DataPropertyName = "Seal"
        Me.SealAdd.HeaderText = "Seal"
        Me.SealAdd.Name = "SealAdd"
        Me.SealAdd.ReadOnly = True
        Me.SealAdd.Width = 50
        '
        'DateOfSupplyEmptyContainer
        '
        Me.DateOfSupplyEmptyContainer.DataPropertyName = "DateOfSupplyEmptyContainer"
        Me.DateOfSupplyEmptyContainer.HeaderText = "Date Of Supply Empty Container"
        Me.DateOfSupplyEmptyContainer.Name = "DateOfSupplyEmptyContainer"
        Me.DateOfSupplyEmptyContainer.ReadOnly = True
        '
        'RETURNPLACE
        '
        Me.RETURNPLACE.DataPropertyName = "RETURNPLACE"
        Me.RETURNPLACE.HeaderText = "Return place"
        Me.RETURNPLACE.Name = "RETURNPLACE"
        Me.RETURNPLACE.ReadOnly = True
        '
        'CustomsLiquiDate
        '
        Me.CustomsLiquiDate.DataPropertyName = "CustomsLiquiDate"
        Me.CustomsLiquiDate.HeaderText = "Return place (Booking)"
        Me.CustomsLiquiDate.Name = "CustomsLiquiDate"
        Me.CustomsLiquiDate.ReadOnly = True
        '
        'PLACESUPPLYEMPTYCONTAINER
        '
        Me.PLACESUPPLYEMPTYCONTAINER.DataPropertyName = "PLACESUPPLYEMPTYCONTAINER"
        Me.PLACESUPPLYEMPTYCONTAINER.HeaderText = "Place Of Supply Empty Container"
        Me.PLACESUPPLYEMPTYCONTAINER.Name = "PLACESUPPLYEMPTYCONTAINER"
        Me.PLACESUPPLYEMPTYCONTAINER.ReadOnly = True
        '
        'DelayAdd
        '
        Me.DelayAdd.DataPropertyName = "Delay"
        Me.DelayAdd.HeaderText = "Delay"
        Me.DelayAdd.Name = "DelayAdd"
        Me.DelayAdd.ReadOnly = True
        Me.DelayAdd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DelayAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DelayAdd.Width = 50
        '
        'DelayDate
        '
        Me.DelayDate.DataPropertyName = "DelayDate"
        Me.DelayDate.HeaderText = "Delay (Date)"
        Me.DelayDate.Name = "DelayDate"
        Me.DelayDate.ReadOnly = True
        '
        'CancelAdd
        '
        Me.CancelAdd.DataPropertyName = "Cancel"
        Me.CancelAdd.HeaderText = "Cancel"
        Me.CancelAdd.Name = "CancelAdd"
        Me.CancelAdd.ReadOnly = True
        Me.CancelAdd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CancelAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.CancelAdd.Width = 50
        '
        'ApproveAdd
        '
        Me.ApproveAdd.DataPropertyName = "Approve"
        Me.ApproveAdd.HeaderText = "Approve"
        Me.ApproveAdd.Name = "ApproveAdd"
        Me.ApproveAdd.ReadOnly = True
        Me.ApproveAdd.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ApproveAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ApproveAdd.Visible = False
        '
        'EditableAdd
        '
        Me.EditableAdd.DataPropertyName = "Editable"
        Me.EditableAdd.HeaderText = "Editable"
        Me.EditableAdd.Name = "EditableAdd"
        Me.EditableAdd.ReadOnly = True
        Me.EditableAdd.Visible = False
        '
        'ContinuedAdd
        '
        Me.ContinuedAdd.DataPropertyName = "Continued"
        Me.ContinuedAdd.HeaderText = "Continued"
        Me.ContinuedAdd.Name = "ContinuedAdd"
        Me.ContinuedAdd.ReadOnly = True
        Me.ContinuedAdd.Visible = False
        '
        'UserIdAdd
        '
        Me.UserIdAdd.DataPropertyName = "UserId"
        Me.UserIdAdd.HeaderText = "UserID"
        Me.UserIdAdd.Name = "UserIdAdd"
        Me.UserIdAdd.ReadOnly = True
        '
        'UpdatetimeAdd
        '
        Me.UpdatetimeAdd.DataPropertyName = "Updatetime"
        Me.UpdatetimeAdd.HeaderText = "Updatetime"
        Me.UpdatetimeAdd.Name = "UpdatetimeAdd"
        Me.UpdatetimeAdd.ReadOnly = True
        '
        'cboVessel
        '
        Me.cboVessel.FormattingEnabled = True
        Me.cboVessel.Location = New System.Drawing.Point(103, 22)
        Me.cboVessel.Name = "cboVessel"
        Me.cboVessel.Size = New System.Drawing.Size(291, 21)
        Me.cboVessel.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(14, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Vessel / VoyNo :"
        '
        'lblBookingQuantity
        '
        Me.lblBookingQuantity.AutoSize = True
        Me.lblBookingQuantity.Location = New System.Drawing.Point(410, 25)
        Me.lblBookingQuantity.Name = "lblBookingQuantity"
        Me.lblBookingQuantity.Size = New System.Drawing.Size(0, 13)
        Me.lblBookingQuantity.TabIndex = 4
        '
        'cmdExportExcel
        '
        Me.cmdExportExcel.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.cmdExportExcel.Location = New System.Drawing.Point(400, 20)
        Me.cmdExportExcel.Name = "cmdExportExcel"
        Me.cmdExportExcel.Size = New System.Drawing.Size(100, 23)
        Me.cmdExportExcel.TabIndex = 5
        Me.cmdExportExcel.Text = "Export to Excel"
        Me.cmdExportExcel.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Button1.Location = New System.Drawing.Point(506, 20)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "&Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmCheckReturnPlace
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 402)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdExportExcel)
        Me.Controls.Add(Me.lblBookingQuantity)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboVessel)
        Me.Controls.Add(Me.dgdAddContainer)
        Me.Name = "frmCheckReturnPlace"
        Me.Text = "Check Return Place"
        CType(Me.dgdAddContainer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgdAddContainer As System.Windows.Forms.DataGridView
    Friend WithEvents cboVessel As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblBookingQuantity As System.Windows.Forms.Label
    Friend WithEvents cmdExportExcel As System.Windows.Forms.Button
    Friend WithEvents LOADINGPLANFORVESSELID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BooKingContainerNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Container_NoAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CTN_SIZE_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cold As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Ventilation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SealAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateOfSupplyEmptyContainer As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RETURNPLACE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomsLiquiDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PLACESUPPLYEMPTYCONTAINER As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DelayAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DelayDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CancelAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ApproveAdd As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents EditableAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContinuedAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIdAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdatetimeAdd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
