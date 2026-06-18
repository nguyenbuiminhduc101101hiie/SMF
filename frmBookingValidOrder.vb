Public Class frmBookingValidOrder
    Inherits System.Windows.Forms.Form
  


    Dim mStatus As String = "Normal"
    Dim mFilter As String

    Dim mBookingValidOrderID As String = DefaultValue
    Dim mApproveBookingValidOrderID As String = DefaultValue



    Dim rsBookingValidOrderList As New ADODB.Recordset
    Public blnUpdated As Boolean

    Public oTable As DataTable
    Public ds As New DataSet

    Const strBookingValidOrderSelect As String = "SELECT " & _
    "BookingValidOrderID, " & _
    "BookingNo ,ValidOrder," & _
    "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "


    Const strBookingValidOrderOrder1 As String = _
           " ORDER BY BookingNo  Desc "
    Const strBookingValidOrderOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    '    Private Function CheckData() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strMsg As String
    '        CheckData = True
    '        strMsg = ""
    '        Dim strBookingValidOrderId As String
    '        If mStatus = "Add" Then
    '            strBookingValidOrderId = DefaultValue
    '            If Me.txtBookingValidOrderCode.Text = "" Then
    '                CheckData = False
    '                DisplayMessage(True, "The code not allow NULL value")
    '                Exit Function
    '            End If
    '            Dim rs As New ADODB.Recordset
    '            Dim strquery As String
    '            strquery = "SELECT * "
    '            strquery = strquery & "FROM BookingValidOrder "
    '            strquery = strquery & "WHERE BookingValidOrder_code = '" & Me.txtBookingValidOrderCode.Text & "' And Continued=1"
    '            rs.Open(strquery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '            If Not rs.EOF Then
    '                CheckData = False
    '                rs.Close()
    '                DisplayMessage(True, "This code had already in database")
    '                Exit Function
    '            End If
    '        End If
    '        If Len(Me.TxtBookingValidOrderName.Text) = 0 Then
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
        Me.dgdBookingValidOrder.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
    '        On Error GoTo Err_Renamed
    '        Dim strFilter As String
    '        strFilter = MakeFilter(Me.txtBookingValidOrder.Text)
    '        If Me.txtBookingValidOrder.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
    '            FindCombo(Me.txtBookingValidOrder.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdBookingValidOrder)
    '            'Select Case cboFind.Text
    '            '        Case "CODE"
    '            '            QueryBookingValidOrder("AND ( BookingValidOrder_CODE LIKE '" & strFilter & "') ")
    '            '            If Me.smnuDisplayCode.Checked = False Then
    '            '                Me.smnuDisplayCode.Checked = True
    '            '            End If
    '            '            Me.dgdBookingValidOrder.Columns.Item("BookingValidOrder_CODE").Visible = Me.smnuDisplayCode.Checked
    '            '        Case "NAME"
    '            '            QueryBookingValidOrder("AND (BookingValidOrder LIKE '" & strFilter & "')")
    '            '            If Me.smnuDisplayName.Checked = False Then
    '            '                Me.smnuDisplayName.Checked = True
    '            '            End If
    '            '            UpdateFrame()
    '            '        Case "TAX"
    '            '            QueryBookingValidOrder("AND (TAX LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayTax.Checked = False Then
    '            '                Me.smnuDisplayTax.Checked = True
    '            '            End If
    '            '            Me.dgdBookingValidOrder.Columns.Item("TAX").Visible = Me.smnuDisplayTax.Checked
    '            '        Case "E-MAIL"
    '            '            QueryBookingValidOrder("AND (EMAIL LIKE '" & strFilter & "') " & mFilter)
    '            '            If Me.smnuDisplayFax.Checked = False Then
    '            '                Me.smnuDisplayFax.Checked = True
    '            '            End If
    '            '            Me.dgdBookingValidOrder.Columns.Item("EMAIL").Visible = Me.smnuDisplayFax.Checked
    '            '    End Select
    '            'Else
    '            '    QueryBookingValidOrder(mFilter)
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub
    Function CheckBookingNo(ByVal BookingNo As String) As Boolean
        Try
            Dim SQL As String
            SQL = " Select Top 1 * from ContainerOutboundNotify Where BookingNO='" & BookingNo.Trim & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function CheckBookingApprove(ByVal BookingNo As String) As Boolean
        Try
            Dim SQL As String
            Dim APValue As String = ""
            Dim Value As String = ""
            Dim ds As New DataSet
            SQL = " Select Top 1 * from ApproveBookingValidOrder Where BookingNO='" & Me.txtBookingNo.Text.Trim & "' And Continued=1 "
            Dim dt As New DataTable
            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count = 0 Then
                Return False
            End If
            ' mac khac lay so value kiem tra voi value moi nhap vao
            APValue = ds.Tables(0).Rows(0).Item("validorder").ToString
            If APValue = "" Then
                Return False
            End If
            Value = Me.txtValidOrder.Text.Trim
            If Value = "" Then
                Return False
            End If
            If CInt(APValue) < CInt(Value) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strBookingValidOrderId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0

        'nếu booking No không có trong cơ sở dữ liệu thì thoát 
        If CheckBookingNo(Me.txtBookingNo.Text.Trim) = False Then
            MsgBox("The Booking No. Not In database, check Again Please")
            Return
        End If
        ' kiem tra xem booking duoc approve hay chua., neu da approve thi kiem tra xem gia tri co dc phep co lon hon gia tri dc appove hay ko

        If CheckBookingApprove(Me.txtBookingNo.Text.Trim) = False Then
            MsgBox("Please check Booking Valid Order.!")
            Return
        End If

        '----------------------
        If mStatus = "Edit" Then
            index = Me.dgdBookingValidOrder.CurrentRow.Index
        End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM BookingValidOrder "
            strQuery = strQuery & "WHERE BookingValidOrderId = '" & mBookingValidOrderID & "' AND BookingValidOrderId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BookingValidOrderId").Value = NewId()
                End If
                strBookingValidOrderId = .Fields("BookingValidOrderId").Value

                .Fields("bookingNo").Value = UCase(Trim(Me.txtBookingNo.Text))
                '.Fields("Code").Value = UCase(Trim(Me.txt.Text))
                '.Fields("Freestorage").Value = Me.txtFreeStorage.Text
                '.Fields("Capacity").Value = UCase(Trim(Me.txtCapacity.Text))
                .Fields("ValidOrder").Value = Me.txtValidOrder.Text
                '.Fields("Country").Value = UCase(Trim(Me.txtCountry.Text))
                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()

            'không cần sắp xếp

            'If mStatus = "Edit" Then
            '    QueryBookingValidOrder(, 1)
            'Else
            '    QueryBookingValidOrder(, 15)
            'End If
            Me.dgdBookingValidOrder.Enabled = True
            'fraUpdate chỉ visible khi thêm hay sửa thành công
            Me.fraUpdate.Visible = False
            ReFormat()
            SetMenu((True))
            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            QueryBookingValidOrder(mFilter, , index)
            mStatus = "Normal"
            blnUpdated = True
            reText(mStatus)
        End If





        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub frmBookingValidOrder_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdBookingValidOrder, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mBookingValidOrderId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        Me.frApproveOrder.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        'LoadComboFind(Me.cboFind, Me.dgdBookingValidOrder)
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

        'Me.cboFind.Text = objUserSetting.GetCParm("frmBookingValidOrder.cboFind", "NAME")
        'mFilter = objUserSetting.GetCParm("frmBookingValidOrder.mFilter")
        'Me.txtBookingNo.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtCODE")
        'Me.TxtBookingValidOrderName.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtBookingValidOrderName")
        'Me.txtTel.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtTel")
        'Me.txtFax.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtFax")
        'Me.txtAddress.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtAddress")
        'Me.txtCountry.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtCountry")

        'Me.txtName5.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtNAME5")
        'Me.txtTax.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtWebsite")
        'Me.txtEmail.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtEmail")
        'Me.txtWebsite.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtWEBSITE")
        'Me.txtRemarks.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtRemarks")
        'Me.txtPersonInCharge.Text = objUserSetting.GetCParm("frmBookingValidOrder.txtPERSONINCHARGE")

        'If Me.txtBookingValidOrder.Text <> "" Then
        '    QueryBookingValidOrder("AND BookingValidOrder LIKE '" & MakeFilter(Me.txtBookingValidOrder.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryBookingValidOrder(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        'Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayName")
        'Me.smnuDisplayCode.Checked = True 'objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayCode")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayFax")
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayAddress")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayaPPROVE")
        'Me.smnuDisplayCountry.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayCountry")

        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmBookingValidOrder.smnuDisplayUpdateTime")
        'UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        'Me.smnuSelect.Enabled = IIf(gSForm = "", False, True)
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmBookingValidOrder_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '    Private Sub frmListVVIP_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        On Error GoTo Err_Renamed
    '        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
    '        objUserSetting.SetCParm("frmBookingValidOrder.cboFind", Me.cboFind.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtBookingValidOrder", Me.txtBookingValidOrder.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtCODE", Me.txtBookingNo.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtBookingValidOrderName", Me.TxtBookingValidOrderName.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtTel", Me.txtTel.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtFax", Me.txtFax.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtAddress", Me.txtAddress.Text)
    '        objUserSetting.SetCParm("frmBookingValidOrder.txtCountry", Me.txtCountry.Text)

    '        objUserSetting.SetCParm("frmBookingValidOrder.mFilter", mFilter)

    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayName", Me.smnuDisplayName.Checked)
    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayCode", Me.smnuDisplayCode.Checked)
    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayTel", Me.smnuDisplayTel.Checked)
    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayFax", Me.smnuDisplayFax.Checked)
    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayAddress", Me.smnuDisplayAddress.Checked)

    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayCountry", Me.smnuDisplayCountry.Checked)

    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
    '        objUserSetting.SetBParm("frmBookingValidOrder.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
    '        Me.cmdCancel_Click(eventSender, eventArgs)
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryBookingValidOrder(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBookingValidOrder = strBookingValidOrderSelect
        ' MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & ", (SELECT count(*) FROM BillOfLading  WHERE BookingValidOrder.BookingValidOrderID = BillOfLading.BookingValidOrderID) AS NumOfTransaction "
        MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & " FROM BookingValidOrder "
        MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & "WHERE (BookingValidOrderID = '" & DefaultValue & "') "

        MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & "OR ("
        MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & "Continued = 1 "
        MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & strBookingValidOrderOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryBookingValidOrder = MakeQueryBookingValidOrder & strBookingValidOrderOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    'Public Function CodeBookingValidOrder() As Integer
    '    Dim rsCount As New ADODB.Recordset
    '    Dim code As Integer
    '    rsCount.Open("select Count(BookingValidOrder_Code) as CountNo from BookingValidOrder", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    code = rsCount.Fields("CountNo").Value
    '    Return code
    'End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmBookingValidOrder", "Add") Then
            'Me.txtBookingNo.Enabled = True
            Me.dgdBookingValidOrder.Enabled = False
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mBookingValidOrderID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtBookingNo.Text = 
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveBookingValidOrder()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdBookingValidOrder.CurrentRow.Index
        Dim strQueryBookingValidOrderList As String
        If Not Me.dgdBookingValidOrder.Item("Editable", index).Value Or Not UserRight("frmBookingValidOrder", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Pgải Đựơc Cầp Quyền"))
            QueryBookingValidOrder(mFilter, , index)
        Else
            strQueryBookingValidOrderList = "Select * from BookingValidOrder where" + " BookingValidOrderID= '" & Me.dgdBookingValidOrder.Item("BookingValidOrderID", index).Value.ToString & "'"
            rsBookingValidOrderList.Open(strQueryBookingValidOrderList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsBookingValidOrderList.Fields("Approve").Value
            rsBookingValidOrderList.Update("Approve", Approve)
            rsBookingValidOrderList.Close()
        End If
        QueryBookingValidOrder(mFilter, , index)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE BookingValidOrderID = '" & Me.dgdBookingValidOrder.Item("BookingValidOrderID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from BookingValidOrder WHERE BookingValidOrderId = '" & Me.dgdBookingValidOrder.Item("BookingValidOrderId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The BookingValidOrder can not be removed.", "Cảng Này Không Thể Xoá"))
            Exit Sub
        End If
        'chư có ràng buộc
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The BookingValidOrder can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdBookingValidOrder.Item("Approve", index)) Then
            If Me.dgdBookingValidOrder.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdBookingValidOrder.Item("Editable", index)) Then
            If Not Me.dgdBookingValidOrder.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmBookingValidOrder", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
        Else
            strMesg = "Delete the BookingValidOrder: " & Me.dgdBookingValidOrder.Item("BookingNo", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from BookingValidOrder where" + " BookingValidOrderID= '" & Me.dgdBookingValidOrder.Item("BookingValidOrderID", index).Value.ToString & "'"
                rsBookingValidOrderList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsBookingValidOrderList.Fields("continued").Value = 0
                rsBookingValidOrderList.Update()

                rsBookingValidOrderList.Requery()
                Me.dgdBookingValidOrder.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdBookingValidOrder.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsBookingValidOrderList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdBookingValidOrder.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdBookingValidOrder.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryBookingValidOrder(mFilter)
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

        If Me.dgdBookingValidOrder.RowCount = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
            Return
        End If
        Dim index As Integer = Me.dgdBookingValidOrder.CurrentRow.Index

        If index >= 0 Then
            Approve = Me.dgdBookingValidOrder.Item("Approve", index).Value
            EditTable = Me.dgdBookingValidOrder.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmBookingValidOrder", "Edit") And Not Me.dgdBookingValidOrder.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdBookingValidOrder.Height = 306
                Me.dgdBookingValidOrder.Enabled = False
                'Me.txtBookingNo.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mBookingValidOrderID = Me.dgdBookingValidOrder.Item("BookingValidOrderId", index).Value.ToString
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
            Me.Text = "Booking ValidOrder "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Booking ValidOrder -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Booking ValidOrder -> Add."
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

    Private Sub QueryBookingValidOrder(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryBookingValidOrder()
        Else
            strQuery = MakeQueryBookingValidOrder(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "BookingValidOrderList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdBookingValidOrder.DataSource = ds.Tables("BookingValidOrderList")
        If Me.dgdBookingValidOrder.Enabled = False Then
            Me.dgdBookingValidOrder.Enabled = True
        End If

        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdBookingValidOrder.Columns.Item("BookingNo").ToolTipText = "Hiện có:" + CStr(Me.dgdBookingValidOrder.RowCount()) + " BookingValidOrders."
        End If
        If Me.dgdBookingValidOrder.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdBookingValidOrder.Rows.Count And Me.dgdBookingValidOrder.Rows.Count > 0 Then
            Me.dgdBookingValidOrder.Rows(location).Selected = True
            Me.dgdBookingValidOrder.CurrentCell = Me.dgdBookingValidOrder.Rows(location).Cells("BookingNo")
        End If
        InsertAutoNumberToGrid(Me.dgdBookingValidOrder)
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

    '        Me.dgdBookingValidOrder.Columns.Item("BookingValidOrderID").Visible = False
    '        Me.dgdBookingValidOrder.Columns.Item("BookingValidOrder_Code").Visible = True  'Me.smnuDisplayCode.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("BookingValidOrder").Visible = Me.smnuDisplayName.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked

    '        Me.dgdBookingValidOrder.Columns.Item("Editable").Visible = False
    '        Me.dgdBookingValidOrder.Columns.Item("Continued").Visible = False
    '        Me.dgdBookingValidOrder.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("Country").Visible = Me.smnuDisplayCountry.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdBookingValidOrder.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        dgdBookingValidOrder.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdBookingValidOrder.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdBookingValidOrder.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdBookingValidOrder.Height + dgdBookingValidOrder.Top '+ 100

        'Me.txtBookingValidOrder.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'Me.txtName1.Width = Me.fraUpdate.Width - Me.txtName1.Left - 10
        cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        cmdOk.Left = cmdCancel.Left - cmdOk.Width - 10
        'cmdFind.Left = Me.txtBookingValidOrder.Left + Me.txtBookingValidOrder.Width + 10
        'txtBookingValidOrder.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdBookingValidOrder_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBookingValidOrder.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdBookingValidOrder.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdBookingValidOrder.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.dgdBookingValidOrder.Columns(ColIndex).Name) = "APPROVE" And Me.dgdBookingValidOrder.CurrentCellAddress().Y = index Then
            Call ApproveBookingValidOrder()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdBookingValidOrder_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBookingValidOrder.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryBookingValidOrder("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdBookingValidOrder)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdBookingValidOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdBookingValidOrder.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdBookingValidOrder.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdBookingValidOrder.SelectedRows(i).Index)
                Next i
            End If

            QueryBookingValidOrder()
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
        Me.txtBookingNo.Text = Me.dgdBookingValidOrder.Item("BookingNo", index).Value.ToString
        'Me.txt.Text = Me.dgdBookingValidOrder.Item("BookingNo", index).Value.ToString
        'Me.txtCapacity.Text = Me.dgdBookingValidOrder.Item("Capacity", index).Value.ToString
        'Me.txtFreeStorage.Text = Me.dgdBookingValidOrder.Item("FreeStorage", index).Value.ToString
        Me.txtValidOrder.Text = Me.dgdBookingValidOrder.Item("ValidOrder", index).Value.ToString


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    'Private Sub smnuDisplayTel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayTel.Click
    '    Me.smnuDisplayTel.Checked = Not Me.smnuDisplayTel.Checked
    '    UpdateFrame()
    'End Sub

    Private Sub frmBookingValidOrder_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub


    '    Private Sub CopyFromExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyFromExcelToolStripMenuItem.Click
    '        On Error GoTo Err_Renamed
    '        Dim strQuery, strQuery1, strBookingValidOrderId, pName As String
    '        Dim rs As New ADODB.Recordset
    '        Dim rs1 As New ADODB.Recordset

    '        strQuery = "SELECT * "
    '        strQuery = strQuery & "FROM tscode "
    '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

    '        strQuery1 = "SELECT * "
    '        strQuery1 = strQuery1 & "FROM BookingValidOrder "
    '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '        While Not rs.EOF
    '            With rs1
    '                .AddNew()
    '                .Fields("BookingValidOrderID").Value = NewId()
    '                .Fields("BookingValidOrder_Code").Value = Trim(UCase(rs.Fields("tscode").Value))
    '                .Fields("BookingValidOrder").Value = UCase(Trim(rs.Fields("BookingValidOrdername").Value))
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
    '        '    QueryBookingValidOrder(, 1)
    '        'Else
    '        '    QueryBookingValidOrder(, 15)
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
                QueryBookingValidOrder("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            If Me.dgdBookingValidOrder.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdBookingValidOrder, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

  
    Private Sub txtBookingNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBookingNo.TextChanged

    End Sub

    Private Sub cmdOKApproveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKApproveOrder.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strApproveBookingValidOrderId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0

        'nếu booking No không có trong cơ sở dữ liệu thì thoát 
        If CheckBookingNo(Me.txtBookingNoAP.Text.Trim) = False Then
            MsgBox("The Booking No. Not In database, check Again Please")
            Return
        End If

        strQuery = "SELECT * "
        strQuery = strQuery & "FROM ApproveBookingValidOrder "
        strQuery = strQuery & "WHERE bookingno = '" & Me.txtBookingNoAP.Text.Trim & "' and continued=1 "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        With rs
            If rs.EOF Then
                .AddNew()
                .Fields("ApproveBookingValidOrderId").Value = NewId()
            End If
            strApproveBookingValidOrderId = .Fields("ApproveBookingValidOrderId").Value
            .Fields("bookingNo").Value = UCase(Trim(Me.txtBookingNoAP.Text.Trim))
            .Fields("ValidOrder").Value = Me.txtValidOrderAP.Text
            .Update()
            DisplayMessage(True, "Saving is OK!")
        End With
        rs.Close()


        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub txtBookingNoAP_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookingNoAP.Leave
        On Error GoTo Err_Renamed
        Dim strQuery As String
        Dim rs As New ADODB.Recordset


        'nếu booking No không có trong cơ sở dữ liệu thì thoát 
        If CheckBookingNo(Me.txtBookingNoAP.Text.Trim) = False Then
            MsgBox("The Booking No. Not In database, check Again Please")
            Return
        End If

        strQuery = "SELECT * "
        strQuery = strQuery & "FROM approvebookingvalidorder "
        strQuery = strQuery & "WHERE BookingNO = '" & Me.txtBookingNoAP.Text.Trim & "' and continued=1 "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            mApproveBookingValidOrderID = rs.Fields("ApproveBookingValidOrderId").Value
            Me.txtValidOrderAP.Text = rs.Fields("ValidOrder").Value
        End If
        rs.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub txtBookingNoAP_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBookingNoAP.TextChanged
        ''kiem tra xem co booking trong table hay khong, neu co thi lay ID va lay ra so ngay validorder
        On Error GoTo Err_Renamed
        'Dim strQuery As String
        'Dim rs As New ADODB.Recordset


        ''nếu booking No không có trong cơ sở dữ liệu thì thoát 
        'If CheckBookingNo(Me.txtBookingNoAP.Text.Trim) = False Then
        '    MsgBox("The Booking No. Not In database, check Again Please")
        '    Return
        'End If

        'strQuery = "SELECT * "
        'strQuery = strQuery & "FROM approvebookingvalidorder "
        'strQuery = strQuery & "WHERE BookingNO = '" & Me.txtBookingNoAP.Text.Trim & "' and continued=1 "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'If Not rs.EOF Then
        '    mApproveBookingValidOrderID = rs.Fields("ApproveBookingValidOrderId").Value
        '    Me.txtValidOrderAP.Text = rs.Fields("ValidOrder").Value
        'End If
        'rs.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub mnuApproveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuApproveOrder.Click
        ' kiem tra quyen han mo valid order
        If gDepartment <> "Management" Then
            DisplayMessage(True, "Please check permission!")
            Return
        End If
        '-------------------------------
        Me.txtBookingNoAP.Text = ""
        Me.txtValidOrderAP.Text = ""
        Me.frApproveOrder.Visible = True
        Me.frApproveOrder.BringToFront()
    End Sub

    Private Sub cmdCancelApproveOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelApproveOrder.Click
        Me.frApproveOrder.Visible = False
    End Sub
End Class