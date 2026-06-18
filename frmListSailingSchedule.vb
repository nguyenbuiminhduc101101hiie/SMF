'Imports Excel
Imports System.Globalization
Public Class frmListSailingSchedule

    Dim mStatus, mSailingID, mStatusP, ETAid As String
    Dim UserRightFrm As String = "frmListSailingSchedule"
    Dim mFilter As String
    Dim oTable As New DataSet

    Sub QueryVessel(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Vessel_ID"
        value = "Data"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Vessel_Id,Vessel + ' - ' + vessel_Code as Data From Vessel where Continued=1 Order By Vessel_Code desc"
        loadDataToObject(cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryOceanVessel(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Vessel_ID"
        value = "Data"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Vessel_Id,Vessel + ' - ' + vessel_Code as Data From Vessel where Continued=1 Order By Vessel_Code desc"
        loadDataToObject(cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryTerminal(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "TerminalID"
        value = "Data"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select terminalId,terminalname as Data From terminal where Continued=1 Order By terminalname desc"
        loadDataToObject(cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Sub QueryPort(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Port_ID"
        value = "Data"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select  port,Port + ' - ' + Port_Code as Data,Port_Id From Port where Continued=1 Order By Port desc"
        loadDataToObject(cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryMarket(ByRef cbo As ComboBox)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Code"
        value = "Code"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select MarketCode as Code From Market where Continued=1 Order By MarketCode desc"
        loadDataToObject(cbo, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub QuerySailing(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet

        '----------------
        'If IsNothing(argCriteria) Then
        'strQuery = MakeQueryContainerOutboundNotify()
        'Else
        '    strQuery = MakeQueryContainerOutboundNotify(argCriteria, index)
        'End If
        strQuery = "Select SailingScheduleID, " & _
                   "PREVessel.Vessel_ID, " & _
                   "PreVessel.Vessel_Code, " & _
                   "PREVessel.Vessel as Vessel, " & _
                   "VoyNo, POL," & _
                   "Operator,Service,Capacity,Slot,Terminal1,Terminal2,Terminal3," & _
                  "ETD, ETA,ETAVoyNo," & _
                   "SAILINGSCHEDULE.Editable,SAILINGSCHEDULE.Continued,SAILINGSCHEDULE.Userupdate,SAILINGSCHEDULE.UpdateTime, SAILINGSCHEDULE.Approve "
        strQuery &= " From (SAILINGSCHEDULE inner JOIN Vessel as PREVessel On Prevessel.Vessel_ID=SAILINGSCHEDULE.Vessel_ID)"
        strQuery &= " Where SAILINGSCHEDULE.continued=1 "
        If argCriteria <> "" Then
            strQuery = strQuery + argCriteria
        End If


        Con.Open()
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ' Con.Open()
        Adapter.Fill(ds, "Sailing")
        Adapter.Fill(oTable, "Sailing")
        'oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdSailingSchedule.DataSource = ds.Tables(0) 'oTable
        If Me.dgdSailingSchedule.Enabled = False Then
            Me.dgdSailingSchedule.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If ds.Tables(0).Rows.Count > 0 Then
            Me.dgdSailingSchedule.Columns.Item("VesseL_Code").ToolTipText = "Hiện có:" + CStr(Me.dgdSailingSchedule.RowCount()) + " VesseL."
        End If
        If Me.dgdSailingSchedule.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        InsertAutoNumberToGrid(Me.dgdSailingSchedule)
        '------------vị trí BM
        If location >= 0 And location <= Me.dgdSailingSchedule.Rows.Count And Me.dgdSailingSchedule.Rows.Count > 0 Then
            Me.dgdSailingSchedule.Rows(location).Selected = True
            Me.dgdSailingSchedule.CurrentCell = Me.dgdSailingSchedule.Rows(location).Cells("VesseL_Code")
        End If
        '--------------------

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description & ", bạn nên dùng menu View để hiển thị hết toàn bộ thông tin trong Bảng dữ liệu, "))
        'Resume


    End Sub

    Sub QueryETA(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        Try

            Dim strQuery As String
            strQuery = "Select ETASCHEDULE.PortID,Port,Port_Code,ETAScheduleID,ETA,ETD,ETASCHEDULE.Editable,ETASCHEDULE.continued,ETASCHEDULE.Approve,ETASCHEDULE.UserUpdate,ETASCHEDULE.UpdateTime "
            strQuery &= " From ETASCHEDULE LEFT JOIN Port on  Port.Port_ID=ETASCHEDULE.PortID "
            strQuery &= " Where ETASCHEDULE.SailingScehduleID='" & mSailingID & "' And ETASCHEDULE.Continued=1 "
            If argCriteria <> "" Then
                strQuery &= argCriteria
            End If

            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim ds As New DataSet
            Con.Open()
            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            Dim dt As New DataSet
            Adapter.Fill(dt)
            Me.dgdETA.DataSource = dt.Tables(0)


            Me.Cursor = System.Windows.Forms.Cursors.Default

            If Me.dgdETA.RowCount() = 0 Then
                DisplayMessage(True, IIf(gLang = "E", "No data (ETA).", "Không có dữ liệu! (ETA)"))
            End If
            '------------vị trí BM
            If location >= 0 And location <= Me.dgdETA.Rows.Count And Me.dgdETA.Rows.Count > 0 Then
                Me.dgdETA.Rows(location).Selected = True
                Me.dgdETA.CurrentCell = Me.dgdETA.Rows(location).Cells(3)
            End If
            '--------------------
            InsertAutoNumberToGrid(Me.dgdETA)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmListSailingSchedule_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        'objUserSetting.SetCParm("frmListSailingSchedule.cboFind", Me.cboFind.Text)
        'objUserSetting.SetCParm("frmListSailingSchedule.cboVessel", Me.cboVessel.Text)
        'objUserSetting.SetCParm("frmListSailingSchedule.txtVesselVoyno", Me.txtVesselVoyno.Text)
        ''objUserSetting.SetCParm("frmListSailingSchedule.cboOceanVessel", Me.cboOceanVessel.Text)
        ''objUserSetting.SetCParm("frmListSailingSchedule.txtOceanVoyNo", Me.txtOceanVoyNo.Text)
        'objUserSetting.SetCParm("frmListSailingSchedule.dtpETD", Me.dtpETD.Text)
        ''objUserSetting.SetCParm("frmListSailingSchedule.dtpVesselETD", Me.dtpVesselETD.Text)




        'objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayVessel", Me.smnuDisplayVessel.Checked)
        'objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayvoyno", Me.smnuDisplayVoyNO.Checked)
        ''objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayOceanVessel", Me.smnuDisplayOceanVessel.Checked)
        ''objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayOceanVesselETD", Me.smnuDisplayOceanVesselETD.Checked)
        'objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayVesselETD", Me.smnuDisplayVesselETD.Checked)
        'objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayApprove", Me.smnuDisplayApprove.Checked)
        'objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        'objUserSetting.SetBParm("frmListSailingSchedule.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        Me.cmdCancel_Click(sender, e)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryService()
        Try
            Dim SQL As String
            SQL = "Select Distinct ServiceFeederId as ID,ServiceFeederCode as Data  "
            SQL &= " From ServiceFeeder "
            SQL &= " Where Continued=1 "
            SQL &= " Order By ServiceFeederCode"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboService.DisplayMember = "data"
            Me.cboService.ValueMember = "ID"
            Me.cboService.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmListSailingSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        SetDefaultGrid(Me.dgdETA, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdSailingSchedule, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        mStatus = "Normal"
        mSailingID = DefaultValue
        QueryService()
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdSailingSchedule)
       
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "Vessel", "Vessel")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "VoyNo", "VoyNo")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "OceanVessel", "OceanVessel")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "OceanVessel VoyNo", "OceanVessel VoyNo")
        'Me.cboFind.Items.Add(oItems)






        Dim cbo As ComboBox
        cbo = Me.cboVessel
        'QuerySailing()
        QueryVessel(cbo)
        'cbo = Me.cboOceanVessel
        'QueryVessel(cbo)
        cbo = Me.cboPort
        QueryPort(cbo)
        cbo = Me.cboPOL
        QueryPort(cbo)
        'cbo = Me.cboTranshipPort
        'QueryPort(cbo)
        cbo = Me.cboTerminal1
        QueryTerminal(cbo)
        cbo = Me.cboTerminal2
        QueryTerminal(cbo)
        cbo = Me.cboTerminal3
        QueryTerminal(cbo)
        'Me.cboFind.Text = objUserSetting.GetCParm("frmListSailingSchedule.cboFind", "Company")
        Me.cboVessel.Text = objUserSetting.GetCParm("frmListSailingSchedule.cboVessel")
        Me.txtVesselVoyno.Text = objUserSetting.GetCParm("frmListSailingSchedule.txtVesselVoyno")
        Me.dtpETD.Text = objUserSetting.GetCParm("frmListSailingSchedule.dtpETD")

        'Me.cboOceanVessel.Text = objUserSetting.GetCParm("frmListSailingSchedule.cboOceanVessel")
        'Me.txtOceanVoyNo.Text = objUserSetting.GetCParm("frmListSailingSchedule.txtOceanVoyNo")
        'Me.dtpVesselETD.Text = objUserSetting.GetCParm("frmListSailingSchedule.dtpVesselETD")
        
        'Me.smnuDisplayVessel.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayVessel")
        'Me.smnuDisplayVoyNO.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayVoyNO")
        ''Me.smnuDisplayOceanVessel.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayOceanVessel")
        ''Me.smnuDisplayOceanVesselVoyNo.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayOceanVesselVoyNo")
        'Me.smnuDisplayVesselETD.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayVesselETD")
        'Me.smnuDisplayApprove.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayAPPROVE")
        ''Me.smnuDisplayOceanVesselETD.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayOceanVesselETD")
        ''Me.smnuDisplayMarket.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayMarket")
        'Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayUserId")
        'Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmListSailingSchedule.smnuDisplayUpdateTime")


        Me.fraUpdate.Visible = False
        UpdateFrame()

        ReFormat()
        Exit Sub
Err:

    End Sub
    Private Sub SetMenu(ByRef argVisible As Boolean)
        On Error GoTo Err_Renamed
        Me.MenuStrip.Enabled = argVisible
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub reText(ByVal mStatus As String)
        If mStatus = "Normal" Then
            Me.Text = "Sailing Schedule "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Sailing Schedule -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Sailing Schedule -> Add."
        End If

    End Sub

    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" And UserRight(UserRightFrm, "Add") Then

            Me.fraUpdate.Visible = True
            Me.dgdSailingSchedule.Enabled = False
            mSailingID = DefaultValue
            ReFormat()
            SetMenu((False))
            mStatus = "Add"
            reText(mStatus)
            QueryETA()

        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.cboVessel.Text = FindIDValue(Me.cboVessel, Me.dgdSailingSchedule.Item("Vessel_ID", index).Value.ToString.Trim)

        Me.txtVesselVoyno.Text = Me.dgdSailingSchedule.Item("VoyNO", index).Value.ToString

        Me.txtOperator.Text = Me.dgdSailingSchedule.Item("OperatorSailing", index).Value.ToString
        Me.cboService.Text = Me.dgdSailingSchedule.Item("Service", index).Value.ToString
        Me.txtSlot.Text = Me.dgdSailingSchedule.Item("Slot", index).Value.ToString
        Me.cboTerminal1.Text = Me.dgdSailingSchedule.Item("Terminal1", index).Value.ToString
        Me.cboTerminal2.Text = Me.dgdSailingSchedule.Item("Terminal2", index).Value.ToString
        Me.cboTerminal3.Text = Me.dgdSailingSchedule.Item("Terminal3", index).Value.ToString
        Me.cboPOL.Text = Me.dgdSailingSchedule.Item("POL", index).Value.ToString
        Me.txtCapacity.Text = Me.dgdSailingSchedule.Item("Capacity", index).Value.ToString
        Me.dtpETD.Text = Me.dgdSailingSchedule.Item("ETD", index).Value.ToString
        Me.dtpETA.Text = Me.dgdSailingSchedule.Item("VesselETA", index).Value.ToString
        Me.txtETAVoyNo.Text = Me.dgdSailingSchedule.Item("ETAVoyNo", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Public Sub smnuEdit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuEdit.Click
        On Error GoTo Err_Renamed
        Dim Approve, EditTable, UsrRight As Boolean
        Dim index As Integer
        If Me.dgdSailingSchedule.Rows.Count > 0 Then
            index = Me.dgdSailingSchedule.CurrentRow.Index
        Else
            Exit Sub
        End If

        If index >= 0 Then
            Approve = Me.dgdSailingSchedule.Item("Approve", index).Value
            EditTable = Me.dgdSailingSchedule.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight(UserRightFrm, "Edit") Then


                Me.dgdSailingSchedule.Height = 306
                Me.dgdSailingSchedule.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))
                mSailingID = Me.dgdSailingSchedule.Item("SailingScheduleID", index).Value.ToString
                QueryETA()
                mStatus = "Edit"
                reText(mStatus)
                RefreshData(index)

            Else
                DisplayMessage(True, IIf(gLang = "E", IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."), "Bạn cần được cấp quyền."))
            End If
        End If
        QueryETA()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description & ", có thể đây là lỗi do bạn thao tác, xin chú ý đến các dữ liệu khi bạn nhập vào, "))
    End Sub

    '    Private Function CheckData() As Boolean
    '        On Error GoTo Err_Renamed
    '        Dim strMsg As String
    '        Dim strQuery As String
    '        CheckData = True
    '        strMsg = ""
    '        If mStatus = "Add" Then
    '            If mStatus = "Add" Then
    '                Dim rs As New ADODB.Recordset
    '                strQuery = "SELECT * "
    '                strQuery = strQuery & "FROM SailingSchedule "
    '                strQuery = strQuery & "WHERE Vessel_ID= '" & FindIDValue(Me.cboVessel, Me.cboVessel.Text) & "' And VoyNo Like'%" & Me.txtVesselVoyno.Text & "%' And Continued=1"
    '                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
    '                If Not rs.EOF Then
    '                    CheckData = False
    '                    rs.Close()
    '                    DisplayMessage(True, "This " & Me.cboVessel.Text & " - " & Me.txtVesselVoyno.Text & " had already in database")
    '                End If
    '            End If
    '        End If
    '        If strMsg <> "" Then
    '            DisplayMessage(True, strMsg)
    '        End If
    '        Exit Function
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Function


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
        Me.dgdSailingSchedule.Left = 10
        dgdSailingSchedule.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            dgdSailingSchedule.Height = Me.Height - Me.cmdOk.Height - 65 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            dgdSailingSchedule.Height = Me.Height - Me.cmdOk.Height - 115 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 20)
        fraUpdate.Top = Me.dgdSailingSchedule.Height + dgdSailingSchedule.Top

        Me.txtSailingSchedule.Width = Me.Width - 300

        'me.txtCompany.Width = Me.fraUpdate.Width - me.txtCompany.Left - 10
        'me.txtCuctomsLiquiDate.Width = Me.fraUpdate.Width - me.txtCuctomsLiquiDate.Left - 10
        'me.txtCompany.Width = Me.fraUpdate.Width -me.txtRepresentative.Left - 10

        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        'cmdOk.Top = fraUpdate.Bottom + 5
        'cmdCancel.Top = cmdOk.Top
        'txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10

        cmdFind.Left = Me.txtSailingSchedule.Left + Me.txtSailingSchedule.Width + 10
        txtSailingSchedule.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Function checkdata() As Boolean
        Try
            Dim i As Integer
            Dim strQuery As String
            strQuery = "Select * from SailingSchedule Where Vessel_ID='" & FindValueID(Me.cboVessel, Me.cboVessel.Text)
            strQuery &= "' And VoyNo='" & Strings.Replace(Strings.Replace(Me.txtVesselVoyno.Text.Trim, " ", ""), "-", "") & "'"
            strQuery &= " And Continued=1 And SailingScheduleID <>'" & mSailingID & "'"
            Dim rs As New ADODB.Recordset
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                rs.Close()
                Return False
            End If
            rs.Close()
            Return True

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Function
    Function FindVesselCode(ByVal ID As String) As String
        Try
            Dim SQL As String
            SQL = "Select * from Vessel Where Vessel_ID='" & ID & "'"
            Dim ds As New DataSet

            ds = ReadDataSet(SQL)
            If ds.Tables(0).Rows.Count = 0 Then
                Return ""
            End If
            Return ds.Tables(0).Rows(0).Item("Vessel_Code").ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub InsertBoardingAgent()
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim Temp() As String
            Temp = Me.cboVessel.Text.Split("-")
            If Temp.Length < 2 Then
                rs.Close()
                Return
            End If
            Dim Vessel, Code As String
            Vessel = Temp(0).Trim
            Code = Temp(1).Trim
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM BoardingAgent Where Vessel='" & Vessel & "' And ShipCode='" & Code & "' And VoyageNoOnArrival='" & Me.txtETAVoyNo.Text & "' and VoyageNoOnDeparture='" & Me.txtVesselVoyno.Text & "' And Continued=1 "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("BoardingagentID").Value = NewId()
                Else
                    rs.Close() 'nếu đã có rồi thì không theêm nữa
                    Return
                End If


                .Fields("Vessel").Value = Vessel
                .Fields("shipCode").Value = Code 'FindVesselCode(FindValueID(Me.cboVessel, Me.cboVessel.Text))
                '.Fields("OceanVesselID").Value = "{" & FindValueID(Me.cboOceanVessel, Me.cboOceanVessel.Text) & "}"
                '.Fields("TranShipPortID").Value = "{" & FindValueID(Me.cboTranshipPort, Me.cboTranshipPort.Text) & "}"
                .Fields("VoyageNoOnArrival").Value = Me.txtETAVoyNo.Text


                .Fields("VoyageNoOnDeparture").Value = Me.txtVesselVoyno.Text
                '.Fields("ServiceTerm").Value = Me.cboService.Text
                '.Fields("OperatorName").Value = Me.txtOperator.Text


                '.Fields("Capacity").Value = Me.txtCapacity.Text
                '.Fields("Slot").Value = Me.txtSlot.Text
                '.Fields("Terminal1").Value = Me.cboTerminal1.Text
                '.Fields("Terminal2").Value = Me.cboTerminal2.Text
                '.Fields("Terminal3").Value = Me.cboTerminal3.Text
                '.Fields("ETAVoyNo").Value = Me.txtETAVoyNo.Text
                '.Fields("ETA").Value = Me.dtpETA.Value.Date
                '.Fields("ETD").Value = Me.dtpETD.Value.Date
                '.Fields("OceanETD").Value = Me.dtpVesselETD.Value.Date


                .Update()

            End With
            rs.Close()
            'Me.dgdSailingSchedule.Enabled = True

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    
    Function CheckTransitExist(ByVal MotherSailingID As String, ByVal PortID As String) As Boolean
        Try
            Dim SQL As String
            SQL = "Select * from ETASCHEDULE "
            SQL &= " Where Continued=1 And SailingScehduleID='" & MotherSailingID & "' And PortID='" & PortID & "' "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then 'neu chua co thi false
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub InsertserviceTransitPort(ByVal Service As String)
        Try
            Dim SQL As String
            SQL = "select ServiceViaPort.* "
            SQL &= " from (ServiceViaPort LEFT JOIN ServiceFeeder On ServiceFeeder.ServiceFeederID=ServiceViaPort.ServiceID) "
            SQL &= " Where ServiceViaPort.Continued=1 And ServiceFeeder.ServiceFeederCode='" & Service.Trim & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return
            End If
            Dim ETA, ETD As Date
            'ETA = Me.dtpVesselETD.Value.Date.AddDays(dt.Rows(0).Item("NumberOfDayVia"))
            'ETD = ETA.AddDays(1)
            For i As Integer = 0 To dt.Rows.Count - 1
                ETA = Me.dtpETD.Value.Date.AddDays(dt.Rows(i).Item("NumberOfDayVia"))
                ETD = ETA.AddDays(1)
                SQL = "Insert into ETASCHEDULE(SailingScehduleID,PortID,ETA,ETD)"
                SQL &= " Values('" & mSailingID & "','" & dt.Rows(i).Item("ViaPortID").ToString & "','" & ETA & "','" & ETD & "')"
                If CheckTransitExist(mSailingID, dt.Rows(i).Item("ViaPortID").ToString) = False Then 'neu chua co thi them
                    InsertSQL(SQL)
                End If

            Next
            QueryETA()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strContainerOutboundNotifyId, pName, strSailingScheduleId As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        Dim Voyno As String
        If Me.cboTerminal1.Text = "" Then
            DisplayMessage(True, "The Terminal invalid, please check again!")
            Me.cboTerminal1.Focus()
            Return
        End If
        If Me.cboService.Text = "" Then
            DisplayMessage(True, "Service invalid, please check again!")
            Me.cboService.Focus()
            Return
        End If
        If Me.txtCapacity.Text = "" Then
            DisplayMessage(True, "Capacity invalid, please check again!")
            Me.txtCapacity.Focus()
            Return
        End If
        If Not IsNumeric(Me.txtSlot.Text) Or Me.txtSlot.Text = "" Then
            DisplayMessage(True, "Slot invalid, please check again!")
            Me.txtSlot.Focus()
            Return
        End If
        If Me.dgdSailingSchedule.RowCount > 0 And mStatus = "Edit" Then
            index = Me.dgdSailingSchedule.CurrentRow.Index
        End If
        If checkdata() = False Then
            DisplayMessage(True, "This schedule already in database")
            Return
        End If
        'If Me.cboOceanVessel.Text = "" Then
        '    DisplayMessage(True, "You have to Input the Ocean Vessel Name ")
        '    Me.cboOceanVessel.Focus()
        '    Return
        'End If
        If Me.cboVessel.Text = "" Then
            DisplayMessage(True, "You have to Input the Vessel Name ")
            Me.cboVessel.Focus()
            Return
        End If

        If (mStatus = "Add" Or mStatus = "Edit") Then
            If mStatus = "Edit" Then
                CopyValues("SailingSchedule", "SailingScheduleID", mSailingID)
            End If
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM SailingSchedule "
            strQuery = strQuery & "WHERE  SailingScheduleID= '" & mSailingID & "' AND SailingScheduleID <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("SailingScheduleID").Value = NewId()
                End If
                mSailingID = .Fields("SailingScheduleID").Value
                .Fields("Vessel_Id").Value = "{" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "}"
                '.Fields("OceanVesselID").Value = "{" & FindValueID(Me.cboOceanVessel, Me.cboOceanVessel.Text) & "}"
                '.Fields("TranShipPortID").Value = "{" & FindValueID(Me.cboTranshipPort, Me.cboTranshipPort.Text) & "}"
                .Fields("VoyNo").Value = Strings.Replace(Strings.Replace(Me.txtVesselVoyno.Text.Trim, " ", ""), "-", "")
                Voyno = Strings.Replace(Strings.Replace(Me.txtVesselVoyno.Text.Trim, " ", ""), "-", "")

                .Fields("POL").Value = Me.cboPOL.Text
                .Fields("Service").Value = Me.cboService.Text
                .Fields("Operator").Value = Me.txtOperator.Text
                .Fields("Capacity").Value = Me.txtCapacity.Text
                .Fields("Slot").Value = Me.txtSlot.Text
                .Fields("Terminal1").Value = Me.cboTerminal1.Text
                .Fields("Terminal2").Value = Me.cboTerminal2.Text
                .Fields("Terminal3").Value = Me.cboTerminal3.Text
                .Fields("ETAVoyNo").Value = Me.txtETAVoyNo.Text
                .Fields("ETA").Value = Me.dtpETA.Value.Date
                .Fields("ETD").Value = Me.dtpETD.Value.Date
                '.Fields("OceanETD").Value = Me.dtpVesselETD.Value.Date


                .Update()

            End With
            rs.Close()
            Me.dgdSailingSchedule.Enabled = True

            InsertserviceTransitPort(Me.cboService.Text)
            If mFilter = "" Then
                QuerySailing(" and voyno ='" & Voyno & "' ", , index)
            Else
                QuerySailing(mFilter)

            End If

            'Me.fraUpdate.Visible = False
            ReFormat()
            'SetMenu((True))
            'mStatus = "Normal"
            'reText(mStatus)
            'blnUpdated = True
            If mStatus = "Add" Then
                InsertBoardingAgent()
            End If
            Dim strQueryWOy As String
            Dim dem As Integer = 0
            If mStatus = "Edit" Then
                If ConfirmMessage(True, "Do you want to change WeekOFYear in Booking ?") = MsgBoxResult.Ok Then
                    Dim rschangeWOy As New ADODB.Recordset
                    strQueryWOy = "SELECT * from containeroutboundnotify "
                    strQueryWOy = strQueryWOy & " WHERE  SailingScheduleID= '" & mSailingID & "' and continued=1 "
                    rschangewoy.Open(strQuerywoy, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    While Not rschangeWOy.EOF
                        rschangeWOy.Fields("weekofyear").Value = WeekOfYear(Me.dtpETD.Value)
                        rschangeWOy.MoveNext()
                        dem += 1
                    End While
                    DisplayMessage(True, dem.ToString + " Booking changed.")
                    rschangeWOy.Close()
                End If

            End If
            '--------- kiem tra co port chua
            Dim strQuery1 As String
            Dim report As New ADODB.Recordset
            strQuery1 = "SELECT * from ETASchedule"
            strQuery1 = strQuery1 & " WHERE  SailingScehduleID= '" & mSailingID & "' AND SailingScehduleID <> '" & DefaultValue & "' "
            report.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If report.EOF Then
                DisplayMessage(True, "Please check Transite port!")
            End If
            report.Close()

            '----------
            'Me.smnuEdit_Click(sender, e)
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, "Xin kiểm tra lại các dữ liệu!"))
    End Sub
    Public Function WeekOfYear(ByVal etd As Date) As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        If etd.ToString <> "" Then
            WeekOfYear = myCal.GetWeekOfYear(etd, myCWR, myFirstDOW)
        Else
            WeekOfYear = 0
        End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function
    Private Sub dgdSailing_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSailingSchedule.CellContentClick
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        On Error GoTo Err_Renamed
        Dim index As Integer
        If Me.dgdSailingSchedule.Rows.Count > 0 Then
            index = Me.dgdSailingSchedule.CurrentRow.Index
        Else
            Exit Sub
        End If
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If ColIndex >= 0 And RowIndex >= 0 Then
            If Me.dgdSailingSchedule.Columns(ColIndex).Name = "Approve" And Me.dgdSailingSchedule.CurrentCellAddress().Y = index Then
                Call ApproveSailing()
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub ApproveSailing()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer
        If Me.dgdSailingSchedule.Rows.Count > 0 Then
            index = Me.dgdSailingSchedule.CurrentRow.Index
        Else
            Exit Sub
        End If

        Dim strQuery As String
        If Not Me.dgdSailingSchedule.Item("Editable", index).Value Or Not UserRight(UserRightFrm, "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            QuerySailing(, , index)
        Else
            Dim rs As New ADODB.Recordset
            strQuery = "Select * from SailingSchedule where" + " SailingScheduleID= '" & Me.dgdSailingSchedule.Item("SailingScheduleID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QuerySailing(, , index)
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
        'strQuery = "Select count(*) cnt from BillOfLading WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "'  "
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEmpty = (rs.Fields("cnt").Value = 0)

        'rs.Close()
        'strQuery = "Select * from ContainerOutboundNotify WHERE ContainerOutBoundNotifyId = '" & Me.dgdContianerOutboundNotify.Item("ContainerOutBoundNotifyId", index).Value.ToString & "' And UserId='DBO'"
        'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'blnEOF = rs.EOF
        'rs.Close()
        'If Not blnEOF Then
        '    DisplayMessage(True, "Sorry, The ContainerOutboundNotify can not be removed.")
        '    Exit Sub
        'End If
        'che tam vi chua co quan he voi Dulieu khac
        'If Not blnEmpty Then
        '    DisplayMessage(True, "The ContainerOutboundNotify can not be removed. There are transactions that relate to this customer.")
        '    Exit Sub
        'End If
        If Not IsNothing(Me.dgdSailingSchedule.Item("Approve", index)) Then
            If Me.dgdSailingSchedule.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdSailingSchedule.Item("Editable", index)) Then
            If Not Me.dgdSailingSchedule.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight(UserRightFrm, "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Vessel: " & Me.dgdSailingSchedule.Item("Vessel", index).Value.ToString & " - " & Me.dgdSailingSchedule.Item("VoyNo", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQueryCommodityList = "Select * from SailingSchedule where" + " SailingScheduleID= '" & Me.dgdSailingSchedule.Item("SailingScheduleID", index).Value.ToString & "'"
                rs.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                rs.Requery()
                Me.dgdSailingSchedule.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdSailingSchedule.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()
                'blnUpdated = True
            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
      Me.dgdSailingSchedule.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim location As Integer
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdSailingSchedule.SelectedRows(i).Index)
                location = Me.dgdSailingSchedule.SelectedRows(i).Index
            Next i
        End If
        Me.QuerySailing(mFilter, , location)
    End Sub
    Public Sub smnuExit_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuExit.Click
        On Error GoTo Err_Renamed
        Me.Close()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub ReFreshFreight(ByVal b As Boolean)
        On Error GoTo Err_named
        'Me.cboContainerType.Enabled = b
        Me.cboPort.Enabled = b
        Me.DtpETAETA.Enabled = b
        Me.dtpETDPort.Enabled = b
        Me.cmdOkP.Enabled = b
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub ctmnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuAdd.Click
        On Error GoTo Err_named
        If mSailingID = DefaultValue Then
            DisplayMessage(True, "Please check again! ")
            Return
        End If
        mStatusP = "Add"
        ETAid = DefaultValue
        'OceanVessel_ID = DefaultValue
        ReFreshFreight(True)

        'Me.cmdOKP.Text = "Add"
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuEdit.Click
        On Error GoTo Errname
        Dim index As Integer

        If Me.dgdETA.Rows.Count > 0 Then
            index = Me.dgdETA.CurrentRow.Index
        Else
            Exit Sub
        End If
        If Not IsNothing(Me.dgdETA.Item("ETAApprove", index).Value) And UserRight(UserRightFrm, "Edit") Then
            If Me.dgdETA.Item("ETAApprove", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        mStatusP = "Edit"

        ReFreshFreight(True)
        ETAid = Me.dgdETA.Item("ETAScheduleID", index).Value.ToString
        'OceanVessel_ID=me.dgdETA(
        Me.cboPort.Text = FindIDValue(Me.cboPort, Me.dgdETA.Item("ETAPortID", index).Value.ToString.Trim)
        Me.DtpETAETA.Text = Me.dgdETA.Item("ETA", index).Value.ToString
        Me.dtpETDPort.Text = Me.dgdETA.Item("ETDPort", index).Value.ToString
        Exit Sub
Errname:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub DeleteRowP(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery As String
        Dim blnEmpty As Boolean
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.BindingContext(oTable).Position

        If Not IsNothing(Me.dgdETA.Item("ETAApprove", index).Value) Then
            If Me.dgdETA.Item("ETAApprove", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdETA.Item("ETAEditable", index).Value) Then
            If Not Me.dgdETA.Item("ETAEditable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight(UserRightFrm, "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            strMesg = "Delete the Detail of : " & Me.dgdETA.Item("Port_Code", index).Value.ToString
            If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                strQuery = "Select * from ETASCHEDULE where ETASCHEDULEID='" & Me.dgdETA.Item("ETASCHEDULEID", index).Value.ToString & "'"
                rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("continued").Value = 0
                rs.Update()

                Me.dgdETA.Rows(index).DefaultCellStyle.ForeColor = Color.White
                Me.dgdETA.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                rs.Close()

            End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub ctmnuDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmnuDel.Click
        Dim selectedRowCount As Integer = _
  Me.dgdETA.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount >= 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRowP(Me.dgdETA.SelectedRows(i).Index)
            Next i
        Else
            Return
        End If
        Dim index As Integer = 0
        If Me.dgdSailingSchedule.RowCount > 0 Then
            index = Me.dgdSailingSchedule.CurrentRow.Index
        End If
        QueryETA(, , )
    End Sub

    Public Sub ApprovePrice()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim rs As New ADODB.Recordset
        Dim index As Integer = Me.dgdETA.CurrentRow.Index
        Dim strQuery As String
        If Not Me.dgdETA.Item("ETAEditable", index).Value Or Not UserRight(UserRightFrm, "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))

        Else
            ' strQuery = "Select * from FREIGHT_CHARGE_Master where" + " BillOfLadingId= '" & oTablePrice.Rows(index).Item("BillOfLadingId").ToString & "' AND Cargo_ID='" & oTablePrice.Rows(index).Item("Cargo_ID").ToString & "' AND Items='" & oTablePrice.Rows(index).Item("Items").ToString & "'"
            strQuery = "select * from ETASchedule where ETAScheduleID='" & Me.dgdETA.Item("ETAScheduleID", index).Value.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rs.Fields("Approve").Value
            rs.Update("Approve", Approve)
            rs.Close()
        End If
        QueryETA()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdETA_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdETA.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdETA.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdETA.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        'MsgBox(Me.dgdETA.CurrentCellAddress.X)
        If Me.dgdETA.Columns(ColIndex).Name = "ETAApprove" And Me.dgdETA.CurrentCellAddress().Y = RowIndex Then
            Call ApprovePrice()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Function checkDataTranship() As Boolean
        Try
            Dim i As Integer
            'Dim strQuery As String
            'strQuery = "Select * from ETASchedule Where PortID='" & FindValueID(Me.cboPort, Me.cboPort.Text)
            'strQuery &= "' And day(ETA) ='" & Me.DtpETAETA.Value.Day & "' And Month(ETA)='" & Me.DtpETAETA.Value.Month & "' And Year(ETA)='" & Me.DtpETAETA.Value.Year & "'"
            'strQuery &= " And Continued=1 And ETAScheduleID<>'" & ETAid & "'"

            'Dim rs As New ADODB.Recordset
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'If Not rs.EOF Then
            '    rs.Close()
            '    Return False
            'End If
            'rs.Close()
            'Return True
            If Me.dgdETA.RowCount = 0 Then
                Return True

            Else
                If mStatusP = "Add" Then
                    For i = 0 To Me.dgdETA.RowCount - 1
                        If UCase(Me.dgdETA.Item("Port_Code", i).Value.ToString) = UCase(Strings.Right(Me.cboPort.Text, 5)) Then
                            Return False
                        End If
                    Next
                End If

            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function


    Private Sub cmdOKP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkP.Click
        On Error GoTo Err_Renamed
        If mSailingID = DefaultValue Then
            DisplayMessage(True, "Xin vui lòng nhập tàu Feeder và tàu Ocean, sau đó mới nhập cảng đến!")
            Exit Sub
        End If

        If checkDataTranship() = False Then
            MsgBox("This Tranship Port has already in database")
            Return
        End If

        If mStatusP = "Add" Or mStatusP = "Edit" Then
            If mStatus = "Edit" Then
                CopyValues("ETASchedule", "ETAScheduleID", ETAid)
            End If

            Dim strQuery, str, Cargo_ID As String
            Dim rs As New ADODB.Recordset
            Dim index As Integer = 0
            If Me.dgdETA.RowCount > 0 Then
                index = Me.dgdETA.CurrentRow.Index()
            End If

            'If indexBill >= 0 Then
            '    Cargo_ID = Me.dgdDetailBillOfLading.Item("Cargo_ID", indexBill).Value.ToString
            'Else
            '    'Cargo_ID = DefaultValue
            '    Exit Sub
            'End If
            'strQuery = "Select * from FREIGHT_CHARGE_IB where charge_ID='" & FindValueID(Me.cboItems, Me.cboItems.Text) & "'"
            'strQuery = strQuery & " and BLIB_id='" & BillID & "' And Continued=1 And Container_Type='" & Me.cboContainerType.Text.Trim & "'"
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

            'If Not rs.EOF And mStatusP = "Add" Then
            '    DisplayMessage(True, "This Item Had Added ")
            '    Exit Sub
            'End If
            'rs.Close()
            strQuery = "Select * from ETASchedule where ETAScheduleID='" & ETAid & "'And Continued=1 "
            ' strQuery = strQuery & " And BL_ID='" & BillID & "'"

            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If mSailingID Like "*{*" Then
                mSailingID = mSailingID
            Else
                mSailingID = "{" + mSailingID + "}"
            End If

            With rs
                If mStatusP = "Add" Then
                    .AddNew()
                    .Fields("ETAScheduleID").Value = NewId()
                    .Fields("SailingScehduleID").Value = mSailingID
                End If

                .Fields("PortID").Value = "{" & FindValueID(Me.cboPort, Me.cboPort.Text) & "}"
                .Fields("ETA").Value = Me.DtpETAETA.Value.Date
                .Fields("ETD").Value = Me.dtpETDPort.Value.Date
                .Update()

                'Dim msg As String = oTableDetailBillOfLading.Rows(index).Item("ContainersNo").ToString
                'DisplayMessage(True, "Giá của Container :" & msg & " của Bill số : " & Me.txtBillOfLadingP.Text & " đã được nhập giá !")

            End With
            rs.Close()

            '-----------------

            'mStatusP = "Normal"
            ReFreshFreight(False)
            Me.dgdETA.Enabled = True
            mStatusP = "Normal"
            Me.cmdOkP.Enabled = False
            QueryETA(, , index)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub cmdCancelP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelP.Click
        On Error GoTo Err_named
        ReFreshFreight(False)
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        Me.fraUpdate.Visible = False
        ReFormat()
        SetMenu((True))
        mStatus = "Normal"
        reText(mStatus)
        Me.dgdSailingSchedule.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    'Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '    UpdateFrame()
    'End Sub
    'Private Sub smnuDisplayVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayVessel.Checked = Not Me.smnuDisplayVessel.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayvoyNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayVoyNO.Checked = Not Me.smnuDisplayVoyNO.Checked()
    '    UpdateFrame()
    'End Sub


    'Private Sub smnuDisplayETDVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayVesselETD.Checked = Not Me.smnuDisplayVesselETD.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayOceanVessel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayOceanVessel.Checked = Not Me.smnuDisplayOceanVessel.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayOceanVesselVoyNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayOceanVesselVoyNo.Checked = Not Me.smnuDisplayOceanVesselVoyNo.Checked
    '    UpdateFrame()
    'End Sub
    'Private Sub smnuDisplayOceanVesselETD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayOceanVesselETD.Checked = Not Me.smnuDisplayOceanVesselETD.Checked
    '    UpdateFrame()
    'End Sub

    'Private Sub smnuDisplayMarket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayMarket.Checked = Not Me.smnuDisplayMarket.Checked
    '    UpdateFrame()

    'End Sub

    'Private Sub smnuDisplayApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.smnuDisplayApprove.Checked = Not Me.smnuDisplayApprove.Checked
    '    UpdateFrame()

    'End Sub
    Private Sub UpdateFrame()
        On Error GoTo Err_Renamed

        'Me.dgdSailingSchedule.Columns.Item("SailingScheduleID").Visible = False
        'Me.dgdSailingSchedule.Columns.Item("Vessel").Visible = Me.smnuDisplayVessel.Checked
        'Me.dgdSailingSchedule.Columns.Item("VoyNo").Visible = Me.smnuDisplayVoyNO.Checked
        ''Me.dgdSailingSchedule.Columns.Item("OceanVessel").Visible = Me.smnuDisplayOceanVessel.Checked
        ''Me.dgdSailingSchedule.Columns.Item("OceanVesselVOyNo").Visible = Me.smnuDisplayOceanVesselVoyNo.Checked
        'Me.dgdSailingSchedule.Columns.Item("ETD").Visible = Me.smnuDisplayVesselETD.Checked
        ''Me.dgdSailingSchedule.Columns.Item("OceanETD").Visible = Me.smnuDisplayOceanVesselETD.Checked
        ''Me.dgdSailingSchedule.Columns.Item("Market").Visible = Me.smnuDisplayMarket.Checked

        'Me.dgdSailingSchedule.Columns.Item("Approve").Visible = Me.smnuDisplayApprove.Checked

        'Me.dgdSailingSchedule.Columns.Item("UserUpdate").Visible = Me.smnuDisplayUserId.Checked
        'Me.dgdSailingSchedule.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtSailingSchedule.Text)
        If Me.txtSailingSchedule.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtSailingSchedule.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdSailingSchedule)
            '    Select Case cboFind.Text
            '        Case "Vessel"
            '            QuerySailing(" AND ( PreVessel.Vessel LIKE '" & strFilter & "') ")
            '            Me.dgdSailingSchedule.Columns.Item("Vessel").Visible = Me.smnuDisplayVessel.Checked
            '        Case "VoyNo"
            '            QuerySailing(" AND (VoyNo LIKE '" & strFilter & "')")
            '            UpdateFrame()
            '        Case "OceanVessel"
            '            QuerySailing(" AND (Vessel.Vessel LIKE '" & strFilter & "') ")
            '            If Me.smnuDisplayOceanVessel.Checked = False Then
            '                Me.smnuDisplayOceanVessel.Checked = True
            '            End If
            '            Me.dgdSailingSchedule.Columns.Item("Oceanvessel").Visible = Me.smnuDisplayOceanVessel.Checked
            '        Case "Oceanvessel VoyNo"
            '            QuerySailing("AND (OceanVesselVoyNo LIKE '" & strFilter & "') ")
            '            Me.dgdSailingSchedule.Columns.Item("OceanVesselVoyNo").Visible = Me.smnuDisplayOceanVesselVoyNo.Checked
            '        Case "Market"
            '            QuerySailing("AND (Market LIKE '" & strFilter & "') ")

            '            Me.dgdSailingSchedule.Columns.Item("Market").Visible = Me.smnuDisplayOceanVesselVoyNo.Checked
            '    End Select
            'Else
            '    QuerySailing()
        End If
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
                QuerySailing("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub DrawTitle(ByVal ws As Excel._Worksheet, ByVal nRow As Integer)
        ws.Range("A" & nRow, "A" & nRow + 1).Merge()
        ws.Range("A" & nRow).Value2 = "VESSEL NAME"
        ws.Range("A" & nRow).ColumnWidth = 18.86
        drawBorder(ws, 5, "A" & nRow, "A" & nRow + 1)
        AlignHorVer(ws, "A" & nRow)

        ws.Range("B" & nRow, "B" & nRow + 1).Merge()
        ws.Range("B" & nRow).Value2 = "VOY"
        drawBorder(ws, 5, "B" & nRow, "B" & nRow + 1)
        ws.Range("B" & nRow).ColumnWidth = 7.71
        AlignHorVer(ws, "B" & nRow)

        ws.Range("C" & nRow).Value2 = "ETD"
        drawBorder(ws, 5, "C" & nRow)
        ws.Range("C" & nRow).ColumnWidth = 7.71
        AlignHorVer(ws, "C" & nRow)

        ws.Range("C" & nRow + 1).Value2 = "HCM"
        drawBorder(ws, 5, "C" & nRow + 1)
        ws.Range("C" & nRow + 1).ColumnWidth = 7.71
        AlignHorVer(ws, "C" & nRow + 1)

        ws.Range("D" & nRow, "D" & nRow + 1).Merge()
        ws.Range("D" & nRow).Value2 = "CONNECTING VESSEL"
        drawBorder(ws, 5, "D" & nRow, "D" & nRow + 1)
        ws.Range("D" & nRow).ColumnWidth = 27.29
        AlignHorVer(ws, "D" & nRow)

        ws.Range("E" & nRow, "F" & nRow).Merge()
        ws.Range("E" & nRow).Value2 = "ETD T/S"
        drawBorder(ws, 5, "E" & nRow, "F" & nRow)
        AlignHorVer(ws, "E" & nRow)

        ws.Range("E" & nRow + 1).Value2 = "HKG"
        drawBorder(ws, 5, "E" & nRow + 1)
        ws.Range("E" & nRow + 1).ColumnWidth = 7.14
        AlignHorVer(ws, "E" & nRow + 1)

        ws.Range("F" & nRow + 1).Value2 = "PKG"
        drawBorder(ws, 5, "F" & nRow + 1)
        ws.Range("F" & nRow + 1).ColumnWidth = 7.14
        AlignHorVer(ws, "F" & nRow + 1)
    End Sub

    Sub Export1()
        Try
            If oTable.Tables(0).Rows.Count = 0 Then
                Return
            End If
            Dim app As Excel.Application
            app = New Excel.Application()

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet)

            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet

            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim i As Integer
            Dim nRow As Integer = 5

            ws.Range("A" & 2).Value2 = Me.Text
            Dim row As Integer = oTable.Tables(0).Rows.Count
            For i = 0 To row - 1
                DrawTitle(ws, nRow)
                ws.Range("A" & nRow + 3).Value = oTable.Tables(0).Rows(i).Item("Vessel")
                ws.Range("B" & nRow + 3).Value = oTable.Tables(0).Rows(i).Item("VoyNo")
                ws.Range("C" & nRow + 3).Value = oTable.Tables(0).Rows(i).Item("ETD")
                'ws.Range("D" & nRow + 3).Value = oTable.Tables(0).Rows(i).Item("OceanVessel")
                'ws.Range("F" & nRow + 3).Value = oTable.Tables(0).Rows(i).Item("OceanETD")

                Dim strQuery As String
                strQuery = "Select ETASCHEDULE.PortID,Port,Port_Code,ETAScheduleID,ETA,ETASCHEDULE.Editable,ETASCHEDULE.continued,ETASCHEDULE.Approve,ETASCHEDULE.UserUpdate,ETASCHEDULE.UpdateTime "
                strQuery &= " From ETASCHEDULE LEFT JOIN Port on  Port.Port_ID=ETASCHEDULE.PortID "
                strQuery &= " Where ETASCHEDULE.SailingScehduleID='" & oTable.Tables(0).Rows(i).Item("SailingScheduleID").ToString & "' And ETASCHEDULE.Continued=1 "
                strQuery &= " Order by ETA "
                Dim dst As New DataSet
                dst = ReadDataSet(strQuery)
                Dim cell As String = "F"
                For j As Integer = 0 To dst.Tables(0).Rows.Count - 1
                    cell = SetCell(cell)
                    ws.Range(cell & nRow + 1).Value = dst.Tables(0).Rows(j).Item("Port")
                    ws.Range(cell & nRow + 1).Cells.Columns.AutoFit()
                    drawBorder(ws, 5, cell & nRow + 1)
                    ws.Range(cell & nRow + 3).Value = dst.Tables(0).Rows(j).Item("ETA")
                Next
                ws.Range("G" & nRow, cell & nRow).Merge()
                ws.Range("G" & nRow).Value = "ETA"
                drawBorder(ws, 5, "G" & nRow)
                AlignHorVer(ws, "G" & nRow, cell & nRow + 1)
                AlignHorVer(ws, "A" & nRow + 3, cell & nRow + 3)
                'drawBorder(ws, 5, "A" & nRow + 2, cell & nRow + 4)
                ws.Range("A" & nRow, cell & nRow + 4).BorderAround(, Excel.XlBorderWeight.xlMedium)
                drawBorder(ws, 7, "A" & nRow + 2, cell & nRow + 4, 2)
                nRow += 6
            Next

            Dim d As Date = CDate(Getdate())
            Dim path = "c:\" & Me.Text & " D" & d.Date & " H" & d.Hour & " M" & d.Minute & " S" & d.Second & " .xls"

            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            MsgBox("Complete")
            app.Visible = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            Dim strSql As String = "Select "
            Export1()
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub dgdSailingSchedule_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdSailingSchedule.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdSailingSchedule)
    End Sub

    Private Sub dgdETA_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdETA.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdETA)
    End Sub

    Private Sub txtSailingSchedule_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSailingSchedule.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub cxtsmnuPortTranship_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPortTranship.Click
    '    Try
    '        gSForm = Me.Name
    '        gSCombo = Me.cboTranshipPort.Name
    '        Dim frm As New frmListPort
    '        frm.ShowDialog(Me)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub cxtsmnuPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cxtsmnuPort.Click
        Try
            gSForm = Me.Name
            gSCombo = Me.cboPort.Name
            Dim frm As New frmListPort
            frm.ShowDialog(Me)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cboVessel_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVessel.Leave
        Dim strQuery As String
        strQuery = "Select * from vessel Where Vessel_ID='" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "'"
        'strQuery &= "' And VoyNo='" & Strings.Replace(Strings.Replace(Me.txtVesselVoyno.Text.Trim, " ", ""), "-", "") & "'"
        strQuery &= " And Continued=1 "
        Dim rs As New ADODB.Recordset
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            Me.txtCapacity.Text = rs.Fields("TEU_FEU").Value.ToString
        End If
        rs.Close()
    End Sub

    'Private Sub cboTranshipPort_Leave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim strSql As String
    '    Me.cboTranshipPort.Text = Trim(UCase(Me.cboTranshipPort.Text))
    '    strSql = "Select Port_Code as Code From Port Where Continued=1"
    '    If Me.cboTranshipPort.FindStringExact(Me.cboTranshipPort.Text) = -1 Then
    '        Me.cboTranshipPort.Text = FindBetter_new("Code", strSql, Me.cboTranshipPort.Text)
    '        If Me.cboTranshipPort.FindStringExact(Me.cboTranshipPort.Text) = -1 Then
    '            DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '            Me.cboTranshipPort.Focus()
    '        End If
    '    End If

    'End Sub


    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Dim strQuery As String
        strQuery = "Select * from vessel Where Vessel_ID='" & FindValueID(Me.cboVessel, Me.cboVessel.Text) & "'"
        'strQuery &= "' And VoyNo='" & Strings.Replace(Strings.Replace(Me.txtVesselVoyno.Text.Trim, " ", ""), "-", "") & "'"
        strQuery &= " And Continued=1 "
        Dim rs As New ADODB.Recordset
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            Me.txtCapacity.Text = rs.Fields("TEU_FEU").Value.ToString
        End If
        rs.Close()
    End Sub

    Private Sub dgdSailingSchedule_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdSailingSchedule.KeyDown
        If e.KeyCode = Keys.Delete Then
            Me.smnuDelete_Click(sender, e)
        End If
    End Sub

    Private Sub dtpETA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpETA.KeyDown
        If e.KeyCode = Keys.Delete Then
            ctmnuDel_Click(sender, e)
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        Dim cbo As ComboBox
        cbo = Me.cboVessel
        'QuerySailing()
        QueryVessel(cbo)
    End Sub
End Class