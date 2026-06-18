<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptDeclarationOfDeparture
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
        Me.cmdUpdateInfo = New System.Windows.Forms.Button
        Me.btnShow = New System.Windows.Forms.Button
        Me.cmdCancel = New System.Windows.Forms.Button
        Me.grpComfirmInfo = New System.Windows.Forms.GroupBox
        Me.txtBangKhaiDichVuYTe = New System.Windows.Forms.TextBox
        Me.txtBangKhaiHanhLyThuyenVien = New System.Windows.Forms.TextBox
        Me.txtBangKhaiDuTruCuaTau = New System.Windows.Forms.TextBox
        Me.txtTaiLieuDinhKem = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBangKhaiHangHoa = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkArrival = New System.Windows.Forms.RadioButton
        Me.chkDeparture = New System.Windows.Forms.RadioButton
        Me.grpComfirmInfo.SuspendLayout()
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(821, 496)
        Me.CrystalReportViewer1.TabIndex = 9
        Me.CrystalReportViewer1.ViewTimeSelectionFormula = ""
        '
        'cmdUpdateInfo
        '
        Me.cmdUpdateInfo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdUpdateInfo.Location = New System.Drawing.Point(725, 5)
        Me.cmdUpdateInfo.Name = "cmdUpdateInfo"
        Me.cmdUpdateInfo.Size = New System.Drawing.Size(75, 23)
        Me.cmdUpdateInfo.TabIndex = 11
        Me.cmdUpdateInfo.Text = "Update Info"
        Me.cmdUpdateInfo.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(254, 252)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 23)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "&Ok"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Location = New System.Drawing.Point(332, 252)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'grpComfirmInfo
        '
        Me.grpComfirmInfo.Controls.Add(Me.txtBangKhaiDichVuYTe)
        Me.grpComfirmInfo.Controls.Add(Me.txtBangKhaiHanhLyThuyenVien)
        Me.grpComfirmInfo.Controls.Add(Me.txtBangKhaiDuTruCuaTau)
        Me.grpComfirmInfo.Controls.Add(Me.txtTaiLieuDinhKem)
        Me.grpComfirmInfo.Controls.Add(Me.Label4)
        Me.grpComfirmInfo.Controls.Add(Me.Label3)
        Me.grpComfirmInfo.Controls.Add(Me.Label5)
        Me.grpComfirmInfo.Controls.Add(Me.txtBangKhaiHangHoa)
        Me.grpComfirmInfo.Controls.Add(Me.Label2)
        Me.grpComfirmInfo.Controls.Add(Me.Label1)
        Me.grpComfirmInfo.Controls.Add(Me.chkArrival)
        Me.grpComfirmInfo.Controls.Add(Me.chkDeparture)
        Me.grpComfirmInfo.Controls.Add(Me.cmdCancel)
        Me.grpComfirmInfo.Controls.Add(Me.btnShow)
        Me.grpComfirmInfo.Location = New System.Drawing.Point(192, 61)
        Me.grpComfirmInfo.Name = "grpComfirmInfo"
        Me.grpComfirmInfo.Size = New System.Drawing.Size(421, 290)
        Me.grpComfirmInfo.TabIndex = 10
        Me.grpComfirmInfo.TabStop = False
        Me.grpComfirmInfo.Text = "Confirm Information"
        Me.grpComfirmInfo.Visible = False
        '
        'txtBangKhaiDichVuYTe
        '
        Me.txtBangKhaiDichVuYTe.Location = New System.Drawing.Point(182, 177)
        Me.txtBangKhaiDichVuYTe.Name = "txtBangKhaiDichVuYTe"
        Me.txtBangKhaiDichVuYTe.Size = New System.Drawing.Size(220, 20)
        Me.txtBangKhaiDichVuYTe.TabIndex = 13
        '
        'txtBangKhaiHanhLyThuyenVien
        '
        Me.txtBangKhaiHanhLyThuyenVien.Location = New System.Drawing.Point(182, 147)
        Me.txtBangKhaiHanhLyThuyenVien.Name = "txtBangKhaiHanhLyThuyenVien"
        Me.txtBangKhaiHanhLyThuyenVien.Size = New System.Drawing.Size(220, 20)
        Me.txtBangKhaiHanhLyThuyenVien.TabIndex = 13
        '
        'txtBangKhaiDuTruCuaTau
        '
        Me.txtBangKhaiDuTruCuaTau.Location = New System.Drawing.Point(182, 114)
        Me.txtBangKhaiDuTruCuaTau.Name = "txtBangKhaiDuTruCuaTau"
        Me.txtBangKhaiDuTruCuaTau.Size = New System.Drawing.Size(220, 20)
        Me.txtBangKhaiDuTruCuaTau.TabIndex = 13
        '
        'txtTaiLieuDinhKem
        '
        Me.txtTaiLieuDinhKem.Location = New System.Drawing.Point(182, 49)
        Me.txtTaiLieuDinhKem.Name = "txtTaiLieuDinhKem"
        Me.txtTaiLieuDinhKem.Size = New System.Drawing.Size(220, 20)
        Me.txtTaiLieuDinhKem.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(150, 26)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Bảng khai kiểm dịch Y tế :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Health Quarantine Declaration"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 26)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Bảng khai hành lý thuyền viên :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Crew’s Effects Declaration" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(49, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 26)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Bảng khai dự trữ của tàu :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ship’s Stores Declaration"
        '
        'txtBangKhaiHangHoa
        '
        Me.txtBangKhaiHangHoa.Location = New System.Drawing.Point(182, 83)
        Me.txtBangKhaiHangHoa.Name = "txtBangKhaiHangHoa"
        Me.txtBangKhaiHangHoa.Size = New System.Drawing.Size(220, 20)
        Me.txtBangKhaiHangHoa.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 26)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Tài liệu đính kèm :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Attached documents "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 26)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Bảng khai hàng hóa :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cargo Declaration"
        '
        'chkArrival
        '
        Me.chkArrival.AutoSize = True
        Me.chkArrival.Checked = True
        Me.chkArrival.Location = New System.Drawing.Point(85, 229)
        Me.chkArrival.Name = "chkArrival"
        Me.chkArrival.Size = New System.Drawing.Size(54, 17)
        Me.chkArrival.TabIndex = 6
        Me.chkArrival.TabStop = True
        Me.chkArrival.Text = "Arrival"
        Me.chkArrival.UseVisualStyleBackColor = True
        '
        'chkDeparture
        '
        Me.chkDeparture.AutoSize = True
        Me.chkDeparture.Location = New System.Drawing.Point(158, 229)
        Me.chkDeparture.Name = "chkDeparture"
        Me.chkDeparture.Size = New System.Drawing.Size(72, 17)
        Me.chkDeparture.TabIndex = 6
        Me.chkDeparture.Text = "Departure"
        Me.chkDeparture.UseVisualStyleBackColor = True
        '
        'frmRptDeclarationOfDeparture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 496)
        Me.Controls.Add(Me.cmdUpdateInfo)
        Me.Controls.Add(Me.grpComfirmInfo)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmRptDeclarationOfDeparture"
        Me.Text = "Report Declaration Of Departure"
        Me.grpComfirmInfo.ResumeLayout(False)
        Me.grpComfirmInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmdUpdateInfo As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents grpComfirmInfo As System.Windows.Forms.GroupBox
    Friend WithEvents chkArrival As System.Windows.Forms.RadioButton
    Friend WithEvents chkDeparture As System.Windows.Forms.RadioButton
    Friend WithEvents txtBangKhaiDichVuYTe As System.Windows.Forms.TextBox
    Friend WithEvents txtBangKhaiHanhLyThuyenVien As System.Windows.Forms.TextBox
    Friend WithEvents txtTaiLieuDinhKem As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBangKhaiHangHoa As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBangKhaiDuTruCuaTau As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
