Public Class frmInlandArbitray

    Dim mStatus As String = "Normal"
    Dim mFilter As String

    Dim mInlandArbitrayID As String = DefaultValue




    Dim rsInlandArbitrayList As New ADODB.Recordset
    Public blnUpdated As Boolean

    Public oTable As DataTable
    Public ds As New DataSet
    '"Price20GP as [20GP],Price40GP as [40GP],Price40HC as [40HC],Price45HC as [45HC],Price20RF as [20RF],Price40RF as [40RF],Price40RH as [40RH],RelayPort," & _
    Const strInlandArbitraySelect As String = "SELECT " & _
    "InlandArbitrayID,InlandArbitray.Market_ID,POL_ID,POD_ID, " & _
    "MarketCode,Market,POL.Port as POL,POD.Port as POD," & _
    "Price20GP ,Price40GP ,Price40HC ,Price45HC,Price20RF ,Price40RF ,Price40RH ,RelayPort," & _
    "InlandArbitray.Approve, " & _
    "InlandArbitray.Continued, " & _
    "InlandArbitray.Editable, " & _
    "InlandArbitray.UserId, " & _
    "InlandArbitray.Updatetime "


    Const strInlandArbitrayOrder1 As String = _
           " ORDER BY MarketCode  Desc "
    Const strInlandArbitrayOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    '    Private Function CheckData() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strMsg As String
    '        CheckData = True
    '        strMsg = ""
    '        Dim strInlandArbitrayId As String
    '        If mStatus = "Add" Then
    '            strInlandArbitrayId = DefaultValue
    '            If Me.txtInlandArbitrayCode.Text = "" Then
    '                CheckData = False
    '                DisplayMessage(True, "The code not allow NULL value")
    '                Exit Function
    '            End If
    '            Dim rs As New ADODB.Recordset
    '            Dim strquery As String
    '            strquery = "SELECT * "
    '            strquery = strquery & "FROM InlandArbitray "
    '            strquery = strquery & "WHERE InlandArbitray_code = '" & Me.txtInlandArbitrayCode.Text & "' And Continued=1"
    '            rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            If Not rs.EOF Then
    '                CheckData = False
    '                rs.Close()
    '                DisplayMessage(True, "This code had already in database")
    '                Exit Function
    '            End If
    '        End If
    '        If Len(Me.TxtInlandArbitrayName.Text) = 0 Then
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
        Me.dgdInlandArbitray.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtInlandArbitray.Text)
    '        If Me.txtInlandArbitray.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtInlandArbitray.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdInlandArbitray)
    '            'Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            QueryInlandArbitray("AND ( InlandArbitray_CODE LIKE '" & strFilter & "') ")
    '            '            If Me.smnuDisplayCode.Checked = False Then
    '            '                Me.smnuDisplayCode.Checked = True
    '            '            End If
    '            '            Me.dgdInlandArbitray.Columns.Item("InlandArbitray_CODE").Visible = Me.smnuDisplayCode.Checked
    '            '        Case "NAME"
    '            '            QueryInlandArbitray("AND (InlandArbitray LIKE '" & strFilter & "')")
    '            '            If Me.smnuDisplayName.Checked = False Then
    '            '                Me.smnuDisplayName.Checked = True
    '            '            End If
    '            '            UpdateFrame()
    '            '        Case "TAX"
    '            '            QueryInlandArbitray("AND (TAX LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayTax.Checked = False Then
    '            '                Me.smnuDisplayTax.Checked = True
    '            '            End If
    '            '            Me.dgdInlandArbitray.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
    '            '        Case "E-MAIL"
    '            '            QueryInlandArbitray("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayFax.Checked = False Then
    '            '                Me.smnuDisplayFax.Checked = True
    '            '            End If
    '            '            Me.dgdInlandArbitray.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
    '            '    End Select
    '            'Else
    '            '    QueryInlandArbitray(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strInlandArbitrayId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        If mStatus = "Edit" Then
            index = Me.dgdInlandArbitray.CurrentRow.Index
        End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM InlandArbitray "
            strQuery = strQuery & "WHERE InlandArbitrayId = '" & mInlandArbitrayID & "' AND InlandArbitrayId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("InlandArbitrayId").Value = NewId()
                End If
                strInlandArbitrayId = .Fields("InlandArbitrayId").Value

                .Fields("Market_ID").Value = "{" & Me.cboMarket.SelectedValue.ToString & "}"
                .Fields("POL_ID").Value = "{" & Me.cboPOL.SelectedValue.ToString & "}"
                .Fields("POD_ID").Value = "{" & Me.cboPOD.SelectedValue.ToString & "}"
                .Fields("RelayPort").Value = UCase(Trim(Me.txtRelayPort.Text))
                .Fields("Price20GP").Value = Me.txtPrice20GP.Text
                .Fields("Price40GP").Value = Me.txtPrice40GP.Text
                .Fields("Price40HC").Value = Me.txtPrice40HC.Text
                .Fields("Price45HC").Value = Me.txtPrice45HC.Text
                .Fields("Price20RF").Value = Me.txtPrice20RF.Text
                .Fields("Price40RF").Value = Me.txtPrice40RF.Text
                .Fields("Price40RH").Value = Me.txtPrice40RH.Text
                .Update()
            End With
            rs.Close()

            'không cần sắp xếp

            'If mStatus = "Edit" Then
            '    QueryInlandArbitray(, 1)
            'Else
            '    QueryInlandArbitray(, 15)
            'End If
            Me.dgdInlandArbitray.Enabled = True
            'fraUpdate chỉ visible khi thêm hay sửa thành công
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            QueryInlandArbitray(mFilter, , index)
            mStatus = "Normal"
            blnUpdated = True
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub QueryMarket()
        Try
            Dim SQL As String
            SQL = " Select Market_ID as ID ,MarketCode + '-' + Market  as Data"
            SQL &= " From Market "
            SQL &= " Where Continued=1 "
            SQL &= " Order By Data"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboMarket.DisplayMember = "data"
            Me.cboMarket.ValueMember = "ID"
            Me.cboMarket.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function GetPortdata() As DataTable
        Try
            Dim SQL As String
            SQL = "select Port_ID as ID ,Port_Code+'-'+Port as data "
            SQL &= " From Port "
            SQL &= " Where Continued=1 "
            SQL &= " Order By Data "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryPort() As DataTable
        Try
            Dim dt1 As New DataTable
            dt1 = GetPortdata()

            Dim dt2 As New DataTable
            dt2 = dt1.Copy

            Me.cboPOL.DisplayMember = "data"
            Me.cboPOL.ValueMember = "ID"
            Me.cboPOL.DataSource = dt1

            Me.cboPOD.DisplayMember = "data"
            Me.cboPOD.ValueMember = "ID"
            Me.cboPOD.DataSource = dt2

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub frmInlandArbitray_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False

        SetDefaultGrid(Me.dgdInlandArbitray, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mInlandArbitrayId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False

        QueryMarket()
        QueryPort()
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmInlandArbitray_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub frmListVVIP_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
    '        objUserSetting.SetCParm("frmInlandArbitray.cboFind", Me.cboFind.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtInlandArbitray", Me.txtInlandArbitray.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtCODE", Me.txtInlandArbitrayCode.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtInlandArbitrayName", Me.TxtInlandArbitrayName.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtTel", Me.txtTel.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtFax", Me.txtFax.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtAddress", Me.txtAddress.Text)
    '        objUserSetting.SetCParm("frmInlandArbitray.txtCountry", Me.txtCountry.Text)

    '        objUserSetting.SetCParm("frmInlandArbitray.mFilter", mFilter)

    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayName", Me.smnuDisplayName.Checked)
    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayCode", Me.smnuDisplayCode.Checked)
    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayTel", Me.smnuDisplayTel.Checked)
    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayFax", Me.smnuDisplayFax.Checked)
    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmInlandArbitray.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        Me.cmdCancel_Click(eventSender, eventArgs)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryInlandArbitray(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryInlandArbitray = strInlandArbitraySelect

        MakeQueryInlandArbitray = MakeQueryInlandArbitray & " FROM (((InlandArbitray LEFT JOIN Market On InlandArbitray.Market_ID=Market.Market_ID) "
        MakeQueryInlandArbitray = MakeQueryInlandArbitray & " LEFT JOIN Port as POL On POL.Port_ID=InlandArbitray.POL_ID )"
        MakeQueryInlandArbitray = MakeQueryInlandArbitray & " LEFT JOIN Port as POD On POD.Port_ID=InlandArbitray.POD_ID)"
        MakeQueryInlandArbitray = MakeQueryInlandArbitray & "WHERE (InlandArbitrayID = '" & DefaultValue & "') "

        MakeQueryInlandArbitray = MakeQueryInlandArbitray & "OR ("
        MakeQueryInlandArbitray = MakeQueryInlandArbitray & " InlandArbitray.Continued = 1 "
        MakeQueryInlandArbitray = MakeQueryInlandArbitray & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryInlandArbitray = MakeQueryInlandArbitray & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryInlandArbitray = MakeQueryInlandArbitray & strInlandArbitrayOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryInlandArbitray = MakeQueryInlandArbitray & strInlandArbitrayOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    'Public Function CodeInlandArbitray() As Integer
    '    Dim rsCount As New ADODB.Recordset
    '    Dim code As Integer
    '    rsCount.Open("select Count(InlandArbitray_Code) as CountNo from InlandArbitray", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    code = rsCount.Fields("CountNo").Value
    '    Return code
    'End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmInlandArbitray", "Add") Then
            'Me.txtInlandArbitrayCode.Enabled = True
            Me.dgdInlandArbitray.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mInlandArbitrayId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtInlandArbitrayCode.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveInlandArbitray()
        On Error GoTo Err_Renamed
        Dim Approve As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdInlandArbitray.CurrentRow.Index
        Dim strQueryInlandArbitrayList As String
        If Me.dgdInlandArbitray.Item("Editable", index).Value = 0 Or Not UserRight("frmInlandArbitray", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
            QueryInlandArbitray(mFilter, , index)
        Else
            strQueryInlandArbitrayList = "Select * from InlandArbitray where" + " InlandArbitrayID= '" & Me.dgdInlandArbitray.Item("InlandArbitrayID", index).Value.ToString & "'"
            rsInlandArbitrayList.Open(strQueryInlandArbitrayList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = IIf(rsInlandArbitrayList.Fields("Approve").Value = 0, 1, 0)
            rsInlandArbitrayList.Update("Approve", Approve)
            rsInlandArbitrayList.Close()
        End If
        QueryInlandArbitray(mFilter, , index)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE InlandArbitrayID = '" & Me.dgdInlandArbitray.Item("InlandArbitrayID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from InlandArbitray WHERE InlandArbitrayId = '" & Me.dgdInlandArbitray.Item("InlandArbitrayId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The InlandArbitray can not be removed.", "Cảng Này Không Thể Xoá"))
            Exit Sub
        End If
        'chư có ràng buộc
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The InlandArbitray can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdInlandArbitray.Item("Approve", index)) Then
            If Me.dgdInlandArbitray.Item("Approve", index).Value = 1 Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdInlandArbitray.Item("Editable", index)) Then
            If Not Me.dgdInlandArbitray.Item("Editable", index).Value = 1 Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmInlandArbitray", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        Else
            strMesg = "Delete the InlandArbitray: " & Me.dgdInlandArbitray.Item("MarketCode", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from InlandArbitray where" + " InlandArbitrayID= '" & Me.dgdInlandArbitray.Item("InlandArbitrayID", index).Value.ToString & "'"
                rsInlandArbitrayList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsInlandArbitrayList.Fields("continued").Value = 0
                rsInlandArbitrayList.Update()

                rsInlandArbitrayList.Requery()
                Me.dgdInlandArbitray.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdInlandArbitray.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsInlandArbitrayList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdInlandArbitray.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdInlandArbitray.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryInlandArbitray(mFilter)
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

        'kiểm tra xem Grid có dữ liệu không

        If Me.dgdInlandArbitray.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            Return
        End If
        Dim index As Integer = Me.dgdInlandArbitray.CurrentRow.Index

        If index >= 0 Then
            Approve = Me.dgdInlandArbitray.Item("Approve", index).Value
            EditTable = Me.dgdInlandArbitray.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmInlandArbitray", "Edit") And Not Me.dgdInlandArbitray.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdInlandArbitray.Height = 306
                Me.dgdInlandArbitray.Enabled = False
                'Me.txtInlandArbitrayCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mInlandArbitrayID = Me.dgdInlandArbitray.Item("InlandArbitrayId", index).Value.ToString
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
            Me.Text = "Inland Arbitray "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Inland Arbitray -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Inland Arbitray -> Add."
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

    Private Sub QueryInlandArbitray(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryInlandArbitray()
        Else
            strQuery = MakeQueryInlandArbitray(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "InlandArbitrayList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdInlandArbitray.DataSource = ds.Tables("InlandArbitrayList")
        If Me.dgdInlandArbitray.Enabled = False Then
            Me.dgdInlandArbitray.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdInlandArbitray.Columns.Item("MarketCode").ToolTipText = "Hiện có:" + CStr(Me.dgdInlandArbitray.RowCount()) + " Market Code."
        End If
        If Me.dgdInlandArbitray.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdInlandArbitray.Rows.Count And Me.dgdInlandArbitray.Rows.Count > 0 Then
            Me.dgdInlandArbitray.Rows(location).Selected = True
            Me.dgdInlandArbitray.CurrentCell = Me.dgdInlandArbitray.Rows(location).Cells(1)
        End If
        InsertAutoNumberToGrid(Me.dgdInlandArbitray)
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

    '        Me.dgdInlandArbitray.Columns.Item("InlandArbitrayID").Visible = False
    '        Me.dgdInlandArbitray.Columns.Item("InlandArbitray_Code").Visible = True  'Me.smnuDisplayCode.Checked
    '        Me.dgdInlandArbitray.Columns.Item("InlandArbitray").Visible = Me.smnuDisplayName.Checked
    '        Me.dgdInlandArbitray.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
    '        Me.dgdInlandArbitray.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
    '        Me.dgdInlandArbitray.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
    '        Me.dgdInlandArbitray.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked

    '        Me.dgdInlandArbitray.Columns.Item("Editable").Visible = False
    '        Me.dgdInlandArbitray.Columns.Item("Continued").Visible = False
    '        Me.dgdInlandArbitray.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdInlandArbitray.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
    '        Me.dgdInlandArbitray.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdInlandArbitray.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        dgdInlandArbitray.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdInlandArbitray.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdInlandArbitray.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdInlandArbitray.Height + dgdInlandArbitray.Top '+ 100

        'Me.txtInlandArbitray.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOk.Left = cmdCancel.Left - cmdOk.Width - 10
        'cmdFind.Left = Me.txtInlandArbitray.Left + Me.txtInlandArbitray.Width + 10
        'txtInlandArbitray.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdInlandArbitray_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdInlandArbitray.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdInlandArbitray.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdInlandArbitray.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdInlandArbitray.Columns(ColIndex).Name) = "APPROVE" And Me.dgdInlandArbitray.CurrentCellAddress().Y = index Then
            Call ApproveInlandArbitray()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdInlandArbitray_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdInlandArbitray.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryInlandArbitray("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdInlandArbitray)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdInlandArbitray_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdInlandArbitray.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdInlandArbitray.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdInlandArbitray.SelectedRows(i).Index)
                Next i
            End If

            QueryInlandArbitray()
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
        Me.cboMarket.SelectedValue = Me.dgdInlandArbitray.Item("Market_ID", index).Value.ToString
        Me.cboPOL.SelectedValue = Me.dgdInlandArbitray.Item("POL_ID", index).Value.ToString
        Me.cboPOD.SelectedValue = Me.dgdInlandArbitray.Item("POD_ID", index).Value.ToString
        Me.txtRelayPort.Text = Me.dgdInlandArbitray.Item("RelayPort", index).Value.ToString

        Me.txtPrice20GP.Text = Me.dgdInlandArbitray.Item("Price20GP", index).Value.ToString()
        Me.txtPrice40GP.Text = Me.dgdInlandArbitray.Item("Price40GP", index).Value.ToString()
        Me.txtPrice40HC.Text = Me.dgdInlandArbitray.Item("Price40HC", index).Value.ToString()
        Me.txtPrice45HC.Text = Me.dgdInlandArbitray.Item("Price45HC", index).Value.ToString()
        Me.txtPrice20RF.Text = Me.dgdInlandArbitray.Item("Price20RF", index).Value.ToString()
        Me.txtPrice40RF.Text = Me.dgdInlandArbitray.Item("Price40RF", index).Value.ToString()
        Me.txtPrice40RH.Text = Me.dgdInlandArbitray.Item("Price40RH", index).Value.ToString()

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    'Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
    '    Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub frmInlandArbitray_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strInlandArbitrayId, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM InlandArbitray "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("InlandArbitrayID").Value = NewId()
    '                .Fields("InlandArbitray_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("InlandArbitray").Value = UCase(Trim(rs.Fields("InlandArbitrayname").Value))
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

    '        'không cần sắp xếp

    '        'If mStatus = "Edit" Then
    '        '    QueryInlandArbitray(, 1)
    '        'Else
    '        '    QueryInlandArbitray(, 15)
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
                QueryInlandArbitray("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            If Me.dgdInlandArbitray.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdInlandArbitray, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    'Private Sub txtCapacity_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.txtCapacity.Text = "" Then
    '        MsgBox("Not allow null")
    '        Me.txtCapacity.Focus()
    '    End If
    'End Sub

    'Private Sub txtValidOrder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.txtValidOrder.Text = "" Then
    '        MsgBox("Not allow null")
    '        Me.txtValidOrder.Focus()
    '    End If
    'End Sub

    'Private Sub txtFreeStorage_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrice45HC.TextChanged, txtPrice40RH.TextChanged, txtPrice40RF.TextChanged, txtPrice40HC.TextChanged, txtPrice40GP.TextChanged, txtPrice20RF.TextChanged, txtPrice20GP.TextChanged
    '    If Me.txtFreeStorage.Text = "" Then
    '        MsgBox("Not allow null")
    '        Me.txtFreeStorage.Focus()
    '    End If
    'End Sub
End Class