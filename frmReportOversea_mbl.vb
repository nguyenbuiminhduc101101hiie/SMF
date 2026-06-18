Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Text.RegularExpressions
'---------------------
Imports System.Data.SqlClient
Imports System.Text
Imports Microsoft.VisualBasic
Imports System.Net.WebRequest
Imports System.Net.WebClient
Imports System.Net
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Public Class frmReportOversea_mbl

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public Sub printReport()
        Try
            Try
                ' xoa csdl

                Dim cmd As New ADODB.Command
                cmd.let_ActiveConnection(strconn)
                cmd.CommandText = "delete from Reportoversea  "

                cmd.Execute(, , ADODB.CommandTypeEnum.adCmdText)
                '---------------

                ' them vao csdl
                Dim i As Integer
                Dim strQuery As String
                Dim rs As New ADODB.Recordset

                For i = 0 To Me.DataGridView1.RowCount - 3

                    strQuery = "SELECT * "
                    strQuery = strQuery & "FROM Reportoversea "
                    rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    With rs

                        .AddNew()

                        .Fields("id").Value = NewId()
                        ''-------------------------
                        ''-------------------------
                        Try
                            .Fields("ref").Value = Me.DataGridView1.Item("job", i).Value.ToString
                        Catch ex As Exception

                        End Try


                        Try
                            .Fields("month").Value = Me.DataGridView1.Item("month", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("hbl").Value = Me.DataGridView1.Item("hbl", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("binvoice").Value = Me.DataGridView1.Item("billingInvoice", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("bnoinvoice").Value = Me.DataGridView1.Item("billingNoInvoice", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("boversea").Value = Me.DataGridView1.Item("billingoversea", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("cinvoice").Value = Me.DataGridView1.Item("costingInvoice", i).Value.ToString
                        Catch ex As Exception

                        End Try
                        Try
                            .Fields("cnoinvoice").Value = Me.DataGridView1.Item("costingNoInvoice", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("coversea").Value = Me.DataGridView1.Item("costingoversea", i).Value.ToString
                        Catch ex As Exception

                        End Try

                        Try
                            .Fields("profit").Value = Me.DataGridView1.Item("profit", i).Value.ToString
                        Catch ex As Exception

                        End Try


                        .Update()
                        .Close()
                    End With

                Next

                '-------------------
                Dim rptDoCument As ReportDocument
                Dim mymargins
                Dim strReportName As String

                rptDoCument = New ReportDocument

                strReportName = "ReportOversea"




                Dim strReportPath As String = Application.StartupPath & "\" & strReportName & ".rpt"
                If Not IO.File.Exists(strReportPath) Then
                    DisplayMessage(True, "Không có file Report:" & vbCrLf & strReportPath)
                    Exit Sub
                End If
                rptDoCument.Load(strReportPath)
                'Formatting paper

                ' End If
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
                '----------------------------------------------------------------------------
                CrystalReportViewer1.ReportSource = rptDoCument
                '------------------------------------------

                rptDoCument.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait

                rptDoCument.Refresh()

                Me.CrystalReportViewer1.Refresh()
                Me.CrystalReportViewer1.Show()

            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.DataGridView1.Rows.Clear()
            If Me.chknotVAT.Checked = True Then
                Me.Text = "Report Oversea MB/L - Not VAT"
            Else
                Me.Text = "Report Oversea MB/L- Inc VAT"
            End If
            If Me.chkall.Checked = True Then

                weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "ref")


                weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "ref")


                'weeklyreport_("Oversea-Sea-Export Shipments", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid")

                'weeklyreport_("Oversea-Sea-Import Shipments", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid")

                'If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
                '    gethbl("MBLMAWB", "Outbound_ACSSeaExport", "BLOB_ID")
                'End If
                'weeklyreport_("ACS-Sea-Export Shipments", "Outbound_ACSSeaExport", "BLOB_ID", "containertype", "outboundid", "outboundfreight", "outboundid")

                weeklyreport_("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "ref")

                'If Me.ComboBox2.Text = "ACS-Air-Export" Then
                weeklyreport_("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "ref")

                'End If

                'If Me.ComboBox2.Text = "Domestic-Truck" Then
                ' weeklyreport("Domestic-Truck Shipments", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
                'End If
                'If Me.ComboBox2.Text = "Logistics-Customs" Then
                weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "ref")
                '  End If
            Else
                If Me.ComboBox2.Text = "Agency-Export" Then
                    weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "ref")
                End If
                If Me.ComboBox2.Text = "Agency-Import" Then
                    weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "ref")
                End If
                If Me.ComboBox2.Text = "Oversea-Sea-Export" Then
                    weeklyreport_("Oversea-Sea-Export Shipments", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "ref")
                End If
                If Me.ComboBox2.Text = "Oversea-Sea-Import" Then
                    weeklyreport_("Oversea-Sea-Import Shipments", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "ref")
                End If

                If Me.ComboBox2.Text = "ACS-Air-Import" Then
                    weeklyreport_("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "ref")
                End If
                If Me.ComboBox2.Text = "ACS-Air-Export" Then
                    weeklyreport_("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "ref")
                End If

                'If Me.ComboBox2.Text = "Domestic-Truck" Then
                '    weeklyreport("Domestic-Truck Shipments", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
                'End If
                If Me.ComboBox2.Text = "Logistics-Customs" Then
                    weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "ref")
                End If
            End If
            Dim itong As Integer
            Dim tong1 As Double = 0
            Dim tong2 As Double = 0
            Dim tong3 As Double = 0
            Dim tong4 As Double = 0
            Dim tong5 As Double = 0
            Dim tong6 As Double = 0
            Dim tong7 As Double = 0
            'Dim tongDEM As Double = 0
            'Dim tongDET As Double = 0
            'Dim tongSTO As Double = 0
            'Dim tongPOWER As Double = 0
            'Dim total As Double = 0
            Dim currow As Integer
            Me.DataGridView1.Rows.Add(1)
            currow = DataGridView1.RowCount - 2
            For itong = 0 To Me.DataGridView1.Rows.Count - 2
                Try
                    tong1 += CDbl(Me.DataGridView1.Item("billingInvoice", itong).Value)
                    tong2 += CDbl(Me.DataGridView1.Item("billingnoInvoice", itong).Value)
                    tong3 += CDbl(Me.DataGridView1.Item("billingoversea", itong).Value)
                    tong4 += CDbl(Me.DataGridView1.Item("costingInvoice", itong).Value)
                    tong5 += CDbl(Me.DataGridView1.Item("costingnoInvoice", itong).Value)
                    tong6 += CDbl(Me.DataGridView1.Item("costingoversea", itong).Value)
                    tong7 += CDbl(Me.DataGridView1.Item("profit", itong).Value)
                Catch ex As Exception

                End Try


            Next
            Me.DataGridView1.Item("billingInvoice", currow).Value = FormatNumber(tong1.ToString, 2)
            Me.DataGridView1.Item("billingnoInvoice", currow).Value = FormatNumber(tong2.ToString, 2)
            Me.DataGridView1.Item("billingOversea", currow).Value = FormatNumber(tong3.ToString, 2)
            Me.DataGridView1.Item("costingInvoice", currow).Value = FormatNumber(tong4.ToString, 2)
            Me.DataGridView1.Item("costingnoInvoice", currow).Value = FormatNumber(tong5.ToString, 2)
            Me.DataGridView1.Item("costingOversea", currow).Value = FormatNumber(tong6.ToString, 2)
            Me.DataGridView1.Item("profit", currow).Value = FormatNumber(tong7.ToString, 2)
            Me.DataGridView1.Item("hbl", currow).Value = "Total"
            printReport()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub weeklyreport_(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal ref As String)
        Try
            Dim currow As Integer
            ' kiem tra neu co du lieu yhi moi add
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            'If Me.CHKSOC.Checked = True Then

            '    If Me.chkselect.Checked = True Then
            '        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & ref & " like '%" & Me.txthbl.Text & "%'  and nvocc=1 order by ref desc " 'and nhom like 'COC%'

            '    Else
            '        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nvocc=1  order by ref desc " 'and nhom like 'COC%'

            '    End If
            'End If

            'If Me.CHKCOC.Checked = True Then

            '    If Me.chkselect.Checked = True Then
            '        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & ref & " like '%" & Me.txthbl.Text & "%'  and nvocc=0  order by ref desc " 'and nhom like 'COC%'

            '    Else
            '        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nvocc=0  order by ref desc " 'and nhom like 'COC%'

            '    End If
            'End If

            If Me.chkallCus.Checked = True Then
                If Me.cboFLC.Text = "" And cboSC.Text = "" Then
                    If Me.chkselect.Checked = True Then
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & ref & " like '%" & Me.txthbl.Text & "%'     order by ref desc" 'and nhom like 'COC%'

                    Else
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'    order by ref desc " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & ref & " like '%" & Me.txthbl.Text & "%'   and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'   order by ref desc" 'and nhom like 'COC%'

                    Else
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'   and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'  order by ref desc " 'and nhom like 'COC%'

                    End If
                End If
            Else
                If Me.cboFLC.Text = "" And cboSC.Text = "" Then
                    If Me.chkselect.Checked = True Then
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & ref & " like '%" & Me.txthbl.Text & "%'  and customerid_showtc='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'     order by ref desc" 'and nhom like 'COC%'

                    Else
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and customerid_showtc='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'    order by ref desc " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & ref & " like '%" & Me.txthbl.Text & "%'   and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "'  and customerid_showtc='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'   order by ref desc" 'and nhom like 'COC%'

                    Else
                        sql = "select distinct ref from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'   and gflc='" & cboFLC.Text & "' and gsc='" & Me.cboSC.Text & "' and customerid_showtc='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  order by ref desc " 'and nhom like 'COC%'

                    End If
                End If
            End If



            ds = ReadDataSet(sql)
            Dim m As Integer
            Try
                'For m = 3 To 5
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                'Next
                'For m = 6 To 8
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Red
                'Next
                'For m = 9 To 9
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LightGreen
                'Next
                'For m = 10 To 11
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                'Next
                'For m = 12 To 13
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Red
                'Next

                'For m = 14 To 15
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LightGreen
                'Next


                'For m = 16 To 16
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Yellow
                'Next
                'For m = 17 To 17
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.Red
                'Next

                'For m = 18 To 19
                '    Me.DataGridView1.Columns(m).DefaultCellStyle.BackColor = Color.LightCyan
                'Next

            Catch ex As Exception

            End Try


            Dim itang As Integer = 1
            If ds.Tables(0).Rows.Count > 0 Then ' ung voi tung ref ta se lay toan bo house
                ' ung voi moi lo ta tim sont
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lap bill

                    'Me.DataGridView1.Rows.Add(1)
                    'currow = DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    ' lay toan bo house


                    '--------------------------------------
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    Me.DataGridView1.Item("no", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                    Me.DataGridView1.Item("job", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    ' Me.DataGridView1.Item("sales", currow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString
                    'Me.DataGridView1.Item("remarks", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                    'Try
                    '    Me.DataGridView1.Item("mbl", currow).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    'Catch ex As Exception
                    '    Me.DataGridView1.Item("mbl", currow).Value = ds.Tables(0).Rows(i).Item("mblcarrier").ToString
                    'End Try

                    'Try
                    '    Me.DataGridView1.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    'Catch ex As Exception
                    '    Me.DataGridView1.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    'End Try


                    'Try
                    '    Me.DataGridView1.Item("month", currow).Value = CDate(ds.Tables(0).Rows(i).Item("datereport").ToString).Month.ToString + CDate(ds.Tables(0).Rows(i).Item("datereport").ToString).Year.ToString
                    'Catch ex As Exception

                    'End Try




                    'Try
                    '    Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                    'Catch ex As Exception
                    '    Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("AirportDeparture").ToString
                    'End Try

                    'Try
                    '    Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString
                    'Catch ex As Exception
                    '    Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("AirPortDes").ToString
                    'End Try
                    ' volume
                    ' kiem tra cont
                    'Dim sqlcont As String
                    'Dim dscont As New DataSet
                    ''-------------
                    'Dim cont As String = ""
                    'Dim kien As Integer = 0
                    'Dim kgs As Double = 0
                    'Dim khoi As Double = 0
                    ''----
                    'Dim cont20 As Integer = 0
                    'Dim cont40 As Integer = 0
                    'Dim cont40hc As Integer = 0
                    'Dim cont20rf As Integer = 0
                    'Dim cont40rf As Integer = 0
                    'Dim ic As Integer
                    ''-------------------

                    'sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' "
                    'dscont = ReadDataSet(sqlcont)
                    'If dscont.Tables(0).Rows.Count > 0 Then
                    '    For ic = 0 To dscont.Tables(0).Rows.Count - 1
                    '        Try
                    '            kien += CDbl(dscont.Tables(0).Rows(ic).Item("sokien").ToString)
                    '        Catch ex As Exception

                    '        End Try

                    '        Try
                    '            kgs += CDbl(dscont.Tables(0).Rows(ic).Item("sokg").ToString)
                    '        Catch ex As Exception

                    '        End Try

                    '        Try
                    '            khoi += CDbl(dscont.Tables(0).Rows(ic).Item("sokhoi").ToString)
                    '        Catch ex As Exception

                    '        End Try
                    '        If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*20*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                    '            cont20 += 1
                    '        End If

                    '        If (dscont.Tables(0).Rows(ic).Item("containertype").ToString Like "*40*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                    '            cont40 += 1
                    '        End If

                    '        If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40HC*") Then
                    '            cont40hc += 1
                    '        End If

                    '        If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*20RF*") Then
                    '            cont20rf += 1
                    '        End If

                    '        If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40RF*") Then
                    '            cont40rf += 1
                    '        End If
                    '    Next

                    'End If
                    'If ds.Tables(0).Rows(i).Item("FCL").ToString = True Then
                    '    '
                    '    If cont20 > 0 Then
                    '        Me.DataGridView1.Item("volume", currow).Value = cont20.ToString + " x 20GP"

                    '    End If
                    '    If cont40 > 0 Then
                    '        Me.DataGridView1.Item("volume", currow).Value += cont40.ToString + " x 40GP; "
                    '    End If
                    '    If cont40hc > 0 Then
                    '        Me.DataGridView1.Item("volume", currow).Value += cont40hc.ToString + " x 40HC; "
                    '    End If

                    '    If cont20rf > 0 Then
                    '        Me.DataGridView1.Item("volume", currow).Value += cont20rf.ToString + " x 20RF; "
                    '    End If

                    '    If cont40rf > 0 Then
                    '        Me.DataGridView1.Item("volume", currow).Value += cont40rf.ToString + " x 40RF"
                    '    End If



                    'ElseIf ds.Tables(0).Rows(i).Item("LCL").ToString = True Then

                    '    Me.DataGridView1.Item("volume", currow).Value = khoi.ToString + " CBM"
                    'End If

                    ''---------------------
                    '' client
                    'Dim sqlcus As String
                    'Dim dscus As New DataSet
                    'Try
                    '    If ds.Tables(0).Rows(i).Item("customerid_showtc").ToString <> "" Then
                    '        sqlcus = "select * from customer where customer_id='" & ds.Tables(0).Rows(i).Item("customerid_showtc").ToString & "' "
                    '        dscus = ReadDataSet(sqlcus)
                    '        If dscus.Tables(0).Rows.Count > 0 Then
                    '            Me.DataGridView1.Item("client", currow).Value = dscus.Tables(0).Rows(0).Item("company").ToString
                    '        End If
                    '    End If

                    'Catch ex As Exception

                    'End Try

                    ''---------------

                    '' client
                    'Dim sqlagent As String
                    'Dim dsagent As New DataSet
                    'Try
                    '    If ds.Tables(0).Rows(i).Item("agentid").ToString <> "" Then
                    '        sqlagent = "select * from customer where customer_id='" & ds.Tables(0).Rows(i).Item("agentid").ToString & "' "
                    '        dsagent = ReadDataSet(sqlagent)
                    '        If dsagent.Tables(0).Rows.Count > 0 Then
                    '            Me.DataGridView1.Item("agent", currow).Value = dsagent.Tables(0).Rows(0).Item("company").ToString
                    '        End If
                    '    End If

                    'Catch ex As Exception

                    'End Try

                    '---------------
                    Dim debitInv As Double = 0
                    Dim debitNoInv As Double = 0
                    Dim debitOversea As Double = 0
                    Dim creditInv As Double = 0
                    Dim creditNoInv As Double = 0
                    Dim creditOversea As Double = 0
                    ''''
                    Dim sqlh As String
                    Dim dsh As New DataSet
                    sqlh = "select * from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' "
                    dsh = ReadDataSet(sqlh)



                    Dim ik As Integer
                    If Me.chknotVAT.Checked = True Then
                        If Me.chkVND.Checked = True Then
                            Dim sqlF As String
                            Dim dsF As New DataSet
                            If Me.chkallpnp.Checked = True Then
                                '  sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'   " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'   and os=0  "
                            Else
                                ' sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' and paycheck='" & Me.chkpay.Checked & "'    and os=0   "
                            End If
                            dsF = ReadDataSet(sqlF)
                            If dsF.Tables(0).Rows.Count > 0 Then


                                For ik = 0 To dsF.Tables(0).Rows.Count - 1
                                    If dsF.Tables(0).Rows(ik).Item("daily").ToString = "False" Then


                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditInv += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditNoInv += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    Else ' dai ly = True
                                        ' dai ly
                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then

                                            If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString)
                                                Catch ex As Exception

                                                End Try

                                            Else
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                Catch ex As Exception

                                                End Try
                                            End If




                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditOversea += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditOversea += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    End If

                                Next



                            End If






                        Else
                            Dim sqlF As String
                            Dim dsF As New DataSet
                            If Me.chkallpnp.Checked = True Then
                                '  sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'   " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'    and os=0  "
                            Else
                                ' sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' and paycheck='" & Me.chkpay.Checked & "'    and os=0  "
                            End If
                            'If Me.chkallpnp.Checked = True Then
                            '    sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  " 'and daily=0

                            'Else
                            '    sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0

                            'End If
                            dsF = ReadDataSet(sqlF)
                            If dsF.Tables(0).Rows.Count > 0 Then


                                For ik = 0 To dsF.Tables(0).Rows.Count - 1
                                    If dsF.Tables(0).Rows(ik).Item("daily").ToString = "False" Then


                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditInv += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditNoInv += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    Else ' dai ly = True
                                        ' dai ly
                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then

                                            If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString)
                                                Catch ex As Exception

                                                End Try

                                            Else
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price_").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                Catch ex As Exception

                                                End Try
                                            End If




                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditOversea += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditOversea += (CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / ((CDbl(dsF.Tables(0).Rows(ik).Item("taxprice").ToString) / 100) + 1)) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    End If

                                Next



                            End If




                        End If
                    Else
                        If Me.chkVND.Checked = True Then
                            Dim sqlF As String
                            Dim dsF As New DataSet
                            If Me.chkallpnp.Checked = True Then
                                '  sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'   " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'   and os=0  "
                            Else
                                ' sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' and paycheck='" & Me.chkpay.Checked & "'    and os=0  "
                            End If
                            'If Me.chkallpnp.Checked = True Then
                            '    sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'   " 'and daily=0

                            'Else
                            '    sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0

                            'End If
                            dsF = ReadDataSet(sqlF)
                            If dsF.Tables(0).Rows.Count > 0 Then


                                For ik = 0 To dsF.Tables(0).Rows.Count - 1
                                    If dsF.Tables(0).Rows(ik).Item("daily").ToString = "False" Then


                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        creditInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    Else ' dai ly = True
                                        ' dai ly
                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then

                                            If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                Catch ex As Exception

                                                End Try

                                            Else
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                Catch ex As Exception

                                                End Try
                                            End If




                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try


                                                Else
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*VND*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) * CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    End If

                                Next



                            End If






                        Else
                            Dim sqlF As String
                            Dim dsF As New DataSet
                            If Me.chkallpnp.Checked = True Then
                                '  sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'   " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "'    and os=0  "
                            Else
                                ' sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0
                                sqlF = "select " & tableFreight & ".currency as currency," & tableFreight & ".tigia as tigia ,* from " & TableDept & " left join " & tableFreight & " on " & tableFreight & "." & tableFreightID & "= " & TableDept & "." & TableDeptID & " where ref='" & ds.Tables(0).Rows(i).Item("ref").ToString & "' and paycheck='" & Me.chkpay.Checked & "'    and os=0   "
                            End If
                            'If Me.chkallpnp.Checked = True Then
                            '    sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  " 'and daily=0

                            'Else
                            '    sqlF = "select * from " & tableFreight & " where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and paycheck='" & Me.chkpay.Checked & "'  " 'and daily=0

                            'End If
                            dsF = ReadDataSet(sqlF)
                            If dsF.Tables(0).Rows.Count > 0 Then


                                For ik = 0 To dsF.Tables(0).Rows.Count - 1
                                    If dsF.Tables(0).Rows(ik).Item("daily").ToString = "False" Then


                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        debitInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        debitNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                Else
                                                    Try
                                                        creditInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        creditNoInv += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    Else ' dai ly = True
                                        ' dai ly
                                        If dsF.Tables(0).Rows(ik).Item("DebitCredit").ToString = "Debit" Then

                                            If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                Catch ex As Exception

                                                End Try

                                            Else
                                                Try
                                                    debitOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                Catch ex As Exception

                                                End Try
                                            End If




                                        Else ' credit
                                            If dsF.Tables(0).Rows(ik).Item("showvnd").ToString = "True" Then 'co hd
                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If


                                            Else

                                                If dsF.Tables(0).Rows(ik).Item("currency").ToString Like "*USD*" Then
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString)
                                                    Catch ex As Exception

                                                    End Try

                                                Else
                                                    Try
                                                        creditOversea += CDbl(dsF.Tables(0).Rows(ik).Item("price").ToString) / CDbl(dsF.Tables(0).Rows(ik).Item("tigia").ToString)

                                                    Catch ex As Exception

                                                    End Try
                                                End If
                                            End If

                                        End If
                                    End If

                                Next



                            End If




                        End If
                    End If









                    ' profit DEM
                    Try
                        Me.DataGridView1.Item("billingInvoice", currow).Value = FormatNumber(debitInv.ToString, 2)  'CDbl(Me.DataGridView1.Item("demfeeCOLLECT", currow).Value) - CDbl(Me.DataGridView1.Item("demfeePAYMENT", currow).Value)

                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("billingnoInvoice", currow).Value = FormatNumber(debitNoInv.ToString, 2)
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("billingOversea", currow).Value = FormatNumber(debitOversea.ToString, 2)
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("costingInvoice", currow).Value = FormatNumber(creditInv.ToString, 2)  'CDbl(Me.DataGridView1.Item("demfeeCOLLECT", currow).Value) - CDbl(Me.DataGridView1.Item("demfeePAYMENT", currow).Value),2)

                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("costingnoInvoice", currow).Value = FormatNumber(creditNoInv.ToString, 2)
                    Catch ex As Exception

                    End Try

                    Try
                        Me.DataGridView1.Item("costingOversea", currow).Value = FormatNumber(creditOversea.ToString, 2)
                    Catch ex As Exception

                    End Try
                    Try
                        Me.DataGridView1.Item("Profit", currow).Value = FormatNumber((debitInv + debitNoInv + debitOversea) - (creditInv + creditNoInv + creditOversea), 2) 'CDbl(Me.DataGridView1.Item("POWERfeeCOLLECT", currow).Value) - CDbl(Me.DataGridView1.Item("POWERfeePAYMENT", currow).Value)

                    Catch ex As Exception

                    End Try


                    '----------------

                    ' profit DEM

                    ' TOTAL
                    Try
                        ' Me.DataGridView1.Item("TOTAL", currow).Value = CDbl(Me.DataGridView1.Item("demfeeProfit", currow).Value) + CDbl(Me.DataGridView1.Item("deTfeeProfit", currow).Value) + CDbl(Me.DataGridView1.Item("STOfeeProfit", currow).Value) + CDbl(Me.DataGridView1.Item("POWERfeeProfit", currow).Value)

                    Catch ex As Exception

                    End Try
                    '------------------------------------------


                    'itang += 1
                Next



            End If
            ' dua cac phi vao



            '=================================================================================================================
            '=================================================================================================================
            '------------------------

        Catch ex As Exception
            DisplayMessage(True, Err.Description)
        End Try

    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            ExportExecel(Me.DataGridView1, Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmWeeklyReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim id, value, strSQL, strQuery As String
            id = "tablename"
            value = "viewername"
            Me.ComboBox2.Items.Clear()


            strSQL = "Select tablename,viewername From listdept order by viewername "
            loadDataToObject(Me.ComboBox2, strSQL, id, value)

            ' cus
            id = "customer_id"
            value = "company"
            Me.cbocus.Items.Clear()


            strSQL = "Select customer_id,taxcode + '-' + company as company From customer order by company "
            loadDataToObject(Me.cbocus, strSQL, id, value)
            ' Me.Label4.Text = "WEEKLY REPORT (Các phí thu hộ và chi hộ tính riêng.)"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGridView1.MouseUp
        Try
            Dim tong As Double = 0
            If Me.DataGridView1.Rows.Count = 0 Then
                Return
            End If
            Dim FirstValue As Boolean = True
            Dim cell As DataGridViewCell
            For Each cell In Me.DataGridView1.SelectedCells

                Try
                    tong += CDbl(cell.Value.ToString())
                Catch ex As Exception

                End Try


                ' TextBox1.Text += cell.Value.ToString()

            Next
            Try
                Me.txtsumSelect.Text = FormatNumber(tong.ToString, 3)
            Catch ex As Exception

            End Try

            'Dim selectedRowCount As Integer = _
            '     Me.dgddebitGrid1.Rows.GetRowCount(DataGridViewElementStates.Selected)
            'If selectedRowCount = 0 Then
            '    DisplayMessage(True, "Xin ch?n 1 dòng d? li?u ?? thao tác.")
            '    Return
            'End If
            'If selectedRowCount > 0 Then
            '    Dim sb As New System.Text.StringBuilder()
            '    Dim i As Integer
            '    For i = 0 To selectedRowCount - 1

            '        tong += CDbl(Me.dgddebitGrid1.Item("pricetruocthue_debit_lc", Me.dgdCreditGrid.SelectedRows(i).Index).ToString)
            '    Next i
            'End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub JobDetailsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JobDetailsToolStripMenuItem.Click
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim id, value, strSQL As String
            id = "customer_id"
            value = "company"
            strSQL = "Select customer_id,taxcode + '-' + company as company From customer where continued=1 and company like '%" & Me.TextBox1.Text & "%' or taxcode like '%" & Me.TextBox1.Text & "%' order by company "
            '  loadDataToObject(Me.cbocus, strSQL, id, value)
            loadDataToObject(Me.cbocus, strSQL, id, value)
            'loadDataToObject(Me.cbocuscredit, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub
End Class