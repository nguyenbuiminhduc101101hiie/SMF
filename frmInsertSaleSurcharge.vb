Public Class frmInsertSaleSurcharge
    Public MarketCode As String = ""
    Public mStatus As String
    Public mPriceStandard_ID As String
    Public mPod_ID As String
    Dim RowIndex, Colindex As Integer

    Sub QueryCombo()
        Try
            Dim SQL As String
            SQL = "Select distinct Port_Code,Port_ID from Port Where Port.Continued=1 Order By port_Code "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboPOL.DisplayMember = "Port_code"
            Me.cboPOL.ValueMember = "Port_id"
            Me.cboPOL.DataSource = dt

            ''query Items
            SQL = "Select distinct Charge_Code,Charge_ID From Charge Where Continued=1 Order By Charge_Code "
            Dim Itemdt As New DataTable
            Itemdt = ReadTable(SQL)
            Me.cboItems.DisplayMember = "Charge_Code"
            Me.cboItems.ValueMember = "Charge_ID"
            Me.cboItems.DataSource = Itemdt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function GetPOD_ID() As String
        Try
            Dim Temp As String = ""
            For i As Integer = 0 To Me.dgdUpdateSurtCharge.RowCount - 1
                If Me.dgdUpdateSurtCharge.Item("PortSelect", i).Value = 1 Then
                    Temp &= "'" & Me.dgdUpdateSurtCharge.Item("Port_ID", i).Value.ToString & "',"
                End If
            Next
            If Temp.Length > 0 Then
                Temp = Temp.Remove(Temp.Length - 1, 1)
            End If
            Return Temp
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function DeletePOD(ByVal POL_ID As String, ByVal Charge_ID As String, ByVal Type As String) As Integer
        Try
            If mPod_ID = "" Then
                mPod_ID = "'" & DefaultValue & "'"
            End If
            Dim SQL As String
            SQL = "delete from PriceStandard "
            SQL &= " where POL_ID='" & POL_ID & "' And Continued=1 And Charge_ID='" & Charge_ID & "' And CTN_TYPE='" & Type & "'"
            SQL &= " And Port_ID In(" & mPod_ID & ")" 'mpod_ID Lấy Giá trị Ở Form_Load khi load lên lấy tất cả các port đã lưu trứơc đó 
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            Return cmd.ExecuteNonQuery()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub QueryPort(ByVal Market_Code As String)
        Try
            Dim SQL As String
            SQL = "select  distinct Port.Port_ID as Port_ID,PortSelect=0, " 'case When (Select Count(*) From PriceStandard Where PriceStandard.Continued=1 and PriceStandard.Port_ID=Port.Port_ID) >0 then 1 else 0 end ,"
            SQL &= " Port as POD,Port_Code as POD_Code "
            SQL &= " From Port   "
            SQL &= " Where MARKETCODESALE='" & Market_Code & "' And Port.Continued=1 " 'And PriceStandard.POL_ID='" & Me.cboPOL.SelectedValue.ToString & "' And PriceStandard.Charge_ID='" & Me.cboItems.SelectedValue.ToString & "' And PriceStandard.CTN_TYPE='" & Me.cboContainerType.Text & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdUpdateSurtCharge.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdUpdateSurtCharge)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub Querymarket()
        Try
            Dim SQL As String
            SQL = "select Distinct marketCode From market Where Continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return
            End If
            Me.cbomarket.DisplayMember = "marketCode"
            Me.cbomarket.ValueMember = "marketCode"
            Me.cbomarket.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryShippingline()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "shippinglineid"
        value = "shippingline"
        strSQL = "Select shippinglineid, shippingline From shippingline  Order By shippingline"
        loadDataToObject(Me.cboShippingLine, strSQL, id, value)
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryUser()
        Try
            Dim id As String = "sale_iD"
            Dim value As String = "salecode"
            Dim strQuery As String = "select sale_id,salecode from sale where continued=1 order by salecode "
            loadDataToObject(Me.cboSalename, strQuery, id, value)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
    Private Sub frmInsertSaleSurcharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Colindex = 0
        RowIndex = 0
        Querymarket()
        'QueryPort(Me.cbomarket.Text)
        QueryCombo()
        QueryShippingline()
        QueryUser()
        'mPod_ID = GetPOD_ID()
        GetCurrency(Me.cboCurrency)
        If UCase(mStatus) = "EDIT" Then
            Dim index As Integer = 0
            If frmPriceStandard.dgdPriceStandard.RowCount = 0 Then
                Return
            Else
                index = frmPriceStandard.dgdPriceStandard.CurrentRow.Index
            End If
            RefreshDataFrmInsert(index)
        End If

    End Sub

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
      
        If Me.cboItems.SelectedValue.ToString = "" Then
            Msg &= "The Items is invalid"
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If

        If Msg <> "" Then
            DisplayMessage(True, Msg)
            Return False
        End If
        Return True
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub RefreshDataFrmInsert(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim oItems As PDSAListItemString
        Me.cboPOL.SelectedValue = frmPriceStandard.dgdPriceStandard.Item("POL_ID", index).Value.ToString
        Me.cboItems.SelectedValue = frmPriceStandard.dgdPriceStandard.Item("Charge_ID", index).Value.ToString
        Me.cboCurrency.Text = frmPriceStandard.dgdPriceStandard.Item("Currency", index).Value
        Me.cboContainerType.Text = frmPriceStandard.dgdPriceStandard.Item("CTN_TYPE", index).Value
        Me.cboPrepaidCollect.Text = frmPriceStandard.dgdPriceStandard.Item("PrepaidCollect", index).Value
        Me.txtMoney.Text = FormatString(frmPriceStandard.dgdPriceStandard.Item("Money", index).Value)
        If frmPriceStandard.dgdPriceStandard.Item("MarketCode", index).Value Then
            Me.cbomarket.Text = frmPriceStandard.dgdPriceStandard.Item("MarketCode", index).Value
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub CheckExistRecord(ByVal Dis_ID As String)
        Try
            Dim Temprs As New ADODB.Recordset
            Dim TempSQL As String
            TempSQL = "Select * from PriceStandard inner join charge on charge.Charge_ID=pricestandard.Charge_ID "
            TempSQL &= " Where PriceStandard.Continued=1 And Port_ID='" & Dis_ID & "' And "
            TempSQL &= " POL_ID='" & Me.cboPOL.SelectedValue.ToString & "' And CTN_TYPE='" & Me.cboContainerType.Text.Trim & "' and  charge='" & Me.cboItems.Text.Trim & "'"
            'TempSQL &= " And Prepaid_Collect='" & Me.cboPrepaidCollect.Text.Trim & "' And Currency='" & Me.cboCurrency.Text.Trim & "'"
            Temprs.Open(TempSQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If Not Temprs.EOF Then 'nếu  cảng load, cảng dở,Loai Cont, Tien,Prepaid,charge dã có trong CSDL thì kho thêm
                Temprs.Fields("Continued").Value = 0 'cập nhật dòng hiên có bằng 0
                Temprs.Update()
            End If
            Temprs.Close()

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strMarket_ID, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer
        If (Me.dgdUpdateSurtCharge.RowCount = 0) Then
            Return
        End If

        If CheckData() And (mStatus = "Add" Or mStatus = "Edit") Then

            'Xoá đi cái củ thêm lại cái mới
            'DeletePOD(Me.cboPOL.SelectedValue.ToString, Me.cboItems.SelectedValue.ToString, Me.cboContainerType.Text)
            strQuery = "SELECT Top 1 * "
            strQuery = strQuery & "FROM PriceStandard "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                For i As Integer = 0 To Me.dgdUpdateSurtCharge.RowCount - 1 'duyệt hết tất cả các port trên Grid
                    If Me.dgdUpdateSurtCharge.Item("PortSelect", i).Value.ToString <> "" Then
                        If Me.dgdUpdateSurtCharge.Item("PortSelect", i).Value = 1 Then 'nếu port đc chọn  thì thêm

                            'hàm kiểm tra nếu có 1 dòng trong CSDL Với những thông tin chọn thì xóa đi(gán continued=0)
                            CheckExistRecord(Me.dgdUpdateSurtCharge.Item("Port_ID", i).Value.ToString)

                            .AddNew()
                            .Fields("Port_ID").Value = "{" & Me.dgdUpdateSurtCharge.Item("Port_ID", i).Value.ToString & "}"
                            .Fields("POL_ID").Value = "{" & Me.cboPOL.SelectedValue.ToString & "}"
                            .Fields("Charge_ID").Value = "{" & Me.cboItems.SelectedValue.ToString & "}"
                            .Fields("CTN_TYPE").Value = Me.cboContainerType.Text.Trim
                            .Fields("Prepaid_Collect").Value = Me.cboPrepaidCollect.Text.Trim
                            .Fields("Currency").Value = Me.cboCurrency.Text.Trim
                            .Fields("ApplyDate").Value = Me.dtpApplyDate.Value.Date
                            If Me.chkNoneExpireDate.Checked = False Then
                                .Fields("ExpireDate").Value = Me.dtpExpireDate.Value.Date
                            End If

                            .Fields("Price").Value = CDbl(Me.txtMoney.Text.Trim)
                            .Fields("shippingline").Value = Me.cboShippingLine.Text.Trim
                            .Fields("salename").Value = Me.cboSalename.Text.Trim
                            .Update()

                        End If
                    End If

                Next


                rs.Close()
            End With
            MsgBox("Successful")
            Me.dgdUpdateSurtCharge.Enabled = True
            'If mStatus = "Edit" Then
            '    QueryPriceStandard(, 1, index)
            'Else
            '    QueryPriceStandard(, 15, index)
            'End If
            'Me.fraUpdate.Visible = False
            'ReFormat()
            'SetMenu((True))

            'blnUpdated = True
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        On Error GoTo Err_Renamed
        'Me.fraUpdate.Visible = False
        'ReFormat()
        'SetMenu((True))
        mStatus = "Normal"
        Me.Close()
        'frmPriceStandard.QueryPriceStandard(" " & frmPriceStandard.mFilter)
        'reText(mStatus)
        Me.dgdUpdateSurtCharge.Enabled = True
        Exit Sub

Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    
    Private Sub CheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckToolStripMenuItem.Click
        If Me.dgdUpdateSurtCharge.RowCount = 0 Then
            Return
        End If
        Try
            Dim RowCount As Integer = Me.dgdUpdateSurtCharge.Rows.GetRowCount(DataGridViewElementStates.Selected)
            For i As Integer = 0 To RowCount - 1
                Me.dgdUpdateSurtCharge.SelectedRows(i).Cells("PortSelect").Value = 1
            Next
            Dim index As Integer = Me.dgdUpdateSurtCharge.CurrentRow.Index
            Me.dgdUpdateSurtCharge.Item("PortSelect", index).Value = 1
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub UnCheckToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnCheckToolStripMenuItem.Click
        If Me.dgdUpdateSurtCharge.RowCount = 0 Then
            Return
        End If
        Try
            Dim RowCount As Integer = Me.dgdUpdateSurtCharge.Rows.GetRowCount(DataGridViewElementStates.Selected)
            For i As Integer = 0 To RowCount - 1
                Me.dgdUpdateSurtCharge.SelectedRows(i).Cells("PortSelect").Value = 0
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cbomarket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbomarket.SelectedIndexChanged
        QueryPort(Me.cbomarket.Text)

        'mPod_ID = GetPOD_ID()
    End Sub

    Private Sub dgdUpdateSurtCharge_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdUpdateSurtCharge.CellClick
        If Me.dgdUpdateSurtCharge.RowCount = 0 Then
            Return
        End If
        Colindex = Me.dgdUpdateSurtCharge.CurrentCell.ColumnIndex
        RowIndex = Me.dgdUpdateSurtCharge.CurrentCell.RowIndex
      
    End Sub

    Private Sub dgdUpdateSurtCharge_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdUpdateSurtCharge.CellContentClick

    End Sub

    Private Sub dgdUpdateSurtCharge_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdUpdateSurtCharge.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdUpdateSurtCharge)
    End Sub

    
    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Try
            If Me.txtSearch.Text.Trim = "" Then
                Return
            End If
            For i As Integer = Colindex To Me.dgdUpdateSurtCharge.ColumnCount - 1
                If UCase(Me.dgdUpdateSurtCharge.Item(i, RowIndex).Value.ToString.Trim) Like "*" & UCase(Me.txtSearch.Text.Trim) & "*" Then
                    Colindex = i + 1
                   
                    Me.dgdUpdateSurtCharge.CurrentCell = Me.dgdUpdateSurtCharge.Rows(RowIndex).Cells(i)
                    Return
                End If
            Next
            For i As Integer = RowIndex + 1 To Me.dgdUpdateSurtCharge.RowCount - 1
                For col As Integer = 0 To Me.dgdUpdateSurtCharge.ColumnCount - 1
                    If UCase(Me.dgdUpdateSurtCharge.Item(col, i).Value.ToString.Trim) Like "*" & UCase(Me.txtSearch.Text.Trim) & "*" Then
                        Colindex = col + 1
                        RowIndex = i
                       


                        Me.dgdUpdateSurtCharge.CurrentCell = Me.dgdUpdateSurtCharge.Rows(i).Cells(col)
                        Return
                    End If
                Next
            Next
            MsgBox("Can not find any value like '" & Me.txtSearch.Text.Trim & "'")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdNewSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNewSearch.Click
        Colindex = 0
        RowIndex = 0
        If Me.dgdUpdateSurtCharge.RowCount = 0 Then
            Return
        End If
        Me.dgdUpdateSurtCharge.CurrentCell = Me.dgdUpdateSurtCharge.Rows(RowIndex).Cells("POD_Code")
    End Sub

    Private Sub cmdimportfile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        VB6.ShowForm(frmimportsalesurcharge, VB6.FormShowConstants.Modeless, Me)
    End Sub
End Class