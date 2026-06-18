<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MasterData
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
        Me.Y2 = New System.Windows.Forms.ComboBox()
        Me.T2 = New System.Windows.Forms.ComboBox()
        Me.N2 = New System.Windows.Forms.ComboBox()
        Me.Y1 = New System.Windows.Forms.ComboBox()
        Me.T1 = New System.Windows.Forms.ComboBox()
        Me.D1 = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.prbExport = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Y2
        '
        Me.Y2.FormattingEnabled = True
        Me.Y2.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y2.Location = New System.Drawing.Point(400, 12)
        Me.Y2.Name = "Y2"
        Me.Y2.Size = New System.Drawing.Size(52, 21)
        Me.Y2.TabIndex = 737
        Me.Y2.Text = "2015"
        '
        'T2
        '
        Me.T2.FormattingEnabled = True
        Me.T2.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T2.Location = New System.Drawing.Point(350, 12)
        Me.T2.Name = "T2"
        Me.T2.Size = New System.Drawing.Size(48, 21)
        Me.T2.TabIndex = 736
        Me.T2.Text = "JAN"
        '
        'N2
        '
        Me.N2.FormattingEnabled = True
        Me.N2.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.N2.Location = New System.Drawing.Point(313, 12)
        Me.N2.Name = "N2"
        Me.N2.Size = New System.Drawing.Size(35, 21)
        Me.N2.TabIndex = 735
        Me.N2.Text = "01"
        '
        'Y1
        '
        Me.Y1.FormattingEnabled = True
        Me.Y1.Items.AddRange(New Object() {"2015", "2016", "2017", "2018", "2019", "2020"})
        Me.Y1.Location = New System.Drawing.Point(208, 12)
        Me.Y1.Name = "Y1"
        Me.Y1.Size = New System.Drawing.Size(52, 21)
        Me.Y1.TabIndex = 734
        Me.Y1.Text = "2015"
        '
        'T1
        '
        Me.T1.FormattingEnabled = True
        Me.T1.Items.AddRange(New Object() {"JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"})
        Me.T1.Location = New System.Drawing.Point(158, 12)
        Me.T1.Name = "T1"
        Me.T1.Size = New System.Drawing.Size(48, 21)
        Me.T1.TabIndex = 733
        Me.T1.Text = "JAN"
        '
        'D1
        '
        Me.D1.FormattingEnabled = True
        Me.D1.Items.AddRange(New Object() {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"})
        Me.D1.Location = New System.Drawing.Point(121, 12)
        Me.D1.Name = "D1"
        Me.D1.Size = New System.Drawing.Size(35, 21)
        Me.D1.TabIndex = 732
        Me.D1.Text = "01"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(280, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 13)
        Me.Label3.TabIndex = 731
        Me.Label3.Text = "to :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 13)
        Me.Label2.TabIndex = 730
        Me.Label2.Text = "From (Date report):"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(465, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 729
        Me.Button1.Text = "Export File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'prbExport
        '
        Me.prbExport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.prbExport.Location = New System.Drawing.Point(23, 45)
        Me.prbExport.Name = "prbExport"
        Me.prbExport.Size = New System.Drawing.Size(679, 23)
        Me.prbExport.TabIndex = 738
        Me.prbExport.Visible = False
        '
        'lblProgress
        '
        Me.lblProgress.AutoSize = True
        Me.lblProgress.Location = New System.Drawing.Point(23, 71)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(0, 13)
        Me.lblProgress.TabIndex = 739
        '
        'Frm_MasterData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(725, 478)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.prbExport)
        Me.Controls.Add(Me.Y2)
        Me.Controls.Add(Me.T2)
        Me.Controls.Add(Me.N2)
        Me.Controls.Add(Me.Y1)
        Me.Controls.Add(Me.T1)
        Me.Controls.Add(Me.D1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "Frm_MasterData"
        Me.Text = "Frm_MasterData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Y2 As ComboBox
    Friend WithEvents T2 As ComboBox
    Friend WithEvents N2 As ComboBox
    Friend WithEvents Y1 As ComboBox
    Friend WithEvents T1 As ComboBox
    Friend WithEvents D1 As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents prbExport As ProgressBar
    Friend WithEvents lblProgress As Label
End Class
