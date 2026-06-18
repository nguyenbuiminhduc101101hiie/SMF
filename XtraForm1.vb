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
Public Class frmBangtheodoiBillTokhai
    Dim dt As DataTable

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Dim ts As DataGridTableStyle = New DataGridTableStyle()
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            iT = 1
            Try
                dt = New DataTable("Bangtheodoibilltokhai")
                dt.Columns.Add(New DataColumn("Số TT", Type.GetType("System.Int32")))  ' 
                dt.Columns.Add(New DataColumn("Mã Lô"))  '    dt.Columns.Add("malo")
                dt.Columns.Add(New DataColumn("Tờ Khai"))
                dt.Columns.Add(New DataColumn("Tên Khách Hàng"))

                dt.Columns.Add(New DataColumn("shipper"))
                dt.Columns.Add(New DataColumn("consignee"))
                dt.Columns.Add(New DataColumn("Mặt Hàng"))


                dt.Columns.Add(New DataColumn("Địa Điểm ĐH"))
                dt.Columns.Add(New DataColumn("Ngày ĐH"))
                dt.Columns.Add(New DataColumn("Hãng Tàu"))

                dt.Columns.Add(New DataColumn("POL"))
                dt.Columns.Add(New DataColumn("POD"))
                dt.Columns.Add(New DataColumn("ETD"))

                dt.Columns.Add(New DataColumn("ETA"))
                dt.Columns.Add(New DataColumn("Bill"))
                dt.Columns.Add(New DataColumn("Ngày Khai HQ"))

                dt.Columns.Add(New DataColumn("Ngày HTTTHQ"))


                dt.Columns.Add(New DataColumn("Air"))
                dt.Columns.Add(New DataColumn("LCL (CBM)"))
                dt.Columns.Add(New DataColumn("Cont 20"))
                dt.Columns.Add(New DataColumn("Cont 40"))
                dt.Columns.Add(New DataColumn("Cont"))
                dt.Columns.Add(New DataColumn("Ghi Chú"))
            Catch ex As Exception

            End Try
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            If Me.chkall.Checked Then
                weeklyreport_("AGENCY-EXPORT", "outbound", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "AGENCY-EXPORT")
                weeklyreport_("AGENCY-IMPORT", "inbound", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "AGENCY-IMPORT")
                weeklyreport_("ACS-Air-Import", "Inbound_OverseaAirImport", "blib_id", "containerrepair", "inboundid", "inboundfreight", "inboundid", "hbl", "mbl", "ACS-Air-Import")
                weeklyreport_("ACS-AIR-EXPORT", "Outbound_OverseaAirExport", "blob_id", "containertype", "outboundid", "outboundfreight", "outboundid", "mblmawb", "mblcarrier", "ACS-AIR-EXPORT")

                weeklyreport_("LOGISTICS-CUSTOMS", "Logistics", "blob_id", "containerlogistics", "outboundid", "logisticsfreight", "logisticsid", "mblmawb", "mblcarrier", "LOGISTICS-CUSTOMS")

            Else
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

            End If

            ' Me.BangtheodoiBillTokhaiTableAdapter1.Fill(Me.HKLogDataSet1.BangtheodoiBillTokhai)


            'hien thi ra grid 
            Me.GridControl1.DataSource = dt
            Me.Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception

        End Try
    End Sub
    Dim iT As Integer
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
            If Me.chkallCus.Checked = True Then
                If Me.chkallsales.Checked = True Then

                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and status='" & Me.ComboBox3.Text & "' order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and status='" & Me.ComboBox3.Text & "' order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and status='" & Me.ComboBox3.Text & "' order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "'  and status='" & Me.ComboBox3.Text & "' order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' and status='" & Me.ComboBox3.Text & "' order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select * from " & TableDept & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' and status='" & Me.ComboBox3.Text & "' order by convert(datetime,datereport) desc " 'and nhom like 'COC%'

                    End If
                End If


            Else ' rieng tung cus
                If Me.chkallsales.Checked = True Then

                    If Me.chkselect.Checked = True Then
                        sql = "select distinct " & TableDeptID & "  from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & "  =" & tableFreight & "." & tableFreightID & "  where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and status='" & Me.ComboBox3.Text & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select distinct " & TableDeptID & " from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & "  =" & tableFreight & "." & tableFreightID & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and status='" & Me.ComboBox3.Text & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "' " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select distinct " & TableDeptID & " from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & "  =" & tableFreight & "." & tableFreightID & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and status='" & Me.ComboBox3.Text & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  " 'and nhom like 'COC%'

                    End If
                Else
                    If Me.chkselect.Checked = True Then
                        sql = "select distinct " & TableDeptID & " from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & "  =" & tableFreight & "." & tableFreightID & "  where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & hbl & " like '%" & Me.txthbl.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "'  and status='" & Me.ComboBox3.Text & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  " 'and nhom like 'COC%'

                    End If
                    If Me.chkmbl.Checked = True Then
                        sql = "select distinct " & TableDeptID & " from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & "  =" & tableFreight & "." & tableFreightID & "  where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%' and " & mbl & " like '%" & Me.TextBox1.Text & "%' and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' and status='" & Me.ComboBox3.Text & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  " 'and nhom like 'COC%'

                    End If
                    If Me.chkselect.Checked = False And Me.chkmbl.Checked = False Then

                        sql = "select distinct " & TableDeptID & " from " & TableDept & " left join " & tableFreight & " on " & TableDept & "." & TableDeptID & "  =" & tableFreight & "." & tableFreightID & " where CONVERT(DATETIME,datereport) between '" & NGAY1 & "' and '" & NGAY2 & "' and ref like '%" & Me.ComboBox1.Text & "%'  and nhom = '" & NHOM & "' and salecode='" & Me.cbosalescode.Text & "' and status='" & Me.ComboBox3.Text & "' and " & tableFreight & ".customerid='" & FindValueID(Me.cbocus, Me.cbocus.Text) & "'  " 'and nhom like 'COC%'

                    End If
                End If


            End If




            ds = ReadDataSet(sql)

           

            ' them cot
        

            '------------------------------------------------------
            Dim m As Integer
            Try

            Catch ex As Exception

            End Try

            Dim tigiadebit As Double = 0
            Dim itang As Integer = 1
            Dim rs As New ADODB.Recordset
            Dim strQuery As String
            Dim dr As DataRow
            ' xoa bangtheodoibilltokhai
            ' Dim cmd1 As New ADODB.Command
            ' cmd1.let_ActiveConnection(strconn)
            ' cmd1.CommandText = "delete from bangtheodoibilltokhai  "

            'cmd1.Execute(, , ADODB.CommandTypeEnum.adCmdText)
            '----------------------------
            ' them cot cho dt

          
            '--------------------
            If ds.Tables(0).Rows.Count > 0 Then
                ' ung voi moi lo ta tim sont
                'Me.DataGridView1.Rows.Add(1)
                'currow = DataGridView1.RowCount - 2
                'Me.DataGridView1.Item("agent", currow).Value = tieudedong 'dso.Tables(0).Rows(i).Item("Department_Shipment").ToString
                For i = 0 To ds.Tables(0).Rows.Count - 1
                    ' lap bill
                    ' ung voi tung id t alay tung hbl
                    dr = dt.NewRow()

                    Dim sqlhbl As String
                    Dim dshbl As New DataSet
                    sqlhbl = "select *  from " & TableDept & "  where  " & TableDeptID & "='" & ds.Tables(0).Rows(i).Item(TableDeptID).ToString & "'  "
                    dshbl = ReadDataSet(sqlhbl)
                    '-----------------------------------------
                    ' mo recordset de them vao bangtheodoibilltokhai
                    ' strQuery = "select * from bangtheodoibilltokhai"
                    ' rs.Open(strQuery, strconn, ADODB.CursorTypeEnum.adOpenDynamic, ADODB.LockTypeEnum.adLockOptimistic, ADODB.CommandTypeEnum.adCmdText)
                    ' With rs

                    '.AddNew()
                    dr.BeginEdit()

                    dr("Số TT") = (iT).ToString
                    dr("Mã Lô") = dshbl.Tables(0).Rows(0).Item("ref").ToString

                    dr("Tờ Khai") = dshbl.Tables(0).Rows(0).Item("tkhq").ToString

                    ' client
                    Dim sqlcus As String
                    Dim dscus As New DataSet
                    Try
                        If dshbl.Tables(0).Rows(0).Item("customerid_showtc").ToString <> "" Then
                            sqlcus = "select * from customer where customer_id='" & dshbl.Tables(0).Rows(0).Item("customerid_showtc").ToString & "' "
                            dscus = ReadDataSet(sqlcus)
                            If dscus.Tables(0).Rows.Count > 0 Then
                                dr("Tên Khách Hàng") = dscus.Tables(0).Rows(0).Item("company").ToString
                            End If
                        End If

                    Catch ex As Exception

                    End Try

                    dr("Shipper") = dshbl.Tables(0).Rows(0).Item("shipper").ToString
                    dr("Consignee") = dshbl.Tables(0).Rows(0).Item("consignee").ToString
                    dr("Mặt Hàng") = dshbl.Tables(0).Rows(0).Item("description").ToString
                    Try
                        dr("Địa Điểm ĐH") = dshbl.Tables(0).Rows(0).Item("por").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        dr("Ngày ĐH") = dshbl.Tables(0).Rows(0).Item("sailingdate").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        dr("Hãng Tàu") = dshbl.Tables(0).Rows(0).Item("shippingline").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        dr("POL") = dshbl.Tables(0).Rows(0).Item("pol").ToString
                    Catch ex As Exception

                    End Try
                    Try
                        dr("POD") = dshbl.Tables(0).Rows(0).Item("pod").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        dr("ETD") = dshbl.Tables(0).Rows(0).Item("sailingdate").ToString
                    Catch ex As Exception

                    End Try


                    Try
                        dr("ETA") = dshbl.Tables(0).Rows(0).Item("eta").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        dr("Bill") = dshbl.Tables(0).Rows(0).Item("mblcarrier").ToString + "/" + dshbl.Tables(0).Rows(0).Item("mblmawb").ToString
                    Catch ex As Exception
                        dr("Bill") = dshbl.Tables(0).Rows(0).Item("mbl").ToString + "/" + dshbl.Tables(0).Rows(0).Item("hbl").ToString

                    End Try
                    Try
                        dr("Ngày Khai HQ") = dshbl.Tables(0).Rows(0).Item("ngaykhaibao").ToString
                    Catch ex As Exception

                    End Try

                    Try
                        dr("Ngày HTTTHQ") = dshbl.Tables(0).Rows(0).Item("ngayhttthq").ToString
                    Catch ex As Exception

                    End Try





                    Try
                        dr("Ghi Chú") = dshbl.Tables(0).Rows(0).Item("remarks").ToString
                    Catch ex As Exception

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

                    sqlcont = "select * from " & tableContainer & " where " & tableContainerID & " = '" & dshbl.Tables(0).Rows(0).Item(TableDeptID).ToString & "' "
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
                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*20*") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                                cont20 += 1
                            End If

                            If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*40*") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                                cont40 += 1
                            End If

                            ' If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "40HC") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*HC*") Then
                            'cont40hc += 1
                            ' End If

                            'If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "20RF") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                            'cont20rf += 1
                            ' End If
                            ' If (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) = "40RF") Then 'And Not (UCase(dscont.Tables(0).Rows(ic).Item("containertype").ToString) Like "*RF*") Then
                            'cont40rf += 1
                            ' End If

                            Try
                                cont += dscont.Tables(0).Rows(ic).Item("containerno").ToString + "/"

                            Catch ex As Exception

                            End Try


                        Next
                        Try
                            dr("Cont 20") = cont20
                        Catch ex As Exception

                        End Try
                        Try
                            dr("Cont") = cont
                        Catch ex As Exception

                        End Try
                        Try
                            dr("Cont 40") = cont40
                        Catch ex As Exception

                        End Try
                        If dshbl.Tables(0).Rows(0).Item("Air").ToString = True Then
                            Try
                                dr("Air") = dshbl.Tables(0).Rows(0).Item("gw").ToString
                            Catch ex As Exception
                                dr("Air") = kgs
                            End Try
                        End If
                        If dshbl.Tables(0).Rows(0).Item("LCL").ToString = True Then
                            dr("LCL (CBM)") = khoi
                        End If


                    End If

                    '.Update()
                    ' .Close()
                    ' End With












                    ' show theo 4 cot

                    '--------------------


                    '---------------------


                    '---------------


                    '---------------
                    iT += 1
                    dr.EndEdit()
                    dt.Rows.Add(dr)
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
            ' ExportExecel(Me.DataGridView1, Me)
            If Me.SaveFileDialog1.ShowDialog(Me) = DialogResult.OK Then
                Me.GridControl1.ExportToXlsx(Me.SaveFileDialog1.FileName)
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmWeeklyReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'TODO: This line of code loads data into the 'HKLogDataSet1.BangtheodoiBillTokhai' table. You can move, or remove it, as needed.
        'Me.BangtheodoiBillTokhaiTableAdapter1.Fill(Me.HKLogDataSet1.BangtheodoiBillTokhai)
        'TODO: This line of code loads data into the 'HKLogDataSet.BangtheodoiBillTokhai' table. You can move, or remove it, as needed.
        'Me.BangtheodoiBillTokhaiTableAdapter.Fill(Me.HKLogDataSet.BangtheodoiBillTokhai)
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

            ' cus
            id = "customer_id"
            value = "company"
            Me.cbocus.Items.Clear()


            strSQL = "Select customer_id,company From customer order by company "
            loadDataToObject(Me.cbocus, strSQL, id, value)
        Catch ex As Exception

        End Try
    End Sub

    

  
   
    Private Sub GridControl1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub GridControl1_Click_1(sender As Object, e As EventArgs)
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Me.GridControl1.ShowPrintPreview()
        Catch ex As Exception

        End Try
    End Sub
End Class