Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListPayAbleAt



    Inherits System.Windows.Forms.Form
    Dim PAYABLE_ATLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsPAYABLE_ATList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mPAYABLE_AT_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strPAYABLE_ATSelect As String = "SELECT " & _
    "PAYABLE_AT_ID, " & _
    "PAYABLE_AT_CODE, " & _
    "PAYABLE_AT , " & _
   "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strPAYABLE_ATOrder1 As String = _
           " ORDER BY PAYABLE_AT_CODE  Desc "
    Const strPAYABLE_ATOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strPAYABLE_AT_ID As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtPAYABLE_ATCode.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM PAYABLE_AT "
                strQuery = strQuery & "WHERE PAYABLE_AT_CODE = '" & Me.txtPAYABLE_ATCode.Text & "' And Continued=1"
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
        strFilter = MakeFilter(Me.txtPayableAt.Text)
        If Me.txtPayableAt.Text <> "" Then
            Select Case Me.cboFind.Text
                Case "Place Code"
                    QueryPAYABLE_AT("AND ( PAYABLE_AT_CODE LIKE '" & strFilter & "') " & mFilter)
                    'Me.dgdPayableAt.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
                Case "Name"
                    QueryPAYABLE_AT("AND (PAYABLE_AT LIKE '" & strFilter & "')" & mFilter)
                    UpdateFrame()
            End Select
        Else
            QueryPAYABLE_AT(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListPayAbleAt_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mPAYABLE_AT_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Place Code", "Place Code")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Name", "Name")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListPayAbleAt.cboFind", "PAYABLE_AT")
        mFilter = objUserSetting.GetCParm("frmListPayAbleAt.mFilter")
        Me.txtPAYABLE_ATCode.Text = objUserSetting.GetCParm("frmListPayAbleAt.txtPAYABLE_AT_CODE")
        If Me.txtPAYABLE_AT.Text <> "" Then
            QueryPAYABLE_AT("AND PAYABLE_AT_CODE LIKE '" & MakeFilter(Me.txtPAYABLE_AT.Text) & "' " & mFilter, , 15)
        Else
            QueryPAYABLE_AT(mFilter, , 15)
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If





        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListPayAbleAt.smnuDisplayAPPROVE")
        Me.smnuDisplayPayableAt.Checked = objUserSetting.GetBParm("frmListPayAbleAt.smnuDisplayPAYABLEAT")


        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListPayAbleAt.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListPayAbleAt.smnuDisplayUpdateTime")

        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListPayAbleAt_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmListPayAbleAt.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmListPayAbleAt.txtPAYABLE_AT", Me.txtPAYABLE_AT.Text)
        objUserSetting.SetCParm("frmListPayAbleAt.txtPAYABLE_ATCODE", Me.txtPAYABLE_ATCode.Text)

        objUserSetting.SetCParm("frmListPayAbleAt.txtPakages", Me.txtPAYABLE_AT.Text)


        objUserSetting.SetCParm("frmListPayAbleAt.mFilter", mFilter)

        objUserSetting.SetBParm("frmListPayAbleAt.smnuDisplayPAYABLE_AT", Me.smnuDisplayPayableAt.Checked)
        objUserSetting.SetBParm("frmListPayAbleAt.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        objUserSetting.SetBParm("frmListPayAbleAt.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListPayAbleAt.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryPAYABLE_AT(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryPAYABLE_AT = strPAYABLE_ATSelect
        MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & "From PAYABLE_AT"
        MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & " WHERE (PAYABLE_AT_ID = '" & DefaultValue & "') "

        MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & "OR ("
        MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & "Continued = 1 "
        MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & strPAYABLE_ATOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryPAYABLE_AT = MakeQueryPAYABLE_AT & strPAYABLE_ATOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodePAYABLE_AT() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(PAYABLE_AT_CODE) as CountNo from PAYABLE_AT", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListPayAbleAt", "Add") Then
            Me.txtPAYABLE_ATCode.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdPayableAt.Enabled = False
            ReFormat()
            SetMenu((False))
            mPAYABLE_AT_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtPAYABLE_ATCode.Text = Me.txtPAYABLE_ATCode.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApprovePAYABLE_AT()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdPayableAt.CurrentRow.Index
        Dim strQueryPAYABLE_ATList As String
        If Not Me.dgdPayableAt.Item("Editable", index).Value Or Not UserRight("frmListPayAbleAt", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPAYABLE_AT(, , index)
        Else
            strQueryPAYABLE_ATList = "Select * from PAYABLE_AT where" + " PAYABLE_AT_ID= '" & dgdPayableAt.Item("PAYABLE_AT_ID", index).Value.ToString & "'"
            rsPAYABLE_ATList.Open(strQueryPAYABLE_ATList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsPAYABLE_ATList.Fields("Approve").Value
            rsPAYABLE_ATList.Update("Approve", Approve)
            rsPAYABLE_ATList.Close()
        End If
        QueryPAYABLE_AT()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE PAYABLE_AT_ID = '" & Me.dgdPayableAt.Item("PAYABLE_AT_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from PAYABLE_AT WHERE PAYABLE_AT_ID = '" & Me.dgdPayableAt.Item("PAYABLE_AT_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The PAYABLE_AT can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The PAYABLE_AT can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdPayableAt.Item("Approve", index)) Then
            If Me.dgdPayableAt.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPayableAt.Item("Editable", index)) Then
            If Not Me.dgdPayableAt.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListPayAbleAt", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the PAYABLE_AT: " & Me.dgdPayableAt.Item("PAYABLE_AT", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from PAYABLE_AT where" + " PAYABLE_AT_ID= '" & Me.dgdPayableAt.Item("PAYABLE_AT_ID", index).Value.ToString & "'"
                rsPAYABLE_ATList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsPAYABLE_ATList.Fields("continued").Value = 0
                rsPAYABLE_ATList.Update()
                rsPAYABLE_ATList.Requery()
                Me.dgdPayableAt.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdPayableAt.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsPAYABLE_ATList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdPayableAt.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdPayableAt.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryPAYABLE_AT()
    End Sub
#Region "ViewMenuStrip"

    Private Sub smnuDisplayPAYABLE_AT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPayableAt.Click
        Me.smnuDisplayPayableAt.Checked = Not Me.smnuDisplayPayableAt.Checked
        UpdateFrame()

    End Sub

    Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub



    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub


#End Region

#Region "Xuly"
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        Dim index As Integer = Me.dgdPayableAt.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdPayableAt.Item("Approve", index).Value
            EditTable = Me.dgdPayableAt.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListPayAbleAt", "Edit") And Not Me.dgdPayableAt.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdPayableAt.Height = 306
                Me.dgdPayableAt.Enabled = False
                Me.txtPAYABLE_ATCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mPAYABLE_AT_ID = Me.dgdPayableAt.Item("PAYABLE_AT_ID", index).Value.ToString
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
            Me.Text = "List PAYABLE_AT"
        ElseIf mStatus = "Edit" Then
            Me.Text = "PAYABLE_AT  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "PAYABLE_AT -> Add."
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

    Private Sub QueryPAYABLE_AT(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPAYABLE_AT()
        Else
            strQuery = MakeQueryPAYABLE_AT(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "PAYABLE_ATList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPayableAt.DataSource = ds.Tables("PAYABLE_ATList")
        If Me.dgdPayableAt.Enabled = False Then
            Me.dgdPayableAt.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdPayableAt.Rows.Count And Me.dgdPayableAt.Rows.Count > 0 Then
            Me.dgdPayableAt.Rows(location).Selected = True
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdPayableAt.Columns.Item("PAYABLE_AT_CODE").ToolTipText = "Hiện có:" + CStr(Me.dgdPayableAt.RowCount()) + " PAYABLE_AT."
        End If
        If Me.dgdPayableAt.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
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

        Me.dgdPayableAt.Columns.Item("PAYABLE_AT_ID").Visible = False
        Me.dgdPayableAt.Columns.Item("PAYABLE_AT").Visible = Me.smnuDisplayPayableAt.Checked
        Me.dgdPayableAt.Columns.Item("Editable").Visible = False
        Me.dgdPayableAt.Columns.Item("Continued").Visible = False
        Me.dgdPayableAt.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        Me.dgdPayableAt.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdPayableAt.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdPayableAt.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdPayableAt.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdPayableAt.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdPayableAt.Height + dgdPayableAt.Top

        Me.txtPayableAt.Width = Me.Width - 300

        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtPayableAt.Left + Me.txtPayableAt.Width + 10
        txtPayableAt.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdPayableAt_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPayableAt.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        index = Me.dgdPayableAt.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPayableAt.CurrentCellAddress.X = 3 And Me.dgdPayableAt.CurrentCellAddress().Y = index Then
            Call ApprovePAYABLE_AT()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPayableAt_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPayableAt.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryPAYABLE_AT("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPayableAt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdPayableAt.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdPayableAt.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdPayableAt.SelectedRows(i).Index)
                Next i
            End If

            QueryPAYABLE_AT()
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
        Me.txtPAYABLE_ATCode.Text = Me.dgdPayableAt.Item("PAYABLE_AT_CODE", index).Value.ToString
        Me.txtPAYABLE_AT.Text = Me.dgdPayableAt.Item("PAYABLE_AT", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmListPayAbleAt_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strPAYABLE_AT_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Rows.Count > 0) Then
            index = Me.dgdPayableAt.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM PAYABLE_AT "
            strQuery = strQuery & "WHERE PAYABLE_AT_ID = '" & mPAYABLE_AT_ID & "' AND PAYABLE_AT_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("PAYABLE_AT_ID").Value = NewId()
                End If
                strPAYABLE_AT_ID = .Fields("PAYABLE_AT_ID").Value
                If mStatus = "Edit" Then
                    '.Fields("Code").Value = Trim(me.txtPAYABLE_AT_CODE.Text)
                Else
                    .Fields("PAYABLE_AT_CODE").Value = Me.txtPAYABLE_ATCode.Text
                End If
                .Fields("PAYABLE_AT").Value = UCase(Trim(Me.txtPAYABLE_AT.Text))
                .Fields("Continued").Value = 1
                .Update()

            End With
            rs.Close()
            Me.dgdPayableAt.Enabled = True
            If mStatus = "Edit" Then
                QueryPAYABLE_AT(, 1, index)
            Else
                QueryPAYABLE_AT(, 15, index)
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
        Me.dgdPayableAt.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

End Class