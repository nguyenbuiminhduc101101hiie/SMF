Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System
Imports System.Net
Imports System.Management
Imports System.Globalization
Imports System.IO


Partial Friend Class frmMain
    'Inherits System.Windows.Forms.Form
    Public otable As DataTable
    Public ds As DataSet
    Dim Mdown As Boolean = False 'nếu mouse dodwn thì true
    Dim X, Y As Integer

    Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Try
            AddImportFreightQuotationMenu()
            Me.MainMenu1.Enabled = False

            ctrFrmMain = Me
            StartupPath = CurDir()
            ' add reference VBIDE, visaul basic compatibility
            Me.Height = VB6.TwipsToPixelsY(CShort(VB6.PixelsToTwipsY(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height) * 0.98))
            Me.Width = VB6.TwipsToPixelsX(CShort(VB6.PixelsToTwipsX(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width) * 0.98))
            'Me.txtVersion.Text = "Version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
            Me.Show()
            GetParm()
            'If gLang = "E" Then
            ' Che tam 8/8/06
            'EfrmMain()
            'gDecimalSymbol = "."
            'gThousandSymbol = ","
            'gListSeparator = "."
            'gMonthly = "Monthly"
            'gQuaterly = "Quaterly"
            'gYearly = "Yearly"
            'gDoubleFormat = "#.###.###"
            'Else
            '    gDecimalSymbol = ","
            '    gThousandSymbol = "."
            '    gListSeparator = ";"
            '    gMonthly = "Tháng"
            '    gQuaterly = "Qúy"
            '    gYearly = "Năm"
            '    gDoubleFormat = "#,###.##"
            'End If
            'gDateFormat = "dd-MMM-yyyy"
            'gDateTimeFormat = "hh:mm dd-MMM-yyyy"
            'gConnectionFailure = False

            mnuSystemLogin_Click(mnuSystemLogin, New System.EventArgs())

            '---------------------------------
            If LoginSucceeded Then
                Dim C, k As Integer
                Try
                    C = getOptionValue("frmthongbao", "OB", "time-thongbao", "time-thongbao", "C")
                    Me.Timer1.Interval = C
                    Me.Timer1.Enabled = True
                Catch ex As Exception
                    Me.Timer1.Interval = 900000 ' 15 phut
                End Try
            End If


            '------------------------------------------


            'checkAlarm1()
            If LoginSucceeded Then
                'checkbaotri()
                'If CheckVersion() = False Then
                '    MsgBox("Version is old. Please contact us to update, thanks.")
                '    Me.Close()
                'End If
                'If GetUserVersion() <> My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision Then
                '	SetUserVersion(My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision)
                '             If AgreeMessage(True, "SMF version " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & IIf(gLang = "E", " has been updated. Do you want to know what's new? ", " vừa được cập nhật trên máy bạn. Bạn có muốn biết thay đổi của Version này?")) = MsgBoxResult.Yes Then
                '                 'mnuWhatsnew_Click(mnuWhatsnew, New System.EventArgs())
                '             End If
                'End If
            Else
                'DisplayMessage(True, "Please check permission , thank!")
                Exit Sub
            End If
            ' If Not CheckRegionalSetting() Then Me.Close()
            ' khoi tao chieu rong them khi man hinh 1024x768
            'If CheckRez(1024, 768) Then
            '    rong = 50
            'Else
            '    'DisplayMessage(True, "Hệ thống hiển thị tốt nhất trên độ phân giải màn hình là : 1024 x 768, đề nghị chọn lại!")
            'End If
            If UCase(gDepartment) = "MANAGEMENT" Then
                OPENMENUMANAGEMENT(True)
            Else
                OPENMENUMANAGEMENT(False)
            End If
        Catch ex As Exception
            DisplayMessage(True, "Resizing failed.")
        End Try

    End Sub
    '    Public Sub queryNotify()
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim strCNLocal As String = "Data Source='" & strServer & "'; User ID='" & strUserId & "'; password='" & strPassword & "'; Initial Catalog='" & strDatabase & "'"
    '        Dim Con As New SqlClient.SqlConnection(strCNLocal)
    '        Dim ds As New DataSet
    '        '----------------
    '        strQuery = "SELECT NotifyVesselId, NotifyVessel.Vessel_Id as Vessel_Id,Vessel.Vessel as VesselName,NotifyVessel.VoyNo as VoyNo ,ETA,ETB,ETD,BTH,Commodity,Remarks,Note,NotifyVessel.Approve as Approve,NotifyVessel.Continued as Continued,NotifyVessel.Editable as Editable,NotifyVessel.UserId as UserId,NotifyVessel.UpDateTime as updateTime FROM NotifyVessel inner join Vessel on NotifyVessel.Vessel_Id=Vessel.Vessel_Id where NotifyVessel.continued=1 ORDER BY NotifyVessel.updatetime desc "
    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        Con.Open()
    '        Adapter.Fill(ds, "NotifyList")
    '        oTable = ds.Tables(0)
    '        'hien thi ra grid 
    '        Me.dgdNotifyVessel.DataSource = ds.Tables("NotifyList")
    '        If Me.dgdNotifyVessel.Enabled = False Then
    '            Me.dgdNotifyVessel.Enabled = True
    '        End If
    '        '--------------------
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub
    'UPGRADE_WARNING: Event frmMain.Resize may fire when form is initialized. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="88B12AE1-6DE0-48A0-86F1-60C0686C026A"'
    Private Sub frmMain_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        If Me.WindowState = System.Windows.Forms.FormWindowState.Normal Then Me.Top = VB6.TwipsToPixelsY(1)
        If Me.WindowState = System.Windows.Forms.FormWindowState.Normal Or Me.WindowState = System.Windows.Forms.FormWindowState.Maximized Then

        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, "Resizing failed.")
    End Sub

    Private Sub frmMain_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            mnuSystemLogin_Click(mnuSystemLogin, New System.EventArgs())
        End If
        logout_log()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:Form_Load")
    End Sub
    Public Sub logout_log()
        Dim cmd As New ADODB.Command
        Try
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "UPDATE UserOnline "
            cmd.CommandText = cmd.CommandText & "SET LogoutTime = GetDate() "
            cmd.CommandText = cmd.CommandText & "WHERE UserOnlineId = '" & strUserOnlineId & "' "
            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
        Catch ex As Exception

        End Try
        'If strconn.State = ADODB.ObjectStateEnum.adStateOpen Then

        'strconn.Close()
        'CSCLEnv.CSCLSConn.Close()
        'End If

    End Sub
    Private Sub GetParm()
        On Error GoTo Err_Renamed
        Dim Vt As Short
        Dim lChar, CmdStr As String
        Dim i As Short
        CmdStr = Trim(VB.Command())

        strServer = ""
        Vt = InStr(UCase(CmdStr), "-S")
        If Vt > 0 Then
            For i = Vt + 2 To Len(CmdStr)
                lChar = Mid(CmdStr, i, 1)
                If lChar = " " Then
                    Exit For
                Else
                    strServer = strServer & lChar
                End If
            Next i
        End If

        Vt = InStr(UCase(CmdStr), "-D")
        If Vt > 0 Then
            strDatabase = ""
            For i = Vt + 2 To Len(CmdStr)
                lChar = Mid(CmdStr, i, 1)
                If lChar = " " Then
                    Exit For
                Else
                    strDatabase = strDatabase & lChar
                End If
            Next i
        Else
            strDatabase = ""
        End If
        strUserId = ""
        Vt = InStr(UCase(CmdStr), "-U")
        If Vt > 0 Then
            For i = Vt + 2 To Len(CmdStr)
                lChar = Mid(CmdStr, i, 1)
                If lChar = " " Then
                    Exit For
                Else
                    strUserId = strUserId & lChar
                End If
            Next i
        End If
        Vt = InStr(UCase(CmdStr), "-L")
        If Vt > 0 Then
            For i = Vt + 2 To Len(CmdStr)
                lChar = Mid(CmdStr, i, 1)
                If lChar = " " Then
                    Exit For
                Else
                    gLang = gLang & UCase(lChar)
                End If
            Next i
        End If
        If gLang = "" Then gLang = "V"
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:GetParm")
    End Sub

    Private Sub Login()
        On Error GoTo Err_Renamed

        VB6.ShowForm(FrmLogin, VB6.FormShowConstants.Modal, Me)
        If LoginSucceeded Then
            Me.MainMenu1.Enabled = True
            DisplayNewMessages()
            SetMenu((True))
            AddImportFreightQuotationMenu()
            CreateObjects()
            GetOption()
            'queryNotify()
            loadDataToPort() ' lay data port TS Code
            Me.ToolTripMenuLogin.Enabled = False
            If gOptCurProfile <> "CSCL_IOB" Then
                'UPGRADE_WARNING: Couldn't resolve default property of object objProfile.Profile. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                objProfile.Profile(gOptCurProfile, Me.Name, "Get")
            End If
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            If gDepartment = "OutBound" Then
                If gBillOfLadingNumber = "" Then
                    VB6.ShowForm(frmInputBillNumber, VB6.FormShowConstants.Modal, Me)
                End If

                If gBillOfLadingNumber = "" Then
                    gBillOfLadingNumber = "No BillNumber."
                End If
            End If
            '----------------------
            Me.Text = gCompanyE + " - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            mnuSystemLogin.Text = "Logoff: " & strUserName
            '-----booking margins
            If UCase(gDepartment) = "BOOKING" Then
                gTopM = 150
                gLeftM = 0
                gRightM = 100
                gBottomM = 100
            End If
        Else
            Me.MainMenu1.Enabled = False
            '---
        End If
        'If My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision < GetRequiredVersion() Then
        '    DisplayMessage(True, IIf(gLang = "E", "The version is too old, please setup again.!.", "Version Chương trình cũ hơn so với dữ liệu. Đề nghị Setup lại hệ thống."))
        '    Me.Close()
        'End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:Login")
        'Resume
    End Sub

    Private Sub Logout()
        Try
            Dim Frm As System.Windows.Forms.Form
            '-


            For Each Frm In My.Application.OpenForms
                If Frm.Name <> "frmMain" Then
                    Frm.Close()
                End If
            Next Frm
            Dim cmd As New ADODB.Command
            Dim strQuery As String
            If Not gConnectionFailure Then
                SetMenu((False))
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "UPDATE UserOnline "
                cmd.CommandText = cmd.CommandText & "SET LogoutTime = GetDate() "
                cmd.CommandText = cmd.CommandText & "WHERE UserOnlineId = '" & strUserOnlineId & "' "
                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                ' kiem tra lai khi huy cac doi tuong
                'DeleteObjects()
            End If

            Me.mnuSystemLogin.Text = "Login"

            Me.Text = "Login"
            LoginSucceeded = False
            '---- set lai gia tri Null moi khi logout
            gBillOfLadingNumber = ""
            gDepartment = ""
            Me.ToolTripMenuLogin.Enabled = True
            ' xoa file temp cua USERPROFILE
            Dim tempDir As String
            Dim f, fa As String
            'Dim fd As fol
            tempDir = System.Environment.GetEnvironmentVariable("TEMP") + ""
            Try

                For Each f In System.IO.Directory.GetFiles(tempDir)
                    If f Like "*rpt" Or f Like "*tmp" Then
                        System.IO.File.Delete(f)
                    End If
                Next
            Catch ex As Exception

            End Try

            'Kill(tempDir + "\*.*")
        Catch ex As Exception

        End Try
        'Resume
    End Sub
    Public Function GetMac(ByVal IP As String) As String
        Try
            Dim dirResults As String
            Dim psi As ProcessStartInfo = New ProcessStartInfo()
            Dim proc As New Process()
            psi.FileName = "nbtstat"
            psi.RedirectStandardInput = False
            psi.RedirectStandardOutput = True
            psi.Arguments = "-A " & IP
            psi.UseShellExecute = False
            proc = Process.Start(psi)
            Dim x As Integer = -1
            Do Until x > -1
                If dirResults <> Nothing Then
                    x = dirResults.Trim.ToLower.IndexOf("mac address", 0)
                    If x > -1 Then
                        Exit Do
                    End If
                End If
                dirResults = proc.StandardOutput.ReadLine
            Loop
            proc.WaitForExit()
            GetMac = ValueSepR(dirResults.Trim, "=").Trim
        Catch err As Exception
            MsgBox(err.Message & err.StackTrace)
        End Try
    End Function
    Public Function ValueSepR(ByVal RawString As String, ByVal SepChar As String) As String
        If InStr(1, RawString, SepChar) <> 0 Then
            ValueSepR = Microsoft.VisualBasic.Right(RawString, Len(RawString) - InStr(1, RawString, SepChar))
        Else
            ValueSepR = RawString
        End If
    End Function
    Private Sub SetMenu(ByVal argEnable As Boolean)
        On Error GoTo Err_Renamed
        'UPGRADE_NOTE: menu was upgraded to menu_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim menu_Renamed As Control
        Dim rs As New ADODB.Recordset
        Dim MenuItems, strQuery As String
        MenuItems = ""
        rs.Open("Select Menu FROM FormList order by formid", strconn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        While Not rs.EOF
            ' 10/8/06 xuat hien loi khi rs.Fields("Menu") co gia tri Null trong Database
            If Not IsDBNull(rs.Fields("Menu").Value) Then
                MenuItems = MenuItems & Trim(rs.Fields("Menu").Value) & ","
            End If
            rs.MoveNext()
        End While
        rs.Close()






        '-----------------------------------------------------------------------------
        'UPGRADE_NOTE: visible was upgraded to visible_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
        Dim visible_Renamed As Boolean
        Dim i As Integer
        Dim item As ToolStripItem
        For Each menu_Renamed In Me.Controls
            If menu_Renamed Is Me.MainMenu1 Then
                'DisplayMessage(False, "")
                For Each child As ToolStripMenuItem In Me.MainMenu1.Items
                    If TypeOf child Is ToolStripMenuItem Then
                        Dim menu_item As ToolStripMenuItem = DirectCast(child, ToolStripMenuItem)
                        For Each child_ As ToolStripItem In menu_item.DropDownItems
                            'DisplayMessage(False, child_.Name)
                            If InStr(MenuItems, child_.Name & ",") > 0 Then
                                If argEnable Then
                                    visible_Renamed = False
                                    strQuery = "Select UserRightForm.FormId,FormList.FormId,URAdd,UREdit,URDelete,URView,URExecute,URApprove "
                                    strQuery = strQuery & "FROM FormList "
                                    strQuery = strQuery & "INNER JOIN UserRightForm "
                                    strQuery = strQuery & "ON  "
                                    strQuery = strQuery & " UserRightForm.FormId = FormList.FormId where Usr = '" & strUserId & "'"
                                    strQuery = strQuery & "AND Menu = '" & child_.Name & "' "
                                    strQuery = strQuery & "AND UserRightForm.Discontinued = 0 "
                                    'Debug.Print strQuery
                                    If UCase(child_.Name) = "smnuservice" Then
                                        DisplayMessage(True, "")
                                    End If
                                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                                    If Not rs.EOF Then
                                        If rs.Fields("URAdd").Value Or rs.Fields("UREdit").Value Or rs.Fields("URDelete").Value Or rs.Fields("URView").Value Or rs.Fields("URExecute").Value Or rs.Fields("URApprove").Value Then
                                            visible_Renamed = True
                                        End If
                                    End If
                                    'Debug.Print strQuery
                                    rs.Close()
                                    'SetMenuItem menu, False
                                    On Error Resume Next
                                    child_.Visible = visible_Renamed

                                Else
                                    'SetMenuItem menu, False
                                    On Error Resume Next
                                    child_.Visible = False
                                End If
                            End If
                        Next child_
                    End If
                Next
            End If
        Next menu_Renamed
        'set menu cua hoangld
        'If UCase(gDepartment) = "Management" Then
        '    OPENMENU(True)
        'Else
        '    OPENMENU(False)
        'End If
        'DeleteFile(strClicensePath2)
        'Me.mnuTest.Visible = (UCase(strUserId) = "DBO")
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:SetMenu")
        'Resume
    End Sub
    Public Sub OPENMENUMANAGEMENT(ByVal chk As Boolean)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'Me.FreightTariffToolStripMenuItem.Visible = chk
            'Me.SpecialFreightToolStripMenuItem.Visible = chk
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub OPENMENU(ByVal chk As Boolean)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'frmContainerOutBoundNotify.mnuRestore.Visible = chk
            'frmContainerOutBoundNotify.mnuReportManagement.Visible = chk
            ''Me.ReduceDEMDETToolStripMenuItem.Visible = chk
            ''frmListBaseMaster.smnureportgraphoutbound.Visible = chk
            'frmContainerOutBoundNotify.smnureportgraphbooking.Visible = chk
            'frmListBaseIB.smnureportgraphinbound.Visible = chk


        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub mnuListConsignee_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmListConsignee, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub mnuListRefresh_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo Err_Renamed
        RefreshObjects()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub mnuListShipper_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'Dim frm As New frmListShipper
            'frm.ShowDialog(Me)
            VB6.ShowForm(frmListShipper, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub mnuSystemExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSystemExit.Click
        Me.Close()
    End Sub
    Public Sub mnuSystemLogin_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuSystemLogin.Click
        On Error GoTo Err_Renamed
        'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
        If IsDBNull(LoginSucceeded) Then
            Login()
        ElseIf LoginSucceeded Then
            Logout()
        Else
            Login()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub mnuToolBalanceCheck_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        'VB6.ShowForm(frmStatus, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Public Sub mnuToolPassword_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolPassword.Click
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        VB6.ShowForm(frmToolPassword, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub mnuToolPermissionData_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolPermissionData.Click
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        VB6.ShowForm(frmUserRightDepartment, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub mnuToolPermissionForm_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles mnuToolPermissionForm.Click
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        VB6.ShowForm(frmUserRightForm, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Function GetUserVersion() As String
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        strQuery = "SELECT CurVersion FROM UserVersion WHERE HostId = Host_Name() AND UserId = user_name() AND AppId = 'CSCL' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            GetUserVersion = ""
        Else
            'UPGRADE_WARNING: Use of Null/IsNull() detected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="2EED02CB-5C0E-4DC1-AE94-4FAA3A30F51A"'
            GetUserVersion = IIf(IsDBNull(rs.Fields("CurVersion").Value), "", rs.Fields("CurVersion").Value)
        End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:GetUserVersion")
    End Function

    Private Sub SetUserVersion(ByVal argVersion As String)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        strQuery = "SELECT CurVersion,AppId FROM UserVersion WHERE HostId = Host_Name() AND UserId = user_name() AND AppId = 'CSCL' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If rs.EOF Then
            rs.AddNew()
            rs.Fields("AppId").Value = "CSCL"
        End If
        rs.Fields("CurVersion").Value = argVersion
        rs.Update()
        rs.Close()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:SetUserVersion")
    End Sub

    Private Function GetRequiredVersion() As String
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        GetRequiredVersion = ""
        strQuery = "SELECT CParm FROM UserSetting WHERE UserId = '" & strDatabase & "' AND ParmId = 'GlobalOption.gRequiredVersion' "
        'If strconn.State <> 0 Then
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            GetRequiredVersion = IIf(IsDBNull(rs.Fields("CParm").Value), "", rs.Fields("CParm").Value)
        End If
        'End If
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:GetRequiredVersion")
        'Resume
    End Function

    Public Sub LoadTransaction(ByVal argTransId As String, ByVal argDocTypeId As String, ByVal argDocID As String, ByVal argDocDateFrom As String, ByVal argDocDateTo As String, ByVal argPeriod As String, ByVal argBalanceSheet As String, ByVal argFilter As String, ByVal argOptDate As Boolean, ByVal argOptPeriod As Boolean)
        On Error GoTo Err_Renamed
        'If FrmOpened("frmInputTransaction") Then
        'If frmInputTransaction.mStatus <> "Normal" Then
        'DisplayMessage(True, IIf(gLang = "E", "Another transaction is being updated!", "Baïn ñang caäp nhaät moät chöùng töø khaùc."))
        'Exit Sub
        'End If
        'End If
        'frmInputTransaction.Load_Renamed(argTransId, argDocTypeId, argDocID, argDocDateFrom, argDocDateTo, argPeriod, argBalanceSheet, argFilter, argOptDate, argOptPeriod)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
    End Sub

    Private Sub ToolTripMenuLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mnuSystemLogin_Click(sender, e)
    End Sub

    Private Sub ToolTripMenuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub CreativeBillOfLading()
        On Error GoTo Err_Renamed
        '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
        'If gDepartment = "OutBound" Or gDepartment = "Management" Then
        VB6.ShowForm(frmInputBillNumber, VB6.FormShowConstants.Modeless, Me)
        If gBillOfLadingNumber = "" Then
            gBillOfLadingNumber = "No BillNumber."
        End If
        Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
        'End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        '----------------------
    End Sub


    Private Sub mnuListNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If LoginSucceeded Then
            VB6.ShowForm(frmListNotify, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub

    End Sub

    Private Sub mnuListBillOfLadingMasterBase_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If gBillOfLadingNumber = "No BillNumber." Then
                DisplayMessage(True, "Alert: No Bill Of Lading.!!!")
            End If
            'Dim frm As New frmListBaseMaster
            'frm.Show()
            VB6.ShowForm(frmListBaseMaster, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListBillOfLadingMasterCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If gBillOfLadingNumber = "No BillNumber." Then
                DisplayMessage(True, "Alert: No Bill Of Lading.!!!")
            End If
            VB6.ShowForm(frmListCargoMaster, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListBillOfLadingHouseBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmListBaseHouse_Cargo, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListBillOfLadingHouseCargo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListCargoHouse, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListPreVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListPreVessel, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnunotifyvessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmNotifyVessel, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuInputContainerOutBoundNotify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuListPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListPort.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'If LoginSucceeded = True Then
            '    Dim form As New frmListPort 'frmInbound 'frmQuotationTico
            '    form.MdiParent = Me
            '    form.show()
            'End If

            VB6.ShowForm(frmListPort, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListContainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListContainer, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListPackages_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                Exit Sub
            Else
                VB6.ShowForm(frmListPackages, VB6.FormShowConstants.Modeless, Me)
            End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListPayableAt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                Exit Sub
            Else
                VB6.ShowForm(frmListPayAbleAt, VB6.FormShowConstants.Modeless, Me)
            End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListCharge.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            ' If LoginSucceeded = True Then
            'Dim form As New frmListCharge 'frmInbound 'frmQuotationTico
            'form.MdiParent = Me
            'form.Show()
            '  End If
            VB6.ShowForm(frmListCharge, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListVessel, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListSeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListSeal, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub mnuListTradeCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                Exit Sub
            Else
                VB6.ShowForm(frmTradeCode, VB6.FormShowConstants.Modeless, Me)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuLisCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub smnuCargoInBound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            frmImportInboundData.Transit = 0
            VB6.ShowForm(frmListCargoIB, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuInputDataBooking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmListBooKingData, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuNotifyVesselOutbound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'VB6.ShowForm(frmListSailingSchedule, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuReportOrientationPortrait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportOrientationPortrait.Click
        gPageSize = "Porttrait"
        Me.mnuReportOrientationPortrait.Checked = Not Me.mnuReportOrientationPortrait.Checked
        Me.mnuReportOrientationLandscape.Checked = Not Me.mnuReportOrientationPortrait.Checked

    End Sub

    Private Sub mnuReportOrientationLandscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportOrientationLandscape.Click
        gPageSize = "Landscape"
        Me.mnuReportOrientationLandscape.Checked = Not Me.mnuReportOrientationLandscape.Checked
        Me.mnuReportOrientationPortrait.Checked = Not Me.mnuReportOrientationLandscape.Checked


    End Sub

    Private Sub mnuInputDataContainers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuInputDataInBound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuCSCLBookingDailyReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmRptCSCLBooking, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuBookingSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmRptBookingSumary, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuMonitorUserOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMonitorUserOnline.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            VB6.ShowForm(frmMonitorUser, VB6.FormShowConstants.Modeless, Me)

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuGeneralReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed

        VB6.ShowForm(frmRptGeneral, VB6.FormShowConstants.Modeless, Me)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuInputData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        frmImportInboundData.Transit = 0
        VB6.ShowForm(frmImportInboundData, VB6.FormShowConstants.Modeless, Me)

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuMoreAdvanceSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMoreAdvanceSearch.Click
        On Error GoTo Err_Renamed

        If LoginSucceeded = True Then
            Dim form As New frmAdvanceSearch 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuListAgency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListAgency, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuInputLoadingPlanForVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            VB6.ShowForm(frmInputLoadingPlanForVessel, VB6.FormShowConstants.Modeless, Me)

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuPriceStandard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmPriceStandard, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListCommodity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListCommondity, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuTERMINALDEPARTURE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmBoardingAgent, VB6.FormShowConstants.Modeless, Me)

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuUserList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuUserList.Click
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        VB6.ShowForm(frmUserList, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuToolPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuToolPermission.Click

    End Sub

    Private Sub mnuHelpHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' VB6.ShowForm(frmVideo, VB6.FormShowConstants.Modeless, Me)
            'Me.HelpProvider1.HelpNamespace = "Huong dan su dung SMF.chm"
            'System.Windows.Forms.Help.ShowHelp(Me, Me.HelpProvider1.HelpNamespace)
            Dim frm As New frmThongbao
            frm.txtnoidung.Text = " Xin download theo đường dẫn http://vietnamforwarder.com/ServiceDetail.aspx?sid=14"
            frm.ShowDialog()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        'Process.Start("http://www.cscl.com.vn/iob.aspx?site=ob")
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        VB6.ShowForm(About, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub mnuReportMargins_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportMargins.Click
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        VB6.ShowForm(frmReportMargins, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPayment.Click

    End Sub

    Private Sub menuSaleSurcharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmSaleSerCharge, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuFeederVesselOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListSailingSchedule, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SmnuMotherVesselOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmListSailingScheduleMother, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub PUHAIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuInputBillNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub mnuInputContainerOutBoundOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuListShipperIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            Dim frm As New frmListShipper
            frm.ShowDialog(Me)
            'VB6.ShowForm(frmListShipper,  VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub mnuListConsigneeIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmListConsignee, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListNotifyIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoginSucceeded Then
            VB6.ShowForm(frmListNotify, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
    End Sub

    Private Sub ToolStripmenuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Me.HelpProvider1.HelpNamespace = "Huong dan su dung FMS.chm"
            System.Windows.Forms.Help.ShowHelp(Me, Me.HelpProvider1.HelpNamespace)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
        'Process.Start("http://www.cscl.com.vn/cscl.aspx?in=info")
    End Sub

    Private Sub mnuPaymentOutBound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        VB6.ShowForm(frmPayMent, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuPaymentInBound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If Not LoginSucceeded Then Exit Sub
        'VB6.ShowForm(frmPayMentIB, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputBillNumberToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CreativeBillOfLading()
    End Sub

    Private Sub EquimentCoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmContainerManagerMent, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmImportDataEquimentControl, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub smnuimportmanifesttransit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            frmImportInboundData.Transit = 1
            VB6.ShowForm(frmImportInboundData, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuDocumenttranShip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo Err_Renamed
        '        If LoginSucceeded Then
        '            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
        '            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
        '            '    Exit Sub
        '            'Else
        '            frmListBaseIB.Transit = 1
        '            VB6.ShowForm(frmListBaseIB, VB6.FormShowConstants.Modeless, Me)
        '            'End If
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnucatgotranship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            frmListCargoIB.Transit = 1
            VB6.ShowForm(frmListCargoIB, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub OutBoundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'frmListCargoIB.Transit = 1
            VB6.ShowForm(frmTransitOutbound, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputDataloadingFilexlsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'frmListCargoIB.Transit = 1
            VB6.ShowForm(frmInputDataListEquipMentControl, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'frmListCargoIB.Transit = 1
            VB6.ShowForm(frmTransitOutBoundDatabase, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuCheckReturnPlace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "Management" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'frmListCargoIB.Transit = 1
            VB6.ShowForm(frmCheckReturnPlace, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuGridFormat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuGridFormat.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmParaColor, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuReduceDEMDET_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmDemdetReduce, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmFeederMotherSchedule, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputLoadingListEmptyContToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmInputDataEmptyContainerIB, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuList.Click

    End Sub

    Private Sub mnuServiceFeeder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmListServiceFeeder, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmListLocalPic, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputDataxlsLoadingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            VB6.ShowForm(frmInputDataFullContainerIB, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuReportSurcharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmAdvanceSearChBooking, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuFreightTarrif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmFreightTariff, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuCheckContainerBookingSupply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmCheckContainerSale_Market, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub mnuSpecialFreightTariff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmSpecialFreightTariffMarket, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub MasterBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmListBaseMaster_Cargo, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub HouseBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmHouseBL_Cargo, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ChangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmBookingOrder, VB6.FormShowConstants.Modeless, Me)

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBookingSupplyOrder.Show()
    End Sub

    Private Sub mnuInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInput.Click

    End Sub

    Private Sub BookingVesselToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmBookingVessel.Show()
    End Sub

    Private Sub ReduceDEMDETToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmDemdetReduce, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub FreightTariffToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmFreightTariffMarket, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SpecialFreightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmSpecialFreightTariffMarket, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CheckEDIFormatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            VB6.ShowForm(frmCheckEDI, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '        On Error GoTo Err_Renamed
        '        If LoginSucceeded Then
        '            frmImportInboundData.Transit = 0
        '            VB6.ShowForm(frmListBaseIBEDI, VB6.FormShowConstants.Modeless, Me)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CargoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            frmImportInboundData.Transit = 0
            VB6.ShowForm(frmListCargoIBEDI, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputEDIToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        frmImportInboundData.Transit = 0
        VB6.ShowForm(frmImportInboundEDI, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub TerminalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListTerminal.Click
        On Error GoTo Err_Renamed
        frmImportInboundData.Transit = 0
        If LoginSucceeded = True Then
            Dim form As New frmTerminal 'frmInbound 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If
        'VB6.ShowForm(frmTerminal, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub HandingChargeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed

        VB6.ShowForm(frmHandlingChargeInboundTransit, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub frmFreighOutboundSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmFreightnoteSummary, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuBookingValidOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmBookingValidOrder, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuCurrency_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCurrency.Click
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCurrency, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuActualFreight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmActualFreight, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuOption.Click
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmOption, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(freightNoteSummary2, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub FreightOutboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmFreightSummaryExcel, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuInlandArbitrary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmInlandArbitray, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Tax2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmAccounting_Report, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub FormToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmAccounting_ReportDetail, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnulistofVVIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmListVVIP, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuRegLicense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuRegLicense.Click
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmRegLicense, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuTaxInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuOther.Click

    End Sub

    Private Sub AccountBankToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmAccountbank, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListBillOfLadingHouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TaxInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxInvoiceToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded = True Then
            Dim form As New frmTaxInvoice 'frmInbound 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If
        ' VB6.ShowForm(frmTaxInvoice, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PricingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub smnuServiceShipping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub smnuRateDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CarierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuCarrier.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded = True Then
            Dim form As New frmCarrier 'frmInbound 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If
        ' VB6.ShowForm(frmCarrier, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuRateDetail_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PhiếuThuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmPhieuthu, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PhiếuChiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BookingOrderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn Không Có Quyền Ở Chức Năng Này"))
            '    Exit Sub
            'Else
            ' VB6.ShowForm(frmPhieuthu, VB6.FormShowConstants.Modeless, Me)
            VB6.ShowForm(frmContainerOutBoundNotify, VB6.FormShowConstants.Modeless, Me)
            'End If

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub AgencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TrackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AlarmToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'FrmLogin.alarmReport1()
        'FrmLogin.checkAlarm1()
        'FrmLogin.checkAlarmConnecting1()
        '  Me.ListThongbao.Text = ""
        ' Timer1_Tick(sender, e)

    End Sub

    Private Sub HandlingFeeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmHandlingOutbound_new, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub HandlingFeeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmhandlingInbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ProfitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub HandlingComToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCongnoHandling, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub FreightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCongno, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CôngNợHàngXuấtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CôngNợHàngNhậpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New frmThongbao
        'frm.txtnoidung.Text = " Sorry, Chức năng này đang xây dựng."
        'frm.ShowDialog()
    End Sub

    Private Sub ProfitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim outStream As Byte() = _
        'System.Text.Encoding.ASCII.GetBytes(Me.txtinputChat.Text + "$")
        'serverStream.Write(outStream, 0, outStream.Length)
        'serverStream.Flush()
    End Sub

    Private Sub CommissionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCommissionInbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CommissionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCommissionOutbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub giayUyQuyenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmGiayUyQuyen, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchChưaThuTiềnUSDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(FrmCongnoManagement, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchĐãThuTiềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCongnoManagementDaTra, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchChưaTrảTiềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCongnoManagementKHchuaTraTien, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchĐãTrảTiềnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCongnoManagementCongTyDaTraTien, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchKháchHàngChưaThanhToánToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(FrmCongnoIBKháchHangChuaThanhToanChoCongTy, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchKháchHàngĐãThanhToánToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(FrmCongnoIBKháchHangDaThanhToanChoCongTy, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchKháchHàngCôngTyChưaThanhToánToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(FrmCongnoIBCongtyChuaThanhToanChoKhachHang, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DanhSáchKháchHàngCôngTyĐãThanhToánToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(FrmCongnoIBCongtyDaThanhToanChoKhachHang, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick


    End Sub

    Private Sub Ca6ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CấnTrừCôngNợToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCantruCongno, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CấnTrừCôngNợToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCantruCongnoInbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CấnTrừCôngNợNhậpXuấtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCantruCongnoNhapXuat, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuListBillOfLadingMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ChartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmChartOut, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ChartToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmChartIn, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub GeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ChartingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmChartProfitOut.Show()
    End Sub

    Private Sub GeneralFreightToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ChartingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmChartProfitIn.Show()
    End Sub

    Private Sub mnuMarketingSale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SeaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmThongbao
        frm.txtnoidung.Text = "Chức năng này tùy chọn, vì vậy sẽ được kích hoạt khi có yêu cầu.!"
        frm.ShowDialog()
    End Sub

    Private Sub AirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frm As New frmThongbao
        frm.txtnoidung.Text = "Chức năng này tùy chọn, vì vậy sẽ được kích hoạt khi có yêu cầu.!"
        frm.ShowDialog()
    End Sub

    Private Sub FreightListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub QContainerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QContainerToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmRPTContainer, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputBillNumberToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CreativeBillOfLading()
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BookingAir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BookingClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub QoutationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)





    End Sub

    Private Sub ToToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            VB6.ShowForm(frmTonghopThuchi, VB6.FormShowConstants.Modeless, Me)
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, msgErr(Me, Err.Description))
    End Sub

    Private Sub DocumentToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InputBillNumberToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
        'If gDepartment = "OutBound" Or gDepartment = "Management" Then
        VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
        If gBillOfLadingNumber = "" Then
            gBillOfLadingNumber = "No BillNumber."
        End If
        Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
        'End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
    End Sub

    Private Sub DocumentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DetailContainersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmDetailContainerIB, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DetailsContainerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmDetailContainerOB, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SaleToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmProfitSaleIN, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SaleToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmProfitSaleOut, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PricingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(Pricing, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ServiceShippingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmService, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RateDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmRateDetail, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ChargeDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ChargeDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DocumentToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmLogistics, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InsertLcogistToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmInsertLogistics, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ReportDoorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmReportDoor, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub GeneralToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmReportDoorGeneral, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CôngNợLogisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCongnoLogistics, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DebitCreditStatementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmBaocaoDebitCreditStatement, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuInBound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PhiếuYêuCầuXeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            VB6.ShowForm(frmPhieuyeucauxe, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub FCLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmProposalFCL, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub LCLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmProposalLCL, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub AirToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmProposalDTDAir, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub OtherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmProposalOther, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ListCoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuOutBound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuTool_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTool.Click

    End Sub

    Private Sub FreightInboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmProfitInbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub FreightOutboundToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmProfitOutbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ChargeDetailsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmChargeDetailsOut, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ChargeDetailsInboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmChargeDetailsIn, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub OutboundToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmreportOutbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmreportInbound, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub BalanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListNoDebitCreditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListNoDebitCreditToolStripMenuItem.Click
        Try
            Try
                VB6.ShowForm(frmNoDebitCredit, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckPayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmCheckpay, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteModifyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteModifyToolStripMenuItem.Click
        Try
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from billonline "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            DisplayMessage(True, "Unlock is OK..")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HoaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmHoadonvaora, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BáoCáoHóaĐơnGTGTToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBaocaohoadonGTGT, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InputRefNoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmInsertLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FreightLogisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            VB6.ShowForm(frmProfitLog, VB6.FormShowConstants.Modeless, Me)


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub LogisticsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmreportLogistics, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ListCôngNợLogisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CheckPayLogisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmCheckPayLog, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DebitCreditStatementLogisticsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBaocaoDebitCreditStatementLog, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportRatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ManualRatesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_Edit, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub QuotationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_Quotation, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ModifyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpressModify, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ZoneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_Zone, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PortToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_port, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DocumentToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCourierDocumnet, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub NonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmExpress_Rate, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExpressToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmExpress_Rate_Express, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TrackingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        VB6.ShowForm(frmtracking, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ListCo6ngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                VB6.ShowForm(frmThongbaocongnoCourier, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InboundToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OutboundToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmGraphOutbound.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub SOAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmSOA.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GeneralToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub baocaotuansale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmBaocaotuanSale.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ICMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmICM.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AirTrackingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmtrackingAir, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecordingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ShowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowToolStripMenuItem.Click
        Try
            'If ShowToolStripMenuItem.Checked = True Then
            '    ShowToolStripMenuItem.Checked = False
            '    ' Me.ListThongbao.Visible = False
            '    Me.GroupBox1.Visible = False
            'Else
            '    ShowToolStripMenuItem.Checked = True
            '    ' Me.ListThongbao.Visible = True

            ' End If
            Dim form As New frmThongbao_
            form.MdiParent = Me
            form.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CôngNợPhảiThuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmCongnoPhieuthu, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CôngNợPhảiTrảToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmcongnophieuchi, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmThongbaocongno, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmThongbaocongnoLog, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmailMarketingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BiênBảnBànGiaoChưToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBienbangiaochungtu, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BalanceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmbalance, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SetParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmSetbalance, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub doichieucongno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmDoichieuCongNoHoadon, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShipmentFollowUpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmShipmentFollowUp, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormMonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmFormMonthReport, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PaymentApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShipmentFollowDOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmShipmentFollowDO, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tonghopthuchilohangSITCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TheoDõiThuChiLôHàngSITCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WeeklyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub WeeklyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub WeeklyReportToHOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub WeeklyReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TheoDõiThuChiLôHàngPaymentSITCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WeeklyReportToHOToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub WeeklyReportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DebitCreditStatementSITCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmdebitCreditSITC, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TheoDõiThuChiLôHàngPaymentSITCToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmtheodoithuchilohanglOGISTICS, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SAPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CommissionToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmCommission, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InboundToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoginSucceeded Then
            Try
                VB6.ShowForm(frmQuotationInbound, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception
                DisplayMessage(True, msgErr(Me, Err.Description))
            End Try
            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub OutboundToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoginSucceeded Then
            Try
                VB6.ShowForm(frmQuotation, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception
                DisplayMessage(True, msgErr(Me, Err.Description))
            End Try
            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub LogisticsToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoginSucceeded Then
            Try
                VB6.ShowForm(frmQuotationLogistics, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception
                DisplayMessage(True, msgErr(Me, Err.Description))
            End Try
            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub ModifyTableToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyTableToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmModify, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmImportTariff, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OutboundToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmweeklyreportoutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InboundToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmweeklyreportInbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmweeklyreportLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InboundToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmweeklyreportInboundToHO, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OutboundToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmweeklyreportOutboundToHO, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmweeklyreportOutboundToHOlogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportRatesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmExpress_Rate_Express, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ManualRatesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_Edit, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub QuotationToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_Quotation, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ModifyToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpressModify, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ZoneToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_Zone, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PortToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmExpress_port, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DocumentToolStripMenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmCourierDocumnet, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub MonthlyReportForSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmMonthlyReportForSale, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub bangkeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmBaocaoBangkeProject, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mauthanhtoanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmpaymentApproveProject, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub tonghopthuchi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmtonghopThuChiCothueProject, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub TổngHợpThuChiUSDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmtonghopthuchiUSDproject, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub HạnCôngNợToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HạnCôngNợToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmhancongnohoadon 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmhancongnohoadon, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LCLToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BravoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBravo, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MonthlyReportOfOutsourcingShippingServiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmMonthlyReportofoutsourcingshippingservice, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuotationforCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If LoginSucceeded Then
            Try
                VB6.ShowForm(frmProposol, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception
                DisplayMessage(True, msgErr(Me, Err.Description))
            End Try
            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub Ba3ngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ba3ngToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBaocaohoadonGTGT 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            'VB6.ShowForm(frmBaocaohoadonGTGT, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BravoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BravoToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBravo 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmBravo, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SAPToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAPToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmSAP 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '   VB6.ShowForm(frmSAP, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhiếuChiPaymentApprovalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ĐốiChiếuCôngNợHóaĐơnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MonthlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBODMonthlyReport, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MonthlyReportSALESEXECUTIVEREPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhiếuThuReceiptVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BalanceToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmbalance, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            VB6.ShowForm(frmTonghopThuchi, VB6.FormShowConstants.Modeless, Me)
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, msgErr(Me, Err.Description))
    End Sub

    Private Sub BáoCáoLợiNhuậnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BáoCáoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBaocaotongsoshipment, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BáoCáoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                VB6.ShowForm(frmDoichieuCongNoHoadon, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BáoCáoTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmdoichieucongnoHoadonTong, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BáoCáoLợiNhuậnTừngSaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmMonthlySaleExecutive, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CustomerDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmDatabaseCus, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TổngChiTrongThángToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PhiếuChiPaymentVoucherToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhiếuChiPaymentVoucherToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        If LoginSucceeded = True Then
            Dim form As New frmPhieuchi 'frmInbound 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If
        'VB6.ShowForm(frmPhieuchi, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PhiếuThuReceiptVoucherToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhiếuThuReceiptVoucherToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmPhieuthu 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '   VB6.ShowForm(frmPhieuthu, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ParameterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmSetbalance, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BalanceToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmbalance, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TổngHợpThuChiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TổngHợpThuChiToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then

            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            If LoginSucceeded = True Then
                Dim form As New frmTonghopThuchi 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '   VB6.ShowForm(frmTonghopThuchi, VB6.FormShowConstants.Modeless, Me)
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, msgErr(Me, Err.Description))
    End Sub

    Private Sub TổngChiTrongThángToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmTongchi, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripContainer1_ContentPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContentPanel.Load

    End Sub

    Private Sub ToolStripContainer1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            Dim webAddress As String = "http://www.willlogistics.com.vn/"
            Process.Start(webAddress)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub












    Private Sub mnuBOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReport.Click

    End Sub

    Private Sub OutboundToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InboundToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub LogisticsToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ConsolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frminsertSILCL, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BookingToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn Không Có Quyền Ở Chức Năng Này"))
            '    Exit Sub
            'Else
            ' VB6.ShowForm(frmPhieuthu, VB6.FormShowConstants.Modeless, Me)
            'VB6.ShowForm(frmBookingAgent, VB6.FormShowConstants.Modeless, Me)
            'End If
            If LoginSucceeded = True Then
                Dim form As New frmBookingAgent
                form.MdiParent = Me
                form.Show()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InsertReferenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmInsertLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InputBillNumberToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DocumentToolStripMenuItem3_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TheoDõiThuChiLôHàngPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InputBillNumberToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
        'If gDepartment = "OutBound" Or gDepartment = "Management" Then
        VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
        If gBillOfLadingNumber = "" Then
            gBillOfLadingNumber = "No BillNumber."
        End If
        Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
        'End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
    End Sub

    Private Sub DocumentToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TheoDõiThuChiLôHàngPaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ShipmentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmMonthlySaleExecutive_onlysale, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CôngNợĐạiLýToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmdebitCreditSITC, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SOAToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            frmSOA.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CommissionToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmCommission, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecordingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnurecording.Click

    End Sub

    Private Sub SaleCodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaleCodeToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If LoginSucceeded = True Then
                Dim form As New frmListSale
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmListSale, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CommodityToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CommodityToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If LoginSucceeded = True Then
                Dim form As New frmListCommondity 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmListCommondity, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub MarketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MarketToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If LoginSucceeded = True Then
                Dim form As New frmListMarket 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmListMarket, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CustomerDatabaseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerDatabaseToolStripMenuItem1.Click
        Try
            ' VB6.ShowForm(frmDatabaseCus, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmDatabaseCus
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgentListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AgentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmAgentReport, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsQuotationCostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmLogisticsQuotation, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchQuotationCostToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmSearchQuotationCode, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsPartnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub PricingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(Pricing, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RateDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmRateDetail, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ServiceShippingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmService, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmInsertLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SalesTargetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesTargetToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmSaleTarget, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreditParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditParameterToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmChiphiCodinh, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaleBonusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmSaleProfitBonus, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheduleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' VB6.ShowForm(frmlinkchedule, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



    Private Sub LogisticsContractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub




    Private Sub ShowListShipmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BáoCáoLợiNhuậnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBaocaoloinhuan, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MainMenu1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MainMenu1.ItemClicked

    End Sub

    Private Sub MessageFromBookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub MessageFromBookingDocumentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmMessageFromBookingDoc, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TheoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmtheodoithuchilohanglOGISTICS, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CoToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmTatcaCongNoDaiLy, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PendingListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub FCLToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'VB6.ShowForm(frmTariffSeaFCL, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffSeaFCL 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LCLToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' VB6.ShowForm(frmTariffSeaLCLInbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffSeaLCLInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FCLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  VB6.ShowForm(frmTariffSeaFCLOutbound, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmTariffSeaFCLOutbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LCLToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  VB6.ShowForm(frmtariffSealclOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtariffSealclOutbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '  VB6.ShowForm(frmTariffAirImport, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffAirImport 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' VB6.ShowForm(frmTariffAirExport, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffAirExport 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub LiabilitiesAgentCôngNợĐạiLýToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmdebitCreditSITC, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LiabilitiesAllOfAgencyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmTatcaCongNoDaiLy, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            DisplayMessage(True, "Please contact with administrator.")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BackupToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Public Sub ExportDataToFile(ByVal strSourceServer As String, ByVal strBakFileName As String, ByVal WindowsAuth As Boolean, ByVal strUsername As String, ByVal strPassword As String, ByVal strDatabase As String)
        'Dim sourceConnectionString As String = Nothing

        'If WindowsAuth = True And strDatabase <> "" Then
        '    sourceConnectionString = "Data Source='" & strSourceServer & "';initial catalog='" & strDatabase & "';Trusted_Connection=True;"
        'ElseIf WindowsAuth = True And strDatabase = "" Then
        '    sourceConnectionString = "Data Source='" & strSourceServer & "';Trusted_Connection=True;"
        'Else
        '    sourceConnectionString = "Data Source='" & strSourceServer & "';initial catalog='" & strDatabase & "';user id='" & strUserName & "';password='" & strPassword & "'"
        'End If

        'Dim sourceConnBuilder As New SqlConnectionStringBuilder(sourceConnectionString)

        'Dim serverConnection As ServerConnection
        'If sourceConnBuilder.IntegratedSecurity Then
        '    serverConnection = New ServerConnection(sourceConnBuilder.DataSource)

        '    ' Windows Authentication
        '    serverConnection.LoginSecure = True
        'Else
        '    serverConnection = New ServerConnection(sourceConnBuilder.DataSource, sourceConnBuilder.UserID, sourceConnBuilder.Password)
        'End If

        'server = New Server(serverConnection)
        'Dim database As Database = server.Databases(sourceConnBuilder.InitialCatalog)

        ''Reference the AdventureWorks2012 database.
        'database = server.Databases(strDatabase)

        ''Store the current recovery model in a variable.
        'Dim recoverymod As Integer
        'recoverymod = database.DatabaseOptions.RecoveryModel

        ''Define a Backup object variable. 
        'Dim bk As New Backup

        ''Specify the type of backup, the description, the name, and the database to be backed up.
        'bk.Action = BackupActionType.Database
        'bk.BackupSetDescription = "Full backup of ReviewInsight " & strDatabase & " Database"
        'bk.BackupSetName = strDatabase & " Backup"
        'bk.Database = strDatabase
        'bk.PercentCompleteNotification = 10

        'AddHandler bk.PercentComplete, AddressOf BackupProgressEvent

        ''Declare a BackupDeviceItem by supplying the backup device file name in the constructor, and the type of device is a file.
        'Dim bdi As BackupDeviceItem
        'bdi = New BackupDeviceItem(strBakFileName, DeviceType.File)

        ''Add the device to the Backup object.
        'bk.Devices.Add(bdi)

        ''Set the Incremental property to False to specify that this is a full database backup.
        'bk.Incremental = False

        ''Specify that the log must be truncated after the backup is complete.
        'bk.LogTruncation = BackupTruncateLogType.Truncate

        ''Run SqlBackup to perform the full database backup on the instance of SQL Server.
        'bk.SqlBackup(server)

        ''Remove the backup device from the Backup object.
        'bk.Devices.Remove(bdi)

        ''Set the database recovery mode back to its original value.
        'server.Databases(strDatabase).DatabaseOptions.RecoveryModel = recoverymod

        ''Inform the user that the backup has been completed.
        'MsgBox("Full Backup complete.")
        'objFrmBackup.ProgressBar1.Value = 0
    End Sub

    Private Sub GeneralProfitReportHouseBillToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmbaocaoloinhuan_hbl, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub HouseProfitAndLossSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmHouseProfitLoss, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ListChargesPaidNotPaidWoojinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmlistchargesPaid, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GeneralProfitReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmGeneralProfitReportWoojin, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuotationToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuotationToolStripMenuItem1.Click
        Try
            'VB6.ShowForm(frmQuotationTico, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub DebitCreditStatementToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmBaocaoDebitCreditStatement, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            gNhom = "SOC"

            gtext = "Shipper Owned Containers Import"
            gStatus = True
            gNgay = True

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            Dim frm As New frmInputBillInbound
            frm.Show()

            ' VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)

            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try

    End Sub

    Private Sub DocumentToolStripMenuItem2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            If LoginSucceeded Then
                gNhom = "SOC"
                gtext = "Shipper Owned Containers Import"
                gStatus = True
                gNgay = True
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                Dim frm As New frmInbound
                frm.Show()



            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub

    Private Sub DetailsSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gNhom = "SOC"
            gtext = "Shipper Owned Containers Import"
            gStatus = True
            gNgay = True

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohang") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            gPrintInbound = "Inbound"
            VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DocumentToolStripMenuItem5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DetailsSheetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CreateRefToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DocumentToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DetailsSheetToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub AlertFromBookingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmMessageFromBooking, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub



    Private Sub AgentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgentToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        If LoginSucceeded = True Then
            Dim form As New frmListAgency 'frmInbound 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If
        '  VB6.ShowForm(frmListAgency, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        If LoginSucceeded Then

            If LoginSucceeded = True Then
                Dim form As New frmQuotation
                form.MdiParent = Me
                form.Show()
            End If

            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub ImportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportToolStripMenuItem1.Click
        If LoginSucceeded Then
            'Try
            '    VB6.ShowForm(frmQuotationInbound, VB6.FormShowConstants.Modeless, Me)
            'Catch ex As Exception
            '    DisplayMessage(True, msgErr(Me, Err.Description))
            'End Try
            If LoginSucceeded = True Then
                Dim form As New frmQuotationInbound
                form.MdiParent = Me
                form.Show()
            End If

            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub CustomsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomsToolStripMenuItem1.Click
        If LoginSucceeded Then
            'Try
            '    VB6.ShowForm(frmQuotationLogistics, VB6.FormShowConstants.Modeless, Me)
            'Catch ex As Exception
            '    DisplayMessage(True, msgErr(Me, Err.Description))
            'End Try
            If LoginSucceeded = True Then
                Dim form As New frmQuotationLogistics
                form.MdiParent = Me
                form.Show()
            End If
            'Dim frm As New frmChicilonVattuThietbi
            'frm.ShowDialog(Me)
            'frm.Dispose()
            'DisplayMessage(True, "Chức năng làm báo giá không tích hợp trong SMF, nếu quý công ty có nhu cầu xin liên hệ : 0908 349945. Xin cảm ơn.")
            'VB6.ShowForm(frmSMF_Quotation, VB6.FormShowConstants.Modeless, Me)
        End If
    End Sub

    Private Sub ImportToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmImportSchedule 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmImportSchedule, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ModifyToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' VB6.ShowForm(frmModifySchedule, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmModifySchedule 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PendingListToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmListPending, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub PartnerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmLogisticsPartner, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogisticsContractToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogisticsContractToolStripMenuItem1.Click
        Try
            '  VB6.ShowForm(frmLogisticsContractPrice, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmLogisticsContractPrice 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShowBookingMonthToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowBookingMonthToolStripMenuItem.Click
        Try
            ' VB6.ShowForm(frmShowBookingInMonth, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded Then
                ' VB6.ShowForm(frmDuyetDNTT, VB6.FormShowConstants.Modeless, Me)
                Dim form As New frmShowBookingInMonth
                form.MdiParent = Me
                form.Show()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            VB6.ShowForm(frmInputBillInbound_OverSeaSeaImport, VB6.FormShowConstants.Modeless, Me)
            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded Then

                VB6.ShowForm(frmInbound_OverseaSeaimport, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DetailsSheetToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            gPrintInbound = "Inbound_OverseaseaImport"
            VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            VB6.ShowForm(frmInputBillInbound_OverSeaAirImport, VB6.FormShowConstants.Modeless, Me)
            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SheetDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ExportToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InsertRefToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            VB6.ShowForm(frmInputBillInbound_OverSeaSeaExport, VB6.FormShowConstants.Modeless, Me)
            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem3_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmOutbound_OverseaSeaExport, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SheetDetailsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gPrintOutbound = "Outbound_OverseaSeaExport"
            VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub DocumentToolStripMenuItem4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub









    Private Sub SheetDetailsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub SheetDetailsToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InsertRefToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            VB6.ShowForm(frmInputBillInbound_ACSSeaExport, VB6.FormShowConstants.Modeless, Me)
            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            VB6.ShowForm(frmOutbound_ACSSeaExport, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SheetDetailsToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gPrintOutbound = "Outbound_ACSSeaExport"
            VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmInsertLogistics_Truck, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmLogistics_Truck, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SheetDetailsToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        gPrintLogistics = "Logistics_Truck"
        VB6.ShowForm(frmtheodoithuchilohanglOGISTICS, VB6.FormShowConstants.Modeless, Me)
    End Sub

    Private Sub ContainerListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmListContainerSOC 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            'VB6.ShowForm(frmListContainerSOC, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub INToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmStockIn, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OUTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmStockOut, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InventoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmInventory_Tico 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmInventory_Tico, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WeeklyReportToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeeklyReportToolStripMenuItem.Click
        Try

            If LoginSucceeded = True Then
                Dim form As New frmAgentReport 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

            'VB6.ShowForm(frmAgentReport, VB6.FormShowConstants.Modeless, Me) 'frmWeeklyReport
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SOAYAMATOToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmSOAYamato, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DebitNoteDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DebitNoteDetailsToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmDebitFromTo, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SOAGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOAGeneralToolStripMenuItem.Click
        Try

            If LoginSucceeded = True Then
                Dim form As New frmSOAGeneral 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


            ' VB6.ShowForm(frmSOAGeneral, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BuyingContractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuyingContractToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmLogisticsContractCost 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmLogisticsContractCost, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub InsertRefToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            gNhom = "ACS-AIR-IMPORT"

            VB6.ShowForm(frmInputBillInbound_OverSeaAirImport, VB6.FormShowConstants.Modeless, Me)
            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded Then
                ' gNhom = "ACS-AIR-IMPORT"
                If LoginSucceeded = True Then
                    Dim form As New frmInbound_OverseaAirImport 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound_OverseaAirImport, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gAir = "ACS-AIR-IMPORT"
            gPrintInbound = "inbound_OverseaAirImport"
            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

            '    VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CreativeBillOfLading()
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        gNhom = "ACS-AIR-EXPORT"
        VB6.ShowForm(frmInputOutbound_OverseaAirExport, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DocumentToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            'gNhom = "ACS-AIR-EXPORT"
            If LoginSucceeded = True Then
                Dim form As New frmOutbound_OverseaAirExport 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmOutbound_OverseaAirExport, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SheetDetailsToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gAir = "ACS-AIR-EXPORT"
            gPrintOutbound = "Outbound_OverseaAirExport"
            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateRefToolStripMenuItem3.Click
        Try
            gNhom = "LOGISTICS-CUSTOMS"
            VB6.ShowForm(frmInsertLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem1_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DocumentToolStripMenuItem1.Click
        Try
            gNhom = "LOGISTICS-CUSTOMS"
            If LoginSucceeded = True Then
                Dim form As New frmLogistics 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmLogistics, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SheetDetailsToolStripMenuItem.Click
        Try
            gPrintLogistics = "Logistics"
            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohanglOGISTICS 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmtheodoithuchilohanglOGISTICS, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PendingListToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        VB6.ShowForm(frmListPending, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub CustomerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem1.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            If LoginSucceeded = True Then
                Dim form As New frmListCustomer 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '     VB6.ShowForm(frmListCustomer, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub StatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            VB6.ShowForm(frmInputContainerStatus, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub InventoryDetailsReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmInventoryDetailsReport, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhiếuĐềNghịThanhToánToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PhiếuĐềNghịThanhToánToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmPhieudenghithanhtoan 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '  VB6.ShowForm(frmPhieudenghithanhtoan, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DOMReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DOMReportToolStripMenuItem.Click
        Try
            VB6.ShowForm(frmDOMReport, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DebitNoteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmDebitMasan, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipboardCustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClipboardCustomerToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmSelectCustomer 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmSelectCustomer, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhiếuĐềNghịHoànỨngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmPhieuDeNghiHoanUng, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhiếuĐềNghịTạmỨngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuTamungHoanung.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmPhieuDeNghiTamUng 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '   VB6.ShowForm(frmPhieuDeNghiTamUng, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormTheoDõiHĐVCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmHDVC, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DebitNoteBToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmDebitChitiet, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportListContainersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            VB6.ShowForm(frmListExportContainer, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookingCarrierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmContainerOutBoundNotify 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '   VB6.ShowForm(frmContainerOutBoundNotify, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem6.Click

    End Sub

    Private Sub AgencyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AgencyToolStripMenuItem1.Click

    End Sub

    Private Sub CôngNợKháchHàngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CôngNợKháchHàngToolStripMenuItem.Click

    End Sub

    Private Sub CôngNợNhàCungCấpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CôngNợNhàCungCấpToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmCongnoNCC 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmCongnoNCC, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ThoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThoToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmReportKPI 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmReportKPI, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RecordingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecordingToolStripMenuItem.Click
        Try
            'VB6.ShowForm(FrmRecording, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New FrmRecording 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OpenWordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            ' VB6.ShowForm(frmquotationWord, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuotationToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CreateRefToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CreativeBillOfLading()
        Try

            gNhom = "AGENCY-EXPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            Dim frm As New frmInputOutbound
            frm.Show()



            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub DocumentToolStripMenuItem_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()
                ' gNhom = "AGENCY-EXPORT"

                gtext = "Export (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                ' Dim frm As New frmOutbound
                ' frm.Show()

                If LoginSucceeded = True Then
                    Dim form As New frmOutbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub SheetDetailsToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'gNhom = "Agency-Export"
            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub SheetDetailsToolStripMenuItem2_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                gNhom = "Agency-Import"
                gtext = "Carrier Own Container (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                '   VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem3_Click_4(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try



            If LoginSucceeded Then

                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub

    Private Sub CreateRefToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            gNhom = "COCHK"

            gtext = "Carrier Own Container (HongKong)"
            gStatus = True
            gNgay = True

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            Dim frm As New frmInputBillInbound
            frm.Show()



            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try

    End Sub

    Private Sub DocumentToolStripMenuItem4_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try



            If LoginSucceeded Then

                gNhom = "COCHK"
                gtext = "Carrier Own Container (HongKong)"
                gStatus = True
                gNgay = True
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                Dim frm As New frmInbound
                frm.Show()

                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub

    Private Sub SheetDetailsToolStripMenuItem3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                gNhom = "COCHK"
                gtext = "Carrier Own Container (HongKong)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem5_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try


            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()
                gNhom = "COCHK"

                gtext = "Carrier Own Container (HongKong)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                Dim frm As New frmOutbound
                frm.Show()
                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CreativeBillOfLading()
        Try

            gNhom = "COCHK"

            gtext = "Carrier Own Container (HongKong)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            Dim frm As New frmInputOutbound
            frm.Show()



            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            gNhom = "COCHK"
            gtext = "Carrier Own Container (HongKong)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportEmptyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded Then
                VB6.ShowForm(frmExportEmpty, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FullToConsigneeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmFullToConsignee 'frmInbound 'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If
                    ' VB6.ShowForm(frmFullToConsignee, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyToDepotToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmEmptyToDepot 'frmInbound 'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If
                    '  VB6.ShowForm(frmEmptyToDepot, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SOCReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SOCReportToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                VB6.ShowForm(frmSOCReport, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContainerStatusReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContainerStatusReportToolStripMenuItem.Click
        Try

            If LoginSucceeded = True Then
                Dim form As New frmReportChitietthuchi_container 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub COCProfitReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COCProfitReportToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                '  VB6.ShowForm(frmReportOversea, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportOversea 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub OverseaReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OverseaReportToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                '  VB6.ShowForm(frmReportOversea, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportOversea_mbl 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportSales 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmreportChiTietThuChi 'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If

                    ' VB6.ShowForm(frmreportChiTietThuChi, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AgencyToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Export511ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Export511ToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frm511301 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frm511301, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Export3331ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Export3331ToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                'If LoginSucceeded = True Then
                '    Dim form As New frm3331 'frmInbound 'frmQuotationTico
                '    form.MdiParent = Me
                '    form.Show()
                'End If
                '   VB6.ShowForm(frm3331, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SốDưToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SốDưToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmSodu 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '   VB6.ShowForm(frmSodu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BossApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BossApprove.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBossApprove 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '   VB6.ShowForm(frmBossApprove, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AccApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccApprove.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmKTT 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '     VB6.ShowForm(frmKTT, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub smnuxecontainer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuxecontainer.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmListXeContainer 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmListXeContainer, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuromooc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuromooc.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmListRomooc 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '     VB6.ShowForm(frmListRomooc, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub SổQuỹToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SổQuỹToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmbalance 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmbalance, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckPaymentToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmCheckPayment 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '   VB6.ShowForm(frmCheckPayment, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TheoDõiNợNhiênLiệuLáiXeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub QuyếtToánNhiênLiệuTiềnLươngLáiXeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmQuyettoannhienlieu 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmQuyettoannhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NhậtKýTruckingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NhậtKýTruckingToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBangkeTrucking 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                ' VB6.ShowForm(frmBangkeTrucking, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesChartToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesChartToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmSalesReportChart 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmSalesReportChart, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Ba1oToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ba1oToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBaocaosanluongtheotuyen 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                ' VB6.ShowForm(frmBaocaosanluongtheotuyen, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DebitNoteToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DebitNoteToolStripMenuItem.Click
        Try
            'If LoginSucceeded Then
            '    If LoginSucceeded = True Then
            '        Dim form As New frmDebit 'frmInbound 'frmQuotationTico
            '        form.MdiParent = Me
            '        form.Show()
            '    End If
            '    ' VB6.ShowForm(frmDebit, VB6.FormShowConstants.Modeless, Me)
            'End If
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmExportLemon 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmMISA, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngKêTạmỨngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BảngKêTạmỨngToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBangketamung 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmBangketamung, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BiênBảnBànGiaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BiênBảnBànGiaoToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmPrintBiennhanhoso 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmPrintBiennhanhoso, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BookingReportToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmBookingReport 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmBookingReport, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportMISAToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportMISAToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmMISA 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmMISA, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub smnuTamung_Click(sender As Object, e As EventArgs) Handles smnuTamung.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmPhieuDeNghiTamUng 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmPhieuDeNghiTamUng, VB6.FormShowConstants.Modeless, Me)

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngKêTạmỨngĐượcDuyệtToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BảngKêTạmỨngĐượcDuyệtToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmBangketamung_nhanvien, VB6.FormShowConstants.Modeless, Me)
                Dim form As New frmBangketamung_nhanvien
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DNTTD9u7o7ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DNTTD9u7o7ToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmDuyetDNTT, VB6.FormShowConstants.Modeless, Me)
                Dim form As New frmDuyetDNTT
                form.MdiParent = Me
                form.Show()

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckPaybảngKêTạmỨngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckPaybảngKêTạmỨngToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmbangketamung_ketoan 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                '  VB6.ShowForm(frmbangketamung_ketoan, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bang3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Bang3ToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmReportChitietthuchi_soc 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                '  VB6.ShowForm(frmReportChitietthuchi_soc, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GeneralReportBa1oCaoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GeneralReportBa1oCaoToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmReportChitietthuchi_soc_Phi 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmReportChitietthuchi_soc_Phi, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TargetProfitSalesBonusToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TargetProfitSalesBonusToolStripMenuItem.Click
        Try
            If LoginSucceeded Then

                If LoginSucceeded = True Then
                    Dim form As New frmSaleProfitBonus 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If


                '  VB6.ShowForm(frmSaleProfitBonus, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuotationToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles QuotationToolStripMenuItem.Click

    End Sub

    Private Sub ToolTripMenuLogin_Click_1(sender As Object, e As EventArgs)
        Try
            mnuSystemLogin_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolTripMenuExit_Click_1(sender As Object, e As EventArgs)
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AlertFromDocumentMonthToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlertFromDocumentMonthToolStripMenuItem.Click
        If LoginSucceeded = True Then
            Dim form As New frmShipments  'frmQuotationTic
            form.MdiParent = Me
            form.Show()
        End If
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmcheckdntt  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem2.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CarrierOwnContainerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarrierOwnContainerToolStripMenuItem.Click

    End Sub

    Private Sub BảngToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BảngToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem2.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportSmartProToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSmartProToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmSmartPro 'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SalesReportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SalesReportToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmReportSales 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LocalChargesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmLocalCharges 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyToShipperToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmEmptytoShipper  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FullToAtQuayToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmFullToAtQuay   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SearchContainerNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchContainerNoToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmSearchBillFromCont   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateOnBoardToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmOnboard   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadingListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadingListToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmLoadinglist  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DischargesListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmDischargesList   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PackingListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PackingListToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmPackinglist   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LocalChargesToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmLocalChargesPT 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Ke61ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Ke61ToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmKehoachdieuxe  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TheoDõiNợNhiênLiệuLáiXeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TheoDõiNợNhiênLiệuLáiXeToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmTheodoinhienlieu 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmQuyettoannhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuyếtToánNhiênLiệuTiềnLươngLáiXeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuyếtToánNhiênLiệuTiềnLươngLáiXeToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmQuyettoannhienlieu 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmQuyettoannhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TạmỨngNhiênLiệuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TạmỨngNhiênLiệuToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frm 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmQuyettoannhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DischargesListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DischargesListToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmDischargeList  'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmPhieutamungxangdau, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ArrivalIFDToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmListContainerArrival 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                'VB6.ShowForm(frmListContainerSOC, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyToAtQuayOEOToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Try
                If LoginSucceeded Then
                    ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                    If LoginSucceeded = True Then
                        Dim form As New frmEmptyToAtQuay   'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TạmỨngNhiênLiệuToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TạmỨngNhiênLiệuToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmPhieutamungxangdau 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmPhieutamungxangdau, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuyếtToánNhiênLiệuTiềnLươngLáiXeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles QuyếtToánNhiênLiệuTiềnLươngLáiXeToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmQuyettoannhienlieu 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmQuyettoannhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TheoDõiNợNhiênLiệuLáiXeToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles TheoDõiNợNhiênLiệuLáiXeToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmTheodoinhienlieu 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChiPhíToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChiPhíToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmRef_ChiphiPhanbo 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NhậtKýSửaChữaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhậtKýSửaChữaToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmNhatkysuachua 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmthongkeShipmentprofit
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ShipOrderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShipOrderToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmContainerOutBoundNotify
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChỉTiêuKhấuHaoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ChỉTiêuKhấuHaoToolStripMenuItem1.Click

    End Sub

    Private Sub NhaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NhaToolStripMenuItem.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub StockInNhậpKhoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmNhapkho

                    form.MdiParent = Me
                    form.Show()
                End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub StockOutXuấtKhoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub InventoryTồnKhoToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub AreaPhânKhuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AreaPhânKhuToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmVung
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WHouseKhoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WHouseKhoToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmwarehouse
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DãyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DãyToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmDay
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LocationViTríToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocationViTríToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmVitri
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmChiPhiPhanBoChoOutbound  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhânBổChiPhíHàngConsolToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ClipsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClipsToolStripMenuItem.Click
        Try
            Dim url As String = "https://youtu.be/akrFQVbOESs"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Try
            Dim url As String = "https://youtu.be/hsxzqpTwxi4"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipsToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ClipsToolStripMenuItem2.Click
        Try
            Dim url As String = "https://youtu.be/0Aw0HvfQz0E"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipsToolStripMenuItem3_Click(sender As Object, e As EventArgs)
        Try
            Dim url As String = "https://youtu.be/3Isj7sAPd3Q"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipsToolStripMenuItem4_Click(sender As Object, e As EventArgs)
        Try
            Dim url As String = "https://youtu.be/QMRlZOAxZuI"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub CargoReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargoReceiptToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmCargoReceipt  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem3.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmImportSchedule 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmImportSchedule, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ModifyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModifyToolStripMenuItem1.Click
        Try
            ' VB6.ShowForm(frmModifySchedule, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmModifySchedule 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FCLToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles FCLToolStripMenuItem2.Click
        Try
            'VB6.ShowForm(frmTariffSeaFCL, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffSeaFCL 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LCLToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles LCLToolStripMenuItem2.Click
        Try
            ' VB6.ShowForm(frmTariffSeaLCLInbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffSeaLCLInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FCLToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles FCLToolStripMenuItem3.Click
        Try
            '  VB6.ShowForm(frmTariffSeaFCLOutbound, VB6.FormShowConstants.Modeless, Me)
            If LoginSucceeded = True Then
                Dim form As New frmTariffSeaFCLOutbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LCLToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles LCLToolStripMenuItem3.Click
        Try
            '  VB6.ShowForm(frmtariffSealclOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtariffSealclOutbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem10.Click
        Try
            '  VB6.ShowForm(frmTariffAirImport, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffAirImport 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem2.Click
        Try
            ' VB6.ShowForm(frmTariffAirExport, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmTariffAirExport 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ItemsTheoTừngPhíToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsTheoTừngPhíToolStripMenuItem.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmLocalCharges 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LocalChargesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles LocalChargesToolStripMenuItem2.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmLocalChargesPT 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ContainerListToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ContainerListToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmListContainerSOC 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            'VB6.ShowForm(frmListContainerSOC, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ArrivalIFDToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ArrivalIFDToolStripMenuItem1.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmListContainerArrival 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                'VB6.ShowForm(frmListContainerSOC, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FullToConsigneeDCOToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FullToConsigneeDCOToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmFullToConsignee 'frmInbound 'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If
                    ' VB6.ShowForm(frmFullToConsignee, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyToDepotEMMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmptyToDepotEMMToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded Then
                    If LoginSucceeded = True Then
                        Dim form As New frmEmptyToDepot 'frmInbound 'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If
                    '  VB6.ShowForm(frmEmptyToDepot, VB6.FormShowConstants.Modeless, Me)
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InventoryReportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles InventoryReportToolStripMenuItem1.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmInventory_Tico 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmInventory_Tico, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DateOnBoardBFFToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DateOnBoardBFFToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmOnboard   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyToAtQuayOEOToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EmptyToAtQuayOEOToolStripMenuItem2.Click
        Try
            Try
                If LoginSucceeded Then
                    ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                    If LoginSucceeded = True Then
                        Dim form As New frmEmptyToAtQuay   'frmQuotationTico
                        form.MdiParent = Me
                        form.Show()
                    End If
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FullToAtQuayOFOToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FullToAtQuayOFOToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmFullToAtQuay   'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EmptyToShipperDSOToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmptyToShipperDSOToolStripMenuItem1.Click
        Try
            If LoginSucceeded Then
                ' VB6.ShowForm(frmReportSales, VB6.FormShowConstants.Modeless, Me)
                If LoginSucceeded = True Then
                    Dim form As New frmEmptytoShipper  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem2.Click

    End Sub

    Private Sub LogisticsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LogisticsToolStripMenuItem.Click

    End Sub

    Private Sub PhânBổChiPhíHàngConsolToolStripMenuItem2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub SheetDetailsToolStripMenuItem7_Click_1(sender As Object, e As EventArgs)
        Try
            Try
                gNhom = "Agency-Import"
                gtext = "Carrier Own Container (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                '   VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem8_Click(sender As Object, e As EventArgs)
        Try
            Try
                gNhom = "Agency-Import"
                gtext = "Carrier Own Container (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                '   VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem9_Click(sender As Object, e As EventArgs)
        Try
            Try
                gNhom = "Agency-Import"
                gtext = "Carrier Own Container (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                '   VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem5_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub CreateRefToolStripMenuItem6_Click(sender As Object, e As EventArgs)
        Try
            gFLC = "L"
            gSC = "C"
            '----

            gNhom = "AGENCY-IMPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            'Dim frm As New frmInputBillInbound
            'frm.Show()
            If LoginSucceeded = True Then
                Dim form As New frmInputBillInbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem7_Click(sender As Object, e As EventArgs)
        Try
            gFLC = "C"
            gSC = "C"
            '----

            gNhom = "AGENCY-IMPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            'Dim frm As New frmInputBillInbound
            'frm.Show()
            If LoginSucceeded = True Then
                Dim form As New frmInputBillInbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem5_Click_3(sender As Object, e As EventArgs)
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub DocumentToolStripMenuItem6_Click_1(sender As Object, e As EventArgs)
        Try



            If LoginSucceeded Then
                '---
                gFLC = "L"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub CreateRefJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateRefJobToolStripMenuItem.Click
        'CreativeBillOfLading()
        Try
            gFLC = "F"
            gSC = "C"
            '----
            gNhom = "AGENCY-EXPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            'Dim frm As New frmInputOutbound
            'frm.Show()
            If LoginSucceeded = True Then
                Dim form As New frmInputOutbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub AirToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles AirToolStripMenuItem.Click

    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem7.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem10_Click(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem10.Click
        Try
            'gNhom = "Agency-Export"
            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem7.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem13.Click
        Try
            gAir = "ACS-AIR-IMPORT"
            gPrintInbound = "inbound_OverseaAirImport"
            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

            '    VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem13_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem13.Click
        Try
            If LoginSucceeded Then
                ' gNhom = "ACS-AIR-IMPORT"
                If LoginSucceeded = True Then
                    Dim form As New frmInbound_OverseaAirImport 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound_OverseaAirImport, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InsertRefJobToolStripMenuItem.Click
        Try
            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            gNhom = "ACS-AIR-IMPORT"
            If LoginSucceeded = True Then
                Dim form As New frmInputBillInbound_OverSeaAirImport 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '  VB6.ShowForm(frmInputBillInbound_OverSeaAirImport, VB6.FormShowConstants.Modeless, Me)
            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsertRefToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles InsertRefToolStripMenuItem.Click
        'CreativeBillOfLading()
        On Error GoTo Err_Renamed
        'DisplayMessage(True, "Đang xây dựng....")
        gNhom = "ACS-AIR-EXPORT"
        If LoginSucceeded = True Then
            Dim form As New frmInputOutbound_OverseaAirExport 'frmInbound 'frmQuotationTico
            form.MdiParent = Me
            form.Show()
        End If
        'VB6.ShowForm(frmInputOutbound_OverseaAirExport, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub DocumentToolStripMenuItem3_Click_5(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem3.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded Then
            'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
            '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
            '    Exit Sub
            'Else
            'Dim frm As New frmListBaseHouse_Cargo
            'frm.Show()
            'gNhom = "ACS-AIR-EXPORT"
            If LoginSucceeded = True Then
                Dim form As New frmOutbound_OverseaAirExport 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            ' VB6.ShowForm(frmOutbound_OverseaAirExport, VB6.FormShowConstants.Modeless, Me)
            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub SheetDetailsToolStripMenuItem2_Click_3(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem2.Click
        Try
            gAir = "ACS-AIR-EXPORT"
            gPrintOutbound = "Outbound_OverseaAirExport"
            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem8.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem8.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipsToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ClipsToolStripMenuItem7.Click
        Try
            Dim url As String = "https://youtu.be/QMRlZOAxZuI"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefJobToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CreateRefJobToolStripMenuItem1.Click
        'CreativeBillOfLading()
        Try
            gFLC = "L"
            gSC = "C"
            '----
            gNhom = "AGENCY-EXPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            'Dim frm As New frmInputOutbound
            'frm.Show()
            If LoginSucceeded = True Then
                Dim form As New frmInputOutbound  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If


            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem8_Click_1(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem8.Click
        Try


            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()
                ' gNhom = "AGENCY-EXPORT"
                '---
                gFLC = "F"
                gSC = "C"
                '----
                gtext = "Export (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                ' Dim frm As New frmOutbound
                ' frm.Show()

                If LoginSucceeded = True Then
                    Dim form As New frmOutbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem11.Click
        Try
            'gNhom = "Agency-Export"
            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefJobToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CreateRefJobToolStripMenuItem2.Click
        'CreativeBillOfLading()
        Try
            gFLC = "C"
            gSC = "C"
            '----
            gNhom = "AGENCY-EXPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            'Dim frm As New frmInputOutbound
            'frm.Show()
            If LoginSucceeded = True Then
                Dim form As New frmInputOutbound  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If


            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem12.Click
        Try


            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()hai 
                ' gNhom = "AGENCY-EXPORT"
                '---
                gFLC = "C"
                gSC = "C"
                '----
                gtext = "Export (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                ' Dim frm As New frmOutbound
                ' frm.Show()

                If LoginSucceeded = True Then
                    Dim form As New frmOutbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem12_Click(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem12.Click
        Try
            'gNhom = "Agency-Export"
            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhânBổChiPhíHàngConsolToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles PhânBổChiPhíHàngConsolToolStripMenuItem.Click
        Try
            'gNhom = "Agency-Export"
            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ClipsToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ClipsToolStripMenuItem8.Click
        Try
            Dim url As String = "https://youtu.be/hsxzqpTwxi4"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LCLToolStripMenuItem_Click_3(sender As Object, e As EventArgs)

    End Sub

    Private Sub CreateRefToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CreateRefToolStripMenuItem.Click
        Try

            '---
            gFLC = "F"
            gSC = "S"
            '----
            gNhom = "AGENCY-IMPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            Dim frm As New frmInputBillInbound
            frm.Show()



            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem1_Click_2(sender As Object, e As EventArgs) Handles CreateRefToolStripMenuItem1.Click
        'CreativeBillOfLading()
        Try
            gFLC = "F"
            gSC = "S"
            '----
            gNhom = "AGENCY-EXPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            Dim frm As New frmInputOutbound
            frm.Show()



            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"

            'DisplayMessage(True, "Đang xây dựng....")
            'VB6.ShowForm(frmInputOutbound, VB6.FormShowConstants.Modeless, Me)

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem2_Click_3(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem2.Click
        Try



            If LoginSucceeded Then

                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem4_Click_3(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem4.Click
        Try


            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()
                ' gNhom = "AGENCY-EXPORT"

                gtext = "Export (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                ' Dim frm As New frmOutbound
                ' frm.Show()

                If LoginSucceeded = True Then
                    Dim form As New frmOutbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem3_Click_2(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem3.Click
        Try
            Try
                gNhom = "Agency-Import"
                gtext = "Carrier Own Container (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                '   VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem5.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem5.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem1.Click

    End Sub

    Private Sub DocumentToolStripMenuItem7_Click_1(sender As Object, e As EventArgs)
        Try



            If LoginSucceeded Then
                '---
                gFLC = "C"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem11_Click(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem11.Click
        Try


            If LoginSucceeded Then
                'If gDepartment <> "OutBound" And gDepartment <> "Management" And gDepartment <> "Booking" And gDepartment <> "InBound" And gDepartment <> "Sale" And gDepartment <> "Container" Then
                '    DisplayMessage(True, IIf(gLang = "E", "Sorry, This shot key is not for you.", "Bạn cần được cấp quyền."))
                '    Exit Sub
                'Else
                'Dim frm As New frmListBaseHouse_Cargo
                'frm.Show()
                ' gNhom = "AGENCY-EXPORT"
                '---
                gFLC = "L"
                gSC = "C"
                '----
                gtext = "Export (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
                'If gDepartment = "OutBound" Or gDepartment = "Management" Then
                'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmOutbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If m
                        End If
                    Next
                Catch ex As Exception

                End Try
                ' Dim frm As New frmOutbound
                ' frm.Show()

                If LoginSucceeded = True Then
                    Dim form As New frmOutbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If

                'VB6.ShowForm(frmOutbound, VB6.FormShowConstants.Modeless, Me)
                'End If
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem4_Click_1(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem4.Click
        Try
            'gNhom = "Agency-Export"
            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmtheodoithuchilohangOutbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If
                    End If
                Next
            Catch ex As Exception

            End Try

            gPrintOutbound = "Outbound"
            '  VB6.ShowForm(frmtheodoithuchilohangOutbound, VB6.FormShowConstants.Modeless, Me)

            If LoginSucceeded = True Then
                Dim form As New frmtheodoithuchilohangOutbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem6.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmCheckDNTT  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BảngTheoDõiBillTờKhaiToolStripMenuItem6_Click(sender As Object, e As EventArgs) Handles BảngTheoDõiBillTờKhaiToolStripMenuItem6.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmBangtheodoiBillTokhai  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckĐềNghịThanhToánToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles CheckĐềNghịThanhToánToolStripMenuItem1.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmCheckDNTT  'frmQuotationTic
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeliveryFormToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Try
        '    If LoginSucceeded = True Then
        '        Dim form As New frmDeliveryForm  'frmQuotationTic
        '        form.MdiParent = Me
        '        form.Show()
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub FCLToolStripMenuItem1_Click_1(sender As Object, e As EventArgs) Handles FCLToolStripMenuItem1.Click

    End Sub

    Private Sub ImportToolStripMenuItem8_Click_1(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem8.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmNhapkho 'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem4.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmxuatkho 'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FCLToolStripMenuItem_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub DailyStatusReportContainersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyStatusReportContainersToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmDailyContainerReport_Inbound_Sea_Air 'frmQuotationTic
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataFlowExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataFlowExportToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmDLExport  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DailyStatusReportContainersToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DailyStatusReportContainersToolStripMenuItem1.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmDailyContainerReport_Outbound_Sea_Air 'frmQuotationTic
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataFlowImportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DataFlowImportToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmDLImport  'frmQuotationTic
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PhânBổChiPhíHàngConsolToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PhânBổChiPhíHàngConsolToolStripMenuItem1.Click

    End Sub

    Private Sub DischargesListToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles DischargesListToolStripMenuItem.Click

    End Sub

    Private Sub PhânBổChiPhíHàngConsolToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles PhânBổChiPhíHàngConsolToolStripMenuItem3.Click
        Try
            If LoginSucceeded Then
                If LoginSucceeded = True Then
                    Dim form As New frmChiPhiPhanBoChoInbound  'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmTheodoinhienlieu, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CreateRefToolStripMenuItem2_Click_2(sender As Object, e As EventArgs) Handles CreateRefToolStripMenuItem2.Click
        Try

            '---
            'gFLC = "F"
            'gSC = "C"
            '----
            gNhom = "AGENCY-IMPORT"

            gtext = "Carrier Own Container (Agent/Oversea)"
            gStatus = False
            gNgay = False

            '----- khởi tạo số Bill nhân viên tự nhập tay và chương trình sẽ kiểm tra
            'If gDepartment = "OutBound" Or gDepartment = "Management" Then
            'VB6.ShowForm(frmInputBillInbound, VB6.FormShowConstants.Modeless, Me)
            '-----------------
            Dim CForm As New Form()
            Try
                For Each CForm In My.Application.OpenForms
                    If (CForm.Name = "frmInputBillInbound") Then
                        'form is loaded so can do work 
                        'if you need to check whether it is actually visible
                        CForm.Close()
                        'If Form.Visible Then
                        '    'do work when visible
                        'End If m
                    End If
                Next
            Catch ex As Exception

            End Try

            '----------------------
            'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
            'Dim frm As New frmInputBillInbound
            'frm.Show()

            If LoginSucceeded = True Then
                Dim form As New frmInputBillInbound 'frmInbound 'frmQuotationTico
                form.MdiParent = Me
                form.Show()
            End If

            If gBillOfLadingNumber = "" Then
                gBillOfLadingNumber = "No BillNumber."
            End If
            Me.Text = "FMS - (" & strServer & " - " & strDatabase & " - " & strUserName & " - " & gDepartment & " - " & UCase(gBillOfLadingNumber) & ")"
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description, "frmMain:LoadTransaction")
        End Try
    End Sub

    Private Sub DocumentToolStripMenuItem_Click_4(sender As Object, e As EventArgs) Handles DocumentToolStripMenuItem.Click
        Try



            If LoginSucceeded Then
                '---
                gFLC = "F"
                gSC = "C"
                '----
                'gNhom = ""
                gtext = "Import (Agent/Oversea)"
                gStatus = False
                gNgay = False
                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmInbound") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                'VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modal, Me)
                ' Dim frm As New frmInbound
                'frm.Show()
                If LoginSucceeded = True Then
                    Dim form As New frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmInbound, VB6.FormShowConstants.Modeless, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub

    Private Sub SheetDetailsToolStripMenuItem1_Click_2(sender As Object, e As EventArgs) Handles SheetDetailsToolStripMenuItem1.Click
        Try
            Try
                gNhom = "Agency-Import"
                gtext = "Carrier Own Container (Agent/Oversea)"
                gStatus = False
                gNgay = False

                '-----------------
                Dim CForm As New Form()
                Try
                    For Each CForm In My.Application.OpenForms
                        If (CForm.Name = "frmtheodoithuchilohang") Then
                            'form is loaded so can do work 
                            'if you need to check whether it is actually visible
                            CForm.Close()
                            'If Form.Visible Then
                            '    'do work when visible
                            'End If
                        End If
                    Next
                Catch ex As Exception

                End Try

                '----------------------
                gPrintInbound = "Inbound"
                '   VB6.ShowForm(frmtheodoithuchilohang, VB6.FormShowConstants.Modeless, Me)

                If LoginSucceeded = True Then
                    Dim form As New frmtheodoithuchilohang 'frmInbound 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TempleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TempleteToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmCongNoGMD 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmCongNoGMD, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TBSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TBSToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New frmCongNoGMD_tbs 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmCongNoGMD, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Try
            Dim url As String = "https://youtu.be/rQyfJpY8tv4"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportToolStripMenuItem9_Click_1(sender As Object, e As EventArgs) Handles ImportToolStripMenuItem9.Click
        Try
            Dim url As String = "https://youtu.be/akrFQVbOESs"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportToolStripMenuItem7_Click_1(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem7.Click
        Try
            Dim url As String = "https://youtu.be/hsxzqpTwxi4"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LogistToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LogistToolStripMenuItem.Click
        Try
            Dim url As String = "https://youtu.be/0Aw0HvfQz0E"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BookingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BookingToolStripMenuItem1.Click
        Try
            Dim url As String = "https://youtu.be/iOfpmi48o-Q"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MasterDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasterDataToolStripMenuItem.Click
        Try
            Try
                If LoginSucceeded = True Then
                    Dim form As New Frm_MasterData 'frmQuotationTico
                    form.MdiParent = Me
                    form.Show()
                End If
                ' VB6.ShowForm(frmCongNoGMD, VB6.FormShowConstants.Modeless, Me)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImportJobToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportJobToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                gNhom = "ACS-AIR-IMPORT"
                Dim form As New frmImportAirImportJob
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Try
            If LoginSucceeded = True Then
                gNhom = "AGENCY-IMPORT"
                Dim form As New frmImportSeaImportJob
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub TarifHeaderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TarifHeaderToolStripMenuItem.Click
        On Error GoTo Err_Renamed
        If LoginSucceeded = True Then
            Dim form As New frmTarifHeader
            form.MdiParent = Me
            form.Show()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub AddImportFreightQuotationMenu()
        Try
            If Me.PricingToolStripMenuItem Is Nothing Then
                Return
            End If
            For Each item As ToolStripItem In Me.PricingToolStripMenuItem.DropDownItems
                If item.Name = "ImportFreightQuotationToolStripMenuItem" Then
                    Return
                End If
            Next
            Dim mnu As New ToolStripMenuItem()
            mnu.Name = "ImportFreightQuotationToolStripMenuItem"
            mnu.Text = "6. Import Freight Quotation"
            mnu.ForeColor = System.Drawing.Color.Blue
            AddHandler mnu.Click, AddressOf ImportFreightQuotationToolStripMenuItem_Click
            Me.PricingToolStripMenuItem.DropDownItems.Add(mnu)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ImportFreightQuotationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportFreightQuotationToolStripMenuItem.Click
        Try
            If LoginSucceeded = True Then
                Dim form As New frmImportFreightQuotation
                form.MdiParent = Me
                form.Show()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub QuotationToolStripMenuItem2_Click_1(sender As Object, e As EventArgs) Handles QuotationToolStripMenuItem2.Click
        Try
            Dim url As String = "https://youtu.be/yOY_hC_jNHU"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub
End Class