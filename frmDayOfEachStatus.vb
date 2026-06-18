Public Class frmDayOfEachStatus

    Dim mFilter As String
    Dim TempFilter As String
    Public oTableContainerMNG As New DataTable

    Private Sub QueryContainerMNG(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed


        Dim strContainerMNGSelect As String = "" & _
        " Select containermanagerment.BL_NO_Inbound,containermanagerment.Container_No,CTN_SIZE_TYPE," & _
        " datediff(day,Convert(DateTime,Arrival_Date),Convert(DateTime,FactOfDelDate)) as FullStorage," & _
        " datediff(day,Convert(DateTime,FactOfDelDate),Convert(DateTime,FactOfReDelDate)) as DET," & _
        " datediff(day,Convert(DateTime,FactOfReDelDate),Convert(DateTime,DateOfEmptyContainerToShipper)) as EmptyStorage," & _
        " datediff(day,Convert(DateTime,DateOfEmptyContainerToShipper),Convert(DateTime,DateOfFullLoadContainerToCY)) as DETFull," & _
        " datediff(day,Convert(DateTime,DateOfFullLoadContainerToCY),Convert(DateTime,DateOfOnBoard)) as WaitForOnboard" & _
        " from ContainerManagerment where containermanagerment.continued=1 "

        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = strContainerMNGSelect
        Else
            strQuery = strContainerMNGSelect & argCriteria '& strContainerMNGSelectC
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableContainerMNG) Then
            oTableContainerMNG.Clear()
        End If
        Adapter.Fill(ds, "ContainerMNG")
        oTableContainerMNG = ds.Tables(0)
        Me.dgdContainerMNG.DataSource = ds.Tables("ContainerMNG")
        If Me.dgdContainerMNG.Enabled = False Then
            Me.dgdContainerMNG.Enabled = True
        End If


        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableContainerMNG.Rows.Count > 0 Then
            Me.dgdContainerMNG.Columns.Item("BLIB_NO").ToolTipText = "Hiện có:" + CStr(Me.dgdContainerMNG.RowCount()) + " Containers."

        End If
        '------------vị trí BM
        'If Me.oTableContainerMNG.Rows.Count > 0 Then
        '    location = Me.dgdContainerMNG.CurrentRow.Index
        'End If
        'If location >= 0 And location <= Me.dgdContainerMNG.Rows.Count And Me.dgdContainerMNG.Rows.Count > 0 Then
        '    Me.dgdContainerMNG.Rows(location).Selected = True
        '    Me.dgdContainerMNG.CurrentCell = Me.dgdContainerMNG.Rows(location).Cells(7)
        'End If
        '--------------------
        ' Me.UpdateFrame()
        '------stt tren luoi
        'InsertAutoNumberToGrid(Me.dgdContainerMNG)
        For i As Integer = 0 To Me.dgdContainerMNG.Columns.Count - 1
            If UCase(Me.dgdContainerMNG.Columns(i).Name) Like "*ID" Or UCase(Me.dgdContainerMNG.Columns(i).Name) Like "*1" Then
                Me.dgdContainerMNG.Columns(i).Visible = False
            End If
        Next
        '--------------------
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Private Sub frmDayOfEachStatus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mFilter = ""
        'TempFilter = " And (BL_NO_OUTBOUND Is Null or BL_NO_OUTBOUND='') AND (DateofOnboard is NULL Or DateofOnboard='') "
        SetDefaultGrid(Me.dgdContainerMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub
    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = frmContainerManagerMent.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryContainerMNG("  " & mFilter)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub ExportExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportExcelToolStripMenuItem.Click
        Try
            ExportExecel(Me.dgdContainerMNG, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    'Private Sub chkContainerInVN_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.chkContainerInVN.Checked = True Then
    '        TempFilter = " And (BL_NO_OUTBOUND Is Null or BL_NO_OUTBOUND='') AND (DateofOnboard is NULL Or DateofOnboard='') "
    '    End If
    'End Sub

    'Private Sub chkContainerOnboard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.chkContainerOnboard.Checked = True Then
    '        TempFilter = " And (BL_NO_OUTBOUND Is not Null and BL_NO_OUTBOUND<>'') AND (DateofOnboard is not  NULL and  DateofOnboard<>'') "
    '    End If
    'End Sub

    'Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.chkAll.Checked = True Then
    '        TempFilter = ""
    '    End If
    'End Sub


    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgdContainerMNG, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContainerMNG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainerMNG.CellContentClick
        '--------------------
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub dgdContainerMNG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdContainerMNG.Click
        '--------------------
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        '---- so 0 thanh mau trang
        Dim t, s As Integer
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub
End Class