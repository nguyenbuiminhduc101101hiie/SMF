Public Class frmCheckPrice
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

    Private Sub frmCheckPrice_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        QueryVessel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        If Me.dgdData.RowCount = 0 Then
            Return
        End If
        ExportExecel(Me.dgdData, Me)

    End Sub
    Sub CheckPrice(ByRef Dgd As DataGridView)
        Try
            Dim SQL As String
            SQL = "Select distinct BookingNo,ContainerOutboundNotifyID From ContainerOutboundNotify Where SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And Continued=1"
            Dim dtBooking As New DataTable
            dtBooking = ReadTable(SQL)
            If dtBooking.Rows.Count = 0 Then
                MsgBox("Have No Booking Number Belong this Vessel")
                Return
            End If
            For i As Integer = 0 To dtBooking.Rows.Count - 1
                SQL = "Select BookingNo as BookingNoSurcharge,Kind as Container_TypeSurCharge ,Unit as CurrencySurcharge ,Freight as PriceSurcharge,PayTerm as PrepaidCollectSurcharge,FreightSale.ChargeCode as ChargeCodeSurcharge,Charge.Charge_ID "
                SQL &= " From ((FreightSale LEFT JOIN Charge On Charge.Charge_Code=FreightSale.ChargeCode)"
                SQL &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=FreightSale.ContainerOutboundNotifyID)"
                SQL &= " Where FreightSale.ContainerOutboundNotifyID='" & dtBooking.Rows(i).Item("ContainerOutboundNotifyID").ToString & "' And FreightSale.Continued=1 order by Kind,Unit,Freight,PayTerm,FreightSale.ChargeCode"
                Dim dtFreightSale As New DataTable
                dtFreightSale = ReadTable(SQL)

                SQL = " Select BookingNo,Container_type ,Freight_Charge_Master.Currency,Amount as Price,Freight_Charge_Master.Prepaid_Collect as PrepaidCollect,Charge.Charge_Code as ChargeCode,Charge.Charge_ID,BL_NO,BillOfLading.CREATIVEUSER as CreateUser"
                SQL &= " From (((Freight_Charge_Master LEFT JOIN BillOfLading On BillOfLading.BL_ID=Freight_Charge_master.BL_ID)"
                SQL &= " LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
                SQL &= " LEFT JOIN Charge On Charge.Charge_ID=Freight_Charge_master.Charge_ID)"
                SQL &= " Where BillOfLading.ContainerOutboundNotifyID='" & dtBooking.Rows(i).Item("ContainerOutboundNotifyID").ToString & "' And BillOfLading.Continued=1 And Freight_Charge_Master.Continued=1 "
                SQL &= "Order By Container_type ,Freight_Charge_Master.Currency,Amount,Freight_Charge_Master.Prepaid_Collect,Charge.Charge_Code  "
                Dim dtCargoFreight As New DataTable
                dtCargoFreight = ReadTable(SQL)

                For Count As Integer = 0 To dtCargoFreight.Rows.Count - 1 'duyệt hết các dòng của phí container
                    For TempCount As Integer = 0 To dtFreightSale.Rows.Count - 1 'duyệt hết các dòng của phí surcharge
                        If dtCargoFreight.Rows(Count).Item("Charge_ID").ToString = dtFreightSale.Rows(TempCount).Item("Charge_ID").ToString And dtCargoFreight.Rows(Count).Item("Container_type").ToString = dtFreightSale.Rows(TempCount).Item("Container_TypeSurCharge").ToString Then
                            Dim AddRow As Boolean = True
                            For Col As Integer = 0 To dtFreightSale.Columns.Count - 2
                                Try
                                    If UCase(dtCargoFreight.Rows(Count).Item(Col).ToString) <> UCase(dtFreightSale.Rows(TempCount).Item(Col).ToString) Then

                                        If AddRow = True Then
                                            Me.dgdData.Rows.Add(1)
                                        End If
                                        Dim CountRow As Integer = Me.dgdData.RowCount - 1
                                        Me.dgdData.Item("BookingNo", CountRow).Value = dtCargoFreight.Rows(Count).Item("BookingNo")
                                        Me.dgdData.Item("Container_Type", CountRow).Value = dtCargoFreight.Rows(Count).Item("Container_Type")
                                        Me.dgdData.Item("ChargeCode", CountRow).Value = dtCargoFreight.Rows(Count).Item("ChargeCode")
                                        Me.dgdData.Item("Currency", CountRow).Value = dtCargoFreight.Rows(Count).Item("Currency")
                                        Me.dgdData.Item("Price", CountRow).Value = dtCargoFreight.Rows(Count).Item("Price")
                                        Me.dgdData.Item("PrepaidCollect", CountRow).Value = dtCargoFreight.Rows(Count).Item("PrepaidCollect")
                                        Me.dgdData.Item("BL_NO", CountRow).Value = dtCargoFreight.Rows(Count).Item("BL_NO")
                                        Me.dgdData.Item("CreateUser", CountRow).Value = dtCargoFreight.Rows(Count).Item("CreateUser")
                                        Me.dgdData.Rows(CountRow).Cells(dtCargoFreight.Columns(Col).ColumnName).Style.ForeColor = Color.Red

                                        If AddRow = True Then
                                            Me.dgdSurCharge.Rows.Add(1)
                                        End If
                                        Dim CountRowSurcharge As Integer = Me.dgdSurCharge.RowCount - 1
                                        Me.dgdSurCharge.Item("BookingNoSurcharge", CountRowSurcharge).Value = dtFreightSale.Rows(TempCount).Item("BookingNoSurcharge")
                                        Me.dgdSurCharge.Item("Container_TypeSurcharge", CountRowSurcharge).Value = dtFreightSale.Rows(TempCount).Item("Container_TypeSurcharge")
                                        Me.dgdSurCharge.Item("ChargeCodeSurCharge", CountRowSurcharge).Value = dtFreightSale.Rows(TempCount).Item("ChargeCodeSurcharge")
                                        Me.dgdSurCharge.Item("CurrencySurcharge", CountRowSurcharge).Value = dtFreightSale.Rows(TempCount).Item("CurrencySurcharge")
                                        Me.dgdSurCharge.Item("PriceSurcharge", CountRowSurcharge).Value = dtFreightSale.Rows(TempCount).Item("PriceSurcharge")
                                        Me.dgdSurCharge.Item("PrepaidCollectSurcharge", CountRowSurcharge).Value = dtFreightSale.Rows(TempCount).Item("PrepaidCollectSurcharge")
                                        Me.dgdSurCharge.Rows(CountRowSurcharge).Cells(dtFreightSale.Columns(Col).ColumnName).Style.ForeColor = Color.Red
                                        AddRow = False
                                    End If
                                Catch ex As Exception
                                    DisplayMessage(True, Err.Description)
                                End Try
                            Next
                        End If
                    Next
                Next
            Next
            InsertAutoNumberToGrid(Me.dgdSurCharge)
            InsertAutoNumberToGrid(Me.dgdData)
            MsgBox("Complete")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.dgdSurCharge.Rows.Clear()
        Me.dgdData.Rows.Clear()

        CheckPrice(Me.dgdData)
    End Sub

    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick, dgdSurCharge.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub

   

    Private Sub dgdData_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdData.RowStateChanged
        Try
            Dim i As Integer = 0
            i = Me.dgdData.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If i = 0 Then
                Return
            End If
            Dim Index As Integer
            Index = Me.dgdData.SelectedRows(0).Index
            Me.dgdSurCharge.Rows(Index).Selected = True
            Me.dgdSurCharge.CurrentCell = Me.dgdSurCharge.Rows(Index).Cells(0)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

   

    Private Sub dgdSurCharge_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles dgdSurCharge.RowStateChanged
        Try
            Dim i As Integer = 0
            i = Me.dgdSurCharge.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If i = 0 Then
                Return
            End If
            Dim Index As Integer
            Index = Me.dgdSurCharge.SelectedRows(0).Index
            Me.dgdData.Rows(Index).Selected = True
            Me.dgdData.CurrentCell = Me.dgdData.Rows(Index).Cells(0)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class