Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports System
Public Class frmReportShipmentProfit
    Public rptDocument As New ReportDocument

    Private Sub reportProfitLoss_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim strReportName As String
            Dim Con As New SqlClient.SqlConnection(strconnDG)
            strReportName = "ReportShipmentProfit"
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
            sql = "select * from quotation_sale where quotationid='" & gShipmentProfitID & "' "
            ds = ReadDataSet(sql)
            If ds.Tables(0).Rows.Count > 0 Then

                Dim ten As Object
                ten = rptDocument.ReportDefinition.ReportObjects("txtbookingno")
                ten.Text = ds.Tables(0).Rows(0).Item("bookingno").ToString

                ten = rptDocument.ReportDefinition.ReportObjects("txtsalename")
                ten.Text = ds.Tables(0).Rows(0).Item("salename").ToString
                ten = rptDocument.ReportDefinition.ReportObjects("txtpol")
                ten.Text = ds.Tables(0).Rows(0).Item("pol").ToString
                ten = rptDocument.ReportDefinition.ReportObjects("txtpod")
                ten.Text = ds.Tables(0).Rows(0).Item("pod").ToString


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
            If gShipmentProfit_IOL = "O" Then
                sqldebit = "select * from outboundfreight_sale left join charge on outboundfreight_sale.itemid=charge.charge_id where quotationid='" & gShipmentProfitID & "'"

            ElseIf gShipmentProfit_IOL = "I" Then
                sqldebit = "select * from inboundfreight_sale left join charge on inboundfreight_sale.itemid=charge.charge_id where quotationid='" & gShipmentProfitID & "'"

            ElseIf gShipmentProfit_IOL = "L" Then
                sqldebit = "select * from logisticsfreight_sale left join charge on logisticsfreight_sale.itemid=charge.charge_id where quotationid='" & gShipmentProfitID & "'"

            End If

            dtdebit = ReadTable(sqldebit)
            ' them vao table
            ' xoatable
            '---------------------------
            Dim CmdSelect As New SqlClient.SqlCommand(sqldebit, Con)
            Dim Adapter As New SqlClient.SqlDataAdapter(CmdSelect)
            Dim cmd As New ADODB.Command
            cmd.let_ActiveConnection(strconn)
            cmd.CommandText = "delete from shipmentProfitDebit  "

            cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)


            Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from shipmentProfitCredit  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)


            ' sau khi xoa ta them vao
            Dim rs As New ADODB.Recordset
            Dim i As Integer
            Adapter.Fill(dsdebit, "tamdebit")
            If dsdebit.Tables(0).Rows.Count > 0 Then

                For i = 0 To dsdebit.Tables(0).Rows.Count - 1
                    If dsdebit.Tables(0).Rows(i).Item("DebitCredit").ToString = "Debit" Then
                        Try
                            tongthuVND += CDbl(dsdebit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString)
                        Catch ex As Exception

                        End Try
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM shipmentProfitDebit "
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs

                            .AddNew()


                            '-------------------------
                            .Fields("tenphi").Value = dsdebit.Tables(0).Rows(i).Item("charge_code").ToString
                            .Fields("soluong").Value = dsdebit.Tables(0).Rows(i).Item("quantity").ToString
                            .Fields("dongia").Value = CDbl(dsdebit.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(dsdebit.Tables(0).Rows(i).Item("tigia").ToString)
                            .Fields("dongiausd").Value = CDbl(dsdebit.Tables(0).Rows(i).Item("unitprice").ToString)
                            .Fields("thanhtien").Value = dsdebit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString
                            .Fields("thue").Value = dsdebit.Tables(0).Rows(i).Item("pricethue").ToString



                     
                            .Fields("total").Value = dsdebit.Tables(0).Rows(i).Item("price").ToString

                            .Update()
                        End With
                        rs.Close()
                    Else
                        Try
                            tongchiVNd += CDbl(dsdebit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString)
                        Catch ex As Exception

                        End Try
                        strQuery = "SELECT * "
                        strQuery = strQuery & "FROM shipmentProfitcredit "
                        rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                        With rs

                            .AddNew()


                            '-------------------------
                            .Fields("tenphi").Value = dsdebit.Tables(0).Rows(i).Item("charge_code").ToString
                            .Fields("soluong").Value = dsdebit.Tables(0).Rows(i).Item("quantity").ToString
                            .Fields("dongia").Value = CDbl(dsdebit.Tables(0).Rows(i).Item("unitprice").ToString) * CDbl(dsdebit.Tables(0).Rows(i).Item("tigia").ToString)
                            .Fields("dongiausd").Value = CDbl(dsdebit.Tables(0).Rows(i).Item("unitprice").ToString)
                            .Fields("thanhtien").Value = dsdebit.Tables(0).Rows(i).Item("pricenotaxvnd").ToString
                            .Fields("thue").Value = dsdebit.Tables(0).Rows(i).Item("pricethue").ToString




                            .Fields("total").Value = dsdebit.Tables(0).Rows(i).Item("price").ToString

                            .Update()
                        End With
                        rs.Close()

                    End If
                   
                Next
            End If
            '  ds.Tables.Add(dtdebit)

            '---show credit----------------------------
          
            '------------------------------------
            Dim txtprofitVND As Object
            txtprofitVND = rptDocument.ReportDefinition.ReportObjects("txtprofit")
            txtprofitVND.Text = "Profit : " + FormatNumber(tongthuVND - tongchiVNd, 0)

            'show = rptDocument.ReportDefinition.ReportObjects("txtselling")
            'show.Text = FormatNumber(tongthuVND + tongdebit, 0) + " VND"

            ''------------------------------------------ 
            'show = rptDocument.ReportDefinition.ReportObjects("txtbuying")
            'show.Text = FormatNumber(tongchiVNd + tongcredit, 0) + " VND"

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
            '--------------connect ko can login
            Dim connection As IConnectionInfo
            For Each connection In rptDocument.DataSourceConnections

                'Select Case connection.ServerName

                '    Case strServer
                connection.SetConnection(strServer, strDatabase, strUserId, strPassword)
                '        ' connection.SetLogon(strUserId, strPassword)

                'End Select

            Next
            '------------
            'Set Database Logon to subreport

            Dim subreport As ReportDocument

            For Each subreport In rptDocument.Subreports

                For Each connection In subreport.DataSourceConnections

                    'Select Case connection.ServerName

                    '    Case strServer

                    connection.SetConnection(strServer, strDatabase, strUserId, strPassword)

                    'End Select

                Next

            Next

            'ds.Tables.Add(dtdebit)
            'ds.Tables.Add(dtcredit)
            ' rptDocument.SetDataSource(ds)
            ' End If
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