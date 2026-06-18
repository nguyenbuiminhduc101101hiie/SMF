Public Class frmTransitOutbound
    Dim SQL As String
    Dim oTableVessel As New DataTable
    Dim oTablebill As New DataTable
    Dim Vessel, VoyNo As String
    Dim VesselOut, VesselOutNo As String
    Dim Temp() As String
    Dim mFilter, mFilterTransit As String
    Const strBillOfLadingSelect As String = " SELECT BLTranSitOutbound.BLIB_Id,BLTranSitOutbound.CargoIB_ID,Container_No,CargoIB.Container_Type," & _
           "GROSSWEIGHT,BillOfLadingIB.Vessel as VesselInbound,BillOfLadingIB.ETA as ETAInbound," & _
           "BLTranSitOutbound.BLIB_NO as BLIB_NO, " & _
            "Shipper.SHIPPER_1  as ShipperName, " & _
           "Consignee.CONSIGNEE_1  as ConsigneeName, BLTranSitOutbound.REF," & _
           "Notify.NOTIFY_1  as NotifyName,  " & _
           "BLTranSitOutbound.Vessel,BLTranSitOutbound.VesselCode," & _
           "BLTranSitOutbound.VoyAge,BLTranSitOutbound.VesselOut,BLTranSitOutbound.VesselOutCode,BLTranSitOutbound.VoyAgeOut,BLTranSitOutbound.VesselOutETD," & _
           "BLTranSitOutbound.CY_CFS_ITEM ,BLTranSitOutbound.SAILINGDATE , BLTranSitOutbound.ETA, BLTranSitOutbound.VIA, " & _
           "BLTranSitOutbound.POR, " & _
           "BLTranSitOutbound.POL , " & _
           "BLTranSitOutbound.POD ,  " & _
           "BLTranSitOutbound.DEL, " & _
           "BLTranSitOutbound.DEST,  " & _
           "BLTranSitOutbound.LC_NO,BLTranSitOutbound.ICDPort,BLTranSitOutbound.BL_Type, BLTranSitOutbound.WeekOfYear ," & _
           "BLTranSitOutbound.DESCRIPTIONOFGOODS,BLTranSitOutbound.DESCRIPTIONFORSHIPPER,BLTranSitOutbound.MARKS,BLTranSitOutbound.DisChargeDate, " & _
           "BLTranSitOutbound.Editable as Editable, " & _
           "BLTranSitOutbound.Continued as Continued, " & _
           "BLTranSitOutbound.Approve as Approve, " & _
           "BLTranSitOutbound.UserId as UserId, " & _
           "BLTranSitOutbound.Updatetime as Updatetime "


    Sub QueryVesselOut()
        Try
            SQL = "Select Vessel,Vessel_Code as VesselCode From Vessel Where Continued=1 Order By Vessel"
            Dim dtVessel As New DataTable
            dtVessel = ReadTable(SQL)
            Me.cboVesselTransit.DisplayMember = "Vessel"
            Me.cboVesselTransit.ValueMember = "VesselCode"
            Me.cboVesselTransit.DataSource = dtVessel
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub QueryBillOfLading(ByVal agr As String)
        Try
            'If Vessel = "" Or VoyNo = "" Then
            '    Return
            'End If
            SQL = "Select BillOfLadingIb.*,Container_No,CargoIB_ID,CargoIB.Container_Type,GROSSWEIGHT  "
            SQL &= " from ((BillOfLadingIb INNER JOIN CargoIB On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID)"
            SQL &= " INNER JOIN Container On Container.CTN_ID=CargoIB.CTN_ID)"
            SQL &= " Where BillOfLadingIb.Continued=1 And TranSit=1 And CargoIB.Continued=1 " & agr
            SQL &= " Order By BLIB_NO"
            oTablebill = ReadTable(SQL)
            Dim CountBillNo As Integer
            Dim billNo As String = ""
            For i As Integer = 0 To oTablebill.Rows.Count - 1
                If billNo <> oTablebill.Rows(i).Item("BLIB_NO").ToString.Trim Then
                    billNo = oTablebill.Rows(i).Item("BLIB_NO").ToString.Trim
                    CountBillNo += 1
                End If
            Next
           
            Me.lblTotalTransitBill.Text = CountBillNo & " Bill(s) And " & oTablebill.Rows.Count & " Container(s)"
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryOutboundTransit(ByVal agr As String)
        Try
            'SQL = "Select * from BLTranSitOutbound Where Continued=1 And TranSit=1 "
            'SQL &= " And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "' Order By BLIB_NO"
          
            SQL = MakeQueryBillOfLading(agr)
            Dim dt1 As New DataTable

            dt1 = ReadTable(SQL)
            Me.dgdBillOfLading.DataSource = dt1

            Dim CountbillNo As Integer = 0
            Dim BillNo As String = ""
            For i As Integer = 0 To dt1.Rows.Count - 1
                If BillNo <> dt1.Rows(i).Item("BLIB_NO").ToString Then
                    CountbillNo += 1
                    BillNo = dt1.Rows(i).Item("BLIB_NO").ToString
                End If
            Next
            Me.lblTotalTransitOutbound.Text = CountbillNo & " Bill(s) And " & dt1.Rows.Count & " Container(s)"
            Me.BL_ID.Visible = False
            For i As Integer = 0 To Me.dgdBillOfLading.ColumnCount - 1
                If UCase(Me.dgdBillOfLading.Columns(i).Name) Like "*ID" Then
                    Me.dgdBillOfLading.Columns(i).Visible = False
                End If
            Next
            InsertAutoNumberToGrid(Me.dgdBillOfLading)
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Sub QueryVessl()
        Try
            SQL = "Select Distinct Vessel + ' - ' + VoyAge  as Vessel, ETA  From BillOfLadingIB Where Continued=1 And TranSit=0 Order by Vessel"

            oTableVessel = ReadTable(SQL)
            For i As Integer = 0 To oTableVessel.Rows.Count - 1
                Me.cboVessel.Items.Add(oTableVessel.Rows(i).Item("Vessel").ToString)
                'Me.cboVoyNo.Items.Add(oTableVessel.Rows(i).Item("VoyNo").ToString)
            Next
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub frmTransitOutbound_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QueryVesselOut()
        QueryVessl()
        mFilter = ""
        mFilterTransit = ""
        SetDefaultGrid(Me.dgdBillOfLading, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)

        SetDefaultGrid(Me.dgdTransitBill, mbkColor, mcbkColor, mcfrColor, msbkColor, msfrColor, mAlign, mFont)


    End Sub

    Private Sub cboVessel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVessel.SelectedIndexChanged
        Try
            If Me.cboVessel.Text = "" Then
                Return
            End If

            Temp = Strings.Split(Me.cboVessel.Text.Trim, " - ")
            If Temp.Length <> 2 Then
                Return
            End If
            Vessel = Temp(0)
            VoyNo = Temp(1)
            AddItemInList(" And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "' ")
            'Me.lbTransitIB.Items.Clear()
            'QueryBillOfLading()
            'For i As Integer = 0 To oTablebill.Rows.Count - 1
            '    Me.lbTransitIB.Items.Add(oTablebill.Rows(i).Item("BLIB_NO").ToString.Trim & " - " & oTablebill.Rows(i).Item("Container_No").ToString.Trim)
            'Next
            For i As Integer = 0 To oTableVessel.Rows.Count - 1
                If UCase(Me.cboVessel.Text.Trim) = UCase(oTableVessel.Rows(i).Item("Vessel").ToString.Trim) Then
                    Me.dtpETA.Text = oTableVessel.Rows(i).Item("ETA").ToString
                End If
            Next

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Sub AddItemInList(Optional ByVal agr As String = "")
        Try
            If Me.dgdTransitBill.RowCount > 0 Then
                Me.dgdTransitBill.Rows.Clear()
            End If

            QueryBillOfLading(agr)
            If oTablebill.Rows.Count > 0 Then
                Me.dgdTransitBill.Rows.Add(oTablebill.Rows.Count)
            End If

            For i As Integer = 0 To oTablebill.Rows.Count - 1
                Me.dgdTransitBill.Item("BLIB", i).Value = oTablebill.Rows(i).Item("BLIB_NO").ToString.Trim

                Me.dgdTransitBill.Item("Container", i).Value = oTablebill.Rows(i).Item("Container_No").ToString.Trim

                Me.dgdTransitBill.Item("Containertype", i).Value = oTablebill.Rows(i).Item("Container_type").ToString.Trim

                Me.dgdTransitBill.Item("ETA1", i).Value = oTablebill.Rows(i).Item("ETA").ToString.Trim
                Me.dgdTransitBill.Item("VesselLeft", i).Value = oTablebill.Rows(i).Item("Vessel").ToString.Trim
                Me.dgdTransitBill.Item("VoyNoLeft", i).Value = oTablebill.Rows(i).Item("Voyage").ToString.Trim

                Me.dgdTransitBill.Item("BLIB_ID", i).Value = oTablebill.Rows(i).Item("BLIB_ID").ToString.Trim
            Next
            InsertAutoNumberToGrid(Me.dgdTransitBill)
           
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub
    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
        Try
            QueryVessl()
            QueryOutboundTransit(" And VesselOut='" & Me.cboVesselTransit.Text.Trim & "' And VoyAgeOut='" & Me.txtVoyNo.Text.Trim & "'")
            AddItemInList(" And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "' ")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub


    Private Sub ctmAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmAdd.Click
        Try
            If Me.cboVesselTransit.Text.Trim = "" Or Me.txtVoyNo.Text.Trim = "" Then
                MsgBox("Transit Vessel And Voy No Not allow Empty Value")
                Return
            End If
            If Me.dgdTransitBill.RowCount = 0 Then
                Return
            End If


            'không cho sort trên lứơi nên dòng i trên lứơi chính là dòng i trên table
            Dim i As Integer
            Dim CountRow As Integer = Me.dgdTransitBill.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If CountRow = 0 Then
                Return
            End If
            For j As Integer = 0 To CountRow - 1
                i = Me.dgdTransitBill.SelectedRows(j).Index

                Dim BLIB_ID As String = Me.dgdTransitBill.Item("BLIB_ID", i).Value.ToString

                Dim rs As New ADODB.Recordset
                SQL = "select * from BLTranSitOutbound"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                With rs


                    .AddNew()
                    .Fields("BLIB_ID").Value = "{" & BLIB_ID & "}"

                    'strBillIBId = .Fields("BLIB_ID").Value
                    .Fields("BLIB_NO").Value = oTablebill.Rows(i).Item("BLIB_NO")
                    .Fields("SHIPPER_ID").Value = "{" & oTablebill.Rows(i).Item("SHIPPER_ID").ToString & "}"
                    .Fields("CONSIGNEE_ID").Value = "{" & oTablebill.Rows(i).Item("CONSIGNEE_ID").ToString & "}"
                    .Fields("NOTIFY_ID").Value = "{" & oTablebill.Rows(i).Item("NOTIFY_ID").ToString & "}"

                    .Fields("CargoIB_ID").Value = "{" & oTablebill.Rows(i).Item("CargoIB_ID").ToString & "}"

                    .Fields("REF").Value = oTablebill.Rows(i).Item("REF")
                    .Fields("CY_CFS_ITEM").Value = oTablebill.Rows(i).Item("CY_CFS_ITEM")
                    .Fields("BL_TYPE").Value = oTablebill.Rows(i).Item("BL_TYPE")
                    .Fields("MARKS").Value = oTablebill.Rows(i).Item("MARKS")
                    .Fields("DESCRIPTIONOFGOODS").Value = oTablebill.Rows(i).Item("DESCRIPTIONOFGOODS")
                    .Fields("DESCRIPTIONFORSHIPPER").Value = oTablebill.Rows(i).Item("DESCRIPTIONFORSHIPPER")
                    .Fields("LC_NO").Value = oTablebill.Rows(i).Item("LC_NO")
                    .Fields("vessel").Value = oTablebill.Rows(i).Item("vessel")
                    .Fields("vesselCode").Value = oTablebill.Rows(i).Item("vesselCode")
                    .Fields("VOYAGE").Value = oTablebill.Rows(i).Item("VOYAGE")

                    .Fields("SAILINGDATE").Value = oTablebill.Rows(i).Item("SAILINGDATE")
                    .Fields("ETA").Value = oTablebill.Rows(i).Item("ETA")
                    .Fields("WEEKOFYEAR").Value = oTablebill.Rows(i).Item("WEEKOFYEAR")
                    .Fields("DisChargeDate").Value = oTablebill.Rows(i).Item("DisChargeDate")

                    .Fields("POR").Value = oTablebill.Rows(i).Item("POR")

                    .Fields("POL").Value = oTablebill.Rows(i).Item("POL")
                    .Fields("POD").Value = oTablebill.Rows(i).Item("POD")
                    .Fields("DEL").Value = oTablebill.Rows(i).Item("DEL")
                    .Fields("DEST").Value = oTablebill.Rows(i).Item("DEST")

                    .Fields("VesselOut").Value = Me.cboVesselTransit.Text
                    .Fields("VoyAgeOut").Value = UCase(Strings.Replace(Strings.Replace(Me.txtVoyNo.Text.Trim, " ", ""), "-", ""))
                    .Fields("VesselOutCode").Value = Me.cboVesselTransit.SelectedValue.ToString
                    .Fields("VesselOutETD").Value = Me.dtpETD.Value.Date
                    .Fields("DisChargeDate").Value = oTablebill.Rows(i).Item("DisChargeDate")
                    .Fields("ICDPort").Value = oTablebill.Rows(i).Item("ICDPort")
                    .Fields("Transit").Value = 1 'oTablebill.Rows(i).Item("Transit")
                    '.Fields("Weekofyear").Value = weekofyear()
                    .Update()
                End With
                rs.Close()
                SQL = "Select * from CargoIB Where CargoIB_ID='" & oTablebill.Rows(i).Item("CargoIB_ID").ToString & "'"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                rs.Fields("Continued").Value = 0
                rs.Update()
                rs.Close()
            Next
            If Vessel = "" Or VoyNo = "" Then
                AddItemInList()
            Else
                AddItemInList(" And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "' ")
            End If

            'AddItemInList(" And Vessel='" & Me.cboVesselTransit.Text.Trim & "' And VoyAge='" & Me.txtVoyNo.Text.Trim & "' ")
            QueryOutboundTransit(" And VesselOut='" & Me.cboVesselTransit.Text.Trim & "' And VoyAgeOut='" & Me.txtVoyNo.Text.Trim & "'")
        Catch ex As Exception
            If Err.Number = -2147217873 Then
                MsgBox("This Bill Already Add to Outbound, Try the another bill Please")
                Return
            End If
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = strBillOfLadingSelect

        MakeQueryBillOfLading = MakeQueryBillOfLading & ",(select Count(*) From Cargoib where Cargoib.BLIB_ID=BLTranSitOutbound.BLIB_ID And CargoIb.continued=1) As QuantityOfContainer "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM ((((((BLTranSitOutbound left join Shipper on BLTranSitOutbound.Shipper_Id=Shipper.Shipper_Id )"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN BillOfLadingIB On BillOfLadingIB.BLIB_ID=BLTranSitOutbound.BLIB_ID)"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " left join Consignee on BLTranSitOutbound.Consignee_Id=Consignee.Consignee_Id ) "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "left join Notify  on BLTranSitOutbound.Notify_Id=Notify.Notify_id )  "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "Left Join CargoIB On CargoIB.CargoIB_ID=BLTranSitOutbound.CargoIB_ID)"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " LEFT JOIN Container On Container.CTN_ID=CargoIB.CTN_ID)"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "BLTranSitOutbound.Continued = 1 " ' "And VesselOut='" & VesselOut.Trim & "' And VoyAgeOut='" & VesselOutNo.Trim & "'"
        MakeQueryBillOfLading = MakeQueryBillOfLading & " "
        If argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading & argCriteria
        End If
        MakeQueryBillOfLading = MakeQueryBillOfLading & " Order By BLIB_NO ASC "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & strBillOfLadingOrder2


        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Public Sub DeleteRow(ByVal index As Integer)
        On Error GoTo Err_Renamed
        Dim rs As New ADODB.Recordset
        Dim strQuery, strQueryCommodityList As String
        Dim blnEmpty, blnEOF As Boolean
        If Not IsNothing(Me.dgdBillOfLading.Item("Approve", index)) Then
            If Me.dgdBillOfLading.Item("Approve", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        If Not IsNothing(Me.dgdBillOfLading.Item("Editable", index)) Then
            If Not Me.dgdBillOfLading.Item("Editable", index).Value Then
                DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
                Exit Sub
            End If
        End If
        Dim strMesg As String
        Dim bm As Short
        If Not UserRight("frmInputDataInBound", "Delete") Then
            DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        Else
            'strMesg = "Delete the Bill OF In Bound: " & Me.dgdBillOfLading.Item("BL_No", index).Value.ToString
            'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            Dim CargoID As String = Me.dgdBillOfLading.Item("CargoIB_ID", index).Value.ToString
            strQueryCommodityList = "delete from BLTranSitOutbound where" + " CargoIB_ID= '" & CargoID & "'"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmd As New SqlClient.SqlCommand(strQueryCommodityList, Conn)
            cmd.CommandType = CommandType.Text
            cmd.CommandText = strQueryCommodityList
            cmd.ExecuteNonQuery()
            'rs.Open(strQueryCommodityList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            'rs.Fields("continued").Value = 0
            'rs.Update()

            'rs.Requery()
            'Me.dgdBillOfLading.Rows(index).DefaultCellStyle.ForeColor = Color.White
            'Me.dgdBillOfLading.Rows(index).DefaultCellStyle.SelectionForeColor = Color.Blue
            'rs.Close()
            'blnUpdated = True
            SQL = "Select * from CargoIB Where CargoIB_ID='" & CargoID & "'"
            rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            rs.Fields("Continued").Value = 1
            rs.Update()
            rs.Close()

            'End If
        End If
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Sub

    Private Sub ctmDeleteOutboundTransit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctmDeleteOutboundTransit.Click
        Try
            Dim selectedRowCount As Integer = _
                      Me.dgdBillOfLading.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If selectedRowCount > 0 Then
                Dim sb As New System.Text.StringBuilder()
                Dim i As Integer
                For i = 0 To selectedRowCount - 1
                    DeleteRow(Me.dgdBillOfLading.SelectedRows(i).Index)
                Next
                AddItemInList(" And Vessel='" & Vessel.Trim & "' And VoyAge='" & VoyNo.Trim & "' ")
                QueryOutboundTransit(" And VesselOut='" & Me.cboVesselTransit.Text.Trim & "' And VoyAgeOut='" & Me.txtVoyNo.Text.Trim & "'")
            End If
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpdate.Click
        Try
            'SQL = "Update BLTranSitOutbound Set VesselOut='" & Me.cboVesselTransit.Text.Trim & "',"
            'SQL &= " VesselOutCode='" & Me.cboVesselTransit.SelectedValue.ToString & "',"
            'SQL &= " VoyAgeOut='" & Me.txtVoyNo.Text.Trim & "',"
            'SQL &= " VesselOutETD='" & Me.dtpETA.Value.Date & "'"
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim cmd As New SqlClient.SqlCommand(SQL, Conn)
            'cmd.CommandType = CommandType.Text
            'cmd.CommandText = SQL
            'cmd.ExecuteNonQuery()
            If Me.dgdBillOfLading.RowCount = 0 Then
                Return
            End If
            Dim SelectedCount As Integer = Me.dgdBillOfLading.Rows.GetRowCount(DataGridViewElementStates.Selected)
            If SelectedCount = 0 Then
                MsgBox("You Have to select Some rows at the Grid Below to Update")
                Return
            End If
            For j As Integer = 0 To SelectedCount - 1
                Dim i As Integer = Me.dgdBillOfLading.SelectedRows(j).Index
                Dim BLIB_ID As String = Me.dgdBillOfLading.Item("BL_ID", i).Value.ToString.Trim

                Dim rs As New ADODB.Recordset
                SQL = "select * from BLTranSitOutbound Where BLIB_ID='" & BLIB_ID & "'"
                rs.Open(SQL, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)

                Try
                    With rs
                        .Fields("VesselOut").Value = Me.cboVesselTransit.Text.Trim
                        .Fields("VesselOutCode").Value = Me.cboVesselTransit.SelectedValue.ToString
                        .Fields("VoyAgeOut").Value = Me.txtVoyNo.Text.Trim
                        .Fields("VesselOutETD").Value = Me.dtpETD.Value.Date
                        .Update()
                    End With
                Catch ex As Exception
                    DisplayMessage(True, Err.Description)
                Finally
                    rs.Close()
                End Try
            Next
            MsgBox("Updated!")
            QueryOutboundTransit(" And VesselOut='" & Me.cboVesselTransit.Text.Trim & "' And VoyAgeOut='" & Me.txtVoyNo.Text.Trim & "'")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub cmdExportExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Me.dgdBillOfLading.RowCount > 0 Then
                'SetMenu(False)
                Me.Cursor = Cursors.WaitCursor
                ExportExecel(Me.dgdBillOfLading, Me)
                'SetMenu(True)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboVesselTransit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboVesselTransit.SelectedIndexChanged
        Try
            If Me.cboVesselTransit.FindStringExact(UCase(Me.cboVesselTransit.Text)) = -1 Then
                MsgBox("Vessel Invalid, Please Select Vessel In The List ")
                Me.cboVesselTransit.Focus()
            End If
            VesselOut = Me.cboVesselTransit.Text
            VesselOutNo = Me.txtVoyNo.Text

            QueryOutboundTransit(" And VesselOut='" & Me.cboVesselTransit.Text.Trim & "' And VoyAgeOut='" & Me.txtVoyNo.Text.Trim & "'")
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdBillOfLading_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBillOfLading.CellClick
       
    End Sub

    Private Sub dgdBillOfLading_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdBillOfLading.CellContentClick

    End Sub
    Private Sub dgdBillOfLading_RowHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBillOfLading.RowHeaderMouseClick
        Try
            If Me.dgdBillOfLading.Rows.Count = 0 Then
                Return
            End If
            Dim i As Integer
            If Not IsNothing(Me.dgdBillOfLading.CurrentRow) Then
                i = Me.dgdBillOfLading.CurrentRow.Index
            Else
                Return
            End If

            Me.txtVoyNo.Text = Me.dgdBillOfLading.Item("TransitVoyno", i).Value.ToString
            Me.cboVesselTransit.SelectedValue = Me.dgdBillOfLading.Item("TransitVesselCode", i).Value.ToString
            Me.dtpETD.Text = Me.dgdBillOfLading.Item("TransitETD", i).Value.ToString

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Sub

    Private Sub dgdBillOfLading_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgdBillOfLading.ColumnHeaderMouseClick
        InsertAutoNumberToGrid(Me.dgdBillOfLading)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim path As String
        Dim app As Excel.Application
        Try
            Dim Alpha() As String = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP"}

            app = New Excel.Application()
            app.Visible = True

            Dim workbooks As Excel.Workbooks
            workbooks = app.Workbooks
            Dim workbook As Excel._Workbook

            path = StartupPath & "\LoadingFormForShangHai.xls"

            workbook = workbooks.Open(path)



            Dim sheets As Excel.Sheets
            sheets = workbook.Worksheets
            Dim ws As Excel._Worksheet
            ws = sheets.Item(1)
            If ws Is Nothing Then
                app.Quit()
                Return
            End If
            Dim startRow As Integer = 13
            For i As Integer = 0 To Me.dgdBillOfLading.RowCount - 1
                ws.Range("A" & i + startRow).Value2 = i + 1
                ws.Range("B" & i + startRow).Value2 = Me.dgdBillOfLading.Item("BL_NO", i).Value.ToString
                ws.Range("C" & i + startRow).Value2 = Me.dgdBillOfLading.Item("Container_No", i).Value.ToString
                'ws.Range("D" & i + startRow).Value2 = 
                ws.Range("E" & i + startRow).Value2 = Me.dgdBillOfLading.Item("Container_Type", i).Value.ToString
                'ws.Range("F" & i + startRow).Value2 = 
                ws.Range("G" & i + startRow).Value2 = Me.dgdBillOfLading.Item("GROSSWEIGHT", i).Value.ToString
                'ws.Range("H" & i + startRow).Value2 = 
                ws.Range("I" & i + startRow).Value2 = Me.dgdBillOfLading.Item("POL", i).Value.ToString
                'ws.Range("J" & i + startRow).Value2 = Me.dgdBillOfLading.Item("BLID_NO", i).Value.ToString
                ws.Range("K" & i + startRow).Value2 = Me.dgdBillOfLading.Item("PORT_OF_DISCHARGE", i).Value.ToString
                ws.Range("L" & i + startRow).Value2 = Me.dgdBillOfLading.Item("PLACE_OF_DESTINATION", i).Value.ToString
                'ws.Range("M" & i + startRow).Value2 = Me.dgdBillOfLading.Item("BLID_NO", i).Value.ToString
                'ws.Range("N" & i + startRow).Value2 = Me.dgdBillOfLading.Item("BLID_NO", i).Value.ToString
                'ws.Range("O" & i + startRow).Value2 = Me.dgdBillOfLading.Item("BLID_NO", i).Value.ToString
                'ws.Range("P" & i + startRow).Value2 = Me.dgdBillOfLading.Item("VesselInbound", i).Value.ToString
                'ws.Range("Q" & i + startRow).Value2 = Me.dgdBillOfLading.Item("ETAVesselInbound", i).Value.ToString
                'ws.Range("R" & i + startRow).Value2 = Me.dgdBillOfLading.Item("BLID_NO", i).Value.ToString
            Next
            ws.Range("B8").Value2 = Me.cboVesselTransit.Text & " - " & Me.txtVoyNo.Text

            ws.Range("B9").Value2 = Me.dtpETD.Value.Date

            workbook.SaveAs("c:\LoadingFormForShangHai " & strUserId & ".xls", , , , , , Excel.XlSaveAsAccessMode.xlShared, , , , )
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub cmdAllTransitBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllTransitBill.Click
        Me.Cursor = Cursors.WaitCursor
        'QueryBillOfLading("") 'query khong dieu kien
        AddItemInList()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdAllTranSitbillOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAllTranSitbillOut.Click
        Me.Cursor = Cursors.WaitCursor
        QueryOutboundTransit("") 'query khong dieu kien
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            If Me.dgdTransitBill.RowCount = 0 Then
                Return
            End If
            ExportExecel(Me.dgdTransitBill, Me)
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub

    Private Sub TransitContainerInVietNamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransitContainerInVietNamToolStripMenuItem.Click
        frmTransitContainerInvietnam.Show()
    End Sub

    Private Sub TranSitContainerOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TranSitContainerOutToolStripMenuItem.Click
        frmTransitContainerOut.Show()
    End Sub

    
    Private Sub cmdSearChBaseIB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearChBaseIB.Click
        'Try
        '    gNameForm = frmListBaseIB.Name
        '    VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
        '    If frmFilter.strQuery <> "Cancel" Then
        '        mFilter = frmFilter.strQuery
        '        AddItemInList("  " & mFilter)
        '    End If
        'Catch ex As Exception
        '    MsgBox(msgErr(Me, ex.Message))
        'End Try
    End Sub

    Private Sub cmdSearchTransitOutbound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSearchTransitOutbound.Click
        Try
            gNameForm = Me.Name
            VB6.ShowForm(frmFilter, VB6.FormShowConstants.Modal, Me)
            If frmFilter.strQuery <> "Cancel" Then
                mFilterTransit = frmFilter.strQuery
                QueryOutboundTransit("  " & mFilterTransit)
            End If
        Catch ex As Exception
            MsgBox(msgErr(Me, ex.Message))
        End Try
    End Sub
End Class