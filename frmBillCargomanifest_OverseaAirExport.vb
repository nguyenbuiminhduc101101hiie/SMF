Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmBillCargomanifest_OverseaAirExport

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


















    Sub PrintRpt()
        Try

            sochungtu = ""
            ngay = ""
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

            ' ten Report
            'If k > 0 Or Me.chkAttachDescription.Checked = True Then

            strReportName = "rptAirCargoManifest"
            'Try
            '    If Me.chkoversea.Checked = True Then
            '        strReportName = "ReportDebitOversea"
            '    Else
            '        strReportName = "ReportDebit"
            '    End If
            'Catch ex As Exception

            'End Try
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
            ' lay thong tin tu debit/credit
            'chen thongtin debit vao table tamdebit
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from aircargomanifest  "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            Dim sqldebit As String
            Dim dsdebit As New DataSet
            sqldebit = "select  * from Outbound_OverseaAirExport where blob_id= '" & gOutboundID & "' "

            dsdebit = ReadDataSet(sqldebit)
            ' lay mbl
            If dsdebit.Tables(0).Rows.Count > 0 Then

            Else
                Exit Sub
            End If
            Dim sqlhawb As String
            Dim dshawb As New DataSet
            sqlhawb = "select * from Outbound_OverseaAirExport where mblcarrier='" & dsdebit.Tables(0).Rows(0).Item("mblcarrier").ToString & "' order by mblmawb "
            dshawb = ReadDataSet(sqlhawb)

            If dshawb.Tables(0).Rows.Count > 0 Then
                For i = 0 To dshawb.Tables(0).Rows.Count - 1
                    Dim rs As New ADODB.Recordset
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM aircargomanifest "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        '.Fields("id").Value = "{" + gOutboundID + "}"
                        '-------------------------
                        Try
                            .Fields("no").Value = dshawb.Tables(0).Rows(i).Item("mblcarrier").ToString.Substring(dshawb.Tables(0).Rows(i).Item("mblcarrier").ToString.Length - 4, 4)

                        Catch ex As Exception

                        End Try
                        .Fields("airline").Value = dshawb.Tables(0).Rows(i).Item("agencyname").ToString

                        .Fields("eta").Value = dshawb.Tables(0).Rows(i).Item("eta").ToString
                        .Fields("mawb").Value = dshawb.Tables(0).Rows(i).Item("mblcarrier").ToString
                        .Fields("original").Value = dshawb.Tables(0).Rows(i).Item("AirportDeparture").ToString
                        .Fields("dest").Value = dshawb.Tables(0).Rows(i).Item("AirPortDes").ToString
                        .Fields("flightno").Value = dshawb.Tables(0).Rows(i).Item("fv1").ToString + " / " + dshawb.Tables(0).Rows(i).Item("fd1").ToString
                        .Fields("specialIntruction").Value = dshawb.Tables(0).Rows(i).Item("remarks").ToString
                        .Fields("destination").Value = dshawb.Tables(0).Rows(i).Item("AirPortDes").ToString
                        .Fields("hawb").Value = dshawb.Tables(0).Rows(i).Item("mblmawb").ToString
                        Try
                            .Fields("cartonno").Value = dshawb.Tables(0).Rows(i).Item("rcp").ToString
                        Catch ex As Exception
                            .Fields("cartonno").Value = 0
                        End Try

                        Try
                            .Fields("weight").Value = dshawb.Tables(0).Rows(i).Item("gw").ToString
                        Catch ex As Exception
                            .Fields("weight").Value = 0
                        End Try

                        .Fields("description").Value = dshawb.Tables(0).Rows(i).Item("nature").ToString
                        Try
                            .Fields("consignee").Value = dshawb.Tables(0).Rows(i).Item("consignee").ToString
                        Catch ex As Exception
                            .Fields("consignee").Value = 0
                        End Try
                        .Update()


                    End With
                    rs.Close()
                Next
            End If



            ' sau khi xoa ta them vao



          
            '--------------------------------------------

            '--------------------------------------------
            '  rptDoCument.SetDataSource(dshawb)
            rptDoCument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)
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
            '---------------------------------------------------------------------------------

         

        


         
       

       
         
            '--------------connect ko can login
            Dim connection As IConnectionInfo
            For Each connection In rptDoCument.DataSourceConnections

                'Select Case connection.ServerName

                '    Case strServer
                connection.SetConnection(strServer, strDatabase, strUserId, strPassword)
                '        ' connection.SetLogon(strUserId, strPassword)

                'End Select

            Next
            '------------
            'Set Database Logon to subreport

            Dim subreport As ReportDocument

            For Each subreport In rptDoCument.Subreports

                For Each connection In subreport.DataSourceConnections

                    'Select Case connection.ServerName

                    '    Case strServer

                    connection.SetConnection(strServer, strDatabase, strUserId, strPassword)

                    'End Select

                Next

            Next
            '----------------------------------------------------------------------------

          
         
            '---------------------------------
            Dim tentaikhoan As String
            Dim tk As Object

            'tentaikhoan = getOptionValue("debit", "debit", "debit", Me.cbotk.Text, "C")
            'tk = rptDoCument.ReportDefinition.ReportObjects("txttaikhoan")
            ' tk.Text = tentaikhoan.ToString
            '------------------------------------------
            Dim tam1() As String
            Dim tam_ As String
            'tam1 = Strings.Split(tentaikhoan, Chr(13))
            'For CountA As Integer = 0 To tam1.Length - 1
            '    tam_ &= tam1(CountA).Replace(Chr(10), "  ")
            '    For CountSpacea As Integer = tam1(CountA).Length To tk.Width \ 10
            '        tam_ &= " "
            '    Next
            'Next
            'tk.Text = tam_
            '------------------------------------------
            'Dim dt As Date
            'dt = frmInBoundRemarks.dtpPrintdate.Value
            'Dim d, m, y As TextObject
            'd = rptDoCument.ReportDefinition.ReportObjects("Day")
            'd.Text = dt.Day
            'm = rptDoCument.ReportDefinition.ReportObjects("Month")
            'm.Text = dt.Month
            'y = rptDoCument.ReportDefinition.ReportObjects("Year")
            'y.Text = dt.Year
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            'Formatting paper

            'If flag = 1 Then
            '    mymargins = rptDoCument.PrintOptions.PageMargins
            '    mymargins.topMargin = gTopM
            '    mymargins.bottomMargin = gBottomM
            '    mymargins.leftMargin = gLeftM
            '    mymargins.rightMargin = gRightM
            '    'rptDoCument.PrintOptions.ApplyPageMargins(mymargins)
            'End If
            'rptDoCument.PrintOptions.PaperSize = PaperSize.PaperA4
            'If frmMain.mnuReportOrientationPortrait.Checked Then
            '    rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
            'Else
            '    rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
            'End If
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
        chkoversea.Text = "Oversea"
        If frmInBoundRemarks.CountBill > 1 Then

            Me.Hide()
        End If
        PrintRpt()
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
    Dim sochungtu, ngay, customerid, amountdebit, amountcredit, chiho, total As String
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
                .Fields("amountdebit").Value = amountdebit
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
End Class