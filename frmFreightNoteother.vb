Public Class frmFreightNoteother
    Dim mStatus As String = "Normal"
    Dim mFreightNoteoTherID As String = DefaultValue
    Public BIllNo As String = ""
    Private Sub frmFreightNoteother_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mStatus = "Normal"
        mFreightNoteoTherID = DefaultValue
        QueryFreightNoteoTher(" and BL_NO='" & BIllNo.Trim & "'")
        Me.txtBLNO.Text = BIllNo.Trim
        Me.cmdOk.Enabled = False
    End Sub
    Sub updateOkButton(ByVal Value As Boolean)
        Try
            Me.cmdOk.Enabled = Value
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub AddToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddToolStripMenuItem.Click
        mStatus = "Add"
        mFreightNoteoTherID = DefaultValue
        updateOkButton(True)
    End Sub

    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try
            If Me.dgdData.RowCount = 0 Or IsNothing(Me.dgdData.CurrentRow) Then
                Return
            End If
            mStatus = "Edit"
            Dim index As Integer
            index = Me.dgdData.CurrentRow.Index
            mFreightNoteoTherID = Me.dgdData.Item("FreightNoteoTherID", index).Value.ToString
            Refreshdata(index)
            updateOkButton(True)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Sub Refreshdata(ByVal Index As Integer)
        Try
            Me.txtBLNO.Text = Me.dgdData.Item("BL_NO", Index).Value.ToString
            Me.txtChargeCode.Text = Me.dgdData.Item("Charge_Code", Index).Value.ToString
            Me.txtFee.Text = Me.dgdData.Item("fee", Index).Value.ToString
            Me.txtQuantity.Text = Me.dgdData.Item("Quantity", Index).Value.ToString
            Me.txtCurrency.Text = Me.dgdData.Item("Currency", Index).Value.ToString
            Me.txtType.Text = Me.dgdData.Item("FeeType", Index).Value.ToString
            'Me.txtToTal.Text = Me.dgdData.Item("ToTal", Index).Value.ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        frmListBaseMaster.txtBillNumber.Text = Me.txtBLNO.Text
        frmListBaseMaster.fraFreightNote.Visible = True
        frmListBaseMaster.fraFreightNote.BringToFront()
        Me.Close()
    End Sub
    Function GetTotal() As Double
        Dim Total As Double = 0
        For i As Integer = 0 To Me.dgdData.RowCount - 1
            Total += Me.dgdData.Item("Fee", i).Value * Me.dgdData.Item("Quantity", i).Value
        Next
        Return Total
    End Function
    Sub QueryFreightNoteoTher(Optional ByVal arg As String = "")
        Try
            Dim SQL As String
            SQL = "Select * from FreightNoteoTher Where Continued=1 " & arg
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdData.DataSource = dt
            Me.txtToTal.Text = GetTotal()
            For i As Integer = 0 To dt.Columns.Count - 1
                If dt.Columns(i).ColumnName.ToUpper Like "*ID*" Or dt.Columns(i).ColumnName.ToUpper Like "*EDITABLE*" Or dt.Columns(i).ColumnName.ToUpper Like "*APPROVED*" Or dt.Columns(i).ColumnName.ToUpper Like "*CONTINUED*" Or dt.Columns(i).ColumnName.ToUpper Like "*USERID*" Or dt.Columns(i).ColumnName.ToUpper Like "*UPDATETIME*" Then
                    Me.dgdData.Columns(i).Visible = False
                End If
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        On Error GoTo Err_Renamed
        Dim strQuery, strFreightNoteoTherId, pName As String
        Dim rs As New ADODB.Recordset
        Dim index As Integer = 0
        If mStatus = "Edit" Then
            index = Me.dgdData.CurrentRow.Index
        End If
        If (mStatus = "Add" Or mStatus = "Edit") Then
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM FreightNoteoTher "
            strQuery = strQuery & "WHERE FreightNoteoTherId = '" & mFreightNoteoTherID & "' AND FreightNoteoTherId <> '" & DefaultValue & "' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("FreightNoteoTherId").Value = NewId()
                End If
                strFreightNoteoTherId = .Fields("FreightNoteoTherId").Value

                .Fields("BL_NO").Value = UCase(Trim(Me.txtBLNO.Text))
                .Fields("Charge_Code").Value = UCase(Trim(Me.txtChargeCode.Text))

                .Fields("Quantity").Value = Me.txtQuantity.Text
                .Fields("Fee").Value = UCase(Trim(Me.txtFee.Text))
                .Fields("Currency").Value = Me.txtCurrency.Text
                .Fields("Type").Value = UCase(Me.txtType.Text)
                .Update()
            End With
            rs.Close()



            'lấy dữ liệu đưa vào lứơi sau khi thêm hay cập nhật thành công
            QueryFreightNoteoTher("AND BL_NO= '" & UCase(Trim(Me.txtBLNO.Text)) & "' ")
            mStatus = "Normal"
            updateOkButton(True)
            Me.cmdOk.Enabled = False
        End If

        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub DeleteRow(ByVal index As Integer)
        Try

            Dim rs, rsFreightNoteoTherList As New ADODB.Recordset
            Dim strQuery, strQueryCommodityList As String
            Dim blnEmpty, blnEOF As Boolean
            ' Xác định vị trí row trong grid
            'Dim index As Integer = Me.BindingContext(oTable).Position
            'strQuery = "Select count(*) cnt from BillOfLading WHERE FreightNoteoTherID = '" & Me.dgddata.Item("FreightNoteoTherID", index).Value.ToString & "'  "
            'rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'blnEmpty = (rs.Fields("cnt").Value = 0)

            'rs.Close()
            strQuery = "Select * from FreightNoteoTher WHERE FreightNoteoTherId = '" & Me.dgddata.Item("FreightNoteoTherId", index).Value.ToString & "' And UserId='DBO' "
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            blnEOF = rs.EOF
            rs.Close()
            If Not blnEOF Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, The FreightNoteoTher can not be removed.", "Fee Này Không Thể Xoá"))
                Exit Sub
            End If
            'chư có ràng buộc
            'If Not blnEmpty Then
            '    DisplayMessage(True, "The FreightNoteoTher can not be removed. There are transactions that relate to this customer.")
            '    Exit Sub
            'End If
            If Not IsNothing(Me.dgddata.Item("Approve", index)) Then
                If CBool(Me.dgdData.Item("Approve", index).Value) Then
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                    Exit Sub
                End If
            End If
            If Not IsNothing(Me.dgddata.Item("Editable", index)) Then
                If Not CBool(Me.dgdData.Item("Editable", index).Value) Then
                    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
                    Exit Sub
                End If
            End If
            Dim strMesg As String
            Dim bm As Short
            If Not UserRight("frmListBillOfLadingMaster", "Delete") Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access right to carry out.", "Bạn Cần Đựơc Cấp Quyền"))
            Else
                strMesg = "Delete the FreightNoteoTher: " & Me.dgdData.Item("Charge_Code", index).Value.ToString
                If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
                    strQueryCommodityList = "Select * from FreightNoteoTher where" + " FreightNoteoTherID= '" & Me.dgdData.Item("FreightNoteoTherID", index).Value.ToString & "'"
                    rsFreightNoteoTherList.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    rsFreightNoteoTherList.Fields("continued").Value = 0
                    rsFreightNoteoTherList.Update()

                    rsFreightNoteoTherList.Requery()
                    Me.dgdData.Rows(index).DefaultCellStyle.ForeColor = Color.White
                    Me.dgdData.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
                    rsFreightNoteoTherList.Close()

                End If
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Dim selectedRowCount As Integer = _
                 Me.dgdData.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdData.SelectedRows(i).Index)
                Next i
            End If
            QueryFreightNoteoTher("AND BL_NO= '" & UCase(Trim(Me.txtBLNO.Text)) & "' ")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    'Private Sub cmdShowReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdShowReport.Click
    '    frmRptfreightNoteoTher.ShowDialog()
    'End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Me.Close()
    End Sub
End Class