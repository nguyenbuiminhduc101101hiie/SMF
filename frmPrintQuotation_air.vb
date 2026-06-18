Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmPrintQuotation_air


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







    Private Sub QueryBillOfLading(Optional ByVal argCriteria As String = "", Optional ByVal index As Integer = 1, Optional ByVal location As Integer = 0)
        On Error GoTo Err_Renamed
        Dim strQuery As String
        '-------------
        Dim Con As New SqlClient.SqlConnection(strconnDG)
        Dim ds As New DataSet
        '----------------
        'If IsNothing(argCriteria) Then
        strQuery = "Select * from quotationTico where quotationticoID='" & gPrintQuotationTICOID & "' "
        'Else
        '    strQuery = ""
        'End If
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











    Sub PrintRpt()
        Try
            Dim rptDoCument As New ReportDocument
            Dim mymargins
            Dim strReportName As String
            Dim strQuery As String
            Dim rs As New ADODB.Recordset
            Dim ds As New DataSet
            Dim i As Integer
            Dim tong As Double = 0
            QueryBillOfLading()
            strReportName = "rptQuotationTICO_Air"


            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDoCument.Load(strReportPath)
            'If Me.chkDH.Checked = True Then
            '    rptDoCument.ReportDefinition.ReportObjects("logoDh").ObjectFormat.EnableSuppress = False
            '    rptDoCument.ReportDefinition.ReportObjects("logowm").ObjectFormat.EnableSuppress = True
            'Else
            '    rptDoCument.ReportDefinition.ReportObjects("logoDh").ObjectFormat.EnableSuppress = True
            '    rptDoCument.ReportDefinition.ReportObjects("logowm").ObjectFormat.EnableSuppress = False
            'End If
            '-----------------------------------------
            'bang 1===========================================================================================
            ' xoa table intamquotation
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from intamquotation  "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            '-------------------------------------------
            Dim sql As String
            sql = "select * from quotationticodetails where quotationticoid='" & gPrintQuotationTICOID & "' and textshow='1' and sea_air='AIR' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then
                ' rptDoCument.ReportDefinition.ReportObjects("Subreport1").ObjectFormat.EnableSuppress = False
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM intamquotation "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        '.Fields("stt").Value = ds.Tables(0).Rows.Count - i
                        .Fields("items").Value = ds.Tables(0).Rows(i).Item("items").ToString
                        .Fields("price").Value = ds.Tables(0).Rows(i).Item("price").ToString
                        Try
                            tong += CDbl(ds.Tables(0).Rows(i).Item("price").ToString)
                        Catch ex As Exception

                        End Try

                        .Fields("unitprice").Value = ds.Tables(0).Rows(i).Item("unitprice").ToString
                        .Fields("quantity").Value = ds.Tables(0).Rows(i).Item("quantity").ToString
                        .Fields("type").Value = ds.Tables(0).Rows(i).Item("type").ToString
                        .Fields("cur").Value = ds.Tables(0).Rows(i).Item("cur").ToString
                        .Fields("stt").Value = ds.Tables(0).Rows(i).Item("stt").ToString
                        .Fields("hienthi").Value = ds.Tables(0).Rows(i).Item("hienthi").ToString
                        Try
                            If UCase(ds.Tables(0).Rows(i).Item("items").ToString) Like "*O/F*" Or UCase(ds.Tables(0).Rows(i).Item("items").ToString) Like "*OF*" Or UCase(ds.Tables(0).Rows(i).Item("items").ToString) Like "*FREIGHT*" Then
                                .Fields("notlocalcharge").Value = True
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("ppcc").Value = ds.Tables(0).Rows(i).Item("ppcc").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("vat").Value = ds.Tables(0).Rows(i).Item("vat").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("priceincvat").Value = ds.Tables(0).Rows(i).Item("priceincvat").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("remarks_phi").Value = ds.Tables(0).Rows(i).Item("remarks_phi").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_airlines").Value = ds.Tables(0).Rows(i).Item("air_airlines").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_destination").Value = ds.Tables(0).Rows(i).Item("air_destination").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_min").Value = ds.Tables(0).Rows(i).Item("air_min").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_normal").Value = ds.Tables(0).Rows(i).Item("air_normal").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_45").Value = ds.Tables(0).Rows(i).Item("air_45").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_100").Value = ds.Tables(0).Rows(i).Item("air_100").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_300").Value = ds.Tables(0).Rows(i).Item("air_300").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_500").Value = ds.Tables(0).Rows(i).Item("air_500").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_1000").Value = ds.Tables(0).Rows(i).Item("air_1000").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_awb").Value = ds.Tables(0).Rows(i).Item("air_awb").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_xray").Value = ds.Tables(0).Rows(i).Item("air_xray").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("air_ams").Value = ds.Tables(0).Rows(i).Item("air_ams").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_fsc").Value = ds.Tables(0).Rows(i).Item("air_fsc").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_Frequency").Value = ds.Tables(0).Rows(i).Item("air_Frequency").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_ssc").Value = ds.Tables(0).Rows(i).Item("air_ssc").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("air_Transittime").Value = ds.Tables(0).Rows(i).Item("air_Transittime").ToString
                        Catch ex As Exception

                        End Try


                        .Update()
                    End With
                    rs.Close()
                Next
            Else
                '  rptDoCument.ReportDefinition.ReportObjects("Subreport1").ObjectFormat.EnableSuppress = True
            End If
            '======================================================================================

            'bang 2===========================================================================================
            ' xoa table intamquotation
            'Dim cmd1 As New ADODB.Command
            'cmd1.let_ActiveConnection(strconn)
            'cmd1.CommandText = "delete from intamquotation1  "

            'cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            ''-------------------------------------------
            'Dim sql1 As String
            'Dim ds1 As New DataSet
            'sql1 = "select * from quotationticodetails where quotationticoid='" & gPrintQuotationTICOID & "' and textshow='2' and sea_air='AIR' "
            'ds1 = ReadDataSet(sql1)
            'If ds1.Tables(0).Rows.Count > 0 Then
            '    ' rptDoCument.ReportDefinition.ReportObjects("Subreport3").ObjectFormat.EnableSuppress = False
            '    For i = 0 To ds1.Tables(0).Rows.Count - 1
            '        strQuery = "SELECT * "
            '        strQuery = strQuery & "FROM intamquotation1 "
            '        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            '        With rs

            '            .AddNew()

            '            .Fields("id").Value = NewId()
            '            ''-------------------------
            '            '.Fields("stt").Value = ds.Tables(0).Rows.Count - i
            '            .Fields("items").Value = ds1.Tables(0).Rows(i).Item("items").ToString
            '            .Fields("price").Value = ds1.Tables(0).Rows(i).Item("price").ToString
            '            Try
            '                tong += CDbl(ds1.Tables(0).Rows(i).Item("price").ToString)
            '            Catch ex As Exception

            '            End Try

            '            .Fields("unitprice").Value = ds1.Tables(0).Rows(i).Item("unitprice").ToString
            '            .Fields("quantity").Value = ds1.Tables(0).Rows(i).Item("quantity").ToString
            '            .Fields("type").Value = ds1.Tables(0).Rows(i).Item("type").ToString
            '            .Fields("cur").Value = ds1.Tables(0).Rows(i).Item("cur").ToString
            '            .Fields("stt").Value = ds1.Tables(0).Rows(i).Item("stt").ToString
            '            .Fields("hienthi").Value = ds1.Tables(0).Rows(i).Item("hienthi").ToString
            '            Try
            '                If UCase(ds1.Tables(0).Rows(i).Item("items").ToString) Like "*O/F*" Or UCase(ds1.Tables(0).Rows(i).Item("items").ToString) Like "*OF*" Or UCase(ds1.Tables(0).Rows(i).Item("items").ToString) Like "*FREIGHT*" Then
            '                    .Fields("notlocalcharge").Value = True
            '                End If
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("ppcc").Value = ds1.Tables(0).Rows(i).Item("ppcc").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("vat").Value = ds1.Tables(0).Rows(i).Item("vat").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("priceincvat").Value = ds1.Tables(0).Rows(i).Item("priceincvat").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("remarks_phi").Value = ds1.Tables(0).Rows(i).Item("remarks_phi").ToString
            '            Catch ex As Exception

            '            End Try
            '            ' --hang air
            '            Try
            '                .Fields("air_airlines").Value = ds1.Tables(0).Rows(i).Item("air_airlines").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_destination").Value = ds1.Tables(0).Rows(i).Item("air_destination").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_min").Value = ds1.Tables(0).Rows(i).Item("air_min").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_normal").Value = ds1.Tables(0).Rows(i).Item("air_normal").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_45").Value = ds1.Tables(0).Rows(i).Item("air_45").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_100").Value = ds1.Tables(0).Rows(i).Item("air_100").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_300").Value = ds1.Tables(0).Rows(i).Item("air_300").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_500").Value = ds1.Tables(0).Rows(i).Item("air_500").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_1000").Value = ds1.Tables(0).Rows(i).Item("air_1000").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_awb").Value = ds1.Tables(0).Rows(i).Item("air_awb").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_xray").Value = ds1.Tables(0).Rows(i).Item("air_xray").ToString
            '            Catch ex As Exception

            '            End Try

            '            Try
            '                .Fields("air_ams").Value = ds1.Tables(0).Rows(i).Item("air_ams").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_fsc").Value = ds1.Tables(0).Rows(i).Item("air_fsc").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_ssc").Value = ds.Tables(0).Rows(i).Item("air_ssc").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_Frequency").Value = ds1.Tables(0).Rows(i).Item("air_Frequency").ToString
            '            Catch ex As Exception

            '            End Try
            '            Try
            '                .Fields("air_Transittime").Value = ds1.Tables(0).Rows(i).Item("air_Transittime").ToString
            '            Catch ex As Exception

            '            End Try




            '            .Update()
            '        End With
            '        rs.Close()
            '    Next
            'Else
            '    '  rptDoCument.ReportDefinition.ReportObjects("Subreport2").ObjectFormat.EnableSuppress = True
            'End If
            Try
                'bang 2===========================================================================================
                ' xoa table intamquotation
                Dim cmd1 As New ADODB.Command
                cmd1.let_ActiveConnection(strconn)
                cmd1.CommandText = "delete from intamquotation1  "

                cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)

                '-------------------------------------------
                Dim sql1 As String
                Dim ds1 As New DataSet
                sql1 = "select * from quotationticodetails where quotationticoid='" & gPrintQuotationTICOID & "'  and sea_air='SEA' and textshow='1'  "
                ds1 = ReadDataSet(sql1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    '  rptDoCument.ReportDefinition.ReportObjects("Subreport3").ObjectFormat.EnableSuppress = False
                    For i = 0 To ds1.Tables(0).Rows.Count - 1
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM intamquotation1 "
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs

                            .AddNew()

                            .Fields("id").Value = NewId()
                            ''-------------------------
                            '.Fields("stt").Value = ds.Tables(0).Rows.Count - i
                            .Fields("items").Value = ds1.Tables(0).Rows(i).Item("items").ToString
                            .Fields("price").Value = ds1.Tables(0).Rows(i).Item("price").ToString
                            Try
                                tong += CDbl(ds1.Tables(0).Rows(i).Item("price").ToString)
                            Catch ex As Exception

                            End Try

                            .Fields("unitprice").Value = ds1.Tables(0).Rows(i).Item("unitprice").ToString
                            .Fields("quantity").Value = ds1.Tables(0).Rows(i).Item("quantity").ToString
                            .Fields("type").Value = ds1.Tables(0).Rows(i).Item("type").ToString
                            .Fields("cur").Value = ds1.Tables(0).Rows(i).Item("cur").ToString
                            .Fields("stt").Value = ds1.Tables(0).Rows(i).Item("stt").ToString
                            .Fields("hienthi").Value = ds1.Tables(0).Rows(i).Item("hienthi").ToString
                            Try
                                If UCase(ds1.Tables(0).Rows(i).Item("items").ToString) Like "*O/F*" Or UCase(ds1.Tables(0).Rows(i).Item("items").ToString) Like "*OF*" Or UCase(ds1.Tables(0).Rows(i).Item("items").ToString) Like "*FREIGHT*" Then
                                    .Fields("notlocalcharge").Value = True
                                End If
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("ppcc").Value = ds1.Tables(0).Rows(i).Item("ppcc").ToString
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("vat").Value = ds1.Tables(0).Rows(i).Item("vat").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("priceincvat").Value = ds1.Tables(0).Rows(i).Item("priceincvat").ToString
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("remarks_phi").Value = ds1.Tables(0).Rows(i).Item("remarks_phi").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("org").Value = ds1.Tables(0).Rows(i).Item("org").ToString
                            Catch ex As Exception

                            End Try
                            Try
                                .Fields("des").Value = ds1.Tables(0).Rows(i).Item("des").ToString
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("req").Value = ds1.Tables(0).Rows(i).Item("req").ToString
                            Catch ex As Exception

                            End Try

                            Try
                                .Fields("tt").Value = ds1.Tables(0).Rows(i).Item("tt").ToString
                            Catch ex As Exception

                            End Try
                            .Update()
                        End With
                        rs.Close()
                    Next
                Else
                    ' rptDoCument.ReportDefinition.ReportObjects("Subreport3").ObjectFormat.EnableSuppress = True
                End If
            Catch ex As Exception

            End Try
            '======================================================================================
            'bang 2===========================================================================================
            ' xoa table intamquotation
            Dim cmd2 As New ADODB.Command
            cmd2.let_ActiveConnection(strconn)
            cmd2.CommandText = "delete from intamquotation2  "

            cmd2.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            '-------------------------------------------
            Dim sql2 As String
            Dim ds2 As New DataSet
            sql2 = "select * from quotationticodetails where quotationticoid='" & gPrintQuotationTICOID & "'  and sea_air='SEA'  and textshow='2'  "
            ds2 = ReadDataSet(sql2)
            If ds2.Tables(0).Rows.Count > 0 Then
                '  rptDoCument.ReportDefinition.ReportObjects("Subreport3").ObjectFormat.EnableSuppress = False
                For i = 0 To ds2.Tables(0).Rows.Count - 1
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM intamquotation2 "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        '.Fields("stt").Value = ds.Tables(0).Rows.Count - i
                        .Fields("items").Value = ds2.Tables(0).Rows(i).Item("items").ToString
                        .Fields("price").Value = ds2.Tables(0).Rows(i).Item("price").ToString
                        Try
                            tong += CDbl(ds2.Tables(0).Rows(i).Item("price").ToString)
                        Catch ex As Exception

                        End Try

                        .Fields("unitprice").Value = ds2.Tables(0).Rows(i).Item("unitprice").ToString
                        .Fields("quantity").Value = ds2.Tables(0).Rows(i).Item("quantity").ToString
                        .Fields("type").Value = ds2.Tables(0).Rows(i).Item("type").ToString
                        .Fields("cur").Value = ds2.Tables(0).Rows(i).Item("cur").ToString
                        .Fields("stt").Value = ds2.Tables(0).Rows(i).Item("stt").ToString
                        .Fields("hienthi").Value = ds2.Tables(0).Rows(i).Item("hienthi").ToString
                        Try
                            If UCase(ds2.Tables(0).Rows(i).Item("items").ToString) Like "*O/F*" Or UCase(ds2.Tables(0).Rows(i).Item("items").ToString) Like "*OF*" Or UCase(ds2.Tables(0).Rows(i).Item("items").ToString) Like "*FREIGHT*" Then
                                .Fields("notlocalcharge").Value = True
                            End If
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("ppcc").Value = ds2.Tables(0).Rows(i).Item("ppcc").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("vat").Value = ds2.Tables(0).Rows(i).Item("vat").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("priceincvat").Value = ds2.Tables(0).Rows(i).Item("priceincvat").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("remarks_phi").Value = ds2.Tables(0).Rows(i).Item("remarks_phi").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("org").Value = ds2.Tables(0).Rows(i).Item("org").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("des").Value = ds2.Tables(0).Rows(i).Item("des").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("req").Value = ds2.Tables(0).Rows(i).Item("req").ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("tt").Value = ds2.Tables(0).Rows(i).Item("tt").ToString
                        Catch ex As Exception

                        End Try
                        .Update()
                    End With
                    rs.Close()
                Next
            Else
                ' rptDoCument.ReportDefinition.ReportObjects("Subreport3").ObjectFormat.EnableSuppress = True
            End If
            '======================================================================================
           
            ' rptDoCument = New ReportDocument


            'Formatting paper

            ' End If
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

            Me.CrystalReportViewer1.ReportSource = rptDoCument
            '-
            Dim showtong As Object
            showtong = rptDoCument.ReportDefinition.ReportObjects("txttong")
            showtong.text = FormatNumber(tong.ToString, 2)
            Dim say As Object
            say = rptDoCument.ReportDefinition.ReportObjects("txtsay")
            say.text = ENumberToWord(tong)
            '----------------------------------------
            Dim T1() As String
            Dim T As String
            Dim showText As Object

            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtno")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("no").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtden")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("den").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            '------

            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtmbl")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("mbl").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            '------
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txthbl")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("hbl").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtvessel")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("vessel").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            ''------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtetd")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("etd").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            ''------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtdescription")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("description").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            ''------

            ''------
            Try
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtpic")
                T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("pic").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
                ''------

            Catch ex As Exception

            End Try

            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtshipper")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("shipper").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            ''------
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtconsignee")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("consignee").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtvolume")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("volume").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------

            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtpor")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("por").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------

            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtpol")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("pol").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------

            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtpodel")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("podel").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtterm")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("term").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            '------
            T = ""
            showText = rptDoCument.ReportDefinition.ReportObjects("txtdate")
            T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("ngay").ToString, Chr(13))
            For CountA As Integer = 0 To T1.Length - 1
                T &= T1(CountA).Replace(Chr(10), "  ")
                For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                    T &= " "
                Next
            Next
            showText.Text = T
            '------
            Try
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtremarks")
                T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("remarks").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
            Catch ex As Exception

            End Try

            '------
            Try
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtfrom")
                T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("from_").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
            Catch ex As Exception

            End Try

            '------
            Try
                T = ""
                showText = rptDoCument.ReportDefinition.ReportObjects("txtvalidity")
                T1 = Strings.Split(oTableBillOfLading.Rows(0).Item("validity").ToString, Chr(13))
                For CountA As Integer = 0 To T1.Length - 1
                    T &= T1(CountA).Replace(Chr(10), "  ")
                    For CountSpacea As Integer = T1(CountA).Length To showText.Width \ 10
                        T &= " "
                    Next
                Next
                showText.Text = T
            Catch ex As Exception

            End Try



            'Formatting paper
            Dim sqlR As String
            Dim dsR As New DataSet
            sqlR = "select * from intamquotation  "
            dsR = ReadDataSet(sqlR)
            'rptDoCument.SetDataSource(dsR.Tables(0))
            Me.CrystalReportViewer1.ReportSource = rptDoCument
            Me.CrystalReportViewer1.Show()

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
        PrintRpt()
    End Sub







    Private Sub cmdRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRefresh.Click
        PrintRpt()
    End Sub

End Class