Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmListAgency
    Inherits System.Windows.Forms.Form
    Dim rsAgencyList As New ADODB.Recordset
    Dim mStatus, mFilter, mCommondityStatus, mPICStatus As String
    Public blnUpdated As Boolean
    Public mAgency_Id As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Dim oTableMarket, oTablePIC, oTableCommondity As New DataTable

    Const strDateOfAgencySelect As String = "SELECT * "

    Const strDateOfAgencyOrder1 As String = _
           " ORDER BY Agency_Code  Desc "
    Const strDateOfAgencyOrder2 As String = _
        " ORDER BY UpdateTime Desc "


    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtAgency.Text)
        If Me.txtAgency.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtAgency.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdAgency)
            '    Select Case Me.cboFind.Text
            '        Case "Agency"
            '            QueryAgency("AND ( AgencyName LIKE '" & strFilter & "') " & mFilter)
            '            'Me.dgdAgency.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
            '            'Case "Company"
            '            '    QueryAgency("AND (Company LIKE '" & strFilter & "')" & mFilter)
            '            '    UpdateFrame()
            '    End Select
            'Else
            '    QueryAgency(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListAgency_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.cmdCancel_Click(sender, e)
    End Sub

    Private Sub frmListAgency_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mCommondityStatus = "Normal"
        mPICStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdAgency, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdPIC, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'mAgency_Id = DefaultValue
        'If UCase(gDepartment.Trim) = "BOOKING" Then
        '    QuyenHan = "BOOKING"
        'ElseIf UCase(gDepartment = "SALE") Then
        '    QuyenHan = UCase(strUserId.Trim)
        'Else
        '    QuyenHan = "Nothing"
        'End If
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Me.fraUpdate1.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdAgency)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Agency", "Agency")
        'Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListAgency.cboFind", "DateOfAgency")
        mFilter = objUserSetting.GetCParm("frmListAgency.mFilter")
        ' Me.txtAgency_Code.Text = objUserSetting.GetCParm("frmListAgency.txtAgency_Code")

        'If Me.txtAgency.Text <> "" Then
        '    QueryAgency("AND Agency_Code LIKE '" & MakeFilter(Me.txtCompany.Text) & "' " & mFilter, , 15)
        'Else
        '    QueryAgency(mFilter, , 15)
        'End If
        QueryAgency()
        'QueryCommondity()
        'QueryMarket()
        'QueryPIC()
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If
        'Me.smnuDisplayAddress.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayAdress")
        'Me.smnuDisplayTel.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayTel")
        'Me.smnuDisplayFax.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayFax")
        'Me.smnuDisplayATTN.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayATTN")
        'Me.smnuDisplayEmail.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayEmail")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayAPPROVE")
        'Me.smnuDisplayCompany.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayCompany")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListAgency.smnuDisplayUpdateTime")
        Me.fraUpdate.Visible = False

        ReFormat()

        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
        Me.TabPage1.BackColor = gMauFra
        Me.TabPage2.BackColor = gMauFra
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListAgency_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        ' ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Function MakeQueryAgency(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryAgency = "select agency_id,AgencyName,address,city,country,email,website,pic_,ass,skype,yahoo,editable,approve,continued "
        MakeQueryAgency = MakeQueryAgency & "From Agency"
        MakeQueryAgency = MakeQueryAgency & " WHERE (Agency_Id = '" & DefaultValue & "') "

        MakeQueryAgency = MakeQueryAgency & "OR ("
        MakeQueryAgency = MakeQueryAgency & "Continued = 1 "
        MakeQueryAgency = MakeQueryAgency & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryAgency = MakeQueryAgency & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryAgency = MakeQueryAgency & strDateOfAgencyOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryAgency = MakeQueryAgency & strDateOfAgencyOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListAgency", "Add") Then
            Me.txtAgency.Enabled = True
            'Me.txtAgency_Code.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdAgency.Enabled = False
            ReFormat()
            SetMenu((False))
            mAgency_Id = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            'Me.txtAgency.Text = Me.txtAgency.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryAgencyPIC()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select PICAgency_ID,PIC,Pos,DirectLine,AgencyName,PICAgency.Editable,PICAgency.continued,PICAgency.Approve,PICAgency.userid,PICAgency.Updatetime "
            strSQL &= " From (PICAgency LEFT JOIN Agency on Agency.Agency_ID=PICAgency.Agency_ID) "
            strSQL &= " Where PICAgency.continued=1 And PICAgency.Agency_ID='" & mAgency_Id & "'"
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If Not IsNothing(oTablePIC) Then
                oTablePIC.Clear()
            End If
            Adapter.Fill(oTablePIC)
            Me.dgdPIC.DataSource = oTablePIC
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ApproveAgency()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdAgency.CurrentRow.Index
        Dim strQueryAgencyList As String
        If Not Me.dgdAgency.Item("Editable", index).Value Or Not UserRight("frmListAgency", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryAgency(mFilter, , index)
        Else
            strQueryAgencyList = "Select * from Agency where" + " Agency_Id= '" & dgdAgency.Item("Agency_Id", index).Value.ToString & "'"
            rsAgencyList.Open(strQueryAgencyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsAgencyList.Fields("Approve").Value
            rsAgencyList.Update("Approve", Approve)
            rsAgencyList.Close()
        End If
        QueryAgency(mFilter, , index)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveAgencyP()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdPIC.CurrentRow.Index
        Dim strQueryAgencyList As String
        If Not Me.dgdPIC.Item("EditableP", index).Value Or Not UserRight("frmListAgency", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryAgencyPIC()
        Else
            strQueryAgencyList = "Select * from PICAGENCY where" + " PICAgency_ID= '" & dgdPIC.Item("PICAgency_ID", index).Value.ToString & "'"
            rsAgencyList.Open(strQueryAgencyList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsAgencyList.Fields("Approve").Value
            rsAgencyList.Update("Approve", Approve)
            rsAgencyList.Close()
        End If
        QueryAgencyPIC()
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

        'strQuery = "Select count(*) cnt from CONTAINEROUTBOUNDNOTIFY WHERE Agency_Id = '" & Me.dgdAgency.Item("Agency_Id", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        'strQuery = "Select * from Agency WHERE Agency_Id = '" & Me.dgdAgency.Item("Agency_Id", index).Value.ToString & "' And UserId='DBO'"
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEOF = rs.EOF
        'rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, The Agency can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
        '    Exit Sub
        'End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Agency can not be removed. There are transactions that relate to this Agency.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdAgency.Item("Approve", index).Value) Then
            If Me.dgdAgency.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdAgency.Item("Editable", index).Value) Then
            If Not Me.dgdAgency.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListAgency", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Agency : " & Me.dgdAgency.Item("AgencyName", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Agency where" + " Agency_Id= '" & Me.dgdAgency.Item("Agency_Id", index).Value.ToString & "'"
                rsAgencyList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsAgencyList.Fields("continued").Value = 0
                rsAgencyList.Update()
                rsAgencyList.Requery()
                Me.dgdAgency.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdAgency.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsAgencyList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdAgency.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdAgency.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryAgency(mFilter)
    End Sub


#Region "Xuly"
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean

        Dim index As Integer = Me.dgdAgency.CurrentRow.Index
        If index >= 0 Then

            Approve = Me.dgdAgency.Item("Approve", index).Value
            EditTable = Me.dgdAgency.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable Then
                Me.dgdAgency.Height = 306
                'Me.txtAgency_Code.Enabled = False
                Me.dgdAgency.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mAgency_Id = Me.dgdAgency.Item("Agency_Id", index).Value.ToString
                SetPicItem(False)
                ' SetCommondityItem(False)
                'QueryAgencyMarket()
                'QueryAgencyCommondity()
                QueryAgencyPIC()
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
            Me.Text = "List Of Agency"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Agency  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Agency -> Add."
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

    Private Sub QueryAgency(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryAgency()
        Else
            strQuery = MakeQueryAgency(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "AgencyList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdAgency.DataSource = ds.Tables("AgencyList")
        If Me.dgdAgency.Enabled = False Then
            Me.dgdAgency.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdAgency.Columns.Item("Agencyname").ToolTipText = "Hiện có:" + CStr(Me.dgdAgency.RowCount()) + " Agencys."
        End If
        If Me.dgdAgency.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdAgency.Rows.Count And Me.dgdAgency.Rows.Count > 0 Then
            Me.dgdAgency.Rows(location).Selected = True
            Me.dgdAgency.CurrentCell = Me.dgdAgency.Rows(location).Cells(3)
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdAgency)
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

    '        Me.dgdAgency.Columns.Item("Address").Visible = Me.smnuDisplayAddress.Checked
    '        Me.dgdAgency.Columns.Item("ATTN").Visible = Me.smnuDisplayATTN.Checked
    '        Me.dgdAgency.Columns.Item("Email").Visible = Me.smnuDisplayEmail.Checked
    '        Me.dgdAgency.Columns.Item("Tel").Visible = Me.smnuDisplayTel.Checked
    '        Me.dgdAgency.Columns.Item("Fax").Visible = Me.smnuDisplayFax.Checked

    '        Me.dgdAgency.Columns.Item("Agency_Id").Visible = False
    '        Me.dgdAgency.Columns.Item("Company").Visible = Me.smnuDisplayCompany.Checked

    '        Me.dgdAgency.Columns.Item("Editable").Visible = False
    '        Me.dgdAgency.Columns.Item("Continued").Visible = False
    '        Me.dgdAgency.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

    '        Me.dgdAgency.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
    '        Me.dgdAgency.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    Private Sub ReFormat()
        On Error GoTo Err
        If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub

        Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
        Me.Left = 0
        Me.Height = frmMain.Height - Me.Top - 10
        Me.Width = frmMain.Width - 8
        dgdAgency.Width = (Me.Width - 30)
        Me.fraUpdate.Width = Me.dgdAgency.Width
        If Me.Width > 610 Then
            dgdAgency.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 50, 40) '> 7000
        Else
            dgdAgency.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        'fraUpdate1.Width = (Me.Width - 30)
        fraUpdate.Top = dgdAgency.Height + dgdAgency.Top

        '       Me.txtAgency.Width = Me.Width - 300

        cmdOK.Top = Me.GroupBox1.Bottom + 5
        cmdCancel.Top = cmdOK.Top

        ' cmdFind.Left = Me.txtAgency.Left + Me.txtAgency.Width + 10
        '    txtAgency.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdAgency_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdAgency.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If Me.dgdAgency.Rows.Count = 0 Then
            Return
        End If
        index = Me.dgdAgency.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If Me.dgdAgency.CurrentCellAddress.X = 8 And Me.dgdAgency.CurrentCellAddress().Y = index Then
            Call ApproveAgency()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdAgency_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdAgency.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdAgency)
    End Sub


    Private Sub dgdAgency_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdAgency.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdAgency.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdAgency.SelectedRows(i).Index)
                Next i
            End If

            QueryAgency(mFilter)
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
        Dim sql As String
        Dim ds As New DataSet
        sql = " select * from agency where agency_id='" & mAgency_Id & "' and continued=1"

        ds = ReadDataSet(sql)

        Me.txtAgencyName.Text = ds.Tables(0).Rows(0).Item("AgencyName").ToString




        Me.txtAddress.Text = ds.Tables(0).Rows(0).Item("Address").ToString 'Me.dgdAgency.Item("Address", index).Value.ToString

        Me.txtCity.Text = ds.Tables(0).Rows(0).Item("city").ToString




        ' Me.txtAddress.Text = Me.dgdAgency.Item("Address", index).Value.ToString
        'Me.txtTel.Text = Me.dgdAgency.Item("Tel", index).Value.ToString
        'Me.txtFax.Text = Me.dgdAgency.Item("Fax", index).Value.ToString
        'Me.txtHangdingFee.Text = Me.dgdAgency.Item("HangdingFee", index).Value.ToString
        Me.txtCountry.Text = ds.Tables(0).Rows(0).Item("country").ToString
        Me.txtemail.Text = ds.Tables(0).Rows(0).Item("email").ToString
        Me.txtpic_.Text = ds.Tables(0).Rows(0).Item("pic_").ToString
        Me.txtweb.Text = ds.Tables(0).Rows(0).Item("website").ToString
        Me.txtass.Text = ds.Tables(0).Rows(0).Item("ass").ToString
        Me.txtskype.Text = ds.Tables(0).Rows(0).Item("skype").ToString
        Me.txtyahoo.Text = ds.Tables(0).Rows(0).Item("yahoo").ToString

        'Me.txtBIZname.Text = Me.dgdAgency.Item("BIZName", index).Value.ToString
        'Me.txtWeb.Text = Me.dgdAgency.Item("Web", index).Value.ToString
        'Me.txtNationality.Text = Me.dgdAgency.Item("Nationality", index).Value.ToString
        'Me.txtProvince.Text = Me.dgdAgency.Item("Province", index).Value.ToString

        'Me.txtType.Text = Me.dgdAgency.Item("Type", index).Value.ToString
        'Me.txtIndustry.Text = Me.dgdAgency.Item("Industry", index).Value.ToString
        'Me.txtAgencyRemarks.Text = Me.dgdAgency.Item("Remarks_Agency", index).Value.ToString
        Me.txtAgencyRemark.Text = ds.Tables(0).Rows(0).Item("AgencyRemarks").ToString 'Me.dgdAgency.Item("AgencyRemarks", index).Value.ToString
        'Me.txtAccountPotantial.Text = Me.dgdAgency.Item("AccountPotantial", index).Value.ToString

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListAgency_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strAgency_Id, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.dgdAgency.RowCount > 0) Then
            index = Me.dgdAgency.CurrentRow.Index
        End If

        If mStatus = "Add" Or mStatus = "Edit" Then
            If mStatus = "Edit" Then
                'CopyValues("Agency", "Agency_Id", mAgency_Id)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Agency "
            strQuery = strQuery & "WHERE Agency_Id = '" & mAgency_Id & "' AND Agency_Id <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("Agency_Id").Value = NewId()
                    mFilter = " And Agency.Agency_ID='" & .Fields("Agency_ID").Value & "'"
                    '.Fields("QuyenHan").Value = UCase(QuyenHan.Trim)
                    'If UCase(gDepartment) = "SALE" Then
                    '    .Fields("SALENAME").Value = UCase(QuyenHan.Trim)
                    'End If
                End If
                strAgency_Id = .Fields("Agency_Id").Value
                .Fields("Fax").Value = Me.txtFax.Text
                .Fields("Address").Value = Me.txtAddress.Text
                .Fields("Tel").Value = Me.txtTel.Text
                .Fields("AgencyRemarks").Value = Me.txtAgencyRemark.Text
                .Fields("AgencyName").Value = Me.txtAgencyName.Text
                .Fields("HangdingFee").Value = Me.txtHangdingFee.Text
                .Fields("Country").Value = Me.txtCountry.Text
                .Fields("City").Value = Me.txtCity.Text
                '---
                .Fields("email").Value = Me.txtemail.Text
                .Fields("website").Value = Me.txtweb.Text
                .Fields("pic_").Value = Me.txtpic_.Text
                .Fields("ass").Value = Me.txtass.Text
                .Fields("skype").Value = Me.txtskype.Text
                .Fields("yahoo").Value = Me.txtyahoo.Text



                .Update()

            End With
            rs.Close()
            Me.dgdAgency.Enabled = True
            'If mStatus = "Edit" Then
            '    QueryAgency(, 1, index)
            'Else
            QueryAgency(mFilter, , index)
            'End If
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
        Me.fraupdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdAgency.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub cmdPICOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPICOk.Click
        Try
            If mPICStatus = "Add" Or mPICStatus = "Edit" Then
                Dim strQuery, strAgency_Id, pName As String
                Dim rs As New ADODB.Recordset
                Dim mPIC As String
                Dim index As Integer
                If (Me.dgdPIC.RowCount > 0) Then
                    index = Me.dgdPIC.CurrentRow.Index
                    mPIC = Me.dgdPIC.Item("PICAgency_ID", index).Value.ToString
                Else
                    mPIC = DefaultValue
                End If

                'strQuery = "SELECT * "
                'strQuery = strQuery & "FROM PIC "
                'strQuery = strQuery & "WHERE Agency_id = '" & mAgency_Id & "' AND PIC liek'%" & me. & "%' "
                'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If Not rs.EOF Then
                '    MsgBox("This record has already in database")
                '    Exit Sub
                'End If
                'rs.Close()

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM PICAGENCY "
                strQuery = strQuery & "WHERE PICAgency_ID = '" & mPIC & "' AND PICAgency_ID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If mPICStatus = "Add" Then
                        .AddNew()
                        .Fields("PICAgency_ID").Value = NewId()
                        .Fields("Agency_ID").Value = "{" & mAgency_Id & "}"
                    End If
                    .Fields("PIC").Value = Me.txtPic.Text.Trim
                    '.Fields("Agency_ID").Value = "{" & FindValueID(Me.txtPic, Me.txtPic.Text) & "}"
                    .Fields("Pos").Value = Me.txtPICPos.Text.Trim
                    .Fields("DirectLine").Value = Me.txtPICDirectLine.Text.Trim

                    .Update()
                End With
                rs.Close()

                QueryAgencyPIC()
                SetPicItem(False)
                mPICStatus = "Normal"
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    Private Sub AddPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPIC.Click
        Try
            SetPicItem(True)
            mPICStatus = "Add"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub EditPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPIC.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean
            Dim index As Integer
            If Me.dgdPIC.RowCount > 0 Then
                index = Me.dgdPIC.CurrentRow.Index
            Else
                Exit Sub
            End If
            Approve = Me.dgdPIC.Item("ApproveP", index).Value
            EditTable = Me.dgdPIC.Item("EditableP", index).Value
            If mPICStatus = "Normal" And Not Approve And EditTable And UserRight("frmListAgency", "Edit") And Not Me.dgdAgency.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                SetPicItem(True)
                mPICStatus = "Edit"
                ' Me.txtAgencyName.Text = Me.dgdAgency.Item("AgencyName", index).Value.ToString
                Me.txtPic.Text = Me.dgdPIC.Item("PIC", index).Value.ToString.Trim
                Me.txtPICPos.Text = Me.dgdPIC.Item("POS", index).Value.ToString.Trim
                Me.txtPICDirectLine.Text = Me.dgdPIC.Item("DirectLine", index).Value.ToString.Trim
            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub SetPicItem(ByVal value As Boolean)
        Try
            ' Me.cboAgency.Enabled = value
            Me.txtPICDirectLine.Enabled = value
            Me.txtPic.Enabled = value
            Me.txtPICPos.Enabled = value
            Me.cmdPICOk.Enabled = value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub DeletePIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePIC.Click
        Dim index As Integer
        If Me.dgdPIC.RowCount > 0 Then
            index = Me.dgdPIC.CurrentRow.Index
        Else
            Exit Sub
        End If

        If Not IsNothing(Me.dgdPIC.Item("ApproveP", index).Value) Then
            If Me.dgdPIC.Item("ApproveP", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strQuery As String
        strQuery = "select * from PICAgency where PICAgency_ID='" & Me.dgdPIC.Item("PICAgency_ID", index).Value.ToString & "' And Continued=1"
        Dim rs As New ADODB.Recordset
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        rs.Fields("Continued").Value = 0
        rs.Update()
        rs.Close()
        QueryAgencyPIC()
    End Sub

    Private Sub dgdPIC_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdPIC.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        Dim index As Integer
        index = Me.dgdPIC.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdPIC.CurrentCellAddress.X = 7 And Me.dgdPIC.CurrentCellAddress().Y = index Then
            Call ApproveAgencyP()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdPICCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPICCancel.Click
        On Error GoTo Err_Renamed
        'Me.fraUpdate.Visible = False
        'ReFormat()
        'SetMenu((True))
        mPICStatus = "Normal"
        'reText(mStatus)
        Me.dgdPIC.Enabled = True
        Me.cmdPICOk.Enabled = False
        SetPicItem(False)
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
                QueryAgency("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If Me.dgdAgency.RowCount > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdAgency, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub txtAgency_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAgency.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim mau As Integer = -65281
            Dim currow As Integer
            Dim i As Integer
            Me.dgdAgency.Rows(0).DefaultCellStyle.BackColor = Color.FromArgb(mau)
            Me.dgdAgency.Rows(0).DefaultCellStyle.ForeColor = Color.Black
            For i = 0 To Me.dgdAgency.RowCount - 1
                Try

                    If Me.dgdAgency.Item("country", i).Value.ToString = Me.dgdAgency.Item("country", i + 1).Value.ToString Then
                        Me.dgdAgency.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        Me.dgdAgency.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                    Else
                        Me.dgdAgency.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                        Me.dgdAgency.Rows(i).DefaultCellStyle.ForeColor = Color.Black
                        mau += 100
                    End If
                Catch ex As Exception

                End Try

            Next
            Try
                Me.dgdAgency.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(mau)
                Me.dgdAgency.Rows(i).DefaultCellStyle.ForeColor = Color.Black
            Catch ex As Exception

            End Try


        Catch ex As Exception

        End Try
    End Sub
End Class