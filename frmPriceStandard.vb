Public Class frmPriceStandard
    Dim MarketLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsListPriceStandard As New ADODB.Recordset
    Public mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mPriceStandard_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strMarketSelect As String = "SELECT shippingline," & _
    "PriceStandard.PriceStandard_ID, " & _
    "PriceStandard.Port_ID, " & _
    "port.Port_Code , Port.MARKETCODETS as MarketCodeTS,Port.MARKETCODESALE as MarketCodeSale," & _
    "PriceStandard.POL_ID, " & _
    " (select port_code from port where Port_ID = POL_ID) as POL_Code , " & _
    "charge.Charge_ID, " & _
    "charge.Charge_Code , " & _
    "PriceStandard.CTN_TYPE , " & _
    "PriceStandard.Prepaid_Collect, " & _
    "PriceStandard.Price, " & _
    "PriceStandard.Currency, ApplyDate,ExpireDate ,Salename , " & _
    "PriceStandard.Approve, " & _
    "PriceStandard.Continued, " & _
    "PriceStandard.Editable, " & _
    "PriceStandard.UserId, " & _
    "PriceStandard.updatetime "

    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim Msg As String
        Dim strQuery As String
        CheckData = True
        Msg = ""
        Dim strMarket_ID As String

        If IsNumeric(Me.txtMoney.Text.Trim) = False Then
            Msg &= "The money is invalid"
        End If
        If FindValueID(Me.cboPort, Me.cboPort.Text.Trim) = "" Then
            Msg &= "The port is invalid"
        End If
        If FindValueID(Me.cboItems, Me.cboItems.Text.Trim) = "" Then
            Msg &= "The Items is invalid"
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If

        Dim tbl As New DataTable
        Dim strSql As String = "Select Count(*) as cnt From PriceStandard " & _
                               "Where Port_ID='" & FindValueID(Me.cboPort, Me.cboPort.Text.Trim) & "' " & _
                               " and Charge_ID='" & FindValueID(Me.cboItems, Me.cboItems.Text.Trim) & "' " & _
                               " and CTN_TYPE='" & Me.cboContainerType.Text.Trim & "' "
        tbl = ReadTable(strSql)
        If tbl.Rows(0).Item("cnt") > 0 And mStatus = "Add" Then
            Msg &= "Đã tồn tại"
        End If
        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtMarket.Text)
        If Me.txtMarket.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtMarket.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdPriceStandard)
            '    Select Case Me.cboFind.Text
            '        Case "Port"
            '            QueryPriceStandard(" AND Port.Port_Code LIKE '%" & strFilter & "%' ")
            '        Case "Items"
            '            QueryPriceStandard(" AND Charge.Charge_Code LIKE '%" & strFilter & "%' ")
            '    End Select
            'Else
            '    QueryPriceStandard(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListPriceStandard_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mPriceStandard_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdPriceStandard)
        SetDefaultGrid(Me.dgdPriceStandard, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Port", "Port")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Items", "Items")
        'Me.cboFind.Items.Add(oItems)


        'Me.cboFind.Text = objUserSetting.GetCParm("frmListPriceStandard.cboFind", "Market")
        mFilter = objUserSetting.GetCParm("frmListPriceStandard.mFilter")

        'If Me.txtMarket.Text <> "" Then
        '    QueryPriceStandard("AND Port.Port LIKE '" & MakeFilter(Me.txtMarket.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryPriceStandard(mFilter, , 15)
        'End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListPriceStandard.smnuDisplayAPPROVE")
        Me.smnuDisplayMarket.Checked = objUserSetting.GetBParm("frmListPriceStandard.smnuDisplayMarket")


        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListPriceStandard.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListPriceStandard.smnuDisplayUpdateTime")

        UpdateFrame()
        QueryCombo()
        Me.cboCurrency.SelectedIndex = 0
        Me.cboContainerType.SelectedIndex = 0
        Me.cboPrepaidCollect.SelectedIndex = 0

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListPriceStandard_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmListPriceStandard.cboFind", Me.cboFind.Text)

        objUserSetting.SetCParm("frmListPriceStandard.txtMarket", Me.txtMarket.Text)



        objUserSetting.SetCParm("frmListPriceStandard.mFilter", mFilter)

        objUserSetting.SetBParm("frmListPriceStandard.smnuDisplayMarket", Me.smnuDisplayMarket.Checked)
        objUserSetting.SetBParm("frmListPriceStandard.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        objUserSetting.SetBParm("frmListPriceStandard.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmListPriceStandard.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(eventSender, eventArgs)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Function GETSALECODE(ByVal USERNAME As String) As String

        Dim strQuery, _SALECODE As String
        Dim RSSALECODE As New ADODB.Recordset
        strQuery = "SELECT SALECODE FROM SALE WHERE USR='" & USERNAME & "'"
        RSSALECODE.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not RSSALECODE.EOF Then
            _SaleCode = RSSALECODE.Fields("SALECODE").Value.ToString
        Else
            _SALECODE = ""
        End If
        RSSALECODE.Close()
        Return _SALECODE
    End Function
    '==========MakeQuery==========

    Private Function MakeQueryPriceStandard(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryPriceStandard = strMarketSelect
        MakeQueryPriceStandard = MakeQueryPriceStandard & "From (PriceStandard INNER JOIN Port ON PriceStandard.Port_ID=port.Port_ID) " & _
                                            "INNER JOIN Charge ON PriceStandard.Charge_ID=Charge.Charge_ID "
        MakeQueryPriceStandard = MakeQueryPriceStandard & " WHERE (PriceStandard_ID <> '" & DefaultValue & "') "

        'MakeQueryPriceStandard = MakeQueryPriceStandard & "and ("
        MakeQueryPriceStandard = MakeQueryPriceStandard & " and PriceStandard.Continued = 1 "
        'MakeQueryPriceStandard = MakeQueryPriceStandard & ")) and (getdate() between ApplyDate and ExpireDate) " 'and PriceStandard.updatetime =(select max(p.updatetime) from PriceStandard P inner join PriceStandard on PriceStandard.PriceStandard_id=p.PriceStandard_id where p.PriceStandard_id=PriceStandard.PriceStandard_id ) "
        ' lay so lieu tu Option
        Dim strQuery, value As String
        Dim rs As New ADODB.Recordset
        value = "0"
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM [option] "
        strQuery = strQuery & "WHERE frmName = 'frmPriceStandard' and OptionCode='PermissionView' And Continued=1 "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        With rs
            If Not rs.EOF Then
                value = .Fields("optionvalue").Value
            End If

        End With
        rs.Close()
        '---------------------------------
        If value = "1" Then
            If UCase(gDepartment) <> "MANAGEMENT" Then
                MakeQueryPriceStandard = MakeQueryPriceStandard & " And salename='" & GETSALECODE(strUserId).Trim & "' "
            End If
        End If
        '---------------------------------------
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryPriceStandard = MakeQueryPriceStandard & argCriteria
        End If
        MakeQueryPriceStandard = MakeQueryPriceStandard & "  order by PriceStandard.updatetime "
        'If index = 1 Then ' 
        '    MakeQueryPriceStandard = MakeQueryPriceStandard & strMarketOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryPriceStandard = MakeQueryPriceStandard & strMarketOrder2
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
        If mStatus = "Normal" And UserRight("frmPriceStandard", "Add") Then


            frmInsertSaleSurcharge.mStatus = "Add"
            frmInsertSaleSurcharge.ShowDialog()
            'Me.txtMarket.Enabled = True
            'Me.fraUpdate.Visible = True
            'Me.dgdPriceStandard.Enabled = False
            'ReFormat()
            'SetMenu((False))
            'mPriceStandard_ID = DefaultValue
            '
            'reText(mStatus)
            'Me.txtMarket.Text = Me.txtMarket.Text
            'Me.cboPort.Enabled = True
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApprovePrice()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdPriceStandard.CurrentRow.Index
        Dim strSql As String
        Dim rs As New ADODB.Recordset
        If Not Me.dgdPriceStandard.Item("Editable", index).Value Or Not UserRight("frmPriceStandard", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryPriceStandard(, , index)
        Else
            strSql = "Select * from PriceStandard where" + " PriceStandard_ID= '" & dgdPriceStandard.Item("PriceStandard_ID", index).Value.ToString & "'"
            rs.Open(strSql, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryPriceStandard()
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
        strQuery = "Select * from PriceStandard WHERE PriceStandard_ID = '" & Me.dgdPriceStandard.Item("PriceStandard_ID", index).Value.ToString & "' And UserId='DBO'"
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

        If Not IsNothing(Me.dgdPriceStandard.Item("Approve", index)) Then
            If Me.dgdPriceStandard.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdPriceStandard.Item("Editable", index)) Then
            If Not Me.dgdPriceStandard.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmPriceStandard", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
           
            strQueryCommodityList = "Select * from PriceStandard where" + " PriceStandard_ID= '" & Me.dgdPriceStandard.Item("PriceStandard_ID", index).Value.ToString & "'"
            rsListPriceStandard.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rsListPriceStandard.Fields("continued").Value = 0
            rsListPriceStandard.Update()
            rsListPriceStandard.Requery()
            Me.dgdPriceStandard.Rows(index).DefaultCellStyle.ForeColor = Color.White
            Me.dgdPriceStandard.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            rsListPriceStandard.Close()
            blnUpdated = True

        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdPriceStandard.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdPriceStandard.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryPriceStandard(" " + mFilter)
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
        If Me.oTable.Rows.Count > 0 Then
            index = Me.dgdPriceStandard.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            Approve = Me.dgdPriceStandard.Item("Approve", index).Value
            EditTable = Me.dgdPriceStandard.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmPriceStandard", "Edit") And Not Me.dgdPriceStandard.Rows(index).DefaultCellStyle.ForeColor = Color.White Then

                frmInsertSaleSurcharge.mStatus = "Edit"

                frmInsertSaleSurcharge.ShowDialog()
                'Me.dgdPriceStandard.Height = 306
                '' Me.txtMarketCode.Enabled = False
                'Me.dgdPriceStandard.Enabled = True
                'Me.fraUpdate.Visible = True
                'ReFormat()
                'SetMenu((False))
                'mPriceStandard_ID = Me.dgdPriceStandard.Item("PriceStandard_ID", index).Value.ToString
                'mStatus = "Edit"
                'reText(mStatus)
                'RefreshData(index)

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
            Me.Text = "List Of Price Standard"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Price Standard  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Price Standard -> Add."
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

    Public Sub QueryPriceStandard(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryPriceStandard()
        Else
            strQuery = MakeQueryPriceStandard(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "ListPriceStandard")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdPriceStandard.DataSource = ds.Tables("ListPriceStandard")
        If Me.dgdPriceStandard.Enabled = False Then
            Me.dgdPriceStandard.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdPriceStandard.Columns.Item("Port").ToolTipText = "Hiện có:" + CStr(Me.dgdPriceStandard.RowCount()) + " Price Standard."
        End If
        If Me.dgdPriceStandard.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdPriceStandard.Rows.Count And Me.dgdPriceStandard.Rows.Count > 0 Then
            Me.dgdPriceStandard.Rows(location).Selected = True
            Me.dgdPriceStandard.CurrentCell = Me.dgdPriceStandard.Rows(location).Cells(2)
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdPriceStandard)
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

        Me.dgdPriceStandard.Columns.Item("PriceStandard_ID").Visible = False
        Me.dgdPriceStandard.Columns.Item("Charge").Visible = Me.smnuDisplayMarket.Checked
        Me.dgdPriceStandard.Columns.Item("Editable").Visible = False
        Me.dgdPriceStandard.Columns.Item("Continued").Visible = False
        Me.dgdPriceStandard.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        Me.dgdPriceStandard.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdPriceStandard.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdPriceStandard.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdPriceStandard.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdPriceStandard.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdPriceStandard.Height + dgdPriceStandard.Top

        Me.txtMarket.Width = Me.Width - 300

        'cmdCancel.Left = Me.fraUpdate.Width / 2 - cmdCancel.Width + 30
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        cmdFind.Left = Me.txtMarket.Left + Me.txtMarket.Width + 10
        txtMarket.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdMarket_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPriceStandard.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdPriceStandard.RowCount = 0 Then
            Return
        End If
        index = Me.dgdPriceStandard.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPriceStandard.Columns(ColIndex).Name = "Approve" And Me.dgdPriceStandard.CurrentCellAddress().Y = index Then
            Call ApprovePrice()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdMarket_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdPriceStandard.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryPriceStandard("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdPriceStandard)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdMarket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdPriceStandard.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdPriceStandard.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdPriceStandard.SelectedRows(i).Index)
                Next i
            End If

            QueryPriceStandard()
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
        Me.cboPOL.Text = FindIDValue(Me.cboPOL, Me.dgdPriceStandard.Item("POL_ID", index).Value.ToString)
        Me.cboPort.Text = FindIDValue(Me.cboPort, Me.dgdPriceStandard.Item("Port_ID", index).Value.ToString)
        Me.cboItems.Text = FindIDValue(Me.cboItems, Me.dgdPriceStandard.Item("Charge_ID", index).Value.ToString)
        Me.cboCurrency.Text = Me.dgdPriceStandard.Item("Currency", index).Value
        Me.cboContainerType.Text = Me.dgdPriceStandard.Item("CTN_TYPE", index).Value
        Me.cboPrepaidCollect.Text = Me.dgdPriceStandard.Item("PrepaidCollect", index).Value
        Me.txtMoney.Text = FormatString(Me.dgdPriceStandard.Item("Money", index).Value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub frmListPriceStandard_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strMarket_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.oTable.Rows.Count > 0) Then
            index = Me.dgdPriceStandard.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM PriceStandard "
            strQuery = strQuery & "WHERE PriceStandard_ID = '" & mPriceStandard_ID & "' AND PriceStandard_ID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("PriceStandard_ID").Value = NewId()
                    mFilter = " And PriceStandard.PriceStandard_ID=" & .Fields("PriceStandard_ID").Value & "'"
                End If
                .Fields("POL_ID").Value = "{" & FindValueID(Me.cboPOL, Me.cboPOL.Text.Trim) & "}"
                .Fields("Port_ID").Value = "{" & FindValueID(Me.cboPort, Me.cboPort.Text.Trim) & "}"
                .Fields("Charge_ID").Value = "{" & FindValueID(Me.cboItems, Me.cboItems.Text.Trim) & "}"
                .Fields("CTN_TYPE").Value = Me.cboContainerType.Text.Trim
                .Fields("Prepaid_Collect").Value = Me.cboPrepaidCollect.Text.Trim
                .Fields("Currency").Value = Me.cboCurrency.Text.Trim
                .Fields("Price").Value = CDbl(Me.txtMoney.Text.Trim)

                .Update()

            End With
            rs.Close()
            Me.dgdPriceStandard.Enabled = True
            If mStatus = "Edit" Then
                QueryPriceStandard(, 1, index)
            Else
                QueryPriceStandard(, 15, index)
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
        Me.dgdPriceStandard.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryCombo()
        On Error GoTo Err_Renamed
        Dim id As String
        Dim value As String
        Dim strSQL As String

        id = "Port_ID"
        value = "Port_Code"
        strSQL = "Select Port_ID,Port_Code From PORT where Continued=1 Order By Port_Code asc"
        loadDataToObject(Me.cboPort, strSQL, id, value)

        'strSQL = "Select Port_ID,Port_Code From PORT where Continued=1 Order By Port_Code asc"
        loadDataToObject(Me.cboPOL, strSQL, id, value)

        id = "CHARGE_ID"
        value = "CHARGE_CODE"
        Dim strQuery As String = "Select CHARGE_ID,CHARGE_CODE from CHARGE where CONTINUED=1 order by Charge_code"
        loadDataToObject(Me.cboItems, strQuery, id, value)
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
                QueryPriceStandard("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdPriceStandard.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdPriceStandard, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub txtMarket_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMarket.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub fraUpdate_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fraUpdate.Enter

    End Sub
End Class