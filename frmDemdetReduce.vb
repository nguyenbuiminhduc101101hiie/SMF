Public Class frmDemdetReduce

    Dim mFilter As String
    Dim SQL As String
    Sub QueryDemBill(Optional ByVal Filter As String = "")
        Try
            If mFilter = "" Then
                mFilter = " And DemDetReduce.BLIB_NO='" & Me.cboBLNO.Text.Trim & "' "
            End If
            SQL = "select  DemDetReduceID,DemDetReduce.BLIB_NO,DemDetReduce.Container_No,DemDetReduce.Container_Type,DemDays,DetDays,PicApproveDem,PicApproveDet,RefDem,RefDet "
            SQL &= " from  DemDetReduce "
            SQL &= " Where DemDetReduce.Continued=1" & Filter & " Order By DemDetReduce.BLIB_NO"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdDemBillData.DataSource = dt
            Me.dgdDemBillData.Columns("DemDetReduceID").Visible = False
            InsertAutoNumberToGrid(Me.dgdDemBillData)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    'Sub QueryDemdetReduce(Optional ByVal Filter As String = "")
    '    Try
    '        SQL = "select distinct DemDetReduce.BLIB_NO,DemDetReduce.Container_No,DemDetReduce.Container_Type,DeMurrageDate,DemDays,DetDays "
    '        SQL &= " from  DemDetReduce "
    '        SQL &= " Where DemDetReduce.Continued=1" & Filter & " Order By DemDetReduce.BLIB_NO"
    '        Dim dt As New DataTable
    '        dt = ReadTable(SQL)
    '        Me.dgdDemBillData.DataSource = dt
    '        InsertAutoNumberToGrid(Me.dgdDemBillData)
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            gNameForm = Me.Name 'frmListBaseIB.Name 'load phần search của Baseib lên
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                Me.QueryDemBill("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub QueryContainerType()
        Try
            Dim SQL As String
            SQL = "Select Distinct Container_Type as Type "
            SQL &= " From (CargoIB INNER JOIN BillOfLadingIB On CargoIB.BLIB_ID = BillOfLadingIB.BLIB_ID)"
            SQL &= " Where BillOfLadingIB.BLIB_NO='" & Me.cboBLNO.Text.Trim & "' And CargoIB.continued=1"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboContainer_type.DisplayMember = "Type"
            Me.cboContainer_type.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryContainerNo()
        Try
            Dim SQL As String
            SQL = "Select Distinct Container_No as No,CTN_SIZE_TYPE as Type  "
            SQL &= " From ((Container INNER JOIN CargoIB On CargoIB.CTN_ID=Container.CTN_ID)"
            SQL &= " INNER JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=CargoIB.BLIB_ID) "
            SQL &= " Where CargoIB.Continued=1 And BillOfLadingIB.BLIB_No='" & Me.cboBLNO.Text.Trim & "' "
            SQL &= " Order By Container_No "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboContainerNo.Text = ""
            Me.cboContainerNo.DisplayMember = "No"
            Me.cboContainerNo.ValueMember = "Type"
            Me.cboContainerNo.DataSource = dt
            Me.lblToTalContainer.Text = Me.cboContainerNo.Items.Count & " Container(s)"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmDemdetReduce_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub dgdDemBillData_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDemBillData.CellClick
        Try
            If Me.dgdDemBillData.RowCount = 0 Or IsNothing(Me.dgdDemBillData.CurrentRow) Then
                Return
            End If
            Dim Index As Integer = Me.dgdDemBillData.CurrentRow.Index
            Me.cboBLNO.Text = Me.dgdDemBillData.Item("BLIB_NO", Index).Value.ToString
            Me.txtDemDays.Text = Me.dgdDemBillData.Item("DemDays", Index).Value.ToString
            Me.txtDetDays.Text = Me.dgdDemBillData.Item("DetDays", Index).Value.ToString
            'QueryContainerType()
            'QueryContainerNo()
            Me.cboContainerNo.Text = Me.dgdDemBillData.Item("Container_No", Index).Value.ToString
            If Me.txtDemDays.Text = "" Then
                Me.chkDemdays.Checked = False
            Else
                Me.chkDemdays.Checked = True
            End If

            If Me.txtDetDays.Text = "" Then
                Me.chkDetDays.Checked = False
            Else
                Me.chkDetDays.Checked = True
            End If
            Me.txtPicApproveDem.Text = Me.dgdDemBillData.Item("PicApproveDem", Index).Value.ToString
            Me.txtPicApproveDet.Text = Me.dgdDemBillData.Item("PicApproveDet", Index).Value.ToString
            Me.txtRefDem.Text = Me.dgdDemBillData.Item("Refdem", Index).Value.ToString
            Me.txtRefDet.Text = Me.dgdDemBillData.Item("RefDet", Index).Value.ToString
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdDemBillData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdDemBillData.CellContentClick

    End Sub

    Private Sub dgdDemBillData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdDemBillData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdDemBillData)
    End Sub

    Private Sub chkDemdays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDemdays.CheckedChanged
        If Me.chkDemdays.Checked = True Then
            Me.txtDemDays.Enabled = True
        Else
            Me.txtDemDays.Enabled = False
        End If
    End Sub

    Private Sub chkDetDays_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDetDays.CheckedChanged
        If Me.chkDetDays.Checked = True Then
            Me.txtDetDays.Enabled = True
        Else
            Me.txtDetDays.Enabled = False
        End If
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Sub OkClick()
        Try
            SQL = "Select * from DemDetReduce Where BLIB_NO='" & Me.cboBLNO.Text.Trim & "' And Continued=1 and Container_No='" & Me.cboContainerNo.Text.Trim & "'"
            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If .EOF Then
                    .AddNew()
                    .Fields("DemDetReduceID").Value = NewId()
                    .Fields("BLIB_NO").Value = Me.cboBLNO.Text
                    .Fields("Container_type").Value = Me.cboContainer_type.Text.Trim
                    .Fields("Container_No").Value = Me.cboContainerNo.Text.Trim
                End If
                .Fields("DemDays").Value = IIf(Me.txtDemDays.Text.Trim = "", 0, Me.txtDemDays.Text.Trim)
                .Fields("DetDays").Value = IIf(Me.txtDetDays.Text.Trim = "", 0, Me.txtDetDays.Text.Trim)

                .Fields("PicApproveDem").Value = IIf(Me.txtDemDays.Text.Trim = "", 0, Me.txtPicApproveDem.Text.Trim)
                .Fields("PicApproveDet").Value = IIf(Me.txtDetDays.Text.Trim = "", 0, Me.txtPicApproveDet.Text.Trim)
                .Fields("RefDem").Value = IIf(Me.txtDemDays.Text.Trim = "", 0, Me.txtRefDem.Text.Trim)
                .Fields("RefDet").Value = IIf(Me.txtDetDays.Text.Trim = "", 0, Me.txtRefDet.Text.Trim)

                .Update()
            End With
            rs.Close()

            'Cập Nhất Correcttion DELdate và Correction ReDelDate
            SQL = "Select Top 1 * from ContainerManagerment Where BL_NO_Inbound='" & Me.cboBLNO.Text.Trim & "' And Continued=1 and Container_No='" & Me.cboContainerNo.Text.Trim & "'"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If .EOF Then
                    .Close()
                    Return
                End If
                If Me.txtDemDays.Text.Trim <> "" Then
                    If .Fields("FactOfDELDate").Value.ToString.Trim <> "" Then
                        .Fields("CorrectionOfDELDate").Value = Date.FromOADate(CDate(.Fields("FactOfDELDate").Value.ToString.Trim).ToOADate - CDbl(Me.txtDemDays.Text)).Date()
                    End If
                End If
                If Me.txtDetDays.Text.Trim <> "" Then
                    If .Fields("FactOfReDELDate").Value.ToString.Trim <> "" Then
                        .Fields("CorrectionOfReDELDate").Value = Date.FromOADate(CDate(.Fields("FactOfReDELDate").Value.ToString.Trim).ToOADate - CDbl(Me.txtDetDays.Text)).Date()
                    End If
                End If
                .Update()
            End With
            rs.Close()


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        OkClick()
        QueryDemBill(mFilter)
    End Sub

    Sub DeleteRow(ByVal Index As Integer)
        Try
            Dim SQL As String
            SQL = "Select * from DemDetReduce Where DemDetReduceID='" & Me.dgdDemBillData.Item("DemDetReduceID", Index).Value.ToString & "' "
            Dim rs As New ADODB.Recordset
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            If rs.EOF Then
                Return
            End If
            rs.Fields("Continued").Value = 0
            rs.Update()
            rs.Close()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.dgdDemBillData.RowCount = 0 Then
                Return
            End If
            Dim i As Integer = Me.dgdDemBillData.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If i = 0 Then
                Return
            End If
            For j As Integer = 0 To i - 1
                Dim index As Integer = Me.dgdDemBillData.SelectedRows(j).Index
                DeleteRow(index)
            Next
            QueryDemBill(" " & mFilter)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboContainerNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboContainerNo.SelectedIndexChanged
        Me.cboContainer_type.Text = Me.cboContainerNo.SelectedValue.ToString
    End Sub

    Sub QueryBillIB(Optional ByVal filter As String = "")
        Try
            Dim SQl As String
            SQl = " Select Distinct BLIB_NO "
            SQl &= " FROM (((((BillOfLadingIB left join Shipper on BillOfLadingIB.Shipper_Id=Shipper.Shipper_Id ) left join Consignee on BillOfladingIB.Consignee_Id=Consignee.Consignee_Id ) left join Notify  on BillOfLadingIB.Notify_Id=Notify.Notify_id )  "
            SQl &= " LEFT JOIN CargoIB On CargoIB.BLIB_ID=BillOfLadingIb.BLIB_ID) "
            SQl &= " LEFT JOIN Container On Container.CTN_ID=cargoib.CTN_ID)"
            SQl &= " Where BillOfLadingIB.Continued=1 " & filter
            SQl &= " Order By BillOfLadingIB.BLIB_NO "
            Dim dt As New DataTable
            dt = ReadTable(SQl)
            Me.cboBLNO.DisplayMember = "BLIB_NO"
            Me.cboBLNO.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub SearchBillOfLadingInboundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBillOfLadingInboundToolStripMenuItem.Click
        Try
            'gNameForm = frmListBaseIB.Name 'load phần search của Baseib lên
            'VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            'If frmFilter.strQuery <> "Cancel" Then
            '    'mFilter = frmFilter.strQuery
            '    QueryBillIB("  " & frmFilter.strQuery)
            'End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cboBLNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBLNO.SelectedIndexChanged
        QueryContainerNo()
    End Sub

    Private Sub cmdAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAll.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 0 To Me.cboContainerNo.Items.Count - 1
                Me.cboContainerNo.SelectedIndex = i
                OkClick()
            Next
            QueryDemBill(mFilter)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class