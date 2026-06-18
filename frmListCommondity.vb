Public Class frmListCommondity
    Dim CommondityLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsCommondityList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mCommondity_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strCommonditySelect As String = "SELECT " & _
    "Commondity_Id, " & _
    "Commondity, " & _
    "Remarks , " & _
    "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strSale_Id As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtCommondity.Text.Trim = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Commondity "
                strQuery = strQuery & "WHERE Commondity = '" & Me.txtCommondity.Text.Trim & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    CheckData = False
                    rs.Close()
                    DisplayMessage(True, IIf(gLang = "E", "This code had already in database", "Mã Này Đã Có Trong Cơ Sở Dữ Liệu"))
                End If
            End If
        End If
        'If Len(Me.cobTemperatureId.Text) = 0 Then
        '    CheckData = False
        '    strMsg = strMsg & "The Name is invalid. Please check again."
        'End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtSale.Text)

        If Me.txtSale.Text <> "" Then
            Select Case Me.cboFind.Text
                Case "Remarks"
                    QueryCommondity("AND ( Remarks LIKE N'" & strFilter & "') ")
                    'Me.dgdCommondity.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
                Case "Commondity"
                    QueryCommondity("AND (Commondity LIKE N'" & strFilter & "') ")
                    UpdateFrame()
            End Select
        Else
            QueryCommondity(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommondity_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mCommondity_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        SetDefaultGrid(Me.dgdCommondity, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Remarks", "Remarks")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Commondity", "Commondity")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListCommondity.cboFind", "Commondity")
        mFilter = objUserSetting.GetCParm("frmListCommondity.mFilter")
        Me.txtCommondity.Text = objUserSetting.GetCParm("frmListCommondity.txtCommondity")
        If Me.txtSale.Text <> "" Then
            QueryCommondity("AND Commondity LIKE '" & MakeFilter(Me.txtCommondity.Text) & "' " & mFilter, , 15)
        Else
            QueryCommondity(mFilter, , 15)
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListCommondity.smnuDisplayAPPROVE")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListCommondity.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListCommondity.smnuDisplayUpdateTime")

        UpdateFrame()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        '----set mau nen,fra
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
      
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListCommondity_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmListCommondity.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListCommondity.txtCommondity", Me.txtCommondity.Text)


        'objUserSetting.SetCParm("frmListCommondity.mFilter", mFilter)

        'objUserSetting.SetBParm("frmListCommondity.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        'objUserSetting.SetBParm("frmListCommondity.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListCommondity.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryCommondity(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryCommondity = strCommonditySelect
        MakeQueryCommondity = MakeQueryCommondity & "From Commondity "
        MakeQueryCommondity = MakeQueryCommondity & " WHERE  "

        MakeQueryCommondity = MakeQueryCommondity & "("
        MakeQueryCommondity = MakeQueryCommondity & "Continued = 1 "
        MakeQueryCommondity = MakeQueryCommondity & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCommondity = MakeQueryCommondity & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryCommondity = MakeQueryCommondity & strCommondityOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryCommondity = MakeQueryCommondity & strCommondityOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeCommondity() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Commondity) as CountNo from Commondity", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("mnumarketingsale", "Add") Then
            Me.txtRemark.Enabled = True
            Me.txtCommondity.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdCommondity.Enabled = False
            ReFormat()
            SetMenu((False))
            mCommondity_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtSale.Text = Me.txtSale.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveCommondity()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCommondity.CurrentRow.Index
        Dim strQueryCommondityList As String
        If Not Me.dgdCommondity.Item("Editable", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryCommondity(, , index)
        Else
            strQueryCommondityList = "Select * from Commondity where" + " Commondity_Id= '" & dgdCommondity.Item("Commondity_Id", index).Value.ToString & "'"
            rsCommondityList.Open(strQueryCommondityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsCommondityList.Fields("Approve").Value
            rsCommondityList.Update("Approve", Approve)
            rsCommondityList.Close()
        End If
        QueryCommondity()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Sale_Id = '" & Me.dgdCommondity.Item("Sale_Id", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Commondity WHERE Commondity_Id = '" & Me.dgdCommondity.Item("Commondity_Id", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Sale can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Commondity can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdCommondity.Item("Approve", index)) Then
            If Me.dgdCommondity.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdCommondity.Item("Editable", index)) Then
            If Not Me.dgdCommondity.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnumarketingsale", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Commondity : " & Me.dgdCommondity.Item("Commondity", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Commondity where" + " Commondity_Id= '" & Me.dgdCommondity.Item("Commondity_Id", index).Value.ToString & "'"
                rsCommondityList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsCommondityList.Fields("continued").Value = 0
                rsCommondityList.Update()
                rsCommondityList.Requery()
                Me.dgdCommondity.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdCommondity.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsCommondityList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdCommondity.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdCommondity.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryCommondity()
    End Sub
#Region "ViewMenuStrip"

    'Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '    UpdateFrame()
    'End Sub



    'Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '    UpdateFrame()
    'End Sub


#End Region

#Region "Xuly"
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Me.dgdCommondity.Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCommondity.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdCommondity.Item("Approve", index).Value
            EditTable = Me.dgdCommondity.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") And Not Me.dgdCommondity.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdCommondity.Height = 306
                ' Me.txtSaleCode.Enabled = False
                Me.dgdCommondity.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mCommondity_ID = Me.dgdCommondity.Item("Commondity_Id", index).Value.ToString
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
    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "List Of Commondity"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Commondity  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Commondity -> Add."
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

    Private Sub QueryCommondity(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCommondity()
        Else
            strQuery = MakeQueryCommondity(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "Commondity")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdCommondity.DataSource = ds.Tables("Commondity")
        If Me.dgdCommondity.Enabled = False Then
            Me.dgdCommondity.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdCommondity.Rows.Count And Me.dgdCommondity.Rows.Count > 0 Then
            Me.dgdCommondity.Rows(location).Selected = True
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdCommondity.Columns.Item("Commondity").ToolTipText = "Hiện có:" + CStr(Me.dgdCommondity.RowCount()) + " Commonditys."
        End If
        If Me.dgdCommondity.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        InsertAutoNumberToGrid(Me.dgdCommondity)
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

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        'Me.dgdCommondity.Columns.Item("Commondity_Id").Visible = False
        'Me.dgdCommondity.Columns.Item("Editable").Visible = False
        'Me.dgdCommondity.Columns.Item("Continued").Visible = False
        'Me.dgdCommondity.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdCommondity.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdCommondity.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - 10 - Me.Top
        Me.Width = frmMain.Width - 8
        dgdCommondity.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdCommondity.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdCommondity.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdCommondity.Height + dgdCommondity.Top

        Me.txtSale.Width = Me.Width - 300

        cmdCancel.Left = Me.fraUpdate.Width / 2 - cmdCancel.Width + 30
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtSale.Left + Me.txtSale.Width + 10
        txtSale.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdCommondity_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCommondity.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        index = Me.dgdCommondity.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdCommondity.CurrentCellAddress.X = 3 And Me.dgdCommondity.CurrentCellAddress().Y = index Then
            Call ApproveCommondity()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdCommondity_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdCommondity.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryCommondity("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
        InsertAutoNumberToGrid(Me.dgdCommondity)
    End Sub

    Private Sub dgdCommondity_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdCommondity.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdCommondity.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdCommondity.SelectedRows(i).Index)
                Next i
            End If

            QueryCommondity()
        End If
    End Sub

    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
        If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
            Me.cboFind.SelectedIndex = 0
            Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
        End If
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.txtRemark.Text = Me.dgdCommondity.Item("Remarks", index).Value.ToString
        Me.txtCommondity.Text = Me.dgdCommondity.Item("Commondity", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListCommondity_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strSale_Id, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Rows.Count > 0) Then
            index = Me.dgdCommondity.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Commondity "
            strQuery = strQuery & "WHERE Commondity_Id = '" & mCommondity_ID & "' AND Commondity_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Commondity_Id").Value = NewId()
                End If
                .Fields("Remarks").Value = Me.txtRemark.Text.Trim
                .Fields("Commondity").Value = Me.txtCommondity.Text.Trim
                .Update()

            End With
            rs.Close()
            Me.dgdCommondity.Enabled = True

            QueryCommondity(, 15, index)

            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            blnUpdated = True
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
        Me.dgdCommondity.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryCommondity("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdCommondity.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdCommondity, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class