Public Class frmLoadingFormForShangHai
    Dim oTable As New DataTable
    Dim Path As String
    Dim SQL As String
    Sub QueryVessel()
        Try
            SQL = "Select SailingScheduleID as ID ,Vessel + ' - ' + voyNo as value "
            SQL &= " From SailingSchedule,vessel where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 Order By Vessel "
            Dim oTableVessel As New DataTable
            oTableVessel = ReadTable(SQL)
            Me.cboVessel.DisplayMember = "Value"
            Me.cboVessel.ValueMember = "ID"
            Me.cboVessel.DataSource = oTableVessel
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub dtpLeavingDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpLeavingDate.ValueChanged
        Try
            Dim strSQL As String
            strSQL = "Select SailingScheduleID as ID,Vessel + ' - ' + voyNo as value "
            strSQL &= " From SailingSchedule,vessel "
            strSQL &= "where SailingSchedule.Vessel_ID=Vessel.Vessel_ID and  SailingSchedule.Continued=1 And ETD='" & Me.dtpLeavingDate.Value.Date & "'"
            strSQL &= "Order By Vessel "
            Dim dt As New DataTable
            dt = ReadTable(strSQL)
            If dt.Rows.Count > 0 Then
                Me.cboVessel.Text = dt.Rows(0).Item("Value").ToString.Trim
            Else
                MsgBox("there is No SailingSchedule For The ETD :" & Me.dtpLeavingDate.Value.Date)
                Return
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryData(ByVal sailingID As String)
        Try
            SQL = "Select BL_NO,Container_No,CTN_STATUS,CTN_SIZE_TYPE as Type,case SOC when 1 then 'SOC' else 'COC' End as COCSOC,AMOUNT as GrossWeight,SealNo as SealNo,"
            SQL &= " ETD,Slot,Operator as OPR,Right(PORT_OF_LOADING_CODE,3) as POL,Right(Tranship,5) as TranShip,PORT_OF_DISCHARGE_CODE as POD ,PLACE_OF_DESTINATION_CODE as DEST,Cold"
            SQL &= " From (((((BillOfLading LEFT JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
            SQL &= " LEFT JOIN Cargo On Cargo.BL_ID=BillOfLading.BL_ID)"
            SQL &= " LEFT JOIN Container On Cargo.CTN_ID=Container.CTN_ID)"
            SQL &= " LEFT JOIN SEAL On seal.SEAL_ID=Cargo.SEAL_ID)"
            SQL &= " LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
            SQL &= " Where BillOfLading.Continued=1 And ContainerOutboundNotify.SailingScheduleID='" & sailingID & "' And Cargo.Continued=1"
            oTable = ReadTable(SQL)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub frmLoadingFormForShangHai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVessel()
    End Sub

    Sub SetExcelValue()
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG"}
            Dim ColName() As String = {"", "BL_NO", "Container_No", "CTN_STATUS", "Type", "COCSOC", "GrossWeight", "OPR", "POL", "TranShip", "POD", "DEST"}
            app = New Excel.Application()


            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Path = StartupPath & "\LoadingFormForShangHai.xls"

            workbook = workbooks.Open(path)
            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim CountRow As Integer = Otable.Rows.Count
            Dim CountCol As Integer = Otable.Columns.Count
            'Dim arr(CountRow + 1, CountCol + 1) As String
            If oTable.Rows.Count > 0 Then
                ws.Range("B11").Value2 = oTable.Rows(0).Item("Slot").ToString
                ws.Range("B8").Value2 = Me.cboVessel.Text
                ws.Range("B9").Value2 = oTable.Rows(0).Item("ETD").ToString
            End If

            If CountRow = 0 Then
                MsgBox("No data")
                Return
            End If
            Dim CurRow As Integer = 13
            For R As Integer = 0 To CountRow - 1
                'arr(R, 0) = R + 1
                ws.Range(Alpha(0) & CurRow).Value2 = R + 1
                For C As Integer = 0 To ColName.Length - 2 'bỏ đi ba cột không rõ dữ liệu {return Place,Date Và remarks}
                    'arr(R, C + 1) = oTable.Rows(R).Item(C).ToString
                    ws.Range(Alpha(C + 1) & CurRow).Value2 = oTable.Rows(R).Item(ColName(C + 1)).ToString
                Next
                CurRow += 1
            Next

            'ws.Range("A14", "Q" & CurRow + 1).Value2 = arr
            ws.Range("A13", "Q" & CurRow + 1).Cells.Borders(Excel.XlBordersIndex.xlInsideVertical).LineStyle = 1
            ws.Range("A13", "Q" & CurRow + 1).Cells.Borders(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = 1
            ws.Range("A13", "Q" & CurRow + 1).Cells.BorderAround(1, Excel.XlBorderWeight.xlMedium)

            Path = "c:\loadingFromForShangHai" & Me.cboVessel.Text.Trim & ".xls"
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            app.Quit()
        Finally
            If oTable.Rows.Count = 0 Then
                app.Quit()
            End If
        End Try

    End Sub
    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try
            'QueryPOL(Me.cboVessel.SelectedValue.ToString)
            SQL = "Select ETD From SailingSchedule Where SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                Me.dtpLeavingDate.Text = dt.Rows(0).Item("ETD").ToString
            Else
                MsgBox("The Schedule Is Invalid , Please Check Again")
                Return
            End If

        Catch ex As Exception
            DisplayMessage(True, Err.Source)
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryData(Me.cboVessel.SelectedValue.ToString)
        SetExcelValue()
    End Sub
End Class