Public Class CheckStatusHistoryBeforeReport
    Dim mFilter As String
    Sub QueryContainer()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strQuery As String
            strQuery = " select Container_no,Arrival_Date,FactOfDelDate,FactOfReDelDate,DateOfEmptyContainerToShipper,DateOfFullLoadContainerToCY, DateOfOnBoard,Vessel_Outbound, VoyNo_Outbound,BL_NO_Outbound "
            strQuery &= " , USERUPDATE,UPDATETIME From containermanagerment "
            strQuery &= " where Continued=1 and (Arrival_Date='' or FactOfDelDate='' or  FactOfReDelDate='' or DateOfEmptyContainerToShipper='' or DateOfFullLoadContainerToCY='' or DateOfOnBoard='' ) " & mFilter
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdContainer.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdContainer)
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdContainer.RowCount - 1
                For s = 0 To Me.dgdContainer.ColumnCount - 1
                    If Me.dgdContainer.Item(s, t).Value.ToString = "0" Then
                        Me.dgdContainer.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next

            For t = 0 To Me.dgdContainer.RowCount - 1

                If Me.dgdContainer.Item(1, t).Value.ToString = "" Or Me.dgdContainer.Item(2, t).Value.ToString = "" Or Me.dgdContainer.Item(3, t).Value.ToString = "" Or Me.dgdContainer.Item(4, t).Value.ToString = "" Or Me.dgdContainer.Item(5, t).Value.ToString = "" Or Me.dgdContainer.Item(6, t).Value.ToString = "" Then
                    Me.dgdContainer.Rows(t).DefaultCellStyle.ForeColor = Color.Red
                End If

            Next
            '---luoi thu hai
            strQuery = " select Container_no,Arrival_Date,FactOfDelDate,FactOfReDelDate,DateOfEmptyContainerToShipper,DateOfFullLoadContainerToCY, DateOfOnBoard,Vessel_Outbound, VoyNo_Outbound,BL_NO_Outbound "
            strQuery &= "  , USERUPDATE,UPDATETIME From containermanagerment "
            strQuery &= " where Continued=1 and Arrival_Date<>'' and  FactOfDelDate<>'' and  FactOfReDelDate<>'' and DateOfEmptyContainerToShipper<>'' and DateOfFullLoadContainerToCY<>'' and DateOfOnBoard<>'' " & mFilter
            Dim cmd1 As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter1 As New SqlClient.SqlDataAdapter(cmd1)
            Dim dt1 As New DataTable
            Adapter1.Fill(dt1)
            Me.dgdcontainer1.DataSource = dt1
            InsertAutoNumberToGrid(Me.dgdcontainer1)
            '---- so 0 thanh mau trang

            For t = 0 To Me.dgdcontainer1.RowCount - 1
                For s = 0 To Me.dgdcontainer1.ColumnCount - 1
                    If Me.dgdcontainer1.Item(s, t).Value.ToString = "0" Then
                        Me.dgdcontainer1.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next

            For t = 0 To Me.dgdcontainer1.RowCount - 1

                If Me.dgdcontainer1.Item(1, t).Value.ToString = "" Or Me.dgdcontainer1.Item(2, t).Value.ToString = "" Or Me.dgdcontainer1.Item(3, t).Value.ToString = "" Or Me.dgdcontainer1.Item(4, t).Value.ToString = "" Or Me.dgdcontainer1.Item(5, t).Value.ToString = "" Or Me.dgdcontainer1.Item(6, t).Value.ToString = "" Then
                    Me.dgdcontainer1.Rows(t).DefaultCellStyle.ForeColor = Color.Red
                End If

            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub CheckStatusHistoryBeforeReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetDefaultGrid(Me.dgdContainer, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
        SetDefaultGrid(Me.dgdcontainer1, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub

    Private Sub mnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSearch.Click
        Try
            gNameForm = frmContainerManagerMent.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainer()
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub mnuExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuExportExcel.Click
        Try
            If Me.dgdContainer.Rows.Count > 0 Then
                SetMenu(False)
                ExportExecel(Me.dgdContainer, Me)
                SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
    Sub Setmenu(ByVal Value)
        Me.MenuStrip1.Enabled = Value
        Me.dgdContainer.Enabled = Value
    End Sub

    Private Sub cmdfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdfind.Click
        Try
            If Me.txtContainerno.Text = "" Then
                Return
            End If

            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Dim strQuery As String
            strQuery = " select Container_no,Arrival_Date,FactOfDelDate,FactOfReDelDate,DateOfEmptyContainerToShipper,DateOfFullLoadContainerToCY, DateOfOnBoard,Vessel_Outbound, VoyNo_Outbound,BL_NO_Outbound "
            strQuery &= "  , USERUPDATE,UPDATETIME From containermanagerment "
            strQuery &= " where Continued=1 AND Container_no like '%" & Me.txtContainerno.Text & "%'"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.dgdContainer.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdContainer)
            '---- so 0 thanh mau trang
            Dim t, s As Integer
            For t = 0 To Me.dgdContainer.RowCount - 1
                For s = 0 To Me.dgdContainer.ColumnCount - 1
                    If Me.dgdContainer.Item(s, t).Value.ToString = "0" Then
                        Me.dgdContainer.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
            For t = 0 To Me.dgdContainer.RowCount - 1

                If Me.dgdContainer.Item(1, t).Value.ToString = "" Or Me.dgdContainer.Item(2, t).Value.ToString = "" Or Me.dgdContainer.Item(3, t).Value.ToString = "" Or Me.dgdContainer.Item(4, t).Value.ToString = "" Or Me.dgdContainer.Item(5, t).Value.ToString = "" Or Me.dgdContainer.Item(6, t).Value.ToString = "" Then
                    Me.dgdContainer.Rows(t).DefaultCellStyle.ForeColor = Color.Red
                End If

            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContainer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainer.CellContentClick

    End Sub

    Private Sub dgdContainer_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContainer.ColumnHeaderMouseClick
        Dim t As Integer
        For t = 0 To Me.dgdContainer.RowCount - 1
            If Me.dgdContainer.Item(1, t).Value.ToString = "" Or Me.dgdContainer.Item(2, t).Value.ToString = "" Or Me.dgdContainer.Item(3, t).Value.ToString = "" Or Me.dgdContainer.Item(4, t).Value.ToString = "" Or Me.dgdContainer.Item(5, t).Value.ToString = "" Or Me.dgdContainer.Item(6, t).Value.ToString = "" Then
                Me.dgdContainer.Rows(t).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        InsertAutoNumberToGrid(Me.dgdContainer)
    End Sub

    Private Sub ExportExcel2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcel2ToolStripMenuItem.Click
        Try
            If Me.dgdcontainer1.Rows.Count > 0 Then
                Setmenu(False)
                ExportExecel(Me.dgdcontainer1, Me)
                Setmenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub dgdcontainer1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdcontainer1.CellContentClick

    End Sub

    Private Sub dgdcontainer1_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdcontainer1.ColumnHeaderMouseClick
        Dim t As Integer
        For t = 0 To Me.dgdcontainer1.RowCount - 1
            If Me.dgdcontainer1.Item(1, t).Value.ToString = "" Or Me.dgdcontainer1.Item(2, t).Value.ToString = "" Or Me.dgdcontainer1.Item(3, t).Value.ToString = "" Or Me.dgdcontainer1.Item(4, t).Value.ToString = "" Or Me.dgdcontainer1.Item(5, t).Value.ToString = "" Or Me.dgdcontainer1.Item(6, t).Value.ToString = "" Then
                Me.dgdcontainer1.Rows(t).DefaultCellStyle.ForeColor = Color.Red
            End If
        Next
        InsertAutoNumberToGrid(Me.dgdcontainer1)
    End Sub
End Class