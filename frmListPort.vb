Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListPort
    Inherits System.Windows.Forms.Form

    Dim rsPortList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mPortId As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strPortSelect As String = "SELECT " & _
    "Port_Id, " & _
    "Port_Code, " & _
    "Port , " & _
    "Tel , " & _
    "Fax , " & _
    "Address , " & _
    "Country,MarketCodeTS,MarketCodeSale,DateExp, " & _
    "OverW20,OverW40,Approve,IG,tradecode, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "


    Const strPortOrder1 As String = _
           " ORDER BY Port_Code  Desc "
    Const strPortOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        CheckData = True
        strMsg = ""
        Dim strPortId As String
        If mStatus = "Add" Then
            strPortId = DefaultValue
            If Me.txtPortCode.Text = "" Then
                CheckData = False
                DisplayMessage(True, "The code not allow NULL value")
                Exit Function
            End If
            Dim rs As New ADODB.Recordset
            Dim strquery As String
            strQuery = "SELECT * "
            strquery = strquery & "FROM Port "
            strquery = strquery & "WHERE Port_code = '" & Me.txtPortCode.Text & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                CheckData = False
                rs.Close()
                DisplayMessage(True, "This code had already in database")
                Exit Function
            End If
        End If
        If Len(Me.TxtPortName.Text) = 0 Then
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
        Me.dgdPort.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtPort.Text)
        If Me.txtPort.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtPort.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdPort)
            'Select Case cboFind.Text
            '        Case "CODE"
            '            QueryPort("AND ( Port_CODE LIKE '" & strFilter & "') ")
            '            If Me.smnuDisplayCode.Checked = False Then
            '                Me.smnuDisplayCode.Checked = True
            '            End If
            '            Me.dgdPort.Columns.Item("Port_CODE").Visible = Me.smnuDisplayCode.Checked
            '        Case "NAME"
            '            QueryPort("AND (Port LIKE '" & strFilter & "')")
            '            If Me.smnuDisplayName.Checked = False Then
            '                Me.smnuDisplayName.Checked = True
            '            End If
            '            UpdateFrame()
            '        Case "TAX"
            '            QueryPort("AND (TAX LIKE '" & strFilter & "') " & mFilter)
            '            If Me.smnuDisplayTax.Checked = False Then
            '                Me.smnuDisplayTax.Checked = True
            '            End If
            '            Me.dgdPort.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
            '        Case "E-MAIL"
            '            QueryPort("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
            '            If Me.smnuDisplayFax.Checked = False Then
            '                Me.smnuDisplayFax.Checked = True
            '            End If
            '            Me.dgdPort.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
            '    End Select
            'Else
            '    QueryPort(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        Try

     
            Dim strQuery, strPortId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            If mStatus = "Edit" Then
                index = Me.dgdPort.CurrentRow.Index
            End If
            If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Port "
                strQuery = strQuery & "WHERE Port_Id = '" & mPortId & "' AND Port_Id <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("Port_Id").Value = NewId()
                    End If
                    strPortId = .Fields("Port_Id").Value
                    If mStatus = "Edit" Then
                        ' DisplayMessage(True, "Warning: this Port Code is changed. ")
                    End If
                    .Fields("Port_Code").Value = Me.txtPortCode.Text
                    'End If
                    .Fields("Port").Value = UCase(Trim(Me.TxtPortName.Text))
                    .Fields("Tel").Value = UCase(Trim(Me.txtTel.Text))
                    .Fields("Fax").Value = UCase(Trim(Me.txtFax.Text))
                    .Fields("Address").Value = UCase(Trim(Me.txtAddress.Text))
                    .Fields("Country").Value = UCase(Trim(Me.txtCountry.Text))
                    .Fields("IG").Value = UCase(Trim(Me.txtIG.Text))
                    .Fields("Tradecode").Value = UCase(Trim(Me.txtTradecode.Text))
                    .Fields("MarketCodeTS").Value = UCase(Trim(Me.txtMarketCodeTS.Text))
                    .Fields("MarketCodeSale").Value = UCase(Trim(Me.txtMarketCodeSale.Text))
                    .Fields("DateEXP").Value = Me.dtpExpireDate.Value.Date
                    Try
                        .Fields("show").Value = Me.chkshow.Checked
                    Catch ex As Exception

                    End Try



                    '.Fields("Continued").Value = 1
                    .Update()
                End With
                rs.Close()

                'không cần sắp xếp

                'If mStatus = "Edit" Then
                '    QueryPort(, 1)
                'Else
                '    QueryPort(, 15)
                'End If
                Me.dgdPort.Enabled = True
                'fraUpdate chỉ visible khi thêm hay sửa thành công
                Me.fraUpdate.Visible = False
                ReFormat()
                SetMenu((True))
                'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
                mFilter = " AND PORT_CODE='" & Me.txtPortCode.Text & "' order by Updatetime desc "
                QueryPort(mFilter, , index)
                mStatus = "Normal"
                blnUpdated = True
            End If





        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try  

        'Resume
    End Sub

    Private Sub frmListPort_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdPort, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mPortId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdPort)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "TAX", "TAX")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "E-MAIL", "E-MAIL")
        'Me.cboFind.Items.Add(oItems)

        'Me.cboFind.Text = objUserSetting.GetCParm("frmListPort.cboFind", "NAME")
        mFilter = objUserSetting.GetCParm("frmListPort.mFilter")
        Me.txtPortCode.Text = objUserSetting.GetCParm("frmListPort.txtCODE")
        Me.TxtPortName.Text = objUserSetting.GetCParm("frmListPort.txtPortName")
        Me.txtTel.Text = objUserSetting.GetCParm("frmListPort.txtTel")
        Me.txtFax.Text = objUserSetting.GetCParm("frmListPort.txtFax")
        Me.txtAddress.Text = objUserSetting.GetCParm("frmListPort.txtAddress")
        Me.txtCountry.Text = objUserSetting.GetCParm("frmListPort.txtCountry")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmListPort.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmListPort.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmListPort.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmListPort.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmListPort.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmListPort.txtPERSONINCHARGE")

        'If Me.txtPort.Text <> "" Then
        '    QueryPort("AND Port LIKE '" & MakeFilter(Me.txtPort.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryPort(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmListPort.smnuDisplayCode")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayFax")
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayAddress")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayaPPROVE")
        'Me.smnuDisplayCountry.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayCountry")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListPort.smnuDisplayUpdateTime")
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
        SetDefaultGrid(Me.dgdPort, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListPort_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'SetDefaultGrid(Me.dgdPort, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'objUserSetting.SetCParm("frmListPort.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListPort.txtPort", Me.txtPort.Text)
        'objUserSetting.SetCParm("frmListPort.txtCODE", Me.txtPortCode.Text)
        'objUserSetting.SetCParm("frmListPort.txtPortName", Me.TxtPortName.Text)
        'objUserSetting.SetCParm("frmListPort.txtTel", Me.txtTel.Text)
        'objUserSetting.SetCParm("frmListPort.txtFax", Me.txtFax.Text)
        'objUserSetting.SetCParm("frmListPort.txtAddress", Me.txtAddress.Text)
        'objUserSetting.SetCParm("frmListPort.txtCountry", Me.txtCountry.Text)

        'objUserSetting.SetCParm("frmListPort.mFilter", mFilter)

        'objUserSetting.SetBParm("frmListPort.smnuDisplayName", Me.smnuDisplayName.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayCode", Me.smnuDisplayCode.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayTel", Me.smnuDisplayTel.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayFax", Me.smnuDisplayFax.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

        'objUserSetting.SetBParm("frmListPort.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

        'objUserSetting.SetBParm("frmListPort.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListPort.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryPort(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryPort = strPortSelect
        ' MakeQueryPort = MakeQueryPort & ", (SELECT count(*) FROM BillOfLading  WHERE Port.Port_Id = BillOfLading.Port_Id) AS NumOfTransaction "
        MakeQueryPort = MakeQueryPort & " ,show FROM Port "
        MakeQueryPort = MakeQueryPort & "WHERE (Port_Id = '" & DefaultValue & "') "

        MakeQueryPort = MakeQueryPort & "OR ("
        MakeQueryPort = MakeQueryPort & "Continued = 1 "
        MakeQueryPort = MakeQueryPort & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryPort = MakeQueryPort & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryPort = MakeQueryPort & strPortOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryPort = MakeQueryPort & strPortOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodePort() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Port_Code) as CountNo from Port", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" Then 'And UserRight("frmListPort", "Add")
            Me.txtPortCode.Enabled = True
            Me.dgdPort.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mPortId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtPortCode.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApprovePort()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdPort.CurrentRow.Index
        Dim strQueryPortList As String
        If Not Me.dgdPort.Item("Editable", index).Value Or Not UserRight("frmListPort", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
            QueryPort(mFilter, , index)
        Else
            strQueryPortList = "Select * from Port where" + " Port_Id= '" & Me.dgdPort.Item("Port_ID", index).Value.ToString & "'"
            rsPortList.Open(strQueryPortList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsPortList.Fields("Approve").Value
            rsPortList.Update("Approve", Approve)
            rsPortList.Close()
        End If
        QueryPort(mFilter, , index)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Port_Id = '" & Me.dgdPort.Item("Port_Id", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Port WHERE Port_Id = '" & Me.dgdPort.Item("Port_Id", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Port can not be removed.", "Cảng Này Không Thể Xoá"))
            Exit Sub
        End If
        'chư có ràng buộc
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Port can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdPort.Item("Approve", index)) Then
            If Me.dgdPort.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPort.Item("Editable", index)) Then
            If Not Me.dgdPort.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        'If Not UserRight("frmListPort", "Delete") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        'Else
        strMesg = "Delete the Port: " & Me.dgdPort.Item("Port_Code", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            strQueryCommodityList = "Select * from Port where" + " Port_Id= '" & Me.dgdPort.Item("Port_ID", index).Value.ToString & "'"
            rsPortList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rsPortList.Fields("continued").Value = 0
            rsPortList.Update()

            rsPortList.Requery()
            Me.dgdPort.Rows(index).DefaultCellStyle.ForeColor = Color.White
            Me.dgdPort.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            rsPortList.Close()
            blnUpdated = True
        End If
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdPort.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdPort.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryPort(mFilter)
    End Sub
    Private Sub smnuDisplayCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCode.Click
        Me.smnuDisplayCode.Checked = Not Me.smnuDisplayCode.Checked
        UpdateFrame()
    End Sub
    Public Sub smnuDisplayName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayName.Click
        Me.smnuDisplayName.Checked = Not Me.smnuDisplayName.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayApprove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayApprove.Click
        Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayAddress_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayAddress.Click
        Me.smnuDisplayAddress.Checked = Not Me.smnuDisplayAddress.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayFax_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayFax.Click
        Me.smnuDisplayFax.Checked = Not Me.smnuDisplayFax.Checked
        UpdateFrame()
    End Sub


    Public Sub smnuDisplayCountry_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayCountry.Click
        Me.smnuDisplayCountry.Checked = Not Me.smnuDisplayCountry.Checked
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

        'kiểm tra xem Grid có dữ liệu không

        If Me.dgdPort.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            Return
        End If
        Dim index As Integer = Me.dgdPort.CurrentRow.Index

        If index >= 0 Then
            Approve = Me.dgdPort.Item("Approve", index).Value
            EditTable = Me.dgdPort.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And Not Me.dgdPort.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdPort.Height = 306
                Me.dgdPort.Enabled = False
                'Me.txtPortCode.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mPortId = Me.dgdPort.Item("Port_Id", index).Value.ToString
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
            Me.Text = "Port "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Port -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Port -> Add."
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

    Private Sub QueryPort(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPort()
        Else
            strQuery = MakeQueryPort(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "PortList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPort.DataSource = ds.Tables("PortList")
        If Me.dgdPort.Enabled = False Then
            Me.dgdPort.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdPort.Columns.Item("Port_Code").ToolTipText = "Hiện có:" + CStr(Me.dgdPort.RowCount()) + " Ports."
        End If
        If Me.dgdPort.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdPort.Rows.Count And Me.dgdPort.Rows.Count > 0 Then
            Me.dgdPort.Rows(location).Selected = True
            Me.dgdPort.CurrentCell = Me.dgdPort.Rows(location).Cells(3)
        End If
        InsertAutoNumberToGrid(Me.dgdPort)
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

        'Me.dgdPort.Columns.Item("Port_Id").Visible = False
        'Me.dgdPort.Columns.Item("Port_Code").Visible = True  'Me.smnuDisplayCode.Checked
        'Me.dgdPort.Columns.Item("Port").Visible = Me.smnuDisplayName.Checked
        'Me.dgdPort.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
        'Me.dgdPort.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
        'Me.dgdPort.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
        'Me.dgdPort.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
        'Me.dgdPort.Columns.Item("OverW20").Visible = Me.smnuOrverW20.Checked
        'Me.dgdPort.Columns.Item("OverW40").Visible = Me.smnuOrverW40.Checked
        'Me.dgdPort.Columns.Item("IG").Visible = Me.smnuIG.Checked
        'Me.dgdPort.Columns.Item("Tradecode").Visible = Me.smnuTradecode.Checked

        'Me.dgdPort.Columns.Item("Editable").Visible = False
        'Me.dgdPort.Columns.Item("Continued").Visible = False
        'Me.dgdPort.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
        'Me.dgdPort.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
        'Me.dgdPort.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdPort.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        dgdPort.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdPort.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdPort.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdPort.Height + dgdPort.Top '+ 100

        Me.txtPort.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        cmdFind.Left = Me.txtPort.Left + Me.txtPort.Width + 10
        txtPort.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdPort_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPort.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdPort.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdPort.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPort.Columns(ColIndex).Name = "Approve" And Me.dgdPort.CurrentCellAddress().Y = index Then
            Call ApprovePort()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPort_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPort.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryPort("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdPort)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPort_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdPort.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdPort.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdPort.SelectedRows(i).Index)
                Next i
            End If

            QueryPort()
        End If
    End Sub




    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
        If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
            Me.cboFind.SelectedIndex = 0
            Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
        End If
    End Sub




    Private Sub RefreshData(ByVal index As Integer)
        Try

    
            Dim oItems As PDSAListItemString
            Me.txtIG.Text = ""
            Me.txtTradecode.Text = ""
            Me.txtPortCode.Text = Me.dgdPort.Item("Port_Code", index).Value.ToString
            Me.TxtPortName.Text = Me.dgdPort.Item("Port", index).Value.ToString
            Me.txtTel.Text = Me.dgdPort.Item("Tel", index).Value.ToString
            Me.txtFax.Text = Me.dgdPort.Item("Fax", index).Value.ToString
            Me.txtAddress.Text = Me.dgdPort.Item("Address", index).Value.ToString
            Me.txtCountry.Text = Me.dgdPort.Item("Country", index).Value.ToString

            Me.txtMarketCodeSale.Text = Me.dgdPort.Item("MarketCodeSale", index).Value.ToString
            Me.txtMarketCodeTS.Text = Me.dgdPort.Item("MarketCodeTS", index).Value.ToString
            Me.dtpExpireDate.Text = Me.dgdPort.Item("DateExp", index).Value.ToString
            Try
                Me.txtTradecode.Text = Me.dgdPort.Item("TradeCode", index).Value.ToString
            Catch ex As Exception

            End Try

            Me.txtIG.Text = IIf(Me.dgdPort.Item("IG", index).Value Is Nothing, "", Me.dgdPort.Item("IG", index).Value)
            Try
                Me.chkshow.Checked = Me.dgdPort.Item("show", index).Value.ToString
            Catch ex As Exception

            End Try


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
        Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
        UpdateFrame()
    End Sub

    Private Sub frmListPort_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strPortId, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM port "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("Port_Id").Value = NewId()
    '                .Fields("Port_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("Port").Value = UCase(Trim(rs.Fields("portname").Value))
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
    '        '    QueryPort(, 1)
    '        'Else
    '        '    QueryPort(, 15)
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
                QueryPort("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdPort.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdPort, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSelect.Click
        If Me.dgdPort.SelectedRows.Count > 0 Then
            Dim index As Integer = Me.dgdPort.CurrentRow.Index
            gSearchID = Me.dgdPort.Item("Port_ID", index).Value.ToString
            gSearchCode = Me.dgdPort.Item("Port_Code", index).Value.ToString
            SearchCombo()
            Me.Close()
        End If
    End Sub

    Private Sub txtPort_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPort.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtPortCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPortCode.TextChanged

    End Sub

    Private Sub UpdateOrverWToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateOrverWToolStripMenuItem.Click
        On Error GoTo Err
        VB6.ShowForm(frmEditPortInfo, VB6.FormShowConstants.Modal, Me)
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub OrverW20ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuOrverW20.Click
        Me.smnuOrverW20.Checked = Not Me.smnuOrverW20.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuOrverW40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuOrverW40.Click
        Me.smnuOrverW40.Checked = Not Me.smnuOrverW40.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuIG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuIG.Click
        Me.smnuIG.Checked = Not Me.smnuIG.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuTradecode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuTradecode.Click
        Me.smnuTradecode.Checked = Not Me.smnuTradecode.Checked
        UpdateFrame()
    End Sub

    Private Sub SelectToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectToolStripMenuItem.Click
        If Me.dgdPort.SelectedRows.Count > 0 Then
            Dim index As Integer = Me.dgdPort.CurrentRow.Index
            gSearchID = Me.dgdPort.Item("Port_ID", index).Value.ToString
            SearchCombo()
            Me.Close()
        End If
    End Sub
End Class