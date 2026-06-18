Imports System.Globalization
Public Class frmReportDailyBookingReport_Mother

    Dim oTable As New DataTable
    'Dim oTableResult As New DataTable
    Dim strSQL As String
    Public Function WeekOfYear(ByVal d As Date) As Integer
        On Error GoTo Err_Renamed
        Dim myCI As New CultureInfo("en-US")
        Dim myCal As Calendar = myCI.Calendar
        Dim myCWR As CalendarWeekRule = myCI.DateTimeFormat.CalendarWeekRule
        Dim myFirstDOW As DayOfWeek = myCI.DateTimeFormat.FirstDayOfWeek
        'If Me.dtpBookingDate.Text <> "" Then
        WeekOfYear = myCal.GetWeekOfYear(d.Date, myCWR, myFirstDOW)
        'Else
        'WeekOfYear = 0
        'End If
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Function

    Sub QueryVessel()
        Try
            strSQL = "Select Distinct Vessel + ' - ' + MotherVesselNo Data ,OceanETD as ETD,Vessel_Code,Service,MotherSailingSchedule.Capacity as Capacity,MotherSailingSchedule.Slot as Slot,MotherSailingSchedule.POL as POL,MotherSailingSchedule.Operator as Operator, "
            strSQL &= " Sum(SoLuong20GP) as SoLuong20GP,sum(SoLuong40GP) as SoLuong40GP,sum(SoLuong40HC) as SoLuong40HC,Sum(SoLuong45HC) as SoLuong45HC,Sum(SoLuong20RF) as SoLuong20RF,Sum(SoLuong40RF) as SoLuong40RF,Sum(SoLuong40RH) as SoLuong40RH,Sum(Soluong20OT) as Soluong20OT ,Sum(Soluong40OT) as Soluong40OT,Sum(Soluong20FR) as Soluong20FR,Sum(Soluong40FR) as Soluong40FR "
            strSQL &= " From ((ContainerOutboundNotify LEFT JOIN MotherSailingSchedule On ContaineroutboundNotify.MotherSailingScheduleID=MotherSailingSchedule.MotherSailingScheduleID)"
            strSQL &= " LEFT JOIN Vessel On MotherSailingSchedule.MotherVesselID=Vessel.Vessel_ID)"
            strSQL &= " Where  convert(dateTime,OceanETD)>'" & Date.FromOADate(Me.dtpFrom.Value.Date.ToOADate - 1) & "' And Convert(DateTime,OceanETD)<'" & Me.dtpTo.Value.Date.AddDays(1) & "' And ContainerOutBoundNotify.continued=1"
            strSQL &= " Group By Vessel,MotherVesselNo,Vessel_Code,Service,OceanETD,MotherSailingSchedule.Capacity,MotherSailingSchedule.Slot,MotherSailingSchedule.POL,MotherSailingSchedule.Operator "
            strSQL &= "  Order By Data"

            'Dim dt As New DataTable
            oTable = ReadTable(strSQL)
            'oTableResult = ReadTable(strSQL)
            Me.dgdVessel.DataSource = oTable
            InsertAutoNumberToGrid(Me.dgdVessel)
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    'Me.DGDVessel.DataBindings.Add("SelectedValue", dt, "ID")
            '    Me.dgdVessel.Items.Add(dt.Rows(i).Item("Data"))
            'Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmReportDailyBookingReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        Me.txtDate.Text = Now.Date
        Me.txtWeek.Text = "W" & WeekOfYear(Now)
        SetDefaultGrid(Me.dgdResult, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdVessel, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        QueryVessel()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        QueryVessel()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim dt As New DataTable
            dt = oTable.Copy()
            'dt.Columns.Add("SpaceTEU")
            dt.Columns.Add("TotalTeu")
            dt.Columns.Add("SoLuong20SP")
            dt.Columns.Add("Soluong40SP")
            Dim Row As DataRow
            Row = dt.NewRow
            Row("soluong20GP") = 0
            Row("soluong40GP") = 0
            Row("soluong40HC") = 0
            Row("soluong45HC") = 0
            Row("soluong20RF") = 0
            Row("soluong40RF") = 0
            Row("soluong40RH") = 0
            Row("soluong20OT") = 0
            Row("soluong40OT") = 0
            Row("soluong20FR") = 0
            Row("soluong40FR") = 0
            Row("TotalTeu") = 0
            For i As Integer = 0 To Me.dgdVessel.RowCount - 1
                If Me.dgdVessel.Item("Chon", i).Value = False Then
                    dt.Rows(i).Delete()
                Else
                    'dt.Rows(i).Item("SpaceTEU") = ""
                    dt.Rows(i).Item("TotalTeu") = dt.Rows(i).Item("Soluong20GP") + (dt.Rows(i).Item("Soluong40GP") * 2) + (dt.Rows(i).Item("Soluong40HC") * 2) + (dt.Rows(i).Item("Soluong45HC") * 2) + dt.Rows(i).Item("Soluong20RF") + dt.Rows(i).Item("Soluong20GP") + (dt.Rows(i).Item("Soluong40RF") * 2) + dt.Rows(i).Item("Soluong20OT") + (dt.Rows(i).Item("Soluong40OT") * 2) + dt.Rows(i).Item("Soluong20FR") + (dt.Rows(i).Item("Soluong40FR") * 2)
                    dt.Rows(i).Item("SoLuong20SP") = ""
                    dt.Rows(i).Item("Soluong40SP") = ""
                    Row("soluong20GP") += CDbl(dt.Rows(i).Item("Soluong20GP"))
                    Row("soluong40GP") += CDbl(dt.Rows(i).Item("Soluong40GP"))
                    Row("soluong40HC") += CDbl(dt.Rows(i).Item("Soluong40HC"))
                    Row("soluong45HC") += CDbl(dt.Rows(i).Item("Soluong45HC"))
                    Row("soluong20RF") += CDbl(dt.Rows(i).Item("Soluong20RF"))
                    Row("soluong40RF") += CDbl(dt.Rows(i).Item("Soluong40RF"))
                    Row("soluong40RH") += CDbl(dt.Rows(i).Item("Soluong40RH"))
                    Row("soluong20OT") += CDbl(dt.Rows(i).Item("Soluong20OT"))
                    Row("soluong40OT") += CDbl(dt.Rows(i).Item("Soluong40OT"))
                    Row("soluong20FR") += CDbl(dt.Rows(i).Item("Soluong20FR"))
                    Row("soluong40FR") += CDbl(dt.Rows(i).Item("Soluong40FR"))
                    Row("TotalTeu") += CDbl(dt.Rows(i).Item("TotalTeu"))
                End If
            Next

            'For i As Integer = 0 To dt.Rows.Count - 1

            '    'Row("soluong20GP") += CDbl(dt.Rows(i).Item("Soluong20GP"))
            'Next
            dt.Rows.Add(Row)
            Me.dgdResult.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdResult)
            'Dim t, s As Integer
            'For t = 0 To Me.dgdResult.RowCount - 1
            '    For s = 0 To Me.dgdResult.ColumnCount - 1
            '        If Me.dgdResult.Item(s, t).Value.ToString = "0" Then
            '            Me.dgdResult.Item(s, t).Style.ForeColor = mcbkColor
            '        End If
            '    Next
            'Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdResult_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdResult.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdResult)
    End Sub

    Private Sub dgdVessel_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdVessel.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdVessel)
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            If Me.dgdResult.Rows.Count > 0 Then
                ExportExecel(Me.dgdResult, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdCheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCheckAll.Click
        Try
            For i As Integer = 0 To Me.dgdVessel.RowCount - 1
                Me.dgdVessel.Item("Chon", i).Value = 1
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdUncheckAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUncheckAll.Click
        Try
            For i As Integer = 0 To Me.dgdVessel.RowCount - 1
                Me.dgdVessel.Item("Chon", i).Value = 0
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdResult_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dgdResult.RowsRemoved
        InsertAutoNumberToGrid(Me.dgdResult)
    End Sub


End Class