Public Class frmFreightSummaryExcel



    Dim CurCol, CurRow As Integer
    Dim X, Y As Integer
    Dim Mdown As Boolean = False
    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL = strSQL & " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 Order By Vessel_Code desc"
        'loadDataToObject(Me.cboVessel, strSQL, id, value)
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboVessel.DisplayMember = value
        Me.cboVessel.ValueMember = id
        Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim strSQL As String
            strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            strSQL &= " From SailingSchedule,vessel "
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD='" & Me.dtpLeavingDate.Value.Date & "'"
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            Else
                MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        On Error GoTo Err_named
        Dim Ves_ID As String
        If Me.cboVessel.Text = "" Then
            Return
        End If
        Ves_ID = Me.cboVessel.SelectedValue.ToString
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        If Ves_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select ETD "
            strQuery &= "from SailingSchedule "
            strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString
            End If
            '  query stranship
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub QueryPayer()
        Try
            Dim SQL As String
            SQL = "Select distinct Payer as Value"
            SQL &= " from ((BillOfLading INNER JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " Where BillOfLading.Continued=1 And convert(DateTime,ETD)+1>'" & Me.dtpFromETD.Value.Date & "' And Convert(DateTime,ETD)-1<'" & Me.dtpToETD.Value.Date & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboPayer.DisplayMember = "Value"
            Me.cboPayer.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryData(Optional ByVal arg As String = "")
        Try
            Dim sql As String

            sql = " select BillOfLading.Payer,Tell='',BL_NO,BL_ID,replace(SailingSchedule.ETD,'12:00AM','') as ETD "
            sql &= " from ((BillOfLading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            sql &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            sql &= " where BillOfLading.Continued=1  " & arg 'and Freight_Charge_Master.Prepaid_Collect='PREPAID'
            Dim dt As New DataTable
            dt = ReadTable(sql)
            Dim Tempdt As New DataTable
            Dim CountRow As Integer = 0
            If Me.dgddata.RowCount > 0 Then
                Me.dgddata.Rows.Clear()
            End If
            For i As Integer = 0 To dt.Rows.Count - 1
                sql = "select Charge_Code,sum(Freight_charge_Master.UnitPriceSale*Freight_charge_Master.quantity*exchange) as Fee "
                sql &= " From ((Freight_charge_Master LEFT JOIN Charge On Freight_charge_Master.Charge_ID=Charge.Charge_ID) "
                sql &= " LEFT JOIN Port On Port.Port_ID=Freight_Charge_Master.PAYABLE_AT_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
                sql &= " Where Freight_Charge_Master.BL_ID='" & dt.Rows(i).Item("BL_ID").ToString & "' And Freight_Charge_master.Continued=1 "
                sql &= " And Port.Port_Code Like 'VN%' and Prepaid_Collect='PREPAID' group by Charge_Code" '
                ',CONTAINER_TYPE,Freight_charge_Master.UnitPriceSale,Freight_charge_Master.quantity,exchange " 'chỉ xuất phí Prepaid trả tiền ở cảng VN sửa ngày 17-1-2008
                Tempdt = ReadTable(sql)
                Dim TempChargeCode As String = ""
                Dim TotalFee As Double = 0
                For j As Integer = 0 To Tempdt.Rows.Count - 1 'lập hết tất cả các phí Container
                    If Tempdt.Rows(j).Item("Charge_Code").ToString.Trim = "LHC" Or Tempdt.Rows(j).Item("Charge_Code").ToString.Trim = "ASC" Then
                        Me.dgddata.Rows.Add(1)
                        CountRow = Me.dgddata.RowCount - 1
                        Me.dgddata.Item("BL_NO", CountRow).Value = dt.Rows(i).Item("BL_NO").ToString

                        Me.dgddata.Item("TAXCODE", CountRow).Value = GetTaxCodeFromPayer(dt.Rows(i).Item("Payer").ToString)


                        Me.dgddata.Item("Payer", CountRow).Value = dt.Rows(i).Item("Payer").ToString
                        Me.dgddata.Item("ETD", CountRow).Value = dt.Rows(i).Item("ETD").ToString
                        Me.dgddata.Item("Charge_Code", CountRow).Value = Tempdt.Rows(j).Item("Charge_Code")
                        Me.dgddata.Item("Fee", CountRow).Value = Tempdt.Rows(j).Item("Fee")

                    Else
                    TempChargeCode &= Tempdt.Rows(j).Item("Charge_Code").ToString.Trim & ","
                    TotalFee += Tempdt.Rows(j).Item("Fee")
                    End If

                Next
                If TempChargeCode.Trim.Length > 0 Then 'nếu có charge thì mới thêm dòng mới
                    TempChargeCode = TempChargeCode.Remove(TempChargeCode.Length - 1)
                    Me.dgddata.Rows.Add(1)
                    CountRow = Me.dgddata.RowCount - 1
                    Me.dgddata.Item("BL_NO", CountRow).Value = dt.Rows(i).Item("BL_NO").ToString

                    Me.dgddata.Item("TAXCODE", CountRow).Value = GetTaxCodeFromPayer(dt.Rows(i).Item("Payer").ToString)

                    Me.dgddata.Item("Payer", CountRow).Value = dt.Rows(i).Item("Payer").ToString
                    Me.dgddata.Item("ETD", CountRow).Value = dt.Rows(i).Item("ETD").ToString
                    Me.dgddata.Item("Charge_Code", CountRow).Value = TempChargeCode
                    Me.dgddata.Item("Fee", CountRow).Value = TotalFee
                End If

                sql = "Select Charge_Code,sum(PriceBillMaster.UnitPrice*PriceBillMaster.Quantity*exchange) as Fee "
                sql &= " from (PriceBillMaster LEFT JOIN Charge On PriceBillMaster.Charge_ID=Charge.Charge_ID ) inner join currency on currency.currency=PriceBillMaster.currency "
                sql &= " Where BL_ID='" & dt.Rows(i).Item("BL_ID").ToString & "' And PriceBillMaster.Continued=1 and Prepaid_collect='PREPAID' group by Charge_Code "
                Tempdt = ReadTable(sql)

                TempChargeCode = ""
                TotalFee = 0
                For j As Integer = 0 To Tempdt.Rows.Count - 1 'lập hết tất cả các Bill

                    If Tempdt.Rows(j).Item("Charge_Code").ToString.Trim = "LHC" Or Tempdt.Rows(j).Item("Charge_Code").ToString.Trim = "ASC" Then
                        Me.dgddata.Rows.Add(1)
                        CountRow = Me.dgddata.RowCount - 1
                        Me.dgddata.Item("BL_NO", CountRow).Value = dt.Rows(i).Item("BL_NO").ToString

                        Me.dgddata.Item("TAXCODE", CountRow).Value = GetTaxCodeFromPayer(dt.Rows(i).Item("Payer").ToString)

                        Me.dgddata.Item("Payer", CountRow).Value = dt.Rows(i).Item("Payer").ToString
                        Me.dgddata.Item("ETD", CountRow).Value = dt.Rows(i).Item("ETD").ToString
                        Me.dgddata.Item("Charge_Code", CountRow).Value = Tempdt.Rows(j).Item("Charge_Code")
                        If Tempdt.Rows(j).Item("Charge_Code") = "ASC" Then
                            Me.dgddata.Item("Fee", CountRow).Value = 25 'Tempdt.Rows(j).Item("Fee")
                        Else
                            Me.dgddata.Item("Fee", CountRow).Value = Tempdt.Rows(j).Item("Fee")
                        End If

                    Else
                        TempChargeCode &= Tempdt.Rows(j).Item("Charge_Code").ToString.Trim & ","
                        TotalFee += Tempdt.Rows(j).Item("Fee")
                    End If
                Next

                If TempChargeCode.Trim.Length > 0 Then 'nếu có charge thì mới thêm dòng mới
                    TempChargeCode = TempChargeCode.Remove(TempChargeCode.Length - 1)
                    Me.dgddata.Rows.Add(1)
                    CountRow = Me.dgddata.RowCount - 1
                    Me.dgddata.Item("BL_NO", CountRow).Value = dt.Rows(i).Item("BL_NO").ToString

                    Me.dgddata.Item("TAXCODE", CountRow).Value = GetTaxCodeFromPayer(dt.Rows(i).Item("Payer").ToString)
                   
                    Me.dgddata.Item("Payer", CountRow).Value = dt.Rows(i).Item("Payer").ToString
                    Me.dgddata.Item("ETD", CountRow).Value = dt.Rows(i).Item("ETD").ToString
                    Me.dgddata.Item("Charge_Code", CountRow).Value = TempChargeCode
                    Me.dgddata.Item("Fee", CountRow).Value = TotalFee
                End If

                sql = " Select BLH_NO From BillOfLading_House Where BL_ID='" & dt.Rows(i).Item("BL_ID").ToString & "' And Continued=1 "
                Tempdt = ReadTable(sql)
                For j As Integer = 0 To Tempdt.Rows.Count - 1 'lập hết tất cả các house
                    Me.dgddata.Rows.Add(1)
                    CountRow = Me.dgddata.RowCount - 1
                    Me.dgddata.Item("BL_NO", CountRow).Value = Tempdt.Rows(j).Item("BLH_NO").ToString

                    Me.dgddata.Item("TAXCODE", CountRow).Value = GetTaxCodeFromPayer(dt.Rows(i).Item("Payer").ToString)
                   
                    Me.dgddata.Item("Payer", CountRow).Value = dt.Rows(i).Item("Payer").ToString
                    Me.dgddata.Item("ETD", CountRow).Value = dt.Rows(i).Item("ETD").ToString
                    Me.dgddata.Item("Tell", CountRow).Value = dt.Rows(i).Item("Tell").ToString
                Next
               
            Next
            'Me.dgddata.DataSource = dt

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    'Sub QueryData(Optional ByVal arg As String = "")
    '    Try
    '        Dim SQL As String
    '        SQL = "select BookingNo as [BookingNo],BL_NO ,Payer,BillOfLading.BL_ID "

    '        SQL &= " from ((BillOfLading INNER JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
    '        SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
    '        SQL &= " Where BillOfLading.Continued=1 " & arg
    '        Dim dt As New DataTable
    '        dt = ReadTable(SQL)
    '        If dt.Rows.Count = 0 Then
    '            MsgBox("No data")
    '            Return
    '        End If
    '        Dim Feedt As New DataTable
    '        If Me.dgddata.Rows.Count > 0 Then
    '            Me.dgddata.Rows.Clear()
    '        End If
    '        Me.dgddata.Rows.Add(dt.Rows.Count)
    '        For i As Integer = 0 To dt.Rows.Count - 1

    '            Me.dgddata.Item("BookingNo", i).Value = dt.Rows(i).Item("BookingNo").ToString.Trim
    '            Me.dgddata.Item("BL_NO", i).Value = dt.Rows(i).Item("BL_NO").ToString.Trim
    '            Me.dgddata.Item("Payer", i).Value = dt.Rows(i).Item("Payer").ToString.Trim

    '            SQL = " Select UnitPriceSale*quantity*exchange as [fee],container_type,QUANTITY,Charge_Code "
    '            SQL &= " From (Freight_Charge_Master LEFT JOIN Charge On  Freight_Charge_Master.Charge_ID=Charge.Charge_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
    '            SQL &= " Where Prepaid_collect='PREPAID' and Freight_Charge_Master.BL_ID='" & dt.Rows(i).Item("BL_ID").ToString & "'"
    '            SQL &= " Group By Charge_Code , UnitPriceSale,exchange,container_type,QUANTITY "
    '            Feedt = ReadTable(SQL)
    '            For j As Integer = 0 To Feedt.Rows.Count - 1
    '                If UCase(Feedt.Rows(j).Item("Charge_Code").ToString.Trim) = "OCB" Then
    '                    Me.dgddata.Item("OceanFreight", i).Value += CDbl(Feedt.Rows(j).Item("Fee").ToString.Trim)
    '                Else
    '                    Dim InsertCol As Boolean = True
    '                    Dim congrow As Double = 0
    '                    ' cong row
    '                    'For row As Integer = 0 To Feedt.Rows.Count - 1


    '                    '    congrow += CDbl(Feedt.Rows(j).Item("Fee").ToString.Trim)
    '                    'Next

    '                    For col As Integer = 0 To Me.dgddata.ColumnCount - 1
    '                        If Me.dgddata.Columns(col).HeaderText = Feedt.Rows(j).Item("Charge_Code").ToString.Trim Then
    '                            Me.dgddata.Rows(i).Cells(col).Value += CDbl(Feedt.Rows(j).Item("Fee").ToString.Trim)
    '                            InsertCol = False
    '                        End If
    '                    Next
    '                    If InsertCol = True Then
    '                        Me.dgddata.Columns.Add(Feedt.Rows(j).Item("Charge_Code").ToString.Trim, Feedt.Rows(j).Item("Charge_Code").ToString.Trim)
    '                        Me.dgddata.Rows(i).Cells(Me.dgddata.ColumnCount - 1).Value = Feedt.Rows(j).Item("Fee").ToString.Trim
    '                    End If
    '                End If
    '            Next

    '        Next

    '        'Me.dgddata.DataSource = dt
    '        Dim t, s As Integer
    '        For t = 0 To Me.dgddata.RowCount - 1
    '            For s = 0 To Me.dgddata.ColumnCount - 1
    '                If Not IsNothing(Me.dgddata.Item(s, t).Value) Then
    '                    If Me.dgddata.Item(s, t).Value.ToString = "0" Or Me.dgddata.Item(s, t).Value.ToString Like "-*" Then
    '                        Me.dgddata.Item(s, t).Style.ForeColor = mcbkColor
    '                    End If
    '                End If

    '            Next
    '        Next
    '        InsertAutoNumberToGrid(Me.dgddata)
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub
    Private Sub frmFreightSummaryExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CurRow = 0
        CurCol = 0
        SetDefaultGrid(Me.dgddata, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        QueryVessel()
        QueryPayer()
    End Sub

    Private Sub dtpFromETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFromETD.ValueChanged
        QueryPayer()
    End Sub

    Private Sub dtpToETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToETD.ValueChanged
        QueryPayer()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryData(" And SailingSchedule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'")
    End Sub

    Private Sub cmdOkPayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkPayer.Click
        QueryData(" And convert(DateTime,ETD)+1>'" & Me.dtpFromETD.Value.Date & "' And Convert(DateTime,ETD)-1<'" & Me.dtpToETD.Value.Date & "' And Payer like '%" & Me.cboPayer.Text.Trim & "%'")
    End Sub

    Private Sub cmdAllPayer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllPayer.Click
        QueryData(" And convert(DateTime,ETD)+1>'" & Me.dtpFromETD.Value.Date & "' And Convert(DateTime,ETD)-1<'" & Me.dtpToETD.Value.Date & "' ")
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgddata, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cdmCancelFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.grpSearch.Visible = False
    End Sub

    Private Sub FindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindToolStripMenuItem.Click
        Me.grpSearch.Visible = True
        Me.grpSearch.BringToFront()
    End Sub
    Sub SetCellFocus(ByVal Col As Integer, ByVal Row As Integer, ByVal dgd As DataGridView)
        Try
            dgd.CurrentCell = dgd.Rows(Row).Cells(Col)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub Search(ByVal searchtext As String, ByRef Row As Integer, ByRef col As Integer, ByVal dgd As DataGridView)
        Try
            searchtext = UCase(searchtext.Trim)
            If Me.dgddata.RowCount = 0 Then
                Return
            End If
            For CurCol As Integer = col To dgd.ColumnCount - 1
                If Not IsNothing(dgd.Rows(Row).Cells(CurCol).Value) Then
                    If dgd.Rows(Row).Cells(CurCol).Value.ToString.Trim Like "*" & searchtext & "*" Then
                        SetCellFocus(CurCol, Row, dgd)

                        col = CurCol + 1
                        Return
                    End If
                End If
            Next
            Row += 1

            For i As Integer = Row To dgd.Rows.Count - 1
                For j As Integer = 0 To dgd.Columns.Count - 1
                    If Not IsNothing(dgd.Rows(i).Cells(j).Value) Then
                        If dgd.Rows(i).Cells(j).Value.ToString.Trim Like "*" & searchtext & "*" Then
                            SetCellFocus(j, i, dgd)
                            Row = i
                            col = j + 1
                            Return
                        End If
                    End If
                Next
            Next
            MsgBox("No More reult")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdFindNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Search(Me.txtSearchText.Text.Trim, CurRow, CurCol, Me.dgddata)
    End Sub

    Private Sub grpSearch_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If Me.grpSearch.Visible = True Then
            CurRow = 0
            CurCol = 0
        End If
    End Sub

    Private Sub grpSearch_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        X = e.X
        Y = e.Y
        Mdown = True
    End Sub

    Private Sub grpSearch_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Mdown Then
            Me.grpSearch.Left = (e.X - X) + Me.grpSearch.Left
            Me.grpSearch.Top = (e.Y - Y) + Me.grpSearch.Top
        End If
    End Sub

    Private Sub grpSearch_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If Mdown Then
            Mdown = False
            Me.grpSearch.Left = (e.X - X) + Me.grpSearch.Left
            Me.grpSearch.Top = (e.Y - Y) + Me.grpSearch.Top
        End If
    End Sub

    Private Sub dgddata_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgddata.CellContentClick
        Try
            CurRow = Me.dgddata.CurrentCell.RowIndex
            CurCol = Me.dgddata.CurrentCell.ColumnIndex
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdFindNext_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFindNext.Click
        Search(Me.txtSearchText.Text.Trim, CurRow, CurCol, Me.dgddata)
    End Sub

    Private Sub cdmCancelFind_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdmCancelFind.Click
        Me.grpSearch.Visible = False
    End Sub
End Class