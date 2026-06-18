Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmTradeCode


    Inherits System.Windows.Forms.Form

    Dim rsTradeList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mTradeId As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strTradeSelect As String = "SELECT " & _
    "TRADE_CODE_ID, " & _
    "Trade_Code, " & _
    "Remarks, " & _
    "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "


    Const strTradeOrder1 As String = _
           " ORDER BY Trade_Code  Desc "
    Const strTradeOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strTradeId As String
        If mStatus = "Add" Then
            strTradeId = DefaultValue
            If Me.txtcode.Text = "" Then
                CheckData = False
                DisplayMessage(True, "The code not allow NULL value")
                Exit Function
            End If
            Dim rs As New ADODB.Recordset
            Dim strquery As String
            strquery = "SELECT * "
            strquery = strquery & "FROM Trade_Code "
            strquery = strquery & "WHERE Trade_code = '" & Me.txtCode.Text & "' And Continued=1"
            rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                CheckData = False
                rs.Close()
                DisplayMessage(True, "This code had already in database")
                Exit Function
            End If
        End If
        If Len(Me.txtRemarks.Text) = 0 Then
            CheckData = False
            strMsg = strMsg & "The Name is invalid. Please check again."
        End If
        If strMsg <> "" Then
            DisplayMessage(True, strMsg)
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    Private Sub cmdCancel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdTradeCode.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtTradeCode.Text)
        If Me.txtTradeCode.Text <> "" Then
            Select Case cboFind.Text
                Case "CODE"
                    QueryTrade("AND ( Trade_CODE LIKE '" & strFilter & "') " & mFilter)
                    If Me.smnuDisplayCode.Checked = False Then
                        Me.smnuDisplayCode.Checked = True
                    End If
                    Me.dgdTradeCode.Columns.Item("Trade_CODE").Visible = Me.smnuDisplayCode.Checked
                    'Case "NAME"
                    '    QueryTrade("AND (Trade LIKE '" & strFilter & "')")
                    '    If Me.smnuDisplayName.Checked = False Then
                    '        Me.smnuDisplayName.Checked = True
                    '    End If
                    '    UpdateFrame()
                    'Case "TAX"
                    '    QueryTrade("AND (TAX LIKE '" & strFilter & "') " & mFilter)
                    '    If Me.smnuDisplayTax.Checked = False Then
                    '        Me.smnuDisplayTax.Checked = True
                    '    End If
                    '   me.dgdTradeCode.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
                    'Case "E-MAIL"
                    '    QueryTrade("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
                    '    If Me.smnuDisplayFax.Checked = False Then
                    '        Me.smnuDisplayFax.Checked = True
                    '    End If
                    '   me.dgdTradeCode.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
            End Select
        Else
            QueryTrade(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strTradeId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Trade_Code "
            strQuery = strQuery & "WHERE Trade_Code_Id = '" & mTradeId & "' AND Trade_Code_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Trade_Code_Id").Value = NewId()
                End If
                strTradeId = .Fields("Trade_Code_Id").Value
                If mStatus = "Edit" Then
                    '.Fields("Code").Value = Trim(Me.txtCode.Text)
                Else
                    .Fields("Trade_Code").Value = Me.txtCode.Text
                End If
                .Fields("ReMarks").Value = UCase(Trim(Me.txtRemarks.Text))
                .Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()

            'không cần sắp xếp

            'If mStatus = "Edit" Then
            '    QueryTrade(, 1)
            'Else
            '    QueryTrade(, 15)
            'End If
            Me.dgdTradeCode.Enabled = True
            'fraUpdate chỉ visible khi thêm hay sửa thành công
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            If Me.oTable.Rows.Count > 0 Then
                index = Me.dgdTradeCode.CurrentRow.Index
            End If
            QueryTrade(, , index)
            mStatus = "Normal"
            blnUpdated = True
        End If





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmTradeCode_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mTradeId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "TAX", "TAX")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "E-MAIL", "E-MAIL")
        'Me.cboFind.Items.Add(oItems)

        Me.cboFind.Text = objUserSetting.GetCParm("frmTradeCode.cboFind", "NAME")
        mFilter = objUserSetting.GetCParm("frmTradeCode.mFilter")
        Me.txtcode.Text = objUserSetting.GetCParm("frmTradeCode.txtCODE")

        Me.txtRemarks.Text = objUserSetting.GetCParm("frmTradeCode.txtRemarks")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmTradeCode.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmTradeCode.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmTradeCode.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmTradeCode.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmTradeCode.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmTradeCode.txtPERSONINCHARGE")

        If Me.txtTradeCode.Text <> "" Then
            QueryTrade("AND Trade_Code LIKE '" & MakeFilter(Me.txtTradeCode.Text) & "' " & mFilter, , 15)
        Else
            QueryTrade(mFilter, , 15)
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        Me.smnuDisplayRemarks.Checked = objUserSetting.GetBParm("frmTradeCode.smnuDisplayReMarks")
        Me.smnuDisplayCode.Checked = objUserSetting.GetBParm("frmTradeCode.smnuDisplayCode")
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmTradeCode.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmTradeCode.smnuDisplayUpdateTime")
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmTradeCode_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmTradeCode.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmTradeCode.txtTradeCode", Me.txtTradeCode.Text)
        objUserSetting.SetCParm("frmTradeCode.txtCODE", Me.txtcode.Text)
        objUserSetting.SetCParm("frmTradeCode.txtRemarks", Me.txtRemarks.Text)

        objUserSetting.SetCParm("frmTradeCode.mFilter", mFilter)

        objUserSetting.SetBParm("frmTradeCode.smnuDisplayRemarks", Me.smnuDisplayRemarks.Checked)
        objUserSetting.SetBParm("frmTradeCode.smnuDisplayCode", Me.smnuDisplayCode.Checked)

        objUserSetting.SetBParm("frmTradeCode.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        objUserSetting.SetBParm("frmTradeCode.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmTradeCode.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryTrade(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryTrade = strTradeSelect
        ' MakeQueryTrade = MakeQueryTrade & ", (SELECT count(*) FROM BillOfLading  WHERE Trade.Trade_Code_Id = BillOfLading.Trade_Code_Id) AS NumOfTransaction "
        MakeQueryTrade = MakeQueryTrade & " FROM Trade_Code "
        MakeQueryTrade = MakeQueryTrade & "WHERE (Trade_Code_Id = '" & DefaultValue & "') "

        MakeQueryTrade = MakeQueryTrade & "OR ("
        MakeQueryTrade = MakeQueryTrade & "Continued = 1 "
        MakeQueryTrade = MakeQueryTrade & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryTrade = MakeQueryTrade & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryTrade = MakeQueryTrade & strTradeOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryTrade = MakeQueryTrade & strTradeOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeTrade() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Trade_Code) as CountNo from Trade", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmTradeCode", "Add") Then
            Me.txtCode.Enabled = True
            Me.dgdTradeCode.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mTradeId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'me.txtcode.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Phải Đựơc Cầp Quyền"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveTrade()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdTradeCode.CurrentRow.Index
        Dim strQueryTradeList As String
        If Not Me.dgdTradeCode.Item("Editable", index).Value Or Not UserRight("frmTradeCode", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
            QueryTrade(, , index)
        Else
            strQueryTradeList = "Select * from Trade_Code where" + " Trade_Code_Id= '" & Me.dgdTradeCode.Item("Trade_Code_Id", index).Value.ToString & "'"
            rsTradeList.Open(strQueryTradeList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsTradeList.Fields("Approve").Value
            rsTradeList.Update("Approve", Approve)
            rsTradeList.Close()
        End If
        QueryTrade()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Trade_Code_Id = '" &me.dgdTradeCode.Item("Trade_Code_Id", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Trade_Code WHERE Trade_Code_Id = '" & Me.dgdTradeCode.Item("Trade_Code_Id", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Trade can not be removed.", "Cảng Này Không Thể Xoá"))
            Exit Sub
        End If
        'chư có ràng buộc
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Trade can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdTradeCode.Item("Approve", index)) Then
            If Me.dgdTradeCode.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdTradeCode.Item("Editable", index)) Then
            If Not Me.dgdTradeCode.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmTradeCode", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        Else
            strMesg = "Delete the Trade: " & Me.dgdTradeCode.Item("Trade_Code", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Trade_Code where" + " Trade_Code_Id= '" & Me.dgdTradeCode.Item("Trade_Code_Id", index).Value.ToString & "'"
                rsTradeList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsTradeList.Fields("continued").Value = 0
                rsTradeList.Update()

                rsTradeList.Requery()
                Me.dgdTradeCode.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdTradeCode.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsTradeList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdTradeCode.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdTradeCode.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryTrade()
    End Sub
    Public Sub smnuDisplayRemarks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayRemarks.Click
        Me.smnuDisplayRemarks.Checked = Not Me.smnuDisplayRemarks.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayApprove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayCode_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayCode.Click
        Me.smnuDisplayCode.Checked = Not Me.smnuDisplayCode.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayUpdateTime_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayUpdateTime.Click
        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayUserId_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayUserId.Click
        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
        UpdateFrame()
    End Sub


    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer = 0
        'kiểm tra xem Grid có dữ liệu không

        If Me.dgdTradeCode.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            Return
        End If
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdTradeCode.CurrentRow.Index
        End If
        If index >= 0 Then
            Approve = Me.dgdTradeCode.Item("Approve", index).Value
            EditTable = Me.dgdTradeCode.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmTradeCode", "Edit") And Not Me.dgdTradeCode.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdTradeCode.Height = 306
                Me.dgdTradeCode.Enabled = False
                Me.txtCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mTradeId = Me.dgdTradeCode.Item("Trade_Code_Id", index).Value.ToString
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
            Me.Text = "Trade "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Trade -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Trade -> Add."
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

    Private Sub QueryTrade(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryTrade()
        Else
            strQuery = MakeQueryTrade(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "TradeList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdTradeCode.DataSource = ds.Tables("TradeList")
        If Me.dgdTradeCode.Enabled = False Then
            Me.dgdTradeCode.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdTradeCode.Columns.Item("Trade_Code").ToolTipText = "Hiện có:" + CStr(Me.dgdTradeCode.RowCount()) + " Trades."
        End If
        If Me.dgdTradeCode.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdTradeCode.Rows.Count And Me.dgdTradeCode.Rows.Count > 0 Then
            Me.dgdTradeCode.Rows(location).Selected = True
            Me.dgdTradeCode.CurrentCell = Me.dgdTradeCode.Rows(location).Cells(2)
        End If
        '--------------------
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

        Me.dgdTradeCode.Columns.Item("Trade_Code_Id").Visible = False
        Me.dgdTradeCode.Columns.Item("Trade_Code").Visible = Me.smnuDisplayCode.Checked
        Me.dgdTradeCode.Columns.Item("Remarks").Visible = Me.smnuDisplayRemarks.Checked

        Me.dgdTradeCode.Columns.Item("Editable").Visible = False
        Me.dgdTradeCode.Columns.Item("Continued").Visible = False
        Me.dgdTradeCode.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        Me.dgdTradeCode.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdTradeCode.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        dgdTradeCode.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdTradeCode.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdTradeCode.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdTradeCode.Height + dgdTradeCode.Top '+ 100
        Me.txtTradeCode.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        cmdFind.Left = Me.txtTradeCode.Left + Me.txtTradeCode.Width + 10
        txtTradeCode.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdTrade_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdTradeCode.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdTradeCode.CurrentRow.Index
        On Error GoTo Err_Renamed
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdTradeCode.CurrentCellAddress.X = 3 And Me.dgdTradeCode.CurrentCellAddress().Y = index Then
            Call ApproveTrade()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdTrade_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdTradeCode.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryTrade("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdTrade_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdTradeCode.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdTradeCode.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdTradeCode.SelectedRows(i).Index)
                Next i
            End If

            QueryTrade()
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
        Me.txtCode.Text = Me.dgdTradeCode.Item("Trade_Code", index).Value.ToString
        Me.txtRemarks.Text = Me.dgdTradeCode.Item("Remarks", index).Value.ToString

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub frmTradeCode_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
End Class