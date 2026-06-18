Public Class frmbookingEWDailyReport
    Public Structure Pos
        Public Portname As String
        Public StartPoint As Integer
        Public EndPoint As Integer
    End Structure
    Dim PortDetail(30) As Pos
    Dim Path As String = ""
    Dim oTableData As DataTable
    Dim oTableDataDetail As DataTable


    Sub QueryVessel(Optional ByVal arg As String = "")
        Try
            Dim SQL As String
            'SQL = "Select MotherSailingScheduleID as ID ,Vessel + '-' + MotherVesselNo as Data "
            'SQL &= " From MotherSailingSchedule LEFT JOIN Vessel On MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID "
            'SQL &= " Where MotherSailingSchedule.Continued=1 " & arg
            'SQL &= " Order By Data "
            SQL = "Select SailingScheduleID as ID,Vessel + '-' + voyNo as Data "
            SQL = SQL & " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 and ETD='" & Me.dtpETD.Value.Date & "' Order By Vessel_Code desc"
            Dim dt As DataTable
            dt = ReadTable(SQL)
            If dt Is Nothing Then
                dt = New DataTable
            End If
            Me.cboMotherVessel.DisplayMember = "Data"
            Me.cboMotherVessel.ValueMember = "ID"
            Me.cboMotherVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboMotherVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMotherVessel.SelectedIndexChanged
        Try
            If IsNothing(Me.cboMotherVessel.SelectedValue) Then
                Return
            End If
            Dim SQL As String
            SQL = "Select OceanETD From MotherSailingSchedule "
            SQL &= " Where MotherSailingSchedule.MotherSailingScheduleID='" & Me.cboMotherVessel.SelectedValue.ToString & "' And Continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                'MsgBox("There is not any ETD for this schedule")
                Return
            End If
            Me.dtpETD.Text = dt.Rows(0).Item("OceanETD").ToString

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dtpETD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpETD.ValueChanged

        Try
            Dim strSQL As String
            strSQL = "Select SailingScheduleID,Vessel + '-' + voyNo as value "
            strSQL &= " From SailingSchedule,vessel "
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD >= '" & Me.dtpETD.Value.Date & "' And ETD <= '" & Me.dtpETD.Value.Date & "'"
            strSQL &= "Order By Vessel_Code desc"
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboMotherVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
                QueryVessel()
            Else
                'MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpETD.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryMarket()
        Try
            Dim SQL As String
            SQL = " Select Market_ID as ID ,MarketCode + '-' + Market  as Data"
            SQL &= " From Market "
            SQL &= " Where Continued=1 "
            SQL &= " Order By MarketCode"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboMarket.DisplayMember = "data"
            Me.cboMarket.ValueMember = "ID"
            Me.cboMarket.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    'Sub QueryMotherService()
    '    Try
    '        Dim SQL As String
    '        SQL = "Select Distinct Service as Data From MotherSailingSchedule"
    '        SQL &= " Where Continued=1 "
    '        SQL &= " Order By Service"
    '        Dim dt As New DataTable
    '        dt = ReadTable(SQL)
    '        Me.cboService.DisplayMember = "data"
    '        Me.cboService.ValueMember = "data"
    '        Me.cboService.DataSource = dt
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try
    'End Sub

    Private Sub frmboookingEWDailyReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.chkeast.Text = "EUS"
        QueryVessel()
        QueryMarket()
        'QueryMotherService()
    End Sub


    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Function QueryData() As DataTable
        Try
            Dim SQL As String 'ContainerOutboundNotifyID, ServiceContract,LeavingDate,MotherSailingSchedule.Service as Service
            SQL = "Select Sum(SoLuong20GP) as SoLuong20GP,Sum(SoLuong40GP) as SoLuong40GP,Sum(SoLuong40HC) as SoLuong40HC,Sum(SoLuong45HC) as SoLuong45HC,Sum(SoLuong20RF) as SoLuong20RF,Sum(SoLuong40RF) as SoLuong40RF,Sum(SoLuong40RH) as SoLuong40RH,Sum(SoLuong20OT) as SoLuong20OT,Sum(SoLuong40OT) as SoLuong40OT,Sum(SoLuong20FR) as SoLuong20FR,Sum(SoLuong40FR) as SoLuong40FR, PortOfUnLoading "
            SQL &= " From (ContainerOutboundNotify INNER JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            SQL &= " where ContainerOutboundNotify.continued=1 And SailingSchedule.SailingScheduleID='" & Me.cboMotherVessel.SelectedValue.ToString & "' "
            SQL &= " And ContainerOutboundNotify.Market_ID='" & Me.cboMarket.SelectedValue.ToString & "'"
            SQL &= " Group By PortOfUnLoading"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function QueryDataDetail() As DataTable
        Try
            Dim SQL As String 'ContainerOutboundNotifyID, ServiceContract,LeavingDate,MotherSailingSchedule.Service as Service
            SQL = "Select distinct ContainerOutboundNotify.ServiceContract as SC,Sum(SoLuong20GP) as SoLuong20GP,Sum(SoLuong40GP) as SoLuong40GP,Sum(SoLuong40HC) as SoLuong40HC,Sum(SoLuong45HC) as SoLuong45HC,Sum(SoLuong20RF) as SoLuong20RF,Sum(SoLuong40RF) as SoLuong40RF,Sum(SoLuong40RH) as SoLuong40RH,Sum(SoLuong20OT) as SoLuong20OT,Sum(SoLuong40OT) as SoLuong40OT,Sum(SoLuong20FR) as SoLuong20FR,Sum(SoLuong40FR) as SoLuong40FR, PortOfUnLoading,Right(PortOfLoading,5) as POL "
            SQL &= " From ContainerOutboundNotify "
            SQL &= " where ContainerOutboundNotify.continued=1 and SailingScheduleID='" & Me.cboMotherVessel.SelectedValue.ToString & "' "
            SQL &= " And ContainerOutboundNotify.Market_ID='" & Me.cboMarket.SelectedValue.ToString & "'"
            SQL &= " Group By PortOfUnLoading,ContainerOutboundNotify.ServiceContract,PortOfLoading"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function QueryPortOfDisCharge() As DataTable
        Try
            Dim SQL As String 'ContainerOutboundNotifyID, ServiceContract,LeavingDate,MotherSailingSchedule.Service as Service
            SQL = "Select Distinct PortOfUnLoading as POD "
            SQL &= " From ContainerOutboundNotify "
            SQL &= " where ContainerOutboundNotify.continued=1 And SailingScheduleID='" & Me.cboMotherVessel.SelectedValue.ToString & "' "
            SQL &= " And ContainerOutboundNotify.Market_ID='" & Me.cboMarket.SelectedValue.ToString & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Function QueryServiceContract() As DataTable
        Try
            Dim SQL As String 'ContainerOutboundNotifyID, ServiceContract,LeavingDate,MotherSailingSchedule.Service as Service
            SQL = "Select Distinct ContainerOutboundNotify.ServiceContract as SC,right(PORTOFLOADING,5) as POL "
            SQL &= " From (ContainerOutboundNotify LEFT JOIN BillOfLading On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID) "
            SQL &= " where ContainerOutboundNotify.continued=1 And SailingScheduleID='" & Me.cboMotherVessel.SelectedValue.ToString & "' "
            SQL &= " And ContainerOutboundNotify.Market_ID='" & Me.cboMarket.SelectedValue.ToString & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Sub SetOnePortData(ByRef ws As Excel._Worksheet, ByVal StartRow As Integer, ByVal DisChargePortName As String, ByVal RowInDataTable As Integer, ByVal StartPoint As Integer, ByVal EndPoint As Integer) 'startpoint and EndPoint là Vitrí của ký tự trong Alpha() mảng tòan cục trong Variable
        Try
            ws.Range(Alpha(StartPoint) & StartRow).Value = DisChargePortName
            ws.Range(Alpha(StartPoint) & StartRow, Alpha(EndPoint) & StartRow).MergeCells = 1

            Dim Type() As String = {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH", "20OT", "40OT", "20FR", "40FR"}
            Dim Temp As Integer = 0
           
            For i As Integer = StartPoint To EndPoint
                If Temp > 10 Then ' dung cho cac loai cont dac biet
                    Exit For
                End If
                ws.Range(Alpha(i) & StartRow + 1).Value = Type(Temp)
                For j As Integer = RowInDataTable To oTableData.Rows.Count - 1
                    If oTableData.Rows(j).Item("PortOfUnLoading").ToString.Trim = DisChargePortName.Trim Then
                        ws.Range(Alpha(i) & StartRow + 2).Value = oTableData.Rows(j).Item("SoLuong" & Type(Temp)).ToString
                        ws.Range("C8").Value += IIf(Type(Temp) Like "4*", oTableData.Rows(j).Item("SoLuong" & Type(Temp)) * 2, oTableData.Rows(j).Item("SoLuong" & Type(Temp)))
                        Exit For
                    End If
                Next
                Temp += 1
            Next


            'ws.Range(Alpha(StartPoint) & StartRow, Alpha(EndPoint) & StartRow + 18).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            'ws.Range(Alpha(StartPoint) & StartRow, Alpha(EndPoint) & StartRow + 18).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
            'ws.Range(Alpha(StartPoint) & StartRow, Alpha(EndPoint) & StartRow + 18).Cells.BorderAround(1, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub SetExcelValueE()
        Dim app As Excel.Application
        Try

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = StartupPath & "\BookingEWDailyReportE.xls"

            workbook = workbooks.Open(Path)

            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            oTableData = QueryData()
            Dim startPoint, EndPoint, StartRow As Integer
            Dim DisChargePortName As String = ""

            startPoint = 3 'tương ứng vị trí thứ 4 trong alpha() trong variable Ký tự 'D'
            EndPoint = startPoint + 10
            StartRow = 6
            For i As Integer = 0 To oTableData.Rows.Count - 1
                DisChargePortName = oTableData.Rows(i).Item("PortOfUnLoading").ToString
                SetOnePortData(ws, StartRow, DisChargePortName, i, startPoint, EndPoint)
                startPoint += 11
                EndPoint = startPoint + 10
            Next

            'set data detail 
            oTableDataDetail = QueryDataDetail()
            startPoint = 4
            EndPoint = startPoint + 10
            Dim CurRow As Integer = 30 'dòng bắt đầu gán dữ liệu
            Dim BeginRow As Integer = 27
            'neu port of discharge chua xuat hien thi moi lay startPoint,EndPoint moi
            'neu da xuat hien thi 
            SetPortDataDetail(ws, BeginRow, CurRow, startPoint, EndPoint)
            Dim Tempvessel() As String = Me.cboMotherVessel.Text.Split("-")
            If Tempvessel.Length >= 2 Then
                ws.Range("B4").Value = Tempvessel(0)
                ws.Range("C4").Value = Tempvessel(1)
            End If

            'ws.Range("A4").Value = "Via " & Me.cboService.Text

            Path = "c:\BookingEWDailyReportEast" & Me.cboMotherVessel.Text & Now().ToString.Replace(":", " ") & ".xls"

            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
            MsgBox("Complete")
            'app.Visible = True
        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            app.Quit()
            Return
        End Try

    End Sub

    Sub SetExcelValueW()
        Dim app As Excel.Application
        Try


            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = StartupPath & "\BookingEWDailyReportW.xls"

            workbook = workbooks.Open(Path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If
            oTableData = QueryData()
            Dim startPoint, EndPoint, StartRow As Integer
            Dim DisChargePortName As String = ""

            startPoint = 3 'tương ứng vị trí thứ 4 trong alpha() trong variable Ký tự 'D'
            EndPoint = startPoint + 10
            StartRow = 6
            For i As Integer = 0 To oTableData.Rows.Count - 1
                DisChargePortName = oTableData.Rows(i).Item("PortOfUnLoading").ToString
                SetOnePortData(ws, StartRow, DisChargePortName, i, startPoint, EndPoint)
                startPoint += 11
                EndPoint = startPoint + 10
            Next

            'set data detail 
            oTableDataDetail = QueryDataDetail()
            startPoint = 4
            EndPoint = startPoint + 10
            Dim CurRow As Integer = 30 'dòng bắt đầu gán dữ liệu
            Dim BeginRow As Integer = 27
            'neu port of discharge chua xuat hien thi moi lay startPoint,EndPoint moi
            'neu da xuat hien thi 
            SetPortDataDetail(ws, BeginRow, CurRow, startPoint, EndPoint)

            Dim Tempvessel() As String = Me.cboMotherVessel.Text.Split("-")
            If Tempvessel.Length >= 2 Then
                ws.Range("C5").Value = Tempvessel(0)
                ws.Range("D5").Value = Tempvessel(1)
            End If

            'ws.Range("A5").Value = "Via " & Me.cboService.Text



            Path = "c:\BookingEWDailyReportWest" & Me.cboMotherVessel.Text & Now().ToString.Replace(":", " ") & ".xls"

            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            app.Quit()
            Return
        End Try

    End Sub



    Function SetPortDataDetail(ByRef ws As Excel._Worksheet, ByVal BeginRow As Integer, ByVal CurRow As Integer, ByRef StartPoint As Integer, ByRef EndPoint As Integer) As Boolean
        Try


            Dim Result As Boolean = False 'port discharge  chua xuat hien
            'CurRow  'dòng bắt đầu điền dữ liệu
            Dim Type() As String = {"20GP", "40GP", "40HC", "45HC", "20RF", "40RF", "40RH", "20OT", "40OT", "20FR", "40FR"}
            'công thức tính subtotal teus
            Dim formula As String = "="
            Dim TempTable As DataTable = QueryPortOfDisCharge()
            Dim CountPOD As Integer = TempTable.Rows.Count
            For i As Integer = 0 To TempTable.Rows.Count - 1
                Result = True
                PortDetail(i).Portname = TempTable.Rows(i).Item("POD").ToString
                PortDetail(i).StartPoint = StartPoint
                PortDetail(i).EndPoint = EndPoint


                ws.Range(Alpha(StartPoint) & BeginRow).Value = TempTable.Rows(i).Item("POD").ToString
                ws.Range(Alpha(StartPoint) & BeginRow, Alpha(EndPoint) & BeginRow).MergeCells = 1
                Dim Temp As Integer = 0
                For j As Integer = StartPoint To EndPoint 'liệt kê 7 lọai container chưa phải dữ liệu
                    If Temp > 10 Then ' dung luon cho cac cont dac viet
                        Exit For
                    End If
                    ws.Range(Alpha(j) & BeginRow + 1).Value = Type(Temp)
                    Temp += 1
                Next

                formula &= Alpha(StartPoint) & BeginRow + 2 & "+" & Alpha(StartPoint + 4) & BeginRow + 2 & "+" 'container 20 feet
                formula &= "(" & Alpha(StartPoint + 1) & BeginRow + 2 & "+" & Alpha(StartPoint + 2) & BeginRow + 2 & "+" & Alpha(StartPoint + 3) & BeginRow + 2 & "+" & Alpha(StartPoint + 5) & BeginRow + 2 & "+" & Alpha(StartPoint + 6) & BeginRow + 2 & ")*2 +"
                StartPoint += 11
                EndPoint = StartPoint + 10
            Next
            If formula.Length > 0 Then
                formula = formula.Remove(formula.Length - 1, 1)
            End If
            ws.Range("D29").Value = formula
            Dim dtSC As DataTable = QueryServiceContract() 'lấy tất cả số hợp đồng thỏa điều kiện

            For i As Integer = 0 To dtSC.Rows.Count - 1 'duyệt hết tất cả các số hợp đồng
                ws.Rows(CurRow).Insert(1)
                ws.Range("D" & CurRow - 1).Copy(ws.Range("D" & CurRow))
                ws.Range("A" & CurRow).Value = dtSC.Rows(i).Item("POL").ToString.Trim
                ws.Range("B" & CurRow).Value = dtSC.Rows(i).Item("SC").ToString.Trim
                'ws.Range("C" & CurRow).Value = oTableDataDetail.Rows(j).Item("Shipper_1").ToString.Trim

                For j As Integer = 0 To oTableDataDetail.Rows.Count - 1 'duyệt tất cả các Dòng thỏa điều kiện có SC No. Lặp đi nhiều book
                    If oTableDataDetail.Rows(j).Item("SC").ToString.Trim = dtSC.Rows(i).Item("SC").ToString.Trim Then
                        For l As Integer = 0 To CountPOD - 1 'duyệt hết các POD 
                            If UCase(oTableDataDetail.Rows(j).Item("PortOfUnLoading").ToString.Trim) = UCase(PortDetail(l).Portname.Trim) Then
                                For k As Integer = 0 To Type.Length - 1
                                    If oTableDataDetail.Rows(j).Item("SoLuong" & Type(k)) > 0 Then
                                        ws.Range(Alpha(PortDetail(l).StartPoint + k) & CurRow).Value = oTableDataDetail.Rows(j).Item("SoLuong" & Type(k)).ToString
                                    End If

                                Next
                            End If
                        Next

                    End If
                Next
            Next

            If Result = True Then
                'ws.Range(Alpha(4) & BeginRow, Alpha(PortDetail(CountPOD - 1).EndPoint) & CurRow + dtSC.Rows.Count).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
                'ws.Range(Alpha(4) & BeginRow, Alpha(PortDetail(CountPOD - 1).EndPoint) & CurRow + dtSC.Rows.Count).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
                'ws.Range(Alpha(4) & BeginRow, Alpha(PortDetail(CountPOD - 1).EndPoint) & CurRow + dtSC.Rows.Count).Cells.BorderAround(1, Excel.XlBorderWeight.xlThin, Excel.XlColorIndex.xlColorIndexAutomatic, 1)
            End If

            Return Result
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    'Private Sub cboService_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        If Me.cboService.FindStringExact(Me.cboService.Text.Trim) = -1 Then
    '            Return
    '        End If
    '        QueryMotherVessel(" And MotherSailingSchedule.Service='" & Me.cboService.Text.Trim & "'")
    '    Catch ex As Exception
    '        DisplayMessage(True, Err.Description)
    '    End Try

    'End Sub

    Private Sub cmdok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdok.Click
        Try
            If Me.chkEast.Checked = True Then
                SetExcelValueE()
            Else
                SetExcelValueW()
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboMarket_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMarket.SelectedIndexChanged

    End Sub
End Class