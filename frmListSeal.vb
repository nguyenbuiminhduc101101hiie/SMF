Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListSeal
    Inherits System.Windows.Forms.Form
    Dim DateOfSealLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsDateOfSealList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mSeal_Id As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strDateOfSealSelect As String = "SELECT " & _
    "Seal_Id, " & _
    "SealNo, " & _
    "DateOfSeal , " & _
   "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strDateOfSealOrder1 As String = _
           " ORDER BY SealNo  Desc "
    Const strDateOfSealOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strSeal_Id As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtSealNo.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Seal "
                strQuery = strQuery & "WHERE SealNo = '" & Me.txtSealNo.Text & "' And Continued=1"
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
        strFilter = MakeFilter(Me.txtSeal.Text)
        If Me.txtSeal.Text <> "" Then
            Select Case Me.cboFind.Text
                Case "Seal No"
                    QueryDateOfSeal("AND ( SealNo LIKE '" & strFilter & "') " & mFilter)
                    'Me.dgdSeal.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
                Case "DateOfSeal"
                    QueryDateOfSeal("AND (DateOfSeal LIKE '" & strFilter & "')" & mFilter)
                    UpdateFrame()
            End Select
        Else
            QueryDateOfSeal(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListSeal_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mSeal_Id = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        SetDefaultGrid(Me.dgdSeal, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Seal No", "Seal No")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "DateOfSeal", "DateOfSeal")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListSeal.cboFind", "DateOfSeal")
        mFilter = objUserSetting.GetCParm("frmListSeal.mFilter")
        Me.txtSealNo.Text = objUserSetting.GetCParm("frmListSeal.txtSealNo")
        If Me.txtSeal.Text <> "" Then
            QueryDateOfSeal("AND SealNo LIKE '" & MakeFilter(Me.dtpSealDate.Text) & "' " & mFilter, , 15)
        Else
            QueryDateOfSeal(mFilter, , 15)
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListSeal.smnuDisplayAPPROVE")
        'Me.smnuDisplaySealDate.Checked = objUserSetting.GetBParm("frmListSeal.smnuDisplayDateOfSeal")


        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListSeal.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListSeal.smnuDisplayUpdateTime")

        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListSeal_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmListSeal.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListSeal.dtpDateOfSeal", Me.dtpSealDate.Text)
        'objUserSetting.SetCParm("frmListSeal.txtSeal", Me.txtSeal.Text)
        'objUserSetting.SetCParm("frmListSeal.txtSealNo", Me.txtSealNo.Text)

        'objUserSetting.SetCParm("frmListSeal.txtPakages", Me.dtpSealDate.Text)


        'objUserSetting.SetCParm("frmListSeal.mFilter", mFilter)

        'objUserSetting.SetBParm("frmListSeal.smnuDisplayDateOfSeal", Me.smnuDisplaySealDate.Checked)
        'objUserSetting.SetBParm("frmListSeal.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        'objUserSetting.SetBParm("frmListSeal.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListSeal.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryDateOfSeal(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryDateOfSeal = strDateOfSealSelect
        MakeQueryDateOfSeal = MakeQueryDateOfSeal & "From Seal"
        MakeQueryDateOfSeal = MakeQueryDateOfSeal & " WHERE (Seal_Id = '" & DefaultValue & "') "

        MakeQueryDateOfSeal = MakeQueryDateOfSeal & "OR ("
        MakeQueryDateOfSeal = MakeQueryDateOfSeal & "Continued = 1 "
        MakeQueryDateOfSeal = MakeQueryDateOfSeal & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryDateOfSeal = MakeQueryDateOfSeal & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryDateOfSeal = MakeQueryDateOfSeal & strDateOfSealOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryDateOfSeal = MakeQueryDateOfSeal & strDateOfSealOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeDateOfSeal() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(SealNo) as CountNo from Seal", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListSeal", "Add") Then
            Me.txtSeal.Enabled = True
            Me.txtSealNo.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdSeal.Enabled = False
            ReFormat()
            SetMenu((False))
            mSeal_Id = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtSeal.Text = Me.txtSeal.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveDateOfSeal()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdSeal.CurrentRow.Index
        Dim strQueryDateOfSealList As String
        If Not Me.dgdSeal.Item("Editable", index).Value Or Not UserRight("frmListSeal", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryDateOfSeal(, , index)
        Else
            strQueryDateOfSealList = "Select * from Seal where" + " Seal_Id= '" & dgdSeal.Item("Seal_Id", index).Value.ToString & "'"
            rsDateOfSealList.Open(strQueryDateOfSealList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsDateOfSealList.Fields("Approve").Value
            rsDateOfSealList.Update("Approve", Approve)
            rsDateOfSealList.Close()
        End If
        QueryDateOfSeal()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Seal_Id = '" & Me.dgdSeal.Item("Seal_Id", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Seal WHERE Seal_Id = '" & Me.dgdSeal.Item("Seal_Id", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Seal can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The DateOfSeal can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdSeal.Item("Approve", index)) Then
            If Me.dgdSeal.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdSeal.Item("Editable", index)) Then
            If Not Me.dgdSeal.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListSeal", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the SealNo: " & Me.dgdSeal.Item("SealNo", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Seal where" + " Seal_Id= '" & Me.dgdSeal.Item("Seal_Id", index).Value.ToString & "'"
                rsDateOfSealList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsDateOfSealList.Fields("continued").Value = 0
                rsDateOfSealList.Update()
                rsDateOfSealList.Requery()
                Me.dgdSeal.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdSeal.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsDateOfSealList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdSeal.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdSeal.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryDateOfSeal()
    End Sub
#Region "ViewMenuStrip"

    'Private Sub smnuDisplayDateOfSeal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplaySealDate.Checked = Not Me.smnuDisplaySealDate.Checked
    '    UpdateFrame()

    'End Sub

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
        If Me.dgdSeal.Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdSeal.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdSeal.Item("Approve", index).Value
            EditTable = Me.dgdSeal.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListSeal", "Edit") And Not Me.dgdSeal.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdSeal.Height = 306
                ' Me.txtSealNo.Enabled = False
                Me.dgdSeal.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mSeal_Id = Me.dgdSeal.Item("Seal_Id", index).Value.ToString
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
            Me.Text = "List Of Seal"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Seal  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Seal -> Add."
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

    Private Sub QueryDateOfSeal(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryDateOfSeal()
        Else
            strQuery = MakeQueryDateOfSeal(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "DateOfSealList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdSeal.DataSource = ds.Tables("DateOfSealList")
        If Me.dgdSeal.Enabled = False Then
            Me.dgdSeal.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdSeal.Rows.Count And Me.dgdSeal.Rows.Count > 0 Then
            Me.dgdSeal.Rows(location).Selected = True
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdSeal.Columns.Item("SealNo").ToolTipText = "Hiện có:" + CStr(Me.dgdSeal.RowCount()) + " Seals."
        End If
        If Me.dgdSeal.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        InsertAutoNumberToGrid(Me.dgdSeal)
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

        'Me.dgdSeal.Columns.Item("Seal_Id").Visible = False
        'Me.dgdSeal.Columns.Item("DateOfSeal").Visible = Me.smnuDisplaySealDate.Checked
        'Me.dgdSeal.Columns.Item("Editable").Visible = False
        'Me.dgdSeal.Columns.Item("Continued").Visible = False
        'Me.dgdSeal.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdSeal.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdSeal.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdSeal.Width = (Me.Width - 30)
        If Me.Width > 610 Then
            dgdSeal.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdSeal.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdSeal.Height + dgdSeal.Top

        Me.txtSeal.Width = Me.Width - 300

        cmdCancel.Left = Me.fraUpdate.Width / 2 - cmdCancel.Width + 30
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtSeal.Left + Me.txtSeal.Width + 10
        txtSeal.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdSeal_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSeal.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        If Me.dgdSeal.Rows.Count = 0 Then
            Return
        End If
        index = Me.dgdSeal.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdSeal.CurrentCellAddress.X = 3 And Me.dgdSeal.CurrentCellAddress().Y = index Then
            Call ApproveDateOfSeal()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdSeal_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdSeal.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryDateOfSeal("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdSeal)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdSeal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdSeal.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdSeal.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdSeal.SelectedRows(i).Index)
                Next i
            End If

            QueryDateOfSeal()
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
        Me.txtSealNo.Text = Me.dgdSeal.Item("SealNo", index).Value.ToString
        Me.dtpSealDate.Text = Me.dgdSeal.Item("DateOfSeal", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListSeal_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strSeal_Id, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Rows.Count > 0) Then
            index = Me.dgdSeal.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Seal "
            strQuery = strQuery & "WHERE Seal_Id = '" & mSeal_Id & "' AND Seal_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Seal_Id").Value = NewId()
                End If
                strSeal_Id = .Fields("Seal_Id").Value
                .Fields("SealNo").Value = Me.txtSealNo.Text
                .Fields("DateOfSeal").Value = Me.dtpSealDate.Value.Date
                .Fields("Continued").Value = 1
                .Update()

            End With
            rs.Close()
            Me.dgdSeal.Enabled = True
            If mStatus = "Edit" Then
                QueryDateOfSeal(, 1, index)
            Else
                QueryDateOfSeal(, 15, index)
            End If
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
        Me.dgdSeal.Enabled = True
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
                QueryDateOfSeal("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdSeal.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdSeal, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class