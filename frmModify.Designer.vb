<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModify
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModify))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdSaveService = New System.Windows.Forms.Button()
        Me.dgdShippingLines = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.textbox1 = New System.Windows.Forms.ComboBox()
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(476, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Exit"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdSaveService
        '
        Me.cmdSaveService.Location = New System.Drawing.Point(395, 4)
        Me.cmdSaveService.Name = "cmdSaveService"
        Me.cmdSaveService.Size = New System.Drawing.Size(75, 23)
        Me.cmdSaveService.TabIndex = 10
        Me.cmdSaveService.Text = "Save"
        Me.cmdSaveService.UseVisualStyleBackColor = True
        '
        'dgdShippingLines
        '
        Me.dgdShippingLines.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgdShippingLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdShippingLines.Location = New System.Drawing.Point(12, 33)
        Me.dgdShippingLines.Name = "dgdShippingLines"
        Me.dgdShippingLines.Size = New System.Drawing.Size(843, 320)
        Me.dgdShippingLines.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(318, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Load"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'textbox1
        '
        Me.textbox1.FormattingEnabled = True
        Me.textbox1.Location = New System.Drawing.Point(12, 4)
        Me.textbox1.Name = "textbox1"
        Me.textbox1.Size = New System.Drawing.Size(300, 21)
        Me.textbox1.TabIndex = 14
        '
        'frmModify
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(867, 365)
        Me.Controls.Add(Me.textbox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdSaveService)
        Me.Controls.Add(Me.dgdShippingLines)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmModify"
        Me.Text = "Modify"
        CType(Me.dgdShippingLines, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdSaveService As System.Windows.Forms.Button
    Friend WithEvents dgdShippingLines As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents textbox1 As System.Windows.Forms.ComboBox
End Class
