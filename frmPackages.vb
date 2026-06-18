Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListPackages

    Inherits System.Windows.Forms.Form
    Dim PACKAGESLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsPACKAGESList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mPACKAGES_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strPACKAGESSelect As String = "SELECT " & _
    "PACKAGES_ID, " & _
    "PACKAGES_CODE, " & _
    "PACKAGES_DESCRIPTION , " & _
   "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strPACKAGESOrder1 As String = _
           " ORDER BY PACKAGES_CODE  Desc "
    Const strPACKAGESOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strPACKAGES_ID As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtPackagesCode.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, "The code not allow NULL value")
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM PACKAGES "
                strQuery = strQuery & "WHERE PACKAGES_CODE = '" & Me.txtPackagesCode.Text & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    CheckData = False
                    rs.Close()
                    DisplayMessage(True, "This code had already in database")
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
        strFilter = MakeFilter(Me.txtPACKAGES.Text)
        If Me.txtPACKAGES.Text <> "" Then
            Select Case cboFind.Text
                Case "PACKAGES_CODE"
                    QueryPACKAGES("AND ( PACKAGES_CODE LIKE '" & strFilter & "') " & mFilter)
                    'Me.dgdPACKAGES.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
                Case "PACKAGES_DESCRIPTION"
                    QueryPACKAGES("AND (PACKAGES_DESCRIPTION LIKE '" & strFilter & "')" & mFilter)
                    UpdateFrame()
            End Select
        Else
            QueryPACKAGES(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmListPACKAGES_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mPACKAGES_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "PACKAGES_CODE", "PACKAGES_CODE")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "PACKAGES_DESCRIPTION", "PACKAGES_DESCRIPTION")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListPACKAGES.cboFind", "PACKAGES_DESCRIPTION")
        mFilter = objUserSetting.GetCParm("frmListPACKAGES.mFilter")
        Me.txtPackagesCode.Text = objUserSetting.GetCParm("frmListPACKAGES.txtPACKAGES_CODE")
        If Me.txtPACKAGES.Text <> "" Then
            QueryPACKAGES("AND PACKAGES_CODE LIKE '" & MakeFilter(Me.txtPACKAGES.Text) & "' " & mFilter, , 15)
        Else
            QueryPACKAGES(mFilter, , 15)
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If





        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListPACKAGES.smnuDisplayAPPROVE")
        Me.smnuDisplayPackagesDescription.Checked = objUserSetting.GetBParm("frmListPACKAGES.smnuDisplayPackagesDescription")


        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListPACKAGES.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListPACKAGES.smnuDisplayUpdateTime")

        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListPACKAGES_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmListPACKAGES.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmListPACKAGES.txtPACKAGES", Me.txtPACKAGES.Text)
        objUserSetting.SetCParm("frmListPACKAGES.txtPACKAGESCODE", Me.txtPackagesCode.Text)

        objUserSetting.SetCParm("frmListPACKAGES.txtPakagesDescription", Me.txtPackagesDescription.Text)


        objUserSetting.SetCParm("frmListPACKAGES.mFilter", mFilter)

        objUserSetting.SetBParm("frmListPACKAGES.smnuDisplayPackagesDescription", Me.smnuDisplayPackagesDescription.Checked)
        objUserSetting.SetBParm("frmListPACKAGES.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        objUserSetting.SetBParm("frmListPACKAGES.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListPACKAGES.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryPACKAGES(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryPACKAGES = strPACKAGESSelect
        MakeQueryPACKAGES = MakeQueryPACKAGES & "From Packages"
        MakeQueryPACKAGES = MakeQueryPACKAGES & " WHERE (PACKAGES_ID = '" & DefaultValue & "') "

        MakeQueryPACKAGES = MakeQueryPACKAGES & "OR ("
        MakeQueryPACKAGES = MakeQueryPACKAGES & "Continued = 1 "
        MakeQueryPACKAGES = MakeQueryPACKAGES & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryPACKAGES = MakeQueryPACKAGES & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryPACKAGES = MakeQueryPACKAGES & strPACKAGESOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryPACKAGES = MakeQueryPACKAGES & strPACKAGESOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodePACKAGES() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(PACKAGES_CODE) as CountNo from Packages", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListPackages", "Add") Then
            Me.txtPackagesCode.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdPackages.Enabled = False
            ReFormat()
            SetMenu((False))
            mPACKAGES_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtPackagesCode.Text = Me.txtPackagesCode.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApprovePACKAGES()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdPackages.CurrentRow.Index
        Dim strQueryPACKAGESList As String
        If Not Me.dgdPackages.Item("Editable", index).Value Or Not UserRight("frmListPackages", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPACKAGES(, , index)
        Else
            strQueryPACKAGESList = "Select * from Packages where" + " PACKAGES_ID= '" & dgdPackages.Item("Packages_ID", index).Value.ToString & "'"
            rsPACKAGESList.Open(strQueryPACKAGESList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsPACKAGESList.Fields("Approve").Value
            rsPACKAGESList.Update("Approve", Approve)
            rsPACKAGESList.Close()
        End If
        QueryPACKAGES()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE PACKAGES_ID = '" & Me.dgdPACKAGES.Item("PACKAGES_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from PACKAGES WHERE PACKAGES_ID = '" & Me.dgdPackages.Item("PACKAGES_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The PACKAGES can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The PACKAGES can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdPackages.Item("Approve", index)) Then
            If Me.dgdPackages.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPackages.Item("Editable", index)) Then
            If Not Me.dgdPackages.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListPackages", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the PACKAGES: " & Me.dgdPackages.Item("PACKAGES_CODE", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from PACKAGES where" + " PACKAGES_ID= '" & Me.dgdPackages.Item("PACKAGES_ID", index).Value.ToString & "'"
                rsPACKAGESList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsPACKAGESList.Fields("continued").Value = 0
                rsPACKAGESList.Update()

                rsPACKAGESList.Requery()
                Me.dgdPackages.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdPackages.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsPACKAGESList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdPackages.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdPackages.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryPACKAGES()
    End Sub
#Region "ViewMenuStrip"

    Private Sub smnuDisplayPackagesDescription_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayPackagesDescription.Click
        Me.smnuDisplayPackagesDescription.Checked = Not Me.smnuDisplayPackagesDescription.Checked
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

        Dim index As Integer = Me.dgdPackages.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdPackages.Item("Approve", index).Value
            EditTable = Me.dgdPackages.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListPackages", "Edit") And Not Me.dgdPackages.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdPackages.Height = 306
                Me.dgdPackages.Enabled = False
                Me.txtPackagesCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mPACKAGES_ID = Me.dgdPackages.Item("PACKAGES_ID", index).Value.ToString
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
            Me.Text = "List PACKAGES"
        ElseIf mStatus = "Edit" Then
            Me.Text = "PACKAGES  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "PACKAGES -> Add."
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

    Private Sub QueryPACKAGES(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPACKAGES()
        Else
            strQuery = MakeQueryPACKAGES(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "PACKAGESList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPackages.DataSource = ds.Tables("PACKAGESList")
        If Me.dgdPackages.Enabled = False Then
            Me.dgdPackages.Enabled = True
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdPackages.Rows.Count And Me.dgdPackages.Rows.Count > 0 Then
            Me.dgdPackages.Rows(location).Selected = True
        End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdPackages.Columns.Item("PACKAGES_CODE").ToolTipText = "Hiện có:" + CStr(Me.dgdPackages.RowCount()) + " PACKAGES."
        End If
        If Me.dgdPackages.RowCount() = 0 Then
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

        Me.dgdPackages.Columns.Item("PACKAGES_ID").Visible = False
        Me.dgdPackages.Columns.Item("PACKAGES_Description").Visible = Me.smnuDisplayPackagesDescription.Checked
        Me.dgdPackages.Columns.Item("Editable").Visible = False
        Me.dgdPackages.Columns.Item("Continued").Visible = False
        Me.dgdPackages.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        Me.dgdPackages.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdPackages.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdPackages.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdPackages.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdPackages.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdPackages.Height + dgdPackages.Top

        Me.txtPackages.Width = Me.Width - 300

        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtPackages.Left + Me.txtPackages.Width + 10
        txtPackages.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdPACKAGES_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPackages.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        index = Me.dgdPackages.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPackages.CurrentCellAddress.X = 3 And Me.dgdPackages.CurrentCellAddress().Y = index Then
            Call ApprovePACKAGES()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPACKAGES_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPackages.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryPACKAGES("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPACKAGES_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdPackages.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdPackages.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdPackages.SelectedRows(i).Index)
                Next i
            End If

            QueryPACKAGES()
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
        Me.txtPackagesCode.Text = Me.dgdPackages.Item("PACKAGES_CODE", index).Value.ToString
        Me.txtPackagesDescription.Text = Me.dgdPackages.Item("PACKAGES_Description", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmListPackages_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strPACKAGES_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Rows.Count > 0) Then
            index = Me.dgdPackages.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM PACKAGES "
            strQuery = strQuery & "WHERE PACKAGES_ID = '" & mPACKAGES_ID & "' AND PACKAGES_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("PACKAGES_ID").Value = NewId()
                End If
                strPACKAGES_ID = .Fields("PACKAGES_ID").Value
                If mStatus = "Edit" Then
                    '.Fields("Code").Value = Trim(me.txtPACKAGES_CODE.Text)
                Else
                    .Fields("PACKAGES_CODE").Value = Me.txtPackagesCode.Text
                End If
                .Fields("PACKAGES_DESCRIPTION").Value = UCase(Trim(Me.txtPackagesDescription.Text))
                .Fields("Continued").Value = 1
                .Update()

            End With
            rs.Close()
            Me.dgdPackages.Enabled = True
            If mStatus = "Edit" Then
                QueryPACKAGES(, 1, index)
            Else
                QueryPACKAGES(, 15, index)
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
        Me.dgdPackages.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class