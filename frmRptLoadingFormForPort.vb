Public Class frmRptLoadingFormForPort

    Dim oTableBooking As New DataTable
    Dim SQL, path As String

    Sub QueryVessel()
        Try
            SQL = "Select SailingScheduleID as ID ,Vessel + ' - ' + voyNo as value "
            SQL &= " From SailingSchedule inner join vessel on SailingSchedule.Vessel_ID=Vessel.Vessel_ID where  SailingSchedule.Continued=1  And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "' Order By Vessel "
            Dim oTableVessel As New DataTable
            oTableVessel = ReadTable(SQL)
            Me.cboVessel.DisplayMember = "Value"
            Me.cboVessel.ValueMember = "ID"
            Me.cboVessel.DataSource = oTableVessel
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim strSQL As String
            strSQL = "Select SailingScheduleID as ID,Vessel + ' - ' + voyNo as value "
            strSQL &= " From SailingSchedule inner join vessel "
            strSQL &= "on SailingSchedule.Vessel_ID=Vessel.Vessel_ID where  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpLeavingDate.Value.Date & "' And ETD <= '" & Me.dtpLeavingDate.Value.Date & "' "
            strSQL &= "Order By Vessel "
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                QueryVessel()
                'Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            Else
                MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryBookingData(ByVal sailingID As String)
        Try
            SQL = "Select Distinct BookingNo,Customer.Company,FullReturnContainerPlace,"
            SQL &= "Cold as Temp,Ventilation as Vent,Right(Tranship,5) as TranShip, " 'replace(left(Tranship,len(Tranship)-5),'-','') as POD,"
            SQL &= "replace(left(PortOfUnloading,len(PortOfUnloading)-5),'-','') as PortOfDisCharge,replace(left(destination,len(destination)-5),'-','') as FinalDestiNation,Right(destination,5) as TSCode,PackingWay as stuffingPlace "
            SQL &= " , ContainerOutboundNotify.ContainerOutboundNotifyID,Soluong20GP as [20GP],Soluong40GP as [40GP], Soluong40HC as [40HC],Soluong45HC as [45HC],Soluong40RF as [40RF],Soluong20RF as [20RF],Soluong40RH as [40RH] "
            SQL &= " From (ContainerOutboundNotify LEFT JOIN CUSTOMER On ContainerOutboundNotify.Customer_ID=Customer.Customer_ID)"
            SQL &= " Where ContainerOutboundNotify.Continued=1  And ContainerOutboundNotify.SailingScheduleID='" & sailingID & "'"
            SQL &= " Order By BookingNo"
            oTableBooking = ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function QueryLoadingPlan(ByVal BookingID As String) As DataTable
        Try
            Dim SQL As String
            SQL = "select Replace(Convert(nvarchar,DateoFsupplyemptycontainer),'12:00AM','') as NgayCapCont,Container_No,Seal as SealNo,PLACESUPPLYEMPTYCONTAINER,"
            SQL &= "CTN_SIZE_TYPE as Type,Weight as GrossWeight,LoadingPlanForVessel.RETURNPLACE,LoadingPlanForVessel.ReturnDate,CustomClear "
            SQL &= " From (LoadingPlanForVessel LEFT JOIN Container On Container.CTN_ID=LoadingPlanForVessel.CTN_ID)"
            SQL &= " Where LoadingPlanForVessel.Continued=1 And LoadingPlanForVessel.ContainerOutboundNotifyID='" & BookingID & "'"
            Return ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Function GetCountRow(ByVal BookingID As String) As Integer
        Try
            Dim SQL As String
            SQL = "select Sum(Soluong20GP+soluong40GP+soluong40HC+soluong45HC+Soluong20RF+soluong40RF+soluong40RH)"
            SQL &= " from ContainerOutboundNotify "
            SQL &= " Where ContainerOutboundNotify.ContainerOutboundNotifyID='" & BookingID & "' And Continued=1 And Editable=1 "
            Dim TempTable As New DataTable
            TempTable = ReadTable(SQL)
            Return TempTable.Rows(0).Item(0)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub SetExcelValue()
        Dim app As Excel.Application
        Dim rscold As New ADODB.Recordset
        Dim sqlcold As String
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}
            
            app = New Excel.Application()
            'Else
            'app = Proc(0)x
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            path = StartupPath & "\LoadingFormForPort.xls"

            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If


            ws.Range("A3").Value2 = "Port Of Loading :" & Me.cboPOL.Text
            Dim tempPOD As String = ""
            If oTableBooking.Rows.Count > 0 Then
                tempPOD = oTableBooking.Rows(0).Item("Tranship").ToString()
            End If
            ws.Range("A4").Value2 = "Port Of Discharge :" & tempPOD
            ws.Range("A2").Value2 = "LOADING PLAN OF " & Me.cboVessel.Text & " ETD :" & Me.dtpLeavingDate.Value.Date

            Dim CountRow As Integer = 0
            Dim BookingID As String = ""
            Dim CurRow As Integer = 8
            Dim Row As Integer = 1
            Dim BookingNo As String = ""

            Dim Container_arr() As String = {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH"}
            
            For i As Integer = 0 To oTableBooking.Rows.Count - 1
                BookingID = oTableBooking.Rows(i).Item("ContainerOutboundNotifyID").ToString
                BookingNo = oTableBooking.Rows(i).Item("BookingNo").ToString
                CountRow = GetCountRow(BookingID)
                Dim Container_Type(Container_arr.Length) As String
                Dim CountType(Container_arr.Length) As Integer
                Dim FactType As Integer = 0
                For C As Integer = 0 To Container_arr.Length - 1
                    If oTableBooking.Rows(i).Item(Container_arr(C)) > 0 Then
                        Container_Type(FactType) = Container_arr(C)
                        CountType(FactType) = oTableBooking.Rows(i).Item(Container_arr(C))
                        FactType += 1
                    End If
                Next
                Dim oTableLoadingPlan As New DataTable
                oTableLoadingPlan = QueryLoadingPlan(BookingID)
                Dim j As Integer = 0
                Dim DELAY, DELAYDATE As String

                For j = 0 To oTableLoadingPlan.Rows.Count - 1
                    'Thông tin Booking
                    If oTableLoadingPlan.Rows(j).Item("Container_No").ToString <> "" Then
                        sqlcold = " select cold,vent, DELAY,DELAYDATE from LOADINGPLANFORVESSEL inner join container on LOADINGPLANFORVESSEL.CTN_ID=container.ctn_id where container.container_no = '" & oTableLoadingPlan.Rows(j).Item("Container_No").ToString.Trim & "'"
                        rscold.Open(sqlcold, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        If Not rscold.EOF Then
                            ws.Range("J" & CurRow).Value2 = rscold.Fields("Cold").Value
                            ws.Range("K" & CurRow).Value2 = rscold.Fields("vent").Value
                            DELAY = rscold.Fields("DELAY").Value
                            DELAYDATE = rscold.Fields("DELAYDATE").Value

                        End If
                        rscold.Close()
                    End If
                    ws.Range("A" & CurRow).Value2 = Row 'STT
                    ws.Range("B" & CurRow).Value2 = oTableBooking.Rows(i).Item("BookingNo").ToString
                    ws.Range("C" & CurRow).Value2 = oTableBooking.Rows(i).Item("Company").ToString
                    ws.Range("L" & CurRow).Value2 = oTableBooking.Rows(i).Item("Tranship").ToString
                    ws.Range("M" & CurRow).Value2 = oTableBooking.Rows(i).Item("PortOfDisCharge").ToString
                    ws.Range("N" & CurRow).Value2 = oTableBooking.Rows(i).Item("FinalDestiNation").ToString
                    ws.Range("O" & CurRow).Value2 = oTableBooking.Rows(i).Item("TSCode").ToString
                    ws.Range("P" & CurRow).Value2 = oTableBooking.Rows(i).Item("stuffingPlace").ToString
                    'Thông Tin loading(Plan)
                    ws.Range("D" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("NgayCapCont").ToString
                    ws.Range("E" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("PLACESUPPLYEMPTYCONTAINER").ToString
                    ws.Range("F" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("Container_No").ToString
                    ws.Range("G" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("SealNo").ToString
                    ws.Range("H" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("Type").ToString
                    ws.Range("U" & CurRow).Value2 = DELAYDATE
                    For K As Integer = 0 To FactType - 1 'kiểm tra container có cấp đủ không
                        If Container_Type(K) = oTableLoadingPlan.Rows(j).Item("Type").ToString Then
                            CountType(K) -= 1
                        End If
                    Next
                    ws.Range("I" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("GrossWeight").ToString
                    ws.Range("Q" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("RETURNPLACE").ToString
                    ws.Range("R" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("ReturnDate").ToString
                    ws.Range("T" & CurRow).Value2 = oTableLoadingPlan.Rows(j).Item("CustomClear").ToString
                    Row += 1
                    CurRow += 1
                Next
                For L As Integer = j + 1 To CountRow
                    ws.Range("A" & CurRow).Value2 = Row 'STT
                    ws.Range("B" & CurRow).Value2 = BookingNo
                    For K As Integer = 0 To FactType - 1 'kiểm tra container có còn container chưa cấp không
                        If CountType(K) > 0 Then
                            CountType(K) -= 1
                            ws.Range("H" & CurRow).Value2 = Container_Type(K)
                            Exit For
                        End If
                    Next

                    ws.Range("Q" & CurRow).Value2 = oTableBooking.Rows(i).Item("FullReturnContainerPlace").ToString
                    ws.Range("C" & CurRow).Value2 = oTableBooking.Rows(i).Item("Company").ToString
                    ws.Range("L" & CurRow).Value2 = oTableBooking.Rows(i).Item("Tranship").ToString
                    ws.Range("M" & CurRow).Value2 = oTableBooking.Rows(i).Item("PortOfDisCharge").ToString
                    ws.Range("N" & CurRow).Value2 = oTableBooking.Rows(i).Item("FinalDestiNation").ToString
                    ws.Range("O" & CurRow).Value2 = oTableBooking.Rows(i).Item("TSCode").ToString
                    ws.Range("P" & CurRow).Value2 = oTableBooking.Rows(i).Item("stuffingPlace").ToString
                    Row += 1
                    CurRow += 1
                Next
            Next
            ws.Range("A8", "U" & CurRow).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
            ws.Range("A8", "U" & CurRow).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            ws.Range("A8", "U" & CurRow).Cells.BorderAround(1, Excel.XlBorderWeight.xlMedium)

            path = "c:\loadingFromForPort" & Me.cboVessel.Text.Trim & ".xls"
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            app.Quit()
        End Try

    End Sub
    Sub QueryPOL(ByVal ID As String)
        Try
            SQL = "select distinct ReturnPlace "
            SQL &= "from (LOADINGPLANFORVESSEL LEFT JOIN ContainerOutboundNotify On LOADINGPLANFORVESSEL.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= "Where LOADINGPLANFORVESSEL.Continued=1 And SailingScheduleID='" & ID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboPOL.Text = ""
            If Me.cboPOL.Items.Count > 0 Then
                Me.cboPOL.Items.Clear()
            End If

            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cboPOL.Items.Add(dt.Rows(i).Item("ReturnPlace").ToString)
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try
            QueryPOL(Me.cboVessel.SelectedValue.ToString)
            SQL = "Select ETD From SailingSchedule Where SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = dt.Rows(0).Item("ETD").ToString
            Else
                MsgBox("The Schedule Is Invalid , Please Check Again")
                Return
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Source)
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub frmRptLoadingFormForPort_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        Dim Ngay() As String
        If Not IsNothing(frmInputLoadingPlanForVessel.cboVesselVoyNoETD.SelectedValue) Then
            Ngay = frmInputLoadingPlanForVessel.cboVesselVoyNoETD.Text.Split("-")
            Me.dtpLeavingDate.Value = Ngay(2).Trim
        End If
    End Sub


    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryBookingData(Me.cboVessel.SelectedValue.ToString)
        SetExcelValue()
    End Sub
End Class