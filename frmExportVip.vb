Public Class frmExportVip
    Dim Path As String
    Sub QueryVesselVoyNo()
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strQuery As String
            strQuery = "Select distinct Vessel.Vessel + ' - ' + SailingSchedule.VoyNo as Data,SailingSchedule.SailingScheduleID as Value"
            strQuery &= " From (((BillOflading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID)"
            strQuery &= " Where BillOfLading.Continued=1"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            Dim dt As New DataTable
            Adapter.Fill(dt)
            Me.cboVessel.DisplayMember = "Data"
            Me.cboVessel.ValueMember = "Value"
            Me.cboVessel.DataSource = dt
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmExportVip_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVesselVoyNo()
    End Sub

    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        If Me.cboVessel.SelectedValue.ToString = "" Or Me.cboVessel.Text.ToString.Trim = "" Then
            Return
        End If
        ExportVIP()
    End Sub
    Sub QueryBLInfo(ByRef dt As DataTable)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strQuery As String
            strQuery = "Select distinct Vessel.Vessel as Vessel, SailingSchedule.VoyNo as VoyNo,BillOfLading.BL_ID,BL_NO,BillOfLading.VIP, "
            strQuery &= " PORT_OF_DISCHARGE_NAME as POD,PORT_OF_DISCHARGE_CODE as POD_CODE, SCAC_CODE,BillOfLading.ServiceContract "
            strQuery &= " ,TRANSFER_PORT1 as VIA1,TRANSFER_PORT2 as VIA2,TRANSFER_PORT3 as VIA3,TRANSFER_PORT4 as VIA4,PLACE_OF_DELIVERY_CODE as DEL_CODE,PLACE_OF_DELIVERY_NAME as DEL ,MotherVessel.Vessel as MotherVessel,OceanETD as MotherETD"
            strQuery &= " From (((((BillOflading LEFT JOIN ContainerOutboundNotify On BillOfLading.ContainerOutboundNotifyID=ContainerOutboundNotify.ContainerOutboundNotifyID)"
            strQuery &= " LEFT JOIN SailingSchedule On ContainerOutboundNotify.SailingScheduleID=SailingSchedule.SailingScheduleID)"
            strQuery &= " LEFT JOIN Vessel On SailingSchedule.Vessel_ID=Vessel.Vessel_ID) "
            strQuery &= " LEFT JOIN MotherSailingSchedule On MotherSailingSchedule.MotherSailingScheduleID=ContainerOutboundNotify.MotherSailingScheduleID)"
            strQuery &= " LEFT join Vessel as MotherVessel On MotherVessel.Vessel_ID=MotherSailingSchedule.MotherVesselID)"
            strQuery &= " Where BillOfLading.Continued=1 And SailingScheDule.SailingScheduleID='" & Me.cboVessel.SelectedValue.ToString & "' ORDER BY VIP "
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            'Dim dt As New DataTable
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryCustomer(ByRef dt As DataTable, ByVal ID As String)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strQuery As String
            strQuery = " Select Shipper_1,Consignee_1,Notify_1 "
            strQuery &= " From (((BillOfLading LEFT JOIN Shipper On BillOfLading.Shipper_ID=Shipper.Shipper_ID)"
            strQuery &= " LEFT JOIN Consignee On BillOfLading.Consignee_ID=Consignee.Consignee_ID) "
            strQuery &= " LEFT JOIN Notify On Notify.Notify_ID=BillOfLading.Notify_id )"
            strQuery &= " Where BillOfLading.Continued=1 And BL_ID='" & ID & "'"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryContainer(ByRef dt As DataTable, ByVal ID As String)
        Try
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim strQuery As String
            strQuery = "Select Container_No "
            strQuery &= " From (Cargo LEFT JOIN Container On Cargo.CTN_ID=Container.CTN_ID)"
            strQuery &= " Where Cargo.Continued=1 And Cargo.BL_ID='" & ID & "'"
            Dim cmd As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmd)
            If dt.Rows.Count > 0 Then
                dt.Rows.Clear()
            End If
            Adapter.Fill(dt)

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Sub ExportVIP()
        Dim App As New Excel.Application
        Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", "BA", "BB", "BC", "BD", "BE", "BF", "BG"}
        Try
            App.Visible = False

            Dim workbooks As Excel.Workbooks
            workbooks = App.Workbooks
            Dim workbook As Excel._Workbook

            'path = StartupPath & "\TripAccountInbound.xls"

            workbook = workbooks.Add()

            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            Dim CurRow As Integer = 4
            Dim CurCol As Integer = 0
            Dim RowInsert As Integer = 1
            Dim dtBill As New DataTable
            Dim dtContainer As New DataTable
            Dim dtCustomer As New DataTable
            Dim ID As String = ""
            QueryBLInfo(dtBill)
            ws.Range("A1").Value2 = "B/L No."
            ws.Rows(1).Font.ColorIndex = 5
            ws.Cells.Font.Bold = True
            ws.Cells.Font.Size = 9



            For i As Integer = 0 To dtBill.Rows.Count - 1
                ID = dtBill.Rows(i).Item("BL_ID").ToString
                QueryCustomer(dtCustomer, ID)
                RowInsert = RowInsert Mod Alpha.Length

                ws.Range(Alpha(0) & CurRow).Value2 = dtBill.Rows(i).Item("BL_NO").ToString
                'If dtBill.Rows(i).Item("BL_NO").ToString = "CSGNAQJ4AP227" Then
                '    DisplayMessage(True, "")
                'End If

                '''''''''''thong tin Customer
                ws.Range(Alpha(RowInsert) & 1).Value2 = "SHIPPER" 'dtCustomer.Rows(0).Item("Shipper_1").ToString
                ws.Range(Alpha(RowInsert + 1) & 1).Value2 = "CONSIGNEE" 'dtCustomer.Rows(0).Item("Consignee_1").ToString
                ws.Range(Alpha(RowInsert + 2) & 1).Value2 = "NOTIFY" 'dtCustomer.Rows(0).Item("Notify_1").ToString

                ws.Range(Alpha(RowInsert) & CurRow).Value2 = dtCustomer.Rows(0).Item("Shipper_1").ToString
                ws.Range(Alpha(RowInsert + 1) & CurRow).Value2 = dtCustomer.Rows(0).Item("Consignee_1").ToString
                ws.Range(Alpha(RowInsert + 2) & CurRow).Value2 = dtCustomer.Rows(0).Item("Notify_1").ToString

                ''''''''''thong tin Bill
                ws.Range(Alpha(RowInsert + 3) & 1).Value2 = "Pre Vessel " 'dtBill.Rows(i).Item("Vessel").ToString
                ws.Range(Alpha(RowInsert + 4) & 1).Value2 = "Voy No" 'dtBill.Rows(i).Item("VoyNo").ToString
                ws.Range(Alpha(RowInsert + 5) & 1).Value2 = "Port Of DisCharge" 'dtBill.Rows(i).Item("POD").ToString
                ws.Range(Alpha(RowInsert + 6) & 1).Value2 = "Code " 'dtBill.Rows(i).Item("POD_CODE").ToString
                ws.Range(Alpha(RowInsert + 7) & 1).Value2 = "SCAC Code" 'dtBill.Rows(i).Item("SCAC_CODE").ToString
                ws.Range(Alpha(RowInsert + 8) & 1).Value2 = "SERVICE CONTRACT" 'dtBill.Rows(i).Item("ServiceContract").ToString
                ws.Range(Alpha(RowInsert + 9) & 1).Value2 = "VIA 1" 'dtBill.Rows(i).Item("SCAC_CODE").ToString
                ws.Range(Alpha(RowInsert + 10) & 1).Value2 = "VIA 2" 'dtBill.Rows(i).Item("ServiceContract").ToString
                ws.Range(Alpha(RowInsert + 11) & 1).Value2 = "VIA 3 " 'dtBill.Rows(i).Item("POD_CODE").ToString
                ws.Range(Alpha(RowInsert + 12) & 1).Value2 = "VIA 4" 'dtBill.Rows(i).Item("SCAC_CODE").ToString
                ws.Range(Alpha(RowInsert + 13) & 1).Value2 = "Port Of Delivery" 'dtBill.Rows(i).Item("ServiceContract").ToStrin
                ws.Range(Alpha(RowInsert + 14) & 1).Value2 = "Code" 'dtBill.Rows(i).Item("ServiceContract").ToStrin
                ws.Range(Alpha(RowInsert + 15) & 1).Value2 = "Mother Vessel " 'dtBill.Rows(i).Item("POD_CODE").ToString
                ws.Range(Alpha(RowInsert + 16) & 1).Value2 = "ETD" 'dtBill.Rows(i).Item("SCAC_CODE").ToString
                ws.Range(Alpha(RowInsert + 17) & 1).Value2 = "ETA" 'dtBill.Rows(i).Item("ServiceContract").ToString


                ws.Range(Alpha(RowInsert + 3) & CurRow).Value2 = dtBill.Rows(i).Item("Vessel")
                ws.Range(Alpha(RowInsert + 4) & CurRow).Value2 = dtBill.Rows(i).Item("VoyNo")
                ws.Range(Alpha(RowInsert + 5) & CurRow).Value2 = dtBill.Rows(i).Item("POD")
                ws.Range(Alpha(RowInsert + 6) & CurRow).Value2 = dtBill.Rows(i).Item("POD_CODE")
                ws.Range(Alpha(RowInsert + 7) & CurRow).Value2 = dtBill.Rows(i).Item("SCAC_CODE")
                ws.Range(Alpha(RowInsert + 8) & CurRow).Value2 = dtBill.Rows(i).Item("ServiceContract")
                ws.Range(Alpha(RowInsert + 9) & CurRow).Value2 = dtBill.Rows(i).Item("VIA1")
                ws.Range(Alpha(RowInsert + 10) & CurRow).Value2 = dtBill.Rows(i).Item("VIA2")
                ws.Range(Alpha(RowInsert + 11) & CurRow).Value2 = dtBill.Rows(i).Item("VIA3")
                ws.Range(Alpha(RowInsert + 12) & CurRow).Value2 = dtBill.Rows(i).Item("VIA4")
                ws.Range(Alpha(RowInsert + 13) & CurRow).Value2 = dtBill.Rows(i).Item("DEL")
                ws.Range(Alpha(RowInsert + 14) & CurRow).Value2 = dtBill.Rows(i).Item("DEL_Code")
                ws.Range(Alpha(RowInsert + 15) & CurRow).Value2 = dtBill.Rows(i).Item("MotherVessel")
                ws.Range(Alpha(RowInsert + 16) & CurRow).Value2 = dtBill.Rows(i).Item("MotherETD")
                'ws.Range(Alpha(RowInsert + 17) & 1).Value2 = "ETA" 'dtBill.Rows(i).Item("ServiceContract").ToString
                If dtBill.Rows(i).Item("VIP") = 1 Then
                    'ws.Cells.Font.ColorIndex = 1

                    ws.Rows(CurRow).Font.ColorIndex = 3
                End If

                QueryContainer(dtContainer, ID)
                For j As Integer = 0 To dtContainer.Rows.Count - 1

                    If RowInsert - 1 <= j Then
                        ws.Columns(RowInsert + 1).Insert()
                        ws.Range(Alpha(RowInsert) & 1).Value2 = "CONT " & RowInsert
                        RowInsert += 1
                    End If

                    ws.Range(Alpha(1 + j) & CurRow).Value2 = dtContainer.Rows(j).Item("Container_No").ToString
                Next
                CurRow += 1
            Next
            App.Visible = True
            MsgBox("complete!")
            'workbook.s
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
            App.Quit()
        Finally
            App = Nothing
        End Try
    End Sub
    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub
End Class