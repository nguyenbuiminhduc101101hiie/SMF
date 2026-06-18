Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmBookingCancel
    Dim mFilter As String = ""
    'Sub reformat()
    '    Try
    '        Me.CrystalReportViewer1.Height = Me.Height - Me.fraChosse.Height - 50
    '        Me.fraChosse.Width = Me.Width - 20
    '        Me.CrystalReportViewer1.Dock = DockStyle.Bottom
    '        'Me.cmdOk.Left = Me.fraChosse.Width - Me.cmdOk.Width - 30
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '    End Try
    'End Sub
    'Private Sub chkCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.txtCustomer.Enabled = Me.chkCustomer.Checked
    'End Sub

    Private Sub frmBookingCancel_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        'reformat()
    End Sub
    Sub QueryBookingCancel(Optional ByVal Filter As String = "")
        Try

            Dim strQuery As String
            'strQuery = "Select ContainerOutBoundNotify.ContainerOutBoundNotifyID,ContainerOutBoundNotify.BookingNo,convert(nvarChar,SoLuong20GP)as SoLuong20GP ,convert(nvarChar,SoLuong40GP)as SoLuong40GP,convert(nvarChar,SoLuong40hc)as SoLuong40HC,convert(nvarChar,SoLuong45hc)as SoLuong45HC,convert(nvarChar,SoLuong20rf)as SoLuong20RF,convert(nvarChar,SoLuong40rf)as SoLuong40RF,convert(nvarChar,SoLuong40rh)as SoLuong40RH,"
            'strQuery &= " BookingPerson,BookingDate,Customer_Code,COMPANY,Customer.Address,BookingCancelLog.Customer CancelPerson,BookingCancelLog.dateCancel [Cancel date]"
            'strQuery &= " From (ContainerOutboundNotify INNER  JOIN  Customer On Customer.Customer_ID = ContainerOutboundNotify.Customer_ID) "
            'strQuery &= " Where ContainerOutboundNotify.Continued=0 " & IIf(Me.chkCustomer.Checked = True, " And COMPANY Like '%" & Me.txtCustomer.Text.Trim & "%'", " And BookingDate>'" & Me.dtpFromBookingDate.Value & "' And BookingDate <'" & Me.dtpToBookingDate.Value & "'")
            strQuery = strQuery + " select * From ContainerOutBoundNotify LEFT JOIN BookingCancelLog On BookingCancelLog.BookingNo=ContainerOutBoundNotify.BooKingNo " 'left JOIN Customer on ContainerOutBoundNotify.Customer_ID=Customer.Customer_ID)"
            ' strQuery = strQuery + " ) "
            'strQuery = strQuery + ") " & _
            '                      " left JOIN Market mak on mak.MarKet_ID = ContainerOutBoundNotify.Market_ID) " & _
            '                      " left JOIN Sale on Sale.Sale_ID = ContainerOutBoundNotify.Sale_ID )" & _
            '                      " ) " & _
            '                      " ) " & _
            '    " LEFT JOIN BookingCancelLog On BookingCancelLog.BookingNo=ContainerOutBoundNotify.BooKingNo) "

            strQuery = strQuery + " WHERE CONTAINEROUTBOUNDNOTIFY.Continued = 0 and wait=0 "
            strQuery &= " " & Filter

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            If dt.Rows.Count <= 0 Then
                MsgBox("No data")
            End If
            Me.dgdData.DataSource = dt
            For i As Integer = 0 To Me.dgdData.ColumnCount - 1 'ẩn các cột nào là ID
                If UCase(Me.dgdData.Columns(i).Name.Trim) Like "*ID" Then
                    Me.dgdData.Columns(i).Visible = False
                End If
            Next

            InsertAutoNumberToGrid(Me.dgdData)
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdData.RowCount - 1
                For s = 0 To Me.dgdData.ColumnCount - 1
                    If Me.dgdData.Item(s, t).Value.ToString = "0" Then
                        Me.dgdData.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
  

    Private Sub frmBookingCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetDefaultGrid(Me.dgdData, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub SearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Try
            gNameForm = frmContainerOutBoundNotify.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery

                QueryBookingCancel(" " & mFilter)

            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            If Me.dgdData.Rows.Count > 0 Then
                ExportExecel(Me.dgdData, Me)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            Dim dt As New DataTable
            Dim FilterArg As String
            FilterArg = " And BookingCancelLog.Customer like'%" & Me.txtCanCelPerson.Text.Trim & "%' "
            FilterArg &= " And convert(dateTime,BookingCancelLog.dateCancel)+1>'" & Me.dtpCancelDateFrom.Value.Date & "' and  convert(dateTime,BookingCancelLog.dateCancel)-1<'" & Me.dtpCancelDateTo.Value.Date & "' "
            QueryBookingCancel(" " & FilterArg)

            'Dim type() As String = {"SoLuong20GP", "SoLuong40GP", "SoLuong20RF", "SoLuong40RF", "SoLuong40HC", "SoLuong45HC", "SoLuong40RH"}
            'For i As Integer = 0 To dt.Rows.Count - 1
            '    For j As Integer = 0 To type.Length - 1
            '        If dt.Rows(i).Item(type(j)) = 0 Then
            '            dt.Rows(i).Item(type(j)) = ""
            '        End If
            '    Next
            'Next
            'Dim rpt As New 
            '-------------
            'Dim rpt As New ReportDocument
            'Dim strReportName As String
            ''Dim strQuery As String
            '' ten Report
            'strReportName = "ReportBookingCancel"
            'Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            'If Not IO.File.Exists(strReportPath) Then
            '    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            '    Exit Sub
            'End If
            'rpt.Load(strReportPath)
            ''--------------
            'rpt.SetDataSource(dt)
            'Me.CrystalReportViewer1.ReportSource = rpt
            'Me.CrystalReportViewer1.Refresh()
            'Me.CrystalReportViewer1.Show()
           
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub PreViewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreViewToolStripMenuItem.Click
        On Error GoTo Err
        Dim index As Integer
        If Me.dgdData.Rows.Count > 0 Then
            index = Me.dgdData.CurrentRow.Index
        Else
            Exit Sub
        End If
        gBookingID = Me.dgdData.Item("ContainerOutBoundNotifyId", index).Value.ToString
        VB6.ShowForm(frmRptSupplyEmptyContainer, VB6.FormShowConstants.Modeless, Me)
        Exit Sub
Err:
    End Sub

    Private Sub dgdData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdData.CellContentClick

    End Sub

    Private Sub dgdData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdData.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdData)
    End Sub
End Class