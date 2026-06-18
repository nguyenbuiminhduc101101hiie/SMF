Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Public Class frmCargoReceipt

    Inherits System.Windows.Forms.Form
    Dim rsAgencyList As New ADODB.Recordset
    Dim mStatus, mFilter, mCommondityStatus, mCargoReceiptDetailStatus As String
    Public blnUpdated As Boolean
    Public mCargoReceiptID, mCargoReceiptDetailID As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet
    Dim oTableMarket, oTablePIC, oTableCommondity As New DataTable

    Const strDateOfAgencySelect As String = "SELECT * "

    Const strDateOfAgencyOrder1 As String = _
           " ORDER BY Agency_Code  Desc "
    Const strDateOfAgencyOrder2 As String = _
        " ORDER BY UpdateTime Desc "




    Private Sub frmListAgency_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.cmdCancel_Click(sender, e)
    End Sub

    Private Sub frmListAgency_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        '  Me.txtcontainertype.Visible = True
        Me.Label5.Visible = True
        mStatus = "Normal"
        mCommondityStatus = "Normal"
        mCargoReceiptDetailStatus = "Normal"
        blnUpdated = False
        SetDefaultGrid(Me.dgdAgency, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdPIC, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        'mCargoReceiptID = DefaultValue
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

        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Agency", "Agency")
        'Me.cboFind.Items.Add(oItems)



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
        '----
        '---------------------
        'Dim id_ As String
        'Dim value_ As String
        'Dim strQuery_ As String
        'cbotenmathang.Items.Clear()
        'id_ = "charge_ID"
        'value_ = "charge_code"
        'strQuery_ = "Select  CHARGE_ID,charge_code +'-'+ charge as charge_code from charge  Order by charge_code "



        'loadDataToObject(Me.cbotenmathang, strQuery_, id_, value_)



        Dim id As String
        Dim value As String
        Dim strQuery As String
        Me.cbocustomer.Items.Clear()
        id = "customer_id"
        value = "company"
        strQuery = "Select customer_id,company from customer where CONTINUED=1 Order by company "
        loadDataToObject(Me.cbocustomer, strQuery, id, value)


        'Me.cbokho.Items.Clear()
        'id = "ten"
        'value = "ten"
        'strQuery = "Select ten from warehouse  Order by ten "
        'loadDataToObject(Me.cbokho, strQuery, id, value)

        '-------------------
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmListAgency_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Function MakeQueryAgency(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryAgency = "select cargoreceiptID,refno,vaohoi,ngay,customerid,company as nhapxuatchodonvi,doongba,phuongtiengiaohang,bookingso,diadiemnhanhang,cargoreceipt.editable,cargoreceipt.approve,cargoreceipt.continued,cargoreceipt.userupdate,cargoreceipt.dateupdate "
        MakeQueryAgency = MakeQueryAgency & "From cargoreceipt left join customer on cargoreceipt.customerID=customer.customer_id "
        MakeQueryAgency = MakeQueryAgency & " WHERE ((cargoreceiptID = '" & DefaultValue & "') "

        MakeQueryAgency = MakeQueryAgency & "OR ("
        MakeQueryAgency = MakeQueryAgency & "cargoreceipt.Continued = 1 "
        MakeQueryAgency = MakeQueryAgency & ")) "
        If gDepartment = "Management" Then
        Else

            MakeQueryAgency = MakeQueryAgency & " and  ("
            MakeQueryAgency = MakeQueryAgency & "cargoreceipt.userupdate = '" & strUserId & "'  "
            MakeQueryAgency = MakeQueryAgency & ") "


        End If
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
        Try
            If mStatus = "Normal" And UserRight("frmCargoReceipt", "Add") Then
                '  Me.txtAgency.Enabled = True
                'Me.txtAgency_Code.Enabled = True
                Me.fraUpdate.Visible = True
                Me.dgdAgency.Enabled = False
                ReFormat()
                SetMenu((False))
                mCargoReceiptID = DefaultValue
                mCargoReceiptDetailID = DefaultValue

                mStatus = "Add"
                reText(mStatus)
                'Me.QueryAgency()
                Me.QueryAgencyPIC()
                ' dem lay so ref
                'Dim sql As String
                'Dim ds As New DataSet
                'sql = "select count(*) as dem from nhapkho "
                'ds = ReadDataSet(sql)
                'Try
                '    Me.txtrefno.Text = CDate(Getdate()).Year.ToString + CDate(Getdate()).Month.ToString + (CDbl(ds.Tables(0).Rows(0).Item("dem").ToString) + 1).ToString
                'Catch ex As Exception

                'End Try
                'Me.txtAgency.Text = Me.txtAgency.Text
                Dim ctr As Control
                For Each ctr In Me.GroupBox1.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

                For Each ctr In Me.GroupBox2.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next
                For Each ctr In Me.TabPage2.Controls ' DEBIT
                    If UCase(TypeName(ctr)) = "TEXTBOX" Or UCase(TypeName(ctr)) = "COMBOBOX" Then
                        ctr.Text = ""
                    End If

                Next

            Else
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Sub QueryAgencyPIC()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strSQL As String
            strSQL = "select  cargoReceiptDetailID,cargoReceiptID,kymahieu,soluong,kichthuoc,stt "
            strSQL &= "  From cargoReceiptDetail  "
            strSQL &= " Where cargoReceiptID ='" & mCargoReceiptID & "'"
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
        If Not UserRight("frmnhapkho", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QueryAgency(mFilter, , index)
        Else
            strQueryAgencyList = "Select * from nhapkho where" + " nhapkhoid= '" & dgdAgency.Item("nhapkhoid", index).Value.ToString & "'"
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
    Public Sub DeleteRowChitiet(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        ' Xác định vị trí row trong grid
        Dim cmd As New ADODB.Command

        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmCargoReceipt", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Items : " & Me.dgdPIC.Item("kymahieu", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from Agency where" + " Agency_Id= '" & Me.dgdAgency.Item("Agency_Id", index).Value.ToString & "'"
                'rsAgencyList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsAgencyList.Fields("continued").Value = 0
                'rsAgencyList.Update()
                'rsAgencyList.Requery()
                'Me.dgdAgency.Rows(index).DefaultCellStyle.ForeColor = Color.White
                'Me.dgdAgency.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsAgencyList.Close()
                'blnUpdated = True
                'End If
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from CargoReceiptDetail where CargoReceiptDetailID= '" & Me.dgdPIC.Item("CargoReceiptDetailID", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            End If
        End If
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
        Dim cmd As New ADODB.Command
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
        'If Not IsNothing(Me.dgdAgency.Item("Editable", index).Value) Then
        '    If Not Me.dgdAgency.Item("Editable", index).Value Then
        '        DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        '        Exit Sub
        '    End If
        'End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmCargoReceipt", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Items : " & Me.dgdAgency.Item("RefNo", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                'strQueryCommodityList = "Select * from Agency where" + " Agency_Id= '" & Me.dgdAgency.Item("Agency_Id", index).Value.ToString & "'"
                'rsAgencyList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'rsAgencyList.Fields("continued").Value = 0
                'rsAgencyList.Update()
                'rsAgencyList.Requery()
                'Me.dgdAgency.Rows(index).DefaultCellStyle.ForeColor = Color.White
                'Me.dgdAgency.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                'rsAgencyList.Close()
                'blnUpdated = True
                'End If
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from cargoreceipt where nhapkhoid= '" & Me.dgdAgency.Item("nhapkhoid", index).Value.ToString & "' "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
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
            'EditTable = Me.dgdAgency.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And UserRight("frmcargoreceipt", "Edit") Then
                Me.dgdAgency.Height = 306
                'Me.txtAgency_Code.Enabled = False
                Me.dgdAgency.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mCargoReceiptID = Me.dgdAgency.Item("cargoreceiptid", index).Value.ToString

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
            Me.Text = "Cargo Receipt"
        ElseIf mStatus = "Edit" Then
            Me.Text = "Cargo Receipt  -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Cargo Receipt -> Add."
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
        'If oTable.Rows.Count > 0 Then
        '    Me.dgdAgency.Columns.Item("Agencyname").ToolTipText = "Hiện có:" + CStr(Me.dgdAgency.RowCount()) + " Agencys."
        'End If
        If Me.dgdAgency.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        'If location > 0 And location <= Me.dgdAgency.Rows.Count And Me.dgdAgency.Rows.Count > 0 Then
        '    Me.dgdAgency.Rows(location).Selected = True
        '    Me.dgdAgency.CurrentCell = Me.dgdAgency.Rows(location).Cells(3)
        'End If
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
            dgdAgency.Height = Me.Height - 50 - IIf(fraUpdate.Visible, fraUpdate.Height + 40, 20) '> 7000
        Else
            dgdAgency.Height = Me.Height - 100 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 20) ' < 7000
        End If
        'fraUpdate1.Width = (Me.Width - 30)
        fraUpdate.Top = dgdAgency.Height + dgdAgency.Top + 10

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
        If UCase(Me.dgdAgency.Columns(ColIndex).Name) = "APPROVE" And Me.dgdAgency.CurrentCellAddress.Y = RowIndex Then
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


    Private Sub RefreshData(ByVal index As Integer)
        Try


            Dim oItems As PDSAListItemString
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from cargoreceipt where cargoreceiptid='" & mCargoReceiptID & "' "

            ds = ReadDataSet(sql)

            Me.txtrefno.Text = ds.Tables(0).Rows(0).Item("refno").ToString

            Me.txtvaohoi.Text = ds.Tables(0).Rows(0).Item("vaohoi").ToString

            Me.txtngay.Text = ds.Tables(0).Rows(0).Item("ngay").ToString

            Try
                Me.cbocustomer.Text = FindIDValue(Me.cbocustomer, ds.Tables(0).Rows(0).Item("customerid").ToString)
            Catch ex As Exception

            End Try
            Me.txtdoongba.Text = ds.Tables(0).Rows(0).Item("doongba").ToString
            Me.txtbookingso.Text = ds.Tables(0).Rows(0).Item("bookingso").ToString
            Me.txtphuongtiengiao.Text = ds.Tables(0).Rows(0).Item("phuongtiengiaohang").ToString



            Me.txtdiadiemnhanhang.Text = ds.Tables(0).Rows(0).Item("diadiemnhanhang").ToString



            '---------------------

            Me.txtrach.Text = ds.Tables(0).Rows(0).Item("t1").ToString
            Me.txtslrach.Text = ds.Tables(0).Rows(0).Item("sl1").ToString
            Me.txtghichurach.Text = ds.Tables(0).Rows(0).Item("gc1").ToString

            Me.txtthung.Text = ds.Tables(0).Rows(0).Item("t2").ToString
            Me.txtslthung.Text = ds.Tables(0).Rows(0).Item("sl2").ToString
            Me.txtghichuthung.Text = ds.Tables(0).Rows(0).Item("gc2").ToString

            Me.txtbep.Text = ds.Tables(0).Rows(0).Item("t3").ToString
            Me.txtslbep.Text = ds.Tables(0).Rows(0).Item("sl3").ToString
            Me.txtghichubep.Text = ds.Tables(0).Rows(0).Item("gc3").ToString

            Me.txtamuot.Text = ds.Tables(0).Rows(0).Item("t4").ToString
            Me.txtslamuot.Text = ds.Tables(0).Rows(0).Item("sl4").ToString
            Me.txtghichuamuot.Text = ds.Tables(0).Rows(0).Item("gc4").ToString

            Me.txtkhongkymahieu.Text = ds.Tables(0).Rows(0).Item("t5").ToString
            Me.txtslkhongkymahieu.Text = ds.Tables(0).Rows(0).Item("sl5").ToString
            Me.txtghichukhongkymahieu.Text = ds.Tables(0).Rows(0).Item("gc5").ToString

            Me.txtkhac.Text = ds.Tables(0).Rows(0).Item("t6").ToString
            Me.txtslkhac.Text = ds.Tables(0).Rows(0).Item("sl6").ToString
            Me.txtghichukhac.Text = ds.Tables(0).Rows(0).Item("gc6").ToString

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

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
        Try


            Dim strQuery, strAgency_Id, pName As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer
            If (Me.dgdAgency.RowCount > 0) Then
                index = Me.dgdAgency.CurrentRow.Index
            End If

            If mStatus = "Add" Or mStatus = "Edit" Then
                If mStatus = "Edit" Then
                    'CopyValues("Agency", "Agency_Id", mCargoReceiptID)
                End If
                strQuery = "SELECT * "
                strQuery = strQuery & "FROM cargoreceipt "
                strQuery = strQuery & "WHERE CargoReceiptID = '" & mCargoReceiptID & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If rs.EOF Then
                        .AddNew()
                        .Fields("CargoReceiptID").Value = NewId()
                        '  mFilter = " And QuotationTicoID='" & .Fields("QuotationTicoID").Value & "'"
                        '.Fields("QuyenHan").Value = UCase(QuyenHan.Trim)
                        'If UCase(gDepartment) = "SALE" Then
                        '    .Fields("SALENAME").Value = UCase(QuyenHan.Trim)
                        'End If
                    End If

                    .Fields("refno").Value = Me.txtrefno.Text

                    .Fields("vaohoi").Value = Me.txtvaohoi.Text
                    .Fields("vaohoi").Value = Me.txtvaohoi.Text
                    .Fields("ngay").Value = Me.txtngay.Text

                    Try
                        .Fields("customerid").Value = "{" + FindValueID(Me.cbocustomer, Me.cbocustomer.Text) + "}"
                    Catch ex As Exception

                    End Try


                    .Fields("doongba").Value = Me.txtdoongba.Text

                    .Fields("phuongtiengiaohang").Value = Me.txtphuongtiengiao.Text
                    .Fields("bookingso").Value = Me.txtbookingso.Text




                    .Fields("diadiemnhanhang").Value = Me.txtdiadiemnhanhang.Text
                    '------------
                    .Fields("t1").Value = Me.txtrach.Text
                    .Fields("sl1").Value = Me.txtslrach.Text
                    .Fields("gc1").Value = Me.txtghichurach.Text

                    .Fields("t2").Value = Me.txtthung.Text
                    .Fields("sl2").Value = Me.txtslthung.Text
                    .Fields("gc2").Value = Me.txtghichuthung.Text

                    .Fields("t3").Value = Me.txtbep.Text
                    .Fields("sl3").Value = Me.txtslbep.Text
                    .Fields("gc3").Value = Me.txtghichubep.Text

                    .Fields("t4").Value = Me.txtamuot.Text
                    .Fields("sl4").Value = Me.txtslamuot.Text
                    .Fields("gc4").Value = Me.txtghichuamuot.Text


                    .Fields("t5").Value = Me.txtkhongkymahieu.Text
                    .Fields("sl5").Value = Me.txtslkhongkymahieu.Text
                    .Fields("gc5").Value = Me.txtghichukhongkymahieu.Text

                    .Fields("t6").Value = Me.txtkhac.Text
                    .Fields("sl6").Value = Me.txtslkhac.Text
                    .Fields("gc6").Value = Me.txtghichukhac.Text

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

        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
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
            If mCargoReceiptDetailStatus = "Add" Or mCargoReceiptDetailStatus = "Edit" Then
                Dim strQuery, strAgency_Id, pName As String
                Dim rs As New ADODB.Recordset
                Dim mCargoReceiptDetailID_ As String
                Dim index As Integer
                If mCargoReceiptID = DefaultValue Then
                    DisplayMessage(True, "Xin nhập 1 Phiếu trước khi nhập chi tiết.!")
                    Exit Sub
                End If
                ' kiem tra maso mathag
                Dim sql, strMesg As String
                Dim ds As New DataSet
                If mCargoReceiptDetailStatus = "Edit" Then

                Else
                    'sql = "select * from nhapkhochitiet where maso='" & txtmaso.Text.Trim & "' "
                    'ds = ReadDataSet(sql)
                    'If ds.Tables(0).Rows.Count > 0 Then
                    '    ' DisplayMessage(True, "Mã số đã tồn tại.!")
                    '    strMesg = "Mã số đã tồn tại, bạn có muốn thêm hay không ?"
                    '    If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    '    Else
                    '        Exit Sub
                    '    End If
                    'End If
                End If

                ' End If



                If (Me.dgdPIC.RowCount > 0) Then
                    index = Me.dgdPIC.CurrentRow.Index
                    mCargoReceiptDetailID_ = Me.dgdPIC.Item("CargoReceiptDetailID", index).Value.ToString
                Else
                    mCargoReceiptDetailID_ = DefaultValue
                End If

                'strQuery = "SELECT * "
                'strQuery = strQuery & "FROM PIC "
                'strQuery = strQuery & "WHERE Agency_id = '" & mCargoReceiptID & "' AND PIC liek'%" & me. & "%' "
                'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                'If Not rs.EOF Then
                '    MsgBox("This record has already in database")
                '    Exit Sub
                'End If
                'rs.Close()

                strQuery = "SELECT * "
                strQuery = strQuery & "FROM CargoReceiptDetail "
                strQuery = strQuery & "WHERE CargoReceiptDetailID = '" & mCargoReceiptDetailID_ & "' AND CargoReceiptDetailID <> '" & DefaultValue & "' "
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs
                    If mCargoReceiptDetailStatus = "Add" Then
                        .AddNew()
                        .Fields("CargoReceiptDetailID").Value = NewId()
                        .Fields("CargoReceiptID").Value = "{" & mCargoReceiptID & "}"
                    End If
                    .Fields("stt").Value = Me.txtstt.Text
                    ' .Fields("itemsid").Value = "{" + FindValueID(Me.cbotenmathang, Me.cbotenmathang.Text) + "}"
                    .Fields("kymahieu").Value = Me.txtkymahieu.Text ' kiem tra trung
                    .Fields("soluong").Value = Me.txtsoluong.Text
              


                    .Fields("kichthuoc").Value = Me.txtkichthuoc.Text


                    ''.Fields("Agency_ID").Value = "{" & FindValueID(Me.txtPic, Me.txtPic.Text) & "}"



                    .Update()
                End With
                rs.Close()

                QueryAgencyPIC()
                SetPicItem(False)
                mCargoReceiptDetailStatus = "Normal"
                Me.cmdPICCancel.Enabled = True
                Me.cmdPICOk.Enabled = False
            End If
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    Private Sub AddPIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddPIC.Click
        Try
            SetPicItem(True)
            Me.txtstt.Text = (Me.dgdPIC.RowCount + 1).ToString
            mCargoReceiptDetailStatus = "Add"
            'Me.txttkco.Text = ""

            'Me.txttkno.Text = ""
          
            Me.txtkichthuoc.Text = ""
            Me.txtkymahieu.Text = ""
            '  Me.txtstt.Text = Me.d


            Me.txtsoluong.Text = ""


            Me.cmdPICOk.Enabled = True
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
            ' Approve = Me.dgdPIC.Item("ApproveP", index).Value
            ' EditTable = Me.dgdPIC.Item("EditableP", index).Value
            If mCargoReceiptDetailStatus = "Normal" Then ' And EditTable And UserRight("frmListAgency", "Edit") And Not Me.dgdAgency.Rows(index).DefaultCellStyle.ForeColor = Color.White
                SetPicItem(True)
                mCargoReceiptDetailStatus = "Edit"
                ' Me.txtAgencyName.Text = Me.dgdAgency.Item("AgencyName", index).Value.ToString
                Me.txtstt.Text = Me.dgdPIC.Item("stt", index).Value.ToString.Trim
                Me.txtkymahieu.Text = Me.dgdPIC.Item("kymahieu", index).Value.ToString.Trim
              
                Me.txtsoluong.Text = Me.dgdPIC.Item("soluong", index).Value.ToString.Trim
              
                Me.txtkichthuoc.Text = Me.dgdPIC.Item("kichthuoc", index).Value.ToString.Trim
                Me.txtstt.Text = Me.dgdPIC.Item("stt", index).Value.ToString.Trim
               
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
            'Me.txtPICDirectLine.Enabled = value
            'Me.txtPic.Enabled = value
            'Me.txtPICPos.Enabled = value
            Me.cmdPICOk.Enabled = value
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'Private Sub DeletePIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePIC.Click
    '    Dim index As Integer
    '    If Me.dgdPIC.RowCount > 0 Then
    '        index = Me.dgdPIC.CurrentRow.Index
    '    Else
    '        Exit Sub
    '    End If

    '    If Not IsNothing(Me.dgdPIC.Item("ApproveP", index).Value) Then
    '        If Me.dgdPIC.Item("ApproveP", index).Value Then
    '            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
    '            Exit Sub
    '        End If
    '    End If
    '    Dim strQuery As String
    '    strQuery = "select * from PICAgency where PICAgency_ID='" & Me.dgdPIC.Item("PICAgency_ID", index).Value.ToString & "' And Continued=1"
    '    Dim rs As New ADODB.Recordset
    '    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '    rs.Fields("Continued").Value = 0
    '    rs.Update()
    '    rs.Close()
    '    QueryAgencyPIC()
    'End Sub

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
        mCargoReceiptDetailStatus = "Normal"
        'reText(mStatus)
        Me.dgdPIC.Enabled = True
        Me.cmdPICOk.Enabled = False
        Me.cmdPICCancel.Enabled = True
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

            Dim chk As Integer
            chk = Me.dgdAgency.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If chk = 0 Then
                DisplayMessage(True, "Xin chọn 1 dòng dữ liệu để thao tác.")
                Return
            End If
            If Me.dgdAgency.RowCount > 0 Then
                Dim index As Integer = Me.dgdAgency.CurrentRow.Index
                gPrintCargoReceiptID = Me.dgdAgency.Item("CargoReceiptID", index).Value.ToString




                If LoginSucceeded = True Then
                    Dim form As New frmPrintCargoReceipt 'frmQuotationTico
                    form.MdiParent = frmMain
                    form.Show()
                End If
                '   VB6.ShowForm(frmPrintQuotation, VB6.FormShowConstants.Modal, Me)
            End If


        Catch ex As Exception
            MsgBox(msgErr(Me, Err.Description))
        End Try
    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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


    Private Sub DeletePIC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeletePIC.Click
        Dim selectedRowCount As Integer = _
    Me.dgdPIC.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowChitiet(Me.dgdPIC.SelectedRows(i).Index)
            Next i
        End If
        ' Me.QueryAgency(mFilter)
        QueryAgencyPIC()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub



   

   

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub txtshipper_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim id As String
            Dim value As String
            Dim strQuery As String
            Me.cbocustomer.Items.Clear()
            id = "customer_id"
            value = "company"
            strQuery = "Select customer_id,company from customer where CONTINUED=1 and (company like '%" & Me.txtsearch.Text & "%' or taxcode like '%" & Me.txtsearch.Text & "%'  ) Order by company "
            loadDataToObject(Me.cbocustomer, strQuery, id, value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Me.txtngay.Text = ddMMMyyyy(Me.DateTimePicker1.Value.Date)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

   

   
End Class