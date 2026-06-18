Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic

Public Class frmListCharge
    Inherits System.Windows.Forms.Form
    Dim ChargeLanh As Boolean = 0
    Dim index As Integer = 0
    Dim rsChargeList As New ADODB.Recordset
    Dim mStatus, mFilter, mStatusT As String
    Public blnUpdated As Boolean
    Public mCharge_ID, mChargeT_ID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strChargeSelect As String = "SELECT " & _
    "Charge_ID, " & _
    "Charge_CODE, " & _
    "Charge , " & _
   "Approve, " & _
    "Continued, " & _
    "Editable, " & _
    "UserId, " & _
    "Updatetime "

    Const strChargeOrder1 As String = _
           " ORDER BY Charge_CODE  "
    Const strChargeOrder2 As String = _
        " ORDER BY UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        strMsg = ""
        Dim strCharge_ID As String
        If mStatus = "Add" Then
            If mStatus = "Add" Then
                If Me.txtChargeCode.Text = "" Then
                    CheckData = False
                    DisplayMessage(True, IIf(gLang = "E", "The code not allow NULL value", "Mã Không Đựơc để Rỗng"))
                End If
                Dim rs As New ADODB.Recordset
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Charge "
                strQuery = strQuery & "WHERE Charge_CODE = '" & Me.txtChargeCode.Text & "' And Continued=1"
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

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtCharge.Text)
        If Me.txtCharge.Text <> "" Then
            Select Case Me.cboFind.Text
                Case "Charge Code"
                    QueryCharge("AND ( Charge_CODE LIKE '" & strFilter & "') " & mFilter)
                    'Me.dgdPayableAt.Columns.Item("CODE").Visible = Me.smnuDisplayBookingPerson.Checked
                Case "Charge"
                    QueryCharge("AND (Charge LIKE '" & strFilter & "')" & mFilter)
                    UpdateFrame()
            End Select
        Else
            QueryCharge(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCharge_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        mStatusT = "Normal"
        blnUpdated = False
        Me.txtstt.Enabled = True
        Me.txtChargeCode.Enabled = True
        Me.txtunit.Enabled = True


        mCharge_ID = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        Dim oItems As PDSAListItemString
        Me.cboFind.Items.Clear()
        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Charge Code", "Charge Code")
        Me.cboFind.Items.Add(oItems)

        oItems = New PDSAListItemString
        oItems.Value = IIf(gLang = "E", "Charge", "Charge")
        Me.cboFind.Items.Add(oItems)


        Me.cboFind.Text = objUserSetting.GetCParm("frmListCharge.cboFind", "Charge")
        mFilter = objUserSetting.GetCParm("frmListCharge.mFilter")
        Me.txtChargeCode.Text = objUserSetting.GetCParm("frmListCharge.txtCharge_CODE")
        If Me.txtCharge.Text <> "" Then
            QueryCharge("AND Charge_CODE LIKE '" & MakeFilter(Me.txtCharge.Text) & "' " & mFilter, , )
        Else
            QueryCharge(mFilter, , )
        End If
        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If


        QueryCombo()


        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListCharge.smnuDisplayAPPROVE")
        'Me.smnuDisplayCharge.Checked = objUserSetting.GetBParm("frmListCharge.smnuDisplayCharge")


        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListCharge.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListCharge.smnuDisplayUpdateTime")

        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Me.BackColor = gMaunen
        Me.fraUpdate.BackColor = gMauFra
        SetDefaultGrid(Me.dgdCharge, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListCharge_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmListCharge.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListCharge.txtCharge", Me.txtCharge.Text)
        'objUserSetting.SetCParm("frmListCharge.txtChargeCODE", Me.txtChargeCode.Text)

        'objUserSetting.SetCParm("frmListCharge.txtChargeValue", Me.txtChargeValue.Text)


        'objUserSetting.SetCParm("frmListCharge.mFilter", mFilter)

        'objUserSetting.SetBParm("frmListCharge.smnuDisplayCharge", Me.smnuDisplayCharge.Checked)
        'objUserSetting.SetBParm("frmListCharge.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)

        'objUserSetting.SetBParm("frmListCharge.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListCharge.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryCharge(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryCharge = strChargeSelect
        MakeQueryCharge = MakeQueryCharge & ", dvt,stt, show,show1,tariffFCL,tariffLCL,tariffFCLib,tariffLCLib,tiengtrung,unit,tk1,tk2,tk3 From Charge"
        MakeQueryCharge = MakeQueryCharge & " WHERE (Charge_ID = '" & DefaultValue & "') "

        MakeQueryCharge = MakeQueryCharge & "OR ("
        MakeQueryCharge = MakeQueryCharge & "Continued = 1 "
        MakeQueryCharge = MakeQueryCharge & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCharge = MakeQueryCharge & argCriteria
        End If
        'If index = 1 Then ' 
        MakeQueryCharge = MakeQueryCharge & strChargeOrder1
        'ElseIf index = 15 Then ' 
        ' MakeQueryCharge = MakeQueryCharge & strChargeOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function CodeCharge() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Charge_CODE) as CountNo from Charge", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight("frmListCharge", "Add") Then
            Me.GroupBox1.Enabled = False
            Me.txtChargeCode.Enabled = True
            Me.fraUpdate.Visible = True
            Me.dgdCharge.Enabled = False
            ReFormat()
            SetMenu((False))
            mCharge_ID = DefaultValue
            mStatus = "Add"
            reText(mStatus)
            Me.txtChargeCode.Text = Me.txtChargeCode.Text
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub ApproveCharge()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdCharge.CurrentRow.Index
        Dim strQueryChargeList As String
        If Not Me.dgdCharge.Item("Editable", index).Value Or Not UserRight("frmListCharge", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryCharge(, , index)
        Else
            strQueryChargeList = "Select * from Charge where" + " Charge_ID= '" & dgdCharge.Item("Charge_ID", index).Value.ToString & "'"
            rsChargeList.Open(strQueryChargeList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsChargeList.Fields("Approve").Value
            rsChargeList.Update("Approve", Approve)
            rsChargeList.Close()
        End If
        QueryCharge()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveChargeT()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.DataGridView1.CurrentRow.Index
        Dim strQueryChargeList As String
        If Not UserRight("frmListCharge", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            Queryt(, , index)
        Else
            strQueryChargeList = "Select * from Chargetemplete where" + " ID = '" & Me.DataGridView1.Item("id", index).Value.ToString & "'"
            rsChargeList.Open(strQueryChargeList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsChargeList.Fields("Approve").Value
            rsChargeList.Update("Approve", Approve)
            rsChargeList.Close()
        End If
        Queryt()
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE Charge_ID = '" & Me.dgdPayableAt.Item("Charge_ID", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        strQuery = "Select * from Charge WHERE Charge_ID = '" & Me.dgdCharge.Item("Charge_ID", index).Value.ToString & "' And UserId='DBO'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, The Charge can not be removed.", "Không Thể Thực Hiện Tác Vụ Này"))
            Exit Sub
        End If
        'che tam vi chua co quan he voi Dulieu khac

        'If Not blnEmpty Then
        '    DisplayMessage(True, "The Charge can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If

        If Not IsNothing(Me.dgdCharge.Item("Approve", index)) Then
            If Me.dgdCharge.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdCharge.Item("Editable", index)) Then
            If Not Me.dgdCharge.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListCharge", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Charge: " & Me.dgdCharge.Item("Charge_Code", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from Charge where" + " Charge_ID= '" & Me.dgdCharge.Item("Charge_ID", index).Value.ToString & "'"
                rsChargeList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rsChargeList.Fields("continued").Value = 0
                rsChargeList.Update()
                rsChargeList.Requery()
                Me.dgdCharge.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdCharge.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rsChargeList.Close()
                blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub DeleteRowT(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        Dim cmd As New ADODB.Command

        If Not IsNothing(Me.DataGridView1.Item("ApproveT", index)) Then
            If Me.DataGridView1.Item("ApproveT", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
    
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmListCharge", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Charges Templete: " & Me.DataGridView1.Item("chargename", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from Charge where" + " Charge_ID= '" & Me.dgdCharge.Item("Charge_ID", index).Value.ToString & "'"
                'rsChargeList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsChargeList.Fields("continued").Value = 0
                'rsChargeList.Update()
                'rsChargeList.Requery()
                'Me.dgdCharge.Rows(index).DefaultCellStyle.ForeColor = Color.White
                'Me.dgdCharge.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsChargeList.Close()
                'blnUpdated = True
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from chargetemplete where id= '" & Me.DataGridView1.Item("id", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdCharge.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdCharge.SelectedRows(i).Index)
            Next i
        End If
        Me.QueryCharge()
    End Sub
#Region "ViewMenuStrip"

    'Private Sub smnuDisplayCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCharge.Click
    '    Me.smnuDisplayCharge.Checked = Not Me.smnuDisplayCharge.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayApprove.Click
    '    Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '    UpdateFrame()
    'End Sub



    'Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
    '    Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
    '    Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '    UpdateFrame()
    'End Sub


#End Region

#Region "Xuly"
    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        If Me.dgdCharge.Rows.Count = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdCharge.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdCharge.Item("Approve", index).Value
            EditTable = Me.dgdCharge.Item("Editable", index).Value
            If mStatus = "Normal" And UserRight("frmListCharge", "Edit") And Not Approve And EditTable And Not Me.dgdCharge.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.GroupBox1.Enabled = True
                Me.dgdCharge.Height = 306
                Me.dgdCharge.Enabled = False
                Me.txtChargeCode.Enabled = True
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mCharge_ID = Me.dgdCharge.Item("Charge_ID", index).Value.ToString
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)
                Me.Queryt()
                Me.cmdokT.Enabled = False
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
            Me.Text = "List Charge"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Charge  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Charge -> Add."
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

    Private Sub Queryt(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        'If IsNothing(argCriteria) Then
        strQuery = "select id,chargeid,charge_Code as chargename,cont20,cont40,ncc,cur,incvat,remarks,chargetemplete.approve as approvet from chargetemplete left join charge on charge.charge_id=chargetemplete.chargeid where chargeid='" & mCharge_ID & "' "
        'Else
        '    strQuery = MakeQueryCharge(argCriteria, index)
        'End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "ChargeList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.DataGridView1.DataSource = ds.Tables("ChargeList")
        If Me.DataGridView1.Enabled = False Then
            Me.DataGridView1.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
      
        '------------vị trí BM
    
        '--------------------
        InsertAutoNumberToGrid(Me.DataGridView1)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    '============Miscelanous==========
  
    Private Sub QueryCharge(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCharge()
        Else
            strQuery = MakeQueryCharge(argCriteria, index)
        End If
        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "ChargeList")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdCharge.DataSource = ds.Tables("ChargeList")
        If Me.dgdCharge.Enabled = False Then
            Me.dgdCharge.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdCharge.Columns.Item("Charge_CODE").ToolTipText = "Hiện có:" + CStr(Me.dgdCharge.RowCount()) + " Charge."
        End If
        If Me.dgdCharge.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdCharge.Rows.Count And Me.dgdCharge.Rows.Count > 0 Then
            Me.dgdCharge.Rows(location).Selected = True
            Me.dgdCharge.CurrentCell = Me.dgdCharge.Rows(location).Cells(2)

        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdCharge)
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

        'Me.dgdCharge.Columns.Item("Charge_ID").Visible = False
        'Me.dgdCharge.Columns.Item("Charge").Visible = Me.smnuDisplayCharge.Checked
        'Me.dgdCharge.Columns.Item("Editable").Visible = False
        'Me.dgdCharge.Columns.Item("Continued").Visible = False
        'Me.dgdCharge.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdCharge.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdCharge.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

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
        dgdCharge.Width = (Me.Width - 30)
        If Me.Width > 610 Then
            dgdCharge.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdCharge.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdCharge.Height + dgdCharge.Top

        'Me.txtCharge.Width = Me.Width - 300

        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10

        'cmdFind.Left = Me.txtCharge.Left + Me.txtCharge.Width + 10
        'txtCharge.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))

    End Sub

    Private Sub dgdPayableAt_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdCharge.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid 
        On Error GoTo Err_Renamed
        If Me.dgdCharge.Rows.Count = 0 Then
            Return
        End If
        index = Me.dgdCharge.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdCharge.CurrentCellAddress.X = 3 And Me.dgdCharge.CurrentCellAddress().Y = index Then
            Call ApproveCharge()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPayableAt_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdCharge.ColumnHeaderMouseClick
        '        Dim index As Integer
        '        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            QueryCharge("", index)
        '        End If
        '        Exit Sub
        'Err_Renamed:
        '        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdPayableAt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdCharge.KeyDown
        Dim selectedRowCount As Integer = _
       Me.dgdCharge.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdCharge.SelectedRows(i).Index)
                Next i
            End If

            QueryCharge()
        End If
    End Sub

    Private Sub cboFind_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cboFind.MouseClick

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

        Me.txtChargeCode.Text = Me.dgdCharge.Item("Charge_CODE", index).Value.ToString
        Me.cbocharges.Text = Me.dgdCharge.Item("Charge_CODE", index).Value.ToString
        Me.txtChargeValue.Text = Me.dgdCharge.Item("Charge", index).Value.ToString
        Me.txtchargeEnglish.Text = Me.dgdCharge.Item("chargetienganh", index).Value.ToString
        Me.txtstt.Text = Me.dgdCharge.Item("stt", index).Value.ToString
        'Me.txtPriceFCL.Text = Me.dgdCharge.Item("pricefcl", index).Value.ToString

        'Me.txtPriceLCL.Text = Me.dgdCharge.Item("pricelcl", index).Value.ToString

        'Me.txtPriceFCLIB.Text = Me.dgdCharge.Item("pricefclib", index).Value.ToString

        'Me.txtPriceLCLIB.Text = Me.dgdCharge.Item("pricelclib", index).Value.ToString
    
        Me.txtunit.Text = Me.dgdCharge.Item("unit", index).Value.ToString
        Me.txtTK1.Text = Me.dgdCharge.Item("tk1", index).Value
        Me.txttk2.Text = Me.dgdCharge.Item("tk2", index).Value
        Me.txttk3.Text = Me.dgdCharge.Item("tk3", index).Value
        'If Me.dgdCharge.Item("show", index).Value = True Then
        '    Me.chkShow.Checked = True
        'Else
        '    Me.chkShow.Checked = False
        'End If
        'If Me.dgdCharge.Item("netprofitout", index).Value = True Then
        '    Me.chkshow1.Checked = True
        'Else
        '    Me.chkshow1.Checked = False
        'End If
        'Me.txttiengtrung.Text = Me.dgdCharge.Item("chargeTiengtrung", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub RefreshDataT(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from chargetemplete left join charge on chargetemplete.chargeid=charge.charge_id where id='" & Me.DataGridView1.Item("id", index).Value.ToString & "'"
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.cbocharges.Text = FindIDValue(Me.cbocharges, ds.Tables(0).Rows(0).Item("chargeid").ToString)
                Me.cbosupplier.Text = ds.Tables(0).Rows(0).Item("ncc").ToString
                Try
                    Me.txtcont20.Text = FormatNumber(ds.Tables(0).Rows(0).Item("cont20").ToString, 2)
                Catch ex As Exception

                End Try
                Try
                    Me.txtcont40.Text = FormatNumber(ds.Tables(0).Rows(0).Item("cont40").ToString)
                Catch ex As Exception

                End Try
                Me.cbocur.Text = ds.Tables(0).Rows(0).Item("cur").ToString
                Me.cbovat.Text = ds.Tables(0).Rows(0).Item("incvat").ToString
                Me.txtremarks.Text = ds.Tables(0).Rows(0).Item("remarks").ToString
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try



    End Sub


    Private Sub frmListCharge_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub
#End Region

    Private Sub fraUpdate_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles fraUpdate.VisibleChanged
        Me.cmdCancel.Visible = fraUpdate.Visible
        Me.cmdOK.Visible = fraUpdate.Visible
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        Try

    
            Dim strQuery, strCharge_ID, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer
            If (Me.oTable.Rows.Count > 0) Then
                index = Me.dgdCharge.CurrentRow.Index
            End If

            If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM Charge "
                strQuery = strQuery & "WHERE Charge_ID = '" & mCharge_ID & "' AND Charge_ID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("Charge_ID").Value = NewId()
                    End If
                    strCharge_ID = .Fields("Charge_ID").Value
                    If mStatus = "Edit" Then
                        .Fields("Charge_CODE").Value = Trim(Me.txtChargeCode.Text)
                    Else
                        .Fields("Charge_CODE").Value = Me.txtChargeCode.Text
                    End If
                    .Fields("Charge").Value = UCase(Trim(Me.txtChargeValue.Text))
                    .Fields("unit").Value = Me.txtunit.Text
                    .Fields("dvt").Value = Me.txtchargeEnglish.Text
                    .Fields("tiengtrung").Value = Me.txtDept.Text

                    '  .Fields("tariffFCL").Value = Me.txtPriceFCL.Text
                    ' .Fields("tariffLCL").Value = Me.txtPriceLCL.Text

                    ' .Fields("tariffFCLib").Value = Me.txtPriceFCLIB.Text
                    ' .Fields("tariffLCLib").Value = Me.txtPriceLCLIB.Text

                    .Fields("stt").Value = UCase(Trim(Me.txtstt.Text))
                    'If Me.chkShow.Checked = True Then
                    '    .Fields("Show").Value = 1
                    'Else

                    '    .Fields("Show").Value = 0
                    'End If

                    'If Me.chkshow1.Checked = True Then
                    '    .Fields("Show1").Value = 1
                    'Else
                    Try
                        .Fields("tk1").Value = UCase(Trim(Me.txtTK1.Text))
                    Catch ex As Exception

                    End Try
                    Try
                        .Fields("tk2").Value = UCase(Trim(Me.txttk2.Text))
                    Catch ex As Exception

                    End Try
                    Try
                        .Fields("tk3").Value = UCase(Trim(Me.txttk3.Text))
                    Catch ex As Exception

                    End Try




                    '    .Fields("Show1").Value = 0
                    'End If
                    .Update()

                End With
                rs.Close()
                Me.dgdCharge.Enabled = True
                If mStatus = "Edit" Then
                    QueryCharge(, 1, index)
                Else
                    QueryCharge(, 15, index)
                End If
                Me.fraUpdate.Visible = False
                ReFormat()
                SetMenu((True))
                mStatus = "Normal"
                blnUpdated = True
            End If

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub
    Sub QueryCombo()
        Try
            Dim id, value, strSQL As String
            Me.cbocharges.Items.Clear()
          
            'loadDataToObject(Me.txtOPL, strSQL, id, value)
            'loadDataToObject(Me.txtPOD, strSQL, id, value)
        
            '----------------------------------------------

            id = "Charge_id"
            value = "Charge_CODE"
            strSQL = "Select  charge_id,Charge_CODE from charge order by Charge_CODE "
            loadDataToObject(Me.cbocharges, strSQL, id, value)
            '-----------------------------------------------  
            Me.cbosupplier.Items.Clear()
            id = "Shippingline"
            value = "Shippingline"
            strSQL = "Select  Shippingline from Shippingline order by Shippingline "
            loadDataToObject(Me.cbosupplier, strSQL, id, value)
            '-----------------------------------------------
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdCharge.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cboFind_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFind.SelectedIndexChanged

    End Sub

    Private Sub txtChargeCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtChargeCode.TextChanged

    End Sub

    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        Try
            Try
                '  allCus()
                'Dim index As Integer = Me.dgddebitGrid.CurrentRow.Index
                'If index >= 0 Then
                If mStatusT = "Normal" And UserRight("frmListCharge", "Add") Then
                    Me.cmdokT.Enabled = True
                
                    Me.DataGridView1.Enabled = False

                    '---------------------------

                    mChargeT_ID = DefaultValue 'Me.dgdHBL.Item("BLIB_ID", index).Value.ToString
                    mStatusT = "Add"
                    Me.cbocharges.Enabled = True
                    Me.cbosupplier.Enabled = True
                    Me.txtcont20.Enabled = True
                    Me.txtcont40.Enabled = True
                    Me.txtremarks.Enabled = True
                    Me.cbocur.Enabled = True
                    Me.cbovat.Enabled = True
                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
                'End If

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim Approve, EditTable, UsrRight As Boolean

            'kiểm tra xem Grid có dữ liệu không

            If Me.DataGridView1.RowCount = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No Data", "Không có Dữ Liệu"))
                Return
            End If
            Dim index As Integer = Me.DataGridView1.CurrentRow.Index
            Approve = Me.DataGridView1.Item("ApproveT", index).Value
            If index >= 0 Then

                If mStatusT = "Normal" And Not Approve And UserRight("frmListCharge", "Edit") Then

                    Me.cmdokT.Enabled = True
                    Me.DataGridView1.Enabled = False
                    mChargeT_ID = Me.DataGridView1.Item("id", index).Value.ToString
                    mStatusT = "Edit"

                    RefreshDataT(index)
                    Me.cbocharges.Enabled = True
                    Me.cbosupplier.Enabled = True
                    Me.txtcont20.Enabled = True
                    Me.txtcont40.Enabled = True
                    Me.txtremarks.Enabled = True
                    Me.cbocur.Enabled = True
                    Me.cbovat.Enabled = True
                    'Me.QueryContainer()
                    

                Else
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            If Me.DataGridView1.Rows.Count = 0 Then
                Return
            End If


            Dim selectedRowCount As Integer = _
                 Me.DataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRowT(Me.DataGridView1.SelectedRows(i).Index)
                Next i
            End If
            Me.Queryt()
        Catch ex As Exception

        End Try
    End Sub

   


    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid 
        On Error GoTo Err_Renamed
        If Me.DataGridView1.Rows.Count = 0 Then
            Return
        End If
        index = Me.DataGridView1.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If UCase(Me.DataGridView1.Columns(ColIndex).Name) = "APPROVET" And Me.DataGridView1.CurrentCellAddress.Y = RowIndex Then
            Call ApproveChargeT()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdokT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdokT.Click
        Try


            Dim strQuery, strCarrierId, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
           
          
          
         

          

         



            If Me.txtcont20.Text = "" Then
                DisplayMessage(True, "Xin kiểm tra giá Cont. 20 ! ")
                Exit Sub
            End If

            If Me.txtcont40.Text = "" Then
                DisplayMessage(True, "Xin kiểm tra giá Cont. 40 ! ")
                Exit Sub
            End If
            If IsNumeric(Me.txtcont20.Text) = False Then
                DisplayMessage(True, "Xin kiểm tra giá Cont. 20 ! ")
                Exit Sub
            End If

            If IsNumeric(Me.txtcont40.Text) = False Then
                DisplayMessage(True, "Xin kiểm tra giá Cont. 40 ! ")
                Exit Sub
            End If
            If UserRight("frmListCharge", "Edit") Then


                If (mStatusT = "Add" Or mStatusT = "Edit") Then

                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM chargeTemplete "
                    strQuery = strQuery & "WHERE id = '" & mChargeT_ID & "'  "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs
                        If rs.EOF Then
                            .AddNew()
                            .Fields("id").Value = NewId()
                        End If

                        Try
                            .Fields("chargeid").Value = "{" + FindValueID(Me.cbocharges, Me.cbocharges.Text) + "}"
                        Catch ex As Exception

                        End Try

                       

                        Try
                            .Fields("cont20").Value = Me.txtcont20.Text
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("cont40").Value = Me.txtcont40.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("cur").Value = Me.cbocur.Text
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("incvat").Value = Me.cbovat.Text
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("remarks").Value = Me.txtremarks.Text
                        Catch ex As Exception

                        End Try



                        Try
                            .Fields("ncc").Value = Me.cbosupplier.Text
                        Catch ex As Exception

                        End Try





                        .Update()
                    End With
                    rs.Close()
                    '===================================================================

                    '============================================================================
                    Me.DataGridView1.Enabled = True
                    'fraUpdate chỉ visible khi thêm hay sửa thành công
                    Me.cmdokT.Enabled = False
                    'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
                    Queryt(mFilter, , index)
                    mStatusT = "Normal"
                End If
            Else
                DisplayMessage(True, "Bạn cần được phân quyền.!")
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub cmdcancelT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancelT.Click
        On Error GoTo Err_Renamed

        Me.cmdokT.Enabled = False

        mStatusT = "Normal"
        Me.cbocharges.Enabled = False
        Me.cbosupplier.Enabled = False
        Me.txtcont20.Enabled = False
        Me.txtcont40.Enabled = False
        Me.txtremarks.Enabled = False
        Me.cbocur.Enabled = False
        Me.cbovat.Enabled = False

        Me.DataGridView1.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
End Class