Public Class frmDemDetInventory
    Dim mFilter As String
    Private Sub frmDemDetInventory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        mFilter = ""
        SetDefaultGrid(Me.dgdContainerMNG, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)
    End Sub
    Sub QueryData(Optional ByVal Filter As String = "")
        Try
            Dim SQL As String
            Dim t, s As Integer
            SQL = " select BL_NO_Inbound,ContainerManagerment.Container_No,CTN_SIZE_TYPE,DemDays as DemReduce,DetDays as DetReduce, "
            SQL &= " datediff(day,Convert(DateTime,Arrival_Date),Convert(DateTime,FactOfDelDate)) as [DemInfact], "
            SQL &= " datediff(day,Convert(DateTime,Arrival_Date),Convert(DateTime,CorrectionOfDELDate)) as [DemCorrect], "
            SQL &= " datediff(day,Convert(DateTime,FactOfDelDate),Convert(DateTime,FactOfReDelDate)) as [DetInfact], "
            SQL &= " datediff(day,Convert(DateTime,FactOfDelDate),Convert(DateTime,CorrectionOfReDELDate)) as [DetCorrect], arrival_date as ETA, FactOfDelDate as [Delivery date], FactOfReDelDate as [Redelivery date] "
            SQL &= " from (ContainerManagerment LEFT JOIN DemDetReduce On ContainerManagerment.BL_NO_Inbound=DemDetReduce.BLIB_NO And ContainerManagerment.Container_No=DemDetReduce.Container_No)"
            'SQL &= " Where ContainerManagerment.Continued=1 And (BL_NO_OUTBOUND Is Null or BL_NO_OUTBOUND='') AND (DateofOnboard is NULL Or DateofOnboard='') "
            SQL &= " Where ContainerManagerment.Continued=1 "
            SQL &= "   " & Filter

            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdContainerMNG.DataSource = dt
            InsertAutoNumberToGrid(Me.dgdContainerMNG)
            For t = 0 To Me.dgdContainerMNG.RowCount - 1
                For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                    If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                        Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                    End If
                Next
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub smnuSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smnuSearch.Click
        Try
            Dim strQuery As String
            gNameForm = frmContainerManagerMent.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilter = frmFilter.strQuery
                QueryData("  " & mFilter)
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
        QueryData(mFilter)
    End Sub

    Private Sub dgdContainerMNG_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgdContainerMNG.Click
        Dim t, s As Integer
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub

    Private Sub dgdContainerMNG_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdContainerMNG.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
    End Sub

    Private Sub dgdContainerMNG_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdContainerMNG.CellContentClick
        Dim t, s As Integer
        InsertAutoNumberToGrid(Me.dgdContainerMNG)
        For t = 0 To Me.dgdContainerMNG.RowCount - 1
            For s = 0 To Me.dgdContainerMNG.ColumnCount - 1
                If Me.dgdContainerMNG.Item(s, t).Value.ToString = "0" Or Me.dgdContainerMNG.Item(s, t).Value.ToString Like "-*" Then
                    Me.dgdContainerMNG.Item(s, t).Style.ForeColor = mcbkColor
                End If
            Next
        Next
    End Sub
End Class