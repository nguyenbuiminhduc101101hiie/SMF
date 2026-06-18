Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class reportProfitLoss

    Public rptDocument As New ReportDocument

    Private Sub reportProfitLoss_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strReportName As String
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            strReportName = "ReportProfitLoss"
            Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
            If Not IO.File.Exists(strReportPath) Then
                DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                Exit Sub
            End If
            rptDocument.Load(strReportPath)





            ' show thong tin co ban
            Dim ref, hbl, shipper, origin, show As Object
            Dim sql As String
            Dim ds As New DataSet
            sql = "select * from inbound where blib_id='" & gHouseProfitLossInbound & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then

                show = rptDocument.ReportDefinition.ReportObjects("txtloai")
                show.Text = "OCEAN INBOUND"


                show = rptDocument.ReportDefinition.ReportObjects("txtref")
                show.Text = ds.Tables(0).Rows(0).Item("ref").ToString
                show = rptDocument.ReportDefinition.ReportObjects("txtmbl")
                show.Text = ds.Tables(0).Rows(0).Item("mbl").ToString

                show = rptDocument.ReportDefinition.ReportObjects("txtshipper")
                show.Text = ds.Tables(0).Rows(0).Item("shipper").ToString
                show = rptDocument.ReportDefinition.ReportObjects("txtshipper")
                show.Text = ds.Tables(0).Rows(0).Item("shipper").ToString
                show = rptDocument.ReportDefinition.ReportObjects("txtorigin")
                show.Text = ds.Tables(0).Rows(0).Item("POL").ToString
                show = rptDocument.ReportDefinition.ReportObjects("txtvesselvoy")
                show.Text = ds.Tables(0).Rows(0).Item("vessel").ToString + "  " + ds.Tables(0).Rows(0).Item("voyage").ToString
                show = rptDocument.ReportDefinition.ReportObjects("txtincoterms")
                show.Text = ds.Tables(0).Rows(0).Item("CY_CFS_ITEM").ToString
                show = rptDocument.ReportDefinition.ReportObjects("txtcontainer")
                show.Text = ds.Tables(0).Rows(0).Item("saycontainer").ToString

                show = rptDocument.ReportDefinition.ReportObjects("txtprofitdate")
                show.Text = ds.Tables(0).Rows(0).Item("datereport").ToString

                show = rptDocument.ReportDefinition.ReportObjects("txtOBARdate")
                show.Text = ds.Tables(0).Rows(0).Item("sailingdate").ToString + "/" + ds.Tables(0).Rows(0).Item("eta").ToString

                show = rptDocument.ReportDefinition.ReportObjects("txthbl")
                show.Text = ds.Tables(0).Rows(0).Item("hbl").ToString

                show = rptDocument.ReportDefinition.ReportObjects("txtconsignee")
                show.Text = ds.Tables(0).Rows(0).Item("consignee").ToString

                show = rptDocument.ReportDefinition.ReportObjects("txtdestination")
                show.Text = ds.Tables(0).Rows(0).Item("dest").ToString
                '-

                show = rptDocument.ReportDefinition.ReportObjects("txtprint")
                show.Text = strUserName

                show = rptDocument.ReportDefinition.ReportObjects("txtbranch")
                show.Text = gBranch
                show = rptDocument.ReportDefinition.ReportObjects("txtsales")
                show.Text = ds.Tables(0).Rows(0).Item("salecode").ToString

                Dim sqlc As String
                Dim dsc As New DataSet
                Dim kien, kg, khoi As Double
                Dim ic As Integer
                sqlc = "select * from containerrepair where inboundid='" & gHouseProfitLossInbound & "' "
                dsc = ReadDataSet(sqlc)
                If dsc.Tables(0).Rows.Count > 0 Then
                    For ic = 0 To dsc.Tables(0).Rows.Count - 1
                        Try
                            kien += dsc.Tables(0).Rows(ic).Item("sokien").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            kg += dsc.Tables(0).Rows(ic).Item("sokg").ToString
                        Catch ex As Exception

                        End Try
                        Try
                            khoi += dsc.Tables(0).Rows(ic).Item("sokhoi").ToString
                        Catch ex As Exception

                        End Try
                    Next
                End If
                show = rptDocument.ReportDefinition.ReportObjects("txtkgs")
                Try
                    show.Text = kien.ToString + " "
                Catch ex As Exception

                End Try
                Try
                    show.Text += dsc.Tables(0).Rows(0).Item("type").ToString
                Catch ex As Exception

                End Try

                Try
                    show.Text += "/" + kg.ToString + " Kgs"
                Catch ex As Exception

                End Try
                show = rptDocument.ReportDefinition.ReportObjects("txtmeas")
                show.Text = khoi.ToString + " CBM"





                '---------------------------------------------

            End If
            Dim tongthuVND As Double = 0
            Dim tongchiVNd As Double = 0
            Dim tongdebit As Double = 0
            Dim tongcredit As Double = 0
            '----------------------------

            Dim dtdebit As New DataTable
            Dim dtcredit As New DataTable
            Dim dtDebitcredit As New DataTable

            Dim dsdebit As New DataSet
            Dim dscredit As New DataSet
            Dim dsDebitcredit As New DataSet

            ' show debit---------------------------
            Dim sqldebit, strQuery As String

            sqldebit = "select Company as Name,charge_code as Code,nodebit as invoiceno,'Inbound' as kind,currency as cur,inboundfreight.tigia as exrate,pricetruocthue as amountcur,pricenotaxvnd as amount,pricethue as vat,price as total from inboundfreight left join inbound on  inboundfreight.inboundid=inbound.blib_id left join charge on charge.charge_id=inboundfreight.itemID left join customer on customer.customer_id=inboundfreight.customerid where inboundfreight.inboundid= '" & gHouseProfitLossInbound & "' and debitcredit='Debit' and daily='0'"

            dtdebit = ReadTable(sqldebit)
            ' them vao table
            ' xoatable
            '---------------------------
            Dim CmdSelect As New SqlClient.SqlCommand(sqldebit, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from tamdebit  "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            ' sau khi xoa ta them vao
            Dim rs As New ADODB.Recordset
            Dim i As Integer
            Adapter.Fill(dsdebit, "tamdebit")
            If dsdebit.Tables(0).Rows.Count > 0 Then

                For i = 0 To dsdebit.Tables(0).Rows.Count - 1

                    Try
                        tongthuVND += CDbl(dsdebit.Tables(0).Rows(i).Item("amount").ToString)
                    Catch ex As Exception

                    End Try
                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM tamdebit "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("HouseID").Value = "{" + gHouseProfitLossInbound + "}"
                        '-------------------------
                        .Fields("name").Value = dsdebit.Tables(0).Rows(i).Item("name").ToString
                        .Fields("invoiceno").Value = dsdebit.Tables(0).Rows(i).Item("invoiceno").ToString
                        .Fields("cur").Value = dsdebit.Tables(0).Rows(i).Item("cur").ToString
                        .Fields("code").Value = dsdebit.Tables(0).Rows(i).Item("code").ToString
                        .Fields("kind").Value = dsdebit.Tables(0).Rows(i).Item("kind").ToString
                        .Fields("exrate").Value = dsdebit.Tables(0).Rows(i).Item("exrate").ToString
                        .Fields("amountcur").Value = dsdebit.Tables(0).Rows(i).Item("amountcur").ToString
                        .Fields("amount").Value = dsdebit.Tables(0).Rows(i).Item("amount").ToString
                        .Fields("vat").Value = dsdebit.Tables(0).Rows(i).Item("vat").ToString
                        .Fields("total").Value = dsdebit.Tables(0).Rows(i).Item("total").ToString

                        .Update()
                    End With
                    rs.Close()
                Next
            End If
            '  ds.Tables.Add(dtdebit)

            '---show credit----------------------------
            ' show debit---------------------------
            Dim sqlcredit As String

            sqlcredit = "select Company as Name,charge_code as Code,nodebit as invoiceno,'Inbound' as kind,currency as cur,inboundfreight.tigia as exrate,pricetruocthue as amountcur,pricenotaxvnd as amount,pricethue as vat,price as total from inboundfreight left join inbound on  inboundfreight.inboundid=inbound.blib_id left join charge on charge.charge_id=inboundfreight.itemID left join customer on customer.customer_id=inboundfreight.customerid where inboundfreight.inboundid= '" & gHouseProfitLossInbound & "' and debitcredit='credit' and daily='0'"

            dtcredit = ReadTable(sqlcredit)
            '---------------------------
            Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from tamcredit "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Dim CmdSelect1 As New SqlClient.SqlCommand(sqlcredit, Con)
            Dim Adapter1 As New SqlClient.SqlDataAdapter(CmdSelect1)
            Adapter1.Fill(dscredit, "tamcredit")
            ' sau khi xoa ta them vao
            Dim rs1 As New ADODB.Recordset
            Dim i1 As Integer
            If dscredit.Tables(0).Rows.Count > 0 Then
                For i = 0 To dscredit.Tables(0).Rows.Count - 1
                    Try
                        tongchiVNd += CDbl(dscredit.Tables(0).Rows(i).Item("amount").ToString)
                    Catch ex As Exception

                    End Try


                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM tamcredit "
                    rs1.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()

                        .Fields("HouseID").Value = "{" + gHouseProfitLossInbound + "}"
                        '-------------------------
                        .Fields("name").Value = dscredit.Tables(0).Rows(i).Item("name").ToString
                        .Fields("invoiceno").Value = dscredit.Tables(0).Rows(i).Item("invoiceno").ToString
                        .Fields("cur").Value = dscredit.Tables(0).Rows(i).Item("cur").ToString
                        .Fields("code").Value = dscredit.Tables(0).Rows(i).Item("code").ToString
                        .Fields("kind").Value = dscredit.Tables(0).Rows(i).Item("kind").ToString
                        .Fields("exrate").Value = dscredit.Tables(0).Rows(i).Item("exrate").ToString
                        .Fields("amountcur").Value = dscredit.Tables(0).Rows(i).Item("amountcur").ToString
                        .Fields("amount").Value = dscredit.Tables(0).Rows(i).Item("amount").ToString
                        .Fields("vat").Value = dscredit.Tables(0).Rows(i).Item("vat").ToString
                        .Fields("total").Value = dscredit.Tables(0).Rows(i).Item("total").ToString

                        .Update()
                    End With
                    rs1.Close()
                Next
            End If

            '---------------debitCredit Dai ly
            Dim sqlDebitcredit As String

            sqlDebitcredit = "select Company as Name,nodebit as invoiceno,currency as cur,pricetruocthue as amountcur,inboundfreight.tigia as exrate,pricenotaxvnd,price,debitcredit  from inboundfreight left join inbound on  inboundfreight.inboundid=inbound.blib_id left join charge on charge.charge_id=inboundfreight.itemID left join customer on customer.customer_id=inboundfreight.customerid where inboundfreight.inboundid= '" & gHouseProfitLossInbound & "' and daily='1' " 'os=1 tra cho dai ly

            dtDebitcredit = ReadTable(sqlDebitcredit)
            '---------------------------
            Dim cmd2 As New ADODB.Command
            cmd2.let_ActiveConnection(strconn)
            cmd2.CommandText = "delete from tamdaily  "

            cmd2.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            Dim CmdSelect2 As New SqlClient.SqlCommand(sqlDebitcredit, Con)
            Dim Adapter2 As New SqlClient.SqlDataAdapter(CmdSelect2)
            Adapter2.Fill(dsDebitcredit, "tamDebitcredit")
            ' sau khi xoa ta them vao
            Dim rs2 As New ADODB.Recordset
            Dim i2 As Integer
            If dsDebitcredit.Tables(0).Rows.Count > 0 Then
                For i = 0 To dsDebitcredit.Tables(0).Rows.Count - 1


                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM tamdaily "
                    rs1.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs1

                        .AddNew()

                        .Fields("tamdailyID").Value = "{" + gHouseProfitLossInbound + "}"
                        '-------------------------
                        .Fields("name").Value = dsDebitcredit.Tables(0).Rows(i).Item("name").ToString
                        .Fields("invoiceno").Value = dsDebitcredit.Tables(0).Rows(i).Item("invoiceno").ToString
                        .Fields("cur").Value = dsDebitcredit.Tables(0).Rows(i).Item("cur").ToString

                        .Fields("exrate").Value = dsDebitcredit.Tables(0).Rows(i).Item("exrate").ToString
                        .Fields("amountcur").Value = dsDebitcredit.Tables(0).Rows(i).Item("amountcur").ToString
                        If dsDebitcredit.Tables(0).Rows(i).Item("Debitcredit").ToString = "Debit" Then
                            .Fields("credit").Value = 0
                            .Fields("debit").Value = dsDebitcredit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString
                            Try
                                tongdebit += CDbl(dsDebitcredit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString)
                            Catch ex As Exception

                            End Try

                        Else
                            .Fields("credit").Value = dsDebitcredit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString
                            .Fields("debit").Value = 0
                            Try
                                tongcredit += CDbl(dsDebitcredit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString)
                            Catch ex As Exception

                            End Try
                        End If

                        .Fields("total").Value = dsDebitcredit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString

                        .Update()
                    End With
                    rs1.Close()
                Next
            End If

            '------------------------------------
            Dim txtprofitVND As Object
            txtprofitVND = rptDocument.ReportDefinition.ReportObjects("txtprofitVND")
            txtprofitVND.Text = "VND " + FormatNumber((tongthuVND + tongdebit) - (tongchiVNd + tongcredit), 0)

            show = rptDocument.ReportDefinition.ReportObjects("txtselling")
            show.Text = FormatNumber(tongthuVND + tongdebit, 0) + " VND"

            '------------------------------------------ 
            show = rptDocument.ReportDefinition.ReportObjects("txtbuying")
            show.Text = FormatNumber(tongchiVNd + tongcredit, 0) + " VND"

            rptDocument.SetDatabaseLogon(strUserId, strPassword, strServer, strDatabase)
            Dim tbCurrent As CrystalDecisions.CrystalReports.Engine.Table
            Dim tliCurrent As CrystalDecisions.Shared.TableLogOnInfo
            For Each tbCurrent In rptDocument.Database.Tables
                tliCurrent = tbCurrent.LogOnInfo
                With tliCurrent.ConnectionInfo
                    .ServerName = strServer
                    .UserID = strUserId
                    .Password = strPassword
                    .DatabaseName = strDatabase
                End With
                tbCurrent.ApplyLogOnInfo(tliCurrent)
            Next tbCurrent

            ds.Tables.Add(dtdebit)
            ds.Tables.Add(dtcredit)
            rptDocument.SetDataSource(ds)
            ' End If
            Dim mymargins = rptDocument.PrintOptions.PageMargins
            mymargins.topMargin = gTopM
            mymargins.bottomMargin = gBottomM
            mymargins.leftMargin = gLeftM
            mymargins.rightMargin = gRightM

            rptDocument.PrintOptions.ApplyPageMargins(mymargins)
            CrystalReportViewer1.ReportSource = rptDocument
            rptDocument.Refresh()

            'If frmInBoundRemarks.CountBill > 1 Then
            '    rptDoCument.PrintToPrinter(1, True, 1, 2)
            '    Me.Close()
            'End If

            'Me.CrystalReportViewer1.Refresh()
            'Me.CrystalReportViewer1.Show()
            'ds.Tables.Add(dt1);
            'ds.Tables.Add(dt);
            'rpt.SetDataSource(ds);
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            reportProfitLoss_Load(sender, e)
        Catch ex As Exception

        End Try

    End Sub
End Class