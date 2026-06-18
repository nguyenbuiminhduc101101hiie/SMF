Public Class frmSaleTarget
    Inherits System.Windows.Forms.Form

    Dim mStatus As String = "Normal"
    Dim mFilter As String

    Dim mSalesTarget As String = DefaultValue




    Dim rsTerminalList As New ADODB.Recordset
    Public blnUpdated As Boolean

    Public oTable As DataTable
    Public ds As New DataSet

    Const strTerminalSelect As String = "SELECT " & _
    "SalesTargetID, " & _
    "Terminalname ,Code,Capacity,Freestorage, ValidOrder," & _
    "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "


    Const strTerminalOrder1 As String = _
           " ORDER BY TerminalName  Desc "
    Const strTerminalOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    '    Private Function CheckData() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strMsg As String
    '        CheckData = True
    '        strMsg = ""
    '        Dim strSalesTargetID As String
    '        If mStatus = "Add" Then
    '            strSalesTargetID = DefaultValue
    '            If Me.txtTerminalCode.Text = "" Then
    '                CheckData = False
    '                DisplayMessage(True, "The code not allow NULL value")
    '                Exit Function
    '            End If
    '            Dim rs As New ADODB.Recordset
    '            Dim strquery As String
    '            strquery = "SELECT * "
    '            strquery = strquery & "FROM Terminal "
    '            strquery = strquery & "WHERE Terminal_code = '" & Me.txtTerminalCode.Text & "' And Continued=1"
    '            rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            If Not rs.EOF Then
    '                CheckData = False
    '                rs.Close()
    '                DisplayMessage(True, "This code had already in database")
    '                Exit Function
    '            End If
    '        End If
    '        If Len(Me.TxtTerminalName.Text) = 0 Then
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
        Me.dgdterminal.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtTerminal.Text)
    '        If Me.txtTerminal.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtTerminal.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdterminal)
    '            'Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            QueryTerminal("AND ( Terminal_CODE LIKE '" & strFilter & "') ")
    '            '            If Me.smnuDisplayCode.Checked = False Then
    '            '                Me.smnuDisplayCode.Checked = True
    '            '            End If
    '            '            Me.dgdterminal.Columns.Item("Terminal_CODE").Visible = Me.smnuDisplayCode.Checked
    '            '        Case "NAME"
    '            '            QueryTerminal("AND (Terminal LIKE '" & strFilter & "')")
    '            '            If Me.smnuDisplayName.Checked = False Then
    '            '                Me.smnuDisplayName.Checked = True
    '            '            End If
    '            '            UpdateFrame()
    '            '        Case "TAX"
    '            '            QueryTerminal("AND (TAX LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayTax.Checked = False Then
    '            '                Me.smnuDisplayTax.Checked = True
    '            '            End If
    '            '            Me.dgdterminal.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
    '            '        Case "E-MAIL"
    '            '            QueryTerminal("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayFax.Checked = False Then
    '            '                Me.smnuDisplayFax.Checked = True
    '            '            End If
    '            '            Me.dgdterminal.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
    '            '    End Select
    '            'Else
    '            '    QueryTerminal(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strSalesTargetID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0


        If mStatus = "Edit" Then
            index = Me.dgdterminal.CurrentRow.Index
        End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM salestarget "
            strQuery = strQuery & "WHERE id = '" & mSalesTarget & "' AND id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("id").Value = NewId()
                End If
                strSalesTargetID = .Fields("id").Value

                .Fields("salecode").Value = UCase(Trim(Me.cbosale.Text))
                .Fields("tu").Value = Me.dtpfrom.Value.Date
                .Fields("den").Value = Me.dtpto.Value.Date
                .Fields("target").Value = Me.txttarget.Text
                .Fields("bonus").Value = Me.txtBonus.Text
                '.Fields("Country").Value = UCase(Trim(Me.txtCountry.Text))
                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()

            'không c?n s?p x?p

            'If mStatus = "Edit" Then
            '    QueryTerminal(, 1)
            'Else
            '    QueryTerminal(, 15)
            'End If
            Me.dgdterminal.Enabled = True
            'fraUpdate ch? visible khi thêm hay s?a thành công
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            'l?y d? li?u ??a vào l??i sau khi thêm hay c?p nh?t thành công
            QueryTerminal(mFilter, , index)
            mStatus = "Normal"
            blnUpdated = True
        End If





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmTerminal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdterminal, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mSalesTarget = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao ??i t??ng oItems ?? thêm d? li?u vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdterminal)
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

        'Me.cboFind.Text = objUserSetting.GetCParm("frmTerminal.cboFind", "NAME")
        'mFilter = objUserSetting.GetCParm("frmTerminal.mFilter")
        'Me.txtTerminalCode.Text = objUserSetting.GetCParm("frmTerminal.txtCODE")
        'Me.TxtTerminalName.Text = objUserSetting.GetCParm("frmTerminal.txtTerminalName")
        'Me.txtTel.Text = objUserSetting.GetCParm("frmTerminal.txtTel")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmTerminal.txtFax")
        'Me.txtAddress.Text = objUserSetting.GetCParm("frmTerminal.txtAddress")
        'Me.txtCountry.Text = objUserSetting.GetCParm("frmTerminal.txtCountry")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmTerminal.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmTerminal.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmTerminal.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmTerminal.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmTerminal.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmTerminal.txtPERSONINCHARGE")

        'If Me.txtTerminal.Text <> "" Then
        '    QueryTerminal("AND Terminal LIKE '" & MakeFilter(Me.txtTerminal.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryTerminal(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmTerminal.smnuDisplayCode")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayFax")
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayAddress")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayaPPROVE")
        'Me.smnuDisplayCountry.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayCountry")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmTerminal.smnuDisplayUpdateTime")
        'UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
        '--------------------------------------------
        Dim id, value, strquery As String
        '--
        Me.cbosale.Items.Clear()
        id = "salecode"
        value = "salecode"
        strQuery = "Select salecode from sale where CONTINUED=1 Order by salecode "
        loadDataToObject(Me.cbosale, strQuery, id, value)
        '--------------------------
        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmTerminal_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
    '        objUserSetting.SetCParm("frmTerminal.cboFind", Me.cboFind.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtTerminal", Me.txtTerminal.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtCODE", Me.txtTerminalCode.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtTerminalName", Me.TxtTerminalName.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtTel", Me.txtTel.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtFax", Me.txtFax.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtAddress", Me.txtAddress.Text)
    '        objUserSetting.SetCParm("frmTerminal.txtCountry", Me.txtCountry.Text)

    '        objUserSetting.SetCParm("frmTerminal.mFilter", mFilter)

    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayName", Me.smnuDisplayName.Checked)
    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayCode", Me.smnuDisplayCode.Checked)
    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayTel", Me.smnuDisplayTel.Checked)
    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayFax", Me.smnuDisplayFax.Checked)
    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmTerminal.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        Me.cmdCancel_Click(eventSender, eventArgs)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryTerminal(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryTerminal = "select * "
        ' MakeQueryTerminal = MakeQueryTerminal & ", (SELECT count(*) FROM BillOfLading  WHERE Terminal.SalesTargetID = BillOfLading.SalesTargetID) AS NumOfTransaction "
        MakeQueryTerminal = MakeQueryTerminal & " FROM salestarget "
        MakeQueryTerminal = MakeQueryTerminal & "  where (1=1) "

        MakeQueryTerminal = MakeQueryTerminal & " "
        MakeQueryTerminal = MakeQueryTerminal & ""
        MakeQueryTerminal = MakeQueryTerminal & " "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryTerminal = MakeQueryTerminal & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryTerminal = MakeQueryTerminal & strTerminalOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryTerminal = MakeQueryTerminal & strTerminalOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    'Public Function CodeTerminal() As Integer
    '    Dim rsCount As New ADODB.Recordset
    '    Dim code As Integer
    '    rsCount.Open("select Count(Terminal_Code) as CountNo from Terminal", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    code = rsCount.Fields("CountNo").Value
    '    Return code
    'End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" Then 'And UserRight("frmTerminal", "Add")
            'Me.txtTerminalCode.Enabled = True
            Me.dgdterminal.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mSalesTarget = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtTerminalCode.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "B?n Pg?i ???c C?p Quy?n"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveTerminal()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác ??nh v? trí row trong grid
        Dim index As Integer = Me.dgdterminal.CurrentRow.Index
        Dim strQueryTerminalList As String
        If Not Me.dgdterminal.Item("Editable", index).Value Or Not UserRight("frmTerminal", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "B?n Pg?i ???c C?p Quy?n."))
            QueryTerminal(mFilter, , index)
        Else
            strQueryTerminalList = "Select * from Terminal where" + " SalesTargetID= '" & Me.dgdterminal.Item("SalesTargetID", index).Value.ToString & "'"
            rsTerminalList.Open(strQueryTerminalList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsTerminalList.Fields("Approve").Value
            rsTerminalList.Update("Approve", Approve)
            rsTerminalList.Close()
        End If
        QueryTerminal(mFilter, , index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        Dim cmd As New ADODB.Command
        ' Xác ??nh v? trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE SalesTargetID = '" & Me.dgdterminal.Item("SalesTargetID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        'strQuery = "Select * from Terminal WHERE SalesTargetID = '" & Me.dgdterminal.Item("SalesTargetID", index).Value.ToString & "' And UserId='DBO' "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEOF = rs.EOF
        'rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, The Terminal can not be removed.", "C?ng Này Không Th? Xoá"))
        '    Exit Sub
        'End If
        'ch? có ràng bu?c
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Terminal can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        'If Not IsNothing(Me.dgdterminal.Item("Approve", index)) Then
        '    If Me.dgdterminal.Item("Approve", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "B?n C?n ???c C?p Quy?n"))
        '        Exit Sub
        '    End If
        'End If
        'If Not IsNothing(Me.dgdterminal.Item("Editable", index)) Then
        '    If Not Me.dgdterminal.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "B?n C?n ???c C?p Quy?n"))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        'If Not UserRight("frmTerminal", "Delete") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "B?n C?n ???c C?p Quy?n"))
        'Else
        strMesg = "Delete the Terminal: " & Me.dgdterminal.Item("Sale", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from salestarget where id= '" & Me.dgdterminal.Item("id", index).Value.ToString & "' "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            'strQueryCommodityList = "Select * from Terminal where" + " SalesTargetID= '" & Me.dgdterminal.Item("SalesTargetID", index).Value.ToString & "'"
            'rsTerminalList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rsTerminalList.Fields("continued").Value = 0
            'rsTerminalList.Update()

            'rsTerminalList.Requery()
            'Me.dgdterminal.Rows(index).DefaultCellStyle.ForeColor = Color.White
            'Me.dgdterminal.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            'rsTerminalList.Close()
            'blnUpdated = True
        End If
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdterminal.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdterminal.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryTerminal(mFilter)
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

        'ki?m tra xem Grid có d? li?u không

        If Me.dgdterminal.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có D? Li?u"))
            Return
        End If
        Dim index As Integer = Me.dgdterminal.CurrentRow.Index

        If index >= 0 Then
            'Approve = Me.dgdterminal.Item("Approve", index).Value
            'EditTable = Me.dgdterminal.Item("Editable", index).Value
            If mStatus = "Normal" Then
                Me.dgdterminal.Height = 306
                Me.dgdterminal.Enabled = False
                'Me.txtTerminalCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mSalesTarget = Me.dgdterminal.Item("id", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "B?n c?n ???c c?p quy?n."))
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Sales Target "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Sales Target -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Sales Target -> Add."
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

    Private Sub QueryTerminal(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryTerminal()
        Else
            strQuery = MakeQueryTerminal(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "TerminalList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdterminal.DataSource = ds.Tables("TerminalList")
        If Me.dgdterminal.Enabled = False Then
            Me.dgdterminal.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        'If oTable.Rows.Count > 0 Then
        '    Me.dgdterminal.Columns.Item("TerminalCode").ToolTipText = "Hi?n có:" + CStr(Me.dgdterminal.RowCount()) + " Terminals."
        'End If
        'If Me.dgdterminal.RowCount() = 0 Then
        '    DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có d? li?u!"))
        'End If
        '------------v? trí BM
        If location > 0 And location <= Me.dgdterminal.Rows.Count And Me.dgdterminal.Rows.Count > 0 Then
            Me.dgdterminal.Rows(location).Selected = True
            Me.dgdterminal.CurrentCell = Me.dgdterminal.Rows(location).Cells(1)
        End If
        InsertAutoNumberToGrid(Me.dgdterminal)
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

    '        Me.dgdterminal.Columns.Item("SalesTargetID").Visible = False
    '        Me.dgdterminal.Columns.Item("Terminal_Code").Visible = True  'Me.smnuDisplayCode.Checked
    '        Me.dgdterminal.Columns.Item("Terminal").Visible = Me.smnuDisplayName.Checked
    '        Me.dgdterminal.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
    '        Me.dgdterminal.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
    '        Me.dgdterminal.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
    '        Me.dgdterminal.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked

    '        Me.dgdterminal.Columns.Item("Editable").Visible = False
    '        Me.dgdterminal.Columns.Item("Continued").Visible = False
    '        Me.dgdterminal.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdterminal.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
    '        Me.dgdterminal.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdterminal.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        dgdterminal.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdterminal.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdterminal.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdterminal.Height + dgdterminal.Top '+ 100

        'Me.txtTerminal.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOk.Left = cmdCancel.Left - cmdOk.Width - 10
        'cmdFind.Left = Me.txtTerminal.Left + Me.txtTerminal.Width + 10
        'txtTerminal.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdterminal_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdterminal.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác ??nh v? trí row trong grid
        If Me.dgdterminal.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdterminal.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdterminal.Columns(ColIndex).Name) = "APPROVE" And Me.dgdterminal.CurrentCellAddress().Y = index Then
            Call ApproveTerminal()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdterminal_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdterminal.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryTerminal("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdterminal)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdterminal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdterminal.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdterminal.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdterminal.SelectedRows(i).Index)
                Next i
            End If

            QueryTerminal()
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
        Me.cbosale.Text = Me.dgdterminal.Item("sale", index).Value.ToString
        Me.dtpfrom.Value = Me.dgdterminal.Item("tu", index).Value.ToString
        Me.dtpto.Value = Me.dgdterminal.Item("den", index).Value.ToString
        Me.txttarget.Text = Me.dgdterminal.Item("target", index).Value.ToString
        Me.txtBonus.Text = Me.dgdterminal.Item("bonus", index).Value.ToString


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    'Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
    '    Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub frmTerminal_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strSalesTargetID, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM Terminal "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("SalesTargetID").Value = NewId()
    '                .Fields("Terminal_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("Terminal").Value = UCase(Trim(rs.Fields("Terminalname").Value))
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

    '        'không c?n s?p x?p

    '        'If mStatus = "Edit" Then
    '        '    QueryTerminal(, 1)
    '        'Else
    '        '    QueryTerminal(, 15)
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
                QueryTerminal("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            If Me.dgdterminal.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdterminal, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

   

    
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strSalesTargetID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0


      
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM salestarget "
            strQuery = strQuery & "WHERE id = '" & mSalesTarget & "' AND id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("id").Value = NewId()
                End If
                strSalesTargetID = .Fields("id").Value

                .Fields("salecode").Value = UCase(Trim(Me.cbosale.Text))
                .Fields("tu").Value = Me.dtpfrom.Value.Date
                .Fields("den").Value = Me.dtpto.Value.Date
                .Fields("target").Value = Me.txttarget.Text
                .Fields("bonus").Value = Me.txtBonus.Text
                '.Fields("Country").Value = UCase(Trim(Me.txtCountry.Text))
                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()

            'không c?n s?p x?p

            'If mStatus = "Edit" Then
            '    QueryTerminal(, 1)
            'Else
            '    QueryTerminal(, 15)
            'End If
            'Me.dgdterminal.Enabled = True
            'fraUpdate ch? visible khi thêm hay s?a thành công
            ' Me.fraUpdate.Visible = False
            'ReFormat()
            ' SetMenu((True))
            'l?y d? li?u ??a vào l??i sau khi thêm hay c?p nh?t thành công
            QueryTerminal(mFilter, , index)
            ' mStatus = "Normal"
            ' blnUpdated = True
        End If





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class