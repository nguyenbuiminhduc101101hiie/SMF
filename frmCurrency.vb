Public Class frmCurrency

    Inherits System.Windows.Forms.Form

    Dim mStatus As String = "Normal"
    Dim mFilter As String

    Dim mCurrencyID As String = DefaultValue




    Dim rsCurrencyList As New ADODB.Recordset
    Public blnUpdated As Boolean

    Public oTable As DataTable
    Public ds As New DataSet

    

    Const strCurrencyOrder1 As String = _
           " ORDER BY Currency  Desc "
    Const strCurrencyOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    '    Private Function CheckData() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strMsg As String
    '        CheckData = True
    '        strMsg = ""
    '        Dim strCurrencyId As String
    '        If mStatus = "Add" Then
    '            strCurrencyId = DefaultValue
    '            If Me.txtCurrencyCode.Text = "" Then
    '                CheckData = False
    '                DisplayMessage(True, "The code not allow NULL value")
    '                Exit Function
    '            End If
    '            Dim rs As New ADODB.Recordset
    '            Dim strquery As String
    '            strquery = "SELECT * "
    '            strquery = strquery & "FROM Currency "
    '            strquery = strquery & "WHERE Currency_code = '" & Me.txtCurrencyCode.Text & "' And Continued=1"
    '            rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            If Not rs.EOF Then
    '                CheckData = False
    '                rs.Close()
    '                DisplayMessage(True, "This code had already in database")
    '                Exit Function
    '            End If
    '        End If
    '        If Len(Me.TxtCurrencyName.Text) = 0 Then
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
        Me.dgdCurrency.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtCurrency.Text)
    '        If Me.txtCurrency.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtCurrency.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdCurrency)
    '            'Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            QueryCurrency("AND ( Currency_CODE LIKE '" & strFilter & "') ")
    '            '            If Me.smnuDisplayCode.Checked = False Then
    '            '                Me.smnuDisplayCode.Checked = True
    '            '            End If
    '            '            Me.dgdCurrency.Columns.Item("Currency_CODE").Visible = Me.smnuDisplayCode.Checked
    '            '        Case "NAME"
    '            '            QueryCurrency("AND (Currency LIKE '" & strFilter & "')")
    '            '            If Me.smnuDisplayName.Checked = False Then
    '            '                Me.smnuDisplayName.Checked = True
    '            '            End If
    '            '            UpdateFrame()
    '            '        Case "TAX"
    '            '            QueryCurrency("AND (TAX LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayTax.Checked = False Then
    '            '                Me.smnuDisplayTax.Checked = True
    '            '            End If
    '            '            Me.dgdCurrency.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
    '            '        Case "E-MAIL"
    '            '            QueryCurrency("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayFax.Checked = False Then
    '            '                Me.smnuDisplayFax.Checked = True
    '            '            End If
    '            '            Me.dgdCurrency.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
    '            '    End Select
    '            'Else
    '            '    QueryCurrency(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strCurrencyId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        If mStatus = "Edit" Then
            index = Me.dgdCurrency.CurrentRow.Index
        End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Currency "
            strQuery = strQuery & "WHERE CurrencyId = '" & mCurrencyID & "' AND CurrencyId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CurrencyId").Value = NewId()
                End If
                strCurrencyId = .Fields("CurrencyId").Value

                .Fields("Currency").Value = UCase(Trim(Me.txtCurrency.Text))
                .Fields("Exchange").Value = UCase(Trim(Me.txtRate.Text))
                .Fields("ngay").Value = ddMMMyyyy(Me.dtpNgay.Value.Date)
                .Fields("code").Value = UCase(Trim(Me.txtcode.Text))

                '.Fields("Freestorage").Value = Me.txtFreeStorage.Text
                '.Fields("Capacity").Value = UCase(Trim(Me.txtCapacity.Text))
                '.Fields("ValidOrder").Value = Me.txtValidOrder.Text
                ''.Fields("Country").Value = UCase(Trim(Me.txtCountry.Text))
                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()

            'không cần sắp xếp

            'If mStatus = "Edit" Then
            '    QueryCurrency(, 1)
            'Else
            '    QueryCurrency(, 15)
            'End If
            Me.dgdCurrency.Enabled = True
            'fraUpdate chỉ visible khi thêm hay sửa thành công
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            QueryCurrency(mFilter, , index)
            mStatus = "Normal"
            blnUpdated = True
        End If





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmCurrency_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdCurrency, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mCurrencyID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdCurrency)
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

        'Me.cboFind.Text = objUserSetting.GetCParm("frmCurrency.cboFind", "NAME")
        'mFilter = objUserSetting.GetCParm("frmCurrency.mFilter")
        'Me.txtCurrencyCode.Text = objUserSetting.GetCParm("frmCurrency.txtCODE")
        'Me.TxtCurrencyName.Text = objUserSetting.GetCParm("frmCurrency.txtCurrencyName")
        'Me.txtTel.Text = objUserSetting.GetCParm("frmCurrency.txtTel")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmCurrency.txtFax")
        'Me.txtAddress.Text = objUserSetting.GetCParm("frmCurrency.txtAddress")
        'Me.txtCountry.Text = objUserSetting.GetCParm("frmCurrency.txtCountry")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmCurrency.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmCurrency.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmCurrency.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmCurrency.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmCurrency.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmCurrency.txtPERSONINCHARGE")

        'If Me.txtCurrency.Text <> "" Then
        '    QueryCurrency("AND Currency LIKE '" & MakeFilter(Me.txtCurrency.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryCurrency(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmCurrency.smnuDisplayCode")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayFax")
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayAddress")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayaPPROVE")
        'Me.smnuDisplayCountry.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayCountry")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmCurrency.smnuDisplayUpdateTime")
        'UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        Me.BackColor = gMaunen
    
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmCurrency_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub frmListVVIP_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
    '        objUserSetting.SetCParm("frmCurrency.cboFind", Me.cboFind.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtCurrency", Me.txtCurrency.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtCODE", Me.txtCurrencyCode.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtCurrencyName", Me.TxtCurrencyName.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtTel", Me.txtTel.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtFax", Me.txtFax.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtAddress", Me.txtAddress.Text)
    '        objUserSetting.SetCParm("frmCurrency.txtCountry", Me.txtCountry.Text)

    '        objUserSetting.SetCParm("frmCurrency.mFilter", mFilter)

    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayName", Me.smnuDisplayName.Checked)
    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayCode", Me.smnuDisplayCode.Checked)
    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayTel", Me.smnuDisplayTel.Checked)
    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayFax", Me.smnuDisplayFax.Checked)
    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmCurrency.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        Me.cmdCancel_Click(eventSender, eventArgs)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryCurrency(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        Dim strCurrencySelect As String = "SELECT " & _
    "CurrencyID, " & _
    "Currency, Exchange as Rate,ngay,code, " & _
    "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

        MakeQueryCurrency = strCurrencySelect
        ' MakeQueryCurrency = MakeQueryCurrency & ", (SELECT count(*) FROM BillOfLading  WHERE Currency.CurrencyID = BillOfLading.CurrencyID) AS NumOfTransaction "
        MakeQueryCurrency = MakeQueryCurrency & " FROM Currency "
        MakeQueryCurrency = MakeQueryCurrency & "WHERE (CurrencyID = '" & DefaultValue & "') "

        MakeQueryCurrency = MakeQueryCurrency & "OR ("
        MakeQueryCurrency = MakeQueryCurrency & "Continued = 1 "
        MakeQueryCurrency = MakeQueryCurrency & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCurrency = MakeQueryCurrency & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryCurrency = MakeQueryCurrency & strCurrencyOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryCurrency = MakeQueryCurrency & strCurrencyOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    'Public Function CodeCurrency() As Integer
    '    Dim rsCount As New ADODB.Recordset
    '    Dim code As Integer
    '    rsCount.Open("select Count(Currency_Code) as CountNo from Currency", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    code = rsCount.Fields("CountNo").Value
    '    Return code
    'End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" Then 'And UserRight("frmCurrency", "Add")
            'Me.txtCurrencyCode.Enabled = True
            Me.dgdCurrency.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mCurrencyID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtCurrencyCode.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveCurrency()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCurrency.CurrentRow.Index
        Dim strQueryCurrencyList As String
        If Not Me.dgdCurrency.Item("Editable", index).Value Or Not UserRight("frmCurrency", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
            QueryCurrency(mFilter, , index)
        Else
            strQueryCurrencyList = "Select * from Currency where" + " CurrencyID= '" & Me.dgdCurrency.Item("CurrencyID", index).Value.ToString & "'"
            rsCurrencyList.Open(strQueryCurrencyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsCurrencyList.Fields("Approve").Value
            rsCurrencyList.Update("Approve", Approve)
            rsCurrencyList.Close()
        End If
        QueryCurrency(mFilter, , index)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE CurrencyID = '" & Me.dgdCurrency.Item("CurrencyID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Currency WHERE CurrencyId = '" & Me.dgdCurrency.Item("CurrencyId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Currency can not be removed.", "Cảng Này Không Thể Xoá"))
            Exit Sub
        End If
        'chư có ràng buộc
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Currency can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        'If Not IsNothing(Me.dgdCurrency.Item("Approve", index)) Then
        '    If Me.dgdCurrency.Item("Approve", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        '        Exit Sub
        '    End If
        'End If
        'If Not IsNothing(Me.dgdCurrency.Item("Editable", index)) Then
        '    If Not Me.dgdCurrency.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        'If Not UserRight("frmCurrency", "Delete") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        'Else
        strMesg = "Delete the Currency: " & Me.dgdCurrency.Item("Currency", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            strQueryCommodityList = "Select * from Currency where" + " CurrencyID= '" & Me.dgdCurrency.Item("CurrencyID", index).Value.ToString & "'"
            rsCurrencyList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rsCurrencyList.Fields("continued").Value = 0
            rsCurrencyList.Update()

            rsCurrencyList.Requery()
            Me.dgdCurrency.Rows(index).DefaultCellStyle.ForeColor = Color.White
            Me.dgdCurrency.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            rsCurrencyList.Close()
            blnUpdated = True
            ' End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdCurrency.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdCurrency.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryCurrency(mFilter)
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

        If Me.dgdCurrency.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            Return
        End If
        Dim index As Integer = Me.dgdCurrency.CurrentRow.Index

        If index >= 0 Then
            'Approve = Me.dgdCurrency.Item("Approve", index).Value
            'EditTable = Me.dgdCurrency.Item("Editable", index).Value
            If mStatus = "Normal" Then
                Me.dgdCurrency.Height = 306
                Me.dgdCurrency.Enabled = False
                'Me.txtCurrencyCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mCurrencyID = Me.dgdCurrency.Item("CurrencyId", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Currency "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Currency -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Currency -> Add."
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

    Private Sub QueryCurrency(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCurrency()
        Else
            strQuery = MakeQueryCurrency(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "CurrencyList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdCurrency.DataSource = ds.Tables("CurrencyList")
        If Me.dgdCurrency.Enabled = False Then
            Me.dgdCurrency.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdCurrency.Columns.Item("Currency").ToolTipText = "Hiện có:" + CStr(Me.dgdCurrency.RowCount()) + " Currencys."
        End If
        If Me.dgdCurrency.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdCurrency.Rows.Count And Me.dgdCurrency.Rows.Count > 0 Then
            Me.dgdCurrency.Rows(location).Selected = True
            Me.dgdCurrency.CurrentCell = Me.dgdCurrency.Rows(location).Cells(1)
        End If
        InsertAutoNumberToGrid(Me.dgdCurrency)
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

    '        Me.dgdCurrency.Columns.Item("CurrencyID").Visible = False
    '        Me.dgdCurrency.Columns.Item("Currency_Code").Visible = True  'Me.smnuDisplayCode.Checked
    '        Me.dgdCurrency.Columns.Item("Currency").Visible = Me.smnuDisplayName.Checked
    '        Me.dgdCurrency.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
    '        Me.dgdCurrency.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
    '        Me.dgdCurrency.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
    '        Me.dgdCurrency.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked

    '        Me.dgdCurrency.Columns.Item("Editable").Visible = False
    '        Me.dgdCurrency.Columns.Item("Continued").Visible = False
    '        Me.dgdCurrency.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdCurrency.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
    '        Me.dgdCurrency.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdCurrency.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        dgdCurrency.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdCurrency.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdCurrency.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdCurrency.Height + dgdCurrency.Top '+ 100

        'Me.txtCurrency.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOk.Left = cmdCancel.Left - cmdOk.Width - 10
        'cmdFind.Left = Me.txtCurrency.Left + Me.txtCurrency.Width + 10
        'txtCurrency.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdCurrency_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCurrency.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdCurrency.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCurrency.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdCurrency.Columns(ColIndex).Name) = "APPROVE" And Me.dgdCurrency.CurrentCellAddress().Y = index Then
            Call ApproveCurrency()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdCurrency_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdCurrency.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryCurrency("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdCurrency)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdCurrency_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdCurrency.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdCurrency.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdCurrency.SelectedRows(i).Index)
                Next i
            End If

            QueryCurrency()
        End If
    End Sub




    'Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
    '    If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
    '        Me.cboFind.SelectedIndex = 0
    '        Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
    '    End If
    'End Sub




    Private Sub RefreshData(ByVal index As Integer)
        Try



            Dim oItems As PDSAListItemString
            Me.txtCurrency.Text = Me.dgdCurrency.Item("Currency", index).Value.ToString
            Me.txtRate.Text = Me.dgdCurrency.Item("Rate", index).Value.ToString
            Try
                Me.dtpNgay.Value = Me.dgdCurrency.Item("ngay", index).Value.ToString
            Catch ex As Exception

            End Try

            Me.txtcode.Text = Me.dgdCurrency.Item("code", index).Value.ToString
            'Me.txtCapacity.Text = Me.dgdCurrency.Item("Capacity", index).Value.ToString
            'Me.txtFreeStorage.Text = Me.dgdCurrency.Item("FreeStorage", index).Value.ToString
            'Me.txtValidOrder.Text = Me.dgdCurrency.Item("ValidOrder", index).Value.ToString

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub

    'Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
    '    Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub frmCurrency_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strCurrencyId, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM Currency "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("CurrencyID").Value = NewId()
    '                .Fields("Currency_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("Currency").Value = UCase(Trim(rs.Fields("Currencyname").Value))
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
    '        '    QueryCurrency(, 1)
    '        'Else
    '        '    QueryCurrency(, 15)
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
                QueryCurrency("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            If Me.dgdCurrency.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdCurrency, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
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

    Private Sub ClpsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClpsToolStripMenuItem.Click
        Try
            Dim url As String = "https://youtu.be/MMcnCJgaPcE"

            Process.Start(url)
        Catch ex As Exception

        End Try
    End Sub
End Class