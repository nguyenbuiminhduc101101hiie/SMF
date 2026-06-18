Public Class frmExportExcelDEMDET

    Dim oTableDemData As New DataTable
    Dim oTableDetData As New DataTable
    Dim ArrExcel(,) As String
    Dim path As String
    Dim strSQL As String
    Sub QueryDemData()
        Try
            strSQL = "select * from DemData Where UpdateTime>'" & Date.FromOADate(Me.dtpFromDate.Value.Date.ToOADate - 1) & "' And UpdateTime<'" & Me.dtpToDate.Value.Date.AddDays(1) & "' And Continued=1 Order By UpdateTime"
            oTableDemData = ReadTable(strSQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryDetData()
        Try
            strSQL = "select * from DetData Where UpdateTime>'" & Date.FromOADate(Me.dtpFromDate.Value.Date.ToOADate - 1) & "' And UpdateTime<'" & Me.dtpToDate.Value.Date.AddDays(1) & "' And Continued=1 Order By UpdateTime"
            oTableDetData = ReadTable(strSQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function QueryBillInfo(ByVal BLNo As String) As DataTable
        Try
            strSQL = "Select Vessel,VoyAge,ETA From BillOfLAdingIb Where BLIB_NO='" & BLNo & "'"
            Return ReadTable(strSQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            Return Nothing
        End Try
    End Function
    Sub ExPortExcel()
        Dim App As Excel.Application
        Try
            App = New Excel.Application
            App.Visible = True
            Dim file As String
            file = StartupPath & "\demurrage"

            Dim workbooks As Excel.Workbooks
            workbooks = App.Workbooks
            Dim workbook As Excel.Workbook
            workbook = workbooks.Open(file)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            Dim CountRow As Integer = oTableDemData.Rows.Count + oTableDetData.Rows.Count + 1
            ReDim ArrExcel(CountRow, 11)

            For i As Integer = 0 To oTableDemData.Rows.Count - 1
                Dim dt As New DataTable
                dt = QueryBillInfo(oTableDemData.Rows(i).Item("BLIB_NO").ToString.Trim)
                ArrExcel(i, 0) = i + 1
                ArrExcel(i, 1) = dt.Rows(0).Item("Vessel").ToString & " - " & dt.Rows(0).Item("VoyAge").ToString
                ArrExcel(i, 2) = CDate(dt.Rows(0).Item("ETA").ToString)
                ArrExcel(i, 3) = oTableDemData.Rows(i).Item("BLIB_NO").ToString
                ArrExcel(i, 4) = CDate(oTableDemData.Rows(i).Item("FromDate").ToString)
                ArrExcel(i, 5) = CDate(oTableDemData.Rows(i).Item("Todate").ToString)
                ArrExcel(i, 6) = (oTableDemData.Rows(i).Item("NumberOfDay").ToString)
                ArrExcel(i, 7) = oTableDemData.Rows(i).Item("NumberOfContainer").ToString
                ArrExcel(i, 8) = oTableDemData.Rows(i).Item("Container_Type").ToString
                ArrExcel(i, 9) = oTableDemData.Rows(i).Item("price").ToString
            Next
            Dim CountDem As Integer = oTableDemData.Rows.Count

            For i As Integer = 0 To oTableDetData.Rows.Count - 1
                Dim dt As New DataTable
                dt = QueryBillInfo(oTableDetData.Rows(i).Item("BLIB_NO").ToString.Trim)
                ArrExcel(CountDem + i, 0) = CountDem + i + 1
                ArrExcel(CountDem + i, 1) = dt.Rows(0).Item("Vessel").ToString & " - " & dt.Rows(0).Item("VoyAge").ToString
                ArrExcel(CountDem + i, 2) = CDate(dt.Rows(0).Item("ETA").ToString)
                ArrExcel(CountDem + i, 3) = oTableDetData.Rows(i).Item("BLIB_NO").ToString
                ArrExcel(CountDem + i, 4) = CDate(oTableDetData.Rows(i).Item("FromDate").ToString)
                ArrExcel(CountDem + i, 5) = CDate(oTableDetData.Rows(i).Item("Todate").ToString)
                ArrExcel(CountDem + i, 6) = (oTableDetData.Rows(i).Item("NumberOfDay").ToString)
                ArrExcel(CountDem + i, 7) = oTableDetData.Rows(i).Item("NumberOfContainer").ToString
                ArrExcel(CountDem + i, 8) = oTableDetData.Rows(i).Item("Container_type").ToString
                ArrExcel(CountDem + i, 9) = oTableDetData.Rows(i).Item("price").ToString
                ArrExcel(CountDem + i, 10) = oTableDetData.Rows(i).Item("kind").ToString
            Next
            ws.Range("A5", "L" & CountRow + 5).Value2 = ArrExcel

           
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            App.Quit()
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryDemData()
        QueryDetData()
        If Me.SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            path = Me.SaveFileDialog1.FileName
        Else
            path = "c:\Demurrage " & Now
        End If
        ExPortExcel()
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class