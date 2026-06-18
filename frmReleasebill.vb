Public Class frmReleasebill
    Dim mReleaseFilter As String = " And FreightNotePrintedOutBound.Release=0 "
    Dim mFilter As String = ""
    Private Sub frmReleasebill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryReleaseBill(mReleaseFilter)
    End Sub
    Sub QueryReleaseBill(Optional ByVal arg As String = "")
        Try
            Dim SQL As String 'chỉ hiện thị những bill đã in freightnote mà chưa release
            SQL = "Select BillOfLading.BL_NO,BillOfLading.PORT_OF_LOADING_CODE as POL,BillOfLading.PORT_OF_DISCHARGE_CODE as POD "
            SQL &= " From(( "
            SQL &= "  BillOflading left join ContainerOutboundNotify On BillOflading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
            SQL &= " Where BillOfLading.TELEX='T'  " & arg
            SQL &= " Order by BillOfLading.BL_NO "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdReleaseBillData.DataSource = dt

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Function UpdateBL_Type(ByVal index As Integer) As Integer
        Try
            Dim SQL As String
            SQL = "Update BillOfLading "
            If Me.dgdReleaseBillData.Item("Release", index).Value = 0 Then
                SQL &= " Set BL_Type='" & Me.dgdReleaseBillData.Item("BL_Type", index).Value & "'"
            Else
                SQL &= " Set BL_Type='T' "
            End If
            SQL &= " Where bl_id='" & Me.dgdReleaseBillData.Item("BL_IDReleaseBill", index).Value.ToString & "' And Continued=1"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL

            Dim i As Integer = cmd.ExecuteNonQuery()
            Return i
        Catch ex As Exception
            DisplayMessage(False, Err.Description)
        End Try
    End Function
    Function UpdateRelease(ByVal index As Integer) As Integer
        Try
            Dim SQL As String
            'Me.dgdReleaseBillData.Item("Release", index).Value = Not Me.dgdReleaseBillData.Item("Release", index).Value
            Me.dgdReleaseBillData.Item("Release", index).Value = IIf(Me.dgdReleaseBillData.Item("Release", index).Value = 0, 1, 0)
            SQL = "Update FreightNotePrintedOutBound "
            SQL &= " Set Release=" & Me.dgdReleaseBillData.Item("Release", index).Value
            SQL &= " Where BillReleaseID='" & Me.dgdReleaseBillData.Item("BillReleaseID", index).Value.ToString & "' And Continued=1"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = SQL
            Dim i As Integer = cmd.ExecuteNonQuery()
            Return i
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function
    Private Sub dgdReleaseBillData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdReleaseBillData.CellContentClick
        On Error GoTo Err_Renamed
        Dim ColIndex, RowIndex As Integer
        ' Xác định vị trí row trong grid
        If Me.dgdReleaseBillData.RowCount = 0 Then
            Return
        End If
        If IsNothing(Me.dgdReleaseBillData.CurrentRow) Then
            Return
        End If
        Dim index As Integer = Me.dgdReleaseBillData.CurrentRow.Index
        ColIndex = e.ColumnIndex()
        RowIndex = e.RowIndex
        If ColIndex < 0 Then
            Return
        End If
        If Me.dgdReleaseBillData.Columns(ColIndex).Name = "Release" And Me.dgdReleaseBillData.CurrentCellAddress().Y = index Then
            UpdateRelease(index)
            UpdateBL_Type(index)
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub cmdCloseReleaseBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCloseReleaseBill.Click
        Me.Close()
    End Sub

    Private Sub cmdRefreshRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefreshRelease.Click
        QueryReleaseBill("  " & mFilter)
    End Sub

    Private Sub cmdNotRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNotRelease.Click
        mReleaseFilter = "  And FreightNotePrintedOutBound.Release=0 "
        QueryReleaseBill(mReleaseFilter)
    End Sub

    Private Sub cmdRelease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRelease.Click
        mReleaseFilter = "  And FreightNotePrintedOutBound.Release=1 "
        QueryReleaseBill(mReleaseFilter)
    End Sub

    Private Sub cmdAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAll.Click
        mReleaseFilter = " "
        QueryReleaseBill(mReleaseFilter)
    End Sub

    Private Sub cmdSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearch.Click
        Try
            Dim strQuery As String
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryReleaseBill("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class