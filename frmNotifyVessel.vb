Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class frmNotifyVessel
#Region "comment"
    '    Dim mStatus As String
    '    Dim sql = "select * from notifyvessel"
    '    Dim Con As New SqlClient.SqlConnection(strconnDG)
    '#Region "Function"
    '    Sub setNULL()
    '        Me.txtCode.Text = ""
    '        Me.TxtName.Text = ""
    '        Me.txtCommodity.Text = ""
    '        Me.txtNote.Text = ""
    '        Me.txtRemarks.Text = ""
    '    End Sub
    '    Function checkdata(ByVal code As String) As Boolean
    '        Try
    '            Dim sql1 As String
    '            sql1 = "select * from notifyvessel where code=N'" & code & "'"
    '            Dim da As New SqlDataAdapter(sql1, Con)
    '            Dim dt As New DataTable
    '            da.Fill(dt)

    '            If dt.Rows.Count > 0 Then
    '                Dim err As String = "Mã này đã có trong CSDL"
    '                If gLang = "E" Then
    '                    err = "This Code had already in Database"

    '                End If
    '                MsgBox(err & vbCrLf, MsgBoxStyle.Critical)
    '                Return False
    '            End If
    '            If code = "" Then
    '                Dim err As String
    '                err = "Mã Không Được để trống"
    '                If gLang = "E" Then
    '                    err = "Code Not Allow Null Value"
    '                End If
    '                MsgBox(err, MsgBoxStyle.Critical)
    '                Return False
    '            End If
    '            Return True
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '            Return False
    '        End Try
    '    End Function
    '    Sub edit()

    '        Dim update As String
    '        Dim i As Integer
    '        i = Me.dgdVessel.CurrentRow.Index
    '        update = "Update notifyvessel set name=N'" & Me.TxtName.Text & "',"
    '        update &= "ETA='" & Me.dtpETA.Value.ToString & "',ETB='" & Me.dtpETB.Value.ToString & "',"
    '        update &= "ETD='" & Me.dtpETD.Value.ToString & "',BTH='" & Me.dtpBTH.Value.ToString & "',"
    '        update &= "Note=N'" & Me.txtNote.Text & "',Commodity=N'" & Me.txtCommodity.Text & "',"
    '        update &= "remarks=N'" & Me.txtRemarks.Text & "' "
    '        update &= "where code=N'" & Me.txtCode.Text & "'"
    '        Dim cmd As New SqlCommand(update, Con)
    '        cmd.CommandType = CommandType.Text
    '        cmd.CommandText = update
    '        cmd.ExecuteNonQuery()
    '        GetData(sql)
    '    End Sub
    '    Sub add()
    '        Dim insert As String
    '        Dim sql As String = "select * from notifyvessel"
    '        insert = "Insert into notifyvessel(code,name,ETA,ETB,ETD,BTH,Commodity,Remarks,Note)"
    '        insert &= " values(N'" & Me.txtCode.Text & "',N'" & Me.TxtName.Text & "','"
    '        insert &= Me.dtpETA.Value.ToString & "','" & Me.dtpETB.Value.ToString & "','" & Me.dtpETD.Value.ToString & "','"
    '        insert &= Me.dtpBTH.Value.ToString & "',N'" & Me.txtCommodity.Text & "',N'" & Me.txtRemarks.Text & "',N'"
    '        insert &= Me.txtNote.Text & "')"
    '        Dim cmd As New SqlCommand(insert, Con)
    '        cmd.CommandType = CommandType.Text
    '        cmd.CommandText = insert
    '        cmd.ExecuteNonQuery()
    '        GetData(sql)
    '        'setNULL()
    '    End Sub
    '    Sub del()
    '        Dim index As Integer
    '        index = Me.dgdVessel.CurrentRow.Index
    '        Dim warn As String
    '        warn = "bạn muốn xoá " & Me.dgdVessel.Item("Vesselname", index).Value.ToString
    '        If gLang = "E" Then
    '            warn = "Are you Sure To Delete " & Me.dgdVessel.Item("Vesselname", index).Value.ToString
    '        End If
    '        If MsgBox(warn, MsgBoxStyle.YesNo Or MsgBoxStyle.Exclamation, "warning") = MsgBoxResult.Yes Then
    '            Dim del As String
    '            del = "update notifyvessel set Continued=0 where Code='" & Me.dgdVessel.Item("vessel_code", index).Value.ToString & "'"
    '            Dim cmd As New SqlCommand(del, Con)
    '            cmd.CommandType = CommandType.Text
    '            cmd.CommandText = del
    '            cmd.ExecuteNonQuery()
    '            Me.dgdVessel.Rows.Remove(Me.dgdVessel.Rows.Item(index))
    '        End If
    '    End Sub
    '    Private Sub GetData(ByVal strsql As String)
    '        Try

    '            Dim dt As New DataTable
    '            Dim da As SqlDataAdapter
    '            Dim row As DataRow
    '            Dim i As Integer = 0
    '            da = New SqlDataAdapter(strsql, Con)
    '            If da IsNot Nothing Then
    '                da.Fill(dt)
    '                If dt.Rows.Count = 0 Then
    '                    MsgBox("không có dữ liệu")
    '                    Return
    '                End If
    '                Me.dgdVessel.Rows.Clear()
    '                Me.dgdVessel.Rows.Add(dt.Rows.Count)
    '                For Each row In dt.Rows
    '                    Me.dgdVessel.Item("Vessel_Id", i).Value = row.Item("NotifyVesselId").ToString
    '                    Me.dgdVessel.Item("vessel_code", i).Value = row.Item("code").ToString
    '                    Me.dgdVessel.Item("vesselname", i).Value = row.Item("Name").ToString
    '                    Me.dgdVessel.Item("ETA", i).Value = row.Item("ETA").ToString
    '                    Me.dgdVessel.Item("ETB", i).Value = row.Item("ETB").ToString
    '                    Me.dgdVessel.Item("ETD", i).Value = row.Item("ETD").ToString
    '                    Me.dgdVessel.Item("BTH", i).Value = row.Item("BTH").ToString
    '                    Me.dgdVessel.Item("Note", i).Value = row.Item("Note").ToString
    '                    Me.dgdVessel.Item("Commodity", i).Value = row.Item("Commodity").ToString
    '                    Me.dgdVessel.Item("remarks", i).Value = row.Item("Remarks").ToString
    '                    Me.dgdVessel.Item("UserId", i).Value = row.Item("UserId").ToString
    '                    Me.dgdVessel.Item("UpdateTime", i).Value = row.Item("UpdateTime").ToString
    '                    Me.dgdVessel.Item("Editable", i).Value = row.Item("Editable")
    '                    Me.dgdVessel.Item("Approve", i).Value = row.Item("Approve")
    '                    Me.dgdVessel.Item("Continued", i).Value = row.Item("Continued")
    '                    i += 1
    '                Next
    '            End If
    '            da.Dispose()
    '            dt.Clear()
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    End Sub
    '    Sub setmenu(ByVal status As Boolean)
    '        Me.MenuStrip.Enabled = status
    '    End Sub
    '    Private Sub ReFormat()
    '        Try
    '            If Me.WindowState = System.Windows.Forms.FormWindowState.Minimized Then Exit Sub
    '            Me.Top = frmMain.MainMenu1.Height + frmMain.ToolStrip1.Height + 18
    '            Me.Left = 0
    '            Me.Height = frmMain.Height  - 10 - Me.Top
    '            Me.Width = frmMain.Width - 8
    '            dgdVessel.Width = (Me.Width - 20)
    '            If Me.Width > 610 Then
    '                dgdVessel.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
    '            Else
    '                dgdVessel.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
    '            End If
    '            fraUpdate.Width = (Me.Width - 30)
    '            fraUpdate.Top = dgdVessel.Height + dgdVessel.Top
    '            Me.txtVessel.Width = Me.Width - 300


    '            txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10
    '            cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
    '            cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
    '            cmdFind.Left = Me.txtVessel.Left + Me.txtVessel.Width + 10
    '            txtVessel.Width = Me.Width - 297

    '            Exit Sub
    '        Catch ex As Exception
    '            MsgBox(msgErr(Me, Err.Description))
    '        End Try
    '        'Resume
    '    End Sub
    '#End Region

    '    Private Sub frmNotifyVessel_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    '        Try
    '            frmnotifyclosed = True
    '            Con.Close()
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    End Sub

    '    Private Sub frmNotifyVessel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        ReFormat()
    '        Me.cboFind.Items.Add("ALL")
    '        Me.cboFind.Items.Add("CODE")
    '        Me.cboFind.Items.Add("NAME")
    '        Me.cboFind.Text = "ALL"
    '        Con.Open()
    '        GetData(sql)
    '    End Sub
    '#Region "MenuStrip"
    '    Private Sub smnuAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuAdd.Click
    '        Me.txtCode.Enabled = True
    '        setmenu(False)
    '        setNULL()
    '        Me.fraUpdate.Visible = True
    '        mStatus = "Insert"
    '        ReFormat()
    '    End Sub

    '    Private Sub smnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuEdit.Click
    '        Me.txtCode.Enabled = False
    '        Me.fraUpdate.Visible = True
    '        setmenu(False)
    '        mStatus = "Edit"
    '        ReFormat()
    '        Dim index As Integer
    '        index = Me.dgdVessel.CurrentRow.Index
    '        Me.txtCode.Text = Me.dgdVessel.Item("vessel_code", index).Value
    '        Me.TxtName.Text = Me.dgdVessel.Item("vesselname", index).Value
    '        Me.dtpETA.Text = Me.dgdVessel.Item("ETA", index).Value
    '        Me.dtpETB.Text = Me.dgdVessel.Item("ETB", index).Value
    '        Me.dtpETD.Text = Me.dgdVessel.Item("ETD", index).Value
    '        Me.dtpBTH.Text = Me.dgdVessel.Item("BTH", index).Value
    '        Me.txtNote.Text = Me.dgdVessel.Item("Note", index).Value
    '        Me.txtCommodity.Text = Me.dgdVessel.Item("Commodity", index).Value
    '        Me.txtRemarks.Text = Me.dgdVessel.Item("remarks", index).Value
    '    End Sub
    '    Private Sub smnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDelete.Click
    '        Try

    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    End Sub
    '    Private Sub smnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExit.Click
    '        Me.Close()
    '        mStatus = ""
    '    End Sub


    '#Region "ViewMenu"
    '    Private Sub smnuDisplayName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayName.Click
    '        Me.smnuDisplayName.Checked = Not Me.smnuDisplayName.Checked
    '        Me.VesselName.Visible = Me.smnuDisplayName.Checked
    '    End Sub

    '    Private Sub smnuDisplayCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCode.Click
    '        Me.smnuDisplayCode.Checked = Not Me.smnuDisplayCode.Checked
    '        Me.Vessel_Code.Visible = Me.smnuDisplayCode.Checked
    '    End Sub

    '    Private Sub smnuDisplayETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayETA.Click
    '        Me.smnuDisplayETA.Checked = Not Me.smnuDisplayETA.Checked
    '        Me.ETA.Visible = Me.smnuDisplayETA.Checked
    '    End Sub

    '    Private Sub smnuDisplayETD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayETD.Click
    '        Me.smnuDisplayName.Checked = Not Me.smnuDisplayName.Checked
    '        Me.ETD.Visible = Me.smnuDisplayName.Checked
    '    End Sub

    '    Private Sub smnuDisplayETB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayETB.Click
    '        Me.smnuDisplayETB.Checked = Not Me.smnuDisplayETB.Checked
    '        Me.ETB.Visible = Me.smnuDisplayETB.Checked
    '    End Sub

    '    Private Sub smnuDisplayBTH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBTH.Click
    '        Me.smnuDisplayBTH.Checked = Not Me.smnuDisplayBTH.Checked
    '        Me.BTH.Visible = Me.smnuDisplayBTH.Checked
    '    End Sub

    '    Private Sub smnuDisplayNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNote.Click
    '        Me.smnuDisplayNote.Checked = Not Me.smnuDisplayNote.Checked
    '        Me.Note.Visible = Me.smnuDisplayNote.Checked
    '    End Sub

    '    Private Sub smnuDisplayCommodity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCommodity.Click
    '        Me.smnuDisplayCommodity.Checked = Not Me.smnuDisplayCommodity.Checked
    '        Me.Commodity.Visible = Me.smnuDisplayCommodity.Checked
    '    End Sub

    '    Private Sub smnuDisplayremarks_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayremarks.Click
    '        Me.smnuDisplayremarks.Checked = Not Me.smnuDisplayremarks.Checked
    '        Me.Remarks.Visible = Me.smnuDisplayremarks.Checked
    '    End Sub

    '    Private Sub smnuDisplayUserId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUserId.Click
    '        Me.smnuDisplayUserId.Checked = Not Me.smnuDisplayUserId.Checked
    '        Me.UserId.Visible = Me.smnuDisplayUserId.Checked
    '    End Sub

    '    Private Sub smnuDisplayUpdateTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayUpdateTime.Click
    '        Me.smnuDisplayUpdateTime.Checked = Not Me.smnuDisplayUpdateTime.Checked
    '        Me.UpdateTime.Visible = Me.smnuDisplayUpdateTime.Checked
    '    End Sub
    '#End Region

    '#End Region

    '    Private Sub frmNotifyVessel_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
    '        ReFormat()
    '    End Sub

    '    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
    '        Try
    '            Me.fraUpdate.Visible = False
    '            ReFormat()
    '            setmenu(True)
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    End Sub

    '    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
    '        Try

    '            If Me.txtVessel.Text = "" Then
    '                Return
    '            End If
    '            Dim sql1 As String
    '            sql1 = sql & " where " & Me.cboFind.Text & " like N'" & MakeFilter(Me.txtVessel.Text) & "'"
    '            'If Me.cboFind.Text = "ALL" Then
    '            '    sql1 = sql
    '            'End If

    '            Me.dgdVessel.Rows.Clear()

    '            GetData(sql1)

    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try
    '    End Sub

    '    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
    '        Try
    '            If String.Compare("Edit", mStatus) = 0 Then
    '                edit()
    '            ElseIf String.Compare("Insert", mStatus) = 0 Then
    '                If checkdata(Me.txtCode.Text) Then
    '                    add()
    '                End If
    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.ToString)
    '        End Try


    '    End Sub

    '    Private Sub dgdVessel_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdVessel.CellClick
    '        If (Me.fraUpdate.Visible = True) And (String.Compare("Edit", mStatus) = 0) Then
    '            Dim frm As New frmNotifyVessel
    '            smnuEdit_Click(frm, New System.EventArgs)
    '        End If
    '    End Sub

    '    Private Sub frmNotifyVessel_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '        ReFormat()
    '    End Sub

    '    Private Sub cboFind_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.SelectedIndexChanged
    '        If Me.cboFind.Text = "ALL" Then
    '            GetData(sql)
    '        End If

    '    End Sub
