Public Class frmUserList
    Dim rsUsrList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mUsr_ID As String
    Public mUsrDP_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strUsrSelect As String = "SELECT " & _
    "ur.UsrID, " & _
    "urDP.UserRightDepartmentID, " & _
    "ur.Usr, " & _
    "ur.Name , " & _
    "urDP.Department, " & _
    "ur.NickName," & _
    "ur.Tel," & _
    "ur.Ext," & _
    "ur.Mobile," & _
    "ur.Fax," & _
    "ur.Email," & _
    "ur.Approve, " & _
    "ur.Discontinued, " & _
    "ur.Editable, " & _
    "ur.UserId, " & _
    "ur.Updatetime "

    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String
        Msg = ""
        If Me.txtUserName.Text.Trim = "" Then
            Msg &= "Please input User Name"
        End If
        If mStatus = "Add" And Msg = "" Then
            Dim st As String = "Select count(*) cnt From UserList Where Usr='" & Me.txtUserName.Text.Trim & "'"
            Dim tbl As DataTable
            tbl = ReadTable(st)
            If tbl.Rows.Count = 0 Then
                Return False
            Else
                If tbl.Rows(0).Item("cnt") >= 1 Then
                    Msg &= "User Name đã tồn tại"
                End If
            End If
        End If
        If Me.txtFullName.Text.Trim = "" Then
            Msg &= "Please input Full Name"
        End If
        If FindValueID(Me.cboDepartment, Me.cboDepartment.Text.Trim) = "" Then
            Msg &= "The Department is invalid"
        End If
        
        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtFind.Text)
        If Me.txtFind.Text <> "" Then
            Select Case Me.cboFind.Text
                Case "User Name"
                    QueryUsr("AND ( ur.Usr LIKE '" & strFilter & "') ")
                Case "Full Name"
                    QueryUsr("AND (ur.Name LIKE '" & strFilter & "') ")
                Case "Department"
                    QueryUsr("AND (urDP.Department LIKE '" & strFilter & "') ")
            End Select
        Else
            QueryUsr()
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub frmUserList_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        Me.txtUserName.Enabled = True
        mStatus = "Normal"
        SetDefaultGrid(Me.dgdUsr, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        blnUpdated = False
        mUsr_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "User Name", "User Name")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Full Name", "Full Name")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Department", "Department")
        Me.cboFind.Items.Add(oItems)

        Me.cboFind.Text = objUserSetting.GetCParm("frmListUsr.cboFind", "User Name")
        mFilter = objUserSetting.GetCParm("frmListUsr.mFilter")

        If Me.txtFind.Text <> "" Then
            QueryUsr("AND ur.Usr LIKE '" & MakeFilter(Me.txtFind.Text) & "' " & mFilter, , )
        Else
            QueryUsr()
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If
        LoadCombo()
        ReFormat()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub frmUserList_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        ' ReFormat()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub frmUserList_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmListUsr.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmListUsr.txtFind", Me.txtFind.Text)
        objUserSetting.SetCParm("frmListUsr.txtUserName", Me.txtUserName.Text)

        objUserSetting.SetCParm("frmListUsr.txtFullName", Me.txtFullName.Text)

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryUsr(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryUsr = strUsrSelect
        MakeQueryUsr = MakeQueryUsr & ", manager1,manager2,manager3 From UserList ur left JOIN UserRightDepartment urDP ON ur.usr=urDP.usr"
        MakeQueryUsr = MakeQueryUsr & " WHERE  "

        MakeQueryUsr = MakeQueryUsr & "("
        MakeQueryUsr = MakeQueryUsr & "ur.Discontinued = 0 "
        MakeQueryUsr = MakeQueryUsr & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryUsr = MakeQueryUsr & argCriteria
        End If
        MakeQueryUsr &= " Order by ur.usr"
        'If index = 1 Then ' 
        '    MakeQueryUsr = MakeQueryUsr & strUsrOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryUsr = MakeQueryUsr & strUsrOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    '==========Menu==========
    
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmUserList", "Add") Then
            Me.fraUpdate.Visible = True
            Me.dgdUsr.Enabled = False
            Me.txtUserName.Enabled = True
            ReFormat()
            SetMenu((False))
            mUsr_ID = DefaultValue
            mUsrDP_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Public Sub ApproveUsr()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdUsr.CurrentRow.Index
        Dim strQueryUsrList As String
        If Not Me.dgdUsr.Item("Editable", index).Value Or Not UserRight("frmUserList", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryUsrList = "Select * from UserList where" + " UsrID= '" & dgdUsr.Item("UsrID", index).Value.ToString & "'"
            rsUsrList.Open(strQueryUsrList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsUsrList.Fields("Approve").Value
            rsUsrList.Update("Approve", Approve)
            rsUsrList.Close()
        End If
        QueryUsr(, , index)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid

        strQuery = "Select * from UserList WHERE UsrID = '" & Me.dgdUsr.Item("UsrID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Usr can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If


        'If Not IsNothing(Me.dgdUsr.Item("Approve", index)) Then
        '    If Me.dgdUsr.Item("Approve", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        '        Exit Sub
        '    End If
        'End If
        'If Not IsNothing(Me.dgdUsr.Item("Editable", index)) Then
        '    If Not Me.dgdUsr.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmUserList", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the User Name: " & Me.dgdUsr.Item("UserName", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from UserList where" + " UsrID= '" & Me.dgdUsr.Item("UsrID", index).Value.ToString & "'"
                rsUsrList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsUsrList.Fields("Discontinued").Value = 1
                rsUsrList.Update()
                rsUsrList.Requery()
                Me.dgdUsr.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdUsr.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsUsrList.Close()

                strQueryCommodityList = "Select * from UserRightDepartment where" + " usr= '" & Me.dgdUsr.Item("UserName", index).Value.ToString & "'"
                rsUsrList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsUsrList.Fields("Discontinued").Value = 1
                rsUsrList.Update()
                rsUsrList.Requery()
                Me.dgdUsr.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdUsr.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsUsrList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdUsr.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdUsr.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryUsr()
    End Sub

#Region "Xuly"
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        Dim index As Integer = Me.dgdUsr.CurrentRow.Index
        If index >= 0 Then
            'Approve = Me.dgdUsr.Item("Approve", index).Value
            'EditTable = Me.dgdUsr.Item("Editable", index).Value
            If mStatus = "Normal" Then 'And Not Approve And EditTable
                Me.dgdUsr.Height = 306
                Me.dgdUsr.Enabled = False
                ' Me.txtUserName.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mUsr_ID = Me.dgdUsr.Item("UsrID", index).Value.ToString
                mUsrDP_ID = Me.dgdUsr.Item("UserRightDepartmentID", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "User List "
        ElseIf mStatus = "Edit" Then
            Me.Text = "User List-> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "User List -> Add."
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========Query==========

    Private Sub QueryUsr(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryUsr()
        Else
            strQuery = MakeQueryUsr(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "UsrList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdUsr.DataSource = ds.Tables("UsrList")
        If Me.dgdUsr.Enabled = False Then
            Me.dgdUsr.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdUsr.Columns.Item("UserName").ToolTipText = "Hiện có:" + CStr(Me.dgdUsr.RowCount()) + " User."
        End If
        If Me.dgdUsr.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdUsr.Rows.Count And Me.dgdUsr.Rows.Count > 0 Then
            Me.dgdUsr.Rows(location).Selected = True
            Me.dgdUsr.CurrentCell = Me.dgdUsr.Rows(location).Cells(2)
        End If
        InsertAutoNumberToGrid(Me.dgdUsr)
        '--------------------
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
        'Resume
    End Sub

    '============Miscelanous==========
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        dgdUsr.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdUsr.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdUsr.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdUsr.Height + dgdUsr.Top

        Me.txtFind.Width = Me.Width - 300

        cmdFind.Left = Me.txtFind.Left + Me.txtFind.Width + 10
        txtFind.Width = Me.Width - 297

        Exit Sub
Err:
        DisplayMessage(True, Err.Description)

    End Sub

    Private Sub dgdPayableAt_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdUsr.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = 0
        index = Me.dgdUsr.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdUsr.CurrentCellAddress.X = 11 And Me.dgdUsr.CurrentCellAddress().Y = index Then
            Call ApproveUsr()
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        Try

       
            Dim oItems As PDSAListItemString
            Me.txtUserName.Text = Me.dgdUsr.Item("UserName", index).Value.ToString
            Me.txtFullName.Text = Me.dgdUsr.Item("FullName", index).Value.ToString
            Me.cboDepartment.Text = Me.dgdUsr.Item("Department", index).Value  'FindIDValue(Me.cboDepartment, Me.dgdUsr.Item("Department", index).Value.ToString)
            Me.txtNickname.Text = Me.dgdUsr.Item("Nickname", index).Value
            Me.txtEmail.Text = Me.dgdUsr.Item("Email", index).Value
            Me.txtExt.Text = Me.dgdUsr.Item("Ext", index).Value
            Me.txtfax.Text = Me.dgdUsr.Item("Fax", index).Value
            Me.txtMobile.Text = Me.dgdUsr.Item("Mobile", index).Value
            Me.txtTel.Text = Me.dgdUsr.Item("Tel", index).Value
            Try
                Me.cbomn1.Text = Me.dgdUsr.Item("mn1", index).Value
            Catch ex As Exception
                Me.cbomn1.Text = ""
            End Try
            Try
                Me.cbomn2.Text = Me.dgdUsr.Item("mn2", index).Value
            Catch ex As Exception
                Me.cbomn2.Text = ""
            End Try
            Try
                Me.cbomn3.Text = Me.dgdUsr.Item("mn3", index).Value
            Catch ex As Exception
                Me.cbomn3.Text = ""
            End Try


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Sub

    Private Sub frmListUsr_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strUsr_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Rows.Count > 0) Then
            index = Me.dgdUsr.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM UserList "
            strQuery = strQuery & "WHERE UsrID = '" & mUsr_ID & "' AND UsrID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("UsrID").Value = NewId()
                End If
                strUsr_ID = .Fields("UsrID").Value
                'If mStatus = "Edit" Then
                '    .Fields("Code").Value = Trim(Me.txtUsr_CODE.Text)
                'Else
                .Fields("Usr").Value = Me.txtUserName.Text
                'End If
                .Fields("Name").Value = Trim(Me.txtFullName.Text)
                .Fields("Department").Value = FindValueID(Me.cboDepartment, Me.cboDepartment.Text.Trim)
                .Fields("NickName").Value = Me.txtNickname.Text.Trim
                .Fields("Tel").Value = Me.txtTel.Text.Trim
                .Fields("Ext").Value = Me.txtExt.Text.Trim
                .Fields("Mobile").Value = Me.txtMobile.Text.Trim
                .Fields("Fax").Value = Me.txtfax.Text.Trim
                .Fields("Email").Value = Me.txtEmail.Text.Trim
                .Fields("manager1").Value = Me.cbomn1.Text.Trim
                .Fields("manager2").Value = Me.cbomn2.Text.Trim
                .Fields("manager3").Value = Me.cbomn3.Text.Trim
                .Fields("discontinued").Value = "0"
                .Update()

            End With
            rs.Close()

            '-----------------------------------
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM UserRightDepartment "
            strQuery = strQuery & "WHERE UserRightDepartmentID = '" & mUsrDP_ID & "' AND UserRightDepartmentID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                End If
                ' If mStatus = "Edit" Then
                '.Fields("Code").Value = Trim(me.txtUsr_CODE.Text)
                'Else
                .Fields("Usr").Value = Me.txtUserName.Text
                ' End If
                .Fields("Department").Value = Me.cboDepartment.Text.Trim
                .Fields("discontinued").Value = "0"
                .Update()

            End With
            rs.Close()

            Me.dgdUsr.Enabled = True
            If mStatus = "Add" Then
                QueryUsr()
            Else
                QueryUsr(, , index)
            End If


            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdUsr.Enabled = True
        Exit Sub

Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Sub LoadCombo()
        Try
            Dim id, value, strSQL As String
            id = "Code"
            value = "Name"
            strSQL = "Select * From Department Order By Name desc"
            loadDataToObject(Me.cboDepartment, strSQL, id, value)

            id = "UsrID"
            value = "Usr"
            strSQL = "Select UsrID,Usr From sale Order By usr desc"
            loadDataToObject(Me.cbomn1, strSQL, id, value)
            loadDataToObject(Me.cbomn2, strSQL, id, value)
            loadDataToObject(Me.cbomn3, strSQL, id, value)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtFind.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.cmdFind.PerformClick()
        End If
    End Sub
End Class