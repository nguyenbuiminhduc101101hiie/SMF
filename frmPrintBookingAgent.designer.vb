<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintBookingAgent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintBookingAgent))
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.chkSea = New System.Windows.Forms.RadioButton()
        Me.chkAir = New System.Windows.Forms.RadioButton()
        Me.SuspendLayout()
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(12, 12)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(75, 23)
        Me.cmdRefresh.TabIndex = 66
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.DisplayGroupTree = False
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(12, 41)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.SelectionFormula = ""
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1039, 431)
        Me.CrystalReportViewer1.TabIndex = 64
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'chkSea
        '
        Me.chkSea.AutoSize = True
        Me.chkSea.Location = New System.Drawing.Point(149, 18)
        Me.chkSea.Name = "chkSea"
        Me.chkSea.Size = New System.Drawing.Size(44, 17)
        Me.chkSea.TabIndex = 67
        Me.chkSea.TabStop = True
        Me.chkSea.Text = "Sea"
        Me.chkSea.UseVisualStyleBackColor = True
        '
        'chkAir
        '
        Me.chkAir.AutoSize = True
        Me.chkAir.Location = New System.Drawing.Point(193, 18)
        Me.chkAir.Name = "chkAir"
        Me.chkAir.Size = New System.Drawing.Size(37, 17)
        Me.chkAir.TabIndex = 68
        Me.chkAir.TabStop = True
        Me.chkAir.Text = "Air"
        Me.chkAir.UseVisualStyleBackColor = True
        '
        'frmPrintBookingAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1063, 484)
        Me.Controls.Add(Me.chkAir)
        Me.Controls.Add(Me.chkSea)
        Me.Controls.Add(Me.cmdRefresh)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPrintBookingAgent"
        Me.Text = "Print Booking Agent"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkSea As System.Windows.Forms.RadioButton
    Friend WithEvents chkAir As System.Windows.Forms.RadioButton
End Class
