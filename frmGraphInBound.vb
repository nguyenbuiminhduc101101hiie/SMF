Public Class frmGraphInBound


    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "VesselCode"
        value = "value"
        'strSQL = "Select PortId,'SS-' + rtrim(Convert(nchar,Code)) + '    ' + rtrim(Convert(nChar,Name)) as NameCode From Port where Continued=1 Order By Code desc"
        strSQL = "Select Distinct VesselCode,Vessel + '-' + VoyAge as value "
        strSQL = strSQL & " From BillOfLadingIB where  Continued=1 Order By value desc"
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
            'If Me.cboVessel.Text = "" Then
            '    Return
            'End If
            'Dim Temp() As String
            'Temp = Me.cboVessel.Text.Split("-")

            strSQL = "Select Top 1 VesselCode,Vessel + '-' + VoyAge as value "
            strSQL &= " From BillOfLadingIB "
            strSQL &= " where Convert(DateTime,ETA)='" & Me.dtpLeavingDate.Value.Date & "' "
            'strSQL &= " Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            Else
                MsgBox("there is No Vessel For The ETA :" & Me.dtpLeavingDate.Value.Date)
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
        Dim Temp() As String
        Temp = Me.cboVessel.Text.Split("-")

        Ves_ID = Me.cboVessel.SelectedValue.ToString
        'MsgBox(Me.dgdDetailBillOFLading_House.Item("CargoIB_id", 0).Value.ToString)
        ' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BLIB_ID='" & Ves_ID & "'", 14)
        If Ves_ID <> "" Then
            Dim strQuery As String
            '-------------
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            Dim dset As New DataSet
            Dim table As New DataTable
            '----------------
            strQuery = "Select Top 1 ETA "
            strQuery &= "from BillOfLadingIB "
            strQuery &= "Where Vessel='" & Temp(0) & "' And VoyAge='" & Temp(1) & "' "

            Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            '-----------------
            'If Not IsNothing(oTable) Then
            '    oTable.Clear()
            'End If
            Adapter.Fill(dset, "Vessel")
            table = dset.Tables(0)
            If table.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = table.Rows(0).Item("ETA").ToString
            End If
            '  query stranship
        End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmGraphInBound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.cboYear.Items.Count > 0 Then
            Me.cboYear.Items.Clear()
        End If
        For i As Integer = Now().Year - 5 To Now.Year + 5
            Me.cboYear.Items.Add(i)
        Next
        QueryVessel()
    End Sub
    Sub AddColumns(ByRef dgd As DataGridView, ByVal Name As String, ByVal Text As String)
        Try
            Dim Index As Integer
            For i As Integer = 0 To Me.dgdData.Columns.Count - 1
                If UCase(Strings.Right(Me.dgdData.Columns(i).Name.Trim, 4)) = Strings.Right(Name, 4) Then
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
    Function GetMarketCode(ByVal PortCode As String) As String
        Try
            Dim SQL As String = "Select MARKETCODESALE Code From Port Where Port_Code='" & PortCode & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return ""
            End If
            Return dt.Rows(0).Item("Code").ToString
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
                AddColumns(Me.dgdData, "BLIB_ID", "BLIB_ID")
                Me.dgdData.Columns("BLIB_ID").Visible = False
            End If
            Dim SQL As String
            SQL = " Select BLIB_NO,BLIB_ID,POL as POL"
            SQL &= " From BillOfLadingIB "
            SQL &= " Where BillOfLadingIB.Continued=1 " & arg
            Dim dtBill As New DataTable
            dtBill = ReadTable(SQL)
            For i As Integer = 0 To dtBill.Rows.Count - 1 'duyệt hết tất cả các bill
                SQL = " select Count(*) As Quantity,Items as Charge_Code,CargoIB.Container_Type,Sum(FREIGHT_CHARGE_IB.UNITPRICE * Quantity) as Amount " ', FREIGHT_CHARGE_IB.UnitPriceSale "
                SQL &= " From (CargoIB LEFT JOIN FREIGHT_CHARGE_IB On CargoIB.BLIB_ID=FREIGHT_CHARGE_IB.BLIB_ID)"
                SQL &= " Where CargoIB.BLIB_ID='" & dtBill.Rows(i).Item("BLIB_ID").ToString() & "' And CargoIB.Continued=1 "
                SQL &= " Group By Items,CargoIB.Container_Type "
                SQL &= " Order By CargoIB.Container_type"
                Dim dtCargoIB As New DataTable
                dtCargoIB = ReadTable(SQL)
                If dtCargoIB.Rows.Count = 0 Then
                    Continue For
                End If
                Dim ContainerType As String = ""
                Dim CountRow As Integer = 0


                ContainerType = dtCargoIB.Rows(0).Item("Container_Type").ToString
                Me.dgdData.Rows.Add(1)
                CountRow = Me.dgdData.RowCount - 1

                AddColumns(Me.dgdData, "BLIB_NO", "B/L No.")
                Me.dgdData.Item("BLIB_NO", CountRow).Value = dtBill.Rows(i).Item("BLIB_NO").ToString
                'If dtBill.Rows(i).Item("BLIB_NO").ToString = "HONYC4R21112007" Then
                '    MsgBox("")
                'End If
                For j As Integer = 0 To dtCargoIB.Rows.Count - 1
                    While j < dtCargoIB.Rows.Count
                        If UCase(ContainerType.Trim) = UCase(dtCargoIB.Rows(j).Item("Container_Type").ToString.Trim) Then
                            Dim TypeCol As String = "QuanTity" & ContainerType
                            AddColumns(Me.dgdData, TypeCol, ContainerType)
                            Me.dgdData.Item(TypeCol, CountRow).Value = dtCargoIB.Rows(j).Item("Quantity")
                            Dim DisplayIndex As Integer = Me.dgdData.Columns(TypeCol).DisplayIndex
                            If IsDBNull(dtCargoIB.Rows(j).Item("Charge_Code")) Then
                                j += 1
                                Continue While
                            End If
                            If UCase(dtCargoIB.Rows(j).Item("Charge_Code").ToString.Trim) = "OCB" Then
                                Dim FreightTariff As String = "OCBTariff" & ContainerType
                                AddColumns(Me.dgdData, FreightTariff, "OCB Tariff")
                                Me.dgdData.Item(FreightTariff, CountRow).Value = dtCargoIB.Rows(j).Item("Amount")
                                Me.dgdData.Columns(FreightTariff).DisplayIndex = DisplayIndex + 1

                                'Dim FreightSale As String = "OCBSale" & ContainerType
                                'AddColumns(Me.dgdData, FreightSale, "OCB Sale")
                                'Me.dgdData.Item(FreightSale, CountRow).Value = dtCargoIB.Rows(j).Item("UnitPriceSale")
                                'Me.dgdData.Columns(FreightSale).DisplayIndex = Me.dgdData.Columns(FreightTariff).DisplayIndex + 1
                            Else
                                Dim OtherFreight As String = dtCargoIB.Rows(j).Item("Charge_Code").ToString.Trim & "_" & ContainerType
                                AddColumns(Me.dgdData, OtherFreight, OtherFreight) 'dtCargoIB.Rows(j).Item("Charge_Code"))
                                Me.dgdData.Item(OtherFreight, CountRow).Value = dtCargoIB.Rows(j).Item("Amount")
                                'If Me.dgdData.Columns(Me.dgdData.Columns.Count - 1).DisplayIndex >= DisplayIndex + 3 Then
                                '    Me.dgdData.Columns(OtherFreight).DisplayIndex = DisplayIndex + 3
                                'Else
                                '    Me.dgdData.Columns(OtherFreight).DisplayIndex = Me.dgdData.Columns(Me.dgdData.Columns.Count - 1).DisplayIndex
                                'End If

                            End If
                        End If
                        j += 1
                    End While
                Next 'kết thúc lập CargoIB
                AddColumns(Me.dgdData, "Market", " Dest Market")
                AddColumns(Me.dgdData, "Vessel", "Vessel")
                Me.dgdData.Item("Market", CountRow).Value = GetMarketCode(dtBill.Rows(i).Item("POL").ToString)
                Dim temp() As String
                temp = Me.cboVessel.Text.Split("-")
                Me.dgdData.Item("Vessel", CountRow).Value = temp(0)
                Me.dgdData.Columns("Market").DisplayIndex = Me.dgdData.Columns.Count - 2
                Me.dgdData.Columns("Vessel").DisplayIndex = Me.dgdData.Columns("Market").DisplayIndex + 1

            Next

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.cboVessel.Text = "" Then
            Return

        End If
        Dim Temp() As String
        Temp = Me.cboVessel.Text.Split("-")

        QueryData(" And Vessel='" & Temp(0) & "' And VoyAge='" & Temp(1) & "'")

    End Sub

    Private Sub cmdOkMonth_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOkMonth.Click
        QueryData(" And Month(convert(DateTime,ETA))=" & Me.cboMonth.Text & " And Year(convert(DateTime,ETA))=" & Me.cboYear.Text)
    End Sub

    Private Sub cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgdData, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdGraph_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGraph.Click
        frmChartingInbound.Show()
    End Sub
End Class