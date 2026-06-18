Public Class frmDailyBookingReport2

    Dim Path As String


    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL = strSQL & " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 and ETD='" & Me.dtpLeavingDate.Value.Date & "' Order By Vessel_Code desc"
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
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "'"
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
                QueryVessel()
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
    Private Sub frmBookingDdailyReport2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        SetExcelValue()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Function QueryData(ByVal Mar As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Distinct sum(SoLuong20GP) as SoLuong20GP,sum(SoLuong40GP) as SoLuong40GP,sum(SoLuong40HC) as SoLuong40HC,sum(SoLuong20RF) as SoLuong20RF,sum(SoLuong40RF) as SoLuong40RF,sum(SoLuong40RH) as SoLuong40RH,sum(SoLuong45HC) as SoLuong45HC ,sum(SoLuong20OT) as SoLuong20OT,sum(SoLuong40OT) as SoLuong40OT,sum(SoLuong20FR) as SoLuong20FR,sum(SoLuong40FR) as SoLuong40FR "
            'SQL &= " ,Market,Tranship,PortOfUnLoading,Destination,ETD,ETA,POL,Operator,Service "
            SQL &= " from (ContainerOutBoundNotify LEFT JOIN Market On ContainerOutBoundNotify.Market_ID=Market.Market_ID)"
            'SQL &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " Where ContainerOutBoundNotify.Continued=1 And ContainerOutBoundNotify.Editable=1 And ContainerOutBoundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And SOC=0 And MarketCode='" & Mar & "'" 'soc=0 tức là hàng COC
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub SetExcelValue()
        Dim app As New Excel.Application
        Try

            app.Visible = True
            Dim SQL As String
            SQL = "Select Distinct MarketCode "
            SQL &= " from (ContainerOutBoundNotify LEFT JOIN Market On ContainerOutBoundNotify.Market_ID=Market.Market_ID) "
            SQL &= " Where(ContainerOutBoundNotify.Continued = 1 And ContainerOutBoundNotify.Editable = 1)"
            SQL &= " And ContainerOutBoundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'" 'And SOC=1"
            Dim dtMarket As New DataTable
            dtMarket = ReadTable(SQL)


            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook
            Path = StartupPath & "\DailyBooking2.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim dt As New DataTable

            Dim Arr(dtMarket.Rows.Count, 12) As Object

            ''
            Dim CurRow As Integer = 15 'dòng bắt đầu đỗ dữ liệu vào
            Dim CountRow As Integer = dtMarket.Rows.Count
            If CountRow > 10 Then
                ws.Rows(18).Insert(CountRow - 10)
            End If

            For i As Integer = 0 To dtMarket.Rows.Count - 1
                Dim market As String
                market = dtMarket.Rows(i).Item("MarketCode")
                dt = QueryData(market)
                Arr(i, 0) = market
                Arr(i, 1) = dt.Rows(0).Item("soluong20GP")
                Arr(i, 2) = dt.Rows(0).Item("soluong40GP")
                Arr(i, 3) = dt.Rows(0).Item("soluong40HC")
                Arr(i, 4) = dt.Rows(0).Item("soluong45HC")
                Arr(i, 5) = dt.Rows(0).Item("soluong40RH")
                Arr(i, 6) = dt.Rows(0).Item("soluong20RF")
                Arr(i, 7) = dt.Rows(0).Item("soluong40RF")
                Arr(i, 8) = dt.Rows(0).Item("soluong20OT")
                Arr(i, 9) = dt.Rows(0).Item("soluong40OT")
                Arr(i, 10) = dt.Rows(0).Item("soluong20FR")
                Arr(i, 11) = dt.Rows(0).Item("soluong40FR")
            Next
            ws.Range("B" & CurRow, "I" & CountRow + CurRow).Value2 = Arr
            SQL = "select Distinct Tranship,PortOfUnLoading as POD,Destination,ETD,ETA,POL,Operator,Service "
            SQL &= " From (ContainerOutboundNotify LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " where ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.Editable=1 "
            SQL &= " And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            Dim TempDt As New DataTable
            TempDt = ReadTable(SQL)
            If TempDt.Rows.Count > 0 Then
                ws.Range("B5").Value2 = TempDt.Rows(0).Item("POL")
                ws.Range("E5").Value2 = Me.cboVessel.Text
                ws.Range("B7").Value2 = TempDt.Rows(0).Item("POD")
                ws.Range("B10").Value2 = TempDt.Rows(0).Item("Tranship")
                ws.Range("C11").Value2 = TempDt.Rows(0).Item("Operator")
                ws.Range("E7").Value2 = TempDt.Rows(0).Item("ETA")
                ws.Range("K7").Value2 = TempDt.Rows(0).Item("ETD")
                'ws.Range("B5").Value2 = TempDt.Rows(0).Item("POL")
            End If


            Path = "c:\DailyBookingReport2" & Now().ToString.Replace(":", " ") & ".xls"
            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
        End Try
    End Sub
End Class