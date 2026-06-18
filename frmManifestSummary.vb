Public Class frmManifestSummary

    Dim Path As String

    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "SailingScheduleID"
        value = "value"
        strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        strSQL &= " From SailingSchedule,vessel "
        strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "' "
        strSQL &= "Order By Vessel_Code desc"
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
            Dim id, value, strSQL As String
            id = "SailingScheduleID"
            value = "value"

            strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            strSQL &= " From SailingSchedule,vessel "
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "' "
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable

            dt = ReadTable(strSQL)
            Me.cboVessel.DisplayMember = value
            Me.cboVessel.ValueMember = id
            Me.cboVessel.DataSource = dt
            If dt.Rows.Count > 0 Then
                QueryVessel() 'Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
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

    Function QueryBill() As DataTable
        Try
            Dim SQL As String
            SQL = "select billoflading.BL_ID,BL_NO,Vessel,VoyNo,ETD,ContaineroutboundNotify.ServiceContract as SC_NO,BillOfLading.VIP as VIP "
            SQL &= " From (((BillOfLading LEFT JOIN ContaineroutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN SailingSchedule On ContaineroutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID)  "
            SQL &= " Where BillOfLading.Continued=1 And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.Editable=1 Order By BL_NO "
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryMasterBill(ByVal bl_id As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select blh_no from billoflading_house where bl_id= '" & bl_id & "' and continued =1 "
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryBillRL() As DataTable
        Try
            Dim SQL As String
            SQL = "select billoflading.BL_ID,BL_NO,Vessel,VoyNo,ETD,ContaineroutboundNotify.ServiceContract as SC_NO,BillOfLading.VIP as VIP, SHIPPER_1 + SHIPPER_2 + SHIPPER_3 + SHIPPER_4 + SHIPPER_5 AS SHIPPER, CONSIGNEE_1 + CONSIGNEE_2 + CONSIGNEE_3 + CONSIGNEE_4 + CONSIGNEE_5 AS CONSIGNEE ,"
            SQL &= " COMMONDITY , billoflading.PORT_OF_LOADING_CODE, billoflading.PORT_OF_DISCHARGE_CODE From ((((BillOfLading LEFT JOIN ContaineroutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN SailingSchedule On ContaineroutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) left join shipper on shipper.shipper_ID=billoflading.shipper_ID) left join consignee on consignee.consignee_id=billoflading.consignee_id  "
            SQL &= " Where BillOfLading.Continued=1 And ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.Editable=1  Order By BL_NO "
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryContainer(ByVal BLID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Container_Type,Count(Container_Type) as Num "
            SQL &= " From Cargo "
            SQL &= " Where Cargo.BL_ID='" & BLID & "' And Continued=1"
            SQL &= " Group By Container_Type Order By Container_Type"
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryContainerRL(ByVal BLID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Container_Type,Count(Container_Type) as Num,TEMPERATURE_SETTING,vent "
            SQL &= " From Cargo "
            SQL &= " Where Cargo.BL_ID='" & BLID & "' And Continued=1 AND (CONTAINER_TYPE LIKE '%RH%' OR CONTAINER_TYPE LIKE '%RF%') "
            SQL &= " Group By Container_Type,TEMPERATURE_SETTING,vent Order By Container_Type"
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Sub frmManifestSummary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub


    Sub SetExcelValue()
        Dim dt, dtMasterBill As DataTable
        Dim billmaster As String
        dt = QueryBill()
        If dt.Rows.Count = 0 Then
            MsgBox("No data")
            Return
        End If
        Dim app As New Excel.Application
        Try

            app.Visible = True
            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook
            Path = StartupPath & "\ManifestSummaryList.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim Container_Type(7) As String
            Dim CountContainerType(7) As Integer
            Dim CountType As Integer = 0
            Dim CurRow As Integer = 6
            ws.Range("C" & CurRow + 2).Value2 = dt.Rows.Count & "B/L(s)"
            ws.Range("B4").Value2 = dt.Rows(0).Item("Vessel") & " " & dt.Rows(0).Item("VoyNo")
            ws.Range("C3").Value2 = dt.Rows(0).Item("ETD")
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim BLID As String = dt.Rows(i).Item("BL_ID").ToString
                ws.Range("A" & CurRow).Value2 = dt.Rows.Count - i
                ws.Range("B" & CurRow).Value2 = dt.Rows(i).Item("BL_NO")
                dtMasterBill = QueryMasterBill(dt.Rows(i).Item("BL_ID").ToString)
                For k As Integer = 0 To dtMasterBill.Rows.Count - 1
                    billmaster += dtMasterBill.Rows(k).Item("blh_no").ToString + ";"
                Next
                ws.Range("c" & CurRow).Value2 = billmaster
                billmaster = ""
                Dim oTableContainer As New DataTable
                oTableContainer = QueryContainer(BLID)
                Dim Type As String = ""
                Dim Count As Integer = 0
                Dim TrueType As Boolean = False
                For L As Integer = 0 To oTableContainer.Rows.Count - 1
                    For j As Integer = 0 To CountType
                        If Container_Type(j) = oTableContainer.Rows(L).Item("Container_Type").ToString Then
                            TrueType = True
                            CountContainerType(j) += CDbl(oTableContainer.Rows(L).Item("Num"))
                            Exit For
                        End If
                    Next
                    If TrueType = False Then
                        Container_Type(CountType) = oTableContainer.Rows(L).Item("Container_Type").ToString
                        CountContainerType(CountType) = CDbl(oTableContainer.Rows(L).Item("Num"))
                        CountType += 1
                    End If
                    Type &= oTableContainer.Rows(L).Item("Container_Type").ToString & " ,"
                    Count += CDbl(oTableContainer.Rows(L).Item("Num"))
                Next
                If Type.Length = 0 Then
                    ws.Rows(CurRow).Insert(1)
                    Continue For
                End If
                ws.Range("D" & CurRow).Value2 = Type.Remove(Type.Length - 1, 1)

                ws.Range("E" & CurRow).Value2 = Count
                ws.Range("F" & CurRow).Value2 = IIf(dt.Rows(i).Item("VIP"), dt.Rows(i).Item("SC_No").ToString, "")
                ws.Rows(CurRow).Insert(1)
            Next
            Dim Temp As String = ""
            For i As Integer = 0 To CountType - 1
                Temp &= CountContainerType(i) & " X " & Container_Type(i) & ","
            Next
            If Temp.Length > 0 Then
                Temp = Temp.Remove(Temp.Length - 1, 1)
            End If
            ws.Range("B" & CurRow + dt.Rows.Count + 2).Value2 = Temp
            Path = "c:\ManifestSummaryList" & Now().ToString.Replace(":", " ") & ".xls"
            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chương trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub SetExcelValueRL()
        Dim dt As DataTable
        Dim dem As Integer = 0
        Dim cold, vent As String
        dt = QueryBillRL()
        If dt.Rows.Count = 0 Then
            MsgBox("No data")
            Return
        End If
        Dim app As New Excel.Application
        Try

            app.Visible = True
            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook
            Path = StartupPath & "\ManifestSummaryListRL.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim Container_Type(7) As String
            Dim CountContainerType(7) As Integer
            Dim CountType As Integer = 0
            Dim CurRow As Integer = 6

            ws.Range("B4").Value2 = dt.Rows(0).Item("Vessel") & " " & dt.Rows(0).Item("VoyNo")
            ws.Range("C3").Value2 = dt.Rows(0).Item("ETD")
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim BLID As String = dt.Rows(i).Item("BL_ID").ToString

                'ws.Range("c" & CurRow).Value2 = dt.Rows(i).Item("BLh_NO")
                Dim oTableContainer As New DataTable
                oTableContainer = QueryContainerRL(BLID)
                Dim Type As String = ""
                Dim Count As Integer = 0
                Dim TrueType As Boolean = False
                If oTableContainer.Rows.Count <> 0 Then
                    ws.Range("A" & CurRow).Value2 = dt.Rows(i).Item("PORT_OF_LOADING_CODE").ToString
                    ws.Range("D" & CurRow).Value2 = dt.Rows(i).Item("PORT_OF_discharge_CODE").ToString
                    'cold = oTableContainer.Rows(dem).Item("TEMPERATURE_SETTING").ToString
                    'vent = oTableContainer.Rows(dem).Item("vent").ToString
                    dem += 1
                    For L As Integer = 0 To oTableContainer.Rows.Count - 1
                        For j As Integer = 0 To CountType
                            If Container_Type(j) = oTableContainer.Rows(L).Item("Container_Type").ToString Then
                                TrueType = True
                                CountContainerType(j) += CDbl(oTableContainer.Rows(L).Item("Num"))
                                Exit For
                            End If
                        Next
                        If TrueType = False Then
                            Container_Type(CountType) = oTableContainer.Rows(L).Item("Container_Type").ToString
                            CountContainerType(CountType) = CDbl(oTableContainer.Rows(L).Item("Num"))
                            CountType += 1
                        End If
                        Type &= oTableContainer.Rows(L).Item("Container_Type").ToString & " ,"
                        Count += CDbl(oTableContainer.Rows(L).Item("Num"))
                    Next

                    If Type.Length = 0 Then
                        ws.Rows(CurRow).Insert(1)
                        Continue For
                    End If
                    ws.Range("b" & CurRow).Value2 = Type.Remove(Type.Length - 1, 1)

                    ws.Range("c" & CurRow).Value2 = Count

                    ws.Range("F" & CurRow).Value2 = dt.Rows(i).Item("BL_NO").ToString
                    ws.Range("g" & CurRow).Value2 = dt.Rows(i).Item("shipper").ToString
                    ws.Range("h" & CurRow).Value2 = dt.Rows(i).Item("consignee").ToString
                    ws.Range("i" & CurRow).Value2 = dt.Rows(i).Item("commondity").ToString
                    'ws.Range("k" & CurRow).Value2 = cold
                    'ws.Range("l" & CurRow).Value2 = vent
                    ws.Rows(CurRow).Insert(1)
                End If
             
            Next
            Dim Temp As String = ""
            For i As Integer = 0 To CountType - 1
                Temp &= CountContainerType(i) & " X " & Container_Type(i) & ","
            Next
            If Temp.Length > 0 Then
                Temp = Temp.Remove(Temp.Length - 1, 1)
            End If
            ws.Range("C" & CurRow + dem + 2).Value2 = CStr(dem) & "B/L(s)"
            ws.Range("B" & CurRow + dt.Rows.Count + 2).Value2 = Temp
            Path = "c:\ManifestSummaryListRL" & Now().ToString.Replace(":", " ") & ".xls"
            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.chkRL.Checked = False Then
            SetExcelValue()
        Else
            SetExcelValueRL()
        End If

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class