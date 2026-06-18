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
Public Class frmDuyetDNTT
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Me.DataGridView1.Rows.Clear()
            If Me.chkall.Checked = True Then

                weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "OutboundID", "mblmawb")


                weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundID", "hbl")


                'weeklyreport_("Oversea-Sea-Export Shipments", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid")

                'weeklyreport_("Oversea-Sea-Import Shipments", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid")

                'If Me.cboIOL.Text.Trim = "ACS-Sea-Export" Then
                '    gethbl("MBLMAWB", "Outbound_ACSSeaExport", "BLOB_ID")
                'End If
                'weeklyreport_("ACS-Sea-Export Shipments", "Outbound_ACSSeaExport", "BLOB_ID", "containertype", "outboundid", "outboundfreight", "outboundid")

                weeklyreport_("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundID", "hbl")

                'If Me.ComboBox2.Text = "ACS-Air-Export" Then
                weeklyreport_("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundID", "mblmawb")

                'End If

                'If Me.ComboBox2.Text = "Domestic-Truck" Then
                ' weeklyreport("Domestic-Truck Shipments", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
                'End If
                'If Me.ComboBox2.Text = "Logistics-Customs" Then
                weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsfreightid", "logisticsID", "mblmawb")
                '  End If
            Else
                If Me.ComboBox2.Text = "Agency-Export" Then
                    weeklyreport_("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundID", "mblmawb")
                End If
                If Me.ComboBox2.Text = "Agency-Import" Then
                    weeklyreport_("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundID", "hbl")
                End If
                If Me.ComboBox2.Text = "Oversea-Sea-Export" Then
                    weeklyreport_("Oversea-Sea-Export Shipments", "Outbound_OverseaSeaExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundID", "mblmawb")
                End If
                If Me.ComboBox2.Text = "Oversea-Sea-Import" Then
                    weeklyreport_("Oversea-Sea-Import Shipments", "Inbound_OverseaSeaimport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundID", "hbl")
                End If

                If Me.ComboBox2.Text = "ACS-Air-Import" Then
                    weeklyreport_("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundID", "hbl")
                End If
                If Me.ComboBox2.Text = "ACS-Air-Export" Then
                    weeklyreport_("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundID", "mblmawb")
                End If

                'If Me.ComboBox2.Text = "Domestic-Truck" Then
                '    weeklyreport("Domestic-Truck Shipments", "Logistics_Truck", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid")
                'End If
                If Me.ComboBox2.Text = "Logistics-Customs" Then
                    weeklyreport_("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsfreightid", "logisticsID", "mblmawb")
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
        Catch ex As Exception

        End Try
    End Sub

    Public Sub weeklyreport_(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal tableFreightID_F As String, ByVal hbl As String)
        Try
            Dim currow As Integer
            ' kiem tra neu co du lieu yhi moi add
            Dim sql As String
            Dim ds As New DataSet
            Dim i As Integer
            Dim NGAY1 As String = D1.Text & "-" & T1.Text & "-" & Y1.Text
            Dim NGAY2 As String = N2.Text & "-" & T2.Text & "-" & Y2.Text
            If Me.chkselect.Checked = True Then
                sql = "select * from " & TableDept & " where ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%'  order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

            Else
                sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'   order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

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
                    ' kiem tra lo co dntt hay khong
                    Dim sqlkt As String
                    Dim dskt As New DataSet
                    sqlkt = "select * from " & tableFreight & " left join customer on  " & tableFreight & ".customerid = customer.customer_id left join charge on " & tableFreight & " .itemid=charge.charge_id where " & tableFreightID_F & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and dntt=1 and ktt=1  and boss=1 "
                    dskt = ReadDataSet(sqlkt)
                    If dskt.Tables(0).Rows.Count > 0 Then

                    Else
                        GoTo tiep
                    End If
                    '---------------------------------------------------------------------
                    Me.DataGridView1.Rows.Add(1)
                    currow = DataGridView1.RowCount - 2
                    Me.DataGridView1.Rows(currow).DefaultCellStyle.ForeColor = Color.DarkBlue
                    'Me.DataGridView1.Item("no", currow).Value = i.ToString 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString

                    Me.DataGridView1.Item("job", currow).Value = ds.Tables(0).Rows(i).Item("ref").ToString
                    ' Me.DataGridView1.Item("sales", currow).Value = ds.Tables(0).Rows(i).Item("salecode").ToString
                    ' Me.DataGridView1.Item("remarks", currow).Value = ds.Tables(0).Rows(i).Item("remarks").ToString
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
                    ''-------------------



                    ''---------------
                    Dim debitInv As Double = 0
                    Dim debitNoInv As Double = 0
                    Dim debitOversea As Double = 0
                    Dim creditInv As Double = 0
                    Dim creditNoInv As Double = 0
                    Dim creditOversea As Double = 0

                    Dim ik As Integer
                    'If Me.chkVND.Checked = True Then
                    Dim sqlF As String
                    Dim dsF As New DataSet
                    'If Me.chkapprove.Checked = True Then
                    sqlF = "select * from " & tableFreight & " left join customer on  " & tableFreight & ".customerid = customer.customer_id left join charge on " & tableFreight & " .itemid=charge.charge_id where " & tableFreightID_F & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and dntt=1 and ktt=1 and boss=1  " 'and daily=0

                    'Else
                    '    sqlF = "select * from " & tableFreight & " left join customer on  " & tableFreight & ".customerid = customer.customer_id left join charge on " & tableFreight & " .itemid=charge.charge_id where " & tableFreightID_F & " ='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "' and dntt=1 and ktt=1 and boss=0  " 'and daily=0

                    'End If
                    dsF = ReadDataSet(sqlF)
                    If dsF.Tables(0).Rows.Count > 0 Then


                        For ik = 0 To dsF.Tables(0).Rows.Count - 1
                            Me.DataGridView1.Rows.Add(1)
                            currow = DataGridView1.RowCount - 2
                            Me.DataGridView1.Item("ID", currow).Value = dsF.Tables(0).Rows(ik).Item(tableFreightID).ToString
                            Me.DataGridView1.Item("dntt", currow).Value = dsF.Tables(0).Rows(ik).Item("dntt").ToString
                            Me.DataGridView1.Item("ktt_", currow).Value = dsF.Tables(0).Rows(ik).Item("ktt").ToString
                            Me.DataGridView1.Item("boss_", currow).Value = dsF.Tables(0).Rows(ik).Item("boss").ToString

                            Me.DataGridView1.Item("vendor", currow).Value = dsF.Tables(0).Rows(ik).Item("company").ToString
                            Me.DataGridView1.Item("item", currow).Value = dsF.Tables(0).Rows(ik).Item("charge").ToString
                            Me.DataGridView1.Item("cur", currow).Value = dsF.Tables(0).Rows(ik).Item("currency").ToString
                            Me.DataGridView1.Item("amount", currow).Value = FormatNumber(dsF.Tables(0).Rows(ik).Item("price").ToString, 2)
                            Me.DataGridView1.Item("REMARKS", currow).Value = dsF.Tables(0).Rows(ik).Item("NOTE").ToString
                        Next



                    End If
