Public Class frmPayMent

    Dim BL_ID As String
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
        'Dim id As String = "BL_ID"
        'Dim value As String = "BL_No"
        Dim strSQL As String
        strSQL = "Select BL_ID,BL_No,bl_no as info From (BILLOFLADING left join ContainerOutBoundNotify on billoflading.ContainerOutBoundNotifyId  = ContainerOutBoundNotify.ContainerOutBoundNotifyId ) left join sailingschedule on sailingschedule.sailingscheduleid=ContainerOutBoundNotify.sailingscheduleid where billoflading.Continued=1" & agr & "  Order By BL_NO ASC"
        'Dim Conn As New SqlClient.SqlConnection(strconnDG)
        'Conn.Open()

        'Dim cmd As New SqlClient.SqlCommand(strSQL, Conn)
        'Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
        'Dim dt As New DataTable
        GetData(oTableBillOfLading, strSQL)
        Me.lvBL_NO.DisplayMember = "BL_NO"
        Me.lvBL_NO.ValueMember = "BL_ID"
        'Me.lvBL_NO.DisplayMember = "info"
        Me.lvBL_NO.DataSource = oTableBillOfLading
        CheckPaid()
        Exit Sub
Err_Renamed:
        'MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub CheckPaid()
        Try
            Dim strQuery As String = "select * from Payment where pay>0 or GetBillName <> '' or GetBillName is not NULL "
            Dim dt As New DataTable
            GetData(dt, strQuery)
            For i As Integer = 0 To oTableBillOfLading.Rows.Count - 1
                For j As Integer = 0 To dt.Rows.Count - 1
                    If oTableBillOfLading.Rows(i).Item("BL_ID").ToString.Trim = dt.Rows(j).Item("BL_ID").ToString.Trim Then
                        oTableBillOfLading.Rows(i).Item("Bl_no") &= "     [" + "(" + dt.Rows(j).Item("payername").ToString.Trim + "-" + IIf(dt.Rows(j).Item("payername").ToString.Trim <> "", dt.Rows(j).Item("paydate").ToString.Trim, "") + ")" + "-" + "(" + dt.Rows(j).Item("getbillname").ToString.Trim + "-" + dt.Rows(j).Item("getbilldate").ToString.Trim + ")" + "]"
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
            QueryBLOfLading()
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try


    End Sub

    Private Sub lvBL_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvBL_NO.SelectedIndexChanged
        Try
            If IsNothing(Me.lvBL_NO.SelectedValue) Then
                Return
            End If
            BL_ID = Me.lvBL_NO.SelectedValue.ToString
            Me.txtBL_NO.Text = Strings.Replace(Me.lvBL_NO.Text, msgThongBao, "").Trim
            Dim strSQL As String

            Me.cboCurrency.SelectedIndex = 0
            
            Me.txtContainer.Text = ""
         
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

            Me.txtPayerName.Text = ""
            Me.dtpGetBillDate.Text = Now.Date.ToString
            Me.txtGetBillName.Text = ""

            strSQL = " Select Prepaid_Collect,Sum(UnitPrice*Quantity) as Fee,Currency  "
            strSQL &= " From PRICEBILLMASTER "
            strSQL &= " Where Continued=1 And BL_ID='" & BL_ID & "' Group By Prepaid_Collect,Currency"
            Dim dtFee As New DataTable
            GetData(dtFee, strSQL)
            If dtFee.Rows.Count >= 3 Then
                DisplayMessage(True, "Currency is invalid Check again please")
            End If

            'For i As Integer = 0 To dtFee.Rows.Count - 1
            '    If UCase(dtFee.Rows(i).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
            '        Me.txtPrepaidFee.Text = FormatString(CDbl(dtFee.Rows(i).Item("Fee").ToString))
            '        Me.txtPrepaidCurrency.Text = dtFee.Rows(i).Item("Currency").ToString + "(USD)"
            '    Else
            '        Me.txtCollectFee.Text = FormatString(CDbl(dtFee.Rows(i).Item("Fee").ToString))
            '        Me.txtCollectCurrency.Text = dtFee.Rows(i).Item("Currency").ToString + "(USD)"
            '    End If
            'Next
            dtFee = Nothing

            strSQL = " Select Prepaid_Collect, Sum(UnitPriceSale*Quantity*exchange) as fee, FREIGHT_CHARGE_Master.Currency "
            strSQL &= " From FREIGHT_CHARGE_Master inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            strSQL &= " Where BL_ID='" & BL_ID & "' And FREIGHT_CHARGE_Master.Continued=1"
            strSQL &= " Group By Prepaid_Collect,FREIGHT_CHARGE_Master.Currency "

            Dim dtFreight As New DataTable
            GetData(dtFreight, strSQL)

            For i As Integer = 0 To dtFreight.Rows.Count - 1
                If UCase(dtFreight.Rows(i).Item("Prepaid_Collect").ToString.Trim) = "PREPAID" Then
                    Me.txtBookingPrePaidFee.Text = FormatString(CDbl(dtFreight.Rows(i).Item("Fee").ToString))
                    Me.txtBookingPrepaidCurrency.Text = dtFreight.Rows(i).Item("Currency").ToString + "(USD)"
                Else
                    Me.txtBookingCollectFee.Text = FormatString(CDbl(dtFreight.Rows(i).Item("Fee").ToString))
                    Me.txtBookingCollectCurrency.Text = dtFreight.Rows(i).Item("Currency").ToString + "(USD)"
                End If
            Next

            strSQL = "select Count(Container_Type) as Num From Cargo "
            strSQL &= " Where BL_ID='" & BL_ID & "' And Continued=1"
            Dim dtCargo As New DataTable
            GetData(dtCargo, strSQL)
            If dtCargo.Rows.Count > 0 Then
                Me.txtContainer.Text = dtCargo.Rows(0).Item("Num").ToString
            End If


            strSQL = "select * from PayMent Where BL_ID='" & BL_ID & "'"
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
                'Me.txtPayerAddress.Text = dtPayMent.Rows(0).Item("PayerAddress").ToString.Trim
                ' getbill
                Me.dtpGetBillDate.Text = dtPayMent.Rows(0).Item("GetBillDate").ToString
                Me.txtGetBillName.Text = dtPayMent.Rows(0).Item("GetBillName").ToString.Trim

            Else
                strSQL = "Select Consignee_1 as Customer,BL_NO "
                strSQL &= " from (BillOfLading LEFT JOIN Consignee On BillOfLading.Consignee_ID=Consignee.Consignee_ID)"
                strSQL &= " Where BL_ID='" & BL_ID & "'"
                Dim dtBL As New DataTable
                GetData(dtBL, strSQL)
                If dtBL.Rows.Count > 0 Then
                    Me.txtBLNOSearch.Text = dtBL.Rows(0).Item("BL_NO").ToString.Trim
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
            strSQL = "select Top 1 * from BillOfLading Where BL_NO Like '%" & Me.txtBLNOSearch.Text.Trim & "%' And Continued=1 "
            Dim dt As New DataTable
            GetData(dt, strSQL)
            If dt.Rows.Count > 0 Then
               
                Me.lvBL_NO.SelectedIndex = Me.lvBL_NO.FindString(dt.Rows(0).Item("bl_no").ToString.Trim, 0)

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
            strQuery = strQuery & "FROM Payment "
            strQuery = strQuery & "WHERE BL_ID = '" & Me.lvBL_NO.SelectedValue.ToString & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("PayMent_id").Value = NewId()
                    .Fields("BL_ID").Value = "{" & Me.lvBL_NO.SelectedValue.ToString & "}"
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
                '.Fields("PayerAddress").Value = Me.txtPayerAddress.Text
                'getbill
                .Fields("GetBillDate").Value = Me.dtpGetBillDate.Value.Date
                .Fields("GetBillName").Value = Me.txtGetBillName.Text

                .Update()
            End With
            rs.Close()
            rs = Nothing
            MsgBox("Updated!")
            If CDbl(Me.txtPay.Text) > 0 Then
                Me.lvBL_NO.SelectedValue = BL_ID
                Dim index As Integer = Me.lvBL_NO.SelectedIndex
                oTableBillOfLading.Rows(index).Item("BL_NO") = Strings.Replace(oTableBillOfLading.Rows(index).Item("BL_NO"), msgThongBao, "") & msgThongBao
                'Me.lvBL_NO.DataSource = oTableBillOfLading
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRate.Leave
        Me.txtRate.Text = FormatString2(CDbl(Me.txtRate.Text))
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged
        'Me.txtVND.Text = FormatString(CDbl(IIf(Me.txtRate.Text <> "", Me.txtRate.Text, 0)) * CDbl(IIf(Me.txtPay.Text <> "", Me.txtPay.Text, 0)))

    End Sub

    Private Sub txtPay_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPay.Leave
        ' Me.txtRemaind.Text = Me.txtTotalPrePaid.Text - Me.txtPay.Text
    End Sub

    Private Sub txtPay_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPay.TextChanged
        Try
            Me.txtVND.Text = FormatString(CDbl(IIf(Me.txtRate.Text <> "", Me.txtRate.Text, 0)) * CDbl(IIf(Me.txtPay.Text <> "", Me.txtPay.Text, 0)))
            'Me.txtPay.Text = FormatString2(CDbl(Me.txtPay.Text))
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtRemaind_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRemaind.Leave
        Me.txtRemaind.Text = FormatString(CDbl(Me.txtRemaind.Text))
    End Sub

    Private Sub txtRemaind_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRemaind.TextChanged

    End Sub

    Private Sub txtPrepaidFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Try
        '    Me.txtTotalPrePaid.Text = CDbl(IIf(Me.txtPrepaidFee.Text.Trim.Length > 0, Me.txtPrepaidFee.Text, 0)) + CDbl(IIf(Me.txtBookingPrePaidFee.Text.Trim.Length > 0, Me.txtBookingPrePaidFee.Text, 0))

        'Catch ex As Exception
        '    DisplayMessage(True, Err.Description)
        'End Try
    End Sub

    Private Sub txtBookingPrePaidFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBookingPrePaidFee.TextChanged, txtBookingPrePaidFeeBuy.TextChanged
        Try
            'Me.txtTotalPrePaid.Text = CDbl(IIf(Me.txtPrepaidFee.Text.Trim.Length > 0, Me.txtPrepaidFee.Text, 0)) + CDbl(IIf(Me.txtBookingPrePaidFee.Text.Trim.Length > 0, Me.txtBookingPrePaidFee.Text, 0))

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtCollectFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Me.txtTotalCollect.Text = CDbl(IIf(Me.txtCollectFee.Text.Trim.Length > 0, Me.txtCollectFee.Text, 0)) + CDbl(IIf(Me.txtBookingCollectFee.Text.Trim.Length > 0, Me.txtBookingCollectFee.Text, 0))

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub txtBookingCollectFee_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBookingCollectFee.TextChanged, TextBox5.TextChanged
        Try
            'Me.txtTotalCollect.Text = CDbl(IIf(Me.txtCollectFee.Text.Trim.Length > 0, Me.txtCollectFee.Text, 0)) + CDbl(IIf(Me.txtBookingCollectFee.Text.Trim.Length > 0, Me.txtBookingCollectFee.Text, 0))

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

            Dim BL_ID As String
            Dim tbl As New DataSet
            tbl = ReadDataSet("Select BL_ID,BL_No,DATE_OF_ISSUE From BILLOFLADING where Continued=1 " & mFilter & " Order by  DATE_OF_ISSUE")
            If tbl.Tables(0).Rows.Count = 0 Then app.Quit()

            ws.Range("A3").Value = "DATE_OF_ISSUE"
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
            ws.Range("P3").Value = "Pay Name"
            ws.Range("Q3").Value = "Get Bill date"
            ws.Range("R3").Value = "Get Bill Name"
            ws.Range("S3").Value = "User Update"
            ws.Range("T3").Value = "Update Time"

            drawBorder(ws, 5, "A3", "T3")
            drawBorder(ws, 7, "A3", "T3")

            For k As Integer = 0 To tbl.Tables(0).Rows.Count - 1

                BL_ID = tbl.Tables(0).Rows(k).Item("BL_ID").ToString

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
                Dim PayDate As String = ""
                Dim ReceiptNo As String = ""
                Dim Customer As String = ""
                '---
                Dim Payname As String = ""
                Dim getbilldate As String = ""
                Dim getbillname As String = ""
                '---------

                strSQL = " Select Prepaid_Collect,Sum(UnitPrice*Quantity) as Fee,Currency  "
                strSQL &= " From PRICEBILLMASTER "
                strSQL &= " Where Continued=1 And BL_ID='" & BL_ID & "' Group By Prepaid_Collect,Currency"
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
                strSQL = "select Count(Container_Type) as Num From Cargo "
                strSQL &= " Where BL_ID='" & BL_ID & "' And Continued=1"
                Dim dtCargo As New DataSet
                GetData(dtCargo, strSQL)
                If dtCargo.Tables(0).Rows.Count > 0 Then
                    Container = dtCargo.Tables(0).Rows(0).Item("Num").ToString
                End If


                strSQL = "select * from PayMent Where BL_ID='" & BL_ID & "'"
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
                    Payname = dtPayMent.Tables(0).Rows(0).Item("payername").ToString.Trim
                    getbilldate = dtPayMent.Tables(0).Rows(0).Item("getbilldate").ToString.Trim
                    getbillname = dtPayMent.Tables(0).Rows(0).Item("getbillname").ToString.Trim
                Else
                    strSQL = "Select Consignee_1 as Customer,BL_NO "
                    strSQL &= " from (BillOfLading LEFT JOIN Consignee On BillOfLading.Consignee_ID=Consignee.Consignee_ID)"
                    strSQL &= " Where BL_ID='" & BL_ID & "'"
                    Dim dtBL As New DataSet
                    GetData(dtBL, strSQL)
                    If dtBL.Tables(0).Rows.Count > 0 Then
                        'Me.txtBLNOSearch.Text = dtBL.Rows(0).Item("BL_NO").ToString.Trim
                        Customer = dtBL.Tables(0).Rows(0).Item("Customer").ToString.Trim
                    End If
                    dtBL = Nothing
                End If

                ws.Range("A" & nRow).Value = tbl.Tables(0).Rows(k).Item("DATE_OF_ISSUE") '"DATE_OF_ISSUE"
                ws.Range("C" & nRow).Value = tbl.Tables(0).Rows(k).Item("BL_No") '"Bill No"
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
                ws.Range("P" & nRow).Value = Payname
                ws.Range("Q" & nRow).Value = getbilldate
                ws.Range("R" & nRow).Value = getbillname

                ws.Range("S" & nRow).Value = Userid '"User Update"
                ws.Range("T" & nRow).Value = UpdateTime '"Update Time"

                nRow += 1
            Next

            ws.Range("A3", "Q" & nRow - 1).Cells.Columns.AutoFit()

            drawBorder(ws, 5, "A3", "T" & nRow - 1)
            drawBorder(ws, 6, "A4", "T" & nRow - 1, 3)
            drawBorder(ws, 7, "A4", "T" & nRow - 1, 3)


            Dim d As Date = CDate(Getdate())
            Dim path = "c:\Payment - " & d.Date & " " & d.Hour & "-" & d.Minute & "-" & d.Second & " .xls"
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
        mFilter = " and '" & Me.dtpIssueFrom.Value.Date & "'<=Date_Of_Issue and Date_Of_Issue<='" & Me.dtpIssueTo.Value.Date & "'"
        QueryBLOfLading(" " & mFilter)
    End Sub

    Private Sub cmdCancelIssue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelIssue.Click
        Me.grpIssue.Visible = False
    End Sub

    Private Sub txtVND_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtVND.TextChanged

    End Sub
End Class