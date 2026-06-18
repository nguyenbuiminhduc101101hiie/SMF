Public Class frmPayMentIB

    Dim BLIB_ID As String
    Dim mFilter As String
    Dim msgThongBao As String = " (Đã Thanh Toán)"
    Dim oTableBillOfLading As New DataTable
    Public Sub GetData(ByRef dt As DataTable, ByVal strSQL As String)
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmd As New SqlClient.SqlCommand()
        Dim Adapter As New SqlClient.SqlDataAdapter()
        Try
            cmd = New SqlClient.SqlCommand(strSQL, Conn)
            Adapter = New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Conn.Close()
            Conn = Nothing
            cmd.Dispose()
            cmd = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Sub

    Public Sub GetData(ByRef dt As DataSet, ByVal strSQL As String)
        Dim Conn As New SqlClient.SqlConnection(strconnDG)
        Dim cmd As New SqlClient.SqlCommand()
        Dim Adapter As New SqlClient.SqlDataAdapter()
        Try
            cmd = New SqlClient.SqlCommand(strSQL, Conn)
            Adapter = New SqlClient.SqlDataAdapter(cmd)
            'If dt.Tables(0).Rows.Count > 0 Then
            '    dt.Tables(0).Rows.Clear()
            'End If
            dt = New DataSet
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            Conn.Close()
            Conn = Nothing
            cmd.Dispose()
            cmd = Nothing
            Adapter.Dispose()
            Adapter = Nothing
        End Try
    End Sub


    Sub QueryBLOfLading(Optional ByVal agr As String = "")
        On Error GoTo Err_Renamed
        'Dim id As String = "BLIB_ID"
        'Dim value As String = "BLIB_NO"
        Dim strSQL As String
        strSQL = "Select BLIB_ID,BLIB_NO From BILLOFLADINGIB where Continued=1" & agr & "  Order By BLIB_NO ASC"
        'Dim Conn As New SqlClient.SqlConnection(strconnDG)
        'Conn.Open()

        'Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
        'Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
        'Dim dt As New DataTable
        GetData(oTableBillOfLading, strSQL)
        Me.lvBL_NO.DisplayMember = "BLIB_NO"
        Me.lvBL_NO.ValueMember = "BLIB_ID"
        Me.lvBL_NO.DataSource = oTableBillOfLading
        CheckPaid()
        Exit Sub
