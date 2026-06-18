Public Class frmOption

    Inherits System.Windows.Forms.Form

    Dim mStatus As String = "Normal"
    Dim mFilter As String

    Dim mOptionID As String = DefaultValue




    Dim rsOptionList As New ADODB.Recordset
    Public blnUpdated As Boolean

    Public oTable As DataTable
    Public ds As New DataSet

    Const strOptionSelect As String = "SELECT frmName, department," & _
    "OptionID, " & _
    "Optionname ,OptionCode as Code,OptionValue," & _
    "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "


    Const strOptionOrder1 As String = _
           " ORDER BY OptionName  Desc "
    Const strOptionOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    '    Private Function CheckData() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strMsg As String
    '        CheckData = True
    '        strMsg = ""
    '        Dim strOptionId As String
    '        If mStatus = "Add" Then
    '            strOptionId = DefaultValue
    '            If Me.txtOptionCode.Text = "" Then
    '                CheckData = False
    '                DisplayMessage(True, "The code not allow NULL value")
    '                Exit Function
    '            End If
    '            Dim rs As New ADODB.Recordset
    '            Dim strquery As String
    '            strquery = "SELECT * "
    '            strquery = strquery & "FROM [Option] "
    '            strquery = strquery & "WHERE Option_code = '" & Me.txtOptionCode.Text & "' And Continued=1"
    '            rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            If Not rs.EOF Then
    '                CheckData = False
    '                rs.Close()
    '                DisplayMessage(True, "This code had already in database")
    '                Exit Function
    '            End If
    '        End If
    '        If Len(Me.TxtOptionName.Text) = 0 Then
    '            CheckData = False
    '            strMsg = strMsg & "The Name is invalid. Please check again."
    '        End If
    '        If strMsg <> "" Then
    '            DisplayMessage(True, strMsg)
    '        End If
    '        Exit Function
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Function
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdOption.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtOption.Text)
    '        If Me.txtOption.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtOption.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdOption)
    '            'Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            QueryOption("AND ( Option_CODE LIKE '" & strFilter & "') ")
    '            '            If Me.smnuDisplayCode.Checked = False Then
    '            '                Me.smnuDisplayCode.Checked = True
    '            '            End If
    '            '            Me.dgdOption.Columns.Item("Option_CODE").Visible = Me.smnuDisplayCode.Checked
    '            '        Case "NAME"
    '            '            QueryOption("AND ([Option] LIKE '" & strFilter & "')")
    '            '            If Me.smnuDisplayName.Checked = False Then
    '            '                Me.smnuDisplayName.Checked = True
    '            '            End If
    '            '            UpdateFrame()
    '            '        Case "TAX"
    '            '            QueryOption("AND (TAX LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayTax.Checked = False Then
    '            '                Me.smnuDisplayTax.Checked = True
    '            '            End If
    '            '            Me.dgdOption.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
    '            '        Case "E-MAIL"
    '            '            QueryOption("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayFax.Checked = False Then
    '            '                Me.smnuDisplayFax.Checked = True
    '            '            End If
    '            '            Me.dgdOption.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
    '            '    End Select
    '            'Else
    '            '    QueryOption(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strOptionId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        If mStatus = "Edit" Then
            index = Me.dgdOption.CurrentRow.Index
        End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM [Option] "
            strQuery = strQuery & "WHERE OptionId = '" & mOptionID & "' AND OptionId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("OptionId").Value = NewId()
                End If
                strOptionId = .Fields("OptionId").Value

                .Fields("OptionName").Value = UCase(Trim(Me.txtName.Text))
                .Fields("OptionCode").Value = UCase(Trim(Me.txtCode.Text))
                .Fields("OptionValue").Value = Me.txtOptionValue.Text
                If UCase(Me.dgdOption.Item("frmname", index).Value) = "COLOR" Then
                    .Fields("OptionValue").Value = Me.cboBackG.BackColor.ToArgb.ToString + "$" + Me.cboFra.BackColor.ToArgb.ToString
                End If
                '.Fields("Country").Value = UCase(Trim(Me.txtCountry.Text))
                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()

            'không cần sắp xếp

            'If mStatus = "Edit" Then
            '    QueryOption(, 1)
            'Else
            '    QueryOption(, 15)
            'End If
            Me.dgdOption.Enabled = True
            'fraUpdate chỉ visible khi thêm hay sửa thành công
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            QueryOption(mFilter, , index)
            mStatus = "Normal"
            blnUpdated = True
            '----------- lay mau nen
            Dim SQL, tach() As String
            Dim ds, ds1 As New DataSet
            SQL = "select * from [option] where frmName='Color' and department='" & strUserId & "'  "
            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count > 0 Then
                tach = ds.Tables(0).Rows(0).Item("optionvalue").ToString.Split("$")

                gMaunen = Color.FromArgb(CInt(tach(0)))
                gMauFra = Color.FromArgb(CInt(tach(1)))



            End If
        End If





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmOption_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdOption, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mOptionId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdOption)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "TAX", "TAX")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "E-MAIL", "E-MAIL")
        'Me.cboFind.Items.Add(oItems)

        'Me.cboFind.Text = objUserSetting.GetCParm("frmOption.cboFind", "NAME")
        'mFilter = objUserSetting.GetCParm("frmOption.mFilter")
        'Me.txtOptionCode.Text = objUserSetting.GetCParm("frmOption.txtCODE")
        'Me.TxtOptionName.Text = objUserSetting.GetCParm("frmOption.txtOptionName")
        'Me.txtTel.Text = objUserSetting.GetCParm("frmOption.txtTel")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmOption.txtFax")
        'Me.txtAddress.Text = objUserSetting.GetCParm("frmOption.txtAddress")
        'Me.txtCountry.Text = objUserSetting.GetCParm("frmOption.txtCountry")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmOption.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmOption.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmOption.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmOption.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmOption.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmOption.txtPERSONINCHARGE")

        'If Me.txtOption.Text <> "" Then
        '    QueryOption("AND [Option] LIKE '" & MakeFilter(Me.txtOption.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryOption(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmOption.smnuDisplayCode")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayFax")
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayAddress")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayaPPROVE")
        'Me.smnuDisplayCountry.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayCountry")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmOption.smnuDisplayUpdateTime")
        'UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmOption_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
    '        objUserSetting.SetCParm("frmOption.cboFind", Me.cboFind.Text)
    '        objUserSetting.SetCParm("frmOption.txtOption", Me.txtOption.Text)
    '        objUserSetting.SetCParm("frmOption.txtCODE", Me.txtOptionCode.Text)
    '        objUserSetting.SetCParm("frmOption.txtOptionName", Me.TxtOptionName.Text)
    '        objUserSetting.SetCParm("frmOption.txtTel", Me.txtTel.Text)
    '        objUserSetting.SetCParm("frmOption.txtFax", Me.txtFax.Text)
    '        objUserSetting.SetCParm("frmOption.txtAddress", Me.txtAddress.Text)
    '        objUserSetting.SetCParm("frmOption.txtCountry", Me.txtCountry.Text)

    '        objUserSetting.SetCParm("frmOption.mFilter", mFilter)

    '        objUserSetting.SetBParm("frmOption.smnuDisplayName", Me.smnuDisplayName.Checked)
    '        objUserSetting.SetBParm("frmOption.smnuDisplayCode", Me.smnuDisplayCode.Checked)
    '        objUserSetting.SetBParm("frmOption.smnuDisplayTel", Me.smnuDisplayTel.Checked)
    '        objUserSetting.SetBParm("frmOption.smnuDisplayFax", Me.smnuDisplayFax.Checked)
    '        objUserSetting.SetBParm("frmOption.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

    '        objUserSetting.SetBParm("frmOption.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        objUserSetting.SetBParm("frmOption.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

    '        objUserSetting.SetBParm("frmOption.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmOption.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        Me.cmdCancel_Click(eventSender, eventArgs)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryOption(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryOption = strOptionSelect
        ' MakeQueryOption = MakeQueryOption & ", (SELECT count(*) FROM BillOfLading  WHERE [Option].OptionID = BillOfLading.OptionID) AS NumOfTransaction "
        MakeQueryOption = MakeQueryOption & " FROM [Option] "
        MakeQueryOption = MakeQueryOption & "WHERE (OptionID = '" & DefaultValue & "') "

        MakeQueryOption = MakeQueryOption & "OR ("
        MakeQueryOption = MakeQueryOption & "Continued = 1 "
        MakeQueryOption = MakeQueryOption & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryOption = MakeQueryOption & argCriteria
        End If
        'If index = 1 Then ' 
        MakeQueryOption = MakeQueryOption & strOptionOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryOption = MakeQueryOption & strOptionOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    'Public Function CodeOption() As Integer
    '    Dim rsCount As New ADODB.Recordset
    '    Dim code As Integer
    '    rsCount.Open("select Count(Option_Code) as CountNo from [Option]", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    code = rsCount.Fields("CountNo").Value
    '    Return code
    'End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmOption", "Add") Then
            'Me.txtOptionCode.Enabled = True
            Me.dgdOption.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mOptionId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtOptionCode.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveOption()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdOption.CurrentRow.Index
        Dim strQueryOptionList As String
        If Not Me.dgdOption.Item("Editable", index).Value Or Not UserRight("frmOption", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
            QueryOption(mFilter, , index)
        Else
            strQueryOptionList = "Select * from [Option] where" + " OptionID= '" & Me.dgdOption.Item("OptionID", index).Value.ToString & "'"
            rsOptionList.Open(strQueryOptionList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsOptionList.Fields("Approve").Value
            rsOptionList.Update("Approve", Approve)
            rsOptionList.Close()
        End If
        QueryOption(mFilter, , index)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE OptionID = '" & Me.dgdOption.Item("OptionID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from [Option] WHERE OptionId = '" & Me.dgdOption.Item("OptionId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The [Option] can not be removed.", "Cảng Này Không Thể Xoá"))
            Exit Sub
        End If
        'chư có ràng buộc
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The [Option] can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdOption.Item("Approve", index)) Then
            If Me.dgdOption.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdOption.Item("Editable", index)) Then
            If Not Me.dgdOption.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmOption", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        Else
            strMesg = "Delete the [Option]: " & Me.dgdOption.Item("OptionCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from [Option] where" + " OptionID= '" & Me.dgdOption.Item("OptionID", index).Value.ToString & "'"
                rsOptionList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsOptionList.Fields("continued").Value = 0
                rsOptionList.Update()

                rsOptionList.Requery()
                Me.dgdOption.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdOption.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsOptionList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdOption.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdOption.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryOption(mFilter)
    End Sub
    'Private Sub smnuDisplayCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCode.Click
    '    Me.smnuDisplayCode.Checked = Not Me.smnuDisplayCode.Checked
    '    UpdateFrame()
    'End Sub
    'Public Sub smnuDisplayName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayName.Click
    '    Me.smnuDisplayName.Checked = Not Me.smnuDisplayName.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayApprove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayApprove.Click
    '    Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayAddress_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayAddress.Click
    '    Me.smnuDisplayAddress.Checked = Not Me.smnuDisplayAddress.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayFax_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayFax.Click
    '    Me.smnuDisplayFax.Checked = Not Me.smnuDisplayFax.Checked
    '    UpdateFrame()
    'End Sub


    'Public Sub smnuDisplayCountry_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayCountry.Click
    '    Me.smnuDisplayCountry.Checked = Not Me.smnuDisplayCountry.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayUpdateTime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayUpdateTime.Click
    '    Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '    UpdateFrame()
    'End Sub

    'Public Sub smnuDisplayUserId_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayUserId.Click
    '    Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '    UpdateFrame()
    'End Sub


    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        'kiểm tra xem Grid có dữ liệu không

        If Me.dgdOption.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            Return
        End If
        Dim index As Integer = Me.dgdOption.CurrentRow.Index

        If index >= 0 Then
            Approve = Me.dgdOption.Item("Approve", index).Value
            EditTable = Me.dgdOption.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmOption", "Edit") And Not Me.dgdOption.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdOption.Height = 306
                Me.dgdOption.Enabled = False
                'Me.txtOptionCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mOptionID = Me.dgdOption.Item("OptionId", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        End If
        If UCase(Me.dgdOption.Item("frmname", index).Value) = "COLOR" Then
            Me.cboBackG.Visible = True
            Me.cboFra.Visible = True

        Else
            Me.cboBackG.Visible = False
            Me.cboFra.Visible = False
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "[Option] "
        ElseIf mStatus = "Edit" Then
            Me.Text = "[Option] -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "[Option] -> Add."
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========Query==========

    Private Sub QueryOption(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryOption()
        Else
            strQuery = MakeQueryOption(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "OptionList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdOption.DataSource = ds.Tables("OptionList")
        If Me.dgdOption.Enabled = False Then
            Me.dgdOption.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdOption.Columns.Item("OptionCode").ToolTipText = "Hiện có:" + CStr(Me.dgdOption.RowCount()) + " Options."
        End If
        If Me.dgdOption.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdOption.Rows.Count And Me.dgdOption.Rows.Count > 0 Then
            Me.dgdOption.Rows(location).Selected = True
            Me.dgdOption.CurrentCell = Me.dgdOption.Rows(location).Cells(1)
        End If
        InsertAutoNumberToGrid(Me.dgdOption)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub UpdateFrame()
    '        On Error GoTo Err_Renamed

    '        Me.dgdOption.Columns.Item("OptionID").Visible = False
    '        Me.dgdOption.Columns.Item("Option_Code").Visible = True  'Me.smnuDisplayCode.Checked
    '        Me.dgdOption.Columns.Item("[Option]").Visible = Me.smnuDisplayName.Checked
    '        Me.dgdOption.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
    '        Me.dgdOption.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
    '        Me.dgdOption.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
    '        Me.dgdOption.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked

    '        Me.dgdOption.Columns.Item("Editable").Visible = False
    '        Me.dgdOption.Columns.Item("Continued").Visible = False
    '        Me.dgdOption.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdOption.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
    '        Me.dgdOption.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdOption.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
        'If (Me.Height < IIf(fraUpdate.Visible, 540, 540)) Then
        '    Me.Height = IIf(fraUpdate.Visible, 540, 540)
        'End If
        'If Me.Width < 700 Then
        '    Me.Width = 700
        'End If
        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        dgdOption.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdOption.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdOption.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdOption.Height + dgdOption.Top '+ 100

        'Me.txtOption.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOk.Left = cmdCancel.Left - cmdOk.Width - 10
        'cmdFind.Left = Me.txtOption.Left + Me.txtOption.Width + 10
        'txtOption.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdOption_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdOption.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdOption.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdOption.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdOption.Columns(ColIndex).Name) = "APPROVE" And Me.dgdOption.CurrentCellAddress().Y = index Then
            Call ApproveOption()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdOption_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdOption.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryOption("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdOption)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdOption_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdOption.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdOption.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdOption.SelectedRows(i).Index)
                Next i
            End If

            QueryOption()
        End If
    End Sub




    'Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
    '    If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
    '        Me.cboFind.SelectedIndex = 0
    '        Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
    '    End If
    'End Sub




    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.txtName.Text = Me.dgdOption.Item("OptionName", index).Value.ToString
        Me.txtCode.Text = Me.dgdOption.Item("OptionCode", index).Value '.ToString
        Me.txtOptionValue.Text = Me.dgdOption.Item("OptionValue", index).Value.ToString
        'Me.txtFreeStorage.Text = Me.dgdOption.Item("FreeStorage", index).Value.ToString
        'Me.txtValidOrder.Text = Me.dgdOption.Item("ValidOrder", index).Value.ToString


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    'Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
    '    Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub frmOption_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strOptionId, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM [Option] "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("OptionID").Value = NewId()
    '                .Fields("Option_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("[Option]").Value = UCase(Trim(rs.Fields("Optionname").Value))
    '                .Fields("Tel").Value = ""
    '                .Fields("Fax").Value = ""
    '                .Fields("Address").Value = ""
    '                .Fields("Country").Value = UCase(Trim(rs.Fields("countrycode").Value))
    '                .Fields("Continued").Value = 1
    '                .Update()
    '            End With
    '            rs.MoveNext()
    '        End While
    '        rs1.Close()
    '        rs.Close()

    '        'không cần sắp xếp

    '        'If mStatus = "Edit" Then
    '        '    QueryOption(, 1)
    '        'Else
    '        '    QueryOption(, 15)
    '        'End If

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryOption("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            If Me.dgdOption.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdOption, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cboBackG_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboBackG.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cboBackG.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    'Private Sub txtCapacity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapacity.Leave
    '    If Me.txtCapacity.Text = "" Then
    '        MsgBox("Not allow null")
    '        Me.txtCapacity.Focus()
    '    End If
    'End Sub

    'Private Sub txtValidOrder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValidOrder.TextChanged
    '    If Me.txtValidOrder.Text = "" Then
    '        MsgBox("Not allow null")
    '        Me.txtValidOrder.Focus()
    '    End If
    'End Sub

    'Private Sub txtFreeStorage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreeStorage.TextChanged
    '    If Me.txtFreeStorage.Text = "" Then
    '        MsgBox("Not allow null")
    '        Me.txtFreeStorage.Focus()
    '    End If
    'End Sub

    Private Sub cboBackG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBackG.SelectedIndexChanged

    End Sub

    Private Sub cboFra_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboFra.MouseClick
        If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.cboFra.BackColor = Me.ColorDialog1.Color
        End If
    End Sub

    Private Sub cboFra_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFra.SelectedIndexChanged

    End Sub
End Class