Public Class frmAdvanceSearChBooking


    Function QueryData() As DataTable
        Dim SQL As String
        If Me.chkJoinBillOfLading.Checked = True Then
            SQL = "Select distinct BookingNo,Tranship,SELL_Way,ContainerOutboundNotify.ServiceContract,SaleCode,SaleName"
            SQL &= ",Market,SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong45HC,SoLuong20RF,SoLuong40RF,SoLuong40RH,SpencialEquipment"
            SQL &= ",Commondity,Cold,Ventilation,EmptyContainerPlace,FullReturnContainerPlace,PackingWay,CustomsLiquiDate"
            SQL &= ",PortOfLoading,PortOfUnLoading,Destination,MaxWMainPort,MaxWLocal,BookingPerson,BookingDate,ContainerOutboundNotify.WeekOfYear,ServiceFeeder,LocalCargo"
            SQL &= ",EmptyMoving , TransiteCargo "
            SQL &= ", [SOC /COC]=case SOC When 1 then 'SOC' else 'COC' End,SlotExchange,FOBCargo,PaymentTerm,FirstSendDate,SecondSendDate,ThirdSendDate"
            SQL &= ",SupplyDate,SupplyOrderPlace,limitedBooking,BL_NO as [B/L],Charge_code,UnitPriceSale , Amount as [UnitPrice (Manifest)] , freightsale.Note "
            SQL &= " From((((ContainerOutboundNotify LEFT JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN Market On ContainerOutboundNotify.Market_ID=Market.Market_ID)"
            SQL &= " LEFT JOIN Freight_Charge_Master On Freight_Charge_Master.BL_ID=BillOfLading.BL_ID)"
            SQL &= " LEFT JOIN Charge On Freight_Charge_Master.Charge_ID=Charge.Charge_ID) inner join freightsale On ContainerOutboundNotify.ContainerOutboundNotifyid=freightsale.ContainerOutboundNotifyid "
            SQL &= " Where ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.Editable=1"
        Else
            SQL = "Select  distinct BookingNo,Tranship,SELL_Way,ContainerOutboundNotify.ServiceContract,SaleCode,SaleName"
            SQL &= ",Marketcode,SoLuong20GP,SoLuong40GP,SoLuong40HC,SoLuong45HC,SoLuong20RF,SoLuong40RF,SoLuong40RH,SpencialEquipment"
            SQL &= ",Commondity,Cold,Ventilation,EmptyContainerPlace,FullReturnContainerPlace,PackingWay,CustomsLiquiDate"
            SQL &= ",PortOfLoading,PortOfUnLoading,Destination,MaxWMainPort,MaxWLocal,BookingPerson,BookingDate,ContainerOutboundNotify.WeekOfYear,ServiceFeeder,LocalCargo"
            SQL &= ",EmptyMoving , TransiteCargo "
            SQL &= ", [SOC /COC]=case SOC When 1 then 'SOC' else 'COC' End,SlotExchange,FOBCargo,PaymentTerm,FirstSendDate,SecondSendDate,ThirdSendDate"
            SQL &= ",SupplyDate,SupplyOrderPlace,limitedBooking,Chargecode,Freight , Freightsale ,Note "
            SQL &= " From (ContainerOutboundNotify "
            SQL &= " LEFT JOIN freightsale On ContainerOutboundNotify.ContainerOutboundNotifyid=freightsale.ContainerOutboundNotifyid) left join market  on  ContainerOutboundNotify.market_id=market.market_ID "
            SQL &= " Where ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.Editable=1"
        End If

        Dim dt As New DataTable
        dt = ReadTable(SQL)
        
        Return dt
    End Function

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

    Private Sub frmAdvanceSearChBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        SetDefaultGrid(Me.DataGridView1, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)


    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Me.DataGridView1.DataSource = QueryData()
        InsertAutoNumberToGrid(Me.DataGridView1)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.DataGridView1.RowCount - 1
            For s = 0 To Me.DataGridView1.ColumnCount - 1
                If Not Me.DataGridView1.Item(s, t).Value Is Nothing Then
                    If Me.DataGridView1.Item(s, t).Value.ToString = "0" Then
                        Me.DataGridView1.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                End If

            Next
        Next
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportExcel.Click
        Try
            If Me.DataGridView1.RowCount > 0 Then
                'SetMenu(False)
                ExportExecel(Me.DataGridView1, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class