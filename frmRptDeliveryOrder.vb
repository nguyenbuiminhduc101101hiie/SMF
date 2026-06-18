Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System

Public Class frmRptDeliveryOrder
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

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM BillOfLadingIB "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "BillOfLadingIB.BLIB_ID= '" & gBillInboundID & "' And BillOfLadingIB.Continued=1"
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
        MakeQueryBillOfLading = strBillOfLadingSelect
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        MakeQueryBillOfLading = MakeQueryBillOfLading & " ,ref,mbl,hbl FROM  BillOfLadingIB "

        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE (BillOfLadingIB.BLIB_ID = '" & gBillInboundID & "') "
        MakeQueryBillOfLading = MakeQueryBillOfLading & "And ("
        MakeQueryBillOfLading = MakeQueryBillOfLading & "BillOfLadingIB.Continued = 1 "
        MakeQueryBillOfLading = MakeQueryBillOfLading & ") "
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

        If oTableBillOfLading.Rows.Count > 0 Then
            Vessel = oTableBillOfLading.Rows(0).Item("OceanVessel").ToString
            VoyAge = oTableBillOfLading.Rows(0).Item("VoyAge").ToString
        End If
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
        MakeQueryCargo = strCargo

        MakeQueryCargo = MakeQueryCargo & ", grosscharge  FROM (CargoIB left join Container on CargoIB.CTN_ID=Container.CTN_ID )"
        MakeQueryCargo = MakeQueryCargo & "WHERE (CargoIB.BLIB_ID = '" & gBillInboundID & "') "
        MakeQueryCargo = MakeQueryCargo & "And ("
        MakeQueryCargo = MakeQueryCargo & "CargoIB.Continued = 1 "
        MakeQueryCargo = MakeQueryCargo & ") Order By CARGOIB.STT"
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
        strQuery = strQuery & "FROM INBOUNDREMARKS "
        strQuery = strQuery & "WHERE BLIB_NO = '" & gBillNoInBound & "' And Continued=1"

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
            Dim strQuery As String
            strQuery = " Select Container_Type,Count(Container_type) as Num From CargoIB"
            strQuery &= " Where BLIB_ID='" & gBillInboundID & "' And Continued=1 Group By Container_type"
            Dim Conn As New SqlClient.SqlConnection(strconnDG)
            Conn.Open()
            Dim cmdSelect As New SqlClient.SqlCommand(strQuery, Conn)
            Dim Adapter As New SqlClient.SqlDataAdapter(cmdSelect)
            If oTableCountContainerType.Rows.Count > 0 Then
                oTableCountContainerType.Rows.Clear()
            End If
            Adapter.Fill(oTableCountContainerType)
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
                CBM.Text = FormatNumber(Dcbm, 3) + cbmUnit
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
                CBM.Text = FormatNumber(Dcbm, 3) + cbmUnit

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
        On Error GoTo Err
        Dim rptDoCument As ReportDocument
        Dim mymargins
        Dim strReportName As String
        Dim strQuery As String
        QueryBillOfLading()
        QueryCargo()
        QueryCustomerInfo()
        QueryRemark()
        Dim N As Integer = IIf(oTableCargoInfo.Rows.Count - 1 > 16, 16, oTableCargoInfo.Rows.Count - 1)
        Dim k As Integer = oTableCargoInfo.Rows.Count - 1 - N
        If flag = 1 Then
            rptDoCument = New ReportDocument
            '----------
            ' ten Report
            strReportName = "ReportLenhGiaohangnoAT"
            If Me.chkCheckAir.Checked = True Then
                strReportName = "ReportLenhGiaohangnoAT_air"
            End If
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            '----------
        Else
            rptDoCument = New ReportDocument

            ' ten Report
            If k > 0 Or Me.chkAttachDescription.Checked = True Then
                strReportName = "ReportArrival"
            Else
                strReportName = "ReportArrivalnoat"
            End If


            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'Formatting paper

        End If


        Dim BL, mbl, hbl As TextObject
        BL = rptDoCument.ReportDefinition.ReportObjects("BL_NO")
        BL.Text = gBillNoInBound
        Dim shipperTam, ConsigneeTam, NotifyTam As String
        Dim shipperTam1(), ConsigneeTam1(), NotifyTam1() As String
        If oTableCustomerInfo.Rows.Count > 0 Then
            Dim shipper, consignee, notify, consigneeTen As TextObject
            Dim tempshipper, tempconsignee, tempnotify As String
            'For i As Integer = 1 To 6
            'tempshipper = oTableCustomerInfo.Rows(0).Item("Shipper").ToString
            'shipper = rptDoCument.ReportDefinition.ReportObjects("Shipper1")
            'shipper.Text = tempshipper
            shipper = rptDoCument.ReportDefinition.ReportObjects("shipper_1")
            'consignee.Text = tempconsignee
            '------ xuong hang
            shipperTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("shipper").ToString, Chr(13))
            'For CountA As Integer = 0 To ConsigneeTam1.Length - 1
            '    shipperTam &= shipperTam1(CountA).Replace(Chr(10), "")
            '    For CountSpacea As Integer = shipperTam1(CountA).Length To shipper.Width \ 10
            '        shipperTam &= " "
            '    Next
            'Next
            shipper.Text = shipperTam1(0)
            'tempconsignee = oTableCustomerInfo.Rows(0).Item("Consignee").ToString
            consignee = rptDoCument.ReportDefinition.ReportObjects("Consignee_1")
            consigneeTen = rptDoCument.ReportDefinition.ReportObjects("txtConsigneeten")
            'consignee.Text = tempconsignee
            '------ xuong hang
            ConsigneeTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Consignee").ToString, Chr(13))
            For CountA As Integer = 0 To ConsigneeTam1.Length - 1
                ConsigneeTam &= ConsigneeTam1(CountA).Replace(Chr(10), "")
                For CountSpacea As Integer = ConsigneeTam1(CountA).Length To consignee.Width \ 10
                    ConsigneeTam &= " "
                Next
            Next
            consigneeTen.Text = ConsigneeTam1(0)
            consignee.Text = ConsigneeTam
            'tempnotify = oTableCustomerInfo.Rows(0).Item("Notify").ToString
            'notify = rptDoCument.ReportDefinition.ReportObjects("Notify1")
            'notify.Text = tempnotify'
            '---------------------------
            notify = rptDoCument.ReportDefinition.ReportObjects("notify_1")
            'consignee.Text = tempconsignee
            '------ xuong hang
            NotifyTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("notify").ToString, Chr(13))
            'For CountA As Integer = 0 To ConsigneeTam1.Length - 1
            '    shipperTam &= shipperTam1(CountA).Replace(Chr(10), "")
            '    For CountSpacea As Integer = shipperTam1(CountA).Length To shipper.Width \ 10
            '        shipperTam &= " "
            '    Next
            'Next
            notify.Text = NotifyTam1(0)

            'Next
        End If
        If oTableBillOfLading.Rows.Count > 0 Then
            Dim ref, BLtYPE, icdPort, PreVessel, Vessel, Voyno, POR, POD, POL, DEL, DEST, DESC, Marks, CY_CFS, Shipment, STATUSSEND As TextObject
            Dim REF1 As TextObject
            REF1 = rptDoCument.ReportDefinition.ReportObjects("REF")
            REF1.Text = oTableBillOfLading.Rows(0).Item("REF").ToString
            MBL = rptDoCument.ReportDefinition.ReportObjects("txtmbl")
            MBL.Text = oTableBillOfLading.Rows(0).Item("mbl").ToString
            HBL = rptDoCument.ReportDefinition.ReportObjects("txthbl")
            HBL.Text = oTableBillOfLading.Rows(0).Item("hbl").ToString
            'If flag = 1 Then
            '    Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
            '    Vessel.Text = oTableBillOfLading.Rows(0).Item("OCeanVessel").ToString & " - " & oTableBillOfLading.Rows(0).Item("VoyAge").ToString
            'Else
            Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
            Vessel.Text = oTableBillOfLading.Rows(0).Item("OCeanVessel").ToString + "  " + oTableBillOfLading.Rows(0).Item("VoyAge").ToString

            'Voyno = rptDoCument.ReportDefinition.ReportObjects("VoyNo")
            'Voyno.Text = oTableBillOfLading.Rows(0).Item("VoyAge").ToString

            'End If

            'PreVessel = rptDoCument.ReportDefinition.ReportObjects("Pre")
            'PreVessel.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString

            POR = rptDoCument.ReportDefinition.ReportObjects("POR")
            POR.Text = oTableBillOfLading.Rows(0).Item("POR").ToString

            STATUSSEND = rptDoCument.ReportDefinition.ReportObjects("TXTSTATUSSEND")
            STATUSSEND.Text = frmInBoundRemarks.ComboBox1.Text

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
            Shipment.Text = oTableBillOfLading.Rows(0).Item("ICDPort").ToString

            icdPort = rptDoCument.ReportDefinition.ReportObjects("txticdPort")
            icdPort.Text = oTableBillOfLading.Rows(0).Item("ICDPort").ToString
            ref = rptDoCument.ReportDefinition.ReportObjects("txtrefno")
            ref.Text = oTableBillOfLading.Rows(0).Item("ref").ToString


            BLtYPE = rptDoCument.ReportDefinition.ReportObjects("TXTBLtYPE")
            BLtYPE.Text = oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString
            '''''''''''''''''''''''''''''''''''''
            'Description og goods


            Dim Temp(), Result As String
            Dim tempTextObject As TextObject
            Result = oTableBillOfLading.Rows(0).Item("DESCRIPTIONOFGOODS").ToString
            Temp = Strings.Split(Result, Chr(13))
            QueryCountContainer()
            Result = ""
            'If CheckLCLCargo() = True Then
            '    Result = " Part Of Containers                                                      "
            'End If
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
            DESC = rptDoCument.ReportDefinition.ReportObjects("Description")
            If Me.chkAttachDescription.Checked = True Then
                DESC.Text = Result
                Result = ""
                DESC = rptDoCument.ReportDefinition.ReportObjects("Description1")
            End If

            For j As Integer = 0 To Temp.Length - 1
                Result &= Temp(j)
                For l As Integer = Temp(j).Length To DESC.Width \ 50
                    Result &= "     "
                Next
            Next
            DESC.Text = Result
        End If
        If oTableCargoInfo.Rows.Count > 0 Then
            Dim container, Gross, CBM, txtamount As TextObject
            Dim tempContainer As String = ""
            Dim Dgross, Dcbm, amount As Double
            Dim kgsUnit, cbmUnit, AmountUnit As String
            Dgross = 0
            Dcbm = 0
            amount = 0
            Dim row As DataRow


            'xư ly các contanier nhiều hơn số container giới hiện thi trên bill 
            If k > 0 Or Me.chkAttachDescription.Checked = True Then
                Dim AttachContainer, BL_NO1, AttachTitle, ToTalAttachContainer As TextObject
                Dim strAttachContainer As String = ""
                MsgBox("This bill has attach list! ")
                Me.chkAttachDescription.Visible = True

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
                    If Me.chkCheckAir.Checked = True Then
                        Dcbm += IIf(oTableCargoInfo.Rows(i).Item("grosscharge").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("grosscharge"), 0)

                    Else
                        Dcbm += IIf(oTableCargoInfo.Rows(i).Item("Meas").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("Meas"), 0)

                    End If
                    amount += IIf(oTableCargoInfo.Rows(i).Item("amount").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("amount"), 0)

                    AmountUnit = oTableCargoInfo.Rows(0).Item("kind").ToString
                    kgsUnit = oTableCargoInfo.Rows(0).Item("GrossUnit").ToString
                    If Me.chkCheckAir.Checked = True Then
                        cbmUnit = "Kgs"
                    Else
                        cbmUnit = oTableCargoInfo.Rows(0).Item("measUnit").ToString
                    End If

                Next
                AttachContainer = rptDoCument.ReportDefinition.ReportObjects("ContainerAttach")
                AttachContainer.Text = strAttachContainer
                container = rptDoCument.ReportDefinition.ReportObjects("Container")
                container.Text = "Attach List"
                txtamount = rptDoCument.ReportDefinition.ReportObjects("txtamount")
                txtamount.Text = FormatNumber(amount, 2) + AmountUnit

                Gross = rptDoCument.ReportDefinition.ReportObjects("Gross")
                Gross.Text = FormatNumber(Dgross, 2) + kgsUnit
                CBM = rptDoCument.ReportDefinition.ReportObjects("CBM")
                CBM.Text = FormatNumber(Dcbm, 2) + cbmUnit
            Else
                For i As Integer = 0 To N
                    Dgross += IIf(oTableCargoInfo.Rows(i).Item("GrossWeight").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("GrossWeight"), 0)


                    If Me.chkCheckAir.Checked = True Then
                        Dcbm += IIf(oTableCargoInfo.Rows(i).Item("grosscharge").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("grosscharge"), 0)

                    Else
                        Dcbm += IIf(oTableCargoInfo.Rows(i).Item("Meas").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("Meas"), 0)

                    End If




                    amount += IIf(oTableCargoInfo.Rows(i).Item("amount").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("amount"), 0)

                    tempContainer &= oTableCargoInfo.Rows(i).Item("CONTAINER_NO").ToString & "  " & oTableCargoInfo.Rows(i).Item("CTN_SIZE_TYPE").ToString & "  " & oTableCargoInfo.Rows(i).Item("Seal").ToString
                    tempContainer &= "                                                                                                   "

                    AmountUnit = oTableCargoInfo.Rows(0).Item("kind").ToString
                    kgsUnit = oTableCargoInfo.Rows(0).Item("GrossUnit").ToString
                    If Me.chkCheckAir.Checked = True Then
                        cbmUnit = "Kgs"
                    Else
                        cbmUnit = oTableCargoInfo.Rows(0).Item("measUnit").ToString
                    End If

                    '  cbmUnit = oTableCargoInfo.Rows(0).Item("measUnit").ToString
                Next

                txtamount = rptDoCument.ReportDefinition.ReportObjects("txtamount")
                txtamount.Text = FormatNumber(amount, 2) + AmountUnit

                Gross = rptDoCument.ReportDefinition.ReportObjects("Gross")
                Gross.Text = FormatNumber(Dgross, 2) + kgsUnit

                CBM = rptDoCument.ReportDefinition.ReportObjects("CBM")
                CBM.Text = FormatNumber(Dcbm, 3) + cbmUnit

                container = rptDoCument.ReportDefinition.ReportObjects("Container")
                container.Text = tempContainer
            End If
        End If
        If oTableremarks.Rows.Count > 0 Then
            Dim arrival, demurage, payment, Shipment, note, BLtYPE As TextObject
            arrival = rptDoCument.ReportDefinition.ReportObjects("Arrival")
            arrival.Text = CDate(oTableremarks.Rows(0).Item("ArrivalDate").ToString)
            If frmInBoundRemarks.chkPrint.Checked Then
                demurage = rptDoCument.ReportDefinition.ReportObjects("Demurage")
                demurage.Text = CDate(oTableremarks.Rows(0).Item("Demurage").ToString)
            End If

            payment = rptDoCument.ReportDefinition.ReportObjects("Payment")
            payment.Text = oTableremarks.Rows(0).Item("Prepaid_Collect").ToString
            'payment.Text &= "  -  " & IIf(oTableBillOfLading.Rows.Count > 0, oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString, "")

        End If
        '----lay gia tien debit
        Dim phi As Object
        phi = rptDoCument.ReportDefinition.ReportObjects("txtphi")

        Dim ds As New DataSet
        Dim sql, phitam, tam As String
        Dim w, countArr As Integer
        Dim tamArr() As String
        sql = " select * from FREIGHT_CHARGE_IB where blib_id='" & gBillInboundID & "' and continued=1  "
        ds = ReadDataSet(sql)
        If ds.Tables(0).Rows.Count > 0 Then
            For w = 0 To ds.Tables(0).Rows.Count - 1
                phitam += (w + 1).ToString + ". " + ds.Tables(0).Rows(w).Item("ITEMS").ToString + " : " + ds.Tables(0).Rows(w).Item("priceBAN").ToString + ds.Tables(0).Rows(w).Item("currency").ToString + "  " + ds.Tables(0).Rows(w).Item("remarks").ToString + Chr(13)
            Next
        End If
        'phi.text = phitam
        '------ xuong hang
        tamArr = Strings.Split(phitam, Chr(13))
        For countArr = 0 To tamArr.Length - 1
            tam &= tamArr(countArr).Replace(Chr(10), "")
            For CountSpacea As Integer = tamArr(countArr).Length To phi.Width \ 10
                tam &= " "
            Next
        Next
        phi.Text = tam
        '-------------------------------------------------------------
        Dim dt As Date
        dt = frmInBoundRemarks.dtpArrival.Value
        Dim d, m, y As TextObject
        'd = rptDoCument.ReportDefinition.ReportObjects("Day")
        'd.Text = dt.Day
        'm = rptDoCument.ReportDefinition.ReportObjects("Month")
        'm.Text = dt.Month
        'y = rptDoCument.ReportDefinition.ReportObjects("Year")
        'y.Text = dt.Year
        '----------- Ngay nhn lenh
        Dim dtNgayLenh As Date
        dtNgayLenh = frmInBoundRemarks.dtpDemurage.Value

        Dim Ngaylenh As TextObject




        'Ngaylenh = rptDoCument.ReportDefinition.ReportObjects("txtngaythangnam")
        'Ngaylenh.Text = "Ngày " + dtNgayLenh.Day.ToString + " Tháng " + dtNgayLenh.Month.ToString + " năm " + dtNgayLenh.Year.ToString
        '--------------
        '----------- Ngay in lenh
        Dim dtNgayInLenh As Date
        dtNgayInLenh = frmInBoundRemarks.dtpPrintdate.Value

        Dim NgayInlenh As TextObject




        NgayInlenh = rptDoCument.ReportDefinition.ReportObjects("txttphcm")
        NgayInlenh.Text = "Tp. HCM Ngày " + dtNgayInLenh.Day.ToString + " Tháng " + dtNgayInLenh.Month.ToString + " năm " + dtNgayInLenh.Year.ToString

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

        If frmInBoundRemarks.CountBill > 1 Then
            rptDoCument.PrintToPrinter(1, True, 1, 2)
            Me.Close()
        End If
        Me.CrystalReportViewer1.Refresh()
        Me.CrystalReportViewer1.Show()
        'Dim strMesg As String = "Print this Arrival Note! ?"
        'If ConfirmMessage(True, strMesg) = MsgBoxResult.Ok Then
        '    rptDoCument.Refresh()
        '    rptDoCument.PrintToPrinter(1, True, 1, 1)
        'End If
        Exit Sub
Err:

        Me.Close()
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmRptArrival_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.chkAttachDescription.Visible = False
        If frmInBoundRemarks.CountBill > 1 Then

            Me.Hide()
        End If
        PrintRpt()
    End Sub

    Private Sub cmdprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ComboBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub chkAttachDescription_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAttachDescription.CheckedChanged
        PrintRpt()
    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        PrintRpt()
    End Sub
End Class