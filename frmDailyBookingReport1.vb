Public Class frmDailyBookingReport1
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


    Private Sub frmDailyBookingReport1vb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub
    Function QueryDryCont(ByVal Dest As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select PortOfUnLoading as POD,Tranship ,Destination as Dest,"
            SQL &= "[20GP] =sum(soluong20GP),[40GP] =sum(soluong40GP),[40HC] =sum(soluong40HC)"
            SQL &= ",[45HC] =sum(soluong45HC),[20OT] =sum(soluong20OT),[40OT] =sum(soluong40OT),[20FR] =sum(soluong20FR),[40FR] =sum(soluong40FR)"
            SQL &= "   from ContainerOutboundNotify"
            SQL &= " where Destination='" & Dest & "' And Continued=1  And SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            SQL &= " group By PortOfUnLoading,Tranship,Destination "
            SQL &= " order By PortOfUnLoading"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return Nothing
        End Try
    End Function

    Function QueryColdCont(ByVal Dest As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select PortOfUnLoading as POD,Tranship,Destination as Dest,Cold"
            SQL &= " ,[20RF] =sum(soluong20RF),[40RH] =sum(soluong40RH),[40RF] =sum(soluong40RF) "
            SQL &= " from ContainerOutboundNotify"
            SQL &= " where  Destination='" & Dest & "' And Continued=1 And  (soluong20RF>0 Or soluong40RH>0)  And SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            SQL &= " group By PortOfUnLoading,Tranship,Destination ,Cold"
            SQL &= " order By PortOfUnLoading"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return Nothing
        End Try
    End Function
    Sub SetExcelValue()
        Dim app As New Excel.Application
        Try

            app.Visible = True
            Dim SQL As String
            SQL = "Select Distinct Destination,PortOfUnLoading From ContainerOutboundNotify inner join SailingSchedule on ContainerOutboundNotify.SailingScheduleID= SailingSchedule.SailingScheduleID Where ContainerOutboundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' And ContainerOutboundNotify.Continued=1  And SailingSchedule.Continued=1 Order By PortOfUnLoading"
            Dim dtDest As New DataTable
            dtDest = ReadTable(SQL)


            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook
            Path = StartupPath & "\DailyBooking1.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim CurRow As Integer = 7
            ws.Range("B2").Value2 = "DAILY BOOKING OF MV. " & Me.cboVessel.Text & ", ETD: " & Me.dtpLeavingDate.Value.Date & ""
            Dim RepeatDest As Boolean = False
            For i As Integer = 0 To dtDest.Rows.Count - 1
                For j As Integer = 0 To i - 1
                    If dtDest.Rows(j).Item(0).ToString = dtDest.Rows(i).Item(0).ToString Then
                        RepeatDest = True
                        Exit For
                    End If
                Next
                If RepeatDest = True Then
                    RepeatDest = False
                    Continue For
                End If
                Dim dest As String = dtDest.Rows(i).Item(0).ToString
                Dim dtDryContainer As New DataTable
                Dim dtColdContainer As New DataTable
                'If dest Like "*USHOU" Then
                '    DisplayMessage(True, "")
                'End If

                dtDryContainer = QueryDryCont(dest)
                dtColdContainer = QueryColdCont(dest)
                For CountDryCont As Integer = 0 To dtDryContainer.Rows.Count - 1 ''thêm container khô trứơc
                    ws.Rows(CurRow).Insert(1)
                    ws.Range("P" & CurRow + 1).Copy(ws.Range("P" & CurRow)) 'thêm công thức vào têu
                    ws.Range("Q" & CurRow + 1).Copy(ws.Range("Q" & CurRow)) 'thêm công thức vào weight
                    'CurRow += 1
                    ws.Range("B" & CurRow).Value2 = Strings.Right(dtDryContainer.Rows(CountDryCont).Item("Tranship").ToString, 5)
                    ws.Range("C" & CurRow).Value2 = Strings.Right(dtDryContainer.Rows(CountDryCont).Item("POD").ToString, 5)
                    ws.Range("D" & CurRow).Value2 = Strings.Right(dtDryContainer.Rows(CountDryCont).Item("Dest").ToString, 5)

                    ws.Range("E" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("20GP") > 0, dtDryContainer.Rows(CountDryCont).Item("20GP").ToString, "")
                    ws.Range("F" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("40GP") > 0, dtDryContainer.Rows(CountDryCont).Item("40GP").ToString, "")
                    ws.Range("G" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("40HC") > 0, dtDryContainer.Rows(CountDryCont).Item("40HC").ToString, "")
                    ws.Range("L" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("20OT") > 0, dtDryContainer.Rows(CountDryCont).Item("20OT").ToString, "")
                    ws.Range("M" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("40OT") > 0, dtDryContainer.Rows(CountDryCont).Item("40OT").ToString, "")
                    ws.Range("N" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("20FR") > 0, dtDryContainer.Rows(CountDryCont).Item("20FR").ToString, "")
                    ws.Range("O" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("40FR") > 0, dtDryContainer.Rows(CountDryCont).Item("40FR").ToString, "")
                    'ws.Range("I" & CurRow).Value2 = dtDryContainer.Rows(CountDryCont).Item("40RH").ToString
                    ws.Range("H" & CurRow).Value2 = IIf(dtDryContainer.Rows(CountDryCont).Item("45HC") > 0, dtDryContainer.Rows(CountDryCont).Item("45HC").ToString, "")
                    'ws.Range("K" & CurRow).Value2 = dtDryContainer.Rows(CountDryCont).Item("40RF").ToString
                    'ws.Range("L" & CurRow).Value2 = dtDryContainer.Rows(CountDryCont).Item("POD").ToString
                    'ws.Range("M" & CurRow).Value2 = dtDryContainer.Rows(CountDryCont).Item("Dest").ToString
                    'ws.Range("N" & CurRow).Value2 = dtDryContainer.Rows(CountDryCont).Item("Tranship").ToString
                    'CurRow += 1
                Next

                For CountColdCont As Integer = 0 To dtColdContainer.Rows.Count - 1 'thêm container lạnh
                    ws.Rows(CurRow).Insert(1)
                    ws.Range("P" & CurRow + 1).Copy(ws.Range("P" & CurRow)) 'thêm công thức vào têu
                    ws.Range("Q" & CurRow + 1).Copy(ws.Range("Q" & CurRow)) 'thêm công thức vào weight
                    'CurRow += 1
                    ws.Range("B" & CurRow).Value2 = Strings.Right(dtColdContainer.Rows(CountColdCont).Item("Tranship").ToString, 5)
                    ws.Range("C" & CurRow).Value2 = Strings.Right(dtColdContainer.Rows(CountColdCont).Item("POD").ToString, 5)
                    ws.Range("D" & CurRow).Value2 = Strings.Right(dtColdContainer.Rows(CountColdCont).Item("Dest").ToString, 5)

                    'ws.Range("E" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("20GP").ToString
                    'ws.Range("F" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("40GP").ToString
                    'ws.Range("G" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("40HC").ToString

                    ws.Range("J" & CurRow).Value2 = IIf(dtColdContainer.Rows(CountColdCont).Item("20RF") > 0, dtColdContainer.Rows(CountColdCont).Item("20RF").ToString, "")
                    ws.Range("I" & CurRow).Value2 = IIf(dtColdContainer.Rows(CountColdCont).Item("40RH") > 0, dtColdContainer.Rows(CountColdCont).Item("40RH").ToString, "")
                    ws.Range("K" & CurRow).Value2 = IIf(dtColdContainer.Rows(CountColdCont).Item("40RF") > 0, dtColdContainer.Rows(CountColdCont).Item("40RF").ToString, "")
                    'ws.Range("J" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("45HC").ToString
                    'ws.Range("K" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("40RF").ToString
                    'ws.Range("L" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("POD").ToString
                    'ws.Range("M" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("Dest").ToString
                    ws.Range("R" & CurRow).Value2 = dtColdContainer.Rows(CountColdCont).Item("Cold").ToString
                    'CurRow += 1
                Next
            Next
            Path = "c:\BookingDaily1" & Now().ToString.Replace(":", " ") & ".xls"
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
        SetExcelValue()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class