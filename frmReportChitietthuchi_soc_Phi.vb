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
Public Class frmReportChitietthuchi_soc_Phi

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Dim ts As DataGridTableStyle = New DataGridTableStyle()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try


            Try
                ''Dim i As Integer
                ''For i = Me.DataGridView1.ColumnCount To 0
                ''    Me.DataGridView1.Columns.RemoveAt(i)
                ''Next
                While Me.DataGridView1.Rows.Count > 0
                    Me.DataGridView1.Columns.RemoveAt(0)
                End While

                'Me.DataGridView1.Rows.Clear()
            Catch ex As Exception

            End Try
            Me.DataGridView1.Columns.Add("No", "No.")
            Me.DataGridView1.Columns.Add("SerialNo", "Serial No.")
            Me.DataGridView1.Columns.Add("Shipper", "Shipper")
            Me.DataGridView1.Columns.Add("Consignee", "Consignee")
            Me.DataGridView1.Columns.Add("MBL", "MBL")
            Me.DataGridView1.Columns.Add("HBL", "HBL")
            Me.DataGridView1.Columns.Add("volume", "Volume")
            Me.DataGridView1.Columns.Add("gp20", "20GP")
            Me.DataGridView1.Columns.Add("gp40", "40GP")
            Me.DataGridView1.Columns.Add("hc40", "40HC")
            Me.DataGridView1.Columns.Add("rf20", "20RF")
            Me.DataGridView1.Columns.Add("rf40", "40RF")
            Me.DataGridView1.Columns.Add("containertype", "Container Type")
            Me.DataGridView1.Columns.Add("CBM", "Meas")
            Me.DataGridView1.Columns.Add("Agent", "Agent")
            Me.DataGridView1.Columns.Add("Carrier", "Carrier")
            Me.DataGridView1.Columns.Add("POL", "POL")
            Me.DataGridView1.Columns.Add("POD", "POD")
            Me.DataGridView1.Columns.Add("Sales", "Sales")

            'Me.DataGridView1.Columns.Add("totalcredit", "Total Credit")
            'Me.DataGridView1.Columns.Add("totaldebit", "Total Debit")
            'Me.DataGridView1.Columns.Add("profit", "Profit")
            Me.DataGridView1.Columns.Add("SoContainer", "Ghi chú số Container/ chi phí ///")
            Me.DataGridView1.Columns.Add("Customer", "Cus./Vendor/Agent")

            Me.DataGridView1.Rows.Clear()
            'Exit Sub
            ' xoa tu cot thu 21

            '------------------------------
            'If Me.chkall.Checked = True Then
            '    weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "COC-EXPORT")
            '    weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "SOC-EXPORT")

            '    weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "COCHK-EXPORT")
            '    weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "SOC-IMPORT")
            '    weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "COC-IMPORT")
            '    weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "COCHK-IMPORT")
            '    weeklyreport_("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "ACS-IMPORT")
            '    weeklyreport_("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "ACS-EXPORT")
            '    weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "mblmawb", "mblcarrier", "LOG")

            'Else  
            'If UCase(Me.ComboBox2.Text) = "AGENCY-EXPORT" Then
            '    weeklyreport_("AGENCY-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "AGENCY-EXPORT")


            'End If
            'If UCase(Me.ComboBox2.Text) = "AGENCY-IMPORT" Then
            '    weeklyreport_("AGENCY-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "AGENCY-IMPORT")


            'End If


            ''weeklyreport_("Oversea-Sea-Export Shipments", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid")

            ''weeklyreport_("Oversea-Sea-Import Shipments", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid")

            ''If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
            ''    gethbl("MBLMAWB", "Outbound_ACSSeaExport", "BLOB_ID")
            ''End If
            ''weeklyreport_("ACS-Sea-Export Shipments", "Outbound_ACSSeaExport", "BLOB_ID", "containertype", "outboundid", "outboundfreight", "outboundid")

            'weeklyreport_("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl")

            ''If Me.ComboBox2.Text = "ACS-Air-Export" Then
            'weeklyreport_("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb")

            ''End If

            ''If Me.ComboBox2.Text = "Domestic-Truck" Then
            '' weeklyreport("Domestic-Truck Shipments", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
            ''End If
            ''If Me.ComboBox2.Text = "Logistics-Customs" Then
            'weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "mblmawb")
            ''  End If



            If UCase(Me.ComboBox2.Text) = "AGENCY-EXPORT" Then
                weeklyreport_("AGENCY-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "AGENCY-EXPORT")

            End If

          

            If UCase(Me.ComboBox2.Text) = "AGENCY-IMPORT" Then
                weeklyreport_("AGENCY-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "AGENCY-IMPORT")
            End If


            If UCase(Me.ComboBox2.Text) = "ACS-AIR-IMPORT" Then
                weeklyreport_("ACS-Air-Import", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "ACS-Air-Import")
            End If

            If UCase(Me.ComboBox2.Text) = "ACS-AIR-EXPORT" Then
                weeklyreport_("ACS-AIR-EXPORT", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "ACS-AIR-EXPORT")
            End If

          
            If UCase(Me.ComboBox2.Text) = "LOGISTICS-CUSTOMS" Then
                weeklyreport_("LOGISTICS-CUSTOMS", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "mblmawb", "mblcarrier", "LOGISTICS-CUSTOMS")
            End If
            'End If
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
                    tong1 += CDbl(Me.DataGridView1.Item("Column9", itong).Value)
                    tong2 += CDbl(Me.DataGridView1.Item("Column10", itong).Value)
                    tong3 += CDbl(Me.DataGridView1.Item("Column11", itong).Value)
                    tong4 += CDbl(Me.DataGridView1.Item("Column16", itong).Value)
                    tong5 += CDbl(Me.DataGridView1.Item("Column17", itong).Value)
                    tong6 += CDbl(Me.DataGridView1.Item("Column18", itong).Value)
                    'tong7 += CDbl(Me.DataGridView1.Item("profit", itong).Value)
                Catch ex As Exception

                End Try


            Next
            Me.DataGridView1.Item("Column9", currow).Value = FormatNumber(tong1.ToString, 2)
            Me.DataGridView1.Item("Column10", currow).Value = FormatNumber(tong2.ToString, 2)
            Me.DataGridView1.Item("Column11", currow).Value = FormatNumber(tong3.ToString, 2)
            Me.DataGridView1.Item("Column16", currow).Value = FormatNumber(tong4.ToString, 2)
            Me.DataGridView1.Item("Column17", currow).Value = FormatNumber(tong5.ToString, 2)
            Me.DataGridView1.Item("Column18", currow).Value = FormatNumber(tong6.ToString, 2)
            'Me.DataGridView1.Item("profit", currow).Value = FormatNumber(tong7.ToString, 2)
            'Me.DataGridView1.Item("hbl", currow).Value = "Total"
        Catch ex As Exception

        End Try
    End Sub

    Public Sub weeklyreport_(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal hbl As String, ByVal mbl As String, ByVal NHOM As String)
        Try
            Dim currow As Integer
            ' kiem tra neu co du lieu yhi moi add
            Dim sql As String
            Dim ds As New DataSet
            Dim i, j As Integer



            '-------------------
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            If Me.CHKSOC.Checked = True Then
                If Me.chkallsales.Checked = True Then

                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' AND  status like '%" & Me.ComboBox3.Text & "%' and nvocc=1 order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=1 order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "'  and nvocc=1  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "'  AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=1  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=1  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=1  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                End If

            End If

            If Me.CHKCOC.Checked = True Then
                If Me.chkallsales.Checked = True Then

                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' AND  status like '%" & Me.ComboBox3.Text & "%' and nvocc=0 order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=0 order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "'  and nvocc=0  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "'  AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=0  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=0  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' AND  status like '%" & Me.ComboBox3.Text & "%'  and nvocc=0  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                End If

            End If
            If Me.chlallsoccoc.Checked = True Then
                If Me.chkallsales.Checked = True Then

                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' AND  status like '%" & Me.ComboBox3.Text & "%'  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' AND  status like '%" & Me.ComboBox3.Text & "%'   order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "'   order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "'  AND  status like '%" & Me.ComboBox3.Text & "%'    order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' AND  status like '%" & Me.ComboBox3.Text & "%'    order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' AND  status like '%" & Me.ComboBox3.Text & "%'   order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                End If

            End If



            ds = ReadDataSet(sql)

            ' tao 1 table them cac phi vao

            Dim cmd1 As New ADODB.Command
            cmd1.let_ActiveConnection(strconn)
            cmd1.CommandText = "delete from dmtenphi  "

            cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)

            '--------------
            Dim sqlF As String
            Dim dsF As New DataSet
            Dim rs As New ADODB.Recordset
            If ds.Tables(0).Rows.Count > 0 Then
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    If Me.chkallCus.Checked = True Then
                        sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id  where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and charge_id='" & FindValueID(Me.cbocharge, Me.cbocharge.Text) & "' and os=0  " 'and daily=0

                    Else
                        sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id  where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and charge_id='" & FindValueID(Me.cbocharge, Me.cbocharge.Text) & "' and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  and os=0  " 'and daily=0

                    End If
                    dsF = ReadDataSet(sqlF)
                    If dsF.Tables(0).Rows.Count > 0 Then

                        For j = 0 To dsF.Tables(0).Rows.Count - 1

                            rs.Open("Select top 1 * from dmtenphi", strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                            With rs

                                .AddNew()
                                .Fields("itemid").Value = "{" + dsF.Tables(0).Rows(j).Item("itemid").ToString + "}"
                                .Fields("debitcredit").Value = dsF.Tables(0).Rows(j).Item("debitcredit").ToString
                                .Update()

                                ' them booking
                            End With
                            rs.Close()
                        Next
                    End If
                Next

            End If

            ' them cot
            Dim sqlcot As String
            Dim dscot As New DataSet
            sqlcot = "select distinct charge_code,debitcredit from dmtenphi left join charge on charge.charge_id=itemid order by debitcredit,charge_code "
            dscot = ReadDataSet(sqlcot)
            If dscot.Tables(0).Rows.Count > 0 Then
                For i = 0 To dscot.Tables(0).Rows.Count - 1
                    'Dim sqlten As String
                    'Dim dsten As New DataSet
                    'sqlten = "select charge_code from charge where charge_id='" & dscot.Tables(0).Rows(i).Item("itemid").ToString & "' "
                    'dsten = ReadDataSet(sqlten)
                    'If dsten.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView1.Columns.Add(dscot.Tables(0).Rows(i).Item("charge_code").ToString + "_" + dscot.Tables(0).Rows(i).Item("debitcredit").ToString, dscot.Tables(0).Rows(i).Item("charge_code").ToString + "_" + dscot.Tables(0).Rows(i).Item("debitcredit").ToString)
                    'End If

                Next
            End If

            '------------------------------------------------------
            Dim m As Integer
            Try

            Catch ex As Exception

            End Try

            Dim tigiadebit As Double = 0
            Dim itang As Integer = 1
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung voi moi lo ta tim sont
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lap bill

                    'Me.DataGridView1.Rows.Add(1)
                    'currow = DataGridView1.RowCount - 2
                    ' hien thi noi dung bill Ib
                    'Me.DataGridView1.Columns.Add("No", "No.")
                    'Me.DataGridView1.Columns.Add("SerialNo", "Serial No.")
                    'Me.DataGridView1.Columns.Add("Shipper", "Shipper")
                    'Me.DataGridView1.Columns.Add("Consignee", "Consignee")
                    'Me.DataGridView1.Columns.Add("MBL", "MBL")
                    'Me.DataGridView1.Columns.Add("HBL", "HBL")
                    'Me.DataGridView1.Columns.Add("volume", "Volume")
                    'Me.DataGridView1.Columns.Add("gp20", "20GP")
                    'Me.DataGridView1.Columns.Add("gp40", "40GP")
                    'Me.DataGridView1.Columns.Add("hc40", "40HC")
                    'Me.DataGridView1.Columns.Add("rf20", "20RF")
                    'Me.DataGridView1.Columns.Add("rf40", "40RF")
                    'Me.DataGridView1.Columns.Add("containertype", "Container Type")
                    'Me.DataGridView1.Columns.Add("CBM", "Meas")
                    'Me.DataGridView1.Columns.Add("Agent", "Agent")
                    'Me.DataGridView1.Columns.Add("Carrier", "Carrier")
                    'Me.DataGridView1.Columns.Add("POL", "POL")
                    'Me.DataGridView1.Columns.Add("POD", "POD")
                    'Me.DataGridView1.Columns.Add("Sales", "Sales")
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.Red
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.BackColor = Color.LightYellow
                    Me.DataGridView1.Item("No", currow).Value = (i + 1).ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                    Me.DataGridView1.Item("SerialNo", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    Me.DataGridView1.Item("shipper", currow).Value = ds.Tables(0).Rows(i).Item("shipper").ToString
                    Me.DataGridView1.Item("consignee", currow).Value = ds.Tables(0).Rows(i).Item("consignee").ToString
                    Me.DataGridView1.Item("carrier", currow).Value = ds.Tables(0).Rows(i).Item("shippingline").ToString
                    Me.DataGridView1.Item("Sales", currow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString
                    'Me.DataGridView1.Item("remarks", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
                    Try
                        Me.DataGridView1.Item("mbl", currow).Value = ds.Tables(0).Rows(i).Item("mbl").ToString
                    Catch ex As Exception
                        Me.DataGridView1.Item("mbl", currow).Value = ds.Tables(0).Rows(i).Item("mblcarrier").ToString
                    End Try

                    Try
                        Me.DataGridView1.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("hbl").ToString
                    Catch ex As Exception
                        Me.DataGridView1.Item("hbl", currow).Value = ds.Tables(0).Rows(i).Item("mblmawb").ToString
                    End Try
                    Try
                        Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("pol").ToString
                    Catch ex As Exception
                        Me.DataGridView1.Item("pol", currow).Value = ds.Tables(0).Rows(i).Item("AirportDeparture").ToString
                    End Try

                    Try
                        Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("pod").ToString
                    Catch ex As Exception
                        Me.DataGridView1.Item("pod", currow).Value = ds.Tables(0).Rows(i).Item("AirPortDes").ToString
                    End Try




                    ' volume
                    ' kiem tra cont
                    Dim sqlcont As String
                    Dim dscont As New DataSet
                    '-------------
                    Dim cont As String = ""
                    Dim kien As Integer = 0
                    Dim kgs As Double = 0
                    Dim khoi As Double = 0
                    '----
                    Dim cont20 As Integer = 0
                    Dim cont40 As Integer = 0
                    Dim cont40hc As Integer = 0
                    Dim cont20rf As Integer = 0
                    Dim cont40rf As Integer = 0
                    Dim ic As Integer
                    '-------------------

                    sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' "
                    dscont = ReadDataSet(sqlcont)
                    If dscont.Tables(0).Rows.Count > 0 Then
                        For ic = 0 To dscont.Tables(0).Rows.Count - 1
                            Try
                                kien += CDbl(dscont.Tables(0).Rows(ic).Item("sokien").ToString)
                            Catch ex As Exception

                            End Try

                            Try
                                kgs += CDbl(dscont.Tables(0).Rows(ic).Item("sokg").ToString)
                            Catch ex As Exception

                            End Try

                            Try
                                khoi += CDbl(dscont.Tables(0).Rows(ic).Item("sokhoi").ToString)
                            Catch ex As Exception

                            End Try
                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "20GP") Or (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "20DC") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                cont20 += 1
                            End If

                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "40GP") Or (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "40DC") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                cont40 += 1
                            End If

                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "40HC") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                cont40hc += 1
                            End If

                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "20RF") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                cont20rf += 1
                            End If
                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "40RF") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                cont40rf += 1
                            End If

                            'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40HC*") Then
                            '    cont40hc += 1
                            'End If

                            'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*20RF*") Then
                            '    cont20rf += 1
                            'End If

                            'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40RF*") Then
                            '    cont40rf += 1
                            'End If



                        Next
                        Me.DataGridView1.Item("gp20", currow).Value = IIf(cont20 > 0, cont20.ToString, "")
                        Me.DataGridView1.Item("gp40", currow).Value = IIf(cont40 > 0, cont40.ToString, "") 'cont40.ToString
                        Me.DataGridView1.Item("hc40", currow).Value = IIf(cont40hc > 0, cont40hc.ToString, "") 'cont40hc.ToString
                        Me.DataGridView1.Item("rf20", currow).Value = IIf(cont20rf > 0, cont20rf.ToString, "") ' cont20rf.ToString
                        Me.DataGridView1.Item("rf40", currow).Value = IIf(cont40rf > 0, cont40rf.ToString, "") 'cont40rf.ToString

                    End If


                    ' show theo 4 cot

                    '--------------------
                    If ds.Tables(0).Rows(i).Item("FCL").ToString = True Then
                        '
                        'If cont20 > 0 Then
                        '    Me.DataGridView1.Item("Column7", currow).Value = cont20.ToString ' + " x 20GP"

                        'End If
                        'If cont40 > 0 Then
                        '    Me.DataGridView1.Item("Column8", currow).Value += cont40.ToString ' + " x 40GP; "
                        'End If
                        'If cont40hc > 0 Then
                        '    Me.DataGridView1.Item("volume", currow).Value += cont40hc.ToString + " x 40HC; "
                        'End If

                        'If cont20rf > 0 Then
                        '    Me.DataGridView1.Item("volume", currow).Value += cont20.ToString + " x 20RF; "
                        'End If

                        'If cont40rf > 0 Then
                        '    Me.DataGridView1.Item("volume", currow).Value += cont20.ToString + " x 40RF"
                        'End If



                    ElseIf ds.Tables(0).Rows(i).Item("LCL").ToString = True Then

                        Me.DataGridView1.Item("cbm", currow).Value = khoi.ToString + " CBM"
                    End If
                    If ds.Tables(0).Rows(i).Item("LCL").ToString = True Then
                        Me.DataGridView1.Item("Containertype", currow).Value = "Consol"
                    End If
                    If ds.Tables(0).Rows(i).Item("FCL").ToString = True Then
                        Me.DataGridView1.Item("Containertype", currow).Value = "FCL"
                    End If

                    '---------------------
                    ' client
                    Dim sqlcus As String
                    Dim dscus As New DataSet
                    Try
                        If ds.Tables(0).Rows(i).Item("customerid_showtc").ToString <> "" Then
                            sqlcus = "select * from customer where customer_id='" & ds.Tables(0).Rows(i).Item("customerid_showtc").ToString & "' "
                            dscus = ReadDataSet(sqlcus)
                            If dscus.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("client", currow).Value = dscus.Tables(0).Rows(0).Item("company").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try

                    '---------------

                    ' client
                    Dim sqlagent As String
                    Dim dsagent As New DataSet
                    Try
                        If ds.Tables(0).Rows(i).Item("agentid").ToString <> "" Then
                            sqlagent = "select * from customer where customer_id='" & ds.Tables(0).Rows(i).Item("agentid").ToString & "' "
                            dsagent = ReadDataSet(sqlagent)
                            If dsagent.Tables(0).Rows.Count > 0 Then
                                Me.DataGridView1.Item("agent", currow).Value = dsagent.Tables(0).Rows(0).Item("company").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try

                    '---------------
                    Dim debitInv As Double = 0
                    Dim debitNoInv As Double = 0
                    Dim debitOversea As Double = 0
                    Dim creditInv As Double = 0
                    Dim creditNoInv As Double = 0
                    Dim creditOversea As Double = 0

                    Dim k As Integer
                    Dim t As Integer
                    '--------------------------------
                    Dim otherdebit As Double = 0
                    Dim othercredit As Double = 0
                    Dim tongdebitthue As Double = 0
                    Dim tongcreditthue As Double = 0
                    '----------------------------
                    Dim tongdebit As Double = 0
                    Dim tongcredit As Double = 0
                    Dim tongdebitvnd As Double = 0
                    Dim tongcreditvnd As Double = 0


                    Dim tongindebit As Double = 0
                    Dim tongincredit As Double = 0
                    Dim tongindebitvnd As Double = 0
                    Dim tongincreditvnd As Double = 0

                    tigiadebit = 0
                    Dim giatientruocthue As Double = 0
                    '-------------------------------

                    ' seclect distinct
                    'them cac cot tuong ung
                    '
                    If Me.chkVND.Checked = True Then

                        If Me.chkallCus.Checked = True Then

                            sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id  left join customer on customer.customer_id=customerid where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  and charge_id='" & FindValueID(Me.cbocharge, Me.cbocharge.Text) & "' and os=0  " 'and daily=0

                        Else
                            sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id  left join customer on customer.customer_id=customerid where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  and charge_id='" & FindValueID(Me.cbocharge, Me.cbocharge.Text) & "'  and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and os=0  " 'and daily=0

                        End If
                        dsF = ReadDataSet(sqlF)
                        If dsF.Tables(0).Rows.Count > 0 Then
                            tongindebit = 0
                            tongincredit = 0
                            tongindebitvnd = 0
                            tongincreditvnd = 0
                            tongdebitthue = 0


                            For k = 0 To dsF.Tables(0).Rows.Count - 1
                                ' them dong chi tiet container
                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                '----------
                                Try
                                    If dsF.Tables(0).Rows(k).Item("currency").ToString = "VND" Then
                                        giatientruocthue = dsF.Tables(0).Rows(k).Item("price").ToString / ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)
                                    Else
                                        giatientruocthue = (dsF.Tables(0).Rows(k).Item("price").ToString * dsF.Tables(0).Rows(k).Item("tigia").ToString) / ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)
                                    End If
                                Catch ex As Exception

                                End Try
                                If dsF.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                    ' show gia 
                                    ' ra toan bo cot, nue dung thi them vao
                                    For t = 0 To Me.DataGridView1.Columns.Count - 1
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) + "_" + UCase(dsF.Tables(0).Rows(k).Item("debitcredit").ToString) = UCase(Me.DataGridView1.Columns(t).Name) Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item(Me.DataGridView1.Columns(t).Name, currow).Value = CDbl(FormatNumber(giatientruocthue, 3))

                                            Catch ex As Exception

                                            End Try

                                        End If
                                    Next
                                    Me.DataGridView1.Item("SoContainer", currow).Value = dsF.Tables(0).Rows(0).Item("container").ToString
                                    '--------------
                                    Try
                                        Me.DataGridView1.Item("exrate", currow).Value = dsF.Tables(0).Rows(0).Item("tigia").ToString
                                        tigiadebit = CDbl(dsF.Tables(0).Rows(0).Item("tigia").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongdebitthue += (giatientruocthue * CDbl(dsF.Tables(0).Rows(k).Item("taxprice").ToString) / 100) 'CDbl(dsF.Tables(0).Rows(k).Item("pricethue").ToString) / CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)

                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongdebit += CDbl(giatientruocthue)
                                        tongdebitvnd += CDbl(giatientruocthue)
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("customer", currow).Value = dsF.Tables(0).Rows(k).Item("company").ToString
                                End If
                                ' credit
                                If dsF.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                    ' show gia 
                                    ' ra toan bo cot, nue dung thi them vao
                                    For t = 0 To Me.DataGridView1.Columns.Count - 1
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) + "_" + UCase(dsF.Tables(0).Rows(k).Item("debitcredit").ToString) = UCase(Me.DataGridView1.Columns(t).Name) Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item(Me.DataGridView1.Columns(t).Name, currow).Value = CDbl(FormatNumber(giatientruocthue, 3))

                                            Catch ex As Exception

                                            End Try

                                        End If
                                    Next
                                    Me.DataGridView1.Item("SoContainer", currow).Value = dsF.Tables(0).Rows(0).Item("container").ToString
                                    Try
                                        tongcreditthue += (giatientruocthue * CDbl(dsF.Tables(0).Rows(k).Item("taxprice").ToString) / 100) 'CDbl(dsF.Tables(0).Rows(k).Item("pricethue").ToString) / CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        tongcredit += CDbl(giatientruocthue)
                                        tongcreditvnd += CDbl(giatientruocthue) '* CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)
                                    Catch ex As Exception

                                    End Try
                                    ' Me.DataGridView1.Item("SoContainer", currow).Value += dsF.Tables(0).Rows(k).Item("container").ToString + "(" + dsF.Tables(0).Rows(k).Item("charge_code").ToString + "=" + FormatNumber(giatientruocthue, 2) + ")///"
                                    Me.DataGridView1.Item("customer", currow).Value = dsF.Tables(0).Rows(k).Item("company").ToString
                                End If
                                'Me.DataGridView1.Item("totalcredit", currow).Value = FormatNumber(tongcredit, 2)

                                'Me.DataGridView1.Item("totaldebit", currow).Value = FormatNumber(tongdebit, 2)
                                'Me.DataGridView1.Item("profit", currow).Value = FormatNumber(tongdebit - tongcredit, 2)

                                currow += 1
                            Next



                        End If




                    Else
                        'Dim sqlF As String
                        'Dim dsF As New DataSet
                        If Me.chkallCus.Checked = True Then
                            sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id left join customer on customer.customer_id=customerid where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  and charge_id='" & FindValueID(Me.cbocharge, Me.cbocharge.Text) & "'  and os=0  " 'and daily=0

                        Else
                            sqlF = "select * from " & tableFreight & " left join charge on " & tableFreight & ".itemid = charge.charge_id left join customer on customer.customer_id=customerid where " & tableFreightID & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  and charge_id='" & FindValueID(Me.cbocharge, Me.cbocharge.Text) & "'  and customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' and os=0  " 'and daily=0

                        End If
                        dsF = ReadDataSet(sqlF)
                        If dsF.Tables(0).Rows.Count > 0 Then
                            tongindebit = 0
                            tongincredit = 0
                            tongindebitvnd = 0
                            tongincreditvnd = 0
                            tongdebitthue = 0


                            For k = 0 To dsF.Tables(0).Rows.Count - 1
                                '-----------------------------them tung cont
                                Me.DataGridView1.Rows.Add(1)
                                currow = DataGridView1.RowCount - 2
                                '------------------
                                Try
                                    If dsF.Tables(0).Rows(k).Item("currency").ToString = "USD" Then
                                        giatientruocthue = dsF.Tables(0).Rows(k).Item("price").ToString / ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)
                                    Else
                                        giatientruocthue = (dsF.Tables(0).Rows(k).Item("price").ToString / dsF.Tables(0).Rows(k).Item("tigia").ToString) / ((dsF.Tables(0).Rows(k).Item("taxprice").ToString / 100) + 1)
                                    End If
                                Catch ex As Exception

                                End Try
                                If dsF.Tables(0).Rows(k).Item("debitcredit").ToString = "Debit" Then

                                    ' show gia 
                                    ' ra toan bo cot, nue dung thi them vao
                                    For t = 0 To Me.DataGridView1.Columns.Count - 1
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) + "_" + UCase(dsF.Tables(0).Rows(k).Item("debitcredit").ToString) = UCase(Me.DataGridView1.Columns(t).Name) Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item(Me.DataGridView1.Columns(t).Name, currow).Value = CDbl(FormatNumber(giatientruocthue, 3))

                                            Catch ex As Exception

                                            End Try

                                        End If
                                    Next
                                    Me.DataGridView1.Item("SoContainer", currow).Value = dsF.Tables(0).Rows(0).Item("container").ToString
                                    ' show tigia
                                    Try
                                        Me.DataGridView1.Item("exrate", currow).Value = dsF.Tables(0).Rows(0).Item("tigia").ToString
                                        tigiadebit = CDbl(dsF.Tables(0).Rows(0).Item("tigia").ToString)
                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongdebitthue += (giatientruocthue * CDbl(dsF.Tables(0).Rows(k).Item("taxprice").ToString) / 100) 'CDbl(dsF.Tables(0).Rows(k).Item("pricethue").ToString) / CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)

                                    Catch ex As Exception

                                    End Try

                                    Try
                                        tongdebit += CDbl(giatientruocthue)
                                        tongdebitvnd += CDbl(giatientruocthue) * CDbl(dsF.Tables(0).Rows(0).Item("tigia").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("customer", currow).Value = dsF.Tables(0).Rows(k).Item("company").ToString
                                End If
                                ' credit
                                If dsF.Tables(0).Rows(k).Item("debitcredit").ToString = "Credit" Then

                                    ' show gia 
                                    ' ra toan bo cot, nue dung thi them vao
                                    For t = 0 To Me.DataGridView1.Columns.Count - 1
                                        If UCase(dsF.Tables(0).Rows(k).Item("charge_code").ToString) + "_" + UCase(dsF.Tables(0).Rows(k).Item("debitcredit").ToString) = UCase(Me.DataGridView1.Columns(t).Name) Then
                                            ' lay price truoc thue
                                            Try
                                                Me.DataGridView1.Item(Me.DataGridView1.Columns(t).Name, currow).Value = CDbl(FormatNumber(giatientruocthue, 3))

                                            Catch ex As Exception

                                            End Try

                                        End If
                                    Next
                                    Me.DataGridView1.Item("SoContainer", currow).Value = dsF.Tables(0).Rows(0).Item("container").ToString
                                    Try
                                        tongcreditthue += (giatientruocthue * CDbl(dsF.Tables(0).Rows(k).Item("taxprice").ToString) / 100) 'CDbl(dsF.Tables(0).Rows(k).Item("pricethue").ToString) / CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)

                                    Catch ex As Exception

                                    End Try
                                    Try
                                        tongcredit += CDbl(giatientruocthue)
                                        tongcreditvnd += CDbl(giatientruocthue) * CDbl(dsF.Tables(0).Rows(k).Item("tigia").ToString)
                                    Catch ex As Exception

                                    End Try
                                    Me.DataGridView1.Item("customer", currow).Value = dsF.Tables(0).Rows(k).Item("company").ToString
                                End If
                                'Me.DataGridView1.Item("SoContainer", currow).Value += dsF.Tables(0).Rows(k).Item("container").ToString + "(" + dsF.Tables(0).Rows(k).Item("charge_code").ToString + "=" + FormatNumber(giatientruocthue, 2) + ")///"
                                'Me.DataGridView1.Item("totalcredit", currow).Value = FormatNumber(tongcredit, 2)

                                'Me.DataGridView1.Item("totaldebit", currow).Value = FormatNumber(tongdebit, 2)
                                'Me.DataGridView1.Item("profit", currow).Value = FormatNumber(tongdebit - tongcredit, 2)


                                currow += 1
                            Next


                        End If






                    End If









                    '------------------------------------------


                    'itang += 1
                Next



            End If
            ' dua cac phi vao



            '=================================================================================================================
            '=================================================================================================================
            '------------------------

        Catch ex As Exception

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
            ' Me.Label4.Text = "WEEKLY REPORT (Các phí thu hộ và chi hộ tính riêng.)"

            id = "salecode"
            value = "salecode"
            Me.cbosalescode.Items.Clear()


            strSQL = "Select salecode From sale order by salecode "
            loadDataToObject(Me.cbosalescode, strSQL, id, value)
            ' item
            id = "charge_id"
            value = "charge_code"
            Me.cbocharge.Items.Clear()


            strSQL = "Select charge_id,charge_code From charge where continued=1 order by charge_code "
            loadDataToObject(Me.cbocharge, strSQL, id, value)
            ' cus
            id = "customer_id"
            value = "company"
            Me.cbocus.Items.Clear()


            strSQL = "Select customer_id,company From customer order by company "
            loadDataToObject(Me.cbocus, strSQL, id, value)


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
End Class