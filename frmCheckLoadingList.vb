Public Class frmCheckLoadingList
    Dim Path As String

    Sub QueryVessel()
        On Error GoTo Err_Renamed
        Dim id, value, strSQL As String
        id = "shipper"
        value = "shipper"
        strSQL = "Select distinct shipper "
        strSQL &= " From billoflading_house WHERE CONTINUED=1 "
        strSQL &= " "
        strSQL &= "Order By Shipper"
        Dim dt As New DataTable
        dt = ReadTable(strSQL)
        Me.cboshipper.DisplayMember = value
        Me.cboshipper.ValueMember = id
        Me.cboshipper.DataSource = dt
        'id = "SailingScheduleID"
        'value = "value"
        'strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
        'strSQL &= " From SailingSchedule,vessel "
        'strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "' "
        'strSQL &= "Order By Vessel_Code desc"
        'Dim dt As New DataTable
        'dt = ReadTable(strSQL)
        'Me.cboVessel.DisplayMember = value
        'Me.cboVessel.ValueMember = id
        'Me.cboVessel.DataSource = dt
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Dim strSQL As String
            'strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            'strSQL &= " From SailingSchedule,vessel "
            'strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "' "
            'strSQL &= "Order By Vessel_Code desc"
            'Dim dt As New DataTable
            'dt = ReadTable(strSQL)
            'If dt.Rows.Count > 0 Then
            '    QueryVessel() 'Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            'Else
            '    MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
            '    Return
            'End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error GoTo Err_named
        'Dim Ves_ID As String
        'If Me.cboVessel.Text = "" Then
        '    Return
        'End If
        'Ves_ID = Me.cboVessel.SelectedValue.ToString
        ''MsgBox(Me.dgdDetailBillOFLading_House.Item("Cargo_id", 0).Value.ToString)
        '' QueryBILLOFLADING_HOUSE(" And BillOfLading_House.BL_ID='" & Ves_ID & "'", 14)
        'If Ves_ID <> "" Then
        '    Dim strQuery As String
        '    '-------------
        '    Dim Con As New SqlClient.SqlConnection(strconnDG)
        '    Dim dset As New DataSet
        '    Dim table As New DataTable
        '    '----------------
        '    strQuery = "Select ETD "
        '    strQuery &= "from SailingSchedule "
        '    strQuery &= "Where SailingScheduleID='" & Ves_ID & "' And SailingSchedule.Continued=1 "

        '    Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        '    Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '    '-----------------
        '    'If Not IsNothing(oTable) Then
        '    '    oTable.Clear()
        '    'End If
        '    Adapter.Fill(dset, "Vessel")
        '    table = dset.Tables(0)
        '    If table.Rows.Count > 0 Then
        '        Me.dtpLeavingDate.Text = table.Rows(0).Item("ETD").ToString
        '    End If
        '    '  query stranship
        'End If
        Exit Sub
