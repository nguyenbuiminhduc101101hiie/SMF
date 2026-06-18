Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListMarket

    Inherits System.Windows.Forms.Form
    Dim MarketLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsMarketList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mMarket_ID As String
    Dim mStatusDest As String
    Dim mDestinationID As String

    '------------------
    Public oTable As DataTable
    Public oTableDest As DataTable
    Public ds As New DataSet

    Const strMarketSelect As String = "SELECT " & _
    "Market_ID, " & _
    "MarketCode, " & _
    "Market ,RemarksBooking, " & _
   "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strMarketOrder1 As String = _
           " ORDER BY MarketCode  Desc "
    Const strMarketOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strMarket_ID As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtMarketCode.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Market "
                strQuery = strQuery & "WHERE MarketCode = '" & Me.txtMarketCode.Text & "' And Continued=1"
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

    Private Function CheckDataDest() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckDataDest = True
        strMsg = ""
        If FindValueID(Me.cboPort, Me.cboPort.Text.Trim) = "" Then
            strMsg = "The Dest Code is invalid"
        End If
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
        strFilter = MakeFilter(Me.txtMarket.Text)
        If Me.txtMarket.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtMarket.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdMarket)
        End If
        '    Select Case Me.cboFind.Text
        '        Case "Market Code"
        '            QueryMarket("AND ( MarketCode LIKE '" & strFilter & "') " & mFilter)
        '            'Me.dgdMarket.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
        '        Case "Market"
        '            QueryMarket("AND (Market LIKE '" & strFilter & "')" & mFilter)
        '            UpdateFrame()
        '    End Select
        'Else
        '    QueryMarket(mFilter)
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListMarket_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mStatusDest = "Normal"
        blnUpdated = False
        mMarket_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        SetDefaultGrid(Me.dgdDestination, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdMarket, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdMarket)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Market Code", "Market Code")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Market", "Market")
        'Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListMarket.cboFind", "Market")
        mFilter = objUserSetting.GetCParm("frmListMarket.mFilter")
        Me.txtMarketCode.Text = objUserSetting.GetCParm("frmListMarket.txtMarketCode")
        'If Me.txtMarket.Text <> "" Then
        '    QueryMarket("AND MarketCode LIKE '" & MakeFilter(Me.txtMarket.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryMarket(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListMarket.smnuDisplayAPPROVE")
        Me.smnuDisplayMarket.Checked = objUserSetting.GetBParm("frmListMarket.smnuDisplayMarket")


        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListMarket.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListMarket.smnuDisplayUpdateTime")

        UpdateFrame()
        QueryCombo()
        SetItemsDest(False)
        ReFormat()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        '----set mau nen,fra
        Me.BackColor = gMaunen
        Me.TabPage1.BackColor = gMauFra
        Me.TabPage2.BackColor = gMauFra
      
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListMarket_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmListMarket.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmListMarket.dtpMarket", Me.txtMarket.Text)
        objUserSetting.SetCParm("frmListMarket.txtMarket", Me.txtMarket.Text)
        objUserSetting.SetCParm("frmListMarket.txtMarketCode", Me.txtMarketCode.Text)

        objUserSetting.SetCParm("frmListMarket.txtPakages", Me.txtMarket.Text)


        objUserSetting.SetCParm("frmListMarket.mFilter", mFilter)

        objUserSetting.SetBParm("frmListMarket.smnuDisplayMarket", Me.smnuDisplayMarket.Checked)
        objUserSetting.SetBParm("frmListMarket.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        objUserSetting.SetBParm("frmListMarket.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListMarket.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        ReFormat()

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryMarket(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryMarket = strMarketSelect
        MakeQueryMarket = MakeQueryMarket & "From Market"
        MakeQueryMarket = MakeQueryMarket & " WHERE (Market_ID = '" & DefaultValue & "') "

        MakeQueryMarket = MakeQueryMarket & "OR ("
        MakeQueryMarket = MakeQueryMarket & "Continued = 1 "
        MakeQueryMarket = MakeQueryMarket & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryMarket = MakeQueryMarket & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryMarket = MakeQueryMarket & strMarketOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryMarket = MakeQueryMarket & strMarketOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeMarket() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(MarketCode) as CountNo from Market", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("mnumarketingsale", "Add") Then
            Me.txtMarket.Enabled = True
            Me.txtMarketCode.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdMarket.Enabled = False
            ReFormat()
            SetMenu((False))
            mMarket_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtMarket.Text = Me.txtMarket.Text
            QueryGrid()
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveMarket()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdMarket.CurrentRow.Index
        Dim strQueryMarketList As String
        If Not Me.dgdMarket.Item("Editable", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryMarket(, , index)
        Else
            strQueryMarketList = "Select * from Market where" + " Market_ID= '" & dgdMarket.Item("Market_ID", index).Value.ToString & "'"
            rsMarketList.Open(strQueryMarketList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsMarketList.Fields("Approve").Value
            rsMarketList.Update("Approve", Approve)
            rsMarketList.Close()
        End If
        QueryMarket()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveDest()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdDestination.CurrentRow.Index
        Dim strQueryMarketList As String
        If Not Me.dgdDestination.Item("EditableD", index).Value Or Not UserRight("mnumarketingsale", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strQueryMarketList = "Select * from Destination where" + " Destination_ID= '" & dgdDestination.Item("Destination_ID", index).Value.ToString & "'"
            rsMarketList.Open(strQueryMarketList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsMarketList.Fields("Approve").Value
            rsMarketList.Update("Approve", Approve)
            rsMarketList.Close()
        End If
        QueryGrid()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Market_ID = '" & Me.dgdMarket.Item("Market_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Market WHERE Market_ID = '" & Me.dgdMarket.Item("Market_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Market can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Market can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdMarket.Item("Approve", index)) Then
            If Me.dgdMarket.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdMarket.Item("Editable", index)) Then
            If Not Me.dgdMarket.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnumarketingsale", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the MarketCode: " & Me.dgdMarket.Item("MarketCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Market where" + " Market_ID= '" & Me.dgdMarket.Item("Market_ID", index).Value.ToString & "'"
                rsMarketList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsMarketList.Fields("continued").Value = 0
                rsMarketList.Update()
                rsMarketList.Requery()
                Me.dgdMarket.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdMarket.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsMarketList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowDest(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Market_ID = '" & Me.dgdMarket.Item("Market_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Destination WHERE Destination_ID = '" & Me.dgdDestination.Item("Destination_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Market can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Market can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdDestination.Item("ApproveD", index)) Then
            If Me.dgdDestination.Item("ApproveD", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdDestination.Item("EditableD", index)) Then
            If Not Me.dgdDestination.Item("EditableD", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("mnumarketingsale", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Destination : " & Me.dgdDestination.Item("DestCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Destination where" + " Destination_ID= '" & Me.dgdDestination.Item("Destination_ID", index).Value.ToString & "'"
                rsMarketList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsMarketList.Fields("continued").Value = 0
                rsMarketList.Update()
                rsMarketList.Requery()
                rsMarketList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdMarket.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdMarket.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryMarket()
    End Sub
#Region "ViewMenuStrip"

    Private Sub smnuDisplayMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayMarket.Click
        Me.smnuDisplayMarket.Checked = Not Me.smnuDisplayMarket.Checked
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
        Dim index As Integer
        If Me.dgdMarket.Rows.Count > 0 Then
            index = Me.dgdMarket.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            Approve = Me.dgdMarket.Item("Approve", index).Value
            EditTable = Me.dgdMarket.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") And Not Me.dgdMarket.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdMarket.Height = 306
                ' Me.txtMarketCode.Enabled = False
                Me.dgdMarket.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mMarket_ID = Me.dgdMarket.Item("Market_ID", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
                QueryGrid()
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
            Me.Text = "List Of Market"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Market  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Market -> Add."
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

    Private Sub QueryMarket(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryMarket()
        Else
            strQuery = MakeQueryMarket(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "MarketList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdMarket.DataSource = ds.Tables("MarketList")
        If Me.dgdMarket.Enabled = False Then
            Me.dgdMarket.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdMarket.Columns.Item("MarketCode").ToolTipText = "Hiện có:" + CStr(Me.dgdMarket.RowCount()) + " Markets."
        End If
        If Me.dgdMarket.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdMarket.Rows.Count And Me.dgdMarket.Rows.Count > 0 Then
            Me.dgdMarket.Rows(location).Selected = True
            Me.dgdMarket.CurrentCell = Me.dgdMarket.Rows(location).Cells(1)
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdMarket)
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

        Me.dgdMarket.Columns.Item("Market_ID").Visible = False
        Me.dgdMarket.Columns.Item("Market").Visible = Me.smnuDisplayMarket.Checked
        Me.dgdMarket.Columns.Item("Editable").Visible = False
        Me.dgdMarket.Columns.Item("Continued").Visible = False
        Me.dgdMarket.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        Me.dgdMarket.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdMarket.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdMarket.Width = (Me.Width - 30)
        If Me.Width > 610 Then
            dgdMarket.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 85, 80) '> 7000
        Else
            dgdMarket.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdMarket.Height + dgdMarket.Top

        Me.txtMarket.Width = Me.Width - 300

        'cmdCancel.Left = Me.fraUpdate.Width / 2 - cmdCancel.Width + 30
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtMarket.Left + Me.txtMarket.Width + 10
        txtMarket.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdMarket_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdMarket.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        index = Me.dgdMarket.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdMarket.CurrentCellAddress.X = 3 And Me.dgdMarket.CurrentCellAddress().Y = index Then
            Call ApproveMarket()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdMarket_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdMarket.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryMarket("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdMarket)
        Exit Sub
Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdMarket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdMarket.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdMarket.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdMarket.SelectedRows(i).Index)
                Next i
            End If

            QueryMarket()
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
        Me.txtMarketCode.Text = Me.dgdMarket.Item("MarketCode", index).Value.ToString
        Me.txtMarketName.Text = Me.dgdMarket.Item("Market", index).Value.ToString
        Me.txtRemarks.Text = Me.dgdMarket.Item("Remarks", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshDataDest(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Me.cboPort.Text = Me.dgdDestination.Item("DestCode", index).Value.ToString
        Me.txtDestination.Text = Me.dgdDestination.Item("DEST", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListMarket_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strMarket_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.dgdMarket.Rows.Count > 0) Then
            index = Me.dgdMarket.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Market "
            strQuery = strQuery & "WHERE Market_ID = '" & mMarket_ID & "' AND Market_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Market_ID").Value = NewId()
                End If
                strMarket_ID = .Fields("Market_ID").Value
                .Fields("MarketCode").Value = Me.txtMarketCode.Text
                .Fields("Market").Value = Me.txtMarketName.Text
                .Fields("RemarksBooking").Value = Me.txtRemarks.Text
                .Update()

            End With
            rs.Close()
            Me.dgdMarket.Enabled = True
            If mStatus = "Edit" Then
                QueryMarket(, 1, index)
            Else
                QueryMarket(, 15, index)
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
        Me.dgdMarket.Enabled = True
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
                QueryMarket("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdMarket.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdMarket, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub QueryGrid()
        Try
            Dim strSql As String = "Select Destination_ID,Dest_Code,Dest,editable,continued,approve,userid,updatetime " & _
                                   " From Destination where Market_ID='" & mMarket_ID & "' and continued=1"

            oTableDest = ReadTable(strSql)

            Me.dgdDestination.DataSource = oTableDest
            InsertAutoNumberToGrid(Me.dgdDestination)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetItemsDest(ByRef value As Boolean)
        On Error GoTo Err_Renamed
        Me.dgdDestination.Enabled = Not value
        Me.cboPort.Enabled = value
        Me.txtDestination.Enabled = value
        Me.cmdOKDest.Enabled = value
        'Me.cmdCancelDest.Enabled = value
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuAddDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuAddDest.Click
        Try
            If mStatusDest = "Normal" And UserRight("mnumarketingsale", "Add") Then
                If mMarket_ID = DefaultValue Then
                    MsgBox("Input market")
                    Me.fraUpdate.SelectedIndex = 0
                    Return
                End If
                SetItemsDest((True))
                mDestinationID = DefaultValue
                mStatusDest = "Add"
            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuEdit.Click
        Try
            Dim Approve, EditTable As Boolean
            Dim index As Integer
            If Me.oTableDest.Rows.Count > 0 Then
                index = Me.dgdDestination.CurrentRow.Index
            Else
                Exit Sub
            End If

            If index >= 0 Then
                Approve = Me.dgdDestination.Item("ApproveD", index).Value
                EditTable = Me.dgdDestination.Item("EditableD", index).Value
                If mStatusDest = "Normal" And Not Approve And EditTable And UserRight("mnumarketingsale", "Edit") Then
                    SetItemsDest(True)
                    mDestinationID = Me.dgdDestination.Item("Destination_ID", index).Value.ToString
                    mStatusDest = "Edit"
                    RefreshDataDest(index)
                Else
                    DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cxtsmnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuDelete.Click
        Try
            Dim selectedRowCount As Integer = _
      Me.dgdDestination.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRowDest(Me.dgdDestination.SelectedRows(i).Index)
                Next i
            End If
            QueryGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub QueryCombo()
        Try
            Dim id As String = "Port_ID"
            Dim value As String = "Port_Code"
            Dim strQuery As String = "select * from Port where continued=1"
            loadDataToObject(Me.cboPort, strQuery, id, value)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Private Sub cmdOKDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKDest.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strMarket_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTableDest.Rows.Count > 0) Then
            index = Me.dgdDestination.CurrentRow.Index
        End If

        If CheckDataDest() And (mStatusDest = "Add" Or mStatusDest = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Destination "
            strQuery = strQuery & "WHERE Destination_ID = '" & mDestinationID & "' AND Destination_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Destination_ID").Value = NewId()
                End If
                Dim tmp As String = mMarket_ID.Replace("{", "")
                tmp = tmp.Trim("}", "")
                .Fields("Market_ID").Value = "{" & tmp & "}"
                .Fields("Dest_Code").Value = Me.cboPort.Text.Trim
                .Fields("Dest").Value = Me.txtDestination.Text.Trim

                .Update()

            End With
            rs.Close()
            Me.dgdDestination.Enabled = True

            QueryGrid()

            SetItemsDest(False)
            mStatusDest = "Normal"
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancelDest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelDest.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetItemsDest((False))
        mStatusDest = "Normal"
        mStatus = "Normal"
        reText(mStatus)
        SetMenu(True)
        Me.dgdMarket.Enabled = True
        Me.dgdDestination.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdDestination_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDestination.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        index = Me.dgdDestination.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdDestination.CurrentCellAddress.X = 5 And Me.dgdDestination.CurrentCellAddress().Y = index Then
            Call ApproveDest()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cxtsmnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuSearch.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPort.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub dgdDestination_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDestination.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDestination)
    End Sub

    Private Sub cboPort_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboPort.Leave
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM Port "
        strQuery = strQuery & "WHERE Port_Code = '" & Me.cboPort.Text.Trim & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            Me.txtDestination.Text = rs.Fields("Port").Value.ToString
        End If
        rs.Close()
    End Sub

    Private Sub cboPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPort.SelectedIndexChanged
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM Port "
        strQuery = strQuery & "WHERE Port_Code = '" & Me.cboPort.Text.Trim & "' And Continued=1"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            Me.txtDestination.Text = rs.Fields("Port").Value.ToString
        End If
        rs.Close()
    End Sub
End Class