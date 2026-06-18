Public Class frmAccounting_Report

    Sub QueryData()
        Try
            Dim SQL As String
            SQL = "Select POL "
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Function TongTienCuoc(ByVal ID As String) As Double
        Try
            Dim SQL As String
            Dim Total As Double = 0
            'phí bill
            SQL = "Select sum(UnitPrice*Quantity*exchange) as Fee "
            SQL &= " From (((PriceBillMaster INNER JOIN BillOfLading On PriceBillMaster .BL_ID=BillOfLading.BL_ID)"
            SQL &= " INNER Join ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
            SQL &= " INNER JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)inner join currency on currency.currency=PriceBillMaster.currency "
            SQL &= "Where PriceBillMaster.Continued=1 And SailingSchedule.SailingScheduleID='" & ID & "' and billoflading.continued=1 "
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("Fee").ToString.Trim <> "" Then
                    Total += dt.Rows(0).Item("Fee")
                End If
            End If
            'phí container
            SQL = "Select sum(UnitPriceSale*Quantity*exchange) as Fee "
            SQL &= " From ((((FREIGHT_CHARGE_Master INNER JOIN BillOfLading On FREIGHT_CHARGE_Master.BL_ID=BillOfLading.BL_ID)"
            SQL &= " INNER Join ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID)"
            SQL &= " INNER JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID) inner join charge on CHARGE.CHARGE_ID=FREIGHT_CHARGE_Master.CHARGE_ID) inner join currency on currency.currency=FREIGHT_CHARGE_Master.currency "
            SQL &= "Where FREIGHT_CHARGE_Master.Continued=1 And billoflading.continued=1 and SailingSchedule.SailingScheduleID='" & ID & "' and (CHARGE.CHARGE_code <> 'THC' )"

            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("Fee").ToString.Trim <> "" Then
                    Total += dt.Rows(0).Item("Fee")
                End If

            End If
            Return Total
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Function
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select sailingScheduleID as ID ,Vessel ,VoyNo,SHIPPING_LINE,POL"
            SQL &= " from (SailingSchedule LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID) "
            SQL &= " Where SailingSchedule.continued=1 And convert(DateTime,ETD)>='" & Me.dtpFrom.Value.Date & " 00:00:00' and Convert(DateTime,ETD)<='" & Me.dtpTo.Value.Date & " 23:59:00'"

            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryVessel()
    End Sub
    Sub SetExcelValueVantaiQT()
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = StartupPath & "\ToKhaiThueThuNhapVTQT.xls"

            workbook = workbooks.Open(path)

            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If

            Dim mVessel, mVoyNo As String
            Dim mId As String
            Dim Currow As Integer = 14
            For i As Integer = 0 To Me.dgdVessel.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1
                Dim index As Integer = Me.dgdVessel.SelectedRows(i).Index
                mVessel = Me.dgdVessel.Item("Vessel", index).Value
                mVoyNo = Me.dgdVessel.Item("VoyNo", index).Value
                mId = Me.dgdVessel.Item("ID", index).Value.ToString
                ws.Rows(Currow).Insert(1)
                ws.Range("A" & Currow).Value = mVessel
                ws.Range("B" & Currow).Value = TongTienCuoc(mId)
                ws.Range("C" & Currow).Value = (TongTienCuoc(mId) * CDbl(Me.txtThueGiam.Text)) / 100
                ws.Range("D" & Currow).Value = (TongTienCuoc(mId) * CDbl(Me.txtThueThuc.Text)) / 100
            Next

            path = "c:\ToKhaiThueThuNhapVTQT " & Now.Second & ".xls"
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub BảngKhaiThuếCướcToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBangKhaiThueCuoc.Click
        SetExcelValueThueCuoc()
    End Sub
    Sub SetExcelValueThueCuoc()

        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = StartupPath & "\ToKhaiThueCuoc.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()

                Return
            End If

            Dim mVessel, mVoyNo As String
            Dim mId As String
            Dim Currow As Integer = 17
            For i As Integer = 0 To Me.dgdVessel.Rows.GetRowCount(DataGridViewElementStates.Selected) - 1
                Dim index As Integer = Me.dgdVessel.SelectedRows(i).Index
                ws.Rows(Currow).Insert(1)
                mVessel = Me.dgdVessel.Item("Vessel", index).Value
                mVoyNo = Me.dgdVessel.Item("VoyNo", index).Value
                mId = Me.dgdVessel.Item("ID", index).Value.ToString
                ws.Range("A" & Currow).Value = Me.dgdVessel.Item("Shipping_Line", index).Value.ToString
                ws.Range("B" & Currow).Value = mVessel & " - " & mVoyNo
                ws.Range("G" & Currow).Value = TongTienCuoc(mId)
                ws.Range("H" & Currow).Value = (TongTienCuoc(mId) * CDbl(Me.txtThueThuc.Text)) / 100
                ws.Range("I" & Currow).Value = (TongTienCuoc(mId) * CDbl(Me.txtThueGiam.Text)) / 100
            Next

            path = "c:\ToKhaiThueCuoc" & Now.Second & ".xls"
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub

    Private Sub mnuBangKhaiThueThuaNhapQT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBangKhaiThueThuaNhapQT.Click
        SetExcelValueVantaiQT()
    End Sub

    Private Sub frmAccounting_Report_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class