#End Region
    Inherits System.Windows.Forms.Form

    Dim rsvesselList As New ADODB.Recordset
    Dim mStatus, mFilter As String
    Public blnUpdated As Boolean
    Public mvesselId As String
    '------------------
    Public oTable As DataTable
    Public ds As New DataSet

    Const strvesselSelect As String = "SELECT " & _
    "notifyvesselId, " & _
    "Vessel_Code , " & _
    "Vessel.Vessel,VoyNo, " & _
    "ETA , " & _
    "ETB , " & _
    "ETD , " & _
    "BTH , " & _
    "Note , " & _
    "Commodity, " & _
    "Remarks, " & _
    "NotifyVessel.Approve, " & _
    "NotifyVessel.Continued, " & _
    "NotifyVessel.Editable, " & _
    "NotifyVessel.UserId, " & _
    "NotifyVessel.Updatetime "
    Const strvesselOrder1 As String = _
           " ORDER BY Vessel_code Desc "
    Const strvesselOrder2 As String = _
        " ORDER BY NotifyVessel.UpdateTime Desc "
    Private Function CheckData() As Boolean
        On Error GoTo Err_Renamed
        Dim strMsg As String
        Dim strQuery As String
        CheckData = True
        If mStatus = "Add" Then
            If Me.txtVesselName.Text = "" Then
                CheckData = False
                DisplayMessage(True, "The code not allow NULL value")
            End If
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM notifyVessel "
            strQuery = strQuery & "WHERE Vessel_ID = '" & FindValueID(Me.cboVesselCode, Me.cboVesselCode.Text) & " ' and Upper(VoyNo)='" & UCase(Trim(Me.txtVoyNo.Text)) & "' And Continued=1"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not rs.EOF Then
                CheckData = False
                rs.Close()
                DisplayMessage(True, "This Notify  had already in database")
            End If
        End If
        strMsg = ""
        Dim strvesselId As String
        If mStatus = "Add" Then
            strvesselId = DefaultValue
        End If

        If Len(Me.cboVesselCode.Text) = 0 Then
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
        Me.dgdvessel.Enabled = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdFind_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFind.Click
        On Error GoTo Err_Renamed
        Dim strFilter As String
        strFilter = MakeFilter(Me.txtVessel.Text)
        If Me.txtVessel.Text.Trim <> "" And FindValueID(Me.cboFind, Me.cboFind.Text.Trim) <> "" Then
            FindCombo(Me.txtVessel.Text.Trim, FindValueID(Me.cboFind, Me.cboFind.Text.Trim), Me.dgdVessel)
            '    Select Case cboFind.Text
            '        Case "ALL"
            '            Queryvessel()
            '        Case "CODE"
            '            Queryvessel(" AND (Vessel.Vessel_Code  LIKE '" & strFilter & "') " & mFilter)
            '            If Me.smnuDisplayCode.Checked = False Then
            '                Me.smnuDisplayCode.Checked = True
            '            End If
            '            Me.dgdVessel.Columns.Item("CODE").Visible = Me.smnuDisplayCode.Checked
            '        Case "NAME"
            '            Queryvessel(" AND (Vessel.Vessel LIKE '" & strFilter & "' )")
            '            If Me.smnuDisplayName.Checked = False Then
            '                Me.smnuDisplayName.Checked = True
            '            End If

            '        Case "VoyNo"
            '            Queryvessel(" AND (VoyNo LIKE '" & strFilter & "' )")
            '            If Me.smnuDisplayName.Checked = False Then
            '                Me.smnuDisplayName.Checked = True
            '            End If

            '            UpdateFrame()
            '    End Select
            'Else
            '    Queryvessel(mFilter)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOK_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strvesselId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer

        If Me.oTable.Rows.Count > 0 And mStatus = "Edit" Then
            index = Me.dgdVessel.CurrentRow.Index
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM Notifyvessel "
            strQuery = strQuery & "WHERE notifyvesselId = '" & mvesselId & "' AND notifyvesselId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("notifyvesselId").Value = NewId()
                End If
                .Fields("Vessel_ID").Value = "{" & FindValueID(Me.cboVesselCode, Me.cboVesselCode.Text) & "}"

                strvesselId = .Fields("notifyvesselId").Value

                .Fields("VoyNo").Value = UCase(Trim(Me.txtVoyNo.Text))

                .Fields("ETA").Value = UCase(Trim(Me.dtpETA.Value.Date))
                .Fields("ETB").Value = UCase(Trim(Me.dtpETB.Value.Date))
                .Fields("ETD").Value = UCase(Trim(Me.dtpETD.Value.Date))
                .Fields("BTH").Value = UCase(Trim(Me.dtpBTH.Value.Date))
                .Fields("Note").Value = UCase(Trim(Me.txtNote.Text))
                '.Fields("Commodity").Value = UCase(Trim(Me.txtCommodity.Text))
                .Fields("Remarks").Value = UCase(Trim(Me.txtRemarks.Text))
                '.Fields("Continued").Value = 1
                .Update()
            End With
            rs.Close()
            Me.dgdVessel.Enabled = True
            If mStatus = "Edit" Then
                Queryvessel(, 1, index)
            Else
                Queryvessel(, 15, 0)
            End If
            Me.fraUpdate.Visible = False
            mStatus = "Normal"
            reText(mStatus)
            ReFormat()
            SetMenu((True))
        End If


        blnUpdated = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Sub QueryVesselCode()
        On Error GoTo ERR_NAMED
        Dim id As String = "Vessel_ID"
        Dim value As String = "Vessel_CODE"
        Dim strQuery As String = "Select Vessel_ID,Vessel_CODE from Vessel where CONTINUED=1"
        loadDataToObject(Me.cboVesselCode, strQuery, id, value)
        Exit Sub
