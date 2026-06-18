Public Class frmReportBookingSummary

    Dim oTable As New DataTable
    Dim strQuery As String

    Sub SelectYear()
        Try
            strQuery = " Select distinct Year(BookingDate) as data from ContainerOutboundnotify Where Continued=1 Order By Data"
            Dim dt As New DataTable
            dt = ReadTable(strQuery)
            Me.cboYear.DisplayMember = "Data"
            Me.cboYear.ValueMember = "Data"
            Me.cboYear.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryVessel()
        Try
            strQuery = "Select Distinct SailingScheduleID as ID,Vessel +' - '+ VoyNo + ' - ' + replace(convert(nvarchar,ETD),'12:00AM','') as Data , etd "
            strQuery &= "From (SailingSchedule LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID)"
            strQuery &= "Where SailingSchedule.Continued=1 Order By ETD "
            Dim dt As New DataTable
            dt = ReadTable(strQuery)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.ValueMember = "ID"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryTheoTau()
        Try
            Dim Temp() As String
            Temp = Strings.Split(Me.cboVessel.Text.Trim, " - ")
            If Temp.Length < 2 Then
                Return
            End If
            Dim Vessel, VoyNo As String
            Vessel = Temp(0)
            VoyNo = Temp(1)
            strQuery = "select Market,sum(Soluong20GP) as Soluong20GP,sum(Soluong40GP) as Soluong40GP,sum(Soluong40HC) as Soluong40HC,Sum(Soluong45HC) as Soluong45HC,sum(Soluong20RF) as Soluong20RF,sum(Soluong40RF) as Soluong40RF,Sum(Soluong40RH) as Soluong40RH,Sum(Soluong20OT) as Soluong20OT ,Sum(Soluong40OT) as Soluong40OT,Sum(Soluong20FR) as Soluong20FR,Sum(Soluong40FR) as Soluong40FR  "
            strQuery &= " From (((ContainerOutBoundNotify LEFT JOIN SailingSchedule On ContainerOutBoundNotify.SailingScheduleID=SailingSchedule.SailingscheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID)"
            strQuery &= " LEFT JOIN Market On Market.Market_ID=Containeroutboundnotify.Market_ID)"
            strQuery &= " Where ContainerOutBoundNotify.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString.Trim & "' And ContainerOutBoundNotify.Continued=1 And ContainerOutBoundNotify.Editable=1"
            strQuery &= " Group By Market"
            oTable = ReadTable(strQuery)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryTheoNgay()
        Try
            strQuery = "select Market,sum(Soluong20GP) as Soluong20GP,sum(Soluong40GP) as Soluong40GP,sum(Soluong40HC) as Soluong40HC,Sum(Soluong45HC) as Soluong45HC,sum(Soluong20RF) as Soluong20RF,sum(Soluong40RF) as Soluong40RF,Sum(Soluong40RH) as Soluong40RH,Sum(Soluong20OT) as Soluong20OT ,Sum(Soluong40OT) as Soluong40OT,Sum(Soluong20FR) as Soluong20FR,Sum(Soluong40FR) as Soluong40FR "
            strQuery &= " from (Containeroutboundnotify LEFT JOIN Market On Market.Market_ID=ContainerOutboundnotify.Market_ID)"
            strQuery &= " Where WeekOfYear='" & Me.cboWeek.Text.Trim & "' And Year(BookingDate)=" & Me.cboYear.Text.Trim & " And Containeroutboundnotify.Continued=1 and Containeroutboundnotify.Editable=1"
            strQuery &= " Group By Market"
            oTable = ReadTable(strQuery)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            If Me.chkDateFind.Checked = True Then
                QueryTheoNgay() 'theo tuần và năm
            Else
                QueryTheoTau() 'theo tàu và số chuyến
            End If
            Me.dgdResult.DataSource = oTable
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

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdResult.Rows.Count > 0 Then
                'SetMenu(False)
                Me.Cursor = Cursors.WaitCursor
                ExportExecel(Me.dgdResult, Me)

                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmSearchPhieuThuTien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
        SetDefaultGrid(Me.dgdResult, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SelectYear()
    End Sub

    Private Sub cboYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboYear.SelectedIndexChanged
        Try
            If Me.cboYear.Items.Count = 0 Then
                Return
            End If
            Dim Year As Integer
            Year = CInt(Me.cboYear.SelectedValue.ToString)
            strQuery = "Select Distinct WeekOfYear From ContainerOutboundNotify Where Year(BookingDate)=" & Year & " And Continued=1 Order By WeekOfYear"
            Dim dt As New DataTable
            dt = ReadTable(strQuery)
            Me.cboWeek.DisplayMember = "WeekOfYear"
            Me.cboWeek.ValueMember = "WeekOfYear"
            Me.cboWeek.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class