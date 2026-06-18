Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListSale


    Inherits System.Windows.Forms.Form
    Dim SaleNameLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsSaleNameList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mSale_Id As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strSaleNameSelect As String = "SELECT " & _
    "Sale_Id, " & _
    "UsrID," & _
    "SaleCode,nhomsale, " & _
    "SaleName , " & _
   "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strSaleNameOrder1 As String = _
           " ORDER BY SaleCode  Desc "
    Const strSaleNameOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strSale_Id As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtSaleCode.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Sale "
                strQuery = strQuery & "WHERE SaleCode = '" & Me.txtSaleCode.Text & "' And Continued=1"
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
        DisplayMessage(True, Err.Description)
    End Function

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtSale.Text)

        If Me.txtSale.Text <> "" Then
            Select Case Me.cboFind.Text
                Case "SaleCode"
                    QuerySaleName("AND ( SaleCode LIKE N'" & strFilter & "') " & mFilter)
                    'Me.dgdSale.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
                Case "SaleName"
                    QuerySaleName("AND (SaleName LIKE N'" & strFilter & "')" & mFilter)
                    UpdateFrame()
            End Select
        Else
            QuerySaleName(mFilter)
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub frmListSale_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mSale_Id = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        SetDefaultGrid(Me.dgdSale, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "SaleCode", "SaleCode")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "SaleName", "SaleName")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListSale.cboFind", "SaleName")
        mFilter = objUserSetting.GetCParm("frmListSale.mFilter")
        Me.txtSaleCode.Text = objUserSetting.GetCParm("frmListSale.txtSaleCode")
        If Me.txtSale.Text <> "" Then
            QuerySaleName("AND SaleCode LIKE '" & MakeFilter(Me.txtSaleName.Text) & "' " & mFilter, , 15)
        Else
            QuerySaleName(mFilter, , 15)
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        QueryUser()

        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListSale.smnuDisplayAPPROVE")
        'Me.smnuDisplaySaleName.Checked = objUserSetting.GetBParm("frmListSale.smnuDisplaySaleName")


        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListSale.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListSale.smnuDisplayUpdateTime")

        UpdateFrame()
        ReFormat()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        '----set mau nen,fra
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
      
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub frmListSale_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmListSale.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListSale.txtSaleName", Me.txtSaleName.Text)

        'objUserSetting.SetCParm("frmListSale.txtSaleCode", Me.txtSaleCode.Text)




        'objUserSetting.SetCParm("frmListSale.mFilter", mFilter)

        'objUserSetting.SetBParm("frmListSale.smnuDisplaySaleName", Me.smnuDisplaySaleName.Checked)
        'objUserSetting.SetBParm("frmListSale.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        'objUserSetting.SetBParm("frmListSale.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListSale.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========MakeQuery==========

    Private Function MakeQuerySaleName(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQuerySaleName = strSaleNameSelect
        MakeQuerySaleName = MakeQuerySaleName & "From Sale"
        MakeQuerySaleName = MakeQuerySaleName & " WHERE (Sale_Id = '" & DefaultValue & "') "

        MakeQuerySaleName = MakeQuerySaleName & "OR ("
        MakeQuerySaleName = MakeQuerySaleName & "Continued = 1 "
        MakeQuerySaleName = MakeQuerySaleName & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQuerySaleName = MakeQuerySaleName & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQuerySaleName = MakeQuerySaleName & strSaleNameOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQuerySaleName = MakeQuerySaleName & strSaleNameOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Function
    '==========Menu==========
    Public Function CodeSaleName() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(SaleCode) as CountNo from Sale", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
       
    End Sub

    Public Sub ApproveSaleName()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdSale.CurrentRow.Index
        Dim strQuerySaleNameList As String
        If Not Me.dgdSale.Item("Editable", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QuerySaleName(, , index)
        Else
            strQuerySaleNameList = "Select * from Sale where" + " Sale_Id= '" & dgdSale.Item("Sale_Id", index).Value.ToString & "'"
            rsSaleNameList.Open(strQuerySaleNameList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsSaleNameList.Fields("Approve").Value
            rsSaleNameList.Update("Approve", Approve)
            rsSaleNameList.Close()
        End If
        QuerySaleName()
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
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Sale_Id = '" & Me.dgdSale.Item("Sale_Id", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Sale WHERE Sale_Id = '" & Me.dgdSale.Item("Sale_Id", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Sale can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The SaleName can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdSale.Item("Approve", index)) Then
            If Me.dgdSale.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdSale.Item("Editable", index)) Then
            If Not Me.dgdSale.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnumarketingsale", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the SaleCode: " & Me.dgdSale.Item("SaleCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Sale where" + " Sale_Id= '" & Me.dgdSale.Item("Sale_Id", index).Value.ToString & "'"
                rsSaleNameList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsSaleNameList.Fields("continued").Value = 0
                rsSaleNameList.Update()
                rsSaleNameList.Requery()
                Me.dgdSale.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdSale.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsSaleNameList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim selectedRowCount As Integer = _
      Me.dgdSale.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdSale.SelectedRows(i).Index)
            Next i
        End If
        Me.QuerySaleName()
    End Sub
#Region "ViewMenuStrip"

    'Private Sub smnuDisplaySaleName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplaySaleName.Checked = Not Me.smnuDisplaySaleName.Checked
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
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        Dim index As Integer = Me.dgdSale.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdSale.Item("Approve", index).Value
            EditTable = Me.dgdSale.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") And Not Me.dgdSale.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdSale.Height = 306
                ' Me.txtSaleCode.Enabled = False
                Me.dgdSale.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mSale_Id = Me.dgdSale.Item("Sale_Id", index).Value.ToString
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
            Me.Text = "List Of Sale"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Sale  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Sale -> Add."
        End If

    End Sub

    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    '==========Query==========

    Private Sub QuerySaleName(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQuerySaleName()
        Else
            strQuery = MakeQuerySaleName(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "SaleNameList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdSale.DataSource = ds.Tables("SaleNameList")
        If Me.dgdSale.Enabled = False Then
            Me.dgdSale.Enabled = True
        End If
        '------------vị trí BM
        'If location > 0 And location <= Me.dgdSale.Rows.Count And Me.dgdSale.Rows.Count > 0 Then
        '    Me.dgdSale.Rows(location).Selected = True
        'End If
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdSale.Columns.Item("SaleCode").ToolTipText = "Hiện có:" + CStr(Me.dgdSale.RowCount()) + " Sales."
        End If
        If Me.dgdSale.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        InsertAutoNumberToGrid(Me.dgdSale)
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

    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        'Me.dgdSale.Columns.Item("Sale_Id").Visible = False
        'Me.dgdSale.Columns.Item("SaleName").Visible = Me.smnuDisplaySaleName.Checked
        'Me.dgdSale.Columns.Item("Editable").Visible = False
        'Me.dgdSale.Columns.Item("Continued").Visible = False
        'Me.dgdSale.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdSale.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdSale.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdSale.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdSale.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdSale.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdSale.Height + dgdSale.Top

        Me.txtSale.Width = Me.Width - 300

        'cmdCancel.Left = Me.fraUpdate.Width / 2 - cmdCancel.Width + 30
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtSale.Left + Me.txtSale.Width + 10
        txtSale.Width = Me.Width - 297

        Exit Sub
Err:
        DisplayMessage(True, Err.Description)

    End Sub

    Private Sub dgdSale_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSale.CellContentClick

        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        index = Me.dgdSale.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdSale.Columns(ColIndex).Name = "Approve" And Me.dgdSale.CurrentCellAddress().Y = index Then
            Call ApproveSaleName()
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdSale_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdSale.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QuerySaleName("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdSale)
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub dgdSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdSale.KeyDown
        ' Dim selectedRowCount As Integer = _
        'Me.dgdSale.Rows.GetRowCount(DataGridViewElementStates.Selected)
        ' If e.KeyCode = Keys.Delete Then
        '     If selectedRowCount > 0 Then
        '         Dim sb As New System.Text.StringBuilder()
        '         Dim i As Integer
        '         For i = 0 To selectedRowCount - 1
        '             DeleteRow(Me.dgdSale.SelectedRows(i).Index)
        '         Next i
        '     End If

        '     QuerySaleName()
        ' End If
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
        Me.txtSaleCode.Text = Me.dgdSale.Item("SaleCode", index).Value.ToString
        Me.txtSaleName.Text = Me.dgdSale.Item("SaleName", index).Value.ToString
        Me.cbonhom.Text = Me.dgdSale.Item("nhom", index).Value.ToString
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub
    Private Sub frmListSale_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
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
            index = Me.dgdSale.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Sale "
            strQuery = strQuery & "WHERE Sale_Id = '" & mSale_Id & "' AND Sale_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Sale_Id").Value = NewId()
                End If
                strSale_Id = .Fields("Sale_Id").Value
                .Fields("UsrID").Value = "{" & FindValueID(Me.cboUser, Me.cboUser.Text.Trim) & "}"
                .Fields("usr").Value = Me.cboUser.Text.Trim
                .Fields("SaleCode").Value = Me.txtSaleCode.Text.Trim
                .Fields("SaleName").Value = Me.txtSaleName.Text.Trim
                .Fields("nhomsale").Value = Me.cbonhom.Text.Trim

                .Update()

            End With
            rs.Close()
            Me.dgdSale.Enabled = True
            If mStatus = "Edit" Then
                QuerySaleName(, 1, index)
            Else
                QuerySaleName(, 15, index)
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
        Me.dgdSale.Enabled = True
        Exit Sub

Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Sub QueryUser()
        Try
            Dim id As String = "usrID"
            Dim value As String = "UsrDP"
            Dim strQuery As String = "select UsrID,Usr as UsrDP from UserList where discontinued=0"
            loadDataToObject(Me.cboUser, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cboUser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboUser.SelectedIndexChanged
        Try
            If FindValueID(Me.cboUser, Me.cboUser.Text.Trim) = "" Then
                Return
            End If
            Dim tbl As DataTable
            tbl = ReadTable("Select Name From UserList Where usr='" & Me.cboUser.Text.Trim & "' and Discontinued=0")
            If tbl.Rows.Count > 0 Then
                Me.txtSaleName.Text = tbl.Rows(0).Item("Name")
            End If

            tbl = ReadTable("Select Department From UserRightDepartment Where usr='" & Me.cboUser.Text.Trim & "' and Discontinued=0")
            If tbl.Rows.Count > 0 Then
                Me.TextBox1.Text = tbl.Rows(0).Item("Department")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub fraUpdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.Enter

    End Sub

    'Private Sub smnuDisplaySaleName_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplaySaleName.Checked = Not Me.smnuDisplaySaleName.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub smnuAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("mnumarketingsale", "Add") Then
            Me.txtSale.Enabled = True
            Me.txtSaleCode.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdSale.Enabled = False
            ReFormat()
            SetMenu((False))
            mSale_Id = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtSale.Text = Me.txtSale.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        DisplayMessage(True, Err.Description)
    End Sub

    Private Sub smnuEdit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        Dim index As Integer = Me.dgdSale.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdSale.Item("Approve", index).Value
            EditTable = Me.dgdSale.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") And Not Me.dgdSale.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdSale.Height = 306
                ' Me.txtSaleCode.Enabled = False
                Me.dgdSale.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mSale_Id = Me.dgdSale.Item("Sale_Id", index).Value.ToString
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

    Private Sub smnuDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        Dim index As Integer = Me.dgdSale.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdSale.Item("Approve", index).Value
            EditTable = Me.dgdSale.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") And Not Me.dgdSale.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdSale.Height = 306
                ' Me.txtSaleCode.Enabled = False
                Me.dgdSale.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mSale_Id = Me.dgdSale.Item("Sale_Id", index).Value.ToString
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

    'Private Sub smnuDisplayApprove_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUserId_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUpdateTime_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub smnuExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
        Me.Close()
    End Sub
End Class

