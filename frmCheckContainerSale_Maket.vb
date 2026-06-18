Public Class frmCheckContainerSale_Maket


    Dim oTableData As New DataTable
    Dim mVessel, mVoyNo As String

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


    Sub QueryData()
        Try
            Dim SQL As String
            SQL = "select Sum(Soluong20GP) as [20GP],Sum(Soluong40GP) as [40GP],"
            SQL &= " Sum(Soluong40HC) as [40HC],Sum(Soluong45HC) as [45HC],"
            SQL &= " Sum(Soluong20RF) as [20RF],Sum(Soluong40RF) as [40RF],"
            SQL &= " Sum(Soluong40RH) as [40RH] "
            SQL &= " From ContainerOutboundNotify "
            SQL &= " Where ContainerOutboundNotify.Continued=1 And ContainerOutBoundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            Dim dtBooking As New DataTable
            dtBooking = ReadTable(SQL) 'query số container book

            oTableData = dtBooking.Copy

            'Query Số container đã cấp lệnh
            SQL = "select Sum([Order].Soluong20GP) as [20GP],Sum([Order].Soluong40GP) as [40GP],"
            SQL &= " Sum([Order].Soluong40HC) as [40HC],Sum([Order].Soluong45HC) as [45HC],"
            SQL &= " Sum([Order].Soluong20RF) as [20RF],Sum([Order].Soluong40RF) as [40RF],"
            SQL &= " Sum([Order].Soluong40RH) as [40RH] "
            SQL &= " From (ContainerOutboundNotify INNER JOIN [Order] On ContainerOutboundNotify.BookingNo=[Order].BookingNo )"
            SQL &= " Where ContainerOutboundNotify.Continued=1 And ContainerOutBoundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' "
            SQL &= " And [Order].Continued=1 "
            Dim dtOrder As New DataTable
            dtOrder = ReadTable(SQL)
            oTableData.ImportRow(dtOrder.Rows(0))

            'Query số container Đã lấy 

            SQL = " Select Count(Container_No) as NumOfContainer,CTN_SIZE_TYPE as Container_Type "
            SQL &= " From ((LoadingPlanForVessel LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=LoadingPlanForVessel.ContainerOutboundNotifyID )"
            SQL &= " LEFT JOIN Container On LoadingPlanForVessel.CTN_ID=Container.CTN_ID) "
            SQL &= " Where LoadingPlanForVessel.Continued=1 And ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' "
            SQL &= " Group By CTN_SIZE_TYPE "
            Dim dtloading As New DataTable
            dtloading = ReadTable(SQL)
            Dim row As DataRow
            row = oTableData.NewRow()
            For i As Integer = 0 To dtloading.Rows.Count - 1

                Dim Type As String
                Type = dtloading.Rows(i).Item("Container_Type").ToString
                row(Type) = dtloading.Rows(i).Item("NumOfContainer")
            Next
            oTableData.Rows.Add(row)
            'Me.dgdBooking.DataSource = oTableData
            row = oTableData.NewRow()

            row("20GP") = oTableData.Rows(oTableData.Rows.Count - 1).Item("20GP")
            If oTableData.Rows(oTableData.Rows.Count - 1).Item("40GP").ToString <> "" Then
                row("40GP") = oTableData.Rows(oTableData.Rows.Count - 1).Item("40GP") * 2
            Else
                row("40GP") = 0
            End If

            If oTableData.Rows(oTableData.Rows.Count - 1).Item("40HC").ToString <> "" Then
                row("40HC") = oTableData.Rows(oTableData.Rows.Count - 1).Item("40HC") * 2
            Else
                row("40HC") = 0
            End If
            If oTableData.Rows(oTableData.Rows.Count - 1).Item("45HC").ToString <> "" Then
                row("45HC") = oTableData.Rows(oTableData.Rows.Count - 1).Item("45HC") * 2
            Else
                row("45HC") = 0
            End If
            row("20RF") = oTableData.Rows(oTableData.Rows.Count - 1).Item("20RF")
            If oTableData.Rows(oTableData.Rows.Count - 1).Item("40RF").ToString <> "" Then
                row("40RF") = oTableData.Rows(oTableData.Rows.Count - 1).Item("40RF") * 2
            Else
                row("40RF") = 0
            End If

            If oTableData.Rows(oTableData.Rows.Count - 1).Item("40RH").ToString <> "" Then
                row("40RH") = oTableData.Rows(oTableData.Rows.Count - 1).Item("40RH") * 2
            Else
                row("40RH") = 0
            End If


            oTableData.Rows.Add(row)
            Me.dgdBooking.DataSource = oTableData

            Dim Header() As String = {"Number Of Container Booking ", "Number Of Container Supply Order", "Number Of Container Supplied ", "Total Teu Supplied "}
            For i As Integer = 0 To Me.dgdBooking.RowCount - 1
                Me.dgdBooking.Item("Vessel", i).Value = mVessel
                Me.dgdBooking.Item("VoyNo", i).Value = mVoyNo
                Me.dgdBooking.Item("Note", i).Value = Header(i)
            Next
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdBooking.RowCount - 1
                For s = 0 To Me.dgdBooking.ColumnCount - 1
                    If Me.dgdBooking.Item(s, t).Value.ToString = "0" Then
                        Me.dgdBooking.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmLoadingPlanInvetory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim Temp() As String
        mVoyNo = ""
        mVessel = ""
        Temp = Me.cboVessel.Text.Split("-")
        If Temp.Length > 0 Then
            mVoyNo = Temp(Temp.Length - 1)
            For i As Integer = 0 To Temp.Length - 2
                mVessel &= Temp(i)
            Next
        End If

        QueryData()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.dgdBooking.Rows.Count > 0 Then
                ExportExecel(Me.dgdBooking, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class