Err_named:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Function QueryBill() As DataTable
        Try
            Dim SQL As String
            SQL = "select BLh_ID,BLh_NO,ContainerOutboundNotify.ServiceContract,TRANSFER_PORT1 as VIA1,TRANSFER_PORT2 as VIA2,TRANSFER_PORT3 as VIA3,"
            SQL &= " PORT_OF_DISCHARGE_CODE as PODCode,PLACE_OF_DESTINATION_NAME as DESTName,PLACE_OF_DESTINATION_CODE as DestCode,ToTalContainer as DESCRIPTION  "
            SQL &= " From BillOfLading_house LEFT JOIN ContaineroutboundNotify On BillOfLading_house.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID "
            SQL &= " Where BillOfLading_house.Continued=1 And date_of_issue between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpTo.Value.Date & "' and shipper like '" & Me.cboshipper.Text.Trim & "%' And ContainerOutboundNotify.Continued=1 Order By BLh_NO "
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function QueryContainer(ByVal BLhID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "Select Container_No + '/ '+ convert(nvarchar(100),Amount) + ' /' + convert(nvarchar(100),gross) + '/ ' + convert(nvarchar(100),CTN_CARGO_MEASUREMENT) as Container_No,TEMPERATURE_SETTING,Vent "
            SQL &= " From (Cargo_house INNER JOIN Container On Cargo_house.CTN_ID=Container.CTN_ID)"
            SQL &= " Where Cargo_house.BLh_ID='" & BLhID & "' And Cargo_house.Continued=1 "
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function CountMaxContainer()
        Try
            Dim SQL As String
            SQL = "Select Count(Container_No) as MaxContainer"
            SQL &= " From (((Cargo_house INNER JOIN Container On Cargo_house.CTN_ID=Container.CTN_ID)"
            SQL &= " INNER JOIN BillOfLading_house On Cargo_house.BLh_ID=BillOfLading_house.BLh_ID)"
            SQL &= " LEFT JOIN ContaineroutboundNotify On BillOfLading_house.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= " Where BillOfLading_house.Continued=1 And date_of_issue between '" & Me.dtpFrom.Value.Date & "' and '" & Me.dtpTo.Value.Date & "' and shipper like '" & Me.cboshipper.Text.Trim & "%' And ContainerOutboundNotify.Continued=1 And ContainerOutboundNotify.Editable=1  "
            SQL &= " And Cargo_house.Continued=1 "
            SQL &= " Group By Cargo_house.BLh_ID "
            SQL &= " order By MaxContainer DESC "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return 0
            End If
            Return dt.Rows(0).Item("MaxContainer")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub frmCheckLoadingList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        Me.BackColor = gMaunen
    End Sub

    Sub SetExcelValue()
        Dim dt As DataTable
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
            Path = StartupPath & "\CheckLoadingList.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim CurRow As Integer = 2
            Dim MaxContainer As Integer = CountMaxContainer()
            For i As Integer = 0 To dt.Rows.Count - 1
                Dim BLhID As String = dt.Rows(i).Item("BLh_ID").ToString

                ws.Range("A" & CurRow).Value2 = dt.Rows(i).Item("BLh_NO").ToString
                ws.Range("B" & CurRow).Value2 = dt.Rows(i).Item("ServiceContract").ToString
                ws.Range("C" & CurRow).Value2 = dt.Rows(i).Item("VIA1").ToString
                ws.Range("D" & CurRow).Value2 = dt.Rows(i).Item("VIA2").ToString
                ws.Range("E" & CurRow).Value2 = dt.Rows(i).Item("VIA3").ToString
                ws.Range("F" & CurRow).Value2 = dt.Rows(i).Item("PODCode").ToString
                ws.Range("G" & CurRow).Value2 = dt.Rows(i).Item("DestName").ToString
                ws.Range("H" & CurRow).Value2 = dt.Rows(i).Item("DestCode").ToString
                ' H nằm trong vị trí thứ 7 của mảng Alpha(A,B.....)
                Dim Pos As Integer = 8
                Dim oTableContainer As DataTable
                oTableContainer = QueryContainer(BLhID)

                For L As Integer = 0 To oTableContainer.Rows.Count - 1
                    ws.Range(Alpha(Pos + L + 1) & 1).Value2 = L + 2 'in ra tiêu đề

                    'in dữ liệu
                    ws.Range(Alpha(Pos + L) & CurRow).Value2 = oTableContainer.Rows(L).Item("Container_No").ToString


                    If oTableContainer.Rows(L).Item("TEMPERATURE_SETTING").ToString.Trim <> "" Then 'hiện sau Description
                        ws.Range(Alpha(Pos + MaxContainer + 3) & 1).Value2 = "Temp"
                        ws.Range(Alpha(Pos + MaxContainer + 3) & CurRow).Value2 = oTableContainer.Rows(L).Item("TEMPERATURE_SETTING").ToString.Trim
                    End If

                    If oTableContainer.Rows(L).Item("Vent").ToString.Trim <> "" Then 'hiện sau TEMPERATURE_SETTING
                        ws.Range(Alpha(Pos + MaxContainer + 4) & 1).Value2 = "Vent"
                        ws.Range(Alpha(Pos + MaxContainer + 4) & CurRow).Value2 = oTableContainer.Rows(L).Item("Vent").ToString.Trim
                    End If
                Next
                ws.Range(Alpha(Pos + MaxContainer + 2) & 1).Value2 = "DESCRIPTTION CONTNER" 'tiêu đề
                'dữ liệu
                ws.Range(Alpha(Pos + MaxContainer + 2) & CurRow).Value2 = dt.Rows(i).Item("DESCRIPTION").ToString

                
                CurRow += 1
            Next
            Path = "c:\" & Me.cboshipper.Text & " " & Me.dtpFrom.Value.Date & "   " & Me.dtpTo.Value.Date & "  " & Now().ToString.Replace(":", " ") & ".xls"
            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chương trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        SetExcelValue()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cboshipper_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboshipper.Leave
        Dim tach() As String
        Dim tach1() As String
        If Me.cboshipper.Text = "" Then
            Return
        End If
        tach = Me.cboshipper.Text.Split(Chr(13))
        tach1 = tach(0).Split(" ")
        If tach1.Length >= 2 Then
            Me.cboshipper.Text = tach1(0).Trim + " " + tach1(1)
        ElseIf tach1.Length = 1 Then
            Me.cboshipper.Text = tach1(0).Trim
        End If



    End Sub

    Private Sub cboshipper_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboshipper.SelectedIndexChanged
       
    End Sub
End Class