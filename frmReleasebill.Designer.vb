<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReleasebill
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
        Me.GrpReleaseBill = New System.Windows.Forms.GroupBox
        Me.cmdNotRelease = New System.Windows.Forms.Button
        Me.cmdAll = New System.Windows.Forms.Button
        Me.cmdRelease = New System.Windows.Forms.Button
        Me.cmdRefreshRelease = New System.Windows.Forms.Button
        Me.cmdCloseReleaseBill = New System.Windows.Forms.Button
        Me.dgdReleaseBillData = New System.Windows.Forms.DataGridView
        Me.BL_IDReleaseBill = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BillReleaseID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BL_NOReleaseBill = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.POLReleaseBill = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PODReleaseBill = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Release = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.ContinuedRelease = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EditableRelease = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ApproveRelease = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UserIDRelease = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.UpdateTimeRelease = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cmdSearch = New System.Windows.Forms.Button
        Me.GrpReleaseBill.SuspendLayout()
        CType(Me.dgdReleaseBillData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrpReleaseBill
        '
        Me.GrpReleaseBill.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GrpReleaseBill.Controls.Add(Me.cmdSearch)
        Me.GrpReleaseBill.Controls.Add(Me.cmdNotRelease)
        Me.GrpReleaseBill.Controls.Add(Me.cmdAll)
        Me.GrpReleaseBill.Controls.Add(Me.cmdRelease)
        Me.GrpReleaseBill.Controls.Add(Me.cmdRefreshRelease)
        Me.GrpReleaseBill.Controls.Add(Me.cmdCloseReleaseBill)
        Me.GrpReleaseBill.Controls.Add(Me.dgdReleaseBillData)
        Me.GrpReleaseBill.Location = New System.Drawing.Point(4, 3)
        Me.GrpReleaseBill.Name = "GrpReleaseBill"
        Me.GrpReleaseBill.Size = New System.Drawing.Size(514, 341)
        Me.GrpReleaseBill.TabIndex = 12
        Me.GrpReleaseBill.TabStop = False
        Me.GrpReleaseBill.Text = "Release bill"
        '
        'cmdNotRelease
        '
        Me.cmdNotRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdNotRelease.Location = New System.Drawing.Point(202, 310)
        Me.cmdNotRelease.Name = "cmdNotRelease"
        Me.cmdNotRelease.Size = New System.Drawing.Size(75, 23)
        Me.cmdNotRelease.TabIndex = 3
        Me.cmdNotRelease.Text = "Not Release"
        Me.cmdNotRelease.UseVisualStyleBackColor = True
        '
        'cmdAll
        '
        Me.cmdAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdAll.Location = New System.Drawing.Point(355, 310)
        Me.cmdAll.Name = "cmdAll"
        Me.cmdAll.Size = New System.Drawing.Size(75, 23)
        Me.cmdAll.TabIndex = 3
        Me.cmdAll.Text = "All"
        Me.cmdAll.UseVisualStyleBackColor = True
        '
        'cmdRelease
        '
        Me.cmdRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRelease.Location = New System.Drawing.Point(279, 310)
        Me.cmdRelease.Name = "cmdRelease"
        Me.cmdRelease.Size = New System.Drawing.Size(75, 23)
        Me.cmdRelease.TabIndex = 3
        Me.cmdRelease.Text = "Released"
        Me.cmdRelease.UseVisualStyleBackColor = True
        '
        'cmdRefreshRelease
        '
        Me.cmdRefreshRelease.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRefreshRelease.Location = New System.Drawing.Point(130, 310)
        Me.cmdRefreshRelease.Name = "cmdRefreshRelease"
        Me.cmdRefreshRelease.Size = New System.Drawing.Size(70, 24)
        Me.cmdRefreshRelease.TabIndex = 2
        Me.cmdRefreshRelease.Text = "Refresh"
        Me.cmdRefreshRelease.UseVisualStyleBackColor = True
        '
        'cmdCloseReleaseBill
        '
        Me.cmdCloseReleaseBill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCloseReleaseBill.Location = New System.Drawing.Point(431, 310)
        Me.cmdCloseReleaseBill.Name = "cmdCloseReleaseBill"
        Me.cmdCloseReleaseBill.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.cmdCloseReleaseBill.Size = New System.Drawing.Size(75, 23)
        Me.cmdCloseReleaseBill.TabIndex = 1
        Me.cmdCloseReleaseBill.Text = "Close"
        Me.cmdCloseReleaseBill.UseVisualStyleBackColor = True
        '
        'dgdReleaseBillData
        '
        Me.dgdReleaseBillData.AllowUserToAddRows = False
        Me.dgdReleaseBillData.AllowUserToDeleteRows = False
        Me.dgdReleaseBillData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdReleaseBillData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdReleaseBillData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BL_IDReleaseBill, Me.BillReleaseID, Me.BL_NOReleaseBill, Me.POLReleaseBill, Me.PODReleaseBill, Me.Release, Me.ContinuedRelease, Me.EditableRelease, Me.ApproveRelease, Me.UserIDRelease, Me.UpdateTimeRelease})
        Me.dgdReleaseBillData.Location = New System.Drawing.Point(6, 14)
        Me.dgdReleaseBillData.Name = "dgdReleaseBillData"
        Me.dgdReleaseBillData.Size = New System.Drawing.Size(502, 289)
        Me.dgdReleaseBillData.TabIndex = 0
        '
        'BL_IDReleaseBill
        '
        Me.BL_IDReleaseBill.DataPropertyName = "BL_ID"
        Me.BL_IDReleaseBill.HeaderText = "BL_ID"
        Me.BL_IDReleaseBill.Name = "BL_IDReleaseBill"
        Me.BL_IDReleaseBill.Visible = False
        '
        'BillReleaseID
        '
        Me.BillReleaseID.DataPropertyName = "BillReleaseID"
        Me.BillReleaseID.HeaderText = "BillReleaseID"
        Me.BillReleaseID.Name = "BillReleaseID"
        Me.BillReleaseID.Visible = False
        '
        'BL_NOReleaseBill
        '
        Me.BL_NOReleaseBill.DataPropertyName = "BL_NO"
        Me.BL_NOReleaseBill.HeaderText = "B/L No."
        Me.BL_NOReleaseBill.Name = "BL_NOReleaseBill"
        '
        'POLReleaseBill
        '
        Me.POLReleaseBill.DataPropertyName = "POL"
        Me.POLReleaseBill.HeaderText = "POL"
        Me.POLReleaseBill.Name = "POLReleaseBill"
        '
        'PODReleaseBill
        '
        Me.PODReleaseBill.DataPropertyName = "POD"
        Me.PODReleaseBill.HeaderText = "POD"
        Me.PODReleaseBill.Name = "PODReleaseBill"
        '
        'Release
        '
        Me.Release.DataPropertyName = "Release"
        Me.Release.HeaderText = "Release"
        Me.Release.Name = "Release"
        '
        'ContinuedRelease
        '
        Me.ContinuedRelease.DataPropertyName = "Continued"
        Me.ContinuedRelease.HeaderText = "Continued"
        Me.ContinuedRelease.Name = "ContinuedRelease"
        Me.ContinuedRelease.Visible = False
        '
        'EditableRelease
        '
        Me.EditableRelease.DataPropertyName = "Editable"
        Me.EditableRelease.HeaderText = "Editable"
        Me.EditableRelease.Name = "EditableRelease"
        Me.EditableRelease.Visible = False
        '
        'ApproveRelease
        '
        Me.ApproveRelease.DataPropertyName = "Approve"
        Me.ApproveRelease.HeaderText = "Approve"
        Me.ApproveRelease.Name = "ApproveRelease"
        Me.ApproveRelease.Visible = False
        '
        'UserIDRelease
        '
        Me.UserIDRelease.DataPropertyName = "UserID"
        Me.UserIDRelease.HeaderText = "UserID"
        Me.UserIDRelease.Name = "UserIDRelease"
        Me.UserIDRelease.Visible = False
        '
        'UpdateTimeRelease
        '
        Me.UpdateTimeRelease.DataPropertyName = "UpdateTime"
        Me.UpdateTimeRelease.HeaderText = "UpdateTime"
        Me.UpdateTimeRelease.Name = "UpdateTimeRelease"
        Me.UpdateTimeRelease.Visible = False
        '
        'cmdSearch
        '
        Me.cmdSearch.Location = New System.Drawing.Point(6, 312)
        Me.cmdSearch.Name = "cmdSearch"
        Me.cmdSearch.Size = New System.Drawing.Size(75, 23)
        Me.cmdSearch.TabIndex = 4
        Me.cmdSearch.Text = "&Search"
        Me.cmdSearch.UseVisualStyleBackColor = True
        '
        'frmReleasebill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 356)
        Me.Controls.Add(Me.GrpReleaseBill)
        Me.Name = "frmReleasebill"
        Me.Text = "Release bill"
        Me.GrpReleaseBill.ResumeLayout(False)
        CType(Me.dgdReleaseBillData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrpReleaseBill As System.Windows.Forms.GroupBox
    Friend WithEvents cmdRefreshRelease As System.Windows.Forms.Button
    Friend WithEvents cmdCloseReleaseBill As System.Windows.Forms.Button
    Friend WithEvents dgdReleaseBillData As System.Windows.Forms.DataGridView
    Friend WithEvents BL_IDReleaseBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BillReleaseID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BL_NOReleaseBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents POLReleaseBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PODReleaseBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Release As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ContinuedRelease As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EditableRelease As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ApproveRelease As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UserIDRelease As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UpdateTimeRelease As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmdNotRelease As System.Windows.Forms.Button
    Friend WithEvents cmdAll As System.Windows.Forms.Button
    Friend WithEvents cmdRelease As System.Windows.Forms.Button
    Friend WithEvents cmdSearch As System.Windows.Forms.Button
End Class
