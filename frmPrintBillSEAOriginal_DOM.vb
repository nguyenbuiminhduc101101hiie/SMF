Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmPrintBillSEAOriginal_DOM
    Dim Vessel, VoyAge As String
    Public oTableCustomerInfo, oTableremarks As DataTable
    Public dsCustomerInfo As New DataSet

    Public oTableBillOfLading As DataTable
    Public dsBillOfLading As New DataSet
    '------------------
    Public oTableCargoInfo As DataTable
    Public dsCargoInfo As New DataSet
    Public flag As Integer
    Dim oTableCountContainerType As New DataTable

    Const strBillOfLadingSelect As String = "SELECT BillOfLadingIB.BLIB_Id as BillOfLadingId,BillOfLadingIB.BLIB_NO , " & _
" Vessel as OCeanVessel,VoyAge," & _
     "POR,REF, " & _
     "PoL,DEST,ICDPort, " & _
      "PoD, " & _
      "Del, " & _
      "DESCRIPTIONFORSHIPPER, DESCRIPTIONOFGOODS,MARKS,CY_CFS_ITEM," & _
        " BL_TYPE "

    Const strCargo As String = "Select Container.CONTAINER_NO,Seal,Container.CTN_SIZE_TYPE," & _
 "Amount,Kind,RECEIVEDATE,Note,Meas,MeasUnit,GROSSWEIGHT,GROSSUNIT "

    Const strCustomerInfo As String = "Select Shipper, " & _
   "" & _
       " " & _
       " " & _
   " " & _
       "" & _
       " " & _
       "Consignee, " & _
   " " & _
       "" & _
       " " & _
       "Notify  "

    Private Function MakeQueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed

        MakeQueryCustomerInfo = strCustomerInfo

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  FROM " & gPrintOutbound & " "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " BLOB_ID= '" & gLogisticsID & "' And Continued=1"
        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub QueryCustomerInfo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCustomerInfo()
        Else
            strQuery = MakeQueryCustomerInfo(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCustomerInfo) Then
            oTableCustomerInfo.Clear()
        End If
        Adapter.Fill(dsCustomerInfo, "BillOfLadingList")
        oTableCustomerInfo = dsCustomerInfo.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Function MakeQueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryBillOfLading = " select * from " & gPrintOutbound & " "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & "  FROM  BillOfLadingIB "

        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE (BLoB_ID = '" & gLogisticsID & "') "

        MakeQueryBillOfLading = MakeQueryBillOfLading & "  "
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryBillOfLading = MakeQueryBillOfLading() & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub QueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryBillOfLading()
        Else
            strQuery = MakeQueryBillOfLading(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableBillOfLading) Then
            oTableBillOfLading.Clear()
        End If
        Adapter.Fill(dsBillOfLading, "BillOfLadingList")
        oTableBillOfLading = dsBillOfLading.Tables(0)

        'If oTableBillOfLading.Rows.Count > 0 Then
        '    Vessel = oTableBillOfLading.Rows(0).Item("OceanVessel").ToString
        '    VoyAge = oTableBillOfLading.Rows(0).Item("VoyAge").ToString
        'End If
        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Function MakeQueryCargo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1) As String
        On Error GoTo Err_Renamed
        MakeQueryCargo = " select * from containerlogistics "

        '  MakeQueryCargo = MakeQueryCargo & " FROM (CargoIB left join Container on CargoIB.CTN_ID=Container.CTN_ID )"
        MakeQueryCargo = MakeQueryCargo & "WHERE (outboundid = '" & gLogisticsID & "') "
        'MakeQueryCargo = MakeQueryCargo & "And ("
        'MakeQueryCargo = MakeQueryCargo & "CargoIB.Continued = 1 "
        'MakeQueryCargo = MakeQueryCargo & ") Order By CARGOIB.STT"
        If Not IsNothing(argCriteria) And argCriteria <> "" Then
            MakeQueryCargo = MakeQueryCargo & argCriteria
        End If

        'Debug.Print MakeQueryCommodity
        Exit Function
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
    End Function

    Private Sub QueryCargo(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        If IsNothing(argCriteria) Then
            strQuery = MakeQueryCargo()
        Else
            strQuery = MakeQueryCargo(argCriteria, index)
        End If
        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableCargoInfo) Then
            oTableCargoInfo.Clear()
        End If
        Adapter.Fill(dsCargoInfo, "BillOfLadingList")
        oTableCargoInfo = dsCargoInfo.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub

    Private Sub QueryRemark(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------

        strQuery = "SELECT * "
        strQuery = strQuery & "FROM logistics "
        strQuery = strQuery & "WHERE BLOB_id = '" & gLogisticsID & "' And Continued=1"

        Dim CmdSelect As New SqlClient.SqlCommand(strQuery, Con)
        Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
        '-----------------
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Con.Open()
        If Not IsNothing(oTableremarks) Then
            oTableremarks.Clear()
        End If
        Adapter.Fill(ds, "remarks")
        oTableremarks = ds.Tables(0)


        'hien thi ra grid 
        '--------------------
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Exit Sub
Err_Renamed:
        MsgBox(msgErr(Me, Err.Description))
        'Resume
    End Sub
    Sub QueryCountContainer()
        Try
            'Dim strQuery As String
            'strQuery = " Select Container_Type,Count(Container_type) as Num From CargoIB"
            'strQuery &= " Where BLIB_ID='" & gBillInboundID & "' And Continued=1 Group By Container_type"
            'Dim Conn As New SqlClient.SqlConnection(strconnDG)
            'Conn.Open()
            'Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            'Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            'If oTableCountContainerType.Rows.Count > 0 Then
            '    oTableCountContainerType.Rows.Clear()
            'End If
            'Adapter.Fill(oTableCountContainerType)
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub

    Function CheckLCLCargo() As Boolean
        Try
            Dim SQL As String
            SQL = "select Top 1 Container_No "
            SQL &= " From ((CargoIb Inner Join BillOfLadingIb On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
            SQL &= " INNER Join Container On Container.CTN_ID=CargoIb.CTN_ID)"
            SQL &= " Where Vessel='" & Vessel & "' And VoyAge='" & VoyAge & "' And CargoIB.Continued=1 And BLIB_NO <>'" & gBillNoInBound & "'"
            SQL &= " And Container_No In "
            SQL &= "(Select Container_No From ((CargoIb Inner Join BillOfLadingIb On CargoIB.BLIB_ID=BillOfLadingIB.BLIB_ID) "
            SQL &= " INNER Join Container On Container.CTN_ID=CargoIb.CTN_ID) Where BLIB_NO='" & gBillNoInBound & "' And CargoIB.continued=1) "
            SQL &= " And (select count(*) from (Freight_Charge_IB LEFT JOIN BillOfLadingIB On Freight_Charge_IB.BLIB_ID=BillOfLadingIB.BLIB_ID) Where BLIB_No='" & gBillNoInBound & "')=0"
            Dim dt As New DataTable
            dt = ReadTable(SQL)
            If dt.Rows.Count = 0 Then
                Return False
            End If
            Return True
        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try
    End Function

    Public Sub PRINTREPORT()
        On Error GoTo Err
        Dim rptDoCument, mymargins
        Dim strReportName As String
        Dim strQuery As String
        QueryBillOfLading()
        QueryCargo()
        QueryCustomerInfo()
        QueryRemark()
        rptDoCument = New ReportDocument        ' ten Report
        Dim N As Integer = IIf(oTableCargoInfo.Rows.Count - 1 > 19, 19, oTableCargoInfo.Rows.Count - 1)
        Dim t As Integer = oTableCargoInfo.Rows.Count - 1 - N

        If flag = 0 Then
            rptDoCument = New ReportDocument
            '----------
            ' ten Report
            strReportName = "ReportDeliveryOrderData"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            '----------
        Else
            If t > 0 Then
                strReportName = "ReportArrival20"
            Else
                strReportName = "ReportArrival"
            End If

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'Formatting paper

        End If


        Dim BL As TextObject
        BL = rptDoCument.ReportDefinition.ReportObjects("BL_NO")
        BL.Text = gBillNoInBound

        If oTableCustomerInfo.Rows.Count > 0 Then
            Dim shipper, consignee, notify As TextObject
            Dim tempshipper, tempconsignee, tempnotify As String
            For i As Integer = 1 To 6
                tempshipper = oTableCustomerInfo.Rows(0).Item("Shipper_" & i).ToString
                shipper = rptDoCument.ReportDefinition.ReportObjects("Shipper_" & i)
                shipper.Text = tempshipper

                tempconsignee = oTableCustomerInfo.Rows(0).Item("Consignee_" & i).ToString
                consignee = rptDoCument.ReportDefinition.ReportObjects("Consignee_" & i)
                consignee.Text = tempconsignee

                tempnotify = oTableCustomerInfo.Rows(0).Item("Notify_" & i).ToString
                notify = rptDoCument.ReportDefinition.ReportObjects("Notify_" & i)
                notify.Text = tempnotify

            Next
        End If
        If oTableBillOfLading.Rows.Count > 0 Then
            Dim icdPort, PreVessel, Vessel, Voyno, POR, POD, POL, DEL, DEST, DESC, Marks, CY_CFS, Shipment, STATUSSEND As TextObject
            Dim REF1 As TextObject
            If flag = 1 Then
                REF1 = rptDoCument.ReportDefinition.ReportObjects("REF")
                REF1.Text = oTableBillOfLading.Rows(0).Item("REF").ToString
                STATUSSEND = rptDoCument.ReportDefinition.ReportObjects("TXTSTATUSSEND")
                STATUSSEND.Text = frmInBoundRemarks.ComboBox1.Text
            End If
            'If flag = 1 Then
            '    Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
            '    Vessel.Text = oTableBillOfLading.Rows(0).Item("OCeanVessel").ToString & " - " & oTableBillOfLading.Rows(0).Item("VoyAge").ToString
            'Else
            Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
            Vessel.Text = oTableBillOfLading.Rows(0).Item("OCeanVessel").ToString

            Voyno = rptDoCument.ReportDefinition.ReportObjects("VoyNo")
            Voyno.Text = oTableBillOfLading.Rows(0).Item("VoyAge").ToString


            'End If

            'PreVessel = rptDoCument.ReportDefinition.ReportObjects("Pre")
            'PreVessel.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString

            POR = rptDoCument.ReportDefinition.ReportObjects("POR")
            POR.Text = oTableBillOfLading.Rows(0).Item("POR").ToString



            POL = rptDoCument.ReportDefinition.ReportObjects("POL")
            POL.Text = oTableBillOfLading.Rows(0).Item("POL").ToString

            POD = rptDoCument.ReportDefinition.ReportObjects("POD")
            POD.Text = oTableBillOfLading.Rows(0).Item("POD").ToString

            DEL = rptDoCument.ReportDefinition.ReportObjects("DEL")
            DEL.Text = oTableBillOfLading.Rows(0).Item("DEL").ToString

            DEST = rptDoCument.ReportDefinition.ReportObjects("DEST")
            DEST.Text = oTableBillOfLading.Rows(0).Item("DEST").ToString

            CY_CFS = rptDoCument.ReportDefinition.ReportObjects("CY_CFS")
            CY_CFS.Text = oTableBillOfLading.Rows(0).Item("CY_CFS_ITEM").ToString

            Shipment = rptDoCument.ReportDefinition.ReportObjects("Shipment")
            Shipment.Text = oTableBillOfLading.Rows(0).Item("shipemt").ToString

            icdPort = rptDoCument.ReportDefinition.ReportObjects("txticdPort")
            icdPort.Text = oTableBillOfLading.Rows(0).Item("ICDPort").ToString

            '''''''''''''''''''''''''''''''''''''
            'Description og goods

            DESC = rptDoCument.ReportDefinition.ReportObjects("Description")
            Dim Temp(), Result As String
            Dim tempTextObject As TextObject
            Result = oTableBillOfLading.Rows(0).Item("DESCRIPTIONOFGOODS").ToString
            Temp = Strings.Split(Result, Chr(13))
            QueryCountContainer()
            Result = ""
            If CheckLCLCargo() = True Then
                Result = " Part Of Containers                                                      "
            End If
            'If oTableCountContainerType.Rows.Count > 0 Then
            '    For i As Integer = 0 To oTableCountContainerType.Rows.Count - 1
            '        Result &= IIf(oTableCountContainerType.Rows(i).Item("Num") < 9, "0" & oTableCountContainerType.Rows(i).Item("Num").ToString, oTableCountContainerType.Rows(i).Item("Num").ToString) & " X " & oTableCountContainerType.Rows(i).Item("Container_Type").ToString
            '        Result &= " & "
            '    Next
            '    Result = Result.Remove(Result.Length - 2)
            '    If oTableCountContainerType.Rows.Count = 1 Then
            '        Result &= " CONTAINER ONLY                                                                                                                                                        "
            '    Else
            '        Result &= "                                                                                                                                                                         "
            '    End If
            'Else
            '    Result = ""
            'End If
            For j As Integer = 0 To Temp.Length - 1
                Result &= Temp(j)
                For k As Integer = Temp(j).Length To DESC.Width \ 50
                    Result &= "     "
                Next
            Next
            DESC.Text = Result
        End If
        If oTableCargoInfo.Rows.Count > 0 Then
            Dim container, Gross, CBM As TextObject
            Dim tempContainer As String = ""
            Dim Dgross, Dcbm As Double
            Dim kgsUnit, cbmUnit As String
            Dgross = 0
            Dcbm = 0
            Dim row As DataRow


            'xư ly các contanier nhiều hơn số container giới hiện thi trên bill 
            If t > 0 Then
                Dim AttachContainer, BL_NO1, AttachTitle, ToTalAttachContainer As TextObject
                Dim strAttachContainer As String = ""
                MsgBox("This bill has attach list! ")
                'AttachTitle = rptDoCument.ReportDefinition.ReportObjects("attachTitle")
                'AttachTitle.Text = "Attach Container"
                BL_NO1 = rptDoCument.ReportDefinition.ReportObjects("BL_NO1")
                BL_NO1.Text = gBillNoInBound

                ToTalAttachContainer = rptDoCument.ReportDefinition.ReportObjects("ToTalAttachContainer")
                ToTalAttachContainer.Text = "Total : " & oTableCargoInfo.Rows.Count & " Containers"

                For i As Integer = 0 To oTableCargoInfo.Rows.Count - 1
                    If i <= 8 Then
                        strAttachContainer &= "(0"
                    Else
                        strAttachContainer &= "("

                    End If
                    strAttachContainer &= i + 1 & ")   " & oTableCargoInfo.Rows(i).Item("Container_No").ToString.Trim
                    strAttachContainer &= "                  " & oTableCargoInfo.Rows(i).Item("CTN_SIZE_TYPE").ToString.Trim & "                  "
                    strAttachContainer &= oTableCargoInfo.Rows(i).Item("Seal").ToString.Trim & "                                                                "
                    Dgross += IIf(oTableCargoInfo.Rows(i).Item("GrossWeight").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("GrossWeight"), 0)
                    Dcbm += IIf(oTableCargoInfo.Rows(i).Item("Meas").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("Meas"), 0)
                    kgsUnit = oTableCargoInfo.Rows(i).Item("GrossUnit").ToString
                    cbmUnit = oTableCargoInfo.Rows(i).Item("measUnit").ToString
                Next

                AttachContainer = rptDoCument.ReportDefinition.ReportObjects("ContainerAttach")
                AttachContainer.Text = strAttachContainer
                container = rptDoCument.ReportDefinition.ReportObjects("Container")
                container.Text = "Attach List"
                Gross = rptDoCument.ReportDefinition.ReportObjects("Gross")
                Gross.Text = FormatNumber(Dgross, 2) + kgsUnit
                CBM = rptDoCument.ReportDefinition.ReportObjects("CBM")
                CBM.Text = FormatNumber(Dcbm, 2) + cbmUnit
            Else
                For i As Integer = 0 To N
                    Dgross += IIf(oTableCargoInfo.Rows(i).Item("GrossWeight").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("GrossWeight"), 0)
                    Dcbm += IIf(oTableCargoInfo.Rows(i).Item("Meas").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("Meas"), 0)
                    tempContainer &= oTableCargoInfo.Rows(i).Item("CONTAINER_NO").ToString & " /" & oTableCargoInfo.Rows(i).Item("CTN_SIZE_TYPE").ToString & " /" & oTableCargoInfo.Rows(i).Item("Seal").ToString
                    tempContainer &= "                                                                                                   "
                Next
                Gross = rptDoCument.ReportDefinition.ReportObjects("Gross")
                Gross.Text = FormatNumber(Dgross, 2) + kgsUnit

                CBM = rptDoCument.ReportDefinition.ReportObjects("CBM")
                CBM.Text = FormatNumber(Dcbm, 2) + cbmUnit

                container = rptDoCument.ReportDefinition.ReportObjects("Container")
                container.Text = tempContainer
            End If
        End If
        If oTableremarks.Rows.Count > 0 Then
            Dim arrival, demurage, payment, Shipment, note As TextObject
            arrival = rptDoCument.ReportDefinition.ReportObjects("Arrival")
            arrival.Text = CDate(oTableremarks.Rows(0).Item("ArrivalDate").ToString)
            If frmInBoundRemarks.chkPrint.Checked Then
                demurage = rptDoCument.ReportDefinition.ReportObjects("Demurage")
                demurage.Text = CDate(oTableremarks.Rows(0).Item("Demurage").ToString)
            End If

            payment = rptDoCument.ReportDefinition.ReportObjects("Payment")
            payment.Text = oTableremarks.Rows(0).Item("Prepaid_Collect").ToString
            payment.Text &= "  -  " & IIf(oTableBillOfLading.Rows.Count > 0, oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString, "")
            'note = rptDoCument.ReportDefinition.ReportObjects("note")
            'note.Text = oTableremarks.Rows(0).Item("note").ToString

        End If
        Dim dt As Date
        dt = frmInBoundRemarks.dtpPrintdate.Value
        Dim d, m, y As TextObject
        d = rptDoCument.ReportDefinition.ReportObjects("Day")
        d.Text = dt.Day
        m = rptDoCument.ReportDefinition.ReportObjects("Month")
        m.Text = dt.Month
        y = rptDoCument.ReportDefinition.ReportObjects("Year")
        y.Text = dt.Year
        ApplyCrystalDatabaseLogon(rptDoCument)
        Me.CrystalReportViewer1.ReportSource = rptDoCument
        'Formatting paper

        If flag = 1 Then
            mymargins = rptDoCument.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM
            rptDoCument.PrintOptions.ApplyPageMargins(mymargins)
        End If

        If frmMain.mnuReportOrientationPortrait.Checked Then
            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
        Else
            rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
        End If
        rptDoCument.Refresh()
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.Show()
        'Dim strMesg As String = "Print this Arrival Note! ?"
        'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
        '    rptDoCument.Refresh()
        '    rptDoCument.PrintToPrinter(1, True, 1, 1)
        'End If

        Exit Sub
Err:
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Sub PrintRpt()
        Try
            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String
            QueryBillOfLading()
            QueryCargo()
            QueryCustomerInfo()
            QueryRemark()
            'Dim N As Integer = IIf(oTableCargoInfo.Rows.Count - 1 > 16, 16, oTableCargoInfo.Rows.Count - 1)
            'Dim k As Integer = oTableCargoInfo.Rows.Count - 1 - N
            'If flag = 0 Then
            '    rptDoCument = New ReportDocument
            '    '----------
            '    ' ten Report
            '    strReportName = "ReportDeliveryOrderData"
            '    Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            '    If Not IO.File.Exists(strReportPath) Then
            '        DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
            '        Exit Sub
            '    End If
            '    rptDoCument.Load(strReportPath)
            '    '----------
            'Else
            rptDoCument = New ReportDocument
            If Me.chkDraft.Checked = True Then
                'If Me.chkAttachlist.Checked = False Then
                'If UCase(oTableBillOfLading.Rows(0).Item("FCL").ToString) = "TRUE" Then
                '    strReportName = "rptHouseBillData_hinh"
                'Else
                '    strReportName = "rptHouseBillData_hinh_LCL"
                'End If
                'Else
                'If UCase(oTableBillOfLading.Rows(0).Item("FCL").ToString) = "TRUE" Then
                'If Me.chkALPine.Checked = True Then
                '    If Me.chkContainer.Checked = True Then
                '        strReportName = "rptHouseBillData_alpine_hinh_attachlist"
                '    Else
                '        strReportName = "rptHouseBillData_alpine_hinh"
                '    End If
                'Else
                If Me.chkContainer.Checked = True Or Me.chkAttachDesc.Checked = True Or Me.chkAttachShippingMarks.Checked = True Then
                    strReportName = "rptHouseBillData_hinh_attachlist_vestal"
                Else
                    strReportName = "rptHouseBillData_hinh_vestal"
                End If
                ' End If


                'Else
                '    If Me.chkContainer.Checked = True Then
                '        strReportName = "rptHouseBillData_hinh_LCL_attachlist"
                '    Else
                '        strReportName = "rptHouseBillData_hinh_LCL"
                '    End If

                'End If
                ' End If

            Else
                'If UCase(oTableBillOfLading.Rows(0).Item("FCL").ToString) = "TRUE" Then
                'If Me.chkALPine.Checked = True Then
                '    If Me.chkContainer.Checked = True Then
                '        strReportName = "rptHouseBillData_alpine_attachlist"
                '    Else
                '        strReportName = "rptHouseBillData_alpine"
                '    End If
                'Else
                If Me.chkContainer.Checked = True Or Me.chkAttachDesc.Checked = True Or Me.chkAttachShippingMarks.Checked = True Then
                    strReportName = "rptHouseBillData_attachlist_vestal"
                Else
                    strReportName = "rptHouseBillData_vestal"
                End If
                ' End If


                'Else
                '    If Me.chkContainer.Checked = True Then
                '        strReportName = "rptHouseBillData_LCL_attachlist"
                '    Else
                '        strReportName = "rptHouseBillData_LCL"
                '    End If

                'End If

            End If
            ' ten Report
            'If k > 0 Or Me.chkAttachDescription.Checked = True Then
            '    strReportName = "ReportArrival"
            'Else
            '    strReportName = "ReportArrivalnoat"
            'End If
            'If Me.chkCheckAir.Checked = True Then
            '    strReportName = "ReportArrivalnoat_air"
            'End If

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'Formatting paper

            ' End If


            Dim BL, MBL, HBL, ngayin, totalprepaidIn, prepaidAt, revenueTons As TextObject
            'BL = rptDoCument.ReportDefinition.ReportObjects("BL_NO")
            'BL.Text = gBillNoInBound
            'ngayin = rptDoCument.ReportDefinition.ReportObjects("txtngay")
            'ngayin.Text = "Ngày " + CDate(Getdate()).Date.ToString.Replace("12:00:00 AM", "")

            Dim shipperTam, ConsigneeTam, NotifyTam As String
            Dim shipperTam1(), ConsigneeTam1(), NotifyTam1() As String
            If oTableCustomerInfo.Rows.Count > 0 Then
                Dim shipper, consignee, notify As TextObject
                Dim tempshipper, tempconsignee, tempnotify As String
                'For i As Integer = 1 To 6
                'tempshipper = oTableCustomerInfo.Rows(0).Item("Shipper").ToString
                'shipper = rptDoCument.ReportDefinition.ReportObjects("Shipper1")
                'shipper.Text = tempshipper
                shipper = rptDoCument.ReportDefinition.ReportObjects("shipper_1")
                'consignee.Text = tempconsignee
                '------ xuong hang
                If Me.chkshowbillOther.Checked = True Then
                    shipperTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("shipperother").ToString, Chr(13))
                Else
                    shipperTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("shipper").ToString, Chr(13))
                End If

                For CountA As Integer = 0 To shipperTam1.Length - 1
                    shipperTam &= shipperTam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = shipperTam1(CountA).Length To shipper.Width \ 10
                        shipperTam &= " "
                    Next
                Next
                If Me.chkthru.Checked = True Then
                    shipper.Text = ""
                Else
                    shipper.Text = shipperTam
                End If

                'tempconsignee = oTableCustomerInfo.Rows(0).Item("Consignee").ToString
                consignee = rptDoCument.ReportDefinition.ReportObjects("Consignee_1")
                'consignee.Text = tempconsignee
                '------ xuong hang
                If Me.chkshowbillOther.Checked = True Then
                    ConsigneeTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Consigneeother").ToString, Chr(13))
                Else
                    ConsigneeTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Consignee").ToString, Chr(13))
                End If

                For CountA As Integer = 0 To ConsigneeTam1.Length - 1
                    ConsigneeTam &= ConsigneeTam1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = ConsigneeTam1(CountA).Length To consignee.Width \ 10
                        ConsigneeTam &= " "
                    Next
                Next
                consignee.Text = ConsigneeTam
                'tempnotify = oTableCustomerInfo.Rows(0).Item("Notify").ToString
                'notify = rptDoCument.ReportDefinition.ReportObjects("Notify1")
                'notify.Text = tempnotify'
                '---------------------------
                notify = rptDoCument.ReportDefinition.ReportObjects("notify_1")
                'consignee.Text = tempconsignee
                '------ xuong hang
                If Me.chkshowbillOther.Checked = True Then
                    NotifyTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("notifyOther").ToString, Chr(13))
                Else
                    NotifyTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("notify").ToString, Chr(13))
                End If

                For CountA As Integer = 0 To NotifyTam1.Length - 1
                    NotifyTam &= NotifyTam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = NotifyTam1(CountA).Length To notify.Width \ 10
                        NotifyTam &= " "
                    Next
                Next
                notify.Text = NotifyTam

                'Next
            End If
            If oTableBillOfLading.Rows.Count > 0 Then
                Dim mbl1, SHOWONBOARD, ref, BLtYPE, icdPort, prepaid, collect, numberOfOriginal, placeandDate, OnboardDate, ShipperRef, PreightCharges, PreVessel, Vessel, Voyno, POR, POD, POL, DEL, DEST, DESC, Marks, CY_CFS, Shipment, STATUSSEND As TextObject
                Dim REF1, saycontainer, totalP, totalG, totalC As TextObject
                If oTableBillOfLading.Rows(0).Item("tongkien").ToString = "" Or oTableBillOfLading.Rows(0).Item("tongkien").ToString = "0" Then

                Else
                    totalP = rptDoCument.ReportDefinition.ReportObjects("totalp")
                    totalP.Text = oTableBillOfLading.Rows(0).Item("tongkien").ToString + " " + oTableBillOfLading.Rows(0).Item("pkgs").ToString


                End If

                If oTableBillOfLading.Rows(0).Item("tongkg").ToString = "" Or oTableBillOfLading.Rows(0).Item("tongkg").ToString = "0" Then

                Else
                    totalG = rptDoCument.ReportDefinition.ReportObjects("totalg")
                    totalG.Text = oTableBillOfLading.Rows(0).Item("tongkg").ToString + " " + " KGS" 'oTableBillOfLading.Rows(0).Item("pkgs").ToString

                End If
                If oTableBillOfLading.Rows(0).Item("tongkhoi").ToString = "" Or oTableBillOfLading.Rows(0).Item("tongkhoi").ToString = "0" Then

                Else
                    totalC = rptDoCument.ReportDefinition.ReportObjects("totalc")
                    totalC.Text = oTableBillOfLading.Rows(0).Item("tongkhoi").ToString + " " + "CBM"

                End If


                REF1 = rptDoCument.ReportDefinition.ReportObjects("PAYABLEAT")
                REF1.Text = oTableBillOfLading.Rows(0).Item("FreightPayableAt").ToString

                MBL = rptDoCument.ReportDefinition.ReportObjects("billNo")
                If Me.chkshowbillOther.Checked = True Then
                    MBL.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString + "A"
                Else
                    MBL.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString
                End If



                MBL = rptDoCument.ReportDefinition.ReportObjects("BL_NO1")
                If Me.chkshowbillOther.Checked = True Then
                    MBL.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString + "A"
                Else
                    MBL.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString
                End If


                PreightCharges = rptDoCument.ReportDefinition.ReportObjects("PreightCharges1")
                PreightCharges.Text = oTableBillOfLading.Rows(0).Item("FreightAmount").ToString

                prepaid = rptDoCument.ReportDefinition.ReportObjects("prepaid")
                prepaid.Text = oTableBillOfLading.Rows(0).Item("prepaid").ToString

                collect = rptDoCument.ReportDefinition.ReportObjects("collect")
                collect.Text = oTableBillOfLading.Rows(0).Item("collect").ToString

                mbl1 = rptDoCument.ReportDefinition.ReportObjects("billNo1")
                If Me.chkshowbillOther.Checked = True Then
                    mbl1.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString + "A"

                Else
                    mbl1.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString

                End If
                'OnboardDate = rptDoCument.ReportDefinition.ReportObjects("loaddate")
                'OnboardDate.Text = oTableBillOfLading.Rows(0).Item("onboardDate").ToString
                '--------
                SHOWONBOARD = rptDoCument.ReportDefinition.ReportObjects("loaddate")
                SHOWONBOARD.Text = oTableBillOfLading.Rows(0).Item("OnboardDate").ToString
                '-----------------show
                'totalprepaidIn = rptDoCument.ReportDefinition.ReportObjects("totalprepaidIn")
                'totalprepaidIn.Text = oTableBillOfLading.Rows(0).Item("totalprepaidIn").ToString
                Try
                    prepaidAt = rptDoCument.ReportDefinition.ReportObjects("prepaidAt")
                    prepaidAt.Text = oTableBillOfLading.Rows(0).Item("prepaidAt").ToString
                Catch ex As Exception

                End Try


                'revenueTons = rptDoCument.ReportDefinition.ReportObjects("revenueTons")
                'revenueTons.Text = oTableBillOfLading.Rows(0).Item("revenueTons").ToString



                '------ xuong hang
                NotifyTam = ""
                NotifyTam1 = Strings.Split(oTableBillOfLading.Rows(0).Item("OnboardDate").ToString, Chr(13))
                For CountA As Integer = 0 To NotifyTam1.Length - 1
                    NotifyTam &= NotifyTam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = NotifyTam1(CountA).Length To SHOWONBOARD.Width \ 10
                        NotifyTam &= " "
                    Next
                Next
                SHOWONBOARD.Text = NotifyTam
                '----------------

                placeandDate = rptDoCument.ReportDefinition.ReportObjects("placeanddate")
                placeandDate.Text = oTableBillOfLading.Rows(0).Item("placeanddate").ToString

                'placeandDate = rptDoCument.ReportDefinition.ReportObjects("placeanddate")
                'placeandDate.Text = oTableBillOfLading.Rows(0).Item("placeanddate").ToString
                'If flag = 1 Then
                '    Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
                '    Vessel.Text = oTableBillOfLading.Rows(0).Item("OCeanVessel").ToString & " - " & oTableBillOfLading.Rows(0).Item("VoyAge").ToString
                'Else
                If Me.chkMother.Checked Then
                    Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVesselName")
                    Vessel.Text = oTableBillOfLading.Rows(0).Item("mVessel").ToString '+ "  " + oTableBillOfLading.Rows(0).Item("VoyAge").ToString

                    Voyno = rptDoCument.ReportDefinition.ReportObjects("VoyNo")
                    Voyno.Text = oTableBillOfLading.Rows(0).Item("mVoy").ToString



                    Vessel = rptDoCument.ReportDefinition.ReportObjects("Pre_Vessel")
                    Vessel.Text = oTableBillOfLading.Rows(0).Item("Vessel").ToString '+ "  " + oTableBillOfLading.Rows(0).Item("VoyAge").ToString

                    Voyno = rptDoCument.ReportDefinition.ReportObjects("Pre_VoyNo")
                    Voyno.Text = oTableBillOfLading.Rows(0).Item("VoyAge").ToString

                Else


                    Vessel = rptDoCument.ReportDefinition.ReportObjects("Pre_Vessel")
                    Vessel.Text = oTableBillOfLading.Rows(0).Item("Vessel").ToString '+ "  " + oTableBillOfLading.Rows(0).Item("VoyAge").ToString

                    Voyno = rptDoCument.ReportDefinition.ReportObjects("Pre_VoyNo")
                    Voyno.Text = oTableBillOfLading.Rows(0).Item("VoyAge").ToString
                End If
                'End If

                saycontainer = rptDoCument.ReportDefinition.ReportObjects("totalcontainer")
                saycontainer.Text = oTableBillOfLading.Rows(0).Item("saycontainer").ToString

                'POR = rptDoCument.ReportDefinition.ReportObjects("POR")
                'POR.Text = oTableBillOfLading.Rows(0).Item("POR").ToString

                STATUSSEND = rptDoCument.ReportDefinition.ReportObjects("txtsur")
                STATUSSEND.Text = Me.cboBillType.Text


                POR = rptDoCument.ReportDefinition.ReportObjects("PlaceOfReceipt")
                POR.Text = oTableBillOfLading.Rows(0).Item("POr").ToString

                POL = rptDoCument.ReportDefinition.ReportObjects("PortOfLoading")
                POL.Text = oTableBillOfLading.Rows(0).Item("POL").ToString

                POD = rptDoCument.ReportDefinition.ReportObjects("PortOfDischarge")
                POD.Text = oTableBillOfLading.Rows(0).Item("POD").ToString

                DEL = rptDoCument.ReportDefinition.ReportObjects("PlaceOfDelivery")
                DEL.Text = oTableBillOfLading.Rows(0).Item("DEL").ToString
                If Me.chkDest.Checked Then
                    DEST = rptDoCument.ReportDefinition.ReportObjects("FinalDestination")
                    DEST.Text = oTableBillOfLading.Rows(0).Item("DEST").ToString
                End If

                Try
                    CY_CFS = rptDoCument.ReportDefinition.ReportObjects("CY_CFS")
                    CY_CFS.Text = oTableBillOfLading.Rows(0).Item("CY_CFS_ITEM").ToString

                Catch ex As Exception

                End Try



                Shipment = rptDoCument.ReportDefinition.ReportObjects("agencyname")
                'Shipment.Text = oTableBillOfLading.Rows(0).Item("agencyname").ToString

                Dim agencyTam As String
                Dim agencytam1() As String
                If Me.chkshowbillOther.Checked = True Then
                    agencytam1 = Strings.Split(oTableBillOfLading.Rows(0).Item("agencynameother").ToString, Chr(13))
                Else
                    agencytam1 = Strings.Split(oTableBillOfLading.Rows(0).Item("agencyname").ToString, Chr(13))
                End If

                For CountA As Integer = 0 To agencytam1.Length - 1
                    agencyTam &= agencytam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = agencytam1(CountA).Length To Shipment.Width \ 10
                        agencyTam &= " "
                    Next
                Next
                Shipment.Text = agencyTam






                numberOfOriginal = rptDoCument.ReportDefinition.ReportObjects("NoOfOrigineBL")
                numberOfOriginal.Text = oTableBillOfLading.Rows(0).Item("numberoforiginal").ToString



                'icdPort = rptDoCument.ReportDefinition.ReportObjects("txticdPort")
                'icdPort.Text = oTableBillOfLading.Rows(0).Item("importCY").ToString

                ref = rptDoCument.ReportDefinition.ReportObjects("ref")
                ref.Text = oTableBillOfLading.Rows(0).Item("ref").ToString


                'BLtYPE = rptDoCument.ReportDefinition.ReportObjects("TXTBLtYPE")
                'BLtYPE.Text = oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString
                '''''''''''''''''''''''''''''''''''''
                'Description og goods


                Dim Temp(), Result, ShippingMarks As String
                Dim tempTextObject, SMarks As TextObject
                Result = oTableBillOfLading.Rows(0).Item("DESCRIPTION").ToString
                ShippingMarks = oTableBillOfLading.Rows(0).Item("ShippingMarks").ToString

                Temp = Strings.Split(Result, Chr(13))
                'QueryCountContainer()
                ' Result = ""

                DESC = rptDoCument.ReportDefinition.ReportObjects("Description1")

                SMarks = rptDoCument.ReportDefinition.ReportObjects("ShippingMarks")

                Dim marksTam As String
                Dim markstam1() As String
                markstam1 = Strings.Split(ShippingMarks, Chr(13))
                For CountA As Integer = 0 To markstam1.Length - 1
                    marksTam &= markstam1(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = markstam1(CountA).Length To SMarks.Width \ 10
                        marksTam &= " "
                    Next
                Next
                SMarks.Text = marksTam







                Dim descTam As String
                Dim desctam1() As String
                desctam1 = Strings.Split(Result, Chr(13))
                For CountA As Integer = 0 To desctam1.Length - 1
                    descTam &= desctam1(CountA) '.Replace(Chr(10), "  ")
                    For CountSpacea As Integer = desctam1(CountA).Length To DESC.Width \ 10
                        descTam &= " "
                    Next
                Next
                DESC.Text = descTam
                ' hien thi attach list
                '--------
                Try
                    Dim showattachlist As Object
                    'If Me.chkAttachlist.Checked = True Then

                    DESC.Text = Result
                    '------ xuong hang
                    NotifyTam = ""
                    NotifyTam1 = Strings.Split(Result, Chr(13))
                    For CountA As Integer = 0 To NotifyTam1.Length - 1
                        NotifyTam &= NotifyTam1(CountA).Replace(Chr(10), " ")
                        For CountSpacea As Integer = NotifyTam1(CountA).Length To DESC.Width \ 10
                            NotifyTam &= " "
                        Next
                    Next
                    DESC.Text = NotifyTam
                    '----------------
                    ' End If

                    Dim attachDes As Object

                    If Me.chkAttachDesc.Checked = True Then
                        attachDes = rptDoCument.ReportDefinition.ReportObjects("txtAttactlist")
                        attachDes.Text = DESC.Text
                        '  rptDoCument.ReportDefinition.ReportObjects("description1").ObjectFormat.EnableSuppress = True
                        attachDes = rptDoCument.ReportDefinition.ReportObjects("description1")
                        attachDes.Text = "Attached list"


                    End If
                    If Me.chkAttachShippingMarks.Checked = True Then
                        attachDes = rptDoCument.ReportDefinition.ReportObjects("txtattShippingmarks")
                        attachDes.Text = SMarks.Text
                        'rptDoCument.ReportDefinition.ReportObjects("ShippingMarks").ObjectFormat.EnableSuppress = True

                        attachDes = rptDoCument.ReportDefinition.ReportObjects("ShippingMarks")
                        attachDes.Text = "Attached list"


                    End If
                Catch ex As Exception

                End Try

                'DESC.Text = Result
            End If
            '' container
            If oTableCargoInfo.Rows.Count > 0 Then
                Dim container, Gross, CBM, txtamount As TextObject
                Dim container1, container2, container3, container4, container5, container6, container7, container8, container9 As Object
                Dim type1, type2, type3, type4, type5, type6, type7, type8, type9 As Object

                Dim seal1, seal2, seal3, seal4, seal5, seal6, seal7, seal8, seal9 As Object

                Dim sokien1, sokien2, sokien3, sokien4, sokien5, sokien6, sokien7, sokien8, sokien9 As Object

                Dim soKg1, soKg2, soKg3, soKg4, soKg5, soKg6, soKg7, soKg8, soKg9 As Object

                Dim soKhoi1, soKhoi2, soKhoi3, soKhoi4, soKhoi5, soKhoi6, soKhoi7, soKhoi8, soKhoi9 As Object

                Dim tempContainer As String = ""
                Dim Dgross, Dcbm, amount As Double
                Dim kgsUnit, cbmUnit, AmountUnit As String
                Dgross = 0
                Dcbm = 0
                amount = 0
                Dim row As DataRow
                Dim tongsoKien, tongsoKG, tongsoKHOI As Double

                Dim rowtang As Integer = 1
                Dim i As Integer
                Dim cont As String = ""
                Dim sokien As String = ""
                Dim sokg As String = ""
                Dim sokhoi As String = ""

                container1 = rptDoCument.ReportDefinition.ReportObjects("containerno1")
                sokien1 = rptDoCument.ReportDefinition.ReportObjects("amount1")

                soKg1 = rptDoCument.ReportDefinition.ReportObjects("gross1")
                soKhoi1 = rptDoCument.ReportDefinition.ReportObjects("meas1")
                If oTableCargoInfo.Rows.Count > 0 Then
                    For i = 0 To oTableCargoInfo.Rows.Count - 1
                        If (oTableCargoInfo.Rows(i).Item("containerno").ToString <> "") Then


                            Try
                                cont += oTableCargoInfo.Rows(i).Item("containerno").ToString + "/" + oTableCargoInfo.Rows(i).Item("seal").ToString + "                     " + Chr(13)

                            Catch ex As Exception

                            End Try
                        End If
                        If oTableCargoInfo.Rows(i).Item("sokien").ToString <> "" Then
                            Try
                                sokien += FormatNumber(oTableCargoInfo.Rows(i).Item("sokien").ToString, 0) + " " + oTableCargoInfo.Rows(i).Item("type").ToString + Chr(13)

                            Catch ex As Exception

                            End Try
                        End If

                        If oTableCargoInfo.Rows(i).Item("sokg").ToString <> "" Then

                            Try
                                sokg += FormatNumber(oTableCargoInfo.Rows(i).Item("sokg").ToString, 2) + " KGS" + Chr(13)

                                tongsoKG += CDbl(oTableCargoInfo.Rows(i).Item("sokg").ToString)
                            Catch ex As Exception

                            End Try

                        End If
                        If oTableCargoInfo.Rows(i).Item("sokhoi").ToString <> "" Then
                            Try
                                sokhoi += FormatNumber(oTableCargoInfo.Rows(i).Item("sokhoi").ToString, 3) + " CBM" + Chr(13)
                                tongsoKHOI += CDbl(oTableCargoInfo.Rows(i).Item("sokhoi").ToString)
                            Catch ex As Exception

                            End Try

                        End If




                        If oTableCargoInfo.Rows(i).Item("sokien").ToString <> "" Then
                            Try
                                tongsoKien += CDbl(oTableCargoInfo.Rows(i).Item("sokien").ToString)
                            Catch ex As Exception

                            End Try

                            'Else
                            '    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("priceCredit" + CStr(rowtang)).ToString)
                        End If
                    Next

                End If
                '--------------xuong hang
                ' khai bao att
                Dim containerAtt, AmountAtt, GrossAtt, MeasAtt As Object
                '----------------------------------------------------------------------------

                containerAtt = rptDoCument.ReportDefinition.ReportObjects("containernoAtt")
                AmountAtt = rptDoCument.ReportDefinition.ReportObjects("AmountAtt")
                GrossAtt = rptDoCument.ReportDefinition.ReportObjects("GrossAtt")
                MeasAtt = rptDoCument.ReportDefinition.ReportObjects("MeasAtt")



                Dim mang() As String
                Dim kq As String
                ' them tong container
                'If oTableBillOfLading.Rows(0).Item("FCL").ToString = "True" Then
                '    cont = cont + Chr(13) + "----------------------------" + Chr(13)
                '    cont = cont + "TOTAL : " + oTableCargoInfo.Rows.Count.ToString + " CONTAINERS"
                'Else
                '    cont = cont + Chr(13) + "----------------------------" + Chr(13)
                '    cont = cont + "TOTAL : " '+ oTableCargoInfo.Rows.Count.ToString + " CONTAINERS"
                'End If

                '--------------------------
                mang = Strings.Split(cont, Chr(13))
                For CountA As Integer = 0 To mang.Length - 1
                    kq &= mang(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = mang(CountA).Length To container1.Width \ 22
                        kq &= " "
                    Next
                Next
                If Me.chkContainerNo.Checked = True Then
                    container1.Text = kq
                    containerAtt.text = kq
                Else
                    container1.Text = ""
                    containerAtt.text = ""
                End If

                '---------------------------------------------
                kq = ""
                'sokien = sokien + Chr(13) + "----------------" + Chr(13)
                '  sokien = sokien + FormatNumber(tongsoKien.ToString, 0).ToString + " " + oTableCargoInfo.Rows(0).Item("type").ToString
                mang = Strings.Split(sokien, Chr(13))
                For CountA As Integer = 0 To mang.Length - 1
                    kq &= mang(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = mang(CountA).Length To sokien1.Width \ 22
                        kq &= " "
                    Next
                Next
                sokien1.Text = kq
                AmountAtt.text = kq

                '---------------------------------------------
                kq = ""
                'sokg = sokg + Chr(13) + "----------------" + Chr(13)
                'sokg = sokg + FormatNumber(tongsoKG.ToString, 2).ToString + " KGS"
                mang = Strings.Split(sokg, Chr(13))
                For CountA As Integer = 0 To mang.Length - 1
                    kq &= mang(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = mang(CountA).Length To soKg1.Width \ 22
                        kq &= " "
                    Next
                Next
                soKg1.Text = kq
                GrossAtt.text = kq
                '---------------------------------------------
                kq = ""
                'sokhoi = sokhoi + Chr(13) + "-------------" + Chr(13)
                'sokhoi = sokhoi + FormatNumber(tongsoKHOI.ToString, 3).ToString + " CBM"
                mang = Strings.Split(sokhoi, Chr(13))
                For CountA As Integer = 0 To mang.Length - 1
                    kq &= mang(CountA).Replace(Chr(10), " ")
                    For CountSpacea As Integer = mang(CountA).Length To soKhoi1.Width \ 22
                        kq &= " "
                    Next
                Next
                soKhoi1.Text = kq
                MeasAtt.text = kq
                If Me.chkContainer.Checked = True Then

                    rptDoCument.ReportDefinition.ReportObjects("containerno1").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("amount1").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("Meas1").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("gross1").ObjectFormat.EnableSuppress = True

                    rptDoCument.ReportDefinition.ReportObjects("containernoatt").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("Measatt").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("amountatt").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("grossatt").ObjectFormat.EnableSuppress = False
                    If Me.chkViewCBM.Checked = True Then


                        rptDoCument.ReportDefinition.ReportObjects("Measatt").ObjectFormat.EnableSuppress = False
                    Else


                        rptDoCument.ReportDefinition.ReportObjects("Measatt").ObjectFormat.EnableSuppress = True
                    End If

                Else
                    rptDoCument.ReportDefinition.ReportObjects("containerno1").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("Meas1").ObjectFormat.EnableSuppress = False
                    ' che tam voi bill will 190914
                    rptDoCument.ReportDefinition.ReportObjects("amount1").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("gross1").ObjectFormat.EnableSuppress = False

                    rptDoCument.ReportDefinition.ReportObjects("Measatt").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("containernoatt").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("amountatt").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("grossatt").ObjectFormat.EnableSuppress = True
                    If Me.chkViewCBM.Checked = True Then
                        rptDoCument.ReportDefinition.ReportObjects("Meas1").ObjectFormat.EnableSuppress = False


                    Else
                        rptDoCument.ReportDefinition.ReportObjects("Meas1").ObjectFormat.EnableSuppress = True


                    End If


                End If



            End If
            Try
                If Me.chkNon.Checked = True Then
                    rptDoCument.ReportDefinition.ReportObjects("txtNon").ObjectFormat.EnableSuppress = False
                Else
                    rptDoCument.ReportDefinition.ReportObjects("txtNon").ObjectFormat.EnableSuppress = True
                End If
            Catch ex As Exception

            End Try
            If oTableremarks.Rows.Count > 0 Then
                Dim arrival, demurage, payment, Shipment, note, BLtYPE, ngaynhanlenh As TextObject


            End If
            ' hien thi attach list
            '--------
            Try
                Dim showattachlist As Object
                If Me.chkAttachlist.Checked = True Then
                    showattachlist = rptDoCument.ReportDefinition.ReportObjects("txtattachlist")
                    showattachlist.Text = oTableBillOfLading.Rows(0).Item("attachlist").ToString
                    '------ xuong hang
                    NotifyTam = ""
                    NotifyTam1 = Strings.Split(oTableBillOfLading.Rows(0).Item("attachlist").ToString, Chr(13))
                    For CountA As Integer = 0 To NotifyTam1.Length - 1
                        NotifyTam &= NotifyTam1(CountA).Replace(Chr(10), " ")
                        For CountSpacea As Integer = NotifyTam1(CountA).Length To showattachlist.Width \ 10
                            NotifyTam &= " "
                        Next
                    Next
                    showattachlist.Text = NotifyTam
                    '----------------
                End If
            Catch ex As Exception

            End Try


            '-----------------------------------
            ' an hien M.Vessel, CBM
            Dim txtnote As Object
            txtnote = rptDoCument.ReportDefinition.ReportObjects("txtnote")
            txtnote.Text = Me.txtby.Text
            Dim m As Integer
            'If Me.chkViewCBM.Checked = False Then
            '    For m = 0 To 8
            '        rptDoCument.ReportDefinition.ReportObjects("Meas" & m + 1).ObjectFormat.EnableSuppress = True
            '    Next
            '    'rptDoCument.ReportDefinition.ReportObjects("MeasAttach").ObjectFormat.EnableSuppress = True

            'End If
            If Me.chkDraft.Checked = False Then

                'rptDoCument.ReportDefinition.ReportObjects("MeasAttach").ObjectFormat.EnableSuppress = True

            End If
            '----lay gia tien debit
            'Dim phi As Object
            'phi = rptDoCument.ReportDefinition.ReportObjects("txtphi")

            'Dim ds As New DataSet
            'Dim sql, phitam, tam As String
            'Dim w, countArr As Integer
            'Dim tamArr() As String
            'Dim item1, item2, item3, item4, item5, item6, item7 As Object
            'Dim cur1, cur2, cur3, cur4, cur5, cur6, cur7 As Object

            'Dim unit1, unit2, unit3, unit4, unit5, unit6, unit7 As Object
            'Dim quantity1, quantity2, quantity3, quantity4, quantity5, quantity6, quantity7 As Object

            'Dim price1, price2, price3, price4, price5, price6, price7 As Object
            'Dim tax1, tax2, tax3, tax4, tax5, tax6, tax7 As Object
            'Dim tongusdvnd, pricebuy1, pricebuy2, pricebuy3, pricebuy4, pricebuy5, pricebuy6, pricebuy7 As Object
            'sql = " select * from inbound  where blib_id='" & gInboundID & "' "
            'ds = ReadDataSet(sql)
            '' lay tong
            'Dim iT As Integer
            'Dim tongvnd As Double = 0
            'Dim tongusd As Double = 0

            'If ds.Tables(0).Rows.Count > 0 Then
            '    For iT = 0 To ds.Tables(0).Rows.Count - 1
            '        If ds.Tables(0).Rows(iT).Item("currency").ToString = "VND" Then
            '            tongvnd += CDbl(ds.Tables(0).Rows(iT).Item("priceban").ToString)

            '        Else
            '            tongusd += CDbl(ds.Tables(0).Rows(iT).Item("priceban").ToString)

            '        End If


            '    Next
            'End If
            'tongusdvnd = rptDoCument.ReportDefinition.ReportObjects("totalUSDVND")
            'tongusdvnd.Text = "Total   VND " + FormatNumber(tongvnd, 2) + "  " + "USD " + FormatNumber(tongusd, 2)
            '----------------------------------
            'Dim tongVND As Double = 0
            'Dim tongUSD As Double = 0



            'For w = 0 To ds.Tables(0).Rows.Count - 1

            'phitam += (w + 1).ToString + ". " + ds.Tables(0).Rows(w).Item("ITEMS").ToString + " : " + ds.Tables(0).Rows(w).Item("priceBAN").ToString + ds.Tables(0).Rows(w).Item("currency").ToString + "  " + ds.Tables(0).Rows(w).Item("remarks").ToString + Chr(13)
            'Next

            'phi.text = phitam
            '------ xuong hang
            'tamArr = Strings.Split(phitam, Chr(13))
            'For countArr = 0 To tamArr.Length - 1
            '    tam &= tamArr(countArr).Replace(Chr(10), "")
            '    For CountSpacea As Integer = tamArr(countArr).Length To phi.Width \ 10
            '        tam &= " "
            '    Next
            'Next
            'phi.Text = tam
            '-------------------------------------------------------------
            'Dim dt As Date
            'dt = frmInBoundRemarks.dtpPrintdate.Value
            'Dim d, m, y As TextObject
            'd = rptDoCument.ReportDefinition.ReportObjects("Day")
            'd.Text = dt.Day
            'm = rptDoCument.ReportDefinition.ReportObjects("Month")
            'm.Text = dt.Month
            'y = rptDoCument.ReportDefinition.ReportObjects("Year")
            'y.Text = dt.Year
            ApplyCrystalDatabaseLogon(rptDoCument)
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            'Formatting paper

            If flag = 1 Then
                mymargins = rptDoCument.PrintOptions.PageMargins
                mymargins.topMargin = gTopM
                mymargins.bottomMargin = gBottomM
                mymargins.leftMargin = gLeftM
                mymargins.rightMargin = gRightM
                'rptDoCument.PrintOptions.ApplyPageMargins(mymargins)
            End If
            'rptDoCument.PrintOptions.PaperSize = PaperSize.PaperA4
            If frmMain.mnuReportOrientationPortrait.Checked Then
                rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            Else
                rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            End If
            rptDoCument.Refresh()

            'If frmInBoundRemarks.CountBill > 1 Then
            '    rptDoCument.PrintToPrinter(1, True, 1, 2)
            '    Me.Close()
            'End If
            Me.CrystalReportViewer1.Refresh()
            Me.CrystalReportViewer1.Show()
            'Dim strMesg As String = "Print this Arrival Note! ?"
            'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
            '    rptDoCument.Refresh()
            '    rptDoCument.PrintToPrinter(1, True, 1, 1)
            'End If


        Catch ex As Exception
            Me.Close()
            MsgBox(msgErr(Me, Err.Description))
        End Try


    End Sub
    Private Sub frmRptArrival_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.chkAttachDescription.Visible = False
        If frmInBoundRemarks.CountBill > 1 Then

            Me.Hide()
        End If
        Me.chkALPine.Visible = False
        '  Me.chkDraft.Visible = False
        PrintRpt()
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkAttachDescription_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PrintRpt()
    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        PrintRpt()
    End Sub

    Private Sub cmdRefresh_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click

    End Sub

    Private Sub chkViewCBM_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkViewCBM.CheckedChanged


    End Sub
End Class