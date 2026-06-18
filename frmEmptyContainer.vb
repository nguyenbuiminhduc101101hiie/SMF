Public Class frmEmptyContainer
    Dim strQuery As String
    Dim rs As New ADODB.Recordset
    Private Sub frmEmptyContainer_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CursorChanged
        Me.Cursor = Cursors.Default
    End Sub
    Sub QueryContainer_type()
        Try
            Dim strQuery As String = "Select Distinct Container_Type From CargoIb Where BLIB_ID='" & gBillInboundID & "' And Continued=1"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            Dim dt As New DataTable
            If dt.Rows.Count > 0 Then
                dt.Clear()
            End If
            Adapter.Fill(dt)
            Me.cboContainerType.DataSource = dt
            Me.cboContainerType.DisplayMember = "Container_type"
        Catch ex As Exception

        End Try
    End Sub
    Public Sub QueryICD(ByRef combo As Object)
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "Code"
        value = "TerminalName"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Code,TerminalName From Terminal where Continued=1 Order By Code desc"
        loadDataToObject(cboEmptyPort, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryEmptyContainer()
        Try
            Dim sql As String
            sql = "select PrintEmptyContainerID,Container_No,Container_Type,EmptyPort,DateOfReDel,ContainerStatus,Printed,UpdateTime,UserID "
            Sql &= " From PrintEmptyContainer "
            Sql &= " Where Continued=1 And BLIB_NO='" & gBillNoInBound & "' Order by Container_No"
            Dim dt As New DataTable
            dt = ReadTable(Sql)
            If dt.Rows.Count = 0 Then
                sql = " Insert Into PrintEmptyContainer (BLIB_NO,EmptyPort,Container_No,Container_Type,DateOfReDel,ContainerStatus,Printed)"
                sql &= "Select Distinct BillOfLadingIB.BLIB_NO,EmptyCY,Container.Container_No,Container_Type,FactOfReDelDate as DateOfReDel,"
                Sql &= " ContainerStatus=case "
                Sql &= " when SoundContainer=1 then 'Sound Container' "
                Sql &= " when ToBeInSpected=1 then 'To be Inspected'"
                Sql &= " when DamageContainer=1 then 'Damage Container'"
                Sql &= " when FullImport=1 then 'Full Import At Quay'"
                Sql &= " when FullToConsignee=1 then 'full To Consignee'"
                Sql &= " when FullExport=1 then 'Full Export'"
                Sql &= " when EmptyToShipper=1 then 'EmptyToShipper'"
                Sql &= " when EmptyContainerReposit=1 then 'Empty Container Reposit' End, 0 "
                Sql &= " From (((CargoIB LEFT JOIN BillOfLadingIB On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID)"
                Sql &= " LEFT JOIN Container On CargoIB.CTN_ID=Container.CTN_ID)"
                Sql &= " LEFT JOIN ContainerManagerment On ContainerManagerMent.BL_NO_Inbound=BillOfLadingIB.BLIB_NO) "
                Sql &= " where CargoIB.BLIB_ID='" & gBillInboundID & "' and CargoIB.Continued=1  "
                Sql &= " And ContainerManagerment.Container_No = Container.Container_no "
                Dim Conn As New SqlClient.SqlConnection(strconnDG)
                Conn.Open()
                Dim cmd As New SqlClient.SqlCommand(Sql, Conn)

                cmd.CommandType = CommandType.Text
                cmd.CommandText = Sql
                cmd.ExecuteNonQuery()

                sql = "select PrintEmptyContainerID,Container_No,Container_Type,EmptyPort,DateOfReDel,ContainerStatus,Printed ,UpdateTime "
                Sql &= " From PrintEmptyContainer "
                Sql &= " Where Continued=1 And BLIB_NO='" & gBillNoInBound & "' Order by Container_No"
                dt = ReadTable(Sql)
            End If

            Me.dgdContainerNo.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdContainerNo)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmEmptyContainer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo Err
        Dim ICDPort As String = ""
        Dim SQL As String
        SetDefaultGrid(Me.dgdContainerNo, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        QueryEmptyContainer()
        QueryICD(Me.cboEmptyPort)
        Dim strICD, strPre_Col As String
        Dim rsICD As New ADODB.Recordset
        'mặc định là in tất cả
        Me.chkAll.Checked = True
        ' Me.txtBLIB_NO.Text = gBillNoInBound
        'QueryContainer_type()
        ' lay ICD Port tu bill cua IB
        strICD = "Select distinct ICDPort,ETA "
        strICD &= "from (BillOfLadingIB LEFT JOIN CargoIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID) where BillOfLadingIB.BLIB_No='" & gBillNoInBound & "' and BillOfLadingIB.Continued=1"
        rsICD.Open(strICD, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        ICDPort = ""
        If Not rsICD.EOF Then
            rsICD.MoveFirst()
            Me.cboEmptyPort.Text = rsICD.Fields("ICDPort").Value.ToString
            Me.dtpNgayCapCang.Text = rsICD.Fields("ETA").Value.ToString
        End If
        rsICD.Close()
        Me.txtBL_NO.Text = gBillNoInBound
        strQuery = "SELECT  NGAYLAYHANG,NGAYHARONG "
        strQuery = strQuery & "FROM EMPTYCONTAINER "
        strQuery = strQuery & "WHERE BLIB_NO = '" & gBillNoInBound & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        If Not rs.EOF Then
            With rs
                'Me.txtBL_NO.Text = .Fields("BLIB_NO").Value
                'Me.cboEmptyPort.Text = .Fields("EMPTYPORT").Value
                'Me.dtpNgayCapCang.Text = .Fields("NGAYCAPCANG").Value
                Me.dtpNgayHaRong.Text = .Fields("NGAYHARONG").Value()
                Me.dtpNgayLayHang.Text = .Fields("NGAYLAYHANG").Value

            End With
        End If
        rs.Close()
        Exit Sub
Err:
        rs.Close()
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err
        If Me.dgdContainerNo.RowCount = 0 Then
            Return
        End If
        Dim RowSelect As Integer = Me.dgdContainerNo.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If RowSelect = 0 Then
            MsgBox("You have to select some rows to Print! ")
            Return
        End If
        If RowSelect > 20 And Me.chkAttachlist.Checked = True Then
            MsgBox("Containers > 20, please check again or just for attach list.")
        ElseIf RowSelect <= 20 And Me.chkAttachlist.Checked = False Then

        Else
            MsgBox("Containers > 20, please check again .")
            Return
        End If
        'For j As Integer = 0 To RowSelect - 1
        '    Dim index As Integer = Me.dgdContainerNo.SelectedRows(j).Index
        '    If UCase(Me.dgdContainerNo.Item("ContainerStatus", index).Value.ToString.Trim) <> "FULL TO CONSIGNEE" Then
        '        MsgBox("There Is some container Already in Empty CY Please check Again")
        '        Return
        '    End If
        'Next

        Me.txtBL_NO.Text = gBillNoInBound
        strQuery = "SELECT * "
        strQuery = strQuery & "FROM EMPTYCONTAINER "
        strQuery = strQuery & "WHERE BLIB_NO = '" & gBillNoInBound & "'"
        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

        With rs
            If rs.EOF Then
                .AddNew()
                .Fields("EMPTYCONTAINEID").Value = NewId()
                .Fields("BLIB_NO").Value = gBillNoInBound
            End If

            .Fields("EMPTYPORT").Value = Me.cboEmptyPort.Text
            .Fields("NGAYCAPCANG").Value = Me.dtpNgayCapCang.Value.Date
            .Fields("NGAYLAYHANG").Value = Me.dtpNgayLayHang.Value.Date
            .Fields("NGAYHARONG").Value = Me.dtpNgayHaRong.Value.Date
            .Update()
        End With

        rs.Close()
        'Me.Hide()
        Dim CountSelectRow As Integer
        CountSelectRow = Me.dgdContainerNo.Rows.GetRowCount(DataGridViewElementStates.Selected)
        If CountSelectRow = 0 Then
            Return
        End If
        For i As Integer = 0 To CountSelectRow - 1
            Dim index As Integer = Me.dgdContainerNo.SelectedRows(i).Index
            SetPrinted(index, True)
            SetEmptyPort(index)
        Next
        VB6.ShowForm(frmRptLenhTraContainerRong, VB6.FormShowConstants.Modal, Me)
        QueryEmptyContainer()
        'Me.Close()

        Exit Sub
Err:
        rs.Close()
        MsgBox(msgErr(Me, Err.Description))
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err
        Me.Close()
        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            ChuHang = "Shipper"
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            ChuHang = "Consignee"
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            ChuHang = "Notify"
        End If
    End Sub

    Private Sub dtpNgayLayHang_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpNgayLayHang.ValueChanged
        Me.dtpNgayHaRong.Value = Me.dtpNgayLayHang.Value.AddDays(2)
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        Me.cboContainerType.Enabled = Not Me.chkAll.Checked
    End Sub

    Public Sub SetPrinted(ByVal index As Integer, Optional ByVal value As Boolean = False)
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.dgdContainerNo.CurrentRow.Index
        Dim strQueryDetailBillOfLadingList As String
        'If Not UserRight("frmInputDataInBound", "Approve") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        'Else
        strQueryDetailBillOfLadingList = "Select * from PrintEmptyContainer where PrintEmptyContainerID = '" & Me.dgdContainerNo.Item("PrintEmptyContainerID", index).Value.ToString & "'"
        rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'Approve = Not rs.Fields("Printed").Value
        If Approve = False Then
            rs.Update("EmptyPort", "")
            rs.Close()
        End If
        If rs.State = ADODB.ObjectStateEnum.adStateOpen Then rs.Close()
        rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        rs.Update("Printed", value)
        rs.Close()
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Public Sub SetEmptyPort(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim Approve As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        'Dim index As Integer = Me.dgdContainerNo.CurrentRow.Index
        Dim strQueryDetailBillOfLadingList As String
        'If Not UserRight("frmInputDataInBound", "Approve") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        'Else
        strQueryDetailBillOfLadingList = "Select * from PrintEmptyContainer where PrintEmptyContainerID = '" & Me.dgdContainerNo.Item("PrintEmptyContainerID", index).Value.ToString & "'"
        rs.Open(strQueryDetailBillOfLadingList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
        'Approve = Not rs.Fields("EmptyPort").Value
        rs.Update("EmptyPort", Me.cboEmptyPort.Text.Trim)
        rs.Close()
        'End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub



    Private Sub dgdContainerNo_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainerNo.CellContentClick
        Try
            If Me.dgdContainerNo.RowCount = 0 Then
                Return
            End If
            Dim colindex As Integer = e.ColumnIndex
            Dim rowindex As Integer = e.RowIndex
            If UCase(Me.dgdContainerNo.Columns(colindex).Name) = "PRINTED" And Me.dgdContainerNo.CurrentCellAddress.Y = rowindex Then
                SetPrinted(rowindex)
                QueryEmptyContainer()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgdContainerNo_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContainerNo.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContainerNo)
    End Sub

    Private Sub cmdUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUncheckAll.Click
        Try
            For i As Integer = 0 To Me.dgdContainerNo.RowCount - 1
                If Me.dgdContainerNo.Item("Printed", i).Value = True Then
                    SetPrinted(i, False)
                End If

            Next
            QueryEmptyContainer()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
End Class