Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports
Public Class frmRptInboundManifest
    '    Dim oTableCargoInfo As New DataTable
    '    Dim oTableBill As New DataTable
    '    Dim oTableFreight As New DataTable
    '    Public oTableCustomerInfo As DataTable
    '    Dim oTableAmountContainer As New DataTable
    '    Dim oTableAllBill As New DataTable
    '    Dim vessel, VoyNo As String

    '    Dim rpt As Object
    '    Const strCustomerInfo As String = "Select Shipper.Shipper_1, " & _
    '   "Shipper.Shipper_2 , Shipper.Shipper_3,Shipper.Shipper_4," & _
    '       "Shipper.Shipper_5 , " & _
    '       "Shipper.Shipper_6 , " & _
    '   "Consignee.Consignee_1, " & _
    '       "Consignee.Consignee_2 , Consignee.Consignee_3,Consignee.Consignee_4," & _
    '       "Consignee.Consignee_5 , " & _
    '       "Consignee.Consignee_6 , " & _
    '   "Notify.Notify_1 , " & _
    '       "Notify.Notify_2, Notify.Notify_3,Notify.Notify_4," & _
    '       "Notify.Notify_5, " & _
    '       "Notify.Notify_6  "



    '    Sub QueryAmountcontainer()
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim ds As New DataSet
    '        strQuery = "select container_type,Amount= Count(Container_type) from CargoIb "
    '        strQuery &= " Where BLIB_ID='" & gBillInboundID & " '"
    '        strQuery &= " And CargoIb.Continued=1 group by Container_type"

    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        Con.Open()
    '        If Not IsNothing(oTableAmountContainer) Then
    '            oTableAmountContainer.Clear()
    '        End If
    '        Adapter.Fill(ds, "AmountContainer")
    '        oTableAmountContainer = ds.Tables(0)

    '        '--------------------
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
    '        On Error GoTo Err_Renamed

    '        MakeQueryCustomerInfo = strCustomerInfo

    '        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM (((BillOfLadingIB LEFT JOIN Shipper On BillOfLadingIB.Shipper_ID=Shipper.Shipper_ID) "
    '        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Consignee On Consignee.Consignee_ID=BillOfLadingIB.Consignee_ID) "
    '        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " LEFT JOIN Notify On Notify.Notify_ID=BillOfLadingIB.Notify_ID) "
    '        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
    '        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLadingIB.BLIB_ID= '" & gBillInboundID & "' And BillOfLadingIB.Continued=1"
    '        'Debug.Print MakeQueryCommodity
    '        Exit Function
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Function

    '    Private Sub QueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
    '        On Error GoTo Err_Renamed
    '        Dim strQuery As String
    '        '-------------
    '        Dim Con As New SqlClient.SqlConnection(strconnDG)
    '        Dim ds As New DataSet
    '        '----------------
    '        If IsNothing(argCriteria) Then
    '            strQuery = MakeQueryCustomerInfo()
    '        Else
    '            strQuery = MakeQueryCustomerInfo(argCriteria, index)
    '        End If
    '        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
    '        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
    '        '-----------------
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        Con.Open()
    '        If Not IsNothing(oTableCustomerInfo) Then
    '            oTableCustomerInfo.Clear()
    '        End If
    '        Adapter.Fill(ds, "BillOfLadingList")
    '        oTableCustomerInfo = ds.Tables(0)


    '        'hien thi ra grid 
    '        '--------------------
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '        'Resume
    '    End Sub
    '    Sub QueryCargoInFo()
    '        Try
    '            Dim strSQL As String
    '            strSQL = "SELECT CONTAINER_NO + ' / ' + CARGOIB.CONTAINER_TYPE + ' / ' AS CONTAINER_NO_TYPE, GROSSWEIGHT as Weight,MEAS as CBM,"
    '            strSQL &= "SEAL + ' / / ' + CARRIERKIND + ' / ' + RECEIVEKIND + ' / ' + STR(AMOUNT) +' ' + KIND +' / '+STR(GROSSWEIGHT) +' ' + GrossUnit +' / '+' / '+ STR(MEAS)+ ' ' +MEASUNIT AS CONTAINER_INFO "
    '            strSQL &= "FROM (CARGOIB INNER JOIN CONTAINER ON CARGOIB.CTN_ID=CONTAINER.CTN_ID)"
    '            strSQL &= " Where BLIB_ID='" & gBillInboundID & "' And cargoib.Continued=1 Order By Container_type"
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Con.Open()
    '            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '            If Not IsNothing(oTableCargoInfo) Then
    '                oTableCargoInfo.Clear()
    '            End If
    '            Adapter.Fill(oTableCargoInfo)
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try
    '    End Sub
    '    Sub QueryBill()
    '        Try
    '            Dim strSQL As String
    '            strSQL = "select * from BillOfLadingIB "
    '            strSQL &= " Where BLIB_ID='" & gBillInboundID & "' And Continued=1"
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Con.Open()
    '            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '            If Not IsNothing(oTableBill) Then
    '                oTableBill.Clear()
    '            End If
    '            Adapter.Fill(oTableBill)
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try
    '    End Sub
    '    Sub QueryFreight()
    '        Try
    '            Dim strSQL As String
    '            strSQL = "select distinct Quantity,Container_type from FREIGHT_CHARGE_IB  "
    '            strSQL &= " Where BLIB_ID='" & gBillInboundID & "' And Continued=1"
    '            Dim Con As New SqlClient.SqlConnection(strconnDG)
    '            Con.Open()
    '            Dim cmdSelect As New SqlClient.SqlCommand(strSQL, Con)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '            If Not IsNothing(oTableFreight) Then
    '                oTableFreight.Clear()
    '            End If
    '            Adapter.Fill(oTableFreight)
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try
    '    End Sub

    '    Sub QueryAllBill(ByVal Vessel As String, ByVal VoyNo As String)

    '        Try
    '            Dim strQuery As String = "Select BLIb_ID,BLIB_NO from BillOfladingIb Where Vessel='" & Vessel & "' And VoyAge='" & VoyNo & "' And Continued=1"
    '            Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '            Conn.Open()
    '            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
    '            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '            If oTableAllBill.Rows.Count > 0 Then
    '                oTableAllBill.Rows.Clear()
    '            End If
    '            Adapter.Fill(oTableAllBill)
    '            If frmPrintAllManifest.chkAll.Checked = False Then
    '                Me.cboBLIB_NO.DisplayMember = "BLIB_NO"
    '                Me.cboBLIB_NO.ValueMember = "BLIB_ID"
    '                Me.cboBLIB_NO.DataSource = oTableAllBill
    '            End If
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try
    '    End Sub

    '    Sub PrintReport(ByVal manifest As String, ByVal manifests As String)
    '        rpt = New ReportInboundManifest
    '        QueryCargoInFo()
    '        QueryBill()
    '        QueryFreight()
    '        QueryCustomerInfo()
    '        Dim i As Integer
    '        If oTableCustomerInfo.Rows.Count > 0 Then

    '            Dim Shipper_1 As TextObject
    '            Dim Shipper_2 As TextObject
    '            Dim Shipper_3 As TextObject
    '            Dim Shipper_4 As TextObject
    '            Dim Shipper_5 As TextObject
    '            Dim Shipper_6 As TextObject
    '            Dim Consignee_1 As TextObject
    '            Dim Consignee_2 As TextObject
    '            Dim Consignee_3 As TextObject
    '            Dim Consignee_4 As TextObject
    '            Dim Consignee_5 As TextObject
    '            Dim Consignee_6 As TextObject

    '            Dim Notify_1 As TextObject
    '            Dim Notify_2 As TextObject
    '            Dim Notify_3 As TextObject
    '            Dim Notify_4 As TextObject
    '            Dim Notify_5 As TextObject
    '            Dim Notify_6 As TextObject

    '            Shipper_1 = rpt.ReportDefinition.ReportObjects("Shipper1")
    '            Shipper_1.Text = " 1) " & oTableCustomerInfo.Rows(0).Item("Shipper_1").ToString
    '            Shipper_2 = rpt.ReportDefinition.ReportObjects("Shipper2")
    '            Shipper_2.Text = oTableCustomerInfo.Rows(0).Item("Shipper_2").ToString
    '            Shipper_3 = rpt.ReportDefinition.ReportObjects("Shipper3")
    '            Shipper_3.Text = oTableCustomerInfo.Rows(0).Item("Shipper_3").ToString
    '            Shipper_4 = rpt.ReportDefinition.ReportObjects("Shipper4")
    '            Shipper_4.Text = oTableCustomerInfo.Rows(0).Item("Shipper_4").ToString
    '            Shipper_5 = rpt.ReportDefinition.ReportObjects("Shipper5")
    '            Shipper_5.Text = oTableCustomerInfo.Rows(0).Item("Shipper_5").ToString
    '            Shipper_6 = rpt.ReportDefinition.ReportObjects("Shipper6")
    '            Shipper_6.Text = oTableCustomerInfo.Rows(0).Item("Shipper_6").ToString

    '            Consignee_1 = rpt.ReportDefinition.ReportObjects("Consignee1")
    '            Consignee_1.Text = " 2) " & oTableCustomerInfo.Rows(0).Item("Consignee_1").ToString
    '            Consignee_2 = rpt.ReportDefinition.ReportObjects("Consignee2")
    '            Consignee_2.Text = oTableCustomerInfo.Rows(0).Item("Consignee_2").ToString
    '            Consignee_3 = rpt.ReportDefinition.ReportObjects("Consignee3")
    '            Consignee_3.Text = oTableCustomerInfo.Rows(0).Item("Consignee_3").ToString
    '            Consignee_4 = rpt.ReportDefinition.ReportObjects("Consignee4")
    '            Consignee_4.Text = oTableCustomerInfo.Rows(0).Item("Consignee_4").ToString
    '            Consignee_5 = rpt.ReportDefinition.ReportObjects("Consignee5")
    '            Consignee_5.Text = oTableCustomerInfo.Rows(0).Item("Consignee_5").ToString
    '            Consignee_6 = rpt.ReportDefinition.ReportObjects("Consignee6")
    '            Consignee_6.Text = oTableCustomerInfo.Rows(0).Item("Consignee_6").ToString

    '            Notify_1 = rpt.ReportDefinition.ReportObjects("Notify1")
    '            Notify_1.Text = " 3) " & oTableCustomerInfo.Rows(0).Item("Notify_1").ToString
    '            Notify_2 = rpt.ReportDefinition.ReportObjects("Notify2")
    '            Notify_2.Text = oTableCustomerInfo.Rows(0).Item("Notify_2").ToString
    '            Notify_3 = rpt.ReportDefinition.ReportObjects("Notify3")
    '            Notify_3.Text = oTableCustomerInfo.Rows(0).Item("Notify_3").ToString
    '            Notify_4 = rpt.ReportDefinition.ReportObjects("Notify4")
    '            Notify_4.Text = oTableCustomerInfo.Rows(0).Item("Notify_4").ToString
    '            Notify_5 = rpt.ReportDefinition.ReportObjects("Notify5")
    '            Notify_5.Text = oTableCustomerInfo.Rows(0).Item("Notify_5").ToString
    '            Notify_6 = rpt.ReportDefinition.ReportObjects("Notify6")
    '            Notify_6.Text = oTableCustomerInfo.Rows(0).Item("Notify_6").ToString
    '        End If
    '        ' không cân phần thêm giá container
    '        For i = 0 To IIf(oTableFreight.Rows.Count - 1 > 8, 8, oTableFreight.Rows.Count - 1)
    '            Dim strFreight As String = ""
    '            Dim Freight As TextObject
    '            Freight = rpt.ReportDefinition.ReportObjects("freight" & i + 1)
    '            strFreight &= oTableFreight.Rows(i).Item("Quantity").ToString & " X "
    '            strFreight &= oTableFreight.Rows(i).Item("CONTAINER_TYPE").ToString & " "
    '            'strFreight &= oTableFreight.Rows(i).Item("Items").ToString & " "

    '            'strFreight &= oTableFreight.Rows(i).Item("CURRENCY").ToString
    '            'strFreight &= oTableFreight.Rows(i).Item("UNITPRICE").ToString & " / "
    '            'strFreight &= oTableFreight.Rows(i).Item("CONTAINER_TYPE").ToString & " "
    '            Freight.Text = strFreight
    '            'Dim pop As TextObject
    '            'pop = rpt.ReportDefinition.ReportObjects("POP" & i + 1)
    '            'pop.Text = oTableFreight.Rows(i).Item("POP_Code").ToString
    '            'Dim Pre_Col As TextObject
    '            'If UCase(oTableFreight.Rows(i).Item("PREPAID_COLLECT").ToString) = "COLLECT" Then
    '            '    Pre_Col = rpt.ReportDefinition.ReportObjects("COLLECT" & i + 1)
    '            'Else
    '            '    Pre_Col = rpt.ReportDefinition.ReportObjects("PREPAID" & i + 1)
    '            'End If
    '            'Pre_Col.Text = oTableFreight.Rows(i).Item("CURRENCY").ToString & oTableFreight.Rows(i).Item("UNITPRICE").ToString
    '        Next
    '        QueryAmountcontainer()
    '        If oTableFreight.Rows.Count = 0 Then
    '            Dim strFreight As String = ""
    '            Dim Freight As TextObject
    '            For j As Integer = 0 To oTableAmountContainer.Rows.Count - 1
    '                strFreight = ""
    '                Freight = rpt.ReportDefinition.ReportObjects("freight" & j + 1)
    '                strFreight &= oTableAmountContainer.Rows(j).Item("Amount").ToString & " X "
    '                strFreight &= oTableAmountContainer.Rows(j).Item("CONTAINER_TYPE").ToString & " "
    '                Freight.Text = strFreight
    '            Next


    '        End If

    '        If oTableBill.Rows.Count > 0 Then
    '            Dim Vessel, BillNo, CY, Description, BillType, Voyage, por, pol, pod, del, dest, Objmanifest As TextObject


    '            Dim CargoMarks As TextObject
    '            CargoMarks = rpt.ReportDefinition.ReportObjects("CargoMarks")
    '            Dim Temp1(), Result1 As String
    '            Result1 = oTableBill.Rows(0).Item("Marks").ToString
    '            Temp1 = Strings.Split(Result1, Chr(13))
    '            Result1 = ""
    '            For j As Integer = 0 To Temp1.Length - 1
    '                Result1 &= Temp1(j)
    '                If Temp1(j).Trim.Length > 0 Then
    '                    For k As Integer = Temp1(j).Length To CargoMarks.Width \ 10
    '                        Result1 &= " "
    '                    Next
    '                End If
    '            Next
    '            CargoMarks.Text = Result1

    '            'cho xuông hàng của description 
    '            Description = rpt.ReportDefinition.ReportObjects("DESCRIPTION")
    '            Dim Temp(), Result As String
    '            ' Dim tempTextObject As TextObject
    '            Result = oTableBill.Rows(0).Item("DESCRIPTIONOFGOODS").ToString
    '            Temp = Strings.Split(Result, Chr(13))
    '            Result = ""
    '            For j As Integer = 0 To Temp.Length - 1

    '                Result &= Temp(j)
    '                If Temp(j).Trim.Length > 0 Then
    '                    For k As Integer = Temp(j).Length To Description.Width \ 10
    '                        Result &= " "
    '                    Next
    '                End If
    '            Next
    '            Description.Text = Result


    '            BillNo = rpt.ReportDefinition.ReportObjects("BL_NO")
    '            BillNo.Text = oTableBill.Rows(0).Item("BLIB_NO").ToString

    '            CY = rpt.ReportDefinition.ReportObjects("CY")
    '            CY.Text = oTableBill.Rows(0).Item("CY_CFS_ITEM").ToString

    '            BillType = rpt.ReportDefinition.ReportObjects("BL_type")
    '            BillType.Text = oTableBill.Rows(0).Item("BL_TYPE").ToString

    '            Vessel = rpt.ReportDefinition.ReportObjects("Vessel")
    '            Vessel.Text = oTableBill.Rows(0).Item("VESSEL").ToString

    '            Voyage = rpt.ReportDefinition.ReportObjects("Voyage")
    '            Voyage.Text = oTableBill.Rows(0).Item("VOYAGE").ToString

    '            por = rpt.ReportDefinition.ReportObjects("por")
    '            por.Text = oTableBill.Rows(0).Item("por").ToString


    '            pol = rpt.ReportDefinition.ReportObjects("pol")
    '            pol.Text = oTableBill.Rows(0).Item("pol").ToString

    '            pod = rpt.ReportDefinition.ReportObjects("pod")
    '            pod.Text = oTableBill.Rows(0).Item("pod").ToString

    '            del = rpt.ReportDefinition.ReportObjects("del")
    '            del.Text = oTableBill.Rows(0).Item("del").ToString

    '            dest = rpt.ReportDefinition.ReportObjects("dest")
    '            dest.Text = oTableBill.Rows(0).Item("dest").ToString

    '            Objmanifest = rpt.ReportDefinition.ReportObjects("txttongso")
    '            Objmanifest.Text = "Manifest : " + manifest + " in " + manifests

    '        End If
    '        rpt.SetDataSource(oTableCargoInfo)
    '        Me.CrystalReportViewer1.ReportSource = rpt
    '        Me.CrystalReportViewer1.Refresh()
    '        Me.CrystalReportViewer1.Show()
    '        'rpt.PrintToPrinter(1, True, 1, 100)

    '    End Sub

    '    'Sub QueryBillNo(ByVal BillNo As String)
    '    '    Try
    '    '        Dim strQuery As String = "Select BLIb_ID from BillOfladingIb Where BLIB_NO='" & Me.txtBLIB_NO.Text.Trim & "' And Continued=1"
    '    '        Dim Conn As New SqlClient.SqlConnection(strconnDG)
    '    '        Conn.Open()
    '    '        Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
    '    '        Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
    '    '        Dim dt As New DataTable
    '    '        Adapter.Fill(dt)
    '    '        If dt.Rows.Count > 0 Then
    '    '            gBillInboundID = dt.Rows(0).Item("BLIB_ID").ToString
    '    '        Else
    '    '            gBillInboundID = ""
    '    '            MsgBox("no this bill")
    '    '        End If
    '    '    Catch ex As Exception
    '    '        MsgBox(Err.Description)
    '    '    End Try
    '    'End Sub

    '    Private Sub frmRptInboundManifest_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Try
    '            Dim tempvessel() As String
    '            tempvessel = Strings.Split(frmPrintAllManifest.cboVessel.Text, " - ")
    '            vessel = IIf(tempvessel.Length > 0, tempvessel(0), "")
    '            VoyNo = IIf(tempvessel.Length > 1, tempvessel(1), "")

    '            QueryAllBill(vessel, VoyNo)
    '            Me.cboBLIB_NO.SelectedValue = gBillInboundID
    '            'cmdOk_Click(sender, e)

    '            If frmPrintAllManifest.chkAll.Checked = True Then
    '                For k As Integer = 0 To oTableAllBill.Rows.Count - 1
    '                    gBillInboundID = oTableAllBill.Rows(k).Item("BLIB_ID").ToString.Trim
    '                    PrintReport(CStr(k + 1), CStr(oTableAllBill.Rows.Count))
    '                    rpt.PrintToPrinter(1, True, 1, 100)
    '                    rpt = Nothing
    '                Next
    '                MsgBox("Complete")
    '                Me.Close()
    '            Else
    '                PrintReport("1", "1")
    '                rpt = Nothing
    '            End If
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try


    '    End Sub

    '    Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
    '        Try

    '            rpt.PrintToPrinter(1, True, 1, 100)

    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try
    '    End Sub

    '    Private Sub cboBLIB_NO_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBLIB_NO.Leave
    '        On Error GoTo Err_Renamed
    '        Dim strSql, Port_code As String
    '        Me.cboBLIB_NO.Text = Trim(UCase(Me.cboBLIB_NO.Text))
    '        strSql = "Select BLIB_No as BLIB_No From BillOfLadingIB Where Continued=1"
    '        If Me.cboBLIB_NO.FindStringExact(Me.cboBLIB_NO.Text) = -1 Then
    '            Me.cboBLIB_NO.Text = FindBetter_new("BLIB_No", strSql, Me.cboBLIB_NO.Text)
    '            If Me.cboBLIB_NO.FindStringExact(Me.cboBLIB_NO.Text) = -1 Then
    '                DisplayMessage(True, "The Port is invalid, please check and correct it.")
    '                Me.cboBLIB_NO.Focus()
    '            End If
    '        End If
    '        Exit Sub
    'Err_Renamed:
    '        MsgBox(msgErr(Me, Err.Description))
    '    End Sub

    '    Private Sub cboBLIB_NO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBLIB_NO.SelectedIndexChanged
    '        Try
    '            If Me.cboBLIB_NO.Text = "" Then
    '                Return
    '            End If
    '            gBillInboundID = Me.cboBLIB_NO.SelectedValue.ToString
    '            Me.CrystalReportViewer1.Dock = DockStyle.Bottom
    '            PrintReport("1", "1")
    '            rpt = Nothing
    '        Catch ex As Exception
    '            MsgBox(Err.Description)
    '        End Try
    '    End Sub
End Class