Public Class frmStorageSoundCOntainerFee
    Dim mFilter As String
    Dim TempFilter As String
    Public oTableContainerMNG As New DataTable
    Public oTableTerminal As New DataTable

    Private Sub QueryContainerMNG(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 14, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed


        Dim strContainerMNGSelect As String = "" & _
        " Select containermanagerment.BL_NO_Inbound,containermanagerment.Container_No,CTN_SIZE_TYPE,EmptyCY,Terminal.FreeStorage, " & _
        " datediff(day,Convert(DateTime,FactOfReDelDate),Convert(DateTime,DateOfEmptyContainerToShipper)) as EmptyStorage " & _
        ", datediff(day,Convert(DateTime,FactOfReDelDate),Convert(DateTime,DateOfEmptyContainerToShipper)) - FreeStorage as FinalStorage " & _
        " from ContainerManagerment,Terminal" & _
        " where containermanagerment.continued=1 And ContainerManagerment.EmptyCY=Terminal.TerminalName " & TempFilter
        Dim i As Integer
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
        
        oTableContainerMNG = ReadTable(strQuery)
        Me.dgdContainerMNG.DataSource = oTableContainerMNG

        Me.Cursor = System.Windows.Forms.Cursors.Default
        If oTableContainerMNG.Rows.Count > 0 Then
            Me.dgdContainerMNG.Columns.Item("BLIB_NO").ToolTipText = "Hiện có:" + CStr(Me.dgdContainerMNG.RowCount()) + " Containers."

        End If
       
        '------stt tren luoi
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        For i = 0 To Me.dgdContainerMNG.Columns.Count - 1
            If UCase(Me.dgdContainerMNG.Columns(i).Name) Like "*ID" Or UCase(Me.dgdContainerMNG.Columns(i).Name) Like "*1" Then
                Me.dgdContainerMNG.Columns(i).Visible = False
            End If
        Next
        'InsertAutoNumberToGrid(Me.dgdContainerMNG)
        '---- so 0 thanh mau trang
        i = 0
        Dim t, s As Integer
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Value = i
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = Color.White
                End If
            Next
        Next
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub QueryTerMinal()
        Try
            Dim SQL As String
            SQL = "Select * from Terminal Where Continued=1"
            oTableTerminal = ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmStorageSoundCOntainerFee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmdRefresh.Visible = False
        mFilter = ""
        'TempFilter = " And (BL_NO_OUTBOUND Is Null or BL_NO_OUTBOUND='') AND (DateofOnboard is NULL Or DateofOnboard='') "
        QueryTerMinal()
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

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        QueryContainerMNG()
    End Sub

    Private Sub dgdContainerMNG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainerMNG.CellContentClick
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        Dim t, s As Integer
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 4 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = Color.White
                End If
            Next
        Next
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        Try
            ExportExecel(Me.dgdContainerMNG, Me)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdContainerMNG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdContainerMNG.Click
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        Dim t, s As Integer
        Dim i As Integer
        'For t = 0 To Me.dgdContainerMNG.RowCount - 1
        '    For s = 0 To 3
        '        If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
        '            Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor

        '        End If
        '    Next
        'Next
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Value = i
                End If
            Next
        Next
    End Sub
End Class