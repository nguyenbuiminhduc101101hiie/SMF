Public Class frmBookingSummaryExcel_Customize


    Function WeekToDate(ByVal Week As Integer, ByVal Year As Integer) As Date ' biết tuần thứ bao nhiêu trong năm tính ra ngày(lịch)
        Try
            Dim CountDayOfWeekNumber As Double = (Week - 1) * 7  'số ngày đã trải qua trong năm hiện tại
            Dim CountDayFrom1990 As Double
            CountDayFrom1990 = CDate("01-01-" & Year).ToOADate()
            CountDayFrom1990 += CountDayOfWeekNumber - 2
            Return Date.FromOADate(CountDayFrom1990)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Sub QueryWeekOfYear()
        Try
            Dim SQL As String
            SQL = "Select Distinct Convert(int,WeekOfYear) as WeekOfYear From ContainerOutboundNotify "
            SQL &= " Where Year(Convert(dateTime,BookingDate))='" & Me.cboYear1.Text & "' And Continued=1 and Editable=1 and WeekofYear <>'0' order By WeekOfYear"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.cboWeekOfYear1.DisplayMember = "WeekOfYear"
            Me.cboWeekOfYear1.DataSource = dt
            Dim dt1 As New DataTable
            SQL = "Select Distinct Convert(int,WeekOfYear) as WeekOfYear From ContainerOutboundNotify "
            SQL &= " Where Year(Convert(dateTime,BookingDate))='" & Me.cboYear2.Text & "' And Continued=1 and Editable=1 and WeekofYear <>'0' order By WeekOfYear"
            dt1 = ReadTable(SQL)
            Me.cboWeekOfYear2.DisplayMember = "WeekOfYear"
            Me.cboWeekOfYear2.DataSource = dt1
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmBookingSummaryExcel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Me.cboYear1.Items.Count > 0 Then
            Me.cboYear1.Items.Clear()
        End If
        Me.cboYear1.Text = Now().Year
        Me.cboYear2.Text = Me.cboYear1.Text
        For i As Integer = 2000 To 2107
            Me.cboYear1.Items.Add(i.ToString)
            Me.cboYear2.Items.Add(i.ToString)
        Next

        For i As Integer = 1 To 53
            Me.cboWeekOfYear1.Items.Add(i.ToString)
            Me.cboWeekOfYear2.Items.Add(i.ToString)
        Next
        Me.cboWeekOfYear1.Text = WeekOfYear(Now.Date)
        Me.cboWeekOfYear2.Text = WeekOfYear(Now.Date)
        'QueryWeekOfYear()
    End Sub

    Private Sub cboWeekOfYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWeekOfYear1.SelectedIndexChanged
        Try
            Dim TempFromDate, TempToDate As Date
            TempFromDate = WeekToDate(CInt(Me.cboWeekOfYear1.Text), CInt(Me.cboYear1.Text))
            TempToDate = TempFromDate.AddDays(6)
            Me.txtFrom1.Text = TempFromDate.Date
            Me.txtTo1.Text = TempToDate.Date
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear1.SelectedIndexChanged
        Try
            Dim TempFromDate, TempToDate As Date
            TempFromDate = WeekToDate(CInt(Me.cboWeekOfYear1.Text), CInt(Me.cboYear1.Text))
            TempToDate = TempFromDate.AddDays(6)
            Me.txtFrom1.Text = TempFromDate.Date
            Me.txtTo1.Text = TempToDate.Date
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
    Function QueryData(ByVal Mar As String, Optional ByVal arg As String = "") As DataTable
        Try
            Dim SQL As String
            SQL = "select Market,Sum(Soluong20GP) as [Soluong20GP],Sum(Soluong40GP) as [Soluong40GP]"
            SQL &= " ,Sum(Soluong40HC) as [Soluong40HC],Sum(Soluong20RF) as [Soluong20RF]"
            SQL &= " ,Sum(Soluong40RF) as [Soluong40RF],Sum(Soluong40RH) as [Soluong40RH],Sum(Soluong45HC) as [Soluong45HC],Sum(Soluong20OT) as [Soluong20OT],Sum(Soluong40OT) as [Soluong40OT],Sum(Soluong20FR) as [Soluong20FR],Sum(Soluong40FR) as [Soluong40FR]"
            SQL &= " from (Containeroutboundnotify INNER JOIN Market On market.Market_ID=Containeroutboundnotify.Market_ID) left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
            SQL &= " where(Containeroutboundnotify.Continued = 1 And Containeroutboundnotify.Editable = 1)"
            SQL &= " And Market.MarketCode='" & Mar & "' " & arg
            SQL &= " group by market"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Return dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Dim app As New Excel.Application
        Try
            Dim Path As String

            app.Visible = True

            Dim SQL As String

            SQL = "Select Distinct MarketCode "
            SQL &= " from (ContainerOutBoundNotify LEFT JOIN Market On ContainerOutBoundNotify.Market_ID=Market.Market_ID) left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
            SQL &= " Where(ContainerOutBoundNotify.Continued = 1 And ContainerOutBoundNotify.Editable = 1)"
            'SQL &= " And Convert(dateTime,etd) between '" & CDate(Me.txtFrom1.Text).Date & "'"
            'SQL &= " And  '" & CDate(Me.txtTo1.Text).Date & "'"
            SQL &= " And Convert(dateTime,etd)>='" & CDate(Me.txtFrom1.Text).Date & " 00:00:00' "
            SQL &= " And Convert(dateTime,etd)<='" & CDate(Me.txtTo1.Text).Date & " 23:59:59' "
            SQL &= " and (marketCode is Not Null Or marketCode='')"
            Dim dtMarket1 As New DataTable
            dtMarket1 = ReadTable(SQL)

            SQL = "Select Distinct MarketCode "
            SQL &= " from (ContainerOutBoundNotify LEFT JOIN Market On ContainerOutBoundNotify.Market_ID=Market.Market_ID)left JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID "
            SQL &= " Where(ContainerOutBoundNotify.Continued = 1 And ContainerOutBoundNotify.Editable = 1)"
            'SQL &= " And Convert(dateTime,etd) between '" & CDate(Me.txtFrom2.Text).Date & "'"
            'SQL &= " And  '" & CDate(Me.txtTo2.Text).Date & "'"
            SQL &= " And Convert(dateTime,etd)>='" & CDate(Me.txtFrom2.Text).Date & " 00:00:00' "
            SQL &= " And Convert(dateTime,etd)<='" & CDate(Me.txtTo2.Text).Date & " 23:59:59' "
            SQL &= " and (marketCode is Not Null Or marketCode='')"
            Dim dtMarket2 As New DataTable
            dtMarket2 = ReadTable(SQL)


            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook
            Path = StartupPath & "\BookingSummary.xls"
            workbook = workbooks.Open(Path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            ws.Range("B3").Value2 = "WEEK NO: " & Me.cboWeekOfYear1.Text & " (" & Me.txtFrom1.Text & " - " & Me.txtTo1.Text & ")"
            Dim Arr1(dtMarket1.Rows.Count, 12) As Object
            ''
            Dim CurRow1 As Integer = 5 'dòng bắt đầu đỗ dữ liệu vào
            Dim CountRow1 As Integer = dtMarket1.Rows.Count
            If CountRow1 > 11 Then
                ws.Rows(10).Insert(CountRow1 - 11)
            End If
            Dim dt1 As New DataTable
            For i As Integer = 0 To dtMarket1.Rows.Count - 1
                Dim market As String
                market = dtMarket1.Rows(i).Item("MarketCode")
                'dt1 = QueryData(market, " And Convert(dateTime,etd) between '" & CDate(Me.txtFrom1.Text).Date & " ' And '" & CDate(Me.txtTo1.Text).Date & "' ")

                dt1 = QueryData(market, " And Convert(dateTime,etd)>='" & CDate(Me.txtFrom1.Text).Date & " 00:00:00' And Convert(dateTime,etd)<='" & CDate(Me.txtTo1.Text).Date & " 23:59:59' ")
                Arr1(i, 0) = market
                Arr1(i, 1) = IIf(dt1.Rows(0).Item("soluong20GP") > 0, dt1.Rows(0).Item("soluong20GP"), "")
                Arr1(i, 2) = IIf(dt1.Rows(0).Item("soluong40GP") > 0, dt1.Rows(0).Item("soluong40GP"), "")
                Arr1(i, 3) = IIf(dt1.Rows(0).Item("soluong40HC") > 0, dt1.Rows(0).Item("soluong40HC"), "")
                Arr1(i, 4) = IIf(dt1.Rows(0).Item("soluong45HC") > 0, dt1.Rows(0).Item("soluong45HC"), "")
                Arr1(i, 5) = IIf(dt1.Rows(0).Item("soluong20RF") > 0, dt1.Rows(0).Item("soluong20RF"), "")
                Arr1(i, 6) = IIf(dt1.Rows(0).Item("soluong40RF") > 0, dt1.Rows(0).Item("soluong40RF"), "")
                Arr1(i, 7) = IIf(dt1.Rows(0).Item("soluong40RH") > 0, dt1.Rows(0).Item("soluong40RH"), "")
                Arr1(i, 8) = IIf(dt1.Rows(0).Item("soluong20OT") > 0, dt1.Rows(0).Item("soluong20OT"), "")
                Arr1(i, 9) = IIf(dt1.Rows(0).Item("soluong40OT") > 0, dt1.Rows(0).Item("soluong40OT"), "")
                Arr1(i, 10) = IIf(dt1.Rows(0).Item("soluong20FR") > 0, dt1.Rows(0).Item("soluong20FR"), "")
                Arr1(i, 11) = IIf(dt1.Rows(0).Item("soluong40FR") > 0, dt1.Rows(0).Item("soluong40FR"), "")




            Next
            ws.Range("B" & CurRow1, "M" & CountRow1 + CurRow1).Value2 = Arr1

            ws.Range("Q3").Value2 = "WEEK NO: " & Me.cboWeekOfYear2.Text & " (" & Me.txtFrom2.Text & " - " & Me.txtTo2.Text & ")"

            Dim Arr2(dtMarket2.Rows.Count, 12) As Object
            ''
            Dim CurRow2 As Integer = 5 'dòng bắt đầu đỗ dữ liệu vào
            Dim CountRow2 As Integer = dtMarket2.Rows.Count
            If (CountRow2 - CountRow1) > 11 Then
                ws.Rows(10).Insert((CountRow2 - CountRow1) - 11)
            End If
            Dim dt2 As New DataTable
            For i As Integer = 0 To dtMarket2.Rows.Count - 1
                Dim market As String
                market = dtMarket2.Rows(i).Item("MarketCode")
                dt2 = QueryData(market, " And Convert(dateTime,etd)>='" & CDate(Me.txtFrom2.Text).Date & " 00:00:00' And Convert(dateTime,etd)<='" & CDate(Me.txtTo2.Text).Date & " 23:59:59' ")
                Arr2(i, 0) = market
                Arr2(i, 1) = IIf(dt2.Rows(0).Item("soluong20GP") > 0, dt2.Rows(0).Item("soluong20GP"), "")
                Arr2(i, 2) = IIf(dt2.Rows(0).Item("soluong40GP") > 0, dt2.Rows(0).Item("soluong40GP"), "")
                Arr2(i, 3) = IIf(dt2.Rows(0).Item("soluong40HC") > 0, dt2.Rows(0).Item("soluong40HC"), "")
                Arr2(i, 4) = IIf(dt2.Rows(0).Item("soluong45HC") > 0, dt2.Rows(0).Item("soluong45HC"), "")
                Arr2(i, 5) = IIf(dt2.Rows(0).Item("soluong20RF") > 0, dt2.Rows(0).Item("soluong20RF"), "")
                Arr2(i, 6) = IIf(dt2.Rows(0).Item("soluong40RF") > 0, dt2.Rows(0).Item("soluong40RF"), "")
                Arr2(i, 7) = IIf(dt2.Rows(0).Item("soluong40RH") > 0, dt2.Rows(0).Item("soluong40RH"), "")
                Arr2(i, 8) = IIf(dt2.Rows(0).Item("soluong20OT") > 0, dt2.Rows(0).Item("soluong20OT"), "")
                Arr2(i, 9) = IIf(dt2.Rows(0).Item("soluong40OT") > 0, dt2.Rows(0).Item("soluong40OT"), "")
                Arr2(i, 10) = IIf(dt2.Rows(0).Item("soluong20FR") > 0, dt2.Rows(0).Item("soluong20FR"), "")
                Arr2(i, 11) = IIf(dt2.Rows(0).Item("soluong40FR") > 0, dt2.Rows(0).Item("soluong40FR"), "")
            Next
            ws.Range("Q" & CurRow2, "AB" & CountRow2 + CurRow2).Value2 = Arr2
            Path = "c:\BookingSummary" & Now.ToString.Replace(":", "").Replace("/", "") & ".xls"
            workbook.SaveAs(Path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        Finally
            app.Quit()
        End Try
    End Sub

    Private Sub cboYear2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear2.SelectedIndexChanged
        Try
            Dim TempFromDate, TempToDate As Date
            TempFromDate = WeekToDate(CInt(Me.cboWeekOfYear2.Text), CInt(Me.cboYear2.Text))
            TempToDate = TempFromDate.AddDays(6)
            Me.txtFrom2.Text = TempFromDate.Date
            Me.txtTo2.Text = TempToDate.Date
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cboWeekOfYear2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWeekOfYear2.SelectedIndexChanged
        Try
            Dim TempFromDate, TempToDate As Date
            TempFromDate = WeekToDate(CInt(Me.cboWeekOfYear2.Text), CInt(Me.cboYear2.Text))
            TempToDate = TempFromDate.AddDays(6)
            Me.txtFrom2.Text = TempFromDate.Date
            Me.txtTo2.Text = TempToDate.Date
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class