tiep:
                Next
                ' dua cac phi vao

            End If

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

            tmrCountdown.Interval = 500
            TargetDT = DateTime.Now.Add(CountDownFrom)
            tmrCountdown.Start()
            ' Me.Label4.Text = "WEEKLY REPORT (Các phí thu hộ và chi hộ tính riêng.)"
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Approveboss(ByVal tieudedong As String, ByVal TableDept As String, ByVal TableDeptID As String, ByVal tableContainer As String, ByVal tableContainerID As String, ByVal tableFreight As String, ByVal tableFreightID As String, ByVal tableFreightID_F As String, ByVal hbl As String)

        Dim Approve, boss As Boolean
        Dim rs As New ADODB.Recordset
        ' Xác định vị trí row trong grid
        Dim index As Integer = Me.DataGridView1.CurrentRow.Index
        Dim strQueryDetailBillOfLading_HouseList As String
        'If Not UserRight("mnuInbound", "Approve") Then
        '    DisplayMessage(True, IIf(gLang = "E", "Sorry, the proccess requires an access rigth to carry out.", "Bạn cần được cấp quyền."))
        'Elsetry
        Try
            strQueryDetailBillOfLading_HouseList = "Select * from " & tableFreight & " where" + " " & tableFreightID & " = '" & Me.DataGridView1.Item("id", index).Value.ToString & "'"
            rs.Open(strQueryDetailBillOfLading_HouseList, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
            boss = Not rs.Fields("boss").Value
            '  Approve = Not rs.Fields("approve").Value
            rs.Update("boss", boss)
            rs.Update("Approve", boss)
            rs.Close()
        Catch ex As Exception

        End Try

        'End If

    End Sub
    Dim thoatapp As Boolean = False
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        '        Try
        '            Dim ColIndex, RowIndex As Integer
        '            ' Xác định vị trí row trong grid
        '            If Me.DataGridView1.RowCount = 0 Then
        '                Return
        '            End If
        '            Dim index As Integer = Me.DataGridView1.CurrentRow.Index

        '            ColIndex = e.ColumnIndex()
        '            RowIndex = e.RowIndex
        '            If ColIndex < 0 Then
        '                Return
        '            End If
        '            If UCase(Me.DataGridView1.Columns(ColIndex).Name) = "BOSS" And Me.DataGridView1.CurrentCellAddress.Y = RowIndex Then

        '                If Me.chkall.Checked = True Then
        '                    thoatapp = False
        '                    Approveboss("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundid", "mblmawb")
        '                    If thoatapp = True Then
        '                        GoTo thoat
        '                    End If
        '                    Approveboss("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundid", "hbl")
        '                    If thoatapp = True Then
        '                        GoTo thoat
        '                    End If
        '                    Approveboss("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundid", "hbl")
        '                    If thoatapp = True Then
        '                        GoTo thoat
        '                    End If
        '                    Approveboss("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundid", "mblmawb")
        '                    If thoatapp = True Then
        '                        GoTo thoat
        '                    End If
        '                    Approveboss("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsfreightid", "logisticsid", "mblmawb")
        '                Else
        '                    If Me.ComboBox2.Text = "Agency-Export" Then
        '                        Approveboss("Export Shipments", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundid", "mblmawb")
        '                    End If
        '                    If Me.ComboBox2.Text = "Agency-Import" Then
        '                        Approveboss("Import Shipments", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundid", "hbl")
        '                    End If

        '                    If Me.ComboBox2.Text = "ACS-Air-Import" Then
        '                        Approveboss("ACS-Air-Import Shipments", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundfreightid", "inboundid", "hbl")
        '                    End If
        '                    If Me.ComboBox2.Text = "ACS-Air-Export" Then
        '                        Approveboss("ACS-Air-Export Shipments", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundfreightid", "outboundid", "mblmawb")
        '                    End If


        '                    If Me.ComboBox2.Text = "Logistics-Customs" Then
        '                        Approveboss("Logistics-Customs Shipments", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsfreightid", "logisticsid", "mblmawb")
        '                    End If
        '                End If
        '                'QueryDetailBillOfLading_House("And Cargo_House.BLH_ID='" & mBILLOFLADING_HOUSEId & "'", , index) '" And BILLOFLADING_HOUSE.BLH_ID='" & Me.dgdDetailBillOfLading_House.Item("BLH_ID", index).Value.ToString & "' ", , index)
        '                ' DisplayMessage(True, "")
        'thoat:
        '                Me.Button1_Click(sender, e)
        '            End If


        '        Catch ex As Exception

        '        End Try
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Me.Button1_Click(sender, e)
        Catch ex As Exception

        End Try
    End Sub
    Dim SetTime As Integer
    Private TargetDT As DateTime
    Private CountDownFrom As TimeSpan = TimeSpan.FromMilliseconds(300000)
    Private Sub tmrCountdown_Tick(sender As Object, e As EventArgs) Handles tmrCountdown.Tick
        Try
            Dim ts As TimeSpan = TargetDT.Subtract(DateTime.Now)
            If ts.TotalMilliseconds > 0 Then
                lbltime.Text = ts.ToString("mm\:ss")
            Else
                lbltime.Text = "00:00"

                tmrCountdown.Interval = 500
                TargetDT = DateTime.Now.Add(CountDownFrom)
                tmrCountdown.Start()
                '  MessageBox.Show("Done")
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class