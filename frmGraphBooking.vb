Public Class frmGraphBooking


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
    Private Sub frmGraphBooking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Sub AddColumns(ByRef dgd As DataGridView, ByVal Name As String, ByVal Text As String)
        Try
            Dim Index As Integer
            For i As Integer = 0 To Me.dgdData.Columns.Count - 1
                If UCase(Strings.Left(Me.dgdData.Columns(i).Name.Trim, 3)) = Strings.Left(Name, 3) Then
                    Index = dgd.Columns(i).DisplayIndex + 1
                End If
                If UCase(Me.dgdData.Columns(i).Name.Trim) = UCase(Name.Trim) Then
                    Return
                End If
            Next
            dgd.Columns.Add(Name, Text)
            If Index <> 0 Then
                dgd.Columns(Name).DisplayIndex = Index
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function AddRow(ByRef dgd As DataGridView, ByVal Count As Integer, ByVal Value As String) As Integer
        Try
            For i As Integer = 0 To dgd.Rows.Count - 1
                If dgd.Item("BookingDate", i).Value.ToString = Value Then
                    Return i
                End If
            Next
            dgd.Rows.Add(Count)
            Return Me.dgdData.RowCount - 1

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub QueryData(Optional ByVal arg As String = "")
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If
            If Me.dgdData.Rows.Count > 0 Then
                Me.dgdData.Rows.Clear()
                Me.dgdData.Columns.Clear()
                AddColumns(Me.dgdData, "BookingDate", "Booking Date")
            End If
            Dim SQl As String
            SQl = "Select distinct Port.MARKETCODESALE as MarketCode,Market.Market_ID "
            SQl &= " From ContainerOutboundNotify , Port ,Market"
            SQl &= " Where Right(ContainerOutboundNotify.PortOfUnLoading,5)=Port.Port_Code And "
            SQl &= " Port.MARKETCODESALE= Market.MarketCode And "
            SQl &= " ContainerOutboundNotify.Continued=1 And Market.Continued=1 " & arg

            Dim dtMarket As New DataTable
            dtMarket = ReadTable(SQl)
            For i As Integer = 0 To dtMarket.Rows.Count - 1
                SQl = "Select BookingDate as BookingDate,sum(Soluong20GP) as [20GP],sum(Soluong40GP) as [40GP]"
                SQl &= ",sum(Soluong40HC) as [40HC],sum(Soluong45HC) as [45HC],sum(SoLuong20RF) as [20RF]"
                SQl &= ",sum(Soluong40RF) as [40RF],sum(Soluong40RH) as [40RH], sum(Soluong20OT) as [20OT],sum(Soluong40OT) as [40OT],sum(Soluong20FR) as [20FR],sum(Soluong40FR) as [40FR] "
                SQl &= " From ContainerOutboundNotify,Market,Port "
                SQl &= " Where Port.MARKETCODESALE= Market.MarketCode And Right(ContainerOutboundNotify.PortOfUnLoading,5)=Port.Port_Code And Market.Market_ID='" & dtMarket.Rows(i).Item("Market_ID").ToString & "' And ContainerOutboundNotify.Continued=1 " & arg
                SQl &= " Group by BookingDate "
                Dim dtBooking As New DataTable
                dtBooking = ReadTable(SQl)
                Dim CountRow As Integer = 0
                For j As Integer = 0 To dtBooking.Rows.Count - 1
                    ' Me.dgdData.Rows.Add(1)
                    CountRow = AddRow(Me.dgdData, 1, dtBooking.Rows(j).Item("BookingDate").ToString)
                    Me.dgdData.Item("BookingDate", CountRow).Value = dtBooking.Rows(j).Item("BookingDate")
                    AddColumns(Me.dgdData, dtMarket.Rows(i).Item("MarketCode").ToString, dtMarket.Rows(i).Item("MarketCode").ToString)
                    For col As Integer = 1 To dtBooking.Columns.Count - 1
                        If dtBooking.Rows(j).Item(col).ToString() <> "0" Then
                            Dim ColName As String = dtMarket.Rows(i).Item("MarketCode") & "_" & dtBooking.Columns(col).ColumnName
                            AddColumns(Me.dgdData, ColName, ColName)
                            Me.dgdData.Item(ColName, CountRow).Value = dtBooking.Rows(j).Item(col).ToString
                        End If
                    Next
                Next
            Next


        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryData(" " & "And SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'")
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgdData, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class