Public Class frmBookingSupplyOrder
    Dim mFilter As String




    Sub QueryOrder()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strQuery As String
            strQuery = " select [Order].BookingNo,[Order].OrderNo,[Order].OrderDate,[Order].DaiDien,[Order].SupplyDepot,[Order].CMND,[Order].Remarks,[Order].Soluong20GP,[Order].Soluong40GP,[Order].Soluong20RF,[Order].Soluong40RF,[Order].Soluong40HC,[Order].Soluong45HC,[Order].Soluong40RH,[Order].Soluong20OT,[Order].Soluong40OT,[Order].Soluong20FR,[Order].Soluong40FR,[Order].UserId,[Order].Updatetime "
            strQuery &= " From (([Order] inner join containeroutboundnotify on [Order].BookingNO=containeroutboundnotify.BookingNo) inner join sailingschedule on containeroutboundnotify.sailingscheduleid= sailingschedule.sailingscheduleid)inner join vessel on sailingschedule.vessel_id=vessel.vessel_id "
            strQuery &= " where [Order].Continued=1 " & mFilter
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdOrder.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdOrder)
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdOrder.RowCount - 1
                For s = 0 To Me.dgdOrder.ColumnCount - 1
                    If Me.dgdOrder.Item(s, t).Value.ToString = "0" Then
                        Me.dgdOrder.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub mnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearch.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryOrder()
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub Setmenu(ByVal Value)
        Me.MenuStrip1.Enabled = Value
        Me.dgdOrder.Enabled = Value
    End Sub
    Private Sub mnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportExcel.Click
        Try
            If Me.dgdOrder.Rows.Count > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdOrder, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub frmBookingSupplyOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDefaultGrid(Me.dgdOrder, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub cmdfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfind.Click
        Try
            If Me.txtbookingno.Text = "" Then
                Return
            End If
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strQuery As String
            strQuery = " select [Order].BookingNo,[Order].OrderNo,[Order].OrderDate,[Order].DaiDien,[Order].SupplyDepot,[Order].CMND,[Order].Remarks,[Order].Soluong20GP,[Order].Soluong40GP,[Order].Soluong20RF,[Order].Soluong40RF,[Order].Soluong40HC,[Order].Soluong45HC,[Order].Soluong40RH,[Order].Soluong20OT,[Order].Soluong40OT,[Order].Soluong20FR,[Order].Soluong40FR,[Order].UserId,[Order].Updatetime "
            strQuery &= " From (([Order] inner join containeroutboundnotify on [Order].BookingNO=containeroutboundnotify.BookingNo) inner join sailingschedule on containeroutboundnotify.sailingscheduleid= sailingschedule.sailingscheduleid)inner join vessel on sailingschedule.vessel_id=vessel.vessel_id "
            strQuery &= " where [Order].Continued=1  and [Order].BookingNo like '%" & Me.txtbookingno.Text.Trim & "%'"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdOrder.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdOrder)
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdOrder.RowCount - 1
                For s = 0 To Me.dgdOrder.ColumnCount - 1
                    If Me.dgdOrder.Item(s, t).Value.ToString = "0" Then
                        Me.dgdOrder.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
End Class