ERR_NAMED:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub notifyvessel_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err_Renamed
        mStatus = "Normal"
        blnUpdated = False
        mvesselId = DefaultValue
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.fraUpdate.Visible = False
        'khai bao đối tượng oItems để thêm dữ liệu vào Combobox
        LoadComboFind(Me.cboFind, Me.dgdVessel)
        'Dim oItems As PDSAListItemString
        'Me.cboFind.Items.Clear()
        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "ALL", "ALL")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "CODE", "CODE")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "NAME", "NAME")
        'Me.cboFind.Items.Add(oItems)

        'oItems = New PDSAListItemString
        'oItems.Value = IIf(gLang = "E", "VoyNo", "VoyNo")
        'Me.cboFind.Items.Add(oItems)


        'Me.cboFind.Text = objUserSetting.GetCParm("frmNotifyVessel.cboFind", "NAME")
        mFilter = objUserSetting.GetCParm("frmNotifyVessel.mFilter")
        Me.txtVesselName.Text = objUserSetting.GetCParm("frmNotifyVessel.txtCODE")
        Me.cboVesselCode.Text = objUserSetting.GetCParm("frmNotifyVessel.txtName")
        Me.dtpETA.Text = objUserSetting.GetCParm("frmNotifyVessel.dtpETA")
        Me.dtpETB.Text = objUserSetting.GetCParm("frmNotifyVessel.dtpETB")
        Me.dtpETD.Text = objUserSetting.GetCParm("frmNotifyVessel.dtpETD")
        Me.dtpBTH.Text = objUserSetting.GetCParm("frmNotifyVessel.dtpBTH")
        Me.txtNote.Text = objUserSetting.GetCParm("frmNotifyVessel.txtnote")
        Me.txtRemarks.Text = objUserSetting.GetCParm("frmNotifyVessel.txtremarks")

        Queryvessel(mFilter, , 15)
        QueryVesselCode()

        If gOptCurProfile <> "CSCL_IOB" Then
            objProfile.Profile(gOptCurProfile, Me.Name, "Get")
        End If

        Me.smnuDisplayName.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayName")
        Me.smnuDisplayCode.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayCode")
        Me.smnuDisplayETA.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayETA")
        Me.smnuDisplayETB.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayETB")
        Me.smnuDisplayETD.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayETD")
        Me.smnuDisplayBTH.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayBTH")
        Me.smnuDisplayCommodity.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayCommodity")
        Me.smnuDisplayNote.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayNote")
        Me.smnudisplayApprove.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayApprove")
        Me.smnuDisplayremarks.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayremarks")
        Me.smnuDisplayUserId.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayUserId")
        Me.smnuDisplayUpdateTime.Checked = objUserSetting.GetBParm("frmNotifyVessel.smnuDisplayUpdateTime")
        UpdateFrame()
        Me.Height = CShort(ctrFrmMain.Height * 0.9)
        Me.Width = CShort(ctrFrmMain.Width * 0.85)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub notifyvessel_Resize(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Resize
        On Error GoTo Err_Renamed
        'ReFormat()
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub frmListCommodity_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error GoTo Err_Renamed
        'objUserSetting.SaveDataGridColumnWidth(Me.dgdCommodity.Name, Me.Name)
        objUserSetting.SetCParm("frmNotifyVessel.cboFind", Me.cboFind.Text)
        objUserSetting.SetCParm("frmNotifyVessel.txtvessel", Me.txtVessel.Text)
        objUserSetting.SetCParm("frmNotifyVessel.txtCODE", Me.txtVesselName.Text)
        objUserSetting.SetCParm("frmNotifyVessel.txtNAME", Me.cboVesselCode.Text)
        objUserSetting.SetCParm("frmNotifyVessel.DtpETA", Me.dtpETA.Text)
        objUserSetting.SetCParm("frmNotifyVessel.DtpETB", Me.dtpETB.Text)
        objUserSetting.SetCParm("frmNotifyVessel.DtpETD", Me.dtpETD.Text)
        objUserSetting.SetCParm("frmNotifyVessel.DtpBTH", Me.dtpBTH.Text)
        objUserSetting.SetCParm("frmNotifyVessel.TxtNote", Me.txtNote.Text)
        objUserSetting.SetCParm("frmNotifyVessel.mFilter", mFilter)

        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayName", Me.smnuDisplayName.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayCode", Me.smnuDisplayCode.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayApprove", Me.smnudisplayApprove.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayBTH", Me.smnuDisplayBTH.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayCommodity", Me.smnuDisplayCommodity.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayETA", Me.smnuDisplayETA.Checked)

        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayETB", Me.smnuDisplayETB.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayETD", Me.smnuDisplayETD.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayNote", Me.smnuDisplayNote.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayRemarks", Me.smnuDisplayremarks.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayUserId", Me.smnuDisplayUserId.Checked)
        objUserSetting.SetBParm("frmNotifyVessel.smnuDisplayUpdateTime", Me.smnuDisplayUpdateTime.Checked)
        frmnotifyclosed = True
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    '==========MakeQuery==========

    Private Function MakeQueryvessel(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryvessel = strvesselSelect
        ' MakeQueryvessel = MakeQueryvessel & ", (SELECT count(*) FROM BillOfLading  WHERE notifyvessel.notifyvessel_Id = BillOfLading.vessel_Id) AS NumOfTransaction "
        MakeQueryvessel = MakeQueryvessel & " FROM (notifyvessel LEFT JOIN Vessel On NotifyVessel.Vessel_ID=Vessel.Vessel_ID) "
        MakeQueryvessel = MakeQueryvessel & "WHERE (notifyvesselId = '" & DefaultValue & "') "

        MakeQueryvessel = MakeQueryvessel & "OR ("
        MakeQueryvessel = MakeQueryvessel & "NotifyVessel.Continued = 1 "
        MakeQueryvessel = MakeQueryvessel & ") "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryvessel = MakeQueryvessel & argCriteria
        End If
        'If index = 1 Then ' 
        '    MakeQueryvessel = MakeQueryvessel & strvesselOrder1
        'ElseIf index = 15 Then ' 
        '    MakeQueryvessel = MakeQueryvessel & strvesselOrder2
        'End If
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function
    '==========Menu==========
    Public Function Codevessel() As Integer
        Dim rsCount As New ADODB.Recordset
        Dim code As Integer
        rsCount.Open("select Count(Code) as CountNo from notifyvessel", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        code = rsCount.Fields("CountNo").Value
        Return code
    End Function
    Public Sub smnuAdd_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuAdd.Click
        On Error GoTo Err_Renamed
        If mStatus = "Normal" Then
            Me.txtVesselName.Enabled = True
            Me.fraUpdate.Visible = True
            ReFormat()
            SetMenu((False))
            mvesselId = DefaultValue
            mStatus = "Add"
            reText(mStatus)
        Else
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub Approvevessel()
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.dgdVessel.CurrentRow.Index
        Dim strQueryvesselList As String
        If Not Me.dgdVessel.Item("Editable", index).Value Or Not UserRight("frmNotifyVessel", "Approve") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
            Queryvessel(, , index)
        Else
            strQueryvesselList = "Select * from notifyvessel where" + " notifyvesselId= '" & Me.dgdVessel.Item("notifyvesselId", index).Value.ToString & "'"
            rsvesselList.Open(strQueryvesselList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            Approve = Not rsvesselList.Fields("Approve").Value
            rsvesselList.Update("Approve", Approve)
            rsvesselList.Close()
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
        strQuery = "Select * from notifyvessel WHERE notifyvesselId = '" & Me.dgdVessel.Item("notifyvesselId", index).Value.ToString & "' And UserId='DBO' "
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        blnEOF = rs.EOF
        rs.Close()
        If Not blnEOF Then
            DisplayMessage(True, "Sorry, The vessel can not be removed.")
            Exit Sub
        End If
        If Not IsNothing(Me.dgdVessel.Item("Approve", index)) Then
            If Me.dgdVessel.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdVessel.Item("Editable", index)) Then
            If Not Me.dgdVessel.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        'If Not UserRight("notifyvessel", "Delete") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        'Else
        strMesg = "Delete the vessel: " & Me.dgdVessel.Item("VesselName", index).Value.ToString
        If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            strQueryCommodityList = "Select * from notifyvessel where" + " notifyvesselId= '" & Me.dgdVessel.Item("notifyvesselId", index).Value.ToString & "'"
            rsvesselList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rsvesselList.Fields("continued").Value = 0
            rsvesselList.Update()

            rsvesselList.Requery()
            Me.dgdVessel.Rows(index).DefaultCellStyle.ForeColor = Color.White
            Me.dgdVessel.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            rsvesselList.Close()
            blnUpdated = True
        End If
        ' End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Public Sub smnuDelete_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDelete.Click
        Dim selectedRowCount As Integer = _
       Me.dgdVessel.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If selectedRowCount > 0 Then
            Dim sb As New System.Text.StringBuilder()
            Dim i As Integer
            For i = 0 To selectedRowCount - 1
                DeleteRow(Me.dgdVessel.SelectedRows(i).Index)
            Next i
        End If
        Me.Queryvessel()
    End Sub

    Public Sub smnuDisplayName_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayName.Click
        Me.smnuDisplayName.Checked = Not Me.smnuDisplayName.Checked
        UpdateFrame()
    End Sub
    Private Sub smnuDisplayETA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayETA.Click
        Me.smnuDisplayETA.Checked = Not Me.smnuDisplayETA.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayETD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayETD.Click
        Me.smnuDisplayETD.Checked = Not Me.smnuDisplayETD.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayETB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayETB.Click
        Me.smnuDisplayETB.Checked = Not Me.smnuDisplayETB.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayBTH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayBTH.Click
        Me.smnuDisplayBTH.Checked = Not Me.smnuDisplayBTH.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayNote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayNote.Click
        Me.smnuDisplayNote.Checked = Not Me.smnuDisplayNote.Checked
        UpdateFrame()
    End Sub

    Private Sub smnuDisplayCommodity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCommodity.Click
        Me.smnuDisplayCommodity.Checked = Not Me.smnuDisplayCommodity.Checked
        UpdateFrame()
    End Sub
    Public Sub smnuDisplayApprove_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnudisplayApprove.Click
        Me.smnudisplayApprove.Checked = Not Me.smnudisplayApprove.Checked
        UpdateFrame()
    End Sub

    Public Sub smnuDisplayreMarks_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles smnuDisplayremarks.Click
        Me.smnuDisplayremarks.Checked = Not Me.smnuDisplayremarks.Checked
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
        If Me.dgdVessel.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdVessel.CurrentRow.Index
        If index >= 0 Then
            Approve = Me.dgdVessel.Item("Approve", index).Value
            EditTable = Me.dgdVessel.Item("Editable", index).Value
            If mStatus = "Normal" And Not Approve And EditTable And UserRight("frmnotifyvessel", "Edit") And Not Me.dgdVessel.Rows(index).DefaultCellStyle.ForeColor = Color.White Then
                Me.dgdVessel.Height = 306
                Me.dgdVessel.Enabled = False
                Me.txtVesselName.Enabled = False
                Me.fraUpdate.Visible = True
                ReFormat()
                SetMenu((False))

                mvesselId = Me.dgdVessel.Item("notifyvesselId", index).Value.ToString
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
            Me.Text = "Notify Vessel "
        ElseIf mStatus = "Edit" Then
            Me.Text = "Notify Vessel -> Edit."
        ElseIf mStatus = "Add" Then
            Me.Text = "Notify Vessel -> Add."
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

    Private Sub Queryvessel(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryvessel()
        Else
            strQuery = MakeQueryvessel(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        Adapter.Fill(ds, "Notifyvessel")
        oTable = ds.Tables(0)
        'hien thi ra grid 
        Me.dgdVessel.DataSource = ds.Tables("Notifyvessel")
        If Me.dgdVessel.Enabled = False Then
            Me.dgdVessel.Enabled = True
        End If

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTable.Rows.Count > 0 Then
            Me.dgdVessel.Columns.Item("Code").ToolTipText = "Hiện có:" + CStr(Me.dgdVessel.RowCount()) + " Notify Vessel"
        End If
        If Me.dgdVessel.RowCount() = 0 Then
            DisplayMessage(True, IIf(gLang = "E", "No data.", "Không có dữ liệu!"))
        End If
        '------------vị trí BM
        If location > 0 And location <= Me.dgdVessel.Rows.Count And Me.dgdVessel.Rows.Count > 0 Then
            Me.dgdVessel.Rows(location).Selected = True
            Me.dgdVessel.CurrentCell = Me.dgdVessel.Rows(location).Cells(3)
        End If
        '--------------------
        InsertAutoNumberToGrid(Me.dgdVessel)
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

        Me.dgdVessel.Columns.Item("notifyvesselId").Visible = False
        Me.dgdVessel.Columns.Item("Code").Visible = Me.smnuDisplayCode.Checked
        Me.dgdVessel.Columns.Item("vesselname").Visible = Me.smnuDisplayName.Checked
        Me.dgdVessel.Columns.Item("ETA").Visible = Me.smnuDisplayETA.Checked
        Me.dgdVessel.Columns.Item("ETB").Visible = Me.smnuDisplayETB.Checked
        Me.dgdVessel.Columns.Item("ETD").Visible = Me.smnuDisplayETD.Checked
        Me.dgdVessel.Columns.Item("BTH").Visible = Me.smnuDisplayBTH.Checked
        Me.dgdVessel.Columns.Item("Note").Visible = Me.smnuDisplayNote.Checked
        Me.dgdVessel.Columns.Item("commodity").Visible = Me.smnuDisplayCommodity.Checked
        Me.dgdVessel.Columns.Item("Approve").Visible = Me.smnudisplayApprove.Checked
        Me.dgdVessel.Columns.Item("Remarks").Visible = Me.smnuDisplayremarks.Checked
        Me.dgdVessel.Columns.Item("UserId").Visible = Me.smnuDisplayUserId.Checked
        Me.dgdVessel.Columns.Item("UpdateTime").Visible = Me.smnuDisplayUpdateTime.Checked
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
        Me.dgdVessel.Width = (Me.Width - 20)
        If Me.Width > 610 Then
            Me.dgdVessel.Height = Me.Height - 60 - IIf(fraUpdate.Visible, fraUpdate.Height + 35, 40) '> 7000
        Else
            Me.dgdVessel.Height = Me.Height - 110 - IIf(fraUpdate.Visible, fraUpdate.Height + 5, 40) ' < 7000
        End If
        fraUpdate.Width = (Me.Width - 30)
        fraUpdate.Top = dgdVessel.Height + dgdVessel.Top '+ 100

        Me.txtVessel.Width = Me.Width - 300

        'Me.TxtName.Width = Me.fraUpdate.Width - Me.TxtName.Left - 10
        'Me.txtPersonInCharge.Width = Me.fraUpdate.Width - Me.txtPersonInCharge.Left - 10
        'me.DtpETA.Width = Me.fraUpdate.Width - me.DtpETA.Left - 10



        txtRemarks.Width = Me.fraUpdate.Width - Me.txtRemarks.Left - 10
        'Me.txtCommodity.Width = txtRemarks.Width
        'cmdCancel.Left = Me.fraUpdate.Width - cmdCancel.Width - 10
        'cmdOK.Left = cmdCancel.Left - cmdOK.Width - 10
        cmdFind.Left = Me.txtVessel.Left + Me.txtVessel.Width + 10
        txtVessel.Width = Me.Width - 297

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub dgdVessel_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdVessel.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdVessel.RowCount = 0 Then
            Return
        End If
        Dim index As Integer = Me.dgdVessel.CurrentRow.Index

        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdVessel.Columns(ColIndex).Name = "Approve" And Me.dgdVessel.CurrentCellAddress().Y = index Then
            Call Approvevessel()
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdVessel_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdVessel.ColumnHeaderMouseClick
        '        Dim index As Integer
        On Error GoTo Err_Renamed
        '        index = e.ColumnIndex()
        '        'DisplayMessage(True, index)
        '        If index <> 1 And index <> 15 Then
        '            Exit Sub
        '        Else
        '            Queryvessel("", index)
        '        End If
        InsertAutoNumberToGrid(Me.dgdVessel)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dgdvessel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdvessel.KeyDown
        Dim selectedRowCount As Integer = _
        Me.dgdVessel.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If e.KeyCode = Keys.Delete Then
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdVessel.SelectedRows(i).Index)
                Next i
            End If
            Queryvessel()
        End If
    End Sub
    Private Sub cboFind_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFind.TextChanged
        If Me.cboFind.FindStringExact(Me.cboFind.Text) = -1 Then
            Me.cboFind.SelectedIndex = 0
            Me.cboFind.Text = CType(Me.cboFind.SelectedItem, PDSAListItemString).Value
        End If
    End Sub

    Private Sub smnuDisplayCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDisplayCode.Click
        Me.smnuDisplayCode.Checked = Not Me.smnuDisplayCode.Checked
        UpdateFrame()
    End Sub
    Private Sub RefreshData(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.txtVesselName.Text = Me.dgdVessel.Item("vesselname", index).Value.ToString
        Me.txtVoyNo.Text = Me.dgdVessel.Item("VoyNo", index).Value.ToString
        Me.cboVesselCode.Text = Me.dgdVessel.Item("Code", index).Value.ToString
        Me.dtpETA.Text = Me.dgdVessel.Item("ETA", index).Value.ToString
        Me.dtpETB.Text = Me.dgdVessel.Item("ETB", index).Value.ToString
        Me.dtpETD.Text = Me.dgdVessel.Item("ETD", index).Value.ToString
        Me.dtpBTH.Text = Me.dgdVessel.Item("BTH", index).Value.ToString
        'Me.txtCommodity.Text = Me.dgdVessel.Item("Commodity", index).Value.ToString
        Me.txtNote.Text = Me.dgdVessel.Item("Note", index).Value.ToString
        Me.txtRemarks.Text = Me.dgdVessel.Item("Remarks", index).Value.ToString
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub notifyvessel_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        'ReFormat()
    End Sub

    Private Sub cboVesselName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboVesselCode.Leave
        On Error GoTo Err_Renamed
        Dim strSql, shipper_code As String

        strSql = "Select Vessel_Code From Vessel Where Continued=1"
        If Me.cboVesselCode.FindStringExact(Me.cboVesselCode.Text) = -1 Then
            Me.cboVesselCode.Text = FindBetter_new("Vessel_Code", strSql, Me.cboVesselCode.Text)
            If Me.cboVesselCode.FindStringExact(Me.cboVesselCode.Text) = -1 Then

                DisplayMessage(True, "The Vessel is invalid, please check and correct it.")
                Me.cboVesselCode.Focus()
            End If
        End If

        Exit Sub
Err_Renamed:
    End Sub

    Private Sub cboVesselName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVesselCode.SelectedIndexChanged
        Dim VesselID As String
        VesselID = FindValueID(Me.cboVesselCode, Me.cboVesselCode.Text)
        If VesselID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "select * from Vessel where Vessel_ID='" & VesselID & "'"

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------

            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                'name = table.Rows(0).Item("Shipper_1").ToString + "  " + table.Rows(0).Item("Shipper_2").ToString + "  " + table.Rows(0).Item("Shipper_3").ToString + "  " + table.Rows(0).Item("Shipper_4").ToString + "  " + table.Rows(0).Item("Shipper_5").ToString + "  " + table.Rows(0).Item("Shipper_6").ToString
                'Me.txtVoyNo.Text = table.Rows(0).Item("VOYAGE").ToString
                Me.txtVesselName.Text = table.Rows(0).Item("Vessel").ToString
            End If
        End If
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                Queryvessel("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub smnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExportExcel.Click
        Try
            If oTable.Rows.Count > 0 Then
                ExportExecel(Me.dgdVessel, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub txtVessel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVessel.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                Me.cmdFind.PerformClick()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class

