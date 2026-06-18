Public Class frmAccounting_ReportDetail

    Function TongTienCuoc(ByVal ID As String) As Double
        Try
            Dim SQL As String
            Dim Total As Double = 0
            'phí bill
            SQL = "Select sum(UnitPrice*Quantity) as Fee "
            SQL &= " From PriceBillMaster "
            SQL &= " Where PriceBillMaster.Continued=1 And PriceBillMaster.BL_ID='" & ID & "'"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("Fee").ToString.Trim <> "" Then
                    Total += dt.Rows(0).Item("Fee")
                End If
            End If
            'phí container
            SQL = "Select sum(UnitPriceSale*Quantity) as Fee "
            SQL &= " From FREIGHT_CHARGE_Master "
            SQL &= "Where FREIGHT_CHARGE_Master.Continued=1 And FREIGHT_CHARGE_Master.BL_ID='" & ID & "'"

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
    Sub SetExcelValueVantaiQT()

        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            Dim path As String = StartupPath & "\ToKhaiThuNhapVTQTDetail.xls"

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
            Dim Currow As Integer = 16
            For i As Integer = 0 To Me.dgdVessel.Rows.Count - 1
                Dim index As Integer = i
                ws.Rows(Currow).Insert(1)
                mVessel = Me.dgdVessel.Item("Vessel", index).Value
                mVoyNo = Me.dgdVessel.Item("VoyNo", index).Value
                mId = Me.dgdVessel.Item("ID", index).Value.ToString
                ws.Range("A" & Currow).Value = Me.dgdVessel.Item("BL_NO", index).Value
                ws.Range("D" & Currow).Value = Me.dgdVessel.Item("POL", index).Value
                ws.Range("E" & Currow).Value = Me.dgdVessel.Item("DEST", index).Value
                ws.Range("F" & Currow).Value = Me.dgdVessel.Item("Payer", index).Value
                ws.Range("G" & Currow).Value = TongTienCuoc(mId)
                ws.Range("H" & Currow).Value = (TongTienCuoc(mId) * CDbl(Me.txtThueThuc.Text)) / 100
                ws.Range("I" & Currow).Value = (TongTienCuoc(mId) * CDbl(Me.txtThueGiam.Text)) / 100
            Next

            path = "c:\ToKhaiThuNhapVTQTDetail" & Now().Second & ".xls"
            workbook.SaveAs(path, , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )

        Catch ex As Exception
            MsgBox("Không xuất được file excel" & vbCrLf & " Tắt chương trình Excel nếu đang mở và chạy lại chừơng trình ")
            MsgBox(Err.Description)
            Return
        Finally
            app.Quit()
        End Try

    End Sub
    Sub QueryVessel()
        Try
            Dim SQL As String
            SQL = "Select BL_ID as ID,BL_NO ,Vessel ,VoyNo,SHIPPING_LINE,POL,PLACE_OF_DESTINATION_CODE as Dest,Payer "
            SQL &= " from (((BillOfLading INNER JOIN ContainerOutboundNotify On ContainerOutboundNotify.ContainerOutboundNotifyID=BillOfLading.ContainerOutboundNotifyID )"
            SQL &= "  LEFT JOIN SailingSchedule On SailingSchedule.SailingScheduleID=ContainerOutboundNotify.SailingScheduleID)"
            SQL &= "  LEFT JOIN Vessel On Vessel.Vessel_ID=SailingSchedule.Vessel_ID) "
            SQL &= " Where SailingSchedule.continued=1 And convert(DateTime,ETD)>='" & Me.dtpFrom.Value.Date & " 00:00:00' and Convert(DateTime,ETD)<='" & Me.dtpTo.Value.Date & " 23:59:00'"

            Dim dt As New DataTable
            dt = ReadTable(SQL)
            Me.dgdVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmAccounting_ReportDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        QueryVessel()
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExportExcel.Click
        SetExcelValueVantaiQT()
    End Sub
End Class