Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Public Class frmListContainer

    Inherits System.Windows.Forms.Form
    Dim ContainerLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsContainerList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mCTN_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strContainerSelect As String = "SELECT " & _
    "CTN_ID, " & _
    "CTN_SIZE_TYPE,CONTAINER_NO, " & _
      "NETWEIGHT , " & _
     "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strContainerOrder1 As String = _
           " ORDER BY CTN_SIZE_TYPE  Desc "
    Const strContainerOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strCTN_ID As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.cboCTN_Size_type.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, "The code not allow NULL value")
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Container "
                strQuery = strQuery & "WHERE CONTAINER_NO = '" & Me.txtContainerNo.Text & "' And Continued=1"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                If Not rs.EOF Then
                    CheckData = False
                    rs.Close()
                    Me.txtContainerNo.Focus()
                    DisplayMessage(True, "This code had already in database")
                    Exit Function
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
        strFilter = MakeFilter(Me.txtContainer.Text)
        If Me.txtContainer.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtContainer.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdContainer)
            '    Select Case cboFind.Text
            '        Case "CTN_SIZE_TYPE"
            '            QueryContainer("AND ( CTN_SIZE_TYPE LIKE '" & strFilter & "') " & mFilter)
            '            'Me.dgdcontainer.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
            '        Case "CONTAINER_NO"
            '            QueryContainer("AND (CONTAINER_NO LIKE '" & strFilter & "')" & mFilter)
            '            UpdateFrame()
            '    End Select
            'Else
            '    QueryContainer(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListContainer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            bEvent = True
        End If
    End Sub



    Private Sub frmListContainer_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mCTN_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        SetDefaultGrid(Me.dgdContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdContainer)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CTN_SIZE_TYPE", "CTN_SIZE_TYPE")
        'Me.cboFind.Items.Add(oItems)
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CONTAINER_NO", "CONTAINER_NO")
        'Me.cboFind.Items.Add(oItems)
        'Me.cboFind.Text = objUserSetting.GetCParm("frmListContainer.cboFind", "TEMPERATURE_ID")

        mFilter = objUserSetting.GetCParm("frmListContainer.mFilter")
        Me.cboCTN_Size_type.Text = objUserSetting.GetCParm("frmListContainer.txtCTN_SIZE_TYPE")
        'Me.CobTemperatureId.Text = objUserSetting.GetCParm("frmListContainer.cobTemperatureId")
        'Me.txtMinTemperature.Text = objUserSetting.GetCParm("frmListContainer.txtMINTEMPERATURE")
        'Me.txtMaxTemperature.Text = objUserSetting.GetCParm("frmListContainer.txtMAXTEMPERATURE")

        'Me.txtVent.Text = objUserSetting.GetCParm("frmListContainer.txtVENT")


        'If Me.txtContainer.Text <> "" Then
        '    QueryContainer("AND CTN_SIZE_TYPE LIKE '" & MakeFilter(Me.txtContainer.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryContainer(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayMinTemperature.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayMINTEMPERATURE")


        'Me.smnuDisplayContainer_Size_Type.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayContainer_Size_Type")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayAPPROVE")
        'Me.smnuDisplayMaxTemperature.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayMAXTEMPERATURE")
        'Me.smnuDisplayTemperatureId.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayTemperatureId")
        'Me.smnuDisplayMinTemperature.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayMinTemperature")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListContainer.smnuDisplayUpdateTime")

        UpdateFrame()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()

        'SetDefaultGrid(Me.dgdContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListContainer_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmListContainer.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmListContainer.txtContainer", Me.txtContainer.Text)
        objUserSetting.SetCParm("frmListContainer.txtCTN_SIZE_TYPE", Me.cboCTN_Size_type.Text)
        'objUserSetting.SetCParm("frmListContainer.cobTemperatureId", Me.CobTemperatureId.Text)
        'objUserSetting.SetCParm("frmListContainer.txtMIN_TEMPERATURE", Me.txtMinTemperature.Text)
        'objUserSetting.SetCParm("frmListContainer.txtMAX_TEMPERATURE", Me.txtMaxTemperature.Text)

        objUserSetting.SetCParm("frmListContainer.mFilter", mFilter)

        'objUserSetting.SetCParm("frmListContainer.txtVENT", Me.txtVent.Text)

        'objUserSetting.SetBParm("frmListContainer.smnuDisplayMINTEMPERATURE", Me.smnuDisplayMinTemperature.Checked)
        'objUserSetting.SetBParm("frmListContainer.smnuDisplayMaxTEMPERATURE", Me.smnuDisplayMaxTemperature.Checked)


        'objUserSetting.SetBParm("frmListContainer.smnuDisplayContainer_Size_Type", Me.smnuDisplayContainer_Size_Type.Checked)

        'objUserSetting.SetBParm("frmListContainer.smnuDisplayTemperatureId", Me.smnuDisplayTemperatureId.Checked)
        'objUserSetting.SetBParm("frmListContainer.smnuDisplayClosingTime", Me.smnuDisplayMinTemperature.Checked)
        'objUserSetting.SetBParm("frmListContainer.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        'objUserSetting.SetBParm("frmListContainer.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListContainer.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)

        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryContainer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryContainer = strContainerSelect
        MakeQueryContainer = MakeQueryContainer & "From Container"
        MakeQueryContainer = MakeQueryContainer & " WHERE (CTN_ID = '" & DefaultValue & "') "

        MakeQueryContainer = MakeQueryContainer & "OR ("
        MakeQueryContainer = MakeQueryContainer & "Continued = 1 "
        MakeQueryContainer = MakeQueryContainer & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryContainer = MakeQueryContainer & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryContainer = MakeQueryContainer & strContainerOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryContainer = MakeQueryContainer & strContainerOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeContainer() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(CTN_SIZE_TYPE) as CountNo from Container", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListContainer", "Add") Then
            Me.cboCTN_Size_type.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdContainer.Enabled = False
            ReFormat()
            SetMenu((False))
            mCTN_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.cboCTN_Size_type.Text = Me.cboCTN_Size_type.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveContainer()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdContainer.CurrentRow.Index
        Dim strQueryContainerList As String
        If Not Me.dgdContainer.Item("Editable", index).Value Or Not UserRight("frmListContainer", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryContainer(mFilter, , index)
        Else
            strQueryContainerList = "Select * from Container where" + " CTN_ID= '" & dgdContainer.Item("ContainerID", index).Value.ToString & "'"
            rsContainerList.Open(strQueryContainerList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsContainerList.Fields("Approve").Value
            rsContainerList.Update("Approve", Approve)
            rsContainerList.Close()
        End If
        QueryContainer(mFilter)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE CTN_ID = '" & Me.dgdcontainer.Item("CTN_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Container WHERE CTN_ID = '" & Me.dgdContainer.Item("ContainerID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Container can not be removed.", "Không Thể Xoá Container Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Container can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdContainer.Item("Approve", index)) Then
            If Me.dgdContainer.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdContainer.Item("Editable", index)) Then
            If Not Me.dgdContainer.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListContainer", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Container: " & Me.dgdContainer.Item("CTN_SIZE_TYPE", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Container where" + " CTN_ID= '" & Me.dgdContainer.Item("ContainerID", index).Value.ToString & "'"
                rsContainerList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsContainerList.Fields("continued").Value = 0
                rsContainerList.Update()

                rsContainerList.Requery()
                Me.dgdContainer.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdContainer.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsContainerList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdContainer.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdContainer.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryContainer(mFilter)
    End Sub
#Region "ViewMenuStrip"

    'Private Sub smnuDisplayContainer_Size_Type_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayContainer_Size_Type.Checked = Not Me.smnuDisplayContainer_Size_Type.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayTemperatureId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayTemperatureId.Checked = Not Me.smnuDisplayTemperatureId.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayMaxTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayMaxTemperature.Checked = Not Me.smnuDisplayMaxTemperature.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayMinTemperature_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayMinTemperature.Checked = Not Me.smnuDisplayMinTemperature.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayVent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayVent.Checked = Not Me.smnuDisplayVent.Checked
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
        If Me.dgdContainer.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdContainer.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdContainer.Item("Approve", index).Value
            EditTable = Me.dgdContainer.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmListContainer", "Edit") And Not Me.dgdContainer.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdContainer.Height = 306
                Me.dgdContainer.Enabled = False
                Me.cboCTN_Size_type.Enabled = True
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mCTN_ID = Me.dgdContainer.Item("ContainerID", index).Value.ToString
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
            Me.Text = "List Container"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Container  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Container -> Add."
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

    Private Sub QueryContainer(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryContainer()
        Else
            strQuery = MakeQueryContainer(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "ContainerList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdContainer.DataSource = ds.Tables("ContainerList")
        If Me.dgdContainer.Enabled = False Then
            Me.dgdContainer.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdContainer.Columns.Item("CTN_SIZE_TYPE").ToolTipText = "Hiện có:" + CStr(Me.dgdContainer.RowCount()) + " Containers."
        End If
        If Me.dgdContainer.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdContainer.Rows.Count And Me.dgdContainer.Rows.Count > 0 Then
            Me.dgdContainer.Rows(location).Selected = True
            Me.dgdContainer.CurrentCell = Me.dgdContainer.Rows(location).Cells(3)
        End If
        InsertAutoNumberToGrid(Me.dgdContainer)
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

        'Me.dgdContainer.Columns.Item("ContainerID").Visible = False
        ''Me.dgdContainer.Columns.Item("MIN_TEMPERATURE").Visible = Me.smnuDisplayMinTemperature.Checked
        'Me.dgdContainer.Columns.Item("Editable").Visible = False
        'Me.dgdContainer.Columns.Item("Continued").Visible = False
        'Me.dgdContainer.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdContainer.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdContainer.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        'Me.dgdContainer.Columns.Item("CTN_SIZE_TYPE").Visible = Me.smnuDisplayContainer_Size_Type.Checked
        ''Me.dgdContainer.Columns.Item("TEMPERATUREID").Visible = Me.smnuDisplayTemperatureId.Checked
        ''Me.dgdContainer.Columns.Item("MAX_TEMPERATURE").Visible = Me.smnuDisplayMaxTemperature.Checked
        ''Me.dgdContainer.Columns.Item("VENT").Visible = Me.smnuDisplayVent.Checked



        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

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
        dgdContainer.Width = (Me.Width - 30)
        If Me.Width > 610 Then
            dgdContainer.Height = Me.Height - 100 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdContainer.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdContainer.Height + dgdContainer.Top

        Me.txtContainer.Width = Me.Width - 300

        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdOK.Top = fraUpdate.Bottom - cmdOK.Height - 5
        'cmdCancel.Top = fraUpdate.Bottom - cmdOK.Height - 5


        txtContainer.Width = Me.Width - 500
        cmdFind.Left = Me.txtContainer.Left + Me.txtContainer.Width + 10
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdcontainer_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainer.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdContainer.RowCount = 0 Then
            Return
        End If
        index = Me.dgdContainer.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdContainer.Columns(ColIndex).Name = "Approve" And Me.dgdContainer.CurrentCellAddress().Y = index Then
            Call ApproveContainer()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub dgdcontainer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContainer.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryContainer("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdcontainer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdContainer.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdContainer.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdContainer.SelectedRows(i).Index)
                Next i
            End If

            QueryContainer(mFilter, 1, 0)
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
        Me.cboCTN_Size_type.Text = Me.dgdContainer.Item("CTN_SIZE_TYPE", index).Value.ToString
        Me.txtContainerNo.Text = Me.dgdContainer.Item("Container_no", index).Value.ToString
        'Me.CobTemperatureId.Text = Me.dgdContainer.Item("TEMPERATUREID", index).Value.ToString
        'Me.txtMinTemperature.Text = Me.dgdContainer.Item("MIN_TEMPERATURE", index).Value.ToString
        'Me.txtMaxTemperature.Text = Me.dgdContainer.Item("MAX_TEMPERATURE", index).Value.ToString
        Me.txtNetWeight.Text = Me.dgdContainer.Item("NETWEIGHT", index).Value.ToString
        'Me.txtVent.Text = Me.dgdContainer.Item("VENT", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub frmContainer_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strCTN_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.dgdContainer.Rows.Count > 0) Then
            index = Me.dgdContainer.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Container "
            strQuery = strQuery & "WHERE CTN_Id = '" & mCTN_ID & "' AND CTN_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("CTN_Id").Value = NewId()
                End If
                strCTN_ID = .Fields("CTN_ID").Value
                'If mStatus = "Edit" Then
                '.Fields("Code").Value = Trim(me.txtCTN_SIZE_TYPE.Text)
                'Else
                .Fields("CTN_SIZE_TYPE").Value = Me.cboCTN_Size_type.Text
                'End If
                .Fields("NETWEIGHT").Value = Me.txtNetWeight.Text
                .Fields("CONTAINER_NO").Value = UCase(Trim(Me.txtContainerNo.Text))
                '.Fields("TEMPERATURE_ID").Value = UCase(Trim(Me.CobTemperatureId.Text))
                '.Fields("MIN_TEMPERATURE").Value = UCase(Trim(Me.txtMinTemperature.Text))
                '.Fields("MAX_TEMPERATURE").Value = UCase(Trim(Me.txtMaxTemperature.Text))
                '.Fields("VENT").Value = UCase(Trim(Me.txtVent.Text))
                .Fields("Continued").Value = 1
                .Update()

            End With
            rs.Close()
            Me.dgdContainer.Enabled = True
            If mStatus = "Edit" Then
                QueryContainer(mFilter, 1, index)
            Else
                If mStatus = "Add" Then
                    mFilter = " AND CONTAINER_NO= '" & UCase(Trim(Me.txtContainerNo.Text)) & "'"
                End If
                QueryContainer(mFilter, 15, index)
            End If
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            mStatus = "Normal"
            reText(mStatus)
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
        Me.dgdContainer.Enabled = True
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
                QueryContainer("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdContainer.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdContainer, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cboCTN_Size_type_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCTN_Size_type.SelectedIndexChanged
        Try
            If Me.cboCTN_Size_type.Text.Trim = "20GP" Then
                Me.txtNetWeight.Text = 2250
            ElseIf Me.cboCTN_Size_type.Text.Trim = "40GP" Then
                Me.txtNetWeight.Text = 6650
            ElseIf Me.cboCTN_Size_type.Text.Trim = "40HC" Then
                Me.txtNetWeight.Text = 3890
            ElseIf Me.cboCTN_Size_type.Text.Trim = "40RH" Then
                Me.txtNetWeight.Text = 5100
            ElseIf Me.cboCTN_Size_type.Text.Trim = "20RF" Then
                Me.txtNetWeight.Text = 3030
            Else
                Me.txtNetWeight.Text = ""
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub txtContainer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContainer.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class