Public Class frmListServiceFeeder
    Inherits System.Windows.Forms.Form

    Dim rsServiceFeederList As New ADODB.Recordset
    Dim mStatus, mStatusVia, mFilter As String
    Public blnUpdated As Boolean
    Public mServiceFeederId, mViaPortID As String

    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strServiceFeederSelect As String = "SELECT * " ' & _
    '   "ServiceFeederId, " & _
    '   "ServiceFeederCode, " & _
    '   "ServiceFeeder , " & _
    '       "NATIONALITY , " & _
    '   "SHIPPING_LINE, " & _
    '   "CALL_SIGN , " & _
    '   "BUILD , " & _
    '"CLASS , " & _
    '   "PUMP_CAPACITY , " & _
    '   "SDWT, " & _
    '   "GRT, " & _
    '   "NRT, " & _
    '   "LOA, " & _
    '   "BM, " & _
    '   "DRAFT, " & _
    '   "TEL, " & _
    '   "FAX, " & _
    '   "TELEX, " & _
    '   "MOBILE, " & _
    '   "EMAIL, " & _
    '    "Approve, " & _
    '    "Continued, " & _
    '   "Editable, " & _
    '   "UserId, " & _
    '   "Updatetime "


    Const strServiceFeederOrder1 As String = _
           " ORDER BY ServiceFeederCode  Desc "
    Const strServiceFeederOrder2 As String = _
        " ORDER BY UpdateTime Desc "

   

    Private Sub frmListServiceFeeder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mStatusVia = "Normal"
        blnUpdated = False
        mServiceFeederId = DefaultValue
        mViaPortID = DefaultValue
        setViaPortItem(False)
        SetDefaultGrid(Me.dgdServiceFeeder, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdServiceFeeder)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'Me.cboFind.Text = objUserSetting.GetCParm("frmListServiceFeeder.cboFind", "NAME")
        mFilter = objUserSetting.GetCParm("frmListServiceFeeder.mFilter")
        Me.txtServiceFeederCode.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtServiceFeederCode")
        Me.txtServiceFeederName.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtServiceFeederName")
        'Me.txtNATIONALITY.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtNATIONALITY")
        'Me.txtVoyage.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtVoyage")
        'Me.txtCallSign.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtCallSign")
        'Me.txtTELEX.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtTELEX")
        'Me.txtBUILD.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtBUILD")
        'Me.txtClass.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtClass")
        'Me.txtEMAIL.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtEmail")
        'Me.txtMOBILE.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtMOBILE")
        'Me.txtEMAIL.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtEMAIL")
        'Me.txtPUMP_CAPACITY.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtPUMP_CAPACITY")
        'Me.txtGRT.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtGRT")
        'Me.txtNRT.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtNRT")
        'Me.txtSDWT.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtSDWT")
        'Me.txtLOA.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtLOA")
        'Me.txtDRAFT.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtDRAFT")
        'Me.txtBM.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtTEL")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtFax")
        'Me.txtShippingLine.Text = objUserSetting.GetCParm("frmListServiceFeeder.txtSHIPPING_LINE")
        'If Me.txtServiceFeeder.Text <> "" Then
        '    QueryServiceFeeder("AND ServiceFeeder LIKE '" & MakeFilter(Me.txtServiceFeeder.Text) & "' " & mFilter, , )
        'Else
        '    QueryServiceFeeder(mFilter, , )
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If


        ' Me.smnuDisplayVOYAGE.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayVOYAGE")
        'Me.smnuDisplayNATIONALITY.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayNATIONALITY")
        'Me.smnuDisplayCALL_SIGN.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayCALL_SIGN")
        'Me.smnuDisplayBUILD.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayBUILD")
        'Me.smnuDisplayCLASS.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayCLASS")
        'Me.smnuDisplayPUMP_CAPACITY.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayPUMP_CAPACITY")
        'Me.smnuDisplaySDWT.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplaySDWT")
        'Me.smnuDisplayGRT.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayGRT")
        'Me.smnuDisplayNRT.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayNRT")
        'Me.smnuDisplayLOA.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayLOA")
        'Me.smnuDisplayBM.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayBM")
        'Me.smnuDisplayDRAFT.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayDRAFT")
        'Me.smnuDisplayTEL.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayTEL")
        'Me.smnuDisplayFAX.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayFAX")
        'Me.smnuDisplayTELEX.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayTELEX")
        'Me.smnuDisplayMOBIL.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayMOBIL")
        'Me.smnuDisplayEMAIL.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayEMAIL")
        'Me.smnuDisplayAPPROVE.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayAPPROVE")

        'Me.smnuDisplayUSERID.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayUserId")
        'Me.smnuDisplayUPDATETIME.Checked = objUserSetting.GetBParm("frmListServiceFeeder.smnuDisplayUpdateTime")
        'UpdateFrame()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        SetWidth()
        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub ReFormat()
        On Error GoTo Err
        Dim rong As Integer
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(fraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(fraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        If Not CheckRez(800, 600) Then
            rong = 50
        Else
            rong = 0
        End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        Me.dgdServiceFeeder.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            Me.dgdServiceFeeder.Height = Me.Height - cmdOk.Height - 10 - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            Me.dgdServiceFeeder.Height = Me.Height - cmdOk.Height - 10 - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = Me.dgdServiceFeeder.Height + Me.dgdServiceFeeder.Top '+ 100
        'cmdCancel.Top = Me.fraUpdate.Bottom + 10
        'Me.cmdOK.Top = Me.cmdCancel.Top
        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdFind.Left = Me.txtServiceFeeder.Left + Me.txtServiceFeeder.Width + 10
        'Me.txtServiceFeeder.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Public Sub SetWidth()
        '-------cot 1

        'Me.txtServiceFeeder.Width = Me.Width - 300
        'Me.TxtServiceFeederName.Width = Me.fraUpdate.Width - Me.TxtServiceFeederName.Left - Me.lblTELEX.Width - Me.txtTELEX.Width - 120
        'Me.lblTELEX.Left = Me.TxtServiceFeederName.Right + 10
        'Me.txtTELEX.Left = Me.lblTELEX.Right + 3

        'Me.txtNATIONALITY.Width = Me.txtNATIONALITY.Right - Me.txtNATIONALITY.Left

        'Me.lblCALLSIGN.Left = Me.TxtServiceFeederName.Right - Me.txtCallSign.Width - 3 - Me.lblCALLSIGN.Width

        'Me.txtCallSign.Left = Me.TxtServiceFeederName.Right - Me.txtCallSign.Width
        'Me.txtCallSign.Width = Me.txtCallSign.Right - Me.txtCallSign.Left

        'Me.LBLCLASS.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLCLASS.Width
        'Me.txtClass.Left = Me.txtCallSign.Left

        'Me.lblMOBILE.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblMOBILE.Width
        'Me.txtMOBILE.Left = Me.txtTELEX.Left

        'Me.LBLGRT.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLGRT.Width
        'Me.txtGRT.Left = Me.txtClass.Left


        'Me.LBLEMAIL.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.LBLEMAIL.Width
        'Me.txtEMAIL.Left = Me.txtTELEX.Left

        'Me.lblTell.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblTell.Width
        'Me.txtTell.Left = Me.txtTELEX.Left

        'Me.LBLSDWT.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.LBLSDWT.Width
        'Me.txtSDWT.Left = Me.txtCallSign.Left

        'Me.lbldraft.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.lbldraft.Width
        'Me.txtDRAFT.Left = Me.txtCallSign.Left

        'Me.lblShippingLine.Left = Me.lblCALLSIGN.Left + Me.lblCALLSIGN.Width - Me.lblShippingLine.Width
        'Me.txtShippingLine.Left = Me.txtCallSign.Left

        'Me.lblFAX.Left = Me.lblTELEX.Left + Me.lblTELEX.Width - Me.lblFAX.Width
        'Me.txtFax.Left = Me.txtTELEX.Left

        '----

    End Sub
    '    Private Sub UpdateFrame()
    '        On Error GoTo Err_Renamed

    '        Me.dgdServiceFeeder.Columns.Item("ServiceFeederId").Visible = False

    '        'Me.dgdServiceFeeder.Columns.Item("Voyage").Visible = Me.smnuDisplayVOYAGE.Checked
    '        Me.dgdServiceFeeder.Columns.Item("Nationality").Visible = Me.smnuDisplayNATIONALITY.Checked
    '        Me.dgdServiceFeeder.Columns.Item("Call_Sign").Visible = Me.smnuDisplayCALL_SIGN.Checked
    '        Me.dgdServiceFeeder.Columns.Item("Build").Visible = Me.smnuDisplayBUILD.Checked
    '        Me.dgdServiceFeeder.Columns.Item("Class1").Visible = Me.smnuDisplayCLASS.Checked
    '        Me.dgdServiceFeeder.Columns.Item("Pump_Capacity").Visible = Me.smnuDisplayPUMP_CAPACITY.Checked
    '        Me.dgdServiceFeeder.Columns.Item("SDWT").Visible = Me.smnuDisplaySDWT.Checked
    '        Me.dgdServiceFeeder.Columns.Item("GRT").Visible = Me.smnuDisplayGRT.Checked
    '        Me.dgdServiceFeeder.Columns.Item("NRT").Visible = Me.smnuDisplayNRT.Checked
    '        Me.dgdServiceFeeder.Columns.Item("LOA").Visible = Me.smnuDisplayLOA.Checked
    '        Me.dgdServiceFeeder.Columns.Item("BM").Visible = Me.smnuDisplayBM.Checked
    '        Me.dgdServiceFeeder.Columns.Item("DRAFT").Visible = Me.smnuDisplayDRAFT.Checked
    '        Me.dgdServiceFeeder.Columns.Item("TEL").Visible = Me.smnuDisplayTEL.Checked
    '        Me.dgdServiceFeeder.Columns.Item("FAX").Visible = Me.smnuDisplayFAX.Checked
    '        Me.dgdServiceFeeder.Columns.Item("MOBILE").Visible = Me.smnuDisplayMOBIL.Checked
    '        Me.dgdServiceFeeder.Columns.Item("EMAIL").Visible = Me.smnuDisplayEMAIL.Checked


    '        Me.dgdServiceFeeder.Columns.Item("CONTINUED").Visible = False
    '        Me.dgdServiceFeeder.Columns.Item("APPROVE").Visible = Me.smnuDisplayAPPROVE.Checked
    '        Me.dgdServiceFeeder.Columns.Item("UserId").Visible = Me.smnuDisplayUSERID.Checked
    '        Me.dgdServiceFeeder.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUPDATETIME.Checked
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    Private Sub QueryServiceFeeder(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryServiceFeeder()
        Else
            strQuery = MakeQueryServiceFeeder(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "List")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdServiceFeeder.DataSource = ds.Tables("List")
        If Me.dgdServiceFeeder.Enabled = False Then
            Me.dgdServiceFeeder.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdServiceFeeder.Rows.Count And Me.dgdServiceFeeder.Rows.Count > 0 Then
            Me.dgdServiceFeeder.Rows(location).Selected = True
            Me.dgdServiceFeeder.CurrentCell = Me.dgdServiceFeeder.Rows(location).Cells(1)
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdServiceFeeder.Columns.Item("ServiceFeederCode").ToolTipText = "Hiện có:" + CStr(Me.dgdServiceFeeder.RowCount()) + " ServiceFeeders."
        End If
        If Me.dgdServiceFeeder.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Function MakeQueryServiceFeeder(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryServiceFeeder = strServiceFeederSelect
        '        MakeQueryServiceFeeder = MakeQueryServiceFeeder & ", (SELECT count(*) FROM BillOfLading  WHERE ServiceFeeder.ServiceFeederId = BillOfLading.ServiceFeederId) AS NumOfTransaction "
        MakeQueryServiceFeeder = MakeQueryServiceFeeder & " FROM ServiceFeeder "
        MakeQueryServiceFeeder = MakeQueryServiceFeeder & "WHERE (ServiceFeederID = '" & DefaultValue & "') "

        MakeQueryServiceFeeder = MakeQueryServiceFeeder & "OR ("
        MakeQueryServiceFeeder = MakeQueryServiceFeeder & "Continued = 1 "
        MakeQueryServiceFeeder = MakeQueryServiceFeeder & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryServiceFeeder = MakeQueryServiceFeeder & argCriteria
        End If
        If index = 1 Then ' 
            MakeQueryServiceFeeder = MakeQueryServiceFeeder & strServiceFeederOrder1
        ElseIf index = 15 Then ' 
            MakeQueryServiceFeeder = MakeQueryServiceFeeder & strServiceFeederOrder2
        End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub frmListServiceFeeder_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmListServiceFeeder_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "List ServiceFeeder "
        ElseIf mStatus = "Edit" Then
            Me.Text = " ServiceFeeder-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "ServiceFeeder-> Add."
        End If

    End Sub
    Private Sub smnuAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListServiceFeeder", "Add") Then
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mServiceFeederId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdServiceFeeder.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        ''''''''''''''''''''''''them 4-07-2007---------------------
        Me.txtServiceFeederCode.Text = Me.dgdServiceFeeder.Item("ServiceFeederCode", index).Value.ToString
        Me.txtServiceFeedername.Text = Me.dgdServiceFeeder.Item("ServiCeFeederName", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveServiceFeeder()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdServiceFeeder.CurrentRow.Index
        Dim strQueryServiceFeederList As String
        If Not Me.dgdServiceFeeder.Item("Editable", index).Value Or Not UserRight("frmListServiceFeeder", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryServiceFeeder(mFilter, , index)
        Else
            Dim rsServiceFeederList As New ADODB.Recordset
            strQueryServiceFeederList = "Select * from ServiceFeeder where" + " ServiceFeederId= '" & Me.dgdServiceFeeder.Item("ServiceFeederID", index).Value.ToString & "'"
            rsServiceFeederList.Open(strQueryServiceFeederList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsServiceFeederList.Fields("Approve").Value
            rsServiceFeederList.Update("Approve", Approve)
            rsServiceFeederList.Close()
            QueryServiceFeeder(mFilter, , )

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from ServiceFeeder WHERE ServiceFeederId = '" & Me.dgdServiceFeeder.Item("ServiceFeederId", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from ServiceFeeder WHERE ServiceFeederId = '" & Me.dgdServiceFeeder.Item("ServiceFeederId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, "Sorry, The ServiceFeeder can not be removed.")
        '    Exit Sub
        'End If
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The ServiceFeeder can not be removed. There are transactions that relate to this Booking.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdServiceFeeder.Item("Approve", index)) Then
            If Me.dgdServiceFeeder.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdServiceFeeder.Item("Editable", index)) Then
            If Not Me.dgdServiceFeeder.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListServiceFeeder", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the ServiceFeeder: " & Me.dgdServiceFeeder.Item("ServiceFeederCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                Dim rsServiceFeederList As New ADODB.Recordset

                strQueryCommodityList = "Select * from ServiceFeeder where" + " ServiceFeederId= '" & Me.dgdServiceFeeder.Item("ServiceFeederId", index).Value.ToString & "'"
                rsServiceFeederList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsServiceFeederList.Fields("continued").Value = 0
                rsServiceFeederList.Update()

                rsServiceFeederList.Requery()
                Me.dgdServiceFeeder.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdServiceFeeder.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsServiceFeederList.Close()
                blnUpdated = True
            End If
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strServiceFeederId As String
        'If mStatus = "Add" Then
        strServiceFeederId = DefaultValue
        If Me.txtServiceFeederCode.Text = "" Then
            CheckData = False
            DisplayMessage(True, IIf(gLang = "E", "Code Not Allow Null Value", "Mã Không Đựơc Để Trống"))
            Exit Function
        End If
        Dim strQueryCode As String
        Dim rsCode As New ADODB.Recordset
        strQueryCode = "SELECT ServiceFeederCode FROM ServiceFeeder WHERE ServiceFeederCode='" & Me.txtServiceFeederCode.Text & "' And Continued=1 And ServiceFeederId<>'" & mServiceFeederId & "'"
        rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rsCode.EOF Then
            DisplayMessage(True, IIf(gLang = "E", "The ServiceFeederCode is already exist.", "Mã Tàu Đã Có"))
            rsCode.Close()
            CheckData = False
            Exit Function
        Else
            rsCode.Close()
        End If
        'End If
        If Len(Me.txtServiceFeederCode.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Code is invalid. Please check again."
        End If
        If Len(Me.txtServiceFeedername.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Name is invalid. Please check again."
        End If



        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub cmdOK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim strQuery, strServiceFeederId As String
        Dim rsCode As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdServiceFeeder.Rows.Count > 0 Then
            index = Me.dgdServiceFeeder.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            Dim rs As New ADODB.Recordset

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM ServiceFeeder "
            strQuery = strQuery & "WHERE ServiceFeederId = '" & mServiceFeederId & "' AND ServiceFeederId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("ServiceFeederId").Value = NewId()
                End If
                strServiceFeederId = .Fields("ServiceFeederId").Value
                'If mStatus = "Add" Then
                .Fields("ServiceFeederCode").Value = UCase(Trim(Me.txtServiceFeederCode.Text))
                'End If
                .Fields("ServiceFeederName").Value = UCase(Trim(Me.txtServiceFeedername.Text))

                .Update()
            End With
            rs.Close()
            Me.dgdServiceFeeder.Enabled = True
            If mStatus = "Edit" Then
                QueryServiceFeeder(, 1, index)
            Else
                QueryServiceFeeder(, 15, index)
            End If
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            SetMenu(True)
            blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, "The Code :" & Me.txtServiceFeederCode.Text & " have been added.")
        'Resume
    End Sub


    'Private Sub smnuDisplayNATIONALITY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNATIONALITY.Click
    '    Me.smnuDisplayNATIONALITY.Checked = Not Me.smnuDisplayNATIONALITY.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayCALL_SIGN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCALL_SIGN.Click
    '    Me.smnuDisplayCALL_SIGN.Checked = Not Me.smnuDisplayCALL_SIGN.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayBUILD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBUILD.Click
    '    Me.smnuDisplayBUILD.Checked = Not Me.smnuDisplayBUILD.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayCLASS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCLASS.Click
    '    Me.smnuDisplayCLASS.Checked = Not Me.smnuDisplayCLASS.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayPUMP_CAPACITY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPUMP_CAPACITY.Click
    '    Me.smnuDisplayPUMP_CAPACITY.Checked = Not Me.smnuDisplayPUMP_CAPACITY.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplaySDWT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplaySDWT.Click
    '    Me.smnuDisplaySDWT.Checked = Not Me.smnuDisplaySDWT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayGRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayGRT.Click
    '    Me.smnuDisplayGRT.Checked = Not Me.smnuDisplayGRT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayNRT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNRT.Click
    '    Me.smnuDisplayNRT.Checked = Not Me.smnuDisplayNRT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayLOA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayLOA.Click
    '    Me.smnuDisplayLOA.Checked = Not Me.smnuDisplayLOA.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayBM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBM.Click
    '    Me.smnuDisplayBM.Checked = Not Me.smnuDisplayBM.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayDRAFT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayDRAFT.Click
    '    Me.smnuDisplayDRAFT.Checked = Not Me.smnuDisplayDRAFT.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayTEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTEL.Click
    '    Me.smnuDisplayTEL.Checked = Not Me.smnuDisplayTEL.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayFAX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayFAX.Click
    '    Me.smnuDisplayFAX.Checked = Not Me.smnuDisplayFAX.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayTELEX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTELEX.Click
    '    Me.smnuDisplayTELEX.Checked = Not Me.smnuDisplayTELEX.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayMOBIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMOBIL.Click
    '    Me.smnuDisplayMOBIL.Checked = Not Me.smnuDisplayMOBIL.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayEMAIL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayEMAIL.Click
    '    Me.smnuDisplayEMAIL.Checked = Not Me.smnuDisplayEMAIL.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayAPPROVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayAPPROVE.Click
    '    Me.smnuDisplayAPPROVE.Checked = Not Me.smnuDisplayAPPROVE.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUSERID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUSERID.Click
    '    Me.smnuDisplayUSERID.Checked = Not Me.smnuDisplayUSERID.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUPDATETIME_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUPDATETIME.Click
    '    Me.smnuDisplayUPDATETIME.Checked = Not Me.smnuDisplayUPDATETIME.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub smnuDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdServiceFeeder.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdServiceFeeder.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryServiceFeeder()
    End Sub

    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.dgdServiceFeeder.Rows.Count > 0 Then
            index = Me.dgdServiceFeeder.CurrentRow.Index
        Else
            Exit Sub
        End If
        If index >= 0 Then
            Approve = Me.dgdServiceFeeder.Item("Approve", index).Value
            EditTable = Me.dgdServiceFeeder.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListServiceFeeder", "Edit") And Not Me.dgdServiceFeeder.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdServiceFeeder.Height = 306
                Me.dgdServiceFeeder.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mServiceFeederId = Me.dgdServiceFeeder.Item("ServiceFeederId", index).Value.ToString

                QueryViaPort() 'Lấy dữ liệu gán trên lứơi
                QueryPortViaPort() 'lấy port gàn vào cboPort
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdServiceFeeder_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdServiceFeeder.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdServiceFeeder.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdServiceFeeder.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdServiceFeeder.Columns(ColIndex).Name = "Approve" And Me.dgdServiceFeeder.CurrentCellAddress().Y = index Then
            Call ApproveServiceFeeder()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtServiceFeeder.Text)
    '        If Me.txtServiceFeeder.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtServiceFeeder.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdServiceFeeder)
    '            '    Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            Me.QueryServiceFeeder("AND ( ServiceFeederCode LIKE '" & strFilter & "') " & mFilter)
    '            '        Case "NAME"
    '            '            Me.QueryServiceFeeder("AND (ServiceFeeder LIKE '" & strFilter & "' ) " & mFilter)
    '            '    End Select
    '            'Else
    '            '    QueryServiceFeeder(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryServiceFeeder("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdServiceFeeder.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdServiceFeeder, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
#Region "Via Port 22-2-2008"

    Sub QueryPortViaPort()
        Try
            Dim dt As New DataTable
            dt = oTablePort.Copy
            Me.cboPort.DisplayMember = "Port_Code"
            Me.cboPort.ValueMember = "Port_ID"
            Me.cboPort.DataSource = dt

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryViaPort(Optional ByVal arg As String = "")
        Try
            Dim SQL As String
            SQL = "Select ServiceViaPort.*,Port.Port_Code,Port.Port "
            SQL &= " From (ServiceViaPort LEFT JOIN Port on Port.Port_ID=ServiceViaPort.ViaPortID) "
            SQL &= " Where ServiceViaPort.Continued=1 And ServiceViaPort.ServiceID='" & mServiceFeederId & "' " & arg
            SQL &= " Order By Port.Port "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdViaPortData.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdViaPortData)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Sub setViaPortItem(ByVal Value As Boolean)
        Try
            Me.cboPort.Enabled = Value
            Me.txtNumberOfDay.Enabled = Value
            Me.cmdOkP.Enabled = Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            mStatusVia = "Add"
            setViaPortItem(True)
            mViaPortID = DefaultValue

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub RefreshdataViaport(ByVal Index As Integer)
        Try
            Me.cboPort.SelectedValue = Me.dgdViaPortData.Item("ViaportID", Index).Value.ToString
            Me.txtNumberOfDay.TabIndex = Me.dgdViaPortData.Item("NumberOfDayVia", Index).Value

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            If Me.dgdViaPortData.Rows.Count = 0 Or IsNothing(Me.dgdViaPortData.CurrentRow) Then
                Return
            End If
            Dim Index As Integer = Me.dgdViaPortData.CurrentRow.Index
            If Me.dgdViaPortData.Item("ApproveViaPort", Index).Value = 1 Then
                MsgBox("Access Carry out,Row Has Approved")
                Return
            End If
            RefreshdataViaport(Index)
            mViaPortID = Me.dgdViaPortData.Item("ServiceViaPortID", Index).Value.ToString
            mStatusVia = "Edit"
            setViaPortItem(True)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Public Sub DeleteRowVia(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from ServiceViaPort WHERE ServiceViaPortId = '" & Me.dgdviaportdata.Item("ServiceViaPortId", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from ServiceViaPort WHERE ServiceViaPortId = '" & Me.dgdViaPortData.Item("ServiceViaPortId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, "Sorry, The ServiceViaPort can not be removed.")
        '    Exit Sub
        'End If
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The ServiceViaPort can not be removed. There are transactions that relate to this Booking.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdViaPortData.Item("ApproveViaPort", index)) Then
            If Me.dgdViaPortData.Item("ApproveViaPort", index).Value = 1 Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If IsNothing(Me.dgdViaPortData.Item("EditableViaport", index)) = 0 Then
            If Me.dgdViaPortData.Item("EditableViaPort", index).Value = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListServiceFeeder", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the ServiceViaPort: " & Me.dgdViaPortData.Item("PortCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                Dim rsServiceViaPortList As New ADODB.Recordset

                strQueryCommodityList = "Select * from ServiceViaPort where" + " ServiceViaPortId= '" & Me.dgdViaPortData.Item("ServiceViaPortId", index).Value.ToString & "'"
                rsServiceViaPortList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsServiceViaPortList.Fields("continued").Value = 0
                rsServiceViaPortList.Update()

                rsServiceViaPortList.Requery()
                Me.dgdViaPortData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdViaPortData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsServiceViaPortList.Close()
                blnUpdated = True
            End If
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim selectedRowCount As Integer = _
                 Me.dgdViaPortData.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRowvia(Me.dgdViaPortData.SelectedRows(i).Index)
                Next i
            End If
            Me.QueryViaPort()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Public Sub ApproveVia()
        On Error GoTo Err_Renamed
        Dim Approve As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdViaPortData.CurrentRow.Index
        Dim strQueryServiceViaPortList As String
        If Me.dgdViaPortData.Item("EditableViaPort", index).Value = 0 Or Not UserRight("frmListServiceFeeder", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryViaPort()
        Else
            Dim rsServiceViaPortList As New ADODB.Recordset
            strQueryServiceViaPortList = "Select * from ServiceViaPort where" + " ServiceViaPortId= '" & Me.dgdViaPortData.Item("ServiceViaPortID", index).Value.ToString & "'"
            rsServiceViaPortList.Open(strQueryServiceViaPortList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = IIf(rsServiceViaPortList.Fields("Approve").Value = 0, 1, 0)
            rsServiceViaPortList.Update("Approve", Approve)
            rsServiceViaPortList.Close()
            QueryViaPort()

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdViaPortData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdViaPortData.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdViaPortData.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdViaPortData.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdViaPortData.Columns(ColIndex).Name) = "APPROVEVIAPORT" And Me.dgdViaPortData.CurrentCellAddress().Y = index Then
            Call ApproveVia()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOkP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkP.Click
        Dim strQuery, strServiceViaPortId As String
        Dim rsCode As New ADODB.Recordset
        Dim index As Integer = 0
        If Me.dgdViaPortData.Rows.Count > 0 Then
            index = Me.dgdViaPortData.CurrentRow.Index
        End If

        If (mStatusVia = "Add" Or mStatusVia = "Edit") Then
            Dim rs As New ADODB.Recordset

            strQuery = "SELECT * "
            strQuery = strQuery & "FROM ServiceViaPort "
            strQuery = strQuery & "WHERE ServiceViaPortId = '" & mViaPortID & "' AND ServiceViaPortId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rsCode.Open(strQueryCode, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("ServiceViaPortId").Value = NewId()
                End If

                .Fields("ServiceID").Value = "{" & mServiceFeederId & "}"
                .Fields("ViaPortID").Value = "{" & Me.cboPort.SelectedValue.ToString & "}"
                .Fields("NumberOfDayVia").Value = Me.txtNumberOfDay.Text
                .Update()
            End With
            rs.Close()
            Me.dgdViaPortData.Enabled = True
            If mStatus = "Edit" Then
                QueryViaPort()
            Else
                QueryViaPort()
            End If

            setViaPortItem(False)
            mStatusVia = "Normal"
            blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelP.Click
        mStatusVia = "Normal"
        setViaPortItem(False)
    End Sub
#End Region



End Class