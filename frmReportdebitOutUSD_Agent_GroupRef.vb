Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmReportdebitOutUSD_Agent_GroupRef
    Dim Vessel, VoyAge, CUR As String
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

        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " FROM " & gDebitInbound & " "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "  "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & "WHERE "
        MakeQueryCustomerInfo = MakeQueryCustomerInfo & " BLiB_ID= '" & gInboundID & "' And Continued=1"
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
        MakeQueryBillOfLading = " select * from " & gDebitInbound & " "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & " FROM (((BillOfLading inner join  BillOfLadingHouse on BillOfLading.BillOfLadingId=BillOfLadingHouse.BillOfLadingId) inner join Shipper on BillOfLading.ShipperId=Shipper.ShipperId ) inner join Consignee on BillOflading.ConsigneeId=Consignee.ConsigneeId ) inner join Notify on BillOfLading.NotifyId=Notify.NotifyId "
        'MakeQueryBillOfLading = MakeQueryBillOfLading & "  FROM  BillOfLadingIB "

        MakeQueryBillOfLading = MakeQueryBillOfLading & " WHERE (BLib_ID = '" & gInboundID & "') "

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
        MakeQueryCargo = " select * from containerrepair "

        '  MakeQueryCargo = MakeQueryCargo & " FROM (CargoIB left join Container on CargoIB.CTN_ID=Container.CTN_ID )"
        MakeQueryCargo = MakeQueryCargo & "WHERE (inboundid = '" & gInboundID & "') "
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
        strQuery = strQuery & "FROM inbound "
        strQuery = strQuery & "WHERE BLiB_id = '" & gInboundID & "' And Continued=1"

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


    Sub PrintRpt()
        Try

            sochungtu = ""

            customerid = DefaultValue
            amountdebit = 0
            amountcredit = 0
            chiho = 0
            total = 0
            Dim rptDoCument As ReportDocument
            Dim mymargins
            Dim i As Integer
            Dim strReportName As String
            Dim strQuery As String

          
            '--------------------------------------
            rptDoCument = New ReportDocument
            Dim sql As String
            Dim ds As New DataSet
            sql = " select * from outboundfreight left join charge on charge.charge_id=itemid where outboundfreight.outboundid='" & gOutboundID & "' and debitcredit='Debit' "
            ds = ReadDataSet(sql)
            'If ds.Tables(0).Rows.Count <= 20 Then
            '    strReportName = "ReportDebitCourier"
            'ElseIf ds.Tables(0).Rows.Count > 20 And ds.Tables(0).Rows.Count <= 50 Then
            '    strReportName = "ReportDebitCourier50"
            'ElseIf ds.Tables(0).Rows.Count > 50 And ds.Tables(0).Rows.Count <= 80 Then
            '    strReportName = "ReportDebitCourier80"



            'End If

            strReportName = "ReportDebit"

            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If


            rptDoCument.Load(strReportPath)
            'Formatting paper'-----------------
            Dim tong As Double = 0
            Dim tongthuho As Double = 0
            '------------------------------
            ' lay ten tu ginboundcusid
            Dim sqlcus As String
            Dim dscus As New DataSet
            sqlcus = "select * from customer where customer_id='" & gOutboundCusID & "' "
            dscus = ReadDataSet(sqlcus)
            If dscus.Tables(0).Rows.Count > 0 Then
                Dim T1() As String
                Dim T As String
                Dim showText As Object

                showText = rptDoCument.ReportDefinition.ReportObjects("txtcus")
                T1 = Strings.Split("To:" + Chr(13) + dscus.Tables(0).Rows(0).Item("company").ToString + Chr(13) + dscus.Tables(0).Rows(0).Item("addresstiengviet").ToString + Chr(13) + "Tax code : " + dscus.Tables(0).Rows(0).Item("taxcode").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
            End If
            '-------------------------------------------------
            ' ngay
            Dim ngay, refno As Object
            ngay = rptDoCument.ReportDefinition.ReportObjects("txtngay")
            ngay.text = CDate(Getdate()).Date
            ' lay thong tin tu bill
            Dim sqlbill As String
            Dim dsbill As New DataSet
            sqlbill = "select * from " & gDebitOutbound & " where blob_id='" & gOutboundID & "' "
            dsbill = ReadDataSet(sqlbill)
            If dsbill.Tables(0).Rows.Count > 0 Then
                refno = rptDoCument.ReportDefinition.ReportObjects("txtrefno")
                refno.text = dsbill.Tables(0).Rows(0).Item("ref")
                refno = rptDoCument.ReportDefinition.ReportObjects("txtnodebit")
                Dim r As Random = New Random
                refno.text = dsbill.Tables(0).Rows(0).Item("nodebit") + "-" + r.Next(100, 999).ToString

                refno = rptDoCument.ReportDefinition.ReportObjects("txthbl")
                refno.text = "..."

                refno = rptDoCument.ReportDefinition.ReportObjects("txtmbl")
                refno.text = dsbill.Tables(0).Rows(0).Item("mblcarrier")
                If Me.chkasperbill.Checked = True Then
                    refno = rptDoCument.ReportDefinition.ReportObjects("Description")
                    refno.text = "AS PER BILL"
                Else
                    refno = rptDoCument.ReportDefinition.ReportObjects("Description")
                    refno.text = dsbill.Tables(0).Rows(0).Item("description").ToString
                End If
                Try
                    refno = rptDoCument.ReportDefinition.ReportObjects("txtVOL")
                    refno.text = "..." 'dsbill.Tables(0).Rows(0).Item("saycontainer")
                Catch ex As Exception

                End Try
                Try
                    refno = rptDoCument.ReportDefinition.ReportObjects("txtissuedby")
                    refno.text = UCase(strUserId)
                Catch ex As Exception

                End Try

                Try
                    refno = rptDoCument.ReportDefinition.ReportObjects("pol")
                    refno.text = dsbill.Tables(0).Rows(0).Item("pol").ToString

                Catch ex As Exception

                End Try
                Try
                    refno = rptDoCument.ReportDefinition.ReportObjects("pod")
                    refno.text = dsbill.Tables(0).Rows(0).Item("pod").ToString

                Catch ex As Exception

                End Try
                refno = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
                refno.text = dsbill.Tables(0).Rows(0).Item("vessel") + "/" + dsbill.Tables(0).Rows(0).Item("voyage")
                refno = rptDoCument.ReportDefinition.ReportObjects("txtcdno")
                refno.text = dsbill.Tables(0).Rows(0).Item("tkhq")

                refno = rptDoCument.ReportDefinition.ReportObjects("txtshippingline")
                refno.text = dsbill.Tables(0).Rows(0).Item("shippingline")

                refno = rptDoCument.ReportDefinition.ReportObjects("arrival")
                refno.text = dsbill.Tables(0).Rows(0).Item("sailingdate") + "/" + dsbill.Tables(0).Rows(0).Item("eta")
            End If
            ' LAY CONT SHOW
            Dim cbm As Double = 0
            Try
                Dim k As Integer
                Dim cont As String = ""
                Dim sqlcont As String
                Dim dscont As New DataSet
                sqlcont = "select * from containertype where outboundID='" & gOutboundID & "'"
                dscont = ReadDataSet(sqlcont)
                If dscont.Tables(0).Rows.Count > 0 Then
                    For k = 0 To dscont.Tables(0).Rows.Count - 1
                        cont += dscont.Tables(0).Rows(k).Item("containerno").ToString + ";"
                        Try
                            cbm += CDbl(dscont.Tables(0).Rows(k).Item("sokhoi").ToString)
                        Catch ex As Exception

                        End Try

                    Next

                End If
                Try
                    refno = rptDoCument.ReportDefinition.ReportObjects("txtcontainer")
                    refno.text = cont
                    refno = rptDoCument.ReportDefinition.ReportObjects("cbm")
                    refno.text = "..."
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try
            '-----------------------
            '--------------------
            Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from debitcredittemp  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' sau khi xoa ta them vao
            ' lay so ref

            '-------------------

            sql = "select * from outboundfreight left join charge on charge.charge_id=outboundfreight.itemid left join outbound on outboundfreight.outboundid=outbound.blob_id where ref='" & gRefOutbound & "' and customerid='" & gOutboundCusID & "' and debitcredit='Debit' " ' os=thu ho

            ' lay so lieu debitnote ghi vao tamdebit
            'thong so 
            'gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            'gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            ds = ReadDataSet(sql)
            'Dim i As Integer
            Dim thanhtien1 As Double = 0
            Dim tongusd As Double = 0
            Dim tongvnd As Double = 0
            Dim tigia As Double = 0
            Dim strQuery1 As String
            Dim rs1 As New ADODB.Recordset
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    Try
                        thanhtien1 += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

                    Catch ex As Exception

                    End Try
                    strQuery1 = "SELECT * "
                    strQuery1 = strQuery1 & "FROM debitcredittemp "
                    rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        ''-------------------------
                        Try
                            .Fields("hbl").Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                        Catch ex As Exception

                        End Try
                        .Fields("stt").Value = ds.Tables(0).Rows(i).Item("stt").ToString
                        .Fields("noidung").Value = ds.Tables(0).Rows(i).Item("dvt").ToString + "(" + ds.Tables(0).Rows(i).Item("mblmawb").ToString + ")"
                        .Fields("soluong").Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                        .Fields("thue").Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
                        .Fields("donvi").Value = "(" + ds.Tables(0).Rows(i).Item("containertype").ToString + ")"
                        .Fields("loaitiente").Value = ds.Tables(0).Rows(i).Item("currency").ToString
                        tigia = ds.Tables(0).Rows(i).Item("tigia").ToString

                        Try
                            .Fields("containerno").Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
                        Catch ex As Exception

                        End Try
                        .Fields("dongia").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
                        .Fields("thanhtien").Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                        If UCase(ds.Tables(0).Rows(i).Item("currency").ToString.Trim) = "VND" Then

                            '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

                            ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString


                            tong += FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
                            tongvnd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

                        Else
                            '.Fields("dongia").Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2)

                            '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

                            ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString
                            ' .Fields("thanhtien").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

                            tong += FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)
                            tongusd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
                        End If


                        .Update()
                    End With
                    rs1.Close()
                Next
            End If
            ''dvhn
            ' thu ho
            '--------------------

            'Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from debitcredittemp_thuho  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' sau khi xoa ta them vao

            sql = "select * from outboundfreight left join charge on charge.charge_id=outboundfreight.itemid where outboundid='" & gOutboundID & "' and customerid='" & gOutboundCusID & "' and debitcredit='Debit' and os=1 " ' os=thu ho

            ' lay so lieu debitnote ghi vao tamdebit
            'thong so 
            'gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            'gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            ds = ReadDataSet(sql)
            Try
                If anAgentInbound = True Then
                    rptDoCument.ReportDefinition.ReportObjects("text1").ObjectFormat.EnableSuppress = True

                    rptDoCument.ReportDefinition.ReportObjects("txttotalamount").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("text14").ObjectFormat.EnableSuppress = True
                    rptDoCument.ReportDefinition.ReportObjects("txtSayVND").ObjectFormat.EnableSuppress = True


                Else

                    rptDoCument.ReportDefinition.ReportObjects("text1").ObjectFormat.EnableSuppress = False

                    rptDoCument.ReportDefinition.ReportObjects("txttotalamount").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("text14").ObjectFormat.EnableSuppress = False
                    rptDoCument.ReportDefinition.ReportObjects("txtSayVND").ObjectFormat.EnableSuppress = False

                End If
            Catch ex As Exception

            End Try
            'Dim i As Integer
            ' Dim thanhtien1 As Double = 0

            ' Dim strQuery1 As String
            'Dim rs1 As New ADODB.Recordset
            'If ds.Tables(0).Rows.Count > 0 Then
            '    For i = 0 To ds.Tables(0).Rows.Count - 1
            '        Try
            '            thanhtien1 += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            '        Catch ex As Exception

            '        End Try
            '        strQuery1 = "SELECT * "
            '        strQuery1 = strQuery1 & "FROM debitcredittemp_thuho "
            '        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            '        With rs1

            '            .AddNew()

            '            .Fields("id").Value = NewId()
            '            ''-------------------------
            '            ''-------------------------
            '            .Fields("stt").Value = ds.Tables(0).Rows(i).Item("stt").ToString
            '            .Fields("noidung").Value = ds.Tables(0).Rows(i).Item("charge").ToString
            '            .Fields("soluong").Value = ds.Tables(0).Rows(i).Item("quantity").ToString
            '            .Fields("thue").Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
            '            .Fields("donvi").Value = "(" + ds.Tables(0).Rows(i).Item("containertype").ToString + ")"
            '            .Fields("loaitiente").Value = ds.Tables(0).Rows(i).Item("currency").ToString

            '            tigia = ds.Tables(0).Rows(i).Item("tigia").ToString
            '            Try
            '                .Fields("containerno").Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
            '            Catch ex As Exception

            '            End Try
            '            .Fields("dongia").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
            '            .Fields("thanhtien").Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
            '            If UCase(ds.Tables(0).Rows(i).Item("currency").ToString.Trim) = "VND" Then

            '                '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

            '                ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString



            '                tongthuho += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
            '                tongvnd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            '            Else
            '                ' .Fields("dongia").Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2)

            '                '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

            '                ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString
            '                ' .Fields("thanhtien").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

            '                tongthuho += CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
            '                tongusd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            '            End If


            '            .Update()
            '        End With
            '        rs1.Close()
            '    Next
            'End If
            ' ''dvhn
            '------------------------------
            'rptDoCument.SetDataSource(ds.Tables(0))
            ' End If
            '------
            Dim tentaikhoan As String
            Dim tk As Object
            tentaikhoan = getOptionValue("debit", "debit", "debit", Me.cbotk.Text, "C")
            tk = rptDoCument.ReportDefinition.ReportObjects("txttaikhoan")
            ' tk.Text = tentaikhoan.ToString
            '------------------------------------------
            Dim tam1() As String
            Dim tam_ As String
            tam1 = Strings.Split(tentaikhoan, Chr(13))
            For CountA As Integer = 0 To tam1.Length - 1
                tam_ &= tam1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = tam1(CountA).Length To tk.Width \ 10
                    tam_ &= " "
                Next
            Next
            tk.Text = tam_
            Dim sqlR As String
            Dim dsR As New DataSet
            'sqlR = "select * from debitcredittemp order by stt "
            'dsR = ReadDataSet(sqlR)
            'rptDoCument.SetDataSource(dsR.Tables(0))
            Try
                tk = rptDoCument.ReportDefinition.ReportObjects("txttotalamount")
                tk.text = FormatNumber(tong + tongthuho, 0)
            Catch ex As Exception

            End Try


            Try
                tk = rptDoCument.ReportDefinition.ReportObjects("txtexchangerate")
                tk.text = FormatNumber(tigia, 0) + ")"
            Catch ex As Exception

            End Try
            If tongvnd = 0 Then
                Try
                    tk = rptDoCument.ReportDefinition.ReportObjects("txttotal")
                    tk.text = "USD " + FormatNumber(tongusd, 2) '+ "    VND " + FormatNumber(tongvnd, 0)
                Catch ex As Exception

                End Try
            Else
                If tongusd = 0 Then
                    Try
                        tk = rptDoCument.ReportDefinition.ReportObjects("txttotal")
                        tk.text = "VND " + FormatNumber(tongvnd, 0)
                    Catch ex As Exception

                    End Try
                Else
                    tk = rptDoCument.ReportDefinition.ReportObjects("txttotal")
                    tk.text = "USD " + FormatNumber(tongusd, 2) + "    VND " + FormatNumber(tongvnd, 0)
                End If

            End If

            Try
                tk = rptDoCument.ReportDefinition.ReportObjects("txtsayvnd")
                tk.text = "Vietnam Dong " + UCase(ENumberToWord(FormatNumber(tong + tongthuho, 0)).Remove(0, 9).Substring(1, 1)) + ENumberToWord(FormatNumber(tong + tongthuho, 0)).Remove(0, 9).Trim.Remove(0, 1)

                '  tk.text = ENumberToWord(FormatNumber(tong + tongthuho, 0)).Remove(0, 9)
            Catch ex As Exception

            End Try
            ' '' '' '' '' ''Dim cmd1 As New ADODB.Command
            ' '' '' '' '' ''cmd1.let_ActiveConnection(strconn)
            ' '' '' '' '' ''cmd1.CommandText = "delete from debitcredittemp  "

            ' '' '' '' '' ''cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            '' '' '' '' '' '' sau khi xoa ta them vao

            ' '' '' '' '' ''sql = "select * from outboundfreight left join charge on charge.charge_id=outboundfreight.itemid where outboundid='" & gOutboundID & "' and customerid='" & gOutboundCusID & "' and debitcredit='Debit' and os=0 " ' os=thu ho

            '' '' '' '' '' '' lay so lieu debitnote ghi vao tamdebit
            '' '' '' '' '' ''thong so 
            '' '' '' '' '' ''gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            '' '' '' '' '' ''gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            ' '' '' '' '' ''ds = ReadDataSet(sql)
            '' '' '' '' '' ''Dim i As Integer
            ' '' '' '' '' ''Dim thanhtien1 As Double = 0
            ' '' '' '' '' ''Dim tongusd As Double = 0
            ' '' '' '' '' ''Dim tongvnd As Double = 0
            ' '' '' '' '' ''Dim tigia As Double = 0
            ' '' '' '' '' ''Dim strQuery1 As String
            ' '' '' '' '' ''Dim rs1 As New ADODB.Recordset
            ' '' '' '' '' ''If ds.Tables(0).Rows.Count > 0 Then
            ' '' '' '' '' ''    For i = 0 To ds.Tables(0).Rows.Count - 1
            ' '' '' '' '' ''        Try
            ' '' '' '' '' ''            thanhtien1 += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            ' '' '' '' '' ''        Catch ex As Exception

            ' '' '' '' '' ''        End Try
            ' '' '' '' '' ''        strQuery1 = "SELECT * "
            ' '' '' '' '' ''        strQuery1 = strQuery1 & "FROM debitcredittemp "
            ' '' '' '' '' ''        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            ' '' '' '' '' ''        With rs1

            ' '' '' '' '' ''            .AddNew()

            ' '' '' '' '' ''            .Fields("id").Value = NewId()
            ' '' '' '' '' ''            ''-------------------------
            ' '' '' '' '' ''            ''-------------------------
            ' '' '' '' '' ''            .Fields("stt").Value = ds.Tables(0).Rows(i).Item("stt").ToString
            ' '' '' '' '' ''            .Fields("noidung").Value = ds.Tables(0).Rows(i).Item("charge").ToString
            ' '' '' '' '' ''            .Fields("soluong").Value = ds.Tables(0).Rows(i).Item("quantity").ToString
            ' '' '' '' '' ''            .Fields("thue").Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
            ' '' '' '' '' ''            .Fields("donvi").Value = ds.Tables(0).Rows(i).Item("containertype").ToString
            ' '' '' '' '' ''            .Fields("loaitiente").Value = ds.Tables(0).Rows(i).Item("currency").ToString
            ' '' '' '' '' ''            tigia = ds.Tables(0).Rows(i).Item("tigia").ToString

            ' '' '' '' '' ''            Try
            ' '' '' '' '' ''                .Fields("containerno").Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
            ' '' '' '' '' ''            Catch ex As Exception

            ' '' '' '' '' ''            End Try
            ' '' '' '' '' ''            .Fields("dongia").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
            ' '' '' '' '' ''            .Fields("thanhtien").Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
            ' '' '' '' '' ''            If UCase(ds.Tables(0).Rows(i).Item("currency").ToString.Trim) = "VND" Then

            ' '' '' '' '' ''                '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

            ' '' '' '' '' ''                ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString


            ' '' '' '' '' ''                tong += FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
            ' '' '' '' '' ''                tongvnd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            ' '' '' '' '' ''            Else
            ' '' '' '' '' ''                '.Fields("dongia").Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2)

            ' '' '' '' '' ''                '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

            ' '' '' '' '' ''                ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString
            ' '' '' '' '' ''                ' .Fields("thanhtien").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

            ' '' '' '' '' ''                tong += FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)
            ' '' '' '' '' ''                tongusd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
            ' '' '' '' '' ''            End If


            ' '' '' '' '' ''            .Update()
            ' '' '' '' '' ''        End With
            ' '' '' '' '' ''        rs1.Close()
            ' '' '' '' '' ''    Next
            ' '' '' '' '' ''End If
            ' '' '' '' '' '' ''dvhn
            '' '' '' '' '' '' thu ho
            '' '' '' '' '' ''--------------------

            '' '' '' '' '' ''Dim cmd1 As New ADODB.Command
            ' '' '' '' '' ''cmd1.let_ActiveConnection(strconn)
            ' '' '' '' '' ''cmd1.CommandText = "delete from debitcredittemp_thuho  "

            ' '' '' '' '' ''cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            '' '' '' '' '' '' sau khi xoa ta them vao

            ' '' '' '' '' ''sql = "select * from outboundfreight left join charge on charge.charge_id=outboundfreight.itemid where outboundid='" & gOutboundID & "' and customerid='" & gOutboundCusID & "' and debitcredit='Debit' and os=1 " ' os=thu ho

            '' '' '' '' '' '' lay so lieu debitnote ghi vao tamdebit
            '' '' '' '' '' ''thong so 
            '' '' '' '' '' ''gInboundID = Me.dgdHBL.Item("BLib_ID", index).Value.ToString
            '' '' '' '' '' ''gInboundCusID = FindValueID(Me.cboCusDebitIn, Me.cboCusDebitIn.Text)
            ' '' '' '' '' ''ds = ReadDataSet(sql)
            '' '' '' '' '' ''Dim i As Integer
            '' '' '' '' '' '' Dim thanhtien1 As Double = 0

            '' '' '' '' '' '' Dim strQuery1 As String
            '' '' '' '' '' ''Dim rs1 As New ADODB.Recordset
            ' '' '' '' '' ''If ds.Tables(0).Rows.Count > 0 Then
            ' '' '' '' '' ''    For i = 0 To ds.Tables(0).Rows.Count - 1
            ' '' '' '' '' ''        Try
            ' '' '' '' '' ''            thanhtien1 += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            ' '' '' '' '' ''        Catch ex As Exception

            ' '' '' '' '' ''        End Try
            ' '' '' '' '' ''        strQuery1 = "SELECT * "
            ' '' '' '' '' ''        strQuery1 = strQuery1 & "FROM debitcredittemp_thuho "
            ' '' '' '' '' ''        rs1.Open(strQuery1, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            ' '' '' '' '' ''        With rs1

            ' '' '' '' '' ''            .AddNew()

            ' '' '' '' '' ''            .Fields("id").Value = NewId()
            ' '' '' '' '' ''            ''-------------------------
            ' '' '' '' '' ''            ''-------------------------
            ' '' '' '' '' ''            .Fields("stt").Value = ds.Tables(0).Rows(i).Item("stt").ToString
            ' '' '' '' '' ''            .Fields("noidung").Value = ds.Tables(0).Rows(i).Item("charge").ToString
            ' '' '' '' '' ''            .Fields("soluong").Value = ds.Tables(0).Rows(i).Item("quantity").ToString
            ' '' '' '' '' ''            .Fields("thue").Value = ds.Tables(0).Rows(i).Item("taxprice").ToString
            ' '' '' '' '' ''            .Fields("donvi").Value = ds.Tables(0).Rows(i).Item("containertype").ToString
            ' '' '' '' '' ''            .Fields("loaitiente").Value = ds.Tables(0).Rows(i).Item("currency").ToString

            ' '' '' '' '' ''            tigia = ds.Tables(0).Rows(i).Item("tigia").ToString
            ' '' '' '' '' ''            Try
            ' '' '' '' '' ''                .Fields("containerno").Value = ds.Tables(0).Rows(i).Item("ngayhoadon").ToString 'ds.Tables(0).Rows(i).Item("container").ToString.Split("-")(0)
            ' '' '' '' '' ''            Catch ex As Exception

            ' '' '' '' '' ''            End Try
            ' '' '' '' '' ''            .Fields("dongia").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2) '* CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
            ' '' '' '' '' ''            .Fields("thanhtien").Value = FormatNumber(ds.Tables(0).Rows(i).Item("price").ToString, 2)
            ' '' '' '' '' ''            If UCase(ds.Tables(0).Rows(i).Item("currency").ToString.Trim) = "VND" Then

            ' '' '' '' '' ''                '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

            ' '' '' '' '' ''                ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString



            ' '' '' '' '' ''                tongthuho += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
            ' '' '' '' '' ''                tongvnd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            ' '' '' '' '' ''            Else
            ' '' '' '' '' ''                ' .Fields("dongia").Value = FormatNumber((CDbl(ds.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)) / ((CDbl(ds.Tables(0).Rows(i).Item("taxprice").ToString) / 100) + 1), 2)

            ' '' '' '' '' ''                '.Fields("subtotal").Value = ds.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

            ' '' '' '' '' ''                ' .Fields("vatamount").Value = ds.Tables(0).Rows(i).Item("pricethue").ToString
            ' '' '' '' '' ''                ' .Fields("thanhtien").Value = FormatNumber(CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString), 2)

            ' '' '' '' '' ''                tongthuho += CDbl(ds.Tables(0).Rows(i).Item("price").ToString) * CDbl(ds.Tables(0).Rows(i).Item("tigia").ToString)
            ' '' '' '' '' ''                tongusd += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)

            ' '' '' '' '' ''            End If


            ' '' '' '' '' ''            .Update()
            ' '' '' '' '' ''        End With
            ' '' '' '' '' ''        rs1.Close()
            ' '' '' '' '' ''    Next
            ' '' '' '' '' ''End If
            ' '' '' '' '' '' ''dvhn
            '' '' '' '' '' ''------------------------------
            '' '' '' '' '' ''rptDoCument.SetDataSource(ds.Tables(0))
            '' '' '' '' '' '' End If
            '' '' '' '' '' ''------
            ' '' '' '' '' ''Dim tentaikhoan As String
            ' '' '' '' '' ''Dim tk As Object
            ' '' '' '' '' ''tentaikhoan = getOptionValue("debit", "debit", "debit", Me.cbotk.Text, "C")
            ' '' '' '' '' ''tk = rptDoCument.ReportDefinition.ReportObjects("txttaikhoan")
            '' '' '' '' '' '' tk.Text = tentaikhoan.ToString
            '' '' '' '' '' ''------------------------------------------
            ' '' '' '' '' ''Dim tam1() As String
            ' '' '' '' '' ''Dim tam_ As String
            ' '' '' '' '' ''tam1 = Strings.Split(tentaikhoan, Chr(13))
            ' '' '' '' '' ''For CountA As Integer = 0 To tam1.Length - 1
            ' '' '' '' '' ''    tam_ &= tam1(CountA).Replace(Chr(10), "  ")
            ' '' '' '' '' ''    For CountSpacea As Integer = tam1(CountA).Length To tk.Width \ 10
            ' '' '' '' '' ''        tam_ &= " "
            ' '' '' '' '' ''    Next
            ' '' '' '' '' ''Next
            ' '' '' '' '' ''tk.Text = tam_
            ' '' '' '' '' ''Dim sqlR As String
            ' '' '' '' '' ''Dim dsR As New DataSet
            '' '' '' '' '' ''sqlR = "select * from debitcredittemp order by stt "
            '' '' '' '' '' ''dsR = ReadDataSet(sqlR)
            '' '' '' '' '' ''rptDoCument.SetDataSource(dsR.Tables(0))
            ' '' '' '' '' ''Try
            ' '' '' '' '' ''    tk = rptDoCument.ReportDefinition.ReportObjects("txttotalamount")
            ' '' '' '' '' ''    tk.text = FormatNumber(tong + tongthuho, 0)
            ' '' '' '' '' ''Catch ex As Exception

            ' '' '' '' '' ''End Try


            ' '' '' '' '' ''Try
            ' '' '' '' '' ''    tk = rptDoCument.ReportDefinition.ReportObjects("txtexchangerate")
            ' '' '' '' '' ''    tk.text = FormatNumber(tigia, 0) + ")"
            ' '' '' '' '' ''Catch ex As Exception

            ' '' '' '' '' ''End Try
            ' '' '' '' '' ''If tongvnd = 0 Then
            ' '' '' '' '' ''    Try
            ' '' '' '' '' ''        tk = rptDoCument.ReportDefinition.ReportObjects("txttotal")
            ' '' '' '' '' ''        tk.text = "USD " + FormatNumber(tongusd, 2) '+ "    VND " + FormatNumber(tongvnd, 0)
            ' '' '' '' '' ''    Catch ex As Exception

            ' '' '' '' '' ''    End Try
            ' '' '' '' '' ''Else
            ' '' '' '' '' ''    If tongusd = 0 Then
            ' '' '' '' '' ''        Try
            ' '' '' '' '' ''            tk = rptDoCument.ReportDefinition.ReportObjects("txttotal")
            ' '' '' '' '' ''            tk.text = "VND " + FormatNumber(tongvnd, 0)
            ' '' '' '' '' ''        Catch ex As Exception

            ' '' '' '' '' ''        End Try
            ' '' '' '' '' ''    Else
            ' '' '' '' '' ''        tk = rptDoCument.ReportDefinition.ReportObjects("txttotal")
            ' '' '' '' '' ''        tk.text = "USD " + FormatNumber(tongusd, 2) + "    VND " + FormatNumber(tongvnd, 0)
            ' '' '' '' '' ''    End If

            ' '' '' '' '' ''End If

            ' '' '' '' '' ''Try
            ' '' '' '' '' ''    tk = rptDoCument.ReportDefinition.ReportObjects("txtsayvnd")
            ' '' '' '' '' ''    tk.text = ENumberToWord(FormatNumber(tong + tongthuho, 0)).Remove(0, 9)
            ' '' '' '' '' ''Catch ex As Exception

            ' '' '' '' '' ''End Try
            'Me.CrystalReportViewer1.ReportSource = rptDoCument
            'Me.CrystalReportViewer1.Show()
            ''---------------------------------

            '---------------------------------------------------------
            '' ''------------------------------------------
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            For Each tbCurrent In rptDoCument.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = strServer
                    .UserID = strUserId
                    .Password = strPassword
                    .DatabaseName = strDatabase
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            rptDoCument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)

            CrystalReportViewer1.ReportSource = rptDoCument
            '------------------------------------------


            '-------------------------------------------------------------
            '-----------chuan bi so lieu ghi vao SOA



            '-------------------------


            'Me.CrystalReportViewer1.ReportSource = rptDoCument
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
    Sub PrintRpt_tigia()
        On Error GoTo Err
        Dim rptDoCument As ReportDocument
        Dim mymargins
        Dim i As Integer
        Dim strReportName As String
        Dim strQuery As String
        QueryBillOfLading()
        QueryCargo()
        QueryCustomerInfo()
        QueryRemark()
        Dim N As Integer = IIf(oTableCargoInfo.Rows.Count - 1 > 16, 16, oTableCargoInfo.Rows.Count - 1)
        Dim k As Integer = oTableCargoInfo.Rows.Count - 1 - N
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

        ' ten Report
        'If k > 0 Or Me.chkAttachDescription.Checked = True Then
        strReportName = "ReportDebit"
        'Else
        'strReportName = "ReportArrivalnoat"
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


        Dim BL, MBL, HBL, ngayin As TextObject
        BL = rptDoCument.ReportDefinition.ReportObjects("BL_NO")
        BL.Text = gBillNoInBound
        ngayin = rptDoCument.ReportDefinition.ReportObjects("txtngay")
        ngayin.Text = "Date :  " + CDate(Getdate()).Date.ToString.Replace("12:00:00 AM", "")

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
            'consignee.Text = tempconsignee
            '------ xuong hang
            'ConsigneeTam1 = Strings.Split(oTableCustomerInfo.Rows(0).Item("Consignee").ToString, Chr(13))
            'For CountA As Integer = 0 To ConsigneeTam1.Length - 1
            '    ConsigneeTam &= ConsigneeTam1(CountA).Replace(Chr(10), "  ")
            '    'For CountSpacea As Integer = ConsigneeTam1(CountA).Length To consignee.Width \ 10
            '    '    ConsigneeTam &= " "
            '    'Next
            'Next
            consignee.Text = frmOutbound.cboCusDebitIn.Text
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
            MBL.Text = oTableBillOfLading.Rows(0).Item("mblcarrier").ToString


            HBL = rptDoCument.ReportDefinition.ReportObjects("txthbl")
            HBL.Text = oTableBillOfLading.Rows(0).Item("mblmawb").ToString
            ' if la hang air thi show hblhawb
            If oTableBillOfLading.Rows(0).Item("hblhawb").ToString.Trim <> "" Then
                HBL.Text = oTableBillOfLading.Rows(0).Item("hblhawb").ToString
            End If



            If Me.chkHBL.Checked = False Then
                rptDoCument.ReportDefinition.ReportObjects("txthbl").ObjectFormat.EnableSuppress = True
            Else
                rptDoCument.ReportDefinition.ReportObjects("txthbl").ObjectFormat.EnableSuppress = False
            End If
            'If flag = 1 Then
            '    Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
            '    Vessel.Text = oTableBillOfLading.Rows(0).Item("OCeanVessel").ToString & " - " & oTableBillOfLading.Rows(0).Item("VoyAge").ToString
            'Else
            Vessel = rptDoCument.ReportDefinition.ReportObjects("OceanVessel")
            Vessel.Text = oTableBillOfLading.Rows(0).Item("Vessel").ToString + "  " + oTableBillOfLading.Rows(0).Item("VoyAge").ToString

            'Voyno = rptDoCument.ReportDefinition.ReportObjects("VoyNo")
            'Voyno.Text = oTableBillOfLading.Rows(0).Item("VoyAge").ToString

            'End If

            'PreVessel = rptDoCument.ReportDefinition.ReportObjects("Pre")
            'PreVessel.Text = oTableBillOfLading.Rows(0).Item("Pre_Vessel").ToString

            'POR = rptDoCument.ReportDefinition.ReportObjects("POR")
            'POR.Text = oTableBillOfLading.Rows(0).Item("POR").ToString

            'STATUSSEND = rptDoCument.ReportDefinition.ReportObjects("TXTSTATUSSEND")
            'STATUSSEND.Text = frmInBoundRemarks.ComboBox1.Text

            POL = rptDoCument.ReportDefinition.ReportObjects("POL")
            POL.Text = oTableBillOfLading.Rows(0).Item("POL").ToString

            POD = rptDoCument.ReportDefinition.ReportObjects("POD")
            POD.Text = oTableBillOfLading.Rows(0).Item("POD").ToString

            DEL = rptDoCument.ReportDefinition.ReportObjects("DEL")
            DEL.Text = oTableBillOfLading.Rows(0).Item("DEL").ToString

            DEST = rptDoCument.ReportDefinition.ReportObjects("DEST")
            DEST.Text = oTableBillOfLading.Rows(0).Item("DEST").ToString

            'CY_CFS = rptDoCument.ReportDefinition.ReportObjects("CY_CFS")
            'CY_CFS.Text = oTableBillOfLading.Rows(0).Item("CY_CFS_ITEM").ToString

            'Shipment = rptDoCument.ReportDefinition.ReportObjects("Shipment")
            'Shipment.Text = oTableBillOfLading.Rows(0).Item("importCY").ToString

            icdPort = rptDoCument.ReportDefinition.ReportObjects("txticdPort")
            icdPort.Text = oTableBillOfLading.Rows(0).Item("importCY").ToString

            ref = rptDoCument.ReportDefinition.ReportObjects("txtrefno")
            ref.Text = oTableBillOfLading.Rows(0).Item("NODEBIT").ToString


            BLtYPE = rptDoCument.ReportDefinition.ReportObjects("TXTBLtYPE")
            BLtYPE.Text = oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString
            '''''''''''''''''''''''''''''''''''''
            'Description og goods


            Dim Temp(), Result As String
            Dim tempTextObject As TextObject
            Result = oTableBillOfLading.Rows(0).Item("DESCRIPTION").ToString
            Temp = Strings.Split(Result, Chr(13))
            QueryCountContainer()
            Result = ""

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
        '' container
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

            'For i As Integer = 0 To N
            '    Dgross += IIf(oTableCargoInfo.Rows(i).Item("GrossWeight").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("GrossWeight"), 0)
            '    Dcbm += IIf(oTableCargoInfo.Rows(i).Item("Meas").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("Meas"), 0)
            '    amount += IIf(oTableCargoInfo.Rows(i).Item("amount").ToString.Trim.Length > 0, oTableCargoInfo.Rows(i).Item("amount"), 0)

            '    tempContainer &= oTableCargoInfo.Rows(i).Item("CONTAINER_NO").ToString & "  " & oTableCargoInfo.Rows(i).Item("CTN_SIZE_TYPE").ToString & "  " & oTableCargoInfo.Rows(i).Item("Seal").ToString
            '    tempContainer &= "                                                                                                   "

            '    AmountUnit = oTableCargoInfo.Rows(0).Item("kind").ToString
            '    kgsUnit = oTableCargoInfo.Rows(0).Item("GrossUnit").ToString
            '    cbmUnit = oTableCargoInfo.Rows(0).Item("measUnit").ToString
            'Next
            'cong 
            Dim kien As Double = 0
            Dim kg As Double = 0
            Dim khoi As Double = 0

            For i = 1 To 9
                If oTableCargoInfo.Rows(0).Item("sokien" + CStr(i)).ToString <> "" Then
                    kien += CDbl(oTableCargoInfo.Rows(0).Item("sokien" + CStr(i)).ToString)
                End If
                If oTableCargoInfo.Rows(0).Item("sokg" + CStr(i)).ToString <> "" Then
                    kg += CDbl(oTableCargoInfo.Rows(0).Item("sokg" + CStr(i)).ToString)
                End If
                If oTableCargoInfo.Rows(0).Item("sokhoi" + CStr(i)).ToString <> "" Then
                    khoi += CDbl(oTableCargoInfo.Rows(0).Item("sokhoi" + CStr(i)).ToString)
                End If

            Next
            txtamount = rptDoCument.ReportDefinition.ReportObjects("txtamount")
            txtamount.Text = "No. Of Pkgs : " + kien.ToString

            Gross = rptDoCument.ReportDefinition.ReportObjects("Gross")
            Gross.Text = "Gross Weight : " + kg.ToString
            CBM = rptDoCument.ReportDefinition.ReportObjects("CBM")
            CBM.Text = "Meas : " + khoi.ToString


            tempContainer = oTableCargoInfo.Rows(0).Item("containerno1").ToString + " " + oTableCargoInfo.Rows(0).Item("seal1").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno2").ToString + " " + oTableCargoInfo.Rows(0).Item("seal2").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno3").ToString + " " + oTableCargoInfo.Rows(0).Item("seal3").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno4").ToString + " " + oTableCargoInfo.Rows(0).Item("seal4").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno5").ToString + " " + oTableCargoInfo.Rows(0).Item("seal5").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno6").ToString + " " + oTableCargoInfo.Rows(0).Item("seal6").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno7").ToString + " " + oTableCargoInfo.Rows(0).Item("seal7").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno8").ToString + " " + oTableCargoInfo.Rows(0).Item("seal8").ToString + " " + oTableCargoInfo.Rows(0).Item("containerno9").ToString + " " + oTableCargoInfo.Rows(0).Item("seal9").ToString
            container = rptDoCument.ReportDefinition.ReportObjects("Container")
            container.Text = tempContainer

        End If
        If oTableremarks.Rows.Count > 0 Then
            Dim arrival, demurage, payment, Shipment, note, BLtYPE, ngaynhanlenh As TextObject
            arrival = rptDoCument.ReportDefinition.ReportObjects("Arrival")
            arrival.Text = CDate(oTableremarks.Rows(0).Item("ETA").ToString)

            ngaynhanlenh = rptDoCument.ReportDefinition.ReportObjects("txtngaynhanlenh")
            ngaynhanlenh.Text = CDate(oTableremarks.Rows(0).Item("ETA").ToString).AddDays(1) + " affer 08h30"


            'If frmInBoundRemarks.chkPrint.Checked Then
            '    demurage = rptDoCument.ReportDefinition.ReportObjects("Demurage")
            '    demurage.Text = CDate(oTableremarks.Rows(0).Item("Demurage").ToString)
            'End If

            payment = rptDoCument.ReportDefinition.ReportObjects("Payment")
            payment.Text = oTableremarks.Rows(0).Item("CY_CFS_ITEM").ToString
            'payment.Text &= "  -  " & IIf(oTableBillOfLading.Rows.Count > 0, oTableBillOfLading.Rows(0).Item("BL_TYPE").ToString, "")

        End If
        '----lay gia tien debit
        Dim phi As Object
        phi = rptDoCument.ReportDefinition.ReportObjects("txtphi")

        Dim ds As New DataSet
        Dim sql, phitam, tam As String
        Dim w, countArr As Integer
        Dim tamArr() As String
        Dim item1, item2, item3, item4, item5, item6, item7, item8, item9, item10 As Object
        Dim cur1, cur2, cur3, cur4, cur5, cur6, cur7, cur8, cur9, cur10 As Object

        Dim unit1, unit2, unit3, unit4, unit5, unit6, unit7, unit8, unit9, unit10 As Object
        Dim quantity1, quantity2, quantity3, quantity4, quantity5, quantity6, quantity7, quantity8, quantity9, quantity10 As Object
        Dim unitprice1, unitprice2, unitprice3, unitprice4, unitprice5, unitprice6, unitprice7, unitprice8, unitprice9, unitprice10 As Object

        Dim price1, price2, price3, price4, price5, price6, price7, price8, price9, price10 As Object
        Dim pricevnd1, pricevnd2, pricevnd3, pricevnd4, pricevnd5, pricevnd6, pricevnd7, pricevnd8, pricevnd9, pricevnd10 As Object

        Dim tax1, tax2, tax3, tax4, tax5, tax6, tax7, tax8, tax9, tax10 As Object
        Dim tongusdvnd, pricebuy1, pricebuy2, pricebuy3, pricebuy4, pricebuy5, pricebuy6, pricebuy7, pricebuy8, pricebuy9, pricebuy10 As Object
        sql = " select * from outbound  where blob_id='" & gOutboundID & "' "
        ds = ReadDataSet(sql)
        ' lay tong
        Dim iT As Integer
        Dim tongvnd As Double = 0
        Dim tongusd As Double = 0
        Dim tongother As Double = 0
        Dim other As String = ""

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
        Dim sqlTen As String
        Dim dsTen As New DataSet
        Dim rowtang As Integer = 1
        If ds.Tables(0).Rows.Count > 0 Then
            If (ds.Tables(0).Rows(0).Item("quantityDebit1").ToString <> "") And (ds.Tables(0).Rows(0).Item("CustomerIDDebit1").ToString = gOutboundCusID) Then


                item1 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item1.Text = ds.Tables(0).Rows(0).Item("itemsDebit1").ToString

                '------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit1").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item1.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item1.Text = ds.Tables(0).Rows(0).Item("itemsDebit1").ToString
                End If
                '-----------------------
                cur1 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur1.Text = ds.Tables(0).Rows(0).Item("currencyDebit1").ToString

                unit1 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit1.Text = ds.Tables(0).Rows(0).Item("container_typeDebit1").ToString

                quantity1 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity1.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit1").ToString, 2) ' doi thanh 


                unitprice1 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice1.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit1").ToString, 2)
                ' cot amount
                price1 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price1.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit1").ToString, 2)
                ' them cot Amount theo ti gia
                pricevnd1 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd1.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit1").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit1").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax1 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax1.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit1").ToString)

                'pricebuy1 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy1.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit1").ToString, 2)

                If ds.Tables(0).Rows(0).Item("currencyDebit1").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit1").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit1").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit1").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit1").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit1").ToString
                End If
                rowtang += 1
            End If

            If ds.Tables(0).Rows(0).Item("quantityDebit2").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit2").ToString = gOutboundCusID) Then


                item2 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item2.Text = ds.Tables(0).Rows(0).Item("itemsDebit2").ToString
                '------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit2").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item2.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item2.Text = ds.Tables(0).Rows(0).Item("itemsDebit2").ToString
                End If
                '-----------------------


                cur2 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur2.Text = ds.Tables(0).Rows(0).Item("currencyDebit2").ToString

                unit2 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit2.Text = ds.Tables(0).Rows(0).Item("container_typeDebit2").ToString

                quantity2 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit2").ToString, 2) ' doi thanh 


                unitprice2 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit2").ToString, 2)


                price2 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit2").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd2 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd2.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit2").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit2").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)


                'tax2 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit2").ToString)

                'pricebuy2 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy2.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit2").ToString, 2)

                If ds.Tables(0).Rows(0).Item("currencyDebit2").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit2").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit2").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit2").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit2").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit2").ToString
                End If


                rowtang += 1
            End If



            If ds.Tables(0).Rows(0).Item("quantityDebit3").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit3").ToString = gOutboundCusID) Then


                item3 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item3.Text = ds.Tables(0).Rows(0).Item("itemsDebit3").ToString
                '---------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit3").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item3.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item3.Text = ds.Tables(0).Rows(0).Item("itemsDebit3").ToString
                End If
                cur3 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur3.Text = ds.Tables(0).Rows(0).Item("currencyDebit3").ToString

                unit3 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit3.Text = ds.Tables(0).Rows(0).Item("container_typeDebit3").ToString

                quantity3 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity3.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit3").ToString, 2) ' doi thanh 


                unitprice3 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice3.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit3").ToString, 2)

                price3 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price3.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit3").ToString, 2)
                ' them cot Amount theo ti gia
                pricevnd3 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd3.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit3").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit3").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)


                'tax3 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax3.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit3").ToString)
                'pricebuy3 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy3.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit3").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit3").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit3").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit3").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit3").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit3").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit3").ToString
                End If


                rowtang += 1
            End If


            If ds.Tables(0).Rows(0).Item("quantityDebit4").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit4").ToString = gOutboundCusID) Then


                item4 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item4.Text = ds.Tables(0).Rows(0).Item("itemsDebit4").ToString
                '-----------------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit4").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item4.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item4.Text = ds.Tables(0).Rows(0).Item("itemsDebit4").ToString
                End If
                '------------------------------------------------------------------
                cur4 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur4.Text = ds.Tables(0).Rows(0).Item("currencyDebit4").ToString

                unit4 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit4.Text = ds.Tables(0).Rows(0).Item("container_typeDebit4").ToString

                quantity4 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity4.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit4").ToString, 2) ' doi thanh 


                unitprice4 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice4.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit4").ToString, 2)

                price4 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price4.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit4").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd4 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd4.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit4").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit4").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax4 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax4.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit4").ToString)
                'pricebuy4 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy4.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit4").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit4").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit4").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit4").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit4").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit4").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit4").ToString
                End If
                rowtang += 1
            End If

            If ds.Tables(0).Rows(0).Item("quantityDebit5").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit5").ToString = gOutboundCusID) Then


                item5 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item5.Text = ds.Tables(0).Rows(0).Item("itemsDebit5").ToString
                '----------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit5").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item5.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item5.Text = ds.Tables(0).Rows(0).Item("itemsDebit5").ToString
                End If
                '-----------------------------------
                cur5 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur5.Text = ds.Tables(0).Rows(0).Item("currencyDebit5").ToString

                unit5 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit5.Text = ds.Tables(0).Rows(0).Item("container_typeDebit5").ToString

                quantity5 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity5.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit5").ToString, 2) ' doi thanh 


                unitprice5 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice5.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit5").ToString, 2)

                price5 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price5.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit5").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd5 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd5.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit5").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit5").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax5 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax5.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit5").ToString)

                'pricebuy5 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy5.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit5").ToString, 2)


                If ds.Tables(0).Rows(0).Item("currencyDebit5").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit5").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit5").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit5").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit5").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit5").ToString
                End If
                rowtang += 1
            End If
            If ds.Tables(0).Rows(0).Item("quantityDebit6").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit6").ToString = gOutboundCusID) Then


                item6 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item6.Text = ds.Tables(0).Rows(0).Item("itemsDebit6").ToString
                '-----------------------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit6").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item6.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item6.Text = ds.Tables(0).Rows(0).Item("itemsDebit6").ToString
                End If
                '-----------------------------------------------
                cur6 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur6.Text = ds.Tables(0).Rows(0).Item("currencyDebit6").ToString

                unit6 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit6.Text = ds.Tables(0).Rows(0).Item("container_typeDebit6").ToString

                quantity6 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity6.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit6").ToString, 2) ' doi thanh 


                unitprice6 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice6.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit6").ToString, 2)

                price6 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price6.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit6").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd6 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd6.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit6").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit6").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax6 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax6.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit6").ToString)
                'pricebuy6 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy6.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit6").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit6").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit6").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit6").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit6").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit6").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit6").ToString
                End If
                rowtang += 1
            End If

            If ds.Tables(0).Rows(0).Item("quantityDebit7").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit7").ToString = gOutboundCusID) Then


                item7 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item7.Text = ds.Tables(0).Rows(0).Item("itemsDebit7").ToString
                '-----------------------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit7").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item7.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item7.Text = ds.Tables(0).Rows(0).Item("itemsDebit7").ToString
                End If
                '-----------------
                cur7 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur7.Text = ds.Tables(0).Rows(0).Item("currencyDebit7").ToString

                unit7 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit7.Text = ds.Tables(0).Rows(0).Item("container_typeDebit7").ToString

                quantity7 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity7.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit7").ToString, 2) ' doi thanh 


                unitprice7 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice7.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit7").ToString, 2)


                price7 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price7.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit7").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd7 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd7.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit7").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit7").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax7 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax7.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit7").ToString)
                'pricebuy7 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy7.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit7").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit7").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit7").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit7").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit7").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit7").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit7").ToString
                End If
                rowtang += 1
            End If
            If ds.Tables(0).Rows(0).Item("quantityDebit8").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit8").ToString = gOutboundCusID) Then


                item8 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item8.Text = ds.Tables(0).Rows(0).Item("itemsDebit8").ToString
                '-----------------------------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit8").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item8.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item8.Text = ds.Tables(0).Rows(0).Item("itemsDebit8").ToString
                End If
                '------------------------------------
                cur8 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur8.Text = ds.Tables(0).Rows(0).Item("currencyDebit8").ToString

                unit8 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit8.Text = ds.Tables(0).Rows(0).Item("container_typeDebit8").ToString

                quantity8 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity8.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit8").ToString, 2) ' doi thanh 


                unitprice8 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice8.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit8").ToString, 2)

                price8 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price8.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit8").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd8 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd8.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit8").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit8").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax8 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax8.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit8").ToString)
                'pricebuy8 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy8.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit8").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit8").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit8").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit8").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit8").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit8").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit8").ToString
                End If
                rowtang += 1
            End If
            If ds.Tables(0).Rows(0).Item("quantityDebit9").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit9").ToString = gOutboundCusID) Then


                item9 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item9.Text = ds.Tables(0).Rows(0).Item("itemsDebit9").ToString
                '-----------------------------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit9").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item9.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item9.Text = ds.Tables(0).Rows(0).Item("itemsDebit9").ToString
                End If
                '------------------------------------
                cur9 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur9.Text = ds.Tables(0).Rows(0).Item("currencyDebit9").ToString

                unit9 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit9.Text = ds.Tables(0).Rows(0).Item("container_typeDebit9").ToString

                quantity9 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity9.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit9").ToString, 2) ' doi thanh 


                unitprice9 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice9.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit9").ToString, 2)


                price9 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price9.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit9").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd9 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd9.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit9").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit9").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax9 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax9.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit9").ToString)
                'pricebuy9 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy9.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit9").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit9").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit9").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit9").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit9").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit9").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit9").ToString
                End If
                rowtang += 1
            End If
            If ds.Tables(0).Rows(0).Item("quantityDebit10").ToString <> "" And (ds.Tables(0).Rows(0).Item("CustomerIDDebit10").ToString = gOutboundCusID) Then


                item10 = rptDoCument.ReportDefinition.ReportObjects("txtitem" + CStr(rowtang))
                item10.Text = ds.Tables(0).Rows(0).Item("itemsDebit10").ToString
                '-----------------------------------------
                sqlTen = " select * from charge where charge like  N'%" & ds.Tables(0).Rows(0).Item("itemsDebit10").ToString & "%' "
                dsTen = ReadDataSet(sqlTen)
                If dsTen.Tables(0).Rows.Count > 0 Then
                    item10.Text = dsTen.Tables(0).Rows(0).Item("charge_code").ToString
                Else
                    item10.Text = ds.Tables(0).Rows(0).Item("itemsDebit10").ToString
                End If
                '------------------------------------
                cur10 = rptDoCument.ReportDefinition.ReportObjects("txtcur" + CStr(rowtang))
                cur10.Text = ds.Tables(0).Rows(0).Item("currencyDebit10").ToString

                unit10 = rptDoCument.ReportDefinition.ReportObjects("txtunit" + CStr(rowtang))
                unit10.Text = ds.Tables(0).Rows(0).Item("container_typeDebit10").ToString

                quantity10 = rptDoCument.ReportDefinition.ReportObjects("txtquantity" + CStr(rowtang))
                quantity10.Text = FormatNumber(ds.Tables(0).Rows(0).Item("QuantityDebit10").ToString, 2) ' doi thanh 


                unitprice10 = rptDoCument.ReportDefinition.ReportObjects("txtUnitprice" + CStr(rowtang))
                unitprice10.Text = FormatNumber(ds.Tables(0).Rows(0).Item("UnitpriceDebit10").ToString, 2)

                price10 = rptDoCument.ReportDefinition.ReportObjects("txtprice" + CStr(rowtang))
                price10.Text = FormatNumber(ds.Tables(0).Rows(0).Item("pricetruocthueDebit10").ToString, 2)

                ' them cot Amount theo ti gia
                pricevnd10 = rptDoCument.ReportDefinition.ReportObjects("txtpricevnd" + CStr(rowtang))
                pricevnd10.Text = FormatNumber(CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit10").ToString) * tigia(ds.Tables(0).Rows(0).Item("CurrencyDebit10").ToString, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

                'tax10 = rptDoCument.ReportDefinition.ReportObjects("txttax" + CStr(rowtang))
                'tax10.Text = FormatNumber(ds.Tables(0).Rows(0).Item("taxpriceDebit10").ToString)
                'pricebuy10 = rptDoCument.ReportDefinition.ReportObjects("txtamount" + CStr(rowtang))
                'pricebuy10.Text = FormatNumber(ds.Tables(0).Rows(0).Item("priceDebit10").ToString, 2)
                If ds.Tables(0).Rows(0).Item("currencyDebit10").ToString = "USD" Then
                    tongusd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit10").ToString)
                ElseIf ds.Tables(0).Rows(0).Item("currencyDebit10").ToString = "VND" Then
                    tongvnd += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit10").ToString)
                Else
                    tongother += CDbl(ds.Tables(0).Rows(0).Item("pricetruocthueDebit10").ToString)
                    other = ds.Tables(0).Rows(0).Item("currencyDebit10").ToString
                End If
                rowtang += 1
            End If


        End If
        Dim tienchuusd, tienchuvnd, tongusdvnd1, tongcong As Object
        tienchuusd = rptDoCument.ReportDefinition.ReportObjects("txtsayusd")
        tienchuvnd = rptDoCument.ReportDefinition.ReportObjects("txtsayVND")

        tongusdvnd = rptDoCument.ReportDefinition.ReportObjects("totalUSDVND")
        tongusdvnd.Text = "Total Amount:   VND " + FormatNumber(tongvnd, 2) + "  " + "USD " + FormatNumber(tongusd, 2) + "  " + other + " " + FormatNumber(tongother, 2)

        tongusdvnd1 = rptDoCument.ReportDefinition.ReportObjects("totalUSDVND1")
        tongusdvnd1.Text = "Sub Total:   VND " + FormatNumber(tongvnd, 2) + "  " + "VND " + FormatNumber(CDbl(tongusd) * tigia("USD", ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2) + "  " + "VND " + FormatNumber(CDbl(tongother) * tigia(other, ds.Tables(0).Rows(0).Item("sailingdate").ToString), 2)

        Dim TONG As Double = CDbl(tongvnd) + CDbl(tongusd) * tigia("USD", ds.Tables(0).Rows(0).Item("eta").ToString) + CDbl(tongother) * tigia(other, ds.Tables(0).Rows(0).Item("sailingdate").ToString)

        'If dsTong.Tables(0).Rows(i).Item("currency").ToString = "USD" Then
        ' If tongusd > 0 Then
        tongcong = rptDoCument.ReportDefinition.ReportObjects("tongcong")
        tongcong.Text = FormatNumber(TONG, 0).ToString
        tienchuusd.text = VNumberToWord(CDbl(TONG), "VND")
        ' End If


        ' tienchuvnd = ENumberToWord(CDbl(tongvnd), "VND")
        'Else
        ' If tongvnd > 0 Then
        ' tienchuvnd.Text = VNumberToWord(CDbl(tongvnd), "VND")
        ' End If


        'For w = 0 To ds.Tables(0).Rows.Count - 1

        'phitam += (w + 1).ToString + ". " + ds.Tables(0).Rows(w).Item("ITEMS").ToString + " : " + ds.Tables(0).Rows(w).Item("priceBAN").ToString + ds.Tables(0).Rows(w).Item("currency").ToString + "  " + ds.Tables(0).Rows(w).Item("remarks").ToString + Chr(13)
        'Next

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
        Exit Sub
Err:

        Me.Close()
        MsgBox(msgErr(Me, Err.Description))
    End Sub
    Private Sub frmRptArrival_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.chkAttachDescription.Visible = False
        chkoversea.Text = "Oversea"
        chkoversea.Visible = False
        Me.Text = "DEBIT NOTE"
        'If frmInBoundRemarks.CountBill > 1 Then

        '    Me.Hide()
        'End If
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

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub

    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        'If Me.chkTigia.Checked = True Then
        '    PrintRpt_tigia()
        'Else
        PrintRpt()
        '  End If

    End Sub
    Dim sochungtu, ngay, customerid, amountdebit, amountcredit, chiho, total, mblhbl As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            strQuery = " select * from soa WHERE sochungtu='" & sochungtu & "' and customerid='" & customerid & "'"
            rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            With rs
                If rs.EOF Then
                    .AddNew()
                    .Fields("soaid").Value = NewId()
                End If

                .Fields("customerid").Value = "{" + customerid + "}"
                .Fields("ngay").Value = ngay
                .Fields("sochungtu").Value = sochungtu
                Try
                    .Fields("mblhbl").Value = mblhbl
                Catch ex As Exception

                End Try

                .Fields("amountdebit").Value = amountdebit
                .Fields("CUR").Value = "VND" ' mac dinh. co the sua lai theo yeu cau
                '  .Fields("amountcredit").Value = amountcredit
                .Fields("chiho").Value = chiho
                .Fields("total").Value = total
                .Fields("iol").Value = "I"

                '--------22-jun
                '.Fields("tkhq").Value = Me.txttkhq.Text
                .Update()
            End With
            rs.Close()
            DisplayMessage(True, "Complete.!(SOA)")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbotk_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbotk.SelectedIndexChanged

    End Sub
End Class