Err_Renamed:
        'MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub CheckPaid()
        Try
            Dim strQuery As String = "select * from PayMentIB where pay>0"
            Dim dt As New DataTable
            GetData(dt, strQuery)
            For i As Integer = 0 To oTableBillOfLading.Rows.Count - 1
                For j As Integer = 0 To dt.Rows.Count - 1
                    If oTableBillOfLading.Rows(i).Item("BLIB_ID").ToString.Trim = dt.Rows(j).Item("BLIB_ID").ToString.Trim Then
                        oTableBillOfLading.Rows(i).Item("BLIB_NO") &= msgThongBao
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmPayMent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            mFilter = ""
            GetCurrency(Me.cboCurrency)
            mFilter = " And (select Count(*) "
            mFilter &= " from Freight_Charge_IB "
            mFilter &= " where (Freight_Charge_IB.BLIB_ID=BillOfLadingIB.BLIB_ID And Prepaid_Collect='COLLECT'))>0"
            QueryBLOfLading(mFilter)


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub lvBL_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBL_NO.SelectedIndexChanged
        Try
            If IsNothing(Me.lvBL_NO.SelectedValue) Then
                Return
            End If
            BLIB_ID = Me.lvBL_NO.SelectedValue.ToString
            Me.txtBL_NO.Text = Strings.Replace(Me.lvBL_NO.Text, msgThongBao, "").Trim
            Dim strSQL As String

            Me.cboCurrency.SelectedIndex = 0
            Me.txtCollectCurrency.Text = ""
            Me.txtCollectFee.Text = "0"
            Me.txtContainer.Text = ""
            Me.txtPrepaidCurrency.Text = ""
            Me.txtPrepaidFee.Text = "0"
            Me.txtBookingPrePaidFee.Text = "0"
            Me.txtBookingPrepaidCurrency.Text = ""
            Me.txtBookingCollectFee.Text = "0"
            Me.txtBookingCollectCurrency.Text = ""
            'Me.txtRate.Text = "0"
            Me.txtPay.Text = "0"
            Me.txtVND.Text = "0"
            Me.txtRemaind.Text = "0"
            Me.txtUserid.Text = ""
            Me.txtUpdateTime.Text = ""
            Me.dtpPayDate.Text = Now.Date.ToString
            Me.txtReceiptNo.Text = ""
            Me.txtPayerAddress.Text = ""
            Me.txtPayerName.Text = ""


            strSQL = " Select Prepaid_Collect,Sum(UnitPrice*Quantity) as Fee,Currency  "
            strSQL &= " From PriceBillIB "
            strSQL &= " Where Continued=1 And BLIB_NO='" & Me.txtBL_NO.Text & "' Group By Prepaid_Collect,Currency"
            Dim dtFee As New DataTable
            GetData(dtFee, strSQL)
            If dtFee.Rows.Count >= 3 Then
                DisplayMessage(True, "Currency is invalid Check again please")
            End If

            For i As Integer = 0 To dtFee.Rows.Count - 1
                If UCase(dtFee.Rows(i).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                    Me.txtPrepaidFee.Text = FormatString(CDbl(dtFee.Rows(i).Item("Fee").ToString))
                    Me.txtPrepaidCurrency.Text = dtFee.Rows(i).Item("Currency").ToString
                Else
                    Me.txtCollectFee.Text = FormatString(CDbl(dtFee.Rows(i).Item("Fee").ToString))
                    Me.txtCollectCurrency.Text = dtFee.Rows(i).Item("Currency").ToString
                End If
            Next
            dtFee = Nothing

            strSQL = " Select Prepaid_Collect, Sum(UnitPrice*Quantity) as fee, Currency "
            strSQL &= " From FREIGHT_CHARGE_IB "
            strSQL &= " Where BLIB_ID='" & BLIB_ID & "' And Continued=1"
            strSQL &= " Group By Prepaid_Collect,Currency "

            Dim dtFreight As New DataTable
            GetData(dtFreight, strSQL)

            For i As Integer = 0 To dtFreight.Rows.Count - 1
                If UCase(dtFreight.Rows(i).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                    Me.txtBookingPrePaidFee.Text = FormatString(CDbl(dtFreight.Rows(i).Item("Fee").ToString))
                    Me.txtBookingPrepaidCurrency.Text = dtFreight.Rows(i).Item("Currency").ToString
                Else
                    Me.txtBookingCollectFee.Text = FormatString(CDbl(dtFreight.Rows(i).Item("Fee").ToString))
                    Me.txtBookingCollectCurrency.Text = dtFreight.Rows(i).Item("Currency").ToString
                End If
            Next

            strSQL = "select Count(Container_Type) as Num From CargoIB "
            strSQL &= " Where BLIB_ID='" & BLIB_ID & "' And Continued=1"
            Dim dtCargo As New DataTable
            GetData(dtCargo, strSQL)
            If dtCargo.Rows.Count > 0 Then
                Me.txtContainer.Text = dtCargo.Rows(0).Item("Num").ToString
            End If


            strSQL = "select * from PayMentIB Where BLIB_ID='" & BLIB_ID & "'"
            Dim dtPayMent As New DataTable
            GetData(dtPayMent, strSQL)
            If dtPayMent.Rows.Count > 0 Then
                Me.cboCurrency.Text = dtPayMent.Rows(0).Item("Currency").ToString
                Me.txtRate.Text = FormatString(CDbl(dtPayMent.Rows(0).Item("Rate").ToString))
                Me.txtPay.Text = FormatString(CDbl(dtPayMent.Rows(0).Item("Pay").ToString))
                Me.txtVND.Text = FormatString(CDbl(dtPayMent.Rows(0).Item("VND").ToString))
                Me.txtRemaind.Text = FormatString(CDbl(dtPayMent.Rows(0).Item("Remain").ToString))
                Me.dtpPayDate.Text = dtPayMent.Rows(0).Item("PayDate").ToString
                Me.txtUserid.Text = dtPayMent.Rows(0).Item("Userid").ToString
                Me.txtUpdateTime.Text = CDate(dtPayMent.Rows(0).Item("UpdateTime").ToString)
                Me.txtCustomer.Text = dtPayMent.Rows(0).Item("Customer").ToString.Trim
                Me.txtReceiptNo.Text = dtPayMent.Rows(0).Item("receiptNo").ToString.Trim
                Me.txtPayerName.Text = dtPayMent.Rows(0).Item("PayerName").ToString.Trim
                Me.txtPayerAddress.Text = dtPayMent.Rows(0).Item("PayerAddress").ToString.Trim

            Else
                strSQL = "Select Consignee_1 as Customer,BLIB_NO "
                strSQL &= " from (BillOfLadingIB LEFT JOIN Consignee On BillOfLadingIB.Consignee_ID=Consignee.Consignee_ID)"
                strSQL &= " Where BLIB_ID='" & BLIB_ID & "'"
                Dim dtBL As New DataTable
                GetData(dtBL, strSQL)
                If dtBL.Rows.Count > 0 Then
                    Me.txtBLNOSearch.Text = dtBL.Rows(0).Item("BLIB_NO").ToString.Trim
                    Me.txtCustomer.Text = dtBL.Rows(0).Item("Customer").ToString.Trim
                End If
                dtBL = Nothing
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFind.Click
        Try


            Dim strSQL As String
            strSQL = "select Top 1 * from BillOfLadingIB Where BLIB_NO Like '%" & Me.txtBLNOSearch.Text.Trim & "%' And Continued=1 "
            Dim dt As New DataTable
            GetData(dt, strSQL)
            If dt.Rows.Count > 0 Then
                Me.lvBL_NO.SelectedIndex = Me.lvBL_NO.FindStringExact(dt.Rows(0).Item("BLIB_NO").ToString.Trim)
            Else
                DisplayMessage(True, "This B/L Is not in database ")
            End If

        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            strQuery = "SELECT * "
            strQuery = strQuery & "FROM PayMentIB "
            strQuery = strQuery & "WHERE BLIB_ID = '" & Me.lvBL_NO.SelectedValue.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("PayMent_id").Value = NewId()
                    .Fields("BLIB_ID").Value = "{" & Me.lvBL_NO.SelectedValue.ToString & "}"
                End If
                .Fields("Currency").Value = Me.cboCurrency.Text
                .Fields("Rate").Value = Me.txtRate.Text
                .Fields("Pay").Value = Me.txtPay.Text
                .Fields("VND").Value = Me.txtVND.Text
                .Fields("Remain").Value = Me.txtRemaind.Text
                .Fields("receiptNo").Value = Me.txtReceiptNo.Text
                .Fields("PayDate").Value = Me.dtpPayDate.Value.Date
                .Fields("Customer").Value = Me.txtCustomer.Text
                .Fields("PayerName").Value = Me.txtPayerName.Text
                .Fields("PayerAddress").Value = Me.txtPayerAddress.Text
                .Update()
            End With
            rs.Close()
            rs = Nothing
            MsgBox("Updated!")
            If CDbl(Me.txtPay.Text) > 0 Then
                Me.lvBL_NO.SelectedValue = BLIB_ID
                Dim index As Integer = Me.lvBL_NO.SelectedIndex
                oTableBillOfLading.Rows(index).Item("BLIB_NO") = Strings.Replace(oTableBillOfLading.Rows(index).Item("BLIB_NO"), msgThongBao, "") & msgThongBao
                'Me.lvBL_NO.DataSource = oTableBillOfLading
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        Me.txtVND.Text = FormatString(CDbl(IIf(Me.txtRate.Text <> "", Me.txtRate.Text, 0)) * CDbl(IIf(Me.txtPay.Text <> "", Me.txtPay.Text, 0)))
        Me.txtRate.Text = FormatString(CDbl(Me.txtRate.Text))
    End Sub

    Private Sub txtPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPay.TextChanged
        Try
            Me.txtVND.Text = FormatString(CDbl(IIf(Me.txtRate.Text <> "", Me.txtRate.Text, 0)) * CDbl(IIf(Me.txtPay.Text <> "", Me.txtPay.Text, 0)))
            Me.txtPay.Text = FormatString(CDbl(Me.txtPay.Text))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtRemaind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemaind.TextChanged
        Me.txtRemaind.Text = FormatString(CDbl(Me.txtRemaind.Text))
    End Sub

    Private Sub txtPrepaidFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrepaidFee.TextChanged
        Try
            Me.txtTotalPrePaid.Text = CDbl(IIf(Me.txtPrepaidFee.Text.Trim.Length > 0, Me.txtPrepaidFee.Text, 0)) + CDbl(IIf(Me.txtBookingPrePaidFee.Text.Trim.Length > 0, Me.txtBookingPrePaidFee.Text, 0))

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtBookingPrePaidFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBookingPrePaidFee.TextChanged
        Try
            Me.txtTotalPrePaid.Text = CDbl(IIf(Me.txtPrepaidFee.Text.Trim.Length > 0, Me.txtPrepaidFee.Text, 0)) + CDbl(IIf(Me.txtBookingPrePaidFee.Text.Trim.Length > 0, Me.txtBookingPrePaidFee.Text, 0))

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtCollectFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCollectFee.TextChanged
        Try
            Me.txtTotalCollect.Text = CDbl(IIf(Me.txtCollectFee.Text.Trim.Length > 0, Me.txtCollectFee.Text, 0)) + CDbl(IIf(Me.txtBookingCollectFee.Text.Trim.Length > 0, Me.txtBookingCollectFee.Text, 0))

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtBookingCollectFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBookingCollectFee.TextChanged
        Try
            Me.txtTotalCollect.Text = CDbl(IIf(Me.txtCollectFee.Text.Trim.Length > 0, Me.txtCollectFee.Text, 0)) + CDbl(IIf(Me.txtBookingCollectFee.Text.Trim.Length > 0, Me.txtBookingCollectFee.Text, 0))

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryBLOfLading("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Sub Export()
        Try

            Dim app As Excel.Application
            app = New Excel.Application

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
            Me.Cursor = Cursors.WaitCursor
            Dim nRow As Integer = 4

            Dim BLIB_NO As String
            Dim tbl As New DataSet
            tbl = ReadDataSet("Select BLIB_ID,BLIB_NO,ETA From BILLOFLADINGIB where Continued=1 " & mFilter & " Order by  ETA")
            If tbl.Tables(0).Rows.Count = 0 Then app.Quit()

            ws.Range("A3").Value = "ETA"
            ws.Range("C3").Value = "Bill No"
            ws.Range("B3").Value = "Receipt No"
            ws.Range("D3").Value = "Containers"
            ws.Range("E3").Value = "Customer"
            ws.Range("F3").Value = "Prepaid Fee"
            ws.Range("G4").Value = "Prepaid Currency"
            ws.Range("H3").Value = "Collect Fee"
            ws.Range("I3").Value = "Collect Currency"
            ws.Range("J3").Value = "Currency"
            ws.Range("K3").Value = "Rate"
            ws.Range("L3").Value = "Pay"
            ws.Range("M3").Value = "VND"
            ws.Range("N3").Value = "Remain"
            ws.Range("O3").Value = "Pay date"
            ws.Range("P3").Value = "User Update"
            ws.Range("Q3").Value = "Update Time"

            drawBorder(ws, 5, "A3", "Q3")
            drawBorder(ws, 7, "A3", "Q3")

            For k As Integer = 0 To tbl.Tables(0).Rows.Count - 1

                BLIB_NO = tbl.Tables(0).Rows(k).Item("BLIB_NO").ToString
                BLIB_ID = tbl.Tables(0).Rows(k).Item("BLIB_ID").ToString
                Dim strSQL As String
                Me.cboCurrency.SelectedIndex = 0


                Dim Currency As String = Me.cboCurrency.Text.Trim
                Dim CollectCurrency As String = ""
                Dim CollectFee As String = "0"
                Dim Container As String = ""
                Dim PrepaidCurrency As String = ""
                Dim PrepaidFee As String = "0"
                Dim Rate As String = "0"
                Dim Pay As String = "0"
                Dim VND As String = "0"
                Dim Remaind As String = "0"
                Dim Userid As String = ""
                Dim UpdateTime As String = ""
                Dim PayDate As String = Now.Date.ToString
                Dim ReceiptNo As String = ""
                Dim Customer As String = ""

                strSQL = " Select Prepaid_Collect,Sum(UnitPrice*Quantity) as Fee,Currency  "
                strSQL &= " From PriceBillIB "
                strSQL &= " Where Continued=1 And BLIB_NO='" & BLIB_NO & "' Group By Prepaid_Collect,Currency"
                Dim dtFee As New DataSet
                GetData(dtFee, strSQL)
                'If dtFee.Rows.Count >= 3 Then
                '    DisplayMessage(True, "Currency is invalid Check again please")
                'End If

                For i As Integer = 0 To dtFee.Tables(0).Rows.Count - 1
                    If UCase(dtFee.Tables(0).Rows(i).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                        PrepaidFee = FormatString(CDbl(dtFee.Tables(0).Rows(i).Item("Fee").ToString))
                        PrepaidCurrency = dtFee.Tables(0).Rows(i).Item("Currency").ToString
                    Else
                        CollectFee = FormatString(CDbl(dtFee.Tables(0).Rows(i).Item("Fee").ToString))
                        CollectCurrency = dtFee.Tables(0).Rows(i).Item("Currency").ToString
                    End If
                Next
                dtFee = Nothing
                strSQL = "select Count(Container_Type) as Num From CargoIB "
                strSQL &= " Where BLIB_ID='" & BLIB_ID & "' And Continued=1"
                Dim dtCargo As New DataSet
                GetData(dtCargo, strSQL)
                If dtCargo.Tables(0).Rows.Count > 0 Then
                    Container = dtCargo.Tables(0).Rows(0).Item("Num").ToString
                End If


                strSQL = "select * from PayMentIB Where BLIB_ID='" & BLIB_ID & "'"
                Dim dtPayMent As New DataSet
                GetData(dtPayMent, strSQL)
                If dtPayMent.Tables(0).Rows.Count > 0 Then
                    Currency = dtPayMent.Tables(0).Rows(0).Item("Currency").ToString
                    Rate = FormatString(CDbl(dtPayMent.Tables(0).Rows(0).Item("Rate").ToString))
                    Pay = FormatString(CDbl(dtPayMent.Tables(0).Rows(0).Item("Pay").ToString))
                    VND = FormatString(CDbl(dtPayMent.Tables(0).Rows(0).Item("VND").ToString))
                    Remaind = FormatString(CDbl(dtPayMent.Tables(0).Rows(0).Item("Remain").ToString))
                    PayDate = dtPayMent.Tables(0).Rows(0).Item("PayDate").ToString
                    Userid = dtPayMent.Tables(0).Rows(0).Item("Userid").ToString
                    UpdateTime = CDate(dtPayMent.Tables(0).Rows(0).Item("UpdateTime").ToString)
                    Customer = dtPayMent.Tables(0).Rows(0).Item("Customer").ToString.Trim
                    ReceiptNo = dtPayMent.Tables(0).Rows(0).Item("receiptNo").ToString.Trim
                Else
                    strSQL = "Select Consignee_1 as Customer,BLIB_NO "
                    strSQL &= " from (BillOfLadingIB LEFT JOIN Consignee On BillOfLadingIB.Consignee_ID=Consignee.Consignee_ID)"
                    strSQL &= " Where BLIB_ID='" & BLIB_ID & "'"
                    Dim dtBL As New DataSet
                    GetData(dtBL, strSQL)
                    If dtBL.Tables(0).Rows.Count > 0 Then
                        'Me.txtBLNOSearch.Text = dtBL.Rows(0).Item("BLIB_NO").ToString.Trim
                        Customer = dtBL.Tables(0).Rows(0).Item("Customer").ToString.Trim
                    End If
                    dtBL = Nothing
                End If

                ws.Range("A" & nRow).Value = tbl.Tables(0).Rows(k).Item("ETA") '"DATE_OF_ISSUE"
                ws.Range("C" & nRow).Value = tbl.Tables(0).Rows(k).Item("BLIB_NO") '"Bill No"
                ws.Range("B" & nRow).Value = ReceiptNo '"Receipt No"
                ws.Range("D" & nRow).Value = Container '"Containers"
                ws.Range("E" & nRow).Value = Customer '"Customer"
                ws.Range("F" & nRow).Value = PrepaidFee  '"Prepaid Fee"
                ws.Range("G" & nRow).Value = PrepaidCurrency '"Prepaid Currency"
                ws.Range("H" & nRow).Value = CollectFee  '"Collect Fee"
                ws.Range("I" & nRow).Value = CollectCurrency '"Collect Currency"
                ws.Range("J" & nRow).Value = Currency '"Currency"
                ws.Range("K" & nRow).Value = Rate '"Rate"
                ws.Range("L" & nRow).Value = Pay '"Pay"
                ws.Range("M" & nRow).Value = VND '"VND"
                ws.Range("N" & nRow).Value = Remaind '"Remain"
                ws.Range("O" & nRow).Value = PayDate '"Pay date"
                ws.Range("P" & nRow).Value = Userid '"User Update"
                ws.Range("Q" & nRow).Value = UpdateTime '"Update Time"

                nRow += 1
            Next

            ws.Range("A3", "Q" & nRow - 1).Cells.Columns.AutoFit()

            drawBorder(ws, 5, "A3", "Q" & nRow - 1)
            drawBorder(ws, 6, "A4", "Q" & nRow - 1, 3)
            drawBorder(ws, 7, "A4", "Q" & nRow - 1, 3)


            Dim d As Date = CDate(Getdate())
            Dim path = "c:\PayMentIB - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
            path = ProccessString(path)
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            Me.Cursor = Cursors.Default

            MsgBox("Complete, path : " & path)
            app.Quit()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub smnuExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuExport.Click
        If Me.lvBL_NO.Items.Count = 0 Then
            Return
        End If
        Export()
    End Sub

    Private Sub smnuDateOfIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuDateOfIssue.Click
        Me.grpIssue.Visible = True
    End Sub

    Private Sub cmdOKIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOKIssue.Click
        Me.grpIssue.Visible = False
        mFilter = " and '" & Me.dtpIssueFrom.Value.Date & "'<=ETA and ETA<='" & Me.dtpIssueTo.Value.Date & "'"
        QueryBLOfLading(" " & mFilter)
    End Sub

    Private Sub cmdCancelIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelIssue.Click
        Me.grpIssue.Visible = False
    End Sub

    Private Sub chkAllBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAllBill.CheckedChanged

        Try
            mFilter = ""
            QueryBLOfLading(mFilter)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub chkCollectBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCollectBill.CheckedChanged
        Try
            mFilter = " And (select Count(*) "
            mFilter &= " from Freight_Charge_IB "
            mFilter &= " where (Freight_Charge_IB.BLIB_ID=BillOfLadingIB.BLIB_ID And Prepaid_Collect='COLLECT'))>0"
            QueryBLOfLading(mFilter)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub chkPrepaidBill_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPrepaidBill.CheckedChanged
        Try
            mFilter = " And (select Count(*) "
            mFilter &= " from Freight_Charge_IB "
            mFilter &= " where (Freight_Charge_IB.BLIB_ID=BillOfLadingIB.BLIB_ID And Prepaid_Collect='COLLECT'))=0"
            QueryBLOfLading(mFilter)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub
End Class